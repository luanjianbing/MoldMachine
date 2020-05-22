using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Advantech.Adam;
using System.Net.Sockets;

namespace Adam6024
{
    public partial class Form1 : Form
    {
        private int m_iCount;
        private int m_iAiTotal, m_iAoTotal, m_iDiTotal, m_iDoTotal;
        private bool[] m_bChEnabled;
        private byte[] m_byAiRange, m_byAoRange;
        private bool m_bStart;
        private AdamSocket adamModbus;
        private Adam6000Type m_Adam6000Type;
        private string m_szIP;
        private int m_iPort;

        public Form1()
        {
            InitializeComponent();

            int iIdx;

            m_bStart = false;			// the action stops at the beginning
            m_szIP = "172.18.3.200";	// modbus slave IP address
            m_iPort = 502;				// modbus TCP port is 502
            adamModbus = new AdamSocket();
            adamModbus.SetTimeout(1000, 1000, 1000); // set timeout for TCP

            m_Adam6000Type = Adam6000Type.Adam6024; // the sample is for ADAM-6050

            // modbus current list view item
            m_iAiTotal = AnalogInput.GetChannelTotal(m_Adam6000Type);
            m_iDiTotal = DigitalInput.GetChannelTotal(m_Adam6000Type);
            m_iAoTotal = AnalogOutput.GetChannelTotal(m_Adam6000Type);
            m_iDoTotal = DigitalOutput.GetChannelTotal(m_Adam6000Type);

            m_bChEnabled = new bool[m_iAiTotal];
            m_byAiRange = new byte[m_iAiTotal];
            m_byAoRange = new byte[m_iAoTotal];

            for (iIdx = 0; iIdx < m_iAoTotal; iIdx++)
            {
                //
                cbxAOChannel.Items.Add(iIdx.ToString());
                //
            }
            cbxAOChannel.SelectedIndex = -1;

            txtModule.Text = m_Adam6000Type.ToString();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_bStart)
            {
                timer1.Enabled = false;
                adamModbus.Disconnect(); // disconnect slave
            }
        }

        private void RefreshAiChannelRange(int i_iChannel)
        {
            byte byRange;
            if (adamModbus.AnalogInput().GetInputRange(i_iChannel, out byRange))
                m_byAiRange[i_iChannel] = byRange;
            else
                txtReadCount.Text += "GetInputRange() failed;";
        }

        private void RefreshAoChannelRange(int i_iChannel)
        {
            byte byRange;
            if (adamModbus.AnalogOutput().GetConfiguration(i_iChannel, out byRange))
                m_byAoRange[i_iChannel] = byRange;
            else
                txtReadCount.Text += "GetConfiguration() failed;";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            m_iCount++; // increment the reading counter
            txtReadCount.Text = "Read coil " + m_iCount.ToString() + " times...";
            RefreshAiChannelValue();
            RefreshDI();
            RefreshAoChannelValue(cbxAOChannel.SelectedIndex);
            RefreshDO();
            timer1.Enabled = true;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (m_bStart) // was started
            {
                panelDO.Enabled = false;
                panelOutput.Enabled = false;
                m_bStart = false;		// starting flag
                timer1.Enabled = false; // disable timer
                adamModbus.Disconnect(); // disconnect slave
                buttonStart.Text = "Start";
            }
            else	// was stoped
            {
                if (adamModbus.Connect(m_szIP, ProtocolType.Tcp, m_iPort))
                {
                    RefreshAiChannelRange(5);
                    RefreshAiChannelRange(4);
                    RefreshAiChannelRange(3);
                    RefreshAiChannelRange(2);
                    RefreshAiChannelRange(1);
                    RefreshAiChannelRange(0);
                    RefreshAoChannelRange(1);
                    RefreshAoChannelRange(0);

                    cbxAOChannel.SelectedIndex = 0;
                    RefreshAiChannelEnabled();

                    panelDO.Enabled = true;
                    panelOutput.Enabled = true;
                    m_iCount = 0; // reset the reading counter
                    timer1.Enabled = true; // enable timer
                    buttonStart.Text = "Stop";
                    m_bStart = true; // starting flag
                }
                else
                    MessageBox.Show("Connect to " + m_szIP + " failed", "Error");
            }
        }

        private void RefreshOutputValue(int i_iChannel)
        {
            int iStart = 11 + i_iChannel;
            int[] iData;
            float fValue;
            string szFormat;
            Adam6024_OutputRange byRange;

            if (adamModbus.Modbus().ReadInputRegs(iStart, 1, out iData))
            {
                fValue = AnalogOutput.GetScaledValue(m_Adam6000Type, m_byAoRange[i_iChannel], iData[0]);
                // 
                szFormat = AnalogOutput.GetFloatFormat(m_Adam6000Type, m_byAoRange[i_iChannel]);
                byRange = (Adam6024_OutputRange)m_byAoRange[i_iChannel];

                if (byRange == Adam6024_OutputRange.mA_0To20) // 0~20mA
                {
                    lblLow.Text = "0 mA";
                    lblHigh.Text = "20 mA";
                    trackBar1.Value = Convert.ToInt32(fValue * trackBar1.Maximum / 20);
                }
                else if (byRange == Adam6024_OutputRange.mA_4To20) // 4~20mA
                {
                    lblLow.Text = "4 mA";
                    lblHigh.Text = "20 mA";
                    trackBar1.Value = Convert.ToInt32((fValue - 4.0) * trackBar1.Maximum / 16);
                }
                else // 0~10V
                {
                    lblLow.Text = "0 V";
                    lblHigh.Text = "10 V";
                    trackBar1.Value = Convert.ToInt32(fValue * trackBar1.Maximum / 10);
                }
                txtOutputValue.Text = fValue.ToString(szFormat);
            }
            else
                txtReadCount.Text += "ReadInputRegs() failed;";
        }

        private void RefreshAiChannelEnabled()
        {
            bool[] bEnabled;

            if (adamModbus.AnalogInput().GetChannelEnabled(m_iAiTotal, out bEnabled))
            {
                Array.Copy(bEnabled, 0, m_bChEnabled, 0, m_iAiTotal);
                chkboxCh0.Checked = m_bChEnabled[0];
                chkboxCh1.Checked = m_bChEnabled[1];
                chkboxCh2.Checked = m_bChEnabled[2];
                chkboxCh3.Checked = m_bChEnabled[3];
                chkboxCh4.Checked = m_bChEnabled[4];
                chkboxCh5.Checked = m_bChEnabled[5];
                if (!m_bChEnabled[0])
                    txtCh0.Text = "";
                if (!m_bChEnabled[1])
                    txtCh1.Text = "";
                if (!m_bChEnabled[2])
                    txtCh2.Text = "";
                if (!m_bChEnabled[3])
                    txtCh3.Text = "";
                if (!m_bChEnabled[4])
                    txtCh4.Text = "";
                if (!m_bChEnabled[5])
                    txtCh5.Text = "";
            }
            else
                txtReadCount.Text += "GetChannelEnabled() failed;";
        }

        private void RefreshDI()
        {
            int iStart = 1;
            bool[] bData;

            if (adamModbus.Modbus().ReadCoilStatus(iStart, m_iDiTotal, out bData))
            {
                txtDICh0.Text = bData[0].ToString();
                txtDICh1.Text = bData[1].ToString();
            }
            else
            {
                txtDICh0.Text = "Fail";
                txtDICh1.Text = "Fail";
            }
        }

        private void RefreshDO()
        {
            int iStart = 17;
            bool[] bData;

            if (adamModbus.Modbus().ReadCoilStatus(iStart, m_iDoTotal, out bData))
            {
                txtDOCh0.Text = bData[0].ToString();
                txtDOCh1.Text = bData[1].ToString();
            }
            else
            {
                txtDOCh0.Text = "Fail";
                txtDOCh1.Text = "Fail";
            }
        }

        private void RefreshSingleAiChannel(int i_iIndex, ref TextBox txtCh, float fValue, int i_iStatus)
        {
            string szFormat;

            if (m_bChEnabled[i_iIndex])
            {
                if (i_iStatus == 0)
                {
                    szFormat = AnalogInput.GetFloatFormat(m_Adam6000Type, m_byAiRange[i_iIndex]);
                    txtCh.Text = fValue.ToString(szFormat) + " " + AnalogInput.GetUnitName(m_Adam6000Type, m_byAiRange[i_iIndex]);
                }
                else if (i_iStatus == 1)
                    txtCh.Text = "Over(H)";
                else if (i_iStatus == 2)
                    txtCh.Text = "Over(L)";
                else
                    txtCh.Text = "Invalid(R)";
            }
        }

        private void RefreshAiChannelValue()
        {
            int iStart = 1, iStatusStart = 21;
            int iIdx;
            int[] iData;
            float[] fValue = new float[m_iAiTotal];
            int[] iStatus = new int[m_iAiTotal];

            if (adamModbus.Modbus().ReadInputRegs(iStart, m_iAiTotal, out iData) &&
                adamModbus.Modbus().ReadInputRegs(iStatusStart, m_iAiTotal, out iStatus))
            {
                for (iIdx = 0; iIdx < m_iAiTotal; iIdx++)
                    fValue[iIdx] = AnalogInput.GetScaledValue(m_Adam6000Type, m_byAiRange[iIdx], iData[iIdx]);
                RefreshSingleAiChannel(0, ref txtCh0, fValue[0], iStatus[0]);
                RefreshSingleAiChannel(1, ref txtCh1, fValue[1], iStatus[1]);
                RefreshSingleAiChannel(2, ref txtCh2, fValue[2], iStatus[2]);
                RefreshSingleAiChannel(3, ref txtCh3, fValue[3], iStatus[3]);
                RefreshSingleAiChannel(4, ref txtCh4, fValue[4], iStatus[4]);
                RefreshSingleAiChannel(5, ref txtCh5, fValue[5], iStatus[5]);
            }
            else
            {
                txtReadCount.Text += "ReadInputRegs() failed;";
            }
        }

        private void RefreshAoChannelValue(int i_iChannel)
        {
            int iStart = 11 + i_iChannel;
            int[] iData;
            float fValue;
            string szFormat;

            if (adamModbus.Modbus().ReadInputRegs(iStart, 1, out iData))
            {
                fValue = AnalogOutput.GetScaledValue(m_Adam6000Type, m_byAoRange[i_iChannel], iData[0]);
                // 
                szFormat = AnalogOutput.GetFloatFormat(m_Adam6000Type, m_byAoRange[i_iChannel]);
                //
                txtCurrentValue.Text = fValue.ToString(szFormat) + " " + AnalogOutput.GetUnitName(m_Adam6000Type, m_byAoRange[i_iChannel]);
            }
            else
            {
                txtReadCount.Text += "ReadInputRegs() failed;";
            }
        }

        private void btnApplyOutput_Click(object sender, EventArgs e)
        {
            int iChannel = cbxAOChannel.SelectedIndex;
            int iStart = 11 + iChannel;
            int iValue;

            timer1.Enabled = false;
            iValue = trackBar1.Value;
            if (iValue > 4095)
                iValue = 4095;
            if (adamModbus.Modbus().PresetSingleReg(iStart, iValue))
            {
                System.Threading.Thread.Sleep(500);
                RefreshAoChannelValue(iChannel);
                RefreshOutputValue(iChannel);
            }
            else
                MessageBox.Show("Change current value failed!", "Error");
            timer1.Enabled = true;
        }

        private void btnCh_Click(int i_iCh, TextBox txtBox)
        {
            int iOnOff, iStart = 17 + i_iCh;

            timer1.Enabled = false;
            if (txtBox.Text == "True") // was ON, now set to OFF
                iOnOff = 0;
            else
                iOnOff = 1;
            if (adamModbus.Modbus().ForceSingleCoil(iStart, iOnOff))
                RefreshDO();
            else
                MessageBox.Show("Set digital output failed!", "Error");
            timer1.Enabled = true;
        }

        private void btnDOCh0_Click(object sender, EventArgs e)
        {
            btnCh_Click(0, txtDOCh0);
        }

        private void btnDOCh1_Click(object sender, EventArgs e)
        {
            btnCh_Click(1, txtDOCh1);
        }

        private void cbxAOChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            int iChannel = cbxAOChannel.SelectedIndex;
            timer1.Enabled = false;
            RefreshAoChannelValue(iChannel);
            RefreshOutputValue(iChannel);
            timer1.Enabled = true;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            int iCh;
            float fValue;
            Adam6024_OutputRange byRange;

            if (m_bStart) // was started
            {
                timer1.Enabled = false;
                iCh = cbxAOChannel.SelectedIndex;
                fValue = Convert.ToSingle(trackBar1.Value);
                byRange = (Adam6024_OutputRange)m_byAoRange[iCh];
                if (byRange == Adam6024_OutputRange.mA_0To20) // 0~20mA
                    fValue = fValue * 20 / trackBar1.Maximum;
                else if (byRange == Adam6024_OutputRange.mA_4To20) // 4~20mA
                    fValue = 4.0f + fValue * 16 / trackBar1.Maximum;
                else // 0~10V
                    fValue = fValue * 10 / trackBar1.Maximum;
                txtOutputValue.Text = fValue.ToString("0.000");
                timer1.Enabled = true;
            }
        }
    }
}
