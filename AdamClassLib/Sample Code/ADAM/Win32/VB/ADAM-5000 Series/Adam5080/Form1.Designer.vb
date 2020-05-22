<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.panelCount = New System.Windows.Forms.Panel
        Me.btnClearCounter = New System.Windows.Forms.Button
        Me.btnStop = New System.Windows.Forms.Button
        Me.txtOverflow = New System.Windows.Forms.TextBox
        Me.label5 = New System.Windows.Forms.Label
        Me.txtCounting = New System.Windows.Forms.TextBox
        Me.label6 = New System.Windows.Forms.Label
        Me.cbxChannel = New System.Windows.Forms.ComboBox
        Me.label7 = New System.Windows.Forms.Label
        Me.btnStart = New System.Windows.Forms.Button
        Me.label9 = New System.Windows.Forms.Label
        Me.label8 = New System.Windows.Forms.Label
        Me.label4 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.txtCounter3 = New System.Windows.Forms.TextBox
        Me.buttonStart = New System.Windows.Forms.Button
        Me.txtCounter2 = New System.Windows.Forms.TextBox
        Me.txtCounter1 = New System.Windows.Forms.TextBox
        Me.txtCounter0 = New System.Windows.Forms.TextBox
        Me.txtReadCount = New System.Windows.Forms.TextBox
        Me.txtModule = New System.Windows.Forms.TextBox
        Me.label2 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.panelCount.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelCount
        '
        Me.panelCount.BackColor = System.Drawing.Color.SkyBlue
        Me.panelCount.Controls.Add(Me.btnClearCounter)
        Me.panelCount.Controls.Add(Me.btnStop)
        Me.panelCount.Controls.Add(Me.txtOverflow)
        Me.panelCount.Controls.Add(Me.label5)
        Me.panelCount.Controls.Add(Me.txtCounting)
        Me.panelCount.Controls.Add(Me.label6)
        Me.panelCount.Controls.Add(Me.cbxChannel)
        Me.panelCount.Controls.Add(Me.label7)
        Me.panelCount.Controls.Add(Me.btnStart)
        Me.panelCount.Location = New System.Drawing.Point(14, 223)
        Me.panelCount.Name = "panelCount"
        Me.panelCount.Size = New System.Drawing.Size(361, 128)
        Me.panelCount.TabIndex = 79
        '
        'btnClearCounter
        '
        Me.btnClearCounter.Location = New System.Drawing.Point(257, 88)
        Me.btnClearCounter.Name = "btnClearCounter"
        Me.btnClearCounter.Size = New System.Drawing.Size(93, 34)
        Me.btnClearCounter.TabIndex = 15
        Me.btnClearCounter.Text = "Clear to startup"
        Me.btnClearCounter.UseVisualStyleBackColor = True
        '
        'btnStop
        '
        Me.btnStop.Location = New System.Drawing.Point(257, 46)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(93, 36)
        Me.btnStop.TabIndex = 14
        Me.btnStop.Text = "Stop counting"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'txtOverflow
        '
        Me.txtOverflow.Location = New System.Drawing.Point(85, 75)
        Me.txtOverflow.Name = "txtOverflow"
        Me.txtOverflow.ReadOnly = True
        Me.txtOverflow.Size = New System.Drawing.Size(121, 22)
        Me.txtOverflow.TabIndex = 11
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(3, 78)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(52, 12)
        Me.label5.TabIndex = 10
        Me.label5.Text = "Overflow:"
        '
        'txtCounting
        '
        Me.txtCounting.Location = New System.Drawing.Point(85, 43)
        Me.txtCounting.Name = "txtCounting"
        Me.txtCounting.ReadOnly = True
        Me.txtCounting.Size = New System.Drawing.Size(121, 22)
        Me.txtCounting.TabIndex = 9
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(3, 46)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(52, 12)
        Me.label6.TabIndex = 8
        Me.label6.Text = "Counting:"
        '
        'cbxChannel
        '
        Me.cbxChannel.FormattingEnabled = True
        Me.cbxChannel.Location = New System.Drawing.Point(85, 13)
        Me.cbxChannel.Name = "cbxChannel"
        Me.cbxChannel.Size = New System.Drawing.Size(121, 20)
        Me.cbxChannel.TabIndex = 7
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(3, 16)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(76, 12)
        Me.label7.TabIndex = 6
        Me.label7.Text = "Channel index:"
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(257, 4)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(93, 36)
        Me.btnStart.TabIndex = 5
        Me.btnStart.Text = "Start counting"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'label9
        '
        Me.label9.AutoSize = True
        Me.label9.Location = New System.Drawing.Point(12, 193)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(60, 12)
        Me.label9.TabIndex = 78
        Me.label9.Text = "Ch-3 value:"
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Location = New System.Drawing.Point(12, 157)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(60, 12)
        Me.label8.TabIndex = 77
        Me.label8.Text = "Ch-2 value:"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(12, 121)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(60, 12)
        Me.label4.TabIndex = 76
        Me.label4.Text = "Ch-1 value:"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(12, 85)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(60, 12)
        Me.label3.TabIndex = 75
        Me.label3.Text = "Ch-0 value:"
        '
        'txtCounter3
        '
        Me.txtCounter3.Location = New System.Drawing.Point(90, 190)
        Me.txtCounter3.Name = "txtCounter3"
        Me.txtCounter3.Size = New System.Drawing.Size(119, 22)
        Me.txtCounter3.TabIndex = 74
        '
        'buttonStart
        '
        Me.buttonStart.Location = New System.Drawing.Point(289, 6)
        Me.buttonStart.Name = "buttonStart"
        Me.buttonStart.Size = New System.Drawing.Size(75, 23)
        Me.buttonStart.TabIndex = 73
        Me.buttonStart.Text = "Start"
        Me.buttonStart.UseVisualStyleBackColor = True
        '
        'txtCounter2
        '
        Me.txtCounter2.Location = New System.Drawing.Point(90, 154)
        Me.txtCounter2.Name = "txtCounter2"
        Me.txtCounter2.Size = New System.Drawing.Size(119, 22)
        Me.txtCounter2.TabIndex = 72
        '
        'txtCounter1
        '
        Me.txtCounter1.Location = New System.Drawing.Point(90, 118)
        Me.txtCounter1.Name = "txtCounter1"
        Me.txtCounter1.Size = New System.Drawing.Size(119, 22)
        Me.txtCounter1.TabIndex = 71
        '
        'txtCounter0
        '
        Me.txtCounter0.Location = New System.Drawing.Point(90, 82)
        Me.txtCounter0.Name = "txtCounter0"
        Me.txtCounter0.Size = New System.Drawing.Size(119, 22)
        Me.txtCounter0.TabIndex = 70
        '
        'txtReadCount
        '
        Me.txtReadCount.Location = New System.Drawing.Point(90, 39)
        Me.txtReadCount.Name = "txtReadCount"
        Me.txtReadCount.ReadOnly = True
        Me.txtReadCount.Size = New System.Drawing.Size(119, 22)
        Me.txtReadCount.TabIndex = 69
        Me.txtReadCount.Text = "0"
        '
        'txtModule
        '
        Me.txtModule.Location = New System.Drawing.Point(90, 6)
        Me.txtModule.Name = "txtModule"
        Me.txtModule.Size = New System.Drawing.Size(119, 22)
        Me.txtModule.TabIndex = 68
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(12, 42)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(61, 12)
        Me.label2.TabIndex = 67
        Me.label2.Text = "Read count:"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(12, 9)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(72, 12)
        Me.label1.TabIndex = 66
        Me.label1.Text = "Module name:"
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(390, 361)
        Me.Controls.Add(Me.panelCount)
        Me.Controls.Add(Me.label9)
        Me.Controls.Add(Me.label8)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.txtCounter3)
        Me.Controls.Add(Me.buttonStart)
        Me.Controls.Add(Me.txtCounter2)
        Me.Controls.Add(Me.txtCounter1)
        Me.Controls.Add(Me.txtCounter0)
        Me.Controls.Add(Me.txtReadCount)
        Me.Controls.Add(Me.txtModule)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Form1"
        Me.Text = "Adam5080 sample program (VB)"
        Me.panelCount.ResumeLayout(False)
        Me.panelCount.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents panelCount As System.Windows.Forms.Panel
    Private WithEvents btnClearCounter As System.Windows.Forms.Button
    Private WithEvents btnStop As System.Windows.Forms.Button
    Private WithEvents txtOverflow As System.Windows.Forms.TextBox
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents txtCounting As System.Windows.Forms.TextBox
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents cbxChannel As System.Windows.Forms.ComboBox
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents btnStart As System.Windows.Forms.Button
    Private WithEvents label9 As System.Windows.Forms.Label
    Private WithEvents label8 As System.Windows.Forms.Label
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents txtCounter3 As System.Windows.Forms.TextBox
    Private WithEvents buttonStart As System.Windows.Forms.Button
    Private WithEvents txtCounter2 As System.Windows.Forms.TextBox
    Private WithEvents txtCounter1 As System.Windows.Forms.TextBox
    Private WithEvents txtCounter0 As System.Windows.Forms.TextBox
    Private WithEvents txtReadCount As System.Windows.Forms.TextBox
    Private WithEvents txtModule As System.Windows.Forms.TextBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
