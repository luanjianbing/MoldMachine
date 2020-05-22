namespace APAX_Controller_Win32_Sample
{
    partial class Form_APAX_Controller
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Local System");
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ListView_Module_Infor = new System.Windows.Forms.ListView();
            this.ColumnHeader_ID = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader_Module = new System.Windows.Forms.ColumnHeader();
            this.panel4 = new System.Windows.Forms.Panel();
            this.NumericUpDown_SCAN = new System.Windows.Forms.NumericUpDown();
            this.TextBox_FPGA_Ver = new System.Windows.Forms.TextBox();
            this.TextBox_Firmware_Ver = new System.Windows.Forms.TextBox();
            this.lbl_SCAN = new System.Windows.Forms.Label();
            this.lbl_FPGA_VER = new System.Windows.Forms.Label();
            this.lbl_Controller_Firmware_Ver = new System.Windows.Forms.Label();
            this.lbl_Controller_Title = new System.Windows.Forms.Label();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_SCAN)).BeginInit();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "Refresh Local";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.Text = "Exit";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
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
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.panel4);
            this.splitContainer1.Size = new System.Drawing.Size(556, 367);
            this.splitContainer1.SplitterDistance = 185;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "";
            treeNode1.Text = "Local System";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView1.Size = new System.Drawing.Size(185, 344);
            this.treeView1.TabIndex = 6;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ListView_Module_Infor);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 174);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(367, 169);
            this.panel1.TabIndex = 2;
            // 
            // ListView_Module_Infor
            // 
            this.ListView_Module_Infor.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader_ID,
            this.ColumnHeader_Module});
            this.ListView_Module_Infor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListView_Module_Infor.FullRowSelect = true;
            this.ListView_Module_Infor.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.ListView_Module_Infor.Location = new System.Drawing.Point(0, 0);
            this.ListView_Module_Infor.Name = "ListView_Module_Infor";
            this.ListView_Module_Infor.Size = new System.Drawing.Size(367, 169);
            this.ListView_Module_Infor.TabIndex = 16;
            this.ListView_Module_Infor.UseCompatibleStateImageBehavior = false;
            this.ListView_Module_Infor.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeader_ID
            // 
            this.ColumnHeader_ID.Text = "Switch ID";
            this.ColumnHeader_ID.Width = 143;
            // 
            // ColumnHeader_Module
            // 
            this.ColumnHeader_Module.Text = "Module";
            this.ColumnHeader_Module.Width = 213;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.NumericUpDown_SCAN);
            this.panel4.Controls.Add(this.TextBox_FPGA_Ver);
            this.panel4.Controls.Add(this.TextBox_Firmware_Ver);
            this.panel4.Controls.Add(this.lbl_SCAN);
            this.panel4.Controls.Add(this.lbl_FPGA_VER);
            this.panel4.Controls.Add(this.lbl_Controller_Firmware_Ver);
            this.panel4.Controls.Add(this.lbl_Controller_Title);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(367, 174);
            this.panel4.TabIndex = 1;
            this.panel4.Visible = false;
            // 
            // NumericUpDown_SCAN
            // 
            this.NumericUpDown_SCAN.Location = new System.Drawing.Point(137, 99);
            this.NumericUpDown_SCAN.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NumericUpDown_SCAN.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.NumericUpDown_SCAN.Name = "NumericUpDown_SCAN";
            this.NumericUpDown_SCAN.Size = new System.Drawing.Size(94, 22);
            this.NumericUpDown_SCAN.TabIndex = 14;
            this.NumericUpDown_SCAN.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.NumericUpDown_SCAN.ValueChanged += new System.EventHandler(this.NumericUpDown_SCAN_ValueChanged);
            // 
            // TextBox_FPGA_Ver
            // 
            this.TextBox_FPGA_Ver.Location = new System.Drawing.Point(137, 70);
            this.TextBox_FPGA_Ver.Name = "TextBox_FPGA_Ver";
            this.TextBox_FPGA_Ver.Size = new System.Drawing.Size(165, 22);
            this.TextBox_FPGA_Ver.TabIndex = 13;
            // 
            // TextBox_Firmware_Ver
            // 
            this.TextBox_Firmware_Ver.Location = new System.Drawing.Point(137, 41);
            this.TextBox_Firmware_Ver.Name = "TextBox_Firmware_Ver";
            this.TextBox_Firmware_Ver.Size = new System.Drawing.Size(165, 22);
            this.TextBox_Firmware_Ver.TabIndex = 12;
            // 
            // lbl_SCAN
            // 
            this.lbl_SCAN.Location = new System.Drawing.Point(13, 99);
            this.lbl_SCAN.Name = "lbl_SCAN";
            this.lbl_SCAN.Size = new System.Drawing.Size(100, 20);
            this.lbl_SCAN.TabIndex = 16;
            this.lbl_SCAN.Text = "Scan Interval:";
            // 
            // lbl_FPGA_VER
            // 
            this.lbl_FPGA_VER.Location = new System.Drawing.Point(13, 70);
            this.lbl_FPGA_VER.Name = "lbl_FPGA_VER";
            this.lbl_FPGA_VER.Size = new System.Drawing.Size(100, 20);
            this.lbl_FPGA_VER.TabIndex = 17;
            this.lbl_FPGA_VER.Text = "FPGA Version:";
            // 
            // lbl_Controller_Firmware_Ver
            // 
            this.lbl_Controller_Firmware_Ver.Location = new System.Drawing.Point(13, 41);
            this.lbl_Controller_Firmware_Ver.Name = "lbl_Controller_Firmware_Ver";
            this.lbl_Controller_Firmware_Ver.Size = new System.Drawing.Size(118, 23);
            this.lbl_Controller_Firmware_Ver.TabIndex = 18;
            this.lbl_Controller_Firmware_Ver.Text = "Firmware Version:";
            // 
            // lbl_Controller_Title
            // 
            this.lbl_Controller_Title.Location = new System.Drawing.Point(13, 7);
            this.lbl_Controller_Title.Name = "lbl_Controller_Title";
            this.lbl_Controller_Title.Size = new System.Drawing.Size(152, 18);
            this.lbl_Controller_Title.TabIndex = 19;
            this.lbl_Controller_Title.Text = "APAX-PAC";
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 343);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Size = new System.Drawing.Size(556, 24);
            this.statusBar1.TabIndex = 2;
            // 
            // Form_APAX_Controller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(556, 367);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.splitContainer1);
            this.Menu = this.mainMenu1;
            this.Name = "Form_APAX_Controller";
            this.Text = "APAX-Controller";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDown_SCAN)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        internal System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.NumericUpDown NumericUpDown_SCAN;
        public System.Windows.Forms.TextBox TextBox_FPGA_Ver;
        public System.Windows.Forms.TextBox TextBox_Firmware_Ver;
        public System.Windows.Forms.Label lbl_SCAN;
        public System.Windows.Forms.Label lbl_FPGA_VER;
        public System.Windows.Forms.Label lbl_Controller_Firmware_Ver;
        public System.Windows.Forms.Label lbl_Controller_Title;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.ListView ListView_Module_Infor;
        protected System.Windows.Forms.ColumnHeader ColumnHeader_ID;
        private System.Windows.Forms.ColumnHeader ColumnHeader_Module;
    }
}

