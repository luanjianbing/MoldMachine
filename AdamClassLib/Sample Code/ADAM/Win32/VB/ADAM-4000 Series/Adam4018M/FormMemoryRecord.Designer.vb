<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMemoryRecord
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
        Me.btnGetRecord = New System.Windows.Forms.Button
        Me.progressBar1 = New System.Windows.Forms.ProgressBar
        Me.numericUpDown2 = New System.Windows.Forms.NumericUpDown
        Me.numericUpDown1 = New System.Windows.Forms.NumericUpDown
        Me.label2 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.numericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnGetRecord
        '
        Me.btnGetRecord.Location = New System.Drawing.Point(264, 6)
        Me.btnGetRecord.Name = "btnGetRecord"
        Me.btnGetRecord.Size = New System.Drawing.Size(75, 23)
        Me.btnGetRecord.TabIndex = 11
        Me.btnGetRecord.Text = "Get record"
        Me.btnGetRecord.UseVisualStyleBackColor = True
        '
        'progressBar1
        '
        Me.progressBar1.Location = New System.Drawing.Point(12, 83)
        Me.progressBar1.Name = "progressBar1"
        Me.progressBar1.Size = New System.Drawing.Size(327, 22)
        Me.progressBar1.TabIndex = 10
        '
        'numericUpDown2
        '
        Me.numericUpDown2.Location = New System.Drawing.Point(111, 41)
        Me.numericUpDown2.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numericUpDown2.Name = "numericUpDown2"
        Me.numericUpDown2.Size = New System.Drawing.Size(98, 22)
        Me.numericUpDown2.TabIndex = 9
        Me.numericUpDown2.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'numericUpDown1
        '
        Me.numericUpDown1.Location = New System.Drawing.Point(111, 7)
        Me.numericUpDown1.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numericUpDown1.Name = "numericUpDown1"
        Me.numericUpDown1.Size = New System.Drawing.Size(98, 22)
        Me.numericUpDown1.TabIndex = 8
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(12, 43)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(65, 12)
        Me.label2.TabIndex = 7
        Me.label2.Text = "Record total:"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(12, 9)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(58, 12)
        Me.label1.TabIndex = 6
        Me.label1.Text = "Start index:"
        '
        'Timer1
        '
        '
        'FormMemoryRecord
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(354, 114)
        Me.Controls.Add(Me.btnGetRecord)
        Me.Controls.Add(Me.progressBar1)
        Me.Controls.Add(Me.numericUpDown2)
        Me.Controls.Add(Me.numericUpDown1)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "FormMemoryRecord"
        Me.Text = "FormMemoryRecord"
        CType(Me.numericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents btnGetRecord As System.Windows.Forms.Button
    Private WithEvents progressBar1 As System.Windows.Forms.ProgressBar
    Private WithEvents numericUpDown2 As System.Windows.Forms.NumericUpDown
    Private WithEvents numericUpDown1 As System.Windows.Forms.NumericUpDown
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
