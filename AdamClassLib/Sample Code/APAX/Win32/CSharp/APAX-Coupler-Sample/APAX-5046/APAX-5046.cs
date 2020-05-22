using System;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using Advantech.Adam;
using Apax_IO_Module_Library;

namespace APAX_5046
{
    public partial class Form_APAX_5046 : Form
    {
        // Global object
        const string APAX_INFO_NAME = "APAX";
        const string DVICE_TYPE = "5046";

        private AdamSocket m_adamSocket;
        int[] m_iTimeout;
        string m_szIP = "";

        private Apax5000Config m_aConf;
        private int m_idxID;
        private int m_ScanTime_LocalSys;
        private AdamType m_adamType = AdamType.Apax5070;
        private ProtocolType protoType = ProtocolType.Tcp;
        private int portNum = 502;

        private int m_iFailCount, m_iScanCount;
        private int m_tmpidx;
        private bool m_bIsEnableSafetyFcn;
        private bool[] m_bDOSafetyVals;
        private string[] m_szSlots;// Container of all solt device type

        private bool m_bStartFlag = false;
        private ushort m_usStart;
        private ushort m_usLength;

        public Form_APAX_5046()
        {
            InitializeComponent();
            m_szSlots = null;
            m_iScanCount = 0;
            m_iFailCount = 0;
            m_idxID = -1; // Set in invalid num 
            m_ScanTime_LocalSys = 500;// Scan time default 500 ms
            timer1.Interval = m_ScanTime_LocalSys;
            m_iTimeout = new int[3];
            m_iTimeout[0] = 2000; // Connection Timeout    
            m_iTimeout[1] = 2000; // Send Timeout
            m_iTimeout[2] = 2000;// Receive Timeout
            this.StatusBar_IO.Text = ("Start to demo "
                        + (APAX_INFO_NAME + ("-"
                        + (DVICE_TYPE + " by clicking \'Start\' button."))));
        }

        public Form_APAX_5046(string IP, int SlotNum, int ScanTime, AdamType i_adamType)
        {
            InitializeComponent();
            m_szSlots = null;
            m_idxID = SlotNum; // Set Slot_ID
            m_iScanCount = 0;
            m_iFailCount = 0;
            m_ScanTime_LocalSys = ScanTime;// Scan time
            m_adamType = i_adamType;
            if (m_adamType == AdamType.Apax5070)
            {
                protoType = ProtocolType.Tcp;
                portNum = 502;
            }
            else
            {
                protoType = ProtocolType.Udp;
                portNum = 5048;
            }

            timer1.Interval = m_ScanTime_LocalSys;
            m_iTimeout = new int[3];
            m_iTimeout[0] = 2000;// Connection Timeout    
            m_iTimeout[1] = 2000;// Send Timeout
            m_iTimeout[2] = 2000;// Receive Timeout
            m_szIP = IP;

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

                m_adamSocket.Configuration().SYS_SetLocateModule(m_idxID, 0);
                m_adamSocket.Disconnect();
                m_adamSocket = null;
            }
            return true;
        }
        private void formIP_ApplyIPAddressClick(string strIP)
        {
            m_szIP = strIP;
        }

        public bool SetIp()
        {
            int count = 0;
            while (((count <= 2) && (m_szIP == "")))
            {
                IPForm formIP = new IPForm();
                formIP.ApplyIPAddressClick += new IPForm.EventHandler_ApplyIPAddressClick(formIP_ApplyIPAddressClick);
                formIP.ShowDialog();
                formIP.Dispose();
                formIP = null;
                count++;
            }
            if ((m_szIP == null))
            {
                return false;
            }
            return true;
        }
        public bool StartRemote()
        {
            if ((m_szIP == ""))
            {
                if (!SetIp())
                {
                    MessageBox.Show("Demo failed! Please set up IP address.", "Error");
                    return false;
                }
            }
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
        public bool OpenDevice()
        {
            m_adamSocket = new AdamSocket(m_adamType);
            m_adamSocket.SetTimeout(m_iTimeout[0], m_iTimeout[1], m_iTimeout[2]);
            if (m_adamSocket.Connect(m_szIP, protoType, portNum))
            {
                if (!m_adamSocket.Configuration().GetSlotInfo(out m_szSlots))
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
            else if ((string.Compare(m_szSlots[m_idxID], 0, DVICE_TYPE, 0, DVICE_TYPE.Length) == 0) && (m_szSlots[m_idxID].Length == 4))
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
        /// <summary>
        /// APAX I/O module information init function
        /// </summary>
        /// <returns></returns>
        public bool RefreshConfiguration()
        {


            if (m_adamSocket.Configuration().GetModuleConfig(m_idxID, out m_aConf))
            {

                txtModule.Text = m_aConf.GetModuleName();       //Information-> Module
                txtID.Text = m_idxID.ToString();                //Information -> Switch ID
                txtSupportKernelFw.Text = m_aConf.wSupportFwVer.ToString("X04").Insert(2, ".");     //Information -> Support kernel Fw
                txtFwVer.Text = m_aConf.wFwVerNo.ToString("X04").Insert(2, ".");                    //Firmware version
                RefreshModbusAddressSetting();
            }
            else
            {
                StatusBar_IO.Text = " GetModuleConfig(Error:" + m_adamSocket.Configuration().LastError.ToString() + ") Failed! ";
                return false;
            }
            return true;
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

            if (!m_adamSocket.Configuration().OUT_SetSafetyEnable(m_idxID, chbxEnableSafety.Checked))
                MessageBox.Show("Set safety function failed! (Err: " + m_adamSocket.Modbus().LastError.ToString() + ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);

            RefreshSafetySetting();
        }
        /// <summary>
        /// Init Channel Information
        /// </summary>
        /// <param name="m_aConf">apax 5000 device object</param>
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
                if (m_adamType == AdamType.Apax5070)
                {
                    if (m_usStart > 40000)
                    {                 //modbus address
                        string szTmp = Convert.ToString(m_usStart + i / 16) + "[" + Convert.ToString(i % 16) + "]";
                        lvItem.SubItems.Add(szTmp);
                    }
                    else
                    {
                        string szTmp = string.Format("{0:D5}", m_usStart + i);
                        lvItem.SubItems.Add(szTmp);
                    }
                }
                else
                {
                    lvItem.SubItems.Add("*****");
                }
                lvItem.SubItems.Add("*****");       //Value
                lvItem.SubItems.Add("BOOL");        //Mode
                lvItem.SubItems.Add("*****");       //Safety Value
                listViewChInfo.Items.Add(lvItem);
            }
            
            listViewChInfo.EndUpdate();
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
            if (!m_adamSocket.DigitalOutput().GetValues(m_idxID, iChannelTotal, out bVal))
            {
                StatusBar_IO.Text += "ApiErr:" + m_adamSocket.Modbus().LastError.ToString() + " ";
                return false;
            }
            for (int i = 0; i < bVal.Length; i++)
            {
                listViewChInfo.Items[i].SubItems[3].Text = bVal[i].ToString();  //moduify "Value" column
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
            m_adamSocket.Disconnect();
            m_adamSocket.Connect(m_adamSocket.GetIP(), protoType, portNum);
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
                btnSetSafetyValue.Enabled = m_bIsEnableSafetyFcn;
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
            if (!m_adamSocket.Configuration().OUT_GetSafetyEnable(m_idxID, out m_bIsEnableSafetyFcn))
            {
                StatusBar_IO.Text += "OUT_GetSafetyEnable(Error:" + m_adamSocket.Modbus().LastError.ToString() + ") Failed! ";
            }
            if (m_bIsEnableSafetyFcn)
            {
                bool[] o_bValues;
                string[] strSafetyValue;
                if (m_adamSocket.DigitalOutput().GetSafetyValues(m_idxID, iChannelTotal, out o_bValues))
                {
                    m_bDOSafetyVals = o_bValues;
                    strSafetyValue = new string[iChannelTotal];
                    for (int i = 0; i < iChannelTotal; i++)
                        listViewChInfo.Items[i].SubItems[5].Text = m_bDOSafetyVals[i].ToString();  //moduify "Safety" column
                }
                else
                    StatusBar_IO.Text += "GetSafetyValues(Error:" + m_adamSocket.Modbus().LastError.ToString() + ") Failed! ";
            }
            else
            {
                for (int i = 0; i < iChannelTotal; i++)
                    listViewChInfo.Items[i].SubItems[5].Text = "Disable";  //moduify "Safety" column
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
            if (m_adamSocket.Configuration().SYS_GetGlobalActive(out active))
            {
                if (active == 1)
                    return true;
                else
                {
                    MessageBox.Show("There is another controller taking control, so you only can monitor IO data.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                    return false;
                }
            }
            else if (m_adamSocket.Modbus().LastError == Advantech.Common.ErrorCode.Socket_Recv_Fail)
                MessageBox.Show("SYS_GetGlobalActive failed (Err: " + m_adamSocket.Modbus().LastError.ToString() + ")", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            else
                MessageBox.Show("Checking controllable failed, utility only could monitor io data now. (" + m_adamSocket.Modbus().LastError.ToString() + ")", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
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
                    if (m_adamSocket.DigitalOutput().SetValue(m_idxID, listViewChInfo.SelectedIndices[i], bState))
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
            if (!m_adamSocket.DigitalOutput().SetSafetyValues(m_idxID, bVal))
                MessageBox.Show("Set safety value failed! (Err: " + m_adamSocket.Modbus().LastError.ToString() + ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
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
            string strVal = listViewChInfo.Items[listViewChInfo.SelectedIndices[0]].SubItems[3].Text;
            bool bVal = false;
            if (strVal == "True")
                bVal = false;
            else
                bVal = true;
            settingDO_SetTF(bVal);
        }

        private void RefreshModbusAddressSetting()
        {
            bool bFixed;

            m_adamSocket.Configuration().GetModbusAddressMode(out bFixed);
            if (bFixed)
            {
                if (m_aConf.wDevType == (ushort)_DeviceType.DigitalInput || m_aConf.wDevType == (ushort)_DeviceType.DigitalOutput)
                {
                    m_usStart = Convert.ToUInt16(64 * m_idxID + 1); //64(Coils, bit) is Slot shift, please reference Modbus/TCP address mapping table(0x)
                    m_usLength = m_aConf.byChTotal;
                }
                else if (m_aConf.wDevType == (ushort)_DeviceType.AnalogInput || m_aConf.wDevType == (ushort)_DeviceType.AnalogOutput)
                {
                    m_usStart = Convert.ToUInt16(32 * m_idxID + 40001); //32(Registers, 2 bytes) is Slot shift, please reference Modbus/TCP address mapping table(4x)
                    m_usLength = m_aConf.byChTotal;
                }
                else if (m_aConf.wDevType == (ushort)_DeviceType.Counter || m_aConf.wDevType == (ushort)_DeviceType.PWM)
                {
                    m_usStart = Convert.ToUInt16(32 * m_idxID + 40001);
                    m_usLength = Convert.ToUInt16(m_aConf.byHwIoTotal_2 * 2 + 1); //per counter channel use 2 Registers(= 4 bytes)
                }
            }
            else
            {
                int o_iStartAddr, o_iLength;
                if (m_adamSocket.Configuration().GetModbusAddressConfig(m_idxID, out o_iStartAddr, out o_iLength))
                {
                    m_usStart = Convert.ToUInt16(o_iStartAddr);
                    m_usLength = Convert.ToUInt16(o_iLength);
                }
            }
        }
        private void btnLocate_Click(object sender, EventArgs e)
        {
            if (btnLocate.Text == "Enable")
            {
                if (m_adamSocket.Configuration().SYS_SetLocateModule(m_idxID, 255))
                    btnLocate.Text = "Disable";
                else
                    MessageBox.Show("Locate module failed!", "Error");
            }
            else
            {
                if (m_adamSocket.Configuration().SYS_SetLocateModule(m_idxID, 0))
                    btnLocate.Text = "Enable";
                else
                    MessageBox.Show("Locate module failed!", "Error");
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
                    m_szIP = "";
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
     
        private void chbxEnableSafety_CheckStateChanged(object sender, EventArgs e)
        {
            btnSetSafetyValue.Enabled = chbxEnableSafety.Checked;
            if (!CheckControllable())
                return;

            if (!m_adamSocket.Configuration().OUT_SetSafetyEnable(m_idxID, chbxEnableSafety.Checked))
                MessageBox.Show("Set safety function failed! (Err: " + m_adamSocket.Modbus().LastError.ToString() + ")", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);

            RefreshSafetySetting();
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
                MessageBox.Show("Failed more than 5 times! Please check the physical connection and MODBUS address setting!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);

            }
            if (m_iScanCount % 50 == 0)
                GC.Collect();
        }

        private void chbxHide_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Visible = !chbxHide.Checked;
        }

        private void Form_APAX_5046_FormClosing(object sender, FormClosingEventArgs e)
        {
            FreeResource();
        }

    }
}