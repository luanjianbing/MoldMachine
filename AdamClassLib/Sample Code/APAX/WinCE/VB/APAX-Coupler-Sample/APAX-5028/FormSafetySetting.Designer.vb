<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class FormSafetySetting
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
        Me.txtSafetyVal = New System.Windows.Forms.TextBox
        Me.labSafety = New System.Windows.Forms.Label
        Me.btnApply = New System.Windows.Forms.Button
        Me.btnSet = New System.Windows.Forms.Button
        Me.txtChannel = New System.Windows.Forms.TextBox
        Me.label2 = New System.Windows.Forms.Label
        Me.gridviewSafety = New System.Windows.Forms.ListView
        Me.clmCh = New System.Windows.Forms.ColumnHeader
        Me.clmSafetyValue = New System.Windows.Forms.ColumnHeader
        Me.labRange = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'txtSafetyVal
        '
        Me.txtSafetyVal.Location = New System.Drawing.Point(73, 283)
        Me.txtSafetyVal.Name = "txtSafetyVal"
        Me.txtSafetyVal.Size = New System.Drawing.Size(60, 23)
        Me.txtSafetyVal.TabIndex = 39
        '
        'labSafety
        '
        Me.labSafety.Location = New System.Drawing.Point(9, 286)
        Me.labSafety.Name = "labSafety"
        Me.labSafety.Size = New System.Drawing.Size(64, 20)
        Me.labSafety.Text = "Value"
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(169, 311)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(72, 20)
        Me.btnApply.TabIndex = 37
        Me.btnApply.Text = "Apply"
        '
        'btnSet
        '
        Me.btnSet.Location = New System.Drawing.Point(169, 283)
        Me.btnSet.Name = "btnSet"
        Me.btnSet.Size = New System.Drawing.Size(72, 20)
        Me.btnSet.TabIndex = 38
        Me.btnSet.Text = "Set"
        '
        'txtChannel
        '
        Me.txtChannel.Enabled = False
        Me.txtChannel.Location = New System.Drawing.Point(73, 251)
        Me.txtChannel.Name = "txtChannel"
        Me.txtChannel.Size = New System.Drawing.Size(60, 23)
        Me.txtChannel.TabIndex = 36
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(9, 255)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(64, 20)
        Me.label2.Text = "Channel"
        '
        'gridviewSafety
        '
        Me.gridviewSafety.Columns.Add(Me.clmCh)
        Me.gridviewSafety.Columns.Add(Me.clmSafetyValue)
        Me.gridviewSafety.FullRowSelect = True
        Me.gridviewSafety.Location = New System.Drawing.Point(9, 3)
        Me.gridviewSafety.Name = "gridviewSafety"
        Me.gridviewSafety.Size = New System.Drawing.Size(230, 244)
        Me.gridviewSafety.TabIndex = 35
        Me.gridviewSafety.View = System.Windows.Forms.View.Details
        '
        'clmCh
        '
        Me.clmCh.Text = "Channel"
        Me.clmCh.Width = 100
        '
        'clmSafetyValue
        '
        Me.clmSafetyValue.Text = "Safety Value"
        Me.clmSafetyValue.Width = 120
        '
        'labRange
        '
        Me.labRange.Location = New System.Drawing.Point(139, 255)
        Me.labRange.Name = "labRange"
        Me.labRange.Size = New System.Drawing.Size(100, 20)
        '
        'FormSafetySetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(251, 348)
        Me.Controls.Add(Me.labRange)
        Me.Controls.Add(Me.txtSafetyVal)
        Me.Controls.Add(Me.labSafety)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.btnSet)
        Me.Controls.Add(Me.txtChannel)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.gridviewSafety)
        Me.Name = "FormSafetySetting"
        Me.Text = "FormSafetySetting"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents txtSafetyVal As System.Windows.Forms.TextBox
    Private WithEvents labSafety As System.Windows.Forms.Label
    Private WithEvents btnApply As System.Windows.Forms.Button
    Private WithEvents btnSet As System.Windows.Forms.Button
    Private WithEvents txtChannel As System.Windows.Forms.TextBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents gridviewSafety As System.Windows.Forms.ListView
    Private WithEvents clmCh As System.Windows.Forms.ColumnHeader
    Private WithEvents clmSafetyValue As System.Windows.Forms.ColumnHeader
    Private WithEvents labRange As System.Windows.Forms.Label
End Class
