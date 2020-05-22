Imports System.Threading
Imports Advantech.Common

Public Class Form1
    Private m_StreamThread As Thread
    Private udpServer As UDPSocketServer
    Private udpStream As SocketStream
    Private m_bStreamThreadStop As Boolean
    Private m_bStreamThreadTerminate As Boolean
    Private m_szMsg As String

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

    End Sub

    Public Sub listBoxMsg_ThreadUpdate(ByVal sender As System.Object, ByVal e As System.EventArgs)
        listBoxMsg.Items.Add(m_szMsg)
        listBoxMsg.SelectedIndex = listBoxMsg.Items.Count - 1
    End Sub

    Public Sub AddListBoxItem(ByVal szMsg As String)
        m_szMsg = szMsg
        Me.listBoxMsg.Invoke(New EventHandler(AddressOf listBoxMsg_ThreadUpdate))
    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim szIP() As String
        Dim iPort As Integer = 5168 'data streaming UDP listen port
        Dim sk As System.Net.Sockets.Socket

        If (btnStart.Text = "Start") Then

            Try

                udpServer = New UDPSocketServer()
                udpServer.Create(iPort)
                sk = udpServer.ServerSocket()
                udpStream = New SocketStream(sk, 2000, 2000)
                Advantech.Adam.AdamSocket.GetLocalNetwork(szIP)
                btnStart.Text = "Stop"
                AddListBoxItem("Local IP = " + szIP(0))
                AddListBoxItem("Start listening... ")

                Me.m_bStreamThreadStop = False
                Me.m_bStreamThreadTerminate = False
                m_StreamThread = New System.Threading.Thread(New ThreadStart(AddressOf Me.ThreadProc))
                m_StreamThread.Start()

            Catch

                If (Not m_StreamThread Is Nothing) Then

                    Me.m_bStreamThreadStop = True
                    Dim iCnt As Integer = 0

                    While (Not m_bStreamThreadTerminate)
                        Thread.Sleep(10)
                        iCnt = iCnt + 1

                        If (iCnt > 50) Then
                            Exit While
                        End If

                    End While

                    m_StreamThread = Nothing

                End If

                udpServer.Terminate()
                udpServer = Nothing
                udpStream = Nothing
                btnStart.Text = "Start"
                MessageBox.Show("Failed to start data streaming process!", "Error")

            End Try

        Else

            Try

                If (Not m_StreamThread Is Nothing) Then

                    Me.m_bStreamThreadStop = True
                    Dim iCnt As Integer = 0

                    While (Not m_bStreamThreadTerminate)
                        Thread.Sleep(10)
                        iCnt = iCnt + 1

                        If (iCnt > 50) Then
                            Exit While
                        End If

                    End While

                    m_StreamThread = Nothing
                End If

                udpServer.Terminate()
                udpServer = Nothing
                udpStream = Nothing
                btnStart.Text = "Start"

            Catch ex As ObjectDisposedException

            End Try

        End If

    End Sub

    Public Sub ThreadProc()

        Dim data As DataStructure
        Dim remoteEP As System.Net.EndPoint
        Dim dt As DateTime = DateTime.Now
        Dim byData(256) As Byte
        Dim iLen As Integer

        While (Not m_bStreamThreadStop)

            Try
                Thread.Sleep(500)
                dt = DateTime.Now
                If (udpStream.DataArrive(100)) Then

                    If (udpStream.RecvUDP(remoteEP, byData, iLen)) Then
                        AddListBoxItem("********** Data received from " + remoteEP.ToString() + " , At " + dt.Hour.ToString() + ":" + dt.Minute.ToString() + ":" + dt.Second.ToString() + " **********")
                        data = New DataStructure()
                        data.SetData(byData, iLen)
                        DisplayInform(data)
                        data = Nothing
                    Else
                        AddListBoxItem("Failed to received")
                    End If

                End If

            Catch ode As ObjectDisposedException
                Me.m_bStreamThreadTerminate = True
                Exit While

            Catch ex As Exception
                MessageBox.Show(ex.Message)
                Me.m_bStreamThreadTerminate = True
                Exit While

            End Try

        End While

        Me.m_bStreamThreadTerminate = True

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        m_bStreamThreadStop = False
        m_bStreamThreadTerminate = False
    End Sub

    Private Sub Form1_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        Try

            If (Not m_StreamThread Is Nothing) Then

                Me.m_bStreamThreadStop = True
                Dim iCnt As Integer = 0

                While (Not m_bStreamThreadTerminate)
                    Thread.Sleep(10)
                    iCnt = iCnt + 1

                    If (iCnt > 50) Then
                        Exit While
                    End If

                End While

                m_StreamThread = Nothing

            End If

            If (Not udpServer Is Nothing) Then
                udpServer.Terminate()
                udpServer = Nothing
            End If

            If (Not udpStream Is Nothing) Then
                udpStream = Nothing
            End If

        Catch

        End Try

    End Sub

    Private Sub DisplayInform(ByVal data As DataStructure)
        'for those who wants to listen the data streaming from ADAM-6000
        'you have to make sure the module type you are listening to.

        'for ADAM-6000 serias
        'DisplayAdam6015(data)
        'DisplayAdam6017(data)
        'DisplayAdam6018(data)
        'DisplayAdam6024(data)
        'DisplayAdam6050(data)
        'DisplayAdam6051(data)
        'DisplayAdam6052(data)
        'DisplayAdam6060(data)
        'DisplayAdam6066(data)
        'DisplayAdam6217(data)
        'DisplayAdam6224(data)
        'DisplayAdam6250(data)
        'DisplayAdam6251(data)
        'DisplayAdam6256(data)
        'DisplayAdam6260(data)
        'DisplayAdam6266(data)

        'for those who wants to listen the data streaming from ADAM-5000/TCP
        'you have to make sure the module type on each slot you are listening to.
        'For example: (ADAM-5017 on slot 0~3, and ADAM-5060 on slot 4~7)
        'DisplayAdam5017(data, 0)
        'DisplayAdam5017(data, 1)
        'DisplayAdam5017(data, 2)
        'DisplayAdam5017(data, 3)
        'DisplayAdam5060(data, 4)
        'DisplayAdam5060(data, 5)
        'DisplayAdam5060(data, 6)
        'DisplayAdam5060(data, 7)

        'for ADAM-5000/TCP serias, each slot you can use
        'DisplayAdam5013(data, 0)
        'DisplayAdam5017(data, 0)
        'DisplayAdam5018(data, 0)
        'DisplayAdam5024(data, 0)
        'DisplayAdam5050(data, 0)
        'DisplayAdam5051(data, 0)
        'DisplayAdam5052(data, 0)
        'DisplayAdam5055(data, 0)
        'DisplayAdam5056(data, 0)
        'DisplayAdam5060(data, 0)
        'DisplayAdam5069(data, 0)
        'DisplayAdam5068(data, 0)
        'DisplayAdam5080(data, 0)
        'DisplayAdam5081(data, 0)

        DisplayAdam5024(data, 1)

    End Sub

    Private Sub DisplayAdam6015(ByVal data As DataStructure)
        Dim i As Integer
        Dim szMsg As String

        For i = 0 To 6
            szMsg = String.Format("AI[{0}]: Data=0x{1:X04}, Max=0x{2:X04}, Min=0x{3:X04}", i, data.AIO(i), data.AIO(i + 9), data.AIO(i + 18))
            AddListBoxItem(szMsg)
        Next

        szMsg = String.Format("Ave=0x{0:X04}", data.AIO(8))
        AddListBoxItem(szMsg)
    End Sub

    Private Sub DisplayAdam6017(ByVal data As DataStructure)
        Dim i As Integer
        Dim szMsg As String

        szMsg = String.Format("DO=0x{0:X04}", data.DIO(1))
        AddListBoxItem(szMsg)

        For i = 0 To 7
            szMsg = String.Format("AI[{0}]: Data=0x{1:X04}, Max=0x{2:X04}, Min=0x{3:X04}", i, data.AIO(i), data.AIO(i + 9), data.AIO(i + 18))
            AddListBoxItem(szMsg)
        Next

        szMsg = String.Format("Ave=0x{0:X04}", data.AIO(8))
        AddListBoxItem(szMsg)

    End Sub

    Private Sub DisplayAdam6018(ByVal data As DataStructure)
        DisplayAdam6017(data)
    End Sub

    Private Sub DisplayAdam6024(ByVal data As DataStructure)
        Dim i As Integer
        Dim szMsg As String

        szMsg = String.Format("DI=0x{0:X04}", data.DIO(0))
        AddListBoxItem(szMsg)
        szMsg = String.Format("DO=0x{0:X04}", data.DIO(1))
        AddListBoxItem(szMsg)

        For i = 0 To 5
            szMsg = String.Format("AI[{0}]: Data=0x{1:X04}", i, data.AIO(i))
            AddListBoxItem(szMsg)
        Next

        For i = 0 To 1
            szMsg = String.Format("AO[{0}]: Data=0x{1:X04}", i, data.AIO(i + 10))
            AddListBoxItem(szMsg)
        Next

    End Sub

    Private Sub DisplayAdam6050(ByVal data As DataStructure)
        Dim i As Integer
        Dim szMsg As String
        Dim uVal As UInt32

        szMsg = String.Format("DI=0x{0:X04}", data.DIO(0))
        AddListBoxItem(szMsg)
        szMsg = String.Format("DO=0x{0:X04}", data.DIO(1))
        AddListBoxItem(szMsg)

        For i = 0 To 11
            uVal = data.AIO(i * 2 + 1)
            uVal = Convert.ToUInt32(uVal * 65536 + data.AIO(i * 2))
            szMsg = String.Format("Counter[{0}]: Data={1}", i, uVal)
            AddListBoxItem(szMsg)
        Next

    End Sub

    Private Sub DisplayAdam6051(ByVal data As DataStructure)
        Dim i As Integer
        Dim szMsg As String
        Dim uVal As UInt32

        szMsg = String.Format("DI=0x{0:X04}", data.DIO(0))
        AddListBoxItem(szMsg)
        szMsg = String.Format("DO=0x{0:X04}", data.DIO(1))
        AddListBoxItem(szMsg)

        For i = 0 To 13
            uVal = data.AIO(i * 2 + 1)
            uVal = Convert.ToUInt32(uVal * 65536 + data.AIO(i * 2))
            szMsg = String.Format("Counter[{0}]: Data={1}", i, uVal)
            AddListBoxItem(szMsg)
        Next

    End Sub

    Private Sub DisplayAdam6052(ByVal data As DataStructure)
        Dim i As Integer
        Dim szMsg As String
        Dim uVal As UInt32

        szMsg = String.Format("DI=0x{0:X04}", data.DIO(0))
        AddListBoxItem(szMsg)
        szMsg = String.Format("DO=0x{0:X04}", data.DIO(1))
        AddListBoxItem(szMsg)

        For i = 0 To 7
            uVal = data.AIO(i * 2 + 1)
            uVal = Convert.ToUInt32(uVal * 65536 + data.AIO(i * 2))
            szMsg = String.Format("Counter[{0}]: Data={1}", i, uVal)
            AddListBoxItem(szMsg)
        Next

    End Sub

    Private Sub DisplayAdam6060(ByVal data As DataStructure)
        Dim i As Integer
        Dim szMsg As String
        Dim uVal As UInt32

        szMsg = String.Format("DI=0x{0:X04}", data.DIO(0))
        AddListBoxItem(szMsg)
        szMsg = String.Format("DO=0x{0:X04}", data.DIO(1))
        AddListBoxItem(szMsg)

        For i = 0 To 5
            uVal = data.AIO(i * 2 + 1)
            uVal = Convert.ToUInt32(uVal * 65536 + data.AIO(i * 2))
            szMsg = String.Format("Counter[{0}]: Data={1}", i, uVal)
            AddListBoxItem(szMsg)
        Next

    End Sub

    Private Sub DisplayAdam6066(ByVal data As DataStructure)
        DisplayAdam6060(data)
    End Sub

    Private Sub DisplayAdam6217(ByVal data As DataStructure)
        DisplayAdam6017(data)
    End Sub

    Private Sub DisplayAdam6224(ByVal data As DataStructure)
        Dim i As Integer
        Dim szMsg As String

        For i = 0 To 3
            szMsg = String.Format("AO[{0}]: Data=0x{1:X04}", i, data.AIO(i))
            AddListBoxItem(szMsg)
        Next

    End Sub

    Private Sub DisplayAdam6250(ByVal data As DataStructure)
        Dim i As Integer
        Dim szMsg As String
        Dim uVal As UInt32

        szMsg = String.Format("DI=0x{0:X04}", data.DIO(0))
        AddListBoxItem(szMsg)
        szMsg = String.Format("DO=0x{0:X04}", data.DIO(1))
        AddListBoxItem(szMsg)

        For i = 0 To 7
            uVal = data.AIO(i * 2 + 1)
            uVal = Convert.ToUInt32(CUInt(uVal) * 65536 + data.AIO(i * 2))
            szMsg = String.Format("Counter[{0}]: Data={1}", i, uVal)
            AddListBoxItem(szMsg)
        Next

    End Sub

    Private Sub DisplayAdam6251(ByVal data As DataStructure)
        Dim i As Integer
        Dim szMsg As String
        Dim uVal As UInt32

        szMsg = String.Format("DI=0x{0:X04}", data.DIO(0))
        AddListBoxItem(szMsg)
        szMsg = String.Format("DO=0x{0:X04}", data.DIO(1))
        AddListBoxItem(szMsg)

        For i = 0 To 15
            uVal = data.AIO(i * 2 + 1)
            uVal = Convert.ToUInt32(CUInt(uVal) * 65536 + data.AIO(i * 2))
            szMsg = String.Format("Counter[{0}]: Data={1}", i, uVal)
            AddListBoxItem(szMsg)
        Next

    End Sub

    Private Sub DisplayAdam6256(ByVal data As DataStructure)
        Dim szMsg As String

        szMsg = String.Format("DI=0x{0:X04}", data.DIO(0))
        AddListBoxItem(szMsg)
        szMsg = String.Format("DO=0x{0:X04}", data.DIO(1))
        AddListBoxItem(szMsg)
    End Sub

    Private Sub DisplayAdam6260(ByVal data As DataStructure)
        Dim szMsg As String

        szMsg = String.Format("DI=0x{0:X04}", data.DIO(0))
        AddListBoxItem(szMsg)
        szMsg = String.Format("DO=0x{0:X04}", data.DIO(1))
        AddListBoxItem(szMsg)
    End Sub

    Private Sub DisplayAdam6266(ByVal data As DataStructure)
        Dim i As Integer
        Dim szMsg As String
        Dim uVal As UInt32

        szMsg = String.Format("DI=0x{0:X04}", data.DIO(0))
        AddListBoxItem(szMsg)
        szMsg = String.Format("DO=0x{0:X04}", data.DIO(1))
        AddListBoxItem(szMsg)

        For i = 0 To 3
            uVal = data.AIO(i * 2 + 1)
            uVal = Convert.ToUInt32(CUInt(uVal) * 65536 + data.AIO(i * 2))
            szMsg = String.Format("Counter[{0}]: Data={1}", i, uVal)
            AddListBoxItem(szMsg)
        Next

    End Sub

    Private Sub DisplayAdam5050(ByVal data As DataStructure, ByVal iSlot As Integer)
        Dim szMsg As String
        szMsg = String.Format("Slot[{0}]", iSlot)
        AddListBoxItem(szMsg)
        szMsg = String.Format("    DIO=0x{0:X04}", data.DIO(iSlot))
        AddListBoxItem(szMsg)
    End Sub

    Private Sub DisplayAdam5051(ByVal data As DataStructure, ByVal iSlot As Integer)
        DisplayAdam5050(data, iSlot)
    End Sub

    Private Sub DisplayAdam5052(ByVal data As DataStructure, ByVal iSlot As Integer)
        DisplayAdam5050(data, iSlot)
    End Sub

    Private Sub DisplayAdam5055(ByVal data As DataStructure, ByVal iSlot As Integer)
        DisplayAdam5050(data, iSlot)
    End Sub

    Private Sub DisplayAdam5056(ByVal data As DataStructure, ByVal iSlot As Integer)
        DisplayAdam5050(data, iSlot)
    End Sub

    Private Sub DisplayAdam5060(ByVal data As DataStructure, ByVal iSlot As Integer)
        DisplayAdam5050(data, iSlot)
    End Sub

    Private Sub DisplayAdam5068(ByVal data As DataStructure, ByVal iSlot As Integer)
        DisplayAdam5050(data, iSlot)
    End Sub

    Private Sub DisplayAdam5069(ByVal data As DataStructure, ByVal iSlot As Integer)
        DisplayAdam5050(data, iSlot)
    End Sub

    Private Sub DisplayAdam5013(ByVal data As DataStructure, ByVal iSlot As Integer)
        Dim szMsg As String

        szMsg = String.Format("Slot[{0}]", iSlot)
        AddListBoxItem(szMsg)
        szMsg = String.Format("    Ch[0]=0x{0:X04}, Ch[1]=0x{1:X04}, Ch[2]=0x{2:X04}", data.AIO(iSlot * 8), data.AIO(iSlot * 8 + 1), data.AIO(iSlot * 8 + 2))
        AddListBoxItem(szMsg)

    End Sub

    Private Sub DisplayAdam5017(ByVal data As DataStructure, ByVal iSlot As Integer)
        Dim szMsg As String

        szMsg = String.Format("Slot[{0}]", iSlot)
        AddListBoxItem(szMsg)
        szMsg = String.Format("    Ch[0]=0x{0:X04}, Ch[1]=0x{1:X04}, Ch[2]=0x{2:X04}, Ch[3]=0x{3:X04}, Ch[4]=0x{4:X04}, Ch[5]=0x{5:X04}, Ch[6]=0x{6:X04}, Ch[7]=0x{7:X04}", data.AIO(iSlot * 8), data.AIO(iSlot * 8 + 1), data.AIO(iSlot * 8 + 2), data.AIO(iSlot * 8 + 3), data.AIO(iSlot * 8 + 4), data.AIO(iSlot * 8 + 5), data.AIO(iSlot * 8 + 6), data.AIO(iSlot * 8 + 7))
        AddListBoxItem(szMsg)

    End Sub

    Private Sub DisplayAdam5018(ByVal data As DataStructure, ByVal iSlot As Integer)
        Dim szMsg As String

        szMsg = String.Format("Slot[{0}]", iSlot)
        AddListBoxItem(szMsg)
        szMsg = String.Format("    Ch[0]=0x{0:X04}, Ch[1]=0x{1:X04}, Ch[2]=0x{2:X04}, Ch[3]=0x{3:X04}, Ch[4]=0x{4:X04}, Ch[5]=0x{5:X04}, Ch[6]=0x{6:X04}", data.AIO(iSlot * 8), data.AIO(iSlot * 8 + 1), data.AIO(iSlot * 8 + 2), data.AIO(iSlot * 8 + 3), data.AIO(iSlot * 8 + 4), data.AIO(iSlot * 8 + 5), data.AIO(iSlot * 8 + 6))
        AddListBoxItem(szMsg)

    End Sub

    Private Sub DisplayAdam5024(ByVal data As DataStructure, ByVal iSlot As Integer)
        Dim szMsg As String

        szMsg = String.Format("Slot[{0}]", iSlot)
        AddListBoxItem(szMsg)
        szMsg = String.Format("    Ch[0]=0x{0:X04}, Ch[1]=0x{1:X04}, Ch[2]=0x{2:X04}, Ch[3]=0x{3:X04}", data.AIO(iSlot * 8), data.AIO(iSlot * 8 + 1), data.AIO(iSlot * 8 + 2), data.AIO(iSlot * 8 + 3))
        AddListBoxItem(szMsg)

    End Sub

    Private Sub DisplayAdam5080(ByVal data As DataStructure, ByVal iSlot As Integer)
        Dim szMsg As String
        Dim uVal0, uVal1, uVal2, uVal3 As UInt32

        uVal0 = data.AIO(iSlot * 8 + 1)
        uVal0 = Convert.ToUInt32(uVal0 * 65536 + data.AIO(iSlot * 8))
        uVal1 = data.AIO(iSlot * 8 + 3)
        uVal1 = Convert.ToUInt32(uVal1 * 65536 + data.AIO(iSlot * 8 + 2))
        uVal2 = data.AIO(iSlot * 8 + 5)
        uVal2 = Convert.ToUInt32(uVal2 * 65536 + data.AIO(iSlot * 8 + 4))
        uVal3 = data.AIO(iSlot * 8 + 7)
        uVal3 = Convert.ToUInt32(uVal3 * 65536 + data.AIO(iSlot * 8 + 6))
        szMsg = String.Format("Slot[{0}]", iSlot)
        AddListBoxItem(szMsg)
        szMsg = String.Format("    Ch[0]={0}, Ch[1]={1}, Ch[2]={2}, Ch[3]={3}", uVal0, uVal1, uVal2, uVal3)
        AddListBoxItem(szMsg)

    End Sub

    Private Sub DisplayAdam5081(ByVal data As DataStructure, ByVal iSlot As Integer)
        Dim szMsg As String
        Dim uVal0, uVal1, uVal2, uVal3 As UInt32

        uVal0 = data.AIO(iSlot * 8 + 1)
        uVal0 = Convert.ToUInt32(CUInt(uVal0) * 65536 + data.AIO(iSlot * 8))
        uVal1 = data.AIO(iSlot * 8 + 3)
        uVal1 = Convert.ToUInt32(CUInt(uVal1) * 65536 + data.AIO(iSlot * 8 + 2))
        uVal2 = data.AIO(iSlot * 8 + 5)
        uVal2 = Convert.ToUInt32(CUInt(uVal2) * 65536 + data.AIO(iSlot * 8 + 4))
        uVal3 = data.AIO(iSlot * 8 + 7)
        uVal3 = Convert.ToUInt32(CUInt(uVal3) * 65536 + data.AIO(iSlot * 8 + 6))

        szMsg = String.Format("Slot[{0}]", iSlot)
        AddListBoxItem(szMsg)
        szMsg = String.Format("    Ch[0]={0}, Ch[1]={1}, Ch[2]={2}, Ch[3]={3}", uVal0, uVal1, uVal2, uVal3)
        AddListBoxItem(szMsg)
    End Sub

End Class
