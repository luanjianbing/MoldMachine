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
        Me.buttonDO1 = New System.Windows.Forms.Button
        Me.buttonDO0 = New System.Windows.Forms.Button
        Me.txtHighAlarm = New System.Windows.Forms.TextBox
        Me.txtLowAlarm = New System.Windows.Forms.TextBox
        Me.txtMode = New System.Windows.Forms.TextBox
        Me.label8 = New System.Windows.Forms.Label
        Me.label7 = New System.Windows.Forms.Label
        Me.label6 = New System.Windows.Forms.Label
        Me.panelEvent = New System.Windows.Forms.Panel
        Me.txtEvent = New System.Windows.Forms.TextBox
        Me.txtCounter = New System.Windows.Forms.TextBox
        Me.label5 = New System.Windows.Forms.Label
        Me.label4 = New System.Windows.Forms.Label
        Me.buttonStart = New System.Windows.Forms.Button
        Me.txtAI = New System.Windows.Forms.TextBox
        Me.txtReadCount = New System.Windows.Forms.TextBox
        Me.txtModule = New System.Windows.Forms.TextBox
        Me.label3 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer
        Me.panelAlarm.SuspendLayout()
        Me.panelEvent.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelAlarm
        '
        Me.panelAlarm.BackColor = System.Drawing.Color.SkyBlue
        Me.panelAlarm.Controls.Add(Me.buttonDO1)
        Me.panelAlarm.Controls.Add(Me.buttonDO0)
        Me.panelAlarm.Controls.Add(Me.txtHighAlarm)
        Me.panelAlarm.Controls.Add(Me.txtLowAlarm)
        Me.panelAlarm.Controls.Add(Me.txtMode)
        Me.panelAlarm.Controls.Add(Me.label8)
        Me.panelAlarm.Controls.Add(Me.label7)
        Me.panelAlarm.Controls.Add(Me.label6)
        Me.panelAlarm.Location = New System.Drawing.Point(3, 202)
        Me.panelAlarm.Name = "panelAlarm"
        Me.panelAlarm.Size = New System.Drawing.Size(348, 107)
        '
        'buttonDO1
        '
        Me.buttonDO1.Location = New System.Drawing.Point(248, 72)
        Me.buttonDO1.Name = "buttonDO1"
        Me.buttonDO1.Size = New System.Drawing.Size(89, 23)
        Me.buttonDO1.TabIndex = 7
        Me.buttonDO1.Text = "Output DO-1"
        '
        'buttonDO0
        '
        Me.buttonDO0.Location = New System.Drawing.Point(248, 40)
        Me.buttonDO0.Name = "buttonDO0"
        Me.buttonDO0.Size = New System.Drawing.Size(89, 23)
        Me.buttonDO0.TabIndex = 6
        Me.buttonDO0.Text = "Output DO-0"
        '
        'txtHighAlarm
        '
        Me.txtHighAlarm.Location = New System.Drawing.Point(102, 73)
        Me.txtHighAlarm.Name = "txtHighAlarm"
        Me.txtHighAlarm.Size = New System.Drawing.Size(128, 23)
        Me.txtHighAlarm.TabIndex = 5
        '
        'txtLowAlarm
        '
        Me.txtLowAlarm.Location = New System.Drawing.Point(102, 41)
        Me.txtLowAlarm.Name = "txtLowAlarm"
        Me.txtLowAlarm.Size = New System.Drawing.Size(128, 23)
        Me.txtLowAlarm.TabIndex = 4
        '
        'txtMode
        '
        Me.txtMode.Location = New System.Drawing.Point(102, 7)
        Me.txtMode.Name = "txtMode"
        Me.txtMode.Size = New System.Drawing.Size(128, 23)
        Me.txtMode.TabIndex = 3
        '
        'label8
        '
        Me.label8.Location = New System.Drawing.Point(3, 76)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(83, 19)
        Me.label8.Text = "High alarm:"
        '
        'label7
        '
        Me.label7.Location = New System.Drawing.Point(3, 44)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(83, 19)
        Me.label7.Text = "Low alarm:"
        '
        'label6
        '
        Me.label6.Location = New System.Drawing.Point(3, 10)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(93, 20)
        Me.label6.Text = "Alarm mode:"
        '
        'panelEvent
        '
        Me.panelEvent.BackColor = System.Drawing.Color.SkyBlue
        Me.panelEvent.Controls.Add(Me.txtEvent)
        Me.panelEvent.Controls.Add(Me.txtCounter)
        Me.panelEvent.Controls.Add(Me.label5)
        Me.panelEvent.Controls.Add(Me.label4)
        Me.panelEvent.Location = New System.Drawing.Point(3, 125)
        Me.panelEvent.Name = "panelEvent"
        Me.panelEvent.Size = New System.Drawing.Size(348, 71)
        '
        'txtEvent
        '
        Me.txtEvent.Location = New System.Drawing.Point(102, 38)
        Me.txtEvent.Name = "txtEvent"
        Me.txtEvent.Size = New System.Drawing.Size(128, 23)
        Me.txtEvent.TabIndex = 3
        '
        'txtCounter
        '
        Me.txtCounter.Location = New System.Drawing.Point(102, 8)
        Me.txtCounter.Name = "txtCounter"
        Me.txtCounter.Size = New System.Drawing.Size(128, 23)
        Me.txtCounter.TabIndex = 2
        '
        'label5
        '
        Me.label5.Location = New System.Drawing.Point(3, 41)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(94, 20)
        Me.label5.Text = "Event status:"
        '
        'label4
        '
        Me.label4.Location = New System.Drawing.Point(3, 11)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(94, 20)
        Me.label4.Text = "Event counter:"
        '
        'buttonStart
        '
        Me.buttonStart.Location = New System.Drawing.Point(276, 14)
        Me.buttonStart.Name = "buttonStart"
        Me.buttonStart.Size = New System.Drawing.Size(75, 23)
        Me.buttonStart.TabIndex = 24
        Me.buttonStart.Text = "Start"
        '
        'txtAI
        '
        Me.txtAI.Location = New System.Drawing.Point(122, 86)
        Me.txtAI.Name = "txtAI"
        Me.txtAI.Size = New System.Drawing.Size(126, 23)
        Me.txtAI.TabIndex = 23
        '
        'txtReadCount
        '
        Me.txtReadCount.Location = New System.Drawing.Point(122, 45)
        Me.txtReadCount.Name = "txtReadCount"
        Me.txtReadCount.ReadOnly = True
        Me.txtReadCount.Size = New System.Drawing.Size(126, 23)
        Me.txtReadCount.TabIndex = 22
        Me.txtReadCount.Text = "0"
        '
        'txtModule
        '
        Me.txtModule.Location = New System.Drawing.Point(122, 8)
        Me.txtModule.Name = "txtModule"
        Me.txtModule.Size = New System.Drawing.Size(126, 23)
        Me.txtModule.TabIndex = 21
        '
        'label3
        '
        Me.label3.Location = New System.Drawing.Point(3, 89)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(124, 20)
        Me.label3.Text = "Analog input value:"
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(3, 48)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(86, 20)
        Me.label2.Text = "Read count:"
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(3, 11)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(97, 20)
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
        Me.ClientSize = New System.Drawing.Size(355, 313)
        Me.Controls.Add(Me.panelAlarm)
        Me.Controls.Add(Me.panelEvent)
        Me.Controls.Add(Me.buttonStart)
        Me.Controls.Add(Me.txtAI)
        Me.Controls.Add(Me.txtReadCount)
        Me.Controls.Add(Me.txtModule)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Text = "Adam4011_12_13 Sample Program (VB)"
        Me.panelAlarm.ResumeLayout(False)
        Me.panelEvent.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents panelAlarm As System.Windows.Forms.Panel
    Private WithEvents buttonDO1 As System.Windows.Forms.Button
    Private WithEvents buttonDO0 As System.Windows.Forms.Button
    Private WithEvents txtHighAlarm As System.Windows.Forms.TextBox
    Private WithEvents txtLowAlarm As System.Windows.Forms.TextBox
    Private WithEvents txtMode As System.Windows.Forms.TextBox
    Private WithEvents label8 As System.Windows.Forms.Label
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents panelEvent As System.Windows.Forms.Panel
    Private WithEvents txtEvent As System.Windows.Forms.TextBox
    Private WithEvents txtCounter As System.Windows.Forms.TextBox
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents buttonStart As System.Windows.Forms.Button
    Private WithEvents txtAI As System.Windows.Forms.TextBox
    Private WithEvents txtReadCount As System.Windows.Forms.TextBox
    Private WithEvents txtModule As System.Windows.Forms.TextBox
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
