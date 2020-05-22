Imports Advantech.Adam
Imports Advantech.Common

Public Class Form1
    Private m_iCom As Int32, m_iAddr As Int32, m_iCount As Int32
    Private m_DOStatus() As Boolean
    Private m_bStart As Boolean
    Private m_adamConfig As Adam4000Config
    Private m_Adam4000Type As Adam4000Type
    Private adamCom As AdamCom

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        m_iCom = 2                              ' using COM2
        m_iAddr = 1                             ' the slave address is 1
        m_iCount = 0                            ' the counting start from 0
        m_DOStatus = New Boolean(3) {}
        m_bStart = False
        m_Adam4000Type = Adam4000Type.Adam4016  ' the sample is for ADAM-4016
        adamCom = New AdamCom(m_iCom)
        adamCom.Checksum = False                ' disbale checksum

        txtModule.Text = m_Adam4000Type.ToString()
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If m_bStart = True Then
            Timer1.Enabled = False ' disable timer
            adamCom.CloseComPort() ' close the COM port
        End If
    End Sub

    Private Sub buttonStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonStart.Click
        Dim DOStatus() As Boolean
        Dim mode As Adam_AIAlarmMode

        If m_bStart = True Then ' was started
            panelAO.Enabled = False
            panelAlarm.Enabled = False
            m_bStart = False
            Timer1.Enabled = False
            adamCom.CloseComPort()
            buttonStart.Text = "Start"
        Else

            If adamCom.OpenComPort() = True Then
                ' set COM port state, 9600,N,8,1
                adamCom.SetComPortState(Baudrate.Baud_9600, Databits.Eight, Parity.None, Stopbits.One)
                ' set COM port timeout
                adamCom.SetComPortTimeout(500, 500, 0, 500, 0)
                m_iCount = 0     ' reset the reading counter
                ' get module config
                If adamCom.Configuration(m_iAddr).GetModuleConfig(m_adamConfig) = False Then
                    adamCom.CloseComPort()
                    MessageBox.Show("Failed to get module config!", "Error")
                    Return
                End If
                ' detect alarm
                If adamCom.Alarm(m_iAddr).GetModeAlarmDO(2, mode, DOStatus) = True Then
                    m_DOStatus(0) = DOStatus(0)
                    m_DOStatus(1) = DOStatus(1)
                    txtMode.Text = mode.ToString()
                    If mode = Adam_AIAlarmMode.Disable Then ' alarm is disabled
                        buttonDO0.Enabled = True
                        buttonDO1.Enabled = True
                    Else
                        buttonDO0.Enabled = False
                        buttonDO1.Enabled = False
                    End If
                End If

                panelAO.Enabled = True
                panelAlarm.Enabled = True
                Timer1.Enabled = True ' enable timer
                buttonStart.Text = "Stop"
                m_bStart = True ' starting flag
            Else
                MessageBox.Show("Failed to open COM port!", "Error")
            End If
        End If
    End Sub

    Private Sub RefreshAIValue()
        Dim fVals() As Single
        Dim iVals() As Int32
        Dim status() As Adam4000_ChannelStatus

        If m_adamConfig.Format = Adam4000_DataFormat.TwosComplementHex Then
            If adamCom.AnalogInput(m_iAddr).GetValues(1, iVals) = True Then
                txtAIValue.Text = "0x" + iVals(0).ToString("X04")
            Else
                txtAIValue.Text = "GetValues() failed"
            End If
        Else
            If adamCom.AnalogInput(m_iAddr).GetValues(1, fVals, status) = True Then
                If status(0) = Adam4000_ChannelStatus.Normal Then

                    If m_adamConfig.Format = Adam4000_DataFormat.EngineerUnit Then
                        txtAIValue.Text = fVals(0).ToString(AnalogInput.GetFloatFormat(m_Adam4000Type, m_adamConfig.TypeCode)) + " " + AnalogInput.GetUnitName(m_Adam4000Type, m_adamConfig.TypeCode)
                    ElseIf (m_adamConfig.Format = Adam4000_DataFormat.Percent) Then
                        txtAIValue.Text = fVals(0).ToString("#0.00") + " %"
                    ElseIf (m_adamConfig.Format = Adam4000_DataFormat.Ohms) Then
                        txtAIValue.Text = fVals(0).ToString("#0.000") + " ohms"
                    End If
                Else
                    txtAIValue.Text = status(0).ToString()
                End If
            Else
                txtAIValue.Text = "GetValues() failed"
            End If
        End If
    End Sub

    Private Sub RefreshAOValue()
        Dim fValue As Single

        If adamCom.AnalogOutput(m_iAddr).GetExcitationValue(fValue) = True Then
            txtAOValue.Text = fValue.ToString("#0.000") + " V"
        Else
            txtAOValue.Text = "GetExcitationValue() failed"
        End If
    End Sub

    Private Sub RefreshDO()
        Dim mode As Adam_AIAlarmMode
        Dim DOStatus() As Boolean

        If (adamCom.Alarm(m_iAddr).GetModeAlarmDO(4, mode, DOStatus)) Then

            m_DOStatus(0) = DOStatus(0)
            m_DOStatus(1) = DOStatus(1)
            m_DOStatus(2) = DOStatus(2)
            m_DOStatus(3) = DOStatus(3)
            txtLowAlarm.Text = DOStatus(0).ToString()
            txtHighAlarm.Text = DOStatus(1).ToString()
            txtDO2.Text = DOStatus(2).ToString()
            txtDO3.Text = DOStatus(3).ToString()

        Else
            txtLowAlarm.Text = "GetModeAlarmDO() failed"
            txtHighAlarm.Text = "GetModeAlarmDO() failed"
            txtDO2.Text = "GetModeAlarmDO() failed"
            txtDO3.Text = "GetModeAlarmDO() failed"
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        m_iCount = m_iCount + 1
        txtReadCount.Text = "Polling " + m_iCount.ToString() + " times..."
        RefreshAIValue()
        RefreshAOValue()
        RefreshDO()
    End Sub

    Private Sub trackBar1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trackBar1.ValueChanged
        Dim fValue As Single

        Timer1.Enabled = False
        fValue = Convert.ToSingle(trackBar1.Value)
        fValue = fValue * 10 / trackBar1.Maximum
        txtOutputValue.Text = fValue.ToString("0.000")
        If m_bStart = True Then ' was started
            Timer1.Enabled = True
        End If
    End Sub

    Private Sub btnApplyOutput_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApplyOutput.Click
        Dim fValue As Single

        Timer1.Enabled = False
        fValue = Convert.ToSingle(txtOutputValue.Text)
        If (adamCom.AnalogOutput(m_iAddr).SetExcitationValue(fValue)) Then
            System.Threading.Thread.Sleep(500)
        Else
            MessageBox.Show("Change current value failed!", "Error")
        End If
        Timer1.Enabled = True
    End Sub

    Private Sub buttonDO0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonDO0.Click
        Dim DOStatus() As Boolean = New Boolean(1) {}

        Timer1.Enabled = False
        If m_DOStatus(0) = True Then ' was ON
            DOStatus(0) = False
        Else
            DOStatus(0) = True
        End If
        DOStatus(1) = m_DOStatus(1)
        If adamCom.Alarm(m_iAddr).SetAlarmDO(DOStatus) = False Then
            MessageBox.Show("Set DO failed!", "Error")
        End If
        Timer1.Enabled = True
    End Sub

    Private Sub buttonDO1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonDO1.Click
        Dim DOStatus() As Boolean = New Boolean(1) {}

        Timer1.Enabled = False
        DOStatus(0) = m_DOStatus(0)
        If (m_DOStatus(1)) Then ' was ON
            DOStatus(1) = False
        Else
            DOStatus(1) = True
            If (adamCom.Alarm(m_iAddr).SetAlarmDO(DOStatus) = False) Then
                MessageBox.Show("Set DO failed!", "Error")
            End If
        End If
        Timer1.Enabled = True
    End Sub

    Private Sub buttonDO2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonDO2.Click
        Dim DOStatus() As Boolean = New Boolean(1) {}

        Timer1.Enabled = False
        If (m_DOStatus(2)) Then ' was ON
            DOStatus(0) = False
        Else
            DOStatus(0) = True
        End If
        DOStatus(1) = m_DOStatus(3)
        If (adamCom.Alarm(m_iAddr).SetExtDO(DOStatus) = False) Then
            MessageBox.Show("Set DO failed!", "Error")
        End If
        Timer1.Enabled = True
    End Sub

    Private Sub buttonDO3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonDO3.Click
        Dim DOStatus() As Boolean = New Boolean(1) {}

        Timer1.Enabled = False
        DOStatus(0) = m_DOStatus(2)
        If (m_DOStatus(3)) Then ' was ON
            DOStatus(1) = False
        Else
            DOStatus(1) = True
        End If
        If (adamCom.Alarm(m_iAddr).SetExtDO(DOStatus) = False) Then
            MessageBox.Show("Set DO failed!", "Error")
        End If
        Timer1.Enabled = True
    End Sub
End Class
