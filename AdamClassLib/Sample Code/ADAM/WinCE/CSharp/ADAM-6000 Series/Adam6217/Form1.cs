using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Advantech.Adam;
using System.Net.Sockets;

namespace Adam6217
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public partial class Form1 : Form
    {
        private bool m_bStart;
        private AdamSocket adamModbus;
        private Adam6000Type m_Adam6000Type;
        private string m_szIP;
        private int m_iPort;
        private int m_iCount;
        private int m_iAiTotal;
        private bool[] m_bChEnabled;
        private ushort[] m_byRange;

        public Form1()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            m_bStart = false;			// the action stops at the beginning
            m_szIP = "172.18.3.189";	// modbus slave IP address
            m_iPort = 502;				// modbus TCP port is 502
            adamModbus = new AdamSocket();
            adamModbus.SetTimeout(1000, 1000, 1000); // set timeout for TCP
            adamModbus.AdamSeriesType = AdamType.Adam6200; // set AdamSeriesType for  ADAM-6217
            m_Adam6000Type = Adam6000Type.Adam6217; // the sample is for ADAM-6217

            m_iAiTotal = AnalogInput.GetChannelTotal(m_Adam6000Type);

            txtModule.Text = m_Adam6000Type.ToString();
            m_bChEnabled = new bool[m_iAiTotal];
            m_byRange = new ushort[m_iAiTotal];
        }

        private void Form1_Closing(object sender, CancelEventArgs e)
        {
            if (m_bStart)
            {
                timer1.Enabled = false;
                adamModbus.Disconnect(); // disconnect slave
            }
        }

        private void RefreshChannelRange(int i_iChannel)
        {
            ushort usRange;
            if (adamModbus.AnalogInput().GetInputRange(i_iChannel, out usRange))
                m_byRange[i_iChannel] = usRange;
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
                chkboxCh7.Checked = m_bChEnabled[7];
            }
            else
                txtReadCount.Text += "GetChannelEnabled() failed;";
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

        private void RefreshChannelValue()
        {
            int iStart = 1;
            int iIdx;
            int[] iData;
            float[] fValue = new float[m_iAiTotal];

            if (adamModbus.Modbus().ReadInputRegs(iStart, m_iAiTotal, out iData))
            {
                for (iIdx = 0; iIdx < m_iAiTotal; iIdx++)
                    fValue[iIdx] = AnalogInput.GetScaledValue(m_Adam6000Type, m_byRange[iIdx], (ushort)iData[iIdx]);

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

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            m_iCount++; // increment the reading counter
            txtReadCount.Text = "Read Input Regs " + m_iCount.ToString() + " times...";
            RefreshChannelValue();

            timer1.Enabled = true;		
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (m_bStart) // was started
            {
                m_bStart = false;		// starting flag
                timer1.Enabled = false; // disable timer
                adamModbus.Disconnect(); // disconnect slave
                buttonStart.Text = "Start";
            }
            else	// was stoped
            {
                if (adamModbus.Connect(m_szIP, ProtocolType.Tcp, m_iPort))
                {
                    m_iCount = 0; // reset the reading counter
                    timer1.Enabled = true; // enable timer
                    buttonStart.Text = "Stop";
                    m_bStart = true; // starting flag

                    RefreshChannelRange(7);
                    RefreshChannelRange(6);
                    RefreshChannelRange(5);
                    RefreshChannelRange(4);
                    RefreshChannelRange(3);
                    RefreshChannelRange(2);
                    RefreshChannelRange(1);
                    RefreshChannelRange(0);

                    RefreshChannelEnabled();
                }
                else
                    MessageBox.Show("Connect to " + m_szIP + " failed", "Error");
            }
        }
    }
}