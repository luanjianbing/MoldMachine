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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.ckCH5 = New System.Windows.Forms.CheckBox
        Me.ckCH4 = New System.Windows.Forms.CheckBox
        Me.gbComport = New System.Windows.Forms.GroupBox
        Me.searchLabel = New System.Windows.Forms.Label
        Me.bCoordinator = New System.Windows.Forms.Button
        Me.cbComportBuadrate = New System.Windows.Forms.ComboBox
        Me.label1 = New System.Windows.Forms.Label
        Me.tbComport = New System.Windows.Forms.TextBox
        Me.bComport = New System.Windows.Forms.Button
        Me.label2 = New System.Windows.Forms.Label
        Me.ckCH3 = New System.Windows.Forms.CheckBox
        Me.ckCH2 = New System.Windows.Forms.CheckBox
        Me.gbxChEnable = New System.Windows.Forms.GroupBox
        Me.ckCH1 = New System.Windows.Forms.CheckBox
        Me.ckCH0 = New System.Windows.Forms.CheckBox
        Me.cbUpdateRate = New System.Windows.Forms.ComboBox
        Me.cbBurnOutPresent = New System.Windows.Forms.ComboBox
        Me.tpChannelStatus = New System.Windows.Forms.TabPage
        Me.bClearLvChStatus = New System.Windows.Forms.Button
        Me.bGetChStatus = New System.Windows.Forms.Button
        Me.gbxChInfo = New System.Windows.Forms.GroupBox
        Me.listViewChStatus = New System.Windows.Forms.ListView
        Me.clmType = New System.Windows.Forms.ColumnHeader
        Me.clmCh = New System.Windows.Forms.ColumnHeader
        Me.clmModbusAddr = New System.Windows.Forms.ColumnHeader
        Me.clmValue = New System.Windows.Forms.ColumnHeader
        Me.clmChStatus = New System.Windows.Forms.ColumnHeader
        Me.label16 = New System.Windows.Forms.Label
        Me.bSetRange = New System.Windows.Forms.Button
        Me.gbxSetRangeOptionalFunction = New System.Windows.Forms.GroupBox
        Me.label17 = New System.Windows.Forms.Label
        Me.label18 = New System.Windows.Forms.Label
        Me.cbBurnOutEnable = New System.Windows.Forms.ComboBox
        Me.bGetConfig = New System.Windows.Forms.Button
        Me.tpSetRange = New System.Windows.Forms.TabPage
        Me.gbxChRangeType = New System.Windows.Forms.GroupBox
        Me.cbCh0 = New System.Windows.Forms.ComboBox
        Me.cbCh5 = New System.Windows.Forms.ComboBox
        Me.label10 = New System.Windows.Forms.Label
        Me.cbCh4 = New System.Windows.Forms.ComboBox
        Me.cbCh2 = New System.Windows.Forms.ComboBox
        Me.label9 = New System.Windows.Forms.Label
        Me.label6 = New System.Windows.Forms.Label
        Me.label8 = New System.Windows.Forms.Label
        Me.cbCh3 = New System.Windows.Forms.ComboBox
        Me.label7 = New System.Windows.Forms.Label
        Me.cbCh1 = New System.Windows.Forms.ComboBox
        Me.label11 = New System.Windows.Forms.Label
        Me.clmChInfoLastUpdateTime = New System.Windows.Forms.ColumnHeader
        Me.clmChInfoLQI = New System.Windows.Forms.ColumnHeader
        Me.clmListShortAddr = New System.Windows.Forms.ColumnHeader
        Me.clmListParentAddr = New System.Windows.Forms.ColumnHeader
        Me.clmListCycleTime = New System.Windows.Forms.ColumnHeader
        Me.clmListInactiveTime = New System.Windows.Forms.ColumnHeader
        Me.clmListStatus = New System.Windows.Forms.ColumnHeader
        Me.timerSearchCoordinator = New System.Windows.Forms.Timer(Me.components)
        Me.clmListLQI = New System.Windows.Forms.ColumnHeader
        Me.clmListSlaveId = New System.Windows.Forms.ColumnHeader
        Me.clmListDeviceName = New System.Windows.Forms.ColumnHeader
        Me.tpDeviceList = New System.Windows.Forms.TabPage
        Me.bDeviceListRefresh = New System.Windows.Forms.Button
        Me.gbxDeviceList = New System.Windows.Forms.GroupBox
        Me.listViewDeviceList = New System.Windows.Forms.ListView
        Me.clmChInfoDataCycle = New System.Windows.Forms.ColumnHeader
        Me.clmChInfoMode = New System.Windows.Forms.ColumnHeader
        Me.txtChannel = New System.Windows.Forms.TextBox
        Me.txtDataCycle = New System.Windows.Forms.TextBox
        Me.clmChInfoValue = New System.Windows.Forms.ColumnHeader
        Me.txtSlaveId = New System.Windows.Forms.TextBox
        Me.txtPanId = New System.Windows.Forms.TextBox
        Me.gbxzigbee = New System.Windows.Forms.GroupBox
        Me.labSlaveId = New System.Windows.Forms.Label
        Me.txtPAddr = New System.Windows.Forms.TextBox
        Me.labPAddr = New System.Windows.Forms.Label
        Me.labDataCycle = New System.Windows.Forms.Label
        Me.txtSAddr = New System.Windows.Forms.TextBox
        Me.labSAddr = New System.Windows.Forms.Label
        Me.labChannel = New System.Windows.Forms.Label
        Me.labPanId = New System.Windows.Forms.Label
        Me.tpInformation = New System.Windows.Forms.TabPage
        Me.gbxFw = New System.Windows.Forms.GroupBox
        Me.txtFwVerZigBee = New System.Windows.Forms.TextBox
        Me.labKernal = New System.Windows.Forms.Label
        Me.labWireless = New System.Windows.Forms.Label
        Me.txtFwVerKernal = New System.Windows.Forms.TextBox
        Me.gbxDevice = New System.Windows.Forms.GroupBox
        Me.txtDeviceName = New System.Windows.Forms.TextBox
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.labDescription = New System.Windows.Forms.Label
        Me.labAdamDevice = New System.Windows.Forms.Label
        Me.tcDeviceInfo = New System.Windows.Forms.TabControl
        Me.tpDeviceStatus = New System.Windows.Forms.TabPage
        Me.gbxDeviceStatus = New System.Windows.Forms.GroupBox
        Me.txtModeStatus = New System.Windows.Forms.TextBox
        Me.txtPower = New System.Windows.Forms.TextBox
        Me.txtBattery = New System.Windows.Forms.TextBox
        Me.txtLink = New System.Windows.Forms.TextBox
        Me.labPowerDetection = New System.Windows.Forms.Label
        Me.labBatteryStatus = New System.Windows.Forms.Label
        Me.labLinkQuality = New System.Windows.Forms.Label
        Me.labModeStatus = New System.Windows.Forms.Label
        Me.tpChannelInfo = New System.Windows.Forms.TabPage
        Me.lPollingTimes = New System.Windows.Forms.Label
        Me.bPolling = New System.Windows.Forms.Button
        Me.gbxChannelInfo = New System.Windows.Forms.GroupBox
        Me.listViewChannelInfo = New System.Windows.Forms.ListView
        Me.clmChInfoType = New System.Windows.Forms.ColumnHeader
        Me.clmChInfoCh = New System.Windows.Forms.ColumnHeader
        Me.clmChInfoModbusAddr = New System.Windows.Forms.ColumnHeader
        Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.bGetEndDevice = New System.Windows.Forms.Button
        Me.gbDeviceInfo = New System.Windows.Forms.GroupBox
        Me.treeView1 = New System.Windows.Forms.TreeView
        Me.gbDeviceTreeView = New System.Windows.Forms.GroupBox
        Me.timerPollingData = New System.Windows.Forms.Timer(Me.components)
        Me.gbComport.SuspendLayout()
        Me.gbxChEnable.SuspendLayout()
        Me.tpChannelStatus.SuspendLayout()
        Me.gbxChInfo.SuspendLayout()
        Me.gbxSetRangeOptionalFunction.SuspendLayout()
        Me.tpSetRange.SuspendLayout()
        Me.gbxChRangeType.SuspendLayout()
        Me.tpDeviceList.SuspendLayout()
        Me.gbxDeviceList.SuspendLayout()
        Me.gbxzigbee.SuspendLayout()
        Me.tpInformation.SuspendLayout()
        Me.gbxFw.SuspendLayout()
        Me.gbxDevice.SuspendLayout()
        Me.tcDeviceInfo.SuspendLayout()
        Me.tpDeviceStatus.SuspendLayout()
        Me.gbxDeviceStatus.SuspendLayout()
        Me.tpChannelInfo.SuspendLayout()
        Me.gbxChannelInfo.SuspendLayout()
        Me.gbDeviceInfo.SuspendLayout()
        Me.gbDeviceTreeView.SuspendLayout()
        Me.SuspendLayout()
        '
        'ckCH5
        '
        Me.ckCH5.AutoSize = True
        Me.ckCH5.Location = New System.Drawing.Point(8, 153)
        Me.ckCH5.Name = "ckCH5"
        Me.ckCH5.Size = New System.Drawing.Size(46, 16)
        Me.ckCH5.TabIndex = 45
        Me.ckCH5.Text = "CH5"
        Me.ckCH5.UseVisualStyleBackColor = True
        '
        'ckCH4
        '
        Me.ckCH4.AutoSize = True
        Me.ckCH4.Location = New System.Drawing.Point(8, 125)
        Me.ckCH4.Name = "ckCH4"
        Me.ckCH4.Size = New System.Drawing.Size(46, 16)
        Me.ckCH4.TabIndex = 44
        Me.ckCH4.Text = "CH4"
        Me.ckCH4.UseVisualStyleBackColor = True
        '
        'gbComport
        '
        Me.gbComport.Controls.Add(Me.searchLabel)
        Me.gbComport.Controls.Add(Me.bCoordinator)
        Me.gbComport.Controls.Add(Me.cbComportBuadrate)
        Me.gbComport.Controls.Add(Me.label1)
        Me.gbComport.Controls.Add(Me.tbComport)
        Me.gbComport.Controls.Add(Me.bComport)
        Me.gbComport.Controls.Add(Me.label2)
        Me.gbComport.Location = New System.Drawing.Point(3, 4)
        Me.gbComport.Name = "gbComport"
        Me.gbComport.Size = New System.Drawing.Size(180, 159)
        Me.gbComport.TabIndex = 10
        Me.gbComport.TabStop = False
        Me.gbComport.Text = "Comport"
        '
        'searchLabel
        '
        Me.searchLabel.AutoSize = True
        Me.searchLabel.Location = New System.Drawing.Point(13, 137)
        Me.searchLabel.Name = "searchLabel"
        Me.searchLabel.Size = New System.Drawing.Size(36, 12)
        Me.searchLabel.TabIndex = 9
        Me.searchLabel.Text = "Search"
        '
        'bCoordinator
        '
        Me.bCoordinator.Location = New System.Drawing.Point(9, 103)
        Me.bCoordinator.Name = "bCoordinator"
        Me.bCoordinator.Size = New System.Drawing.Size(154, 23)
        Me.bCoordinator.TabIndex = 8
        Me.bCoordinator.Text = "Search Coordinator"
        Me.bCoordinator.UseVisualStyleBackColor = True
        '
        'cbComportBuadrate
        '
        Me.cbComportBuadrate.FormattingEnabled = True
        Me.cbComportBuadrate.Items.AddRange(New Object() {"9600", "115200"})
        Me.cbComportBuadrate.Location = New System.Drawing.Point(63, 43)
        Me.cbComportBuadrate.Name = "cbComportBuadrate"
        Me.cbComportBuadrate.Size = New System.Drawing.Size(99, 20)
        Me.cbComportBuadrate.TabIndex = 8
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(6, 18)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(43, 12)
        Me.label1.TabIndex = 2
        Me.label1.Text = "Number"
        '
        'tbComport
        '
        Me.tbComport.Location = New System.Drawing.Point(63, 15)
        Me.tbComport.Name = "tbComport"
        Me.tbComport.Size = New System.Drawing.Size(99, 22)
        Me.tbComport.TabIndex = 0
        Me.tbComport.Text = "1"
        '
        'bComport
        '
        Me.bComport.Location = New System.Drawing.Point(9, 71)
        Me.bComport.Name = "bComport"
        Me.bComport.Size = New System.Drawing.Size(153, 23)
        Me.bComport.TabIndex = 1
        Me.bComport.Text = "Open"
        Me.bComport.UseVisualStyleBackColor = True
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(6, 46)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(47, 12)
        Me.label2.TabIndex = 3
        Me.label2.Text = "Buadrate"
        '
        'ckCH3
        '
        Me.ckCH3.AutoSize = True
        Me.ckCH3.Location = New System.Drawing.Point(8, 99)
        Me.ckCH3.Name = "ckCH3"
        Me.ckCH3.Size = New System.Drawing.Size(46, 16)
        Me.ckCH3.TabIndex = 43
        Me.ckCH3.Text = "CH3"
        Me.ckCH3.UseVisualStyleBackColor = True
        '
        'ckCH2
        '
        Me.ckCH2.AutoSize = True
        Me.ckCH2.Location = New System.Drawing.Point(8, 72)
        Me.ckCH2.Name = "ckCH2"
        Me.ckCH2.Size = New System.Drawing.Size(46, 16)
        Me.ckCH2.TabIndex = 42
        Me.ckCH2.Text = "CH2"
        Me.ckCH2.UseVisualStyleBackColor = True
        '
        'gbxChEnable
        '
        Me.gbxChEnable.Controls.Add(Me.ckCH5)
        Me.gbxChEnable.Controls.Add(Me.ckCH4)
        Me.gbxChEnable.Controls.Add(Me.ckCH3)
        Me.gbxChEnable.Controls.Add(Me.ckCH2)
        Me.gbxChEnable.Controls.Add(Me.ckCH1)
        Me.gbxChEnable.Controls.Add(Me.ckCH0)
        Me.gbxChEnable.Location = New System.Drawing.Point(301, 20)
        Me.gbxChEnable.Name = "gbxChEnable"
        Me.gbxChEnable.Size = New System.Drawing.Size(99, 181)
        Me.gbxChEnable.TabIndex = 23
        Me.gbxChEnable.TabStop = False
        Me.gbxChEnable.Text = "Channel Enable"
        '
        'ckCH1
        '
        Me.ckCH1.AutoSize = True
        Me.ckCH1.Location = New System.Drawing.Point(8, 45)
        Me.ckCH1.Name = "ckCH1"
        Me.ckCH1.Size = New System.Drawing.Size(46, 16)
        Me.ckCH1.TabIndex = 41
        Me.ckCH1.Text = "CH1"
        Me.ckCH1.UseVisualStyleBackColor = True
        '
        'ckCH0
        '
        Me.ckCH0.AutoSize = True
        Me.ckCH0.Location = New System.Drawing.Point(8, 19)
        Me.ckCH0.Name = "ckCH0"
        Me.ckCH0.Size = New System.Drawing.Size(46, 16)
        Me.ckCH0.TabIndex = 40
        Me.ckCH0.Text = "CH0"
        Me.ckCH0.UseVisualStyleBackColor = True
        '
        'cbUpdateRate
        '
        Me.cbUpdateRate.FormattingEnabled = True
        Me.cbUpdateRate.Items.AddRange(New Object() {"Auto", "50 Hz", "60 Hz"})
        Me.cbUpdateRate.Location = New System.Drawing.Point(9, 36)
        Me.cbUpdateRate.Name = "cbUpdateRate"
        Me.cbUpdateRate.Size = New System.Drawing.Size(105, 20)
        Me.cbUpdateRate.TabIndex = 27
        '
        'cbBurnOutPresent
        '
        Me.cbBurnOutPresent.FormattingEnabled = True
        Me.cbBurnOutPresent.Items.AddRange(New Object() {"Down Scale", "Up Scale"})
        Me.cbBurnOutPresent.Location = New System.Drawing.Point(9, 131)
        Me.cbBurnOutPresent.Name = "cbBurnOutPresent"
        Me.cbBurnOutPresent.Size = New System.Drawing.Size(105, 20)
        Me.cbBurnOutPresent.TabIndex = 32
        '
        'tpChannelStatus
        '
        Me.tpChannelStatus.Controls.Add(Me.bClearLvChStatus)
        Me.tpChannelStatus.Controls.Add(Me.bGetChStatus)
        Me.tpChannelStatus.Controls.Add(Me.gbxChInfo)
        Me.tpChannelStatus.Location = New System.Drawing.Point(4, 23)
        Me.tpChannelStatus.Name = "tpChannelStatus"
        Me.tpChannelStatus.Padding = New System.Windows.Forms.Padding(3)
        Me.tpChannelStatus.Size = New System.Drawing.Size(582, 402)
        Me.tpChannelStatus.TabIndex = 1
        Me.tpChannelStatus.Text = "Channel Status (AI Module)"
        Me.tpChannelStatus.UseVisualStyleBackColor = True
        '
        'bClearLvChStatus
        '
        Me.bClearLvChStatus.Location = New System.Drawing.Point(465, 65)
        Me.bClearLvChStatus.Name = "bClearLvChStatus"
        Me.bClearLvChStatus.Size = New System.Drawing.Size(102, 23)
        Me.bClearLvChStatus.TabIndex = 11
        Me.bClearLvChStatus.Text = "Clear"
        Me.bClearLvChStatus.UseVisualStyleBackColor = True
        '
        'bGetChStatus
        '
        Me.bGetChStatus.Location = New System.Drawing.Point(465, 31)
        Me.bGetChStatus.Name = "bGetChStatus"
        Me.bGetChStatus.Size = New System.Drawing.Size(102, 23)
        Me.bGetChStatus.TabIndex = 10
        Me.bGetChStatus.Text = "Get Channel Status"
        Me.bGetChStatus.UseVisualStyleBackColor = True
        '
        'gbxChInfo
        '
        Me.gbxChInfo.Controls.Add(Me.listViewChStatus)
        Me.gbxChInfo.Location = New System.Drawing.Point(6, 11)
        Me.gbxChInfo.Name = "gbxChInfo"
        Me.gbxChInfo.Size = New System.Drawing.Size(455, 178)
        Me.gbxChInfo.TabIndex = 0
        Me.gbxChInfo.TabStop = False
        Me.gbxChInfo.Text = "Channel Status"
        '
        'listViewChStatus
        '
        Me.listViewChStatus.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.clmType, Me.clmCh, Me.clmModbusAddr, Me.clmValue, Me.clmChStatus})
        Me.listViewChStatus.Dock = System.Windows.Forms.DockStyle.Fill
        Me.listViewChStatus.Location = New System.Drawing.Point(3, 18)
        Me.listViewChStatus.Name = "listViewChStatus"
        Me.listViewChStatus.Size = New System.Drawing.Size(449, 157)
        Me.listViewChStatus.TabIndex = 0
        Me.listViewChStatus.UseCompatibleStateImageBehavior = False
        Me.listViewChStatus.View = System.Windows.Forms.View.Details
        '
        'clmType
        '
        Me.clmType.Text = "Type"
        Me.clmType.Width = 50
        '
        'clmCh
        '
        Me.clmCh.Text = "Ch"
        Me.clmCh.Width = 40
        '
        'clmModbusAddr
        '
        Me.clmModbusAddr.Text = "Modbus Addr"
        Me.clmModbusAddr.Width = 80
        '
        'clmValue
        '
        Me.clmValue.Text = "Value"
        Me.clmValue.Width = 70
        '
        'clmChStatus
        '
        Me.clmChStatus.Text = "Ch Status"
        Me.clmChStatus.Width = 200
        '
        'label16
        '
        Me.label16.AutoSize = True
        Me.label16.Location = New System.Drawing.Point(7, 21)
        Me.label16.Name = "label16"
        Me.label16.Size = New System.Drawing.Size(83, 12)
        Me.label16.TabIndex = 28
        Me.label16.Text = "Integration Time"
        '
        'bSetRange
        '
        Me.bSetRange.Location = New System.Drawing.Point(420, 73)
        Me.bSetRange.Name = "bSetRange"
        Me.bSetRange.Size = New System.Drawing.Size(87, 23)
        Me.bSetRange.TabIndex = 28
        Me.bSetRange.Text = "Set Config"
        Me.bSetRange.UseVisualStyleBackColor = True
        '
        'gbxSetRangeOptionalFunction
        '
        Me.gbxSetRangeOptionalFunction.Controls.Add(Me.label16)
        Me.gbxSetRangeOptionalFunction.Controls.Add(Me.cbUpdateRate)
        Me.gbxSetRangeOptionalFunction.Controls.Add(Me.cbBurnOutPresent)
        Me.gbxSetRangeOptionalFunction.Controls.Add(Me.label17)
        Me.gbxSetRangeOptionalFunction.Controls.Add(Me.label18)
        Me.gbxSetRangeOptionalFunction.Controls.Add(Me.cbBurnOutEnable)
        Me.gbxSetRangeOptionalFunction.Location = New System.Drawing.Point(170, 20)
        Me.gbxSetRangeOptionalFunction.Name = "gbxSetRangeOptionalFunction"
        Me.gbxSetRangeOptionalFunction.Size = New System.Drawing.Size(125, 181)
        Me.gbxSetRangeOptionalFunction.TabIndex = 22
        Me.gbxSetRangeOptionalFunction.TabStop = False
        Me.gbxSetRangeOptionalFunction.Text = "Optional Function"
        '
        'label17
        '
        Me.label17.AutoSize = True
        Me.label17.Location = New System.Drawing.Point(7, 69)
        Me.label17.Name = "label17"
        Me.label17.Size = New System.Drawing.Size(111, 12)
        Me.label17.TabIndex = 29
        Me.label17.Text = "Burnout Detect Enable"
        '
        'label18
        '
        Me.label18.AutoSize = True
        Me.label18.Location = New System.Drawing.Point(7, 117)
        Me.label18.Name = "label18"
        Me.label18.Size = New System.Drawing.Size(106, 12)
        Me.label18.TabIndex = 31
        Me.label18.Text = "Burnout Detect Mode"
        '
        'cbBurnOutEnable
        '
        Me.cbBurnOutEnable.FormattingEnabled = True
        Me.cbBurnOutEnable.Items.AddRange(New Object() {"Enable", "Disable"})
        Me.cbBurnOutEnable.Location = New System.Drawing.Point(9, 84)
        Me.cbBurnOutEnable.Name = "cbBurnOutEnable"
        Me.cbBurnOutEnable.Size = New System.Drawing.Size(105, 20)
        Me.cbBurnOutEnable.TabIndex = 30
        '
        'bGetConfig
        '
        Me.bGetConfig.Location = New System.Drawing.Point(420, 31)
        Me.bGetConfig.Name = "bGetConfig"
        Me.bGetConfig.Size = New System.Drawing.Size(87, 23)
        Me.bGetConfig.TabIndex = 27
        Me.bGetConfig.Text = "Get Config"
        Me.bGetConfig.UseVisualStyleBackColor = True
        '
        'tpSetRange
        '
        Me.tpSetRange.Controls.Add(Me.bGetConfig)
        Me.tpSetRange.Controls.Add(Me.bSetRange)
        Me.tpSetRange.Controls.Add(Me.gbxChEnable)
        Me.tpSetRange.Controls.Add(Me.gbxSetRangeOptionalFunction)
        Me.tpSetRange.Controls.Add(Me.gbxChRangeType)
        Me.tpSetRange.Location = New System.Drawing.Point(4, 23)
        Me.tpSetRange.Name = "tpSetRange"
        Me.tpSetRange.Size = New System.Drawing.Size(576, 402)
        Me.tpSetRange.TabIndex = 3
        Me.tpSetRange.Text = "Set Range (AI Module)"
        Me.tpSetRange.UseVisualStyleBackColor = True
        '
        'gbxChRangeType
        '
        Me.gbxChRangeType.Controls.Add(Me.cbCh0)
        Me.gbxChRangeType.Controls.Add(Me.cbCh5)
        Me.gbxChRangeType.Controls.Add(Me.label10)
        Me.gbxChRangeType.Controls.Add(Me.cbCh4)
        Me.gbxChRangeType.Controls.Add(Me.cbCh2)
        Me.gbxChRangeType.Controls.Add(Me.label9)
        Me.gbxChRangeType.Controls.Add(Me.label6)
        Me.gbxChRangeType.Controls.Add(Me.label8)
        Me.gbxChRangeType.Controls.Add(Me.cbCh3)
        Me.gbxChRangeType.Controls.Add(Me.label7)
        Me.gbxChRangeType.Controls.Add(Me.cbCh1)
        Me.gbxChRangeType.Controls.Add(Me.label11)
        Me.gbxChRangeType.Location = New System.Drawing.Point(14, 20)
        Me.gbxChRangeType.Name = "gbxChRangeType"
        Me.gbxChRangeType.Size = New System.Drawing.Size(150, 181)
        Me.gbxChRangeType.TabIndex = 21
        Me.gbxChRangeType.TabStop = False
        Me.gbxChRangeType.Text = "Range Type"
        '
        'cbCh0
        '
        Me.cbCh0.FormattingEnabled = True
        Me.cbCh0.Items.AddRange(New Object() {"-150mV ~  150mV", "-500mV ~  500mV", " -1V ~ 1V", "-5V ~ 5V", "-10 ~  10V", "-20mA ~ 20mA", "0~20mA", "4~20mA"})
        Me.cbCh0.Location = New System.Drawing.Point(43, 21)
        Me.cbCh0.Name = "cbCh0"
        Me.cbCh0.Size = New System.Drawing.Size(101, 20)
        Me.cbCh0.TabIndex = 13
        '
        'cbCh5
        '
        Me.cbCh5.FormattingEnabled = True
        Me.cbCh5.Items.AddRange(New Object() {"-150mV ~  150mV", "-500mV ~  500mV", " -1V ~ 1V", "-5V ~ 5V", "-10 ~  10V", "-20mA ~ 20mA", "0~20mA", "4~20mA"})
        Me.cbCh5.Location = New System.Drawing.Point(43, 151)
        Me.cbCh5.Name = "cbCh5"
        Me.cbCh5.Size = New System.Drawing.Size(101, 20)
        Me.cbCh5.TabIndex = 18
        '
        'label10
        '
        Me.label10.AutoSize = True
        Me.label10.Location = New System.Drawing.Point(12, 131)
        Me.label10.Name = "label10"
        Me.label10.Size = New System.Drawing.Size(25, 12)
        Me.label10.TabIndex = 23
        Me.label10.Text = "Ch4"
        '
        'cbCh4
        '
        Me.cbCh4.FormattingEnabled = True
        Me.cbCh4.Items.AddRange(New Object() {"-150mV ~  150mV", "-500mV ~  500mV", " -1V ~ 1V", "-5V ~ 5V", "-10 ~  10V", "-20mA ~ 20mA", "0~20mA", "4~20mA"})
        Me.cbCh4.Location = New System.Drawing.Point(43, 125)
        Me.cbCh4.Name = "cbCh4"
        Me.cbCh4.Size = New System.Drawing.Size(101, 20)
        Me.cbCh4.TabIndex = 17
        '
        'cbCh2
        '
        Me.cbCh2.FormattingEnabled = True
        Me.cbCh2.Items.AddRange(New Object() {"-150mV ~  150mV", "-500mV ~  500mV", " -1V ~ 1V", "-5V ~ 5V", "-10 ~  10V", "-20mA ~ 20mA", "0~20mA", "4~20mA"})
        Me.cbCh2.Location = New System.Drawing.Point(43, 73)
        Me.cbCh2.Name = "cbCh2"
        Me.cbCh2.Size = New System.Drawing.Size(101, 20)
        Me.cbCh2.TabIndex = 15
        '
        'label9
        '
        Me.label9.AutoSize = True
        Me.label9.Location = New System.Drawing.Point(12, 105)
        Me.label9.Name = "label9"
        Me.label9.Size = New System.Drawing.Size(25, 12)
        Me.label9.TabIndex = 22
        Me.label9.Text = "Ch3"
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(12, 27)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(25, 12)
        Me.label6.TabIndex = 19
        Me.label6.Text = "Ch0"
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Location = New System.Drawing.Point(12, 79)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(25, 12)
        Me.label8.TabIndex = 21
        Me.label8.Text = "Ch2"
        '
        'cbCh3
        '
        Me.cbCh3.FormattingEnabled = True
        Me.cbCh3.Items.AddRange(New Object() {"-150mV ~  150mV", "-500mV ~  500mV", " -1V ~ 1V", "-5V ~ 5V", "-10 ~  10V", "-20mA ~ 20mA", "0~20mA", "4~20mA"})
        Me.cbCh3.Location = New System.Drawing.Point(43, 99)
        Me.cbCh3.Name = "cbCh3"
        Me.cbCh3.Size = New System.Drawing.Size(101, 20)
        Me.cbCh3.TabIndex = 16
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(12, 53)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(25, 12)
        Me.label7.TabIndex = 20
        Me.label7.Text = "Ch1"
        '
        'cbCh1
        '
        Me.cbCh1.FormattingEnabled = True
        Me.cbCh1.Items.AddRange(New Object() {"-150mV ~  150mV", "-500mV ~  500mV", " -1V ~ 1V", "-5V ~ 5V", "-10 ~  10V", "-20mA ~ 20mA", "0~20mA", "4~20mA"})
        Me.cbCh1.Location = New System.Drawing.Point(43, 47)
        Me.cbCh1.Name = "cbCh1"
        Me.cbCh1.Size = New System.Drawing.Size(101, 20)
        Me.cbCh1.TabIndex = 14
        '
        'label11
        '
        Me.label11.AutoSize = True
        Me.label11.Location = New System.Drawing.Point(12, 157)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(25, 12)
        Me.label11.TabIndex = 24
        Me.label11.Text = "Ch5"
        '
        'clmChInfoLastUpdateTime
        '
        Me.clmChInfoLastUpdateTime.Text = "Last Update Time"
        Me.clmChInfoLastUpdateTime.Width = 137
        '
        'clmChInfoLQI
        '
        Me.clmChInfoLQI.Text = "LQI"
        Me.clmChInfoLQI.Width = 45
        '
        'clmListShortAddr
        '
        Me.clmListShortAddr.Text = "Short Addr"
        Me.clmListShortAddr.Width = 70
        '
        'clmListParentAddr
        '
        Me.clmListParentAddr.Text = "Parent Addr"
        Me.clmListParentAddr.Width = 70
        '
        'clmListCycleTime
        '
        Me.clmListCycleTime.Text = "CycleTime"
        Me.clmListCycleTime.Width = 68
        '
        'clmListInactiveTime
        '
        Me.clmListInactiveTime.Text = "InactiveTime"
        Me.clmListInactiveTime.Width = 73
        '
        'clmListStatus
        '
        Me.clmListStatus.Text = "Status"
        Me.clmListStatus.Width = 88
        '
        'timerSearchCoordinator
        '
        '
        'clmListLQI
        '
        Me.clmListLQI.Text = "LQI"
        Me.clmListLQI.Width = 50
        '
        'clmListSlaveId
        '
        Me.clmListSlaveId.Text = "Slave ID"
        Me.clmListSlaveId.Width = 63
        '
        'clmListDeviceName
        '
        Me.clmListDeviceName.Text = "Name"
        Me.clmListDeviceName.Width = 75
        '
        'tpDeviceList
        '
        Me.tpDeviceList.Controls.Add(Me.bDeviceListRefresh)
        Me.tpDeviceList.Controls.Add(Me.gbxDeviceList)
        Me.tpDeviceList.Location = New System.Drawing.Point(4, 23)
        Me.tpDeviceList.Name = "tpDeviceList"
        Me.tpDeviceList.Size = New System.Drawing.Size(576, 402)
        Me.tpDeviceList.TabIndex = 5
        Me.tpDeviceList.Text = "Device List"
        Me.tpDeviceList.UseVisualStyleBackColor = True
        '
        'bDeviceListRefresh
        '
        Me.bDeviceListRefresh.Location = New System.Drawing.Point(11, 11)
        Me.bDeviceListRefresh.Name = "bDeviceListRefresh"
        Me.bDeviceListRefresh.Size = New System.Drawing.Size(75, 23)
        Me.bDeviceListRefresh.TabIndex = 1
        Me.bDeviceListRefresh.Text = "Refresh"
        Me.bDeviceListRefresh.UseVisualStyleBackColor = True
        '
        'gbxDeviceList
        '
        Me.gbxDeviceList.Controls.Add(Me.listViewDeviceList)
        Me.gbxDeviceList.Location = New System.Drawing.Point(6, 43)
        Me.gbxDeviceList.Name = "gbxDeviceList"
        Me.gbxDeviceList.Size = New System.Drawing.Size(569, 352)
        Me.gbxDeviceList.TabIndex = 0
        Me.gbxDeviceList.TabStop = False
        Me.gbxDeviceList.Text = "End Device (Router)"
        '
        'listViewDeviceList
        '
        Me.listViewDeviceList.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.clmListDeviceName, Me.clmListSlaveId, Me.clmListLQI, Me.clmListInactiveTime, Me.clmListCycleTime, Me.clmListShortAddr, Me.clmListParentAddr, Me.clmListStatus})
        Me.listViewDeviceList.Dock = System.Windows.Forms.DockStyle.Fill
        Me.listViewDeviceList.Location = New System.Drawing.Point(3, 18)
        Me.listViewDeviceList.Name = "listViewDeviceList"
        Me.listViewDeviceList.Size = New System.Drawing.Size(563, 331)
        Me.listViewDeviceList.TabIndex = 0
        Me.listViewDeviceList.UseCompatibleStateImageBehavior = False
        Me.listViewDeviceList.View = System.Windows.Forms.View.Details
        '
        'clmChInfoDataCycle
        '
        Me.clmChInfoDataCycle.Text = "Data Cycle"
        Me.clmChInfoDataCycle.Width = 65
        '
        'clmChInfoMode
        '
        Me.clmChInfoMode.Text = "Mode"
        Me.clmChInfoMode.Width = 80
        '
        'txtChannel
        '
        Me.txtChannel.Location = New System.Drawing.Point(382, 16)
        Me.txtChannel.Name = "txtChannel"
        Me.txtChannel.ReadOnly = True
        Me.txtChannel.Size = New System.Drawing.Size(70, 22)
        Me.txtChannel.TabIndex = 100
        '
        'txtDataCycle
        '
        Me.txtDataCycle.Location = New System.Drawing.Point(381, 107)
        Me.txtDataCycle.Name = "txtDataCycle"
        Me.txtDataCycle.ReadOnly = True
        Me.txtDataCycle.Size = New System.Drawing.Size(71, 22)
        Me.txtDataCycle.TabIndex = 99
        '
        'clmChInfoValue
        '
        Me.clmChInfoValue.Text = "Value"
        '
        'txtSlaveId
        '
        Me.txtSlaveId.Location = New System.Drawing.Point(127, 44)
        Me.txtSlaveId.Name = "txtSlaveId"
        Me.txtSlaveId.ReadOnly = True
        Me.txtSlaveId.Size = New System.Drawing.Size(70, 22)
        Me.txtSlaveId.TabIndex = 97
        '
        'txtPanId
        '
        Me.txtPanId.Location = New System.Drawing.Point(127, 15)
        Me.txtPanId.Name = "txtPanId"
        Me.txtPanId.ReadOnly = True
        Me.txtPanId.Size = New System.Drawing.Size(70, 22)
        Me.txtPanId.TabIndex = 96
        '
        'gbxzigbee
        '
        Me.gbxzigbee.BackColor = System.Drawing.Color.Transparent
        Me.gbxzigbee.Controls.Add(Me.txtChannel)
        Me.gbxzigbee.Controls.Add(Me.txtDataCycle)
        Me.gbxzigbee.Controls.Add(Me.txtSlaveId)
        Me.gbxzigbee.Controls.Add(Me.txtPanId)
        Me.gbxzigbee.Controls.Add(Me.labSlaveId)
        Me.gbxzigbee.Controls.Add(Me.txtPAddr)
        Me.gbxzigbee.Controls.Add(Me.labPAddr)
        Me.gbxzigbee.Controls.Add(Me.labDataCycle)
        Me.gbxzigbee.Controls.Add(Me.txtSAddr)
        Me.gbxzigbee.Controls.Add(Me.labSAddr)
        Me.gbxzigbee.Controls.Add(Me.labChannel)
        Me.gbxzigbee.Controls.Add(Me.labPanId)
        Me.gbxzigbee.Location = New System.Drawing.Point(6, 179)
        Me.gbxzigbee.Name = "gbxzigbee"
        Me.gbxzigbee.Size = New System.Drawing.Size(560, 169)
        Me.gbxzigbee.TabIndex = 27
        Me.gbxzigbee.TabStop = False
        Me.gbxzigbee.Text = "Zigbee Information (for Normal mode setting)"
        '
        'labSlaveId
        '
        Me.labSlaveId.AutoSize = True
        Me.labSlaveId.Location = New System.Drawing.Point(7, 47)
        Me.labSlaveId.Name = "labSlaveId"
        Me.labSlaveId.Size = New System.Drawing.Size(104, 12)
        Me.labSlaveId.TabIndex = 94
        Me.labSlaveId.Text = "Slave ID (245 ~ 248)"
        '
        'txtPAddr
        '
        Me.txtPAddr.Location = New System.Drawing.Point(127, 72)
        Me.txtPAddr.Name = "txtPAddr"
        Me.txtPAddr.ReadOnly = True
        Me.txtPAddr.Size = New System.Drawing.Size(70, 22)
        Me.txtPAddr.TabIndex = 93
        '
        'labPAddr
        '
        Me.labPAddr.AutoSize = True
        Me.labPAddr.Location = New System.Drawing.Point(7, 75)
        Me.labPAddr.Name = "labPAddr"
        Me.labPAddr.Size = New System.Drawing.Size(108, 12)
        Me.labPAddr.TabIndex = 92
        Me.labPAddr.Text = "Parent Address (HEX)"
        '
        'labDataCycle
        '
        Me.labDataCycle.AutoSize = True
        Me.labDataCycle.Location = New System.Drawing.Point(7, 110)
        Me.labDataCycle.Name = "labDataCycle"
        Me.labDataCycle.Size = New System.Drawing.Size(368, 12)
        Me.labDataCycle.TabIndex = 85
        Me.labDataCycle.Text = "Data Cycle (1 ~ 86400s sec) (Note:This value only valid under Normal Mode)"
        '
        'txtSAddr
        '
        Me.txtSAddr.Location = New System.Drawing.Point(382, 72)
        Me.txtSAddr.Name = "txtSAddr"
        Me.txtSAddr.ReadOnly = True
        Me.txtSAddr.Size = New System.Drawing.Size(70, 22)
        Me.txtSAddr.TabIndex = 79
        '
        'labSAddr
        '
        Me.labSAddr.AutoSize = True
        Me.labSAddr.Location = New System.Drawing.Point(221, 75)
        Me.labSAddr.Name = "labSAddr"
        Me.labSAddr.Size = New System.Drawing.Size(104, 12)
        Me.labSAddr.TabIndex = 76
        Me.labSAddr.Text = "Short Address (HEX)"
        '
        'labChannel
        '
        Me.labChannel.AutoSize = True
        Me.labChannel.Location = New System.Drawing.Point(221, 19)
        Me.labChannel.Name = "labChannel"
        Me.labChannel.Size = New System.Drawing.Size(108, 12)
        Me.labChannel.TabIndex = 62
        Me.labChannel.Text = "RF Channel (11 ~ 26)"
        '
        'labPanId
        '
        Me.labPanId.AutoSize = True
        Me.labPanId.Location = New System.Drawing.Point(7, 19)
        Me.labPanId.Name = "labPanId"
        Me.labPanId.Size = New System.Drawing.Size(101, 12)
        Me.labPanId.TabIndex = 60
        Me.labPanId.Text = "PAN ID (1 ~ 16300)"
        '
        'tpInformation
        '
        Me.tpInformation.BackColor = System.Drawing.Color.Transparent
        Me.tpInformation.Controls.Add(Me.gbxzigbee)
        Me.tpInformation.Controls.Add(Me.gbxFw)
        Me.tpInformation.Controls.Add(Me.gbxDevice)
        Me.tpInformation.Location = New System.Drawing.Point(4, 23)
        Me.tpInformation.Name = "tpInformation"
        Me.tpInformation.Padding = New System.Windows.Forms.Padding(3)
        Me.tpInformation.Size = New System.Drawing.Size(576, 402)
        Me.tpInformation.TabIndex = 0
        Me.tpInformation.Text = "Information"
        Me.tpInformation.UseVisualStyleBackColor = True
        '
        'gbxFw
        '
        Me.gbxFw.Controls.Add(Me.txtFwVerZigBee)
        Me.gbxFw.Controls.Add(Me.labKernal)
        Me.gbxFw.Controls.Add(Me.labWireless)
        Me.gbxFw.Controls.Add(Me.txtFwVerKernal)
        Me.gbxFw.Location = New System.Drawing.Point(6, 97)
        Me.gbxFw.Name = "gbxFw"
        Me.gbxFw.Size = New System.Drawing.Size(560, 76)
        Me.gbxFw.TabIndex = 26
        Me.gbxFw.TabStop = False
        Me.gbxFw.Text = "Firmware Version"
        '
        'txtFwVerZigBee
        '
        Me.txtFwVerZigBee.Location = New System.Drawing.Point(95, 46)
        Me.txtFwVerZigBee.Name = "txtFwVerZigBee"
        Me.txtFwVerZigBee.ReadOnly = True
        Me.txtFwVerZigBee.Size = New System.Drawing.Size(459, 22)
        Me.txtFwVerZigBee.TabIndex = 3
        '
        'labKernal
        '
        Me.labKernal.AutoSize = True
        Me.labKernal.Location = New System.Drawing.Point(6, 20)
        Me.labKernal.Name = "labKernal"
        Me.labKernal.Size = New System.Drawing.Size(36, 12)
        Me.labKernal.TabIndex = 0
        Me.labKernal.Text = "Kernel"
        '
        'labWireless
        '
        Me.labWireless.AutoSize = True
        Me.labWireless.Location = New System.Drawing.Point(6, 49)
        Me.labWireless.Name = "labWireless"
        Me.labWireless.Size = New System.Drawing.Size(83, 12)
        Me.labWireless.TabIndex = 0
        Me.labWireless.Text = "Wireless Module"
        '
        'txtFwVerKernal
        '
        Me.txtFwVerKernal.Location = New System.Drawing.Point(95, 17)
        Me.txtFwVerKernal.Name = "txtFwVerKernal"
        Me.txtFwVerKernal.ReadOnly = True
        Me.txtFwVerKernal.Size = New System.Drawing.Size(459, 22)
        Me.txtFwVerKernal.TabIndex = 1
        '
        'gbxDevice
        '
        Me.gbxDevice.Controls.Add(Me.txtDeviceName)
        Me.gbxDevice.Controls.Add(Me.txtDescription)
        Me.gbxDevice.Controls.Add(Me.labDescription)
        Me.gbxDevice.Controls.Add(Me.labAdamDevice)
        Me.gbxDevice.Location = New System.Drawing.Point(6, 12)
        Me.gbxDevice.Name = "gbxDevice"
        Me.gbxDevice.Size = New System.Drawing.Size(560, 74)
        Me.gbxDevice.TabIndex = 25
        Me.gbxDevice.TabStop = False
        Me.gbxDevice.Text = "Device"
        '
        'txtDeviceName
        '
        Me.txtDeviceName.Location = New System.Drawing.Point(95, 16)
        Me.txtDeviceName.Name = "txtDeviceName"
        Me.txtDeviceName.ReadOnly = True
        Me.txtDeviceName.Size = New System.Drawing.Size(459, 22)
        Me.txtDeviceName.TabIndex = 87
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(95, 44)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.ReadOnly = True
        Me.txtDescription.Size = New System.Drawing.Size(459, 22)
        Me.txtDescription.TabIndex = 85
        '
        'labDescription
        '
        Me.labDescription.AutoSize = True
        Me.labDescription.Location = New System.Drawing.Point(6, 47)
        Me.labDescription.Name = "labDescription"
        Me.labDescription.Size = New System.Drawing.Size(58, 12)
        Me.labDescription.TabIndex = 4
        Me.labDescription.Text = "Description"
        '
        'labAdamDevice
        '
        Me.labAdamDevice.AutoSize = True
        Me.labAdamDevice.Location = New System.Drawing.Point(6, 19)
        Me.labAdamDevice.Name = "labAdamDevice"
        Me.labAdamDevice.Size = New System.Drawing.Size(32, 12)
        Me.labAdamDevice.TabIndex = 4
        Me.labAdamDevice.Text = "Name"
        '
        'tcDeviceInfo
        '
        Me.tcDeviceInfo.Controls.Add(Me.tpInformation)
        Me.tcDeviceInfo.Controls.Add(Me.tpDeviceStatus)
        Me.tcDeviceInfo.Controls.Add(Me.tpChannelInfo)
        Me.tcDeviceInfo.Controls.Add(Me.tpChannelStatus)
        Me.tcDeviceInfo.Controls.Add(Me.tpSetRange)
        Me.tcDeviceInfo.Controls.Add(Me.tpDeviceList)
        Me.tcDeviceInfo.ImageList = Me.imageList1
        Me.tcDeviceInfo.Location = New System.Drawing.Point(6, 18)
        Me.tcDeviceInfo.Name = "tcDeviceInfo"
        Me.tcDeviceInfo.SelectedIndex = 0
        Me.tcDeviceInfo.Size = New System.Drawing.Size(590, 429)
        Me.tcDeviceInfo.TabIndex = 0
        '
        'tpDeviceStatus
        '
        Me.tpDeviceStatus.Controls.Add(Me.gbxDeviceStatus)
        Me.tpDeviceStatus.Location = New System.Drawing.Point(4, 23)
        Me.tpDeviceStatus.Name = "tpDeviceStatus"
        Me.tpDeviceStatus.Size = New System.Drawing.Size(576, 402)
        Me.tpDeviceStatus.TabIndex = 2
        Me.tpDeviceStatus.Text = "Device Status"
        Me.tpDeviceStatus.UseVisualStyleBackColor = True
        '
        'gbxDeviceStatus
        '
        Me.gbxDeviceStatus.Controls.Add(Me.txtModeStatus)
        Me.gbxDeviceStatus.Controls.Add(Me.txtPower)
        Me.gbxDeviceStatus.Controls.Add(Me.txtBattery)
        Me.gbxDeviceStatus.Controls.Add(Me.txtLink)
        Me.gbxDeviceStatus.Controls.Add(Me.labPowerDetection)
        Me.gbxDeviceStatus.Controls.Add(Me.labBatteryStatus)
        Me.gbxDeviceStatus.Controls.Add(Me.labLinkQuality)
        Me.gbxDeviceStatus.Controls.Add(Me.labModeStatus)
        Me.gbxDeviceStatus.Location = New System.Drawing.Point(11, 14)
        Me.gbxDeviceStatus.Name = "gbxDeviceStatus"
        Me.gbxDeviceStatus.Size = New System.Drawing.Size(358, 134)
        Me.gbxDeviceStatus.TabIndex = 1
        Me.gbxDeviceStatus.TabStop = False
        Me.gbxDeviceStatus.Text = "Data"
        '
        'txtModeStatus
        '
        Me.txtModeStatus.Location = New System.Drawing.Point(113, 17)
        Me.txtModeStatus.Name = "txtModeStatus"
        Me.txtModeStatus.ReadOnly = True
        Me.txtModeStatus.Size = New System.Drawing.Size(184, 22)
        Me.txtModeStatus.TabIndex = 8
        '
        'txtPower
        '
        Me.txtPower.Location = New System.Drawing.Point(113, 101)
        Me.txtPower.Name = "txtPower"
        Me.txtPower.ReadOnly = True
        Me.txtPower.Size = New System.Drawing.Size(184, 22)
        Me.txtPower.TabIndex = 7
        '
        'txtBattery
        '
        Me.txtBattery.Location = New System.Drawing.Point(113, 73)
        Me.txtBattery.Name = "txtBattery"
        Me.txtBattery.ReadOnly = True
        Me.txtBattery.Size = New System.Drawing.Size(184, 22)
        Me.txtBattery.TabIndex = 6
        '
        'txtLink
        '
        Me.txtLink.Location = New System.Drawing.Point(113, 45)
        Me.txtLink.Name = "txtLink"
        Me.txtLink.ReadOnly = True
        Me.txtLink.Size = New System.Drawing.Size(184, 22)
        Me.txtLink.TabIndex = 5
        '
        'labPowerDetection
        '
        Me.labPowerDetection.AutoSize = True
        Me.labPowerDetection.Location = New System.Drawing.Point(7, 104)
        Me.labPowerDetection.Name = "labPowerDetection"
        Me.labPowerDetection.Size = New System.Drawing.Size(76, 12)
        Me.labPowerDetection.TabIndex = 3
        Me.labPowerDetection.Text = "External power"
        '
        'labBatteryStatus
        '
        Me.labBatteryStatus.AutoSize = True
        Me.labBatteryStatus.Location = New System.Drawing.Point(7, 76)
        Me.labBatteryStatus.Name = "labBatteryStatus"
        Me.labBatteryStatus.Size = New System.Drawing.Size(69, 12)
        Me.labBatteryStatus.TabIndex = 2
        Me.labBatteryStatus.Text = "Battery Status"
        '
        'labLinkQuality
        '
        Me.labLinkQuality.AutoSize = True
        Me.labLinkQuality.Location = New System.Drawing.Point(6, 48)
        Me.labLinkQuality.Name = "labLinkQuality"
        Me.labLinkQuality.Size = New System.Drawing.Size(64, 12)
        Me.labLinkQuality.TabIndex = 1
        Me.labLinkQuality.Text = "Link Quality"
        '
        'labModeStatus
        '
        Me.labModeStatus.AutoSize = True
        Me.labModeStatus.Location = New System.Drawing.Point(6, 20)
        Me.labModeStatus.Name = "labModeStatus"
        Me.labModeStatus.Size = New System.Drawing.Size(62, 12)
        Me.labModeStatus.TabIndex = 0
        Me.labModeStatus.Text = "Mode Status"
        '
        'tpChannelInfo
        '
        Me.tpChannelInfo.Controls.Add(Me.lPollingTimes)
        Me.tpChannelInfo.Controls.Add(Me.bPolling)
        Me.tpChannelInfo.Controls.Add(Me.gbxChannelInfo)
        Me.tpChannelInfo.Location = New System.Drawing.Point(4, 23)
        Me.tpChannelInfo.Name = "tpChannelInfo"
        Me.tpChannelInfo.Size = New System.Drawing.Size(576, 402)
        Me.tpChannelInfo.TabIndex = 4
        Me.tpChannelInfo.Text = "Channel Information"
        Me.tpChannelInfo.UseVisualStyleBackColor = True
        '
        'lPollingTimes
        '
        Me.lPollingTimes.AutoSize = True
        Me.lPollingTimes.Location = New System.Drawing.Point(158, 16)
        Me.lPollingTimes.Name = "lPollingTimes"
        Me.lPollingTimes.Size = New System.Drawing.Size(78, 12)
        Me.lPollingTimes.TabIndex = 15
        Me.lPollingTimes.Text = "Polling Times : "
        '
        'bPolling
        '
        Me.bPolling.Location = New System.Drawing.Point(9, 11)
        Me.bPolling.Name = "bPolling"
        Me.bPolling.Size = New System.Drawing.Size(93, 23)
        Me.bPolling.TabIndex = 14
        Me.bPolling.Text = "Polling"
        Me.bPolling.UseVisualStyleBackColor = True
        '
        'gbxChannelInfo
        '
        Me.gbxChannelInfo.Controls.Add(Me.listViewChannelInfo)
        Me.gbxChannelInfo.Location = New System.Drawing.Point(6, 47)
        Me.gbxChannelInfo.Name = "gbxChannelInfo"
        Me.gbxChannelInfo.Size = New System.Drawing.Size(574, 222)
        Me.gbxChannelInfo.TabIndex = 0
        Me.gbxChannelInfo.TabStop = False
        Me.gbxChannelInfo.Text = "Channel Information"
        '
        'listViewChannelInfo
        '
        Me.listViewChannelInfo.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.clmChInfoType, Me.clmChInfoCh, Me.clmChInfoModbusAddr, Me.clmChInfoValue, Me.clmChInfoMode, Me.clmChInfoDataCycle, Me.clmChInfoLQI, Me.clmChInfoLastUpdateTime})
        Me.listViewChannelInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.listViewChannelInfo.Location = New System.Drawing.Point(3, 18)
        Me.listViewChannelInfo.Name = "listViewChannelInfo"
        Me.listViewChannelInfo.Size = New System.Drawing.Size(568, 201)
        Me.listViewChannelInfo.TabIndex = 0
        Me.listViewChannelInfo.UseCompatibleStateImageBehavior = False
        Me.listViewChannelInfo.View = System.Windows.Forms.View.Details
        '
        'clmChInfoType
        '
        Me.clmChInfoType.Text = "Type"
        '
        'clmChInfoCh
        '
        Me.clmChInfoCh.Text = "Ch"
        Me.clmChInfoCh.Width = 35
        '
        'clmChInfoModbusAddr
        '
        Me.clmChInfoModbusAddr.Text = "Modbus Addr"
        Me.clmChInfoModbusAddr.Width = 80
        '
        'imageList1
        '
        Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.imageList1.Images.SetKeyName(0, "Adam2000.ico")
        Me.imageList1.Images.SetKeyName(1, "LIGHTON.ICO")
        Me.imageList1.Images.SetKeyName(2, "LIGHTOFF.ICO")
        '
        'bGetEndDevice
        '
        Me.bGetEndDevice.Location = New System.Drawing.Point(9, 261)
        Me.bGetEndDevice.Name = "bGetEndDevice"
        Me.bGetEndDevice.Size = New System.Drawing.Size(153, 23)
        Me.bGetEndDevice.TabIndex = 1
        Me.bGetEndDevice.Text = "Get End Device"
        Me.bGetEndDevice.UseVisualStyleBackColor = True
        '
        'gbDeviceInfo
        '
        Me.gbDeviceInfo.Controls.Add(Me.tcDeviceInfo)
        Me.gbDeviceInfo.Location = New System.Drawing.Point(187, 4)
        Me.gbDeviceInfo.Name = "gbDeviceInfo"
        Me.gbDeviceInfo.Size = New System.Drawing.Size(602, 454)
        Me.gbDeviceInfo.TabIndex = 12
        Me.gbDeviceInfo.TabStop = False
        Me.gbDeviceInfo.Text = "Device Info"
        '
        'treeView1
        '
        Me.treeView1.ImageIndex = 0
        Me.treeView1.ImageList = Me.imageList1
        Me.treeView1.Location = New System.Drawing.Point(3, 18)
        Me.treeView1.Name = "treeView1"
        Me.treeView1.SelectedImageIndex = 0
        Me.treeView1.Size = New System.Drawing.Size(175, 239)
        Me.treeView1.TabIndex = 0
        '
        'gbDeviceTreeView
        '
        Me.gbDeviceTreeView.Controls.Add(Me.bGetEndDevice)
        Me.gbDeviceTreeView.Controls.Add(Me.treeView1)
        Me.gbDeviceTreeView.Location = New System.Drawing.Point(3, 169)
        Me.gbDeviceTreeView.Name = "gbDeviceTreeView"
        Me.gbDeviceTreeView.Size = New System.Drawing.Size(182, 290)
        Me.gbDeviceTreeView.TabIndex = 11
        Me.gbDeviceTreeView.TabStop = False
        Me.gbDeviceTreeView.Text = "Device Tree View"
        '
        'timerPollingData
        '
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 462)
        Me.Controls.Add(Me.gbComport)
        Me.Controls.Add(Me.gbDeviceInfo)
        Me.Controls.Add(Me.gbDeviceTreeView)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Text = "ADAM2000-Sample"
        Me.gbComport.ResumeLayout(False)
        Me.gbComport.PerformLayout()
        Me.gbxChEnable.ResumeLayout(False)
        Me.gbxChEnable.PerformLayout()
        Me.tpChannelStatus.ResumeLayout(False)
        Me.gbxChInfo.ResumeLayout(False)
        Me.gbxSetRangeOptionalFunction.ResumeLayout(False)
        Me.gbxSetRangeOptionalFunction.PerformLayout()
        Me.tpSetRange.ResumeLayout(False)
        Me.gbxChRangeType.ResumeLayout(False)
        Me.gbxChRangeType.PerformLayout()
        Me.tpDeviceList.ResumeLayout(False)
        Me.gbxDeviceList.ResumeLayout(False)
        Me.gbxzigbee.ResumeLayout(False)
        Me.gbxzigbee.PerformLayout()
        Me.tpInformation.ResumeLayout(False)
        Me.gbxFw.ResumeLayout(False)
        Me.gbxFw.PerformLayout()
        Me.gbxDevice.ResumeLayout(False)
        Me.gbxDevice.PerformLayout()
        Me.tcDeviceInfo.ResumeLayout(False)
        Me.tpDeviceStatus.ResumeLayout(False)
        Me.gbxDeviceStatus.ResumeLayout(False)
        Me.gbxDeviceStatus.PerformLayout()
        Me.tpChannelInfo.ResumeLayout(False)
        Me.tpChannelInfo.PerformLayout()
        Me.gbxChannelInfo.ResumeLayout(False)
        Me.gbDeviceInfo.ResumeLayout(False)
        Me.gbDeviceTreeView.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents ckCH5 As System.Windows.Forms.CheckBox
    Private WithEvents ckCH4 As System.Windows.Forms.CheckBox
    Private WithEvents gbComport As System.Windows.Forms.GroupBox
    Private WithEvents searchLabel As System.Windows.Forms.Label
    Private WithEvents bCoordinator As System.Windows.Forms.Button
    Private WithEvents cbComportBuadrate As System.Windows.Forms.ComboBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents tbComport As System.Windows.Forms.TextBox
    Private WithEvents bComport As System.Windows.Forms.Button
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents ckCH3 As System.Windows.Forms.CheckBox
    Private WithEvents ckCH2 As System.Windows.Forms.CheckBox
    Private WithEvents gbxChEnable As System.Windows.Forms.GroupBox
    Private WithEvents ckCH1 As System.Windows.Forms.CheckBox
    Private WithEvents ckCH0 As System.Windows.Forms.CheckBox
    Private WithEvents cbUpdateRate As System.Windows.Forms.ComboBox
    Private WithEvents cbBurnOutPresent As System.Windows.Forms.ComboBox
    Private WithEvents tpChannelStatus As System.Windows.Forms.TabPage
    Private WithEvents bClearLvChStatus As System.Windows.Forms.Button
    Private WithEvents bGetChStatus As System.Windows.Forms.Button
    Private WithEvents gbxChInfo As System.Windows.Forms.GroupBox
    Private WithEvents listViewChStatus As System.Windows.Forms.ListView
    Private WithEvents clmType As System.Windows.Forms.ColumnHeader
    Private WithEvents clmCh As System.Windows.Forms.ColumnHeader
    Private WithEvents clmModbusAddr As System.Windows.Forms.ColumnHeader
    Private WithEvents clmValue As System.Windows.Forms.ColumnHeader
    Private WithEvents clmChStatus As System.Windows.Forms.ColumnHeader
    Private WithEvents label16 As System.Windows.Forms.Label
    Private WithEvents bSetRange As System.Windows.Forms.Button
    Private WithEvents gbxSetRangeOptionalFunction As System.Windows.Forms.GroupBox
    Private WithEvents label17 As System.Windows.Forms.Label
    Private WithEvents label18 As System.Windows.Forms.Label
    Private WithEvents cbBurnOutEnable As System.Windows.Forms.ComboBox
    Private WithEvents bGetConfig As System.Windows.Forms.Button
    Private WithEvents tpSetRange As System.Windows.Forms.TabPage
    Private WithEvents gbxChRangeType As System.Windows.Forms.GroupBox
    Private WithEvents cbCh0 As System.Windows.Forms.ComboBox
    Private WithEvents cbCh5 As System.Windows.Forms.ComboBox
    Private WithEvents label10 As System.Windows.Forms.Label
    Private WithEvents cbCh4 As System.Windows.Forms.ComboBox
    Private WithEvents cbCh2 As System.Windows.Forms.ComboBox
    Private WithEvents label9 As System.Windows.Forms.Label
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents label8 As System.Windows.Forms.Label
    Private WithEvents cbCh3 As System.Windows.Forms.ComboBox
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents cbCh1 As System.Windows.Forms.ComboBox
    Private WithEvents label11 As System.Windows.Forms.Label
    Private WithEvents clmChInfoLastUpdateTime As System.Windows.Forms.ColumnHeader
    Private WithEvents clmChInfoLQI As System.Windows.Forms.ColumnHeader
    Private WithEvents clmListShortAddr As System.Windows.Forms.ColumnHeader
    Private WithEvents clmListParentAddr As System.Windows.Forms.ColumnHeader
    Private WithEvents clmListCycleTime As System.Windows.Forms.ColumnHeader
    Private WithEvents clmListInactiveTime As System.Windows.Forms.ColumnHeader
    Private WithEvents clmListStatus As System.Windows.Forms.ColumnHeader
    Private WithEvents timerSearchCoordinator As System.Windows.Forms.Timer
    Private WithEvents clmListLQI As System.Windows.Forms.ColumnHeader
    Private WithEvents clmListSlaveId As System.Windows.Forms.ColumnHeader
    Private WithEvents clmListDeviceName As System.Windows.Forms.ColumnHeader
    Private WithEvents tpDeviceList As System.Windows.Forms.TabPage
    Private WithEvents bDeviceListRefresh As System.Windows.Forms.Button
    Private WithEvents gbxDeviceList As System.Windows.Forms.GroupBox
    Private WithEvents listViewDeviceList As System.Windows.Forms.ListView
    Private WithEvents clmChInfoDataCycle As System.Windows.Forms.ColumnHeader
    Private WithEvents clmChInfoMode As System.Windows.Forms.ColumnHeader
    Private WithEvents txtChannel As System.Windows.Forms.TextBox
    Private WithEvents txtDataCycle As System.Windows.Forms.TextBox
    Private WithEvents clmChInfoValue As System.Windows.Forms.ColumnHeader
    Private WithEvents txtSlaveId As System.Windows.Forms.TextBox
    Private WithEvents txtPanId As System.Windows.Forms.TextBox
    Private WithEvents gbxzigbee As System.Windows.Forms.GroupBox
    Private WithEvents labSlaveId As System.Windows.Forms.Label
    Private WithEvents txtPAddr As System.Windows.Forms.TextBox
    Private WithEvents labPAddr As System.Windows.Forms.Label
    Private WithEvents labDataCycle As System.Windows.Forms.Label
    Private WithEvents txtSAddr As System.Windows.Forms.TextBox
    Private WithEvents labSAddr As System.Windows.Forms.Label
    Private WithEvents labChannel As System.Windows.Forms.Label
    Private WithEvents labPanId As System.Windows.Forms.Label
    Private WithEvents tpInformation As System.Windows.Forms.TabPage
    Private WithEvents gbxFw As System.Windows.Forms.GroupBox
    Private WithEvents txtFwVerZigBee As System.Windows.Forms.TextBox
    Private WithEvents labKernal As System.Windows.Forms.Label
    Private WithEvents labWireless As System.Windows.Forms.Label
    Private WithEvents txtFwVerKernal As System.Windows.Forms.TextBox
    Private WithEvents gbxDevice As System.Windows.Forms.GroupBox
    Private WithEvents txtDeviceName As System.Windows.Forms.TextBox
    Private WithEvents txtDescription As System.Windows.Forms.TextBox
    Private WithEvents labDescription As System.Windows.Forms.Label
    Private WithEvents labAdamDevice As System.Windows.Forms.Label
    Private WithEvents tcDeviceInfo As System.Windows.Forms.TabControl
    Private WithEvents tpDeviceStatus As System.Windows.Forms.TabPage
    Private WithEvents gbxDeviceStatus As System.Windows.Forms.GroupBox
    Private WithEvents txtModeStatus As System.Windows.Forms.TextBox
    Private WithEvents txtPower As System.Windows.Forms.TextBox
    Private WithEvents txtBattery As System.Windows.Forms.TextBox
    Private WithEvents txtLink As System.Windows.Forms.TextBox
    Private WithEvents labPowerDetection As System.Windows.Forms.Label
    Private WithEvents labBatteryStatus As System.Windows.Forms.Label
    Private WithEvents labLinkQuality As System.Windows.Forms.Label
    Private WithEvents labModeStatus As System.Windows.Forms.Label
    Private WithEvents tpChannelInfo As System.Windows.Forms.TabPage
    Private WithEvents lPollingTimes As System.Windows.Forms.Label
    Private WithEvents bPolling As System.Windows.Forms.Button
    Private WithEvents gbxChannelInfo As System.Windows.Forms.GroupBox
    Private WithEvents listViewChannelInfo As System.Windows.Forms.ListView
    Private WithEvents clmChInfoType As System.Windows.Forms.ColumnHeader
    Private WithEvents clmChInfoCh As System.Windows.Forms.ColumnHeader
    Private WithEvents clmChInfoModbusAddr As System.Windows.Forms.ColumnHeader
    Private WithEvents bGetEndDevice As System.Windows.Forms.Button
    Private WithEvents imageList1 As System.Windows.Forms.ImageList
    Private WithEvents gbDeviceInfo As System.Windows.Forms.GroupBox
    Private WithEvents treeView1 As System.Windows.Forms.TreeView
    Private WithEvents gbDeviceTreeView As System.Windows.Forms.GroupBox
    Private WithEvents timerPollingData As System.Windows.Forms.Timer

End Class
