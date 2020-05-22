Imports System.Net.Sockets
Imports Advantech.Adam
Public Class Form1
    Private m_bStart As Boolean
    Private adamModbus As AdamSocket
    Private m_Adam6000Type As Adam6000Type
    Private m_szIP As String
    Private m_iPort As Integer
    Private m_iCount As Integer
    Private m_iAiTotal As Integer
    Private m_bChEnabled() As Boolean
    Private m_byRange() As UShort

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        m_bStart = False                'the action stops at the beginning
        m_szIP = "172.18.3.189"    'modbus slave IP address
        m_iPort = 502                     'modbus TCP port is 502
        adamModbus = New AdamSocket
        adamModbus.SetTimeout(1000, 1000, 1000) 'set timeout for TCP

        adamModbus.AdamSeriesType = AdamType.Adam6200 'set AdamSeriesType for  ADAM-6217
        m_Adam6000Type = Adam6000Type.Adam6217 'the sample is for ADAM-6217
        m_iAiTotal = AnalogInput.GetChannelTotal(m_Adam6000Type)

        txtModule.Text = m_Adam6000Type.ToString()
        m_bChEnabled = New Boolean(m_iAiTotal) {}
        m_byRange = New UShort(m_iAiTotal) {}
    End Sub

    Private Sub Form1_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If (m_bStart = True) Then
            Timer1.Enabled = False
            adamModbus.Disconnect() 'disconnect slave
        End If
    End Sub

    Private Sub RefreshChannelRange(ByVal i_iChannel As Integer)
        Dim usRange As UShort
        If (adamModbus.AnalogInput().GetInputRange(i_iChannel, usRange)) Then
            m_byRange(i_iChannel) = usRange
        Else
            txtReadCount.Text += "GetRangeCode() failed;"
        End If
    End Sub

    Private Sub RefreshChannelEnabled()
        Dim bEnabled() As Boolean

        If (adamModbus.AnalogInput().GetChannelEnabled(m_iAiTotal, bEnabled)) Then
            Array.Copy(bEnabled, 0, m_bChEnabled, 0, m_iAiTotal)
            chkboxCh0.Checked = m_bChEnabled(0)
            chkboxCh1.Checked = m_bChEnabled(1)
            chkboxCh2.Checked = m_bChEnabled(2)
            chkboxCh3.Checked = m_bChEnabled(3)
            chkboxCh4.Checked = m_bChEnabled(4)
            chkboxCh5.Checked = m_bChEnabled(5)
            chkboxCh6.Checked = m_bChEnabled(6)
            chkboxCh7.Checked = m_bChEnabled(7)
        Else
            txtReadCount.Text += "GetChannelEnabled() failed;"
        End If
    End Sub

    Private Sub RefreshSingleChannel(ByVal i_iIndex As Integer, ByRef txtCh As TextBox, ByVal fValue As Single)
        Dim szFormat As String

        If (m_bChEnabled(i_iIndex) = True) Then
            szFormat = AnalogInput.GetFloatFormat(m_Adam6000Type, m_byRange(i_iIndex))
            txtCh.Text = fValue.ToString(szFormat) + " " + AnalogInput.GetUnitName(m_Adam6000Type, m_byRange(i_iIndex))
        End If
    End Sub

    Private Sub RefreshChannelValue()
        Dim iStart As Integer = 1
        Dim iIdx As Integer
        Dim iData() As Integer
        Dim fValue() As Single
        fValue = New Single([m_iAiTotal]) {}

        If (adamModbus.Modbus().ReadInputRegs(iStart, m_iAiTotal, iData)) Then
            For iIdx = 0 To (m_iAiTotal - 1)
                fValue(iIdx) = AnalogInput.GetScaledValue(m_Adam6000Type, m_byRange(iIdx), Convert.ToUInt16(iData(iIdx)))
            Next iIdx

            RefreshSingleChannel(0, txtAIValue0, fValue(0))
            RefreshSingleChannel(1, txtAIValue1, fValue(1))
            RefreshSingleChannel(2, txtAIValue2, fValue(2))
            RefreshSingleChannel(3, txtAIValue3, fValue(3))
            RefreshSingleChannel(4, txtAIValue4, fValue(4))
            RefreshSingleChannel(5, txtAIValue5, fValue(5))
            RefreshSingleChannel(6, txtAIValue6, fValue(6))
            RefreshSingleChannel(7, txtAIValue7, fValue(7))
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False

        m_iCount = m_iCount + 1 ' increment the reading counter
        txtReadCount.Text = "Read Input Regs " + m_iCount.ToString() + " times..."
        RefreshChannelValue()

        Timer1.Enabled = True
    End Sub

    Private Sub buttonStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonStart.Click
        If (m_bStart) Then 'was started
            m_bStart = False        'starting flag
            Timer1.Enabled = False  'disable timer
            adamModbus.Disconnect() 'disconnect slave
            buttonStart.Text = "Start"
        Else    'was stoped
            If (adamModbus.Connect(m_szIP, ProtocolType.Tcp, m_iPort)) Then
                m_iCount = 0  'reset the reading counter
                Timer1.Enabled = True 'enable timer
                buttonStart.Text = "Stop"
                m_bStart = True 'starting flag

                RefreshChannelRange(7)
                RefreshChannelRange(6)
                RefreshChannelRange(5)
                RefreshChannelRange(4)
                RefreshChannelRange(3)
                RefreshChannelRange(2)
                RefreshChannelRange(1)
                RefreshChannelRange(0)
                RefreshChannelEnabled()
            Else
                MessageBox.Show("Connect to " + m_szIP + " failed", "Error")
            End If
        End If
    End Sub
End Class

