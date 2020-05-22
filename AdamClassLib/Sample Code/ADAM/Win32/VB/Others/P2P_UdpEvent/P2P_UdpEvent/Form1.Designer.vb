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
        Me.listViewInfo = New System.Windows.Forms.ListView
        Me.columnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.columnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.txtFuncCode = New System.Windows.Forms.TextBox
        Me.txtRecvNum = New System.Windows.Forms.TextBox
        Me.labFuncCode = New System.Windows.Forms.Label
        Me.btnStart = New System.Windows.Forms.Button
        Me.gbxCurrentInfo = New System.Windows.Forms.GroupBox
        Me.labRecvNum = New System.Windows.Forms.Label
        Me.gbxHistory = New System.Windows.Forms.GroupBox
        Me.listBoxHistory = New System.Windows.Forms.ListBox
        Me.txtPort = New System.Windows.Forms.TextBox
        Me.labPort = New System.Windows.Forms.Label
        Me.gbxCurrentInfo.SuspendLayout()
        Me.gbxHistory.SuspendLayout()
        Me.SuspendLayout()
        '
        'listViewInfo
        '
        Me.listViewInfo.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeader1, Me.columnHeader2, Me.columnHeader3})
        Me.listViewInfo.Location = New System.Drawing.Point(8, 71)
        Me.listViewInfo.Name = "listViewInfo"
        Me.listViewInfo.Size = New System.Drawing.Size(232, 304)
        Me.listViewInfo.TabIndex = 4
        Me.listViewInfo.UseCompatibleStateImageBehavior = False
        Me.listViewInfo.View = System.Windows.Forms.View.Details
        '
        'columnHeader1
        '
        Me.columnHeader1.Text = "Channel"
        '
        'columnHeader2
        '
        Me.columnHeader2.Text = "Value"
        '
        'columnHeader3
        '
        Me.columnHeader3.Text = "C.O.S. Flag"
        Me.columnHeader3.Width = 82
        '
        'txtFuncCode
        '
        Me.txtFuncCode.Location = New System.Drawing.Point(89, 43)
        Me.txtFuncCode.Name = "txtFuncCode"
        Me.txtFuncCode.ReadOnly = True
        Me.txtFuncCode.Size = New System.Drawing.Size(100, 22)
        Me.txtFuncCode.TabIndex = 3
        '
        'txtRecvNum
        '
        Me.txtRecvNum.Location = New System.Drawing.Point(89, 15)
        Me.txtRecvNum.Name = "txtRecvNum"
        Me.txtRecvNum.ReadOnly = True
        Me.txtRecvNum.Size = New System.Drawing.Size(100, 22)
        Me.txtRecvNum.TabIndex = 2
        '
        'labFuncCode
        '
        Me.labFuncCode.AutoSize = True
        Me.labFuncCode.Location = New System.Drawing.Point(6, 46)
        Me.labFuncCode.Name = "labFuncCode"
        Me.labFuncCode.Size = New System.Drawing.Size(74, 12)
        Me.labFuncCode.TabIndex = 1
        Me.labFuncCode.Text = "Function Code"
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(459, 5)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(75, 23)
        Me.btnStart.TabIndex = 12
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'gbxCurrentInfo
        '
        Me.gbxCurrentInfo.Controls.Add(Me.listViewInfo)
        Me.gbxCurrentInfo.Controls.Add(Me.txtFuncCode)
        Me.gbxCurrentInfo.Controls.Add(Me.txtRecvNum)
        Me.gbxCurrentInfo.Controls.Add(Me.labFuncCode)
        Me.gbxCurrentInfo.Controls.Add(Me.labRecvNum)
        Me.gbxCurrentInfo.Location = New System.Drawing.Point(294, 40)
        Me.gbxCurrentInfo.Name = "gbxCurrentInfo"
        Me.gbxCurrentInfo.Size = New System.Drawing.Size(246, 381)
        Me.gbxCurrentInfo.TabIndex = 14
        Me.gbxCurrentInfo.TabStop = False
        Me.gbxCurrentInfo.Text = "Current Information"
        '
        'labRecvNum
        '
        Me.labRecvNum.AutoSize = True
        Me.labRecvNum.Location = New System.Drawing.Point(6, 18)
        Me.labRecvNum.Name = "labRecvNum"
        Me.labRecvNum.Size = New System.Drawing.Size(68, 12)
        Me.labRecvNum.TabIndex = 0
        Me.labRecvNum.Text = "Receive Num"
        '
        'gbxHistory
        '
        Me.gbxHistory.Controls.Add(Me.listBoxHistory)
        Me.gbxHistory.Location = New System.Drawing.Point(2, 40)
        Me.gbxHistory.Name = "gbxHistory"
        Me.gbxHistory.Size = New System.Drawing.Size(285, 381)
        Me.gbxHistory.TabIndex = 13
        Me.gbxHistory.TabStop = False
        Me.gbxHistory.Text = "History Message"
        '
        'listBoxHistory
        '
        Me.listBoxHistory.FormattingEnabled = True
        Me.listBoxHistory.ItemHeight = 12
        Me.listBoxHistory.Location = New System.Drawing.Point(6, 12)
        Me.listBoxHistory.Name = "listBoxHistory"
        Me.listBoxHistory.Size = New System.Drawing.Size(273, 364)
        Me.listBoxHistory.TabIndex = 0
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(35, 6)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.ReadOnly = True
        Me.txtPort.Size = New System.Drawing.Size(50, 22)
        Me.txtPort.TabIndex = 11
        '
        'labPort
        '
        Me.labPort.AutoSize = True
        Me.labPort.Location = New System.Drawing.Point(2, 10)
        Me.labPort.Name = "labPort"
        Me.labPort.Size = New System.Drawing.Size(27, 12)
        Me.labPort.TabIndex = 10
        Me.labPort.Text = "Port:"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(543, 423)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.gbxCurrentInfo)
        Me.Controls.Add(Me.gbxHistory)
        Me.Controls.Add(Me.txtPort)
        Me.Controls.Add(Me.labPort)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Text = "Peer to Peer Event (VB)"
        Me.gbxCurrentInfo.ResumeLayout(False)
        Me.gbxCurrentInfo.PerformLayout()
        Me.gbxHistory.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents listViewInfo As System.Windows.Forms.ListView
    Private WithEvents columnHeader1 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader2 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader3 As System.Windows.Forms.ColumnHeader
    Private WithEvents txtFuncCode As System.Windows.Forms.TextBox
    Private WithEvents txtRecvNum As System.Windows.Forms.TextBox
    Private WithEvents labFuncCode As System.Windows.Forms.Label
    Private WithEvents btnStart As System.Windows.Forms.Button
    Private WithEvents gbxCurrentInfo As System.Windows.Forms.GroupBox
    Private WithEvents labRecvNum As System.Windows.Forms.Label
    Private WithEvents gbxHistory As System.Windows.Forms.GroupBox
    Private WithEvents listBoxHistory As System.Windows.Forms.ListBox
    Private WithEvents txtPort As System.Windows.Forms.TextBox
    Private WithEvents labPort As System.Windows.Forms.Label

End Class
