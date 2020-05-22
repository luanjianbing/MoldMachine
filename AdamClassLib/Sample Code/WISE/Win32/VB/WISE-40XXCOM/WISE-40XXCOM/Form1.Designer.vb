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
        Me.txtURL = New System.Windows.Forms.TextBox
        Me.label3 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.txtIPAddress = New System.Windows.Forms.TextBox
        Me.label1 = New System.Windows.Forms.Label
        Me.comboBoxUrl1 = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.comboBoxUrl2 = New System.Windows.Forms.ComboBox
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.ColumnChannel = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColumnValue = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColumnStatus = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColumnSlaveID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColumnSlaveAddress = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ColumnMappingAddress = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'comboBox1
        '
        Me.comboBox1.FormattingEnabled = True
        Me.comboBox1.Items.AddRange(New Object() {"GET"})
        Me.comboBox1.Location = New System.Drawing.Point(97, 151)
        Me.comboBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.comboBox1.Name = "comboBox1"
        Me.comboBox1.Size = New System.Drawing.Size(160, 23)
        Me.comboBox1.TabIndex = 33
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Location = New System.Drawing.Point(16, 155)
        Me.label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(55, 15)
        Me.label8.TabIndex = 32
        Me.label8.Text = "Method:"
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(16, 232)
        Me.label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(71, 15)
        Me.label7.TabIndex = 31
        Me.label7.Text = "JSON data:"
        '
        'btnSend
        '
        Me.btnSend.Location = New System.Drawing.Point(97, 182)
        Me.btnSend.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(593, 29)
        Me.btnSend.TabIndex = 30
        Me.btnSend.Text = "Send HTTP reqeust"
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'txtJSON
        '
        Me.txtJSON.AcceptsReturn = True
        Me.txtJSON.Location = New System.Drawing.Point(96, 232)
        Me.txtJSON.Margin = New System.Windows.Forms.Padding(4)
        Me.txtJSON.Multiline = True
        Me.txtJSON.Name = "txtJSON"
        Me.txtJSON.ReadOnly = True
        Me.txtJSON.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtJSON.Size = New System.Drawing.Size(592, 45)
        Me.txtJSON.TabIndex = 29
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(16, 120)
        Me.label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(64, 15)
        Me.label6.TabIndex = 28
        Me.label6.Text = "Password:"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(97, 116)
        Me.txtPassword.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(132, 25)
        Me.txtPassword.TabIndex = 27
        Me.txtPassword.Text = "00000000"
        '
        'txtAcount
        '
        Me.txtAcount.Location = New System.Drawing.Point(97, 81)
        Me.txtAcount.Margin = New System.Windows.Forms.Padding(4)
        Me.txtAcount.Name = "txtAcount"
        Me.txtAcount.Size = New System.Drawing.Size(132, 25)
        Me.txtAcount.TabIndex = 26
        Me.txtAcount.Text = "root"
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(16, 85)
        Me.label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(58, 15)
        Me.label5.TabIndex = 25
        Me.label5.Text = "Account:"
        '
        'txtURL
        '
        Me.txtURL.Location = New System.Drawing.Point(97, 46)
        Me.txtURL.Margin = New System.Windows.Forms.Padding(4)
        Me.txtURL.Name = "txtURL"
        Me.txtURL.ReadOnly = True
        Me.txtURL.Size = New System.Drawing.Size(592, 25)
        Me.txtURL.TabIndex = 22
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(239, 15)
        Me.label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(11, 15)
        Me.label3.TabIndex = 21
        Me.label3.Text = "/"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(16, 50)
        Me.label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(39, 15)
        Me.label2.TabIndex = 19
        Me.label2.Text = "URL:"
        '
        'txtIPAddress
        '
        Me.txtIPAddress.Location = New System.Drawing.Point(97, 11)
        Me.txtIPAddress.Margin = New System.Windows.Forms.Padding(4)
        Me.txtIPAddress.Name = "txtIPAddress"
        Me.txtIPAddress.Size = New System.Drawing.Size(132, 25)
        Me.txtIPAddress.TabIndex = 18
        Me.txtIPAddress.Text = "10.0.0.1"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(16, 15)
        Me.label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(69, 15)
        Me.label1.TabIndex = 17
        Me.label1.Text = "IP address:"
        '
        'comboBoxUrl1
        '
        Me.comboBoxUrl1.FormattingEnabled = True
        Me.comboBoxUrl1.Items.AddRange(New Object() {"expansion_bit", "expansion_word"})
        Me.comboBoxUrl1.Location = New System.Drawing.Point(258, 11)
        Me.comboBoxUrl1.Margin = New System.Windows.Forms.Padding(4)
        Me.comboBoxUrl1.Name = "comboBoxUrl1"
        Me.comboBoxUrl1.Size = New System.Drawing.Size(134, 23)
        Me.comboBoxUrl1.TabIndex = 19
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(400, 15)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(11, 15)
        Me.Label9.TabIndex = 35
        Me.Label9.Text = "/"
        '
        'comboBoxUrl2
        '
        Me.comboBoxUrl2.FormattingEnabled = True
        Me.comboBoxUrl2.Items.AddRange(New Object() {"com_1"})
        Me.comboBoxUrl2.Location = New System.Drawing.Point(419, 11)
        Me.comboBoxUrl2.Margin = New System.Windows.Forms.Padding(4)
        Me.comboBoxUrl2.Name = "comboBoxUrl2"
        Me.comboBoxUrl2.Size = New System.Drawing.Size(134, 23)
        Me.comboBoxUrl2.TabIndex = 20
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ColumnChannel, Me.ColumnValue, Me.ColumnStatus, Me.ColumnSlaveID, Me.ColumnSlaveAddress, Me.ColumnMappingAddress})
        Me.DataGridView1.Location = New System.Drawing.Point(97, 284)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 27
        Me.DataGridView1.Size = New System.Drawing.Size(634, 286)
        Me.DataGridView1.TabIndex = 36
        '
        'ColumnChannel
        '
        Me.ColumnChannel.HeaderText = "Channel"
        Me.ColumnChannel.Name = "ColumnChannel"
        Me.ColumnChannel.ReadOnly = True
        Me.ColumnChannel.Width = 80
        '
        'ColumnValue
        '
        Me.ColumnValue.HeaderText = "Value"
        Me.ColumnValue.Name = "ColumnValue"
        Me.ColumnValue.ReadOnly = True
        '
        'ColumnStatus
        '
        Me.ColumnStatus.HeaderText = "Status"
        Me.ColumnStatus.Name = "ColumnStatus"
        Me.ColumnStatus.ReadOnly = True
        '
        'ColumnSlaveID
        '
        Me.ColumnSlaveID.HeaderText = "Slave ID"
        Me.ColumnSlaveID.Name = "ColumnSlaveID"
        Me.ColumnSlaveID.ReadOnly = True
        Me.ColumnSlaveID.Width = 80
        '
        'ColumnSlaveAddress
        '
        Me.ColumnSlaveAddress.HeaderText = "Slave Address"
        Me.ColumnSlaveAddress.Name = "ColumnSlaveAddress"
        Me.ColumnSlaveAddress.ReadOnly = True
        '
        'ColumnMappingAddress
        '
        Me.ColumnMappingAddress.HeaderText = "Mapping Address"
        Me.ColumnMappingAddress.Name = "ColumnMappingAddress"
        Me.ColumnMappingAddress.ReadOnly = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(765, 582)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.comboBoxUrl2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.comboBoxUrl1)
        Me.Controls.Add(Me.comboBox1)
        Me.Controls.Add(Me.label8)
        Me.Controls.Add(Me.label7)
        Me.Controls.Add(Me.btnSend)
        Me.Controls.Add(Me.txtJSON)
        Me.Controls.Add(Me.label6)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtAcount)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.txtURL)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.txtIPAddress)
        Me.Controls.Add(Me.label1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Form1"
        Me.Text = "WISE-40XX COM sample"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Private WithEvents txtURL As System.Windows.Forms.TextBox
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents txtIPAddress As System.Windows.Forms.TextBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents comboBoxUrl1 As System.Windows.Forms.ComboBox
    Private WithEvents Label9 As System.Windows.Forms.Label
    Private WithEvents comboBoxUrl2 As System.Windows.Forms.ComboBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ColumnChannel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnSlaveID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnSlaveAddress As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ColumnMappingAddress As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
