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
            this.components = new System.ComponentModel.Container();
            this.buttonStart = new System.Windows.Forms.Button();
            this.txtAO2 = new System.Windows.Forms.TextBox();
            this.txtAO1 = new System.Windows.Forms.TextBox();
            this.txtAO0 = new System.Windows.Forms.TextBox();
            this.txtReadCount = new System.Windows.Forms.TextBox();
            this.txtModule = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnApplyOutput = new System.Windows.Forms.Button();
            this.panelAO = new System.Windows.Forms.Panel();
            this.cbxChannel = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtOutputValue = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblHigh = new System.Windows.Forms.Label();
            this.lblLow = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.txtAO3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelAO.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(234, 4);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 44;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // txtAO2
            // 
            this.txtAO2.Location = new System.Drawing.Point(80, 154);
            this.txtAO2.Name = "txtAO2";
            this.txtAO2.Size = new System.Drawing.Size(119, 22);
            this.txtAO2.TabIndex = 43;
            // 
            // txtAO1
            // 
            this.txtAO1.Location = new System.Drawing.Point(80, 118);
            this.txtAO1.Name = "txtAO1";
            this.txtAO1.Size = new System.Drawing.Size(119, 22);
            this.txtAO1.TabIndex = 42;
            // 
            // txtAO0
            // 
            this.txtAO0.Location = new System.Drawing.Point(80, 82);
            this.txtAO0.Name = "txtAO0";
            this.txtAO0.Size = new System.Drawing.Size(119, 22);
            this.txtAO0.TabIndex = 41;
            // 
            // txtReadCount
            // 
            this.txtReadCount.Location = new System.Drawing.Point(80, 39);
            this.txtReadCount.Name = "txtReadCount";
            this.txtReadCount.ReadOnly = true;
            this.txtReadCount.Size = new System.Drawing.Size(119, 22);
            this.txtReadCount.TabIndex = 40;
            this.txtReadCount.Text = "0";
            // 
            // txtModule
            // 
            this.txtModule.Location = new System.Drawing.Point(80, 6);
            this.txtModule.Name = "txtModule";
            this.txtModule.Size = new System.Drawing.Size(119, 22);
            this.txtModule.TabIndex = 39;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 12);
            this.label2.TabIndex = 35;
            this.label2.Text = "Read count:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 12);
            this.label1.TabIndex = 34;
            this.label1.Text = "Module name:";
            // 
            // btnApplyOutput
            // 
            this.btnApplyOutput.Location = new System.Drawing.Point(213, 105);
            this.btnApplyOutput.Name = "btnApplyOutput";
            this.btnApplyOutput.Size = new System.Drawing.Size(93, 23);
            this.btnApplyOutput.TabIndex = 5;
            this.btnApplyOutput.Text = "Apply output";
            this.btnApplyOutput.UseVisualStyleBackColor = true;
            this.btnApplyOutput.Click += new System.EventHandler(this.btnApplyOutput_Click);
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
            this.panelAO.Location = new System.Drawing.Point(3, 230);
            this.panelAO.Name = "panelAO";
            this.panelAO.Size = new System.Drawing.Size(313, 137);
            this.panelAO.TabIndex = 45;
            // 
            // cbxChannel
            // 
            this.cbxChannel.FormattingEnabled = true;
            this.cbxChannel.Location = new System.Drawing.Point(94, 9);
            this.cbxChannel.Name = "cbxChannel";
            this.cbxChannel.Size = new System.Drawing.Size(97, 20);
            this.cbxChannel.TabIndex = 7;
            this.cbxChannel.SelectedIndexChanged += new System.EventHandler(this.cbxChannel_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 12);
            this.label10.TabIndex = 6;
            this.label10.Text = "Channel index:";
            // 
            // txtOutputValue
            // 
            this.txtOutputValue.Location = new System.Drawing.Point(98, 107);
            this.txtOutputValue.Name = "txtOutputValue";
            this.txtOutputValue.ReadOnly = true;
            this.txtOutputValue.Size = new System.Drawing.Size(100, 22);
            this.txtOutputValue.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "Value to output:";
            // 
            // lblHigh
            // 
            this.lblHigh.AutoSize = true;
            this.lblHigh.Location = new System.Drawing.Point(174, 74);
            this.lblHigh.Name = "lblHigh";
            this.lblHigh.Size = new System.Drawing.Size(25, 12);
            this.lblHigh.TabIndex = 2;
            this.lblHigh.Text = "10V";
            // 
            // lblLow
            // 
            this.lblLow.AutoSize = true;
            this.lblLow.Location = new System.Drawing.Point(12, 74);
            this.lblLow.Name = "lblLow";
            this.lblLow.Size = new System.Drawing.Size(19, 12);
            this.lblLow.TabIndex = 1;
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
            // txtAO3
            // 
            this.txtAO3.Location = new System.Drawing.Point(80, 190);
            this.txtAO3.Name = "txtAO3";
            this.txtAO3.Size = new System.Drawing.Size(119, 22);
            this.txtAO3.TabIndex = 47;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 12);
            this.label3.TabIndex = 48;
            this.label3.Text = "AO-0 value:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 12);
            this.label4.TabIndex = 49;
            this.label4.Text = "AO-1 value:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(2, 157);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 12);
            this.label8.TabIndex = 50;
            this.label8.Text = "AO-2 value:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(2, 193);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 12);
            this.label9.TabIndex = 51;
            this.label9.Text = "AO-3 value:";
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
            this.ClientSize = new System.Drawing.Size(318, 370);
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
            this.Text = "Adam5024 sample program (C#)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panelAO.ResumeLayout(false);
            this.panelAO.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.TextBox txtAO2;
        private System.Windows.Forms.TextBox txtAO1;
        private System.Windows.Forms.TextBox txtAO0;
        private System.Windows.Forms.TextBox txtReadCount;
        private System.Windows.Forms.TextBox txtModule;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnApplyOutput;
        private System.Windows.Forms.Panel panelAO;
        private System.Windows.Forms.TextBox txtOutputValue;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblHigh;
        private System.Windows.Forms.Label lblLow;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TextBox txtAO3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbxChannel;
        private System.Windows.Forms.Timer timer1;
    }
}

