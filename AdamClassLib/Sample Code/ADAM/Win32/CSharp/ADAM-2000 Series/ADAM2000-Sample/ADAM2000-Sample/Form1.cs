using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Advantech.Adam;

namespace ADAM2000_Sample
{
    public partial class Form1 : Form
    {
        private static int ENDDEVICE_MAX_NUMBER = 64;

        private AdamCom m_adamCom;
        private Adam2000Config m_CoordinatorConfig;
        private Adam2000Config m_CurrentDeviceNodeConfig;
        private TreeNode m_coordinatorNode;
        private ArrayList m_deviceList;
        private int m_iQueryCount = 0;
        private int m_ChannelNumber = 0;
        private int m_iCoorComport;
        private int m_iCoordinatorSlaveId;
        private int m_Counter;
        private int[] m_iShortAddr;
        private int[] m_iModuleStatus;
        private int[] m_iSlaveIDarray;
        private int[] m_iModuleNameFirst;
        private int[] m_iModuleNameSecond;
        private int[] m_iDeviceType;
        private ushort[] m_usRanges;
        private bool m_bCheckName;
        private const ushort AD_Convert_Timeout = (1 << 0);
        private const ushort Over_Range = (1 << 1);
        private const ushort Under_Range = (1 << 2);
        private const ushort Open_Circuit_Burnout = (1 << 3);
        private const ushort Not_Converted_Yet = (1 << 5);
        private const ushort ADC_Initializing_Error = (1 << 7);
        private const ushort Zero_Span_Calibration_Error = (1 << 9);
        private const string m_StrDeviceInfo = "Device Info";

        public Form1()
        {
            InitializeComponent();
            m_CoordinatorConfig = new Adam2000Config();
            m_deviceList = new ArrayList();

            //Initial some UI default option
            cbComportBuadrate.SelectedIndex = 0;
            bCoordinator.Enabled = false;
            gbDeviceTreeView.Enabled = false;
            gbDeviceInfo.Enabled = false;
            searchLabel.Visible = false;
            bGetEndDevice.Visible = false;
        }

        private void bComport_Click(object sender, EventArgs e)
        {
            gbDeviceInfo.Text = m_StrDeviceInfo;

            if (bComport.Text == "Open")
            {
                m_iCoorComport = Convert.ToInt32(tbComport.Text.ToString());
                m_adamCom = new AdamCom(m_iCoorComport);

                if (m_adamCom.OpenComPort())
                {
                    // Open Comport Success
                    m_adamCom.SetComPortTimeout(500, 5000, 0, 1000, 0); // set comport timeout

                    // Set Buadrate
                    if (cbComportBuadrate.SelectedIndex == 0)
                        m_adamCom.SetComPortState(Advantech.Common.Baudrate.Baud_9600, Advantech.Common.Databits.Eight, Advantech.Common.Parity.None, Advantech.Common.Stopbits.One);
                    else if (cbComportBuadrate.SelectedIndex == 1)
                        m_adamCom.SetComPortState(Advantech.Common.Baudrate.Baud_115200, Advantech.Common.Databits.Eight, Advantech.Common.Parity.None, Advantech.Common.Stopbits.One);
                    else
                        m_adamCom.SetComPortState(Advantech.Common.Baudrate.Baud_9600, Advantech.Common.Databits.Eight, Advantech.Common.Parity.None, Advantech.Common.Stopbits.One);

                    bComport.Text = "Close";
                    gbDeviceTreeView.Enabled = true;
                    gbDeviceInfo.Enabled = true;
                    bCoordinator.Enabled = true;

                }
                else
                {
                    // return open Comport Fail
                    MessageBox.Show("Open COMPORT fail");
                }
            }
            else if (bComport.Text == "Close")
            {
                if (m_adamCom != null)
                    m_adamCom.CloseComPort();


                tcDeviceInfo.SelectedIndex = 0;
                txtDeviceName.Text = string.Empty;
                txtDescription.Text = string.Empty;
                txtFwVerKernal.Text = string.Empty;
                txtFwVerZigBee.Text = string.Empty;
                txtPanId.Text = string.Empty;
                txtChannel.Text = string.Empty;
                txtSlaveId.Text = string.Empty;
                txtPAddr.Text = string.Empty;
                txtSAddr.Text = string.Empty;
                txtDataCycle.Text = string.Empty;

                treeView1.Nodes.Clear();
                bCoordinator.Enabled = false;
                gbDeviceTreeView.Enabled = false;
                gbDeviceInfo.Enabled = false;
                bGetEndDevice.Visible = false;
                bComport.Text = "Open";

            }
        }

        private void bCoordinator_Click(object sender, EventArgs e)
        {
            bGetEndDevice.Visible = false;
            bool bRet = false;
            if (m_adamCom != null)
                bRet = true;

            treeView1.Nodes.Clear();
            gbDeviceInfo.Text = m_StrDeviceInfo;

            if (bRet)
            {
                // Reset Comport Parameters
                m_adamCom.SetComPortTimeout(200, 600, 0, 400, 0);
                // Set Search Counter to be initial
                m_Counter = 241;
                timerSearchCoordinator.Interval = 600;
                searchLabel.Visible = true;
                timerSearchCoordinator.Enabled = true;
            }
        }

        private void timerSearchCoordinator_Tick(object sender, EventArgs e)
        {
            if (m_Counter < 249)
            {
                searchLabel.Text = "Searching " + m_Counter.ToString();

                if (m_adamCom.Adam2000(m_Counter).GetCoordinator(ref m_CoordinatorConfig))
                {
                    m_iCoordinatorSlaveId = m_Counter;

                    if ((m_Counter >= 241) && (m_Counter <= 244))   //Initial mode
                        m_coordinatorNode = new TreeNode("ADAM-2520Z" + "(*" + m_Counter.ToString("X02") + "h)");
                    else
                        m_coordinatorNode = new TreeNode("ADAM-2520Z" + "(" + m_Counter.ToString("X02") + "h)");

                    treeView1.BeginUpdate();
                    treeView1.Nodes.Add(m_coordinatorNode);
                    treeView1.EndUpdate();
                    treeView1.SelectedNode = treeView1.Nodes[0];
                }

                m_Counter++;
            }
            else
            {
                timerSearchCoordinator.Enabled = false;
                searchLabel.Text = "";
            }
        }

        private void bGetEndDevice_Click(object sender, EventArgs e)
        {
            m_coordinatorNode.Nodes.Clear();
            m_deviceList.Clear();
            int iRetryCount = 0;
            int iRetryLimit = 3;
            int iStart = 213; //wireless version data start address nuder ADAM-2000 protocol definition
            int i = 0;
            byte[] byWirelessVersionData;
            bool bReturnVal = true;
            bool bReadShortAddr = false;
            bool bReadModuleStatus = false;
            bool bReadSlaveID = false;
            bool bReadModuleNameFirst = false;
            bool bReadModuleNameSecond = false;

            try
            {
                while (true)
                {
                    for (i = 0; i < iRetryLimit; i++)
                    {
                        if (!bReadShortAddr)
                        {
                            if (!m_adamCom.Modbus(m_iCoordinatorSlaveId).ReadHoldingRegs(10001, ENDDEVICE_MAX_NUMBER, out m_iShortAddr))  // Short address
                            {
                                if (iRetryCount >= iRetryLimit)
                                {
                                    MessageBox.Show("EndDevice 10001", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    bReturnVal = false;
                                    break;
                                }
                                else
                                {
                                    iRetryCount++;
                                    System.Threading.Thread.Sleep(100);
                                    continue;
                                }
                            }
                            else
                                bReadShortAddr = true;

                            System.Threading.Thread.Sleep(30);
                        }

                        if (!bReadSlaveID)
                        {
                            if (!m_adamCom.Modbus(m_iCoordinatorSlaveId).ReadHoldingRegs(10401, ENDDEVICE_MAX_NUMBER, out m_iSlaveIDarray))  // slave ID
                            {
                                if (iRetryCount >= iRetryLimit)
                                {
                                    MessageBox.Show("EndDevice 10401", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    bReturnVal = false;
                                    break;
                                }
                                else
                                {
                                    iRetryCount++;
                                    System.Threading.Thread.Sleep(100);
                                    continue;
                                }
                            }
                            else
                                bReadSlaveID = true;

                            System.Threading.Thread.Sleep(30);
                        }

                        if (!bReadModuleNameFirst)
                        {
                            if (!m_adamCom.Modbus(m_iCoordinatorSlaveId).ReadHoldingRegs(10601, ENDDEVICE_MAX_NUMBER, out m_iModuleNameFirst))  //Module Name
                            {
                                if (iRetryCount >= iRetryLimit)
                                {
                                    MessageBox.Show("EndDevice 10601 first", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    bReturnVal = false;
                                    break;
                                }
                                else
                                {
                                    iRetryCount++;
                                    System.Threading.Thread.Sleep(100);
                                    continue;
                                }
                            }
                            else
                                bReadModuleNameFirst = true;

                            System.Threading.Thread.Sleep(30);
                        }

                        if (!bReadModuleNameSecond)
                        {
                            if (!m_adamCom.Modbus(m_iCoordinatorSlaveId).ReadHoldingRegs(10601 + ENDDEVICE_MAX_NUMBER, ENDDEVICE_MAX_NUMBER, out m_iModuleNameSecond))  //Module Name
                            {
                                if (iRetryCount >= iRetryLimit)
                                {
                                    MessageBox.Show("EndDevice 10601 second", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    bReturnVal = false;
                                    break;
                                }
                                else
                                {
                                    iRetryCount++;
                                    System.Threading.Thread.Sleep(100);
                                    continue;
                                }
                            }
                            else
                                bReadModuleNameSecond = true;

                            System.Threading.Thread.Sleep(30);
                        }

                        if (!bReadModuleStatus)
                        {
                            if (!m_adamCom.Modbus(m_iCoordinatorSlaveId).ReadHoldingRegs(11001, ENDDEVICE_MAX_NUMBER, out m_iModuleStatus))  //Module status
                            {
                                if (iRetryCount >= iRetryLimit)
                                {
                                    MessageBox.Show("EndDevice 11001", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    bReturnVal = false;
                                    break;
                                }
                                else
                                {
                                    iRetryCount++;
                                    System.Threading.Thread.Sleep(100);
                                    continue;
                                }
                            }
                            else
                                bReadModuleStatus = true;

                            System.Threading.Thread.Sleep(30);
                        }

                        //prevent old MSP430 firmware not support this address 10801 (End Device and Router Version>=A103B01 supprot this address)
                        if (m_adamCom.Modbus(m_iCoordinatorSlaveId).ReadHoldingRegs(10801, ENDDEVICE_MAX_NUMBER, out m_iDeviceType))  // Device Type
                            m_bCheckName = false;
                        else
                            m_bCheckName = true;

                        if (bReturnVal)
                            break;
                    }

                    if (bReadShortAddr &&
                        bReadSlaveID &&
                        bReadModuleNameFirst &&
                        bReadModuleNameSecond &&
                        bReadModuleStatus) //make sure all needed information already read back
                    {
                        for (i = 0; i < ENDDEVICE_MAX_NUMBER; i++)
                        {
                            if (m_iShortAddr[i] != 0xFFFF) //0xFFFF means empty
                            {
                                Adam2000Config tempAdam2kConfig = new Adam2000Config();

                                tempAdam2kConfig.wShortAddr = Convert.ToUInt16(m_iShortAddr[i]);
                                tempAdam2kConfig.wMBSlaveID = Convert.ToUInt16(m_iSlaveIDarray[i]);
                                byWirelessVersionData = new byte[4];

                                for (int j = 0; j < iRetryLimit; j++)
                                {
                                    if (m_adamCom.Modbus(tempAdam2kConfig.wMBSlaveID).ReadHoldingRegs(iStart, 2, out byWirelessVersionData)) // read 2 registers, 4 bytes
                                    {
                                        tempAdam2kConfig.wFwVerNo = Convert.ToUInt16(byWirelessVersionData[0] * 0x100 + byWirelessVersionData[1]);
                                        tempAdam2kConfig.wFwVerBld = Convert.ToUInt16(byWirelessVersionData[2] * 0x100 + byWirelessVersionData[3]);
                                        break;
                                    }
                                    System.Threading.Thread.Sleep(100);
                                }

                                if (i < ENDDEVICE_MAX_NUMBER / 2)
                                    tempAdam2kConfig.dwModName = Convert.ToUInt32(Convert.ToInt32(m_iModuleNameFirst[i * 2]) << 16 | Convert.ToInt32(m_iModuleNameFirst[i * 2 + 1]));
                                else
                                    tempAdam2kConfig.dwModName = Convert.ToUInt32(Convert.ToInt32(m_iModuleNameSecond[(i - ENDDEVICE_MAX_NUMBER / 2) * 2]) << 16 | Convert.ToInt32(m_iModuleNameSecond[(i - ENDDEVICE_MAX_NUMBER / 2) * 2 + 1]));

                                tempAdam2kConfig.wModuleStatus = Convert.ToUInt16(m_iModuleStatus[i]);
                                m_deviceList.Add(tempAdam2kConfig);

                                if (m_bCheckName)
                                {
                                    if ((((tempAdam2kConfig.dwModName & 0xFFFF0000) >> 16).ToString("X4") != "2520")) //Coordinator
                                    {
                                        InsertNodeAdamDevice(ref tempAdam2kConfig);
                                    }
                                }
                                else
                                {
                                    tempAdam2kConfig.wDevType = Convert.ToUInt16(m_iDeviceType[i]);

                                    if ((tempAdam2kConfig.wDevType == 0x0001)  || //DI
                                        (tempAdam2kConfig.wDevType == 0x0002)  || //DO
                                        (tempAdam2kConfig.wDevType == 0x0003)  || //AI
                                        (tempAdam2kConfig.wDevType == 0x0004)  || //AO
                                        (tempAdam2kConfig.wDevType == 0x000D) || //Sensor
                                        (tempAdam2kConfig.wDevType == 0x000F)) //Router
                                    {
                                        InsertNodeAdamDevice(ref tempAdam2kConfig);
                                    }

                                }

                                tempAdam2kConfig = null;
                            }
                        }
                    }
                    else
                        MessageBox.Show("Load End Device information error, please retry again.\nIf mode change, please re-search coordinator.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    break;
                } //while
            }
            catch (Exception ex)
            {
                string strMsg = ex.Message;
                string strCap = "Exception";
                MessageBox.Show(strMsg, strCap, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }

        }

        private void InsertNodeAdamDevice(ref Adam2000Config a2kConfigObj)
        {
            TreeNode moduleNode;
            treeView1.BeginUpdate();
            if (((Byte)a2kConfigObj.wModuleStatus & 0x01) == 0) //initial mode
                moduleNode = new TreeNode("ADAM" + "-" + a2kConfigObj.GetModuleName() + "(*" + a2kConfigObj.wMBSlaveID.ToString("X2") + "h)");
            else
                moduleNode = new TreeNode("ADAM" + "-" + a2kConfigObj.GetModuleName() + "(" + a2kConfigObj.wMBSlaveID.ToString("X2") + "h)");

            moduleNode.Tag = (object)a2kConfigObj.wShortAddr; //for store Short address

            m_coordinatorNode.Nodes.Add(moduleNode);
            m_coordinatorNode.Expand();
            treeView1.EndUpdate();
        }

        private enum TabPageStatus : int
        {
            Enable = 1, 
            Disable = 2
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e == null)
            {
                gbDeviceInfo.Text = m_StrDeviceInfo;
                return;
            }

            if (e.Node == null)
            {
                gbDeviceInfo.Text = m_StrDeviceInfo;
                return;
            }

            gbDeviceInfo.Text = m_StrDeviceInfo + " : " + e.Node.Text;

            m_CurrentDeviceNodeConfig = new Adam2000Config();

            switch (e.Node.Level)
            {
                case 0: // Coordinator Node
                    {
                        bGetEndDevice.Visible = true;
                        RefreshCoordinatorInformation();
                        m_CurrentDeviceNodeConfig = m_CoordinatorConfig;

                        if (tcDeviceInfo.Controls.Contains(tpDeviceStatus))
                            tcDeviceInfo.Controls.Remove(tpDeviceStatus);
                        if (tcDeviceInfo.Controls.Contains(tpChannelInfo))
                            tcDeviceInfo.Controls.Remove(tpChannelInfo);
                        if (tcDeviceInfo.Controls.Contains(tpChannelStatus))
                            tcDeviceInfo.Controls.Remove(tpChannelStatus);
                        if (tcDeviceInfo.Controls.Contains(tpSetRange))
                            tcDeviceInfo.Controls.Remove(tpSetRange);
                        if (!tcDeviceInfo.Controls.Contains(tpDeviceList))
                            tcDeviceInfo.Controls.Add(tpDeviceList);
                    }
                    break;
                case 1: // End Device (Router) Node
                    {
                        bGetEndDevice.Visible = false;
                        RefreshEndDeviceInformation(((ushort)e.Node.Tag), ref m_CurrentDeviceNodeConfig);

                        if (tcDeviceInfo.Controls.Contains(tpDeviceList))
                            tcDeviceInfo.Controls.Remove(tpDeviceList);
                        if (!tcDeviceInfo.Controls.Contains(tpDeviceStatus))
                            tcDeviceInfo.Controls.Add(tpDeviceStatus);

                        if (m_CurrentDeviceNodeConfig.wDevType != 0x000F) // != Router
                        {
                            if (!tcDeviceInfo.Controls.Contains(tpChannelInfo))
                                tcDeviceInfo.Controls.Add(tpChannelInfo);
                        }
                        else
                        {
                            if (tcDeviceInfo.Controls.Contains(tpChannelInfo))
                                tcDeviceInfo.Controls.Remove(tpChannelInfo);
                        }

                        if (m_CurrentDeviceNodeConfig.wDevType == 0x0003) //AI
                        {
                            if (!tcDeviceInfo.Controls.Contains(tpChannelStatus))
                                tcDeviceInfo.Controls.Add(tpChannelStatus);
                            if (!tcDeviceInfo.Controls.Contains(tpSetRange))
                                tcDeviceInfo.Controls.Add(tpSetRange);
                        }
                        else
                        {
                            if (tcDeviceInfo.Controls.Contains(tpChannelStatus))
                                tcDeviceInfo.Controls.Remove(tpChannelStatus);
                            if (tcDeviceInfo.Controls.Contains(tpSetRange))
                                tcDeviceInfo.Controls.Remove(tpSetRange);
                        }
                    }
                    break;
            }

            tcDeviceInfo_SelectedIndexChanged(this, null);
        }

        private void RefreshCoordinatorInformation()
        {
            m_adamCom.Adam2000(m_iCoordinatorSlaveId).GetFixInformation(0, ref m_CoordinatorConfig);
            m_adamCom.Adam2000(m_iCoordinatorSlaveId).GetCoordinator(ref m_CoordinatorConfig);
        }

        private void RefreshEndDeviceInformation(ushort usShortAddr, ref Adam2000Config tempAdam2000Config)
        {
            for (int i = 0; i < this.m_deviceList.Count; i++)
            {
                if (((Adam2000Config)m_deviceList[i]).wShortAddr == usShortAddr)
                {
                    tempAdam2000Config = (Adam2000Config)m_deviceList[i];
                    m_adamCom.Adam2000(m_iCoordinatorSlaveId).GetFixInformation(((Adam2000Config)m_deviceList[i]).wShortAddr, ref tempAdam2000Config);
                    m_adamCom.Adam2000(m_iCoordinatorSlaveId).GetVariationInformation(((Adam2000Config)m_deviceList[i]).wShortAddr, ref tempAdam2000Config);
                    m_deviceList[i] = tempAdam2000Config;
                }
            }
        }

        private void tcDeviceInfo_SelectedIndexChanged(object sender, EventArgs e)
        {  
            Cursor.Current = Cursors.WaitCursor;

            m_iQueryCount = 0;
            timerPollingData.Enabled = false;
            bPolling.Text = "Polling";
            lPollingTimes.Text = "Polling Times : ";

            try
            {
                if (tcDeviceInfo.SelectedTab == tpInformation)
                    RefreshModuleInformation();
                else if (tcDeviceInfo.SelectedTab == tpDeviceStatus)
                    RefreshDeviceStatus();
                else if (tcDeviceInfo.SelectedTab == tpChannelInfo)
                    RefreshChannelInfoPage();
                else if (tcDeviceInfo.SelectedTab == tpChannelStatus)
                    RefreshChannelStatus();
                else if (tcDeviceInfo.SelectedTab == tpSetRange)
                    RefreshSetRangePage();
                else if (tcDeviceInfo.SelectedTab == tpDeviceList)
                    RefreshDeviceListPage();
            }
            catch
            {
            }
            Cursor.Current = Cursors.Default;
        }

        private void tcDeviceInfo_Selecting(object sender, TabControlCancelEventArgs e)
        {
            e.Cancel = !((Control)e.TabPage).Enabled;
        }

        private string GetModuleDescription(Adam2000Config tempAdam2000Config)
        {
            string strRet = "Unknown";

            if (tempAdam2000Config.GetModuleName().Contains("2520Z"))
                strRet = "Wireless Sensor Network Modbus RTU Gateway";
            else if (tempAdam2000Config.GetModuleName().Contains("2510Z"))
                strRet = "Wireless Sensor Network Router Node";
            else if (tempAdam2000Config.GetModuleName().Contains("2017Z"))
                strRet = "Wireless Sensor Network 6-ch Analog Input Node";
            else if (tempAdam2000Config.GetModuleName().Contains("2017PZ"))
                strRet = "Wireless Sensor Network 6-ch Analog Input Node";
            else if (tempAdam2000Config.GetModuleName().Contains("2031Z"))
                strRet = "Wireless Sensor Network Temperature, Humidity Sensor Node";
            else if (tempAdam2000Config.GetModuleName().Contains("2051Z"))
                strRet = "Wireless Sensor Network 8-ch Digital Input Node";
            else if (tempAdam2000Config.GetModuleName().Contains("2051PZ"))
                strRet = "Wireless Sensor Network 8-ch Digital Input Node";

            return strRet;
        }

        private bool QueryChannelStatus()
        {
            bool bRet = true;
            int iAiStatusStart = 101;
            int AiChNum = 6;
            int[] iAiStatus;
            listViewChStatus.Items.Clear();

            if (m_adamCom.Modbus(m_CurrentDeviceNodeConfig.wMBSlaveID).ReadHoldingRegs(iAiStatusStart, (AiChNum * 2), out iAiStatus))
            {
                for (int i = 0; i < AiChNum; i++)
                {
                    listViewChStatus.Items.Add("AI");
                    listViewChStatus.Items[i].SubItems.Add(i.ToString());
                    listViewChStatus.Items[i].SubItems.Add((4000 + iAiStatusStart + (i*2)).ToString());
                    listViewChStatus.Items[i].SubItems.Add(iAiStatus[(i * 2)].ToString());
                    listViewChStatus.Items[i].SubItems.Add(GetChannelStatusString((ushort)iAiStatus[(i * 2)]));
                }
            }
            else
            {
                bRet = false;
                MessageBox.Show("Error: Read Holding Register fail!");
                return bRet;
            }
            return bRet;
        }

        private string GetChannelStatusString(ushort usStatusValue)
        {
            string szMsg = string.Empty;
            if ((usStatusValue & AD_Convert_Timeout) == AD_Convert_Timeout)
            {
                szMsg = "A/D convert timeout (fail)";
            }
            else if ((usStatusValue & Over_Range) == Over_Range)
            {
                szMsg = "Over Range";
            }
            else if ((usStatusValue & Under_Range) == Under_Range)
            {
                szMsg = "Under_Range";
            }
            else if ((usStatusValue & Open_Circuit_Burnout) == Open_Circuit_Burnout)
            {
                szMsg = "Open Circuit (Burnout)";
            }
            else if ((usStatusValue & Not_Converted_Yet) == Not_Converted_Yet)
            {
                szMsg = "Not converted yet";
            }
            else if ((usStatusValue & ADC_Initializing_Error) == ADC_Initializing_Error)
            {
                szMsg = "ADC initializing/Error";
            }
            else if ((usStatusValue & Zero_Span_Calibration_Error) == Zero_Span_Calibration_Error)
            {
                szMsg = "Zero/Span Calibration Error";
            }

            if (szMsg == string.Empty)
                szMsg = "Normal";

            return szMsg;
        }

        private void RefreshModuleInformation()
        {

            if (m_CurrentDeviceNodeConfig.wFwVerNo.ToString("X04").Length == 4)
                txtFwVerZigBee.Text = m_CurrentDeviceNodeConfig.wFwVerNo.ToString("X04").Insert(2, ".");
            else
                txtFwVerZigBee.Text = m_CurrentDeviceNodeConfig.wFwVerNo.ToString("X04");

            txtDeviceName.Text = m_CurrentDeviceNodeConfig.GetModuleName().ToString();
            txtDescription.Text = GetModuleDescription(m_CurrentDeviceNodeConfig);

            txtPanId.Text = Convert.ToString(m_CurrentDeviceNodeConfig.wPanID);
            txtSlaveId.Text = Convert.ToString(m_CurrentDeviceNodeConfig.wMBSlaveID);
            txtChannel.Text = Convert.ToString(m_CurrentDeviceNodeConfig.wWirelessCh);

            if ((m_CurrentDeviceNodeConfig.wDevType == 0x0001) || //DI
                (m_CurrentDeviceNodeConfig.wDevType == 0x0002) || //DO
                (m_CurrentDeviceNodeConfig.wDevType == 0x0003) || //AI
                (m_CurrentDeviceNodeConfig.wDevType == 0x0004) || //AO
                (m_CurrentDeviceNodeConfig.wDevType == 0x000D) || //Sensor
                (m_CurrentDeviceNodeConfig.wDevType == 0x000F)) //Router
            {
                labKernal.Visible = false;
                txtFwVerKernal.Visible = false;
                labPAddr.Visible = true;
                txtPAddr.Visible = true;
                labSAddr.Visible = true;
                txtSAddr.Visible = true;
                labDataCycle.Visible = true;
                txtDataCycle.Visible = true;

                uint tempVal = Convert.ToUInt32(m_CurrentDeviceNodeConfig.wParentShortAddr);
                txtPAddr.Text = "0x" + String.Format("{0:X4}", tempVal);

                tempVal = Convert.ToUInt32(m_CurrentDeviceNodeConfig.wShortAddr);
                txtSAddr.Text = "0x" + String.Format("{0:X4}", tempVal);

                txtDataCycle.Text = Convert.ToString(m_CurrentDeviceNodeConfig.dwActCycle);
            }
            else
            {
                labKernal.Visible = true;
                txtFwVerKernal.Visible = true;
                labPAddr.Visible = false;
                txtPAddr.Visible = false;
                labSAddr.Visible = false;
                txtSAddr.Visible = false;
                labDataCycle.Visible = false;
                txtDataCycle.Visible = false;

                if (m_CurrentDeviceNodeConfig.w430FwVer.ToString("X04").Length == 4)
                    txtFwVerKernal.Text = m_CurrentDeviceNodeConfig.w430FwVer.ToString("X04").Insert(2, ".");
                else
                    txtFwVerKernal.Text = m_CurrentDeviceNodeConfig.w430FwVer.ToString("X04");
            }
        }

        private void RefreshChannelInfoPage()
        {
            listViewChannelInfo.Items.Clear();
            listViewChannelInfo.BeginUpdate();

            if (m_CurrentDeviceNodeConfig.wDevType == 0x0001) //DI
            {
                m_ChannelNumber = 8;            
                InitialDI(m_CurrentDeviceNodeConfig);
            }
            else if (m_CurrentDeviceNodeConfig.wDevType == 0x000D) //Sensor
            {
                m_ChannelNumber = 2;
                InitialSensor(m_CurrentDeviceNodeConfig);
            }
            else if (m_CurrentDeviceNodeConfig.wDevType == 0x0003) //AI
            {
                m_ChannelNumber = 6;
                m_usRanges = new ushort[m_ChannelNumber];
                UpdateRangesValue();
                InitialAI(m_CurrentDeviceNodeConfig);
            }
            else // Others
            {
            }
            listViewChannelInfo.EndUpdate();
            listViewChannelInfo.BringToFront();
        }

        private void InitialDI(Adam2000Config tempAdam2000Config)
        {
            int start = 00001;
            bool[] bStatus;
            listViewChannelInfo.Columns[4].Text = "Mode";

            if (!m_adamCom.Modbus(tempAdam2000Config.wMBSlaveID).ReadCoilStatus(start, m_ChannelNumber, out bStatus))
            {
                MessageBox.Show("Read Coil Status Fail : " + m_adamCom.Modbus(tempAdam2000Config.wMBSlaveID).LastError.ToString());
            }

            string strLQI = string.Empty;
            if ((tempAdam2000Config.wLQI >= 0) && (tempAdam2000Config.wLQI <= 255))
                strLQI = (Convert.ToInt32(tempAdam2000Config.wLQI) * 100 / 255).ToString() + "%";  //LQI, from 0~255
            else
                strLQI = "--";  //LQI, but data not fall in reasonable range

            for (int i = 0; i < m_ChannelNumber; i++)
            {
                listViewChannelInfo.Items.Add("DI"); //Type
                listViewChannelInfo.Tag = i;  
                listViewChannelInfo.Items[i].SubItems.Add(i.ToString()); //Ch Number
                listViewChannelInfo.Items[i].SubItems.Add("0000" + (i + 1).ToString()); //Modbus Addr
                if (bStatus[i]) //Value
                {
                    listViewChannelInfo.Items[i].SubItems.Add("1");  
                }
                else
                {
                    listViewChannelInfo.Items[i].SubItems.Add("0");  
                }

                listViewChannelInfo.Items[i].SubItems.Add("BOOL"); //Mode

                if (((Byte)tempAdam2000Config.wModuleStatus & 0x01) == 1) //Normal mode
                {
                    DateTime time = DateTime.Now;   // fetch current time
                    listViewChannelInfo.Items[i].SubItems.Add(tempAdam2000Config.dwActCycle.ToString() + "s"); //Cycle Time
                    listViewChannelInfo.Items[i].SubItems.Add(strLQI); //LQI
                    listViewChannelInfo.Items[i].SubItems.Add(time.ToString("G")); //G is data format like "3/9/2008 4:05:07 PM" 
                }
                else
                {
                    listViewChannelInfo.Items[i].SubItems.Add("1s (initial mode)"); //Cycle Time
                    listViewChannelInfo.Items[i].SubItems.Add(strLQI); //LQI
                    listViewChannelInfo.Items[i].SubItems.Add("");
                }
            }
        }

        private void InitialAI(Adam2000Config tempAdam2000Config)
        {
            listViewChannelInfo.Columns[4].Text = "Range";

            string strLQI = string.Empty;
            if ((tempAdam2000Config.wLQI >= 0) && (tempAdam2000Config.wLQI <= 255))
                strLQI = (Convert.ToInt32(tempAdam2000Config.wLQI) * 100 / 255).ToString() + "%";  //LQI, from 0~255
            else
                strLQI = "--";  //LQI, but data not fall in reasonable range

            for (int i = 0; i < m_ChannelNumber; i++)
            {
                listViewChannelInfo.Items.Add("AI"); //Type
                listViewChannelInfo.Tag = i;
                listViewChannelInfo.Items[i].SubItems.Add(i.ToString()); //Ch Number
                listViewChannelInfo.Items[i].SubItems.Add((40000 + i + 1).ToString()); //Modbus Addr
                listViewChannelInfo.Items[i].SubItems.Add("*****"); //Value
                listViewChannelInfo.Items[i].SubItems.Add(AnalogInput.GetRangeName(m_usRanges[i])); //Range

                if (((Byte)tempAdam2000Config.wModuleStatus & 0x01) == 1) //Normal mode
                {
                    DateTime time = DateTime.Now;   // fetch current time
                    listViewChannelInfo.Items[i].SubItems.Add(tempAdam2000Config.dwActCycle.ToString() + "s"); //Cycle Time
                    listViewChannelInfo.Items[i].SubItems.Add(strLQI); //LQI
                    listViewChannelInfo.Items[i].SubItems.Add(time.ToString("G")); //G is data format like "3/9/2008 4:05:07 PM" 
                }
                else
                {
                    listViewChannelInfo.Items[i].SubItems.Add("1s (initial mode)"); //Cycle Time
                    listViewChannelInfo.Items[i].SubItems.Add(strLQI); //LQI
                    listViewChannelInfo.Items[i].SubItems.Add("");
                }
            }
        }

        private void InitialSensor(Adam2000Config tempAdam2000Config)
        {
            listViewChannelInfo.Columns[4].Text = "Unit";

            string strLQI = string.Empty;
            if ((tempAdam2000Config.wLQI >= 0) && (tempAdam2000Config.wLQI <= 255))
                strLQI = (Convert.ToInt32(tempAdam2000Config.wLQI) * 100 / 255).ToString() + "%";  //LQI, from 0~255
            else
                strLQI = "--";  //LQI, but data not fall in reasonable range

            for (int i = 0; i < m_ChannelNumber; i++)
            {
                if (0 == i)
                {
                    listViewChannelInfo.Items.Add("Temp."); //Type
                    listViewChannelInfo.Tag = i;
                    listViewChannelInfo.Items[i].SubItems.Add(i.ToString()); //Ch Number
                    listViewChannelInfo.Items[i].SubItems.Add((40000 + i + 1).ToString()); //Modbus Addr
                    listViewChannelInfo.Items[i].SubItems.Add("*****"); //Value
                    listViewChannelInfo.Items[i].SubItems.Add("C"); //Unit                    
                }
                else if (1 == i)
                {
                    listViewChannelInfo.Items.Add("Humidity"); //Type
                    listViewChannelInfo.Tag = i;
                    listViewChannelInfo.Items[i].SubItems.Add(i.ToString()); //Ch Number
                    listViewChannelInfo.Items[i].SubItems.Add((40000 + i + 1).ToString()); //Modbus Addr
                    listViewChannelInfo.Items[i].SubItems.Add("*****"); //Value
                    listViewChannelInfo.Items[i].SubItems.Add("%"); //Unit                  
                }

                if (((Byte)tempAdam2000Config.wModuleStatus & 0x01) == 1) //Normal mode
                {
                    DateTime time = DateTime.Now;   // fetch current time
                    listViewChannelInfo.Items[i].SubItems.Add(tempAdam2000Config.dwActCycle.ToString() + "s"); //Cycle Time
                    listViewChannelInfo.Items[i].SubItems.Add(strLQI); //LQI
                    listViewChannelInfo.Items[i].SubItems.Add(time.ToString("G")); //G is data format like "3/9/2008 4:05:07 PM" 
                }
                else
                {
                    listViewChannelInfo.Items[i].SubItems.Add("1s (initial mode)"); //Cycle Time
                    listViewChannelInfo.Items[i].SubItems.Add(strLQI); //LQI
                    listViewChannelInfo.Items[i].SubItems.Add("");
                }
            }
        }

        private bool RefreshData()
        {
            bool bRet = true;
            byte[] byEndDeviceData;
            int start = 00001; //data start address nuder ADAM-2000 protocol definition
            int intInactiveTime = 0;

            try
            {
                //Modbus EndDevice address defined under ADAM-2000 protocol
                //301	1 Register(2 bytes)	Module Status
                //302	1 Register(2 bytes)	Wireless Signal Intensity (LQI)
                //303	1 Register(2 bytes)	Battery Estimation
                //304	2 Register(4 bytes)	Device Inactive Period (unit:sec)
                start = 301;
                if (!m_adamCom.Modbus(m_CurrentDeviceNodeConfig.wMBSlaveID).ReadHoldingRegs(start, 5, out byEndDeviceData)) //read 4 registers, 10 bytes
                {
                    MessageBox.Show("Read Holding Regs Fail: " + m_adamCom.Modbus(m_CurrentDeviceNodeConfig.wMBSlaveID).LastError.ToString());
                    bRet = false;
                    return bRet;
                }

                intInactiveTime = (Convert.ToInt32(byEndDeviceData[6]) << 24) + Convert.ToInt32(byEndDeviceData[7] << 16) +
                                           (Convert.ToInt32(byEndDeviceData[8]) << 8) + Convert.ToInt32(byEndDeviceData[9]);

                string strLQI = string.Empty;
                if ((byEndDeviceData[3] >= 0) && (byEndDeviceData[3] <= 255))
                    strLQI = (byEndDeviceData[3] * 100 / 255).ToString() + "%";  //LQI, from 0~255
                else
                    strLQI = "--"; //LQI, but data not fall in reasonable range

                if (m_CurrentDeviceNodeConfig.wDevType == 0x0001) //DI
                {
                    bool[] bVal;
                    start = 001;
                    if (!m_adamCom.Modbus(m_CurrentDeviceNodeConfig.wMBSlaveID).ReadCoilStatus(start, m_ChannelNumber, out bVal))
                    {
                        MessageBox.Show("Read Coil Status Fail: " + m_adamCom.Modbus(m_CurrentDeviceNodeConfig.wMBSlaveID).LastError.ToString());
                        bRet = false;
                        return bRet;
                    }

                    for (int i = 0; i < m_ChannelNumber; i++)
                    {
                        string strValue = string.Empty;
                        if (bVal[i])
                        {
                            strValue = "1";
                        }
                        else
                        {
                            strValue = "0";
                        }
                        DateTime time = DateTime.Now;   // fetch current time
                        time = time.AddSeconds(-(intInactiveTime));
                        listViewChannelInfo.Items[i].SubItems[3].Text = strValue; //Value
                        listViewChannelInfo.Items[i].SubItems[5].Text = m_CurrentDeviceNodeConfig.dwActCycle.ToString() + "s"; //Data Cycle;
                        listViewChannelInfo.Items[i].SubItems[6].Text = strLQI; //LQI
                        if (((Byte)m_CurrentDeviceNodeConfig.wModuleStatus & 0x01) == 1) //Normal mode
                        {
                            listViewChannelInfo.Items[i].SubItems[7].Text = time.ToString("G"); //G is data format like "3/9/2008 4:05:07 PM" 
                        }
                        else
                        {
                            listViewChannelInfo.Items[i].SubItems[7].Text = string.Empty; 
                        }
                    }
                }
                else if (m_CurrentDeviceNodeConfig.wDevType == 0x000D) //Sensor
                {
                    byte[] byData;
                    ushort[] usVal = new ushort[m_ChannelNumber];
                    string strValue = string.Empty;
                    start = 001;

                    if (!m_adamCom.Modbus(m_CurrentDeviceNodeConfig.wMBSlaveID).ReadHoldingRegs(start, m_ChannelNumber, out byData))
                    {
                        MessageBox.Show("Read Holding Registers Fail: " + m_adamCom.Modbus(m_CurrentDeviceNodeConfig.wMBSlaveID).LastError.ToString());
                        bRet = false;
                        return bRet;
                    }

                    for (int i = 0; i < m_ChannelNumber; i++)
                    {
                        usVal[i] = Convert.ToUInt16((Convert.ToUInt32(byData[i * 2]) << 8) | Convert.ToUInt32(byData[i * 2 + 1]));

                        if (0 == i)
                            strValue = (Adam2000.ConvertToEngineerData((int)Adam2kChannelType.Temperature, usVal[i])).ToString("F1"); //temperature, degree C
                        else if (1 == i)
                            strValue = (Adam2000.ConvertToEngineerData((int)Adam2kChannelType.Humidity, usVal[i])).ToString("F1"); //humidity, %
                        else
                            strValue = (usVal[i]).ToString();

                        DateTime time = DateTime.Now;   // fetch current time
                        time = time.AddSeconds(-(intInactiveTime));
                        listViewChannelInfo.Items[i].SubItems[3].Text = strValue; //Value
                        listViewChannelInfo.Items[i].SubItems[5].Text = m_CurrentDeviceNodeConfig.dwActCycle.ToString() + "s"; //Data Cycle;
                        listViewChannelInfo.Items[i].SubItems[6].Text = strLQI; //LQI
                        if (((Byte)m_CurrentDeviceNodeConfig.wModuleStatus & 0x01) == 1) //Normal mode
                        {
                            listViewChannelInfo.Items[i].SubItems[7].Text = time.ToString("G"); //G is data format like "3/9/2008 4:05:07 PM" 
                        }
                        else
                        {
                            listViewChannelInfo.Items[i].SubItems[7].Text = string.Empty;
                        }
                    }
                }
                else if (m_CurrentDeviceNodeConfig.wDevType == 0x0003) //AI
                {
                    ushort[] usVal;
                    byte[] byChannelStatus;
                    string strValue = string.Empty;

                    if (!m_adamCom.Adam2000(Convert.ToInt32(m_iCoordinatorSlaveId)).GetVariationInformation(Convert.ToUInt16(m_CurrentDeviceNodeConfig.wShortAddr), ref m_CurrentDeviceNodeConfig, out byChannelStatus, out usVal))
                    {
                        MessageBox.Show("Read Get Variation Information Fail: " + m_adamCom.Modbus(m_CurrentDeviceNodeConfig.wMBSlaveID).LastError.ToString());
                        bRet = false;
                        return bRet;
                    }

                    for (int i = 0; i < m_ChannelNumber; i++)
                    {
                        DateTime time = DateTime.Now;   // fetch current time
                        time = time.AddSeconds(-(intInactiveTime));
                        float fVal = AnalogInput.GetScaledValue(this.m_usRanges[i], usVal[i]);
                        strValue = fVal.ToString(AnalogInput.GetFloatFormat(this.m_usRanges[i]));
                        listViewChannelInfo.Items[i].SubItems[3].Text = strValue;
                        listViewChannelInfo.Items[i].SubItems[5].Text = m_CurrentDeviceNodeConfig.dwActCycle.ToString() + "s"; //Data Cycle;
                        listViewChannelInfo.Items[i].SubItems[6].Text = strLQI; //LQI
                        if (((Byte)m_CurrentDeviceNodeConfig.wModuleStatus & 0x01) == 1) //Normal mode
                        {
                            listViewChannelInfo.Items[i].SubItems[7].Text = time.ToString("G"); //G is data format like "3/9/2008 4:05:07 PM" 
                        }
                        else
                        {
                            listViewChannelInfo.Items[i].SubItems[7].Text = string.Empty;
                        }
                    }
                }
            }
            catch
            {
                bRet = false;
            }
            listViewChannelInfo.BringToFront();
            return bRet;
        }

        private void RefreshDeviceStatus()
        {
            if ((m_CurrentDeviceNodeConfig.wDevType == 0x0001) || //DI
                (m_CurrentDeviceNodeConfig.wDevType == 0x0002) || //DO
                (m_CurrentDeviceNodeConfig.wDevType == 0x0003) || //AI
                (m_CurrentDeviceNodeConfig.wDevType == 0x0004) || //AO
                (m_CurrentDeviceNodeConfig.wDevType == 0x000D) || //Sensor
                (m_CurrentDeviceNodeConfig.wDevType == 0x000F)) //Router
            {
                if ((m_CurrentDeviceNodeConfig.wLQI >= 0) && (m_CurrentDeviceNodeConfig.wLQI <= 255))
                    txtLink.Text = Convert.ToString((m_CurrentDeviceNodeConfig.wLQI * 100 / 255)) + "%"; //LQI is from 0~255
                else
                    txtLink.Text = "--";  //LQI, but data not fall in reasonable range 

                if (Convert.ToBoolean(m_CurrentDeviceNodeConfig.wModuleStatus & 0x02))
                {
                    txtPower.Text = "Yes";
                    txtBattery.Text = "--"; //Battery level is from 0~65535
                }
                else
                {
                    txtPower.Text = "No";
                    txtBattery.Text = Convert.ToString((m_CurrentDeviceNodeConfig.wBetteryStatus * 100 / 65535)) + "%"; //Battery status is from 0~65535
                }

                if (Convert.ToBoolean(m_CurrentDeviceNodeConfig.wModuleStatus & 0x01))
                    txtModeStatus.Text = "Normal";
                else
                    txtModeStatus.Text = "Initial";  
            }
            else
            {
                txtModeStatus.Text = string.Empty;
                txtLink.Text = string.Empty;
                txtBattery.Text = string.Empty;
                txtPower.Text = string.Empty;
            }
        }

        private void bGetChStatus_Click(object sender, EventArgs e)
        {
            if (!QueryChannelStatus())
            {
                MessageBox.Show("Query Function Failed");
            }
        }

        private void RefreshChannelStatus()
        {
            listViewChStatus.Items.Clear();

            if (m_CurrentDeviceNodeConfig.wDevType == 0x0003) //AI
            {
                bGetChStatus.Enabled = true;
                bClearLvChStatus.Enabled = true;
            }
            else
            {
                bGetChStatus.Enabled = false;
                bClearLvChStatus.Enabled = false;
            }
        }

        private void RefreshSetRangePage()
        {
            if (m_CurrentDeviceNodeConfig.wDevType == 0x0003) //AI
            {
                bGetConfig.Enabled = true;
                bSetRange.Enabled = true;
            }
            else
            {
                bGetConfig.Enabled = false;
                bSetRange.Enabled = false;
            }
        }

        private void RefreshDeviceListPage()
        {
            byte[] byEndDeviceData;
            int start = 00001; //data start address nuder ADAM-2000 protocol definition

            if (m_CurrentDeviceNodeConfig.wDevType == 0x000E) //Coordinator
            {
                bDeviceListRefresh.Enabled = true;
            }
            else
            {
                bDeviceListRefresh.Enabled = false;
                return;
            }

            listViewDeviceList.Items.Clear();
            listViewDeviceList.BeginUpdate();
            for (int i = 0; i < m_deviceList.Count; i++)
            {
                Adam2000Config tempAdam2000Config;
                tempAdam2000Config = (Adam2000Config)m_deviceList[i];
                RefreshEndDeviceInformation(tempAdam2000Config.wShortAddr, ref tempAdam2000Config);
                string strDeviceName = tempAdam2000Config.GetModuleName().ToString(); //Module name
                string strSlaveId = tempAdam2000Config.wMBSlaveID.ToString("D3") + " (" + tempAdam2000Config.wMBSlaveID.ToString("X2") + "h)"; //Slave ID

                //Modbus EndDevice address defined under ADAM-2000 protocol
                //301	1 Register(2 bytes)	Module Status
                //302	1 Register(2 bytes)	Wireless Signal Intensity (LQI)
                //303	1 Register(2 bytes)	Battery Estimation
                //304	2 Register(4 bytes)	Device Inactive Period (unit:sec)
                start = 301;
                if (!m_adamCom.Modbus(tempAdam2000Config.wMBSlaveID).ReadHoldingRegs(start, 5, out byEndDeviceData)) //read 4 registers, 10 bytes
                {
                    MessageBox.Show("Read Holding Regs Fail: " + m_adamCom.Modbus(tempAdam2000Config.wMBSlaveID).LastError.ToString());
                }

                int intInactiveTime = 0;
                intInactiveTime = (Convert.ToInt32(byEndDeviceData[6]) << 24) + Convert.ToInt32(byEndDeviceData[7] << 16) +
                                           (Convert.ToInt32(byEndDeviceData[8]) << 8) + Convert.ToInt32(byEndDeviceData[9]);

                string strLQI = string.Empty;
                if ((byEndDeviceData[3] >= 0) && (byEndDeviceData[3] <= 255))
                    strLQI = (byEndDeviceData[3] * 100 / 255).ToString() + "%";  //LQI, from 0~255
                else
                    strLQI = "--"; //LQI, but data not fall in reasonable range

                string strInactiveTime = intInactiveTime.ToString() + "s"; //Inactive Time (s)
                string strCycleTime = tempAdam2000Config.dwActCycle.ToString() + "s"; //Cycle Time (s)
                string strShortAddr = "0x" + tempAdam2000Config.wShortAddr.ToString("X4"); //Short address[Hex]
                string strParentShortAddr = "0x" + tempAdam2000Config.wParentShortAddr.ToString("X4"); //Parent short address[Hex]
                string strStatus = string.Empty;
                if ((Convert.ToInt32(tempAdam2000Config.wModuleStatus) & 0x01) == 0)
                    strStatus = "Initial"; //Module status
                else
                    strStatus = "Normal"; //Module status

                listViewDeviceList.Items.Add(strDeviceName);
                listViewDeviceList.Items[i].SubItems.Add(strSlaveId);
                listViewDeviceList.Items[i].SubItems.Add(strLQI);
                listViewDeviceList.Items[i].SubItems.Add(strInactiveTime);
                listViewDeviceList.Items[i].SubItems.Add(strCycleTime);
                listViewDeviceList.Items[i].SubItems.Add(strShortAddr);
                listViewDeviceList.Items[i].SubItems.Add(strParentShortAddr);
                listViewDeviceList.Items[i].SubItems.Add(strStatus);
            }
            listViewDeviceList.EndUpdate();
        }

        private void bClearLvChStatus_Click(object sender, EventArgs e)
        {
            listViewChStatus.Items.Clear();
        }

        private void UpdateRangesValue( )
        {
            // Read from flash
            int iRecvLen = 0;
            int iLength = 4 + 10;
            byte[] byCmd = new byte[4 + 10 + 6];
            byte[] byRecv = new byte[256];
            int iSAddr = 0x0000;
            int iCAddr = 0x0000;

            //End Device Short Address 
            iSAddr = m_CurrentDeviceNodeConfig.wShortAddr;

            // Coordinator ID
            iCAddr = m_iCoordinatorSlaveId;

            // 4 Bytes 
            byCmd[0] = 0xFF;    //Coordinator header
            byCmd[1] = 0x5A;    //Coordinator header
            byCmd[2] = Convert.ToByte(iCAddr & 0xFF);                 // Coordinator ID Low 
            byCmd[3] = Convert.ToByte((iCAddr >> 8) & 0xFF);          // Coordinator ID High
            // 10 Bytes
            byCmd[4 + 0] = Convert.ToByte(iSAddr & 0xFF);             //Short Address Low
            byCmd[4 + 1] = Convert.ToByte((iSAddr >> 8) & 0xFF);      //Short Address High

            // Message 0x0000 Register Query
            byCmd[4 + 2] = 0x00;    //Message Type Low        
            byCmd[4 + 3] = 0x00;    //Message Type High      

            byCmd[4 + 4] = 0x01;    //Packet Version Low
            byCmd[4 + 5] = 0x00;    //Packet Version High
            byCmd[4 + 6] = 0x01;    //Sequence Number Low
            byCmd[4 + 7] = 0x00;    //Sequence Number High
            byCmd[4 + 8] = 0x00;    //CmdCode Low (Reserved)
            byCmd[4 + 9] = 0x00;    //CmdCode High (Reserved)

            m_adamCom.SetPurge(0x000C);

            if (m_adamCom.Send(iLength, byCmd) == (4 + 10))
            {
                //   if ((iRecvLen = m_adamCom.Recv(byRecv.Length, ref byRecv)) >= 10 + 4 + txtEchoContent.Text.Length)
                if ((iRecvLen = m_adamCom.Recv(byRecv.Length, ref byRecv)) >= 10 + 4 + 12) // 4 Bytes header + 10 Bytes code + 12 Bytes data
                {
                    //   if(byRecv[5] == 0x00 && byRecv[6] == 0x01)   // expected message type code
                    if (byRecv[6] == 0x01 && byRecv[7] == 0x00)
                    {

                        for (int i = 49; i < 60 + 4; i++)
                        {
                            // Update Range Code for each channel
                            if (i >= 49 && i <= 59 && i % 2 == 1)
                            {
                                byte byHigh = byRecv[i];
                                byte byLow = byRecv[i - 1];
                                int iIndex = i;
                                int iRangeCode = 0;

                                iRangeCode = ((byHigh & 0x00ff) << 8) | byLow;

                                switch (iIndex)
                                {
                                    case 49:
                                        m_usRanges[0] = (ushort)iRangeCode;
                                        break;
                                    case 51:
                                        m_usRanges[1] = (ushort)iRangeCode;
                                        break;
                                    case 53:
                                        m_usRanges[2] = (ushort)iRangeCode;
                                        break;
                                    case 55:
                                        m_usRanges[3] = (ushort)iRangeCode;
                                        break;
                                    case 57:
                                        m_usRanges[4] = (ushort)iRangeCode;
                                        break;
                                    case 59:
                                        m_usRanges[5] = (ushort)iRangeCode;
                                        break;
                                }
                            }
                        }
                    }
                    else
                        MessageBox.Show("Function Fail");
                }
                else
                    MessageBox.Show("Fail: Receive Fail ");
            }
            else
                MessageBox.Show("Fail: Send Fail");
        }

        private void UpdateUICombooBox(byte byHigh, byte byLow, int iIndex)
        {
            int iChangeIndex = 1;
            int iRangeCode = 0;
            iRangeCode = ((byHigh & 0x00ff) << 8) | byLow;

            switch (iRangeCode)
            {
                case 0x0103:
                    iChangeIndex = 0;
                    break;
                case 0x0104:
                    iChangeIndex = 1;
                    break;
                case 0x0140:
                    iChangeIndex = 2;
                    break;
                case 0x0142:
                    iChangeIndex = 3;
                    break;
                case 0x0143:
                    iChangeIndex = 4;
                    break;
                case 0x0181:
                    iChangeIndex = 5;
                    break;
                case 0x0182:
                    iChangeIndex = 6;
                    break;
                case 0x0180:
                    iChangeIndex = 7;
                    break;

            }

            switch (iIndex)
            {
                case 49:
                    cbCh0.SelectedIndex = iChangeIndex;
                    break;
                case 51:
                    cbCh1.SelectedIndex = iChangeIndex;
                    break;
                case 53:
                    cbCh2.SelectedIndex = iChangeIndex;
                    break;
                case 55:
                    cbCh3.SelectedIndex = iChangeIndex;
                    break;
                case 57:
                    cbCh4.SelectedIndex = iChangeIndex;
                    break;
                case 59:
                    cbCh5.SelectedIndex = iChangeIndex;
                    break;
            }
        }

        private void bGetConfig_Click(object sender, EventArgs e)
        {
            // Read from flash
            int iRecvLen = 0;
            int iLength = 4 + 10;
            byte[] byCmd = new byte[4 + 10 + 6];
            byte[] byRecv = new byte[256];
            int iSAddr = 0x0000;
            int iCAddr = 0x0000;

            //End Device Short Address 
            iSAddr = m_CurrentDeviceNodeConfig.wShortAddr;

            // Coordinator ID
            iCAddr = m_iCoordinatorSlaveId;

            // 4 Bytes 
            byCmd[0] = 0xFF;    //Coordinator header
            byCmd[1] = 0x5A;    //Coordinator header
            byCmd[2] = Convert.ToByte(iCAddr & 0xFF);                 // Coordinator ID Low 
            byCmd[3] = Convert.ToByte((iCAddr >> 8) & 0xFF);          // Coordinator ID High
            // 10 Bytes
            byCmd[4 + 0] = Convert.ToByte(iSAddr & 0xFF);             //Short Address Low
            byCmd[4 + 1] = Convert.ToByte((iSAddr >> 8) & 0xFF);      //Short Address High

            // Message 0x0000 Register Query
            byCmd[4 + 2] = 0x00;    //Message Type Low        
            byCmd[4 + 3] = 0x00;    //Message Type High      

            byCmd[4 + 4] = 0x01;    //Packet Version Low
            byCmd[4 + 5] = 0x00;    //Packet Version High
            byCmd[4 + 6] = 0x01;    //Sequence Number Low
            byCmd[4 + 7] = 0x00;    //Sequence Number High
            byCmd[4 + 8] = 0x00;    //CmdCode Low (Reserved)
            byCmd[4 + 9] = 0x00;    //CmdCode High (Reserved)

            m_adamCom.SetPurge(0x000C);

            if (m_adamCom.Send(iLength, byCmd) == (4 + 10))
            {
                //   if ((iRecvLen = m_adamCom.Recv(byRecv.Length, ref byRecv)) >= 10 + 4 + txtEchoContent.Text.Length)
                if ((iRecvLen = m_adamCom.Recv(byRecv.Length, ref byRecv)) >= 10 + 4 + 12) // 4 Bytes header + 10 Bytes code + 12 Bytes data
                {
                    //   if(byRecv[5] == 0x00 && byRecv[6] == 0x01)   // expected message type code
                    if (byRecv[6] == 0x01 && byRecv[7] == 0x00)
                    {

                        for (int i = 0; i < 72 + 4; i++)
                        {
                            // Update Range Code for each channel
                            if (i >= 49 && i <= 59 && i % 2 == 1)
                            {
                                UpdateUICombooBox(byRecv[i], byRecv[i - 1], i);
                            }

                            /* byRecv[60] function enable byte */
                            // Update burnout Enable
                            if ((byRecv[60] & 0x01) == 0)
                            {
                                cbBurnOutEnable.SelectedIndex = 1;  // Disable
                            }
                            else
                            {
                                cbBurnOutEnable.SelectedIndex = 0;  // Enable
                            }

                            // update burnout ouput option
                            if (((byRecv[60] & 0x02) >> 1) == 0)
                            {
                                cbBurnOutPresent.SelectedIndex = 0; // Low
                            }
                            else
                            {
                                cbBurnOutPresent.SelectedIndex = 1; // High
                            }

                            // update Filter Mode 
                            if (((byRecv[60] & 0x30) >> 4) == 0)
                            {
                                cbUpdateRate.SelectedIndex = 0;
                            }
                            else if (((byRecv[60] & 0x30) >> 4) == 1)
                            {
                                cbUpdateRate.SelectedIndex = 1;
                            }
                            else if (((byRecv[60] & 0x30) >> 4) == 2)
                            {
                                cbUpdateRate.SelectedIndex = 2;
                            }

                            /* byRecv[61] Channel Mask byte */
                            if ((byRecv[61] & 0x01) == 1)
                            {
                                ckCH0.Checked = true;
                            }
                            else
                            {
                                ckCH0.Checked = false;
                            }

                            if ((byRecv[61] & 0x02) == 2)
                            {
                                ckCH1.Checked = true;
                            }
                            else
                            {
                                ckCH1.Checked = false;
                            }

                            if ((byRecv[61] & 0x04) == 4)
                            {
                                ckCH2.Checked = true;
                            }
                            else
                            {
                                ckCH2.Checked = false;
                            }

                            if ((byRecv[61] & 0x08) == 8)
                            {
                                ckCH3.Checked = true;
                            }
                            else
                            {
                                ckCH3.Checked = false;
                            }

                            if ((byRecv[61] & 0x10) == 0x10)
                            {
                                ckCH4.Checked = true;
                            }
                            else
                            {
                                ckCH4.Checked = false;
                            }

                            if ((byRecv[61] & 0x20) == 0x20)
                            {
                                ckCH5.Checked = true;
                            }
                            else
                            {
                                ckCH5.Checked = false;
                            }
                        }

                    }
                    else
                        MessageBox.Show("Function Fail");

                }
                else
                    MessageBox.Show("Fail: Receive Fail ");
            }
            else
                MessageBox.Show("Fail: Send Fail");
        }

        private Int16 getRangeConfigFromUI(ComboBox cbChannel)
        {
            Int16 selectedRangeCode;
            switch (cbChannel.SelectedIndex)
            {
                case 0:   // +- 150 mV
                    selectedRangeCode = 0x0103;
                    break;
                case 1:   // +-500 mV
                    selectedRangeCode = 0x0104;
                    break;
                case 2:   // +- 1V
                    selectedRangeCode = 0x0140;
                    break;
                case 3:   // +- 5V
                    selectedRangeCode = 0x0142;
                    break;
                case 4:   // +- 10 V
                    selectedRangeCode = 0x0143;
                    break;
                case 5:   // +-20 mA
                    selectedRangeCode = 0x0181;
                    break;
                case 6:   // 0~20mA
                    selectedRangeCode = 0x0182;
                    break;
                case 7:   // 4~20mA
                    selectedRangeCode = 0x0180;
                    break;
                default:
                    selectedRangeCode = 0x0143;
                    break;
            }

            return selectedRangeCode;
        }

        private void bSetRange_Click(object sender, EventArgs e)
        {
            int iRecvLen = 0;
            int iLength = 4 + 10 + 28;
            byte[] byCmd = new byte[4 + 10 + 28];
            byte[] byRecv = new byte[256];
            int iSAddr = 0x0000;
            int iCAddr = 0x0000;

            //End Device Short Address 
            iSAddr = m_CurrentDeviceNodeConfig.wShortAddr;

            // Coordinator ID
            iCAddr = m_iCoordinatorSlaveId;

            // 4 Bytes 
            byCmd[0] = 0xFF;    //Coordinator header
            byCmd[1] = 0x5A;    //Coordinator header
            byCmd[2] = Convert.ToByte(iCAddr & 0xFF);             // Coordinator ID Low 
            byCmd[3] = Convert.ToByte((iCAddr >> 8) & 0xFF);      // Coordinator ID High
            // 10 Bytes
            byCmd[4 + 0] = Convert.ToByte(iSAddr & 0xFF);             //Short Address Low
            byCmd[4 + 1] = Convert.ToByte((iSAddr >> 8) & 0xFF);      //Short Address High

            // Message
            byCmd[4 + 2] = 0x32;    //Message Type Low        
            byCmd[4 + 3] = 0x80;    //Message Type High      

            byCmd[4 + 4] = 0x01;    //Packet Version Low
            byCmd[4 + 5] = 0x00;    //Packet Version High
            byCmd[4 + 6] = 0x01;    //Sequence Number Low
            byCmd[4 + 7] = 0x00;    //Sequence Number High
            byCmd[4 + 8] = 0x00;    //CmdCode Low (Reserved)
            byCmd[4 + 9] = 0x00;    //CmdCode High (Reserved)

            // Ch0~6 Range Code (Little Endian)
            byCmd[14 + 0] = Convert.ToByte(getRangeConfigFromUI(cbCh0) & 0xff);
            byCmd[14 + 1] = Convert.ToByte((getRangeConfigFromUI(cbCh0) >> 8) & 0xff);

            byCmd[14 + 2] = Convert.ToByte(getRangeConfigFromUI(cbCh1) & 0xff);
            byCmd[14 + 3] = Convert.ToByte((getRangeConfigFromUI(cbCh1) >> 8) & 0xff);

            byCmd[14 + 4] = Convert.ToByte(getRangeConfigFromUI(cbCh2) & 0xff);
            byCmd[14 + 5] = Convert.ToByte((getRangeConfigFromUI(cbCh2) >> 8) & 0xff);

            byCmd[14 + 6] = Convert.ToByte(getRangeConfigFromUI(cbCh3) & 0xff);
            byCmd[14 + 7] = Convert.ToByte((getRangeConfigFromUI(cbCh3) >> 8) & 0xff);

            byCmd[14 + 8] = Convert.ToByte(getRangeConfigFromUI(cbCh4) & 0xff);
            byCmd[14 + 9] = Convert.ToByte((getRangeConfigFromUI(cbCh4) >> 8) & 0xff);

            byCmd[14 + 10] = Convert.ToByte(getRangeConfigFromUI(cbCh5) & 0xff);
            byCmd[14 + 11] = Convert.ToByte((getRangeConfigFromUI(cbCh5) >> 8) & 0xff);

            // Function Config Enable
            byCmd[14 + 12] = 0x00;

            // Set burn out enable
            if (cbBurnOutEnable.SelectedIndex == 0)
            {
                byCmd[14 + 12] |= 0x01;
            }
            else
            {
                byCmd[14 + 12] &= 0xFE;
            }

            // Set burn out high/low
            if (cbBurnOutPresent.SelectedIndex == 0)
            {
                byCmd[14 + 12] &= 0xFD;  // Low
            }
            else
            {
                byCmd[14 + 12] |= 0x02;  // high
            }

            // Set Update Rate Filter Option
            if (cbUpdateRate.SelectedIndex == 0) // Auto
            {
                byCmd[14 + 12] &= 0xCF;
            }
            else if (cbUpdateRate.SelectedIndex == 1) // 50 Hz
            {
                byCmd[14 + 12] &= 0xCF;
                byCmd[14 + 12] |= 0x10;
            }
            else if (cbUpdateRate.SelectedIndex == 2) // 60 Hz
            {
                byCmd[14 + 12] &= 0xCF;
                byCmd[14 + 12] |= 0x20;
            }

            // Channel Mask
            byCmd[14 + 13] = 0x00;

            if (ckCH0.Checked)
            {
                byCmd[14 + 13] |= 1;
            }
            if (ckCH1.Checked)
            {
                byCmd[14 + 13] |= 2;
            }
            if (ckCH2.Checked)
            {
                byCmd[14 + 13] |= 4;
            }
            if (ckCH3.Checked)
            {
                byCmd[14 + 13] |= 8;
            }
            if (ckCH4.Checked)
            {
                byCmd[14 + 13] |= 16;
            }
            if (ckCH5.Checked)
            {
                byCmd[14 + 13] |= 32;
            }

            // reserved
            byCmd[14 + 14] = 0x77;
            byCmd[14 + 15] = 0x77;
            byCmd[14 + 16] = 0x77;
            byCmd[14 + 17] = 0x77;

            // Tag Name           
            byCmd[14 + 18] = 0x41;
            byCmd[14 + 19] = 0x55;
            byCmd[14 + 20] = 0x41;
            byCmd[14 + 21] = 0x55;
            byCmd[14 + 22] = 0x41;
            byCmd[14 + 23] = 0x77;
            byCmd[14 + 24] = 0x77;
            byCmd[14 + 25] = 0x77;
            byCmd[14 + 26] = 0x77;
            byCmd[14 + 27] = 0x77;


            m_adamCom.SetComPortTimeout(500, 5000, 0, 1000, 0); // set comport timeout

            m_adamCom.SetPurge(0x000C);

            if (m_adamCom.Send(iLength, byCmd) == (4 + 10 + 28))
            {

                if ((iRecvLen = m_adamCom.Recv(byRecv.Length, ref byRecv)) >= 10 + 4 + 2) // 4 Bytes header + 10 Bytes code + 2 Bytes data
                {
                    if (byRecv[14] == 0x00 && byRecv[15] == 0x00)
                    {
                        MessageBox.Show("Set Range Done!");
                    }
                    else
                        MessageBox.Show("Function Fail");
                }
                else
                    MessageBox.Show("Fail: Receive Fail ");
            }
            else
                MessageBox.Show("Fail: Send Fail");
        }

        private void bDeviceListRefresh_Click(object sender, EventArgs e)
        {
            bGetEndDevice_Click(this, null);
            RefreshDeviceListPage();
        }

        private void timerPollingData_Tick(object sender, EventArgs e)
        {
            if (RefreshData())
            {
                m_iQueryCount++;
                lPollingTimes.Text = "Polling Times : " + m_iQueryCount.ToString();
            }
            else
            {
                timerPollingData.Enabled = false;
                lPollingTimes.Text = "Polling Times : ";
                bPolling.Text = "Polling";
            }
        }

        private void bPolling_Click(object sender, EventArgs e)
        {
            if (bPolling.Text == "Polling")
            {
                timerPollingData.Interval = 1000;
                timerPollingData.Enabled = true;
                bPolling.Text = "Stop";
            }
            else
            {
                m_iQueryCount = 0;
                timerPollingData.Enabled = false;
                bPolling.Text = "Polling";
                lPollingTimes.Text = "Polling Times : ";
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_iQueryCount = 0;
            timerPollingData.Enabled = false;
            bPolling.Text = "Polling";
            lPollingTimes.Text = "Polling Times : ";
        }

    }
}
