Imports Advantech.Adam
Imports Advantech.Common
Imports System.Data
Imports System.Threading


Public Class FORM_APAX_5046SO

    'Global

    Dim APAX_INFO_NAME As String = "APAX"
    Public Const DVICE_TYPE = "5046SO"

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
    Dim m_bIsEnableSafetyFcn As Boolean
    Dim m_bDOSafetyVals() As Boolean

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
        m_ScanTime_LocalSys(0) = ScanTime 'Scan time default 500 ms
        Timer1.Interval = m_ScanTime_LocalSys(0)
        Me.StatusBar_IO.Text = "Start to demo " + APAX_INFO_NAME + "-" + DVICE_TYPE + " by clicking 'Start' button."

    End Sub
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
                If (String.Compare(m_szSlots(iLoop), 0, DVICE_TYPE, 0, DVICE_TYPE.Length) = 0 And m_szSlots(iLoop).Length = 6) Then
                    iDeviceNum = iDeviceNum + 1
                    If iDeviceNum = 1 Then 'Record first find device
                        m_iSlot_ID = iLoop 'Get DVICE_TYPE Solt
                    End If
                End If
            Next

        Else

            If (String.Compare(m_szSlots(m_iSlot_ID), 0, DVICE_TYPE, 0, DVICE_TYPE.Length) = 0 And m_szSlots(m_iSlot_ID).Length = 6) Then
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
        Else
            Me.StatusBar_IO.Text = (" GetModuleConfig(Error:" _
                        + (m_adamCtl.Configuration.ApiLastError.ToString + ") Failed! "))
            Return False
        End If


        Return True

    End Function

    Public Sub InitialRemotePanelComponents()

        Dim iLoop As Integer
        Dim lvItem As ListViewItem

        listViewChInfo.Items.Clear()
        listViewChInfo.BeginUpdate()

        For iLoop = 0 To Me.m_iDOChannelNum - 1
            lvItem = New ListViewItem(_HardwareIOType.DO.ToString)
            'Type
            lvItem.SubItems.Add(iLoop.ToString)
            'Ch
            lvItem.SubItems.Add("*****")
            'Value
            lvItem.SubItems.Add("BOOL")
            'Mode
            lvItem.SubItems.Add("*****")
            'Safety Value
            listViewChInfo.Items.Add(lvItem)
        Next

        listViewChInfo.EndUpdate()

    End Sub

    Public Function GetChannelInfo() As Boolean

        Dim iLoop As Integer

        For iLoop = 0 To m_aConf.HwIoType.Length - 1

            If (m_aConf.HwIoType(iLoop) = _HardwareIOType.DO) Then
                m_iDOChannelNum = m_aConf.HwIoTotal(iLoop)
            ElseIf (m_aConf.HwIoType(iLoop) = _HardwareIOType.DI) Then
                m_iDIChannelNum = m_aConf.HwIoTotal(iLoop)
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

    ''' Refresh Modules's Safety column value
    Private Sub RefreshSafetySetting()

        Dim i As Integer = 0

        If Not m_adamCtl.Configuration.OUT_GetSafetyEnable(Me.m_iSlot_ID, m_bIsEnableSafetyFcn) Then
            StatusBar_IO.Text = (StatusBar_IO.Text + ("OUT_GetSafetyEnable(Error:" _
                        + (m_adamCtl.Configuration.ApiLastError.ToString + ") Failed! ")))
        End If

        If m_bIsEnableSafetyFcn Then

            Dim o_bValues() As Boolean = Nothing
            Dim strSafetyValue() As String = Nothing

            Me.chbxEnableSafety.Checked = True

            If m_adamCtl.DigitalOutput.GetSafetyValues(m_iSlot_ID, Me.m_iDOChannelNum, o_bValues) Then

                m_bDOSafetyVals = o_bValues
                strSafetyValue = New String((m_iDOChannelNum) - 1) {}
                For i = 0 To m_iDOChannelNum - 1
                    listViewChInfo.Items(i).SubItems(4).Text = m_bDOSafetyVals(i).ToString
                Next
                'moduify "Safety" column
            Else
                Me.StatusBar_IO.Text = (StatusBar_IO.Text + ("GetSafetyValues(Error:" _
                            + (m_adamCtl.DigitalOutput.ApiLastError.ToString + ") Failed! ")))
            End If
        Else
            For i = 0 To m_iDOChannelNum - 1
                listViewChInfo.Items(i).SubItems(4).Text = "Disable"
            Next
            'moduify "Safety" column
        End If

    End Sub

    Private Sub tcRemote_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcRemote.SelectedIndexChanged

        Dim strSelPageName As String = tcRemote.TabPages(tcRemote.SelectedIndex).Text
        Me.StatusBar_IO.Text = ""

        If (strSelPageName = "Module Information") Then

            Timer1.Enabled = False
            m_iFailCount = 0
            Me.m_iPollingCount = 0
        ElseIf (strSelPageName = "DO") Then
            'Refresh safety information
            Timer1.Enabled = True
        End If

    End Sub
    ''' <summary>
    ''' Refresh DO Channel Information "Value" column
    ''' </summary>
    ''' <returns></returns>
    Private Function RefreshData() As Boolean

        Dim bVal() As Boolean = Nothing
        Dim i As Integer

        If Not m_adamCtl.DigitalOutput.GetValues(Me.m_iSlot_ID, Me.m_iDOChannelNum, bVal) Then
            Me.StatusBar_IO.Text = (StatusBar_IO.Text + ("ApiErr:" _
                        + (m_adamCtl.DigitalOutput.ApiLastError.ToString + " ")))
            Return False
        End If

        For i = 0 To bVal.Length - 1
            If listViewChInfo.Items(i).SubItems(2).Text <> bVal(i).ToString Then
                listViewChInfo.Items(i).SubItems(2).Text = bVal(i).ToString
                'moduify "Value" column
            End If
        Next

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
        Me.panelConfig.Visible = Not chbxHide.Checked
    End Sub

    Private Sub chbxEnableSafety_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbxEnableSafety.CheckStateChanged
        btnSetSafetyValue.Enabled = chbxEnableSafety.Checked
        If Not CheckControllable() Then
            Return
        End If
        If Not m_adamCtl.Configuration.OUT_SetSafetyEnable(m_iSlot_ID, chbxEnableSafety.Checked) Then
            MessageBox.Show(("Set safety function failed! (Err: " _
                            + (m_adamCtl.Configuration.ApiLastError.ToString + ")")), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        End If
        RefreshSafetySetting()
    End Sub
    ''' Double click channel to change value
    Private Sub listViewChInfo_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles listViewChInfo.ItemActivate
        If Not CheckControllable() Then
            Return
        End If
        Dim strVal As String = listViewChInfo.Items(listViewChInfo.SelectedIndices(0)).SubItems(2).Text
        Dim bVal As Boolean = False
        If (strVal = "True") Then
            bVal = False
        Else
            bVal = True
        End If
        settingDO_SetTF(bVal)
    End Sub
    ''' <summary>
    ''' Check module controllable
    ''' </summary>
    ''' <returns></returns>
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
    ''' <summary>
    ''' Set selected channels status to true or false
    ''' </summary>
    ''' <param name="bState">channel status</param>
    Private Sub settingDO_SetTF(ByVal bState As Boolean)
        If Not CheckControllable() Then
            Return
        End If
        Timer1.Enabled = False
        If (listViewChInfo.SelectedIndices.Count = 0) Then
            MessageBox.Show("Please select the target channel in the listview!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            Timer1.Enabled = True
            Return
        Else
            Dim i As Integer = 0
            Do While (i < listViewChInfo.SelectedIndices.Count)
                If m_adamCtl.DigitalOutput.SetValue(m_iSlot_ID, listViewChInfo.SelectedIndices(i), bState) Then
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
    ''' <summary>
    '''  Apply setting when user configure safety status
    ''' </summary>
    ''' <param name="bVal"></param>
    Private Sub formSafety_ApplySafetyValueClick(ByVal bVal() As Boolean)
        If Not m_adamCtl.DigitalOutput.SetSafetyValues(m_iSlot_ID, bVal) Then
            MessageBox.Show(("Set safety value failed! (Err: " _
                            + (m_adamCtl.DigitalOutput.ApiLastError.ToString + ")")), "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
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

    Private Sub APAX_5046SO_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        FreeResource()
    End Sub
End Class