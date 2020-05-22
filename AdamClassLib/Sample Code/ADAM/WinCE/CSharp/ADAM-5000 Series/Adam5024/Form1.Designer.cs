namespace Adam5024
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
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAO3 = new System.Windows.Forms.TextBox();
            this.panelAO = new System.Windows.Forms.Panel();
            this.cbxChannel = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnApplyOutput = new System.Windows.Forms.Button();
            this.txtOutputValue = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblHigh = new System.Windows.Forms.Label();
            this.lblLow = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.buttonStart = new System.Windows.Forms.Button();
            this.txtAO2 = new System.Windows.Forms.TextBox();
            this.txtAO1 = new System.Windows.Forms.TextBox();
            this.txtAO0 = new System.Windows.Forms.TextBox();
            this.txtReadCount = new System.Windows.Forms.TextBox();
            this.txtModule = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer();
            this.panelAO.SuspendLayout();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(3, 193);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 20);
            this.label9.Text = "AO-3 value:";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(3, 157);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 20);
            this.label8.Text = "AO-2 value:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 20);
            this.label4.Text = "AO-1 value:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 20);
            this.label3.Text = "AO-0 value:";
            // 
            // txtAO3
            // 
            this.txtAO3.Location = new System.Drawing.Point(91, 190);
            this.txtAO3.Name = "txtAO3";
            this.txtAO3.Size = new System.Drawing.Size(119, 23);
            this.txtAO3.TabIndex = 61;
            // 
            // panelAO
            // 
            this.panelAO.BackColor = System.Drawing.Color.SkyBlue;
            this.panelAO.Controls.Add(this.cbxChannel);
            this.panelAO.Controls.Add(this.label10);
            this.panelAO.Controls.Add(this.btnApplyOutput);
            this.panelAO.Controls.Add(this.txtOutputValue);
            this.panelAO.Controls.Add(this.label7);
            this.panelAO.Controls.Add(this.lblHigh);
            this.panelAO.Controls.Add(this.lblLow);
            this.panelAO.Controls.Add(this.trackBar1);
            this.panelAO.Location = new System.Drawing.Point(2, 230);
            this.panelAO.Name = "panelAO";
            this.panelAO.Size = new System.Drawing.Size(313, 137);
            // 
            // cbxChannel
            // 
            this.cbxChannel.Location = new System.Drawing.Point(106, 9);
            this.cbxChannel.Name = "cbxChannel";
            this.cbxChannel.Size = new System.Drawing.Size(97, 23);
            this.cbxChannel.TabIndex = 7;
            this.cbxChannel.SelectedIndexChanged += new System.EventHandler(this.cbxChannel_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(12, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 20);
            this.label10.Text = "Channel index:";
            // 
            // btnApplyOutput
            // 
            this.btnApplyOutput.Location = new System.Drawing.Point(213, 107);
            this.btnApplyOutput.Name = "btnApplyOutput";
            this.btnApplyOutput.Size = new System.Drawing.Size(93, 23);
            this.btnApplyOutput.TabIndex = 5;
            this.btnApplyOutput.Text = "Apply output";
            this.btnApplyOutput.Click += new System.EventHandler(this.btnApplyOutput_Click);
            // 
            // txtOutputValue
            // 
            this.txtOutputValue.Location = new System.Drawing.Point(108, 107);
            this.txtOutputValue.Name = "txtOutputValue";
            this.txtOutputValue.ReadOnly = true;
            this.txtOutputValue.Size = new System.Drawing.Size(99, 23);
            this.txtOutputValue.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(12, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 20);
            this.label7.Text = "Value to output:";
            // 
            // lblHigh
            // 
            this.lblHigh.Location = new System.Drawing.Point(169, 74);
            this.lblHigh.Name = "lblHigh";
            this.lblHigh.Size = new System.Drawing.Size(33, 22);
            this.lblHigh.Text = "10V";
            // 
            // lblLow
            // 
            this.lblLow.Location = new System.Drawing.Point(12, 74);
            this.lblLow.Name = "lblLow";
            this.lblLow.Size = new System.Drawing.Size(26, 22);
            this.lblLow.Text = "0V";
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 16;
            this.trackBar1.Location = new System.Drawing.Point(3, 41);
            this.trackBar1.Maximum = 4095;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(204, 45);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(235, 4);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 60;
            this.buttonStart.Text = "Start";
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // txtAO2
            // 
            this.txtAO2.Location = new System.Drawing.Point(91, 154);
            this.txtAO2.Name = "txtAO2";
            this.txtAO2.Size = new System.Drawing.Size(119, 23);
            this.txtAO2.TabIndex = 59;
            // 
            // txtAO1
            // 
            this.txtAO1.Location = new System.Drawing.Point(91, 118);
            this.txtAO1.Name = "txtAO1";
            this.txtAO1.Size = new System.Drawing.Size(119, 23);
            this.txtAO1.TabIndex = 58;
            // 
            // txtAO0
            // 
            this.txtAO0.Location = new System.Drawing.Point(91, 82);
            this.txtAO0.Name = "txtAO0";
            this.txtAO0.Size = new System.Drawing.Size(119, 23);
            this.txtAO0.TabIndex = 57;
            // 
            // txtReadCount
            // 
            this.txtReadCount.Location = new System.Drawing.Point(91, 39);
            this.txtReadCount.Name = "txtReadCount";
            this.txtReadCount.ReadOnly = true;
            this.txtReadCount.Size = new System.Drawing.Size(119, 23);
            this.txtReadCount.TabIndex = 56;
            this.txtReadCount.Text = "0";
            // 
            // txtModule
            // 
            this.txtModule.Location = new System.Drawing.Point(91, 6);
            this.txtModule.Name = "txtModule";
            this.txtModule.Size = new System.Drawing.Size(119, 23);
            this.txtModule.TabIndex = 55;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 20);
            this.label2.Text = "Read count:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 18);
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
            this.ClientSize = new System.Drawing.Size(317, 370);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAO3);
            this.Controls.Add(this.panelAO);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.txtAO2);
            this.Controls.Add(this.txtAO1);
            this.Controls.Add(this.txtAO0);
            this.Controls.Add(this.txtReadCount);
            this.Controls.Add(this.txtModule);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Adam5024 sample program ";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
            this.panelAO.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAO3;
        private System.Windows.Forms.Panel panelAO;
        private System.Windows.Forms.ComboBox cbxChannel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnApplyOutput;
        private System.Windows.Forms.TextBox txtOutputValue;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblHigh;
        private System.Windows.Forms.Label lblLow;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.TextBox txtAO2;
        private System.Windows.Forms.TextBox txtAO1;
        private System.Windows.Forms.TextBox txtAO0;
        private System.Windows.Forms.TextBox txtReadCount;
        private System.Windows.Forms.TextBox txtModule;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
    }
}

