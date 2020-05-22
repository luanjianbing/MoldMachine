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
        Me.btnSetAllFalse = New System.Windows.Forms.Button
        Me.columnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.columnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.btnSetAllTrue = New System.Windows.Forms.Button
        Me.listView1 = New System.Windows.Forms.ListView
        Me.label1 = New System.Windows.Forms.Label
        Me.txtReadCount = New System.Windows.Forms.TextBox
        Me.label2 = New System.Windows.Forms.Label
        Me.btnStart = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnSetAllFalse
        '
        Me.btnSetAllFalse.Enabled = False
        Me.btnSetAllFalse.Location = New System.Drawing.Point(321, 113)
        Me.btnSetAllFalse.Name = "btnSetAllFalse"
        Me.btnSetAllFalse.Size = New System.Drawing.Size(75, 23)
        Me.btnSetAllFalse.TabIndex = 28
        Me.btnSetAllFalse.Text = "Set All False"
        Me.btnSetAllFalse.UseVisualStyleBackColor = True
        '
        'columnHeader2
        '
        Me.columnHeader2.Text = "Value"
        Me.columnHeader2.Width = 118
        '
        'timer1
        '
        Me.timer1.Interval = 500
        '
        'columnHeader1
        '
        Me.columnHeader1.Text = "Index"
        Me.columnHeader1.Width = 71
        '
        'btnSetAllTrue
        '
        Me.btnSetAllTrue.Enabled = False
        Me.btnSetAllTrue.Location = New System.Drawing.Point(321, 75)
        Me.btnSetAllTrue.Name = "btnSetAllTrue"
        Me.btnSetAllTrue.Size = New System.Drawing.Size(75, 23)
        Me.btnSetAllTrue.TabIndex = 27
        Me.btnSetAllTrue.Text = "Set All True"
        Me.btnSetAllTrue.UseVisualStyleBackColor = True
        '
        'listView1
        '
        Me.listView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader1, Me.columnHeader2})
        Me.listView1.FullRowSelect = True
        Me.listView1.HideSelection = False
        Me.listView1.Location = New System.Drawing.Point(7, 75)
        Me.listView1.Name = "listView1"
        Me.listView1.Size = New System.Drawing.Size(308, 330)
        Me.listView1.TabIndex = 26
        Me.listView1.UseCompatibleStateImageBehavior = False
        Me.listView1.View = System.Windows.Forms.View.Details
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(5, 60)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(239, 12)
        Me.label1.TabIndex = 25
        Me.label1.Text = "Double click the list view to change the flag status:"
        '
        'txtReadCount
        '
        Me.txtReadCount.Location = New System.Drawing.Point(83, 5)
        Me.txtReadCount.Name = "txtReadCount"
        Me.txtReadCount.ReadOnly = True
        Me.txtReadCount.Size = New System.Drawing.Size(150, 22)
        Me.txtReadCount.TabIndex = 23
        Me.txtReadCount.Text = "0"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(5, 8)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(61, 12)
        Me.label2.TabIndex = 22
        Me.label2.Text = "Read count:"
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(321, 3)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(75, 23)
        Me.btnStart.TabIndex = 24
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(400, 408)
        Me.Controls.Add(Me.btnSetAllFalse)
        Me.Controls.Add(Me.btnSetAllTrue)
        Me.Controls.Add(Me.listView1)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.txtReadCount)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.btnStart)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Text = "Set/Get GCL Auxiliary Flag Status (VB)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents btnSetAllFalse As System.Windows.Forms.Button
    Private WithEvents columnHeader2 As System.Windows.Forms.ColumnHeader
    Private WithEvents timer1 As System.Windows.Forms.Timer
    Private WithEvents columnHeader1 As System.Windows.Forms.ColumnHeader
    Private WithEvents btnSetAllTrue As System.Windows.Forms.Button
    Private WithEvents listView1 As System.Windows.Forms.ListView
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents txtReadCount As System.Windows.Forms.TextBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents btnStart As System.Windows.Forms.Button

End Class
