namespace Adam4080D
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
            this.panelAlarm = new System.Windows.Forms.Panel();
            this.btnClearLatch = new System.Windows.Forms.Button();
            this.txtHighAlarm = new System.Windows.Forms.TextBox();
            this.txtLowAlarm = new System.Windows.Forms.TextBox();
            this.btnHighAlarm = new System.Windows.Forms.Button();
            this.btnLowAlarm = new System.Windows.Forms.Button();
            this.btnClearCounter = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtOverflow = new System.Windows.Forms.TextBox();
            this.txtCounting = new System.Windows.Forms.TextBox();
            this.cbxChannel = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panelLEDOutput = new System.Windows.Forms.Panel();
            this.btnLED = new System.Windows.Forms.Button();
            this.txtLED = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panelLED = new System.Windows.Forms.Panel();
            this.btnApplyLED = new System.Windows.Forms.Button();
            this.cbxLedSource = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
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
            this.panelAlarm.SuspendLayout();
            this.panelLEDOutput.SuspendLayout();
            this.panelLED.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelCount
            // 
            this.panelCount.BackColor = System.Drawing.Color.SkyBlue;
            this.panelCount.Controls.Add(this.panelAlarm);
            this.panelCount.Controls.Add(this.btnClearCounter);
            this.panelCount.Controls.Add(this.btnStop);
            this.panelCount.Controls.Add(this.btnStart);
            this.panelCount.Controls.Add(this.txtOverflow);
            this.panelCount.Controls.Add(this.txtCounting);
            this.panelCount.Controls.Add(this.cbxChannel);
            this.panelCount.Controls.Add(this.label9);
            this.panelCount.Controls.Add(this.label8);
            this.panelCount.Controls.Add(this.label7);
            this.panelCount.Location = new System.Drawing.Point(3, 214);
            this.panelCount.Name = "panelCount";
            this.panelCount.Size = new System.Drawing.Size(336, 194);
            // 
            // panelAlarm
            // 
            this.panelAlarm.Controls.Add(this.btnClearLatch);
            this.panelAlarm.Controls.Add(this.txtHighAlarm);
            this.panelAlarm.Controls.Add(this.txtLowAlarm);
            this.panelAlarm.Controls.Add(this.btnHighAlarm);
            this.panelAlarm.Controls.Add(this.btnLowAlarm);
            this.panelAlarm.Location = new System.Drawing.Point(0, 108);
            this.panelAlarm.Name = "panelAlarm";
            this.panelAlarm.Size = new System.Drawing.Size(335, 86);
            // 
            // btnClearLatch
            // 
            this.btnClearLatch.Location = new System.Drawing.Point(225, 10);
            this.btnClearLatch.Name = "btnClearLatch";
            this.btnClearLatch.Size = new System.Drawing.Size(102, 25);
            this.btnClearLatch.TabIndex = 4;
            this.btnClearLatch.Text = "Clear latch alarm";
            this.btnClearLatch.Click += new System.EventHandler(this.btnClearLatch_Click);
            // 
            // txtHighAlarm
            // 
            this.txtHighAlarm.Location = new System.Drawing.Point(94, 54);
            this.txtHighAlarm.Name = "txtHighAlarm";
            this.txtHighAlarm.ReadOnly = true;
            this.txtHighAlarm.Size = new System.Drawing.Size(100, 23);
            this.txtHighAlarm.TabIndex = 3;
            // 
            // txtLowAlarm
            // 
            this.txtLowAlarm.Location = new System.Drawing.Point(93, 12);
            this.txtLowAlarm.Name = "txtLowAlarm";
            this.txtLowAlarm.ReadOnly = true;
            this.txtLowAlarm.Size = new System.Drawing.Size(100, 23);
            this.txtLowAlarm.TabIndex = 2;
            // 
            // btnHighAlarm
            // 
            this.btnHighAlarm.Location = new System.Drawing.Point(5, 52);
            this.btnHighAlarm.Name = "btnHighAlarm";
            this.btnHighAlarm.Size = new System.Drawing.Size(75, 23);
            this.btnHighAlarm.TabIndex = 1;
            this.btnHighAlarm.Text = "High alarm";
            this.btnHighAlarm.Click += new System.EventHandler(this.btnHighAlarm_Click);
            // 
            // btnLowAlarm
            // 
            this.btnLowAlarm.Location = new System.Drawing.Point(5, 12);
            this.btnLowAlarm.Name = "btnLowAlarm";
            this.btnLowAlarm.Size = new System.Drawing.Size(75, 23);
            this.btnLowAlarm.TabIndex = 0;
            this.btnLowAlarm.Text = "Low alarm";
            this.btnLowAlarm.Click += new System.EventHandler(this.btnLowAlarm_Click);
            // 
            // btnClearCounter
            // 
            this.btnClearCounter.Location = new System.Drawing.Point(225, 73);
            this.btnClearCounter.Name = "btnClearCounter";
            this.btnClearCounter.Size = new System.Drawing.Size(102, 29);
            this.btnClearCounter.TabIndex = 18;
            this.btnClearCounter.Text = "Clear to startup";
            this.btnClearCounter.Click += new System.EventHandler(this.btnClearCounter_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(225, 39);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(102, 28);
            this.btnStop.TabIndex = 17;
            this.btnStop.Text = "Stop counting";
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(225, 6);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(102, 27);
            this.btnStart.TabIndex = 16;
            this.btnStart.Text = "Start counting";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtOverflow
            // 
            this.txtOverflow.Location = new System.Drawing.Point(93, 78);
            this.txtOverflow.Name = "txtOverflow";
            this.txtOverflow.ReadOnly = true;
            this.txtOverflow.Size = new System.Drawing.Size(100, 23);
            this.txtOverflow.TabIndex = 5;
            // 
            // txtCounting
            // 
            this.txtCounting.Location = new System.Drawing.Point(93, 44);
            this.txtCounting.Name = "txtCounting";
            this.txtCounting.ReadOnly = true;
            this.txtCounting.Size = new System.Drawing.Size(100, 23);
            this.txtCounting.TabIndex = 4;
            // 
            // cbxChannel
            // 
            this.cbxChannel.Location = new System.Drawing.Point(93, 9);
            this.cbxChannel.Name = "cbxChannel";
            this.cbxChannel.Size = new System.Drawing.Size(108, 23);
            this.cbxChannel.TabIndex = 3;
            this.cbxChannel.SelectedIndexChanged += new System.EventHandler(this.cbxChannel_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(3, 81);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 20);
            this.label9.Text = "Overflow:";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(3, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 20);
            this.label8.Text = "Counting:";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(3, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 20);
            this.label7.Text = "Channel index:";
            // 
            // panelLEDOutput
            // 
            this.panelLEDOutput.Controls.Add(this.btnLED);
            this.panelLEDOutput.Controls.Add(this.txtLED);
            this.panelLEDOutput.Controls.Add(this.label6);
            this.panelLEDOutput.Location = new System.Drawing.Point(3, 178);
            this.panelLEDOutput.Name = "panelLEDOutput";
            this.panelLEDOutput.Size = new System.Drawing.Size(336, 36);
            // 
            // btnLED
            // 
            this.btnLED.Location = new System.Drawing.Point(252, 6);
            this.btnLED.Name = "btnLED";
            this.btnLED.Size = new System.Drawing.Size(75, 23);
            this.btnLED.TabIndex = 4;
            this.btnLED.Text = "Set LED";
            this.btnLED.Click += new System.EventHandler(this.btnLED_Click);
            // 
            // txtLED
            // 
            this.txtLED.Location = new System.Drawing.Point(85, 6);
            this.txtLED.Name = "txtLED";
            this.txtLED.Size = new System.Drawing.Size(100, 23);
            this.txtLED.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(3, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 19);
            this.label6.Text = "LED output:";
            // 
            // panelLED
            // 
            this.panelLED.Controls.Add(this.btnApplyLED);
            this.panelLED.Controls.Add(this.cbxLedSource);
            this.panelLED.Controls.Add(this.label5);
            this.panelLED.Location = new System.Drawing.Point(3, 140);
            this.panelLED.Name = "panelLED";
            this.panelLED.Size = new System.Drawing.Size(336, 74);
            // 
            // btnApplyLED
            // 
            this.btnApplyLED.Location = new System.Drawing.Point(252, 10);
            this.btnApplyLED.Name = "btnApplyLED";
            this.btnApplyLED.Size = new System.Drawing.Size(75, 23);
            this.btnApplyLED.TabIndex = 3;
            this.btnApplyLED.Text = "Apply";
            this.btnApplyLED.Click += new System.EventHandler(this.btnApplyLED_Click);
            // 
            // cbxLedSource
            // 
            this.cbxLedSource.Location = new System.Drawing.Point(85, 10);
            this.cbxLedSource.Name = "cbxLedSource";
            this.cbxLedSource.Size = new System.Drawing.Size(121, 23);
            this.cbxLedSource.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 18);
            this.label5.Text = "LED source:";
            // 
            // txtCounter1
            // 
            this.txtCounter1.Location = new System.Drawing.Point(93, 112);
            this.txtCounter1.Name = "txtCounter1";
            this.txtCounter1.Size = new System.Drawing.Size(125, 23);
            this.txtCounter1.TabIndex = 39;
            // 
            // txtCounter0
            // 
            this.txtCounter0.Location = new System.Drawing.Point(93, 77);
            this.txtCounter0.Name = "txtCounter0";
            this.txtCounter0.Size = new System.Drawing.Size(125, 23);
            this.txtCounter0.TabIndex = 38;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 20);
            this.label4.Text = "Ch-1 value:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 20);
            this.label3.Text = "Ch-0 value:";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(263, 6);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 37;
            this.buttonStart.Text = "Start";
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // txtReadCount
            // 
            this.txtReadCount.Location = new System.Drawing.Point(93, 40);
            this.txtReadCount.Name = "txtReadCount";
            this.txtReadCount.ReadOnly = true;
            this.txtReadCount.Size = new System.Drawing.Size(125, 23);
            this.txtReadCount.TabIndex = 36;
            this.txtReadCount.Text = "0";
            // 
            // txtModule
            // 
            this.txtModule.Location = new System.Drawing.Point(93, 6);
            this.txtModule.Name = "txtModule";
            this.txtModule.Size = new System.Drawing.Size(125, 23);
            this.txtModule.TabIndex = 35;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 20);
            this.label2.Text = "Read count:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 18);
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
            this.ClientSize = new System.Drawing.Size(343, 413);
            this.Controls.Add(this.panelCount);
            this.Controls.Add(this.panelLEDOutput);
            this.Controls.Add(this.panelLED);
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
            this.Text = "Adam4080D Sample Program (C#)";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
            this.panelCount.ResumeLayout(false);
            this.panelAlarm.ResumeLayout(false);
            this.panelLEDOutput.ResumeLayout(false);
            this.panelLED.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelCount;
        private System.Windows.Forms.Panel panelAlarm;
        private System.Windows.Forms.Button btnClearLatch;
        private System.Windows.Forms.TextBox txtHighAlarm;
        private System.Windows.Forms.TextBox txtLowAlarm;
        private System.Windows.Forms.Button btnHighAlarm;
        private System.Windows.Forms.Button btnLowAlarm;
        private System.Windows.Forms.Button btnClearCounter;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtOverflow;
        private System.Windows.Forms.TextBox txtCounting;
        private System.Windows.Forms.ComboBox cbxChannel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panelLEDOutput;
        private System.Windows.Forms.Button btnLED;
        private System.Windows.Forms.TextBox txtLED;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panelLED;
        private System.Windows.Forms.Button btnApplyLED;
        private System.Windows.Forms.ComboBox cbxLedSource;
        private System.Windows.Forms.Label label5;
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

