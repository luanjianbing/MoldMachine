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
        Me.gbxIOData = New System.Windows.Forms.GroupBox
        Me.txtIOData = New System.Windows.Forms.TextBox
        Me.btnStart = New System.Windows.Forms.Button
        Me.txtMsg = New System.Windows.Forms.TextBox
        Me.gbxMsg = New System.Windows.Forms.GroupBox
        Me.gbxDataInfo = New System.Windows.Forms.GroupBox
        Me.gbxHistory = New System.Windows.Forms.GroupBox
        Me.listBoxMsg = New System.Windows.Forms.ListBox
        Me.txtPort = New System.Windows.Forms.TextBox
        Me.label1 = New System.Windows.Forms.Label
        Me.gbxIOData.SuspendLayout()
        Me.gbxMsg.SuspendLayout()
        Me.gbxDataInfo.SuspendLayout()
        Me.gbxHistory.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbxIOData
        '
        Me.gbxIOData.Controls.Add(Me.txtIOData)
        Me.gbxIOData.Location = New System.Drawing.Point(6, 12)
        Me.gbxIOData.Name = "gbxIOData"
        Me.gbxIOData.Size = New System.Drawing.Size(305, 215)
        Me.gbxIOData.TabIndex = 6
        Me.gbxIOData.TabStop = False
        Me.gbxIOData.Text = "IO Data"
        '
        'txtIOData
        '
        Me.txtIOData.Location = New System.Drawing.Point(6, 15)
        Me.txtIOData.Multiline = True
        Me.txtIOData.Name = "txtIOData"
        Me.txtIOData.ReadOnly = True
        Me.txtIOData.Size = New System.Drawing.Size(293, 194)
        Me.txtIOData.TabIndex = 0
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(702, 9)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(75, 23)
        Me.btnStart.TabIndex = 9
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'txtMsg
        '
        Me.txtMsg.Location = New System.Drawing.Point(6, 15)
        Me.txtMsg.Multiline = True
        Me.txtMsg.Name = "txtMsg"
        Me.txtMsg.ReadOnly = True
        Me.txtMsg.Size = New System.Drawing.Size(293, 121)
        Me.txtMsg.TabIndex = 0
        '
        'gbxMsg
        '
        Me.gbxMsg.Controls.Add(Me.txtMsg)
        Me.gbxMsg.Location = New System.Drawing.Point(6, 233)
        Me.gbxMsg.Name = "gbxMsg"
        Me.gbxMsg.Size = New System.Drawing.Size(305, 142)
        Me.gbxMsg.TabIndex = 5
        Me.gbxMsg.TabStop = False
        Me.gbxMsg.Text = "Message"
        '
        'gbxDataInfo
        '
        Me.gbxDataInfo.Controls.Add(Me.gbxIOData)
        Me.gbxDataInfo.Controls.Add(Me.gbxMsg)
        Me.gbxDataInfo.Location = New System.Drawing.Point(460, 31)
        Me.gbxDataInfo.Name = "gbxDataInfo"
        Me.gbxDataInfo.Size = New System.Drawing.Size(317, 381)
        Me.gbxDataInfo.TabIndex = 8
        Me.gbxDataInfo.TabStop = False
        Me.gbxDataInfo.Text = "Data Information"
        '
        'gbxHistory
        '
        Me.gbxHistory.Controls.Add(Me.listBoxMsg)
        Me.gbxHistory.Location = New System.Drawing.Point(-1, 31)
        Me.gbxHistory.Name = "gbxHistory"
        Me.gbxHistory.Size = New System.Drawing.Size(457, 381)
        Me.gbxHistory.TabIndex = 7
        Me.gbxHistory.TabStop = False
        Me.gbxHistory.Text = "History Message"
        '
        'listBoxMsg
        '
        Me.listBoxMsg.FormattingEnabled = True
        Me.listBoxMsg.HorizontalScrollbar = True
        Me.listBoxMsg.ItemHeight = 12
        Me.listBoxMsg.Location = New System.Drawing.Point(6, 12)
        Me.listBoxMsg.Name = "listBoxMsg"
        Me.listBoxMsg.Size = New System.Drawing.Size(445, 364)
        Me.listBoxMsg.TabIndex = 0
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(32, 3)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.ReadOnly = True
        Me.txtPort.Size = New System.Drawing.Size(50, 22)
        Me.txtPort.TabIndex = 6
        Me.txtPort.Text = "5168"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(-1, 6)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(27, 12)
        Me.label1.TabIndex = 5
        Me.label1.Text = "Port:"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(779, 414)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.gbxDataInfo)
        Me.Controls.Add(Me.gbxHistory)
        Me.Controls.Add(Me.txtPort)
        Me.Controls.Add(Me.label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Text = "GCL IO data and message stream sample (VB)"
        Me.gbxIOData.ResumeLayout(False)
        Me.gbxIOData.PerformLayout()
        Me.gbxMsg.ResumeLayout(False)
        Me.gbxMsg.PerformLayout()
        Me.gbxDataInfo.ResumeLayout(False)
        Me.gbxHistory.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents gbxIOData As System.Windows.Forms.GroupBox
    Private WithEvents txtIOData As System.Windows.Forms.TextBox
    Private WithEvents btnStart As System.Windows.Forms.Button
    Private WithEvents txtMsg As System.Windows.Forms.TextBox
    Private WithEvents gbxMsg As System.Windows.Forms.GroupBox
    Private WithEvents gbxDataInfo As System.Windows.Forms.GroupBox
    Private WithEvents gbxHistory As System.Windows.Forms.GroupBox
    Private WithEvents listBoxMsg As System.Windows.Forms.ListBox
    Private WithEvents txtPort As System.Windows.Forms.TextBox
    Private WithEvents label1 As System.Windows.Forms.Label

End Class
