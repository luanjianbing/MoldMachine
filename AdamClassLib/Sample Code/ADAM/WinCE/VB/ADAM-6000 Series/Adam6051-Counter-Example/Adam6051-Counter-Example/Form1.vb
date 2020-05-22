Imports System.Net.Sockets
Imports Advantech.Adam

Public Class Form1
    Private m_bStart As Boolean
    Private m_adamUDP As AdamSocket             'UDP protocol to config module 
    Private m_adamModbus As AdamSocket        'Modbus TCP for real data access and config module 
    Private m_Adam6000Type As Adam6000Type
    Private m_szIP As String
    Private m_iPort As Integer
    Private m_iCount As Integer
    Private m_iDoTotal, m_iDiTotal, m_iCntTotal As Integer
    Private m_iCh As Integer
    Private m_bRecordLastCount() As Boolean
    Private m_bDigitalFilter() As Boolean
    Private m_bInvert() As Boolean
    Private m_byMode() As Byte
    Private m_byConfig() As Byte
    Private m_lHigh(), m_lLow() As Long

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        m_bStart = False                                                ' the action stops at the beginning
        m_szIP = "10.0.0.1"                                           ' modbus slave IP address
        m_iPort = 502                                                    ' modbus TCP port is 502
        m_adamModbus = New AdamSocket()
        m_adamModbus.SetTimeout(1000, 1000, 1000)   ' set timeout for TCP

        m_Adam6000Type = Adam6000Type.Adam6051 ' the sample is for ADAM-6051

        InitAdam6051()
        SetModeItem()
        btnEnableDisable(False)
        txtModule.Text = m_Adam6000Type.ToString()

    End Sub

    Private Sub InitChannelItems(ByVal i_bVisable As Boolean, ByVal i_bIsDI As Boolean, ByRef i_iDI As Integer, ByRef i_iDO As Integer, ByRef panelCh As Panel, ByRef btnCh As Button)
        Dim iCh As Integer

        If (i_bVisable) Then

            panelCh.Visible = True
            iCh = i_iDI + i_iDO

            If (i_bIsDI) Then ' DI

                btnCh.Text = "DI " + i_iDI.ToString()
                btnCh.Enabled = False
                i_iDI = i_iDI + 1

            Else ' DO

                btnCh.Text = "DO " + i_iDO.ToString()
                i_iDO = i_iDO + 1

            End If

        Else
            panelCh.Visible = False
        End If

    End Sub

    Private Sub InitAdam6051()
        Dim iDI As Integer = 0, iDO As Integer = 0

        InitChannelItems(True, True, iDI, iDO, panelCh0, btnCh0)
        InitChannelItems(True, True, iDI, iDO, panelCh1, btnCh1)
        InitChannelItems(True, True, iDI, iDO, panelCh2, btnCh2)
        InitChannelItems(True, True, iDI, iDO, panelCh3, btnCh3)
        InitChannelItems(True, True, iDI, iDO, panelCh4, btnCh4)
        InitChannelItems(True, True, iDI, iDO, panelCh5, btnCh5)
        InitChannelItems(True, True, iDI, iDO, panelCh6, btnCh6)
        InitChannelItems(True, True, iDI, iDO, panelCh7, btnCh7)
        InitChannelItems(True, True, iDI, iDO, panelCh8, btnCh8)
        InitChannelItems(True, True, iDI, iDO, panelCh9, btnCh9)
        InitChannelItems(True, True, iDI, iDO, panelCh10, btnCh10)
        InitChannelItems(True, True, iDI, iDO, panelCh11, btnCh11)
        InitChannelItems(True, False, iDI, iDO, panelCh12, btnCh12)
        InitChannelItems(True, False, iDI, iDO, panelCh13, btnCh13)
        InitChannelItems(False, True, iDI, iDO, panelCh14, btnCh14)
        InitChannelItems(False, True, iDI, iDO, panelCh15, btnCh15)
        InitChannelItems(False, True, iDI, iDO, panelCh16, btnCh16)
        InitChannelItems(False, True, iDI, iDO, panelCh17, btnCh17)

        panelCounter.Visible = True

        m_iDiTotal = 12
        m_iDoTotal = 6
        m_iCntTotal = Counter.GetChannelTotal(Adam6000Type.Adam6051)
        ReDim m_byMode(m_iCntTotal)
        ReDim m_bRecordLastCount(m_iCntTotal)
        ReDim m_bDigitalFilter(m_iCntTotal)
        ReDim m_bInvert(m_iCntTotal)

    End Sub

    Private Sub Form1_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        If (m_bStart) Then
            timer1.Enabled = False
            CounterStartStop(CType(Me.btnCounterStartCh1, Object), False)
            CounterStartStop(CType(Me.btnCounterStartCh2, Object), False)
            m_adamModbus.Disconnect()   ' disconnect slave
        End If

        If (Not m_adamUDP Is Nothing) Then
            m_adamUDP.Disconnect()
            m_adamUDP = Nothing
        End If

    End Sub

    Private Sub buttonStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonStart.Click

        If (m_bStart) Then ' was started

            btnEnableDisable(False)
            panelDIO.Enabled = False
            panelDiMode.Enabled = False
            panelSetting.Enabled = False
            m_bStart = False        ' starting flag
            timer1.Enabled = False ' disable timer
            m_adamModbus.Disconnect() ' disconnect slave
            buttonStart.Text = "Start"

        Else ' was stoped

            If (m_adamModbus.Connect(m_szIP, ProtocolType.Tcp, m_iPort)) Then

                m_adamUDP = New AdamSocket()
                m_adamUDP.Connect(AdamType.Adam6000, m_szIP, ProtocolType.Udp)

                btnEnableDisable(True)
                panelDIO.Enabled = True
                panelDiMode.Enabled = True
                panelSetting.Enabled = True
                m_iCount = 0 ' reset the reading counter

                comboBoxCh.SelectedIndex = 1 ' will trig RefreshChannelMode()
                RefreshPanel()

                If (m_byMode(comboBoxCh.SelectedIndex) = CType(Adam6051_CounterMode.Counter, Byte)) Then
                    CounterStartStop(CType(Me.btnCounterStartCh2, Object), True)
                End If

                comboBoxCh.SelectedIndex = 0 ' will trig RefreshChannelMode()
                RefreshPanel()

                If (m_byMode(comboBoxCh.SelectedIndex) = CType(Adam6051_CounterMode.Counter, Byte)) Then
                    CounterStartStop(CType(Me.btnCounterStartCh1, Object), True)
                End If

                m_bStart = True               ' starting flag                
                timer1.Enabled = True       ' enable timer
                buttonStart.Text = "Stop"

            Else
                MessageBox.Show("Connect to " + m_szIP + " failed", "Error")
            End If

        End If

    End Sub

    Private Sub RefreshDIO()

        Dim iDiStart As Integer = 1, iDoStart As Integer = 17
        Dim iChTotal As Integer
        Dim iIdx As Integer
        Dim iConfigStart As Integer
        Dim bDiData(), bDoData(), bData() As Boolean
        Dim byConfig() As Byte

        If (m_adamModbus.DigitalInput().GetIOConfig(byConfig)) Then

            'counter
            iConfigStart = Counter.GetChannelStart(m_Adam6000Type)

            For iIdx = 0 To (m_iCntTotal - 1)
                Counter.ParseIOConfig(byConfig(iConfigStart + iIdx), m_byMode(iIdx), m_bRecordLastCount(iIdx), m_bDigitalFilter(iIdx), m_bInvert(iIdx))
            Next

        End If

        If (m_adamModbus.Modbus().ReadCoilStatus(iDiStart, m_iDiTotal, bDiData) AndAlso m_adamModbus.Modbus().ReadCoilStatus(iDoStart, m_iDoTotal, bDoData)) Then

            iChTotal = m_iDiTotal + m_iDoTotal
            ReDim bData([iChTotal])
            Array.Copy(bDiData, 0, bData, 0, m_iDiTotal)
            Array.Copy(bDoData, 0, bData, m_iDiTotal, m_iDoTotal)

            If (iChTotal > 0) Then
                txtCh0.Text = bData(0).ToString()
            End If

            If (iChTotal > 1) Then
                txtCh1.Text = bData(1).ToString()
            End If

            If (iChTotal > 2) Then
                txtCh2.Text = bData(2).ToString()
            End If

            If (iChTotal > 3) Then
                txtCh3.Text = bData(3).ToString()
            End If

            If (iChTotal > 4) Then
                txtCh4.Text = bData(4).ToString()
            End If

            If (iChTotal > 5) Then
                txtCh5.Text = bData(5).ToString()
            End If

            If (iChTotal > 6) Then
                txtCh6.Text = bData(6).ToString()
            End If

            If (iChTotal > 7) Then
                txtCh7.Text = bData(7).ToString()
            End If

            If (iChTotal > 8) Then
                txtCh8.Text = bData(8).ToString()
            End If

            If (iChTotal > 9) Then
                txtCh9.Text = bData(9).ToString()
            End If

            If (iChTotal > 10) Then
                txtCh10.Text = bData(10).ToString()
            End If

            If (iChTotal > 11) Then
                txtCh11.Text = bData(11).ToString()
            End If

            If (iChTotal > 12) Then
                txtCh12.Text = bData(12).ToString()
            End If

            If (iChTotal > 13) Then
                txtCh13.Text = bData(13).ToString()
            End If

            If (iChTotal > 14) Then
                txtCh14.Text = bData(14).ToString()
            End If

            If (iChTotal > 15) Then
                txtCh15.Text = bData(15).ToString()
            End If

            If (iChTotal > 16) Then
                txtCh16.Text = bData(16).ToString()
            End If

            If (iChTotal > 17) Then
                txtCh17.Text = bData(17).ToString()
            End If

        Else

            txtCh0.Text = "Fail"
            txtCh1.Text = "Fail"
            txtCh2.Text = "Fail"
            txtCh3.Text = "Fail"
            txtCh4.Text = "Fail"
            txtCh5.Text = "Fail"
            txtCh6.Text = "Fail"
            txtCh7.Text = "Fail"
            txtCh8.Text = "Fail"
            txtCh9.Text = "Fail"
            txtCh10.Text = "Fail"
            txtCh11.Text = "Fail"
            txtCh12.Text = "Fail"
            txtCh13.Text = "Fail"
            txtCh14.Text = "Fail"
            txtCh15.Text = "Fail"
            txtCh16.Text = "Fail"
            txtCh17.Text = "Fail"

        End If

        If (m_Adam6000Type = Adam6000Type.Adam6051) Then
            RefreshCounterValue()
        End If

    End Sub

    Private Sub timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timer1.Tick
        timer1.Enabled = False

        m_iCount = m_iCount + 1 ' increment the reading counter
        txtReadCount.Text = "Read coil " + m_iCount.ToString() + " times..."
        RefreshDIO()

        timer1.Enabled = True
    End Sub

    Private Sub btnCh_Click(ByVal i_iCh As Integer, ByVal txtBox As TextBox)
        Dim iOnOff As Integer
        Dim iStart As Integer = 17 + i_iCh - m_iDiTotal

        timer1.Enabled = False

        If (txtBox.Text = "True") Then ' was ON, now set to OFF
            iOnOff = 0
        Else
            iOnOff = 1
        End If

        If (m_adamModbus.Modbus().ForceSingleCoil(iStart, iOnOff)) Then
            RefreshDIO()
        Else
            MessageBox.Show("Set digital output failed!", "Error")
        End If

        timer1.Enabled = True

    End Sub

    Private Function RefreshCounterValue() As Boolean
        Dim iCntStart As Integer = 25, iChTotal As Integer = 2     'for 6051, 12 DI, 2 counter, each counter uses 2 registers

        Dim iData() As Integer
        Dim fValue As Double

        If (m_adamModbus.Modbus().ReadInputRegs(iCntStart, iChTotal * 2, iData)) Then
            fValue = Counter.GetScaledValue(m_Adam6000Type, m_byMode(0), iData(1), iData(0))
            txtCntValue0.Text = fValue.ToString(Counter.GetFormat(m_Adam6000Type, m_byMode(0))) + " " + Counter.GetUnitName(m_Adam6000Type, m_byMode(0))

            fValue = Counter.GetScaledValue(m_Adam6000Type, m_byMode(1), iData(3), iData(2))
            txtCntValue1.Text = fValue.ToString(Counter.GetFormat(m_Adam6000Type, m_byMode(1))) + " " + Counter.GetUnitName(m_Adam6000Type, m_byMode(1))

            Return True
        End If

        Return False
    End Function

    Private Sub SetModeItem()
        cbxDiMode.Items.Add("Counter")
        cbxDiMode.Items.Add("Frequency")
    End Sub

    Private Sub RefreshChannelMode()
        Dim iConfigStart As Integer

        If (m_adamUDP.DigitalInput().GetIOConfig(m_byConfig)) Then

            iConfigStart = Counter.GetChannelStart(m_Adam6000Type)
            Counter.ParseIOConfig(m_byConfig(iConfigStart + comboBoxCh.SelectedIndex), m_byMode(comboBoxCh.SelectedIndex), m_bRecordLastCount(comboBoxCh.SelectedIndex), m_bDigitalFilter(comboBoxCh.SelectedIndex), m_bInvert(comboBoxCh.SelectedIndex))

        Else
            MessageBox.Show("GetIOConfig() failed;")
        End If

    End Sub

    Private Sub btnCh0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh0.Click
        btnCh_Click(0, txtCh0)
    End Sub

    Private Sub btnCh1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh1.Click
        btnCh_Click(1, txtCh1)
    End Sub

    Private Sub btnCh2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh2.Click
        btnCh_Click(2, txtCh2)
    End Sub

    Private Sub btnCh3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh3.Click
        btnCh_Click(3, txtCh3)
    End Sub

    Private Sub btnCh4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh4.Click
        btnCh_Click(4, txtCh4)
    End Sub

    Private Sub btnCh5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh5.Click
        btnCh_Click(5, txtCh5)
    End Sub

    Private Sub btnCh6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh6.Click
        btnCh_Click(6, txtCh6)
    End Sub

    Private Sub btnCh7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh7.Click
        btnCh_Click(7, txtCh7)
    End Sub

    Private Sub btnCh8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh8.Click
        btnCh_Click(8, txtCh8)
    End Sub

    Private Sub btnCh9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh9.Click
        btnCh_Click(9, txtCh9)
    End Sub

    Private Sub btnCh10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh10.Click
        btnCh_Click(10, txtCh10)
    End Sub

    Private Sub btnCh11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh11.Click
        btnCh_Click(11, txtCh11)
    End Sub

    Private Sub btnCh12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh12.Click
        btnCh_Click(12, txtCh12)
    End Sub

    Private Sub btnCh13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh13.Click
        btnCh_Click(13, txtCh13)
    End Sub

    Private Sub btnCh14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh14.Click
        btnCh_Click(14, txtCh14)
    End Sub

    Private Sub btnCh15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh15.Click
        btnCh_Click(15, txtCh15)
    End Sub

    Private Sub btnCh16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh16.Click
        btnCh_Click(16, txtCh16)
    End Sub

    Private Sub btnCh17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh17.Click
        btnCh_Click(17, txtCh17)
    End Sub

    Private Sub btnCounterStartCh1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCounterStartCh1.Click

        If (btnCounterStartCh1.Text = "Start") Then
            CounterStartStop(sender, True)
        Else
            CounterStartStop(sender, False)
        End If

    End Sub

    Private Sub btnCounterStartCh2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCounterStartCh2.Click

        If (btnCounterStartCh2.Text = "Start") Then
            CounterStartStop(sender, True)
        Else
            CounterStartStop(sender, False)
        End If

    End Sub

    Private Sub CounterStartStop(ByVal sender As Object, ByVal bFlag As Boolean)

        Dim iData, iStart As Integer
        Dim iConfigStart As Integer

        If (m_bStart) Then

            timer1.Enabled = False

            If (CType(sender, Button).Name = "btnCounterStartCh1") Then

                If (bFlag) Then
                    iData = 1
                Else
                    iData = 0
                End If

                m_iCh = 0

                iConfigStart = Counter.GetChannelStart(m_Adam6000Type)
                iStart = 32 + (iConfigStart + m_iCh) * 4 + 1

                If (m_adamModbus.Modbus().ForceSingleCoil(iStart, iData)) Then

                    RefreshCounterValue()
                    If (bFlag) Then
                        btnCounterStartCh1.Text = "Stop"
                    Else
                        btnCounterStartCh1.Text = "Start"
                    End If

                Else
                    MessageBox.Show("ForceSingleCoil() failed;")
                End If

            Else  ' "btnCounterStartCh2"

                If (bFlag) Then
                    iData = 1
                Else
                    iData = 0
                End If

                m_iCh = 1

                iConfigStart = Counter.GetChannelStart(m_Adam6000Type)
                iStart = 32 + (iConfigStart + m_iCh) * 4 + 1

                If (m_adamModbus.Modbus().ForceSingleCoil(iStart, iData)) Then

                    RefreshCounterValue()
                    If (bFlag) Then
                        btnCounterStartCh2.Text = "Stop"
                    Else
                        btnCounterStartCh2.Text = "Start"
                    End If

                Else
                    MessageBox.Show("ForceSingleCoil() failed;")
                End If

            End If

            timer1.Enabled = True

        End If

    End Sub

    Private Sub btnEnableDisable(ByVal bEnable As Boolean)
        btnCounterStartCh1.Enabled = bEnable
        btnCounterClearCh1.Enabled = bEnable
        btnCounterStartCh2.Enabled = bEnable
        btnCounterClearCh2.Enabled = bEnable
        btnApplyMode.Enabled = bEnable
        buttonApplyChange.Enabled = bEnable
    End Sub

    Private Sub btnCounterClearCh1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCounterClearCh1.Click
        ClearCounter(sender)
    End Sub

    Private Sub btnCounterClearCh2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCounterClearCh2.Click
        ClearCounter(sender)
    End Sub

    Private Sub ClearCounter(ByVal sender As Object)
        Dim iConfigStart, iStart As Integer
        Dim iData As Integer = 1  'to clear, set as 1

        If (CType(sender, Button).Name = "btnCounterClearCh1") Then

            m_iCh = 0
            iConfigStart = Counter.GetChannelStart(m_Adam6000Type)
            iStart = 32 + (iConfigStart + m_iCh) * 4 + 2

            If (m_adamModbus.Modbus().ForceSingleCoil(iStart, iData)) Then
                RefreshCounterValue()
            Else
                MessageBox.Show("ForceSingleCoil() failed;")
            End If

        Else

            m_iCh = 1
            iConfigStart = Counter.GetChannelStart(m_Adam6000Type)
            iStart = 32 + (iConfigStart + m_iCh) * 4 + 2

            If (m_adamModbus.Modbus().ForceSingleCoil(iStart, iData)) Then
                RefreshCounterValue()
            Else
                MessageBox.Show("ForceSingleCoil() failed;")
            End If

        End If

    End Sub

    Private Sub btnApplyMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApplyMode.Click
        Dim byConf, byMode, byPreConf As Byte
        byPreConf = 0

        If (cbxDiMode.SelectedIndex = 0) Then
            byMode = CType(Adam6051_CounterMode.Counter, Byte)
        Else
            byMode = CType(Adam6051_CounterMode.Frequency, Byte)
        End If

        Dim iConfigStart As Integer = Counter.GetChannelStart(m_Adam6000Type)
        Dim chIdx As Integer = iConfigStart + comboBoxCh.SelectedIndex
        Counter.FormIOConfig(byMode, m_bRecordLastCount(comboBoxCh.SelectedIndex), m_bDigitalFilter(comboBoxCh.SelectedIndex), m_bInvert(comboBoxCh.SelectedIndex), byConf)

        byPreConf = m_byConfig(chIdx)
        m_byConfig(chIdx) = byConf

        If (m_adamUDP.Counter().SetIOConfig(m_byConfig)) Then

            RefreshChannelMode()
            RefreshPanel()
            RefreshSetting()
            MessageBox.Show("Apply mode setting successfully!", "Information")

        Else

            m_byConfig(iConfigStart + m_iCh) = byPreConf
            MessageBox.Show("Change counter mode failed!", "Error")

        End If

    End Sub

    Private Sub ApplyChange()

        Try

            Dim byConf, byPreConf As Byte
            Dim lHigh, lLow As Long
            Dim lPreHigh As Long = 0
            Dim lPreLow As Long = 0

            If (comboBoxCh.SelectedIndex = 0) Then
                m_iCh = 0
            Else
                m_iCh = 1
            End If

            byPreConf = 0
            If (Not m_byConfig Is Nothing) Then
                byPreConf = m_byConfig(m_iCh)
            End If

            If (Not m_lHigh Is Nothing) Then
                lPreHigh = m_lHigh(Me.m_iCh)
            End If

            If (Not m_lLow Is Nothing) Then
                lPreLow = m_lLow(Me.m_iCh)
            End If

            timer1.Enabled = False

            Dim iConfigStart As Integer = Counter.GetChannelStart(m_Adam6000Type)

            If (m_byMode(m_iCh) = CType(Adam6051_CounterMode.Counter, Byte)) Then

                'digital filter
                If (cbxFilter.Checked) Then

                    Try

                        lHigh = Convert.ToInt64(txtCntHigh.Text)
                        lLow = Convert.ToInt64(txtCntLow.Text)

                    Catch ex As Exception

                        MessageBox.Show("The digital filter signal width is invalid!", "Error")
                        timer1.Enabled = True
                        Return

                    End Try

                    lPreHigh = m_lHigh(iConfigStart + m_iCh)
                    lPreLow = m_lLow(iConfigStart + m_iCh)
                    m_lHigh(iConfigStart + m_iCh) = lHigh
                    m_lLow(iConfigStart + m_iCh) = lLow

                    If (Not m_adamUDP.Counter().SetDigitalFilterMiniSignalWidth(m_lHigh, m_lLow)) Then
                        MessageBox.Show("Change digital filter signal width failed!", "Error")

                        m_lHigh(iConfigStart + m_iCh) = lPreHigh
                        m_lLow(iConfigStart + m_iCh) = lPreLow

                        timer1.Enabled = True
                        Return

                    End If

                End If

                'Setting
                Counter.FormIOConfig(m_byMode(m_iCh), cbxKeepLast.Checked, cbxFilter.Checked, cbxInvert.Checked, byConf)

                byPreConf = m_byConfig(iConfigStart + m_iCh)
                m_byConfig(iConfigStart + m_iCh) = byConf

                If (m_adamUDP.Counter().SetIOConfig(m_byConfig)) Then

                    MessageBox.Show("Apply change setting successfully!", "Information")
                    RefreshChannelMode()
                    RefreshModePanel()
                    RefreshSetting()

                Else

                    m_byConfig(iConfigStart + m_iCh) = byPreConf
                    MessageBox.Show("Change DI setting failed!", "Error")

                End If

            End If

            timer1.Enabled = True

        Catch ex As Exception
            MessageBox.Show("Failed to apply setting! (" + ex.Message + ")")
        End Try

    End Sub

    Private Sub buttonApplyChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonApplyChange.Click
        ApplyChange()
    End Sub

    Private Sub comboBoxCh_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comboBoxCh.SelectedIndexChanged
        RefreshChannelMode()
        RefreshModePanel()
        RefreshSetting()
    End Sub

    Private Sub RefreshModePanel()
        If (m_byMode(comboBoxCh.SelectedIndex) = CType(Adam6051_CounterMode.Counter, Byte)) Then
            cbxDiMode.SelectedIndex = 0
            panelSetting.Visible = True
        Else
            cbxDiMode.SelectedIndex = 1
            panelSetting.Visible = False
        End If
    End Sub

    Private Sub RefreshPanel()
        If (m_byMode(comboBoxCh.SelectedIndex) = CType(Adam6051_CounterMode.Counter, Byte)) Then

            If (comboBoxCh.SelectedIndex = 0) Then
                btnCounterStartCh1.Enabled = True
                btnCounterClearCh1.Enabled = True
            Else
                btnCounterStartCh2.Enabled = True
                btnCounterClearCh2.Enabled = True
            End If

            panelSetting.Visible = True

        Else

            If (comboBoxCh.SelectedIndex = 0) Then
                btnCounterStartCh1.Enabled = False
                btnCounterClearCh1.Enabled = False
            Else
                btnCounterStartCh2.Enabled = False
                btnCounterClearCh2.Enabled = False
            End If

            panelSetting.Visible = False

        End If

    End Sub

    Private Sub RefreshSetting()
        Dim iStart As Integer

        If (comboBoxCh.SelectedIndex = 0) Then
            m_iCh = 0
        Else
            m_iCh = 1
        End If

        cbxInvert.Checked = m_bInvert(m_iCh)
        cbxKeepLast.Checked = m_bRecordLastCount(m_iCh)
        cbxFilter.Checked = m_bDigitalFilter(m_iCh)

        If (cbxFilter.Checked) Then
            txtCntLow.ReadOnly = False
            txtCntHigh.ReadOnly = False
        Else
            txtCntLow.ReadOnly = True
            txtCntHigh.ReadOnly = True
        End If

        If ((m_Adam6000Type = Adam6000Type.Adam6051) OrElse (m_Adam6000Type = Adam6000Type.Adam6051W)) Then

            If (m_byMode(m_iCh) = CType(Adam6051_CounterMode.Counter, Byte)) Then

                iStart = Counter.GetChannelStart(m_Adam6000Type)

                If (m_adamUDP.Counter().GetDigitalFilterMiniSignalWidth(m_lHigh, m_lLow) AndAlso ((iStart + m_iCh) < m_lHigh.Length)) Then
                    txtCntLow.Text = m_lLow(iStart + m_iCh).ToString()
                    txtCntHigh.Text = m_lHigh(iStart + m_iCh).ToString()
                Else
                    MessageBox.Show("GetDigitalFilterMiniSignalWidth() failed.", "Error")
                End If

            End If

        End If

    End Sub

    Private Sub cbxFilter_CheckStateChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxFilter.CheckStateChanged

        If (cbxFilter.Checked) Then
            txtCntLow.ReadOnly = False
            txtCntHigh.ReadOnly = False
        Else
            txtCntLow.ReadOnly = True
            txtCntHigh.ReadOnly = True
        End If

    End Sub
End Class
