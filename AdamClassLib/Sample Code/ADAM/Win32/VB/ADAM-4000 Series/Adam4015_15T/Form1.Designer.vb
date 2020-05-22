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
        Me.txtAIValue5 = New System.Windows.Forms.TextBox
        Me.txtAIValue4 = New System.Windows.Forms.TextBox
        Me.txtAIValue3 = New System.Windows.Forms.TextBox
        Me.txtAIValue2 = New System.Windows.Forms.TextBox
        Me.txtAIValue1 = New System.Windows.Forms.TextBox
        Me.txtAIValue0 = New System.Windows.Forms.TextBox
        Me.txtReadCount = New System.Windows.Forms.TextBox
        Me.txtModule = New System.Windows.Forms.TextBox
        Me.chkboxCh5 = New System.Windows.Forms.CheckBox
        Me.chkboxCh4 = New System.Windows.Forms.CheckBox
        Me.chkboxCh3 = New System.Windows.Forms.CheckBox
        Me.chkboxCh2 = New System.Windows.Forms.CheckBox
        Me.chkboxCh1 = New System.Windows.Forms.CheckBox
        Me.chkboxCh0 = New System.Windows.Forms.CheckBox
        Me.label2 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'buttonStart
        '
        Me.buttonStart.Location = New System.Drawing.Point(257, 12)
        Me.buttonStart.Name = "buttonStart"
        Me.buttonStart.Size = New System.Drawing.Size(75, 23)
        Me.buttonStart.TabIndex = 33
        Me.buttonStart.Text = "Start"
        Me.buttonStart.UseVisualStyleBackColor = True
        '
        'txtAIValue5
        '
        Me.txtAIValue5.Location = New System.Drawing.Point(103, 268)
        Me.txtAIValue5.Name = "txtAIValue5"
        Me.txtAIValue5.Size = New System.Drawing.Size(119, 22)
        Me.txtAIValue5.TabIndex = 32
        '
        'txtAIValue4
        '
        Me.txtAIValue4.Location = New System.Drawing.Point(103, 230)
        Me.txtAIValue4.Name = "txtAIValue4"
        Me.txtAIValue4.Size = New System.Drawing.Size(119, 22)
        Me.txtAIValue4.TabIndex = 31
        '
        'txtAIValue3
        '
        Me.txtAIValue3.Location = New System.Drawing.Point(103, 193)
        Me.txtAIValue3.Name = "txtAIValue3"
        Me.txtAIValue3.Size = New System.Drawing.Size(119, 22)
        Me.txtAIValue3.TabIndex = 30
        '
        'txtAIValue2
        '
        Me.txtAIValue2.Location = New System.Drawing.Point(103, 156)
        Me.txtAIValue2.Name = "txtAIValue2"
        Me.txtAIValue2.Size = New System.Drawing.Size(119, 22)
        Me.txtAIValue2.TabIndex = 29
        '
        'txtAIValue1
        '
        Me.txtAIValue1.Location = New System.Drawing.Point(103, 121)
        Me.txtAIValue1.Name = "txtAIValue1"
        Me.txtAIValue1.Size = New System.Drawing.Size(119, 22)
        Me.txtAIValue1.TabIndex = 28
        '
        'txtAIValue0
        '
        Me.txtAIValue0.Location = New System.Drawing.Point(103, 85)
        Me.txtAIValue0.Name = "txtAIValue0"
        Me.txtAIValue0.Size = New System.Drawing.Size(119, 22)
        Me.txtAIValue0.TabIndex = 27
        '
        'txtReadCount
        '
        Me.txtReadCount.Location = New System.Drawing.Point(103, 39)
        Me.txtReadCount.Name = "txtReadCount"
        Me.txtReadCount.ReadOnly = True
        Me.txtReadCount.Size = New System.Drawing.Size(119, 22)
        Me.txtReadCount.TabIndex = 26
        Me.txtReadCount.Text = "0"
        '
        'txtModule
        '
        Me.txtModule.Location = New System.Drawing.Point(103, 6)
        Me.txtModule.Name = "txtModule"
        Me.txtModule.Size = New System.Drawing.Size(119, 22)
        Me.txtModule.TabIndex = 25
        '
        'chkboxCh5
        '
        Me.chkboxCh5.AutoSize = True
        Me.chkboxCh5.Enabled = False
        Me.chkboxCh5.Location = New System.Drawing.Point(14, 270)
        Me.chkboxCh5.Name = "chkboxCh5"
        Me.chkboxCh5.Size = New System.Drawing.Size(77, 16)
        Me.chkboxCh5.TabIndex = 24
        Me.chkboxCh5.Text = "AI-5 value:"
        Me.chkboxCh5.UseVisualStyleBackColor = True
        '
        'chkboxCh4
        '
        Me.chkboxCh4.AutoSize = True
        Me.chkboxCh4.Enabled = False
        Me.chkboxCh4.Location = New System.Drawing.Point(14, 232)
        Me.chkboxCh4.Name = "chkboxCh4"
        Me.chkboxCh4.Size = New System.Drawing.Size(77, 16)
        Me.chkboxCh4.TabIndex = 23
        Me.chkboxCh4.Text = "AI-4 value:"
        Me.chkboxCh4.UseVisualStyleBackColor = True
        '
        'chkboxCh3
        '
        Me.chkboxCh3.AutoSize = True
        Me.chkboxCh3.Enabled = False
        Me.chkboxCh3.Location = New System.Drawing.Point(14, 195)
        Me.chkboxCh3.Name = "chkboxCh3"
        Me.chkboxCh3.Size = New System.Drawing.Size(77, 16)
        Me.chkboxCh3.TabIndex = 22
        Me.chkboxCh3.Text = "AI-3 value:"
        Me.chkboxCh3.UseVisualStyleBackColor = True
        '
        'chkboxCh2
        '
        Me.chkboxCh2.AutoSize = True
        Me.chkboxCh2.Enabled = False
        Me.chkboxCh2.Location = New System.Drawing.Point(14, 158)
        Me.chkboxCh2.Name = "chkboxCh2"
        Me.chkboxCh2.Size = New System.Drawing.Size(77, 16)
        Me.chkboxCh2.TabIndex = 21
        Me.chkboxCh2.Text = "AI-2 value:"
        Me.chkboxCh2.UseVisualStyleBackColor = True
        '
        'chkboxCh1
        '
        Me.chkboxCh1.AutoSize = True
        Me.chkboxCh1.Enabled = False
        Me.chkboxCh1.Location = New System.Drawing.Point(14, 123)
        Me.chkboxCh1.Name = "chkboxCh1"
        Me.chkboxCh1.Size = New System.Drawing.Size(77, 16)
        Me.chkboxCh1.TabIndex = 20
        Me.chkboxCh1.Text = "AI-1 value:"
        Me.chkboxCh1.UseVisualStyleBackColor = True
        '
        'chkboxCh0
        '
        Me.chkboxCh0.AutoSize = True
        Me.chkboxCh0.Enabled = False
        Me.chkboxCh0.Location = New System.Drawing.Point(14, 87)
        Me.chkboxCh0.Name = "chkboxCh0"
        Me.chkboxCh0.Size = New System.Drawing.Size(77, 16)
        Me.chkboxCh0.TabIndex = 19
        Me.chkboxCh0.Text = "AI-0 value:"
        Me.chkboxCh0.UseVisualStyleBackColor = True
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(12, 42)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(61, 12)
        Me.label2.TabIndex = 18
        Me.label2.Text = "Read count:"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(12, 9)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(72, 12)
        Me.label1.TabIndex = 17
        Me.label1.Text = "Module name:"
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(342, 302)
        Me.Controls.Add(Me.buttonStart)
        Me.Controls.Add(Me.txtAIValue5)
        Me.Controls.Add(Me.txtAIValue4)
        Me.Controls.Add(Me.txtAIValue3)
        Me.Controls.Add(Me.txtAIValue2)
        Me.Controls.Add(Me.txtAIValue1)
        Me.Controls.Add(Me.txtAIValue0)
        Me.Controls.Add(Me.txtReadCount)
        Me.Controls.Add(Me.txtModule)
        Me.Controls.Add(Me.chkboxCh5)
        Me.Controls.Add(Me.chkboxCh4)
        Me.Controls.Add(Me.chkboxCh3)
        Me.Controls.Add(Me.chkboxCh2)
        Me.Controls.Add(Me.chkboxCh1)
        Me.Controls.Add(Me.chkboxCh0)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Form1"
        Me.Text = "Adam4015_15T sample program (VB)"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents buttonStart As System.Windows.Forms.Button
    Private WithEvents txtAIValue5 As System.Windows.Forms.TextBox
    Private WithEvents txtAIValue4 As System.Windows.Forms.TextBox
    Private WithEvents txtAIValue3 As System.Windows.Forms.TextBox
    Private WithEvents txtAIValue2 As System.Windows.Forms.TextBox
    Private WithEvents txtAIValue1 As System.Windows.Forms.TextBox
    Private WithEvents txtAIValue0 As System.Windows.Forms.TextBox
    Private WithEvents txtReadCount As System.Windows.Forms.TextBox
    Private WithEvents txtModule As System.Windows.Forms.TextBox
    Private WithEvents chkboxCh5 As System.Windows.Forms.CheckBox
    Private WithEvents chkboxCh4 As System.Windows.Forms.CheckBox
    Private WithEvents chkboxCh3 As System.Windows.Forms.CheckBox
    Private WithEvents chkboxCh2 As System.Windows.Forms.CheckBox
    Private WithEvents chkboxCh1 As System.Windows.Forms.CheckBox
    Private WithEvents chkboxCh0 As System.Windows.Forms.CheckBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
