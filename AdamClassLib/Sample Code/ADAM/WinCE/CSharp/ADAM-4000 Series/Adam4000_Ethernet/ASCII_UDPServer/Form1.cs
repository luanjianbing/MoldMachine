using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using Advantech.Adam;
using Advantech.Common;

namespace ASCII_UDPServer
{
    public partial class Form1 : Form
    {
        private UDPSocketServer m_SvrSocket;
        private SocketStream m_SvrStream;
        private AdamCom m_com;
        private int m_ListenPort, m_UDPSendTimeout, m_UDPRecvTimeout, m_SerialTimeout;
        private int m_UDPRecv, m_UDPSent, m_SerialSent, m_SerialRecv;
        private byte[] m_byUDPRecv;


        public Form1()
        {
            InitializeComponent();

            string hostName;
            IPHostEntry hostInfo;
            IPAddress[] address;
            int iCnt;

            m_ListenPort = 1025;
            m_UDPSendTimeout = 100;
            m_UDPRecvTimeout = 100;
            m_SerialTimeout = 500;
            m_byUDPRecv = new byte[1024];
            //
            try
            {
                hostName = Dns.GetHostName();
                hostInfo = Dns.Resolve(hostName);
                address = hostInfo.AddressList;
                for (iCnt = 0; iCnt < address.Length; iCnt++)
                    textBoxLocal.Text += address[iCnt].ToString() + "; ";
            }
            catch
            {
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            Socket svrSocket;
            if (buttonStart.Text == "Start")
            {
                m_com = new AdamCom(2);
                m_com.Checksum = false; // set the checksum disbale, if the checksum must be applied, set it to true
                m_com.SetComPortState(Baudrate.Baud_9600, Databits.Eight, Parity.None, Stopbits.One); // 9600, N, 8, 1
                m_com.SetComPortTimeout(m_SerialTimeout, m_SerialTimeout, 0, m_SerialTimeout, 0);
                if (!m_com.OpenComPort())
                {
                    MessageBox.Show("Failed to open COM!", "Error");
                    return;
                }
                m_SvrSocket = new UDPSocketServer();
                m_SvrSocket.Create(m_ListenPort);
                svrSocket = m_SvrSocket.ServerSocket();
                m_SvrStream = new SocketStream(ref svrSocket, m_UDPSendTimeout, m_UDPRecvTimeout);
                buttonStart.Text = "Stop";
                m_UDPRecv = 0;
                m_UDPSent = 0;
                m_SerialSent = 0;
                m_SerialRecv = 0;
                textBoxUDPRecv.Text = m_UDPRecv.ToString();
                textBoxUDPSent.Text = m_UDPSent.ToString();
                textBoxSerialSent.Text = m_SerialSent.ToString();
                textBoxSerialRecv.Text = m_SerialRecv.ToString();
                timer1.Enabled = true;
            }
            else
            {
                timer1.Enabled = false;
                m_SvrSocket.Terminate();
                m_com.CloseComPort();
                buttonStart.Text = "Start";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            EndPoint remoteEP;
            int iUDPRecv, iUDPSend;
            byte[] byUDPSend;
            string szUDPRecv, szComRecv;

            timer1.Enabled = false;

            if (m_SvrStream.DataArrive(10))
            {
                if (m_SvrStream.RecvUDP(out remoteEP, m_byUDPRecv, out iUDPRecv))
                {
                    m_UDPRecv++;
                    textBoxUDPRecv.Text = m_UDPRecv.ToString();
                    szUDPRecv = Encoding.ASCII.GetString(m_byUDPRecv, 0, iUDPRecv);
                    // pass command to COM port
                    m_SerialSent++;
                    textBoxSerialSent.Text = m_SerialSent.ToString();
                    if (m_com.AdamTransaction(szUDPRecv, out szComRecv))
                    {
                        m_SerialRecv++;
                        textBoxSerialRecv.Text = m_SerialSent.ToString();
                        byUDPSend = Encoding.ASCII.GetBytes(szComRecv);
                        iUDPSend = byUDPSend.Length;
                        if (m_SvrStream.SendUDP(ref remoteEP, byUDPSend, iUDPSend))
                        {
                            m_UDPSent++;
                            textBoxUDPSent.Text = m_UDPSent.ToString();
                        }
                    }
                }
            }
            timer1.Enabled = true;
        }
    }
}