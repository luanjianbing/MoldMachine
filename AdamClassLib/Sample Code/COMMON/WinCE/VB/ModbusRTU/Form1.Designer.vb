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
        Me.buttonStart = New System.Windows.Forms.Button
        Me.listViewModbusCur = New System.Windows.Forms.ListView
        Me.columnHeaderLocation = New System.Windows.Forms.ColumnHeader
        Me.columnHeaderType = New System.Windows.Forms.ColumnHeader
        Me.columnHeaderValDec = New System.Windows.Forms.ColumnHeader
        Me.columnHeaderValHex = New System.Windows.Forms.ColumnHeader
        Me.txtStatus = New System.Windows.Forms.TextBox
        Me.Timer1 = New System.Windows.Forms.Timer
        Me.SuspendLayout()
        '
        'buttonStart
        '
        Me.buttonStart.Location = New System.Drawing.Point(334, 13)
        Me.buttonStart.Name = "buttonStart"
        Me.buttonStart.Size = New System.Drawing.Size(75, 23)
        Me.buttonStart.TabIndex = 8
        Me.buttonStart.Text = "Start"
        '
        'listViewModbusCur
        '
        Me.listViewModbusCur.Columns.Add(Me.columnHeaderLocation)
        Me.listViewModbusCur.Columns.Add(Me.columnHeaderType)
        Me.listViewModbusCur.Columns.Add(Me.columnHeaderValDec)
        Me.listViewModbusCur.Columns.Add(Me.columnHeaderValHex)
        Me.listViewModbusCur.Location = New System.Drawing.Point(3, 41)
        Me.listViewModbusCur.Name = "listViewModbusCur"
        Me.listViewModbusCur.Size = New System.Drawing.Size(319, 314)
        Me.listViewModbusCur.TabIndex = 7
        Me.listViewModbusCur.View = System.Windows.Forms.View.Details
        '
        'columnHeaderLocation
        '
        Me.columnHeaderLocation.Text = "Location"
        Me.columnHeaderLocation.Width = 67
        '
        'columnHeaderType
        '
        Me.columnHeaderType.Text = "Type"
        Me.columnHeaderType.Width = 59
        '
        'columnHeaderValDec
        '
        Me.columnHeaderValDec.Text = "Value[Dec]"
        Me.columnHeaderValDec.Width = 86
        '
        'columnHeaderValHex
        '
        Me.columnHeaderValHex.Text = "Value[Hex]"
        Me.columnHeaderValHex.Width = 93
        '
        'txtStatus
        '
        Me.txtStatus.Location = New System.Drawing.Point(3, 13)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(319, 23)
        Me.txtStatus.TabIndex = 6
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(415, 361)
        Me.Controls.Add(Me.buttonStart)
        Me.Controls.Add(Me.listViewModbusCur)
        Me.Controls.Add(Me.txtStatus)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Text = "ModbusRTU Sample Program (VB)"
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents buttonStart As System.Windows.Forms.Button
    Private WithEvents listViewModbusCur As System.Windows.Forms.ListView
    Private WithEvents columnHeaderLocation As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeaderType As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeaderValDec As System.Windows.Forms.ColumnHeader
    Private WithEvents columnHeaderValHex As System.Windows.Forms.ColumnHeader
    Private WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
