namespace WISE_4000_REST
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtJSON = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtAcount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPatchData = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTarget = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.Items.Add("GET");
            this.comboBox1.Items.Add("PATCH");
            this.comboBox1.Location = new System.Drawing.Point(139, 147);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 50;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(48, 147);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 23);
            this.label8.Text = "Method:";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(49, 259);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 20);
            this.label7.Text = "JSON data:";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(139, 230);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(445, 23);
            this.btnSend.TabIndex = 49;
            this.btnSend.Text = "Send HTTP reqeust";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtJSON
            // 
            this.txtJSON.AcceptsReturn = true;
            this.txtJSON.Location = new System.Drawing.Point(139, 259);
            this.txtJSON.Multiline = true;
            this.txtJSON.Name = "txtJSON";
            this.txtJSON.ReadOnly = true;
            this.txtJSON.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtJSON.Size = new System.Drawing.Size(445, 158);
            this.txtJSON.TabIndex = 48;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(48, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 23);
            this.label6.Text = "Password:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(139, 119);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(100, 23);
            this.txtPassword.TabIndex = 47;
            this.txtPassword.Text = "00000000";
            // 
            // txtAcount
            // 
            this.txtAcount.Location = new System.Drawing.Point(139, 91);
            this.txtAcount.Name = "txtAcount";
            this.txtAcount.Size = new System.Drawing.Size(100, 23);
            this.txtAcount.TabIndex = 46;
            this.txtAcount.Text = "root";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(48, 91);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 23);
            this.label5.Text = "Account:";
            // 
            // txtPatchData
            // 
            this.txtPatchData.Location = new System.Drawing.Point(139, 173);
            this.txtPatchData.Multiline = true;
            this.txtPatchData.Name = "txtPatchData";
            this.txtPatchData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPatchData.Size = new System.Drawing.Size(445, 51);
            this.txtPatchData.TabIndex = 45;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(48, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 24);
            this.label4.Text = "Patch Data:";
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(139, 63);
            this.txtURL.Name = "txtURL";
            this.txtURL.ReadOnly = true;
            this.txtURL.Size = new System.Drawing.Size(445, 23);
            this.txtURL.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(245, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(8, 12);
            this.label3.Text = "/";
            // 
            // txtTarget
            // 
            this.txtTarget.Location = new System.Drawing.Point(262, 35);
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.Size = new System.Drawing.Size(322, 23);
            this.txtTarget.TabIndex = 43;
            this.txtTarget.Text = "profile";
            this.txtTarget.TextChanged += new System.EventHandler(this.url_TextChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(48, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 23);
            this.label2.Text = "URL:";
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Location = new System.Drawing.Point(139, 35);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(100, 23);
            this.txtIPAddress.TabIndex = 42;
            this.txtIPAddress.Text = "10.0.0.1";
            this.txtIPAddress.TextChanged += new System.EventHandler(this.url_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(48, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 15);
            this.label1.Text = "IP address:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(638, 455);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtJSON);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtAcount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPatchData);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTarget);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIPAddress);
            this.Controls.Add(this.label1);
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "WISE-4000 REST sample";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtJSON;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtAcount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPatchData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTarget;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.Label label1;
    }
}

