using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Advantech.Adam;

namespace APAX_5046SO
{
    public partial class Form_APAX_5046SO : Form
    {
        // Global object
        private string APAX_INFO_NAME = "APAX";
        private string DVICE_TYPE = "5046SO";

        private AdamControl m_adamCtl;
        private Apax5000Config m_aConf;

        private int m_idxID;
        private int m_ScanTime_LocalSys;
        private int m_iFailCount, m_iScanCount;
        private int m_tmpidx;
        private bool m_bIsEnableSafetyFcn;
        private bool[] m_bDOSafetyVals;

        private string[] m_szSlots;// Container of all solt device type
        private bool m_bStartFlag;

        public Form_APAX_5046SO()
        {
            InitializeComponent();
            m_szSlots = null;
            m_iScanCount = 0;
            m_iFailCount = 0;
            m_bStartFlag = false;
            m_idxID = -1; // Set in invalid num 
            m_ScanTime_LocalSys = 500;// Scan time default 500 ms
            timer1.Interval = m_ScanTime_LocalSys;
            this.StatusBar_IO.Text = ("Start to demo "
                        + (APAX_INFO_NAME + ("-"
                        + (DVICE_TYPE + " by clicking \'Start\' button."))));
        }
        public Form_APAX_5046SO(int SlotNum, int ScanTime)
        {
            InitializeComponent();
            m_szSlots = null;
            m_idxID = SlotNum; // Set Slot_ID
            m_iScanCount = 0;
            m_iFailCount = 0;
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
                    if ((string.Compare(m_szSlots[iLoop], 0, DVICE_TYPE, 0, DVICE_TYPE.Length) == 0) && (m_szSlots[iLoop].Length == 6))
                    {
                        iDeviceNum++;
                        if ((iDeviceNum == 1))// Record first find device
                        {

                            m_idxID = iLoop;// Get DVICE_TYPE Solt

                        }
                    }
                }
            }
            else if ((string.Compare(m_szSlots[m_idxID], 0, DVICE_TYPE, 0, DVICE_TYPE.Length) == 0) && (m_szSlots[m_idxID].Length == 6))
            {
                iDeviceNum++;
            }

            if ((iDeviceNum == 1))
            {
                return true;
            }
            else if ((iDeviceNum > 1))
            {
                string szMsg = "Found " + iDeviceNum.ToString() + DVICE_TYPE + " devices." + " It's will demo Solt " + m_idxID.ToString() + ".";
                MessageBox.Show("Found " + iDeviceNum.ToString() + DVICE_TYPE + " devices." + " It's will demo Solt " + m_idxID.ToString() + ".", "Warning");
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
                    throw new System.Exception("Find " + DVICE_TYPE + "Device Fail.");
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
                txtModule.Text = m_aConf.GetModuleName();       //Information-> Module
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

        private void btnEnableLocate_Click(object sender, EventArgs e)
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
        /// Init Channel Information
        /// </summary>
        /// <param name="aConf">apax 5000 device object</param>
        private void InitialDataTabPages()
        {
            int i = 0, idx = 0;
            byte type = (byte)_HardwareIOType.DO;   //APAX-5046 is DO module
            ListViewItem lvItem;

            for (i = 0; i < m_aConf.HwIoType.Length; i++)
            {
                if (m_aConf.HwIoType[i] == type)
                    idx = i;
            }
            m_tmpidx = idx;
            listViewChInfo.BeginUpdate();
            listViewChInfo.Items.Clear();
            for (i = 0; i < m_aConf.HwIoTotal[idx]; i++)
            {
                lvItem = new ListViewItem(_HardwareIOType.DO.ToString());   //Type
                lvItem.SubItems.Add(i.ToString());  //Ch
                lvItem.SubItems.Add("*****");       //Value
                lvItem.SubItems.Add("BOOL");        //Mode
                lvItem.SubItems.Add("*****");       //Safety Value
                listViewChInfo.Items.Add(lvItem);
            }
            listViewChInfo.EndUpdate();
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
        /// Refresh DO Channel Information "Value" column
        /// </summary>
        /// <returns></returns>
        private bool RefreshData()
        {
            int iChannelTotal = 0;
            bool[] bVal;

            iChannelTotal = this.m_aConf.HwIoTotal[m_tmpidx];
            if (!m_adamCtl.DigitalOutput().GetValues(m_idxID, iChannelTotal, out bVal))
            {
                StatusBar_IO.Text += "ApiErr:" + m_adamCtl.DigitalOutput().ApiLastError.ToString() + " ";
                return false;
            }
            for (int i = 0; i < bVal.Length; i++)
            {
                listViewChInfo.Items[i].SubItems[2].Text = bVal[i].ToString();  //moduify "Value" column
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
            else if (strSelPageName == "DO")
            {
                //Refresh safety information
                RefreshSafetySetting();
                chbxEnableSafety.Checked = m_bIsEnableSafetyFcn;
            }

            if (tabControl1.SelectedIndex == 0)
                this.timer1.Enabled = false;
            else
                this.timer1.Enabled = true;
        }
        /// <summary>
        /// Refresh Modules's Safety column value
        /// </summary>
        private void RefreshSafetySetting()
        {
            int iChannelTotal = this.m_aConf.HwIoTotal[m_tmpidx];
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
                        listViewChInfo.Items[i].SubItems[4].Text = m_bDOSafetyVals[i].ToString();  //moduify "Safety" column
                }
                else
                    StatusBar_IO.Text += "GetSafetyValues(Error:" + m_adamCtl.DigitalOutput().ApiLastError.ToString() + ") Failed! ";
            }
            else
            {
                for (int i = 0; i < iChannelTotal; i++)
                    listViewChInfo.Items[i].SubItems[4].Text = "Disable";  //moduify "Safety" column
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
            if (listViewChInfo.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Please select the target channel in the listview!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                timer1.Enabled = true;
                return;
            }
            else
            {
                for (int i = 0; i < listViewChInfo.SelectedIndices.Count; i++)
                {
                    if (m_adamCtl.DigitalOutput().SetValue(m_idxID, listViewChInfo.SelectedIndices[i], bState))
                        RefreshData();
                    else
                        MessageBox.Show("Set digital output failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                }
            }
            timer1.Enabled = true;
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

            int iChannelTotal = this.m_aConf.HwIoTotal[m_tmpidx];

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
        /// Double click channel to change value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewChInfo_DoubleClick(object sender, EventArgs e)
        {
            if (!CheckControllable())
                return;
            string strVal = listViewChInfo.Items[listViewChInfo.SelectedIndices[0]].SubItems[2].Text;
            bool bVal = false;
            if (strVal == "True")
                bVal = false;
            else
                bVal = true;
            settingDO_SetTF(bVal);
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

        private void chbxEnableSafety_CheckStateChanged(object sender, EventArgs e)
        {
            btnSetSafetyValue.Enabled = chbxEnableSafety.Checked;
            if (!CheckControllable())
                return;

            if (!m_adamCtl.Configuration().OUT_SetSafetyEnable(m_idxID, chbxEnableSafety.Checked))
                MessageBox.Show("Set safety function failed! (Err: " + m_adamCtl.LastError.ToString() + ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);

            RefreshSafetySetting();
        }

        private void chbxHide_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Visible = !chbxHide.Checked;
        }
        /// <summary>
        /// If checkbox disable, it will disable all safety value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chbxEnableSafety_CheckedChanged(object sender, EventArgs e)
        {
             
            btnSetSafetyValue.Enabled = chbxEnableSafety.Checked;
            if (!CheckControllable())
                return;

            if (!m_adamCtl.Configuration().OUT_SetSafetyEnable(m_idxID, chbxEnableSafety.Checked))
                MessageBox.Show("Set safety function failed! (Err: " + m_adamCtl.Configuration().ApiLastError.ToString() + ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);

            RefreshSafetySetting();
        }

        private void Form_APAX_5046SO_FormClosing(object sender, FormClosingEventArgs e)
        {
            FreeResource();
        }

    }
}