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
            this.txtCounter1 = new System.Windows.Forms.TextBox();
            this.txtCounter0 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.txtReadCount = new System.Windows.Forms.TextBox();
            this.txtModule = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer();
            this.panelCount.SuspendLayout();
            this.SuspendLayout();
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
            this.panelCount.Location = new System.Drawing.Point(4, 152);
            this.panelCount.Name = "panelCount";
            this.panelCount.Size = new System.Drawing.Size(361, 148);
            // 
            // btnClearCounter
            // 
            this.btnClearCounter.Location = new System.Drawing.Point(257, 106);
            this.btnClearCounter.Name = "btnClearCounter";
            this.btnClearCounter.Size = new System.Drawing.Size(101, 34);
            this.btnClearCounter.TabIndex = 15;
            this.btnClearCounter.Text = "Clear to startup";
            this.btnClearCounter.Click += new System.EventHandler(this.btnClearCounter_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(257, 61);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(101, 36);
            this.btnStop.TabIndex = 14;
            this.btnStop.Text = "Stop counting";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // txtAlarm
            // 
            this.txtAlarm.Location = new System.Drawing.Point(106, 114);
            this.txtAlarm.Name = "txtAlarm";
            this.txtAlarm.ReadOnly = true;
            this.txtAlarm.Size = new System.Drawing.Size(100, 23);
            this.txtAlarm.TabIndex = 13;
            // 
            // btnAlarm
            // 
            this.btnAlarm.Location = new System.Drawing.Point(5, 114);
            this.btnAlarm.Name = "btnAlarm";
            this.btnAlarm.Size = new System.Drawing.Size(85, 23);
            this.btnAlarm.TabIndex = 12;
            this.btnAlarm.Text = "Alarm";
            this.btnAlarm.Click += new System.EventHandler(this.btnAlarm_Click);
            // 
            // txtOverflow
            // 
            this.txtOverflow.Location = new System.Drawing.Point(91, 75);
            this.txtOverflow.Name = "txtOverflow";
            this.txtOverflow.ReadOnly = true;
            this.txtOverflow.Size = new System.Drawing.Size(121, 23);
            this.txtOverflow.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(3, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 19);
            this.label8.Text = "Overflow:";
            // 
            // txtCounting
            // 
            this.txtCounting.Location = new System.Drawing.Point(91, 43);
            this.txtCounting.Name = "txtCounting";
            this.txtCounting.ReadOnly = true;
            this.txtCounting.Size = new System.Drawing.Size(121, 23);
            this.txtCounting.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(3, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 20);
            this.label6.Text = "Counting:";
            // 
            // cbxChannel
            // 
            this.cbxChannel.Location = new System.Drawing.Point(91, 13);
            this.cbxChannel.Name = "cbxChannel";
            this.cbxChannel.Size = new System.Drawing.Size(121, 23);
            this.cbxChannel.TabIndex = 7;
            this.cbxChannel.SelectedIndexChanged += new System.EventHandler(this.cbxChannel_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 20);
            this.label5.Text = "Channel index:";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(257, 16);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(101, 36);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "Start counting";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtCounter1
            // 
            this.txtCounter1.Location = new System.Drawing.Point(92, 112);
            this.txtCounter1.Name = "txtCounter1";
            this.txtCounter1.Size = new System.Drawing.Size(150, 23);
            this.txtCounter1.TabIndex = 28;
            // 
            // txtCounter0
            // 
            this.txtCounter0.Location = new System.Drawing.Point(92, 77);
            this.txtCounter0.Name = "txtCounter0";
            this.txtCounter0.Size = new System.Drawing.Size(150, 23);
            this.txtCounter0.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(4, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 20);
            this.label4.Text = "Ch-1 value:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(4, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.Text = "Ch-0 value:";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(279, 6);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 26;
            this.buttonStart.Text = "Start";
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // txtReadCount
            // 
            this.txtReadCount.Location = new System.Drawing.Point(92, 40);
            this.txtReadCount.Name = "txtReadCount";
            this.txtReadCount.ReadOnly = true;
            this.txtReadCount.Size = new System.Drawing.Size(150, 23);
            this.txtReadCount.TabIndex = 25;
            this.txtReadCount.Text = "0";
            // 
            // txtModule
            // 
            this.txtModule.Location = new System.Drawing.Point(92, 6);
            this.txtModule.Name = "txtModule";
            this.txtModule.Size = new System.Drawing.Size(150, 23);
            this.txtModule.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(4, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 20);
            this.label2.Text = "Read count:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 18);
            this.label1.Text = "Module name:";
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
            this.ClientSize = new System.Drawing.Size(368, 306);
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
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Adam4080 Sample Program (C#)";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
            this.panelCount.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCount;
        private System.Windows.Forms.Button btnClearCounter;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TextBox txtAlarm;
        private System.Windows.Forms.Button btnAlarm;
        private System.Windows.Forms.TextBox txtOverflow;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCounting;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxChannel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtCounter1;
        private System.Windows.Forms.TextBox txtCounter0;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.TextBox txtReadCount;
        private System.Windows.Forms.TextBox txtModule;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
    }
}

