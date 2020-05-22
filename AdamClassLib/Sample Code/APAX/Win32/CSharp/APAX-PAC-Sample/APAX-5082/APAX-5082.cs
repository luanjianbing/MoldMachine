using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Advantech.Adam;

namespace APAX_5082
{
    public partial class Form_APAX_5082 : Form
    {
        // Global object
        private string APAX_INFO_NAME = "APAX";
        private string DVICE_TYPE = "5082";

        private AdamControl m_adamCtl;
        private Apax5000Config m_aConf;

        private int m_idxID;
        private int m_ScanTime_LocalSys;
        private int m_iFailCount, m_iScanCount;
        private string[] m_szSlots;// Container of all solt device type

        private bool m_bIsEnableSafetyFcn;
        private bool[] m_bDOSafetyVals;
        private int m_DIidx, m_DOidx, m_PWMidx;
        private int m_iDoOffset = 0;
        private bool[] m_bChMask = new bool[AdamControl.APAX_MaxAIOCh];

        public static int DI_FILTER_WIDTH_MAX = 400;
        public static int DI_FILTER_WIDTH_MIN = 5;
        private bool m_bStartFlag = false;

        public Form_APAX_5082()
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
        public Form_APAX_5082(int SlotNum, int ScanTime)
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

            //APAX-5082 is DI and DO and PWM module
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
                    listViewChInfo_DO.BeginUpdate();
                    listViewChInfo_DO.Items.Clear();
                    for (int j = 0; j < m_aConf.HwIoTotal[i]; j++)
                    {
                        ListViewItem lvItem;
                        lvItem = new ListViewItem(_HardwareIOType.DO.ToString());   //Type
                        lvItem.SubItems.Add(j.ToString());  //Ch
                        lvItem.SubItems.Add("*****");       //Value
                        lvItem.SubItems.Add("BOOL");        //Mode
                        lvItem.SubItems.Add("*****");       //Safety Value
                        listViewChInfo_DO.Items.Add(lvItem);
                    }
                    listViewChInfo_DO.EndUpdate();
                }
                else if (m_aConf.HwIoType[i] == (byte)_HardwareIOType.PWM)
                {
                    m_PWMidx = i;
                    listViewChInfo_PWM.BeginUpdate();
                    listViewChInfo_PWM.Items.Clear();
                    for (int j = 0; j < m_aConf.HwIoTotal[i]; j++)
                    {
                        ListViewItem lvItem;
                        lvItem = new ListViewItem(_HardwareIOType.PWM.ToString());   //Type
                        lvItem.SubItems.Add(j.ToString());  //Ch
                        lvItem.SubItems.Add("*****");       //Status
                        lvItem.SubItems.Add("*****");        //Frequency
                        lvItem.SubItems.Add("*****");       //Duty Cycle
                        listViewChInfo_PWM.Items.Add(lvItem);
                    }
                    listViewChInfo_PWM.EndUpdate();
                }
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
            }
            else if (strSelPageName == "PWM")
            {

                iChannelTotal = this.m_aConf.HwIoTotal[m_PWMidx];
                uint[] uiFerquency = new uint[iChannelTotal];
                float[] fDutyCycle = new float[iChannelTotal];
                for (int i = 0; i < iChannelTotal; i++)
                {
                    if (m_adamCtl.Counter().GetChannelConfig((int)m_idxID, (ushort)i, out uiFerquency[i], out fDutyCycle[i]))
                    {
                        listViewChInfo_PWM.Items[i].SubItems[3].Text = uiFerquency[i].ToString();           //Update Frequency column
                        listViewChInfo_PWM.Items[i].SubItems[4].Text = fDutyCycle[i].ToString("0.0");       //Update Duty Cycle column
                    }
                    else
                    {
                        listViewChInfo_PWM.Items[i].SubItems[3].Text = "*****";
                        listViewChInfo_PWM.Items[i].SubItems[4].Text = "*****";
                        StatusBar_IO.Text += "ApiErr:" + m_adamCtl.Counter().ApiLastError.ToString() + " ";
                    }
                }
            }
            return true;
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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            uint uiWidth;
            bool bEnable = true;
            string strSelPageName = tabControl1.TabPages[tabControl1.SelectedIndex].Text;
            StatusBar_IO.Text = "";
            if (strSelPageName == "Module Information")
            {
                m_iFailCount = 0;
                m_iScanCount = 0;
            }
            else if (strSelPageName == "DI")
            {
                //Get DI Filter value
                if (m_adamCtl.DigitalInput().GetDigitalFilterMiniSignalWidth(m_idxID, out uiWidth, out bEnable))
                {
                    txtCntMin.Text = uiWidth.ToString();
                    chkBoxDiFilterEnable.Checked = bEnable;
                }
            }
            else if (strSelPageName == "DO")
            {
                //Refresh safety information
                RefreshSafetySetting();
                chbxEnableSafety.Checked = m_bIsEnableSafetyFcn;
            }
            else if (strSelPageName == "PWM")
            {
                RefreshPwmSetting();
                RefreshPwmSettingFormInfo();
                RefreshPwmChannelMask();
            }

            if (tabControl1.SelectedIndex == 0)
                timer1.Enabled = false;
            else
                timer1.Enabled = true;
        }
        /// <summary>
        /// Refresh Modules's Safety column value for DO module
        /// </summary>
        private void RefreshSafetySetting()
        {
            int iChannelTotal = this.m_aConf.HwIoTotal[m_DOidx];
            if (!m_adamCtl.Configuration().OUT_GetSafetyEnable(m_idxID, out m_bIsEnableSafetyFcn))
            {
                StatusBar_IO.Text += "OUT_GetSafetyEnable(Error:" + m_adamCtl.Configuration().ApiLastError.ToString() + ") Failed! ";
            }
            if (m_bIsEnableSafetyFcn)
            {
                bool[] o_bValues;
                string[] strSafetyValue;
                if (m_adamCtl.DigitalOutput().GetSafetyValues(m_idxID, iChannelTotal, out o_bValues))
                {
                    m_bDOSafetyVals = o_bValues;
                    strSafetyValue = new string[iChannelTotal];
                    for (int i = 0; i < iChannelTotal; i++)
                        listViewChInfo_DO.Items[i].SubItems[4].Text = m_bDOSafetyVals[i].ToString();  //moduify "Safety" column
                }
                else
                    StatusBar_IO.Text += "GetSafetyValues(Error:" + m_adamCtl.DigitalOutput().ApiLastError.ToString() + ") Failed! ";
            }
            else
            {
                for (int i = 0; i < iChannelTotal; i++)
                    listViewChInfo_DO.Items[i].SubItems[4].Text = "Disable";  //moduify "Safety" column
            }
        }
        /// <summary>
        /// Set DI filter -> Minimum low signal width
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnApplySetting_Click(object sender, EventArgs e)
        {
            uint uiWidth = 10;
            bool bDI = this.chkBoxDiFilterEnable.Checked;
            string strCntMin = this.txtCntMin.Text;
            uiWidth = Convert.ToUInt32(strCntMin);
            if (uiWidth > DI_FILTER_WIDTH_MAX || uiWidth < DI_FILTER_WIDTH_MIN)
            {
                MessageBox.Show("Error: Illegal parameter. The range of Di filter width is " + DI_FILTER_WIDTH_MIN.ToString() + "~" + DI_FILTER_WIDTH_MAX + " (0.1ms).\nAnd the width value have to be multiple of 5.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                return;
            }
            if (m_adamCtl.DigitalInput().SetDigitalFilterMiniSignalWidth(m_idxID, uiWidth, bDI))
            {
                if (uiWidth % 5 == 0)
                    MessageBox.Show("Set digital filter width done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                else
                    MessageBox.Show("Set digital filter width done!\nThe width value have to be multiple of 5.\n (" + uiWidth.ToString() + " => " + Convert.ToString(uiWidth - uiWidth % 5) + ")", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            else
            {
                MessageBox.Show("Set digital filter width failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

                return;
            }
        }
        /// <summary>
        /// Set related channels to true status
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTrue_Click(object sender, EventArgs e)
        {
            if (!CheckControllable())
                return;
            settingDO_SetTF(true);
        }
        /// <summary>
        /// Set related channels to false status
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Click Safety Function -> Set Value button, it will pop a window for configuration.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSetSafetyValue_Click(object sender, EventArgs e)
        {
            if (!CheckControllable())
                return;

            timer1.Enabled = false;

            int iChannelTotal = this.m_aConf.HwIoTotal[m_DOidx];

            FormSafetySetting formSafety = new FormSafetySetting(iChannelTotal, m_bDOSafetyVals);
            formSafety.ApplySafetyValueClick += new FormSafetySetting.EventHandler_ApplySafetyValueClick(formSafety_ApplySafetyValueClick);

            formSafety.ShowDialog();
            formSafety.Dispose();
            formSafety = null;
            timer1.Enabled = true;
        }
        /// <summary>
        ///  Apply setting when user configure safety status
        /// </summary>
        /// <param name="bVal"></param>
        private void formSafety_ApplySafetyValueClick(bool[] bVal)
        {
            if (!m_adamCtl.DigitalOutput().SetSafetyValues(m_idxID, bVal))
                MessageBox.Show("Set safety value failed! (Err: " + m_adamCtl.DigitalOutput().ApiLastError.ToString() + ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            else
                MessageBox.Show("Set safety value ok!", "Info");
            RefreshSafetySetting();
        }

        /// <summary>
        /// Update PWM Channel Information "Frequency" and "Duty Cycle" columns
        /// </summary>
        /// <returns></returns>
        private bool RefreshPwmSetting()
        {
            int iChannelTotal = this.m_aConf.HwIoTotal[m_PWMidx];
            uint[] uiFerquency = new uint[iChannelTotal];
            float[] fDutyCycle = new float[iChannelTotal];
            for (int i = 0; i < iChannelTotal; i++)
            {
                if (m_adamCtl.Counter().GetChannelConfig((int)m_idxID, (ushort)i, out uiFerquency[i], out fDutyCycle[i]))
                {
                    listViewChInfo_PWM.Items[i].SubItems[3].Text = uiFerquency[i].ToString();           //Update Frequency column
                    listViewChInfo_PWM.Items[i].SubItems[4].Text = fDutyCycle[i].ToString("0.0");       //Update Duty Cycle column
                }
                else
                {
                    listViewChInfo_PWM.Items[i].SubItems[3].Text = "*****";     //Update Frequency column
                    listViewChInfo_PWM.Items[i].SubItems[4].Text = "*****";     //Update Duty Cycle column
                    StatusBar_IO.Text += "GetChannelConfig(Error:" + m_adamCtl.Counter().ApiLastError.ToString() + ") Failed! ";
                }
            }
            return true;
        }
        /// <summary>
        /// Update PWM channel Setting -> Frequency and DutyCycle
        /// </summary>
        private void RefreshPwmSettingFormInfo()
        {
            int iSelectChannelIndex;
            if (listViewChInfo_PWM.SelectedIndices.Count == 0)
            {
                listViewChInfo_PWM.Items[0].Selected = true;
                iSelectChannelIndex = 0;
            }
            else
            {
                iSelectChannelIndex = listViewChInfo_PWM.SelectedIndices[0];    //selext first
            }
            uint uiFerquency = 0;
            float fDutyCycle = 0;
            if (m_adamCtl.Counter().GetChannelConfig((int)m_idxID, (ushort)iSelectChannelIndex, out uiFerquency, out fDutyCycle))
            {
                txtFrequency.Text = uiFerquency.ToString();
                txtDutyCycle.Text = fDutyCycle.ToString("0.0");
            }
            else
            {
                txtFrequency.Text = "*****";
                txtDutyCycle.Text = "**";
                StatusBar_IO.Text += "GetChannelConfig(Error:" + m_adamCtl.Counter().ApiLastError.ToString() + ") Failed! ";
            }
        }
        /// <summary>
        /// refresh PWM Channel status
        /// </summary>
        private void RefreshPwmChannelMask()
        {
            if (m_adamCtl.Configuration().GetModuleConfig(m_idxID, out m_aConf))
            {
                //refresh PWM Channel status
                string[] strChMask = new string[listViewChInfo_PWM.Items.Count];
                for (int i = 0; i < strChMask.Length; i++)
                {
                    m_bChMask[i] = Convert.ToBoolean(m_aConf.dwChMask & Convert.ToUInt32(1 << i));
                    if (m_bChMask[i])
                        listViewChInfo_PWM.Items[i].SubItems[2].Text = "Start";
                    else
                        listViewChInfo_PWM.Items[i].SubItems[2].Text = "Stop";
                }
            }
        }

        private void btnPwmApplySetting_Click(object sender, EventArgs e)
        {
            if ((txtFrequency.Text.Length > 0) && (txtDutyCycle.Text.Length > 0))
            {
                timer1.Enabled = false;
                bool bRet = true;
                UInt32 uiFreq = 0;
                float fDuty = 0f;
                if (listViewChInfo_PWM.SelectedIndices.Count == 0 && !chbxApplyAll.Checked)
                {
                    MessageBox.Show("Please select the target channel in the listview!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    bRet = false;
                }
                if (bRet)
                {
                    try
                    {
                        uiFreq = Convert.ToUInt32(txtFrequency.Text);
                        if (uiFreq < 1 || uiFreq > 30000)
                            throw new Exception();
                    }
                    catch
                    {
                        MessageBox.Show("The Frequency is invalid! This value must be between 1 ~ 30000 !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                        bRet = false;
                    }
                }
                if (bRet)
                {
                    try
                    {
                        fDuty = Convert.ToSingle(txtDutyCycle.Text);
                        if (fDuty < 0.1f || fDuty > 99.9f)
                            throw new Exception();
                    }
                    catch
                    {
                        MessageBox.Show("The Duty Cycle is invalid! This value must be between 0.1 ~ 99.9 !!", "Error");
                        bRet = false;
                    }
                }

                if (bRet)
                {
                    for (int i = 0; i < listViewChInfo_PWM.Items.Count; i++)
                    {

                        if (chbxApplyAll.Checked)
                        {
                            if (m_adamCtl.Counter().SetChannelConfig(this.m_idxID, (ushort)i, uiFreq, fDuty))
                            {
                                RefreshPwmSetting();
                                MessageBox.Show("Set Channel Config done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                            }
                            else
                            {
                                MessageBox.Show("Set Channel Config failed! ApiErr:" + m_adamCtl.Counter().ApiLastError.ToString() + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                                break;
                            }
                        }
                        else
                        {
                            if (listViewChInfo_PWM.Items[i].Selected)
                            {
                                if (m_adamCtl.Counter().SetChannelConfig(this.m_idxID, (ushort)i, uiFreq, fDuty))
                                {
                                    RefreshPwmSetting();
                                    MessageBox.Show("Set Channel Config done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                                }
                                else
                                {
                                    MessageBox.Show("Set Channel Config failed! ApiErr:" + m_adamCtl.Counter().ApiLastError.ToString() + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                                    break;
                                }
                            }
                        }
                    }
                }
                timer1.Enabled = true;
            }
            else
            {
                MessageBox.Show("Frequency or Duty Cycle input value can't be empty.", "Warnning");
            }
        }

        private void btnMaskEnable_Click(object sender, EventArgs e)
        {
            settingPWM_MaskSetting(true, chbxApplyAll.Checked);
        }

        private void btnMaskDisable_Click(object sender, EventArgs e)
        {
            settingPWM_MaskSetting(false, chbxApplyAll.Checked);
        }
        /// <summary>
        /// Set PWM channel setting -> Output status
        /// </summary>
        /// <param name="bEnable"></param>
        /// <param name="i_bApplyAll"></param>
        private void settingPWM_MaskSetting(bool bEnable, bool i_bApplyAll)
        {
            if (!CheckControllable())
                return;
            timer1.Enabled = false;
            bool bRet = true;
            if (listViewChInfo_PWM.SelectedIndices.Count == 0 && !i_bApplyAll)
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
                        bChMask[i] = bEnable;
                }
                else
                {
                    for (int i = 0; i < listViewChInfo_PWM.SelectedIndices.Count; i++)
                        bChMask[listViewChInfo_PWM.SelectedIndices[i]] = bEnable;
                }
                for (int i = 0; i < listViewChInfo_PWM.Items.Count; i++)
                {
                    if (bChMask[i])
                        uiMask |= ((uint)1 << i);
                }
                if (m_adamCtl.Counter().SetChannelEnabled(this.m_idxID, uiMask))
                {
                    RefreshPwmChannelMask();
                    string strOut = "Set Channel " + (bEnable ? "Start" : "Stop") + " done!";
                    MessageBox.Show(strOut, "Information");
                }
                else
                {
                    string strOut = "Set Channel " + (bEnable ? "Start" : "Stop") + " failed! Err:" + m_adamCtl.Counter().ApiLastError.ToString() + "";
                    MessageBox.Show(strOut, "Error");
                }
            }
            timer1.Enabled = true;
        }

        private void Form_APAX_5082_FormClosing(object sender, FormClosingEventArgs e)
        {
            FreeResource();
        }

        private void chbxHide_PWM_CheckedChanged(object sender, EventArgs e)
        {
            panel3.Visible = !chbxHide_PWM.Checked;
        }

        private void chbxHide_DO_CheckedChanged(object sender, EventArgs e)
        {
            panel2.Visible = !chbxHide_DO.Checked;
        }

        private void chbxHide_DI_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Visible = !chbxHide_DI.Checked;
        }

        private void chbxEnableSafety_CheckedChanged(object sender, EventArgs e)
        {
            btnSetSafetyValue.Enabled = chbxEnableSafety.Checked;
            if (!CheckControllable())
                return;

            if (!m_adamCtl.Configuration().OUT_SetSafetyEnable(m_idxID, chbxEnableSafety.Checked))
                MessageBox.Show("Set safety function failed! (Err: " + m_adamCtl.Configuration().ApiLastError.ToString() + ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);

            RefreshSafetySetting();
        }


    }
}