namespace Adam4011_12_13
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
            this.panelAlarm = new System.Windows.Forms.Panel();
            this.buttonDO1 = new System.Windows.Forms.Button();
            this.buttonDO0 = new System.Windows.Forms.Button();
            this.txtHighAlarm = new System.Windows.Forms.TextBox();
            this.txtLowAlarm = new System.Windows.Forms.TextBox();
            this.txtMode = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panelEvent = new System.Windows.Forms.Panel();
            this.txtEvent = new System.Windows.Forms.TextBox();
            this.txtCounter = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.txtAI = new System.Windows.Forms.TextBox();
            this.txtReadCount = new System.Windows.Forms.TextBox();
            this.txtModule = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer();
            this.panelAlarm.SuspendLayout();
            this.panelEvent.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelAlarm
            // 
            this.panelAlarm.BackColor = System.Drawing.Color.SkyBlue;
            this.panelAlarm.Controls.Add(this.buttonDO1);
            this.panelAlarm.Controls.Add(this.buttonDO0);
            this.panelAlarm.Controls.Add(this.txtHighAlarm);
            this.panelAlarm.Controls.Add(this.txtLowAlarm);
            this.panelAlarm.Controls.Add(this.txtMode);
            this.panelAlarm.Controls.Add(this.label8);
            this.panelAlarm.Controls.Add(this.label7);
            this.panelAlarm.Controls.Add(this.label6);
            this.panelAlarm.Location = new System.Drawing.Point(3, 200);
            this.panelAlarm.Name = "panelAlarm";
            this.panelAlarm.Size = new System.Drawing.Size(348, 107);
            // 
            // buttonDO1
            // 
            this.buttonDO1.Location = new System.Drawing.Point(248, 72);
            this.buttonDO1.Name = "buttonDO1";
            this.buttonDO1.Size = new System.Drawing.Size(89, 23);
            this.buttonDO1.TabIndex = 7;
            this.buttonDO1.Text = "Output DO-1";
            this.buttonDO1.Click += new System.EventHandler(this.buttonDO1_Click);
            // 
            // buttonDO0
            // 
            this.buttonDO0.Location = new System.Drawing.Point(248, 40);
            this.buttonDO0.Name = "buttonDO0";
            this.buttonDO0.Size = new System.Drawing.Size(89, 23);
            this.buttonDO0.TabIndex = 6;
            this.buttonDO0.Text = "Output DO-0";
            this.buttonDO0.Click += new System.EventHandler(this.buttonDO0_Click);
            // 
            // txtHighAlarm
            // 
            this.txtHighAlarm.Location = new System.Drawing.Point(102, 73);
            this.txtHighAlarm.Name = "txtHighAlarm";
            this.txtHighAlarm.Size = new System.Drawing.Size(128, 23);
            this.txtHighAlarm.TabIndex = 5;
            // 
            // txtLowAlarm
            // 
            this.txtLowAlarm.Location = new System.Drawing.Point(102, 41);
            this.txtLowAlarm.Name = "txtLowAlarm";
            this.txtLowAlarm.Size = new System.Drawing.Size(128, 23);
            this.txtLowAlarm.TabIndex = 4;
            // 
            // txtMode
            // 
            this.txtMode.Location = new System.Drawing.Point(102, 7);
            this.txtMode.Name = "txtMode";
            this.txtMode.Size = new System.Drawing.Size(128, 23);
            this.txtMode.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(3, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 19);
            this.label8.Text = "High alarm:";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(3, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 19);
            this.label7.Text = "Low alarm:";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(3, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 20);
            this.label6.Text = "Alarm mode:";
            // 
            // panelEvent
            // 
            this.panelEvent.BackColor = System.Drawing.Color.SkyBlue;
            this.panelEvent.Controls.Add(this.txtEvent);
            this.panelEvent.Controls.Add(this.txtCounter);
            this.panelEvent.Controls.Add(this.label5);
            this.panelEvent.Controls.Add(this.label4);
            this.panelEvent.Location = new System.Drawing.Point(3, 123);
            this.panelEvent.Name = "panelEvent";
            this.panelEvent.Size = new System.Drawing.Size(348, 71);
            // 
            // txtEvent
            // 
            this.txtEvent.Location = new System.Drawing.Point(102, 38);
            this.txtEvent.Name = "txtEvent";
            this.txtEvent.Size = new System.Drawing.Size(128, 23);
            this.txtEvent.TabIndex = 3;
            // 
            // txtCounter
            // 
            this.txtCounter.Location = new System.Drawing.Point(102, 8);
            this.txtCounter.Name = "txtCounter";
            this.txtCounter.Size = new System.Drawing.Size(128, 23);
            this.txtCounter.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 20);
            this.label5.Text = "Event status:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 20);
            this.label4.Text = "Event counter:";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(276, 12);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 15;
            this.buttonStart.Text = "Start";
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // txtAI
            // 
            this.txtAI.Location = new System.Drawing.Point(122, 84);
            this.txtAI.Name = "txtAI";
            this.txtAI.Size = new System.Drawing.Size(126, 23);
            this.txtAI.TabIndex = 14;
            // 
            // txtReadCount
            // 
            this.txtReadCount.Location = new System.Drawing.Point(122, 43);
            this.txtReadCount.Name = "txtReadCount";
            this.txtReadCount.ReadOnly = true;
            this.txtReadCount.Size = new System.Drawing.Size(126, 23);
            this.txtReadCount.TabIndex = 13;
            this.txtReadCount.Text = "0";
            // 
            // txtModule
            // 
            this.txtModule.Location = new System.Drawing.Point(122, 6);
            this.txtModule.Name = "txtModule";
            this.txtModule.Size = new System.Drawing.Size(126, 23);
            this.txtModule.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 20);
            this.label3.Text = "Analog input value:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.Text = "Read count:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
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
            this.ClientSize = new System.Drawing.Size(355, 311);
            this.Controls.Add(this.panelAlarm);
            this.Controls.Add(this.panelEvent);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.txtAI);
            this.Controls.Add(this.txtReadCount);
            this.Controls.Add(this.txtModule);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Adam4011_12_13 Sample Program (C#)";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
            this.panelAlarm.ResumeLayout(false);
            this.panelEvent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelAlarm;
        private System.Windows.Forms.Button buttonDO1;
        private System.Windows.Forms.Button buttonDO0;
        private System.Windows.Forms.TextBox txtHighAlarm;
        private System.Windows.Forms.TextBox txtLowAlarm;
        private System.Windows.Forms.TextBox txtMode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panelEvent;
        private System.Windows.Forms.TextBox txtEvent;
        private System.Windows.Forms.TextBox txtCounter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.TextBox txtAI;
        private System.Windows.Forms.TextBox txtReadCount;
        private System.Windows.Forms.TextBox txtModule;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
    }
}

