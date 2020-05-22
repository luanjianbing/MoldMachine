namespace Adam6224
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtModule = new System.Windows.Forms.TextBox();
            this.txtReadCount = new System.Windows.Forms.TextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPageDI = new System.Windows.Forms.TabPage();
            this.listViewDiChannelInfo = new System.Windows.Forms.ListView();
            this.ColumnDiInfoLocation = new System.Windows.Forms.ColumnHeader();
            this.ColumnDiInfoType = new System.Windows.Forms.ColumnHeader();
            this.ColumnDiInfoChNo = new System.Windows.Forms.ColumnHeader();
            this.ColumnDiInfoModeValue = new System.Windows.Forms.ColumnHeader();
            this.ColumnDiInfoChValue = new System.Windows.Forms.ColumnHeader();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPageAO = new System.Windows.Forms.TabPage();
            this.listViewAoChannelInfo = new System.Windows.Forms.ListView();
            this.ColumnAoInfoLocation = new System.Windows.Forms.ColumnHeader();
            this.ColumnAoInfoType = new System.Windows.Forms.ColumnHeader();
            this.ColumnAoInfoChNo = new System.Windows.Forms.ColumnHeader();
            this.ColumnAoInfoValueDec = new System.Windows.Forms.ColumnHeader();
            this.ColumnAoInfoValueHex = new System.Windows.Forms.ColumnHeader();
            this.ColumnAoInfoValueEng = new System.Windows.Forms.ColumnHeader();
            this.ColumnAoInfoRange = new System.Windows.Forms.ColumnHeader();
            this.label10 = new System.Windows.Forms.Label();
            this.panelAoValueSetting = new System.Windows.Forms.Panel();
            this.btnSetAoValue = new System.Windows.Forms.Button();
            this.labAoHigh = new System.Windows.Forms.Label();
            this.labAoLow = new System.Windows.Forms.Label();
            this.tBarAoOutputVal = new System.Windows.Forms.TrackBar();
            this.txtAoOutputVal = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSelAoChannel = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnApplyAoSelRange = new System.Windows.Forms.Button();
            this.cbxAoOutputRange = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxAoChannel = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControlMain.SuspendLayout();
            this.tabPageDI.SuspendLayout();
            this.tabPageAO.SuspendLayout();
            this.panelAoValueSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(17, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.Text = "Module name:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(17, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 20);
            this.label2.Text = "Read count:";
            // 
            // txtModule
            // 
            this.txtModule.Location = new System.Drawing.Point(157, 16);
            this.txtModule.Name = "txtModule";
            this.txtModule.Size = new System.Drawing.Size(176, 23);
            this.txtModule.TabIndex = 2;
            // 
            // txtReadCount
            // 
            this.txtReadCount.Location = new System.Drawing.Point(157, 48);
            this.txtReadCount.Name = "txtReadCount";
            this.txtReadCount.Size = new System.Drawing.Size(176, 23);
            this.txtReadCount.TabIndex = 3;
            this.txtReadCount.Text = "0";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(369, 16);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(95, 47);
            this.buttonStart.TabIndex = 4;
            this.buttonStart.Text = "Start";
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPageDI);
            this.tabControlMain.Controls.Add(this.tabPageAO);
            this.tabControlMain.Location = new System.Drawing.Point(5, 86);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(602, 326);
            this.tabControlMain.TabIndex = 5;
            this.tabControlMain.SelectedIndexChanged += new System.EventHandler(this.tabControlMain_SelectedIndexChanged);
            // 
            // tabPageDI
            // 
            this.tabPageDI.Controls.Add(this.listViewDiChannelInfo);
            this.tabPageDI.Controls.Add(this.label3);
            this.tabPageDI.Location = new System.Drawing.Point(4, 25);
            this.tabPageDI.Name = "tabPageDI";
            this.tabPageDI.Size = new System.Drawing.Size(594, 297);
            this.tabPageDI.Text = "DI";
            // 
            // listViewDiChannelInfo
            // 
            this.listViewDiChannelInfo.Columns.Add(this.ColumnDiInfoLocation);
            this.listViewDiChannelInfo.Columns.Add(this.ColumnDiInfoType);
            this.listViewDiChannelInfo.Columns.Add(this.ColumnDiInfoChNo);
            this.listViewDiChannelInfo.Columns.Add(this.ColumnDiInfoModeValue);
            this.listViewDiChannelInfo.Columns.Add(this.ColumnDiInfoChValue);
            this.listViewDiChannelInfo.Location = new System.Drawing.Point(13, 40);
            this.listViewDiChannelInfo.Name = "listViewDiChannelInfo";
            this.listViewDiChannelInfo.Size = new System.Drawing.Size(568, 155);
            this.listViewDiChannelInfo.TabIndex = 1;
            this.listViewDiChannelInfo.View = System.Windows.Forms.View.Details;
            // 
            // ColumnDiInfoLocation
            // 
            this.ColumnDiInfoLocation.Text = "Address";
            this.ColumnDiInfoLocation.Width = 110;
            // 
            // ColumnDiInfoType
            // 
            this.ColumnDiInfoType.Text = "Type";
            this.ColumnDiInfoType.Width = 110;
            // 
            // ColumnDiInfoChNo
            // 
            this.ColumnDiInfoChNo.Text = "Channel";
            this.ColumnDiInfoChNo.Width = 110;
            // 
            // ColumnDiInfoModeValue
            // 
            this.ColumnDiInfoModeValue.Text = "Mode";
            this.ColumnDiInfoModeValue.Width = 110;
            // 
            // ColumnDiInfoChValue
            // 
            this.ColumnDiInfoChValue.Text = "Value";
            this.ColumnDiInfoChValue.Width = 125;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 20);
            this.label3.Text = "Channel Information";
            // 
            // tabPageAO
            // 
            this.tabPageAO.Controls.Add(this.listViewAoChannelInfo);
            this.tabPageAO.Controls.Add(this.label10);
            this.tabPageAO.Controls.Add(this.panelAoValueSetting);
            this.tabPageAO.Controls.Add(this.btnApplyAoSelRange);
            this.tabPageAO.Controls.Add(this.cbxAoOutputRange);
            this.tabPageAO.Controls.Add(this.label6);
            this.tabPageAO.Controls.Add(this.cbxAoChannel);
            this.tabPageAO.Controls.Add(this.label5);
            this.tabPageAO.Controls.Add(this.label4);
            this.tabPageAO.Location = new System.Drawing.Point(4, 25);
            this.tabPageAO.Name = "tabPageAO";
            this.tabPageAO.Size = new System.Drawing.Size(594, 297);
            this.tabPageAO.Text = "AO";
            // 
            // listViewAoChannelInfo
            // 
            this.listViewAoChannelInfo.Columns.Add(this.ColumnAoInfoLocation);
            this.listViewAoChannelInfo.Columns.Add(this.ColumnAoInfoType);
            this.listViewAoChannelInfo.Columns.Add(this.ColumnAoInfoChNo);
            this.listViewAoChannelInfo.Columns.Add(this.ColumnAoInfoValueDec);
            this.listViewAoChannelInfo.Columns.Add(this.ColumnAoInfoValueHex);
            this.listViewAoChannelInfo.Columns.Add(this.ColumnAoInfoValueEng);
            this.listViewAoChannelInfo.Columns.Add(this.ColumnAoInfoRange);
            this.listViewAoChannelInfo.Location = new System.Drawing.Point(8, 165);
            this.listViewAoChannelInfo.Name = "listViewAoChannelInfo";
            this.listViewAoChannelInfo.Size = new System.Drawing.Size(576, 120);
            this.listViewAoChannelInfo.TabIndex = 11;
            this.listViewAoChannelInfo.View = System.Windows.Forms.View.Details;
            // 
            // ColumnAoInfoLocation
            // 
            this.ColumnAoInfoLocation.Text = "Address";
            this.ColumnAoInfoLocation.Width = 70;
            // 
            // ColumnAoInfoType
            // 
            this.ColumnAoInfoType.Text = "Type";
            this.ColumnAoInfoType.Width = 70;
            // 
            // ColumnAoInfoChNo
            // 
            this.ColumnAoInfoChNo.Text = "Ch";
            this.ColumnAoInfoChNo.Width = 45;
            // 
            // ColumnAoInfoValueDec
            // 
            this.ColumnAoInfoValueDec.Text = "Value[Dec]";
            this.ColumnAoInfoValueDec.Width = 90;
            // 
            // ColumnAoInfoValueHex
            // 
            this.ColumnAoInfoValueHex.Text = "Value[Hex]";
            this.ColumnAoInfoValueHex.Width = 90;
            // 
            // ColumnAoInfoValueEng
            // 
            this.ColumnAoInfoValueEng.Text = "Value[Eng]";
            this.ColumnAoInfoValueEng.Width = 90;
            // 
            // ColumnAoInfoRange
            // 
            this.ColumnAoInfoRange.Text = "Range";
            this.ColumnAoInfoRange.Width = 118;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(8, 138);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(131, 19);
            this.label10.Text = "Channel Information";
            // 
            // panelAoValueSetting
            // 
            this.panelAoValueSetting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panelAoValueSetting.Controls.Add(this.btnSetAoValue);
            this.panelAoValueSetting.Controls.Add(this.labAoHigh);
            this.panelAoValueSetting.Controls.Add(this.labAoLow);
            this.panelAoValueSetting.Controls.Add(this.tBarAoOutputVal);
            this.panelAoValueSetting.Controls.Add(this.txtAoOutputVal);
            this.panelAoValueSetting.Controls.Add(this.label9);
            this.panelAoValueSetting.Controls.Add(this.txtSelAoChannel);
            this.panelAoValueSetting.Controls.Add(this.label8);
            this.panelAoValueSetting.Controls.Add(this.label7);
            this.panelAoValueSetting.Location = new System.Drawing.Point(224, 9);
            this.panelAoValueSetting.Name = "panelAoValueSetting";
            this.panelAoValueSetting.Size = new System.Drawing.Size(360, 146);
            // 
            // btnSetAoValue
            // 
            this.btnSetAoValue.Location = new System.Drawing.Point(16, 117);
            this.btnSetAoValue.Name = "btnSetAoValue";
            this.btnSetAoValue.Size = new System.Drawing.Size(100, 20);
            this.btnSetAoValue.TabIndex = 8;
            this.btnSetAoValue.Text = "Apply Output";
            this.btnSetAoValue.Click += new System.EventHandler(this.btnSetAoValue_Click);
            // 
            // labAoHigh
            // 
            this.labAoHigh.Location = new System.Drawing.Point(319, 93);
            this.labAoHigh.Name = "labAoHigh";
            this.labAoHigh.Size = new System.Drawing.Size(60, 20);
            this.labAoHigh.Text = "High";
            // 
            // labAoLow
            // 
            this.labAoLow.Location = new System.Drawing.Point(17, 94);
            this.labAoLow.Name = "labAoLow";
            this.labAoLow.Size = new System.Drawing.Size(60, 20);
            this.labAoLow.Text = "Low";
            // 
            // tBarAoOutputVal
            // 
            this.tBarAoOutputVal.LargeChange = 16;
            this.tBarAoOutputVal.Location = new System.Drawing.Point(12, 54);
            this.tBarAoOutputVal.Maximum = 4095;
            this.tBarAoOutputVal.Name = "tBarAoOutputVal";
            this.tBarAoOutputVal.Size = new System.Drawing.Size(337, 45);
            this.tBarAoOutputVal.TabIndex = 5;
            this.tBarAoOutputVal.TickFrequency = 256;
            this.tBarAoOutputVal.ValueChanged += new System.EventHandler(this.tBarAoOutputVal_ValueChanged);
            // 
            // txtAoOutputVal
            // 
            this.txtAoOutputVal.Location = new System.Drawing.Point(242, 28);
            this.txtAoOutputVal.Name = "txtAoOutputVal";
            this.txtAoOutputVal.Size = new System.Drawing.Size(100, 23);
            this.txtAoOutputVal.TabIndex = 4;
            this.txtAoOutputVal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAoOutputVal_KeyPress);
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(195, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 20);
            this.label9.Text = "Value :     ";
            // 
            // txtSelAoChannel
            // 
            this.txtSelAoChannel.Location = new System.Drawing.Point(78, 28);
            this.txtSelAoChannel.Name = "txtSelAoChannel";
            this.txtSelAoChannel.ReadOnly = true;
            this.txtSelAoChannel.Size = new System.Drawing.Size(100, 23);
            this.txtSelAoChannel.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(16, 31);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 20);
            this.label8.Text = "Channel : ";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(8, 6);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 20);
            this.label7.Text = "Set Output Value";
            // 
            // btnApplyAoSelRange
            // 
            this.btnApplyAoSelRange.Location = new System.Drawing.Point(148, 104);
            this.btnApplyAoSelRange.Name = "btnApplyAoSelRange";
            this.btnApplyAoSelRange.Size = new System.Drawing.Size(70, 23);
            this.btnApplyAoSelRange.TabIndex = 5;
            this.btnApplyAoSelRange.Text = "Apply";
            this.btnApplyAoSelRange.Click += new System.EventHandler(this.btnApplyAoSelRange_Click);
            // 
            // cbxAoOutputRange
            // 
            this.cbxAoOutputRange.Location = new System.Drawing.Point(89, 75);
            this.cbxAoOutputRange.Name = "cbxAoOutputRange";
            this.cbxAoOutputRange.Size = new System.Drawing.Size(129, 23);
            this.cbxAoOutputRange.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(10, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 20);
            this.label6.Text = "Range : ";
            // 
            // cbxAoChannel
            // 
            this.cbxAoChannel.Location = new System.Drawing.Point(89, 38);
            this.cbxAoChannel.Name = "cbxAoChannel";
            this.cbxAoChannel.Size = new System.Drawing.Size(129, 23);
            this.cbxAoChannel.TabIndex = 2;
            this.cbxAoChannel.SelectedIndexChanged += new System.EventHandler(this.cbxAoChannel_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(10, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 20);
            this.label5.Text = "Channel : ";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(10, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 20);
            this.label4.Text = "Output Range";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(615, 419);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.txtReadCount);
            this.Controls.Add(this.txtModule);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Adam6224 Sample Program (C#)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
            this.tabControlMain.ResumeLayout(false);
            this.tabPageDI.ResumeLayout(false);
            this.tabPageAO.ResumeLayout(false);
            this.panelAoValueSetting.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtModule;
        private System.Windows.Forms.TextBox txtReadCount;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageDI;
        private System.Windows.Forms.TabPage tabPageAO;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listViewDiChannelInfo;
        private System.Windows.Forms.ColumnHeader ColumnDiInfoLocation;
        private System.Windows.Forms.ColumnHeader ColumnDiInfoType;
        private System.Windows.Forms.ColumnHeader ColumnDiInfoChNo;
        private System.Windows.Forms.ColumnHeader ColumnDiInfoModeValue;
        private System.Windows.Forms.ColumnHeader ColumnDiInfoChValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxAoOutputRange;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxAoChannel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnApplyAoSelRange;
        private System.Windows.Forms.Panel panelAoValueSetting;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TrackBar tBarAoOutputVal;
        private System.Windows.Forms.TextBox txtAoOutputVal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSelAoChannel;
        private System.Windows.Forms.Label labAoHigh;
        private System.Windows.Forms.Label labAoLow;
        private System.Windows.Forms.Button btnSetAoValue;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListView listViewAoChannelInfo;
        private System.Windows.Forms.ColumnHeader ColumnAoInfoLocation;
        private System.Windows.Forms.ColumnHeader ColumnAoInfoType;
        private System.Windows.Forms.ColumnHeader ColumnAoInfoChNo;
        private System.Windows.Forms.ColumnHeader ColumnAoInfoValueDec;
        private System.Windows.Forms.ColumnHeader ColumnAoInfoValueHex;
        private System.Windows.Forms.ColumnHeader ColumnAoInfoValueEng;
        private System.Windows.Forms.ColumnHeader ColumnAoInfoRange;
    }
}

