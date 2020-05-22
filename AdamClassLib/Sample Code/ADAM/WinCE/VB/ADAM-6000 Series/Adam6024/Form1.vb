Imports Advantech.Adam
Imports System.Net.Sockets

Public Class Form1
    Private m_iCount As Integer
    Private m_iAiTotal As Integer, m_iAoTotal As Integer, m_iDiTotal As Integer, m_iDoTotal As Integer
    Private m_bChEnabled() As Boolean
    Private m_byAiRange() As Byte, m_byAoRange() As Byte
    Private m_bStart As Boolean
    Private adamModbus As AdamSocket
    Private m_Adam6000Type As Adam6000Type
    Private m_szIP As String
    Private m_iPort As Integer


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim iIdx As Integer

        m_bStart = False   ' the action stops at the beginning
        m_szIP = "172.18.3.221" ' modbus slave IP address
        m_iPort = 502    ' modbus TCP port is 502
        adamModbus = New AdamSocket
        adamModbus.SetTimeout(1000, 1000, 1000) ' set timeout for TCP

        m_Adam6000Type = Adam6000Type.Adam6024 ' the sample is for ADAM-6050

        ' modbus current list view item
        m_iAiTotal = AnalogInput.GetChannelTotal(m_Adam6000Type)
        m_iDiTotal = DigitalInput.GetChannelTotal(m_Adam6000Type)
        m_iAoTotal = AnalogOutput.GetChannelTotal(m_Adam6000Type)
        m_iDoTotal = DigitalOutput.GetChannelTotal(m_Adam6000Type)

        m_bChEnabled = New Boolean(m_iAiTotal - 1) {}
        m_byAiRange = New Byte(m_iAiTotal - 1) {}
        m_byAoRange = New Byte(m_iAoTotal - 1) {}

        For iIdx = 0 To m_iAoTotal - 1
            '
            cbxAOChannel.Items.Add(iIdx.ToString())
            '
        Next iIdx
        cbxAOChannel.SelectedIndex = -1

        txtModule.Text = m_Adam6000Type.ToString()
    End Sub

    Private Sub Form1_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If (m_bStart = True) Then
            Timer1.Enabled = False
            adamModbus.Disconnect() ' disconnect slave
        End If
    End Sub

    Private Sub RefreshAiChannelRange(ByVal i_iChannel As Integer)
        Dim byRange As Byte
        If adamModbus.AnalogInput().GetInputRange(i_iChannel, byRange) = True Then
            m_byAiRange(i_iChannel) = byRange
        Else
            txtReadCount.Text += "GetInputRange() failed;"
        End If
    End Sub

    Private Sub RefreshAoChannelRange(ByVal i_iChannel As Integer)
        Dim byRange As Byte
        If adamModbus.AnalogOutput().GetConfiguration(i_iChannel, byRange) = True Then
            m_byAoRange(i_iChannel) = byRange
        Else
            txtReadCount.Text += "GetInputRange() failed;"
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False

        m_iCount = m_iCount + 1 ' increment the reading counter
        txtReadCount.Text = "Read coil " + m_iCount.ToString() + " times..."
        RefreshAiChannelValue()
        RefreshDI()
        RefreshAoChannelValue(cbxAOChannel.SelectedIndex)
        RefreshDO()
        Timer1.Enabled = True
    End Sub

    Private Sub buttonStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonStart.Click
        If (m_bStart = True) Then ' was started
            panelDO.Enabled = False
            panelOutput.Enabled = False
            m_bStart = False  ' starting flag
            Timer1.Enabled = False ' disable timer
            adamModbus.Disconnect() ' disconnect slave
            buttonStart.Text = "Start"
        Else ' was stoped
            If (adamModbus.Connect(m_szIP, ProtocolType.Tcp, m_iPort) = True) Then
                RefreshAiChannelRange(5)
                RefreshAiChannelRange(4)
                RefreshAiChannelRange(3)
                RefreshAiChannelRange(2)
                RefreshAiChannelRange(1)
                RefreshAiChannelRange(0)
                RefreshAoChannelRange(1)
                RefreshAoChannelRange(0)

                cbxAOChannel.SelectedIndex = 0
                RefreshAiChannelEnabled()
                panelDO.Enabled = True
                panelOutput.Enabled = True
                m_iCount = 0 ' reset the reading counter
                Timer1.Enabled = True ' enable timer
                buttonStart.Text = "Stop"
                m_bStart = True ' starting flag
            Else
                MessageBox.Show("Connect to " + m_szIP + " failed", "Error")
            End If
        End If
    End Sub

    Private Sub RefreshOutputValue(ByVal i_iChannel As Integer)
        Dim iStart As Integer = 11 + i_iChannel
        Dim iData() As Integer
        Dim fValue As Single
        Dim szFormat As String
        Dim byRange As Adam6024_OutputRange

        If (adamModbus.Modbus().ReadInputRegs(iStart, 1, iData) = True) Then
            fValue = AnalogOutput.GetScaledValue(m_Adam6000Type, m_byAoRange(i_iChannel), iData(0))
            ' 
            szFormat = AnalogOutput.GetFloatFormat(m_Adam6000Type, m_byAoRange(i_iChannel))
            byRange = m_byAoRange(i_iChannel)

            If (byRange = Adam6024_OutputRange.mA_0To20) Then ' 0~20mA
                lblLow.Text = "0 mA"
                lblHigh.Text = "20 mA"
                trackBar1.Value = Convert.ToInt32(fValue * trackBar1.Maximum / 20)
            ElseIf (byRange = Adam6024_OutputRange.mA_4To20) Then ' 4~20mA
                lblLow.Text = "4 mA"
                lblHigh.Text = "20 mA"
                trackBar1.Value = Convert.ToInt32((fValue - 4.0) * trackBar1.Maximum / 16)
            Else ' 0~10V
                lblLow.Text = "0 V"
                lblHigh.Text = "10 V"
                trackBar1.Value = Convert.ToInt32(fValue * trackBar1.Maximum / 10)
            End If
            txtOutputValue.Text = fValue.ToString(szFormat)
        Else
            txtReadCount.Text += "ReadInputRegs() failed"
        End If
    End Sub
    Private Sub RefreshAiChannelEnabled()
        Dim bEnabled() As Boolean

        If (adamModbus.AnalogInput().GetChannelEnabled(m_iAiTotal, bEnabled) = True) Then
            Array.Copy(bEnabled, 0, m_bChEnabled, 0, m_iAiTotal)
            chkboxCh0.Checked = m_bChEnabled(0)
            chkboxCh1.Checked = m_bChEnabled(1)
            chkboxCh2.Checked = m_bChEnabled(2)
            chkboxCh3.Checked = m_bChEnabled(3)
            chkboxCh4.Checked = m_bChEnabled(4)
            chkboxCh5.Checked = m_bChEnabled(5)
            If (m_bChEnabled(0) = False) Then
                txtCh0.Text = ""
            End If
            If (m_bChEnabled(1) = False) Then
                txtCh1.Text = ""
            End If
            If (m_bChEnabled(2) = False) Then
                txtCh2.Text = ""
            End If
            If (m_bChEnabled(3) = False) Then
                txtCh3.Text = ""
            End If
            If (m_bChEnabled(4) = False) Then
                txtCh4.Text = ""
            End If
            If (m_bChEnabled(5) = False) Then
                txtCh5.Text = ""
            End If
        Else
            txtReadCount.Text += "GetChannelEnabled() failed"
        End If
    End Sub

    Private Sub RefreshDI()
        Dim iStart As Integer = 1
        Dim bData() As Boolean

        If (adamModbus.Modbus().ReadCoilStatus(iStart, m_iDiTotal, bData) = True) Then
            txtDICh0.Text = bData(0).ToString()
            txtDICh1.Text = bData(1).ToString()
        Else
            txtDICh0.Text = "Fail"
            txtDICh1.Text = "Fail"
        End If
    End Sub

    Private Sub RefreshDO()
        Dim iStart As Integer = 17
        Dim bData() As Boolean

        If (adamModbus.Modbus().ReadCoilStatus(iStart, m_iDoTotal, bData) = True) Then
            txtDOCh0.Text = bData(0).ToString()
            txtDOCh1.Text = bData(1).ToString()
        Else
            txtDOCh0.Text = "Fail"
            txtDOCh1.Text = "Fail"
        End If
    End Sub

    Private Sub RefreshSingleAiChannel(ByVal i_iIndex As Integer, ByRef txtCh As TextBox, ByVal fValue As Single, ByVal i_iStatus As Integer)
        Dim szFormat As String

        If (m_bChEnabled(i_iIndex) = True) Then
            If (i_iStatus = 0) Then
                szFormat = AnalogInput.GetFloatFormat(m_Adam6000Type, m_byAiRange(i_iIndex))
                txtCh.Text = fValue.ToString(szFormat) + " " + AnalogInput.GetUnitName(m_Adam6000Type, m_byAiRange(i_iIndex))
            ElseIf (i_iStatus = 1) Then
                txtCh.Text = "Over(H)"
            ElseIf (i_iStatus = 2) Then
                txtCh.Text = "Over(L)"
            Else
                txtCh.Text = "Invalid(R)"
            End If
        End If
    End Sub

    Private Sub RefreshAiChannelValue()
        Dim iStart As Integer = 1, iStatusStart As Integer = 21
        Dim iIdx As Integer
        Dim iData() As Integer
        Dim fValue() As Single = New Single(m_iAiTotal - 1) {}
        Dim iStatus() As Integer = New Integer(m_iAiTotal - 1) {}

        If (adamModbus.Modbus().ReadInputRegs(iStart, m_iAiTotal, iData) And adamModbus.Modbus().ReadInputRegs(iStatusStart, m_iAiTotal, iStatus)) Then
            For iIdx = 0 To m_iAiTotal - 1
                fValue(iIdx) = AnalogInput.GetScaledValue(m_Adam6000Type, m_byAiRange(iIdx), iData(iIdx))
            Next iIdx

            RefreshSingleAiChannel(0, txtCh0, fValue(0), iStatus(0))
            RefreshSingleAiChannel(1, txtCh1, fValue(1), iStatus(1))
            RefreshSingleAiChannel(2, txtCh2, fValue(2), iStatus(2))
            RefreshSingleAiChannel(3, txtCh3, fValue(3), iStatus(3))
            RefreshSingleAiChannel(4, txtCh4, fValue(4), iStatus(4))
            RefreshSingleAiChannel(5, txtCh5, fValue(5), iStatus(5))
        Else
            txtReadCount.Text += "ReadInputRegs() failed;"
        End If
    End Sub

    Private Sub RefreshAoChannelValue(ByVal i_iChannel As Integer)
        Dim iStart As Integer = 11 + i_iChannel
        Dim iData() As Integer
        Dim fValue As Single
        Dim szFormat As String

        If (adamModbus.Modbus().ReadInputRegs(iStart, 1, iData)) Then
            fValue = AnalogOutput.GetScaledValue(m_Adam6000Type, m_byAoRange(i_iChannel), iData(0))
            ' 
            szFormat = AnalogOutput.GetFloatFormat(m_Adam6000Type, m_byAoRange(i_iChannel))
            '
            txtCurrentValue.Text = fValue.ToString(szFormat) + " " + AnalogOutput.GetUnitName(m_Adam6000Type, m_byAoRange(i_iChannel))
        Else
            txtReadCount.Text += "ReadInputRegs() failed;"
        End If
    End Sub

    Private Sub btnApplyOutput_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApplyOutput.Click
        Dim iChannel As Integer = cbxAOChannel.SelectedIndex
        Dim iStart As Integer = 11 + iChannel
        Dim iValue As Integer

        Timer1.Enabled = False
        iValue = trackBar1.Value
        If (iValue > 4095) Then
            iValue = 4095
        End If
        If (adamModbus.Modbus().PresetSingleReg(iStart, iValue) = True) Then
            System.Threading.Thread.Sleep(500)
            RefreshAoChannelValue(iChannel)
            RefreshOutputValue(iChannel)
        Else
            MessageBox.Show("Change current value failed!", "Error")
        End If
        Timer1.Enabled = True
    End Sub

    Private Sub btnCh_Click(ByVal i_iCh As Integer, ByVal txtBox As TextBox)
        Dim iOnOff As Integer, iStart As Integer = 17 + i_iCh

        timer1.Enabled = False
        If (txtBox.Text = "True") Then ' was ON, now set to OFF
            iOnOff = 0
        Else
            iOnOff = 1
        End If
        If (adamModbus.Modbus().ForceSingleCoil(iStart, iOnOff) = True) Then
            RefreshDO()
        Else
            MessageBox.Show("Set digital output failed!", "Error")
        End If
        timer1.Enabled = True
    End Sub

    Private Sub btnDOCh0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDOCh0.Click
        btnCh_Click(0, txtDOCh0)
    End Sub

    Private Sub btnDOCh1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDOCh1.Click
        btnCh_Click(1, txtDOCh1)
    End Sub

    Private Sub trackBar1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trackBar1.ValueChanged
        Dim iCh As Integer
        Dim fValue As Single
        Dim byRange As Adam6024_OutputRange

        If (m_bStart = True) Then ' was started
            Timer1.Enabled = False
            iCh = cbxAOChannel.SelectedIndex
            fValue = Convert.ToSingle(trackBar1.Value)
            byRange = m_byAoRange(iCh)
            If (byRange = Adam6024_OutputRange.mA_0To20) Then ' 0~20mA
                fValue = fValue * 20 / trackBar1.Maximum
            ElseIf (byRange = Adam6024_OutputRange.mA_4To20) Then ' 4~20mA
                fValue = 4.0F + fValue * 16 / trackBar1.Maximum
            Else ' 0~10V
                fValue = fValue * 10 / trackBar1.Maximum
            End If
            txtOutputValue.Text = fValue.ToString("0.000")
            Timer1.Enabled = True
        End If
    End Sub

    Private Sub cbxAOChannel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxAOChannel.SelectedIndexChanged
        Dim iChannel As Integer = cbxAOChannel.SelectedIndex
        Timer1.Enabled = False
        RefreshAoChannelValue(iChannel)
        RefreshOutputValue(iChannel)
        Timer1.Enabled = True
    End Sub
End Class
