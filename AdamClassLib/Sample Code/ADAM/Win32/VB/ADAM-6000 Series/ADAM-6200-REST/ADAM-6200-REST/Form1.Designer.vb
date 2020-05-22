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
        Me.dataGridView1 = New System.Windows.Forms.DataGridView
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
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dataGridView1
        '
        Me.dataGridView1.AllowUserToDeleteRows = False
        Me.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridView1.Location = New System.Drawing.Point(73, 320)
        Me.dataGridView1.Name = "dataGridView1"
        Me.dataGridView1.ReadOnly = True
        Me.dataGridView1.RowTemplate.Height = 24
        Me.dataGridView1.Size = New System.Drawing.Size(445, 136)
        Me.dataGridView1.TabIndex = 33
        '
        'btnConvert
        '
        Me.btnConvert.Location = New System.Drawing.Point(73, 291)
        Me.btnConvert.Name = "btnConvert"
        Me.btnConvert.Size = New System.Drawing.Size(445, 23)
        Me.btnConvert.TabIndex = 32
        Me.btnConvert.Text = "Convert Dataset"
        Me.btnConvert.UseVisualStyleBackColor = True
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(12, 184)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(55, 12)
        Me.label7.TabIndex = 31
        Me.label7.Text = "XML data:"
        '
        'btnSend
        '
        Me.btnSend.Location = New System.Drawing.Point(73, 152)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(445, 23)
        Me.btnSend.TabIndex = 30
        Me.btnSend.Text = "Send HTTP reqeust"
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'txtXML
        '
        Me.txtXML.AcceptsReturn = True
        Me.txtXML.Location = New System.Drawing.Point(73, 181)
        Me.txtXML.Multiline = True
        Me.txtXML.Name = "txtXML"
        Me.txtXML.ReadOnly = True
        Me.txtXML.Size = New System.Drawing.Size(445, 104)
        Me.txtXML.TabIndex = 29
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(12, 127)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(51, 12)
        Me.label6.TabIndex = 28
        Me.label6.Text = "Password:"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(73, 124)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(100, 22)
        Me.txtPassword.TabIndex = 27
        Me.txtPassword.Text = "00000000"
        '
        'txtAcount
        '
        Me.txtAcount.Location = New System.Drawing.Point(73, 96)
        Me.txtAcount.Name = "txtAcount"
        Me.txtAcount.Size = New System.Drawing.Size(100, 22)
        Me.txtAcount.TabIndex = 26
        Me.txtAcount.Text = "root"
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(12, 99)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(47, 12)
        Me.label5.TabIndex = 25
        Me.label5.Text = "Account:"
        '
        'txtPostData
        '
        Me.txtPostData.Location = New System.Drawing.Point(73, 68)
        Me.txtPostData.Name = "txtPostData"
        Me.txtPostData.Size = New System.Drawing.Size(445, 22)
        Me.txtPostData.TabIndex = 24
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(12, 71)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(57, 12)
        Me.label4.TabIndex = 23
        Me.label4.Text = "POST data:"
        '
        'txtURL
        '
        Me.txtURL.Location = New System.Drawing.Point(73, 40)
        Me.txtURL.Name = "txtURL"
        Me.txtURL.ReadOnly = True
        Me.txtURL.Size = New System.Drawing.Size(445, 22)
        Me.txtURL.TabIndex = 22
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(179, 15)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(8, 12)
        Me.label3.TabIndex = 21
        Me.label3.Text = "/"
        '
        'txtTarget
        '
        Me.txtTarget.Location = New System.Drawing.Point(196, 12)
        Me.txtTarget.Name = "txtTarget"
        Me.txtTarget.Size = New System.Drawing.Size(322, 22)
        Me.txtTarget.TabIndex = 20
        Me.txtTarget.Text = "digitalinput/all/value"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(12, 43)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(31, 12)
        Me.label2.TabIndex = 19
        Me.label2.Text = "URL:"
        '
        'txtIPAddress
        '
        Me.txtIPAddress.Location = New System.Drawing.Point(73, 12)
        Me.txtIPAddress.Name = "txtIPAddress"
        Me.txtIPAddress.Size = New System.Drawing.Size(100, 22)
        Me.txtIPAddress.TabIndex = 18
        Me.txtIPAddress.Text = "10.0.0.1"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(12, 15)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(55, 12)
        Me.label1.TabIndex = 17
        Me.label1.Text = "IP address:"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(530, 468)
        Me.Controls.Add(Me.dataGridView1)
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
        Me.Name = "Form1"
        Me.Text = "ADAM-6200 REST sample"
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents dataGridView1 As System.Windows.Forms.DataGridView
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
