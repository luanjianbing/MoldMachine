using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Advantech.Adam;
using Advantech.Common;

namespace Adam4080D
{
    public partial class Form1 : Form
    {
        private int m_iCom, m_iAddr, m_iCount, m_iChTotal;
        private bool m_bStart;
        private Adam4000Config m_adamConfig;
        private Adam4000Type m_Adam4000Type;
        private AdamCom adamCom;

        public Form1()
        {
            InitializeComponent();

            int iIdx;
            m_iCom = 4;		// using COM4
            m_iAddr = 1;	// the slave address is 1
            m_iCount = 0;	// the counting start from 0
            m_bStart = false;
            m_Adam4000Type = Adam4000Type.Adam4080D; // the sample is for ADAM-4080D

            m_iChTotal = Counter.GetChannelTotal(m_Adam4000Type);
            for (iIdx = 0; iIdx < m_iChTotal; iIdx++)
                cbxChannel.Items.Add(iIdx.ToString());
            adamCom = new AdamCom(m_iCom);
            adamCom.Checksum = false; // disbale checksum

            txtModule.Text = m_Adam4000Type.ToString();
            // LED source
            cbxLedSource.Items.Add("Channel 0");
            cbxLedSource.Items.Add("Channel 1");
            cbxLedSource.Items.Add("External input");
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
                panelLED.Enabled = false;
                panelCount.Enabled = false;
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
                    // LED panel
                    panelLED.Enabled = true;
                    RefreshLEDSource();
                    // Counter panel
                    if (m_adamConfig.TypeCode == (byte)Adam4080_CounterMode.Counter)
                    {
                        panelCount.Enabled = true;
                        cbxChannel.SelectedIndex = 0;
                        RefreshAlarmButton();
                    }
                    else
                        panelCount.Enabled = false;
                    timer1.Enabled = true; // enable timer
                    buttonStart.Text = "Stop";
                    m_bStart = true; // starting flag
                }
                else
                    MessageBox.Show("Failed to open COM port!", "Error");
            }
        }

        private void RefreshCurrentValue(int i_iChannel, ref TextBox i_txtCh)
        {
            long lVal;
            if (adamCom.Counter(m_iAddr).GetValue(i_iChannel, out lVal))
                i_txtCh.Text = lVal.ToString() + " " + Counter.GetUnitName(m_Adam4000Type, m_adamConfig.TypeCode);
            else
                i_txtCh.Text = "Fail";
        }

        private void RefreshAlarmButton()
        {
            bool[] bDO;
            Adam4000_CounterAlarmMode byMode;

            if (adamCom.Alarm(m_iAddr).GetModeAlarmDO(out byMode, out bDO))
            {
                if (byMode == Adam4000_CounterAlarmMode.Disable)
                {
                    btnLowAlarm.Text = "DO-0";
                    btnHighAlarm.Text = "DO-1";
                    btnHighAlarm.Enabled = true;
                    btnLowAlarm.Enabled = true;
                    btnClearLatch.Enabled = false;
                }
                else if (byMode == Adam4000_CounterAlarmMode.Latch)
                {
                    btnLowAlarm.Text = "Low alarm";
                    btnHighAlarm.Text = "High alarm";
                    btnHighAlarm.Enabled = false;
                    btnLowAlarm.Enabled = false;
                    btnClearLatch.Enabled = true;
                }
                else if (byMode == Adam4000_CounterAlarmMode.Momentary)
                {
                    btnLowAlarm.Text = "Low alarm";
                    btnHighAlarm.Text = "High alarm";
                    btnHighAlarm.Enabled = false;
                    btnLowAlarm.Enabled = false;
                    btnClearLatch.Enabled = false;
                }
            }
            else
                MessageBox.Show("GetModeAlarmDO() failed");
        }

        private void RefreshStatus()
        {
            bool bCount, bOver;
            int iChannel;

            iChannel = cbxChannel.SelectedIndex;
            if (adamCom.Counter(m_iAddr).GetStatus(iChannel, out bCount))
                txtCounting.Text = bCount.ToString();
            else
                txtCounting.Text = "Fail";
            if (adamCom.Counter(m_iAddr).GetOverflowFlag(iChannel, out bOver))
                txtOverflow.Text = bOver.ToString();
            else
                txtOverflow.Text = "Fail";
        }

        private void RefreshLEDSource()
        {
            byte bySource;

            if (adamCom.Counter(m_iAddr).GetLEDSource(out bySource))
            {
                cbxLedSource.SelectedIndex = bySource;
                if (bySource == 2) // host
                    panelLEDOutput.Visible = true;
                else
                    panelLEDOutput.Visible = false;
            }
            else
                MessageBox.Show("GetLEDSource() failed");
        }

        private void RefreshAlarm()
        {
            bool[] bAlarm, bDO;
            int iChannel;

            iChannel = cbxChannel.SelectedIndex;
            if (iChannel == 0)
            {
                if (adamCom.Alarm(m_iAddr).GetEnableAlarmDO(out bAlarm, out bDO))
                {
                    txtLowAlarm.Text = bDO[0].ToString();
                    txtHighAlarm.Text = bDO[1].ToString();
                }
                else
                {
                    txtLowAlarm.Text = "Fail";
                    txtHighAlarm.Text = "Fail";
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            m_iCount++;
            txtReadCount.Text = "Polling " + m_iCount.ToString() + " times...";
            RefreshCurrentValue(0, ref txtCounter0);
            RefreshCurrentValue(1, ref txtCounter1);
            if (m_adamConfig.TypeCode == (byte)Adam4080_CounterMode.Counter)
            {
                RefreshStatus();
                RefreshAlarm();
            }
        }

        private void cbxChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            int iCh;

            timer1.Enabled = false;
            iCh = cbxChannel.SelectedIndex;
            if (m_adamConfig.TypeCode == (byte)Adam4080_CounterMode.Counter)
            {
                if (iCh == 0)
                {
                    panelAlarm.Visible = true;
                    RefreshAlarmButton();
                }
                else
                    panelAlarm.Visible = false;
            }
            timer1.Enabled = true;
        }

        private void btnLowAlarm_Click(object sender, EventArgs e)
        {
            bool[] bDO = new bool[2];

            timer1.Enabled = false;
            if (txtLowAlarm.Text == "True")
                bDO[0] = false;
            else
                bDO[0] = true;
            bDO[1] = (txtHighAlarm.Text == "True");
            if (!adamCom.Alarm(m_iAddr).SetAlarmDO(bDO))
                MessageBox.Show("Set DO output failed!", "Error");
            timer1.Enabled = true;
        }

        private void btnHighAlarm_Click(object sender, EventArgs e)
        {
            bool[] bDO = new bool[2];

            timer1.Enabled = false;
            bDO[0] = (txtLowAlarm.Text == "True");
            if (txtHighAlarm.Text == "True")	// was true
                bDO[1] = false;
            else
                bDO[1] = true;
            if (!adamCom.Alarm(m_iAddr).SetAlarmDO(bDO))
                MessageBox.Show("Set DO output failed!", "Error");
            timer1.Enabled = true;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            int iChannel;
            timer1.Enabled = false;
            iChannel = cbxChannel.SelectedIndex;
            if (adamCom.Counter(m_iAddr).SetStatus(iChannel, true))
                System.Threading.Thread.Sleep(500);
            else
                MessageBox.Show("Start counter failed!", "Error");
            timer1.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            int iChannel;
            timer1.Enabled = false;
            iChannel = cbxChannel.SelectedIndex;
            if (adamCom.Counter(m_iAddr).SetStatus(iChannel, false))
                System.Threading.Thread.Sleep(500);
            else
                MessageBox.Show("Stop counter failed!", "Error");
            timer1.Enabled = true;
        }

        private void btnClearCounter_Click(object sender, EventArgs e)
        {
            int iChannel;
            timer1.Enabled = false;
            iChannel = cbxChannel.SelectedIndex;
            if (adamCom.Counter(m_iAddr).SetClear(iChannel))
                System.Threading.Thread.Sleep(500);
            else
                MessageBox.Show("Clear counter failed!", "Error");
            timer1.Enabled = true;
        }

        private void btnClearLatch_Click(object sender, EventArgs e)
        {
            int iChannel;
            timer1.Enabled = false;
            iChannel = cbxChannel.SelectedIndex;
            if (adamCom.Alarm(m_iAddr).SetLatchClear())
                System.Threading.Thread.Sleep(500);
            else
                MessageBox.Show("Clear latch alarm failed!", "Error");
            timer1.Enabled = true;
        }

        private void btnApplyLED_Click(object sender, EventArgs e)
        {
            if (adamCom.Counter(m_iAddr).SetLEDSource((byte)cbxLedSource.SelectedIndex))
            {
                System.Threading.Thread.Sleep(500);
                MessageBox.Show("Change LED source done!", "Information");
                RefreshLEDSource();
            }
            else
                MessageBox.Show("Change LED source failed!", "Error");
        }

        private void btnLED_Click(object sender, EventArgs e)
        {
            if (txtLED.Text.Length != 6)
            {
                MessageBox.Show("The text length must be 6!", "Error");
                return;
            }
            timer1.Enabled = false;
            if (adamCom.Counter(m_iAddr).SetLEDText(txtLED.Text))
                MessageBox.Show("Set LED text done!", "Information");
            else
                MessageBox.Show("Set LED text failed!", "Error");
            timer1.Enabled = true;
        }
    }
}