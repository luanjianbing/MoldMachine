using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Advantech.Adam;
using Advantech.Common;

namespace DataStreaming
{
    public partial class Form1 : Form
    {
        private Thread m_StreamThread;
        private UDPSocketServer udpServer;
        private SocketStream udpStream;
        private bool m_bStreamThreadStop;
        private bool m_bStreamThreadTerminate;
        private string m_szMsg;

        public Form1()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        public void listBoxMsg_ThreadUpdate(object sender, EventArgs e)
        {
            listBoxMsg.Items.Add(m_szMsg);
            listBoxMsg.SelectedIndex = listBoxMsg.Items.Count - 1;
        }

        public void AddListBoxItem(string szMsg)
        {
            m_szMsg = szMsg;
            this.listBoxMsg.Invoke(new EventHandler(listBoxMsg_ThreadUpdate));
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            string[] szIP;
            int iPort = 5168; // data streaming UDP listen port
            System.Net.Sockets.Socket sk;

            if (btnStart.Text == "Start")
            {
                try
                {
                    udpServer = new UDPSocketServer();
                    udpServer.Create(iPort);
                    sk = udpServer.ServerSocket();
                    udpStream = new SocketStream(ref sk, 2000, 2000);
                    Advantech.Adam.AdamSocket.GetLocalNetwork(out szIP);
                    btnStart.Text = "Stop";
                    AddListBoxItem("Local IP = " + szIP[0]);
                    AddListBoxItem("Start listening... ");

                    this.m_bStreamThreadStop = false;
                    this.m_bStreamThreadTerminate = false;
                    m_StreamThread = new System.Threading.Thread(new ThreadStart(this.ThreadProc));
                    m_StreamThread.Start();
                }
                catch
                {
                    if (m_StreamThread != null)
                    {
                        this.m_bStreamThreadStop = true;
                        int iCnt = 0;
                        while (!m_bStreamThreadTerminate)
                        {
                            Thread.Sleep(10);
                            ++iCnt;
                            if (iCnt > 50)
                                break;
                        }
                        m_StreamThread = null;
                    }

                    udpServer.Terminate();
                    udpServer = null;
                    udpStream = null;
                    btnStart.Text = "Start";
                    MessageBox.Show("Failed to start data streaming process!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    if (m_StreamThread != null)
                    {
                        this.m_bStreamThreadStop = true;
                        int iCnt = 0;
                        while (!m_bStreamThreadTerminate)
                        {
                            Thread.Sleep(10);
                            ++iCnt;
                            if (iCnt > 50)
                                break;
                        }
                        m_StreamThread = null;
                    }

                    udpServer.Terminate();
                    udpServer = null;
                    udpStream = null;
                    btnStart.Text = "Start";
                }
                catch (ObjectDisposedException)
                {
                }
            }

        }

        public void ThreadProc()
        {
            DataStructure data;
            System.Net.EndPoint remoteEP;
            DateTime dt = DateTime.Now;
            byte[] byData = new byte[300];
            int iLen;

            while (!m_bStreamThreadStop)
            {
                try
                {
                    Thread.Sleep(500);
                    dt = DateTime.Now;
                    if (udpStream.DataArrive(100))
                    {
                        if (udpStream.RecvUDP(out remoteEP, byData, out iLen))
                        {
                            AddListBoxItem("********** Data received from " + remoteEP.ToString() + " , At " + dt.Hour.ToString() + ":" + dt.Minute.ToString() + ":" + dt.Second.ToString() + " **********");
                            data = new DataStructure();
                            data.SetData(byData, iLen);
                            DisplayInform(data);
                            data = null;
                        }
                        else
                            AddListBoxItem("Failed to received");
                    }
                }
                catch (ObjectDisposedException)
                {
                    this.m_bStreamThreadTerminate = true;
                    break;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    this.m_bStreamThreadTerminate = true;
                    break;
                }
            }

            this.m_bStreamThreadTerminate = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            m_bStreamThreadStop = false;
            m_bStreamThreadTerminate = false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (m_StreamThread != null)
                {
                    this.m_bStreamThreadStop = true;
                    int iCnt = 0;
                    while (!m_bStreamThreadTerminate)
                    {
                        Thread.Sleep(10);
                        ++iCnt;
                        if (iCnt > 50)
                            break;
                    }
                    m_StreamThread = null;
                }

                if (udpServer != null)
                {
                    udpServer.Terminate();
                    udpServer = null;
                }

                if (udpStream != null)
                    udpStream = null;             
            }
            catch
            {
            }
        }

        private void DisplayInform(DataStructure data)
        {
            // for those who wants to listen the data streaming from ADAM-6000
            // you have to make sure the module type you are listening to.

            // for ADAM-6000 serias
            //DisplayAdam6015(data);
            //DisplayAdam6017(data);
            //DisplayAdam6018(data);
            //DisplayAdam6024(data);
            //DisplayAdam6050(data);
            //DisplayAdam6051(data);
            //DisplayAdam6052(data);
            //DisplayAdam6060(data);
            //DisplayAdam6066(data);
            //DisplayAdam6217(data);
            //DisplayAdam6224(data);
            //DisplayAdam6250(data);
            //DisplayAdam6251(data);
            //DisplayAdam6256(data);
            //DisplayAdam6260(data);
            //DisplayAdam6266(data);

            // for those who wants to listen the data streaming from ADAM-5000/TCP
            // you have to make sure the module type on each slot you are listening to.
            // For example: (ADAM-5017 on slot 0~3, and ADAM-5060 on slot 4~7)
            /*
            DisplayAdam5017(data, 0);
            DisplayAdam5017(data, 1);
            DisplayAdam5017(data, 2);
            DisplayAdam5017(data, 3);
            DisplayAdam5060(data, 4);
            DisplayAdam5060(data, 5);
            DisplayAdam5060(data, 6);
            DisplayAdam5060(data, 7);
            */

            // for ADAM-5000/TCP serias, each slot you can use           
            /*
            DisplayAdam5013(data, 0);
            DisplayAdam5017(data, 0);
            DisplayAdam5018(data, 0);
            DisplayAdam5024(data, 0);
            DisplayAdam5050(data, 0);
            DisplayAdam5051(data, 0);
            DisplayAdam5052(data, 0);
            DisplayAdam5055(data, 0);
            DisplayAdam5056(data, 0);
            DisplayAdam5060(data, 0);
            DisplayAdam5068(data, 0);
            DisplayAdam5069(data, 0);
            DisplayAdam5080(data, 0);
            DisplayAdam5081(data, 0);
            */

            DisplayAdam5024(data, 1);
        }

        private void DisplayAdam6015(DataStructure data)
        {
            int i;
            string szMsg;

            for (i = 0; i < 7; i++)
            {
                szMsg = string.Format("AI[{0}]: Data=0x{1:X04}, Max=0x{2:X04}, Min=0x{3:X04}", i, data.AIO(i), data.AIO(i + 9), data.AIO(i + 18));
                AddListBoxItem(szMsg);
            }
            szMsg = string.Format("Ave=0x{0:X04}", data.AIO(8));
            AddListBoxItem(szMsg);
        }

        private void DisplayAdam6017(DataStructure data)
        {
            int i;
            string szMsg;

            szMsg = string.Format("DO=0x{0:X04}", data.DIO(1));
            AddListBoxItem(szMsg);
            for (i = 0; i < 8; i++)
            {
                szMsg = string.Format("AI[{0}]: Data=0x{1:X04}, Max=0x{2:X04}, Min=0x{3:X04}", i, data.AIO(i), data.AIO(i + 9), data.AIO(i + 18));
                AddListBoxItem(szMsg);
            }
            szMsg = string.Format("Ave=0x{0:X04}", data.AIO(8));
            AddListBoxItem(szMsg);
        }

        private void DisplayAdam6018(DataStructure data)
        {
            DisplayAdam6017(data);
        }

        private void DisplayAdam6024(DataStructure data)
        {
            int i;
            string szMsg;

            szMsg = string.Format("DI=0x{0:X04}", data.DIO(0));
            AddListBoxItem(szMsg);
            szMsg = string.Format("DO=0x{0:X04}", data.DIO(1));
            AddListBoxItem(szMsg);
            for (i = 0; i < 6; i++)
            {
                szMsg = string.Format("AI[{0}]: Data=0x{1:X04}", i, data.AIO(i));
                AddListBoxItem(szMsg);
            }
            for (i = 0; i < 2; i++)
            {
                szMsg = string.Format("AO[{0}]: Data=0x{1:X04}", i, data.AIO(i + 10));
                AddListBoxItem(szMsg);
            }
        }

        private void DisplayAdam6050(DataStructure data)
        {
            int i;
            string szMsg;
            UInt32 uVal;

            szMsg = string.Format("DI=0x{0:X04}", data.DIO(0));
            AddListBoxItem(szMsg);
            szMsg = string.Format("DO=0x{0:X04}", data.DIO(1));
            AddListBoxItem(szMsg);

            for (i = 0; i < 12; i++)
            {
                uVal = data.AIO(i * 2 + 1);
                uVal = Convert.ToUInt32(uVal * 65536 + data.AIO(i * 2));
                szMsg = string.Format("Counter[{0}]: Data={1}", i, uVal);
                AddListBoxItem(szMsg);
            }
        }

        private void DisplayAdam6051(DataStructure data)
        {
            int i;
            string szMsg;
            UInt32 uVal;

            szMsg = string.Format("DI=0x{0:X04}", data.DIO(0));
            AddListBoxItem(szMsg);
            szMsg = string.Format("DO=0x{0:X04}", data.DIO(1));
            AddListBoxItem(szMsg);
            for (i = 0; i < 14; i++)
            {
                uVal = data.AIO(i * 2 + 1);
                uVal = Convert.ToUInt32(uVal * 65536 + data.AIO(i * 2));
                szMsg = string.Format("Counter[{0}]: Data={1}", i, uVal);
                AddListBoxItem(szMsg);
            }
        }

        private void DisplayAdam6052(DataStructure data)
        {
            int i;
            string szMsg;
            UInt32 uVal;

            szMsg = string.Format("DI=0x{0:X04}", data.DIO(0));
            AddListBoxItem(szMsg);
            szMsg = string.Format("DO=0x{0:X04}", data.DIO(1));
            AddListBoxItem(szMsg);
            for (i = 0; i < 8; i++)
            {
                uVal = data.AIO(i * 2 + 1);
                uVal = Convert.ToUInt32(uVal * 65536 + data.AIO(i * 2));
                szMsg = string.Format("Counter[{0}]: Data={1}", i, uVal);
                AddListBoxItem(szMsg);
            }
        }

        private void DisplayAdam6060(DataStructure data)
        {
            int i;
            string szMsg;
            UInt32 uVal;

            szMsg = string.Format("DI=0x{0:X04}", data.DIO(0));
            AddListBoxItem(szMsg);
            szMsg = string.Format("DO=0x{0:X04}", data.DIO(1));
            AddListBoxItem(szMsg);
            for (i = 0; i < 6; i++)
            {
                uVal = data.AIO(i * 2 + 1);
                uVal = Convert.ToUInt32(uVal * 65536 + data.AIO(i * 2));
                szMsg = string.Format("Counter[{0}]: Data={1}", i, uVal);
                AddListBoxItem(szMsg);
            }
        }

        private void DisplayAdam6066(DataStructure data)
        {
            DisplayAdam6060(data);
        }

        private void DisplayAdam6217(DataStructure data)
        {
            DisplayAdam6017(data);
        }

        private void DisplayAdam6224(DataStructure data)
        {
            int i;
            string szMsg;

            for (i = 0; i < 4; i++)
            {
                szMsg = string.Format("AO[{0}]: Data=0x{1:X04}", i, data.AIO(i));
                AddListBoxItem(szMsg);
            }
        }

        private void DisplayAdam6250(DataStructure data)
        {
            int i;
            string szMsg;
            UInt32 uVal;

            szMsg = string.Format("DI=0x{0:X04}", data.DIO(0));
            AddListBoxItem(szMsg);
            szMsg = string.Format("DO=0x{0:X04}", data.DIO(1));
            AddListBoxItem(szMsg);

            for (i = 0; i < 8; i++)
            {
                uVal = data.AIO(i * 2 + 1);
                uVal = Convert.ToUInt32((uint)uVal * 65536 + data.AIO(i * 2));
                szMsg = string.Format("Counter[{0}]: Data={1}", i, uVal);
                AddListBoxItem(szMsg);
            }
        }

        private void DisplayAdam6251(DataStructure data)
        {
            int i;
            string szMsg;
            UInt32 uVal;

            szMsg = string.Format("DI=0x{0:X04}", data.DIO(0));
            AddListBoxItem(szMsg);
            szMsg = string.Format("DO=0x{0:X04}", data.DIO(1));
            AddListBoxItem(szMsg);
            for (i = 0; i < 16; i++)
            {
                uVal = data.AIO(i * 2 + 1);
                uVal = Convert.ToUInt32((uint)uVal * 65536 + data.AIO(i * 2));
                szMsg = string.Format("Counter[{0}]: Data={1}", i, uVal);
                AddListBoxItem(szMsg);
            }
        }

        private void DisplayAdam6256(DataStructure data)
        {
            string szMsg;

            szMsg = string.Format("DI=0x{0:X04}", data.DIO(0));
            AddListBoxItem(szMsg);
            szMsg = string.Format("DO=0x{0:X04}", data.DIO(1));
            AddListBoxItem(szMsg);
        }

        private void DisplayAdam6260(DataStructure data)
        {
            string szMsg;

            szMsg = string.Format("DI=0x{0:X04}", data.DIO(0));
            AddListBoxItem(szMsg);
            szMsg = string.Format("DO=0x{0:X04}", data.DIO(1));
            AddListBoxItem(szMsg);
        }

        private void DisplayAdam6266(DataStructure data)
        {
            int i;
            string szMsg;
            UInt32 uVal;

            szMsg = string.Format("DI=0x{0:X04}", data.DIO(0));
            AddListBoxItem(szMsg);
            szMsg = string.Format("DO=0x{0:X04}", data.DIO(1));
            AddListBoxItem(szMsg);

            for (i = 0; i < 4; i++)
            {
                uVal = data.AIO(i * 2 + 1);
                uVal = Convert.ToUInt32((uint)uVal * 65536 + data.AIO(i * 2));
                szMsg = string.Format("Counter[{0}]: Data={1}", i, uVal);
                AddListBoxItem(szMsg);
            }
        }

        private void DisplayAdam5050(DataStructure data, int iSlot)
        {
            string szMsg;
            szMsg = string.Format("Slot[{0}]", iSlot);
            AddListBoxItem(szMsg);
            szMsg = string.Format("    DIO=0x{0:X04}", data.DIO(iSlot));
            AddListBoxItem(szMsg);
        }

        private void DisplayAdam5051(DataStructure data, int iSlot)
        {
            DisplayAdam5050(data, iSlot);
        }

        private void DisplayAdam5052(DataStructure data, int iSlot)
        {
            DisplayAdam5050(data, iSlot);
        }

        private void DisplayAdam5055(DataStructure data, int iSlot)
        {
            DisplayAdam5050(data, iSlot);
        }

        private void DisplayAdam5056(DataStructure data, int iSlot)
        {
            DisplayAdam5050(data, iSlot);
        }

        private void DisplayAdam5060(DataStructure data, int iSlot)
        {
            DisplayAdam5050(data, iSlot);
        }

        private void DisplayAdam5068(DataStructure data, int iSlot)
        {
            DisplayAdam5050(data, iSlot);
        }

        private void DisplayAdam5069(DataStructure data, int iSlot)
        {
            DisplayAdam5050(data, iSlot);
        }

        private void DisplayAdam5013(DataStructure data, int iSlot)
        {
            string szMsg;

            szMsg = string.Format("Slot[{0}]", iSlot);
            AddListBoxItem(szMsg);
            szMsg = string.Format("    Ch[0]=0x{0:X04}, Ch[1]=0x{1:X04}, Ch[2]=0x{2:X04}",
                data.AIO(iSlot * 8), data.AIO(iSlot * 8 + 1), data.AIO(iSlot * 8 + 2));
            AddListBoxItem(szMsg);
        }

        private void DisplayAdam5017(DataStructure data, int iSlot)
        {
            string szMsg;

            szMsg = string.Format("Slot[{0}]", iSlot);
            AddListBoxItem(szMsg);
            szMsg = string.Format("    Ch[0]=0x{0:X04}, Ch[1]=0x{1:X04}, Ch[2]=0x{2:X04}, Ch[3]=0x{3:X04}, Ch[4]=0x{4:X04}, Ch[5]=0x{5:X04}, Ch[6]=0x{6:X04}, Ch[7]=0x{7:X04}",
                data.AIO(iSlot * 8), data.AIO(iSlot * 8 + 1), data.AIO(iSlot * 8 + 2), data.AIO(iSlot * 8 + 3),
                data.AIO(iSlot * 8 + 4), data.AIO(iSlot * 8 + 5), data.AIO(iSlot * 8 + 6), data.AIO(iSlot * 8 + 7));
            AddListBoxItem(szMsg);
        }

        private void DisplayAdam5018(DataStructure data, int iSlot)
        {
            string szMsg;

            szMsg = string.Format("Slot[{0}]", iSlot);
            AddListBoxItem(szMsg);
            szMsg = string.Format("    Ch[0]=0x{0:X04}, Ch[1]=0x{1:X04}, Ch[2]=0x{2:X04}, Ch[3]=0x{3:X04}, Ch[4]=0x{4:X04}, Ch[5]=0x{5:X04}, Ch[6]=0x{6:X04}",
                data.AIO(iSlot * 8), data.AIO(iSlot * 8 + 1), data.AIO(iSlot * 8 + 2), data.AIO(iSlot * 8 + 3),
                data.AIO(iSlot * 8 + 4), data.AIO(iSlot * 8 + 5), data.AIO(iSlot * 8 + 6));
            AddListBoxItem(szMsg);
        }

        private void DisplayAdam5024(DataStructure data, int iSlot)
        {
            string szMsg;

            szMsg = string.Format("Slot[{0}]", iSlot);
            AddListBoxItem(szMsg);
            szMsg = string.Format("    Ch[0]=0x{0:X04}, Ch[1]=0x{1:X04}, Ch[2]=0x{2:X04}, Ch[3]=0x{3:X04}",
                data.AIO(iSlot * 8), data.AIO(iSlot * 8 + 1), data.AIO(iSlot * 8 + 2), data.AIO(iSlot * 8 + 3));
            AddListBoxItem(szMsg);
        }

        private void DisplayAdam5080(DataStructure data, int iSlot)
        {
            string szMsg;
            UInt32 uVal0, uVal1, uVal2, uVal3;

            uVal0 = data.AIO(iSlot * 8 + 1);
            uVal0 = Convert.ToUInt32(uVal0 * 65536 + data.AIO(iSlot * 8));
            uVal1 = data.AIO(iSlot * 8 + 3);
            uVal1 = Convert.ToUInt32(uVal1 * 65536 + data.AIO(iSlot * 8 + 2));
            uVal2 = data.AIO(iSlot * 8 + 5);
            uVal2 = Convert.ToUInt32(uVal2 * 65536 + data.AIO(iSlot * 8 + 4));
            uVal3 = data.AIO(iSlot * 8 + 7);
            uVal3 = Convert.ToUInt32(uVal3 * 65536 + data.AIO(iSlot * 8 + 6));
            szMsg = string.Format("Slot[{0}]", iSlot);
            AddListBoxItem(szMsg);
            szMsg = string.Format("    Ch[0]={0}, Ch[1]={1}, Ch[2]={2}, Ch[3]={3}",
                uVal0, uVal1, uVal2, uVal3);
            AddListBoxItem(szMsg);
        }

        private void DisplayAdam5081(DataStructure data, int iSlot)
        {
            string szMsg;
            UInt32 uVal0, uVal1, uVal2, uVal3;

            uVal0 = data.AIO(iSlot * 8 + 1);
            uVal0 = Convert.ToUInt32((uint)uVal0 * 65536 + data.AIO(iSlot * 8));
            uVal1 = data.AIO(iSlot * 8 + 3);
            uVal1 = Convert.ToUInt32((uint)uVal1 * 65536 + data.AIO(iSlot * 8 + 2));
            uVal2 = data.AIO(iSlot * 8 + 5);
            uVal2 = Convert.ToUInt32((uint)uVal2 * 65536 + data.AIO(iSlot * 8 + 4));
            uVal3 = data.AIO(iSlot * 8 + 7);
            uVal3 = Convert.ToUInt32((uint)uVal3 * 65536 + data.AIO(iSlot * 8 + 6));

            szMsg = string.Format("Slot[{0}]", iSlot);
            AddListBoxItem(szMsg);
            szMsg = string.Format("    Ch[0]={0}, Ch[1]={1}, Ch[2]={2}, Ch[3]={3}",
                uVal0, uVal1, uVal2, uVal3);
            AddListBoxItem(szMsg);
        }
    }
}
