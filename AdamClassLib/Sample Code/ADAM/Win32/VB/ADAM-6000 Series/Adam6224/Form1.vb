Imports System.Globalization
Imports System.Net.Sockets
Imports Advantech.Adam
Public Class Form1
    Private m_bStart As Boolean
    Private adamModbus As AdamSocket
    Private m_Adam6000Type As Adam6000Type
    Private m_szIP As String
    Private m_iPort As Integer
    Private m_iCount As Integer
    Private m_iAoChTotal, m_iAoRangeTotal As Integer
    Private m_iAoValueStartAddr As Integer
    Private m_iDiTotal As Integer
    Private m_DiValueStartAddr As Integer
    Private m_fHigh, m_fLow As Single
    Private m_usRange(), m_usAoValue() As UShort

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        m_bStart = False            'the action stops at the beginning
        m_szIP = "172.18.3.93"  'modbus slave IP address
        m_iPort = 502               'modbus TCP port is 502
        adamModbus = New AdamSocket()
        adamModbus.SetTimeout(1000, 1000, 1000) 'set timeout for TCP
        adamModbus.AdamSeriesType = AdamType.Adam6200
        adamModbus.Connect(m_szIP, ProtocolType.Tcp, m_iPort)

        m_Adam6000Type = Adam6000Type.Adam6224 'the sample is for ADAM-6224

        m_iAoChTotal = AnalogOutput.GetChannelTotal(m_Adam6000Type)
        m_iAoRangeTotal = AnalogOutput.GetRangeTotal(m_Adam6000Type, Adam6000_RangeFormat.Ushort)
        m_iDiTotal = DigitalInput.GetChannelTotal(m_Adam6000Type)
        m_DiValueStartAddr = 1
        m_iAoValueStartAddr = 1
        txtModule.Text = m_Adam6000Type.ToString()
        m_usRange = New UShort(m_iAoChTotal) {}
        m_usAoValue = New UShort(m_iAoChTotal) {}

        InitialDiDgViewModbusGeneralRow(m_DiValueStartAddr, m_iDiTotal, dgViewDiChannelInfo)

        InitialAoDgViewModbusGeneralRow(m_iAoValueStartAddr, m_iAoChTotal, dgViewAoChannelInfo)

        For i As Integer = 0 To (m_iAoChTotal - 1)
            cbxAoChannel.Items.Add(i.ToString())
        Next i

        cbxAoChannel.Items.Add("All")

        If (m_Adam6000Type = Adam6000Type.Adam6224) Then

            For i_iIndex As Integer = 0 To (m_iAoRangeTotal - 1)
                Dim usRangeCode As UShort
                Dim strRangeName As String
                usRangeCode = AnalogOutput.GetRangeCode2Byte(m_Adam6000Type, i_iIndex)
                strRangeName = AnalogOutput.GetRangeName(m_Adam6000Type, usRangeCode)
                cbxAoOutputRange.Items.Add(New ComboItem(strRangeName, usRangeCode))
            Next

        End If

        For i As Integer = 0 To (m_iAoChTotal - 1)
            RefreshAoChannelRange(i, False)
        Next i

        RefreshAoModbusValue(m_iAoValueStartAddr, m_iAoChTotal, dgViewAoChannelInfo)
        cbxAoChannel.SelectedIndex = 0
    End Sub
    Private Sub InitialDiDgViewModbusGeneralRow(ByVal iDiChStart As Integer, ByVal iDiChTotal As Integer, ByRef targetDataGridView As DataGridView)
        Dim iPos, iIdx As Integer
        Dim dgvRow As DataGridViewRow
        Dim dgvCell As DataGridViewCell
        targetDataGridView.Rows.Clear()
        targetDataGridView.Columns(0).Width = 30
        targetDataGridView.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
        targetDataGridView.Columns(1).Width = 30
        targetDataGridView.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        targetDataGridView.Columns(2).Width = 30
        targetDataGridView.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        targetDataGridView.Columns(3).Width = 30
        targetDataGridView.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
        targetDataGridView.Columns(4).Width = 95
        targetDataGridView.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable

        iPos = iDiChStart
        For iIdx = 0 To (iDiChTotal - 1)
            dgvRow = New DataGridViewRow()
            'Text type : Location
            dgvCell = New DataGridViewTextBoxCell()
            dgvCell.Value = iPos.ToString("D5")
            dgvRow.Cells.Add(dgvCell)
            'Text type : Type
            dgvCell = New DataGridViewTextBoxCell()
            dgvCell.Value = "DI"
            dgvRow.Cells.Add(dgvCell)
            'Text type : Ch No.
            dgvCell = New DataGridViewTextBoxCell()
            dgvCell.Value = iIdx.ToString()
            dgvRow.Cells.Add(dgvCell)
            'Text type : Bool
            dgvCell = New DataGridViewTextBoxCell()
            dgvCell.Value = "BOOL"
            dgvRow.Cells.Add(dgvCell)
            'Text type : Mode Value
            dgvCell = New DataGridViewTextBoxCell()
            dgvCell.Value = ""
            dgvRow.Cells.Add(dgvCell)

            targetDataGridView.Rows.Add(dgvRow)

            iPos = iPos + 1

        Next iIdx
    End Sub

    Private Sub InitialAoDgViewModbusGeneralRow(ByVal iAiChStart As Integer, ByVal iAiChTotal As Integer, ByRef targetDataGridView As DataGridView)
        Dim iPos, iIdx As Integer
        Dim dgvRow As DataGridViewRow
        Dim dgvCell As DataGridViewCell
        targetDataGridView.Rows.Clear()
        targetDataGridView.Columns(0).Width = 50
        targetDataGridView.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
        targetDataGridView.Columns(1).Width = 35
        targetDataGridView.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        targetDataGridView.Columns(2).Width = 30
        targetDataGridView.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        targetDataGridView.Columns(3).Width = 63
        targetDataGridView.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
        targetDataGridView.Columns(4).Width = 63
        targetDataGridView.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
        targetDataGridView.Columns(5).Width = 63
        targetDataGridView.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
        targetDataGridView.Columns(6).Width = 90
        targetDataGridView.Columns(6).SortMode = DataGridViewColumnSortMode.NotSortable

        iPos = 40000 + iAiChStart
        For iIdx = 0 To (iAiChTotal - 1)
            dgvRow = New DataGridViewRow()
            'Text type : Location
            dgvCell = New DataGridViewTextBoxCell()
            dgvCell.Value = iPos.ToString("D5")
            dgvRow.Cells.Add(dgvCell)
            'Text type : Type
            dgvCell = New DataGridViewTextBoxCell()
            dgvCell.Value = "AO"
            dgvRow.Cells.Add(dgvCell)
            'Text type : Ch No.
            dgvCell = New DataGridViewTextBoxCell()
            dgvCell.Value = iIdx.ToString()
            dgvRow.Cells.Add(dgvCell)
            'Text type : Value[Dec]
            dgvCell = New DataGridViewTextBoxCell()
            dgvCell.Value = "******"
            dgvRow.Cells.Add(dgvCell)
            'Text type : Value[Hex]
            dgvCell = New DataGridViewTextBoxCell()
            dgvCell.Value = "******"
            dgvRow.Cells.Add(dgvCell)
            'Text type : Value[Eng]
            dgvCell = New DataGridViewTextBoxCell()
            dgvCell.Value = "******"
            dgvRow.Cells.Add(dgvCell)
            'Text type : Range Description
            dgvCell = New DataGridViewTextBoxCell()
            dgvCell.Value = ""
            dgvRow.Cells.Add(dgvCell)

            targetDataGridView.Rows.Add(dgvRow)
            iPos = iPos + 1
        Next iIdx
    End Sub

    Private Sub RefreshAoChannelRange(ByVal i_iChannel As Integer, ByVal i_bRefresh As Boolean)

        Dim usRange As UShort
        usRange = (CType(cbxAoOutputRange.Items(0), ComboItem)).GetCode()

        If (adamModbus.AnalogOutput().GetOutputRange(i_iChannel, usRange)) Then
            m_usRange(i_iChannel) = usRange
            If (i_bRefresh) Then
                For i As Integer = 0 To (cbxAoOutputRange.Items.Count - 1)
                    If (CType(cbxAoOutputRange.Items(i), ComboItem).GetCode() = usRange) Then
                        cbxAoOutputRange.SelectedIndex = i
                        Return
                    End If
                Next i
            End If
        Else
            MessageBox.Show("GetRangeCode() failed;")
        End If
    End Sub

    Private Function RefreshAoModbusValue(ByVal i_AoValueStart As Integer, ByVal i_AoChTotal As Integer, ByRef dgViewModbus As DataGridView) As Boolean
        Dim iIdx As Integer
        Dim iValueData() As Integer
        Dim szRange, szFormat As String

        If (adamModbus.Modbus().ReadInputRegs(i_AoValueStart, i_AoChTotal, iValueData)) Then
            For iIdx = 0 To (i_AoChTotal - 1)
                szRange = AnalogOutput.GetRangeName(m_Adam6000Type, m_usRange(iIdx))
                szFormat = AnalogOutput.GetFloatFormat(m_Adam6000Type, m_usRange(iIdx))
                m_usAoValue(iIdx) = Convert.ToUInt16(iValueData(iIdx))
                dgViewModbus.Rows(iIdx).Cells(3).Value = m_usAoValue(iIdx).ToString()
                dgViewModbus.Rows(iIdx).Cells(4).Value = m_usAoValue(iIdx).ToString("X04")
                dgViewModbus.Rows(iIdx).Cells(5).Value = AnalogOutput.GetScaledValue(m_Adam6000Type, m_usRange(iIdx), m_usAoValue(iIdx)).ToString(szFormat)
                dgViewModbus.Rows(iIdx).Cells(6).Value = szRange
            Next iIdx
            Return True
        End If
        Return False
    End Function

    Private Function RefreshDiModbusValue(ByVal i_DiValueStart As Integer, ByVal i_DiChTotal As Integer, ByRef dgViewModbus As DataGridView) As Boolean
        Dim iIdx As Integer
        Dim iValueData() As Boolean

        If (adamModbus.Modbus().ReadCoilStatus(i_DiValueStart, i_DiChTotal, iValueData)) Then

            For iIdx = 0 To (i_DiChTotal - 1)
                dgViewModbus.Rows(iIdx).Cells(4).Value = iValueData(iIdx).ToString()
            Next iIdx
            Return True
        End If
        Return False
    End Function
    Protected Class ComboItem
        Inherits Object

        Protected m_Name As String
        Protected m_Code As UShort
        Public Sub New(ByVal name As String, ByVal code As UShort)
            m_Name = name
            m_Code = code
        End Sub
        Public Property GetCode() As UShort
            Get
                Return m_Code
            End Get
            Set(ByVal value As UShort)
                m_Code = value
            End Set
        End Property
        Public Overrides Function ToString() As String
            Return m_Name
        End Function
    End Class

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If (m_bStart) Then
            timer1.Enabled = False
            adamModbus.Disconnect()  'disconnect slave
        End If
    End Sub

    Private Sub timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timer1.Tick
        timer1.Enabled = False
        m_iCount = m_iCount + 1  'increment the reading counter

        If (tabControlMain.SelectedIndex = 0) Then
            If (RefreshDiModbusValue(m_DiValueStartAddr, m_iDiTotal, dgViewDiChannelInfo)) Then
                txtReadCount.Text = "Read Coil Status " + m_iCount.ToString() + " times..."
            Else
                txtReadCount.Text = "Read Coil Status failed !"
            End If
        Else
            If (RefreshAoModbusValue(m_iAoValueStartAddr, m_iAoChTotal, dgViewAoChannelInfo)) Then
                txtReadCount.Text = "Read Registers " + m_iCount.ToString() + " times..."
            Else
                txtReadCount.Text = "Read Registers failed !"

            End If
        End If
        timer1.Enabled = True
    End Sub

    Private Sub buttonStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonStart.Click
        If (m_bStart) Then 'was started
            m_bStart = False 'starting flag
            timer1.Enabled = False 'disable timer
            buttonStart.Text = "Start"
            btnApplyAoSelRange.Enabled = False
            btnSetAoValue.Enabled = False
        Else    'was stoped
            m_iCount = 0 'reset the reading counter
            timer1.Enabled = True 'enable timer
            buttonStart.Text = "Stop"
            btnApplyAoSelRange.Enabled = True
            btnSetAoValue.Enabled = True
            m_bStart = True 'starting flag
        End If
    End Sub

    Private Sub tabControlMain_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabControlMain.SelectedIndexChanged
        m_iCount = 0
    End Sub

    Private Sub cbxAoChannel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxAoChannel.SelectedIndexChanged
        Dim iRetryLimit As Integer = 10
        Dim iRetryCount As Integer = 0

        If (cbxAoChannel.SelectedIndex <> m_iAoChTotal) Then
            If (timer1.Enabled) Then
                timer1.Enabled = False
                RefreshAoChannelRange(cbxAoChannel.SelectedIndex, True)
                If (cbxAoChannel.SelectedIndex >= 0) Then
                    dgViewAoChannelInfo.Rows(cbxAoChannel.SelectedIndex).Selected = True
                End If
                timer1.Enabled = True
            Else
                RefreshAoChannelRange(cbxAoChannel.SelectedIndex, True)
                If (cbxAoChannel.SelectedIndex >= 0) Then
                    dgViewAoChannelInfo.Rows(cbxAoChannel.SelectedIndex).Selected = True
                End If
            End If

            gpBoxAoSetValue.Visible = True

            For i As Integer = 0 To (iRetryLimit - 1)
                AnalogOutput.GetRangeHighLow(m_Adam6000Type, m_usRange(cbxAoChannel.SelectedIndex), m_fHigh, m_fLow)
                If ((m_fHigh = 0.0F) And (m_fLow = 0.0F)) Then
                    iRetryCount = iRetryCount + 1
                    System.Threading.Thread.Sleep(150)
                    Continue For
                Else
                    Exit For
                End If
            Next i

            txtSelAoChannel.Text = cbxAoChannel.SelectedIndex.ToString()
            RefreshOutputPanel(m_fHigh, m_fLow)

            If (iRetryCount >= iRetryLimit) Then
                MessageBox.Show("AnalogOutput.GetRangeHighLow failed! Please retry again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            End If
        Else
            gpBoxAoSetValue.Visible = False
        End If
    End Sub

    Public Sub RefreshOutputPanel(ByVal fHigh As Single, ByVal fLow As Single)
        Dim fOutputVal As Single

        fOutputVal = AnalogOutput.GetScaledValue(m_Adam6000Type, m_usRange(cbxAoChannel.SelectedIndex), m_usAoValue(cbxAoChannel.SelectedIndex))

        labAoHigh.Text = fHigh.ToString()
        labAoLow.Text = fLow.ToString()
        txtAoOutputVal.Text = fOutputVal.ToString("0.000")

        Try
            tBarAoOutputVal.Value = Convert.ToInt32(tBarAoOutputVal.Minimum + (tBarAoOutputVal.Maximum - tBarAoOutputVal.Minimum) * (fOutputVal - fLow) / (fHigh - fLow))
        Catch
            tBarAoOutputVal.Value = 0
        End Try
    End Sub

    Private Sub ApplyAoOutputRange(ByVal idxChannel As Integer, ByVal idxOutputRange As Integer, ByVal bShowDone As Boolean)
        Dim iChannel As Integer
        Dim usOutputRange As UShort

        If (idxChannel <> m_iAoChTotal) Then
            usOutputRange = (CType(cbxAoOutputRange.Items(idxOutputRange), ComboItem)).GetCode()
            iChannel = idxChannel

            If (adamModbus.AnalogOutput().SetOutputRange(iChannel, usOutputRange)) Then
                System.Threading.Thread.Sleep(50)
                If (bShowDone) Then
                    MessageBox.Show("Change output range done!", "Information")
                End If
                RefreshAoChannelRange(iChannel, False)
            Else
                MessageBox.Show("Change output range failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End If
        Else
            Dim bRet As Boolean = True
            usOutputRange = (CType(cbxAoOutputRange.Items(idxOutputRange), ComboItem)).GetCode()
            Dim prompt As FormPrompt
            prompt = New FormPrompt()
            prompt.label1.Text = "Set Output Range....."
            prompt.Show()
            prompt.IncreaseBar(0)
            prompt.Update()

            For iChannel = 0 To (m_iAoChTotal - 1)
                If (usOutputRange <> m_usRange(iChannel)) Then
                    bRet = adamModbus.AnalogOutput().SetOutputRange(iChannel, usOutputRange)
                    System.Threading.Thread.Sleep(100)
                End If
                prompt.IncreaseBar((prompt.progressBar1.Maximum * iChannel) / m_iAoChTotal)
                prompt.Update()
            Next iChannel

            If (bRet) Then
                prompt.IncreaseBar(100)
                prompt.Update()
                prompt.Close()
                prompt = Nothing
            Else
                prompt.Close()
                prompt = Nothing
            End If

            If (bRet) Then
                If (bShowDone) Then
                    MessageBox.Show("Change range configuration done!", "Information")
                End If
                System.Threading.Thread.Sleep(500)
                For iChannel = 0 To (m_iAoChTotal - 1)
                    RefreshAoChannelRange(iChannel, False)
                Next iChannel
            Else
                MessageBox.Show("Change range configuration failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End If
        End If
    End Sub

    Private Sub btnApplyAoSelRange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApplyAoSelRange.Click
        If (timer1.Enabled) Then
            timer1.Enabled = False
            ApplyAoOutputRange(cbxAoChannel.SelectedIndex, cbxAoOutputRange.SelectedIndex, True)
            timer1.Enabled = True
        Else
            ApplyAoOutputRange(cbxAoChannel.SelectedIndex, cbxAoOutputRange.SelectedIndex, True)
        End If

        cbxAoChannel_SelectedIndexChanged(Me, Nothing)
    End Sub

    Public Shared Function ConvertUSSingle(ByVal i_szSingle As String) As Single
        Dim numberFormatInfo As NumberFormatInfo
        Dim fVal As Single
        numberFormatInfo = New CultureInfo("en-US", False).NumberFormat
        fVal = 0.0F

        If ((i_szSingle <> Nothing) And (i_szSingle.Length > 0)) Then
            Try
                fVal = Convert.ToSingle(i_szSingle)
            Catch
                System.Windows.Forms.MessageBox.Show("Invalid value: " + i_szSingle)
            End Try
        End If

        Return fVal
    End Function

    Private Sub btnSetAoValue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetAoValue.Click
        Dim fVal, fHigh, fLow As Single
        Dim usValue As Short
        Dim iPresetRegAddr As Integer = 0
        Dim i_byResolution As Byte = 12
        Dim strVal As String = txtAoOutputVal.Text.ToString().Trim()

        If (strVal.Length = 0) Then
            MessageBox.Show("Illegal value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            Return
        End If

        fVal = ConvertUSSingle(strVal)
        AnalogOutput.GetRangeHighLow(m_Adam6000Type, m_usRange(cbxAoChannel.SelectedIndex), fHigh, fLow)

        If (fHigh - fLow = 0) Then
            MessageBox.Show("GetRangeHighLow() failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            Return
        End If

        If (fVal > fHigh Or fVal < fLow) Then
            MessageBox.Show("Illegal value! Please enter the value " + fLow.ToString() + " ~ " + fHigh.ToString() + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
            Return
        End If

        usValue = Convert.ToUInt16((Convert.ToSingle(System.Math.Pow(2, i_byResolution) - 1) / (fHigh - fLow)) * (fVal - fLow))

        iPresetRegAddr = m_iAoValueStartAddr + cbxAoChannel.SelectedIndex

        If (adamModbus.Modbus().PresetSingleReg(iPresetRegAddr, Convert.ToInt32(usValue))) Then
            m_usAoValue(cbxAoChannel.SelectedIndex) = usValue
        Else
            MessageBox.Show("PresetSingleReg() failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1)
        End If

        cbxAoChannel_SelectedIndexChanged(Me, Nothing)
    End Sub

    Private Sub txtAoOutputVal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAoOutputVal.KeyPress
        If ((e.KeyChar < "0") And (e.KeyChar > "9")) Then
            e.Handled = False
        ElseIf ((e.KeyChar = ".") Or (e.KeyChar = ",")) Then
            e.Handled = False
        ElseIf (e.KeyChar = Chr(8)) Then
            e.Handled = False
        ElseIf (e.KeyChar = Chr(45)) Then
            e.Handled = False
        ElseIf (e.KeyChar = Chr(13)) Then 'Enter
            btnSetAoValue_Click(Me, Nothing)
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtAoOutputVal_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtAoOutputVal.MouseDown
        txtAoOutputVal.SelectAll()
    End Sub

    Private Sub tBarAoOutputVal_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tBarAoOutputVal.MouseDown
        txtAoOutputVal.SelectAll()
    End Sub

    Private Sub tBarAoOutputVal_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tBarAoOutputVal.ValueChanged
        Dim fVal As Single
        fVal = (m_fHigh - m_fLow) * (tBarAoOutputVal.Value - tBarAoOutputVal.Minimum) / (tBarAoOutputVal.Maximum - tBarAoOutputVal.Minimum) + m_fLow
        txtAoOutputVal.Text = fVal.ToString("0.000")
    End Sub
End Class
