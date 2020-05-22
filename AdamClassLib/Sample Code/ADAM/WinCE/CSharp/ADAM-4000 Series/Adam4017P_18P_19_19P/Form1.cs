﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Advantech.Adam;
using Advantech.Common;

namespace Adam4017P_18P_19_19P
{
    public partial class Form1 : Form
    {
        private int m_iCom, m_iAddr, m_iCount, m_iChTotal;
        private bool m_bStart;
        private byte[] m_byRange;
        private Adam4000Config m_adamConfig;
        private Adam4000Type m_Adam4000Type;
        private AdamCom adamCom;


        public Form1()
        {
            InitializeComponent();

            m_iCom = 4;		// using COM4
            m_iAddr = 1;	// the slave address is 1
            m_iCount = 0;	// the counting start from 0
            m_bStart = false;
            m_Adam4000Type = Adam4000Type.Adam4017P; // the sample is for ADAM-4017P
            //m_Adam4000Type = Adam4000Type.Adam4018P; // the sample is for ADAM-4018P
            //m_Adam4000Type = Adam4000Type.Adam4019; // the sample is for ADAM-4019
            //m_Adam4000Type = Adam4000Type.Adam4019P; // the sample is for ADAM-4019P

            m_iChTotal = AnalogInput.GetChannelTotal(m_Adam4000Type);
            m_byRange = new byte[m_iChTotal];
            adamCom = new AdamCom(m_iCom);
            adamCom.Checksum = false; // disbale checksum

            txtModule.Text = m_Adam4000Type.ToString();
        }

        private void Form1_Closing(object sender, CancelEventArgs e)
        {
            if (m_bStart)
            {
                timer1.Enabled = false; // disable timer
                adamCom.CloseComPort(); // close the COM port
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (m_bStart) // was started
            {
                m_bStart = false;
                timer1.Enabled = false;
                adamCom.CloseComPort();
                buttonStart.Text = "Start";
            }
            else
            {
                if (adamCom.OpenComPort())
                {
                    // set COM port state, 9600,N,8,1
                    adamCom.SetComPortState(Baudrate.Baud_9600, Databits.Eight, Parity.None, Stopbits.One);
                    // set COM port timeout
                    adamCom.SetComPortTimeout(500, 500, 0, 500, 0);
                    m_iCount = 0; // reset the reading counter
                    // get module config
                    if (!adamCom.Configuration(m_iAddr).GetModuleConfig(out m_adamConfig))
                    {
                        adamCom.CloseComPort();
                        MessageBox.Show("Failed to get module config!", "Error");
                        return;
                    }
                    //
                    RefreshChannelEnable();
                    RefreshChannelRange();
                    //
                    timer1.Enabled = true; // enable timer
                    buttonStart.Text = "Stop";
                    m_bStart = true; // starting flag
                }
                else
                    MessageBox.Show("Failed to open COM port!", "Error");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            float[] fVals;
            int[] iVals;
            Adam4000_ChannelStatus[] status;

            m_iCount++;
            txtReadCount.Text = "Polling " + m_iCount.ToString() + " times...";
            if (m_adamConfig.Format == Adam4000_DataFormat.TwosComplementHex)
            {
                if (adamCom.AnalogInput(m_iAddr).GetValues(8, out iVals))
                {
                    txtAIValue0.Text = "0x" + iVals[0].ToString("X04");
                    txtAIValue1.Text = "0x" + iVals[1].ToString("X04");
                    txtAIValue2.Text = "0x" + iVals[2].ToString("X04");
                    txtAIValue3.Text = "0x" + iVals[3].ToString("X04");
                    txtAIValue4.Text = "0x" + iVals[4].ToString("X04");
                    txtAIValue5.Text = "0x" + iVals[5].ToString("X04");
                    txtAIValue6.Text = "0x" + iVals[6].ToString("X04");
                    txtAIValue7.Text = "0x" + iVals[7].ToString("X04");
                }
                else
                {
                    txtAIValue0.Text = "Failed to get!";
                    txtAIValue1.Text = "Failed to get!";
                    txtAIValue2.Text = "Failed to get!";
                    txtAIValue3.Text = "Failed to get!";
                    txtAIValue4.Text = "Failed to get!";
                    txtAIValue5.Text = "Failed to get!";
                    txtAIValue6.Text = "Failed to get!";
                    txtAIValue7.Text = "Failed to get!";
                }
            }
            else
            {
                if (adamCom.AnalogInput(m_iAddr).GetValues(8, out fVals, out status))
                {
                    RefreshValue(ref txtAIValue0, status[0], fVals[0], m_byRange[0]);
                    RefreshValue(ref txtAIValue1, status[1], fVals[1], m_byRange[1]);
                    RefreshValue(ref txtAIValue2, status[2], fVals[2], m_byRange[2]);
                    RefreshValue(ref txtAIValue3, status[3], fVals[3], m_byRange[3]);
                    RefreshValue(ref txtAIValue4, status[4], fVals[4], m_byRange[4]);
                    RefreshValue(ref txtAIValue5, status[5], fVals[5], m_byRange[5]);
                    RefreshValue(ref txtAIValue6, status[6], fVals[6], m_byRange[6]);
                    RefreshValue(ref txtAIValue7, status[7], fVals[7], m_byRange[7]);
                }
                else
                {
                    txtAIValue0.Text = "Failed to get!";
                    txtAIValue1.Text = "Failed to get!";
                    txtAIValue2.Text = "Failed to get!";
                    txtAIValue3.Text = "Failed to get!";
                    txtAIValue4.Text = "Failed to get!";
                    txtAIValue5.Text = "Failed to get!";
                    txtAIValue6.Text = "Failed to get!";
                    txtAIValue7.Text = "Failed to get!";
                }
            }
        }

        private void RefreshChannelEnable()
        {
            bool[] bEnabled;

            if (adamCom.AnalogInput(m_iAddr).GetChannelEnabled(8, out bEnabled))
            {
                chkboxCh0.Checked = bEnabled[0];
                chkboxCh1.Checked = bEnabled[1];
                chkboxCh2.Checked = bEnabled[2];
                chkboxCh3.Checked = bEnabled[3];
                chkboxCh4.Checked = bEnabled[4];
                chkboxCh5.Checked = bEnabled[5];
                chkboxCh6.Checked = bEnabled[6];
                chkboxCh7.Checked = bEnabled[7];
            }
            else
                MessageBox.Show("GetChannelEnabled() failed", "Error");
        }

        private void RefreshChannelRange()
        {
            byte byRange;
            int iIdx;

            for (iIdx = 0; iIdx < m_iChTotal; iIdx++)
            {
                if (adamCom.AnalogInput(m_iAddr).GetInputRange(iIdx, out byRange))
                    m_byRange[iIdx] = byRange;
                else
                {
                    MessageBox.Show("GetRangeCode() failed", "Error");
                    break;
                }
            }
        }

        private void RefreshValue(ref TextBox i_txtCh, Adam4000_ChannelStatus i_status, float i_fValue, byte i_byRange)
        {
            if (i_status == Adam4000_ChannelStatus.Normal)
            {
                if (m_adamConfig.Format == Adam4000_DataFormat.EngineerUnit)
                    i_txtCh.Text = i_fValue.ToString(AnalogInput.GetFloatFormat(m_Adam4000Type, i_byRange)) + " " + AnalogInput.GetUnitName(m_Adam4000Type, i_byRange);
                else if (m_adamConfig.Format == Adam4000_DataFormat.Percent)
                    i_txtCh.Text = i_fValue.ToString("#0.00") + " %";
            }
            else
                i_txtCh.Text = i_status.ToString();
        }
    }
}