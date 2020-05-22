Imports Advantech.Adam
Imports Advantech.Common

Public Class Form1
    Private m_iCom As Int32, m_iAddr As Int32, m_iCount As Int32
    Private m_bStart As Boolean
    Private m_adamConfig As Adam4000Config
    Private m_Adam4000Type As Adam4000Type
    Private adamCom As AdamCom

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        m_iCom = 2                                  ' using COM2
        m_iAddr = 1                                 ' the slave address is 1
        m_iCount = 0                                ' the counting start from 0
        m_bStart = False
        m_Adam4000Type = Adam4000Type.Adam4015      ' the sample is for ADAM-4015
        'm_Adam4000Type = Adam4000Type.Adam4015T    ' the sample is for ADAM-4015T
        adamCom = New AdamCom(m_iCom)
        adamCom.Checksum = False ' disbale checksum

        txtModule.Text = m_Adam4000Type.ToString()
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If m_bStart = True Then
            timer1.Enabled = False ' disable timer
            adamCom.CloseComPort() ' close the COM port
        End If
    End Sub

    Private Sub buttonStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonStart.Click
        If m_bStart = True Then ' was started
            m_bStart = False
            timer1.Enabled = False
            adamCom.CloseComPort()
            buttonStart.Text = "Start"
        Else
            If adamCom.OpenComPort() = True Then
                ' set COM port state, 9600,N,8,1
                adamCom.SetComPortState(Baudrate.Baud_9600, Databits.Eight, Parity.None, Stopbits.One)
                ' set COM port timeout
                adamCom.SetComPortTimeout(500, 500, 0, 500, 0)
                m_iCount = 0 ' reset the reading counter
                ' get module config
                If adamCom.Configuration(m_iAddr).GetModuleConfig(m_adamConfig) = False Then
                    adamCom.CloseComPort()
                    MessageBox.Show("Failed to get module config!", "Error")
                    Return
                End If

                RefreshChannelEnable()

                timer1.Enabled = True                               ' enable timer
                buttonStart.Text = "Stop"
                m_bStart = True                                     ' starting flag
            Else
                MessageBox.Show("Failed to open COM port!", "Error")
            End If
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim values() As Single
        Dim status() As Adam4000_ChannelStatus

        m_iCount = m_iCount + 1
        txtReadCount.Text = "Polling " + m_iCount.ToString() + " times..."
        If adamCom.AnalogInput(m_iAddr).GetValues(6, values, status) = True Then
            RefreshValue(txtAIValue0, status(0), values(0))
            RefreshValue(txtAIValue1, status(1), values(1))
            RefreshValue(txtAIValue2, status(2), values(2))
            RefreshValue(txtAIValue3, status(3), values(3))
            RefreshValue(txtAIValue4, status(4), values(4))
            RefreshValue(txtAIValue5, status(5), values(5))
        Else
            txtAIValue0.Text = "Failed to get!"
            txtAIValue1.Text = "Failed to get!"
            txtAIValue2.Text = "Failed to get!"
            txtAIValue3.Text = "Failed to get!"
            txtAIValue4.Text = "Failed to get!"
            txtAIValue5.Text = "Failed to get!"
        End If
    End Sub

    Private Sub RefreshChannelEnable()
        Dim bEnabled() As Boolean

        If (adamCom.AnalogInput(m_iAddr).GetChannelEnabled(6, bEnabled)) Then
            chkboxCh0.Checked = bEnabled(0)
            chkboxCh1.Checked = bEnabled(1)
            chkboxCh2.Checked = bEnabled(2)
            chkboxCh3.Checked = bEnabled(3)
            chkboxCh4.Checked = bEnabled(4)
            chkboxCh5.Checked = bEnabled(5)
        Else
            MessageBox.Show("GetChannelEnabled() failed", "Error")
        End If
    End Sub

    Private Sub RefreshValue(ByRef i_txtCh As TextBox, ByVal i_status As Adam4000_ChannelStatus, ByVal i_fValue As Single)

        If i_status = Adam4000_ChannelStatus.Normal Then
            If m_adamConfig.Format = Adam4000_DataFormat.EngineerUnit Then
                If m_adamConfig.Temperature = Adam_Temperature.Centigrade Then
                    i_txtCh.Text = i_fValue.ToString("#0.0") + " 'C"
                Else
                    i_txtCh.Text = i_fValue.ToString("#0.0") + " 'F"
                End If
            Else ' ohms
                i_txtCh.Text = i_fValue.ToString("#0.000") + " ohms"
            End If
        Else
            i_txtCh.Text = i_status.ToString()
        End If

    End Sub
End Class
