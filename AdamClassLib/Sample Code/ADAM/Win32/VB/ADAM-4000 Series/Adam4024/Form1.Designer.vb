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
        Me.txtDI3 = New System.Windows.Forms.TextBox
        Me.txtDI2 = New System.Windows.Forms.TextBox
        Me.label12 = New System.Windows.Forms.Label
        Me.label13 = New System.Windows.Forms.Label
        Me.txtDI1 = New System.Windows.Forms.TextBox
        Me.txtDI0 = New System.Windows.Forms.TextBox
        Me.label10 = New System.Windows.Forms.Label
        Me.label11 = New System.Windows.Forms.Label
        Me.txtAO3 = New System.Windows.Forms.TextBox
        Me.txtAO2 = New System.Windows.Forms.TextBox
        Me.label8 = New System.Windows.Forms.Label
        Me.label9 = New System.Windows.Forms.Label
        Me.txtAO1 = New System.Windows.Forms.TextBox
        Me.txtAO0 = New System.Windows.Forms.TextBox
        Me.label4 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.panelAO = New System.Windows.Forms.Panel
        Me.label14 = New System.Windows.Forms.Label
        Me.cbxChannel = New System.Windows.Forms.ComboBox
        Me.btnApplyOutput = New System.Windows.Forms.Button
        Me.txtOutputValue = New System.Windows.Forms.TextBox
        Me.label7 = New System.Windows.Forms.Label
        Me.lblHigh = New System.Windows.Forms.Label
        Me.lblLow = New System.Windows.Forms.Label
        Me.trackBar1 = New System.Windows.Forms.TrackBar
        Me.buttonStart = New System.Windows.Forms.Button
        Me.txtReadCount = New System.Windows.Forms.TextBox
        Me.txtModule = New System.Windows.Forms.TextBox
        Me.label2 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.panelAO.SuspendLayout()
        CType(Me.trackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtDI3
        '
        Me.txtDI3.Location = New System.Drawing.Point(255, 200)
        Me.txtDI3.Name = "txtDI3"
        Me.txtDI3.Size = New System.Drawing.Size(105, 22)
        Me.txtDI3.TabIndex = 61
        '
        'txtDI2
        '
        Me.txtDI2.Location = New System.Drawing.Point(255, 163)
        Me.txtDI2.Name = "txtDI2"
        Me.txtDI2.Size = New System.Drawing.Size(105, 22)
        Me.txtDI2.TabIndex = 60
        '
        'label12
        '
        Me.label12.AutoSize = True
        Me.label12.Location = New System.Drawing.Point(191, 204)
        Me.label12.Name = "label12"
        Me.label12.Size = New System.Drawing.Size(58, 12)
        Me.label12.TabIndex = 59
        Me.label12.Text = "DI-3 value:"
        '
        'label13
        '
        Me.label13.AutoSize = True
        Me.label13.Location = New System.Drawing.Point(191, 166)
        Me.label13.Name = "label13"
        Me.label13.Size = New System.Drawing.Size(58, 12)
        Me.label13.TabIndex = 58
        Me.label13.Text = "DI-2 value:"
        '
        'txtDI1
        '
        Me.txtDI1.Location = New System.Drawing.Point(255, 123)
        Me.txtDI1.Name = "txtDI1"
        Me.txtDI1.Size = New System.Drawing.Size(105, 22)
        Me.txtDI1.TabIndex = 57
        '
        'txtDI0
        '
        Me.txtDI0.Location = New System.Drawing.Point(255, 86)
        Me.txtDI0.Name = "txtDI0"
        Me.txtDI0.Size = New System.Drawing.Size(105, 22)
        Me.txtDI0.TabIndex = 56
        '
        'label10
        '
        Me.label10.AutoSize = True
        Me.label10.Location = New System.Drawing.Point(191, 127)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(58, 12)
        Me.label10.TabIndex = 55
        Me.label10.Text = "DI-1 value:"
        '
        'label11
        '
        Me.label11.AutoSize = True
        Me.label11.Location = New System.Drawing.Point(191, 89)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(58, 12)
        Me.label11.TabIndex = 54
        Me.label11.Text = "DI-0 value:"
        '
        'txtAO3
        '
        Me.txtAO3.Location = New System.Drawing.Point(81, 197)
        Me.txtAO3.Name = "txtAO3"
        Me.txtAO3.Size = New System.Drawing.Size(105, 22)
        Me.txtAO3.TabIndex = 53
        '
        'txtAO2
        '
        Me.txtAO2.Location = New System.Drawing.Point(81, 160)
        Me.txtAO2.Name = "txtAO2"
        Me.txtAO2.Size = New System.Drawing.Size(105, 22)
        Me.txtAO2.TabIndex = 52
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Location = New System.Drawing.Point(13, 204)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(62, 12)
        Me.label8.TabIndex = 51
        Me.label8.Text = "AO-3 value:"
        '
        'label9
        '
        Me.label9.AutoSize = True
        Me.label9.Location = New System.Drawing.Point(13, 166)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(62, 12)
        Me.label9.TabIndex = 50
        Me.label9.Text = "AO-2 value:"
        '
        'txtAO1
        '
        Me.txtAO1.Location = New System.Drawing.Point(80, 123)
        Me.txtAO1.Name = "txtAO1"
        Me.txtAO1.Size = New System.Drawing.Size(105, 22)
        Me.txtAO1.TabIndex = 49
        '
        'txtAO0
        '
        Me.txtAO0.Location = New System.Drawing.Point(80, 86)
        Me.txtAO0.Name = "txtAO0"
        Me.txtAO0.Size = New System.Drawing.Size(105, 22)
        Me.txtAO0.TabIndex = 48
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(12, 127)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(62, 12)
        Me.label4.TabIndex = 47
        Me.label4.Text = "AO-1 value:"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(12, 89)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(62, 12)
        Me.label3.TabIndex = 46
        Me.label3.Text = "AO-0 value:"
        '
        'panelAO
        '
        Me.panelAO.BackColor = System.Drawing.Color.SkyBlue
        Me.panelAO.Controls.Add(Me.label14)
        Me.panelAO.Controls.Add(Me.cbxChannel)
        Me.panelAO.Controls.Add(Me.btnApplyOutput)
        Me.panelAO.Controls.Add(Me.txtOutputValue)
        Me.panelAO.Controls.Add(Me.label7)
        Me.panelAO.Controls.Add(Me.lblHigh)
        Me.panelAO.Controls.Add(Me.lblLow)
        Me.panelAO.Controls.Add(Me.trackBar1)
        Me.panelAO.Location = New System.Drawing.Point(15, 236)
        Me.panelAO.Name = "panelAO"
        Me.panelAO.Size = New System.Drawing.Size(345, 97)
        Me.panelAO.TabIndex = 45
        '
        'label14
        '
        Me.label14.AutoSize = True
        Me.label14.Location = New System.Drawing.Point(9, 10)
        Me.label14.Name = "label14"
        Me.label14.Size = New System.Drawing.Size(76, 12)
        Me.label14.TabIndex = 7
        Me.label14.Text = "Channel index:"
        '
        'cbxChannel
        '
        Me.cbxChannel.FormattingEnabled = True
        Me.cbxChannel.Location = New System.Drawing.Point(91, 7)
        Me.cbxChannel.Name = "cbxChannel"
        Me.cbxChannel.Size = New System.Drawing.Size(90, 20)
        Me.cbxChannel.TabIndex = 6
        '
        'btnApplyOutput
        '
        Me.btnApplyOutput.Location = New System.Drawing.Point(230, 10)
        Me.btnApplyOutput.Name = "btnApplyOutput"
        Me.btnApplyOutput.Size = New System.Drawing.Size(93, 23)
        Me.btnApplyOutput.TabIndex = 5
        Me.btnApplyOutput.Text = "Apply output"
        Me.btnApplyOutput.UseVisualStyleBackColor = True
        '
        'txtOutputValue
        '
        Me.txtOutputValue.Location = New System.Drawing.Point(230, 67)
        Me.txtOutputValue.Name = "txtOutputValue"
        Me.txtOutputValue.ReadOnly = True
        Me.txtOutputValue.Size = New System.Drawing.Size(100, 22)
        Me.txtOutputValue.TabIndex = 4
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(228, 52)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(80, 12)
        Me.label7.TabIndex = 3
        Me.label7.Text = "Value to output:"
        '
        'lblHigh
        '
        Me.lblHigh.AutoSize = True
        Me.lblHigh.Location = New System.Drawing.Point(174, 77)
        Me.lblHigh.Name = "lblHigh"
        Me.lblHigh.Size = New System.Drawing.Size(25, 12)
        Me.lblHigh.TabIndex = 2
        Me.lblHigh.Text = "10V"
        '
        'lblLow
        '
        Me.lblLow.AutoSize = True
        Me.lblLow.Location = New System.Drawing.Point(12, 77)
        Me.lblLow.Name = "lblLow"
        Me.lblLow.Size = New System.Drawing.Size(19, 12)
        Me.lblLow.TabIndex = 1
        Me.lblLow.Text = "0V"
        '
        'trackBar1
        '
        Me.trackBar1.LargeChange = 16
        Me.trackBar1.Location = New System.Drawing.Point(3, 44)
        Me.trackBar1.Maximum = 4095
        Me.trackBar1.Name = "trackBar1"
        Me.trackBar1.Size = New System.Drawing.Size(204, 45)
        Me.trackBar1.TabIndex = 0
        '
        'buttonStart
        '
        Me.buttonStart.Location = New System.Drawing.Point(285, 4)
        Me.buttonStart.Name = "buttonStart"
        Me.buttonStart.Size = New System.Drawing.Size(75, 23)
        Me.buttonStart.TabIndex = 44
        Me.buttonStart.Text = "Start"
        Me.buttonStart.UseVisualStyleBackColor = True
        '
        'txtReadCount
        '
        Me.txtReadCount.Location = New System.Drawing.Point(115, 40)
        Me.txtReadCount.Name = "txtReadCount"
        Me.txtReadCount.ReadOnly = True
        Me.txtReadCount.Size = New System.Drawing.Size(150, 22)
        Me.txtReadCount.TabIndex = 43
        Me.txtReadCount.Text = "0"
        '
        'txtModule
        '
        Me.txtModule.Location = New System.Drawing.Point(115, 6)
        Me.txtModule.Name = "txtModule"
        Me.txtModule.Size = New System.Drawing.Size(150, 22)
        Me.txtModule.TabIndex = 42
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(12, 43)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(61, 12)
        Me.label2.TabIndex = 41
        Me.label2.Text = "Read count:"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(12, 9)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(72, 12)
        Me.label1.TabIndex = 40
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
        Me.ClientSize = New System.Drawing.Size(377, 343)
        Me.Controls.Add(Me.txtDI3)
        Me.Controls.Add(Me.txtDI2)
        Me.Controls.Add(Me.label12)
        Me.Controls.Add(Me.label13)
        Me.Controls.Add(Me.txtDI1)
        Me.Controls.Add(Me.txtDI0)
        Me.Controls.Add(Me.label10)
        Me.Controls.Add(Me.label11)
        Me.Controls.Add(Me.txtAO3)
        Me.Controls.Add(Me.txtAO2)
        Me.Controls.Add(Me.label8)
        Me.Controls.Add(Me.label9)
        Me.Controls.Add(Me.txtAO1)
        Me.Controls.Add(Me.txtAO0)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.panelAO)
        Me.Controls.Add(Me.buttonStart)
        Me.Controls.Add(Me.txtReadCount)
        Me.Controls.Add(Me.txtModule)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Form1"
        Me.Text = "Adam4024 sample program (VB)"
        Me.panelAO.ResumeLayout(False)
        Me.panelAO.PerformLayout()
        CType(Me.trackBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents txtDI3 As System.Windows.Forms.TextBox
    Private WithEvents txtDI2 As System.Windows.Forms.TextBox
    Private WithEvents label12 As System.Windows.Forms.Label
    Private WithEvents label13 As System.Windows.Forms.Label
    Private WithEvents txtDI1 As System.Windows.Forms.TextBox
    Private WithEvents txtDI0 As System.Windows.Forms.TextBox
    Private WithEvents label10 As System.Windows.Forms.Label
    Private WithEvents label11 As System.Windows.Forms.Label
    Private WithEvents txtAO3 As System.Windows.Forms.TextBox
    Private WithEvents txtAO2 As System.Windows.Forms.TextBox
    Private WithEvents label8 As System.Windows.Forms.Label
    Private WithEvents label9 As System.Windows.Forms.Label
    Private WithEvents txtAO1 As System.Windows.Forms.TextBox
    Private WithEvents txtAO0 As System.Windows.Forms.TextBox
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents panelAO As System.Windows.Forms.Panel
    Private WithEvents label14 As System.Windows.Forms.Label
    Private WithEvents cbxChannel As System.Windows.Forms.ComboBox
    Private WithEvents btnApplyOutput As System.Windows.Forms.Button
    Private WithEvents txtOutputValue As System.Windows.Forms.TextBox
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents lblHigh As System.Windows.Forms.Label
    Private WithEvents lblLow As System.Windows.Forms.Label
    Private WithEvents trackBar1 As System.Windows.Forms.TrackBar
    Private WithEvents buttonStart As System.Windows.Forms.Button
    Private WithEvents txtReadCount As System.Windows.Forms.TextBox
    Private WithEvents txtModule As System.Windows.Forms.TextBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
