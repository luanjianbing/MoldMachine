Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Threading
Imports System.Net.Sockets
Imports Advantech.Adam
Imports Advantech.Common
Imports Apax_IO_Module_Library
Imports APAX_5060
Imports APAX_5060PE
Imports APAX_5046
Imports APAX_5046SO
Imports APAX_5040
Imports APAX_5040PE
Imports APAX_5045
Imports APAX_5013
Imports APAX_5017
Imports APAX_5017H
Imports APAX_5017PE
Imports APAX_5018
Imports APAX_5028
Imports APAX_5080
Imports APAX_5082
Imports APAX_5090

Public Class Form_APAX_Coupler

    '===================
    ' user configuration
    '   APAX-5070: AdamType.Apax5070
    '   APAX-5071: AdamType.Apax5071
    '   APAX-5072: AdamType.Apax5072
    '===================

    Private adamType As AdamType = adamType.Apax5070

    Private protoType As ProtocolType = ProtocolType.Tcp
    Private portNum As Integer = 502
    Dim m_adamModbusSocket As AdamSocket
    Dim m_dsInfoLocalSys As DataSet
    Dim m_ScanTime_LocalSys() As Integer
    Dim m_iTimeout() As Integer
    Dim m_szIP As String = ""
    Dim m_adamList_Group As ArrayList
    Dim m_adamObject As AdamInformation
    Dim m_szSlotInfo() As String = Nothing
    Dim m_listIndexOfApax5090 As New List(Of Integer)()
    Dim m_iApax5090TcpPorVals()() As Integer
    Dim m_sDSPFWVer As String

    Dim IDX_SWITCHID As Integer = 0
    Dim IDX_MODULENAME As Integer = 1
    Dim IDX_ADDRESSTYPE As Integer = 2
    Dim IDX_STARTADDRESS As Integer = 3
    Dim IDX_LENGTH As Integer = 4

    Private Const ASCII_CMD_UDP_PORT As Integer = 1025
    Private Const STAR_CHAR As Char = "*"c
    Private Const APAX_INFO_NAME As String = "APAX"
    Private Const APAX_5013_STR As String = "5013"
    Private Const APAX_5017_STR As String = "5017"
    Private Const APAX_5017H_STR As String = "5017H"
    Private Const APAX_5017PE_STR As String = "5017PE"
    Private Const APAX_5018_STR As String = "5018"
    Private Const APAX_5028_STR As String = "5028"
    Private Const APAX_5040_STR As String = "5040"
    Private Const APAX_5040PE_STR As String = "5040PE"
    Private Const APAX_5045_STR As String = "5045"
    Private Const APAX_5046_STR As String = "5046"
    Private Const APAX_5046SO_STR As String = "5046SO"
    Private Const APAX_5060_STR As String = "5060"
    Private Const APAX_5060PE_STR As String = "5060PE"
    Private Const APAX_5080_STR As String = "5080"
    Private Const APAX_5082_STR As String = "5082"
    Private Const APAX_5090_STR As String = "5090" 'Only support APAX-5070 (BE Version)

    Private ReadOnly APAX_COUPLER_SUPPORT_MODULE() _
                           As String = { _
                                                APAX_5013_STR, APAX_5017_STR, APAX_5017H_STR, APAX_5017PE_STR, APAX_5018_STR, _
                                                APAX_5028_STR, _
                                                APAX_5040_STR, APAX_5040PE_STR, APAX_5045_STR, _
                                                APAX_5046_STR, APAX_5046SO_STR, APAX_5060_STR, APAX_5060PE_STR, _
                                                APAX_5080_STR, APAX_5082_STR, _
                                                APAX_5090_STR _
                                              }

    Private ReadOnly InvalidModbusSettingApaxModule() As String = {APAX_5090_STR}

    Private Function IsModuleSupportModbusSetting(ByVal szModuleName As String) As Boolean

        Dim bRet As Boolean = True
        Dim intPos As Integer = Array.IndexOf(InvalidModbusSettingApaxModule, szModuleName)
        If (intPos > -1) Then
            bRet = False
        End If
        Return bRet

    End Function

    Public Sub New()
        MyBase.New()

        InitializeComponent()
        'scan timer init
        m_ScanTime_LocalSys = New Integer((1) - 1) {}
        m_ScanTime_LocalSys(0) = 1000
        m_adamModbusSocket = Nothing
        m_iTimeout = New Integer((3) - 1) {}
        m_iTimeout(0) = 2000 'Connection Timeout    
        m_iTimeout(1) = 2000  'Send Timeout
        m_iTimeout(2) = 2000 'Receive Timeout

        If (adamType = adamType.Apax5070) Then
            protoType = ProtocolType.Tcp
            portNum = 502
            panelFSVSetting.Visible = True
        Else
            protoType = ProtocolType.Udp
            portNum = 5048
            panelFSVSetting.Visible = False
            Me.tabControl1.Controls.Remove(Me.tabAddressSetting)
            Me.tabControl1.TabPages.Remove(Me.tabSerial)
        End If

        listViewComPortInfo.Items.Clear()
    End Sub

    ''' Refresh I/O modules of this controller and show controller information
    Private Sub AfterSelect_CouplerDevice(ByVal e As TreeNode)
        Dim DSPFWVer As String = ""
        Dim adamNode As TreeNode

        m_adamModbusSocket = New AdamSocket(AdamType.Apax5070)
        m_adamModbusSocket.SetTimeout(m_iTimeout(0), m_iTimeout(1), m_iTimeout(2))

        If m_adamModbusSocket.Connect(AdamType.Apax5070, m_szIP, ProtocolType.Tcp) Then

            If m_adamModbusSocket.RefreshIOInfo Then

                Dim waitThread As Thread = New Thread(AddressOf ShowWaitMsg)
                waitThread.IsBackground = False
                waitThread.Start()

                m_adamModbusSocket.Configuration.GetSlotInfo(m_szSlotInfo)

                treeView1.BeginUpdate()
                e.Nodes.Clear()

                Dim iCnt As Integer = 0
                Do While (iCnt < m_szSlotInfo.Length)
                    If (Not (m_szSlotInfo(iCnt)) Is Nothing) Then
                        adamNode = New TreeNode((m_szSlotInfo(iCnt) + ("(S" + (iCnt.ToString + ")"))))
                        adamNode.Tag = CType(iCnt, Byte)
                        e.Nodes.Add(adamNode)
                    End If
                    iCnt = (iCnt + 1)
                Loop
                e.ExpandAll()
                treeView1.EndUpdate()
                m_adamModbusSocket.GetDSPFWVer(m_sDSPFWVer)
                m_adamModbusSocket.Disconnect()

            End If

        Else
            MessageBox.Show(("Connection error ( Err : " _
                            + (m_adamModbusSocket.LastError.ToString + " ). Please check the network setting.")), "Error")
            m_adamModbusSocket.Disconnect()
            Return
        End If


        RefreshConfiguration()
        m_adamModbusSocket = Nothing
    End Sub


    ' When select any I/O Modules, replace related APAX I/O module (usercontrol) at rignt panel
    Private Sub AfterSelect_CouplerSlot(ByVal e As TreeNode)
        Dim strSelectModuleId As String = String.Empty
        Dim iSlot As Integer
        Dim iCmpLength As Integer = 4
        iSlot = Convert.ToInt32(e.Tag)
        Dim apaxModule As Form
        strSelectModuleId = m_szSlotInfo(iSlot).ToUpper()

        If MsgBox("Do you want to demo APAX-" + e.Text + "?", MsgBoxStyle.YesNo, "Information") = MsgBoxResult.No Then
            Return
        End If

        If Not IsApaxCouplerSupportModule(strSelectModuleId) Then
            MessageBox.Show("Not support APAX" + e.Text + " module", "Error")
            Return
        End If

        If (strSelectModuleId = APAX_5013_STR) Then
            apaxModule = New Form_APAX_5013(m_szIP, CType(iSlot, Byte), m_ScanTime_LocalSys(0))
        ElseIf (strSelectModuleId = APAX_5017_STR) Then
            apaxModule = New Form_APAX_5017(m_szIP, CType(iSlot, Byte), m_ScanTime_LocalSys(0))
        ElseIf (strSelectModuleId = APAX_5017H_STR) Then
            apaxModule = New Form_APAX_5017H(m_szIP, CType(iSlot, Byte), m_ScanTime_LocalSys(0))
        ElseIf (strSelectModuleId = APAX_5017PE_STR) Then
            apaxModule = New Form_APAX_5017PE(m_szIP, CType(iSlot, Byte), m_ScanTime_LocalSys(0))
        ElseIf (strSelectModuleId = APAX_5018_STR) Then
            apaxModule = New Form_APAX_5018(m_szIP, CType(iSlot, Byte), m_ScanTime_LocalSys(0))
        ElseIf (strSelectModuleId = APAX_5028_STR) Then
            apaxModule = New Form_APAX_5028(m_szIP, CType(iSlot, Byte), m_ScanTime_LocalSys(0))
        ElseIf (strSelectModuleId = APAX_5040_STR) Then
            apaxModule = New Form_APAX_5040(m_szIP, CType(iSlot, Byte), m_ScanTime_LocalSys(0))
        ElseIf (strSelectModuleId = APAX_5040PE_STR) Then
            apaxModule = New Form_APAX_5040PE(m_szIP, CType(iSlot, Byte), m_ScanTime_LocalSys(0))
        ElseIf (strSelectModuleId = APAX_5045_STR) Then
            apaxModule = New Form_APAX_5045(m_szIP, CType(iSlot, Byte), m_ScanTime_LocalSys(0))
        ElseIf (strSelectModuleId = APAX_5046_STR) Then
            apaxModule = New FORM_APAX_5046(m_szIP, CType(iSlot, Byte), m_ScanTime_LocalSys(0))
        ElseIf (strSelectModuleId = APAX_5046SO_STR) Then
            apaxModule = New FORM_APAX_5046SO(m_szIP, CType(iSlot, Byte), m_ScanTime_LocalSys(0))
        ElseIf (strSelectModuleId = APAX_5060_STR) Then
            apaxModule = New Form_APAX_5060(m_szIP, CType(iSlot, Byte), m_ScanTime_LocalSys(0))
        ElseIf (strSelectModuleId = APAX_5060PE_STR) Then
            apaxModule = New Form_APAX_5060PE(m_szIP, CType(iSlot, Byte), m_ScanTime_LocalSys(0))
        ElseIf (strSelectModuleId = APAX_5080_STR) Then
            apaxModule = New Form_APAX_5080(m_szIP, CType(iSlot, Byte), m_ScanTime_LocalSys(0))
        ElseIf (strSelectModuleId = APAX_5082_STR) Then
            apaxModule = New Form_APAX_5082(m_szIP, CType(iSlot, Byte), m_ScanTime_LocalSys(0))
        ElseIf (adamType = adamType.Apax5070) AndAlso (strSelectModuleId = APAX_5090_STR) AndAlso (m_adamObject.HardwareType(0) <> 1) AndAlso (m_adamObject.HardwareType(1) <> 1) Then
            apaxModule = New Form_APAX_5090(m_szIP, CType(iSlot, Byte), adamType)
        Else
            MessageBox.Show("Not support APAX" + e.Text + " module", "Error")
            Return
        End If

        apaxModule.ShowDialog() 'assign I/O module information
        apaxModule = Nothing
        GC.Collect()

    End Sub

    Private Sub formIP_ApplyIPAddressClick(ByVal strIP As String)
        m_szIP = strIP
    End Sub

    ' Refresh Current I/O Modules at this APAX controller
    Private Sub RefreshCurrentModuleInfo()
        Dim idx As Integer = 0
        Dim i As Integer = 0
        Try
            Dim listItemModule() As ListViewItem = New ListViewItem((m_szSlotInfo.Length) - 1) {}
            listViewDescription.BeginUpdate()
            listViewDescription.Items.Clear()
            i = 0
            Do While (i < m_szSlotInfo.Length)
                listItemModule(i) = New ListViewItem(i.ToString)
                listItemModule(i).SubItems.Add(m_szSlotInfo(i))
                listViewDescription.Items.Add(listItemModule(i))
                i = (i + 1)
            Loop
            listViewDescription.EndUpdate()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Exception")
        End Try
    End Sub

    Private Function IsApaxCouplerSupportModule(ByVal szModuleName As String) As Boolean
        Dim bRet As Boolean
        Dim intPos As Integer
        bRet = False

        intPos = Array.IndexOf(APAX_COUPLER_SUPPORT_MODULE, szModuleName)

        If (intPos > -1) Then
            bRet = True
        End If

        Return bRet
    End Function

    Private Sub ShowWaitMsg()

        Dim FormWait = New Wait_Form
        FormWait.Start_Wait(3000)
        FormWait.ShowDialog()

    End Sub

    ' Init APAX coupler information
    Public Function RefreshConfiguration() As Boolean

        'Query device information and network informations
        If AdamSocket.GetAdamDeviceList(m_szIP, 2000, m_adamList_Group) Then
            m_adamObject = CType(m_adamList_Group(0), AdamInformation)
        Else
            MessageBox.Show("Get module information failed!", "Error")
            Return False
        End If

        'APAX Coupler Information
        Me.labModuleName.Text = "APAX-PAC"
        'Firmware Version
        Me.txtFwVer.Text = String.Format("{0:X2}.{1:X2}", m_adamObject.FwVer(0), m_adamObject.FwVer(1))
        'Kernel Firmware Version
        If (m_sDSPFWVer <> "") Then
            Me.txtFwVer2.Text = m_sDSPFWVer.Substring(0, 4).Insert(2, ".")
        End If

        If (adamType = adamType.Apax5070) Then

            If (m_adamModbusSocket.Connect(adamType, m_szIP, ProtocolType.Udp)) Then 'FPGA Firmware Version (Should use udp to get FPGA version) 
                Dim o_dwVer As UInteger
                If m_adamModbusSocket.Configuration.GetFpgaVersion(o_dwVer) Then
                    Me.txtFpgaFwVer.Text = o_dwVer.ToString("X4").Insert(2, ".")
                End If
            End If

            If ((Array.IndexOf(m_szSlotInfo, APAX_5090_STR) = -1) OrElse (m_adamObject.HardwareType(0) = 1 AndAlso m_adamObject.HardwareType(1) = 1)) Then

                If (tabControl1.TabPages.Contains(tabSerial)) Then
                    tabControl1.TabPages.RemoveAt(tabControl1.TabPages.Count - 1)
                End If

            Else

                If (Not tabControl1.TabPages.Contains(tabSerial)) Then
                    tabControl1.TabPages.Add(tabSerial)
                End If

                m_listIndexOfApax5090 = New List(Of Integer)()

                Dim idx As Integer = 0
                For idx = 0 To m_szSlotInfo.Length - 1
                    If ((m_szSlotInfo(idx) <> Nothing) AndAlso (m_szSlotInfo(idx).IndexOf(APAX_5090_STR) > -1)) Then
                        m_listIndexOfApax5090.Add(idx)
                    End If
                Next

                m_iApax5090TcpPorVals = New Integer(AdamControl.APAX_MaxSlot - 1)() {}
                RefreshSerialModulesComPortSetting()

            End If

        Else

            'FPGA Firmware Version (Should use udp to get FPGA version)
            If m_adamModbusSocket.Connect(m_szIP, ProtocolType.Udp, portNum) Then
                Dim o_dwVer As UInteger
                If m_adamModbusSocket.Configuration.GetFpgaVersion(o_dwVer) Then
                    Me.txtFpgaFwVer.Text = o_dwVer.ToString("X4").Insert(2, ".")
                End If
            End If

        End If


        m_adamModbusSocket.Disconnect()
        txtDeviceName.Text = m_adamObject.DeviceName
        txtDeviceDesc.Text = m_adamObject.Description

        RefreshCurrentModuleInfo() 'Current modules information
        txtMacAddress.Text = String.Format("{0:X02}-{1:X02}-{2:X02}-{3:X02}-{4:X02}-{5:X02}", m_adamObject.Mac(0), m_adamObject.Mac(1), m_adamObject.Mac(2), m_adamObject.Mac(3), m_adamObject.Mac(4), m_adamObject.Mac(5)) 'Network information
        txtIPAddress.Text = String.Format("{0}.{1}.{2}.{3}", m_adamObject.IP(0), m_adamObject.IP(1), m_adamObject.IP(2), m_adamObject.IP(3))
        txtSubnetAddress.Text = String.Format("{0}.{1}.{2}.{3}", m_adamObject.Subnet(0), m_adamObject.Subnet(1), m_adamObject.Subnet(2), m_adamObject.Subnet(3))
        txtDefaultGateway.Text = String.Format("{0}.{1}.{2}.{3}", m_adamObject.Gateway(0), m_adamObject.Gateway(1), m_adamObject.Gateway(2), m_adamObject.Gateway(3))
        numHostIdle.Text = m_adamObject.HostIdleTime.ToString
        RefreshModbusAddressSetting() 'Refresh Modbus address mapping
        RefreshFSVSettingInfo()  'Refresh FSV settings

        Return True

    End Function

    Private Sub RefreshSerialModulesComPortSetting()
        Dim lvItem As ListViewItem
        Dim listGetTcpInfoSucceed As New List(Of Integer)()
        Dim listGetTcpInfoFailed As New List(Of String)()
        Dim idx As Integer = 0
        Dim outerIdx As Integer = 0
        Dim innerIdx As Integer = 0

        If (m_listIndexOfApax5090.Count <= 0) Then
            Return
        End If

        For idx = 0 To m_listIndexOfApax5090.Count - 1
            If (Not GetSerialComPortTcpPortMapping(m_listIndexOfApax5090(idx), m_iApax5090TcpPorVals(m_listIndexOfApax5090(idx)))) Then
                listGetTcpInfoFailed.Add(idx.ToString())
            Else
                listGetTcpInfoSucceed.Add(m_listIndexOfApax5090(idx))
            End If
        Next

        If (listGetTcpInfoFailed.Count > 0) Then
            Dim failedList = String.Join(", ", listGetTcpInfoFailed.ToArray())
            MessageBox.Show("Get Switch ID [ " + failedList + " ] parameters failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
        End If

        If (listGetTcpInfoSucceed.Count <= 0) Then
            Return
        End If

        listViewComPortInfo.BeginUpdate()
        listViewComPortInfo.Items.Clear()

        For outerIdx = 0 To listGetTcpInfoSucceed.Count - 1

            For innerIdx = 0 To m_iApax5090TcpPorVals(listGetTcpInfoSucceed(outerIdx)).Length - 1

                lvItem = New ListViewItem(listGetTcpInfoSucceed(outerIdx).ToString()) 'Switch Id
                lvItem.SubItems.Add(APAX_INFO_NAME + "-" + APAX_5090_STR) 'Module Name
                lvItem.SubItems.Add("COM " + (innerIdx + 1).ToString())      'COM Port Id
                lvItem.SubItems.Add(m_iApax5090TcpPorVals(listGetTcpInfoSucceed(outerIdx))(innerIdx).ToString()) 'Map Tcp Port
                listViewComPortInfo.Items.Add(lvItem)

            Next

        Next

        listViewComPortInfo.EndUpdate()
    End Sub

    Public Function GetSerialComPortTcpPortMapping(ByVal i_intSlotId As Integer, ByRef o_tcpPortMappingAry() As Integer) As Boolean
        Dim adamSocket As AdamSocket = New AdamSocket(adamType.Apax5070)
        Dim bRet As Boolean = False
        o_tcpPortMappingAry = New Integer((4) - 1) {}

        If (adamSocket.Connect(m_szIP, ProtocolType.Udp, ASCII_CMD_UDP_PORT)) Then
            adamSocket.SetTimeout(m_iTimeout(0), m_iTimeout(1), m_iTimeout(2))
            bRet = adamSocket.Configuration().GetModuleCOMTcpPortMapping(i_intSlotId, o_tcpPortMappingAry)
        Else
            'MessageBox.Show("Failed to connect module!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            bRet = False
        End If

        adamSocket.Disconnect()
        adamSocket = Nothing
        Return bRet

    End Function

    ''' Refresh Modbus Address type and value
    Private Sub RefreshModbusAddressSetting()
        gvAddress.Items.Clear()

        Try
            If m_adamModbusSocket.Connect(m_szIP, ProtocolType.Tcp, 502) Then
                Dim bFixed As Boolean
                Dim szAddressType() As String = New String((m_szSlotInfo.Length) - 1) {}
                Dim szLength() As String = New String((m_szSlotInfo.Length) - 1) {}
                Dim szStartAddress() As String = New String((m_szSlotInfo.Length) - 1) {}
                Dim listItemModule() As ListViewItem = New ListViewItem((m_szSlotInfo.Length) - 1) {}
                Dim i As Integer = 0

                For i = 0 To m_szSlotInfo.Length - 1
                    listItemModule(i) = New ListViewItem(i.ToString)
                    If (Not (m_szSlotInfo(i)) Is Nothing) Then

                        If (IsModuleSupportModbusSetting(m_szSlotInfo(i))) Then
                            listItemModule(i).SubItems.Add("APAX-" + m_szSlotInfo(i))
                        Else
                            listItemModule(i).SubItems.Add("APAX-" + m_szSlotInfo(i) + " : INVALID")
                        End If

                    Else
                        listItemModule(i).SubItems.Add("Empty")
                    End If

                    listItemModule(i).SubItems.Add("")
                    listItemModule(i).SubItems.Add("")
                    listItemModule(i).SubItems.Add("")
                    gvAddress.Items.Add(listItemModule(i))
                Next

                m_adamModbusSocket.Configuration.GetModbusAddressMode(bFixed)

                If bFixed Then
                    addressTypeValue.Text = "Fixed Mode"
                    For i = 0 To m_szSlotInfo.Length - 1

                        If ((Not (m_szSlotInfo(i)) Is Nothing) AndAlso (IsModuleSupportModbusSetting(m_szSlotInfo(i)))) Then

                            Dim apaxConfig As Apax5000Config = Nothing
                            Dim iTemp As Integer
                            m_adamModbusSocket.Configuration.GetModuleConfig(i, apaxConfig)
                            If ((apaxConfig.wDevType = 1) OrElse (apaxConfig.wDevType = 2)) Then
                                szLength(i) = Convert.ToString(64)
                                iTemp = ((64 * i) + 1)
                                szAddressType(i) = "0X"
                            Else
                                szLength(i) = Convert.ToString(32)
                                iTemp = ((32 * i) + 1)
                                szAddressType(i) = "4X"
                            End If
                            szStartAddress(i) = iTemp.ToString

                        Else
                            szAddressType(i) = "0X"
                            szStartAddress(i) = 0.ToString
                            szLength(i) = 0.ToString
                        End If
                    Next

                Else

                    Dim o_iData() As Integer = Nothing
                    addressTypeValue.Text = "Flexible Mode"
                    m_adamModbusSocket.Modbus.ReadAdvantechRegs(60101, 64, o_iData)

                    For i = 0 To m_szSlotInfo.Length - 1

                        If (IsModuleSupportModbusSetting(m_szSlotInfo(i))) Then

                            Dim iStartAddress As Integer = (o_iData((i * 2)) Mod 10000)
                            If ((o_iData((i * 2)) / 40000) = 1) Then
                                szAddressType(i) = "4X"
                            Else
                                szAddressType(i) = "0X"
                            End If
                            szStartAddress(i) = iStartAddress.ToString
                            szLength(i) = o_iData(((i * 2) + 1)).ToString

                        Else

                            szAddressType(i) = "0X"
                            szStartAddress(i) = (0).ToString()
                            szLength(i) = (0).ToString()

                        End If
                    Next

                End If

                UpdateInfoString(IDX_STARTADDRESS, szStartAddress)
                UpdateInfoString(IDX_ADDRESSTYPE, szAddressType)
                UpdateInfoString(IDX_LENGTH, szLength)
            End If
        Catch ex As System.Exception
            MessageBox.Show("Initialize UI Modbus address setting failed.", "Error")
        End Try
        m_adamModbusSocket.Disconnect()
    End Sub

    ' Refresh Modbus Address row value
    Public Sub UpdateInfoString(ByVal idxColumn As Integer, ByVal szString() As String)
        Dim idxRow As Integer = 0
        Do While (idxRow < m_szSlotInfo.Length)
            If (Not (szString(idxRow)) Is Nothing) Then
                gvAddress.Items(idxRow).SubItems(idxColumn).Text = szString(idxRow)
            End If
            idxRow = (idxRow + 1)
        Loop
    End Sub

    Private Sub chbxEnCommFSV_CheckStateChanged(ByVal sender As Object, ByVal e As EventArgs)
        If chbxEnCommFSV.Checked Then
            txtCommFSVtimeout.Enabled = True
        Else
            txtCommFSVtimeout.Enabled = False
        End If
    End Sub

    ' Refresh Fail Safe Value Setting
    Private Sub RefreshFSVSettingInfo()
        Dim o_iData() As Integer = Nothing
        Dim adamSocket As AdamSocket = New AdamSocket(AdamType.Apax5070)
        If adamSocket.Connect(m_szIP, ProtocolType.Tcp, 502) Then
            If adamSocket.Modbus.ReadAdvantechRegs(60004, 2, o_iData) Then
                If (10 = (o_iData(0) >> 12)) Then 'check 'a' of 0xa105
                    If (&H105 > (o_iData(0) And &HFFF)) Then
                        panelFSVSetting.Visible = False 'AXIS fw version under 105 not support set communication IO FSV, so invisible
                    Else   'fw version greater than 0x105 (include 0x105)
                        If adamSocket.Modbus.ReadAdvantechRegs(60301, 2, o_iData) Then
                            If (1 = o_iData(0)) Then
                                chbxEnCommFSV.Checked = True
                                txtCommFSVtimeout.Enabled = True
                                txtCommFSVtimeout.Text = o_iData(1).ToString 'Communication IO FSV Timeout
                            Else
                                chbxEnCommFSV.Checked = False
                            End If
                        End If
                    End If
                End If

            Else
                panelFSVSetting.Visible = False
            End If
        End If
        adamSocket.Disconnect()
        adamSocket = Nothing
    End Sub

    Private Sub btnSetCommFSV_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSetCommFSV.Click
        Dim iData() As Integer = New Integer((1) - 1) {}
        Dim adamSocket As AdamSocket = New AdamSocket(AdamType.Apax5070)
        Dim iAddr As Integer = 60301
        'Communication IO FSV Setting
        If chbxEnCommFSV.Checked Then
            iData(0) = 1
        Else
            iData(0) = 0
        End If
        If adamSocket.Connect(m_szIP, ProtocolType.Tcp, 502) Then
            If adamSocket.Modbus.WriteAdvantechRegs(iAddr, iData) Then
                If chbxEnCommFSV.Checked Then
                    Try
                        iData(0) = Convert.ToInt32(txtCommFSVtimeout.Text)
                        If ((1 > iData(0)) OrElse (65535 < iData(0))) Then
                            MessageBox.Show("Input value not acceptable," + vbLf + "please enter value from 1~65535")
                            Return
                        End If
                        iAddr = 60302
                        'Communication IO FSV Timeout
                        If adamSocket.Modbus.WriteAdvantechRegs(iAddr, iData) Then
                            MessageBox.Show("Set Communication FSV Done.")
                        Else
                            MessageBox.Show("Set Communication FSV failed.")
                        End If
                    Catch ex As System.Exception
                        MessageBox.Show("Input fromat not correct," + vbLf + "please enter value from 1~65535")
                    End Try
                Else
                    txtCommFSVtimeout.Enabled = False
                    iAddr = 60302
                    'Communication IO FSV Timeout
                    If adamSocket.Modbus.WriteAdvantechRegs(iAddr, iData) Then
                        MessageBox.Show("Set Communication FSV Done.")
                    Else
                        MessageBox.Show("Set Communication FSV failed.")
                    End If
                End If
            Else
                MessageBox.Show("Set Communication FSV Setting failed.")
            End If
        End If
        adamSocket.Disconnect()
        adamSocket = Nothing
    End Sub
    ' Pop window to set IP address
    Private Sub menuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuItem2.Click

        Dim formIP As IPForm = New IPForm
        AddHandler formIP.ApplyIPAddressClick, AddressOf Me.formIP_ApplyIPAddressClick
        formIP.ShowDialog()
        formIP.Dispose()
        formIP = Nothing

    End Sub

    Private Sub menuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuItem3.Click
        'Exit
        Application.Exit()
    End Sub
    ' Refresh Coupler IP address and IO modules
    Private Sub menuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuItem1.Click

        If (m_szIP = "") Then
            MessageBox.Show("Please enter IP address!")
            Return
        End If
        treeView1.SelectedNode = treeView1.Nodes(0)
        treeView1.BeginUpdate()
        treeView1.Nodes(0).Nodes.Clear()
        Dim adamNode As TreeNode = New TreeNode(m_szIP)
        treeView1.Nodes(0).Nodes.Add(adamNode)
        treeView1.ExpandAll()
        treeView1.EndUpdate()
        treeView1.SelectedNode = treeView1.Nodes(0).Nodes(0)
    End Sub
    ' Select tree items
    Private Sub treeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles treeView1.AfterSelect

        If ((String.Compare(e.Node.Text, "Ethernet") <> 0) AndAlso (m_szIP <> "")) Then
            If (String.Compare(e.Node.Text, m_szIP) = 0) Then
                AfterSelect_CouplerDevice(e.Node)
            Else
                AfterSelect_CouplerSlot(e.Node)
            End If
        End If

    End Sub

    Private Sub chbxEnCommFSV_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbxEnCommFSV.CheckedChanged
        txtCommFSVtimeout.Enabled = chbxEnCommFSV.Checked
    End Sub

End Class

