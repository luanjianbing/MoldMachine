using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using Advantech.Adam;
using Advantech.Common;

namespace Adam5080
{
    public partial class Form1 : Form
    {
        private int m_iCom, m_iAddr, m_iSlot, m_iCount, m_iChTotal;
        private bool m_bStart, m_b5000;
        private byte m_byMode;
        private string m_szIP;
        private Adam5000Type m_Adam5000Type;
        private AdamCom adamCom;
        private AdamSocket adamSocket;

        public Form1()
        {
            InitializeComponent();

            int iIdx;
            m_b5000 = true; // set to true for module on ADAM-5000; set to false for module on ADAM-5000/TCP
            if (m_b5000)
            {
                m_iCom = 2;		// using COM2
                adamCom = new AdamCom(m_iCom);
                adamCom.Checksum = false; // disbale checksum
            }
            else
            {
                m_szIP = "172.18.3.179";
                adamSocket = new AdamSocket();
                adamSocket.SetTimeout(1000, 1000, 1000); // set timeout
            }
            m_iAddr = 1;	// the slave address is 1
            m_iSlot = 0;	// the slot index of the module
            m_iCount = 0;	// the counting start from 0
            m_bStart = false;
            m_Adam5000Type = Adam5000Type.Adam5080; // the sample is for ADAM-5080

            m_iChTotal = Counter.GetChannelTotal(m_Adam5000Type);
            for (iIdx = 0; iIdx < m_iChTotal; iIdx++)
                cbxChannel.Items.Add(iIdx.ToString());
            txtModule.Text = m_Adam5000Type.ToString();
        }

        private void Form1_Closing(object sender, CancelEventArgs e)
        {
            if (m_bStart)
            {
                timer1.Enabled = false; // disable timer
                if (m_b5000)
                    adamCom.CloseComPort(); // close the COM port
                else
                    adamSocket.Disconnect();
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (m_bStart) // was started
            {
                panelCount.Enabled = false;
                m_bStart = false;
                timer1.Enabled = false;
                if (m_b5000)
                    adamCom.CloseComPort();
                else
                    adamSocket.Disconnect();
                buttonStart.Text = "Start";
            }
            else
            {
                if (m_b5000)
                {
                    if (adamCom.OpenComPort())
                    {
                        // set COM port state, 9600,N,8,1
                        adamCom.SetComPortState(Baudrate.Baud_9600, Databits.Eight, Parity.None, Stopbits.One);
                        // set COM port timeout
                        adamCom.SetComPortTimeout(500, 500, 0, 500, 0);
                        m_iCount = 0; // reset the reading counter
                        //
                        if (RefreshMode())
                        {
                            cbxChannel.SelectedIndex = 0;
                            if (m_byMode != (byte)Adam5080_CounterMode.Frequency)
                                panelCount.Enabled = true;
                            timer1.Enabled = true; // enable timer
                            buttonStart.Text = "Stop";
                            m_bStart = true; // starting flag
                        }
                        else
                            adamCom.CloseComPort();
                    }
                    else
                        MessageBox.Show("Failed to open COM port!", "Error");
                }
                else
                {
                    if (adamSocket.Connect(AdamType.Adam5000Tcp, m_szIP, ProtocolType.Tcp))
                    {
                        m_iCount = 0; // reset the reading counter
                        //
                        if (RefreshMode())
                        {
                            cbxChannel.SelectedIndex = 0;
                            if (m_byMode != (byte)Adam5080_CounterMode.Frequency)
                                panelCount.Enabled = true;
                            timer1.Enabled = true; // enable timer
                            buttonStart.Text = "Stop";
                            m_bStart = true; // starting flag
                        }
                        else
                            adamSocket.Disconnect();
                    }
                    else
                        MessageBox.Show("Failed to connect to " + m_szIP + "!", "Error");
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int iCh;
            m_iCount++;
            txtReadCount.Text = "Polling " + m_iCount.ToString() + " times...";
            RefreshChannelValue(0, ref txtCounter0);
            RefreshChannelValue(1, ref txtCounter1);
            RefreshChannelValue(2, ref txtCounter2);
            RefreshChannelValue(3, ref txtCounter3);
            iCh = cbxChannel.SelectedIndex;
            RefreshStatus(iCh);
        }

        private bool RefreshMode()
        {
            byte byDataFormat;
            bool bRet;

            if (m_b5000)
                bRet = adamCom.Counter(m_iAddr).GetModeFormat(m_iSlot, out m_byMode, out byDataFormat);
            else
                bRet = adamSocket.Counter(m_iAddr).GetMode(m_iSlot, out m_byMode);
            if (!bRet)
                MessageBox.Show("Get mode failed", "Error");
            return bRet;
        }

        private void RefreshChannelValue(int i_iChannel, ref TextBox i_txtCh)
        {
            int iStart = m_iSlot * 8 + i_iChannel * 2 + 1;
            int iHigh, iLow;
            double fValue;
            int[] iData;

            if (m_b5000)
            {
                if (adamCom.Counter(m_iAddr).GetValue(m_iSlot, i_iChannel, m_byMode, out fValue))
                {
                    i_txtCh.Text = fValue.ToString(Counter.GetFormat(m_Adam5000Type, m_byMode)) + " " +
                        Counter.GetUnitName(m_Adam5000Type, m_byMode);
                }
                else
                    i_txtCh.Text = "Failed to get";
            }
            else
            {
                if (adamSocket.Modbus(m_iAddr).ReadInputRegs(iStart, 2, out iData))
                {
                    iLow = iData[0];
                    iHigh = iData[1];

                    fValue = Counter.GetScaledValue(m_Adam5000Type, m_byMode, iHigh, iLow);
                    i_txtCh.Text = fValue.ToString(Counter.GetFormat(m_Adam5000Type, m_byMode)) + " " +
                        Counter.GetUnitName(m_Adam5000Type, m_byMode);
                }
                else
                    i_txtCh.Text = "Failed to get";
            }
        }

        private void RefreshStatus(int i_iChannel)
        {
            int iStart = m_iSlot * 16 + i_iChannel * 4 + 1;
            bool[] bData;
            bool bCount;

            if (panelCount.Enabled == false)
                return;

            if (m_b5000)
            {
                // Start/Stop counting
                if (adamCom.Counter(m_iAddr).GetStatus(m_iSlot, i_iChannel, out bCount) &&
                    adamCom.Counter(m_iAddr).GetOverflowFlag(m_Adam5000Type, m_iSlot, out bData))
                {
                    txtCounting.Text = bCount.ToString();				// Start/Stop counting
                    txtOverflow.Text = bData[i_iChannel].ToString();	// overflow flag
                }
                else
                {
                    txtCounting.Text = "Failed to get";
                    txtOverflow.Text = "Failed to get";
                }
            }
            else
            {
                if (adamSocket.Modbus(m_iAddr).ReadCoilStatus(iStart, 4, out bData))
                {
                    txtCounting.Text = bData[0].ToString();	// bit 0, Start/Stop counting
                    txtOverflow.Text = bData[2].ToString();	// bit 2, overflow flag
                }
                else
                {
                    txtCounting.Text = "Failed to get";
                    txtOverflow.Text = "Failed to get";
                }
            }
        }

        private void cbxChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            int iCh;
            timer1.Enabled = false;
            iCh = cbxChannel.SelectedIndex;
            RefreshStatus(iCh);
            timer1.Enabled = true;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            int iChannel;
            bool bRet;

            timer1.Enabled = false;
            iChannel = cbxChannel.SelectedIndex;
            if (m_b5000)
                bRet = adamCom.Counter(m_iAddr).SetStatus(m_iSlot, iChannel, true);
            else
                bRet = adamSocket.Counter(m_iAddr).SetStatus(m_iSlot, iChannel, true);
            if (!bRet)
                MessageBox.Show("Set counter start failed!", "Error");
            timer1.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            int iChannel;
            bool bRet;

            timer1.Enabled = false;
            iChannel = cbxChannel.SelectedIndex;
            if (m_b5000)
                bRet = adamCom.Counter(m_iAddr).SetStatus(m_iSlot, iChannel, false);
            else
                bRet = adamSocket.Counter(m_iAddr).SetStatus(m_iSlot, iChannel, false);
            if (!bRet)
                MessageBox.Show("Set counter stop failed!", "Error");
            timer1.Enabled = true;
        }

        private void btnClearCounter_Click(object sender, EventArgs e)
        {
            int iChannel;
            bool bRet;

            timer1.Enabled = false;
            iChannel = cbxChannel.SelectedIndex;
            if (m_b5000)
                bRet = adamCom.Counter(m_iAddr).SetToStartup(m_iSlot, iChannel);
            else
                bRet = adamSocket.Counter(m_iAddr).SetToStartup(m_iSlot, iChannel);
            if (!bRet)
                MessageBox.Show("Set counter to startup value failed!", "Error");
            timer1.Enabled = true;
        }
    }
}