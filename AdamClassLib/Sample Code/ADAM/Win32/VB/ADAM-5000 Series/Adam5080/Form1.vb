Imports Advantech.Adam
Imports Advantech.Common

Public Class Form1
    Private m_iCom As Integer, m_iAddr As Integer, m_iSlot As Integer, m_iCount As Integer, m_iChTotal As Integer
    Private m_bStart As Boolean, m_b5000 As Boolean
    Private m_byMode As Byte
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
        m_Adam5000Type = Adam5000Type.Adam5080 ' the sample is for ADAM-5080

        m_iChTotal = Counter.GetChannelTotal(m_Adam5000Type)
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
                    If RefreshMode() = True Then
                        cbxChannel.SelectedIndex = 0
                        If m_byMode <> Adam5080_CounterMode.Frequency Then
                            panelCount.Enabled = True
                        End If
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
                    If RefreshMode() = True Then
                        cbxChannel.SelectedIndex = 0
                        If m_byMode <> Adam5080_CounterMode.Frequency Then
                            panelCount.Enabled = True
                        End If
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
        Dim iCh As Integer

        m_iCount = m_iCount + 1
        txtReadCount.Text = "Polling " + m_iCount.ToString() + " times..."
        RefreshChannelValue(0, txtCounter0)
        RefreshChannelValue(1, txtCounter1)
        RefreshChannelValue(2, txtCounter2)
        RefreshChannelValue(3, txtCounter3)
        iCh = cbxChannel.SelectedIndex
        RefreshStatus(iCh)
    End Sub

    Private Function RefreshMode() As Boolean
        Dim byDataFormat As Byte
        Dim bRet As Boolean

        If m_b5000 = True Then
            bRet = adamCom.Counter(m_iAddr).GetModeFormat(m_iSlot, m_byMode, byDataFormat)
        Else
            bRet = adamSocket.Counter(m_iAddr).GetMode(m_iSlot, m_byMode)
        End If
        If bRet = False Then
            MessageBox.Show("Get mode failed", "Error")
        End If
        Return bRet
    End Function

    Private Sub RefreshChannelValue(ByVal i_iChannel As Integer, ByVal i_txtCh As TextBox)
        Dim iStart As Integer
        Dim iHigh As Integer, iLow As Integer
        Dim fValue As Double
        Dim iData() As Integer

        iStart = m_iSlot * 8 + i_iChannel * 2 + 1
        If m_b5000 = True Then
            If adamCom.Counter(m_iAddr).GetValue(m_iSlot, i_iChannel, m_byMode, fValue) = True Then
                i_txtCh.Text = fValue.ToString(Counter.GetFormat(m_Adam5000Type, m_byMode)) + " " + Counter.GetUnitName(m_Adam5000Type, m_byMode)
            Else
                i_txtCh.Text = "Failed to get"
            End If
        Else
            If adamSocket.Modbus(m_iAddr).ReadInputRegs(iStart, 2, iData) = True Then
                iLow = iData(0)
                iHigh = iData(1)

                fValue = Counter.GetScaledValue(m_Adam5000Type, m_byMode, iHigh, iLow)
                i_txtCh.Text = fValue.ToString(Counter.GetFormat(m_Adam5000Type, m_byMode)) + " " + Counter.GetUnitName(m_Adam5000Type, m_byMode)
            Else
                i_txtCh.Text = "Failed to get"
            End If
        End If
    End Sub

    Private Sub RefreshStatus(ByVal i_iChannel As Integer)
        Dim iStart As Integer
        Dim bData() As Boolean
        Dim bCount As Boolean

        iStart = m_iSlot * 16 + i_iChannel * 4 + 1
        If panelCount.Enabled = False Then
            Return
        End If

        If m_b5000 = True Then
            ' Start/Stop counting
            If adamCom.Counter(m_iAddr).GetStatus(m_iSlot, i_iChannel, bCount) = True And adamCom.Counter(m_iAddr).GetOverflowFlag(m_Adam5000Type, m_iSlot, bData) = True Then
                txtCounting.Text = bCount.ToString()    ' Start/Stop counting
                txtOverflow.Text = bData(i_iChannel).ToString() ' overflow flag
            Else
                txtCounting.Text = "Failed to get"
                txtOverflow.Text = "Failed to get"
            End If
        Else
            If adamSocket.Modbus(m_iAddr).ReadCoilStatus(iStart, 4, bData) = True Then
                txtCounting.Text = bData(0).ToString() ' bit 0, Start/Stop counting
                txtOverflow.Text = bData(2).ToString() ' bit 2, overflow flag
            Else
                txtCounting.Text = "Failed to get"
                txtOverflow.Text = "Failed to get"
            End If
        End If
    End Sub

    Private Sub cbxChannel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxChannel.SelectedIndexChanged
        Dim iCh As Integer
        Timer1.Enabled = False
        iCh = cbxChannel.SelectedIndex
        RefreshStatus(iCh)
        Timer1.Enabled = True
    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        Dim iChannel As Integer
        Dim bRet As Boolean

        Timer1.Enabled = False
        iChannel = cbxChannel.SelectedIndex
        If (m_b5000) Then
            bRet = adamCom.Counter(m_iAddr).SetStatus(m_iSlot, iChannel, True)
        Else
            bRet = adamSocket.Counter(m_iAddr).SetStatus(m_iSlot, iChannel, True)
        End If
        If bRet = False Then
            MessageBox.Show("Set counter start failed!", "Error")
        End If
        Timer1.Enabled = True
    End Sub

    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
        Dim iChannel As Integer
        Dim bRet As Boolean

        Timer1.Enabled = False
        iChannel = cbxChannel.SelectedIndex
        If (m_b5000) Then
            bRet = adamCom.Counter(m_iAddr).SetStatus(m_iSlot, iChannel, False)
        Else
            bRet = adamSocket.Counter(m_iAddr).SetStatus(m_iSlot, iChannel, False)
        End If
        If bRet = False Then
            MessageBox.Show("Set counter start failed!", "Error")
        End If
        Timer1.Enabled = True
    End Sub

    Private Sub btnClearCounter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearCounter.Click
        Dim iChannel As Integer
        Dim bRet As Boolean

        Timer1.Enabled = False
        iChannel = cbxChannel.SelectedIndex
        If m_b5000 = True Then
            bRet = adamCom.Counter(m_iAddr).SetToStartup(m_iSlot, iChannel)
        Else
            bRet = adamSocket.Counter(m_iAddr).SetToStartup(m_iSlot, iChannel)
        End If
        If bRet = False Then
            MessageBox.Show("Set counter to startup value failed!", "Error")
        End If
        Timer1.Enabled = True
    End Sub
End Class
