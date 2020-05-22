using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Advantech.Adam;
using Advantech.Common;

namespace Adam4080
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
            m_Adam4000Type = Adam4000Type.Adam4080; // the sample is for ADAM-4080

            m_iChTotal = Counter.GetChannelTotal(m_Adam4000Type);
            for (iIdx = 0; iIdx < m_iChTotal; iIdx++)
                cbxChannel.Items.Add(iIdx.ToString());
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
                    //
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
            bool[] bAlarm, bDO;
            int iChannel;

            iChannel = cbxChannel.SelectedIndex;
            if (adamCom.Alarm(m_iAddr).GetEnableAlarmDO(out bAlarm, out bDO))
            {
                if (bAlarm[iChannel]) // alarm enabled
                {
                    btnAlarm.Text = "Ch-" + iChannel.ToString() + " alarm";
                    btnAlarm.Enabled = false;
                }
                else
                {
                    btnAlarm.Text = "DO-" + iChannel.ToString();
                    btnAlarm.Enabled = true;
                }
            }
            else
                MessageBox.Show("GetEnableAlarmDO() failed", "Error");
        }

        private void RefreshStatus()
        {
            bool bCount, bOver;
            bool[] bAlarm, bDO;
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
            if (adamCom.Alarm(m_iAddr).GetEnableAlarmDO(out bAlarm, out bDO))
                txtAlarm.Text = bDO[iChannel].ToString();
            else
                txtAlarm.Text = "Fail";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            m_iCount++;
            txtReadCount.Text = "Polling " + m_iCount.ToString() + " times...";
            RefreshCurrentValue(0, ref txtCounter0);
            RefreshCurrentValue(1, ref txtCounter1);
            if (m_adamConfig.TypeCode == (byte)Adam4080_CounterMode.Counter)
                RefreshStatus();
        }

        private void cbxChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshAlarmButton();
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

        private void btnAlarm_Click(object sender, EventArgs e)
        {
            int iChannel;
            bool[] bAlarm, bDO;

            timer1.Enabled = false;
            iChannel = cbxChannel.SelectedIndex;
            if (adamCom.Alarm(m_iAddr).GetEnableAlarmDO(out bAlarm, out bDO))
            {
                if (bDO[iChannel])
                    bDO[iChannel] = false;
                else
                    bDO[iChannel] = true;
                if (!adamCom.Alarm(m_iAddr).SetAlarmDO(bDO))
                    MessageBox.Show("Set DO output failed!", "Information");
            }
            else
                MessageBox.Show("Get DO output failed!", "Information");
            timer1.Enabled = true;
        }

    }
}