using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Advantech.Adam;
using System.Net.Sockets;

namespace GCL_SetAuxFlag
{
    public partial class Form1 : Form
    {
        private Advantech.Adam.AdamSocket adamUDP;
        private string m_szIP;
        private int m_iPort;
        private int m_iCount;

        public Form1()
        {
            //This call is required by the Windows Form Designer.
            InitializeComponent();

            //Those modules support Set/Get AuxFlagStatus
            //Adam6000Type.Adam6050;
            //Adam6000Type.Adam6051;
            //Adam6000Type.Adam6052;
            //Adam6000Type.Adam6055;
            //Adam6000Type.Adam6060;
            //Adam6000Type.Adam6066;
            //Adam6000Type.Adam6217;
            //Adam6000Type.Adam6224;
            //Adam6000Type.Adam6250;
            //Adam6000Type.Adam6251;
            //Adam6000Type.Adam6256;
            //Adam6000Type.Adam6260;
            //Adam6000Type.Adam6266;

            m_szIP = "10.0.0.1";	        // modbus slave IP address
            m_iPort = 1025;				// modbus UDP port is 1025
            adamUDP = new AdamSocket();
            adamUDP.SetTimeout(1000, 1000, 1000); // set timeout for UDP

            for (int i = 0; i < 16; i++)
            {
                listView1.Items.Add(i.ToString());
                listView1.Items[i].SubItems.Add("*****");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            m_iCount++; // increment the reading counter
            txtReadCount.Text = "Read status " + m_iCount.ToString() + " times...";

            RefreshAuxFlagStatus();

            timer1.Enabled = true;	
        }

        private void RefreshAuxFlagStatus()
        {
            bool[] bStatus;
            if (adamUDP.Configuration().GetGCL_AuxFlagStatus(out bStatus))
            {
                for (int i = 0; i < this.listView1.Items.Count; i++)
                {
                    if (i < bStatus.Length)
                        this.listView1.Items[i].SubItems[1].Text = bStatus[i].ToString();
                    else
                        this.listView1.Items[i].SubItems[1].Text = "*****";
                }
            }
            else
            {
                for (int i = 0; i < this.listView1.Items.Count; i++)
                {
                    this.listView1.Items[i].SubItems[1].Text = "*****";
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.timer1.Stop();
            adamUDP.Disconnect();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (this.btnStart.Text == "Start")
            {
                if (adamUDP.Connect(m_szIP, ProtocolType.Udp, m_iPort))
                {
                    this.btnStart.Text = "Stop";
                    btnSetAllTrue.Enabled = true;
                    btnSetAllFalse.Enabled = true;
                    this.timer1.Start();
                }
                else
                    MessageBox.Show("Connect to " + m_szIP + " failed", "Error");
            }
            else
            {
                this.timer1.Stop();
                btnSetAllTrue.Enabled = false;
                btnSetAllFalse.Enabled = false;
                this.btnStart.Text = "Start";
                adamUDP.Disconnect(); // disconnect slave
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if ((listView1.SelectedItems.Count > 0) && (this.btnStart.Text == "Stop"))
            {
                this.timer1.Stop();
                int iIdx = listView1.SelectedItems[0].Index;
                bool bStatus = false;
                if (listView1.SelectedItems[0].SubItems[1].Text == "True")
                    bStatus = false;
                else
                    bStatus = true;

                if (!this.adamUDP.Configuration().SetGCL_AuxFlagStatus(iIdx, bStatus))
                {
                    MessageBox.Show("Failed to Set GCL AuxFlagStatus");
                }

                this.timer1.Start();
            }
        }

        private void btnSetAllTrue_Click(object sender, EventArgs e)
        {
            bool[] bStatus = new bool[this.listView1.Items.Count];

            for (int i = 0; i < bStatus.Length; i++)
                bStatus[i] = true;

            SetAllAuxFlag(bStatus);
        }

        private void btnSetAllFalse_Click(object sender, EventArgs e)
        {
            bool[] bStatus = new bool[this.listView1.Items.Count];

            for (int i = 0; i < bStatus.Length; i++)
                bStatus[i] = false;

            SetAllAuxFlag(bStatus);
        }

        private void SetAllAuxFlag(bool[] bStatus)
        {
            this.timer1.Stop();

            if (!this.adamUDP.Configuration().SetGCL_AuxFlagStatus(bStatus))
            {
                MessageBox.Show("Failed to Set GCL AuxFlagStatus");
            }

            this.timer1.Start();
        }

    }
}
