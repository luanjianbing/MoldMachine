using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Advantech.Adam;
using Advantech.Common;

namespace Adam4016
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
            m_iAddr = 1;	// the slave address is 1
            m_iCount = 0;	// the counting start from 0
            m_DOStatus = new bool[4];
            m_bStart = false;
            m_Adam4000Type = Adam4000Type.Adam4016; // the sample is for ADAM-4016
            adamCom = new AdamCom(m_iCom);
            adamCom.Checksum = false; // disbale checksum

            txtModule.Text = m_Adam4000Type.ToString();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
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
                panelAO.Enabled = false;
                panelAlarm.Enabled = false;
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
                    //
                    panelAO.Enabled = true;
                    panelAlarm.Enabled = true;
                    timer1.Enabled = true; // enable timer
                    buttonStart.Text = "Stop";
                    m_bStart = true; // starting flag
                }
                else
                    MessageBox.Show("Failed to open COM port!", "Error");
            }
        }

        private void RefreshAIValue()
        {
            float[] fVals;
            int[] iVals;
            Adam4000_ChannelStatus[] status;

            if (m_adamConfig.Format == Adam4000_DataFormat.TwosComplementHex)
            {
                if (adamCom.AnalogInput(m_iAddr).GetValues(1, out iVals))
                    txtAIValue.Text = "0x" + iVals[0].ToString("X04");
                else
                    txtAIValue.Text = "GetValues() failed;";
            }
            else
            {
                if (adamCom.AnalogInput(m_iAddr).GetValues(1, out fVals, out status))
                {
                    if (status[0] == Adam4000_ChannelStatus.Normal)
                    {
                        if (m_adamConfig.Format == Adam4000_DataFormat.EngineerUnit)
                            txtAIValue.Text = fVals[0].ToString(AnalogInput.GetFloatFormat(m_Adam4000Type, m_adamConfig.TypeCode)) + " " + AnalogInput.GetUnitName(m_Adam4000Type, m_adamConfig.TypeCode);
                        else if (m_adamConfig.Format == Adam4000_DataFormat.Percent)
                            txtAIValue.Text = fVals[0].ToString("#0.00") + " %";
                        else if (m_adamConfig.Format == Adam4000_DataFormat.Ohms)
                            txtAIValue.Text = fVals[0].ToString("#0.000") + " ohms";
                    }
                    else
                        txtAIValue.Text = status[0].ToString();
                }
                else
                    txtAIValue.Text = "GetValues() failed;";
            }
        }

        private void RefreshAOValue()
        {
            float fValue;

            if (adamCom.AnalogOutput(m_iAddr).GetExcitationValue(out fValue))
                txtAOValue.Text = fValue.ToString("#0.000") + " V";
            else
                txtAOValue.Text = "GetExcitationValue() failed;";
        }

        private void RefreshDO()
        {
            Adam_AIAlarmMode mode;
            bool[] DOStatus;

            if (adamCom.Alarm(m_iAddr).GetModeAlarmDO(4, out mode, out DOStatus))
            {
                m_DOStatus[0] = DOStatus[0];
                m_DOStatus[1] = DOStatus[1];
                m_DOStatus[2] = DOStatus[2];
                m_DOStatus[3] = DOStatus[3];
                txtLowAlarm.Text = DOStatus[0].ToString();
                txtHighAlarm.Text = DOStatus[1].ToString();
                txtDO2.Text = DOStatus[2].ToString();
                txtDO3.Text = DOStatus[3].ToString();
            }
            else
            {
                txtLowAlarm.Text = "GetModeAlarmDO() failed";
                txtHighAlarm.Text = "GetModeAlarmDO() failed";
                txtDO2.Text = "GetModeAlarmDO() failed";
                txtDO3.Text = "GetModeAlarmDO() failed";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            m_iCount++;
            txtReadCount.Text = "Polling " + m_iCount.ToString() + " times...";
            RefreshAIValue();
            RefreshAOValue();
            RefreshDO();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            float fValue;

            timer1.Enabled = false;
            fValue = Convert.ToSingle(trackBar1.Value);
            fValue = fValue * 10 / trackBar1.Maximum;
            txtOutputValue.Text = fValue.ToString("0.000");
            if (m_bStart) // was started
                timer1.Enabled = true;
        }

        private void btnApplyOutput_Click(object sender, EventArgs e)
        {
            float fValue;

            timer1.Enabled = false;
            fValue = Convert.ToSingle(txtOutputValue.Text);
            if (adamCom.AnalogOutput(m_iAddr).SetExcitationValue(fValue))
                System.Threading.Thread.Sleep(500);
            else
                MessageBox.Show("Change current value failed!", "Error");
            timer1.Enabled = true;
        }

        private void buttonDO0_Click(object sender, EventArgs e)
        {
            bool[] DOStatus = new bool[2];

            timer1.Enabled = false;
            if (m_DOStatus[0]) // was ON
                DOStatus[0] = false;
            else
                DOStatus[0] = true;
            DOStatus[1] = m_DOStatus[1];
            if (!adamCom.Alarm(m_iAddr).SetAlarmDO(DOStatus))
                MessageBox.Show("Set DO failed!", "Error");
            timer1.Enabled = true;
        }

        private void buttonDO1_Click(object sender, EventArgs e)
        {
            bool[] DOStatus = new bool[2];

            timer1.Enabled = false;
            DOStatus[0] = m_DOStatus[0];
            if (m_DOStatus[1]) // was ON
                DOStatus[1] = false;
            else
                DOStatus[1] = true;
            if (!adamCom.Alarm(m_iAddr).SetAlarmDO(DOStatus))
                MessageBox.Show("Set DO failed!", "Error");
            timer1.Enabled = true;
        }

        private void buttonDO2_Click(object sender, EventArgs e)
        {
            bool[] DOStatus = new bool[2];

            timer1.Enabled = false;
            if (m_DOStatus[2]) // was ON
                DOStatus[0] = false;
            else
                DOStatus[0] = true;
            DOStatus[1] = m_DOStatus[3];
            if (!adamCom.Alarm(m_iAddr).SetExtDO(DOStatus))
                MessageBox.Show("Set DO failed!", "Error");
            timer1.Enabled = true;
        }

        private void buttonDO3_Click(object sender, EventArgs e)
        {
            bool[] DOStatus = new bool[2];

            timer1.Enabled = false;
            DOStatus[0] = m_DOStatus[2];
            if (m_DOStatus[3]) // was ON
                DOStatus[1] = false;
            else
                DOStatus[1] = true;
            if (!adamCom.Alarm(m_iAddr).SetExtDO(DOStatus))
                MessageBox.Show("Set DO failed!", "Error");
            timer1.Enabled = true;
        }

    }
}
