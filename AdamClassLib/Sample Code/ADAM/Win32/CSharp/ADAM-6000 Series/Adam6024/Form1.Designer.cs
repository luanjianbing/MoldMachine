namespace Adam6024
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
            this.panelOutput = new System.Windows.Forms.Panel();
            this.cbxAOChannel = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnApplyOutput = new System.Windows.Forms.Button();
            this.txtOutputValue = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblHigh = new System.Windows.Forms.Label();
            this.lblLow = new System.Windows.Forms.Label();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.txtReadCount = new System.Windows.Forms.TextBox();
            this.txtModule = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.panelDO = new System.Windows.Forms.Panel();
            this.txtDOCh1 = new System.Windows.Forms.TextBox();
            this.txtDOCh0 = new System.Windows.Forms.TextBox();
            this.btnDOCh1 = new System.Windows.Forms.Button();
            this.btnDOCh0 = new System.Windows.Forms.Button();
            this.txtCh5 = new System.Windows.Forms.TextBox();
            this.txtCh4 = new System.Windows.Forms.TextBox();
            this.txtCh3 = new System.Windows.Forms.TextBox();
            this.txtCh2 = new System.Windows.Forms.TextBox();
            this.txtCh1 = new System.Windows.Forms.TextBox();
            this.txtCh0 = new System.Windows.Forms.TextBox();
            this.chkboxCh5 = new System.Windows.Forms.CheckBox();
            this.chkboxCh4 = new System.Windows.Forms.CheckBox();
            this.chkboxCh3 = new System.Windows.Forms.CheckBox();
            this.chkboxCh2 = new System.Windows.Forms.CheckBox();
            this.chkboxCh1 = new System.Windows.Forms.CheckBox();
            this.chkboxCh0 = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCurrentValue = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panelDI = new System.Windows.Forms.Panel();
            this.txtDICh1 = new System.Windows.Forms.TextBox();
            this.txtDICh0 = new System.Windows.Forms.TextBox();
            this.btnCh1 = new System.Windows.Forms.Button();
            this.btnCh0 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelOutput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.panelDO.SuspendLayout();
            this.panelDI.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelOutput
            // 
            this.panelOutput.BackColor = System.Drawing.Color.SkyBlue;
            this.panelOutput.Controls.Add(this.cbxAOChannel);
            this.panelOutput.Controls.Add(this.label10);
            this.panelOutput.Controls.Add(this.btnApplyOutput);
            this.panelOutput.Controls.Add(this.txtOutputValue);
            this.panelOutput.Controls.Add(this.label7);
            this.panelOutput.Controls.Add(this.lblHigh);
            this.panelOutput.Controls.Add(this.lblLow);
            this.panelOutput.Controls.Add(this.trackBar1);
            this.panelOutput.Location = new System.Drawing.Point(4, 137);
            this.panelOutput.Name = "panelOutput";
            this.panelOutput.Size = new System.Drawing.Size(326, 115);
            this.panelOutput.TabIndex = 15;
            // 
            // cbxAOChannel
            // 
            this.cbxAOChannel.FormattingEnabled = true;
            this.cbxAOChannel.Location = new System.Drawing.Point(94, 59);
            this.cbxAOChannel.Name = "cbxAOChannel";
            this.cbxAOChannel.Size = new System.Drawing.Size(97, 20);
            this.cbxAOChannel.TabIndex = 9;
            this.cbxAOChannel.SelectedIndexChanged += new System.EventHandler(this.cbxAOChannel_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 62);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 12);
            this.label10.TabIndex = 8;
            this.label10.Text = "Channel index:";
            // 
            // btnApplyOutput
            // 
            this.btnApplyOutput.Location = new System.Drawing.Point(215, 83);
            this.btnApplyOutput.Name = "btnApplyOutput";
            this.btnApplyOutput.Size = new System.Drawing.Size(93, 23);
            this.btnApplyOutput.TabIndex = 5;
            this.btnApplyOutput.Text = "Apply output";
            this.btnApplyOutput.UseVisualStyleBackColor = true;
            this.btnApplyOutput.Click += new System.EventHandler(this.btnApplyOutput_Click);
            // 
            // txtOutputValue
            // 
            this.txtOutputValue.Location = new System.Drawing.Point(94, 85);
            this.txtOutputValue.Name = "txtOutputValue";
            this.txtOutputValue.ReadOnly = true;
            this.txtOutputValue.Size = new System.Drawing.Size(97, 22);
            this.txtOutputValue.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "Value to output:";
            // 
            // lblHigh
            // 
            this.lblHigh.AutoSize = true;
            this.lblHigh.Location = new System.Drawing.Point(174, 36);
            this.lblHigh.Name = "lblHigh";
            this.lblHigh.Size = new System.Drawing.Size(28, 12);
            this.lblHigh.TabIndex = 2;
            this.lblHigh.Text = "High";
            // 
            // lblLow
            // 
            this.lblLow.AutoSize = true;
            this.lblLow.Location = new System.Drawing.Point(12, 36);
            this.lblLow.Name = "lblLow";
            this.lblLow.Size = new System.Drawing.Size(26, 12);
            this.lblLow.TabIndex = 1;
            this.lblLow.Text = "Low";
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
            // txtReadCount
            // 
            this.txtReadCount.Location = new System.Drawing.Point(80, 40);
            this.txtReadCount.Name = "txtReadCount";
            this.txtReadCount.ReadOnly = true;
            this.txtReadCount.Size = new System.Drawing.Size(150, 22);
            this.txtReadCount.TabIndex = 13;
            this.txtReadCount.Text = "0";
            // 
            // txtModule
            // 
            this.txtModule.Location = new System.Drawing.Point(80, 6);
            this.txtModule.Name = "txtModule";
            this.txtModule.Size = new System.Drawing.Size(150, 22);
            this.txtModule.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "Read count:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "Module name:";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(404, 12);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 14;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // panelDO
            // 
            this.panelDO.BackColor = System.Drawing.Color.SkyBlue;
            this.panelDO.Controls.Add(this.txtDOCh1);
            this.panelDO.Controls.Add(this.txtDOCh0);
            this.panelDO.Controls.Add(this.btnDOCh1);
            this.panelDO.Controls.Add(this.btnDOCh0);
            this.panelDO.Location = new System.Drawing.Point(336, 137);
            this.panelDO.Name = "panelDO";
            this.panelDO.Size = new System.Drawing.Size(143, 115);
            this.panelDO.TabIndex = 16;
            // 
            // txtDOCh1
            // 
            this.txtDOCh1.Location = new System.Drawing.Point(84, 63);
            this.txtDOCh1.Name = "txtDOCh1";
            this.txtDOCh1.Size = new System.Drawing.Size(56, 22);
            this.txtDOCh1.TabIndex = 3;
            // 
            // txtDOCh0
            // 
            this.txtDOCh0.Location = new System.Drawing.Point(84, 14);
            this.txtDOCh0.Name = "txtDOCh0";
            this.txtDOCh0.Size = new System.Drawing.Size(56, 22);
            this.txtDOCh0.TabIndex = 2;
            // 
            // btnDOCh1
            // 
            this.btnDOCh1.Location = new System.Drawing.Point(3, 62);
            this.btnDOCh1.Name = "btnDOCh1";
            this.btnDOCh1.Size = new System.Drawing.Size(75, 23);
            this.btnDOCh1.TabIndex = 1;
            this.btnDOCh1.Text = "DO 1";
            this.btnDOCh1.UseVisualStyleBackColor = true;
            this.btnDOCh1.Click += new System.EventHandler(this.btnDOCh1_Click);
            // 
            // btnDOCh0
            // 
            this.btnDOCh0.Location = new System.Drawing.Point(3, 14);
            this.btnDOCh0.Name = "btnDOCh0";
            this.btnDOCh0.Size = new System.Drawing.Size(75, 23);
            this.btnDOCh0.TabIndex = 0;
            this.btnDOCh0.Text = "DO 0";
            this.btnDOCh0.UseVisualStyleBackColor = true;
            this.btnDOCh0.Click += new System.EventHandler(this.btnDOCh0_Click);
            // 
            // txtCh5
            // 
            this.txtCh5.Location = new System.Drawing.Point(248, 357);
            this.txtCh5.Name = "txtCh5";
            this.txtCh5.ReadOnly = true;
            this.txtCh5.Size = new System.Drawing.Size(82, 22);
            this.txtCh5.TabIndex = 36;
            // 
            // txtCh4
            // 
            this.txtCh4.Location = new System.Drawing.Point(248, 321);
            this.txtCh4.Name = "txtCh4";
            this.txtCh4.ReadOnly = true;
            this.txtCh4.Size = new System.Drawing.Size(82, 22);
            this.txtCh4.TabIndex = 35;
            // 
            // txtCh3
            // 
            this.txtCh3.Location = new System.Drawing.Point(248, 286);
            this.txtCh3.Name = "txtCh3";
            this.txtCh3.ReadOnly = true;
            this.txtCh3.Size = new System.Drawing.Size(82, 22);
            this.txtCh3.TabIndex = 34;
            // 
            // txtCh2
            // 
            this.txtCh2.Location = new System.Drawing.Point(82, 355);
            this.txtCh2.Name = "txtCh2";
            this.txtCh2.ReadOnly = true;
            this.txtCh2.Size = new System.Drawing.Size(82, 22);
            this.txtCh2.TabIndex = 33;
            // 
            // txtCh1
            // 
            this.txtCh1.Location = new System.Drawing.Point(82, 322);
            this.txtCh1.Name = "txtCh1";
            this.txtCh1.ReadOnly = true;
            this.txtCh1.Size = new System.Drawing.Size(82, 22);
            this.txtCh1.TabIndex = 32;
            // 
            // txtCh0
            // 
            this.txtCh0.Location = new System.Drawing.Point(82, 286);
            this.txtCh0.Name = "txtCh0";
            this.txtCh0.ReadOnly = true;
            this.txtCh0.Size = new System.Drawing.Size(82, 22);
            this.txtCh0.TabIndex = 31;
            // 
            // chkboxCh5
            // 
            this.chkboxCh5.AutoSize = true;
            this.chkboxCh5.Enabled = false;
            this.chkboxCh5.Location = new System.Drawing.Point(170, 359);
            this.chkboxCh5.Name = "chkboxCh5";
            this.chkboxCh5.Size = new System.Drawing.Size(77, 16);
            this.chkboxCh5.TabIndex = 30;
            this.chkboxCh5.Text = "AI-5 value:";
            this.chkboxCh5.UseVisualStyleBackColor = true;
            // 
            // chkboxCh4
            // 
            this.chkboxCh4.AutoSize = true;
            this.chkboxCh4.Enabled = false;
            this.chkboxCh4.Location = new System.Drawing.Point(170, 323);
            this.chkboxCh4.Name = "chkboxCh4";
            this.chkboxCh4.Size = new System.Drawing.Size(77, 16);
            this.chkboxCh4.TabIndex = 29;
            this.chkboxCh4.Text = "AI-4 value:";
            this.chkboxCh4.UseVisualStyleBackColor = true;
            // 
            // chkboxCh3
            // 
            this.chkboxCh3.AutoSize = true;
            this.chkboxCh3.Enabled = false;
            this.chkboxCh3.Location = new System.Drawing.Point(170, 288);
            this.chkboxCh3.Name = "chkboxCh3";
            this.chkboxCh3.Size = new System.Drawing.Size(77, 16);
            this.chkboxCh3.TabIndex = 28;
            this.chkboxCh3.Text = "AI-3 value:";
            this.chkboxCh3.UseVisualStyleBackColor = true;
            // 
            // chkboxCh2
            // 
            this.chkboxCh2.AutoSize = true;
            this.chkboxCh2.Enabled = false;
            this.chkboxCh2.Location = new System.Drawing.Point(4, 357);
            this.chkboxCh2.Name = "chkboxCh2";
            this.chkboxCh2.Size = new System.Drawing.Size(77, 16);
            this.chkboxCh2.TabIndex = 27;
            this.chkboxCh2.Text = "AI-2 value:";
            this.chkboxCh2.UseVisualStyleBackColor = true;
            // 
            // chkboxCh1
            // 
            this.chkboxCh1.AutoSize = true;
            this.chkboxCh1.Enabled = false;
            this.chkboxCh1.Location = new System.Drawing.Point(4, 324);
            this.chkboxCh1.Name = "chkboxCh1";
            this.chkboxCh1.Size = new System.Drawing.Size(77, 16);
            this.chkboxCh1.TabIndex = 26;
            this.chkboxCh1.Text = "AI-1 value:";
            this.chkboxCh1.UseVisualStyleBackColor = true;
            // 
            // chkboxCh0
            // 
            this.chkboxCh0.AutoSize = true;
            this.chkboxCh0.Enabled = false;
            this.chkboxCh0.Location = new System.Drawing.Point(4, 288);
            this.chkboxCh0.Name = "chkboxCh0";
            this.chkboxCh0.Size = new System.Drawing.Size(77, 16);
            this.chkboxCh0.TabIndex = 25;
            this.chkboxCh0.Text = "AI-0 value:";
            this.chkboxCh0.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 12);
            this.label3.TabIndex = 37;
            this.label3.Text = "Analog Output";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 12);
            this.label4.TabIndex = 38;
            this.label4.Text = "Current value:";
            // 
            // txtCurrentValue
            // 
            this.txtCurrentValue.Location = new System.Drawing.Point(80, 108);
            this.txtCurrentValue.Name = "txtCurrentValue";
            this.txtCurrentValue.ReadOnly = true;
            this.txtCurrentValue.Size = new System.Drawing.Size(150, 22);
            this.txtCurrentValue.TabIndex = 39;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(2, 267);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 12);
            this.label8.TabIndex = 40;
            this.label8.Text = "Analog Iutput";
            // 
            // panelDI
            // 
            this.panelDI.BackColor = System.Drawing.Color.SkyBlue;
            this.panelDI.Controls.Add(this.txtDICh1);
            this.panelDI.Controls.Add(this.txtDICh0);
            this.panelDI.Controls.Add(this.btnCh1);
            this.panelDI.Controls.Add(this.btnCh0);
            this.panelDI.Location = new System.Drawing.Point(336, 267);
            this.panelDI.Name = "panelDI";
            this.panelDI.Size = new System.Drawing.Size(143, 115);
            this.panelDI.TabIndex = 41;
            // 
            // txtDICh1
            // 
            this.txtDICh1.Location = new System.Drawing.Point(84, 63);
            this.txtDICh1.Name = "txtDICh1";
            this.txtDICh1.Size = new System.Drawing.Size(56, 22);
            this.txtDICh1.TabIndex = 3;
            // 
            // txtDICh0
            // 
            this.txtDICh0.Location = new System.Drawing.Point(84, 14);
            this.txtDICh0.Name = "txtDICh0";
            this.txtDICh0.Size = new System.Drawing.Size(56, 22);
            this.txtDICh0.TabIndex = 2;
            // 
            // btnCh1
            // 
            this.btnCh1.Location = new System.Drawing.Point(3, 62);
            this.btnCh1.Name = "btnCh1";
            this.btnCh1.Size = new System.Drawing.Size(75, 23);
            this.btnCh1.TabIndex = 1;
            this.btnCh1.Text = "DI 1";
            this.btnCh1.UseVisualStyleBackColor = true;
            // 
            // btnCh0
            // 
            this.btnCh0.Location = new System.Drawing.Point(3, 14);
            this.btnCh0.Name = "btnCh0";
            this.btnCh0.Size = new System.Drawing.Size(75, 23);
            this.btnCh0.TabIndex = 0;
            this.btnCh0.Text = "DI 0";
            this.btnCh0.UseVisualStyleBackColor = true;
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
            this.ClientSize = new System.Drawing.Size(483, 387);
            this.Controls.Add(this.panelDI);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCurrentValue);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCh5);
            this.Controls.Add(this.txtCh4);
            this.Controls.Add(this.txtCh3);
            this.Controls.Add(this.txtCh2);
            this.Controls.Add(this.txtCh1);
            this.Controls.Add(this.txtCh0);
            this.Controls.Add(this.chkboxCh5);
            this.Controls.Add(this.chkboxCh4);
            this.Controls.Add(this.chkboxCh3);
            this.Controls.Add(this.chkboxCh2);
            this.Controls.Add(this.chkboxCh1);
            this.Controls.Add(this.chkboxCh0);
            this.Controls.Add(this.panelDO);
            this.Controls.Add(this.panelOutput);
            this.Controls.Add(this.txtReadCount);
            this.Controls.Add(this.txtModule);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Adam6024 sample program (C#)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panelOutput.ResumeLayout(false);
            this.panelOutput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.panelDO.ResumeLayout(false);
            this.panelDO.PerformLayout();
            this.panelDI.ResumeLayout(false);
            this.panelDI.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelOutput;
        private System.Windows.Forms.ComboBox cbxAOChannel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnApplyOutput;
        private System.Windows.Forms.TextBox txtOutputValue;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblHigh;
        private System.Windows.Forms.Label lblLow;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.TextBox txtReadCount;
        private System.Windows.Forms.TextBox txtModule;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Panel panelDO;
        private System.Windows.Forms.TextBox txtDOCh1;
        private System.Windows.Forms.TextBox txtDOCh0;
        private System.Windows.Forms.Button btnDOCh1;
        private System.Windows.Forms.Button btnDOCh0;
        private System.Windows.Forms.TextBox txtCh5;
        private System.Windows.Forms.TextBox txtCh4;
        private System.Windows.Forms.TextBox txtCh3;
        private System.Windows.Forms.TextBox txtCh2;
        private System.Windows.Forms.TextBox txtCh1;
        private System.Windows.Forms.TextBox txtCh0;
        private System.Windows.Forms.CheckBox chkboxCh5;
        private System.Windows.Forms.CheckBox chkboxCh4;
        private System.Windows.Forms.CheckBox chkboxCh3;
        private System.Windows.Forms.CheckBox chkboxCh2;
        private System.Windows.Forms.CheckBox chkboxCh1;
        private System.Windows.Forms.CheckBox chkboxCh0;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCurrentValue;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panelDI;
        private System.Windows.Forms.TextBox txtDICh1;
        private System.Windows.Forms.TextBox txtDICh0;
        private System.Windows.Forms.Button btnCh1;
        private System.Windows.Forms.Button btnCh0;
        private System.Windows.Forms.Timer timer1;
    }
}

