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
            this.components = new System.ComponentModel.Container();
            this.txtCounter1 = new System.Windows.Forms.TextBox();
            this.txtCounter0 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.txtReadCount = new System.Windows.Forms.TextBox();
            this.txtModule = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelLED = new System.Windows.Forms.Panel();
            this.btnApplyLED = new System.Windows.Forms.Button();
            this.cbxLedSource = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLED = new System.Windows.Forms.TextBox();
            this.panelLEDOutput = new System.Windows.Forms.Panel();
            this.btnLED = new System.Windows.Forms.Button();
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelLED.SuspendLayout();
            this.panelLEDOutput.SuspendLayout();
            this.panelCount.SuspendLayout();
            this.panelAlarm.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCounter1
            // 
            this.txtCounter1.Location = new System.Drawing.Point(90, 112);
            this.txtCounter1.Name = "txtCounter1";
            this.txtCounter1.Size = new System.Drawing.Size(150, 22);
            this.txtCounter1.TabIndex = 27;
            // 
            // txtCounter0
            // 
            this.txtCounter0.Location = new System.Drawing.Point(90, 77);
            this.txtCounter0.Name = "txtCounter0";
            this.txtCounter0.Size = new System.Drawing.Size(150, 22);
            this.txtCounter0.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 12);
            this.label4.TabIndex = 25;
            this.label4.Text = "Ch-1 value:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 12);
            this.label3.TabIndex = 24;
            this.label3.Text = "Ch-0 value:";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(257, 4);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 23;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // txtReadCount
            // 
            this.txtReadCount.Location = new System.Drawing.Point(90, 40);
            this.txtReadCount.Name = "txtReadCount";
            this.txtReadCount.ReadOnly = true;
            this.txtReadCount.Size = new System.Drawing.Size(150, 22);
            this.txtReadCount.TabIndex = 22;
            this.txtReadCount.Text = "0";
            // 
            // txtModule
            // 
            this.txtModule.Location = new System.Drawing.Point(90, 6);
            this.txtModule.Name = "txtModule";
            this.txtModule.Size = new System.Drawing.Size(150, 22);
            this.txtModule.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 12);
            this.label2.TabIndex = 20;
            this.label2.Text = "Read count:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 12);
            this.label1.TabIndex = 19;
            this.label1.Text = "Module name:";
            // 
            // panelLED
            // 
            this.panelLED.Controls.Add(this.btnApplyLED);
            this.panelLED.Controls.Add(this.cbxLedSource);
            this.panelLED.Controls.Add(this.label5);
            this.panelLED.Location = new System.Drawing.Point(5, 140);
            this.panelLED.Name = "panelLED";
            this.panelLED.Size = new System.Drawing.Size(336, 74);
            this.panelLED.TabIndex = 28;
            // 
            // btnApplyLED
            // 
            this.btnApplyLED.Location = new System.Drawing.Point(252, 10);
            this.btnApplyLED.Name = "btnApplyLED";
            this.btnApplyLED.Size = new System.Drawing.Size(75, 23);
            this.btnApplyLED.TabIndex = 3;
            this.btnApplyLED.Text = "Apply";
            this.btnApplyLED.UseVisualStyleBackColor = true;
            this.btnApplyLED.Click += new System.EventHandler(this.btnApplyLED_Click);
            // 
            // cbxLedSource
            // 
            this.cbxLedSource.FormattingEnabled = true;
            this.cbxLedSource.Location = new System.Drawing.Point(72, 12);
            this.cbxLedSource.Name = "cbxLedSource";
            this.cbxLedSource.Size = new System.Drawing.Size(121, 20);
            this.cbxLedSource.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "LED source:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "LED output:";
            // 
            // txtLED
            // 
            this.txtLED.Location = new System.Drawing.Point(75, 7);
            this.txtLED.Name = "txtLED";
            this.txtLED.Size = new System.Drawing.Size(100, 22);
            this.txtLED.TabIndex = 3;
            // 
            // panelLEDOutput
            // 
            this.panelLEDOutput.Controls.Add(this.btnLED);
            this.panelLEDOutput.Controls.Add(this.txtLED);
            this.panelLEDOutput.Controls.Add(this.label6);
            this.panelLEDOutput.Location = new System.Drawing.Point(5, 178);
            this.panelLEDOutput.Name = "panelLEDOutput";
            this.panelLEDOutput.Size = new System.Drawing.Size(336, 36);
            this.panelLEDOutput.TabIndex = 4;
            // 
            // btnLED
            // 
            this.btnLED.Location = new System.Drawing.Point(252, 6);
            this.btnLED.Name = "btnLED";
            this.btnLED.Size = new System.Drawing.Size(75, 23);
            this.btnLED.TabIndex = 4;
            this.btnLED.Text = "Set LED";
            this.btnLED.UseVisualStyleBackColor = true;
            this.btnLED.Click += new System.EventHandler(this.btnLED_Click);
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
            this.panelCount.Location = new System.Drawing.Point(5, 214);
            this.panelCount.Name = "panelCount";
            this.panelCount.Size = new System.Drawing.Size(336, 194);
            this.panelCount.TabIndex = 29;
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
            this.panelAlarm.TabIndex = 19;
            // 
            // btnClearLatch
            // 
            this.btnClearLatch.Location = new System.Drawing.Point(225, 10);
            this.btnClearLatch.Name = "btnClearLatch";
            this.btnClearLatch.Size = new System.Drawing.Size(93, 25);
            this.btnClearLatch.TabIndex = 4;
            this.btnClearLatch.Text = "Clear latch alarm";
            this.btnClearLatch.UseVisualStyleBackColor = true;
            this.btnClearLatch.Click += new System.EventHandler(this.btnClearLatch_Click);
            // 
            // txtHighAlarm
            // 
            this.txtHighAlarm.Location = new System.Drawing.Point(86, 54);
            this.txtHighAlarm.Name = "txtHighAlarm";
            this.txtHighAlarm.ReadOnly = true;
            this.txtHighAlarm.Size = new System.Drawing.Size(100, 22);
            this.txtHighAlarm.TabIndex = 3;
            // 
            // txtLowAlarm
            // 
            this.txtLowAlarm.Location = new System.Drawing.Point(85, 12);
            this.txtLowAlarm.Name = "txtLowAlarm";
            this.txtLowAlarm.ReadOnly = true;
            this.txtLowAlarm.Size = new System.Drawing.Size(100, 22);
            this.txtLowAlarm.TabIndex = 2;
            // 
            // btnHighAlarm
            // 
            this.btnHighAlarm.Location = new System.Drawing.Point(5, 52);
            this.btnHighAlarm.Name = "btnHighAlarm";
            this.btnHighAlarm.Size = new System.Drawing.Size(75, 23);
            this.btnHighAlarm.TabIndex = 1;
            this.btnHighAlarm.Text = "High alarm";
            this.btnHighAlarm.UseVisualStyleBackColor = true;
            this.btnHighAlarm.Click += new System.EventHandler(this.btnHighAlarm_Click);
            // 
            // btnLowAlarm
            // 
            this.btnLowAlarm.Location = new System.Drawing.Point(5, 12);
            this.btnLowAlarm.Name = "btnLowAlarm";
            this.btnLowAlarm.Size = new System.Drawing.Size(75, 23);
            this.btnLowAlarm.TabIndex = 0;
            this.btnLowAlarm.Text = "Low alarm";
            this.btnLowAlarm.UseVisualStyleBackColor = true;
            this.btnLowAlarm.Click += new System.EventHandler(this.btnLowAlarm_Click);
            // 
            // btnClearCounter
            // 
            this.btnClearCounter.Location = new System.Drawing.Point(225, 73);
            this.btnClearCounter.Name = "btnClearCounter";
            this.btnClearCounter.Size = new System.Drawing.Size(93, 29);
            this.btnClearCounter.TabIndex = 18;
            this.btnClearCounter.Text = "Clear to startup";
            this.btnClearCounter.UseVisualStyleBackColor = true;
            this.btnClearCounter.Click += new System.EventHandler(this.btnClearCounter_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(225, 39);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(93, 28);
            this.btnStop.TabIndex = 17;
            this.btnStop.Text = "Stop counting";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(225, 6);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(93, 27);
            this.btnStart.TabIndex = 16;
            this.btnStart.Text = "Start counting";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtOverflow
            // 
            this.txtOverflow.Location = new System.Drawing.Point(85, 78);
            this.txtOverflow.Name = "txtOverflow";
            this.txtOverflow.ReadOnly = true;
            this.txtOverflow.Size = new System.Drawing.Size(100, 22);
            this.txtOverflow.TabIndex = 5;
            // 
            // txtCounting
            // 
            this.txtCounting.Location = new System.Drawing.Point(85, 44);
            this.txtCounting.Name = "txtCounting";
            this.txtCounting.ReadOnly = true;
            this.txtCounting.Size = new System.Drawing.Size(100, 22);
            this.txtCounting.TabIndex = 4;
            // 
            // cbxChannel
            // 
            this.cbxChannel.FormattingEnabled = true;
            this.cbxChannel.Location = new System.Drawing.Point(85, 9);
            this.cbxChannel.Name = "cbxChannel";
            this.cbxChannel.Size = new System.Drawing.Size(108, 20);
            this.cbxChannel.TabIndex = 3;
            this.cbxChannel.SelectedIndexChanged += new System.EventHandler(this.cbxChannel_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 81);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 12);
            this.label9.TabIndex = 2;
            this.label9.Text = "Overflow:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "Counting:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "Channel index:";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 415);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Adam4080D sample program (C#)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panelLED.ResumeLayout(false);
            this.panelLED.PerformLayout();
            this.panelLEDOutput.ResumeLayout(false);
            this.panelLEDOutput.PerformLayout();
            this.panelCount.ResumeLayout(false);
            this.panelCount.PerformLayout();
            this.panelAlarm.ResumeLayout(false);
            this.panelAlarm.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCounter1;
        private System.Windows.Forms.TextBox txtCounter0;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.TextBox txtReadCount;
        private System.Windows.Forms.TextBox txtModule;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelLED;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnApplyLED;
        private System.Windows.Forms.ComboBox cbxLedSource;
        private System.Windows.Forms.TextBox txtLED;
        private System.Windows.Forms.Panel panelLEDOutput;
        private System.Windows.Forms.Button btnLED;
        private System.Windows.Forms.Panel panelCount;
        private System.Windows.Forms.TextBox txtOverflow;
        private System.Windows.Forms.TextBox txtCounting;
        private System.Windows.Forms.ComboBox cbxChannel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panelAlarm;
        private System.Windows.Forms.Button btnClearLatch;
        private System.Windows.Forms.TextBox txtHighAlarm;
        private System.Windows.Forms.TextBox txtLowAlarm;
        private System.Windows.Forms.Button btnHighAlarm;
        private System.Windows.Forms.Button btnLowAlarm;
        private System.Windows.Forms.Button btnClearCounter;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Timer timer1;
    }
}

