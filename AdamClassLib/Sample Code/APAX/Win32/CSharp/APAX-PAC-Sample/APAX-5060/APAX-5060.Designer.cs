namespace APAX_5060
{
    partial class Form_APAX_5060
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
            this.lblLocate = new System.Windows.Forms.Label();
            this.txtModule = new System.Windows.Forms.TextBox();
            this.labModule = new System.Windows.Forms.Label();
            this.labID = new System.Windows.Forms.Label();
            this.labFwVer = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtFwVer = new System.Windows.Forms.TextBox();
            this.txtSupportKernelFw = new System.Windows.Forms.TextBox();
            this.labSupportKernelFw = new System.Windows.Forms.Label();
            this.tabDO = new System.Windows.Forms.TabPage();
            this.listViewChInfo = new System.Windows.Forms.ListView();
            this.clmType = new System.Windows.Forms.ColumnHeader();
            this.clmCh = new System.Windows.Forms.ColumnHeader();
            this.clmValue = new System.Windows.Forms.ColumnHeader();
            this.clmMode = new System.Windows.Forms.ColumnHeader();
            this.clmSafety = new System.Windows.Forms.ColumnHeader();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSetSafetyValue = new System.Windows.Forms.Button();
            this.chbxEnableSafety = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panelSetting = new System.Windows.Forms.Panel();
            this.btnTrue = new System.Windows.Forms.Button();
            this.btnFalse = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.chbxHide = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabModuleInfo.SuspendLayout();
            this.tabDO.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelSetting.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // Btn_Quit
            // 
            this.Btn_Quit.Location = new System.Drawing.Point(409, 335);
            this.Btn_Quit.Name = "Btn_Quit";
            this.Btn_Quit.Size = new System.Drawing.Size(73, 21);
            this.Btn_Quit.TabIndex = 21;
            this.Btn_Quit.Text = "Quit";
            this.Btn_Quit.Click += new System.EventHandler(this.Btn_Quit_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(330, 335);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(73, 21);
            this.btnStart.TabIndex = 20;
            this.btnStart.Text = "Start";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // StatusBar_IO
            // 
            this.StatusBar_IO.Location = new System.Drawing.Point(0, 363);
            this.StatusBar_IO.Name = "StatusBar_IO";
            this.StatusBar_IO.Size = new System.Drawing.Size(486, 24);
            this.StatusBar_IO.TabIndex = 22;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabModuleInfo);
            this.tabControl1.Controls.Add(this.tabDO);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(486, 333);
            this.tabControl1.TabIndex = 19;
            this.tabControl1.Visible = false;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
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
            this.tabModuleInfo.Location = new System.Drawing.Point(4, 22);
            this.tabModuleInfo.Name = "tabModuleInfo";
            this.tabModuleInfo.Size = new System.Drawing.Size(478, 307);
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
            // lblLocate
            // 
            this.lblLocate.Location = new System.Drawing.Point(4, 129);
            this.lblLocate.Name = "lblLocate";
            this.lblLocate.Size = new System.Drawing.Size(56, 20);
            this.lblLocate.TabIndex = 53;
            this.lblLocate.Text = "Locate:";
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
            // tabDO
            // 
            this.tabDO.Controls.Add(this.listViewChInfo);
            this.tabDO.Controls.Add(this.panel1);
            this.tabDO.Controls.Add(this.panelMain);
            this.tabDO.Location = new System.Drawing.Point(4, 22);
            this.tabDO.Name = "tabDO";
            this.tabDO.Size = new System.Drawing.Size(478, 307);
            this.tabDO.TabIndex = 1;
            this.tabDO.Text = "DO";
            // 
            // listViewChInfo
            // 
            this.listViewChInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmType,
            this.clmCh,
            this.clmValue,
            this.clmMode,
            this.clmSafety});
            this.listViewChInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewChInfo.FullRowSelect = true;
            this.listViewChInfo.Location = new System.Drawing.Point(0, 78);
            this.listViewChInfo.Name = "listViewChInfo";
            this.listViewChInfo.Size = new System.Drawing.Size(478, 229);
            this.listViewChInfo.TabIndex = 2;
            this.listViewChInfo.UseCompatibleStateImageBehavior = false;
            this.listViewChInfo.View = System.Windows.Forms.View.Details;
            this.listViewChInfo.ItemActivate += new System.EventHandler(this.listViewChInfo_DoubleClick);
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
            // clmMode
            // 
            this.clmMode.Text = "Mode";
            // 
            // clmSafety
            // 
            this.clmSafety.Text = "Safety Value";
            this.clmSafety.Width = 150;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.Controls.Add(this.btnSetSafetyValue);
            this.panel1.Controls.Add(this.chbxEnableSafety);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.panelSetting);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(478, 46);
            this.panel1.TabIndex = 3;
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
            // panelMain
            // 
            this.panelMain.Controls.Add(this.chbxHide);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(478, 32);
            this.panelMain.TabIndex = 4;
            // 
            // chbxHide
            // 
            this.chbxHide.Location = new System.Drawing.Point(8, 8);
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
            // Form_APAX_5060
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 387);
            this.Controls.Add(this.Btn_Quit);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.StatusBar_IO);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form_APAX_5060";
            this.Text = "APAX-5060";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_APAX_5060_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabModuleInfo.ResumeLayout(false);
            this.tabModuleInfo.PerformLayout();
            this.tabDO.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelSetting.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button Btn_Quit;
        internal System.Windows.Forms.Button btnStart;
        internal System.Windows.Forms.StatusBar StatusBar_IO;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabModuleInfo;
        private System.Windows.Forms.Button btnLocate;
        private System.Windows.Forms.Label lblLocate;
        private System.Windows.Forms.TextBox txtModule;
        private System.Windows.Forms.Label labModule;
        private System.Windows.Forms.Label labID;
        private System.Windows.Forms.Label labFwVer;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtFwVer;
        private System.Windows.Forms.TextBox txtSupportKernelFw;
        private System.Windows.Forms.Label labSupportKernelFw;
        private System.Windows.Forms.TabPage tabDO;
        private System.Windows.Forms.ListView listViewChInfo;
        private System.Windows.Forms.ColumnHeader clmType;
        private System.Windows.Forms.ColumnHeader clmCh;
        private System.Windows.Forms.ColumnHeader clmValue;
        private System.Windows.Forms.ColumnHeader clmMode;
        private System.Windows.Forms.ColumnHeader clmSafety;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSetSafetyValue;
        private System.Windows.Forms.CheckBox chbxEnableSafety;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelSetting;
        private System.Windows.Forms.Button btnTrue;
        private System.Windows.Forms.Button btnFalse;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.CheckBox chbxHide;
        private System.Windows.Forms.Timer timer1;
    }
}

