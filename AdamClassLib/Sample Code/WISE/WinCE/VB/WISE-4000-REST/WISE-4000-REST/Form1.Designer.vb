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
    private mainMenu1 As System.Windows.Forms.MainMenu

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.mainMenu1 = New System.Windows.Forms.MainMenu
        Me.comboBox1 = New System.Windows.Forms.ComboBox
        Me.label8 = New System.Windows.Forms.Label
        Me.label7 = New System.Windows.Forms.Label
        Me.btnSend = New System.Windows.Forms.Button
        Me.txtJSON = New System.Windows.Forms.TextBox
        Me.label6 = New System.Windows.Forms.Label
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.txtAcount = New System.Windows.Forms.TextBox
        Me.label5 = New System.Windows.Forms.Label
        Me.txtPatchData = New System.Windows.Forms.TextBox
        Me.label4 = New System.Windows.Forms.Label
        Me.txtURL = New System.Windows.Forms.TextBox
        Me.label3 = New System.Windows.Forms.Label
        Me.txtTarget = New System.Windows.Forms.TextBox
        Me.label2 = New System.Windows.Forms.Label
        Me.txtIPAddress = New System.Windows.Forms.TextBox
        Me.label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'comboBox1
        '
        Me.comboBox1.Items.Add("GET")
        Me.comboBox1.Items.Add("PATCH")
        Me.comboBox1.Location = New System.Drawing.Point(142, 148)
        Me.comboBox1.Name = "comboBox1"
        Me.comboBox1.Size = New System.Drawing.Size(121, 23)
        Me.comboBox1.TabIndex = 67
        '
        'label8
        '
        Me.label8.Location = New System.Drawing.Point(51, 148)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(85, 23)
        Me.label8.Text = "Method:"
        '
        'label7
        '
        Me.label7.Location = New System.Drawing.Point(52, 260)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(84, 20)
        Me.label7.Text = "JSON data:"
        '
        'btnSend
        '
        Me.btnSend.Location = New System.Drawing.Point(142, 231)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(445, 23)
        Me.btnSend.TabIndex = 66
        Me.btnSend.Text = "Send HTTP reqeust"
        '
        'txtJSON
        '
        Me.txtJSON.AcceptsReturn = True
        Me.txtJSON.Location = New System.Drawing.Point(142, 260)
        Me.txtJSON.Multiline = True
        Me.txtJSON.Name = "txtJSON"
        Me.txtJSON.ReadOnly = True
        Me.txtJSON.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtJSON.Size = New System.Drawing.Size(445, 158)
        Me.txtJSON.TabIndex = 65
        '
        'label6
        '
        Me.label6.Location = New System.Drawing.Point(51, 120)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(85, 23)
        Me.label6.Text = "Password:"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(142, 120)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(100, 23)
        Me.txtPassword.TabIndex = 64
        Me.txtPassword.Text = "00000000"
        '
        'txtAcount
        '
        Me.txtAcount.Location = New System.Drawing.Point(142, 92)
        Me.txtAcount.Name = "txtAcount"
        Me.txtAcount.Size = New System.Drawing.Size(100, 23)
        Me.txtAcount.TabIndex = 63
        Me.txtAcount.Text = "root"
        '
        'label5
        '
        Me.label5.Location = New System.Drawing.Point(51, 92)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(70, 23)
        Me.label5.Text = "Account:"
        '
        'txtPatchData
        '
        Me.txtPatchData.Location = New System.Drawing.Point(142, 174)
        Me.txtPatchData.Multiline = True
        Me.txtPatchData.Name = "txtPatchData"
        Me.txtPatchData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtPatchData.Size = New System.Drawing.Size(445, 51)
        Me.txtPatchData.TabIndex = 62
        '
        'label4
        '
        Me.label4.Location = New System.Drawing.Point(51, 174)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(85, 24)
        Me.label4.Text = "Patch Data:"
        '
        'txtURL
        '
        Me.txtURL.Location = New System.Drawing.Point(142, 64)
        Me.txtURL.Name = "txtURL"
        Me.txtURL.ReadOnly = True
        Me.txtURL.Size = New System.Drawing.Size(445, 23)
        Me.txtURL.TabIndex = 61
        '
        'label3
        '
        Me.label3.Location = New System.Drawing.Point(248, 39)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(8, 12)
        Me.label3.Text = "/"
        '
        'txtTarget
        '
        Me.txtTarget.Location = New System.Drawing.Point(265, 36)
        Me.txtTarget.Name = "txtTarget"
        Me.txtTarget.Size = New System.Drawing.Size(322, 23)
        Me.txtTarget.TabIndex = 60
        Me.txtTarget.Text = "profile"
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(51, 64)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(70, 23)
        Me.label2.Text = "URL:"
        '
        'txtIPAddress
        '
        Me.txtIPAddress.Location = New System.Drawing.Point(142, 36)
        Me.txtIPAddress.Name = "txtIPAddress"
        Me.txtIPAddress.Size = New System.Drawing.Size(100, 23)
        Me.txtIPAddress.TabIndex = 59
        Me.txtIPAddress.Text = "10.0.0.1"
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(51, 36)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(85, 15)
        Me.label1.Text = "IP address:"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(638, 455)
        Me.Controls.Add(Me.comboBox1)
        Me.Controls.Add(Me.label8)
        Me.Controls.Add(Me.label7)
        Me.Controls.Add(Me.btnSend)
        Me.Controls.Add(Me.txtJSON)
        Me.Controls.Add(Me.label6)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtAcount)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.txtPatchData)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.txtURL)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.txtTarget)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.txtIPAddress)
        Me.Controls.Add(Me.label1)
        Me.Menu = Me.mainMenu1
        Me.Name = "Form1"
        Me.Text = "WISE-4000 REST sample"
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents comboBox1 As System.Windows.Forms.ComboBox
    Private WithEvents label8 As System.Windows.Forms.Label
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents btnSend As System.Windows.Forms.Button
    Private WithEvents txtJSON As System.Windows.Forms.TextBox
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents txtPassword As System.Windows.Forms.TextBox
    Private WithEvents txtAcount As System.Windows.Forms.TextBox
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents txtPatchData As System.Windows.Forms.TextBox
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents txtURL As System.Windows.Forms.TextBox
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents txtTarget As System.Windows.Forms.TextBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents txtIPAddress As System.Windows.Forms.TextBox
    Private WithEvents label1 As System.Windows.Forms.Label

End Class
