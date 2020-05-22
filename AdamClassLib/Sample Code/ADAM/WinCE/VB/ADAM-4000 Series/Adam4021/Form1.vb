Imports Advantech.Adam
Imports Advantech.Common

Public Class Form1
    Private m_iCom As Int32, m_iAddr As Int32, m_iCount As Int32
    Private m_bStart As Boolean
    Private m_adamConfig As Adam4000Config
    Private m_Adam4000Type As Adam4000Type
    Private adamCom As AdamCom
    
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        m_iCom = 2                                      ' using COM2
        m_iAddr = 1                                     ' the slave address is 1
        m_iCount = 0                                    ' the counting start from 0
        m_bStart = False
        m_Adam4000Type = Adam4000Type.Adam4021          ' the sample is for ADAM-4021
        adamCom = New AdamCom(m_iCom)
        adamCom.Checksum = False                        ' disbale checksum

        txtModule.Text = m_Adam4000Type.ToString()
    End Sub

    Private Sub Form1_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If m_bStart = True Then
            Timer1.Enabled = False      ' disable timer
            adamCom.CloseComPort()      ' close the COM port
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
                m_iCount = 0                                     ' reset the reading counter
                ' get module config
                If adamCom.Configuration(m_iAddr).GetModuleConfig(m_adamConfig) = False Then
                    adamCom.CloseComPort()
                    MessageBox.Show("Failed to get module config!", "Error")
                    Return
                End If
                panelAO.Enabled = True
                RefreshTrackbar()
                Timer1.Enabled = True           ' enable timer
                buttonStart.Text = "Stop"
                m_bStart = True                 ' starting flag

            Else
                MessageBox.Show("Failed to open COM port!", "Error")

            End If
        End If
    End Sub

    Private Sub RefreshTrackbar()
        If m_adamConfig.Format = Adam4000_DataFormat.EngineerUnit Then

            If m_adamConfig.TypeCode = Adam4021_OutputRange.mA_0To20 Then
                lblLow.Text = "0 mA"
                lblHigh.Text = "20 mA"
            ElseIf (m_adamConfig.TypeCode = Adam4021_OutputRange.mA_4To20) Then
                If (txtOutputValue.Text = 0) Then
                    txtOutputValue.Text = "4"
                End If
                lblLow.Text = "4 mA"
                lblHigh.Text = "20 mA"
            Else
                lblLow.Text = "0 V"
                lblHigh.Text = "10 V"
            End If
        ElseIf m_adamConfig.Format = Adam4000_DataFormat.Percent Then
            lblLow.Text = "0 %"
            lblHigh.Text = "100 %"
        Else
            lblLow.Text = "0x000"
            lblHigh.Text = "0xFFF"
        End If
    End Sub

    Private Sub RefreshAOValue()
        Dim fValue As Single
        Dim iValue As Int32

        If adamCom.AnalogOutput(m_iAddr).GetCurrentValue(m_adamConfig.Format, fValue) = True Then
            If m_adamConfig.Format = Adam4000_DataFormat.EngineerUnit Then
                txtAOValue.Text = fValue.ToString("#0.000") + " " + AnalogOutput.GetUnitName(m_Adam4000Type, m_adamConfig.TypeCode)
            ElseIf m_adamConfig.Format = Adam4000_DataFormat.Percent Then
                txtAOValue.Text = fValue.ToString("#0.000") + " %"
            Else
                iValue = Convert.ToInt32(fValue)
                txtAOValue.Text = "0X" + iValue.ToString("X03")
            End If
        Else
            txtAOValue.Text = "GetCurrentValue() failed"
        End If

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        m_iCount = m_iCount + 1
        txtReadCount.Text = "Polling " + m_iCount.ToString() + " times..."
        RefreshAOValue()
    End Sub

    Private Sub trackBar1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trackBar1.ValueChanged
        Dim fValue As Single
        Dim iValue As Int32

        Timer1.Enabled = False
        If m_adamConfig.Format = Adam4000_DataFormat.EngineerUnit Then
            fValue = Convert.ToSingle(trackBar1.Value)
            If m_adamConfig.TypeCode = Adam4021_OutputRange.mA_0To20 Then
                fValue = Convert.ToSingle(20.0 * trackBar1.Value / trackBar1.Maximum)
            ElseIf (m_adamConfig.TypeCode = Adam4021_OutputRange.mA_4To20) Then
                fValue = Convert.ToSingle(16.0 * trackBar1.Value / trackBar1.Maximum + 4)
            Else
                fValue = Convert.ToSingle(10.0 * trackBar1.Value / trackBar1.Maximum)
            End If
            txtOutputValue.Text = fValue.ToString("#0.000")
        ElseIf (m_adamConfig.Format = Adam4000_DataFormat.Percent) Then
            fValue = Convert.ToSingle(100.0 * trackBar1.Value / trackBar1.Maximum)
            txtOutputValue.Text = fValue.ToString("#0.000")
        Else
            iValue = trackBar1.Value
            txtOutputValue.Text = "0X" + iValue.ToString("X03")
        End If
        Timer1.Enabled = True
    End Sub

    Private Sub btnApplyOutput_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApplyOutput.Click
        Dim fValue As Single
        Dim iValue As Integer

        Timer1.Enabled = False
        If (m_adamConfig.Format = Adam4000_DataFormat.TwosComplementHex) Then
            iValue = Convert.ToInt32(txtOutputValue.Text, 16)
            fValue = Convert.ToSingle(iValue)
        Else
            fValue = Convert.ToSingle(txtOutputValue.Text)
        End If
        If (adamCom.AnalogOutput(m_iAddr).SetCurrentValue(Convert.ToByte(m_adamConfig.Format), fValue) = True) Then
            System.Threading.Thread.Sleep(500)
        Else
            MessageBox.Show("Change AO value failed!", "Error")
        End If
        Timer1.Enabled = True
    End Sub
End Class
