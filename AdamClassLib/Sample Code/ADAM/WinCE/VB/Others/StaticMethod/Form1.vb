Imports Advantech.Adam

Public Class Form1

    
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbxAdamType.Items.Add(AdamType.Adam4000)
        cbxAdamType.Items.Add(AdamType.Adam5000)
        cbxAdamType.Items.Add(AdamType.Adam5000Tcp)
        cbxAdamType.Items.Add(AdamType.Adam6000)
        cbxAdamType.SelectedIndex = 0
    End Sub

    Private Sub cbxAdamType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxAdamType.SelectedIndexChanged
        Dim adamType As AdamType
        adamType = cbxAdamType.SelectedItem

        If (adamType.Equals(adamType.Adam4000)) Then
            InitAdam4000ComboxList()
        ElseIf (adamType.Equals(adamType.Adam6000)) Then
            InitAdam6000ComboxList()
        Else
            InitAdam5000ComboxList()
        End If
    End Sub

    Private Sub cbxModuleType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxModuleType.SelectedIndexChanged
        Dim adamType As Advantech.Adam.AdamType
        adamType = cbxAdamType.SelectedItem

        If (adamType.Equals(adamType.Adam4000)) Then
            RefreshAdam4000Information()
        ElseIf (adamType.Equals(adamType.Adam6000)) Then
            RefreshAdam6000Information()
        Else
            RefreshAdam5000Information()
        End If
    End Sub

    Private Sub InitAdam4000ComboxList()
        cbxModuleType.Items.Clear()
        cbxModuleType.Items.Add(Adam4000Type.Adam4011)
        cbxModuleType.Items.Add(Adam4000Type.Adam4011D)
        cbxModuleType.Items.Add(Adam4000Type.Adam4012)
        cbxModuleType.Items.Add(Adam4000Type.Adam4013)
        cbxModuleType.Items.Add(Adam4000Type.Adam4015)
        cbxModuleType.Items.Add(Adam4000Type.Adam4015T)
        cbxModuleType.Items.Add(Adam4000Type.Adam4016)
        cbxModuleType.Items.Add(Adam4000Type.Adam4017)
        cbxModuleType.Items.Add(Adam4000Type.Adam4017P)
        cbxModuleType.Items.Add(Adam4000Type.Adam4018)
        cbxModuleType.Items.Add(Adam4000Type.Adam4018M)
        cbxModuleType.Items.Add(Adam4000Type.Adam4018P)
        cbxModuleType.Items.Add(Adam4000Type.Adam4019)
        cbxModuleType.Items.Add(Adam4000Type.Adam4019P)
        cbxModuleType.Items.Add(Adam4000Type.Adam4021)
        cbxModuleType.Items.Add(Adam4000Type.Adam4022T)
        cbxModuleType.Items.Add(Adam4000Type.Adam4024)
        cbxModuleType.Items.Add(Adam4000Type.Adam4050)
        cbxModuleType.Items.Add(Adam4000Type.Adam4051)
        cbxModuleType.Items.Add(Adam4000Type.Adam4052)
        cbxModuleType.Items.Add(Adam4000Type.Adam4053)
        cbxModuleType.Items.Add(Adam4000Type.Adam4055)
        cbxModuleType.Items.Add(Adam4000Type.Adam4056S)
        cbxModuleType.Items.Add(Adam4000Type.Adam4056SO)
        cbxModuleType.Items.Add(Adam4000Type.Adam4060)
        cbxModuleType.Items.Add(Adam4000Type.Adam4068)
        cbxModuleType.Items.Add(Adam4000Type.Adam4069)
        cbxModuleType.Items.Add(Adam4000Type.Adam4080)
        cbxModuleType.Items.Add(Adam4000Type.Adam4080D)
        cbxModuleType.SelectedIndex = 0
    End Sub

    Private Sub RefreshAdam4000Information()
        Dim iIdx As Int32
        Dim byCode As Byte

        Dim adamType As Adam4000Type

        adamType = cbxModuleType.SelectedItem
        ' AI information
        txtAITotal.Text = AnalogInput.GetChannelTotal(adamType).ToString()
        listViewAI.Items.Clear()

        For iIdx = 0 To AnalogInput.GetRangeTotal(adamType) - 1
            byCode = AnalogInput.GetRangeCode(adamType, iIdx)
            listViewAI.Items.Add(New ListViewItem("0x" + byCode.ToString("X02")))               ' range code
            listViewAI.Items(iIdx).SubItems.Add(AnalogInput.GetRangeName(adamType, byCode)) ' range name
            listViewAI.Items(iIdx).SubItems.Add(AnalogInput.GetUnitName(adamType, byCode))  ' range name
        Next iIdx
        ' AO information
        txtAOTotal.Text = AnalogOutput.GetChannelTotal(adamType).ToString()
        listViewAO.Items.Clear()
        For iIdx = 0 To AnalogOutput.GetRangeTotal(adamType) - 1
            byCode = AnalogOutput.GetRangeCode(adamType, iIdx)
            listViewAO.Items.Add(New ListViewItem("0x" + byCode.ToString("X02")))               ' range code
            listViewAO.Items(iIdx).SubItems.Add(AnalogOutput.GetRangeName(adamType, byCode))  ' range name
            listViewAO.Items(iIdx).SubItems.Add(AnalogOutput.GetUnitName(adamType, byCode))   ' range name
        Next iIdx
        ' DIO
        txtDITotal.Text = DigitalInput.GetChannelTotal(adamType).ToString()
        txtDOTotal.Text = DigitalOutput.GetChannelTotal(adamType).ToString()
        ' counter
        txtCounterTotal.Text = Counter.GetChannelTotal(adamType).ToString()
        listViewCounter.Items.Clear()
        If Counter.GetModeTotal(adamType) > 0 Then
            listViewCounter.Items.Add(New ListViewItem(Counter.GetModeName(adamType, Adam4080_CounterMode.Counter)))  ' mode name
            listViewCounter.Items(0).SubItems.Add(Counter.GetUnitName(adamType, Adam4080_CounterMode.Counter))   ' unit name
            listViewCounter.Items.Add(New ListViewItem(Counter.GetModeName(adamType, Adam4080_CounterMode.Frequency))) ' mode name
            listViewCounter.Items(1).SubItems.Add(Counter.GetUnitName(adamType, Adam4080_CounterMode.Frequency))   ' unit name
        End If
        ' alarm
        listViewAlarm.Items.Clear()
        For iIdx = 0 To Alarm.GetModeTotal(adamType) - 1
            byCode = Alarm.GetModeCode(adamType, iIdx)
            listViewAlarm.Items.Add(New ListViewItem(Alarm.GetModeName(adamType, byCode))) ' mode name
        Next iIdx
    End Sub

    Private Sub InitAdam5000ComboxList()
        cbxModuleType.Items.Clear()
        cbxModuleType.Items.Add(Adam5000Type.Adam5013)
        cbxModuleType.Items.Add(Adam5000Type.Adam5017)
        cbxModuleType.Items.Add(Adam5000Type.Adam5017H)
        cbxModuleType.Items.Add(Adam5000Type.Adam5017UH)
        cbxModuleType.Items.Add(Adam5000Type.Adam5018)
        cbxModuleType.Items.Add(Adam5000Type.Adam5024)
        cbxModuleType.Items.Add(Adam5000Type.Adam5050)
        cbxModuleType.Items.Add(Adam5000Type.Adam5051)
        cbxModuleType.Items.Add(Adam5000Type.Adam5052)
        cbxModuleType.Items.Add(Adam5000Type.Adam5055)
        cbxModuleType.Items.Add(Adam5000Type.Adam5060)
        cbxModuleType.Items.Add(Adam5000Type.Adam5068)
        cbxModuleType.Items.Add(Adam5000Type.Adam5069)
        cbxModuleType.Items.Add(Adam5000Type.Adam5080)
        cbxModuleType.SelectedIndex = 0
    End Sub

    Private Sub RefreshAdam5000Information()
        Dim iIdx As Int32
        Dim byCode As Byte

        Dim adamType As Adam5000Type
        adamType = cbxModuleType.SelectedItem
        ' AI information
        txtAITotal.Text = AnalogInput.GetChannelTotal(adamType).ToString()
        listViewAI.Items.Clear()
        For iIdx = 0 To AnalogInput.GetRangeTotal(adamType) - 1
            byCode = AnalogInput.GetRangeCode(adamType, iIdx)
            listViewAI.Items.Add(New ListViewItem("0x" + byCode.ToString("X02")))           ' range code
            listViewAI.Items(iIdx).SubItems.Add(AnalogInput.GetRangeName(adamType, byCode)) ' range name
            listViewAI.Items(iIdx).SubItems.Add(AnalogInput.GetUnitName(adamType, byCode))  ' range name
        Next iIdx
        ' AO information
        txtAOTotal.Text = AnalogOutput.GetChannelTotal(adamType).ToString()
        listViewAO.Items.Clear()
        For iIdx = 0 To AnalogOutput.GetRangeTotal(adamType) - 1
            byCode = AnalogOutput.GetRangeCode(adamType, iIdx)
            listViewAO.Items.Add(New ListViewItem("0x" + byCode.ToString("X02")))               ' range code
            listViewAO.Items(iIdx).SubItems.Add(AnalogOutput.GetRangeName(adamType, byCode))    ' range name
            listViewAO.Items(iIdx).SubItems.Add(AnalogOutput.GetUnitName(adamType, byCode))     ' range name
        Next iIdx
        ' DIO
        txtDITotal.Text = DigitalInput.GetChannelTotal(adamType).ToString()
        txtDOTotal.Text = DigitalOutput.GetChannelTotal(adamType).ToString()
        ' counter
        txtCounterTotal.Text = Counter.GetChannelTotal(adamType).ToString()
        listViewCounter.Items.Clear()
        If Counter.GetModeTotal(adamType) > 0 Then
            listViewCounter.Items.Add(New ListViewItem(Counter.GetModeName(adamType, Adam5080_CounterMode.Bi_Direction)))     ' mode name
            listViewCounter.Items(0).SubItems.Add(Counter.GetUnitName(adamType, Adam5080_CounterMode.Bi_Direction))      ' unit name
            listViewCounter.Items.Add(New ListViewItem(Counter.GetModeName(adamType, Adam5080_CounterMode.Up_Down)))   ' mode name
            listViewCounter.Items(1).SubItems.Add(Counter.GetUnitName(adamType, Adam5080_CounterMode.Up_Down))    ' unit name
            listViewCounter.Items.Add(New ListViewItem(Counter.GetModeName(adamType, Adam5080_CounterMode.Frequency)))  ' mode name
            listViewCounter.Items(2).SubItems.Add(Counter.GetUnitName(adamType, Adam5080_CounterMode.Frequency))    ' unit name
        End If
        ' alarm
        listViewAlarm.Items.Clear()
        For iIdx = 0 To Alarm.GetModeTotal(adamType) - 1
            byCode = Alarm.GetModeCode(adamType, iIdx)
            listViewAlarm.Items.Add(New ListViewItem(Alarm.GetModeName(adamType, byCode))) ' mode name
        Next iIdx
    End Sub

    Private Sub InitAdam6000ComboxList()
        cbxModuleType.Items.Clear()
        cbxModuleType.Items.Add(Adam6000Type.Adam6015)
        cbxModuleType.Items.Add(Adam6000Type.Adam6017)
        cbxModuleType.Items.Add(Adam6000Type.Adam6018)
        cbxModuleType.Items.Add(Adam6000Type.Adam6022)
        cbxModuleType.Items.Add(Adam6000Type.Adam6024)
        cbxModuleType.Items.Add(Adam6000Type.Adam6050)
        cbxModuleType.Items.Add(Adam6000Type.Adam6050W)
        cbxModuleType.Items.Add(Adam6000Type.Adam6051)
        cbxModuleType.Items.Add(Adam6000Type.Adam6051W)
        cbxModuleType.Items.Add(Adam6000Type.Adam6052)
        cbxModuleType.Items.Add(Adam6000Type.Adam6055)
        cbxModuleType.Items.Add(Adam6000Type.Adam6060)
        cbxModuleType.Items.Add(Adam6000Type.Adam6060W)
        cbxModuleType.Items.Add(Adam6000Type.Adam6066)
        cbxModuleType.Items.Add(Adam6000Type.Adam6217)
        cbxModuleType.Items.Add(Adam6000Type.Adam6224)
        cbxModuleType.Items.Add(Adam6000Type.Adam6250)
        cbxModuleType.Items.Add(Adam6000Type.Adam6251)
        cbxModuleType.Items.Add(Adam6000Type.Adam6256)
        cbxModuleType.Items.Add(Adam6000Type.Adam6260)
        cbxModuleType.Items.Add(Adam6000Type.Adam6266)
        cbxModuleType.SelectedIndex = 0
    End Sub

    Private Sub RefreshAdam6000Information()
        Dim byCode As Byte
        Dim usCode As UShort
        Dim intAdamType As Integer

        Dim adamType As Adam6000Type
        adamType = CType(cbxModuleType.SelectedItem, Adam6000Type)
        intAdamType = CType(adamType, Integer)

        ' AI information
        txtAITotal.Text = AnalogInput.GetChannelTotal(adamType).ToString()
        listViewAI.Items.Clear()

        If ((intAdamType = 6017) OrElse ((intAdamType >= 6217) AndAlso (intAdamType <= 6224))) Then
            For iIdx As Integer = 0 To (AnalogInput.GetRangeTotal(adamType, Adam6000_RangeFormat.Ushort) - 1)
                usCode = AnalogInput.GetRangeCode2Byte(adamType, iIdx)
                listViewAI.Items.Add(New ListViewItem("0x" + usCode.ToString("X04")))               ' range code
                listViewAI.Items(iIdx).SubItems.Add(AnalogInput.GetRangeName(adamType, usCode))   ' range name
                listViewAI.Items(iIdx).SubItems.Add(AnalogInput.GetUnitName(adamType, usCode))    ' unit name
            Next iIdx
        Else
            For iIdx As Integer = 0 To (AnalogInput.GetRangeTotal(adamType, Adam6000_RangeFormat.Byte) - 1)
                byCode = AnalogInput.GetRangeCode(adamType, iIdx)
                listViewAI.Items.Add(New ListViewItem("0x" + byCode.ToString("X02")))               ' range code
                listViewAI.Items(iIdx).SubItems.Add(AnalogInput.GetRangeName(adamType, byCode))     ' range name
                listViewAI.Items(iIdx).SubItems.Add(AnalogInput.GetUnitName(adamType, byCode))      ' range name
            Next iIdx
        End If

        ' AO information
        txtAOTotal.Text = AnalogOutput.GetChannelTotal(adamType).ToString()
        listViewAO.Items.Clear()

        If ((intAdamType >= 6217) AndAlso (intAdamType <= 6224)) Then
            For iIdx As Integer = 0 To (AnalogOutput.GetRangeTotal(adamType, Adam6000_RangeFormat.Ushort) - 1)
                usCode = AnalogOutput.GetRangeCode2Byte(adamType, iIdx)
                listViewAO.Items.Add(New ListViewItem("0x" + usCode.ToString("X04")))               ' range code
                listViewAO.Items(iIdx).SubItems.Add(AnalogInput.GetRangeName(adamType, usCode))   ' range name
                listViewAO.Items(iIdx).SubItems.Add(AnalogInput.GetUnitName(adamType, usCode))    ' unit name
            Next iIdx
        Else
            For iIdx As Integer = 0 To (AnalogInput.GetRangeTotal(adamType, Adam6000_RangeFormat.Byte) - 1)
                byCode = AnalogOutput.GetRangeCode(adamType, iIdx)
                listViewAO.Items.Add(New ListViewItem("0x" + byCode.ToString("X02")))               ' range code
                listViewAO.Items(iIdx).SubItems.Add(AnalogOutput.GetRangeName(adamType, byCode))    ' range name
                listViewAO.Items(iIdx).SubItems.Add(AnalogOutput.GetUnitName(adamType, byCode))     ' range name
            Next iIdx
        End If

        ' DIO
        txtDITotal.Text = DigitalInput.GetChannelTotal(adamType).ToString()
        txtDOTotal.Text = DigitalOutput.GetChannelTotal(adamType).ToString()
        ' counter
        txtCounterTotal.Text = Counter.GetChannelTotal(adamType).ToString()
        listViewCounter.Items.Clear()
        If (Counter.GetModeTotal(adamType) > 0) Then
            listViewCounter.Items.Add(New ListViewItem(Counter.GetModeName(adamType, Adam6051_CounterMode.Counter)))  ' mode name
            listViewCounter.Items(0).SubItems.Add(Counter.GetUnitName(adamType, Adam6051_CounterMode.Counter))   ' unit name
            listViewCounter.Items.Add(New ListViewItem(Counter.GetModeName(adamType, Adam6051_CounterMode.Frequency))) ' mode name
            listViewCounter.Items(1).SubItems.Add(Counter.GetUnitName(adamType, Adam6051_CounterMode.Frequency))   ' unit name
        End If
        ' alarm
        listViewAlarm.Items.Clear()
        For iIdx As Integer = 0 To Alarm.GetModeTotal(adamType) - 1
            byCode = Alarm.GetModeCode(adamType, iIdx)
            listViewAlarm.Items.Add(New ListViewItem(Alarm.GetModeName(adamType, byCode))) ' mode name
        Next iIdx
    End Sub
End Class
