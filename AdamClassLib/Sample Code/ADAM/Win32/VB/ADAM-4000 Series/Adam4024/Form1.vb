Imports Advantech.Adam
Imports Advantech.Common

Public Class Form1
    Private m_iCom As Int32, m_iAddr As Int32, m_iCount As Int32, m_iChTotal As Int32
    Private m_byRange() As Byte
    Private m_bStart As Boolean
    Private m_adamConfig As Adam4000Config
    Private m_Adam4000Type As Adam4000Type
    Private adamCom As AdamCom

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim iIdx As Int32
        m_iCom = 2                              ' using COM2
        m_iAddr = 1                             ' the slave address is 1
        m_iCount = 0                            ' the counting start from 0
        m_bStart = False
        m_Adam4000Type = Adam4000Type.Adam4024  ' the sample is for ADAM-4024

        m_iChTotal = AnalogOutput.GetChannelTotal(m_Adam4000Type)
        m_byRange = New Byte(m_iChTotal - 1) {}
        For iIdx = 0 To m_iChTotal - 1
            cbxChannel.Items.Add(iIdx.ToString())
        Next iIdx
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
        If m_bStart = True Then ' was started
            panelAO.Enabled = False
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

                RefreshChannelRange()
                cbxChannel.SelectedIndex = 0

                panelAO.Enabled = True
                Timer1.Enabled = True ' enable timer
                buttonStart.Text = "Stop"
                m_bStart = True ' starting flag

            Else
                MessageBox.Show("Failed to open COM port!", "Error")
            End If
        End If
    End Sub

    Private Sub RefreshChannelRange()
        Dim byRange As Byte
        Dim iCh As Int32

        For iCh = 0 To m_iChTotal - 1
            If adamCom.AnalogOutput(m_iAddr).GetOutputRange(iCh, byRange) = True Then
                m_byRange(iCh) = byRange
            End If
        Next iCh
    End Sub

    Private Sub RefreshChannelValue(ByVal i_iChannel As Int32, ByRef i_txtCh As TextBox)
        Dim fValue As Single
        Dim szFormat As String

        If adamCom.AnalogOutput(m_iAddr).GetCurrentValue(i_iChannel, fValue) = True Then
            szFormat = AnalogOutput.GetFloatFormat(m_Adam4000Type, m_byRange(i_iChannel))
            i_txtCh.Text = fValue.ToString(szFormat) + " " + AnalogOutput.GetUnitName(m_Adam4000Type, m_byRange(i_iChannel))
        Else
            i_txtCh.Text = "GetCurrentValue() failed"
        End If
    End Sub

    Private Sub RefreshDIValue()
        Dim bValue() As Boolean

        If adamCom.DigitalInput(m_iAddr).GetValues(bValue) = True Then
            txtDI0.Text = bValue(0).ToString()
            txtDI1.Text = bValue(1).ToString()
            txtDI2.Text = bValue(2).ToString()
            txtDI3.Text = bValue(3).ToString()
        Else
            txtDI0.Text = "GetValues() failed"
            txtDI1.Text = "GetValues() failed"
            txtDI2.Text = "GetValues() failed"
            txtDI3.Text = "GetValues() failed"
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        m_iCount = m_iCount + 1
        txtReadCount.Text = "Polling " + m_iCount.ToString() + " times..."
        RefreshChannelValue(0, txtAO0)
        RefreshChannelValue(1, txtAO1)
        RefreshChannelValue(2, txtAO2)
        RefreshChannelValue(3, txtAO3)
        RefreshDIValue()
    End Sub

    Private Sub cbxChannel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxChannel.SelectedIndexChanged
        Dim iCh As Int32
        Dim fValue As Single
        Dim byRange As Adam4024_OutputRange

        Timer1.Enabled = False
        iCh = cbxChannel.SelectedIndex
        fValue = Convert.ToSingle(trackBar1.Value)
        byRange = m_byRange(iCh)
        If (byRange = Adam4024_OutputRange.mA_0To20) Then ' 0~20mA

            lblLow.Text = "0 mA"
            lblHigh.Text = "20 mA"
            fValue = fValue * 20 / trackBar1.Maximum

        ElseIf (byRange = Adam4024_OutputRange.mA_4To20) Then  ' 4~20mA

            lblLow.Text = "4 mA"
            lblHigh.Text = "20 mA"
            fValue = 4.0F + fValue * 16 / trackBar1.Maximum

        Else ' +/- 10V

            lblLow.Text = "-10 V"
            lblHigh.Text = "10 V"
            fValue = -10 + fValue * 20 / trackBar1.Maximum
        End If
        txtOutputValue.Text = fValue.ToString("#0.000")
        Timer1.Enabled = True
    End Sub

    Private Sub trackBar1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trackBar1.ValueChanged
        Dim iCh As Int32
        Dim fValue As Single
        Dim byRange As Adam4024_OutputRange

        Timer1.Enabled = False
        iCh = cbxChannel.SelectedIndex
        fValue = Convert.ToSingle(trackBar1.Value)
        byRange = m_byRange(iCh)
        If (byRange = Adam4024_OutputRange.mA_0To20) Then       ' 0~20mA
            fValue = fValue * 20 / trackBar1.Maximum
        ElseIf (byRange = Adam4024_OutputRange.mA_4To20) Then   ' 4~20mA
            fValue = 4.0F + fValue * 16 / trackBar1.Maximum
        Else                                                    ' 0~10V
            fValue = -10 + fValue * 20 / trackBar1.Maximum
        End If
        txtOutputValue.Text = fValue.ToString("#0.000")
        Timer1.Enabled = True
    End Sub

    Private Sub btnApplyOutput_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApplyOutput.Click
        Dim iChannel As Int32
        Dim fValue As Single

        Timer1.Enabled = False
        iChannel = cbxChannel.SelectedIndex
        fValue = Convert.ToSingle(txtOutputValue.Text)
        If (adamCom.AnalogOutput(m_iAddr).SetCurrentValue(iChannel, fValue)) = True Then
            System.Threading.Thread.Sleep(500)
        Else
            MessageBox.Show("Change current value failed!", "Error")
            Timer1.Enabled = True
        End If
    End Sub
End Class
