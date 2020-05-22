Imports Advantech.Adam
Imports Advantech.Common
Imports System.Data
Imports System.Threading
Imports System.Net.Sockets
Imports Apax_IO_Module_Library

Public Class Form_APAX_5090

    'Global object
    Const APAX_INFO_NAME As String = "APAX"
    Const DVICE_TYPE As String = "5090"
    Const ASCII_CMD_UDP_PORT As Integer = 1025
    Const m_COM1ValueIdx As Integer = 0

    Dim m_adamSocket As AdamSocket 'Control Handle
    Dim adamUDP As AdamSocket
    Dim m_szIP As String = "" 'Connect IP

    Dim m_aConf As Apax5000Config
    Dim m_idxID As Integer
    Dim m_adamType As AdamType = AdamType.Apax5070
    Dim protoType As ProtocolType = ProtocolType.Tcp
    Dim portNum As Integer = 502
    Dim m_ComPortNumTotal As Integer
    Dim m_tmpidx As Integer
    Dim m_iConnectTimeout, m_iSendTimeout, m_iReceiveTimeout As Integer
    Dim m_szSlots() As String 'Container of all solt device type
    Dim m_bStartFlag As Boolean = False
    Dim m_comPortParametersAry() As ComPortParameters

    Public Class ComPortParameters : Inherits Object
        Dim m_SlotNum As Integer
        Dim m_ComPortNum As Integer
        Dim m_BaudRate As Integer
        Dim m_DataBit As Integer
        Dim m_StopBit As Integer
        Dim m_Parity As Integer
        Dim m_FlowControl As Integer
        Dim m_StatusMsg As String
        Dim m_StatusFlag As Boolean

        Public Sub New(ByVal slotNum As Integer, ByVal comPortNum As Integer, ByVal baudRate As Integer, ByVal dataBit As Integer, ByVal stopBit As Integer, ByVal parity As Integer, ByVal flowControl As Integer)
            m_SlotNum = slotNum
            m_ComPortNum = comPortNum
            m_BaudRate = baudRate
            m_DataBit = dataBit
            m_StopBit = stopBit
            m_Parity = parity
            m_FlowControl = flowControl
            m_StatusMsg = String.Empty
            m_StatusFlag = False
        End Sub

        Property SlotNum() As Integer
            Get
                Return m_SlotNum
            End Get
            Set(ByVal value As Integer)
                m_SlotNum = value
            End Set
        End Property

        Property ComPortNum() As Integer
            Get
                Return m_ComPortNum
            End Get
            Set(ByVal value As Integer)
                m_ComPortNum = value
            End Set
        End Property

        Property BaudRate() As Integer
            Get
                Return m_BaudRate
            End Get
            Set(ByVal value As Integer)
                m_BaudRate = value
            End Set
        End Property

        Property DataBit() As Integer
            Get
                Return m_DataBit
            End Get
            Set(ByVal value As Integer)
                m_DataBit = value
            End Set
        End Property

        Property StopBit() As Integer
            Get
                Return m_StopBit
            End Get
            Set(ByVal value As Integer)
                m_StopBit = value
            End Set
        End Property

        Property Parity() As Integer
            Get
                Return m_Parity
            End Get
            Set(ByVal value As Integer)
                m_Parity = value
            End Set
        End Property

        Property FlowControl() As Integer
            Get
                Return m_FlowControl
            End Get
            Set(ByVal value As Integer)
                m_FlowControl = value
            End Set
        End Property

        Property StatusMsg() As String
            Get
                Return m_StatusMsg
            End Get
            Set(ByVal value As String)
                m_StatusMsg = value
            End Set
        End Property

        Property StatusFlag() As Boolean
            Get
                Return m_StatusFlag
            End Get
            Set(ByVal value As Boolean)
                m_StatusFlag = value
            End Set
        End Property

    End Class

    Public Enum emComPortParameters
        Baudrate_ = 0
        Databit_ = 1
        Parity_ = 2
        Stopbit_ = 3
        Flowctl_ = 4
        Tcpport_ = 5
    End Enum

    Public Enum emBaudrate
        Baudrate_600 = 0
        Baudrate_1200 = 1
        Baudrate_2400 = 2
        Baudrate_4800 = 3
        Baudrate_9600 = 4
        Baudrate_14400 = 5
        Baudrate_19200 = 6
        Baudrate_38400 = 7
        Baudrate_57600 = 8
        Baudrate_115200 = 9
        Unknown = 255
    End Enum

    Public Enum emDatabit
        Databit_8 = 0
        Databit_9 = 1
        Unknown = 255
    End Enum

    Public Enum emParity
        Parity_NONE = 0
        Parity_ODD = 1
        Parity_EVEN = 2
        Parity_MARK = 3
        Parity_SPACE = 4
        Unknown = 255
    End Enum

    Public Enum emStopbit
        Stopbit_1 = 0
        Stopbit_0_5 = 1
        Stopbit_2 = 2
        Stopbit_1_5 = 3
        Unknown = 255
    End Enum

    Public Enum emFlowcontrol
        Flowctl_NONE = 0
        Flowctl_RTS = 1
        Flowctl_CTS = 2
        Flowctl_DTR = 3
        Unknown = 255
    End Enum

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        adamUDP = New AdamSocket()
        m_idxID = -1 ' Set in invalid num 
        m_iConnectTimeout = 2000 ' Connection Timeout    
        m_iSendTimeout = 2000 ' Send Timeout
        m_iReceiveTimeout = 2000 ' Receive Timeout
        cbxPort.SelectedIndex = 0
        m_comPortParametersAry = New ComPortParameters((4) - 1) {}
        SetIp()
        Me.StatusBar_IO.Text = "Start to demo " + APAX_INFO_NAME + "-" + DVICE_TYPE + " by clicking 'Start' button."
    End Sub

    Public Sub New(ByVal IP As String, ByVal SlotNum As Integer, ByVal i_adamType As AdamType)
        MyBase.New()
        InitializeComponent()
        adamUDP = New AdamSocket()
        m_szSlots = Nothing
        m_idxID = SlotNum ' Set Slot_ID
        m_adamType = i_adamType

        If (m_adamType = AdamType.Apax5070) Then
            protoType = ProtocolType.Tcp
            portNum = 502
        Else
            protoType = ProtocolType.Udp
            portNum = 5048
        End If

        m_iConnectTimeout = 2000 'Connection Timeout    
        m_iSendTimeout = 2000 'Send Timeout
        m_iReceiveTimeout = 2000 'Receive Timeout
        cbxPort.SelectedIndex = 0
        m_szIP = IP
        m_comPortParametersAry = New ComPortParameters((4) - 1) {}
        Me.StatusBar_IO.Text = "Start to demo " + APAX_INFO_NAME + "-" + DVICE_TYPE + " by clicking 'Start' button."
    End Sub

    Public Function FreeResource() As Boolean

        If (m_bStartFlag) Then
            m_bStartFlag = False
            Me.tcRemote.Enabled = False
            Me.tcRemote.Visible = False

            'disable locate module
            m_adamSocket.Configuration.SYS_SetLocateModule(m_idxID, 0)
            m_adamSocket.Disconnect()
            m_adamSocket = Nothing

            adamUDP.Disconnect()
            adamUDP = Nothing

        End If

        Return True

    End Function

    Private Sub formIP_ApplyIPAddressClick(ByVal strIP As String)
        m_szIP = strIP
    End Sub

    Public Function SetIp() As Boolean
        Dim count As Integer = 0

        While (count <= 2) And m_szIP = Nothing
            Dim formIP As IPForm = New IPForm
            AddHandler formIP.ApplyIPAddressClick, AddressOf Me.formIP_ApplyIPAddressClick
            formIP.ShowDialog()
            formIP.Dispose()
            formIP = Nothing
            count = count + 1
        End While

        If m_szIP = Nothing Then
            Return False
        End If
        Return True
    End Function

    Public Function StartRemote()

        If m_szIP = "" Then
            If Not SetIp() Then
                MessageBox.Show("Demo failed! Please set up IP address.", "Error")
                Return False
            End If
        End If

        Try

            If Not OpenDevice() Then
                Throw New System.Exception("Open Local Device Fail.")
            End If
            If Not DeviceFind() Then
                Throw New System.Exception("Find " + DVICE_TYPE + "Device Fail.")
            End If
            If Not RefreshConfiguration() Then
                Throw New System.Exception("Get" + DVICE_TYPE + " Device Configuration Fail.")
            End If

        Catch ex As Exception

            MessageBox.Show(ex.ToString, "Error")
            Return False

        End Try

        Me.StatusBar_IO.Text = "Starting to remote..."
        Me.tcRemote.Enabled = True
        Me.tcRemote.Visible = True
        InitialDataTabPages()
        Me.Text = APAX_INFO_NAME + DVICE_TYPE
        Me.tcRemote.SelectedIndex = 0
        Return True

    End Function

    Public Function OpenDevice() As Boolean

        m_adamSocket = New AdamSocket(AdamType.Apax5070)
        m_adamSocket.SetTimeout(m_iConnectTimeout, m_iSendTimeout, m_iReceiveTimeout)

        If m_adamSocket.Connect(m_szIP, protoType, portNum) Then
            If (Not m_adamSocket.Configuration.GetSlotInfo(m_szSlots)) Then
                Me.StatusBar_IO.Text = "GetSlotInfo() Failed! "
                Return False
            End If
        End If

        Return True

    End Function

    Public Function DeviceFind() As Boolean

        Dim iLoop As Integer = 0
        Dim iDeviceNum As Integer = 0

        If m_idxID = -1 Then

            For iLoop = 0 To m_szSlots.Length - 1
                If m_szSlots(iLoop) = Nothing Then
                    Continue For
                End If
                If (String.Compare(m_szSlots(iLoop), 0, DVICE_TYPE, 0, DVICE_TYPE.Length) = 0 And m_szSlots(iLoop).Length = 4) Then
                    iDeviceNum = iDeviceNum + 1
                    If iDeviceNum = 1 Then 'Record first find device
                        m_idxID = iLoop 'Get DVICE_TYPE Solt
                    End If
                End If
            Next

        Else

            If (String.Compare(m_szSlots(m_idxID), 0, DVICE_TYPE, 0, DVICE_TYPE.Length) = 0 And m_szSlots(m_idxID).Length = 4) Then
                iDeviceNum = iDeviceNum + 1
            End If

        End If

        If iDeviceNum = 1 Then
            DeviceFind = True
        ElseIf iDeviceNum > 1 Then
            MessageBox.Show("Found " + iDeviceNum.ToString + DVICE_TYPE + " devices." + vbCrLf + " It's will demo Solt " + m_idxID.ToString + ".", "Warning")
            DeviceFind = True
        Else
            MessageBox.Show("Can't find any " + DVICE_TYPE + " device!", "Error")
            DeviceFind = False
        End If
    End Function

    Public Function RefreshConfiguration() As Boolean

        If m_adamSocket.Configuration.GetModuleConfig(m_idxID, m_aConf) Then

            Me.txtModule.Text = (APAX_INFO_NAME + ("-" + m_aConf.GetModuleName)) 'Information-> Module
            Me.txtID.Text = m_idxID.ToString  'Information -> Switch ID
            Me.txtSupportKernelFw.Text = m_aConf.wSupportFwVer.ToString("X04").Insert(2, ".") 'Information -> Support kernel Fw
            Me.txtFwVer.Text = m_aConf.wFwVerNo.ToString("X04").Insert(2, ".") 'Firmware version
        Else
            Me.StatusBar_IO.Text = (" GetModuleConfig(Error:" _
                        + (m_adamSocket.Configuration.ApiLastError.ToString + ") Failed! "))
            Return False
        End If

        Return True

    End Function

    Public Sub InitialDataTabPages()

        Dim i As Integer = 0
        Dim idx As Integer = 0
        Dim type As Byte = _HardwareIOType.COM_Port  'APAX-5090 is Serial (COM Port) module
        Dim lvItem As ListViewItem

        For i = 0 To m_aConf.HwIoType.Length - 1
            If (m_aConf.HwIoType(i) = type) Then
                idx = i
            End If
        Next

        m_ComPortNumTotal = m_aConf.HwIoTotal(idx)

        m_tmpidx = idx
        listViewComPortInfo.BeginUpdate()
        listViewComPortInfo.Items.Clear()

        For i = 0 To m_aConf.HwIoTotal(idx) - 1
            lvItem = New ListViewItem(_HardwareIOType.COM_Port.ToString().Replace("_", " ").Replace("Port", "") + " " + (i + 1).ToString())  '(COM1~COM4)
            lvItem.SubItems.Add("*****")       'Baudrate
            lvItem.SubItems.Add("*****")       'Databits
            lvItem.SubItems.Add("*****")       'Parity
            lvItem.SubItems.Add("*****")       'Stopbits
            lvItem.SubItems.Add("*****")       'FlowControl
            lvItem.SubItems.Add("*****")       'TcpPort
            listViewComPortInfo.Items.Add(lvItem)
        Next

        listViewComPortInfo.EndUpdate()

    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        Dim strbtnStatus As String = Me.btnStart.Text

        If String.Compare(strbtnStatus, "Start", True) = 0 Then 'Was Stop, Then Start

            'Was Stop, Then Start
            If Not StartRemote() Then
                m_szIP = ""
                Return
            End If

            m_bStartFlag = True
            Me.btnStart.Text = "Stop"

        Else  'Was Start, Then Stop
            Me.StatusBar_IO.Text = "Start to demo " + APAX_INFO_NAME + "-" + DVICE_TYPE + " by clicking 'Start'button."
            Me.FreeResource()
            Me.btnStart.Text = "Start"

        End If
    End Sub

    Private Sub Btn_Quit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Quit.Click
        Close()
    End Sub

    Private Sub Form_APAX_5090_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        FreeResource()
    End Sub

    Private Sub btnLocate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLocate.Click
        If (Me.btnLocate.Text = "Enable") Then
            If m_adamSocket.Configuration.SYS_SetLocateModule(m_idxID, 255) Then
                Me.btnLocate.Text = "Disable"
            Else
                MessageBox.Show("Locate module failed!", "Error")
            End If
        ElseIf m_adamSocket.Configuration.SYS_SetLocateModule(m_idxID, 0) Then
            btnLocate.Text = "Enable"
        Else
            MessageBox.Show("Locate module failed!", "Error")
        End If
    End Sub

    Private Sub chbxHide_Serial_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbxHide_Serial.CheckStateChanged
        Me.panelConfig_Serial.Visible = Not chbxHide_Serial.Checked
    End Sub

    Private Sub RefreshSerialComPortSetting()
        Dim intPortNum As Integer = 0
        m_comPortParametersAry = New ComPortParameters((m_ComPortNumTotal) - 1) {}
        Dim serialComPortTcpPortMappingAry() As Integer = New Integer((m_ComPortNumTotal) - 1) {}

        For intPortNum = 1 To m_ComPortNumTotal
            GetSerialComPortSetting(m_idxID, intPortNum, m_comPortParametersAry(intPortNum - 1))
        Next

        GetSerialComPortTcpPortMapping(m_idxID, serialComPortTcpPortMappingAry)

        For intPortNum = 0 To m_ComPortNumTotal - 1
            'Baudrate value
            listViewComPortInfo.Items(intPortNum).SubItems(1).Text = (CType(m_comPortParametersAry(intPortNum).BaudRate, emBaudrate).ToString().Replace(emComPortParameters.Baudrate_.ToString(), String.Empty))
            'Databit value
            listViewComPortInfo.Items(intPortNum).SubItems(2).Text = (CType(m_comPortParametersAry(intPortNum).DataBit, emDatabit).ToString().Replace(emComPortParameters.Databit_.ToString(), String.Empty))
            'Parity value
            listViewComPortInfo.Items(intPortNum).SubItems(3).Text = (CType(m_comPortParametersAry(intPortNum).Parity, emParity).ToString().Replace(emComPortParameters.Parity_.ToString(), String.Empty))
            'StopBit value
            listViewComPortInfo.Items(intPortNum).SubItems(4).Text = (CType(m_comPortParametersAry(intPortNum).StopBit, emStopbit).ToString().Replace(emComPortParameters.Stopbit_.ToString(), String.Empty).Replace("_", "."))
            'FlowControl value
            listViewComPortInfo.Items(intPortNum).SubItems(5).Text = (CType(m_comPortParametersAry(intPortNum).FlowControl, emFlowcontrol).ToString().Replace(emComPortParameters.Flowctl_.ToString(), String.Empty))
            'Mapping TCP Port value
            listViewComPortInfo.Items(intPortNum).SubItems(6).Text = serialComPortTcpPortMappingAry(intPortNum).ToString()
        Next

        UpdateSettingPanel(m_comPortParametersAry(cbxPort.SelectedIndex))
    End Sub

    Public Function GetSerialComPortTcpPortMapping(ByVal i_intSlotId As Integer, ByRef o_tcpPortMappingAry() As Integer) As Boolean
        Dim bRet As Boolean = False
        o_tcpPortMappingAry = New Integer((4) - 1) {}

        If (adamUDP.Connect(m_szIP, ProtocolType.Udp, ASCII_CMD_UDP_PORT)) Then
            adamUDP.SetTimeout(m_iConnectTimeout, m_iSendTimeout, m_iReceiveTimeout)
            bRet = adamUDP.Configuration().GetModuleCOMTcpPortMapping(i_intSlotId, o_tcpPortMappingAry)
        Else
            MessageBox.Show("Failed to connect module!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            bRet = False
        End If

        adamUDP.Disconnect()
        Return bRet

    End Function

    Public Function GetSerialComPortSetting(ByVal i_intSlotId As Integer, ByVal i_intComPortNum As Integer, ByRef o_comPortParameters As ComPortParameters) As Boolean
        Dim intUnknownVal As Integer = 255
        Dim bRet As Boolean = False
        o_comPortParameters = New ComPortParameters(i_intSlotId, i_intComPortNum, intUnknownVal, intUnknownVal, intUnknownVal, intUnknownVal, intUnknownVal)

        If (adamUDP.Connect(m_szIP, ProtocolType.Udp, ASCII_CMD_UDP_PORT)) Then

            Dim o_iBaudRate, o_iDataBit, o_iStopBit, o_iParity, o_iFlowControl As Integer
            adamUDP.SetTimeout(m_iConnectTimeout, m_iSendTimeout, m_iReceiveTimeout)

            If (adamUDP.Configuration().GetModuleCOMConfig(i_intSlotId, i_intComPortNum, o_iBaudRate, o_iDataBit, o_iStopBit, o_iParity, o_iFlowControl)) Then

                o_comPortParameters.ComPortNum = i_intComPortNum
                o_comPortParameters.BaudRate = o_iBaudRate
                o_comPortParameters.DataBit = o_iDataBit
                o_comPortParameters.StopBit = o_iStopBit
                o_comPortParameters.Parity = o_iParity
                o_comPortParameters.FlowControl = o_iFlowControl
                o_comPortParameters.StatusFlag = True
                bRet = True

            Else

                o_comPortParameters.StatusMsg = adamUDP.LastError.ToString()
                o_comPortParameters.StatusFlag = False
                bRet = False

            End If

        Else
            'MessageBox.Show("Failed to connect module!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            o_comPortParameters.StatusMsg = "Read ComPort Config : Failed to connect module!"
            bRet = False
        End If

        adamUDP.Disconnect()
        Return bRet

    End Function

    Private Sub UpdateSettingPanel(ByVal i_comPortParameters As ComPortParameters)
        Try
            cbxPort.SelectedIndex = i_comPortParameters.ComPortNum - 1
            cbxBaudRate.SelectedIndex = i_comPortParameters.BaudRate
            cbxDatabit.SelectedIndex = i_comPortParameters.DataBit
            cbxParity.SelectedIndex = i_comPortParameters.Parity
            cbxStopbit.SelectedIndex = i_comPortParameters.StopBit
            cbxFlowCtrl.SelectedIndex = i_comPortParameters.FlowControl
        Catch ex As Exception
        End Try
    End Sub

    Private Sub tcRemote_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcRemote.SelectedIndexChanged

        Dim strSelPageName As String = tcRemote.TabPages(tcRemote.SelectedIndex).Text

        If (strSelPageName = "Serial") Then
            RefreshSerialComPortSetting()
        End If

    End Sub

    Private Sub cbxPort_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxPort.SelectedIndexChanged
        Try

            If (cbxPort.SelectedIndex < m_comPortParametersAry.Length) Then
                UpdateSettingPanel(m_comPortParametersAry(cbxPort.SelectedIndex))
            End If

        Catch ex As Exception
        End Try
    End Sub


    Private Sub btnApplySetting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApplySetting.Click
        Dim bRet As Boolean = False
        Dim arrayOfComPort() As Integer = New Integer((4) - 1) {1, 2, 3, 4}
        Dim failedOfComPort() As String = New String() {}
        Dim listFailedSetting As New List(Of String)()
        Dim intComPortNum As Integer

        If Not CheckControllable() Then
            Return
        End If

        If (chbxPortSettingFollowCOM1.Checked) Then

            intComPortNum = -1
            m_comPortParametersAry(m_COM1ValueIdx).BaudRate = cbxBaudRate.SelectedIndex
            m_comPortParametersAry(m_COM1ValueIdx).DataBit = cbxDatabit.SelectedIndex
            m_comPortParametersAry(m_COM1ValueIdx).Parity = cbxParity.SelectedIndex
            m_comPortParametersAry(m_COM1ValueIdx).StopBit = cbxStopbit.SelectedIndex
            m_comPortParametersAry(m_COM1ValueIdx).FlowControl = cbxFlowCtrl.SelectedIndex

        Else

            intComPortNum = cbxPort.SelectedIndex + 1
            m_comPortParametersAry(cbxPort.SelectedIndex).BaudRate = cbxBaudRate.SelectedIndex
            m_comPortParametersAry(cbxPort.SelectedIndex).DataBit = cbxDatabit.SelectedIndex
            m_comPortParametersAry(cbxPort.SelectedIndex).Parity = cbxParity.SelectedIndex
            m_comPortParametersAry(cbxPort.SelectedIndex).StopBit = cbxStopbit.SelectedIndex
            m_comPortParametersAry(cbxPort.SelectedIndex).FlowControl = cbxFlowCtrl.SelectedIndex

        End If


        If ((intComPortNum > 0) AndAlso (intComPortNum <= m_comPortParametersAry.Length)) Then

            bRet = SetSerialComPortSetting(m_idxID, intComPortNum, m_comPortParametersAry(intComPortNum - 1))
            If (bRet = False) Then
                listFailedSetting.Add(m_comPortParametersAry.ToString())
            End If

        Else

            'All follow COM1 setting
            For Each comPortNumIdx As Integer In arrayOfComPort

                bRet = SetSerialComPortSetting(m_idxID, comPortNumIdx, m_comPortParametersAry(0))
                If (bRet = False) Then
                    listFailedSetting.Add(m_comPortParametersAry.ToString())
                End If

            Next

        End If

        If (listFailedSetting.Count > 0) Then
            Dim failedList = String.Join(", ", listFailedSetting.ToArray())
            MessageBox.Show("Set COM port [ " + failedList + " ] parameters failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
        Else
            MessageBox.Show("Set COM port parameters done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            RefreshSerialComPortSetting()
        End If
    End Sub

    Private Function CheckControllable() As Boolean ' Check module controllable
        Dim active As System.UInt16
        If m_adamSocket.Configuration.SYS_GetGlobalActive(active) Then
            If (active = 1) Then
                Return True
            Else
                MessageBox.Show("There is another controller taking control, so you only can monitor IO data.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
                Return False
            End If
        End If
        MessageBox.Show(("Checking controllable failed, utility only could monitor io data now. (" _
                        + (m_adamSocket.Configuration.ApiLastError.ToString + ")")), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
        Return False
    End Function

    Private Function SetSerialComPortSetting(ByVal i_intSlotId As Integer, ByVal i_intComPortNum As Integer, ByVal i_comPortParameters As ComPortParameters) As Boolean
        Dim bRet As Boolean = False
        Dim i_iBaudRate, i_iDataBit, i_iStopBit, i_iParity, i_iFlowControl As Integer

        i_iBaudRate = i_comPortParameters.BaudRate
        i_iDataBit = i_comPortParameters.DataBit
        i_iStopBit = i_comPortParameters.StopBit
        i_iParity = i_comPortParameters.Parity
        i_iFlowControl = i_comPortParameters.FlowControl

        If (adamUDP.Connect(m_szIP, ProtocolType.Udp, ASCII_CMD_UDP_PORT)) Then

            adamUDP.SetTimeout(m_iConnectTimeout, m_iSendTimeout, m_iReceiveTimeout)
            bRet = adamUDP.Configuration().SetModuleCOMConfig(i_intSlotId, i_intComPortNum, i_iBaudRate, i_iDataBit, i_iStopBit, i_iParity, i_iFlowControl)

        Else

            'MessageBox.Show("Failed to connect module!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            i_comPortParameters.StatusMsg = "Write ComPort Config : Failed to connect module!"
            bRet = False

        End If

        adamUDP.Disconnect()
        Return bRet

    End Function

End Class
