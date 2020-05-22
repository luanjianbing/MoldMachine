<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Form1
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
        Me.Timer1 = New System.Windows.Forms.Timer
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
        Me.panelCount.Location = New System.Drawing.Point(0, 154)
        Me.panelCount.Name = "panelCount"
        Me.panelCount.Size = New System.Drawing.Size(361, 148)
        '
        'btnClearCounter
        '
        Me.btnClearCounter.Location = New System.Drawing.Point(257, 106)
        Me.btnClearCounter.Name = "btnClearCounter"
        Me.btnClearCounter.Size = New System.Drawing.Size(101, 34)
        Me.btnClearCounter.TabIndex = 15
        Me.btnClearCounter.Text = "Clear to startup"
        '
        'btnStop
        '
        Me.btnStop.Location = New System.Drawing.Point(257, 61)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(101, 36)
        Me.btnStop.TabIndex = 14
        Me.btnStop.Text = "Stop counting"
        '
        'txtAlarm
        '
        Me.txtAlarm.Location = New System.Drawing.Point(106, 114)
        Me.txtAlarm.Name = "txtAlarm"
        Me.txtAlarm.ReadOnly = True
        Me.txtAlarm.Size = New System.Drawing.Size(100, 23)
        Me.txtAlarm.TabIndex = 13
        '
        'btnAlarm
        '
        Me.btnAlarm.Location = New System.Drawing.Point(5, 114)
        Me.btnAlarm.Name = "btnAlarm"
        Me.btnAlarm.Size = New System.Drawing.Size(85, 23)
        Me.btnAlarm.TabIndex = 12
        Me.btnAlarm.Text = "Alarm"
        '
        'txtOverflow
        '
        Me.txtOverflow.Location = New System.Drawing.Point(91, 75)
        Me.txtOverflow.Name = "txtOverflow"
        Me.txtOverflow.ReadOnly = True
        Me.txtOverflow.Size = New System.Drawing.Size(121, 23)
        Me.txtOverflow.TabIndex = 11
        '
        'label8
        '
        Me.label8.Location = New System.Drawing.Point(3, 78)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(67, 19)
        Me.label8.Text = "Overflow:"
        '
        'txtCounting
        '
        Me.txtCounting.Location = New System.Drawing.Point(91, 43)
        Me.txtCounting.Name = "txtCounting"
        Me.txtCounting.ReadOnly = True
        Me.txtCounting.Size = New System.Drawing.Size(121, 23)
        Me.txtCounting.TabIndex = 9
        '
        'label6
        '
        Me.label6.Location = New System.Drawing.Point(3, 46)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(67, 20)
        Me.label6.Text = "Counting:"
        '
        'cbxChannel
        '
        Me.cbxChannel.Location = New System.Drawing.Point(91, 13)
        Me.cbxChannel.Name = "cbxChannel"
        Me.cbxChannel.Size = New System.Drawing.Size(121, 23)
        Me.cbxChannel.TabIndex = 7
        '
        'label5
        '
        Me.label5.Location = New System.Drawing.Point(3, 16)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(96, 20)
        Me.label5.Text = "Channel index:"
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(257, 16)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(101, 36)
        Me.btnStart.TabIndex = 5
        Me.btnStart.Text = "Start counting"
        '
        'txtCounter1
        '
        Me.txtCounter1.Location = New System.Drawing.Point(88, 114)
        Me.txtCounter1.Name = "txtCounter1"
        Me.txtCounter1.Size = New System.Drawing.Size(150, 23)
        Me.txtCounter1.TabIndex = 38
        '
        'txtCounter0
        '
        Me.txtCounter0.Location = New System.Drawing.Point(88, 79)
        Me.txtCounter0.Name = "txtCounter0"
        Me.txtCounter0.Size = New System.Drawing.Size(150, 23)
        Me.txtCounter0.TabIndex = 37
        '
        'label4
        '
        Me.label4.Location = New System.Drawing.Point(0, 117)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(77, 20)
        Me.label4.Text = "Ch-1 value:"
        '
        'label3
        '
        Me.label3.Location = New System.Drawing.Point(0, 82)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(77, 20)
        Me.label3.Text = "Ch-0 value:"
        '
        'buttonStart
        '
        Me.buttonStart.Location = New System.Drawing.Point(275, 8)
        Me.buttonStart.Name = "buttonStart"
        Me.buttonStart.Size = New System.Drawing.Size(75, 23)
        Me.buttonStart.TabIndex = 36
        Me.buttonStart.Text = "Start"
        '
        'txtReadCount
        '
        Me.txtReadCount.Location = New System.Drawing.Point(88, 42)
        Me.txtReadCount.Name = "txtReadCount"
        Me.txtReadCount.ReadOnly = True
        Me.txtReadCount.Size = New System.Drawing.Size(150, 23)
        Me.txtReadCount.TabIndex = 35
        Me.txtReadCount.Text = "0"
        '
        'txtModule
        '
        Me.txtModule.Location = New System.Drawing.Point(88, 8)
        Me.txtModule.Name = "txtModule"
        Me.txtModule.Size = New System.Drawing.Size(150, 23)
        Me.txtModule.TabIndex = 34
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(0, 45)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(88, 20)
        Me.label2.Text = "Read count:"
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(0, 11)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(97, 18)
        Me.label1.Text = "Module name:"
        '
        'Timer1
        '
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(362, 305)
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
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Text = "Adam4080 Sample Program (VB)"
        Me.panelCount.ResumeLayout(False)
        Me.ResumeLayout(False)

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
