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

namespace Adam50XXDIO
{
    public partial class Form1 : Form
    {
        private int m_iCom, m_iAddr, m_iSlot, m_iCount, m_iChTotal;
        private bool m_bStart, m_b5000;
        private string m_szIP;
        private Adam5000Type m_Adam5000Type;
        private AdamCom adamCom;
        private AdamSocket adamSocket;

        public Form1()
        {
            InitializeComponent();

            m_b5000 = true; // set to true for module on ADAM-5000; set to false for module on ADAM-5000/TCP
            if (m_b5000)
            {
                m_iCom = 2;		// using COM2
                adamCom = new AdamCom(m_iCom);
                adamCom.Checksum = false; // disbale checksum
            }
            else
            {
                m_szIP = "172.19.1.234";
                adamSocket = new AdamSocket();
                adamSocket.SetTimeout(1000, 1000, 1000); // set timeout
            }
            m_iAddr = 1;	// the slave address is 1
            m_iSlot = 1;	// the slot index of the module
            m_iCount = 0;	// the counting start from 0
            m_bStart = false;
            //m_Adam5000Type = Adam5000Type.Adam5050; // the sample is for ADAM-5050
            m_Adam5000Type = Adam5000Type.Adam5051; // the sample is for ADAM-5051
            //m_Adam5000Type = Adam5000Type.Adam5052; // the sample is for ADAM-5052
            //m_Adam5000Type = Adam5000Type.Adam5055; // the sample is for ADAM-5055
            //m_Adam5000Type = Adam5000Type.Adam5056; // the sample is for ADAM-5056
            //m_Adam5000Type = Adam5000Type.Adam5060; // the sample is for ADAM-5060
            //m_Adam5000Type = Adam5000Type.Adam5068; // the sample is for ADAM-5068
            //m_Adam5000Type = Adam5000Type.Adam5069; // the sample is for ADAM-5069

            m_iChTotal = DigitalInput.GetChannelTotal(m_Adam5000Type) + DigitalOutput.GetChannelTotal(m_Adam5000Type);
            txtModule.Text = m_Adam5000Type.ToString();
        }

        private void Form1_Closing(object sender, CancelEventArgs e)
        {
            if (m_bStart)
            {
                timer1.Enabled = false; // disable timer
                if (m_b5000)
                    adamCom.CloseComPort(); // close the COM port
                else
                    adamSocket.Disconnect();
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (m_bStart) // was started
            {
                panelDIO.Enabled = false;
                m_bStart = false;
                timer1.Enabled = false;
                if (m_b5000)
                    adamCom.CloseComPort();
                else
                    adamSocket.Disconnect();
                buttonStart.Text = "Start";
            }
            else
            {
                if (m_b5000)
                {
                    if (adamCom.OpenComPort())
                    {
                        // set COM port state, 9600,N,8,1
                        adamCom.SetComPortState(Baudrate.Baud_9600, Databits.Eight, Parity.None, Stopbits.One);
                        // set COM port timeout
                        adamCom.SetComPortTimeout(500, 500, 0, 500, 0);
                        m_iCount = 0; // reset the reading counter
                        //
                        if (RefreshForm())
                        {
                            panelDIO.Enabled = true;
                            timer1.Enabled = true; // enable timer
                            buttonStart.Text = "Stop";
                            m_bStart = true; // starting flag
                        }
                        else
                            adamCom.CloseComPort();
                    }
                    else
                        MessageBox.Show("Failed to open COM port!", "Error");
                }
                else
                {
                    if (adamSocket.Connect(AdamType.Adam5000Tcp, m_szIP, ProtocolType.Tcp))
                    {
                        m_iCount = 0; // reset the reading counter
                        //
                        if (RefreshForm())
                        {
                            panelDIO.Enabled = true;
                            timer1.Enabled = true; // enable timer
                            buttonStart.Text = "Stop";
                            m_bStart = true; // starting flag
                        }
                        else
                            adamSocket.Disconnect();
                    }
                    else
                        MessageBox.Show("Failed to connect to " + m_szIP + "!", "Error");
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            m_iCount++;
            txtReadCount.Text = "Polling " + m_iCount.ToString() + " times...";
            RefresDIO();
        }

        private bool RefreshForm()
        {
            bool bRet = false;

            if (m_Adam5000Type == Adam5000Type.Adam5050)
                bRet = InitAdam5050();
            else if (m_Adam5000Type == Adam5000Type.Adam5051)
                bRet = InitAdam5051();
            else if (m_Adam5000Type == Adam5000Type.Adam5052)
                bRet = InitAdam5052();
            else if (m_Adam5000Type == Adam5000Type.Adam5055)
                bRet = InitAdam5055();
            else if (m_Adam5000Type == Adam5000Type.Adam5056)
                bRet = InitAdam5056();
            else if (m_Adam5000Type == Adam5000Type.Adam5060)
                bRet = InitAdam5060();
            else if (m_Adam5000Type == Adam5000Type.Adam5068)
                bRet = InitAdam5068();
            else if (m_Adam5000Type == Adam5000Type.Adam5069)
                bRet = InitAdam5069();
            if (!bRet)
                MessageBox.Show("Refresh form failed", "Error");
            return bRet;
        }

        private void InitChannelItems(bool i_bVisable, bool i_bIsDI, bool i_bIsMasked, ref int i_iCh, ref int i_iDI, ref int i_iDO, ref Panel panelCh, ref Button btnCh)
        {
            int iCh;
            if (i_bVisable)
            {
                panelCh.Visible = true;
                iCh = i_iDI + i_iDO;
                if (i_bIsDI) // DI
                {
                    if (i_iCh >= 0)
                    {
                        btnCh.Text = "Ch" + i_iCh.ToString("00") + "/DI";
                        i_iCh++;
                    }
                    else
                        btnCh.Text = "DI " + i_iDI.ToString();
                    btnCh.Enabled = false;
                    i_iDI++;
                }
                else // DO
                {
                    if (i_iCh >= 0)
                    {
                        btnCh.Text = "Ch" + i_iCh.ToString("00") + "/DO";
                        i_iCh++;
                    }
                    else
                        btnCh.Text = "DO " + i_iDO.ToString();
                    if (i_bIsMasked)
                        btnCh.Enabled = false;
                    else
                        btnCh.Enabled = true;
                    i_iDO++;
                }
            }
            else
                panelCh.Visible = false;
        }

        private bool InitAdam5050()
        {
            bool[] bDIO, bMask;
            bool bRet;
            int iCh = 0, iDI = 0, iDO = 0;

            if (m_b5000)
                bRet = (adamCom.DigitalInput(m_iAddr).GetUniversalStatus(m_iSlot, out bDIO) & adamCom.DigitalOutput(m_iAddr).GetAlarmMappingMask(m_iSlot, m_iChTotal, out bMask));
            else
                bRet = (adamSocket.DigitalInput(m_iAddr).GetUniversalStatus(m_iSlot, out bDIO) & adamSocket.DigitalOutput(m_iAddr).GetAlarmMappingMask(m_iSlot, m_iChTotal, out bMask));
            if (bRet && bDIO.Length == 16)
            {
                InitChannelItems(true, bDIO[0], bMask[0], ref iCh, ref iDI, ref iDO, ref panelCh0, ref btnCh0);
                InitChannelItems(true, bDIO[1], bMask[1], ref iCh, ref iDI, ref iDO, ref panelCh1, ref btnCh1);
                InitChannelItems(true, bDIO[2], bMask[2], ref iCh, ref iDI, ref iDO, ref panelCh2, ref btnCh2);
                InitChannelItems(true, bDIO[3], bMask[3], ref iCh, ref iDI, ref iDO, ref panelCh3, ref btnCh3);
                InitChannelItems(true, bDIO[4], bMask[4], ref iCh, ref iDI, ref iDO, ref panelCh4, ref btnCh4);
                InitChannelItems(true, bDIO[5], bMask[5], ref iCh, ref iDI, ref iDO, ref panelCh5, ref btnCh5);
                InitChannelItems(true, bDIO[6], bMask[6], ref iCh, ref iDI, ref iDO, ref panelCh6, ref btnCh6);
                InitChannelItems(true, bDIO[7], bMask[7], ref iCh, ref iDI, ref iDO, ref panelCh7, ref btnCh7);
                InitChannelItems(true, bDIO[8], bMask[8], ref iCh, ref iDI, ref iDO, ref panelCh8, ref btnCh8);
                InitChannelItems(true, bDIO[9], bMask[9], ref iCh, ref iDI, ref iDO, ref panelCh9, ref btnCh9);
                InitChannelItems(true, bDIO[10], bMask[10], ref iCh, ref iDI, ref iDO, ref panelCh10, ref btnCh10);
                InitChannelItems(true, bDIO[11], bMask[11], ref iCh, ref iDI, ref iDO, ref panelCh11, ref btnCh11);
                InitChannelItems(true, bDIO[12], bMask[12], ref iCh, ref iDI, ref iDO, ref panelCh12, ref btnCh12);
                InitChannelItems(true, bDIO[13], bMask[13], ref iCh, ref iDI, ref iDO, ref panelCh13, ref btnCh13);
                InitChannelItems(true, bDIO[14], bMask[14], ref iCh, ref iDI, ref iDO, ref panelCh14, ref btnCh14);
                InitChannelItems(true, bDIO[15], bMask[15], ref iCh, ref iDI, ref iDO, ref panelCh15, ref btnCh15);
                return true;
            }
            return false;
        }

        private bool InitAdam5051()
        {
            int iCh = -1, iDI = 0, iDO = 0;

            InitChannelItems(true, true, false, ref iCh, ref iDI, ref iDO, ref panelCh0, ref btnCh0);
            InitChannelItems(true, true, false, ref iCh, ref iDI, ref iDO, ref panelCh1, ref btnCh1);
            InitChannelItems(true, true, false, ref iCh, ref iDI, ref iDO, ref panelCh2, ref btnCh2);
            InitChannelItems(true, true, false, ref iCh, ref iDI, ref iDO, ref panelCh3, ref btnCh3);
            InitChannelItems(true, true, false, ref iCh, ref iDI, ref iDO, ref panelCh4, ref btnCh4);
            InitChannelItems(true, true, false, ref iCh, ref iDI, ref iDO, ref panelCh5, ref btnCh5);
            InitChannelItems(true, true, false, ref iCh, ref iDI, ref iDO, ref panelCh6, ref btnCh6);
            InitChannelItems(true, true, false, ref iCh, ref iDI, ref iDO, ref panelCh7, ref btnCh7);
            InitChannelItems(true, true, false, ref iCh, ref iDI, ref iDO, ref panelCh8, ref btnCh8);
            InitChannelItems(true, true, false, ref iCh, ref iDI, ref iDO, ref panelCh9, ref btnCh9);
            InitChannelItems(true, true, false, ref iCh, ref iDI, ref iDO, ref panelCh10, ref btnCh10);
            InitChannelItems(true, true, false, ref iCh, ref iDI, ref iDO, ref panelCh11, ref btnCh11);
            InitChannelItems(true, true, false, ref iCh, ref iDI, ref iDO, ref panelCh12, ref btnCh12);
            InitChannelItems(true, true, false, ref iCh, ref iDI, ref iDO, ref panelCh13, ref btnCh13);
            InitChannelItems(true, true, false, ref iCh, ref iDI, ref iDO, ref panelCh14, ref btnCh14);
            InitChannelItems(true, true, false, ref iCh, ref iDI, ref iDO, ref panelCh15, ref btnCh15);
            return true;
        }

        private bool InitAdam5052()
        {
            int iCh = -1, iDI = 0, iDO = 0;

            InitChannelItems(true, true, false, ref iCh, ref iDI, ref iDO, ref panelCh0, ref btnCh0);
            InitChannelItems(true, true, false, ref iCh, ref iDI, ref iDO, ref panelCh1, ref btnCh1);
            InitChannelItems(true, true, false, ref iCh, ref iDI, ref iDO, ref panelCh2, ref btnCh2);
            InitChannelItems(true, true, false, ref iCh, ref iDI, ref iDO, ref panelCh3, ref btnCh3);
            InitChannelItems(true, true, false, ref iCh, ref iDI, ref iDO, ref panelCh4, ref btnCh4);
            InitChannelItems(true, true, false, ref iCh, ref iDI, ref iDO, ref panelCh5, ref btnCh5);
            InitChannelItems(true, true, false, ref iCh, ref iDI, ref iDO, ref panelCh6, ref btnCh6);
            InitChannelItems(true, true, false, ref iCh, ref iDI, ref iDO, ref panelCh7, ref btnCh7);
            InitChannelItems(false, true, false, ref iCh, ref iDI, ref iDO, ref panelCh8, ref btnCh8);
            InitChannelItems(false, true, false, ref iCh, ref iDI, ref iDO, ref panelCh9, ref btnCh9);
            InitChannelItems(false, true, false, ref iCh, ref iDI, ref iDO, ref panelCh10, ref btnCh10);
            InitChannelItems(false, true, false, ref iCh, ref iDI, ref iDO, ref panelCh11, ref btnCh11);
            InitChannelItems(false, true, false, ref iCh, ref iDI, ref iDO, ref panelCh12, ref btnCh12);
            InitChannelItems(false, true, false, ref iCh, ref iDI, ref iDO, ref panelCh13, ref btnCh13);
            InitChannelItems(false, true, false, ref iCh, ref iDI, ref iDO, ref panelCh14, ref btnCh14);
            InitChannelItems(false, true, false, ref iCh, ref iDI, ref iDO, ref panelCh15, ref btnCh15);
            return true;
        }

        private bool InitAdam5055()
        {
            bool[] bMask;
            bool bRet;
            int iCh = -1, iDI = 0, iDO = 0;

            if (m_b5000)
                bRet = adamCom.DigitalOutput(m_iAddr).GetAlarmMappingMask(m_iSlot, m_iChTotal, out bMask);
            else
                bRet = adamSocket.DigitalOutput(m_iAddr).GetAlarmMappingMask(m_iSlot, m_iChTotal, out bMask);
            if (bRet)
            {
                InitChannelItems(true, false, bMask[0], ref iCh, ref iDI, ref iDO, ref panelCh0, ref btnCh0);
                InitChannelItems(true, false, bMask[1], ref iCh, ref iDI, ref iDO, ref panelCh1, ref btnCh1);
                InitChannelItems(true, false, bMask[2], ref iCh, ref iDI, ref iDO, ref panelCh2, ref btnCh2);
                InitChannelItems(true, false, bMask[3], ref iCh, ref iDI, ref iDO, ref panelCh3, ref btnCh3);
                InitChannelItems(true, false, bMask[4], ref iCh, ref iDI, ref iDO, ref panelCh4, ref btnCh4);
                InitChannelItems(true, false, bMask[5], ref iCh, ref iDI, ref iDO, ref panelCh5, ref btnCh5);
                InitChannelItems(true, false, bMask[6], ref iCh, ref iDI, ref iDO, ref panelCh6, ref btnCh6);
                InitChannelItems(true, false, bMask[7], ref iCh, ref iDI, ref iDO, ref panelCh7, ref btnCh7);
                InitChannelItems(true, true, false, ref iCh, ref iDI, ref iDO, ref panelCh8, ref btnCh8);
                InitChannelItems(true, true, false, ref iCh, ref iDI, ref iDO, ref panelCh9, ref btnCh9);
                InitChannelItems(true, true, false, ref iCh, ref iDI, ref iDO, ref panelCh10, ref btnCh10);
                InitChannelItems(true, true, false, ref iCh, ref iDI, ref iDO, ref panelCh11, ref btnCh11);
                InitChannelItems(true, true, false, ref iCh, ref iDI, ref iDO, ref panelCh12, ref btnCh12);
                InitChannelItems(true, true, false, ref iCh, ref iDI, ref iDO, ref panelCh13, ref btnCh13);
                InitChannelItems(true, true, false, ref iCh, ref iDI, ref iDO, ref panelCh14, ref btnCh14);
                InitChannelItems(true, true, false, ref iCh, ref iDI, ref iDO, ref panelCh15, ref btnCh15);
                return true;
            }
            return false;
        }

        private bool InitAdam5056()
        {
            bool[] bMask;
            bool bRet;
            int iCh = -1, iDI = 0, iDO = 0;

            if (m_b5000)
                bRet = adamCom.DigitalOutput(m_iAddr).GetAlarmMappingMask(m_iSlot, m_iChTotal, out bMask);
            else
                bRet = adamSocket.DigitalOutput(m_iAddr).GetAlarmMappingMask(m_iSlot, m_iChTotal, out bMask);
            if (bRet)
            {
                InitChannelItems(true, false, bMask[0], ref iCh, ref iDI, ref iDO, ref panelCh0, ref btnCh0);
                InitChannelItems(true, false, bMask[1], ref iCh, ref iDI, ref iDO, ref panelCh1, ref btnCh1);
                InitChannelItems(true, false, bMask[2], ref iCh, ref iDI, ref iDO, ref panelCh2, ref btnCh2);
                InitChannelItems(true, false, bMask[3], ref iCh, ref iDI, ref iDO, ref panelCh3, ref btnCh3);
                InitChannelItems(true, false, bMask[4], ref iCh, ref iDI, ref iDO, ref panelCh4, ref btnCh4);
                InitChannelItems(true, false, bMask[5], ref iCh, ref iDI, ref iDO, ref panelCh5, ref btnCh5);
                InitChannelItems(true, false, bMask[6], ref iCh, ref iDI, ref iDO, ref panelCh6, ref btnCh6);
                InitChannelItems(true, false, bMask[7], ref iCh, ref iDI, ref iDO, ref panelCh7, ref btnCh7);
                InitChannelItems(true, false, bMask[8], ref iCh, ref iDI, ref iDO, ref panelCh8, ref btnCh8);
                InitChannelItems(true, false, bMask[9], ref iCh, ref iDI, ref iDO, ref panelCh9, ref btnCh9);
                InitChannelItems(true, false, bMask[10], ref iCh, ref iDI, ref iDO, ref panelCh10, ref btnCh10);
                InitChannelItems(true, false, bMask[11], ref iCh, ref iDI, ref iDO, ref panelCh11, ref btnCh11);
                InitChannelItems(true, false, bMask[12], ref iCh, ref iDI, ref iDO, ref panelCh12, ref btnCh12);
                InitChannelItems(true, false, bMask[13], ref iCh, ref iDI, ref iDO, ref panelCh13, ref btnCh13);
                InitChannelItems(true, false, bMask[14], ref iCh, ref iDI, ref iDO, ref panelCh14, ref btnCh14);
                InitChannelItems(true, false, bMask[15], ref iCh, ref iDI, ref iDO, ref panelCh15, ref btnCh15);
                return true;
            }
            return false;
        }

        private bool InitAdam5060()
        {
            bool[] bMask;
            bool bRet;
            int iCh = -1, iDI = 0, iDO = 0;

            if (m_b5000)
                bRet = adamCom.DigitalOutput(m_iAddr).GetAlarmMappingMask(m_iSlot, m_iChTotal, out bMask);
            else
                bRet = adamSocket.DigitalOutput(m_iAddr).GetAlarmMappingMask(m_iSlot, m_iChTotal, out bMask);
            if (bRet)
            {
                InitChannelItems(true, false, bMask[0], ref iCh, ref iDI, ref iDO, ref panelCh0, ref btnCh0);
                InitChannelItems(true, false, bMask[1], ref iCh, ref iDI, ref iDO, ref panelCh1, ref btnCh1);
                InitChannelItems(true, false, bMask[2], ref iCh, ref iDI, ref iDO, ref panelCh2, ref btnCh2);
                InitChannelItems(true, false, bMask[3], ref iCh, ref iDI, ref iDO, ref panelCh3, ref btnCh3);
                InitChannelItems(true, false, bMask[4], ref iCh, ref iDI, ref iDO, ref panelCh4, ref btnCh4);
                InitChannelItems(true, false, bMask[5], ref iCh, ref iDI, ref iDO, ref panelCh5, ref btnCh5);
                InitChannelItems(false, false, false, ref iCh, ref iDI, ref iDO, ref panelCh6, ref btnCh6);
                InitChannelItems(false, false, false, ref iCh, ref iDI, ref iDO, ref panelCh7, ref btnCh7);
                InitChannelItems(false, false, false, ref iCh, ref iDI, ref iDO, ref panelCh8, ref btnCh8);
                InitChannelItems(false, false, false, ref iCh, ref iDI, ref iDO, ref panelCh9, ref btnCh9);
                InitChannelItems(false, false, false, ref iCh, ref iDI, ref iDO, ref panelCh10, ref btnCh10);
                InitChannelItems(false, false, false, ref iCh, ref iDI, ref iDO, ref panelCh11, ref btnCh11);
                InitChannelItems(false, false, false, ref iCh, ref iDI, ref iDO, ref panelCh12, ref btnCh12);
                InitChannelItems(false, false, false, ref iCh, ref iDI, ref iDO, ref panelCh13, ref btnCh13);
                InitChannelItems(false, false, false, ref iCh, ref iDI, ref iDO, ref panelCh14, ref btnCh14);
                InitChannelItems(false, false, false, ref iCh, ref iDI, ref iDO, ref panelCh15, ref btnCh15);
                return true;
            }
            return false;
        }

        private bool InitAdam5068()
        {
            bool[] bMask;
            bool bRet;
            int iCh = -1, iDI = 0, iDO = 0;

            if (m_b5000)
                bRet = adamCom.DigitalOutput(m_iAddr).GetAlarmMappingMask(m_iSlot, m_iChTotal, out bMask);
            else
                bRet = adamSocket.DigitalOutput(m_iAddr).GetAlarmMappingMask(m_iSlot, m_iChTotal, out bMask);
            if (bRet)
            {
                InitChannelItems(true, false, bMask[0], ref iCh, ref iDI, ref iDO, ref panelCh0, ref btnCh0);
                InitChannelItems(true, false, bMask[1], ref iCh, ref iDI, ref iDO, ref panelCh1, ref btnCh1);
                InitChannelItems(true, false, bMask[2], ref iCh, ref iDI, ref iDO, ref panelCh2, ref btnCh2);
                InitChannelItems(true, false, bMask[3], ref iCh, ref iDI, ref iDO, ref panelCh3, ref btnCh3);
                InitChannelItems(true, false, bMask[4], ref iCh, ref iDI, ref iDO, ref panelCh4, ref btnCh4);
                InitChannelItems(true, false, bMask[5], ref iCh, ref iDI, ref iDO, ref panelCh5, ref btnCh5);
                InitChannelItems(true, false, bMask[6], ref iCh, ref iDI, ref iDO, ref panelCh6, ref btnCh6);
                InitChannelItems(true, false, bMask[7], ref iCh, ref iDI, ref iDO, ref panelCh7, ref btnCh7);
                InitChannelItems(false, false, false, ref iCh, ref iDI, ref iDO, ref panelCh8, ref btnCh8);
                InitChannelItems(false, false, false, ref iCh, ref iDI, ref iDO, ref panelCh9, ref btnCh9);
                InitChannelItems(false, false, false, ref iCh, ref iDI, ref iDO, ref panelCh10, ref btnCh10);
                InitChannelItems(false, false, false, ref iCh, ref iDI, ref iDO, ref panelCh11, ref btnCh11);
                InitChannelItems(false, false, false, ref iCh, ref iDI, ref iDO, ref panelCh12, ref btnCh12);
                InitChannelItems(false, false, false, ref iCh, ref iDI, ref iDO, ref panelCh13, ref btnCh13);
                InitChannelItems(false, false, false, ref iCh, ref iDI, ref iDO, ref panelCh14, ref btnCh14);
                InitChannelItems(false, false, false, ref iCh, ref iDI, ref iDO, ref panelCh15, ref btnCh15);
                return true;
            }
            return false;
        }

        private bool InitAdam5069()
        {
            bool[] bMask;
            bool bRet;
            int iCh = -1, iDI = 0, iDO = 0;

            if (m_b5000)
                bRet = adamCom.DigitalOutput(m_iAddr).GetAlarmMappingMask(m_iSlot, m_iChTotal, out bMask);
            else
                bRet = adamSocket.DigitalOutput(m_iAddr).GetAlarmMappingMask(m_iSlot, m_iChTotal, out bMask);
            if (bRet)
            {
                InitChannelItems(true, false, bMask[0], ref iCh, ref iDI, ref iDO, ref panelCh0, ref btnCh0);
                InitChannelItems(true, false, bMask[1], ref iCh, ref iDI, ref iDO, ref panelCh1, ref btnCh1);
                InitChannelItems(true, false, bMask[2], ref iCh, ref iDI, ref iDO, ref panelCh2, ref btnCh2);
                InitChannelItems(true, false, bMask[3], ref iCh, ref iDI, ref iDO, ref panelCh3, ref btnCh3);
                InitChannelItems(true, false, bMask[4], ref iCh, ref iDI, ref iDO, ref panelCh4, ref btnCh4);
                InitChannelItems(true, false, bMask[5], ref iCh, ref iDI, ref iDO, ref panelCh5, ref btnCh5);
                InitChannelItems(true, false, bMask[6], ref iCh, ref iDI, ref iDO, ref panelCh6, ref btnCh6);
                InitChannelItems(true, false, bMask[7], ref iCh, ref iDI, ref iDO, ref panelCh7, ref btnCh7);
                InitChannelItems(false, false, false, ref iCh, ref iDI, ref iDO, ref panelCh8, ref btnCh8);
                InitChannelItems(false, false, false, ref iCh, ref iDI, ref iDO, ref panelCh9, ref btnCh9);
                InitChannelItems(false, false, false, ref iCh, ref iDI, ref iDO, ref panelCh10, ref btnCh10);
                InitChannelItems(false, false, false, ref iCh, ref iDI, ref iDO, ref panelCh11, ref btnCh11);
                InitChannelItems(false, false, false, ref iCh, ref iDI, ref iDO, ref panelCh12, ref btnCh12);
                InitChannelItems(false, false, false, ref iCh, ref iDI, ref iDO, ref panelCh13, ref btnCh13);
                InitChannelItems(false, false, false, ref iCh, ref iDI, ref iDO, ref panelCh14, ref btnCh14);
                InitChannelItems(false, false, false, ref iCh, ref iDI, ref iDO, ref panelCh15, ref btnCh15);
                return true;
            }
            return false;
        }

        private bool RefresDIO()
        {
            int iStart = m_iSlot * 16 + 1;
            bool[] bData;
            bool bRet;

            if (m_b5000)
            {
                if (this.m_Adam5000Type == Adam5000Type.Adam5052)
                    bRet = adamCom.DigitalInput(m_iAddr).GetValues(m_iSlot, m_iChTotal, out bData);	
                else
                    bRet = adamCom.DigitalOutput(m_iAddr).GetValues(m_iSlot, m_iChTotal, out bData);
            }
            else
                bRet = adamSocket.Modbus(m_iAddr).ReadCoilStatus(iStart, m_iChTotal, out bData);
            if (bRet)
            {
                if (m_iChTotal > 0)
                    txtCh0.Text = bData[0].ToString();
                if (m_iChTotal > 1)
                    txtCh1.Text = bData[1].ToString();
                if (m_iChTotal > 2)
                    txtCh2.Text = bData[2].ToString();
                if (m_iChTotal > 3)
                    txtCh3.Text = bData[3].ToString();
                if (m_iChTotal > 4)
                    txtCh4.Text = bData[4].ToString();
                if (m_iChTotal > 5)
                    txtCh5.Text = bData[5].ToString();
                if (m_iChTotal > 6)
                    txtCh6.Text = bData[6].ToString();
                if (m_iChTotal > 7)
                    txtCh7.Text = bData[7].ToString();
                if (m_iChTotal > 8)
                    txtCh8.Text = bData[8].ToString();
                if (m_iChTotal > 9)
                    txtCh9.Text = bData[9].ToString();
                if (m_iChTotal > 10)
                    txtCh10.Text = bData[10].ToString();
                if (m_iChTotal > 11)
                    txtCh11.Text = bData[11].ToString();
                if (m_iChTotal > 12)
                    txtCh12.Text = bData[12].ToString();
                if (m_iChTotal > 13)
                    txtCh13.Text = bData[13].ToString();
                if (m_iChTotal > 14)
                    txtCh14.Text = bData[14].ToString();
                if (m_iChTotal > 15)
                    txtCh15.Text = bData[15].ToString();
                return true;
            }
            else
            {
                txtCh0.Text = "Fail";
                txtCh1.Text = "Fail";
                txtCh2.Text = "Fail";
                txtCh3.Text = "Fail";
                txtCh4.Text = "Fail";
                txtCh5.Text = "Fail";
                txtCh6.Text = "Fail";
                txtCh7.Text = "Fail";
                txtCh8.Text = "Fail";
                txtCh9.Text = "Fail";
                txtCh10.Text = "Fail";
                txtCh11.Text = "Fail";
                txtCh12.Text = "Fail";
                txtCh13.Text = "Fail";
                txtCh14.Text = "Fail";
                txtCh15.Text = "Fail";
            }
            return false;
        }

        private void btnCh_Click(int i_iCh, TextBox txtBox)
        {
            bool bRet;
            int iStart = m_iSlot * 16 + i_iCh + 1;

            timer1.Enabled = false;
            if (m_b5000)
                bRet = adamCom.DigitalOutput(m_iAddr).SetValue(m_iSlot, i_iCh, (txtBox.Text == "False"));
            else
                bRet = adamSocket.Modbus(m_iAddr).ForceSingleCoil(iStart, (txtBox.Text == "False"));
            if (!bRet)
                MessageBox.Show("Set digital output failed!", "Error");
            timer1.Enabled = true;
        }

        private void btnCh0_Click(object sender, EventArgs e)
        {
            btnCh_Click(0, txtCh0);
        }

        private void btnCh1_Click(object sender, EventArgs e)
        {
            btnCh_Click(1, txtCh1);
        }

        private void btnCh2_Click(object sender, EventArgs e)
        {
            btnCh_Click(2, txtCh2);
        }

        private void btnCh3_Click(object sender, EventArgs e)
        {
            btnCh_Click(3, txtCh3);
        }

        private void btnCh4_Click(object sender, EventArgs e)
        {
            btnCh_Click(4, txtCh4);
        }

        private void btnCh5_Click(object sender, EventArgs e)
        {
            btnCh_Click(5, txtCh5);
        }

        private void btnCh6_Click(object sender, EventArgs e)
        {
            btnCh_Click(6, txtCh6);
        }

        private void btnCh7_Click(object sender, EventArgs e)
        {
            btnCh_Click(7, txtCh7);
        }

        private void btnCh8_Click(object sender, EventArgs e)
        {
            btnCh_Click(8, txtCh8);
        }

        private void btnCh9_Click(object sender, EventArgs e)
        {
            btnCh_Click(9, txtCh9);
        }

        private void btnCh10_Click(object sender, EventArgs e)
        {
            btnCh_Click(10, txtCh10);
        }

        private void btnCh11_Click(object sender, EventArgs e)
        {
            btnCh_Click(11, txtCh11);
        }

        private void btnCh12_Click(object sender, EventArgs e)
        {
            btnCh_Click(12, txtCh12);
        }

        private void btnCh13_Click(object sender, EventArgs e)
        {
            btnCh_Click(13, txtCh13);
        }

        private void btnCh14_Click(object sender, EventArgs e)
        {
            btnCh_Click(14, txtCh14);
        }

        private void btnCh15_Click(object sender, EventArgs e)
        {
            btnCh_Click(15, txtCh15);
        }
    }
}