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
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
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
        Me.panelCount.Location = New System.Drawing.Point(5, 214)
        Me.panelCount.Name = "panelCount"
        Me.panelCount.Size = New System.Drawing.Size(336, 194)
        Me.panelCount.TabIndex = 41
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
        Me.panelAlarm.TabIndex = 19
        '
        'btnClearLatch
        '
        Me.btnClearLatch.Location = New System.Drawing.Point(234, 10)
        Me.btnClearLatch.Name = "btnClearLatch"
        Me.btnClearLatch.Size = New System.Drawing.Size(93, 25)
        Me.btnClearLatch.TabIndex = 4
        Me.btnClearLatch.Text = "Clear latch alarm"
        Me.btnClearLatch.UseVisualStyleBackColor = True
        '
        'txtHighAlarm
        '
        Me.txtHighAlarm.Location = New System.Drawing.Point(86, 54)
        Me.txtHighAlarm.Name = "txtHighAlarm"
        Me.txtHighAlarm.ReadOnly = True
        Me.txtHighAlarm.Size = New System.Drawing.Size(100, 22)
        Me.txtHighAlarm.TabIndex = 3
        '
        'txtLowAlarm
        '
        Me.txtLowAlarm.Location = New System.Drawing.Point(85, 12)
        Me.txtLowAlarm.Name = "txtLowAlarm"
        Me.txtLowAlarm.ReadOnly = True
        Me.txtLowAlarm.Size = New System.Drawing.Size(100, 22)
        Me.txtLowAlarm.TabIndex = 2
        '
        'btnHighAlarm
        '
        Me.btnHighAlarm.Location = New System.Drawing.Point(5, 52)
        Me.btnHighAlarm.Name = "btnHighAlarm"
        Me.btnHighAlarm.Size = New System.Drawing.Size(75, 23)
        Me.btnHighAlarm.TabIndex = 1
        Me.btnHighAlarm.Text = "High alarm"
        Me.btnHighAlarm.UseVisualStyleBackColor = True
        '
        'btnLowAlarm
        '
        Me.btnLowAlarm.Location = New System.Drawing.Point(5, 12)
        Me.btnLowAlarm.Name = "btnLowAlarm"
        Me.btnLowAlarm.Size = New System.Drawing.Size(75, 23)
        Me.btnLowAlarm.TabIndex = 0
        Me.btnLowAlarm.Text = "Low alarm"
        Me.btnLowAlarm.UseVisualStyleBackColor = True
        '
        'btnClearCounter
        '
        Me.btnClearCounter.Location = New System.Drawing.Point(234, 73)
        Me.btnClearCounter.Name = "btnClearCounter"
        Me.btnClearCounter.Size = New System.Drawing.Size(93, 29)
        Me.btnClearCounter.TabIndex = 18
        Me.btnClearCounter.Text = "Clear to startup"
        Me.btnClearCounter.UseVisualStyleBackColor = True
        '
        'btnStop
        '
        Me.btnStop.Location = New System.Drawing.Point(234, 39)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(93, 28)
        Me.btnStop.TabIndex = 17
        Me.btnStop.Text = "Stop counting"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(234, 6)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(93, 27)
        Me.btnStart.TabIndex = 16
        Me.btnStart.Text = "Start counting"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'txtOverflow
        '
        Me.txtOverflow.Location = New System.Drawing.Point(85, 78)
        Me.txtOverflow.Name = "txtOverflow"
        Me.txtOverflow.ReadOnly = True
        Me.txtOverflow.Size = New System.Drawing.Size(100, 22)
        Me.txtOverflow.TabIndex = 5
        '
        'txtCounting
        '
        Me.txtCounting.Location = New System.Drawing.Point(85, 44)
        Me.txtCounting.Name = "txtCounting"
        Me.txtCounting.ReadOnly = True
        Me.txtCounting.Size = New System.Drawing.Size(100, 22)
        Me.txtCounting.TabIndex = 4
        '
        'cbxChannel
        '
        Me.cbxChannel.FormattingEnabled = True
        Me.cbxChannel.Location = New System.Drawing.Point(85, 9)
        Me.cbxChannel.Name = "cbxChannel"
        Me.cbxChannel.Size = New System.Drawing.Size(108, 20)
        Me.cbxChannel.TabIndex = 3
        '
        'label9
        '
        Me.label9.AutoSize = True
        Me.label9.Location = New System.Drawing.Point(3, 81)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(52, 12)
        Me.label9.TabIndex = 2
        Me.label9.Text = "Overflow:"
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Location = New System.Drawing.Point(3, 47)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(52, 12)
        Me.label8.TabIndex = 1
        Me.label8.Text = "Counting:"
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(3, 12)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(76, 12)
        Me.label7.TabIndex = 0
        Me.label7.Text = "Channel index:"
        '
        'panelLEDOutput
        '
        Me.panelLEDOutput.Controls.Add(Me.btnLED)
        Me.panelLEDOutput.Controls.Add(Me.txtLED)
        Me.panelLEDOutput.Controls.Add(Me.label6)
        Me.panelLEDOutput.Location = New System.Drawing.Point(5, 178)
        Me.panelLEDOutput.Name = "panelLEDOutput"
        Me.panelLEDOutput.Size = New System.Drawing.Size(336, 36)
        Me.panelLEDOutput.TabIndex = 30
        '
        'btnLED
        '
        Me.btnLED.Location = New System.Drawing.Point(252, 6)
        Me.btnLED.Name = "btnLED"
        Me.btnLED.Size = New System.Drawing.Size(75, 23)
        Me.btnLED.TabIndex = 4
        Me.btnLED.Text = "Set LED"
        Me.btnLED.UseVisualStyleBackColor = True
        '
        'txtLED
        '
        Me.txtLED.Location = New System.Drawing.Point(75, 7)
        Me.txtLED.Name = "txtLED"
        Me.txtLED.Size = New System.Drawing.Size(100, 22)
        Me.txtLED.TabIndex = 3
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(3, 10)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(63, 12)
        Me.label6.TabIndex = 1
        Me.label6.Text = "LED output:"
        '
        'panelLED
        '
        Me.panelLED.Controls.Add(Me.btnApplyLED)
        Me.panelLED.Controls.Add(Me.cbxLedSource)
        Me.panelLED.Controls.Add(Me.label5)
        Me.panelLED.Location = New System.Drawing.Point(5, 140)
        Me.panelLED.Name = "panelLED"
        Me.panelLED.Size = New System.Drawing.Size(336, 74)
        Me.panelLED.TabIndex = 40
        '
        'btnApplyLED
        '
        Me.btnApplyLED.Location = New System.Drawing.Point(252, 10)
        Me.btnApplyLED.Name = "btnApplyLED"
        Me.btnApplyLED.Size = New System.Drawing.Size(75, 23)
        Me.btnApplyLED.TabIndex = 3
        Me.btnApplyLED.Text = "Apply"
        Me.btnApplyLED.UseVisualStyleBackColor = True
        '
        'cbxLedSource
        '
        Me.cbxLedSource.FormattingEnabled = True
        Me.cbxLedSource.Location = New System.Drawing.Point(72, 12)
        Me.cbxLedSource.Name = "cbxLedSource"
        Me.cbxLedSource.Size = New System.Drawing.Size(121, 20)
        Me.cbxLedSource.TabIndex = 2
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(3, 15)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(63, 12)
        Me.label5.TabIndex = 0
        Me.label5.Text = "LED source:"
        '
        'txtCounter1
        '
        Me.txtCounter1.Location = New System.Drawing.Point(90, 112)
        Me.txtCounter1.Name = "txtCounter1"
        Me.txtCounter1.Size = New System.Drawing.Size(150, 22)
        Me.txtCounter1.TabIndex = 39
        '
        'txtCounter0
        '
        Me.txtCounter0.Location = New System.Drawing.Point(90, 77)
        Me.txtCounter0.Name = "txtCounter0"
        Me.txtCounter0.Size = New System.Drawing.Size(150, 22)
        Me.txtCounter0.TabIndex = 38
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(12, 115)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(60, 12)
        Me.label4.TabIndex = 37
        Me.label4.Text = "Ch-1 value:"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(12, 80)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(60, 12)
        Me.label3.TabIndex = 36
        Me.label3.Text = "Ch-0 value:"
        '
        'buttonStart
        '
        Me.buttonStart.Location = New System.Drawing.Point(257, 4)
        Me.buttonStart.Name = "buttonStart"
        Me.buttonStart.Size = New System.Drawing.Size(75, 23)
        Me.buttonStart.TabIndex = 35
        Me.buttonStart.Text = "Start"
        Me.buttonStart.UseVisualStyleBackColor = True
        '
        'txtReadCount
        '
        Me.txtReadCount.Location = New System.Drawing.Point(90, 40)
        Me.txtReadCount.Name = "txtReadCount"
        Me.txtReadCount.ReadOnly = True
        Me.txtReadCount.Size = New System.Drawing.Size(150, 22)
        Me.txtReadCount.TabIndex = 34
        Me.txtReadCount.Text = "0"
        '
        'txtModule
        '
        Me.txtModule.Location = New System.Drawing.Point(90, 6)
        Me.txtModule.Name = "txtModule"
        Me.txtModule.Size = New System.Drawing.Size(150, 22)
        Me.txtModule.TabIndex = 33
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(12, 43)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(61, 12)
        Me.label2.TabIndex = 32
        Me.label2.Text = "Read count:"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(12, 9)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(72, 12)
        Me.label1.TabIndex = 31
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
        Me.ClientSize = New System.Drawing.Size(346, 413)
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
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Form1"
        Me.Text = "Adam4080D sample program (VB)"
        Me.panelCount.ResumeLayout(False)
        Me.panelCount.PerformLayout()
        Me.panelAlarm.ResumeLayout(False)
        Me.panelAlarm.PerformLayout()
        Me.panelLEDOutput.ResumeLayout(False)
        Me.panelLEDOutput.PerformLayout()
        Me.panelLED.ResumeLayout(False)
        Me.panelLED.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
