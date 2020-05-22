Public Class Wait_Form
    Dim iCount As Integer = 1
    Dim iRunTime As Integer = 0
    Dim iMilliSec As Integer = 0
    Public Sub Start_Wait()

        Me.iMilliSec = 4500
        Me.Timer1.Enabled = True

    End Sub
    Public Sub Start_Wait(ByVal iWait As Integer)

        Me.iMilliSec = iWait
        Me.Timer1.Enabled = True

    End Sub
    Public Sub End_Wait()

        Me.Timer1.Enabled = False
        Me.Close()


    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim iLabelStatus As Integer

        iLabelStatus = (iCount Mod 4)
        iRunTime = iRunTime + Timer1.Interval

        Select Case (iLabelStatus)
            Case 0
                Me.lbl_Wait.Text = "Please waiting."
                iCount = 0
            Case 1
                Me.lbl_Wait.Text = "Please waiting.."
            Case 2
                Me.lbl_Wait.Text = "Please waiting..."
            Case 3
                Me.lbl_Wait.Text = "Please waiting...."
        End Select

        If (iRunTime >= iMilliSec) Then

            progressBar1.Value = 100
            End_Wait()

        Else

            progressBar1.Value = iRunTime * 100 / iMilliSec

        End If
        iCount = iCount + 1
    End Sub

End Class