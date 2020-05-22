Imports Advantech.Adam
Imports Advantech.Common
Imports System.Data
Imports System.Threading

Public Class Form_APAX_5028
    'Global
    Dim APAX_INFO_NAME As String = "APAX"
    Public Const DVICE_TYPE = "5028"

    Dim m_adamCtl As AdamControl 'Control Handle
    Dim m_aConf As Apax5000Config 'Configuration information
    Dim m_iSlot_ID As Integer 'Device switch ID
    Dim m_ScanTime_LocalSys() As Integer
    Dim m_szSlots() As String 'Container of all solt device type
    Dim bOutVal(), bInVal() As Boolean 'Container of DIO Status
    Dim m_bStartFlag As Boolean = False

    Dim m_iPollingCount As Integer 'Polling device status count
    Dim m_iFailCount As Integer 'Device Polling fail count
    Dim m_iAOChannelNum As Integer 'Device DI Channel number
    Dim m_tmpidx As Integer

    Dim m_bIsEnableSafetyFcn As Boolean
    Dim m_usAOSafetyVals() As System.UInt16
    Dim m_usRanges_supAO() As System.UInt16
    Dim m_usRanges() As System.UInt16
    Dim m_usStartupAO() As System.UInt16
    Dim m_fHigh As Single
    Dim m_fLow As Single
    Dim b_AOValueModified As Boolean
    Dim m_iSelChannels As Integer

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

        m_usRanges = m_aConf.wChRange

        Return True

    End Function

    Public Sub InitialRemotePanelComponents()

        Dim strRanges() As String
        Dim lvItem As ListViewItem
        Dim i As Integer
        strRanges = New String(Me.m_aConf.HwIoType_TotalRange(m_tmpidx) - 1) {} 'init range combobox

        For i = 0 To strRanges.Length - 1
            strRanges(i) = AnalogOutput.GetRangeName(m_usRanges_supAO(i))
        Next

        SetRangeComboBox(strRanges)
        listViewChInfo.Items.Clear()
        listViewChInfo.BeginUpdate()

        For i = 0 To Me.m_iAOChannelNum - 1

            lvItem = New ListViewItem(_HardwareIOType.AO.ToString) 'Type
            lvItem.SubItems.Add(i.ToString) 'Ch
            lvItem.SubItems.Add("*****") 'Value
            lvItem.SubItems.Add("*****") 'Range
            lvItem.SubItems.Add("*****") 'Start up
            lvItem.SubItems.Add("*****") 'Safety Value
            listViewChInfo.Items.Add(lvItem)

        Next

        listViewChInfo.EndUpdate()

    End Sub

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

    Public Function GetChannelInfo() As Boolean

        Dim iLoop As Integer

        For iLoop = 0 To m_aConf.HwIoType.Length - 1

            If (m_aConf.HwIoType(iLoop) = _HardwareIOType.AO) Then
                m_iAOChannelNum = m_aConf.HwIoTotal(iLoop)
                m_tmpidx = iLoop

                If (iLoop = 0) Then
                    m_usRanges_supAO = m_aConf.wHwIoType_0_Range
                ElseIf (iLoop = 1) Then
                    m_usRanges_supAO = m_aConf.wHwIoType_1_Range
                ElseIf (iLoop = 2) Then
                    m_usRanges_supAO = m_aConf.wHwIoType_2_Range
                ElseIf (iLoop = 3) Then
                    m_usRanges_supAO = m_aConf.wHwIoType_3_Range
                Else
                    m_usRanges_supAO = m_aConf.wHwIoType_4_Range
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

    Private Function RefreshRanges() As Boolean ' Get Channel information "Range" column
        Try
            Dim iChannelTotal As Integer = Me.m_aConf.HwIoTotal(m_tmpidx)
            If m_adamCtl.Configuration.GetModuleConfig(Me.m_iSlot_ID, m_aConf) Then
                m_usRanges = m_aConf.wChRange
                ' Update Range column
                Dim i As Integer = 0
                Do While (i < iChannelTotal)
                    listViewChInfo.Items(i).SubItems(3).Text = AnalogOutput.GetRangeName(m_usRanges(i)).ToString
                    i = (i + 1)
                Loop
            Else
                StatusBar_IO.Text = (StatusBar_IO.Text + ("GetModuleConfig(Error:" _
                            + (m_adamCtl.Configuration.ApiLastError.ToString + ") Failed! ")))
            End If
            Return True
        Catch ex As System.Exception
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Refresh start up value
    ''' </summary>
    ''' <returns></returns>
    Private Function RefreshAoStartupValues() As Boolean
        Try
            Dim strVals() As String
            Dim iChannelTotal As Integer = Me.m_aConf.HwIoTotal(m_tmpidx)
            If m_adamCtl.AnalogOutput.GetStartupValues(m_iSlot_ID, iChannelTotal, m_usStartupAO) Then
                strVals = New String((iChannelTotal) - 1) {}
                Dim i As Integer = 0
                Do While (i < m_usStartupAO.Length)
                    strVals(i) = AnalogOutput.GetScaledValue(Me.m_usRanges(i), m_usStartupAO(i)).ToString("0.000;-0.000")
                    listViewChInfo.Items(i).SubItems(4).Text = strVals(i)
                    i = (i + 1)
                Loop
            Else
                StatusBar_IO.Text = (StatusBar_IO.Text + "GetStartupValues() Failed! ")
            End If
            Return True
        Catch ex As System.Exception
            Return False
        End Try
    End Function

    Private Sub RefreshSafetySetting() ' Refresh Modules's Safety column value

        Dim i As Integer

        If Not m_adamCtl.Configuration.OUT_GetSafetyEnable(m_iSlot_ID, m_bIsEnableSafetyFcn) Then
            StatusBar_IO.Text = (StatusBar_IO.Text + ("OUT_GetSafetyEnable(Error:" _
                        + (m_adamCtl.Configuration.ApiLastError.ToString + ") Failed! ")))
        End If

        If m_bIsEnableSafetyFcn Then
            Dim o_usValues() As System.UInt16 = Nothing
            Dim strSafetyValue() As String = Nothing

            If m_adamCtl.AnalogOutput.GetSafetyValues(Me.m_iSlot_ID, Me.m_iAOChannelNum, o_usValues) Then
                m_usAOSafetyVals = o_usValues
                strSafetyValue = New String((m_iAOChannelNum) - 1) {}

                For i = 0 To m_iAOChannelNum - 1
                    listViewChInfo.Items(i).SubItems(5).Text = AnalogOutput.GetScaledValue(Me.m_usRanges(i), m_usAOSafetyVals(i)).ToString("0.000;-0.000")
                Next
                'moduify "Safety" column
            Else
                StatusBar_IO.Text = (StatusBar_IO.Text + ("GetSafetyValues(Error:" _
                            + (m_adamCtl.DigitalOutput.ApiLastError.ToString + ") Failed! ")))
            End If
        Else
            For i = 0 To m_iAOChannelNum - 1
                listViewChInfo.Items(i).SubItems(5).Text = "Disable"
            Next
            'moduify "Safety" column
        End If

    End Sub

    Private Sub tcRemote_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcRemote.SelectedIndexChanged

        Dim strSelPageName As String = tcRemote.TabPages(tcRemote.SelectedIndex).Text
        Dim idx As Integer
        Dim fHigh As Single = 0
        Dim fLow As Single = 0
        Dim fVal As Single = 0
        Dim usVal As System.UInt16
        Dim i As Integer = 0

        StatusBar_IO.Text = ""
        If (strSelPageName = "Module Information") Then
            m_iFailCount = 0
            m_iPollingCount = 0
        ElseIf (strSelPageName = "AO") Then
            RefreshRanges()
            RefreshAoStartupValues()
            RefreshSafetySetting()
            chbxEnableSafety.Checked = m_bIsEnableSafetyFcn
            'Set AO info
            idx = 0
            'initial index
            If m_adamCtl.AnalogOutput.GetCurrentValue(m_iAOChannelNum, idx, usVal) Then
                AnalogOutput.GetRangeHighLow(m_usRanges(idx), fHigh, fLow)
                fVal = AnalogOutput.GetScaledValue(m_usRanges(idx), usVal)
                RefreshOutputPanel(fHigh, fLow, fVal)
            Else
                Me.StatusBar_IO.Text = (Me.StatusBar_IO.Text + "GetValues() filed!")
            End If
            'synchronize channel status 

            For i = 0 To listViewChInfo.Items.Count - 1

                If (i = idx) Then
                    listViewChInfo.Items(i).Selected = True
                Else
                    listViewChInfo.Items(i).Selected = False
                End If
            Next
            Dim szTemp As String = AnalogOutput.GetRangeName(m_usRanges(idx))

            For i = 0 To cbxRange.Items.Count - 1
                If (szTemp = cbxRange.Items(i).ToString) Then
                    cbxRange.SelectedIndex = i
                    Exit For
                End If
            Next
        End If
        If (tcRemote.SelectedIndex = 0) Then
            Me.Timer1.Enabled = False
        Else
            Me.Timer1.Enabled = True
        End If

    End Sub

    Public Sub RefreshOutputPanel(ByVal fHigh As Single, ByVal fLow As Single, ByVal fOutputVal As Single) ' Set UI of txtValue and TrackBarValue

        m_fHigh = fHigh
        m_fLow = fLow
        labHigh.Text = m_fHigh.ToString
        labLow.Text = m_fLow.ToString
        txtOutputVal.Text = fOutputVal.ToString("0.000")
        tBarOutputVal.Value = Convert.ToInt32((tBarOutputVal.Minimum + ((tBarOutputVal.Maximum - tBarOutputVal.Minimum) * ((fOutputVal - fLow) / (fHigh - fLow)))))

    End Sub

    Private Function RefreshData() As Boolean

        Dim usVal() As System.UInt16 = Nothing
        Dim strVal() As String = Nothing
        Dim fLow As Single = 0
        Dim fHigh As Single = 0
        Dim i As Integer = 0

        If Not m_adamCtl.AnalogOutput.GetValues(m_iSlot_ID, m_iAOChannelNum, usVal) Then
            StatusBar_IO.Text = (StatusBar_IO.Text + ("ApiErr:" _
                        + (m_adamCtl.AnalogOutput.ApiLastError.ToString + " ")))
            Return False
        End If

        strVal = New String((usVal.Length) - 1) {}

        For i = 0 To m_iAOChannelNum - 1

            If Me.IsShowRawData Then
                strVal(i) = usVal(i).ToString("X04")
            Else
                strVal(i) = AnalogOutput.GetScaledValue(Me.m_usRanges(i), usVal(i)).ToString(AnalogOutput.GetFloatFormat(Me.m_usRanges(i)))
            End If

            If listViewChInfo.Items(i).SubItems(2).Text <> strVal(i).ToString Then
                listViewChInfo.Items(i).SubItems(2).Text = strVal(i).ToString 'moduify "Value" column
            End If

        Next


        If Not b_AOValueModified Then 'Update tBarOutputVal

            Dim idx As Integer = 0

            For i = 0 To listViewChInfo.Items.Count - 1

                If listViewChInfo.Items(i).Selected Then
                    idx = i
                End If

            Next

            AnalogOutput.GetRangeHighLow(m_usRanges(idx), fHigh, fLow)
            RefreshOutputPanel(fHigh, fLow, AnalogOutput.GetScaledValue(Me.m_usRanges(idx), usVal(idx)))

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
        Me.Panel1.Visible = Not chbxHide.Checked
    End Sub


    Private Function CheckControllable() As Boolean 'Check module controllable
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


    Private Sub Form_APAX_5028_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        FreeResource()
    End Sub


    Private Sub listViewChInfo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listViewChInfo.SelectedIndexChanged

        Dim idx As Integer = 0
        'Update txtSelChannel UI
        Dim i As Integer = 0
        Do While (i < listViewChInfo.Items.Count)
            If listViewChInfo.Items(i).Selected Then
                idx = i
            End If
            i = (i + 1)
        Loop
        txtSelChannel.Text = idx.ToString
        m_iSelChannels = idx
        b_AOValueModified = False

    End Sub

    Private Sub formSafety_ApplySafetyValueClick(ByVal szVal() As String) '  Apply setting when user configure safety status

        Dim fLow As Single
        Dim fVal As Single
        Dim fHigh As Single
        Dim usAOSafetyVals() As System.UInt16 = New System.UInt16((m_usAOSafetyVals.Length) - 1) {}
        Dim i As Integer = 0
        Do While (i < m_iAOChannelNum)
            fVal = 0.0!
            If ((Not (szVal(i)) Is Nothing) _
                        AndAlso (szVal(i).Length > 0)) Then
                Try
                    fVal = Convert.ToSingle(szVal(i))
                Catch ex As System.Exception
                    System.Windows.Forms.MessageBox.Show(("Invalid value: " + szVal(i)))
                End Try
            End If
            AnalogOutput.GetRangeHighLow(m_usRanges(i), fHigh, fLow)
            If ((fHigh - fLow) _
                        = 0) Then
                MessageBox.Show("GetRangeHighLow() failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
                Return
            End If
            If ((fVal > fHigh) _
                        OrElse (fVal < fLow)) Then
                MessageBox.Show(("Channel " _
                                + (i.ToString + (" is illegal value! Please enter the value " _
                                + (fLow.ToString + (" ~ " _
                                + (fHigh.ToString + ".")))))), "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
                Return
            End If
            usAOSafetyVals(i) = Convert.ToUInt16((65535.0! _
                            * ((fVal - fLow) _
                            / (fHigh - fLow))))
            i = (i + 1)
        Loop
        If Not m_adamCtl.AnalogOutput.SetSafetyValues(Me.m_iSlot_ID, Me.m_iAOChannelNum, usAOSafetyVals) Then
            MessageBox.Show(("Set safety value failed! (Err: " _
                            + (m_adamCtl.AnalogOutput.ApiLastError.ToString + ")")), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        End If
        RefreshSafetySetting()
    End Sub

    Private Sub chbxEnableSafety_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbxEnableSafety.CheckStateChanged
        btnSetSafetyValue.Enabled = chbxEnableSafety.Checked
        btnSetAsSafety.Enabled = chbxEnableSafety.Checked
        If Not CheckControllable() Then
            Return
        End If
        If Not m_adamCtl.Configuration.OUT_SetSafetyEnable(Me.m_iSlot_ID, chbxEnableSafety.Checked) Then
            MessageBox.Show(("Set safety function failed! (Err: " _
                            + (m_adamCtl.Configuration.ApiLastError.ToString + ")")), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
        End If
        RefreshSafetySetting()
    End Sub

    Private Sub btnApplyOutput_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApplyOutput.Click
        b_AOValueModified = False

        If Not CheckControllable() Then
            Return
        End If
        Timer1.Enabled = False
        Dim fLow, fVal, fHigh As Single
        If (txtOutputVal.Text.Length = 0) Then
            MessageBox.Show("Illegal value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            Return
        End If
        Try
            'Get range higf & low
            AnalogOutput.GetRangeHighLow(m_usRanges(m_iSelChannels), fHigh, fLow)
            If ((fHigh - fLow) _
                        = 0) Then
                MessageBox.Show("GetRangeHighLow() failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
                Return
            End If
            'convert output value to float
            fVal = 0.0!
            If ((Not (txtOutputVal.Text) Is Nothing) _
                        AndAlso (txtOutputVal.Text.Length > 0)) Then
                Try
                    fVal = Convert.ToSingle(txtOutputVal.Text)
                Catch ex As System.Exception
                    System.Windows.Forms.MessageBox.Show(("Invalid value: " + txtOutputVal.Text))
                End Try
            End If
            If ((fVal > fHigh) _
                        OrElse (fVal < fLow)) Then
                MessageBox.Show(("Illegal value! Please enter the value " _
                                + (fLow.ToString + (" ~ " _
                                + (fHigh.ToString + ".")))), "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
                Return
            End If
            'Set channel value
            If Me.m_adamCtl.AnalogOutput.SetCurrentValue(Me.m_iSlot_ID, m_iSelChannels, m_usRanges(m_iSelChannels), fVal) Then
                RefreshOutputPanel(fHigh, fLow, fVal)
            Else
                MessageBox.Show("Change current value failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
                Return
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
            Return
        End Try
        RefreshData()
        MessageBox.Show("Set output value done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
        Timer1.Enabled = True
    End Sub

    Private Sub btnApplySelRange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApplySelRange.Click
        Dim result As DialogResult
        If Not CheckControllable() Then
            Return
        End If
        Timer1.Enabled = False
        result = MessageBox.Show("After changing range setting, you need to configure proper start-up value again!", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
        If (result = DialogResult.Yes) Then
            Dim bRet As Boolean = True
            Dim i_bApplyAll As Boolean = chbxApplyAll.Checked
            If ((listViewChInfo.SelectedIndices.Count = 0) _
                        AndAlso Not i_bApplyAll) Then
                MessageBox.Show("Please select the target channel in the listview!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
                bRet = False
            End If
            If bRet Then
                Dim usRanges() As System.UInt16 = New System.UInt16((m_usRanges.Length) - 1) {}
                Array.Copy(m_usRanges, 0, usRanges, 0, m_usRanges.Length)
                If i_bApplyAll Then
                    Dim i As Integer = 0
                    Do While (i < usRanges.Length)
                        usRanges(i) = AnalogOutput.GetRangeCode2Byte(cbxRange.SelectedItem.ToString)
                        i = (i + 1)
                    Loop
                Else
                    Dim i As Integer = 0
                    Do While (i < listViewChInfo.SelectedIndices.Count)
                        usRanges(listViewChInfo.SelectedIndices(i)) = AnalogOutput.GetRangeCode2Byte(cbxRange.SelectedItem.ToString)
                        i = (i + 1)
                    Loop
                End If
                If m_adamCtl.AnalogOutput.SetRanges(Me.m_iSlot_ID, m_iAOChannelNum, usRanges) Then
                    MessageBox.Show("Set ranges done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
                    RefreshRanges()
                    RefreshAoStartupValues()
                Else
                    MessageBox.Show("Set ranges failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
                End If
            End If
        End If
        Timer1.Enabled = True
    End Sub

    Private Sub btnSetSafetyValue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetSafetyValue.Click
        If Not CheckControllable() Then
            Return
        End If
        Timer1.Enabled = False
        Dim iChannelTotal As Integer = Me.m_aConf.HwIoTotal(m_tmpidx)
        Dim fAOSafetyVals() As Single = New Single((iChannelTotal) - 1) {}
        Dim i As Integer = 0
        Do While (i < iChannelTotal)
            fAOSafetyVals(i) = AnalogOutput.GetScaledValue(m_usRanges(i), m_usAOSafetyVals(i))
            i = (i + 1)
        Loop
        Dim szRanges() As String = New String((iChannelTotal) - 1) {}
        Dim idx As Integer = 0
        Do While (idx < szRanges.Length)
            szRanges(idx) = AnalogInput.GetRangeName(m_usRanges(idx))
            idx = (idx + 1)
        Loop

        Dim formSafety As FormSafetySetting = New FormSafetySetting(iChannelTotal, fAOSafetyVals, szRanges)
        AddHandler formSafety.ApplySafetyValueClick, AddressOf Me.formSafety_ApplySafetyValueClick

        formSafety.ShowDialog()
        formSafety.Dispose()
        formSafety = Nothing
        Timer1.Enabled = True
    End Sub

    Private Sub tBarOutputVal_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tBarOutputVal.ValueChanged
        Dim fVal As Single
        fVal = (((m_fHigh - m_fLow) _
                    * ((tBarOutputVal.Value - tBarOutputVal.Minimum) _
                    / (tBarOutputVal.Maximum - tBarOutputVal.Minimum))) _
                    + m_fLow)
        txtOutputVal.Text = fVal.ToString("0.000")
    End Sub

    Private Sub btnSetAsStartup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetAsStartup.Click
        If Not CheckControllable() Then
            Return
        End If
        Dim fLow As Single
        Dim fVal As Single
        Dim fHigh As Single
        Timer1.Enabled = False
        If (txtOutputVal.Text.Length = 0) Then
            MessageBox.Show("Illegal value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            
            Return
        End If
        Try
            'Get range higf & low
            AnalogOutput.GetRangeHighLow(m_usRanges(m_iSelChannels), fHigh, fLow)
            If ((fHigh - fLow) _
                        = 0) Then
                MessageBox.Show("GetRangeHighLow() failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
                Return
            End If
            'convert output value to float
            fVal = 0.0!
            If ((Not (txtOutputVal.Text) Is Nothing) _
                        AndAlso (txtOutputVal.Text.Length > 0)) Then
                Try
                    fVal = Convert.ToSingle(txtOutputVal.Text)
                Catch ex As System.Exception
                    System.Windows.Forms.MessageBox.Show(("Invalid value: " + txtOutputVal.Text))
                End Try
            End If
            If ((fVal > fHigh) _
                        OrElse (fVal < fLow)) Then
                MessageBox.Show(("Illegal value! Please enter the value " _
                                + (fLow.ToString + (" ~ " _
                                + (fHigh.ToString + ".")))), "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
                Return
            End If
            Dim usStartupAO() As System.UInt16 = New System.UInt16((m_usStartupAO.Length) - 1) {}
            Array.Copy(m_usStartupAO, 0, usStartupAO, 0, m_usStartupAO.Length)
            usStartupAO(m_iSelChannels) = Convert.ToUInt16((65535.0! _
                            * ((fVal - fLow) _
                            / (fHigh - fLow))))
            If m_adamCtl.AnalogOutput.SetStartupValues(Me.m_iSlot_ID, usStartupAO) Then
                MessageBox.Show("Set AO startup values done!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
                RefreshAoStartupValues()
            Else
                MessageBox.Show("Set AO startup values failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            End If
        Catch ex As System.Exception
            MessageBox.Show("Illegal value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            Return
        End Try
        Timer1.Enabled = True
    End Sub

    Private Sub btnSetAsSafety_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetAsSafety.Click
        If Not CheckControllable() Then
            Return
        End If
        Try
            Dim fLow As Single
            Dim fVal As Single
            Dim fHigh As Single
            Dim iChannelTotal As Integer = Me.m_aConf.HwIoTotal(m_tmpidx)
            'Get range higf & low
            AnalogOutput.GetRangeHighLow(m_usRanges(m_iSelChannels), fHigh, fLow)
            If ((fHigh - fLow) _
                        = 0) Then
                MessageBox.Show("GetRangeHighLow() failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
                Return
            End If
            'convert output value to float
            fVal = 0.0!
            If ((Not (txtOutputVal.Text) Is Nothing) _
                        AndAlso (txtOutputVal.Text.Length > 0)) Then
                Try
                    fVal = Convert.ToSingle(txtOutputVal.Text)
                Catch ex As System.Exception
                    System.Windows.Forms.MessageBox.Show(("Invalid value: " + txtOutputVal.Text))
                End Try
            End If
            Dim usAOSafetyVals() As System.UInt16 = New System.UInt16((m_usAOSafetyVals.Length) - 1) {}
            Array.Copy(m_usAOSafetyVals, 0, usAOSafetyVals, 0, m_usAOSafetyVals.Length)
            usAOSafetyVals(m_iSelChannels) = Convert.ToUInt16((65535.0! _
                            * ((fVal - fLow) _
                            / (fHigh - fLow))))
            If Not m_adamCtl.AnalogOutput.SetSafetyValues(Me.m_iSlot_ID, iChannelTotal, usAOSafetyVals) Then
                MessageBox.Show(("Set safety value failed! (Err: " _
                                + (m_adamCtl.AnalogOutput.ApiLastError.ToString + ")")), "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1)
            End If
            RefreshSafetySetting()
        Catch ex As System.Exception
            Return
        End Try
        Return


    End Sub

    Private Sub tBarOutputVal_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tBarOutputVal.GotFocus
        b_AOValueModified = True
        txtOutputVal.SelectAll()
    End Sub

    Private Sub txtOutputVal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOutputVal.KeyPress
        b_AOValueModified = True
    End Sub


End Class
