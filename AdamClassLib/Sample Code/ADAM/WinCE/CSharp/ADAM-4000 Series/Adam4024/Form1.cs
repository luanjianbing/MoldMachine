using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Advantech.Adam;
using Advantech.Common;

namespace Adam4024
{
    public partial class Form1 : Form
    {
        private int m_iCom, m_iAddr, m_iCount, m_iChTotal;
        private byte[] m_byRange;
        private bool m_bStart;
        private Adam4000Config m_adamConfig;
        private Adam4000Type m_Adam4000Type;
        private AdamCom adamCom;


        public Form1()
        {
            InitializeComponent();

            int iIdx;
            m_iCom = 4;		// using COM2
            m_iAddr = 1;	// the slave address is 1
            m_iCount = 0;	// the counting start from 0
            m_bStart = false;
            m_Adam4000Type = Adam4000Type.Adam4024; // the sample is for ADAM-4024

            m_iChTotal = AnalogOutput.GetChannelTotal(m_Adam4000Type);
            m_byRange = new byte[m_iChTotal];
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
                panelAO.Enabled = false;
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
                    RefreshChannelRange();
                    cbxChannel.SelectedIndex = 0;
                    //
                    panelAO.Enabled = true;
                    timer1.Enabled = true; // enable timer
                    buttonStart.Text = "Stop";
                    m_bStart = true; // starting flag
                }
                else
                    MessageBox.Show("Failed to open COM port!", "Error");
            }
        }

        private void RefreshChannelRange()
        {
            byte byRange;
            int iCh;

            for (iCh = 0; iCh < m_iChTotal; iCh++)
            {
                if (adamCom.AnalogOutput(m_iAddr).GetOutputRange(iCh, out byRange))
                    m_byRange[iCh] = byRange;
            }
        }

        private void RefreshChannelValue(int i_iChannel, ref TextBox i_txtCh)
        {
            float fValue;
            string szFormat;

            if (adamCom.AnalogOutput(m_iAddr).GetCurrentValue(i_iChannel, out fValue))
            {
                szFormat = AnalogOutput.GetFloatFormat(m_Adam4000Type, m_byRange[i_iChannel]);
                i_txtCh.Text = fValue.ToString(szFormat) + " " + AnalogOutput.GetUnitName(m_Adam4000Type, m_byRange[i_iChannel]);
            }
            else
                i_txtCh.Text = "GetCurrentValue() failed";
        }

        private void RefreshDIValue()
        {
            bool[] bValue;

            if (adamCom.DigitalInput(m_iAddr).GetValues(out bValue))
            {
                txtDI0.Text = bValue[0].ToString();
                txtDI1.Text = bValue[1].ToString();
                txtDI2.Text = bValue[2].ToString();
                txtDI3.Text = bValue[3].ToString();
            }
            else
            {
                txtDI0.Text = "GetValues() failed";
                txtDI1.Text = "GetValues() failed";
                txtDI2.Text = "GetValues() failed";
                txtDI3.Text = "GetValues() failed";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            m_iCount++;
            txtReadCount.Text = "Polling " + m_iCount.ToString() + " times...";
            RefreshChannelValue(0, ref txtAO0);
            RefreshChannelValue(1, ref txtAO1);
            RefreshChannelValue(2, ref txtAO2);
            RefreshChannelValue(3, ref txtAO3);
            RefreshDIValue();
        }

        private void cbxChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            int iCh;
            float fValue;
            Adam4024_OutputRange byRange;

            timer1.Enabled = false;
            iCh = cbxChannel.SelectedIndex;
            fValue = Convert.ToSingle(trackBar1.Value);
            byRange = (Adam4024_OutputRange)m_byRange[iCh];
            if (byRange == Adam4024_OutputRange.mA_0To20) // 0~20mA
            {
                lblLow.Text = "0 mA";
                lblHigh.Text = "20 mA";
                fValue = fValue * 20 / trackBar1.Maximum;
            }
            else if (byRange == Adam4024_OutputRange.mA_4To20) // 4~20mA
            {
                lblLow.Text = "4 mA";
                lblHigh.Text = "20 mA";
                fValue = 4.0f + fValue * 16 / trackBar1.Maximum;
            }
            else // +/- 10V
            {
                lblLow.Text = "-10 V";
                lblHigh.Text = "10 V";
                fValue = -10 + fValue * 20 / trackBar1.Maximum;
            }
            txtOutputValue.Text = fValue.ToString("#0.000");
            timer1.Enabled = true;
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            int iCh;
            float fValue;
            Adam4024_OutputRange byRange;

            timer1.Enabled = false;
            iCh = cbxChannel.SelectedIndex;
            fValue = Convert.ToSingle(trackBar1.Value);
            byRange = (Adam4024_OutputRange)m_byRange[iCh];
            if (byRange == Adam4024_OutputRange.mA_0To20) // 0~20mA
                fValue = fValue * 20 / trackBar1.Maximum;
            else if (byRange == Adam4024_OutputRange.mA_4To20) // 4~20mA
                fValue = 4.0f + fValue * 16 / trackBar1.Maximum;
            else // 0~10V
                fValue = -10 + fValue * 20 / trackBar1.Maximum;
            txtOutputValue.Text = fValue.ToString("#0.000");
            timer1.Enabled = true;
        }

        private void btnApplyOutput_Click(object sender, EventArgs e)
        {
            int iChannel;
            float fValue;

            timer1.Enabled = false;
            iChannel = cbxChannel.SelectedIndex;
            fValue = Convert.ToSingle(txtOutputValue.Text);
            if (adamCom.AnalogOutput(m_iAddr).SetCurrentValue(iChannel, fValue))
                System.Threading.Thread.Sleep(500);
            else
                MessageBox.Show("Change current value failed!", "Error");
            timer1.Enabled = true;
        }
    }
}