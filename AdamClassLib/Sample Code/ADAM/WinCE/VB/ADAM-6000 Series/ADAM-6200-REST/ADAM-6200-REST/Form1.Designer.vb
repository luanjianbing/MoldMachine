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
        Me.listView1 = New System.Windows.Forms.ListView
        Me.btnConvert = New System.Windows.Forms.Button
        Me.label7 = New System.Windows.Forms.Label
        Me.btnSend = New System.Windows.Forms.Button
        Me.txtXML = New System.Windows.Forms.TextBox
        Me.label6 = New System.Windows.Forms.Label
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.txtAcount = New System.Windows.Forms.TextBox
        Me.label5 = New System.Windows.Forms.Label
        Me.txtPostData = New System.Windows.Forms.TextBox
        Me.label4 = New System.Windows.Forms.Label
        Me.txtURL = New System.Windows.Forms.TextBox
        Me.label3 = New System.Windows.Forms.Label
        Me.txtTarget = New System.Windows.Forms.TextBox
        Me.label2 = New System.Windows.Forms.Label
        Me.txtIPAddress = New System.Windows.Forms.TextBox
        Me.label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'listView1
        '
        Me.listView1.FullRowSelect = True
        Me.listView1.Location = New System.Drawing.Point(92, 371)
        Me.listView1.Name = "listView1"
        Me.listView1.Size = New System.Drawing.Size(444, 99)
        Me.listView1.TabIndex = 56
        Me.listView1.View = System.Windows.Forms.View.Details
        '
        'btnConvert
        '
        Me.btnConvert.Location = New System.Drawing.Point(91, 333)
        Me.btnConvert.Name = "btnConvert"
        Me.btnConvert.Size = New System.Drawing.Size(445, 23)
        Me.btnConvert.TabIndex = 55
        Me.btnConvert.Text = "Convert Dataset"
        '
        'label7
        '
        Me.label7.Location = New System.Drawing.Point(8, 216)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(77, 18)
        Me.label7.Text = "XML data:"
        '
        'btnSend
        '
        Me.btnSend.Location = New System.Drawing.Point(91, 180)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(445, 23)
        Me.btnSend.TabIndex = 54
        Me.btnSend.Text = "Send HTTP reqeust"
        '
        'txtXML
        '
        Me.txtXML.AcceptsReturn = True
        Me.txtXML.Location = New System.Drawing.Point(91, 216)
        Me.txtXML.Multiline = True
        Me.txtXML.Name = "txtXML"
        Me.txtXML.ReadOnly = True
        Me.txtXML.Size = New System.Drawing.Size(445, 104)
        Me.txtXML.TabIndex = 53
        '
        'label6
        '
        Me.label6.Location = New System.Drawing.Point(9, 146)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(77, 22)
        Me.label6.Text = "Password:"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(92, 146)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(100, 23)
        Me.txtPassword.TabIndex = 52
        Me.txtPassword.Text = "00000000"
        '
        'txtAcount
        '
        Me.txtAcount.Location = New System.Drawing.Point(92, 112)
        Me.txtAcount.Name = "txtAcount"
        Me.txtAcount.Size = New System.Drawing.Size(100, 23)
        Me.txtAcount.TabIndex = 51
        Me.txtAcount.Text = "root"
        '
        'label5
        '
        Me.label5.Location = New System.Drawing.Point(8, 112)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(64, 19)
        Me.label5.Text = "Account:"
        '
        'txtPostData
        '
        Me.txtPostData.Location = New System.Drawing.Point(92, 77)
        Me.txtPostData.Name = "txtPostData"
        Me.txtPostData.Size = New System.Drawing.Size(445, 23)
        Me.txtPostData.TabIndex = 50
        '
        'label4
        '
        Me.label4.Location = New System.Drawing.Point(8, 77)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(78, 19)
        Me.label4.Text = "POST data:"
        '
        'txtURL
        '
        Me.txtURL.BackColor = System.Drawing.SystemColors.Control
        Me.txtURL.Location = New System.Drawing.Point(91, 44)
        Me.txtURL.Name = "txtURL"
        Me.txtURL.ReadOnly = True
        Me.txtURL.Size = New System.Drawing.Size(445, 23)
        Me.txtURL.TabIndex = 49
        '
        'label3
        '
        Me.label3.Location = New System.Drawing.Point(197, 14)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(8, 12)
        Me.label3.Text = "/"
        '
        'txtTarget
        '
        Me.txtTarget.Location = New System.Drawing.Point(214, 11)
        Me.txtTarget.Name = "txtTarget"
        Me.txtTarget.Size = New System.Drawing.Size(322, 23)
        Me.txtTarget.TabIndex = 48
        Me.txtTarget.Text = "digitalinput/all/value"
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(8, 44)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(47, 18)
        Me.label2.Text = "URL:"
        '
        'txtIPAddress
        '
        Me.txtIPAddress.Location = New System.Drawing.Point(91, 11)
        Me.txtIPAddress.Name = "txtIPAddress"
        Me.txtIPAddress.Size = New System.Drawing.Size(100, 23)
        Me.txtIPAddress.TabIndex = 47
        Me.txtIPAddress.Text = "10.0.0.1"
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(8, 11)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(55, 19)
        Me.label1.Text = "IP address:"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(544, 481)
        Me.Controls.Add(Me.listView1)
        Me.Controls.Add(Me.btnConvert)
        Me.Controls.Add(Me.label7)
        Me.Controls.Add(Me.btnSend)
        Me.Controls.Add(Me.txtXML)
        Me.Controls.Add(Me.label6)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtAcount)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.txtPostData)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.txtURL)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.txtTarget)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.txtIPAddress)
        Me.Controls.Add(Me.label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents listView1 As System.Windows.Forms.ListView
    Private WithEvents btnConvert As System.Windows.Forms.Button
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents btnSend As System.Windows.Forms.Button
    Private WithEvents txtXML As System.Windows.Forms.TextBox
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents txtPassword As System.Windows.Forms.TextBox
    Private WithEvents txtAcount As System.Windows.Forms.TextBox
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents txtPostData As System.Windows.Forms.TextBox
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents txtURL As System.Windows.Forms.TextBox
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents txtTarget As System.Windows.Forms.TextBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents txtIPAddress As System.Windows.Forms.TextBox
    Private WithEvents label1 As System.Windows.Forms.Label

End Class
