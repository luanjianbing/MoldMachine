Imports Advantech.Adam
Imports Advantech.Common
Imports System.Net

Public Class Form1
    Private adamList As ArrayList
    Private m_iTimeout As Int32
    Private m_iIndex As Int32
    Private m_iResetMilliSecond As Int32
    Private currentIPString As String

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim szLocalIP() As String
        Dim iCnt As Int32, iLen As Int32
        Dim portNode As TreeNode
        adamList = New ArrayList()
        m_iTimeout = 1000 'ms
        m_iResetMilliSecond = 8000 'ms

        ' add tree node to host for local IP
        If AdamSocket.GetLocalNetwork(szLocalIP) = True Then
            tcpTree.BeginUpdate()
            iLen = szLocalIP.Length
            For iCnt = 0 To iLen - 1
                portNode = New TreeNode(szLocalIP(iCnt))
                portNode.ImageIndex = 5
                portNode.SelectedImageIndex = 6
                tcpTree.Nodes(0).Nodes.Add(portNode)
            Next iCnt
            ' the node for those IP not in the domain
            portNode = New TreeNode("Others")
            portNode.ImageIndex = 5
            portNode.SelectedImageIndex = 6
            tcpTree.Nodes(0).Nodes.Add(portNode)
            tcpTree.Nodes(0).Expand()
            tcpTree.EndUpdate()
        End If
    End Sub

    Private Sub ClearNodes()
        Dim iLan As Int32, iIdx As Int32
        Dim tcpNode As TreeNode, lanNode As TreeNode

        tcpNode = tcpTree.Nodes(0) ' TCP root
        iLan = tcpNode.Nodes.Count
        tcpTree.BeginUpdate()
        For iIdx = 0 To iLan - 1
            lanNode = tcpNode.Nodes(iIdx)
            lanNode.Nodes.Clear()
        Next iIdx
        tcpNode.Expand()
        tcpTree.EndUpdate()
        tcpTree.Refresh()
    End Sub

    Private Sub InsertNode(ByVal i_iIndex As Int32, ByVal adamObject As AdamInformation)
        Dim ipStr As String
        Dim byTemp() As Byte, byAdamIP() As Byte, bySubnet() As Byte, byLocalIP() As Byte
        Dim iLan As Int32, iIdx As Int32
        Dim ipAddr As IPAddress
        Dim tcpNode As TreeNode, lanNode As TreeNode, moduleNode As TreeNode


        byAdamIP = adamObject.IP
        bySubnet = adamObject.Subnet
        ipStr = String.Format("{0}.{1}.{2}.{3}", byAdamIP(0), byAdamIP(1), byAdamIP(2), byAdamIP(3))
        tcpNode = tcpTree.Nodes(0) ' TCP root
        iLan = tcpNode.Nodes.Count
        For iIdx = 0 To iLan - 1 - 1
            ipAddr = IPAddress.Parse(tcpNode.Nodes(iIdx).Text)
            byLocalIP = ipAddr.GetAddressBytes()
            ' check is in the same subnet
            If (((byAdamIP(0) And bySubnet(0)) = (byLocalIP(0) And bySubnet(0))) AndAlso ((byAdamIP(1) And bySubnet(1)) = (byLocalIP(1) And bySubnet(1))) AndAlso ((byAdamIP(2) And bySubnet(2)) = (byLocalIP(2) And bySubnet(2))) AndAlso ((byAdamIP(3) And bySubnet(3)) = (byLocalIP(3) And bySubnet(3)))) Then
                Exit For
            End If

        Next iIdx
        lanNode = tcpNode.Nodes(iIdx)
        tcpTree.BeginUpdate()
        moduleNode = New TreeNode(ipStr + "-[" + adamObject.DeviceName + "]")
        byTemp = adamObject.DeviceID
        If ((byTemp(0) = &H36) OrElse (byTemp(0) = &H50)) Then                 ' 5000 TCP
            moduleNode.ImageIndex = 1
            moduleNode.SelectedImageIndex = 2
        Else
            moduleNode.ImageIndex = 3
            moduleNode.SelectedImageIndex = 4
        End If
        moduleNode.Tag = i_iIndex                  ' remember the ADAM index in ArrayList
        lanNode.Nodes.Add(moduleNode)
        lanNode.Expand()
        tcpTree.EndUpdate()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim iIndex As Int32
        Dim iCount As Int32 = 0
        Dim adamObject As AdamInformation
        Dim szLocalIPs() As String
        adamList = New ArrayList()

        Cursor.Current = Cursors.WaitCursor
        ClearNodes()

        If (AdamSocket.GetLocalNetwork(szLocalIPs)) Then

            For Each szLocalIP As String In szLocalIPs

                Dim adamCarryList As ArrayList
                AdamSocket.GetAdamDeviceList(m_iTimeout, szLocalIP, adamCarryList)

                If (adamCarryList.Count > 0) Then

                    For iIndex = 0 To adamCarryList.Count - 1

                        adamObject = New AdamInformation()
                        adamObject = CType(adamCarryList(iIndex), AdamInformation)

                        If (adamList.Contains(adamObject) = False) Then

                            'Add Device to list
                            adamList.Add(adamObject)
                            ' add to tree
                            InsertNode(iCount, adamObject)
                            iCount = iCount + 1

                        End If
                    Next iIndex

                End If

            Next

        End If

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub tcpTree_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tcpTree.AfterSelect
        Dim adamObject As AdamInformation

        currentIPString = e.Node.Text.ToString

        If (e.Node.ImageIndex = 1 Or e.Node.ImageIndex = 3) Then  ' module node
            m_iIndex = Convert.ToInt32(e.Node.Tag)
            adamObject = adamList(m_iIndex)
            ' IP
            txtIP.Text = String.Format("{0}.{1}.{2}.{3}", adamObject.IP(0), adamObject.IP(1), adamObject.IP(2), adamObject.IP(3))
            ' MAC
            txtMac.Text = String.Format("{0:X02}-{1:X02}-{2:X02}-{3:X02}-{4:X02}-{5:X02}", adamObject.Mac(0), adamObject.Mac(1), adamObject.Mac(2), adamObject.Mac(3), adamObject.Mac(4), adamObject.Mac(5))
            ' subnet
            txtSubnet.Text = String.Format("{0}.{1}.{2}.{3}", adamObject.Subnet(0), adamObject.Subnet(1), adamObject.Subnet(2), adamObject.Subnet(3))
            ' gateway
            txtGateway.Text = String.Format("{0}.{1}.{2}.{3}", adamObject.Gateway(0), adamObject.Gateway(1), adamObject.Gateway(2), adamObject.Gateway(3))
            ' device name
            txtName.Text = adamObject.DeviceName
            ' device description
            txtDescription.Text = adamObject.Description
            ' host idel
            txtHostIdle.Text = String.Format("{0}", adamObject.HostIdleTime)

            btnNetSetting.Enabled = True
            btnDeviceInfoSetting.Enabled = True
            btnSystemRestart.Enabled = True

            If (e.Node.Parent.Text = "Others") Then
                gbxNet.Visible = True
                gbxDeviceInfo.Visible = False
                gbxOther.Visible = False
            Else
                gbxNet.Visible = True
                gbxDeviceInfo.Visible = True
                gbxOther.Visible = True
            End If

        Else
            txtIP.Text = ""
            txtMac.Text = ""
            txtSubnet.Text = ""
            txtGateway.Text = ""
            txtHostIdle.Text = ""
            txtName.Text = ""
            txtDescription.Text = ""
            btnNetSetting.Enabled = False
            btnDeviceInfoSetting.Enabled = False
            btnSystemRestart.Enabled = False
            gbxNet.Visible = False
            gbxDeviceInfo.Visible = False
            gbxOther.Visible = False
        End If
    End Sub

    Private Sub btnNetSetting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNetSetting.Click
        ApplyNetwork(txtIP.Text, txtSubnet.Text, txtGateway.Text, txtHostIdle.Text)
    End Sub

    Private Function ApplyNetwork(ByVal strIP As String, ByVal strSubnet As String, ByVal strGateway As String, ByVal strHostIdle As String) As Boolean
        Dim frmWait As FormWait
        Dim adamOld As AdamInformation = CType(adamList(m_iIndex), AdamInformation)
        Dim adamNew As AdamInformation
        adamNew = New AdamInformation()

        Dim szMACs As String() = txtMac.Text.Split(New [Char]() {"-"c})
        Dim szIP As String
        Dim bRet As Boolean
        bRet = True

        adamOld.CopyTo(adamNew)
        szIP = strIP

        If (IsValidIP(strIP, adamNew) <> True) Then
            MessageBox.Show("The IP address is invalid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            bRet = False
        End If

        If (IsValidSubnet(strSubnet, adamNew) <> True) Then
            MessageBox.Show("The subnet address is invalid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            bRet = False
        End If

        If (((adamOld.DeviceID(0) = 80) AndAlso (adamOld.DeviceID(1) = 0)) OrElse ((adamOld.DeviceID(0) = 96) AndAlso (adamOld.DeviceID(1) = 34)) OrElse ((adamOld.DeviceID(0) = 96) AndAlso (adamOld.DeviceID(1) = 36))) Then
            If (bRet AndAlso (IsValidIPClass(strIP, strSubnet) <> True)) Then
                bRet = False
            End If
        End If

        If (IsValidGateway(strGateway, adamNew) <> True) Then
            MessageBox.Show("The default gateway is invalid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            bRet = False
        End If

        If (IsValidIdle(strHostIdle, adamNew) <> True) Then

            If (adamNew.HardwareType(1) = 2) Then
                If (adamNew.HardwareType(0) = 0) Then ' ADAM-6000W
                    MessageBox.Show("The host idle time must be between 10~255!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                Else 'WISE
                    MessageBox.Show("The host idle time must be between 0~4095!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
                End If
            Else
                MessageBox.Show("The host idle time must be between 5~4095!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End If

            bRet = False

        End If

        If (bRet) Then

            Cursor.Current = Cursors.WaitCursor

            If (SetAdamInformationEx(AdamInfoType.AdamNetConfig, m_iTimeout, adamNew)) Then
                ' reset module
                SetAdamInformationEx(AdamInfoType.AdamReset, m_iTimeout, adamNew)
                frmWait = New FormWait("Waiting", "Reset module", m_iResetMilliSecond)
                frmWait.ShowDialog()
                frmWait.Dispose()
                frmWait = Nothing

                ' refresh tree if IP is modified
                MessageBox.Show("Change network done!", "Information")

                If ((adamNew.IP(0) <> adamOld.IP(0)) OrElse (adamNew.IP(1) <> adamOld.IP(1)) OrElse (adamNew.IP(2) <> adamOld.IP(2)) OrElse (adamNew.IP(3) <> adamOld.IP(3))) Then

                    adamNew.CopyTo(adamOld)
                    ' refresh tree
                    tcpTree.BeginUpdate()
                    tcpTree.SelectedNode.Text = String.Format("{0}.{1}.{2}.{3}-[{4}]", adamNew.IP(0), adamNew.IP(1), adamNew.IP(2), adamNew.IP(3), adamNew.DeviceName)
                    tcpTree.EndUpdate()

                Else
                    adamNew.CopyTo(adamOld)
                End If

            Else
                MessageBox.Show("Change network failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End If

            Cursor.Current = Cursors.Default
        End If

        adamNew = Nothing

        Return bRet

    End Function

    Public Shared Function SetAdamInformationEx(ByVal i_infoType As AdamInfoType, ByVal i_iTimeout As Int32, ByVal i_adamObject As AdamInformation) As Boolean
        Dim szLocalIPs As String()
        Dim bRet As Boolean = False

        If (AdamSocket.GetLocalNetwork(szLocalIPs)) Then

            For Each szLocalIP As String In szLocalIPs

                If (AdamSocket.SetAdamInformation(i_infoType, i_iTimeout, i_adamObject, szLocalIP)) Then
                    bRet = True
                    Exit For
                End If

            Next

        End If

        Return bRet

    End Function

    Private Function IsValidIP(ByVal i_szIP As String, ByRef adamObject As AdamInformation) As Boolean
        Dim iCnt, iNum As Int32
        Dim szIPs As String()

        szIPs = i_szIP.Split(New [Char]() {"."c})

        If (szIPs.Length = 4) Then

            For iCnt = 0 To 3

                If (szIPs(iCnt).Length > 0 AndAlso szIPs(iCnt).Length <= 3) Then

                    iNum = Convert.ToInt32(szIPs(iCnt))

                    If (iNum >= 0 AndAlso iNum <= 255) Then
                        adamObject.IP(iCnt) = Convert.ToByte(iNum)
                    Else
                        Return False
                    End If

                Else

                    Return False

                End If

            Next

            If ((adamObject.IP(0)) = 0 AndAlso (adamObject.IP(1) = 0) AndAlso (adamObject.IP(2) = 0) AndAlso (adamObject.IP(3) = 0)) Then
                Return False
            End If

        Else
            Return False
        End If

        Return True

    End Function

    Private Function IsValidSubnet(ByVal i_szSubnet As String, ByRef adamObject As AdamInformation) As Boolean
        Dim iCnt, iCnt2, iNum As Int32
        Dim szIPs As String()
        Dim bIsNotContinueMask As Boolean = False

        szIPs = i_szSubnet.Split(New [Char]() {"."c})

        If (szIPs.Length = 4) Then

            For iCnt = 0 To 3

                If (szIPs(iCnt).Length > 0 AndAlso szIPs(iCnt).Length <= 3) Then

                    iNum = Convert.ToInt32(szIPs(iCnt))

                    If (iNum >= 0 AndAlso iNum <= 255) Then

                        If (iCnt = 3 AndAlso iNum = 255) Then
                            Return False
                        End If

                        adamObject.Subnet(iCnt) = Convert.ToByte(iNum)

                        'Check mask continue
                        For iCnt2 = 0 To 7

                            If (((iNum >> (7 - iCnt2)) And 1) > 0) Then

                                If (bIsNotContinueMask) Then
                                    Return False
                                End If

                            Else
                                bIsNotContinueMask = True
                            End If

                        Next

                    Else

                        Return False

                    End If

                Else

                    Return False

                End If

            Next

        Else
            Return False
        End If

        Return True

    End Function

    Private Function IsValidGateway(ByVal i_szGateway As String, ByRef adamObject As AdamInformation) As Boolean
        Dim iCnt, iNum As Int32
        Dim szIPs As String()

        szIPs = i_szGateway.Split(New [Char]() {"."c})

        If (szIPs.Length = 4) Then

            For iCnt = 0 To 3

                If (szIPs(iCnt).Length > 0 AndAlso szIPs(iCnt).Length <= 3) Then

                    iNum = Convert.ToInt32(szIPs(iCnt))

                    If (iNum >= 0 AndAlso iNum <= 255) Then
                        adamObject.Gateway(iCnt) = Convert.ToByte(iNum)
                    Else
                        Return False
                    End If

                Else

                    Return False

                End If

            Next

        Else
            Return False
        End If

        Return True

    End Function

    Private Function IsValidIdle(ByVal i_szIdleTime As String, ByRef adamObject As AdamInformation) As Boolean
        Dim i_iIdleTime As Int32

        If (i_szIdleTime.Length > 0) Then

            i_iIdleTime = Convert.ToInt32(i_szIdleTime)

            If ((adamObject.HardwareType(1) = 1) AndAlso (i_iIdleTime >= 2) AndAlso (i_iIdleTime <= 4095)) Then ' ODM ADAM-6066
                adamObject.HostIdleTime = i_iIdleTime
                Return True
            ElseIf ((adamObject.HardwareType(1) = 2) AndAlso (adamObject.HardwareType(0) = 0) AndAlso (i_iIdleTime >= 10) AndAlso (i_iIdleTime <= 255)) Then ' ADAM-6000W
                adamObject.HostIdleTime = i_iIdleTime
                Return True
            ElseIf ((adamObject.HardwareType(1) = 2) AndAlso (adamObject.HardwareType(0) = 65) AndAlso (i_iIdleTime >= 0) AndAlso (i_iIdleTime <= 4095)) Then ' WISE
                adamObject.HostIdleTime = i_iIdleTime
                Return True
            ElseIf ((adamObject.HardwareType(1) = 100) AndAlso (i_iIdleTime >= 2) AndAlso (i_iIdleTime <= 4095)) Then ' ADAM-6000
                adamObject.HostIdleTime = i_iIdleTime
                Return True
            ElseIf ((adamObject.HardwareType(1) = 66) AndAlso (i_iIdleTime >= 2) AndAlso (i_iIdleTime <= 4095)) Then ' ADAM-6200
                adamObject.HostIdleTime = i_iIdleTime
                Return True
            ElseIf ((i_iIdleTime >= 5) AndAlso (i_iIdleTime <= 4095)) Then 'Others
                adamObject.HostIdleTime = i_iIdleTime
                Return True
            End If

        End If

        Return False

    End Function

    Private Shared Function IsValidIPClass(ByVal i_szIP As String, ByVal i_szSubnet As String) As Boolean
        Dim byIp(4) As Byte
        Dim bySubMask(4) As Byte
        Dim iCnt, iNum As Int32
        Dim szIPs As String()
        Dim szSubnets As String()
        Dim uiIp, uiSubMask As UInt32

        szIPs = i_szIP.Split(New [Char]() {"."c})
        szSubnets = i_szSubnet.Split(New [Char]() {"."c})

        If ((szIPs.Length = 4) AndAlso (szSubnets.Length = 4)) Then

            For iCnt = 0 To 3

                If (((szIPs(iCnt).Length > 0) AndAlso (szIPs(iCnt).Length <= 3)) AndAlso ((szSubnets(iCnt).Length > 0) AndAlso (szSubnets(iCnt).Length <= 3))) Then ' check input from 0 ~ 999

                    iNum = Convert.ToInt32(szIPs(iCnt))

                    If ((iNum >= 0) AndAlso (iNum <= 255)) Then
                        byIp(iCnt) = CType(iNum, Byte)
                    Else
                        MessageBox.Show("The IP address is invalid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
                        Return False
                    End If

                    iNum = Convert.ToInt32(szSubnets(iCnt))

                    If ((iNum >= 0) AndAlso (iNum <= 255)) Then
                        bySubMask(iCnt) = CType(iNum, Byte)
                    Else
                        MessageBox.Show("The Subnet mask address is invalid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
                        Return False
                    End If

                Else
                    MessageBox.Show("The address is invalid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
                    Return False
                End If

            Next

        Else
            MessageBox.Show("The address is invalid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            Return False
        End If

        'Check IP and submask
        uiIp = CType(byIp(0), UInt32)
        uiIp = uiIp Or (CType(byIp(1), UInt32) << 8)
        uiIp = uiIp Or (CType(byIp(2), UInt32) << 16)
        uiIp = uiIp Or (CType(byIp(3), UInt32) << 24)

        uiSubMask = CType(bySubMask(0), UInt32)
        uiSubMask = uiSubMask Or (CType(bySubMask(1), UInt32) << 8)
        uiSubMask = uiSubMask Or (CType(bySubMask(2), UInt32) << 16)
        uiSubMask = uiSubMask Or (CType(bySubMask(3), UInt32) << 24)

        If ((byIp(0) >= 1) AndAlso (byIp(0) <= 126)) Then               'Class A

            If (byIp(0) = 10) Then

                'class A, private IPv4 address space 
                'IP:10.0.0.0 ~ 10.255.255.255 
                'Mask:255.0.0.0
                If (szSubnets(0) <> "255") Then
                    MessageBox.Show("Private IP address Error: Class A\nIP:10.0.0.0 ~ 10.255.255.255 \nSubnet mask:255.X.X.X", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
                    Return False
                End If

            Else

                'IP:1.0.0.0 ~ 126.255.255.255, 127.x.x.x for loopback 
                'Mask:255.0.0.0
                If (szSubnets(0) <> "255") Then
                    MessageBox.Show("IP Address Classification Error: Class A\nIP:1.0.0.0 ~ 126.255.255.255 \nSubnet mask:255.X.X.X", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
                    Return False
                End If

            End If

        ElseIf (byIp(0) = 127) Then 'Class A, 127.x.x.x reserved for loopback  

            MessageBox.Show("IP Address Classification Error: Class A\nIP:127.X.X.X reserved for loopback.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            Return False

        ElseIf ((byIp(0) >= 128) AndAlso (byIp(0) <= 191)) Then        'Class B

            If ((byIp(0) = 172) AndAlso ((byIp(1) >= 16) AndAlso (byIp(1) <= 31))) Then

                'class B, private IPv4 address space 
                'IP:172.16.0.0 ~ 172.31.255.255 
                'Mask:255.240.0.0
                'if (szSubnets[0] != "255" || szSubnets[1] != "240")
                If ((szSubnets(0) <> "255") OrElse ((Convert.ToInt32(szSubnets(1)) And 240) <> 240)) Then
                    MessageBox.Show("Private IP address Error: Class B\nIP:172.16.0.0 ~ 172.31.255.255 \nSubnet mask:255.240.X.X", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
                    Return False
                End If

            Else

                'IP:128.0.0.0 ~ 191.255.255.255 
                'Mask:255.255.0.0
                If ((szSubnets(0) <> "255") OrElse (szSubnets(1) <> "255")) Then
                    MessageBox.Show("IP Address Classification Error: Class B\nIP:128.0.0.0 ~ 191.255.255.255 \nSubnet mask:255.255.X.X", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
                    Return False
                End If


            End If

        ElseIf ((byIp(0) >= 192) AndAlso (byIp(0) <= 223)) Then       'Class C

            If ((byIp(0) = 192) AndAlso (byIp(1) = 168)) Then

                'class C, private IPv4 address space 
                'IP:192.168.0.0 ~ 192.168.255.255 
                'Mask:255.0.0.0
                If ((szSubnets(0) <> "255") OrElse (szSubnets(1) <> "255")) Then
                    MessageBox.Show("Private IP address Error: Class C\nIP:192.168.0.0 ~ 192.168.255.255 \nSubnet mask:255.255.X.X", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
                    Return False
                End If

            Else

                'IP:192.0.0.0 ~ 223.255.255.255 
                'Mask:255.255.255.0
                If ((szSubnets(0) <> "255") OrElse (szSubnets(1) <> "255") OrElse (szSubnets(2) <> "255")) Then
                    MessageBox.Show("IP Address Classification Error: Class C\nIP:192.0.0.0 ~ 223.255.255.255 \nSubnet mask:255.255.255.X", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
                    Return False
                End If

            End If

        Else

            MessageBox.Show("IP Address Classification Error: Please follow the class A~C rules", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            Return False

        End If

        If ((uiIp And (Not uiSubMask)) = 0) Then

            MessageBox.Show("The combination of IP and Subnet mask is incorrect. All Host ID bits are 0.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            Return False

        ElseIf ((uiIp And (Not uiSubMask)) = (Not uiSubMask)) Then

            MessageBox.Show("The combination of IP and Subnet mask is incorrect. All Host ID bits are 1.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            Return False

        ElseIf ((byIp(0) = 255) AndAlso (byIp(1) = 255) AndAlso (byIp(2) = 255) AndAlso (byIp(3) = 255)) Then ' reserved for broadcast 
            MessageBox.Show("IP Address illegal, 255.255.255.255 is reserved for broadcast usage.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            Return False
        End If

        Return True

    End Function

    Private Sub btnDeviceInfoSetting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeviceInfoSetting.Click
        Dim adamOld As AdamInformation
        adamOld = CType(adamList(m_iIndex), AdamInformation)
        Dim adamNew As AdamInformation
        adamNew = New AdamInformation()
        adamOld.CopyTo(adamNew)

        Cursor.Current = Cursors.WaitCursor

        adamNew.DeviceName = txtName.Text
        adamNew.Description = txtDescription.Text

        If (SetAdamInformationEx(AdamInfoType.AdamDeviceInfo, m_iTimeout, adamNew)) Then

            MessageBox.Show("Change device information done!", "Information")
            If (adamNew.DeviceName <> adamOld.DeviceName) Then
                tcpTree.SelectedNode.Text = String.Format("{0}.{1}.{2}.{3}-[{4}]", adamNew.IP(0), adamNew.IP(1), adamNew.IP(2), adamNew.IP(3), adamNew.DeviceName)
            End If
            adamNew.CopyTo(adamOld)

        Else
            MessageBox.Show("Change device information failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End If

        Cursor.Current = Cursors.Default
        adamNew = Nothing
    End Sub

    Private Sub btnSystemRestart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSystemRestart.Click
        Dim frmWait As FormWait
        Dim adamOld As AdamInformation
        adamOld = CType(adamList(m_iIndex), AdamInformation)

        Cursor.Current = Cursors.WaitCursor

        ' reset module
        SetAdamInformationEx(AdamInfoType.AdamReset, m_iTimeout, adamOld)
        frmWait = New FormWait("Waiting", "Reset module", m_iResetMilliSecond)
        frmWait.ShowDialog()
        frmWait.Dispose()
        frmWait = Nothing

        Cursor.Current = Cursors.Default
    End Sub
End Class
