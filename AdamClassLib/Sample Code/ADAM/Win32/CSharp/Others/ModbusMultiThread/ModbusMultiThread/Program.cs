using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using Advantech.Adam;
using Advantech.Protocol;

namespace AdvModbusMultiThread
{
    class AdvModbusMultiThread
    {
        private string m_szIP = "172.18.3.246"; // Target device IP
        private int m_iPort = 502;              // Target device port
        private int m_iSleep = 500;             // Interval of modbus request
        private int m_iMaxRetryCount = 5;       // Maximum retry count when connection fail
        private int m_iStart = 1;				// Modbus starting address
        private int m_iLength = 8;				// Modbus reading length
        private bool m_bRegister = true;		// Set to true to read the register, otherwise, read the coil
        public bool m_running = false;          
 

        void ConnectTarget()
        {
            int[] iData;
            bool[] bData;
            int retryConnCnt = 0;
            int retryCnt = 0;
            string szThreadName = System.Threading.Thread.CurrentThread.Name;

            AdamSocket adamTCP = new AdamSocket();
            adamTCP.SetTimeout(1000, 1000, 1000);

            while (m_running)
            {
                if (adamTCP.Connected != true)
                {
                    adamTCP.Disconnect();   //Disconnect previous connection

                    Console.WriteLine("[{0}] Connect to " + m_szIP.ToString() + "...", szThreadName);
                    if (!adamTCP.Connect(m_szIP, ProtocolType.Tcp, m_iPort))
                    {
                        retryConnCnt++;
                        Console.WriteLine("[{0}] Connect fail! Wait for 5s to retry. Retry count = " + retryConnCnt.ToString(), szThreadName);
                        System.Threading.Thread.Sleep(5000);
                        continue;
                    }
                }

                if (m_bRegister) // Read registers (4X references)
                {
                    if (adamTCP.Modbus().ReadHoldingRegs(m_iStart, m_iLength, out iData))
                    {
                        string temp = "";
                        for (int idx = 0; idx < m_iLength; idx++)
                        {
                            temp += " " + iData[idx].ToString("X");
                        }
                        Console.WriteLine("[{0}] Read registers: " + temp, szThreadName);
                        retryCnt = 0;
                    }
                    else
                    {
                        retryCnt++;
                        Console.WriteLine("[{0}] Read registers failed! count = " + retryCnt.ToString(), szThreadName);
                    }
                }
                else
                {

                    if (adamTCP.Modbus().ReadCoilStatus(m_iStart, m_iLength, out bData))
                    {
                        string temp = "";
                        for (int idx = 0; idx < m_iLength; idx++)
                        {
                            temp = temp + " " + bData[idx].ToString();
                        }
                        Console.WriteLine("[{0}] Read coil: " + temp, szThreadName);
                        retryCnt = 0;
                    }
                    else
                    {
                        retryCnt++;
                        Console.WriteLine("[{0}] Read coil failed! count = " + retryCnt.ToString(), szThreadName);
                    }

                }

                //check retry count
                if(retryCnt >= m_iMaxRetryCount)
                    adamTCP.Disconnect();

                System.Threading.Thread.Sleep(m_iSleep);
            }
            adamTCP.Disconnect();
            Console.WriteLine("[{0}] Disconnect.", szThreadName);
        }


        static void Main(string[] args)
        {
            ConsoleKeyInfo cki;

            AdvModbusMultiThread mThread = new AdvModbusMultiThread();

            System.Threading.Thread t1 = new System.Threading.Thread(new System.Threading.ThreadStart(mThread.ConnectTarget));
            System.Threading.Thread t2 = new System.Threading.Thread(new System.Threading.ThreadStart(mThread.ConnectTarget));

            t1.Name = "T1";
            t2.Name = "T2";

            mThread.m_running = true;  

            t1.Start();
            t2.Start();
            

            Console.WriteLine("Press the Escape (Esc) key to quit...");
            
            do
            {
                cki = Console.ReadKey(true);
            } while (cki.Key != ConsoleKey.Escape);

            mThread.m_running = false;

            t1.Join();
            Console.WriteLine("t1 stop");

            t2.Join();
            Console.WriteLine("t2 stop");

            Console.ReadKey(true);
        }
    }
}
