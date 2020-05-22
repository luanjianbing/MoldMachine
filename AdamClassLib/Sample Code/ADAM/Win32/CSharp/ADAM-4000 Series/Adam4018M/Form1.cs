using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Advantech.Adam;
using Advantech.Common;

namespace Adam4018M
{
    public partial class Form1 : Form
    {
        private int m_iCom, m_iAddr, m_iCount, m_iChTotal;
        private bool m_bStart;
        private bool[] m_bCh;
        private Adam4000Config m_adamConfig;
        private Adam4000Type m_Adam4000Type;
        private AdamCom adamCom;

        public Form1()
        {
            InitializeComponent();

            m_iCom = 4;		// using COM1
            m_iAddr = 1;	// the slave address is 1
            m_iCount = 0;	// the counting start from 0
            m_bStart = false;
            m_Adam4000Type = Adam4000Type.Adam4018M; // the sample is for ADAM-4018M

            m_iChTotal = AnalogInput.GetChannelTotal(m_Adam4000Type);
            m_bCh = new bool[m_iChTotal];
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
            if (m_bStart) // was started
            {
                tabControl1.Enabled = false;
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
                    tabControl1.Enabled = true;
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
            m_iCount++;
            txtReadCount.Text = "Polling " + m_iCount.ToString() + " times...";
            if (tabControl1.SelectedIndex == 0) // data page
            {
                RefreshAIValues();
            }
            else	// memory page
            {
                RefreshMemInfo();
            }
        }

        private void RefreshChannelEnable()
        {
            bool[] bEnabled;
            int idx;

            if (adamCom.AnalogInput(m_iAddr).GetChannelEnabled(m_iChTotal, out bEnabled))
            {
                for (idx = 0; idx < m_iChTotal; idx++)
                    m_bCh[idx] = bEnabled[idx];
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

        private void RefreshAIValues()
        {
            if (!RefreshValue(0, ref txtAIValue0))
                return;
            if (!RefreshValue(1, ref txtAIValue1))
                return;
            if (!RefreshValue(2, ref txtAIValue2))
                return;
            if (!RefreshValue(3, ref txtAIValue3))
                return;
            if (!RefreshValue(4, ref txtAIValue4))
                return;
            if (!RefreshValue(5, ref txtAIValue5))
                return;
            if (!RefreshValue(6, ref txtAIValue6))
                return;
            if (!RefreshValue(7, ref txtAIValue7))
                return;
        }

        private bool RefreshValue(int i_iCh, ref TextBox i_txtCh)
        {
            float fVal;
            Adam4000_ChannelStatus status;

            if (m_bCh[i_iCh] == false) // channel disabled
            {
                i_txtCh.Text = "";
                return true;
            }
            if (adamCom.AnalogInput(m_iAddr).GetValue(i_iCh, out fVal, out status))
            {
                if (status == Adam4000_ChannelStatus.Normal)
                    i_txtCh.Text = fVal.ToString(AnalogInput.GetFloatFormat(m_Adam4000Type, m_adamConfig.TypeCode)) + " " + AnalogInput.GetUnitName(m_Adam4000Type, m_adamConfig.TypeCode);
                else
                    i_txtCh.Text = fVal.ToString();
                return true;
            }
            return false;
        }

        private void RefreshMemInfo()
        {
            bool bRecording;
            int iStdCount, iEvtCount;
            if (adamCom.AnalogInput(m_iAddr).GetMemOperation(out bRecording) &&
                adamCom.AnalogInput(m_iAddr).GetMemStandardRecordCount(out iStdCount) &&
                adamCom.AnalogInput(m_iAddr).GetMemEventRecordCount(out iEvtCount))
            {
                txtRecord.Text = bRecording.ToString();
                txtMemStandardCount.Text = iStdCount.ToString();
                txtMemEventCount.Text = iEvtCount.ToString();
            }
            else
            {
                txtRecord.Text = "Fail";
                txtMemStandardCount.Text = "Fail";
                txtMemEventCount.Text = "Fail";
            }
        }

        private void btnStartMem_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (adamCom.AnalogInput(m_iAddr).SetMemOperation(true))
                System.Threading.Thread.Sleep(500);
            else
                MessageBox.Show("Start recording failed!", "Error");
            timer1.Enabled = true;
        }

        private void btnStopMem_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (adamCom.AnalogInput(m_iAddr).SetMemOperation(false))
                System.Threading.Thread.Sleep(500);
            else
                MessageBox.Show("Stop recording failed!", "Error");
            timer1.Enabled = true;
        }

        private void btnGetMem_Click(object sender, EventArgs e)
        {
            FormMemoryRecord memRec;
            string szTitle = "ADAM-4018M memory records";

            timer1.Enabled = false;
            memRec = new FormMemoryRecord(ref adamCom, ref listView1, m_iAddr, szTitle, this.Width, this.Height);
            memRec.ShowDialog();
            memRec = null;
            timer1.Enabled = true;
        }
    }
}
