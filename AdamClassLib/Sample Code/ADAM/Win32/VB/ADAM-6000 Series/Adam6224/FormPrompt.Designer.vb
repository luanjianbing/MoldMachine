<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPrompt
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
        Me.label1 = New System.Windows.Forms.Label
        Me.progressBar1 = New System.Windows.Forms.ProgressBar
        Me.SuspendLayout()
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(11, 11)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(312, 24)
        Me.label1.TabIndex = 4
        Me.label1.Text = "Form loading..."
        '
        'progressBar1
        '
        Me.progressBar1.Location = New System.Drawing.Point(11, 43)
        Me.progressBar1.Name = "progressBar1"
        Me.progressBar1.Size = New System.Drawing.Size(312, 24)
        Me.progressBar1.TabIndex = 5
        '
        'FormPrompt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(334, 78)
        Me.ControlBox = False
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.progressBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPrompt"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Please wait..."
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents label1 As System.Windows.Forms.Label
    Public WithEvents progressBar1 As System.Windows.Forms.ProgressBar
End Class
