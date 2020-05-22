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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Root");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnSearch = new System.Windows.Forms.Button();
            this.tcpTree = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtHostIdle = new System.Windows.Forms.TextBox();
            this.txtGateway = new System.Windows.Forms.TextBox();
            this.txtSubnet = new System.Windows.Forms.TextBox();
            this.txtMac = new System.Windows.Forms.TextBox();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbxNet = new System.Windows.Forms.GroupBox();
            this.gbxDeviceInfo = new System.Windows.Forms.GroupBox();
            this.panelDeviceInfo = new System.Windows.Forms.Panel();
            this.btnDeviceInfoSetting = new System.Windows.Forms.Button();
            this.btnNetSetting = new System.Windows.Forms.Button();
            this.gbxOther = new System.Windows.Forms.GroupBox();
            this.btnSystemRestart = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.gbxNet.SuspendLayout();
            this.gbxDeviceInfo.SuspendLayout();
            this.panelDeviceInfo.SuspendLayout();
            this.gbxOther.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(210, 444);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tcpTree
            // 
            this.tcpTree.ImageIndex = 0;
            this.tcpTree.ImageList = this.imageList1;
            this.tcpTree.Location = new System.Drawing.Point(8, 12);
            this.tcpTree.Name = "tcpTree";
            treeNode1.Name = "Node0";
            treeNode1.Text = "Root";
            this.tcpTree.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.tcpTree.SelectedImageIndex = 0;
            this.tcpTree.Size = new System.Drawing.Size(277, 415);
            this.tcpTree.TabIndex = 4;
            this.tcpTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tcpTree_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "tcpRoot.ico");
            this.imageList1.Images.SetKeyName(1, "ADAM5000.ico");
            this.imageList1.Images.SetKeyName(2, "ADAM50on.ico");
            this.imageList1.Images.SetKeyName(3, "ADAM4000Off.ico");
            this.imageList1.Images.SetKeyName(4, "ADAM4000On.ico");
            this.imageList1.Images.SetKeyName(5, "tcpOff.ico");
            this.imageList1.Images.SetKeyName(6, "tcpOn.ico");
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtHostIdle);
            this.panel1.Controls.Add(this.txtGateway);
            this.panel1.Controls.Add(this.txtSubnet);
            this.panel1.Controls.Add(this.txtMac);
            this.panel1.Controls.Add(this.txtIP);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(9, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(251, 149);
            this.panel1.TabIndex = 3;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(87, 38);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(157, 63);
            this.txtDescription.TabIndex = 16;
            this.txtDescription.MaxLength = 127;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(88, 10);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(156, 22);
            this.txtName.TabIndex = 15;
            // 
            // txtHostIdle
            // 
            this.txtHostIdle.Location = new System.Drawing.Point(89, 117);
            this.txtHostIdle.Name = "txtHostIdle";
            this.txtHostIdle.Size = new System.Drawing.Size(156, 22);
            this.txtHostIdle.TabIndex = 14;
            // 
            // txtGateway
            // 
            this.txtGateway.Location = new System.Drawing.Point(88, 88);
            this.txtGateway.Name = "txtGateway";
            this.txtGateway.Size = new System.Drawing.Size(156, 22);
            this.txtGateway.TabIndex = 13;
            // 
            // txtSubnet
            // 
            this.txtSubnet.Location = new System.Drawing.Point(88, 60);
            this.txtSubnet.Name = "txtSubnet";
            this.txtSubnet.Size = new System.Drawing.Size(156, 22);
            this.txtSubnet.TabIndex = 12;
            // 
            // txtMac
            // 
            this.txtMac.Location = new System.Drawing.Point(88, 32);
            this.txtMac.Name = "txtMac";
            this.txtMac.ReadOnly = true;
            this.txtMac.Size = new System.Drawing.Size(156, 22);
            this.txtMac.TabIndex = 11;
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(88, 4);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(156, 22);
            this.txtIP.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "Description: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "Device Name: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "Host Idle: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "Default gateway: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "Subnet mask: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mac: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP address:";
            // 
            // gbxNet
            // 
            this.gbxNet.Controls.Add(this.btnNetSetting);
            this.gbxNet.Controls.Add(this.panel1);
            this.gbxNet.Location = new System.Drawing.Point(292, 12);
            this.gbxNet.Name = "gbxNet";
            this.gbxNet.Size = new System.Drawing.Size(269, 212);
            this.gbxNet.TabIndex = 6;
            this.gbxNet.TabStop = false;
            this.gbxNet.Text = "Network Setting";
            // 
            // gbxDeviceInfo
            // 
            this.gbxDeviceInfo.Controls.Add(this.btnDeviceInfoSetting);
            this.gbxDeviceInfo.Controls.Add(this.panelDeviceInfo);
            this.gbxDeviceInfo.Location = new System.Drawing.Point(292, 229);
            this.gbxDeviceInfo.Name = "gbxDeviceInfo";
            this.gbxDeviceInfo.Size = new System.Drawing.Size(268, 168);
            this.gbxDeviceInfo.TabIndex = 7;
            this.gbxDeviceInfo.TabStop = false;
            this.gbxDeviceInfo.Text = "Device Info";
            // 
            // panelDeviceInfo
            // 
            this.panelDeviceInfo.Controls.Add(this.txtDescription);
            this.panelDeviceInfo.Controls.Add(this.txtName);
            this.panelDeviceInfo.Controls.Add(this.label6);
            this.panelDeviceInfo.Controls.Add(this.label7);
            this.panelDeviceInfo.Location = new System.Drawing.Point(8, 15);
            this.panelDeviceInfo.Name = "panelDeviceInfo";
            this.panelDeviceInfo.Size = new System.Drawing.Size(251, 112);
            this.panelDeviceInfo.TabIndex = 0;
            // 
            // btnDeviceInfoSetting
            // 
            this.btnDeviceInfoSetting.Enabled = false;
            this.btnDeviceInfoSetting.Location = new System.Drawing.Point(177, 133);
            this.btnDeviceInfoSetting.Name = "btnDeviceInfoSetting";
            this.btnDeviceInfoSetting.Size = new System.Drawing.Size(84, 23);
            this.btnDeviceInfoSetting.TabIndex = 18;
            this.btnDeviceInfoSetting.Text = "Apply Change";
            this.btnDeviceInfoSetting.UseVisualStyleBackColor = true;
            this.btnDeviceInfoSetting.Click += new System.EventHandler(this.btnDeviceInfoSetting_Click);
            // 
            // btnNetSetting
            // 
            this.btnNetSetting.Enabled = false;
            this.btnNetSetting.Location = new System.Drawing.Point(176, 180);
            this.btnNetSetting.Name = "btnNetSetting";
            this.btnNetSetting.Size = new System.Drawing.Size(84, 23);
            this.btnNetSetting.TabIndex = 9;
            this.btnNetSetting.Text = "Apply Change";
            this.btnNetSetting.UseVisualStyleBackColor = true;
            this.btnNetSetting.Click += new System.EventHandler(this.btnNetSetting_Click);
            // 
            // gbxOther
            // 
            this.gbxOther.Controls.Add(this.btnSystemRestart);
            this.gbxOther.Location = new System.Drawing.Point(293, 403);
            this.gbxOther.Name = "gbxOther";
            this.gbxOther.Size = new System.Drawing.Size(268, 64);
            this.gbxOther.TabIndex = 9;
            this.gbxOther.TabStop = false;
            this.gbxOther.Text = "Other";
            // 
            // btnSystemRestart
            // 
            this.btnSystemRestart.Enabled = false;
            this.btnSystemRestart.Location = new System.Drawing.Point(175, 21);
            this.btnSystemRestart.Name = "btnSystemRestart";
            this.btnSystemRestart.Size = new System.Drawing.Size(84, 23);
            this.btnSystemRestart.TabIndex = 18;
            this.btnSystemRestart.Text = "System Restart";
            this.btnSystemRestart.UseVisualStyleBackColor = true;
            this.btnSystemRestart.Click += new System.EventHandler(this.btnSystemRestart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 478);
            this.Controls.Add(this.gbxOther);
            this.Controls.Add(this.gbxDeviceInfo);
            this.Controls.Add(this.gbxNet);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.tcpTree);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "UDP Search Sample Program (C#)";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbxNet.ResumeLayout(false);
            this.gbxDeviceInfo.ResumeLayout(false);
            this.panelDeviceInfo.ResumeLayout(false);
            this.panelDeviceInfo.PerformLayout();
            this.gbxOther.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TreeView tcpTree;
        private System.Windows.Forms.Panel panel1;
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
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox gbxNet;
        private System.Windows.Forms.GroupBox gbxDeviceInfo;
        private System.Windows.Forms.Panel panelDeviceInfo;
        private System.Windows.Forms.Button btnNetSetting;
        private System.Windows.Forms.Button btnDeviceInfoSetting;
        private System.Windows.Forms.GroupBox gbxOther;
        private System.Windows.Forms.Button btnSystemRestart;
    }
}

