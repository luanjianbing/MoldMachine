namespace Adam4016
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtModule = new System.Windows.Forms.TextBox();
            this.txtReadCount = new System.Windows.Forms.TextBox();
            this.txtAIValue = new System.Windows.Forms.TextBox();
            this.txtAOValue = new System.Windows.Forms.TextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.panelAO = new System.Windows.Forms.Panel();
            this.btnApplyOutput = new System.Windows.Forms.Button();
            this.txtOutputValue = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.panelAlarm = new System.Windows.Forms.Panel();
            this.buttonDO3 = new System.Windows.Forms.Button();
            this.buttonDO2 = new System.Windows.Forms.Button();
            this.buttonDO1 = new System.Windows.Forms.Button();
            this.buttonDO0 = new System.Windows.Forms.Button();
            this.txtDO3 = new System.Windows.Forms.TextBox();
            this.txtDO2 = new System.Windows.Forms.TextBox();
            this.txtHighAlarm = new System.Windows.Forms.TextBox();
            this.txtLowAlarm = new System.Windows.Forms.TextBox();
            this.txtMode = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelAO.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.panelAlarm.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Module name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Read count:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "Analog input value:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "Analog output value:";
            // 
            // txtModule
            // 
            this.txtModule.Location = new System.Drawing.Point(106, 6);
            this.txtModule.Name = "txtModule";
            this.txtModule.Size = new System.Drawing.Size(150, 22);
            this.txtModule.TabIndex = 4;
            // 
            // txtReadCount
            // 
            this.txtReadCount.Location = new System.Drawing.Point(106, 40);
            this.txtReadCount.Name = "txtReadCount";
            this.txtReadCount.ReadOnly = true;
            this.txtReadCount.Size = new System.Drawing.Size(150, 22);
            this.txtReadCount.TabIndex = 5;
            this.txtReadCount.Text = "0";
            // 
            // txtAIValue
            // 
            this.txtAIValue.Location = new System.Drawing.Point(106, 77);
            this.txtAIValue.Name = "txtAIValue";
            this.txtAIValue.Size = new System.Drawing.Size(150, 22);
            this.txtAIValue.TabIndex = 6;
            // 
            // txtAOValue
            // 
            this.txtAOValue.Location = new System.Drawing.Point(106, 115);
            this.txtAOValue.Name = "txtAOValue";
            this.txtAOValue.Size = new System.Drawing.Size(150, 22);
            this.txtAOValue.TabIndex = 7;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(278, 4);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 8;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // panelAO
            // 
            this.panelAO.BackColor = System.Drawing.Color.SkyBlue;
            this.panelAO.Controls.Add(this.btnApplyOutput);
            this.panelAO.Controls.Add(this.txtOutputValue);
            this.panelAO.Controls.Add(this.label7);
            this.panelAO.Controls.Add(this.label6);
            this.panelAO.Controls.Add(this.label5);
            this.panelAO.Controls.Add(this.trackBar1);
            this.panelAO.Location = new System.Drawing.Point(5, 162);
            this.panelAO.Name = "panelAO";
            this.panelAO.Size = new System.Drawing.Size(348, 115);
            this.panelAO.TabIndex = 9;
            // 
            // btnApplyOutput
            // 
            this.btnApplyOutput.Location = new System.Drawing.Point(233, 82);
            this.btnApplyOutput.Name = "btnApplyOutput";
            this.btnApplyOutput.Size = new System.Drawing.Size(93, 23);
            this.btnApplyOutput.TabIndex = 5;
            this.btnApplyOutput.Text = "Apply output";
            this.btnApplyOutput.UseVisualStyleBackColor = true;
            this.btnApplyOutput.Click += new System.EventHandler(this.btnApplyOutput_Click);
            // 
            // txtOutputValue
            // 
            this.txtOutputValue.Location = new System.Drawing.Point(98, 84);
            this.txtOutputValue.Name = "txtOutputValue";
            this.txtOutputValue.ReadOnly = true;
            this.txtOutputValue.Size = new System.Drawing.Size(100, 22);
            this.txtOutputValue.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "Value to output:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(174, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "10V";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "0V";
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
            // panelAlarm
            // 
            this.panelAlarm.BackColor = System.Drawing.Color.SkyBlue;
            this.panelAlarm.Controls.Add(this.buttonDO3);
            this.panelAlarm.Controls.Add(this.buttonDO2);
            this.panelAlarm.Controls.Add(this.buttonDO1);
            this.panelAlarm.Controls.Add(this.buttonDO0);
            this.panelAlarm.Controls.Add(this.txtDO3);
            this.panelAlarm.Controls.Add(this.txtDO2);
            this.panelAlarm.Controls.Add(this.txtHighAlarm);
            this.panelAlarm.Controls.Add(this.txtLowAlarm);
            this.panelAlarm.Controls.Add(this.txtMode);
            this.panelAlarm.Controls.Add(this.label12);
            this.panelAlarm.Controls.Add(this.label11);
            this.panelAlarm.Controls.Add(this.label10);
            this.panelAlarm.Controls.Add(this.label9);
            this.panelAlarm.Controls.Add(this.label8);
            this.panelAlarm.Location = new System.Drawing.Point(5, 283);
            this.panelAlarm.Name = "panelAlarm";
            this.panelAlarm.Size = new System.Drawing.Size(348, 155);
            this.panelAlarm.TabIndex = 10;
            // 
            // buttonDO3
            // 
            this.buttonDO3.Location = new System.Drawing.Point(220, 120);
            this.buttonDO3.Name = "buttonDO3";
            this.buttonDO3.Size = new System.Drawing.Size(106, 23);
            this.buttonDO3.TabIndex = 13;
            this.buttonDO3.Text = "Output DO-3";
            this.buttonDO3.UseVisualStyleBackColor = true;
            this.buttonDO3.Click += new System.EventHandler(this.buttonDO3_Click);
            // 
            // buttonDO2
            // 
            this.buttonDO2.Location = new System.Drawing.Point(220, 92);
            this.buttonDO2.Name = "buttonDO2";
            this.buttonDO2.Size = new System.Drawing.Size(106, 23);
            this.buttonDO2.TabIndex = 12;
            this.buttonDO2.Text = "Output DO-2";
            this.buttonDO2.UseVisualStyleBackColor = true;
            this.buttonDO2.Click += new System.EventHandler(this.buttonDO2_Click);
            // 
            // buttonDO1
            // 
            this.buttonDO1.Location = new System.Drawing.Point(220, 64);
            this.buttonDO1.Name = "buttonDO1";
            this.buttonDO1.Size = new System.Drawing.Size(106, 23);
            this.buttonDO1.TabIndex = 11;
            this.buttonDO1.Text = "Output DO-1";
            this.buttonDO1.UseVisualStyleBackColor = true;
            this.buttonDO1.Click += new System.EventHandler(this.buttonDO1_Click);
            // 
            // buttonDO0
            // 
            this.buttonDO0.Location = new System.Drawing.Point(220, 36);
            this.buttonDO0.Name = "buttonDO0";
            this.buttonDO0.Size = new System.Drawing.Size(106, 23);
            this.buttonDO0.TabIndex = 10;
            this.buttonDO0.Text = "Output DO-0";
            this.buttonDO0.UseVisualStyleBackColor = true;
            this.buttonDO0.Click += new System.EventHandler(this.buttonDO0_Click);
            // 
            // txtDO3
            // 
            this.txtDO3.Location = new System.Drawing.Point(101, 122);
            this.txtDO3.Name = "txtDO3";
            this.txtDO3.Size = new System.Drawing.Size(100, 22);
            this.txtDO3.TabIndex = 9;
            // 
            // txtDO2
            // 
            this.txtDO2.Location = new System.Drawing.Point(101, 94);
            this.txtDO2.Name = "txtDO2";
            this.txtDO2.Size = new System.Drawing.Size(100, 22);
            this.txtDO2.TabIndex = 8;
            // 
            // txtHighAlarm
            // 
            this.txtHighAlarm.Location = new System.Drawing.Point(101, 66);
            this.txtHighAlarm.Name = "txtHighAlarm";
            this.txtHighAlarm.Size = new System.Drawing.Size(100, 22);
            this.txtHighAlarm.TabIndex = 7;
            // 
            // txtLowAlarm
            // 
            this.txtLowAlarm.Location = new System.Drawing.Point(101, 38);
            this.txtLowAlarm.Name = "txtLowAlarm";
            this.txtLowAlarm.Size = new System.Drawing.Size(100, 22);
            this.txtLowAlarm.TabIndex = 6;
            // 
            // txtMode
            // 
            this.txtMode.Location = new System.Drawing.Point(101, 10);
            this.txtMode.Name = "txtMode";
            this.txtMode.Size = new System.Drawing.Size(100, 22);
            this.txtMode.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 125);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(34, 12);
            this.label12.TabIndex = 4;
            this.label12.Text = "DO-3:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 97);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 12);
            this.label11.TabIndex = 3;
            this.label11.Text = "DO-2:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 69);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 12);
            this.label10.TabIndex = 2;
            this.label10.Text = "DO-1 high alarm:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 12);
            this.label9.TabIndex = 1;
            this.label9.Text = "DO-0 low alarm:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "Alarm mode:";
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
            this.ClientSize = new System.Drawing.Size(359, 444);
            this.Controls.Add(this.panelAlarm);
            this.Controls.Add(this.panelAO);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.txtAOValue);
            this.Controls.Add(this.txtAIValue);
            this.Controls.Add(this.txtReadCount);
            this.Controls.Add(this.txtModule);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Adam4016 sample program (C#)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panelAO.ResumeLayout(false);
            this.panelAO.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.panelAlarm.ResumeLayout(false);
            this.panelAlarm.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtModule;
        private System.Windows.Forms.TextBox txtReadCount;
        private System.Windows.Forms.TextBox txtAIValue;
        private System.Windows.Forms.TextBox txtAOValue;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Panel panelAO;
        private System.Windows.Forms.Panel panelAlarm;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button btnApplyOutput;
        private System.Windows.Forms.TextBox txtOutputValue;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonDO0;
        private System.Windows.Forms.TextBox txtDO3;
        private System.Windows.Forms.TextBox txtDO2;
        private System.Windows.Forms.TextBox txtHighAlarm;
        private System.Windows.Forms.TextBox txtLowAlarm;
        private System.Windows.Forms.TextBox txtMode;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonDO3;
        private System.Windows.Forms.Button buttonDO2;
        private System.Windows.Forms.Button buttonDO1;
        private System.Windows.Forms.Timer timer1;
    }
}

