using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Advantech.Adam;
using System.Net.Sockets;

namespace Adam6015_17_18
{
    public partial class Form1 : Form
    {
        private bool m_bStart;
        private AdamSocket adamModbus, adamUDP;
        private Adam6000Type m_Adam6000Type;
        private string m_szIP;
        private string m_szFwVersion;
        const int m_Adam6000NewerFwVer = 5;
        private int m_DeviceFwVer = 4;
        private int m_iPort;
        private int m_iCount;
        private int m_iAiTotal, m_iDoTotal;
        private bool[] m_bChEnabled;
        private byte[] m_byRange;
        private ushort[] m_usRange; //for newer version Adam6017

        public Form1()
        {
            InitializeComponent();

            m_bStart = false;			// the action stops at the beginning
            m_szIP = "172.18.3.237";	// modbus slave IP address
            m_iPort = 502;				// modbus TCP port is 502
            adamModbus = new AdamSocket();
            adamModbus.SetTimeout(1000, 1000, 1000); // set timeout for TCP
            adamUDP = new AdamSocket();
            adamUDP.SetTimeout(1000, 1000, 1000); // set timeout for UDP

            //m_Adam6000Type = Adam6000Type.Adam6015; // the sample is for ADAM-6015
            m_Adam6000Type = Adam6000Type.Adam6017; // the sample is for ADAM-6017
            //m_Adam6000Type = Adam6000Type.Adam6018; // the sample is for ADAM-6018

            adamUDP.Connect(AdamType.Adam6000, m_szIP, ProtocolType.Udp);
            if (adamUDP.Configuration().GetFirmwareVer(out m_szFwVersion))
                m_DeviceFwVer = int.Parse(m_szFwVersion.Trim().Substring(0, 1));
            adamUDP.Disconnect();

            m_iAiTotal = AnalogInput.GetChannelTotal(m_Adam6000Type);
            m_iDoTotal = DigitalOutput.GetChannelTotal(m_Adam6000Type);

            txtModule.Text = m_Adam6000Type.ToString();
            m_bChEnabled = new bool[m_iAiTotal];

            if (m_DeviceFwVer < m_Adam6000NewerFwVer)
            {
                m_byRange = new byte[m_iAiTotal];
            }
            else
            {
                //for newer version Adam
                m_usRange = new ushort[m_iAiTotal];
            }

            // arrange channel text box

            if (m_Adam6000Type == Adam6000Type.Adam6015)
            {
                // Channel
                chkboxCh7.Visible = false;
                txtAIValue7.Visible = false;
                // DO
                panelDO.Visible = false;
            }
            else if (m_Adam6000Type == Adam6000Type.Adam6017)
            {
                // DO
                btnCh2.Visible = false;
                txtCh2.Visible = false;
                btnCh3.Visible = false;
                txtCh3.Visible = false;
                btnCh4.Visible = false;
                txtCh4.Visible = false;
                btnCh5.Visible = false;
                txtCh5.Visible = false;
                btnCh6.Visible = false;
                txtCh6.Visible = false;
                btnCh7.Visible = false;
                txtCh7.Visible = false;
            }
            else  //Adam6018
            {
                ;
            }
        }

        private void Form1_Closing(object sender, CancelEventArgs e)
        {
            adamUDP.Disconnect();

            if (m_bStart)
            {
                timer1.Enabled = false;
                adamModbus.Disconnect(); // disconnect slave
            }
        }

        private void RefreshChannelRangeByteFormat(int i_iChannel)
        {
            byte byRange;
            if (adamModbus.AnalogInput().GetInputRange(i_iChannel, out byRange))
                m_byRange[i_iChannel] = byRange;
            else
                txtReadCount.Text += "GetRangeCode() failed;";
        }

        private void RefreshChannelRangeUshortFormat(int i_iChannel)
        {
            //for newer version Adam
            ushort usRange;
            if (adamModbus.AnalogInput().GetInputRange(i_iChannel, out usRange))
                m_usRange[i_iChannel] = usRange;
            else
                txtReadCount.Text += "GetRangeCode() failed;";
        }

        private void RefreshChannelEnabled()
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
                chkboxCh6.Checked = m_bChEnabled[6];
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
                if (!m_bChEnabled[6])
                    txtCh6.Text = "";
                if (m_Adam6000Type == Adam6000Type.Adam6017 ||
                    m_Adam6000Type == Adam6000Type.Adam6018)
                {
                    chkboxCh7.Checked = m_bChEnabled[7];
                    if (!m_bChEnabled[7])
                        txtCh7.Text = "";
                }
            }
            else
                txtReadCount.Text += "GetChannelEnabled() failed;";
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (m_bStart) // was started
            {
                panelDO.Enabled = false;
                m_bStart = false;		// starting flag
                timer1.Enabled = false; // disable timer
                adamModbus.Disconnect(); // disconnect slave
                buttonStart.Text = "Start";
            }
            else	// was stoped
            {
                if (adamModbus.Connect(m_szIP, ProtocolType.Tcp, m_iPort))
                {
                    panelDO.Enabled = true;
                    m_iCount = 0; // reset the reading counter
                    timer1.Enabled = true; // enable timer
                    buttonStart.Text = "Stop";
                    m_bStart = true; // starting flag

                    if (m_DeviceFwVer < m_Adam6000NewerFwVer)
                    {
                        if (m_Adam6000Type == Adam6000Type.Adam6017 ||
                            m_Adam6000Type == Adam6000Type.Adam6018)
                            RefreshChannelRangeByteFormat(7);
                        RefreshChannelRangeByteFormat(6);
                        RefreshChannelRangeByteFormat(5);
                        RefreshChannelRangeByteFormat(4);
                        RefreshChannelRangeByteFormat(3);
                        RefreshChannelRangeByteFormat(2);
                        RefreshChannelRangeByteFormat(1);
                        RefreshChannelRangeByteFormat(0);
                    }
                    else
                    {
                        //for newer version Adam
                        if (m_Adam6000Type == Adam6000Type.Adam6017 ||
                            m_Adam6000Type == Adam6000Type.Adam6018)
                            RefreshChannelRangeUshortFormat(7);
                        RefreshChannelRangeUshortFormat(6);
                        RefreshChannelRangeUshortFormat(5);
                        RefreshChannelRangeUshortFormat(4);
                        RefreshChannelRangeUshortFormat(3);
                        RefreshChannelRangeUshortFormat(2);
                        RefreshChannelRangeUshortFormat(1);
                        RefreshChannelRangeUshortFormat(0);
                    }

                    RefreshChannelEnabled();
                }
                else
                    MessageBox.Show("Connect to " + m_szIP + " failed", "Error");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            m_iCount++; // increment the reading counter
            txtReadCount.Text = "Read coil " + m_iCount.ToString() + " times...";

            if (m_DeviceFwVer < m_Adam6000NewerFwVer)
                RefreshChannelValueByteFormat(); 
            else
                RefreshChannelValueUshortFormat(); //for newer version Adam

            RefreshDO();

            timer1.Enabled = true;
        }

        private void RefreshDO()
        {
            int iStart = 17;
            bool[] bData = new bool[m_iDoTotal];

            if (m_iDoTotal == 0)
            {
            }
            else
            {
                if (adamModbus.Modbus().ReadCoilStatus(iStart, m_iDoTotal, out bData))
                {

                    if (m_iDoTotal > 0)
                        txtCh0.Text = bData[0].ToString();
                    if (m_iDoTotal > 1)
                        txtCh1.Text = bData[1].ToString();
                    if (m_iDoTotal > 2)
                        txtCh2.Text = bData[2].ToString();
                    if (m_iDoTotal > 3)
                        txtCh3.Text = bData[3].ToString();
                    if (m_iDoTotal > 4)
                        txtCh4.Text = bData[4].ToString();
                    if (m_iDoTotal > 5)
                        txtCh5.Text = bData[5].ToString();
                    if (m_iDoTotal > 6)
                        txtCh6.Text = bData[6].ToString();
                    if (m_iDoTotal > 7)
                        txtCh7.Text = bData[7].ToString();

                }
                else
                {
                    txtCh0.Text = "Fail";
                    txtCh1.Text = "Fail";
                    txtCh2.Text = "Fail";
                    txtCh3.Text = "Fail";
                    txtCh4.Text = "Fail";
                    txtCh5.Text = "Fail";
                    txtCh6.Text = "Fail";
                    txtCh7.Text = "Fail";
                }
            }
        }

        private void RefreshSingleChannel(int i_iIndex, ref TextBox txtCh, float fValue)
        {
            string szFormat;

            if (m_bChEnabled[i_iIndex])
            {
                szFormat = AnalogInput.GetFloatFormat(m_Adam6000Type, m_byRange[i_iIndex]);
                txtCh.Text = fValue.ToString(szFormat) + " " + AnalogInput.GetUnitName(m_Adam6000Type, m_byRange[i_iIndex]);
            }
        }

        private void RefreshSingleChannelBurn(int i_iIndex, ref TextBox i_txtCh, float i_fValue, bool i_bBurn)
        {
            string szFormat;

            if (m_bChEnabled[i_iIndex])
            {
                if (i_bBurn)
                    i_txtCh.Text = "Burn out";
                else
                {
                    szFormat = AnalogInput.GetFloatFormat(m_Adam6000Type, m_byRange[i_iIndex]);
                    i_txtCh.Text = i_fValue.ToString(szFormat) + " " + AnalogInput.GetUnitName(m_Adam6000Type, m_byRange[i_iIndex]);
                }
            }
        }

        private void RefreshSingleChannelWithAiStatus(int i_iIndex, ref TextBox i_txtCh, float i_fValue, ushort i_usAiStatus)
        {
            string szFormat;
            string szRange;
            string szErrorMsg = string.Empty;
            string szComma = " , ";
            szRange = AnalogInput.GetRangeName(m_Adam6000Type, m_usRange[i_iIndex]);

            if (m_bChEnabled[i_iIndex])
            {
                if (i_usAiStatus == (ushort)Adam_AiStatus_LowAddress.No_Fault_Detected)
                {
                    szErrorMsg = string.Empty;
                    szFormat = AnalogInput.GetFloatFormat(m_Adam6000Type, m_usRange[i_iIndex]);
                    i_txtCh.Text = i_fValue.ToString(szFormat) + " " + AnalogInput.GetUnitName(m_Adam6000Type, m_usRange[i_iIndex]);
                }
                else
                {
                    if ((i_usAiStatus & (ushort)Adam_AiStatus_LowAddress.FailToProvideAiValueUartTimeout) == (ushort)Adam_AiStatus_LowAddress.FailToProvideAiValueUartTimeout)
                    {
                        szErrorMsg = "Fail to provide AI value (UART timeout)";
                    }
                    else if ((i_usAiStatus & (ushort)Adam_AiStatus_LowAddress.Over_Range) == (ushort)Adam_AiStatus_LowAddress.Over_Range)
                    {
                        szErrorMsg = (szErrorMsg == string.Empty) ? ("Over Range") : (szErrorMsg + szComma + "Over Range");
                    }
                    else if ((i_usAiStatus & (ushort)Adam_AiStatus_LowAddress.Under_Range) == (ushort)Adam_AiStatus_LowAddress.Under_Range)
                    {
                        szErrorMsg = (szErrorMsg == string.Empty) ? ("Under Range") : (szErrorMsg + szComma + "Under Range");
                    }
                    else if ((i_usAiStatus & (ushort)Adam_AiStatus_LowAddress.Open_Circuit_Burnout) == (ushort)Adam_AiStatus_LowAddress.Open_Circuit_Burnout)
                    {
                        szErrorMsg = (szErrorMsg == string.Empty) ? ("Open Circuit (Burnout)") : (szErrorMsg + szComma + "Open Circuit (Burnout)");
                    }
                    else if ((i_usAiStatus & (ushort)Adam_AiStatus_LowAddress.Zero_Span_CalibrationError) == (ushort)Adam_AiStatus_LowAddress.Zero_Span_CalibrationError)
                    {
                        szErrorMsg = (szErrorMsg == string.Empty) ? ("Zero/Span Calibration Error") : (szErrorMsg + szComma + "Zero/Span Calibration Error");
                    }
                    i_txtCh.Text = szErrorMsg;
                }
            }
        }

        private void RefreshChannelValueUshortFormat()
        {
            int iStart = 1, iAiStatusStart = 101;
            int iIdx;
            int[] iData, iAiStatus;
            float[] fValue = new float[m_iAiTotal];

            if (adamModbus.Modbus().ReadInputRegs(iStart, m_iAiTotal, out iData))
            {
                for (iIdx = 0; iIdx < m_iAiTotal; iIdx++)
                {
                    fValue[iIdx] = AnalogInput.GetScaledValue(m_Adam6000Type, m_usRange[iIdx], (ushort)iData[iIdx]);
                }

                if (adamModbus.Modbus().ReadInputRegs(iAiStatusStart, (m_iAiTotal * 2), out iAiStatus))
                {
                    RefreshSingleChannelWithAiStatus(0, ref txtAIValue0, fValue[0], (ushort)iAiStatus[(0 * 2)]);
                    RefreshSingleChannelWithAiStatus(1, ref txtAIValue1, fValue[1], (ushort)iAiStatus[(1 * 2)]);
                    RefreshSingleChannelWithAiStatus(2, ref txtAIValue2, fValue[2], (ushort)iAiStatus[(2 * 2)]);
                    RefreshSingleChannelWithAiStatus(3, ref txtAIValue3, fValue[3], (ushort)iAiStatus[(3 * 2)]);
                    RefreshSingleChannelWithAiStatus(4, ref txtAIValue4, fValue[4], (ushort)iAiStatus[(4 * 2)]);
                    RefreshSingleChannelWithAiStatus(5, ref txtAIValue5, fValue[5], (ushort)iAiStatus[(5 * 2)]);
                    RefreshSingleChannelWithAiStatus(6, ref txtAIValue6, fValue[6], (ushort)iAiStatus[(6 * 2)]);

                    if ((m_Adam6000Type == Adam6000Type.Adam6017) || (m_Adam6000Type == Adam6000Type.Adam6018))
                    {
                        RefreshSingleChannelWithAiStatus(7, ref txtAIValue7, fValue[7], (ushort)iAiStatus[(7 * 2)]);
                    }
                }
            }
        }

        private void RefreshChannelValueByteFormat()
        {
            int iStart = 1, iBurnStart = 121;
            int iIdx;
            int[] iData;
            float[] fValue = new float[m_iAiTotal];
            bool[] bBurn = new bool[m_iAiTotal];

            if (adamModbus.Modbus().ReadInputRegs(iStart, m_iAiTotal, out iData))
            {
                for (iIdx = 0; iIdx < m_iAiTotal; iIdx++)
                    fValue[iIdx] = AnalogInput.GetScaledValue(m_Adam6000Type, m_byRange[iIdx], iData[iIdx]);
                
                if (m_Adam6000Type == Adam6000Type.Adam6015)
                {
                    if (adamModbus.Modbus().ReadCoilStatus(iBurnStart, m_iAiTotal, out bBurn)) // read burn out flag
                    {
                        RefreshSingleChannelBurn(0, ref txtAIValue0, fValue[0], bBurn[0]);
                        RefreshSingleChannelBurn(1, ref txtAIValue1, fValue[1], bBurn[1]);
                        RefreshSingleChannelBurn(2, ref txtAIValue2, fValue[2], bBurn[2]);
                        RefreshSingleChannelBurn(3, ref txtAIValue3, fValue[3], bBurn[3]);
                        RefreshSingleChannelBurn(4, ref txtAIValue4, fValue[4], bBurn[4]);
                        RefreshSingleChannelBurn(5, ref txtAIValue5, fValue[5], bBurn[5]);
                        RefreshSingleChannelBurn(6, ref txtAIValue6, fValue[6], bBurn[6]);
                    }
                }
                else
                {
                    RefreshSingleChannel(0, ref txtAIValue0, fValue[0]);
                    RefreshSingleChannel(1, ref txtAIValue1, fValue[1]);
                    RefreshSingleChannel(2, ref txtAIValue2, fValue[2]);
                    RefreshSingleChannel(3, ref txtAIValue3, fValue[3]);
                    RefreshSingleChannel(4, ref txtAIValue4, fValue[4]);
                    RefreshSingleChannel(5, ref txtAIValue5, fValue[5]);
                    RefreshSingleChannel(6, ref txtAIValue6, fValue[6]);
                    RefreshSingleChannel(7, ref txtAIValue7, fValue[7]);
                }
            }
        }

        private void btnCh_Click(int i_iCh, TextBox txtBox)
        {
            int iOnOff, iStart = 17 + i_iCh;

            timer1.Enabled = false;
            if (txtBox.Text == "True") // was ON, now set to OFF
            {
                iOnOff = 0;
            }
            else
            {
                iOnOff = 1;
            }
            if (adamModbus.Modbus().ForceSingleCoil(iStart, iOnOff))
                RefreshDO();
            else
                MessageBox.Show("Set digital output failed!", "Error");
            timer1.Enabled = true;
        }

        private void btnCh0_Click(object sender, EventArgs e)
        {
            btnCh_Click(0, txtCh0);
        }

        private void btnCh1_Click(object sender, EventArgs e)
        {
            btnCh_Click(1, txtCh1);
        }

        private void btnCh2_Click(object sender, EventArgs e)
        {
            btnCh_Click(2, txtCh2);
        }

        private void btnCh3_Click(object sender, EventArgs e)
        {
            btnCh_Click(3, txtCh3);
        }

        private void btnCh4_Click(object sender, EventArgs e)
        {
            btnCh_Click(4, txtCh4);
        }

        private void btnCh5_Click(object sender, EventArgs e)
        {
            btnCh_Click(5, txtCh5);
        }

        private void btnCh6_Click(object sender, EventArgs e)
        {
            btnCh_Click(6, txtCh6);
        }

        private void btnCh7_Click(object sender, EventArgs e)
        {
            btnCh_Click(7, txtCh7);
        }
    }
}