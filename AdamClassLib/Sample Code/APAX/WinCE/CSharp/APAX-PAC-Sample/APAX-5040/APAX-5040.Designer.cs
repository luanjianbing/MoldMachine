﻿namespace APAX_5040
{
    partial class Form_APAX_5040
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
            this.listViewChInfo = new System.Windows.Forms.ListView();
            this.clmDIType = new System.Windows.Forms.ColumnHeader();
            this.clmDICh = new System.Windows.Forms.ColumnHeader();
            this.clmMbAddr = new System.Windows.Forms.ColumnHeader();
            this.clmDIValue = new System.Windows.Forms.ColumnHeader();
            this.clmDIMode = new System.Windows.Forms.ColumnHeader();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelCntMin = new System.Windows.Forms.Label();
            this.chkBoxDiFilterEnable = new System.Windows.Forms.CheckBox();
            this.btnApplySetting = new System.Windows.Forms.Button();
            this.labUnit = new System.Windows.Forms.Label();
            this.txtCntMin = new System.Windows.Forms.TextBox();
            this.panelMain_DI = new System.Windows.Forms.Panel();
            this.chbxHide_DI = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer();
            this.tabControl1.SuspendLayout();
            this.tabModuleInfo.SuspendLayout();
            this.tabDI.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelMain_DI.SuspendLayout();
            this.SuspendLayout();
            // 
            // Btn_Quit
            // 
            this.Btn_Quit.Location = new System.Drawing.Point(453, 337);
            this.Btn_Quit.Name = "Btn_Quit";
            this.Btn_Quit.Size = new System.Drawing.Size(73, 21);
            this.Btn_Quit.TabIndex = 24;
            this.Btn_Quit.Text = "Quit";
            this.Btn_Quit.Click += new System.EventHandler(this.Btn_Quit_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(374, 337);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(73, 21);
            this.btnStart.TabIndex = 23;
            this.btnStart.Text = "Start";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // StatusBar_IO
            // 
            this.StatusBar_IO.Location = new System.Drawing.Point(0, 363);
            this.StatusBar_IO.Name = "StatusBar_IO";
            this.StatusBar_IO.Size = new System.Drawing.Size(531, 24);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabModuleInfo);
            this.tabControl1.Controls.Add(this.tabDI);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(531, 331);
            this.tabControl1.TabIndex = 22;
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
            this.tabModuleInfo.Location = new System.Drawing.Point(4, 25);
            this.tabModuleInfo.Name = "tabModuleInfo";
            this.tabModuleInfo.Size = new System.Drawing.Size(523, 302);
            this.tabModuleInfo.Text = "Module Information";
            // 
            // btnLocate
            // 
            this.btnLocate.Location = new System.Drawing.Point(135, 131);
            this.btnLocate.Name = "btnLocate";
            this.btnLocate.Size = new System.Drawing.Size(72, 20);
            this.btnLocate.TabIndex = 29;
            this.btnLocate.Text = "Enable";
            this.btnLocate.Click += new System.EventHandler(this.btnLocate_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.Text = "Locate";
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
            this.labFwVer.Location = new System.Drawing.Point(4, 102);
            this.labFwVer.Name = "labFwVer";
            this.labFwVer.Size = new System.Drawing.Size(125, 20);
            this.labFwVer.Text = "Firmware Version:";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(135, 40);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(223, 23);
            this.txtID.TabIndex = 23;
            // 
            // txtFwVer
            // 
            this.txtFwVer.Location = new System.Drawing.Point(135, 102);
            this.txtFwVer.Name = "txtFwVer";
            this.txtFwVer.ReadOnly = true;
            this.txtFwVer.Size = new System.Drawing.Size(223, 23);
            this.txtFwVer.TabIndex = 25;
            // 
            // txtSupportKernelFw
            // 
            this.txtSupportKernelFw.Location = new System.Drawing.Point(135, 71);
            this.txtSupportKernelFw.Name = "txtSupportKernelFw";
            this.txtSupportKernelFw.ReadOnly = true;
            this.txtSupportKernelFw.Size = new System.Drawing.Size(223, 23);
            this.txtSupportKernelFw.TabIndex = 26;
            // 
            // labSupportKernelFw
            // 
            this.labSupportKernelFw.Location = new System.Drawing.Point(4, 74);
            this.labSupportKernelFw.Name = "labSupportKernelFw";
            this.labSupportKernelFw.Size = new System.Drawing.Size(124, 20);
            this.labSupportKernelFw.Text = "Support Kernel Fw:";
            // 
            // tabDI
            // 
            this.tabDI.Controls.Add(this.listViewChInfo);
            this.tabDI.Controls.Add(this.panel2);
            this.tabDI.Controls.Add(this.panelMain_DI);
            this.tabDI.Location = new System.Drawing.Point(4, 25);
            this.tabDI.Name = "tabDI";
            this.tabDI.Size = new System.Drawing.Size(523, 302);
            this.tabDI.Text = "DI";
            // 
            // listViewChInfo
            // 
            this.listViewChInfo.Columns.Add(this.clmDIType);
            this.listViewChInfo.Columns.Add(this.clmDICh);
            this.listViewChInfo.Columns.Add(this.clmMbAddr);
            this.listViewChInfo.Columns.Add(this.clmDIValue);
            this.listViewChInfo.Columns.Add(this.clmDIMode);
            this.listViewChInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewChInfo.FullRowSelect = true;
            this.listViewChInfo.Location = new System.Drawing.Point(0, 103);
            this.listViewChInfo.Name = "listViewChInfo";
            this.listViewChInfo.Size = new System.Drawing.Size(523, 199);
            this.listViewChInfo.TabIndex = 4;
            this.listViewChInfo.View = System.Windows.Forms.View.Details;
            // 
            // clmDIType
            // 
            this.clmDIType.Text = "Type";
            this.clmDIType.Width = 60;
            // 
            // clmDICh
            // 
            this.clmDICh.Text = "CH";
            this.clmDICh.Width = 60;
            // 
            // clmMbAddr
            // 
            this.clmMbAddr.Text = "Modbus Addr";
            this.clmMbAddr.Width = 90;
            // 
            // clmDIValue
            // 
            this.clmDIValue.Text = "Value";
            this.clmDIValue.Width = 60;
            // 
            // clmDIMode
            // 
            this.clmDIMode.Text = "Mode";
            this.clmDIMode.Width = 60;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SkyBlue;
            this.panel2.Controls.Add(this.labelCntMin);
            this.panel2.Controls.Add(this.chkBoxDiFilterEnable);
            this.panel2.Controls.Add(this.btnApplySetting);
            this.panel2.Controls.Add(this.labUnit);
            this.panel2.Controls.Add(this.txtCntMin);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(523, 71);
            // 
            // labelCntMin
            // 
            this.labelCntMin.Location = new System.Drawing.Point(8, 37);
            this.labelCntMin.Name = "labelCntMin";
            this.labelCntMin.Size = new System.Drawing.Size(243, 24);
            this.labelCntMin.Text = "Minimum low signal width (30~400)";
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
            this.btnApplySetting.Location = new System.Drawing.Point(415, 37);
            this.btnApplySetting.Name = "btnApplySetting";
            this.btnApplySetting.Size = new System.Drawing.Size(88, 24);
            this.btnApplySetting.TabIndex = 6;
            this.btnApplySetting.Text = "Apply";
            this.btnApplySetting.Click += new System.EventHandler(this.btnApplySetting_Click);
            // 
            // labUnit
            // 
            this.labUnit.Location = new System.Drawing.Point(351, 37);
            this.labUnit.Name = "labUnit";
            this.labUnit.Size = new System.Drawing.Size(58, 24);
            this.labUnit.Text = "0.1 ms";
            // 
            // txtCntMin
            // 
            this.txtCntMin.Location = new System.Drawing.Point(291, 38);
            this.txtCntMin.MaxLength = 10;
            this.txtCntMin.Name = "txtCntMin";
            this.txtCntMin.Size = new System.Drawing.Size(54, 23);
            this.txtCntMin.TabIndex = 8;
            // 
            // panelMain_DI
            // 
            this.panelMain_DI.Controls.Add(this.chbxHide_DI);
            this.panelMain_DI.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMain_DI.Location = new System.Drawing.Point(0, 0);
            this.panelMain_DI.Name = "panelMain_DI";
            this.panelMain_DI.Size = new System.Drawing.Size(523, 32);
            // 
            // chbxHide_DI
            // 
            this.chbxHide_DI.Location = new System.Drawing.Point(8, 8);
            this.chbxHide_DI.Name = "chbxHide_DI";
            this.chbxHide_DI.Size = new System.Drawing.Size(168, 20);
            this.chbxHide_DI.TabIndex = 1;
            this.chbxHide_DI.Text = "Hide Setting Panel";
            this.chbxHide_DI.CheckStateChanged += new System.EventHandler(this.chbxHide_DI_CheckStateChanged);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form_APAX_5040
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(531, 387);
            this.Controls.Add(this.Btn_Quit);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.StatusBar_IO);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form_APAX_5040";
            this.Text = "APAX-5040";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form_APAX_5040_Closing);
            this.tabControl1.ResumeLayout(false);
            this.tabModuleInfo.ResumeLayout(false);
            this.tabDI.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panelMain_DI.ResumeLayout(false);
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
        private System.Windows.Forms.ListView listViewChInfo;
        private System.Windows.Forms.ColumnHeader clmDIType;
        private System.Windows.Forms.ColumnHeader clmDICh;
        private System.Windows.Forms.ColumnHeader clmMbAddr;
        private System.Windows.Forms.ColumnHeader clmDIValue;
        private System.Windows.Forms.ColumnHeader clmDIMode;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelCntMin;
        private System.Windows.Forms.CheckBox chkBoxDiFilterEnable;
        private System.Windows.Forms.Button btnApplySetting;
        private System.Windows.Forms.Label labUnit;
        private System.Windows.Forms.TextBox txtCntMin;
        private System.Windows.Forms.Panel panelMain_DI;
        private System.Windows.Forms.CheckBox chbxHide_DI;
        private System.Windows.Forms.Timer timer1;

    }
}

