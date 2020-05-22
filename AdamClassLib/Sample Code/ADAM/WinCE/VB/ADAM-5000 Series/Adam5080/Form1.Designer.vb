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
        Me.Timer1 = New System.Windows.Forms.Timer
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
        Me.panelCount.Location = New System.Drawing.Point(2, 227)
        Me.panelCount.Name = "panelCount"
        Me.panelCount.Size = New System.Drawing.Size(361, 128)
        '
        'btnClearCounter
        '
        Me.btnClearCounter.Location = New System.Drawing.Point(245, 88)
        Me.btnClearCounter.Name = "btnClearCounter"
        Me.btnClearCounter.Size = New System.Drawing.Size(105, 34)
        Me.btnClearCounter.TabIndex = 15
        Me.btnClearCounter.Text = "Clear to startup"
        '
        'btnStop
        '
        Me.btnStop.Location = New System.Drawing.Point(245, 46)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(105, 36)
        Me.btnStop.TabIndex = 14
        Me.btnStop.Text = "Stop counting"
        '
        'txtOverflow
        '
        Me.txtOverflow.Location = New System.Drawing.Point(96, 75)
        Me.txtOverflow.Name = "txtOverflow"
        Me.txtOverflow.ReadOnly = True
        Me.txtOverflow.Size = New System.Drawing.Size(121, 23)
        Me.txtOverflow.TabIndex = 11
        '
        'label5
        '
        Me.label5.Location = New System.Drawing.Point(3, 78)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(66, 20)
        Me.label5.Text = "Overflow:"
        '
        'txtCounting
        '
        Me.txtCounting.Location = New System.Drawing.Point(96, 43)
        Me.txtCounting.Name = "txtCounting"
        Me.txtCounting.ReadOnly = True
        Me.txtCounting.Size = New System.Drawing.Size(121, 23)
        Me.txtCounting.TabIndex = 9
        '
        'label6
        '
        Me.label6.Location = New System.Drawing.Point(3, 46)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(66, 20)
        Me.label6.Text = "Counting:"
        '
        'cbxChannel
        '
        Me.cbxChannel.Location = New System.Drawing.Point(96, 13)
        Me.cbxChannel.Name = "cbxChannel"
        Me.cbxChannel.Size = New System.Drawing.Size(121, 23)
        Me.cbxChannel.TabIndex = 7
        '
        'label7
        '
        Me.label7.Location = New System.Drawing.Point(3, 16)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(96, 20)
        Me.label7.Text = "Channel index:"
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(245, 4)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(105, 36)
        Me.btnStart.TabIndex = 5
        Me.btnStart.Text = "Start counting"
        '
        'label9
        '
        Me.label9.Location = New System.Drawing.Point(0, 197)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(81, 20)
        Me.label9.Text = "Ch-3 value:"
        '
        'label8
        '
        Me.label8.Location = New System.Drawing.Point(0, 161)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(81, 20)
        Me.label8.Text = "Ch-2 value:"
        '
        'label4
        '
        Me.label4.Location = New System.Drawing.Point(0, 125)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(81, 20)
        Me.label4.Text = "Ch-1 value:"
        '
        'label3
        '
        Me.label3.Location = New System.Drawing.Point(0, 89)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(81, 20)
        Me.label3.Text = "Ch-0 value:"
        '
        'txtCounter3
        '
        Me.txtCounter3.Location = New System.Drawing.Point(90, 194)
        Me.txtCounter3.Name = "txtCounter3"
        Me.txtCounter3.Size = New System.Drawing.Size(119, 23)
        Me.txtCounter3.TabIndex = 88
        '
        'buttonStart
        '
        Me.buttonStart.Location = New System.Drawing.Point(277, 10)
        Me.buttonStart.Name = "buttonStart"
        Me.buttonStart.Size = New System.Drawing.Size(75, 23)
        Me.buttonStart.TabIndex = 87
        Me.buttonStart.Text = "Start"
        '
        'txtCounter2
        '
        Me.txtCounter2.Location = New System.Drawing.Point(90, 158)
        Me.txtCounter2.Name = "txtCounter2"
        Me.txtCounter2.Size = New System.Drawing.Size(119, 23)
        Me.txtCounter2.TabIndex = 86
        '
        'txtCounter1
        '
        Me.txtCounter1.Location = New System.Drawing.Point(90, 122)
        Me.txtCounter1.Name = "txtCounter1"
        Me.txtCounter1.Size = New System.Drawing.Size(119, 23)
        Me.txtCounter1.TabIndex = 85
        '
        'txtCounter0
        '
        Me.txtCounter0.Location = New System.Drawing.Point(90, 86)
        Me.txtCounter0.Name = "txtCounter0"
        Me.txtCounter0.Size = New System.Drawing.Size(119, 23)
        Me.txtCounter0.TabIndex = 84
        '
        'txtReadCount
        '
        Me.txtReadCount.Location = New System.Drawing.Point(90, 43)
        Me.txtReadCount.Name = "txtReadCount"
        Me.txtReadCount.ReadOnly = True
        Me.txtReadCount.Size = New System.Drawing.Size(119, 23)
        Me.txtReadCount.TabIndex = 83
        Me.txtReadCount.Text = "0"
        '
        'txtModule
        '
        Me.txtModule.Location = New System.Drawing.Point(90, 10)
        Me.txtModule.Name = "txtModule"
        Me.txtModule.Size = New System.Drawing.Size(119, 23)
        Me.txtModule.TabIndex = 82
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(0, 46)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(81, 20)
        Me.label2.Text = "Read count:"
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(0, 13)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(91, 20)
        Me.label1.Text = "Module name:"
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(365, 358)
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
        Me.Name = "Form1"
        Me.Text = "Adam5080 sample program (VB)"
        Me.panelCount.ResumeLayout(False)
        Me.ResumeLayout(False)

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
