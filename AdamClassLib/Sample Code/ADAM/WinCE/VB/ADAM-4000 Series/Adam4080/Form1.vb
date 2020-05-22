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
        m_Adam4000Type = Adam4000Type.Adam4080  ' the sample is for ADAM-4080

        m_iChTotal = Counter.GetChannelTotal(m_Adam4000Type)
        For iIdx = 0 To m_iChTotal - 1
            cbxChannel.Items.Add(iIdx.ToString())
        Next iIdx
        adamCom = New AdamCom(m_iCom)
        adamCom.Checksum = False                ' disbale checksum

        txtModule.Text = m_Adam4000Type.ToString()
    End Sub

    Private Sub Form1_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If (m_bStart = True) Then
            Timer1.Enabled = False ' disable timer
            adamCom.CloseComPort() ' close the COM port
        End If
    End Sub

    Private Sub buttonStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonStart.Click
        If (m_bStart = True) Then ' was started
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
                ''''''
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
        Dim bAlarm() As Boolean, bDO() As Boolean
        Dim iChannel As Integer

        iChannel = cbxChannel.SelectedIndex
        If (adamCom.Alarm(m_iAddr).GetEnableAlarmDO(bAlarm, bDO) = True) Then
            If (bAlarm(iChannel) = True) Then 'alarm enabled
                btnAlarm.Text = "Ch-" + iChannel.ToString() + " alarm"
                btnAlarm.Enabled = False
            Else
                btnAlarm.Text = "DO-" + iChannel.ToString()
                btnAlarm.Enabled = True
            End If
        Else
            MessageBox.Show("GetEnableAlarmDO() failed", "Error")
        End If
    End Sub

    Private Sub RefreshStatus()
        Dim bCount As Boolean, bOver As Boolean
        Dim bAlarm() As Boolean, bDO() As Boolean
        Dim iChannel As Integer

        iChannel = cbxChannel.SelectedIndex
        If (adamCom.Counter(m_iAddr).GetStatus(iChannel, bCount)) Then
            txtCounting.Text = bCount.ToString()
        Else
            txtCounting.Text = "Fail"
        End If
        If (adamCom.Counter(m_iAddr).GetOverflowFlag(iChannel, bOver)) Then
            txtOverflow.Text = bOver.ToString()
        Else
            txtOverflow.Text = "Fail"
        End If
        If (adamCom.Alarm(m_iAddr).GetEnableAlarmDO(bAlarm, bDO)) Then
            txtAlarm.Text = bDO(iChannel).ToString()
        Else
            txtAlarm.Text = "Fail"
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        m_iCount = m_iCount + 1
        txtReadCount.Text = "Polling " + m_iCount.ToString() + " times..."
        RefreshCurrentValue(0, txtCounter0)
        RefreshCurrentValue(1, txtCounter1)
        If (m_adamConfig.TypeCode = Convert.ToByte(Adam4080_CounterMode.Counter)) Then
            RefreshStatus()
        End If
    End Sub

    Private Sub cbxChannel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxChannel.SelectedIndexChanged
        RefreshAlarmButton()
    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        Dim iChannel As Integer
        Timer1.Enabled = False
        iChannel = cbxChannel.SelectedIndex
        If (adamCom.Counter(m_iAddr).SetStatus(iChannel, True) = True) Then
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

    Private Sub btnAlarm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlarm.Click
        Dim iChannel As Integer
        Dim bAlarm() As Boolean, bDO() As Boolean

        Timer1.Enabled = False
        iChannel = cbxChannel.SelectedIndex
        If (adamCom.Alarm(m_iAddr).GetEnableAlarmDO(bAlarm, bDO) = True) Then
            If (bDO(iChannel) = True) Then
                bDO(iChannel) = False
            Else
                bDO(iChannel) = True
            End If
            If (adamCom.Alarm(m_iAddr).SetAlarmDO(bDO) = False) Then
                MessageBox.Show("Set DO output failed!", "Information")
            End If
        Else
            MessageBox.Show("Get DO output failed!", "Information")
        End If
        Timer1.Enabled = True
    End Sub
End Class
