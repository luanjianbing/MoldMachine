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
        Me.txtTime = New System.Windows.Forms.TextBox
        Me.txtRespond = New System.Windows.Forms.TextBox
        Me.txtSend = New System.Windows.Forms.TextBox
        Me.label3 = New System.Windows.Forms.Label
        Me.label4 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.label2 = New System.Windows.Forms.Label
        Me.btnConnect = New System.Windows.Forms.Button
        Me.txtIP = New System.Windows.Forms.TextBox
        Me.groupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSend
        '
        Me.btnSend.Location = New System.Drawing.Point(404, 21)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(75, 23)
        Me.btnSend.TabIndex = 6
        Me.btnSend.Text = "Send"
        Me.btnSend.UseVisualStyleBackColor = True
        '
        'txtTime
        '
        Me.txtTime.Location = New System.Drawing.Point(64, 87)
        Me.txtTime.Name = "txtTime"
        Me.txtTime.ReadOnly = True
        Me.txtTime.Size = New System.Drawing.Size(334, 22)
        Me.txtTime.TabIndex = 5
        '
        'txtRespond
        '
        Me.txtRespond.Location = New System.Drawing.Point(64, 54)
        Me.txtRespond.Name = "txtRespond"
        Me.txtRespond.ReadOnly = True
        Me.txtRespond.Size = New System.Drawing.Size(334, 22)
        Me.txtRespond.TabIndex = 4
        '
        'txtSend
        '
        Me.txtSend.Location = New System.Drawing.Point(64, 23)
        Me.txtSend.Name = "txtSend"
        Me.txtSend.Size = New System.Drawing.Size(334, 22)
        Me.txtSend.TabIndex = 3
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(15, 57)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(49, 12)
        Me.label3.TabIndex = 1
        Me.label3.Text = "Respond:"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(15, 90)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(32, 12)
        Me.label4.TabIndex = 2
        Me.label4.Text = "Time:"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(6, 9)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(18, 12)
        Me.label1.TabIndex = 4
        Me.label1.Text = "IP:"
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.btnSend)
        Me.groupBox1.Controls.Add(Me.txtTime)
        Me.groupBox1.Controls.Add(Me.txtRespond)
        Me.groupBox1.Controls.Add(Me.txtSend)
        Me.groupBox1.Controls.Add(Me.label4)
        Me.groupBox1.Controls.Add(Me.label3)
        Me.groupBox1.Controls.Add(Me.label2)
        Me.groupBox1.Location = New System.Drawing.Point(2, 38)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(485, 117)
        Me.groupBox1.TabIndex = 7
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "ASCII Command"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(15, 26)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(31, 12)
        Me.label2.TabIndex = 0
        Me.label2.Text = "Send:"
        '
        'btnConnect
        '
        Me.btnConnect.Location = New System.Drawing.Point(208, 6)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(75, 23)
        Me.btnConnect.TabIndex = 6
        Me.btnConnect.Text = "Connect"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'txtIP
        '
        Me.txtIP.Location = New System.Drawing.Point(30, 6)
        Me.txtIP.Name = "txtIP"
        Me.txtIP.Size = New System.Drawing.Size(154, 22)
        Me.txtIP.TabIndex = 5
        Me.txtIP.Text = "10.0.0.1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(489, 157)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.groupBox1)
        Me.Controls.Add(Me.btnConnect)
        Me.Controls.Add(Me.txtIP)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Text = "UDP ASCII Command (VB)"
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents btnSend As System.Windows.Forms.Button
    Private WithEvents txtTime As System.Windows.Forms.TextBox
    Private WithEvents txtRespond As System.Windows.Forms.TextBox
    Private WithEvents txtSend As System.Windows.Forms.TextBox
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents btnConnect As System.Windows.Forms.Button
    Private WithEvents txtIP As System.Windows.Forms.TextBox

End Class
