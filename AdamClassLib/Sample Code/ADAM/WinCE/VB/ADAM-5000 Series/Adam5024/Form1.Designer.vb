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
        Me.label9 = New System.Windows.Forms.Label
        Me.label8 = New System.Windows.Forms.Label
        Me.label4 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.txtAO3 = New System.Windows.Forms.TextBox
        Me.panelAO = New System.Windows.Forms.Panel
        Me.cbxChannel = New System.Windows.Forms.ComboBox
        Me.label10 = New System.Windows.Forms.Label
        Me.btnApplyOutput = New System.Windows.Forms.Button
        Me.txtOutputValue = New System.Windows.Forms.TextBox
        Me.label7 = New System.Windows.Forms.Label
        Me.lblHigh = New System.Windows.Forms.Label
        Me.lblLow = New System.Windows.Forms.Label
        Me.trackBar1 = New System.Windows.Forms.TrackBar
        Me.buttonStart = New System.Windows.Forms.Button
        Me.txtAO2 = New System.Windows.Forms.TextBox
        Me.txtAO1 = New System.Windows.Forms.TextBox
        Me.txtAO0 = New System.Windows.Forms.TextBox
        Me.txtReadCount = New System.Windows.Forms.TextBox
        Me.txtModule = New System.Windows.Forms.TextBox
        Me.label2 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer
        Me.panelAO.SuspendLayout()
        Me.SuspendLayout()
        '
        'label9
        '
        Me.label9.Location = New System.Drawing.Point(3, 195)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(86, 20)
        Me.label9.Text = "AO-3 value:"
        '
        'label8
        '
        Me.label8.Location = New System.Drawing.Point(3, 159)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(86, 20)
        Me.label8.Text = "AO-2 value:"
        '
        'label4
        '
        Me.label4.Location = New System.Drawing.Point(3, 123)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(86, 20)
        Me.label4.Text = "AO-1 value:"
        '
        'label3
        '
        Me.label3.Location = New System.Drawing.Point(3, 87)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(86, 20)
        Me.label3.Text = "AO-0 value:"
        '
        'txtAO3
        '
        Me.txtAO3.Location = New System.Drawing.Point(91, 192)
        Me.txtAO3.Name = "txtAO3"
        Me.txtAO3.Size = New System.Drawing.Size(119, 23)
        Me.txtAO3.TabIndex = 75
        '
        'panelAO
        '
        Me.panelAO.BackColor = System.Drawing.Color.SkyBlue
        Me.panelAO.Controls.Add(Me.cbxChannel)
        Me.panelAO.Controls.Add(Me.label10)
        Me.panelAO.Controls.Add(Me.btnApplyOutput)
        Me.panelAO.Controls.Add(Me.txtOutputValue)
        Me.panelAO.Controls.Add(Me.label7)
        Me.panelAO.Controls.Add(Me.lblHigh)
        Me.panelAO.Controls.Add(Me.lblLow)
        Me.panelAO.Controls.Add(Me.trackBar1)
        Me.panelAO.Location = New System.Drawing.Point(2, 232)
        Me.panelAO.Name = "panelAO"
        Me.panelAO.Size = New System.Drawing.Size(313, 137)
        '
        'cbxChannel
        '
        Me.cbxChannel.Location = New System.Drawing.Point(106, 9)
        Me.cbxChannel.Name = "cbxChannel"
        Me.cbxChannel.Size = New System.Drawing.Size(97, 23)
        Me.cbxChannel.TabIndex = 7
        '
        'label10
        '
        Me.label10.Location = New System.Drawing.Point(12, 12)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(99, 20)
        Me.label10.Text = "Channel index:"
        '
        'btnApplyOutput
        '
        Me.btnApplyOutput.Location = New System.Drawing.Point(213, 107)
        Me.btnApplyOutput.Name = "btnApplyOutput"
        Me.btnApplyOutput.Size = New System.Drawing.Size(93, 23)
        Me.btnApplyOutput.TabIndex = 5
        Me.btnApplyOutput.Text = "Apply output"
        '
        'txtOutputValue
        '
        Me.txtOutputValue.Location = New System.Drawing.Point(108, 107)
        Me.txtOutputValue.Name = "txtOutputValue"
        Me.txtOutputValue.ReadOnly = True
        Me.txtOutputValue.Size = New System.Drawing.Size(99, 23)
        Me.txtOutputValue.TabIndex = 4
        '
        'label7
        '
        Me.label7.Location = New System.Drawing.Point(12, 110)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(110, 20)
        Me.label7.Text = "Value to output:"
        '
        'lblHigh
        '
        Me.lblHigh.Location = New System.Drawing.Point(169, 74)
        Me.lblHigh.Name = "lblHigh"
        Me.lblHigh.Size = New System.Drawing.Size(33, 22)
        Me.lblHigh.Text = "10V"
        '
        'lblLow
        '
        Me.lblLow.Location = New System.Drawing.Point(12, 74)
        Me.lblLow.Name = "lblLow"
        Me.lblLow.Size = New System.Drawing.Size(26, 22)
        Me.lblLow.Text = "0V"
        '
        'trackBar1
        '
        Me.trackBar1.LargeChange = 16
        Me.trackBar1.Location = New System.Drawing.Point(3, 41)
        Me.trackBar1.Maximum = 4095
        Me.trackBar1.Name = "trackBar1"
        Me.trackBar1.Size = New System.Drawing.Size(204, 45)
        Me.trackBar1.TabIndex = 0
        '
        'buttonStart
        '
        Me.buttonStart.Location = New System.Drawing.Point(235, 6)
        Me.buttonStart.Name = "buttonStart"
        Me.buttonStart.Size = New System.Drawing.Size(75, 23)
        Me.buttonStart.TabIndex = 74
        Me.buttonStart.Text = "Start"
        '
        'txtAO2
        '
        Me.txtAO2.Location = New System.Drawing.Point(91, 156)
        Me.txtAO2.Name = "txtAO2"
        Me.txtAO2.Size = New System.Drawing.Size(119, 23)
        Me.txtAO2.TabIndex = 73
        '
        'txtAO1
        '
        Me.txtAO1.Location = New System.Drawing.Point(91, 120)
        Me.txtAO1.Name = "txtAO1"
        Me.txtAO1.Size = New System.Drawing.Size(119, 23)
        Me.txtAO1.TabIndex = 72
        '
        'txtAO0
        '
        Me.txtAO0.Location = New System.Drawing.Point(91, 84)
        Me.txtAO0.Name = "txtAO0"
        Me.txtAO0.Size = New System.Drawing.Size(119, 23)
        Me.txtAO0.TabIndex = 71
        '
        'txtReadCount
        '
        Me.txtReadCount.Location = New System.Drawing.Point(91, 41)
        Me.txtReadCount.Name = "txtReadCount"
        Me.txtReadCount.ReadOnly = True
        Me.txtReadCount.Size = New System.Drawing.Size(119, 23)
        Me.txtReadCount.TabIndex = 70
        Me.txtReadCount.Text = "0"
        '
        'txtModule
        '
        Me.txtModule.Location = New System.Drawing.Point(91, 8)
        Me.txtModule.Name = "txtModule"
        Me.txtModule.Size = New System.Drawing.Size(119, 23)
        Me.txtModule.TabIndex = 69
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(3, 44)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(92, 20)
        Me.label2.Text = "Read count:"
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(3, 11)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(92, 18)
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
        Me.ClientSize = New System.Drawing.Size(318, 372)
        Me.Controls.Add(Me.label9)
        Me.Controls.Add(Me.label8)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.txtAO3)
        Me.Controls.Add(Me.panelAO)
        Me.Controls.Add(Me.buttonStart)
        Me.Controls.Add(Me.txtAO2)
        Me.Controls.Add(Me.txtAO1)
        Me.Controls.Add(Me.txtAO0)
        Me.Controls.Add(Me.txtReadCount)
        Me.Controls.Add(Me.txtModule)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.Name = "Form1"
        Me.Text = "Adam5024 sample program (VB)"
        Me.panelAO.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents label9 As System.Windows.Forms.Label
    Private WithEvents label8 As System.Windows.Forms.Label
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents txtAO3 As System.Windows.Forms.TextBox
    Private WithEvents panelAO As System.Windows.Forms.Panel
    Private WithEvents cbxChannel As System.Windows.Forms.ComboBox
    Private WithEvents label10 As System.Windows.Forms.Label
    Private WithEvents btnApplyOutput As System.Windows.Forms.Button
    Private WithEvents txtOutputValue As System.Windows.Forms.TextBox
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents lblHigh As System.Windows.Forms.Label
    Private WithEvents lblLow As System.Windows.Forms.Label
    Private WithEvents trackBar1 As System.Windows.Forms.TrackBar
    Private WithEvents buttonStart As System.Windows.Forms.Button
    Private WithEvents txtAO2 As System.Windows.Forms.TextBox
    Private WithEvents txtAO1 As System.Windows.Forms.TextBox
    Private WithEvents txtAO0 As System.Windows.Forms.TextBox
    Private WithEvents txtReadCount As System.Windows.Forms.TextBox
    Private WithEvents txtModule As System.Windows.Forms.TextBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
