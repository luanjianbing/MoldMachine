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
        Me.btnStart = New System.Windows.Forms.Button
        Me.listBoxMsg = New System.Windows.Forms.ListBox
        Me.SuspendLayout()
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(414, 16)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(88, 24)
        Me.btnStart.TabIndex = 7
        Me.btnStart.Text = "Start"
        '
        'listBoxMsg
        '
        Me.listBoxMsg.Location = New System.Drawing.Point(10, 48)
        Me.listBoxMsg.Name = "listBoxMsg"
        Me.listBoxMsg.Size = New System.Drawing.Size(492, 370)
        Me.listBoxMsg.TabIndex = 6
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(513, 435)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.listBoxMsg)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Text = "DataStreaming Sample (VB)"
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents btnStart As System.Windows.Forms.Button
    Private WithEvents listBoxMsg As System.Windows.Forms.ListBox

End Class
