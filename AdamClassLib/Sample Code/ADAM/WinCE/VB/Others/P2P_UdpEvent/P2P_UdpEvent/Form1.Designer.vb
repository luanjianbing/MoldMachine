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
        Me.labRecvNum = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.listBoxHistory = New System.Windows.Forms.ListBox
        Me.label1 = New System.Windows.Forms.Label
        Me.btnStart = New System.Windows.Forms.Button
        Me.txtPort = New System.Windows.Forms.TextBox
        Me.labPort = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'listViewInfo
        '
        Me.listViewInfo.Columns.Add(Me.columnHeader1)
        Me.listViewInfo.Columns.Add(Me.columnHeader2)
        Me.listViewInfo.Columns.Add(Me.columnHeader3)
        Me.listViewInfo.Location = New System.Drawing.Point(296, 141)
        Me.listViewInfo.Name = "listViewInfo"
        Me.listViewInfo.Size = New System.Drawing.Size(242, 291)
        Me.listViewInfo.TabIndex = 33
        Me.listViewInfo.View = System.Windows.Forms.View.Details
        '
        'columnHeader1
        '
        Me.columnHeader1.Text = "Channel"
        Me.columnHeader1.Width = 58
        '
        'columnHeader2
        '
        Me.columnHeader2.Text = "Value"
        Me.columnHeader2.Width = 44
        '
        'columnHeader3
        '
        Me.columnHeader3.Text = "C.O.S. Flag"
        Me.columnHeader3.Width = 82
        '
        'txtFuncCode
        '
        Me.txtFuncCode.Location = New System.Drawing.Point(426, 110)
        Me.txtFuncCode.Name = "txtFuncCode"
        Me.txtFuncCode.ReadOnly = True
        Me.txtFuncCode.Size = New System.Drawing.Size(112, 23)
        Me.txtFuncCode.TabIndex = 32
        '
        'txtRecvNum
        '
        Me.txtRecvNum.Location = New System.Drawing.Point(426, 81)
        Me.txtRecvNum.Name = "txtRecvNum"
        Me.txtRecvNum.ReadOnly = True
        Me.txtRecvNum.Size = New System.Drawing.Size(112, 23)
        Me.txtRecvNum.TabIndex = 31
        '
        'labFuncCode
        '
        Me.labFuncCode.Location = New System.Drawing.Point(297, 113)
        Me.labFuncCode.Name = "labFuncCode"
        Me.labFuncCode.Size = New System.Drawing.Size(100, 20)
        Me.labFuncCode.Text = "Function Code"
        '
        'labRecvNum
        '
        Me.labRecvNum.Location = New System.Drawing.Point(297, 84)
        Me.labRecvNum.Name = "labRecvNum"
        Me.labRecvNum.Size = New System.Drawing.Size(90, 20)
        Me.labRecvNum.Text = "Receive Num"
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(297, 45)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(142, 20)
        Me.label2.Text = "Current Information : "
        '
        'listBoxHistory
        '
        Me.listBoxHistory.Location = New System.Drawing.Point(9, 78)
        Me.listBoxHistory.Name = "listBoxHistory"
        Me.listBoxHistory.Size = New System.Drawing.Size(273, 354)
        Me.listBoxHistory.TabIndex = 30
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(9, 45)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(117, 20)
        Me.label1.Text = "History Message : "
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(463, 8)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(75, 23)
        Me.btnStart.TabIndex = 29
        Me.btnStart.Text = "Start"
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(54, 8)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.ReadOnly = True
        Me.txtPort.Size = New System.Drawing.Size(50, 23)
        Me.txtPort.TabIndex = 28
        '
        'labPort
        '
        Me.labPort.Location = New System.Drawing.Point(9, 12)
        Me.labPort.Name = "labPort"
        Me.labPort.Size = New System.Drawing.Size(39, 19)
        Me.labPort.Text = "Port:"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(547, 441)
        Me.Controls.Add(Me.listViewInfo)
        Me.Controls.Add(Me.txtFuncCode)
        Me.Controls.Add(Me.txtRecvNum)
        Me.Controls.Add(Me.labFuncCode)
        Me.Controls.Add(Me.labRecvNum)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.listBoxHistory)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.txtPort)
        Me.Controls.Add(Me.labPort)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Text = "Peer to Peer Event (VB)"
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents listViewInfo As System.Windows.Forms.ListView
    Private WithEvents columnHeader1 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader2 As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeader3 As System.Windows.Forms.ColumnHeader
    Private WithEvents txtFuncCode As System.Windows.Forms.TextBox
    Private WithEvents txtRecvNum As System.Windows.Forms.TextBox
    Private WithEvents labFuncCode As System.Windows.Forms.Label
    Private WithEvents labRecvNum As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents listBoxHistory As System.Windows.Forms.ListBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents btnStart As System.Windows.Forms.Button
    Private WithEvents txtPort As System.Windows.Forms.TextBox
    Private WithEvents labPort As System.Windows.Forms.Label

End Class
