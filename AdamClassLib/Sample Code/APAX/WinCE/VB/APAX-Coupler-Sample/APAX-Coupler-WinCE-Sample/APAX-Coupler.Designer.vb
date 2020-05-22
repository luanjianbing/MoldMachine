<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Form_APAX_Coupler
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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Ethernet")
        Me.mainMenu1 = New System.Windows.Forms.MainMenu
        Me.menuItem1 = New System.Windows.Forms.MenuItem
        Me.menuItem2 = New System.Windows.Forms.MenuItem
        Me.menuItem3 = New System.Windows.Forms.MenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.treeView1 = New System.Windows.Forms.TreeView
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.tabControl1 = New System.Windows.Forms.TabControl
        Me.tabInfomation = New System.Windows.Forms.TabPage
        Me.listViewDescription = New System.Windows.Forms.ListView
        Me.clmSwID = New System.Windows.Forms.ColumnHeader
        Me.clmModule = New System.Windows.Forms.ColumnHeader
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.txtDeviceDesc = New System.Windows.Forms.TextBox
        Me.labDevDesc = New System.Windows.Forms.Label
        Me.txtDeviceName = New System.Windows.Forms.TextBox
        Me.labDevName = New System.Windows.Forms.Label
        Me.txtFwVer2 = New System.Windows.Forms.TextBox
        Me.labFwVer2 = New System.Windows.Forms.Label
        Me.txtFpgaFwVer = New System.Windows.Forms.TextBox
        Me.labFPGAVer = New System.Windows.Forms.Label
        Me.txtFwVer = New System.Windows.Forms.TextBox
        Me.labFwVer = New System.Windows.Forms.Label
        Me.labModuleName = New System.Windows.Forms.Label
        Me.tabNetSetting = New System.Windows.Forms.TabPage
        Me.panelFSVSetting = New System.Windows.Forms.Panel
        Me.btnSetCommFSV = New System.Windows.Forms.Button
        Me.label2 = New System.Windows.Forms.Label
        Me.chbxEnCommFSV = New System.Windows.Forms.CheckBox
        Me.label1 = New System.Windows.Forms.Label
        Me.txtCommFSVtimeout = New System.Windows.Forms.TextBox
        Me.panelNetworkSetting = New System.Windows.Forms.Panel
        Me.label3 = New System.Windows.Forms.Label
        Me.txtDefaultGateway = New System.Windows.Forms.TextBox
        Me.txtSubnetAddress = New System.Windows.Forms.TextBox
        Me.txtIPAddress = New System.Windows.Forms.TextBox
        Me.labMacAddress = New System.Windows.Forms.Label
        Me.txtMacAddress = New System.Windows.Forms.TextBox
        Me.labIPAddress = New System.Windows.Forms.Label
        Me.labSubnetMask = New System.Windows.Forms.Label
        Me.labDefaultGateway = New System.Windows.Forms.Label
        Me.labHostIdle = New System.Windows.Forms.Label
        Me.numHostIdle = New System.Windows.Forms.TextBox
        Me.tabAddressSetting = New System.Windows.Forms.TabPage
        Me.gvAddress = New System.Windows.Forms.ListView
        Me.ColumnSwitchID = New System.Windows.Forms.ColumnHeader
        Me.ColumnModuleName = New System.Windows.Forms.ColumnHeader
        Me.ColumnAddressType = New System.Windows.Forms.ColumnHeader
        Me.ColumnStartAddress = New System.Windows.Forms.ColumnHeader
        Me.ColumnLength = New System.Windows.Forms.ColumnHeader
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.addressTypeValue = New System.Windows.Forms.TextBox
        Me.label4 = New System.Windows.Forms.Label
        Me.tabSerial = New System.Windows.Forms.TabPage
        Me.panelInfo_SerialMapTcpPort = New System.Windows.Forms.Panel
        Me.listViewComPortInfo = New System.Windows.Forms.ListView
        Me.clmSwitchId = New System.Windows.Forms.ColumnHeader
        Me.clmModuleName = New System.Windows.Forms.ColumnHeader
        Me.clmComPort = New System.Windows.Forms.ColumnHeader
        Me.clmTcpPortMap = New System.Windows.Forms.ColumnHeader
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.tabControl1.SuspendLayout()
        Me.tabInfomation.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.tabNetSetting.SuspendLayout()
        Me.panelFSVSetting.SuspendLayout()
        Me.panelNetworkSetting.SuspendLayout()
        Me.tabAddressSetting.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.tabSerial.SuspendLayout()
        Me.panelInfo_SerialMapTcpPort.SuspendLayout()
        Me.SuspendLayout()
        '
        'mainMenu1
        '
        Me.mainMenu1.MenuItems.Add(Me.menuItem1)
        Me.mainMenu1.MenuItems.Add(Me.menuItem2)
        Me.mainMenu1.MenuItems.Add(Me.menuItem3)
        '
        'menuItem1
        '
        Me.menuItem1.Text = "Refresh Ethernet"
        '
        'menuItem2
        '
        Me.menuItem2.Text = "Setting IP"
        '
        'menuItem3
        '
        Me.menuItem3.Text = "Exit"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.treeView1)
        Me.Panel1.Location = New System.Drawing.Point(0, 26)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(130, 407)
        '
        'treeView1
        '
        Me.treeView1.Dock = System.Windows.Forms.DockStyle.Left
        Me.treeView1.Location = New System.Drawing.Point(0, 0)
        Me.treeView1.Name = "treeView1"
        TreeNode1.Text = "Ethernet"
        Me.treeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1})
        Me.treeView1.Size = New System.Drawing.Size(129, 407)
        Me.treeView1.TabIndex = 6
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.tabControl1)
        Me.Panel2.Location = New System.Drawing.Point(136, 26)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(499, 407)
        '
        'tabControl1
        '
        Me.tabControl1.Controls.Add(Me.tabInfomation)
        Me.tabControl1.Controls.Add(Me.tabNetSetting)
        Me.tabControl1.Controls.Add(Me.tabAddressSetting)
        Me.tabControl1.Controls.Add(Me.tabSerial)
        Me.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabControl1.Location = New System.Drawing.Point(0, 0)
        Me.tabControl1.Name = "tabControl1"
        Me.tabControl1.SelectedIndex = 0
        Me.tabControl1.Size = New System.Drawing.Size(499, 407)
        Me.tabControl1.TabIndex = 2
        '
        'tabInfomation
        '
        Me.tabInfomation.Controls.Add(Me.listViewDescription)
        Me.tabInfomation.Controls.Add(Me.Panel3)
        Me.tabInfomation.Location = New System.Drawing.Point(4, 25)
        Me.tabInfomation.Name = "tabInfomation"
        Me.tabInfomation.Size = New System.Drawing.Size(491, 378)
        Me.tabInfomation.Text = "Information"
        '
        'listViewDescription
        '
        Me.listViewDescription.Columns.Add(Me.clmSwID)
        Me.listViewDescription.Columns.Add(Me.clmModule)
        Me.listViewDescription.Dock = System.Windows.Forms.DockStyle.Fill
        Me.listViewDescription.Location = New System.Drawing.Point(0, 220)
        Me.listViewDescription.Name = "listViewDescription"
        Me.listViewDescription.Size = New System.Drawing.Size(491, 158)
        Me.listViewDescription.TabIndex = 4
        Me.listViewDescription.View = System.Windows.Forms.View.Details
        '
        'clmSwID
        '
        Me.clmSwID.Text = "Switch ID"
        Me.clmSwID.Width = 152
        '
        'clmModule
        '
        Me.clmModule.Text = "Module"
        Me.clmModule.Width = 284
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.txtDeviceDesc)
        Me.Panel3.Controls.Add(Me.labDevDesc)
        Me.Panel3.Controls.Add(Me.txtDeviceName)
        Me.Panel3.Controls.Add(Me.labDevName)
        Me.Panel3.Controls.Add(Me.txtFwVer2)
        Me.Panel3.Controls.Add(Me.labFwVer2)
        Me.Panel3.Controls.Add(Me.txtFpgaFwVer)
        Me.Panel3.Controls.Add(Me.labFPGAVer)
        Me.Panel3.Controls.Add(Me.txtFwVer)
        Me.Panel3.Controls.Add(Me.labFwVer)
        Me.Panel3.Controls.Add(Me.labModuleName)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(491, 220)
        '
        'txtDeviceDesc
        '
        Me.txtDeviceDesc.Enabled = False
        Me.txtDeviceDesc.Location = New System.Drawing.Point(153, 162)
        Me.txtDeviceDesc.Multiline = True
        Me.txtDeviceDesc.Name = "txtDeviceDesc"
        Me.txtDeviceDesc.ReadOnly = True
        Me.txtDeviceDesc.Size = New System.Drawing.Size(247, 51)
        Me.txtDeviceDesc.TabIndex = 39
        '
        'labDevDesc
        '
        Me.labDevDesc.Location = New System.Drawing.Point(12, 164)
        Me.labDevDesc.Name = "labDevDesc"
        Me.labDevDesc.Size = New System.Drawing.Size(120, 20)
        Me.labDevDesc.Text = "Device Description :"
        '
        'txtDeviceName
        '
        Me.txtDeviceName.Enabled = False
        Me.txtDeviceName.Location = New System.Drawing.Point(153, 130)
        Me.txtDeviceName.Name = "txtDeviceName"
        Me.txtDeviceName.ReadOnly = True
        Me.txtDeviceName.Size = New System.Drawing.Size(176, 23)
        Me.txtDeviceName.TabIndex = 36
        '
        'labDevName
        '
        Me.labDevName.Location = New System.Drawing.Point(12, 133)
        Me.labDevName.Name = "labDevName"
        Me.labDevName.Size = New System.Drawing.Size(120, 20)
        Me.labDevName.Text = "Device Name :"
        '
        'txtFwVer2
        '
        Me.txtFwVer2.Enabled = False
        Me.txtFwVer2.Location = New System.Drawing.Point(153, 99)
        Me.txtFwVer2.Name = "txtFwVer2"
        Me.txtFwVer2.ReadOnly = True
        Me.txtFwVer2.Size = New System.Drawing.Size(176, 23)
        Me.txtFwVer2.TabIndex = 30
        '
        'labFwVer2
        '
        Me.labFwVer2.Location = New System.Drawing.Point(12, 102)
        Me.labFwVer2.Name = "labFwVer2"
        Me.labFwVer2.Size = New System.Drawing.Size(120, 20)
        Me.labFwVer2.Text = "Kernel Version :"
        '
        'txtFpgaFwVer
        '
        Me.txtFpgaFwVer.Enabled = False
        Me.txtFpgaFwVer.Location = New System.Drawing.Point(153, 68)
        Me.txtFpgaFwVer.Name = "txtFpgaFwVer"
        Me.txtFpgaFwVer.ReadOnly = True
        Me.txtFpgaFwVer.Size = New System.Drawing.Size(176, 23)
        Me.txtFpgaFwVer.TabIndex = 18
        '
        'labFPGAVer
        '
        Me.labFPGAVer.Location = New System.Drawing.Point(12, 71)
        Me.labFPGAVer.Name = "labFPGAVer"
        Me.labFPGAVer.Size = New System.Drawing.Size(120, 20)
        Me.labFPGAVer.Text = "FPGA Version :"
        '
        'txtFwVer
        '
        Me.txtFwVer.Enabled = False
        Me.txtFwVer.Location = New System.Drawing.Point(153, 37)
        Me.txtFwVer.Name = "txtFwVer"
        Me.txtFwVer.ReadOnly = True
        Me.txtFwVer.Size = New System.Drawing.Size(176, 23)
        Me.txtFwVer.TabIndex = 20
        '
        'labFwVer
        '
        Me.labFwVer.Location = New System.Drawing.Point(12, 40)
        Me.labFwVer.Name = "labFwVer"
        Me.labFwVer.Size = New System.Drawing.Size(120, 20)
        Me.labFwVer.Text = "Firmware Version :"
        '
        'labModuleName
        '
        Me.labModuleName.Location = New System.Drawing.Point(12, 7)
        Me.labModuleName.Name = "labModuleName"
        Me.labModuleName.Size = New System.Drawing.Size(100, 20)
        Me.labModuleName.Text = "APAX-PAC"
        '
        'tabNetSetting
        '
        Me.tabNetSetting.Controls.Add(Me.panelFSVSetting)
        Me.tabNetSetting.Controls.Add(Me.panelNetworkSetting)
        Me.tabNetSetting.Location = New System.Drawing.Point(4, 25)
        Me.tabNetSetting.Name = "tabNetSetting"
        Me.tabNetSetting.Size = New System.Drawing.Size(491, 378)
        Me.tabNetSetting.Text = "Network Setting"
        '
        'panelFSVSetting
        '
        Me.panelFSVSetting.Controls.Add(Me.btnSetCommFSV)
        Me.panelFSVSetting.Controls.Add(Me.label2)
        Me.panelFSVSetting.Controls.Add(Me.chbxEnCommFSV)
        Me.panelFSVSetting.Controls.Add(Me.label1)
        Me.panelFSVSetting.Controls.Add(Me.txtCommFSVtimeout)
        Me.panelFSVSetting.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelFSVSetting.Location = New System.Drawing.Point(0, 216)
        Me.panelFSVSetting.Name = "panelFSVSetting"
        Me.panelFSVSetting.Size = New System.Drawing.Size(491, 162)
        '
        'btnSetCommFSV
        '
        Me.btnSetCommFSV.Location = New System.Drawing.Point(300, 50)
        Me.btnSetCommFSV.Name = "btnSetCommFSV"
        Me.btnSetCommFSV.Size = New System.Drawing.Size(72, 20)
        Me.btnSetCommFSV.TabIndex = 15
        Me.btnSetCommFSV.Text = "Apply"
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(16, 18)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(237, 20)
        Me.label2.Text = "Fail Safe Value Setting"
        '
        'chbxEnCommFSV
        '
        Me.chbxEnCommFSV.Location = New System.Drawing.Point(16, 50)
        Me.chbxEnCommFSV.Name = "chbxEnCommFSV"
        Me.chbxEnCommFSV.Size = New System.Drawing.Size(263, 20)
        Me.chbxEnCommFSV.TabIndex = 13
        Me.chbxEnCommFSV.Text = "Enable Communication FSV "
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(16, 83)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(96, 16)
        Me.label1.Text = "Timout (sec)"
        '
        'txtCommFSVtimeout
        '
        Me.txtCommFSVtimeout.Location = New System.Drawing.Point(112, 76)
        Me.txtCommFSVtimeout.Name = "txtCommFSVtimeout"
        Me.txtCommFSVtimeout.Size = New System.Drawing.Size(167, 23)
        Me.txtCommFSVtimeout.TabIndex = 12
        '
        'panelNetworkSetting
        '
        Me.panelNetworkSetting.Controls.Add(Me.label3)
        Me.panelNetworkSetting.Controls.Add(Me.txtDefaultGateway)
        Me.panelNetworkSetting.Controls.Add(Me.txtSubnetAddress)
        Me.panelNetworkSetting.Controls.Add(Me.txtIPAddress)
        Me.panelNetworkSetting.Controls.Add(Me.labMacAddress)
        Me.panelNetworkSetting.Controls.Add(Me.txtMacAddress)
        Me.panelNetworkSetting.Controls.Add(Me.labIPAddress)
        Me.panelNetworkSetting.Controls.Add(Me.labSubnetMask)
        Me.panelNetworkSetting.Controls.Add(Me.labDefaultGateway)
        Me.panelNetworkSetting.Controls.Add(Me.labHostIdle)
        Me.panelNetworkSetting.Controls.Add(Me.numHostIdle)
        Me.panelNetworkSetting.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelNetworkSetting.Location = New System.Drawing.Point(0, 0)
        Me.panelNetworkSetting.Name = "panelNetworkSetting"
        Me.panelNetworkSetting.Size = New System.Drawing.Size(491, 216)
        '
        'label3
        '
        Me.label3.Location = New System.Drawing.Point(16, 16)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(237, 20)
        Me.label3.Text = "Network Setting"
        '
        'txtDefaultGateway
        '
        Me.txtDefaultGateway.Enabled = False
        Me.txtDefaultGateway.Location = New System.Drawing.Point(112, 143)
        Me.txtDefaultGateway.Name = "txtDefaultGateway"
        Me.txtDefaultGateway.Size = New System.Drawing.Size(167, 23)
        Me.txtDefaultGateway.TabIndex = 1
        '
        'txtSubnetAddress
        '
        Me.txtSubnetAddress.Enabled = False
        Me.txtSubnetAddress.Location = New System.Drawing.Point(112, 110)
        Me.txtSubnetAddress.Name = "txtSubnetAddress"
        Me.txtSubnetAddress.Size = New System.Drawing.Size(167, 23)
        Me.txtSubnetAddress.TabIndex = 2
        '
        'txtIPAddress
        '
        Me.txtIPAddress.Enabled = False
        Me.txtIPAddress.Location = New System.Drawing.Point(112, 78)
        Me.txtIPAddress.Name = "txtIPAddress"
        Me.txtIPAddress.Size = New System.Drawing.Size(167, 23)
        Me.txtIPAddress.TabIndex = 3
        '
        'labMacAddress
        '
        Me.labMacAddress.Location = New System.Drawing.Point(16, 52)
        Me.labMacAddress.Name = "labMacAddress"
        Me.labMacAddress.Size = New System.Drawing.Size(96, 16)
        Me.labMacAddress.Text = "Mac Address"
        '
        'txtMacAddress
        '
        Me.txtMacAddress.Enabled = False
        Me.txtMacAddress.Location = New System.Drawing.Point(112, 46)
        Me.txtMacAddress.Name = "txtMacAddress"
        Me.txtMacAddress.Size = New System.Drawing.Size(167, 23)
        Me.txtMacAddress.TabIndex = 5
        '
        'labIPAddress
        '
        Me.labIPAddress.Location = New System.Drawing.Point(16, 84)
        Me.labIPAddress.Name = "labIPAddress"
        Me.labIPAddress.Size = New System.Drawing.Size(96, 16)
        Me.labIPAddress.Text = "IP Address"
        '
        'labSubnetMask
        '
        Me.labSubnetMask.Location = New System.Drawing.Point(16, 116)
        Me.labSubnetMask.Name = "labSubnetMask"
        Me.labSubnetMask.Size = New System.Drawing.Size(96, 16)
        Me.labSubnetMask.Text = "Subnet Mask"
        '
        'labDefaultGateway
        '
        Me.labDefaultGateway.Location = New System.Drawing.Point(16, 148)
        Me.labDefaultGateway.Name = "labDefaultGateway"
        Me.labDefaultGateway.Size = New System.Drawing.Size(96, 16)
        Me.labDefaultGateway.Text = "Default Gateway"
        '
        'labHostIdle
        '
        Me.labHostIdle.Location = New System.Drawing.Point(16, 180)
        Me.labHostIdle.Name = "labHostIdle"
        Me.labHostIdle.Size = New System.Drawing.Size(96, 16)
        Me.labHostIdle.Text = "Host Idle Timeout"
        '
        'numHostIdle
        '
        Me.numHostIdle.Enabled = False
        Me.numHostIdle.Location = New System.Drawing.Point(112, 176)
        Me.numHostIdle.Name = "numHostIdle"
        Me.numHostIdle.Size = New System.Drawing.Size(167, 23)
        Me.numHostIdle.TabIndex = 10
        '
        'tabAddressSetting
        '
        Me.tabAddressSetting.Controls.Add(Me.gvAddress)
        Me.tabAddressSetting.Controls.Add(Me.Panel4)
        Me.tabAddressSetting.Location = New System.Drawing.Point(4, 25)
        Me.tabAddressSetting.Name = "tabAddressSetting"
        Me.tabAddressSetting.Size = New System.Drawing.Size(491, 378)
        Me.tabAddressSetting.Text = "Modbus Address Setting"
        '
        'gvAddress
        '
        Me.gvAddress.Columns.Add(Me.ColumnSwitchID)
        Me.gvAddress.Columns.Add(Me.ColumnModuleName)
        Me.gvAddress.Columns.Add(Me.ColumnAddressType)
        Me.gvAddress.Columns.Add(Me.ColumnStartAddress)
        Me.gvAddress.Columns.Add(Me.ColumnLength)
        Me.gvAddress.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gvAddress.Location = New System.Drawing.Point(0, 51)
        Me.gvAddress.Name = "gvAddress"
        Me.gvAddress.Size = New System.Drawing.Size(491, 327)
        Me.gvAddress.TabIndex = 3
        Me.gvAddress.View = System.Windows.Forms.View.Details
        '
        'ColumnSwitchID
        '
        Me.ColumnSwitchID.Text = "Switch ID"
        Me.ColumnSwitchID.Width = 70
        '
        'ColumnModuleName
        '
        Me.ColumnModuleName.Text = "Module Name"
        Me.ColumnModuleName.Width = 90
        '
        'ColumnAddressType
        '
        Me.ColumnAddressType.Text = "Address Type"
        Me.ColumnAddressType.Width = 90
        '
        'ColumnStartAddress
        '
        Me.ColumnStartAddress.Text = "Start Address"
        Me.ColumnStartAddress.Width = 90
        '
        'ColumnLength
        '
        Me.ColumnLength.Text = "Length"
        Me.ColumnLength.Width = 70
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.addressTypeValue)
        Me.Panel4.Controls.Add(Me.label4)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(491, 51)
        '
        'addressTypeValue
        '
        Me.addressTypeValue.Enabled = False
        Me.addressTypeValue.Location = New System.Drawing.Point(122, 16)
        Me.addressTypeValue.Name = "addressTypeValue"
        Me.addressTypeValue.Size = New System.Drawing.Size(151, 23)
        Me.addressTypeValue.TabIndex = 1
        '
        'label4
        '
        Me.label4.Location = New System.Drawing.Point(15, 20)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(100, 20)
        Me.label4.Text = "Address Type"
        '
        'tabSerial
        '
        Me.tabSerial.Controls.Add(Me.panelInfo_SerialMapTcpPort)
        Me.tabSerial.Location = New System.Drawing.Point(4, 25)
        Me.tabSerial.Name = "tabSerial"
        Me.tabSerial.Size = New System.Drawing.Size(491, 378)
        Me.tabSerial.Text = "Serial"
        '
        'panelInfo_SerialMapTcpPort
        '
        Me.panelInfo_SerialMapTcpPort.Controls.Add(Me.listViewComPortInfo)
        Me.panelInfo_SerialMapTcpPort.Location = New System.Drawing.Point(1, 15)
        Me.panelInfo_SerialMapTcpPort.Name = "panelInfo_SerialMapTcpPort"
        Me.panelInfo_SerialMapTcpPort.Size = New System.Drawing.Size(489, 348)
        '
        'listViewComPortInfo
        '
        Me.listViewComPortInfo.Columns.Add(Me.clmSwitchId)
        Me.listViewComPortInfo.Columns.Add(Me.clmModuleName)
        Me.listViewComPortInfo.Columns.Add(Me.clmComPort)
        Me.listViewComPortInfo.Columns.Add(Me.clmTcpPortMap)
        Me.listViewComPortInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.listViewComPortInfo.FullRowSelect = True
        Me.listViewComPortInfo.Location = New System.Drawing.Point(0, 0)
        Me.listViewComPortInfo.Name = "listViewComPortInfo"
        Me.listViewComPortInfo.Size = New System.Drawing.Size(489, 348)
        Me.listViewComPortInfo.TabIndex = 11
        Me.listViewComPortInfo.View = System.Windows.Forms.View.Details
        '
        'clmSwitchId
        '
        Me.clmSwitchId.Text = "Switcvh ID"
        Me.clmSwitchId.Width = 85
        '
        'clmModuleName
        '
        Me.clmModuleName.Text = "Module Name"
        Me.clmModuleName.Width = 100
        '
        'clmComPort
        '
        Me.clmComPort.Text = "COM Port"
        Me.clmComPort.Width = 85
        '
        'clmTcpPortMap
        '
        Me.clmTcpPortMap.Text = "TCP Port Mapping (1026~2000)"
        Me.clmTcpPortMap.Width = 200
        '
        'Form_APAX_Coupler
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(638, 455)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Menu = Me.mainMenu1
        Me.Name = "Form_APAX_Coupler"
        Me.Text = "APAX-Coupler"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.tabControl1.ResumeLayout(False)
        Me.tabInfomation.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.tabNetSetting.ResumeLayout(False)
        Me.panelFSVSetting.ResumeLayout(False)
        Me.panelNetworkSetting.ResumeLayout(False)
        Me.tabAddressSetting.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.tabSerial.ResumeLayout(False)
        Me.panelInfo_SerialMapTcpPort.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents mainMenu1 As System.Windows.Forms.MainMenu
    Private WithEvents menuItem1 As System.Windows.Forms.MenuItem
    Private WithEvents menuItem2 As System.Windows.Forms.MenuItem
    Private WithEvents menuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Private WithEvents treeView1 As System.Windows.Forms.TreeView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Private WithEvents tabControl1 As System.Windows.Forms.TabControl
    Private WithEvents tabInfomation As System.Windows.Forms.TabPage
    Private WithEvents listViewDescription As System.Windows.Forms.ListView
    Private WithEvents clmSwID As System.Windows.Forms.ColumnHeader
    Private WithEvents clmModule As System.Windows.Forms.ColumnHeader
    Private WithEvents Panel3 As System.Windows.Forms.Panel
    Private WithEvents txtDeviceDesc As System.Windows.Forms.TextBox
    Private WithEvents labDevDesc As System.Windows.Forms.Label
    Private WithEvents txtDeviceName As System.Windows.Forms.TextBox
    Private WithEvents labDevName As System.Windows.Forms.Label
    Private WithEvents txtFwVer2 As System.Windows.Forms.TextBox
    Private WithEvents labFwVer2 As System.Windows.Forms.Label
    Private WithEvents txtFpgaFwVer As System.Windows.Forms.TextBox
    Private WithEvents labFPGAVer As System.Windows.Forms.Label
    Private WithEvents txtFwVer As System.Windows.Forms.TextBox
    Private WithEvents labFwVer As System.Windows.Forms.Label
    Private WithEvents labModuleName As System.Windows.Forms.Label
    Private WithEvents tabNetSetting As System.Windows.Forms.TabPage
    Private WithEvents panelFSVSetting As System.Windows.Forms.Panel
    Private WithEvents btnSetCommFSV As System.Windows.Forms.Button
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents chbxEnCommFSV As System.Windows.Forms.CheckBox
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents txtCommFSVtimeout As System.Windows.Forms.TextBox
    Private WithEvents panelNetworkSetting As System.Windows.Forms.Panel
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents txtDefaultGateway As System.Windows.Forms.TextBox
    Private WithEvents txtSubnetAddress As System.Windows.Forms.TextBox
    Private WithEvents txtIPAddress As System.Windows.Forms.TextBox
    Private WithEvents labMacAddress As System.Windows.Forms.Label
    Private WithEvents txtMacAddress As System.Windows.Forms.TextBox
    Private WithEvents labIPAddress As System.Windows.Forms.Label
    Private WithEvents labSubnetMask As System.Windows.Forms.Label
    Private WithEvents labDefaultGateway As System.Windows.Forms.Label
    Private WithEvents labHostIdle As System.Windows.Forms.Label
    Private WithEvents numHostIdle As System.Windows.Forms.TextBox
    Private WithEvents tabAddressSetting As System.Windows.Forms.TabPage
    Private WithEvents gvAddress As System.Windows.Forms.ListView
    Private WithEvents ColumnSwitchID As System.Windows.Forms.ColumnHeader
    Private WithEvents ColumnModuleName As System.Windows.Forms.ColumnHeader
    Private WithEvents ColumnAddressType As System.Windows.Forms.ColumnHeader
    Private WithEvents ColumnStartAddress As System.Windows.Forms.ColumnHeader
    Private WithEvents ColumnLength As System.Windows.Forms.ColumnHeader
    Private WithEvents Panel4 As System.Windows.Forms.Panel
    Private WithEvents addressTypeValue As System.Windows.Forms.TextBox
    Private WithEvents label4 As System.Windows.Forms.Label
    Friend WithEvents tabSerial As System.Windows.Forms.TabPage
    Private WithEvents panelInfo_SerialMapTcpPort As System.Windows.Forms.Panel
    Private WithEvents listViewComPortInfo As System.Windows.Forms.ListView
    Private WithEvents clmSwitchId As System.Windows.Forms.ColumnHeader
    Private WithEvents clmModuleName As System.Windows.Forms.ColumnHeader
    Private WithEvents clmComPort As System.Windows.Forms.ColumnHeader
    Private WithEvents clmTcpPortMap As System.Windows.Forms.ColumnHeader

End Class
