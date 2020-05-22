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
        Me.panelPID = New System.Windows.Forms.Panel
        Me.adamTrend1 = New Advantech.Graph.AdamTrend
        Me.label13 = New System.Windows.Forms.Label
        Me.label11 = New System.Windows.Forms.Label
        Me.panel4 = New System.Windows.Forms.Panel
        Me.panel3 = New System.Windows.Forms.Panel
        Me.panel2 = New System.Windows.Forms.Panel
        Me.label9 = New System.Windows.Forms.Label
        Me.txtGraphLow = New System.Windows.Forms.TextBox
        Me.txtGraphHigh = New System.Windows.Forms.TextBox
        Me.panel1 = New System.Windows.Forms.Panel
        Me.adamLightMV = New Advantech.Graph.AdamLight
        Me.adamLightPV = New Advantech.Graph.AdamLight
        Me.txtMVAlarm = New System.Windows.Forms.TextBox
        Me.label10 = New System.Windows.Forms.Label
        Me.txtPVAlarm = New System.Windows.Forms.TextBox
        Me.label12 = New System.Windows.Forms.Label
        Me.panelAO = New System.Windows.Forms.Panel
        Me.progressBarMV = New System.Windows.Forms.ProgressBar
        Me.label8 = New System.Windows.Forms.Label
        Me.txtMV = New System.Windows.Forms.TextBox
        Me.txtPV = New System.Windows.Forms.TextBox
        Me.label6 = New System.Windows.Forms.Label
        Me.progressBarPV = New System.Windows.Forms.ProgressBar
        Me.label5 = New System.Windows.Forms.Label
        Me.txtSV = New System.Windows.Forms.TextBox
        Me.label7 = New System.Windows.Forms.Label
        Me.lblSVHigh = New System.Windows.Forms.Label
        Me.lblSVLow = New System.Windows.Forms.Label
        Me.trackBarSV = New System.Windows.Forms.TrackBar
        Me.cbxControl = New System.Windows.Forms.ComboBox
        Me.label4 = New System.Windows.Forms.Label
        Me.cbxLoop = New System.Windows.Forms.ComboBox
        Me.label3 = New System.Windows.Forms.Label
        Me.buttonStart = New System.Windows.Forms.Button
        Me.txtReadCount = New System.Windows.Forms.TextBox
        Me.txtModule = New System.Windows.Forms.TextBox
        Me.label2 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer
        Me.panelPID.SuspendLayout()
        Me.panel1.SuspendLayout()
        Me.panelAO.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelPID
        '
        Me.panelPID.Controls.Add(Me.adamTrend1)
        Me.panelPID.Controls.Add(Me.label13)
        Me.panelPID.Controls.Add(Me.label11)
        Me.panelPID.Controls.Add(Me.panel4)
        Me.panelPID.Controls.Add(Me.panel3)
        Me.panelPID.Controls.Add(Me.panel2)
        Me.panelPID.Controls.Add(Me.label9)
        Me.panelPID.Controls.Add(Me.txtGraphLow)
        Me.panelPID.Controls.Add(Me.txtGraphHigh)
        Me.panelPID.Controls.Add(Me.panel1)
        Me.panelPID.Controls.Add(Me.panelAO)
        Me.panelPID.Controls.Add(Me.cbxControl)
        Me.panelPID.Controls.Add(Me.label4)
        Me.panelPID.Controls.Add(Me.cbxLoop)
        Me.panelPID.Controls.Add(Me.label3)
        Me.panelPID.Location = New System.Drawing.Point(18, 68)
        Me.panelPID.Name = "panelPID"
        Me.panelPID.Size = New System.Drawing.Size(604, 380)
        '
        'adamTrend1
        '
        Me.adamTrend1.DrawType = Advantech.Graph.DrawType.Analog
        Me.adamTrend1.GridBackColor = System.Drawing.Color.Black
        Me.adamTrend1.GridColor = System.Drawing.Color.DarkGreen
        Me.adamTrend1.GridLineSize = 10
        Me.adamTrend1.HorLabOrientation = Advantech.Graph.enumHorLabOrientation.Non
        Me.adamTrend1.HorLabType = Advantech.Graph.enumHorLabType.[Step]
        Me.adamTrend1.Location = New System.Drawing.Point(95, 162)
        Me.adamTrend1.MaximumY = 100.0!
        Me.adamTrend1.MinimumY = 0.0!
        Me.adamTrend1.Name = "adamTrend1"
        Me.adamTrend1.Pen0Color = System.Drawing.Color.Red
        Me.adamTrend1.Pen1Color = System.Drawing.Color.Orange
        Me.adamTrend1.Pen2Color = System.Drawing.Color.Yellow
        Me.adamTrend1.Pen3Color = System.Drawing.Color.Green
        Me.adamTrend1.Pen4Color = System.Drawing.Color.Blue
        Me.adamTrend1.Pen5Color = System.Drawing.Color.Plum
        Me.adamTrend1.Pen6Color = System.Drawing.Color.Gray
        Me.adamTrend1.Pen7Color = System.Drawing.Color.White
        Me.adamTrend1.Registration = ""
        Me.adamTrend1.Size = New System.Drawing.Size(501, 190)
        Me.adamTrend1.StepSize = 1
        Me.adamTrend1.TabIndex = 23
        Me.adamTrend1.Text = "adamTrend1"
        Me.adamTrend1.VerLabOrientation = Advantech.Graph.enumVerLabOrientation.Non
        Me.adamTrend1.VerLabUnit = ""
        '
        'label13
        '
        Me.label13.Location = New System.Drawing.Point(481, 357)
        Me.label13.Name = "label13"
        Me.label13.Size = New System.Drawing.Size(30, 18)
        Me.label13.Text = "MV"
        '
        'label11
        '
        Me.label11.Location = New System.Drawing.Point(294, 357)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(25, 18)
        Me.label11.Text = "PV"
        '
        'panel4
        '
        Me.panel4.BackColor = System.Drawing.Color.Red
        Me.panel4.Location = New System.Drawing.Point(511, 358)
        Me.panel4.Name = "panel4"
        Me.panel4.Size = New System.Drawing.Size(56, 16)
        '
        'panel3
        '
        Me.panel3.BackColor = System.Drawing.Color.Yellow
        Me.panel3.Location = New System.Drawing.Point(319, 358)
        Me.panel3.Name = "panel3"
        Me.panel3.Size = New System.Drawing.Size(56, 16)
        '
        'panel2
        '
        Me.panel2.BackColor = System.Drawing.Color.Blue
        Me.panel2.Location = New System.Drawing.Point(124, 358)
        Me.panel2.Name = "panel2"
        Me.panel2.Size = New System.Drawing.Size(56, 16)
        '
        'label9
        '
        Me.label9.Location = New System.Drawing.Point(99, 357)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(36, 18)
        Me.label9.Text = "SV"
        '
        'txtGraphLow
        '
        Me.txtGraphLow.Location = New System.Drawing.Point(5, 330)
        Me.txtGraphLow.Name = "txtGraphLow"
        Me.txtGraphLow.Size = New System.Drawing.Size(84, 23)
        Me.txtGraphLow.TabIndex = 15
        '
        'txtGraphHigh
        '
        Me.txtGraphHigh.Location = New System.Drawing.Point(5, 163)
        Me.txtGraphHigh.Name = "txtGraphHigh"
        Me.txtGraphHigh.Size = New System.Drawing.Size(84, 23)
        Me.txtGraphHigh.TabIndex = 14
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.Color.SkyBlue
        Me.panel1.Controls.Add(Me.adamLightMV)
        Me.panel1.Controls.Add(Me.adamLightPV)
        Me.panel1.Controls.Add(Me.txtMVAlarm)
        Me.panel1.Controls.Add(Me.label10)
        Me.panel1.Controls.Add(Me.txtPVAlarm)
        Me.panel1.Controls.Add(Me.label12)
        Me.panel1.Location = New System.Drawing.Point(466, 11)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(130, 146)
        '
        'adamLightMV
        '
        Me.adamLightMV.LightOffColor = System.Drawing.Color.LightGray
        Me.adamLightMV.LightOnColor = System.Drawing.Color.Lime
        Me.adamLightMV.Location = New System.Drawing.Point(9, 86)
        Me.adamLightMV.Name = "adamLightMV"
        Me.adamLightMV.Registration = ""
        Me.adamLightMV.Size = New System.Drawing.Size(26, 26)
        Me.adamLightMV.Style = Advantech.Graph.LightStyle.Round
        Me.adamLightMV.TabIndex = 13
        Me.adamLightMV.Value = False
        '
        'adamLightPV
        '
        Me.adamLightPV.LightOffColor = System.Drawing.Color.LightGray
        Me.adamLightPV.LightOnColor = System.Drawing.Color.Lime
        Me.adamLightPV.Location = New System.Drawing.Point(9, 31)
        Me.adamLightPV.Name = "adamLightPV"
        Me.adamLightPV.Registration = ""
        Me.adamLightPV.Size = New System.Drawing.Size(26, 25)
        Me.adamLightPV.Style = Advantech.Graph.LightStyle.Round
        Me.adamLightPV.TabIndex = 12
        Me.adamLightPV.Value = False
        '
        'txtMVAlarm
        '
        Me.txtMVAlarm.Location = New System.Drawing.Point(45, 89)
        Me.txtMVAlarm.Name = "txtMVAlarm"
        Me.txtMVAlarm.ReadOnly = True
        Me.txtMVAlarm.Size = New System.Drawing.Size(73, 23)
        Me.txtMVAlarm.TabIndex = 8
        '
        'label10
        '
        Me.label10.Location = New System.Drawing.Point(5, 70)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(67, 20)
        Me.label10.Text = "MV alarm:"
        '
        'txtPVAlarm
        '
        Me.txtPVAlarm.Location = New System.Drawing.Point(45, 31)
        Me.txtPVAlarm.Name = "txtPVAlarm"
        Me.txtPVAlarm.ReadOnly = True
        Me.txtPVAlarm.Size = New System.Drawing.Size(71, 23)
        Me.txtPVAlarm.TabIndex = 4
        '
        'label12
        '
        Me.label12.Location = New System.Drawing.Point(9, 13)
        Me.label12.Name = "label12"
        Me.label12.Size = New System.Drawing.Size(70, 20)
        Me.label12.Text = "PV alarm:"
        '
        'panelAO
        '
        Me.panelAO.BackColor = System.Drawing.Color.SkyBlue
        Me.panelAO.Controls.Add(Me.progressBarMV)
        Me.panelAO.Controls.Add(Me.label8)
        Me.panelAO.Controls.Add(Me.txtMV)
        Me.panelAO.Controls.Add(Me.txtPV)
        Me.panelAO.Controls.Add(Me.label6)
        Me.panelAO.Controls.Add(Me.progressBarPV)
        Me.panelAO.Controls.Add(Me.label5)
        Me.panelAO.Controls.Add(Me.txtSV)
        Me.panelAO.Controls.Add(Me.label7)
        Me.panelAO.Controls.Add(Me.lblSVHigh)
        Me.panelAO.Controls.Add(Me.lblSVLow)
        Me.panelAO.Controls.Add(Me.trackBarSV)
        Me.panelAO.Location = New System.Drawing.Point(132, 11)
        Me.panelAO.Name = "panelAO"
        Me.panelAO.Size = New System.Drawing.Size(328, 146)
        '
        'progressBarMV
        '
        Me.progressBarMV.Location = New System.Drawing.Point(39, 111)
        Me.progressBarMV.Name = "progressBarMV"
        Me.progressBarMV.Size = New System.Drawing.Size(148, 22)
        '
        'label8
        '
        Me.label8.Location = New System.Drawing.Point(287, 114)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(17, 23)
        Me.label8.Text = "%"
        '
        'txtMV
        '
        Me.txtMV.Location = New System.Drawing.Point(208, 111)
        Me.txtMV.Name = "txtMV"
        Me.txtMV.Size = New System.Drawing.Size(73, 23)
        Me.txtMV.TabIndex = 10
        '
        'txtPV
        '
        Me.txtPV.Location = New System.Drawing.Point(208, 64)
        Me.txtPV.Name = "txtPV"
        Me.txtPV.ReadOnly = True
        Me.txtPV.Size = New System.Drawing.Size(73, 23)
        Me.txtPV.TabIndex = 8
        '
        'label6
        '
        Me.label6.Location = New System.Drawing.Point(9, 114)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(39, 19)
        Me.label6.Text = "MV"
        '
        'progressBarPV
        '
        Me.progressBarPV.Location = New System.Drawing.Point(39, 64)
        Me.progressBarPV.Name = "progressBarPV"
        Me.progressBarPV.Size = New System.Drawing.Size(151, 22)
        '
        'label5
        '
        Me.label5.Location = New System.Drawing.Point(9, 67)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(24, 19)
        Me.label5.Text = "PV"
        '
        'txtSV
        '
        Me.txtSV.Location = New System.Drawing.Point(210, 10)
        Me.txtSV.Name = "txtSV"
        Me.txtSV.Size = New System.Drawing.Size(71, 23)
        Me.txtSV.TabIndex = 4
        '
        'label7
        '
        Me.label7.Location = New System.Drawing.Point(9, 13)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(23, 20)
        Me.label7.Text = "SV"
        '
        'lblSVHigh
        '
        Me.lblSVHigh.Location = New System.Drawing.Point(172, 36)
        Me.lblSVHigh.Name = "lblSVHigh"
        Me.lblSVHigh.Size = New System.Drawing.Size(32, 18)
        Me.lblSVHigh.Text = "100"
        '
        'lblSVLow
        '
        Me.lblSVLow.Location = New System.Drawing.Point(37, 36)
        Me.lblSVLow.Name = "lblSVLow"
        Me.lblSVLow.Size = New System.Drawing.Size(20, 18)
        Me.lblSVLow.Text = "0"
        '
        'trackBarSV
        '
        Me.trackBarSV.LargeChange = 2
        Me.trackBarSV.Location = New System.Drawing.Point(28, 3)
        Me.trackBarSV.Maximum = 20
        Me.trackBarSV.Name = "trackBarSV"
        Me.trackBarSV.Size = New System.Drawing.Size(176, 45)
        Me.trackBarSV.TabIndex = 7
        '
        'cbxControl
        '
        Me.cbxControl.Items.Add("Free")
        Me.cbxControl.Items.Add("Auto")
        Me.cbxControl.Items.Add("Manual")
        Me.cbxControl.Location = New System.Drawing.Point(5, 78)
        Me.cbxControl.Name = "cbxControl"
        Me.cbxControl.Size = New System.Drawing.Size(121, 23)
        Me.cbxControl.TabIndex = 3
        '
        'label4
        '
        Me.label4.Location = New System.Drawing.Point(3, 62)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(96, 27)
        Me.label4.Text = "Control mode:"
        '
        'cbxLoop
        '
        Me.cbxLoop.Items.Add("0")
        Me.cbxLoop.Items.Add("1")
        Me.cbxLoop.Location = New System.Drawing.Point(5, 26)
        Me.cbxLoop.Name = "cbxLoop"
        Me.cbxLoop.Size = New System.Drawing.Size(121, 23)
        Me.cbxLoop.TabIndex = 1
        '
        'label3
        '
        Me.label3.Location = New System.Drawing.Point(3, 10)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(47, 25)
        Me.label3.Text = "Loop:"
        '
        'buttonStart
        '
        Me.buttonStart.Location = New System.Drawing.Point(547, 6)
        Me.buttonStart.Name = "buttonStart"
        Me.buttonStart.Size = New System.Drawing.Size(75, 23)
        Me.buttonStart.TabIndex = 38
        Me.buttonStart.Text = "Start"
        '
        'txtReadCount
        '
        Me.txtReadCount.Location = New System.Drawing.Point(119, 40)
        Me.txtReadCount.Name = "txtReadCount"
        Me.txtReadCount.ReadOnly = True
        Me.txtReadCount.Size = New System.Drawing.Size(150, 23)
        Me.txtReadCount.TabIndex = 39
        Me.txtReadCount.Text = "0"
        '
        'txtModule
        '
        Me.txtModule.Location = New System.Drawing.Point(119, 6)
        Me.txtModule.Name = "txtModule"
        Me.txtModule.Size = New System.Drawing.Size(150, 23)
        Me.txtModule.TabIndex = 40
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(16, 43)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(78, 20)
        Me.label2.Text = "Read count:"
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(16, 9)
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
        Me.ClientSize = New System.Drawing.Size(638, 455)
        Me.Controls.Add(Me.panelPID)
        Me.Controls.Add(Me.buttonStart)
        Me.Controls.Add(Me.txtReadCount)
        Me.Controls.Add(Me.txtModule)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Text = "Adam6022 Sample Program (VB)"
        Me.panelPID.ResumeLayout(False)
        Me.panel1.ResumeLayout(False)
        Me.panelAO.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents panelPID As System.Windows.Forms.Panel
    Private WithEvents label13 As System.Windows.Forms.Label
    Private WithEvents label11 As System.Windows.Forms.Label
    Private WithEvents panel4 As System.Windows.Forms.Panel
    Private WithEvents panel3 As System.Windows.Forms.Panel
    Private WithEvents panel2 As System.Windows.Forms.Panel
    Private WithEvents label9 As System.Windows.Forms.Label
    Private WithEvents txtGraphLow As System.Windows.Forms.TextBox
    Private WithEvents txtGraphHigh As System.Windows.Forms.TextBox
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents txtMVAlarm As System.Windows.Forms.TextBox
    Private WithEvents label10 As System.Windows.Forms.Label
    Private WithEvents txtPVAlarm As System.Windows.Forms.TextBox
    Private WithEvents label12 As System.Windows.Forms.Label
    Private WithEvents panelAO As System.Windows.Forms.Panel
    Private WithEvents progressBarMV As System.Windows.Forms.ProgressBar
    Private WithEvents label8 As System.Windows.Forms.Label
    Private WithEvents txtMV As System.Windows.Forms.TextBox
    Private WithEvents txtPV As System.Windows.Forms.TextBox
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents progressBarPV As System.Windows.Forms.ProgressBar
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents txtSV As System.Windows.Forms.TextBox
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents lblSVHigh As System.Windows.Forms.Label
    Private WithEvents lblSVLow As System.Windows.Forms.Label
    Private WithEvents trackBarSV As System.Windows.Forms.TrackBar
    Private WithEvents cbxControl As System.Windows.Forms.ComboBox
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents cbxLoop As System.Windows.Forms.ComboBox
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents buttonStart As System.Windows.Forms.Button
    Private WithEvents txtReadCount As System.Windows.Forms.TextBox
    Private WithEvents txtModule As System.Windows.Forms.TextBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents adamTrend1 As Advantech.Graph.AdamTrend
    Private WithEvents adamLightMV As Advantech.Graph.AdamLight
    Private WithEvents adamLightPV As Advantech.Graph.AdamLight
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
