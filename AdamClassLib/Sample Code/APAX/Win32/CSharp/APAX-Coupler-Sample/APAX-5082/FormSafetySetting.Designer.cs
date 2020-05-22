namespace APAX_5082
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnApply = new System.Windows.Forms.Button();
            this.gridviewSafety = new System.Windows.Forms.DataGridView();
            this.colChannel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDOSafetyState = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.chbxSelecteAll = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridviewSafety)).BeginInit();
            this.SuspendLayout();
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(162, 381);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(68, 23);
            this.btnApply.TabIndex = 5;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // gridviewSafety
            // 
            this.gridviewSafety.AllowUserToAddRows = false;
            this.gridviewSafety.AllowUserToDeleteRows = false;
            this.gridviewSafety.AllowUserToResizeColumns = false;
            this.gridviewSafety.AllowUserToResizeRows = false;
            this.gridviewSafety.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gridviewSafety.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridviewSafety.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colChannel,
            this.colDOSafetyState});
            this.gridviewSafety.Location = new System.Drawing.Point(12, 12);
            this.gridviewSafety.MultiSelect = false;
            this.gridviewSafety.Name = "gridviewSafety";
            this.gridviewSafety.RowHeadersVisible = false;
            this.gridviewSafety.RowTemplate.Height = 24;
            this.gridviewSafety.Size = new System.Drawing.Size(218, 363);
            this.gridviewSafety.TabIndex = 4;
            this.gridviewSafety.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridviewSafety_CellContentClick);
            // 
            // colChannel
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colChannel.DefaultCellStyle = dataGridViewCellStyle1;
            this.colChannel.HeaderText = "Channel";
            this.colChannel.Name = "colChannel";
            this.colChannel.ReadOnly = true;
            this.colChannel.Width = 80;
            // 
            // colDOSafetyState
            // 
            this.colDOSafetyState.HeaderText = "          Safety State";
            this.colDOSafetyState.Name = "colDOSafetyState";
            this.colDOSafetyState.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colDOSafetyState.Width = 115;
            // 
            // chbxSelecteAll
            // 
            this.chbxSelecteAll.AutoSize = true;
            this.chbxSelecteAll.Location = new System.Drawing.Point(104, 16);
            this.chbxSelecteAll.Name = "chbxSelecteAll";
            this.chbxSelecteAll.Size = new System.Drawing.Size(15, 14);
            this.chbxSelecteAll.TabIndex = 6;
            this.chbxSelecteAll.UseVisualStyleBackColor = true;
            this.chbxSelecteAll.Click += new System.EventHandler(this.chbxSelecteAll_Click);
            // 
            // FormSafetySetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 476);
            this.Controls.Add(this.chbxSelecteAll);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.gridviewSafety);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSafetySetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Safety Setting";
            ((System.ComponentModel.ISupportInitialize)(this.gridviewSafety)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.DataGridView gridviewSafety;
        private System.Windows.Forms.DataGridViewTextBoxColumn colChannel;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colDOSafetyState;
        private System.Windows.Forms.CheckBox chbxSelecteAll;
    }
}