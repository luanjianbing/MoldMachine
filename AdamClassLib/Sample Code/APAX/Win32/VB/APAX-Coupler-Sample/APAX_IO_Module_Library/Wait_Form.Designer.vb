<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Wait_Form
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
        Me.components = New System.ComponentModel.Container
        Me.lbl_Wait = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.progressBar1 = New System.Windows.Forms.ProgressBar
        Me.SuspendLayout()
        '
        'lbl_Wait
        '
        Me.lbl_Wait.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.lbl_Wait.Location = New System.Drawing.Point(12, 9)
        Me.lbl_Wait.Name = "lbl_Wait"
        Me.lbl_Wait.Size = New System.Drawing.Size(152, 20)
        Me.lbl_Wait.TabIndex = 1
        Me.lbl_Wait.Text = "Please waiting"
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'progressBar1
        '
        Me.progressBar1.Location = New System.Drawing.Point(12, 32)
        Me.progressBar1.Name = "progressBar1"
        Me.progressBar1.Size = New System.Drawing.Size(360, 23)
        Me.progressBar1.TabIndex = 2
        '
        'Wait_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(386, 80)
        Me.Controls.Add(Me.progressBar1)
        Me.Controls.Add(Me.lbl_Wait)
        Me.Name = "Wait_Form"
        Me.Text = "Wait_Form"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbl_Wait As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Private WithEvents progressBar1 As System.Windows.Forms.ProgressBar
End Class
