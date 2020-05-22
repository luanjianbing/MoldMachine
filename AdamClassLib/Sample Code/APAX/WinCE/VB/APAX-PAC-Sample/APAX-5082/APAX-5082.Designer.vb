<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Form_APAX_5082
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
        Me.panel2 = New System.Windows.Forms.Panel
        Me.labelCntMin = New System.Windows.Forms.Label
        Me.chkBoxDiFilterEnable = New System.Windows.Forms.CheckBox
        Me.btnApplySetting = New System.Windows.Forms.Button
        Me.labUnit = New System.Windows.Forms.Label
        Me.txtCntMin = New System.Windows.Forms.TextBox
        Me.panelMain = New System.Windows.Forms.Panel
        Me.chbxHide = New System.Windows.Forms.CheckBox
        Me.tabDO = New System.Windows.Forms.TabPage
        Me.listViewChInfo_DO = New System.Windows.Forms.ListView
        Me.clmDOType = New System.Windows.Forms.ColumnHeader
        Me.clmDOCh = New System.Windows.Forms.ColumnHeader
        Me.clmDOValue = New System.Windows.Forms.ColumnHeader
        Me.clmDOMode = New System.Windows.Forms.ColumnHeader
        Me.clmDOSafety = New System.Windows.Forms.ColumnHeader
        Me.panel1 = New System.Windows.Forms.Panel
        Me.btnSetSafetyValue = New System.Windows.Forms.Button
        Me.chbxEnableSafety = New System.Windows.Forms.CheckBox
        Me.label2 = New System.Windows.Forms.Label
        Me.panelSetting = New System.Windows.Forms.Panel
        Me.btnTrue = New System.Windows.Forms.Button
        Me.btnFalse = New System.Windows.Forms.Button
        Me.panelMain_DO = New System.Windows.Forms.Panel
        Me.chbxHide_DO = New System.Windows.Forms.CheckBox
        Me.TabPWM = New System.Windows.Forms.TabPage
        Me.listViewChInfo_PWM = New System.Windows.Forms.ListView
        Me.clmPWMType = New System.Windows.Forms.ColumnHeader
        Me.clmPWMCh = New System.Windows.Forms.ColumnHeader
        Me.clmPWMStatus = New System.Windows.Forms.ColumnHeader
        Me.clmPWMFreq = New System.Windows.Forms.ColumnHeader
        Me.clmPWMDutyCycle = New System.Windows.Forms.ColumnHeader
        Me.panelPWMSetting = New System.Windows.Forms.Panel
        Me.chbxApplyAll = New System.Windows.Forms.CheckBox
        Me.btnMaskDisable = New System.Windows.Forms.Button
        Me.btnMaskEnable = New System.Windows.Forms.Button
        Me.label3 = New System.Windows.Forms.Label
        Me.btnPwmApplySetting = New System.Windows.Forms.Button
        Me.txtDutyCycle = New System.Windows.Forms.TextBox
        Me.txtFrequency = New System.Windows.Forms.TextBox
        Me.label4 = New System.Windows.Forms.Label
        Me.label5 = New System.Windows.Forms.Label
        Me.panelMain_PWM = New System.Windows.Forms.Panel
        Me.chbxHide_PWM = New System.Windows.Forms.CheckBox
        Me.Btn_Quit = New System.Windows.Forms.Button
        Me.btnStart = New System.Windows.Forms.Button
        Me.StatusBar_IO = New System.Windows.Forms.StatusBar
        Me.Timer1 = New System.Windows.Forms.Timer
        Me.tcRemote.SuspendLayout()
        Me.tabModuleInfo.SuspendLayout()
        Me.tabDI.SuspendLayout()
        Me.panel2.SuspendLayout()
        Me.panelMain.SuspendLayout()
        Me.tabDO.SuspendLayout()
        Me.panel1.SuspendLayout()
        Me.panelSetting.SuspendLayout()
        Me.panelMain_DO.SuspendLayout()
        Me.TabPWM.SuspendLayout()
        Me.panelPWMSetting.SuspendLayout()
        Me.panelMain_PWM.SuspendLayout()
        Me.SuspendLayout()
        '
        'tcRemote
        '
        Me.tcRemote.Controls.Add(Me.tabModuleInfo)
        Me.tcRemote.Controls.Add(Me.tabDI)
        Me.tcRemote.Controls.Add(Me.tabDO)
        Me.tcRemote.Controls.Add(Me.TabPWM)
        Me.tcRemote.Dock = System.Windows.Forms.DockStyle.Top
        Me.tcRemote.Enabled = False
        Me.tcRemote.Location = New System.Drawing.Point(0, 0)
        Me.tcRemote.Name = "tcRemote"
        Me.tcRemote.SelectedIndex = 0
        Me.tcRemote.Size = New System.Drawing.Size(454, 321)
        Me.tcRemote.TabIndex = 6
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
        Me.tabModuleInfo.Size = New System.Drawing.Size(446, 292)
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
        Me.tabDI.Controls.Add(Me.panel2)
        Me.tabDI.Controls.Add(Me.panelMain)
        Me.tabDI.Location = New System.Drawing.Point(4, 25)
        Me.tabDI.Name = "tabDI"
        Me.tabDI.Size = New System.Drawing.Size(446, 292)
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
        Me.listViewChInfo_DI.Location = New System.Drawing.Point(0, 109)
        Me.listViewChInfo_DI.Name = "listViewChInfo_DI"
        Me.listViewChInfo_DI.Size = New System.Drawing.Size(446, 183)
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
        'panel2
        '
        Me.panel2.BackColor = System.Drawing.Color.SkyBlue
        Me.panel2.Controls.Add(Me.labelCntMin)
        Me.panel2.Controls.Add(Me.chkBoxDiFilterEnable)
        Me.panel2.Controls.Add(Me.btnApplySetting)
        Me.panel2.Controls.Add(Me.labUnit)
        Me.panel2.Controls.Add(Me.txtCntMin)
        Me.panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel2.Location = New System.Drawing.Point(0, 32)
        Me.panel2.Name = "panel2"
        Me.panel2.Size = New System.Drawing.Size(446, 77)
        '
        'labelCntMin
        '
        Me.labelCntMin.Location = New System.Drawing.Point(8, 37)
        Me.labelCntMin.Name = "labelCntMin"
        Me.labelCntMin.Size = New System.Drawing.Size(222, 24)
        Me.labelCntMin.Text = "Minimum low signal width (5~400)"
        '
        'chkBoxDiFilterEnable
        '
        Me.chkBoxDiFilterEnable.Checked = True
        Me.chkBoxDiFilterEnable.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBoxDiFilterEnable.Enabled = False
        Me.chkBoxDiFilterEnable.Location = New System.Drawing.Point(8, 6)
        Me.chkBoxDiFilterEnable.Name = "chkBoxDiFilterEnable"
        Me.chkBoxDiFilterEnable.Size = New System.Drawing.Size(160, 24)
        Me.chkBoxDiFilterEnable.TabIndex = 5
        Me.chkBoxDiFilterEnable.Text = "DI Filter Enable"
        '
        'btnApplySetting
        '
        Me.btnApplySetting.Location = New System.Drawing.Point(354, 37)
        Me.btnApplySetting.Name = "btnApplySetting"
        Me.btnApplySetting.Size = New System.Drawing.Size(88, 24)
        Me.btnApplySetting.TabIndex = 6
        Me.btnApplySetting.Text = "Apply"
        '
        'labUnit
        '
        Me.labUnit.Location = New System.Drawing.Point(290, 37)
        Me.labUnit.Name = "labUnit"
        Me.labUnit.Size = New System.Drawing.Size(58, 24)
        Me.labUnit.Text = "0.1 ms"
        '
        'txtCntMin
        '
        Me.txtCntMin.Location = New System.Drawing.Point(230, 38)
        Me.txtCntMin.MaxLength = 10
        Me.txtCntMin.Name = "txtCntMin"
        Me.txtCntMin.Size = New System.Drawing.Size(54, 23)
        Me.txtCntMin.TabIndex = 8
        '
        'panelMain
        '
        Me.panelMain.Controls.Add(Me.chbxHide)
        Me.panelMain.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelMain.Location = New System.Drawing.Point(0, 0)
        Me.panelMain.Name = "panelMain"
        Me.panelMain.Size = New System.Drawing.Size(446, 32)
        '
        'chbxHide
        '
        Me.chbxHide.Location = New System.Drawing.Point(8, 8)
        Me.chbxHide.Name = "chbxHide"
        Me.chbxHide.Size = New System.Drawing.Size(168, 20)
        Me.chbxHide.TabIndex = 1
        Me.chbxHide.Text = "Hide Setting Panel"
        '
        'tabDO
        '
        Me.tabDO.Controls.Add(Me.listViewChInfo_DO)
        Me.tabDO.Controls.Add(Me.panel1)
        Me.tabDO.Controls.Add(Me.panelMain_DO)
        Me.tabDO.Location = New System.Drawing.Point(4, 25)
        Me.tabDO.Name = "tabDO"
        Me.tabDO.Size = New System.Drawing.Size(446, 292)
        Me.tabDO.Text = "DO"
        '
        'listViewChInfo_DO
        '
        Me.listViewChInfo_DO.Columns.Add(Me.clmDOType)
        Me.listViewChInfo_DO.Columns.Add(Me.clmDOCh)
        Me.listViewChInfo_DO.Columns.Add(Me.clmDOValue)
        Me.listViewChInfo_DO.Columns.Add(Me.clmDOMode)
        Me.listViewChInfo_DO.Columns.Add(Me.clmDOSafety)
        Me.listViewChInfo_DO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.listViewChInfo_DO.FullRowSelect = True
        Me.listViewChInfo_DO.Location = New System.Drawing.Point(0, 78)
        Me.listViewChInfo_DO.Name = "listViewChInfo_DO"
        Me.listViewChInfo_DO.Size = New System.Drawing.Size(446, 214)
        Me.listViewChInfo_DO.TabIndex = 4
        Me.listViewChInfo_DO.View = System.Windows.Forms.View.Details
        '
        'clmDOType
        '
        Me.clmDOType.Text = "Type"
        Me.clmDOType.Width = 60
        '
        'clmDOCh
        '
        Me.clmDOCh.Text = "CH"
        Me.clmDOCh.Width = 60
        '
        'clmDOValue
        '
        Me.clmDOValue.Text = "Value"
        Me.clmDOValue.Width = 60
        '
        'clmDOMode
        '
        Me.clmDOMode.Text = "Mode"
        Me.clmDOMode.Width = 60
        '
        'clmDOSafety
        '
        Me.clmDOSafety.Text = "Safety Value"
        Me.clmDOSafety.Width = 150
        '
        'panel1
        '
        Me.panel1.BackColor = System.Drawing.Color.SkyBlue
        Me.panel1.Controls.Add(Me.btnSetSafetyValue)
        Me.panel1.Controls.Add(Me.chbxEnableSafety)
        Me.panel1.Controls.Add(Me.label2)
        Me.panel1.Controls.Add(Me.panelSetting)
        Me.panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel1.Location = New System.Drawing.Point(0, 32)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(446, 46)
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
        'panelMain_DO
        '
        Me.panelMain_DO.Controls.Add(Me.chbxHide_DO)
        Me.panelMain_DO.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelMain_DO.Location = New System.Drawing.Point(0, 0)
        Me.panelMain_DO.Name = "panelMain_DO"
        Me.panelMain_DO.Size = New System.Drawing.Size(446, 32)
        '
        'chbxHide_DO
        '
        Me.chbxHide_DO.Location = New System.Drawing.Point(8, 8)
        Me.chbxHide_DO.Name = "chbxHide_DO"
        Me.chbxHide_DO.Size = New System.Drawing.Size(168, 20)
        Me.chbxHide_DO.TabIndex = 1
        Me.chbxHide_DO.Text = "Hide Setting Panel"
        '
        'TabPWM
        '
        Me.TabPWM.Controls.Add(Me.listViewChInfo_PWM)
        Me.TabPWM.Controls.Add(Me.panelPWMSetting)
        Me.TabPWM.Controls.Add(Me.panelMain_PWM)
        Me.TabPWM.Location = New System.Drawing.Point(4, 25)
        Me.TabPWM.Name = "TabPWM"
        Me.TabPWM.Size = New System.Drawing.Size(446, 292)
        Me.TabPWM.Text = "PWM"
        '
        'listViewChInfo_PWM
        '
        Me.listViewChInfo_PWM.Columns.Add(Me.clmPWMType)
        Me.listViewChInfo_PWM.Columns.Add(Me.clmPWMCh)
        Me.listViewChInfo_PWM.Columns.Add(Me.clmPWMStatus)
        Me.listViewChInfo_PWM.Columns.Add(Me.clmPWMFreq)
        Me.listViewChInfo_PWM.Columns.Add(Me.clmPWMDutyCycle)
        Me.listViewChInfo_PWM.Dock = System.Windows.Forms.DockStyle.Fill
        Me.listViewChInfo_PWM.FullRowSelect = True
        Me.listViewChInfo_PWM.Location = New System.Drawing.Point(0, 189)
        Me.listViewChInfo_PWM.Name = "listViewChInfo_PWM"
        Me.listViewChInfo_PWM.Size = New System.Drawing.Size(446, 103)
        Me.listViewChInfo_PWM.TabIndex = 6
        Me.listViewChInfo_PWM.View = System.Windows.Forms.View.Details
        '
        'clmPWMType
        '
        Me.clmPWMType.Text = "Type"
        Me.clmPWMType.Width = 60
        '
        'clmPWMCh
        '
        Me.clmPWMCh.Text = "CH"
        Me.clmPWMCh.Width = 50
        '
        'clmPWMStatus
        '
        Me.clmPWMStatus.Text = "Status"
        Me.clmPWMStatus.Width = 60
        '
        'clmPWMFreq
        '
        Me.clmPWMFreq.Text = "Frequency (Hz)"
        Me.clmPWMFreq.Width = 120
        '
        'clmPWMDutyCycle
        '
        Me.clmPWMDutyCycle.Text = "Duty Cycle (%)"
        Me.clmPWMDutyCycle.Width = 120
        '
        'panelPWMSetting
        '
        Me.panelPWMSetting.BackColor = System.Drawing.Color.SkyBlue
        Me.panelPWMSetting.Controls.Add(Me.chbxApplyAll)
        Me.panelPWMSetting.Controls.Add(Me.btnMaskDisable)
        Me.panelPWMSetting.Controls.Add(Me.btnMaskEnable)
        Me.panelPWMSetting.Controls.Add(Me.label3)
        Me.panelPWMSetting.Controls.Add(Me.btnPwmApplySetting)
        Me.panelPWMSetting.Controls.Add(Me.txtDutyCycle)
        Me.panelPWMSetting.Controls.Add(Me.txtFrequency)
        Me.panelPWMSetting.Controls.Add(Me.label4)
        Me.panelPWMSetting.Controls.Add(Me.label5)
        Me.panelPWMSetting.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelPWMSetting.Location = New System.Drawing.Point(0, 30)
        Me.panelPWMSetting.Name = "panelPWMSetting"
        Me.panelPWMSetting.Size = New System.Drawing.Size(446, 159)
        '
        'chbxApplyAll
        '
        Me.chbxApplyAll.Location = New System.Drawing.Point(8, 6)
        Me.chbxApplyAll.Name = "chbxApplyAll"
        Me.chbxApplyAll.Size = New System.Drawing.Size(172, 20)
        Me.chbxApplyAll.TabIndex = 17
        Me.chbxApplyAll.Text = "Apply to all channels"
        '
        'btnMaskDisable
        '
        Me.btnMaskDisable.Location = New System.Drawing.Point(115, 130)
        Me.btnMaskDisable.Name = "btnMaskDisable"
        Me.btnMaskDisable.Size = New System.Drawing.Size(76, 20)
        Me.btnMaskDisable.TabIndex = 16
        Me.btnMaskDisable.Text = "Stop"
        '
        'btnMaskEnable
        '
        Me.btnMaskEnable.Location = New System.Drawing.Point(17, 130)
        Me.btnMaskEnable.Name = "btnMaskEnable"
        Me.btnMaskEnable.Size = New System.Drawing.Size(76, 20)
        Me.btnMaskEnable.TabIndex = 15
        Me.btnMaskEnable.Text = "Start"
        '
        'label3
        '
        Me.label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular)
        Me.label3.Location = New System.Drawing.Point(8, 78)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(558, 61)
        Me.label3.Text = "Note: Channel 0 and 1 output on the same base frequency, but duty cycle of both c" & _
            "an be different. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "         (Channel 2, 3), (Channel 4, 5), (Channel 6, 7) have " & _
            "the same restriction as (Channel 0, 1)."
        '
        'btnPwmApplySetting
        '
        Me.btnPwmApplySetting.Location = New System.Drawing.Point(315, 26)
        Me.btnPwmApplySetting.Name = "btnPwmApplySetting"
        Me.btnPwmApplySetting.Size = New System.Drawing.Size(100, 32)
        Me.btnPwmApplySetting.TabIndex = 14
        Me.btnPwmApplySetting.Text = "Apply"
        '
        'txtDutyCycle
        '
        Me.txtDutyCycle.Location = New System.Drawing.Point(188, 53)
        Me.txtDutyCycle.MaxLength = 4
        Me.txtDutyCycle.Name = "txtDutyCycle"
        Me.txtDutyCycle.Size = New System.Drawing.Size(100, 23)
        Me.txtDutyCycle.TabIndex = 13
        '
        'txtFrequency
        '
        Me.txtFrequency.Location = New System.Drawing.Point(188, 29)
        Me.txtFrequency.MaxLength = 5
        Me.txtFrequency.Name = "txtFrequency"
        Me.txtFrequency.Size = New System.Drawing.Size(100, 23)
        Me.txtFrequency.TabIndex = 12
        '
        'label4
        '
        Me.label4.Location = New System.Drawing.Point(8, 54)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(174, 20)
        Me.label4.Text = "Duty Cycle (0.1 ~ 99.9%) :"
        '
        'label5
        '
        Me.label5.Location = New System.Drawing.Point(8, 30)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(174, 20)
        Me.label5.Text = "Frequency (1 ~ 30K Hz) :"
        '
        'panelMain_PWM
        '
        Me.panelMain_PWM.Controls.Add(Me.chbxHide_PWM)
        Me.panelMain_PWM.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelMain_PWM.Location = New System.Drawing.Point(0, 0)
        Me.panelMain_PWM.Name = "panelMain_PWM"
        Me.panelMain_PWM.Size = New System.Drawing.Size(446, 30)
        '
        'chbxHide_PWM
        '
        Me.chbxHide_PWM.Location = New System.Drawing.Point(8, 5)
        Me.chbxHide_PWM.Name = "chbxHide_PWM"
        Me.chbxHide_PWM.Size = New System.Drawing.Size(168, 20)
        Me.chbxHide_PWM.TabIndex = 1
        Me.chbxHide_PWM.Text = "Hide Setting Panel"
        '
        'Btn_Quit
        '
        Me.Btn_Quit.Location = New System.Drawing.Point(377, 339)
        Me.Btn_Quit.Name = "Btn_Quit"
        Me.Btn_Quit.Size = New System.Drawing.Size(73, 21)
        Me.Btn_Quit.TabIndex = 23
        Me.Btn_Quit.Text = "Quit"
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(298, 339)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(73, 21)
        Me.btnStart.TabIndex = 22
        Me.btnStart.Text = "Start"
        '
        'StatusBar_IO
        '
        Me.StatusBar_IO.Location = New System.Drawing.Point(0, 366)
        Me.StatusBar_IO.Name = "StatusBar_IO"
        Me.StatusBar_IO.Size = New System.Drawing.Size(454, 24)
        '
        'Timer1
        '
        '
        'Form_APAX_5082
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(454, 390)
        Me.Controls.Add(Me.Btn_Quit)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.StatusBar_IO)
        Me.Controls.Add(Me.tcRemote)
        Me.Name = "Form_APAX_5082"
        Me.Text = "APAX-5082"
        Me.tcRemote.ResumeLayout(False)
        Me.tabModuleInfo.ResumeLayout(False)
        Me.tabDI.ResumeLayout(False)
        Me.panel2.ResumeLayout(False)
        Me.panelMain.ResumeLayout(False)
        Me.tabDO.ResumeLayout(False)
        Me.panel1.ResumeLayout(False)
        Me.panelSetting.ResumeLayout(False)
        Me.panelMain_DO.ResumeLayout(False)
        Me.TabPWM.ResumeLayout(False)
        Me.panelPWMSetting.ResumeLayout(False)
        Me.panelMain_PWM.ResumeLayout(False)
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
    Private WithEvents tabDI As System.Windows.Forms.TabPage
    Private WithEvents listViewChInfo_DI As System.Windows.Forms.ListView
    Private WithEvents clmDIType As System.Windows.Forms.ColumnHeader
    Private WithEvents clmDICh As System.Windows.Forms.ColumnHeader
    Private WithEvents clmDIValue As System.Windows.Forms.ColumnHeader
    Private WithEvents clmDIMode As System.Windows.Forms.ColumnHeader
    Private WithEvents panel2 As System.Windows.Forms.Panel
    Private WithEvents labelCntMin As System.Windows.Forms.Label
    Private WithEvents chkBoxDiFilterEnable As System.Windows.Forms.CheckBox
    Private WithEvents btnApplySetting As System.Windows.Forms.Button
    Private WithEvents labUnit As System.Windows.Forms.Label
    Private WithEvents txtCntMin As System.Windows.Forms.TextBox
    Private WithEvents panelMain As System.Windows.Forms.Panel
    Private WithEvents chbxHide As System.Windows.Forms.CheckBox
    Friend WithEvents tabDO As System.Windows.Forms.TabPage
    Private WithEvents listViewChInfo_DO As System.Windows.Forms.ListView
    Private WithEvents clmDOType As System.Windows.Forms.ColumnHeader
    Private WithEvents clmDOCh As System.Windows.Forms.ColumnHeader
    Private WithEvents clmDOValue As System.Windows.Forms.ColumnHeader
    Private WithEvents clmDOMode As System.Windows.Forms.ColumnHeader
    Private WithEvents clmDOSafety As System.Windows.Forms.ColumnHeader
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents btnSetSafetyValue As System.Windows.Forms.Button
    Private WithEvents chbxEnableSafety As System.Windows.Forms.CheckBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents panelSetting As System.Windows.Forms.Panel
    Private WithEvents btnTrue As System.Windows.Forms.Button
    Private WithEvents btnFalse As System.Windows.Forms.Button
    Private WithEvents panelMain_DO As System.Windows.Forms.Panel
    Private WithEvents chbxHide_DO As System.Windows.Forms.CheckBox
    Friend WithEvents Btn_Quit As System.Windows.Forms.Button
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents StatusBar_IO As System.Windows.Forms.StatusBar
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents TabPWM As System.Windows.Forms.TabPage
    Private WithEvents listViewChInfo_PWM As System.Windows.Forms.ListView
    Private WithEvents clmPWMType As System.Windows.Forms.ColumnHeader
    Private WithEvents clmPWMCh As System.Windows.Forms.ColumnHeader
    Private WithEvents clmPWMStatus As System.Windows.Forms.ColumnHeader
    Private WithEvents clmPWMFreq As System.Windows.Forms.ColumnHeader
    Private WithEvents clmPWMDutyCycle As System.Windows.Forms.ColumnHeader
    Private WithEvents panelPWMSetting As System.Windows.Forms.Panel
    Private WithEvents chbxApplyAll As System.Windows.Forms.CheckBox
    Private WithEvents btnMaskDisable As System.Windows.Forms.Button
    Private WithEvents btnMaskEnable As System.Windows.Forms.Button
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents btnPwmApplySetting As System.Windows.Forms.Button
    Private WithEvents txtDutyCycle As System.Windows.Forms.TextBox
    Private WithEvents txtFrequency As System.Windows.Forms.TextBox
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents panelMain_PWM As System.Windows.Forms.Panel
    Private WithEvents chbxHide_PWM As System.Windows.Forms.CheckBox

End Class
