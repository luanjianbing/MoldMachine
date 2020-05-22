<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSafetySetting
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
        Me.rdbtnOff = New System.Windows.Forms.RadioButton
        Me.rdbtnOn = New System.Windows.Forms.RadioButton
        Me.chbxSelecteAll = New System.Windows.Forms.CheckBox
        Me.btnApply = New System.Windows.Forms.Button
        Me.txtChannel = New System.Windows.Forms.TextBox
        Me.labSafety = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.btnSet = New System.Windows.Forms.Button
        Me.gridviewSafety = New System.Windows.Forms.ListView
        Me.clmCh = New System.Windows.Forms.ColumnHeader
        Me.clmSafetyStat = New System.Windows.Forms.ColumnHeader
        Me.SuspendLayout()
        '
        'rdbtnOff
        '
        Me.rdbtnOff.Location = New System.Drawing.Point(127, 305)
        Me.rdbtnOff.Name = "rdbtnOff"
        Me.rdbtnOff.Size = New System.Drawing.Size(48, 20)
        Me.rdbtnOff.TabIndex = 29
        Me.rdbtnOff.Text = "Off"
        '
        'rdbtnOn
        '
        Me.rdbtnOn.Location = New System.Drawing.Point(83, 305)
        Me.rdbtnOn.Name = "rdbtnOn"
        Me.rdbtnOn.Size = New System.Drawing.Size(48, 20)
        Me.rdbtnOn.TabIndex = 30
        Me.rdbtnOn.Text = "On"
        '
        'chbxSelecteAll
        '
        Me.chbxSelecteAll.Location = New System.Drawing.Point(83, 331)
        Me.chbxSelecteAll.Name = "chbxSelecteAll"
        Me.chbxSelecteAll.Size = New System.Drawing.Size(84, 20)
        Me.chbxSelecteAll.TabIndex = 31
        Me.chbxSelecteAll.Text = "ApplyAll"
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(172, 358)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(72, 20)
        Me.btnApply.TabIndex = 32
        Me.btnApply.Text = "Apply"
        '
        'txtChannel
        '
        Me.txtChannel.Enabled = False
        Me.txtChannel.Location = New System.Drawing.Point(83, 274)
        Me.txtChannel.Name = "txtChannel"
        Me.txtChannel.Size = New System.Drawing.Size(60, 22)
        Me.txtChannel.TabIndex = 33
        '
        'labSafety
        '
        Me.labSafety.Location = New System.Drawing.Point(31, 305)
        Me.labSafety.Name = "labSafety"
        Me.labSafety.Size = New System.Drawing.Size(64, 20)
        Me.labSafety.TabIndex = 34
        Me.labSafety.Text = "Value"
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(31, 277)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(64, 20)
        Me.label2.TabIndex = 35
        Me.label2.Text = "Channel"
        '
        'btnSet
        '
        Me.btnSet.Location = New System.Drawing.Point(172, 330)
        Me.btnSet.Name = "btnSet"
        Me.btnSet.Size = New System.Drawing.Size(72, 20)
        Me.btnSet.TabIndex = 36
        Me.btnSet.Text = "Set"
        '
        'gridviewSafety
        '
        Me.gridviewSafety.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.clmCh, Me.clmSafetyStat})
        Me.gridviewSafety.FullRowSelect = True
        Me.gridviewSafety.Location = New System.Drawing.Point(12, 12)
        Me.gridviewSafety.Name = "gridviewSafety"
        Me.gridviewSafety.Size = New System.Drawing.Size(232, 244)
        Me.gridviewSafety.TabIndex = 28
        Me.gridviewSafety.UseCompatibleStateImageBehavior = False
        Me.gridviewSafety.View = System.Windows.Forms.View.Details
        '
        'clmCh
        '
        Me.clmCh.Text = "Channel"
        Me.clmCh.Width = 100
        '
        'clmSafetyStat
        '
        Me.clmSafetyStat.Text = "Safety State"
        Me.clmSafetyStat.Width = 120
        '
        'FormSafetySetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(257, 388)
        Me.Controls.Add(Me.rdbtnOff)
        Me.Controls.Add(Me.rdbtnOn)
        Me.Controls.Add(Me.chbxSelecteAll)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.txtChannel)
        Me.Controls.Add(Me.labSafety)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.btnSet)
        Me.Controls.Add(Me.gridviewSafety)
        Me.Name = "FormSafetySetting"
        Me.Text = "FormSafetySetting"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents rdbtnOff As System.Windows.Forms.RadioButton
    Private WithEvents rdbtnOn As System.Windows.Forms.RadioButton
    Private WithEvents chbxSelecteAll As System.Windows.Forms.CheckBox
    Private WithEvents btnApply As System.Windows.Forms.Button
    Private WithEvents txtChannel As System.Windows.Forms.TextBox
    Private WithEvents labSafety As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents btnSet As System.Windows.Forms.Button
    Private WithEvents gridviewSafety As System.Windows.Forms.ListView
    Private WithEvents clmCh As System.Windows.Forms.ColumnHeader
    Private WithEvents clmSafetyStat As System.Windows.Forms.ColumnHeader
End Class
