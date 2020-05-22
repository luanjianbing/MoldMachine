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
        Me.panelAlarm = New System.Windows.Forms.Panel
        Me.buttonDO3 = New System.Windows.Forms.Button
        Me.buttonDO2 = New System.Windows.Forms.Button
        Me.buttonDO1 = New System.Windows.Forms.Button
        Me.buttonDO0 = New System.Windows.Forms.Button
        Me.txtDO3 = New System.Windows.Forms.TextBox
        Me.txtDO2 = New System.Windows.Forms.TextBox
        Me.txtHighAlarm = New System.Windows.Forms.TextBox
        Me.txtLowAlarm = New System.Windows.Forms.TextBox
        Me.txtMode = New System.Windows.Forms.TextBox
        Me.label12 = New System.Windows.Forms.Label
        Me.label11 = New System.Windows.Forms.Label
        Me.label10 = New System.Windows.Forms.Label
        Me.label9 = New System.Windows.Forms.Label
        Me.label8 = New System.Windows.Forms.Label
        Me.panelAO = New System.Windows.Forms.Panel
        Me.btnApplyOutput = New System.Windows.Forms.Button
        Me.txtOutputValue = New System.Windows.Forms.TextBox
        Me.label7 = New System.Windows.Forms.Label
        Me.label6 = New System.Windows.Forms.Label
        Me.label5 = New System.Windows.Forms.Label
        Me.trackBar1 = New System.Windows.Forms.TrackBar
        Me.buttonStart = New System.Windows.Forms.Button
        Me.txtAOValue = New System.Windows.Forms.TextBox
        Me.txtAIValue = New System.Windows.Forms.TextBox
        Me.txtReadCount = New System.Windows.Forms.TextBox
        Me.txtModule = New System.Windows.Forms.TextBox
        Me.label4 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer
        Me.panelAlarm.SuspendLayout()
        Me.panelAO.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelAlarm
        '
        Me.panelAlarm.BackColor = System.Drawing.Color.SkyBlue
        Me.panelAlarm.Controls.Add(Me.buttonDO3)
        Me.panelAlarm.Controls.Add(Me.buttonDO2)
        Me.panelAlarm.Controls.Add(Me.buttonDO1)
        Me.panelAlarm.Controls.Add(Me.buttonDO0)
        Me.panelAlarm.Controls.Add(Me.txtDO3)
        Me.panelAlarm.Controls.Add(Me.txtDO2)
        Me.panelAlarm.Controls.Add(Me.txtHighAlarm)
        Me.panelAlarm.Controls.Add(Me.txtLowAlarm)
        Me.panelAlarm.Controls.Add(Me.txtMode)
        Me.panelAlarm.Controls.Add(Me.label12)
        Me.panelAlarm.Controls.Add(Me.label11)
        Me.panelAlarm.Controls.Add(Me.label10)
        Me.panelAlarm.Controls.Add(Me.label9)
        Me.panelAlarm.Controls.Add(Me.label8)
        Me.panelAlarm.Location = New System.Drawing.Point(3, 287)
        Me.panelAlarm.Name = "panelAlarm"
        Me.panelAlarm.Size = New System.Drawing.Size(348, 155)
        '
        'buttonDO3
        '
        Me.buttonDO3.Location = New System.Drawing.Point(232, 120)
        Me.buttonDO3.Name = "buttonDO3"
        Me.buttonDO3.Size = New System.Drawing.Size(106, 23)
        Me.buttonDO3.TabIndex = 13
        Me.buttonDO3.Text = "Output DO-3"
        '
        'buttonDO2
        '
        Me.buttonDO2.Location = New System.Drawing.Point(232, 92)
        Me.buttonDO2.Name = "buttonDO2"
        Me.buttonDO2.Size = New System.Drawing.Size(106, 23)
        Me.buttonDO2.TabIndex = 12
        Me.buttonDO2.Text = "Output DO-2"
        '
        'buttonDO1
        '
        Me.buttonDO1.Location = New System.Drawing.Point(232, 64)
        Me.buttonDO1.Name = "buttonDO1"
        Me.buttonDO1.Size = New System.Drawing.Size(106, 23)
        Me.buttonDO1.TabIndex = 11
        Me.buttonDO1.Text = "Output DO-1"
        '
        'buttonDO0
        '
        Me.buttonDO0.Location = New System.Drawing.Point(232, 36)
        Me.buttonDO0.Name = "buttonDO0"
        Me.buttonDO0.Size = New System.Drawing.Size(106, 23)
        Me.buttonDO0.TabIndex = 10
        Me.buttonDO0.Text = "Output DO-0"
        '
        'txtDO3
        '
        Me.txtDO3.Location = New System.Drawing.Point(118, 122)
        Me.txtDO3.Name = "txtDO3"
        Me.txtDO3.Size = New System.Drawing.Size(100, 23)
        Me.txtDO3.TabIndex = 9
        '
        'txtDO2
        '
        Me.txtDO2.Location = New System.Drawing.Point(118, 94)
        Me.txtDO2.Name = "txtDO2"
        Me.txtDO2.Size = New System.Drawing.Size(100, 23)
        Me.txtDO2.TabIndex = 8
        '
        'txtHighAlarm
        '
        Me.txtHighAlarm.Location = New System.Drawing.Point(118, 66)
        Me.txtHighAlarm.Name = "txtHighAlarm"
        Me.txtHighAlarm.Size = New System.Drawing.Size(100, 23)
        Me.txtHighAlarm.TabIndex = 7
        '
        'txtLowAlarm
        '
        Me.txtLowAlarm.Location = New System.Drawing.Point(118, 38)
        Me.txtLowAlarm.Name = "txtLowAlarm"
        Me.txtLowAlarm.Size = New System.Drawing.Size(100, 23)
        Me.txtLowAlarm.TabIndex = 6
        '
        'txtMode
        '
        Me.txtMode.Location = New System.Drawing.Point(118, 10)
        Me.txtMode.Name = "txtMode"
        Me.txtMode.Size = New System.Drawing.Size(100, 23)
        Me.txtMode.TabIndex = 5
        '
        'label12
        '
        Me.label12.Location = New System.Drawing.Point(12, 125)
        Me.label12.Name = "label12"
        Me.label12.Size = New System.Drawing.Size(66, 18)
        Me.label12.Text = "DO-3:"
        '
        'label11
        '
        Me.label11.Location = New System.Drawing.Point(12, 97)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(49, 18)
        Me.label11.Text = "DO-2:"
        '
        'label10
        '
        Me.label10.Location = New System.Drawing.Point(12, 69)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(117, 22)
        Me.label10.Text = "DO-1 high alarm:"
        '
        'label9
        '
        Me.label9.Location = New System.Drawing.Point(12, 41)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(107, 18)
        Me.label9.Text = "DO-0 low alarm:"
        '
        'label8
        '
        Me.label8.Location = New System.Drawing.Point(12, 13)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(87, 20)
        Me.label8.Text = "Alarm mode:"
        '
        'panelAO
        '
        Me.panelAO.BackColor = System.Drawing.Color.SkyBlue
        Me.panelAO.Controls.Add(Me.btnApplyOutput)
        Me.panelAO.Controls.Add(Me.txtOutputValue)
        Me.panelAO.Controls.Add(Me.label7)
        Me.panelAO.Controls.Add(Me.label6)
        Me.panelAO.Controls.Add(Me.label5)
        Me.panelAO.Controls.Add(Me.trackBar1)
        Me.panelAO.Location = New System.Drawing.Point(3, 166)
        Me.panelAO.Name = "panelAO"
        Me.panelAO.Size = New System.Drawing.Size(348, 115)
        '
        'btnApplyOutput
        '
        Me.btnApplyOutput.Location = New System.Drawing.Point(241, 82)
        Me.btnApplyOutput.Name = "btnApplyOutput"
        Me.btnApplyOutput.Size = New System.Drawing.Size(93, 23)
        Me.btnApplyOutput.TabIndex = 5
        Me.btnApplyOutput.Text = "Apply output"
        '
        'txtOutputValue
        '
        Me.txtOutputValue.Location = New System.Drawing.Point(113, 84)
        Me.txtOutputValue.Name = "txtOutputValue"
        Me.txtOutputValue.ReadOnly = True
        Me.txtOutputValue.Size = New System.Drawing.Size(100, 23)
        Me.txtOutputValue.TabIndex = 4
        '
        'label7
        '
        Me.label7.Location = New System.Drawing.Point(12, 87)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(107, 18)
        Me.label7.Text = "Value to output:"
        '
        'label6
        '
        Me.label6.Location = New System.Drawing.Point(168, 36)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(33, 29)
        Me.label6.Text = "10V"
        '
        'label5
        '
        Me.label5.Location = New System.Drawing.Point(12, 36)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(34, 19)
        Me.label5.Text = "0V"
        '
        'trackBar1
        '
        Me.trackBar1.LargeChange = 16
        Me.trackBar1.Location = New System.Drawing.Point(3, 3)
        Me.trackBar1.Maximum = 4095
        Me.trackBar1.Name = "trackBar1"
        Me.trackBar1.Size = New System.Drawing.Size(204, 30)
        Me.trackBar1.TabIndex = 0
        '
        'buttonStart
        '
        Me.buttonStart.Location = New System.Drawing.Point(274, 8)
        Me.buttonStart.Name = "buttonStart"
        Me.buttonStart.Size = New System.Drawing.Size(75, 23)
        Me.buttonStart.TabIndex = 30
        Me.buttonStart.Text = "Start"
        '
        'txtAOValue
        '
        Me.txtAOValue.Location = New System.Drawing.Point(128, 119)
        Me.txtAOValue.Name = "txtAOValue"
        Me.txtAOValue.Size = New System.Drawing.Size(138, 23)
        Me.txtAOValue.TabIndex = 29
        '
        'txtAIValue
        '
        Me.txtAIValue.Location = New System.Drawing.Point(128, 81)
        Me.txtAIValue.Name = "txtAIValue"
        Me.txtAIValue.Size = New System.Drawing.Size(138, 23)
        Me.txtAIValue.TabIndex = 28
        '
        'txtReadCount
        '
        Me.txtReadCount.Location = New System.Drawing.Point(128, 44)
        Me.txtReadCount.Name = "txtReadCount"
        Me.txtReadCount.ReadOnly = True
        Me.txtReadCount.Size = New System.Drawing.Size(138, 23)
        Me.txtReadCount.TabIndex = 27
        Me.txtReadCount.Text = "0"
        '
        'txtModule
        '
        Me.txtModule.Location = New System.Drawing.Point(128, 10)
        Me.txtModule.Name = "txtModule"
        Me.txtModule.Size = New System.Drawing.Size(138, 23)
        Me.txtModule.TabIndex = 26
        '
        'label4
        '
        Me.label4.Location = New System.Drawing.Point(3, 122)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(132, 20)
        Me.label4.Text = "Analog output value:"
        '
        'label3
        '
        Me.label3.Location = New System.Drawing.Point(3, 84)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(122, 20)
        Me.label3.Text = "Analog input value:"
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(3, 47)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(81, 20)
        Me.label2.Text = "Read count:"
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(3, 13)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(95, 20)
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
        Me.ClientSize = New System.Drawing.Size(354, 446)
        Me.Controls.Add(Me.panelAlarm)
        Me.Controls.Add(Me.panelAO)
        Me.Controls.Add(Me.buttonStart)
        Me.Controls.Add(Me.txtAOValue)
        Me.Controls.Add(Me.txtAIValue)
        Me.Controls.Add(Me.txtReadCount)
        Me.Controls.Add(Me.txtModule)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Text = "Adam4016 Sample Program (VB)"
        Me.panelAlarm.ResumeLayout(False)
        Me.panelAO.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents panelAlarm As System.Windows.Forms.Panel
    Private WithEvents buttonDO3 As System.Windows.Forms.Button
    Private WithEvents buttonDO2 As System.Windows.Forms.Button
    Private WithEvents buttonDO1 As System.Windows.Forms.Button
    Private WithEvents buttonDO0 As System.Windows.Forms.Button
    Private WithEvents txtDO3 As System.Windows.Forms.TextBox
    Private WithEvents txtDO2 As System.Windows.Forms.TextBox
    Private WithEvents txtHighAlarm As System.Windows.Forms.TextBox
    Private WithEvents txtLowAlarm As System.Windows.Forms.TextBox
    Private WithEvents txtMode As System.Windows.Forms.TextBox
    Private WithEvents label12 As System.Windows.Forms.Label
    Private WithEvents label11 As System.Windows.Forms.Label
    Private WithEvents label10 As System.Windows.Forms.Label
    Private WithEvents label9 As System.Windows.Forms.Label
    Private WithEvents label8 As System.Windows.Forms.Label
    Private WithEvents panelAO As System.Windows.Forms.Panel
    Private WithEvents btnApplyOutput As System.Windows.Forms.Button
    Private WithEvents txtOutputValue As System.Windows.Forms.TextBox
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents trackBar1 As System.Windows.Forms.TrackBar
    Private WithEvents buttonStart As System.Windows.Forms.Button
    Private WithEvents txtAOValue As System.Windows.Forms.TextBox
    Private WithEvents txtAIValue As System.Windows.Forms.TextBox
    Private WithEvents txtReadCount As System.Windows.Forms.TextBox
    Private WithEvents txtModule As System.Windows.Forms.TextBox
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
