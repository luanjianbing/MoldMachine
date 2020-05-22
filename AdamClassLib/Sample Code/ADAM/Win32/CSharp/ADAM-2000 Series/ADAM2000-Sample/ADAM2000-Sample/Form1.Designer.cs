namespace ADAM2000_Sample
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gbComport = new System.Windows.Forms.GroupBox();
            this.searchLabel = new System.Windows.Forms.Label();
            this.bCoordinator = new System.Windows.Forms.Button();
            this.cbComportBuadrate = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbComport = new System.Windows.Forms.TextBox();
            this.bComport = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.gbDeviceTreeView = new System.Windows.Forms.GroupBox();
            this.bGetEndDevice = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.gbDeviceInfo = new System.Windows.Forms.GroupBox();
            this.tcDeviceInfo = new System.Windows.Forms.TabControl();
            this.tpInformation = new System.Windows.Forms.TabPage();
            this.gbxzigbee = new System.Windows.Forms.GroupBox();
            this.txtChannel = new System.Windows.Forms.TextBox();
            this.txtDataCycle = new System.Windows.Forms.TextBox();
            this.txtSlaveId = new System.Windows.Forms.TextBox();
            this.txtPanId = new System.Windows.Forms.TextBox();
            this.labSlaveId = new System.Windows.Forms.Label();
            this.txtPAddr = new System.Windows.Forms.TextBox();
            this.labPAddr = new System.Windows.Forms.Label();
            this.labDataCycle = new System.Windows.Forms.Label();
            this.txtSAddr = new System.Windows.Forms.TextBox();
            this.labSAddr = new System.Windows.Forms.Label();
            this.labChannel = new System.Windows.Forms.Label();
            this.labPanId = new System.Windows.Forms.Label();
            this.gbxFw = new System.Windows.Forms.GroupBox();
            this.txtFwVerZigBee = new System.Windows.Forms.TextBox();
            this.labKernal = new System.Windows.Forms.Label();
            this.labWireless = new System.Windows.Forms.Label();
            this.txtFwVerKernal = new System.Windows.Forms.TextBox();
            this.gbxDevice = new System.Windows.Forms.GroupBox();
            this.txtDeviceName = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.labDescription = new System.Windows.Forms.Label();
            this.labAdamDevice = new System.Windows.Forms.Label();
            this.tpDeviceStatus = new System.Windows.Forms.TabPage();
            this.gbxDeviceStatus = new System.Windows.Forms.GroupBox();
            this.txtModeStatus = new System.Windows.Forms.TextBox();
            this.txtPower = new System.Windows.Forms.TextBox();
            this.txtBattery = new System.Windows.Forms.TextBox();
            this.txtLink = new System.Windows.Forms.TextBox();
            this.labPowerDetection = new System.Windows.Forms.Label();
            this.labBatteryStatus = new System.Windows.Forms.Label();
            this.labLinkQuality = new System.Windows.Forms.Label();
            this.labModeStatus = new System.Windows.Forms.Label();
            this.tpChannelInfo = new System.Windows.Forms.TabPage();
            this.lPollingTimes = new System.Windows.Forms.Label();
            this.bPolling = new System.Windows.Forms.Button();
            this.gbxChannelInfo = new System.Windows.Forms.GroupBox();
            this.listViewChannelInfo = new System.Windows.Forms.ListView();
            this.clmChInfoType = new System.Windows.Forms.ColumnHeader();
            this.clmChInfoCh = new System.Windows.Forms.ColumnHeader();
            this.clmChInfoModbusAddr = new System.Windows.Forms.ColumnHeader();
            this.clmChInfoValue = new System.Windows.Forms.ColumnHeader();
            this.clmChInfoMode = new System.Windows.Forms.ColumnHeader();
            this.clmChInfoDataCycle = new System.Windows.Forms.ColumnHeader();
            this.clmChInfoLQI = new System.Windows.Forms.ColumnHeader();
            this.clmChInfoLastUpdateTime = new System.Windows.Forms.ColumnHeader();
            this.tpChannelStatus = new System.Windows.Forms.TabPage();
            this.bClearLvChStatus = new System.Windows.Forms.Button();
            this.bGetChStatus = new System.Windows.Forms.Button();
            this.gbxChInfo = new System.Windows.Forms.GroupBox();
            this.listViewChStatus = new System.Windows.Forms.ListView();
            this.clmType = new System.Windows.Forms.ColumnHeader();
            this.clmCh = new System.Windows.Forms.ColumnHeader();
            this.clmModbusAddr = new System.Windows.Forms.ColumnHeader();
            this.clmValue = new System.Windows.Forms.ColumnHeader();
            this.clmChStatus = new System.Windows.Forms.ColumnHeader();
            this.tpSetRange = new System.Windows.Forms.TabPage();
            this.bGetConfig = new System.Windows.Forms.Button();
            this.bSetRange = new System.Windows.Forms.Button();
            this.gbxChEnable = new System.Windows.Forms.GroupBox();
            this.ckCH5 = new System.Windows.Forms.CheckBox();
            this.ckCH4 = new System.Windows.Forms.CheckBox();
            this.ckCH3 = new System.Windows.Forms.CheckBox();
            this.ckCH2 = new System.Windows.Forms.CheckBox();
            this.ckCH1 = new System.Windows.Forms.CheckBox();
            this.ckCH0 = new System.Windows.Forms.CheckBox();
            this.gbxSetRangeOptionalFunction = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cbUpdateRate = new System.Windows.Forms.ComboBox();
            this.cbBurnOutPresent = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.cbBurnOutEnable = new System.Windows.Forms.ComboBox();
            this.gbxChRangeType = new System.Windows.Forms.GroupBox();
            this.cbCh0 = new System.Windows.Forms.ComboBox();
            this.cbCh5 = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cbCh4 = new System.Windows.Forms.ComboBox();
            this.cbCh2 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbCh3 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbCh1 = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tpDeviceList = new System.Windows.Forms.TabPage();
            this.bDeviceListRefresh = new System.Windows.Forms.Button();
            this.gbxDeviceList = new System.Windows.Forms.GroupBox();
            this.listViewDeviceList = new System.Windows.Forms.ListView();
            this.clmListDeviceName = new System.Windows.Forms.ColumnHeader();
            this.clmListSlaveId = new System.Windows.Forms.ColumnHeader();
            this.clmListLQI = new System.Windows.Forms.ColumnHeader();
            this.clmListInactiveTime = new System.Windows.Forms.ColumnHeader();
            this.clmListCycleTime = new System.Windows.Forms.ColumnHeader();
            this.clmListShortAddr = new System.Windows.Forms.ColumnHeader();
            this.clmListParentAddr = new System.Windows.Forms.ColumnHeader();
            this.clmListStatus = new System.Windows.Forms.ColumnHeader();
            this.timerSearchCoordinator = new System.Windows.Forms.Timer(this.components);
            this.timerPollingData = new System.Windows.Forms.Timer(this.components);
            this.gbComport.SuspendLayout();
            this.gbDeviceTreeView.SuspendLayout();
            this.gbDeviceInfo.SuspendLayout();
            this.tcDeviceInfo.SuspendLayout();
            this.tpInformation.SuspendLayout();
            this.gbxzigbee.SuspendLayout();
            this.gbxFw.SuspendLayout();
            this.gbxDevice.SuspendLayout();
            this.tpDeviceStatus.SuspendLayout();
            this.gbxDeviceStatus.SuspendLayout();
            this.tpChannelInfo.SuspendLayout();
            this.gbxChannelInfo.SuspendLayout();
            this.tpChannelStatus.SuspendLayout();
            this.gbxChInfo.SuspendLayout();
            this.tpSetRange.SuspendLayout();
            this.gbxChEnable.SuspendLayout();
            this.gbxSetRangeOptionalFunction.SuspendLayout();
            this.gbxChRangeType.SuspendLayout();
            this.tpDeviceList.SuspendLayout();
            this.gbxDeviceList.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbComport
            // 
            this.gbComport.Controls.Add(this.searchLabel);
            this.gbComport.Controls.Add(this.bCoordinator);
            this.gbComport.Controls.Add(this.cbComportBuadrate);
            this.gbComport.Controls.Add(this.label1);
            this.gbComport.Controls.Add(this.tbComport);
            this.gbComport.Controls.Add(this.bComport);
            this.gbComport.Controls.Add(this.label2);
            this.gbComport.Location = new System.Drawing.Point(2, 3);
            this.gbComport.Name = "gbComport";
            this.gbComport.Size = new System.Drawing.Size(180, 159);
            this.gbComport.TabIndex = 7;
            this.gbComport.TabStop = false;
            this.gbComport.Text = "Comport";
            // 
            // searchLabel
            // 
            this.searchLabel.AutoSize = true;
            this.searchLabel.Location = new System.Drawing.Point(13, 137);
            this.searchLabel.Name = "searchLabel";
            this.searchLabel.Size = new System.Drawing.Size(36, 12);
            this.searchLabel.TabIndex = 9;
            this.searchLabel.Text = "Search";
            // 
            // bCoordinator
            // 
            this.bCoordinator.Location = new System.Drawing.Point(9, 103);
            this.bCoordinator.Name = "bCoordinator";
            this.bCoordinator.Size = new System.Drawing.Size(154, 23);
            this.bCoordinator.TabIndex = 8;
            this.bCoordinator.Text = "Search Coordinator";
            this.bCoordinator.UseVisualStyleBackColor = true;
            this.bCoordinator.Click += new System.EventHandler(this.bCoordinator_Click);
            // 
            // cbComportBuadrate
            // 
            this.cbComportBuadrate.FormattingEnabled = true;
            this.cbComportBuadrate.Items.AddRange(new object[] {
            "9600",
            "115200"});
            this.cbComportBuadrate.Location = new System.Drawing.Point(63, 43);
            this.cbComportBuadrate.Name = "cbComportBuadrate";
            this.cbComportBuadrate.Size = new System.Drawing.Size(99, 20);
            this.cbComportBuadrate.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Number";
            // 
            // tbComport
            // 
            this.tbComport.Location = new System.Drawing.Point(63, 15);
            this.tbComport.Name = "tbComport";
            this.tbComport.Size = new System.Drawing.Size(99, 22);
            this.tbComport.TabIndex = 0;
            this.tbComport.Text = "1";
            // 
            // bComport
            // 
            this.bComport.Location = new System.Drawing.Point(9, 71);
            this.bComport.Name = "bComport";
            this.bComport.Size = new System.Drawing.Size(153, 23);
            this.bComport.TabIndex = 1;
            this.bComport.Text = "Open";
            this.bComport.UseVisualStyleBackColor = true;
            this.bComport.Click += new System.EventHandler(this.bComport_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Buadrate";
            // 
            // gbDeviceTreeView
            // 
            this.gbDeviceTreeView.Controls.Add(this.bGetEndDevice);
            this.gbDeviceTreeView.Controls.Add(this.treeView1);
            this.gbDeviceTreeView.Location = new System.Drawing.Point(2, 168);
            this.gbDeviceTreeView.Name = "gbDeviceTreeView";
            this.gbDeviceTreeView.Size = new System.Drawing.Size(182, 290);
            this.gbDeviceTreeView.TabIndex = 8;
            this.gbDeviceTreeView.TabStop = false;
            this.gbDeviceTreeView.Text = "Device Tree View";
            // 
            // bGetEndDevice
            // 
            this.bGetEndDevice.Location = new System.Drawing.Point(9, 261);
            this.bGetEndDevice.Name = "bGetEndDevice";
            this.bGetEndDevice.Size = new System.Drawing.Size(153, 23);
            this.bGetEndDevice.TabIndex = 1;
            this.bGetEndDevice.Text = "Get End Device";
            this.bGetEndDevice.UseVisualStyleBackColor = true;
            this.bGetEndDevice.Click += new System.EventHandler(this.bGetEndDevice_Click);
            // 
            // treeView1
            // 
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(3, 18);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(175, 239);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Adam2000.ico");
            this.imageList1.Images.SetKeyName(1, "LIGHTON.ICO");
            this.imageList1.Images.SetKeyName(2, "LIGHTOFF.ICO");
            // 
            // gbDeviceInfo
            // 
            this.gbDeviceInfo.Controls.Add(this.tcDeviceInfo);
            this.gbDeviceInfo.Location = new System.Drawing.Point(186, 3);
            this.gbDeviceInfo.Name = "gbDeviceInfo";
            this.gbDeviceInfo.Size = new System.Drawing.Size(604, 454);
            this.gbDeviceInfo.TabIndex = 9;
            this.gbDeviceInfo.TabStop = false;
            this.gbDeviceInfo.Text = "Device Info";
            // 
            // tcDeviceInfo
            // 
            this.tcDeviceInfo.Controls.Add(this.tpInformation);
            this.tcDeviceInfo.Controls.Add(this.tpDeviceStatus);
            this.tcDeviceInfo.Controls.Add(this.tpChannelInfo);
            this.tcDeviceInfo.Controls.Add(this.tpChannelStatus);
            this.tcDeviceInfo.Controls.Add(this.tpSetRange);
            this.tcDeviceInfo.Controls.Add(this.tpDeviceList);
            this.tcDeviceInfo.ImageList = this.imageList1;
            this.tcDeviceInfo.Location = new System.Drawing.Point(6, 18);
            this.tcDeviceInfo.Name = "tcDeviceInfo";
            this.tcDeviceInfo.SelectedIndex = 0;
            this.tcDeviceInfo.Size = new System.Drawing.Size(593, 429);
            this.tcDeviceInfo.TabIndex = 0;
            this.tcDeviceInfo.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tcDeviceInfo_Selecting);
            this.tcDeviceInfo.SelectedIndexChanged += new System.EventHandler(this.tcDeviceInfo_SelectedIndexChanged);
            // 
            // tpInformation
            // 
            this.tpInformation.BackColor = System.Drawing.Color.Transparent;
            this.tpInformation.Controls.Add(this.gbxzigbee);
            this.tpInformation.Controls.Add(this.gbxFw);
            this.tpInformation.Controls.Add(this.gbxDevice);
            this.tpInformation.Location = new System.Drawing.Point(4, 23);
            this.tpInformation.Name = "tpInformation";
            this.tpInformation.Padding = new System.Windows.Forms.Padding(3);
            this.tpInformation.Size = new System.Drawing.Size(585, 402);
            this.tpInformation.TabIndex = 0;
            this.tpInformation.Text = "Information";
            this.tpInformation.UseVisualStyleBackColor = true;
            // 
            // gbxzigbee
            // 
            this.gbxzigbee.BackColor = System.Drawing.Color.Transparent;
            this.gbxzigbee.Controls.Add(this.txtChannel);
            this.gbxzigbee.Controls.Add(this.txtDataCycle);
            this.gbxzigbee.Controls.Add(this.txtSlaveId);
            this.gbxzigbee.Controls.Add(this.txtPanId);
            this.gbxzigbee.Controls.Add(this.labSlaveId);
            this.gbxzigbee.Controls.Add(this.txtPAddr);
            this.gbxzigbee.Controls.Add(this.labPAddr);
            this.gbxzigbee.Controls.Add(this.labDataCycle);
            this.gbxzigbee.Controls.Add(this.txtSAddr);
            this.gbxzigbee.Controls.Add(this.labSAddr);
            this.gbxzigbee.Controls.Add(this.labChannel);
            this.gbxzigbee.Controls.Add(this.labPanId);
            this.gbxzigbee.Location = new System.Drawing.Point(6, 179);
            this.gbxzigbee.Name = "gbxzigbee";
            this.gbxzigbee.Size = new System.Drawing.Size(560, 169);
            this.gbxzigbee.TabIndex = 27;
            this.gbxzigbee.TabStop = false;
            this.gbxzigbee.Text = "Zigbee Information (for Normal mode setting)";
            // 
            // txtChannel
            // 
            this.txtChannel.Location = new System.Drawing.Point(382, 16);
            this.txtChannel.Name = "txtChannel";
            this.txtChannel.ReadOnly = true;
            this.txtChannel.Size = new System.Drawing.Size(70, 22);
            this.txtChannel.TabIndex = 100;
            // 
            // txtDataCycle
            // 
            this.txtDataCycle.Location = new System.Drawing.Point(381, 107);
            this.txtDataCycle.Name = "txtDataCycle";
            this.txtDataCycle.ReadOnly = true;
            this.txtDataCycle.Size = new System.Drawing.Size(71, 22);
            this.txtDataCycle.TabIndex = 99;
            // 
            // txtSlaveId
            // 
            this.txtSlaveId.Location = new System.Drawing.Point(127, 44);
            this.txtSlaveId.Name = "txtSlaveId";
            this.txtSlaveId.ReadOnly = true;
            this.txtSlaveId.Size = new System.Drawing.Size(70, 22);
            this.txtSlaveId.TabIndex = 97;
            // 
            // txtPanId
            // 
            this.txtPanId.Location = new System.Drawing.Point(127, 15);
            this.txtPanId.Name = "txtPanId";
            this.txtPanId.ReadOnly = true;
            this.txtPanId.Size = new System.Drawing.Size(70, 22);
            this.txtPanId.TabIndex = 96;
            // 
            // labSlaveId
            // 
            this.labSlaveId.AutoSize = true;
            this.labSlaveId.Location = new System.Drawing.Point(7, 47);
            this.labSlaveId.Name = "labSlaveId";
            this.labSlaveId.Size = new System.Drawing.Size(104, 12);
            this.labSlaveId.TabIndex = 94;
            this.labSlaveId.Text = "Slave ID (245 ~ 248)";
            // 
            // txtPAddr
            // 
            this.txtPAddr.Location = new System.Drawing.Point(127, 72);
            this.txtPAddr.Name = "txtPAddr";
            this.txtPAddr.ReadOnly = true;
            this.txtPAddr.Size = new System.Drawing.Size(70, 22);
            this.txtPAddr.TabIndex = 93;
            // 
            // labPAddr
            // 
            this.labPAddr.AutoSize = true;
            this.labPAddr.Location = new System.Drawing.Point(7, 75);
            this.labPAddr.Name = "labPAddr";
            this.labPAddr.Size = new System.Drawing.Size(108, 12);
            this.labPAddr.TabIndex = 92;
            this.labPAddr.Text = "Parent Address (HEX)";
            // 
            // labDataCycle
            // 
            this.labDataCycle.AutoSize = true;
            this.labDataCycle.Location = new System.Drawing.Point(7, 110);
            this.labDataCycle.Name = "labDataCycle";
            this.labDataCycle.Size = new System.Drawing.Size(368, 12);
            this.labDataCycle.TabIndex = 85;
            this.labDataCycle.Text = "Data Cycle (1 ~ 86400s sec) (Note:This value only valid under Normal Mode)";
            // 
            // txtSAddr
            // 
            this.txtSAddr.Location = new System.Drawing.Point(382, 72);
            this.txtSAddr.Name = "txtSAddr";
            this.txtSAddr.ReadOnly = true;
            this.txtSAddr.Size = new System.Drawing.Size(70, 22);
            this.txtSAddr.TabIndex = 79;
            // 
            // labSAddr
            // 
            this.labSAddr.AutoSize = true;
            this.labSAddr.Location = new System.Drawing.Point(221, 75);
            this.labSAddr.Name = "labSAddr";
            this.labSAddr.Size = new System.Drawing.Size(104, 12);
            this.labSAddr.TabIndex = 76;
            this.labSAddr.Text = "Short Address (HEX)";
            // 
            // labChannel
            // 
            this.labChannel.AutoSize = true;
            this.labChannel.Location = new System.Drawing.Point(221, 19);
            this.labChannel.Name = "labChannel";
            this.labChannel.Size = new System.Drawing.Size(108, 12);
            this.labChannel.TabIndex = 62;
            this.labChannel.Text = "RF Channel (11 ~ 26)";
            // 
            // labPanId
            // 
            this.labPanId.AutoSize = true;
            this.labPanId.Location = new System.Drawing.Point(7, 19);
            this.labPanId.Name = "labPanId";
            this.labPanId.Size = new System.Drawing.Size(101, 12);
            this.labPanId.TabIndex = 60;
            this.labPanId.Text = "PAN ID (1 ~ 16300)";
            // 
            // gbxFw
            // 
            this.gbxFw.Controls.Add(this.txtFwVerZigBee);
            this.gbxFw.Controls.Add(this.labKernal);
            this.gbxFw.Controls.Add(this.labWireless);
            this.gbxFw.Controls.Add(this.txtFwVerKernal);
            this.gbxFw.Location = new System.Drawing.Point(6, 97);
            this.gbxFw.Name = "gbxFw";
            this.gbxFw.Size = new System.Drawing.Size(560, 76);
            this.gbxFw.TabIndex = 26;
            this.gbxFw.TabStop = false;
            this.gbxFw.Text = "Firmware Version";
            // 
            // txtFwVerZigBee
            // 
            this.txtFwVerZigBee.Location = new System.Drawing.Point(95, 46);
            this.txtFwVerZigBee.Name = "txtFwVerZigBee";
            this.txtFwVerZigBee.ReadOnly = true;
            this.txtFwVerZigBee.Size = new System.Drawing.Size(459, 22);
            this.txtFwVerZigBee.TabIndex = 3;
            // 
            // labKernal
            // 
            this.labKernal.AutoSize = true;
            this.labKernal.Location = new System.Drawing.Point(6, 20);
            this.labKernal.Name = "labKernal";
            this.labKernal.Size = new System.Drawing.Size(36, 12);
            this.labKernal.TabIndex = 0;
            this.labKernal.Text = "Kernel";
            // 
            // labWireless
            // 
            this.labWireless.AutoSize = true;
            this.labWireless.Location = new System.Drawing.Point(6, 49);
            this.labWireless.Name = "labWireless";
            this.labWireless.Size = new System.Drawing.Size(83, 12);
            this.labWireless.TabIndex = 0;
            this.labWireless.Text = "Wireless Module";
            // 
            // txtFwVerKernal
            // 
            this.txtFwVerKernal.Location = new System.Drawing.Point(95, 17);
            this.txtFwVerKernal.Name = "txtFwVerKernal";
            this.txtFwVerKernal.ReadOnly = true;
            this.txtFwVerKernal.Size = new System.Drawing.Size(459, 22);
            this.txtFwVerKernal.TabIndex = 1;
            // 
            // gbxDevice
            // 
            this.gbxDevice.Controls.Add(this.txtDeviceName);
            this.gbxDevice.Controls.Add(this.txtDescription);
            this.gbxDevice.Controls.Add(this.labDescription);
            this.gbxDevice.Controls.Add(this.labAdamDevice);
            this.gbxDevice.Location = new System.Drawing.Point(6, 12);
            this.gbxDevice.Name = "gbxDevice";
            this.gbxDevice.Size = new System.Drawing.Size(560, 74);
            this.gbxDevice.TabIndex = 25;
            this.gbxDevice.TabStop = false;
            this.gbxDevice.Text = "Device";
            // 
            // txtDeviceName
            // 
            this.txtDeviceName.Location = new System.Drawing.Point(95, 16);
            this.txtDeviceName.Name = "txtDeviceName";
            this.txtDeviceName.ReadOnly = true;
            this.txtDeviceName.Size = new System.Drawing.Size(459, 22);
            this.txtDeviceName.TabIndex = 87;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(95, 44);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(459, 22);
            this.txtDescription.TabIndex = 85;
            // 
            // labDescription
            // 
            this.labDescription.AutoSize = true;
            this.labDescription.Location = new System.Drawing.Point(6, 47);
            this.labDescription.Name = "labDescription";
            this.labDescription.Size = new System.Drawing.Size(58, 12);
            this.labDescription.TabIndex = 4;
            this.labDescription.Text = "Description";
            // 
            // labAdamDevice
            // 
            this.labAdamDevice.AutoSize = true;
            this.labAdamDevice.Location = new System.Drawing.Point(6, 19);
            this.labAdamDevice.Name = "labAdamDevice";
            this.labAdamDevice.Size = new System.Drawing.Size(32, 12);
            this.labAdamDevice.TabIndex = 4;
            this.labAdamDevice.Text = "Name";
            // 
            // tpDeviceStatus
            // 
            this.tpDeviceStatus.Controls.Add(this.gbxDeviceStatus);
            this.tpDeviceStatus.Location = new System.Drawing.Point(4, 23);
            this.tpDeviceStatus.Name = "tpDeviceStatus";
            this.tpDeviceStatus.Size = new System.Drawing.Size(585, 402);
            this.tpDeviceStatus.TabIndex = 2;
            this.tpDeviceStatus.Text = "Device Status";
            this.tpDeviceStatus.UseVisualStyleBackColor = true;
            // 
            // gbxDeviceStatus
            // 
            this.gbxDeviceStatus.Controls.Add(this.txtModeStatus);
            this.gbxDeviceStatus.Controls.Add(this.txtPower);
            this.gbxDeviceStatus.Controls.Add(this.txtBattery);
            this.gbxDeviceStatus.Controls.Add(this.txtLink);
            this.gbxDeviceStatus.Controls.Add(this.labPowerDetection);
            this.gbxDeviceStatus.Controls.Add(this.labBatteryStatus);
            this.gbxDeviceStatus.Controls.Add(this.labLinkQuality);
            this.gbxDeviceStatus.Controls.Add(this.labModeStatus);
            this.gbxDeviceStatus.Location = new System.Drawing.Point(11, 14);
            this.gbxDeviceStatus.Name = "gbxDeviceStatus";
            this.gbxDeviceStatus.Size = new System.Drawing.Size(358, 134);
            this.gbxDeviceStatus.TabIndex = 1;
            this.gbxDeviceStatus.TabStop = false;
            this.gbxDeviceStatus.Text = "Data";
            // 
            // txtModeStatus
            // 
            this.txtModeStatus.Location = new System.Drawing.Point(113, 17);
            this.txtModeStatus.Name = "txtModeStatus";
            this.txtModeStatus.ReadOnly = true;
            this.txtModeStatus.Size = new System.Drawing.Size(184, 22);
            this.txtModeStatus.TabIndex = 8;
            // 
            // txtPower
            // 
            this.txtPower.Location = new System.Drawing.Point(113, 101);
            this.txtPower.Name = "txtPower";
            this.txtPower.ReadOnly = true;
            this.txtPower.Size = new System.Drawing.Size(184, 22);
            this.txtPower.TabIndex = 7;
            // 
            // txtBattery
            // 
            this.txtBattery.Location = new System.Drawing.Point(113, 73);
            this.txtBattery.Name = "txtBattery";
            this.txtBattery.ReadOnly = true;
            this.txtBattery.Size = new System.Drawing.Size(184, 22);
            this.txtBattery.TabIndex = 6;
            // 
            // txtLink
            // 
            this.txtLink.Location = new System.Drawing.Point(113, 45);
            this.txtLink.Name = "txtLink";
            this.txtLink.ReadOnly = true;
            this.txtLink.Size = new System.Drawing.Size(184, 22);
            this.txtLink.TabIndex = 5;
            // 
            // labPowerDetection
            // 
            this.labPowerDetection.AutoSize = true;
            this.labPowerDetection.Location = new System.Drawing.Point(7, 104);
            this.labPowerDetection.Name = "labPowerDetection";
            this.labPowerDetection.Size = new System.Drawing.Size(76, 12);
            this.labPowerDetection.TabIndex = 3;
            this.labPowerDetection.Text = "External power";
            // 
            // labBatteryStatus
            // 
            this.labBatteryStatus.AutoSize = true;
            this.labBatteryStatus.Location = new System.Drawing.Point(7, 76);
            this.labBatteryStatus.Name = "labBatteryStatus";
            this.labBatteryStatus.Size = new System.Drawing.Size(69, 12);
            this.labBatteryStatus.TabIndex = 2;
            this.labBatteryStatus.Text = "Battery Status";
            // 
            // labLinkQuality
            // 
            this.labLinkQuality.AutoSize = true;
            this.labLinkQuality.Location = new System.Drawing.Point(6, 48);
            this.labLinkQuality.Name = "labLinkQuality";
            this.labLinkQuality.Size = new System.Drawing.Size(64, 12);
            this.labLinkQuality.TabIndex = 1;
            this.labLinkQuality.Text = "Link Quality";
            // 
            // labModeStatus
            // 
            this.labModeStatus.AutoSize = true;
            this.labModeStatus.Location = new System.Drawing.Point(6, 20);
            this.labModeStatus.Name = "labModeStatus";
            this.labModeStatus.Size = new System.Drawing.Size(62, 12);
            this.labModeStatus.TabIndex = 0;
            this.labModeStatus.Text = "Mode Status";
            // 
            // tpChannelInfo
            // 
            this.tpChannelInfo.Controls.Add(this.lPollingTimes);
            this.tpChannelInfo.Controls.Add(this.bPolling);
            this.tpChannelInfo.Controls.Add(this.gbxChannelInfo);
            this.tpChannelInfo.Location = new System.Drawing.Point(4, 23);
            this.tpChannelInfo.Name = "tpChannelInfo";
            this.tpChannelInfo.Size = new System.Drawing.Size(585, 402);
            this.tpChannelInfo.TabIndex = 4;
            this.tpChannelInfo.Text = "Channel Information";
            this.tpChannelInfo.UseVisualStyleBackColor = true;
            // 
            // lPollingTimes
            // 
            this.lPollingTimes.AutoSize = true;
            this.lPollingTimes.Location = new System.Drawing.Point(158, 16);
            this.lPollingTimes.Name = "lPollingTimes";
            this.lPollingTimes.Size = new System.Drawing.Size(78, 12);
            this.lPollingTimes.TabIndex = 15;
            this.lPollingTimes.Text = "Polling Times : ";
            // 
            // bPolling
            // 
            this.bPolling.Location = new System.Drawing.Point(9, 11);
            this.bPolling.Name = "bPolling";
            this.bPolling.Size = new System.Drawing.Size(93, 23);
            this.bPolling.TabIndex = 14;
            this.bPolling.Text = "Polling";
            this.bPolling.UseVisualStyleBackColor = true;
            this.bPolling.Click += new System.EventHandler(this.bPolling_Click);
            // 
            // gbxChannelInfo
            // 
            this.gbxChannelInfo.Controls.Add(this.listViewChannelInfo);
            this.gbxChannelInfo.Location = new System.Drawing.Point(6, 47);
            this.gbxChannelInfo.Name = "gbxChannelInfo";
            this.gbxChannelInfo.Size = new System.Drawing.Size(574, 222);
            this.gbxChannelInfo.TabIndex = 0;
            this.gbxChannelInfo.TabStop = false;
            this.gbxChannelInfo.Text = "Channel Information";
            // 
            // listViewChannelInfo
            // 
            this.listViewChannelInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmChInfoType,
            this.clmChInfoCh,
            this.clmChInfoModbusAddr,
            this.clmChInfoValue,
            this.clmChInfoMode,
            this.clmChInfoDataCycle,
            this.clmChInfoLQI,
            this.clmChInfoLastUpdateTime});
            this.listViewChannelInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewChannelInfo.Location = new System.Drawing.Point(3, 18);
            this.listViewChannelInfo.Name = "listViewChannelInfo";
            this.listViewChannelInfo.Size = new System.Drawing.Size(568, 201);
            this.listViewChannelInfo.TabIndex = 0;
            this.listViewChannelInfo.UseCompatibleStateImageBehavior = false;
            this.listViewChannelInfo.View = System.Windows.Forms.View.Details;
            // 
            // clmChInfoType
            // 
            this.clmChInfoType.Text = "Type";
            // 
            // clmChInfoCh
            // 
            this.clmChInfoCh.Text = "Ch";
            this.clmChInfoCh.Width = 35;
            // 
            // clmChInfoModbusAddr
            // 
            this.clmChInfoModbusAddr.Text = "Modbus Addr";
            this.clmChInfoModbusAddr.Width = 80;
            // 
            // clmChInfoValue
            // 
            this.clmChInfoValue.Text = "Value";
            // 
            // clmChInfoMode
            // 
            this.clmChInfoMode.Text = "Mode";
            this.clmChInfoMode.Width = 80;
            // 
            // clmChInfoDataCycle
            // 
            this.clmChInfoDataCycle.Text = "Data Cycle";
            this.clmChInfoDataCycle.Width = 65;
            // 
            // clmChInfoLQI
            // 
            this.clmChInfoLQI.Text = "LQI";
            this.clmChInfoLQI.Width = 45;
            // 
            // clmChInfoLastUpdateTime
            // 
            this.clmChInfoLastUpdateTime.Text = "Last Update Time";
            this.clmChInfoLastUpdateTime.Width = 137;
            // 
            // tpChannelStatus
            // 
            this.tpChannelStatus.Controls.Add(this.bClearLvChStatus);
            this.tpChannelStatus.Controls.Add(this.bGetChStatus);
            this.tpChannelStatus.Controls.Add(this.gbxChInfo);
            this.tpChannelStatus.Location = new System.Drawing.Point(4, 23);
            this.tpChannelStatus.Name = "tpChannelStatus";
            this.tpChannelStatus.Padding = new System.Windows.Forms.Padding(3);
            this.tpChannelStatus.Size = new System.Drawing.Size(585, 402);
            this.tpChannelStatus.TabIndex = 1;
            this.tpChannelStatus.Text = "Channel Status (AI Module)";
            this.tpChannelStatus.UseVisualStyleBackColor = true;
            // 
            // bClearLvChStatus
            // 
            this.bClearLvChStatus.Location = new System.Drawing.Point(465, 65);
            this.bClearLvChStatus.Name = "bClearLvChStatus";
            this.bClearLvChStatus.Size = new System.Drawing.Size(102, 23);
            this.bClearLvChStatus.TabIndex = 11;
            this.bClearLvChStatus.Text = "Clear";
            this.bClearLvChStatus.UseVisualStyleBackColor = true;
            this.bClearLvChStatus.Click += new System.EventHandler(this.bClearLvChStatus_Click);
            // 
            // bGetChStatus
            // 
            this.bGetChStatus.Location = new System.Drawing.Point(465, 31);
            this.bGetChStatus.Name = "bGetChStatus";
            this.bGetChStatus.Size = new System.Drawing.Size(102, 23);
            this.bGetChStatus.TabIndex = 10;
            this.bGetChStatus.Text = "Get Channel Status";
            this.bGetChStatus.UseVisualStyleBackColor = true;
            this.bGetChStatus.Click += new System.EventHandler(this.bGetChStatus_Click);
            // 
            // gbxChInfo
            // 
            this.gbxChInfo.Controls.Add(this.listViewChStatus);
            this.gbxChInfo.Location = new System.Drawing.Point(6, 11);
            this.gbxChInfo.Name = "gbxChInfo";
            this.gbxChInfo.Size = new System.Drawing.Size(455, 178);
            this.gbxChInfo.TabIndex = 0;
            this.gbxChInfo.TabStop = false;
            this.gbxChInfo.Text = "Channel Status";
            // 
            // listViewChStatus
            // 
            this.listViewChStatus.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmType,
            this.clmCh,
            this.clmModbusAddr,
            this.clmValue,
            this.clmChStatus});
            this.listViewChStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewChStatus.Location = new System.Drawing.Point(3, 18);
            this.listViewChStatus.Name = "listViewChStatus";
            this.listViewChStatus.Size = new System.Drawing.Size(449, 157);
            this.listViewChStatus.TabIndex = 0;
            this.listViewChStatus.UseCompatibleStateImageBehavior = false;
            this.listViewChStatus.View = System.Windows.Forms.View.Details;
            // 
            // clmType
            // 
            this.clmType.Text = "Type";
            this.clmType.Width = 50;
            // 
            // clmCh
            // 
            this.clmCh.Text = "Ch";
            this.clmCh.Width = 40;
            // 
            // clmModbusAddr
            // 
            this.clmModbusAddr.Text = "Modbus Addr";
            this.clmModbusAddr.Width = 80;
            // 
            // clmValue
            // 
            this.clmValue.Text = "Value";
            this.clmValue.Width = 70;
            // 
            // clmChStatus
            // 
            this.clmChStatus.Text = "Ch Status";
            this.clmChStatus.Width = 200;
            // 
            // tpSetRange
            // 
            this.tpSetRange.Controls.Add(this.bGetConfig);
            this.tpSetRange.Controls.Add(this.bSetRange);
            this.tpSetRange.Controls.Add(this.gbxChEnable);
            this.tpSetRange.Controls.Add(this.gbxSetRangeOptionalFunction);
            this.tpSetRange.Controls.Add(this.gbxChRangeType);
            this.tpSetRange.Location = new System.Drawing.Point(4, 23);
            this.tpSetRange.Name = "tpSetRange";
            this.tpSetRange.Size = new System.Drawing.Size(585, 402);
            this.tpSetRange.TabIndex = 3;
            this.tpSetRange.Text = "Set Range (AI Module)";
            this.tpSetRange.UseVisualStyleBackColor = true;
            // 
            // bGetConfig
            // 
            this.bGetConfig.Location = new System.Drawing.Point(420, 31);
            this.bGetConfig.Name = "bGetConfig";
            this.bGetConfig.Size = new System.Drawing.Size(87, 23);
            this.bGetConfig.TabIndex = 27;
            this.bGetConfig.Text = "Get Config";
            this.bGetConfig.UseVisualStyleBackColor = true;
            this.bGetConfig.Click += new System.EventHandler(this.bGetConfig_Click);
            // 
            // bSetRange
            // 
            this.bSetRange.Location = new System.Drawing.Point(420, 73);
            this.bSetRange.Name = "bSetRange";
            this.bSetRange.Size = new System.Drawing.Size(87, 23);
            this.bSetRange.TabIndex = 28;
            this.bSetRange.Text = "Set Config";
            this.bSetRange.UseVisualStyleBackColor = true;
            this.bSetRange.Click += new System.EventHandler(this.bSetRange_Click);
            // 
            // gbxChEnable
            // 
            this.gbxChEnable.Controls.Add(this.ckCH5);
            this.gbxChEnable.Controls.Add(this.ckCH4);
            this.gbxChEnable.Controls.Add(this.ckCH3);
            this.gbxChEnable.Controls.Add(this.ckCH2);
            this.gbxChEnable.Controls.Add(this.ckCH1);
            this.gbxChEnable.Controls.Add(this.ckCH0);
            this.gbxChEnable.Location = new System.Drawing.Point(301, 20);
            this.gbxChEnable.Name = "gbxChEnable";
            this.gbxChEnable.Size = new System.Drawing.Size(99, 181);
            this.gbxChEnable.TabIndex = 23;
            this.gbxChEnable.TabStop = false;
            this.gbxChEnable.Text = "Channel Enable";
            // 
            // ckCH5
            // 
            this.ckCH5.AutoSize = true;
            this.ckCH5.Location = new System.Drawing.Point(8, 153);
            this.ckCH5.Name = "ckCH5";
            this.ckCH5.Size = new System.Drawing.Size(46, 16);
            this.ckCH5.TabIndex = 45;
            this.ckCH5.Text = "CH5";
            this.ckCH5.UseVisualStyleBackColor = true;
            // 
            // ckCH4
            // 
            this.ckCH4.AutoSize = true;
            this.ckCH4.Location = new System.Drawing.Point(8, 125);
            this.ckCH4.Name = "ckCH4";
            this.ckCH4.Size = new System.Drawing.Size(46, 16);
            this.ckCH4.TabIndex = 44;
            this.ckCH4.Text = "CH4";
            this.ckCH4.UseVisualStyleBackColor = true;
            // 
            // ckCH3
            // 
            this.ckCH3.AutoSize = true;
            this.ckCH3.Location = new System.Drawing.Point(8, 99);
            this.ckCH3.Name = "ckCH3";
            this.ckCH3.Size = new System.Drawing.Size(46, 16);
            this.ckCH3.TabIndex = 43;
            this.ckCH3.Text = "CH3";
            this.ckCH3.UseVisualStyleBackColor = true;
            // 
            // ckCH2
            // 
            this.ckCH2.AutoSize = true;
            this.ckCH2.Location = new System.Drawing.Point(8, 72);
            this.ckCH2.Name = "ckCH2";
            this.ckCH2.Size = new System.Drawing.Size(46, 16);
            this.ckCH2.TabIndex = 42;
            this.ckCH2.Text = "CH2";
            this.ckCH2.UseVisualStyleBackColor = true;
            // 
            // ckCH1
            // 
            this.ckCH1.AutoSize = true;
            this.ckCH1.Location = new System.Drawing.Point(8, 45);
            this.ckCH1.Name = "ckCH1";
            this.ckCH1.Size = new System.Drawing.Size(46, 16);
            this.ckCH1.TabIndex = 41;
            this.ckCH1.Text = "CH1";
            this.ckCH1.UseVisualStyleBackColor = true;
            // 
            // ckCH0
            // 
            this.ckCH0.AutoSize = true;
            this.ckCH0.Location = new System.Drawing.Point(8, 19);
            this.ckCH0.Name = "ckCH0";
            this.ckCH0.Size = new System.Drawing.Size(46, 16);
            this.ckCH0.TabIndex = 40;
            this.ckCH0.Text = "CH0";
            this.ckCH0.UseVisualStyleBackColor = true;
            // 
            // gbxSetRangeOptionalFunction
            // 
            this.gbxSetRangeOptionalFunction.Controls.Add(this.label16);
            this.gbxSetRangeOptionalFunction.Controls.Add(this.cbUpdateRate);
            this.gbxSetRangeOptionalFunction.Controls.Add(this.cbBurnOutPresent);
            this.gbxSetRangeOptionalFunction.Controls.Add(this.label17);
            this.gbxSetRangeOptionalFunction.Controls.Add(this.label18);
            this.gbxSetRangeOptionalFunction.Controls.Add(this.cbBurnOutEnable);
            this.gbxSetRangeOptionalFunction.Location = new System.Drawing.Point(170, 20);
            this.gbxSetRangeOptionalFunction.Name = "gbxSetRangeOptionalFunction";
            this.gbxSetRangeOptionalFunction.Size = new System.Drawing.Size(125, 181);
            this.gbxSetRangeOptionalFunction.TabIndex = 22;
            this.gbxSetRangeOptionalFunction.TabStop = false;
            this.gbxSetRangeOptionalFunction.Text = "Optional Function";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 21);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(83, 12);
            this.label16.TabIndex = 28;
            this.label16.Text = "Integration Time";
            // 
            // cbUpdateRate
            // 
            this.cbUpdateRate.FormattingEnabled = true;
            this.cbUpdateRate.Items.AddRange(new object[] {
            "Auto",
            "50 Hz",
            "60 Hz"});
            this.cbUpdateRate.Location = new System.Drawing.Point(9, 36);
            this.cbUpdateRate.Name = "cbUpdateRate";
            this.cbUpdateRate.Size = new System.Drawing.Size(105, 20);
            this.cbUpdateRate.TabIndex = 27;
            // 
            // cbBurnOutPresent
            // 
            this.cbBurnOutPresent.FormattingEnabled = true;
            this.cbBurnOutPresent.Items.AddRange(new object[] {
            "Down Scale",
            "Up Scale"});
            this.cbBurnOutPresent.Location = new System.Drawing.Point(9, 131);
            this.cbBurnOutPresent.Name = "cbBurnOutPresent";
            this.cbBurnOutPresent.Size = new System.Drawing.Size(105, 20);
            this.cbBurnOutPresent.TabIndex = 32;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(7, 69);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(111, 12);
            this.label17.TabIndex = 29;
            this.label17.Text = "Burnout Detect Enable";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(7, 117);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(106, 12);
            this.label18.TabIndex = 31;
            this.label18.Text = "Burnout Detect Mode";
            // 
            // cbBurnOutEnable
            // 
            this.cbBurnOutEnable.FormattingEnabled = true;
            this.cbBurnOutEnable.Items.AddRange(new object[] {
            "Enable",
            "Disable"});
            this.cbBurnOutEnable.Location = new System.Drawing.Point(9, 84);
            this.cbBurnOutEnable.Name = "cbBurnOutEnable";
            this.cbBurnOutEnable.Size = new System.Drawing.Size(105, 20);
            this.cbBurnOutEnable.TabIndex = 30;
            // 
            // gbxChRangeType
            // 
            this.gbxChRangeType.Controls.Add(this.cbCh0);
            this.gbxChRangeType.Controls.Add(this.cbCh5);
            this.gbxChRangeType.Controls.Add(this.label10);
            this.gbxChRangeType.Controls.Add(this.cbCh4);
            this.gbxChRangeType.Controls.Add(this.cbCh2);
            this.gbxChRangeType.Controls.Add(this.label9);
            this.gbxChRangeType.Controls.Add(this.label6);
            this.gbxChRangeType.Controls.Add(this.label8);
            this.gbxChRangeType.Controls.Add(this.cbCh3);
            this.gbxChRangeType.Controls.Add(this.label7);
            this.gbxChRangeType.Controls.Add(this.cbCh1);
            this.gbxChRangeType.Controls.Add(this.label11);
            this.gbxChRangeType.Location = new System.Drawing.Point(14, 20);
            this.gbxChRangeType.Name = "gbxChRangeType";
            this.gbxChRangeType.Size = new System.Drawing.Size(150, 181);
            this.gbxChRangeType.TabIndex = 21;
            this.gbxChRangeType.TabStop = false;
            this.gbxChRangeType.Text = "Range Type";
            // 
            // cbCh0
            // 
            this.cbCh0.FormattingEnabled = true;
            this.cbCh0.Items.AddRange(new object[] {
            "-150mV ~  150mV",
            "-500mV ~  500mV",
            " -1V ~ 1V",
            "-5V ~ 5V",
            "-10 ~  10V",
            "-20mA ~ 20mA",
            "0~20mA",
            "4~20mA"});
            this.cbCh0.Location = new System.Drawing.Point(43, 21);
            this.cbCh0.Name = "cbCh0";
            this.cbCh0.Size = new System.Drawing.Size(101, 20);
            this.cbCh0.TabIndex = 13;
            // 
            // cbCh5
            // 
            this.cbCh5.FormattingEnabled = true;
            this.cbCh5.Items.AddRange(new object[] {
            "-150mV ~  150mV",
            "-500mV ~  500mV",
            " -1V ~ 1V",
            "-5V ~ 5V",
            "-10 ~  10V",
            "-20mA ~ 20mA",
            "0~20mA",
            "4~20mA"});
            this.cbCh5.Location = new System.Drawing.Point(43, 151);
            this.cbCh5.Name = "cbCh5";
            this.cbCh5.Size = new System.Drawing.Size(101, 20);
            this.cbCh5.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 131);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(25, 12);
            this.label10.TabIndex = 23;
            this.label10.Text = "Ch4";
            // 
            // cbCh4
            // 
            this.cbCh4.FormattingEnabled = true;
            this.cbCh4.Items.AddRange(new object[] {
            "-150mV ~  150mV",
            "-500mV ~  500mV",
            " -1V ~ 1V",
            "-5V ~ 5V",
            "-10 ~  10V",
            "-20mA ~ 20mA",
            "0~20mA",
            "4~20mA"});
            this.cbCh4.Location = new System.Drawing.Point(43, 125);
            this.cbCh4.Name = "cbCh4";
            this.cbCh4.Size = new System.Drawing.Size(101, 20);
            this.cbCh4.TabIndex = 17;
            // 
            // cbCh2
            // 
            this.cbCh2.FormattingEnabled = true;
            this.cbCh2.Items.AddRange(new object[] {
            "-150mV ~  150mV",
            "-500mV ~  500mV",
            " -1V ~ 1V",
            "-5V ~ 5V",
            "-10 ~  10V",
            "-20mA ~ 20mA",
            "0~20mA",
            "4~20mA"});
            this.cbCh2.Location = new System.Drawing.Point(43, 73);
            this.cbCh2.Name = "cbCh2";
            this.cbCh2.Size = new System.Drawing.Size(101, 20);
            this.cbCh2.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 105);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(25, 12);
            this.label9.TabIndex = 22;
            this.label9.Text = "Ch3";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 12);
            this.label6.TabIndex = 19;
            this.label6.Text = "Ch0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 12);
            this.label8.TabIndex = 21;
            this.label8.Text = "Ch2";
            // 
            // cbCh3
            // 
            this.cbCh3.FormattingEnabled = true;
            this.cbCh3.Items.AddRange(new object[] {
            "-150mV ~  150mV",
            "-500mV ~  500mV",
            " -1V ~ 1V",
            "-5V ~ 5V",
            "-10 ~  10V",
            "-20mA ~ 20mA",
            "0~20mA",
            "4~20mA"});
            this.cbCh3.Location = new System.Drawing.Point(43, 99);
            this.cbCh3.Name = "cbCh3";
            this.cbCh3.Size = new System.Drawing.Size(101, 20);
            this.cbCh3.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 12);
            this.label7.TabIndex = 20;
            this.label7.Text = "Ch1";
            // 
            // cbCh1
            // 
            this.cbCh1.FormattingEnabled = true;
            this.cbCh1.Items.AddRange(new object[] {
            "-150mV ~  150mV",
            "-500mV ~  500mV",
            " -1V ~ 1V",
            "-5V ~ 5V",
            "-10 ~  10V",
            "-20mA ~ 20mA",
            "0~20mA",
            "4~20mA"});
            this.cbCh1.Location = new System.Drawing.Point(43, 47);
            this.cbCh1.Name = "cbCh1";
            this.cbCh1.Size = new System.Drawing.Size(101, 20);
            this.cbCh1.TabIndex = 14;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 157);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(25, 12);
            this.label11.TabIndex = 24;
            this.label11.Text = "Ch5";
            // 
            // tpDeviceList
            // 
            this.tpDeviceList.Controls.Add(this.bDeviceListRefresh);
            this.tpDeviceList.Controls.Add(this.gbxDeviceList);
            this.tpDeviceList.Location = new System.Drawing.Point(4, 23);
            this.tpDeviceList.Name = "tpDeviceList";
            this.tpDeviceList.Size = new System.Drawing.Size(585, 402);
            this.tpDeviceList.TabIndex = 5;
            this.tpDeviceList.Text = "Device List";
            this.tpDeviceList.UseVisualStyleBackColor = true;
            // 
            // bDeviceListRefresh
            // 
            this.bDeviceListRefresh.Location = new System.Drawing.Point(11, 11);
            this.bDeviceListRefresh.Name = "bDeviceListRefresh";
            this.bDeviceListRefresh.Size = new System.Drawing.Size(75, 23);
            this.bDeviceListRefresh.TabIndex = 1;
            this.bDeviceListRefresh.Text = "Refresh";
            this.bDeviceListRefresh.UseVisualStyleBackColor = true;
            this.bDeviceListRefresh.Click += new System.EventHandler(this.bDeviceListRefresh_Click);
            // 
            // gbxDeviceList
            // 
            this.gbxDeviceList.Controls.Add(this.listViewDeviceList);
            this.gbxDeviceList.Location = new System.Drawing.Point(6, 43);
            this.gbxDeviceList.Name = "gbxDeviceList";
            this.gbxDeviceList.Size = new System.Drawing.Size(569, 352);
            this.gbxDeviceList.TabIndex = 0;
            this.gbxDeviceList.TabStop = false;
            this.gbxDeviceList.Text = "End Device (Router)";
            // 
            // listViewDeviceList
            // 
            this.listViewDeviceList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmListDeviceName,
            this.clmListSlaveId,
            this.clmListLQI,
            this.clmListInactiveTime,
            this.clmListCycleTime,
            this.clmListShortAddr,
            this.clmListParentAddr,
            this.clmListStatus});
            this.listViewDeviceList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewDeviceList.Location = new System.Drawing.Point(3, 18);
            this.listViewDeviceList.Name = "listViewDeviceList";
            this.listViewDeviceList.Size = new System.Drawing.Size(563, 331);
            this.listViewDeviceList.TabIndex = 0;
            this.listViewDeviceList.UseCompatibleStateImageBehavior = false;
            this.listViewDeviceList.View = System.Windows.Forms.View.Details;
            // 
            // clmListDeviceName
            // 
            this.clmListDeviceName.Text = "Name";
            this.clmListDeviceName.Width = 75;
            // 
            // clmListSlaveId
            // 
            this.clmListSlaveId.Text = "Slave ID";
            this.clmListSlaveId.Width = 63;
            // 
            // clmListLQI
            // 
            this.clmListLQI.Text = "LQI";
            this.clmListLQI.Width = 50;
            // 
            // clmListInactiveTime
            // 
            this.clmListInactiveTime.Text = "InactiveTime";
            this.clmListInactiveTime.Width = 73;
            // 
            // clmListCycleTime
            // 
            this.clmListCycleTime.Text = "CycleTime";
            this.clmListCycleTime.Width = 68;
            // 
            // clmListShortAddr
            // 
            this.clmListShortAddr.Text = "Short Addr";
            this.clmListShortAddr.Width = 70;
            // 
            // clmListParentAddr
            // 
            this.clmListParentAddr.Text = "Parent Addr";
            this.clmListParentAddr.Width = 70;
            // 
            // clmListStatus
            // 
            this.clmListStatus.Text = "Status";
            this.clmListStatus.Width = 88;
            // 
            // timerSearchCoordinator
            // 
            this.timerSearchCoordinator.Tick += new System.EventHandler(this.timerSearchCoordinator_Tick);
            // 
            // timerPollingData
            // 
            this.timerPollingData.Tick += new System.EventHandler(this.timerPollingData_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(795, 462);
            this.Controls.Add(this.gbDeviceInfo);
            this.Controls.Add(this.gbDeviceTreeView);
            this.Controls.Add(this.gbComport);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "ADAM2000-Sample";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.gbComport.ResumeLayout(false);
            this.gbComport.PerformLayout();
            this.gbDeviceTreeView.ResumeLayout(false);
            this.gbDeviceInfo.ResumeLayout(false);
            this.tcDeviceInfo.ResumeLayout(false);
            this.tpInformation.ResumeLayout(false);
            this.gbxzigbee.ResumeLayout(false);
            this.gbxzigbee.PerformLayout();
            this.gbxFw.ResumeLayout(false);
            this.gbxFw.PerformLayout();
            this.gbxDevice.ResumeLayout(false);
            this.gbxDevice.PerformLayout();
            this.tpDeviceStatus.ResumeLayout(false);
            this.gbxDeviceStatus.ResumeLayout(false);
            this.gbxDeviceStatus.PerformLayout();
            this.tpChannelInfo.ResumeLayout(false);
            this.tpChannelInfo.PerformLayout();
            this.gbxChannelInfo.ResumeLayout(false);
            this.tpChannelStatus.ResumeLayout(false);
            this.gbxChInfo.ResumeLayout(false);
            this.tpSetRange.ResumeLayout(false);
            this.gbxChEnable.ResumeLayout(false);
            this.gbxChEnable.PerformLayout();
            this.gbxSetRangeOptionalFunction.ResumeLayout(false);
            this.gbxSetRangeOptionalFunction.PerformLayout();
            this.gbxChRangeType.ResumeLayout(false);
            this.gbxChRangeType.PerformLayout();
            this.tpDeviceList.ResumeLayout(false);
            this.gbxDeviceList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbComport;
        private System.Windows.Forms.ComboBox cbComportBuadrate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbComport;
        private System.Windows.Forms.Button bComport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bCoordinator;
        private System.Windows.Forms.GroupBox gbDeviceTreeView;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.GroupBox gbDeviceInfo;
        private System.Windows.Forms.Timer timerSearchCoordinator;
        private System.Windows.Forms.Label searchLabel;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button bGetEndDevice;
        private System.Windows.Forms.TabControl tcDeviceInfo;
        private System.Windows.Forms.TabPage tpInformation;
        private System.Windows.Forms.TabPage tpChannelStatus;
        private System.Windows.Forms.GroupBox gbxzigbee;
        private System.Windows.Forms.TextBox txtChannel;
        private System.Windows.Forms.TextBox txtDataCycle;
        private System.Windows.Forms.TextBox txtSlaveId;
        private System.Windows.Forms.TextBox txtPanId;
        private System.Windows.Forms.Label labSlaveId;
        private System.Windows.Forms.TextBox txtPAddr;
        private System.Windows.Forms.Label labPAddr;
        private System.Windows.Forms.Label labDataCycle;
        private System.Windows.Forms.TextBox txtSAddr;
        private System.Windows.Forms.Label labSAddr;
        private System.Windows.Forms.Label labChannel;
        private System.Windows.Forms.Label labPanId;
        private System.Windows.Forms.GroupBox gbxFw;
        private System.Windows.Forms.TextBox txtFwVerZigBee;
        private System.Windows.Forms.Label labKernal;
        private System.Windows.Forms.Label labWireless;
        private System.Windows.Forms.TextBox txtFwVerKernal;
        private System.Windows.Forms.GroupBox gbxDevice;
        private System.Windows.Forms.TextBox txtDeviceName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label labDescription;
        private System.Windows.Forms.Label labAdamDevice;
        private System.Windows.Forms.TabPage tpDeviceStatus;
        private System.Windows.Forms.GroupBox gbxDeviceStatus;
        private System.Windows.Forms.TextBox txtModeStatus;
        private System.Windows.Forms.TextBox txtPower;
        private System.Windows.Forms.TextBox txtBattery;
        private System.Windows.Forms.TextBox txtLink;
        private System.Windows.Forms.Label labPowerDetection;
        private System.Windows.Forms.Label labBatteryStatus;
        private System.Windows.Forms.Label labLinkQuality;
        private System.Windows.Forms.Label labModeStatus;
        private System.Windows.Forms.GroupBox gbxChInfo;
        private System.Windows.Forms.ListView listViewChStatus;
        private System.Windows.Forms.ColumnHeader clmType;
        private System.Windows.Forms.ColumnHeader clmCh;
        private System.Windows.Forms.ColumnHeader clmModbusAddr;
        private System.Windows.Forms.ColumnHeader clmValue;
        private System.Windows.Forms.ColumnHeader clmChStatus;
        private System.Windows.Forms.Button bGetChStatus;
        private System.Windows.Forms.Button bClearLvChStatus;
        private System.Windows.Forms.TabPage tpSetRange;
        private System.Windows.Forms.GroupBox gbxSetRangeOptionalFunction;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cbUpdateRate;
        private System.Windows.Forms.ComboBox cbBurnOutPresent;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cbBurnOutEnable;
        private System.Windows.Forms.GroupBox gbxChRangeType;
        private System.Windows.Forms.ComboBox cbCh0;
        private System.Windows.Forms.ComboBox cbCh5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbCh4;
        private System.Windows.Forms.ComboBox cbCh2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbCh3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbCh1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox gbxChEnable;
        private System.Windows.Forms.Button bGetConfig;
        private System.Windows.Forms.Button bSetRange;
        private System.Windows.Forms.CheckBox ckCH5;
        private System.Windows.Forms.CheckBox ckCH4;
        private System.Windows.Forms.CheckBox ckCH3;
        private System.Windows.Forms.CheckBox ckCH2;
        private System.Windows.Forms.CheckBox ckCH1;
        private System.Windows.Forms.CheckBox ckCH0;
        private System.Windows.Forms.TabPage tpChannelInfo;
        private System.Windows.Forms.TabPage tpDeviceList;
        private System.Windows.Forms.GroupBox gbxDeviceList;
        private System.Windows.Forms.Button bDeviceListRefresh;
        private System.Windows.Forms.ListView listViewDeviceList;
        private System.Windows.Forms.ColumnHeader clmListDeviceName;
        private System.Windows.Forms.ColumnHeader clmListSlaveId;
        private System.Windows.Forms.ColumnHeader clmListLQI;
        private System.Windows.Forms.ColumnHeader clmListInactiveTime;
        private System.Windows.Forms.ColumnHeader clmListCycleTime;
        private System.Windows.Forms.ColumnHeader clmListShortAddr;
        private System.Windows.Forms.ColumnHeader clmListParentAddr;
        private System.Windows.Forms.ColumnHeader clmListStatus;
        private System.Windows.Forms.GroupBox gbxChannelInfo;
        private System.Windows.Forms.ListView listViewChannelInfo;
        private System.Windows.Forms.ColumnHeader clmChInfoType;
        private System.Windows.Forms.ColumnHeader clmChInfoCh;
        private System.Windows.Forms.ColumnHeader clmChInfoModbusAddr;
        private System.Windows.Forms.ColumnHeader clmChInfoValue;
        private System.Windows.Forms.ColumnHeader clmChInfoMode;
        private System.Windows.Forms.ColumnHeader clmChInfoDataCycle;
        private System.Windows.Forms.ColumnHeader clmChInfoLQI;
        private System.Windows.Forms.ColumnHeader clmChInfoLastUpdateTime;
        private System.Windows.Forms.Timer timerPollingData;
        private System.Windows.Forms.Label lPollingTimes;
        private System.Windows.Forms.Button bPolling;


    }
}

