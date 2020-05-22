namespace APAX_5017PE
{
    partial class Form_APAX_5017PE
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabModuleInfo = new System.Windows.Forms.TabPage();
            this.btnLocate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labADVer = new System.Windows.Forms.Label();
            this.txtAIOFwVer = new System.Windows.Forms.TextBox();
            this.txtModule = new System.Windows.Forms.TextBox();
            this.labModule = new System.Windows.Forms.Label();
            this.labID = new System.Windows.Forms.Label();
            this.labFwVer = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtFwVer = new System.Windows.Forms.TextBox();
            this.txtSupportKernelFw = new System.Windows.Forms.TextBox();
            this.labSupportKernelFw = new System.Windows.Forms.Label();
            this.tabAI = new System.Windows.Forms.TabPage();
            this.listViewChInfo = new System.Windows.Forms.ListView();
            this.clmType = new System.Windows.Forms.ColumnHeader();
            this.clmCh = new System.Windows.Forms.ColumnHeader();
            this.clmValue = new System.Windows.Forms.ColumnHeader();
            this.clmChStatus = new System.Windows.Forms.ColumnHeader();
            this.clmRange = new System.Windows.Forms.ColumnHeader();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbxIntegration = new System.Windows.Forms.ComboBox();
            this.labIntegration = new System.Windows.Forms.Label();
            this.btnIntegration = new System.Windows.Forms.Button();
            this.btnMaskEnable = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnMaskDisable = new System.Windows.Forms.Button();
            this.cbxSampleRate = new System.Windows.Forms.ComboBox();
            this.labSampleRate = new System.Windows.Forms.Label();
            this.btnSampleRate = new System.Windows.Forms.Button();
            this.cbxBurnoutValue = new System.Windows.Forms.ComboBox();
            this.labBurnoutValue = new System.Windows.Forms.Label();
            this.cbxRange = new System.Windows.Forms.ComboBox();
            this.chkApplyAll = new System.Windows.Forms.CheckBox();
            this.btnApplySelRange = new System.Windows.Forms.Button();
            this.labRange = new System.Windows.Forms.Label();
            this.btnBurnoutValue = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.chbxShowRawData = new System.Windows.Forms.CheckBox();
            this.chbxHide = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Btn_Quit = new System.Windows.Forms.Button();
            this.StatusBar_IO = new System.Windows.Forms.StatusBar();
            this.tabControl1.SuspendLayout();
            this.tabModuleInfo.SuspendLayout();
            this.tabAI.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(468, 363);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(73, 21);
            this.btnStart.TabIndex = 36;
            this.btnStart.Text = "Start";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabModuleInfo);
            this.tabControl1.Controls.Add(this.tabAI);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(626, 360);
            this.tabControl1.TabIndex = 35;
            this.tabControl1.Visible = false;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabModuleInfo
            // 
            this.tabModuleInfo.Controls.Add(this.btnLocate);
            this.tabModuleInfo.Controls.Add(this.label1);
            this.tabModuleInfo.Controls.Add(this.labADVer);
            this.tabModuleInfo.Controls.Add(this.txtAIOFwVer);
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
            this.tabModuleInfo.Size = new System.Drawing.Size(618, 334);
            this.tabModuleInfo.TabIndex = 0;
            this.tabModuleInfo.Text = "Module Information";
            // 
            // btnLocate
            // 
            this.btnLocate.Location = new System.Drawing.Point(157, 163);
            this.btnLocate.Name = "btnLocate";
            this.btnLocate.Size = new System.Drawing.Size(72, 20);
            this.btnLocate.TabIndex = 50;
            this.btnLocate.Text = "Enable";
            this.btnLocate.Click += new System.EventHandler(this.btnLocate_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 51;
            this.label1.Text = "Locate";
            // 
            // labADVer
            // 
            this.labADVer.Location = new System.Drawing.Point(4, 135);
            this.labADVer.Name = "labADVer";
            this.labADVer.Size = new System.Drawing.Size(149, 20);
            this.labADVer.TabIndex = 52;
            this.labADVer.Text = "AIO Firmware Version :";
            // 
            // txtAIOFwVer
            // 
            this.txtAIOFwVer.Location = new System.Drawing.Point(157, 134);
            this.txtAIOFwVer.Name = "txtAIOFwVer";
            this.txtAIOFwVer.ReadOnly = true;
            this.txtAIOFwVer.Size = new System.Drawing.Size(208, 22);
            this.txtAIOFwVer.TabIndex = 41;
            // 
            // txtModule
            // 
            this.txtModule.Location = new System.Drawing.Point(157, 9);
            this.txtModule.Name = "txtModule";
            this.txtModule.ReadOnly = true;
            this.txtModule.Size = new System.Drawing.Size(208, 22);
            this.txtModule.TabIndex = 36;
            // 
            // labModule
            // 
            this.labModule.Location = new System.Drawing.Point(4, 10);
            this.labModule.Name = "labModule";
            this.labModule.Size = new System.Drawing.Size(100, 20);
            this.labModule.TabIndex = 53;
            this.labModule.Text = "Module :";
            // 
            // labID
            // 
            this.labID.Location = new System.Drawing.Point(4, 42);
            this.labID.Name = "labID";
            this.labID.Size = new System.Drawing.Size(100, 20);
            this.labID.TabIndex = 54;
            this.labID.Text = "Switch ID :";
            // 
            // labFwVer
            // 
            this.labFwVer.Location = new System.Drawing.Point(4, 103);
            this.labFwVer.Name = "labFwVer";
            this.labFwVer.Size = new System.Drawing.Size(124, 20);
            this.labFwVer.TabIndex = 55;
            this.labFwVer.Text = "Firmware Version:";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(157, 41);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(208, 22);
            this.txtID.TabIndex = 37;
            // 
            // txtFwVer
            // 
            this.txtFwVer.Location = new System.Drawing.Point(157, 102);
            this.txtFwVer.Name = "txtFwVer";
            this.txtFwVer.ReadOnly = true;
            this.txtFwVer.Size = new System.Drawing.Size(208, 22);
            this.txtFwVer.TabIndex = 39;
            // 
            // txtSupportKernelFw
            // 
            this.txtSupportKernelFw.Location = new System.Drawing.Point(157, 70);
            this.txtSupportKernelFw.Name = "txtSupportKernelFw";
            this.txtSupportKernelFw.ReadOnly = true;
            this.txtSupportKernelFw.Size = new System.Drawing.Size(208, 22);
            this.txtSupportKernelFw.TabIndex = 40;
            // 
            // labSupportKernelFw
            // 
            this.labSupportKernelFw.Location = new System.Drawing.Point(4, 71);
            this.labSupportKernelFw.Name = "labSupportKernelFw";
            this.labSupportKernelFw.Size = new System.Drawing.Size(124, 20);
            this.labSupportKernelFw.TabIndex = 56;
            this.labSupportKernelFw.Text = "Support Kernel Fw:";
            // 
            // tabAI
            // 
            this.tabAI.Controls.Add(this.listViewChInfo);
            this.tabAI.Controls.Add(this.panel1);
            this.tabAI.Controls.Add(this.panelMain);
            this.tabAI.Location = new System.Drawing.Point(4, 22);
            this.tabAI.Name = "tabAI";
            this.tabAI.Size = new System.Drawing.Size(618, 334);
            this.tabAI.TabIndex = 1;
            this.tabAI.Text = "AI";
            // 
            // listViewChInfo
            // 
            this.listViewChInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmType,
            this.clmCh,
            this.clmValue,
            this.clmChStatus,
            this.clmRange});
            this.listViewChInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewChInfo.FullRowSelect = true;
            this.listViewChInfo.Location = new System.Drawing.Point(0, 210);
            this.listViewChInfo.Name = "listViewChInfo";
            this.listViewChInfo.Size = new System.Drawing.Size(618, 124);
            this.listViewChInfo.TabIndex = 2;
            this.listViewChInfo.UseCompatibleStateImageBehavior = false;
            this.listViewChInfo.View = System.Windows.Forms.View.Details;
            this.listViewChInfo.SelectedIndexChanged += new System.EventHandler(this.listViewChInfo_SelectedIndexChanged);
            // 
            // clmType
            // 
            this.clmType.Text = "Type";
            // 
            // clmCh
            // 
            this.clmCh.Text = "CH";
            // 
            // clmValue
            // 
            this.clmValue.Text = "Value";
            // 
            // clmChStatus
            // 
            this.clmChStatus.Text = "Ch Status";
            this.clmChStatus.Width = 91;
            // 
            // clmRange
            // 
            this.clmRange.Text = "Range";
            this.clmRange.Width = 200;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.Controls.Add(this.cbxIntegration);
            this.panel1.Controls.Add(this.labIntegration);
            this.panel1.Controls.Add(this.btnIntegration);
            this.panel1.Controls.Add(this.btnMaskEnable);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnMaskDisable);
            this.panel1.Controls.Add(this.cbxSampleRate);
            this.panel1.Controls.Add(this.labSampleRate);
            this.panel1.Controls.Add(this.btnSampleRate);
            this.panel1.Controls.Add(this.cbxBurnoutValue);
            this.panel1.Controls.Add(this.labBurnoutValue);
            this.panel1.Controls.Add(this.cbxRange);
            this.panel1.Controls.Add(this.chkApplyAll);
            this.panel1.Controls.Add(this.btnApplySelRange);
            this.panel1.Controls.Add(this.labRange);
            this.panel1.Controls.Add(this.btnBurnoutValue);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(618, 182);
            this.panel1.TabIndex = 3;
            // 
            // cbxIntegration
            // 
            this.cbxIntegration.Location = new System.Drawing.Point(163, 93);
            this.cbxIntegration.Name = "cbxIntegration";
            this.cbxIntegration.Size = new System.Drawing.Size(181, 20);
            this.cbxIntegration.TabIndex = 58;
            // 
            // labIntegration
            // 
            this.labIntegration.Location = new System.Drawing.Point(8, 94);
            this.labIntegration.Name = "labIntegration";
            this.labIntegration.Size = new System.Drawing.Size(118, 20);
            this.labIntegration.TabIndex = 59;
            this.labIntegration.Text = "Integration Time :";
            // 
            // btnIntegration
            // 
            this.btnIntegration.Location = new System.Drawing.Point(360, 92);
            this.btnIntegration.Name = "btnIntegration";
            this.btnIntegration.Size = new System.Drawing.Size(86, 24);
            this.btnIntegration.TabIndex = 59;
            this.btnIntegration.Text = "Apply";
            this.btnIntegration.Click += new System.EventHandler(this.btnIntegration_Click);
            // 
            // btnMaskEnable
            // 
            this.btnMaskEnable.Location = new System.Drawing.Point(163, 64);
            this.btnMaskEnable.Name = "btnMaskEnable";
            this.btnMaskEnable.Size = new System.Drawing.Size(71, 24);
            this.btnMaskEnable.TabIndex = 54;
            this.btnMaskEnable.Text = "Enable";
            this.btnMaskEnable.Click += new System.EventHandler(this.btnMaskEnable_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 20);
            this.label2.TabIndex = 60;
            this.label2.Text = "Channel Mask :";
            // 
            // btnMaskDisable
            // 
            this.btnMaskDisable.Location = new System.Drawing.Point(273, 64);
            this.btnMaskDisable.Name = "btnMaskDisable";
            this.btnMaskDisable.Size = new System.Drawing.Size(71, 24);
            this.btnMaskDisable.TabIndex = 55;
            this.btnMaskDisable.Text = "Disable";
            this.btnMaskDisable.Click += new System.EventHandler(this.btnMaskDisable_Click);
            // 
            // cbxSampleRate
            // 
            this.cbxSampleRate.Location = new System.Drawing.Point(163, 149);
            this.cbxSampleRate.Name = "cbxSampleRate";
            this.cbxSampleRate.Size = new System.Drawing.Size(181, 20);
            this.cbxSampleRate.TabIndex = 47;
            // 
            // labSampleRate
            // 
            this.labSampleRate.Location = new System.Drawing.Point(8, 150);
            this.labSampleRate.Name = "labSampleRate";
            this.labSampleRate.Size = new System.Drawing.Size(153, 20);
            this.labSampleRate.TabIndex = 61;
            this.labSampleRate.Text = "Sampling Rate (Hz/Ch):";
            // 
            // btnSampleRate
            // 
            this.btnSampleRate.Location = new System.Drawing.Point(360, 148);
            this.btnSampleRate.Name = "btnSampleRate";
            this.btnSampleRate.Size = new System.Drawing.Size(86, 24);
            this.btnSampleRate.TabIndex = 48;
            this.btnSampleRate.Text = "Apply";
            this.btnSampleRate.Click += new System.EventHandler(this.btnSampleRate_Click);
            // 
            // cbxBurnoutValue
            // 
            this.cbxBurnoutValue.Location = new System.Drawing.Point(163, 121);
            this.cbxBurnoutValue.Name = "cbxBurnoutValue";
            this.cbxBurnoutValue.Size = new System.Drawing.Size(181, 20);
            this.cbxBurnoutValue.TabIndex = 40;
            // 
            // labBurnoutValue
            // 
            this.labBurnoutValue.Location = new System.Drawing.Point(8, 122);
            this.labBurnoutValue.Name = "labBurnoutValue";
            this.labBurnoutValue.Size = new System.Drawing.Size(153, 20);
            this.labBurnoutValue.TabIndex = 62;
            this.labBurnoutValue.Text = "Burnout Detect Mode :";
            // 
            // cbxRange
            // 
            this.cbxRange.Location = new System.Drawing.Point(163, 37);
            this.cbxRange.Name = "cbxRange";
            this.cbxRange.Size = new System.Drawing.Size(181, 20);
            this.cbxRange.TabIndex = 41;
            // 
            // chkApplyAll
            // 
            this.chkApplyAll.Location = new System.Drawing.Point(8, 6);
            this.chkApplyAll.Name = "chkApplyAll";
            this.chkApplyAll.Size = new System.Drawing.Size(203, 24);
            this.chkApplyAll.TabIndex = 42;
            this.chkApplyAll.Text = "Apply to All Channels";
            // 
            // btnApplySelRange
            // 
            this.btnApplySelRange.Location = new System.Drawing.Point(360, 36);
            this.btnApplySelRange.Name = "btnApplySelRange";
            this.btnApplySelRange.Size = new System.Drawing.Size(86, 24);
            this.btnApplySelRange.TabIndex = 43;
            this.btnApplySelRange.Text = "Apply";
            this.btnApplySelRange.Click += new System.EventHandler(this.btnApplySelRange_Click);
            // 
            // labRange
            // 
            this.labRange.Location = new System.Drawing.Point(8, 38);
            this.labRange.Name = "labRange";
            this.labRange.Size = new System.Drawing.Size(118, 20);
            this.labRange.TabIndex = 63;
            this.labRange.Text = "Range :";
            // 
            // btnBurnoutValue
            // 
            this.btnBurnoutValue.Location = new System.Drawing.Point(360, 120);
            this.btnBurnoutValue.Name = "btnBurnoutValue";
            this.btnBurnoutValue.Size = new System.Drawing.Size(86, 24);
            this.btnBurnoutValue.TabIndex = 44;
            this.btnBurnoutValue.Text = "Apply";
            this.btnBurnoutValue.Click += new System.EventHandler(this.btnBurnoutValue_Click);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.chbxShowRawData);
            this.panelMain.Controls.Add(this.chbxHide);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(618, 28);
            this.panelMain.TabIndex = 4;
            // 
            // chbxShowRawData
            // 
            this.chbxShowRawData.Location = new System.Drawing.Point(176, 3);
            this.chbxShowRawData.Name = "chbxShowRawData";
            this.chbxShowRawData.Size = new System.Drawing.Size(128, 20);
            this.chbxShowRawData.TabIndex = 30;
            this.chbxShowRawData.Text = "Show Raw Data";
            // 
            // chbxHide
            // 
            this.chbxHide.Location = new System.Drawing.Point(8, 5);
            this.chbxHide.Name = "chbxHide";
            this.chbxHide.Size = new System.Drawing.Size(168, 20);
            this.chbxHide.TabIndex = 1;
            this.chbxHide.Text = "Hide Setting Panel";
            this.chbxHide.CheckedChanged += new System.EventHandler(this.chbxHide_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Btn_Quit
            // 
            this.Btn_Quit.Location = new System.Drawing.Point(547, 363);
            this.Btn_Quit.Name = "Btn_Quit";
            this.Btn_Quit.Size = new System.Drawing.Size(73, 21);
            this.Btn_Quit.TabIndex = 37;
            this.Btn_Quit.Text = "Quit";
            this.Btn_Quit.Click += new System.EventHandler(this.Btn_Quit_Click);
            // 
            // StatusBar_IO
            // 
            this.StatusBar_IO.Location = new System.Drawing.Point(0, 389);
            this.StatusBar_IO.Name = "StatusBar_IO";
            this.StatusBar_IO.Size = new System.Drawing.Size(626, 24);
            this.StatusBar_IO.TabIndex = 38;
            // 
            // Form_APAX_5017PE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 413);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.Btn_Quit);
            this.Controls.Add(this.StatusBar_IO);
            this.Name = "Form_APAX_5017PE";
            this.Text = "APAX-5017PE";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_APAX_5017_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabModuleInfo.ResumeLayout(false);
            this.tabModuleInfo.PerformLayout();
            this.tabAI.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabModuleInfo;
        private System.Windows.Forms.Button btnLocate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labADVer;
        private System.Windows.Forms.TextBox txtAIOFwVer;
        private System.Windows.Forms.TextBox txtModule;
        private System.Windows.Forms.Label labModule;
        private System.Windows.Forms.Label labID;
        private System.Windows.Forms.Label labFwVer;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtFwVer;
        private System.Windows.Forms.TextBox txtSupportKernelFw;
        private System.Windows.Forms.Label labSupportKernelFw;
        private System.Windows.Forms.TabPage tabAI;
        private System.Windows.Forms.ListView listViewChInfo;
        private System.Windows.Forms.ColumnHeader clmType;
        private System.Windows.Forms.ColumnHeader clmCh;
        private System.Windows.Forms.ColumnHeader clmValue;
        private System.Windows.Forms.ColumnHeader clmChStatus;
        private System.Windows.Forms.ColumnHeader clmRange;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbxIntegration;
        private System.Windows.Forms.Label labIntegration;
        private System.Windows.Forms.Button btnIntegration;
        private System.Windows.Forms.Button btnMaskEnable;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnMaskDisable;
        private System.Windows.Forms.ComboBox cbxSampleRate;
        private System.Windows.Forms.Label labSampleRate;
        private System.Windows.Forms.Button btnSampleRate;
        private System.Windows.Forms.ComboBox cbxBurnoutValue;
        private System.Windows.Forms.Label labBurnoutValue;
        private System.Windows.Forms.ComboBox cbxRange;
        private System.Windows.Forms.CheckBox chkApplyAll;
        private System.Windows.Forms.Button btnApplySelRange;
        private System.Windows.Forms.Label labRange;
        private System.Windows.Forms.Button btnBurnoutValue;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.CheckBox chbxShowRawData;
        private System.Windows.Forms.CheckBox chbxHide;
        private System.Windows.Forms.Timer timer1;
        internal System.Windows.Forms.Button Btn_Quit;
        internal System.Windows.Forms.StatusBar StatusBar_IO;
    }
}

