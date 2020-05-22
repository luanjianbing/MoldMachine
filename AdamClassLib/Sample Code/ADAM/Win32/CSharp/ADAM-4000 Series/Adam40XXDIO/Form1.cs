﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Advantech.Adam;
using Advantech.Common;

namespace Adam40XXDIO
{
    public partial class Form1 : Form
    {
        private int m_iCom, m_iAddr, m_iCount, m_iDITotal, m_iDOTotal;
        private bool m_bStart;
        private Adam4000Config m_adamConfig;
        private Adam4000Type m_Adam4000Type;
        private AdamCom adamCom;

        public Form1()
        {
            InitializeComponent();

            m_iCom = 8;		// using COM4
			m_iAddr = 1;	// the slave address is 1
			m_iCount = 0;	// the counting start from 0
			m_bStart = false;
			//m_Adam4000Type = Adam4000Type.Adam4050; // the sample is for ADAM-4050
			//m_Adam4000Type = Adam4000Type.Adam4051; // the sample is for ADAM-4051
			//m_Adam4000Type = Adam4000Type.Adam4052; // the sample is for ADAM-4052
			//m_Adam4000Type = Adam4000Type.Adam4053; // the sample is for ADAM-4053
			//m_Adam4000Type = Adam4000Type.Adam4055; // the sample is for ADAM-4055
			//m_Adam4000Type = Adam4000Type.Adam4056S; // the sample is for ADAM-4056S
			//m_Adam4000Type = Adam4000Type.Adam4056SO; // the sample is for ADAM-4056SO
			m_Adam4000Type = Adam4000Type.Adam4060; // the sample is for ADAM-4060
			//m_Adam4000Type = Adam4000Type.Adam4068; // the sample is for ADAM-4068
			//m_Adam4000Type = Adam4000Type.Adam4069; // the sample is for ADAM-4069

			m_iDITotal = DigitalInput.GetChannelTotal(m_Adam4000Type);
			m_iDOTotal = DigitalOutput.GetChannelTotal(m_Adam4000Type);
			if (m_Adam4000Type == Adam4000Type.Adam4050)
				InitAdam4050();
			else if (m_Adam4000Type == Adam4000Type.Adam4051)
				InitAdam4051();
			else if (m_Adam4000Type == Adam4000Type.Adam4052)
				InitAdam4052();
			else if (m_Adam4000Type == Adam4000Type.Adam4053)
				InitAdam4053();
			else if (m_Adam4000Type == Adam4000Type.Adam4055)
				InitAdam4055();
			else if (m_Adam4000Type == Adam4000Type.Adam4056S)
				InitAdam4056S();
			else if (m_Adam4000Type == Adam4000Type.Adam4056SO)
				InitAdam4056SO();
			else if (m_Adam4000Type == Adam4000Type.Adam4060)
				InitAdam4060();
			else if (m_Adam4000Type == Adam4000Type.Adam4068)
				InitAdam4068();
			else if (m_Adam4000Type == Adam4000Type.Adam4069)
				InitAdam4069();
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
                panelDIO.Enabled = false;
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
                    adamCom.SetComPortTimeout(500, 1000, 0, 1000, 0);
                    m_iCount = 0; // reset the reading counter
                    // get module config
                    if (!adamCom.Configuration(m_iAddr).GetModuleConfig(out m_adamConfig))
                    {
                        adamCom.CloseComPort();
                        MessageBox.Show("Failed to get module config!", "Error");
                        return;
                    }
                    //
                    panelDIO.Enabled = true;
                    timer1.Enabled = true; // enable timer
                    buttonStart.Text = "Stop";
                    m_bStart = true; // starting flag
                }
                else
                    MessageBox.Show("Failed to open COM port!", "Error");
            }
        }

        private void InitChannelItems(bool i_bVisable, bool i_bIsDI, ref int i_iCh, ref int i_iDI, ref int i_iDO, ref Panel panelCh, ref Button btnCh)
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
                    i_iDO++;
                }
            }
            else
                panelCh.Visible = false;
        }

        private void InitAdam4050()
        {
            int iCh = -1, iDI = 0, iDO = 0;

            InitChannelItems(true, true, ref iCh, ref iDI, ref iDO, ref panelCh0, ref btnCh0);
            InitChannelItems(true, true, ref iCh, ref iDI, ref iDO, ref panelCh1, ref btnCh1);
            InitChannelItems(true, true, ref iCh, ref iDI, ref iDO, ref panelCh2, ref btnCh2);
            InitChannelItems(true, true, ref iCh, ref iDI, ref iDO, ref panelCh3, ref btnCh3);
            InitChannelItems(true, true, ref iCh, ref iDI, ref iDO, ref panelCh4, ref btnCh4);
            InitChannelItems(true, true, ref iCh, ref iDI, ref iDO, ref panelCh5, ref btnCh5);
            InitChannelItems(true, true, ref iCh, ref iDI, ref iDO, ref panelCh6, ref btnCh6);
            InitChannelItems(false, true, ref iCh, ref iDI, ref iDO, ref panelCh7, ref btnCh7);
            //
            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh8, ref btnCh8);
            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh9, ref btnCh9);
            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh10, ref btnCh10);
            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh11, ref btnCh11);
            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh12, ref btnCh12);
            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh13, ref btnCh13);
            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh14, ref btnCh14);
            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh15, ref btnCh15);
        }

        private void InitAdam4051()
        {
            int iCh = -1, iDI = 0, iDO = 0;

            InitChannelItems(true, true, ref iCh, ref iDI, ref iDO, ref panelCh0, ref btnCh0);
            InitChannelItems(true, true, ref iCh, ref iDI, ref iDO, ref panelCh1, ref btnCh1);
            InitChannelItems(true, true, ref iCh, ref iDI, ref iDO, ref panelCh2, ref btnCh2);
            InitChannelItems(true, true, ref iCh, ref iDI, ref iDO, ref panelCh3, ref btnCh3);
            InitChannelItems(true, true, ref iCh, ref iDI, ref iDO, ref panelCh4, ref btnCh4);
            InitChannelItems(true, true, ref iCh, ref iDI, ref iDO, ref panelCh5, ref btnCh5);
            InitChannelItems(true, true, ref iCh, ref iDI, ref iDO, ref panelCh6, ref btnCh6);
            InitChannelItems(true, true, ref iCh, ref iDI, ref iDO, ref panelCh7, ref btnCh7);
            //
            InitChannelItems(true, true, ref iCh, ref iDI, ref iDO, ref panelCh8, ref btnCh8);
            InitChannelItems(true, true, ref iCh, ref iDI, ref iDO, ref panelCh9, ref btnCh9);
            InitChannelItems(true, true, ref iCh, ref iDI, ref iDO, ref panelCh10, ref btnCh10);
            InitChannelItems(true, true, ref iCh, ref iDI, ref iDO, ref panelCh11, ref btnCh11);
            InitChannelItems(true, true, ref iCh, ref iDI, ref iDO, ref panelCh12, ref btnCh12);
            InitChannelItems(true, true, ref iCh, ref iDI, ref iDO, ref panelCh13, ref btnCh13);
            InitChannelItems(true, true, ref iCh, ref iDI, ref iDO, ref panelCh14, ref btnCh14);
            InitChannelItems(true, true, ref iCh, ref iDI, ref iDO, ref panelCh15, ref btnCh15);
        }

        private void InitAdam4052()
        {
            int iCh = -1, iDI = 0, iDO = 0;

            InitChannelItems(true, true, ref iCh, ref iDI, ref iDO, ref panelCh0, ref btnCh0);
            InitChannelItems(true, true, ref iCh, ref iDI, ref iDO, ref panelCh1, ref btnCh1);
            InitChannelItems(true, true, ref iCh, ref iDI, ref iDO, ref panelCh2, ref btnCh2);
            InitChannelItems(true, true, ref iCh, ref iDI, ref iDO, ref panelCh3, ref btnCh3);
            InitChannelItems(true, true, ref iCh, ref iDI, ref iDO, ref panelCh4, ref btnCh4);
            InitChannelItems(true, true, ref iCh, ref iDI, ref iDO, ref panelCh5, ref btnCh5);
            InitChannelItems(true, true, ref iCh, ref iDI, ref iDO, ref panelCh6, ref btnCh6);
            InitChannelItems(true, true, ref iCh, ref iDI, ref iDO, ref panelCh7, ref btnCh7);
            //
            InitChannelItems(false, true, ref iCh, ref iDI, ref iDO, ref panelCh8, ref btnCh8);
            InitChannelItems(false, true, ref iCh, ref iDI, ref iDO, ref panelCh9, ref btnCh9);
            InitChannelItems(false, true, ref iCh, ref iDI, ref iDO, ref panelCh10, ref btnCh10);
            InitChannelItems(false, true, ref iCh, ref iDI, ref iDO, ref panelCh11, ref btnCh11);
            InitChannelItems(false, true, ref iCh, ref iDI, ref iDO, ref panelCh12, ref btnCh12);
            InitChannelItems(false, true, ref iCh, ref iDI, ref iDO, ref panelCh13, ref btnCh13);
            InitChannelItems(false, true, ref iCh, ref iDI, ref iDO, ref panelCh14, ref btnCh14);
            InitChannelItems(false, true, ref iCh, ref iDI, ref iDO, ref panelCh15, ref btnCh15);
        }

        private void InitAdam4053()
        {
            int iCh = -1, iDI = 0, iDO = 0;

            InitChannelItems(true, true, ref iCh, ref iDI, ref iDO, ref panelCh0, ref btnCh0);
            InitChannelItems(true, true, ref iCh, ref iDI, ref iDO, ref panelCh1, ref btnCh1);
            InitChannelItems(true, true, ref iCh, ref iDI, ref iDO, ref panelCh2, ref btnCh2);
            InitChannelItems(true, true, ref iCh, ref iDI, ref iDO, ref panelCh3, ref btnCh3);
            InitChannelItems(true, true, ref iCh, ref iDI, ref iDO, ref panelCh4, ref btnCh4);
            InitChannelItems(true, true, ref iCh, ref iDI, ref iDO, ref panelCh5, ref btnCh5);
            InitChannelItems(true, true, ref iCh, ref iDI, ref iDO, ref panelCh6, ref btnCh6);
            InitChannelItems(true, true, ref iCh, ref iDI, ref iDO, ref panelCh7, ref btnCh7);
            //
            InitChannelItems(true, true, ref iCh, ref iDI, ref iDO, ref panelCh8, ref btnCh8);
            InitChannelItems(true, true, ref iCh, ref iDI, ref iDO, ref panelCh9, ref btnCh9);
            InitChannelItems(true, true, ref iCh, ref iDI, ref iDO, ref panelCh10, ref btnCh10);
            InitChannelItems(true, true, ref iCh, ref iDI, ref iDO, ref panelCh11, ref btnCh11);
            InitChannelItems(true, true, ref iCh, ref iDI, ref iDO, ref panelCh12, ref btnCh12);
            InitChannelItems(true, true, ref iCh, ref iDI, ref iDO, ref panelCh13, ref btnCh13);
            InitChannelItems(true, true, ref iCh, ref iDI, ref iDO, ref panelCh14, ref btnCh14);
            InitChannelItems(true, true, ref iCh, ref iDI, ref iDO, ref panelCh15, ref btnCh15);
        }

        private void InitAdam4055()
        {
            int iCh = -1, iDI = 0, iDO = 0;

            InitChannelItems(true, true, ref iCh, ref iDI, ref iDO, ref panelCh0, ref btnCh0);
            InitChannelItems(true, true, ref iCh, ref iDI, ref iDO, ref panelCh1, ref btnCh1);
            InitChannelItems(true, true, ref iCh, ref iDI, ref iDO, ref panelCh2, ref btnCh2);
            InitChannelItems(true, true, ref iCh, ref iDI, ref iDO, ref panelCh3, ref btnCh3);
            InitChannelItems(true, true, ref iCh, ref iDI, ref iDO, ref panelCh4, ref btnCh4);
            InitChannelItems(true, true, ref iCh, ref iDI, ref iDO, ref panelCh5, ref btnCh5);
            InitChannelItems(true, true, ref iCh, ref iDI, ref iDO, ref panelCh6, ref btnCh6);
            InitChannelItems(true, true, ref iCh, ref iDI, ref iDO, ref panelCh7, ref btnCh7);
            //
            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh8, ref btnCh8);
            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh9, ref btnCh9);
            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh10, ref btnCh10);
            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh11, ref btnCh11);
            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh12, ref btnCh12);
            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh13, ref btnCh13);
            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh14, ref btnCh14);
            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh15, ref btnCh15);
        }

        private void InitAdam4056S()
        {
            int iCh = -1, iDI = 0, iDO = 0;

            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh0, ref btnCh0);
            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh1, ref btnCh1);
            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh2, ref btnCh2);
            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh3, ref btnCh3);
            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh4, ref btnCh4);
            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh5, ref btnCh5);
            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh6, ref btnCh6);
            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh7, ref btnCh7);
            //
            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh8, ref btnCh8);
            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh9, ref btnCh9);
            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh10, ref btnCh10);
            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh11, ref btnCh11);
            InitChannelItems(false, false, ref iCh, ref iDI, ref iDO, ref panelCh12, ref btnCh12);
            InitChannelItems(false, false, ref iCh, ref iDI, ref iDO, ref panelCh13, ref btnCh13);
            InitChannelItems(false, false, ref iCh, ref iDI, ref iDO, ref panelCh14, ref btnCh14);
            InitChannelItems(false, false, ref iCh, ref iDI, ref iDO, ref panelCh15, ref btnCh15);
        }

        private void InitAdam4056SO()
        {
            int iCh = -1, iDI = 0, iDO = 0;

            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh0, ref btnCh0);
            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh1, ref btnCh1);
            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh2, ref btnCh2);
            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh3, ref btnCh3);
            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh4, ref btnCh4);
            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh5, ref btnCh5);
            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh6, ref btnCh6);
            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh7, ref btnCh7);
            //
            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh8, ref btnCh8);
            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh9, ref btnCh9);
            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh10, ref btnCh10);
            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh11, ref btnCh11);
            InitChannelItems(false, false, ref iCh, ref iDI, ref iDO, ref panelCh12, ref btnCh12);
            InitChannelItems(false, false, ref iCh, ref iDI, ref iDO, ref panelCh13, ref btnCh13);
            InitChannelItems(false, false, ref iCh, ref iDI, ref iDO, ref panelCh14, ref btnCh14);
            InitChannelItems(false, false, ref iCh, ref iDI, ref iDO, ref panelCh15, ref btnCh15);
        }

        private void InitAdam4060()
        {
            int iCh = -1, iDI = 0, iDO = 0;

            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh0, ref btnCh0);
            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh1, ref btnCh1);
            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh2, ref btnCh2);
            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh3, ref btnCh3);
            InitChannelItems(false, false, ref iCh, ref iDI, ref iDO, ref panelCh4, ref btnCh4);
            InitChannelItems(false, false, ref iCh, ref iDI, ref iDO, ref panelCh5, ref btnCh5);
            InitChannelItems(false, false, ref iCh, ref iDI, ref iDO, ref panelCh6, ref btnCh6);
            InitChannelItems(false, false, ref iCh, ref iDI, ref iDO, ref panelCh7, ref btnCh7);
            //
            InitChannelItems(false, false, ref iCh, ref iDI, ref iDO, ref panelCh8, ref btnCh8);
            InitChannelItems(false, false, ref iCh, ref iDI, ref iDO, ref panelCh9, ref btnCh9);
            InitChannelItems(false, false, ref iCh, ref iDI, ref iDO, ref panelCh10, ref btnCh10);
            InitChannelItems(false, false, ref iCh, ref iDI, ref iDO, ref panelCh11, ref btnCh11);
            InitChannelItems(false, false, ref iCh, ref iDI, ref iDO, ref panelCh12, ref btnCh12);
            InitChannelItems(false, false, ref iCh, ref iDI, ref iDO, ref panelCh13, ref btnCh13);
            InitChannelItems(false, false, ref iCh, ref iDI, ref iDO, ref panelCh14, ref btnCh14);
            InitChannelItems(false, false, ref iCh, ref iDI, ref iDO, ref panelCh15, ref btnCh15);
        }

        private void InitAdam4068()
        {
            int iCh = -1, iDI = 0, iDO = 0;

            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh0, ref btnCh0);
            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh1, ref btnCh1);
            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh2, ref btnCh2);
            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh3, ref btnCh3);
            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh4, ref btnCh4);
            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh5, ref btnCh5);
            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh6, ref btnCh6);
            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh7, ref btnCh7);
            //
            InitChannelItems(false, false, ref iCh, ref iDI, ref iDO, ref panelCh8, ref btnCh8);
            InitChannelItems(false, false, ref iCh, ref iDI, ref iDO, ref panelCh9, ref btnCh9);
            InitChannelItems(false, false, ref iCh, ref iDI, ref iDO, ref panelCh10, ref btnCh10);
            InitChannelItems(false, false, ref iCh, ref iDI, ref iDO, ref panelCh11, ref btnCh11);
            InitChannelItems(false, false, ref iCh, ref iDI, ref iDO, ref panelCh12, ref btnCh12);
            InitChannelItems(false, false, ref iCh, ref iDI, ref iDO, ref panelCh13, ref btnCh13);
            InitChannelItems(false, false, ref iCh, ref iDI, ref iDO, ref panelCh14, ref btnCh14);
            InitChannelItems(false, false, ref iCh, ref iDI, ref iDO, ref panelCh15, ref btnCh15);
        }

        private void InitAdam4069()
        {
            int iCh = -1, iDI = 0, iDO = 0;

            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh0, ref btnCh0);
            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh1, ref btnCh1);
            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh2, ref btnCh2);
            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh3, ref btnCh3);
            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh4, ref btnCh4);
            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh5, ref btnCh5);
            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh6, ref btnCh6);
            InitChannelItems(true, false, ref iCh, ref iDI, ref iDO, ref panelCh7, ref btnCh7);
            //
            InitChannelItems(false, false, ref iCh, ref iDI, ref iDO, ref panelCh8, ref btnCh8);
            InitChannelItems(false, false, ref iCh, ref iDI, ref iDO, ref panelCh9, ref btnCh9);
            InitChannelItems(false, false, ref iCh, ref iDI, ref iDO, ref panelCh10, ref btnCh10);
            InitChannelItems(false, false, ref iCh, ref iDI, ref iDO, ref panelCh11, ref btnCh11);
            InitChannelItems(false, false, ref iCh, ref iDI, ref iDO, ref panelCh12, ref btnCh12);
            InitChannelItems(false, false, ref iCh, ref iDI, ref iDO, ref panelCh13, ref btnCh13);
            InitChannelItems(false, false, ref iCh, ref iDI, ref iDO, ref panelCh14, ref btnCh14);
            InitChannelItems(false, false, ref iCh, ref iDI, ref iDO, ref panelCh15, ref btnCh15);
        }

        private void RefresDIO()
        {
            bool[] bDI, bDO;

            if (adamCom.DigitalInput(m_iAddr).GetValues(m_iDITotal, m_iDOTotal, out bDI, out bDO))
            {
                if (m_iDITotal > 0)
                {
                    if (m_iDOTotal > 0) // DI > 0, DO > 0
                    {
                        if (m_iDITotal > 0)
                            txtCh0.Text = bDI[0].ToString();
                        if (m_iDITotal > 1)
                            txtCh1.Text = bDI[1].ToString();
                        if (m_iDITotal > 2)
                            txtCh2.Text = bDI[2].ToString();
                        if (m_iDITotal > 3)
                            txtCh3.Text = bDI[3].ToString();
                        if (m_iDITotal > 4)
                            txtCh4.Text = bDI[4].ToString();
                        if (m_iDITotal > 5)
                            txtCh5.Text = bDI[5].ToString();
                        if (m_iDITotal > 6)
                            txtCh6.Text = bDI[6].ToString();
                        if (m_iDITotal > 7)
                            txtCh7.Text = bDI[7].ToString();
                        //
                        if (m_iDOTotal > 0)
                            txtCh8.Text = bDO[0].ToString();
                        if (m_iDOTotal > 1)
                            txtCh9.Text = bDO[1].ToString();
                        if (m_iDOTotal > 2)
                            txtCh10.Text = bDO[2].ToString();
                        if (m_iDOTotal > 3)
                            txtCh11.Text = bDO[3].ToString();
                        if (m_iDOTotal > 4)
                            txtCh12.Text = bDO[4].ToString();
                        if (m_iDOTotal > 5)
                            txtCh13.Text = bDO[5].ToString();
                        if (m_iDOTotal > 6)
                            txtCh14.Text = bDO[6].ToString();
                        if (m_iDOTotal > 7)
                            txtCh15.Text = bDO[7].ToString();
                    }
                    else // DI > 0, DO = 0 
                    {
                        if (m_iDITotal > 0)
                            txtCh0.Text = bDI[0].ToString();
                        if (m_iDITotal > 1)
                            txtCh1.Text = bDI[1].ToString();
                        if (m_iDITotal > 2)
                            txtCh2.Text = bDI[2].ToString();
                        if (m_iDITotal > 3)
                            txtCh3.Text = bDI[3].ToString();
                        if (m_iDITotal > 4)
                            txtCh4.Text = bDI[4].ToString();
                        if (m_iDITotal > 5)
                            txtCh5.Text = bDI[5].ToString();
                        if (m_iDITotal > 6)
                            txtCh6.Text = bDI[6].ToString();
                        if (m_iDITotal > 7)
                            txtCh7.Text = bDI[7].ToString();
                        if (m_iDITotal > 8)
                            txtCh8.Text = bDI[8].ToString();
                        if (m_iDITotal > 9)
                            txtCh9.Text = bDI[9].ToString();
                        if (m_iDITotal > 10)
                            txtCh10.Text = bDI[10].ToString();
                        if (m_iDITotal > 11)
                            txtCh11.Text = bDI[11].ToString();
                        if (m_iDITotal > 12)
                            txtCh12.Text = bDI[12].ToString();
                        if (m_iDITotal > 13)
                            txtCh13.Text = bDI[13].ToString();
                        if (m_iDITotal > 14)
                            txtCh14.Text = bDI[14].ToString();
                        if (m_iDITotal > 15)
                            txtCh15.Text = bDI[15].ToString();
                    }
                }
                else // DI = 0, DO > 0
                {
                    if (m_iDOTotal > 0)
                        txtCh0.Text = bDO[0].ToString();
                    if (m_iDOTotal > 1)
                        txtCh1.Text = bDO[1].ToString();
                    if (m_iDOTotal > 2)
                        txtCh2.Text = bDO[2].ToString();
                    if (m_iDOTotal > 3)
                        txtCh3.Text = bDO[3].ToString();
                    if (m_iDOTotal > 4)
                        txtCh4.Text = bDO[4].ToString();
                    if (m_iDOTotal > 5)
                        txtCh5.Text = bDO[5].ToString();
                    if (m_iDOTotal > 6)
                        txtCh6.Text = bDO[6].ToString();
                    if (m_iDOTotal > 7)
                        txtCh7.Text = bDO[7].ToString();
                    if (m_iDOTotal > 8)
                        txtCh8.Text = bDO[8].ToString();
                    if (m_iDOTotal > 9)
                        txtCh9.Text = bDO[9].ToString();
                    if (m_iDOTotal > 10)
                        txtCh10.Text = bDO[10].ToString();
                    if (m_iDOTotal > 11)
                        txtCh11.Text = bDO[11].ToString();
                    if (m_iDOTotal > 12)
                        txtCh12.Text = bDO[12].ToString();
                    if (m_iDOTotal > 13)
                        txtCh13.Text = bDO[13].ToString();
                    if (m_iDOTotal > 14)
                        txtCh14.Text = bDO[14].ToString();
                    if (m_iDOTotal > 15)
                        txtCh15.Text = bDO[15].ToString();
                }
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
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            m_iCount++;
            txtReadCount.Text = "Polling " + m_iCount.ToString() + " times...";
            RefresDIO();
        }

        private void btn_Click(int i_iCh, TextBox txtBox)
        {
            bool bRet;
            timer1.Enabled = false;
            if (m_iDITotal > 0)
                i_iCh = i_iCh - 8;
            if (m_iDOTotal > 8) // ADAM-4056S, ADAM-4056SO
                bRet = adamCom.DigitalOutput(m_iAddr).SetSValue(i_iCh, (txtBox.Text == "False"));
            else
                bRet = adamCom.DigitalOutput(m_iAddr).SetValue(i_iCh, (txtBox.Text == "False"));
            if (!bRet)
                MessageBox.Show("Set digital output failed!", "Error");
            timer1.Enabled = true;
        }

        private void btnChannel_Click(object sender, EventArgs e)
        {
            string tempName = ((Button)sender).Name.ToString();
            if (tempName.Length == 6)
                tempName = tempName.Substring(5, 1);
            else
                tempName = tempName.Substring(5, 2);

            btn_Click(Convert.ToInt32(tempName), (TextBox)(this.Controls.Find("txtCh" + tempName, true)[0]) );
        }
    }
}
