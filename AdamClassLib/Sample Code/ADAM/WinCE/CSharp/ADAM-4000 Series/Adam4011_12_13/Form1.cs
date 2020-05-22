using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Advantech.Adam;
using Advantech.Common;

namespace Adam4011_12_13
{
    public partial class Form1 : Form
    {
        private int m_iCom, m_iAddr, m_iCount;
        private bool[] m_DOStatus;
        private bool m_bStart;
        private Adam4000Config m_adamConfig;
        private Adam4000Type m_Adam4000Type;
        private AdamCom adamCom;

        public Form1()
        {
            InitializeComponent();

            m_iCom = 4;		// using COM4
            m_iAddr = 19;	// the slave address is 1
            m_iCount = 0;	// the counting start from 0
            m_DOStatus = new bool[2];
            m_bStart = false;
            m_Adam4000Type = Adam4000Type.Adam4011; // the sample is for ADAM-4011
            //m_Adam4000Type = Adam4000Type.Adam4011D; // the sample is for ADAM-4011D
            //m_Adam4000Type = Adam4000Type.Adam4012; // the sample is for ADAM-4012
            //m_Adam4000Type = Adam4000Type.Adam4013; // the sample is for ADAM-4013
            adamCom = new AdamCom(m_iCom);
            adamCom.Checksum = false; // disable checksum

            txtModule.Text = m_Adam4000Type.ToString();
            if (m_Adam4000Type == Adam4000Type.Adam4013)
            {
                panelEvent.Visible = false;
                panelAlarm.Visible = false;
            }
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
            bool[] DOStatus;
            Adam_AIAlarmMode mode;

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
                    // detect alarm
                    // for ADAM-4011, ADAM-4011D, or ADAM-4012
                    if (m_Adam4000Type != Adam4000Type.Adam4013)
                    {
                        if (adamCom.Alarm(m_iAddr).GetModeAlarmDO(2, out mode, out DOStatus))
                        {
                            m_DOStatus[0] = DOStatus[0];
                            m_DOStatus[1] = DOStatus[1];
                            txtMode.Text = mode.ToString();
                            if (mode == Adam_AIAlarmMode.Disable) // alarm is disabled
                            {
                                buttonDO0.Enabled = true;
                                buttonDO1.Enabled = true;
                            }
                            else
                            {
                                buttonDO0.Enabled = false;
                                buttonDO1.Enabled = false;
                            }
                        }
                    }
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
            long lVal;
            bool bDI;
            float[] fVal;
            bool[] DOStatus;
            Adam4000_ChannelStatus[] status;
            Adam_AIAlarmMode mode;

            m_iCount++;
            txtReadCount.Text = "Polling " + m_iCount.ToString() + " times...";
            if (adamCom.AnalogInput(m_iAddr).GetValues(1, out fVal, out status)) // read AI value
            {
                if (status[0] == Adam4000_ChannelStatus.Normal) // the value is normal
                    txtAI.Text = fVal[0].ToString() + " " + AnalogInput.GetUnitName(m_Adam4000Type, m_adamConfig.TypeCode);
                else	// the value is invalid
                    txtAI.Text = status[0].ToString();
            }
            else
            {
                txtAI.Text = "Failed to get!";
            }
            // for ADAM-4011, ADAM-4011D, or ADAM-4012
            if (m_Adam4000Type != Adam4000Type.Adam4013)
            {
                // event counter
                if (adamCom.Counter(m_iAddr).GetValue(out lVal))
                    txtCounter.Text = lVal.ToString();
                else
                    txtCounter.Text = "Failed to get!";
                // event status
                if (adamCom.DigitalInput(m_iAddr).GetValue(out bDI))
                    txtEvent.Text = bDI.ToString();
                else
                    txtEvent.Text = "Failed to get!";
                // alarm
                if (adamCom.Alarm(m_iAddr).GetModeAlarmDO(2, out mode, out DOStatus))
                {
                    m_DOStatus[0] = DOStatus[0];
                    m_DOStatus[1] = DOStatus[1];
                    txtLowAlarm.Text = DOStatus[0].ToString();
                    txtHighAlarm.Text = DOStatus[1].ToString();
                }
                else
                {
                    txtLowAlarm.Text = "Failed to get!";
                    txtHighAlarm.Text = "Failed to get!";
                }
            }
        }

        private void buttonDO0_Click(object sender, EventArgs e)
        {
            bool[] DOStatus = new bool[2];
            if (m_bStart) // was started
            {
                timer1.Enabled = false; // disable timer for polling before sending command
                if (m_DOStatus[0]) // was true, now set to false
                    DOStatus[0] = false;
                else
                    DOStatus[0] = true;
                DOStatus[1] = m_DOStatus[1];
                if (!adamCom.Alarm(m_iAddr).SetAlarmDO(DOStatus))
                    MessageBox.Show("Set DO failed!", "Error");
                timer1.Enabled = true;
            }
        }

        private void buttonDO1_Click(object sender, EventArgs e)
        {
            bool[] DOStatus = new bool[2];
            if (m_bStart) // was started
            {
                timer1.Enabled = false; // disable timer for polling before sending command
                DOStatus[0] = m_DOStatus[0];
                if (m_DOStatus[1]) // was true, now set to false
                    DOStatus[1] = false;
                else
                    DOStatus[1] = true;
                if (!adamCom.Alarm(m_iAddr).SetAlarmDO(DOStatus))
                    MessageBox.Show("Set DO failed!", "Error");
                timer1.Enabled = true;
            }		
        }


    }
}