<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IPForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.button1 = New System.Windows.Forms.Button
        Me.IPAddressText = New System.Windows.Forms.TextBox
        Me.label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'button1
        '
        Me.button1.Location = New System.Drawing.Point(94, 86)
        Me.button1.Name = "button1"
        Me.button1.Size = New System.Drawing.Size(72, 20)
        Me.button1.TabIndex = 5
        Me.button1.Text = "OK"
        '
        'IPAddressText
        '
        Me.IPAddressText.Location = New System.Drawing.Point(12, 41)
        Me.IPAddressText.Name = "IPAddressText"
        Me.IPAddressText.Size = New System.Drawing.Size(241, 22)
        Me.IPAddressText.TabIndex = 4
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(12, 17)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(189, 20)
        Me.label1.TabIndex = 6
        Me.label1.Text = "Please enter IP address:"
        '
        'IPForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(269, 119)
        Me.Controls.Add(Me.button1)
        Me.Controls.Add(Me.IPAddressText)
        Me.Controls.Add(Me.label1)
        Me.Name = "IPForm"
        Me.Text = "IPForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents button1 As System.Windows.Forms.Button
    Private WithEvents IPAddressText As System.Windows.Forms.TextBox
    Private WithEvents label1 As System.Windows.Forms.Label
End Class
