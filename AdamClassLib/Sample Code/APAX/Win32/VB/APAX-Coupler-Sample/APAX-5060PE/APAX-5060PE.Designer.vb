<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_APAX_5060PE
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
        Me.tcRemote = New System.Windows.Forms.TabControl
        Me.tabModuleInfo = New System.Windows.Forms.TabPage
        Me.btnLocate = New System.Windows.Forms.Button
        Me.lblLocate = New System.Windows.Forms.Label
        Me.txtModuleID = New System.Windows.Forms.TextBox
        Me.labModule = New System.Windows.Forms.Label
        Me.labID = New System.Windows.Forms.Label
        Me.labFwVer = New System.Windows.Forms.Label
        Me.txtSWID = New System.Windows.Forms.TextBox
        Me.txtFwVer = New System.Windows.Forms.TextBox
        Me.txtSupportKernelFw = New System.Windows.Forms.TextBox
        Me.labSupportKernelFw = New System.Windows.Forms.Label
        Me.tabDO = New System.Windows.Forms.TabPage
        Me.listViewChInfo = New System.Windows.Forms.ListView
        Me.clmType = New System.Windows.Forms.ColumnHeader
        Me.clmCh = New System.Windows.Forms.ColumnHeader
        Me.clmAddr = New System.Windows.Forms.ColumnHeader
        Me.clmValue = New System.Windows.Forms.ColumnHeader
        Me.clmMode = New System.Windows.Forms.ColumnHeader
        Me.clmSafety = New System.Windows.Forms.ColumnHeader
        Me.panelConfig = New System.Windows.Forms.Panel
        Me.btnSetSafetyValue = New System.Windows.Forms.Button
        Me.chbxEnableSafety = New System.Windows.Forms.CheckBox
        Me.label2 = New System.Windows.Forms.Label
        Me.panelSetting = New System.Windows.Forms.Panel
        Me.btnTrue = New System.Windows.Forms.Button
        Me.btnFalse = New System.Windows.Forms.Button
        Me.panelMain = New System.Windows.Forms.Panel
        Me.chbxHide = New System.Windows.Forms.CheckBox
        Me.Btn_Quit = New System.Windows.Forms.Button
        Me.btnStart = New System.Windows.Forms.Button
        Me.StatusBar_IO = New System.Windows.Forms.StatusBar
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.tcRemote.SuspendLayout()
        Me.tabModuleInfo.SuspendLayout()
        Me.tabDO.SuspendLayout()
        Me.panelConfig.SuspendLayout()
        Me.panelSetting.SuspendLayout()
        Me.panelMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'tcRemote
        '
        Me.tcRemote.Controls.Add(Me.tabModuleInfo)
        Me.tcRemote.Controls.Add(Me.tabDO)
        Me.tcRemote.Dock = System.Windows.Forms.DockStyle.Top
        Me.tcRemote.Enabled = False
        Me.tcRemote.Location = New System.Drawing.Point(0, 0)
        Me.tcRemote.Name = "tcRemote"
        Me.tcRemote.SelectedIndex = 0
        Me.tcRemote.Size = New System.Drawing.Size(509, 321)
        Me.tcRemote.TabIndex = 4
        Me.tcRemote.Visible = False
        '
        'tabModuleInfo
        '
        Me.tabModuleInfo.Controls.Add(Me.btnLocate)
        Me.tabModuleInfo.Controls.Add(Me.lblLocate)
        Me.tabModuleInfo.Controls.Add(Me.txtModuleID)
        Me.tabModuleInfo.Controls.Add(Me.labModule)
        Me.tabModuleInfo.Controls.Add(Me.labID)
        Me.tabModuleInfo.Controls.Add(Me.labFwVer)
        Me.tabModuleInfo.Controls.Add(Me.txtSWID)
        Me.tabModuleInfo.Controls.Add(Me.txtFwVer)
        Me.tabModuleInfo.Controls.Add(Me.txtSupportKernelFw)
        Me.tabModuleInfo.Controls.Add(Me.labSupportKernelFw)
        Me.tabModuleInfo.Location = New System.Drawing.Point(4, 22)
        Me.tabModuleInfo.Name = "tabModuleInfo"
        Me.tabModuleInfo.Size = New System.Drawing.Size(501, 295)
        Me.tabModuleInfo.TabIndex = 0
        Me.tabModuleInfo.Text = "Module Information"
        '
        'btnLocate
        '
        Me.btnLocate.Location = New System.Drawing.Point(135, 129)
        Me.btnLocate.Name = "btnLocate"
        Me.btnLocate.Size = New System.Drawing.Size(72, 20)
        Me.btnLocate.TabIndex = 50
        Me.btnLocate.Text = "Enable"
        '
        'lblLocate
        '
        Me.lblLocate.Location = New System.Drawing.Point(4, 129)
        Me.lblLocate.Name = "lblLocate"
        Me.lblLocate.Size = New System.Drawing.Size(56, 20)
        Me.lblLocate.TabIndex = 51
        Me.lblLocate.Text = "Locate:"
        '
        'txtModuleID
        '
        Me.txtModuleID.Location = New System.Drawing.Point(135, 9)
        Me.txtModuleID.Name = "txtModuleID"
        Me.txtModuleID.ReadOnly = True
        Me.txtModuleID.Size = New System.Drawing.Size(223, 22)
        Me.txtModuleID.TabIndex = 18
        '
        'labModule
        '
        Me.labModule.Location = New System.Drawing.Point(4, 9)
        Me.labModule.Name = "labModule"
        Me.labModule.Size = New System.Drawing.Size(100, 20)
        Me.labModule.TabIndex = 52
        Me.labModule.Text = "Module :"
        '
        'labID
        '
        Me.labID.Location = New System.Drawing.Point(4, 40)
        Me.labID.Name = "labID"
        Me.labID.Size = New System.Drawing.Size(100, 20)
        Me.labID.TabIndex = 53
        Me.labID.Text = "Switch ID :"
        '
        'labFwVer
        '
        Me.labFwVer.Location = New System.Drawing.Point(4, 100)
        Me.labFwVer.Name = "labFwVer"
        Me.labFwVer.Size = New System.Drawing.Size(125, 20)
        Me.labFwVer.TabIndex = 54
        Me.labFwVer.Text = "Firmware Version:"
        '
        'txtSWID
        '
        Me.txtSWID.Location = New System.Drawing.Point(135, 40)
        Me.txtSWID.Name = "txtSWID"
        Me.txtSWID.ReadOnly = True
        Me.txtSWID.Size = New System.Drawing.Size(223, 22)
        Me.txtSWID.TabIndex = 23
        '
        'txtFwVer
        '
        Me.txtFwVer.Location = New System.Drawing.Point(135, 100)
        Me.txtFwVer.Name = "txtFwVer"
        Me.txtFwVer.ReadOnly = True
        Me.txtFwVer.Size = New System.Drawing.Size(223, 22)
        Me.txtFwVer.TabIndex = 25
        '
        'txtSupportKernelFw
        '
        Me.txtSupportKernelFw.Location = New System.Drawing.Point(135, 69)
        Me.txtSupportKernelFw.Name = "txtSupportKernelFw"
        Me.txtSupportKernelFw.ReadOnly = True
        Me.txtSupportKernelFw.Size = New System.Drawing.Size(223, 22)
        Me.txtSupportKernelFw.TabIndex = 26
        '
        'labSupportKernelFw
        '
        Me.labSupportKernelFw.Location = New System.Drawing.Point(4, 72)
        Me.labSupportKernelFw.Name = "labSupportKernelFw"
        Me.labSupportKernelFw.Size = New System.Drawing.Size(124, 20)
        Me.labSupportKernelFw.TabIndex = 55
        Me.labSupportKernelFw.Text = "Support Kernel Fw:"
        '
        'tabDO
        '
        Me.tabDO.Controls.Add(Me.listViewChInfo)
        Me.tabDO.Controls.Add(Me.panelConfig)
        Me.tabDO.Controls.Add(Me.panelMain)
        Me.tabDO.Location = New System.Drawing.Point(4, 22)
        Me.tabDO.Name = "tabDO"
        Me.tabDO.Size = New System.Drawing.Size(501, 295)
        Me.tabDO.TabIndex = 1
        Me.tabDO.Text = "DO"
        '
        'listViewChInfo
        '
        Me.listViewChInfo.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.clmType, Me.clmCh, Me.clmAddr, Me.clmValue, Me.clmMode, Me.clmSafety})
        Me.listViewChInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.listViewChInfo.FullRowSelect = True
        Me.listViewChInfo.Location = New System.Drawing.Point(0, 78)
        Me.listViewChInfo.Name = "listViewChInfo"
        Me.listViewChInfo.Size = New System.Drawing.Size(501, 217)
        Me.listViewChInfo.TabIndex = 2
        Me.listViewChInfo.UseCompatibleStateImageBehavior = False
        Me.listViewChInfo.View = System.Windows.Forms.View.Details
        '
        'clmType
        '
        Me.clmType.Text = "Type"
        Me.clmType.Width = 51
        '
        'clmCh
        '
        Me.clmCh.Text = "CH"
        Me.clmCh.Width = 43
        '
        'clmAddr
        '
        Me.clmAddr.Text = "Modbus Addr"
        Me.clmAddr.Width = 81
        '
        'clmValue
        '
        Me.clmValue.Text = "Value"
        '
        'clmMode
        '
        Me.clmMode.Text = "Mode"
        '
        'clmSafety
        '
        Me.clmSafety.Text = "Safety Value"
        Me.clmSafety.Width = 150
        '
        'panelConfig
        '
        Me.panelConfig.BackColor = System.Drawing.Color.SkyBlue
        Me.panelConfig.Controls.Add(Me.btnSetSafetyValue)
        Me.panelConfig.Controls.Add(Me.chbxEnableSafety)
        Me.panelConfig.Controls.Add(Me.label2)
        Me.panelConfig.Controls.Add(Me.panelSetting)
        Me.panelConfig.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelConfig.Location = New System.Drawing.Point(0, 32)
        Me.panelConfig.Name = "panelConfig"
        Me.panelConfig.Size = New System.Drawing.Size(501, 46)
        Me.panelConfig.TabIndex = 3
        '
        'btnSetSafetyValue
        '
        Me.btnSetSafetyValue.Enabled = False
        Me.btnSetSafetyValue.Location = New System.Drawing.Point(354, 11)
        Me.btnSetSafetyValue.Name = "btnSetSafetyValue"
        Me.btnSetSafetyValue.Size = New System.Drawing.Size(84, 24)
        Me.btnSetSafetyValue.TabIndex = 4
        Me.btnSetSafetyValue.Text = "Set Value"
        '
        'chbxEnableSafety
        '
        Me.chbxEnableSafety.Location = New System.Drawing.Point(272, 13)
        Me.chbxEnableSafety.Name = "chbxEnableSafety"
        Me.chbxEnableSafety.Size = New System.Drawing.Size(76, 20)
        Me.chbxEnableSafety.TabIndex = 5
        Me.chbxEnableSafety.Text = "Enable"
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(174, 13)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(111, 20)
        Me.label2.TabIndex = 6
        Me.label2.Text = "Safety Function"
        '
        'panelSetting
        '
        Me.panelSetting.BackColor = System.Drawing.Color.SkyBlue
        Me.panelSetting.Controls.Add(Me.btnTrue)
        Me.panelSetting.Controls.Add(Me.btnFalse)
        Me.panelSetting.Dock = System.Windows.Forms.DockStyle.Left
        Me.panelSetting.Location = New System.Drawing.Point(0, 0)
        Me.panelSetting.Name = "panelSetting"
        Me.panelSetting.Size = New System.Drawing.Size(166, 46)
        Me.panelSetting.TabIndex = 7
        '
        'btnTrue
        '
        Me.btnTrue.Location = New System.Drawing.Point(7, 11)
        Me.btnTrue.Name = "btnTrue"
        Me.btnTrue.Size = New System.Drawing.Size(72, 24)
        Me.btnTrue.TabIndex = 0
        Me.btnTrue.Text = "Set True"
        '
        'btnFalse
        '
        Me.btnFalse.Location = New System.Drawing.Point(87, 11)
        Me.btnFalse.Name = "btnFalse"
        Me.btnFalse.Size = New System.Drawing.Size(72, 24)
        Me.btnFalse.TabIndex = 1
        Me.btnFalse.Text = "Set False"
        '
        'panelMain
        '
        Me.panelMain.Controls.Add(Me.chbxHide)
        Me.panelMain.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelMain.Location = New System.Drawing.Point(0, 0)
        Me.panelMain.Name = "panelMain"
        Me.panelMain.Size = New System.Drawing.Size(501, 32)
        Me.panelMain.TabIndex = 4
        '
        'chbxHide
        '
        Me.chbxHide.Location = New System.Drawing.Point(8, 8)
        Me.chbxHide.Name = "chbxHide"
        Me.chbxHide.Size = New System.Drawing.Size(168, 20)
        Me.chbxHide.TabIndex = 1
        Me.chbxHide.Text = "Hide Setting Panel"
        '
        'Btn_Quit
        '
        Me.Btn_Quit.Location = New System.Drawing.Point(432, 327)
        Me.Btn_Quit.Name = "Btn_Quit"
        Me.Btn_Quit.Size = New System.Drawing.Size(73, 21)
        Me.Btn_Quit.TabIndex = 17
        Me.Btn_Quit.Text = "Quit"
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(353, 327)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(73, 21)
        Me.btnStart.TabIndex = 16
        Me.btnStart.Text = "Start"
        '
        'StatusBar_IO
        '
        Me.StatusBar_IO.Location = New System.Drawing.Point(0, 359)
        Me.StatusBar_IO.Name = "StatusBar_IO"
        Me.StatusBar_IO.Size = New System.Drawing.Size(509, 24)
        Me.StatusBar_IO.TabIndex = 18
        '
        'Timer1
        '
        '
        'Form_APAX_5060
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(509, 383)
        Me.Controls.Add(Me.Btn_Quit)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.StatusBar_IO)
        Me.Controls.Add(Me.tcRemote)
        Me.Name = "Form_APAX_5060"
        Me.Text = "APAX-5060PE"
        Me.tcRemote.ResumeLayout(False)
        Me.tabModuleInfo.ResumeLayout(False)
        Me.tabModuleInfo.PerformLayout()
        Me.tabDO.ResumeLayout(False)
        Me.panelConfig.ResumeLayout(False)
        Me.panelSetting.ResumeLayout(False)
        Me.panelMain.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents tcRemote As System.Windows.Forms.TabControl
    Private WithEvents tabModuleInfo As System.Windows.Forms.TabPage
    Private WithEvents btnLocate As System.Windows.Forms.Button
    Private WithEvents lblLocate As System.Windows.Forms.Label
    Private WithEvents txtModuleID As System.Windows.Forms.TextBox
    Private WithEvents labModule As System.Windows.Forms.Label
    Private WithEvents labID As System.Windows.Forms.Label
    Private WithEvents labFwVer As System.Windows.Forms.Label
    Private WithEvents txtSWID As System.Windows.Forms.TextBox
    Private WithEvents txtFwVer As System.Windows.Forms.TextBox
    Private WithEvents txtSupportKernelFw As System.Windows.Forms.TextBox
    Private WithEvents labSupportKernelFw As System.Windows.Forms.Label
    Private WithEvents tabDO As System.Windows.Forms.TabPage
    Private WithEvents listViewChInfo As System.Windows.Forms.ListView
    Private WithEvents clmType As System.Windows.Forms.ColumnHeader
    Private WithEvents clmCh As System.Windows.Forms.ColumnHeader
    Private WithEvents clmValue As System.Windows.Forms.ColumnHeader
    Private WithEvents clmMode As System.Windows.Forms.ColumnHeader
    Private WithEvents clmSafety As System.Windows.Forms.ColumnHeader
    Private WithEvents panelConfig As System.Windows.Forms.Panel
    Private WithEvents btnSetSafetyValue As System.Windows.Forms.Button
    Private WithEvents chbxEnableSafety As System.Windows.Forms.CheckBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents panelSetting As System.Windows.Forms.Panel
    Private WithEvents btnTrue As System.Windows.Forms.Button
    Private WithEvents btnFalse As System.Windows.Forms.Button
    Private WithEvents panelMain As System.Windows.Forms.Panel
    Private WithEvents chbxHide As System.Windows.Forms.CheckBox
    Friend WithEvents Btn_Quit As System.Windows.Forms.Button
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents StatusBar_IO As System.Windows.Forms.StatusBar
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents clmAddr As System.Windows.Forms.ColumnHeader

End Class
