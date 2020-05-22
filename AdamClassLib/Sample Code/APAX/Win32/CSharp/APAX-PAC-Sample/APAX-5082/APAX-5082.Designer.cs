namespace APAX_5082
{
    partial class Form_APAX_5082
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
            this.Btn_Quit = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkBoxDiFilterEnable = new System.Windows.Forms.CheckBox();
            this.btnApplySetting = new System.Windows.Forms.Button();
            this.labUnit = new System.Windows.Forms.Label();
            this.txtCntMin = new System.Windows.Forms.TextBox();
            this.labelCntMin = new System.Windows.Forms.Label();
            this.panelMain_DI = new System.Windows.Forms.Panel();
            this.chbxHide_DI = new System.Windows.Forms.CheckBox();
            this.tabDO = new System.Windows.Forms.TabPage();
            this.listViewChInfo_DO = new System.Windows.Forms.ListView();
            this.clmDOType = new System.Windows.Forms.ColumnHeader();
            this.clmDOCh = new System.Windows.Forms.ColumnHeader();
            this.clmDOValue = new System.Windows.Forms.ColumnHeader();
            this.clmDOMode = new System.Windows.Forms.ColumnHeader();
            this.clmDOSafety = new System.Windows.Forms.ColumnHeader();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSetSafetyValue = new System.Windows.Forms.Button();
            this.chbxEnableSafety = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panelSetting = new System.Windows.Forms.Panel();
            this.btnTrue = new System.Windows.Forms.Button();
            this.btnFalse = new System.Windows.Forms.Button();
            this.panelMain_DO = new System.Windows.Forms.Panel();
            this.chbxHide_DO = new System.Windows.Forms.CheckBox();
            this.tabPWM = new System.Windows.Forms.TabPage();
            this.listViewChInfo_PWM = new System.Windows.Forms.ListView();
            this.clmPWMType = new System.Windows.Forms.ColumnHeader();
            this.clmPWMCh = new System.Windows.Forms.ColumnHeader();
            this.clmPWMStatus = new System.Windows.Forms.ColumnHeader();
            this.clmPWMFreq = new System.Windows.Forms.ColumnHeader();
            this.clmPWMDutyCycle = new System.Windows.Forms.ColumnHeader();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chbxApplyAll = new System.Windows.Forms.CheckBox();
            this.btnMaskDisable = new System.Windows.Forms.Button();
            this.btnMaskEnable = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPwmApplySetting = new System.Windows.Forms.Button();
            this.txtDutyCycle = new System.Windows.Forms.TextBox();
            this.txtFrequency = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panelMain_PWM = new System.Windows.Forms.Panel();
            this.chbxHide_PWM = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabModuleInfo.SuspendLayout();
            this.tabDI.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelMain_DI.SuspendLayout();
            this.tabDO.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelSetting.SuspendLayout();
            this.panelMain_DO.SuspendLayout();
            this.tabPWM.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelMain_PWM.SuspendLayout();
            this.SuspendLayout();
            // 
            // Btn_Quit
            // 
            this.Btn_Quit.Location = new System.Drawing.Point(550, 374);
            this.Btn_Quit.Name = "Btn_Quit";
            this.Btn_Quit.Size = new System.Drawing.Size(73, 21);
            this.Btn_Quit.TabIndex = 37;
            this.Btn_Quit.Text = "Quit";
            this.Btn_Quit.Click += new System.EventHandler(this.Btn_Quit_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(471, 374);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(73, 21);
            this.btnStart.TabIndex = 36;
            this.btnStart.Text = "Start";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // StatusBar_IO
            // 
            this.StatusBar_IO.Location = new System.Drawing.Point(0, 401);
            this.StatusBar_IO.Name = "StatusBar_IO";
            this.StatusBar_IO.Size = new System.Drawing.Size(627, 24);
            this.StatusBar_IO.TabIndex = 38;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabModuleInfo);
            this.tabControl1.Controls.Add(this.tabDI);
            this.tabControl1.Controls.Add(this.tabDO);
            this.tabControl1.Controls.Add(this.tabPWM);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(627, 368);
            this.tabControl1.TabIndex = 35;
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
            this.tabModuleInfo.Size = new System.Drawing.Size(619, 342);
            this.tabModuleInfo.TabIndex = 0;
            this.tabModuleInfo.Text = "Module Information";
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
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 51;
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
            this.labModule.TabIndex = 52;
            this.labModule.Text = "Module :";
            // 
            // labID
            // 
            this.labID.Location = new System.Drawing.Point(4, 40);
            this.labID.Name = "labID";
            this.labID.Size = new System.Drawing.Size(100, 20);
            this.labID.TabIndex = 53;
            this.labID.Text = "Switch ID :";
            // 
            // labFwVer
            // 
            this.labFwVer.Location = new System.Drawing.Point(4, 100);
            this.labFwVer.Name = "labFwVer";
            this.labFwVer.Size = new System.Drawing.Size(125, 20);
            this.labFwVer.TabIndex = 54;
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
            this.labSupportKernelFw.TabIndex = 55;
            this.labSupportKernelFw.Text = "Support Kernel Fw:";
            // 
            // tabDI
            // 
            this.tabDI.Controls.Add(this.listViewChInfo_DI);
            this.tabDI.Controls.Add(this.panel1);
            this.tabDI.Controls.Add(this.panelMain_DI);
            this.tabDI.Location = new System.Drawing.Point(4, 22);
            this.tabDI.Name = "tabDI";
            this.tabDI.Size = new System.Drawing.Size(619, 342);
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
            this.listViewChInfo_DI.Location = new System.Drawing.Point(0, 101);
            this.listViewChInfo_DI.Name = "listViewChInfo_DI";
            this.listViewChInfo_DI.Size = new System.Drawing.Size(619, 241);
            this.listViewChInfo_DI.TabIndex = 7;
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.Controls.Add(this.chkBoxDiFilterEnable);
            this.panel1.Controls.Add(this.btnApplySetting);
            this.panel1.Controls.Add(this.labUnit);
            this.panel1.Controls.Add(this.txtCntMin);
            this.panel1.Controls.Add(this.labelCntMin);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(619, 71);
            this.panel1.TabIndex = 8;
            // 
            // chkBoxDiFilterEnable
            // 
            this.chkBoxDiFilterEnable.Checked = true;
            this.chkBoxDiFilterEnable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBoxDiFilterEnable.Enabled = false;
            this.chkBoxDiFilterEnable.Location = new System.Drawing.Point(8, 6);
            this.chkBoxDiFilterEnable.Name = "chkBoxDiFilterEnable";
            this.chkBoxDiFilterEnable.Size = new System.Drawing.Size(160, 24);
            this.chkBoxDiFilterEnable.TabIndex = 5;
            this.chkBoxDiFilterEnable.Text = "DI Filter Enable";
            // 
            // btnApplySetting
            // 
            this.btnApplySetting.Location = new System.Drawing.Point(352, 38);
            this.btnApplySetting.Name = "btnApplySetting";
            this.btnApplySetting.Size = new System.Drawing.Size(88, 24);
            this.btnApplySetting.TabIndex = 6;
            this.btnApplySetting.Text = "Apply";
            this.btnApplySetting.Click += new System.EventHandler(this.btnApplySetting_Click);
            // 
            // labUnit
            // 
            this.labUnit.Location = new System.Drawing.Point(288, 38);
            this.labUnit.Name = "labUnit";
            this.labUnit.Size = new System.Drawing.Size(58, 24);
            this.labUnit.TabIndex = 7;
            this.labUnit.Text = "0.1 ms";
            // 
            // txtCntMin
            // 
            this.txtCntMin.Location = new System.Drawing.Point(228, 38);
            this.txtCntMin.MaxLength = 10;
            this.txtCntMin.Name = "txtCntMin";
            this.txtCntMin.Size = new System.Drawing.Size(54, 22);
            this.txtCntMin.TabIndex = 8;
            // 
            // labelCntMin
            // 
            this.labelCntMin.Location = new System.Drawing.Point(8, 38);
            this.labelCntMin.Name = "labelCntMin";
            this.labelCntMin.Size = new System.Drawing.Size(231, 24);
            this.labelCntMin.TabIndex = 9;
            this.labelCntMin.Text = "Minimum low signal width (5~400)";
            // 
            // panelMain_DI
            // 
            this.panelMain_DI.Controls.Add(this.chbxHide_DI);
            this.panelMain_DI.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMain_DI.Location = new System.Drawing.Point(0, 0);
            this.panelMain_DI.Name = "panelMain_DI";
            this.panelMain_DI.Size = new System.Drawing.Size(619, 30);
            this.panelMain_DI.TabIndex = 9;
            // 
            // chbxHide_DI
            // 
            this.chbxHide_DI.Location = new System.Drawing.Point(8, 5);
            this.chbxHide_DI.Name = "chbxHide_DI";
            this.chbxHide_DI.Size = new System.Drawing.Size(168, 20);
            this.chbxHide_DI.TabIndex = 1;
            this.chbxHide_DI.Text = "Hide Setting Panel";
            this.chbxHide_DI.CheckedChanged += new System.EventHandler(this.chbxHide_DI_CheckedChanged);
            // 
            // tabDO
            // 
            this.tabDO.Controls.Add(this.listViewChInfo_DO);
            this.tabDO.Controls.Add(this.panel2);
            this.tabDO.Controls.Add(this.panelMain_DO);
            this.tabDO.Location = new System.Drawing.Point(4, 22);
            this.tabDO.Name = "tabDO";
            this.tabDO.Size = new System.Drawing.Size(619, 342);
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
            this.clmDOSafety});
            this.listViewChInfo_DO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewChInfo_DO.FullRowSelect = true;
            this.listViewChInfo_DO.Location = new System.Drawing.Point(0, 76);
            this.listViewChInfo_DO.Name = "listViewChInfo_DO";
            this.listViewChInfo_DO.Size = new System.Drawing.Size(619, 266);
            this.listViewChInfo_DO.TabIndex = 6;
            this.listViewChInfo_DO.UseCompatibleStateImageBehavior = false;
            this.listViewChInfo_DO.View = System.Windows.Forms.View.Details;
            this.listViewChInfo_DO.ItemActivate += new System.EventHandler(this.listViewChInfo_DO_DoubleClick);
            // 
            // clmDOType
            // 
            this.clmDOType.Text = "Type";
            // 
            // clmDOCh
            // 
            this.clmDOCh.Text = "CH";
            // 
            // clmDOValue
            // 
            this.clmDOValue.Text = "Value";
            // 
            // clmDOMode
            // 
            this.clmDOMode.Text = "Mode";
            // 
            // clmDOSafety
            // 
            this.clmDOSafety.Text = "Safety Value";
            this.clmDOSafety.Width = 150;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SkyBlue;
            this.panel2.Controls.Add(this.btnSetSafetyValue);
            this.panel2.Controls.Add(this.chbxEnableSafety);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.panelSetting);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 30);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(619, 46);
            this.panel2.TabIndex = 7;
            // 
            // btnSetSafetyValue
            // 
            this.btnSetSafetyValue.Enabled = false;
            this.btnSetSafetyValue.Location = new System.Drawing.Point(354, 11);
            this.btnSetSafetyValue.Name = "btnSetSafetyValue";
            this.btnSetSafetyValue.Size = new System.Drawing.Size(84, 24);
            this.btnSetSafetyValue.TabIndex = 4;
            this.btnSetSafetyValue.Text = "Set Value";
            this.btnSetSafetyValue.Click += new System.EventHandler(this.btnSetSafetyValue_Click);
            // 
            // chbxEnableSafety
            // 
            this.chbxEnableSafety.Location = new System.Drawing.Point(272, 13);
            this.chbxEnableSafety.Name = "chbxEnableSafety";
            this.chbxEnableSafety.Size = new System.Drawing.Size(76, 20);
            this.chbxEnableSafety.TabIndex = 5;
            this.chbxEnableSafety.Text = "Enable";
            this.chbxEnableSafety.CheckedChanged += new System.EventHandler(this.chbxEnableSafety_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(174, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Safety Function";
            // 
            // panelSetting
            // 
            this.panelSetting.BackColor = System.Drawing.Color.SkyBlue;
            this.panelSetting.Controls.Add(this.btnTrue);
            this.panelSetting.Controls.Add(this.btnFalse);
            this.panelSetting.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSetting.Location = new System.Drawing.Point(0, 0);
            this.panelSetting.Name = "panelSetting";
            this.panelSetting.Size = new System.Drawing.Size(166, 46);
            this.panelSetting.TabIndex = 7;
            // 
            // btnTrue
            // 
            this.btnTrue.Location = new System.Drawing.Point(7, 11);
            this.btnTrue.Name = "btnTrue";
            this.btnTrue.Size = new System.Drawing.Size(72, 24);
            this.btnTrue.TabIndex = 0;
            this.btnTrue.Text = "Set True";
            this.btnTrue.Click += new System.EventHandler(this.btnTrue_Click);
            // 
            // btnFalse
            // 
            this.btnFalse.Location = new System.Drawing.Point(87, 11);
            this.btnFalse.Name = "btnFalse";
            this.btnFalse.Size = new System.Drawing.Size(72, 24);
            this.btnFalse.TabIndex = 1;
            this.btnFalse.Text = "Set False";
            this.btnFalse.Click += new System.EventHandler(this.btnFalse_Click);
            // 
            // panelMain_DO
            // 
            this.panelMain_DO.Controls.Add(this.chbxHide_DO);
            this.panelMain_DO.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMain_DO.Location = new System.Drawing.Point(0, 0);
            this.panelMain_DO.Name = "panelMain_DO";
            this.panelMain_DO.Size = new System.Drawing.Size(619, 30);
            this.panelMain_DO.TabIndex = 8;
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
            // tabPWM
            // 
            this.tabPWM.Controls.Add(this.listViewChInfo_PWM);
            this.tabPWM.Controls.Add(this.panel3);
            this.tabPWM.Controls.Add(this.panelMain_PWM);
            this.tabPWM.Location = new System.Drawing.Point(4, 22);
            this.tabPWM.Name = "tabPWM";
            this.tabPWM.Size = new System.Drawing.Size(619, 342);
            this.tabPWM.TabIndex = 3;
            this.tabPWM.Text = "PWM";
            // 
            // listViewChInfo_PWM
            // 
            this.listViewChInfo_PWM.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmPWMType,
            this.clmPWMCh,
            this.clmPWMStatus,
            this.clmPWMFreq,
            this.clmPWMDutyCycle});
            this.listViewChInfo_PWM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewChInfo_PWM.FullRowSelect = true;
            this.listViewChInfo_PWM.Location = new System.Drawing.Point(0, 205);
            this.listViewChInfo_PWM.Name = "listViewChInfo_PWM";
            this.listViewChInfo_PWM.Size = new System.Drawing.Size(619, 137);
            this.listViewChInfo_PWM.TabIndex = 5;
            this.listViewChInfo_PWM.UseCompatibleStateImageBehavior = false;
            this.listViewChInfo_PWM.View = System.Windows.Forms.View.Details;
            // 
            // clmPWMType
            // 
            this.clmPWMType.Text = "Type";
            // 
            // clmPWMCh
            // 
            this.clmPWMCh.Text = "CH";
            this.clmPWMCh.Width = 50;
            // 
            // clmPWMStatus
            // 
            this.clmPWMStatus.Text = "Status";
            // 
            // clmPWMFreq
            // 
            this.clmPWMFreq.Text = "Frequency (Hz)";
            this.clmPWMFreq.Width = 120;
            // 
            // clmPWMDutyCycle
            // 
            this.clmPWMDutyCycle.Text = "Duty Cycle (%)";
            this.clmPWMDutyCycle.Width = 120;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.SkyBlue;
            this.panel3.Controls.Add(this.chbxApplyAll);
            this.panel3.Controls.Add(this.btnMaskDisable);
            this.panel3.Controls.Add(this.btnMaskEnable);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.btnPwmApplySetting);
            this.panel3.Controls.Add(this.txtDutyCycle);
            this.panel3.Controls.Add(this.txtFrequency);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 30);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(619, 175);
            this.panel3.TabIndex = 6;
            // 
            // chbxApplyAll
            // 
            this.chbxApplyAll.Location = new System.Drawing.Point(8, 6);
            this.chbxApplyAll.Name = "chbxApplyAll";
            this.chbxApplyAll.Size = new System.Drawing.Size(172, 20);
            this.chbxApplyAll.TabIndex = 17;
            this.chbxApplyAll.Text = "Apply to all channels";
            // 
            // btnMaskDisable
            // 
            this.btnMaskDisable.Location = new System.Drawing.Point(106, 142);
            this.btnMaskDisable.Name = "btnMaskDisable";
            this.btnMaskDisable.Size = new System.Drawing.Size(76, 20);
            this.btnMaskDisable.TabIndex = 16;
            this.btnMaskDisable.Text = "Stop";
            this.btnMaskDisable.Click += new System.EventHandler(this.btnMaskDisable_Click);
            // 
            // btnMaskEnable
            // 
            this.btnMaskEnable.Location = new System.Drawing.Point(8, 142);
            this.btnMaskEnable.Name = "btnMaskEnable";
            this.btnMaskEnable.Size = new System.Drawing.Size(76, 20);
            this.btnMaskEnable.TabIndex = 15;
            this.btnMaskEnable.Text = "Start";
            this.btnMaskEnable.Click += new System.EventHandler(this.btnMaskEnable_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label3.Location = new System.Drawing.Point(8, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(558, 61);
            this.label3.TabIndex = 18;
            this.label3.Text = "Note: Channel 0 and 1 output on the same base frequency, but duty cycle of both c" +
                "an be different. \r\n         (Channel 2, 3), (Channel 4, 5), (Channel 6, 7) have " +
                "the same restriction as (Channel 0, 1).";
            // 
            // btnPwmApplySetting
            // 
            this.btnPwmApplySetting.Location = new System.Drawing.Point(315, 26);
            this.btnPwmApplySetting.Name = "btnPwmApplySetting";
            this.btnPwmApplySetting.Size = new System.Drawing.Size(100, 32);
            this.btnPwmApplySetting.TabIndex = 14;
            this.btnPwmApplySetting.Text = "Apply";
            this.btnPwmApplySetting.Click += new System.EventHandler(this.btnPwmApplySetting_Click);
            // 
            // txtDutyCycle
            // 
            this.txtDutyCycle.Location = new System.Drawing.Point(188, 53);
            this.txtDutyCycle.MaxLength = 4;
            this.txtDutyCycle.Name = "txtDutyCycle";
            this.txtDutyCycle.Size = new System.Drawing.Size(100, 22);
            this.txtDutyCycle.TabIndex = 13;
            // 
            // txtFrequency
            // 
            this.txtFrequency.Location = new System.Drawing.Point(188, 29);
            this.txtFrequency.MaxLength = 5;
            this.txtFrequency.Name = "txtFrequency";
            this.txtFrequency.Size = new System.Drawing.Size(100, 22);
            this.txtFrequency.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(174, 20);
            this.label4.TabIndex = 19;
            this.label4.Text = "Duty Cycle (0.1 ~ 99.9%) :";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(174, 20);
            this.label5.TabIndex = 20;
            this.label5.Text = "Frequency (1 ~ 30K Hz) :";
            // 
            // panelMain_PWM
            // 
            this.panelMain_PWM.Controls.Add(this.chbxHide_PWM);
            this.panelMain_PWM.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMain_PWM.Location = new System.Drawing.Point(0, 0);
            this.panelMain_PWM.Name = "panelMain_PWM";
            this.panelMain_PWM.Size = new System.Drawing.Size(619, 30);
            this.panelMain_PWM.TabIndex = 7;
            // 
            // chbxHide_PWM
            // 
            this.chbxHide_PWM.Location = new System.Drawing.Point(8, 5);
            this.chbxHide_PWM.Name = "chbxHide_PWM";
            this.chbxHide_PWM.Size = new System.Drawing.Size(168, 20);
            this.chbxHide_PWM.TabIndex = 1;
            this.chbxHide_PWM.Text = "Hide Setting Panel";
            this.chbxHide_PWM.CheckedChanged += new System.EventHandler(this.chbxHide_PWM_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form_APAX_5082
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 425);
            this.Controls.Add(this.Btn_Quit);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.StatusBar_IO);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form_APAX_5082";
            this.Text = "APAX-5082";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_APAX_5082_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabModuleInfo.ResumeLayout(false);
            this.tabModuleInfo.PerformLayout();
            this.tabDI.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelMain_DI.ResumeLayout(false);
            this.tabDO.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panelSetting.ResumeLayout(false);
            this.panelMain_DO.ResumeLayout(false);
            this.tabPWM.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panelMain_PWM.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button Btn_Quit;
        internal System.Windows.Forms.Button btnStart;
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkBoxDiFilterEnable;
        private System.Windows.Forms.Button btnApplySetting;
        private System.Windows.Forms.Label labUnit;
        private System.Windows.Forms.TextBox txtCntMin;
        private System.Windows.Forms.Label labelCntMin;
        private System.Windows.Forms.Panel panelMain_DI;
        private System.Windows.Forms.CheckBox chbxHide_DI;
        private System.Windows.Forms.TabPage tabDO;
        private System.Windows.Forms.ListView listViewChInfo_DO;
        private System.Windows.Forms.ColumnHeader clmDOType;
        private System.Windows.Forms.ColumnHeader clmDOCh;
        private System.Windows.Forms.ColumnHeader clmDOValue;
        private System.Windows.Forms.ColumnHeader clmDOMode;
        private System.Windows.Forms.ColumnHeader clmDOSafety;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSetSafetyValue;
        private System.Windows.Forms.CheckBox chbxEnableSafety;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelSetting;
        private System.Windows.Forms.Button btnTrue;
        private System.Windows.Forms.Button btnFalse;
        private System.Windows.Forms.Panel panelMain_DO;
        private System.Windows.Forms.CheckBox chbxHide_DO;
        private System.Windows.Forms.TabPage tabPWM;
        private System.Windows.Forms.ListView listViewChInfo_PWM;
        private System.Windows.Forms.ColumnHeader clmPWMType;
        private System.Windows.Forms.ColumnHeader clmPWMCh;
        private System.Windows.Forms.ColumnHeader clmPWMStatus;
        private System.Windows.Forms.ColumnHeader clmPWMFreq;
        private System.Windows.Forms.ColumnHeader clmPWMDutyCycle;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox chbxApplyAll;
        private System.Windows.Forms.Button btnMaskDisable;
        private System.Windows.Forms.Button btnMaskEnable;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPwmApplySetting;
        private System.Windows.Forms.TextBox txtDutyCycle;
        private System.Windows.Forms.TextBox txtFrequency;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelMain_PWM;
        private System.Windows.Forms.CheckBox chbxHide_PWM;
        private System.Windows.Forms.Timer timer1;
    }
}

