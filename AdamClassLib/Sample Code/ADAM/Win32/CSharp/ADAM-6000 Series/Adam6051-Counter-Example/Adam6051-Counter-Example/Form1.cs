using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using Advantech.Adam;

namespace Adam6051_Counter_Example
{
    public partial class Form1 : Form
    {
        private bool m_bStart;
        private AdamSocket m_adamUDP; //UDP protocol to config module 
        private AdamSocket m_adamModbus; //Modbus TCP for real data access and config module 
        private Adam6000Type m_Adam6000Type;
        private string m_szIP;
        private int m_iPort;
        private int m_iCount;
        private int m_iDoTotal, m_iDiTotal, m_iCntTotal;
        private int m_iCh;
        private bool[] m_bRecordLastCount;
        private bool[] m_bDigitalFilter;
        private bool[] m_bInvert;
        private byte[] m_byMode;
        private byte[] m_byConfig;
        private long[] m_lHigh, m_lLow;

        public Form1()
        {
            InitializeComponent();

            m_bStart = false;			                                      // the action stops at the beginning
            m_szIP = "10.0.0.1";                                       	  // modbus slave IP address
            m_iPort = 502;				                                      // modbus TCP port is 502
            m_adamModbus = new AdamSocket();
            m_adamModbus.SetTimeout(1000, 1000, 1000);  // set timeout for TCP

            m_Adam6000Type = Adam6000Type.Adam6051; // the sample is for ADAM-6051

            InitAdam6051();
            SetModeItem();
            btnEnableDisable(false);
            txtModule.Text = m_Adam6000Type.ToString();
        }

        protected void InitChannelItems(bool i_bVisable, bool i_bIsDI, ref int i_iDI, ref int i_iDO, ref Panel panelCh, ref Button btnCh)
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

        protected void InitAdam6051()
        {
            int iDI = 0, iDO = 0;

            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh0, ref btnCh0);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh1, ref btnCh1);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh2, ref btnCh2);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh3, ref btnCh3);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh4, ref btnCh4);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh5, ref btnCh5);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh6, ref btnCh6);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh7, ref btnCh7);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh8, ref btnCh8);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh9, ref btnCh9);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh10, ref btnCh10);
            InitChannelItems(true, true, ref iDI, ref iDO, ref panelCh11, ref btnCh11);
            InitChannelItems(true, false, ref iDI, ref iDO, ref panelCh12, ref btnCh12);
            InitChannelItems(true, false, ref iDI, ref iDO, ref panelCh13, ref btnCh13);
            InitChannelItems(false, true, ref iDI, ref iDO, ref panelCh14, ref btnCh14);
            InitChannelItems(false, true, ref iDI, ref iDO, ref panelCh15, ref btnCh15);
            InitChannelItems(false, true, ref iDI, ref iDO, ref panelCh16, ref btnCh16);
            InitChannelItems(false, true, ref iDI, ref iDO, ref panelCh17, ref btnCh17);

            panelCounter.Visible = true;

            m_iDiTotal = 12;
            m_iDoTotal = 6;
            m_iCntTotal = Counter.GetChannelTotal(Adam6000Type.Adam6051);
            m_byMode = new byte[m_iCntTotal];
            m_bRecordLastCount = new bool[m_iCntTotal];
            m_bDigitalFilter = new bool[m_iCntTotal];
            m_bInvert = new bool[m_iCntTotal];
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_bStart)
            {
                timer1.Enabled = false;
                CounterStartStop((object)this.btnCounterStartCh1, false);
                CounterStartStop((object)this.btnCounterStartCh2, false);
                m_adamModbus.Disconnect(); // disconnect slave
            }

            if (m_adamUDP != null)
            {
                m_adamUDP.Disconnect();
                m_adamUDP = null;
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (m_bStart) // was started
            {
                btnEnableDisable(false);
                panelDIO.Enabled = false;
                panelDiMode.Enabled = false;
                panelSetting.Enabled = false;
                m_bStart = false;		// starting flag
                timer1.Enabled = false; // disable timer
                m_adamModbus.Disconnect(); // disconnect slave
                buttonStart.Text = "Start";
            }
            else	// was stoped
            {
                if (m_adamModbus.Connect(m_szIP, ProtocolType.Tcp, m_iPort))
                {
                    m_adamUDP = new AdamSocket();
                    m_adamUDP.Connect(AdamType.Adam6000, m_szIP, ProtocolType.Udp);

                    btnEnableDisable(true);
                    panelDIO.Enabled = true;
                    panelDiMode.Enabled = true;
                    panelSetting.Enabled = true;
                    m_iCount = 0; // reset the reading counter

                    comboBoxCh.SelectedIndex = 1; //will trig RefreshChannelMode();
                    RefreshPanel();
                    if (m_byMode[comboBoxCh.SelectedIndex] == (byte)Adam6051_CounterMode.Counter)
                        CounterStartStop((object)this.btnCounterStartCh2, true);

                    comboBoxCh.SelectedIndex = 0; //will trig RefreshChannelMode();
                    RefreshPanel();
                    if (m_byMode[comboBoxCh.SelectedIndex] == (byte)Adam6051_CounterMode.Counter)
                        CounterStartStop((object)this.btnCounterStartCh1, true);

                    m_bStart = true; // starting flag                
                    timer1.Enabled = true; // enable timer
                    buttonStart.Text = "Stop";
                }
                else
                    MessageBox.Show("Connect to " + m_szIP + " failed", "Error");
            }
        }

        private void RefreshDIO()
        {
            int iDiStart = 1, iDoStart = 17;
            int iChTotal;
            int iIdx;
            int iConfigStart;
            bool[] bDiData, bDoData, bData;
            byte[] byConfig;

            if (m_adamModbus.DigitalInput().GetIOConfig(out byConfig))
            {
                // counter

                iConfigStart = Counter.GetChannelStart(m_Adam6000Type);

                for (iIdx = 0; iIdx < m_iCntTotal; iIdx++)
                {
                    Counter.ParseIOConfig(byConfig[iConfigStart + iIdx], out m_byMode[iIdx],
                        out m_bRecordLastCount[iIdx], out m_bDigitalFilter[iIdx], out m_bInvert[iIdx]);
                }
            }

            if (m_adamModbus.Modbus().ReadCoilStatus(iDiStart, m_iDiTotal, out bDiData) &&
                m_adamModbus.Modbus().ReadCoilStatus(iDoStart, m_iDoTotal, out bDoData))
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

            if (m_Adam6000Type == Adam6000Type.Adam6051)
            {
                RefreshCounterValue();
            }
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
            if (m_adamModbus.Modbus().ForceSingleCoil(iStart, iOnOff))
                RefreshDIO();
            else
                MessageBox.Show("Set digital output failed!", "Error");
            timer1.Enabled = true;
        }

        private bool RefreshCounterValue()
        {
            int iCntStart = 25, iChTotal = 2; // for 6051, 12 DI, 2 counter, each counter uses 2 registers

            int[] iData;
            double fValue;

            if (m_adamModbus.Modbus().ReadInputRegs(iCntStart, iChTotal * 2, out iData))
            {
                fValue = Counter.GetScaledValue(m_Adam6000Type, m_byMode[0], iData[1], iData[0]);
                txtCntValue0.Text = fValue.ToString(Counter.GetFormat(m_Adam6000Type, m_byMode[0])) + " " +
                    Counter.GetUnitName(m_Adam6000Type, m_byMode[0]);
                fValue = Counter.GetScaledValue(m_Adam6000Type, m_byMode[1], iData[3], iData[2]);
                txtCntValue1.Text = fValue.ToString(Counter.GetFormat(m_Adam6000Type, m_byMode[1])) + " " +
                    Counter.GetUnitName(m_Adam6000Type, m_byMode[1]);
                return true;
            }
            return false;
        }

        private void SetModeItem()
        {
            cbxDiMode.Items.Add("Counter");
            cbxDiMode.Items.Add("Frequency");
        }

        private void RefreshChannelMode()
        {
            int iConfigStart;

            if (m_adamUDP.DigitalInput().GetIOConfig(out m_byConfig))
            {
                iConfigStart = Counter.GetChannelStart(m_Adam6000Type);
                Counter.ParseIOConfig(m_byConfig[iConfigStart + comboBoxCh.SelectedIndex], out m_byMode[comboBoxCh.SelectedIndex],
                    out m_bRecordLastCount[comboBoxCh.SelectedIndex], out m_bDigitalFilter[comboBoxCh.SelectedIndex], out m_bInvert[comboBoxCh.SelectedIndex]);
            }
            else
            {
                MessageBox.Show("GetIOConfig() failed;");
            }
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

        private void btnCounterStartCh1_Click(object sender, EventArgs e)
        {
            if (btnCounterStartCh1.Text == "Start")
                CounterStartStop(sender, true);
            else
                CounterStartStop(sender, false);
        }

        private void btnCounterStartCh2_Click(object sender, EventArgs e)
        {
            if (btnCounterStartCh2.Text == "Start")
                CounterStartStop(sender, true);
            else
                CounterStartStop(sender, false);
        }

        private void CounterStartStop(object sender, bool bFlag)
        {
            int iData, iStart;
            int iConfigStart;

            if (m_bStart)
            {
                timer1.Enabled = false;

                if (((Button)sender).Name == "btnCounterStartCh1")
                {
                    if (bFlag)
                        iData = 1;
                    else
                        iData = 0;

                    m_iCh = 0;

                    iConfigStart = Counter.GetChannelStart(m_Adam6000Type);
                    iStart = 32 + (iConfigStart + m_iCh) * 4 + 1;
                    if (m_adamModbus.Modbus().ForceSingleCoil(iStart, iData))
                    {
                        RefreshCounterValue();
                        if (bFlag)
                            btnCounterStartCh1.Text = "Stop";
                        else
                            btnCounterStartCh1.Text = "Start";
                    }
                    else
                        MessageBox.Show("ForceSingleCoil() failed;");

                }
                else //"btnCounterStartCh2"
                {
                    if (bFlag)
                        iData = 1;
                    else
                        iData = 0;

                    m_iCh = 1;

                    iConfigStart = Counter.GetChannelStart(m_Adam6000Type);
                    iStart = 32 + (iConfigStart + m_iCh) * 4 + 1;
                    if (m_adamModbus.Modbus().ForceSingleCoil(iStart, iData))
                    {
                        RefreshCounterValue();
                        if (bFlag)
                            btnCounterStartCh2.Text = "Stop";
                        else
                            btnCounterStartCh2.Text = "Start";
                    }
                    else
                        MessageBox.Show("ForceSingleCoil() failed;");
                }

                timer1.Enabled = true;
            }
        }

        private void btnEnableDisable(bool bEnable)
        {
            btnCounterStartCh1.Enabled = bEnable;
            btnCounterClearCh1.Enabled = bEnable;
            btnCounterStartCh2.Enabled = bEnable;
            btnCounterClearCh2.Enabled = bEnable;
            btnApplyMode.Enabled = bEnable;
            buttonApplyChange.Enabled = bEnable;
        }

        private void btnCounterClearCh1_Click(object sender, EventArgs e)
        {
            ClearCounter(sender);
        }

        private void btnCounterClearCh2_Click(object sender, EventArgs e)
        {
            ClearCounter(sender);
        }

        private void ClearCounter(object sender)
        {
            int iConfigStart, iStart;
            int iData = 1; //to clear, set as 1

            if (((Button)sender).Name == "btnCounterClearCh1")
            {
                m_iCh = 0;

                iConfigStart = Counter.GetChannelStart(m_Adam6000Type);
                iStart = 32 + (iConfigStart + m_iCh) * 4 + 2;
                if (m_adamModbus.Modbus().ForceSingleCoil(iStart, iData))
                    RefreshCounterValue();
                else
                    MessageBox.Show("ForceSingleCoil() failed;");

            }
            else
            {
                m_iCh = 1;

                iConfigStart = Counter.GetChannelStart(m_Adam6000Type);
                iStart = 32 + (iConfigStart + m_iCh) * 4 + 2;
                if (m_adamModbus.Modbus().ForceSingleCoil(iStart, iData))
                    RefreshCounterValue();
                else
                    MessageBox.Show("ForceSingleCoil() failed;");
            }
        }

        private void btnApplyMode_Click(object sender, EventArgs e)
        {
            byte byConf, byMode, byPreConf;
            byPreConf = 0x00;

            if (cbxDiMode.SelectedIndex == 0)
                byMode = (byte)Adam6051_CounterMode.Counter;
            else
                byMode = (byte)Adam6051_CounterMode.Frequency;

            int iConfigStart = Counter.GetChannelStart(m_Adam6000Type);
            int chIdx = iConfigStart + comboBoxCh.SelectedIndex;
            Counter.FormIOConfig(byMode, m_bRecordLastCount[comboBoxCh.SelectedIndex], m_bDigitalFilter[comboBoxCh.SelectedIndex], m_bInvert[comboBoxCh.SelectedIndex], out byConf);

            byPreConf = m_byConfig[chIdx];
            m_byConfig[chIdx] = byConf;

            if (m_adamUDP.Counter().SetIOConfig(m_byConfig))
            {
                RefreshChannelMode();
                RefreshPanel();
                RefreshSetting();
                MessageBox.Show("Apply mode setting successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                m_byConfig[iConfigStart + m_iCh] = byPreConf; 
                MessageBox.Show("Change counter mode failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void ApplyChange()
        {

            try
            {
                byte byConf, byPreConf;
                long lHigh, lLow, lPreHigh = 0, lPreLow = 0;

                if (comboBoxCh.SelectedIndex == 0)
                    m_iCh = 0;
                else
                    m_iCh = 1;

                byPreConf = 0x00;
                if (m_byConfig != null)
                {
                    byPreConf = m_byConfig[m_iCh];
                }

                if (m_lHigh != null)
                {
                    lPreHigh = m_lHigh[this.m_iCh];
                }

                if (m_lLow != null)
                {
                    lPreLow = m_lLow[this.m_iCh];
                }

                timer1.Enabled = false;


                int iConfigStart = Counter.GetChannelStart(m_Adam6000Type);
                if (m_byMode[m_iCh] == (byte)Adam6051_CounterMode.Counter)
                {
                    // digital filter
                    if (cbxFilter.Checked)
                    {
                        try
                        {
                            lHigh = Convert.ToInt64(txtCntHigh.Text);
                            lLow = Convert.ToInt64(txtCntLow.Text);
                        }
                        catch
                        {
                            MessageBox.Show("The digital filter signal width is invalid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                            timer1.Enabled = true;
                            return;
                        }


                        lPreHigh = m_lHigh[iConfigStart + m_iCh];
                        lPreLow = m_lLow[iConfigStart + m_iCh];
                        m_lHigh[iConfigStart + m_iCh] = lHigh;
                        m_lLow[iConfigStart + m_iCh] = lLow;

                        if (!m_adamUDP.Counter().SetDigitalFilterMiniSignalWidth(m_lHigh, m_lLow))
                        {
                            MessageBox.Show("Change digital filter signal width failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                            m_lHigh[iConfigStart + m_iCh] = lPreHigh;
                            m_lLow[iConfigStart + m_iCh] = lPreLow;

                            timer1.Enabled = true;
                            return;
                        }

                    }
                    // setting
                    Counter.FormIOConfig(m_byMode[m_iCh], cbxKeepLast.Checked, cbxFilter.Checked, cbxInvert.Checked, out byConf);

                    byPreConf = m_byConfig[iConfigStart + m_iCh];
                    m_byConfig[iConfigStart + m_iCh] = byConf;

                    if (m_adamUDP.Counter().SetIOConfig(m_byConfig))
                    {
                        MessageBox.Show("Apply change setting successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshChannelMode();
                        RefreshModePanel();
                        RefreshSetting();
                    }
                    else
                    {
                        m_byConfig[iConfigStart + m_iCh] = byPreConf;
                        MessageBox.Show("Change DI setting failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    }
                }

                timer1.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to apply setting! (" + ex.Message + ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void buttonApplyChange_Click(object sender, EventArgs e)
        {
            ApplyChange();
        }

        private void comboBoxCh_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshChannelMode();
            RefreshModePanel();
            RefreshSetting();
        }

        private void RefreshModePanel()
        {
            if (m_byMode[comboBoxCh.SelectedIndex] == (byte)Adam6051_CounterMode.Counter)
            {
                cbxDiMode.SelectedIndex = 0;
                panelSetting.Visible = true;
            }
            else
            {
                cbxDiMode.SelectedIndex = 1;
                panelSetting.Visible = false;
            }
        }

        private void RefreshPanel()
        {
            if (m_byMode[comboBoxCh.SelectedIndex] == (byte)Adam6051_CounterMode.Counter)
            {
                if (comboBoxCh.SelectedIndex == 0)
                {
                    btnCounterStartCh1.Enabled = true;
                    btnCounterClearCh1.Enabled = true;
                }
                else
                {
                    btnCounterStartCh2.Enabled = true;
                    btnCounterClearCh2.Enabled = true;
                }
                panelSetting.Visible = true;
            }
            else
            {
                if (comboBoxCh.SelectedIndex == 0)
                {
                    btnCounterStartCh1.Enabled = false;
                    btnCounterClearCh1.Enabled = false;
                }
                else
                {
                    btnCounterStartCh2.Enabled = false;
                    btnCounterClearCh2.Enabled = false;
                }
                panelSetting.Visible = false;
            }
        }

        private void RefreshSetting()
        {
            int iStart;

            if (comboBoxCh.SelectedIndex == 0)
                m_iCh = 0;
            else
                m_iCh = 1;

            cbxInvert.Checked = m_bInvert[m_iCh];
            cbxKeepLast.Checked = m_bRecordLastCount[m_iCh];
            cbxFilter.Checked = m_bDigitalFilter[m_iCh];

            if (cbxFilter.Checked)
            {
                txtCntLow.ReadOnly = false;
                txtCntHigh.ReadOnly = false;
            }
            else
            {
                txtCntLow.ReadOnly = true;
                txtCntHigh.ReadOnly = true;
            }

            if (m_Adam6000Type == Adam6000Type.Adam6051 || m_Adam6000Type == Adam6000Type.Adam6051W)
            {
                if (m_byMode[m_iCh] == (byte)Adam6051_CounterMode.Counter)
                {
                    iStart = Counter.GetChannelStart(m_Adam6000Type);

                    if (m_adamUDP.Counter().GetDigitalFilterMiniSignalWidth(out m_lHigh, out m_lLow) &&
                        (iStart + m_iCh) < m_lHigh.Length)
                    {
                        txtCntLow.Text = m_lLow[iStart + m_iCh].ToString();
                        txtCntHigh.Text = m_lHigh[iStart + m_iCh].ToString();
                    }
                    else
                        MessageBox.Show("GetDigitalFilterMiniSignalWidth() failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                }
            }
        }

        private void cbxFilter_CheckStateChanged(object sender, EventArgs e)
        {
            if (cbxFilter.Checked)
            {
                txtCntLow.ReadOnly = false;
                txtCntHigh.ReadOnly = false;
            }
            else
            {
                txtCntLow.ReadOnly = true;
                txtCntHigh.ReadOnly = true;
            }
        }

    }
}
