namespace Adam4022T
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
            this.panelPID = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.txtGraphLow = new System.Windows.Forms.TextBox();
            this.txtGraphHigh = new System.Windows.Forms.TextBox();
            this.adamTrend1 = new Advantech.Graph.AdamTrend();
            this.panel1 = new System.Windows.Forms.Panel();
            this.adamLightMV = new Advantech.Graph.AdamLight();
            this.adamLightPV = new Advantech.Graph.AdamLight();
            this.txtMVAlarm = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPVAlarm = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.panelAO = new System.Windows.Forms.Panel();
            this.progressBarMV = new System.Windows.Forms.ProgressBar();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMV = new System.Windows.Forms.TextBox();
            this.txtPV = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.progressBarPV = new System.Windows.Forms.ProgressBar();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSV = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lblSVHigh = new System.Windows.Forms.Label();
            this.lblSVLow = new System.Windows.Forms.Label();
            this.trackBarSV = new System.Windows.Forms.TrackBar();
            this.cbxControl = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxLoop = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panelPID.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelAO.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSV)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(543, 6);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 0;
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
            this.txtReadCount.TabIndex = 0;
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
            // panelPID
            // 
            this.panelPID.Controls.Add(this.label13);
            this.panelPID.Controls.Add(this.label11);
            this.panelPID.Controls.Add(this.panel4);
            this.panelPID.Controls.Add(this.panel3);
            this.panelPID.Controls.Add(this.panel2);
            this.panelPID.Controls.Add(this.label9);
            this.panelPID.Controls.Add(this.txtGraphLow);
            this.panelPID.Controls.Add(this.txtGraphHigh);
            this.panelPID.Controls.Add(this.adamTrend1);
            this.panelPID.Controls.Add(this.panel1);
            this.panelPID.Controls.Add(this.panelAO);
            this.panelPID.Controls.Add(this.cbxControl);
            this.panelPID.Controls.Add(this.label4);
            this.panelPID.Controls.Add(this.cbxLoop);
            this.panelPID.Controls.Add(this.label3);
            this.panelPID.Location = new System.Drawing.Point(14, 68);
            this.panelPID.Name = "panelPID";
            this.panelPID.Size = new System.Drawing.Size(604, 380);
            this.panelPID.TabIndex = 23;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(482, 362);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(23, 12);
            this.label13.TabIndex = 21;
            this.label13.Text = "MV";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(294, 362);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(19, 12);
            this.label11.TabIndex = 20;
            this.label11.Text = "PV";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Red;
            this.panel4.Location = new System.Drawing.Point(511, 358);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(56, 16);
            this.panel4.TabIndex = 19;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Yellow;
            this.panel3.Location = new System.Drawing.Point(319, 358);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(56, 16);
            this.panel3.TabIndex = 18;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Blue;
            this.panel2.Location = new System.Drawing.Point(124, 358);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(56, 16);
            this.panel2.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(99, 362);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(19, 12);
            this.label9.TabIndex = 16;
            this.label9.Text = "SV";
            // 
            // txtGraphLow
            // 
            this.txtGraphLow.Location = new System.Drawing.Point(5, 330);
            this.txtGraphLow.Name = "txtGraphLow";
            this.txtGraphLow.Size = new System.Drawing.Size(84, 22);
            this.txtGraphLow.TabIndex = 15;
            this.txtGraphLow.Leave += new System.EventHandler(this.txtGraphLow_Leave);
            this.txtGraphLow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGraphLow_KeyPress);
            // 
            // txtGraphHigh
            // 
            this.txtGraphHigh.Location = new System.Drawing.Point(5, 163);
            this.txtGraphHigh.Name = "txtGraphHigh";
            this.txtGraphHigh.Size = new System.Drawing.Size(84, 22);
            this.txtGraphHigh.TabIndex = 14;
            this.txtGraphHigh.Leave += new System.EventHandler(this.txtGraphHigh_Leave);
            this.txtGraphHigh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGraphHigh_KeyPress);
            // 
            // adamTrend1
            // 
            this.adamTrend1.DrawType = Advantech.Graph.DrawType.Analog;
            this.adamTrend1.GridBackColor = System.Drawing.Color.Black;
            this.adamTrend1.GridColor = System.Drawing.Color.DarkGreen;
            this.adamTrend1.HorLabOrientation = Advantech.Graph.enumHorLabOrientation.Non;
            this.adamTrend1.HorLabType = Advantech.Graph.enumHorLabType.Step;
            this.adamTrend1.Location = new System.Drawing.Point(95, 163);
            this.adamTrend1.MaximumY = 100F;
            this.adamTrend1.MinimumY = 0F;
            this.adamTrend1.Name = "adamTrend1";
            this.adamTrend1.Pen0Color = System.Drawing.Color.Red;
            this.adamTrend1.Pen1Color = System.Drawing.Color.Orange;
            this.adamTrend1.Pen2Color = System.Drawing.Color.Yellow;
            this.adamTrend1.Pen3Color = System.Drawing.Color.Green;
            this.adamTrend1.Pen4Color = System.Drawing.Color.Blue;
            this.adamTrend1.Pen5Color = System.Drawing.Color.Plum;
            this.adamTrend1.Pen6Color = System.Drawing.Color.Gray;
            this.adamTrend1.Pen7Color = System.Drawing.Color.White;
            this.adamTrend1.Registration = "";
            this.adamTrend1.Size = new System.Drawing.Size(501, 189);
            this.adamTrend1.TabIndex = 13;
            this.adamTrend1.Text = "adamTrend1";
            this.adamTrend1.VerLabOrientation = Advantech.Graph.enumVerLabOrientation.Non;
            this.adamTrend1.VerLabUnit = "";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SkyBlue;
            this.panel1.Controls.Add(this.adamLightMV);
            this.panel1.Controls.Add(this.adamLightPV);
            this.panel1.Controls.Add(this.txtMVAlarm);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtPVAlarm);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Location = new System.Drawing.Point(466, 11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(130, 146);
            this.panel1.TabIndex = 12;
            // 
            // adamLightMV
            // 
            this.adamLightMV.LightOffColor = System.Drawing.Color.LightGray;
            this.adamLightMV.LightOnColor = System.Drawing.Color.Lime;
            this.adamLightMV.Location = new System.Drawing.Point(11, 85);
            this.adamLightMV.Name = "adamLightMV";
            this.adamLightMV.Registration = "";
            this.adamLightMV.Size = new System.Drawing.Size(26, 26);
            this.adamLightMV.Style = Advantech.Graph.LightStyle.Round;
            this.adamLightMV.TabIndex = 10;
            this.adamLightMV.Value = false;
            // 
            // adamLightPV
            // 
            this.adamLightPV.LightOffColor = System.Drawing.Color.LightGray;
            this.adamLightPV.LightOnColor = System.Drawing.Color.Lime;
            this.adamLightPV.Location = new System.Drawing.Point(11, 28);
            this.adamLightPV.Name = "adamLightPV";
            this.adamLightPV.Registration = "";
            this.adamLightPV.Size = new System.Drawing.Size(26, 25);
            this.adamLightPV.Style = Advantech.Graph.LightStyle.Round;
            this.adamLightPV.TabIndex = 9;
            this.adamLightPV.Value = false;
            // 
            // txtMVAlarm
            // 
            this.txtMVAlarm.Location = new System.Drawing.Point(45, 89);
            this.txtMVAlarm.Name = "txtMVAlarm";
            this.txtMVAlarm.ReadOnly = true;
            this.txtMVAlarm.Size = new System.Drawing.Size(73, 22);
            this.txtMVAlarm.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 12);
            this.label10.TabIndex = 7;
            this.label10.Text = "MV alarm:";
            // 
            // txtPVAlarm
            // 
            this.txtPVAlarm.Location = new System.Drawing.Point(45, 31);
            this.txtPVAlarm.Name = "txtPVAlarm";
            this.txtPVAlarm.ReadOnly = true;
            this.txtPVAlarm.Size = new System.Drawing.Size(71, 22);
            this.txtPVAlarm.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(51, 12);
            this.label12.TabIndex = 3;
            this.label12.Text = "PV alarm:";
            // 
            // panelAO
            // 
            this.panelAO.BackColor = System.Drawing.Color.SkyBlue;
            this.panelAO.Controls.Add(this.progressBarMV);
            this.panelAO.Controls.Add(this.label8);
            this.panelAO.Controls.Add(this.txtMV);
            this.panelAO.Controls.Add(this.txtPV);
            this.panelAO.Controls.Add(this.label6);
            this.panelAO.Controls.Add(this.progressBarPV);
            this.panelAO.Controls.Add(this.label5);
            this.panelAO.Controls.Add(this.txtSV);
            this.panelAO.Controls.Add(this.label7);
            this.panelAO.Controls.Add(this.lblSVHigh);
            this.panelAO.Controls.Add(this.lblSVLow);
            this.panelAO.Controls.Add(this.trackBarSV);
            this.panelAO.Location = new System.Drawing.Point(132, 11);
            this.panelAO.Name = "panelAO";
            this.panelAO.Size = new System.Drawing.Size(328, 146);
            this.panelAO.TabIndex = 11;
            // 
            // progressBarMV
            // 
            this.progressBarMV.Location = new System.Drawing.Point(39, 111);
            this.progressBarMV.Name = "progressBarMV";
            this.progressBarMV.Size = new System.Drawing.Size(148, 22);
            this.progressBarMV.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(287, 114);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 12);
            this.label8.TabIndex = 11;
            this.label8.Text = "%";
            // 
            // txtMV
            // 
            this.txtMV.Location = new System.Drawing.Point(208, 111);
            this.txtMV.Name = "txtMV";
            this.txtMV.Size = new System.Drawing.Size(73, 22);
            this.txtMV.TabIndex = 10;
            this.txtMV.Leave += new System.EventHandler(this.txtMV_Leave);
            this.txtMV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMV_KeyPress);
            // 
            // txtPV
            // 
            this.txtPV.Location = new System.Drawing.Point(208, 64);
            this.txtPV.Name = "txtPV";
            this.txtPV.ReadOnly = true;
            this.txtPV.Size = new System.Drawing.Size(73, 22);
            this.txtPV.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "MV";
            // 
            // progressBarPV
            // 
            this.progressBarPV.Location = new System.Drawing.Point(39, 64);
            this.progressBarPV.Name = "progressBarPV";
            this.progressBarPV.Size = new System.Drawing.Size(151, 22);
            this.progressBarPV.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "PV";
            // 
            // txtSV
            // 
            this.txtSV.Location = new System.Drawing.Point(210, 10);
            this.txtSV.Name = "txtSV";
            this.txtSV.Size = new System.Drawing.Size(71, 22);
            this.txtSV.TabIndex = 4;
            this.txtSV.Leave += new System.EventHandler(this.txtSV_Leave);
            this.txtSV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSV_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "SV";
            // 
            // lblSVHigh
            // 
            this.lblSVHigh.AutoSize = true;
            this.lblSVHigh.Location = new System.Drawing.Point(172, 36);
            this.lblSVHigh.Name = "lblSVHigh";
            this.lblSVHigh.Size = new System.Drawing.Size(23, 12);
            this.lblSVHigh.TabIndex = 2;
            this.lblSVHigh.Text = "100";
            // 
            // lblSVLow
            // 
            this.lblSVLow.AutoSize = true;
            this.lblSVLow.Location = new System.Drawing.Point(37, 36);
            this.lblSVLow.Name = "lblSVLow";
            this.lblSVLow.Size = new System.Drawing.Size(11, 12);
            this.lblSVLow.TabIndex = 1;
            this.lblSVLow.Text = "0";
            // 
            // trackBarSV
            // 
            this.trackBarSV.LargeChange = 2;
            this.trackBarSV.Location = new System.Drawing.Point(28, 3);
            this.trackBarSV.Maximum = 20;
            this.trackBarSV.Name = "trackBarSV";
            this.trackBarSV.Size = new System.Drawing.Size(176, 45);
            this.trackBarSV.TabIndex = 7;
            this.trackBarSV.ValueChanged += new System.EventHandler(this.trackBarSV_ValueChanged);
            // 
            // cbxControl
            // 
            this.cbxControl.FormattingEnabled = true;
            this.cbxControl.Items.AddRange(new object[] {
            "Free",
            "Auto",
            "Manual"});
            this.cbxControl.Location = new System.Drawing.Point(5, 78);
            this.cbxControl.Name = "cbxControl";
            this.cbxControl.Size = new System.Drawing.Size(121, 20);
            this.cbxControl.TabIndex = 3;
            this.cbxControl.SelectedIndexChanged += new System.EventHandler(this.cbxControl_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "Control mode:";
            // 
            // cbxLoop
            // 
            this.cbxLoop.FormattingEnabled = true;
            this.cbxLoop.Items.AddRange(new object[] {
            "0",
            "1"});
            this.cbxLoop.Location = new System.Drawing.Point(5, 26);
            this.cbxLoop.Name = "cbxLoop";
            this.cbxLoop.Size = new System.Drawing.Size(121, 20);
            this.cbxLoop.TabIndex = 1;
            this.cbxLoop.SelectedIndexChanged += new System.EventHandler(this.cbxLoop_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "Loop:";
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
            this.ClientSize = new System.Drawing.Size(631, 460);
            this.Controls.Add(this.panelPID);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.txtReadCount);
            this.Controls.Add(this.txtModule);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Adam4022T sample program (C#)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panelPID.ResumeLayout(false);
            this.panelPID.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelAO.ResumeLayout(false);
            this.panelAO.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.TextBox txtReadCount;
        private System.Windows.Forms.TextBox txtModule;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelPID;
        private System.Windows.Forms.ComboBox cbxLoop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelAO;
        private System.Windows.Forms.TextBox txtSV;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblSVHigh;
        private System.Windows.Forms.Label lblSVLow;
        private System.Windows.Forms.TrackBar trackBarSV;
        private System.Windows.Forms.ComboBox cbxControl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ProgressBar progressBarPV;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ProgressBar progressBarMV;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMV;
        private System.Windows.Forms.TextBox txtPV;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtMVAlarm;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPVAlarm;
        private System.Windows.Forms.Label label12;
        private Advantech.Graph.AdamLight adamLightPV;
        private Advantech.Graph.AdamLight adamLightMV;
        private Advantech.Graph.AdamTrend adamTrend1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtGraphLow;
        private System.Windows.Forms.TextBox txtGraphHigh;
        private System.Windows.Forms.Timer timer1;
    }
}

