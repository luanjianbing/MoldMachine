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
        Me.btnSend.Location = New System.Drawing.Point(366, 185)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(75, 23)
        Me.btnSend.TabIndex = 62
        Me.btnSend.Text = "Send"
        '
        'label9
        '
        Me.label9.Location = New System.Drawing.Point(1, 217)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(113, 18)
        Me.label9.Text = "Receiving string"
        '
        'lsbxRecv
        '
        Me.lsbxRecv.Location = New System.Drawing.Point(3, 236)
        Me.lsbxRecv.Name = "lsbxRecv"
        Me.lsbxRecv.Size = New System.Drawing.Size(438, 82)
        Me.lsbxRecv.TabIndex = 61
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(366, 35)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 60
        Me.btnClose.Text = "Close"
        '
        'btnOpen
        '
        Me.btnOpen.Location = New System.Drawing.Point(366, 6)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(75, 23)
        Me.btnOpen.TabIndex = 59
        Me.btnOpen.Text = "Open"
        '
        'txtSend
        '
        Me.txtSend.Location = New System.Drawing.Point(3, 185)
        Me.txtSend.Name = "txtSend"
        Me.txtSend.Size = New System.Drawing.Size(341, 23)
        Me.txtSend.TabIndex = 58
        '
        'label8
        '
        Me.label8.Location = New System.Drawing.Point(1, 168)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(93, 24)
        Me.label8.Text = "Sending string"
        '
        'cbxWriteTimeout
        '
        Me.cbxWriteTimeout.Items.Add("100")
        Me.cbxWriteTimeout.Items.Add("500")
        Me.cbxWriteTimeout.Items.Add("1000")
        Me.cbxWriteTimeout.Items.Add("5000")
        Me.cbxWriteTimeout.Location = New System.Drawing.Point(264, 37)
        Me.cbxWriteTimeout.Name = "cbxWriteTimeout"
        Me.cbxWriteTimeout.Size = New System.Drawing.Size(97, 23)
        Me.cbxWriteTimeout.TabIndex = 57
        '
        'label7
        '
        Me.label7.Location = New System.Drawing.Point(175, 40)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(94, 16)
        Me.label7.Text = "Write timeout:"
        '
        'cbxReadTimeout
        '
        Me.cbxReadTimeout.Items.Add("100")
        Me.cbxReadTimeout.Items.Add("500")
        Me.cbxReadTimeout.Items.Add("1000")
        Me.cbxReadTimeout.Items.Add("5000")
        Me.cbxReadTimeout.Location = New System.Drawing.Point(263, 6)
        Me.cbxReadTimeout.Name = "cbxReadTimeout"
        Me.cbxReadTimeout.Size = New System.Drawing.Size(97, 23)
        Me.cbxReadTimeout.TabIndex = 56
        '
        'label6
        '
        Me.label6.Location = New System.Drawing.Point(174, 11)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(95, 18)
        Me.label6.Text = "Read timeout:"
        '
        'cbxStopbits
        '
        Me.cbxStopbits.Items.Add("1")
        Me.cbxStopbits.Items.Add("1.5")
        Me.cbxStopbits.Items.Add("2")
        Me.cbxStopbits.Location = New System.Drawing.Point(66, 124)
        Me.cbxStopbits.Name = "cbxStopbits"
        Me.cbxStopbits.Size = New System.Drawing.Size(97, 23)
        Me.cbxStopbits.TabIndex = 55
        '
        'label5
        '
        Me.label5.Location = New System.Drawing.Point(3, 127)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(70, 20)
        Me.label5.Text = "Stopbits:"
        '
        'cbxParity
        '
        Me.cbxParity.Items.Add("None")
        Me.cbxParity.Items.Add("Odd")
        Me.cbxParity.Items.Add("Even")
        Me.cbxParity.Items.Add("Mark")
        Me.cbxParity.Items.Add("Space")
        Me.cbxParity.Location = New System.Drawing.Point(66, 95)
        Me.cbxParity.Name = "cbxParity"
        Me.cbxParity.Size = New System.Drawing.Size(97, 23)
        Me.cbxParity.TabIndex = 54
        '
        'label4
        '
        Me.label4.Location = New System.Drawing.Point(3, 98)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(45, 20)
        Me.label4.Text = "Parity:"
        '
        'cbxDatabits
        '
        Me.cbxDatabits.Items.Add("5")
        Me.cbxDatabits.Items.Add("6")
        Me.cbxDatabits.Items.Add("7")
        Me.cbxDatabits.Items.Add("8")
        Me.cbxDatabits.Location = New System.Drawing.Point(66, 66)
        Me.cbxDatabits.Name = "cbxDatabits"
        Me.cbxDatabits.Size = New System.Drawing.Size(97, 23)
        Me.cbxDatabits.TabIndex = 53
        '
        'label3
        '
        Me.label3.Location = New System.Drawing.Point(3, 69)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(70, 20)
        Me.label3.Text = "Databits:"
        '
        'cbxBaudrate
        '
        Me.cbxBaudrate.Items.Add("9600")
        Me.cbxBaudrate.Items.Add("19200")
        Me.cbxBaudrate.Items.Add("38400")
        Me.cbxBaudrate.Items.Add("57600")
        Me.cbxBaudrate.Location = New System.Drawing.Point(66, 37)
        Me.cbxBaudrate.Name = "cbxBaudrate"
        Me.cbxBaudrate.Size = New System.Drawing.Size(97, 23)
        Me.cbxBaudrate.TabIndex = 52
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(3, 40)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(70, 16)
        Me.label2.Text = "Baudrate:"
        '
        'cbxCOM
        '
        Me.cbxCOM.Items.Add("1")
        Me.cbxCOM.Items.Add("2")
        Me.cbxCOM.Items.Add("3")
        Me.cbxCOM.Items.Add("4")
        Me.cbxCOM.Location = New System.Drawing.Point(66, 8)
        Me.cbxCOM.Name = "cbxCOM"
        Me.cbxCOM.Size = New System.Drawing.Size(97, 23)
        Me.cbxCOM.TabIndex = 51
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(3, 11)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(50, 16)
        Me.label1.Text = "COM:"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(445, 323)
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
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Text = "ComPortTest Sample Program (VB)"
        Me.ResumeLayout(False)

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
