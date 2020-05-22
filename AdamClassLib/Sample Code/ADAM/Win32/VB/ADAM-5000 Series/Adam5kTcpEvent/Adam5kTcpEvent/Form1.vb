Imports Advantech.Adam
Imports Advantech.Common
Imports System.Threading
Public Class Form1
    Inherits System.Windows.Forms.Form



#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents txtPort As System.Windows.Forms.TextBox
    Friend WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents treeViewDS As System.Windows.Forms.TreeView
    Friend WithEvents listBoxMsg As System.Windows.Forms.ListBox
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtPort = New System.Windows.Forms.TextBox
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.treeViewDS = New System.Windows.Forms.TreeView
        Me.listBoxMsg = New System.Windows.Forms.ListBox
        Me.label2 = New System.Windows.Forms.Label
        Me.btnStart = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.groupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtPort
        '
        Me.txtPort.Enabled = False
        Me.txtPort.Location = New System.Drawing.Point(64, 16)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(88, 22)
        Me.txtPort.TabIndex = 14
        Me.txtPort.Text = "9168"
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.treeViewDS)
        Me.groupBox1.Controls.Add(Me.listBoxMsg)
        Me.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.groupBox1.Location = New System.Drawing.Point(0, 48)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.groupBox1.Size = New System.Drawing.Size(576, 350)
        Me.groupBox1.TabIndex = 16
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Receiving Data"
        '
        'treeViewDS
        '
        Me.treeViewDS.Dock = System.Windows.Forms.DockStyle.Fill
        Me.treeViewDS.ImageIndex = -1
        Me.treeViewDS.Location = New System.Drawing.Point(200, 18)
        Me.treeViewDS.Name = "treeViewDS"
        Me.treeViewDS.SelectedImageIndex = -1
        Me.treeViewDS.Size = New System.Drawing.Size(373, 329)
        Me.treeViewDS.TabIndex = 1
        '
        'listBoxMsg
        '
        Me.listBoxMsg.Dock = System.Windows.Forms.DockStyle.Left
        Me.listBoxMsg.HorizontalScrollbar = True
        Me.listBoxMsg.ItemHeight = 12
        Me.listBoxMsg.Location = New System.Drawing.Point(3, 18)
        Me.listBoxMsg.Name = "listBoxMsg"
        Me.listBoxMsg.Size = New System.Drawing.Size(197, 328)
        Me.listBoxMsg.TabIndex = 0
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(16, 16)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(48, 20)
        Me.label2.TabIndex = 13
        Me.label2.Text = "Port:"
        Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnStart
        '
        Me.btnStart.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStart.Location = New System.Drawing.Point(472, 16)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(88, 24)
        Me.btnStart.TabIndex = 15
        Me.btnStart.Text = "Start"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtPort)
        Me.Panel1.Controls.Add(Me.label2)
        Me.Panel1.Controls.Add(Me.btnStart)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(576, 48)
        Me.Panel1.TabIndex = 17
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 15)
        Me.ClientSize = New System.Drawing.Size(576, 398)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Form1"
        Me.Text = "Adam-5000/TCP Event Sample (VB)"
        Me.groupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private m_Adam5000Type() As Advantech.Adam.Adam5000Type
    Private m_strHostIP() As String
    Private m_szMsg As String
    Private m_szMsgData As String
    Private m_iSlot As Integer

    'Event Trigger 5000TCP
    Private StreamRecList As AdamStreamRecList
    Private udpServerThread As AdamEventServerThread
    Private m_iCount As Integer
    Private m_bStopUI As Boolean
    Private m_bTerminateUI As Boolean
    Private m_uiThread As Thread

    Private m_MonitorDataStreamIP As String

    Private Delegate Sub UpdateListBoxCallback(ByVal strMsg As String)
    Private Delegate Sub UpdateTreeViewCallback(ByVal strMsg As String, ByVal slot as Integer)


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        StreamRecList = New AdamStreamRecList

        m_Adam5000Type = New Adam5000Type(8 - 1) {}

        m_strHostIP = New String(3 - 1) {}
        m_strHostIP(0) = "10.0.0.11"                        'Adam5000/TCP IP
        m_strHostIP(1) = "10.0.0.21"                        'Adam5000/TCP IP
        m_strHostIP(2) = "10.0.0.31"                        'Adam5000/TCP IP

        ' for those who wants to listen the data streaming from ADAM-6000
        ' you have to make sure the module type you are listening to.
        'm_MonitorDataStreamIP = m_strHostIP(0);

        'm_Adam5000Type(0) = Adam5000Type.Adam5051
        'm_Adam5000Type(1) = Adam5000Type.Non
        'm_Adam5000Type(2) = Adam5000Type.Non
        'm_Adam5000Type(3) = Adam5000Type.Non
        'm_Adam5000Type(4) = Adam5000Type.Non
        'm_Adam5000Type(5) = Adam5000Type.Non
        'm_Adam5000Type(6) = Adam5000Type.Non
        'm_Adam5000Type(7) = Adam5000Type.Non


        'm_MonitorDataStreamIP = m_strHostIP(1)

        'm_Adam5000Type(0) = Adam5000Type.Non
        'm_Adam5000Type(1) = Adam5000Type.Non
        'm_Adam5000Type(2) = Adam5000Type.Adam5051
        'm_Adam5000Type(3) = Adam5000Type.Non
        'm_Adam5000Type(4) = Adam5000Type.Non
        'm_Adam5000Type(5) = Adam5000Type.Non
        'm_Adam5000Type(6) = Adam5000Type.Non
        'm_Adam5000Type(7) = Adam5000Type.Non

        m_MonitorDataStreamIP = m_strHostIP(2)

        m_Adam5000Type(0) = Adam5000Type.Non
        m_Adam5000Type(1) = Adam5000Type.Non
        m_Adam5000Type(2) = Adam5000Type.Non
        m_Adam5000Type(3) = Adam5000Type.Adam5056
        m_Adam5000Type(4) = Adam5000Type.Adam5051
        m_Adam5000Type(5) = Adam5000Type.Non
        m_Adam5000Type(6) = Adam5000Type.Non
        m_Adam5000Type(7) = Adam5000Type.Non

        InitialTreeNode()

        m_bTerminateUI = True

    End Sub

    Private Sub Form1_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed

        Dim iCnt As Integer = 0

        StopEventRoutineThread()

        Try
            udpServerThread.StopThread()
        Catch ex As System.NullReferenceException
        End Try
    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        If (btnStart.Text = "Start") Then
            btnStart.Text = "Stop"
            udpServerThread = New AdamEventServerThread(StreamRecList, Me.m_strHostIP)
            udpServerThread.StartThread()
            StartEventRoutineThread()

        Else

            StopEventRoutineThread()

            btnStart.Text = "Start"
            udpServerThread.StopThread()
            StreamRecList.ClearStreamRec()
        End If
    End Sub

    Private Sub AddListBoxItem(ByVal szMsg As String)
        If (listBoxMsg.InvokeRequired = True) Then
            listBoxMsg.BeginInvoke(New UpdateListBoxCallback(AddressOf AddListBoxItem), New Object() {szMsg})
        Else

            Dim iLimit As Integer = 300
            listBoxMsg.BeginUpdate()
            If (listBoxMsg.Items.Count > iLimit) Then

                listBoxMsg.Items.Clear()
            End If

            listBoxMsg.Items.Add(szMsg)
            listBoxMsg.SelectedIndex = listBoxMsg.Items.Count - 1
            listBoxMsg.EndUpdate()
        End If
    End Sub

    Private Sub InitialTreeNode()

        Dim strHostIP As String = m_MonitorDataStreamIP
        Dim i As Integer
        Dim strTemp As String = ""

        strTemp = "HOST " + "[" + strHostIP + "]"
        treeViewDS.Nodes.Add(strTemp)

        For i = 0 To m_Adam5000Type.Length - 1
            treeViewDS.Nodes(0).Nodes.Add(m_Adam5000Type(i).ToString())
        Next i

        For i = 0 To m_Adam5000Type.Length - 1
            treeViewDS.Nodes(0).Nodes(i).Nodes.Add("Data:")
        Next i

        treeViewDS.ExpandAll()
    End Sub

    Private Sub StartEventRoutineThread()
        m_bStopUI = False
        m_uiThread = New System.Threading.Thread(New ThreadStart(AddressOf EventRoutine))
        m_uiThread.Start()
    End Sub
    Private Sub StopEventRoutineThread()
        m_bStopUI = True
        Do While m_bTerminateUI = False
            Thread.Sleep(10)
        Loop
    End Sub
    Private Sub EventRoutine()

        Dim byData() As Byte
        Dim Data As DataStructure

        m_bTerminateUI = False

        Do While (m_bStopUI = False)

            Thread.Sleep(5)
            If UpdateEvent() = True Then
                m_iCount = m_iCount + 1

                'Show Data streaming
                If (StreamRecList.GetLastStreamRec(m_MonitorDataStreamIP, byData)) Then
                    Data = New DataStructure
                    Data.SetData(byData, byData.Length)
                    DisplayInform(Data)
                End If

            End If
        Loop
        m_bTerminateUI = True
    End Sub

    Private Function UpdateEvent() As Boolean

        Dim byIP() As Byte
        Dim iSlot As Integer, iChannel As Integer, iType As Integer, iStatus As Integer
        Dim strTime As String
        Dim lVal As Long
        Dim s0 As String, s1 As String, s2 As String, s3 As String, s4 As String, s5 As String, s6 As String

        If StreamRecList.PopEventRec(byIP, iSlot, iChannel, iType, iStatus, strTime, lVal) = True Then

            s0 = byIP(0).ToString() + "." + byIP(1).ToString() + "." + byIP(2).ToString() + "." + byIP(3).ToString()
            s1 = strTime
            s2 = iSlot.ToString()
            s3 = iChannel.ToString()
            s6 = lVal.ToString()

            If iType = EVENT_TYPE.DIO Then
                s4 = "DIO event"
            ElseIf iType = EVENT_TYPE.HIALARM Then
                s4 = "High Alarm event"
            ElseIf iType = EVENT_TYPE.LOALARM Then
                s4 = "Low Alarm event"
            ElseIf iType = EVENT_TYPE.CONNECT Then
                s4 = "Connection"
            Else
                s4 = "unknown event type"
            End If


            If iStatus = EVENT_STATUS.ON_TO_OFF Then
                s5 = "'ON' to 'OFF'"
            ElseIf iStatus = EVENT_STATUS.OFF_TO_ON Then
                s5 = "'OFF' to 'ON'"
            ElseIf iStatus = EVENT_STATUS.NO_CHANGE Then
                s5 = "No change"
            ElseIf iStatus = EVENT_STATUS.LOST Then
                s5 = "Lost"
            Else
                s5 = "unknown status"
            End If

            AddListBoxItem("Count=" + m_iCount.ToString())
            AddListBoxItem("IP: " + s0)
            AddListBoxItem("(" + s1 + ")")
            AddListBoxItem("--Slot(" + s2 + "), Ch(" + s3 + ")")
            AddListBoxItem("--Val(" + s6 + ")")
            AddListBoxItem("--Type(" + s4 + ")")
            AddListBoxItem("--Event(" + s5 + ")")
            AddListBoxItem("")
            Return True
        End If
        Return False

    End Function


    Private Sub DisplayInform(ByVal data As DataStructure)

        ' for those who wants to listen the data streaming from ADAM-6000
        ' you have to make sure the module type you are listening to.

        Dim strMsg As String = "Data:"
        Dim iSlotIndex As Integer = 0

        For iSlotIndex = 0 To Me.m_Adam5000Type.Length - 1
            If m_Adam5000Type(iSlotIndex) = Adam5000Type.Adam5013 Then
                strMsg = DisplayAdam5013(data, iSlotIndex)
            ElseIf m_Adam5000Type(iSlotIndex) = Adam5000Type.Adam5017 Then
                strMsg = DisplayAdam5017(data, iSlotIndex)
            ElseIf m_Adam5000Type(iSlotIndex) = Adam5000Type.Adam5018 Then
                strMsg = DisplayAdam5018(data, iSlotIndex)
            ElseIf m_Adam5000Type(iSlotIndex) = Adam5000Type.Adam5024 Then
                strMsg = DisplayAdam5024(data, iSlotIndex)
            ElseIf m_Adam5000Type(iSlotIndex) = Adam5000Type.Adam5050 Then
                strMsg = DisplayAdam5050(data, iSlotIndex)
            ElseIf m_Adam5000Type(iSlotIndex) = Adam5000Type.Adam5051 Then
                strMsg = DisplayAdam5051(data, iSlotIndex)
            ElseIf m_Adam5000Type(iSlotIndex) = Adam5000Type.Adam5052 Then
                strMsg = DisplayAdam5052(data, iSlotIndex)
            ElseIf m_Adam5000Type(iSlotIndex) = Adam5000Type.Adam5055 Then
                strMsg = DisplayAdam5055(data, iSlotIndex)
            ElseIf m_Adam5000Type(iSlotIndex) = Adam5000Type.Adam5056 Then
                strMsg = DisplayAdam5056(data, iSlotIndex)
            ElseIf m_Adam5000Type(iSlotIndex) = Adam5000Type.Adam5060 Then
                strMsg = DisplayAdam5060(data, iSlotIndex)
            ElseIf m_Adam5000Type(iSlotIndex) = Adam5000Type.Adam5068 Then
                strMsg = DisplayAdam5068(data, iSlotIndex)
            ElseIf m_Adam5000Type(iSlotIndex) = Adam5000Type.Adam5069 Then
                strMsg = DisplayAdam5069(data, iSlotIndex)
            ElseIf m_Adam5000Type(iSlotIndex) = Adam5000Type.Adam5080 Then
                strMsg = DisplayAdam5080(data, iSlotIndex)
            ElseIf m_Adam5000Type(iSlotIndex) = Adam5000Type.Adam5081 Then
                strMsg = DisplayAdam5081(data, iSlotIndex)
            Else
                strMsg = ""
            End If

            ChangeTreeViewData(strMsg, iSlotIndex)

        Next iSlotIndex
    End Sub

    Private Sub ChangeTreeViewData(ByVal szMsg As String, ByVal iSlot As Integer)

        If treeViewDS.InvokeRequired = True Then
            treeViewDS.BeginInvoke(New UpdateTreeViewCallback(AddressOf ChangeTreeViewData), New Object() {szMsg, iSlot})
        Else
            treeViewDS.Nodes(0).Nodes(iSlot).Nodes(0).Text = szMsg
        End If
    End Sub

    Private Function DisplayAdam5050(ByVal data As DataStructure, ByVal iSlot As Integer) As String
        Dim szMsg As String
        szMsg = String.Format("    DIO=0x{0:X04}", data.DIO(iSlot))
        Return szMsg
    End Function

    Private Function DisplayAdam5051(ByVal data As DataStructure, ByVal iSlot As Integer) As String
        Dim szMsg As String = DisplayAdam5050(data, iSlot)
        Return szMsg
    End Function

    Private Function DisplayAdam5052(ByVal data As DataStructure, ByVal iSlot As Integer) As String
        Dim szMsg As String = DisplayAdam5050(data, iSlot)
        Return szMsg
    End Function

    Private Function DisplayAdam5055(ByVal data As DataStructure, ByVal iSlot As Integer) As String
        Dim szMsg As String = DisplayAdam5050(data, iSlot)
        Return szMsg
    End Function

    Private Function DisplayAdam5056(ByVal data As DataStructure, ByVal iSlot As Integer) As String
        Dim szMsg As String = DisplayAdam5050(data, iSlot)
        Return szMsg
    End Function

    Private Function DisplayAdam5060(ByVal data As DataStructure, ByVal iSlot As Integer) As String
        Dim szMsg As String = DisplayAdam5050(data, iSlot)
        Return szMsg
    End Function

    Private Function DisplayAdam5068(ByVal data As DataStructure, ByVal iSlot As Integer) As String
        Dim szMsg As String = DisplayAdam5050(data, iSlot)
        Return szMsg
    End Function

    Private Function DisplayAdam5069(ByVal data As DataStructure, ByVal iSlot As Integer) As String
        Dim szMsg As String = DisplayAdam5050(data, iSlot)
        Return szMsg
    End Function

    Private Function DisplayAdam5013(ByVal data As DataStructure, ByVal iSlot As Integer) As String
        Dim szMsg As String
        szMsg = String.Format("    Ch[0]=0x{0:X04}, Ch[1]=0x{1:X04}, Ch[2]=0x{2:X04}", data.AIO(iSlot * 8), data.AIO(iSlot * 8 + 1), data.AIO(iSlot * 8 + 2))
        Return szMsg
    End Function

    Private Function DisplayAdam5017(ByVal data As DataStructure, ByVal iSlot As Integer) As String
        Dim szMsg As String
        szMsg = String.Format("    Ch[0]=0x{0:X04}, Ch[1]=0x{1:X04}, Ch[2]=0x{2:X04}, Ch[3]=0x{3:X04}, Ch[4]=0x{4:X04}, Ch[5]=0x{5:X04}, Ch[6]=0x{6:X04}, Ch[7]=0x{7:X04}", data.AIO(iSlot * 8), data.AIO(iSlot * 8 + 1), data.AIO(iSlot * 8 + 2), data.AIO(iSlot * 8 + 3), data.AIO(iSlot * 8 + 4), data.AIO(iSlot * 8 + 5), data.AIO(iSlot * 8 + 6), data.AIO(iSlot * 8 + 7))
        Return szMsg
    End Function
    Private Function DisplayAdam5018(ByVal data As DataStructure, ByVal iSlot As Integer) As String
        Dim szMsg As String
        szMsg = String.Format("    Ch[0]=0x{0:X04}, Ch[1]=0x{1:X04}, Ch[2]=0x{2:X04}, Ch[3]=0x{3:X04}, Ch[4]=0x{4:X04}, Ch[5]=0x{5:X04}, Ch[6]=0x{6:X04}", data.AIO(iSlot * 8), data.AIO(iSlot * 8 + 1), data.AIO(iSlot * 8 + 2), data.AIO(iSlot * 8 + 3), data.AIO(iSlot * 8 + 4), data.AIO(iSlot * 8 + 5), data.AIO(iSlot * 8 + 6))
        Return szMsg
    End Function
    Private Function DisplayAdam5024(ByVal data As DataStructure, ByVal iSlot As Integer) As String
        Dim szMsg As String
        szMsg = String.Format("    Ch[0]=0x{0:X04}, Ch[1]=0x{1:X04}, Ch[2]=0x{2:X04}, Ch[3]=0x{3:X04}", data.AIO(iSlot * 8), data.AIO(iSlot * 8 + 1), data.AIO(iSlot * 8 + 2), data.AIO(iSlot * 8 + 3))
        Return szMsg
    End Function
    Private Function DisplayAdam5080(ByVal data As DataStructure, ByVal iSlot As Integer) As String
        Dim szMsg As String
        Dim uVal0 As Long, uVal1 As Long, uVal2 As Long, uVal3 As Long

        uVal0 = data.AIO(iSlot * 8 + 1)
        uVal0 = uVal0 * 65536 + data.AIO(iSlot * 8)
        uVal1 = data.AIO(iSlot * 8 + 3)
        uVal1 = uVal1 * 65536 + data.AIO(iSlot * 8 + 2)
        uVal2 = data.AIO(iSlot * 8 + 5)
        uVal2 = uVal2 * 65536 + data.AIO(iSlot * 8 + 4)
        uVal3 = data.AIO(iSlot * 8 + 7)
        uVal3 = uVal3 * 65536 + data.AIO(iSlot * 8 + 6)
        szMsg = String.Format("Slot[{0}]", iSlot)
        szMsg = String.Format("    Ch[0]={0}, Ch[1]={1}, Ch[2]={2}, Ch[3]={3}", uVal0, uVal1, uVal2, uVal3)
        Return szMsg
    End Function
    Private Function DisplayAdam5081(ByVal data As DataStructure, ByVal iSlot As Integer) As String
        Dim szMsg As String
        Dim uVal0 As Long, uVal1 As Long, uVal2 As Long, uVal3 As Long
        uVal0 = data.AIO(iSlot * 8 + 1)
        uVal0 = uVal0 * 65536 + data.AIO(iSlot * 8)
        uVal1 = data.AIO(iSlot * 8 + 3)
        uVal1 = uVal1 * 65536 + data.AIO(iSlot * 8 + 2)
        uVal2 = data.AIO(iSlot * 8 + 5)
        uVal2 = uVal2 * 65536 + data.AIO(iSlot * 8 + 4)
        uVal3 = data.AIO(iSlot * 8 + 7)
        uVal3 = uVal3 * 65536 + data.AIO(iSlot * 8 + 6)

        szMsg = String.Format("Slot[{0}]", iSlot)
        szMsg = String.Format("    Ch[0]={0}, Ch[1]={1}, Ch[2]={2}, Ch[3]={3}", uVal0, uVal1, uVal2, uVal3)
        Return szMsg
    End Function
End Class
