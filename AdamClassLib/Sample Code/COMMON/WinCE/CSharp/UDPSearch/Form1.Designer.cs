namespace UDPSearch
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
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Root");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnSearch = new System.Windows.Forms.Button();
            this.tcpTree = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.panelNetworkSetting = new System.Windows.Forms.Panel();
            this.btnNetSetting = new System.Windows.Forms.Button();
            this.txtHostIdle = new System.Windows.Forms.TextBox();
            this.txtGateway = new System.Windows.Forms.TextBox();
            this.txtSubnet = new System.Windows.Forms.TextBox();
            this.txtMac = new System.Windows.Forms.TextBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panelDeviceInfo = new System.Windows.Forms.Panel();
            this.btnDeviceInfoSetting = new System.Windows.Forms.Button();
            this.panelOther = new System.Windows.Forms.Panel();
            this.btnSystemRestart = new System.Windows.Forms.Button();
            this.panelNetworkSetting.SuspendLayout();
            this.panelDeviceInfo.SuspendLayout();
            this.panelOther.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(208, 424);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tcpTree
            // 
            this.tcpTree.ImageIndex = 0;
            this.tcpTree.ImageList = this.imageList1;
            this.tcpTree.Location = new System.Drawing.Point(6, 12);
            this.tcpTree.Name = "tcpTree";
            treeNode2.Text = "Root";
            this.tcpTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.tcpTree.SelectedImageIndex = 0;
            this.tcpTree.Size = new System.Drawing.Size(277, 402);
            this.tcpTree.TabIndex = 7;
            this.tcpTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tcpTree_AfterSelect);
            this.imageList1.Images.Clear();
            this.imageList1.Images.Add(((System.Drawing.Icon)(resources.GetObject("resource"))));
            this.imageList1.Images.Add(((System.Drawing.Icon)(resources.GetObject("resource1"))));
            this.imageList1.Images.Add(((System.Drawing.Icon)(resources.GetObject("resource2"))));
            this.imageList1.Images.Add(((System.Drawing.Icon)(resources.GetObject("resource3"))));
            this.imageList1.Images.Add(((System.Drawing.Icon)(resources.GetObject("resource4"))));
            this.imageList1.Images.Add(((System.Drawing.Icon)(resources.GetObject("resource5"))));
            this.imageList1.Images.Add(((System.Drawing.Icon)(resources.GetObject("resource6"))));
            // 
            // panelNetworkSetting
            // 
            this.panelNetworkSetting.Controls.Add(this.btnNetSetting);
            this.panelNetworkSetting.Controls.Add(this.txtHostIdle);
            this.panelNetworkSetting.Controls.Add(this.txtGateway);
            this.panelNetworkSetting.Controls.Add(this.txtSubnet);
            this.panelNetworkSetting.Controls.Add(this.txtMac);
            this.panelNetworkSetting.Controls.Add(this.txtIP);
            this.panelNetworkSetting.Controls.Add(this.label5);
            this.panelNetworkSetting.Controls.Add(this.label4);
            this.panelNetworkSetting.Controls.Add(this.label3);
            this.panelNetworkSetting.Controls.Add(this.label2);
            this.panelNetworkSetting.Controls.Add(this.label1);
            this.panelNetworkSetting.Location = new System.Drawing.Point(303, 12);
            this.panelNetworkSetting.Name = "panelNetworkSetting";
            this.panelNetworkSetting.Size = new System.Drawing.Size(264, 183);
            // 
            // btnNetSetting
            // 
            this.btnNetSetting.Enabled = false;
            this.btnNetSetting.Location = new System.Drawing.Point(140, 151);
            this.btnNetSetting.Name = "btnNetSetting";
            this.btnNetSetting.Size = new System.Drawing.Size(120, 23);
            this.btnNetSetting.TabIndex = 11;
            this.btnNetSetting.Text = "Apply Change";
            this.btnNetSetting.Click += new System.EventHandler(this.btnNetSetting_Click);
            // 
            // txtHostIdle
            // 
            this.txtHostIdle.Location = new System.Drawing.Point(107, 117);
            this.txtHostIdle.Name = "txtHostIdle";
            this.txtHostIdle.Size = new System.Drawing.Size(154, 23);
            this.txtHostIdle.TabIndex = 14;
            // 
            // txtGateway
            // 
            this.txtGateway.Location = new System.Drawing.Point(106, 88);
            this.txtGateway.Name = "txtGateway";
            this.txtGateway.Size = new System.Drawing.Size(154, 23);
            this.txtGateway.TabIndex = 13;
            // 
            // txtSubnet
            // 
            this.txtSubnet.Location = new System.Drawing.Point(106, 60);
            this.txtSubnet.Name = "txtSubnet";
            this.txtSubnet.Size = new System.Drawing.Size(154, 23);
            this.txtSubnet.TabIndex = 12;
            // 
            // txtMac
            // 
            this.txtMac.Location = new System.Drawing.Point(106, 32);
            this.txtMac.Name = "txtMac";
            this.txtMac.ReadOnly = true;
            this.txtMac.Size = new System.Drawing.Size(154, 23);
            this.txtMac.TabIndex = 11;
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(106, 4);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(154, 23);
            this.txtIP.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 20);
            this.label5.Text = "Host Idle: ";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 19);
            this.label4.Text = "Default gateway: ";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 19);
            this.label3.Text = "Subnet mask: ";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 19);
            this.label2.Text = "Mac: ";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.Text = "IP address:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(106, 34);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(155, 56);
            this.txtDescription.TabIndex = 16;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(107, 6);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(154, 23);
            this.txtName.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(3, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 19);
            this.label7.Text = "Description: ";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(3, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 20);
            this.label6.Text = "Device Name: ";
            // 
            // panelDeviceInfo
            // 
            this.panelDeviceInfo.Controls.Add(this.btnDeviceInfoSetting);
            this.panelDeviceInfo.Controls.Add(this.txtDescription);
            this.panelDeviceInfo.Controls.Add(this.txtName);
            this.panelDeviceInfo.Controls.Add(this.label6);
            this.panelDeviceInfo.Controls.Add(this.label7);
            this.panelDeviceInfo.Location = new System.Drawing.Point(303, 205);
            this.panelDeviceInfo.Name = "panelDeviceInfo";
            this.panelDeviceInfo.Size = new System.Drawing.Size(264, 132);
            // 
            // btnDeviceInfoSetting
            // 
            this.btnDeviceInfoSetting.Enabled = false;
            this.btnDeviceInfoSetting.Location = new System.Drawing.Point(140, 99);
            this.btnDeviceInfoSetting.Name = "btnDeviceInfoSetting";
            this.btnDeviceInfoSetting.Size = new System.Drawing.Size(120, 23);
            this.btnDeviceInfoSetting.TabIndex = 19;
            this.btnDeviceInfoSetting.Text = "Apply Change";
            this.btnDeviceInfoSetting.Click += new System.EventHandler(this.btnDeviceInfoSetting_Click);
            // 
            // panelOther
            // 
            this.panelOther.Controls.Add(this.btnSystemRestart);
            this.panelOther.Location = new System.Drawing.Point(303, 346);
            this.panelOther.Name = "panelOther";
            this.panelOther.Size = new System.Drawing.Size(264, 60);
            // 
            // btnSystemRestart
            // 
            this.btnSystemRestart.Enabled = false;
            this.btnSystemRestart.Location = new System.Drawing.Point(140, 18);
            this.btnSystemRestart.Name = "btnSystemRestart";
            this.btnSystemRestart.Size = new System.Drawing.Size(120, 23);
            this.btnSystemRestart.TabIndex = 19;
            this.btnSystemRestart.Text = "System Restart";
            this.btnSystemRestart.Click += new System.EventHandler(this.btnSystemRestart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(590, 463);
            this.Controls.Add(this.panelOther);
            this.Controls.Add(this.panelDeviceInfo);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tcpTree);
            this.Controls.Add(this.panelNetworkSetting);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "UDP Search Sample Program (C#)";
            this.panelNetworkSetting.ResumeLayout(false);
            this.panelDeviceInfo.ResumeLayout(false);
            this.panelOther.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TreeView tcpTree;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panelNetworkSetting;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtHostIdle;
        private System.Windows.Forms.TextBox txtGateway;
        private System.Windows.Forms.TextBox txtSubnet;
        private System.Windows.Forms.TextBox txtMac;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelDeviceInfo;
        private System.Windows.Forms.Button btnNetSetting;
        private System.Windows.Forms.Button btnDeviceInfoSetting;
        private System.Windows.Forms.Panel panelOther;
        private System.Windows.Forms.Button btnSystemRestart;
    }
}

