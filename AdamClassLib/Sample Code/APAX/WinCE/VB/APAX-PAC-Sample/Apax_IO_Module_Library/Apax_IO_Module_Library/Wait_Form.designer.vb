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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Wait_Form))
        Me.lbl_Wait = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer
        Me.progressBar1 = New System.Windows.Forms.ProgressBar
        Me.SuspendLayout()
        '
        'lbl_Wait
        '
        resources.ApplyResources(Me.lbl_Wait, "lbl_Wait")
        Me.lbl_Wait.Name = "lbl_Wait"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'progressBar1
        '
        resources.ApplyResources(Me.progressBar1, "progressBar1")
        Me.progressBar1.Name = "progressBar1"
        '
        'Wait_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.progressBar1)
        Me.Controls.Add(Me.lbl_Wait)
        Me.Name = "Wait_Form"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbl_Wait As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Private WithEvents progressBar1 As System.Windows.Forms.ProgressBar
End Class
