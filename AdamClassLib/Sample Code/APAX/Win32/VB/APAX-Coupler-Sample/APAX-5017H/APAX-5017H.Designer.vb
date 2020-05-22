<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_APAX_5017H
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
        Me.Btn_Quit = New System.Windows.Forms.Button
        Me.btnStart = New System.Windows.Forms.Button
        Me.StatusBar_IO = New System.Windows.Forms.StatusBar
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
        Me.clmType = New System.Windows.Forms.ColumnHeader
        Me.ColumnAddr = New System.Windows.Forms.ColumnHeader
        Me.clmCh = New System.Windows.Forms.ColumnHeader
        Me.clmValue = New System.Windows.Forms.ColumnHeader
        Me.clmChStatus = New System.Windows.Forms.ColumnHeader
        Me.clmRange = New System.Windows.Forms.ColumnHeader
        Me.panelConfig = New System.Windows.Forms.Panel
        Me.cbxSampleRate = New System.Windows.Forms.ComboBox
        Me.labSampleRate = New System.Windows.Forms.Label
        Me.btnSampleRate = New System.Windows.Forms.Button
        Me.labBurnout = New System.Windows.Forms.Label
        Me.btnBurnoutFcn = New System.Windows.Forms.Button
        Me.chkBurnoutFcn = New System.Windows.Forms.CheckBox
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
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.tcRemote.SuspendLayout()
        Me.tabModuleInfo.SuspendLayout()
        Me.tabAI.SuspendLayout()
        Me.panelConfig.SuspendLayout()
        Me.panelSetting.SuspendLayout()
        Me.SuspendLayout()
        '
        'Btn_Quit
        '
        Me.Btn_Quit.Location = New System.Drawing.Point(396, 350)
        Me.Btn_Quit.Name = "Btn_Quit"
        Me.Btn_Quit.Size = New System.Drawing.Size(73, 21)
        Me.Btn_Quit.TabIndex = 15
        Me.Btn_Quit.Text = "Quit"
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(317, 350)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(73, 21)
        Me.btnStart.TabIndex = 13
        Me.btnStart.Text = "Start"
        '
        'StatusBar_IO
        '
        Me.StatusBar_IO.Location = New System.Drawing.Point(0, 380)
        Me.StatusBar_IO.Name = "StatusBar_IO"
        Me.StatusBar_IO.Size = New System.Drawing.Size(482, 24)
        Me.StatusBar_IO.TabIndex = 16
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
        Me.tcRemote.Size = New System.Drawing.Size(482, 344)
        Me.tcRemote.TabIndex = 14
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
        Me.tabModuleInfo.Location = New System.Drawing.Point(4, 22)
        Me.tabModuleInfo.Name = "tabModuleInfo"
        Me.tabModuleInfo.Size = New System.Drawing.Size(474, 318)
        Me.tabModuleInfo.TabIndex = 0
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
        Me.lblLocate.TabIndex = 49
        Me.lblLocate.Text = "Locate:"
        '
        'labADVer
        '
        Me.labADVer.Location = New System.Drawing.Point(4, 135)
        Me.labADVer.Name = "labADVer"
        Me.labADVer.Size = New System.Drawing.Size(149, 20)
        Me.labADVer.TabIndex = 50
        Me.labADVer.Text = "AIO Firmware Version :"
        '
        'txtAIOFwVer
        '
        Me.txtAIOFwVer.Location = New System.Drawing.Point(157, 134)
        Me.txtAIOFwVer.Name = "txtAIOFwVer"
        Me.txtAIOFwVer.ReadOnly = True
        Me.txtAIOFwVer.Size = New System.Drawing.Size(208, 22)
        Me.txtAIOFwVer.TabIndex = 41
        '
        'txtModuleID
        '
        Me.txtModuleID.Location = New System.Drawing.Point(157, 8)
        Me.txtModuleID.Name = "txtModuleID"
        Me.txtModuleID.ReadOnly = True
        Me.txtModuleID.Size = New System.Drawing.Size(208, 22)
        Me.txtModuleID.TabIndex = 36
        '
        'labModule
        '
        Me.labModule.Location = New System.Drawing.Point(4, 9)
        Me.labModule.Name = "labModule"
        Me.labModule.Size = New System.Drawing.Size(100, 20)
        Me.labModule.TabIndex = 51
        Me.labModule.Text = "Module :"
        '
        'labID
        '
        Me.labID.Location = New System.Drawing.Point(4, 41)
        Me.labID.Name = "labID"
        Me.labID.Size = New System.Drawing.Size(100, 20)
        Me.labID.TabIndex = 52
        Me.labID.Text = "Switch ID :"
        '
        'labFwVer
        '
        Me.labFwVer.Location = New System.Drawing.Point(4, 103)
        Me.labFwVer.Name = "labFwVer"
        Me.labFwVer.Size = New System.Drawing.Size(124, 20)
        Me.labFwVer.TabIndex = 53
        Me.labFwVer.Text = "Firmware Version:"
        '
        'txtSWID
        '
        Me.txtSWID.Location = New System.Drawing.Point(157, 40)
        Me.txtSWID.Name = "txtSWID"
        Me.txtSWID.ReadOnly = True
        Me.txtSWID.Size = New System.Drawing.Size(208, 22)
        Me.txtSWID.TabIndex = 37
        '
        'txtFwVer
        '
        Me.txtFwVer.Location = New System.Drawing.Point(157, 102)
        Me.txtFwVer.Name = "txtFwVer"
        Me.txtFwVer.ReadOnly = True
        Me.txtFwVer.Size = New System.Drawing.Size(208, 22)
        Me.txtFwVer.TabIndex = 39
        '
        'txtSupportKernelFw
        '
        Me.txtSupportKernelFw.Location = New System.Drawing.Point(157, 70)
        Me.txtSupportKernelFw.Name = "txtSupportKernelFw"
        Me.txtSupportKernelFw.ReadOnly = True
        Me.txtSupportKernelFw.Size = New System.Drawing.Size(208, 22)
        Me.txtSupportKernelFw.TabIndex = 40
        '
        'labSupportKernelFw
        '
        Me.labSupportKernelFw.Location = New System.Drawing.Point(4, 71)
        Me.labSupportKernelFw.Name = "labSupportKernelFw"
        Me.labSupportKernelFw.Size = New System.Drawing.Size(124, 20)
        Me.labSupportKernelFw.TabIndex = 54
        Me.labSupportKernelFw.Text = "Support Kernel Fw:"
        '
        'tabAI
        '
        Me.tabAI.Controls.Add(Me.listViewChInfo)
        Me.tabAI.Controls.Add(Me.panelConfig)
        Me.tabAI.Controls.Add(Me.panelSetting)
        Me.tabAI.Location = New System.Drawing.Point(4, 22)
        Me.tabAI.Name = "tabAI"
        Me.tabAI.Size = New System.Drawing.Size(474, 318)
        Me.tabAI.TabIndex = 1
        Me.tabAI.Text = "AI"
        '
        'listViewChInfo
        '
        Me.listViewChInfo.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.clmType, Me.ColumnAddr, Me.clmCh, Me.clmValue, Me.clmChStatus, Me.clmRange})
        Me.listViewChInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.listViewChInfo.FullRowSelect = True
        Me.listViewChInfo.Location = New System.Drawing.Point(0, 164)
        Me.listViewChInfo.Name = "listViewChInfo"
        Me.listViewChInfo.Size = New System.Drawing.Size(474, 154)
        Me.listViewChInfo.TabIndex = 2
        Me.listViewChInfo.UseCompatibleStateImageBehavior = False
        Me.listViewChInfo.View = System.Windows.Forms.View.Details
        '
        'clmType
        '
        Me.clmType.Text = "Type"
        Me.clmType.Width = 88
        '
        'ColumnAddr
        '
        Me.ColumnAddr.Text = "Modbus Addr"
        Me.ColumnAddr.Width = 86
        '
        'clmCh
        '
        Me.clmCh.Text = "CH"
        Me.clmCh.Width = 52
        '
        'clmValue
        '
        Me.clmValue.Text = "Value"
        Me.clmValue.Width = 74
        '
        'clmChStatus
        '
        Me.clmChStatus.Text = "Ch Status"
        Me.clmChStatus.Width = 90
        '
        'clmRange
        '
        Me.clmRange.Text = "Range"
        Me.clmRange.Width = 200
        '
        'panelConfig
        '
        Me.panelConfig.BackColor = System.Drawing.Color.SkyBlue
        Me.panelConfig.Controls.Add(Me.cbxSampleRate)
        Me.panelConfig.Controls.Add(Me.labSampleRate)
        Me.panelConfig.Controls.Add(Me.btnSampleRate)
        Me.panelConfig.Controls.Add(Me.labBurnout)
        Me.panelConfig.Controls.Add(Me.btnBurnoutFcn)
        Me.panelConfig.Controls.Add(Me.chkBurnoutFcn)
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
        Me.panelConfig.Size = New System.Drawing.Size(474, 136)
        Me.panelConfig.TabIndex = 3
        '
        'cbxSampleRate
        '
        Me.cbxSampleRate.Location = New System.Drawing.Point(149, 106)
        Me.cbxSampleRate.Name = "cbxSampleRate"
        Me.cbxSampleRate.Size = New System.Drawing.Size(181, 20)
        Me.cbxSampleRate.TabIndex = 35
        '
        'labSampleRate
        '
        Me.labSampleRate.Location = New System.Drawing.Point(8, 107)
        Me.labSampleRate.Name = "labSampleRate"
        Me.labSampleRate.Size = New System.Drawing.Size(153, 20)
        Me.labSampleRate.TabIndex = 36
        Me.labSampleRate.Text = "Sampling Rate (Hz/Ch):"
        '
        'btnSampleRate
        '
        Me.btnSampleRate.Location = New System.Drawing.Point(345, 105)
        Me.btnSampleRate.Name = "btnSampleRate"
        Me.btnSampleRate.Size = New System.Drawing.Size(86, 24)
        Me.btnSampleRate.TabIndex = 36
        Me.btnSampleRate.Text = "Apply"
        '
        'labBurnout
        '
        Me.labBurnout.Location = New System.Drawing.Point(8, 51)
        Me.labBurnout.Name = "labBurnout"
        Me.labBurnout.Size = New System.Drawing.Size(100, 20)
        Me.labBurnout.TabIndex = 37
        Me.labBurnout.Text = "Burnout Detect:"
        '
        'btnBurnoutFcn
        '
        Me.btnBurnoutFcn.Enabled = False
        Me.btnBurnoutFcn.Location = New System.Drawing.Point(345, 49)
        Me.btnBurnoutFcn.Name = "btnBurnoutFcn"
        Me.btnBurnoutFcn.Size = New System.Drawing.Size(86, 24)
        Me.btnBurnoutFcn.TabIndex = 31
        Me.btnBurnoutFcn.Text = "Apply"
        '
        'chkBurnoutFcn
        '
        Me.chkBurnoutFcn.Enabled = False
        Me.chkBurnoutFcn.Location = New System.Drawing.Point(149, 51)
        Me.chkBurnoutFcn.Name = "chkBurnoutFcn"
        Me.chkBurnoutFcn.Size = New System.Drawing.Size(168, 20)
        Me.chkBurnoutFcn.TabIndex = 32
        Me.chkBurnoutFcn.Text = "Enable"
        '
        'cbxBurnoutValue
        '
        Me.cbxBurnoutValue.Location = New System.Drawing.Point(149, 78)
        Me.cbxBurnoutValue.Name = "cbxBurnoutValue"
        Me.cbxBurnoutValue.Size = New System.Drawing.Size(181, 20)
        Me.cbxBurnoutValue.TabIndex = 15
        '
        'labBurnoutValue
        '
        Me.labBurnoutValue.Location = New System.Drawing.Point(8, 79)
        Me.labBurnoutValue.Name = "labBurnoutValue"
        Me.labBurnoutValue.Size = New System.Drawing.Size(153, 20)
        Me.labBurnoutValue.TabIndex = 38
        Me.labBurnoutValue.Text = "Burnout Detect Mode :"
        '
        'cbxRange
        '
        Me.cbxRange.Location = New System.Drawing.Point(149, 22)
        Me.cbxRange.Name = "cbxRange"
        Me.cbxRange.Size = New System.Drawing.Size(181, 20)
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
        Me.labRange.TabIndex = 39
        Me.labRange.Text = "Range :"
        '
        'btnBurnoutValue
        '
        Me.btnBurnoutValue.Location = New System.Drawing.Point(345, 77)
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
        Me.panelSetting.Size = New System.Drawing.Size(474, 28)
        Me.panelSetting.TabIndex = 4
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
        'Timer1
        '
        '
        'Form_APAX_5017H
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(482, 404)
        Me.Controls.Add(Me.Btn_Quit)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.StatusBar_IO)
        Me.Controls.Add(Me.tcRemote)
        Me.Name = "Form_APAX_5017H"
        Me.Text = "APAX-5017H"
        Me.tcRemote.ResumeLayout(False)
        Me.tabModuleInfo.ResumeLayout(False)
        Me.tabModuleInfo.PerformLayout()
        Me.tabAI.ResumeLayout(False)
        Me.panelConfig.ResumeLayout(False)
        Me.panelSetting.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Btn_Quit As System.Windows.Forms.Button
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents StatusBar_IO As System.Windows.Forms.StatusBar
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
    Private WithEvents listViewChInfo As System.Windows.Forms.ListView
    Private WithEvents clmType As System.Windows.Forms.ColumnHeader
    Private WithEvents clmCh As System.Windows.Forms.ColumnHeader
    Private WithEvents clmValue As System.Windows.Forms.ColumnHeader
    Private WithEvents clmChStatus As System.Windows.Forms.ColumnHeader
    Private WithEvents clmRange As System.Windows.Forms.ColumnHeader
    Private WithEvents panelConfig As System.Windows.Forms.Panel
    Private WithEvents cbxSampleRate As System.Windows.Forms.ComboBox
    Private WithEvents labSampleRate As System.Windows.Forms.Label
    Private WithEvents btnSampleRate As System.Windows.Forms.Button
    Private WithEvents labBurnout As System.Windows.Forms.Label
    Private WithEvents btnBurnoutFcn As System.Windows.Forms.Button
    Private WithEvents chkBurnoutFcn As System.Windows.Forms.CheckBox
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
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ColumnAddr As System.Windows.Forms.ColumnHeader

End Class
