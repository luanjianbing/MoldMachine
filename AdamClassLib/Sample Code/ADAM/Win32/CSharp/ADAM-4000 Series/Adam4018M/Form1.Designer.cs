namespace Adam4018M
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageData = new System.Windows.Forms.TabPage();
            this.txtAIValue7 = new System.Windows.Forms.TextBox();
            this.txtAIValue6 = new System.Windows.Forms.TextBox();
            this.txtAIValue5 = new System.Windows.Forms.TextBox();
            this.txtAIValue4 = new System.Windows.Forms.TextBox();
            this.txtAIValue3 = new System.Windows.Forms.TextBox();
            this.txtAIValue2 = new System.Windows.Forms.TextBox();
            this.txtAIValue1 = new System.Windows.Forms.TextBox();
            this.txtAIValue0 = new System.Windows.Forms.TextBox();
            this.chkboxCh7 = new System.Windows.Forms.CheckBox();
            this.chkboxCh6 = new System.Windows.Forms.CheckBox();
            this.chkboxCh5 = new System.Windows.Forms.CheckBox();
            this.chkboxCh4 = new System.Windows.Forms.CheckBox();
            this.chkboxCh3 = new System.Windows.Forms.CheckBox();
            this.chkboxCh2 = new System.Windows.Forms.CheckBox();
            this.chkboxCh1 = new System.Windows.Forms.CheckBox();
            this.chkboxCh0 = new System.Windows.Forms.CheckBox();
            this.tabPageMem = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.btnGetMem = new System.Windows.Forms.Button();
            this.btnStopMem = new System.Windows.Forms.Button();
            this.btnStartMem = new System.Windows.Forms.Button();
            this.txtMemEventCount = new System.Windows.Forms.TextBox();
            this.txtMemStandardCount = new System.Windows.Forms.TextBox();
            this.txtRecord = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPageData.SuspendLayout();
            this.tabPageMem.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(251, 4);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 36;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // txtReadCount
            // 
            this.txtReadCount.Location = new System.Drawing.Point(90, 40);
            this.txtReadCount.Name = "txtReadCount";
            this.txtReadCount.ReadOnly = true;
            this.txtReadCount.Size = new System.Drawing.Size(150, 22);
            this.txtReadCount.TabIndex = 35;
            this.txtReadCount.Text = "0";
            // 
            // txtModule
            // 
            this.txtModule.Location = new System.Drawing.Point(90, 6);
            this.txtModule.Name = "txtModule";
            this.txtModule.Size = new System.Drawing.Size(150, 22);
            this.txtModule.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 12);
            this.label2.TabIndex = 33;
            this.label2.Text = "Read count:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 12);
            this.label1.TabIndex = 32;
            this.label1.Text = "Module name:";
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageData);
            this.tabControl1.Controls.Add(this.tabPageMem);
            this.tabControl1.Location = new System.Drawing.Point(3, 79);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(334, 351);
            this.tabControl1.TabIndex = 37;
            // 
            // tabPageData
            // 
            this.tabPageData.Controls.Add(this.txtAIValue7);
            this.tabPageData.Controls.Add(this.txtAIValue6);
            this.tabPageData.Controls.Add(this.txtAIValue5);
            this.tabPageData.Controls.Add(this.txtAIValue4);
            this.tabPageData.Controls.Add(this.txtAIValue3);
            this.tabPageData.Controls.Add(this.txtAIValue2);
            this.tabPageData.Controls.Add(this.txtAIValue1);
            this.tabPageData.Controls.Add(this.txtAIValue0);
            this.tabPageData.Controls.Add(this.chkboxCh7);
            this.tabPageData.Controls.Add(this.chkboxCh6);
            this.tabPageData.Controls.Add(this.chkboxCh5);
            this.tabPageData.Controls.Add(this.chkboxCh4);
            this.tabPageData.Controls.Add(this.chkboxCh3);
            this.tabPageData.Controls.Add(this.chkboxCh2);
            this.tabPageData.Controls.Add(this.chkboxCh1);
            this.tabPageData.Controls.Add(this.chkboxCh0);
            this.tabPageData.Location = new System.Drawing.Point(4, 21);
            this.tabPageData.Name = "tabPageData";
            this.tabPageData.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageData.Size = new System.Drawing.Size(326, 326);
            this.tabPageData.TabIndex = 0;
            this.tabPageData.Text = "Data";
            this.tabPageData.UseVisualStyleBackColor = true;
            // 
            // txtAIValue7
            // 
            this.txtAIValue7.Location = new System.Drawing.Point(93, 251);
            this.txtAIValue7.Name = "txtAIValue7";
            this.txtAIValue7.ReadOnly = true;
            this.txtAIValue7.Size = new System.Drawing.Size(150, 22);
            this.txtAIValue7.TabIndex = 63;
            // 
            // txtAIValue6
            // 
            this.txtAIValue6.Location = new System.Drawing.Point(93, 216);
            this.txtAIValue6.Name = "txtAIValue6";
            this.txtAIValue6.ReadOnly = true;
            this.txtAIValue6.Size = new System.Drawing.Size(150, 22);
            this.txtAIValue6.TabIndex = 62;
            // 
            // txtAIValue5
            // 
            this.txtAIValue5.Location = new System.Drawing.Point(93, 179);
            this.txtAIValue5.Name = "txtAIValue5";
            this.txtAIValue5.ReadOnly = true;
            this.txtAIValue5.Size = new System.Drawing.Size(150, 22);
            this.txtAIValue5.TabIndex = 61;
            // 
            // txtAIValue4
            // 
            this.txtAIValue4.Location = new System.Drawing.Point(93, 143);
            this.txtAIValue4.Name = "txtAIValue4";
            this.txtAIValue4.ReadOnly = true;
            this.txtAIValue4.Size = new System.Drawing.Size(150, 22);
            this.txtAIValue4.TabIndex = 60;
            // 
            // txtAIValue3
            // 
            this.txtAIValue3.Location = new System.Drawing.Point(93, 108);
            this.txtAIValue3.Name = "txtAIValue3";
            this.txtAIValue3.ReadOnly = true;
            this.txtAIValue3.Size = new System.Drawing.Size(150, 22);
            this.txtAIValue3.TabIndex = 59;
            // 
            // txtAIValue2
            // 
            this.txtAIValue2.Location = new System.Drawing.Point(93, 73);
            this.txtAIValue2.Name = "txtAIValue2";
            this.txtAIValue2.ReadOnly = true;
            this.txtAIValue2.Size = new System.Drawing.Size(150, 22);
            this.txtAIValue2.TabIndex = 58;
            // 
            // txtAIValue1
            // 
            this.txtAIValue1.Location = new System.Drawing.Point(93, 40);
            this.txtAIValue1.Name = "txtAIValue1";
            this.txtAIValue1.ReadOnly = true;
            this.txtAIValue1.Size = new System.Drawing.Size(150, 22);
            this.txtAIValue1.TabIndex = 57;
            // 
            // txtAIValue0
            // 
            this.txtAIValue0.Location = new System.Drawing.Point(93, 4);
            this.txtAIValue0.Name = "txtAIValue0";
            this.txtAIValue0.ReadOnly = true;
            this.txtAIValue0.Size = new System.Drawing.Size(150, 22);
            this.txtAIValue0.TabIndex = 56;
            // 
            // chkboxCh7
            // 
            this.chkboxCh7.AutoSize = true;
            this.chkboxCh7.Enabled = false;
            this.chkboxCh7.Location = new System.Drawing.Point(6, 253);
            this.chkboxCh7.Name = "chkboxCh7";
            this.chkboxCh7.Size = new System.Drawing.Size(77, 16);
            this.chkboxCh7.TabIndex = 55;
            this.chkboxCh7.Text = "AI-7 value:";
            this.chkboxCh7.UseVisualStyleBackColor = true;
            // 
            // chkboxCh6
            // 
            this.chkboxCh6.AutoSize = true;
            this.chkboxCh6.Enabled = false;
            this.chkboxCh6.Location = new System.Drawing.Point(6, 218);
            this.chkboxCh6.Name = "chkboxCh6";
            this.chkboxCh6.Size = new System.Drawing.Size(77, 16);
            this.chkboxCh6.TabIndex = 54;
            this.chkboxCh6.Text = "AI-6 value:";
            this.chkboxCh6.UseVisualStyleBackColor = true;
            // 
            // chkboxCh5
            // 
            this.chkboxCh5.AutoSize = true;
            this.chkboxCh5.Enabled = false;
            this.chkboxCh5.Location = new System.Drawing.Point(6, 181);
            this.chkboxCh5.Name = "chkboxCh5";
            this.chkboxCh5.Size = new System.Drawing.Size(77, 16);
            this.chkboxCh5.TabIndex = 53;
            this.chkboxCh5.Text = "AI-5 value:";
            this.chkboxCh5.UseVisualStyleBackColor = true;
            // 
            // chkboxCh4
            // 
            this.chkboxCh4.AutoSize = true;
            this.chkboxCh4.Enabled = false;
            this.chkboxCh4.Location = new System.Drawing.Point(6, 145);
            this.chkboxCh4.Name = "chkboxCh4";
            this.chkboxCh4.Size = new System.Drawing.Size(77, 16);
            this.chkboxCh4.TabIndex = 52;
            this.chkboxCh4.Text = "AI-4 value:";
            this.chkboxCh4.UseVisualStyleBackColor = true;
            // 
            // chkboxCh3
            // 
            this.chkboxCh3.AutoSize = true;
            this.chkboxCh3.Enabled = false;
            this.chkboxCh3.Location = new System.Drawing.Point(6, 110);
            this.chkboxCh3.Name = "chkboxCh3";
            this.chkboxCh3.Size = new System.Drawing.Size(77, 16);
            this.chkboxCh3.TabIndex = 51;
            this.chkboxCh3.Text = "AI-3 value:";
            this.chkboxCh3.UseVisualStyleBackColor = true;
            // 
            // chkboxCh2
            // 
            this.chkboxCh2.AutoSize = true;
            this.chkboxCh2.Enabled = false;
            this.chkboxCh2.Location = new System.Drawing.Point(6, 75);
            this.chkboxCh2.Name = "chkboxCh2";
            this.chkboxCh2.Size = new System.Drawing.Size(77, 16);
            this.chkboxCh2.TabIndex = 50;
            this.chkboxCh2.Text = "AI-2 value:";
            this.chkboxCh2.UseVisualStyleBackColor = true;
            // 
            // chkboxCh1
            // 
            this.chkboxCh1.AutoSize = true;
            this.chkboxCh1.Enabled = false;
            this.chkboxCh1.Location = new System.Drawing.Point(6, 42);
            this.chkboxCh1.Name = "chkboxCh1";
            this.chkboxCh1.Size = new System.Drawing.Size(77, 16);
            this.chkboxCh1.TabIndex = 49;
            this.chkboxCh1.Text = "AI-1 value:";
            this.chkboxCh1.UseVisualStyleBackColor = true;
            // 
            // chkboxCh0
            // 
            this.chkboxCh0.AutoSize = true;
            this.chkboxCh0.Enabled = false;
            this.chkboxCh0.Location = new System.Drawing.Point(6, 6);
            this.chkboxCh0.Name = "chkboxCh0";
            this.chkboxCh0.Size = new System.Drawing.Size(77, 16);
            this.chkboxCh0.TabIndex = 48;
            this.chkboxCh0.Text = "AI-0 value:";
            this.chkboxCh0.UseVisualStyleBackColor = true;
            // 
            // tabPageMem
            // 
            this.tabPageMem.BackColor = System.Drawing.Color.Transparent;
            this.tabPageMem.Controls.Add(this.listView1);
            this.tabPageMem.Controls.Add(this.btnGetMem);
            this.tabPageMem.Controls.Add(this.btnStopMem);
            this.tabPageMem.Controls.Add(this.btnStartMem);
            this.tabPageMem.Controls.Add(this.txtMemEventCount);
            this.tabPageMem.Controls.Add(this.txtMemStandardCount);
            this.tabPageMem.Controls.Add(this.txtRecord);
            this.tabPageMem.Controls.Add(this.label5);
            this.tabPageMem.Controls.Add(this.label4);
            this.tabPageMem.Controls.Add(this.label3);
            this.tabPageMem.Location = new System.Drawing.Point(4, 21);
            this.tabPageMem.Name = "tabPageMem";
            this.tabPageMem.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMem.Size = new System.Drawing.Size(326, 326);
            this.tabPageMem.TabIndex = 1;
            this.tabPageMem.Text = "Memory";
            this.tabPageMem.UseVisualStyleBackColor = true;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView1.Location = new System.Drawing.Point(8, 98);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(312, 222);
            this.listView1.TabIndex = 9;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Index";
            this.columnHeader1.Width = 51;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Ch";
            this.columnHeader2.Width = 48;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Data";
            this.columnHeader3.Width = 79;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Elapse";
            this.columnHeader4.Width = 69;
            // 
            // btnGetMem
            // 
            this.btnGetMem.Location = new System.Drawing.Point(245, 68);
            this.btnGetMem.Name = "btnGetMem";
            this.btnGetMem.Size = new System.Drawing.Size(75, 23);
            this.btnGetMem.TabIndex = 8;
            this.btnGetMem.Text = "Get records";
            this.btnGetMem.UseVisualStyleBackColor = true;
            this.btnGetMem.Click += new System.EventHandler(this.btnGetMem_Click);
            // 
            // btnStopMem
            // 
            this.btnStopMem.Location = new System.Drawing.Point(245, 40);
            this.btnStopMem.Name = "btnStopMem";
            this.btnStopMem.Size = new System.Drawing.Size(75, 23);
            this.btnStopMem.TabIndex = 7;
            this.btnStopMem.Text = "Stop";
            this.btnStopMem.UseVisualStyleBackColor = true;
            this.btnStopMem.Click += new System.EventHandler(this.btnStopMem_Click);
            // 
            // btnStartMem
            // 
            this.btnStartMem.Location = new System.Drawing.Point(245, 11);
            this.btnStartMem.Name = "btnStartMem";
            this.btnStartMem.Size = new System.Drawing.Size(75, 23);
            this.btnStartMem.TabIndex = 6;
            this.btnStartMem.Text = "Start";
            this.btnStartMem.UseVisualStyleBackColor = true;
            this.btnStartMem.Click += new System.EventHandler(this.btnStartMem_Click);
            // 
            // txtMemEventCount
            // 
            this.txtMemEventCount.Location = new System.Drawing.Point(94, 70);
            this.txtMemEventCount.Name = "txtMemEventCount";
            this.txtMemEventCount.ReadOnly = true;
            this.txtMemEventCount.Size = new System.Drawing.Size(100, 22);
            this.txtMemEventCount.TabIndex = 5;
            // 
            // txtMemStandardCount
            // 
            this.txtMemStandardCount.Location = new System.Drawing.Point(94, 42);
            this.txtMemStandardCount.Name = "txtMemStandardCount";
            this.txtMemStandardCount.ReadOnly = true;
            this.txtMemStandardCount.Size = new System.Drawing.Size(100, 22);
            this.txtMemStandardCount.TabIndex = 4;
            // 
            // txtRecord
            // 
            this.txtRecord.Location = new System.Drawing.Point(94, 13);
            this.txtRecord.Name = "txtRecord";
            this.txtRecord.ReadOnly = true;
            this.txtRecord.Size = new System.Drawing.Size(100, 22);
            this.txtRecord.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "Event record:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "Standard record:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "Recording:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 430);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.txtReadCount);
            this.Controls.Add(this.txtModule);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Adam4018M sample program (C#)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPageData.ResumeLayout(false);
            this.tabPageData.PerformLayout();
            this.tabPageMem.ResumeLayout(false);
            this.tabPageMem.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.TextBox txtReadCount;
        private System.Windows.Forms.TextBox txtModule;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageData;
        private System.Windows.Forms.TextBox txtAIValue7;
        private System.Windows.Forms.TextBox txtAIValue6;
        private System.Windows.Forms.TextBox txtAIValue5;
        private System.Windows.Forms.TextBox txtAIValue4;
        private System.Windows.Forms.TextBox txtAIValue3;
        private System.Windows.Forms.TextBox txtAIValue2;
        private System.Windows.Forms.TextBox txtAIValue1;
        private System.Windows.Forms.TextBox txtAIValue0;
        private System.Windows.Forms.CheckBox chkboxCh7;
        private System.Windows.Forms.CheckBox chkboxCh6;
        private System.Windows.Forms.CheckBox chkboxCh5;
        private System.Windows.Forms.CheckBox chkboxCh4;
        private System.Windows.Forms.CheckBox chkboxCh3;
        private System.Windows.Forms.CheckBox chkboxCh2;
        private System.Windows.Forms.CheckBox chkboxCh1;
        private System.Windows.Forms.CheckBox chkboxCh0;
        private System.Windows.Forms.TabPage tabPageMem;
        private System.Windows.Forms.Button btnStopMem;
        private System.Windows.Forms.Button btnStartMem;
        private System.Windows.Forms.TextBox txtMemEventCount;
        private System.Windows.Forms.TextBox txtMemStandardCount;
        private System.Windows.Forms.TextBox txtRecord;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGetMem;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}

