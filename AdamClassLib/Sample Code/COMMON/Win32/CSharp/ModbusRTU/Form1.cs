using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Advantech.Adam;
using Advantech.Common;

namespace ModbusRTU
{
    public partial class Form1 : Form
    {
        private int m_iCom, m_iAddr, m_iCount;
        private int m_iStart, m_iLength;
        private bool m_bRegister, m_bStart;
        private AdamCom adamCom;

        public Form1()
        {
            InitializeComponent();

            int iIdx, iPos, iStart;

            m_bStart = false;	// the action stops at the beginning
            m_bRegister = false; // set to true to read the register, otherwise, read the coil
            m_iCom = 8;			// host COM port number
            m_iAddr = 1;		// modbus slave address
            m_iStart = 1;		// modbus starting address
            m_iLength = 8;		// modbus reading length
            adamCom = new AdamCom(m_iCom);

            // fill the ListView
            if (m_bRegister) // The initial register list 
            {
                iStart = 40000 + m_iStart; // The register starting position  (4X references)
                for (iIdx = 0; iIdx < m_iLength; iIdx++)
                {
                    iPos = iStart + iIdx;
                    listViewModbusCur.Items.Add(new ListViewItem(iPos.ToString()));
                    listViewModbusCur.Items[iIdx].SubItems.Add("Word");
                    listViewModbusCur.Items[iIdx].SubItems.Add("*****");
                    listViewModbusCur.Items[iIdx].SubItems.Add("****");
                }
            }
            else	// The initial coil list
            {
                iStart = m_iStart;	// The coil starting position (0X references)
                for (iIdx = 0; iIdx < m_iLength; iIdx++)
                {
                    iPos = iStart + iIdx;
                    listViewModbusCur.Items.Add(new ListViewItem(iPos.ToString("00000")));
                    listViewModbusCur.Items[iIdx].SubItems.Add("Bit");
                    listViewModbusCur.Items[iIdx].SubItems.Add("*****");
                    listViewModbusCur.Items[iIdx].SubItems.Add("****");
                }
            }
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
                m_bStart = false;		// starting flag
                timer1.Enabled = false; // disable timer
                adamCom.CloseComPort(); // close the COM port
                buttonStart.Text = "Start";
            }
            else	// was stoped
            {
                if (adamCom.OpenComPort())
                {
                    // set COM port state
                    adamCom.SetComPortState(Baudrate.Baud_9600, Databits.Eight, Parity.None, Stopbits.One);
                    // set COM port timeout
                    adamCom.SetComPortTimeout(500, 1000, 0, 1000, 0);
                    m_iCount = 0; // reset the reading counter
                    timer1.Enabled = true; // enable timer
                    buttonStart.Text = "Stop";
                    m_bStart = true; // starting flag
                }
                else
                    MessageBox.Show("Open COM port failed", "Error");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int iIdx;
            int[] iData;
            bool[] bData;

            if (m_bRegister) // Read registers (4X references)
            {
                // read register (4X) data from slave
                if (adamCom.Modbus(m_iAddr).ReadHoldingRegs(m_iStart, m_iLength, out iData))
                {
                    m_iCount++; // increment the reading counter
                    txtStatus.Text = "Read registers " + m_iCount.ToString() + " times...";
                    // update ListView
                    for (iIdx = 0; iIdx < m_iLength; iIdx++)
                    {
                        listViewModbusCur.Items[iIdx].SubItems[2].Text = iData[iIdx].ToString();			// show value in decimal
                        listViewModbusCur.Items[iIdx].SubItems[3].Text = iData[iIdx].ToString("X04");	// show value in hexdecimal
                    }
                }
                else
                    txtStatus.Text = "Read registers failed!"; // show error message in "txtStatus"
            }
            else
            {
                // read coil (0X) data from slave
                if (adamCom.Modbus(m_iAddr).ReadCoilStatus(m_iStart, m_iLength, out bData))
                {
                    m_iCount++; // increment the reading counter
                    txtStatus.Text = "Read coil " + m_iCount.ToString() + " times...";
                    // update ListView
                    for (iIdx = 0; iIdx < m_iLength; iIdx++)
                    {
                        listViewModbusCur.Items[iIdx].SubItems[2].Text = bData[iIdx].ToString();	// show value
                    }
                }
                else
                    txtStatus.Text = "Read coil failed!"; // show error message in "txtStatus"
            }
        }
    }
}
