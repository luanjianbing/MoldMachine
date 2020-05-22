Imports Advantech.Adam
Imports Advantech.Common

Public Class Form1
    Private m_iCom As Integer, m_iAddr As Integer, m_iSlot As Integer, m_iCount As Integer, m_iChTotal As Integer
    Private m_bStart As Boolean, m_b5000 As Boolean
    Private m_byRange() As Byte
    Private m_szIP As String
    Private m_Adam5000Type As Adam5000Type
    Private adamCom As AdamCom
    Private adamSocket As AdamSocket

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim iIdx As Integer
        m_b5000 = True ' set to true for module on ADAM-5000 set to false for module on ADAM-5000/TCP
        If m_b5000 = True Then
            m_iCom = 2  ' using COM2
            adamCom = New AdamCom(m_iCom)
            adamCom.Checksum = False ' disbale checksum
        Else
            m_szIP = "172.18.3.179"
            adamSocket = New AdamSocket
            adamSocket.SetTimeout(1000, 1000, 1000) ' set timeout
        End If
        m_iAddr = 1 ' the slave address is 1
        m_iSlot = 0 ' the slot index of the module
        m_iCount = 0 ' the counting start from 0
        m_bStart = False
        m_Adam5000Type = Adam5000Type.Adam5024 ' the sample is for ADAM-5024

        m_iChTotal = AnalogOutput.GetChannelTotal(m_Adam5000Type)
        m_byRange = New Byte(m_iChTotal - 1) {} ' 0~(m_iChTotal-1)
        For iIdx = 0 To (m_iChTotal - 1)
            cbxChannel.Items.Add(iIdx.ToString())
        Next iIdx
        txtModule.Text = m_Adam5000Type.ToString()
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If m_bStart = True Then
            Timer1.Enabled = False ' disable timer
            If m_b5000 = True Then
                adamCom.CloseComPort() ' close the COM port
            Else
                adamSocket.Disconnect()
            End If
        End If
    End Sub

    Private Sub buttonStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonStart.Click
        If m_bStart = True Then ' was started
            m_bStart = False
            Timer1.Enabled = False
            If (m_b5000) Then
                adamCom.CloseComPort()
            Else
                adamSocket.Disconnect()
            End If
            buttonStart.Text = "Start"
        Else
            If m_b5000 = True Then
                If adamCom.OpenComPort() = True Then
                    ' set COM port state, 9600,N,8,1
                    adamCom.SetComPortState(Baudrate.Baud_9600, Databits.Eight, Parity.None, Stopbits.One)
                    ' set COM port timeout
                    adamCom.SetComPortTimeout(500, 500, 0, 500, 0)
                    m_iCount = 0 ' reset the reading counter
                    If RefreshChannelRange() = True Then
                        cbxChannel.SelectedIndex = 0
                        panelAO.Enabled = True
                        Timer1.Enabled = True ' enable timer
                        buttonStart.Text = "Stop"
                        m_bStart = True ' starting flag
                    Else
                        adamCom.CloseComPort()
                    End If
                Else
                    MessageBox.Show("Failed to open COM port!", "Error")
                End If
            Else
                If adamSocket.Connect(AdamType.Adam5000Tcp, m_szIP, System.Net.Sockets.ProtocolType.Tcp) = True Then
                    m_iCount = 0 ' reset the reading counter
                    If RefreshChannelRange() = True Then
                        cbxChannel.SelectedIndex = 0
                        panelAO.Enabled = True
                        Timer1.Enabled = True ' enable timer
                        buttonStart.Text = "Stop"
                        m_bStart = True ' starting flag
                    Else
                        adamSocket.Disconnect()
                    End If
                Else
                    MessageBox.Show("Failed to connect to " + m_szIP + "!", "Error")
                End If
            End If
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        m_iCount = m_iCount + 1
        txtReadCount.Text = "Polling " + m_iCount.ToString() + " times..."
        RefreshChannelValue(0, txtAO0)
        RefreshChannelValue(1, txtAO1)
        RefreshChannelValue(2, txtAO2)
        RefreshChannelValue(3, txtAO3)
    End Sub

    Private Function RefreshRange(ByVal i_iChannel As Integer) As Boolean
        Dim byRange As Byte, bySlewrate As Byte
        Dim bRet As Boolean

        If m_b5000 = True Then
            bRet = adamCom.AnalogOutput(m_iAddr).GetConfiguration(m_iSlot, i_iChannel, byRange, bySlewrate)
        Else
            bRet = adamSocket.AnalogOutput(m_iAddr).GetConfiguration(m_iSlot, i_iChannel, byRange)
        End If
        If bRet = True Then
            m_byRange(i_iChannel) = byRange
        End If
        Return bRet
    End Function

    Private Function RefreshChannelRange() As Boolean
        Dim bRet As Boolean
        Dim iIdx As Integer

        bRet = True
        For iIdx = 0 To (m_iChTotal - 1)
            bRet = RefreshRange(iIdx)
            If bRet = False Then
                MessageBox.Show("Get range failed", "Error")
                Exit For
            End If
        Next iIdx
        Return bRet
    End Function

    Private Sub RefreshChannelValue(ByVal i_iChannel As Integer, ByVal i_txtCh As TextBox)
        Dim iStart As Integer
        Dim iData() As Integer
        Dim fValue As Single
        Dim szFormat As String

        iStart = m_iSlot * 8 + i_iChannel + 1
        If m_b5000 = True Then
            If adamCom.AnalogOutput(m_iAddr).GetCurrentValue(m_iSlot, i_iChannel, fValue) = True Then
                szFormat = AnalogOutput.GetFloatFormat(m_Adam5000Type, m_byRange(i_iChannel))
                i_txtCh.Text = fValue.ToString(szFormat) + " " + AnalogOutput.GetUnitName(m_Adam5000Type, m_byRange(i_iChannel))
            Else
                i_txtCh.Text = "Failed to get"
            End If
        Else
            If adamSocket.Modbus(m_iAddr).ReadInputRegs(iStart, 1, iData) = True Then
                fValue = AnalogOutput.GetScaledValue(m_Adam5000Type, m_byRange(i_iChannel), iData(0))
                szFormat = AnalogOutput.GetFloatFormat(m_Adam5000Type, m_byRange(i_iChannel))
                i_txtCh.Text = fValue.ToString(szFormat) + " " + AnalogOutput.GetUnitName(m_Adam5000Type, m_byRange(i_iChannel))
            Else
                i_txtCh.Text = "Failed to get"
            End If
        End If
    End Sub

    Private Sub cbxChannel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxChannel.SelectedIndexChanged
        Dim iCh As Integer
        Dim fValue As Single
        Dim byRange As Adam5024_OutputRange

        Timer1.Enabled = False
        iCh = cbxChannel.SelectedIndex
        fValue = Convert.ToSingle(trackBar1.Value)
        byRange = m_byRange(iCh)
        If byRange = Adam5024_OutputRange.mA_0To20 Then ' 0~20mA
            lblLow.Text = "0 mA"
            lblHigh.Text = "20 mA"
            fValue = fValue * 20 / trackBar1.Maximum
        ElseIf (byRange = Adam5024_OutputRange.mA_4To20) Then ' 4~20mA
            lblLow.Text = "4 mA"
            lblHigh.Text = "20 mA"
            fValue = 4.0F + fValue * 16 / trackBar1.Maximum
        Else ' 0~10V
            lblLow.Text = "0 V"
            lblHigh.Text = "10 V"
            fValue = fValue * 10 / trackBar1.Maximum
        End If
        txtOutputValue.Text = fValue.ToString("#0.000")
        Timer1.Enabled = True
    End Sub

    Private Sub trackBar1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trackBar1.ValueChanged
        Dim iCh As Integer
        Dim fValue As Single
        Dim byRange As Adam5024_OutputRange

        Timer1.Enabled = False
        iCh = cbxChannel.SelectedIndex
        fValue = Convert.ToSingle(trackBar1.Value)
        byRange = m_byRange(iCh)
        If byRange = Adam5024_OutputRange.mA_0To20 Then ' 0~20mA
            fValue = fValue * 20 / trackBar1.Maximum
        ElseIf byRange = Adam5024_OutputRange.mA_4To20 Then ' 4~20mA
            fValue = 4.0F + fValue * 16 / trackBar1.Maximum
        Else ' 0~10V
            fValue = fValue * 10 / trackBar1.Maximum
        End If
        txtOutputValue.Text = fValue.ToString("#0.000")
        Timer1.Enabled = True
    End Sub

    Private Sub btnApplyOutput_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApplyOutput.Click
        Dim bRet As Boolean
        Dim iChannel As Integer
        Dim fValue As Single

        Timer1.Enabled = False
        iChannel = cbxChannel.SelectedIndex
        fValue = Convert.ToSingle(txtOutputValue.Text)
        If m_b5000 = True Then
            bRet = adamCom.AnalogOutput(m_iAddr).SetCurrentValue(m_iSlot, iChannel, fValue)
        Else
            bRet = adamSocket.AnalogOutput(m_iAddr).SetCurrentValue(m_iSlot, iChannel, fValue)
        End If
        If bRet = True Then
            System.Threading.Thread.Sleep(500)
        Else
            MessageBox.Show("Change current value failed!", "Error")
        End If
        Timer1.Enabled = True
    End Sub
End Class
