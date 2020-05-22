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
        Me.btnSend = New System.Windows.Forms.Button
        Me.label9 = New System.Windows.Forms.Label
        Me.lsbxRecv = New System.Windows.Forms.ListBox
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnOpen = New System.Windows.Forms.Button
        Me.txtSend = New System.Windows.Forms.TextBox
        Me.label8 = New System.Windows.Forms.Label
        Me.cbxWriteTimeout = New System.Windows.Forms.ComboBox
        Me.label7 = New System.Windows.Forms.Label
        Me.cbxReadTimeout = New System.Windows.Forms.ComboBox
        Me.label6 = New System.Windows.Forms.Label
        Me.cbxStopbits = New System.Windows.Forms.ComboBox
        Me.label5 = New System.Windows.Forms.Label
        Me.cbxParity = New System.Windows.Forms.ComboBox
        Me.label4 = New System.Windows.Forms.Label
        Me.cbxDatabits = New System.Windows.Forms.ComboBox
        Me.label3 = New System.Windows.Forms.Label
        Me.cbxBaudrate = New System.Windows.Forms.ComboBox
        Me.label2 = New System.Windows.Forms.Label
        Me.cbxCOM = New System.Windows.Forms.ComboBox
        Me.label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btnSend
        '
        Me.btnSend.Location = New System.Drawing.Point(375, 179)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(75, 23)
        Me.btnSend.TabIndex = 41
        Me.btnSend.Text = "Send"
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'label9
        '
        Me.label9.AutoSize = True
        Me.label9.Location = New System.Drawing.Point(10, 215)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(81, 12)
        Me.label9.TabIndex = 40
        Me.label9.Text = "Receiving string"
        '
        'lsbxRecv
        '
        Me.lsbxRecv.FormattingEnabled = True
        Me.lsbxRecv.ItemHeight = 12
        Me.lsbxRecv.Location = New System.Drawing.Point(12, 230)
        Me.lsbxRecv.Name = "lsbxRecv"
        Me.lsbxRecv.Size = New System.Drawing.Size(438, 88)
        Me.lsbxRecv.TabIndex = 39
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(375, 31)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 38
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnOpen
        '
        Me.btnOpen.Location = New System.Drawing.Point(375, 2)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(75, 23)
        Me.btnOpen.TabIndex = 37
        Me.btnOpen.Text = "Open"
        Me.btnOpen.UseVisualStyleBackColor = True
        '
        'txtSend
        '
        Me.txtSend.Location = New System.Drawing.Point(12, 181)
        Me.txtSend.Name = "txtSend"
        Me.txtSend.Size = New System.Drawing.Size(341, 22)
        Me.txtSend.TabIndex = 36
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Location = New System.Drawing.Point(10, 166)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(72, 12)
        Me.label8.TabIndex = 35
        Me.label8.Text = "Sending string"
        '
        'cbxWriteTimeout
        '
        Me.cbxWriteTimeout.FormattingEnabled = True
        Me.cbxWriteTimeout.Items.AddRange(New Object() {"100", "500", "1000", "5000"})
        Me.cbxWriteTimeout.Location = New System.Drawing.Point(251, 35)
        Me.cbxWriteTimeout.Name = "cbxWriteTimeout"
        Me.cbxWriteTimeout.Size = New System.Drawing.Size(103, 20)
        Me.cbxWriteTimeout.TabIndex = 34
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(175, 38)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(72, 12)
        Me.label7.TabIndex = 33
        Me.label7.Text = "Write timeout:"
        '
        'cbxReadTimeout
        '
        Me.cbxReadTimeout.FormattingEnabled = True
        Me.cbxReadTimeout.Items.AddRange(New Object() {"100", "500", "1000", "5000"})
        Me.cbxReadTimeout.Location = New System.Drawing.Point(250, 4)
        Me.cbxReadTimeout.Name = "cbxReadTimeout"
        Me.cbxReadTimeout.Size = New System.Drawing.Size(103, 20)
        Me.cbxReadTimeout.TabIndex = 32
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(174, 9)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(70, 12)
        Me.label6.TabIndex = 31
        Me.label6.Text = "Read timeout:"
        '
        'cbxStopbits
        '
        Me.cbxStopbits.FormattingEnabled = True
        Me.cbxStopbits.Items.AddRange(New Object() {"1", "1.5", "2"})
        Me.cbxStopbits.Location = New System.Drawing.Point(66, 122)
        Me.cbxStopbits.Name = "cbxStopbits"
        Me.cbxStopbits.Size = New System.Drawing.Size(103, 20)
        Me.cbxStopbits.TabIndex = 30
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(12, 125)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(45, 12)
        Me.label5.TabIndex = 29
        Me.label5.Text = "Stopbits:"
        '
        'cbxParity
        '
        Me.cbxParity.FormattingEnabled = True
        Me.cbxParity.Items.AddRange(New Object() {"None", "Odd", "Even", "Mark", "Space"})
        Me.cbxParity.Location = New System.Drawing.Point(66, 93)
        Me.cbxParity.Name = "cbxParity"
        Me.cbxParity.Size = New System.Drawing.Size(103, 20)
        Me.cbxParity.TabIndex = 28
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(12, 96)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(35, 12)
        Me.label4.TabIndex = 27
        Me.label4.Text = "Parity:"
        '
        'cbxDatabits
        '
        Me.cbxDatabits.FormattingEnabled = True
        Me.cbxDatabits.Items.AddRange(New Object() {"5", "6", "7", "8"})
        Me.cbxDatabits.Location = New System.Drawing.Point(66, 64)
        Me.cbxDatabits.Name = "cbxDatabits"
        Me.cbxDatabits.Size = New System.Drawing.Size(103, 20)
        Me.cbxDatabits.TabIndex = 26
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(12, 67)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(45, 12)
        Me.label3.TabIndex = 25
        Me.label3.Text = "Databits:"
        '
        'cbxBaudrate
        '
        Me.cbxBaudrate.FormattingEnabled = True
        Me.cbxBaudrate.Items.AddRange(New Object() {"9600", "19200", "38400", "57600"})
        Me.cbxBaudrate.Location = New System.Drawing.Point(66, 35)
        Me.cbxBaudrate.Name = "cbxBaudrate"
        Me.cbxBaudrate.Size = New System.Drawing.Size(103, 20)
        Me.cbxBaudrate.TabIndex = 24
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(12, 38)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(50, 12)
        Me.label2.TabIndex = 23
        Me.label2.Text = "Baudrate:"
        '
        'cbxCOM
        '
        Me.cbxCOM.FormattingEnabled = True
        Me.cbxCOM.Items.AddRange(New Object() {"1", "2", "3", "4"})
        Me.cbxCOM.Location = New System.Drawing.Point(66, 6)
        Me.cbxCOM.Name = "cbxCOM"
        Me.cbxCOM.Size = New System.Drawing.Size(103, 20)
        Me.cbxCOM.TabIndex = 22
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(12, 9)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(34, 12)
        Me.label1.TabIndex = 21
        Me.label1.Text = "COM:"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(463, 325)
        Me.Controls.Add(Me.btnSend)
        Me.Controls.Add(Me.label9)
        Me.Controls.Add(Me.lsbxRecv)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnOpen)
        Me.Controls.Add(Me.txtSend)
        Me.Controls.Add(Me.label8)
        Me.Controls.Add(Me.cbxWriteTimeout)
        Me.Controls.Add(Me.label7)
        Me.Controls.Add(Me.cbxReadTimeout)
        Me.Controls.Add(Me.label6)
        Me.Controls.Add(Me.cbxStopbits)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.cbxParity)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.cbxDatabits)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.cbxBaudrate)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.cbxCOM)
        Me.Controls.Add(Me.label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Form1"
        Me.Text = "ComPortTest sample program (VB)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents btnSend As System.Windows.Forms.Button
    Private WithEvents label9 As System.Windows.Forms.Label
    Private WithEvents lsbxRecv As System.Windows.Forms.ListBox
    Private WithEvents btnClose As System.Windows.Forms.Button
    Private WithEvents btnOpen As System.Windows.Forms.Button
    Private WithEvents txtSend As System.Windows.Forms.TextBox
    Private WithEvents label8 As System.Windows.Forms.Label
    Private WithEvents cbxWriteTimeout As System.Windows.Forms.ComboBox
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents cbxReadTimeout As System.Windows.Forms.ComboBox
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents cbxStopbits As System.Windows.Forms.ComboBox
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents cbxParity As System.Windows.Forms.ComboBox
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents cbxDatabits As System.Windows.Forms.ComboBox
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents cbxBaudrate As System.Windows.Forms.ComboBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents cbxCOM As System.Windows.Forms.ComboBox
    Private WithEvents label1 As System.Windows.Forms.Label

End Class
