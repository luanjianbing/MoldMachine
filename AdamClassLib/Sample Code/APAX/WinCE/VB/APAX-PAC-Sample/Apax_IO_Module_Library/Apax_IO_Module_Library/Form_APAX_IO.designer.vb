<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Form_APAX_IO
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
        Me.Panel_Info = New System.Windows.Forms.Panel
        Me.btn_Locate = New System.Windows.Forms.Button
        Me.lbl_Locate = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lbl_ModuleTitle = New System.Windows.Forms.Label
        Me.txtModule = New System.Windows.Forms.TextBox
        Me.txtKernelVer = New System.Windows.Forms.TextBox
        Me.txtID = New System.Windows.Forms.TextBox
        Me.txtFirmwareVer = New System.Windows.Forms.TextBox
        Me.lbl_SwitchTitle = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Btn_Search = New System.Windows.Forms.Button
        Me.Btn_Quit = New System.Windows.Forms.Button
        Me.panel_Remote = New System.Windows.Forms.Panel
        Me.StatusBar_IO = New System.Windows.Forms.StatusBar
        Me.Panel_Info.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel_Info
        '
        Me.Panel_Info.Controls.Add(Me.btn_Locate)
        Me.Panel_Info.Controls.Add(Me.lbl_Locate)
        Me.Panel_Info.Controls.Add(Me.Label1)
        Me.Panel_Info.Controls.Add(Me.lbl_ModuleTitle)
        Me.Panel_Info.Controls.Add(Me.txtModule)
        Me.Panel_Info.Controls.Add(Me.txtKernelVer)
        Me.Panel_Info.Controls.Add(Me.txtID)
        Me.Panel_Info.Controls.Add(Me.txtFirmwareVer)
        Me.Panel_Info.Controls.Add(Me.lbl_SwitchTitle)
        Me.Panel_Info.Controls.Add(Me.Label2)
        Me.Panel_Info.Enabled = False
        Me.Panel_Info.Location = New System.Drawing.Point(12, 15)
        Me.Panel_Info.Name = "Panel_Info"
        Me.Panel_Info.Size = New System.Drawing.Size(411, 87)
        '
        'btn_Locate
        '
        Me.btn_Locate.Location = New System.Drawing.Point(79, 61)
        Me.btn_Locate.Name = "btn_Locate"
        Me.btn_Locate.Size = New System.Drawing.Size(78, 23)
        Me.btn_Locate.TabIndex = 15
        Me.btn_Locate.Text = "Enable"
        '
        'lbl_Locate
        '
        Me.lbl_Locate.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbl_Locate.Location = New System.Drawing.Point(8, 61)
        Me.lbl_Locate.Name = "lbl_Locate"
        Me.lbl_Locate.Size = New System.Drawing.Size(73, 22)
        Me.lbl_Locate.Text = "Locate:"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.Location = New System.Drawing.Point(183, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 22)
        Me.Label1.Text = "Firmware Version:"
        '
        'lbl_ModuleTitle
        '
        Me.lbl_ModuleTitle.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbl_ModuleTitle.Location = New System.Drawing.Point(8, 11)
        Me.lbl_ModuleTitle.Name = "lbl_ModuleTitle"
        Me.lbl_ModuleTitle.Size = New System.Drawing.Size(61, 22)
        Me.lbl_ModuleTitle.Text = "Module:"
        '
        'txtModule
        '
        Me.txtModule.Location = New System.Drawing.Point(79, 10)
        Me.txtModule.Name = "txtModule"
        Me.txtModule.ReadOnly = True
        Me.txtModule.Size = New System.Drawing.Size(78, 23)
        Me.txtModule.TabIndex = 3
        '
        'txtKernelVer
        '
        Me.txtKernelVer.Location = New System.Drawing.Point(325, 36)
        Me.txtKernelVer.Name = "txtKernelVer"
        Me.txtKernelVer.ReadOnly = True
        Me.txtKernelVer.Size = New System.Drawing.Size(78, 23)
        Me.txtKernelVer.TabIndex = 12
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(79, 36)
        Me.txtID.Name = "txtID"
        Me.txtID.ReadOnly = True
        Me.txtID.Size = New System.Drawing.Size(78, 23)
        Me.txtID.TabIndex = 6
        '
        'txtFirmwareVer
        '
        Me.txtFirmwareVer.Location = New System.Drawing.Point(325, 10)
        Me.txtFirmwareVer.Name = "txtFirmwareVer"
        Me.txtFirmwareVer.ReadOnly = True
        Me.txtFirmwareVer.Size = New System.Drawing.Size(78, 23)
        Me.txtFirmwareVer.TabIndex = 11
        '
        'lbl_SwitchTitle
        '
        Me.lbl_SwitchTitle.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lbl_SwitchTitle.Location = New System.Drawing.Point(8, 37)
        Me.lbl_SwitchTitle.Name = "lbl_SwitchTitle"
        Me.lbl_SwitchTitle.Size = New System.Drawing.Size(73, 22)
        Me.lbl_SwitchTitle.Text = "Switch ID:"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.Location = New System.Drawing.Point(183, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(149, 22)
        Me.Label2.Text = "Support Kernel Version:"
        '
        'Btn_Search
        '
        Me.Btn_Search.Location = New System.Drawing.Point(257, 367)
        Me.Btn_Search.Name = "Btn_Search"
        Me.Btn_Search.Size = New System.Drawing.Size(80, 20)
        Me.Btn_Search.TabIndex = 22
        Me.Btn_Search.Text = "Search"
        '
        'Btn_Quit
        '
        Me.Btn_Quit.Location = New System.Drawing.Point(343, 367)
        Me.Btn_Quit.Name = "Btn_Quit"
        Me.Btn_Quit.Size = New System.Drawing.Size(80, 20)
        Me.Btn_Quit.TabIndex = 21
        Me.Btn_Quit.Text = "Quit"
        '
        'panel_Remote
        '
        Me.panel_Remote.BackColor = System.Drawing.Color.LightSkyBlue
        Me.panel_Remote.Enabled = False
        Me.panel_Remote.Location = New System.Drawing.Point(12, 112)
        Me.panel_Remote.Name = "panel_Remote"
        Me.panel_Remote.Size = New System.Drawing.Size(411, 236)
        '
        'StatusBar_IO
        '
        Me.StatusBar_IO.Location = New System.Drawing.Point(0, 391)
        Me.StatusBar_IO.Name = "StatusBar_IO"
        Me.StatusBar_IO.Size = New System.Drawing.Size(439, 24)
        '
        'Form_APAX_IO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.ClientSize = New System.Drawing.Size(439, 415)
        Me.Controls.Add(Me.StatusBar_IO)
        Me.Controls.Add(Me.panel_Remote)
        Me.Controls.Add(Me.Btn_Search)
        Me.Controls.Add(Me.Panel_Info)
        Me.Controls.Add(Me.Btn_Quit)
        Me.Name = "Form_APAX_IO"
        Me.Text = "APAX-50XX"
        Me.Panel_Info.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents lbl_Locate As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents lbl_ModuleTitle As System.Windows.Forms.Label
    Public WithEvents lbl_SwitchTitle As System.Windows.Forms.Label
    Public WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents Panel_Info As System.Windows.Forms.Panel
    Public WithEvents btn_Locate As System.Windows.Forms.Button
    Public WithEvents txtModule As System.Windows.Forms.TextBox
    Public WithEvents txtKernelVer As System.Windows.Forms.TextBox
    Public WithEvents txtID As System.Windows.Forms.TextBox
    Public WithEvents txtFirmwareVer As System.Windows.Forms.TextBox
    Public WithEvents Btn_Search As System.Windows.Forms.Button
    Public WithEvents Btn_Quit As System.Windows.Forms.Button
    Public WithEvents panel_Remote As System.Windows.Forms.Panel
    Public WithEvents StatusBar_IO As System.Windows.Forms.StatusBar

End Class
