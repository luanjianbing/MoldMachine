Imports Advantech.Adam
Imports Advantech.Common
Imports System.Data
Imports System.Threading

Public Class Form_APAX_5080

    'Global
    Dim APAX_INFO_NAME As String = "APAX"
    Public Const DVICE_TYPE = "5080"

    Dim m_adamCtl As AdamControl 'Control Handle
    Dim m_aConf As Apax5000Config 'Configuration information
    Dim m_iSlot_ID As Integer 'Device switch ID
    Dim m_ScanTime_LocalSys() As Integer
    Dim m_szSlots() As String 'Container of all solt device type
    Dim bOutVal(), bInVal() As Boolean 'Container of DIO Status
    Dim m_bStartFlag As Boolean = False

    Dim m_iPollingCount As Integer 'Polling device status count
    Dim m_iFailCount As Integer 'Device Polling fail count
    Dim m_iDIChannelNum As Integer 'Device DI Channel number
    Dim m_iDOChannelNum As Integer 'Device DO Channel number
    Dim m_iCNTChannelNum As Integer 'Device DI Channel number
    Dim m_CNTidx As Integer
    Dim m_iDoOffset As Integer = 0
    Dim m_usRanges() As System.UInt16
    Dim m_bChMask() As Boolean = New Boolean((AdamControl.APAX_MaxAIOCh) - 1) {}
    Dim m_uiChMask As UInteger = 0
    Dim m_uiDOPulseWidth() As UInteger
    Dim m_uiAlarmLimitValue() As UInteger
    Dim m_usAlarmsConfig() As System.UInt16 'H-byte is DOBehavior, L-byte is AlarmConfig
    Dim m_usRanges_supAI() As System.UInt16
    Dim m_usCNTConfig() As System.UInt16 'H-byte is GateConfig, L-byte is CNTConfig
    Dim m_uiStartupCNT() As UInteger

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
        Me.StatusBar_IO.Text = "Start to demo " + APAX_INFO_NAME + "-" + DVICE_TYPE + " by clicking 'Start' button."

    End Sub
    Public Sub New(ByVal SlotNum As Integer, ByVal ScanTime As Integer)
        MyBase.New()

        InitializeComponent()
        m_szSlots = Nothing
        m_iSlot_ID = SlotNum 'Set Slot_ID
        m_iPollingCount = 0
        m_iFailCount = 0
        m_ScanTime_LocalSys = New Integer((1) - 1) {}
        m_ScanTime_LocalSys(0) = ScanTime 'Scan time
        Timer1.Interval = m_ScanTime_LocalSys(0)
        Me.StatusBar_IO.Text = "Start to demo " + APAX_INFO_NAME + "-" + DVICE_TYPE + " by clicking 'Start' button."

    End Sub
    Public ReadOnly Property IsShowRawData() As Boolean

        Get
            Return chbxShowRawData.Checked
        End Get

    End Property
    Public Function OpenDevice() As Boolean

        m_adamCtl = New AdamControl(AdamType.Apax5000)

        If m_adamCtl.OpenDevice Then
            If Not m_adamCtl.Configuration.SYS_SetDspChannelFlag(False) Then
                Me.StatusBar_IO.Text = "SYS_SetDspChannelFlag(false) Failed! "
                Return False
            End If
            If (Not m_adamCtl.Configuration.GetSlotInfo(m_szSlots)) Then
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

    Public Function RefreshConfiguration() As Boolean

        Dim i As Integer = 0

        If m_adamCtl.Configuration.GetModuleConfig(m_iSlot_ID, m_aConf) Then

            Me.txtModuleID.Text = (APAX_INFO_NAME + ("-" + m_aConf.GetModuleName)) 'Information-> Module
            Me.txtSWID.Text = m_iSlot_ID.ToString  'Information -> Switch ID
            Me.txtSupportKernelFw.Text = m_aConf.wSupportFwVer.ToString("X04").Insert(2, ".") 'Information -> Support kernel Fw
            Me.txtFwVer.Text = m_aConf.wFwVerNo.ToString("X04").Insert(2, ".") 'Firmware version
            m_usRanges = m_aConf.wChRange

        Else
            Me.StatusBar_IO.Text = (" GetModuleConfig(Error:" _
                        + (m_adamCtl.Configuration.ApiLastError.ToString + ") Failed! "))
            Return False
        End If


        Return True

    End Function

    Public Sub SetAlarmTypeComboBox(ByVal strTypes() As String) ' Get DO setting -> Alarm Type string

        cbxAlarmType.BeginUpdate()
        cbxAlarmType.Items.Clear()
        Dim i As Integer = 0
        Do While (i < strTypes.Length)
            cbxAlarmType.Items.Add(strTypes(i))
            i = (i + 1)
        Loop
        If (cbxAlarmType.Items.Count > 0) Then
            cbxAlarmType.SelectedIndex = 0
        End If
        cbxAlarmType.EndUpdate()

    End Sub

    Public Sub SetMappingChComboBox(ByVal iChNum As Integer, ByVal strMode() As String) ' Get DO setting -> Mapping channel values

        cbxLocalAlarmMapCh.BeginUpdate()
        cbxLocalAlarmMapCh.Items.Clear()
        Dim i As Integer = 0
        Do While (i < iChNum)
            cbxLocalAlarmMapCh.Items.Add(i.ToString)
            i = (i + 1)
        Loop
        If (cbxLocalAlarmMapCh.Items.Count > 0) Then
            cbxLocalAlarmMapCh.SelectedIndex = 0
        End If
        cbxLocalAlarmMapCh.EndUpdate()

    End Sub

    Public Sub SetDOBehaviorComboBox(ByVal strTypes() As String)    ' Get DO setting -> DO behavior string
        cbxDOBehavior.BeginUpdate()
        cbxDOBehavior.Items.Clear()
        Dim i As Integer = 0
        Do While (i < strTypes.Length)
            cbxDOBehavior.Items.Add(strTypes(i))
            i = (i + 1)
        Loop
        If (cbxDOBehavior.Items.Count > 0) Then
            cbxDOBehavior.SelectedIndex = 0
        End If
        cbxDOBehavior.EndUpdate()
    End Sub

    Public Sub SetRangeComboBox(ByVal strRanges() As String)  ' Get CNT setting -> CNT Mode
        cbxRange.BeginUpdate()
        cbxRange.Items.Clear()
        Dim i As Integer = 0
        Do While (i < strRanges.Length)
            cbxRange.Items.Add(strRanges(i))
            i = (i + 1)
        Loop
        If (cbxRange.Items.Count > 0) Then
            cbxRange.SelectedIndex = 0
        End If
        cbxRange.EndUpdate()
    End Sub

    Public Sub SetCNTMappingChComboBox(ByVal iChNum As Integer) ' Get CNT setting -> Counter Gate Setting -> Mapping gate
        cbxLocalGateMapCh.BeginUpdate()
        cbxLocalGateMapCh.Items.Clear()
        Dim i As Integer = 0
        Do While (i < iChNum)
            cbxLocalGateMapCh.Items.Add(i.ToString)
            i = (i + 1)
        Loop
        If (cbxLocalGateMapCh.Items.Count > 0) Then
            cbxLocalGateMapCh.SelectedIndex = 0
        End If
        cbxLocalGateMapCh.EndUpdate()
    End Sub

    Public Sub SetGateTypeComboBox(ByVal strTypes() As String) ' Get CNT setting -> Counter Gate Setting -> Gate Active Type
        cbxGateType.BeginUpdate()
        cbxGateType.Items.Clear()
        Dim i As Integer = 0
        Do While (i < strTypes.Length)
            cbxGateType.Items.Add(strTypes(i))
            i = (i + 1)
        Loop
        If (cbxGateType.Items.Count > 0) Then
            cbxGateType.SelectedIndex = 0
        End If
        cbxGateType.EndUpdate()
    End Sub

    Public Sub SetGateTriggerModeComboBox(ByVal strTypes() As String) ' Get CNT setting -> Counter Gate Setting -> Trigger mode
        cbxTriggerMode.BeginUpdate()
        cbxTriggerMode.Items.Clear()
        Dim i As Integer = 0
        Do While (i < strTypes.Length)
            cbxTriggerMode.Items.Add(strTypes(i))
            i = (i + 1)
        Loop
        If (cbxTriggerMode.Items.Count > 0) Then
            cbxTriggerMode.SelectedIndex = 0
        End If
        cbxTriggerMode.EndUpdate()
    End Sub

    Public Sub InitialRemotePanelComponents()

        Dim iLoop As Integer
        Dim lvItem As ListViewItem
        Dim strRange() As String
        listViewChInfo_DI.Items.Clear()
        listViewChInfo_DI.BeginUpdate()

        For iLoop = 0 To Me.m_iDIChannelNum - 1

            lvItem = New ListViewItem(_HardwareIOType.DI.ToString)
            lvItem.SubItems.Add(iLoop.ToString) 'Type
            lvItem.SubItems.Add("*****") 'Ch
            lvItem.SubItems.Add("BOOL")  'Value
            lvItem.SubItems.Add("*****") 'Mode
            listViewChInfo_DI.Items.Add(lvItem)

        Next
        listViewChInfo_DI.EndUpdate()
        strRange = New String((m_aConf.HwIoTotal(2)) - 1) {}
        SetAlarmTypeComboBox(New String() {"Low", "High"}) 'Get DO setting -> Alarm Type string

        For iLoop = 0 To m_iDOChannelNum - 1
            strRange(iLoop) = AnalogInput.GetRangeName(m_usRanges(iLoop))
        Next

        SetMappingChComboBox(m_iDOChannelNum, strRange)   'Counter number
        SetDOBehaviorComboBox(New String() {"Low Level", "High Level", "Low Pulse", "High Pulse"}) 'Get DO setting -> DO behavior string
        listViewChInfo_DO.Items.Clear()
        listViewChInfo_DO.BeginUpdate() 'Init channel information

        For iLoop = 0 To m_iDOChannelNum - 1

            lvItem = New ListViewItem(_HardwareIOType.DO.ToString) 'Type
            lvItem.SubItems.Add(iLoop.ToString)  'Ch
            lvItem.SubItems.Add("*****") 'DO Value
            lvItem.SubItems.Add("BOOL") 'Mode
            lvItem.SubItems.Add("*****") 'Alarm Type
            lvItem.SubItems.Add("*****") 'Alarm Limit
            lvItem.SubItems.Add("*****") 'Alarm Flag
            lvItem.SubItems.Add("*****")
            lvItem.SubItems.Add("*****") 'Map Ch
            listViewChInfo_DO.Items.Add(lvItem) 'DO Behavior

        Next

        listViewChInfo_DO.EndUpdate()
        m_uiDOPulseWidth = New UInteger((m_iDOChannelNum) - 1) {}
        m_uiAlarmLimitValue = New UInteger((m_iDOChannelNum) - 1) {}
        m_usAlarmsConfig = New System.UInt16((m_iDOChannelNum) - 1) {}
        listViewChInfo_DO.EndUpdate()
        strRange = Nothing

        strRange = New String((m_aConf.HwIoType_TotalRange(m_CNTidx)) - 1) {}
        For iLoop = 0 To strRange.Length - 1
            strRange(iLoop) = Counter.GetModeName(m_usRanges_supAI(iLoop))
        Next
        m_usCNTConfig = New System.UInt16((m_aConf.HwIoTotal(m_CNTidx)) - 1) {}
        SetRangeComboBox(strRange)

        SetCNTMappingChComboBox(m_aConf.HwIoTotal(0)) 'Get CNT setting -> CNT Mode (Range)
        'Mapping DI number
        SetGateTypeComboBox(New String() {"Low level", "Falling edge", "High level", "Rising edge"})
        'Get CNT setting -> Counter Gate Setting -> Gate Active Type
        SetGateTriggerModeComboBox(New String() {"Non-Retrigger", "Retrigger", "Edge Start"})
        'Get CNT setting -> Counter Gate Setting -> Trigger mode
        'Init channel information
        listViewChInfo_CNT.Items.Clear()
        listViewChInfo_CNT.BeginUpdate()

        For iLoop = 0 To m_iCNTChannelNum - 1

            lvItem = New ListViewItem(_HardwareIOType.CNT.ToString) 'Type
            lvItem.SubItems.Add(iLoop.ToString) 'Ch
            lvItem.SubItems.Add("*****") 'Value
            lvItem.SubItems.Add("*****")     'Mode
            lvItem.SubItems.Add("*****") 'Startup
            lvItem.SubItems.Add("*****") 'Counting
            lvItem.SubItems.Add("*****")  'Status
            lvItem.SubItems.Add("*****") 'Count Type
            lvItem.SubItems.Add("*****") 'Map Ch
            lvItem.SubItems.Add("*****") 'Gate Active
            lvItem.SubItems.Add("*****") 'Gate trigger
            listViewChInfo_CNT.Items.Add(lvItem)

        Next

        listViewChInfo_CNT.EndUpdate()

    End Sub

    Public Function GetChannelInfo() As Boolean

        Dim iLoop As Integer

        For iLoop = 0 To m_aConf.HwIoType.Length - 1

            If (m_aConf.HwIoType(iLoop) = _HardwareIOType.DI) Then
                m_iDIChannelNum = m_aConf.HwIoTotal(iLoop)
                m_iDoOffset = m_iDIChannelNum
            End If

            If (m_aConf.HwIoType(iLoop) = _HardwareIOType.DO) Then
                m_iDOChannelNum = m_aConf.HwIoTotal(iLoop)
            End If

            If (m_aConf.HwIoType(iLoop) = _HardwareIOType.CNT) Then
                m_iCNTChannelNum = m_aConf.HwIoTotal(iLoop)
                m_CNTidx = iLoop
                If (iLoop = 0) Then
                    m_usRanges_supAI = m_aConf.wHwIoType_0_Range
                ElseIf (iLoop = 1) Then
                    m_usRanges_supAI = m_aConf.wHwIoType_1_Range
                ElseIf (iLoop = 2) Then
                    m_usRanges_supAI = m_aConf.wHwIoType_2_Range
                ElseIf (iLoop = 3) Then
                    m_usRanges_supAI = m_aConf.wHwIoType_3_Range
                Else
                    m_usRanges_supAI = m_aConf.wHwIoType_4_Range
                End If

            End If

        Next

        Return True

    End Function

    Public Function StartRemote()

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

            'disable timer
            Timer1.Enabled = False
            'disable locate module
            m_adamCtl.Configuration.SYS_SetLocateModule(m_iSlot_ID, 0)
            m_adamCtl = Nothing

        End If

        Return True

    End Function

    ''' <summary>
    ''' Get DO Alarm settings: Mode, Alarm type, DO behavior, Mapping Channel, Limit value, DO pulse width
    ''' </summary>
    Private Sub RefreshDoAlarmSetting()
        Dim bEnable As Boolean
        Dim bAutoRL As Boolean
        Dim byAlarmtype As Byte
        Dim iMappingCh As Integer
        Dim uiLimitVal As UInteger
        Dim byDOBehavior As Byte
        Dim uiPulseWidth As UInteger
        Dim i As Integer = 0

        Do While (i < listViewChInfo_DO.Items.Count)
            m_usAlarmsConfig(i) = 0
            m_uiDOPulseWidth(i) = 0
            m_uiAlarmLimitValue(i) = 0
            If m_adamCtl.Alarm.GetLocalAlarmConfiguration(m_iSlot_ID, i, bEnable, bAutoRL, byAlarmtype, iMappingCh, uiLimitVal, byDOBehavior, uiPulseWidth) Then
                m_usAlarmsConfig(i) = (m_usAlarmsConfig(i) + CType((byAlarmtype And &H1), System.UInt16))
                m_usAlarmsConfig(i) = (m_usAlarmsConfig(i) + CType((iMappingCh << 3), System.UInt16))
                m_usAlarmsConfig(i) = (m_usAlarmsConfig(i) + CType((byDOBehavior * &H100), System.UInt16))
                m_uiAlarmLimitValue(i) = uiLimitVal
                m_uiDOPulseWidth(i) = uiPulseWidth
                If bEnable Then
                    listViewChInfo_DO.Items(i).SubItems(0).Text = "Alarm"
                    'moduify "Type" column
                    m_usAlarmsConfig(i) = (m_usAlarmsConfig(i) + 4)
                    If (byAlarmtype = 0) Then
                        listViewChInfo_DO.Items(i).SubItems(4).Text = "Low"
                    ElseIf (byAlarmtype = 1) Then
                        listViewChInfo_DO.Items(i).SubItems(4).Text = "High"
                    Else
                        listViewChInfo_DO.Items(i).SubItems(4).Text = "???"
                    End If
                    Dim strMappingCh As String = ("Cnt" + iMappingCh.ToString)
                    If bAutoRL Then
                        m_usAlarmsConfig(i) = (m_usAlarmsConfig(i) + &H40)
                        strMappingCh = (strMappingCh + "(AutoRL)")
                    End If
                    listViewChInfo_DO.Items(i).SubItems(7).Text = strMappingCh
                    'moduify "Map Ch" column
                    listViewChInfo_DO.Items(i).SubItems(5).Text = uiLimitVal.ToString
                    'moduify "Alarm Limit" column
                    If (byDOBehavior = 0) Then
                        listViewChInfo_DO.Items(i).SubItems(8).Text = "Low Level"
                    ElseIf (byDOBehavior = 1) Then
                        listViewChInfo_DO.Items(i).SubItems(8).Text = "High Level"
                    ElseIf (byDOBehavior = 2) Then
                        listViewChInfo_DO.Items(i).SubItems(8).Text = ("PulseLo Width" + uiPulseWidth.ToString)
                    ElseIf (byDOBehavior = 3) Then
                        listViewChInfo_DO.Items(i).SubItems(8).Text = ("PulseHi Width" + uiPulseWidth.ToString)
                    Else
                        listViewChInfo_DO.Items(i).SubItems(8).Text = "???"
                    End If
                Else
                    listViewChInfo_DO.Items(i).SubItems(0).Text = "DO"
                    'moduify "Type" column
                    listViewChInfo_DO.Items(i).SubItems(4).Text = "Disable"
                    'moduify "Alarm Type" column
                    listViewChInfo_DO.Items(i).SubItems(7).Text = "Disable"
                    'moduify "Map Ch" column
                    listViewChInfo_DO.Items(i).SubItems(5).Text = "Disable"
                    'moduify "Alarm Limit" column
                    listViewChInfo_DO.Items(i).SubItems(8).Text = "Disable"
                    'moduify "DO Behavior" column
                End If
            Else
                listViewChInfo_DO.Items(i).SubItems(0).Text = "*****"
                'moduify "Type" column
                listViewChInfo_DO.Items(i).SubItems(4).Text = "*****"
                'moduify "Alarm Type" column
                listViewChInfo_DO.Items(i).SubItems(7).Text = "*****"
                'moduify "Map Ch" column
                listViewChInfo_DO.Items(i).SubItems(5).Text = "*****"
                'moduify "Alarm Limit" column
                listViewChInfo_DO.Items(i).SubItems(8).Text = "*****"
                'moduify "DO Behavior" column
                Dim strErr As String
                strErr = ("GetLocalAlarmConfiguration(Error:" _
                            + (m_adamCtl.Counter.ApiLastError.ToString + ") Failed! "))
                StatusBar_IO.Text = (StatusBar_IO.Text + strErr)
            End If
            i = (i + 1)
        Loop
    End Sub

    ''' <summary>
    ''' Get CNT configuration
    ''' </summary>
    Private Sub RefreshCntCountMode()
        Dim bOnceRepeat As Boolean
        Dim bReloadIniti As Boolean
        Dim i As Integer = 0
        Do While (i < listViewChInfo_CNT.Items.Count)
            If m_adamCtl.Counter.GetCntTypeConfiguration(Me.m_iSlot_ID, i, bOnceRepeat, bReloadIniti) Then
                Dim us_Temp As System.UInt16 = CType(((Convert.ToUInt16(bOnceRepeat) * &H2) + (Convert.ToUInt16(bReloadIniti) * &H1)), System.UInt16)
                m_usCNTConfig(i) = CType(((m_usCNTConfig(i) And &HFF00) + us_Temp), System.UInt16)
                Dim strCntMode As String
                If (Not ((m_usRanges(i) = CType(ApaxUnknown_InputRange.Up, System.UInt16)) _
                            OrElse ((m_usRanges(i) = CType(ApaxUnknown_InputRange.HighFrequency, System.UInt16)) _
                            OrElse ((m_usRanges(i) = CType(ApaxUnknown_InputRange.LowFrequency, System.UInt16)) _
                            OrElse (m_usRanges(i) = CType(ApaxUnknown_InputRange.WaveWidth, System.UInt16))))) _
                            AndAlso ((i Mod 2) = 1)) Then
                    listViewChInfo_CNT.Items(i).SubItems(7).Text = "*****"
                    'Update "Count Type" column
                    'TODO: Warning!!! continue If
                End If
                If bOnceRepeat Then
                    strCntMode = "Repeat"
                Else
                    strCntMode = "Once"
                End If
                If bReloadIniti Then
                    strCntMode = (strCntMode + "//ReloadToStartup")
                Else
                    strCntMode = (strCntMode + "//ReloadToZero")
                End If
                listViewChInfo_CNT.Items(i).SubItems(7).Text = strCntMode
                'Update "Count Type" column
            Else
                listViewChInfo_CNT.Items(i).SubItems(7).Text = "*****"
                Dim strErr As String = ("GetCntConfiguration(Error:" _
                            + (m_adamCtl.Counter.ApiLastError.ToString + ") Failed! "))
                StatusBar_IO.Text = (StatusBar_IO.Text + strErr)
            End If
            System.Threading.Thread.Sleep(20)
            i = (i + 1)
        Loop
    End Sub

    ''' <summary>
    ''' Get CNT gate configuration
    ''' </summary>
    Private Sub RefreshCntGateSetting()
        Dim bEnable As Boolean
        Dim byRetriggerMode As Byte
        Dim byGatetype As Byte
        Dim iMappingCh As Integer
        Dim i As Integer = 0
        Do While (i < listViewChInfo_CNT.Items.Count)
            If m_adamCtl.Counter.GetLocalGateConfiguration(m_iSlot_ID, i, bEnable, byRetriggerMode, byGatetype, iMappingCh) Then
                Dim us_Temp As System.UInt16 = CType((((iMappingCh * &H20) _
                            + ((Convert.ToUInt16(bEnable) * &H10) _
                            + ((byRetriggerMode * &H4) _
                            + (byGatetype * &H1)))) _
                            * &H100), System.UInt16)
                m_usCNTConfig(i) = CType(((m_usCNTConfig(i) And &H100) + us_Temp), System.UInt16)
                If (Not ((m_usRanges(i) = CType(ApaxUnknown_InputRange.Up, System.UInt16)) _
                            OrElse ((m_usRanges(i) = CType(ApaxUnknown_InputRange.HighFrequency, System.UInt16)) _
                            OrElse ((m_usRanges(i) = CType(ApaxUnknown_InputRange.LowFrequency, System.UInt16)) _
                            OrElse (m_usRanges(i) = CType(ApaxUnknown_InputRange.WaveWidth, System.UInt16))))) _
                            AndAlso ((i Mod 2) _
                            = 1)) Then
                    listViewChInfo_CNT.Items(i).SubItems(10).Text = "*****"
                    'Update "Gate Trigger" column
                    listViewChInfo_CNT.Items(i).SubItems(9).Text = "*****"
                    'Update "Gate Active" column
                    listViewChInfo_CNT.Items(i).SubItems(8).Text = "*****"
                    'Update "Map Ch" column
                    'TODO: Warning!!! continue If
                End If
                Dim strMappingCh As String
                Dim strGateSetting As String
                Dim strGateActiveType As String
                If bEnable Then
                    If (byRetriggerMode = 0) Then
                        strGateSetting = "Non-Retrigger"
                    ElseIf (byRetriggerMode = 1) Then
                        strGateSetting = "Retrigger"
                    ElseIf (byRetriggerMode = 2) Then
                        strGateSetting = "Edge Start"
                    Else
                        strGateSetting = "???"
                    End If
                    If (byGatetype = 0) Then
                        strGateActiveType = "Low level"
                    ElseIf (byGatetype = 1) Then
                        strGateActiveType = "Falling edge"
                    ElseIf (byGatetype = 2) Then
                        strGateActiveType = "High level"
                    ElseIf (byGatetype = 3) Then
                        strGateActiveType = "Rising edge"
                    Else
                        strGateActiveType = "???"
                    End If
                    strMappingCh = ("Gate" + iMappingCh.ToString)
                Else
                    strGateActiveType = "Disable"
                    strGateSetting = "Disable"
                    strMappingCh = "Disable"
                End If
                listViewChInfo_CNT.Items(i).SubItems(10).Text = strGateSetting
                'Update "Gate Trigger" column
                listViewChInfo_CNT.Items(i).SubItems(9).Text = strGateActiveType
                'Update "Gate Active" column
                listViewChInfo_CNT.Items(i).SubItems(8).Text = strMappingCh
                'Update "Map Ch" column
            Else
                Dim strErr As String = ("GetLocalGateConfiguration(Error:" _
                            + (m_adamCtl.Counter.ApiLastError.ToString + ") Failed! "))
                StatusBar_IO.Text = (StatusBar_IO.Text + strErr)
            End If
            System.Threading.Thread.Sleep(20)
            i = (i + 1)
        Loop
    End Sub

    ''' <summary>
    ''' Get CNT Startup value
    ''' </summary>
    ''' <returns></returns>
    Private Function RefreshCntStartupValues() As Boolean
        Dim iChannelTotal As Integer
        Try
            iChannelTotal = Me.m_aConf.HwIoTotal(m_CNTidx)
            If m_adamCtl.Counter.GetStartupValues(m_iSlot_ID, iChannelTotal, m_uiStartupCNT) Then
                Dim i As Integer = 0
                Do While (i < iChannelTotal)
                    If (Not ((m_usRanges(i) = CType(ApaxUnknown_InputRange.Up, System.UInt16)) _
                                OrElse ((m_usRanges(i) = CType(ApaxUnknown_InputRange.HighFrequency, System.UInt16)) _
                                OrElse ((m_usRanges(i) = CType(ApaxUnknown_InputRange.LowFrequency, System.UInt16)) _
                                OrElse (m_usRanges(i) = CType(ApaxUnknown_InputRange.WaveWidth, System.UInt16))))) _
                                AndAlso ((i Mod 2) _
                                = 1)) Then
                        listViewChInfo_CNT.Items(i).SubItems(4).Text = "*****"
                        'Update "Startup" column
                        'TODO: Warning!!! continue If
                    End If
                    listViewChInfo_CNT.Items(i).SubItems(4).Text = m_uiStartupCNT(i).ToString
                    'Update "Startup" column
                    i = (i + 1)
                Loop
                Return True
            Else
                Dim strErr As String = ("GetStartupValues(Error:" _
                            + (m_adamCtl.Counter.ApiLastError.ToString + ") Failed! "))
                StatusBar_IO.Text = (StatusBar_IO.Text + strErr)
            End If
        Catch ex As Exception
            Return False
        End Try
        Return False
    End Function

    'Refresh CNT -> Setting -> Digital Filter & FreqAcq. Time
    Private Sub RefreshCntSetting()
        Dim iFilter As Integer = 0
        Dim szFilter As String = "???"
        Dim szFreqAcqTime As String = "???"
        Dim uiFcnParam As UInteger = 0
        If m_adamCtl.Counter.GetDigitalFilter(m_iSlot_ID, iFilter) Then
            szFilter = (CType(iFilter, Single) / 10).ToString
        Else
            StatusBar_IO.Text = (StatusBar_IO.Text + ("GetDigitalFilter(Error:" _
                        + (m_adamCtl.Counter.ApiLastError.ToString + ") Failed! ")))
        End If
        If m_adamCtl.Configuration.GetModuleConfig(m_iSlot_ID, m_aConf) Then
            'Check if support SampleRate
            If (Me.m_aConf.byFunType_0 = CType(_FunctionType.SampleRate, Byte)) Then
                uiFcnParam = m_aConf.dwFunParam_0
            ElseIf (Me.m_aConf.byFunType_1 = CType(_FunctionType.SampleRate, Byte)) Then
                uiFcnParam = m_aConf.dwFunParam_1
            ElseIf (Me.m_aConf.byFunType_2 = CType(_FunctionType.SampleRate, Byte)) Then
                uiFcnParam = m_aConf.dwFunParam_2
            ElseIf (Me.m_aConf.byFunType_3 = CType(_FunctionType.SampleRate, Byte)) Then
                uiFcnParam = m_aConf.dwFunParam_3
            ElseIf (Me.m_aConf.byFunType_4 = CType(_FunctionType.SampleRate, Byte)) Then
                uiFcnParam = m_aConf.dwFunParam_4
            Else
                Return
            End If
            uiFcnParam = (uiFcnParam / 1000)
            szFreqAcqTime = uiFcnParam.ToString
        Else
            Dim strErr As String = ("GetModuleConfig(Error:" _
                        + (m_adamCtl.Configuration.ApiLastError.ToString + ") Failed! "))
            StatusBar_IO.Text = (StatusBar_IO.Text + strErr)
        End If
        txtFilter.Text = szFilter
        txtFreqAcqTime.Text = szFreqAcqTime
    End Sub

    Public Sub EnableDisableControlPanel(ByVal i_state As Boolean, ByVal o_bEnable As Boolean)
        btnApplyCountType.Enabled = i_state
        txtStartupVal.Enabled = i_state
        btnApplySetting.Enabled = i_state
        btnStop.Enabled = i_state
        btnStart.Enabled = i_state
        btnResetCnt.Enabled = i_state
        btnClearOF.Enabled = i_state
        chbxReloadToStartup.Enabled = i_state
        chbxRepeat.Enabled = i_state
        chbxGateEnable.Enabled = i_state
        cbxLocalGateMapCh.Enabled = (i_state And o_bEnable)
        cbxGateType.Enabled = (i_state And o_bEnable)
        cbxTriggerMode.Enabled = (i_state And o_bEnable)
        btnApplyGateSetting.Enabled = i_state
    End Sub

    Private Sub LvChInfoCNT_SelectedIndexChanged(ByVal idxSel As Integer) ' When user select specific item of channel information(CNT), update related information of each channel

        If (Not ((m_usRanges(idxSel) = CType(ApaxUnknown_InputRange.Up, System.UInt16)) _
                    OrElse ((m_usRanges(idxSel) = CType(ApaxUnknown_InputRange.HighFrequency, System.UInt16)) _
                    OrElse ((m_usRanges(idxSel) = CType(ApaxUnknown_InputRange.LowFrequency, System.UInt16)) _
                    OrElse (m_usRanges(idxSel) = CType(ApaxUnknown_InputRange.WaveWidth, System.UInt16))))) _
                    AndAlso ((idxSel Mod 2) = 1)) Then
            cbxRange.SelectedIndex = cbxRange.Items.IndexOf(AnalogInput.GetRangeName(m_usRanges(idxSel)))
            EnableDisableControlPanel(False, False)
            'Disable all CNT control panel
        Else
            Dim o_bEnable As Boolean = (((m_usCNTConfig(idxSel) / &H100) And &H10) > 0)
            Dim o_byTriggerMode As Byte = CType((((m_usCNTConfig(idxSel) / &H100) And &HC) >> 2), Byte)
            Dim o_byGateActiveType As Byte = CType(((m_usCNTConfig(idxSel) / &H100) And &H3), Byte)
            Dim o_iGateMap As Integer = CType((((m_usCNTConfig(idxSel) / &H100) And 96) >> 5), Integer)
            Dim o_lStartup As Long = CType(m_uiStartupCNT(idxSel), Long)
            Dim o_bReload As Boolean = ((m_usCNTConfig(idxSel) And &H1) > 0)
            Dim o_bRepeat As Boolean = ((m_usCNTConfig(idxSel) And &H2) > 0)
            cbxRange.SelectedIndex = cbxRange.Items.IndexOf(AnalogInput.GetRangeName(m_usRanges(idxSel)))
            txtStartupVal.Text = o_lStartup.ToString
            chbxRepeat.Checked = o_bRepeat
            chbxReloadToStartup.Checked = o_bReload
            chbxGateEnable.Checked = o_bEnable
            cbxLocalGateMapCh.SelectedIndex = o_iGateMap
            cbxGateType.SelectedIndex = CType(o_byGateActiveType, Integer)
            cbxTriggerMode.SelectedIndex = CType(o_byTriggerMode, Integer)
            EnableDisableControlPanel(True, o_bEnable) 'Enable all CNT control panel
        End If

    End Sub

    Private Function RefreshRanges() As Boolean ' Update Channel information "Mode" column detail

        Dim i As Integer = 0


        Try
            If m_adamCtl.Configuration.GetModuleConfig(m_iSlot_ID, m_aConf) Then
                Dim iChannelTotal As Integer = Me.m_aConf.HwIoTotal(m_CNTidx)
                Dim strRange() As String = New String((iChannelTotal) - 1) {}
                m_usRanges = m_aConf.wChRange
                m_uiChMask = m_aConf.dwChMask

                For i = 0 To Me.m_bChMask.Length - 1
                    m_bChMask(i) = ((m_uiChMask And (&H1 << i)) > 0)
                Next
                listViewChInfo_CNT.BeginUpdate()
                For i = 0 To strRange.Length - 1
                    strRange(i) = Counter.GetModeName(m_usRanges(i))
                    If ((i Mod 2) _
                                = 0) Then
                        If (m_usRanges(i) = CType(ApaxUnknown_InputRange.Bi_Direction, System.UInt16)) Then
                            strRange(i) = (strRange(i) + "[P]")
                        ElseIf (m_usRanges(i) = CType(ApaxUnknown_InputRange.Up_Down, System.UInt16)) Then
                            strRange(i) = (strRange(i) + "[U]")
                        ElseIf ((m_usRanges(i) = CType(ApaxUnknown_InputRange.AB1X, System.UInt16)) _
                                    OrElse ((m_usRanges(i) = CType(ApaxUnknown_InputRange.AB2X, System.UInt16)) _
                                    OrElse (m_usRanges(i) = CType(ApaxUnknown_InputRange.AB4X, System.UInt16)))) Then
                            strRange(i) = (strRange(i) + "[A]")
                        End If
                    ElseIf (m_usRanges(i) = CType(ApaxUnknown_InputRange.Bi_Direction, System.UInt16)) Then
                        strRange(i) = (strRange(i) + "[D]")
                    ElseIf (m_usRanges(i) = CType(ApaxUnknown_InputRange.Up_Down, System.UInt16)) Then
                        strRange(i) = (strRange(i) + "[D]")
                    ElseIf ((m_usRanges(i) = CType(ApaxUnknown_InputRange.AB1X, System.UInt16)) _
                                OrElse ((m_usRanges(i) = CType(ApaxUnknown_InputRange.AB2X, System.UInt16)) _
                                OrElse (m_usRanges(i) = CType(ApaxUnknown_InputRange.AB4X, System.UInt16)))) Then
                        strRange(i) = (strRange(i) + "[B]")
                    End If
                    listViewChInfo_CNT.Items(i).SubItems(3).Text = strRange(i).ToString

                    'Update "Mode" column
                    If m_bChMask(i) Then
                        listViewChInfo_CNT.Items(i).SubItems(5).Text = "Start"
                    Else

                        'Update "Counting" column
                        If (Not ((m_usRanges(i) = CType(ApaxUnknown_InputRange.Up, System.UInt16)) _
                                    OrElse ((m_usRanges(i) = CType(ApaxUnknown_InputRange.HighFrequency, System.UInt16)) _
                                    OrElse ((m_usRanges(i) = CType(ApaxUnknown_InputRange.LowFrequency, System.UInt16)) _
                                    OrElse (m_usRanges(i) = CType(ApaxUnknown_InputRange.WaveWidth, System.UInt16))))) _
                                    AndAlso ((i Mod 2) = 1)) Then
                            listViewChInfo_CNT.Items(i).SubItems(5).Text = "*****"
                            'Update "Counting" column
                        Else
                            listViewChInfo_CNT.Items(i).SubItems(5).Text = "Stop"
                            'Update "Counting" column
                        End If
                    End If
                Next
                listViewChInfo_CNT.EndUpdate()

                RefreshCntCountMode()
                'Get counter configuration
                RefreshCntGateSetting()
                'Get counter gate configuration
                RefreshCntStartupValues()
                'Get CNT Startup value

                For i = 0 To listViewChInfo_CNT.Items.Count - 1
                    If listViewChInfo_CNT.Items(i).Selected Then
                        LvChInfoCNT_SelectedIndexChanged(i)
                        Exit For
                    End If
                Next
            Else
                StatusBar_IO.Text = (StatusBar_IO.Text + ("GetModuleConfig(Error:" _
                            + (m_adamCtl.Configuration.ApiLastError.ToString + ") Failed! ")))
            End If
            Return True
        Catch ex As System.Exception
            Return False
        End Try
    End Function

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        Dim strbtnStatus As String = Me.btnStart.Text

        If String.Compare(strbtnStatus, "Start", True) = 0 Then 'Was Stop, Then Start

            If Not StartRemote() Then
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
            If m_adamCtl.Configuration.SYS_SetLocateModule(m_iSlot_ID, 255) Then
                Me.btnLocate.Text = "Disable"
            Else
                MessageBox.Show("Locate module failed!", "Error")
            End If
        ElseIf m_adamCtl.Configuration.SYS_SetLocateModule(m_iSlot_ID, 0) Then
            btnLocate.Text = "Enable"
        Else
            MessageBox.Show("Locate module failed!", "Error")
        End If

    End Sub

    Private Sub Btn_Quit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Quit.Click
        Close()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim bRet As Boolean
        StatusBar_IO.Text = ("Polling (Interval=" _
                    + (Timer1.Interval.ToString + "ms): "))
        bRet = RefreshData()
        If bRet Then
            m_iPollingCount = (m_iPollingCount + 1)
            m_iFailCount = 0
            StatusBar_IO.Text = (StatusBar_IO.Text _
                        + (m_iPollingCount.ToString + " times..."))
        Else
            m_iFailCount = (m_iFailCount + 1)
            StatusBar_IO.Text = (StatusBar_IO.Text _
                        + (m_iFailCount.ToString + " failures..."))
        End If
        If (m_iFailCount > 5) Then
            Timer1.Enabled = False
            StatusBar_IO.Text = (StatusBar_IO.Text + " polling suspended!!")
            MessageBox.Show("Failed more than 5 times! Please check the physical connection!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        End If
        If ((m_iPollingCount Mod 50) _
                    = 0) Then
            GC.Collect()
        End If
    End Sub

    Private Function RefreshData() As Boolean ' Refresh Channel Information "Value" column

        Dim strSelPageName As String = tcRemote.TabPages(tcRemote.SelectedIndex).Text
        Dim i As Integer = 0

        If (strSelPageName = "DI") Then

            Dim bVal() As Boolean = Nothing

            If Not m_adamCtl.DigitalInput.GetValues(Me.m_iSlot_ID, m_iDIChannelNum, bVal) Then
                StatusBar_IO.Text = (StatusBar_IO.Text + ("ApiErr:" + (m_adamCtl.DigitalInput.ApiLastError.ToString + " ")))
                Return False
            End If

            For i = 0 To bVal.Length - 1
                listViewChInfo_DI.Items(i).SubItems(2).Text = bVal(i).ToString 'moduify "Value" column
            Next

        ElseIf (strSelPageName = "DO") Then

            Dim bVal() As Boolean = Nothing 'Refresh Value

            If Not m_adamCtl.DigitalOutput.GetValues(m_iSlot_ID, (m_iDIChannelNum + m_iDOChannelNum), bVal) Then
                StatusBar_IO.Text = (StatusBar_IO.Text + ("ApiErr:" + (m_adamCtl.DigitalOutput.ApiLastError.ToString + " ")))
                Return False
            End If

            For i = 0 To ((bVal.Length - m_iDoOffset) - 1)
                listViewChInfo_DO.Items(i).SubItems(2).Text = bVal((i + m_iDoOffset)).ToString 'moduify "Value" column
            Next

            Dim uiVal As UInteger

            If Not m_adamCtl.Alarm.GetAlarmFlags(m_iSlot_ID, uiVal) Then 'Refresh AlarmFlag
                StatusBar_IO.Text = (StatusBar_IO.Text + ("ApiErr:" + (m_adamCtl.Alarm.ApiLastError.ToString + " ")))
                Return False
            End If

            For i = 0 To m_iDOChannelNum - 1

                If (((uiVal >> i) And 1) > 0) Then
                    listViewChInfo_DO.Items(i).SubItems(6).Text = "True"
                Else
                    listViewChInfo_DO.Items(i).SubItems(6).Text = "False"
                End If

            Next
        ElseIf (strSelPageName = "CNT") Then
            Dim uiVal() As UInteger = Nothing
            Dim aStatus() As Advantech.Adam.Apax5000_ChannelStatus = Nothing

            If Not m_adamCtl.Counter.GetChannelStatus(Me.m_iSlot_ID, m_iCNTChannelNum, aStatus) Then
                StatusBar_IO.Text = (StatusBar_IO.Text + ("ApiErr:" + (m_adamCtl.Counter.ApiLastError.ToString + " ")))
                Return False
            End If
            If Not m_adamCtl.Counter.GetValues(m_iSlot_ID, uiVal) Then
                StatusBar_IO.Text = (StatusBar_IO.Text + ("ApiErr:" _
                            + (m_adamCtl.Counter.ApiLastError.ToString + " ")))
                Return False
            End If
            Dim strVal() As String = New String((uiVal.Length) - 1) {}
            Dim fVals() As Single = New Single((uiVal.Length) - 1) {}
            Dim strStatus() As String = New String((aStatus.Length) - 1) {}

            For i = 0 To Me.m_iCNTChannelNum - 1
                strStatus(i) = aStatus(i).ToString
                Dim o_bStatus As Boolean
                If Not m_adamCtl.Counter.GetGateTriggerStatus(m_iSlot_ID, i, o_bStatus) Then
                    StatusBar_IO.Text = (StatusBar_IO.Text + ("ApiErr:" _
                                + (m_adamCtl.Counter.ApiLastError.ToString + " ")))
                End If
                If o_bStatus Then
                    If (listViewChInfo_CNT.Items(i).SubItems(10).Text.Substring((listViewChInfo_CNT.Items(i).SubItems(10).Text.Length - 3), 3) <> "(*)") Then
                        listViewChInfo_CNT.Items(i).SubItems(10).Text = (listViewChInfo_CNT.Items(i).SubItems(10).Text + "(*)")
                    End If
                ElseIf (listViewChInfo_CNT.Items(i).SubItems(10).Text.Substring((listViewChInfo_CNT.Items(i).SubItems(10).Text.Length - 3), 3) = "(*)") Then
                    listViewChInfo_CNT.Items(i).SubItems(10).Text = listViewChInfo_CNT.Items(i).SubItems(10).Text.Substring(0, (listViewChInfo_CNT.Items(i).SubItems(10).Text.Length - 3))
                End If
                If (Not ((m_usRanges(i) = CType(ApaxUnknown_InputRange.Up, System.UInt16)) _
                            OrElse ((m_usRanges(i) = CType(ApaxUnknown_InputRange.HighFrequency, System.UInt16)) _
                            OrElse ((m_usRanges(i) = CType(ApaxUnknown_InputRange.LowFrequency, System.UInt16)) _
                            OrElse (m_usRanges(i) = CType(ApaxUnknown_InputRange.WaveWidth, System.UInt16))))) _
                            AndAlso ((i Mod 2) _
                            = 1)) Then

                    listViewChInfo_CNT.Items(i).SubItems(2).Text = "*****" 'moduify "Value" column
                    listViewChInfo_CNT.Items(i).SubItems(6).Text = "*****" 'moduify "Status" column
                    Continue For
                ElseIf (m_usRanges(i) = CType(ApaxUnknown_InputRange.HighFrequency, System.UInt16)) Then
                    fVals(i) = (Convert.ToSingle(uiVal(i)) / 10.0!)
                    If Me.IsShowRawData Then
                        strVal(i) = uiVal(i).ToString("X08")
                    Else
                        strVal(i) = fVals(i).ToString("0.0")
                    End If
                ElseIf (m_usRanges(i) = CType(ApaxUnknown_InputRange.LowFrequency, System.UInt16)) Then
                    fVals(i) = (Convert.ToSingle(uiVal(i)) / 10000.0!)
                    If Me.IsShowRawData Then
                        strVal(i) = uiVal(i).ToString("X08")
                    Else
                        strVal(i) = fVals(i).ToString("0.0000")
                    End If
                ElseIf Me.IsShowRawData Then
                    strVal(i) = uiVal(i).ToString("X08")
                Else
                    strVal(i) = uiVal(i).ToString("0.0")
                End If
                listViewChInfo_CNT.Items(i).SubItems(2).Text = strVal(i).ToString 'moduify "Value" column
                listViewChInfo_CNT.Items(i).SubItems(6).Text = strStatus(i).ToString 'moduify "Status" column
            Next
        End If

        Return True

    End Function

    Private Sub tcRemote_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcRemote.SelectedIndexChanged
        Dim strSelPageName As String = tcRemote.TabPages(tcRemote.SelectedIndex).Text
        StatusBar_IO.Text = ""
        If (strSelPageName = "Module Information") Then
            m_iFailCount = 0
            m_iPollingCount = 0
        ElseIf (strSelPageName = "DO") Then
            RefreshDoAlarmSetting()
            If (listViewChInfo_DO.SelectedIndices.Count = 0) Then
                listViewChInfo_DO.Items(0).Selected = True
            End If
        ElseIf (strSelPageName = "CNT") Then
            RefreshRanges()
            'Update Channel information "Mode" column detail
            RefreshCntSetting()
            'Refresh CNT -> Setting -> Digital Filter & FreqAcq. Time
            If (listViewChInfo_CNT.SelectedIndices.Count = 0) Then
                listViewChInfo_CNT.Items(0).Selected = True
            End If
        End If
        If (tcRemote.SelectedIndex = 0) Then
            Timer1.Enabled = False
        Else
            Timer1.Enabled = True
        End If
    End Sub

    Private Sub Form_APAX_5080_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        FreeResource()
    End Sub

    Private Sub chbxHide_DO_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbxHide_DO.CheckStateChanged
        Me.panelDOSetting.Visible = Not chbxHide_DO.Checked
    End Sub

    Private Sub chbxHide_CNT_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbxHide_CNT.CheckStateChanged
        Me.panelCNTSetting.Visible = Not chbxHide_CNT.Checked
    End Sub

    Private Sub chbxGateEnable_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbxGateEnable.CheckStateChanged
        cbxLocalGateMapCh.Enabled = chbxGateEnable.Checked
        cbxGateType.Enabled = chbxGateEnable.Checked
        cbxTriggerMode.Enabled = chbxGateEnable.Checked
    End Sub

    Private Sub rbtnAlarm_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnAlarm.CheckedChanged

        cbxAlarmType.Enabled = rbtnAlarm.Checked
        cbxDOBehavior.Enabled = rbtnAlarm.Checked
        cbxLocalAlarmMapCh.Enabled = rbtnAlarm.Checked
        txtLocalAlarmLimit.Enabled = rbtnAlarm.Checked
        txtDOPulseWidth.Enabled = (rbtnAlarm.Checked AndAlso ((cbxDOBehavior.SelectedIndex = 2) OrElse (cbxDOBehavior.SelectedIndex = 3)))
        chbxAutoRL.Enabled = rbtnAlarm.Checked
        btnAlarmClear.Enabled = rbtnAlarm.Checked
        btnAlarmClearall.Enabled = rbtnAlarm.Checked
        btnTrue.Enabled = Not rbtnAlarm.Checked
        btnFalse.Enabled = Not rbtnAlarm.Checked

    End Sub

    Private Function CheckControllable() As Boolean ' Check module controllable
        Dim active As System.UInt16
        If m_adamCtl.Configuration.SYS_GetGlobalActive(active) Then
            If (active = 1) Then
                Return True
            Else
                MessageBox.Show("There is another controller taking control, so you only can monitor IO data.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
                Return False
            End If
        End If
        MessageBox.Show(("Checking controllable failed, utility only could monitor io data now. (" _
                        + (m_adamCtl.Configuration.ApiLastError.ToString + ")")), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
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
                If m_adamCtl.DigitalOutput.SetValue(m_iSlot_ID, listViewChInfo_DO.SelectedIndices(i), bState) Then
                    RefreshData()
                Else
                    MessageBox.Show("Set digital output failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                End If
                i = (i + 1)
            Loop
        End If
        Timer1.Enabled = True
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

    Private Sub btnApplySetting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApplySetting.Click

        If Not CheckControllable() Then
            Return
        End If

        Dim uiLimitVal As UInteger = 0
        Dim uiPulseWidth As UInteger = 1
        Dim bIsAlarm As Boolean = rbtnAlarm.Checked
        Dim bAutoRL As Boolean = chbxAutoRL.Checked
        Dim iAlarmType As Integer = cbxAlarmType.SelectedIndex
        Dim iMappingCh As Integer = cbxLocalAlarmMapCh.SelectedIndex
        Dim szLimitVal As String = txtLocalAlarmLimit.Text
        Dim iDOBehavior As Integer = cbxDOBehavior.SelectedIndex
        Dim szPulseWidth As String = txtDOPulseWidth.Text
        Dim bApplyAll As Boolean = chbxApplyAll_DO.Checked
        Dim szMode As String
        Timer1.Enabled = False

        'Check even channel alarm mode
        If ((iMappingCh Mod 2) = 1) Then
            szMode = AnalogInput.GetRangeName(m_usRanges(iMappingCh))
            If ((szMode = AnalogInput.GetRangeName(CType(ApaxUnknown_InputRange.Bi_Direction, System.UInt16))) _
                        OrElse ((szMode = AnalogInput.GetRangeName(CType(ApaxUnknown_InputRange.Up_Down, System.UInt16))) _
                        OrElse ((szMode = AnalogInput.GetRangeName(CType(ApaxUnknown_InputRange.AB1X, System.UInt16))) _
                        OrElse ((szMode = AnalogInput.GetRangeName(CType(ApaxUnknown_InputRange.AB2X, System.UInt16))) _
                        OrElse (szMode = AnalogInput.GetRangeName(CType(ApaxUnknown_InputRange.AB4X, System.UInt16))))))) Then
                MessageBox.Show(("For the counter mode '" _
                                + (szMode + "', only even channel can be selected to map an alarm!")), "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
                Timer1.Enabled = True
                Return
            End If
        End If

        'Check alarm mode limit value (0~4294967295)
        Try
            If (szLimitVal.Length = 0) Then
                MessageBox.Show("Please input the alarm limit value between (0~4294967295).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
                Timer1.Enabled = True
                Return
            End If
            uiLimitVal = Convert.ToUInt32(szLimitVal)
        Catch ex As System.Exception
            MessageBox.Show("Please input the alarm limit value between (0~4294967295).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            Timer1.Enabled = True
            Return
        End Try
        'Check alarm mode DO pulse width (1~85899 ms)
        Try
            If (szPulseWidth.Length = 0) Then
                MessageBox.Show("Please input the DO pulse width value between (1~85899 ms).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
                Timer1.Enabled = True
                Return
            End If
            uiPulseWidth = Convert.ToUInt32(szPulseWidth)
            If ((uiPulseWidth = 0) _
                        OrElse (uiPulseWidth > 85899)) Then
                MessageBox.Show("Please input the DO pulse width value between (1~85899 ms).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
                Timer1.Enabled = True
                Return
            End If
        Catch ex As System.Exception
            MessageBox.Show("Please input the DO pulse width value between (1~85899 ms).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            Timer1.Enabled = True
            Return
        End Try
        If ((listViewChInfo_DO.SelectedIndices.Count = 0) _
                    AndAlso Not bApplyAll) Then
            MessageBox.Show("Please select the target channel in the listview!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            Timer1.Enabled = True
            Return
        End If
        If bApplyAll Then
            Dim i As Integer = 0
            Do While (i < listViewChInfo_DO.Items.Count)
                If Not m_adamCtl.Alarm.SetLocalAlarmConfiguration(Me.m_iSlot_ID, i, bIsAlarm, bAutoRL, CType(iAlarmType, Byte), iMappingCh, uiLimitVal, CType(iDOBehavior, Byte), uiPulseWidth) Then
                    MessageBox.Show(("Set alarm" _
                                    + (i.ToString + (" configuration failed! ApiErr:" _
                                    + (m_adamCtl.Alarm.ApiLastError.ToString + "")))), "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
                    Timer1.Enabled = True
                    Return
                End If
                i = (i + 1)
            Loop
            MessageBox.Show("Set alarm configuration done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            RefreshDoAlarmSetting()
            Timer1.Enabled = True
            Return
        Else
            Dim i As Integer = 0
            Do While (i < listViewChInfo_DO.SelectedIndices.Count)
                If Not m_adamCtl.Alarm.SetLocalAlarmConfiguration(Me.m_iSlot_ID, listViewChInfo_DO.SelectedIndices(i), bIsAlarm, bAutoRL, CType(iAlarmType, Byte), iMappingCh, uiLimitVal, CType(iDOBehavior, Byte), uiPulseWidth) Then
                    MessageBox.Show(("Set alarm" _
                                    + (listViewChInfo_DO.SelectedIndices(i).ToString + (" configuration failed! ApiErr:" _
                                    + (m_adamCtl.Alarm.ApiLastError.ToString + "")))), "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
                    Timer1.Enabled = True
                    Return
                End If
                i = (i + 1)
            Loop
            MessageBox.Show("Set gate configuration done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            RefreshDoAlarmSetting()
            Timer1.Enabled = True
            Return
        End If
    End Sub

    Private Sub btnAlarmClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlarmClear.Click
        If Not CheckControllable() Then
            Return
        End If
        Timer1.Enabled = False
        If (listViewChInfo_DO.SelectedIndices.Count = 0) Then
            MessageBox.Show("Please select the target channel in the listview!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            Timer1.Enabled = True
            Return
        End If
        Dim uiMask As UInteger = 0
        Dim i As Integer = 0
        Do While (i < listViewChInfo_DO.SelectedIndices.Count)
            uiMask = (uiMask Or CType((1 << listViewChInfo_DO.SelectedIndices(i)), UInteger))
            i = (i + 1)
        Loop
        If m_adamCtl.Alarm.ClearAlarmFlags(Me.m_iSlot_ID, uiMask) Then
            RefreshData()
        Else
            MessageBox.Show(("Clear alarm flags failed! ApiErr:" _
                            + (m_adamCtl.Alarm.ApiLastError.ToString + "")), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        End If
        Timer1.Enabled = True
    End Sub

    Private Sub btnAlarmClearall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlarmClearall.Click
        If Not CheckControllable() Then
            Return
        End If
        Timer1.Enabled = False
        If (listViewChInfo_DO.SelectedIndices.Count = 0) Then
            MessageBox.Show("Please select the target channel in the listview!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            Timer1.Enabled = True
            Return
        End If
        If m_adamCtl.Alarm.ClearAlarmFlags(Me.m_iSlot_ID, 15) Then
            RefreshData()
        Else
            MessageBox.Show(("Clear alarm flags failed! Err:" _
                            + (m_adamCtl.Alarm.ApiLastError.ToString + "")), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        End If
        Timer1.Enabled = True
    End Sub

    Private Sub LvChInfoDO_SelectedIndexChanged(ByVal idxSel As Integer) ' When user select specific item of channel information(DO), update related information of each channel

        Dim bEnable As Boolean = ((m_usAlarmsConfig(idxSel) And &H4) > 0)
        Dim bAutoRL As Boolean = ((m_usAlarmsConfig(idxSel) And &H40) > 0)
        Dim byAlarmtype As Byte = CType((m_usAlarmsConfig(idxSel) And &H1), Byte)
        Dim iMappingCh As Integer = CType(((m_usAlarmsConfig(idxSel) And &H38) >> 3), Integer)
        Dim uiLimitVal As UInteger = m_uiAlarmLimitValue(idxSel)
        Dim byDOBehavior As Byte = CType((m_usAlarmsConfig(idxSel) / &H100), Byte)
        Dim uiPulseWidth As UInteger = m_uiDOPulseWidth(idxSel)

        rbtnAlarm.Checked = bEnable
        rbtnDO.Checked = Not bEnable
        chbxAutoRL.Checked = bAutoRL
        cbxAlarmType.SelectedIndex = CType(byAlarmtype, Integer)
        cbxLocalAlarmMapCh.SelectedIndex = iMappingCh
        txtLocalAlarmLimit.Text = uiLimitVal.ToString
        cbxDOBehavior.SelectedIndex = CType(byDOBehavior, Integer)
        txtDOPulseWidth.Text = uiPulseWidth.ToString

    End Sub
    Private Sub listViewChInfo_DO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listViewChInfo_DO.SelectedIndexChanged
        Dim i As Integer = 0
        Do While (i < listViewChInfo_DO.Items.Count)
            If listViewChInfo_DO.Items(i).Selected Then
                LvChInfoDO_SelectedIndexChanged(i)
                Exit Do
            End If
            i = (i + 1)
        Loop
    End Sub

    Private Sub btnApplySelRange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApplySelRange.Click
        If Not CheckControllable() Then
            Return
        End If
        Timer1.Enabled = False
        Dim bRet As Boolean = True
        Dim bApplyAll As Boolean = chbxApplyAll_CNT.Checked
        If ((listViewChInfo_CNT.SelectedIndices.Count = 0) _
                    AndAlso bApplyAll) Then
            MessageBox.Show("Please select the target channel in the listview!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            bRet = False
        End If
        If bRet Then
            Dim usRanges() As System.UInt16 = New System.UInt16((m_usRanges.Length) - 1) {}
            Array.Copy(m_usRanges, 0, usRanges, 0, m_usRanges.Length)
            If bApplyAll Then
                Dim i As Integer = 0
                Do While (i < usRanges.Length)
                    usRanges(i) = Counter.GetRangeCode2Byte(cbxRange.SelectedItem.ToString)
                    i = (i + 1)
                Loop
            Else
                Dim i As Integer = 0
                Do While (i < listViewChInfo_CNT.SelectedIndices.Count)
                    Dim neighborIdx As Integer

                    If (listViewChInfo_CNT.SelectedIndices(i) Mod 2 = 0) Then
                        neighborIdx = listViewChInfo_CNT.SelectedIndices(i) + 1
                    Else
                        neighborIdx = listViewChInfo_CNT.SelectedIndices(i) - 1
                    End If
                    usRanges(listViewChInfo_CNT.SelectedIndices(i)) = Counter.GetRangeCode2Byte(cbxRange.SelectedItem.ToString)
                    If ((cbxRange.SelectedIndex = 0) _
                                OrElse ((cbxRange.SelectedIndex = 1) _
                                OrElse ((cbxRange.SelectedIndex = 4) _
                                OrElse ((cbxRange.SelectedIndex = 5) _
                                OrElse (cbxRange.SelectedIndex = 6))))) Then
                        usRanges(neighborIdx) = Counter.GetRangeCode2Byte(cbxRange.SelectedItem.ToString)
                    ElseIf ((usRanges(neighborIdx) <> CType(ApaxUnknown_InputRange.Up, System.UInt16)) _
                                AndAlso ((usRanges(neighborIdx) <> CType(ApaxUnknown_InputRange.HighFrequency, System.UInt16)) _
                                AndAlso ((usRanges(neighborIdx) <> CType(ApaxUnknown_InputRange.LowFrequency, System.UInt16)) _
                                AndAlso (usRanges(neighborIdx) <> CType(ApaxUnknown_InputRange.WaveWidth, System.UInt16))))) Then
                        usRanges(neighborIdx) = Counter.GetRangeCode2Byte(cbxRange.SelectedItem.ToString)
                    End If
                    i = (i + 1)
                Loop
            End If
            Dim iChannelTotal As Integer = Me.m_aConf.HwIoTotal(m_CNTidx)
            If m_adamCtl.Counter.SetModes(Me.m_iSlot_ID, iChannelTotal, usRanges) Then
                MessageBox.Show("Set modes done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
                RefreshRanges()
            Else
                MessageBox.Show(("Set modes failed! ApiErr:" _
                                + (m_adamCtl.Counter.ApiLastError.ToString + "")), "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            End If
        End If
        Timer1.Enabled = True
    End Sub

    Private Sub btnApplyStartup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApplyStartup.Click
        If Not CheckControllable() Then
            Return
        End If
        Timer1.Enabled = False
        Dim uiStartupVal As UInteger = 0
        Dim bRet As Boolean = True
        Try
            uiStartupVal = Convert.ToUInt32(txtStartupVal.Text)
        Catch ex As System.Exception
            MessageBox.Show("Invalid startup value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            Timer1.Enabled = True
            Return
        End Try
        Dim bApplyAll As Boolean = chbxApplyAll_CNT.Checked
        If ((listViewChInfo_CNT.SelectedIndices.Count = 0) _
                    AndAlso Not bApplyAll) Then
            MessageBox.Show("Please select the target channel in the listview!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            Return
        End If
        If bRet Then
            Dim uiVals() As UInteger = New UInteger((m_uiStartupCNT.Length) - 1) {}
            Array.Copy(m_uiStartupCNT, 0, uiVals, 0, m_uiStartupCNT.Length)
            If bApplyAll Then
                Dim i As Integer = 0
                Do While (i < m_uiStartupCNT.Length)
                    uiVals(i) = uiStartupVal
                    i = (i + 1)
                Loop
            Else
                Dim i As Integer = 0
                Do While (i < listViewChInfo_CNT.SelectedIndices.Count)
                    uiVals(listViewChInfo_CNT.SelectedIndices(i)) = uiStartupVal
                    If Not ((m_usRanges(listViewChInfo_CNT.SelectedIndices(i)) = CType(ApaxUnknown_InputRange.Up, System.UInt16)) _
                                OrElse ((m_usRanges(listViewChInfo_CNT.SelectedIndices(i)) = CType(ApaxUnknown_InputRange.HighFrequency, System.UInt16)) _
                                OrElse ((m_usRanges(listViewChInfo_CNT.SelectedIndices(i)) = CType(ApaxUnknown_InputRange.LowFrequency, System.UInt16)) _
                                OrElse (m_usRanges(listViewChInfo_CNT.SelectedIndices(i)) = CType(ApaxUnknown_InputRange.WaveWidth, System.UInt16))))) Then
                        If ((listViewChInfo_CNT.SelectedIndices(i) Mod 2) _
                                    = 0) Then
                            uiVals((listViewChInfo_CNT.SelectedIndices(i) + 1)) = uiStartupVal
                        Else
                            uiVals((listViewChInfo_CNT.SelectedIndices(i) - 1)) = uiStartupVal
                        End If
                    End If
                    i = (i + 1)
                Loop
            End If
            Dim iChannelTotal As Integer = Me.m_aConf.HwIoTotal(m_CNTidx)
            If m_adamCtl.Counter.SetStartupValues(Me.m_iSlot_ID, uiVals) Then
                RefreshCntStartupValues()
            Else
                MessageBox.Show(("Set startup values failed! ApiErr:" _
                                + (m_adamCtl.Counter.ApiLastError.ToString + "")), "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            End If
        End If
        Timer1.Enabled = True
    End Sub

    Private Sub settingCNT_MaskSetting(ByVal bEnable As Boolean, ByVal i_bApplyAll As Boolean)
        If Not CheckControllable() Then
            Return
        End If
        Timer1.Enabled = False
        Dim bRet As Boolean = True
        'bool bApplyAll = chbxApplyAll_CNT.Checked;
        If ((listViewChInfo_CNT.SelectedIndices.Count = 0) AndAlso Not i_bApplyAll) Then
            MessageBox.Show("Please select the target channel in the listview!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            Return
        End If

        If bRet Then
            Dim bChMask() As Boolean = New Boolean((m_bChMask.Length) - 1) {}
            Dim uiMask As UInteger = 0
            Array.Copy(m_bChMask, 0, bChMask, 0, m_bChMask.Length)
            If i_bApplyAll Then
                Dim i As Integer = 0
                Do While (i < bChMask.Length)
                    bChMask(i) = bEnable
                    i = (i + 1)
                Loop
            Else
                Dim i As Integer = 0
                Do While (i < listViewChInfo_CNT.SelectedIndices.Count)
                    bChMask(listViewChInfo_CNT.SelectedIndices(i)) = bEnable
                    If Not ((m_usRanges(listViewChInfo_CNT.SelectedIndices(i)) = CType(ApaxUnknown_InputRange.Up, System.UInt16)) _
                                OrElse ((m_usRanges(listViewChInfo_CNT.SelectedIndices(i)) = CType(ApaxUnknown_InputRange.HighFrequency, System.UInt16)) _
                                OrElse ((m_usRanges(listViewChInfo_CNT.SelectedIndices(i)) = CType(ApaxUnknown_InputRange.LowFrequency, System.UInt16)) _
                                OrElse (m_usRanges(listViewChInfo_CNT.SelectedIndices(i)) = CType(ApaxUnknown_InputRange.WaveWidth, System.UInt16))))) Then
                        If ((listViewChInfo_CNT.SelectedIndices(i) Mod 2) = 0) Then
                            bChMask((listViewChInfo_CNT.SelectedIndices(i) + 1)) = bEnable
                        Else
                            bChMask((listViewChInfo_CNT.SelectedIndices(i) - 1)) = bEnable
                        End If
                    End If
                    i = (i + 1)
                Loop
            End If

            Dim iIdx As Integer = 0
            Do While (iIdx < bChMask.Length)
                If bChMask(iIdx) Then
                    uiMask = (uiMask Or (CType(1, UInteger) << iIdx))
                End If
                iIdx = (iIdx + 1)
            Loop
            If m_adamCtl.Counter.SetChannelEnabled(Me.m_iSlot_ID, uiMask) Then
                RefreshRanges()
            Else
                MessageBox.Show(("Set ChannelEnabled failed! ApiErr:" _
                                + (m_adamCtl.Counter.ApiLastError.ToString + "")), "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            End If
        End If
        Timer1.Enabled = True
    End Sub
    Private Sub bth_CNTStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bth_CNTStart.Click
        settingCNT_MaskSetting(True, chbxApplyAll_CNT.Checked)
    End Sub

    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
        settingCNT_MaskSetting(False, chbxApplyAll_CNT.Checked)
    End Sub

    Private Sub btnResetCnt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetCnt.Click

        If Not CheckControllable() Then
            Return
        End If

        Timer1.Enabled = False
        Dim bRet As Boolean = True
        Dim bApplyAll As Boolean = chbxApplyAll_CNT.Checked
        If ((listViewChInfo_CNT.SelectedIndices.Count = 0) AndAlso Not bApplyAll) Then
            MessageBox.Show("Please select the target channel in the listview!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            Return
        End If
        If bRet Then
            Dim bChMask() As Boolean = New Boolean((m_bChMask.Length) - 1) {}
            Dim uiMask As UInteger = 0
            If bApplyAll Then
                Dim i As Integer = 0
                Do While (i < bChMask.Length)
                    bChMask(i) = True
                    i = (i + 1)
                Loop
            Else

                Dim i As Integer = 0
                Do While (i < listViewChInfo_CNT.SelectedIndices.Count)
                    bChMask(listViewChInfo_CNT.SelectedIndices(i)) = True
                    If Not ((m_usRanges(listViewChInfo_CNT.SelectedIndices(i)) = CType(ApaxUnknown_InputRange.Up, System.UInt16)) _
                                OrElse ((m_usRanges(listViewChInfo_CNT.SelectedIndices(i)) = CType(ApaxUnknown_InputRange.HighFrequency, System.UInt16)) _
                                OrElse ((m_usRanges(listViewChInfo_CNT.SelectedIndices(i)) = CType(ApaxUnknown_InputRange.LowFrequency, System.UInt16)) _
                                OrElse (m_usRanges(listViewChInfo_CNT.SelectedIndices(i)) = CType(ApaxUnknown_InputRange.WaveWidth, System.UInt16))))) Then
                        If ((listViewChInfo_CNT.SelectedIndices(i) Mod 2) = 0) Then
                            bChMask((listViewChInfo_CNT.SelectedIndices(i) + 1)) = True
                        Else
                            bChMask((listViewChInfo_CNT.SelectedIndices(i) - 1)) = True
                        End If
                    End If
                    i = (i + 1)
                Loop
            End If
            Dim iIdx As Integer = 0
            Do While (iIdx < bChMask.Length)
                If bChMask(iIdx) Then
                    uiMask = (uiMask Or (CType(1, UInteger) << iIdx))
                End If
                iIdx = (iIdx + 1)
            Loop
            If Not m_adamCtl.Counter.SetToStartup(Me.m_iSlot_ID, uiMask) Then
                MessageBox.Show(("Reset counter failed! ApiErr:" _
                                + (m_adamCtl.Counter.ApiLastError.ToString + "")), "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            End If
        End If
        Timer1.Enabled = True
    End Sub

    Private Sub btnClearOF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearOF.Click
        If Not CheckControllable() Then
            Return
        End If
        Timer1.Enabled = False
        Dim bRet As Boolean = True
        Dim bApplyAll As Boolean = chbxApplyAll_CNT.Checked
        If ((listViewChInfo_CNT.SelectedIndices.Count = 0) _
                    AndAlso Not bApplyAll) Then
            MessageBox.Show("Please select the target channel in the listview!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            Return
        End If
        If bRet Then

            Dim bChMask() As Boolean = New Boolean((m_bChMask.Length) - 1) {}
            Dim uiMask As UInteger = 0
            If bApplyAll Then
                Dim i As Integer = 0
                Do While (i < bChMask.Length)
                    bChMask(i) = True
                    i = (i + 1)
                Loop

            Else
                Dim i As Integer = 0
                Do While (i < listViewChInfo_CNT.SelectedIndices.Count)
                    bChMask(listViewChInfo_CNT.SelectedIndices(i)) = True
                    If Not ((m_usRanges(listViewChInfo_CNT.SelectedIndices(i)) = CType(ApaxUnknown_InputRange.Up, System.UInt16)) _
                                OrElse ((m_usRanges(listViewChInfo_CNT.SelectedIndices(i)) = CType(ApaxUnknown_InputRange.HighFrequency, System.UInt16)) _
                                OrElse ((m_usRanges(listViewChInfo_CNT.SelectedIndices(i)) = CType(ApaxUnknown_InputRange.LowFrequency, System.UInt16)) _
                                OrElse (m_usRanges(listViewChInfo_CNT.SelectedIndices(i)) = CType(ApaxUnknown_InputRange.WaveWidth, System.UInt16))))) Then
                        If ((listViewChInfo_CNT.SelectedIndices(i) Mod 2) = 0) Then
                            bChMask((listViewChInfo_CNT.SelectedIndices(i) + 1)) = True
                        Else
                            bChMask((listViewChInfo_CNT.SelectedIndices(i) - 1)) = True
                        End If
                    End If
                    i = (i + 1)
                Loop
            End If
            Dim iIdx As Integer = 0
            Do While (iIdx < bChMask.Length)
                If bChMask(iIdx) Then
                    uiMask = (uiMask Or (CType(1, UInteger) << iIdx))
                End If
                iIdx = (iIdx + 1)
            Loop
            If Not m_adamCtl.Counter.ClearOverflows(Me.m_iSlot_ID, uiMask) Then
                MessageBox.Show(("Clear counter overflow flag failed! ApiErr:" + (m_adamCtl.Counter.ApiLastError.ToString + "")), "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            End If
        End If
        Timer1.Enabled = True

    End Sub

    Private Sub btnApplyCountType_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApplyCountType.Click
        If Not CheckControllable() Then
            Return
        End If
        Dim bRet As Boolean = True
        Timer1.Enabled = False
        Dim bApplyAll As Boolean = chbxApplyAll_CNT.Checked
        If ((listViewChInfo_CNT.SelectedIndices.Count = 0) _
                    AndAlso Not bApplyAll) Then
            MessageBox.Show("Please select the target channel in the listview!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            Return
        End If
        If bRet Then
            If bApplyAll Then
                Dim i As Integer = 0
                Do While (i < listViewChInfo_CNT.Items.Count)
                    If Not m_adamCtl.Counter.SetCntTypeConfiguration(m_iSlot_ID, i, chbxRepeat.Checked, chbxReloadToStartup.Checked) Then
                        MessageBox.Show(("Set count type" _
                                        + (i.ToString + (" configuration failed! ApiErr:" _
                                        + (m_adamCtl.Counter.ApiLastError.ToString + "")))), "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
                        Timer1.Enabled = True
                        Return
                    End If
                    i = (i + 1)
                Loop
                RefreshCntCountMode()
                Timer1.Enabled = True
                Return
            Else
                Dim i As Integer = 0
                Do While (i < listViewChInfo_CNT.SelectedIndices.Count)
                    If Not m_adamCtl.Counter.SetCntTypeConfiguration(Me.m_iSlot_ID, listViewChInfo_CNT.SelectedIndices(i), chbxRepeat.Checked, chbxReloadToStartup.Checked) Then
                        MessageBox.Show(("Set count type" _
                                        + (listViewChInfo_CNT.SelectedIndices(i).ToString + (" configuration failed! ApiErr:" _
                                        + (m_adamCtl.Counter.ApiLastError.ToString + "")))), "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
                        Timer1.Enabled = True
                        Return
                    End If
                    If Not ((m_usRanges(listViewChInfo_CNT.SelectedIndices(i)) = CType(ApaxUnknown_InputRange.Up, System.UInt16)) _
                                OrElse ((m_usRanges(listViewChInfo_CNT.SelectedIndices(i)) = CType(ApaxUnknown_InputRange.HighFrequency, System.UInt16)) _
                                OrElse ((m_usRanges(listViewChInfo_CNT.SelectedIndices(i)) = CType(ApaxUnknown_InputRange.LowFrequency, System.UInt16)) _
                                OrElse (m_usRanges(listViewChInfo_CNT.SelectedIndices(i)) = CType(ApaxUnknown_InputRange.WaveWidth, System.UInt16))))) Then
                        Dim neighborIdx As Integer

                        If ((listViewChInfo_CNT.SelectedIndices(i) Mod 2) = 0) Then
                            neighborIdx = listViewChInfo_CNT.SelectedIndices(i) + 1
                        Else
                            neighborIdx = listViewChInfo_CNT.SelectedIndices(i) - 1
                        End If

                        If Not m_adamCtl.Counter.SetCntTypeConfiguration(m_iSlot_ID, neighborIdx, chbxRepeat.Checked, chbxReloadToStartup.Checked) Then
                            MessageBox.Show(("Set count type" _
                                            + (listViewChInfo_CNT.SelectedIndices(i).ToString + (" configuration failed! ApiErr:" _
                                            + (m_adamCtl.Counter.ApiLastError.ToString + "")))), "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
                            Timer1.Enabled = True
                            Return
                        End If
                    End If
                    i = (i + 1)
                Loop
                MessageBox.Show("Set count type configuration done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
                RefreshCntCountMode()
                Timer1.Enabled = True
                Return
            End If
        End If
    End Sub

    Private Sub btnClrTriger_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClrTriger.Click
        Try
            Dim uiInput() As UInteger = New UInteger((5) - 1) {}
            If chbxApplyAll_CNT.Checked Then
                uiInput(0) = &HFF
            Else
                Dim i As Integer = 0
                Do While (i < listViewChInfo_CNT.SelectedIndices.Count)
                    uiInput(0) = (uiInput(0) Or CType((1 << listViewChInfo_CNT.SelectedIndices(i)), UInteger))
                    i = (i + 1)
                Loop
            End If
            m_adamCtl.Configuration.TOOL_SetCmdWriteReadRet(Me.m_iSlot_ID, &H78, uiInput)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnApplyGateSetting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApplyGateSetting.Click
        If Not CheckControllable() Then
            Return
        End If
        Dim bRet As Boolean = True
        Timer1.Enabled = False
        Dim bApplyAll As Boolean = chbxApplyAll_CNT.Checked
        If ((listViewChInfo_CNT.SelectedIndices.Count = 0) _
                    AndAlso Not bApplyAll) Then
            MessageBox.Show("Please select the target channel in the listview!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            Return
        End If
        If bRet Then
            If bApplyAll Then
                Dim i As Integer = 0
                Do While (i < listViewChInfo_CNT.Items.Count)
                    If Not m_adamCtl.Counter.SetLocalGateConfiguration(Me.m_iSlot_ID, i, chbxGateEnable.Checked, CType(cbxTriggerMode.SelectedIndex, Byte), CType(cbxGateType.SelectedIndex, Byte), cbxLocalGateMapCh.SelectedIndex) Then
                        MessageBox.Show(("Set gate" _
                                        + (i.ToString + (" configuration failed! ApiErr:" _
                                        + (m_adamCtl.Counter.ApiLastError.ToString + "")))), "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
                        Timer1.Enabled = True
                        Return
                    End If
                    i = (i + 1)
                Loop
                RefreshCntGateSetting()
                Timer1.Enabled = True
                Return
            Else
                Dim i As Integer = 0
                Do While (i < listViewChInfo_CNT.SelectedIndices.Count)
                    If Not m_adamCtl.Counter.SetLocalGateConfiguration(Me.m_iSlot_ID, listViewChInfo_CNT.SelectedIndices(i), chbxGateEnable.Checked, CType(cbxTriggerMode.SelectedIndex, Byte), CType(cbxGateType.SelectedIndex, Byte), cbxLocalGateMapCh.SelectedIndex) Then
                        MessageBox.Show(("Set gate" _
                                        + (listViewChInfo_CNT.SelectedIndices(i).ToString + (" configuration failed! ApiErr:" _
                                        + (m_adamCtl.Counter.ApiLastError.ToString + "")))), "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
                        Timer1.Enabled = True
                        Return
                    End If
                    If Not ((m_usRanges(listViewChInfo_CNT.SelectedIndices(i)) = CType(ApaxUnknown_InputRange.Up, System.UInt16)) _
                                OrElse ((m_usRanges(listViewChInfo_CNT.SelectedIndices(i)) = CType(ApaxUnknown_InputRange.HighFrequency, System.UInt16)) _
                                OrElse ((m_usRanges(listViewChInfo_CNT.SelectedIndices(i)) = CType(ApaxUnknown_InputRange.LowFrequency, System.UInt16)) _
                                OrElse (m_usRanges(listViewChInfo_CNT.SelectedIndices(i)) = CType(ApaxUnknown_InputRange.WaveWidth, System.UInt16))))) Then
                        Dim neighborIdx As Integer

                        If ((listViewChInfo_CNT.SelectedIndices(i) Mod 2) = 0) Then
                            neighborIdx = listViewChInfo_CNT.SelectedIndices(i) + 1
                        Else
                            neighborIdx = listViewChInfo_CNT.SelectedIndices(i) - 1
                        End If

                        If Not m_adamCtl.Counter.SetLocalGateConfiguration(Me.m_iSlot_ID, neighborIdx, chbxGateEnable.Checked, CType(cbxTriggerMode.SelectedIndex, Byte), CType(cbxGateType.SelectedIndex, Byte), cbxLocalGateMapCh.SelectedIndex) Then
                            MessageBox.Show(("Set gate" _
                                            + (listViewChInfo_CNT.SelectedIndices(i).ToString + (" configuration failed! ApiErr:" _
                                            + (m_adamCtl.Counter.ApiLastError.ToString + "")))), "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
                            Timer1.Enabled = True
                            Return
                        End If
                    End If
                    i = (i + 1)
                Loop
                RefreshCntGateSetting()
                Timer1.Enabled = True
                Return
            End If
        End If
    End Sub

    Private Sub listViewChInfo_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles listViewChInfo_DO.ItemActivate ' Double click channel to change value
        If Not CheckControllable() Then
            Return
        End If
        Dim strVal As String = listViewChInfo_DO.Items(listViewChInfo_DO.SelectedIndices(0)).SubItems(2).Text
        Dim bVal As Boolean = False
        If (strVal = "True") Then
            bVal = False
        Else
            bVal = True
        End If
        settingDO_SetTF(bVal)
    End Sub

    Private Sub btnApplyFilter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApplyFilter.Click
        If Not CheckControllable() Then
            Return
        End If
        Try
            If (txtFilter.Text.Length = 0) Then
                MessageBox.Show("Please input the CNT Digital filter value between (0~40000 us).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
                Return
            End If
            Dim Filter As Double = Convert.ToDouble(txtFilter.Text)
            Dim iFilter As Integer = CType((Filter * 10), Int32)
            Dim bRet As Boolean
            If (iFilter > 400000) Then
                MessageBox.Show("Please input the Digital filter value between (0~40000 us).", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
                Return
            Else
                bRet = m_adamCtl.Counter.SetDigitalFilter(Me.m_iSlot_ID, iFilter)
                If bRet Then
                    If (iFilter = 0) Then
                        MessageBox.Show("Digital filter disable", "Information")
                    Else
                        Dim fFilter As Single
                        fFilter = CType((10000000 / iFilter), Single)
                        MessageBox.Show(("Digital filter frequency: " _
                                        + (fFilter.ToString + " Hz")), "Information")
                        RefreshCntSetting()
                    End If
                Else
                    MessageBox.Show(("Set digital filter failed! ApiErr:" _
                                    + (m_adamCtl.Counter.ApiLastError.ToString + "")), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                End If
                Return
            End If
        Catch ex As System.Exception
            MessageBox.Show("Invalid digital filter value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        End Try

    End Sub

    Private Sub btnFreqAcqTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFreqAcqTime.Click
        If Not CheckControllable() Then
            Return
        End If
        Try
            Dim iFreqAcqTime As Integer = Convert.ToInt32(txtFreqAcqTime.Text)
            If ((iFreqAcqTime < 1) _
                        OrElse (iFreqAcqTime > 10000)) Then
                MessageBox.Show("Invalid frequency acquisition time value! (1~10000)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                Return
            End If
            Dim bRet As Boolean = m_adamCtl.Counter.SetFreqAcqTime(Me.m_iSlot_ID, iFreqAcqTime)
            If bRet Then
                RefreshCntSetting()
            Else
                MessageBox.Show(("Set frequency acquisition time failed! ApiErr:" _
                                + (m_adamCtl.Counter.ApiLastError.ToString + "")), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            End If
        Catch ex As System.Exception
            MessageBox.Show("Invalid frequency acquisition time value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub cbxDOBehavior_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxDOBehavior.SelectedIndexChanged
        If rbtnAlarm.Checked Then
            If ((cbxDOBehavior.SelectedIndex = 2) OrElse (cbxDOBehavior.SelectedIndex = 3)) Then
                txtDOPulseWidth.Enabled = True
            Else
                txtDOPulseWidth.Enabled = False
            End If
        End If
    End Sub

    Private Sub cbxLocalAlarmMapCh_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxLocalAlarmMapCh.SelectedIndexChanged
        Dim idx As Integer = cbxLocalAlarmMapCh.SelectedIndex
        If ((m_usRanges(idx) = CType(ApaxUnknown_InputRange.HighFrequency, System.UInt16)) _
                    OrElse (m_usRanges(idx) = CType(ApaxUnknown_InputRange.LowFrequency, System.UInt16))) Then
            labHz.Visible = True
        Else
            labHz.Visible = False
        End If
        txtMappingChannel.Text = AnalogInput.GetRangeName(m_usRanges(idx))
        If rbtnAlarm.Checked Then
            If ((cbxDOBehavior.SelectedIndex = 2) _
                        OrElse (cbxDOBehavior.SelectedIndex = 3)) Then
                txtDOPulseWidth.Enabled = True
            Else
                txtDOPulseWidth.Enabled = False
            End If
        End If

    End Sub

    Private Sub listViewChInfo_CNT_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listViewChInfo_CNT.SelectedIndexChanged
        Dim i As Integer = 0
        Do While (i < listViewChInfo_CNT.Items.Count)
            If listViewChInfo_CNT.Items(i).Selected Then
                LvChInfoCNT_SelectedIndexChanged(i)
                Exit Do
            End If
            i = (i + 1)
        Loop
    End Sub
End Class
