<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Wait_Form
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.progressBar1 = New System.Windows.Forms.ProgressBar
        Me.lbl_Wait = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer
        Me.SuspendLayout()
        '
        'progressBar1
        '
        Me.progressBar1.Location = New System.Drawing.Point(15, 48)
        Me.progressBar1.Name = "progressBar1"
        Me.progressBar1.Size = New System.Drawing.Size(360, 23)
        '
        'lbl_Wait
        '
        Me.lbl_Wait.Location = New System.Drawing.Point(15, 25)
        Me.lbl_Wait.Name = "lbl_Wait"
        Me.lbl_Wait.Size = New System.Drawing.Size(152, 20)
        Me.lbl_Wait.Text = "Please waiting"
        '
        'Wait_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(390, 107)
        Me.Controls.Add(Me.progressBar1)
        Me.Controls.Add(Me.lbl_Wait)
        Me.Name = "Wait_Form"
        Me.Text = "Wait_Form"
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents progressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents lbl_Wait As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
