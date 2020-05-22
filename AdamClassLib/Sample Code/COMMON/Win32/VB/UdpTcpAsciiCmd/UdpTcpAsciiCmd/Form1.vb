Imports System.Text
Imports System.Net.Sockets
Imports Advantech.Adam
Imports Advantech.Common

Public Class Form1
    Const ADAM5KUDP_PORT As Integer = 6168
    Const ADAM6KUDP_PORT As Integer = 1025
    Const ADAMTCP_PORT As Integer = 502

    Private adamSk As AdamSocket
    Private m_iPort As Integer
    Private m_protocol As ProtocolType

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        adamSk = New AdamSocket()

        'Adam-6000 UDP
        m_iPort = ADAM6KUDP_PORT
        m_protocol = ProtocolType.Udp

        'Adam-5000 UDP
        'm_iPort = ADAM5KUDP_PORT
        'm_protocol = ProtocolType.Udp

        'Adam-5000/6000 TCP
        'm_iPort = ADAMTCP_PORT
        'm_protocol = ProtocolType.Tcp

        Me.groupBox1.Enabled = False

    End Sub

    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click

        If (btnConnect.Text = "Connect") Then

            If (adamSk.Connect(txtIP.Text, m_protocol, m_iPort)) Then
                adamSk.SetTimeout(2000, 2000, 2000)
                Me.groupBox1.Enabled = True
                txtIP.Enabled = False
                btnConnect.Text = "Disconnect"
            Else
                MessageBox.Show("Failed to connect module!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
            End If

        Else
            adamSk.Disconnect()
            Me.groupBox1.Enabled = False
            txtIP.Enabled = True
            btnConnect.Text = "Connect"
        End If

    End Sub

    Private Sub Form1_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed

        If (Not adamSk Is Nothing) Then
            adamSk.Disconnect()
            adamSk = Nothing
        End If

    End Sub

    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        Dim tTime As DateTime
        Dim szCommand, szRecv As String
        szCommand = txtSend.Text + vbCrLf

        If (adamSk.AdamTransaction(szCommand, szRecv)) Then
            txtRespond.Text = szRecv
        Else
            txtRespond.Text = adamSk.LastError.ToString()
        End If

        tTime = DateTime.Now
        txtTime.Text = tTime.ToString("hh:mm:ss")

    End Sub
End Class
