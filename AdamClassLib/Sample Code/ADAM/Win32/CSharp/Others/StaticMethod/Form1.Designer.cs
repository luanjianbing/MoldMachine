namespace StaticMethod
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
            this.cbxAdamType = new System.Windows.Forms.ComboBox();
            this.cbxModuleType = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageAI = new System.Windows.Forms.TabPage();
            this.listViewAI = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.txtAITotal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPageAO = new System.Windows.Forms.TabPage();
            this.listViewAO = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.txtAOTotal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPageDIO = new System.Windows.Forms.TabPage();
            this.txtDOTotal = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDITotal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPageOther = new System.Windows.Forms.TabPage();
            this.listViewAlarm = new System.Windows.Forms.ListView();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.label11 = new System.Windows.Forms.Label();
            this.listViewCounter = new System.Windows.Forms.ListView();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.txtCounterTotal = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPageAI.SuspendLayout();
            this.tabPageAO.SuspendLayout();
            this.tabPageDIO.SuspendLayout();
            this.tabPageOther.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "ADAM type:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Module type:";
            // 
            // cbxAdamType
            // 
            this.cbxAdamType.FormattingEnabled = true;
            this.cbxAdamType.Location = new System.Drawing.Point(83, 6);
            this.cbxAdamType.Name = "cbxAdamType";
            this.cbxAdamType.Size = new System.Drawing.Size(121, 20);
            this.cbxAdamType.TabIndex = 4;
            this.cbxAdamType.SelectedIndexChanged += new System.EventHandler(this.cbxAdamType_SelectedIndexChanged);
            // 
            // cbxModuleType
            // 
            this.cbxModuleType.FormattingEnabled = true;
            this.cbxModuleType.Location = new System.Drawing.Point(83, 36);
            this.cbxModuleType.Name = "cbxModuleType";
            this.cbxModuleType.Size = new System.Drawing.Size(121, 20);
            this.cbxModuleType.TabIndex = 5;
            this.cbxModuleType.SelectedIndexChanged += new System.EventHandler(this.cbxModuleType_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageAI);
            this.tabControl1.Controls.Add(this.tabPageAO);
            this.tabControl1.Controls.Add(this.tabPageDIO);
            this.tabControl1.Controls.Add(this.tabPageOther);
            this.tabControl1.Location = new System.Drawing.Point(5, 62);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(476, 361);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPageAI
            // 
            this.tabPageAI.Controls.Add(this.listViewAI);
            this.tabPageAI.Controls.Add(this.txtAITotal);
            this.tabPageAI.Controls.Add(this.label4);
            this.tabPageAI.Controls.Add(this.label3);
            this.tabPageAI.Location = new System.Drawing.Point(4, 22);
            this.tabPageAI.Name = "tabPageAI";
            this.tabPageAI.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAI.Size = new System.Drawing.Size(468, 335);
            this.tabPageAI.TabIndex = 0;
            this.tabPageAI.Text = "Analog input";
            this.tabPageAI.UseVisualStyleBackColor = true;
            // 
            // listViewAI
            // 
            this.listViewAI.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewAI.Location = new System.Drawing.Point(82, 49);
            this.listViewAI.Name = "listViewAI";
            this.listViewAI.Size = new System.Drawing.Size(380, 281);
            this.listViewAI.TabIndex = 3;
            this.listViewAI.UseCompatibleStateImageBehavior = false;
            this.listViewAI.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Code";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Range name";
            this.columnHeader2.Width = 117;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Unit";
            this.columnHeader3.Width = 91;
            // 
            // txtAITotal
            // 
            this.txtAITotal.Location = new System.Drawing.Point(82, 13);
            this.txtAITotal.Name = "txtAITotal";
            this.txtAITotal.Size = new System.Drawing.Size(100, 22);
            this.txtAITotal.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "Input range:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "Channel total:";
            // 
            // tabPageAO
            // 
            this.tabPageAO.Controls.Add(this.listViewAO);
            this.tabPageAO.Controls.Add(this.txtAOTotal);
            this.tabPageAO.Controls.Add(this.label5);
            this.tabPageAO.Controls.Add(this.label6);
            this.tabPageAO.Location = new System.Drawing.Point(4, 22);
            this.tabPageAO.Name = "tabPageAO";
            this.tabPageAO.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAO.Size = new System.Drawing.Size(468, 335);
            this.tabPageAO.TabIndex = 1;
            this.tabPageAO.Text = "Analog output";
            this.tabPageAO.UseVisualStyleBackColor = true;
            // 
            // listViewAO
            // 
            this.listViewAO.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listViewAO.Location = new System.Drawing.Point(82, 46);
            this.listViewAO.Name = "listViewAO";
            this.listViewAO.Size = new System.Drawing.Size(380, 281);
            this.listViewAO.TabIndex = 7;
            this.listViewAO.UseCompatibleStateImageBehavior = false;
            this.listViewAO.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Code";
            this.columnHeader4.Width = 80;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Range name";
            this.columnHeader5.Width = 117;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Unit";
            this.columnHeader6.Width = 91;
            // 
            // txtAOTotal
            // 
            this.txtAOTotal.Location = new System.Drawing.Point(82, 10);
            this.txtAOTotal.Name = "txtAOTotal";
            this.txtAOTotal.Size = new System.Drawing.Size(100, 22);
            this.txtAOTotal.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "Output range:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "Channel total:";
            // 
            // tabPageDIO
            // 
            this.tabPageDIO.Controls.Add(this.txtDOTotal);
            this.tabPageDIO.Controls.Add(this.label8);
            this.tabPageDIO.Controls.Add(this.txtDITotal);
            this.tabPageDIO.Controls.Add(this.label7);
            this.tabPageDIO.Location = new System.Drawing.Point(4, 22);
            this.tabPageDIO.Name = "tabPageDIO";
            this.tabPageDIO.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDIO.Size = new System.Drawing.Size(468, 335);
            this.tabPageDIO.TabIndex = 2;
            this.tabPageDIO.Text = "Digital input/output";
            this.tabPageDIO.UseVisualStyleBackColor = true;
            // 
            // txtDOTotal
            // 
            this.txtDOTotal.Location = new System.Drawing.Point(82, 58);
            this.txtDOTotal.Name = "txtDOTotal";
            this.txtDOTotal.Size = new System.Drawing.Size(100, 22);
            this.txtDOTotal.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 61);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 12);
            this.label8.TabIndex = 5;
            this.label8.Text = "Output total:";
            // 
            // txtDITotal
            // 
            this.txtDITotal.Location = new System.Drawing.Point(82, 17);
            this.txtDITotal.Name = "txtDITotal";
            this.txtDITotal.Size = new System.Drawing.Size(100, 22);
            this.txtDITotal.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 12);
            this.label7.TabIndex = 3;
            this.label7.Text = "Input total:";
            // 
            // tabPageOther
            // 
            this.tabPageOther.Controls.Add(this.listViewAlarm);
            this.tabPageOther.Controls.Add(this.label11);
            this.tabPageOther.Controls.Add(this.listViewCounter);
            this.tabPageOther.Controls.Add(this.txtCounterTotal);
            this.tabPageOther.Controls.Add(this.label9);
            this.tabPageOther.Controls.Add(this.label10);
            this.tabPageOther.Location = new System.Drawing.Point(4, 22);
            this.tabPageOther.Name = "tabPageOther";
            this.tabPageOther.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOther.Size = new System.Drawing.Size(468, 335);
            this.tabPageOther.TabIndex = 3;
            this.tabPageOther.Text = "Counter/Alarm";
            this.tabPageOther.UseVisualStyleBackColor = true;
            // 
            // listViewAlarm
            // 
            this.listViewAlarm.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9});
            this.listViewAlarm.Location = new System.Drawing.Point(82, 196);
            this.listViewAlarm.Name = "listViewAlarm";
            this.listViewAlarm.Size = new System.Drawing.Size(380, 137);
            this.listViewAlarm.TabIndex = 9;
            this.listViewAlarm.UseCompatibleStateImageBehavior = false;
            this.listViewAlarm.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Mode name";
            this.columnHeader9.Width = 183;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 196);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(66, 12);
            this.label11.TabIndex = 8;
            this.label11.Text = "Alarm mode:";
            // 
            // listViewCounter
            // 
            this.listViewCounter.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8});
            this.listViewCounter.Location = new System.Drawing.Point(82, 46);
            this.listViewCounter.Name = "listViewCounter";
            this.listViewCounter.Size = new System.Drawing.Size(380, 137);
            this.listViewCounter.TabIndex = 7;
            this.listViewCounter.UseCompatibleStateImageBehavior = false;
            this.listViewCounter.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Mode name";
            this.columnHeader7.Width = 184;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Unit";
            this.columnHeader8.Width = 117;
            // 
            // txtCounterTotal
            // 
            this.txtCounterTotal.Location = new System.Drawing.Point(82, 10);
            this.txtCounterTotal.Name = "txtCounterTotal";
            this.txtCounterTotal.Size = new System.Drawing.Size(100, 22);
            this.txtCounterTotal.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 12);
            this.label9.TabIndex = 5;
            this.label9.Text = "Counter mode:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 12);
            this.label10.TabIndex = 4;
            this.label10.Text = "Counter total:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 428);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.cbxModuleType);
            this.Controls.Add(this.cbxAdamType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Static Method Sample Program (C#)";
            this.tabControl1.ResumeLayout(false);
            this.tabPageAI.ResumeLayout(false);
            this.tabPageAI.PerformLayout();
            this.tabPageAO.ResumeLayout(false);
            this.tabPageAO.PerformLayout();
            this.tabPageDIO.ResumeLayout(false);
            this.tabPageDIO.PerformLayout();
            this.tabPageOther.ResumeLayout(false);
            this.tabPageOther.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxAdamType;
        private System.Windows.Forms.ComboBox cbxModuleType;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageAI;
        private System.Windows.Forms.TabPage tabPageAO;
        private System.Windows.Forms.ListView listViewAI;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.TextBox txtAITotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tabPageDIO;
        private System.Windows.Forms.TabPage tabPageOther;
        private System.Windows.Forms.ListView listViewAO;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.TextBox txtAOTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDOTotal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDITotal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView listViewCounter;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.TextBox txtCounterTotal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListView listViewAlarm;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Label label11;
    }
}

