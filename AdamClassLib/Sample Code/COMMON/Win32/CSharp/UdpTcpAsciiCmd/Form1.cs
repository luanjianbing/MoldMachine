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

namespace UdpTcpAsciiCmd
{
    public partial class Form1 : Form
    {
        const int ADAM5KUDP_PORT = 6168;
        const int ADAM6KUDP_PORT = 1025;
        const int ADAMTCP_PORT = 502;

        private AdamSocket adamSk;
        private int m_iPort;
        private ProtocolType m_protocol;

        public Form1()
        {
            InitializeComponent();

            adamSk = new AdamSocket();

            ////Adam-6000 UDP
            m_iPort = ADAM6KUDP_PORT;
            m_protocol = ProtocolType.Udp;

            ////Adam-5000 UDP
            //m_iPort = ADAM5KUDP_PORT;
            //m_protocol = ProtocolType.Udp;

            ////Adam-5000/6000 TCP
            //m_iPort = ADAMTCP_PORT;
            //m_protocol = ProtocolType.Tcp;

            this.groupBox1.Enabled = false;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (btnConnect.Text == "Connect")
            {
                if (adamSk.Connect(txtIP.Text, m_protocol, m_iPort))
                {
                    adamSk.SetTimeout(2000, 2000, 2000);
                    this.groupBox1.Enabled = true;
                    txtIP.Enabled = false;
                    btnConnect.Text = "Disconnect";
                }
                else
                    MessageBox.Show("Failed to connect module!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
            {
                adamSk.Disconnect();
                this.groupBox1.Enabled = false;
                txtIP.Enabled = true;
                btnConnect.Text = "Connect";
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (adamSk != null)
            {
                adamSk.Disconnect();
                adamSk = null;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            DateTime tTime;
            string szCommand, szRecv;
            szCommand = txtSend.Text + "\r";

            if (adamSk.AdamTransaction(szCommand, out szRecv))
            {
                txtRespond.Text = szRecv;
            }
            else
            {
                txtRespond.Text = adamSk.LastError.ToString();
            }

            tTime = DateTime.Now;
            txtTime.Text = tTime.ToString("hh:mm:ss");
        }
    }
}
