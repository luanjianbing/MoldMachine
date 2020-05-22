<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_APAX_5090
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
        Me.labParity = New System.Windows.Forms.Label
        Me.cbxParity = New System.Windows.Forms.ComboBox
        Me.labStopbit = New System.Windows.Forms.Label
        Me.tableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.StatusBar_IO = New System.Windows.Forms.StatusBar
        Me.tcRemote = New System.Windows.Forms.TabControl
        Me.tabModuleInfo = New System.Windows.Forms.TabPage
        Me.tableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.labModule = New System.Windows.Forms.Label
        Me.txtModule = New System.Windows.Forms.TextBox
        Me.labID = New System.Windows.Forms.Label
        Me.txtID = New System.Windows.Forms.TextBox
        Me.labSupportKernelFw = New System.Windows.Forms.Label
        Me.txtSupportKernelFw = New System.Windows.Forms.TextBox
        Me.labFwVer = New System.Windows.Forms.Label
        Me.txtFwVer = New System.Windows.Forms.TextBox
        Me.label1 = New System.Windows.Forms.Label
        Me.btnLocate = New System.Windows.Forms.Button
        Me.tabSerial = New System.Windows.Forms.TabPage
        Me.flowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel
        Me.panelHideControl_Serial = New System.Windows.Forms.Panel
        Me.chbxHide_Serial = New System.Windows.Forms.CheckBox
        Me.panelConfig_Serial = New System.Windows.Forms.Panel
        Me.tableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel
        Me.tableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel
        Me.cbxDatabit = New System.Windows.Forms.ComboBox
        Me.labDatabit = New System.Windows.Forms.Label
        Me.cbxBaudRate = New System.Windows.Forms.ComboBox
        Me.labBaudrate = New System.Windows.Forms.Label
        Me.tableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel
        Me.cbxPort = New System.Windows.Forms.ComboBox
        Me.labPort = New System.Windows.Forms.Label
        Me.btnApplySetting = New System.Windows.Forms.Button
        Me.chbxPortSettingFollowCOM1 = New System.Windows.Forms.CheckBox
        Me.tableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel
        Me.cbxStopbit = New System.Windows.Forms.ComboBox
        Me.labFlowCtrl = New System.Windows.Forms.Label
        Me.cbxFlowCtrl = New System.Windows.Forms.ComboBox
        Me.panelInfo_Serial = New System.Windows.Forms.Panel
        Me.listViewComPortInfo = New System.Windows.Forms.ListView
        Me.clmSerialItem = New System.Windows.Forms.ColumnHeader
        Me.clmBaudrate = New System.Windows.Forms.ColumnHeader
        Me.clmDatabit = New System.Windows.Forms.ColumnHeader
        Me.clmParity = New System.Windows.Forms.ColumnHeader
        Me.clmStopBit = New System.Windows.Forms.ColumnHeader
        Me.clmFlowCtrl = New System.Windows.Forms.ColumnHeader
        Me.clmMapTcpPort = New System.Windows.Forms.ColumnHeader
        Me.flowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
        Me.btnStart = New System.Windows.Forms.Button
        Me.Btn_Quit = New System.Windows.Forms.Button
        Me.tableLayoutPanel1.SuspendLayout()
        Me.tcRemote.SuspendLayout()
        Me.tabModuleInfo.SuspendLayout()
        Me.tableLayoutPanel2.SuspendLayout()
        Me.tabSerial.SuspendLayout()
        Me.flowLayoutPanel2.SuspendLayout()
        Me.panelHideControl_Serial.SuspendLayout()
        Me.panelConfig_Serial.SuspendLayout()
        Me.tableLayoutPanel4.SuspendLayout()
        Me.tableLayoutPanel5.SuspendLayout()
        Me.tableLayoutPanel3.SuspendLayout()
        Me.tableLayoutPanel6.SuspendLayout()
        Me.panelInfo_Serial.SuspendLayout()
        Me.flowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'labParity
        '
        Me.labParity.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.labParity.AutoSize = True
        Me.labParity.Location = New System.Drawing.Point(3, 8)
        Me.labParity.Name = "labParity"
        Me.labParity.Size = New System.Drawing.Size(54, 12)
        Me.labParity.TabIndex = 0
        Me.labParity.Text = "Parity"
        '
        'cbxParity
        '
        Me.cbxParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxParity.FormattingEnabled = True
        Me.cbxParity.Items.AddRange(New Object() {"NONE", "ODD", "EVEN", "MARK", "SPACE"})
        Me.cbxParity.Location = New System.Drawing.Point(63, 3)
        Me.cbxParity.Name = "cbxParity"
        Me.cbxParity.Size = New System.Drawing.Size(84, 20)
        Me.cbxParity.TabIndex = 1
        '
        'labStopbit
        '
        Me.labStopbit.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.labStopbit.AutoSize = True
        Me.labStopbit.Location = New System.Drawing.Point(178, 8)
        Me.labStopbit.Name = "labStopbit"
        Me.labStopbit.Size = New System.Drawing.Size(54, 12)
        Me.labStopbit.TabIndex = 2
        Me.labStopbit.Text = "Stopbits"
        '
        'tableLayoutPanel1
        '
        Me.tableLayoutPanel1.ColumnCount = 1
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tableLayoutPanel1.Controls.Add(Me.StatusBar_IO, 0, 2)
        Me.tableLayoutPanel1.Controls.Add(Me.tcRemote, 0, 0)
        Me.tableLayoutPanel1.Controls.Add(Me.flowLayoutPanel1, 0, 1)
        Me.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
        Me.tableLayoutPanel1.RowCount = 3
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.tableLayoutPanel1.Size = New System.Drawing.Size(752, 421)
        Me.tableLayoutPanel1.TabIndex = 3
        '
        'StatusBar_IO
        '
        Me.StatusBar_IO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.StatusBar_IO.Location = New System.Drawing.Point(3, 389)
        Me.StatusBar_IO.Name = "StatusBar_IO"
        Me.StatusBar_IO.Size = New System.Drawing.Size(746, 29)
        Me.StatusBar_IO.TabIndex = 26
        '
        'tcRemote
        '
        Me.tcRemote.Controls.Add(Me.tabModuleInfo)
        Me.tcRemote.Controls.Add(Me.tabSerial)
        Me.tcRemote.Location = New System.Drawing.Point(3, 3)
        Me.tcRemote.Name = "tcRemote"
        Me.tcRemote.SelectedIndex = 0
        Me.tcRemote.Size = New System.Drawing.Size(746, 345)
        Me.tcRemote.TabIndex = 1
        Me.tcRemote.Visible = False
        '
        'tabModuleInfo
        '
        Me.tabModuleInfo.BackColor = System.Drawing.SystemColors.Control
        Me.tabModuleInfo.Controls.Add(Me.tableLayoutPanel2)
        Me.tabModuleInfo.Location = New System.Drawing.Point(4, 22)
        Me.tabModuleInfo.Name = "tabModuleInfo"
        Me.tabModuleInfo.Padding = New System.Windows.Forms.Padding(3)
        Me.tabModuleInfo.Size = New System.Drawing.Size(738, 319)
        Me.tabModuleInfo.TabIndex = 0
        Me.tabModuleInfo.Text = "Module Information"
        '
        'tableLayoutPanel2
        '
        Me.tableLayoutPanel2.ColumnCount = 2
        Me.tableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120.0!))
        Me.tableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tableLayoutPanel2.Controls.Add(Me.labModule, 0, 0)
        Me.tableLayoutPanel2.Controls.Add(Me.txtModule, 1, 0)
        Me.tableLayoutPanel2.Controls.Add(Me.labID, 0, 1)
        Me.tableLayoutPanel2.Controls.Add(Me.txtID, 1, 1)
        Me.tableLayoutPanel2.Controls.Add(Me.labSupportKernelFw, 0, 2)
        Me.tableLayoutPanel2.Controls.Add(Me.txtSupportKernelFw, 1, 2)
        Me.tableLayoutPanel2.Controls.Add(Me.labFwVer, 0, 3)
        Me.tableLayoutPanel2.Controls.Add(Me.txtFwVer, 1, 3)
        Me.tableLayoutPanel2.Controls.Add(Me.label1, 0, 4)
        Me.tableLayoutPanel2.Controls.Add(Me.btnLocate, 1, 4)
        Me.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.tableLayoutPanel2.Name = "tableLayoutPanel2"
        Me.tableLayoutPanel2.RowCount = 6
        Me.tableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.tableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tableLayoutPanel2.Size = New System.Drawing.Size(732, 313)
        Me.tableLayoutPanel2.TabIndex = 0
        '
        'labModule
        '
        Me.labModule.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.labModule.Location = New System.Drawing.Point(3, 5)
        Me.labModule.Name = "labModule"
        Me.labModule.Size = New System.Drawing.Size(100, 20)
        Me.labModule.TabIndex = 32
        Me.labModule.Text = "Module :"
        '
        'txtModule
        '
        Me.txtModule.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtModule.Location = New System.Drawing.Point(123, 4)
        Me.txtModule.Name = "txtModule"
        Me.txtModule.ReadOnly = True
        Me.txtModule.Size = New System.Drawing.Size(223, 22)
        Me.txtModule.TabIndex = 33
        '
        'labID
        '
        Me.labID.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.labID.Location = New System.Drawing.Point(3, 35)
        Me.labID.Name = "labID"
        Me.labID.Size = New System.Drawing.Size(100, 20)
        Me.labID.TabIndex = 34
        Me.labID.Text = "Switch ID :"
        '
        'txtID
        '
        Me.txtID.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtID.Location = New System.Drawing.Point(123, 34)
        Me.txtID.Name = "txtID"
        Me.txtID.ReadOnly = True
        Me.txtID.Size = New System.Drawing.Size(223, 22)
        Me.txtID.TabIndex = 35
        '
        'labSupportKernelFw
        '
        Me.labSupportKernelFw.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.labSupportKernelFw.Location = New System.Drawing.Point(3, 65)
        Me.labSupportKernelFw.Name = "labSupportKernelFw"
        Me.labSupportKernelFw.Size = New System.Drawing.Size(114, 20)
        Me.labSupportKernelFw.TabIndex = 36
        Me.labSupportKernelFw.Text = "Support Kernel Fw:"
        '
        'txtSupportKernelFw
        '
        Me.txtSupportKernelFw.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtSupportKernelFw.Location = New System.Drawing.Point(123, 64)
        Me.txtSupportKernelFw.Name = "txtSupportKernelFw"
        Me.txtSupportKernelFw.ReadOnly = True
        Me.txtSupportKernelFw.Size = New System.Drawing.Size(223, 22)
        Me.txtSupportKernelFw.TabIndex = 37
        '
        'labFwVer
        '
        Me.labFwVer.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.labFwVer.Location = New System.Drawing.Point(3, 95)
        Me.labFwVer.Name = "labFwVer"
        Me.labFwVer.Size = New System.Drawing.Size(114, 20)
        Me.labFwVer.TabIndex = 38
        Me.labFwVer.Text = "Firmware Version:"
        '
        'txtFwVer
        '
        Me.txtFwVer.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.txtFwVer.Location = New System.Drawing.Point(123, 94)
        Me.txtFwVer.Name = "txtFwVer"
        Me.txtFwVer.ReadOnly = True
        Me.txtFwVer.Size = New System.Drawing.Size(223, 22)
        Me.txtFwVer.TabIndex = 39
        '
        'label1
        '
        Me.label1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.label1.Location = New System.Drawing.Point(3, 125)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(56, 20)
        Me.label1.TabIndex = 40
        Me.label1.Text = "Locate"
        '
        'btnLocate
        '
        Me.btnLocate.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnLocate.Location = New System.Drawing.Point(123, 125)
        Me.btnLocate.Name = "btnLocate"
        Me.btnLocate.Size = New System.Drawing.Size(72, 20)
        Me.btnLocate.TabIndex = 41
        Me.btnLocate.Text = "Enable"
        '
        'tabSerial
        '
        Me.tabSerial.BackColor = System.Drawing.SystemColors.Control
        Me.tabSerial.Controls.Add(Me.flowLayoutPanel2)
        Me.tabSerial.Location = New System.Drawing.Point(4, 22)
        Me.tabSerial.Name = "tabSerial"
        Me.tabSerial.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSerial.Size = New System.Drawing.Size(738, 319)
        Me.tabSerial.TabIndex = 1
        Me.tabSerial.Text = "Serial"
        '
        'flowLayoutPanel2
        '
        Me.flowLayoutPanel2.Controls.Add(Me.panelHideControl_Serial)
        Me.flowLayoutPanel2.Controls.Add(Me.panelConfig_Serial)
        Me.flowLayoutPanel2.Controls.Add(Me.panelInfo_Serial)
        Me.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flowLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.flowLayoutPanel2.Name = "flowLayoutPanel2"
        Me.flowLayoutPanel2.Size = New System.Drawing.Size(732, 313)
        Me.flowLayoutPanel2.TabIndex = 0
        '
        'panelHideControl_Serial
        '
        Me.panelHideControl_Serial.Controls.Add(Me.chbxHide_Serial)
        Me.panelHideControl_Serial.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelHideControl_Serial.Location = New System.Drawing.Point(3, 3)
        Me.panelHideControl_Serial.Name = "panelHideControl_Serial"
        Me.panelHideControl_Serial.Size = New System.Drawing.Size(726, 32)
        Me.panelHideControl_Serial.TabIndex = 7
        '
        'chbxHide_Serial
        '
        Me.chbxHide_Serial.Location = New System.Drawing.Point(8, 8)
        Me.chbxHide_Serial.Name = "chbxHide_Serial"
        Me.chbxHide_Serial.Size = New System.Drawing.Size(168, 20)
        Me.chbxHide_Serial.TabIndex = 1
        Me.chbxHide_Serial.Text = "Hide Setting Panel"
        '
        'panelConfig_Serial
        '
        Me.panelConfig_Serial.BackColor = System.Drawing.Color.SkyBlue
        Me.panelConfig_Serial.Controls.Add(Me.tableLayoutPanel4)
        Me.panelConfig_Serial.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelConfig_Serial.Location = New System.Drawing.Point(3, 41)
        Me.panelConfig_Serial.Name = "panelConfig_Serial"
        Me.panelConfig_Serial.Size = New System.Drawing.Size(726, 114)
        Me.panelConfig_Serial.TabIndex = 8
        '
        'tableLayoutPanel4
        '
        Me.tableLayoutPanel4.ColumnCount = 1
        Me.tableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tableLayoutPanel4.Controls.Add(Me.tableLayoutPanel5, 0, 1)
        Me.tableLayoutPanel4.Controls.Add(Me.tableLayoutPanel3, 0, 0)
        Me.tableLayoutPanel4.Controls.Add(Me.tableLayoutPanel6, 0, 2)
        Me.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tableLayoutPanel4.Location = New System.Drawing.Point(0, 0)
        Me.tableLayoutPanel4.Name = "tableLayoutPanel4"
        Me.tableLayoutPanel4.RowCount = 4
        Me.tableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.tableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.tableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.tableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1.0!))
        Me.tableLayoutPanel4.Size = New System.Drawing.Size(726, 114)
        Me.tableLayoutPanel4.TabIndex = 1
        '
        'tableLayoutPanel5
        '
        Me.tableLayoutPanel5.ColumnCount = 6
        Me.tableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.tableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.tableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.tableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.tableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tableLayoutPanel5.Controls.Add(Me.cbxDatabit, 4, 0)
        Me.tableLayoutPanel5.Controls.Add(Me.labDatabit, 3, 0)
        Me.tableLayoutPanel5.Controls.Add(Me.cbxBaudRate, 1, 0)
        Me.tableLayoutPanel5.Controls.Add(Me.labBaudrate, 0, 0)
        Me.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tableLayoutPanel5.Location = New System.Drawing.Point(3, 38)
        Me.tableLayoutPanel5.Name = "tableLayoutPanel5"
        Me.tableLayoutPanel5.RowCount = 1
        Me.tableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tableLayoutPanel5.Size = New System.Drawing.Size(720, 29)
        Me.tableLayoutPanel5.TabIndex = 0
        '
        'cbxDatabit
        '
        Me.cbxDatabit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxDatabit.FormattingEnabled = True
        Me.cbxDatabit.Items.AddRange(New Object() {"8", "9"})
        Me.cbxDatabit.Location = New System.Drawing.Point(238, 3)
        Me.cbxDatabit.Name = "cbxDatabit"
        Me.cbxDatabit.Size = New System.Drawing.Size(84, 20)
        Me.cbxDatabit.TabIndex = 5
        '
        'labDatabit
        '
        Me.labDatabit.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.labDatabit.AutoSize = True
        Me.labDatabit.Location = New System.Drawing.Point(178, 8)
        Me.labDatabit.Name = "labDatabit"
        Me.labDatabit.Size = New System.Drawing.Size(42, 12)
        Me.labDatabit.TabIndex = 4
        Me.labDatabit.Text = "Databits"
        '
        'cbxBaudRate
        '
        Me.cbxBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxBaudRate.FormattingEnabled = True
        Me.cbxBaudRate.Items.AddRange(New Object() {"600", "1200", "2400", "4800", "9600", "14400", "19200", "38400", "57600", "115200"})
        Me.cbxBaudRate.Location = New System.Drawing.Point(63, 3)
        Me.cbxBaudRate.Name = "cbxBaudRate"
        Me.cbxBaudRate.Size = New System.Drawing.Size(84, 20)
        Me.cbxBaudRate.TabIndex = 3
        '
        'labBaudrate
        '
        Me.labBaudrate.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.labBaudrate.AutoSize = True
        Me.labBaudrate.Location = New System.Drawing.Point(3, 8)
        Me.labBaudrate.Name = "labBaudrate"
        Me.labBaudrate.Size = New System.Drawing.Size(54, 12)
        Me.labBaudrate.TabIndex = 2
        Me.labBaudrate.Text = "Baudrate"
        '
        'tableLayoutPanel3
        '
        Me.tableLayoutPanel3.ColumnCount = 6
        Me.tableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.tableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.tableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150.0!))
        Me.tableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 182.0!))
        Me.tableLayoutPanel3.Controls.Add(Me.cbxPort, 1, 0)
        Me.tableLayoutPanel3.Controls.Add(Me.labPort, 0, 0)
        Me.tableLayoutPanel3.Controls.Add(Me.btnApplySetting, 5, 0)
        Me.tableLayoutPanel3.Controls.Add(Me.chbxPortSettingFollowCOM1, 3, 0)
        Me.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tableLayoutPanel3.Location = New System.Drawing.Point(3, 3)
        Me.tableLayoutPanel3.Name = "tableLayoutPanel3"
        Me.tableLayoutPanel3.RowCount = 1
        Me.tableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.tableLayoutPanel3.Size = New System.Drawing.Size(720, 29)
        Me.tableLayoutPanel3.TabIndex = 0
        '
        'cbxPort
        '
        Me.cbxPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxPort.FormattingEnabled = True
        Me.cbxPort.Items.AddRange(New Object() {"COM1", "COM2", "COM3", "COM4"})
        Me.cbxPort.Location = New System.Drawing.Point(63, 3)
        Me.cbxPort.Name = "cbxPort"
        Me.cbxPort.Size = New System.Drawing.Size(84, 20)
        Me.cbxPort.TabIndex = 1
        '
        'labPort
        '
        Me.labPort.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.labPort.AutoSize = True
        Me.labPort.Location = New System.Drawing.Point(3, 11)
        Me.labPort.Name = "labPort"
        Me.labPort.Size = New System.Drawing.Size(24, 12)
        Me.labPort.TabIndex = 0
        Me.labPort.Text = "Port"
        '
        'btnApplySetting
        '
        Me.btnApplySetting.Location = New System.Drawing.Point(541, 3)
        Me.btnApplySetting.Name = "btnApplySetting"
        Me.btnApplySetting.Size = New System.Drawing.Size(169, 23)
        Me.btnApplySetting.TabIndex = 2
        Me.btnApplySetting.Text = "Apply"
        Me.btnApplySetting.UseVisualStyleBackColor = True
        '
        'chbxPortSettingFollowCOM1
        '
        Me.chbxPortSettingFollowCOM1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.chbxPortSettingFollowCOM1.AutoSize = True
        Me.chbxPortSettingFollowCOM1.Location = New System.Drawing.Point(178, 9)
        Me.chbxPortSettingFollowCOM1.Name = "chbxPortSettingFollowCOM1"
        Me.chbxPortSettingFollowCOM1.Size = New System.Drawing.Size(109, 16)
        Me.chbxPortSettingFollowCOM1.TabIndex = 3
        Me.chbxPortSettingFollowCOM1.Text = "All follow COM 1"
        Me.chbxPortSettingFollowCOM1.UseVisualStyleBackColor = True
        '
        'tableLayoutPanel6
        '
        Me.tableLayoutPanel6.ColumnCount = 9
        Me.tableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.tableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.tableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.tableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.tableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
        Me.tableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80.0!))
        Me.tableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90.0!))
        Me.tableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tableLayoutPanel6.Controls.Add(Me.labParity, 0, 0)
        Me.tableLayoutPanel6.Controls.Add(Me.cbxParity, 1, 0)
        Me.tableLayoutPanel6.Controls.Add(Me.labStopbit, 3, 0)
        Me.tableLayoutPanel6.Controls.Add(Me.cbxStopbit, 4, 0)
        Me.tableLayoutPanel6.Controls.Add(Me.labFlowCtrl, 6, 0)
        Me.tableLayoutPanel6.Controls.Add(Me.cbxFlowCtrl, 7, 0)
        Me.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tableLayoutPanel6.Location = New System.Drawing.Point(3, 73)
        Me.tableLayoutPanel6.Name = "tableLayoutPanel6"
        Me.tableLayoutPanel6.RowCount = 1
        Me.tableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tableLayoutPanel6.Size = New System.Drawing.Size(720, 29)
        Me.tableLayoutPanel6.TabIndex = 1
        '
        'cbxStopbit
        '
        Me.cbxStopbit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxStopbit.FormattingEnabled = True
        Me.cbxStopbit.Items.AddRange(New Object() {"1", "0.5", "2", "1.5"})
        Me.cbxStopbit.Location = New System.Drawing.Point(238, 3)
        Me.cbxStopbit.Name = "cbxStopbit"
        Me.cbxStopbit.Size = New System.Drawing.Size(84, 20)
        Me.cbxStopbit.TabIndex = 3
        '
        'labFlowCtrl
        '
        Me.labFlowCtrl.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.labFlowCtrl.AutoSize = True
        Me.labFlowCtrl.Location = New System.Drawing.Point(353, 8)
        Me.labFlowCtrl.Name = "labFlowCtrl"
        Me.labFlowCtrl.Size = New System.Drawing.Size(74, 12)
        Me.labFlowCtrl.TabIndex = 4
        Me.labFlowCtrl.Text = "Flow Control"
        '
        'cbxFlowCtrl
        '
        Me.cbxFlowCtrl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxFlowCtrl.FormattingEnabled = True
        Me.cbxFlowCtrl.Items.AddRange(New Object() {"NONE", "RTS", "CTS", "DTR"})
        Me.cbxFlowCtrl.Location = New System.Drawing.Point(433, 3)
        Me.cbxFlowCtrl.Name = "cbxFlowCtrl"
        Me.cbxFlowCtrl.Size = New System.Drawing.Size(84, 20)
        Me.cbxFlowCtrl.TabIndex = 5
        '
        'panelInfo_Serial
        '
        Me.panelInfo_Serial.Controls.Add(Me.listViewComPortInfo)
        Me.panelInfo_Serial.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelInfo_Serial.Location = New System.Drawing.Point(3, 161)
        Me.panelInfo_Serial.Name = "panelInfo_Serial"
        Me.panelInfo_Serial.Size = New System.Drawing.Size(723, 147)
        Me.panelInfo_Serial.TabIndex = 10
        '
        'listViewComPortInfo
        '
        Me.listViewComPortInfo.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.clmSerialItem, Me.clmBaudrate, Me.clmDatabit, Me.clmParity, Me.clmStopBit, Me.clmFlowCtrl, Me.clmMapTcpPort})
        Me.listViewComPortInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.listViewComPortInfo.FullRowSelect = True
        Me.listViewComPortInfo.Location = New System.Drawing.Point(0, 0)
        Me.listViewComPortInfo.Name = "listViewComPortInfo"
        Me.listViewComPortInfo.Size = New System.Drawing.Size(723, 147)
        Me.listViewComPortInfo.TabIndex = 9
        Me.listViewComPortInfo.UseCompatibleStateImageBehavior = False
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
        'clmDatabit
        '
        Me.clmDatabit.Text = "Databits"
        Me.clmDatabit.Width = 100
        '
        'clmParity
        '
        Me.clmParity.Text = "Parity"
        Me.clmParity.Width = 100
        '
        'clmStopBit
        '
        Me.clmStopBit.Text = "Stopbits"
        Me.clmStopBit.Width = 100
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
        'flowLayoutPanel1
        '
        Me.flowLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.flowLayoutPanel1.Controls.Add(Me.btnStart)
        Me.flowLayoutPanel1.Controls.Add(Me.Btn_Quit)
        Me.flowLayoutPanel1.Location = New System.Drawing.Point(587, 354)
        Me.flowLayoutPanel1.Name = "flowLayoutPanel1"
        Me.flowLayoutPanel1.Size = New System.Drawing.Size(162, 29)
        Me.flowLayoutPanel1.TabIndex = 2
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(3, 3)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(73, 21)
        Me.btnStart.TabIndex = 24
        Me.btnStart.Text = "Start"
        '
        'Btn_Quit
        '
        Me.Btn_Quit.Location = New System.Drawing.Point(82, 3)
        Me.Btn_Quit.Name = "Btn_Quit"
        Me.Btn_Quit.Size = New System.Drawing.Size(73, 21)
        Me.Btn_Quit.TabIndex = 25
        Me.Btn_Quit.Text = "Quit"
        '
        'Form_APAX_5090
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(752, 421)
        Me.Controls.Add(Me.tableLayoutPanel1)
        Me.Name = "Form_APAX_5090"
        Me.Text = "APAX_5090"
        Me.tableLayoutPanel1.ResumeLayout(False)
        Me.tcRemote.ResumeLayout(False)
        Me.tabModuleInfo.ResumeLayout(False)
        Me.tableLayoutPanel2.ResumeLayout(False)
        Me.tableLayoutPanel2.PerformLayout()
        Me.tabSerial.ResumeLayout(False)
        Me.flowLayoutPanel2.ResumeLayout(False)
        Me.panelHideControl_Serial.ResumeLayout(False)
        Me.panelConfig_Serial.ResumeLayout(False)
        Me.tableLayoutPanel4.ResumeLayout(False)
        Me.tableLayoutPanel5.ResumeLayout(False)
        Me.tableLayoutPanel5.PerformLayout()
        Me.tableLayoutPanel3.ResumeLayout(False)
        Me.tableLayoutPanel3.PerformLayout()
        Me.tableLayoutPanel6.ResumeLayout(False)
        Me.tableLayoutPanel6.PerformLayout()
        Me.panelInfo_Serial.ResumeLayout(False)
        Me.flowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents labParity As System.Windows.Forms.Label
    Private WithEvents cbxParity As System.Windows.Forms.ComboBox
    Private WithEvents labStopbit As System.Windows.Forms.Label
    Private WithEvents tableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents StatusBar_IO As System.Windows.Forms.StatusBar
    Private WithEvents tcRemote As System.Windows.Forms.TabControl
    Private WithEvents tabModuleInfo As System.Windows.Forms.TabPage
    Private WithEvents tableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Private WithEvents labModule As System.Windows.Forms.Label
    Private WithEvents txtModule As System.Windows.Forms.TextBox
    Private WithEvents labID As System.Windows.Forms.Label
    Private WithEvents txtID As System.Windows.Forms.TextBox
    Private WithEvents labSupportKernelFw As System.Windows.Forms.Label
    Private WithEvents txtSupportKernelFw As System.Windows.Forms.TextBox
    Private WithEvents labFwVer As System.Windows.Forms.Label
    Private WithEvents txtFwVer As System.Windows.Forms.TextBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents btnLocate As System.Windows.Forms.Button
    Private WithEvents tabSerial As System.Windows.Forms.TabPage
    Private WithEvents flowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Private WithEvents panelHideControl_Serial As System.Windows.Forms.Panel
    Private WithEvents chbxHide_Serial As System.Windows.Forms.CheckBox
    Private WithEvents panelConfig_Serial As System.Windows.Forms.Panel
    Private WithEvents tableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Private WithEvents tableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Private WithEvents cbxDatabit As System.Windows.Forms.ComboBox
    Private WithEvents labDatabit As System.Windows.Forms.Label
    Private WithEvents cbxBaudRate As System.Windows.Forms.ComboBox
    Private WithEvents labBaudrate As System.Windows.Forms.Label
    Private WithEvents tableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Private WithEvents cbxPort As System.Windows.Forms.ComboBox
    Private WithEvents labPort As System.Windows.Forms.Label
    Private WithEvents btnApplySetting As System.Windows.Forms.Button
    Private WithEvents chbxPortSettingFollowCOM1 As System.Windows.Forms.CheckBox
    Private WithEvents tableLayoutPanel6 As System.Windows.Forms.TableLayoutPanel
    Private WithEvents cbxStopbit As System.Windows.Forms.ComboBox
    Private WithEvents labFlowCtrl As System.Windows.Forms.Label
    Private WithEvents cbxFlowCtrl As System.Windows.Forms.ComboBox
    Private WithEvents panelInfo_Serial As System.Windows.Forms.Panel
    Private WithEvents listViewComPortInfo As System.Windows.Forms.ListView
    Private WithEvents clmSerialItem As System.Windows.Forms.ColumnHeader
    Private WithEvents clmBaudrate As System.Windows.Forms.ColumnHeader
    Private WithEvents clmDatabit As System.Windows.Forms.ColumnHeader
    Private WithEvents clmParity As System.Windows.Forms.ColumnHeader
    Private WithEvents clmStopBit As System.Windows.Forms.ColumnHeader
    Private WithEvents clmFlowCtrl As System.Windows.Forms.ColumnHeader
    Private WithEvents clmMapTcpPort As System.Windows.Forms.ColumnHeader
    Private WithEvents flowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents Btn_Quit As System.Windows.Forms.Button

End Class
