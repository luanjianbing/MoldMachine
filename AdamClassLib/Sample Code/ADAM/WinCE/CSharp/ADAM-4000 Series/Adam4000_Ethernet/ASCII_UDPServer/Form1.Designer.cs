namespace ASCII_UDPServer
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxLocal = new System.Windows.Forms.TextBox();
            this.textBoxUDPRecv = new System.Windows.Forms.TextBox();
            this.textBoxUDPSent = new System.Windows.Forms.TextBox();
            this.textBoxSerialSent = new System.Windows.Forms.TextBox();
            this.textBoxSerialRecv = new System.Windows.Forms.TextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.Text = "Local IPs:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.Text = "UDP received:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.Text = "UDP sent:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(284, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.Text = "Serial sent:";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(284, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 20);
            this.label5.Text = "Serial received:";
            // 
            // textBoxLocal
            // 
            this.textBoxLocal.Location = new System.Drawing.Point(70, 13);
            this.textBoxLocal.Name = "textBoxLocal";
            this.textBoxLocal.Size = new System.Drawing.Size(238, 23);
            this.textBoxLocal.TabIndex = 9;
            // 
            // textBoxUDPRecv
            // 
            this.textBoxUDPRecv.Location = new System.Drawing.Point(92, 61);
            this.textBoxUDPRecv.Name = "textBoxUDPRecv";
            this.textBoxUDPRecv.Size = new System.Drawing.Size(161, 23);
            this.textBoxUDPRecv.TabIndex = 10;
            // 
            // textBoxUDPSent
            // 
            this.textBoxUDPSent.Location = new System.Drawing.Point(92, 106);
            this.textBoxUDPSent.Name = "textBoxUDPSent";
            this.textBoxUDPSent.Size = new System.Drawing.Size(161, 23);
            this.textBoxUDPSent.TabIndex = 11;
            // 
            // textBoxSerialSent
            // 
            this.textBoxSerialSent.Location = new System.Drawing.Point(384, 58);
            this.textBoxSerialSent.Name = "textBoxSerialSent";
            this.textBoxSerialSent.Size = new System.Drawing.Size(161, 23);
            this.textBoxSerialSent.TabIndex = 12;
            // 
            // textBoxSerialRecv
            // 
            this.textBoxSerialRecv.Location = new System.Drawing.Point(384, 106);
            this.textBoxSerialRecv.Name = "textBoxSerialRecv";
            this.textBoxSerialRecv.Size = new System.Drawing.Size(161, 23);
            this.textBoxSerialRecv.TabIndex = 13;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(473, 13);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(72, 20);
            this.buttonStart.TabIndex = 14;
            this.buttonStart.Text = "Start";
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(576, 141);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.textBoxSerialRecv);
            this.Controls.Add(this.textBoxSerialSent);
            this.Controls.Add(this.textBoxUDPSent);
            this.Controls.Add(this.textBoxUDPRecv);
            this.Controls.Add(this.textBoxLocal);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Adam4000_Ethernet ASCII_UDPServer Sample Program (C#)";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxLocal;
        private System.Windows.Forms.TextBox textBoxUDPRecv;
        private System.Windows.Forms.TextBox textBoxUDPSent;
        private System.Windows.Forms.TextBox textBoxSerialSent;
        private System.Windows.Forms.TextBox textBoxSerialRecv;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Timer timer1;
    }
}

