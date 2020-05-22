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
        Me.components = New System.ComponentModel.Container
        Me.tabControl1 = New System.Windows.Forms.TabControl
        Me.tabPageData = New System.Windows.Forms.TabPage
        Me.txtAIValue7 = New System.Windows.Forms.TextBox
        Me.txtAIValue6 = New System.Windows.Forms.TextBox
        Me.txtAIValue5 = New System.Windows.Forms.TextBox
        Me.txtAIValue4 = New System.Windows.Forms.TextBox
        Me.txtAIValue3 = New System.Windows.Forms.TextBox
        Me.txtAIValue2 = New System.Windows.Forms.TextBox
        Me.txtAIValue1 = New System.Windows.Forms.TextBox
        Me.txtAIValue0 = New System.Windows.Forms.TextBox
        Me.chkboxCh7 = New System.Windows.Forms.CheckBox
        Me.chkboxCh6 = New System.Windows.Forms.CheckBox
        Me.chkboxCh5 = New System.Windows.Forms.CheckBox
        Me.chkboxCh4 = New System.Windows.Forms.CheckBox
        Me.chkboxCh3 = New System.Windows.Forms.CheckBox
        Me.chkboxCh2 = New System.Windows.Forms.CheckBox
        Me.chkboxCh1 = New System.Windows.Forms.CheckBox
        Me.chkboxCh0 = New System.Windows.Forms.CheckBox
        Me.tabPageMem = New System.Windows.Forms.TabPage
        Me.listView1 = New System.Windows.Forms.ListView
        Me.columnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.btnGetMem = New System.Windows.Forms.Button
        Me.btnStopMem = New System.Windows.Forms.Button
        Me.btnStartMem = New System.Windows.Forms.Button
        Me.txtMemEventCount = New System.Windows.Forms.TextBox
        Me.txtMemStandardCount = New System.Windows.Forms.TextBox
        Me.txtRecord = New System.Windows.Forms.TextBox
        Me.label5 = New System.Windows.Forms.Label
        Me.label4 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.buttonStart = New System.Windows.Forms.Button
        Me.txtReadCount = New System.Windows.Forms.TextBox
        Me.txtModule = New System.Windows.Forms.TextBox
        Me.label2 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.tabControl1.SuspendLayout()
        Me.tabPageData.SuspendLayout()
        Me.tabPageMem.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabControl1
        '
        Me.tabControl1.Controls.Add(Me.tabPageData)
        Me.tabControl1.Controls.Add(Me.tabPageMem)
        Me.tabControl1.Location = New System.Drawing.Point(14, 79)
        Me.tabControl1.Name = "tabControl1"
        Me.tabControl1.SelectedIndex = 0
        Me.tabControl1.Size = New System.Drawing.Size(334, 351)
        Me.tabControl1.TabIndex = 43
        '
        'tabPageData
        '
        Me.tabPageData.Controls.Add(Me.txtAIValue7)
        Me.tabPageData.Controls.Add(Me.txtAIValue6)
        Me.tabPageData.Controls.Add(Me.txtAIValue5)
        Me.tabPageData.Controls.Add(Me.txtAIValue4)
        Me.tabPageData.Controls.Add(Me.txtAIValue3)
        Me.tabPageData.Controls.Add(Me.txtAIValue2)
        Me.tabPageData.Controls.Add(Me.txtAIValue1)
        Me.tabPageData.Controls.Add(Me.txtAIValue0)
        Me.tabPageData.Controls.Add(Me.chkboxCh7)
        Me.tabPageData.Controls.Add(Me.chkboxCh6)
        Me.tabPageData.Controls.Add(Me.chkboxCh5)
        Me.tabPageData.Controls.Add(Me.chkboxCh4)
        Me.tabPageData.Controls.Add(Me.chkboxCh3)
        Me.tabPageData.Controls.Add(Me.chkboxCh2)
        Me.tabPageData.Controls.Add(Me.chkboxCh1)
        Me.tabPageData.Controls.Add(Me.chkboxCh0)
        Me.tabPageData.Location = New System.Drawing.Point(4, 21)
        Me.tabPageData.Name = "tabPageData"
        Me.tabPageData.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPageData.Size = New System.Drawing.Size(326, 326)
        Me.tabPageData.TabIndex = 0
        Me.tabPageData.Text = "Data"
        Me.tabPageData.UseVisualStyleBackColor = True
        '
        'txtAIValue7
        '
        Me.txtAIValue7.Location = New System.Drawing.Point(93, 251)
        Me.txtAIValue7.Name = "txtAIValue7"
        Me.txtAIValue7.ReadOnly = True
        Me.txtAIValue7.Size = New System.Drawing.Size(150, 22)
        Me.txtAIValue7.TabIndex = 63
        '
        'txtAIValue6
        '
        Me.txtAIValue6.Location = New System.Drawing.Point(93, 216)
        Me.txtAIValue6.Name = "txtAIValue6"
        Me.txtAIValue6.ReadOnly = True
        Me.txtAIValue6.Size = New System.Drawing.Size(150, 22)
        Me.txtAIValue6.TabIndex = 62
        '
        'txtAIValue5
        '
        Me.txtAIValue5.Location = New System.Drawing.Point(93, 179)
        Me.txtAIValue5.Name = "txtAIValue5"
        Me.txtAIValue5.ReadOnly = True
        Me.txtAIValue5.Size = New System.Drawing.Size(150, 22)
        Me.txtAIValue5.TabIndex = 61
        '
        'txtAIValue4
        '
        Me.txtAIValue4.Location = New System.Drawing.Point(93, 143)
        Me.txtAIValue4.Name = "txtAIValue4"
        Me.txtAIValue4.ReadOnly = True
        Me.txtAIValue4.Size = New System.Drawing.Size(150, 22)
        Me.txtAIValue4.TabIndex = 60
        '
        'txtAIValue3
        '
        Me.txtAIValue3.Location = New System.Drawing.Point(93, 108)
        Me.txtAIValue3.Name = "txtAIValue3"
        Me.txtAIValue3.ReadOnly = True
        Me.txtAIValue3.Size = New System.Drawing.Size(150, 22)
        Me.txtAIValue3.TabIndex = 59
        '
        'txtAIValue2
        '
        Me.txtAIValue2.Location = New System.Drawing.Point(93, 73)
        Me.txtAIValue2.Name = "txtAIValue2"
        Me.txtAIValue2.ReadOnly = True
        Me.txtAIValue2.Size = New System.Drawing.Size(150, 22)
        Me.txtAIValue2.TabIndex = 58
        '
        'txtAIValue1
        '
        Me.txtAIValue1.Location = New System.Drawing.Point(93, 40)
        Me.txtAIValue1.Name = "txtAIValue1"
        Me.txtAIValue1.ReadOnly = True
        Me.txtAIValue1.Size = New System.Drawing.Size(150, 22)
        Me.txtAIValue1.TabIndex = 57
        '
        'txtAIValue0
        '
        Me.txtAIValue0.Location = New System.Drawing.Point(93, 4)
        Me.txtAIValue0.Name = "txtAIValue0"
        Me.txtAIValue0.ReadOnly = True
        Me.txtAIValue0.Size = New System.Drawing.Size(150, 22)
        Me.txtAIValue0.TabIndex = 56
        '
        'chkboxCh7
        '
        Me.chkboxCh7.AutoSize = True
        Me.chkboxCh7.Enabled = False
        Me.chkboxCh7.Location = New System.Drawing.Point(6, 253)
        Me.chkboxCh7.Name = "chkboxCh7"
        Me.chkboxCh7.Size = New System.Drawing.Size(77, 16)
        Me.chkboxCh7.TabIndex = 55
        Me.chkboxCh7.Text = "AI-7 value:"
        Me.chkboxCh7.UseVisualStyleBackColor = True
        '
        'chkboxCh6
        '
        Me.chkboxCh6.AutoSize = True
        Me.chkboxCh6.Enabled = False
        Me.chkboxCh6.Location = New System.Drawing.Point(6, 218)
        Me.chkboxCh6.Name = "chkboxCh6"
        Me.chkboxCh6.Size = New System.Drawing.Size(77, 16)
        Me.chkboxCh6.TabIndex = 54
        Me.chkboxCh6.Text = "AI-6 value:"
        Me.chkboxCh6.UseVisualStyleBackColor = True
        '
        'chkboxCh5
        '
        Me.chkboxCh5.AutoSize = True
        Me.chkboxCh5.Enabled = False
        Me.chkboxCh5.Location = New System.Drawing.Point(6, 181)
        Me.chkboxCh5.Name = "chkboxCh5"
        Me.chkboxCh5.Size = New System.Drawing.Size(77, 16)
        Me.chkboxCh5.TabIndex = 53
        Me.chkboxCh5.Text = "AI-5 value:"
        Me.chkboxCh5.UseVisualStyleBackColor = True
        '
        'chkboxCh4
        '
        Me.chkboxCh4.AutoSize = True
        Me.chkboxCh4.Enabled = False
        Me.chkboxCh4.Location = New System.Drawing.Point(6, 145)
        Me.chkboxCh4.Name = "chkboxCh4"
        Me.chkboxCh4.Size = New System.Drawing.Size(77, 16)
        Me.chkboxCh4.TabIndex = 52
        Me.chkboxCh4.Text = "AI-4 value:"
        Me.chkboxCh4.UseVisualStyleBackColor = True
        '
        'chkboxCh3
        '
        Me.chkboxCh3.AutoSize = True
        Me.chkboxCh3.Enabled = False
        Me.chkboxCh3.Location = New System.Drawing.Point(6, 110)
        Me.chkboxCh3.Name = "chkboxCh3"
        Me.chkboxCh3.Size = New System.Drawing.Size(77, 16)
        Me.chkboxCh3.TabIndex = 51
        Me.chkboxCh3.Text = "AI-3 value:"
        Me.chkboxCh3.UseVisualStyleBackColor = True
        '
        'chkboxCh2
        '
        Me.chkboxCh2.AutoSize = True
        Me.chkboxCh2.Enabled = False
        Me.chkboxCh2.Location = New System.Drawing.Point(6, 75)
        Me.chkboxCh2.Name = "chkboxCh2"
        Me.chkboxCh2.Size = New System.Drawing.Size(77, 16)
        Me.chkboxCh2.TabIndex = 50
        Me.chkboxCh2.Text = "AI-2 value:"
        Me.chkboxCh2.UseVisualStyleBackColor = True
        '
        'chkboxCh1
        '
        Me.chkboxCh1.AutoSize = True
        Me.chkboxCh1.Enabled = False
        Me.chkboxCh1.Location = New System.Drawing.Point(6, 42)
        Me.chkboxCh1.Name = "chkboxCh1"
        Me.chkboxCh1.Size = New System.Drawing.Size(77, 16)
        Me.chkboxCh1.TabIndex = 49
        Me.chkboxCh1.Text = "AI-1 value:"
        Me.chkboxCh1.UseVisualStyleBackColor = True
        '
        'chkboxCh0
        '
        Me.chkboxCh0.AutoSize = True
        Me.chkboxCh0.Enabled = False
        Me.chkboxCh0.Location = New System.Drawing.Point(6, 6)
        Me.chkboxCh0.Name = "chkboxCh0"
        Me.chkboxCh0.Size = New System.Drawing.Size(77, 16)
        Me.chkboxCh0.TabIndex = 48
        Me.chkboxCh0.Text = "AI-0 value:"
        Me.chkboxCh0.UseVisualStyleBackColor = True
        '
        'tabPageMem
        '
        Me.tabPageMem.BackColor = System.Drawing.Color.Transparent
        Me.tabPageMem.Controls.Add(Me.listView1)
        Me.tabPageMem.Controls.Add(Me.btnGetMem)
        Me.tabPageMem.Controls.Add(Me.btnStopMem)
        Me.tabPageMem.Controls.Add(Me.btnStartMem)
        Me.tabPageMem.Controls.Add(Me.txtMemEventCount)
        Me.tabPageMem.Controls.Add(Me.txtMemStandardCount)
        Me.tabPageMem.Controls.Add(Me.txtRecord)
        Me.tabPageMem.Controls.Add(Me.label5)
        Me.tabPageMem.Controls.Add(Me.label4)
        Me.tabPageMem.Controls.Add(Me.label3)
        Me.tabPageMem.Location = New System.Drawing.Point(4, 21)
        Me.tabPageMem.Name = "tabPageMem"
        Me.tabPageMem.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPageMem.Size = New System.Drawing.Size(326, 326)
        Me.tabPageMem.TabIndex = 1
        Me.tabPageMem.Text = "Memory"
        Me.tabPageMem.UseVisualStyleBackColor = True
        '
        'listView1
        '
        Me.listView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader1, Me.columnHeader2, Me.columnHeader3, Me.columnHeader4})
        Me.listView1.Location = New System.Drawing.Point(8, 98)
        Me.listView1.Name = "listView1"
        Me.listView1.Size = New System.Drawing.Size(312, 222)
        Me.listView1.TabIndex = 9
        Me.listView1.UseCompatibleStateImageBehavior = False
        Me.listView1.View = System.Windows.Forms.View.Details
        '
        'columnHeader1
        '
        Me.columnHeader1.Text = "Index"
        Me.columnHeader1.Width = 51
        '
        'columnHeader2
        '
        Me.columnHeader2.Text = "Ch"
        Me.columnHeader2.Width = 48
        '
        'columnHeader3
        '
        Me.columnHeader3.Text = "Data"
        Me.columnHeader3.Width = 79
        '
        'columnHeader4
        '
        Me.columnHeader4.Text = "Elapse"
        Me.columnHeader4.Width = 69
        '
        'btnGetMem
        '
        Me.btnGetMem.Location = New System.Drawing.Point(245, 68)
        Me.btnGetMem.Name = "btnGetMem"
        Me.btnGetMem.Size = New System.Drawing.Size(75, 23)
        Me.btnGetMem.TabIndex = 8
        Me.btnGetMem.Text = "Get records"
        Me.btnGetMem.UseVisualStyleBackColor = True
        '
        'btnStopMem
        '
        Me.btnStopMem.Location = New System.Drawing.Point(245, 40)
        Me.btnStopMem.Name = "btnStopMem"
        Me.btnStopMem.Size = New System.Drawing.Size(75, 23)
        Me.btnStopMem.TabIndex = 7
        Me.btnStopMem.Text = "Stop"
        Me.btnStopMem.UseVisualStyleBackColor = True
        '
        'btnStartMem
        '
        Me.btnStartMem.Location = New System.Drawing.Point(245, 11)
        Me.btnStartMem.Name = "btnStartMem"
        Me.btnStartMem.Size = New System.Drawing.Size(75, 23)
        Me.btnStartMem.TabIndex = 6
        Me.btnStartMem.Text = "Start"
        Me.btnStartMem.UseVisualStyleBackColor = True
        '
        'txtMemEventCount
        '
        Me.txtMemEventCount.Location = New System.Drawing.Point(94, 70)
        Me.txtMemEventCount.Name = "txtMemEventCount"
        Me.txtMemEventCount.ReadOnly = True
        Me.txtMemEventCount.Size = New System.Drawing.Size(100, 22)
        Me.txtMemEventCount.TabIndex = 5
        '
        'txtMemStandardCount
        '
        Me.txtMemStandardCount.Location = New System.Drawing.Point(94, 42)
        Me.txtMemStandardCount.Name = "txtMemStandardCount"
        Me.txtMemStandardCount.ReadOnly = True
        Me.txtMemStandardCount.Size = New System.Drawing.Size(100, 22)
        Me.txtMemStandardCount.TabIndex = 4
        '
        'txtRecord
        '
        Me.txtRecord.Location = New System.Drawing.Point(94, 13)
        Me.txtRecord.Name = "txtRecord"
        Me.txtRecord.ReadOnly = True
        Me.txtRecord.Size = New System.Drawing.Size(100, 22)
        Me.txtRecord.TabIndex = 3
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(6, 73)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(68, 12)
        Me.label5.TabIndex = 2
        Me.label5.Text = "Event record:"
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(6, 45)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(82, 12)
        Me.label4.TabIndex = 1
        Me.label4.Text = "Standard record:"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(6, 16)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(57, 12)
        Me.label3.TabIndex = 0
        Me.label3.Text = "Recording:"
        '
        'buttonStart
        '
        Me.buttonStart.Location = New System.Drawing.Point(273, 6)
        Me.buttonStart.Name = "buttonStart"
        Me.buttonStart.Size = New System.Drawing.Size(75, 23)
        Me.buttonStart.TabIndex = 42
        Me.buttonStart.Text = "Start"
        Me.buttonStart.UseVisualStyleBackColor = True
        '
        'txtReadCount
        '
        Me.txtReadCount.Location = New System.Drawing.Point(101, 40)
        Me.txtReadCount.Name = "txtReadCount"
        Me.txtReadCount.ReadOnly = True
        Me.txtReadCount.Size = New System.Drawing.Size(150, 22)
        Me.txtReadCount.TabIndex = 41
        Me.txtReadCount.Text = "0"
        '
        'txtModule
        '
        Me.txtModule.Location = New System.Drawing.Point(101, 6)
        Me.txtModule.Name = "txtModule"
        Me.txtModule.Size = New System.Drawing.Size(150, 22)
        Me.txtModule.TabIndex = 40
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(12, 43)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(61, 12)
        Me.label2.TabIndex = 39
        Me.label2.Text = "Read count:"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(12, 9)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(72, 12)
        Me.label1.TabIndex = 38
        Me.label1.Text = "Module name:"
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(362, 435)
        Me.Controls.Add(Me.tabControl1)
        Me.Controls.Add(Me.buttonStart)
        Me.Controls.Add(Me.txtReadCount)
        Me.Controls.Add(Me.txtModule)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.Name = "Form1"
        Me.Text = "Adam4018M sample program (VB)"
        Me.tabControl1.ResumeLayout(False)
        Me.tabPageData.ResumeLayout(False)
        Me.tabPageData.PerformLayout()
        Me.tabPageMem.ResumeLayout(False)
        Me.tabPageMem.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents tabControl1 As System.Windows.Forms.TabControl
    Private WithEvents tabPageData As System.Windows.Forms.TabPage
    Private WithEvents txtAIValue7 As System.Windows.Forms.TextBox
    Private WithEvents txtAIValue6 As System.Windows.Forms.TextBox
    Private WithEvents txtAIValue5 As System.Windows.Forms.TextBox
    Private WithEvents txtAIValue4 As System.Windows.Forms.TextBox
    Private WithEvents txtAIValue3 As System.Windows.Forms.TextBox
    Private WithEvents txtAIValue2 As System.Windows.Forms.TextBox
    Private WithEvents txtAIValue1 As System.Windows.Forms.TextBox
    Private WithEvents txtAIValue0 As System.Windows.Forms.TextBox
    Private WithEvents chkboxCh7 As System.Windows.Forms.CheckBox
    Private WithEvents chkboxCh6 As System.Windows.Forms.CheckBox
    Private WithEvents chkboxCh5 As System.Windows.Forms.CheckBox
    Private WithEvents chkboxCh4 As System.Windows.Forms.CheckBox
    Private WithEvents chkboxCh3 As System.Windows.Forms.CheckBox
    Private WithEvents chkboxCh2 As System.Windows.Forms.CheckBox
    Private WithEvents chkboxCh1 As System.Windows.Forms.CheckBox
    Private WithEvents chkboxCh0 As System.Windows.Forms.CheckBox
    Private WithEvents tabPageMem As System.Windows.Forms.TabPage
    Private WithEvents listView1 As System.Windows.Forms.ListView
    Private WithEvents columnHeader1 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader2 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader3 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader4 As System.Windows.Forms.ColumnHeader
    Private WithEvents btnGetMem As System.Windows.Forms.Button
    Private WithEvents btnStopMem As System.Windows.Forms.Button
    Private WithEvents btnStartMem As System.Windows.Forms.Button
    Private WithEvents txtMemEventCount As System.Windows.Forms.TextBox
    Private WithEvents txtMemStandardCount As System.Windows.Forms.TextBox
    Private WithEvents txtRecord As System.Windows.Forms.TextBox
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents buttonStart As System.Windows.Forms.Button
    Private WithEvents txtReadCount As System.Windows.Forms.TextBox
    Private WithEvents txtModule As System.Windows.Forms.TextBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
