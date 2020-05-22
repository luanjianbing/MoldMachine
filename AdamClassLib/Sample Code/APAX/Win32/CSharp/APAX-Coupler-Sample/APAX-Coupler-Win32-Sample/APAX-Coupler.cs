using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;
using Advantech.Adam;
using Apax_IO_Module_Library;
using APAX_5013;
using APAX_5017;
using APAX_5017H;
using APAX_5017PE;
using APAX_5018;
using APAX_5028;
using APAX_5040;
using APAX_5040PE;
using APAX_5045;
using APAX_5046;
using APAX_5046SO;
using APAX_5060;
using APAX_5060PE;
using APAX_5080;
using APAX_5082;
using APAX_5090;

namespace APAX_Coupler_Win32_Sample
{
    public partial class Form_APAX_Coupler : Form
    {
       
        //===================
        // user configuration
        //   APAX-5070: AdamType.Apax5070
        //   APAX-5071: AdamType.Apax5071
        //   APAX-5072: AdamType.Apax5072
        //===================
        private AdamType adamType = AdamType.Apax5070;

        // Global object
        private AdamSocket m_adamModbusSocket;
        private int[] m_ScanTime_LocalSys;
        private int[] m_iTimeout;
        private string m_szIP = "";
        
        private ProtocolType protoType = ProtocolType.Tcp;
        private int portNum = 502;
        public string[] m_szSlotInfo;
        private List<int> m_listIndexOfApax5090;
        private int[][] m_iApax5090TcpPorVals;

        private ArrayList m_adamList_Group;
        private AdamInformation m_adamObject;
        string m_sDSPFWVer;

        public static int IDX_SWITCHID = 0;
        public static int IDX_MODULENAME = 1;
        public static int IDX_ADDRESSTYPE = 2;
        public static int IDX_STARTADDRESS = 3;
        public static int IDX_LENGTH = 4;

        private const int ASCII_CMD_UDP_PORT = 1025;
        private const char STAR_CHAR = '*';
        private const string APAX_INFO_NAME = "APAX";
        private const string APAX_5013_STR = "5013";
        private const string APAX_5017_STR = "5017";
        private const string APAX_5017H_STR = "5017H";
        private const string APAX_5017PE_STR = "5017PE";
        private const string APAX_5018_STR = "5018";
        private const string APAX_5028_STR = "5028";
        private const string APAX_5040_STR = "5040";
        private const string APAX_5040PE_STR = "5040PE";
        private const string APAX_5045_STR = "5045";
        private const string APAX_5046_STR = "5046";
        private const string APAX_5046SO_STR = "5046SO";
        private const string APAX_5060_STR = "5060";
        private const string APAX_5060PE_STR = "5060PE";
        private const string APAX_5080_STR = "5080";
        private const string APAX_5082_STR = "5082";
        private const string APAX_5090_STR = "5090"; //Only support APAX-5070 (BE Version)

        private readonly string[] APAX_COUPLER_SUPPORT_MODULE 
                   = new string[] { 
                                            APAX_5013_STR, APAX_5017_STR, APAX_5017H_STR, APAX_5017PE_STR, APAX_5018_STR, 
                                            APAX_5028_STR, 
                                            APAX_5040_STR, APAX_5040PE_STR, APAX_5045_STR, 
                                            APAX_5046_STR, APAX_5046SO_STR, APAX_5060_STR, APAX_5060PE_STR,
                                            APAX_5080_STR, APAX_5082_STR,
                                            APAX_5090_STR 
                                          };

        private readonly string[] InvalidModbusSettingApaxModule = new string[] { APAX_5090_STR };

        public bool IsModuleSupportModbusSetting(string szModuleName)
        {
            bool bRet = true;
            int intPos = Array.IndexOf(InvalidModbusSettingApaxModule, szModuleName);
            if (intPos > -1)
            {
                bRet = false;
            }
            return bRet;
        }

        public Form_APAX_Coupler()
        {
            InitializeComponent();

            // scan timer init
            m_ScanTime_LocalSys = new int[1];
            m_ScanTime_LocalSys[0] = 1000;
            m_adamModbusSocket = null;
            m_iTimeout = new int[3];
            m_iTimeout[0] = 2000;// Connection Timeout     
            m_iTimeout[1] = 2000; // Send Timeout
            m_iTimeout[2] = 2000;// Receive Timeout

            if (adamType == AdamType.Apax5070)
            {
                protoType = ProtocolType.Tcp;
                portNum = 502;
                panelFSVSetting.Visible = true;
            }
            else
            {
                protoType = ProtocolType.Udp;
                portNum = 5048;
                panelFSVSetting.Visible = false;
                this.tabControl1.Controls.Remove(this.tabAddressSetting);
                this.tabControl1.TabPages.Remove(this.tabSerial);
            }

            listViewComPortInfo.Items.Clear();
        }
        /// <summary>
        /// Refresh I/O modules of this controller and show controller information
        /// </summary>
        /// <param name="e"></param>
        private void AfterSelect_CouplerDevice(TreeNode e)
        {
            TreeNode adamNode;

            m_adamModbusSocket = new AdamSocket(adamType);
            m_adamModbusSocket.SetTimeout(m_iTimeout[0], m_iTimeout[1], m_iTimeout[2]);
            if (m_adamModbusSocket.Connect(m_szIP, protoType, portNum))
            {
                if (m_adamModbusSocket.RefreshIOInfo())
                {
                    Thread waitThread = new Thread(ShowWaitMsg);
                    waitThread.Start();
                    m_adamModbusSocket.Configuration().GetSlotInfo(out m_szSlotInfo);
                    //
                    treeView1.BeginUpdate();
                    e.Nodes.Clear();
                    for (int iCnt = 0; iCnt < m_szSlotInfo.Length; iCnt++)
                    {
                        if (m_szSlotInfo[iCnt] != null)
                        {
                            adamNode = new TreeNode(m_szSlotInfo[iCnt] + "(S" + iCnt.ToString() + ")");
                            adamNode.Tag = (byte)iCnt;
                            e.Nodes.Add(adamNode);
                        }
                    }
                    e.ExpandAll();
                    treeView1.EndUpdate();
                    m_adamModbusSocket.GetDSPFWVer(ref m_sDSPFWVer);
                    m_adamModbusSocket.Disconnect();
                }
            }
            else
            {
                MessageBox.Show("Connection error ( Err : " + m_adamModbusSocket.LastError.ToString() + " ). Please check the network setting.", "Error");
                m_adamModbusSocket.Disconnect();
                m_adamModbusSocket = null;
                return;

            }

            RefreshConfiguration();
            m_adamModbusSocket = null;          
        }

        private bool IsApaxCouplerSupportModule(string szModuleName)
        {
            bool bRet = false;
            int intPos = Array.IndexOf(APAX_COUPLER_SUPPORT_MODULE, szModuleName);
            if (intPos > -1)
            {
                bRet = true;
            }
            return bRet;
        }

        private void ShowWaitMsg(object param)
        {
            Wait_Form FormWait = new Wait_Form();
            FormWait.Start_Wait(3000);
            FormWait.ShowDialog();
            FormWait.Dispose();
            FormWait = null;
        }
        /// <summary>
        /// When select any I/O Modules, show related APAX I/O module at rignt Form
        /// </summary>
        /// <param name="e"></param>
        private void AfterSelect_CouplerSlot(TreeNode e)
        {
            string strSelectModuleId = string.Empty;
            int iSlot;
            iSlot = Convert.ToInt32(e.Tag);
            Form apaxModule;
            strSelectModuleId = m_szSlotInfo[iSlot].ToUpper();

            if ((MessageBox.Show("Do you want to demo APAX-" + e.Text + "?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No))
            {
                return;
            }

            if (IsApaxCouplerSupportModule(strSelectModuleId) == false)
            {
                MessageBox.Show(("Not support APAX" + (e.Text + " module")), "Error");
                return;
            }

            if (strSelectModuleId == APAX_5013_STR)
            {
                apaxModule = new Form_APAX_5013(m_szIP, ((byte)(iSlot)), m_ScanTime_LocalSys[0], adamType);
            }
            else if (strSelectModuleId == APAX_5017_STR)
            {
                apaxModule = new Form_APAX_5017(m_szIP, ((byte)(iSlot)), m_ScanTime_LocalSys[0], adamType);
            }
            else if (strSelectModuleId == APAX_5017H_STR)
            {
                apaxModule = new Form_APAX_5017H(m_szIP, ((byte)(iSlot)), m_ScanTime_LocalSys[0], adamType);
            }
            else if (strSelectModuleId == APAX_5017PE_STR)
            {
                apaxModule = new Form_APAX_5017PE(m_szIP, ((byte)(iSlot)), m_ScanTime_LocalSys[0], adamType);
            }
            else if (strSelectModuleId == APAX_5018_STR)
            {
                apaxModule = new Form_APAX_5018(m_szIP, ((byte)(iSlot)), m_ScanTime_LocalSys[0], adamType);
            }
            else if (strSelectModuleId == APAX_5028_STR)
            {
                apaxModule = new Form_APAX_5028(m_szIP, ((byte)(iSlot)), m_ScanTime_LocalSys[0], adamType);
            }
            else if (strSelectModuleId == APAX_5040_STR)
            {
                apaxModule = new Form_APAX_5040(m_szIP, ((byte)(iSlot)), m_ScanTime_LocalSys[0], adamType);
            }
            else if (strSelectModuleId == APAX_5040PE_STR)
            {
                apaxModule = new Form_APAX_5040PE(m_szIP, ((byte)(iSlot)), m_ScanTime_LocalSys[0], adamType);
            }
            else if (strSelectModuleId == APAX_5045_STR)
            {
                apaxModule = new Form_APAX_5045(m_szIP, ((byte)(iSlot)), m_ScanTime_LocalSys[0], adamType);
            }
            else if (strSelectModuleId == APAX_5046_STR)
            {
                apaxModule = new Form_APAX_5046(m_szIP, ((byte)(iSlot)), m_ScanTime_LocalSys[0], adamType);
            }
            else if (strSelectModuleId == APAX_5046SO_STR)
            {
                apaxModule = new Form_APAX_5046SO(m_szIP, ((byte)(iSlot)), m_ScanTime_LocalSys[0], adamType);
            }
            else if (strSelectModuleId == APAX_5060_STR)
            {
                apaxModule = new Form_APAX_5060(m_szIP, ((byte)(iSlot)), m_ScanTime_LocalSys[0], adamType);
            }
            else if (strSelectModuleId == APAX_5060PE_STR)
            {
                apaxModule = new Form_APAX_5060PE(m_szIP, ((byte)(iSlot)), m_ScanTime_LocalSys[0], adamType);
            }
            else if (strSelectModuleId == APAX_5080_STR)
            {
                apaxModule = new Form_APAX_5080(m_szIP, ((byte)(iSlot)), m_ScanTime_LocalSys[0], adamType);
            }
            else if (strSelectModuleId == APAX_5082_STR)
            {
                apaxModule = new Form_APAX_5082(m_szIP, ((byte)(iSlot)), m_ScanTime_LocalSys[0], adamType);
            }
            else if ((adamType == AdamType.Apax5070) && (strSelectModuleId == APAX_5090_STR) && (m_adamObject.HardwareType[0] != 0x01 && m_adamObject.HardwareType[1] != 0x01))
            {
                apaxModule = new Form_APAX_5090(m_szIP, ((byte)(iSlot)), adamType);
            }
            else
            {
                MessageBox.Show(("Not support APAX" + (e.Text + " module")), "Error");
                return;
            }

            apaxModule.ShowDialog();
            apaxModule = null;
            GC.Collect();
        }

        private void formIP_ApplyIPAddressClick(string strIP)
        {
            m_szIP = strIP;
        }
        /// <summary>
        /// Init APAX controller information
        /// </summary>
        /// <returns></returns>
        public bool RefreshConfiguration()
        {
            //Query device information and network informations
            if (AdamSocket.GetAdamDeviceList("255.255.255.255", 2000, out m_adamList_Group))
            {
                for(int i=0;i<m_adamList_Group.Count;i++){
                    m_adamObject = (AdamInformation)m_adamList_Group[i];
                    string tmpIP = string.Format("{0}.{1}.{2}.{3}", m_adamObject.IP[0], m_adamObject.IP[1], m_adamObject.IP[2], m_adamObject.IP[3]);
                    if (string.Compare(m_szIP, tmpIP) == 0)
                        break;                
                }                
            }
            else
            {
                MessageBox.Show("Get module information failed!", "Error");
                return true;
            }

            //APAX Coupler Information
            this.labModuleName.Text = "APAX-PAC";
            this.txtFwVer.Text = string.Format("{0:X2}.{1:X2}", m_adamObject.FwVer[0], m_adamObject.FwVer[1]);  //Firmware Version
            if (m_sDSPFWVer != "")
                this.txtFwVer2.Text = m_sDSPFWVer.Substring(0, 4).Insert(2, ".");                               //Kernel Firmware Version

            if (adamType == AdamType.Apax5070)
            {
                if (m_adamModbusSocket.Connect(adamType, m_szIP, ProtocolType.Udp)) //FPGA Firmware Version (Should use udp to get FPGA version)
                {
                    uint o_dwVer;
                    if (m_adamModbusSocket.Configuration().GetFpgaVersion(out o_dwVer))
                        this.txtFpgaFwVer.Text = o_dwVer.ToString("X4").Insert(2, ".");
                }

                if ((Array.IndexOf(m_szSlotInfo, APAX_5090_STR) == -1) || (m_adamObject.HardwareType[0] == 0x01 && m_adamObject.HardwareType[1] == 0x01))
                {
                    if (tabControl1.TabPages.Contains(tabSerial))
                    {
                        tabControl1.TabPages.RemoveAt(tabControl1.TabPages.Count -1);
                    }
                }
                else
                {
                    if (!tabControl1.TabPages.Contains(tabSerial))
                    {
                        tabControl1.TabPages.Add(tabSerial);
                    }

                    m_listIndexOfApax5090 = new List<int>();

                    for (int idx = 0; idx < m_szSlotInfo.Length; idx++)
                    {
                        if ((m_szSlotInfo[idx] != null) && (m_szSlotInfo[idx].IndexOf(APAX_5090_STR) > -1))
                        {
                            m_listIndexOfApax5090.Add(idx);
                        }
                    }
                    m_iApax5090TcpPorVals = new int[AdamControl.APAX_MaxSlot][];
                    RefreshSerialModulesComPortSetting();
                }
            }
            else
            {
                if (m_adamModbusSocket.Connect(m_szIP, ProtocolType.Udp, portNum)) //FPGA Firmware Version (Should use udp to get FPGA version)
                {
                    uint o_dwVer;
                    if (m_adamModbusSocket.Configuration().GetFpgaVersion(out o_dwVer))
                        this.txtFpgaFwVer.Text = o_dwVer.ToString("X4").Insert(2, ".");
                }
            }

            m_adamModbusSocket.Disconnect();
            txtDeviceName.Text = m_adamObject.DeviceName;
            txtDeviceDesc.Text = m_adamObject.Description;
            RefreshCurrentModuleInfo(); //Current modules information
            //Network information
            txtMacAddress.Text = string.Format("{0:X02}-{1:X02}-{2:X02}-{3:X02}-{4:X02}-{5:X02}",   //MAC address
                m_adamObject.Mac[0], m_adamObject.Mac[1],
                m_adamObject.Mac[2], m_adamObject.Mac[3],
                m_adamObject.Mac[4], m_adamObject.Mac[5]);
            txtIPAddress.Text = string.Format("{0}.{1}.{2}.{3}",    //IP address
                m_adamObject.IP[0], m_adamObject.IP[1], m_adamObject.IP[2], m_adamObject.IP[3]);
            txtSubnetAddress.Text = string.Format("{0}.{1}.{2}.{3}",    //subnet mask
                m_adamObject.Subnet[0], m_adamObject.Subnet[1], m_adamObject.Subnet[2], m_adamObject.Subnet[3]);
            txtDefaultGateway.Text = string.Format("{0}.{1}.{2}.{3}",    //default gateway
                m_adamObject.Gateway[0], m_adamObject.Gateway[1], m_adamObject.Gateway[2], m_adamObject.Gateway[3]);
            numHostIdle.Text = m_adamObject.HostIdleTime.ToString();

            // Refresh Modbus address mapping
            RefreshModbusAddressSetting();
            // Refresh FSV settings
            RefreshFSVSettingInfo();

            return true;
        }

        private void RefreshSerialModulesComPortSetting()
        {
            ListViewItem lvItem;
            List<int> listGetTcpInfoSucceed = new List<int>();
            List<string> listGetTcpInfoFailed = new List<string>();

            if (m_listIndexOfApax5090.Count <= 0)
            { return; }

            for (int idx = 0; idx < m_listIndexOfApax5090.Count; idx++)
            {
                if (!GetSerialComPortTcpPortMapping(m_listIndexOfApax5090[idx], out m_iApax5090TcpPorVals[m_listIndexOfApax5090[idx]]))
                { listGetTcpInfoFailed.Add(idx.ToString()); }
                else
                { listGetTcpInfoSucceed.Add(m_listIndexOfApax5090[idx]); }
            }

            if (listGetTcpInfoFailed.Count > 0)
            {
                var failedList = String.Join(", ", listGetTcpInfoFailed.ToArray());
                MessageBox.Show("Get Switch ID [ " + failedList + " ] parameters failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }

            if (listGetTcpInfoSucceed.Count <= 0)
            { return; }

            listViewComPortInfo.BeginUpdate();
            listViewComPortInfo.Items.Clear();

            for (int outerIdx = 0; outerIdx < listGetTcpInfoSucceed.Count; outerIdx++)
            {
                for (int innerIdx = 0; innerIdx < m_iApax5090TcpPorVals[listGetTcpInfoSucceed[outerIdx]].Length; innerIdx++)
                {
                    #region Refresh Serial ComPort Table
                    lvItem = new ListViewItem(listGetTcpInfoSucceed[outerIdx].ToString()); //Switch Id
                    lvItem.SubItems.Add(APAX_INFO_NAME + "-" + APAX_5090_STR); //Module Name
                    lvItem.SubItems.Add("COM " + (innerIdx + 1).ToString());       //COM Port Id
                    lvItem.SubItems.Add(m_iApax5090TcpPorVals[listGetTcpInfoSucceed[outerIdx]][innerIdx].ToString()); //Map Tcp Port
                    listViewComPortInfo.Items.Add(lvItem);
                    #endregion
                }
            }
            listViewComPortInfo.EndUpdate();
        }

        private bool GetSerialComPortTcpPortMapping(int i_intSlotId, out int[] o_tcpPortMappingAry)
        {
            AdamSocket adamSocket = new AdamSocket(AdamType.Apax5070);
            bool bRet = false;
            o_tcpPortMappingAry = new int[4];

            if (adamSocket.Connect(m_szIP, ProtocolType.Udp, ASCII_CMD_UDP_PORT))
            {
                adamSocket.SetTimeout(m_iTimeout[0], m_iTimeout[1], m_iTimeout[2]);
                bRet = adamSocket.Configuration().GetModuleCOMTcpPortMapping(i_intSlotId, out o_tcpPortMappingAry);
            }
            else
            {
                //MessageBox.Show("Failed to connect module!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                bRet = false;
            }

            adamSocket.Disconnect();
            adamSocket = null;
            return bRet;
        }

        /// <summary>
        /// Refresh Current I/O Modules at this APAX controller
        /// </summary>
        /// <param name="dsInfo">I/O Module description</param>
        private void RefreshCurrentModuleInfo()
        {
            try
            {
                ListViewItem[] listItemModule = new ListViewItem[m_szSlotInfo.Length];

                listViewDescription.BeginUpdate();
                listViewDescription.Items.Clear();

                for (int i = 0; i < m_szSlotInfo.Length; i++)
                {
                    listItemModule[i] = new ListViewItem(i.ToString());
                    listItemModule[i].SubItems.Add(m_szSlotInfo[i]);
                    listViewDescription.Items.Add(listItemModule[i]);
                }

                listViewDescription.EndUpdate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }
        }
        /// <summary>
        /// Refresh Modbus Address type and value
        /// </summary>
        private void RefreshModbusAddressSetting()
        {
            gvAddress.Items.Clear();

            try
            {
                if (m_adamModbusSocket.Connect(m_adamModbusSocket.GetIP(), protoType, portNum))
                {
                    bool bFixed;
                    m_adamModbusSocket.Configuration().GetModbusAddressMode(out bFixed);
                    string[] szAddressType = new string[m_szSlotInfo.Length];
                    string[] szLength = new string[m_szSlotInfo.Length];
                    string[] szStartAddress = new string[m_szSlotInfo.Length];

                    //Update Modbus Address Setting tab
                    ListViewItem[] listItemModule = new ListViewItem[m_szSlotInfo.Length];
                    for (int i = 0; i < m_szSlotInfo.Length; i++)
                    {
                        listItemModule[i] = new ListViewItem(i.ToString());
                        if (m_szSlotInfo[i] != null)
                        {
                            if (IsModuleSupportModbusSetting(m_szSlotInfo[i]))
                            {
                                listItemModule[i].SubItems.Add("APAX-" + m_szSlotInfo[i]);
                            }
                            else
                            {
                                listItemModule[i].SubItems.Add("APAX-" + m_szSlotInfo[i] + " : INVALID");
                            }
                        }
                        else
                        {
                            listItemModule[i].SubItems.Add("Empty");
                        }

                        listItemModule[i].SubItems.Add("");
                        listItemModule[i].SubItems.Add("");
                        listItemModule[i].SubItems.Add("");
                        gvAddress.Items.Add(listItemModule[i]);
                    }

                    if (bFixed)
                    {
                        addressTypeValue.Text = "Fixed Mode";
                        for (int i = 0; i < m_szSlotInfo.Length; i++)
                        {
                            if ((m_szSlotInfo[i] != null) && (IsModuleSupportModbusSetting(m_szSlotInfo[i])))
                            {
                                Apax5000Config apaxConfig = null;
                                int iTemp;
                                m_adamModbusSocket.Configuration().GetModuleConfig(i, out apaxConfig);
                                if (apaxConfig.wDevType == 0x0001 || apaxConfig.wDevType == 0x0002)
                                {
                                    szLength[i] = Convert.ToString(64);
                                    iTemp = 64 * i + 1;
                                    szAddressType[i] = "0X";
                                }
                                else
                                {
                                    szLength[i] = Convert.ToString(32);
                                    iTemp = 32 * i + 1;
                                    szAddressType[i] = "4X";
                                }
                                szStartAddress[i] = iTemp.ToString();
                            }
                            else
                            {
                                szAddressType[i] = "0X";
                                szStartAddress[i] = (0).ToString();
                                szLength[i] = (0).ToString();
                            }
                        }
                    }
                    else
                    {
                        int[] o_iData;
                        addressTypeValue.Text = "Flexible Mode";
                        m_adamModbusSocket.Modbus().ReadAdvantechRegs(60101, 64, out o_iData);
                        for (int i = 0; i < m_szSlotInfo.Length; i++)
                        {
                            if (IsModuleSupportModbusSetting(m_szSlotInfo[i]))
                            {
                                int iStartAddress = o_iData[i * 2] % 10000;
                                if (o_iData[i * 2] / 40000 == 1)
                                    szAddressType[i] = "4X";
                                else
                                    szAddressType[i] = "0X";
                                szStartAddress[i] = iStartAddress.ToString();
                                szLength[i] = o_iData[i * 2 + 1].ToString();
                            }
                            else
                            {
                                szAddressType[i] = "0X";
                                szStartAddress[i] = (0).ToString();
                                szLength[i] = (0).ToString();
                            }
                        }
                    }
                    UpdateInfoString(IDX_STARTADDRESS, szStartAddress);
                    UpdateInfoString(IDX_ADDRESSTYPE, szAddressType);
                    UpdateInfoString(IDX_LENGTH, szLength);
                }

            }
            catch
            {
                MessageBox.Show("Initialize UI Modbus address setting failed.", "Error");
            }
            m_adamModbusSocket.Disconnect();

        }
        /// <summary>
        /// Refresh Modbus Address row value
        /// </summary>
        /// <param name="idxColumn"></param>
        /// <param name="szString"></param>
        public void UpdateInfoString(int idxColumn, string[] szString)
        {
            for (int idxRow = 0; idxRow < m_szSlotInfo.Length; idxRow++)
            {
                if (szString[idxRow] != null)
                    gvAddress.Items[idxRow].SubItems[idxColumn].Text = szString[idxRow];
            }
        }
        /// <summary>
        /// Refresh Fail Safe Value Setting
        /// </summary>
        private void RefreshFSVSettingInfo()
        {
            int[] o_iData;
            AdamSocket adamSocket = new AdamSocket(adamType);

            if (adamSocket.Connect(m_szIP, protoType, portNum))
            {
                if (adamSocket.Modbus().ReadAdvantechRegs(60004, 2, out o_iData)) //60004 is to read platform (AXIS) FW version
                {
                    if (0x0a == (o_iData[0] >> 12)) //check 'a' of 0xa105
                    {
                        if (0x105 > (o_iData[0] & 0x0FFF))
                            panelFSVSetting.Visible = false; //AXIS fw version under 105 not support set communication IO FSV, so invisible
                        else
                        { //fw version greater than 0x105 (include 0x105)
                            if (adamSocket.Modbus().ReadAdvantechRegs(60301, 2, out o_iData)) //Communication IO FSV Setting
                            {
                                if (0x01 == o_iData[0]) //Communication IO FSV enable
                                {
                                    chbxEnCommFSV.Checked = true;
                                    txtCommFSVtimeout.Enabled = true;
                                    txtCommFSVtimeout.Text = o_iData[1].ToString(); //Communication IO FSV Timeout
                                }
                                else
                                    chbxEnCommFSV.Checked = false;
                            }
                        }
                    }
                }
                else
                    panelFSVSetting.Visible = false;
            }

            adamSocket.Disconnect();
            adamSocket = null;
        }
        private void menuItem3_Click(object sender, EventArgs e)
        {
            //Exit
            Application.Exit();
        }
        /// <summary>
        /// Pop window to set IP address
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem2_Click(object sender, EventArgs e)
        {
            IPForm formIP = new IPForm();
            formIP.ApplyIPAddressClick += new IPForm.EventHandler_ApplyIPAddressClick(formIP_ApplyIPAddressClick);
            formIP.ShowDialog();
            formIP.Dispose();
            formIP = null;
        }
        /// <summary>
        /// Refresh Coupler IP address and IO modules
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuItem1_Click(object sender, EventArgs e)
        {
            if (m_szIP == "")
            {
                MessageBox.Show("Please enter IP address!");
                return;
            }
            treeView1.SelectedNode = treeView1.Nodes[0];
            treeView1.BeginUpdate();
            treeView1.Nodes[0].Nodes.Clear();
            TreeNode adamNode = new TreeNode(m_szIP);
            treeView1.Nodes[0].Nodes.Add(adamNode);
            treeView1.ExpandAll();
            treeView1.EndUpdate();
            treeView1.SelectedNode = treeView1.Nodes[0].Nodes[0];

        }
        /// <summary>
        /// Select tree items
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

            if ((string.Compare(e.Node.Text, "Ethernet") != 0) && (m_szIP != ""))
            {
                if (string.Compare(e.Node.Text, m_szIP) == 0)// 'Coupler' node
                    AfterSelect_CouplerDevice(e.Node);
                else// 'Slot' node
                    AfterSelect_CouplerSlot(e.Node);
            }
        }

        private void btnSetCommFSV_Click(object sender, EventArgs e)
        {
            int[] iData = new int[1];
            AdamSocket adamSocket = new AdamSocket(adamType);
            int iAddr = 60301; //Communication IO FSV Setting

            if (chbxEnCommFSV.Checked)
                iData[0] = 0x01;
            else
                iData[0] = 0x00;

            if (adamSocket.Connect(m_szIP, protoType, portNum))
            {
                if (adamSocket.Modbus().WriteAdvantechRegs(iAddr, iData))
                {
                    if (chbxEnCommFSV.Checked)
                    {
                        try
                        {
                            iData[0] = Convert.ToInt32(txtCommFSVtimeout.Text);

                            if ((1 > iData[0]) || (65535 < iData[0]))
                            {
                                MessageBox.Show("Input value not acceptable,\nplease enter value from 1~65535");
                                return;
                            }

                            iAddr = 60302; //Communication IO FSV Timeout
                            if (adamSocket.Modbus().WriteAdvantechRegs(iAddr, iData))
                                MessageBox.Show("Set Communication FSV Done.");
                            else
                                MessageBox.Show("Set Communication FSV failed.");
                        }
                        catch
                        {
                            MessageBox.Show("Input fromat not correct,\nplease enter value from 1~65535");
                        }
                    }
                    else
                    {
                        txtCommFSVtimeout.Enabled = false;

                        iAddr = 60302; //Communication IO FSV Timeout
                        if (adamSocket.Modbus().WriteAdvantechRegs(iAddr, iData))
                            MessageBox.Show("Set Communication FSV Done.");
                        else
                            MessageBox.Show("Set Communication FSV failed.");
                    }

                }
                else
                    MessageBox.Show("Set Communication FSV Setting failed.");
            }

            adamSocket.Disconnect();
            adamSocket = null;
        }

        private void chbxEnCommFSV_CheckedChanged(object sender, EventArgs e)
        {
            if (chbxEnCommFSV.Checked)
                txtCommFSVtimeout.Enabled = true;
            else
                txtCommFSVtimeout.Enabled = false;
        }

    }
}
