namespace Adam6217
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
            this.chkboxCh0 = new System.Windows.Forms.CheckBox();
            this.chkboxCh1 = new System.Windows.Forms.CheckBox();
            this.chkboxCh2 = new System.Windows.Forms.CheckBox();
            this.chkboxCh3 = new System.Windows.Forms.CheckBox();
            this.chkboxCh4 = new System.Windows.Forms.CheckBox();
            this.chkboxCh5 = new System.Windows.Forms.CheckBox();
            this.chkboxCh6 = new System.Windows.Forms.CheckBox();
            this.chkboxCh7 = new System.Windows.Forms.CheckBox();
            this.txtAIValue0 = new System.Windows.Forms.TextBox();
            this.txtAIValue1 = new System.Windows.Forms.TextBox();
            this.txtAIValue2 = new System.Windows.Forms.TextBox();
            this.txtAIValue3 = new System.Windows.Forms.TextBox();
            this.txtAIValue4 = new System.Windows.Forms.TextBox();
            this.txtAIValue5 = new System.Windows.Forms.TextBox();
            this.txtAIValue6 = new System.Windows.Forms.TextBox();
            this.txtAIValue7 = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(17, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 20);
            this.label1.Text = "Module name:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(17, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 20);
            this.label2.Text = "Read count:";
            // 
            // txtModule
            // 
            this.txtModule.Location = new System.Drawing.Point(169, 16);
            this.txtModule.Name = "txtModule";
            this.txtModule.Size = new System.Drawing.Size(176, 23);
            this.txtModule.TabIndex = 2;
            // 
            // txtReadCount
            // 
            this.txtReadCount.Location = new System.Drawing.Point(169, 48);
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
            // chkboxCh0
            // 
            this.chkboxCh0.Enabled = false;
            this.chkboxCh0.Location = new System.Drawing.Point(17, 96);
            this.chkboxCh0.Name = "chkboxCh0";
            this.chkboxCh0.Size = new System.Drawing.Size(136, 20);
            this.chkboxCh0.TabIndex = 5;
            this.chkboxCh0.Text = "AI-0 value:";
            // 
            // chkboxCh1
            // 
            this.chkboxCh1.Enabled = false;
            this.chkboxCh1.Location = new System.Drawing.Point(17, 128);
            this.chkboxCh1.Name = "chkboxCh1";
            this.chkboxCh1.Size = new System.Drawing.Size(136, 20);
            this.chkboxCh1.TabIndex = 6;
            this.chkboxCh1.Text = "AI-1 value:";
            // 
            // chkboxCh2
            // 
            this.chkboxCh2.Enabled = false;
            this.chkboxCh2.Location = new System.Drawing.Point(17, 160);
            this.chkboxCh2.Name = "chkboxCh2";
            this.chkboxCh2.Size = new System.Drawing.Size(136, 20);
            this.chkboxCh2.TabIndex = 7;
            this.chkboxCh2.Text = "AI-2 value:";
            // 
            // chkboxCh3
            // 
            this.chkboxCh3.Enabled = false;
            this.chkboxCh3.Location = new System.Drawing.Point(17, 192);
            this.chkboxCh3.Name = "chkboxCh3";
            this.chkboxCh3.Size = new System.Drawing.Size(136, 20);
            this.chkboxCh3.TabIndex = 8;
            this.chkboxCh3.Text = "AI-3 value:";
            // 
            // chkboxCh4
            // 
            this.chkboxCh4.Enabled = false;
            this.chkboxCh4.Location = new System.Drawing.Point(17, 224);
            this.chkboxCh4.Name = "chkboxCh4";
            this.chkboxCh4.Size = new System.Drawing.Size(136, 20);
            this.chkboxCh4.TabIndex = 9;
            this.chkboxCh4.Text = "AI-4 value:";
            // 
            // chkboxCh5
            // 
            this.chkboxCh5.Enabled = false;
            this.chkboxCh5.Location = new System.Drawing.Point(17, 256);
            this.chkboxCh5.Name = "chkboxCh5";
            this.chkboxCh5.Size = new System.Drawing.Size(136, 20);
            this.chkboxCh5.TabIndex = 10;
            this.chkboxCh5.Text = "AI-5 value:";
            // 
            // chkboxCh6
            // 
            this.chkboxCh6.Enabled = false;
            this.chkboxCh6.Location = new System.Drawing.Point(17, 288);
            this.chkboxCh6.Name = "chkboxCh6";
            this.chkboxCh6.Size = new System.Drawing.Size(136, 20);
            this.chkboxCh6.TabIndex = 11;
            this.chkboxCh6.Text = "AI-6 value:";
            // 
            // chkboxCh7
            // 
            this.chkboxCh7.Enabled = false;
            this.chkboxCh7.Location = new System.Drawing.Point(17, 320);
            this.chkboxCh7.Name = "chkboxCh7";
            this.chkboxCh7.Size = new System.Drawing.Size(136, 20);
            this.chkboxCh7.TabIndex = 12;
            this.chkboxCh7.Text = "AI-7 value:";
            // 
            // txtAIValue0
            // 
            this.txtAIValue0.Location = new System.Drawing.Point(169, 96);
            this.txtAIValue0.Name = "txtAIValue0";
            this.txtAIValue0.Size = new System.Drawing.Size(176, 23);
            this.txtAIValue0.TabIndex = 13;
            // 
            // txtAIValue1
            // 
            this.txtAIValue1.Location = new System.Drawing.Point(169, 128);
            this.txtAIValue1.Name = "txtAIValue1";
            this.txtAIValue1.Size = new System.Drawing.Size(176, 23);
            this.txtAIValue1.TabIndex = 14;
            // 
            // txtAIValue2
            // 
            this.txtAIValue2.Location = new System.Drawing.Point(169, 160);
            this.txtAIValue2.Name = "txtAIValue2";
            this.txtAIValue2.Size = new System.Drawing.Size(176, 23);
            this.txtAIValue2.TabIndex = 15;
            // 
            // txtAIValue3
            // 
            this.txtAIValue3.Location = new System.Drawing.Point(169, 192);
            this.txtAIValue3.Name = "txtAIValue3";
            this.txtAIValue3.Size = new System.Drawing.Size(176, 23);
            this.txtAIValue3.TabIndex = 16;
            // 
            // txtAIValue4
            // 
            this.txtAIValue4.Location = new System.Drawing.Point(169, 224);
            this.txtAIValue4.Name = "txtAIValue4";
            this.txtAIValue4.Size = new System.Drawing.Size(176, 23);
            this.txtAIValue4.TabIndex = 17;
            // 
            // txtAIValue5
            // 
            this.txtAIValue5.Location = new System.Drawing.Point(169, 256);
            this.txtAIValue5.Name = "txtAIValue5";
            this.txtAIValue5.Size = new System.Drawing.Size(176, 23);
            this.txtAIValue5.TabIndex = 18;
            // 
            // txtAIValue6
            // 
            this.txtAIValue6.Location = new System.Drawing.Point(169, 288);
            this.txtAIValue6.Name = "txtAIValue6";
            this.txtAIValue6.Size = new System.Drawing.Size(176, 23);
            this.txtAIValue6.TabIndex = 19;
            // 
            // txtAIValue7
            // 
            this.txtAIValue7.Location = new System.Drawing.Point(169, 320);
            this.txtAIValue7.Name = "txtAIValue7";
            this.txtAIValue7.Size = new System.Drawing.Size(176, 23);
            this.txtAIValue7.TabIndex = 20;
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
            this.ClientSize = new System.Drawing.Size(526, 379);
            this.Controls.Add(this.txtAIValue7);
            this.Controls.Add(this.txtAIValue6);
            this.Controls.Add(this.txtAIValue5);
            this.Controls.Add(this.txtAIValue4);
            this.Controls.Add(this.txtAIValue3);
            this.Controls.Add(this.txtAIValue2);
            this.Controls.Add(this.txtAIValue1);
            this.Controls.Add(this.txtAIValue0);
            this.Controls.Add(this.chkboxCh7);
            this.Controls.Add(this.chkboxCh6);
            this.Controls.Add(this.chkboxCh5);
            this.Controls.Add(this.chkboxCh4);
            this.Controls.Add(this.chkboxCh3);
            this.Controls.Add(this.chkboxCh2);
            this.Controls.Add(this.chkboxCh1);
            this.Controls.Add(this.chkboxCh0);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.txtReadCount);
            this.Controls.Add(this.txtModule);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Adam6217 Sample Program (C#)";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtModule;
        private System.Windows.Forms.TextBox txtReadCount;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.CheckBox chkboxCh0;
        private System.Windows.Forms.CheckBox chkboxCh1;
        private System.Windows.Forms.CheckBox chkboxCh2;
        private System.Windows.Forms.CheckBox chkboxCh3;
        private System.Windows.Forms.CheckBox chkboxCh4;
        private System.Windows.Forms.CheckBox chkboxCh5;
        private System.Windows.Forms.CheckBox chkboxCh6;
        private System.Windows.Forms.CheckBox chkboxCh7;
        private System.Windows.Forms.TextBox txtAIValue0;
        private System.Windows.Forms.TextBox txtAIValue1;
        private System.Windows.Forms.TextBox txtAIValue2;
        private System.Windows.Forms.TextBox txtAIValue3;
        private System.Windows.Forms.TextBox txtAIValue4;
        private System.Windows.Forms.TextBox txtAIValue5;
        private System.Windows.Forms.TextBox txtAIValue6;
        private System.Windows.Forms.TextBox txtAIValue7;
        private System.Windows.Forms.Timer timer1;
    }
}

