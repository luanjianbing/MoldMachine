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
        Me.comboBox1.FormattingEnabled = True
        Me.comboBox1.Items.AddRange(New Object() {"GET", "PATCH"})
        Me.comboBox1.Location = New System.Drawing.Point(73, 121)
        Me.comboBox1.Name = "comboBox1"
        Me.comboBox1.Size = New System.Drawing.Size(121, 20)
        Me.comboBox1.TabIndex = 33
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Location = New System.Drawing.Point(12, 124)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(44, 12)
        Me.label8.TabIndex = 32
        Me.label8.Text = "Method:"
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(13, 236)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(56, 12)
        Me.label7.TabIndex = 31
        Me.label7.Text = "JSON data:"
        '
        'btnSend
        '
        Me.btnSend.Location = New System.Drawing.Point(73, 204)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(445, 23)
        Me.btnSend.TabIndex = 30
        Me.btnSend.Text = "Send HTTP reqeust"
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'txtJSON
        '
        Me.txtJSON.AcceptsReturn = True
        Me.txtJSON.Location = New System.Drawing.Point(73, 233)
        Me.txtJSON.Multiline = True
        Me.txtJSON.Name = "txtJSON"
        Me.txtJSON.ReadOnly = True
        Me.txtJSON.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtJSON.Size = New System.Drawing.Size(445, 158)
        Me.txtJSON.TabIndex = 29
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(12, 96)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(51, 12)
        Me.label6.TabIndex = 28
        Me.label6.Text = "Password:"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(73, 93)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(100, 22)
        Me.txtPassword.TabIndex = 27
        Me.txtPassword.Text = "00000000"
        '
        'txtAcount
        '
        Me.txtAcount.Location = New System.Drawing.Point(73, 65)
        Me.txtAcount.Name = "txtAcount"
        Me.txtAcount.Size = New System.Drawing.Size(100, 22)
        Me.txtAcount.TabIndex = 26
        Me.txtAcount.Text = "root"
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(12, 68)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(47, 12)
        Me.label5.TabIndex = 25
        Me.label5.Text = "Account:"
        '
        'txtPatchData
        '
        Me.txtPatchData.Location = New System.Drawing.Point(73, 147)
        Me.txtPatchData.Multiline = True
        Me.txtPatchData.Name = "txtPatchData"
        Me.txtPatchData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtPatchData.Size = New System.Drawing.Size(445, 51)
        Me.txtPatchData.TabIndex = 24
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(12, 150)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(57, 12)
        Me.label4.TabIndex = 23
        Me.label4.Text = "Patch Data:"
        '
        'txtURL
        '
        Me.txtURL.Location = New System.Drawing.Point(73, 37)
        Me.txtURL.Name = "txtURL"
        Me.txtURL.ReadOnly = True
        Me.txtURL.Size = New System.Drawing.Size(445, 22)
        Me.txtURL.TabIndex = 22
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(179, 12)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(8, 12)
        Me.label3.TabIndex = 21
        Me.label3.Text = "/"
        '
        'txtTarget
        '
        Me.txtTarget.Location = New System.Drawing.Point(196, 9)
        Me.txtTarget.Name = "txtTarget"
        Me.txtTarget.Size = New System.Drawing.Size(322, 22)
        Me.txtTarget.TabIndex = 20
        Me.txtTarget.Text = "profile"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(12, 40)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(31, 12)
        Me.label2.TabIndex = 19
        Me.label2.Text = "URL:"
        '
        'txtIPAddress
        '
        Me.txtIPAddress.Location = New System.Drawing.Point(73, 9)
        Me.txtIPAddress.Name = "txtIPAddress"
        Me.txtIPAddress.Size = New System.Drawing.Size(100, 22)
        Me.txtIPAddress.TabIndex = 18
        Me.txtIPAddress.Text = "10.0.0.1"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(12, 12)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(55, 12)
        Me.label1.TabIndex = 17
        Me.label1.Text = "IP address:"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(530, 401)
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
        Me.Name = "Form1"
        Me.Text = "ADAM-3600 REST sample"
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
