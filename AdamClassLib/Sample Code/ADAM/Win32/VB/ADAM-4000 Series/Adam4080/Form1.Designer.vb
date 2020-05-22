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
        Me.txtAlarm = New System.Windows.Forms.TextBox
        Me.btnAlarm = New System.Windows.Forms.Button
        Me.txtOverflow = New System.Windows.Forms.TextBox
        Me.label8 = New System.Windows.Forms.Label
        Me.txtCounting = New System.Windows.Forms.TextBox
        Me.label6 = New System.Windows.Forms.Label
        Me.cbxChannel = New System.Windows.Forms.ComboBox
        Me.label5 = New System.Windows.Forms.Label
        Me.btnStart = New System.Windows.Forms.Button
        Me.txtCounter1 = New System.Windows.Forms.TextBox
        Me.txtCounter0 = New System.Windows.Forms.TextBox
        Me.label4 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.buttonStart = New System.Windows.Forms.Button
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
        Me.panelCount.Controls.Add(Me.txtAlarm)
        Me.panelCount.Controls.Add(Me.btnAlarm)
        Me.panelCount.Controls.Add(Me.txtOverflow)
        Me.panelCount.Controls.Add(Me.label8)
        Me.panelCount.Controls.Add(Me.txtCounting)
        Me.panelCount.Controls.Add(Me.label6)
        Me.panelCount.Controls.Add(Me.cbxChannel)
        Me.panelCount.Controls.Add(Me.label5)
        Me.panelCount.Controls.Add(Me.btnStart)
        Me.panelCount.Location = New System.Drawing.Point(9, 152)
        Me.panelCount.Name = "panelCount"
        Me.panelCount.Size = New System.Drawing.Size(361, 148)
        Me.panelCount.TabIndex = 29
        '
        'btnClearCounter
        '
        Me.btnClearCounter.Location = New System.Drawing.Point(257, 106)
        Me.btnClearCounter.Name = "btnClearCounter"
        Me.btnClearCounter.Size = New System.Drawing.Size(93, 34)
        Me.btnClearCounter.TabIndex = 15
        Me.btnClearCounter.Text = "Clear to startup"
        Me.btnClearCounter.UseVisualStyleBackColor = True
        '
        'btnStop
        '
        Me.btnStop.Location = New System.Drawing.Point(257, 61)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(93, 36)
        Me.btnStop.TabIndex = 14
        Me.btnStop.Text = "Stop counting"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'txtAlarm
        '
        Me.txtAlarm.Location = New System.Drawing.Point(106, 114)
        Me.txtAlarm.Name = "txtAlarm"
        Me.txtAlarm.ReadOnly = True
        Me.txtAlarm.Size = New System.Drawing.Size(100, 22)
        Me.txtAlarm.TabIndex = 13
        '
        'btnAlarm
        '
        Me.btnAlarm.Location = New System.Drawing.Point(5, 114)
        Me.btnAlarm.Name = "btnAlarm"
        Me.btnAlarm.Size = New System.Drawing.Size(85, 23)
        Me.btnAlarm.TabIndex = 12
        Me.btnAlarm.Text = "Alarm"
        Me.btnAlarm.UseVisualStyleBackColor = True
        '
        'txtOverflow
        '
        Me.txtOverflow.Location = New System.Drawing.Point(85, 75)
        Me.txtOverflow.Name = "txtOverflow"
        Me.txtOverflow.ReadOnly = True
        Me.txtOverflow.Size = New System.Drawing.Size(121, 22)
        Me.txtOverflow.TabIndex = 11
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Location = New System.Drawing.Point(3, 78)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(52, 12)
        Me.label8.TabIndex = 10
        Me.label8.Text = "Overflow:"
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
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(3, 16)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(76, 12)
        Me.label5.TabIndex = 6
        Me.label5.Text = "Channel index:"
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(257, 16)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(93, 36)
        Me.btnStart.TabIndex = 5
        Me.btnStart.Text = "Start counting"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'txtCounter1
        '
        Me.txtCounter1.Location = New System.Drawing.Point(90, 112)
        Me.txtCounter1.Name = "txtCounter1"
        Me.txtCounter1.Size = New System.Drawing.Size(150, 22)
        Me.txtCounter1.TabIndex = 28
        '
        'txtCounter0
        '
        Me.txtCounter0.Location = New System.Drawing.Point(90, 77)
        Me.txtCounter0.Name = "txtCounter0"
        Me.txtCounter0.Size = New System.Drawing.Size(150, 22)
        Me.txtCounter0.TabIndex = 27
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(12, 115)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(60, 12)
        Me.label4.TabIndex = 26
        Me.label4.Text = "Ch-1 value:"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(12, 80)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(60, 12)
        Me.label3.TabIndex = 25
        Me.label3.Text = "Ch-0 value:"
        '
        'buttonStart
        '
        Me.buttonStart.Location = New System.Drawing.Point(284, 4)
        Me.buttonStart.Name = "buttonStart"
        Me.buttonStart.Size = New System.Drawing.Size(75, 23)
        Me.buttonStart.TabIndex = 24
        Me.buttonStart.Text = "Start"
        Me.buttonStart.UseVisualStyleBackColor = True
        '
        'txtReadCount
        '
        Me.txtReadCount.Location = New System.Drawing.Point(90, 40)
        Me.txtReadCount.Name = "txtReadCount"
        Me.txtReadCount.ReadOnly = True
        Me.txtReadCount.Size = New System.Drawing.Size(150, 22)
        Me.txtReadCount.TabIndex = 23
        Me.txtReadCount.Text = "0"
        '
        'txtModule
        '
        Me.txtModule.Location = New System.Drawing.Point(90, 6)
        Me.txtModule.Name = "txtModule"
        Me.txtModule.Size = New System.Drawing.Size(150, 22)
        Me.txtModule.TabIndex = 22
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(12, 43)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(61, 12)
        Me.label2.TabIndex = 21
        Me.label2.Text = "Read count:"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(12, 9)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(72, 12)
        Me.label1.TabIndex = 20
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
        Me.ClientSize = New System.Drawing.Size(380, 311)
        Me.Controls.Add(Me.panelCount)
        Me.Controls.Add(Me.txtCounter1)
        Me.Controls.Add(Me.txtCounter0)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.buttonStart)
        Me.Controls.Add(Me.txtReadCount)
        Me.Controls.Add(Me.txtModule)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Form1"
        Me.Text = "Adam4080 sample program (VB)"
        Me.panelCount.ResumeLayout(False)
        Me.panelCount.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents panelCount As System.Windows.Forms.Panel
    Private WithEvents btnClearCounter As System.Windows.Forms.Button
    Private WithEvents btnStop As System.Windows.Forms.Button
    Private WithEvents txtAlarm As System.Windows.Forms.TextBox
    Private WithEvents btnAlarm As System.Windows.Forms.Button
    Private WithEvents txtOverflow As System.Windows.Forms.TextBox
    Private WithEvents label8 As System.Windows.Forms.Label
    Private WithEvents txtCounting As System.Windows.Forms.TextBox
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents cbxChannel As System.Windows.Forms.ComboBox
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents btnStart As System.Windows.Forms.Button
    Private WithEvents txtCounter1 As System.Windows.Forms.TextBox
    Private WithEvents txtCounter0 As System.Windows.Forms.TextBox
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents buttonStart As System.Windows.Forms.Button
    Private WithEvents txtReadCount As System.Windows.Forms.TextBox
    Private WithEvents txtModule As System.Windows.Forms.TextBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
