using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UDPSearch
{
    public partial class FormWait : Form
    {
        private int m_iTime, m_iMilliSec;
        private bool m_infiniteTimer;
        private bool m_stopFlag;
        private int m_counter;
        private const int DIVIDOR = 15;

        public FormWait(int i_iMilliSec)
        {
            InitializeComponent();
            
            m_iTime = 0;
            m_iMilliSec = i_iMilliSec;
        }

        public FormWait(string i_szTitle, string i_szDescription, int i_iMilliSec)
        {
            InitializeComponent();

            m_iTime = 0;
            m_iMilliSec = i_iMilliSec;

            this.Text = i_szTitle;
            labDescription.Text = i_szDescription;
            m_infiniteTimer = false;
            m_stopFlag = false;
            m_counter = 0;
        }

        public FormWait(string i_szTitle, string i_szDescription, bool i_infiniteTimer)
        {
            InitializeComponent();

            m_iTime = 0;
            m_iMilliSec = 30000; //to prevent not calling stop timer function

            this.Text = i_szTitle;
            labDescription.Text = i_szDescription;
            m_stopFlag = false;
            m_counter = 0;
            if (i_infiniteTimer)
                m_infiniteTimer = true;
            else
                m_infiniteTimer = false;
        }

        private void FormWait_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            m_iTime = m_iTime + timer1.Interval;

            if (m_infiniteTimer)
            {
                if ((m_stopFlag) || (m_iTime >= m_iMilliSec))
                {
                    progressBar1.Value = 100;
                    timer1.Enabled = false;
                    this.Close();
                }

                progressBar1.Value = (m_counter * 100) / DIVIDOR;
                if (m_counter >= DIVIDOR)
                    m_counter = 0;
                else
                    m_counter++;
            }
            else
            { 
                if (m_iTime >= m_iMilliSec)
                {
                    progressBar1.Value = 100;
                    timer1.Enabled = false;
                    this.Close();
                }
                progressBar1.Value = m_iTime * 100 / m_iMilliSec;
            }
        }

        public bool StopFlag
        {
            get
            {
                return this.m_stopFlag;
            }
            set
            {
                this.m_stopFlag = value;
            }
        }

    }
}