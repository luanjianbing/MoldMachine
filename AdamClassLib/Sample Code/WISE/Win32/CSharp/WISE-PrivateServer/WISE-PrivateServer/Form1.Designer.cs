namespace WISE_PrivateServer
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.clmTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRemoteEndPoint = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmReqHttpScheme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmReqHttpMethod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmFormat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmRequestUrl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.reviewDataRichTbx = new System.Windows.Forms.RichTextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmTime,
            this.clmRemoteEndPoint,
            this.clmReqHttpScheme,
            this.clmReqHttpMethod,
            this.clmFormat,
            this.clmRequestUrl});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(4, 22);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(891, 322);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // clmTime
            // 
            this.clmTime.FillWeight = 110F;
            this.clmTime.HeaderText = "Time";
            this.clmTime.Name = "clmTime";
            this.clmTime.ReadOnly = true;
            this.clmTime.Width = 140;
            // 
            // clmRemoteEndPoint
            // 
            this.clmRemoteEndPoint.FillWeight = 115F;
            this.clmRemoteEndPoint.HeaderText = "Remote End Point";
            this.clmRemoteEndPoint.Name = "clmRemoteEndPoint";
            this.clmRemoteEndPoint.ReadOnly = true;
            this.clmRemoteEndPoint.Width = 160;
            // 
            // clmReqHttpScheme
            // 
            this.clmReqHttpScheme.FillWeight = 50F;
            this.clmReqHttpScheme.HeaderText = "Scheme";
            this.clmReqHttpScheme.Name = "clmReqHttpScheme";
            this.clmReqHttpScheme.ReadOnly = true;
            this.clmReqHttpScheme.Width = 50;
            // 
            // clmReqHttpMethod
            // 
            this.clmReqHttpMethod.FillWeight = 95F;
            this.clmReqHttpMethod.HeaderText = "HTTP Method";
            this.clmReqHttpMethod.Name = "clmReqHttpMethod";
            this.clmReqHttpMethod.ReadOnly = true;
            this.clmReqHttpMethod.Width = 95;
            // 
            // clmFormat
            // 
            this.clmFormat.FillWeight = 85F;
            this.clmFormat.HeaderText = "Data Format";
            this.clmFormat.Name = "clmFormat";
            this.clmFormat.ReadOnly = true;
            this.clmFormat.Width = 85;
            // 
            // clmRequestUrl
            // 
            this.clmRequestUrl.FillWeight = 272F;
            this.clmRequestUrl.HeaderText = "Client URL";
            this.clmRequestUrl.Name = "clmRequestUrl";
            this.clmRequestUrl.ReadOnly = true;
            this.clmRequestUrl.Width = 290;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(907, 550);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(899, 348);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Private Server for Handling POST Requests";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.reviewDataRichTbx);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(4, 360);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(899, 184);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Review incoming data";
            // 
            // reviewDataRichTbx
            // 
            this.reviewDataRichTbx.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reviewDataRichTbx.Location = new System.Drawing.Point(4, 22);
            this.reviewDataRichTbx.Margin = new System.Windows.Forms.Padding(4);
            this.reviewDataRichTbx.Name = "reviewDataRichTbx";
            this.reviewDataRichTbx.Size = new System.Drawing.Size(891, 158);
            this.reviewDataRichTbx.TabIndex = 0;
            this.reviewDataRichTbx.Text = "";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(4, 552);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(899, 1);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 550);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "WISE-Private Server v2.02";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RichTextBox reviewDataRichTbx;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRemoteEndPoint;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmReqHttpScheme;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmReqHttpMethod;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFormat;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmRequestUrl;
    }
}

