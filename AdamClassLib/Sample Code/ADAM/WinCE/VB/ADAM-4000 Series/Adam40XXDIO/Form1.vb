Imports Advantech.Adam
Imports Advantech.Common

Public Class Form1
    Private m_iCom As Integer, m_iAddr As Integer, m_iCount As Integer, m_iDITotal As Integer, m_iDOTotal As Integer
    Private m_bStart As Boolean
    Private m_adamConfig As Adam4000Config
    Private m_Adam4000Type As Adam4000Type
    Private adamCom As AdamCom


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        m_iCom = 2                          ' using COM2
        m_iAddr = 1                         ' the slave address is 1
        m_iCount = 0                        ' the counting start from 0
        m_bStart = False
        m_Adam4000Type = Adam4000Type.Adam4050    '' the sample is for ADAM-4050
        'm_Adam4000Type = Adam4000Type.Adam4051   '' the sample is for ADAM-4051
        'm_Adam4000Type = Adam4000Type.Adam4052   '' the sample is for ADAM-4052
        'm_Adam4000Type = Adam4000Type.Adam4053   '' the sample is for ADAM-4053
        'm_Adam4000Type = Adam4000Type.Adam4055   '' the sample is for ADAM-4055
        'm_Adam4000Type = Adam4000Type.Adam4056S  '' the sample is for ADAM-4056S
        'm_Adam4000Type = Adam4000Type.Adam4056SO '' the sample is for ADAM-4056SO
        'm_Adam4000Type = Adam4000Type.Adam4060   '' the sample is for ADAM-4060
        'm_Adam4000Type = Adam4000Type.Adam4068   '' the sample is for ADAM-4068
        'm_Adam4000Type = Adam4000Type.Adam4069   '' the sample is for ADAM-4069

        m_iDITotal = DigitalInput.GetChannelTotal(m_Adam4000Type)
        m_iDOTotal = DigitalOutput.GetChannelTotal(m_Adam4000Type)
        If (m_Adam4000Type = Adam4000Type.Adam4050) Then
            InitAdam4050()
        ElseIf (m_Adam4000Type = Adam4000Type.Adam4051) Then
            InitAdam4051()
        ElseIf (m_Adam4000Type = Adam4000Type.Adam4052) Then
            InitAdam4052()
        ElseIf (m_Adam4000Type = Adam4000Type.Adam4053) Then
            InitAdam4053()
        ElseIf (m_Adam4000Type = Adam4000Type.Adam4055) Then
            InitAdam4055()
        ElseIf (m_Adam4000Type = Adam4000Type.Adam4056S) Then
            InitAdam4056S()
        ElseIf (m_Adam4000Type = Adam4000Type.Adam4056SO) Then
            InitAdam4056SO()
        ElseIf (m_Adam4000Type = Adam4000Type.Adam4060) Then
            InitAdam4060()
        ElseIf (m_Adam4000Type = Adam4000Type.Adam4068) Then
            InitAdam4068()
        ElseIf (m_Adam4000Type = Adam4000Type.Adam4069) Then
            InitAdam4069()
        End If
        adamCom = New AdamCom(m_iCom)
        adamCom.Checksum = False ' disbale checksum

        txtModule.Text = m_Adam4000Type.ToString()
    End Sub

    Private Sub Form1_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If m_bStart = True Then
            timer1.Enabled = False ' disable timer
            adamCom.CloseComPort() ' close the COM port
        End If
    End Sub

    Private Sub buttonStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonStart.Click
        If m_bStart = True Then ' was started
            panelDIO.Enabled = False
            m_bStart = False
            timer1.Enabled = False
            adamCom.CloseComPort()
            buttonStart.Text = "Start"
        Else
            If (adamCom.OpenComPort()) Then
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

                panelDIO.Enabled = True
                timer1.Enabled = True               ' enable timer
                buttonStart.Text = "Stop"
                m_bStart = True                     ' starting flag

            Else
                MessageBox.Show("Failed to open COM port!", "Error")
            End If
        End If
    End Sub

    Private Sub InitChannelItems(ByVal i_bVisable As Boolean, ByVal i_bIsDI As Boolean, ByRef i_iCh As Integer, ByRef i_iDI As Integer, ByRef i_iDO As Integer, ByRef panelCh As Panel, ByRef btnCh As Button)
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
                i_iDO = i_iDO + 1
            End If
        Else
            panelCh.Visible = False
        End If
    End Sub
    Private Sub InitAdam4050()
        Dim iCh As Integer = -1, iDI As Integer = 0, iDO As Integer = 0

        InitChannelItems(True, True, iCh, iDI, iDO, panelCh0, btnCh0)
        InitChannelItems(True, True, iCh, iDI, iDO, panelCh1, btnCh1)
        InitChannelItems(True, True, iCh, iDI, iDO, panelCh2, btnCh2)
        InitChannelItems(True, True, iCh, iDI, iDO, panelCh3, btnCh3)
        InitChannelItems(True, True, iCh, iDI, iDO, panelCh4, btnCh4)
        InitChannelItems(True, True, iCh, iDI, iDO, panelCh5, btnCh5)
        InitChannelItems(True, True, iCh, iDI, iDO, panelCh6, btnCh6)
        InitChannelItems(False, True, iCh, iDI, iDO, panelCh7, btnCh7)
        ''''''
        InitChannelItems(True, False, iCh, iDI, iDO, panelCh8, btnCh8)
        InitChannelItems(True, False, iCh, iDI, iDO, panelCh9, btnCh9)
        InitChannelItems(True, False, iCh, iDI, iDO, panelCh10, btnCh10)
        InitChannelItems(True, False, iCh, iDI, iDO, panelCh11, btnCh11)
        InitChannelItems(True, False, iCh, iDI, iDO, panelCh12, btnCh12)
        InitChannelItems(True, False, iCh, iDI, iDO, panelCh13, btnCh13)
        InitChannelItems(True, False, iCh, iDI, iDO, panelCh14, btnCh14)
        InitChannelItems(True, False, iCh, iDI, iDO, panelCh15, btnCh15)
    End Sub
    Private Sub InitAdam4051()
        Dim iCh As Integer = -1, iDI As Integer = 0, iDO As Integer = 0

        InitChannelItems(True, True, iCh, iDI, iDO, panelCh0, btnCh0)
        InitChannelItems(True, True, iCh, iDI, iDO, panelCh1, btnCh1)
        InitChannelItems(True, True, iCh, iDI, iDO, panelCh2, btnCh2)
        InitChannelItems(True, True, iCh, iDI, iDO, panelCh3, btnCh3)
        InitChannelItems(True, True, iCh, iDI, iDO, panelCh4, btnCh4)
        InitChannelItems(True, True, iCh, iDI, iDO, panelCh5, btnCh5)
        InitChannelItems(True, True, iCh, iDI, iDO, panelCh6, btnCh6)
        InitChannelItems(True, True, iCh, iDI, iDO, panelCh7, btnCh7)
        ''''''
        InitChannelItems(True, True, iCh, iDI, iDO, panelCh8, btnCh8)
        InitChannelItems(True, True, iCh, iDI, iDO, panelCh9, btnCh9)
        InitChannelItems(True, True, iCh, iDI, iDO, panelCh10, btnCh10)
        InitChannelItems(True, True, iCh, iDI, iDO, panelCh11, btnCh11)
        InitChannelItems(True, True, iCh, iDI, iDO, panelCh12, btnCh12)
        InitChannelItems(True, True, iCh, iDI, iDO, panelCh13, btnCh13)
        InitChannelItems(True, True, iCh, iDI, iDO, panelCh14, btnCh14)
        InitChannelItems(True, True, iCh, iDI, iDO, panelCh15, btnCh15)
    End Sub
    Private Sub InitAdam4052()
        Dim iCh As Integer = -1, iDI As Integer = 0, iDO As Integer = 0

        InitChannelItems(True, True, iCh, iDI, iDO, panelCh0, btnCh0)
        InitChannelItems(True, True, iCh, iDI, iDO, panelCh1, btnCh1)
        InitChannelItems(True, True, iCh, iDI, iDO, panelCh2, btnCh2)
        InitChannelItems(True, True, iCh, iDI, iDO, panelCh3, btnCh3)
        InitChannelItems(True, True, iCh, iDI, iDO, panelCh4, btnCh4)
        InitChannelItems(True, True, iCh, iDI, iDO, panelCh5, btnCh5)
        InitChannelItems(True, True, iCh, iDI, iDO, panelCh6, btnCh6)
        InitChannelItems(True, True, iCh, iDI, iDO, panelCh7, btnCh7)
        ''''''
        InitChannelItems(False, True, iCh, iDI, iDO, panelCh8, btnCh8)
        InitChannelItems(False, True, iCh, iDI, iDO, panelCh9, btnCh9)
        InitChannelItems(False, True, iCh, iDI, iDO, panelCh10, btnCh10)
        InitChannelItems(False, True, iCh, iDI, iDO, panelCh11, btnCh11)
        InitChannelItems(False, True, iCh, iDI, iDO, panelCh12, btnCh12)
        InitChannelItems(False, True, iCh, iDI, iDO, panelCh13, btnCh13)
        InitChannelItems(False, True, iCh, iDI, iDO, panelCh14, btnCh14)
        InitChannelItems(False, True, iCh, iDI, iDO, panelCh15, btnCh15)
    End Sub
    Private Sub InitAdam4053()
        Dim iCh As Integer = -1, iDI As Integer = 0, iDO As Integer = 0

        InitChannelItems(True, True, iCh, iDI, iDO, panelCh0, btnCh0)
        InitChannelItems(True, True, iCh, iDI, iDO, panelCh1, btnCh1)
        InitChannelItems(True, True, iCh, iDI, iDO, panelCh2, btnCh2)
        InitChannelItems(True, True, iCh, iDI, iDO, panelCh3, btnCh3)
        InitChannelItems(True, True, iCh, iDI, iDO, panelCh4, btnCh4)
        InitChannelItems(True, True, iCh, iDI, iDO, panelCh5, btnCh5)
        InitChannelItems(True, True, iCh, iDI, iDO, panelCh6, btnCh6)
        InitChannelItems(True, True, iCh, iDI, iDO, panelCh7, btnCh7)
        ''''''
        InitChannelItems(True, True, iCh, iDI, iDO, panelCh8, btnCh8)
        InitChannelItems(True, True, iCh, iDI, iDO, panelCh9, btnCh9)
        InitChannelItems(True, True, iCh, iDI, iDO, panelCh10, btnCh10)
        InitChannelItems(True, True, iCh, iDI, iDO, panelCh11, btnCh11)
        InitChannelItems(True, True, iCh, iDI, iDO, panelCh12, btnCh12)
        InitChannelItems(True, True, iCh, iDI, iDO, panelCh13, btnCh13)
        InitChannelItems(True, True, iCh, iDI, iDO, panelCh14, btnCh14)
        InitChannelItems(True, True, iCh, iDI, iDO, panelCh15, btnCh15)
    End Sub
    Private Sub InitAdam4055()
        Dim iCh As Integer = -1, iDI As Integer = 0, iDO As Integer = 0

        InitChannelItems(True, True, iCh, iDI, iDO, panelCh0, btnCh0)
        InitChannelItems(True, True, iCh, iDI, iDO, panelCh1, btnCh1)
        InitChannelItems(True, True, iCh, iDI, iDO, panelCh2, btnCh2)
        InitChannelItems(True, True, iCh, iDI, iDO, panelCh3, btnCh3)
        InitChannelItems(True, True, iCh, iDI, iDO, panelCh4, btnCh4)
        InitChannelItems(True, True, iCh, iDI, iDO, panelCh5, btnCh5)
        InitChannelItems(True, True, iCh, iDI, iDO, panelCh6, btnCh6)
        InitChannelItems(True, True, iCh, iDI, iDO, panelCh7, btnCh7)
        ''''''
        InitChannelItems(True, False, iCh, iDI, iDO, panelCh8, btnCh8)
        InitChannelItems(True, False, iCh, iDI, iDO, panelCh9, btnCh9)
        InitChannelItems(True, False, iCh, iDI, iDO, panelCh10, btnCh10)
        InitChannelItems(True, False, iCh, iDI, iDO, panelCh11, btnCh11)
        InitChannelItems(True, False, iCh, iDI, iDO, panelCh12, btnCh12)
        InitChannelItems(True, False, iCh, iDI, iDO, panelCh13, btnCh13)
        InitChannelItems(True, False, iCh, iDI, iDO, panelCh14, btnCh14)
        InitChannelItems(True, False, iCh, iDI, iDO, panelCh15, btnCh15)
    End Sub
    Private Sub InitAdam4056S()
        Dim iCh As Integer = -1, iDI As Integer = 0, iDO As Integer = 0

        InitChannelItems(True, False, iCh, iDI, iDO, panelCh0, btnCh0)
        InitChannelItems(True, False, iCh, iDI, iDO, panelCh1, btnCh1)
        InitChannelItems(True, False, iCh, iDI, iDO, panelCh2, btnCh2)
        InitChannelItems(True, False, iCh, iDI, iDO, panelCh3, btnCh3)
        InitChannelItems(True, False, iCh, iDI, iDO, panelCh4, btnCh4)
        InitChannelItems(True, False, iCh, iDI, iDO, panelCh5, btnCh5)
        InitChannelItems(True, False, iCh, iDI, iDO, panelCh6, btnCh6)
        InitChannelItems(True, False, iCh, iDI, iDO, panelCh7, btnCh7)
        ''''''
        InitChannelItems(True, False, iCh, iDI, iDO, panelCh8, btnCh8)
        InitChannelItems(True, False, iCh, iDI, iDO, panelCh9, btnCh9)
        InitChannelItems(True, False, iCh, iDI, iDO, panelCh10, btnCh10)
        InitChannelItems(True, False, iCh, iDI, iDO, panelCh11, btnCh11)
        InitChannelItems(False, False, iCh, iDI, iDO, panelCh12, btnCh12)
        InitChannelItems(False, False, iCh, iDI, iDO, panelCh13, btnCh13)
        InitChannelItems(False, False, iCh, iDI, iDO, panelCh14, btnCh14)
        InitChannelItems(False, False, iCh, iDI, iDO, panelCh15, btnCh15)
    End Sub
    Private Sub InitAdam4056SO()
        Dim iCh As Integer = -1, iDI As Integer = 0, iDO As Integer = 0

        InitChannelItems(True, False, iCh, iDI, iDO, panelCh0, btnCh0)
        InitChannelItems(True, False, iCh, iDI, iDO, panelCh1, btnCh1)
        InitChannelItems(True, False, iCh, iDI, iDO, panelCh2, btnCh2)
        InitChannelItems(True, False, iCh, iDI, iDO, panelCh3, btnCh3)
        InitChannelItems(True, False, iCh, iDI, iDO, panelCh4, btnCh4)
        InitChannelItems(True, False, iCh, iDI, iDO, panelCh5, btnCh5)
        InitChannelItems(True, False, iCh, iDI, iDO, panelCh6, btnCh6)
        InitChannelItems(True, False, iCh, iDI, iDO, panelCh7, btnCh7)
        ''''''
        InitChannelItems(True, False, iCh, iDI, iDO, panelCh8, btnCh8)
        InitChannelItems(True, False, iCh, iDI, iDO, panelCh9, btnCh9)
        InitChannelItems(True, False, iCh, iDI, iDO, panelCh10, btnCh10)
        InitChannelItems(True, False, iCh, iDI, iDO, panelCh11, btnCh11)
        InitChannelItems(False, False, iCh, iDI, iDO, panelCh12, btnCh12)
        InitChannelItems(False, False, iCh, iDI, iDO, panelCh13, btnCh13)
        InitChannelItems(False, False, iCh, iDI, iDO, panelCh14, btnCh14)
        InitChannelItems(False, False, iCh, iDI, iDO, panelCh15, btnCh15)
    End Sub
    Private Sub InitAdam4060()
        Dim iCh As Integer = -1, iDI As Integer = 0, iDO As Integer = 0

        InitChannelItems(True, False, iCh, iDI, iDO, panelCh0, btnCh0)
        InitChannelItems(True, False, iCh, iDI, iDO, panelCh1, btnCh1)
        InitChannelItems(True, False, iCh, iDI, iDO, panelCh2, btnCh2)
        InitChannelItems(True, False, iCh, iDI, iDO, panelCh3, btnCh3)
        InitChannelItems(False, False, iCh, iDI, iDO, panelCh4, btnCh4)
        InitChannelItems(False, False, iCh, iDI, iDO, panelCh5, btnCh5)
        InitChannelItems(False, False, iCh, iDI, iDO, panelCh6, btnCh6)
        InitChannelItems(False, False, iCh, iDI, iDO, panelCh7, btnCh7)
        ''''''
        InitChannelItems(False, False, iCh, iDI, iDO, panelCh8, btnCh8)
        InitChannelItems(False, False, iCh, iDI, iDO, panelCh9, btnCh9)
        InitChannelItems(False, False, iCh, iDI, iDO, panelCh10, btnCh10)
        InitChannelItems(False, False, iCh, iDI, iDO, panelCh11, btnCh11)
        InitChannelItems(False, False, iCh, iDI, iDO, panelCh12, btnCh12)
        InitChannelItems(False, False, iCh, iDI, iDO, panelCh13, btnCh13)
        InitChannelItems(False, False, iCh, iDI, iDO, panelCh14, btnCh14)
        InitChannelItems(False, False, iCh, iDI, iDO, panelCh15, btnCh15)
    End Sub
    Private Sub InitAdam4068()
        Dim iCh As Integer = -1, iDI As Integer = 0, iDO As Integer = 0

        InitChannelItems(True, False, iCh, iDI, iDO, panelCh0, btnCh0)
        InitChannelItems(True, False, iCh, iDI, iDO, panelCh1, btnCh1)
        InitChannelItems(True, False, iCh, iDI, iDO, panelCh2, btnCh2)
        InitChannelItems(True, False, iCh, iDI, iDO, panelCh3, btnCh3)
        InitChannelItems(True, False, iCh, iDI, iDO, panelCh4, btnCh4)
        InitChannelItems(True, False, iCh, iDI, iDO, panelCh5, btnCh5)
        InitChannelItems(True, False, iCh, iDI, iDO, panelCh6, btnCh6)
        InitChannelItems(True, False, iCh, iDI, iDO, panelCh7, btnCh7)
        ''''''
        InitChannelItems(False, False, iCh, iDI, iDO, panelCh8, btnCh8)
        InitChannelItems(False, False, iCh, iDI, iDO, panelCh9, btnCh9)
        InitChannelItems(False, False, iCh, iDI, iDO, panelCh10, btnCh10)
        InitChannelItems(False, False, iCh, iDI, iDO, panelCh11, btnCh11)
        InitChannelItems(False, False, iCh, iDI, iDO, panelCh12, btnCh12)
        InitChannelItems(False, False, iCh, iDI, iDO, panelCh13, btnCh13)
        InitChannelItems(False, False, iCh, iDI, iDO, panelCh14, btnCh14)
        InitChannelItems(False, False, iCh, iDI, iDO, panelCh15, btnCh15)
    End Sub
    Private Sub InitAdam4069()
        Dim iCh As Integer = -1, iDI As Integer = 0, iDO As Integer = 0

        InitChannelItems(True, False, iCh, iDI, iDO, panelCh0, btnCh0)
        InitChannelItems(True, False, iCh, iDI, iDO, panelCh1, btnCh1)
        InitChannelItems(True, False, iCh, iDI, iDO, panelCh2, btnCh2)
        InitChannelItems(True, False, iCh, iDI, iDO, panelCh3, btnCh3)
        InitChannelItems(True, False, iCh, iDI, iDO, panelCh4, btnCh4)
        InitChannelItems(True, False, iCh, iDI, iDO, panelCh5, btnCh5)
        InitChannelItems(True, False, iCh, iDI, iDO, panelCh6, btnCh6)
        InitChannelItems(True, False, iCh, iDI, iDO, panelCh7, btnCh7)
        ''''''
        InitChannelItems(False, False, iCh, iDI, iDO, panelCh8, btnCh8)
        InitChannelItems(False, False, iCh, iDI, iDO, panelCh9, btnCh9)
        InitChannelItems(False, False, iCh, iDI, iDO, panelCh10, btnCh10)
        InitChannelItems(False, False, iCh, iDI, iDO, panelCh11, btnCh11)
        InitChannelItems(False, False, iCh, iDI, iDO, panelCh12, btnCh12)
        InitChannelItems(False, False, iCh, iDI, iDO, panelCh13, btnCh13)
        InitChannelItems(False, False, iCh, iDI, iDO, panelCh14, btnCh14)
        InitChannelItems(False, False, iCh, iDI, iDO, panelCh15, btnCh15)

    End Sub
    Private Sub RefresDIO()
        Dim bDI() As Boolean, bDO() As Boolean

        If (adamCom.DigitalInput(m_iAddr).GetValues(m_iDITotal, m_iDOTotal, bDI, bDO)) Then
            If (m_iDITotal > 0) Then
                If (m_iDOTotal > 0) Then ' DI > 0, DO > 0
                    If (m_iDITotal > 0) Then
                        txtCh0.Text = bDI(0).ToString()
                    End If
                    If (m_iDITotal > 1) Then
                        txtCh1.Text = bDI(1).ToString()
                    End If
                    If (m_iDITotal > 2) Then
                        txtCh2.Text = bDI(2).ToString()
                    End If
                    If (m_iDITotal > 3) Then
                        txtCh3.Text = bDI(3).ToString()
                    End If
                    If (m_iDITotal > 4) Then
                        txtCh4.Text = bDI(4).ToString()
                    End If
                    If (m_iDITotal > 5) Then
                        txtCh5.Text = bDI(5).ToString()
                    End If
                    If (m_iDITotal > 6) Then
                        txtCh6.Text = bDI(6).ToString()
                    End If
                    If (m_iDITotal > 7) Then
                        txtCh7.Text = bDI(7).ToString()
                    End If
                    ''''''
                    If (m_iDOTotal > 0) Then
                        txtCh8.Text = bDO(0).ToString()
                    End If
                    If (m_iDOTotal > 1) Then
                        txtCh9.Text = bDO(1).ToString()
                    End If
                    If (m_iDOTotal > 2) Then
                        txtCh10.Text = bDO(2).ToString()
                    End If
                    If (m_iDOTotal > 3) Then
                        txtCh11.Text = bDO(3).ToString()
                    End If
                    If (m_iDOTotal > 4) Then
                        txtCh12.Text = bDO(4).ToString()
                    End If
                    If (m_iDOTotal > 5) Then
                        txtCh13.Text = bDO(5).ToString()
                    End If
                    If (m_iDOTotal > 6) Then
                        txtCh14.Text = bDO(6).ToString()
                    End If
                    If (m_iDOTotal > 7) Then
                        txtCh15.Text = bDO(7).ToString()
                    End If
                Else            ' DI > 0, DO = 0 
                    If (m_iDITotal > 0) Then
                        txtCh0.Text = bDI(0).ToString()
                    End If
                    If (m_iDITotal > 1) Then
                        txtCh1.Text = bDI(1).ToString()
                    End If
                    If (m_iDITotal > 2) Then
                        txtCh2.Text = bDI(2).ToString()
                    End If
                    If (m_iDITotal > 3) Then
                        txtCh3.Text = bDI(3).ToString()
                    End If
                    If (m_iDITotal > 4) Then
                        txtCh4.Text = bDI(4).ToString()
                    End If
                    If (m_iDITotal > 5) Then
                        txtCh5.Text = bDI(5).ToString()
                    End If
                    If (m_iDITotal > 6) Then
                        txtCh6.Text = bDI(6).ToString()
                    End If
                    If (m_iDITotal > 7) Then
                        txtCh7.Text = bDI(7).ToString()
                    End If
                    If (m_iDITotal > 8) Then
                        txtCh8.Text = bDI(8).ToString()
                    End If
                    If (m_iDITotal > 9) Then
                        txtCh9.Text = bDI(9).ToString()
                    End If
                    If (m_iDITotal > 10) Then
                        txtCh10.Text = bDI(10).ToString()
                    End If
                    If (m_iDITotal > 11) Then
                        txtCh11.Text = bDI(11).ToString()
                    End If
                    If (m_iDITotal > 12) Then
                        txtCh12.Text = bDI(12).ToString()
                    End If
                    If (m_iDITotal > 13) Then
                        txtCh13.Text = bDI(13).ToString()
                    End If
                    If (m_iDITotal > 14) Then
                        txtCh14.Text = bDI(14).ToString()
                    End If
                    If (m_iDITotal > 15) Then
                        txtCh15.Text = bDI(15).ToString()
                    End If
                End If
            Else ' DI = 0, DO > 0
                If (m_iDOTotal > 0) Then
                    txtCh0.Text = bDO(0).ToString()
                End If
                If (m_iDOTotal > 1) Then
                    txtCh1.Text = bDO(1).ToString()
                End If
                If (m_iDOTotal > 2) Then
                    txtCh2.Text = bDO(2).ToString()
                End If
                If (m_iDOTotal > 3) Then
                    txtCh3.Text = bDO(3).ToString()
                End If
                If (m_iDOTotal > 4) Then
                    txtCh4.Text = bDO(4).ToString()
                End If
                If (m_iDOTotal > 5) Then
                    txtCh5.Text = bDO(5).ToString()
                End If
                If (m_iDOTotal > 6) Then
                    txtCh6.Text = bDO(6).ToString()
                End If
                If (m_iDOTotal > 7) Then
                    txtCh7.Text = bDO(7).ToString()
                End If
                If (m_iDOTotal > 8) Then
                    txtCh8.Text = bDO(8).ToString()
                End If
                If (m_iDOTotal > 9) Then
                    txtCh9.Text = bDO(9).ToString()
                End If
                If (m_iDOTotal > 10) Then
                    txtCh10.Text = bDO(10).ToString()
                End If
                If (m_iDOTotal > 11) Then
                    txtCh11.Text = bDO(11).ToString()
                End If
                If (m_iDOTotal > 12) Then
                    txtCh12.Text = bDO(12).ToString()
                End If
                If (m_iDOTotal > 13) Then
                    txtCh13.Text = bDO(13).ToString()
                End If
                If (m_iDOTotal > 14) Then
                    txtCh14.Text = bDO(14).ToString()
                End If
                If (m_iDOTotal > 15) Then
                    txtCh15.Text = bDO(15).ToString()
                End If
            End If

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
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        m_iCount = m_iCount + 1
        txtReadCount.Text = "Polling " + m_iCount.ToString() + " times..."
        RefresDIO()
    End Sub

    Private Sub btnCh_Click(ByVal i_iCh As Integer, ByVal txtBox As TextBox)
        Dim bRet As Boolean
        timer1.Enabled = False
        If (m_iDITotal > 0) Then
            i_iCh = i_iCh - 8
        End If
        If (m_iDOTotal > 8) Then ' ADAM-4056S, ADAM-4056SO
            bRet = adamCom.DigitalOutput(m_iAddr).SetSValue(i_iCh, (txtBox.Text = "False"))
        Else
            bRet = adamCom.DigitalOutput(m_iAddr).SetValue(i_iCh, (txtBox.Text = "False"))
        End If
        If (Not bRet) Then
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
