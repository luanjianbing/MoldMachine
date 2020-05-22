using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using Advantech.Adam;
using Advantech.Common;

namespace UDPSearch
{
    public partial class Form1 : Form
    {
        private int m_iTimeout;
        private int m_iIndex;
        private ArrayList adamList;
        private string currentIPString;
        private int m_iResetMilliSecond;

        public Form1()
        {
            InitializeComponent();

            string[] szLocalIP;
            int iCnt, iLen;
            TreeNode portNode;
            adamList = new ArrayList();
            m_iTimeout = 1000; //ms
            m_iResetMilliSecond = 8000; //ms

            // add tree node to host for local IP
            if (AdamSocket.GetLocalNetwork(out szLocalIP))
            {
                tcpTree.BeginUpdate();
                iLen = szLocalIP.Length;
                for (iCnt = 0; iCnt < iLen; iCnt++)
                {
                    portNode = new TreeNode(szLocalIP[iCnt]);
                    portNode.ImageIndex = 5;
                    portNode.SelectedImageIndex = 6;
                    tcpTree.Nodes[0].Nodes.Add(portNode);
                }
                // the node for those IP not in the domain
                portNode = new TreeNode("Others");
                portNode.ImageIndex = 5;
                portNode.SelectedImageIndex = 6;
                tcpTree.Nodes[0].Nodes.Add(portNode);
                tcpTree.Nodes[0].Expand();
                tcpTree.EndUpdate();
            }
        }

        private void ClearNodes()
        {
            int iLan, iIdx;
            TreeNode tcpNode, lanNode;

            tcpNode = tcpTree.Nodes[0]; // TCP root
            iLan = tcpNode.Nodes.Count;
            tcpTree.BeginUpdate();
            for (iIdx = 0; iIdx < iLan; iIdx++)
            {
                lanNode = tcpNode.Nodes[iIdx];
                lanNode.Nodes.Clear();
            }
            tcpNode.Expand();
            tcpTree.EndUpdate();
            tcpTree.Refresh();
        }

        private void InsertNode(int i_iIndex, AdamInformation adamObject)
        {
            string ipStr;
            byte[] byTemp, byAdamIP, bySubnet, byLocalIP;
            int iLan, iIdx;
            TreeNode tcpNode, lanNode, moduleNode;


            byAdamIP = adamObject.IP;
            bySubnet = adamObject.Subnet;
            ipStr = string.Format("{0}.{1}.{2}.{3}", byAdamIP[0], byAdamIP[1], byAdamIP[2], byAdamIP[3]);
            tcpNode = tcpTree.Nodes[0]; // TCP root
            iLan = tcpNode.Nodes.Count;
            for (iIdx = 0; iIdx < iLan - 1; iIdx++)
            {
                byLocalIP = IPAddress.Parse(tcpNode.Nodes[iIdx].Text).GetAddressBytes();
                // check is in the same subnet
                if (((byAdamIP[0] & bySubnet[0]) == (byLocalIP[0] & bySubnet[0])) &&
                    ((byAdamIP[1] & bySubnet[1]) == (byLocalIP[1] & bySubnet[1])) &&
                    ((byAdamIP[2] & bySubnet[2]) == (byLocalIP[2] & bySubnet[2])) &&
                    ((byAdamIP[3] & bySubnet[3]) == (byLocalIP[3] & bySubnet[3])))
                    break;
            }
            lanNode = tcpNode.Nodes[iIdx];
            tcpTree.BeginUpdate();
            moduleNode = new TreeNode(ipStr + "-[" + adamObject.DeviceName + "]");
            byTemp = adamObject.DeviceID;
            if ((byTemp[0] == 0x36) || (byTemp[0] == 0x50)) // 5000 TCP
            {
                moduleNode.ImageIndex = 1;
                moduleNode.SelectedImageIndex = 2;
            }
            else
            {
                moduleNode.ImageIndex = 3;
                moduleNode.SelectedImageIndex = 4;
            }
            moduleNode.Tag = i_iIndex; // remember the ADAM index in ArrayList
            lanNode.Nodes.Add(moduleNode);
            lanNode.Expand();
            tcpTree.EndUpdate();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int iIndex;
            int iCount = 0;
            AdamInformation adamObject;
            string[] szLocalIPs;
            adamList = new ArrayList();

            Cursor.Current = Cursors.WaitCursor;
            ClearNodes();

            if (AdamSocket.GetLocalNetwork(out szLocalIPs))
            {
                foreach (string szLocalIP in szLocalIPs)
                {
                    ArrayList adamCarryList;
                    AdamSocket.GetAdamDeviceList(m_iTimeout, szLocalIP, out adamCarryList);

                    if (adamCarryList.Count > 0)
                    {
                        for (iIndex = 0; iIndex < adamCarryList.Count; iIndex++)
                        {
                            adamObject = new AdamInformation();
                            adamObject = (AdamInformation)adamCarryList[iIndex];

                            if (adamList.Contains(adamObject) == false)
                            {
                                adamList.Add(adamObject); //Add Device to list
                                InsertNode(iCount, adamObject);
                                iCount = iCount + 1;
                            }
                        }
                    }
                }
            }

            Cursor.Current = Cursors.Default;
        }

        private void tcpTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int iIndex;
            AdamInformation adamObject;

            currentIPString = e.Node.Text.ToString();

            if (e.Node.ImageIndex == 1 || e.Node.ImageIndex == 3) // module node
            {
                iIndex = Convert.ToInt32(e.Node.Tag);
                adamObject = (AdamInformation)adamList[iIndex];
                // IP
                txtIP.Text = string.Format("{0}.{1}.{2}.{3}", adamObject.IP[0], adamObject.IP[1], adamObject.IP[2], adamObject.IP[3]);
                // MAC
                txtMac.Text = string.Format("{0:X02}-{1:X02}-{2:X02}-{3:X02}-{4:X02}-{5:X02}", adamObject.Mac[0], adamObject.Mac[1], adamObject.Mac[2], adamObject.Mac[3], adamObject.Mac[4], adamObject.Mac[5]);
                // subnet
                txtSubnet.Text = string.Format("{0}.{1}.{2}.{3}", adamObject.Subnet[0], adamObject.Subnet[1], adamObject.Subnet[2], adamObject.Subnet[3]);
                // gateway
                txtGateway.Text = string.Format("{0}.{1}.{2}.{3}", adamObject.Gateway[0], adamObject.Gateway[1], adamObject.Gateway[2], adamObject.Gateway[3]);
                // device name
                txtName.Text = adamObject.DeviceName;
                // device description
                txtDescription.Text = adamObject.Description;
                // host idel
                txtHostIdle.Text = string.Format("{0}", adamObject.HostIdleTime);

                btnNetSetting.Enabled = true;
                btnDeviceInfoSetting.Enabled = true;
                btnSystemRestart.Enabled = true;

                if (e.Node.Parent.Text == "Others")
                {
                    panelNetworkSetting.Visible = true;
                    panelDeviceInfo.Visible = false;
                    panelOther.Visible = false;
                }
                else
                {
                    panelNetworkSetting.Visible = true;
                    panelDeviceInfo.Visible = true;
                    panelOther.Visible = true;
                }
            }
            else
            {
                txtIP.Text = "";
                txtMac.Text = "";
                txtSubnet.Text = "";
                txtGateway.Text = "";
                txtHostIdle.Text = "";
                txtName.Text = "";
                txtDescription.Text = "";
                btnNetSetting.Enabled = false;
                btnDeviceInfoSetting.Enabled = false;
                btnSystemRestart.Enabled = false;
                panelNetworkSetting.Visible = false;
                panelDeviceInfo.Visible = false;
                panelOther.Visible = false;
            }
        }

        private void btnNetSetting_Click(object sender, EventArgs e)
        {
            ApplyNetwork(txtIP.Text, txtSubnet.Text, txtGateway.Text, txtHostIdle.Text);
        }

        private bool ApplyNetwork(string strIP, string strSubnet, string strGateway, string strHostIdle)
        {
            FormWait frmWait;
            AdamInformation adamOld = (AdamInformation)adamList[m_iIndex];
            AdamInformation adamNew = new AdamInformation();

            string[] szMACs = txtMac.Text.Split(new Char[] { '-' });
            string szIP;
            bool bRet = true;

            adamOld.CopyTo(ref adamNew);
            szIP = strIP;
            if (!IsValidIP(strIP, ref adamNew))
            {
                MessageBox.Show("The IP address is invalid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                bRet = false;
            }
            if (!IsValidSubnet(strSubnet, ref adamNew))
            {
                MessageBox.Show("The subnet address is invalid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                bRet = false;
            }

            if (((adamOld.DeviceID[0] == 0x50) && (adamOld.DeviceID[1] == 0x00)) ||
                ((adamOld.DeviceID[0] == 0x60) && (adamOld.DeviceID[1] == 0x22)) ||
                ((adamOld.DeviceID[0] == 0x60) && (adamOld.DeviceID[1] == 0x24)))
            {
                if (bRet && !IsValidIPClass(strIP, strSubnet))
                {
                    bRet = false;
                }
            }

            if (!IsValidGateway(strGateway, ref adamNew))
            {
                MessageBox.Show("The default gateway is invalid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                bRet = false;
            }

            if (!IsValidIdle(strHostIdle, ref adamNew))
            {
                if (adamNew.HardwareType[1] == 2) // ADAM-6000W
                {
                    if (adamNew.HardwareType[0] == 0) // ADAM-6000W
                        MessageBox.Show("The host idle time must be between 10~255!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    else
                        MessageBox.Show("The host idle time must be between 0~4095!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                }
                else
                    MessageBox.Show("The host idle time must be between 2~4095!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                bRet = false;
            }

            if (bRet)
            {
                Cursor.Current = Cursors.WaitCursor;
                //
                if (SetAdamInformationEx(AdamInfoType.AdamNetConfig, m_iTimeout, adamNew))
                {
                    // reset module
                    SetAdamInformationEx(AdamInfoType.AdamReset, m_iTimeout, adamNew);
                    frmWait = new FormWait("Waiting", "Reset module", m_iResetMilliSecond);
                    frmWait.ShowDialog();
                    frmWait.Dispose();
                    frmWait = null;

                    // refresh tree if IP is modified
                    MessageBox.Show("Change network done!", "Information");
                    if ((adamNew.IP[0] != adamOld.IP[0]) || (adamNew.IP[1] != adamOld.IP[1]) ||
                        (adamNew.IP[2] != adamOld.IP[2]) || (adamNew.IP[3] != adamOld.IP[3]))
                    {
                        adamNew.CopyTo(ref adamOld);
                        // refresh tree
                        tcpTree.BeginUpdate();
                        tcpTree.SelectedNode.Text = string.Format("{0}.{1}.{2}.{3}-[{4}]",
                            adamNew.IP[0], adamNew.IP[1], adamNew.IP[2], adamNew.IP[3], adamNew.DeviceName);
                        tcpTree.EndUpdate();
                    }
                    else
                        adamNew.CopyTo(ref adamOld);
                }
                else
                    MessageBox.Show("Change network failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                Cursor.Current = Cursors.Default;
            }
            adamNew = null;

            return bRet;
        }

        public static bool SetAdamInformationEx(AdamInfoType i_infoType, int i_iTimeout, AdamInformation i_adamObject)
        {
            string[] szLocalIPs;
            bool bRet = false;

            if (AdamSocket.GetLocalNetwork(out szLocalIPs))
            {
                foreach (string szLocalIP in szLocalIPs)
                {
                    if (AdamSocket.SetAdamInformation(i_infoType, i_iTimeout, i_adamObject, szLocalIP))
                    {
                        bRet = true;
                        break;
                    }
                }
            }

            return bRet;
        }

        private bool IsValidIP(string i_szIP, ref AdamInformation adamObject)
        {
            int iCnt, iNum;
            string[] szIPs;

            szIPs = i_szIP.Split(new Char[] { '.' });
            if (szIPs.Length == 4)
            {
                for (iCnt = 0; iCnt < 4; iCnt++)
                {
                    if (szIPs[iCnt].Length > 0 && szIPs[iCnt].Length <= 3)
                    {
                        iNum = Convert.ToInt32(szIPs[iCnt]);
                        if (iNum >= 0 && iNum <= 255)
                            adamObject.IP[iCnt] = Convert.ToByte(iNum);
                        else
                            return false;
                    }
                    else
                        return false;
                }
                if (adamObject.IP[0] == 0 && adamObject.IP[1] == 0 &&
                    adamObject.IP[2] == 0 && adamObject.IP[3] == 0)
                    return false;
            }
            else
                return false;
            return true;
        }

        private bool IsValidSubnet(string i_szSubnet, ref AdamInformation adamObject)
        {
            int iCnt, iNum;
            string[] szIPs;
            bool bIsNotContinueMask = false;

            szIPs = i_szSubnet.Split(new Char[] { '.' });
            if (szIPs.Length == 4)
            {
                for (iCnt = 0; iCnt < 4; iCnt++)
                {
                    if (szIPs[iCnt].Length > 0 && szIPs[iCnt].Length <= 3)
                    {
                        iNum = Convert.ToInt32(szIPs[iCnt]);
                        if (iNum >= 0 && iNum <= 255)
                        {
                            if (iCnt == 3 && iNum == 255)
                                return false;
                            adamObject.Subnet[iCnt] = Convert.ToByte(iNum);

                            //Check mask continue
                            for (int i = 0; i < 8; i++)
                            {
                                if (((iNum >> (7 - i)) & 0x01) > 0)
                                {
                                    if (bIsNotContinueMask)
                                    {
                                        return false;
                                    }
                                }
                                else
                                    bIsNotContinueMask = true;
                            }
                            ////
                        }
                        else
                            return false;
                    }
                    else
                        return false;
                }
            }
            else
                return false;

            return true;
        }

        private bool IsValidGateway(string i_szGateway, ref AdamInformation adamObject)
        {
            int iCnt, iNum;
            string[] szIPs;

            szIPs = i_szGateway.Split(new Char[] { '.' });
            if (szIPs.Length == 4)
            {
                for (iCnt = 0; iCnt < 4; iCnt++)
                {
                    if (szIPs[iCnt].Length > 0 && szIPs[iCnt].Length <= 3)
                    {
                        iNum = Convert.ToInt32(szIPs[iCnt]);
                        if (iNum >= 0 && iNum <= 255)
                            adamObject.Gateway[iCnt] = Convert.ToByte(iNum);
                        else
                            return false;
                    }
                    else
                        return false;
                }
            }
            else
                return false;
            return true;
        }

        private bool IsValidIdle(string i_szIdleTime, ref AdamInformation adamObject)
        {
            int i_iIdleTime;
            if (i_szIdleTime.Length > 0)
            {
                i_iIdleTime = Convert.ToInt32(i_szIdleTime);
                if (adamObject.HardwareType[1] == 1 && i_iIdleTime >= 2 && i_iIdleTime <= 4095) // ODM ADAM-6066
                {
                    adamObject.HostIdleTime = i_iIdleTime;
                    return true;
                }
                else if (adamObject.HardwareType[1] == 2 && adamObject.HardwareType[0] == 0 && i_iIdleTime >= 10 && i_iIdleTime <= 255) // ADAM-6000W
                {
                    adamObject.HostIdleTime = i_iIdleTime;
                    return true;
                }
                else if (adamObject.HardwareType[1] == 2 && adamObject.HardwareType[0] == 0x41 && i_iIdleTime >= 0 && i_iIdleTime <= 4095) // WISE
                {
                    adamObject.HostIdleTime = i_iIdleTime;
                    return true;
                }
                else if (adamObject.HardwareType[1] == 100 && i_iIdleTime >= 2 && i_iIdleTime <= 4095) //[Tim] ADAM-6000
                {
                    adamObject.HostIdleTime = i_iIdleTime;
                    return true;
                }
                else if (adamObject.HardwareType[1] == 0x42 && i_iIdleTime >= 2 && i_iIdleTime <= 4095) // ADAM-6200
                {
                    adamObject.HostIdleTime = i_iIdleTime;
                    return true;
                }
                else if (i_iIdleTime >= 5 && i_iIdleTime <= 4095) //Others
                {
                    adamObject.HostIdleTime = i_iIdleTime;
                    return true;
                }
            }
            return false;
        }

        public static bool IsValidIPClass(string i_szIP, string i_szSubnet)
        {
            byte[] byIp = new byte[4];
            byte[] bySubMask = new byte[4];
            int iCnt, iNum;
            string[] szIPs;
            string[] szSubnets;
            UInt32 uiIp, uiSubMask;


            szIPs = i_szIP.Split(new Char[] { '.' });
            szSubnets = i_szSubnet.Split(new Char[] { '.' });

            if (szIPs.Length == 4 && szSubnets.Length == 4)
            {
                for (iCnt = 0; iCnt < 4; iCnt++)
                {
                    if ((szIPs[iCnt].Length > 0 && szIPs[iCnt].Length <= 3) && (szSubnets[iCnt].Length > 0 && szSubnets[iCnt].Length <= 3)) //check input from 0 ~ 999
                    {
                        iNum = Convert.ToInt32(szIPs[iCnt]);
                        if (iNum >= 0 && iNum <= 255)
                        {
                            byIp[iCnt] = (byte)iNum;
                        }
                        else
                        {
                            MessageBox.Show("The IP address is invalid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                            return false;
                        }

                        iNum = Convert.ToInt32(szSubnets[iCnt]);
                        if (iNum >= 0 && iNum <= 255)
                        {
                            bySubMask[iCnt] = (byte)iNum;
                        }
                        else
                        {
                            MessageBox.Show("The Subnet mask address is invalid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("The address is invalid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                        return false;
                    }
                }
            }
            else
            {
                MessageBox.Show("The address is invalid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                return false;
            }

            //Check IP and submask
            uiIp = (UInt32)byIp[0];
            uiIp |= (UInt32)byIp[1] << 8;
            uiIp |= (UInt32)byIp[2] << 16;
            uiIp |= (UInt32)byIp[3] << 24;

            uiSubMask = (UInt32)bySubMask[0];
            uiSubMask |= (UInt32)bySubMask[1] << 8;
            uiSubMask |= (UInt32)bySubMask[2] << 16;
            uiSubMask |= (UInt32)bySubMask[3] << 24;

            if (byIp[0] >= 1 && byIp[0] <= 126)               //Class A
            {
                if (byIp[0] == 10)
                {
                    //class A, private IPv4 address space 
                    //IP:10.0.0.0 ~ 10.255.255.255 
                    //Mask:255.0.0.0
                    if (szSubnets[0] != "255")
                    {
                        MessageBox.Show("Private IP address Error: Class A\nIP:10.0.0.0 ~ 10.255.255.255 \nSubnet mask:255.X.X.X", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                        return false;
                    }
                }
                else
                {
                    //IP:1.0.0.0 ~ 126.255.255.255, 127.x.x.x for loopback 
                    //Mask:255.0.0.0
                    if (szSubnets[0] != "255")
                    {
                        MessageBox.Show("IP Address Classification Error: Class A\nIP:1.0.0.0 ~ 126.255.255.255 \nSubnet mask:255.X.X.X", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                        return false;
                    }
                }

            }
            else if (byIp[0] == 127) //Class A, 127.x.x.x reserved for loopback  
            {
                MessageBox.Show("IP Address Classification Error: Class A\nIP:127.X.X.X reserved for loopback.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if (byIp[0] >= 128 && byIp[0] <= 191)        //Class B
            {
                if (byIp[0] == 172 && (byIp[1] >= 16 && byIp[1] <= 31))
                {
                    //class B, private IPv4 address space 
                    //IP:172.16.0.0 ~ 172.31.255.255 
                    //Mask:255.240.0.0
                    //if (szSubnets[0] != "255" || szSubnets[1] != "240")
                    if (szSubnets[0] != "255" || ((Convert.ToInt32(szSubnets[1]) & 240) != 240))
                    {
                        MessageBox.Show("Private IP address Error: Class B\nIP:172.16.0.0 ~ 172.31.255.255 \nSubnet mask:255.240.X.X", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                        return false;
                    }
                }
                else
                {
                    //IP:128.0.0.0 ~ 191.255.255.255 
                    //Mask:255.255.0.0
                    if (szSubnets[0] != "255" || szSubnets[1] != "255")
                    {
                        MessageBox.Show("IP Address Classification Error: Class B\nIP:128.0.0.0 ~ 191.255.255.255 \nSubnet mask:255.255.X.X", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                        return false;
                    }
                }

            }
            else if (byIp[0] >= 192 && byIp[0] <= 223)        //Class C
            {
                if (byIp[0] == 192 && byIp[1] == 168)
                {
                    //class C, private IPv4 address space 
                    //IP:192.168.0.0 ~ 192.168.255.255 
                    //Mask:255.0.0.0
                    if (szSubnets[0] != "255" || szSubnets[1] != "255")
                    {
                        MessageBox.Show("Private IP address Error: Class C\nIP:192.168.0.0 ~ 192.168.255.255 \nSubnet mask:255.255.X.X", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                        return false;
                    }
                }
                else
                {
                    //IP:192.0.0.0 ~ 223.255.255.255 
                    //Mask:255.255.255.0
                    if (szSubnets[0] != "255" || szSubnets[1] != "255" || szSubnets[2] != "255")
                    {
                        MessageBox.Show("IP Address Classification Error: Class C\nIP:192.0.0.0 ~ 223.255.255.255 \nSubnet mask:255.255.255.X", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                        return false;
                    }
                }

            }
            else
            {
                MessageBox.Show("IP Address Classification Error: Please follow the class A~C rules", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                return false;
            }

            if ((uiIp & ~uiSubMask) == 0)
            {
                MessageBox.Show("The combination of IP and Subnet mask is incorrect. All Host ID bits are 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if ((uiIp & ~uiSubMask) == ~uiSubMask)
            {
                MessageBox.Show("The combination of IP and Subnet mask is incorrect. All Host ID bits are 1.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                return false;
            }
            else if ((byIp[0] == 255) && (byIp[1] == 255) && (byIp[2] == 255) && (byIp[3] == 255)) //reserved for broadcast 
            {
                MessageBox.Show("IP Address illegal, 255.255.255.255 is reserved for broadcast usage.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                return false;
            }
            return true;
        }

        private void btnDeviceInfoSetting_Click(object sender, EventArgs e)
        {
            AdamInformation adamOld = (AdamInformation)adamList[m_iIndex];
            AdamInformation adamNew = new AdamInformation();
            adamOld.CopyTo(ref adamNew);

            Cursor.Current = Cursors.WaitCursor;

            adamNew.DeviceName = txtName.Text;
            adamNew.Description = txtDescription.Text;
            if (SetAdamInformationEx(AdamInfoType.AdamDeviceInfo, m_iTimeout, adamNew))
            {
                MessageBox.Show("Change device information done!", "Information");
                if (adamNew.DeviceName != adamOld.DeviceName)
                    tcpTree.SelectedNode.Text = string.Format("{0}.{1}.{2}.{3}-[{4}]",
                        adamNew.IP[0], adamNew.IP[1], adamNew.IP[2], adamNew.IP[3], adamNew.DeviceName);
                adamNew.CopyTo(ref adamOld);
            }
            else
                MessageBox.Show("Change device information failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            Cursor.Current = Cursors.Default;
            adamNew = null;
        }

        private void btnSystemRestart_Click(object sender, EventArgs e)
        {
            FormWait frmWait;
            AdamInformation adamOld = (AdamInformation)adamList[m_iIndex];

            Cursor.Current = Cursors.WaitCursor;

            // reset module
            SetAdamInformationEx(AdamInfoType.AdamReset, m_iTimeout, adamOld);
            frmWait = new FormWait("Waiting", "Reset module", m_iResetMilliSecond);
            frmWait.ShowDialog();
            frmWait.Dispose();
            frmWait = null;

            Cursor.Current = Cursors.Default;
        }

    }
}