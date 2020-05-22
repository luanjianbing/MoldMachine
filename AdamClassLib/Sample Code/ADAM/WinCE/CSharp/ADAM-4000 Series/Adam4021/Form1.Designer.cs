namespace Adam4021
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
            this.buttonStart = new System.Windows.Forms.Button();
            this.txtAOValue = new System.Windows.Forms.TextBox();
            this.txtReadCount = new System.Windows.Forms.TextBox();
            this.txtModule = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelAO = new System.Windows.Forms.Panel();
            this.btnApplyOutput = new System.Windows.Forms.Button();
            this.txtOutputValue = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblHigh = new System.Windows.Forms.Label();
            this.lblLow = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.timer1 = new System.Windows.Forms.Timer();
            this.panelAO.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(267, 9);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 25;
            this.buttonStart.Text = "Start";
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // txtAOValue
            // 
            this.txtAOValue.Location = new System.Drawing.Point(132, 75);
            this.txtAOValue.Name = "txtAOValue";
            this.txtAOValue.Size = new System.Drawing.Size(121, 23);
            this.txtAOValue.TabIndex = 24;
            // 
            // txtReadCount
            // 
            this.txtReadCount.Location = new System.Drawing.Point(132, 40);
            this.txtReadCount.Name = "txtReadCount";
            this.txtReadCount.ReadOnly = true;
            this.txtReadCount.Size = new System.Drawing.Size(121, 23);
            this.txtReadCount.TabIndex = 23;
            this.txtReadCount.Text = "0";
            // 
            // txtModule
            // 
            this.txtModule.Location = new System.Drawing.Point(132, 6);
            this.txtModule.Name = "txtModule";
            this.txtModule.Size = new System.Drawing.Size(121, 23);
            this.txtModule.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 20);
            this.label4.Text = "Analog output value:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.Text = "Read count:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 20);
            this.label1.Text = "Module name:";
            // 
            // panelAO
            // 
            this.panelAO.BackColor = System.Drawing.Color.SkyBlue;
            this.panelAO.Controls.Add(this.btnApplyOutput);
            this.panelAO.Controls.Add(this.txtOutputValue);
            this.panelAO.Controls.Add(this.label7);
            this.panelAO.Controls.Add(this.lblHigh);
            this.panelAO.Controls.Add(this.lblLow);
            this.panelAO.Controls.Add(this.trackBar1);
            this.panelAO.Location = new System.Drawing.Point(5, 116);
            this.panelAO.Name = "panelAO";
            this.panelAO.Size = new System.Drawing.Size(337, 103);
            // 
            // btnApplyOutput
            // 
            this.btnApplyOutput.Location = new System.Drawing.Point(233, 70);
            this.btnApplyOutput.Name = "btnApplyOutput";
            this.btnApplyOutput.Size = new System.Drawing.Size(93, 23);
            this.btnApplyOutput.TabIndex = 5;
            this.btnApplyOutput.Text = "Apply output";
            this.btnApplyOutput.Click += new System.EventHandler(this.btnApplyOutput_Click);
            // 
            // txtOutputValue
            // 
            this.txtOutputValue.Location = new System.Drawing.Point(110, 70);
            this.txtOutputValue.Name = "txtOutputValue";
            this.txtOutputValue.ReadOnly = true;
            this.txtOutputValue.Size = new System.Drawing.Size(100, 23);
            this.txtOutputValue.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(12, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 18);
            this.label7.Text = "Value to output:";
            // 
            // lblHigh
            // 
            this.lblHigh.Location = new System.Drawing.Point(174, 36);
            this.lblHigh.Name = "lblHigh";
            this.lblHigh.Size = new System.Drawing.Size(33, 22);
            this.lblHigh.Text = "10V";
            // 
            // lblLow
            // 
            this.lblLow.Location = new System.Drawing.Point(12, 36);
            this.lblLow.Name = "lblLow";
            this.lblLow.Size = new System.Drawing.Size(31, 22);
            this.lblLow.Text = "0V";
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 16;
            this.trackBar1.Location = new System.Drawing.Point(3, 3);
            this.trackBar1.Maximum = 4095;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(204, 45);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
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
            this.ClientSize = new System.Drawing.Size(346, 225);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.txtAOValue);
            this.Controls.Add(this.txtReadCount);
            this.Controls.Add(this.txtModule);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panelAO);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Adam4021 Sample Program (C#)";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
            this.panelAO.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.TextBox txtAOValue;
        private System.Windows.Forms.TextBox txtReadCount;
        private System.Windows.Forms.TextBox txtModule;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelAO;
        private System.Windows.Forms.Button btnApplyOutput;
        private System.Windows.Forms.TextBox txtOutputValue;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblHigh;
        private System.Windows.Forms.Label lblLow;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Timer timer1;
    }
}

