namespace WISE_4000_REST
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
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAcount = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtJSON = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBoxUrl1 = new System.Windows.Forms.ComboBox();
            this.comboBoxUrl2 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ColumnChannel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSlaveId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSlaveAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMappingAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP address:";
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Location = new System.Drawing.Point(97, 15);
            this.txtIPAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(132, 25);
            this.txtIPAddress.TabIndex = 1;
            this.txtIPAddress.Text = "10.0.0.1";
            this.txtIPAddress.TextChanged += new System.EventHandler(this.txtIPAddress_textChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "URL:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(239, 19);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(11, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "/";
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(97, 50);
            this.txtURL.Margin = new System.Windows.Forms.Padding(4);
            this.txtURL.Name = "txtURL";
            this.txtURL.ReadOnly = true;
            this.txtURL.Size = new System.Drawing.Size(592, 25);
            this.txtURL.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 89);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Account:";
            // 
            // txtAcount
            // 
            this.txtAcount.Location = new System.Drawing.Point(97, 85);
            this.txtAcount.Margin = new System.Windows.Forms.Padding(4);
            this.txtAcount.Name = "txtAcount";
            this.txtAcount.Size = new System.Drawing.Size(132, 25);
            this.txtAcount.TabIndex = 9;
            this.txtAcount.Text = "root";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(97, 120);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(132, 25);
            this.txtPassword.TabIndex = 10;
            this.txtPassword.Text = "00000000";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 124);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "Password:";
            // 
            // txtJSON
            // 
            this.txtJSON.AcceptsReturn = true;
            this.txtJSON.Location = new System.Drawing.Point(96, 248);
            this.txtJSON.Margin = new System.Windows.Forms.Padding(4);
            this.txtJSON.Multiline = true;
            this.txtJSON.Name = "txtJSON";
            this.txtJSON.ReadOnly = true;
            this.txtJSON.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtJSON.Size = new System.Drawing.Size(592, 44);
            this.txtJSON.TabIndex = 12;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(97, 196);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(593, 29);
            this.btnSend.TabIndex = 13;
            this.btnSend.Text = "Send HTTP reqeust";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 251);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "JSON data:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 159);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 15);
            this.label8.TabIndex = 15;
            this.label8.Text = "Method:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "GET"});
            this.comboBox1.Location = new System.Drawing.Point(97, 155);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(160, 23);
            this.comboBox1.TabIndex = 16;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBoxUrl1
            // 
            this.comboBoxUrl1.FormattingEnabled = true;
            this.comboBoxUrl1.Items.AddRange(new object[] {
            "expansion_bit",
            "expansion_word"});
            this.comboBoxUrl1.Location = new System.Drawing.Point(255, 15);
            this.comboBoxUrl1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxUrl1.Name = "comboBoxUrl1";
            this.comboBoxUrl1.Size = new System.Drawing.Size(160, 23);
            this.comboBoxUrl1.TabIndex = 2;
            this.comboBoxUrl1.SelectedIndexChanged += new System.EventHandler(this.comboBoxUrl1_SelectedIndexChanged);
            // 
            // comboBoxUrl2
            // 
            this.comboBoxUrl2.FormattingEnabled = true;
            this.comboBoxUrl2.Items.AddRange(new object[] {
            "com_1"});
            this.comboBoxUrl2.Location = new System.Drawing.Point(444, 15);
            this.comboBoxUrl2.Margin = new System.Windows.Forms.Padding(4);
            this.comboBoxUrl2.Name = "comboBoxUrl2";
            this.comboBoxUrl2.Size = new System.Drawing.Size(127, 23);
            this.comboBoxUrl2.TabIndex = 3;
            this.comboBoxUrl2.SelectedIndexChanged += new System.EventHandler(this.comboBoxUrl2_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(426, 18);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(11, 15);
            this.label9.TabIndex = 19;
            this.label9.Text = "/";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnChannel,
            this.ColumnValue,
            this.ColumnStatus,
            this.ColumnSlaveId,
            this.ColumnSlaveAddress,
            this.ColumnMappingAddress});
            this.dataGridView1.Location = new System.Drawing.Point(96, 299);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(631, 257);
            this.dataGridView1.TabIndex = 20;
            // 
            // ColumnChannel
            // 
            this.ColumnChannel.HeaderText = "Channel";
            this.ColumnChannel.Name = "ColumnChannel";
            this.ColumnChannel.ReadOnly = true;
            this.ColumnChannel.Width = 80;
            // 
            // ColumnValue
            // 
            this.ColumnValue.HeaderText = "Value";
            this.ColumnValue.Name = "ColumnValue";
            this.ColumnValue.ReadOnly = true;
            // 
            // ColumnStatus
            // 
            this.ColumnStatus.HeaderText = "Status";
            this.ColumnStatus.Name = "ColumnStatus";
            this.ColumnStatus.ReadOnly = true;
            // 
            // ColumnSlaveId
            // 
            this.ColumnSlaveId.HeaderText = "Slave ID";
            this.ColumnSlaveId.Name = "ColumnSlaveId";
            this.ColumnSlaveId.ReadOnly = true;
            this.ColumnSlaveId.Width = 80;
            // 
            // ColumnSlaveAddress
            // 
            this.ColumnSlaveAddress.HeaderText = "Slave Address";
            this.ColumnSlaveAddress.Name = "ColumnSlaveAddress";
            this.ColumnSlaveAddress.ReadOnly = true;
            // 
            // ColumnMappingAddress
            // 
            this.ColumnMappingAddress.HeaderText = "Mapping Address";
            this.ColumnMappingAddress.Name = "ColumnMappingAddress";
            this.ColumnMappingAddress.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 582);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboBoxUrl2);
            this.Controls.Add(this.comboBoxUrl1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtJSON);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtAcount);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIPAddress);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "WISE-40XX COM sample";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAcount;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtJSON;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBoxUrl1;
        private System.Windows.Forms.ComboBox comboBoxUrl2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnChannel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSlaveId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSlaveAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMappingAddress;
    }
}

