namespace ComPortTest
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
            this.btnSend = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.lsbxRecv = new System.Windows.Forms.ListBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbxWriteTimeout = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbxReadTimeout = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxStopbits = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxParity = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxDatabits = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxBaudrate = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxCOM = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(366, 188);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 41;
            this.btnSend.Text = "Send";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(1, 220);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(113, 18);
            this.label9.Text = "Receiving string";
            // 
            // lsbxRecv
            // 
            this.lsbxRecv.Location = new System.Drawing.Point(3, 239);
            this.lsbxRecv.Name = "lsbxRecv";
            this.lsbxRecv.Size = new System.Drawing.Size(438, 82);
            this.lsbxRecv.TabIndex = 40;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(366, 38);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 39;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(366, 9);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 38;
            this.btnOpen.Text = "Open";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(3, 188);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(341, 23);
            this.txtSend.TabIndex = 37;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(1, 171);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 24);
            this.label8.Text = "Sending string";
            // 
            // cbxWriteTimeout
            // 
            this.cbxWriteTimeout.Items.Add("100");
            this.cbxWriteTimeout.Items.Add("500");
            this.cbxWriteTimeout.Items.Add("1000");
            this.cbxWriteTimeout.Items.Add("5000");
            this.cbxWriteTimeout.Location = new System.Drawing.Point(264, 40);
            this.cbxWriteTimeout.Name = "cbxWriteTimeout";
            this.cbxWriteTimeout.Size = new System.Drawing.Size(97, 23);
            this.cbxWriteTimeout.TabIndex = 36;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(175, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 16);
            this.label7.Text = "Write timeout:";
            // 
            // cbxReadTimeout
            // 
            this.cbxReadTimeout.Items.Add("100");
            this.cbxReadTimeout.Items.Add("500");
            this.cbxReadTimeout.Items.Add("1000");
            this.cbxReadTimeout.Items.Add("5000");
            this.cbxReadTimeout.Location = new System.Drawing.Point(263, 9);
            this.cbxReadTimeout.Name = "cbxReadTimeout";
            this.cbxReadTimeout.Size = new System.Drawing.Size(97, 23);
            this.cbxReadTimeout.TabIndex = 35;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(174, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 18);
            this.label6.Text = "Read timeout:";
            // 
            // cbxStopbits
            // 
            this.cbxStopbits.Items.Add("1");
            this.cbxStopbits.Items.Add("1.5");
            this.cbxStopbits.Items.Add("2");
            this.cbxStopbits.Location = new System.Drawing.Point(66, 127);
            this.cbxStopbits.Name = "cbxStopbits";
            this.cbxStopbits.Size = new System.Drawing.Size(97, 23);
            this.cbxStopbits.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 130);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 20);
            this.label5.Text = "Stopbits:";
            // 
            // cbxParity
            // 
            this.cbxParity.Items.Add("None");
            this.cbxParity.Items.Add("Odd");
            this.cbxParity.Items.Add("Even");
            this.cbxParity.Items.Add("Mark");
            this.cbxParity.Items.Add("Space");
            this.cbxParity.Location = new System.Drawing.Point(66, 98);
            this.cbxParity.Name = "cbxParity";
            this.cbxParity.Size = new System.Drawing.Size(97, 23);
            this.cbxParity.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 20);
            this.label4.Text = "Parity:";
            // 
            // cbxDatabits
            // 
            this.cbxDatabits.Items.Add("5");
            this.cbxDatabits.Items.Add("6");
            this.cbxDatabits.Items.Add("7");
            this.cbxDatabits.Items.Add("8");
            this.cbxDatabits.Location = new System.Drawing.Point(66, 69);
            this.cbxDatabits.Name = "cbxDatabits";
            this.cbxDatabits.Size = new System.Drawing.Size(97, 23);
            this.cbxDatabits.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.Text = "Databits:";
            // 
            // cbxBaudrate
            // 
            this.cbxBaudrate.Items.Add("2400");
            this.cbxBaudrate.Items.Add("4800");
            this.cbxBaudrate.Items.Add("9600");
            this.cbxBaudrate.Items.Add("19200");
            this.cbxBaudrate.Items.Add("38400");
            this.cbxBaudrate.Items.Add("57600");
            this.cbxBaudrate.Items.Add("115200");
            this.cbxBaudrate.Location = new System.Drawing.Point(66, 40);
            this.cbxBaudrate.Name = "cbxBaudrate";
            this.cbxBaudrate.Size = new System.Drawing.Size(97, 23);
            this.cbxBaudrate.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.Text = "Baudrate:";
            // 
            // cbxCOM
            // 
            this.cbxCOM.Items.Add("1");
            this.cbxCOM.Items.Add("2");
            this.cbxCOM.Items.Add("3");
            this.cbxCOM.Items.Add("4");
            this.cbxCOM.Location = new System.Drawing.Point(66, 11);
            this.cbxCOM.Name = "cbxCOM";
            this.cbxCOM.Size = new System.Drawing.Size(97, 23);
            this.cbxCOM.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.Text = "COM:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(444, 325);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lsbxRecv);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.txtSend);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbxWriteTimeout);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbxReadTimeout);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbxStopbits);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbxParity);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbxDatabits);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxBaudrate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxCOM);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "ComPortTest Sample Program (C#)";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox lsbxRecv;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbxWriteTimeout;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbxReadTimeout;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxStopbits;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxParity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxDatabits;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxBaudrate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxCOM;
        private System.Windows.Forms.Label label1;
    }
}

