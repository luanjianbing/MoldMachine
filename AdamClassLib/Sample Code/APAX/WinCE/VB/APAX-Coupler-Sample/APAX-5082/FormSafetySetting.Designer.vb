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
        Me.rdbtnOff.Location = New System.Drawing.Point(112, 284)
        Me.rdbtnOff.Name = "rdbtnOff"
        Me.rdbtnOff.Size = New System.Drawing.Size(48, 20)
        Me.rdbtnOff.TabIndex = 20
        Me.rdbtnOff.Text = "Off"
        '
        'rdbtnOn
        '
        Me.rdbtnOn.Location = New System.Drawing.Point(64, 284)
        Me.rdbtnOn.Name = "rdbtnOn"
        Me.rdbtnOn.Size = New System.Drawing.Size(48, 20)
        Me.rdbtnOn.TabIndex = 21
        Me.rdbtnOn.Text = "On"
        '
        'chbxSelecteAll
        '
        Me.chbxSelecteAll.Location = New System.Drawing.Point(60, 312)
        Me.chbxSelecteAll.Name = "chbxSelecteAll"
        Me.chbxSelecteAll.Size = New System.Drawing.Size(84, 20)
        Me.chbxSelecteAll.TabIndex = 22
        Me.chbxSelecteAll.Text = "ApplyAll"
        '
        'btnApply
        '
        Me.btnApply.Location = New System.Drawing.Point(156, 340)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(72, 20)
        Me.btnApply.TabIndex = 23
        Me.btnApply.Text = "Apply"
        '
        'txtChannel
        '
        Me.txtChannel.Enabled = False
        Me.txtChannel.Location = New System.Drawing.Point(64, 252)
        Me.txtChannel.Name = "txtChannel"
        Me.txtChannel.Size = New System.Drawing.Size(60, 23)
        Me.txtChannel.TabIndex = 24
        '
        'labSafety
        '
        Me.labSafety.Location = New System.Drawing.Point(0, 284)
        Me.labSafety.Name = "labSafety"
        Me.labSafety.Size = New System.Drawing.Size(64, 20)
        Me.labSafety.Text = "Value"
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(0, 256)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(64, 20)
        Me.label2.Text = "Channel"
        '
        'btnSet
        '
        Me.btnSet.Location = New System.Drawing.Point(156, 312)
        Me.btnSet.Name = "btnSet"
        Me.btnSet.Size = New System.Drawing.Size(72, 20)
        Me.btnSet.TabIndex = 27
        Me.btnSet.Text = "Set"
        '
        'gridviewSafety
        '
        Me.gridviewSafety.Columns.Add(Me.clmCh)
        Me.gridviewSafety.Columns.Add(Me.clmSafetyStat)
        Me.gridviewSafety.FullRowSelect = True
        Me.gridviewSafety.Location = New System.Drawing.Point(0, 0)
        Me.gridviewSafety.Name = "gridviewSafety"
        Me.gridviewSafety.Size = New System.Drawing.Size(232, 244)
        Me.gridviewSafety.TabIndex = 19
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
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(233, 370)
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
        Me.ResumeLayout(False)

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
