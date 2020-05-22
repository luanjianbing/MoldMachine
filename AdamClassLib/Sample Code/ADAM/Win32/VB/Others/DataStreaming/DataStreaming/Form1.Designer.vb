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
        Me.listBoxMsg = New System.Windows.Forms.ListBox
        Me.btnStart = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'listBoxMsg
        '
        Me.listBoxMsg.FormattingEnabled = True
        Me.listBoxMsg.ItemHeight = 12
        Me.listBoxMsg.Location = New System.Drawing.Point(3, 39)
        Me.listBoxMsg.Name = "listBoxMsg"
        Me.listBoxMsg.Size = New System.Drawing.Size(492, 376)
        Me.listBoxMsg.TabIndex = 1
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(407, 7)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(88, 24)
        Me.btnStart.TabIndex = 5
        Me.btnStart.Text = "Start"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(499, 422)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.listBoxMsg)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Text = "DataStreaming sample (VB)"
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents listBoxMsg As System.Windows.Forms.ListBox
    Private WithEvents btnStart As System.Windows.Forms.Button

End Class
