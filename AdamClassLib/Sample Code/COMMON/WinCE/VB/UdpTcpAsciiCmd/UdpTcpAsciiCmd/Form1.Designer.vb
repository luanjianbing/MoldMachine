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
        Me.txtTime = New System.Windows.Forms.TextBox
        Me.label5 = New System.Windows.Forms.Label
        Me.txtRespond = New System.Windows.Forms.TextBox
        Me.label4 = New System.Windows.Forms.Label
        Me.btnSend = New System.Windows.Forms.Button
        Me.txtSend = New System.Windows.Forms.TextBox
        Me.label3 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.btnConnect = New System.Windows.Forms.Button
        Me.txtIP = New System.Windows.Forms.TextBox
        Me.label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'txtTime
        '
        Me.txtTime.Location = New System.Drawing.Point(92, 141)
        Me.txtTime.Name = "txtTime"
        Me.txtTime.ReadOnly = True
        Me.txtTime.Size = New System.Drawing.Size(324, 23)
        Me.txtTime.TabIndex = 27
        '
        'label5
        '
        Me.label5.Location = New System.Drawing.Point(22, 144)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(43, 20)
        Me.label5.Text = "Time:"
        '
        'txtRespond
        '
        Me.txtRespond.Location = New System.Drawing.Point(92, 112)
        Me.txtRespond.Name = "txtRespond"
        Me.txtRespond.ReadOnly = True
        Me.txtRespond.Size = New System.Drawing.Size(324, 23)
        Me.txtRespond.TabIndex = 26
        '
        'label4
        '
        Me.label4.Location = New System.Drawing.Point(22, 115)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(67, 20)
        Me.label4.Text = "Respond:"
        '
        'btnSend
        '
        Me.btnSend.Location = New System.Drawing.Point(429, 83)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(66, 23)
        Me.btnSend.TabIndex = 25
        Me.btnSend.Text = "Send"
        '
        'txtSend
        '
        Me.txtSend.Location = New System.Drawing.Point(92, 83)
        Me.txtSend.Name = "txtSend"
        Me.txtSend.Size = New System.Drawing.Size(324, 23)
        Me.txtSend.TabIndex = 24
        '
        'label3
        '
        Me.label3.Location = New System.Drawing.Point(22, 86)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(40, 20)
        Me.label3.Text = "Send:"
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(8, 57)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(105, 20)
        Me.label2.Text = "ASCII Command"
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(208, 11)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(75, 23)
        Me.btnConnect.TabIndex = 23
        Me.btnConnect.Text = "Connect"
        '
        'txtIP
        '
        Me.txtIP.Location = New System.Drawing.Point(40, 11)
        Me.txtIP.Name = "txtIP"
        Me.txtIP.Size = New System.Drawing.Size(154, 23)
        Me.txtIP.TabIndex = 22
        Me.txtIP.Text = "10.0.0.1"
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(8, 11)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(26, 23)
        Me.label1.Text = "IP:"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(503, 174)
        Me.Controls.Add(Me.txtTime)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.txtRespond)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.btnSend)
        Me.Controls.Add(Me.txtSend)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.btnConnect)
        Me.Controls.Add(Me.txtIP)
        Me.Controls.Add(Me.label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Text = "UDP ASCII Command (VB)"
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents txtTime As System.Windows.Forms.TextBox
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents txtRespond As System.Windows.Forms.TextBox
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents btnSend As System.Windows.Forms.Button
    Private WithEvents txtSend As System.Windows.Forms.TextBox
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents btnConnect As System.Windows.Forms.Button
    Private WithEvents txtIP As System.Windows.Forms.TextBox
    Private WithEvents label1 As System.Windows.Forms.Label

End Class
