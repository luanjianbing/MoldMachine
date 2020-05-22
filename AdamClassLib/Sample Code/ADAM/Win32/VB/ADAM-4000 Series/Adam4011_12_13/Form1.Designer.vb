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
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
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
        Me.panelAlarm.Location = New System.Drawing.Point(12, 200)
        Me.panelAlarm.Name = "panelAlarm"
        Me.panelAlarm.Size = New System.Drawing.Size(348, 107)
        Me.panelAlarm.TabIndex = 17
        '
        'buttonDO1
        '
        Me.buttonDO1.Location = New System.Drawing.Point(228, 72)
        Me.buttonDO1.Name = "buttonDO1"
        Me.buttonDO1.Size = New System.Drawing.Size(89, 23)
        Me.buttonDO1.TabIndex = 7
        Me.buttonDO1.Text = "Output DO-1"
        Me.buttonDO1.UseVisualStyleBackColor = True
        '
        'buttonDO0
        '
        Me.buttonDO0.Location = New System.Drawing.Point(228, 40)
        Me.buttonDO0.Name = "buttonDO0"
        Me.buttonDO0.Size = New System.Drawing.Size(89, 23)
        Me.buttonDO0.TabIndex = 6
        Me.buttonDO0.Text = "Output DO-0"
        Me.buttonDO0.UseVisualStyleBackColor = True
        '
        'txtHighAlarm
        '
        Me.txtHighAlarm.Location = New System.Drawing.Point(82, 73)
        Me.txtHighAlarm.Name = "txtHighAlarm"
        Me.txtHighAlarm.Size = New System.Drawing.Size(128, 22)
        Me.txtHighAlarm.TabIndex = 5
        '
        'txtLowAlarm
        '
        Me.txtLowAlarm.Location = New System.Drawing.Point(82, 41)
        Me.txtLowAlarm.Name = "txtLowAlarm"
        Me.txtLowAlarm.Size = New System.Drawing.Size(128, 22)
        Me.txtLowAlarm.TabIndex = 4
        '
        'txtMode
        '
        Me.txtMode.Location = New System.Drawing.Point(82, 7)
        Me.txtMode.Name = "txtMode"
        Me.txtMode.Size = New System.Drawing.Size(128, 22)
        Me.txtMode.TabIndex = 3
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Location = New System.Drawing.Point(3, 76)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(60, 12)
        Me.label8.TabIndex = 2
        Me.label8.Text = "High alarm:"
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(3, 44)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(58, 12)
        Me.label7.TabIndex = 1
        Me.label7.Text = "Low alarm:"
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(3, 10)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(66, 12)
        Me.label6.TabIndex = 0
        Me.label6.Text = "Alarm mode:"
        '
        'panelEvent
        '
        Me.panelEvent.BackColor = System.Drawing.Color.SkyBlue
        Me.panelEvent.Controls.Add(Me.txtEvent)
        Me.panelEvent.Controls.Add(Me.txtCounter)
        Me.panelEvent.Controls.Add(Me.label5)
        Me.panelEvent.Controls.Add(Me.label4)
        Me.panelEvent.Location = New System.Drawing.Point(12, 123)
        Me.panelEvent.Name = "panelEvent"
        Me.panelEvent.Size = New System.Drawing.Size(348, 71)
        Me.panelEvent.TabIndex = 16
        '
        'txtEvent
        '
        Me.txtEvent.Location = New System.Drawing.Point(82, 38)
        Me.txtEvent.Name = "txtEvent"
        Me.txtEvent.Size = New System.Drawing.Size(128, 22)
        Me.txtEvent.TabIndex = 3
        '
        'txtCounter
        '
        Me.txtCounter.Location = New System.Drawing.Point(82, 8)
        Me.txtCounter.Name = "txtCounter"
        Me.txtCounter.Size = New System.Drawing.Size(128, 22)
        Me.txtCounter.TabIndex = 2
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(3, 41)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(63, 12)
        Me.label5.TabIndex = 1
        Me.label5.Text = "Event status:"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(3, 11)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(73, 12)
        Me.label4.TabIndex = 0
        Me.label4.Text = "Event counter:"
        '
        'buttonStart
        '
        Me.buttonStart.Location = New System.Drawing.Point(285, 12)
        Me.buttonStart.Name = "buttonStart"
        Me.buttonStart.Size = New System.Drawing.Size(75, 23)
        Me.buttonStart.TabIndex = 15
        Me.buttonStart.Text = "Start"
        Me.buttonStart.UseVisualStyleBackColor = True
        '
        'txtAI
        '
        Me.txtAI.Location = New System.Drawing.Point(122, 84)
        Me.txtAI.Name = "txtAI"
        Me.txtAI.Size = New System.Drawing.Size(126, 22)
        Me.txtAI.TabIndex = 14
        '
        'txtReadCount
        '
        Me.txtReadCount.Location = New System.Drawing.Point(122, 43)
        Me.txtReadCount.Name = "txtReadCount"
        Me.txtReadCount.ReadOnly = True
        Me.txtReadCount.Size = New System.Drawing.Size(126, 22)
        Me.txtReadCount.TabIndex = 13
        Me.txtReadCount.Text = "0"
        '
        'txtModule
        '
        Me.txtModule.Location = New System.Drawing.Point(122, 6)
        Me.txtModule.Name = "txtModule"
        Me.txtModule.Size = New System.Drawing.Size(126, 22)
        Me.txtModule.TabIndex = 12
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(12, 87)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(97, 12)
        Me.label3.TabIndex = 11
        Me.label3.Text = "Analog input value:"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(12, 46)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(61, 12)
        Me.label2.TabIndex = 10
        Me.label2.Text = "Read count:"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(12, 9)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(72, 12)
        Me.label1.TabIndex = 9
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
        Me.ClientSize = New System.Drawing.Size(373, 317)
        Me.Controls.Add(Me.panelAlarm)
        Me.Controls.Add(Me.panelEvent)
        Me.Controls.Add(Me.buttonStart)
        Me.Controls.Add(Me.txtAI)
        Me.Controls.Add(Me.txtReadCount)
        Me.Controls.Add(Me.txtModule)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Form1"
        Me.Text = "Adam4011_12_13 sample program (VB)"
        Me.panelAlarm.ResumeLayout(False)
        Me.panelAlarm.PerformLayout()
        Me.panelEvent.ResumeLayout(False)
        Me.panelEvent.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
