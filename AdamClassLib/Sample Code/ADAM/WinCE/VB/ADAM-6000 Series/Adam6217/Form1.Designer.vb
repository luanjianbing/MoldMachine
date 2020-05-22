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
        Me.Timer1 = New System.Windows.Forms.Timer
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtModule = New System.Windows.Forms.TextBox
        Me.txtReadCount = New System.Windows.Forms.TextBox
        Me.buttonStart = New System.Windows.Forms.Button
        Me.chkboxCh0 = New System.Windows.Forms.CheckBox
        Me.chkboxCh1 = New System.Windows.Forms.CheckBox
        Me.chkboxCh2 = New System.Windows.Forms.CheckBox
        Me.chkboxCh3 = New System.Windows.Forms.CheckBox
        Me.chkboxCh4 = New System.Windows.Forms.CheckBox
        Me.chkboxCh5 = New System.Windows.Forms.CheckBox
        Me.chkboxCh6 = New System.Windows.Forms.CheckBox
        Me.chkboxCh7 = New System.Windows.Forms.CheckBox
        Me.txtAIValue0 = New System.Windows.Forms.TextBox
        Me.txtAIValue1 = New System.Windows.Forms.TextBox
        Me.txtAIValue2 = New System.Windows.Forms.TextBox
        Me.txtAIValue3 = New System.Windows.Forms.TextBox
        Me.txtAIValue4 = New System.Windows.Forms.TextBox
        Me.txtAIValue5 = New System.Windows.Forms.TextBox
        Me.txtAIValue6 = New System.Windows.Forms.TextBox
        Me.txtAIValue7 = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(33, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 20)
        Me.Label1.Text = "Module name:"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(33, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(136, 20)
        Me.Label2.Text = "Read count:"
        '
        'txtModule
        '
        Me.txtModule.Location = New System.Drawing.Point(185, 20)
        Me.txtModule.Name = "txtModule"
        Me.txtModule.Size = New System.Drawing.Size(176, 23)
        Me.txtModule.TabIndex = 2
        '
        'txtReadCount
        '
        Me.txtReadCount.Location = New System.Drawing.Point(185, 52)
        Me.txtReadCount.Name = "txtReadCount"
        Me.txtReadCount.Size = New System.Drawing.Size(176, 23)
        Me.txtReadCount.TabIndex = 3
        Me.txtReadCount.Text = "0"
        '
        'buttonStart
        '
        Me.buttonStart.Location = New System.Drawing.Point(385, 20)
        Me.buttonStart.Name = "buttonStart"
        Me.buttonStart.Size = New System.Drawing.Size(95, 47)
        Me.buttonStart.TabIndex = 4
        Me.buttonStart.Text = "Start"
        '
        'chkboxCh0
        '
        Me.chkboxCh0.Enabled = False
        Me.chkboxCh0.Location = New System.Drawing.Point(33, 100)
        Me.chkboxCh0.Name = "chkboxCh0"
        Me.chkboxCh0.Size = New System.Drawing.Size(136, 20)
        Me.chkboxCh0.TabIndex = 5
        Me.chkboxCh0.Text = "AI-0 value:"
        '
        'chkboxCh1
        '
        Me.chkboxCh1.Enabled = False
        Me.chkboxCh1.Location = New System.Drawing.Point(33, 132)
        Me.chkboxCh1.Name = "chkboxCh1"
        Me.chkboxCh1.Size = New System.Drawing.Size(136, 20)
        Me.chkboxCh1.TabIndex = 6
        Me.chkboxCh1.Text = "AI-1 value:"
        '
        'chkboxCh2
        '
        Me.chkboxCh2.Enabled = False
        Me.chkboxCh2.Location = New System.Drawing.Point(33, 164)
        Me.chkboxCh2.Name = "chkboxCh2"
        Me.chkboxCh2.Size = New System.Drawing.Size(136, 20)
        Me.chkboxCh2.TabIndex = 7
        Me.chkboxCh2.Text = "AI-2 value:"
        '
        'chkboxCh3
        '
        Me.chkboxCh3.Enabled = False
        Me.chkboxCh3.Location = New System.Drawing.Point(33, 196)
        Me.chkboxCh3.Name = "chkboxCh3"
        Me.chkboxCh3.Size = New System.Drawing.Size(136, 20)
        Me.chkboxCh3.TabIndex = 8
        Me.chkboxCh3.Text = "AI-3 value:"
        '
        'chkboxCh4
        '
        Me.chkboxCh4.Enabled = False
        Me.chkboxCh4.Location = New System.Drawing.Point(33, 228)
        Me.chkboxCh4.Name = "chkboxCh4"
        Me.chkboxCh4.Size = New System.Drawing.Size(136, 20)
        Me.chkboxCh4.TabIndex = 9
        Me.chkboxCh4.Text = "AI-4 value:"
        '
        'chkboxCh5
        '
        Me.chkboxCh5.Enabled = False
        Me.chkboxCh5.Location = New System.Drawing.Point(33, 260)
        Me.chkboxCh5.Name = "chkboxCh5"
        Me.chkboxCh5.Size = New System.Drawing.Size(136, 20)
        Me.chkboxCh5.TabIndex = 10
        Me.chkboxCh5.Text = "AI-5 value:"
        '
        'chkboxCh6
        '
        Me.chkboxCh6.Enabled = False
        Me.chkboxCh6.Location = New System.Drawing.Point(33, 292)
        Me.chkboxCh6.Name = "chkboxCh6"
        Me.chkboxCh6.Size = New System.Drawing.Size(136, 20)
        Me.chkboxCh6.TabIndex = 11
        Me.chkboxCh6.Text = "AI-6 value:"
        '
        'chkboxCh7
        '
        Me.chkboxCh7.Enabled = False
        Me.chkboxCh7.Location = New System.Drawing.Point(33, 324)
        Me.chkboxCh7.Name = "chkboxCh7"
        Me.chkboxCh7.Size = New System.Drawing.Size(136, 20)
        Me.chkboxCh7.TabIndex = 12
        Me.chkboxCh7.Text = "AI-7 value:"
        '
        'txtAIValue0
        '
        Me.txtAIValue0.Location = New System.Drawing.Point(185, 100)
        Me.txtAIValue0.Name = "txtAIValue0"
        Me.txtAIValue0.Size = New System.Drawing.Size(176, 23)
        Me.txtAIValue0.TabIndex = 13
        '
        'txtAIValue1
        '
        Me.txtAIValue1.Location = New System.Drawing.Point(185, 132)
        Me.txtAIValue1.Name = "txtAIValue1"
        Me.txtAIValue1.Size = New System.Drawing.Size(176, 23)
        Me.txtAIValue1.TabIndex = 14
        '
        'txtAIValue2
        '
        Me.txtAIValue2.Location = New System.Drawing.Point(185, 164)
        Me.txtAIValue2.Name = "txtAIValue2"
        Me.txtAIValue2.Size = New System.Drawing.Size(176, 23)
        Me.txtAIValue2.TabIndex = 15
        '
        'txtAIValue3
        '
        Me.txtAIValue3.Location = New System.Drawing.Point(185, 196)
        Me.txtAIValue3.Name = "txtAIValue3"
        Me.txtAIValue3.Size = New System.Drawing.Size(176, 23)
        Me.txtAIValue3.TabIndex = 16
        '
        'txtAIValue4
        '
        Me.txtAIValue4.Location = New System.Drawing.Point(185, 228)
        Me.txtAIValue4.Name = "txtAIValue4"
        Me.txtAIValue4.Size = New System.Drawing.Size(176, 23)
        Me.txtAIValue4.TabIndex = 17
        '
        'txtAIValue5
        '
        Me.txtAIValue5.Location = New System.Drawing.Point(185, 260)
        Me.txtAIValue5.Name = "txtAIValue5"
        Me.txtAIValue5.Size = New System.Drawing.Size(176, 23)
        Me.txtAIValue5.TabIndex = 18
        '
        'txtAIValue6
        '
        Me.txtAIValue6.Location = New System.Drawing.Point(185, 292)
        Me.txtAIValue6.Name = "txtAIValue6"
        Me.txtAIValue6.Size = New System.Drawing.Size(176, 23)
        Me.txtAIValue6.TabIndex = 19
        '
        'txtAIValue7
        '
        Me.txtAIValue7.Location = New System.Drawing.Point(185, 324)
        Me.txtAIValue7.Name = "txtAIValue7"
        Me.txtAIValue7.Size = New System.Drawing.Size(176, 23)
        Me.txtAIValue7.TabIndex = 20
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(526, 379)
        Me.Controls.Add(Me.txtAIValue7)
        Me.Controls.Add(Me.txtAIValue6)
        Me.Controls.Add(Me.txtAIValue5)
        Me.Controls.Add(Me.txtAIValue4)
        Me.Controls.Add(Me.txtAIValue3)
        Me.Controls.Add(Me.txtAIValue2)
        Me.Controls.Add(Me.txtAIValue1)
        Me.Controls.Add(Me.txtAIValue0)
        Me.Controls.Add(Me.chkboxCh7)
        Me.Controls.Add(Me.chkboxCh6)
        Me.Controls.Add(Me.chkboxCh5)
        Me.Controls.Add(Me.chkboxCh4)
        Me.Controls.Add(Me.chkboxCh3)
        Me.Controls.Add(Me.chkboxCh2)
        Me.Controls.Add(Me.chkboxCh1)
        Me.Controls.Add(Me.chkboxCh0)
        Me.Controls.Add(Me.buttonStart)
        Me.Controls.Add(Me.txtReadCount)
        Me.Controls.Add(Me.txtModule)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Text = "Adam6217 sample program (VB)"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtModule As System.Windows.Forms.TextBox
    Friend WithEvents txtReadCount As System.Windows.Forms.TextBox
    Friend WithEvents buttonStart As System.Windows.Forms.Button
    Friend WithEvents chkboxCh0 As System.Windows.Forms.CheckBox
    Friend WithEvents chkboxCh1 As System.Windows.Forms.CheckBox
    Friend WithEvents chkboxCh2 As System.Windows.Forms.CheckBox
    Friend WithEvents chkboxCh3 As System.Windows.Forms.CheckBox
    Friend WithEvents chkboxCh4 As System.Windows.Forms.CheckBox
    Friend WithEvents chkboxCh5 As System.Windows.Forms.CheckBox
    Friend WithEvents chkboxCh6 As System.Windows.Forms.CheckBox
    Friend WithEvents chkboxCh7 As System.Windows.Forms.CheckBox
    Friend WithEvents txtAIValue0 As System.Windows.Forms.TextBox
    Friend WithEvents txtAIValue1 As System.Windows.Forms.TextBox
    Friend WithEvents txtAIValue2 As System.Windows.Forms.TextBox
    Friend WithEvents txtAIValue3 As System.Windows.Forms.TextBox
    Friend WithEvents txtAIValue4 As System.Windows.Forms.TextBox
    Friend WithEvents txtAIValue5 As System.Windows.Forms.TextBox
    Friend WithEvents txtAIValue6 As System.Windows.Forms.TextBox
    Friend WithEvents txtAIValue7 As System.Windows.Forms.TextBox

End Class
