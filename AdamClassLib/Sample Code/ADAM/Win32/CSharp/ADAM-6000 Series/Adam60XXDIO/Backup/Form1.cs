using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using Advantech.Adam;

namespace Adam60XXDIO
{
    public partial class Form1 : Form
    {
        private bool m_bStart;
        private AdamSocket adamModbus;
        private Adam6000Type m_Adam6000Type;
        private string m_szIP;
        private int m_iPort;
        private int m_iDoTotal, m_iDiTotal, m_iCount;

        public Form1()
        {
            InitializeComponent();

            m_bStart = false;			// the action stops at the beginning
            m_szIP = "172.18.3.232";	// modbus slave IP address
            m_iPort = 502;				// modbus TCP port is 502
            adamModbus = new AdamSocket();
            adamModbus.SetTimeout(1000, 1000, 1000); // set timeout for TCP

            m_Adam6000Type = Adam6000Type.Adam6050; // the sample is for ADAM-6050
            //m_Adam6000Type = Adam6000Type.Adam6050W; // the sample is for ADAM-6050W
            //m_Adam6000Type = Adam6000Type.Adam6051; // the sample is for ADAM-6051
            //m_Adam6000Type = Adam6000Type.Adam6051W; // the sample is for ADAM-6051W
            //m_Adam6000Type = Adam6000Type.Adam6052; // the sample is for ADAM-6052
            //m_Adam6000Type = Adam6000Type.Adam6055; // the sample is for ADAM-6055
            //m_Adam6000Type = Adam6000Type.Adam6060; // the sample is for ADAM-6060
            //m_Adam6000Type = Adam6000Type.Adam6060W; // the sample is for ADAM-6060W
            //m_Adam6000Type = Adam6000Type.Adam6066; // the sample is for ADAM-6066

            if (m_Adam6000Type == Adam6000Type.Adam6050 ||
                m_Adam6000Type == Adam6000Type.Adam6050W)
                InitAdam6050();
            else if (m_Adam6000Type == Adam6000Type.Adam6051 ||
                m_Adam6000Type == Adam6000Type.Adam6051W)
                InitAdam6051();
            else if (m_Adam6000Type == Adam6000Type.Adam6052)
                InitAdam6052();
            else if (m_Adam6000Type == Adam6000Type.Adam6055)
                InitAdam6055();
            else if (m_Adam6000Type == Adam6000Type.Adam6060 ||
                m_Adam6000Type == Adam6000Type.Adam6060W)
                InitAdam6060();
            else if (m_Adam6000Type == Adam6000Type.Adam6066)
                InitAdam6066();

            txtModule.Text = m_Adam6000Type.ToString();
        }

        protected void InitChannelItems(bool i_bVisable, bool i_bIsDI, ref int i_iDI, ref int i_iDO, ref Panel panelCh, ref Button btnCh, ref CheckBox cbxWDT)
        {
            int iCh;
            if (i_bVisable)
            {
                panelCh.Visible = true;
                iCh = i_iDI + i_iDO;
                if (i_bIsDI) // DI
                {
                    btnCh.Text = "DI " + i_iDI.ToString();
                    btnCh.Enabled = false;
                    i_iDI++;
                    cbxWDT.Visible = false;
                }
                else // DO
                {
                    btnCh.Text = "DO " + i_iDO.ToString();
                    i_iDO++;
                }
            }
            else
                panelCh.Visible = false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected void InitAdam6050()
        {
            int iDI = 0, iDO = 0;

            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh0, ref btnCh0, ref cbxWDT0);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh1, ref btnCh1, ref cbxWDT1);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh2, ref btnCh2, ref cbxWDT2);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh3, ref btnCh3, ref cbxWDT3);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh4, ref btnCh4, ref cbxWDT4);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh5, ref btnCh5, ref cbxWDT5);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh6, ref btnCh6, ref cbxWDT6);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh7, ref btnCh7, ref cbxWDT7);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh8, ref btnCh8, ref cbxWDT8);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh9, ref btnCh9, ref cbxWDT9);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh10, ref btnCh10, ref cbxWDT10);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh11, ref btnCh11, ref cbxWDT11);
            InitChannelItems(true, false, ref iDI, ref iDO, ref panelCh12, ref btnCh12, ref cbxWDT12);
            InitChannelItems(true, false, ref iDI, ref iDO, ref panelCh13, ref btnCh13, ref cbxWDT13);
            InitChannelItems(true, false, ref iDI, ref iDO, ref panelCh14, ref btnCh14, ref cbxWDT14);
            InitChannelItems(true, false, ref iDI, ref iDO, ref panelCh15, ref btnCh15, ref cbxWDT15);
            InitChannelItems(true, false, ref iDI, ref iDO, ref panelCh16, ref btnCh16, ref cbxWDT16);
            InitChannelItems(true, false, ref iDI, ref iDO, ref panelCh17, ref btnCh17, ref cbxWDT17);

            m_iDoTotal = iDO;
            m_iDiTotal = iDI;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected void InitAdam6051()
        {
            int iDI = 0, iDO = 0;

            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh0, ref btnCh0, ref cbxWDT0);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh1, ref btnCh1, ref cbxWDT1);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh2, ref btnCh2, ref cbxWDT2);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh3, ref btnCh3, ref cbxWDT3);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh4, ref btnCh4, ref cbxWDT4);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh5, ref btnCh5, ref cbxWDT5);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh6, ref btnCh6, ref cbxWDT6);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh7, ref btnCh7, ref cbxWDT7);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh8, ref btnCh8, ref cbxWDT8);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh9, ref btnCh9, ref cbxWDT9);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh10, ref btnCh10, ref cbxWDT10);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh11, ref btnCh11, ref cbxWDT11);
            InitChannelItems(true, false, ref iDI, ref iDO, ref panelCh12, ref btnCh12, ref cbxWDT12);
            InitChannelItems(true, false, ref iDI, ref iDO, ref panelCh13, ref btnCh13, ref cbxWDT13);
            InitChannelItems(false, true, ref iDI, ref iDO, ref panelCh14, ref btnCh14, ref cbxWDT14);
            InitChannelItems(false, true, ref iDI, ref iDO, ref panelCh15, ref btnCh15, ref cbxWDT15);
            InitChannelItems(false, true, ref iDI, ref iDO, ref panelCh16, ref btnCh16, ref cbxWDT16);
            InitChannelItems(false, true, ref iDI, ref iDO, ref panelCh17, ref btnCh17, ref cbxWDT17);

            m_iDoTotal = iDO;
            m_iDiTotal = iDI;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected void InitAdam6052()
        {
            int iDI = 0, iDO = 0;

            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh0, ref btnCh0, ref cbxWDT0);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh1, ref btnCh1, ref cbxWDT1);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh2, ref btnCh2, ref cbxWDT2);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh3, ref btnCh3, ref cbxWDT3);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh4, ref btnCh4, ref cbxWDT4);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh5, ref btnCh5, ref cbxWDT5);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh6, ref btnCh6, ref cbxWDT6);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh7, ref btnCh7, ref cbxWDT7);
            InitChannelItems(true, false, ref iDI, ref iDO, ref panelCh8, ref btnCh8, ref cbxWDT8);
            InitChannelItems(true, false, ref iDI, ref iDO, ref panelCh9, ref btnCh9, ref cbxWDT9);
            InitChannelItems(true, false, ref iDI, ref iDO, ref panelCh10, ref btnCh10, ref cbxWDT10);
            InitChannelItems(true, false, ref iDI, ref iDO, ref panelCh11, ref btnCh11, ref cbxWDT11);
            InitChannelItems(true, false, ref iDI, ref iDO, ref panelCh12, ref btnCh12, ref cbxWDT12);
            InitChannelItems(true, false, ref iDI, ref iDO, ref panelCh13, ref btnCh13, ref cbxWDT13);
            InitChannelItems(true, false, ref iDI, ref iDO, ref panelCh14, ref btnCh14, ref cbxWDT14);
            InitChannelItems(true, false, ref iDI, ref iDO, ref panelCh15, ref btnCh15, ref cbxWDT15);
            InitChannelItems(false, true, ref iDI, ref iDO, ref panelCh16, ref btnCh16, ref cbxWDT16);
            InitChannelItems(false, true, ref iDI, ref iDO, ref panelCh17, ref btnCh17, ref cbxWDT17);

            m_iDoTotal = iDO;
            m_iDiTotal = iDI;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected void InitAdam6055()
        {
            int iDI = 0, iDO = 0;

            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh0, ref btnCh0, ref cbxWDT0);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh1, ref btnCh1, ref cbxWDT1);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh2, ref btnCh2, ref cbxWDT2);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh3, ref btnCh3, ref cbxWDT3);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh4, ref btnCh4, ref cbxWDT4);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh5, ref btnCh5, ref cbxWDT5);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh6, ref btnCh6, ref cbxWDT6);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh7, ref btnCh7, ref cbxWDT7);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh8, ref btnCh8, ref cbxWDT8);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh9, ref btnCh9, ref cbxWDT9);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh10, ref btnCh10, ref cbxWDT10);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh11, ref btnCh11, ref cbxWDT11);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh12, ref btnCh12, ref cbxWDT12);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh13, ref btnCh13, ref cbxWDT13);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh14, ref btnCh14, ref cbxWDT14);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh15, ref btnCh15, ref cbxWDT15);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh16, ref btnCh16, ref cbxWDT16);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh17, ref btnCh17, ref cbxWDT17);

            m_iDoTotal = iDO;
            m_iDiTotal = iDI;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected void InitAdam6060()
        {
            int iDI = 0, iDO = 0;

            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh0, ref btnCh0, ref cbxWDT0);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh1, ref btnCh1, ref cbxWDT1);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh2, ref btnCh2, ref cbxWDT2);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh3, ref btnCh3, ref cbxWDT3);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh4, ref btnCh4, ref cbxWDT4);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh5, ref btnCh5, ref cbxWDT5);
            InitChannelItems(true, false, ref iDI, ref iDO, ref panelCh6, ref btnCh6, ref cbxWDT6);
            InitChannelItems(true, false, ref iDI, ref iDO, ref panelCh7, ref btnCh7, ref cbxWDT7);
            InitChannelItems(true, false, ref iDI, ref iDO, ref panelCh8, ref btnCh8, ref cbxWDT8);
            InitChannelItems(true, false, ref iDI, ref iDO, ref panelCh9, ref btnCh9, ref cbxWDT9);
            InitChannelItems(true, false, ref iDI, ref iDO, ref panelCh10, ref btnCh10, ref cbxWDT10);
            InitChannelItems(true, false, ref iDI, ref iDO, ref panelCh11, ref btnCh11, ref cbxWDT11);
            InitChannelItems(false, true, ref iDI, ref iDO, ref panelCh12, ref btnCh12, ref cbxWDT12);
            InitChannelItems(false, true, ref iDI, ref iDO, ref panelCh13, ref btnCh13, ref cbxWDT13);
            InitChannelItems(false, true, ref iDI, ref iDO, ref panelCh14, ref btnCh14, ref cbxWDT14);
            InitChannelItems(false, true, ref iDI, ref iDO, ref panelCh15, ref btnCh15, ref cbxWDT15);
            InitChannelItems(false, true, ref iDI, ref iDO, ref panelCh16, ref btnCh16, ref cbxWDT16);
            InitChannelItems(false, true, ref iDI, ref iDO, ref panelCh17, ref btnCh17, ref cbxWDT17);

            m_iDoTotal = iDO;
            m_iDiTotal = iDI;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected void InitAdam6066()
        {
            int iDI = 0, iDO = 0;

            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh0, ref btnCh0, ref cbxWDT0);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh1, ref btnCh1, ref cbxWDT1);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh2, ref btnCh2, ref cbxWDT2);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh3, ref btnCh3, ref cbxWDT3);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh4, ref btnCh4, ref cbxWDT4);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh5, ref btnCh5, ref cbxWDT5);
            InitChannelItems(true, false, ref iDI, ref iDO, ref panelCh6, ref btnCh6, ref cbxWDT6);
            InitChannelItems(true, false, ref iDI, ref iDO, ref panelCh7, ref btnCh7, ref cbxWDT7);
            InitChannelItems(true, false, ref iDI, ref iDO, ref panelCh8, ref btnCh8, ref cbxWDT8);
            InitChannelItems(true, false, ref iDI, ref iDO, ref panelCh9, ref btnCh9, ref cbxWDT9);
            InitChannelItems(true, false, ref iDI, ref iDO, ref panelCh10, ref btnCh10, ref cbxWDT10);
            InitChannelItems(true, false, ref iDI, ref iDO, ref panelCh11, ref btnCh11, ref cbxWDT11);
            InitChannelItems(false, true, ref iDI, ref iDO, ref panelCh12, ref btnCh12, ref cbxWDT12);
            InitChannelItems(false, true, ref iDI, ref iDO, ref panelCh13, ref btnCh13, ref cbxWDT13);
            InitChannelItems(false, true, ref iDI, ref iDO, ref panelCh14, ref btnCh14, ref cbxWDT14);
            InitChannelItems(false, true, ref iDI, ref iDO, ref panelCh15, ref btnCh15, ref cbxWDT15);
            InitChannelItems(false, true, ref iDI, ref iDO, ref panelCh16, ref btnCh16, ref cbxWDT16);
            InitChannelItems(false, true, ref iDI, ref iDO, ref panelCh17, ref btnCh17, ref cbxWDT17);

            m_iDoTotal = iDO;
            m_iDiTotal = iDI;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_bStart)
            {
                timer1.Enabled = false;
                adamModbus.Disconnect(); // disconnect slave
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (m_bStart) // was started
            {
                panelDIO.Enabled = false;
                m_bStart = false;		// starting flag
                timer1.Enabled = false; // disable timer
                adamModbus.Disconnect(); // disconnect slave
                buttonStart.Text = "Start";
                btnApplyWDT.Enabled = false;
            }
            else	// was stoped
            {
                if (adamModbus.Connect(m_szIP, ProtocolType.Tcp, m_iPort))
                {
                    RefreshWDT();
                    panelDIO.Enabled = true;
                    m_iCount = 0; // reset the reading counter
                    timer1.Enabled = true; // enable timer
                    buttonStart.Text = "Stop";
                    m_bStart = true; // starting flag
                    btnApplyWDT.Enabled = true;
                }
                else
                    MessageBox.Show("Connect to " + m_szIP + " failed", "Error");
            }		
        }

        private void RefreshDIO()
        {
            int iDiStart = 1, iDoStart = 17;
            int iChTotal;
            bool[] bDiData, bDoData, bData;

            if (m_Adam6000Type == Adam6000Type.Adam6055)
            {
                if (adamModbus.Modbus().ReadCoilStatus(iDiStart, m_iDiTotal, out bDiData))
                {
                    iChTotal = m_iDiTotal;
                    bData = new bool[iChTotal];
                    Array.Copy(bDiData, 0, bData, 0, m_iDiTotal);
                    if (iChTotal > 0)
                        txtCh0.Text = bData[0].ToString();
                    if (iChTotal > 1)
                        txtCh1.Text = bData[1].ToString();
                    if (iChTotal > 2)
                        txtCh2.Text = bData[2].ToString();
                    if (iChTotal > 3)
                        txtCh3.Text = bData[3].ToString();
                    if (iChTotal > 4)
                        txtCh4.Text = bData[4].ToString();
                    if (iChTotal > 5)
                        txtCh5.Text = bData[5].ToString();
                    if (iChTotal > 6)
                        txtCh6.Text = bData[6].ToString();
                    if (iChTotal > 7)
                        txtCh7.Text = bData[7].ToString();
                    if (iChTotal > 8)
                        txtCh8.Text = bData[8].ToString();
                    if (iChTotal > 9)
                        txtCh9.Text = bData[9].ToString();
                    if (iChTotal > 10)
                        txtCh10.Text = bData[10].ToString();
                    if (iChTotal > 11)
                        txtCh11.Text = bData[11].ToString();
                    if (iChTotal > 12)
                        txtCh12.Text = bData[12].ToString();
                    if (iChTotal > 13)
                        txtCh13.Text = bData[13].ToString();
                    if (iChTotal > 14)
                        txtCh14.Text = bData[14].ToString();
                    if (iChTotal > 15)
                        txtCh15.Text = bData[15].ToString();
                    if (iChTotal > 16)
                        txtCh16.Text = bData[16].ToString();
                    if (iChTotal > 17)
                        txtCh17.Text = bData[17].ToString();
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
                    txtCh16.Text = "Fail";
                    txtCh17.Text = "Fail";
                }
            }
            else
            {
                if (adamModbus.Modbus().ReadCoilStatus(iDiStart, m_iDiTotal, out bDiData) &&
                    adamModbus.Modbus().ReadCoilStatus(iDoStart, m_iDoTotal, out bDoData))
                {
                    iChTotal = m_iDiTotal + m_iDoTotal;
                    bData = new bool[iChTotal];
                    Array.Copy(bDiData, 0, bData, 0, m_iDiTotal);
                    Array.Copy(bDoData, 0, bData, m_iDiTotal, m_iDoTotal);
                    if (iChTotal > 0)
                        txtCh0.Text = bData[0].ToString();
                    if (iChTotal > 1)
                        txtCh1.Text = bData[1].ToString();
                    if (iChTotal > 2)
                        txtCh2.Text = bData[2].ToString();
                    if (iChTotal > 3)
                        txtCh3.Text = bData[3].ToString();
                    if (iChTotal > 4)
                        txtCh4.Text = bData[4].ToString();
                    if (iChTotal > 5)
                        txtCh5.Text = bData[5].ToString();
                    if (iChTotal > 6)
                        txtCh6.Text = bData[6].ToString();
                    if (iChTotal > 7)
                        txtCh7.Text = bData[7].ToString();
                    if (iChTotal > 8)
                        txtCh8.Text = bData[8].ToString();
                    if (iChTotal > 9)
                        txtCh9.Text = bData[9].ToString();
                    if (iChTotal > 10)
                        txtCh10.Text = bData[10].ToString();
                    if (iChTotal > 11)
                        txtCh11.Text = bData[11].ToString();
                    if (iChTotal > 12)
                        txtCh12.Text = bData[12].ToString();
                    if (iChTotal > 13)
                        txtCh13.Text = bData[13].ToString();
                    if (iChTotal > 14)
                        txtCh14.Text = bData[14].ToString();
                    if (iChTotal > 15)
                        txtCh15.Text = bData[15].ToString();
                    if (iChTotal > 16)
                        txtCh16.Text = bData[16].ToString();
                    if (iChTotal > 17)
                        txtCh17.Text = bData[17].ToString();
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
                    txtCh16.Text = "Fail";
                    txtCh17.Text = "Fail";
                }
            }

            System.GC.Collect();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            m_iCount++; // increment the reading counter
            txtReadCount.Text = "Read coil " + m_iCount.ToString() + " times...";
            RefreshDIO();

            timer1.Enabled = true;
        }

        private void btnCh_Click(int i_iCh, TextBox txtBox)
        {
            int iOnOff, iStart = 17 + i_iCh - m_iDiTotal;

            timer1.Enabled = false;
            if (txtBox.Text == "True") // was ON, now set to OFF
            {
                iOnOff = 0;
            }
            else
            {
                iOnOff = 1;
            }
            if (adamModbus.Modbus().ForceSingleCoil(iStart, iOnOff))
                RefreshDIO();
            else
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

        private void btnCh16_Click(object sender, EventArgs e)
        {
            btnCh_Click(16, txtCh16);
        }

        private void btnCh17_Click(object sender, EventArgs e)
        {
            btnCh_Click(17, txtCh17);
        }

        private void btnApplyWDT_Click(object sender, EventArgs e)
        {
            int iCnt;
            bool[] bWDT;

            timer1.Enabled = false;
            bWDT = new bool[m_iDoTotal];

            iCnt = 0;

            ApplyWDT(0, ref iCnt, ref cbxWDT0, ref bWDT);
            ApplyWDT(1, ref iCnt, ref cbxWDT1, ref bWDT);
            ApplyWDT(2, ref iCnt, ref cbxWDT2, ref bWDT);
            ApplyWDT(3, ref iCnt, ref cbxWDT3, ref bWDT);
            ApplyWDT(4, ref iCnt, ref cbxWDT4, ref bWDT);
            ApplyWDT(5, ref iCnt, ref cbxWDT5, ref bWDT);
            ApplyWDT(6, ref iCnt, ref cbxWDT6, ref bWDT);
            ApplyWDT(7, ref iCnt, ref cbxWDT7, ref bWDT);
            ApplyWDT(8, ref iCnt, ref cbxWDT8, ref bWDT);
            ApplyWDT(9, ref iCnt, ref cbxWDT9, ref bWDT);
            ApplyWDT(10, ref iCnt, ref cbxWDT10, ref bWDT);
            ApplyWDT(11, ref iCnt, ref cbxWDT11, ref bWDT);
            ApplyWDT(12, ref iCnt, ref cbxWDT12, ref bWDT);
            ApplyWDT(13, ref iCnt, ref cbxWDT13, ref bWDT);
            ApplyWDT(14, ref iCnt, ref cbxWDT14, ref bWDT);
            ApplyWDT(15, ref iCnt, ref cbxWDT15, ref bWDT);
            ApplyWDT(16, ref iCnt, ref cbxWDT16, ref bWDT);
            ApplyWDT(17, ref iCnt, ref cbxWDT17, ref bWDT);

            ApplyWDT_Click(chbxCommWDT.Checked, chbxPtoPWDT.Checked, bWDT, true);

            timer1.Enabled = true;
        }

        private void ApplyWDT(int i_iCh, ref int i_iCount, ref CheckBox cbxWDT, ref bool[] i_bWDT)
        {
            if (m_iDiTotal < (i_iCh + 1) && i_iCount < m_iDoTotal)
            {
                i_bWDT[i_iCount] = cbxWDT.Checked;
                i_iCount++;
            }
        }

        private void ApplyWDT_Click(bool bCommFSV, bool bPtoPFSV, bool[] bWDT, bool bShowOk)
        {
            if (adamModbus.DigitalOutput().SetWDTMask(bCommFSV, bPtoPFSV, bWDT))
            {
                if (bShowOk)
                    MessageBox.Show("Set WDT mask done!", "Information");
                RefreshWDT();
            }
            else
                MessageBox.Show("Set WDT mask failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
        }

        private void RefreshWDTCheck(int i_iCh, ref int i_iCount, ref CheckBox cbxWDT, ref bool[] i_bWDT)
        {
            if (m_iDiTotal < (i_iCh + 1) && i_iCount < 8)
            {
                cbxWDT.Checked = i_bWDT[i_iCount];
                i_iCount++;
            }
        }

        private void RefreshWDT()
        {
            int iCnt;
            bool bCommFSV;
            bool bPtoPFSV;
            bool[] bWDT;

            //if (m_Adam6000Type == Adam6000Type.Adam6055) // no DO for 6055
            if (m_iDoTotal == 0)
            {
                btnApplyWDT.Visible = false;
                chbxCommWDT.Visible = false;
                chbxPtoPWDT.Visible = false;
                return;
            }

            if (adamModbus.DigitalOutput().GetWDTMask(out bCommFSV, out bPtoPFSV, out bWDT) && bWDT.Length == 8)
            {
                chbxCommWDT.Checked = bCommFSV;
                chbxPtoPWDT.Checked = bPtoPFSV;
                iCnt = 0;
                RefreshWDTCheck(0, ref iCnt, ref cbxWDT0, ref bWDT);
                RefreshWDTCheck(1, ref iCnt, ref cbxWDT1, ref bWDT);
                RefreshWDTCheck(2, ref iCnt, ref cbxWDT2, ref bWDT);
                RefreshWDTCheck(3, ref iCnt, ref cbxWDT3, ref bWDT);
                RefreshWDTCheck(4, ref iCnt, ref cbxWDT4, ref bWDT);
                RefreshWDTCheck(5, ref iCnt, ref cbxWDT5, ref bWDT);
                RefreshWDTCheck(6, ref iCnt, ref cbxWDT6, ref bWDT);
                RefreshWDTCheck(7, ref iCnt, ref cbxWDT7, ref bWDT);
                RefreshWDTCheck(8, ref iCnt, ref cbxWDT8, ref bWDT);
                RefreshWDTCheck(9, ref iCnt, ref cbxWDT9, ref bWDT);
                RefreshWDTCheck(10, ref iCnt, ref cbxWDT10, ref bWDT);
                RefreshWDTCheck(11, ref iCnt, ref cbxWDT11, ref bWDT);
                RefreshWDTCheck(12, ref iCnt, ref cbxWDT12, ref bWDT);
                RefreshWDTCheck(13, ref iCnt, ref cbxWDT13, ref bWDT);
                RefreshWDTCheck(14, ref iCnt, ref cbxWDT14, ref bWDT);
                RefreshWDTCheck(15, ref iCnt, ref cbxWDT15, ref bWDT);
                RefreshWDTCheck(16, ref iCnt, ref cbxWDT16, ref bWDT);
                RefreshWDTCheck(17, ref iCnt, ref cbxWDT17, ref bWDT);
            }
            else
                MessageBox.Show("GetWDTMask() failed;");
        }

        private void chbxCommWDT_CheckedChanged(object sender, EventArgs e)
        {
            if (chbxCommWDT.Checked && chbxPtoPWDT.Checked)
                chbxPtoPWDT.Checked = false;
        }

        private void chbxPtoPWDT_CheckedChanged(object sender, EventArgs e)
        {
            if (chbxPtoPWDT.Checked && chbxCommWDT.Checked)
                chbxCommWDT.Checked = false;
        }
    }
}
