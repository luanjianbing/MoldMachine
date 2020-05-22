using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Advantech.Adam;
using Advantech.Common;

namespace Adam4015_15T
{
    public partial class Form1 : Form
    {
        private int m_iCom, m_iAddr, m_iCount;
        private bool m_bStart;
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
            //m_Adam4000Type = Adam4000Type.Adam4015; // the sample is for ADAM-4015
            m_Adam4000Type = Adam4000Type.Adam4015T; // the sample is for ADAM-4015T
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
            float[] values;
            Adam4000_ChannelStatus[] status;

            m_iCount++;
            txtReadCount.Text = "Polling " + m_iCount.ToString() + " times...";
            if (adamCom.AnalogInput(m_iAddr).GetValues(6, out values, out status))
            {
                RefreshValue(ref txtAIValue0, status[0], values[0]);
                RefreshValue(ref txtAIValue1, status[1], values[1]);
                RefreshValue(ref txtAIValue2, status[2], values[2]);
                RefreshValue(ref txtAIValue3, status[3], values[3]);
                RefreshValue(ref txtAIValue4, status[4], values[4]);
                RefreshValue(ref txtAIValue5, status[5], values[5]);
            }
            else
            {
                txtAIValue0.Text = "Failed to get!";
                txtAIValue1.Text = "Failed to get!";
                txtAIValue2.Text = "Failed to get!";
                txtAIValue3.Text = "Failed to get!";
                txtAIValue4.Text = "Failed to get!";
                txtAIValue5.Text = "Failed to get!";
            }
        }

        private void RefreshChannelEnable()
        {
            bool[] bEnabled;

            if (adamCom.AnalogInput(m_iAddr).GetChannelEnabled(6, out bEnabled))
            {
                chkboxCh0.Checked = bEnabled[0];
                chkboxCh1.Checked = bEnabled[1];
                chkboxCh2.Checked = bEnabled[2];
                chkboxCh3.Checked = bEnabled[3];
                chkboxCh4.Checked = bEnabled[4];
                chkboxCh5.Checked = bEnabled[5];
            }
            else
                MessageBox.Show("GetChannelEnabled() failed", "Error");
        }

        private void RefreshValue(ref TextBox i_txtCh, Adam4000_ChannelStatus i_status, float i_fValue)
        {
            if (i_status == Adam4000_ChannelStatus.Normal)
            {
                if (m_adamConfig.Format == Adam4000_DataFormat.EngineerUnit)
                {
                    if (m_adamConfig.Temperature == Adam_Temperature.Centigrade)
                        i_txtCh.Text = i_fValue.ToString("#0.0") + " 'C";
                    else
                        i_txtCh.Text = i_fValue.ToString("#0.0") + " 'F";
                }
                else // ohms
                    i_txtCh.Text = i_fValue.ToString("#0.000") + " ohms";
            }
            else
                i_txtCh.Text = i_status.ToString();
        }
    }
}