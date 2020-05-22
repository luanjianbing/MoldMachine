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

namespace Adam5024
{
    public partial class Form1 : Form
    {
        private int m_iCom, m_iAddr, m_iSlot, m_iCount, m_iChTotal;
        private bool m_bStart, m_b5000;
        private byte[] m_byRange;
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
                m_iCom = 4;		// using COM4
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
            m_Adam5000Type = Adam5000Type.Adam5024; // the sample is for ADAM-5024

            m_iChTotal = AnalogOutput.GetChannelTotal(m_Adam5000Type);
            m_byRange = new byte[m_iChTotal];
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
                panelAO.Enabled = false;
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
                        if (RefreshChannelRange())
                        {
                            cbxChannel.SelectedIndex = 0;
                            panelAO.Enabled = true;
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
                        if (RefreshChannelRange())
                        {
                            cbxChannel.SelectedIndex = 0;
                            panelAO.Enabled = true;
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
            m_iCount++;
            txtReadCount.Text = "Polling " + m_iCount.ToString() + " times...";
            RefreshChannelValue(0, ref txtAO0);
            RefreshChannelValue(1, ref txtAO1);
            RefreshChannelValue(2, ref txtAO2);
            RefreshChannelValue(3, ref txtAO3);
        }

        private bool RefreshRange(int i_iChannel)
        {
            byte byRange, bySlewrate;
            bool bRet;

            if (m_b5000)
                bRet = adamCom.AnalogOutput(m_iAddr).GetConfiguration(m_iSlot, i_iChannel, out byRange, out bySlewrate);
            else
                bRet = adamSocket.AnalogOutput(m_iAddr).GetConfiguration(m_iSlot, i_iChannel, out byRange);
            if (bRet)
                m_byRange[i_iChannel] = byRange;
            return bRet;
        }

        private bool RefreshChannelRange()
        {
            bool bRet = true;
            int iIdx;

            for (iIdx = 0; iIdx < m_iChTotal; iIdx++)
            {
                bRet = RefreshRange(iIdx);
                if (!bRet)
                {
                    MessageBox.Show("Get range failed", "Error");
                    break;
                }
            }
            return bRet;
        }

        private void RefreshChannelValue(int i_iChannel, ref TextBox i_txtCh)
        {
            int iStart = m_iSlot * 8 + i_iChannel + 1;
            int[] iData;
            float fValue;
            string szFormat;

            if (m_b5000)
            {
                if (adamCom.AnalogOutput(m_iAddr).GetCurrentValue(m_iSlot, i_iChannel, out fValue))
                {
                    szFormat = AnalogOutput.GetFloatFormat(m_Adam5000Type, m_byRange[i_iChannel]);
                    i_txtCh.Text = fValue.ToString(szFormat) + " " + AnalogOutput.GetUnitName(m_Adam5000Type, m_byRange[i_iChannel]);
                }
                else
                    i_txtCh.Text = "Failed to get";
            }
            else
            {
                if (adamSocket.Modbus(m_iAddr).ReadInputRegs(iStart, 1, out iData))
                {
                    fValue = AnalogOutput.GetScaledValue(m_Adam5000Type, m_byRange[i_iChannel], iData[0]);
                    // 
                    szFormat = AnalogOutput.GetFloatFormat(m_Adam5000Type, m_byRange[i_iChannel]);
                    //
                    i_txtCh.Text = fValue.ToString(szFormat) + " " + AnalogOutput.GetUnitName(m_Adam5000Type, m_byRange[i_iChannel]);
                }
                else
                    i_txtCh.Text = "Failed to get";
            }
        }

        private void cbxChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            int iCh;
            float fValue;
            Adam5024_OutputRange byRange;

            timer1.Enabled = false;
            iCh = cbxChannel.SelectedIndex;
            fValue = Convert.ToSingle(trackBar1.Value);
            byRange = (Adam5024_OutputRange)m_byRange[iCh];
            if (byRange == Adam5024_OutputRange.mA_0To20) // 0~20mA
            {
                lblLow.Text = "0 mA";
                lblHigh.Text = "20 mA";
                fValue = fValue * 20 / trackBar1.Maximum;
            }
            else if (byRange == Adam5024_OutputRange.mA_4To20) // 4~20mA
            {
                lblLow.Text = "4 mA";
                lblHigh.Text = "20 mA";
                fValue = 4.0f + fValue * 16 / trackBar1.Maximum;
            }
            else // 0~10V
            {
                lblLow.Text = "0 V";
                lblHigh.Text = "10 V";
                fValue = fValue * 10 / trackBar1.Maximum;
            }
            txtOutputValue.Text = fValue.ToString("#0.000");
            timer1.Enabled = true;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            int iCh;
            float fValue;
            Adam5024_OutputRange byRange;

            timer1.Enabled = false;
            iCh = cbxChannel.SelectedIndex;
            fValue = Convert.ToSingle(trackBar1.Value);
            byRange = (Adam5024_OutputRange)m_byRange[iCh];
            if (byRange == Adam5024_OutputRange.mA_0To20) // 0~20mA
                fValue = fValue * 20 / trackBar1.Maximum;
            else if (byRange == Adam5024_OutputRange.mA_4To20) // 4~20mA
                fValue = 4.0f + fValue * 16 / trackBar1.Maximum;
            else // 0~10V
                fValue = fValue * 10 / trackBar1.Maximum;
            txtOutputValue.Text = fValue.ToString("#0.000");
            timer1.Enabled = true;
        }

        private void btnApplyOutput_Click(object sender, EventArgs e)
        {
            bool bRet;
            int iChannel;
            float fValue;

            timer1.Enabled = false;
            iChannel = cbxChannel.SelectedIndex;
            fValue = Convert.ToSingle(txtOutputValue.Text);
            if (m_b5000)
                bRet = adamCom.AnalogOutput(m_iAddr).SetCurrentValue(m_iSlot, iChannel, fValue);
            else
                bRet = adamSocket.AnalogOutput(m_iAddr).SetCurrentValue(m_iSlot, iChannel, fValue);
            if (bRet)
                System.Threading.Thread.Sleep(500);
            else
                MessageBox.Show("Change current value failed!", "Error");
            timer1.Enabled = true;
        }
    }
}