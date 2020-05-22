namespace Adam4017_18
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
            this.txtModule = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // txtReadCount
            // 
            this.txtReadCount.Location = new System.Drawing.Point(101, 40);
            this.txtReadCount.Name = "txtReadCount";
            this.txtReadCount.ReadOnly = true;
            this.txtReadCount.Size = new System.Drawing.Size(150, 22);
            this.txtReadCount.TabIndex = 9;
            this.txtReadCount.Text = "0";
            // 
            // txtModule
            // 
            this.txtModule.Location = new System.Drawing.Point(101, 6);
            this.txtModule.Name = "txtModule";
            this.txtModule.Size = new System.Drawing.Size(150, 22);
            this.txtModule.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "Read count:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "Module name:";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(273, 6);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 10;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // chkboxCh0
            // 
            this.chkboxCh0.AutoSize = true;
            this.chkboxCh0.Enabled = false;
            this.chkboxCh0.Location = new System.Drawing.Point(14, 98);
            this.chkboxCh0.Name = "chkboxCh0";
            this.chkboxCh0.Size = new System.Drawing.Size(77, 16);
            this.chkboxCh0.TabIndex = 11;
            this.chkboxCh0.Text = "AI-0 value:";
            this.chkboxCh0.UseVisualStyleBackColor = true;
            // 
            // chkboxCh1
            // 
            this.chkboxCh1.AutoSize = true;
            this.chkboxCh1.Enabled = false;
            this.chkboxCh1.Location = new System.Drawing.Point(14, 134);
            this.chkboxCh1.Name = "chkboxCh1";
            this.chkboxCh1.Size = new System.Drawing.Size(77, 16);
            this.chkboxCh1.TabIndex = 12;
            this.chkboxCh1.Text = "AI-1 value:";
            this.chkboxCh1.UseVisualStyleBackColor = true;
            // 
            // chkboxCh2
            // 
            this.chkboxCh2.AutoSize = true;
            this.chkboxCh2.Enabled = false;
            this.chkboxCh2.Location = new System.Drawing.Point(14, 167);
            this.chkboxCh2.Name = "chkboxCh2";
            this.chkboxCh2.Size = new System.Drawing.Size(77, 16);
            this.chkboxCh2.TabIndex = 13;
            this.chkboxCh2.Text = "AI-2 value:";
            this.chkboxCh2.UseVisualStyleBackColor = true;
            // 
            // chkboxCh3
            // 
            this.chkboxCh3.AutoSize = true;
            this.chkboxCh3.Enabled = false;
            this.chkboxCh3.Location = new System.Drawing.Point(14, 202);
            this.chkboxCh3.Name = "chkboxCh3";
            this.chkboxCh3.Size = new System.Drawing.Size(77, 16);
            this.chkboxCh3.TabIndex = 14;
            this.chkboxCh3.Text = "AI-3 value:";
            this.chkboxCh3.UseVisualStyleBackColor = true;
            // 
            // chkboxCh4
            // 
            this.chkboxCh4.AutoSize = true;
            this.chkboxCh4.Enabled = false;
            this.chkboxCh4.Location = new System.Drawing.Point(14, 237);
            this.chkboxCh4.Name = "chkboxCh4";
            this.chkboxCh4.Size = new System.Drawing.Size(77, 16);
            this.chkboxCh4.TabIndex = 15;
            this.chkboxCh4.Text = "AI-4 value:";
            this.chkboxCh4.UseVisualStyleBackColor = true;
            // 
            // chkboxCh5
            // 
            this.chkboxCh5.AutoSize = true;
            this.chkboxCh5.Enabled = false;
            this.chkboxCh5.Location = new System.Drawing.Point(14, 273);
            this.chkboxCh5.Name = "chkboxCh5";
            this.chkboxCh5.Size = new System.Drawing.Size(77, 16);
            this.chkboxCh5.TabIndex = 16;
            this.chkboxCh5.Text = "AI-5 value:";
            this.chkboxCh5.UseVisualStyleBackColor = true;
            // 
            // chkboxCh6
            // 
            this.chkboxCh6.AutoSize = true;
            this.chkboxCh6.Enabled = false;
            this.chkboxCh6.Location = new System.Drawing.Point(14, 310);
            this.chkboxCh6.Name = "chkboxCh6";
            this.chkboxCh6.Size = new System.Drawing.Size(77, 16);
            this.chkboxCh6.TabIndex = 17;
            this.chkboxCh6.Text = "AI-6 value:";
            this.chkboxCh6.UseVisualStyleBackColor = true;
            // 
            // chkboxCh7
            // 
            this.chkboxCh7.AutoSize = true;
            this.chkboxCh7.Enabled = false;
            this.chkboxCh7.Location = new System.Drawing.Point(14, 345);
            this.chkboxCh7.Name = "chkboxCh7";
            this.chkboxCh7.Size = new System.Drawing.Size(77, 16);
            this.chkboxCh7.TabIndex = 18;
            this.chkboxCh7.Text = "AI-7 value:";
            this.chkboxCh7.UseVisualStyleBackColor = true;
            // 
            // txtAIValue0
            // 
            this.txtAIValue0.Location = new System.Drawing.Point(101, 96);
            this.txtAIValue0.Name = "txtAIValue0";
            this.txtAIValue0.ReadOnly = true;
            this.txtAIValue0.Size = new System.Drawing.Size(150, 22);
            this.txtAIValue0.TabIndex = 19;
            // 
            // txtAIValue1
            // 
            this.txtAIValue1.Location = new System.Drawing.Point(101, 132);
            this.txtAIValue1.Name = "txtAIValue1";
            this.txtAIValue1.ReadOnly = true;
            this.txtAIValue1.Size = new System.Drawing.Size(150, 22);
            this.txtAIValue1.TabIndex = 20;
            // 
            // txtAIValue2
            // 
            this.txtAIValue2.Location = new System.Drawing.Point(101, 165);
            this.txtAIValue2.Name = "txtAIValue2";
            this.txtAIValue2.ReadOnly = true;
            this.txtAIValue2.Size = new System.Drawing.Size(150, 22);
            this.txtAIValue2.TabIndex = 21;
            // 
            // txtAIValue3
            // 
            this.txtAIValue3.Location = new System.Drawing.Point(101, 200);
            this.txtAIValue3.Name = "txtAIValue3";
            this.txtAIValue3.ReadOnly = true;
            this.txtAIValue3.Size = new System.Drawing.Size(150, 22);
            this.txtAIValue3.TabIndex = 22;
            // 
            // txtAIValue4
            // 
            this.txtAIValue4.Location = new System.Drawing.Point(101, 235);
            this.txtAIValue4.Name = "txtAIValue4";
            this.txtAIValue4.ReadOnly = true;
            this.txtAIValue4.Size = new System.Drawing.Size(150, 22);
            this.txtAIValue4.TabIndex = 23;
            // 
            // txtAIValue5
            // 
            this.txtAIValue5.Location = new System.Drawing.Point(101, 271);
            this.txtAIValue5.Name = "txtAIValue5";
            this.txtAIValue5.ReadOnly = true;
            this.txtAIValue5.Size = new System.Drawing.Size(150, 22);
            this.txtAIValue5.TabIndex = 24;
            // 
            // txtAIValue6
            // 
            this.txtAIValue6.Location = new System.Drawing.Point(101, 308);
            this.txtAIValue6.Name = "txtAIValue6";
            this.txtAIValue6.ReadOnly = true;
            this.txtAIValue6.Size = new System.Drawing.Size(150, 22);
            this.txtAIValue6.TabIndex = 25;
            // 
            // txtAIValue7
            // 
            this.txtAIValue7.Location = new System.Drawing.Point(101, 343);
            this.txtAIValue7.Name = "txtAIValue7";
            this.txtAIValue7.ReadOnly = true;
            this.txtAIValue7.Size = new System.Drawing.Size(150, 22);
            this.txtAIValue7.TabIndex = 26;
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
            this.ClientSize = new System.Drawing.Size(355, 379);
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
            this.Name = "Form1";
            this.Text = "Adam4017_18 sample program (C#)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtReadCount;
        private System.Windows.Forms.TextBox txtModule;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
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

