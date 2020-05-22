<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Form_APAX_5017PE
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
        Me.tcRemote = New System.Windows.Forms.TabControl
        Me.tabModuleInfo = New System.Windows.Forms.TabPage
        Me.btnLocate = New System.Windows.Forms.Button
        Me.lblLocate = New System.Windows.Forms.Label
        Me.labADVer = New System.Windows.Forms.Label
        Me.txtAIOFwVer = New System.Windows.Forms.TextBox
        Me.txtModuleID = New System.Windows.Forms.TextBox
        Me.labModule = New System.Windows.Forms.Label
        Me.labID = New System.Windows.Forms.Label
        Me.labFwVer = New System.Windows.Forms.Label
        Me.txtSWID = New System.Windows.Forms.TextBox
        Me.txtFwVer = New System.Windows.Forms.TextBox
        Me.txtSupportKernelFw = New System.Windows.Forms.TextBox
        Me.labSupportKernelFw = New System.Windows.Forms.Label
        Me.tabAI = New System.Windows.Forms.TabPage
        Me.listViewChInfo = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader
        Me.panelConfig = New System.Windows.Forms.Panel
        Me.cbxIntegration = New System.Windows.Forms.ComboBox
        Me.labIntegration = New System.Windows.Forms.Label
        Me.btnIntegration = New System.Windows.Forms.Button
        Me.btnMaskEnable = New System.Windows.Forms.Button
        Me.label2 = New System.Windows.Forms.Label
        Me.btnMaskDisable = New System.Windows.Forms.Button
        Me.cbxSampleRate = New System.Windows.Forms.ComboBox
        Me.labSampleRate = New System.Windows.Forms.Label
        Me.btnSampleRate = New System.Windows.Forms.Button
        Me.cbxBurnoutValue = New System.Windows.Forms.ComboBox
        Me.labBurnoutValue = New System.Windows.Forms.Label
        Me.cbxRange = New System.Windows.Forms.ComboBox
        Me.chkApplyAll = New System.Windows.Forms.CheckBox
        Me.btnApplySelRange = New System.Windows.Forms.Button
        Me.labRange = New System.Windows.Forms.Label
        Me.btnBurnoutValue = New System.Windows.Forms.Button
        Me.panelSetting = New System.Windows.Forms.Panel
        Me.cbRawData = New System.Windows.Forms.CheckBox
        Me.cbSetPanelHide = New System.Windows.Forms.CheckBox
        Me.Btn_Quit = New System.Windows.Forms.Button
        Me.btnStart = New System.Windows.Forms.Button
        Me.StatusBar_IO = New System.Windows.Forms.StatusBar
        Me.Timer1 = New System.Windows.Forms.Timer
        Me.clmType = New System.Windows.Forms.ColumnHeader
        Me.clmCh = New System.Windows.Forms.ColumnHeader
        Me.ColumnAddr = New System.Windows.Forms.ColumnHeader
        Me.clmValue = New System.Windows.Forms.ColumnHeader
        Me.clmChStatus = New System.Windows.Forms.ColumnHeader
        Me.clmRange = New System.Windows.Forms.ColumnHeader
        Me.tcRemote.SuspendLayout()
        Me.tabModuleInfo.SuspendLayout()
        Me.tabAI.SuspendLayout()
        Me.panelConfig.SuspendLayout()
        Me.panelSetting.SuspendLayout()
        Me.SuspendLayout()
        '
        'tcRemote
        '
        Me.tcRemote.Controls.Add(Me.tabModuleInfo)
        Me.tcRemote.Controls.Add(Me.tabAI)
        Me.tcRemote.Dock = System.Windows.Forms.DockStyle.Top
        Me.tcRemote.Enabled = False
        Me.tcRemote.Location = New System.Drawing.Point(0, 0)
        Me.tcRemote.Name = "tcRemote"
        Me.tcRemote.SelectedIndex = 0
        Me.tcRemote.Size = New System.Drawing.Size(475, 344)
        Me.tcRemote.TabIndex = 11
        Me.tcRemote.Visible = False
        '
        'tabModuleInfo
        '
        Me.tabModuleInfo.Controls.Add(Me.btnLocate)
        Me.tabModuleInfo.Controls.Add(Me.lblLocate)
        Me.tabModuleInfo.Controls.Add(Me.labADVer)
        Me.tabModuleInfo.Controls.Add(Me.txtAIOFwVer)
        Me.tabModuleInfo.Controls.Add(Me.txtModuleID)
        Me.tabModuleInfo.Controls.Add(Me.labModule)
        Me.tabModuleInfo.Controls.Add(Me.labID)
        Me.tabModuleInfo.Controls.Add(Me.labFwVer)
        Me.tabModuleInfo.Controls.Add(Me.txtSWID)
        Me.tabModuleInfo.Controls.Add(Me.txtFwVer)
        Me.tabModuleInfo.Controls.Add(Me.txtSupportKernelFw)
        Me.tabModuleInfo.Controls.Add(Me.labSupportKernelFw)
        Me.tabModuleInfo.Location = New System.Drawing.Point(4, 25)
        Me.tabModuleInfo.Name = "tabModuleInfo"
        Me.tabModuleInfo.Size = New System.Drawing.Size(467, 315)
        Me.tabModuleInfo.Text = "Module Information"
        '
        'btnLocate
        '
        Me.btnLocate.Location = New System.Drawing.Point(157, 163)
        Me.btnLocate.Name = "btnLocate"
        Me.btnLocate.Size = New System.Drawing.Size(72, 20)
        Me.btnLocate.TabIndex = 48
        Me.btnLocate.Text = "Enable"
        '
        'lblLocate
        '
        Me.lblLocate.Location = New System.Drawing.Point(4, 163)
        Me.lblLocate.Name = "lblLocate"
        Me.lblLocate.Size = New System.Drawing.Size(56, 20)
        Me.lblLocate.Text = "Locate:"
        '
        'labADVer
        '
        Me.labADVer.Location = New System.Drawing.Point(4, 135)
        Me.labADVer.Name = "labADVer"
        Me.labADVer.Size = New System.Drawing.Size(149, 20)
        Me.labADVer.Text = "AIO Firmware Version :"
        '
        'txtAIOFwVer
        '
        Me.txtAIOFwVer.Location = New System.Drawing.Point(157, 134)
        Me.txtAIOFwVer.Name = "txtAIOFwVer"
        Me.txtAIOFwVer.ReadOnly = True
        Me.txtAIOFwVer.Size = New System.Drawing.Size(208, 23)
        Me.txtAIOFwVer.TabIndex = 41
        '
        'txtModuleID
        '
        Me.txtModuleID.Location = New System.Drawing.Point(157, 8)
        Me.txtModuleID.Name = "txtModuleID"
        Me.txtModuleID.ReadOnly = True
        Me.txtModuleID.Size = New System.Drawing.Size(208, 23)
        Me.txtModuleID.TabIndex = 36
        '
        'labModule
        '
        Me.labModule.Location = New System.Drawing.Point(4, 9)
        Me.labModule.Name = "labModule"
        Me.labModule.Size = New System.Drawing.Size(100, 20)
        Me.labModule.Text = "Module :"
        '
        'labID
        '
        Me.labID.Location = New System.Drawing.Point(4, 41)
        Me.labID.Name = "labID"
        Me.labID.Size = New System.Drawing.Size(100, 20)
        Me.labID.Text = "Switch ID :"
        '
        'labFwVer
        '
        Me.labFwVer.Location = New System.Drawing.Point(4, 103)
        Me.labFwVer.Name = "labFwVer"
        Me.labFwVer.Size = New System.Drawing.Size(124, 20)
        Me.labFwVer.Text = "Firmware Version:"
        '
        'txtSWID
        '
        Me.txtSWID.Location = New System.Drawing.Point(157, 40)
        Me.txtSWID.Name = "txtSWID"
        Me.txtSWID.ReadOnly = True
        Me.txtSWID.Size = New System.Drawing.Size(208, 23)
        Me.txtSWID.TabIndex = 37
        '
        'txtFwVer
        '
        Me.txtFwVer.Location = New System.Drawing.Point(157, 102)
        Me.txtFwVer.Name = "txtFwVer"
        Me.txtFwVer.ReadOnly = True
        Me.txtFwVer.Size = New System.Drawing.Size(208, 23)
        Me.txtFwVer.TabIndex = 39
        '
        'txtSupportKernelFw
        '
        Me.txtSupportKernelFw.Location = New System.Drawing.Point(157, 70)
        Me.txtSupportKernelFw.Name = "txtSupportKernelFw"
        Me.txtSupportKernelFw.ReadOnly = True
        Me.txtSupportKernelFw.Size = New System.Drawing.Size(208, 23)
        Me.txtSupportKernelFw.TabIndex = 40
        '
        'labSupportKernelFw
        '
        Me.labSupportKernelFw.Location = New System.Drawing.Point(4, 71)
        Me.labSupportKernelFw.Name = "labSupportKernelFw"
        Me.labSupportKernelFw.Size = New System.Drawing.Size(124, 20)
        Me.labSupportKernelFw.Text = "Support Kernel Fw:"
        '
        'tabAI
        '
        Me.tabAI.Controls.Add(Me.listViewChInfo)
        Me.tabAI.Controls.Add(Me.panelConfig)
        Me.tabAI.Controls.Add(Me.panelSetting)
        Me.tabAI.Location = New System.Drawing.Point(4, 25)
        Me.tabAI.Name = "tabAI"
        Me.tabAI.Size = New System.Drawing.Size(467, 315)
        Me.tabAI.Text = "AI"
        '
        'listViewChInfo
        '
        Me.listViewChInfo.Columns.Add(Me.ColumnHeader1)
        Me.listViewChInfo.Columns.Add(Me.ColumnHeader2)
        Me.listViewChInfo.Columns.Add(Me.ColumnHeader3)
        Me.listViewChInfo.Columns.Add(Me.ColumnHeader4)
        Me.listViewChInfo.Columns.Add(Me.ColumnHeader5)
        Me.listViewChInfo.Columns.Add(Me.ColumnHeader6)
        Me.listViewChInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.listViewChInfo.FullRowSelect = True
        Me.listViewChInfo.Location = New System.Drawing.Point(0, 201)
        Me.listViewChInfo.Name = "listViewChInfo"
        Me.listViewChInfo.Size = New System.Drawing.Size(467, 114)
        Me.listViewChInfo.TabIndex = 5
        Me.listViewChInfo.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Type"
        Me.ColumnHeader1.Width = 40
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "CH"
        Me.ColumnHeader2.Width = 44
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Modbus Addr"
        Me.ColumnHeader3.Width = 85
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Value"
        Me.ColumnHeader4.Width = 44
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Ch Status"
        Me.ColumnHeader5.Width = 80
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Range"
        Me.ColumnHeader6.Width = 200
        '
        'panelConfig
        '
        Me.panelConfig.BackColor = System.Drawing.Color.SkyBlue
        Me.panelConfig.Controls.Add(Me.cbxIntegration)
        Me.panelConfig.Controls.Add(Me.labIntegration)
        Me.panelConfig.Controls.Add(Me.btnIntegration)
        Me.panelConfig.Controls.Add(Me.btnMaskEnable)
        Me.panelConfig.Controls.Add(Me.label2)
        Me.panelConfig.Controls.Add(Me.btnMaskDisable)
        Me.panelConfig.Controls.Add(Me.cbxSampleRate)
        Me.panelConfig.Controls.Add(Me.labSampleRate)
        Me.panelConfig.Controls.Add(Me.btnSampleRate)
        Me.panelConfig.Controls.Add(Me.cbxBurnoutValue)
        Me.panelConfig.Controls.Add(Me.labBurnoutValue)
        Me.panelConfig.Controls.Add(Me.cbxRange)
        Me.panelConfig.Controls.Add(Me.chkApplyAll)
        Me.panelConfig.Controls.Add(Me.btnApplySelRange)
        Me.panelConfig.Controls.Add(Me.labRange)
        Me.panelConfig.Controls.Add(Me.btnBurnoutValue)
        Me.panelConfig.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelConfig.Location = New System.Drawing.Point(0, 28)
        Me.panelConfig.Name = "panelConfig"
        Me.panelConfig.Size = New System.Drawing.Size(467, 173)
        '
        'cbxIntegration
        '
        Me.cbxIntegration.Location = New System.Drawing.Point(149, 82)
        Me.cbxIntegration.Name = "cbxIntegration"
        Me.cbxIntegration.Size = New System.Drawing.Size(181, 23)
        Me.cbxIntegration.TabIndex = 60
        '
        'labIntegration
        '
        Me.labIntegration.Location = New System.Drawing.Point(8, 85)
        Me.labIntegration.Name = "labIntegration"
        Me.labIntegration.Size = New System.Drawing.Size(118, 20)
        Me.labIntegration.Text = "Integration Time :"
        '
        'btnIntegration
        '
        Me.btnIntegration.Location = New System.Drawing.Point(346, 81)
        Me.btnIntegration.Name = "btnIntegration"
        Me.btnIntegration.Size = New System.Drawing.Size(86, 24)
        Me.btnIntegration.TabIndex = 61
        Me.btnIntegration.Text = "Apply"
        '
        'btnMaskEnable
        '
        Me.btnMaskEnable.Location = New System.Drawing.Point(149, 52)
        Me.btnMaskEnable.Name = "btnMaskEnable"
        Me.btnMaskEnable.Size = New System.Drawing.Size(71, 24)
        Me.btnMaskEnable.TabIndex = 56
        Me.btnMaskEnable.Text = "Enable"
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(8, 56)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(104, 20)
        Me.label2.Text = "Channel Mask :"
        '
        'btnMaskDisable
        '
        Me.btnMaskDisable.Location = New System.Drawing.Point(259, 52)
        Me.btnMaskDisable.Name = "btnMaskDisable"
        Me.btnMaskDisable.Size = New System.Drawing.Size(71, 24)
        Me.btnMaskDisable.TabIndex = 57
        Me.btnMaskDisable.Text = "Disable"
        '
        'cbxSampleRate
        '
        Me.cbxSampleRate.Location = New System.Drawing.Point(149, 139)
        Me.cbxSampleRate.Name = "cbxSampleRate"
        Me.cbxSampleRate.Size = New System.Drawing.Size(181, 23)
        Me.cbxSampleRate.TabIndex = 35
        '
        'labSampleRate
        '
        Me.labSampleRate.Location = New System.Drawing.Point(8, 140)
        Me.labSampleRate.Name = "labSampleRate"
        Me.labSampleRate.Size = New System.Drawing.Size(153, 20)
        Me.labSampleRate.Text = "Sampling Rate (Hz/Ch):"
        '
        'btnSampleRate
        '
        Me.btnSampleRate.Location = New System.Drawing.Point(345, 138)
        Me.btnSampleRate.Name = "btnSampleRate"
        Me.btnSampleRate.Size = New System.Drawing.Size(86, 24)
        Me.btnSampleRate.TabIndex = 36
        Me.btnSampleRate.Text = "Apply"
        '
        'cbxBurnoutValue
        '
        Me.cbxBurnoutValue.Location = New System.Drawing.Point(149, 111)
        Me.cbxBurnoutValue.Name = "cbxBurnoutValue"
        Me.cbxBurnoutValue.Size = New System.Drawing.Size(181, 23)
        Me.cbxBurnoutValue.TabIndex = 15
        '
        'labBurnoutValue
        '
        Me.labBurnoutValue.Location = New System.Drawing.Point(8, 112)
        Me.labBurnoutValue.Name = "labBurnoutValue"
        Me.labBurnoutValue.Size = New System.Drawing.Size(153, 20)
        Me.labBurnoutValue.Text = "Burnout Detect Mode :"
        '
        'cbxRange
        '
        Me.cbxRange.Location = New System.Drawing.Point(149, 23)
        Me.cbxRange.Name = "cbxRange"
        Me.cbxRange.Size = New System.Drawing.Size(181, 23)
        Me.cbxRange.TabIndex = 19
        '
        'chkApplyAll
        '
        Me.chkApplyAll.Location = New System.Drawing.Point(8, 2)
        Me.chkApplyAll.Name = "chkApplyAll"
        Me.chkApplyAll.Size = New System.Drawing.Size(203, 24)
        Me.chkApplyAll.TabIndex = 21
        Me.chkApplyAll.Text = "Apply to All Channels"
        '
        'btnApplySelRange
        '
        Me.btnApplySelRange.Location = New System.Drawing.Point(345, 21)
        Me.btnApplySelRange.Name = "btnApplySelRange"
        Me.btnApplySelRange.Size = New System.Drawing.Size(86, 24)
        Me.btnApplySelRange.TabIndex = 23
        Me.btnApplySelRange.Text = "Apply"
        '
        'labRange
        '
        Me.labRange.Location = New System.Drawing.Point(8, 23)
        Me.labRange.Name = "labRange"
        Me.labRange.Size = New System.Drawing.Size(118, 20)
        Me.labRange.Text = "Range :"
        '
        'btnBurnoutValue
        '
        Me.btnBurnoutValue.Location = New System.Drawing.Point(345, 110)
        Me.btnBurnoutValue.Name = "btnBurnoutValue"
        Me.btnBurnoutValue.Size = New System.Drawing.Size(86, 24)
        Me.btnBurnoutValue.TabIndex = 29
        Me.btnBurnoutValue.Text = "Apply"
        '
        'panelSetting
        '
        Me.panelSetting.Controls.Add(Me.cbRawData)
        Me.panelSetting.Controls.Add(Me.cbSetPanelHide)
        Me.panelSetting.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelSetting.Location = New System.Drawing.Point(0, 0)
        Me.panelSetting.Name = "panelSetting"
        Me.panelSetting.Size = New System.Drawing.Size(467, 28)
        '
        'cbRawData
        '
        Me.cbRawData.Location = New System.Drawing.Point(176, 3)
        Me.cbRawData.Name = "cbRawData"
        Me.cbRawData.Size = New System.Drawing.Size(128, 20)
        Me.cbRawData.TabIndex = 30
        Me.cbRawData.Text = "Show Raw Data"
        '
        'cbSetPanelHide
        '
        Me.cbSetPanelHide.Location = New System.Drawing.Point(8, 5)
        Me.cbSetPanelHide.Name = "cbSetPanelHide"
        Me.cbSetPanelHide.Size = New System.Drawing.Size(168, 20)
        Me.cbSetPanelHide.TabIndex = 1
        Me.cbSetPanelHide.Text = "Hide Setting Panel"
        '
        'Btn_Quit
        '
        Me.Btn_Quit.Location = New System.Drawing.Point(398, 365)
        Me.Btn_Quit.Name = "Btn_Quit"
        Me.Btn_Quit.Size = New System.Drawing.Size(73, 21)
        Me.Btn_Quit.TabIndex = 14
        Me.Btn_Quit.Text = "Quit"
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(323, 365)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(73, 21)
        Me.btnStart.TabIndex = 13
        Me.btnStart.Text = "Start"
        '
        'StatusBar_IO
        '
        Me.StatusBar_IO.Location = New System.Drawing.Point(0, 392)
        Me.StatusBar_IO.Name = "StatusBar_IO"
        Me.StatusBar_IO.Size = New System.Drawing.Size(475, 24)
        '
        'Timer1
        '
        '
        'clmType
        '
        Me.clmType.Text = "Type"
        '
        'clmCh
        '
        Me.clmCh.Text = "CH"
        Me.clmCh.Width = 44
        '
        'ColumnAddr
        '
        Me.ColumnAddr.Text = "Modbus Addr"
        Me.ColumnAddr.Width = 85
        '
        'clmValue
        '
        Me.clmValue.Text = "Value"
        '
        'clmChStatus
        '
        Me.clmChStatus.Text = "Ch Status"
        Me.clmChStatus.Width = 80
        '
        'clmRange
        '
        Me.clmRange.Text = "Range"
        Me.clmRange.Width = 200
        '
        'Form_APAX_5017PE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(475, 416)
        Me.Controls.Add(Me.Btn_Quit)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.StatusBar_IO)
        Me.Controls.Add(Me.tcRemote)
        Me.Name = "Form_APAX_5017PE"
        Me.Text = "APAX-5017PE"
        Me.tcRemote.ResumeLayout(False)
        Me.tabModuleInfo.ResumeLayout(False)
        Me.tabAI.ResumeLayout(False)
        Me.panelConfig.ResumeLayout(False)
        Me.panelSetting.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents tcRemote As System.Windows.Forms.TabControl
    Private WithEvents tabModuleInfo As System.Windows.Forms.TabPage
    Private WithEvents btnLocate As System.Windows.Forms.Button
    Private WithEvents lblLocate As System.Windows.Forms.Label
    Private WithEvents labADVer As System.Windows.Forms.Label
    Private WithEvents txtAIOFwVer As System.Windows.Forms.TextBox
    Private WithEvents txtModuleID As System.Windows.Forms.TextBox
    Private WithEvents labModule As System.Windows.Forms.Label
    Private WithEvents labID As System.Windows.Forms.Label
    Private WithEvents labFwVer As System.Windows.Forms.Label
    Private WithEvents txtSWID As System.Windows.Forms.TextBox
    Private WithEvents txtFwVer As System.Windows.Forms.TextBox
    Private WithEvents txtSupportKernelFw As System.Windows.Forms.TextBox
    Private WithEvents labSupportKernelFw As System.Windows.Forms.Label
    Private WithEvents tabAI As System.Windows.Forms.TabPage
    Private WithEvents panelConfig As System.Windows.Forms.Panel
    Private WithEvents cbxSampleRate As System.Windows.Forms.ComboBox
    Private WithEvents labSampleRate As System.Windows.Forms.Label
    Private WithEvents btnSampleRate As System.Windows.Forms.Button
    Private WithEvents cbxBurnoutValue As System.Windows.Forms.ComboBox
    Private WithEvents labBurnoutValue As System.Windows.Forms.Label
    Private WithEvents cbxRange As System.Windows.Forms.ComboBox
    Private WithEvents chkApplyAll As System.Windows.Forms.CheckBox
    Private WithEvents btnApplySelRange As System.Windows.Forms.Button
    Private WithEvents labRange As System.Windows.Forms.Label
    Private WithEvents btnBurnoutValue As System.Windows.Forms.Button
    Private WithEvents panelSetting As System.Windows.Forms.Panel
    Private WithEvents cbRawData As System.Windows.Forms.CheckBox
    Private WithEvents cbSetPanelHide As System.Windows.Forms.CheckBox
    Friend WithEvents Btn_Quit As System.Windows.Forms.Button
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents StatusBar_IO As System.Windows.Forms.StatusBar
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Private WithEvents cbxIntegration As System.Windows.Forms.ComboBox
    Private WithEvents labIntegration As System.Windows.Forms.Label
    Private WithEvents btnIntegration As System.Windows.Forms.Button
    Private WithEvents btnMaskEnable As System.Windows.Forms.Button
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents btnMaskDisable As System.Windows.Forms.Button
    Private WithEvents listViewChInfo As System.Windows.Forms.ListView
    Private WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Private WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Private WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Private WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Private WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Private WithEvents clmType As System.Windows.Forms.ColumnHeader
    Private WithEvents clmCh As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnAddr As System.Windows.Forms.ColumnHeader
    Private WithEvents clmValue As System.Windows.Forms.ColumnHeader
    Private WithEvents clmChStatus As System.Windows.Forms.ColumnHeader
    Private WithEvents clmRange As System.Windows.Forms.ColumnHeader

End Class
