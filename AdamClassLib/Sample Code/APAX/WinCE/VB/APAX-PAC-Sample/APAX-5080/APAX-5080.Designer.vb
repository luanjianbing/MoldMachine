<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Form_APAX_5080
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
        Me.Btn_Quit = New System.Windows.Forms.Button
        Me.btnStart = New System.Windows.Forms.Button
        Me.StatusBar_IO = New System.Windows.Forms.StatusBar
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
        Me.tabDI = New System.Windows.Forms.TabPage
        Me.listViewChInfo_DI = New System.Windows.Forms.ListView
        Me.clmDIType = New System.Windows.Forms.ColumnHeader
        Me.clmDICh = New System.Windows.Forms.ColumnHeader
        Me.clmDIValue = New System.Windows.Forms.ColumnHeader
        Me.clmDIMode = New System.Windows.Forms.ColumnHeader
        Me.tabDO = New System.Windows.Forms.TabPage
        Me.listViewChInfo_DO = New System.Windows.Forms.ListView
        Me.clmDOType = New System.Windows.Forms.ColumnHeader
        Me.clmDOCh = New System.Windows.Forms.ColumnHeader
        Me.clmDOValue = New System.Windows.Forms.ColumnHeader
        Me.clmDOMode = New System.Windows.Forms.ColumnHeader
        Me.clmDOAlarmType = New System.Windows.Forms.ColumnHeader
        Me.clmDOAlarmLimit = New System.Windows.Forms.ColumnHeader
        Me.clmDOAlarmFlag = New System.Windows.Forms.ColumnHeader
        Me.clmDOMapCh = New System.Windows.Forms.ColumnHeader
        Me.clmDOBehav = New System.Windows.Forms.ColumnHeader
        Me.panelDO = New System.Windows.Forms.Panel
        Me.btnAlarmClearall = New System.Windows.Forms.Button
        Me.btnAlarmClear = New System.Windows.Forms.Button
        Me.btnTrue = New System.Windows.Forms.Button
        Me.label2 = New System.Windows.Forms.Label
        Me.btnFalse = New System.Windows.Forms.Button
        Me.label3 = New System.Windows.Forms.Label
        Me.panelDOSetting = New System.Windows.Forms.Panel
        Me.labHz = New System.Windows.Forms.Label
        Me.chbxApplyAll_DO = New System.Windows.Forms.CheckBox
        Me.txtMappingChannel = New System.Windows.Forms.TextBox
        Me.cbxLocalAlarmMapCh = New System.Windows.Forms.ComboBox
        Me.labLimitVal = New System.Windows.Forms.Label
        Me.txtLocalAlarmLimit = New System.Windows.Forms.TextBox
        Me.rbtnDO = New System.Windows.Forms.RadioButton
        Me.btnApplySetting = New System.Windows.Forms.Button
        Me.cbxAlarmType = New System.Windows.Forms.ComboBox
        Me.labMapCh = New System.Windows.Forms.Label
        Me.labAlarmType = New System.Windows.Forms.Label
        Me.labMode = New System.Windows.Forms.Label
        Me.rbtnAlarm = New System.Windows.Forms.RadioButton
        Me.label4 = New System.Windows.Forms.Label
        Me.txtDOPulseWidth = New System.Windows.Forms.TextBox
        Me.label5 = New System.Windows.Forms.Label
        Me.cbxDOBehavior = New System.Windows.Forms.ComboBox
        Me.chbxAutoRL = New System.Windows.Forms.CheckBox
        Me.panelMain_DO = New System.Windows.Forms.Panel
        Me.chbxHide_DO = New System.Windows.Forms.CheckBox
        Me.tabCNT = New System.Windows.Forms.TabPage
        Me.listViewChInfo_CNT = New System.Windows.Forms.ListView
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader4 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader5 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader7 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader8 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader9 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader10 = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader11 = New System.Windows.Forms.ColumnHeader
        Me.panelSetting = New System.Windows.Forms.Panel
        Me.txtFreqAcqTime = New System.Windows.Forms.TextBox
        Me.btnApplyFilter = New System.Windows.Forms.Button
        Me.txtFilter = New System.Windows.Forms.TextBox
        Me.label6 = New System.Windows.Forms.Label
        Me.label7 = New System.Windows.Forms.Label
        Me.btnFreqAcqTime = New System.Windows.Forms.Button
        Me.panelCNTSetting = New System.Windows.Forms.Panel
        Me.btnClrTriger = New System.Windows.Forms.Button
        Me.cbxTriggerMode = New System.Windows.Forms.ComboBox
        Me.cbxLocalGateMapCh = New System.Windows.Forms.ComboBox
        Me.label8 = New System.Windows.Forms.Label
        Me.chbxApplyAll_CNT = New System.Windows.Forms.CheckBox
        Me.chbxGateEnable = New System.Windows.Forms.CheckBox
        Me.btnApplyGateSetting = New System.Windows.Forms.Button
        Me.label9 = New System.Windows.Forms.Label
        Me.btnApplyCountType = New System.Windows.Forms.Button
        Me.chbxReloadToStartup = New System.Windows.Forms.CheckBox
        Me.chbxRepeat = New System.Windows.Forms.CheckBox
        Me.label10 = New System.Windows.Forms.Label
        Me.btnClearOF = New System.Windows.Forms.Button
        Me.btnResetCnt = New System.Windows.Forms.Button
        Me.btnStop = New System.Windows.Forms.Button
        Me.bth_CNTStart = New System.Windows.Forms.Button
        Me.btnApplyStartup = New System.Windows.Forms.Button
        Me.btnApplySelRange = New System.Windows.Forms.Button
        Me.txtStartupVal = New System.Windows.Forms.TextBox
        Me.cbxRange = New System.Windows.Forms.ComboBox
        Me.labChMask = New System.Windows.Forms.Label
        Me.labRange = New System.Windows.Forms.Label
        Me.cbxGateType = New System.Windows.Forms.ComboBox
        Me.labGateType = New System.Windows.Forms.Label
        Me.labTriggerMode = New System.Windows.Forms.Label
        Me.labStartupVal = New System.Windows.Forms.Label
        Me.panelMain_CNT = New System.Windows.Forms.Panel
        Me.chbxShowRawData = New System.Windows.Forms.CheckBox
        Me.chbxHide_CNT = New System.Windows.Forms.CheckBox
        Me.clmCNTType = New System.Windows.Forms.ColumnHeader
        Me.clmCNTCh = New System.Windows.Forms.ColumnHeader
        Me.clmCNTValue = New System.Windows.Forms.ColumnHeader
        Me.clmCNTMode = New System.Windows.Forms.ColumnHeader
        Me.clmCNTStartup = New System.Windows.Forms.ColumnHeader
        Me.clmCNTCounting = New System.Windows.Forms.ColumnHeader
        Me.clmCNTStatus = New System.Windows.Forms.ColumnHeader
        Me.clmCNTCountType = New System.Windows.Forms.ColumnHeader
        Me.clmCNTMapCh = New System.Windows.Forms.ColumnHeader
        Me.clmCNTGateActive = New System.Windows.Forms.ColumnHeader
        Me.clmCNTGateTrigger = New System.Windows.Forms.ColumnHeader
        Me.Timer1 = New System.Windows.Forms.Timer
        Me.tcRemote.SuspendLayout()
        Me.tabModuleInfo.SuspendLayout()
        Me.tabDI.SuspendLayout()
        Me.tabDO.SuspendLayout()
        Me.panelDO.SuspendLayout()
        Me.panelDOSetting.SuspendLayout()
        Me.panelMain_DO.SuspendLayout()
        Me.tabCNT.SuspendLayout()
        Me.panelSetting.SuspendLayout()
        Me.panelCNTSetting.SuspendLayout()
        Me.panelMain_CNT.SuspendLayout()
        Me.SuspendLayout()
        '
        'Btn_Quit
        '
        Me.Btn_Quit.Location = New System.Drawing.Point(561, 379)
        Me.Btn_Quit.Name = "Btn_Quit"
        Me.Btn_Quit.Size = New System.Drawing.Size(73, 21)
        Me.Btn_Quit.TabIndex = 21
        Me.Btn_Quit.Text = "Quit"
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(482, 379)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(73, 21)
        Me.btnStart.TabIndex = 20
        Me.btnStart.Text = "Start"
        '
        'StatusBar_IO
        '
        Me.StatusBar_IO.Location = New System.Drawing.Point(0, 406)
        Me.StatusBar_IO.Name = "StatusBar_IO"
        Me.StatusBar_IO.Size = New System.Drawing.Size(638, 24)
        '
        'tcRemote
        '
        Me.tcRemote.Controls.Add(Me.tabModuleInfo)
        Me.tcRemote.Controls.Add(Me.tabDI)
        Me.tcRemote.Controls.Add(Me.tabDO)
        Me.tcRemote.Controls.Add(Me.tabCNT)
        Me.tcRemote.Dock = System.Windows.Forms.DockStyle.Top
        Me.tcRemote.Enabled = False
        Me.tcRemote.Location = New System.Drawing.Point(0, 0)
        Me.tcRemote.Name = "tcRemote"
        Me.tcRemote.SelectedIndex = 0
        Me.tcRemote.Size = New System.Drawing.Size(638, 373)
        Me.tcRemote.TabIndex = 19
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
        Me.tabModuleInfo.Location = New System.Drawing.Point(4, 25)
        Me.tabModuleInfo.Name = "tabModuleInfo"
        Me.tabModuleInfo.Size = New System.Drawing.Size(630, 344)
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
        Me.lblLocate.Text = "Locate:"
        '
        'txtModuleID
        '
        Me.txtModuleID.Location = New System.Drawing.Point(135, 9)
        Me.txtModuleID.Name = "txtModuleID"
        Me.txtModuleID.ReadOnly = True
        Me.txtModuleID.Size = New System.Drawing.Size(223, 23)
        Me.txtModuleID.TabIndex = 18
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
        Me.labID.Location = New System.Drawing.Point(4, 40)
        Me.labID.Name = "labID"
        Me.labID.Size = New System.Drawing.Size(100, 20)
        Me.labID.Text = "Switch ID :"
        '
        'labFwVer
        '
        Me.labFwVer.Location = New System.Drawing.Point(4, 100)
        Me.labFwVer.Name = "labFwVer"
        Me.labFwVer.Size = New System.Drawing.Size(125, 20)
        Me.labFwVer.Text = "Firmware Version:"
        '
        'txtSWID
        '
        Me.txtSWID.Location = New System.Drawing.Point(135, 40)
        Me.txtSWID.Name = "txtSWID"
        Me.txtSWID.ReadOnly = True
        Me.txtSWID.Size = New System.Drawing.Size(223, 23)
        Me.txtSWID.TabIndex = 23
        '
        'txtFwVer
        '
        Me.txtFwVer.Location = New System.Drawing.Point(135, 100)
        Me.txtFwVer.Name = "txtFwVer"
        Me.txtFwVer.ReadOnly = True
        Me.txtFwVer.Size = New System.Drawing.Size(223, 23)
        Me.txtFwVer.TabIndex = 25
        '
        'txtSupportKernelFw
        '
        Me.txtSupportKernelFw.Location = New System.Drawing.Point(135, 69)
        Me.txtSupportKernelFw.Name = "txtSupportKernelFw"
        Me.txtSupportKernelFw.ReadOnly = True
        Me.txtSupportKernelFw.Size = New System.Drawing.Size(223, 23)
        Me.txtSupportKernelFw.TabIndex = 26
        '
        'labSupportKernelFw
        '
        Me.labSupportKernelFw.Location = New System.Drawing.Point(4, 72)
        Me.labSupportKernelFw.Name = "labSupportKernelFw"
        Me.labSupportKernelFw.Size = New System.Drawing.Size(124, 20)
        Me.labSupportKernelFw.Text = "Support Kernel Fw:"
        '
        'tabDI
        '
        Me.tabDI.Controls.Add(Me.listViewChInfo_DI)
        Me.tabDI.Location = New System.Drawing.Point(4, 25)
        Me.tabDI.Name = "tabDI"
        Me.tabDI.Size = New System.Drawing.Size(630, 344)
        Me.tabDI.Text = "DI"
        '
        'listViewChInfo_DI
        '
        Me.listViewChInfo_DI.Columns.Add(Me.clmDIType)
        Me.listViewChInfo_DI.Columns.Add(Me.clmDICh)
        Me.listViewChInfo_DI.Columns.Add(Me.clmDIValue)
        Me.listViewChInfo_DI.Columns.Add(Me.clmDIMode)
        Me.listViewChInfo_DI.Dock = System.Windows.Forms.DockStyle.Fill
        Me.listViewChInfo_DI.FullRowSelect = True
        Me.listViewChInfo_DI.Location = New System.Drawing.Point(0, 0)
        Me.listViewChInfo_DI.Name = "listViewChInfo_DI"
        Me.listViewChInfo_DI.Size = New System.Drawing.Size(630, 344)
        Me.listViewChInfo_DI.TabIndex = 7
        Me.listViewChInfo_DI.View = System.Windows.Forms.View.Details
        '
        'clmDIType
        '
        Me.clmDIType.Text = "Type"
        Me.clmDIType.Width = 60
        '
        'clmDICh
        '
        Me.clmDICh.Text = "CH"
        Me.clmDICh.Width = 60
        '
        'clmDIValue
        '
        Me.clmDIValue.Text = "Value"
        Me.clmDIValue.Width = 60
        '
        'clmDIMode
        '
        Me.clmDIMode.Text = "Mode"
        Me.clmDIMode.Width = 60
        '
        'tabDO
        '
        Me.tabDO.Controls.Add(Me.listViewChInfo_DO)
        Me.tabDO.Controls.Add(Me.panelDO)
        Me.tabDO.Controls.Add(Me.panelDOSetting)
        Me.tabDO.Controls.Add(Me.panelMain_DO)
        Me.tabDO.Location = New System.Drawing.Point(4, 25)
        Me.tabDO.Name = "tabDO"
        Me.tabDO.Size = New System.Drawing.Size(630, 344)
        Me.tabDO.Text = "DO"
        '
        'listViewChInfo_DO
        '
        Me.listViewChInfo_DO.Columns.Add(Me.clmDOType)
        Me.listViewChInfo_DO.Columns.Add(Me.clmDOCh)
        Me.listViewChInfo_DO.Columns.Add(Me.clmDOValue)
        Me.listViewChInfo_DO.Columns.Add(Me.clmDOMode)
        Me.listViewChInfo_DO.Columns.Add(Me.clmDOAlarmType)
        Me.listViewChInfo_DO.Columns.Add(Me.clmDOAlarmLimit)
        Me.listViewChInfo_DO.Columns.Add(Me.clmDOAlarmFlag)
        Me.listViewChInfo_DO.Columns.Add(Me.clmDOMapCh)
        Me.listViewChInfo_DO.Columns.Add(Me.clmDOBehav)
        Me.listViewChInfo_DO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.listViewChInfo_DO.FullRowSelect = True
        Me.listViewChInfo_DO.Location = New System.Drawing.Point(0, 176)
        Me.listViewChInfo_DO.Name = "listViewChInfo_DO"
        Me.listViewChInfo_DO.Size = New System.Drawing.Size(630, 168)
        Me.listViewChInfo_DO.TabIndex = 3
        Me.listViewChInfo_DO.View = System.Windows.Forms.View.Details
        '
        'clmDOType
        '
        Me.clmDOType.Text = "Type"
        Me.clmDOType.Width = 40
        '
        'clmDOCh
        '
        Me.clmDOCh.Text = "CH"
        Me.clmDOCh.Width = 30
        '
        'clmDOValue
        '
        Me.clmDOValue.Text = "DO Value"
        Me.clmDOValue.Width = 65
        '
        'clmDOMode
        '
        Me.clmDOMode.Text = "Mode"
        Me.clmDOMode.Width = 45
        '
        'clmDOAlarmType
        '
        Me.clmDOAlarmType.Text = "Alarm Type"
        Me.clmDOAlarmType.Width = 80
        '
        'clmDOAlarmLimit
        '
        Me.clmDOAlarmLimit.Text = "Alarm Limit"
        Me.clmDOAlarmLimit.Width = 80
        '
        'clmDOAlarmFlag
        '
        Me.clmDOAlarmFlag.Text = "Alarm Flag"
        Me.clmDOAlarmFlag.Width = 80
        '
        'clmDOMapCh
        '
        Me.clmDOMapCh.Text = "Map Ch"
        Me.clmDOMapCh.Width = 80
        '
        'clmDOBehav
        '
        Me.clmDOBehav.Text = "DO Behavior"
        Me.clmDOBehav.Width = 100
        '
        'panelDO
        '
        Me.panelDO.BackColor = System.Drawing.Color.SkyBlue
        Me.panelDO.Controls.Add(Me.btnAlarmClearall)
        Me.panelDO.Controls.Add(Me.btnAlarmClear)
        Me.panelDO.Controls.Add(Me.btnTrue)
        Me.panelDO.Controls.Add(Me.label2)
        Me.panelDO.Controls.Add(Me.btnFalse)
        Me.panelDO.Controls.Add(Me.label3)
        Me.panelDO.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelDO.Location = New System.Drawing.Point(0, 142)
        Me.panelDO.Name = "panelDO"
        Me.panelDO.Size = New System.Drawing.Size(630, 34)
        '
        'btnAlarmClearall
        '
        Me.btnAlarmClearall.Enabled = False
        Me.btnAlarmClearall.Location = New System.Drawing.Point(504, 8)
        Me.btnAlarmClearall.Name = "btnAlarmClearall"
        Me.btnAlarmClearall.Size = New System.Drawing.Size(109, 22)
        Me.btnAlarmClearall.TabIndex = 0
        Me.btnAlarmClearall.Text = "Clear all"
        '
        'btnAlarmClear
        '
        Me.btnAlarmClear.Enabled = False
        Me.btnAlarmClear.Location = New System.Drawing.Point(384, 8)
        Me.btnAlarmClear.Name = "btnAlarmClear"
        Me.btnAlarmClear.Size = New System.Drawing.Size(109, 22)
        Me.btnAlarmClear.TabIndex = 1
        Me.btnAlarmClear.Text = "Clear alarm latch"
        '
        'btnTrue
        '
        Me.btnTrue.Location = New System.Drawing.Point(61, 8)
        Me.btnTrue.Name = "btnTrue"
        Me.btnTrue.Size = New System.Drawing.Size(72, 20)
        Me.btnTrue.TabIndex = 0
        Me.btnTrue.Text = "Set True"
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(328, 8)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(52, 20)
        Me.label2.Text = "Alarm:"
        '
        'btnFalse
        '
        Me.btnFalse.Location = New System.Drawing.Point(141, 8)
        Me.btnFalse.Name = "btnFalse"
        Me.btnFalse.Size = New System.Drawing.Size(72, 20)
        Me.btnFalse.TabIndex = 1
        Me.btnFalse.Text = "Set False"
        '
        'label3
        '
        Me.label3.Location = New System.Drawing.Point(6, 8)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(49, 20)
        Me.label3.Text = "DO:"
        '
        'panelDOSetting
        '
        Me.panelDOSetting.BackColor = System.Drawing.Color.SkyBlue
        Me.panelDOSetting.Controls.Add(Me.labHz)
        Me.panelDOSetting.Controls.Add(Me.chbxApplyAll_DO)
        Me.panelDOSetting.Controls.Add(Me.txtMappingChannel)
        Me.panelDOSetting.Controls.Add(Me.cbxLocalAlarmMapCh)
        Me.panelDOSetting.Controls.Add(Me.labLimitVal)
        Me.panelDOSetting.Controls.Add(Me.txtLocalAlarmLimit)
        Me.panelDOSetting.Controls.Add(Me.rbtnDO)
        Me.panelDOSetting.Controls.Add(Me.btnApplySetting)
        Me.panelDOSetting.Controls.Add(Me.cbxAlarmType)
        Me.panelDOSetting.Controls.Add(Me.labMapCh)
        Me.panelDOSetting.Controls.Add(Me.labAlarmType)
        Me.panelDOSetting.Controls.Add(Me.labMode)
        Me.panelDOSetting.Controls.Add(Me.rbtnAlarm)
        Me.panelDOSetting.Controls.Add(Me.label4)
        Me.panelDOSetting.Controls.Add(Me.txtDOPulseWidth)
        Me.panelDOSetting.Controls.Add(Me.label5)
        Me.panelDOSetting.Controls.Add(Me.cbxDOBehavior)
        Me.panelDOSetting.Controls.Add(Me.chbxAutoRL)
        Me.panelDOSetting.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelDOSetting.Location = New System.Drawing.Point(0, 30)
        Me.panelDOSetting.Name = "panelDOSetting"
        Me.panelDOSetting.Size = New System.Drawing.Size(630, 112)
        '
        'labHz
        '
        Me.labHz.Location = New System.Drawing.Point(477, 56)
        Me.labHz.Name = "labHz"
        Me.labHz.Size = New System.Drawing.Size(44, 18)
        Me.labHz.Text = "(Hz)"
        '
        'chbxApplyAll_DO
        '
        Me.chbxApplyAll_DO.Location = New System.Drawing.Point(4, 7)
        Me.chbxApplyAll_DO.Name = "chbxApplyAll_DO"
        Me.chbxApplyAll_DO.Size = New System.Drawing.Size(159, 20)
        Me.chbxApplyAll_DO.TabIndex = 5
        Me.chbxApplyAll_DO.Text = "Apply to All Channels"
        '
        'txtMappingChannel
        '
        Me.txtMappingChannel.Location = New System.Drawing.Point(400, 30)
        Me.txtMappingChannel.Name = "txtMappingChannel"
        Me.txtMappingChannel.ReadOnly = True
        Me.txtMappingChannel.Size = New System.Drawing.Size(112, 23)
        Me.txtMappingChannel.TabIndex = 1
        '
        'cbxLocalAlarmMapCh
        '
        Me.cbxLocalAlarmMapCh.Enabled = False
        Me.cbxLocalAlarmMapCh.Location = New System.Drawing.Point(338, 30)
        Me.cbxLocalAlarmMapCh.Name = "cbxLocalAlarmMapCh"
        Me.cbxLocalAlarmMapCh.Size = New System.Drawing.Size(56, 23)
        Me.cbxLocalAlarmMapCh.TabIndex = 2
        '
        'labLimitVal
        '
        Me.labLimitVal.Location = New System.Drawing.Point(231, 54)
        Me.labLimitVal.Name = "labLimitVal"
        Me.labLimitVal.Size = New System.Drawing.Size(88, 20)
        Me.labLimitVal.Text = "Limit value :"
        '
        'txtLocalAlarmLimit
        '
        Me.txtLocalAlarmLimit.Enabled = False
        Me.txtLocalAlarmLimit.Location = New System.Drawing.Point(400, 54)
        Me.txtLocalAlarmLimit.Name = "txtLocalAlarmLimit"
        Me.txtLocalAlarmLimit.Size = New System.Drawing.Size(70, 23)
        Me.txtLocalAlarmLimit.TabIndex = 3
        Me.txtLocalAlarmLimit.Text = "0"
        '
        'rbtnDO
        '
        Me.rbtnDO.Checked = True
        Me.rbtnDO.Location = New System.Drawing.Point(102, 30)
        Me.rbtnDO.Name = "rbtnDO"
        Me.rbtnDO.Size = New System.Drawing.Size(56, 20)
        Me.rbtnDO.TabIndex = 4
        Me.rbtnDO.Text = "DO"
        '
        'btnApplySetting
        '
        Me.btnApplySetting.Location = New System.Drawing.Point(477, 79)
        Me.btnApplySetting.Name = "btnApplySetting"
        Me.btnApplySetting.Size = New System.Drawing.Size(72, 22)
        Me.btnApplySetting.TabIndex = 6
        Me.btnApplySetting.Text = "Apply"
        '
        'cbxAlarmType
        '
        Me.cbxAlarmType.Enabled = False
        Me.cbxAlarmType.Location = New System.Drawing.Point(102, 54)
        Me.cbxAlarmType.Name = "cbxAlarmType"
        Me.cbxAlarmType.Size = New System.Drawing.Size(94, 23)
        Me.cbxAlarmType.TabIndex = 7
        '
        'labMapCh
        '
        Me.labMapCh.Location = New System.Drawing.Point(231, 30)
        Me.labMapCh.Name = "labMapCh"
        Me.labMapCh.Size = New System.Drawing.Size(115, 20)
        Me.labMapCh.Text = "Mapping channel:"
        '
        'labAlarmType
        '
        Me.labAlarmType.Location = New System.Drawing.Point(6, 54)
        Me.labAlarmType.Name = "labAlarmType"
        Me.labAlarmType.Size = New System.Drawing.Size(100, 20)
        Me.labAlarmType.Text = "Alarm Type:"
        '
        'labMode
        '
        Me.labMode.Location = New System.Drawing.Point(6, 30)
        Me.labMode.Name = "labMode"
        Me.labMode.Size = New System.Drawing.Size(100, 20)
        Me.labMode.Text = "Mode:"
        '
        'rbtnAlarm
        '
        Me.rbtnAlarm.Location = New System.Drawing.Point(157, 30)
        Me.rbtnAlarm.Name = "rbtnAlarm"
        Me.rbtnAlarm.Size = New System.Drawing.Size(68, 20)
        Me.rbtnAlarm.TabIndex = 11
        Me.rbtnAlarm.Text = "Alarm"
        '
        'label4
        '
        Me.label4.Location = New System.Drawing.Point(6, 78)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(90, 20)
        Me.label4.Text = "DO behavior:"
        '
        'txtDOPulseWidth
        '
        Me.txtDOPulseWidth.Enabled = False
        Me.txtDOPulseWidth.Location = New System.Drawing.Point(400, 78)
        Me.txtDOPulseWidth.MaxLength = 6
        Me.txtDOPulseWidth.Name = "txtDOPulseWidth"
        Me.txtDOPulseWidth.Size = New System.Drawing.Size(70, 23)
        Me.txtDOPulseWidth.TabIndex = 14
        Me.txtDOPulseWidth.Text = "1"
        '
        'label5
        '
        Me.label5.Location = New System.Drawing.Point(231, 78)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(146, 20)
        Me.label5.Text = "DO pulse width (ms):"
        '
        'cbxDOBehavior
        '
        Me.cbxDOBehavior.Enabled = False
        Me.cbxDOBehavior.Location = New System.Drawing.Point(102, 78)
        Me.cbxDOBehavior.Name = "cbxDOBehavior"
        Me.cbxDOBehavior.Size = New System.Drawing.Size(94, 23)
        Me.cbxDOBehavior.TabIndex = 16
        '
        'chbxAutoRL
        '
        Me.chbxAutoRL.Enabled = False
        Me.chbxAutoRL.Location = New System.Drawing.Point(514, 31)
        Me.chbxAutoRL.Name = "chbxAutoRL"
        Me.chbxAutoRL.Size = New System.Drawing.Size(72, 20)
        Me.chbxAutoRL.TabIndex = 17
        Me.chbxAutoRL.Text = "AutoRL"
        '
        'panelMain_DO
        '
        Me.panelMain_DO.Controls.Add(Me.chbxHide_DO)
        Me.panelMain_DO.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelMain_DO.Location = New System.Drawing.Point(0, 0)
        Me.panelMain_DO.Name = "panelMain_DO"
        Me.panelMain_DO.Size = New System.Drawing.Size(630, 30)
        '
        'chbxHide_DO
        '
        Me.chbxHide_DO.Location = New System.Drawing.Point(8, 5)
        Me.chbxHide_DO.Name = "chbxHide_DO"
        Me.chbxHide_DO.Size = New System.Drawing.Size(168, 20)
        Me.chbxHide_DO.TabIndex = 1
        Me.chbxHide_DO.Text = "Hide Setting Panel"
        '
        'tabCNT
        '
        Me.tabCNT.Controls.Add(Me.listViewChInfo_CNT)
        Me.tabCNT.Controls.Add(Me.panelSetting)
        Me.tabCNT.Controls.Add(Me.panelCNTSetting)
        Me.tabCNT.Controls.Add(Me.panelMain_CNT)
        Me.tabCNT.Location = New System.Drawing.Point(4, 25)
        Me.tabCNT.Name = "tabCNT"
        Me.tabCNT.Size = New System.Drawing.Size(630, 344)
        Me.tabCNT.Text = "CNT"
        '
        'listViewChInfo_CNT
        '
        Me.listViewChInfo_CNT.Columns.Add(Me.ColumnHeader1)
        Me.listViewChInfo_CNT.Columns.Add(Me.ColumnHeader2)
        Me.listViewChInfo_CNT.Columns.Add(Me.ColumnHeader3)
        Me.listViewChInfo_CNT.Columns.Add(Me.ColumnHeader4)
        Me.listViewChInfo_CNT.Columns.Add(Me.ColumnHeader5)
        Me.listViewChInfo_CNT.Columns.Add(Me.ColumnHeader6)
        Me.listViewChInfo_CNT.Columns.Add(Me.ColumnHeader7)
        Me.listViewChInfo_CNT.Columns.Add(Me.ColumnHeader8)
        Me.listViewChInfo_CNT.Columns.Add(Me.ColumnHeader9)
        Me.listViewChInfo_CNT.Columns.Add(Me.ColumnHeader10)
        Me.listViewChInfo_CNT.Columns.Add(Me.ColumnHeader11)
        Me.listViewChInfo_CNT.Dock = System.Windows.Forms.DockStyle.Fill
        Me.listViewChInfo_CNT.FullRowSelect = True
        Me.listViewChInfo_CNT.Location = New System.Drawing.Point(0, 229)
        Me.listViewChInfo_CNT.Name = "listViewChInfo_CNT"
        Me.listViewChInfo_CNT.Size = New System.Drawing.Size(630, 115)
        Me.listViewChInfo_CNT.TabIndex = 9
        Me.listViewChInfo_CNT.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Type"
        Me.ColumnHeader1.Width = 40
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Ch"
        Me.ColumnHeader2.Width = 30
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Value"
        Me.ColumnHeader3.Width = 60
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Mode"
        Me.ColumnHeader4.Width = 80
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Startup"
        Me.ColumnHeader5.Width = 60
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Counting"
        Me.ColumnHeader6.Width = 60
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Status"
        Me.ColumnHeader7.Width = 55
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Count Type"
        Me.ColumnHeader8.Width = 150
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Map Ch"
        Me.ColumnHeader9.Width = 60
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Gate Active"
        Me.ColumnHeader10.Width = 80
        '
        'ColumnHeader11
        '
        Me.ColumnHeader11.Text = "Gate Trigger"
        Me.ColumnHeader11.Width = 100
        '
        'panelSetting
        '
        Me.panelSetting.BackColor = System.Drawing.Color.SkyBlue
        Me.panelSetting.Controls.Add(Me.txtFreqAcqTime)
        Me.panelSetting.Controls.Add(Me.btnApplyFilter)
        Me.panelSetting.Controls.Add(Me.txtFilter)
        Me.panelSetting.Controls.Add(Me.label6)
        Me.panelSetting.Controls.Add(Me.label7)
        Me.panelSetting.Controls.Add(Me.btnFreqAcqTime)
        Me.panelSetting.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelSetting.Location = New System.Drawing.Point(0, 192)
        Me.panelSetting.Name = "panelSetting"
        Me.panelSetting.Size = New System.Drawing.Size(630, 37)
        '
        'txtFreqAcqTime
        '
        Me.txtFreqAcqTime.Location = New System.Drawing.Point(483, 7)
        Me.txtFreqAcqTime.MaxLength = 10
        Me.txtFreqAcqTime.Name = "txtFreqAcqTime"
        Me.txtFreqAcqTime.Size = New System.Drawing.Size(55, 23)
        Me.txtFreqAcqTime.TabIndex = 0
        Me.txtFreqAcqTime.Text = "1000"
        '
        'btnApplyFilter
        '
        Me.btnApplyFilter.Location = New System.Drawing.Point(230, 6)
        Me.btnApplyFilter.Name = "btnApplyFilter"
        Me.btnApplyFilter.Size = New System.Drawing.Size(60, 24)
        Me.btnApplyFilter.TabIndex = 1
        Me.btnApplyFilter.Text = "Apply"
        '
        'txtFilter
        '
        Me.txtFilter.Location = New System.Drawing.Point(178, 6)
        Me.txtFilter.MaxLength = 10
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(46, 23)
        Me.txtFilter.TabIndex = 2
        Me.txtFilter.Text = "50"
        '
        'label6
        '
        Me.label6.Location = New System.Drawing.Point(296, 7)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(199, 20)
        Me.label6.Text = "Freq.Acq. Time (1~10000 ms):"
        '
        'label7
        '
        Me.label7.Location = New System.Drawing.Point(6, 7)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(180, 20)
        Me.label7.Text = "Digital filter (0~40000.0 us):"
        '
        'btnFreqAcqTime
        '
        Me.btnFreqAcqTime.Location = New System.Drawing.Point(544, 7)
        Me.btnFreqAcqTime.Name = "btnFreqAcqTime"
        Me.btnFreqAcqTime.Size = New System.Drawing.Size(60, 24)
        Me.btnFreqAcqTime.TabIndex = 6
        Me.btnFreqAcqTime.Text = "Apply"
        '
        'panelCNTSetting
        '
        Me.panelCNTSetting.BackColor = System.Drawing.Color.SkyBlue
        Me.panelCNTSetting.Controls.Add(Me.btnClrTriger)
        Me.panelCNTSetting.Controls.Add(Me.cbxTriggerMode)
        Me.panelCNTSetting.Controls.Add(Me.cbxLocalGateMapCh)
        Me.panelCNTSetting.Controls.Add(Me.label8)
        Me.panelCNTSetting.Controls.Add(Me.chbxApplyAll_CNT)
        Me.panelCNTSetting.Controls.Add(Me.chbxGateEnable)
        Me.panelCNTSetting.Controls.Add(Me.btnApplyGateSetting)
        Me.panelCNTSetting.Controls.Add(Me.label9)
        Me.panelCNTSetting.Controls.Add(Me.btnApplyCountType)
        Me.panelCNTSetting.Controls.Add(Me.chbxReloadToStartup)
        Me.panelCNTSetting.Controls.Add(Me.chbxRepeat)
        Me.panelCNTSetting.Controls.Add(Me.label10)
        Me.panelCNTSetting.Controls.Add(Me.btnClearOF)
        Me.panelCNTSetting.Controls.Add(Me.btnResetCnt)
        Me.panelCNTSetting.Controls.Add(Me.btnStop)
        Me.panelCNTSetting.Controls.Add(Me.bth_CNTStart)
        Me.panelCNTSetting.Controls.Add(Me.btnApplyStartup)
        Me.panelCNTSetting.Controls.Add(Me.btnApplySelRange)
        Me.panelCNTSetting.Controls.Add(Me.txtStartupVal)
        Me.panelCNTSetting.Controls.Add(Me.cbxRange)
        Me.panelCNTSetting.Controls.Add(Me.labChMask)
        Me.panelCNTSetting.Controls.Add(Me.labRange)
        Me.panelCNTSetting.Controls.Add(Me.cbxGateType)
        Me.panelCNTSetting.Controls.Add(Me.labGateType)
        Me.panelCNTSetting.Controls.Add(Me.labTriggerMode)
        Me.panelCNTSetting.Controls.Add(Me.labStartupVal)
        Me.panelCNTSetting.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelCNTSetting.Location = New System.Drawing.Point(0, 30)
        Me.panelCNTSetting.Name = "panelCNTSetting"
        Me.panelCNTSetting.Size = New System.Drawing.Size(630, 162)
        '
        'btnClrTriger
        '
        Me.btnClrTriger.Location = New System.Drawing.Point(453, 118)
        Me.btnClrTriger.Name = "btnClrTriger"
        Me.btnClrTriger.Size = New System.Drawing.Size(72, 24)
        Me.btnClrTriger.TabIndex = 0
        Me.btnClrTriger.Text = "Clear"
        '
        'cbxTriggerMode
        '
        Me.cbxTriggerMode.Location = New System.Drawing.Point(479, 89)
        Me.cbxTriggerMode.Name = "cbxTriggerMode"
        Me.cbxTriggerMode.Size = New System.Drawing.Size(124, 23)
        Me.cbxTriggerMode.TabIndex = 1
        '
        'cbxLocalGateMapCh
        '
        Me.cbxLocalGateMapCh.Location = New System.Drawing.Point(531, 30)
        Me.cbxLocalGateMapCh.Name = "cbxLocalGateMapCh"
        Me.cbxLocalGateMapCh.Size = New System.Drawing.Size(72, 23)
        Me.cbxLocalGateMapCh.TabIndex = 2
        '
        'label8
        '
        Me.label8.Location = New System.Drawing.Point(440, 31)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(104, 20)
        Me.label8.Text = "Mapping gate:"
        '
        'chbxApplyAll_CNT
        '
        Me.chbxApplyAll_CNT.Location = New System.Drawing.Point(8, 6)
        Me.chbxApplyAll_CNT.Name = "chbxApplyAll_CNT"
        Me.chbxApplyAll_CNT.Size = New System.Drawing.Size(168, 20)
        Me.chbxApplyAll_CNT.TabIndex = 4
        Me.chbxApplyAll_CNT.Text = "Apply to All Channels"
        '
        'chbxGateEnable
        '
        Me.chbxGateEnable.Location = New System.Drawing.Point(368, 31)
        Me.chbxGateEnable.Name = "chbxGateEnable"
        Me.chbxGateEnable.Size = New System.Drawing.Size(70, 20)
        Me.chbxGateEnable.TabIndex = 4
        Me.chbxGateEnable.Text = "Enable"
        '
        'btnApplyGateSetting
        '
        Me.btnApplyGateSetting.Location = New System.Drawing.Point(531, 118)
        Me.btnApplyGateSetting.Name = "btnApplyGateSetting"
        Me.btnApplyGateSetting.Size = New System.Drawing.Size(72, 24)
        Me.btnApplyGateSetting.TabIndex = 5
        Me.btnApplyGateSetting.Text = "Apply"
        '
        'label9
        '
        Me.label9.Location = New System.Drawing.Point(368, 6)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(134, 20)
        Me.label9.Text = "Counter gate setting:"
        '
        'btnApplyCountType
        '
        Me.btnApplyCountType.Location = New System.Drawing.Point(286, 118)
        Me.btnApplyCountType.Name = "btnApplyCountType"
        Me.btnApplyCountType.Size = New System.Drawing.Size(72, 24)
        Me.btnApplyCountType.TabIndex = 7
        Me.btnApplyCountType.Text = "Apply"
        '
        'chbxReloadToStartup
        '
        Me.chbxReloadToStartup.Location = New System.Drawing.Point(91, 139)
        Me.chbxReloadToStartup.Name = "chbxReloadToStartup"
        Me.chbxReloadToStartup.Size = New System.Drawing.Size(148, 20)
        Me.chbxReloadToStartup.TabIndex = 8
        Me.chbxReloadToStartup.Text = "Reload To Startup"
        '
        'chbxRepeat
        '
        Me.chbxRepeat.Location = New System.Drawing.Point(91, 120)
        Me.chbxRepeat.Name = "chbxRepeat"
        Me.chbxRepeat.Size = New System.Drawing.Size(72, 20)
        Me.chbxRepeat.TabIndex = 9
        Me.chbxRepeat.Text = "Repeat"
        '
        'label10
        '
        Me.label10.Location = New System.Drawing.Point(8, 120)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(86, 20)
        Me.label10.Text = "Count Type:"
        '
        'btnClearOF
        '
        Me.btnClearOF.Location = New System.Drawing.Point(286, 88)
        Me.btnClearOF.Name = "btnClearOF"
        Me.btnClearOF.Size = New System.Drawing.Size(72, 24)
        Me.btnClearOF.TabIndex = 11
        Me.btnClearOF.Text = "Clear Flag"
        '
        'btnResetCnt
        '
        Me.btnResetCnt.Location = New System.Drawing.Point(221, 88)
        Me.btnResetCnt.Name = "btnResetCnt"
        Me.btnResetCnt.Size = New System.Drawing.Size(60, 24)
        Me.btnResetCnt.TabIndex = 12
        Me.btnResetCnt.Text = "Reset"
        '
        'btnStop
        '
        Me.btnStop.Location = New System.Drawing.Point(156, 88)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(60, 24)
        Me.btnStop.TabIndex = 13
        Me.btnStop.Text = "Stop"
        '
        'bth_CNTStart
        '
        Me.bth_CNTStart.Location = New System.Drawing.Point(91, 88)
        Me.bth_CNTStart.Name = "bth_CNTStart"
        Me.bth_CNTStart.Size = New System.Drawing.Size(60, 24)
        Me.bth_CNTStart.TabIndex = 14
        Me.bth_CNTStart.Text = "Start"
        '
        'btnApplyStartup
        '
        Me.btnApplyStartup.Location = New System.Drawing.Point(286, 60)
        Me.btnApplyStartup.Name = "btnApplyStartup"
        Me.btnApplyStartup.Size = New System.Drawing.Size(72, 24)
        Me.btnApplyStartup.TabIndex = 15
        Me.btnApplyStartup.Text = "Apply"
        '
        'btnApplySelRange
        '
        Me.btnApplySelRange.Location = New System.Drawing.Point(286, 29)
        Me.btnApplySelRange.Name = "btnApplySelRange"
        Me.btnApplySelRange.Size = New System.Drawing.Size(72, 24)
        Me.btnApplySelRange.TabIndex = 16
        Me.btnApplySelRange.Text = "Apply"
        '
        'txtStartupVal
        '
        Me.txtStartupVal.Location = New System.Drawing.Point(196, 61)
        Me.txtStartupVal.MaxLength = 10
        Me.txtStartupVal.Name = "txtStartupVal"
        Me.txtStartupVal.Size = New System.Drawing.Size(84, 23)
        Me.txtStartupVal.TabIndex = 17
        Me.txtStartupVal.Text = "0"
        '
        'cbxRange
        '
        Me.cbxRange.Location = New System.Drawing.Point(91, 30)
        Me.cbxRange.Name = "cbxRange"
        Me.cbxRange.Size = New System.Drawing.Size(189, 23)
        Me.cbxRange.TabIndex = 18
        '
        'labChMask
        '
        Me.labChMask.Location = New System.Drawing.Point(8, 90)
        Me.labChMask.Name = "labChMask"
        Me.labChMask.Size = New System.Drawing.Size(86, 20)
        Me.labChMask.Text = "Set Counter:"
        '
        'labRange
        '
        Me.labRange.Location = New System.Drawing.Point(8, 31)
        Me.labRange.Name = "labRange"
        Me.labRange.Size = New System.Drawing.Size(100, 20)
        Me.labRange.Text = "CNT Mode :"
        '
        'cbxGateType
        '
        Me.cbxGateType.Location = New System.Drawing.Point(479, 61)
        Me.cbxGateType.Name = "cbxGateType"
        Me.cbxGateType.Size = New System.Drawing.Size(124, 23)
        Me.cbxGateType.TabIndex = 21
        '
        'labGateType
        '
        Me.labGateType.Location = New System.Drawing.Point(368, 62)
        Me.labGateType.Name = "labGateType"
        Me.labGateType.Size = New System.Drawing.Size(134, 20)
        Me.labGateType.Text = "Gate Active Type:"
        '
        'labTriggerMode
        '
        Me.labTriggerMode.Location = New System.Drawing.Point(368, 90)
        Me.labTriggerMode.Name = "labTriggerMode"
        Me.labTriggerMode.Size = New System.Drawing.Size(100, 20)
        Me.labTriggerMode.Text = "Trigger Mode:"
        '
        'labStartupVal
        '
        Me.labStartupVal.Location = New System.Drawing.Point(8, 62)
        Me.labStartupVal.Name = "labStartupVal"
        Me.labStartupVal.Size = New System.Drawing.Size(208, 20)
        Me.labStartupVal.Text = "Startup value (0~4294967295):"
        '
        'panelMain_CNT
        '
        Me.panelMain_CNT.Controls.Add(Me.chbxShowRawData)
        Me.panelMain_CNT.Controls.Add(Me.chbxHide_CNT)
        Me.panelMain_CNT.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelMain_CNT.Location = New System.Drawing.Point(0, 0)
        Me.panelMain_CNT.Name = "panelMain_CNT"
        Me.panelMain_CNT.Size = New System.Drawing.Size(630, 30)
        '
        'chbxShowRawData
        '
        Me.chbxShowRawData.Location = New System.Drawing.Point(182, 5)
        Me.chbxShowRawData.Name = "chbxShowRawData"
        Me.chbxShowRawData.Size = New System.Drawing.Size(128, 20)
        Me.chbxShowRawData.TabIndex = 31
        Me.chbxShowRawData.Text = "Show Raw Data"
        '
        'chbxHide_CNT
        '
        Me.chbxHide_CNT.Location = New System.Drawing.Point(8, 5)
        Me.chbxHide_CNT.Name = "chbxHide_CNT"
        Me.chbxHide_CNT.Size = New System.Drawing.Size(168, 20)
        Me.chbxHide_CNT.TabIndex = 1
        Me.chbxHide_CNT.Text = "Hide Setting Panel"
        '
        'clmCNTType
        '
        Me.clmCNTType.Text = "Type"
        Me.clmCNTType.Width = 40
        '
        'clmCNTCh
        '
        Me.clmCNTCh.Text = "Ch"
        Me.clmCNTCh.Width = 30
        '
        'clmCNTValue
        '
        Me.clmCNTValue.Text = "Value"
        Me.clmCNTValue.Width = 60
        '
        'clmCNTMode
        '
        Me.clmCNTMode.Text = "Mode"
        Me.clmCNTMode.Width = 80
        '
        'clmCNTStartup
        '
        Me.clmCNTStartup.Text = "Startup"
        Me.clmCNTStartup.Width = 60
        '
        'clmCNTCounting
        '
        Me.clmCNTCounting.Text = "Counting"
        Me.clmCNTCounting.Width = 60
        '
        'clmCNTStatus
        '
        Me.clmCNTStatus.Text = "Status"
        Me.clmCNTStatus.Width = 55
        '
        'clmCNTCountType
        '
        Me.clmCNTCountType.Text = "Count Type"
        Me.clmCNTCountType.Width = 150
        '
        'clmCNTMapCh
        '
        Me.clmCNTMapCh.Text = "Map Ch"
        Me.clmCNTMapCh.Width = 60
        '
        'clmCNTGateActive
        '
        Me.clmCNTGateActive.Text = "Gate Active"
        Me.clmCNTGateActive.Width = 80
        '
        'clmCNTGateTrigger
        '
        Me.clmCNTGateTrigger.Text = "Gate Trigger"
        Me.clmCNTGateTrigger.Width = 100
        '
        'Timer1
        '
        '
        'Form_APAX_5080
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(638, 430)
        Me.Controls.Add(Me.Btn_Quit)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.StatusBar_IO)
        Me.Controls.Add(Me.tcRemote)
        Me.Name = "Form_APAX_5080"
        Me.Text = "APAX-5080"
        Me.tcRemote.ResumeLayout(False)
        Me.tabModuleInfo.ResumeLayout(False)
        Me.tabDI.ResumeLayout(False)
        Me.tabDO.ResumeLayout(False)
        Me.panelDO.ResumeLayout(False)
        Me.panelDOSetting.ResumeLayout(False)
        Me.panelMain_DO.ResumeLayout(False)
        Me.tabCNT.ResumeLayout(False)
        Me.panelSetting.ResumeLayout(False)
        Me.panelCNTSetting.ResumeLayout(False)
        Me.panelMain_CNT.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Btn_Quit As System.Windows.Forms.Button
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents StatusBar_IO As System.Windows.Forms.StatusBar
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
    Private WithEvents tabDI As System.Windows.Forms.TabPage
    Private WithEvents listViewChInfo_DI As System.Windows.Forms.ListView
    Private WithEvents clmDIType As System.Windows.Forms.ColumnHeader
    Private WithEvents clmDICh As System.Windows.Forms.ColumnHeader
    Private WithEvents clmDIValue As System.Windows.Forms.ColumnHeader
    Private WithEvents clmDIMode As System.Windows.Forms.ColumnHeader
    Friend WithEvents tabDO As System.Windows.Forms.TabPage
    Private WithEvents panelMain_DO As System.Windows.Forms.Panel
    Private WithEvents chbxHide_DO As System.Windows.Forms.CheckBox
    Friend WithEvents tabCNT As System.Windows.Forms.TabPage
    Private WithEvents listViewChInfo_DO As System.Windows.Forms.ListView
    Private WithEvents clmDOType As System.Windows.Forms.ColumnHeader
    Private WithEvents clmDOCh As System.Windows.Forms.ColumnHeader
    Private WithEvents clmDOValue As System.Windows.Forms.ColumnHeader
    Private WithEvents clmDOMode As System.Windows.Forms.ColumnHeader
    Private WithEvents clmDOAlarmType As System.Windows.Forms.ColumnHeader
    Private WithEvents clmDOAlarmLimit As System.Windows.Forms.ColumnHeader
    Private WithEvents clmDOAlarmFlag As System.Windows.Forms.ColumnHeader
    Private WithEvents clmDOMapCh As System.Windows.Forms.ColumnHeader
    Private WithEvents clmDOBehav As System.Windows.Forms.ColumnHeader
    Private WithEvents btnAlarmClearall As System.Windows.Forms.Button
    Private WithEvents btnAlarmClear As System.Windows.Forms.Button
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents panelDO As System.Windows.Forms.Panel
    Private WithEvents btnTrue As System.Windows.Forms.Button
    Private WithEvents btnFalse As System.Windows.Forms.Button
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents panelDOSetting As System.Windows.Forms.Panel
    Private WithEvents labHz As System.Windows.Forms.Label
    Private WithEvents chbxApplyAll_DO As System.Windows.Forms.CheckBox
    Private WithEvents txtMappingChannel As System.Windows.Forms.TextBox
    Private WithEvents cbxLocalAlarmMapCh As System.Windows.Forms.ComboBox
    Private WithEvents labLimitVal As System.Windows.Forms.Label
    Private WithEvents txtLocalAlarmLimit As System.Windows.Forms.TextBox
    Private WithEvents rbtnDO As System.Windows.Forms.RadioButton
    Private WithEvents btnApplySetting As System.Windows.Forms.Button
    Private WithEvents cbxAlarmType As System.Windows.Forms.ComboBox
    Private WithEvents labMapCh As System.Windows.Forms.Label
    Private WithEvents labAlarmType As System.Windows.Forms.Label
    Private WithEvents labMode As System.Windows.Forms.Label
    Private WithEvents rbtnAlarm As System.Windows.Forms.RadioButton
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents txtDOPulseWidth As System.Windows.Forms.TextBox
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents cbxDOBehavior As System.Windows.Forms.ComboBox
    Private WithEvents chbxAutoRL As System.Windows.Forms.CheckBox
    Private WithEvents panelSetting As System.Windows.Forms.Panel
    Private WithEvents txtFreqAcqTime As System.Windows.Forms.TextBox
    Private WithEvents btnApplyFilter As System.Windows.Forms.Button
    Private WithEvents txtFilter As System.Windows.Forms.TextBox
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents btnFreqAcqTime As System.Windows.Forms.Button
    Private WithEvents panelMain_CNT As System.Windows.Forms.Panel
    Private WithEvents chbxShowRawData As System.Windows.Forms.CheckBox
    Private WithEvents chbxHide_CNT As System.Windows.Forms.CheckBox
    Private WithEvents panelCNTSetting As System.Windows.Forms.Panel
    Private WithEvents btnClrTriger As System.Windows.Forms.Button
    Private WithEvents cbxTriggerMode As System.Windows.Forms.ComboBox
    Private WithEvents cbxLocalGateMapCh As System.Windows.Forms.ComboBox
    Private WithEvents label8 As System.Windows.Forms.Label
    Private WithEvents chbxApplyAll_CNT As System.Windows.Forms.CheckBox
    Private WithEvents chbxGateEnable As System.Windows.Forms.CheckBox
    Private WithEvents btnApplyGateSetting As System.Windows.Forms.Button
    Private WithEvents label9 As System.Windows.Forms.Label
    Private WithEvents btnApplyCountType As System.Windows.Forms.Button
    Private WithEvents chbxReloadToStartup As System.Windows.Forms.CheckBox
    Private WithEvents chbxRepeat As System.Windows.Forms.CheckBox
    Private WithEvents label10 As System.Windows.Forms.Label
    Private WithEvents btnClearOF As System.Windows.Forms.Button
    Private WithEvents btnResetCnt As System.Windows.Forms.Button
    Private WithEvents btnStop As System.Windows.Forms.Button
    Private WithEvents bth_CNTStart As System.Windows.Forms.Button
    Private WithEvents btnApplyStartup As System.Windows.Forms.Button
    Private WithEvents btnApplySelRange As System.Windows.Forms.Button
    Private WithEvents txtStartupVal As System.Windows.Forms.TextBox
    Private WithEvents cbxRange As System.Windows.Forms.ComboBox
    Private WithEvents labChMask As System.Windows.Forms.Label
    Private WithEvents labRange As System.Windows.Forms.Label
    Private WithEvents cbxGateType As System.Windows.Forms.ComboBox
    Private WithEvents labGateType As System.Windows.Forms.Label
    Private WithEvents labTriggerMode As System.Windows.Forms.Label
    Private WithEvents labStartupVal As System.Windows.Forms.Label
    Private WithEvents listViewChInfo_CNT As System.Windows.Forms.ListView
    Private WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Private WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Private WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Private WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Private WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Private WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Private WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Private WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Private WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Private WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Private WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Private WithEvents clmCNTType As System.Windows.Forms.ColumnHeader
    Private WithEvents clmCNTCh As System.Windows.Forms.ColumnHeader
    Private WithEvents clmCNTValue As System.Windows.Forms.ColumnHeader
    Private WithEvents clmCNTMode As System.Windows.Forms.ColumnHeader
    Private WithEvents clmCNTStartup As System.Windows.Forms.ColumnHeader
    Private WithEvents clmCNTCounting As System.Windows.Forms.ColumnHeader
    Private WithEvents clmCNTStatus As System.Windows.Forms.ColumnHeader
    Private WithEvents clmCNTCountType As System.Windows.Forms.ColumnHeader
    Private WithEvents clmCNTMapCh As System.Windows.Forms.ColumnHeader
    Private WithEvents clmCNTGateActive As System.Windows.Forms.ColumnHeader
    Private WithEvents clmCNTGateTrigger As System.Windows.Forms.ColumnHeader
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
