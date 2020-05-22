namespace APAX_5028
{
    partial class Form_APAX_5028
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
            this.tabAO = new System.Windows.Forms.TabPage();
            this.listViewChInfo = new System.Windows.Forms.ListView();
            this.clmType = new System.Windows.Forms.ColumnHeader();
            this.clmCh = new System.Windows.Forms.ColumnHeader();
            this.clmValue = new System.Windows.Forms.ColumnHeader();
            this.clmRange = new System.Windows.Forms.ColumnHeader();
            this.clmStart = new System.Windows.Forms.ColumnHeader();
            this.clmSafety = new System.Windows.Forms.ColumnHeader();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelSafetyFunction = new System.Windows.Forms.Panel();
            this.btnSetSafetyValue = new System.Windows.Forms.Button();
            this.chbxEnableSafety = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panelSetting = new System.Windows.Forms.Panel();
            this.chbxApplyAll = new System.Windows.Forms.CheckBox();
            this.cbxRange = new System.Windows.Forms.ComboBox();
            this.labRange = new System.Windows.Forms.Label();
            this.btnApplySelRange = new System.Windows.Forms.Button();
            this.panelOutputValue = new System.Windows.Forms.Panel();
            this.txtSelChannel = new System.Windows.Forms.TextBox();
            this.btnSetAsSafety = new System.Windows.Forms.Button();
            this.btnApplyOutput = new System.Windows.Forms.Button();
            this.labLow = new System.Windows.Forms.Label();
            this.labHigh = new System.Windows.Forms.Label();
            this.tBarOutputVal = new System.Windows.Forms.TrackBar();
            this.txtOutputVal = new System.Windows.Forms.TextBox();
            this.labOutputVal = new System.Windows.Forms.Label();
            this.btnSetAsStartup = new System.Windows.Forms.Button();
            this.labChannel = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.chbxShowRawData = new System.Windows.Forms.CheckBox();
            this.chbxHide = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabModuleInfo.SuspendLayout();
            this.tabAO.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelSafetyFunction.SuspendLayout();
            this.panelSetting.SuspendLayout();
            this.panelOutputValue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tBarOutputVal)).BeginInit();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // Btn_Quit
            // 
            this.Btn_Quit.Location = new System.Drawing.Point(508, 339);
            this.Btn_Quit.Name = "Btn_Quit";
            this.Btn_Quit.Size = new System.Drawing.Size(73, 21);
            this.Btn_Quit.TabIndex = 31;
            this.Btn_Quit.Text = "Quit";
            this.Btn_Quit.Click += new System.EventHandler(this.Btn_Quit_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(429, 339);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(73, 21);
            this.btnStart.TabIndex = 30;
            this.btnStart.Text = "Start";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // StatusBar_IO
            // 
            this.StatusBar_IO.Location = new System.Drawing.Point(0, 366);
            this.StatusBar_IO.Name = "StatusBar_IO";
            this.StatusBar_IO.Size = new System.Drawing.Size(584, 24);
            this.StatusBar_IO.TabIndex = 32;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabModuleInfo);
            this.tabControl1.Controls.Add(this.tabAO);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(584, 333);
            this.tabControl1.TabIndex = 29;
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
            this.tabModuleInfo.Size = new System.Drawing.Size(576, 307);
            this.tabModuleInfo.TabIndex = 0;
            this.tabModuleInfo.Text = "Module Information";
            // 
            // btnLocate
            // 
            this.btnLocate.Location = new System.Drawing.Point(135, 129);
            this.btnLocate.Name = "btnLocate";
            this.btnLocate.Size = new System.Drawing.Size(72, 20);
            this.btnLocate.TabIndex = 31;
            this.btnLocate.Text = "Enable";
            this.btnLocate.Click += new System.EventHandler(this.btnLocate_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 32;
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
            this.labModule.TabIndex = 33;
            this.labModule.Text = "Module :";
            // 
            // labID
            // 
            this.labID.Location = new System.Drawing.Point(4, 40);
            this.labID.Name = "labID";
            this.labID.Size = new System.Drawing.Size(100, 20);
            this.labID.TabIndex = 34;
            this.labID.Text = "Switch ID :";
            // 
            // labFwVer
            // 
            this.labFwVer.Location = new System.Drawing.Point(4, 100);
            this.labFwVer.Name = "labFwVer";
            this.labFwVer.Size = new System.Drawing.Size(124, 20);
            this.labFwVer.TabIndex = 35;
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
            this.labSupportKernelFw.TabIndex = 36;
            this.labSupportKernelFw.Text = "Support Kernel Fw:";
            // 
            // tabAO
            // 
            this.tabAO.Controls.Add(this.listViewChInfo);
            this.tabAO.Controls.Add(this.panel1);
            this.tabAO.Controls.Add(this.panelMain);
            this.tabAO.Location = new System.Drawing.Point(4, 22);
            this.tabAO.Name = "tabAO";
            this.tabAO.Size = new System.Drawing.Size(576, 307);
            this.tabAO.TabIndex = 1;
            this.tabAO.Text = "AO";
            // 
            // listViewChInfo
            // 
            this.listViewChInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmType,
            this.clmCh,
            this.clmValue,
            this.clmRange,
            this.clmStart,
            this.clmSafety});
            this.listViewChInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewChInfo.FullRowSelect = true;
            this.listViewChInfo.Location = new System.Drawing.Point(0, 192);
            this.listViewChInfo.Name = "listViewChInfo";
            this.listViewChInfo.Size = new System.Drawing.Size(576, 115);
            this.listViewChInfo.TabIndex = 2;
            this.listViewChInfo.UseCompatibleStateImageBehavior = false;
            this.listViewChInfo.View = System.Windows.Forms.View.Details;
            this.listViewChInfo.SelectedIndexChanged += new System.EventHandler(this.listViewChInfo_SelectedIndexChanged);
            // 
            // clmType
            // 
            this.clmType.Text = "Type";
            this.clmType.Width = 40;
            // 
            // clmCh
            // 
            this.clmCh.Text = "CH";
            this.clmCh.Width = 40;
            // 
            // clmValue
            // 
            this.clmValue.Text = "Value";
            // 
            // clmRange
            // 
            this.clmRange.Text = "Range";
            this.clmRange.Width = 80;
            // 
            // clmStart
            // 
            this.clmStart.Text = "Startup";
            this.clmStart.Width = 80;
            // 
            // clmSafety
            // 
            this.clmSafety.Text = "Safety Value";
            this.clmSafety.Width = 200;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.Controls.Add(this.panelSafetyFunction);
            this.panel1.Controls.Add(this.panelSetting);
            this.panel1.Controls.Add(this.panelOutputValue);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(576, 160);
            this.panel1.TabIndex = 3;
            // 
            // panelSafetyFunction
            // 
            this.panelSafetyFunction.BackColor = System.Drawing.Color.SkyBlue;
            this.panelSafetyFunction.Controls.Add(this.btnSetSafetyValue);
            this.panelSafetyFunction.Controls.Add(this.chbxEnableSafety);
            this.panelSafetyFunction.Controls.Add(this.label2);
            this.panelSafetyFunction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSafetyFunction.Location = new System.Drawing.Point(0, 97);
            this.panelSafetyFunction.Name = "panelSafetyFunction";
            this.panelSafetyFunction.Size = new System.Drawing.Size(294, 63);
            this.panelSafetyFunction.TabIndex = 0;
            // 
            // btnSetSafetyValue
            // 
            this.btnSetSafetyValue.Enabled = false;
            this.btnSetSafetyValue.Location = new System.Drawing.Point(134, 31);
            this.btnSetSafetyValue.Name = "btnSetSafetyValue";
            this.btnSetSafetyValue.Size = new System.Drawing.Size(83, 24);
            this.btnSetSafetyValue.TabIndex = 0;
            this.btnSetSafetyValue.Text = "Set Value";
            this.btnSetSafetyValue.Click += new System.EventHandler(this.btnSetSafetyValue_Click);
            // 
            // chbxEnableSafety
            // 
            this.chbxEnableSafety.Location = new System.Drawing.Point(134, 6);
            this.chbxEnableSafety.Name = "chbxEnableSafety";
            this.chbxEnableSafety.Size = new System.Drawing.Size(76, 20);
            this.chbxEnableSafety.TabIndex = 1;
            this.chbxEnableSafety.Text = "Enable";
            this.chbxEnableSafety.CheckedChanged += new System.EventHandler(this.chbxEnableSafety_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(4, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Safety Function";
            // 
            // panelSetting
            // 
            this.panelSetting.BackColor = System.Drawing.Color.SkyBlue;
            this.panelSetting.Controls.Add(this.chbxApplyAll);
            this.panelSetting.Controls.Add(this.cbxRange);
            this.panelSetting.Controls.Add(this.labRange);
            this.panelSetting.Controls.Add(this.btnApplySelRange);
            this.panelSetting.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSetting.Location = new System.Drawing.Point(0, 0);
            this.panelSetting.Name = "panelSetting";
            this.panelSetting.Size = new System.Drawing.Size(294, 97);
            this.panelSetting.TabIndex = 1;
            // 
            // chbxApplyAll
            // 
            this.chbxApplyAll.Location = new System.Drawing.Point(3, 3);
            this.chbxApplyAll.Name = "chbxApplyAll";
            this.chbxApplyAll.Size = new System.Drawing.Size(168, 24);
            this.chbxApplyAll.TabIndex = 0;
            this.chbxApplyAll.Text = "Apply to All Channels";
            // 
            // cbxRange
            // 
            this.cbxRange.Location = new System.Drawing.Point(63, 33);
            this.cbxRange.Name = "cbxRange";
            this.cbxRange.Size = new System.Drawing.Size(171, 20);
            this.cbxRange.TabIndex = 1;
            // 
            // labRange
            // 
            this.labRange.Location = new System.Drawing.Point(3, 35);
            this.labRange.Name = "labRange";
            this.labRange.Size = new System.Drawing.Size(60, 20);
            this.labRange.TabIndex = 2;
            this.labRange.Text = "Range :";
            // 
            // btnApplySelRange
            // 
            this.btnApplySelRange.Location = new System.Drawing.Point(167, 64);
            this.btnApplySelRange.Name = "btnApplySelRange";
            this.btnApplySelRange.Size = new System.Drawing.Size(67, 24);
            this.btnApplySelRange.TabIndex = 3;
            this.btnApplySelRange.Text = "Apply";
            this.btnApplySelRange.Click += new System.EventHandler(this.btnApplySelRange_Click);
            // 
            // panelOutputValue
            // 
            this.panelOutputValue.BackColor = System.Drawing.Color.SkyBlue;
            this.panelOutputValue.Controls.Add(this.txtSelChannel);
            this.panelOutputValue.Controls.Add(this.btnSetAsSafety);
            this.panelOutputValue.Controls.Add(this.btnApplyOutput);
            this.panelOutputValue.Controls.Add(this.labLow);
            this.panelOutputValue.Controls.Add(this.labHigh);
            this.panelOutputValue.Controls.Add(this.tBarOutputVal);
            this.panelOutputValue.Controls.Add(this.txtOutputVal);
            this.panelOutputValue.Controls.Add(this.labOutputVal);
            this.panelOutputValue.Controls.Add(this.btnSetAsStartup);
            this.panelOutputValue.Controls.Add(this.labChannel);
            this.panelOutputValue.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelOutputValue.Location = new System.Drawing.Point(294, 0);
            this.panelOutputValue.Name = "panelOutputValue";
            this.panelOutputValue.Size = new System.Drawing.Size(282, 160);
            this.panelOutputValue.TabIndex = 2;
            // 
            // txtSelChannel
            // 
            this.txtSelChannel.Enabled = false;
            this.txtSelChannel.Location = new System.Drawing.Point(80, 8);
            this.txtSelChannel.Name = "txtSelChannel";
            this.txtSelChannel.Size = new System.Drawing.Size(94, 22);
            this.txtSelChannel.TabIndex = 0;
            // 
            // btnSetAsSafety
            // 
            this.btnSetAsSafety.Enabled = false;
            this.btnSetAsSafety.Location = new System.Drawing.Point(179, 127);
            this.btnSetAsSafety.Name = "btnSetAsSafety";
            this.btnSetAsSafety.Size = new System.Drawing.Size(85, 24);
            this.btnSetAsSafety.TabIndex = 1;
            this.btnSetAsSafety.Text = "Set Safety";
            this.btnSetAsSafety.Click += new System.EventHandler(this.btnSetAsSafety_Click);
            // 
            // btnApplyOutput
            // 
            this.btnApplyOutput.Location = new System.Drawing.Point(186, 34);
            this.btnApplyOutput.Name = "btnApplyOutput";
            this.btnApplyOutput.Size = new System.Drawing.Size(78, 24);
            this.btnApplyOutput.TabIndex = 2;
            this.btnApplyOutput.Text = "Output";
            this.btnApplyOutput.Click += new System.EventHandler(this.btnApplyOutput_Click);
            // 
            // labLow
            // 
            this.labLow.Location = new System.Drawing.Point(16, 104);
            this.labLow.Name = "labLow";
            this.labLow.Size = new System.Drawing.Size(80, 20);
            this.labLow.TabIndex = 3;
            this.labLow.Text = "Low";
            // 
            // labHigh
            // 
            this.labHigh.Location = new System.Drawing.Point(184, 104);
            this.labHigh.Name = "labHigh";
            this.labHigh.Size = new System.Drawing.Size(80, 20);
            this.labHigh.TabIndex = 4;
            this.labHigh.Text = "High";
            this.labHigh.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tBarOutputVal
            // 
            this.tBarOutputVal.LargeChange = 500;
            this.tBarOutputVal.Location = new System.Drawing.Point(8, 64);
            this.tBarOutputVal.Maximum = 4095;
            this.tBarOutputVal.Name = "tBarOutputVal";
            this.tBarOutputVal.Size = new System.Drawing.Size(250, 45);
            this.tBarOutputVal.SmallChange = 100;
            this.tBarOutputVal.TabIndex = 5;
            this.tBarOutputVal.TickFrequency = 100;
            this.tBarOutputVal.ValueChanged += new System.EventHandler(this.tBarOutputVal_ValueChanged_1);
            this.tBarOutputVal.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tBarOutputVal_MouseDown);
            // 
            // txtOutputVal
            // 
            this.txtOutputVal.Location = new System.Drawing.Point(80, 35);
            this.txtOutputVal.Name = "txtOutputVal";
            this.txtOutputVal.Size = new System.Drawing.Size(94, 22);
            this.txtOutputVal.TabIndex = 6;
            this.txtOutputVal.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtOutputVal_MouseDown);
            // 
            // labOutputVal
            // 
            this.labOutputVal.Location = new System.Drawing.Point(8, 36);
            this.labOutputVal.Name = "labOutputVal";
            this.labOutputVal.Size = new System.Drawing.Size(60, 20);
            this.labOutputVal.TabIndex = 7;
            this.labOutputVal.Text = "Value :";
            // 
            // btnSetAsStartup
            // 
            this.btnSetAsStartup.Location = new System.Drawing.Point(16, 127);
            this.btnSetAsStartup.Name = "btnSetAsStartup";
            this.btnSetAsStartup.Size = new System.Drawing.Size(85, 24);
            this.btnSetAsStartup.TabIndex = 8;
            this.btnSetAsStartup.Text = "Set Startup";
            this.btnSetAsStartup.Click += new System.EventHandler(this.btnSetAsStartup_Click);
            // 
            // labChannel
            // 
            this.labChannel.Location = new System.Drawing.Point(8, 10);
            this.labChannel.Name = "labChannel";
            this.labChannel.Size = new System.Drawing.Size(70, 20);
            this.labChannel.TabIndex = 9;
            this.labChannel.Text = "Channel :";
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.chbxShowRawData);
            this.panelMain.Controls.Add(this.chbxHide);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(576, 32);
            this.panelMain.TabIndex = 4;
            // 
            // chbxShowRawData
            // 
            this.chbxShowRawData.Location = new System.Drawing.Point(176, 6);
            this.chbxShowRawData.Name = "chbxShowRawData";
            this.chbxShowRawData.Size = new System.Drawing.Size(128, 20);
            this.chbxShowRawData.TabIndex = 2;
            this.chbxShowRawData.Text = "Show Raw Data";
            this.chbxShowRawData.Visible = false;
            // 
            // chbxHide
            // 
            this.chbxHide.Location = new System.Drawing.Point(3, 6);
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
            // Form_APAX_5028
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 390);
            this.Controls.Add(this.Btn_Quit);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.StatusBar_IO);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form_APAX_5028";
            this.Text = "APAX-5028";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_APAX_5028_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabModuleInfo.ResumeLayout(false);
            this.tabModuleInfo.PerformLayout();
            this.tabAO.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelSafetyFunction.ResumeLayout(false);
            this.panelSetting.ResumeLayout(false);
            this.panelOutputValue.ResumeLayout(false);
            this.panelOutputValue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tBarOutputVal)).EndInit();
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtModule;
        private System.Windows.Forms.Label labModule;
        private System.Windows.Forms.Label labID;
        private System.Windows.Forms.Label labFwVer;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtFwVer;
        private System.Windows.Forms.TextBox txtSupportKernelFw;
        private System.Windows.Forms.Label labSupportKernelFw;
        private System.Windows.Forms.TabPage tabAO;
        private System.Windows.Forms.ListView listViewChInfo;
        private System.Windows.Forms.ColumnHeader clmType;
        private System.Windows.Forms.ColumnHeader clmCh;
        private System.Windows.Forms.ColumnHeader clmValue;
        private System.Windows.Forms.ColumnHeader clmRange;
        private System.Windows.Forms.ColumnHeader clmStart;
        private System.Windows.Forms.ColumnHeader clmSafety;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelSafetyFunction;
        private System.Windows.Forms.Button btnSetSafetyValue;
        private System.Windows.Forms.CheckBox chbxEnableSafety;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelSetting;
        private System.Windows.Forms.CheckBox chbxApplyAll;
        public System.Windows.Forms.ComboBox cbxRange;
        private System.Windows.Forms.Label labRange;
        private System.Windows.Forms.Button btnApplySelRange;
        private System.Windows.Forms.Panel panelOutputValue;
        public System.Windows.Forms.TextBox txtSelChannel;
        private System.Windows.Forms.Button btnSetAsSafety;
        private System.Windows.Forms.Button btnApplyOutput;
        private System.Windows.Forms.Label labLow;
        private System.Windows.Forms.Label labHigh;
        private System.Windows.Forms.TrackBar tBarOutputVal;
        private System.Windows.Forms.TextBox txtOutputVal;
        private System.Windows.Forms.Label labOutputVal;
        private System.Windows.Forms.Button btnSetAsStartup;
        private System.Windows.Forms.Label labChannel;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.CheckBox chbxShowRawData;
        private System.Windows.Forms.CheckBox chbxHide;
        private System.Windows.Forms.Timer timer1;
    }
}

