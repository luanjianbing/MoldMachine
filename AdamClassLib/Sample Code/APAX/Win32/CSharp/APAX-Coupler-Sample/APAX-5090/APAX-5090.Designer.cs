namespace APAX_5090
{
    partial class Form_APAX_5090
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
            this.tcRemote = new System.Windows.Forms.TabControl();
            this.tabModuleInfo = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.labModule = new System.Windows.Forms.Label();
            this.txtModule = new System.Windows.Forms.TextBox();
            this.labID = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.labSupportKernelFw = new System.Windows.Forms.Label();
            this.txtSupportKernelFw = new System.Windows.Forms.TextBox();
            this.labFwVer = new System.Windows.Forms.Label();
            this.txtFwVer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLocate = new System.Windows.Forms.Button();
            this.tabSerial = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelHideControl_Serial = new System.Windows.Forms.Panel();
            this.chbxHide_Serial = new System.Windows.Forms.CheckBox();
            this.panelConfig_Serial = new System.Windows.Forms.Panel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.cbxDatabit = new System.Windows.Forms.ComboBox();
            this.labDatabit = new System.Windows.Forms.Label();
            this.cbxBaudRate = new System.Windows.Forms.ComboBox();
            this.labBaudrate = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.cbxPort = new System.Windows.Forms.ComboBox();
            this.labPort = new System.Windows.Forms.Label();
            this.btnApplySetting = new System.Windows.Forms.Button();
            this.chbxPortSettingFollowCOM1 = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.labParity = new System.Windows.Forms.Label();
            this.cbxParity = new System.Windows.Forms.ComboBox();
            this.labStopbit = new System.Windows.Forms.Label();
            this.cbxStopbit = new System.Windows.Forms.ComboBox();
            this.labFlowCtrl = new System.Windows.Forms.Label();
            this.cbxFlowCtrl = new System.Windows.Forms.ComboBox();
            this.panelInfo_Serial = new System.Windows.Forms.Panel();
            this.listViewComPortInfo = new System.Windows.Forms.ListView();
            this.clmSerialItem = new System.Windows.Forms.ColumnHeader();
            this.clmBaudrate = new System.Windows.Forms.ColumnHeader();
            this.clmDatabit = new System.Windows.Forms.ColumnHeader();
            this.clmParity = new System.Windows.Forms.ColumnHeader();
            this.clmStopBit = new System.Windows.Forms.ColumnHeader();
            this.clmFlowCtrl = new System.Windows.Forms.ColumnHeader();
            this.clmMapTcpPort = new System.Windows.Forms.ColumnHeader();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.StatusBar_IO = new System.Windows.Forms.StatusBar();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnStart = new System.Windows.Forms.Button();
            this.Btn_Quit = new System.Windows.Forms.Button();
            this.tcRemote.SuspendLayout();
            this.tabModuleInfo.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabSerial.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.panelHideControl_Serial.SuspendLayout();
            this.panelConfig_Serial.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.panelInfo_Serial.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcRemote
            // 
            this.tcRemote.Controls.Add(this.tabModuleInfo);
            this.tcRemote.Controls.Add(this.tabSerial);
            this.tcRemote.Location = new System.Drawing.Point(3, 3);
            this.tcRemote.Name = "tcRemote";
            this.tcRemote.SelectedIndex = 0;
            this.tcRemote.Size = new System.Drawing.Size(746, 345);
            this.tcRemote.TabIndex = 1;
            this.tcRemote.Visible = false;
            this.tcRemote.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabModuleInfo
            // 
            this.tabModuleInfo.BackColor = System.Drawing.SystemColors.Control;
            this.tabModuleInfo.Controls.Add(this.tableLayoutPanel2);
            this.tabModuleInfo.Location = new System.Drawing.Point(4, 22);
            this.tabModuleInfo.Name = "tabModuleInfo";
            this.tabModuleInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabModuleInfo.Size = new System.Drawing.Size(738, 319);
            this.tabModuleInfo.TabIndex = 0;
            this.tabModuleInfo.Text = "Module Information";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.labModule, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtModule, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.labID, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtID, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.labSupportKernelFw, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtSupportKernelFw, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.labFwVer, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtFwVer, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.btnLocate, 1, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(732, 313);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // labModule
            // 
            this.labModule.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labModule.Location = new System.Drawing.Point(3, 5);
            this.labModule.Name = "labModule";
            this.labModule.Size = new System.Drawing.Size(100, 20);
            this.labModule.TabIndex = 32;
            this.labModule.Text = "Module :";
            // 
            // txtModule
            // 
            this.txtModule.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtModule.Location = new System.Drawing.Point(123, 4);
            this.txtModule.Name = "txtModule";
            this.txtModule.ReadOnly = true;
            this.txtModule.Size = new System.Drawing.Size(223, 22);
            this.txtModule.TabIndex = 33;
            // 
            // labID
            // 
            this.labID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labID.Location = new System.Drawing.Point(3, 35);
            this.labID.Name = "labID";
            this.labID.Size = new System.Drawing.Size(100, 20);
            this.labID.TabIndex = 34;
            this.labID.Text = "Switch ID :";
            // 
            // txtID
            // 
            this.txtID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtID.Location = new System.Drawing.Point(123, 34);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(223, 22);
            this.txtID.TabIndex = 35;
            // 
            // labSupportKernelFw
            // 
            this.labSupportKernelFw.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labSupportKernelFw.Location = new System.Drawing.Point(3, 65);
            this.labSupportKernelFw.Name = "labSupportKernelFw";
            this.labSupportKernelFw.Size = new System.Drawing.Size(114, 20);
            this.labSupportKernelFw.TabIndex = 36;
            this.labSupportKernelFw.Text = "Support Kernel Fw:";
            // 
            // txtSupportKernelFw
            // 
            this.txtSupportKernelFw.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtSupportKernelFw.Location = new System.Drawing.Point(123, 64);
            this.txtSupportKernelFw.Name = "txtSupportKernelFw";
            this.txtSupportKernelFw.ReadOnly = true;
            this.txtSupportKernelFw.Size = new System.Drawing.Size(223, 22);
            this.txtSupportKernelFw.TabIndex = 37;
            // 
            // labFwVer
            // 
            this.labFwVer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labFwVer.Location = new System.Drawing.Point(3, 95);
            this.labFwVer.Name = "labFwVer";
            this.labFwVer.Size = new System.Drawing.Size(114, 20);
            this.labFwVer.TabIndex = 38;
            this.labFwVer.Text = "Firmware Version:";
            // 
            // txtFwVer
            // 
            this.txtFwVer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtFwVer.Location = new System.Drawing.Point(123, 94);
            this.txtFwVer.Name = "txtFwVer";
            this.txtFwVer.ReadOnly = true;
            this.txtFwVer.Size = new System.Drawing.Size(223, 22);
            this.txtFwVer.TabIndex = 39;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.Location = new System.Drawing.Point(3, 125);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 40;
            this.label1.Text = "Locate";
            // 
            // btnLocate
            // 
            this.btnLocate.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnLocate.Location = new System.Drawing.Point(123, 125);
            this.btnLocate.Name = "btnLocate";
            this.btnLocate.Size = new System.Drawing.Size(72, 20);
            this.btnLocate.TabIndex = 41;
            this.btnLocate.Text = "Enable";
            this.btnLocate.Click += new System.EventHandler(this.btnLocate_Click);
            // 
            // tabSerial
            // 
            this.tabSerial.BackColor = System.Drawing.SystemColors.Control;
            this.tabSerial.Controls.Add(this.flowLayoutPanel2);
            this.tabSerial.Location = new System.Drawing.Point(4, 22);
            this.tabSerial.Name = "tabSerial";
            this.tabSerial.Padding = new System.Windows.Forms.Padding(3);
            this.tabSerial.Size = new System.Drawing.Size(738, 319);
            this.tabSerial.TabIndex = 1;
            this.tabSerial.Text = "Serial";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.panelHideControl_Serial);
            this.flowLayoutPanel2.Controls.Add(this.panelConfig_Serial);
            this.flowLayoutPanel2.Controls.Add(this.panelInfo_Serial);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(732, 313);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // panelHideControl_Serial
            // 
            this.panelHideControl_Serial.Controls.Add(this.chbxHide_Serial);
            this.panelHideControl_Serial.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHideControl_Serial.Location = new System.Drawing.Point(3, 3);
            this.panelHideControl_Serial.Name = "panelHideControl_Serial";
            this.panelHideControl_Serial.Size = new System.Drawing.Size(726, 32);
            this.panelHideControl_Serial.TabIndex = 7;
            // 
            // chbxHide_Serial
            // 
            this.chbxHide_Serial.Location = new System.Drawing.Point(8, 8);
            this.chbxHide_Serial.Name = "chbxHide_Serial";
            this.chbxHide_Serial.Size = new System.Drawing.Size(168, 20);
            this.chbxHide_Serial.TabIndex = 1;
            this.chbxHide_Serial.Text = "Hide Setting Panel";
            this.chbxHide_Serial.CheckedChanged += new System.EventHandler(this.chbxHide_Serial_CheckedChanged);
            // 
            // panelConfig_Serial
            // 
            this.panelConfig_Serial.BackColor = System.Drawing.Color.SkyBlue;
            this.panelConfig_Serial.Controls.Add(this.tableLayoutPanel4);
            this.panelConfig_Serial.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelConfig_Serial.Location = new System.Drawing.Point(3, 41);
            this.panelConfig_Serial.Name = "panelConfig_Serial";
            this.panelConfig_Serial.Size = new System.Drawing.Size(726, 114);
            this.panelConfig_Serial.TabIndex = 8;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel5, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel6, 0, 2);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 4;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(726, 114);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 6;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.cbxDatabit, 4, 0);
            this.tableLayoutPanel5.Controls.Add(this.labDatabit, 3, 0);
            this.tableLayoutPanel5.Controls.Add(this.cbxBaudRate, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.labBaudrate, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 38);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(720, 29);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // cbxDatabit
            // 
            this.cbxDatabit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDatabit.FormattingEnabled = true;
            this.cbxDatabit.Items.AddRange(new object[] {
            "8",
            "9"});
            this.cbxDatabit.Location = new System.Drawing.Point(238, 3);
            this.cbxDatabit.Name = "cbxDatabit";
            this.cbxDatabit.Size = new System.Drawing.Size(84, 20);
            this.cbxDatabit.TabIndex = 5;
            // 
            // labDatabit
            // 
            this.labDatabit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labDatabit.AutoSize = true;
            this.labDatabit.Location = new System.Drawing.Point(178, 8);
            this.labDatabit.Name = "labDatabit";
            this.labDatabit.Size = new System.Drawing.Size(42, 12);
            this.labDatabit.TabIndex = 4;
            this.labDatabit.Text = "Databits";
            // 
            // cbxBaudRate
            // 
            this.cbxBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBaudRate.FormattingEnabled = true;
            this.cbxBaudRate.Items.AddRange(new object[] {
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cbxBaudRate.Location = new System.Drawing.Point(63, 3);
            this.cbxBaudRate.Name = "cbxBaudRate";
            this.cbxBaudRate.Size = new System.Drawing.Size(84, 20);
            this.cbxBaudRate.TabIndex = 3;
            // 
            // labBaudrate
            // 
            this.labBaudrate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labBaudrate.AutoSize = true;
            this.labBaudrate.Location = new System.Drawing.Point(3, 8);
            this.labBaudrate.Name = "labBaudrate";
            this.labBaudrate.Size = new System.Drawing.Size(54, 12);
            this.labBaudrate.TabIndex = 2;
            this.labBaudrate.Text = "Baudrate";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 6;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 182F));
            this.tableLayoutPanel3.Controls.Add(this.cbxPort, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.labPort, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnApplySetting, 5, 0);
            this.tableLayoutPanel3.Controls.Add(this.chbxPortSettingFollowCOM1, 3, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(720, 29);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // cbxPort
            // 
            this.cbxPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPort.FormattingEnabled = true;
            this.cbxPort.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4"});
            this.cbxPort.Location = new System.Drawing.Point(63, 3);
            this.cbxPort.Name = "cbxPort";
            this.cbxPort.Size = new System.Drawing.Size(84, 20);
            this.cbxPort.TabIndex = 1;
            this.cbxPort.SelectedIndexChanged += new System.EventHandler(this.cbxPort_SelectedIndexChanged);
            // 
            // labPort
            // 
            this.labPort.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labPort.AutoSize = true;
            this.labPort.Location = new System.Drawing.Point(3, 11);
            this.labPort.Name = "labPort";
            this.labPort.Size = new System.Drawing.Size(24, 12);
            this.labPort.TabIndex = 0;
            this.labPort.Text = "Port";
            // 
            // btnApplySetting
            // 
            this.btnApplySetting.Location = new System.Drawing.Point(541, 3);
            this.btnApplySetting.Name = "btnApplySetting";
            this.btnApplySetting.Size = new System.Drawing.Size(169, 23);
            this.btnApplySetting.TabIndex = 2;
            this.btnApplySetting.Text = "Apply";
            this.btnApplySetting.UseVisualStyleBackColor = true;
            this.btnApplySetting.Click += new System.EventHandler(this.btnApplySetting_Click);
            // 
            // chbxPortSettingFollowCOM1
            // 
            this.chbxPortSettingFollowCOM1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chbxPortSettingFollowCOM1.AutoSize = true;
            this.chbxPortSettingFollowCOM1.Location = new System.Drawing.Point(178, 9);
            this.chbxPortSettingFollowCOM1.Name = "chbxPortSettingFollowCOM1";
            this.chbxPortSettingFollowCOM1.Size = new System.Drawing.Size(109, 16);
            this.chbxPortSettingFollowCOM1.TabIndex = 3;
            this.chbxPortSettingFollowCOM1.Text = "All follow COM 1";
            this.chbxPortSettingFollowCOM1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 9;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.labParity, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.cbxParity, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.labStopbit, 3, 0);
            this.tableLayoutPanel6.Controls.Add(this.cbxStopbit, 4, 0);
            this.tableLayoutPanel6.Controls.Add(this.labFlowCtrl, 6, 0);
            this.tableLayoutPanel6.Controls.Add(this.cbxFlowCtrl, 7, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 73);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(720, 29);
            this.tableLayoutPanel6.TabIndex = 1;
            // 
            // labParity
            // 
            this.labParity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labParity.AutoSize = true;
            this.labParity.Location = new System.Drawing.Point(3, 8);
            this.labParity.Name = "labParity";
            this.labParity.Size = new System.Drawing.Size(54, 12);
            this.labParity.TabIndex = 0;
            this.labParity.Text = "Parity";
            // 
            // cbxParity
            // 
            this.cbxParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxParity.FormattingEnabled = true;
            this.cbxParity.Items.AddRange(new object[] {
            "NONE",
            "ODD",
            "EVEN",
            "MARK",
            "SPACE"});
            this.cbxParity.Location = new System.Drawing.Point(63, 3);
            this.cbxParity.Name = "cbxParity";
            this.cbxParity.Size = new System.Drawing.Size(84, 20);
            this.cbxParity.TabIndex = 1;
            // 
            // labStopbit
            // 
            this.labStopbit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labStopbit.AutoSize = true;
            this.labStopbit.Location = new System.Drawing.Point(178, 8);
            this.labStopbit.Name = "labStopbit";
            this.labStopbit.Size = new System.Drawing.Size(54, 12);
            this.labStopbit.TabIndex = 2;
            this.labStopbit.Text = "Stopbits";
            // 
            // cbxStopbit
            // 
            this.cbxStopbit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxStopbit.FormattingEnabled = true;
            this.cbxStopbit.Items.AddRange(new object[] {
            "1",
            "0.5",
            "2",
            "1.5"});
            this.cbxStopbit.Location = new System.Drawing.Point(238, 3);
            this.cbxStopbit.Name = "cbxStopbit";
            this.cbxStopbit.Size = new System.Drawing.Size(84, 20);
            this.cbxStopbit.TabIndex = 3;
            // 
            // labFlowCtrl
            // 
            this.labFlowCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labFlowCtrl.AutoSize = true;
            this.labFlowCtrl.Location = new System.Drawing.Point(353, 8);
            this.labFlowCtrl.Name = "labFlowCtrl";
            this.labFlowCtrl.Size = new System.Drawing.Size(74, 12);
            this.labFlowCtrl.TabIndex = 4;
            this.labFlowCtrl.Text = "Flow Control";
            // 
            // cbxFlowCtrl
            // 
            this.cbxFlowCtrl.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFlowCtrl.FormattingEnabled = true;
            this.cbxFlowCtrl.Items.AddRange(new object[] {
            "NONE",
            "RTS",
            "CTS",
            "DTR"});
            this.cbxFlowCtrl.Location = new System.Drawing.Point(433, 3);
            this.cbxFlowCtrl.Name = "cbxFlowCtrl";
            this.cbxFlowCtrl.Size = new System.Drawing.Size(84, 20);
            this.cbxFlowCtrl.TabIndex = 5;
            // 
            // panelInfo_Serial
            // 
            this.panelInfo_Serial.Controls.Add(this.listViewComPortInfo);
            this.panelInfo_Serial.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInfo_Serial.Location = new System.Drawing.Point(3, 161);
            this.panelInfo_Serial.Name = "panelInfo_Serial";
            this.panelInfo_Serial.Size = new System.Drawing.Size(723, 147);
            this.panelInfo_Serial.TabIndex = 10;
            // 
            // listViewComPortInfo
            // 
            this.listViewComPortInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmSerialItem,
            this.clmBaudrate,
            this.clmDatabit,
            this.clmParity,
            this.clmStopBit,
            this.clmFlowCtrl,
            this.clmMapTcpPort});
            this.listViewComPortInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewComPortInfo.FullRowSelect = true;
            this.listViewComPortInfo.Location = new System.Drawing.Point(0, 0);
            this.listViewComPortInfo.Name = "listViewComPortInfo";
            this.listViewComPortInfo.Size = new System.Drawing.Size(723, 147);
            this.listViewComPortInfo.TabIndex = 9;
            this.listViewComPortInfo.UseCompatibleStateImageBehavior = false;
            this.listViewComPortInfo.View = System.Windows.Forms.View.Details;
            // 
            // clmSerialItem
            // 
            this.clmSerialItem.Text = "Item";
            this.clmSerialItem.Width = 90;
            // 
            // clmBaudrate
            // 
            this.clmBaudrate.Text = "Baudrate";
            this.clmBaudrate.Width = 100;
            // 
            // clmDatabit
            // 
            this.clmDatabit.Text = "Databits";
            this.clmDatabit.Width = 100;
            // 
            // clmParity
            // 
            this.clmParity.Text = "Parity";
            this.clmParity.Width = 100;
            // 
            // clmStopBit
            // 
            this.clmStopBit.Text = "Stopbits";
            this.clmStopBit.Width = 100;
            // 
            // clmFlowCtrl
            // 
            this.clmFlowCtrl.Text = "Flow Control";
            this.clmFlowCtrl.Width = 100;
            // 
            // clmMapTcpPort
            // 
            this.clmMapTcpPort.Text = "TCP Port";
            this.clmMapTcpPort.Width = 125;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.StatusBar_IO, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tcRemote, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(752, 421);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // StatusBar_IO
            // 
            this.StatusBar_IO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StatusBar_IO.Location = new System.Drawing.Point(3, 389);
            this.StatusBar_IO.Name = "StatusBar_IO";
            this.StatusBar_IO.Size = new System.Drawing.Size(746, 29);
            this.StatusBar_IO.TabIndex = 26;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.btnStart);
            this.flowLayoutPanel1.Controls.Add(this.Btn_Quit);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(587, 354);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(162, 29);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(3, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(73, 21);
            this.btnStart.TabIndex = 24;
            this.btnStart.Text = "Start";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // Btn_Quit
            // 
            this.Btn_Quit.Location = new System.Drawing.Point(82, 3);
            this.Btn_Quit.Name = "Btn_Quit";
            this.Btn_Quit.Size = new System.Drawing.Size(73, 21);
            this.Btn_Quit.TabIndex = 25;
            this.Btn_Quit.Text = "Quit";
            this.Btn_Quit.Click += new System.EventHandler(this.Btn_Quit_Click);
            // 
            // Form_APAX_5090
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 421);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form_APAX_5090";
            this.Text = "APAX_5090";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_APAX_5090_FormClosing);
            this.tcRemote.ResumeLayout(false);
            this.tabModuleInfo.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tabSerial.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.panelHideControl_Serial.ResumeLayout(false);
            this.panelConfig_Serial.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.panelInfo_Serial.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcRemote;
        private System.Windows.Forms.TabPage tabModuleInfo;
        private System.Windows.Forms.TabPage tabSerial;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        internal System.Windows.Forms.Button btnStart;
        internal System.Windows.Forms.Button Btn_Quit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label labModule;
        private System.Windows.Forms.TextBox txtModule;
        private System.Windows.Forms.Label labID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label labSupportKernelFw;
        private System.Windows.Forms.TextBox txtSupportKernelFw;
        private System.Windows.Forms.Label labFwVer;
        private System.Windows.Forms.TextBox txtFwVer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLocate;
        internal System.Windows.Forms.StatusBar StatusBar_IO;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Panel panelHideControl_Serial;
        private System.Windows.Forms.CheckBox chbxHide_Serial;
        private System.Windows.Forms.Panel panelConfig_Serial;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.ComboBox cbxDatabit;
        private System.Windows.Forms.Label labDatabit;
        private System.Windows.Forms.ComboBox cbxBaudRate;
        private System.Windows.Forms.Label labBaudrate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.ComboBox cbxPort;
        private System.Windows.Forms.Label labPort;
        private System.Windows.Forms.Button btnApplySetting;
        private System.Windows.Forms.CheckBox chbxPortSettingFollowCOM1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Label labParity;
        private System.Windows.Forms.ComboBox cbxParity;
        private System.Windows.Forms.Label labStopbit;
        private System.Windows.Forms.ComboBox cbxStopbit;
        private System.Windows.Forms.Label labFlowCtrl;
        private System.Windows.Forms.ComboBox cbxFlowCtrl;
        private System.Windows.Forms.ListView listViewComPortInfo;
        private System.Windows.Forms.ColumnHeader clmSerialItem;
        private System.Windows.Forms.ColumnHeader clmBaudrate;
        private System.Windows.Forms.ColumnHeader clmParity;
        private System.Windows.Forms.ColumnHeader clmStopBit;
        private System.Windows.Forms.ColumnHeader clmFlowCtrl;
        private System.Windows.Forms.Panel panelInfo_Serial;
        private System.Windows.Forms.ColumnHeader clmMapTcpPort;
        private System.Windows.Forms.ColumnHeader clmDatabit;
    }
}

