namespace UdpTcpAsciiCmd
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
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRespond = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(205, 8);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "Connect";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(37, 8);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(154, 23);
            this.txtIP.TabIndex = 4;
            this.txtIP.Text = "10.0.0.1";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(5, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 23);
            this.label1.Text = "IP:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(5, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 20);
            this.label2.Text = "ASCII Command";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(426, 80);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(66, 23);
            this.btnSend.TabIndex = 10;
            this.btnSend.Text = "Send";
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(89, 80);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(324, 23);
            this.txtSend.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(19, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 20);
            this.label3.Text = "Send:";
            // 
            // txtRespond
            // 
            this.txtRespond.Location = new System.Drawing.Point(89, 109);
            this.txtRespond.Name = "txtRespond";
            this.txtRespond.ReadOnly = true;
            this.txtRespond.Size = new System.Drawing.Size(324, 23);
            this.txtRespond.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(19, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 20);
            this.label4.Text = "Respond:";
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(89, 138);
            this.txtTime.Name = "txtTime";
            this.txtTime.ReadOnly = true;
            this.txtTime.Size = new System.Drawing.Size(324, 23);
            this.txtTime.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(19, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 20);
            this.label5.Text = "Time:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(503, 174);
            this.Controls.Add(this.txtTime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtRespond);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtSend);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "UDP ASCII Command (C#)";
            this.Closed += new System.EventHandler(this.Form1_Closed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRespond;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTime;
        private System.Windows.Forms.Label label5;
    }
}

