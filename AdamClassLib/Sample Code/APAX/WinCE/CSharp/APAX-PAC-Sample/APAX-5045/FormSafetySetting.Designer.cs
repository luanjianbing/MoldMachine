namespace APAX_5045
{
    partial class FormSafetySetting
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
            this.rdbtnOff = new System.Windows.Forms.RadioButton();
            this.rdbtnOn = new System.Windows.Forms.RadioButton();
            this.chbxSelecteAll = new System.Windows.Forms.CheckBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.txtChannel = new System.Windows.Forms.TextBox();
            this.labSafety = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSet = new System.Windows.Forms.Button();
            this.gridviewSafety = new System.Windows.Forms.ListView();
            this.clmCh = new System.Windows.Forms.ColumnHeader();
            this.clmSafetyStat = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // rdbtnOff
            // 
            this.rdbtnOff.Location = new System.Drawing.Point(120, 292);
            this.rdbtnOff.Name = "rdbtnOff";
            this.rdbtnOff.Size = new System.Drawing.Size(48, 20);
            this.rdbtnOff.TabIndex = 29;
            this.rdbtnOff.Text = "Off";
            // 
            // rdbtnOn
            // 
            this.rdbtnOn.Location = new System.Drawing.Point(72, 292);
            this.rdbtnOn.Name = "rdbtnOn";
            this.rdbtnOn.Size = new System.Drawing.Size(48, 20);
            this.rdbtnOn.TabIndex = 30;
            this.rdbtnOn.Text = "On";
            // 
            // chbxSelecteAll
            // 
            this.chbxSelecteAll.Location = new System.Drawing.Point(68, 320);
            this.chbxSelecteAll.Name = "chbxSelecteAll";
            this.chbxSelecteAll.Size = new System.Drawing.Size(84, 20);
            this.chbxSelecteAll.TabIndex = 31;
            this.chbxSelecteAll.Text = "ApplyAll";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(164, 348);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(72, 20);
            this.btnApply.TabIndex = 32;
            this.btnApply.Text = "Apply";
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // txtChannel
            // 
            this.txtChannel.Enabled = false;
            this.txtChannel.Location = new System.Drawing.Point(72, 260);
            this.txtChannel.Name = "txtChannel";
            this.txtChannel.Size = new System.Drawing.Size(60, 23);
            this.txtChannel.TabIndex = 33;
            // 
            // labSafety
            // 
            this.labSafety.Location = new System.Drawing.Point(8, 292);
            this.labSafety.Name = "labSafety";
            this.labSafety.Size = new System.Drawing.Size(64, 20);
            this.labSafety.Text = "Value";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 264);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.Text = "Channel";
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(164, 320);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(72, 20);
            this.btnSet.TabIndex = 36;
            this.btnSet.Text = "Set";
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // gridviewSafety
            // 
            this.gridviewSafety.Columns.Add(this.clmCh);
            this.gridviewSafety.Columns.Add(this.clmSafetyStat);
            this.gridviewSafety.FullRowSelect = true;
            this.gridviewSafety.Location = new System.Drawing.Point(8, 8);
            this.gridviewSafety.Name = "gridviewSafety";
            this.gridviewSafety.Size = new System.Drawing.Size(232, 244);
            this.gridviewSafety.TabIndex = 28;
            this.gridviewSafety.View = System.Windows.Forms.View.Details;
            this.gridviewSafety.SelectedIndexChanged += new System.EventHandler(this.gridviewSafety_SelectedIndexChanged);
            // 
            // clmCh
            // 
            this.clmCh.Text = "Channel";
            this.clmCh.Width = 100;
            // 
            // clmSafetyStat
            // 
            this.clmSafetyStat.Text = "Safety State";
            this.clmSafetyStat.Width = 120;
            // 
            // FormSafetySetting
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(248, 375);
            this.Controls.Add(this.rdbtnOff);
            this.Controls.Add(this.rdbtnOn);
            this.Controls.Add(this.chbxSelecteAll);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.txtChannel);
            this.Controls.Add(this.labSafety);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.gridviewSafety);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSafetySetting";
            this.Text = "Safety Setting";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton rdbtnOff;
        private System.Windows.Forms.RadioButton rdbtnOn;
        private System.Windows.Forms.CheckBox chbxSelecteAll;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TextBox txtChannel;
        private System.Windows.Forms.Label labSafety;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.ListView gridviewSafety;
        private System.Windows.Forms.ColumnHeader clmCh;
        private System.Windows.Forms.ColumnHeader clmSafetyStat;
    }
}