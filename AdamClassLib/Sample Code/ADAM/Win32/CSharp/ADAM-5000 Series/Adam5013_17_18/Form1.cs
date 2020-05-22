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

namespace Adam5013_17_18
{
    public partial class Form1 : Form
    {
        private int m_iCom, m_iAddr, m_iSlot, m_iCount, m_iChTotal;
        private bool m_bStart, m_b5000;
        private byte m_byRange, m_byFormat;
        private string m_szIP;
        private Adam5000Type m_Adam5000Type;
        private AdamCom adamCom;
        private AdamSocket adamSocket;


        public Form1()
        {
            InitializeComponent();

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
            //m_Adam5000Type = Adam5000Type.Adam5013; // the sample is for ADAM-5013
            //m_Adam5000Type = Adam5000Type.Adam5017; // the sample is for ADAM-5017
            m_Adam5000Type = Adam5000Type.Adam5018; // the sample is for ADAM-5018

            m_iChTotal = AnalogInput.GetChannelTotal(m_Adam5000Type);

            txtModule.Text = m_Adam5000Type.ToString();
            // 
            if (m_Adam5000Type == Adam5000Type.Adam5013)
            {
                chkboxCh3.Visible = false;
                txtAIValue3.Visible = false;
                chkboxCh4.Visible = false;
                txtAIValue4.Visible = false;
                chkboxCh5.Visible = false;
                txtAIValue5.Visible = false;
                chkboxCh6.Visible = false;
                txtAIValue6.Visible = false;
                chkboxCh7.Visible = false;
                txtAIValue7.Visible = false;
            }
            else if (m_Adam5000Type == Adam5000Type.Adam5018)
            {
                chkboxCh7.Visible = false;
                txtAIValue7.Visible = false;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
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
                            RefreshChannelEnable();
                            //
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
                            RefreshChannelEnable();
                            //
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
            if (m_Adam5000Type == Adam5000Type.Adam5013)
                RefreshAdam5013ChannelValue();
            else if (m_Adam5000Type == Adam5000Type.Adam5017)
                RefreshAdam5017ChannelValue();
            else
                RefreshAdam5018ChannelValue();
        }

        private void RefreshChannelEnable()
        {
            bool bRet;
            bool[] bEnabled;

            if (m_b5000)
                bRet = adamCom.AnalogInput(m_iAddr).GetChannelEnabled(m_iSlot, m_iChTotal, out bEnabled);
            else
                bRet = adamSocket.AnalogInput(m_iAddr).GetChannelEnabled(m_iSlot, m_iChTotal, out bEnabled);
            if (bRet)
            {
                if (m_iChTotal > 0)
                    chkboxCh0.Checked = bEnabled[0];
                if (m_iChTotal > 1)
                    chkboxCh1.Checked = bEnabled[1];
                if (m_iChTotal > 2)
                    chkboxCh2.Checked = bEnabled[2];
                if (m_iChTotal > 3)
                    chkboxCh3.Checked = bEnabled[3];
                if (m_iChTotal > 4)
                    chkboxCh4.Checked = bEnabled[4];
                if (m_iChTotal > 5)
                    chkboxCh5.Checked = bEnabled[5];
                if (m_iChTotal > 6)
                    chkboxCh6.Checked = bEnabled[6];
                if (m_iChTotal > 7)
                    chkboxCh7.Checked = bEnabled[7];
                txtAIValue0.Text = "";
                txtAIValue1.Text = "";
                txtAIValue2.Text = "";
                txtAIValue3.Text = "";
                txtAIValue4.Text = "";
                txtAIValue5.Text = "";
                txtAIValue6.Text = "";
                txtAIValue7.Text = "";
            }
            else
                MessageBox.Show("GetChannelEnabled() failed", "Error");
        }

        private bool RefreshChannelRange()
        {
            bool bRet;
            byte byIntegration;

            if (m_b5000)
                bRet = adamCom.AnalogInput(m_iAddr).GetRangeIntegrationDataFormat(m_iSlot, out m_byRange, out byIntegration, out m_byFormat);
            else
                bRet = adamSocket.AnalogInput(m_iAddr).GetRangeIntegration(m_iSlot, out m_byRange, out byIntegration);
            if (!bRet)
                MessageBox.Show("Get range failed!", "Error");
            return bRet;
        }

        private void RefreshAdam5013ChannelValue()
        {
            int iStart = m_iSlot * 8 + 1;
            int[] iData;
            float[] fVal;
            float fValue;
            string szFormat, szUnit;

            if (m_b5000)
            {
                if (adamCom.AnalogInput(m_iAddr).GetValues(m_iSlot, m_iChTotal, out fVal))
                {
                    if (m_byFormat == (byte)Adam5000_DataFormat.Ohms) // ohms
                    {
                        if (chkboxCh0.Checked)
                            txtAIValue0.Text = fVal[0].ToString() + " ohms";
                        if (chkboxCh1.Checked)
                            txtAIValue1.Text = fVal[1].ToString() + " ohms";
                        if (chkboxCh2.Checked)
                            txtAIValue2.Text = fVal[2].ToString() + " ohms";
                    }
                    else
                    {
                        // floating format
                        szFormat = AnalogInput.GetFloatFormat(m_Adam5000Type, m_byRange);
                        szUnit = AnalogInput.GetUnitName(m_Adam5000Type, m_byRange);
                        //
                        if (chkboxCh0.Checked)
                            txtAIValue0.Text = fVal[0].ToString(szFormat) + " " + szUnit;
                        if (chkboxCh1.Checked)
                            txtAIValue1.Text = fVal[1].ToString(szFormat) + " " + szUnit;
                        if (chkboxCh2.Checked)
                            txtAIValue2.Text = fVal[2].ToString(szFormat) + " " + szUnit;
                    }
                }
                else
                {
                    if (chkboxCh0.Checked)
                        txtAIValue0.Text = "Failed to get!";
                    if (chkboxCh1.Checked)
                        txtAIValue1.Text = "Failed to get!";
                    if (chkboxCh2.Checked)
                        txtAIValue2.Text = "Failed to get!";
                }
            }
            else
            {
                if (adamSocket.Modbus().ReadInputRegs(iStart, m_iChTotal, out iData))
                {
                    // floating format
                    szFormat = AnalogInput.GetFloatFormat(m_Adam5000Type, m_byRange);
                    szUnit = AnalogInput.GetUnitName(m_Adam5000Type, m_byRange);
                    //
                    if (chkboxCh0.Checked)
                    {
                        fValue = AnalogInput.GetScaledValue(m_Adam5000Type, m_byRange, iData[0]);
                        txtAIValue0.Text = fValue.ToString(szFormat) + " " + szUnit;
                    }
                    if (chkboxCh1.Checked)
                    {
                        fValue = AnalogInput.GetScaledValue(m_Adam5000Type, m_byRange, iData[1]);
                        txtAIValue1.Text = fValue.ToString(szFormat) + " " + szUnit;
                    }
                    if (chkboxCh2.Checked)
                    {
                        fValue = AnalogInput.GetScaledValue(m_Adam5000Type, m_byRange, iData[2]);
                        txtAIValue2.Text = fValue.ToString(szFormat) + " " + szUnit;
                    }
                }
                else
                {
                    if (chkboxCh0.Checked)
                        txtAIValue0.Text = "Failed to get!";
                    if (chkboxCh1.Checked)
                        txtAIValue1.Text = "Failed to get!";
                    if (chkboxCh2.Checked)
                        txtAIValue2.Text = "Failed to get!";
                }
            }
        }

        private void RefreshAdam5017ChannelValue()
        {
            int iStart = m_iSlot * 8 + 1;
            int[] iData;
            float[] fVal;
            float fValue;
            string szFormat, szUnit;

            if (m_b5000)
            {
                if (adamCom.AnalogInput(m_iAddr).GetValues(m_iSlot, m_iChTotal, out fVal))
                {
                    // floating format
                    szFormat = AnalogInput.GetFloatFormat(m_Adam5000Type, m_byRange);
                    szUnit = AnalogInput.GetUnitName(m_Adam5000Type, m_byRange);
                    //
                    if (chkboxCh0.Checked)
                        txtAIValue0.Text = fVal[0].ToString(szFormat) + " " + szUnit;
                    if (chkboxCh1.Checked)
                        txtAIValue1.Text = fVal[1].ToString(szFormat) + " " + szUnit;
                    if (chkboxCh2.Checked)
                        txtAIValue2.Text = fVal[2].ToString(szFormat) + " " + szUnit;
                    if (chkboxCh3.Checked)
                        txtAIValue3.Text = fVal[3].ToString(szFormat) + " " + szUnit;
                    if (chkboxCh4.Checked)
                        txtAIValue4.Text = fVal[4].ToString(szFormat) + " " + szUnit;
                    if (chkboxCh5.Checked)
                        txtAIValue5.Text = fVal[5].ToString(szFormat) + " " + szUnit;
                    if (chkboxCh6.Checked)
                        txtAIValue6.Text = fVal[6].ToString(szFormat) + " " + szUnit;
                    if (chkboxCh7.Checked)
                        txtAIValue7.Text = fVal[7].ToString(szFormat) + " " + szUnit;
                }
                else
                {
                    if (chkboxCh0.Checked)
                        txtAIValue0.Text = "Failed to get!";
                    if (chkboxCh1.Checked)
                        txtAIValue1.Text = "Failed to get!";
                    if (chkboxCh2.Checked)
                        txtAIValue2.Text = "Failed to get!";
                    if (chkboxCh3.Checked)
                        txtAIValue3.Text = "Failed to get!";
                    if (chkboxCh4.Checked)
                        txtAIValue4.Text = "Failed to get!";
                    if (chkboxCh5.Checked)
                        txtAIValue5.Text = "Failed to get!";
                    if (chkboxCh6.Checked)
                        txtAIValue6.Text = "Failed to get!";
                    if (chkboxCh7.Checked)
                        txtAIValue7.Text = "Failed to get!";
                }
            }
            else
            {
                if (adamSocket.Modbus().ReadInputRegs(iStart, m_iChTotal, out iData))
                {
                    // floating format
                    szFormat = AnalogInput.GetFloatFormat(m_Adam5000Type, m_byRange);
                    szUnit = AnalogInput.GetUnitName(m_Adam5000Type, m_byRange);
                    //
                    if (chkboxCh0.Checked)
                    {
                        fValue = AnalogInput.GetScaledValue(m_Adam5000Type, m_byRange, iData[0]);
                        txtAIValue0.Text = fValue.ToString(szFormat) + " " + szUnit;
                    }
                    if (chkboxCh1.Checked)
                    {
                        fValue = AnalogInput.GetScaledValue(m_Adam5000Type, m_byRange, iData[1]);
                        txtAIValue1.Text = fValue.ToString(szFormat) + " " + szUnit;
                    }
                    if (chkboxCh2.Checked)
                    {
                        fValue = AnalogInput.GetScaledValue(m_Adam5000Type, m_byRange, iData[2]);
                        txtAIValue2.Text = fValue.ToString(szFormat) + " " + szUnit;
                    }
                    if (chkboxCh3.Checked)
                    {
                        fValue = AnalogInput.GetScaledValue(m_Adam5000Type, m_byRange, iData[3]);
                        txtAIValue3.Text = fValue.ToString(szFormat) + " " + szUnit;
                    }
                    if (chkboxCh4.Checked)
                    {
                        fValue = AnalogInput.GetScaledValue(m_Adam5000Type, m_byRange, iData[4]);
                        txtAIValue4.Text = fValue.ToString(szFormat) + " " + szUnit;
                    }
                    if (chkboxCh5.Checked)
                    {
                        fValue = AnalogInput.GetScaledValue(m_Adam5000Type, m_byRange, iData[5]);
                        txtAIValue5.Text = fValue.ToString(szFormat) + " " + szUnit;
                    }
                    if (chkboxCh6.Checked)
                    {
                        fValue = AnalogInput.GetScaledValue(m_Adam5000Type, m_byRange, iData[6]);
                        txtAIValue6.Text = fValue.ToString(szFormat) + " " + szUnit;
                    }
                    if (chkboxCh7.Checked)
                    {
                        fValue = AnalogInput.GetScaledValue(m_Adam5000Type, m_byRange, iData[7]);
                        txtAIValue7.Text = fValue.ToString(szFormat) + " " + szUnit;
                    }
                }
                else
                {
                    if (chkboxCh0.Checked)
                        txtAIValue0.Text = "Failed to get!";
                    if (chkboxCh1.Checked)
                        txtAIValue1.Text = "Failed to get!";
                    if (chkboxCh2.Checked)
                        txtAIValue2.Text = "Failed to get!";
                    if (chkboxCh3.Checked)
                        txtAIValue3.Text = "Failed to get!";
                    if (chkboxCh4.Checked)
                        txtAIValue4.Text = "Failed to get!";
                    if (chkboxCh5.Checked)
                        txtAIValue5.Text = "Failed to get!";
                    if (chkboxCh6.Checked)
                        txtAIValue6.Text = "Failed to get!";
                    if (chkboxCh7.Checked)
                        txtAIValue7.Text = "Failed to get!";
                }
            }
        }

        private void RefreshAdam5018ChannelValue()
        {
            int iStart = m_iSlot * 8 + 1;
            int[] iData;
            float[] fVal;
            float fValue;
            string szFormat, szUnit;

            if (m_b5000)
            {
                if (adamCom.AnalogInput(m_iAddr).GetValues(m_iSlot, m_iChTotal, out fVal))
                {
                    // floating format
                    szFormat = AnalogInput.GetFloatFormat(m_Adam5000Type, m_byRange);
                    szUnit = AnalogInput.GetUnitName(m_Adam5000Type, m_byRange);
                    //
                    if (chkboxCh0.Checked)
                        txtAIValue0.Text = fVal[0].ToString(szFormat) + " " + szUnit;
                    if (chkboxCh1.Checked)
                        txtAIValue1.Text = fVal[1].ToString(szFormat) + " " + szUnit;
                    if (chkboxCh2.Checked)
                        txtAIValue2.Text = fVal[2].ToString(szFormat) + " " + szUnit;
                    if (chkboxCh3.Checked)
                        txtAIValue3.Text = fVal[3].ToString(szFormat) + " " + szUnit;
                    if (chkboxCh4.Checked)
                        txtAIValue4.Text = fVal[4].ToString(szFormat) + " " + szUnit;
                    if (chkboxCh5.Checked)
                        txtAIValue5.Text = fVal[5].ToString(szFormat) + " " + szUnit;
                    if (chkboxCh6.Checked)
                        txtAIValue6.Text = fVal[6].ToString(szFormat) + " " + szUnit;
                }
                else
                {
                    if (chkboxCh0.Checked)
                        txtAIValue0.Text = "Failed to get!";
                    if (chkboxCh1.Checked)
                        txtAIValue1.Text = "Failed to get!";
                    if (chkboxCh2.Checked)
                        txtAIValue2.Text = "Failed to get!";
                    if (chkboxCh3.Checked)
                        txtAIValue3.Text = "Failed to get!";
                    if (chkboxCh4.Checked)
                        txtAIValue4.Text = "Failed to get!";
                    if (chkboxCh5.Checked)
                        txtAIValue5.Text = "Failed to get!";
                    if (chkboxCh6.Checked)
                        txtAIValue6.Text = "Failed to get!";
                }
            }
            else
            {
                if (adamSocket.Modbus().ReadInputRegs(iStart, m_iChTotal, out iData))
                {
                    // floating format
                    szFormat = AnalogInput.GetFloatFormat(m_Adam5000Type, m_byRange);
                    szUnit = AnalogInput.GetUnitName(m_Adam5000Type, m_byRange);
                    //
                    if (chkboxCh0.Checked)
                    {
                        fValue = AnalogInput.GetScaledValue(m_Adam5000Type, m_byRange, iData[0]);
                        txtAIValue0.Text = fValue.ToString(szFormat) + " " + szUnit;
                    }
                    if (chkboxCh1.Checked)
                    {
                        fValue = AnalogInput.GetScaledValue(m_Adam5000Type, m_byRange, iData[1]);
                        txtAIValue1.Text = fValue.ToString(szFormat) + " " + szUnit;
                    }
                    if (chkboxCh2.Checked)
                    {
                        fValue = AnalogInput.GetScaledValue(m_Adam5000Type, m_byRange, iData[2]);
                        txtAIValue2.Text = fValue.ToString(szFormat) + " " + szUnit;
                    }
                    if (chkboxCh3.Checked)
                    {
                        fValue = AnalogInput.GetScaledValue(m_Adam5000Type, m_byRange, iData[3]);
                        txtAIValue3.Text = fValue.ToString(szFormat) + " " + szUnit;
                    }
                    if (chkboxCh4.Checked)
                    {
                        fValue = AnalogInput.GetScaledValue(m_Adam5000Type, m_byRange, iData[4]);
                        txtAIValue4.Text = fValue.ToString(szFormat) + " " + szUnit;
                    }
                    if (chkboxCh5.Checked)
                    {
                        fValue = AnalogInput.GetScaledValue(m_Adam5000Type, m_byRange, iData[5]);
                        txtAIValue5.Text = fValue.ToString(szFormat) + " " + szUnit;
                    }
                    if (chkboxCh6.Checked)
                    {
                        fValue = AnalogInput.GetScaledValue(m_Adam5000Type, m_byRange, iData[6]);
                        txtAIValue6.Text = fValue.ToString(szFormat) + " " + szUnit;
                    }
                }
                else
                {
                    if (chkboxCh0.Checked)
                        txtAIValue0.Text = "Failed to get!";
                    if (chkboxCh1.Checked)
                        txtAIValue1.Text = "Failed to get!";
                    if (chkboxCh2.Checked)
                        txtAIValue2.Text = "Failed to get!";
                    if (chkboxCh3.Checked)
                        txtAIValue3.Text = "Failed to get!";
                    if (chkboxCh4.Checked)
                        txtAIValue4.Text = "Failed to get!";
                    if (chkboxCh5.Checked)
                        txtAIValue5.Text = "Failed to get!";
                    if (chkboxCh6.Checked)
                        txtAIValue6.Text = "Failed to get!";
                }
            }
        }
    }
}
