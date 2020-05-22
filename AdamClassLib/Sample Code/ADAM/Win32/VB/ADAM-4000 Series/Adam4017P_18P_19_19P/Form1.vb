Imports Advantech.Adam
Imports Advantech.Common

Public Class Form1
    Private m_iCom As Int32, m_iAddr As Int32, m_iCount As Int32, m_iChTotal As Int32
    Private m_bStart As Boolean
    Private m_byRange() As Byte
    Private m_adamConfig As Adam4000Config
    Private m_Adam4000Type As Adam4000Type
    Private adamCom As AdamCom

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        m_iCom = 2              ' using COM2
        m_iAddr = 1             ' the slave address is 1
        m_iCount = 0            ' the counting start from 0
        m_bStart = False
        m_Adam4000Type = Adam4000Type.Adam4017P     ' the sample is for ADAM-4017P
        'm_Adam4000Type = Adam4000Type.Adam4018P    ' the sample is for ADAM-4018P
        'm_Adam4000Type = Adam4000Type.Adam4019     ' the sample is for ADAM-4019
        'm_Adam4000Type = Adam4000Type.Adam4019P    ' the sample is for ADAM-4019P

        m_iChTotal = AnalogInput.GetChannelTotal(m_Adam4000Type)
        m_byRange = New Byte(m_iChTotal - 1) {}
        adamCom = New AdamCom(m_iCom)
        adamCom.Checksum = False            ' disbale checksum

        txtModule.Text = m_Adam4000Type.ToString()
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If m_bStart = True Then
            Timer1.Enabled = False      ' disable timer
            adamCom.CloseComPort()      ' close the COM port
        End If
    End Sub

    Private Sub buttonStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonStart.Click
        If m_bStart = True Then ' was started
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
                m_iCount = 0 ' reset the reading counter
                ' get module config
                If adamCom.Configuration(m_iAddr).GetModuleConfig(m_adamConfig) = False Then
                    adamCom.CloseComPort()
                    MessageBox.Show("Failed to get module config!", "Error")
                    Return
                End If

                RefreshChannelEnable()
                RefreshChannelRange()

                Timer1.Enabled = True       ' enable timer
                buttonStart.Text = "Stop"
                m_bStart = True             ' starting flag
            Else
                MessageBox.Show("Failed to open COM port!", "Error")
            End If
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim fVals As Single()
        Dim iVals As Int32()
        Dim status As Adam4000_ChannelStatus()

        m_iCount = m_iCount + 1
        txtReadCount.Text = "Polling " + m_iCount.ToString() + " times..."
        If m_adamConfig.Format = Adam4000_DataFormat.TwosComplementHex Then
            If adamCom.AnalogInput(m_iAddr).GetValues(8, iVals) = True Then
                txtAIValue0.Text = "0x" + iVals(0).ToString("X04")
                txtAIValue1.Text = "0x" + iVals(1).ToString("X04")
                txtAIValue2.Text = "0x" + iVals(2).ToString("X04")
                txtAIValue3.Text = "0x" + iVals(3).ToString("X04")
                txtAIValue4.Text = "0x" + iVals(4).ToString("X04")
                txtAIValue5.Text = "0x" + iVals(5).ToString("X04")
                txtAIValue6.Text = "0x" + iVals(6).ToString("X04")
                txtAIValue7.Text = "0x" + iVals(7).ToString("X04")
            Else
                txtAIValue0.Text = "Failed to get!"
                txtAIValue1.Text = "Failed to get!"
                txtAIValue2.Text = "Failed to get!"
                txtAIValue3.Text = "Failed to get!"
                txtAIValue4.Text = "Failed to get!"
                txtAIValue5.Text = "Failed to get!"
                txtAIValue6.Text = "Failed to get!"
                txtAIValue7.Text = "Failed to get!"
            End If
        Else
            If adamCom.AnalogInput(m_iAddr).GetValues(8, fVals, status) = True Then
                RefreshValue(txtAIValue0, status(0), fVals(0), m_byRange(0))
                RefreshValue(txtAIValue1, status(1), fVals(1), m_byRange(1))
                RefreshValue(txtAIValue2, status(2), fVals(2), m_byRange(2))
                RefreshValue(txtAIValue3, status(3), fVals(3), m_byRange(3))
                RefreshValue(txtAIValue4, status(4), fVals(4), m_byRange(4))
                RefreshValue(txtAIValue5, status(5), fVals(5), m_byRange(5))
                RefreshValue(txtAIValue6, status(6), fVals(6), m_byRange(6))
                RefreshValue(txtAIValue7, status(7), fVals(7), m_byRange(7))
            Else
                txtAIValue0.Text = "Failed to get!"
                txtAIValue1.Text = "Failed to get!"
                txtAIValue2.Text = "Failed to get!"
                txtAIValue3.Text = "Failed to get!"
                txtAIValue4.Text = "Failed to get!"
                txtAIValue5.Text = "Failed to get!"
                txtAIValue6.Text = "Failed to get!"
                txtAIValue7.Text = "Failed to get!"
            End If
        End If
    End Sub

    Private Sub RefreshChannelEnable()
        Dim bEnabled As Boolean()

        If (adamCom.AnalogInput(m_iAddr).GetChannelEnabled(8, bEnabled)) Then
            chkboxCh0.Checked = bEnabled(0)
            chkboxCh1.Checked = bEnabled(1)
            chkboxCh2.Checked = bEnabled(2)
            chkboxCh3.Checked = bEnabled(3)
            chkboxCh4.Checked = bEnabled(4)
            chkboxCh5.Checked = bEnabled(5)
            chkboxCh6.Checked = bEnabled(6)
            chkboxCh7.Checked = bEnabled(7)
        Else
            MessageBox.Show("GetChannelEnabled() failed", "Error")
        End If
    End Sub

    Private Sub RefreshChannelRange()
        Dim byRange As Byte
        Dim iIdx As Int32

        For iIdx = 0 To m_iChTotal - 1

            If (adamCom.AnalogInput(m_iAddr).GetInputRange(iIdx, byRange)) Then
                m_byRange(iIdx) = byRange
            Else
                MessageBox.Show("GetRangeCode() failed", "Error")
                Exit For
            End If
        Next iIdx
    End Sub

    Private Sub RefreshValue(ByRef i_txtCh As TextBox, ByVal i_status As Adam4000_ChannelStatus, ByVal i_fValue As Single, ByVal i_byRange As Byte)
        If i_status = Adam4000_ChannelStatus.Normal Then

            If m_adamConfig.Format = Adam4000_DataFormat.EngineerUnit Then
                i_txtCh.Text = i_fValue.ToString(AnalogInput.GetFloatFormat(m_Adam4000Type, i_byRange)) + " " + AnalogInput.GetUnitName(m_Adam4000Type, i_byRange)
            ElseIf m_adamConfig.Format = Adam4000_DataFormat.Percent Then
                i_txtCh.Text = i_fValue.ToString("#0.00") + " %"
            End If

        Else
            i_txtCh.Text = i_status.ToString()
        End If
    End Sub
End Class
