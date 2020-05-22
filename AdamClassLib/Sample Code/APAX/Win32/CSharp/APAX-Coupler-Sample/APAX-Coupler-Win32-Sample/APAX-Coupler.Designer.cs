namespace APAX_Coupler_Win32_Sample
{
    partial class Form_APAX_Coupler
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Ethernet");
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabInfomation = new System.Windows.Forms.TabPage();
            this.listViewDescription = new System.Windows.Forms.ListView();
            this.clmSwID = new System.Windows.Forms.ColumnHeader();
            this.clmModule = new System.Windows.Forms.ColumnHeader();
            this.Panel3 = new System.Windows.Forms.Panel();
            this.txtDeviceDesc = new System.Windows.Forms.TextBox();
            this.labDevDesc = new System.Windows.Forms.Label();
            this.txtDeviceName = new System.Windows.Forms.TextBox();
            this.labDevName = new System.Windows.Forms.Label();
            this.txtFwVer2 = new System.Windows.Forms.TextBox();
            this.labFwVer2 = new System.Windows.Forms.Label();
            this.txtFpgaFwVer = new System.Windows.Forms.TextBox();
            this.labFPGAVer = new System.Windows.Forms.Label();
            this.txtFwVer = new System.Windows.Forms.TextBox();
            this.labFwVer = new System.Windows.Forms.Label();
            this.labModuleName = new System.Windows.Forms.Label();
            this.tabNetSetting = new System.Windows.Forms.TabPage();
            this.panelFSVSetting = new System.Windows.Forms.Panel();
            this.btnSetCommFSV = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.chbxEnCommFSV = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCommFSVtimeout = new System.Windows.Forms.TextBox();
            this.panelNetworkSetting = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDefaultGateway = new System.Windows.Forms.TextBox();
            this.txtSubnetAddress = new System.Windows.Forms.TextBox();
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.labMacAddress = new System.Windows.Forms.Label();
            this.txtMacAddress = new System.Windows.Forms.TextBox();
            this.labIPAddress = new System.Windows.Forms.Label();
            this.labSubnetMask = new System.Windows.Forms.Label();
            this.labDefaultGateway = new System.Windows.Forms.Label();
            this.labHostIdle = new System.Windows.Forms.Label();
            this.numHostIdle = new System.Windows.Forms.TextBox();
            this.tabAddressSetting = new System.Windows.Forms.TabPage();
            this.gvAddress = new System.Windows.Forms.ListView();
            this.ColumnSwitchID = new System.Windows.Forms.ColumnHeader();
            this.ColumnModuleName = new System.Windows.Forms.ColumnHeader();
            this.ColumnAddressType = new System.Windows.Forms.ColumnHeader();
            this.ColumnStartAddress = new System.Windows.Forms.ColumnHeader();
            this.ColumnLength = new System.Windows.Forms.ColumnHeader();
            this.Panel4 = new System.Windows.Forms.Panel();
            this.addressTypeValue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabSerial = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gbxComTcpPortSetting = new System.Windows.Forms.GroupBox();
            this.listViewComPortInfo = new System.Windows.Forms.ListView();
            this.clmSwitchId = new System.Windows.Forms.ColumnHeader();
            this.clmModuleName = new System.Windows.Forms.ColumnHeader();
            this.clmComPort = new System.Windows.Forms.ColumnHeader();
            this.clmTcpPortMap = new System.Windows.Forms.ColumnHeader();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabInfomation.SuspendLayout();
            this.Panel3.SuspendLayout();
            this.tabNetSetting.SuspendLayout();
            this.panelFSVSetting.SuspendLayout();
            this.panelNetworkSetting.SuspendLayout();
            this.tabAddressSetting.SuspendLayout();
            this.Panel4.SuspendLayout();
            this.tabSerial.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.gbxComTcpPortSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2,
            this.menuItem3});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "Refresh Ethernet";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.Text = "Setting IP";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 2;
            this.menuItem3.Text = "Exit";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(696, 437);
            this.splitContainer1.SplitterDistance = 175;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode2.Name = "";
            treeNode2.Text = "Ethernet";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.treeView1.Size = new System.Drawing.Size(175, 437);
            this.treeView1.TabIndex = 10;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabInfomation);
            this.tabControl1.Controls.Add(this.tabNetSetting);
            this.tabControl1.Controls.Add(this.tabAddressSetting);
            this.tabControl1.Controls.Add(this.tabSerial);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(517, 437);
            this.tabControl1.TabIndex = 4;
            // 
            // tabInfomation
            // 
            this.tabInfomation.Controls.Add(this.listViewDescription);
            this.tabInfomation.Controls.Add(this.Panel3);
            this.tabInfomation.Location = new System.Drawing.Point(4, 22);
            this.tabInfomation.Name = "tabInfomation";
            this.tabInfomation.Size = new System.Drawing.Size(509, 411);
            this.tabInfomation.TabIndex = 0;
            this.tabInfomation.Text = "Information";
            this.tabInfomation.UseVisualStyleBackColor = true;
            // 
            // listViewDescription
            // 
            this.listViewDescription.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmSwID,
            this.clmModule});
            this.listViewDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewDescription.Location = new System.Drawing.Point(0, 220);
            this.listViewDescription.Name = "listViewDescription";
            this.listViewDescription.Size = new System.Drawing.Size(509, 191);
            this.listViewDescription.TabIndex = 4;
            this.listViewDescription.UseCompatibleStateImageBehavior = false;
            this.listViewDescription.View = System.Windows.Forms.View.Details;
            // 
            // clmSwID
            // 
            this.clmSwID.Text = "Switch ID";
            this.clmSwID.Width = 152;
            // 
            // clmModule
            // 
            this.clmModule.Text = "Module";
            this.clmModule.Width = 284;
            // 
            // Panel3
            // 
            this.Panel3.Controls.Add(this.txtDeviceDesc);
            this.Panel3.Controls.Add(this.labDevDesc);
            this.Panel3.Controls.Add(this.txtDeviceName);
            this.Panel3.Controls.Add(this.labDevName);
            this.Panel3.Controls.Add(this.txtFwVer2);
            this.Panel3.Controls.Add(this.labFwVer2);
            this.Panel3.Controls.Add(this.txtFpgaFwVer);
            this.Panel3.Controls.Add(this.labFPGAVer);
            this.Panel3.Controls.Add(this.txtFwVer);
            this.Panel3.Controls.Add(this.labFwVer);
            this.Panel3.Controls.Add(this.labModuleName);
            this.Panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel3.Location = new System.Drawing.Point(0, 0);
            this.Panel3.Name = "Panel3";
            this.Panel3.Size = new System.Drawing.Size(509, 220);
            this.Panel3.TabIndex = 5;
            // 
            // txtDeviceDesc
            // 
            this.txtDeviceDesc.Enabled = false;
            this.txtDeviceDesc.Location = new System.Drawing.Point(153, 162);
            this.txtDeviceDesc.Multiline = true;
            this.txtDeviceDesc.Name = "txtDeviceDesc";
            this.txtDeviceDesc.ReadOnly = true;
            this.txtDeviceDesc.Size = new System.Drawing.Size(247, 51);
            this.txtDeviceDesc.TabIndex = 39;
            // 
            // labDevDesc
            // 
            this.labDevDesc.Location = new System.Drawing.Point(12, 164);
            this.labDevDesc.Name = "labDevDesc";
            this.labDevDesc.Size = new System.Drawing.Size(120, 20);
            this.labDevDesc.TabIndex = 40;
            this.labDevDesc.Text = "Device Description :";
            // 
            // txtDeviceName
            // 
            this.txtDeviceName.Enabled = false;
            this.txtDeviceName.Location = new System.Drawing.Point(153, 130);
            this.txtDeviceName.Name = "txtDeviceName";
            this.txtDeviceName.ReadOnly = true;
            this.txtDeviceName.Size = new System.Drawing.Size(176, 22);
            this.txtDeviceName.TabIndex = 36;
            // 
            // labDevName
            // 
            this.labDevName.Location = new System.Drawing.Point(12, 133);
            this.labDevName.Name = "labDevName";
            this.labDevName.Size = new System.Drawing.Size(120, 20);
            this.labDevName.TabIndex = 41;
            this.labDevName.Text = "Device Name :";
            // 
            // txtFwVer2
            // 
            this.txtFwVer2.Enabled = false;
            this.txtFwVer2.Location = new System.Drawing.Point(153, 99);
            this.txtFwVer2.Name = "txtFwVer2";
            this.txtFwVer2.ReadOnly = true;
            this.txtFwVer2.Size = new System.Drawing.Size(176, 22);
            this.txtFwVer2.TabIndex = 30;
            // 
            // labFwVer2
            // 
            this.labFwVer2.Location = new System.Drawing.Point(12, 102);
            this.labFwVer2.Name = "labFwVer2";
            this.labFwVer2.Size = new System.Drawing.Size(120, 20);
            this.labFwVer2.TabIndex = 42;
            this.labFwVer2.Text = "Kernel Version :";
            // 
            // txtFpgaFwVer
            // 
            this.txtFpgaFwVer.Enabled = false;
            this.txtFpgaFwVer.Location = new System.Drawing.Point(153, 68);
            this.txtFpgaFwVer.Name = "txtFpgaFwVer";
            this.txtFpgaFwVer.ReadOnly = true;
            this.txtFpgaFwVer.Size = new System.Drawing.Size(176, 22);
            this.txtFpgaFwVer.TabIndex = 18;
            // 
            // labFPGAVer
            // 
            this.labFPGAVer.Location = new System.Drawing.Point(12, 71);
            this.labFPGAVer.Name = "labFPGAVer";
            this.labFPGAVer.Size = new System.Drawing.Size(120, 20);
            this.labFPGAVer.TabIndex = 43;
            this.labFPGAVer.Text = "FPGA Version :";
            // 
            // txtFwVer
            // 
            this.txtFwVer.Enabled = false;
            this.txtFwVer.Location = new System.Drawing.Point(153, 37);
            this.txtFwVer.Name = "txtFwVer";
            this.txtFwVer.ReadOnly = true;
            this.txtFwVer.Size = new System.Drawing.Size(176, 22);
            this.txtFwVer.TabIndex = 20;
            // 
            // labFwVer
            // 
            this.labFwVer.Location = new System.Drawing.Point(12, 40);
            this.labFwVer.Name = "labFwVer";
            this.labFwVer.Size = new System.Drawing.Size(120, 20);
            this.labFwVer.TabIndex = 44;
            this.labFwVer.Text = "Firmware Version :";
            // 
            // labModuleName
            // 
            this.labModuleName.Location = new System.Drawing.Point(12, 7);
            this.labModuleName.Name = "labModuleName";
            this.labModuleName.Size = new System.Drawing.Size(100, 20);
            this.labModuleName.TabIndex = 45;
            this.labModuleName.Text = "APAX-PAC";
            // 
            // tabNetSetting
            // 
            this.tabNetSetting.Controls.Add(this.panelFSVSetting);
            this.tabNetSetting.Controls.Add(this.panelNetworkSetting);
            this.tabNetSetting.Location = new System.Drawing.Point(4, 22);
            this.tabNetSetting.Name = "tabNetSetting";
            this.tabNetSetting.Size = new System.Drawing.Size(509, 411);
            this.tabNetSetting.TabIndex = 1;
            this.tabNetSetting.Text = "Network Setting";
            this.tabNetSetting.UseVisualStyleBackColor = true;
            // 
            // panelFSVSetting
            // 
            this.panelFSVSetting.Controls.Add(this.btnSetCommFSV);
            this.panelFSVSetting.Controls.Add(this.label2);
            this.panelFSVSetting.Controls.Add(this.chbxEnCommFSV);
            this.panelFSVSetting.Controls.Add(this.label1);
            this.panelFSVSetting.Controls.Add(this.txtCommFSVtimeout);
            this.panelFSVSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFSVSetting.Location = new System.Drawing.Point(0, 216);
            this.panelFSVSetting.Name = "panelFSVSetting";
            this.panelFSVSetting.Size = new System.Drawing.Size(509, 195);
            this.panelFSVSetting.TabIndex = 0;
            // 
            // btnSetCommFSV
            // 
            this.btnSetCommFSV.Location = new System.Drawing.Point(300, 50);
            this.btnSetCommFSV.Name = "btnSetCommFSV";
            this.btnSetCommFSV.Size = new System.Drawing.Size(72, 20);
            this.btnSetCommFSV.TabIndex = 15;
            this.btnSetCommFSV.Text = "Apply";
            this.btnSetCommFSV.Click += new System.EventHandler(this.btnSetCommFSV_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(237, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "Fail Safe Value Setting";
            // 
            // chbxEnCommFSV
            // 
            this.chbxEnCommFSV.Location = new System.Drawing.Point(16, 50);
            this.chbxEnCommFSV.Name = "chbxEnCommFSV";
            this.chbxEnCommFSV.Size = new System.Drawing.Size(263, 20);
            this.chbxEnCommFSV.TabIndex = 13;
            this.chbxEnCommFSV.Text = "Enable Communication FSV ";
            this.chbxEnCommFSV.CheckedChanged += new System.EventHandler(this.chbxEnCommFSV_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "Timout (sec)";
            // 
            // txtCommFSVtimeout
            // 
            this.txtCommFSVtimeout.Location = new System.Drawing.Point(112, 76);
            this.txtCommFSVtimeout.Name = "txtCommFSVtimeout";
            this.txtCommFSVtimeout.Size = new System.Drawing.Size(167, 22);
            this.txtCommFSVtimeout.TabIndex = 12;
            // 
            // panelNetworkSetting
            // 
            this.panelNetworkSetting.Controls.Add(this.label3);
            this.panelNetworkSetting.Controls.Add(this.txtDefaultGateway);
            this.panelNetworkSetting.Controls.Add(this.txtSubnetAddress);
            this.panelNetworkSetting.Controls.Add(this.txtIPAddress);
            this.panelNetworkSetting.Controls.Add(this.labMacAddress);
            this.panelNetworkSetting.Controls.Add(this.txtMacAddress);
            this.panelNetworkSetting.Controls.Add(this.labIPAddress);
            this.panelNetworkSetting.Controls.Add(this.labSubnetMask);
            this.panelNetworkSetting.Controls.Add(this.labDefaultGateway);
            this.panelNetworkSetting.Controls.Add(this.labHostIdle);
            this.panelNetworkSetting.Controls.Add(this.numHostIdle);
            this.panelNetworkSetting.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelNetworkSetting.Location = new System.Drawing.Point(0, 0);
            this.panelNetworkSetting.Name = "panelNetworkSetting";
            this.panelNetworkSetting.Size = new System.Drawing.Size(509, 216);
            this.panelNetworkSetting.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(237, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Network Setting";
            // 
            // txtDefaultGateway
            // 
            this.txtDefaultGateway.Enabled = false;
            this.txtDefaultGateway.Location = new System.Drawing.Point(112, 143);
            this.txtDefaultGateway.Name = "txtDefaultGateway";
            this.txtDefaultGateway.Size = new System.Drawing.Size(167, 22);
            this.txtDefaultGateway.TabIndex = 1;
            // 
            // txtSubnetAddress
            // 
            this.txtSubnetAddress.Enabled = false;
            this.txtSubnetAddress.Location = new System.Drawing.Point(112, 110);
            this.txtSubnetAddress.Name = "txtSubnetAddress";
            this.txtSubnetAddress.Size = new System.Drawing.Size(167, 22);
            this.txtSubnetAddress.TabIndex = 2;
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Enabled = false;
            this.txtIPAddress.Location = new System.Drawing.Point(112, 78);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(167, 22);
            this.txtIPAddress.TabIndex = 3;
            // 
            // labMacAddress
            // 
            this.labMacAddress.Location = new System.Drawing.Point(16, 52);
            this.labMacAddress.Name = "labMacAddress";
            this.labMacAddress.Size = new System.Drawing.Size(96, 16);
            this.labMacAddress.TabIndex = 4;
            this.labMacAddress.Text = "Mac Address";
            // 
            // txtMacAddress
            // 
            this.txtMacAddress.Enabled = false;
            this.txtMacAddress.Location = new System.Drawing.Point(112, 46);
            this.txtMacAddress.Name = "txtMacAddress";
            this.txtMacAddress.Size = new System.Drawing.Size(167, 22);
            this.txtMacAddress.TabIndex = 5;
            // 
            // labIPAddress
            // 
            this.labIPAddress.Location = new System.Drawing.Point(16, 84);
            this.labIPAddress.Name = "labIPAddress";
            this.labIPAddress.Size = new System.Drawing.Size(96, 16);
            this.labIPAddress.TabIndex = 6;
            this.labIPAddress.Text = "IP Address";
            // 
            // labSubnetMask
            // 
            this.labSubnetMask.Location = new System.Drawing.Point(16, 116);
            this.labSubnetMask.Name = "labSubnetMask";
            this.labSubnetMask.Size = new System.Drawing.Size(96, 16);
            this.labSubnetMask.TabIndex = 7;
            this.labSubnetMask.Text = "Subnet Mask";
            // 
            // labDefaultGateway
            // 
            this.labDefaultGateway.Location = new System.Drawing.Point(16, 148);
            this.labDefaultGateway.Name = "labDefaultGateway";
            this.labDefaultGateway.Size = new System.Drawing.Size(96, 16);
            this.labDefaultGateway.TabIndex = 8;
            this.labDefaultGateway.Text = "Default Gateway";
            // 
            // labHostIdle
            // 
            this.labHostIdle.Location = new System.Drawing.Point(16, 180);
            this.labHostIdle.Name = "labHostIdle";
            this.labHostIdle.Size = new System.Drawing.Size(96, 16);
            this.labHostIdle.TabIndex = 9;
            this.labHostIdle.Text = "Host Idle Timeout";
            // 
            // numHostIdle
            // 
            this.numHostIdle.Enabled = false;
            this.numHostIdle.Location = new System.Drawing.Point(112, 176);
            this.numHostIdle.Name = "numHostIdle";
            this.numHostIdle.Size = new System.Drawing.Size(167, 22);
            this.numHostIdle.TabIndex = 10;
            // 
            // tabAddressSetting
            // 
            this.tabAddressSetting.Controls.Add(this.gvAddress);
            this.tabAddressSetting.Controls.Add(this.Panel4);
            this.tabAddressSetting.Location = new System.Drawing.Point(4, 22);
            this.tabAddressSetting.Name = "tabAddressSetting";
            this.tabAddressSetting.Size = new System.Drawing.Size(509, 411);
            this.tabAddressSetting.TabIndex = 2;
            this.tabAddressSetting.Text = "Modbus Address Setting";
            this.tabAddressSetting.UseVisualStyleBackColor = true;
            // 
            // gvAddress
            // 
            this.gvAddress.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnSwitchID,
            this.ColumnModuleName,
            this.ColumnAddressType,
            this.ColumnStartAddress,
            this.ColumnLength});
            this.gvAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvAddress.GridLines = true;
            this.gvAddress.Location = new System.Drawing.Point(0, 51);
            this.gvAddress.Name = "gvAddress";
            this.gvAddress.Size = new System.Drawing.Size(509, 360);
            this.gvAddress.TabIndex = 3;
            this.gvAddress.UseCompatibleStateImageBehavior = false;
            this.gvAddress.View = System.Windows.Forms.View.Details;
            // 
            // ColumnSwitchID
            // 
            this.ColumnSwitchID.Text = "Switch ID";
            this.ColumnSwitchID.Width = 90;
            // 
            // ColumnModuleName
            // 
            this.ColumnModuleName.Text = "Module Name";
            this.ColumnModuleName.Width = 130;
            // 
            // ColumnAddressType
            // 
            this.ColumnAddressType.Text = "Address Type";
            this.ColumnAddressType.Width = 90;
            // 
            // ColumnStartAddress
            // 
            this.ColumnStartAddress.Text = "Start Address";
            this.ColumnStartAddress.Width = 90;
            // 
            // ColumnLength
            // 
            this.ColumnLength.Text = "Length";
            this.ColumnLength.Width = 80;
            // 
            // Panel4
            // 
            this.Panel4.Controls.Add(this.addressTypeValue);
            this.Panel4.Controls.Add(this.label4);
            this.Panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.Panel4.Location = new System.Drawing.Point(0, 0);
            this.Panel4.Name = "Panel4";
            this.Panel4.Size = new System.Drawing.Size(509, 51);
            this.Panel4.TabIndex = 4;
            // 
            // addressTypeValue
            // 
            this.addressTypeValue.Enabled = false;
            this.addressTypeValue.Location = new System.Drawing.Point(122, 16);
            this.addressTypeValue.Name = "addressTypeValue";
            this.addressTypeValue.Size = new System.Drawing.Size(151, 22);
            this.addressTypeValue.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(15, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Address Type";
            // 
            // tabSerial
            // 
            this.tabSerial.Controls.Add(this.tableLayoutPanel1);
            this.tabSerial.Location = new System.Drawing.Point(4, 22);
            this.tabSerial.Name = "tabSerial";
            this.tabSerial.Size = new System.Drawing.Size(509, 411);
            this.tabSerial.TabIndex = 3;
            this.tabSerial.Text = "Serial";
            this.tabSerial.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.Controls.Add(this.gbxComTcpPortSetting, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 375F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(509, 411);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // gbxComTcpPortSetting
            // 
            this.gbxComTcpPortSetting.Controls.Add(this.listViewComPortInfo);
            this.gbxComTcpPortSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxComTcpPortSetting.Location = new System.Drawing.Point(3, 3);
            this.gbxComTcpPortSetting.Name = "gbxComTcpPortSetting";
            this.gbxComTcpPortSetting.Size = new System.Drawing.Size(493, 369);
            this.gbxComTcpPortSetting.TabIndex = 1;
            this.gbxComTcpPortSetting.TabStop = false;
            this.gbxComTcpPortSetting.Text = "TCP Port Setting : ";
            // 
            // listViewComPortInfo
            // 
            this.listViewComPortInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmSwitchId,
            this.clmModuleName,
            this.clmComPort,
            this.clmTcpPortMap});
            this.listViewComPortInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewComPortInfo.FullRowSelect = true;
            this.listViewComPortInfo.GridLines = true;
            this.listViewComPortInfo.Location = new System.Drawing.Point(3, 18);
            this.listViewComPortInfo.Name = "listViewComPortInfo";
            this.listViewComPortInfo.Size = new System.Drawing.Size(487, 348);
            this.listViewComPortInfo.TabIndex = 10;
            this.listViewComPortInfo.UseCompatibleStateImageBehavior = false;
            this.listViewComPortInfo.View = System.Windows.Forms.View.Details;
            // 
            // clmSwitchId
            // 
            this.clmSwitchId.Text = "Switcvh ID";
            this.clmSwitchId.Width = 100;
            // 
            // clmModuleName
            // 
            this.clmModuleName.Text = "Module Name";
            this.clmModuleName.Width = 100;
            // 
            // clmComPort
            // 
            this.clmComPort.Text = "COM Port";
            this.clmComPort.Width = 100;
            // 
            // clmTcpPortMap
            // 
            this.clmTcpPortMap.Text = "TCP Port Mapping (1026~2000)";
            this.clmTcpPortMap.Width = 180;
            // 
            // Form_APAX_Coupler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 437);
            this.Controls.Add(this.splitContainer1);
            this.Menu = this.mainMenu1;
            this.Name = "Form_APAX_Coupler";
            this.Text = "APAX-Coupler";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabInfomation.ResumeLayout(false);
            this.Panel3.ResumeLayout(false);
            this.Panel3.PerformLayout();
            this.tabNetSetting.ResumeLayout(false);
            this.panelFSVSetting.ResumeLayout(false);
            this.panelFSVSetting.PerformLayout();
            this.panelNetworkSetting.ResumeLayout(false);
            this.panelNetworkSetting.PerformLayout();
            this.tabAddressSetting.ResumeLayout(false);
            this.Panel4.ResumeLayout(false);
            this.Panel4.PerformLayout();
            this.tabSerial.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.gbxComTcpPortSetting.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabInfomation;
        private System.Windows.Forms.ListView listViewDescription;
        private System.Windows.Forms.ColumnHeader clmSwID;
        private System.Windows.Forms.ColumnHeader clmModule;
        private System.Windows.Forms.Panel Panel3;
        private System.Windows.Forms.TextBox txtDeviceDesc;
        private System.Windows.Forms.Label labDevDesc;
        private System.Windows.Forms.TextBox txtDeviceName;
        private System.Windows.Forms.Label labDevName;
        private System.Windows.Forms.TextBox txtFwVer2;
        private System.Windows.Forms.Label labFwVer2;
        private System.Windows.Forms.TextBox txtFpgaFwVer;
        private System.Windows.Forms.Label labFPGAVer;
        private System.Windows.Forms.TextBox txtFwVer;
        private System.Windows.Forms.Label labFwVer;
        private System.Windows.Forms.Label labModuleName;
        private System.Windows.Forms.TabPage tabNetSetting;
        private System.Windows.Forms.Panel panelFSVSetting;
        private System.Windows.Forms.Button btnSetCommFSV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chbxEnCommFSV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCommFSVtimeout;
        private System.Windows.Forms.Panel panelNetworkSetting;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDefaultGateway;
        private System.Windows.Forms.TextBox txtSubnetAddress;
        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.Label labMacAddress;
        private System.Windows.Forms.TextBox txtMacAddress;
        private System.Windows.Forms.Label labIPAddress;
        private System.Windows.Forms.Label labSubnetMask;
        private System.Windows.Forms.Label labDefaultGateway;
        private System.Windows.Forms.Label labHostIdle;
        private System.Windows.Forms.TextBox numHostIdle;
        private System.Windows.Forms.TabPage tabAddressSetting;
        private System.Windows.Forms.ListView gvAddress;
        private System.Windows.Forms.ColumnHeader ColumnSwitchID;
        private System.Windows.Forms.ColumnHeader ColumnModuleName;
        private System.Windows.Forms.ColumnHeader ColumnAddressType;
        private System.Windows.Forms.ColumnHeader ColumnStartAddress;
        private System.Windows.Forms.ColumnHeader ColumnLength;
        private System.Windows.Forms.Panel Panel4;
        private System.Windows.Forms.TextBox addressTypeValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabSerial;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox gbxComTcpPortSetting;
        private System.Windows.Forms.ListView listViewComPortInfo;
        private System.Windows.Forms.ColumnHeader clmSwitchId;
        private System.Windows.Forms.ColumnHeader clmModuleName;
        private System.Windows.Forms.ColumnHeader clmComPort;
        private System.Windows.Forms.ColumnHeader clmTcpPortMap;
    }
}

