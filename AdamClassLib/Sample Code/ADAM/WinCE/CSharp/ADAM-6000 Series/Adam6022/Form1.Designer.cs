namespace Adam6022
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
            this.panelPID = new System.Windows.Forms.Panel();
            this.adamTrend1 = new Advantech.Graph.AdamTrend();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.txtGraphLow = new System.Windows.Forms.TextBox();
            this.txtGraphHigh = new System.Windows.Forms.TextBox();
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
            this.buttonStart = new System.Windows.Forms.Button();
            this.txtReadCount = new System.Windows.Forms.TextBox();
            this.txtModule = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer();
            this.panelPID.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelAO.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPID
            // 
            this.panelPID.Controls.Add(this.adamTrend1);
            this.panelPID.Controls.Add(this.label13);
            this.panelPID.Controls.Add(this.label11);
            this.panelPID.Controls.Add(this.panel4);
            this.panelPID.Controls.Add(this.panel3);
            this.panelPID.Controls.Add(this.panel2);
            this.panelPID.Controls.Add(this.label9);
            this.panelPID.Controls.Add(this.txtGraphLow);
            this.panelPID.Controls.Add(this.txtGraphHigh);
            this.panelPID.Controls.Add(this.panel1);
            this.panelPID.Controls.Add(this.panelAO);
            this.panelPID.Controls.Add(this.cbxControl);
            this.panelPID.Controls.Add(this.label4);
            this.panelPID.Controls.Add(this.cbxLoop);
            this.panelPID.Controls.Add(this.label3);
            this.panelPID.Location = new System.Drawing.Point(18, 68);
            this.panelPID.Name = "panelPID";
            this.panelPID.Size = new System.Drawing.Size(604, 380);
            // 
            // adamTrend1
            // 
            this.adamTrend1.DrawType = Advantech.Graph.DrawType.Analog;
            this.adamTrend1.GridBackColor = System.Drawing.Color.Black;
            this.adamTrend1.GridColor = System.Drawing.Color.DarkGreen;
            this.adamTrend1.GridLineSize = 10;
            this.adamTrend1.HorLabOrientation = Advantech.Graph.enumHorLabOrientation.Non;
            this.adamTrend1.HorLabType = Advantech.Graph.enumHorLabType.Step;
            this.adamTrend1.Location = new System.Drawing.Point(95, 162);
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
            this.adamTrend1.Size = new System.Drawing.Size(501, 190);
            this.adamTrend1.StepSize = 1;
            this.adamTrend1.TabIndex = 22;
            this.adamTrend1.Text = "adamTrend1";
            this.adamTrend1.VerLabOrientation = Advantech.Graph.enumVerLabOrientation.Non;
            this.adamTrend1.VerLabUnit = "";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(481, 357);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(30, 18);
            this.label13.Text = "MV";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(294, 357);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(25, 18);
            this.label11.Text = "PV";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Red;
            this.panel4.Location = new System.Drawing.Point(511, 358);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(56, 16);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Yellow;
            this.panel3.Location = new System.Drawing.Point(319, 358);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(56, 16);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Blue;
            this.panel2.Location = new System.Drawing.Point(124, 358);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(56, 16);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(99, 357);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(36, 18);
            this.label9.Text = "SV";
            // 
            // txtGraphLow
            // 
            this.txtGraphLow.Location = new System.Drawing.Point(5, 330);
            this.txtGraphLow.Name = "txtGraphLow";
            this.txtGraphLow.Size = new System.Drawing.Size(84, 23);
            this.txtGraphLow.TabIndex = 15;
            this.txtGraphLow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGraphLow_KeyPress);
            // 
            // txtGraphHigh
            // 
            this.txtGraphHigh.Location = new System.Drawing.Point(5, 163);
            this.txtGraphHigh.Name = "txtGraphHigh";
            this.txtGraphHigh.Size = new System.Drawing.Size(84, 23);
            this.txtGraphHigh.TabIndex = 14;
            this.txtGraphHigh.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGraphHigh_KeyPress);
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
            // 
            // adamLightMV
            // 
            this.adamLightMV.LightOffColor = System.Drawing.Color.LightGray;
            this.adamLightMV.LightOnColor = System.Drawing.Color.Lime;
            this.adamLightMV.Location = new System.Drawing.Point(13, 86);
            this.adamLightMV.Name = "adamLightMV";
            this.adamLightMV.Registration = "";
            this.adamLightMV.Size = new System.Drawing.Size(26, 26);
            this.adamLightMV.Style = Advantech.Graph.LightStyle.Round;
            this.adamLightMV.TabIndex = 12;
            this.adamLightMV.Value = false;
            // 
            // adamLightPV
            // 
            this.adamLightPV.LightOffColor = System.Drawing.Color.LightGray;
            this.adamLightPV.LightOnColor = System.Drawing.Color.Lime;
            this.adamLightPV.Location = new System.Drawing.Point(13, 29);
            this.adamLightPV.Name = "adamLightPV";
            this.adamLightPV.Registration = "";
            this.adamLightPV.Size = new System.Drawing.Size(26, 25);
            this.adamLightPV.Style = Advantech.Graph.LightStyle.Round;
            this.adamLightPV.TabIndex = 11;
            this.adamLightPV.Value = false;
            // 
            // txtMVAlarm
            // 
            this.txtMVAlarm.Location = new System.Drawing.Point(45, 89);
            this.txtMVAlarm.Name = "txtMVAlarm";
            this.txtMVAlarm.ReadOnly = true;
            this.txtMVAlarm.Size = new System.Drawing.Size(73, 23);
            this.txtMVAlarm.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(5, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 20);
            this.label10.Text = "MV alarm:";
            // 
            // txtPVAlarm
            // 
            this.txtPVAlarm.Location = new System.Drawing.Point(45, 31);
            this.txtPVAlarm.Name = "txtPVAlarm";
            this.txtPVAlarm.ReadOnly = true;
            this.txtPVAlarm.Size = new System.Drawing.Size(71, 23);
            this.txtPVAlarm.TabIndex = 4;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(9, 13);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 20);
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
            // 
            // progressBarMV
            // 
            this.progressBarMV.Location = new System.Drawing.Point(39, 111);
            this.progressBarMV.Name = "progressBarMV";
            this.progressBarMV.Size = new System.Drawing.Size(148, 22);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(287, 114);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 22);
            this.label8.Text = "%";
            // 
            // txtMV
            // 
            this.txtMV.Location = new System.Drawing.Point(208, 111);
            this.txtMV.Name = "txtMV";
            this.txtMV.Size = new System.Drawing.Size(73, 23);
            this.txtMV.TabIndex = 10;
            this.txtMV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMV_KeyPress);
            // 
            // txtPV
            // 
            this.txtPV.Location = new System.Drawing.Point(208, 64);
            this.txtPV.Name = "txtPV";
            this.txtPV.ReadOnly = true;
            this.txtPV.Size = new System.Drawing.Size(73, 23);
            this.txtPV.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(9, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 19);
            this.label6.Text = "MV";
            // 
            // progressBarPV
            // 
            this.progressBarPV.Location = new System.Drawing.Point(39, 64);
            this.progressBarPV.Name = "progressBarPV";
            this.progressBarPV.Size = new System.Drawing.Size(151, 22);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(9, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 19);
            this.label5.Text = "PV";
            // 
            // txtSV
            // 
            this.txtSV.Location = new System.Drawing.Point(210, 10);
            this.txtSV.Name = "txtSV";
            this.txtSV.Size = new System.Drawing.Size(71, 23);
            this.txtSV.TabIndex = 4;
            this.txtSV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSV_KeyPress);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(9, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 20);
            this.label7.Text = "SV";
            // 
            // lblSVHigh
            // 
            this.lblSVHigh.Location = new System.Drawing.Point(172, 36);
            this.lblSVHigh.Name = "lblSVHigh";
            this.lblSVHigh.Size = new System.Drawing.Size(32, 18);
            this.lblSVHigh.Text = "100";
            // 
            // lblSVLow
            // 
            this.lblSVLow.Location = new System.Drawing.Point(37, 36);
            this.lblSVLow.Name = "lblSVLow";
            this.lblSVLow.Size = new System.Drawing.Size(20, 18);
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
            this.cbxControl.Items.Add("Free");
            this.cbxControl.Items.Add("Auto");
            this.cbxControl.Items.Add("Manual");
            this.cbxControl.Location = new System.Drawing.Point(5, 78);
            this.cbxControl.Name = "cbxControl";
            this.cbxControl.Size = new System.Drawing.Size(121, 23);
            this.cbxControl.TabIndex = 3;
            this.cbxControl.SelectedIndexChanged += new System.EventHandler(this.cbxControl_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 27);
            this.label4.Text = "Control mode:";
            // 
            // cbxLoop
            // 
            this.cbxLoop.Items.Add("0");
            this.cbxLoop.Items.Add("1");
            this.cbxLoop.Location = new System.Drawing.Point(5, 26);
            this.cbxLoop.Name = "cbxLoop";
            this.cbxLoop.Size = new System.Drawing.Size(121, 23);
            this.cbxLoop.TabIndex = 1;
            this.cbxLoop.SelectedIndexChanged += new System.EventHandler(this.cbxLoop_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 25);
            this.label3.Text = "Loop:";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(547, 6);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 32;
            this.buttonStart.Text = "Start";
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // txtReadCount
            // 
            this.txtReadCount.Location = new System.Drawing.Point(119, 40);
            this.txtReadCount.Name = "txtReadCount";
            this.txtReadCount.ReadOnly = true;
            this.txtReadCount.Size = new System.Drawing.Size(150, 23);
            this.txtReadCount.TabIndex = 33;
            this.txtReadCount.Text = "0";
            // 
            // txtModule
            // 
            this.txtModule.Location = new System.Drawing.Point(119, 6);
            this.txtModule.Name = "txtModule";
            this.txtModule.Size = new System.Drawing.Size(150, 23);
            this.txtModule.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.Text = "Read count:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 20);
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
            this.ClientSize = new System.Drawing.Size(638, 455);
            this.Controls.Add(this.panelPID);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.txtReadCount);
            this.Controls.Add(this.txtModule);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Adam6022 Sample Program (C#)";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
            this.panelPID.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelAO.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPID;
        private Advantech.Graph.AdamTrend adamTrend1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtGraphLow;
        private System.Windows.Forms.TextBox txtGraphHigh;
        private System.Windows.Forms.Panel panel1;
        private Advantech.Graph.AdamLight adamLightMV;
        private Advantech.Graph.AdamLight adamLightPV;
        private System.Windows.Forms.TextBox txtMVAlarm;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPVAlarm;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panelAO;
        private System.Windows.Forms.ProgressBar progressBarMV;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtMV;
        private System.Windows.Forms.TextBox txtPV;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ProgressBar progressBarPV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSV;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblSVHigh;
        private System.Windows.Forms.Label lblSVLow;
        private System.Windows.Forms.TrackBar trackBarSV;
        private System.Windows.Forms.ComboBox cbxControl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxLoop;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.TextBox txtReadCount;
        private System.Windows.Forms.TextBox txtModule;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
    }
}

