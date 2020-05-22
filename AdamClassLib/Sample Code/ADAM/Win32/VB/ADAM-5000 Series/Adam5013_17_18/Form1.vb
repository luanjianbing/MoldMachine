Imports Advantech.Adam
Imports Advantech.Common

Public Class Form1
    Private m_iCom As Integer, m_iAddr As Integer, m_iSlot As Integer, m_iCount As Integer, m_iChTotal As Integer
    Private m_bStart As Boolean, m_b5000 As Boolean
    Private m_byRange As Byte, m_byFormat As Byte
    Private m_szIP As String
    Private m_Adam5000Type As Adam5000Type
    Private adamCom As AdamCom
    Private adamSocket As AdamSocket

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        m_Adam5000Type = Adam5000Type.Adam5013 ' the sample is for ADAM-5013
        'm_Adam5000Type = Adam5000Type.Adam5017 ' the sample is for ADAM-5017
        'm_Adam5000Type = Adam5000Type.Adam5018 ' the sample is for ADAM-5018

        m_iChTotal = AnalogInput.GetChannelTotal(m_Adam5000Type)

        txtModule.Text = m_Adam5000Type.ToString()
        ' 
        If m_Adam5000Type = Adam5000Type.Adam5013 Then
            chkboxCh3.Visible = False
            txtAIValue3.Visible = False
            chkboxCh4.Visible = False
            txtAIValue4.Visible = False
            chkboxCh5.Visible = False
            txtAIValue5.Visible = False
            chkboxCh6.Visible = False
            txtAIValue6.Visible = False
            chkboxCh7.Visible = False
            txtAIValue7.Visible = False
        ElseIf m_Adam5000Type = Adam5000Type.Adam5018 Then
            chkboxCh7.Visible = False
            txtAIValue7.Visible = False
        End If
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
                    If RefreshChannelRange() = True Then
                        RefreshChannelEnable()
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
                    If RefreshChannelRange() = True Then
                        RefreshChannelEnable()
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
        m_iCount = m_iCount + 1
        txtReadCount.Text = "Polling " + m_iCount.ToString() + " times..."
        If m_Adam5000Type = Adam5000Type.Adam5013 Then
            RefreshAdam5013ChannelValue()
        ElseIf m_Adam5000Type = Adam5000Type.Adam5017 Then
            RefreshAdam5017ChannelValue()
        Else
            RefreshAdam5018ChannelValue()
        End If
    End Sub

    Private Sub RefreshChannelEnable()
        Dim bRet As Boolean
        Dim bEnabled() As Boolean

        If m_b5000 = True Then
            bRet = adamCom.AnalogInput(m_iAddr).GetChannelEnabled(m_iSlot, m_iChTotal, bEnabled)
        Else
            bRet = adamSocket.AnalogInput(m_iAddr).GetChannelEnabled(m_iSlot, m_iChTotal, bEnabled)
        End If
        If bRet = True Then
            If m_iChTotal > 0 Then
                chkboxCh0.Checked = bEnabled(0)
            End If
            If m_iChTotal > 1 Then
                chkboxCh1.Checked = bEnabled(1)
            End If
            If m_iChTotal > 2 Then
                chkboxCh2.Checked = bEnabled(2)
            End If
            If m_iChTotal > 3 Then
                chkboxCh3.Checked = bEnabled(3)
            End If
            If m_iChTotal > 4 Then
                chkboxCh4.Checked = bEnabled(4)
            End If
            If m_iChTotal > 5 Then
                chkboxCh5.Checked = bEnabled(5)
            End If
            If m_iChTotal > 6 Then
                chkboxCh6.Checked = bEnabled(6)
            End If
            If m_iChTotal > 7 Then
                chkboxCh7.Checked = bEnabled(7)
            End If
            txtAIValue0.Text = ""
            txtAIValue1.Text = ""
            txtAIValue2.Text = ""
            txtAIValue3.Text = ""
            txtAIValue4.Text = ""
            txtAIValue5.Text = ""
            txtAIValue6.Text = ""
            txtAIValue7.Text = ""
        Else
            MessageBox.Show("GetChannelEnabled() failed", "Error")
        End If
    End Sub

    Private Function RefreshChannelRange() As Boolean
        Dim bRet As Boolean
        Dim byIntegration As Byte

        If m_b5000 = True Then
            bRet = adamCom.AnalogInput(m_iAddr).GetRangeIntegrationDataFormat(m_iSlot, m_byRange, byIntegration, m_byFormat)
        Else
            bRet = adamSocket.AnalogInput(m_iAddr).GetRangeIntegration(m_iSlot, m_byRange, byIntegration)
        End If
        If bRet = False Then
            MessageBox.Show("Get range failed!", "Error")
        End If
        Return bRet
    End Function

    Private Sub RefreshAdam5013ChannelValue()
        Dim iStart As Integer
        Dim iData() As Integer
        Dim fVal() As Single
        Dim fValue As Single
        Dim szFormat As String, szUnit As String

        iStart = m_iSlot * 8 + 1
        If m_b5000 = True Then
            If adamCom.AnalogInput(m_iAddr).GetValues(m_iSlot, m_iChTotal, fVal) = True Then
                If m_byFormat = Adam5000_DataFormat.Ohms Then ' ohms
                    If chkboxCh0.Checked = True Then
                        txtAIValue0.Text = fVal(0).ToString() + " ohms"
                    End If
                    If chkboxCh1.Checked = True Then
                        txtAIValue1.Text = fVal(1).ToString() + " ohms"
                    End If
                    If chkboxCh2.Checked = True Then
                        txtAIValue2.Text = fVal(2).ToString() + " ohms"
                    End If
                Else
                    ' floating format
                    szFormat = AnalogInput.GetFloatFormat(m_Adam5000Type, m_byRange)
                    szUnit = AnalogInput.GetUnitName(m_Adam5000Type, m_byRange)
                    '
                    If (chkboxCh0.Checked) Then
                        txtAIValue0.Text = fVal(0).ToString(szFormat) + " " + szUnit
                    End If
                    If (chkboxCh1.Checked) Then
                        txtAIValue1.Text = fVal(1).ToString(szFormat) + " " + szUnit
                    End If
                    If (chkboxCh2.Checked) Then
                        txtAIValue2.Text = fVal(2).ToString(szFormat) + " " + szUnit
                    End If
                End If
            Else
                If chkboxCh0.Checked = True Then
                    txtAIValue0.Text = "Failed to get!"
                End If
                If chkboxCh1.Checked = True Then
                    txtAIValue1.Text = "Failed to get!"
                End If
                If chkboxCh2.Checked = True Then
                    txtAIValue2.Text = "Failed to get!"
                End If
            End If
        Else
            If adamSocket.Modbus().ReadInputRegs(iStart, m_iChTotal, iData) = True Then
                ' floating format
                szFormat = AnalogInput.GetFloatFormat(m_Adam5000Type, m_byRange)
                szUnit = AnalogInput.GetUnitName(m_Adam5000Type, m_byRange)
                '
                If chkboxCh0.Checked = True Then
                    fValue = AnalogInput.GetScaledValue(m_Adam5000Type, m_byRange, iData(0))
                    txtAIValue0.Text = fValue.ToString(szFormat) + " " + szUnit
                End If
                If chkboxCh1.Checked = True Then
                    fValue = AnalogInput.GetScaledValue(m_Adam5000Type, m_byRange, iData(1))
                    txtAIValue1.Text = fValue.ToString(szFormat) + " " + szUnit
                End If
                If chkboxCh2.Checked = True Then
                    fValue = AnalogInput.GetScaledValue(m_Adam5000Type, m_byRange, iData(2))
                    txtAIValue2.Text = fValue.ToString(szFormat) + " " + szUnit
                End If
            Else
                If chkboxCh0.Checked = True Then
                    txtAIValue0.Text = "Failed to get!"
                End If
                If chkboxCh1.Checked = True Then
                    txtAIValue1.Text = "Failed to get!"
                End If
                If chkboxCh2.Checked = True Then
                    txtAIValue2.Text = "Failed to get!"
                End If
            End If
        End If
    End Sub

    Private Sub RefreshAdam5017ChannelValue()
        Dim iStart As Integer
        Dim iData() As Integer
        Dim fVal() As Single
        Dim fValue As Single
        Dim szFormat As String, szUnit As String

        iStart = m_iSlot * 8 + 1
        If m_b5000 = True Then
            If adamCom.AnalogInput(m_iAddr).GetValues(m_iSlot, m_iChTotal, fVal) = True Then
                ' floating format
                szFormat = AnalogInput.GetFloatFormat(m_Adam5000Type, m_byRange)
                szUnit = AnalogInput.GetUnitName(m_Adam5000Type, m_byRange)
                '
                If chkboxCh0.Checked = True Then
                    txtAIValue0.Text = fVal(0).ToString(szFormat) + " " + szUnit
                End If
                If chkboxCh1.Checked = True Then
                    txtAIValue1.Text = fVal(1).ToString(szFormat) + " " + szUnit
                End If
                If chkboxCh2.Checked = True Then
                    txtAIValue2.Text = fVal(2).ToString(szFormat) + " " + szUnit
                End If
                If chkboxCh3.Checked = True Then
                    txtAIValue3.Text = fVal(3).ToString(szFormat) + " " + szUnit
                End If
                If chkboxCh4.Checked = True Then
                    txtAIValue4.Text = fVal(4).ToString(szFormat) + " " + szUnit
                End If
                If chkboxCh5.Checked = True Then
                    txtAIValue5.Text = fVal(5).ToString(szFormat) + " " + szUnit
                End If
                If chkboxCh6.Checked = True Then
                    txtAIValue6.Text = fVal(6).ToString(szFormat) + " " + szUnit
                End If
                If chkboxCh7.Checked = True Then
                    txtAIValue7.Text = fVal(7).ToString(szFormat) + " " + szUnit
                End If
            Else
                If chkboxCh0.Checked = True Then
                    txtAIValue0.Text = "Failed to get!"
                End If
                If chkboxCh1.Checked = True Then
                    txtAIValue1.Text = "Failed to get!"
                End If
                If chkboxCh2.Checked = True Then
                    txtAIValue2.Text = "Failed to get!"
                End If
                If chkboxCh3.Checked = True Then
                    txtAIValue3.Text = "Failed to get!"
                End If
                If chkboxCh4.Checked = True Then
                    txtAIValue4.Text = "Failed to get!"
                End If
                If chkboxCh5.Checked = True Then
                    txtAIValue5.Text = "Failed to get!"
                End If
                If chkboxCh6.Checked = True Then
                    txtAIValue6.Text = "Failed to get!"
                End If
                If chkboxCh7.Checked = True Then
                    txtAIValue7.Text = "Failed to get!"
                End If
            End If
        Else
            If adamSocket.Modbus().ReadInputRegs(iStart, m_iChTotal, iData) = True Then
                ' floating format
                szFormat = AnalogInput.GetFloatFormat(m_Adam5000Type, m_byRange)
                szUnit = AnalogInput.GetUnitName(m_Adam5000Type, m_byRange)
                '
                If chkboxCh0.Checked = True Then
                    fValue = AnalogInput.GetScaledValue(m_Adam5000Type, m_byRange, iData(0))
                    txtAIValue0.Text = fValue.ToString(szFormat) + " " + szUnit
                End If
                If chkboxCh1.Checked = True Then
                    fValue = AnalogInput.GetScaledValue(m_Adam5000Type, m_byRange, iData(1))
                    txtAIValue1.Text = fValue.ToString(szFormat) + " " + szUnit
                End If
                If chkboxCh2.Checked = True Then
                    fValue = AnalogInput.GetScaledValue(m_Adam5000Type, m_byRange, iData(2))
                    txtAIValue2.Text = fValue.ToString(szFormat) + " " + szUnit
                End If
                If chkboxCh3.Checked = True Then
                    fValue = AnalogInput.GetScaledValue(m_Adam5000Type, m_byRange, iData(3))
                    txtAIValue3.Text = fValue.ToString(szFormat) + " " + szUnit
                End If
                If chkboxCh4.Checked = True Then
                    fValue = AnalogInput.GetScaledValue(m_Adam5000Type, m_byRange, iData(4))
                    txtAIValue4.Text = fValue.ToString(szFormat) + " " + szUnit
                End If
                If chkboxCh5.Checked = True Then
                    fValue = AnalogInput.GetScaledValue(m_Adam5000Type, m_byRange, iData(5))
                    txtAIValue5.Text = fValue.ToString(szFormat) + " " + szUnit
                End If
                If chkboxCh6.Checked = True Then
                    fValue = AnalogInput.GetScaledValue(m_Adam5000Type, m_byRange, iData(6))
                    txtAIValue6.Text = fValue.ToString(szFormat) + " " + szUnit
                End If
                If chkboxCh7.Checked = True Then
                    fValue = AnalogInput.GetScaledValue(m_Adam5000Type, m_byRange, iData(7))
                    txtAIValue7.Text = fValue.ToString(szFormat) + " " + szUnit
                End If
            Else
                If chkboxCh0.Checked = True Then
                    txtAIValue0.Text = "Failed to get!"
                End If
                If chkboxCh1.Checked = True Then
                    txtAIValue1.Text = "Failed to get!"
                End If
                If chkboxCh2.Checked = True Then
                    txtAIValue2.Text = "Failed to get!"
                End If
                If chkboxCh3.Checked = True Then
                    txtAIValue3.Text = "Failed to get!"
                End If
                If chkboxCh4.Checked = True Then
                    txtAIValue4.Text = "Failed to get!"
                End If
                If chkboxCh5.Checked = True Then
                    txtAIValue5.Text = "Failed to get!"
                End If
                If chkboxCh6.Checked = True Then
                    txtAIValue6.Text = "Failed to get!"
                End If
                If chkboxCh7.Checked = True Then
                    txtAIValue7.Text = "Failed to get!"
                End If
            End If
        End If
    End Sub

    Private Sub RefreshAdam5018ChannelValue()
        Dim iStart As Integer
        Dim iData() As Integer
        Dim fVal() As Single
        Dim fValue As Single
        Dim szFormat As String, szUnit As String

        iStart = m_iSlot * 8 + 1

        If m_b5000 = True Then
            If adamCom.AnalogInput(m_iAddr).GetValues(m_iSlot, m_iChTotal, fVal) = True Then
                ' floating format
                szFormat = AnalogInput.GetFloatFormat(m_Adam5000Type, m_byRange)
                szUnit = AnalogInput.GetUnitName(m_Adam5000Type, m_byRange)
                '
                If chkboxCh0.Checked = True Then
                    txtAIValue0.Text = fVal(0).ToString(szFormat) + " " + szUnit
                End If
                If chkboxCh1.Checked = True Then
                    txtAIValue1.Text = fVal(1).ToString(szFormat) + " " + szUnit
                End If
                If chkboxCh2.Checked = True Then
                    txtAIValue2.Text = fVal(2).ToString(szFormat) + " " + szUnit
                End If
                If chkboxCh3.Checked = True Then
                    txtAIValue3.Text = fVal(3).ToString(szFormat) + " " + szUnit
                End If
                If chkboxCh4.Checked = True Then
                    txtAIValue4.Text = fVal(4).ToString(szFormat) + " " + szUnit
                End If
                If chkboxCh5.Checked = True Then
                    txtAIValue5.Text = fVal(5).ToString(szFormat) + " " + szUnit
                End If
                If chkboxCh6.Checked = True Then
                    txtAIValue6.Text = fVal(6).ToString(szFormat) + " " + szUnit
                End If
            Else
                If chkboxCh0.Checked = True Then
                    txtAIValue0.Text = "Failed to get!"
                End If
                If chkboxCh1.Checked = True Then
                    txtAIValue1.Text = "Failed to get!"
                End If
                If chkboxCh2.Checked = True Then
                    txtAIValue2.Text = "Failed to get!"
                End If
                If chkboxCh3.Checked = True Then
                    txtAIValue3.Text = "Failed to get!"
                End If
                If chkboxCh4.Checked = True Then
                    txtAIValue4.Text = "Failed to get!"
                End If
                If chkboxCh5.Checked = True Then
                    txtAIValue5.Text = "Failed to get!"
                End If
                If chkboxCh6.Checked = True Then
                    txtAIValue6.Text = "Failed to get!"
                End If
            End If
        Else
            If adamSocket.Modbus().ReadInputRegs(iStart, m_iChTotal, iData) = True Then
                ' floating format
                szFormat = AnalogInput.GetFloatFormat(m_Adam5000Type, m_byRange)
                szUnit = AnalogInput.GetUnitName(m_Adam5000Type, m_byRange)
                '
                If chkboxCh0.Checked = True Then
                    fValue = AnalogInput.GetScaledValue(m_Adam5000Type, m_byRange, iData(0))
                    txtAIValue0.Text = fValue.ToString(szFormat) + " " + szUnit
                End If
                If chkboxCh1.Checked = True Then
                    fValue = AnalogInput.GetScaledValue(m_Adam5000Type, m_byRange, iData(1))
                    txtAIValue1.Text = fValue.ToString(szFormat) + " " + szUnit
                End If
                If chkboxCh2.Checked = True Then
                    fValue = AnalogInput.GetScaledValue(m_Adam5000Type, m_byRange, iData(2))
                    txtAIValue2.Text = fValue.ToString(szFormat) + " " + szUnit
                End If
                If chkboxCh3.Checked = True Then
                    fValue = AnalogInput.GetScaledValue(m_Adam5000Type, m_byRange, iData(3))
                    txtAIValue3.Text = fValue.ToString(szFormat) + " " + szUnit
                End If
                If chkboxCh4.Checked = True Then
                    fValue = AnalogInput.GetScaledValue(m_Adam5000Type, m_byRange, iData(4))
                    txtAIValue4.Text = fValue.ToString(szFormat) + " " + szUnit
                End If
                If chkboxCh5.Checked = True Then
                    fValue = AnalogInput.GetScaledValue(m_Adam5000Type, m_byRange, iData(5))
                    txtAIValue5.Text = fValue.ToString(szFormat) + " " + szUnit
                End If
                If chkboxCh6.Checked = True Then
                    fValue = AnalogInput.GetScaledValue(m_Adam5000Type, m_byRange, iData(6))
                    txtAIValue6.Text = fValue.ToString(szFormat) + " " + szUnit
                End If
            Else
                If chkboxCh0.Checked = True Then
                    txtAIValue0.Text = "Failed to get!"
                End If
                If chkboxCh1.Checked = True Then
                    txtAIValue1.Text = "Failed to get!"
                End If
                If chkboxCh2.Checked = True Then
                    txtAIValue2.Text = "Failed to get!"
                End If
                If chkboxCh3.Checked = True Then
                    txtAIValue3.Text = "Failed to get!"
                End If
                If chkboxCh4.Checked = True Then
                    txtAIValue4.Text = "Failed to get!"
                End If
                If chkboxCh5.Checked = True Then
                    txtAIValue5.Text = "Failed to get!"
                End If
                If chkboxCh6.Checked = True Then
                    txtAIValue6.Text = "Failed to get!"
                End If
            End If
        End If
    End Sub
End Class
