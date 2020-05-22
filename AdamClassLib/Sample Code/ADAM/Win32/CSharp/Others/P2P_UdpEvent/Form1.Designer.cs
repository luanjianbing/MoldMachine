namespace P2P_UdpEvent
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
            this.btnStart = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.labPort = new System.Windows.Forms.Label();
            this.listBoxHistory = new System.Windows.Forms.ListBox();
            this.gbxHistory = new System.Windows.Forms.GroupBox();
            this.gbxCurrentInfo = new System.Windows.Forms.GroupBox();
            this.listViewInfo = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.txtFuncCode = new System.Windows.Forms.TextBox();
            this.txtRecvNum = new System.Windows.Forms.TextBox();
            this.labFuncCode = new System.Windows.Forms.Label();
            this.labRecvNum = new System.Windows.Forms.Label();
            this.gbxHistory.SuspendLayout();
            this.gbxCurrentInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(464, 6);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 7;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(39, 6);
            this.txtPort.Name = "txtPort";
            this.txtPort.ReadOnly = true;
            this.txtPort.Size = new System.Drawing.Size(50, 22);
            this.txtPort.TabIndex = 6;
            // 
            // labPort
            // 
            this.labPort.AutoSize = true;
            this.labPort.Location = new System.Drawing.Point(6, 9);
            this.labPort.Name = "labPort";
            this.labPort.Size = new System.Drawing.Size(27, 12);
            this.labPort.TabIndex = 5;
            this.labPort.Text = "Port:";
            // 
            // listBoxHistory
            // 
            this.listBoxHistory.FormattingEnabled = true;
            this.listBoxHistory.ItemHeight = 12;
            this.listBoxHistory.Location = new System.Drawing.Point(6, 12);
            this.listBoxHistory.Name = "listBoxHistory";
            this.listBoxHistory.Size = new System.Drawing.Size(273, 364);
            this.listBoxHistory.TabIndex = 0;
            // 
            // gbxHistory
            // 
            this.gbxHistory.Controls.Add(this.listBoxHistory);
            this.gbxHistory.Location = new System.Drawing.Point(2, 46);
            this.gbxHistory.Name = "gbxHistory";
            this.gbxHistory.Size = new System.Drawing.Size(285, 381);
            this.gbxHistory.TabIndex = 8;
            this.gbxHistory.TabStop = false;
            this.gbxHistory.Text = "History Message";
            // 
            // gbxCurrentInfo
            // 
            this.gbxCurrentInfo.Controls.Add(this.listViewInfo);
            this.gbxCurrentInfo.Controls.Add(this.txtFuncCode);
            this.gbxCurrentInfo.Controls.Add(this.txtRecvNum);
            this.gbxCurrentInfo.Controls.Add(this.labFuncCode);
            this.gbxCurrentInfo.Controls.Add(this.labRecvNum);
            this.gbxCurrentInfo.Location = new System.Drawing.Point(293, 46);
            this.gbxCurrentInfo.Name = "gbxCurrentInfo";
            this.gbxCurrentInfo.Size = new System.Drawing.Size(246, 381);
            this.gbxCurrentInfo.TabIndex = 9;
            this.gbxCurrentInfo.TabStop = false;
            this.gbxCurrentInfo.Text = "Current Information";
            // 
            // listViewInfo
            // 
            this.listViewInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewInfo.Location = new System.Drawing.Point(8, 71);
            this.listViewInfo.Name = "listViewInfo";
            this.listViewInfo.Size = new System.Drawing.Size(232, 304);
            this.listViewInfo.TabIndex = 4;
            this.listViewInfo.UseCompatibleStateImageBehavior = false;
            this.listViewInfo.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Channel";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "C.O.S. Flag";
            this.columnHeader3.Width = 82;
            // 
            // txtFuncCode
            // 
            this.txtFuncCode.Location = new System.Drawing.Point(89, 43);
            this.txtFuncCode.Name = "txtFuncCode";
            this.txtFuncCode.ReadOnly = true;
            this.txtFuncCode.Size = new System.Drawing.Size(100, 22);
            this.txtFuncCode.TabIndex = 3;
            // 
            // txtRecvNum
            // 
            this.txtRecvNum.Location = new System.Drawing.Point(89, 15);
            this.txtRecvNum.Name = "txtRecvNum";
            this.txtRecvNum.ReadOnly = true;
            this.txtRecvNum.Size = new System.Drawing.Size(100, 22);
            this.txtRecvNum.TabIndex = 2;
            // 
            // labFuncCode
            // 
            this.labFuncCode.AutoSize = true;
            this.labFuncCode.Location = new System.Drawing.Point(6, 46);
            this.labFuncCode.Name = "labFuncCode";
            this.labFuncCode.Size = new System.Drawing.Size(74, 12);
            this.labFuncCode.TabIndex = 1;
            this.labFuncCode.Text = "Function Code";
            // 
            // labRecvNum
            // 
            this.labRecvNum.AutoSize = true;
            this.labRecvNum.Location = new System.Drawing.Point(6, 18);
            this.labRecvNum.Name = "labRecvNum";
            this.labRecvNum.Size = new System.Drawing.Size(68, 12);
            this.labRecvNum.TabIndex = 0;
            this.labRecvNum.Text = "Receive Num";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 430);
            this.Controls.Add(this.gbxCurrentInfo);
            this.Controls.Add(this.gbxHistory);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.labPort);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Peer to Peer Event (C#)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.gbxHistory.ResumeLayout(false);
            this.gbxCurrentInfo.ResumeLayout(false);
            this.gbxCurrentInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label labPort;
        private System.Windows.Forms.ListBox listBoxHistory;
        private System.Windows.Forms.GroupBox gbxHistory;
        private System.Windows.Forms.GroupBox gbxCurrentInfo;
        private System.Windows.Forms.TextBox txtFuncCode;
        private System.Windows.Forms.TextBox txtRecvNum;
        private System.Windows.Forms.Label labFuncCode;
        private System.Windows.Forms.Label labRecvNum;
        private System.Windows.Forms.ListView listViewInfo;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
    }
}

