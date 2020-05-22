Imports Advantech.Adam
Imports Advantech.Common
Imports System.Data
Imports System.Threading
Imports Apax_IO_Module_Library
Imports System.Net.Sockets

Public Class Form_APAX_5045

    'Global
    Dim APAX_INFO_NAME As String = "APAX"
    Public Const DVICE_TYPE = "5045"

    Dim m_adamModbusSocket As AdamSocket 'Control Handle
    Dim m_iTimeout() As Integer 'Time out setting parameter
    Dim m_szIP As String = "" 'Connect IP

    Dim m_aConf As Apax5000Config 'Configuration information
    Dim m_iSlot_ID As Integer 'Device switch ID
    Dim m_ScanTime_LocalSys() As Integer
    Dim m_szSlots() As String 'Container of all solt device type
    Dim bOutVal(), bInVal() As Boolean 'Container of DIO Status
    Dim m_bStartFlag As Boolean = False
    Dim protoType As ProtocolType = ProtocolType.Tcp
    Dim portNum As Integer = 502

    Dim m_iPollingCount As Integer 'Polling device status count
    Dim m_iFailCount As Integer 'Device Polling fail count
    Dim m_iDIChannelNum As Integer 'Device DI Channel number
    Dim m_iDOChannelNum As Integer 'Device DI Channel number
    Dim m_bIsEnableSafetyFcn As Boolean
    Dim m_bDOSafetyVals() As Boolean
    Dim m_usStart As System.UInt16
    Dim m_usLength As System.UInt16
    Shared DI_FILTER_WIDTH_MAX As Integer = 400
    Shared DI_FILTER_WIDTH_MIN As Integer = 30

    Public Sub New()
        MyBase.New()

        InitializeComponent()
        m_szSlots = Nothing
        m_iPollingCount = 0
        m_iFailCount = 0
        m_iSlot_ID = -1 'Set in invalid num 
        m_ScanTime_LocalSys = New Integer((1) - 1) {}
        m_ScanTime_LocalSys(0) = 500 'Scan time default 500 ms
        Timer1.Interval = m_ScanTime_LocalSys(0)

        m_iTimeout = New Integer((3) - 1) {}
        m_iTimeout(0) = 2000  'Connection Timeout    
        m_iTimeout(1) = 2000  'Send Timeout
        m_iTimeout(2) = 2000  'Receive Timeout

        Me.StatusBar_IO.Text = "Start to demo " + APAX_INFO_NAME + "-" + DVICE_TYPE + " by clicking 'Start' button."

    End Sub

    Public Sub New(ByVal IP As String, ByVal SlotNum As Integer, ByVal ScanTime As Integer)
        MyBase.New()

        InitializeComponent()
        m_szSlots = Nothing
        m_iSlot_ID = SlotNum 'Set Slot_ID
        m_iPollingCount = 0
        m_iFailCount = 0
        m_ScanTime_LocalSys = New Integer((1) - 1) {}
        m_ScanTime_LocalSys(0) = ScanTime 'Scan time
        Timer1.Interval = m_ScanTime_LocalSys(0)

        m_iTimeout = New Integer((3) - 1) {}
        m_iTimeout(0) = 2000   'Connection Timeout    
        m_iTimeout(1) = 2000 'Send Timeout
        m_iTimeout(2) = 2000  'Receive Timeout
        m_szIP = IP

        Me.StatusBar_IO.Text = "Start to demo " + APAX_INFO_NAME + "-" + DVICE_TYPE + " by clicking 'Start' button."

    End Sub

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

    Public Function OpenDevice() As Boolean

        m_adamModbusSocket = New AdamSocket(AdamType.Apax5070)
        m_adamModbusSocket.SetTimeout(m_iTimeout(0), m_iTimeout(1), m_iTimeout(2))

        If m_adamModbusSocket.Connect(AdamType.Apax5070, m_szIP, ProtocolType.Tcp) Then
            If (Not m_adamModbusSocket.Configuration.GetSlotInfo(m_szSlots)) Then
                Me.StatusBar_IO.Text = "GetSlotInfo() Failed! "
                Return False
            End If
        End If

        Return True

    End Function

    Public Function DeviceFind() As Boolean

        Dim iLoop As Integer = 0
        Dim iDeviceNum As Integer = 0

        If m_iSlot_ID = -1 Then

            For iLoop = 0 To m_szSlots.Length - 1
                If m_szSlots(iLoop) = Nothing Then
                    Continue For
                End If
                If (String.Compare(m_szSlots(iLoop), 0, DVICE_TYPE, 0, DVICE_TYPE.Length) = 0) Then
                    iDeviceNum = iDeviceNum + 1
                    If iDeviceNum = 1 Then 'Record first find device
                        m_iSlot_ID = iLoop 'Get DVICE_TYPE Solt
                    End If
                End If
            Next

        Else

            If (String.Compare(m_szSlots(m_iSlot_ID), 0, DVICE_TYPE, 0, DVICE_TYPE.Length) = 0) Then
                iDeviceNum = iDeviceNum + 1
            End If

        End If

        If iDeviceNum = 1 Then
            DeviceFind = True
        ElseIf iDeviceNum > 1 Then
            MessageBox.Show("Found " + iDeviceNum.ToString + DVICE_TYPE + " devices." + vbCrLf + " It's will demo Solt " + m_iSlot_ID.ToString + ".", "Warning")
            DeviceFind = True
        Else
            MessageBox.Show("Can't find any " + DVICE_TYPE + " device!", "Error")
            DeviceFind = False
        End If
    End Function

    Private Sub RefreshModbusAddressSetting()
        Dim bFixed As Boolean
        m_adamModbusSocket.Configuration.GetModbusAddressMode(bFixed)
        If bFixed Then
            If ((m_aConf.wDevType = CType(_DeviceType.DigitalInput, System.UInt16)) _
                        OrElse (m_aConf.wDevType = CType(_DeviceType.DigitalOutput, System.UInt16))) Then
                m_usStart = Convert.ToUInt16(((64 * m_iSlot_ID) + 1))
                '64(Coils, bit) is Slot shift, please reference Modbus/TCP address mapping table(0x)
                m_usLength = m_aConf.byChTotal
            ElseIf ((m_aConf.wDevType = CType(_DeviceType.AnalogInput, System.UInt16)) _
                        OrElse (m_aConf.wDevType = CType(_DeviceType.AnalogOutput, System.UInt16))) Then
                m_usStart = Convert.ToUInt16(((32 * m_iSlot_ID) + 40001))
                '32(Registers, 2 bytes) is Slot shift, please reference Modbus/TCP address mapping table(4x)
                m_usLength = m_aConf.byChTotal
            ElseIf ((m_aConf.wDevType = CType(_DeviceType.Counter, System.UInt16)) _
                        OrElse (m_aConf.wDevType = CType(_DeviceType.PWM, System.UInt16))) Then
                m_usStart = Convert.ToUInt16(((32 * m_iSlot_ID) + 40001))
                m_usLength = Convert.ToUInt16(((m_aConf.byHwIoTotal_2 * 2) + 1))
                'per counter channel use 2 Registers(= 4 bytes)
            End If
        Else
            Dim o_iLength As Integer
            Dim o_iStartAddr As Integer
            If m_adamModbusSocket.Configuration.GetModbusAddressConfig(m_iSlot_ID, o_iStartAddr, o_iLength) Then
                m_usStart = Convert.ToUInt16(o_iStartAddr)
                m_usLength = Convert.ToUInt16(o_iLength)
            End If
        End If
    End Sub
    Public Function RefreshConfiguration() As Boolean

        Dim i As Integer = 0

        If m_adamModbusSocket.Configuration.GetModuleConfig(m_iSlot_ID, m_aConf) Then
            Me.txtModuleID.Text = (APAX_INFO_NAME + ("-" + m_aConf.GetModuleName)) 'Information-> Module
            Me.txtSWID.Text = m_iSlot_ID.ToString 'Information -> Switch ID
            Me.txtSupportKernelFw.Text = m_aConf.wSupportFwVer.ToString("X04").Insert(2, ".")  'Information -> Support kernel Fw
            Me.txtFwVer.Text = m_aConf.wFwVerNo.ToString("X04").Insert(2, ".") 'Firmware version
        Else
            Me.StatusBar_IO.Text = (" GetModuleConfig(Error:" _
                        + (m_adamModbusSocket.Configuration.ApiLastError.ToString + ") Failed! "))
            Return False
        End If

        RefreshModbusAddressSetting()
        Return True

    End Function

    Public Sub InitialRemotePanelComponents()

        Dim iLoop As Integer
        Dim lvItem As ListViewItem
        listViewChInfo_DI.Items.Clear()
        listViewChInfo_DI.BeginUpdate()

        For iLoop = 0 To Me.m_iDIChannelNum - 1
            lvItem = New ListViewItem(_HardwareIOType.DI.ToString)  'Type
            lvItem.SubItems.Add(iLoop.ToString)  'Ch
            If (m_usStart > 40000) Then
                Dim szTmp As String = (Convert.ToString((m_usStart + (iLoop / 16))) + ("[" + (Convert.ToString((iLoop Mod 16)) + "]")))
                lvItem.SubItems.Add(szTmp)  'modbus address
            Else
                Dim szTmp As String = String.Format("{0:D5}", (m_usStart + iLoop))
                lvItem.SubItems.Add(szTmp)
            End If
            lvItem.SubItems.Add("*****") 'Value
            lvItem.SubItems.Add("BOOL") 'Mode
            lvItem.SubItems.Add("*****") 'Safety Value
            listViewChInfo_DI.Items.Add(lvItem)
        Next

        listViewChInfo_DI.EndUpdate()
        listViewChInfo_DO.Items.Clear()
        listViewChInfo_DO.BeginUpdate()

        For iLoop = 0 To Me.m_iDOChannelNum - 1
            lvItem = New ListViewItem(_HardwareIOType.DO.ToString) 'Type
            lvItem.SubItems.Add(iLoop.ToString) 'Ch

            If (m_usStart > 40000) Then
                Dim szTmp As String = (Convert.ToString((m_usStart + ((iLoop + m_aConf.HwIoTotal(0)) / 16))) + _
                                      ("[" + (Convert.ToString(((iLoop + m_aConf.HwIoTotal(0)) Mod 16)) + "]")))
                lvItem.SubItems.Add(szTmp)
            Else
                Dim szTmp As String = String.Format("{0:D5}", (m_usStart + (iLoop + m_aConf.HwIoTotal(0))))
                lvItem.SubItems.Add(szTmp)
            End If

            lvItem.SubItems.Add("*****") 'Value
            lvItem.SubItems.Add("BOOL") 'Mode
            lvItem.SubItems.Add("*****") 'Safety Value
            listViewChInfo_DO.Items.Add(lvItem)
        Next

        listViewChInfo_DO.EndUpdate()

    End Sub

    Public Function GetChannelInfo() As Boolean

        Dim iLoop As Integer

        For iLoop = 0 To m_aConf.HwIoType.Length - 1

            If (m_aConf.HwIoType(iLoop) = _HardwareIOType.DI) Then
                m_iDIChannelNum = m_aConf.HwIoTotal(iLoop)
            ElseIf (m_aConf.HwIoType(iLoop) = _HardwareIOType.DO) Then
                m_iDOChannelNum = m_aConf.HwIoTotal(iLoop)

            End If

        Next

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
            If Not GetChannelInfo() Then
                Throw New System.Exception("Get" + DVICE_TYPE + " Device ChannelInfo Fail.")
            End If

        Catch ex As Exception

            MessageBox.Show("Demo failed! Please check define 'DVICE_TYPE' of type or device set up status.", "Error")
            Return False

        End Try

        Me.StatusBar_IO.Text = "Starting to remote..."
        Me.Timer1.Interval = m_ScanTime_LocalSys(0)
        Me.tcRemote.Enabled = True
        Me.tcRemote.Visible = True
        InitialRemotePanelComponents()
        Me.Text = APAX_INFO_NAME + DVICE_TYPE
        m_iPollingCount = 0
        Me.tcRemote.SelectedIndex = 0
        Return True

    End Function

    Public Function FreeResource() As Boolean

        If m_bStartFlag Then

            m_bStartFlag = False
            Me.tcRemote.Enabled = False
            Me.tcRemote.Visible = False
            Timer1.Enabled = False 'disable timer
            m_adamModbusSocket.Configuration.SYS_SetLocateModule(m_iSlot_ID, 0) 'disable locate module
            m_adamModbusSocket = Nothing

        End If

        Return True

    End Function

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        Dim strbtnStatus As String = Me.btnStart.Text

        If String.Compare(strbtnStatus, "Start", True) = 0 Then 'Was Stop, Then Start

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

    Private Sub btnLocate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLocate.Click
        If (Me.btnLocate.Text = "Enable") Then
            If m_adamModbusSocket.Configuration.SYS_SetLocateModule(m_iSlot_ID, 255) Then
                Me.btnLocate.Text = "Disable"
            Else
                MessageBox.Show("Locate module failed!", "Error")
            End If
        ElseIf m_adamModbusSocket.Configuration.SYS_SetLocateModule(m_iSlot_ID, 0) Then
            btnLocate.Text = "Enable"
        Else
            MessageBox.Show("Locate module failed!", "Error")
        End If

    End Sub

    Private Sub Btn_Quit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Quit.Click
        Close()
    End Sub

    Private Sub tcRemote_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcRemote.SelectedIndexChanged
        Dim uiWidth As UInteger
        Dim bEnable As Boolean = True
        Dim strSelPageName As String = tcRemote.TabPages(tcRemote.SelectedIndex).Text
        Me.StatusBar_IO.Text = ""
        m_adamModbusSocket.Disconnect()
        m_adamModbusSocket.Connect(m_adamModbusSocket.GetIP(), protoType, portNum)

        If (strSelPageName = "Module Information") Then
            Timer1.Enabled = False
            m_iFailCount = 0
            Me.m_iPollingCount = 0
        ElseIf (strSelPageName = "DI") Then
            'Get DI Filter Value
            If (m_adamModbusSocket.DigitalInput().GetDigitalFilterMiniSignalWidth(m_iSlot_ID, uiWidth, bEnable)) Then
                txtCntMin.Text = CStr(uiWidth)
                chkBoxDiFilterEnable.Checked = bEnable
            End If
            Timer1.Enabled = True
        ElseIf (strSelPageName = "DO") Then
            Timer1.Enabled = True
            RefreshSafetySetting() 'Refresh safety information
            chbxEnableSafety.Checked = m_bIsEnableSafetyFcn
        End If

    End Sub

    Private Function RefreshData() As Boolean ' Refresh DIO Channel Information "Value" column

        bInVal = Nothing
        bOutVal = Nothing

        Dim strSelPageName As String = tcRemote.TabPages(tcRemote.SelectedIndex).Text
        Dim i As Integer

        If (strSelPageName = "DI") Then

            If Not m_adamModbusSocket.DigitalInput.GetValues(Me.m_iSlot_ID, Me.m_iDIChannelNum, bInVal) Then
                Me.StatusBar_IO.Text = (StatusBar_IO.Text + ("ApiErr:" _
                            + (m_adamModbusSocket.DigitalInput.ApiLastError.ToString + " ")))
                Return False
            End If

            For i = 0 To bInVal.Length - 1
                If listViewChInfo_DI.Items(i).SubItems(3).Text <> bInVal(i).ToString Then
                    listViewChInfo_DI.Items(i).SubItems(3).Text = bInVal(i).ToString 'moduify "Value" column

                End If
            Next

        ElseIf (strSelPageName = "DO") Then

            If Not m_adamModbusSocket.DigitalOutput.GetValues(Me.m_iSlot_ID, Me.m_iDOChannelNum + m_iDIChannelNum, bOutVal) Then 'should add offset for DIO modules 
                Me.StatusBar_IO.Text = (StatusBar_IO.Text + ("ApiErr:" + (m_adamModbusSocket.DigitalOutput.ApiLastError.ToString + " ")))
                Return False
            End If

            For i = 0 To bOutVal.Length - m_iDIChannelNum - 1
                If listViewChInfo_DO.Items(i).SubItems(3).Text <> bOutVal(i + m_iDIChannelNum).ToString Then
                    listViewChInfo_DO.Items(i).SubItems(3).Text = bOutVal(i + m_iDIChannelNum).ToString 'moduify "Value" column

                End If
            Next

        End If

        Return True

    End Function

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        Timer1.Enabled = False

        Dim bRet As Boolean

        Me.StatusBar_IO.Text = ("Polling (Interval=" + (Timer1.Interval.ToString + "ms): "))
        bRet = RefreshData()

        If bRet Then
            m_iPollingCount = (m_iPollingCount + 1)
            m_iFailCount = 0
            StatusBar_IO.Text = (StatusBar_IO.Text + (m_iPollingCount.ToString + " times..."))
        Else
            m_iFailCount = (m_iFailCount + 1)
            StatusBar_IO.Text = (StatusBar_IO.Text + (m_iFailCount.ToString + " failures..."))
        End If

        If (m_iFailCount > 5) Then
            Timer1.Enabled = False
            StatusBar_IO.Text = (StatusBar_IO.Text + " polling suspended!!")
            MessageBox.Show("Failed more than 5 times! Please check the physical connection!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Return
        End If

        If ((m_iPollingCount Mod 50) = 0) Then
            GC.Collect()
        End If

        Timer1.Enabled = True

    End Sub

    Private Sub chbxHide_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbxHide.CheckStateChanged
        Me.panel2.Visible = Not chbxHide.Checked
    End Sub

    Private Function CheckControllable() As Boolean ' Check module controllable
        Dim active As System.UInt16
        If m_adamModbusSocket.Configuration.SYS_GetGlobalActive(active) Then
            If (active = 1) Then
                Return True
            Else
                MessageBox.Show("There is another controller taking control, so you only can monitor IO data.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
                Return False
            End If
        End If
        MessageBox.Show(("Checking controllable failed, utility only could monitor io data now. (" _
                        + (m_adamModbusSocket.Configuration.ApiLastError.ToString + ")")), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
        Return False
    End Function

    Private Sub settingDO_SetTF(ByVal bState As Boolean) ' Set selected channels status to true or false
        If Not CheckControllable() Then
            Return
        End If
        Timer1.Enabled = False
        If (listViewChInfo_DO.SelectedIndices.Count = 0) Then
            MessageBox.Show("Please select the target channel in the listview!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            Timer1.Enabled = True
            Return
        Else
            Dim i As Integer = 0
            Do While (i < listViewChInfo_DO.SelectedIndices.Count)
                If m_adamModbusSocket.DigitalOutput.SetValue(m_iSlot_ID, listViewChInfo_DO.SelectedIndices(i) + m_iDIChannelNum, bState) Then
                    RefreshData()
                Else
                    MessageBox.Show("Set digital output failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                End If
                i = (i + 1)
            Loop
        End If
        Timer1.Enabled = True
    End Sub

    Private Sub listViewChInfo_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles listViewChInfo_DO.ItemActivate ' Double click channel to change value
        If Not CheckControllable() Then
            Return
        End If
        Dim strVal As String = listViewChInfo_DO.Items(listViewChInfo_DO.SelectedIndices(0)).SubItems(3).Text
        Dim bVal As Boolean = False
        If (strVal = "True") Then
            bVal = False
        Else
            bVal = True
        End If
        settingDO_SetTF(bVal)
    End Sub

    Private Sub btnApplySetting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApplySetting.Click

        Dim uiWidth As UInteger = 10
        Dim bDI As Boolean = Me.chkBoxDiFilterEnable.Checked
        Dim strCntMin As String = Me.txtCntMin.Text

        If strCntMin <> "" Then
            uiWidth = Convert.ToUInt32(strCntMin)
        Else
            MessageBox.Show("Error: Width value is invalid.", _
                            "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            Return
        End If


        If ((uiWidth > DI_FILTER_WIDTH_MAX) _
                    OrElse (uiWidth < DI_FILTER_WIDTH_MIN)) Then
            MessageBox.Show("Error: Illegal parameter. The range of Di filter width is " _
                            + CStr(DI_FILTER_WIDTH_MIN) + "~" _
                            + CStr(DI_FILTER_WIDTH_MAX) + " (0.1ms)." + vbLf + "And the width value have to be multiple of 5.", _
                            "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            Return
        End If

        If m_adamModbusSocket.DigitalInput.SetDigitalFilterMiniSignalWidth(Me.m_iSlot_ID, uiWidth, bDI) Then
            If ((uiWidth Mod 5) _
                        = 0) Then
                MessageBox.Show("Set digital filter width done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            Else
                MessageBox.Show(("Set digital filter width done!" + vbLf + "The width value have to be multiple of 5." + vbLf + " (" _
                        + (uiWidth.ToString + (" => " _
                        + (Convert.ToString((uiWidth _
                            - (uiWidth Mod 5))) + ")")))), "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            End If
        Else
            MessageBox.Show("Set digital filter width failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            Return
        End If

    End Sub

    Private Sub listViewChInfo_DO_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not CheckControllable() Then
            Return
        End If
        Dim strVal As String = listViewChInfo_DO.Items(listViewChInfo_DO.SelectedIndices(0)).SubItems(3).Text
        Dim bVal As Boolean = False
        If (strVal = "True") Then
            bVal = False
        Else
            bVal = True
        End If
        settingDO_SetTF(bVal)
    End Sub

    Private Sub btnTrue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTrue.Click
        If Not CheckControllable() Then
            Return
        End If
        settingDO_SetTF(True)
    End Sub

    Private Sub btnFalse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFalse.Click
        If Not CheckControllable() Then
            Return
        End If
        settingDO_SetTF(False)
    End Sub

    Private Sub RefreshSafetySetting() ' Refresh Modules's Safety column value

        Dim i As Integer = 0

        If Not m_adamModbusSocket.Configuration.OUT_GetSafetyEnable(Me.m_iSlot_ID, m_bIsEnableSafetyFcn) Then
            StatusBar_IO.Text = (StatusBar_IO.Text + ("OUT_GetSafetyEnable(Error:" _
                        + (m_adamModbusSocket.Configuration.ApiLastError.ToString + ") Failed! ")))
        End If

        If m_bIsEnableSafetyFcn Then

            Dim o_bValues() As Boolean = Nothing
            Dim strSafetyValue() As String = Nothing

            Me.chbxEnableSafety.Checked = True

            If m_adamModbusSocket.DigitalOutput.GetSafetyValues(m_iSlot_ID, Me.m_iDOChannelNum, o_bValues) Then

                m_bDOSafetyVals = o_bValues
                strSafetyValue = New String((m_iDOChannelNum) - 1) {}
                For i = 0 To m_iDOChannelNum - 1
                    listViewChInfo_DO.Items(i).SubItems(5).Text = m_bDOSafetyVals(i).ToString 'moduify "Safety" column
                Next

            Else
                Me.StatusBar_IO.Text = (StatusBar_IO.Text + ("GetSafetyValues(Error:" _
                            + (m_adamModbusSocket.DigitalOutput.ApiLastError.ToString + ") Failed! ")))
            End If
        Else
            For i = 0 To m_iDOChannelNum - 1
                listViewChInfo_DO.Items(i).SubItems(5).Text = "Disable" 'moduify "Safety" column
            Next

        End If

    End Sub

    Private Sub formSafety_ApplySafetyValueClick(ByVal bVal() As Boolean) '  Apply setting when user configure safety status
        If Not m_adamModbusSocket.DigitalOutput.SetSafetyValues(m_iSlot_ID, bVal) Then
            MessageBox.Show(("Set safety value failed! (Err: " _
                            + (m_adamModbusSocket.DigitalOutput.ApiLastError.ToString + ")")), "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
        Else
            MessageBox.Show("Set safety value ok!", "Info")
        End If
        RefreshSafetySetting()
    End Sub

    Private Sub btnSetSafetyValue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetSafetyValue.Click
        If Not CheckControllable() Then
            Return
        End If

        Timer1.Enabled = False
        Dim formSafety As FormSafetySetting = New FormSafetySetting(Me.m_iDOChannelNum, m_bDOSafetyVals)
        AddHandler formSafety.ApplySafetyValueClick, AddressOf Me.formSafety_ApplySafetyValueClick
        formSafety.ShowDialog()
        formSafety.Dispose()
        formSafety = Nothing
        Timer1.Enabled = True
    End Sub

    Private Sub chbxHide_DO_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbxHide_DO.CheckStateChanged
        panel1.Visible = (Not chbxHide_DO.Checked)
    End Sub

    Private Sub chbxEnableSafety_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbxEnableSafety.CheckStateChanged
        btnSetSafetyValue.Enabled = chbxEnableSafety.Checked
        If Not CheckControllable() Then
            Return
        End If
        If Not m_adamModbusSocket.Configuration.OUT_SetSafetyEnable(m_iSlot_ID, chbxEnableSafety.Checked) Then
            MessageBox.Show(("Set safety function failed! (Err: " _
                            + (m_adamModbusSocket.Configuration.ApiLastError.ToString + ")")), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        End If
        RefreshSafetySetting()
    End Sub

    Private Sub Form_APAX_4045_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        FreeResource()
    End Sub
End Class
