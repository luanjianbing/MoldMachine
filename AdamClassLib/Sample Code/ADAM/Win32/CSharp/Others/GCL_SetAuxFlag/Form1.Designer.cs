namespace GCL_SetAuxFlag
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
            this.txtReadCount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.btnSetAllTrue = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnSetAllFalse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtReadCount
            // 
            this.txtReadCount.Location = new System.Drawing.Point(90, 6);
            this.txtReadCount.Name = "txtReadCount";
            this.txtReadCount.ReadOnly = true;
            this.txtReadCount.Size = new System.Drawing.Size(150, 22);
            this.txtReadCount.TabIndex = 16;
            this.txtReadCount.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 12);
            this.label2.TabIndex = 15;
            this.label2.Text = "Read count:";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(328, 4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 17;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "Double click the list view to change the flag status:";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(14, 76);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(308, 330);
            this.listView1.TabIndex = 19;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Index";
            this.columnHeader1.Width = 71;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value";
            this.columnHeader2.Width = 118;
            // 
            // btnSetAllTrue
            // 
            this.btnSetAllTrue.Enabled = false;
            this.btnSetAllTrue.Location = new System.Drawing.Point(328, 76);
            this.btnSetAllTrue.Name = "btnSetAllTrue";
            this.btnSetAllTrue.Size = new System.Drawing.Size(75, 23);
            this.btnSetAllTrue.TabIndex = 20;
            this.btnSetAllTrue.Text = "Set All True";
            this.btnSetAllTrue.UseVisualStyleBackColor = true;
            this.btnSetAllTrue.Click += new System.EventHandler(this.btnSetAllTrue_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnSetAllFalse
            // 
            this.btnSetAllFalse.Enabled = false;
            this.btnSetAllFalse.Location = new System.Drawing.Point(328, 114);
            this.btnSetAllFalse.Name = "btnSetAllFalse";
            this.btnSetAllFalse.Size = new System.Drawing.Size(75, 23);
            this.btnSetAllFalse.TabIndex = 21;
            this.btnSetAllFalse.Text = "Set All False";
            this.btnSetAllFalse.UseVisualStyleBackColor = true;
            this.btnSetAllFalse.Click += new System.EventHandler(this.btnSetAllFalse_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 418);
            this.Controls.Add(this.btnSetAllFalse);
            this.Controls.Add(this.btnSetAllTrue);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtReadCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Set/Get GCL Auxiliary Flag Status (C#)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtReadCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnSetAllTrue;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnSetAllFalse;
    }
}

