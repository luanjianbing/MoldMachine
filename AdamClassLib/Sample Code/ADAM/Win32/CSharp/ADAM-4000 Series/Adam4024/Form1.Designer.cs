namespace Adam4024
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
            this.txtReadCount = new System.Windows.Forms.TextBox();
            this.txtModule = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelAO = new System.Windows.Forms.Panel();
            this.btnApplyOutput = new System.Windows.Forms.Button();
            this.txtOutputValue = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblHigh = new System.Windows.Forms.Label();
            this.lblLow = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.txtAO1 = new System.Windows.Forms.TextBox();
            this.txtAO0 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAO3 = new System.Windows.Forms.TextBox();
            this.txtAO2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDI1 = new System.Windows.Forms.TextBox();
            this.txtDI0 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDI3 = new System.Windows.Forms.TextBox();
            this.txtDI2 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cbxChannel = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelAO.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(285, 4);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 22;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // txtReadCount
            // 
            this.txtReadCount.Location = new System.Drawing.Point(115, 40);
            this.txtReadCount.Name = "txtReadCount";
            this.txtReadCount.ReadOnly = true;
            this.txtReadCount.Size = new System.Drawing.Size(150, 22);
            this.txtReadCount.TabIndex = 21;
            this.txtReadCount.Text = "0";
            // 
            // txtModule
            // 
            this.txtModule.Location = new System.Drawing.Point(115, 6);
            this.txtModule.Name = "txtModule";
            this.txtModule.Size = new System.Drawing.Size(150, 22);
            this.txtModule.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 12);
            this.label2.TabIndex = 19;
            this.label2.Text = "Read count:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "Module name:";
            // 
            // panelAO
            // 
            this.panelAO.BackColor = System.Drawing.Color.SkyBlue;
            this.panelAO.Controls.Add(this.label14);
            this.panelAO.Controls.Add(this.cbxChannel);
            this.panelAO.Controls.Add(this.btnApplyOutput);
            this.panelAO.Controls.Add(this.txtOutputValue);
            this.panelAO.Controls.Add(this.label7);
            this.panelAO.Controls.Add(this.lblHigh);
            this.panelAO.Controls.Add(this.lblLow);
            this.panelAO.Controls.Add(this.trackBar1);
            this.panelAO.Location = new System.Drawing.Point(15, 236);
            this.panelAO.Name = "panelAO";
            this.panelAO.Size = new System.Drawing.Size(345, 97);
            this.panelAO.TabIndex = 23;
            // 
            // btnApplyOutput
            // 
            this.btnApplyOutput.Location = new System.Drawing.Point(230, 10);
            this.btnApplyOutput.Name = "btnApplyOutput";
            this.btnApplyOutput.Size = new System.Drawing.Size(93, 23);
            this.btnApplyOutput.TabIndex = 5;
            this.btnApplyOutput.Text = "Apply output";
            this.btnApplyOutput.UseVisualStyleBackColor = true;
            this.btnApplyOutput.Click += new System.EventHandler(this.btnApplyOutput_Click);
            // 
            // txtOutputValue
            // 
            this.txtOutputValue.Location = new System.Drawing.Point(230, 67);
            this.txtOutputValue.Name = "txtOutputValue";
            this.txtOutputValue.ReadOnly = true;
            this.txtOutputValue.Size = new System.Drawing.Size(100, 22);
            this.txtOutputValue.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(228, 52);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "Value to output:";
            // 
            // lblHigh
            // 
            this.lblHigh.AutoSize = true;
            this.lblHigh.Location = new System.Drawing.Point(174, 77);
            this.lblHigh.Name = "lblHigh";
            this.lblHigh.Size = new System.Drawing.Size(25, 12);
            this.lblHigh.TabIndex = 2;
            this.lblHigh.Text = "10V";
            // 
            // lblLow
            // 
            this.lblLow.AutoSize = true;
            this.lblLow.Location = new System.Drawing.Point(12, 77);
            this.lblLow.Name = "lblLow";
            this.lblLow.Size = new System.Drawing.Size(19, 12);
            this.lblLow.TabIndex = 1;
            this.lblLow.Text = "0V";
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 16;
            this.trackBar1.Location = new System.Drawing.Point(3, 44);
            this.trackBar1.Maximum = 4095;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(204, 45);
            this.trackBar1.TabIndex = 0;
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // txtAO1
            // 
            this.txtAO1.Location = new System.Drawing.Point(80, 123);
            this.txtAO1.Name = "txtAO1";
            this.txtAO1.Size = new System.Drawing.Size(105, 22);
            this.txtAO1.TabIndex = 27;
            // 
            // txtAO0
            // 
            this.txtAO0.Location = new System.Drawing.Point(80, 86);
            this.txtAO0.Name = "txtAO0";
            this.txtAO0.Size = new System.Drawing.Size(105, 22);
            this.txtAO0.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 12);
            this.label4.TabIndex = 25;
            this.label4.Text = "AO-1 value:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 12);
            this.label3.TabIndex = 24;
            this.label3.Text = "AO-0 value:";
            // 
            // txtAO3
            // 
            this.txtAO3.Location = new System.Drawing.Point(81, 197);
            this.txtAO3.Name = "txtAO3";
            this.txtAO3.Size = new System.Drawing.Size(105, 22);
            this.txtAO3.TabIndex = 31;
            // 
            // txtAO2
            // 
            this.txtAO2.Location = new System.Drawing.Point(81, 160);
            this.txtAO2.Name = "txtAO2";
            this.txtAO2.Size = new System.Drawing.Size(105, 22);
            this.txtAO2.TabIndex = 30;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 204);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 12);
            this.label8.TabIndex = 29;
            this.label8.Text = "AO-3 value:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 166);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 12);
            this.label9.TabIndex = 28;
            this.label9.Text = "AO-2 value:";
            // 
            // txtDI1
            // 
            this.txtDI1.Location = new System.Drawing.Point(255, 123);
            this.txtDI1.Name = "txtDI1";
            this.txtDI1.Size = new System.Drawing.Size(105, 22);
            this.txtDI1.TabIndex = 35;
            // 
            // txtDI0
            // 
            this.txtDI0.Location = new System.Drawing.Point(255, 86);
            this.txtDI0.Name = "txtDI0";
            this.txtDI0.Size = new System.Drawing.Size(105, 22);
            this.txtDI0.TabIndex = 34;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(191, 127);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 12);
            this.label10.TabIndex = 33;
            this.label10.Text = "DI-1 value:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(191, 89);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 12);
            this.label11.TabIndex = 32;
            this.label11.Text = "DI-0 value:";
            // 
            // txtDI3
            // 
            this.txtDI3.Location = new System.Drawing.Point(255, 200);
            this.txtDI3.Name = "txtDI3";
            this.txtDI3.Size = new System.Drawing.Size(105, 22);
            this.txtDI3.TabIndex = 39;
            // 
            // txtDI2
            // 
            this.txtDI2.Location = new System.Drawing.Point(255, 163);
            this.txtDI2.Name = "txtDI2";
            this.txtDI2.Size = new System.Drawing.Size(105, 22);
            this.txtDI2.TabIndex = 38;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(191, 204);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 12);
            this.label12.TabIndex = 37;
            this.label12.Text = "DI-3 value:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(191, 166);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 12);
            this.label13.TabIndex = 36;
            this.label13.Text = "DI-2 value:";
            // 
            // cbxChannel
            // 
            this.cbxChannel.FormattingEnabled = true;
            this.cbxChannel.Location = new System.Drawing.Point(91, 7);
            this.cbxChannel.Name = "cbxChannel";
            this.cbxChannel.Size = new System.Drawing.Size(90, 20);
            this.cbxChannel.TabIndex = 6;
            this.cbxChannel.SelectedIndexChanged += new System.EventHandler(this.cbxChannel_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(9, 10);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(76, 12);
            this.label14.TabIndex = 7;
            this.label14.Text = "Channel index:";
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
            this.ClientSize = new System.Drawing.Size(375, 345);
            this.Controls.Add(this.txtDI3);
            this.Controls.Add(this.txtDI2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtDI1);
            this.Controls.Add(this.txtDI0);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtAO3);
            this.Controls.Add(this.txtAO2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtAO1);
            this.Controls.Add(this.txtAO0);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panelAO);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.txtReadCount);
            this.Controls.Add(this.txtModule);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Adam4024 sample program (C#)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panelAO.ResumeLayout(false);
            this.panelAO.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.TextBox txtReadCount;
        private System.Windows.Forms.TextBox txtModule;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelAO;
        private System.Windows.Forms.Button btnApplyOutput;
        private System.Windows.Forms.TextBox txtOutputValue;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblHigh;
        private System.Windows.Forms.Label lblLow;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TextBox txtAO1;
        private System.Windows.Forms.TextBox txtAO0;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAO3;
        private System.Windows.Forms.TextBox txtAO2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDI1;
        private System.Windows.Forms.TextBox txtDI0;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDI3;
        private System.Windows.Forms.TextBox txtDI2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbxChannel;
        private System.Windows.Forms.Timer timer1;
    }
}

