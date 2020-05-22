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
        Me.tabControl1 = New System.Windows.Forms.TabControl
        Me.tabPageAI = New System.Windows.Forms.TabPage
        Me.listViewAI = New System.Windows.Forms.ListView
        Me.columnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.txtAITotal = New System.Windows.Forms.TextBox
        Me.label4 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.tabPageAO = New System.Windows.Forms.TabPage
        Me.listViewAO = New System.Windows.Forms.ListView
        Me.columnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader6 = New System.Windows.Forms.ColumnHeader
        Me.txtAOTotal = New System.Windows.Forms.TextBox
        Me.label5 = New System.Windows.Forms.Label
        Me.label6 = New System.Windows.Forms.Label
        Me.tabPageDIO = New System.Windows.Forms.TabPage
        Me.txtDOTotal = New System.Windows.Forms.TextBox
        Me.label8 = New System.Windows.Forms.Label
        Me.txtDITotal = New System.Windows.Forms.TextBox
        Me.label7 = New System.Windows.Forms.Label
        Me.tabPageOther = New System.Windows.Forms.TabPage
        Me.listViewAlarm = New System.Windows.Forms.ListView
        Me.columnHeader9 = New System.Windows.Forms.ColumnHeader
        Me.label11 = New System.Windows.Forms.Label
        Me.listViewCounter = New System.Windows.Forms.ListView
        Me.columnHeader7 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader8 = New System.Windows.Forms.ColumnHeader
        Me.txtCounterTotal = New System.Windows.Forms.TextBox
        Me.label9 = New System.Windows.Forms.Label
        Me.label10 = New System.Windows.Forms.Label
        Me.cbxModuleType = New System.Windows.Forms.ComboBox
        Me.cbxAdamType = New System.Windows.Forms.ComboBox
        Me.label2 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.tabControl1.SuspendLayout()
        Me.tabPageAI.SuspendLayout()
        Me.tabPageAO.SuspendLayout()
        Me.tabPageDIO.SuspendLayout()
        Me.tabPageOther.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabControl1
        '
        Me.tabControl1.Controls.Add(Me.tabPageAI)
        Me.tabControl1.Controls.Add(Me.tabPageAO)
        Me.tabControl1.Controls.Add(Me.tabPageDIO)
        Me.tabControl1.Controls.Add(Me.tabPageOther)
        Me.tabControl1.Location = New System.Drawing.Point(5, 62)
        Me.tabControl1.Name = "tabControl1"
        Me.tabControl1.SelectedIndex = 0
        Me.tabControl1.Size = New System.Drawing.Size(476, 361)
        Me.tabControl1.TabIndex = 11
        '
        'tabPageAI
        '
        Me.tabPageAI.Controls.Add(Me.listViewAI)
        Me.tabPageAI.Controls.Add(Me.txtAITotal)
        Me.tabPageAI.Controls.Add(Me.label4)
        Me.tabPageAI.Controls.Add(Me.label3)
        Me.tabPageAI.Location = New System.Drawing.Point(4, 22)
        Me.tabPageAI.Name = "tabPageAI"
        Me.tabPageAI.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPageAI.Size = New System.Drawing.Size(468, 335)
        Me.tabPageAI.TabIndex = 0
        Me.tabPageAI.Text = "Analog input"
        Me.tabPageAI.UseVisualStyleBackColor = True
        '
        'listViewAI
        '
        Me.listViewAI.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader1, Me.columnHeader2, Me.columnHeader3})
        Me.listViewAI.Location = New System.Drawing.Point(82, 49)
        Me.listViewAI.Name = "listViewAI"
        Me.listViewAI.Size = New System.Drawing.Size(380, 281)
        Me.listViewAI.TabIndex = 3
        Me.listViewAI.UseCompatibleStateImageBehavior = False
        Me.listViewAI.View = System.Windows.Forms.View.Details
        '
        'columnHeader1
        '
        Me.columnHeader1.Text = "Code"
        Me.columnHeader1.Width = 80
        '
        'columnHeader2
        '
        Me.columnHeader2.Text = "Range name"
        Me.columnHeader2.Width = 117
        '
        'columnHeader3
        '
        Me.columnHeader3.Text = "Unit"
        Me.columnHeader3.Width = 91
        '
        'txtAITotal
        '
        Me.txtAITotal.Location = New System.Drawing.Point(82, 13)
        Me.txtAITotal.Name = "txtAITotal"
        Me.txtAITotal.Size = New System.Drawing.Size(100, 22)
        Me.txtAITotal.TabIndex = 2
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(6, 49)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(62, 12)
        Me.label4.TabIndex = 1
        Me.label4.Text = "Input range:"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(6, 16)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(70, 12)
        Me.label3.TabIndex = 0
        Me.label3.Text = "Channel total:"
        '
        'tabPageAO
        '
        Me.tabPageAO.Controls.Add(Me.listViewAO)
        Me.tabPageAO.Controls.Add(Me.txtAOTotal)
        Me.tabPageAO.Controls.Add(Me.label5)
        Me.tabPageAO.Controls.Add(Me.label6)
        Me.tabPageAO.Location = New System.Drawing.Point(4, 22)
        Me.tabPageAO.Name = "tabPageAO"
        Me.tabPageAO.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPageAO.Size = New System.Drawing.Size(468, 335)
        Me.tabPageAO.TabIndex = 1
        Me.tabPageAO.Text = "Analog output"
        Me.tabPageAO.UseVisualStyleBackColor = True
        '
        'listViewAO
        '
        Me.listViewAO.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader4, Me.columnHeader5, Me.columnHeader6})
        Me.listViewAO.Location = New System.Drawing.Point(82, 46)
        Me.listViewAO.Name = "listViewAO"
        Me.listViewAO.Size = New System.Drawing.Size(380, 281)
        Me.listViewAO.TabIndex = 7
        Me.listViewAO.UseCompatibleStateImageBehavior = False
        Me.listViewAO.View = System.Windows.Forms.View.Details
        '
        'columnHeader4
        '
        Me.columnHeader4.Text = "Code"
        Me.columnHeader4.Width = 80
        '
        'columnHeader5
        '
        Me.columnHeader5.Text = "Range name"
        Me.columnHeader5.Width = 117
        '
        'columnHeader6
        '
        Me.columnHeader6.Text = "Unit"
        Me.columnHeader6.Width = 91
        '
        'txtAOTotal
        '
        Me.txtAOTotal.Location = New System.Drawing.Point(82, 10)
        Me.txtAOTotal.Name = "txtAOTotal"
        Me.txtAOTotal.Size = New System.Drawing.Size(100, 22)
        Me.txtAOTotal.TabIndex = 6
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(6, 46)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(69, 12)
        Me.label5.TabIndex = 5
        Me.label5.Text = "Output range:"
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(6, 13)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(70, 12)
        Me.label6.TabIndex = 4
        Me.label6.Text = "Channel total:"
        '
        'tabPageDIO
        '
        Me.tabPageDIO.Controls.Add(Me.txtDOTotal)
        Me.tabPageDIO.Controls.Add(Me.label8)
        Me.tabPageDIO.Controls.Add(Me.txtDITotal)
        Me.tabPageDIO.Controls.Add(Me.label7)
        Me.tabPageDIO.Location = New System.Drawing.Point(4, 22)
        Me.tabPageDIO.Name = "tabPageDIO"
        Me.tabPageDIO.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPageDIO.Size = New System.Drawing.Size(468, 335)
        Me.tabPageDIO.TabIndex = 2
        Me.tabPageDIO.Text = "Digital input/output"
        Me.tabPageDIO.UseVisualStyleBackColor = True
        '
        'txtDOTotal
        '
        Me.txtDOTotal.Location = New System.Drawing.Point(82, 58)
        Me.txtDOTotal.Name = "txtDOTotal"
        Me.txtDOTotal.Size = New System.Drawing.Size(100, 22)
        Me.txtDOTotal.TabIndex = 6
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Location = New System.Drawing.Point(6, 61)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(63, 12)
        Me.label8.TabIndex = 5
        Me.label8.Text = "Output total:"
        '
        'txtDITotal
        '
        Me.txtDITotal.Location = New System.Drawing.Point(82, 17)
        Me.txtDITotal.Name = "txtDITotal"
        Me.txtDITotal.Size = New System.Drawing.Size(100, 22)
        Me.txtDITotal.TabIndex = 4
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(6, 20)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(56, 12)
        Me.label7.TabIndex = 3
        Me.label7.Text = "Input total:"
        '
        'tabPageOther
        '
        Me.tabPageOther.Controls.Add(Me.listViewAlarm)
        Me.tabPageOther.Controls.Add(Me.label11)
        Me.tabPageOther.Controls.Add(Me.listViewCounter)
        Me.tabPageOther.Controls.Add(Me.txtCounterTotal)
        Me.tabPageOther.Controls.Add(Me.label9)
        Me.tabPageOther.Controls.Add(Me.label10)
        Me.tabPageOther.Location = New System.Drawing.Point(4, 22)
        Me.tabPageOther.Name = "tabPageOther"
        Me.tabPageOther.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPageOther.Size = New System.Drawing.Size(468, 335)
        Me.tabPageOther.TabIndex = 3
        Me.tabPageOther.Text = "Counter/Alarm"
        Me.tabPageOther.UseVisualStyleBackColor = True
        '
        'listViewAlarm
        '
        Me.listViewAlarm.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader9})
        Me.listViewAlarm.Location = New System.Drawing.Point(82, 196)
        Me.listViewAlarm.Name = "listViewAlarm"
        Me.listViewAlarm.Size = New System.Drawing.Size(380, 137)
        Me.listViewAlarm.TabIndex = 9
        Me.listViewAlarm.UseCompatibleStateImageBehavior = False
        Me.listViewAlarm.View = System.Windows.Forms.View.Details
        '
        'columnHeader9
        '
        Me.columnHeader9.Text = "Mode name"
        Me.columnHeader9.Width = 183
        '
        'label11
        '
        Me.label11.AutoSize = True
        Me.label11.Location = New System.Drawing.Point(6, 196)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(66, 12)
        Me.label11.TabIndex = 8
        Me.label11.Text = "Alarm mode:"
        '
        'listViewCounter
        '
        Me.listViewCounter.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader7, Me.columnHeader8})
        Me.listViewCounter.Location = New System.Drawing.Point(82, 46)
        Me.listViewCounter.Name = "listViewCounter"
        Me.listViewCounter.Size = New System.Drawing.Size(380, 137)
        Me.listViewCounter.TabIndex = 7
        Me.listViewCounter.UseCompatibleStateImageBehavior = False
        Me.listViewCounter.View = System.Windows.Forms.View.Details
        '
        'columnHeader7
        '
        Me.columnHeader7.Text = "Mode name"
        Me.columnHeader7.Width = 184
        '
        'columnHeader8
        '
        Me.columnHeader8.Text = "Unit"
        Me.columnHeader8.Width = 117
        '
        'txtCounterTotal
        '
        Me.txtCounterTotal.Location = New System.Drawing.Point(82, 10)
        Me.txtCounterTotal.Name = "txtCounterTotal"
        Me.txtCounterTotal.Size = New System.Drawing.Size(100, 22)
        Me.txtCounterTotal.TabIndex = 6
        '
        'label9
        '
        Me.label9.AutoSize = True
        Me.label9.Location = New System.Drawing.Point(6, 46)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(75, 12)
        Me.label9.TabIndex = 5
        Me.label9.Text = "Counter mode:"
        '
        'label10
        '
        Me.label10.AutoSize = True
        Me.label10.Location = New System.Drawing.Point(6, 13)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(69, 12)
        Me.label10.TabIndex = 4
        Me.label10.Text = "Counter total:"
        '
        'cbxModuleType
        '
        Me.cbxModuleType.FormattingEnabled = True
        Me.cbxModuleType.Location = New System.Drawing.Point(83, 36)
        Me.cbxModuleType.Name = "cbxModuleType"
        Me.cbxModuleType.Size = New System.Drawing.Size(121, 20)
        Me.cbxModuleType.TabIndex = 10
        '
        'cbxAdamType
        '
        Me.cbxAdamType.FormattingEnabled = True
        Me.cbxAdamType.Location = New System.Drawing.Point(83, 6)
        Me.cbxAdamType.Name = "cbxAdamType"
        Me.cbxAdamType.Size = New System.Drawing.Size(121, 20)
        Me.cbxAdamType.TabIndex = 9
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(12, 39)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(67, 12)
        Me.label2.TabIndex = 8
        Me.label2.Text = "Module type:"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(12, 9)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(65, 12)
        Me.label1.TabIndex = 7
        Me.label1.Text = "ADAM type:"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(485, 425)
        Me.Controls.Add(Me.tabControl1)
        Me.Controls.Add(Me.cbxModuleType)
        Me.Controls.Add(Me.cbxAdamType)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Text = "Static Method Sample Program (VB)"
        Me.tabControl1.ResumeLayout(False)
        Me.tabPageAI.ResumeLayout(False)
        Me.tabPageAI.PerformLayout()
        Me.tabPageAO.ResumeLayout(False)
        Me.tabPageAO.PerformLayout()
        Me.tabPageDIO.ResumeLayout(False)
        Me.tabPageDIO.PerformLayout()
        Me.tabPageOther.ResumeLayout(False)
        Me.tabPageOther.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents tabControl1 As System.Windows.Forms.TabControl
    Private WithEvents tabPageAI As System.Windows.Forms.TabPage
    Private WithEvents listViewAI As System.Windows.Forms.ListView
    Private WithEvents columnHeader1 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader2 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader3 As System.Windows.Forms.ColumnHeader
    Private WithEvents txtAITotal As System.Windows.Forms.TextBox
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents tabPageAO As System.Windows.Forms.TabPage
    Private WithEvents listViewAO As System.Windows.Forms.ListView
    Private WithEvents columnHeader4 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader5 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader6 As System.Windows.Forms.ColumnHeader
    Private WithEvents txtAOTotal As System.Windows.Forms.TextBox
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents tabPageDIO As System.Windows.Forms.TabPage
    Private WithEvents txtDOTotal As System.Windows.Forms.TextBox
    Private WithEvents label8 As System.Windows.Forms.Label
    Private WithEvents txtDITotal As System.Windows.Forms.TextBox
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents tabPageOther As System.Windows.Forms.TabPage
    Private WithEvents listViewAlarm As System.Windows.Forms.ListView
    Private WithEvents columnHeader9 As System.Windows.Forms.ColumnHeader
    Private WithEvents label11 As System.Windows.Forms.Label
    Private WithEvents listViewCounter As System.Windows.Forms.ListView
    Private WithEvents columnHeader7 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader8 As System.Windows.Forms.ColumnHeader
    Private WithEvents txtCounterTotal As System.Windows.Forms.TextBox
    Private WithEvents label9 As System.Windows.Forms.Label
    Private WithEvents label10 As System.Windows.Forms.Label
    Private WithEvents cbxModuleType As System.Windows.Forms.ComboBox
    Private WithEvents cbxAdamType As System.Windows.Forms.ComboBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label

End Class
