Imports Advantech.Common

Public Class Form1
    Dim com As Advantech.Common.ComPort

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cbxCOM.SelectedIndex = 1            ' default is COM2
        cbxBaudrate.SelectedIndex = 0       ' default baudrate 9600
        cbxDatabits.SelectedIndex = 3       ' databits 8
        cbxParity.SelectedIndex = 0         ' parity is None
        cbxStopbits.SelectedIndex = 0       ' stopbits is 1
        cbxReadTimeout.SelectedIndex = 0    ' read timeout is 100 ms
        cbxWriteTimeout.SelectedIndex = 0   ' write timeout is 100 ms
    End Sub

    Private Sub SwitchEnable(ByVal bEnable As Boolean)
        btnOpen.Enabled = bEnable
        cbxCOM.Enabled = bEnable
        cbxBaudrate.Enabled = bEnable
        cbxDatabits.Enabled = bEnable
        cbxParity.Enabled = bEnable
        cbxStopbits.Enabled = bEnable
        cbxReadTimeout.Enabled = bEnable
        cbxWriteTimeout.Enabled = bEnable
    End Sub

    Private Function SetComState() As Boolean
        Dim baudrate As Advantech.Common.Baudrate
        Dim databits As Advantech.Common.Databits
        Dim parity As Advantech.Common.Parity
        Dim stopbits As Advantech.Common.Stopbits

        Select Case cbxBaudrate.SelectedIndex
            Case 0
                baudrate = Advantech.Common.Baudrate.Baud_9600
            Case 1
                baudrate = Advantech.Common.Baudrate.Baud_19200
            Case 2
                baudrate = Advantech.Common.Baudrate.Baud_38400
            Case Else
                baudrate = Advantech.Common.Baudrate.Baud_57600
        End Select
        Select Case cbxDatabits.SelectedIndex
            Case 0
                databits = Advantech.Common.Databits.Five
            Case 1
                databits = Advantech.Common.Databits.Six
            Case 2
                databits = Advantech.Common.Databits.Seven
            Case Else
                databits = Advantech.Common.Databits.Eight
        End Select
        Select Case cbxParity.SelectedIndex
            Case 0
                parity = Advantech.Common.Parity.None
            Case 1
                parity = Advantech.Common.Parity.Odd
            Case 2
                parity = Advantech.Common.Parity.Even
            Case 3
                parity = Advantech.Common.Parity.Mark
            Case Else
                parity = Advantech.Common.Parity.Space
        End Select
        Select Case cbxStopbits.SelectedIndex
            Case 0
                stopbits = Advantech.Common.Stopbits.One
            Case 1
                stopbits = Advantech.Common.Stopbits.OneAndHalf
            Case Else
                stopbits = Advantech.Common.Stopbits.Two
        End Select
        Return com.SetComPortState(baudrate, databits, parity, stopbits)
    End Function

    Private Function SetComTimeout() As Boolean
        Dim rdTout As Integer, wrTout As Integer
        Select Case cbxReadTimeout.SelectedIndex
            Case 0
                rdTout = 100
            Case 1
                rdTout = 500
            Case 2
                rdTout = 1000
            Case Else
                rdTout = 5000
        End Select
        Select Case cbxWriteTimeout.SelectedIndex
            Case 0
                wrTout = 100
            Case 1
                wrTout = 500
            Case 2
                wrTout = 1000
            Case Else
                wrTout = 5000
        End Select
        Return com.SetComPortTimeout(rdTout, rdTout, 0, wrTout, 0)
    End Function

    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click
        Dim port As Integer

        port = cbxCOM.SelectedIndex() + 1

        com = New Advantech.Common.ComPort(port)
        If com.OpenComPort() = True Then
            ' set COM port state
            If SetComState() = False Then
                MsgBox("Set COM port state failed!", MsgBoxStyle.OkOnly, "Error")
                Return
            End If
            ' set COM port timeout
            If SetComTimeout() = False Then
                MsgBox("Set COM port timeout failed!", MsgBoxStyle.OkOnly, "Error")
                Return
            End If
            btnClose.Enabled = True
            btnSend.Enabled = True
            SwitchEnable(False)
        Else
            MsgBox("Open COM" & port & ": failed!", MsgBoxStyle.OkOnly, "Error")
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Dim port As Integer

        port = cbxCOM.SelectedIndex() + 1

        If com.CloseComPort() = True Then
            MsgBox("Close COM" & port & ": done!", MsgBoxStyle.OkOnly, "Close")
        Else
            MsgBox("Close COM" & port & ": failed!", MsgBoxStyle.OkOnly, "Error")
        End If
        btnClose.Enabled = False
        btnSend.Enabled = False
        SwitchEnable(True)
    End Sub

    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        Dim szSend As String, szRecv As String

        If txtSend.Text.Length = 0 Then
            MsgBox("Please input the command string!", MsgBoxStyle.OkOnly, "Warn")
            Exit Sub
        End If

        szSend = txtSend.Text + Chr(13) ' append carrage return for sending ADAM-ASCII command
        If com.Send(szSend) > 0 Then    ' sending command
            If com.Recv(szRecv) > 0 Then    ' receiving command
                lsbxRecv.Items.Add(szRecv)
            Else
                lsbxRecv.Items.Add("## Fail to receive! ##")
            End If
        Else
            lsbxRecv.Items.Add("## Fail to send! ##")
        End If
        lsbxRecv.SelectedIndex = lsbxRecv.Items.Count - 1
    End Sub
End Class
