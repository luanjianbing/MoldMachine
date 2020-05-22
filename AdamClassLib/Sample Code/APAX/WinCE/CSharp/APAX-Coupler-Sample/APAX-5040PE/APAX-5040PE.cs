using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Net.Sockets;
using Advantech.Adam;
using Apax_IO_Module_Library;

namespace APAX_5040PE
{
    public partial class Form_APAX_5040PE : Form
    {
         // Global object
        const string APAX_INFO_NAME = "APAX";
        const string  DVICE_TYPE = "5040PE";

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
        private string[] m_szSlots;// Container of all solt device type

        public static int DI_FILTER_WIDTH_MAX = 400;
        public static int DI_FILTER_WIDTH_MIN = 10;
        private bool m_bStartFlag = false;
        private ushort m_usStart;
        private ushort m_usLength;

        public Form_APAX_5040PE()
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

        public Form_APAX_5040PE(string IP, int SlotNum, int ScanTime, AdamType i_adamType)
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
                    throw new System.Exception("Get"+ DVICE_TYPE + " Device Configuration Fail.");
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
                for (iLoop = 0; iLoop< m_szSlots.Length; iLoop++)
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
        ///  Initial every tab of I/O modules Information
        /// </summary>
        /// <param name="aConf">apax 5000 device object</param>
        private void InitialDataTabPages( )
        {
            int i = 0, idx = 0;
            byte type = (byte)_HardwareIOType.DI;   //APAX-5040 is DI module
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
                lvItem = new ListViewItem(_HardwareIOType.DI.ToString());   //Type
                lvItem.SubItems.Add(i.ToString());      //Ch
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
                lvItem.SubItems.Add("*****");           //Value
                lvItem.SubItems.Add("BOOL");            //Mode
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
                MessageBox.Show("Failed more than 5 times! Please check the physical connection and MODBUS address setting!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
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
            bool[] bVal;
            iChannelTotal = this.m_aConf.HwIoTotal[m_tmpidx];
            if (!m_adamSocket.DigitalInput().GetValues(m_idxID, iChannelTotal, out bVal))
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
        private void chbxHide_DI_CheckStateChanged(object sender, EventArgs e)
        {
            panel2.Visible = !chbxHide_DI.Checked;
        }
        /// <summary>
        /// When change tab, refresh status, timer, counter related informations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            uint uiWidth;
            bool bEnable = true;
            string strSelPageName = tabControl1.TabPages[tabControl1.SelectedIndex].Text;
            StatusBar_IO.Text = "";

            m_adamSocket.Disconnect();
            m_adamSocket.Connect(m_adamSocket.GetIP(), protoType, portNum);

            if (strSelPageName == "Module Information")
            {
                m_iFailCount = 0;
                m_iScanCount = 0;
            }
            else if (strSelPageName == "DI")
            {
                //Get DI Filter value
                if (m_adamSocket.DigitalInput().GetDigitalFilterMiniSignalWidth(m_idxID, out uiWidth, out bEnable))
                {
                    txtCntMin.Text = uiWidth.ToString();
                    chkBoxDiFilterEnable.Checked = bEnable;
                }
            }

            if (tabControl1.SelectedIndex == 0)
                timer1.Enabled = false;
            else
                timer1.Enabled = true;
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
            if (m_adamSocket.DigitalInput().SetDigitalFilterMiniSignalWidth(m_idxID, uiWidth, bDI))
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

        private void Form_APAX_5040PE_Closing(object sender, CancelEventArgs e)
        {
            FreeResource();
        }

    }
}