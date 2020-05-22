Imports Advantech.Adam
Imports Advantech.Common
Imports Apax_IO_Module_Library
Imports System.Threading


Public Class Form_APAX_5013

    Private ReadOnly MAX_CHANNEL = "24"

    Public APAX_INFO_NAME As String = "APAX"
    Public Const DVICE_TYPE = "5013"

    Dim m_adamCtl As AdamControl 'Control Handle
    Dim m_aConf As Apax5000Config 'Configuration information
    Dim m_iSlot_ID As Integer 'Device switch ID
    Dim m_ScanTime_LocalSys() As Integer
    Dim m_szSlots() As String 'Container of all solt device type
    Dim m_usOutVal(), m_usInVal() As System.UInt16 'Container of AIO raw data
    Dim m_bStartFlag As Boolean = False
    Dim m_aStatus() As Advantech.Adam.Apax5000_ChannelStatus

    Dim m_iPollingCount As Integer 'Polling device status count
    Dim m_iFailCount As Integer 'Device Polling fail count
    Dim m_iAIChannelNum As Integer 'Device AI Channel number
    Dim m_iAOChannelNum As Integer 'Device AO Channel number
    Dim m_iDIChannelNum As Integer 'Device DI Channel number
    Dim m_iDOChannelNum As Integer 'Device DO Channel number

    Dim m_bChMask() As Boolean = New Boolean((AdamControl.APAX_MaxAIOCh) - 1) {}
    Dim m_uiChMask As UInteger = 0
    Dim m_uiBurnoutVal As UInteger = 0
    Dim m_uiBurnoutMask As UInteger = 0
    Dim m_usRanges() As System.UInt16

    Public Sub New()
        MyBase.New()

        InitializeComponent()
        m_szSlots = Nothing
        m_iPollingCount = 0
        m_iFailCount = 0
        m_iSlot_ID = -1 'Set Slot_ID in invalid num 
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
        m_ScanTime_LocalSys(0) = ScanTime
        Timer1.Interval = m_ScanTime_LocalSys(0)
        Me.StatusBar_IO.Text = "Start to demo " + APAX_INFO_NAME + "-" + DVICE_TYPE + " by clicking 'Start' button."

    End Sub

    Private Sub ShowWaitMsg()

        Dim FormWait = New Wait_Form
        FormWait.Start_Wait(500)
        FormWait.ShowDialog()

    End Sub

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

    Public Function StartRemote()

        Dim waitThread As Thread = New Thread(AddressOf ShowWaitMsg)
        waitThread.IsBackground = False
        waitThread.Start()

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
            'Information-> Module
            Me.txtModuleID.Text = (APAX_INFO_NAME + ("-" + m_aConf.GetModuleName))
            'Information -> Switch ID
            Me.txtSWID.Text = m_iSlot_ID.ToString
            'Information -> Support kernel Fw
            Me.txtSupportKernelFw.Text = m_aConf.wSupportFwVer.ToString("X04").Insert(2, ".")
            'Firmware version
            Me.txtFwVer.Text = m_aConf.wFwVerNo.ToString("X04").Insert(2, ".")
            'AI Firmware version
            Me.txtAIOFwVer.Text = m_aConf.wHwVer.ToString("X04").Insert(2, ".")
        Else
            Me.StatusBar_IO.Text = (" GetModuleConfig(Error:" _
                        + (m_adamCtl.Configuration.ApiLastError.ToString + ") Failed! "))
            Return False
        End If

        m_usRanges = m_aConf.wChRange
        m_uiChMask = m_aConf.dwChMask

        For i = 0 To Me.m_bChMask.Length - 1
            m_bChMask(i) = ((m_uiChMask And (&H1 << i)) > 0)
        Next

        Return True

    End Function

    Public Sub SetRangeComboBox(ByVal strRanges() As String)

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

    ''' Get Burnout detect mode value combobox string
    Public Sub SetBurnoutFcnValueComboBox(ByVal strRanges() As String)

        cbxBurnoutValue.BeginUpdate()
        cbxBurnoutValue.Items.Clear()

        Dim i As Integer = 0

        Do While (i < strRanges.Length)
            cbxBurnoutValue.Items.Add(strRanges(i))
            i = (i + 1)
        Loop

        If (cbxBurnoutValue.Items.Count > 0) Then
            cbxBurnoutValue.SelectedIndex = 0
        End If

        cbxBurnoutValue.EndUpdate()

    End Sub

    Public Sub SetIntegrationComboBox(ByVal strIntegration() As String) ' Get Integration time combobox string

        Dim iLoop As Integer = 0
        cbxIntegration.BeginUpdate()
        cbxIntegration.Items.Clear()

        For i = 0 To strIntegration.Length - 1
            cbxIntegration.Items.Add(strIntegration(i))
        Next

        If (cbxIntegration.Items.Count > 0) Then
            cbxIntegration.SelectedIndex = 0
        End If

        cbxIntegration.EndUpdate()

    End Sub

    Public Sub InitialRemotePanelComponents()

        Dim iLoop, iSiezOfRange, iIndex As Integer
        Dim lvItem As ListViewItem
        Dim strRanges() As String
        Dim m_usRanges_supAI() As System.UInt16

        For iLoop = 0 To m_aConf.HwIoType.Length - 1
            If (m_aConf.HwIoType(iLoop) = _HardwareIOType.AI) Then
                iIndex = iLoop
            End If
        Next

        'init range combobox
        If (iIndex = 0) Then
            m_usRanges_supAI = m_aConf.wHwIoType_0_Range
        ElseIf (iIndex = 1) Then
            m_usRanges_supAI = m_aConf.wHwIoType_1_Range
        ElseIf (iIndex = 2) Then
            m_usRanges_supAI = m_aConf.wHwIoType_2_Range
        ElseIf (iIndex = 3) Then
            m_usRanges_supAI = m_aConf.wHwIoType_3_Range
        Else
            m_usRanges_supAI = m_aConf.wHwIoType_4_Range
        End If

        iSiezOfRange = (m_aConf.HwIoType_TotalRange(iIndex)) 'Get AI Total type range number
        strRanges = New String(iSiezOfRange - 1) {}

        For iLoop = 0 To iSiezOfRange - 1
            strRanges(iLoop) = AnalogInput.GetRangeName(m_usRanges_supAI(iLoop))
        Next

        SetRangeComboBox(strRanges)
        SetBurnoutFcnValueComboBox(New String() {"Down Scale", "Up Scale"})
        SetIntegrationComboBox(New String() {AnalogInput.GetIntegrationName(AdamType.Apax5000, CType(Apax_Integration.Hz60_50ms, Byte)), AnalogInput.GetIntegrationName(AdamType.Apax5000, CType(Apax_Integration.Hz50_60ms, Byte))})
        listViewChInfo.Items.Clear()
        listViewChInfo.BeginUpdate()

        For iLoop = 0 To m_iAIChannelNum - 1
            lvItem = New ListViewItem(_HardwareIOType.AI.ToString)
            'type
            lvItem.SubItems.Add(iLoop.ToString)
            'Ch
            lvItem.SubItems.Add("*****")
            'Value
            lvItem.SubItems.Add("*****")
            'Ch Status 
            lvItem.SubItems.Add("*****")
            'Range
            listViewChInfo().Items.Add(lvItem)
        Next

        listViewChInfo.EndUpdate()

    End Sub

    ''' Check module controllable
    Private Function CheckControllable() As Boolean
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

    Public Function GetChannelInfo() As Boolean

        Dim iLoop As Integer

        For iLoop = 0 To m_aConf.HwIoType.Length - 1
            If (m_aConf.HwIoType(iLoop) = _HardwareIOType.AI) Then
                m_iAIChannelNum = m_aConf.HwIoTotal(iLoop)
            ElseIf (m_aConf.HwIoType(iLoop) = _HardwareIOType.DO) Then
                m_iDOChannelNum = m_aConf.HwIoTotal(iLoop)
            ElseIf (m_aConf.HwIoType(iLoop) = _HardwareIOType.DI) Then
                m_iDIChannelNum = m_aConf.HwIoTotal(iLoop)
            ElseIf (m_aConf.HwIoType(iLoop) = _HardwareIOType.AO) Then
                m_iDIChannelNum = m_aConf.HwIoTotal(iLoop)
            End If
        Next

        Return True

    End Function

    ''' Refresh AI Burnout detect mode settings
    Private Function RefreshBurnoutSetting(ByVal bUpdateBurnFun As Boolean, ByVal bUpdateBurnVal As Boolean) As Boolean

        Try
            Dim bRet As Boolean = False
            Dim o_dwEnableMask As UInteger
            Dim o_dwValue As UInteger
            Dim waitThread As Thread = New Thread(AddressOf ShowWaitMsg)

            waitThread.IsBackground = False
            waitThread.Start()

            If bUpdateBurnFun Then
                If Not m_adamCtl.AnalogInput.GetBurnoutFunEnable(m_iSlot_ID, o_dwEnableMask) Then
                    bRet = False
                Else
                    bRet = True
                    m_uiBurnoutMask = o_dwEnableMask
                End If
                System.Threading.Thread.Sleep(1000)
            End If
            If bUpdateBurnVal Then
                If Not m_adamCtl.AnalogInput.GetBurnoutValue(m_iSlot_ID, o_dwValue) Then
                    bRet = False
                Else
                    bRet = True
                    m_uiBurnoutVal = o_dwValue
                    If (m_uiBurnoutVal = 0) Then
                        cbxBurnoutValue.SelectedIndex = 0
                    Else
                        cbxBurnoutValue.SelectedIndex = 1
                    End If
                End If
            End If
            Return bRet
        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Function GetChannelRangeIdx(ByVal o_szRangeName As String) As Integer
        Dim i As Integer = 0

        Do While (i < cbxRange.Items.Count)
            If (cbxRange.Items(i).ToString = o_szRangeName) Then
                Return i
            End If
            i = (i + 1)
        Loop

        Return -1

    End Function

    ''' When user select specific item of channel information, you should update channel range
    Private Sub LvChInfo_SelectedIndexChanged(ByVal idxSel As Integer)

        Me.cbxRange.SelectedIndex = GetChannelRangeIdx(AnalogInput.GetRangeName(m_usRanges(idxSel)))
        Me.btnMaskEnable.Enabled = True
        Me.btnMaskDisable.Enabled = True

        If (((m_usRanges(idxSel) <= CType(ApaxUnknown_InputRange.Btype_200To1820C, System.UInt16)) _
                    AndAlso (m_usRanges(idxSel) >= CType(ApaxUnknown_InputRange.Jtype_Neg210To1200C, System.UInt16))) _
                    OrElse ((m_usRanges(idxSel) <= CType(ApaxUnknown_InputRange.Ni518_0To100, System.UInt16)) _
                    AndAlso (m_usRanges(idxSel) >= CType(ApaxUnknown_InputRange.Pt100_3851_Neg200To850, System.UInt16)))) Then
            Me.chkBurnoutFcn.Enabled = True
            Me.btnBurnoutFcn.Enabled = True
        Else
            Me.chkBurnoutFcn.Enabled = False
            Me.btnBurnoutFcn.Enabled = False
        End If

        'refresh burnout mask
        If (((m_uiBurnoutMask >> idxSel) And &H1) > 0) Then
            chkBurnoutFcn.Checked = True
        Else
            chkBurnoutFcn.Checked = False
        End If

    End Sub
    Private Sub Btn_Quit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btn_Quit.Click
        Close()
    End Sub

    Private Sub btnLocate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLocate.Click
        If (btnLocate.Text = "Enable") Then
            If m_adamCtl.Configuration.SYS_SetLocateModule(m_iSlot_ID, 255) Then
                btnLocate.Text = "Disable"
            Else
                MessageBox.Show("Locate module failed!", "Error")
            End If
        ElseIf m_adamCtl.Configuration.SYS_SetLocateModule(m_iSlot_ID, 0) Then
            btnLocate.Text = "Enable"
        Else
            MessageBox.Show("Locate module failed!", "Error")
        End If

    End Sub

    Private Sub btnApplySelRange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApplySelRange.Click
        If Not CheckControllable() Then
            Return
        End If
        Timer1.Enabled = False
        Dim bRet As Boolean = True
        If ((listViewChInfo.SelectedIndices.Count = 0) _
                    AndAlso Not chkApplyAll.Checked) Then
            MessageBox.Show("Please select the target channel in the listview!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            bRet = False
        End If
        If bRet Then
            Dim usRanges() As System.UInt16 = New System.UInt16((m_usRanges.Length) - 1) {}
            Dim i As Integer = 0
            Array.Copy(m_usRanges, 0, usRanges, 0, m_usRanges.Length)

            If chkApplyAll.Checked Then

                For i = 0 To usRanges.Length - 1
                    usRanges(i) = AnalogInput.GetRangeCode2Byte(cbxRange.SelectedItem.ToString)
                Next
            Else
                For i = 0 To listViewChInfo.SelectedIndices.Count - 1
                    usRanges(listViewChInfo.SelectedIndices(i)) = AnalogInput.GetRangeCode2Byte(cbxRange.SelectedItem.ToString)
                Next
            End If

            If m_adamCtl.AnalogInput.SetRanges(Me.m_iSlot_ID, Me.m_iAIChannelNum, usRanges) Then
                RefreshRanges()
            Else
                MessageBox.Show("Set ranges failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            End If

        End If
        Timer1.Enabled = True

    End Sub

    Private Sub btnMaskEnable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMaskEnable.Click
        If Not CheckControllable() Then
            Return
        End If
        settingAI_MaskSetting(True, chkApplyAll.Checked)
    End Sub

    Private Sub btnMaskDisable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMaskDisable.Click
        If Not CheckControllable() Then
            Return
        End If
        settingAI_MaskSetting(False, chkApplyAll.Checked)
    End Sub

    ''' Enable/Disable Channel mask function
    Private Sub settingAI_MaskSetting(ByVal bEnable As Boolean, ByVal i_bApplyAll As Boolean)
        Dim i As Integer = 0
        Dim bRet As Boolean = True

        If Not CheckControllable() Then
            Return
        End If
        Timer1.Enabled = False


        If ((listViewChInfo.SelectedIndices.Count = 0) AndAlso Not i_bApplyAll) Then
            MessageBox.Show("Please select the target channel in the listview!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            bRet = False
        End If

        If bRet Then
            Dim bChMask() As Boolean = New Boolean((m_bChMask.Length) - 1) {}
            Dim uiMask As UInteger = 0
            Array.Copy(m_bChMask, 0, bChMask, 0, m_bChMask.Length)

            If i_bApplyAll Then

                For i = 0 To bChMask.Length - 1
                    bChMask(i) = bEnable
                Next
            Else

                For i = 0 To listViewChInfo.SelectedIndices.Count - 1
                    bChMask(listViewChInfo.SelectedIndices(i)) = bEnable
                Next
            End If

            For i = 0 To bChMask.Length - 1
                If bChMask(i) Then
                    uiMask = (uiMask Or ((CType(1, UInteger) << i)))
                End If
            Next

            If uiMask = 0 Then ' Can't disable all channel
                MessageBox.Show("Cannot diable all channel!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            Else
                If m_adamCtl.AnalogInput.SetChannelEnabled(Me.m_iSlot_ID, uiMask) Then
                    RefreshRanges()
                Else
                    MessageBox.Show("Set ChannelEnabled failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
                End If
            End If

        End If
        Timer1.Enabled = True
    End Sub

    ''' Get Channel information "Range" column
    Private Function RefreshRanges() As Boolean

        Dim i As Integer = 0
        Try
            If m_adamCtl.Configuration.GetModuleConfig(m_iSlot_ID, m_aConf) Then
                m_usRanges = m_aConf.wChRange
                m_uiChMask = m_aConf.dwChMask

                For i = 0 To Me.m_bChMask.Length - 1
                    m_bChMask(i) = ((m_uiChMask And (1 << i)) > 0)
                Next
                listViewChInfo.BeginUpdate()
                For i = 0 To m_iAIChannelNum - 1
                    listViewChInfo.Items(i).SubItems(4).Text = AnalogInput.GetRangeName(m_usRanges(i)).ToString
                Next
                listViewChInfo.EndUpdate()
            Else
                StatusBar_IO.Text = (StatusBar_IO.Text + ("GetModuleConfig(Error:" _
                            + (m_adamCtl.Configuration.ApiLastError.ToString + ") Failed! ")))
            End If

            Return True

        Catch ex As Exception
            Return False
        End Try

    End Function
    Private Sub btnIntegration_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIntegration.Click
        If Not CheckControllable() Then
            Return
        End If
        Timer1.Enabled = False
        Dim uiVal As UInteger = CType(AnalogInput.GetIntegrationCode(AdamType.Apax5000, cbxIntegration.SelectedIndex), UInteger)
        If m_adamCtl.AnalogInput.SetIntegration(m_iSlot_ID, uiVal) Then
            MessageBox.Show("Set integration time done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            RefreshAiSetting()
        Else
            MessageBox.Show("Set integration time failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
        End If
        Timer1.Enabled = True
    End Sub

    Private Sub btnBurnoutValue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBurnoutValue.Click
        Dim uiVal As UInteger
        If (cbxBurnoutValue.SelectedIndex = 0) Then
            uiVal = 0
        Else
            uiVal = 65535
        End If
        If Not CheckControllable() Then
            Return
        End If
        Timer1.Enabled = False
        If m_adamCtl.AnalogInput.SetBurnoutValue(Me.m_iSlot_ID, uiVal) Then
            MessageBox.Show("Set burnout value done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            RefreshBurnoutSetting(False, True)
            'refresh burnout detect mode
        Else
            MessageBox.Show("Set burnout value failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
        End If
        Timer1.Enabled = True
    End Sub

    Private Sub cbSetPanelHide_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSetPanelHide.CheckStateChanged
        panel1.Visible = Not cbSetPanelHide.Checked
    End Sub

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

    Public Function ReadChannelStatus() As Boolean

        m_usInVal = Nothing
        m_aStatus = Nothing

        If (Me.m_uiChMask <> 0) Then

            If Not Me.m_adamCtl.AnalogInput.GetChannelStatus(Me.m_iSlot_ID, Me.m_iAIChannelNum, m_aStatus) Then
                Me.StatusBar_IO.Text = (StatusBar_IO.Text + ("[GetChannelStatus] ApiErr:" _
                            + (m_adamCtl.AnalogInput.ApiLastError.ToString + " ")))
                Return False
            End If

            If Not m_adamCtl.AnalogInput.GetValues(Me.m_iSlot_ID, Me.m_iAIChannelNum, m_usInVal) Then
                StatusBar_IO.Text = (StatusBar_IO.Text + ("[GetValues] ApiErr:" _
                            + (m_adamCtl.AnalogInput.ApiLastError.ToString + " ")))
                Return False
            End If

            Return True

        End If

        Return False

    End Function
    Public Function Update_AI_UIStatus() As Boolean

        Dim strVal() As String = New String((Me.m_iAIChannelNum) - 1) {}
        Dim strStatus() As String = New String((Me.m_iAIChannelNum) - 1) {}
        Dim dVals() As Double = New Double((Me.m_iAIChannelNum) - 1) {}
        Dim i As Integer
        Dim bHasTCRange As Boolean = False

        listViewChInfo.BeginUpdate()

        If m_usInVal.Length > 0 Then

            For i = 0 To Me.m_iAIChannelNum - 1
                If (m_aConf.wPktVer >= 2) Then
                    dVals(i) = AnalogInput.GetScaledValueWithResolution(Me.m_usRanges(i), m_usInVal(i), m_aConf.wHwIoType_0_Resolution)
                ElseIf (m_aConf.GetModuleName = "5017H") Then
                    dVals(i) = AnalogInput.GetScaledValueWithResolution(Me.m_usRanges(i), m_usInVal(i), 12)
                Else
                    dVals(i) = AnalogInput.GetScaledValue(Me.m_usRanges(i), m_usInVal(i))
                End If

                If ((m_usRanges(i) >= &H400) AndAlso (m_usRanges(i) < &H500)) Then
                    bHasTCRange = True
                End If

                If m_bChMask(i) Then
                    If cbRawData.Checked Then
                        strVal(i) = m_usInVal(i).ToString("X04")
                    Else
                        strVal(i) = dVals(i).ToString(AnalogInput.GetFloatFormat(Me.m_usRanges(i)))
                    End If
                    strStatus(i) = m_aStatus(i).ToString
                Else
                    strVal(i) = "*****"
                    strStatus(i) = "Disable"
                End If

                If listViewChInfo.Items(i).SubItems(2).Text <> strVal(i).ToString Then
                    listViewChInfo.Items(i).SubItems(2).Text = strVal(i).ToString 'moduify "Value" column
                End If

                If listViewChInfo.Items(i).SubItems(3).Text <> strStatus(i).ToString Then
                    listViewChInfo.Items(i).SubItems(3).Text = strStatus(i).ToString 'modify "Ch Status" column
                End If

            Next

            If (bHasTCRange AndAlso (((Me.m_iPollingCount * Timer1.Interval) Mod 5000) >= 0) AndAlso (((Me.m_iPollingCount * Timer1.Interval) Mod 5000) < 1)) Then
                Dim fCJCVal As Single
                Dim o_Status As Apax5000_ChannelStatus
                If m_adamCtl.AnalogInput.GetCJCValue(m_iSlot_ID, fCJCVal, o_Status) Then
                    If (o_Status = Apax5000_ChannelStatus.CJCTempError) Then
                        Timer1.Enabled = False
                        MessageBox.Show("The CJC temperature sensor failed!" + vbLf + "Please check device is install correctly.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
                        StatusBar_IO.Text = (StatusBar_IO.Text + "The CJC temperature sensor failed! Please check device is install correctly.")
                    End If
                End If
            End If
        Else
            For i = 0 To Me.m_iAIChannelNum - 1
                listViewChInfo.Items(i).SubItems(2).Text = "******"
                'moduify "Value" column
                listViewChInfo.Items(i).SubItems(3).Text = "******"
                'modify "Ch Status" column
            Next
        End If

        listViewChInfo.EndUpdate()

    End Function

    Public Function RefreshData() As Boolean

        If Not ReadChannelStatus() Then
            Return False
        End If
        Update_AI_UIStatus()

        Return True
    End Function

    Private Sub tcRemote_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcRemote.SelectedIndexChanged
        Dim strSelPageName As String = tcRemote.TabPages(tcRemote.SelectedIndex).Text

        Me.StatusBar_IO.Text = ""
        If (strSelPageName = "Module Information") Then

            Timer1.Enabled = False
            m_iFailCount = 0
            Me.m_iPollingCount = 0

        ElseIf (strSelPageName = "AI") Then

            Dim waitThread As Thread = New Thread(AddressOf ShowWaitMsg)
            waitThread.IsBackground = False
            waitThread.Start()

            RefreshRanges()
            RefreshAiSetting()
            RefreshBurnoutSetting(True, True) 'refresh burnout mask value and get burnout detect mode
            Timer1.Enabled = True
        End If
    End Sub

    ''' Refresh Integration time 
    Private Sub RefreshAiSetting()

        If m_adamCtl.Configuration.GetModuleConfig(Me.m_iSlot_ID, m_aConf) Then
            Dim idx As Integer
            Dim uiFcnParam As UInteger

            'Check if support SampleRate
            If (Me.m_aConf.byFunType_0 = CType(_FunctionType.Filter, Byte)) Then
                uiFcnParam = m_aConf.dwFunParam_0
            ElseIf (Me.m_aConf.byFunType_1 = CType(_FunctionType.Filter, Byte)) Then
                uiFcnParam = m_aConf.dwFunParam_1
            ElseIf (Me.m_aConf.byFunType_2 = CType(_FunctionType.Filter, Byte)) Then
                uiFcnParam = m_aConf.dwFunParam_2
            ElseIf (Me.m_aConf.byFunType_3 = CType(_FunctionType.Filter, Byte)) Then
                uiFcnParam = m_aConf.dwFunParam_3
            ElseIf (Me.m_aConf.byFunType_4 = CType(_FunctionType.Filter, Byte)) Then
                uiFcnParam = m_aConf.dwFunParam_4
            Else
                Return
            End If

            idx = AnalogInput.GetIntegrationIndex(AdamType.Apax5000, CType(uiFcnParam, Byte))
            If (idx > (cbxIntegration.Items.Count - 1)) Then
                cbxIntegration.SelectedIndex = -1
            Else
                cbxIntegration.SelectedIndex = idx
            End If
        Else
            StatusBar_IO.Text = (StatusBar_IO.Text + ("GetModuleConfig(Error:" _
                        + (m_adamCtl.Configuration.ApiLastError.ToString + ") Failed! ")))
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim bRet As Boolean
        Me.StatusBar_IO.Text = ("Polling (Interval=" _
                    + (Timer1.Interval.ToString + "ms): "))
        bRet = RefreshData()
        If bRet Then
            Me.m_iPollingCount = (m_iPollingCount + 1)
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

    Private Sub Form_APAX_5013_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        FreeResource()
    End Sub

    Private Sub chkBurnoutFcn_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkBurnoutFcn.CheckStateChanged

    End Sub


    Private Sub listViewChInfo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listViewChInfo.SelectedIndexChanged
        Dim iLoop As Integer
        listViewChInfo.BeginUpdate()
        For iLoop = 0 To listViewChInfo.Items.Count - 1
            If listViewChInfo.Items(iLoop).Selected Then
                LvChInfo_SelectedIndexChanged(iLoop)
                Exit For
            End If
        Next
        listViewChInfo.EndUpdate()
    End Sub

    Private Sub btnBurnoutFcn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBurnoutFcn.Click
        If Not CheckControllable() Then
            Return
        End If
        Timer1.Enabled = False
        If chkApplyAll.Checked Then

            If chkBurnoutFcn.Checked Then
                m_uiBurnoutMask = (CType((1 << Me.m_iAIChannelNum), UInteger) - 1)
            Else
                m_uiBurnoutMask = 0
            End If
        Else

            Dim idx As Integer = 0
            Dim iLoop As Integer = 0
            For iLoop = 0 To listViewChInfo.Items.Count - 1
                If listViewChInfo.Items(iLoop).Selected Then
                    idx = iLoop
                    Exit For
                End If
            Next

            Dim uiMask As UInteger = CType((1 << idx), UInteger)

            If chkBurnoutFcn.Checked Then
                m_uiBurnoutMask = (m_uiBurnoutMask Or uiMask)
            Else
                m_uiBurnoutMask = m_uiBurnoutMask And (Not (uiMask))
            End If

        End If
        If m_adamCtl.AnalogInput.SetBurnoutFunEnable(Me.m_iSlot_ID, m_uiBurnoutMask) Then
            MessageBox.Show("Set burnout enable function done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            RefreshBurnoutSetting(True, False)
            'refresh burnout mask value
        Else
            MessageBox.Show("Set burnout enable function failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
        End If
        Timer1.Enabled = True
    End Sub
End Class
