﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.txtAOValue = New System.Windows.Forms.TextBox
        Me.txtReadCount = New System.Windows.Forms.TextBox
        Me.txtModule = New System.Windows.Forms.TextBox
        Me.label4 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.panelAO = New System.Windows.Forms.Panel
        Me.btnApplyOutput = New System.Windows.Forms.Button
        Me.txtOutputValue = New System.Windows.Forms.TextBox
        Me.label7 = New System.Windows.Forms.Label
        Me.lblHigh = New System.Windows.Forms.Label
        Me.lblLow = New System.Windows.Forms.Label
        Me.trackBar1 = New System.Windows.Forms.TrackBar
        Me.Timer1 = New System.Windows.Forms.Timer
        Me.panelAO.SuspendLayout()
        Me.SuspendLayout()
        '
        'buttonStart
        '
        Me.buttonStart.Location = New System.Drawing.Point(264, 11)
        Me.buttonStart.Name = "buttonStart"
        Me.buttonStart.Size = New System.Drawing.Size(75, 23)
        Me.buttonStart.TabIndex = 33
        Me.buttonStart.Text = "Start"
        '
        'txtAOValue
        '
        Me.txtAOValue.Location = New System.Drawing.Point(129, 77)
        Me.txtAOValue.Name = "txtAOValue"
        Me.txtAOValue.Size = New System.Drawing.Size(121, 23)
        Me.txtAOValue.TabIndex = 32
        '
        'txtReadCount
        '
        Me.txtReadCount.Location = New System.Drawing.Point(129, 42)
        Me.txtReadCount.Name = "txtReadCount"
        Me.txtReadCount.ReadOnly = True
        Me.txtReadCount.Size = New System.Drawing.Size(121, 23)
        Me.txtReadCount.TabIndex = 31
        Me.txtReadCount.Text = "0"
        '
        'txtModule
        '
        Me.txtModule.Location = New System.Drawing.Point(129, 8)
        Me.txtModule.Name = "txtModule"
        Me.txtModule.Size = New System.Drawing.Size(121, 23)
        Me.txtModule.TabIndex = 30
        '
        'label4
        '
        Me.label4.Location = New System.Drawing.Point(0, 80)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(136, 20)
        Me.label4.Text = "Analog output value:"
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(0, 45)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(83, 20)
        Me.label2.Text = "Read count:"
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(0, 11)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(94, 20)
        Me.label1.Text = "Module name:"
        '
        'panelAO
        '
        Me.panelAO.BackColor = System.Drawing.Color.SkyBlue
        Me.panelAO.Controls.Add(Me.btnApplyOutput)
        Me.panelAO.Controls.Add(Me.txtOutputValue)
        Me.panelAO.Controls.Add(Me.label7)
        Me.panelAO.Controls.Add(Me.lblHigh)
        Me.panelAO.Controls.Add(Me.lblLow)
        Me.panelAO.Controls.Add(Me.trackBar1)
        Me.panelAO.Location = New System.Drawing.Point(2, 118)
        Me.panelAO.Name = "panelAO"
        Me.panelAO.Size = New System.Drawing.Size(337, 103)
        '
        'btnApplyOutput
        '
        Me.btnApplyOutput.Location = New System.Drawing.Point(233, 70)
        Me.btnApplyOutput.Name = "btnApplyOutput"
        Me.btnApplyOutput.Size = New System.Drawing.Size(93, 23)
        Me.btnApplyOutput.TabIndex = 5
        Me.btnApplyOutput.Text = "Apply output"
        '
        'txtOutputValue
        '
        Me.txtOutputValue.Location = New System.Drawing.Point(110, 70)
        Me.txtOutputValue.Name = "txtOutputValue"
        Me.txtOutputValue.ReadOnly = True
        Me.txtOutputValue.Size = New System.Drawing.Size(100, 23)
        Me.txtOutputValue.TabIndex = 4
        '
        'label7
        '
        Me.label7.Location = New System.Drawing.Point(12, 73)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(106, 18)
        Me.label7.Text = "Value to output:"
        '
        'lblHigh
        '
        Me.lblHigh.Location = New System.Drawing.Point(174, 36)
        Me.lblHigh.Name = "lblHigh"
        Me.lblHigh.Size = New System.Drawing.Size(33, 22)
        Me.lblHigh.Text = "10V"
        '
        'lblLow
        '
        Me.lblLow.Location = New System.Drawing.Point(12, 36)
        Me.lblLow.Name = "lblLow"
        Me.lblLow.Size = New System.Drawing.Size(31, 22)
        Me.lblLow.Text = "0V"
        '
        'trackBar1
        '
        Me.trackBar1.LargeChange = 16
        Me.trackBar1.Location = New System.Drawing.Point(3, 3)
        Me.trackBar1.Maximum = 4095
        Me.trackBar1.Name = "trackBar1"
        Me.trackBar1.Size = New System.Drawing.Size(204, 45)
        Me.trackBar1.TabIndex = 0
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
        Me.ClientSize = New System.Drawing.Size(341, 224)
        Me.Controls.Add(Me.buttonStart)
        Me.Controls.Add(Me.txtAOValue)
        Me.Controls.Add(Me.txtReadCount)
        Me.Controls.Add(Me.txtModule)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.panelAO)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Text = "Adam4021 Sample Program (VB)"
        Me.panelAO.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents buttonStart As System.Windows.Forms.Button
    Private WithEvents txtAOValue As System.Windows.Forms.TextBox
    Private WithEvents txtReadCount As System.Windows.Forms.TextBox
    Private WithEvents txtModule As System.Windows.Forms.TextBox
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents panelAO As System.Windows.Forms.Panel
    Private WithEvents btnApplyOutput As System.Windows.Forms.Button
    Private WithEvents txtOutputValue As System.Windows.Forms.TextBox
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents lblHigh As System.Windows.Forms.Label
    Private WithEvents lblLow As System.Windows.Forms.Label
    Private WithEvents trackBar1 As System.Windows.Forms.TrackBar
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
