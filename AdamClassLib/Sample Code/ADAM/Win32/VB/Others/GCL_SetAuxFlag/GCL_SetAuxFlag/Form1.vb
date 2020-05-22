Imports Advantech.Adam
Imports System.Net.Sockets

Public Class Form1
    Private adamUDP As Advantech.Adam.AdamSocket
    Private m_szIP As String
    Private m_iPort As Integer
    Private m_iCount As Integer

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        'Those modules support Set/Get AuxFlagStatus
        'Adam6000Type.Adam6050;
        'Adam6000Type.Adam6051;
        'Adam6000Type.Adam6052;
        'Adam6000Type.Adam6055;
        'Adam6000Type.Adam6060;
        'Adam6000Type.Adam6066;
        'Adam6000Type.Adam6217;
        'Adam6000Type.Adam6224;
        'Adam6000Type.Adam6250;
        'Adam6000Type.Adam6251;
        'Adam6000Type.Adam6256;
        'Adam6000Type.Adam6260;
        'Adam6000Type.Adam6266;

        m_szIP = "10.0.0.1"                                  ' modbus slave IP address
        m_iPort = 1025                                         ' modbus UDP port is 1025
        adamUDP = New AdamSocket()
        adamUDP.SetTimeout(1000, 1000, 1000)   ' set timeout for UDP

        Dim i As Integer

        For i = 0 To 15
            listView1.Items.Add(i.ToString())
            listView1.Items(i).SubItems.Add("*****")
        Next

    End Sub

    Private Sub timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timer1.Tick
        timer1.Enabled = False

        m_iCount = m_iCount + 1 ' increment the reading counter
        txtReadCount.Text = "Read status " + m_iCount.ToString() + " times..."

        RefreshAuxFlagStatus()

        timer1.Enabled = True
    End Sub

    Private Sub RefreshAuxFlagStatus()
        Dim bStatus() As Boolean
        Dim i As Integer

        If (adamUDP.Configuration().GetGCL_AuxFlagStatus(bStatus)) Then

            For i = 0 To (listView1.Items.Count - 1)

                If (i < bStatus.Length) Then
                    Me.listView1.Items(i).SubItems(1).Text = bStatus(i).ToString()
                Else
                    Me.listView1.Items(i).SubItems(1).Text = "*****"
                End If

            Next

        Else

            For i = 0 To (listView1.Items.Count - 1)
                Me.listView1.Items(i).SubItems(1).Text = "*****"
            Next

        End If
    End Sub

    Private Sub Form1_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Me.timer1.Stop()
        adamUDP.Disconnect()
    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click

        If (Me.btnStart.Text = "Start") Then

            If (adamUDP.Connect(m_szIP, ProtocolType.Udp, m_iPort)) Then

                Me.btnStart.Text = "Stop"
                btnSetAllTrue.Enabled = True
                btnSetAllFalse.Enabled = True
                Me.timer1.Start()

            Else
                MessageBox.Show("Connect to " + m_szIP + " failed", "Error")
            End If

        Else

            Me.timer1.Stop()
            btnSetAllTrue.Enabled = False
            btnSetAllFalse.Enabled = False
            Me.btnStart.Text = "Start"
            adamUDP.Disconnect() 'disconnect slave

        End If

    End Sub

    Private Sub listView1_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles listView1.DoubleClick

        If ((listView1.SelectedItems.Count > 0) AndAlso (Me.btnStart.Text = "Stop")) Then
            Me.timer1.Stop()
            Dim iIdx As Integer = listView1.SelectedItems(0).Index
            Dim bStatus As Boolean = False

            If (listView1.SelectedItems(0).SubItems(1).Text = "True") Then
                bStatus = False
            Else
                bStatus = True
            End If

            If (Not Me.adamUDP.Configuration().SetGCL_AuxFlagStatus(iIdx, bStatus)) Then
                MessageBox.Show("Failed to Set GCL AuxFlagStatus")
            End If

            Me.timer1.Start()

        End If

    End Sub

    Private Sub btnSetAllTrue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetAllTrue.Click
        Dim bStatus(Me.listView1.Items.Count) As Boolean
        Dim i As Integer

        For i = 0 To (bStatus.Length - 1)
            bStatus(i) = True
        Next

        SetAllAuxFlag(bStatus)
    End Sub

    Private Sub btnSetAllFalse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetAllFalse.Click
        Dim bStatus(Me.listView1.Items.Count) As Boolean
        Dim i As Integer

        For i = 0 To (bStatus.Length - 1)
            bStatus(i) = False
        Next

        SetAllAuxFlag(bStatus)
    End Sub

    Private Sub SetAllAuxFlag(ByVal bStatus() As Boolean)
        timer1.Stop()

        If (Not Me.adamUDP.Configuration().SetGCL_AuxFlagStatus(bStatus)) Then
            MessageBox.Show("Failed to Set GCL AuxFlagStatus")
        End If

        timer1.Start()
    End Sub
End Class
