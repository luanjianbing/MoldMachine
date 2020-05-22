namespace APAX_5028
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
            this.gridviewSafety = new System.Windows.Forms.ListView();
            this.clmCh = new System.Windows.Forms.ColumnHeader();
            this.clmSafetyValue = new System.Windows.Forms.ColumnHeader();
            this.txtChannel = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnSet = new System.Windows.Forms.Button();
            this.labSafety = new System.Windows.Forms.Label();
            this.txtSafetyVal = new System.Windows.Forms.TextBox();
            this.labRange = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gridviewSafety
            // 
            this.gridviewSafety.Columns.Add(this.clmCh);
            this.gridviewSafety.Columns.Add(this.clmSafetyValue);
            this.gridviewSafety.FullRowSelect = true;
            this.gridviewSafety.Location = new System.Drawing.Point(8, 8);
            this.gridviewSafety.Name = "gridviewSafety";
            this.gridviewSafety.Size = new System.Drawing.Size(232, 244);
            this.gridviewSafety.TabIndex = 20;
            this.gridviewSafety.View = System.Windows.Forms.View.Details;
            this.gridviewSafety.SelectedIndexChanged += new System.EventHandler(this.gridviewSafety_SelectedIndexChanged);
            // 
            // clmCh
            // 
            this.clmCh.Text = "Channel";
            this.clmCh.Width = 100;
            // 
            // clmSafetyValue
            // 
            this.clmSafetyValue.Text = "Safety Value";
            this.clmSafetyValue.Width = 120;
            // 
            // txtChannel
            // 
            this.txtChannel.Enabled = false;
            this.txtChannel.Location = new System.Drawing.Point(72, 261);
            this.txtChannel.Name = "txtChannel";
            this.txtChannel.Size = new System.Drawing.Size(60, 23);
            this.txtChannel.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 265);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.Text = "Channel";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(168, 340);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(72, 20);
            this.btnApply.TabIndex = 28;
            this.btnApply.Text = "Apply";
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(168, 312);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(72, 20);
            this.btnSet.TabIndex = 29;
            this.btnSet.Text = "Set";
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // labSafety
            // 
            this.labSafety.Location = new System.Drawing.Point(8, 296);
            this.labSafety.Name = "labSafety";
            this.labSafety.Size = new System.Drawing.Size(64, 20);
            this.labSafety.Text = "Value";
            // 
            // txtSafetyVal
            // 
            this.txtSafetyVal.Location = new System.Drawing.Point(72, 293);
            this.txtSafetyVal.Name = "txtSafetyVal";
            this.txtSafetyVal.Size = new System.Drawing.Size(60, 23);
            this.txtSafetyVal.TabIndex = 32;
            // 
            // labRange
            // 
            this.labRange.Location = new System.Drawing.Point(138, 264);
            this.labRange.Name = "labRange";
            this.labRange.Size = new System.Drawing.Size(100, 20);
            // 
            // FormSafetySetting
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(248, 375);
            this.Controls.Add(this.labRange);
            this.Controls.Add(this.txtSafetyVal);
            this.Controls.Add(this.labSafety);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.txtChannel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gridviewSafety);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSafetySetting";
            this.Text = "Safety Setting";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView gridviewSafety;
        private System.Windows.Forms.ColumnHeader clmCh;
        private System.Windows.Forms.ColumnHeader clmSafetyValue;
        private System.Windows.Forms.TextBox txtChannel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.Label labSafety;
        private System.Windows.Forms.TextBox txtSafetyVal;
        private System.Windows.Forms.Label labRange;
    }
}