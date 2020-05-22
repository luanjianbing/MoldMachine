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
            this.label1 = new System.Windows.Forms.Label();
            this.cbxCOM = new System.Windows.Forms.ComboBox();
            this.cbxBaudrate = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxDatabits = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxParity = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxStopbits = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxReadTimeout = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxWriteTimeout = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lsbxRecv = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "COM:";
            // 
            // cbxCOM
            // 
            this.cbxCOM.FormattingEnabled = true;
            this.cbxCOM.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cbxCOM.Location = new System.Drawing.Point(56, 9);
            this.cbxCOM.Name = "cbxCOM";
            this.cbxCOM.Size = new System.Drawing.Size(103, 20);
            this.cbxCOM.TabIndex = 1;
            // 
            // cbxBaudrate
            // 
            this.cbxBaudrate.FormattingEnabled = true;
            this.cbxBaudrate.Items.AddRange(new object[] {
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.cbxBaudrate.Location = new System.Drawing.Point(56, 38);
            this.cbxBaudrate.Name = "cbxBaudrate";
            this.cbxBaudrate.Size = new System.Drawing.Size(103, 20);
            this.cbxBaudrate.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Baudrate:";
            // 
            // cbxDatabits
            // 
            this.cbxDatabits.FormattingEnabled = true;
            this.cbxDatabits.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8"});
            this.cbxDatabits.Location = new System.Drawing.Point(56, 67);
            this.cbxDatabits.Name = "cbxDatabits";
            this.cbxDatabits.Size = new System.Drawing.Size(103, 20);
            this.cbxDatabits.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Databits:";
            // 
            // cbxParity
            // 
            this.cbxParity.FormattingEnabled = true;
            this.cbxParity.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even",
            "Mark",
            "Space"});
            this.cbxParity.Location = new System.Drawing.Point(56, 96);
            this.cbxParity.Name = "cbxParity";
            this.cbxParity.Size = new System.Drawing.Size(103, 20);
            this.cbxParity.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "Parity:";
            // 
            // cbxStopbits
            // 
            this.cbxStopbits.FormattingEnabled = true;
            this.cbxStopbits.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.cbxStopbits.Location = new System.Drawing.Point(56, 125);
            this.cbxStopbits.Name = "cbxStopbits";
            this.cbxStopbits.Size = new System.Drawing.Size(103, 20);
            this.cbxStopbits.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "Stopbits:";
            // 
            // cbxReadTimeout
            // 
            this.cbxReadTimeout.FormattingEnabled = true;
            this.cbxReadTimeout.Items.AddRange(new object[] {
            "100",
            "500",
            "1000",
            "5000"});
            this.cbxReadTimeout.Location = new System.Drawing.Point(240, 7);
            this.cbxReadTimeout.Name = "cbxReadTimeout";
            this.cbxReadTimeout.Size = new System.Drawing.Size(103, 20);
            this.cbxReadTimeout.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(164, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "Read timeout:";
            // 
            // cbxWriteTimeout
            // 
            this.cbxWriteTimeout.FormattingEnabled = true;
            this.cbxWriteTimeout.Items.AddRange(new object[] {
            "100",
            "500",
            "1000",
            "5000"});
            this.cbxWriteTimeout.Location = new System.Drawing.Point(241, 38);
            this.cbxWriteTimeout.Name = "cbxWriteTimeout";
            this.cbxWriteTimeout.Size = new System.Drawing.Size(103, 20);
            this.cbxWriteTimeout.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(165, 41);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "Write timeout:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(0, 169);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "Sending string";
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(2, 184);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(341, 22);
            this.txtSend.TabIndex = 15;
            this.txtSend.Text = "#01";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(365, 4);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 16;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(365, 33);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lsbxRecv
            // 
            this.lsbxRecv.FormattingEnabled = true;
            this.lsbxRecv.ItemHeight = 12;
            this.lsbxRecv.Location = new System.Drawing.Point(2, 233);
            this.lsbxRecv.Name = "lsbxRecv";
            this.lsbxRecv.Size = new System.Drawing.Size(438, 88);
            this.lsbxRecv.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(0, 218);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 12);
            this.label9.TabIndex = 19;
            this.label9.Text = "Receiving string";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(365, 182);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 20;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 325);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "ComPortTest sample program (C#)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxCOM;
        private System.Windows.Forms.ComboBox cbxBaudrate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxDatabits;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxParity;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxStopbits;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxReadTimeout;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxWriteTimeout;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListBox lsbxRecv;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSend;
    }
}

