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
        Me.panelDI = New System.Windows.Forms.Panel
        Me.txtDICh1 = New System.Windows.Forms.TextBox
        Me.txtDICh0 = New System.Windows.Forms.TextBox
        Me.btnCh1 = New System.Windows.Forms.Button
        Me.btnCh0 = New System.Windows.Forms.Button
        Me.label8 = New System.Windows.Forms.Label
        Me.txtCurrentValue = New System.Windows.Forms.TextBox
        Me.label4 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.txtCh5 = New System.Windows.Forms.TextBox
        Me.txtCh4 = New System.Windows.Forms.TextBox
        Me.txtCh3 = New System.Windows.Forms.TextBox
        Me.txtCh2 = New System.Windows.Forms.TextBox
        Me.txtCh1 = New System.Windows.Forms.TextBox
        Me.txtCh0 = New System.Windows.Forms.TextBox
        Me.chkboxCh5 = New System.Windows.Forms.CheckBox
        Me.chkboxCh4 = New System.Windows.Forms.CheckBox
        Me.chkboxCh3 = New System.Windows.Forms.CheckBox
        Me.chkboxCh2 = New System.Windows.Forms.CheckBox
        Me.chkboxCh1 = New System.Windows.Forms.CheckBox
        Me.chkboxCh0 = New System.Windows.Forms.CheckBox
        Me.panelDO = New System.Windows.Forms.Panel
        Me.txtDOCh1 = New System.Windows.Forms.TextBox
        Me.txtDOCh0 = New System.Windows.Forms.TextBox
        Me.btnDOCh1 = New System.Windows.Forms.Button
        Me.btnDOCh0 = New System.Windows.Forms.Button
        Me.panelOutput = New System.Windows.Forms.Panel
        Me.cbxAOChannel = New System.Windows.Forms.ComboBox
        Me.label10 = New System.Windows.Forms.Label
        Me.btnApplyOutput = New System.Windows.Forms.Button
        Me.txtOutputValue = New System.Windows.Forms.TextBox
        Me.label7 = New System.Windows.Forms.Label
        Me.lblHigh = New System.Windows.Forms.Label
        Me.lblLow = New System.Windows.Forms.Label
        Me.trackBar1 = New System.Windows.Forms.TrackBar
        Me.txtReadCount = New System.Windows.Forms.TextBox
        Me.txtModule = New System.Windows.Forms.TextBox
        Me.label2 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.buttonStart = New System.Windows.Forms.Button
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.panelDI.SuspendLayout()
        Me.panelDO.SuspendLayout()
        Me.panelOutput.SuspendLayout()
        CType(Me.trackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panelDI
        '
        Me.panelDI.BackColor = System.Drawing.Color.SkyBlue
        Me.panelDI.Controls.Add(Me.txtDICh1)
        Me.panelDI.Controls.Add(Me.txtDICh0)
        Me.panelDI.Controls.Add(Me.btnCh1)
        Me.panelDI.Controls.Add(Me.btnCh0)
        Me.panelDI.Location = New System.Drawing.Point(346, 267)
        Me.panelDI.Name = "panelDI"
        Me.panelDI.Size = New System.Drawing.Size(143, 115)
        Me.panelDI.TabIndex = 65
        '
        'txtDICh1
        '
        Me.txtDICh1.Location = New System.Drawing.Point(84, 63)
        Me.txtDICh1.Name = "txtDICh1"
        Me.txtDICh1.Size = New System.Drawing.Size(56, 22)
        Me.txtDICh1.TabIndex = 3
        '
        'txtDICh0
        '
        Me.txtDICh0.Location = New System.Drawing.Point(84, 14)
        Me.txtDICh0.Name = "txtDICh0"
        Me.txtDICh0.Size = New System.Drawing.Size(56, 22)
        Me.txtDICh0.TabIndex = 2
        '
        'btnCh1
        '
        Me.btnCh1.Location = New System.Drawing.Point(3, 62)
        Me.btnCh1.Name = "btnCh1"
        Me.btnCh1.Size = New System.Drawing.Size(75, 23)
        Me.btnCh1.TabIndex = 1
        Me.btnCh1.Text = "DI 1"
        Me.btnCh1.UseVisualStyleBackColor = True
        '
        'btnCh0
        '
        Me.btnCh0.Location = New System.Drawing.Point(3, 14)
        Me.btnCh0.Name = "btnCh0"
        Me.btnCh0.Size = New System.Drawing.Size(75, 23)
        Me.btnCh0.TabIndex = 0
        Me.btnCh0.Text = "DI 0"
        Me.btnCh0.UseVisualStyleBackColor = True
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Location = New System.Drawing.Point(12, 267)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(70, 12)
        Me.label8.TabIndex = 64
        Me.label8.Text = "Analog Iutput"
        '
        'txtCurrentValue
        '
        Me.txtCurrentValue.Location = New System.Drawing.Point(90, 108)
        Me.txtCurrentValue.Name = "txtCurrentValue"
        Me.txtCurrentValue.ReadOnly = True
        Me.txtCurrentValue.Size = New System.Drawing.Size(150, 22)
        Me.txtCurrentValue.TabIndex = 63
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(12, 111)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(72, 12)
        Me.label4.TabIndex = 62
        Me.label4.Text = "Current value:"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(12, 86)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(74, 12)
        Me.label3.TabIndex = 61
        Me.label3.Text = "Analog Output"
        '
        'txtCh5
        '
        Me.txtCh5.Location = New System.Drawing.Point(258, 357)
        Me.txtCh5.Name = "txtCh5"
        Me.txtCh5.ReadOnly = True
        Me.txtCh5.Size = New System.Drawing.Size(82, 22)
        Me.txtCh5.TabIndex = 60
        '
        'txtCh4
        '
        Me.txtCh4.Location = New System.Drawing.Point(258, 321)
        Me.txtCh4.Name = "txtCh4"
        Me.txtCh4.ReadOnly = True
        Me.txtCh4.Size = New System.Drawing.Size(82, 22)
        Me.txtCh4.TabIndex = 59
        '
        'txtCh3
        '
        Me.txtCh3.Location = New System.Drawing.Point(258, 286)
        Me.txtCh3.Name = "txtCh3"
        Me.txtCh3.ReadOnly = True
        Me.txtCh3.Size = New System.Drawing.Size(82, 22)
        Me.txtCh3.TabIndex = 58
        '
        'txtCh2
        '
        Me.txtCh2.Location = New System.Drawing.Point(92, 355)
        Me.txtCh2.Name = "txtCh2"
        Me.txtCh2.ReadOnly = True
        Me.txtCh2.Size = New System.Drawing.Size(82, 22)
        Me.txtCh2.TabIndex = 57
        '
        'txtCh1
        '
        Me.txtCh1.Location = New System.Drawing.Point(92, 322)
        Me.txtCh1.Name = "txtCh1"
        Me.txtCh1.ReadOnly = True
        Me.txtCh1.Size = New System.Drawing.Size(82, 22)
        Me.txtCh1.TabIndex = 56
        '
        'txtCh0
        '
        Me.txtCh0.Location = New System.Drawing.Point(92, 286)
        Me.txtCh0.Name = "txtCh0"
        Me.txtCh0.ReadOnly = True
        Me.txtCh0.Size = New System.Drawing.Size(82, 22)
        Me.txtCh0.TabIndex = 55
        '
        'chkboxCh5
        '
        Me.chkboxCh5.AutoSize = True
        Me.chkboxCh5.Enabled = False
        Me.chkboxCh5.Location = New System.Drawing.Point(180, 359)
        Me.chkboxCh5.Name = "chkboxCh5"
        Me.chkboxCh5.Size = New System.Drawing.Size(77, 16)
        Me.chkboxCh5.TabIndex = 54
        Me.chkboxCh5.Text = "AI-5 value:"
        Me.chkboxCh5.UseVisualStyleBackColor = True
        '
        'chkboxCh4
        '
        Me.chkboxCh4.AutoSize = True
        Me.chkboxCh4.Enabled = False
        Me.chkboxCh4.Location = New System.Drawing.Point(180, 323)
        Me.chkboxCh4.Name = "chkboxCh4"
        Me.chkboxCh4.Size = New System.Drawing.Size(77, 16)
        Me.chkboxCh4.TabIndex = 53
        Me.chkboxCh4.Text = "AI-4 value:"
        Me.chkboxCh4.UseVisualStyleBackColor = True
        '
        'chkboxCh3
        '
        Me.chkboxCh3.AutoSize = True
        Me.chkboxCh3.Enabled = False
        Me.chkboxCh3.Location = New System.Drawing.Point(180, 288)
        Me.chkboxCh3.Name = "chkboxCh3"
        Me.chkboxCh3.Size = New System.Drawing.Size(77, 16)
        Me.chkboxCh3.TabIndex = 52
        Me.chkboxCh3.Text = "AI-3 value:"
        Me.chkboxCh3.UseVisualStyleBackColor = True
        '
        'chkboxCh2
        '
        Me.chkboxCh2.AutoSize = True
        Me.chkboxCh2.Enabled = False
        Me.chkboxCh2.Location = New System.Drawing.Point(14, 357)
        Me.chkboxCh2.Name = "chkboxCh2"
        Me.chkboxCh2.Size = New System.Drawing.Size(77, 16)
        Me.chkboxCh2.TabIndex = 51
        Me.chkboxCh2.Text = "AI-2 value:"
        Me.chkboxCh2.UseVisualStyleBackColor = True
        '
        'chkboxCh1
        '
        Me.chkboxCh1.AutoSize = True
        Me.chkboxCh1.Enabled = False
        Me.chkboxCh1.Location = New System.Drawing.Point(14, 324)
        Me.chkboxCh1.Name = "chkboxCh1"
        Me.chkboxCh1.Size = New System.Drawing.Size(77, 16)
        Me.chkboxCh1.TabIndex = 50
        Me.chkboxCh1.Text = "AI-1 value:"
        Me.chkboxCh1.UseVisualStyleBackColor = True
        '
        'chkboxCh0
        '
        Me.chkboxCh0.AutoSize = True
        Me.chkboxCh0.Enabled = False
        Me.chkboxCh0.Location = New System.Drawing.Point(14, 288)
        Me.chkboxCh0.Name = "chkboxCh0"
        Me.chkboxCh0.Size = New System.Drawing.Size(77, 16)
        Me.chkboxCh0.TabIndex = 49
        Me.chkboxCh0.Text = "AI-0 value:"
        Me.chkboxCh0.UseVisualStyleBackColor = True
        '
        'panelDO
        '
        Me.panelDO.BackColor = System.Drawing.Color.SkyBlue
        Me.panelDO.Controls.Add(Me.txtDOCh1)
        Me.panelDO.Controls.Add(Me.txtDOCh0)
        Me.panelDO.Controls.Add(Me.btnDOCh1)
        Me.panelDO.Controls.Add(Me.btnDOCh0)
        Me.panelDO.Location = New System.Drawing.Point(346, 137)
        Me.panelDO.Name = "panelDO"
        Me.panelDO.Size = New System.Drawing.Size(143, 115)
        Me.panelDO.TabIndex = 48
        '
        'txtDOCh1
        '
        Me.txtDOCh1.Location = New System.Drawing.Point(84, 63)
        Me.txtDOCh1.Name = "txtDOCh1"
        Me.txtDOCh1.Size = New System.Drawing.Size(56, 22)
        Me.txtDOCh1.TabIndex = 3
        '
        'txtDOCh0
        '
        Me.txtDOCh0.Location = New System.Drawing.Point(84, 14)
        Me.txtDOCh0.Name = "txtDOCh0"
        Me.txtDOCh0.Size = New System.Drawing.Size(56, 22)
        Me.txtDOCh0.TabIndex = 2
        '
        'btnDOCh1
        '
        Me.btnDOCh1.Location = New System.Drawing.Point(3, 62)
        Me.btnDOCh1.Name = "btnDOCh1"
        Me.btnDOCh1.Size = New System.Drawing.Size(75, 23)
        Me.btnDOCh1.TabIndex = 1
        Me.btnDOCh1.Text = "DO 1"
        Me.btnDOCh1.UseVisualStyleBackColor = True
        '
        'btnDOCh0
        '
        Me.btnDOCh0.Location = New System.Drawing.Point(3, 14)
        Me.btnDOCh0.Name = "btnDOCh0"
        Me.btnDOCh0.Size = New System.Drawing.Size(75, 23)
        Me.btnDOCh0.TabIndex = 0
        Me.btnDOCh0.Text = "DO 0"
        Me.btnDOCh0.UseVisualStyleBackColor = True
        '
        'panelOutput
        '
        Me.panelOutput.BackColor = System.Drawing.Color.SkyBlue
        Me.panelOutput.Controls.Add(Me.cbxAOChannel)
        Me.panelOutput.Controls.Add(Me.label10)
        Me.panelOutput.Controls.Add(Me.btnApplyOutput)
        Me.panelOutput.Controls.Add(Me.txtOutputValue)
        Me.panelOutput.Controls.Add(Me.label7)
        Me.panelOutput.Controls.Add(Me.lblHigh)
        Me.panelOutput.Controls.Add(Me.lblLow)
        Me.panelOutput.Controls.Add(Me.trackBar1)
        Me.panelOutput.Location = New System.Drawing.Point(14, 137)
        Me.panelOutput.Name = "panelOutput"
        Me.panelOutput.Size = New System.Drawing.Size(326, 115)
        Me.panelOutput.TabIndex = 47
        '
        'cbxAOChannel
        '
        Me.cbxAOChannel.FormattingEnabled = True
        Me.cbxAOChannel.Location = New System.Drawing.Point(94, 59)
        Me.cbxAOChannel.Name = "cbxAOChannel"
        Me.cbxAOChannel.Size = New System.Drawing.Size(97, 20)
        Me.cbxAOChannel.TabIndex = 9
        '
        'label10
        '
        Me.label10.AutoSize = True
        Me.label10.Location = New System.Drawing.Point(12, 62)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(76, 12)
        Me.label10.TabIndex = 8
        Me.label10.Text = "Channel index:"
        '
        'btnApplyOutput
        '
        Me.btnApplyOutput.Location = New System.Drawing.Point(215, 83)
        Me.btnApplyOutput.Name = "btnApplyOutput"
        Me.btnApplyOutput.Size = New System.Drawing.Size(93, 23)
        Me.btnApplyOutput.TabIndex = 5
        Me.btnApplyOutput.Text = "Apply output"
        Me.btnApplyOutput.UseVisualStyleBackColor = True
        '
        'txtOutputValue
        '
        Me.txtOutputValue.Location = New System.Drawing.Point(94, 85)
        Me.txtOutputValue.Name = "txtOutputValue"
        Me.txtOutputValue.ReadOnly = True
        Me.txtOutputValue.Size = New System.Drawing.Size(97, 22)
        Me.txtOutputValue.TabIndex = 4
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(12, 88)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(80, 12)
        Me.label7.TabIndex = 3
        Me.label7.Text = "Value to output:"
        '
        'lblHigh
        '
        Me.lblHigh.AutoSize = True
        Me.lblHigh.Location = New System.Drawing.Point(174, 36)
        Me.lblHigh.Name = "lblHigh"
        Me.lblHigh.Size = New System.Drawing.Size(28, 12)
        Me.lblHigh.TabIndex = 2
        Me.lblHigh.Text = "High"
        '
        'lblLow
        '
        Me.lblLow.AutoSize = True
        Me.lblLow.Location = New System.Drawing.Point(12, 36)
        Me.lblLow.Name = "lblLow"
        Me.lblLow.Size = New System.Drawing.Size(26, 12)
        Me.lblLow.TabIndex = 1
        Me.lblLow.Text = "Low"
        '
        'trackBar1
        '
        Me.trackBar1.LargeChange = 16
        Me.trackBar1.Location = New System.Drawing.Point(3, 3)
        Me.trackBar1.Maximum = 4095
        Me.trackBar1.Name = "trackBar1"
        Me.trackBar1.Size = New System.Drawing.Size(204, 45)
        Me.trackBar1.TabIndex = 0
        '
        'txtReadCount
        '
        Me.txtReadCount.Location = New System.Drawing.Point(90, 40)
        Me.txtReadCount.Name = "txtReadCount"
        Me.txtReadCount.ReadOnly = True
        Me.txtReadCount.Size = New System.Drawing.Size(150, 22)
        Me.txtReadCount.TabIndex = 45
        Me.txtReadCount.Text = "0"
        '
        'txtModule
        '
        Me.txtModule.Location = New System.Drawing.Point(90, 6)
        Me.txtModule.Name = "txtModule"
        Me.txtModule.Size = New System.Drawing.Size(150, 22)
        Me.txtModule.TabIndex = 44
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(12, 43)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(61, 12)
        Me.label2.TabIndex = 43
        Me.label2.Text = "Read count:"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(12, 9)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(72, 12)
        Me.label1.TabIndex = 42
        Me.label1.Text = "Module name:"
        '
        'buttonStart
        '
        Me.buttonStart.Location = New System.Drawing.Point(414, 12)
        Me.buttonStart.Name = "buttonStart"
        Me.buttonStart.Size = New System.Drawing.Size(75, 23)
        Me.buttonStart.TabIndex = 46
        Me.buttonStart.Text = "Start"
        Me.buttonStart.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(503, 390)
        Me.Controls.Add(Me.panelDI)
        Me.Controls.Add(Me.label8)
        Me.Controls.Add(Me.txtCurrentValue)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.txtCh5)
        Me.Controls.Add(Me.txtCh4)
        Me.Controls.Add(Me.txtCh3)
        Me.Controls.Add(Me.txtCh2)
        Me.Controls.Add(Me.txtCh1)
        Me.Controls.Add(Me.txtCh0)
        Me.Controls.Add(Me.chkboxCh5)
        Me.Controls.Add(Me.chkboxCh4)
        Me.Controls.Add(Me.chkboxCh3)
        Me.Controls.Add(Me.chkboxCh2)
        Me.Controls.Add(Me.chkboxCh1)
        Me.Controls.Add(Me.chkboxCh0)
        Me.Controls.Add(Me.panelDO)
        Me.Controls.Add(Me.panelOutput)
        Me.Controls.Add(Me.txtReadCount)
        Me.Controls.Add(Me.txtModule)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.buttonStart)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Form1"
        Me.Text = "Adam6024 sample program (VB)"
        Me.panelDI.ResumeLayout(False)
        Me.panelDI.PerformLayout()
        Me.panelDO.ResumeLayout(False)
        Me.panelDO.PerformLayout()
        Me.panelOutput.ResumeLayout(False)
        Me.panelOutput.PerformLayout()
        CType(Me.trackBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents panelDI As System.Windows.Forms.Panel
    Private WithEvents txtDICh1 As System.Windows.Forms.TextBox
    Private WithEvents txtDICh0 As System.Windows.Forms.TextBox
    Private WithEvents btnCh1 As System.Windows.Forms.Button
    Private WithEvents btnCh0 As System.Windows.Forms.Button
    Private WithEvents label8 As System.Windows.Forms.Label
    Private WithEvents txtCurrentValue As System.Windows.Forms.TextBox
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents txtCh5 As System.Windows.Forms.TextBox
    Private WithEvents txtCh4 As System.Windows.Forms.TextBox
    Private WithEvents txtCh3 As System.Windows.Forms.TextBox
    Private WithEvents txtCh2 As System.Windows.Forms.TextBox
    Private WithEvents txtCh1 As System.Windows.Forms.TextBox
    Private WithEvents txtCh0 As System.Windows.Forms.TextBox
    Private WithEvents chkboxCh5 As System.Windows.Forms.CheckBox
    Private WithEvents chkboxCh4 As System.Windows.Forms.CheckBox
    Private WithEvents chkboxCh3 As System.Windows.Forms.CheckBox
    Private WithEvents chkboxCh2 As System.Windows.Forms.CheckBox
    Private WithEvents chkboxCh1 As System.Windows.Forms.CheckBox
    Private WithEvents chkboxCh0 As System.Windows.Forms.CheckBox
    Private WithEvents panelDO As System.Windows.Forms.Panel
    Private WithEvents txtDOCh1 As System.Windows.Forms.TextBox
    Private WithEvents txtDOCh0 As System.Windows.Forms.TextBox
    Private WithEvents btnDOCh1 As System.Windows.Forms.Button
    Private WithEvents btnDOCh0 As System.Windows.Forms.Button
    Private WithEvents panelOutput As System.Windows.Forms.Panel
    Private WithEvents cbxAOChannel As System.Windows.Forms.ComboBox
    Private WithEvents label10 As System.Windows.Forms.Label
    Private WithEvents btnApplyOutput As System.Windows.Forms.Button
    Private WithEvents txtOutputValue As System.Windows.Forms.TextBox
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents lblHigh As System.Windows.Forms.Label
    Private WithEvents lblLow As System.Windows.Forms.Label
    Private WithEvents trackBar1 As System.Windows.Forms.TrackBar
    Private WithEvents txtReadCount As System.Windows.Forms.TextBox
    Private WithEvents txtModule As System.Windows.Forms.TextBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents buttonStart As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
