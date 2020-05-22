<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class FormWait
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
        Me.labDescription = New System.Windows.Forms.Label
        Me.timer1 = New System.Windows.Forms.Timer
        Me.SuspendLayout()
        '
        'progressBar1
        '
        Me.progressBar1.Location = New System.Drawing.Point(6, 25)
        Me.progressBar1.Name = "progressBar1"
        Me.progressBar1.Size = New System.Drawing.Size(320, 23)
        '
        'labDescription
        '
        Me.labDescription.Location = New System.Drawing.Point(8, 7)
        Me.labDescription.Name = "labDescription"
        Me.labDescription.Size = New System.Drawing.Size(304, 14)
        Me.labDescription.Text = "Please wait..."
        '
        'timer1
        '
        '
        'FormWait
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(332, 76)
        Me.ControlBox = False
        Me.Controls.Add(Me.progressBar1)
        Me.Controls.Add(Me.labDescription)
        Me.Name = "FormWait"
        Me.Text = "Configuration"
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents progressBar1 As System.Windows.Forms.ProgressBar
    Private WithEvents labDescription As System.Windows.Forms.Label
    Private WithEvents timer1 As System.Windows.Forms.Timer
End Class
