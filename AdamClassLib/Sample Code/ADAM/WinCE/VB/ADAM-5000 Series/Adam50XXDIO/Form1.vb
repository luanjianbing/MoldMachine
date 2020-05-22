Imports Advantech.Adam
Imports Advantech.Common

Public Class Form1
    Private m_iCom As Integer, m_iAddr As Integer, m_iSlot As Integer, m_iCount As Integer, m_iChTotal As Integer
    Private m_bStart As Boolean, m_b5000 As Boolean
    Private m_szIP As String
    Private m_Adam5000Type As Adam5000Type
    Private adamCom As AdamCom
    Private adamSocket As AdamSocket

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim iIdx As Integer
        m_b5000 = True ' set to true for module on ADAM-5000 set to false for module on ADAM-5000/TCP
        If m_b5000 = True Then
            m_iCom = 2  ' using COM2
            adamCom = New AdamCom(m_iCom)
            adamCom.Checksum = False ' disbale checksum
        Else
            m_szIP = "172.19.1.234"
            adamSocket = New AdamSocket
            adamSocket.SetTimeout(1000, 1000, 1000) ' set timeout
        End If
        m_iAddr = 1 ' the slave address is 1
        m_iSlot = 0 ' the slot index of the module
        m_iCount = 0 ' the counting start from 0
        m_bStart = False
        m_Adam5000Type = Adam5000Type.Adam5050 ' the sample is for ADAM-5050
        'm_Adam5000Type = Adam5000Type.Adam5051 ' the sample is for ADAM-5051
        'm_Adam5000Type = Adam5000Type.Adam5052 ' the sample is for ADAM-5052
        'm_Adam5000Type = Adam5000Type.Adam5055 ' the sample is for ADAM-5055
        'm_Adam5000Type = Adam5000Type.Adam5056 ' the sample is for ADAM-5056
        'm_Adam5000Type = Adam5000Type.Adam5060 ' the sample is for ADAM-5060
        'm_Adam5000Type = Adam5000Type.Adam5068 ' the sample is for ADAM-5068
        'm_Adam5000Type = Adam5000Type.Adam5069 ' the sample is for ADAM-5069

        m_iChTotal = DigitalInput.GetChannelTotal(m_Adam5000Type) + DigitalOutput.GetChannelTotal(m_Adam5000Type)
        txtModule.Text = m_Adam5000Type.ToString()
    End Sub

    Private Sub Form1_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
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
                    If RefreshForm() = True Then
                        panelDIO.Enabled = True
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
                    If RefreshForm() = True Then
                        panelDIO.Enabled = True
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
        RefresDIO()
    End Sub

    Private Function RefreshForm() As Boolean
        Dim bRet As Boolean

        bRet = False
        If m_Adam5000Type = Adam5000Type.Adam5050 Then
            bRet = InitAdam5050()
        ElseIf m_Adam5000Type = Adam5000Type.Adam5051 Then
            bRet = InitAdam5051()
        ElseIf m_Adam5000Type = Adam5000Type.Adam5052 Then
            bRet = InitAdam5052()
        ElseIf m_Adam5000Type = Adam5000Type.Adam5055 Then
            bRet = InitAdam5055()
        ElseIf m_Adam5000Type = Adam5000Type.Adam5056 Then
            bRet = InitAdam5056()
        ElseIf m_Adam5000Type = Adam5000Type.Adam5060 Then
            bRet = InitAdam5060()
        ElseIf m_Adam5000Type = Adam5000Type.Adam5068 Then
            bRet = InitAdam5068()
        ElseIf m_Adam5000Type = Adam5000Type.Adam5069 Then
            bRet = InitAdam5069()
        End If
        If bRet = False Then
            MessageBox.Show("Refresh form failed", "Error")
        End If
        Return bRet
    End Function

    Private Sub InitChannelItems(ByVal i_bVisable As Boolean, ByVal i_bIsDI As Boolean, ByVal i_bIsMasked As Boolean, ByRef i_iCh As Integer, ByRef i_iDI As Integer, ByRef i_iDO As Integer, ByRef panelCh As Panel, ByRef btnCh As Button)
        Dim iCh As Integer
        If i_bVisable = True Then
            panelCh.Visible = True
            iCh = i_iDI + i_iDO
            If i_bIsDI = True Then ' DI
                If i_iCh >= 0 Then
                    btnCh.Text = "Ch" + i_iCh.ToString("00") + "/DI"
                    i_iCh = i_iCh + 1
                Else
                    btnCh.Text = "DI " + i_iDI.ToString()
                End If
                btnCh.Enabled = False
                i_iDI = i_iDI + 1
            Else ' DO
                If i_iCh >= 0 Then
                    btnCh.Text = "Ch" + i_iCh.ToString("00") + "/DO"
                    i_iCh = i_iCh + 1
                Else
                    btnCh.Text = "DO " + i_iDO.ToString()
                End If
                If i_bIsMasked = True Then
                    btnCh.Enabled = False
                Else
                    btnCh.Enabled = True
                End If
                i_iDO = i_iDO + 1
            End If
        Else
            panelCh.Visible = False
        End If
    End Sub

    Private Function InitAdam5050() As Boolean
        Dim bDIO() As Boolean, bMask() As Boolean
        Dim bRet As Boolean
        Dim iCh As Integer, iDI As Integer, iDO As Integer

        iCh = 0
        iDI = 0
        iDO = 0
        If m_b5000 = True Then
            bRet = (adamCom.DigitalInput(m_iAddr).GetUniversalStatus(m_iSlot, bDIO) And adamCom.DigitalOutput(m_iAddr).GetAlarmMappingMask(m_iSlot, m_iChTotal, bMask))
        Else
            bRet = (adamSocket.DigitalInput(m_iAddr).GetUniversalStatus(m_iSlot, bDIO) And adamSocket.DigitalOutput(m_iAddr).GetAlarmMappingMask(m_iSlot, m_iChTotal, bMask))
        End If
        If bRet = True And bDIO.Length = 16 Then
            InitChannelItems(True, bDIO(0), bMask(0), iCh, iDI, iDO, panelCh0, btnCh0)
            InitChannelItems(True, bDIO(1), bMask(1), iCh, iDI, iDO, panelCh1, btnCh1)
            InitChannelItems(True, bDIO(2), bMask(2), iCh, iDI, iDO, panelCh2, btnCh2)
            InitChannelItems(True, bDIO(3), bMask(3), iCh, iDI, iDO, panelCh3, btnCh3)
            InitChannelItems(True, bDIO(4), bMask(4), iCh, iDI, iDO, panelCh4, btnCh4)
            InitChannelItems(True, bDIO(5), bMask(5), iCh, iDI, iDO, panelCh5, btnCh5)
            InitChannelItems(True, bDIO(6), bMask(6), iCh, iDI, iDO, panelCh6, btnCh6)
            InitChannelItems(True, bDIO(7), bMask(7), iCh, iDI, iDO, panelCh7, btnCh7)
            InitChannelItems(True, bDIO(8), bMask(8), iCh, iDI, iDO, panelCh8, btnCh8)
            InitChannelItems(True, bDIO(9), bMask(9), iCh, iDI, iDO, panelCh9, btnCh9)
            InitChannelItems(True, bDIO(10), bMask(10), iCh, iDI, iDO, panelCh10, btnCh10)
            InitChannelItems(True, bDIO(11), bMask(11), iCh, iDI, iDO, panelCh11, btnCh11)
            InitChannelItems(True, bDIO(12), bMask(12), iCh, iDI, iDO, panelCh12, btnCh12)
            InitChannelItems(True, bDIO(13), bMask(13), iCh, iDI, iDO, panelCh13, btnCh13)
            InitChannelItems(True, bDIO(14), bMask(14), iCh, iDI, iDO, panelCh14, btnCh14)
            InitChannelItems(True, bDIO(15), bMask(15), iCh, iDI, iDO, panelCh15, btnCh15)
            Return True
        End If
        Return False
    End Function

    Private Function InitAdam5051() As Boolean
        Dim iCh As Integer, iDI As Integer, iDO As Integer

        iCh = -1
        iDI = 0
        iDO = 0

        InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh0, btnCh0)
        InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh1, btnCh1)
        InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh2, btnCh2)
        InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh3, btnCh3)
        InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh4, btnCh4)
        InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh5, btnCh5)
        InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh6, btnCh6)
        InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh7, btnCh7)
        InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh8, btnCh8)
        InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh9, btnCh9)
        InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh10, btnCh10)
        InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh11, btnCh11)
        InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh12, btnCh12)
        InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh13, btnCh13)
        InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh14, btnCh14)
        InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh15, btnCh15)
        Return True
    End Function

    Private Function InitAdam5052() As Boolean
        Dim iCh As Integer, iDI As Integer, iDO As Integer

        iCh = -1
        iDI = 0
        iDO = 0

        InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh0, btnCh0)
        InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh1, btnCh1)
        InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh2, btnCh2)
        InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh3, btnCh3)
        InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh4, btnCh4)
        InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh5, btnCh5)
        InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh6, btnCh6)
        InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh7, btnCh7)
        InitChannelItems(False, True, False, iCh, iDI, iDO, panelCh8, btnCh8)
        InitChannelItems(False, True, False, iCh, iDI, iDO, panelCh9, btnCh9)
        InitChannelItems(False, True, False, iCh, iDI, iDO, panelCh10, btnCh10)
        InitChannelItems(False, True, False, iCh, iDI, iDO, panelCh11, btnCh11)
        InitChannelItems(False, True, False, iCh, iDI, iDO, panelCh12, btnCh12)
        InitChannelItems(False, True, False, iCh, iDI, iDO, panelCh13, btnCh13)
        InitChannelItems(False, True, False, iCh, iDI, iDO, panelCh14, btnCh14)
        InitChannelItems(False, True, False, iCh, iDI, iDO, panelCh15, btnCh15)
        Return True
    End Function

    Private Function InitAdam5055() As Boolean
        Dim bMask() As Boolean
        Dim bRet As Boolean
        Dim iCh As Integer, iDI As Integer, iDO As Integer

        iCh = -1
        iDI = 0
        iDO = 0
        If m_b5000 = True Then
            bRet = adamCom.DigitalOutput(m_iAddr).GetAlarmMappingMask(m_iSlot, m_iChTotal, bMask)
        Else
            bRet = adamSocket.DigitalOutput(m_iAddr).GetAlarmMappingMask(m_iSlot, m_iChTotal, bMask)
        End If
        If bRet = True Then
            InitChannelItems(True, False, bMask(0), iCh, iDI, iDO, panelCh0, btnCh0)
            InitChannelItems(True, False, bMask(1), iCh, iDI, iDO, panelCh1, btnCh1)
            InitChannelItems(True, False, bMask(2), iCh, iDI, iDO, panelCh2, btnCh2)
            InitChannelItems(True, False, bMask(3), iCh, iDI, iDO, panelCh3, btnCh3)
            InitChannelItems(True, False, bMask(4), iCh, iDI, iDO, panelCh4, btnCh4)
            InitChannelItems(True, False, bMask(5), iCh, iDI, iDO, panelCh5, btnCh5)
            InitChannelItems(True, False, bMask(6), iCh, iDI, iDO, panelCh6, btnCh6)
            InitChannelItems(True, False, bMask(7), iCh, iDI, iDO, panelCh7, btnCh7)
            InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh8, btnCh8)
            InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh9, btnCh9)
            InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh10, btnCh10)
            InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh11, btnCh11)
            InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh12, btnCh12)
            InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh13, btnCh13)
            InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh14, btnCh14)
            InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh15, btnCh15)
            Return True
        End If
        Return False
    End Function

    Private Function InitAdam5056() As Boolean
        Dim bMask() As Boolean
        Dim bRet As Boolean
        Dim iCh As Integer, iDI As Integer, iDO As Integer

        iCh = -1
        iDI = 0
        iDO = 0
        If m_b5000 = True Then
            bRet = adamCom.DigitalOutput(m_iAddr).GetAlarmMappingMask(m_iSlot, m_iChTotal, bMask)
        Else
            bRet = adamSocket.DigitalOutput(m_iAddr).GetAlarmMappingMask(m_iSlot, m_iChTotal, bMask)
        End If
        If bRet = True Then
            InitChannelItems(True, False, bMask(0), iCh, iDI, iDO, panelCh0, btnCh0)
            InitChannelItems(True, False, bMask(1), iCh, iDI, iDO, panelCh1, btnCh1)
            InitChannelItems(True, False, bMask(2), iCh, iDI, iDO, panelCh2, btnCh2)
            InitChannelItems(True, False, bMask(3), iCh, iDI, iDO, panelCh3, btnCh3)
            InitChannelItems(True, False, bMask(4), iCh, iDI, iDO, panelCh4, btnCh4)
            InitChannelItems(True, False, bMask(5), iCh, iDI, iDO, panelCh5, btnCh5)
            InitChannelItems(True, False, bMask(6), iCh, iDI, iDO, panelCh6, btnCh6)
            InitChannelItems(True, False, bMask(7), iCh, iDI, iDO, panelCh7, btnCh7)
            InitChannelItems(True, False, bMask(8), iCh, iDI, iDO, panelCh8, btnCh8)
            InitChannelItems(True, False, bMask(9), iCh, iDI, iDO, panelCh9, btnCh9)
            InitChannelItems(True, False, bMask(10), iCh, iDI, iDO, panelCh10, btnCh10)
            InitChannelItems(True, False, bMask(11), iCh, iDI, iDO, panelCh11, btnCh11)
            InitChannelItems(True, False, bMask(12), iCh, iDI, iDO, panelCh12, btnCh12)
            InitChannelItems(True, False, bMask(13), iCh, iDI, iDO, panelCh13, btnCh13)
            InitChannelItems(True, False, bMask(14), iCh, iDI, iDO, panelCh14, btnCh14)
            InitChannelItems(True, False, bMask(15), iCh, iDI, iDO, panelCh15, btnCh15)
            Return True
        End If
        Return False
    End Function

    Private Function InitAdam5060() As Boolean
        Dim bMask() As Boolean
        Dim bRet As Boolean
        Dim iCh As Integer, iDI As Integer, iDO As Integer

        iCh = -1
        iDI = 0
        iDO = 0
        If m_b5000 = True Then
            bRet = adamCom.DigitalOutput(m_iAddr).GetAlarmMappingMask(m_iSlot, m_iChTotal, bMask)
        Else
            bRet = adamSocket.DigitalOutput(m_iAddr).GetAlarmMappingMask(m_iSlot, m_iChTotal, bMask)
        End If
        If bRet = True Then
            InitChannelItems(True, False, bMask(0), iCh, iDI, iDO, panelCh0, btnCh0)
            InitChannelItems(True, False, bMask(1), iCh, iDI, iDO, panelCh1, btnCh1)
            InitChannelItems(True, False, bMask(2), iCh, iDI, iDO, panelCh2, btnCh2)
            InitChannelItems(True, False, bMask(3), iCh, iDI, iDO, panelCh3, btnCh3)
            InitChannelItems(True, False, bMask(4), iCh, iDI, iDO, panelCh4, btnCh4)
            InitChannelItems(True, False, bMask(5), iCh, iDI, iDO, panelCh5, btnCh5)
            InitChannelItems(False, False, False, iCh, iDI, iDO, panelCh6, btnCh6)
            InitChannelItems(False, False, False, iCh, iDI, iDO, panelCh7, btnCh7)
            InitChannelItems(False, False, False, iCh, iDI, iDO, panelCh8, btnCh8)
            InitChannelItems(False, False, False, iCh, iDI, iDO, panelCh9, btnCh9)
            InitChannelItems(False, False, False, iCh, iDI, iDO, panelCh10, btnCh10)
            InitChannelItems(False, False, False, iCh, iDI, iDO, panelCh11, btnCh11)
            InitChannelItems(False, False, False, iCh, iDI, iDO, panelCh12, btnCh12)
            InitChannelItems(False, False, False, iCh, iDI, iDO, panelCh13, btnCh13)
            InitChannelItems(False, False, False, iCh, iDI, iDO, panelCh14, btnCh14)
            InitChannelItems(False, False, False, iCh, iDI, iDO, panelCh15, btnCh15)
            Return True
        End If
        Return False
    End Function

    Private Function InitAdam5068() As Boolean
        Dim bMask() As Boolean
        Dim bRet As Boolean
        Dim iCh As Integer, iDI As Integer, iDO As Integer

        iCh = -1
        iDI = 0
        iDO = 0
        If m_b5000 = True Then
            bRet = adamCom.DigitalOutput(m_iAddr).GetAlarmMappingMask(m_iSlot, m_iChTotal, bMask)
        Else
            bRet = adamSocket.DigitalOutput(m_iAddr).GetAlarmMappingMask(m_iSlot, m_iChTotal, bMask)
        End If
        If bRet = True Then
            InitChannelItems(True, False, bMask(0), iCh, iDI, iDO, panelCh0, btnCh0)
            InitChannelItems(True, False, bMask(1), iCh, iDI, iDO, panelCh1, btnCh1)
            InitChannelItems(True, False, bMask(2), iCh, iDI, iDO, panelCh2, btnCh2)
            InitChannelItems(True, False, bMask(3), iCh, iDI, iDO, panelCh3, btnCh3)
            InitChannelItems(True, False, bMask(4), iCh, iDI, iDO, panelCh4, btnCh4)
            InitChannelItems(True, False, bMask(5), iCh, iDI, iDO, panelCh5, btnCh5)
            InitChannelItems(True, False, bMask(6), iCh, iDI, iDO, panelCh6, btnCh6)
            InitChannelItems(True, False, bMask(7), iCh, iDI, iDO, panelCh7, btnCh7)
            InitChannelItems(False, False, False, iCh, iDI, iDO, panelCh8, btnCh8)
            InitChannelItems(False, False, False, iCh, iDI, iDO, panelCh9, btnCh9)
            InitChannelItems(False, False, False, iCh, iDI, iDO, panelCh10, btnCh10)
            InitChannelItems(False, False, False, iCh, iDI, iDO, panelCh11, btnCh11)
            InitChannelItems(False, False, False, iCh, iDI, iDO, panelCh12, btnCh12)
            InitChannelItems(False, False, False, iCh, iDI, iDO, panelCh13, btnCh13)
            InitChannelItems(False, False, False, iCh, iDI, iDO, panelCh14, btnCh14)
            InitChannelItems(False, False, False, iCh, iDI, iDO, panelCh15, btnCh15)
            Return True
        End If
        Return False
    End Function

    Private Function InitAdam5069() As Boolean
        Dim bMask() As Boolean
        Dim bRet As Boolean
        Dim iCh As Integer, iDI As Integer, iDO As Integer

        iCh = -1
        iDI = 0
        iDO = 0
        If m_b5000 = True Then
            bRet = adamCom.DigitalOutput(m_iAddr).GetAlarmMappingMask(m_iSlot, m_iChTotal, bMask)
        Else
            bRet = adamSocket.DigitalOutput(m_iAddr).GetAlarmMappingMask(m_iSlot, m_iChTotal, bMask)
        End If
        If bRet = True Then
            InitChannelItems(True, False, bMask(0), iCh, iDI, iDO, panelCh0, btnCh0)
            InitChannelItems(True, False, bMask(1), iCh, iDI, iDO, panelCh1, btnCh1)
            InitChannelItems(True, False, bMask(2), iCh, iDI, iDO, panelCh2, btnCh2)
            InitChannelItems(True, False, bMask(3), iCh, iDI, iDO, panelCh3, btnCh3)
            InitChannelItems(True, False, bMask(4), iCh, iDI, iDO, panelCh4, btnCh4)
            InitChannelItems(True, False, bMask(5), iCh, iDI, iDO, panelCh5, btnCh5)
            InitChannelItems(True, False, bMask(6), iCh, iDI, iDO, panelCh6, btnCh6)
            InitChannelItems(True, False, bMask(7), iCh, iDI, iDO, panelCh7, btnCh7)
            InitChannelItems(False, False, False, iCh, iDI, iDO, panelCh8, btnCh8)
            InitChannelItems(False, False, False, iCh, iDI, iDO, panelCh9, btnCh9)
            InitChannelItems(False, False, False, iCh, iDI, iDO, panelCh10, btnCh10)
            InitChannelItems(False, False, False, iCh, iDI, iDO, panelCh11, btnCh11)
            InitChannelItems(False, False, False, iCh, iDI, iDO, panelCh12, btnCh12)
            InitChannelItems(False, False, False, iCh, iDI, iDO, panelCh13, btnCh13)
            InitChannelItems(False, False, False, iCh, iDI, iDO, panelCh14, btnCh14)
            InitChannelItems(False, False, False, iCh, iDI, iDO, panelCh15, btnCh15)
            Return True
        End If
        Return False
    End Function

    Private Function RefresDIO() As Boolean
        Dim iStart As Integer
        Dim bData() As Boolean
        Dim bRet As Boolean

        iStart = m_iSlot * 16 + 1
        If m_b5000 = True Then
            If m_Adam5000Type = Adam5000Type.Adam5052 Then
                bRet = adamCom.DigitalInput(m_iAddr).GetValues(m_iSlot, m_iChTotal, bData)
            Else
                bRet = adamCom.DigitalOutput(m_iAddr).GetValues(m_iSlot, m_iChTotal, bData)
            End If
        Else
            bRet = adamSocket.Modbus(m_iAddr).ReadCoilStatus(iStart, m_iChTotal, bData)
        End If
        If bRet = True Then
            If m_iChTotal > 0 Then
                txtCh0.Text = bData(0).ToString()
            End If
            If m_iChTotal > 1 Then
                txtCh1.Text = bData(1).ToString()
            End If
            If m_iChTotal > 2 Then
                txtCh2.Text = bData(2).ToString()
            End If
            If m_iChTotal > 3 Then
                txtCh3.Text = bData(3).ToString()
            End If
            If m_iChTotal > 4 Then
                txtCh4.Text = bData(4).ToString()
            End If
            If m_iChTotal > 5 Then
                txtCh5.Text = bData(5).ToString()
            End If
            If m_iChTotal > 6 Then
                txtCh6.Text = bData(6).ToString()
            End If
            If m_iChTotal > 7 Then
                txtCh7.Text = bData(7).ToString()
            End If
            If m_iChTotal > 8 Then
                txtCh8.Text = bData(8).ToString()
            End If
            If m_iChTotal > 9 Then
                txtCh9.Text = bData(9).ToString()
            End If
            If m_iChTotal > 10 Then
                txtCh10.Text = bData(10).ToString()
            End If
            If m_iChTotal > 11 Then
                txtCh11.Text = bData(11).ToString()
            End If
            If m_iChTotal > 12 Then
                txtCh12.Text = bData(12).ToString()
            End If
            If m_iChTotal > 13 Then
                txtCh13.Text = bData(13).ToString()
            End If
            If m_iChTotal > 14 Then
                txtCh14.Text = bData(14).ToString()
            End If
            If m_iChTotal > 15 Then
                txtCh15.Text = bData(15).ToString()
            End If
            Return True
        Else
            txtCh0.Text = "Fail"
            txtCh1.Text = "Fail"
            txtCh2.Text = "Fail"
            txtCh3.Text = "Fail"
            txtCh4.Text = "Fail"
            txtCh5.Text = "Fail"
            txtCh6.Text = "Fail"
            txtCh7.Text = "Fail"
            txtCh8.Text = "Fail"
            txtCh9.Text = "Fail"
            txtCh10.Text = "Fail"
            txtCh11.Text = "Fail"
            txtCh12.Text = "Fail"
            txtCh13.Text = "Fail"
            txtCh14.Text = "Fail"
            txtCh15.Text = "Fail"
        End If
        Return False
    End Function

    Private Sub btnCh_Click(ByVal i_iCh As Integer, ByRef txtBox As TextBox)
        Dim bRet As Boolean
        Dim iStart As Integer

        iStart = m_iSlot * 16 + i_iCh + 1
        timer1.Enabled = False
        If m_b5000 = True Then
            bRet = adamCom.DigitalOutput(m_iAddr).SetValue(m_iSlot, i_iCh, (txtBox.Text = "False"))
        Else
            bRet = adamSocket.Modbus(m_iAddr).ForceSingleCoil(iStart, (txtBox.Text = "False"))
        End If
        If bRet = False Then
            MessageBox.Show("Set digital output failed!", "Error")
        End If
        timer1.Enabled = True
    End Sub

    Private Sub btnCh0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh0.Click
        btnCh_Click(0, txtCh0)
    End Sub

    Private Sub btnCh1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh1.Click
        btnCh_Click(1, txtCh1)
    End Sub

    Private Sub btnCh2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh2.Click
        btnCh_Click(2, txtCh2)
    End Sub

    Private Sub btnCh3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh3.Click
        btnCh_Click(3, txtCh3)
    End Sub

    Private Sub btnCh4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh4.Click
        btnCh_Click(4, txtCh4)
    End Sub

    Private Sub btnCh5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh5.Click
        btnCh_Click(5, txtCh5)
    End Sub

    Private Sub btnCh6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh6.Click
        btnCh_Click(6, txtCh6)
    End Sub

    Private Sub btnCh7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh7.Click
        btnCh_Click(7, txtCh7)
    End Sub

    Private Sub btnCh8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh8.Click
        btnCh_Click(8, txtCh8)
    End Sub

    Private Sub btnCh9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh9.Click
        btnCh_Click(9, txtCh9)
    End Sub

    Private Sub btnCh10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh10.Click
        btnCh_Click(10, txtCh10)
    End Sub

    Private Sub btnCh11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh11.Click
        btnCh_Click(11, txtCh11)
    End Sub

    Private Sub btnCh12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh12.Click
        btnCh_Click(12, txtCh12)
    End Sub

    Private Sub btnCh13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh13.Click
        btnCh_Click(13, txtCh13)
    End Sub

    Private Sub btnCh14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh14.Click
        btnCh_Click(14, txtCh14)
    End Sub

    Private Sub btnCh15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh15.Click
        btnCh_Click(15, txtCh15)
    End Sub
End Class
