namespace ADAM_6200_REST
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
            this.btnConvert = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtXML = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtAcount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPostData = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTarget = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(93, 330);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(445, 23);
            this.btnConvert.TabIndex = 31;
            this.btnConvert.Text = "Convert Dataset";
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(10, 213);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 18);
            this.label7.Text = "XML data:";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(93, 177);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(445, 23);
            this.btnSend.TabIndex = 30;
            this.btnSend.Text = "Send HTTP reqeust";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtXML
            // 
            this.txtXML.AcceptsReturn = true;
            this.txtXML.Location = new System.Drawing.Point(93, 213);
            this.txtXML.Multiline = true;
            this.txtXML.Name = "txtXML";
            this.txtXML.ReadOnly = true;
            this.txtXML.Size = new System.Drawing.Size(445, 104);
            this.txtXML.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(11, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 22);
            this.label6.Text = "Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(94, 143);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(100, 23);
            this.txtPassword.TabIndex = 28;
            this.txtPassword.Text = "00000000";
            // 
            // txtAcount
            // 
            this.txtAcount.Location = new System.Drawing.Point(94, 109);
            this.txtAcount.Name = "txtAcount";
            this.txtAcount.Size = new System.Drawing.Size(100, 23);
            this.txtAcount.TabIndex = 27;
            this.txtAcount.Text = "root";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(10, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 19);
            this.label5.Text = "Account:";
            // 
            // txtPostData
            // 
            this.txtPostData.Location = new System.Drawing.Point(94, 74);
            this.txtPostData.Name = "txtPostData";
            this.txtPostData.Size = new System.Drawing.Size(445, 23);
            this.txtPostData.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(10, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 19);
            this.label4.Text = "POST data:";
            // 
            // txtURL
            // 
            this.txtURL.BackColor = System.Drawing.SystemColors.Control;
            this.txtURL.Location = new System.Drawing.Point(93, 41);
            this.txtURL.Name = "txtURL";
            this.txtURL.ReadOnly = true;
            this.txtURL.Size = new System.Drawing.Size(445, 23);
            this.txtURL.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(199, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(8, 12);
            this.label3.Text = "/";
            // 
            // txtTarget
            // 
            this.txtTarget.Location = new System.Drawing.Point(216, 8);
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.Size = new System.Drawing.Size(322, 23);
            this.txtTarget.TabIndex = 24;
            this.txtTarget.Text = "digitalinput/all/value";
            this.txtTarget.TextChanged += new System.EventHandler(this.url_TextChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(10, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 18);
            this.label2.Text = "URL:";
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Location = new System.Drawing.Point(93, 8);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(100, 23);
            this.txtIPAddress.TabIndex = 23;
            this.txtIPAddress.Text = "10.0.0.1";
            this.txtIPAddress.TextChanged += new System.EventHandler(this.url_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 19);
            this.label1.Text = "IP address:";
            // 
            // listView1
            // 
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(94, 368);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(444, 99);
            this.listView1.TabIndex = 39;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(544, 481);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtXML);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtAcount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPostData);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTarget);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIPAddress);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "ADAM-6200 REST Sample";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtXML;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtAcount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPostData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTarget;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView1;
    }
}

