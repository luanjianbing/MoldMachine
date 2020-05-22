<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class FormMemoryRecord
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
        Me.btnGetRecord = New System.Windows.Forms.Button
        Me.progressBar1 = New System.Windows.Forms.ProgressBar
        Me.numericUpDown2 = New System.Windows.Forms.NumericUpDown
        Me.numericUpDown1 = New System.Windows.Forms.NumericUpDown
        Me.label2 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer
        Me.SuspendLayout()
        '
        'btnGetRecord
        '
        Me.btnGetRecord.Location = New System.Drawing.Point(234, 11)
        Me.btnGetRecord.Name = "btnGetRecord"
        Me.btnGetRecord.Size = New System.Drawing.Size(75, 23)
        Me.btnGetRecord.TabIndex = 17
        Me.btnGetRecord.Text = "Get record"
        '
        'progressBar1
        '
        Me.progressBar1.Location = New System.Drawing.Point(5, 84)
        Me.progressBar1.Name = "progressBar1"
        Me.progressBar1.Size = New System.Drawing.Size(304, 22)
        '
        'numericUpDown2
        '
        Me.numericUpDown2.Location = New System.Drawing.Point(90, 43)
        Me.numericUpDown2.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numericUpDown2.Name = "numericUpDown2"
        Me.numericUpDown2.Size = New System.Drawing.Size(98, 24)
        Me.numericUpDown2.TabIndex = 16
        Me.numericUpDown2.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'numericUpDown1
        '
        Me.numericUpDown1.Location = New System.Drawing.Point(90, 9)
        Me.numericUpDown1.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numericUpDown1.Name = "numericUpDown1"
        Me.numericUpDown1.Size = New System.Drawing.Size(98, 24)
        Me.numericUpDown1.TabIndex = 15
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(3, 45)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(93, 22)
        Me.label2.Text = "Record total:"
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(3, 11)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(81, 20)
        Me.label1.Text = "Start index:"
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'FormMemoryRecord
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(315, 113)
        Me.Controls.Add(Me.btnGetRecord)
        Me.Controls.Add(Me.progressBar1)
        Me.Controls.Add(Me.numericUpDown2)
        Me.Controls.Add(Me.numericUpDown1)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMemoryRecord"
        Me.Text = "FormMemoryRecord"
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents btnGetRecord As System.Windows.Forms.Button
    Private WithEvents progressBar1 As System.Windows.Forms.ProgressBar
    Private WithEvents numericUpDown2 As System.Windows.Forms.NumericUpDown
    Private WithEvents numericUpDown1 As System.Windows.Forms.NumericUpDown
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
