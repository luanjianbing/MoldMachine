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

namespace APAX_5090
{
    public partial class Form_APAX_5090 : Form
    {
        // Global object
        const string APAX_INFO_NAME = "APAX";
        const string DVICE_TYPE = "5090";
        const int ASCII_CMD_UDP_PORT = 1025;
        const int m_COM1ValueIdx = 0;

        private AdamSocket m_adamSocket;
        private AdamSocket adamUDP;
        string m_szIP = "";

        private Apax5000Config m_aConf;
        private int m_idxID;
        private AdamType m_adamType = AdamType.Apax5070;
        private ProtocolType protoType = ProtocolType.Tcp;
        private int portNum = 502;
        private int m_ComPortNumTotal;
        private int m_tmpidx;
        private int m_iConnectTimeout, m_iSendTimeout, m_iReceiveTimeout;
        private string[] m_szSlots;// Container of all solt device type
        private bool m_bStartFlag = false;
        private ComPortParameters[] m_comPortParametersAry;

        public class ComPortParameters : Object
        {
            private int m_SlotNum;
            private int m_ComPortNum;
            private int m_BaudRate;
            private int m_DataBit;
            private int m_StopBit;
            private int m_Parity;
            private int m_FlowControl;
            private string m_StatusMsg;
            private bool m_StatusFlag;

            public ComPortParameters(int slotNum, int comPortNum, int baudRate, int dataBit, int stopBit, int parity, int flowControl)
            {
                m_SlotNum = slotNum;
                m_ComPortNum = comPortNum;
                m_BaudRate = baudRate;
                m_DataBit = dataBit;
                m_StopBit = stopBit;
                m_Parity = parity;
                m_FlowControl = flowControl;
                m_StatusMsg = string.Empty;
                m_StatusFlag = false;
            }

            public int SlotNum
            {
                get { return m_SlotNum; }
                set { m_SlotNum = value; }
            }

            public int ComPortNum
            {
                get { return m_ComPortNum; }
                set { m_ComPortNum = value; }
            }

            public int BaudRate
            {
                get { return m_BaudRate; }
                set { m_BaudRate = value; }
            }

            public int DataBit
            {
                get { return m_DataBit; }
                set { m_DataBit = value; }
            }

            public int StopBit
            {
                get { return m_StopBit; }
                set { m_StopBit = value; }
            }

            public int Parity
            {
                get { return m_Parity; }
                set { m_Parity = value; }
            }

            public int FlowControl
            {
                get { return m_FlowControl; }
                set { m_FlowControl = value; }
            }

            public string StatusMsg
            {
                get { return m_StatusMsg; }
                set { m_StatusMsg = value; }
            }

            public bool StatusFlag
            {
                get { return m_StatusFlag; }
                set { m_StatusFlag = value; }
            }
        }

        public enum emComPortParameters
        {
            Baudrate_ = 0,
            Databit_ = 1,
            Parity_ = 2,
            Stopbit_ = 3,
            Flowctl_ = 4,
            Tcpport_ = 5
        }

        public enum emBaudrate
        {
            Baudrate_600 = 0,
            Baudrate_1200 = 1,
            Baudrate_2400 = 2,
            Baudrate_4800 = 3,
            Baudrate_9600 = 4,
            Baudrate_14400 = 5,
            Baudrate_19200 = 6,
            Baudrate_38400 = 7,
            Baudrate_57600 = 8,
            Baudrate_115200 = 9,
            Unknown = 255
        }

        public enum emDatabit
        {
            Databit_8 = 0,
            Databit_9 = 1,
            Unknown = 255
        }

        public enum emParity
        {
            Parity_NONE = 0,
            Parity_ODD = 1,
            Parity_EVEN = 2,
            Parity_MARK = 3,
            Parity_SPACE = 4,
            Unknown = 255
        }

        public enum emStopbit
        {
            Stopbit_1 = 0,
            Stopbit_0_5 = 1,
            Stopbit_2 = 2,
            Stopbit_1_5 = 3,
            Unknown = 255
        }

        public enum emFlowcontrol
        {
            Flowctl_NONE = 0,
            Flowctl_RTS = 1,
            Flowctl_CTS = 2,
            Flowctl_DTR = 3,
            Unknown = 255
        }

        public Form_APAX_5090()
        {
            InitializeComponent();
            adamUDP = new AdamSocket();
            m_idxID = -1; // Set in invalid num 
            m_iConnectTimeout = 2000; // Connection Timeout    
            m_iSendTimeout = 2000; // Send Timeout
            m_iReceiveTimeout = 2000;// Receive Timeout
            cbxPort.SelectedIndex = 0;
            m_comPortParametersAry = new ComPortParameters[4];
            this.StatusBar_IO.Text = ("Start to demo "
            + (APAX_INFO_NAME + ("-"
            + (DVICE_TYPE + " by clicking \'Start\' button."))));
        }

        public Form_APAX_5090(string IP, int SlotNum, AdamType i_adamType)
        {
            InitializeComponent();
            adamUDP = new AdamSocket();
            m_szSlots = null;
            m_idxID = SlotNum; // Set Slot_ID
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

            m_iConnectTimeout = 2000; // Connection Timeout    
            m_iSendTimeout = 2000; // Send Timeout
            m_iReceiveTimeout = 2000;// Receive Timeout
            cbxPort.SelectedIndex = 0;
            m_szIP = IP;
            m_comPortParametersAry = new ComPortParameters[4];
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
                this.tcRemote.Enabled = false;
                this.tcRemote.Visible = false;

                m_adamSocket.Configuration().SYS_SetLocateModule(m_idxID, 0);
                m_adamSocket.Disconnect();
                m_adamSocket = null;

                adamUDP.Disconnect();
                adamUDP = null;
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
            this.tcRemote.Enabled = true;
            this.tcRemote.Visible = true;
            InitialDataTabPages();
            this.Text = (APAX_INFO_NAME + DVICE_TYPE);
            this.tcRemote.SelectedIndex = 0;
            return true;
        }
        public bool OpenDevice()
        {
            m_adamSocket = new AdamSocket(m_adamType);
            m_adamSocket.SetTimeout(m_iConnectTimeout, m_iSendTimeout, m_iReceiveTimeout);
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
        private void InitialDataTabPages()
        {
            int i = 0, idx = 0;
            byte type = (byte)_HardwareIOType.COM_Port;   //APAX-5090 is Serial (COM Port) module
            ListViewItem lvItem;

            for (i = 0; i < m_aConf.HwIoType.Length; i++)
            {
                if (m_aConf.HwIoType[i] == type)
                    idx = i;
            }
            m_ComPortNumTotal = m_aConf.HwIoTotal[idx];

            m_tmpidx = idx;
            listViewComPortInfo.BeginUpdate();
            listViewComPortInfo.Items.Clear();

            for (i = 0; i < m_aConf.HwIoTotal[idx]; i++)
            {
                lvItem = new ListViewItem(_HardwareIOType.COM_Port.ToString().Replace("_", " ").Replace("Port", "") + " " + (i + 1).ToString());   //(COM1~COM4)
                lvItem.SubItems.Add("*****");       //Baudrate
                lvItem.SubItems.Add("*****");       //Databits
                lvItem.SubItems.Add("*****");       //Parity
                lvItem.SubItems.Add("*****");       //Stopbits
                lvItem.SubItems.Add("*****");       //FlowControl
                lvItem.SubItems.Add("*****");       //TcpPort
                listViewComPortInfo.Items.Add(lvItem);
            }

            listViewComPortInfo.EndUpdate();
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

        private void Form_APAX_5090_FormClosing(object sender, FormClosingEventArgs e)
        {
            FreeResource();
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

        private void chbxHide_Serial_CheckedChanged(object sender, EventArgs e)
        {
            panelConfig_Serial.Visible = !chbxHide_Serial.Checked;
        }

        private void RefreshSerialComPortSetting()
        {
            m_comPortParametersAry = new ComPortParameters[m_ComPortNumTotal];
            int[] serialComPortTcpPortMappingAry = new int[m_ComPortNumTotal];

            for (int intPortNum = 1; intPortNum <= m_ComPortNumTotal; intPortNum++)
            {
                GetSerialComPortSetting(m_idxID, intPortNum, out m_comPortParametersAry[intPortNum - 1]);
            }

            GetSerialComPortTcpPortMapping(m_idxID, out serialComPortTcpPortMappingAry);

            for (int i = 0; i < m_ComPortNumTotal; i++)
            {
                //Baudrate value
                listViewComPortInfo.Items[i].SubItems[1].Text = ((emBaudrate)m_comPortParametersAry[i].BaudRate).ToString().Replace(emComPortParameters.Baudrate_.ToString(), string.Empty);
                //Databit value
                listViewComPortInfo.Items[i].SubItems[2].Text = ((emDatabit)m_comPortParametersAry[i].DataBit).ToString().Replace(emComPortParameters.Databit_.ToString(), string.Empty);
                //Parity value
                listViewComPortInfo.Items[i].SubItems[3].Text = ((emParity)m_comPortParametersAry[i].Parity).ToString().Replace(emComPortParameters.Parity_.ToString(), string.Empty);
                //StopBit value
                listViewComPortInfo.Items[i].SubItems[4].Text = ((emStopbit)m_comPortParametersAry[i].StopBit).ToString().Replace(emComPortParameters.Stopbit_.ToString(), string.Empty).Replace("_", ".");
                //FlowControl value
                listViewComPortInfo.Items[i].SubItems[5].Text = ((emFlowcontrol)m_comPortParametersAry[i].FlowControl).ToString().Replace(emComPortParameters.Flowctl_.ToString(), string.Empty);
                //Mapping TCP Port value
                listViewComPortInfo.Items[i].SubItems[6].Text = serialComPortTcpPortMappingAry[i].ToString();
            }
            UpdateSettingPanel(m_comPortParametersAry[cbxPort.SelectedIndex]);
        }

        private bool GetSerialComPortTcpPortMapping(int i_intSlotId, out int[] o_tcpPortMappingAry)
        {
            bool bRet = false;
            o_tcpPortMappingAry = new int[4];

            if (adamUDP.Connect(m_szIP, ProtocolType.Udp, ASCII_CMD_UDP_PORT))
            {
                adamUDP.SetTimeout(m_iConnectTimeout, m_iSendTimeout, m_iReceiveTimeout);

                bRet = adamUDP.Configuration().GetModuleCOMTcpPortMapping(i_intSlotId, out o_tcpPortMappingAry);
            }
            else
            {
                MessageBox.Show("Failed to connect module!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                bRet = false;
            }

            adamUDP.Disconnect();
            return bRet;
        }

        private bool GetSerialComPortSetting(int i_intSlotId, int i_intComPortNum, out ComPortParameters o_comPortParameters)
        {
            int intUnknownVal = 255;
            bool bRet = false;
            o_comPortParameters = new ComPortParameters(i_intSlotId, i_intComPortNum, intUnknownVal, intUnknownVal, intUnknownVal, intUnknownVal, intUnknownVal);

            if (adamUDP.Connect(m_szIP, ProtocolType.Udp, ASCII_CMD_UDP_PORT))
            {
                int o_iBaudRate, o_iDataBit, o_iStopBit, o_iParity, o_iFlowControl;
                adamUDP.SetTimeout(m_iConnectTimeout, m_iSendTimeout, m_iReceiveTimeout);
                if (adamUDP.Configuration().GetModuleCOMConfig(i_intSlotId, i_intComPortNum, out o_iBaudRate, out  o_iDataBit, out o_iStopBit, out o_iParity, out o_iFlowControl))
                {
                    o_comPortParameters.ComPortNum = i_intComPortNum;
                    o_comPortParameters.BaudRate = o_iBaudRate;
                    o_comPortParameters.DataBit = o_iDataBit;
                    o_comPortParameters.StopBit = o_iStopBit;
                    o_comPortParameters.Parity = o_iParity;
                    o_comPortParameters.FlowControl = o_iFlowControl;
                    o_comPortParameters.StatusFlag = true;
                    bRet = true;
                }
                else
                {
                    o_comPortParameters.StatusMsg = adamUDP.LastError.ToString();
                    o_comPortParameters.StatusFlag = false;
                    bRet = false;
                }
            }
            else
            {
                //MessageBox.Show("Failed to connect module!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                o_comPortParameters.StatusMsg = "Read ComPort Config : Failed to connect module!";
                bRet = false;
            }

            adamUDP.Disconnect();
            return bRet;
        }

        private void UpdateSettingPanel(ComPortParameters i_comPortParameters)
        {
            try
            {
                cbxPort.SelectedIndex = i_comPortParameters.ComPortNum - 1;
                cbxBaudRate.SelectedIndex = i_comPortParameters.BaudRate;
                cbxDatabit.SelectedIndex = i_comPortParameters.DataBit;
                cbxParity.SelectedIndex = i_comPortParameters.Parity;
                cbxStopbit.SelectedIndex = i_comPortParameters.StopBit;
                cbxFlowCtrl.SelectedIndex = i_comPortParameters.FlowControl;
            }
            catch
            {
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strSelPageName = tcRemote.TabPages[tcRemote.SelectedIndex].Text;
            if (strSelPageName == "Serial")
            {
                RefreshSerialComPortSetting();
            }
        }

        private void cbxPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbxPort.SelectedIndex < m_comPortParametersAry.Length)
                {
                    UpdateSettingPanel(m_comPortParametersAry[cbxPort.SelectedIndex]);
                }
            }
            catch
            {
            }
        }

        private void btnApplySetting_Click(object sender, EventArgs e)
        {
            bool bRet = false;
            int[] arrayOfComPort = new int[] { 1, 2, 3, 4 };
            string[] failedOfComPort = new string[] { };
            List<string> listFailedSetting = new List<string>();
            int intComPortNum;

            if (!CheckControllable())
                return;

            if (chbxPortSettingFollowCOM1.Checked)
            {
                intComPortNum = -1;
                m_comPortParametersAry[m_COM1ValueIdx].BaudRate = cbxBaudRate.SelectedIndex;
                m_comPortParametersAry[m_COM1ValueIdx].DataBit = cbxDatabit.SelectedIndex;
                m_comPortParametersAry[m_COM1ValueIdx].Parity = cbxParity.SelectedIndex;
                m_comPortParametersAry[m_COM1ValueIdx].StopBit = cbxStopbit.SelectedIndex;
                m_comPortParametersAry[m_COM1ValueIdx].FlowControl = cbxFlowCtrl.SelectedIndex;
            }
            else
            {
                intComPortNum = cbxPort.SelectedIndex + 1;
                m_comPortParametersAry[cbxPort.SelectedIndex].BaudRate = cbxBaudRate.SelectedIndex;
                m_comPortParametersAry[cbxPort.SelectedIndex].DataBit = cbxDatabit.SelectedIndex;
                m_comPortParametersAry[cbxPort.SelectedIndex].Parity = cbxParity.SelectedIndex;
                m_comPortParametersAry[cbxPort.SelectedIndex].StopBit = cbxStopbit.SelectedIndex;
                m_comPortParametersAry[cbxPort.SelectedIndex].FlowControl = cbxFlowCtrl.SelectedIndex;
            }

            if ((intComPortNum > 0) && (intComPortNum <= m_comPortParametersAry.Length))
            {
                bRet = SetSerialComPortSetting(m_idxID, intComPortNum, m_comPortParametersAry[intComPortNum - 1]);
                if (bRet == false)
                {
                    listFailedSetting.Add(m_comPortParametersAry.ToString());
                }
            }
            else
            {
                //All follow COM1 setting
                foreach (int comPortNumIdx in arrayOfComPort)
                {
                    bRet = SetSerialComPortSetting(m_idxID, comPortNumIdx, m_comPortParametersAry[0]);
                    if (bRet == false)
                    {
                        listFailedSetting.Add(comPortNumIdx.ToString());
                    }
                }
            }

            if (listFailedSetting.Count > 0)
            {
                var failedList = String.Join(", ", listFailedSetting.ToArray());
                MessageBox.Show("Set COM port [ " + failedList + " ] parameters failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            else
            {
                MessageBox.Show("Set COM port parameters done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                RefreshSerialComPortSetting();
            }
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

        private bool SetSerialComPortSetting(int i_intSlotId, int i_intComPortNum, ComPortParameters i_comPortParameters)
        {
            bool bRet = false;
            int i_iBaudRate, i_iDataBit, i_iStopBit, i_iParity, i_iFlowControl;
            i_iBaudRate = i_comPortParameters.BaudRate;
            i_iDataBit = i_comPortParameters.DataBit;
            i_iStopBit = i_comPortParameters.StopBit;
            i_iParity = i_comPortParameters.Parity;
            i_iFlowControl = i_comPortParameters.FlowControl;

            if (adamUDP.Connect(m_szIP, ProtocolType.Udp, ASCII_CMD_UDP_PORT))
            {
                adamUDP.SetTimeout(m_iConnectTimeout, m_iSendTimeout, m_iReceiveTimeout);
                bRet = adamUDP.Configuration().SetModuleCOMConfig(i_intSlotId, i_intComPortNum, i_iBaudRate, i_iDataBit, i_iStopBit, i_iParity, i_iFlowControl);
            }
            else
            {
                //MessageBox.Show("Failed to connect module!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                i_comPortParameters.StatusMsg = "Write ComPort Config : Failed to connect module!";
                bRet = false;
            }

            adamUDP.Disconnect();
            return bRet;
        }
    }
}
