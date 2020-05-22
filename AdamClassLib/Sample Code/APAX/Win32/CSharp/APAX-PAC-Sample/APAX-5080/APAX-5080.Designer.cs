namespace APAX_5080
{
    partial class Form_APAX_5080
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
            this.btnStart = new System.Windows.Forms.Button();
            this.Btn_Quit = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.StatusBar_IO = new System.Windows.Forms.StatusBar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabModuleInfo = new System.Windows.Forms.TabPage();
            this.btnLocate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtModule = new System.Windows.Forms.TextBox();
            this.labModule = new System.Windows.Forms.Label();
            this.labID = new System.Windows.Forms.Label();
            this.labFwVer = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtFwVer = new System.Windows.Forms.TextBox();
            this.txtSupportKernelFw = new System.Windows.Forms.TextBox();
            this.labSupportKernelFw = new System.Windows.Forms.Label();
            this.tabDI = new System.Windows.Forms.TabPage();
            this.listViewChInfo_DI = new System.Windows.Forms.ListView();
            this.clmDIType = new System.Windows.Forms.ColumnHeader();
            this.clmDICh = new System.Windows.Forms.ColumnHeader();
            this.clmDIValue = new System.Windows.Forms.ColumnHeader();
            this.clmDIMode = new System.Windows.Forms.ColumnHeader();
            this.tabDO = new System.Windows.Forms.TabPage();
            this.listViewChInfo_DO = new System.Windows.Forms.ListView();
            this.clmDOType = new System.Windows.Forms.ColumnHeader();
            this.clmDOCh = new System.Windows.Forms.ColumnHeader();
            this.clmDOValue = new System.Windows.Forms.ColumnHeader();
            this.clmDOMode = new System.Windows.Forms.ColumnHeader();
            this.clmDOAlarmType = new System.Windows.Forms.ColumnHeader();
            this.clmDOAlarmLimit = new System.Windows.Forms.ColumnHeader();
            this.clmDOAlarmFlag = new System.Windows.Forms.ColumnHeader();
            this.clmDOMapCh = new System.Windows.Forms.ColumnHeader();
            this.clmDOBehav = new System.Windows.Forms.ColumnHeader();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelAlarm = new System.Windows.Forms.Panel();
            this.btnAlarmClearall = new System.Windows.Forms.Button();
            this.btnAlarmClear = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panelDO = new System.Windows.Forms.Panel();
            this.btnTrue = new System.Windows.Forms.Button();
            this.btnFalse = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labHz = new System.Windows.Forms.Label();
            this.chbxApplyAll_DO = new System.Windows.Forms.CheckBox();
            this.txtMappingChannel = new System.Windows.Forms.TextBox();
            this.cbxLocalAlarmMapCh = new System.Windows.Forms.ComboBox();
            this.labLimitVal = new System.Windows.Forms.Label();
            this.txtLocalAlarmLimit = new System.Windows.Forms.TextBox();
            this.rbtnDO = new System.Windows.Forms.RadioButton();
            this.btnApplySetting = new System.Windows.Forms.Button();
            this.cbxAlarmType = new System.Windows.Forms.ComboBox();
            this.labMapCh = new System.Windows.Forms.Label();
            this.labAlarmType = new System.Windows.Forms.Label();
            this.labMode = new System.Windows.Forms.Label();
            this.rbtnAlarm = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDOPulseWidth = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxDOBehavior = new System.Windows.Forms.ComboBox();
            this.chbxAutoRL = new System.Windows.Forms.CheckBox();
            this.panelMain_DO = new System.Windows.Forms.Panel();
            this.chbxHide_DO = new System.Windows.Forms.CheckBox();
            this.tabCNT = new System.Windows.Forms.TabPage();
            this.listViewChInfo_CNT = new System.Windows.Forms.ListView();
            this.clmCNTType = new System.Windows.Forms.ColumnHeader();
            this.clmCNTCh = new System.Windows.Forms.ColumnHeader();
            this.clmCNTValue = new System.Windows.Forms.ColumnHeader();
            this.clmCNTMode = new System.Windows.Forms.ColumnHeader();
            this.clmCNTStartup = new System.Windows.Forms.ColumnHeader();
            this.clmCNTCounting = new System.Windows.Forms.ColumnHeader();
            this.clmCNTStatus = new System.Windows.Forms.ColumnHeader();
            this.clmCNTCountType = new System.Windows.Forms.ColumnHeader();
            this.clmCNTMapCh = new System.Windows.Forms.ColumnHeader();
            this.clmCNTGateActive = new System.Windows.Forms.ColumnHeader();
            this.clmCNTGateTrigger = new System.Windows.Forms.ColumnHeader();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelSetting = new System.Windows.Forms.Panel();
            this.txtFreqAcqTime = new System.Windows.Forms.TextBox();
            this.btnApplyFilter = new System.Windows.Forms.Button();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnFreqAcqTime = new System.Windows.Forms.Button();
            this.panelSelItems = new System.Windows.Forms.Panel();
            this.btnCNTStart = new System.Windows.Forms.Button();
            this.btnClrTriger = new System.Windows.Forms.Button();
            this.cbxTriggerMode = new System.Windows.Forms.ComboBox();
            this.cbxLocalGateMapCh = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chbxApplyAll_CNT = new System.Windows.Forms.CheckBox();
            this.chbxGateEnable = new System.Windows.Forms.CheckBox();
            this.btnApplyGateSetting = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.btnApplyCountType = new System.Windows.Forms.Button();
            this.chbxReloadToStartup = new System.Windows.Forms.CheckBox();
            this.chbxRepeat = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnClearOF = new System.Windows.Forms.Button();
            this.btnResetCnt = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnApplyStartup = new System.Windows.Forms.Button();
            this.btnApplySelRange = new System.Windows.Forms.Button();
            this.txtStartupVal = new System.Windows.Forms.TextBox();
            this.cbxRange = new System.Windows.Forms.ComboBox();
            this.labChMask = new System.Windows.Forms.Label();
            this.labRange = new System.Windows.Forms.Label();
            this.cbxGateType = new System.Windows.Forms.ComboBox();
            this.labGateType = new System.Windows.Forms.Label();
            this.labTriggerMode = new System.Windows.Forms.Label();
            this.labStartupVal = new System.Windows.Forms.Label();
            this.panelMain_CNT = new System.Windows.Forms.Panel();
            this.chbxShowRawData = new System.Windows.Forms.CheckBox();
            this.chbxHide_CNT = new System.Windows.Forms.CheckBox();
            this.tabControl1.SuspendLayout();
            this.tabModuleInfo.SuspendLayout();
            this.tabDI.SuspendLayout();
            this.tabDO.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelAlarm.SuspendLayout();
            this.panelDO.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panelMain_DO.SuspendLayout();
            this.tabCNT.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelSetting.SuspendLayout();
            this.panelSelItems.SuspendLayout();
            this.panelMain_CNT.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(480, 405);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(73, 21);
            this.btnStart.TabIndex = 58;
            this.btnStart.Text = "Start";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // Btn_Quit
            // 
            this.Btn_Quit.Location = new System.Drawing.Point(559, 405);
            this.Btn_Quit.Name = "Btn_Quit";
            this.Btn_Quit.Size = new System.Drawing.Size(73, 21);
            this.Btn_Quit.TabIndex = 57;
            this.Btn_Quit.Text = "Quit";
            this.Btn_Quit.Click += new System.EventHandler(this.Btn_Quit_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // StatusBar_IO
            // 
            this.StatusBar_IO.Location = new System.Drawing.Point(0, 436);
            this.StatusBar_IO.Name = "StatusBar_IO";
            this.StatusBar_IO.Size = new System.Drawing.Size(635, 24);
            this.StatusBar_IO.TabIndex = 59;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabModuleInfo);
            this.tabControl1.Controls.Add(this.tabDI);
            this.tabControl1.Controls.Add(this.tabDO);
            this.tabControl1.Controls.Add(this.tabCNT);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(635, 399);
            this.tabControl1.TabIndex = 56;
            this.tabControl1.Visible = false;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabModuleInfo
            // 
            this.tabModuleInfo.Controls.Add(this.btnLocate);
            this.tabModuleInfo.Controls.Add(this.label1);
            this.tabModuleInfo.Controls.Add(this.txtModule);
            this.tabModuleInfo.Controls.Add(this.labModule);
            this.tabModuleInfo.Controls.Add(this.labID);
            this.tabModuleInfo.Controls.Add(this.labFwVer);
            this.tabModuleInfo.Controls.Add(this.txtID);
            this.tabModuleInfo.Controls.Add(this.txtFwVer);
            this.tabModuleInfo.Controls.Add(this.txtSupportKernelFw);
            this.tabModuleInfo.Controls.Add(this.labSupportKernelFw);
            this.tabModuleInfo.Location = new System.Drawing.Point(4, 22);
            this.tabModuleInfo.Name = "tabModuleInfo";
            this.tabModuleInfo.Size = new System.Drawing.Size(627, 373);
            this.tabModuleInfo.TabIndex = 0;
            this.tabModuleInfo.Text = "Module Information";
            // 
            // btnLocate
            // 
            this.btnLocate.Location = new System.Drawing.Point(135, 129);
            this.btnLocate.Name = "btnLocate";
            this.btnLocate.Size = new System.Drawing.Size(72, 20);
            this.btnLocate.TabIndex = 52;
            this.btnLocate.Text = "Enable";
            this.btnLocate.Click += new System.EventHandler(this.btnLocate_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 53;
            this.label1.Text = "Locate";
            // 
            // txtModule
            // 
            this.txtModule.Location = new System.Drawing.Point(135, 9);
            this.txtModule.Name = "txtModule";
            this.txtModule.ReadOnly = true;
            this.txtModule.Size = new System.Drawing.Size(223, 22);
            this.txtModule.TabIndex = 18;
            // 
            // labModule
            // 
            this.labModule.Location = new System.Drawing.Point(4, 9);
            this.labModule.Name = "labModule";
            this.labModule.Size = new System.Drawing.Size(100, 20);
            this.labModule.TabIndex = 54;
            this.labModule.Text = "Module :";
            // 
            // labID
            // 
            this.labID.Location = new System.Drawing.Point(4, 40);
            this.labID.Name = "labID";
            this.labID.Size = new System.Drawing.Size(100, 20);
            this.labID.TabIndex = 55;
            this.labID.Text = "Switch ID :";
            // 
            // labFwVer
            // 
            this.labFwVer.Location = new System.Drawing.Point(4, 100);
            this.labFwVer.Name = "labFwVer";
            this.labFwVer.Size = new System.Drawing.Size(124, 20);
            this.labFwVer.TabIndex = 56;
            this.labFwVer.Text = "Firmware Version:";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(135, 40);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(223, 22);
            this.txtID.TabIndex = 23;
            // 
            // txtFwVer
            // 
            this.txtFwVer.Location = new System.Drawing.Point(135, 100);
            this.txtFwVer.Name = "txtFwVer";
            this.txtFwVer.ReadOnly = true;
            this.txtFwVer.Size = new System.Drawing.Size(223, 22);
            this.txtFwVer.TabIndex = 25;
            // 
            // txtSupportKernelFw
            // 
            this.txtSupportKernelFw.Location = new System.Drawing.Point(135, 69);
            this.txtSupportKernelFw.Name = "txtSupportKernelFw";
            this.txtSupportKernelFw.ReadOnly = true;
            this.txtSupportKernelFw.Size = new System.Drawing.Size(223, 22);
            this.txtSupportKernelFw.TabIndex = 26;
            // 
            // labSupportKernelFw
            // 
            this.labSupportKernelFw.Location = new System.Drawing.Point(4, 72);
            this.labSupportKernelFw.Name = "labSupportKernelFw";
            this.labSupportKernelFw.Size = new System.Drawing.Size(124, 20);
            this.labSupportKernelFw.TabIndex = 57;
            this.labSupportKernelFw.Text = "Support Kernel Fw:";
            // 
            // tabDI
            // 
            this.tabDI.Controls.Add(this.listViewChInfo_DI);
            this.tabDI.Location = new System.Drawing.Point(4, 22);
            this.tabDI.Name = "tabDI";
            this.tabDI.Size = new System.Drawing.Size(627, 373);
            this.tabDI.TabIndex = 1;
            this.tabDI.Text = "DI";
            // 
            // listViewChInfo_DI
            // 
            this.listViewChInfo_DI.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmDIType,
            this.clmDICh,
            this.clmDIValue,
            this.clmDIMode});
            this.listViewChInfo_DI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewChInfo_DI.FullRowSelect = true;
            this.listViewChInfo_DI.Location = new System.Drawing.Point(0, 0);
            this.listViewChInfo_DI.Name = "listViewChInfo_DI";
            this.listViewChInfo_DI.Size = new System.Drawing.Size(627, 373);
            this.listViewChInfo_DI.TabIndex = 4;
            this.listViewChInfo_DI.UseCompatibleStateImageBehavior = false;
            this.listViewChInfo_DI.View = System.Windows.Forms.View.Details;
            // 
            // clmDIType
            // 
            this.clmDIType.Text = "Type";
            // 
            // clmDICh
            // 
            this.clmDICh.Text = "CH";
            // 
            // clmDIValue
            // 
            this.clmDIValue.Text = "Value";
            // 
            // clmDIMode
            // 
            this.clmDIMode.Text = "Mode";
            // 
            // tabDO
            // 
            this.tabDO.Controls.Add(this.listViewChInfo_DO);
            this.tabDO.Controls.Add(this.panel2);
            this.tabDO.Controls.Add(this.panelMain_DO);
            this.tabDO.Location = new System.Drawing.Point(4, 22);
            this.tabDO.Name = "tabDO";
            this.tabDO.Size = new System.Drawing.Size(627, 373);
            this.tabDO.TabIndex = 2;
            this.tabDO.Text = "DO";
            // 
            // listViewChInfo_DO
            // 
            this.listViewChInfo_DO.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmDOType,
            this.clmDOCh,
            this.clmDOValue,
            this.clmDOMode,
            this.clmDOAlarmType,
            this.clmDOAlarmLimit,
            this.clmDOAlarmFlag,
            this.clmDOMapCh,
            this.clmDOBehav});
            this.listViewChInfo_DO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewChInfo_DO.FullRowSelect = true;
            this.listViewChInfo_DO.Location = new System.Drawing.Point(0, 178);
            this.listViewChInfo_DO.Name = "listViewChInfo_DO";
            this.listViewChInfo_DO.Size = new System.Drawing.Size(627, 195);
            this.listViewChInfo_DO.TabIndex = 2;
            this.listViewChInfo_DO.UseCompatibleStateImageBehavior = false;
            this.listViewChInfo_DO.View = System.Windows.Forms.View.Details;
            this.listViewChInfo_DO.ItemActivate += new System.EventHandler(this.listViewChInfo_DO_DoubleClick);
            this.listViewChInfo_DO.SelectedIndexChanged += new System.EventHandler(this.listViewChInfo_DO_SelectedIndexChanged);
            // 
            // clmDOType
            // 
            this.clmDOType.Text = "Type";
            this.clmDOType.Width = 40;
            // 
            // clmDOCh
            // 
            this.clmDOCh.Text = "CH";
            this.clmDOCh.Width = 30;
            // 
            // clmDOValue
            // 
            this.clmDOValue.Text = "DO Value";
            this.clmDOValue.Width = 65;
            // 
            // clmDOMode
            // 
            this.clmDOMode.Text = "Mode";
            this.clmDOMode.Width = 45;
            // 
            // clmDOAlarmType
            // 
            this.clmDOAlarmType.Text = "Alarm Type";
            this.clmDOAlarmType.Width = 80;
            // 
            // clmDOAlarmLimit
            // 
            this.clmDOAlarmLimit.Text = "Alarm Limit";
            this.clmDOAlarmLimit.Width = 80;
            // 
            // clmDOAlarmFlag
            // 
            this.clmDOAlarmFlag.Text = "Alarm Flag";
            this.clmDOAlarmFlag.Width = 80;
            // 
            // clmDOMapCh
            // 
            this.clmDOMapCh.Text = "Map Ch";
            this.clmDOMapCh.Width = 80;
            // 
            // clmDOBehav
            // 
            this.clmDOBehav.Text = "DO Behavior";
            this.clmDOBehav.Width = 100;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SkyBlue;
            this.panel2.Controls.Add(this.panelAlarm);
            this.panel2.Controls.Add(this.panelDO);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(627, 148);
            this.panel2.TabIndex = 3;
            // 
            // panelAlarm
            // 
            this.panelAlarm.BackColor = System.Drawing.Color.SkyBlue;
            this.panelAlarm.Controls.Add(this.btnAlarmClearall);
            this.panelAlarm.Controls.Add(this.btnAlarmClear);
            this.panelAlarm.Controls.Add(this.label2);
            this.panelAlarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAlarm.Location = new System.Drawing.Point(286, 112);
            this.panelAlarm.Name = "panelAlarm";
            this.panelAlarm.Size = new System.Drawing.Size(341, 36);
            this.panelAlarm.TabIndex = 0;
            // 
            // btnAlarmClearall
            // 
            this.btnAlarmClearall.Enabled = false;
            this.btnAlarmClearall.Location = new System.Drawing.Point(184, 6);
            this.btnAlarmClearall.Name = "btnAlarmClearall";
            this.btnAlarmClearall.Size = new System.Drawing.Size(109, 22);
            this.btnAlarmClearall.TabIndex = 0;
            this.btnAlarmClearall.Text = "Clear all";
            this.btnAlarmClearall.Click += new System.EventHandler(this.btnAlarmClearall_Click);
            // 
            // btnAlarmClear
            // 
            this.btnAlarmClear.Enabled = false;
            this.btnAlarmClear.Location = new System.Drawing.Point(64, 6);
            this.btnAlarmClear.Name = "btnAlarmClear";
            this.btnAlarmClear.Size = new System.Drawing.Size(109, 22);
            this.btnAlarmClear.TabIndex = 1;
            this.btnAlarmClear.Text = "Clear alarm latch";
            this.btnAlarmClear.Click += new System.EventHandler(this.btnAlarmClear_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Alarm:";
            // 
            // panelDO
            // 
            this.panelDO.BackColor = System.Drawing.Color.SkyBlue;
            this.panelDO.Controls.Add(this.btnTrue);
            this.panelDO.Controls.Add(this.btnFalse);
            this.panelDO.Controls.Add(this.label3);
            this.panelDO.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelDO.Location = new System.Drawing.Point(0, 112);
            this.panelDO.Name = "panelDO";
            this.panelDO.Size = new System.Drawing.Size(286, 36);
            this.panelDO.TabIndex = 1;
            // 
            // btnTrue
            // 
            this.btnTrue.Location = new System.Drawing.Point(61, 8);
            this.btnTrue.Name = "btnTrue";
            this.btnTrue.Size = new System.Drawing.Size(72, 20);
            this.btnTrue.TabIndex = 0;
            this.btnTrue.Text = "Set True";
            this.btnTrue.Click += new System.EventHandler(this.btnTrue_Click);
            // 
            // btnFalse
            // 
            this.btnFalse.Location = new System.Drawing.Point(141, 6);
            this.btnFalse.Name = "btnFalse";
            this.btnFalse.Size = new System.Drawing.Size(72, 22);
            this.btnFalse.TabIndex = 1;
            this.btnFalse.Text = "Set False";
            this.btnFalse.Click += new System.EventHandler(this.btnFalse_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "DO:";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.SkyBlue;
            this.panel4.Controls.Add(this.labHz);
            this.panel4.Controls.Add(this.chbxApplyAll_DO);
            this.panel4.Controls.Add(this.txtMappingChannel);
            this.panel4.Controls.Add(this.cbxLocalAlarmMapCh);
            this.panel4.Controls.Add(this.labLimitVal);
            this.panel4.Controls.Add(this.txtLocalAlarmLimit);
            this.panel4.Controls.Add(this.rbtnDO);
            this.panel4.Controls.Add(this.btnApplySetting);
            this.panel4.Controls.Add(this.cbxAlarmType);
            this.panel4.Controls.Add(this.labMapCh);
            this.panel4.Controls.Add(this.labAlarmType);
            this.panel4.Controls.Add(this.labMode);
            this.panel4.Controls.Add(this.rbtnAlarm);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.txtDOPulseWidth);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.cbxDOBehavior);
            this.panel4.Controls.Add(this.chbxAutoRL);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(627, 112);
            this.panel4.TabIndex = 2;
            // 
            // labHz
            // 
            this.labHz.Location = new System.Drawing.Point(477, 56);
            this.labHz.Name = "labHz";
            this.labHz.Size = new System.Drawing.Size(44, 18);
            this.labHz.TabIndex = 0;
            this.labHz.Text = "(Hz)";
            // 
            // chbxApplyAll_DO
            // 
            this.chbxApplyAll_DO.Location = new System.Drawing.Point(4, 7);
            this.chbxApplyAll_DO.Name = "chbxApplyAll_DO";
            this.chbxApplyAll_DO.Size = new System.Drawing.Size(159, 20);
            this.chbxApplyAll_DO.TabIndex = 5;
            this.chbxApplyAll_DO.Text = "Apply to All Channels";
            // 
            // txtMappingChannel
            // 
            this.txtMappingChannel.Location = new System.Drawing.Point(400, 30);
            this.txtMappingChannel.Name = "txtMappingChannel";
            this.txtMappingChannel.ReadOnly = true;
            this.txtMappingChannel.Size = new System.Drawing.Size(112, 22);
            this.txtMappingChannel.TabIndex = 1;
            // 
            // cbxLocalAlarmMapCh
            // 
            this.cbxLocalAlarmMapCh.Enabled = false;
            this.cbxLocalAlarmMapCh.Location = new System.Drawing.Point(338, 30);
            this.cbxLocalAlarmMapCh.Name = "cbxLocalAlarmMapCh";
            this.cbxLocalAlarmMapCh.Size = new System.Drawing.Size(56, 20);
            this.cbxLocalAlarmMapCh.TabIndex = 2;
            this.cbxLocalAlarmMapCh.SelectedIndexChanged += new System.EventHandler(this.cbxLocalAlarmMapCh_SelectedIndexChanged);
            // 
            // labLimitVal
            // 
            this.labLimitVal.Location = new System.Drawing.Point(231, 54);
            this.labLimitVal.Name = "labLimitVal";
            this.labLimitVal.Size = new System.Drawing.Size(88, 20);
            this.labLimitVal.TabIndex = 6;
            this.labLimitVal.Text = "Limit value :";
            // 
            // txtLocalAlarmLimit
            // 
            this.txtLocalAlarmLimit.Enabled = false;
            this.txtLocalAlarmLimit.Location = new System.Drawing.Point(400, 54);
            this.txtLocalAlarmLimit.Name = "txtLocalAlarmLimit";
            this.txtLocalAlarmLimit.Size = new System.Drawing.Size(70, 22);
            this.txtLocalAlarmLimit.TabIndex = 3;
            this.txtLocalAlarmLimit.Text = "0";
            // 
            // rbtnDO
            // 
            this.rbtnDO.Checked = true;
            this.rbtnDO.Location = new System.Drawing.Point(102, 30);
            this.rbtnDO.Name = "rbtnDO";
            this.rbtnDO.Size = new System.Drawing.Size(56, 20);
            this.rbtnDO.TabIndex = 4;
            this.rbtnDO.TabStop = true;
            this.rbtnDO.Text = "DO";
            // 
            // btnApplySetting
            // 
            this.btnApplySetting.Location = new System.Drawing.Point(477, 79);
            this.btnApplySetting.Name = "btnApplySetting";
            this.btnApplySetting.Size = new System.Drawing.Size(72, 22);
            this.btnApplySetting.TabIndex = 6;
            this.btnApplySetting.Text = "Apply";
            this.btnApplySetting.Click += new System.EventHandler(this.btnApplySetting_Click);
            // 
            // cbxAlarmType
            // 
            this.cbxAlarmType.Enabled = false;
            this.cbxAlarmType.Location = new System.Drawing.Point(102, 54);
            this.cbxAlarmType.Name = "cbxAlarmType";
            this.cbxAlarmType.Size = new System.Drawing.Size(94, 20);
            this.cbxAlarmType.TabIndex = 7;
            // 
            // labMapCh
            // 
            this.labMapCh.Location = new System.Drawing.Point(231, 30);
            this.labMapCh.Name = "labMapCh";
            this.labMapCh.Size = new System.Drawing.Size(115, 20);
            this.labMapCh.TabIndex = 8;
            this.labMapCh.Text = "Mapping channel:";
            // 
            // labAlarmType
            // 
            this.labAlarmType.Location = new System.Drawing.Point(6, 54);
            this.labAlarmType.Name = "labAlarmType";
            this.labAlarmType.Size = new System.Drawing.Size(100, 20);
            this.labAlarmType.TabIndex = 9;
            this.labAlarmType.Text = "Alarm Type:";
            // 
            // labMode
            // 
            this.labMode.Location = new System.Drawing.Point(6, 30);
            this.labMode.Name = "labMode";
            this.labMode.Size = new System.Drawing.Size(100, 20);
            this.labMode.TabIndex = 10;
            this.labMode.Text = "Mode:";
            // 
            // rbtnAlarm
            // 
            this.rbtnAlarm.Location = new System.Drawing.Point(155, 30);
            this.rbtnAlarm.Name = "rbtnAlarm";
            this.rbtnAlarm.Size = new System.Drawing.Size(68, 20);
            this.rbtnAlarm.TabIndex = 11;
            this.rbtnAlarm.Text = "Alarm";
            this.rbtnAlarm.CheckedChanged += new System.EventHandler(this.rbtnAlarm_CheckedChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 20);
            this.label4.TabIndex = 12;
            this.label4.Text = "DO behavior:";
            // 
            // txtDOPulseWidth
            // 
            this.txtDOPulseWidth.Enabled = false;
            this.txtDOPulseWidth.Location = new System.Drawing.Point(400, 78);
            this.txtDOPulseWidth.MaxLength = 6;
            this.txtDOPulseWidth.Name = "txtDOPulseWidth";
            this.txtDOPulseWidth.Size = new System.Drawing.Size(70, 22);
            this.txtDOPulseWidth.TabIndex = 14;
            this.txtDOPulseWidth.Text = "1";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(231, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "DO pulse width (ms):";
            // 
            // cbxDOBehavior
            // 
            this.cbxDOBehavior.Enabled = false;
            this.cbxDOBehavior.Location = new System.Drawing.Point(102, 78);
            this.cbxDOBehavior.Name = "cbxDOBehavior";
            this.cbxDOBehavior.Size = new System.Drawing.Size(94, 20);
            this.cbxDOBehavior.TabIndex = 16;
            // 
            // chbxAutoRL
            // 
            this.chbxAutoRL.Enabled = false;
            this.chbxAutoRL.Location = new System.Drawing.Point(514, 31);
            this.chbxAutoRL.Name = "chbxAutoRL";
            this.chbxAutoRL.Size = new System.Drawing.Size(72, 20);
            this.chbxAutoRL.TabIndex = 17;
            this.chbxAutoRL.Text = "AutoRL";
            // 
            // panelMain_DO
            // 
            this.panelMain_DO.Controls.Add(this.chbxHide_DO);
            this.panelMain_DO.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMain_DO.Location = new System.Drawing.Point(0, 0);
            this.panelMain_DO.Name = "panelMain_DO";
            this.panelMain_DO.Size = new System.Drawing.Size(627, 30);
            this.panelMain_DO.TabIndex = 4;
            // 
            // chbxHide_DO
            // 
            this.chbxHide_DO.Location = new System.Drawing.Point(8, 5);
            this.chbxHide_DO.Name = "chbxHide_DO";
            this.chbxHide_DO.Size = new System.Drawing.Size(168, 20);
            this.chbxHide_DO.TabIndex = 1;
            this.chbxHide_DO.Text = "Hide Setting Panel";
            this.chbxHide_DO.CheckedChanged += new System.EventHandler(this.chbxHide_DO_CheckedChanged);
            // 
            // tabCNT
            // 
            this.tabCNT.Controls.Add(this.listViewChInfo_CNT);
            this.tabCNT.Controls.Add(this.panel3);
            this.tabCNT.Controls.Add(this.panelMain_CNT);
            this.tabCNT.Location = new System.Drawing.Point(4, 22);
            this.tabCNT.Name = "tabCNT";
            this.tabCNT.Size = new System.Drawing.Size(627, 373);
            this.tabCNT.TabIndex = 3;
            this.tabCNT.Text = "CNT";
            // 
            // listViewChInfo_CNT
            // 
            this.listViewChInfo_CNT.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmCNTType,
            this.clmCNTCh,
            this.clmCNTValue,
            this.clmCNTMode,
            this.clmCNTStartup,
            this.clmCNTCounting,
            this.clmCNTStatus,
            this.clmCNTCountType,
            this.clmCNTMapCh,
            this.clmCNTGateActive,
            this.clmCNTGateTrigger});
            this.listViewChInfo_CNT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewChInfo_CNT.FullRowSelect = true;
            this.listViewChInfo_CNT.Location = new System.Drawing.Point(0, 229);
            this.listViewChInfo_CNT.Name = "listViewChInfo_CNT";
            this.listViewChInfo_CNT.Size = new System.Drawing.Size(627, 144);
            this.listViewChInfo_CNT.TabIndex = 5;
            this.listViewChInfo_CNT.UseCompatibleStateImageBehavior = false;
            this.listViewChInfo_CNT.View = System.Windows.Forms.View.Details;
            this.listViewChInfo_CNT.SelectedIndexChanged += new System.EventHandler(this.listViewChInfo_CNT_SelectedIndexChanged);
            // 
            // clmCNTType
            // 
            this.clmCNTType.Text = "Type";
            this.clmCNTType.Width = 40;
            // 
            // clmCNTCh
            // 
            this.clmCNTCh.Text = "Ch";
            this.clmCNTCh.Width = 30;
            // 
            // clmCNTValue
            // 
            this.clmCNTValue.Text = "Value";
            // 
            // clmCNTMode
            // 
            this.clmCNTMode.Text = "Mode";
            this.clmCNTMode.Width = 80;
            // 
            // clmCNTStartup
            // 
            this.clmCNTStartup.Text = "Startup";
            // 
            // clmCNTCounting
            // 
            this.clmCNTCounting.Text = "Counting";
            // 
            // clmCNTStatus
            // 
            this.clmCNTStatus.Text = "Status";
            this.clmCNTStatus.Width = 55;
            // 
            // clmCNTCountType
            // 
            this.clmCNTCountType.Text = "Count Type";
            this.clmCNTCountType.Width = 150;
            // 
            // clmCNTMapCh
            // 
            this.clmCNTMapCh.Text = "Map Ch";
            // 
            // clmCNTGateActive
            // 
            this.clmCNTGateActive.Text = "Gate Active";
            this.clmCNTGateActive.Width = 80;
            // 
            // clmCNTGateTrigger
            // 
            this.clmCNTGateTrigger.Text = "Gate Trigger";
            this.clmCNTGateTrigger.Width = 100;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SkyBlue;
            this.panel3.Controls.Add(this.panelSetting);
            this.panel3.Controls.Add(this.panelSelItems);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 30);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(627, 199);
            this.panel3.TabIndex = 6;
            // 
            // panelSetting
            // 
            this.panelSetting.BackColor = System.Drawing.Color.SkyBlue;
            this.panelSetting.Controls.Add(this.txtFreqAcqTime);
            this.panelSetting.Controls.Add(this.btnApplyFilter);
            this.panelSetting.Controls.Add(this.txtFilter);
            this.panelSetting.Controls.Add(this.label6);
            this.panelSetting.Controls.Add(this.label7);
            this.panelSetting.Controls.Add(this.btnFreqAcqTime);
            this.panelSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSetting.Location = new System.Drawing.Point(0, 162);
            this.panelSetting.Name = "panelSetting";
            this.panelSetting.Size = new System.Drawing.Size(627, 37);
            this.panelSetting.TabIndex = 0;
            // 
            // txtFreqAcqTime
            // 
            this.txtFreqAcqTime.Location = new System.Drawing.Point(483, 7);
            this.txtFreqAcqTime.MaxLength = 10;
            this.txtFreqAcqTime.Name = "txtFreqAcqTime";
            this.txtFreqAcqTime.Size = new System.Drawing.Size(55, 22);
            this.txtFreqAcqTime.TabIndex = 0;
            this.txtFreqAcqTime.Text = "1000";
            // 
            // btnApplyFilter
            // 
            this.btnApplyFilter.Location = new System.Drawing.Point(230, 6);
            this.btnApplyFilter.Name = "btnApplyFilter";
            this.btnApplyFilter.Size = new System.Drawing.Size(60, 24);
            this.btnApplyFilter.TabIndex = 1;
            this.btnApplyFilter.Text = "Apply";
            this.btnApplyFilter.Click += new System.EventHandler(this.btnApplyFilter_Click);
            // 
            // txtFilter
            // 
            this.txtFilter.Location = new System.Drawing.Point(178, 6);
            this.txtFilter.MaxLength = 10;
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(46, 22);
            this.txtFilter.TabIndex = 2;
            this.txtFilter.Text = "50";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(296, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(199, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "Freq.Acq. Time (1~10000 ms):";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(6, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(180, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "Digital filter (0~40000.0 us):";
            // 
            // btnFreqAcqTime
            // 
            this.btnFreqAcqTime.Location = new System.Drawing.Point(544, 7);
            this.btnFreqAcqTime.Name = "btnFreqAcqTime";
            this.btnFreqAcqTime.Size = new System.Drawing.Size(60, 24);
            this.btnFreqAcqTime.TabIndex = 6;
            this.btnFreqAcqTime.Text = "Apply";
            this.btnFreqAcqTime.Click += new System.EventHandler(this.btnFreqAcqTime_Click);
            // 
            // panelSelItems
            // 
            this.panelSelItems.BackColor = System.Drawing.Color.SkyBlue;
            this.panelSelItems.Controls.Add(this.btnCNTStart);
            this.panelSelItems.Controls.Add(this.btnClrTriger);
            this.panelSelItems.Controls.Add(this.cbxTriggerMode);
            this.panelSelItems.Controls.Add(this.cbxLocalGateMapCh);
            this.panelSelItems.Controls.Add(this.label8);
            this.panelSelItems.Controls.Add(this.chbxApplyAll_CNT);
            this.panelSelItems.Controls.Add(this.chbxGateEnable);
            this.panelSelItems.Controls.Add(this.btnApplyGateSetting);
            this.panelSelItems.Controls.Add(this.label9);
            this.panelSelItems.Controls.Add(this.btnApplyCountType);
            this.panelSelItems.Controls.Add(this.chbxReloadToStartup);
            this.panelSelItems.Controls.Add(this.chbxRepeat);
            this.panelSelItems.Controls.Add(this.label10);
            this.panelSelItems.Controls.Add(this.btnClearOF);
            this.panelSelItems.Controls.Add(this.btnResetCnt);
            this.panelSelItems.Controls.Add(this.btnStop);
            this.panelSelItems.Controls.Add(this.btnApplyStartup);
            this.panelSelItems.Controls.Add(this.btnApplySelRange);
            this.panelSelItems.Controls.Add(this.txtStartupVal);
            this.panelSelItems.Controls.Add(this.cbxRange);
            this.panelSelItems.Controls.Add(this.labChMask);
            this.panelSelItems.Controls.Add(this.labRange);
            this.panelSelItems.Controls.Add(this.cbxGateType);
            this.panelSelItems.Controls.Add(this.labGateType);
            this.panelSelItems.Controls.Add(this.labTriggerMode);
            this.panelSelItems.Controls.Add(this.labStartupVal);
            this.panelSelItems.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSelItems.Location = new System.Drawing.Point(0, 0);
            this.panelSelItems.Name = "panelSelItems";
            this.panelSelItems.Size = new System.Drawing.Size(627, 162);
            this.panelSelItems.TabIndex = 1;
            // 
            // btnCNTStart
            // 
            this.btnCNTStart.Location = new System.Drawing.Point(91, 88);
            this.btnCNTStart.Name = "btnCNTStart";
            this.btnCNTStart.Size = new System.Drawing.Size(60, 24);
            this.btnCNTStart.TabIndex = 25;
            this.btnCNTStart.Text = "Start";
            this.btnCNTStart.Click += new System.EventHandler(this.btnCNTStart_Click);
            // 
            // btnClrTriger
            // 
            this.btnClrTriger.Location = new System.Drawing.Point(453, 118);
            this.btnClrTriger.Name = "btnClrTriger";
            this.btnClrTriger.Size = new System.Drawing.Size(72, 24);
            this.btnClrTriger.TabIndex = 0;
            this.btnClrTriger.Text = "Clear";
            this.btnClrTriger.Click += new System.EventHandler(this.btnClrTriger_Click);
            // 
            // cbxTriggerMode
            // 
            this.cbxTriggerMode.Location = new System.Drawing.Point(479, 89);
            this.cbxTriggerMode.Name = "cbxTriggerMode";
            this.cbxTriggerMode.Size = new System.Drawing.Size(124, 20);
            this.cbxTriggerMode.TabIndex = 1;
            // 
            // cbxLocalGateMapCh
            // 
            this.cbxLocalGateMapCh.Location = new System.Drawing.Point(531, 30);
            this.cbxLocalGateMapCh.Name = "cbxLocalGateMapCh";
            this.cbxLocalGateMapCh.Size = new System.Drawing.Size(72, 20);
            this.cbxLocalGateMapCh.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(440, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 20);
            this.label8.TabIndex = 26;
            this.label8.Text = "Mapping gate:";
            // 
            // chbxApplyAll_CNT
            // 
            this.chbxApplyAll_CNT.Location = new System.Drawing.Point(8, 6);
            this.chbxApplyAll_CNT.Name = "chbxApplyAll_CNT";
            this.chbxApplyAll_CNT.Size = new System.Drawing.Size(168, 20);
            this.chbxApplyAll_CNT.TabIndex = 4;
            this.chbxApplyAll_CNT.Text = "Apply to All Channels";
            // 
            // chbxGateEnable
            // 
            this.chbxGateEnable.Location = new System.Drawing.Point(368, 31);
            this.chbxGateEnable.Name = "chbxGateEnable";
            this.chbxGateEnable.Size = new System.Drawing.Size(70, 20);
            this.chbxGateEnable.TabIndex = 4;
            this.chbxGateEnable.Text = "Enable";
            this.chbxGateEnable.CheckedChanged += new System.EventHandler(this.chbxGateEnable_CheckedChanged);
            // 
            // btnApplyGateSetting
            // 
            this.btnApplyGateSetting.Location = new System.Drawing.Point(531, 118);
            this.btnApplyGateSetting.Name = "btnApplyGateSetting";
            this.btnApplyGateSetting.Size = new System.Drawing.Size(72, 24);
            this.btnApplyGateSetting.TabIndex = 5;
            this.btnApplyGateSetting.Text = "Apply";
            this.btnApplyGateSetting.Click += new System.EventHandler(this.btnApplyGateSetting_Click);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(368, 6);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(134, 20);
            this.label9.TabIndex = 27;
            this.label9.Text = "Counter gate setting:";
            // 
            // btnApplyCountType
            // 
            this.btnApplyCountType.Location = new System.Drawing.Point(286, 118);
            this.btnApplyCountType.Name = "btnApplyCountType";
            this.btnApplyCountType.Size = new System.Drawing.Size(72, 24);
            this.btnApplyCountType.TabIndex = 7;
            this.btnApplyCountType.Text = "Apply";
            this.btnApplyCountType.Click += new System.EventHandler(this.btnApplyCountType_Click);
            // 
            // chbxReloadToStartup
            // 
            this.chbxReloadToStartup.Location = new System.Drawing.Point(91, 139);
            this.chbxReloadToStartup.Name = "chbxReloadToStartup";
            this.chbxReloadToStartup.Size = new System.Drawing.Size(148, 20);
            this.chbxReloadToStartup.TabIndex = 8;
            this.chbxReloadToStartup.Text = "Reload To Startup";
            // 
            // chbxRepeat
            // 
            this.chbxRepeat.Location = new System.Drawing.Point(91, 120);
            this.chbxRepeat.Name = "chbxRepeat";
            this.chbxRepeat.Size = new System.Drawing.Size(72, 20);
            this.chbxRepeat.TabIndex = 9;
            this.chbxRepeat.Text = "Repeat";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(8, 120);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 20);
            this.label10.TabIndex = 28;
            this.label10.Text = "Count Type:";
            // 
            // btnClearOF
            // 
            this.btnClearOF.Location = new System.Drawing.Point(286, 88);
            this.btnClearOF.Name = "btnClearOF";
            this.btnClearOF.Size = new System.Drawing.Size(72, 24);
            this.btnClearOF.TabIndex = 11;
            this.btnClearOF.Text = "Clear Flag";
            this.btnClearOF.Click += new System.EventHandler(this.btnClearOF_Click);
            // 
            // btnResetCnt
            // 
            this.btnResetCnt.Location = new System.Drawing.Point(221, 88);
            this.btnResetCnt.Name = "btnResetCnt";
            this.btnResetCnt.Size = new System.Drawing.Size(60, 24);
            this.btnResetCnt.TabIndex = 12;
            this.btnResetCnt.Text = "Reset";
            this.btnResetCnt.Click += new System.EventHandler(this.btnResetCnt_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(156, 88);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(60, 24);
            this.btnStop.TabIndex = 13;
            this.btnStop.Text = "Stop";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnApplyStartup
            // 
            this.btnApplyStartup.Location = new System.Drawing.Point(286, 60);
            this.btnApplyStartup.Name = "btnApplyStartup";
            this.btnApplyStartup.Size = new System.Drawing.Size(72, 24);
            this.btnApplyStartup.TabIndex = 15;
            this.btnApplyStartup.Text = "Apply";
            this.btnApplyStartup.Click += new System.EventHandler(this.btnApplyStartup_Click);
            // 
            // btnApplySelRange
            // 
            this.btnApplySelRange.Location = new System.Drawing.Point(286, 29);
            this.btnApplySelRange.Name = "btnApplySelRange";
            this.btnApplySelRange.Size = new System.Drawing.Size(72, 24);
            this.btnApplySelRange.TabIndex = 16;
            this.btnApplySelRange.Text = "Apply";
            this.btnApplySelRange.Click += new System.EventHandler(this.btnApplySelRange_Click);
            // 
            // txtStartupVal
            // 
            this.txtStartupVal.Location = new System.Drawing.Point(196, 61);
            this.txtStartupVal.MaxLength = 10;
            this.txtStartupVal.Name = "txtStartupVal";
            this.txtStartupVal.Size = new System.Drawing.Size(84, 22);
            this.txtStartupVal.TabIndex = 17;
            this.txtStartupVal.Text = "0";
            // 
            // cbxRange
            // 
            this.cbxRange.Location = new System.Drawing.Point(91, 30);
            this.cbxRange.Name = "cbxRange";
            this.cbxRange.Size = new System.Drawing.Size(189, 20);
            this.cbxRange.TabIndex = 18;
            // 
            // labChMask
            // 
            this.labChMask.Location = new System.Drawing.Point(8, 90);
            this.labChMask.Name = "labChMask";
            this.labChMask.Size = new System.Drawing.Size(86, 20);
            this.labChMask.TabIndex = 29;
            this.labChMask.Text = "Set Counter:";
            // 
            // labRange
            // 
            this.labRange.Location = new System.Drawing.Point(8, 31);
            this.labRange.Name = "labRange";
            this.labRange.Size = new System.Drawing.Size(100, 20);
            this.labRange.TabIndex = 30;
            this.labRange.Text = "CNT Mode :";
            // 
            // cbxGateType
            // 
            this.cbxGateType.Location = new System.Drawing.Point(479, 61);
            this.cbxGateType.Name = "cbxGateType";
            this.cbxGateType.Size = new System.Drawing.Size(124, 20);
            this.cbxGateType.TabIndex = 21;
            // 
            // labGateType
            // 
            this.labGateType.Location = new System.Drawing.Point(368, 62);
            this.labGateType.Name = "labGateType";
            this.labGateType.Size = new System.Drawing.Size(134, 20);
            this.labGateType.TabIndex = 31;
            this.labGateType.Text = "Gate Active Type:";
            // 
            // labTriggerMode
            // 
            this.labTriggerMode.Location = new System.Drawing.Point(368, 90);
            this.labTriggerMode.Name = "labTriggerMode";
            this.labTriggerMode.Size = new System.Drawing.Size(100, 20);
            this.labTriggerMode.TabIndex = 32;
            this.labTriggerMode.Text = "Trigger Mode:";
            // 
            // labStartupVal
            // 
            this.labStartupVal.Location = new System.Drawing.Point(8, 62);
            this.labStartupVal.Name = "labStartupVal";
            this.labStartupVal.Size = new System.Drawing.Size(208, 20);
            this.labStartupVal.TabIndex = 33;
            this.labStartupVal.Text = "Startup value (0~4294967295):";
            // 
            // panelMain_CNT
            // 
            this.panelMain_CNT.Controls.Add(this.chbxShowRawData);
            this.panelMain_CNT.Controls.Add(this.chbxHide_CNT);
            this.panelMain_CNT.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMain_CNT.Location = new System.Drawing.Point(0, 0);
            this.panelMain_CNT.Name = "panelMain_CNT";
            this.panelMain_CNT.Size = new System.Drawing.Size(627, 30);
            this.panelMain_CNT.TabIndex = 7;
            // 
            // chbxShowRawData
            // 
            this.chbxShowRawData.Location = new System.Drawing.Point(182, 5);
            this.chbxShowRawData.Name = "chbxShowRawData";
            this.chbxShowRawData.Size = new System.Drawing.Size(128, 20);
            this.chbxShowRawData.TabIndex = 31;
            this.chbxShowRawData.Text = "Show Raw Data";
            // 
            // chbxHide_CNT
            // 
            this.chbxHide_CNT.Location = new System.Drawing.Point(8, 5);
            this.chbxHide_CNT.Name = "chbxHide_CNT";
            this.chbxHide_CNT.Size = new System.Drawing.Size(168, 20);
            this.chbxHide_CNT.TabIndex = 1;
            this.chbxHide_CNT.Text = "Hide Setting Panel";
            this.chbxHide_CNT.CheckedChanged += new System.EventHandler(this.chbxHide_CNT_CheckedChanged);
            // 
            // Form_APAX_5080
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 460);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.Btn_Quit);
            this.Controls.Add(this.StatusBar_IO);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form_APAX_5080";
            this.Text = "APAX-5080";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_APAX_5080_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabModuleInfo.ResumeLayout(false);
            this.tabModuleInfo.PerformLayout();
            this.tabDI.ResumeLayout(false);
            this.tabDO.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panelAlarm.ResumeLayout(false);
            this.panelDO.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panelMain_DO.ResumeLayout(false);
            this.tabCNT.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panelSetting.ResumeLayout(false);
            this.panelSetting.PerformLayout();
            this.panelSelItems.ResumeLayout(false);
            this.panelSelItems.PerformLayout();
            this.panelMain_CNT.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button btnStart;
        internal System.Windows.Forms.Button Btn_Quit;
        private System.Windows.Forms.Timer timer1;
        internal System.Windows.Forms.StatusBar StatusBar_IO;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabModuleInfo;
        private System.Windows.Forms.Button btnLocate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtModule;
        private System.Windows.Forms.Label labModule;
        private System.Windows.Forms.Label labID;
        private System.Windows.Forms.Label labFwVer;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtFwVer;
        private System.Windows.Forms.TextBox txtSupportKernelFw;
        private System.Windows.Forms.Label labSupportKernelFw;
        private System.Windows.Forms.TabPage tabDI;
        private System.Windows.Forms.ListView listViewChInfo_DI;
        private System.Windows.Forms.ColumnHeader clmDIType;
        private System.Windows.Forms.ColumnHeader clmDICh;
        private System.Windows.Forms.ColumnHeader clmDIValue;
        private System.Windows.Forms.ColumnHeader clmDIMode;
        private System.Windows.Forms.TabPage tabDO;
        private System.Windows.Forms.ListView listViewChInfo_DO;
        private System.Windows.Forms.ColumnHeader clmDOType;
        private System.Windows.Forms.ColumnHeader clmDOCh;
        private System.Windows.Forms.ColumnHeader clmDOValue;
        private System.Windows.Forms.ColumnHeader clmDOMode;
        private System.Windows.Forms.ColumnHeader clmDOAlarmType;
        private System.Windows.Forms.ColumnHeader clmDOAlarmLimit;
        private System.Windows.Forms.ColumnHeader clmDOAlarmFlag;
        private System.Windows.Forms.ColumnHeader clmDOMapCh;
        private System.Windows.Forms.ColumnHeader clmDOBehav;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panelAlarm;
        private System.Windows.Forms.Button btnAlarmClearall;
        private System.Windows.Forms.Button btnAlarmClear;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelDO;
        private System.Windows.Forms.Button btnTrue;
        private System.Windows.Forms.Button btnFalse;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label labHz;
        private System.Windows.Forms.CheckBox chbxApplyAll_DO;
        private System.Windows.Forms.TextBox txtMappingChannel;
        private System.Windows.Forms.ComboBox cbxLocalAlarmMapCh;
        private System.Windows.Forms.Label labLimitVal;
        private System.Windows.Forms.TextBox txtLocalAlarmLimit;
        private System.Windows.Forms.RadioButton rbtnDO;
        private System.Windows.Forms.Button btnApplySetting;
        private System.Windows.Forms.ComboBox cbxAlarmType;
        private System.Windows.Forms.Label labMapCh;
        private System.Windows.Forms.Label labAlarmType;
        private System.Windows.Forms.Label labMode;
        private System.Windows.Forms.RadioButton rbtnAlarm;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDOPulseWidth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxDOBehavior;
        private System.Windows.Forms.CheckBox chbxAutoRL;
        private System.Windows.Forms.Panel panelMain_DO;
        private System.Windows.Forms.CheckBox chbxHide_DO;
        private System.Windows.Forms.TabPage tabCNT;
        private System.Windows.Forms.ListView listViewChInfo_CNT;
        private System.Windows.Forms.ColumnHeader clmCNTType;
        private System.Windows.Forms.ColumnHeader clmCNTCh;
        private System.Windows.Forms.ColumnHeader clmCNTValue;
        private System.Windows.Forms.ColumnHeader clmCNTMode;
        private System.Windows.Forms.ColumnHeader clmCNTStartup;
        private System.Windows.Forms.ColumnHeader clmCNTCounting;
        private System.Windows.Forms.ColumnHeader clmCNTStatus;
        private System.Windows.Forms.ColumnHeader clmCNTCountType;
        private System.Windows.Forms.ColumnHeader clmCNTMapCh;
        private System.Windows.Forms.ColumnHeader clmCNTGateActive;
        private System.Windows.Forms.ColumnHeader clmCNTGateTrigger;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelSetting;
        private System.Windows.Forms.TextBox txtFreqAcqTime;
        private System.Windows.Forms.Button btnApplyFilter;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnFreqAcqTime;
        private System.Windows.Forms.Panel panelSelItems;
        private System.Windows.Forms.Button btnCNTStart;
        private System.Windows.Forms.Button btnClrTriger;
        private System.Windows.Forms.ComboBox cbxTriggerMode;
        private System.Windows.Forms.ComboBox cbxLocalGateMapCh;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chbxApplyAll_CNT;
        private System.Windows.Forms.CheckBox chbxGateEnable;
        private System.Windows.Forms.Button btnApplyGateSetting;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnApplyCountType;
        private System.Windows.Forms.CheckBox chbxReloadToStartup;
        private System.Windows.Forms.CheckBox chbxRepeat;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnClearOF;
        private System.Windows.Forms.Button btnResetCnt;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnApplyStartup;
        private System.Windows.Forms.Button btnApplySelRange;
        private System.Windows.Forms.TextBox txtStartupVal;
        private System.Windows.Forms.ComboBox cbxRange;
        private System.Windows.Forms.Label labChMask;
        private System.Windows.Forms.Label labRange;
        private System.Windows.Forms.ComboBox cbxGateType;
        private System.Windows.Forms.Label labGateType;
        private System.Windows.Forms.Label labTriggerMode;
        private System.Windows.Forms.Label labStartupVal;
        private System.Windows.Forms.Panel panelMain_CNT;
        private System.Windows.Forms.CheckBox chbxShowRawData;
        private System.Windows.Forms.CheckBox chbxHide_CNT;
    }
}

