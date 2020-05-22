Imports Advantech.Adam
Imports Advantech.Common

Public Class Form1
    Private m_iCom As Integer, m_iAddr As Integer, m_iCount As Integer
    Private m_DOStatus() As Boolean
    Private m_bStart As Boolean
    Private m_adamConfig As Adam4000Config
    Private m_Adam4000Type As Adam4000Type
    Private adamCom As AdamCom

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        m_iCom = 2  ' using COM2
        m_iAddr = 1 ' the slave address is 1
        m_iCount = 0 ' the counting start from 0
        m_DOStatus = New Boolean(1) {}
        m_bStart = False
        'm_Adam4000Type = Adam4000Type.Adam4011 '' the sample is for ADAM-4011
        'm_Adam4000Type = Adam4000Type.Adam4011D '' the sample is for ADAM-4011D
        m_Adam4000Type = Adam4000Type.Adam4012 '' the sample is for ADAM-4012
        'm_Adam4000Type = Adam4000Type.Adam4013 '' the sample is for ADAM-4013
        adamCom = New AdamCom(m_iCom)
        adamCom.Checksum = False ' disbale checksum

        txtModule.Text = m_Adam4000Type.ToString()
        If m_Adam4000Type = Adam4000Type.Adam4013 Then
            panelEvent.Visible = False
            panelAlarm.Visible = False
        End If
    End Sub

    Private Sub Form1_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If m_bStart = True Then
            Timer1.Enabled = False ' disable timer
            adamCom.CloseComPort() ' close the COM port
        End If
    End Sub

    Private Sub buttonStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonStart.Click
        Dim DOStatus() As Boolean
        Dim mode As Adam_AIAlarmMode

        If (m_bStart = True) Then ' was started
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
                ' detect alarm
                ' for ADAM-4011, ADAM-4011D, or ADAM-4012
                If (m_Adam4000Type <> Adam4000Type.Adam4013) Then
                    If adamCom.Alarm(m_iAddr).GetModeAlarmDO(2, mode, DOStatus) = True Then
                        m_DOStatus(0) = DOStatus(0)
                        m_DOStatus(1) = DOStatus(1)
                        txtMode.Text = mode.ToString()
                        If (mode = Adam_AIAlarmMode.Disable) Then ' alarm is disabled
                            buttonDO0.Enabled = True
                            buttonDO1.Enabled = True
                        Else
                            buttonDO0.Enabled = False
                            buttonDO1.Enabled = False
                        End If
                    End If
                End If
                Timer1.Enabled = True ' enable timer
                buttonStart.Text = "Stop"
                m_bStart = True ' starting flag
            Else
                MessageBox.Show("Failed to open COM port!", "Error")
            End If
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim lVal As Long
        Dim bDI As Boolean
        Dim fVal() As Single
        Dim DOStatus() As Boolean
        Dim status() As Adam4000_ChannelStatus
        Dim mode As Adam_AIAlarmMode

        m_iCount = m_iCount + 1
        txtReadCount.Text = "Polling " + m_iCount.ToString() + " times..."
        If (adamCom.AnalogInput(m_iAddr).GetValues(1, fVal, status) = True) Then ' read AI value
            If (status(0) = Adam4000_ChannelStatus.Normal) Then ' the value is normal
                txtAI.Text = fVal(0).ToString() + " " + AnalogInput.GetUnitName(m_Adam4000Type, m_adamConfig.TypeCode)
            Else ' the value is invalid
                txtAI.Text = status(0).ToString()
            End If
        Else
            txtAI.Text = "Failed to get!"
        End If
        ' for ADAM-4011, ADAM-4011D, or ADAM-4012
        If (m_Adam4000Type <> Adam4000Type.Adam4013) Then
            ' event counter
            If (adamCom.Counter(m_iAddr).GetValue(lVal)) Then
                txtCounter.Text = lVal.ToString()
            Else
                txtCounter.Text = "Failed to get!"
            End If
            ' event status
            If (adamCom.DigitalInput(m_iAddr).GetValue(bDI)) Then
                txtEvent.Text = bDI.ToString()
            Else
                txtEvent.Text = "Failed to get!"
            End If
            ' alarm
            If (adamCom.Alarm(m_iAddr).GetModeAlarmDO(2, mode, DOStatus)) Then
                m_DOStatus(0) = DOStatus(0)
                m_DOStatus(1) = DOStatus(1)
                txtLowAlarm.Text = DOStatus(0).ToString()
                txtHighAlarm.Text = DOStatus(1).ToString()
            Else
                txtLowAlarm.Text = "Failed to get!"
                txtHighAlarm.Text = "Failed to get!"
            End If
        End If
    End Sub

    Private Sub buttonDO0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonDO0.Click
        Dim DOStatus() As Boolean = New Boolean(1) {}
        If (m_bStart = True) Then ' was started
            Timer1.Enabled = False ' disable timer for polling before sending command
            If (m_DOStatus(0) = True) Then ' was true, now set to false
                DOStatus(0) = False
            Else
                DOStatus(0) = True
            End If
            DOStatus(1) = m_DOStatus(1)
            If (adamCom.Alarm(m_iAddr).SetAlarmDO(DOStatus) = False) Then
                MessageBox.Show("Set DO failed!", "Error")
            End If
            Timer1.Enabled = True
        End If
    End Sub

    Private Sub buttonDO1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonDO1.Click
        Dim DOStatus() As Boolean = New Boolean(1) {}
        If (m_bStart = True) Then ' was started
            Timer1.Enabled = False ' disable timer for polling before sending command
            DOStatus(0) = m_DOStatus(0)
            If (m_DOStatus(1) = True) Then ' was true, now set to false
                DOStatus(1) = False
            Else
                DOStatus(1) = True
            End If
            If (adamCom.Alarm(m_iAddr).SetAlarmDO(DOStatus) = False) Then
                MessageBox.Show("Set DO failed!", "Error")
            End If
            Timer1.Enabled = True
        End If
    End Sub
End Class
