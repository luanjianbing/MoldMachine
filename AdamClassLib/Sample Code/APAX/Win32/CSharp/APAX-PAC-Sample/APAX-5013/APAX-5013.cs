using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Advantech.Adam;
using Apax_IO_Module_Library;

namespace APAX_5013
{
    public partial class Form_APAX_5013 : Form
    {
        // Global object
        private string APAX_INFO_NAME = "APAX";
        private string DVICE_TYPE = "5013";

        private AdamControl m_adamCtl;
        private Apax5000Config m_aConf;

        private int m_idxID;
        private int m_ScanTime_LocalSys;
        private int m_iFailCount, m_iScanCount;
        private int m_tmpidx;
        private string[] m_szSlots;// Container of all solt device type

        private bool[] m_bChMask;
        private uint m_uiChMask = 0;
        private uint m_uiBurnoutVal = 0;
        private uint m_uiBurnoutMask = 0;
        private ushort[] m_usRanges;
        private bool m_bStartFlag = false;

        public Form_APAX_5013()
        {
            InitializeComponent();
            m_szSlots = null;
            m_iScanCount = 0;
            m_iFailCount = 0;
            m_bChMask = new bool[AdamControl.APAX_MaxAIOCh];
            m_bStartFlag = false;
            m_idxID = -1; // Set in invalid num 
            m_ScanTime_LocalSys = 500;// Scan time default 500 ms
            timer1.Interval = m_ScanTime_LocalSys;
            this.StatusBar_IO.Text = ("Start to demo "
                        + (APAX_INFO_NAME + ("-"
                        + (DVICE_TYPE + " by clicking \'Start\' button."))));
        }
        public Form_APAX_5013(int SlotNum, int ScanTime)
        {
            InitializeComponent();
            m_szSlots = null;
            m_idxID = SlotNum; // Set Slot_ID
            m_iScanCount = 0;
            m_iFailCount = 0;
            m_bChMask = new bool[AdamControl.APAX_MaxAIOCh];
            m_bStartFlag = false;
            m_ScanTime_LocalSys = ScanTime;// Scan time
            timer1.Interval = m_ScanTime_LocalSys;
            this.StatusBar_IO.Text = ("Start to demo "
                        + (APAX_INFO_NAME + ("-"
                        + (DVICE_TYPE + " by clicking \'Start\' button."))));
        }
        /// <summary>
        /// Used for change I/O module 
        /// </summary>
        /// <returns></returns>
        public bool FreeResource()
        {
            if (m_bStartFlag)
            {
                m_bStartFlag = false;
                this.tabControl1.Enabled = false;
                this.tabControl1.Visible = false;
                timer1.Enabled = false;

                m_adamCtl.Configuration().SYS_SetLocateModule(m_idxID, 0);
                m_adamCtl = null;
            }
            return true;
        }
        public bool OpenDevice()
        {
            m_adamCtl = new AdamControl(AdamType.Apax5000);
            if (m_adamCtl.OpenDevice())
            {
                if (!m_adamCtl.Configuration().SYS_SetDspChannelFlag(false))
                {
                    this.StatusBar_IO.Text = "SYS_SetDspChannelFlag(false) Failed! ";
                    return false;
                }
                if (!m_adamCtl.Configuration().GetSlotInfo(out m_szSlots))
                {
                    this.StatusBar_IO.Text = "GetSlotInfo() Failed! ";
                    return false;
                }
            }
            return true;
        }
        public bool DeviceFind()
        {
            int iLoop = 0;
            int iDeviceNum = 0;
            if ((m_idxID == -1))
            {
                for (iLoop = 0; iLoop < m_szSlots.Length; iLoop++)
                {
                    if ((m_szSlots[iLoop] == null))
                        continue;
                    if ((string.Compare(m_szSlots[iLoop], 0, DVICE_TYPE, 0, DVICE_TYPE.Length) == 0) && (m_szSlots[iLoop].Length == 4))
                    {
                        iDeviceNum++;
                        if ((iDeviceNum == 1))// Record first find device
                        {

                            m_idxID = iLoop;// Get DVICE_TYPE Solt

                        }
                    }
                }
            }
            else if ((string.Compare(m_szSlots[m_idxID], 0, DVICE_TYPE, 0, DVICE_TYPE.Length) == 0))
            {
                iDeviceNum++;
            }

            if ((iDeviceNum == 1))
            {
                return true;
            }
            else if ((iDeviceNum > 1))
            {
                MessageBox.Show("Found " + iDeviceNum.ToString() + " " + DVICE_TYPE + " devices." + " It's will demo Solt " + m_idxID.ToString() + ".", "Warning");
                return true;
            }
            else
            {
                MessageBox.Show(("Can\'t find any "
                                + (DVICE_TYPE + " device!")), "Error");
                return false;
            }
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            string strbtnStatus = this.btnStart.Text;
            if ((string.Compare(strbtnStatus, "Start", true) == 0))
            {
                // Was Stop, Then Start
                if (!StartRemote())
                {
                    return;
                }
                m_bStartFlag = true;
                this.btnStart.Text = "Stop";
            }
            else
            {
                // Was Start, Then Stop
                this.StatusBar_IO.Text = ("Start to demo "
                            + APAX_INFO_NAME + "-"
                            + DVICE_TYPE + " by clicking 'Start'button.");
                this.FreeResource();
                this.btnStart.Text = "Start";
            }
        }
        private void Btn_Quit_Click(object sender, EventArgs e)
        {
            Close();
        }

        public bool StartRemote()
        {
            try
            {
                if (!OpenDevice())
                {
                    throw new System.Exception("Open Local Device Fail.");
                }
                if (!DeviceFind())
                {
                    throw new System.Exception("Find " + DVICE_TYPE + " Device Fail.");
                }
                if (!RefreshConfiguration())
                {
                    throw new System.Exception("Get" + DVICE_TYPE + " Device Configuration Fail.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
                return false;
            }
            this.StatusBar_IO.Text = "Starting to remote...";
            this.timer1.Interval = m_ScanTime_LocalSys;
            this.tabControl1.Enabled = true;
            this.tabControl1.Visible = true;
            InitialDataTabPages();
            this.Text = (APAX_INFO_NAME + DVICE_TYPE);
            m_iScanCount = 0;
            this.tabControl1.SelectedIndex = 0;
            return true;
        }
        /// <summary>
        /// APAX I/O module information init function
        /// </summary>
        /// <returns></returns>
        public bool RefreshConfiguration()
        {
            string strModuleName;

            if (m_adamCtl.Configuration().GetModuleConfig(m_idxID, out m_aConf))
            {
                txtModule.Text = m_aConf.GetModuleName();       //Information-> ModuleA
                strModuleName = m_aConf.GetModuleName();
                txtID.Text = m_idxID.ToString();                //Information -> Switch ID
                txtSupportKernelFw.Text = m_aConf.wSupportFwVer.ToString("X04").Insert(2, ".");     //Information -> Support kernel Fw
                txtFwVer.Text = m_aConf.wFwVerNo.ToString("X04").Insert(2, ".");                    //Firmware version
                txtAIOFwVer.Text = m_aConf.wHwVer.ToString("X04").Insert(2, ".");   //AIO Firmware version
                RefreshRanges();
            }
            else
            {
                StatusBar_IO.Text = " GetModuleConfig(Error:" + m_adamCtl.Configuration().ApiLastError.ToString() + ") Failed! ";
                return false;
            }
            return true;
        }
        /// <summary>
        /// Init Channel Information
        /// </summary>
        /// <param name="m_aConf">apax 5000 device object</param>
        private void InitialDataTabPages()
        {
            int i = 0, idx = 0;
            byte type = (byte)_HardwareIOType.AI;   //APAX-5013 is AI module
            ListViewItem lvItem;
            string[] strRanges;
            ushort[] m_usRanges_supAI;

            for (i = 0; i < m_aConf.HwIoType.Length; i++)
            {
                if (m_aConf.HwIoType[i] == type)
                    idx = i;
            }
            m_tmpidx = idx;

            //init range combobox
            if (m_tmpidx == 0)
                m_usRanges_supAI = m_aConf.wHwIoType_0_Range;
            else if (m_tmpidx == 1)
                m_usRanges_supAI = m_aConf.wHwIoType_1_Range;
            else if (m_tmpidx == 2)
                m_usRanges_supAI = m_aConf.wHwIoType_2_Range;
            else if (m_tmpidx == 3)
                m_usRanges_supAI = m_aConf.wHwIoType_3_Range;
            else
                m_usRanges_supAI = m_aConf.wHwIoType_4_Range;
            //Get combobox items of Range
            strRanges = new string[m_aConf.HwIoType_TotalRange[m_tmpidx]];
            for (i = 0; i < strRanges.Length; i++)
            {
                strRanges[i] = AnalogInput.GetRangeName(m_usRanges_supAI[i]);
            }
            SetRangeComboBox(strRanges);
            cbxRange.SelectedIndex = GetChannelRangeIdx(AnalogInput.GetRangeName(m_usRanges[0]));  //get the first channel range
            //Get combobox items of Integration Time
            SetIntegrationComboBox(new string[] { AnalogInput.GetIntegrationName(AdamType.Apax5000, (byte)Apax_Integration.Hz60_50ms), AnalogInput.GetIntegrationName(AdamType.Apax5000, (byte)Apax_Integration.Hz50_60ms) });
            //Get combobox items of Burnout Detect Mode
            SetBurnoutFcnValueComboBox(new string[] { "Down Scale", "Up Scale" });
            //init channel information
            listViewChInfo.BeginUpdate();
            listViewChInfo.Items.Clear();
            for (i = 0; i < m_aConf.HwIoTotal[m_tmpidx]; i++)
            {
                lvItem = new ListViewItem(_HardwareIOType.AI.ToString());   //type
                lvItem.SubItems.Add(i.ToString());      //Ch
                lvItem.SubItems.Add("*****");           //Value
                lvItem.SubItems.Add("*****");           //Ch Status 
                lvItem.SubItems.Add("*****");           //Range
                listViewChInfo.Items.Add(lvItem);
            }
            listViewChInfo.EndUpdate();
        }
        public int GetChannelRangeIdx(string o_szRangeName)
        {
            for (int i = 0; i < cbxRange.Items.Count; i++)
            {
                if (cbxRange.Items[i].ToString() == o_szRangeName)
                    return i;
            }
            return -1;
        }
        /// <summary>
        /// Get Range combobox string
        /// </summary>
        /// <param name="strRanges"></param>
        public void SetRangeComboBox(string[] strRanges)
        {
            cbxRange.BeginUpdate();
            cbxRange.Items.Clear();
            for (int i = 0; i < strRanges.Length; i++)
                cbxRange.Items.Add(strRanges[i]);

            if (cbxRange.Items.Count > 0)
                cbxRange.SelectedIndex = 0;
            cbxRange.EndUpdate();
        }
        /// <summary>
        /// Get Integration time combobox string
        /// </summary>
        /// <param name="strIntegration"></param>
        public void SetIntegrationComboBox(string[] strIntegration)
        {
            cbxIntegration.BeginUpdate();
            cbxIntegration.Items.Clear();
            for (int i = 0; i < strIntegration.Length; i++)
                cbxIntegration.Items.Add(strIntegration[i]);

            if (cbxIntegration.Items.Count > 0)
                cbxIntegration.SelectedIndex = 0;
            cbxIntegration.EndUpdate();
        }
        /// <summary>
        /// Get Burnout detect mode value combobox string
        /// </summary>
        /// <param name="strRanges"></param>
        public void SetBurnoutFcnValueComboBox(string[] strRanges)
        {
            cbxBurnoutValue.BeginUpdate();
            cbxBurnoutValue.Items.Clear();
            for (int i = 0; i < strRanges.Length; i++)
                cbxBurnoutValue.Items.Add(strRanges[i]);

            if (cbxBurnoutValue.Items.Count > 0)
                cbxBurnoutValue.SelectedIndex = 0;
            cbxBurnoutValue.EndUpdate();
        }

        private void btnLocate_Click(object sender, EventArgs e)
        {
            if (btnLocate.Text == "Enable")
            {
                if (m_adamCtl.Configuration().SYS_SetLocateModule(m_idxID, 255))
                    btnLocate.Text = "Disable";
                else
                    MessageBox.Show("Locate module failed!", "Error");
            }
            else
            {
                if (m_adamCtl.Configuration().SYS_SetLocateModule(m_idxID, 0))
                    btnLocate.Text = "Enable";
                else
                    MessageBox.Show("Locate module failed!", "Error");
            }
        }

        /// <summary>
        /// Periodically get Channel Information every time interval
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            bool bRet;
            StatusBar_IO.Text = "Polling (Interval=" + timer1.Interval.ToString() + "ms): ";
            bRet = RefreshData();
            if (bRet)
            {
                m_iScanCount++;
                m_iFailCount = 0;
                StatusBar_IO.Text += m_iScanCount.ToString() + " times...";
            }
            else
            {
                m_iFailCount++;
                StatusBar_IO.Text += m_iFailCount.ToString() + " failures...";
            }

            if (m_iFailCount > 5)
            {
                timer1.Enabled = false;
                StatusBar_IO.Text += " polling suspended!!";
                MessageBox.Show("Failed more than 5 times! Please check the physical connection!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
            if (m_iScanCount % 50 == 0)
                GC.Collect();
        }
        /// <summary>
        /// Refresh AI Channel Information
        /// </summary>
        /// <returns></returns>
        private bool RefreshData()
        {
            int iChannelTotal = this.m_aConf.HwIoTotal[m_tmpidx];

            if (this.m_uiChMask != 0x00)
            {
                ushort[] usVal;
                Advantech.Adam.Apax5000_ChannelStatus[] aStatus;

                if (!m_adamCtl.AnalogInput().GetChannelStatus(m_idxID, iChannelTotal, out aStatus))
                {
                    StatusBar_IO.Text += "[GetChannelStatus] ApiErr:" + m_adamCtl.AnalogInput().ApiLastError.ToString() + " ";
                    return false;
                }
                if (!m_adamCtl.AnalogInput().GetValues(m_idxID, iChannelTotal, out usVal))
                {
                    StatusBar_IO.Text += "[GetValues] ApiErr:" + m_adamCtl.AnalogInput().ApiLastError.ToString() + " ";
                    return false;
                }

                string[] strVal = new string[iChannelTotal];
                string[] strStatus = new string[iChannelTotal];
                double[] dVals = new double[iChannelTotal];
                bool bHasTCRange = false;

                for (int i = 0; i < iChannelTotal; i++)
                {
                    if (m_aConf.wPktVer >= 0x0002)
                        dVals[i] = AnalogInput.GetScaledValueWithResolution(this.m_usRanges[i], usVal[i], m_aConf.wHwIoType_0_Resolution);
                    else
                    {
                        if (m_aConf.GetModuleName() == "5017H")
                            dVals[i] = AnalogInput.GetScaledValueWithResolution(this.m_usRanges[i], usVal[i], 12);
                        else
                            dVals[i] = AnalogInput.GetScaledValue(this.m_usRanges[i], usVal[i]);
                    }

                    if (m_usRanges[i] >= 0x400 && m_usRanges[i] < 0x500)
                        bHasTCRange = true;
                    if (m_bChMask[i])
                    {
                        if (this.IsShowRawData)
                            strVal[i] = usVal[i].ToString("X04");
                        else
                            strVal[i] = dVals[i].ToString(AnalogInput.GetFloatFormat(this.m_usRanges[i]));
                        strStatus[i] = aStatus[i].ToString();
                    }
                    else
                    {
                        strVal[i] = "*****";
                        strStatus[i] = "Disable";
                    }
                    listViewChInfo.Items[i].SubItems[2].Text = strVal[i].ToString();  //moduify "Value" column
                    listViewChInfo.Items[i].SubItems[3].Text = strStatus[i].ToString();   //modify "Ch Status" column
                }

                if (bHasTCRange && (((m_iScanCount * timer1.Interval) % 5000 >= 0) && ((m_iScanCount * timer1.Interval) % 5000 < 1)))
                {
                    float fCJCVal;
                    Apax5000_ChannelStatus o_Status;
                    if (m_adamCtl.AnalogInput().GetCJCValue(m_idxID, out fCJCVal, out o_Status))
                    {
                        if (o_Status == Apax5000_ChannelStatus.CJCTempError)
                        {
                            timer1.Enabled = false;
                            MessageBox.Show("The CJC temperature sensor failed!\nPlease check device is install correctly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                            StatusBar_IO.Text += "The CJC temperature sensor failed! Please check device is install correctly.";
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < iChannelTotal; i++)
                {
                    listViewChInfo.Items[i].SubItems[2].Text = "******";        //moduify "Value" column
                    listViewChInfo.Items[i].SubItems[3].Text = "******";        //modify "Ch Status" column
                }
            }
            return true;
        }
        /// <summary>
        /// When change tab, refresh status, timer, counter related informations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strSelPageName = tabControl1.TabPages[tabControl1.SelectedIndex].Text;
            StatusBar_IO.Text = "";
            if (strSelPageName == "Module Information")
            {
                m_iFailCount = 0;
                m_iScanCount = 0;
            }
            else if (strSelPageName == "AI")
            {
                RefreshRanges();
                RefreshAiSetting();
                RefreshBurnoutSetting(true, true);  //refresh burnout mask value and get burnout detect mode
            }
            if (listViewChInfo.SelectedIndices.Count == 0)
                listViewChInfo.Items[0].Selected = true;

            if (tabControl1.SelectedIndex == 0)
                timer1.Enabled = false;
            else
                timer1.Enabled = true;
        }
        /// <summary>
        /// Get Channel information "Range" column
        /// </summary>
        /// <returns></returns>
        private bool RefreshRanges()
        {
            try
            {
                int iChannelTotal = this.m_aConf.HwIoTotal[m_tmpidx];
                if (m_adamCtl.Configuration().GetModuleConfig(m_idxID, out m_aConf))
                {
                    m_usRanges = m_aConf.wChRange;
                    m_uiChMask = m_aConf.dwChMask;
                    for (int i = 0; i < this.m_bChMask.Length; i++)
                    {
                        m_bChMask[i] = ((m_uiChMask & (0x01 << i)) > 0);
                    }
                    for (int i = 0; i < iChannelTotal; i++)
                    {
                        listViewChInfo.Items[i].SubItems[4].Text = AnalogInput.GetRangeName(m_usRanges[i]).ToString();
                    }
                }
                else
                    StatusBar_IO.Text += "GetModuleConfig(Error:" + m_adamCtl.Configuration().ApiLastError.ToString() + ") Failed! ";
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Refresh Integration time 
        /// </summary>
        private void RefreshAiSetting()
        {
            if (m_adamCtl.Configuration().GetModuleConfig(m_idxID, out m_aConf))
            {
                int idx;
                uint uiFcnParam;

                //Check if support SampleRate
                if (this.m_aConf.byFunType_0 == (byte)_FunctionType.Filter)
                {
                    uiFcnParam = m_aConf.dwFunParam_0;
                }
                else if (this.m_aConf.byFunType_1 == (byte)_FunctionType.Filter)
                {
                    uiFcnParam = m_aConf.dwFunParam_1;
                }
                else if (this.m_aConf.byFunType_2 == (byte)_FunctionType.Filter)
                {
                    uiFcnParam = m_aConf.dwFunParam_2;
                }
                else if (this.m_aConf.byFunType_3 == (byte)_FunctionType.Filter)
                {
                    uiFcnParam = m_aConf.dwFunParam_3;
                }
                else if (this.m_aConf.byFunType_4 == (byte)_FunctionType.Filter)
                {
                    uiFcnParam = m_aConf.dwFunParam_4;
                }
                else
                    return;
                idx = AnalogInput.GetIntegrationIndex(AdamType.Apax5000, (byte)uiFcnParam);
                if (idx > cbxIntegration.Items.Count - 1)
                    cbxIntegration.SelectedIndex = -1;
                else
                    cbxIntegration.SelectedIndex = idx;
            }
            else
                StatusBar_IO.Text += "GetModuleConfig(Error:" + m_adamCtl.Configuration().ApiLastError.ToString() + ") Failed! ";
        }
        /// <summary>
        /// Refresh AI Burnout detect mode settings
        /// </summary>
        /// <param name="bUpdateBurnFun"></param>
        /// <param name="bUpdateBurnVal"></param>
        /// <returns></returns>
        private bool RefreshBurnoutSetting(bool bUpdateBurnFun, bool bUpdateBurnVal)
        {
            try
            {
                bool bRet = false;
                uint o_dwEnableMask;
                uint o_dwValue;

                ThreadStart newStart = new ThreadStart(showMsg);
                Thread waitThread = new Thread(newStart);
                waitThread.Start();

                if (bUpdateBurnFun)     //Get burnout mask value
                {
                    if (!m_adamCtl.AnalogInput().GetBurnoutFunEnable(m_idxID, out o_dwEnableMask))
                        bRet = false;
                    else
                    {
                        bRet = true;
                        m_uiBurnoutMask = o_dwEnableMask;
                    }
                    System.Threading.Thread.Sleep(1000);
                }
                if (bUpdateBurnVal)
                {
                    if (!m_adamCtl.AnalogInput().GetBurnoutValue(m_idxID, out o_dwValue))
                        bRet = false;
                    else
                    {
                        bRet = true;
                        m_uiBurnoutVal = o_dwValue;
                        if (m_uiBurnoutVal == 0x00000000)       //Update Burnout Detect Mode combobox value
                            cbxBurnoutValue.SelectedIndex = 0;
                        else
                            cbxBurnoutValue.SelectedIndex = 1;
                    }
                }
                return bRet;
            }
            catch
            {
                return false;
            }
        }
        public bool IsShowRawData
        {
            get
            {
                return chbxShowRawData.Checked;
            }
        }
        private void listViewChInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < listViewChInfo.Items.Count; i++)
            {
                if (listViewChInfo.Items[i].Selected)
                {
                    LvChInfo_SelectedIndexChanged(i);
                    break;
                }
            }
        }
        /// <summary>
        /// When user select specific item of channel information, you should update channel range
        /// </summary>
        /// <param name="idxSel"></param>
        private void LvChInfo_SelectedIndexChanged(int idxSel)
        {
            this.cbxRange.SelectedIndex = GetChannelRangeIdx(AnalogInput.GetRangeName(m_usRanges[idxSel]));
            this.btnMaskEnable.Enabled = true;
            this.btnMaskDisable.Enabled = true;
            if ((m_usRanges[idxSel] <= (ushort)ApaxUnknown_InputRange.Btype_200To1820C && m_usRanges[idxSel] >= (ushort)ApaxUnknown_InputRange.Jtype_Neg210To1200C) ||  //0x0401~0x04C1
                (m_usRanges[idxSel] <= (ushort)ApaxUnknown_InputRange.Ni518_0To100 && m_usRanges[idxSel] >= (ushort)ApaxUnknown_InputRange.Pt100_3851_Neg200To850))     //0x0200~0x0321
            {
                this.chkBurnoutFcn.Enabled = true;
                this.btnBurnoutFcn.Enabled = true;
            }
            else
            {
                this.chkBurnoutFcn.Enabled = false;
                this.btnBurnoutFcn.Enabled = false;
            }
            //refresh burnout mask
            if (((m_uiBurnoutMask >> idxSel) & 0x1) > 0)
                chkBurnoutFcn.Checked = true;
            else
                chkBurnoutFcn.Checked = false;
        }

        private void btnApplySelRange_Click(object sender, EventArgs e)
        {
            if (!CheckControllable())
                return;
            timer1.Enabled = false;

            bool bRet = true;
            if (listViewChInfo.SelectedIndices.Count == 0 && !chkApplyAll.Checked)
            {
                MessageBox.Show("Please select the target channel in the listview!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                bRet = false;
            }
            if (bRet)
            {
                int iChannelTotal = this.m_aConf.HwIoTotal[m_tmpidx];
                ushort[] usRanges = new ushort[m_usRanges.Length];
                Array.Copy(m_usRanges, 0, usRanges, 0, m_usRanges.Length);
                if (chkApplyAll.Checked)
                {
                    for (int i = 0; i < usRanges.Length; i++)
                    {
                        usRanges[i] = AnalogInput.GetRangeCode2Byte(cbxRange.SelectedItem.ToString());
                    }
                }
                else
                {
                    for (int i = 0; i < listViewChInfo.SelectedIndices.Count; i++)
                    {
                        usRanges[listViewChInfo.SelectedIndices[i]] = AnalogInput.GetRangeCode2Byte(cbxRange.SelectedItem.ToString());
                    }
                }
                if (m_adamCtl.AnalogInput().SetRanges(this.m_idxID, iChannelTotal, usRanges))
                {
                    RefreshRanges();
                }
                else
                {
                    MessageBox.Show("Set ranges failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                }
            }
            timer1.Enabled = true;
        }
        /// <summary>
        /// Check module controllable
        /// </summary>
        /// <returns></returns>
        private bool CheckControllable()
        {
            ushort active;
            if (m_adamCtl.Configuration().SYS_GetGlobalActive(out active))
            {
                if (active == 1)
                    return true;
                else
                {
                    MessageBox.Show("There is another controller taking control, so you only can monitor IO data.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    return false;
                }
            }
            MessageBox.Show("Checking controllable failed, utility only could monitor io data now. (" + m_adamCtl.Configuration().ApiLastError.ToString() + ")", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            return false;
        }
        /// <summary>
        /// Waiting Foam dialog
        /// </summary>
        private void showMsg()
        {
            Wait_Form FormWait = new Wait_Form();
            FormWait.Start_Wait(3000);
            FormWait.ShowDialog();
            FormWait.Dispose();
            FormWait = null;
        }
        private void btnMaskEnable_Click(object sender, EventArgs e)
        {
            if (!CheckControllable())
                return;
            settingAI_MaskSetting(true, chkApplyAll.Checked);
        }

        private void btnMaskDisable_Click(object sender, EventArgs e)
        {
            if (!CheckControllable())
                return;
            settingAI_MaskSetting(false, chkApplyAll.Checked);
        }
        /// <summary>
        /// Enable/Disable Channel mask function
        /// </summary>
        /// <param name="bEnable"></param>
        /// <param name="i_bApplyAll"></param>
        private void settingAI_MaskSetting(bool bEnable, bool i_bApplyAll)
        {
            if (!CheckControllable())
                return;
            timer1.Enabled = false;
            bool bRet = true;
            if (listViewChInfo.SelectedIndices.Count == 0 && !i_bApplyAll)
            {
                MessageBox.Show("Please select the target channel in the listview!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                bRet = false;
            }
            if (bRet)
            {
                bool[] bChMask = new bool[m_bChMask.Length];
                uint uiMask = 0x00000000;
                Array.Copy(m_bChMask, 0, bChMask, 0, m_bChMask.Length);
                if (i_bApplyAll)
                {
                    for (int i = 0; i < bChMask.Length; i++)
                    {
                        bChMask[i] = bEnable;
                    }
                }
                else
                {
                    for (int i = 0; i < listViewChInfo.SelectedIndices.Count; i++)
                    {
                        bChMask[listViewChInfo.SelectedIndices[i]] = bEnable;
                    }
                }
                for (int i = 0; i < bChMask.Length; i++)
                {
                    if (bChMask[i])
                        uiMask |= ((uint)1 << i);
                }
                if ((uiMask == 0))
                {
                    //  Can't disable all channel
                    MessageBox.Show("Cannot diable all channel!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    if (this.m_adamCtl.AnalogInput().SetChannelEnabled(m_idxID, uiMask))
                        RefreshRanges();
                    else
                        MessageBox.Show("Set ChannelEnabled failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                }
            }
            timer1.Enabled = true;
        }

        private void btnBurnoutFcn_Click(object sender, EventArgs e)
        {
            if (!CheckControllable())
                return;
            timer1.Enabled = false;
            if (chkApplyAll.Checked)
            {
                int iChannelTotal = this.m_aConf.HwIoTotal[m_tmpidx];
                if (chkBurnoutFcn.Checked)
                    m_uiBurnoutMask = (uint)(0x1 << iChannelTotal) - 1;
                else
                    m_uiBurnoutMask = 0x0;
            }
            else
            {
                int idx = 0;
                for (int i = 0; i < listViewChInfo.Items.Count; i++)
                {
                    if (listViewChInfo.Items[i].Selected)
                    {
                        idx = i;
                        break;
                    }
                }
                uint uiMask = (uint)(0x1 << idx);
                if (chkBurnoutFcn.Checked)
                    m_uiBurnoutMask |= uiMask;
                else
                    m_uiBurnoutMask &= ~uiMask;
            }
            if (m_adamCtl.AnalogInput().SetBurnoutFunEnable(m_idxID, m_uiBurnoutMask))
            {
                MessageBox.Show("Set burnout enable function done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                RefreshBurnoutSetting(true, false); //refresh burnout mask value
            }
            else
                MessageBox.Show("Set burnout enable function failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            timer1.Enabled = true;
        }

        private void btnIntegration_Click(object sender, EventArgs e)
        {
            if (!CheckControllable())
                return;
            timer1.Enabled = false;
            uint uiVal = (uint)AnalogInput.GetIntegrationCode(AdamType.Apax5000, cbxIntegration.SelectedIndex);
            if (m_adamCtl.AnalogInput().SetIntegration(m_idxID, uiVal))
            {
                MessageBox.Show("Set integration time done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                RefreshAiSetting();
            }
            else
            {
                MessageBox.Show("Set integration time failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            timer1.Enabled = true;
        }

        private void btnBurnoutValue_Click(object sender, EventArgs e)
        {
            uint uiVal;
            if (cbxBurnoutValue.SelectedIndex == 0)
                uiVal = 0;
            else
                uiVal = 0xFFFF;
            if (!CheckControllable())
                return;
            timer1.Enabled = false;
            if (m_adamCtl.AnalogInput().SetBurnoutValue(this.m_idxID, uiVal))
            {
                MessageBox.Show("Set burnout value done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                RefreshBurnoutSetting(false, true);     //refresh burnout detect mode
            }
            else
                MessageBox.Show("Set burnout value failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            timer1.Enabled = true;
        }

        private void chbxHide_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Visible = !chbxHide.Checked;
        }

        private void Form_APAX_5013_FormClosing(object sender, FormClosingEventArgs e)
        {
            FreeResource();
        }

    }
}