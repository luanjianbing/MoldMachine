using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Advantech.Adam;

namespace APAX_5080
{
    public partial class Form_APAX_5080 : Form
    {
        // Global object
        private string APAX_INFO_NAME = "APAX";
        private string DVICE_TYPE = "5080";

        private AdamControl m_adamCtl;
        private Apax5000Config m_aConf;

        private int m_idxID;
        private int m_ScanTime_LocalSys;
        private int m_iFailCount, m_iScanCount;
        private string[] m_szSlots;// Container of all solt device type

        private int m_DIidx, m_DOidx, m_CNTidx;
        private int m_iDoOffset = 0;
        private ushort[] m_usRanges;
        private bool[] m_bChMask = new bool[AdamControl.APAX_MaxAIOCh];
        private uint m_uiChMask = 0;

        private uint[] m_uiAlarmLimitValue, m_uiDOPulseWidth;
        private ushort[] m_usAlarmsConfig;  //H-byte is DOBehavior, L-byte is AlarmConfig
        private ushort[] m_usRanges_supAI;
        private ushort[] m_usCNTConfig; //H-byte is GateConfig, L-byte is CNTConfig
        private uint[] m_uiStartupCNT;
        private bool m_bStartFlag;

        public Form_APAX_5080()
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
        public Form_APAX_5080(int SlotNum, int ScanTime)
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
        ///  Initial every tab of I/O modules Information
        /// </summary>
        /// <param name="m_aConf">apax 5000 device object</param>
        private void InitialDataTabPages()
        {
            int i = 0;

            //APAX-5080 is DI and DO and CNT module
            for (i = 0; i < m_aConf.HwIoType.Length; i++)
            {
                if (m_aConf.HwIoType[i] == (byte)_HardwareIOType.DI)
                {
                    m_DIidx = i;
                    m_iDoOffset = m_aConf.HwIoTotal[i];
                    ListViewItem lvItem;
                    listViewChInfo_DI.BeginUpdate();
                    listViewChInfo_DI.Items.Clear();
                    for (int j = 0; j < m_aConf.HwIoTotal[i]; j++)
                    {
                        lvItem = new ListViewItem(_HardwareIOType.DI.ToString());   //Type
                        lvItem.SubItems.Add(j.ToString());      //Ch
                        lvItem.SubItems.Add("*****");           //Value
                        lvItem.SubItems.Add("BOOL");            //Mode
                        listViewChInfo_DI.Items.Add(lvItem);
                    }
                    listViewChInfo_DI.EndUpdate();
                }
                else if (m_aConf.HwIoType[i] == (byte)_HardwareIOType.DO)
                {
                    m_DOidx = i;
                    //Get DO setting -> Alarm Type string
                    SetAlarmTypeComboBox(new string[] { "Low", "High" });

                    //Get DO setting -> Mapping channel values
                    string[] strRange = new string[m_aConf.HwIoTotal[2]];     //m_aConf.HwIoTotal[2] is number of CNT channel count
                    for (int j = 0; j < m_aConf.HwIoTotal[2]; j++)
                        strRange[j] = AnalogInput.GetRangeName(m_usRanges[j]);
                    SetMappingChComboBox(m_aConf.HwIoTotal[2], strRange); //Counter number

                    //Get DO setting -> DO behavior string
                    SetDOBehaviorComboBox(new string[] { "Low Level", "High Level", "Low Pulse", "High Pulse" });

                    //Init channel information
                    listViewChInfo_DO.BeginUpdate();
                    listViewChInfo_DO.Items.Clear();
                    for (int j = 0; j < m_aConf.HwIoTotal[i]; j++)
                    {
                        ListViewItem lvItem;
                        lvItem = new ListViewItem(_HardwareIOType.DO.ToString());   //Type
                        lvItem.SubItems.Add(j.ToString());  //Ch
                        lvItem.SubItems.Add("*****");       //DO Value
                        lvItem.SubItems.Add("BOOL");        //Mode
                        lvItem.SubItems.Add("*****");       //Alarm Type
                        lvItem.SubItems.Add("*****");       //Alarm Limit
                        lvItem.SubItems.Add("*****");       //Alarm Flag
                        lvItem.SubItems.Add("*****");       //Map Ch
                        lvItem.SubItems.Add("*****");       //DO Behavior
                        listViewChInfo_DO.Items.Add(lvItem);
                    }
                    listViewChInfo_DO.EndUpdate();

                    m_uiDOPulseWidth = new uint[m_aConf.HwIoTotal[m_DOidx]];
                    m_uiAlarmLimitValue = new uint[m_aConf.HwIoTotal[m_DOidx]];
                    m_usAlarmsConfig = new ushort[m_aConf.HwIoTotal[m_DOidx]];
                }
                else if (m_aConf.HwIoType[i] == (byte)_HardwareIOType.CNT)
                {
                    string[] strRanges;
                    m_CNTidx = i;

                    if (m_CNTidx == 0)
                        m_usRanges_supAI = m_aConf.wHwIoType_0_Range;
                    else if (m_CNTidx == 1)
                        m_usRanges_supAI = m_aConf.wHwIoType_1_Range;
                    else if (m_CNTidx == 2)
                        m_usRanges_supAI = m_aConf.wHwIoType_2_Range;
                    else if (m_CNTidx == 3)
                        m_usRanges_supAI = m_aConf.wHwIoType_3_Range;
                    else
                        m_usRanges_supAI = m_aConf.wHwIoType_4_Range;
                    strRanges = new string[m_aConf.HwIoType_TotalRange[m_CNTidx]];
                    for (int idx = 0; idx < strRanges.Length; idx++)
                    {
                        strRanges[idx] = Counter.GetModeName(m_usRanges_supAI[idx]);
                    }
                    m_usCNTConfig = new ushort[m_aConf.HwIoTotal[m_CNTidx]];
                    SetRangeComboBox(strRanges);                    //Get CNT setting -> CNT Mode (Range)
                    SetCNTMappingChComboBox(m_aConf.HwIoTotal[0]);    //Mapping DI number
                    SetGateTypeComboBox(new string[] { "Low level", "Falling edge", "High level", "Rising edge" }); //Get CNT setting -> Counter Gate Setting -> Gate Active Type
                    SetGateTriggerModeComboBox(new string[] { "Non-Retrigger", "Retrigger", "Edge Start" });    //Get CNT setting -> Counter Gate Setting -> Trigger mode

                    //Init channel information
                    listViewChInfo_CNT.BeginUpdate();
                    listViewChInfo_CNT.Items.Clear();
                    for (int j = 0; j < m_aConf.HwIoTotal[i]; j++)
                    {
                        ListViewItem lvItem;
                        lvItem = new ListViewItem(_HardwareIOType.CNT.ToString());   //Type
                        lvItem.SubItems.Add(j.ToString());  //Ch
                        lvItem.SubItems.Add("*****");       //Value
                        lvItem.SubItems.Add("*****");       //Mode
                        lvItem.SubItems.Add("*****");       //Startup
                        lvItem.SubItems.Add("*****");       //Counting
                        lvItem.SubItems.Add("*****");       //Status
                        lvItem.SubItems.Add("*****");       //Count Type
                        lvItem.SubItems.Add("*****");       //Map Ch
                        lvItem.SubItems.Add("*****");       //Gate Active
                        lvItem.SubItems.Add("*****");       //Gate trigger
                        listViewChInfo_CNT.Items.Add(lvItem);
                    }
                    listViewChInfo_CNT.EndUpdate();
                }
            }
        }
        /// <summary>
        /// Get DO setting -> Alarm Type string
        /// </summary>
        /// <param name="strTypes"></param>
        public void SetAlarmTypeComboBox(string[] strTypes)
        {
            cbxAlarmType.BeginUpdate();
            cbxAlarmType.Items.Clear();
            for (int i = 0; i < strTypes.Length; i++)
                cbxAlarmType.Items.Add(strTypes[i]);

            if (cbxAlarmType.Items.Count > 0)
                cbxAlarmType.SelectedIndex = 0;
            cbxAlarmType.EndUpdate();
        }
        /// <summary>
        /// Get DO setting -> Mapping channel values
        /// </summary>
        /// <param name="iChNum"></param>
        /// <param name="strMode"></param>
        public void SetMappingChComboBox(int iChNum, string[] strMode)
        {
            cbxLocalAlarmMapCh.BeginUpdate();
            cbxLocalAlarmMapCh.Items.Clear();
            for (int i = 0; i < iChNum; i++)
            {
                cbxLocalAlarmMapCh.Items.Add(i.ToString());
            }
            if (cbxLocalAlarmMapCh.Items.Count > 0)
                cbxLocalAlarmMapCh.SelectedIndex = 0;
            cbxLocalAlarmMapCh.EndUpdate();
        }
        /// <summary>
        /// Get DO setting -> DO behavior string
        /// </summary>
        /// <param name="strTypes"></param>
        public void SetDOBehaviorComboBox(string[] strTypes)
        {
            cbxDOBehavior.BeginUpdate();
            cbxDOBehavior.Items.Clear();
            for (int i = 0; i < strTypes.Length; i++)
                cbxDOBehavior.Items.Add(strTypes[i]);

            if (cbxDOBehavior.Items.Count > 0)
                cbxDOBehavior.SelectedIndex = 0;
            cbxDOBehavior.EndUpdate();
        }
        /// <summary>
        /// Get CNT setting -> CNT Mode
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
        /// Get CNT setting -> Counter Gate Setting -> Mapping gate
        /// </summary>
        /// <param name="iChNum"></param>
        public void SetCNTMappingChComboBox(int iChNum)
        {
            cbxLocalGateMapCh.BeginUpdate();
            cbxLocalGateMapCh.Items.Clear();
            for (int i = 0; i < iChNum; i++)
                cbxLocalGateMapCh.Items.Add(i.ToString());

            if (cbxLocalGateMapCh.Items.Count > 0)
                cbxLocalGateMapCh.SelectedIndex = 0;
            cbxLocalGateMapCh.EndUpdate();
        }
        /// <summary>
        /// Get CNT setting -> Counter Gate Setting -> Gate Active Type
        /// </summary>
        /// <param name="strTypes"></param>
        public void SetGateTypeComboBox(string[] strTypes)
        {
            cbxGateType.BeginUpdate();
            cbxGateType.Items.Clear();
            for (int i = 0; i < strTypes.Length; i++)
                cbxGateType.Items.Add(strTypes[i]);

            if (cbxGateType.Items.Count > 0)
                cbxGateType.SelectedIndex = 0;
            cbxGateType.EndUpdate();
        }
        /// <summary>
        /// Get CNT setting -> Counter Gate Setting -> Trigger mode
        /// </summary>
        /// <param name="strTypes"></param>
        public void SetGateTriggerModeComboBox(string[] strTypes)
        {
            cbxTriggerMode.BeginUpdate();
            cbxTriggerMode.Items.Clear();
            for (int i = 0; i < strTypes.Length; i++)
                cbxTriggerMode.Items.Add(strTypes[i]);

            if (cbxTriggerMode.Items.Count > 0)
                cbxTriggerMode.SelectedIndex = 0;
            cbxTriggerMode.EndUpdate();
        }
        private void rbtnAlarm_CheckedChanged(object sender, EventArgs e)
        {
            cbxAlarmType.Enabled = rbtnAlarm.Checked;
            cbxDOBehavior.Enabled = rbtnAlarm.Checked;
            cbxLocalAlarmMapCh.Enabled = rbtnAlarm.Checked;
            txtLocalAlarmLimit.Enabled = rbtnAlarm.Checked;
            txtDOPulseWidth.Enabled = (rbtnAlarm.Checked && (cbxDOBehavior.SelectedIndex == 2 || cbxDOBehavior.SelectedIndex == 3));
            chbxAutoRL.Enabled = rbtnAlarm.Checked;
            btnAlarmClear.Enabled = rbtnAlarm.Checked;
            btnAlarmClearall.Enabled = rbtnAlarm.Checked;
            btnTrue.Enabled = !rbtnAlarm.Checked;
            btnFalse.Enabled = !rbtnAlarm.Checked;
        }
        /// <summary>
        /// Periodically get Channel Information every time interval
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            bool bRet;
            timer1.Enabled = false;
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
            timer1.Enabled = true;
        }
        /// <summary>
        /// Refresh Channel Information "Value" column
        /// </summary>
        /// <returns></returns>
        private bool RefreshData()
        {
            int iChannelTotal = 0;
            string strSelPageName = tabControl1.TabPages[tabControl1.SelectedIndex].Text;
            if (strSelPageName == "DI")
            {
                bool[] bVal;
                iChannelTotal = this.m_aConf.HwIoTotal[m_DIidx];
                if (!m_adamCtl.DigitalInput().GetValues(m_idxID, iChannelTotal, out bVal))
                {
                    StatusBar_IO.Text += "ApiErr:" + m_adamCtl.DigitalInput().ApiLastError.ToString() + " ";
                    return false;
                }
                for (int i = 0; i < bVal.Length; i++)
                {
                    listViewChInfo_DI.Items[i].SubItems[2].Text = bVal[i].ToString();  //moduify "Value" column
                }
            }
            else if (strSelPageName == "DO")
            {
                //Refresh Value
                bool[] bVal;
                iChannelTotal = this.m_aConf.HwIoTotal[m_DOidx];
                if (!m_adamCtl.DigitalOutput().GetValues(m_idxID, m_iDoOffset + iChannelTotal, out bVal))   //Should add offset for DIO modules 
                {
                    StatusBar_IO.Text += "ApiErr:" + m_adamCtl.DigitalOutput().ApiLastError.ToString() + " ";
                    return false;
                }
                for (int i = 0; i < bVal.Length - m_iDoOffset; i++)
                {
                    listViewChInfo_DO.Items[i].SubItems[2].Text = bVal[i + m_iDoOffset].ToString();  //moduify "Value" column
                }
                //Refresh AlarmFlag
                uint uiVal;
                if (!m_adamCtl.Alarm().GetAlarmFlags(m_idxID, out uiVal))
                {
                    StatusBar_IO.Text += "ApiErr:" + m_adamCtl.Alarm().ApiLastError.ToString() + " ";
                    return false;
                }
                for (int i = 0; i < iChannelTotal; i++)
                {
                    if (((uiVal >> i) & 0x01) > 0)
                        listViewChInfo_DO.Items[i].SubItems[6].Text = "True";
                    else
                        listViewChInfo_DO.Items[i].SubItems[6].Text = "False";
                }
            }
            else if (strSelPageName == "CNT")
            {
                uint[] uiVal;
                Advantech.Adam.Apax5000_ChannelStatus[] aStatus;
                iChannelTotal = this.m_aConf.HwIoTotal[m_CNTidx];
                if (!m_adamCtl.Counter().GetChannelStatus(m_idxID, iChannelTotal, out aStatus))
                {
                    StatusBar_IO.Text += "ApiErr:" + m_adamCtl.Counter().ApiLastError.ToString() + " ";
                    return false;
                }

                if (!m_adamCtl.Counter().GetValues(m_idxID, out uiVal))
                {
                    StatusBar_IO.Text += "ApiErr:" + m_adamCtl.Counter().ApiLastError.ToString() + " ";
                    return false;
                }
                string[] strVal = new string[uiVal.Length];
                float[] fVals = new float[uiVal.Length];
                string[] strStatus = new string[aStatus.Length];
                for (int i = 0; i < iChannelTotal; i++)
                {
                    strStatus[i] = aStatus[i].ToString();
                    bool o_bStatus;

                    if (!m_adamCtl.Counter().GetGateTriggerStatus(m_idxID, i, out o_bStatus))
                        StatusBar_IO.Text += "ApiErr:" + m_adamCtl.Counter().ApiLastError.ToString() + " ";
                    if (o_bStatus)
                    {
                        if (listViewChInfo_CNT.Items[i].SubItems[10].Text.Substring(listViewChInfo_CNT.Items[i].SubItems[10].Text.Length - 3, 3) != "(*)")      //Update "Gate Trigger" column
                            listViewChInfo_CNT.Items[i].SubItems[10].Text += "(*)";
                    }
                    else
                    {
                        if (listViewChInfo_CNT.Items[i].SubItems[10].Text.Substring(listViewChInfo_CNT.Items[i].SubItems[10].Text.Length - 3, 3) == "(*)")      //Update "Gate Trigger" column
                            listViewChInfo_CNT.Items[i].SubItems[10].Text = listViewChInfo_CNT.Items[i].SubItems[10].Text.Substring(0, listViewChInfo_CNT.Items[i].SubItems[10].Text.Length - 3);
                    }

                    if (!(m_usRanges[i] == (ushort)ApaxUnknown_InputRange.Up ||
                          m_usRanges[i] == (ushort)ApaxUnknown_InputRange.HighFrequency ||
                          m_usRanges[i] == (ushort)ApaxUnknown_InputRange.LowFrequency ||
                          m_usRanges[i] == (ushort)ApaxUnknown_InputRange.WaveWidth) && i % 2 == 1)
                    {
                        listViewChInfo_CNT.Items[i].SubItems[2].Text = "*****";    //moduify "Value" column
                        listViewChInfo_CNT.Items[i].SubItems[6].Text = "*****";    //moduify "Status" column
                        continue;
                    }
                    else if (m_usRanges[i] == (ushort)ApaxUnknown_InputRange.HighFrequency)
                    {
                        fVals[i] = Convert.ToSingle(uiVal[i]) / 10.0f;
                        if (this.IsShowRawData)
                            strVal[i] = uiVal[i].ToString("X08");
                        else
                            strVal[i] = fVals[i].ToString("0.0");
                    }
                    else if (m_usRanges[i] == (ushort)ApaxUnknown_InputRange.LowFrequency)
                    {
                        fVals[i] = Convert.ToSingle(uiVal[i]) / 10000.0f;
                        if (this.IsShowRawData)
                            strVal[i] = uiVal[i].ToString("X08");
                        else
                            strVal[i] = fVals[i].ToString("0.0000");
                    }
                    else
                    {
                        if (this.IsShowRawData)
                            strVal[i] = uiVal[i].ToString("X08");
                        else
                            strVal[i] = uiVal[i].ToString("0.0");
                    }
                    listViewChInfo_CNT.Items[i].SubItems[2].Text = strVal[i].ToString();    //moduify "Value" column
                    listViewChInfo_CNT.Items[i].SubItems[6].Text = strStatus[i].ToString();    //moduify "Status" column
                }
            }
            return true;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strSelPageName = tabControl1.TabPages[tabControl1.SelectedIndex].Text;
            StatusBar_IO.Text = "";
            if (strSelPageName == "Module Information")
            {
                m_iFailCount = 0;
                m_iScanCount = 0;
            }
            else if (strSelPageName == "DO")
            {
                RefreshDoAlarmSetting();
                if (listViewChInfo_DO.SelectedIndices.Count == 0)
                    listViewChInfo_DO.Items[0].Selected = true;
            }
            else if (strSelPageName == "CNT")
            {
                RefreshRanges();        //Update Channel information "Mode" column detail
                RefreshCntSetting();    //Refresh CNT -> Setting -> Digital Filter & FreqAcq. Time
                if (listViewChInfo_CNT.SelectedIndices.Count == 0)
                    listViewChInfo_CNT.Items[0].Selected = true;
            }
            if (tabControl1.SelectedIndex == 0)
                timer1.Enabled = false;
            else
                timer1.Enabled = true;
        }
        /// <summary>
        /// Get DO Alarm settings: Mode, Alarm type, DO behavior, Mapping Channel, Limit value, DO pulse width
        /// </summary>
        private void RefreshDoAlarmSetting()
        {
            bool bEnable;
            bool bAutoRL;
            byte byAlarmtype;
            int iMappingCh;
            uint uiLimitVal;
            byte byDOBehavior;
            uint uiPulseWidth;
            for (int i = 0; i < listViewChInfo_DO.Items.Count; i++)
            {
                m_usAlarmsConfig[i] = 0;
                m_uiDOPulseWidth[i] = 0;
                m_uiAlarmLimitValue[i] = 0;
                if (m_adamCtl.Alarm().GetLocalAlarmConfiguration(m_idxID, i, out bEnable, out bAutoRL, out byAlarmtype, out iMappingCh, out uiLimitVal, out byDOBehavior, out uiPulseWidth))
                {
                    m_usAlarmsConfig[i] += (ushort)(byAlarmtype & 0x01);
                    m_usAlarmsConfig[i] += (ushort)(iMappingCh << 3);
                    m_usAlarmsConfig[i] += (ushort)(byDOBehavior * 0x100);
                    m_uiAlarmLimitValue[i] = uiLimitVal;
                    m_uiDOPulseWidth[i] = uiPulseWidth;
                    if (bEnable)    //Mode is Alarm Type
                    {
                        listViewChInfo_DO.Items[i].SubItems[0].Text = "Alarm";      //moduify "Type" column
                        m_usAlarmsConfig[i] += 0x4;

                        if (byAlarmtype == 0)                                       //moduify "Alarm Type" column
                            listViewChInfo_DO.Items[i].SubItems[4].Text = "Low";
                        else if (byAlarmtype == 1)
                            listViewChInfo_DO.Items[i].SubItems[4].Text = "High";
                        else
                            listViewChInfo_DO.Items[i].SubItems[4].Text = "???";

                        string strMappingCh = "Cnt" + iMappingCh.ToString();
                        if (bAutoRL)
                        {
                            m_usAlarmsConfig[i] += 0x40;
                            strMappingCh += "(AutoRL)";
                        }
                        listViewChInfo_DO.Items[i].SubItems[7].Text = strMappingCh;       //moduify "Map Ch" column

                        listViewChInfo_DO.Items[i].SubItems[5].Text = uiLimitVal.ToString();    //moduify "Alarm Limit" column

                        if (byDOBehavior == 0)                                      //moduify "DO Behavior" column
                            listViewChInfo_DO.Items[i].SubItems[8].Text = "Low Level";
                        else if (byDOBehavior == 1)
                            listViewChInfo_DO.Items[i].SubItems[8].Text = "High Level";
                        else if (byDOBehavior == 2)
                            listViewChInfo_DO.Items[i].SubItems[8].Text = "PulseLo Width" + uiPulseWidth.ToString();
                        else if (byDOBehavior == 3)
                            listViewChInfo_DO.Items[i].SubItems[8].Text = "PulseHi Width" + uiPulseWidth.ToString();
                        else
                            listViewChInfo_DO.Items[i].SubItems[8].Text = "???";
                    }
                    else    //Mode is DO Type
                    {
                        listViewChInfo_DO.Items[i].SubItems[0].Text = "DO";         //moduify "Type" column
                        listViewChInfo_DO.Items[i].SubItems[4].Text = "Disable";    //moduify "Alarm Type" column
                        listViewChInfo_DO.Items[i].SubItems[7].Text = "Disable";    //moduify "Map Ch" column
                        listViewChInfo_DO.Items[i].SubItems[5].Text = "Disable";    //moduify "Alarm Limit" column
                        listViewChInfo_DO.Items[i].SubItems[8].Text = "Disable";    //moduify "DO Behavior" column
                    }
                }
                else
                {
                    listViewChInfo_DO.Items[i].SubItems[0].Text = "*****";    //moduify "Type" column
                    listViewChInfo_DO.Items[i].SubItems[4].Text = "*****";    //moduify "Alarm Type" column
                    listViewChInfo_DO.Items[i].SubItems[7].Text = "*****";    //moduify "Map Ch" column
                    listViewChInfo_DO.Items[i].SubItems[5].Text = "*****";    //moduify "Alarm Limit" column
                    listViewChInfo_DO.Items[i].SubItems[8].Text = "*****";    //moduify "DO Behavior" column

                    string strErr;
                    strErr = "GetLocalAlarmConfiguration(Error:" + m_adamCtl.Counter().ApiLastError.ToString() + ") Failed! ";
                    StatusBar_IO.Text += strErr;
                }
            }
        }
        /// <summary>
        /// Update Channel information "Mode" column detail
        /// </summary>
        /// <returns></returns>
        private bool RefreshRanges()
        {
            try
            {
                if (m_adamCtl.Configuration().GetModuleConfig(m_idxID, out m_aConf))
                {
                    int iChannelTotal = this.m_aConf.HwIoTotal[m_CNTidx];
                    string[] strRange = new string[iChannelTotal];
                    m_usRanges = m_aConf.wChRange;
                    m_uiChMask = m_aConf.dwChMask;
                    for (int i = 0; i < this.m_bChMask.Length; i++)
                    {
                        m_bChMask[i] = ((m_uiChMask & (0x01 << i)) > 0);
                    }
                    for (int i = 0; i < strRange.Length; i++)
                    {
                        strRange[i] = Counter.GetModeName(m_usRanges[i]);
                        if (i % 2 == 0)
                        {
                            if (m_usRanges[i] == (ushort)ApaxUnknown_InputRange.Bi_Direction)
                            {
                                strRange[i] += "[P]";
                            }
                            else if (m_usRanges[i] == (ushort)ApaxUnknown_InputRange.Up_Down)
                            {
                                strRange[i] += "[U]";
                            }
                            else if (m_usRanges[i] == (ushort)ApaxUnknown_InputRange.AB1X ||
                                     m_usRanges[i] == (ushort)ApaxUnknown_InputRange.AB2X ||
                                     m_usRanges[i] == (ushort)ApaxUnknown_InputRange.AB4X)
                            {
                                strRange[i] += "[A]";
                            }
                        }
                        else
                        {
                            if (m_usRanges[i] == (ushort)ApaxUnknown_InputRange.Bi_Direction)
                            {
                                strRange[i] += "[D]";
                            }
                            else if (m_usRanges[i] == (ushort)ApaxUnknown_InputRange.Up_Down)
                            {
                                strRange[i] += "[D]";
                            }
                            else if (m_usRanges[i] == (ushort)ApaxUnknown_InputRange.AB1X ||
                                     m_usRanges[i] == (ushort)ApaxUnknown_InputRange.AB2X ||
                                     m_usRanges[i] == (ushort)ApaxUnknown_InputRange.AB4X)
                            {
                                strRange[i] += "[B]";
                            }
                        }
                        listViewChInfo_CNT.Items[i].SubItems[3].Text = strRange[i].ToString();  //Update "Mode" column

                        if (m_bChMask[i])
                            listViewChInfo_CNT.Items[i].SubItems[5].Text = "Start";     //Update "Counting" column
                        else
                        {
                            if (!(m_usRanges[i] == (ushort)ApaxUnknown_InputRange.Up ||
                                  m_usRanges[i] == (ushort)ApaxUnknown_InputRange.HighFrequency ||
                                  m_usRanges[i] == (ushort)ApaxUnknown_InputRange.LowFrequency ||
                                  m_usRanges[i] == (ushort)ApaxUnknown_InputRange.WaveWidth) && i % 2 == 1)
                            {
                                listViewChInfo_CNT.Items[i].SubItems[5].Text = "*****"; //Update "Counting" column
                            }
                            else
                            {
                                listViewChInfo_CNT.Items[i].SubItems[5].Text = "Stop";  //Update "Counting" column
                            }
                        }
                    }
                    RefreshCntCountMode();      //Get counter configuration
                    RefreshCntGateSetting();    //Get counter gate configuration
                    RefreshCntStartupValues();  //Get CNT Startup value
                    for (int i = 0; i < listViewChInfo_CNT.Items.Count; i++)
                    {
                        if (listViewChInfo_CNT.Items[i].Selected)
                        {
                            LvChInfoCNT_SelectedIndexChanged(i);
                            break;
                        }
                    }
                }
                else
                {
                    StatusBar_IO.Text += "GetModuleConfig(Error:" + m_adamCtl.Configuration().ApiLastError.ToString() + ") Failed! ";
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Get CNT configuration
        /// </summary>
        private void RefreshCntCountMode()
        {
            bool bOnceRepeat;
            bool bReloadIniti;
            for (int i = 0; i < listViewChInfo_CNT.Items.Count; i++)
            {
                if (m_adamCtl.Counter().GetCntTypeConfiguration(m_idxID, i, out bOnceRepeat, out bReloadIniti))
                {
                    ushort us_Temp = (ushort)(Convert.ToUInt16(bOnceRepeat) * 0x2 + Convert.ToUInt16(bReloadIniti) * 0x1);
                    m_usCNTConfig[i] = (ushort)((m_usCNTConfig[i] & 0xff00) + us_Temp);
                    string strCntMode;
                    if (!(m_usRanges[i] == (ushort)ApaxUnknown_InputRange.Up || m_usRanges[i] == (ushort)ApaxUnknown_InputRange.HighFrequency ||
                        m_usRanges[i] == (ushort)ApaxUnknown_InputRange.LowFrequency || m_usRanges[i] == (ushort)ApaxUnknown_InputRange.WaveWidth) && i % 2 == 1)
                    {
                        listViewChInfo_CNT.Items[i].SubItems[7].Text = "*****";     //Update "Count Type" column
                        continue;
                    }
                    if (bOnceRepeat)
                    {
                        strCntMode = "Repeat";
                    }
                    else
                    {
                        strCntMode = "Once";
                    }

                    if (bReloadIniti)
                    {
                        strCntMode += "//ReloadToStartup";
                    }
                    else
                    {
                        strCntMode += "//ReloadToZero";
                    }
                    listViewChInfo_CNT.Items[i].SubItems[7].Text = strCntMode;      //Update "Count Type" column
                }
                else
                {
                    listViewChInfo_CNT.Items[i].SubItems[7].Text = "*****";
                    string strErr = "GetCntConfiguration(Error:" + m_adamCtl.Counter().ApiLastError.ToString() + ") Failed! ";
                    StatusBar_IO.Text += strErr;
                }
                System.Threading.Thread.Sleep(20);
            }
        }
        /// <summary>
        /// Get CNT gate configuration
        /// </summary>
        private void RefreshCntGateSetting()
        {
            bool bEnable;
            byte byGatetype, byRetriggerMode;
            int iMappingCh;
            for (int i = 0; i < listViewChInfo_CNT.Items.Count; i++)
            {
                if (m_adamCtl.Counter().GetLocalGateConfiguration(m_idxID, i, out bEnable, out byRetriggerMode, out byGatetype, out iMappingCh))
                {
                    ushort us_Temp = (ushort)((iMappingCh * 0x20 + Convert.ToUInt16(bEnable) * 0x10 + byRetriggerMode * 0x4 + byGatetype * 0x1) * 0x100);
                    m_usCNTConfig[i] = (ushort)((m_usCNTConfig[i] & 0xFF) + us_Temp);
                    if (!(m_usRanges[i] == (ushort)ApaxUnknown_InputRange.Up || m_usRanges[i] == (ushort)ApaxUnknown_InputRange.HighFrequency ||
                        m_usRanges[i] == (ushort)ApaxUnknown_InputRange.LowFrequency || m_usRanges[i] == (ushort)ApaxUnknown_InputRange.WaveWidth) && i % 2 == 1)
                    {
                        listViewChInfo_CNT.Items[i].SubItems[10].Text = "*****";     //Update "Gate Trigger" column
                        listViewChInfo_CNT.Items[i].SubItems[9].Text = "*****";     //Update "Gate Active" column
                        listViewChInfo_CNT.Items[i].SubItems[8].Text = "*****";     //Update "Map Ch" column
                        continue;
                    }
                    string strGateSetting, strGateActiveType, strMappingCh;
                    if (bEnable)
                    {
                        if (byRetriggerMode == 0)
                            strGateSetting = "Non-Retrigger";
                        else if (byRetriggerMode == 1)
                            strGateSetting = "Retrigger";
                        else if (byRetriggerMode == 2)
                            strGateSetting = "Edge Start";
                        else
                            strGateSetting = "???";

                        if (byGatetype == 0)
                            strGateActiveType = "Low level";
                        else if (byGatetype == 1)
                            strGateActiveType = "Falling edge";
                        else if (byGatetype == 2)
                            strGateActiveType = "High level";
                        else if (byGatetype == 3)
                            strGateActiveType = "Rising edge";
                        else
                            strGateActiveType = "???";

                        strMappingCh = "Gate" + iMappingCh.ToString();
                    }
                    else
                    {
                        strGateActiveType = "Disable";
                        strGateSetting = "Disable";
                        strMappingCh = "Disable";
                    }
                    listViewChInfo_CNT.Items[i].SubItems[10].Text = strGateSetting;     //Update "Gate Trigger" column
                    listViewChInfo_CNT.Items[i].SubItems[9].Text = strGateActiveType;   //Update "Gate Active" column
                    listViewChInfo_CNT.Items[i].SubItems[8].Text = strMappingCh;        //Update "Map Ch" column
                }
                else
                {
                    string strErr = "GetLocalGateConfiguration(Error:" + m_adamCtl.Counter().ApiLastError.ToString() + ") Failed! ";
                    StatusBar_IO.Text += strErr;
                }
                System.Threading.Thread.Sleep(20);
            }
        }
        /// <summary>
        /// Get CNT Startup value
        /// </summary>
        /// <returns></returns>
        private bool RefreshCntStartupValues()
        {
            int iChannelTotal;
            try
            {
                iChannelTotal = this.m_aConf.HwIoTotal[m_CNTidx];
                if (m_adamCtl.Counter().GetStartupValues(m_idxID, iChannelTotal, out m_uiStartupCNT))
                {
                    for (int i = 0; i < iChannelTotal; i++)
                    {
                        if (!(m_usRanges[i] == (ushort)ApaxUnknown_InputRange.Up || m_usRanges[i] == (ushort)ApaxUnknown_InputRange.HighFrequency ||
                              m_usRanges[i] == (ushort)ApaxUnknown_InputRange.LowFrequency || m_usRanges[i] == (ushort)ApaxUnknown_InputRange.WaveWidth) && i % 2 == 1)
                        {
                            listViewChInfo_CNT.Items[i].SubItems[4].Text = "*****";        //Update "Startup" column
                            continue;
                        }
                        listViewChInfo_CNT.Items[i].SubItems[4].Text = m_uiStartupCNT[i].ToString();    //Update "Startup" column
                    }
                    return true;
                }
                else
                {
                    string strErr = "GetStartupValues(Error:" + m_adamCtl.Counter().ApiLastError.ToString() + ") Failed! ";
                    StatusBar_IO.Text += strErr;
                }
            }
            catch//(Exception ex)
            {
                return false;
            }
            return false;
        }
        /// <summary>
        /// Refresh CNT -> Setting -> Digital Filter & FreqAcq. Time
        /// </summary>
        private void RefreshCntSetting()
        {
            int iFilter = 0;
            string szFilter = "???";
            string szFreqAcqTime = "???";
            uint uiFcnParam = 0;

            if (m_adamCtl.Counter().GetDigitalFilter(m_idxID, out iFilter))
                szFilter = ((float)iFilter / 10).ToString();
            else
                StatusBar_IO.Text += "GetDigitalFilter(Error:" + m_adamCtl.Counter().ApiLastError.ToString() + ") Failed! ";
            if (m_adamCtl.Configuration().GetModuleConfig(m_idxID, out m_aConf))
            {
                //Check if support SampleRate
                if (this.m_aConf.byFunType_0 == (byte)_FunctionType.SampleRate)
                    uiFcnParam = m_aConf.dwFunParam_0;
                else if (this.m_aConf.byFunType_1 == (byte)_FunctionType.SampleRate)
                    uiFcnParam = m_aConf.dwFunParam_1;
                else if (this.m_aConf.byFunType_2 == (byte)_FunctionType.SampleRate)
                    uiFcnParam = m_aConf.dwFunParam_2;
                else if (this.m_aConf.byFunType_3 == (byte)_FunctionType.SampleRate)
                    uiFcnParam = m_aConf.dwFunParam_3;
                else if (this.m_aConf.byFunType_4 == (byte)_FunctionType.SampleRate)
                    uiFcnParam = m_aConf.dwFunParam_4;
                else
                    return;
                uiFcnParam = uiFcnParam / 1000;
                szFreqAcqTime = uiFcnParam.ToString();
            }
            else
            {
                string strErr = "GetModuleConfig(Error:" + m_adamCtl.Configuration().ApiLastError.ToString() + ") Failed! ";
                StatusBar_IO.Text += strErr;
            }
            txtFilter.Text = szFilter;
            txtFreqAcqTime.Text = szFreqAcqTime;
        }
        private void listViewChInfo_DO_SelectedIndexChanged(object sender, EventArgs e)
        {

            for (int i = 0; i < listViewChInfo_DO.Items.Count; i++)
            {
                if (listViewChInfo_DO.Items[i].Selected)
                {
                    LvChInfoDO_SelectedIndexChanged(i);
                    break;
                }
            }
        }
        /// <summary>
        /// When user select specific item of channel information(DO), update related information of each channel
        /// </summary>
        /// <param name="idxSel"></param>
        private void LvChInfoDO_SelectedIndexChanged(int idxSel)
        {
            bool bEnable = ((m_usAlarmsConfig[idxSel] & 0x4) > 0);
            bool bAutoRL = ((m_usAlarmsConfig[idxSel] & 0x40) > 0);
            byte byAlarmtype = (byte)(m_usAlarmsConfig[idxSel] & 0x1);
            int iMappingCh = (int)((m_usAlarmsConfig[idxSel] & 0x38) >> 3);
            uint uiLimitVal = m_uiAlarmLimitValue[idxSel];
            byte byDOBehavior = (byte)(m_usAlarmsConfig[idxSel] / 0x100);
            uint uiPulseWidth = m_uiDOPulseWidth[idxSel];

            rbtnAlarm.Checked = bEnable;
            rbtnDO.Checked = !bEnable;
            chbxAutoRL.Checked = bAutoRL;
            cbxAlarmType.SelectedIndex = (int)byAlarmtype;
            cbxLocalAlarmMapCh.SelectedIndex = iMappingCh;
            txtLocalAlarmLimit.Text = uiLimitVal.ToString();
            cbxDOBehavior.SelectedIndex = (int)byDOBehavior;
            txtDOPulseWidth.Text = uiPulseWidth.ToString();
        }
        private void listViewChInfo_CNT_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < listViewChInfo_CNT.Items.Count; i++)
            {
                if (listViewChInfo_CNT.Items[i].Selected)
                {
                    LvChInfoCNT_SelectedIndexChanged(i);
                    break;
                }
            }
        }
        /// <summary>
        /// When user select specific item of channel information(CNT), update related information of each channel
        /// </summary>
        /// <param name="idxSel"></param>
        private void LvChInfoCNT_SelectedIndexChanged(int idxSel)
        {
            if (!(m_usRanges[idxSel] == (ushort)ApaxUnknown_InputRange.Up ||
                  m_usRanges[idxSel] == (ushort)ApaxUnknown_InputRange.HighFrequency ||
                  m_usRanges[idxSel] == (ushort)ApaxUnknown_InputRange.LowFrequency ||
                  m_usRanges[idxSel] == (ushort)ApaxUnknown_InputRange.WaveWidth) && idxSel % 2 == 1)
            {
                cbxRange.SelectedIndex = cbxRange.Items.IndexOf(AnalogInput.GetRangeName(m_usRanges[idxSel]));
                EnableDisableControlPanel(false, false);  //Disable all CNT control panel
            }
            else
            {
                bool o_bEnable = ((m_usCNTConfig[idxSel] / 0x100) & 0x10) > 0;
                byte o_byTriggerMode = (byte)(((m_usCNTConfig[idxSel] / 0x100) & 0xC) >> 2);
                byte o_byGateActiveType = (byte)((m_usCNTConfig[idxSel] / 0x100) & 0x3);
                int o_iGateMap = (int)(((m_usCNTConfig[idxSel] / 0x100) & 0x60) >> 5);
                long o_lStartup = (long)m_uiStartupCNT[idxSel];
                bool o_bReload = (m_usCNTConfig[idxSel] & 0x1) > 0;
                bool o_bRepeat = (m_usCNTConfig[idxSel] & 0x2) > 0;
                cbxRange.SelectedIndex = cbxRange.Items.IndexOf(AnalogInput.GetRangeName(m_usRanges[idxSel]));
                txtStartupVal.Text = o_lStartup.ToString();
                chbxRepeat.Checked = o_bRepeat;
                chbxReloadToStartup.Checked = o_bReload;
                chbxGateEnable.Checked = o_bEnable;
                cbxLocalGateMapCh.SelectedIndex = o_iGateMap;
                cbxGateType.SelectedIndex = (int)o_byGateActiveType;
                cbxTriggerMode.SelectedIndex = (int)o_byTriggerMode;
                EnableDisableControlPanel(true, o_bEnable);  //Enable all CNT control panel
            }
        }
        public void EnableDisableControlPanel(bool i_state, bool o_bEnable)
        {
            btnApplyCountType.Enabled = i_state;
            txtStartupVal.Enabled = i_state;
            btnApplySetting.Enabled = i_state;
            btnStop.Enabled = i_state;
            btnStart.Enabled = i_state;
            btnResetCnt.Enabled = i_state;
            btnClearOF.Enabled = i_state;
            chbxReloadToStartup.Enabled = i_state;
            chbxRepeat.Enabled = i_state;
            chbxGateEnable.Enabled = i_state;
            cbxLocalGateMapCh.Enabled = i_state & o_bEnable;
            cbxGateType.Enabled = i_state & o_bEnable;
            cbxTriggerMode.Enabled = i_state & o_bEnable;
            btnApplyGateSetting.Enabled = i_state;
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

        private void cbxLocalAlarmMapCh_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = cbxLocalAlarmMapCh.SelectedIndex;
            if (m_usRanges[idx] == (ushort)ApaxUnknown_InputRange.HighFrequency || m_usRanges[idx] == (ushort)ApaxUnknown_InputRange.LowFrequency)
                labHz.Visible = true;
            else
                labHz.Visible = false;
            txtMappingChannel.Text = AnalogInput.GetRangeName(m_usRanges[idx]);
            if (rbtnAlarm.Checked)
            {
                if (cbxDOBehavior.SelectedIndex == 2 || cbxDOBehavior.SelectedIndex == 3)
                    txtDOPulseWidth.Enabled = true;
                else
                    txtDOPulseWidth.Enabled = false;
            }
        }

        private void btnTrue_Click(object sender, EventArgs e)
        {
            if (!CheckControllable())
                return;
            settingDO_SetTF(true);
        }

        private void btnFalse_Click(object sender, EventArgs e)
        {
            if (!CheckControllable())
                return;
            settingDO_SetTF(false);
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
        /// Set selected channels status to true or false
        /// </summary>
        /// <param name="bState">channel status</param>
        private void settingDO_SetTF(bool bState)
        {
            if (!CheckControllable())
                return;
            timer1.Enabled = false;
            if (listViewChInfo_DO.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Please select the target channel in the listview!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                timer1.Enabled = true;
                return;
            }
            else
            {
                for (int i = 0; i < listViewChInfo_DO.SelectedIndices.Count; i++)
                {
                    if (m_adamCtl.DigitalOutput().SetValue(m_idxID, listViewChInfo_DO.SelectedIndices[i], bState))
                        RefreshData();
                    else
                        MessageBox.Show("Set digital output failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                }
            }
            timer1.Enabled = true;
        }
        /// <summary>
        /// DO behavior change index, when user select "Low Level" and "High Level", shoule disable "DO pulse width" 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxDOBehavior_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbtnAlarm.Checked)
            {
                if (cbxDOBehavior.SelectedIndex == 2 || cbxDOBehavior.SelectedIndex == 3)
                    txtDOPulseWidth.Enabled = true;
                else
                    txtDOPulseWidth.Enabled = false;
            }
        }
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar.CompareTo('0') >= 0) && (e.KeyChar.CompareTo('9') <= 0))
                e.Handled = false;
            else if (e.KeyChar == (char)8)
                e.Handled = false;
            else
                e.Handled = true;
        }
        private void btnApplySetting_Click(object sender, EventArgs e)
        {
            if (!CheckControllable())
                return;
            uint uiLimitVal = 0;
            uint uiPulseWidth = 1;

            bool bIsAlarm = rbtnAlarm.Checked;
            bool bAutoRL = chbxAutoRL.Checked;
            int iAlarmType = cbxAlarmType.SelectedIndex;
            int iMappingCh = cbxLocalAlarmMapCh.SelectedIndex;
            string szLimitVal = txtLocalAlarmLimit.Text;
            int iDOBehavior = cbxDOBehavior.SelectedIndex;
            string szPulseWidth = txtDOPulseWidth.Text;
            bool bApplyAll = chbxApplyAll_DO.Checked;

            string szMode;
            timer1.Enabled = false;
            //Check even channel alarm mode
            if ((iMappingCh % 2) == 1)  // odd channel
            {
                szMode = AnalogInput.GetRangeName(m_usRanges[iMappingCh]);
                if (szMode == AnalogInput.GetRangeName((ushort)ApaxUnknown_InputRange.Bi_Direction) ||
                    szMode == AnalogInput.GetRangeName((ushort)ApaxUnknown_InputRange.Up_Down) ||
                    szMode == AnalogInput.GetRangeName((ushort)ApaxUnknown_InputRange.AB1X) ||
                    szMode == AnalogInput.GetRangeName((ushort)ApaxUnknown_InputRange.AB2X) ||
                    szMode == AnalogInput.GetRangeName((ushort)ApaxUnknown_InputRange.AB4X))
                {
                    MessageBox.Show("For the counter mode '" + szMode + "', only even channel can be selected to map an alarm!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    timer1.Enabled = true;
                    return;
                }
            }
            //Check alarm mode limit value (0~4294967295)
            try
            {
                if (szLimitVal.Length == 0)
                {
                    MessageBox.Show("Please input the alarm limit value between (0~4294967295).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    timer1.Enabled = true;
                    return;
                }
                uiLimitVal = Convert.ToUInt32(szLimitVal);
            }
            catch
            {
                MessageBox.Show("Please input the alarm limit value between (0~4294967295).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                timer1.Enabled = true;
                return;
            }
            //Check alarm mode DO pulse width (1~85899 ms)
            try
            {
                if (szPulseWidth.Length == 0)
                {
                    MessageBox.Show("Please input the DO pulse width value between (1~85899 ms).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    timer1.Enabled = true;
                    return;
                }
                uiPulseWidth = Convert.ToUInt32(szPulseWidth);
                if (uiPulseWidth == 0 || uiPulseWidth > 85899)
                {
                    MessageBox.Show("Please input the DO pulse width value between (1~85899 ms).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    timer1.Enabled = true;
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Please input the DO pulse width value between (1~85899 ms).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                timer1.Enabled = true;
                return;
            }

            if (listViewChInfo_DO.SelectedIndices.Count == 0 && !bApplyAll)
            {
                MessageBox.Show("Please select the target channel in the listview!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                timer1.Enabled = true;
                return;
            }
            if (bApplyAll)
            {
                for (int i = 0; i < listViewChInfo_DO.Items.Count; i++)
                {
                    if (!m_adamCtl.Alarm().SetLocalAlarmConfiguration(this.m_idxID, i, bIsAlarm, bAutoRL, (byte)iAlarmType, iMappingCh, uiLimitVal, (byte)iDOBehavior, uiPulseWidth))
                    {
                        MessageBox.Show("Set alarm" + i.ToString() + " configuration failed! ApiErr:" + m_adamCtl.Alarm().ApiLastError.ToString() + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                        timer1.Enabled = true;
                        return;
                    }
                }
                MessageBox.Show("Set alarm configuration done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                RefreshDoAlarmSetting();
                timer1.Enabled = true;
                return;
            }
            else
            {
                for (int i = 0; i < listViewChInfo_DO.SelectedIndices.Count; i++)
                {
                    if (!m_adamCtl.Alarm().SetLocalAlarmConfiguration(this.m_idxID, listViewChInfo_DO.SelectedIndices[i], bIsAlarm, bAutoRL, (byte)iAlarmType, iMappingCh, uiLimitVal, (byte)iDOBehavior, uiPulseWidth))
                    {
                        MessageBox.Show("Set alarm" + listViewChInfo_DO.SelectedIndices[i].ToString() + " configuration failed! ApiErr:" + m_adamCtl.Alarm().ApiLastError.ToString() + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                        timer1.Enabled = true;
                        return;
                    }
                }
                MessageBox.Show("Set gate configuration done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                RefreshDoAlarmSetting();
                timer1.Enabled = true;
                return;
            }
        }
      
        public bool IsShowRawData
        {
            get
            {
                return chbxShowRawData.Checked;
            }
        }

        private void cbxRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxRange.Items.Count >= 9)
            {
                if (cbxRange.SelectedIndex == 7 ||  //Low frequency
                    cbxRange.SelectedIndex == 8)    //Wave width    
                {
                    btnApplyStartup.Enabled = false;
                    txtStartupVal.ReadOnly = true;
                }
                else
                {
                    btnApplyStartup.Enabled = true;
                    txtStartupVal.ReadOnly = false;
                }
            }
        }
        private void txt_KeyPressfloat(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar.CompareTo('0') >= 0) && (e.KeyChar.CompareTo('9') <= 0))
                e.Handled = false;
            else if (e.KeyChar == (char)8)
                e.Handled = false;
            else if (e.KeyChar == (char)46)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void btnApplySelRange_Click(object sender, EventArgs e)
        {
            if (!CheckControllable())
                return;
            timer1.Enabled = false;
            bool bRet = true;
            bool bApplyAll = chbxApplyAll_CNT.Checked;
            if (listViewChInfo_CNT.SelectedIndices.Count == 0 && bApplyAll)
            {
                MessageBox.Show("Please select the target channel in the listview!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                bRet = false;
            }
            if (bRet)
            {
                ushort[] usRanges = new ushort[m_usRanges.Length];
                Array.Copy(m_usRanges, 0, usRanges, 0, m_usRanges.Length);
                if (bApplyAll)
                    for (int i = 0; i < usRanges.Length; i++)
                        usRanges[i] = Counter.GetRangeCode2Byte(cbxRange.SelectedItem.ToString());
                else
                {
                    for (int i = 0; i < listViewChInfo_CNT.SelectedIndices.Count; i++)
                    {
                        int neighborIdx = (listViewChInfo_CNT.SelectedIndices[i] % 2 == 0) ? listViewChInfo_CNT.SelectedIndices[i] + 1 : listViewChInfo_CNT.SelectedIndices[i] - 1;
                        //int neighborIdx;
                        //if (listViewChInfo_CNT.SelectedIndices[i] % 2 == 0)
                        //    neighborIdx = listViewChInfo_CNT.SelectedIndices[i] + 1;
                        //else
                        //    neighborIdx = listViewChInfo_CNT.SelectedIndices[i] - 1;
                        usRanges[listViewChInfo_CNT.SelectedIndices[i]] = Counter.GetRangeCode2Byte(cbxRange.SelectedItem.ToString());
                        if (cbxRange.SelectedIndex == 0 || cbxRange.SelectedIndex == 1 || cbxRange.SelectedIndex == 4 || cbxRange.SelectedIndex == 5 || cbxRange.SelectedIndex == 6)
                        {
                            usRanges[neighborIdx] = Counter.GetRangeCode2Byte(cbxRange.SelectedItem.ToString());
                        }
                        else
                        {
                            if (usRanges[neighborIdx] != (ushort)ApaxUnknown_InputRange.Up &&
                                    usRanges[neighborIdx] != (ushort)ApaxUnknown_InputRange.HighFrequency &&
                                    usRanges[neighborIdx] != (ushort)ApaxUnknown_InputRange.LowFrequency &&
                                    usRanges[neighborIdx] != (ushort)ApaxUnknown_InputRange.WaveWidth)
                                usRanges[neighborIdx] = Counter.GetRangeCode2Byte(cbxRange.SelectedItem.ToString());
                        }
                    }
                }
                int iChannelTotal = this.m_aConf.HwIoTotal[m_CNTidx];
                if (m_adamCtl.Counter().SetModes(this.m_idxID, iChannelTotal, usRanges))
                {
                    MessageBox.Show("Set modes done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    RefreshRanges();
                }
                else
                {
                    MessageBox.Show("Set modes failed! ApiErr:" + m_adamCtl.Counter().ApiLastError.ToString() + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                }
            }
            timer1.Enabled = true;
        }

        private void btnApplyStartup_Click(object sender, EventArgs e)
        {
            if (!CheckControllable())
                return;
            timer1.Enabled = false;
            uint uiStartupVal = 0;
            bool bRet = true;
            try
            {
                uiStartupVal = Convert.ToUInt32(txtStartupVal.Text);
            }
            catch
            {
                MessageBox.Show("Invalid startup value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                timer1.Enabled = true;
                return;
            }
            bool bApplyAll = chbxApplyAll_CNT.Checked;
            if (listViewChInfo_CNT.SelectedIndices.Count == 0 && !bApplyAll)
            {
                MessageBox.Show("Please select the target channel in the listview!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                return;
            }
            if (bRet)
            {
                uint[] uiVals = new uint[m_uiStartupCNT.Length];
                Array.Copy(m_uiStartupCNT, 0, uiVals, 0, m_uiStartupCNT.Length);
                if (bApplyAll)
                    for (int i = 0; i < m_uiStartupCNT.Length; i++)
                        uiVals[i] = uiStartupVal;
                else
                {
                    for (int i = 0; i < listViewChInfo_CNT.SelectedIndices.Count; i++)
                    {
                        uiVals[listViewChInfo_CNT.SelectedIndices[i]] = uiStartupVal;
                        if (!(m_usRanges[listViewChInfo_CNT.SelectedIndices[i]] == (ushort)ApaxUnknown_InputRange.Up ||
                              m_usRanges[listViewChInfo_CNT.SelectedIndices[i]] == (ushort)ApaxUnknown_InputRange.HighFrequency ||
                              m_usRanges[listViewChInfo_CNT.SelectedIndices[i]] == (ushort)ApaxUnknown_InputRange.LowFrequency ||
                              m_usRanges[listViewChInfo_CNT.SelectedIndices[i]] == (ushort)ApaxUnknown_InputRange.WaveWidth))
                        {
                            if (listViewChInfo_CNT.SelectedIndices[i] % 2 == 0)
                                uiVals[listViewChInfo_CNT.SelectedIndices[i] + 1] = uiStartupVal;
                            else
                                uiVals[listViewChInfo_CNT.SelectedIndices[i] - 1] = uiStartupVal;
                        }
                    }

                }
                int iChannelTotal = this.m_aConf.HwIoTotal[m_CNTidx];
                if (m_adamCtl.Counter().SetStartupValues(this.m_idxID, uiVals))
                {
                    RefreshCntStartupValues();
                }
                else
                {
                    MessageBox.Show("Set startup values failed! ApiErr:" + m_adamCtl.Counter().ApiLastError.ToString() + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                }
            }
            timer1.Enabled = true;
        }

        private void btnCNTStart_Click(object sender, EventArgs e)
        {
            settingCNT_MaskSetting(true, chbxApplyAll_CNT.Checked);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            settingCNT_MaskSetting(false, chbxApplyAll_CNT.Checked);
        }
        private void settingCNT_MaskSetting(bool bEnable, bool i_bApplyAll)
        {
            if (!CheckControllable())
                return;
            timer1.Enabled = false;
            bool bRet = true;
            //bool bApplyAll = chbxApplyAll_CNT.Checked;
            if (listViewChInfo_CNT.SelectedIndices.Count == 0 && !i_bApplyAll)
            {
                MessageBox.Show("Please select the target channel in the listview!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                return;
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
                    for (int i = 0; i < listViewChInfo_CNT.SelectedIndices.Count; i++)
                    {
                        bChMask[listViewChInfo_CNT.SelectedIndices[i]] = bEnable;
                        if (!(m_usRanges[listViewChInfo_CNT.SelectedIndices[i]] == (ushort)ApaxUnknown_InputRange.Up ||
                              m_usRanges[listViewChInfo_CNT.SelectedIndices[i]] == (ushort)ApaxUnknown_InputRange.HighFrequency ||
                              m_usRanges[listViewChInfo_CNT.SelectedIndices[i]] == (ushort)ApaxUnknown_InputRange.LowFrequency ||
                              m_usRanges[listViewChInfo_CNT.SelectedIndices[i]] == (ushort)ApaxUnknown_InputRange.WaveWidth))
                        {
                            if (listViewChInfo_CNT.SelectedIndices[i] % 2 == 0)
                                bChMask[listViewChInfo_CNT.SelectedIndices[i] + 1] = bEnable;
                            else
                                bChMask[listViewChInfo_CNT.SelectedIndices[i] - 1] = bEnable;
                        }
                    }
                }
                for (int iIdx = 0; iIdx < bChMask.Length; iIdx++)
                {
                    if (bChMask[iIdx])
                        uiMask |= ((uint)1 << iIdx);
                }
                if (m_adamCtl.Counter().SetChannelEnabled(this.m_idxID, uiMask))
                {
                    RefreshRanges();
                }
                else
                {
                    MessageBox.Show("Set ChannelEnabled failed! ApiErr:" + m_adamCtl.Counter().ApiLastError.ToString() + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                }
            }
            timer1.Enabled = true;
        }

        private void btnResetCnt_Click(object sender, EventArgs e)
        {
            if (!CheckControllable())
                return;
            timer1.Enabled = false;
            bool bRet = true;
            bool bApplyAll = chbxApplyAll_CNT.Checked;
            if (listViewChInfo_CNT.SelectedIndices.Count == 0 && !bApplyAll)
            {
                MessageBox.Show("Please select the target channel in the listview!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                return;
            }
            if (bRet)
            {
                bool[] bChMask = new bool[m_bChMask.Length];
                uint uiMask = 0x00000000;
                if (bApplyAll)
                    for (int i = 0; i < bChMask.Length; i++)
                    {
                        bChMask[i] = true;
                    }
                else
                {
                    for (int i = 0; i < listViewChInfo_CNT.SelectedIndices.Count; i++)
                    {
                        bChMask[listViewChInfo_CNT.SelectedIndices[i]] = true;
                        if (!(m_usRanges[listViewChInfo_CNT.SelectedIndices[i]] == (ushort)ApaxUnknown_InputRange.Up ||
                              m_usRanges[listViewChInfo_CNT.SelectedIndices[i]] == (ushort)ApaxUnknown_InputRange.HighFrequency ||
                              m_usRanges[listViewChInfo_CNT.SelectedIndices[i]] == (ushort)ApaxUnknown_InputRange.LowFrequency ||
                              m_usRanges[listViewChInfo_CNT.SelectedIndices[i]] == (ushort)ApaxUnknown_InputRange.WaveWidth))
                        {
                            if (listViewChInfo_CNT.SelectedIndices[i] % 2 == 0)
                                bChMask[listViewChInfo_CNT.SelectedIndices[i] + 1] = true;
                            else
                                bChMask[listViewChInfo_CNT.SelectedIndices[i] - 1] = true;
                        }
                    }
                }
                for (int iIdx = 0; iIdx < bChMask.Length; iIdx++)
                {
                    if (bChMask[iIdx])
                        uiMask |= ((uint)1 << iIdx);
                }
                if (!(m_adamCtl.Counter().SetToStartup(this.m_idxID, uiMask)))
                {
                    MessageBox.Show("Reset counter failed! ApiErr:" + m_adamCtl.Counter().ApiLastError.ToString() + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                }
            }
            timer1.Enabled = true;
        }

        private void btnClearOF_Click(object sender, EventArgs e)
        {
            if (!CheckControllable())
                return;
            timer1.Enabled = false;
            bool bRet = true;
            bool bApplyAll = chbxApplyAll_CNT.Checked;
            if (listViewChInfo_CNT.SelectedIndices.Count == 0 && !bApplyAll)
            {
                MessageBox.Show("Please select the target channel in the listview!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                return;
            }
            if (bRet)
            {
                bool[] bChMask = new bool[m_bChMask.Length];
                uint uiMask = 0x00000000;
                if (bApplyAll)
                    for (int i = 0; i < bChMask.Length; i++)
                    {
                        bChMask[i] = true;
                    }
                else
                {
                    for (int i = 0; i < listViewChInfo_CNT.SelectedIndices.Count; i++)
                    {
                        bChMask[listViewChInfo_CNT.SelectedIndices[i]] = true;
                        if (!(m_usRanges[listViewChInfo_CNT.SelectedIndices[i]] == (ushort)ApaxUnknown_InputRange.Up ||
                              m_usRanges[listViewChInfo_CNT.SelectedIndices[i]] == (ushort)ApaxUnknown_InputRange.HighFrequency ||
                              m_usRanges[listViewChInfo_CNT.SelectedIndices[i]] == (ushort)ApaxUnknown_InputRange.LowFrequency ||
                              m_usRanges[listViewChInfo_CNT.SelectedIndices[i]] == (ushort)ApaxUnknown_InputRange.WaveWidth))
                        {
                            if (listViewChInfo_CNT.SelectedIndices[i] % 2 == 0)
                                bChMask[listViewChInfo_CNT.SelectedIndices[i] + 1] = true;
                            else
                                bChMask[listViewChInfo_CNT.SelectedIndices[i] - 1] = true;
                        }
                    }
                }
                for (int iIdx = 0; iIdx < bChMask.Length; iIdx++)
                {
                    if (bChMask[iIdx])
                        uiMask |= ((uint)1 << iIdx);
                }
                if (!(m_adamCtl.Counter().ClearOverflows(this.m_idxID, uiMask)))
                {
                    MessageBox.Show("Clear counter overflow flag failed! ApiErr:" + m_adamCtl.Counter().ApiLastError.ToString() + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                }
            }
            timer1.Enabled = true;
        }

        private void btnApplyCountType_Click(object sender, EventArgs e)
        {
            if (!CheckControllable())
                return;
            bool bRet = true;

            timer1.Enabled = false;
            bool bApplyAll = chbxApplyAll_CNT.Checked;
            if (listViewChInfo_CNT.SelectedIndices.Count == 0 && !bApplyAll)
            {
                MessageBox.Show("Please select the target channel in the listview!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                return;
            }
            if (bRet)
            {
                if (bApplyAll)
                {
                    for (int i = 0; i < listViewChInfo_CNT.Items.Count; i++)
                    {
                        if (!m_adamCtl.Counter().SetCntTypeConfiguration(m_idxID, i, chbxRepeat.Checked, chbxReloadToStartup.Checked))
                        {
                            MessageBox.Show("Set count type" + i.ToString() + " configuration failed! ApiErr:" + m_adamCtl.Counter().ApiLastError.ToString() + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                            timer1.Enabled = true;
                            return;
                        }
                    }
                    RefreshCntCountMode();
                    timer1.Enabled = true;
                    return;
                }
                else
                {
                    for (int i = 0; i < listViewChInfo_CNT.SelectedIndices.Count; i++)
                    {
                        if (!m_adamCtl.Counter().SetCntTypeConfiguration(this.m_idxID, listViewChInfo_CNT.SelectedIndices[i], chbxRepeat.Checked, chbxReloadToStartup.Checked))
                        {
                            MessageBox.Show("Set count type" + listViewChInfo_CNT.SelectedIndices[i].ToString() + " configuration failed! ApiErr:" + m_adamCtl.Counter().ApiLastError.ToString() + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                            timer1.Enabled = true;
                            return;
                        }
                        if (!(m_usRanges[listViewChInfo_CNT.SelectedIndices[i]] == (ushort)ApaxUnknown_InputRange.Up ||
                              m_usRanges[listViewChInfo_CNT.SelectedIndices[i]] == (ushort)ApaxUnknown_InputRange.HighFrequency ||
                              m_usRanges[listViewChInfo_CNT.SelectedIndices[i]] == (ushort)ApaxUnknown_InputRange.LowFrequency ||
                              m_usRanges[listViewChInfo_CNT.SelectedIndices[i]] == (ushort)ApaxUnknown_InputRange.WaveWidth))
                        {
                            int neighborIdx = (listViewChInfo_CNT.SelectedIndices[i] % 2 == 0) ? listViewChInfo_CNT.SelectedIndices[i] + 1 : listViewChInfo_CNT.SelectedIndices[i] - 1;
                            if (!m_adamCtl.Counter().SetCntTypeConfiguration(this.m_idxID, neighborIdx, chbxRepeat.Checked, chbxReloadToStartup.Checked))
                            {
                                MessageBox.Show("Set count type" + listViewChInfo_CNT.SelectedIndices[i].ToString() + " configuration failed! ApiErr:" + m_adamCtl.Counter().ApiLastError.ToString() + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                                timer1.Enabled = true;
                                return;
                            }
                        }
                    }
                    MessageBox.Show("Set count type configuration done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    RefreshCntCountMode();
                    timer1.Enabled = true;
                    return;
                }
            }
        }

        private void btnApplyGateSetting_Click(object sender, EventArgs e)
        {
            if (!CheckControllable())
                return;
            bool bRet = true;

            timer1.Enabled = false;
            bool bApplyAll = chbxApplyAll_CNT.Checked;
            if (listViewChInfo_CNT.SelectedIndices.Count == 0 && !bApplyAll)
            {
                MessageBox.Show("Please select the target channel in the listview!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                return;
            }
            if (bRet)
            {
                if (bApplyAll)
                {
                    for (int i = 0; i < listViewChInfo_CNT.Items.Count; i++)
                    {
                        if (!m_adamCtl.Counter().SetLocalGateConfiguration(m_idxID, i, chbxGateEnable.Checked, (byte)cbxTriggerMode.SelectedIndex, (byte)cbxGateType.SelectedIndex, cbxLocalGateMapCh.SelectedIndex))
                        {
                            MessageBox.Show("Set gate" + i.ToString() + " configuration failed! ApiErr:" + m_adamCtl.Counter().ApiLastError.ToString() + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                            timer1.Enabled = true;
                            return;
                        }
                    }
                    RefreshCntGateSetting();
                    timer1.Enabled = true;
                    return;
                }
                else
                {
                    for (int i = 0; i < listViewChInfo_CNT.SelectedIndices.Count; i++)
                    {
                        if (!m_adamCtl.Counter().SetLocalGateConfiguration(this.m_idxID, listViewChInfo_CNT.SelectedIndices[i], chbxGateEnable.Checked, (byte)cbxTriggerMode.SelectedIndex, (byte)cbxGateType.SelectedIndex, cbxLocalGateMapCh.SelectedIndex))
                        {
                            MessageBox.Show("Set gate" + listViewChInfo_CNT.SelectedIndices[i].ToString() + " configuration failed! ApiErr:" + m_adamCtl.Counter().ApiLastError.ToString() + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                            timer1.Enabled = true;
                            return;
                        }
                        if (!(m_usRanges[listViewChInfo_CNT.SelectedIndices[i]] == (ushort)ApaxUnknown_InputRange.Up ||
                              m_usRanges[listViewChInfo_CNT.SelectedIndices[i]] == (ushort)ApaxUnknown_InputRange.HighFrequency ||
                              m_usRanges[listViewChInfo_CNT.SelectedIndices[i]] == (ushort)ApaxUnknown_InputRange.LowFrequency ||
                              m_usRanges[listViewChInfo_CNT.SelectedIndices[i]] == (ushort)ApaxUnknown_InputRange.WaveWidth))
                        {
                            int neighborIdx = (listViewChInfo_CNT.SelectedIndices[i] % 2 == 0) ? listViewChInfo_CNT.SelectedIndices[i] + 1 : listViewChInfo_CNT.SelectedIndices[i] - 1;
                            if (!m_adamCtl.Counter().SetLocalGateConfiguration(this.m_idxID, neighborIdx, chbxGateEnable.Checked, (byte)cbxTriggerMode.SelectedIndex, (byte)cbxGateType.SelectedIndex, cbxLocalGateMapCh.SelectedIndex))
                            {
                                MessageBox.Show("Set gate" + listViewChInfo_CNT.SelectedIndices[i].ToString() + " configuration failed! ApiErr:" + m_adamCtl.Counter().ApiLastError.ToString() + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                                timer1.Enabled = true;
                                return;
                            }
                        }
                    }
                    RefreshCntGateSetting();
                    timer1.Enabled = true;
                    return;
                }
            }
        }

        private void btnClrTriger_Click(object sender, EventArgs e)
        {
            try
            {
                uint[] uiInput = new uint[5];
                if (chbxApplyAll_CNT.Checked)
                    uiInput[0] = 0xFF;
                else
                    for (int i = 0; i < listViewChInfo_CNT.SelectedIndices.Count; i++)
                        uiInput[0] |= (uint)(0x1 << listViewChInfo_CNT.SelectedIndices[i]);
                m_adamCtl.Configuration().TOOL_SetCmdWriteReadRet(m_idxID, 0x0078, uiInput);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnApplyFilter_Click(object sender, EventArgs e)
        {
            if (!CheckControllable())
                return;
            try
            {
                if (txtFilter.Text.Length == 0)
                {
                    MessageBox.Show("Please input the CNT Digital filter value between (0~40000 us).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    return;
                }
                double Filter = Convert.ToDouble(txtFilter.Text);
                int iFilter = (Int32)(Filter * 10);
                bool bRet;
                if (iFilter > 400000)
                {
                    MessageBox.Show("Please input the Digital filter value between (0~40000 us).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    return;
                }
                else
                {
                    bRet = m_adamCtl.Counter().SetDigitalFilter(this.m_idxID, iFilter);
                    if (bRet)
                    {
                        if (iFilter == 0)
                        {
                            MessageBox.Show("Digital filter disable", "Information");
                        }
                        else
                        {
                            float fFilter;
                            fFilter = (float)(10000000 / iFilter);
                            MessageBox.Show("Digital filter frequency: " + fFilter.ToString() + " Hz", "Information");
                            RefreshCntSetting();
                        }
                    }
                    else
                        MessageBox.Show("Set digital filter failed! ApiErr:" + m_adamCtl.Counter().ApiLastError.ToString() + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Invalid digital filter value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
        }
        /// <summary>
        /// Double click channel to change value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewChInfo_DO_DoubleClick(object sender, EventArgs e)
        {
            if (!CheckControllable())
                return;
            string strVal = listViewChInfo_DO.Items[listViewChInfo_DO.SelectedIndices[0]].SubItems[2].Text;
            bool bVal = false;
            if (strVal == "True")
                bVal = false;
            else
                bVal = true;
            settingDO_SetTF(bVal);
        }
        private void btnFreqAcqTime_Click(object sender, EventArgs e)
        {
            if (!CheckControllable())
                return;
            try
            {
                int iFreqAcqTime = Convert.ToInt32(txtFreqAcqTime.Text);
                if (iFreqAcqTime < 1 || iFreqAcqTime > 10000)
                {
                    MessageBox.Show("Invalid frequency acquisition time value! (1~10000)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                    return;
                }
                bool bRet = m_adamCtl.Counter().SetFreqAcqTime(this.m_idxID, iFreqAcqTime);
                if (bRet)
                    RefreshCntSetting();
                else
                    MessageBox.Show("Set frequency acquisition time failed! ApiErr:" + m_adamCtl.Counter().ApiLastError.ToString() + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
            catch
            {
                MessageBox.Show("Invalid frequency acquisition time value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnAlarmClear_Click(object sender, EventArgs e)
        {
            if (!CheckControllable())
                return;
            timer1.Enabled = false;
            if (listViewChInfo_DO.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Please select the target channel in the listview!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                timer1.Enabled = true;
                return;
            }
            uint uiMask = 0x00;
            for (int i = 0; i < listViewChInfo_DO.SelectedIndices.Count; i++)
                uiMask |= (uint)(0x01 << listViewChInfo_DO.SelectedIndices[i]);

            if (m_adamCtl.Alarm().ClearAlarmFlags(m_idxID, uiMask))
                RefreshData();
            else
                MessageBox.Show("Clear alarm flags failed! ApiErr:" + m_adamCtl.Alarm().ApiLastError.ToString() + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            timer1.Enabled = true;
        }

        private void btnAlarmClearall_Click(object sender, EventArgs e)
        {
            if (!CheckControllable())
                return;
            timer1.Enabled = false;
            if (listViewChInfo_DO.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Please select the target channel in the listview!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                timer1.Enabled = true;
                return;
            }
            if (m_adamCtl.Alarm().ClearAlarmFlags(m_idxID, 15))   //clear all
                RefreshData();
            else
                MessageBox.Show("Clear alarm flags failed! Err:" + m_adamCtl.Alarm().ApiLastError.ToString() + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
            timer1.Enabled = true;
        }

        private void chbxHide_DO_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Visible = !chbxHide_DO.Checked;
        }

        private void chbxHide_CNT_CheckedChanged(object sender, EventArgs e)
        {
            panel3.Visible = !chbxHide_CNT.Checked;
        }

        private void chbxGateEnable_CheckedChanged(object sender, EventArgs e)
        {
            cbxLocalGateMapCh.Enabled = chbxGateEnable.Checked;
            cbxGateType.Enabled = chbxGateEnable.Checked;
            cbxTriggerMode.Enabled = chbxGateEnable.Checked;
        }

        private void Form_APAX_5080_FormClosing(object sender, FormClosingEventArgs e)
        {
            FreeResource();
        }

    }
}