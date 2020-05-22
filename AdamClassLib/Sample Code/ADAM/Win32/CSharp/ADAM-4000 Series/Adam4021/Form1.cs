using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Advantech.Adam;
using Advantech.Common;

namespace Adam4021
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
            m_Adam4000Type = Adam4000Type.Adam4021; // the sample is for ADAM-4021
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
                    panelAO.Enabled = true;
                    RefreshTrackbar();
                    timer1.Enabled = true; // enable timer
                    buttonStart.Text = "Stop";
                    m_bStart = true; // starting flag
                }
                else
                    MessageBox.Show("Failed to open COM port!", "Error");
            }
        }

        private void RefreshTrackbar()
        {
            if (m_adamConfig.Format == Adam4000_DataFormat.EngineerUnit)
            {
                if (m_adamConfig.TypeCode == (byte)Adam4021_OutputRange.mA_0To20)
                {
                    lblLow.Text = "0 mA";
                    lblHigh.Text = "20 mA";
                    txtOutputValue.Text = "0";
                }
                else if (m_adamConfig.TypeCode == (byte)Adam4021_OutputRange.mA_4To20)
                {
                    lblLow.Text = "4 mA";
                    lblHigh.Text = "20 mA";
                    txtOutputValue.Text = "4";
                }
                else
                {
                    lblLow.Text = "0 V";
                    lblHigh.Text = "10 V";
                    txtOutputValue.Text = "0";
                }
            }
            else if (m_adamConfig.Format == Adam4000_DataFormat.Percent)
            {
                lblLow.Text = "0 %";
                lblHigh.Text = "100 %";
                txtOutputValue.Text = "0";
            }
            else
            {
                lblLow.Text = "0x000";
                lblHigh.Text = "0xFFF";
                txtOutputValue.Text = "0x000";
            }
        }

        private void RefreshAOValue()
        {
            float fValue;
            int iValue;

            if (adamCom.AnalogOutput(m_iAddr).GetCurrentValue((byte)m_adamConfig.Format, out fValue))
            {
                if (m_adamConfig.Format == Adam4000_DataFormat.EngineerUnit)
                    txtAOValue.Text = fValue.ToString("#0.000") + " " + AnalogOutput.GetUnitName(m_Adam4000Type, m_adamConfig.TypeCode);
                else if (m_adamConfig.Format == Adam4000_DataFormat.Percent)
                    txtAOValue.Text = fValue.ToString("#0.000") + " %";
                else
                {
                    iValue = Convert.ToInt32(fValue);
                    txtAOValue.Text = "0X" + iValue.ToString("X03");
                }
            }
            else
                txtAOValue.Text = "GetCurrentValue() failed";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            m_iCount++;
            txtReadCount.Text = "Polling " + m_iCount.ToString() + " times...";
            RefreshAOValue();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            float fValue;
            int iValue;

            timer1.Enabled = false;
            if (m_adamConfig.Format == Adam4000_DataFormat.EngineerUnit)
            {
                fValue = Convert.ToSingle(trackBar1.Value);
                if (m_adamConfig.TypeCode == (byte)Adam4021_OutputRange.mA_0To20)
                    fValue = Convert.ToSingle(20.0 * trackBar1.Value / trackBar1.Maximum);
                else if (m_adamConfig.TypeCode == (byte)Adam4021_OutputRange.mA_4To20)
                    fValue = Convert.ToSingle(16.0 * trackBar1.Value / trackBar1.Maximum + 4);
                else
                    fValue = Convert.ToSingle(10.0 * trackBar1.Value / trackBar1.Maximum);
                txtOutputValue.Text = fValue.ToString("#0.000");
            }
            else if (m_adamConfig.Format == Adam4000_DataFormat.Percent)
            {
                fValue = Convert.ToSingle(100.0 * trackBar1.Value / trackBar1.Maximum);
                txtOutputValue.Text = fValue.ToString("#0.000");
            }
            else
            {
                iValue = trackBar1.Value;
                txtOutputValue.Text = "0X" + iValue.ToString("X03");
            }
            timer1.Enabled = true;
        }

        private void btnApplyOutput_Click(object sender, EventArgs e)
        {
            float fValue;
            int iValue;

            timer1.Enabled = false;
            if (m_adamConfig.Format == Adam4000_DataFormat.TwosComplementHex)
            {
                iValue = Convert.ToInt32(txtOutputValue.Text, 16);
                fValue = Convert.ToSingle(iValue);
            }
            else
                fValue = Convert.ToSingle(txtOutputValue.Text);
            if (adamCom.AnalogOutput(m_iAddr).SetCurrentValue((byte)m_adamConfig.Format, fValue))
                System.Threading.Thread.Sleep(500);
            else
                MessageBox.Show("Change AO value failed!", "Error");
            timer1.Enabled = true;
        }
    }
}
