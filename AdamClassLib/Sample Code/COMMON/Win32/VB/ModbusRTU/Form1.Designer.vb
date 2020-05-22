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
        Me.buttonStart = New System.Windows.Forms.Button
        Me.listViewModbusCur = New System.Windows.Forms.ListView
        Me.columnHeaderLocation = New System.Windows.Forms.ColumnHeader
        Me.columnHeaderType = New System.Windows.Forms.ColumnHeader
        Me.columnHeaderValDec = New System.Windows.Forms.ColumnHeader
        Me.columnHeaderValHex = New System.Windows.Forms.ColumnHeader
        Me.txtStatus = New System.Windows.Forms.TextBox
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'buttonStart
        '
        Me.buttonStart.Location = New System.Drawing.Point(337, 10)
        Me.buttonStart.Name = "buttonStart"
        Me.buttonStart.Size = New System.Drawing.Size(75, 23)
        Me.buttonStart.TabIndex = 5
        Me.buttonStart.Text = "Start"
        Me.buttonStart.UseVisualStyleBackColor = True
        '
        'listViewModbusCur
        '
        Me.listViewModbusCur.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnHeaderLocation, Me.columnHeaderType, Me.columnHeaderValDec, Me.columnHeaderValHex})
        Me.listViewModbusCur.Location = New System.Drawing.Point(12, 40)
        Me.listViewModbusCur.Name = "listViewModbusCur"
        Me.listViewModbusCur.Size = New System.Drawing.Size(319, 314)
        Me.listViewModbusCur.TabIndex = 4
        Me.listViewModbusCur.UseCompatibleStateImageBehavior = False
        Me.listViewModbusCur.View = System.Windows.Forms.View.Details
        '
        'columnHeaderLocation
        '
        Me.columnHeaderLocation.Text = "Location"
        Me.columnHeaderLocation.Width = 64
        '
        'columnHeaderType
        '
        Me.columnHeaderType.Text = "Type"
        '
        'columnHeaderValDec
        '
        Me.columnHeaderValDec.Text = "Value[Dec]"
        Me.columnHeaderValDec.Width = 81
        '
        'columnHeaderValHex
        '
        Me.columnHeaderValHex.Text = "Value[Hex]"
        Me.columnHeaderValHex.Width = 89
        '
        'txtStatus
        '
        Me.txtStatus.Location = New System.Drawing.Point(12, 12)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(319, 22)
        Me.txtStatus.TabIndex = 3
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(423, 365)
        Me.Controls.Add(Me.buttonStart)
        Me.Controls.Add(Me.listViewModbusCur)
        Me.Controls.Add(Me.txtStatus)
        Me.Name = "Form1"
        Me.Text = "ModbusRTU sample program (VB)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
