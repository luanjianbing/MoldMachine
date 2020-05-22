Imports Advantech.Adam
Imports Advantech.Common

Public Class Form1
    Private m_iCom As Integer, m_iAddr As Integer, m_iCount As Integer, m_iChTotal As Integer
    Private m_bStart As Boolean
    Private m_adamConfig As Adam4000Config
    Private m_Adam4000Type As Adam4000Type
    Private adamCom As AdamCom
    
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim iIdx As Integer
        m_iCom = 2                              ' using COM2
        m_iAddr = 1                             ' the slave address is 1
        m_iCount = 0                            ' the counting start from 0
        m_bStart = False
        m_Adam4000Type = Adam4000Type.Adam4080D ' the sample is for ADAM-4080D

        m_iChTotal = Counter.GetChannelTotal(m_Adam4000Type)
        For iIdx = 0 To m_iChTotal - 1
            cbxChannel.Items.Add(iIdx.ToString())
        Next iIdx
        adamCom = New AdamCom(m_iCom)
        adamCom.Checksum = False                ' disbale checksum

        txtModule.Text = m_Adam4000Type.ToString()
        ' LED source
        cbxLedSource.Items.Add("Channel 0")
        cbxLedSource.Items.Add("Channel 1")
        cbxLedSource.Items.Add("External input")
    End Sub

    Private Sub Form1_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If (m_bStart = True) Then
            Timer1.Enabled = False ' disable timer
            adamCom.CloseComPort() ' close the COM port
        End If
    End Sub

    Private Sub buttonStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonStart.Click
        If (m_bStart = True) Then ' was started
            panelLED.Enabled = False
            panelCount.Enabled = False
            m_bStart = False
            Timer1.Enabled = False
            adamCom.CloseComPort()
            buttonStart.Text = "Start"
        Else
            If (adamCom.OpenComPort() = True) Then
                ' set COM port state, 9600,N,8,1
                adamCom.SetComPortState(Baudrate.Baud_9600, Databits.Eight, Parity.None, Stopbits.One)
                ' set COM port timeout
                adamCom.SetComPortTimeout(500, 500, 0, 500, 0)
                m_iCount = 0 ' reset the reading counter
                ' get module config
                If (adamCom.Configuration(m_iAddr).GetModuleConfig(m_adamConfig) = False) Then
                    adamCom.CloseComPort()
                    MessageBox.Show("Failed to get module config!", "Error")
                    Return
                End If
                ' LED panel
                panelLED.Enabled = True
                RefreshLEDSource()
                ' Counter panel
                If (m_adamConfig.TypeCode = Adam4080_CounterMode.Counter) Then
                    panelCount.Enabled = True
                    cbxChannel.SelectedIndex = 0
                    RefreshAlarmButton()
                Else
                    panelCount.Enabled = False
                End If
                Timer1.Enabled = True ' enable timer
                buttonStart.Text = "Stop"
                m_bStart = True ' starting flag
            Else
                MessageBox.Show("Failed to open COM port!", "Error")
            End If
        End If
    End Sub

    Private Sub RefreshCurrentValue(ByVal i_iChannel As Integer, ByRef i_txtCh As TextBox)
        Dim lVal As Long
        If (adamCom.Counter(m_iAddr).GetValue(i_iChannel, lVal) = True) Then
            i_txtCh.Text = lVal.ToString() + " " + Counter.GetUnitName(m_Adam4000Type, m_adamConfig.TypeCode)
        Else
            i_txtCh.Text = "Fail"
        End If
    End Sub

    Private Sub RefreshAlarmButton()
        Dim bDO() As Boolean
        Dim byMode As Adam4000_CounterAlarmMode

        If (adamCom.Alarm(m_iAddr).GetModeAlarmDO(byMode, bDO) = True) Then
            If (byMode = Adam4000_CounterAlarmMode.Disable) Then
                btnLowAlarm.Text = "DO-0"
                btnHighAlarm.Text = "DO-1"
                btnHighAlarm.Enabled = True
                btnLowAlarm.Enabled = True
                btnClearLatch.Enabled = False
            ElseIf (byMode = Adam4000_CounterAlarmMode.Latch) Then
                btnLowAlarm.Text = "Low alarm"
                btnHighAlarm.Text = "High alarm"
                btnHighAlarm.Enabled = False
                btnLowAlarm.Enabled = False
                btnClearLatch.Enabled = True
            ElseIf (byMode = Adam4000_CounterAlarmMode.Momentary) Then
                btnLowAlarm.Text = "Low alarm"
                btnHighAlarm.Text = "High alarm"
                btnHighAlarm.Enabled = False
                btnLowAlarm.Enabled = False
                btnClearLatch.Enabled = False
            End If

        Else
            MessageBox.Show("GetModeAlarmDO() failed")
        End If
    End Sub

    Private Sub RefreshStatus()
        Dim bCount As Boolean, bOver As Boolean
        Dim iChannel As Integer

        iChannel = cbxChannel.SelectedIndex
        If (adamCom.Counter(m_iAddr).GetStatus(iChannel, bCount) = True) Then
            txtCounting.Text = bCount.ToString()
        Else
            txtCounting.Text = "Fail"
        End If
        If (adamCom.Counter(m_iAddr).GetOverflowFlag(iChannel, bOver) = True) Then
            txtOverflow.Text = bOver.ToString()
        Else
            txtOverflow.Text = "Fail"
        End If
    End Sub

    Private Sub RefreshLEDSource()
        Dim bySource As Byte

        If (adamCom.Counter(m_iAddr).GetLEDSource(bySource) = True) Then
            cbxLedSource.SelectedIndex = bySource
            If (bySource = 2) Then ' host
                panelLEDOutput.Visible = True
            Else
                panelLEDOutput.Visible = False
            End If
        Else
            MessageBox.Show("GetLEDSource() failed")
        End If
    End Sub

    Private Sub RefreshAlarm()
        Dim bAlarm() As Boolean, bDO() As Boolean
        Dim iChannel As Integer

        iChannel = cbxChannel.SelectedIndex
        If (iChannel = 0) Then
            If (adamCom.Alarm(m_iAddr).GetEnableAlarmDO(bAlarm, bDO) = True) Then
                txtLowAlarm.Text = bDO(0).ToString()
                txtHighAlarm.Text = bDO(1).ToString()
            Else
                txtLowAlarm.Text = "Fail"
                txtHighAlarm.Text = "Fail"
            End If
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        m_iCount = m_iCount + 1
        txtReadCount.Text = "Polling " + m_iCount.ToString() + " times..."
        RefreshCurrentValue(0, txtCounter0)
        RefreshCurrentValue(1, txtCounter1)
        If (m_adamConfig.TypeCode = Adam4080_CounterMode.Counter) Then
            RefreshStatus()
            RefreshAlarm()
        End If
    End Sub

    Private Sub cbxChannel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxChannel.SelectedIndexChanged
        Dim iCh As Integer

        Timer1.Enabled = False
        iCh = cbxChannel.SelectedIndex
        If (m_adamConfig.TypeCode = Adam4080_CounterMode.Counter) Then

            If (iCh = 0) Then
                panelAlarm.Visible = True
                RefreshAlarmButton()
            Else
                panelAlarm.Visible = False
            End If
        End If
        Timer1.Enabled = True
    End Sub

    Private Sub btnLowAlarm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLowAlarm.Click
        Dim bDO() As Boolean = New Boolean(2) {}

        Timer1.Enabled = False
        If (txtLowAlarm.Text = "True") Then
            bDO(0) = False
        Else
            bDO(0) = True
        End If
        bDO(1) = (txtHighAlarm.Text = "True")
        If (adamCom.Alarm(m_iAddr).SetAlarmDO(bDO) = False) Then
            MessageBox.Show("Set DO output failed!", "Error")
        End If
        Timer1.Enabled = True
    End Sub

    Private Sub btnHighAlarm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHighAlarm.Click
        Dim bDO() As Boolean = New Boolean(2) {}

        Timer1.Enabled = False
        bDO(0) = (txtLowAlarm.Text = "True")
        If (txtHighAlarm.Text = "True") Then ' was true
            bDO(1) = False
        Else
            bDO(1) = True
        End If
        If (adamCom.Alarm(m_iAddr).SetAlarmDO(bDO) = False) Then
            MessageBox.Show("Set DO output failed!", "Error")
        End If
        Timer1.Enabled = True
    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        Dim iChannel As Integer
        Timer1.Enabled = False
        iChannel = cbxChannel.SelectedIndex
        If (adamCom.Counter(m_iAddr).SetStatus(iChannel, True)) Then
            System.Threading.Thread.Sleep(500)
        Else
            MessageBox.Show("Start counter failed!", "Error")
        End If
        Timer1.Enabled = True
    End Sub

    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
        Dim iChannel As Integer
        Timer1.Enabled = False
        iChannel = cbxChannel.SelectedIndex
        If (adamCom.Counter(m_iAddr).SetStatus(iChannel, False) = True) Then
            System.Threading.Thread.Sleep(500)
        Else
            MessageBox.Show("Stop counter failed!", "Error")
        End If
        Timer1.Enabled = True
    End Sub

    Private Sub btnClearCounter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearCounter.Click
        Dim iChannel As Integer
        Timer1.Enabled = False
        iChannel = cbxChannel.SelectedIndex
        If (adamCom.Counter(m_iAddr).SetClear(iChannel) = True) Then
            System.Threading.Thread.Sleep(500)
        Else
            MessageBox.Show("Clear counter failed!", "Error")
        End If
        Timer1.Enabled = True
    End Sub

    Private Sub btnClearLatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearLatch.Click
        Dim iChannel As Integer
        Timer1.Enabled = False
        iChannel = cbxChannel.SelectedIndex
        If (adamCom.Alarm(m_iAddr).SetLatchClear() = True) Then
            System.Threading.Thread.Sleep(500)
        Else
            MessageBox.Show("Clear counter failed!", "Error")
        End If
        Timer1.Enabled = True
    End Sub

    Private Sub txtLED_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLED.KeyPress
        If ((e.KeyChar.CompareTo("0"c) >= 0) And (e.KeyChar.CompareTo("9"c) <= 0)) Then
            e.Handled = False
        ElseIf (e.KeyChar.CompareTo("."c) = 0) Then
            e.Handled = False
        ElseIf (e.KeyChar = CChar(CStr(8))) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub btnApplyLED_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApplyLED.Click
        If (adamCom.Counter(m_iAddr).SetLEDSource(cbxLedSource.SelectedIndex) = True) Then
            System.Threading.Thread.Sleep(500)
            MessageBox.Show("Change LED source done!", "Information")
            RefreshLEDSource()
        Else
            MessageBox.Show("Change LED source failed!", "Error")
        End If
    End Sub

    Private Sub btnLED_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLED.Click
        If (txtLED.Text.Length <> 6) Then
            MessageBox.Show("The text length must be 6!", "Error")
            Return
        End If
        Timer1.Enabled = False
        If (adamCom.Counter(m_iAddr).SetLEDText(txtLED.Text)) Then
            MessageBox.Show("Set LED text done!", "Information")
        Else
            MessageBox.Show("Set LED text failed!", "Error")
        End If
        Timer1.Enabled = True
    End Sub
End Class
