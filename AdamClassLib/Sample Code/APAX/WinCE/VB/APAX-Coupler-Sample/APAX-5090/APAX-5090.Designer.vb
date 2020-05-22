<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Form_APAX_5090
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
        Me.btnApplySetting = New System.Windows.Forms.Button
        Me.StatusBar_IO = New System.Windows.Forms.StatusBar
        Me.cbxFlowCtrl = New System.Windows.Forms.ComboBox
        Me.labFlowCtrl = New System.Windows.Forms.Label
        Me.cbxStopbit = New System.Windows.Forms.ComboBox
        Me.clmStopBit = New System.Windows.Forms.ColumnHeader
        Me.panelConfig_Serial = New System.Windows.Forms.Panel
        Me.labStopbit = New System.Windows.Forms.Label
        Me.cbxDatabit = New System.Windows.Forms.ComboBox
        Me.labDatabit = New System.Windows.Forms.Label
        Me.cbxParity = New System.Windows.Forms.ComboBox
        Me.labParity = New System.Windows.Forms.Label
        Me.cbxBaudRate = New System.Windows.Forms.ComboBox
        Me.labBaudrate = New System.Windows.Forms.Label
        Me.chbxPortSettingFollowCOM1 = New System.Windows.Forms.CheckBox
        Me.cbxPort = New System.Windows.Forms.ComboBox
        Me.labPort = New System.Windows.Forms.Label
        Me.clmFlowCtrl = New System.Windows.Forms.ColumnHeader
        Me.clmMapTcpPort = New System.Windows.Forms.ColumnHeader
        Me.panelHideControl_Serial = New System.Windows.Forms.Panel
        Me.chbxHide_Serial = New System.Windows.Forms.CheckBox
        Me.clmParity = New System.Windows.Forms.ColumnHeader
        Me.btnLocate = New System.Windows.Forms.Button
        Me.clmDatabit = New System.Windows.Forms.ColumnHeader
        Me.lblLocate = New System.Windows.Forms.Label
        Me.Btn_Quit = New System.Windows.Forms.Button
        Me.txtModule = New System.Windows.Forms.TextBox
        Me.labModule = New System.Windows.Forms.Label
        Me.labFwVer = New System.Windows.Forms.Label
        Me.txtID = New System.Windows.Forms.TextBox
        Me.labID = New System.Windows.Forms.Label
        Me.btnStart = New System.Windows.Forms.Button
        Me.tabModuleInfo = New System.Windows.Forms.TabPage
        Me.txtFwVer = New System.Windows.Forms.TextBox
        Me.txtSupportKernelFw = New System.Windows.Forms.TextBox
        Me.labSupportKernelFw = New System.Windows.Forms.Label
        Me.listViewComPortInfo = New System.Windows.Forms.ListView
        Me.clmSerialItem = New System.Windows.Forms.ColumnHeader
        Me.clmBaudrate = New System.Windows.Forms.ColumnHeader
        Me.panelInfo_Serial = New System.Windows.Forms.Panel
        Me.tabSerial = New System.Windows.Forms.TabPage
        Me.tcRemote = New System.Windows.Forms.TabControl
        Me.panelConfig_Serial.SuspendLayout()
        Me.panelHideControl_Serial.SuspendLayout()
        Me.tabModuleInfo.SuspendLayout()
        Me.panelInfo_Serial.SuspendLayout()
        Me.tabSerial.SuspendLayout()
        Me.tcRemote.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnApplySetting
        '
        Me.btnApplySetting.Location = New System.Drawing.Point(557, 10)
        Me.btnApplySetting.Name = "btnApplySetting"
        Me.btnApplySetting.Size = New System.Drawing.Size(122, 23)
        Me.btnApplySetting.TabIndex = 25
        Me.btnApplySetting.Text = "Apply"
        '
        'StatusBar_IO
        '
        Me.StatusBar_IO.Location = New System.Drawing.Point(0, 410)
        Me.StatusBar_IO.Name = "StatusBar_IO"
        Me.StatusBar_IO.Size = New System.Drawing.Size(766, 24)
        '
        'cbxFlowCtrl
        '
        Me.cbxFlowCtrl.Items.Add("NONE")
        Me.cbxFlowCtrl.Items.Add("RTS")
        Me.cbxFlowCtrl.Items.Add("CTS")
        Me.cbxFlowCtrl.Items.Add("DTR")
        Me.cbxFlowCtrl.Location = New System.Drawing.Point(557, 80)
        Me.cbxFlowCtrl.Name = "cbxFlowCtrl"
        Me.cbxFlowCtrl.Size = New System.Drawing.Size(122, 23)
        Me.cbxFlowCtrl.TabIndex = 24
        '
        'labFlowCtrl
        '
        Me.labFlowCtrl.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.labFlowCtrl.Location = New System.Drawing.Point(465, 80)
        Me.labFlowCtrl.Name = "labFlowCtrl"
        Me.labFlowCtrl.Size = New System.Drawing.Size(81, 23)
        Me.labFlowCtrl.Text = "Flow Control"
        '
        'cbxStopbit
        '
        Me.cbxStopbit.Items.Add("1")
        Me.cbxStopbit.Items.Add("0.5")
        Me.cbxStopbit.Items.Add("2")
        Me.cbxStopbit.Items.Add("1.5")
        Me.cbxStopbit.Location = New System.Drawing.Point(307, 82)
        Me.cbxStopbit.Name = "cbxStopbit"
        Me.cbxStopbit.Size = New System.Drawing.Size(122, 23)
        Me.cbxStopbit.TabIndex = 16
        '
        'clmStopBit
        '
        Me.clmStopBit.Text = "Stopbits"
        Me.clmStopBit.Width = 100
        '
        'panelConfig_Serial
        '
        Me.panelConfig_Serial.BackColor = System.Drawing.Color.SkyBlue
        Me.panelConfig_Serial.Controls.Add(Me.btnApplySetting)
        Me.panelConfig_Serial.Controls.Add(Me.cbxFlowCtrl)
        Me.panelConfig_Serial.Controls.Add(Me.labFlowCtrl)
        Me.panelConfig_Serial.Controls.Add(Me.cbxStopbit)
        Me.panelConfig_Serial.Controls.Add(Me.labStopbit)
        Me.panelConfig_Serial.Controls.Add(Me.cbxDatabit)
        Me.panelConfig_Serial.Controls.Add(Me.labDatabit)
        Me.panelConfig_Serial.Controls.Add(Me.cbxParity)
        Me.panelConfig_Serial.Controls.Add(Me.labParity)
        Me.panelConfig_Serial.Controls.Add(Me.cbxBaudRate)
        Me.panelConfig_Serial.Controls.Add(Me.labBaudrate)
        Me.panelConfig_Serial.Controls.Add(Me.chbxPortSettingFollowCOM1)
        Me.panelConfig_Serial.Controls.Add(Me.cbxPort)
        Me.panelConfig_Serial.Controls.Add(Me.labPort)
        Me.panelConfig_Serial.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelConfig_Serial.Location = New System.Drawing.Point(0, 30)
        Me.panelConfig_Serial.Name = "panelConfig_Serial"
        Me.panelConfig_Serial.Size = New System.Drawing.Size(758, 174)
        '
        'labStopbit
        '
        Me.labStopbit.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.labStopbit.Location = New System.Drawing.Point(238, 81)
        Me.labStopbit.Name = "labStopbit"
        Me.labStopbit.Size = New System.Drawing.Size(54, 22)
        Me.labStopbit.Text = "Stopbits"
        '
        'cbxDatabit
        '
        Me.cbxDatabit.Items.Add("8")
        Me.cbxDatabit.Items.Add("9")
        Me.cbxDatabit.Location = New System.Drawing.Point(307, 43)
        Me.cbxDatabit.Name = "cbxDatabit"
        Me.cbxDatabit.Size = New System.Drawing.Size(122, 23)
        Me.cbxDatabit.TabIndex = 13
        '
        'labDatabit
        '
        Me.labDatabit.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.labDatabit.Location = New System.Drawing.Point(238, 40)
        Me.labDatabit.Name = "labDatabit"
        Me.labDatabit.Size = New System.Drawing.Size(63, 22)
        Me.labDatabit.Text = "Databits"
        '
        'cbxParity
        '
        Me.cbxParity.Items.Add("NONE")
        Me.cbxParity.Items.Add("ODD")
        Me.cbxParity.Items.Add("EVEN")
        Me.cbxParity.Items.Add("MARK")
        Me.cbxParity.Items.Add("SPACE")
        Me.cbxParity.Location = New System.Drawing.Point(79, 82)
        Me.cbxParity.Name = "cbxParity"
        Me.cbxParity.Size = New System.Drawing.Size(122, 23)
        Me.cbxParity.TabIndex = 9
        '
        'labParity
        '
        Me.labParity.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.labParity.Location = New System.Drawing.Point(8, 81)
        Me.labParity.Name = "labParity"
        Me.labParity.Size = New System.Drawing.Size(54, 20)
        Me.labParity.Text = "Parity"
        '
        'cbxBaudRate
        '
        Me.cbxBaudRate.Items.Add("600")
        Me.cbxBaudRate.Items.Add("1200")
        Me.cbxBaudRate.Items.Add("2400")
        Me.cbxBaudRate.Items.Add("4800")
        Me.cbxBaudRate.Items.Add("9600")
        Me.cbxBaudRate.Items.Add("14400")
        Me.cbxBaudRate.Items.Add("19200")
        Me.cbxBaudRate.Items.Add("38400")
        Me.cbxBaudRate.Items.Add("57600")
        Me.cbxBaudRate.Items.Add("115200")
        Me.cbxBaudRate.Location = New System.Drawing.Point(79, 43)
        Me.cbxBaudRate.Name = "cbxBaudRate"
        Me.cbxBaudRate.Size = New System.Drawing.Size(122, 23)
        Me.cbxBaudRate.TabIndex = 6
        '
        'labBaudrate
        '
        Me.labBaudrate.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.labBaudrate.Location = New System.Drawing.Point(8, 41)
        Me.labBaudrate.Name = "labBaudrate"
        Me.labBaudrate.Size = New System.Drawing.Size(64, 21)
        Me.labBaudrate.Text = "Baudrate"
        '
        'chbxPortSettingFollowCOM1
        '
        Me.chbxPortSettingFollowCOM1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chbxPortSettingFollowCOM1.Location = New System.Drawing.Point(238, 8)
        Me.chbxPortSettingFollowCOM1.Name = "chbxPortSettingFollowCOM1"
        Me.chbxPortSettingFollowCOM1.Size = New System.Drawing.Size(138, 20)
        Me.chbxPortSettingFollowCOM1.TabIndex = 4
        Me.chbxPortSettingFollowCOM1.Text = "All follow COM 1"
        '
        'cbxPort
        '
        Me.cbxPort.Items.Add("COM1")
        Me.cbxPort.Items.Add("COM2")
        Me.cbxPort.Items.Add("COM3")
        Me.cbxPort.Items.Add("COM4")
        Me.cbxPort.Location = New System.Drawing.Point(79, 7)
        Me.cbxPort.Name = "cbxPort"
        Me.cbxPort.Size = New System.Drawing.Size(122, 23)
        Me.cbxPort.TabIndex = 2
        '
        'labPort
        '
        Me.labPort.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.labPort.Location = New System.Drawing.Point(8, 8)
        Me.labPort.Name = "labPort"
        Me.labPort.Size = New System.Drawing.Size(36, 22)
        Me.labPort.Text = "Port"
        '
        'clmFlowCtrl
        '
        Me.clmFlowCtrl.Text = "Flow Control"
        Me.clmFlowCtrl.Width = 100
        '
        'clmMapTcpPort
        '
        Me.clmMapTcpPort.Text = "TCP Port"
        Me.clmMapTcpPort.Width = 125
        '
        'panelHideControl_Serial
        '
        Me.panelHideControl_Serial.Controls.Add(Me.chbxHide_Serial)
        Me.panelHideControl_Serial.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHideControl_Serial.Location = New System.Drawing.Point(0, 0)
        Me.panelHideControl_Serial.Name = "panelHideControl_Serial"
        Me.panelHideControl_Serial.Size = New System.Drawing.Size(758, 30)
        '
        'chbxHide_Serial
        '
        Me.chbxHide_Serial.Location = New System.Drawing.Point(8, 5)
        Me.chbxHide_Serial.Name = "chbxHide_Serial"
        Me.chbxHide_Serial.Size = New System.Drawing.Size(168, 20)
        Me.chbxHide_Serial.TabIndex = 1
        Me.chbxHide_Serial.Text = "Hide Setting Panel"
        '
        'clmParity
        '
        Me.clmParity.Text = "Parity"
        Me.clmParity.Width = 100
        '
        'btnLocate
        '
        Me.btnLocate.Location = New System.Drawing.Point(135, 129)
        Me.btnLocate.Name = "btnLocate"
        Me.btnLocate.Size = New System.Drawing.Size(72, 20)
        Me.btnLocate.TabIndex = 50
        Me.btnLocate.Text = "Enable"
        '
        'clmDatabit
        '
        Me.clmDatabit.Text = "Databits"
        Me.clmDatabit.Width = 100
        '
        'lblLocate
        '
        Me.lblLocate.Location = New System.Drawing.Point(4, 129)
        Me.lblLocate.Name = "lblLocate"
        Me.lblLocate.Size = New System.Drawing.Size(56, 20)
        Me.lblLocate.Text = "Locate:"
        '
        'Btn_Quit
        '
        Me.Btn_Quit.Location = New System.Drawing.Point(689, 385)
        Me.Btn_Quit.Name = "Btn_Quit"
        Me.Btn_Quit.Size = New System.Drawing.Size(73, 21)
        Me.Btn_Quit.TabIndex = 32
        Me.Btn_Quit.Text = "Quit"
        '
        'txtModule
        '
        Me.txtModule.Location = New System.Drawing.Point(135, 9)
        Me.txtModule.Name = "txtModule"
        Me.txtModule.ReadOnly = True
        Me.txtModule.Size = New System.Drawing.Size(223, 23)
        Me.txtModule.TabIndex = 18
        '
        'labModule
        '
        Me.labModule.Location = New System.Drawing.Point(4, 9)
        Me.labModule.Name = "labModule"
        Me.labModule.Size = New System.Drawing.Size(100, 20)
        Me.labModule.Text = "Module :"
        '
        'labFwVer
        '
        Me.labFwVer.Location = New System.Drawing.Point(4, 100)
        Me.labFwVer.Name = "labFwVer"
        Me.labFwVer.Size = New System.Drawing.Size(125, 20)
        Me.labFwVer.Text = "Firmware Version:"
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(135, 40)
        Me.txtID.Name = "txtID"
        Me.txtID.ReadOnly = True
        Me.txtID.Size = New System.Drawing.Size(223, 23)
        Me.txtID.TabIndex = 23
        '
        'labID
        '
        Me.labID.Location = New System.Drawing.Point(4, 40)
        Me.labID.Name = "labID"
        Me.labID.Size = New System.Drawing.Size(100, 20)
        Me.labID.Text = "Switch ID :"
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(610, 385)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(73, 21)
        Me.btnStart.TabIndex = 31
        Me.btnStart.Text = "Start"
        '
        'tabModuleInfo
        '
        Me.tabModuleInfo.Controls.Add(Me.btnLocate)
        Me.tabModuleInfo.Controls.Add(Me.lblLocate)
        Me.tabModuleInfo.Controls.Add(Me.txtModule)
        Me.tabModuleInfo.Controls.Add(Me.labModule)
        Me.tabModuleInfo.Controls.Add(Me.labID)
        Me.tabModuleInfo.Controls.Add(Me.labFwVer)
        Me.tabModuleInfo.Controls.Add(Me.txtID)
        Me.tabModuleInfo.Controls.Add(Me.txtFwVer)
        Me.tabModuleInfo.Controls.Add(Me.txtSupportKernelFw)
        Me.tabModuleInfo.Controls.Add(Me.labSupportKernelFw)
        Me.tabModuleInfo.Location = New System.Drawing.Point(4, 25)
        Me.tabModuleInfo.Name = "tabModuleInfo"
        Me.tabModuleInfo.Size = New System.Drawing.Size(758, 350)
        Me.tabModuleInfo.Text = "Module Information"
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
        'listViewComPortInfo
        '
        Me.listViewComPortInfo.Columns.Add(Me.clmSerialItem)
        Me.listViewComPortInfo.Columns.Add(Me.clmBaudrate)
        Me.listViewComPortInfo.Columns.Add(Me.clmDatabit)
        Me.listViewComPortInfo.Columns.Add(Me.clmParity)
        Me.listViewComPortInfo.Columns.Add(Me.clmStopBit)
        Me.listViewComPortInfo.Columns.Add(Me.clmFlowCtrl)
        Me.listViewComPortInfo.Columns.Add(Me.clmMapTcpPort)
        Me.listViewComPortInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.listViewComPortInfo.FullRowSelect = True
        Me.listViewComPortInfo.Location = New System.Drawing.Point(0, 0)
        Me.listViewComPortInfo.Name = "listViewComPortInfo"
        Me.listViewComPortInfo.Size = New System.Drawing.Size(758, 147)
        Me.listViewComPortInfo.TabIndex = 9
        Me.listViewComPortInfo.View = System.Windows.Forms.View.Details
        '
        'clmSerialItem
        '
        Me.clmSerialItem.Text = "Item"
        Me.clmSerialItem.Width = 90
        '
        'clmBaudrate
        '
        Me.clmBaudrate.Text = "Baudrate"
        Me.clmBaudrate.Width = 100
        '
        'panelInfo_Serial
        '
        Me.panelInfo_Serial.Controls.Add(Me.listViewComPortInfo)
        Me.panelInfo_Serial.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelInfo_Serial.Location = New System.Drawing.Point(0, 204)
        Me.panelInfo_Serial.Name = "panelInfo_Serial"
        Me.panelInfo_Serial.Size = New System.Drawing.Size(758, 147)
        '
        'tabSerial
        '
        Me.tabSerial.Controls.Add(Me.panelInfo_Serial)
        Me.tabSerial.Controls.Add(Me.panelConfig_Serial)
        Me.tabSerial.Controls.Add(Me.panelHideControl_Serial)
        Me.tabSerial.Location = New System.Drawing.Point(4, 25)
        Me.tabSerial.Name = "tabSerial"
        Me.tabSerial.Size = New System.Drawing.Size(758, 350)
        Me.tabSerial.Text = "Serial"
        '
        'tcRemote
        '
        Me.tcRemote.Controls.Add(Me.tabModuleInfo)
        Me.tcRemote.Controls.Add(Me.tabSerial)
        Me.tcRemote.Dock = System.Windows.Forms.DockStyle.Top
        Me.tcRemote.Enabled = False
        Me.tcRemote.Location = New System.Drawing.Point(0, 0)
        Me.tcRemote.Name = "tcRemote"
        Me.tcRemote.SelectedIndex = 0
        Me.tcRemote.Size = New System.Drawing.Size(766, 379)
        Me.tcRemote.TabIndex = 30
        Me.tcRemote.Visible = False
        '
        'Form_APAX_5090
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(766, 434)
        Me.Controls.Add(Me.StatusBar_IO)
        Me.Controls.Add(Me.Btn_Quit)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.tcRemote)
        Me.Name = "Form_APAX_5090"
        Me.Text = "APAX_5090"
        Me.panelConfig_Serial.ResumeLayout(False)
        Me.panelHideControl_Serial.ResumeLayout(False)
        Me.tabModuleInfo.ResumeLayout(False)
        Me.panelInfo_Serial.ResumeLayout(False)
        Me.tabSerial.ResumeLayout(False)
        Me.tcRemote.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents btnApplySetting As System.Windows.Forms.Button
    Friend WithEvents StatusBar_IO As System.Windows.Forms.StatusBar
    Private WithEvents cbxFlowCtrl As System.Windows.Forms.ComboBox
    Private WithEvents labFlowCtrl As System.Windows.Forms.Label
    Private WithEvents cbxStopbit As System.Windows.Forms.ComboBox
    Private WithEvents clmStopBit As System.Windows.Forms.ColumnHeader
    Private WithEvents panelConfig_Serial As System.Windows.Forms.Panel
    Private WithEvents labStopbit As System.Windows.Forms.Label
    Private WithEvents cbxDatabit As System.Windows.Forms.ComboBox
    Private WithEvents labDatabit As System.Windows.Forms.Label
    Private WithEvents cbxParity As System.Windows.Forms.ComboBox
    Private WithEvents labParity As System.Windows.Forms.Label
    Private WithEvents cbxBaudRate As System.Windows.Forms.ComboBox
    Private WithEvents labBaudrate As System.Windows.Forms.Label
    Private WithEvents chbxPortSettingFollowCOM1 As System.Windows.Forms.CheckBox
    Private WithEvents cbxPort As System.Windows.Forms.ComboBox
    Private WithEvents labPort As System.Windows.Forms.Label
    Private WithEvents clmFlowCtrl As System.Windows.Forms.ColumnHeader
    Private WithEvents clmMapTcpPort As System.Windows.Forms.ColumnHeader
    Private WithEvents panelHideControl_Serial As System.Windows.Forms.Panel
    Private WithEvents chbxHide_Serial As System.Windows.Forms.CheckBox
    Private WithEvents clmParity As System.Windows.Forms.ColumnHeader
    Private WithEvents btnLocate As System.Windows.Forms.Button
    Private WithEvents clmDatabit As System.Windows.Forms.ColumnHeader
    Private WithEvents lblLocate As System.Windows.Forms.Label
    Friend WithEvents Btn_Quit As System.Windows.Forms.Button
    Private WithEvents txtModule As System.Windows.Forms.TextBox
    Private WithEvents labModule As System.Windows.Forms.Label
    Private WithEvents labFwVer As System.Windows.Forms.Label
    Private WithEvents txtID As System.Windows.Forms.TextBox
    Private WithEvents labID As System.Windows.Forms.Label
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Private WithEvents tabModuleInfo As System.Windows.Forms.TabPage
    Private WithEvents txtFwVer As System.Windows.Forms.TextBox
    Private WithEvents txtSupportKernelFw As System.Windows.Forms.TextBox
    Private WithEvents labSupportKernelFw As System.Windows.Forms.Label
    Private WithEvents listViewComPortInfo As System.Windows.Forms.ListView
    Private WithEvents clmSerialItem As System.Windows.Forms.ColumnHeader
    Private WithEvents clmBaudrate As System.Windows.Forms.ColumnHeader
    Private WithEvents panelInfo_Serial As System.Windows.Forms.Panel
    Private WithEvents tabSerial As System.Windows.Forms.TabPage
    Private WithEvents tcRemote As System.Windows.Forms.TabControl

End Class
