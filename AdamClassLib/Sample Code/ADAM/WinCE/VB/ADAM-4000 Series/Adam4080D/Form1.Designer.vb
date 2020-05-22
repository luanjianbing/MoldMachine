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
        Me.panelAlarm = New System.Windows.Forms.Panel
        Me.btnClearLatch = New System.Windows.Forms.Button
        Me.txtHighAlarm = New System.Windows.Forms.TextBox
        Me.txtLowAlarm = New System.Windows.Forms.TextBox
        Me.btnHighAlarm = New System.Windows.Forms.Button
        Me.btnLowAlarm = New System.Windows.Forms.Button
        Me.btnClearCounter = New System.Windows.Forms.Button
        Me.btnStop = New System.Windows.Forms.Button
        Me.btnStart = New System.Windows.Forms.Button
        Me.txtOverflow = New System.Windows.Forms.TextBox
        Me.txtCounting = New System.Windows.Forms.TextBox
        Me.cbxChannel = New System.Windows.Forms.ComboBox
        Me.label9 = New System.Windows.Forms.Label
        Me.label8 = New System.Windows.Forms.Label
        Me.label7 = New System.Windows.Forms.Label
        Me.panelLEDOutput = New System.Windows.Forms.Panel
        Me.btnLED = New System.Windows.Forms.Button
        Me.txtLED = New System.Windows.Forms.TextBox
        Me.label6 = New System.Windows.Forms.Label
        Me.panelLED = New System.Windows.Forms.Panel
        Me.btnApplyLED = New System.Windows.Forms.Button
        Me.cbxLedSource = New System.Windows.Forms.ComboBox
        Me.label5 = New System.Windows.Forms.Label
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
        Me.panelAlarm.SuspendLayout()
        Me.panelLEDOutput.SuspendLayout()
        Me.panelLED.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelCount
        '
        Me.panelCount.BackColor = System.Drawing.Color.SkyBlue
        Me.panelCount.Controls.Add(Me.panelAlarm)
        Me.panelCount.Controls.Add(Me.btnClearCounter)
        Me.panelCount.Controls.Add(Me.btnStop)
        Me.panelCount.Controls.Add(Me.btnStart)
        Me.panelCount.Controls.Add(Me.txtOverflow)
        Me.panelCount.Controls.Add(Me.txtCounting)
        Me.panelCount.Controls.Add(Me.cbxChannel)
        Me.panelCount.Controls.Add(Me.label9)
        Me.panelCount.Controls.Add(Me.label8)
        Me.panelCount.Controls.Add(Me.label7)
        Me.panelCount.Location = New System.Drawing.Point(3, 216)
        Me.panelCount.Name = "panelCount"
        Me.panelCount.Size = New System.Drawing.Size(336, 194)
        '
        'panelAlarm
        '
        Me.panelAlarm.Controls.Add(Me.btnClearLatch)
        Me.panelAlarm.Controls.Add(Me.txtHighAlarm)
        Me.panelAlarm.Controls.Add(Me.txtLowAlarm)
        Me.panelAlarm.Controls.Add(Me.btnHighAlarm)
        Me.panelAlarm.Controls.Add(Me.btnLowAlarm)
        Me.panelAlarm.Location = New System.Drawing.Point(0, 108)
        Me.panelAlarm.Name = "panelAlarm"
        Me.panelAlarm.Size = New System.Drawing.Size(335, 86)
        '
        'btnClearLatch
        '
        Me.btnClearLatch.Location = New System.Drawing.Point(225, 10)
        Me.btnClearLatch.Name = "btnClearLatch"
        Me.btnClearLatch.Size = New System.Drawing.Size(102, 25)
        Me.btnClearLatch.TabIndex = 4
        Me.btnClearLatch.Text = "Clear latch alarm"
        '
        'txtHighAlarm
        '
        Me.txtHighAlarm.Location = New System.Drawing.Point(94, 54)
        Me.txtHighAlarm.Name = "txtHighAlarm"
        Me.txtHighAlarm.ReadOnly = True
        Me.txtHighAlarm.Size = New System.Drawing.Size(100, 23)
        Me.txtHighAlarm.TabIndex = 3
        '
        'txtLowAlarm
        '
        Me.txtLowAlarm.Location = New System.Drawing.Point(93, 12)
        Me.txtLowAlarm.Name = "txtLowAlarm"
        Me.txtLowAlarm.ReadOnly = True
        Me.txtLowAlarm.Size = New System.Drawing.Size(100, 23)
        Me.txtLowAlarm.TabIndex = 2
        '
        'btnHighAlarm
        '
        Me.btnHighAlarm.Location = New System.Drawing.Point(5, 52)
        Me.btnHighAlarm.Name = "btnHighAlarm"
        Me.btnHighAlarm.Size = New System.Drawing.Size(75, 23)
        Me.btnHighAlarm.TabIndex = 1
        Me.btnHighAlarm.Text = "High alarm"
        '
        'btnLowAlarm
        '
        Me.btnLowAlarm.Location = New System.Drawing.Point(5, 12)
        Me.btnLowAlarm.Name = "btnLowAlarm"
        Me.btnLowAlarm.Size = New System.Drawing.Size(75, 23)
        Me.btnLowAlarm.TabIndex = 0
        Me.btnLowAlarm.Text = "Low alarm"
        '
        'btnClearCounter
        '
        Me.btnClearCounter.Location = New System.Drawing.Point(225, 73)
        Me.btnClearCounter.Name = "btnClearCounter"
        Me.btnClearCounter.Size = New System.Drawing.Size(102, 29)
        Me.btnClearCounter.TabIndex = 18
        Me.btnClearCounter.Text = "Clear to startup"
        '
        'btnStop
        '
        Me.btnStop.Location = New System.Drawing.Point(225, 39)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(102, 28)
        Me.btnStop.TabIndex = 17
        Me.btnStop.Text = "Stop counting"
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(225, 6)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(102, 27)
        Me.btnStart.TabIndex = 16
        Me.btnStart.Text = "Start counting"
        '
        'txtOverflow
        '
        Me.txtOverflow.Location = New System.Drawing.Point(93, 78)
        Me.txtOverflow.Name = "txtOverflow"
        Me.txtOverflow.ReadOnly = True
        Me.txtOverflow.Size = New System.Drawing.Size(100, 23)
        Me.txtOverflow.TabIndex = 5
        '
        'txtCounting
        '
        Me.txtCounting.Location = New System.Drawing.Point(93, 44)
        Me.txtCounting.Name = "txtCounting"
        Me.txtCounting.ReadOnly = True
        Me.txtCounting.Size = New System.Drawing.Size(100, 23)
        Me.txtCounting.TabIndex = 4
        '
        'cbxChannel
        '
        Me.cbxChannel.Location = New System.Drawing.Point(93, 9)
        Me.cbxChannel.Name = "cbxChannel"
        Me.cbxChannel.Size = New System.Drawing.Size(108, 23)
        Me.cbxChannel.TabIndex = 3
        '
        'label9
        '
        Me.label9.Location = New System.Drawing.Point(3, 81)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(77, 20)
        Me.label9.Text = "Overflow:"
        '
        'label8
        '
        Me.label8.Location = New System.Drawing.Point(3, 47)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(77, 20)
        Me.label8.Text = "Counting:"
        '
        'label7
        '
        Me.label7.Location = New System.Drawing.Point(3, 12)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(95, 20)
        Me.label7.Text = "Channel index:"
        '
        'panelLEDOutput
        '
        Me.panelLEDOutput.Controls.Add(Me.btnLED)
        Me.panelLEDOutput.Controls.Add(Me.txtLED)
        Me.panelLEDOutput.Controls.Add(Me.label6)
        Me.panelLEDOutput.Location = New System.Drawing.Point(3, 180)
        Me.panelLEDOutput.Name = "panelLEDOutput"
        Me.panelLEDOutput.Size = New System.Drawing.Size(336, 36)
        '
        'btnLED
        '
        Me.btnLED.Location = New System.Drawing.Point(252, 6)
        Me.btnLED.Name = "btnLED"
        Me.btnLED.Size = New System.Drawing.Size(75, 23)
        Me.btnLED.TabIndex = 4
        Me.btnLED.Text = "Set LED"
        '
        'txtLED
        '
        Me.txtLED.Location = New System.Drawing.Point(85, 6)
        Me.txtLED.Name = "txtLED"
        Me.txtLED.Size = New System.Drawing.Size(100, 23)
        Me.txtLED.TabIndex = 3
        '
        'label6
        '
        Me.label6.Location = New System.Drawing.Point(3, 10)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(77, 19)
        Me.label6.Text = "LED output:"
        '
        'panelLED
        '
        Me.panelLED.Controls.Add(Me.btnApplyLED)
        Me.panelLED.Controls.Add(Me.cbxLedSource)
        Me.panelLED.Controls.Add(Me.label5)
        Me.panelLED.Location = New System.Drawing.Point(3, 142)
        Me.panelLED.Name = "panelLED"
        Me.panelLED.Size = New System.Drawing.Size(336, 74)
        '
        'btnApplyLED
        '
        Me.btnApplyLED.Location = New System.Drawing.Point(252, 10)
        Me.btnApplyLED.Name = "btnApplyLED"
        Me.btnApplyLED.Size = New System.Drawing.Size(75, 23)
        Me.btnApplyLED.TabIndex = 3
        Me.btnApplyLED.Text = "Apply"
        '
        'cbxLedSource
        '
        Me.cbxLedSource.Location = New System.Drawing.Point(85, 10)
        Me.cbxLedSource.Name = "cbxLedSource"
        Me.cbxLedSource.Size = New System.Drawing.Size(121, 23)
        Me.cbxLedSource.TabIndex = 2
        '
        'label5
        '
        Me.label5.Location = New System.Drawing.Point(3, 15)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(78, 18)
        Me.label5.Text = "LED source:"
        '
        'txtCounter1
        '
        Me.txtCounter1.Location = New System.Drawing.Point(93, 114)
        Me.txtCounter1.Name = "txtCounter1"
        Me.txtCounter1.Size = New System.Drawing.Size(125, 23)
        Me.txtCounter1.TabIndex = 51
        '
        'txtCounter0
        '
        Me.txtCounter0.Location = New System.Drawing.Point(93, 79)
        Me.txtCounter0.Name = "txtCounter0"
        Me.txtCounter0.Size = New System.Drawing.Size(125, 23)
        Me.txtCounter0.TabIndex = 50
        '
        'label4
        '
        Me.label4.Location = New System.Drawing.Point(3, 117)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(91, 20)
        Me.label4.Text = "Ch-1 value:"
        '
        'label3
        '
        Me.label3.Location = New System.Drawing.Point(3, 82)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(91, 20)
        Me.label3.Text = "Ch-0 value:"
        '
        'buttonStart
        '
        Me.buttonStart.Location = New System.Drawing.Point(263, 8)
        Me.buttonStart.Name = "buttonStart"
        Me.buttonStart.Size = New System.Drawing.Size(75, 23)
        Me.buttonStart.TabIndex = 49
        Me.buttonStart.Text = "Start"
        '
        'txtReadCount
        '
        Me.txtReadCount.Location = New System.Drawing.Point(93, 42)
        Me.txtReadCount.Name = "txtReadCount"
        Me.txtReadCount.ReadOnly = True
        Me.txtReadCount.Size = New System.Drawing.Size(125, 23)
        Me.txtReadCount.TabIndex = 48
        Me.txtReadCount.Text = "0"
        '
        'txtModule
        '
        Me.txtModule.Location = New System.Drawing.Point(93, 8)
        Me.txtModule.Name = "txtModule"
        Me.txtModule.Size = New System.Drawing.Size(125, 23)
        Me.txtModule.TabIndex = 47
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(3, 45)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(91, 20)
        Me.label2.Text = "Read count:"
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(3, 11)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(91, 18)
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
        Me.ClientSize = New System.Drawing.Size(342, 414)
        Me.Controls.Add(Me.panelCount)
        Me.Controls.Add(Me.panelLEDOutput)
        Me.Controls.Add(Me.panelLED)
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
        Me.Text = "Adam4080D Sample Program (VB)"
        Me.panelCount.ResumeLayout(False)
        Me.panelAlarm.ResumeLayout(False)
        Me.panelLEDOutput.ResumeLayout(False)
        Me.panelLED.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents panelCount As System.Windows.Forms.Panel
    Private WithEvents panelAlarm As System.Windows.Forms.Panel
    Private WithEvents btnClearLatch As System.Windows.Forms.Button
    Private WithEvents txtHighAlarm As System.Windows.Forms.TextBox
    Private WithEvents txtLowAlarm As System.Windows.Forms.TextBox
    Private WithEvents btnHighAlarm As System.Windows.Forms.Button
    Private WithEvents btnLowAlarm As System.Windows.Forms.Button
    Private WithEvents btnClearCounter As System.Windows.Forms.Button
    Private WithEvents btnStop As System.Windows.Forms.Button
    Private WithEvents btnStart As System.Windows.Forms.Button
    Private WithEvents txtOverflow As System.Windows.Forms.TextBox
    Private WithEvents txtCounting As System.Windows.Forms.TextBox
    Private WithEvents cbxChannel As System.Windows.Forms.ComboBox
    Private WithEvents label9 As System.Windows.Forms.Label
    Private WithEvents label8 As System.Windows.Forms.Label
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents panelLEDOutput As System.Windows.Forms.Panel
    Private WithEvents btnLED As System.Windows.Forms.Button
    Private WithEvents txtLED As System.Windows.Forms.TextBox
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents panelLED As System.Windows.Forms.Panel
    Private WithEvents btnApplyLED As System.Windows.Forms.Button
    Private WithEvents cbxLedSource As System.Windows.Forms.ComboBox
    Private WithEvents label5 As System.Windows.Forms.Label
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
