namespace Adam5080
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
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCounter3 = new System.Windows.Forms.TextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.txtCounter2 = new System.Windows.Forms.TextBox();
            this.txtCounter1 = new System.Windows.Forms.TextBox();
            this.txtCounter0 = new System.Windows.Forms.TextBox();
            this.txtReadCount = new System.Windows.Forms.TextBox();
            this.txtModule = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClearCounter = new System.Windows.Forms.Button();
            this.txtOverflow = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panelCount = new System.Windows.Forms.Panel();
            this.btnStop = new System.Windows.Forms.Button();
            this.txtCounting = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxChannel = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelCount.SuspendLayout();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(2, 193);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 12);
            this.label9.TabIndex = 64;
            this.label9.Text = "Ch-3 value:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(2, 157);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 12);
            this.label8.TabIndex = 63;
            this.label8.Text = "Ch-2 value:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 12);
            this.label4.TabIndex = 62;
            this.label4.Text = "Ch-1 value:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 12);
            this.label3.TabIndex = 61;
            this.label3.Text = "Ch-0 value:";
            // 
            // txtCounter3
            // 
            this.txtCounter3.Location = new System.Drawing.Point(80, 190);
            this.txtCounter3.Name = "txtCounter3";
            this.txtCounter3.Size = new System.Drawing.Size(119, 22);
            this.txtCounter3.TabIndex = 60;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(279, 6);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 59;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // txtCounter2
            // 
            this.txtCounter2.Location = new System.Drawing.Point(80, 154);
            this.txtCounter2.Name = "txtCounter2";
            this.txtCounter2.Size = new System.Drawing.Size(119, 22);
            this.txtCounter2.TabIndex = 58;
            // 
            // txtCounter1
            // 
            this.txtCounter1.Location = new System.Drawing.Point(80, 118);
            this.txtCounter1.Name = "txtCounter1";
            this.txtCounter1.Size = new System.Drawing.Size(119, 22);
            this.txtCounter1.TabIndex = 57;
            // 
            // txtCounter0
            // 
            this.txtCounter0.Location = new System.Drawing.Point(80, 82);
            this.txtCounter0.Name = "txtCounter0";
            this.txtCounter0.Size = new System.Drawing.Size(119, 22);
            this.txtCounter0.TabIndex = 56;
            // 
            // txtReadCount
            // 
            this.txtReadCount.Location = new System.Drawing.Point(80, 39);
            this.txtReadCount.Name = "txtReadCount";
            this.txtReadCount.ReadOnly = true;
            this.txtReadCount.Size = new System.Drawing.Size(119, 22);
            this.txtReadCount.TabIndex = 55;
            this.txtReadCount.Text = "0";
            // 
            // txtModule
            // 
            this.txtModule.Location = new System.Drawing.Point(80, 6);
            this.txtModule.Name = "txtModule";
            this.txtModule.Size = new System.Drawing.Size(119, 22);
            this.txtModule.TabIndex = 54;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 12);
            this.label2.TabIndex = 53;
            this.label2.Text = "Read count:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 12);
            this.label1.TabIndex = 52;
            this.label1.Text = "Module name:";
            // 
            // btnClearCounter
            // 
            this.btnClearCounter.Location = new System.Drawing.Point(257, 88);
            this.btnClearCounter.Name = "btnClearCounter";
            this.btnClearCounter.Size = new System.Drawing.Size(93, 34);
            this.btnClearCounter.TabIndex = 15;
            this.btnClearCounter.Text = "Clear to startup";
            this.btnClearCounter.UseVisualStyleBackColor = true;
            this.btnClearCounter.Click += new System.EventHandler(this.btnClearCounter_Click);
            // 
            // txtOverflow
            // 
            this.txtOverflow.Location = new System.Drawing.Point(85, 75);
            this.txtOverflow.Name = "txtOverflow";
            this.txtOverflow.ReadOnly = true;
            this.txtOverflow.Size = new System.Drawing.Size(121, 22);
            this.txtOverflow.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "Overflow:";
            // 
            // panelCount
            // 
            this.panelCount.BackColor = System.Drawing.Color.SkyBlue;
            this.panelCount.Controls.Add(this.btnClearCounter);
            this.panelCount.Controls.Add(this.btnStop);
            this.panelCount.Controls.Add(this.txtOverflow);
            this.panelCount.Controls.Add(this.label5);
            this.panelCount.Controls.Add(this.txtCounting);
            this.panelCount.Controls.Add(this.label6);
            this.panelCount.Controls.Add(this.cbxChannel);
            this.panelCount.Controls.Add(this.label7);
            this.panelCount.Controls.Add(this.btnStart);
            this.panelCount.Location = new System.Drawing.Point(4, 223);
            this.panelCount.Name = "panelCount";
            this.panelCount.Size = new System.Drawing.Size(361, 128);
            this.panelCount.TabIndex = 65;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(257, 46);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(93, 36);
            this.btnStop.TabIndex = 14;
            this.btnStop.Text = "Stop counting";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // txtCounting
            // 
            this.txtCounting.Location = new System.Drawing.Point(85, 43);
            this.txtCounting.Name = "txtCounting";
            this.txtCounting.ReadOnly = true;
            this.txtCounting.Size = new System.Drawing.Size(121, 22);
            this.txtCounting.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 12);
            this.label6.TabIndex = 8;
            this.label6.Text = "Counting:";
            // 
            // cbxChannel
            // 
            this.cbxChannel.FormattingEnabled = true;
            this.cbxChannel.Location = new System.Drawing.Point(85, 13);
            this.cbxChannel.Name = "cbxChannel";
            this.cbxChannel.Size = new System.Drawing.Size(121, 20);
            this.cbxChannel.TabIndex = 7;
            this.cbxChannel.SelectedIndexChanged += new System.EventHandler(this.cbxChannel_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "Channel index:";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(257, 4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(93, 36);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Start counting";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 353);
            this.Controls.Add(this.panelCount);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCounter3);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.txtCounter2);
            this.Controls.Add(this.txtCounter1);
            this.Controls.Add(this.txtCounter0);
            this.Controls.Add(this.txtReadCount);
            this.Controls.Add(this.txtModule);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Adam5080 sample program (C#)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panelCount.ResumeLayout(false);
            this.panelCount.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCounter3;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.TextBox txtCounter2;
        private System.Windows.Forms.TextBox txtCounter1;
        private System.Windows.Forms.TextBox txtCounter0;
        private System.Windows.Forms.TextBox txtReadCount;
        private System.Windows.Forms.TextBox txtModule;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClearCounter;
        private System.Windows.Forms.TextBox txtOverflow;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelCount;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TextBox txtCounting;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxChannel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Timer timer1;
    }
}

