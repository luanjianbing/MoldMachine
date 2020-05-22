Public Class IPForm
    Public Delegate Sub EventHandler_ApplyIPAddressClick(ByVal szVal As String)


    Public Event ApplyIPAddressClick As EventHandler_ApplyIPAddressClick

    Private Sub button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button1.Click
        label1.Text = IPAddressText.Text
        RaiseEvent ApplyIPAddressClick(IPAddressText.Text)
        Me.Close()
    End Sub
End Class