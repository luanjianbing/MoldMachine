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
            this.StatusBar_IO = new System.Windows.Forms.StatusBar();
            this.btnLocate = new System.Windows.Forms.Button();
            this.lblLocate = new System.Windows.Forms.Label();
            this.txtModule = new System.Windows.Forms.TextBox();
            this.labModule = new System.Windows.Forms.Label();
            this.labID = new System.Windows.Forms.Label();
            this.labFwVer = new System.Windows.Forms.Label();
            this.Btn_Quit = new System.Windows.Forms.Button();
            this.txtID = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.tabModuleInfo = new System.Windows.Forms.TabPage();
            this.txtFwVer = new System.Windows.Forms.TextBox();
            this.txtSupportKernelFw = new System.Windows.Forms.TextBox();
            this.labSupportKernelFw = new System.Windows.Forms.Label();
            this.tcRemote = new System.Windows.Forms.TabControl();
            this.tabSerial = new System.Windows.Forms.TabPage();
            this.panelInfo_Serial = new System.Windows.Forms.Panel();
            this.listViewComPortInfo = new System.Windows.Forms.ListView();
            this.clmSerialItem = new System.Windows.Forms.ColumnHeader();
            this.clmBaudrate = new System.Windows.Forms.ColumnHeader();
            this.clmDatabit = new System.Windows.Forms.ColumnHeader();
            this.clmParity = new System.Windows.Forms.ColumnHeader();
            this.clmStopBit = new System.Windows.Forms.ColumnHeader();
            this.clmFlowCtrl = new System.Windows.Forms.ColumnHeader();
            this.clmMapTcpPort = new System.Windows.Forms.ColumnHeader();
            this.panelConfig_Serial = new System.Windows.Forms.Panel();
            this.btnApplySetting = new System.Windows.Forms.Button();
            this.cbxFlowCtrl = new System.Windows.Forms.ComboBox();
            this.labFlowCtrl = new System.Windows.Forms.Label();
            this.cbxStopbit = new System.Windows.Forms.ComboBox();
            this.labStopbit = new System.Windows.Forms.Label();
            this.cbxDatabit = new System.Windows.Forms.ComboBox();
            this.labDatabit = new System.Windows.Forms.Label();
            this.cbxParity = new System.Windows.Forms.ComboBox();
            this.labParity = new System.Windows.Forms.Label();
            this.cbxBaudRate = new System.Windows.Forms.ComboBox();
            this.labBaudrate = new System.Windows.Forms.Label();
            this.chbxPortSettingFollowCOM1 = new System.Windows.Forms.CheckBox();
            this.cbxPort = new System.Windows.Forms.ComboBox();
            this.labPort = new System.Windows.Forms.Label();
            this.panelHideControl_Serial = new System.Windows.Forms.Panel();
            this.chbxHide_Serial = new System.Windows.Forms.CheckBox();
            this.tabModuleInfo.SuspendLayout();
            this.tcRemote.SuspendLayout();
            this.tabSerial.SuspendLayout();
            this.panelInfo_Serial.SuspendLayout();
            this.panelConfig_Serial.SuspendLayout();
            this.panelHideControl_Serial.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatusBar_IO
            // 
            this.StatusBar_IO.Location = new System.Drawing.Point(0, 410);
            this.StatusBar_IO.Name = "StatusBar_IO";
            this.StatusBar_IO.Size = new System.Drawing.Size(766, 24);
            // 
            // btnLocate
            // 
            this.btnLocate.Location = new System.Drawing.Point(135, 129);
            this.btnLocate.Name = "btnLocate";
            this.btnLocate.Size = new System.Drawing.Size(72, 20);
            this.btnLocate.TabIndex = 50;
            this.btnLocate.Text = "Enable";
            this.btnLocate.Click += new System.EventHandler(this.btnLocate_Click);
            // 
            // lblLocate
            // 
            this.lblLocate.Location = new System.Drawing.Point(4, 129);
            this.lblLocate.Name = "lblLocate";
            this.lblLocate.Size = new System.Drawing.Size(56, 20);
            this.lblLocate.Text = "Locate:";
            // 
            // txtModule
            // 
            this.txtModule.Location = new System.Drawing.Point(135, 9);
            this.txtModule.Name = "txtModule";
            this.txtModule.ReadOnly = true;
            this.txtModule.Size = new System.Drawing.Size(223, 23);
            this.txtModule.TabIndex = 18;
            // 
            // labModule
            // 
            this.labModule.Location = new System.Drawing.Point(4, 9);
            this.labModule.Name = "labModule";
            this.labModule.Size = new System.Drawing.Size(100, 20);
            this.labModule.Text = "Module :";
            // 
            // labID
            // 
            this.labID.Location = new System.Drawing.Point(4, 40);
            this.labID.Name = "labID";
            this.labID.Size = new System.Drawing.Size(100, 20);
            this.labID.Text = "Switch ID :";
            // 
            // labFwVer
            // 
            this.labFwVer.Location = new System.Drawing.Point(4, 100);
            this.labFwVer.Name = "labFwVer";
            this.labFwVer.Size = new System.Drawing.Size(125, 20);
            this.labFwVer.Text = "Firmware Version:";
            // 
            // Btn_Quit
            // 
            this.Btn_Quit.Location = new System.Drawing.Point(689, 385);
            this.Btn_Quit.Name = "Btn_Quit";
            this.Btn_Quit.Size = new System.Drawing.Size(73, 21);
            this.Btn_Quit.TabIndex = 28;
            this.Btn_Quit.Text = "Quit";
            this.Btn_Quit.Click += new System.EventHandler(this.Btn_Quit_Click);
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(135, 40);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(223, 23);
            this.txtID.TabIndex = 23;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(610, 385);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(73, 21);
            this.btnStart.TabIndex = 27;
            this.btnStart.Text = "Start";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tabModuleInfo
            // 
            this.tabModuleInfo.Controls.Add(this.btnLocate);
            this.tabModuleInfo.Controls.Add(this.lblLocate);
            this.tabModuleInfo.Controls.Add(this.txtModule);
            this.tabModuleInfo.Controls.Add(this.labModule);
            this.tabModuleInfo.Controls.Add(this.labID);
            this.tabModuleInfo.Controls.Add(this.labFwVer);
            this.tabModuleInfo.Controls.Add(this.txtID);
            this.tabModuleInfo.Controls.Add(this.txtFwVer);
            this.tabModuleInfo.Controls.Add(this.txtSupportKernelFw);
            this.tabModuleInfo.Controls.Add(this.labSupportKernelFw);
            this.tabModuleInfo.Location = new System.Drawing.Point(4, 25);
            this.tabModuleInfo.Name = "tabModuleInfo";
            this.tabModuleInfo.Size = new System.Drawing.Size(758, 350);
            this.tabModuleInfo.Text = "Module Information";
            // 
            // txtFwVer
            // 
            this.txtFwVer.Location = new System.Drawing.Point(135, 100);
            this.txtFwVer.Name = "txtFwVer";
            this.txtFwVer.ReadOnly = true;
            this.txtFwVer.Size = new System.Drawing.Size(223, 23);
            this.txtFwVer.TabIndex = 25;
            // 
            // txtSupportKernelFw
            // 
            this.txtSupportKernelFw.Location = new System.Drawing.Point(135, 69);
            this.txtSupportKernelFw.Name = "txtSupportKernelFw";
            this.txtSupportKernelFw.ReadOnly = true;
            this.txtSupportKernelFw.Size = new System.Drawing.Size(223, 23);
            this.txtSupportKernelFw.TabIndex = 26;
            // 
            // labSupportKernelFw
            // 
            this.labSupportKernelFw.Location = new System.Drawing.Point(4, 72);
            this.labSupportKernelFw.Name = "labSupportKernelFw";
            this.labSupportKernelFw.Size = new System.Drawing.Size(124, 20);
            this.labSupportKernelFw.Text = "Support Kernel Fw:";
            // 
            // tcRemote
            // 
            this.tcRemote.Controls.Add(this.tabModuleInfo);
            this.tcRemote.Controls.Add(this.tabSerial);
            this.tcRemote.Dock = System.Windows.Forms.DockStyle.Top;
            this.tcRemote.Enabled = false;
            this.tcRemote.Location = new System.Drawing.Point(0, 0);
            this.tcRemote.Name = "tcRemote";
            this.tcRemote.SelectedIndex = 0;
            this.tcRemote.Size = new System.Drawing.Size(766, 379);
            this.tcRemote.TabIndex = 26;
            this.tcRemote.Visible = false;
            this.tcRemote.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabSerial
            // 
            this.tabSerial.Controls.Add(this.panelInfo_Serial);
            this.tabSerial.Controls.Add(this.panelConfig_Serial);
            this.tabSerial.Controls.Add(this.panelHideControl_Serial);
            this.tabSerial.Location = new System.Drawing.Point(4, 25);
            this.tabSerial.Name = "tabSerial";
            this.tabSerial.Size = new System.Drawing.Size(758, 350);
            this.tabSerial.Text = "Serial";
            // 
            // panelInfo_Serial
            // 
            this.panelInfo_Serial.Controls.Add(this.listViewComPortInfo);
            this.panelInfo_Serial.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInfo_Serial.Location = new System.Drawing.Point(0, 204);
            this.panelInfo_Serial.Name = "panelInfo_Serial";
            this.panelInfo_Serial.Size = new System.Drawing.Size(758, 147);
            // 
            // listViewComPortInfo
            // 
            this.listViewComPortInfo.Columns.Add(this.clmSerialItem);
            this.listViewComPortInfo.Columns.Add(this.clmBaudrate);
            this.listViewComPortInfo.Columns.Add(this.clmDatabit);
            this.listViewComPortInfo.Columns.Add(this.clmParity);
            this.listViewComPortInfo.Columns.Add(this.clmStopBit);
            this.listViewComPortInfo.Columns.Add(this.clmFlowCtrl);
            this.listViewComPortInfo.Columns.Add(this.clmMapTcpPort);
            this.listViewComPortInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewComPortInfo.FullRowSelect = true;
            this.listViewComPortInfo.Location = new System.Drawing.Point(0, 0);
            this.listViewComPortInfo.Name = "listViewComPortInfo";
            this.listViewComPortInfo.Size = new System.Drawing.Size(758, 147);
            this.listViewComPortInfo.TabIndex = 9;
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
            // panelConfig_Serial
            // 
            this.panelConfig_Serial.BackColor = System.Drawing.Color.SkyBlue;
            this.panelConfig_Serial.Controls.Add(this.btnApplySetting);
            this.panelConfig_Serial.Controls.Add(this.cbxFlowCtrl);
            this.panelConfig_Serial.Controls.Add(this.labFlowCtrl);
            this.panelConfig_Serial.Controls.Add(this.cbxStopbit);
            this.panelConfig_Serial.Controls.Add(this.labStopbit);
            this.panelConfig_Serial.Controls.Add(this.cbxDatabit);
            this.panelConfig_Serial.Controls.Add(this.labDatabit);
            this.panelConfig_Serial.Controls.Add(this.cbxParity);
            this.panelConfig_Serial.Controls.Add(this.labParity);
            this.panelConfig_Serial.Controls.Add(this.cbxBaudRate);
            this.panelConfig_Serial.Controls.Add(this.labBaudrate);
            this.panelConfig_Serial.Controls.Add(this.chbxPortSettingFollowCOM1);
            this.panelConfig_Serial.Controls.Add(this.cbxPort);
            this.panelConfig_Serial.Controls.Add(this.labPort);
            this.panelConfig_Serial.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelConfig_Serial.Location = new System.Drawing.Point(0, 30);
            this.panelConfig_Serial.Name = "panelConfig_Serial";
            this.panelConfig_Serial.Size = new System.Drawing.Size(758, 174);
            // 
            // btnApplySetting
            // 
            this.btnApplySetting.Location = new System.Drawing.Point(557, 10);
            this.btnApplySetting.Name = "btnApplySetting";
            this.btnApplySetting.Size = new System.Drawing.Size(122, 23);
            this.btnApplySetting.TabIndex = 25;
            this.btnApplySetting.Text = "Apply";
            this.btnApplySetting.Click += new System.EventHandler(this.btnApplySetting_Click);
            // 
            // cbxFlowCtrl
            // 
            this.cbxFlowCtrl.Items.Add("NONE");
            this.cbxFlowCtrl.Items.Add("RTS");
            this.cbxFlowCtrl.Items.Add("CTS");
            this.cbxFlowCtrl.Items.Add("DTR");
            this.cbxFlowCtrl.Location = new System.Drawing.Point(557, 80);
            this.cbxFlowCtrl.Name = "cbxFlowCtrl";
            this.cbxFlowCtrl.Size = new System.Drawing.Size(122, 23);
            this.cbxFlowCtrl.TabIndex = 24;
            // 
            // labFlowCtrl
            // 
            this.labFlowCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labFlowCtrl.Location = new System.Drawing.Point(465, 80);
            this.labFlowCtrl.Name = "labFlowCtrl";
            this.labFlowCtrl.Size = new System.Drawing.Size(81, 23);
            this.labFlowCtrl.Text = "Flow Control";
            // 
            // cbxStopbit
            // 
            this.cbxStopbit.Items.Add("1");
            this.cbxStopbit.Items.Add("0.5");
            this.cbxStopbit.Items.Add("2");
            this.cbxStopbit.Items.Add("1.5");
            this.cbxStopbit.Location = new System.Drawing.Point(307, 82);
            this.cbxStopbit.Name = "cbxStopbit";
            this.cbxStopbit.Size = new System.Drawing.Size(122, 23);
            this.cbxStopbit.TabIndex = 16;
            // 
            // labStopbit
            // 
            this.labStopbit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labStopbit.Location = new System.Drawing.Point(238, 81);
            this.labStopbit.Name = "labStopbit";
            this.labStopbit.Size = new System.Drawing.Size(54, 22);
            this.labStopbit.Text = "Stopbits";
            // 
            // cbxDatabit
            // 
            this.cbxDatabit.Items.Add("8");
            this.cbxDatabit.Items.Add("9");
            this.cbxDatabit.Location = new System.Drawing.Point(307, 43);
            this.cbxDatabit.Name = "cbxDatabit";
            this.cbxDatabit.Size = new System.Drawing.Size(122, 23);
            this.cbxDatabit.TabIndex = 13;
            // 
            // labDatabit
            // 
            this.labDatabit.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labDatabit.Location = new System.Drawing.Point(238, 40);
            this.labDatabit.Name = "labDatabit";
            this.labDatabit.Size = new System.Drawing.Size(63, 22);
            this.labDatabit.Text = "Databits";
            // 
            // cbxParity
            // 
            this.cbxParity.Items.Add("NONE");
            this.cbxParity.Items.Add("ODD");
            this.cbxParity.Items.Add("EVEN");
            this.cbxParity.Items.Add("MARK");
            this.cbxParity.Items.Add("SPACE");
            this.cbxParity.Location = new System.Drawing.Point(79, 82);
            this.cbxParity.Name = "cbxParity";
            this.cbxParity.Size = new System.Drawing.Size(122, 23);
            this.cbxParity.TabIndex = 9;
            // 
            // labParity
            // 
            this.labParity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labParity.Location = new System.Drawing.Point(8, 81);
            this.labParity.Name = "labParity";
            this.labParity.Size = new System.Drawing.Size(54, 20);
            this.labParity.Text = "Parity";
            // 
            // cbxBaudRate
            // 
            this.cbxBaudRate.Items.Add("600");
            this.cbxBaudRate.Items.Add("1200");
            this.cbxBaudRate.Items.Add("2400");
            this.cbxBaudRate.Items.Add("4800");
            this.cbxBaudRate.Items.Add("9600");
            this.cbxBaudRate.Items.Add("14400");
            this.cbxBaudRate.Items.Add("19200");
            this.cbxBaudRate.Items.Add("38400");
            this.cbxBaudRate.Items.Add("57600");
            this.cbxBaudRate.Items.Add("115200");
            this.cbxBaudRate.Location = new System.Drawing.Point(79, 43);
            this.cbxBaudRate.Name = "cbxBaudRate";
            this.cbxBaudRate.Size = new System.Drawing.Size(122, 23);
            this.cbxBaudRate.TabIndex = 6;
            // 
            // labBaudrate
            // 
            this.labBaudrate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labBaudrate.Location = new System.Drawing.Point(8, 41);
            this.labBaudrate.Name = "labBaudrate";
            this.labBaudrate.Size = new System.Drawing.Size(64, 21);
            this.labBaudrate.Text = "Baudrate";
            // 
            // chbxPortSettingFollowCOM1
            // 
            this.chbxPortSettingFollowCOM1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.chbxPortSettingFollowCOM1.Location = new System.Drawing.Point(238, 8);
            this.chbxPortSettingFollowCOM1.Name = "chbxPortSettingFollowCOM1";
            this.chbxPortSettingFollowCOM1.Size = new System.Drawing.Size(138, 20);
            this.chbxPortSettingFollowCOM1.TabIndex = 4;
            this.chbxPortSettingFollowCOM1.Text = "All follow COM 1";
            // 
            // cbxPort
            // 
            this.cbxPort.Items.Add("COM1");
            this.cbxPort.Items.Add("COM2");
            this.cbxPort.Items.Add("COM3");
            this.cbxPort.Items.Add("COM4");
            this.cbxPort.Location = new System.Drawing.Point(79, 7);
            this.cbxPort.Name = "cbxPort";
            this.cbxPort.Size = new System.Drawing.Size(122, 23);
            this.cbxPort.TabIndex = 2;
            this.cbxPort.SelectedIndexChanged += new System.EventHandler(this.cbxPort_SelectedIndexChanged);
            // 
            // labPort
            // 
            this.labPort.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labPort.Location = new System.Drawing.Point(8, 8);
            this.labPort.Name = "labPort";
            this.labPort.Size = new System.Drawing.Size(36, 22);
            this.labPort.Text = "Port";
            // 
            // panelHideControl_Serial
            // 
            this.panelHideControl_Serial.Controls.Add(this.chbxHide_Serial);
            this.panelHideControl_Serial.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHideControl_Serial.Location = new System.Drawing.Point(0, 0);
            this.panelHideControl_Serial.Name = "panelHideControl_Serial";
            this.panelHideControl_Serial.Size = new System.Drawing.Size(758, 30);
            // 
            // chbxHide_Serial
            // 
            this.chbxHide_Serial.Location = new System.Drawing.Point(8, 5);
            this.chbxHide_Serial.Name = "chbxHide_Serial";
            this.chbxHide_Serial.Size = new System.Drawing.Size(168, 20);
            this.chbxHide_Serial.TabIndex = 1;
            this.chbxHide_Serial.Text = "Hide Setting Panel";
            this.chbxHide_Serial.CheckStateChanged += new System.EventHandler(this.chbxHide_CheckStateChanged);
            // 
            // Form_APAX_5090
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(766, 434);
            this.Controls.Add(this.StatusBar_IO);
            this.Controls.Add(this.Btn_Quit);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.tcRemote);
            this.Name = "Form_APAX_5090";
            this.Text = "APAX_5090";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form_APAX_5090_Closing);
            this.tabModuleInfo.ResumeLayout(false);
            this.tcRemote.ResumeLayout(false);
            this.tabSerial.ResumeLayout(false);
            this.panelInfo_Serial.ResumeLayout(false);
            this.panelConfig_Serial.ResumeLayout(false);
            this.panelHideControl_Serial.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.StatusBar StatusBar_IO;
        private System.Windows.Forms.Button btnLocate;
        private System.Windows.Forms.Label lblLocate;
        private System.Windows.Forms.TextBox txtModule;
        private System.Windows.Forms.Label labModule;
        private System.Windows.Forms.Label labID;
        private System.Windows.Forms.Label labFwVer;
        internal System.Windows.Forms.Button Btn_Quit;
        private System.Windows.Forms.TextBox txtID;
        internal System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TabPage tabModuleInfo;
        private System.Windows.Forms.TextBox txtFwVer;
        private System.Windows.Forms.TextBox txtSupportKernelFw;
        private System.Windows.Forms.Label labSupportKernelFw;
        private System.Windows.Forms.TabControl tcRemote;
        private System.Windows.Forms.TabPage tabSerial;
        private System.Windows.Forms.Panel panelHideControl_Serial;
        private System.Windows.Forms.CheckBox chbxHide_Serial;
        private System.Windows.Forms.Panel panelConfig_Serial;
        private System.Windows.Forms.ComboBox cbxPort;
        private System.Windows.Forms.Label labPort;
        private System.Windows.Forms.Label labBaudrate;
        private System.Windows.Forms.CheckBox chbxPortSettingFollowCOM1;
        private System.Windows.Forms.ComboBox cbxParity;
        private System.Windows.Forms.Label labParity;
        private System.Windows.Forms.ComboBox cbxBaudRate;
        private System.Windows.Forms.Label labDatabit;
        private System.Windows.Forms.ComboBox cbxStopbit;
        private System.Windows.Forms.Label labStopbit;
        private System.Windows.Forms.ComboBox cbxDatabit;
        private System.Windows.Forms.Label labFlowCtrl;
        private System.Windows.Forms.ComboBox cbxFlowCtrl;
        private System.Windows.Forms.Button btnApplySetting;
        private System.Windows.Forms.Panel panelInfo_Serial;
        private System.Windows.Forms.ListView listViewComPortInfo;
        private System.Windows.Forms.ColumnHeader clmSerialItem;
        private System.Windows.Forms.ColumnHeader clmBaudrate;
        private System.Windows.Forms.ColumnHeader clmDatabit;
        private System.Windows.Forms.ColumnHeader clmParity;
        private System.Windows.Forms.ColumnHeader clmStopBit;
        private System.Windows.Forms.ColumnHeader clmFlowCtrl;
        private System.Windows.Forms.ColumnHeader clmMapTcpPort;
    }
}

