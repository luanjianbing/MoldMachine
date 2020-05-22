Imports System.Net.Sockets
Imports Advantech.Adam

Public Class Form1
    Private m_bStart As Boolean
    Private adamModbus As AdamSocket
    Private m_Adam6000Type As Adam6000Type
    Private m_szIP As String
    Private m_iPort As Integer
    Private m_iDoTotal As Integer, m_iDiTotal As Integer, m_iCount As Integer

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        m_bStart = False   ' the action stops at the beginning
        m_szIP = "172.18.3.232" ' modbus slave IP address
        m_iPort = 502    ' modbus TCP port is 502
        adamModbus = New AdamSocket
        adamModbus.SetTimeout(1000, 1000, 1000) ' set timeout for TCP

        m_Adam6000Type = Adam6000Type.Adam6050 ' the sample is for ADAM-6050
        'm_Adam6000Type = Adam6000Type.Adam6050W ' the sample is for ADAM-6050W
        'm_Adam6000Type = Adam6000Type.Adam6051 ' the sample is for ADAM-6051
        'm_Adam6000Type = Adam6000Type.Adam6051W ' the sample is for ADAM-6051W
        'm_Adam6000Type = Adam6000Type.Adam6052 ' the sample is for ADAM-6052
        'm_Adam6000Type = Adam6000Type.Adam6055 ' the sample is for ADAM-6055
        'm_Adam6000Type = Adam6000Type.Adam6060 ' the sample is for ADAM-6060
        'm_Adam6000Type = Adam6000Type.Adam6060W ' the sample is for ADAM-6060W
        'm_Adam6000Type = Adam6000Type.Adam6066 ' the sample is for ADAM-6066

        If (m_Adam6000Type = Adam6000Type.Adam6050 Or m_Adam6000Type = Adam6000Type.Adam6050W) Then
            InitAdam6050()
        ElseIf (m_Adam6000Type = Adam6000Type.Adam6051 Or m_Adam6000Type = Adam6000Type.Adam6051W) Then
            InitAdam6051()
        ElseIf (m_Adam6000Type = Adam6000Type.Adam6052) Then
            InitAdam6052()
        ElseIf (m_Adam6000Type = Adam6000Type.Adam6055) Then
            InitAdam6055()
        ElseIf (m_Adam6000Type = Adam6000Type.Adam6060 Or m_Adam6000Type = Adam6000Type.Adam6060W) Then
            InitAdam6060()
        ElseIf (m_Adam6000Type = Adam6000Type.Adam6066) Then
            InitAdam6066()
        End If

        txtModule.Text = m_Adam6000Type.ToString()
    End Sub

    Private Sub Form1_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If (m_bStart = True) Then
            Timer1.Enabled = False
            adamModbus.Disconnect() ' disconnect slave
        End If
    End Sub

    Protected Sub InitChannelItems(ByVal i_bVisable As Boolean, ByVal i_bIsDI As Boolean, ByRef i_iDI As Integer, ByRef i_iDO As Integer, ByRef panelCh As Panel, ByRef btnCh As Button, ByRef cbxWDT As CheckBox)
        Dim iCh As Integer
        If (i_bVisable = True) Then
            panelCh.Visible = True
            iCh = i_iDI + i_iDO
            If (i_bIsDI = True) Then ' DI
                btnCh.Text = "DI " + i_iDI.ToString()
                btnCh.Enabled = False
                i_iDI = i_iDI + 1
                cbxWDT.Visible = False
            Else ' DO
                btnCh.Text = "DO " + i_iDO.ToString()
                i_iDO = i_iDO + 1
            End If
        Else
            panelCh.Visible = False
        End If
    End Sub
    Protected Sub InitAdam6050()
        Dim iDI As Integer = 0, iDO As Integer = 0

        InitChannelItems(True, True, iDI, iDO, panelCh0, btnCh0, cbxWDT0)
        InitChannelItems(True, True, iDI, iDO, panelCh1, btnCh1, cbxWDT1)
        InitChannelItems(True, True, iDI, iDO, panelCh2, btnCh2, cbxWDT2)
        InitChannelItems(True, True, iDI, iDO, panelCh3, btnCh3, cbxWDT3)
        InitChannelItems(True, True, iDI, iDO, panelCh4, btnCh4, cbxWDT4)
        InitChannelItems(True, True, iDI, iDO, panelCh5, btnCh5, cbxWDT5)
        InitChannelItems(True, True, iDI, iDO, panelCh6, btnCh6, cbxWDT6)
        InitChannelItems(True, True, iDI, iDO, panelCh7, btnCh7, cbxWDT7)
        InitChannelItems(True, True, iDI, iDO, panelCh8, btnCh8, cbxWDT8)
        InitChannelItems(True, True, iDI, iDO, panelCh9, btnCh9, cbxWDT9)
        InitChannelItems(True, True, iDI, iDO, panelCh10, btnCh10, cbxWDT10)
        InitChannelItems(True, True, iDI, iDO, panelCh11, btnCh11, cbxWDT11)
        InitChannelItems(True, False, iDI, iDO, panelCh12, btnCh12, cbxWDT12)
        InitChannelItems(True, False, iDI, iDO, panelCh13, btnCh13, cbxWDT13)
        InitChannelItems(True, False, iDI, iDO, panelCh14, btnCh14, cbxWDT14)
        InitChannelItems(True, False, iDI, iDO, panelCh15, btnCh15, cbxWDT15)
        InitChannelItems(True, False, iDI, iDO, panelCh16, btnCh16, cbxWDT16)
        InitChannelItems(True, False, iDI, iDO, panelCh17, btnCh17, cbxWDT17)

        m_iDoTotal = iDO
        m_iDiTotal = iDI
    End Sub
    Protected Sub InitAdam6051()
        Dim iDI As Integer = 0, iDO As Integer = 0

        InitChannelItems(True, True, iDI, iDO, panelCh0, btnCh0, cbxWDT0)
        InitChannelItems(True, True, iDI, iDO, panelCh1, btnCh1, cbxWDT1)
        InitChannelItems(True, True, iDI, iDO, panelCh2, btnCh2, cbxWDT2)
        InitChannelItems(True, True, iDI, iDO, panelCh3, btnCh3, cbxWDT3)
        InitChannelItems(True, True, iDI, iDO, panelCh4, btnCh4, cbxWDT4)
        InitChannelItems(True, True, iDI, iDO, panelCh5, btnCh5, cbxWDT5)
        InitChannelItems(True, True, iDI, iDO, panelCh6, btnCh6, cbxWDT6)
        InitChannelItems(True, True, iDI, iDO, panelCh7, btnCh7, cbxWDT7)
        InitChannelItems(True, True, iDI, iDO, panelCh8, btnCh8, cbxWDT8)
        InitChannelItems(True, True, iDI, iDO, panelCh9, btnCh9, cbxWDT9)
        InitChannelItems(True, True, iDI, iDO, panelCh10, btnCh10, cbxWDT10)
        InitChannelItems(True, True, iDI, iDO, panelCh11, btnCh11, cbxWDT11)
        InitChannelItems(True, False, iDI, iDO, panelCh12, btnCh12, cbxWDT12)
        InitChannelItems(True, False, iDI, iDO, panelCh13, btnCh13, cbxWDT13)
        InitChannelItems(False, True, iDI, iDO, panelCh14, btnCh14, cbxWDT14)
        InitChannelItems(False, True, iDI, iDO, panelCh15, btnCh15, cbxWDT15)
        InitChannelItems(False, True, iDI, iDO, panelCh16, btnCh16, cbxWDT16)
        InitChannelItems(False, True, iDI, iDO, panelCh17, btnCh17, cbxWDT17)

        m_iDoTotal = iDO
        m_iDiTotal = iDI

    End Sub
    Protected Sub InitAdam6052()
        Dim iDI As Integer = 0, iDO As Integer = 0

        InitChannelItems(True, True, iDI, iDO, panelCh0, btnCh0, cbxWDT0)
        InitChannelItems(True, True, iDI, iDO, panelCh1, btnCh1, cbxWDT1)
        InitChannelItems(True, True, iDI, iDO, panelCh2, btnCh2, cbxWDT2)
        InitChannelItems(True, True, iDI, iDO, panelCh3, btnCh3, cbxWDT3)
        InitChannelItems(True, True, iDI, iDO, panelCh4, btnCh4, cbxWDT4)
        InitChannelItems(True, True, iDI, iDO, panelCh5, btnCh5, cbxWDT5)
        InitChannelItems(True, True, iDI, iDO, panelCh6, btnCh6, cbxWDT6)
        InitChannelItems(True, True, iDI, iDO, panelCh7, btnCh7, cbxWDT7)
        InitChannelItems(True, False, iDI, iDO, panelCh8, btnCh8, cbxWDT8)
        InitChannelItems(True, False, iDI, iDO, panelCh9, btnCh9, cbxWDT9)
        InitChannelItems(True, False, iDI, iDO, panelCh10, btnCh10, cbxWDT10)
        InitChannelItems(True, False, iDI, iDO, panelCh11, btnCh11, cbxWDT11)
        InitChannelItems(True, False, iDI, iDO, panelCh12, btnCh12, cbxWDT12)
        InitChannelItems(True, False, iDI, iDO, panelCh13, btnCh13, cbxWDT13)
        InitChannelItems(True, False, iDI, iDO, panelCh14, btnCh14, cbxWDT14)
        InitChannelItems(True, False, iDI, iDO, panelCh15, btnCh15, cbxWDT15)
        InitChannelItems(False, True, iDI, iDO, panelCh16, btnCh16, cbxWDT16)
        InitChannelItems(False, True, iDI, iDO, panelCh17, btnCh17, cbxWDT17)

        m_iDoTotal = iDO
        m_iDiTotal = iDI

    End Sub
    Protected Sub InitAdam6055()
        Dim iDI As Integer = 0, iDO As Integer = 0

        InitChannelItems(True, True, iDI, iDO, panelCh0, btnCh0, cbxWDT0)
        InitChannelItems(True, True, iDI, iDO, panelCh1, btnCh1, cbxWDT1)
        InitChannelItems(True, True, iDI, iDO, panelCh2, btnCh2, cbxWDT2)
        InitChannelItems(True, True, iDI, iDO, panelCh3, btnCh3, cbxWDT3)
        InitChannelItems(True, True, iDI, iDO, panelCh4, btnCh4, cbxWDT4)
        InitChannelItems(True, True, iDI, iDO, panelCh5, btnCh5, cbxWDT5)
        InitChannelItems(True, True, iDI, iDO, panelCh6, btnCh6, cbxWDT6)
        InitChannelItems(True, True, iDI, iDO, panelCh7, btnCh7, cbxWDT7)
        InitChannelItems(True, True, iDI, iDO, panelCh8, btnCh8, cbxWDT8)
        InitChannelItems(True, True, iDI, iDO, panelCh9, btnCh9, cbxWDT9)
        InitChannelItems(True, True, iDI, iDO, panelCh10, btnCh10, cbxWDT10)
        InitChannelItems(True, True, iDI, iDO, panelCh11, btnCh11, cbxWDT11)
        InitChannelItems(True, True, iDI, iDO, panelCh12, btnCh12, cbxWDT12)
        InitChannelItems(True, True, iDI, iDO, panelCh13, btnCh13, cbxWDT13)
        InitChannelItems(True, True, iDI, iDO, panelCh14, btnCh14, cbxWDT14)
        InitChannelItems(True, True, iDI, iDO, panelCh15, btnCh15, cbxWDT15)
        InitChannelItems(True, True, iDI, iDO, panelCh16, btnCh16, cbxWDT16)
        InitChannelItems(True, True, iDI, iDO, panelCh17, btnCh17, cbxWDT17)

        m_iDoTotal = iDO
        m_iDiTotal = iDI

    End Sub
    Protected Sub InitAdam6060()
        Dim iDI As Integer = 0, iDO As Integer = 0

        InitChannelItems(True, True, iDI, iDO, panelCh0, btnCh0, cbxWDT0)
        InitChannelItems(True, True, iDI, iDO, panelCh1, btnCh1, cbxWDT1)
        InitChannelItems(True, True, iDI, iDO, panelCh2, btnCh2, cbxWDT2)
        InitChannelItems(True, True, iDI, iDO, panelCh3, btnCh3, cbxWDT3)
        InitChannelItems(True, True, iDI, iDO, panelCh4, btnCh4, cbxWDT4)
        InitChannelItems(True, True, iDI, iDO, panelCh5, btnCh5, cbxWDT5)
        InitChannelItems(True, False, iDI, iDO, panelCh6, btnCh6, cbxWDT6)
        InitChannelItems(True, False, iDI, iDO, panelCh7, btnCh7, cbxWDT7)
        InitChannelItems(True, False, iDI, iDO, panelCh8, btnCh8, cbxWDT8)
        InitChannelItems(True, False, iDI, iDO, panelCh9, btnCh9, cbxWDT9)
        InitChannelItems(True, False, iDI, iDO, panelCh10, btnCh10, cbxWDT10)
        InitChannelItems(True, False, iDI, iDO, panelCh11, btnCh11, cbxWDT11)
        InitChannelItems(False, True, iDI, iDO, panelCh12, btnCh12, cbxWDT12)
        InitChannelItems(False, True, iDI, iDO, panelCh13, btnCh13, cbxWDT13)
        InitChannelItems(False, True, iDI, iDO, panelCh14, btnCh14, cbxWDT14)
        InitChannelItems(False, True, iDI, iDO, panelCh15, btnCh15, cbxWDT15)
        InitChannelItems(False, True, iDI, iDO, panelCh16, btnCh16, cbxWDT16)
        InitChannelItems(False, True, iDI, iDO, panelCh17, btnCh17, cbxWDT17)

        m_iDoTotal = iDO
        m_iDiTotal = iDI

    End Sub
    Protected Sub InitAdam6066()
        Dim iDI As Integer = 0, iDO As Integer = 0

        InitChannelItems(True, True, iDI, iDO, panelCh0, btnCh0, cbxWDT0)
        InitChannelItems(True, True, iDI, iDO, panelCh1, btnCh1, cbxWDT1)
        InitChannelItems(True, True, iDI, iDO, panelCh2, btnCh2, cbxWDT2)
        InitChannelItems(True, True, iDI, iDO, panelCh3, btnCh3, cbxWDT3)
        InitChannelItems(True, True, iDI, iDO, panelCh4, btnCh4, cbxWDT4)
        InitChannelItems(True, True, iDI, iDO, panelCh5, btnCh5, cbxWDT5)
        InitChannelItems(True, False, iDI, iDO, panelCh6, btnCh6, cbxWDT6)
        InitChannelItems(True, False, iDI, iDO, panelCh7, btnCh7, cbxWDT7)
        InitChannelItems(True, False, iDI, iDO, panelCh8, btnCh8, cbxWDT8)
        InitChannelItems(True, False, iDI, iDO, panelCh9, btnCh9, cbxWDT9)
        InitChannelItems(True, False, iDI, iDO, panelCh10, btnCh10, cbxWDT10)
        InitChannelItems(True, False, iDI, iDO, panelCh11, btnCh11, cbxWDT11)
        InitChannelItems(False, True, iDI, iDO, panelCh12, btnCh12, cbxWDT12)
        InitChannelItems(False, True, iDI, iDO, panelCh13, btnCh13, cbxWDT13)
        InitChannelItems(False, True, iDI, iDO, panelCh14, btnCh14, cbxWDT14)
        InitChannelItems(False, True, iDI, iDO, panelCh15, btnCh15, cbxWDT15)
        InitChannelItems(False, True, iDI, iDO, panelCh16, btnCh16, cbxWDT16)
        InitChannelItems(False, True, iDI, iDO, panelCh17, btnCh17, cbxWDT17)

        m_iDoTotal = iDO
        m_iDiTotal = iDI
    End Sub

    Private Sub buttonStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonStart.Click
        If (m_bStart = True) Then ' was started
            panelDIO.Enabled = False
            m_bStart = False  ' starting flag
            Timer1.Enabled = False ' disable timer
            adamModbus.Disconnect() ' disconnect slave
            buttonStart.Text = "Start"
            btnApplyWDT.Enabled = False
        Else ' was stoped
            If (adamModbus.Connect(m_szIP, ProtocolType.Tcp, m_iPort)) Then
                RefreshWDT()
                m_iCount = 0 ' reset the reading counter
                panelDIO.Enabled = True
                Timer1.Enabled = True ' enable timer
                buttonStart.Text = "Stop"
                m_bStart = True ' starting flag
                btnApplyWDT.Enabled = True
            Else
                MessageBox.Show("Connect to " + m_szIP + " failed", "Error")
            End If
        End If
    End Sub

    Private Sub RefreshDIO()
        Dim iDiStart As Integer = 1, iDoStart As Integer = 17
        Dim iChTotal As Integer
        Dim bDiData() As Boolean, bDoData() As Boolean, bData() As Boolean

        If (m_Adam6000Type = Adam6000Type.Adam6055) Then

            If (adamModbus.Modbus().ReadCoilStatus(iDiStart, m_iDiTotal, bDiData) = True) Then

                iChTotal = m_iDiTotal
                bData = New Boolean(iChTotal - 1) {}
                Array.Copy(bDiData, 0, bData, 0, m_iDiTotal)
                If (iChTotal > 0) Then
                    txtCh0.Text = bData(0).ToString()
                End If
                If (iChTotal > 1) Then
                    txtCh1.Text = bData(1).ToString()
                End If
                If (iChTotal > 2) Then
                    txtCh2.Text = bData(2).ToString()
                End If
                If (iChTotal > 3) Then
                    txtCh3.Text = bData(3).ToString()
                End If
                If (iChTotal > 4) Then
                    txtCh4.Text = bData(4).ToString()
                End If
                If (iChTotal > 5) Then
                    txtCh5.Text = bData(5).ToString()
                End If
                If (iChTotal > 6) Then
                    txtCh6.Text = bData(6).ToString()
                End If
                If (iChTotal > 7) Then
                    txtCh7.Text = bData(7).ToString()
                End If
                If (iChTotal > 8) Then
                    txtCh8.Text = bData(8).ToString()
                End If
                If (iChTotal > 9) Then
                    txtCh9.Text = bData(9).ToString()
                End If
                If (iChTotal > 10) Then
                    txtCh10.Text = bData(10).ToString()
                End If
                If (iChTotal > 11) Then
                    txtCh11.Text = bData(11).ToString()
                End If
                If (iChTotal > 12) Then
                    txtCh12.Text = bData(12).ToString()
                End If
                If (iChTotal > 13) Then
                    txtCh13.Text = bData(13).ToString()
                End If
                If (iChTotal > 14) Then
                    txtCh14.Text = bData(14).ToString()
                End If
                If (iChTotal > 15) Then
                    txtCh15.Text = bData(15).ToString()
                End If
                If (iChTotal > 16) Then
                    txtCh16.Text = bData(16).ToString()
                End If
                If (iChTotal > 17) Then
                    txtCh17.Text = bData(17).ToString()
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
                txtCh16.Text = "Fail"
                txtCh17.Text = "Fail"
            End If

        Else

            If ((adamModbus.Modbus().ReadCoilStatus(iDiStart, m_iDiTotal, bDiData) And adamModbus.Modbus().ReadCoilStatus(iDoStart, m_iDoTotal, bDoData)) = True) Then

                iChTotal = m_iDiTotal + m_iDoTotal
                bData = New Boolean(iChTotal - 1) {}
                Array.Copy(bDiData, 0, bData, 0, m_iDiTotal)
                Array.Copy(bDoData, 0, bData, m_iDiTotal, m_iDoTotal)
                If (iChTotal > 0) Then
                    txtCh0.Text = bData(0).ToString()
                End If
                If (iChTotal > 1) Then
                    txtCh1.Text = bData(1).ToString()
                End If
                If (iChTotal > 2) Then
                    txtCh2.Text = bData(2).ToString()
                End If
                If (iChTotal > 3) Then
                    txtCh3.Text = bData(3).ToString()
                End If
                If (iChTotal > 4) Then
                    txtCh4.Text = bData(4).ToString()
                End If
                If (iChTotal > 5) Then
                    txtCh5.Text = bData(5).ToString()
                End If
                If (iChTotal > 6) Then
                    txtCh6.Text = bData(6).ToString()
                End If
                If (iChTotal > 7) Then
                    txtCh7.Text = bData(7).ToString()
                End If
                If (iChTotal > 8) Then
                    txtCh8.Text = bData(8).ToString()
                End If
                If (iChTotal > 9) Then
                    txtCh9.Text = bData(9).ToString()
                End If
                If (iChTotal > 10) Then
                    txtCh10.Text = bData(10).ToString()
                End If
                If (iChTotal > 11) Then
                    txtCh11.Text = bData(11).ToString()
                End If
                If (iChTotal > 12) Then
                    txtCh12.Text = bData(12).ToString()
                End If
                If (iChTotal > 13) Then
                    txtCh13.Text = bData(13).ToString()
                End If
                If (iChTotal > 14) Then
                    txtCh14.Text = bData(14).ToString()
                End If
                If (iChTotal > 15) Then
                    txtCh15.Text = bData(15).ToString()
                End If
                If (iChTotal > 16) Then
                    txtCh16.Text = bData(16).ToString()
                End If
                If (iChTotal > 17) Then
                    txtCh17.Text = bData(17).ToString()
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
                txtCh16.Text = "Fail"
                txtCh17.Text = "Fail"
            End If
        End If

        System.GC.Collect()

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False

        m_iCount = m_iCount + 1 ' increment the reading counter
        txtReadCount.Text = "Read coil " + m_iCount.ToString() + " times..."
        RefreshDIO()

        Timer1.Enabled = True
    End Sub

    Private Sub btnCh_Click(ByVal i_iCh As Integer, ByVal txtBox As TextBox)
        Dim iOnOff As Integer, iStart As Integer = 17 + i_iCh - m_iDiTotal

        timer1.Enabled = False
        If (txtBox.Text = "True") Then ' was ON, now set to OFF
            iOnOff = 0
        Else
            iOnOff = 1
        End If
        If (adamModbus.Modbus().ForceSingleCoil(iStart, iOnOff)) Then
            RefreshDIO()
        Else
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

    Private Sub btnCh16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh16.Click
        btnCh_Click(16, txtCh16)
    End Sub

    Private Sub btnCh17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh17.Click
        btnCh_Click(17, txtCh17)
    End Sub

    Private Sub btnApplyWDT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApplyWDT.Click
        Dim iCnt As Int32
        Dim bWDT(m_iDoTotal) As Boolean
        Timer1.Enabled = False

        iCnt = 0

        ApplyWDT(0, iCnt, cbxWDT0, bWDT)
        ApplyWDT(1, iCnt, cbxWDT1, bWDT)
        ApplyWDT(2, iCnt, cbxWDT2, bWDT)
        ApplyWDT(3, iCnt, cbxWDT3, bWDT)
        ApplyWDT(4, iCnt, cbxWDT4, bWDT)
        ApplyWDT(5, iCnt, cbxWDT5, bWDT)
        ApplyWDT(6, iCnt, cbxWDT6, bWDT)
        ApplyWDT(7, iCnt, cbxWDT7, bWDT)
        ApplyWDT(8, iCnt, cbxWDT8, bWDT)
        ApplyWDT(9, iCnt, cbxWDT9, bWDT)
        ApplyWDT(10, iCnt, cbxWDT10, bWDT)
        ApplyWDT(11, iCnt, cbxWDT11, bWDT)
        ApplyWDT(12, iCnt, cbxWDT12, bWDT)
        ApplyWDT(13, iCnt, cbxWDT13, bWDT)
        ApplyWDT(14, iCnt, cbxWDT14, bWDT)
        ApplyWDT(15, iCnt, cbxWDT15, bWDT)
        ApplyWDT(16, iCnt, cbxWDT16, bWDT)
        ApplyWDT(17, iCnt, cbxWDT17, bWDT)

        ApplyWDT_Click(chbxCommWDT.Checked, chbxPtoPWDT.Checked, bWDT, True)

        Timer1.Enabled = True
    End Sub

    Private Sub ApplyWDT(ByVal i_iCh As Int32, ByRef i_iCount As Int32, ByRef cbxWDT As CheckBox, ByRef i_bWDT As Boolean())
        If ((m_iDiTotal < (i_iCh + 1)) AndAlso (i_iCount < m_iDoTotal)) Then
            i_bWDT(i_iCount) = cbxWDT.Checked
            i_iCount = i_iCount + 1
        End If
    End Sub

    Private Sub ApplyWDT_Click(ByVal bCommFSV As Boolean, ByVal bPtoPFSV As Boolean, ByVal bWDT As Boolean(), ByVal bShowOk As Boolean)
        If (adamModbus.DigitalOutput().SetWDTMask(bCommFSV, bPtoPFSV, bWDT)) Then
            If (bShowOk) Then
                MessageBox.Show("Set WDT mask done!", "Information")
            End If
            RefreshWDT()
        Else
            MessageBox.Show("Set WDT mask failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        End If
    End Sub

    Private Sub RefreshWDTCheck(ByVal i_iCh As Int32, ByRef i_iCount As Int32, ByRef cbxWDT As CheckBox, ByRef i_bWDT As Boolean())
        If ((m_iDiTotal < (i_iCh + 1)) AndAlso (i_iCount < 8)) Then
            cbxWDT.Checked = i_bWDT(i_iCount)
            i_iCount = i_iCount + 1
        End If
    End Sub

    Private Sub RefreshWDT()
        Dim iCnt As Int32
        Dim bCommFSV As Boolean
        Dim bPtoPFSV As Boolean
        Dim bWDT As Boolean()

        'if (m_Adam6000Type = Adam6000Type.Adam6055) // no DO for 6055
        If (m_iDoTotal = 0) Then
            btnApplyWDT.Visible = False
            chbxCommWDT.Visible = False
            chbxPtoPWDT.Visible = False
            Return
        End If

        If (adamModbus.DigitalOutput().GetWDTMask(bCommFSV, bPtoPFSV, bWDT) AndAlso (bWDT.Length = 8)) Then
            chbxCommWDT.Checked = bCommFSV
            chbxPtoPWDT.Checked = bPtoPFSV
            iCnt = 0
            RefreshWDTCheck(0, iCnt, cbxWDT0, bWDT)
            RefreshWDTCheck(1, iCnt, cbxWDT1, bWDT)
            RefreshWDTCheck(2, iCnt, cbxWDT2, bWDT)
            RefreshWDTCheck(3, iCnt, cbxWDT3, bWDT)
            RefreshWDTCheck(4, iCnt, cbxWDT4, bWDT)
            RefreshWDTCheck(5, iCnt, cbxWDT5, bWDT)
            RefreshWDTCheck(6, iCnt, cbxWDT6, bWDT)
            RefreshWDTCheck(7, iCnt, cbxWDT7, bWDT)
            RefreshWDTCheck(8, iCnt, cbxWDT8, bWDT)
            RefreshWDTCheck(9, iCnt, cbxWDT9, bWDT)
            RefreshWDTCheck(10, iCnt, cbxWDT10, bWDT)
            RefreshWDTCheck(11, iCnt, cbxWDT11, bWDT)
            RefreshWDTCheck(12, iCnt, cbxWDT12, bWDT)
            RefreshWDTCheck(13, iCnt, cbxWDT13, bWDT)
            RefreshWDTCheck(14, iCnt, cbxWDT14, bWDT)
            RefreshWDTCheck(15, iCnt, cbxWDT15, bWDT)
            RefreshWDTCheck(16, iCnt, cbxWDT16, bWDT)
            RefreshWDTCheck(17, iCnt, cbxWDT17, bWDT)
        Else
            MessageBox.Show("GetWDTMask() failed;")
        End If

    End Sub

    Private Sub chbxCommWDT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbxCommWDT.Click
        If (chbxCommWDT.Checked AndAlso chbxPtoPWDT.Checked) Then
            chbxPtoPWDT.Checked = False
        End If
    End Sub

    Private Sub chbxPtoPWDT_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbxPtoPWDT.Click
        If (chbxPtoPWDT.Checked AndAlso chbxCommWDT.Checked) Then
            chbxCommWDT.Checked = False
        End If
    End Sub
End Class
