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
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxHistory = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFuncCode = new System.Windows.Forms.TextBox();
            this.txtRecvNum = new System.Windows.Forms.TextBox();
            this.labFuncCode = new System.Windows.Forms.Label();
            this.labRecvNum = new System.Windows.Forms.Label();
            this.listViewInfo = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(462, 9);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 10;
            this.btnStart.Text = "Start";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(53, 9);
            this.txtPort.Name = "txtPort";
            this.txtPort.ReadOnly = true;
            this.txtPort.Size = new System.Drawing.Size(50, 23);
            this.txtPort.TabIndex = 9;
            // 
            // labPort
            // 
            this.labPort.Location = new System.Drawing.Point(8, 13);
            this.labPort.Name = "labPort";
            this.labPort.Size = new System.Drawing.Size(39, 19);
            this.labPort.Text = "Port:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 20);
            this.label1.Text = "History Message : ";
            // 
            // listBoxHistory
            // 
            this.listBoxHistory.Location = new System.Drawing.Point(8, 79);
            this.listBoxHistory.Name = "listBoxHistory";
            this.listBoxHistory.Size = new System.Drawing.Size(273, 354);
            this.listBoxHistory.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(296, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(142, 20);
            this.label2.Text = "Current Information : ";
            // 
            // txtFuncCode
            // 
            this.txtFuncCode.Location = new System.Drawing.Point(425, 111);
            this.txtFuncCode.Name = "txtFuncCode";
            this.txtFuncCode.ReadOnly = true;
            this.txtFuncCode.Size = new System.Drawing.Size(112, 23);
            this.txtFuncCode.TabIndex = 19;
            // 
            // txtRecvNum
            // 
            this.txtRecvNum.Location = new System.Drawing.Point(425, 82);
            this.txtRecvNum.Name = "txtRecvNum";
            this.txtRecvNum.ReadOnly = true;
            this.txtRecvNum.Size = new System.Drawing.Size(112, 23);
            this.txtRecvNum.TabIndex = 18;
            // 
            // labFuncCode
            // 
            this.labFuncCode.Location = new System.Drawing.Point(296, 114);
            this.labFuncCode.Name = "labFuncCode";
            this.labFuncCode.Size = new System.Drawing.Size(100, 20);
            this.labFuncCode.Text = "Function Code";
            // 
            // labRecvNum
            // 
            this.labRecvNum.Location = new System.Drawing.Point(296, 85);
            this.labRecvNum.Name = "labRecvNum";
            this.labRecvNum.Size = new System.Drawing.Size(90, 20);
            this.labRecvNum.Text = "Receive Num";
            // 
            // listViewInfo
            // 
            this.listViewInfo.Columns.Add(this.columnHeader1);
            this.listViewInfo.Columns.Add(this.columnHeader2);
            this.listViewInfo.Columns.Add(this.columnHeader3);
            this.listViewInfo.Location = new System.Drawing.Point(295, 142);
            this.listViewInfo.Name = "listViewInfo";
            this.listViewInfo.Size = new System.Drawing.Size(242, 291);
            this.listViewInfo.TabIndex = 22;
            this.listViewInfo.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Channel";
            this.columnHeader1.Width = 58;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value";
            this.columnHeader2.Width = 44;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "C.O.S. Flag";
            this.columnHeader3.Width = 82;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(547, 441);
            this.Controls.Add(this.listViewInfo);
            this.Controls.Add(this.txtFuncCode);
            this.Controls.Add(this.txtRecvNum);
            this.Controls.Add(this.labFuncCode);
            this.Controls.Add(this.labRecvNum);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBoxHistory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.labPort);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Peer to Peer Event (C#)";
            this.Closed += new System.EventHandler(this.Form1_Closed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label labPort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxHistory;
        private System.Windows.Forms.Label label2;
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

