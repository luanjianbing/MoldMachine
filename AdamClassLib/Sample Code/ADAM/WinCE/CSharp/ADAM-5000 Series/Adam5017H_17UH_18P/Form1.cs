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

namespace Adam5017H_17UH_18P
{
    public partial class Form1 : Form
    {
        private int m_iCom, m_iAddr, m_iSlot, m_iCount, m_iChTotal;
        private bool m_bStart, m_b5000;
        private byte[] m_byRange;
        private byte m_byFormat;
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
            m_iAddr = 3;	// the slave address is 1
            m_iSlot = 0;	// the slot index of the module
            m_iCount = 0;	// the counting start from 0
            m_bStart = false;
            m_Adam5000Type = Adam5000Type.Adam5017H; // the sample is for ADAM-5017H
            //m_Adam5000Type = Adam5000Type.Adam5017UH; // the sample is for ADAM-5017UH
            //m_Adam5000Type = Adam5000Type.Adam5018P; // the sample is for ADAM-5018P

            m_iChTotal = AnalogInput.GetChannelTotal(m_Adam5000Type);
            m_byRange = new byte[m_iChTotal];
            txtModule.Text = m_Adam5000Type.ToString();
            //
            if (m_Adam5000Type == Adam5000Type.Adam5018P)
            {
                chkboxCh7.Visible = false;
                txtAIValue7.Visible = false;
            }
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
                            RefreshFormat();
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
                            RefreshFormat();
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
            RefreshChannelValue();
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

        private bool RefreshRange(int i_iChannel)
        {
            byte byRange;
            bool bRet;

            if (m_b5000)
                bRet = adamCom.AnalogInput(m_iAddr).GetInputRange(m_iSlot, i_iChannel, out byRange);
            else
                bRet = adamSocket.AnalogInput(m_iAddr).GetInputRange(m_iSlot, i_iChannel, out byRange);
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

        private void RefreshFormat()
        {
            bool bRet;

            if (m_b5000)
                bRet = adamCom.AnalogInput(m_iAddr).GetDataFormat(m_iSlot, out m_byFormat);
            else
                bRet = adamSocket.AnalogInput(m_iAddr).GetDataFormat(m_iSlot, out m_byFormat);
            if (!bRet)
                MessageBox.Show("Get format failed", "Error");
        }

        private void RefreshChannelValue()
        {
            int iStart = m_iSlot * 8 + 1;
            int iIdx;
            int[] iData;
            float[] fValue;
            string szFormat;

            if (m_b5000)
            {
                if (m_byFormat == (byte)Adam5000_DataFormat.EngineerUnit)
                {
                    if (adamCom.AnalogInput(m_iAddr).GetValues(m_iSlot, m_iChTotal, out fValue))
                    {
                        // 
                        szFormat = AnalogInput.GetFloatFormat(m_Adam5000Type, m_byRange[0]);
                        //
                        if (chkboxCh0.Checked)
                            txtAIValue0.Text = fValue[0].ToString(szFormat) + " " + AnalogInput.GetUnitName(m_Adam5000Type, m_byRange[0]);
                        if (chkboxCh1.Checked)
                            txtAIValue1.Text = fValue[1].ToString(szFormat) + " " + AnalogInput.GetUnitName(m_Adam5000Type, m_byRange[1]);
                        if (chkboxCh2.Checked)
                            txtAIValue2.Text = fValue[2].ToString(szFormat) + " " + AnalogInput.GetUnitName(m_Adam5000Type, m_byRange[2]);
                        if (chkboxCh3.Checked)
                            txtAIValue3.Text = fValue[3].ToString(szFormat) + " " + AnalogInput.GetUnitName(m_Adam5000Type, m_byRange[3]);
                        if (chkboxCh4.Checked)
                            txtAIValue4.Text = fValue[4].ToString(szFormat) + " " + AnalogInput.GetUnitName(m_Adam5000Type, m_byRange[4]);
                        if (chkboxCh5.Checked)
                            txtAIValue5.Text = fValue[5].ToString(szFormat) + " " + AnalogInput.GetUnitName(m_Adam5000Type, m_byRange[5]);
                        if (chkboxCh6.Checked)
                            txtAIValue6.Text = fValue[6].ToString(szFormat) + " " + AnalogInput.GetUnitName(m_Adam5000Type, m_byRange[6]);
                        if (chkboxCh7.Checked)
                            txtAIValue7.Text = fValue[7].ToString(szFormat) + " " + AnalogInput.GetUnitName(m_Adam5000Type, m_byRange[7]);
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
                else if (m_byFormat == (byte)Adam5000_DataFormat.TwosComplementHex)
                {
                    if (adamCom.AnalogInput(m_iAddr).GetValues(m_iSlot, m_iChTotal, out iData))
                    {
                        szFormat = "X04";
                        //
                        if (chkboxCh0.Checked)
                            txtAIValue0.Text = "0x" + iData[0].ToString(szFormat) + " " + AnalogInput.GetUnitName(m_Adam5000Type, m_byRange[0]);
                        if (chkboxCh1.Checked)
                            txtAIValue1.Text = "0x" + iData[1].ToString(szFormat) + " " + AnalogInput.GetUnitName(m_Adam5000Type, m_byRange[1]);
                        if (chkboxCh2.Checked)
                            txtAIValue2.Text = "0x" + iData[2].ToString(szFormat) + " " + AnalogInput.GetUnitName(m_Adam5000Type, m_byRange[2]);
                        if (chkboxCh3.Checked)
                            txtAIValue3.Text = "0x" + iData[3].ToString(szFormat) + " " + AnalogInput.GetUnitName(m_Adam5000Type, m_byRange[3]);
                        if (chkboxCh4.Checked)
                            txtAIValue4.Text = "0x" + iData[4].ToString(szFormat) + " " + AnalogInput.GetUnitName(m_Adam5000Type, m_byRange[4]);
                        if (chkboxCh5.Checked)
                            txtAIValue5.Text = "0x" + iData[5].ToString(szFormat) + " " + AnalogInput.GetUnitName(m_Adam5000Type, m_byRange[5]);
                        if (chkboxCh6.Checked)
                            txtAIValue6.Text = "0x" + iData[6].ToString(szFormat) + " " + AnalogInput.GetUnitName(m_Adam5000Type, m_byRange[6]);
                        if (chkboxCh7.Checked)
                            txtAIValue7.Text = "0x" + iData[7].ToString(szFormat) + " " + AnalogInput.GetUnitName(m_Adam5000Type, m_byRange[7]);
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
            else
            {
                if (adamSocket.Modbus().ReadInputRegs(iStart, m_iChTotal, out iData))
                {
                    fValue = new float[m_iChTotal];
                    for (iIdx = 0; iIdx < m_iChTotal; iIdx++)
                        fValue[iIdx] = AnalogInput.GetScaledValue(m_Adam5000Type, m_byRange[iIdx], iData[iIdx]);
                    // 
                    szFormat = AnalogInput.GetFloatFormat(m_Adam5000Type, m_byRange[0]);
                    //
                    if (chkboxCh0.Checked)
                        txtAIValue0.Text = fValue[0].ToString(szFormat) + " " + AnalogInput.GetUnitName(m_Adam5000Type, m_byRange[0]);
                    if (chkboxCh1.Checked)
                        txtAIValue1.Text = fValue[1].ToString(szFormat) + " " + AnalogInput.GetUnitName(m_Adam5000Type, m_byRange[1]);
                    if (chkboxCh2.Checked)
                        txtAIValue2.Text = fValue[2].ToString(szFormat) + " " + AnalogInput.GetUnitName(m_Adam5000Type, m_byRange[2]);
                    if (chkboxCh3.Checked)
                        txtAIValue3.Text = fValue[3].ToString(szFormat) + " " + AnalogInput.GetUnitName(m_Adam5000Type, m_byRange[3]);
                    if (chkboxCh4.Checked)
                        txtAIValue4.Text = fValue[4].ToString(szFormat) + " " + AnalogInput.GetUnitName(m_Adam5000Type, m_byRange[4]);
                    if (chkboxCh5.Checked)
                        txtAIValue5.Text = fValue[5].ToString(szFormat) + " " + AnalogInput.GetUnitName(m_Adam5000Type, m_byRange[5]);
                    if (chkboxCh6.Checked)
                        txtAIValue6.Text = fValue[6].ToString(szFormat) + " " + AnalogInput.GetUnitName(m_Adam5000Type, m_byRange[6]);
                    if (chkboxCh7.Checked)
                        txtAIValue7.Text = fValue[7].ToString(szFormat) + " " + AnalogInput.GetUnitName(m_Adam5000Type, m_byRange[7]);
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
    }
}