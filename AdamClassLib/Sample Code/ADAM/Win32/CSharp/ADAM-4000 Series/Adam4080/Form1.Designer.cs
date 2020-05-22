namespace Adam4080
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
            this.txtReadCount = new System.Windows.Forms.TextBox();
            this.txtModule = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCounter0 = new System.Windows.Forms.TextBox();
            this.txtCounter1 = new System.Windows.Forms.TextBox();
            this.panelCount = new System.Windows.Forms.Panel();
            this.btnClearCounter = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.txtAlarm = new System.Windows.Forms.TextBox();
            this.btnAlarm = new System.Windows.Forms.Button();
            this.txtOverflow = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCounting = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxChannel = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelCount.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtReadCount
            // 
            this.txtReadCount.Location = new System.Drawing.Point(90, 40);
            this.txtReadCount.Name = "txtReadCount";
            this.txtReadCount.ReadOnly = true;
            this.txtReadCount.Size = new System.Drawing.Size(150, 22);
            this.txtReadCount.TabIndex = 13;
            this.txtReadCount.Text = "0";
            // 
            // txtModule
            // 
            this.txtModule.Location = new System.Drawing.Point(90, 6);
            this.txtModule.Name = "txtModule";
            this.txtModule.Size = new System.Drawing.Size(150, 22);
            this.txtModule.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "Read count:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "Module name:";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(284, 4);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 14;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "Ch-0 value:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 12);
            this.label4.TabIndex = 16;
            this.label4.Text = "Ch-1 value:";
            // 
            // txtCounter0
            // 
            this.txtCounter0.Location = new System.Drawing.Point(90, 77);
            this.txtCounter0.Name = "txtCounter0";
            this.txtCounter0.Size = new System.Drawing.Size(150, 22);
            this.txtCounter0.TabIndex = 17;
            // 
            // txtCounter1
            // 
            this.txtCounter1.Location = new System.Drawing.Point(90, 112);
            this.txtCounter1.Name = "txtCounter1";
            this.txtCounter1.Size = new System.Drawing.Size(150, 22);
            this.txtCounter1.TabIndex = 18;
            // 
            // panelCount
            // 
            this.panelCount.BackColor = System.Drawing.Color.SkyBlue;
            this.panelCount.Controls.Add(this.btnClearCounter);
            this.panelCount.Controls.Add(this.btnStop);
            this.panelCount.Controls.Add(this.txtAlarm);
            this.panelCount.Controls.Add(this.btnAlarm);
            this.panelCount.Controls.Add(this.txtOverflow);
            this.panelCount.Controls.Add(this.label8);
            this.panelCount.Controls.Add(this.txtCounting);
            this.panelCount.Controls.Add(this.label6);
            this.panelCount.Controls.Add(this.cbxChannel);
            this.panelCount.Controls.Add(this.label5);
            this.panelCount.Controls.Add(this.btnStart);
            this.panelCount.Location = new System.Drawing.Point(9, 152);
            this.panelCount.Name = "panelCount";
            this.panelCount.Size = new System.Drawing.Size(361, 148);
            this.panelCount.TabIndex = 19;
            // 
            // btnClearCounter
            // 
            this.btnClearCounter.Location = new System.Drawing.Point(257, 106);
            this.btnClearCounter.Name = "btnClearCounter";
            this.btnClearCounter.Size = new System.Drawing.Size(93, 34);
            this.btnClearCounter.TabIndex = 15;
            this.btnClearCounter.Text = "Clear to startup";
            this.btnClearCounter.UseVisualStyleBackColor = true;
            this.btnClearCounter.Click += new System.EventHandler(this.btnClearCounter_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(257, 61);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(93, 36);
            this.btnStop.TabIndex = 14;
            this.btnStop.Text = "Stop counting";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // txtAlarm
            // 
            this.txtAlarm.Location = new System.Drawing.Point(106, 114);
            this.txtAlarm.Name = "txtAlarm";
            this.txtAlarm.ReadOnly = true;
            this.txtAlarm.Size = new System.Drawing.Size(100, 22);
            this.txtAlarm.TabIndex = 13;
            // 
            // btnAlarm
            // 
            this.btnAlarm.Location = new System.Drawing.Point(5, 114);
            this.btnAlarm.Name = "btnAlarm";
            this.btnAlarm.Size = new System.Drawing.Size(85, 23);
            this.btnAlarm.TabIndex = 12;
            this.btnAlarm.Text = "Alarm";
            this.btnAlarm.UseVisualStyleBackColor = true;
            this.btnAlarm.Click += new System.EventHandler(this.btnAlarm_Click);
            // 
            // txtOverflow
            // 
            this.txtOverflow.Location = new System.Drawing.Point(85, 75);
            this.txtOverflow.Name = "txtOverflow";
            this.txtOverflow.ReadOnly = true;
            this.txtOverflow.Size = new System.Drawing.Size(121, 22);
            this.txtOverflow.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 12);
            this.label8.TabIndex = 10;
            this.label8.Text = "Overflow:";
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 12);
            this.label5.TabIndex = 6;
            this.label5.Text = "Channel index:";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(257, 16);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(93, 36);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Start counting";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 309);
            this.Controls.Add(this.panelCount);
            this.Controls.Add(this.txtCounter1);
            this.Controls.Add(this.txtCounter0);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.txtReadCount);
            this.Controls.Add(this.txtModule);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Adam4080 sample program (C#)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panelCount.ResumeLayout(false);
            this.panelCount.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtReadCount;
        private System.Windows.Forms.TextBox txtModule;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCounter0;
        private System.Windows.Forms.TextBox txtCounter1;
        private System.Windows.Forms.Panel panelCount;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ComboBox cbxChannel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCounting;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAlarm;
        private System.Windows.Forms.Button btnAlarm;
        private System.Windows.Forms.TextBox txtOverflow;
        private System.Windows.Forms.Button btnClearCounter;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Timer timer1;
    }
}

