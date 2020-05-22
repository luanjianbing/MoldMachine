using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using Advantech.Adam;
using Advantech.Common;

namespace ModbusTCP
{
    public partial class Form1 : Form
    {
        private string m_szIP;
        private int m_iCount, m_iPort;
        private int m_iStart, m_iLength;
        private bool m_bRegister, m_bStart;
        private AdamSocket adamTCP;


        public Form1()
        {
            InitializeComponent();

            int iIdx, iPos, iStart;

            m_bStart = false;			// the action stops at the beginning
            m_bRegister = true;			// set to true to read the register, otherwise, read the coil
            m_szIP = "172.18.3.243";	// modbus slave IP address
            m_iPort = 502;				// modbus TCP port is 502
            m_iStart = 1;				// modbus starting address
            m_iLength = 8;				// modbus reading length
            adamTCP = new AdamSocket();
            adamTCP.SetTimeout(1000, 1000, 1000); // set timeout for TCP

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

        private void Form1_Closing(object sender, CancelEventArgs e)
        {
            if (m_bStart)
            {
                timer1.Enabled = false; // disable timer
                adamTCP.Disconnect();	// disconnect slave
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (m_bStart) // was started
            {
                m_bStart = false;		// starting flag
                timer1.Enabled = false; // disable timer
                adamTCP.Disconnect(); // disconnect slave
                buttonStart.Text = "Start";
            }
            else	// was stoped
            {
                if (adamTCP.Connect(m_szIP, ProtocolType.Tcp, m_iPort))
                {
                    m_iCount = 0; // reset the reading counter
                    timer1.Enabled = true; // enable timer
                    buttonStart.Text = "Stop";
                    m_bStart = true; // starting flag
                }
                else
                    MessageBox.Show("Connect to " + m_szIP + " failed", "Error");
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
                if (adamTCP.Modbus().ReadHoldingRegs(m_iStart, m_iLength, out iData))
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
                if (adamTCP.Modbus().ReadCoilStatus(m_iStart, m_iLength, out bData))
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