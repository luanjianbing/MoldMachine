namespace GCL_IO_Message
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
            this.txtPort = new System.Windows.Forms.TextBox();
            this.gbxHistory = new System.Windows.Forms.GroupBox();
            this.listBoxMsg = new System.Windows.Forms.ListBox();
            this.gbxDataInfo = new System.Windows.Forms.GroupBox();
            this.gbxIOData = new System.Windows.Forms.GroupBox();
            this.txtIOData = new System.Windows.Forms.TextBox();
            this.gbxMsg = new System.Windows.Forms.GroupBox();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.gbxHistory.SuspendLayout();
            this.gbxDataInfo.SuspendLayout();
            this.gbxIOData.SuspendLayout();
            this.gbxMsg.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port:";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(37, 6);
            this.txtPort.Name = "txtPort";
            this.txtPort.ReadOnly = true;
            this.txtPort.Size = new System.Drawing.Size(50, 22);
            this.txtPort.TabIndex = 1;
            this.txtPort.Text = "5168";
            // 
            // gbxHistory
            // 
            this.gbxHistory.Controls.Add(this.listBoxMsg);
            this.gbxHistory.Location = new System.Drawing.Point(4, 34);
            this.gbxHistory.Name = "gbxHistory";
            this.gbxHistory.Size = new System.Drawing.Size(457, 381);
            this.gbxHistory.TabIndex = 2;
            this.gbxHistory.TabStop = false;
            this.gbxHistory.Text = "History Message";
            // 
            // listBoxMsg
            // 
            this.listBoxMsg.FormattingEnabled = true;
            this.listBoxMsg.HorizontalScrollbar = true;
            this.listBoxMsg.ItemHeight = 12;
            this.listBoxMsg.Location = new System.Drawing.Point(6, 12);
            this.listBoxMsg.Name = "listBoxMsg";
            this.listBoxMsg.Size = new System.Drawing.Size(445, 364);
            this.listBoxMsg.TabIndex = 0;
            // 
            // gbxDataInfo
            // 
            this.gbxDataInfo.Controls.Add(this.gbxIOData);
            this.gbxDataInfo.Controls.Add(this.gbxMsg);
            this.gbxDataInfo.Location = new System.Drawing.Point(467, 34);
            this.gbxDataInfo.Name = "gbxDataInfo";
            this.gbxDataInfo.Size = new System.Drawing.Size(317, 381);
            this.gbxDataInfo.TabIndex = 3;
            this.gbxDataInfo.TabStop = false;
            this.gbxDataInfo.Text = "Data Information";
            // 
            // gbxIOData
            // 
            this.gbxIOData.Controls.Add(this.txtIOData);
            this.gbxIOData.Location = new System.Drawing.Point(6, 12);
            this.gbxIOData.Name = "gbxIOData";
            this.gbxIOData.Size = new System.Drawing.Size(305, 215);
            this.gbxIOData.TabIndex = 6;
            this.gbxIOData.TabStop = false;
            this.gbxIOData.Text = "IO Data";
            // 
            // txtIOData
            // 
            this.txtIOData.Location = new System.Drawing.Point(6, 15);
            this.txtIOData.Multiline = true;
            this.txtIOData.Name = "txtIOData";
            this.txtIOData.ReadOnly = true;
            this.txtIOData.Size = new System.Drawing.Size(293, 194);
            this.txtIOData.TabIndex = 0;
            // 
            // gbxMsg
            // 
            this.gbxMsg.Controls.Add(this.txtMsg);
            this.gbxMsg.Location = new System.Drawing.Point(6, 233);
            this.gbxMsg.Name = "gbxMsg";
            this.gbxMsg.Size = new System.Drawing.Size(305, 142);
            this.gbxMsg.TabIndex = 5;
            this.gbxMsg.TabStop = false;
            this.gbxMsg.Text = "Message";
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(6, 15);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.ReadOnly = true;
            this.txtMsg.Size = new System.Drawing.Size(293, 121);
            this.txtMsg.TabIndex = 0;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(709, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 424);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.gbxDataInfo);
            this.Controls.Add(this.gbxHistory);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "GCL IO data and message stream sample (VC#)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.gbxHistory.ResumeLayout(false);
            this.gbxDataInfo.ResumeLayout(false);
            this.gbxIOData.ResumeLayout(false);
            this.gbxIOData.PerformLayout();
            this.gbxMsg.ResumeLayout(false);
            this.gbxMsg.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.GroupBox gbxHistory;
        private System.Windows.Forms.ListBox listBoxMsg;
        private System.Windows.Forms.GroupBox gbxDataInfo;
        private System.Windows.Forms.GroupBox gbxIOData;
        private System.Windows.Forms.TextBox txtIOData;
        private System.Windows.Forms.GroupBox gbxMsg;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtMsg;
    }
}

