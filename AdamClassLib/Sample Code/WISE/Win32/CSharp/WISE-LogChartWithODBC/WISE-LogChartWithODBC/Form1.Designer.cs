namespace WISE_ColudDataCollect
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
            this.Start = new System.Windows.Forms.Button();
            this.listData = new System.Windows.Forms.ListView();
            this.DeviceName = new System.Windows.Forms.ColumnHeader();
            this.Data = new System.Windows.Forms.ColumnHeader();
            this.Total = new System.Windows.Forms.ColumnHeader();
            this.Date = new System.Windows.Forms.ColumnHeader();
            this.Display = new System.Windows.Forms.Button();
            this.DirPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Period = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TimeRange = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DBMode = new System.Windows.Forms.ComboBox();
            this.SQLiteTitle = new System.Windows.Forms.Label();
            this.SQLiteDB = new System.Windows.Forms.TextBox();
            this.PWD = new System.Windows.Forms.TextBox();
            this.UID = new System.Windows.Forms.TextBox();
            this.PWDTitle = new System.Windows.Forms.Label();
            this.UIDTitle = new System.Windows.Forms.Label();
            this.DBName = new System.Windows.Forms.TextBox();
            this.DBTitle = new System.Windows.Forms.Label();
            this.ServerName = new System.Windows.Forms.TextBox();
            this.ServerTitle = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(60, 368);
            this.Start.Margin = new System.Windows.Forms.Padding(4);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(151, 42);
            this.Start.TabIndex = 0;
            this.Start.Text = "Select Log Directory and Start Parse";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // listData
            // 
            this.listData.AllowColumnReorder = true;
            this.listData.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DeviceName,
            this.Data,
            this.Total,
            this.Date});
            this.listData.ForeColor = System.Drawing.SystemColors.WindowText;
            this.listData.Location = new System.Drawing.Point(16, 25);
            this.listData.Margin = new System.Windows.Forms.Padding(4);
            this.listData.MultiSelect = false;
            this.listData.Name = "listData";
            this.listData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listData.Size = new System.Drawing.Size(556, 334);
            this.listData.TabIndex = 1;
            this.listData.UseCompatibleStateImageBehavior = false;
            this.listData.View = System.Windows.Forms.View.Details;
            // 
            // DeviceName
            // 
            this.DeviceName.Text = "Device Name";
            this.DeviceName.Width = 170;
            // 
            // Data
            // 
            this.Data.Text = "Data Type";
            this.Data.Width = 63;
            // 
            // Total
            // 
            this.Total.Text = "Total Data";
            this.Total.Width = 102;
            // 
            // Date
            // 
            this.Date.Text = "The Last Upload Time";
            this.Date.Width = 153;
            // 
            // Display
            // 
            this.Display.Location = new System.Drawing.Point(411, 368);
            this.Display.Margin = new System.Windows.Forms.Padding(4);
            this.Display.Name = "Display";
            this.Display.Size = new System.Drawing.Size(107, 42);
            this.Display.TabIndex = 2;
            this.Display.Text = "Display Chart";
            this.Display.UseVisualStyleBackColor = true;
            this.Display.Click += new System.EventHandler(this.Show_Click);
            // 
            // DirPath
            // 
            this.DirPath.Location = new System.Drawing.Point(16, 39);
            this.DirPath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DirPath.Name = "DirPath";
            this.DirPath.Size = new System.Drawing.Size(556, 25);
            this.DirPath.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 15);
            this.label3.TabIndex = 10;
            this.label3.Text = "Log location:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "Period of data parsing(ms):";
            // 
            // Period
            // 
            this.Period.Location = new System.Drawing.Point(193, 71);
            this.Period.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Period.MaxLength = 9;
            this.Period.Name = "Period";
            this.Period.Size = new System.Drawing.Size(73, 25);
            this.Period.TabIndex = 12;
            this.Period.Text = "5000";
            this.Period.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Period_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(311, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 30);
            this.label2.TabIndex = 13;
            this.label2.Text = "Range of data parsing(min):\r\n(From current time)";
            // 
            // TimeRange
            // 
            this.TimeRange.Location = new System.Drawing.Point(497, 74);
            this.TimeRange.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TimeRange.MaxLength = 9;
            this.TimeRange.Name = "TimeRange";
            this.TimeRange.Size = new System.Drawing.Size(75, 25);
            this.TimeRange.TabIndex = 14;
            this.TimeRange.Text = "1440";
            this.TimeRange.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TimeRange_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.DBMode);
            this.groupBox1.Controls.Add(this.SQLiteTitle);
            this.groupBox1.Controls.Add(this.SQLiteDB);
            this.groupBox1.Controls.Add(this.PWD);
            this.groupBox1.Controls.Add(this.UID);
            this.groupBox1.Controls.Add(this.PWDTitle);
            this.groupBox1.Controls.Add(this.UIDTitle);
            this.groupBox1.Controls.Add(this.DBName);
            this.groupBox1.Controls.Add(this.DBTitle);
            this.groupBox1.Controls.Add(this.ServerName);
            this.groupBox1.Controls.Add(this.ServerTitle);
            this.groupBox1.Controls.Add(this.TimeRange);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Period);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.DirPath);
            this.groupBox1.Location = new System.Drawing.Point(11, 434);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(592, 235);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "User Setting";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 121);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 15);
            this.label4.TabIndex = 28;
            this.label4.Text = "Database Server:";
            // 
            // DBMode
            // 
            this.DBMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DBMode.FormattingEnabled = true;
            this.DBMode.Items.AddRange(new object[] {
            "SQL Server",
            "SQLite"});
            this.DBMode.Location = new System.Drawing.Point(129, 118);
            this.DBMode.Margin = new System.Windows.Forms.Padding(4);
            this.DBMode.Name = "DBMode";
            this.DBMode.Size = new System.Drawing.Size(98, 23);
            this.DBMode.TabIndex = 27;
            this.DBMode.SelectedIndexChanged += new System.EventHandler(this.DBMode_SelectedIndexChanged);
            // 
            // SQLiteTitle
            // 
            this.SQLiteTitle.AutoSize = true;
            this.SQLiteTitle.Location = new System.Drawing.Point(252, 121);
            this.SQLiteTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SQLiteTitle.Name = "SQLiteTitle";
            this.SQLiteTitle.Size = new System.Drawing.Size(160, 15);
            this.SQLiteTitle.TabIndex = 26;
            this.SQLiteTitle.Text = "SQLite Database Location:\r";
            // 
            // SQLiteDB
            // 
            this.SQLiteDB.Location = new System.Drawing.Point(439, 118);
            this.SQLiteDB.Margin = new System.Windows.Forms.Padding(4);
            this.SQLiteDB.Name = "SQLiteDB";
            this.SQLiteDB.Size = new System.Drawing.Size(133, 25);
            this.SQLiteDB.TabIndex = 25;
            // 
            // PWD
            // 
            this.PWD.Location = new System.Drawing.Point(439, 191);
            this.PWD.Margin = new System.Windows.Forms.Padding(4);
            this.PWD.Name = "PWD";
            this.PWD.Size = new System.Drawing.Size(133, 25);
            this.PWD.TabIndex = 24;
            // 
            // UID
            // 
            this.UID.Location = new System.Drawing.Point(439, 156);
            this.UID.Margin = new System.Windows.Forms.Padding(4);
            this.UID.Name = "UID";
            this.UID.Size = new System.Drawing.Size(133, 25);
            this.UID.TabIndex = 23;
            // 
            // PWDTitle
            // 
            this.PWDTitle.AutoSize = true;
            this.PWDTitle.Location = new System.Drawing.Point(344, 195);
            this.PWDTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.PWDTitle.Name = "PWDTitle";
            this.PWDTitle.Size = new System.Drawing.Size(64, 15);
            this.PWDTitle.TabIndex = 22;
            this.PWDTitle.Text = "Password:";
            // 
            // UIDTitle
            // 
            this.UIDTitle.AutoSize = true;
            this.UIDTitle.Location = new System.Drawing.Point(344, 160);
            this.UIDTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.UIDTitle.Name = "UIDTitle";
            this.UIDTitle.Size = new System.Drawing.Size(74, 15);
            this.UIDTitle.TabIndex = 21;
            this.UIDTitle.Text = "User Name:";
            // 
            // DBName
            // 
            this.DBName.Location = new System.Drawing.Point(129, 191);
            this.DBName.Margin = new System.Windows.Forms.Padding(4);
            this.DBName.Name = "DBName";
            this.DBName.Size = new System.Drawing.Size(181, 25);
            this.DBName.TabIndex = 20;
            // 
            // DBTitle
            // 
            this.DBTitle.AutoSize = true;
            this.DBTitle.Location = new System.Drawing.Point(13, 195);
            this.DBTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DBTitle.Name = "DBTitle";
            this.DBTitle.Size = new System.Drawing.Size(98, 15);
            this.DBTitle.TabIndex = 19;
            this.DBTitle.Text = "Database Name:";
            // 
            // ServerName
            // 
            this.ServerName.Location = new System.Drawing.Point(129, 156);
            this.ServerName.Margin = new System.Windows.Forms.Padding(4);
            this.ServerName.Name = "ServerName";
            this.ServerName.Size = new System.Drawing.Size(181, 25);
            this.ServerName.TabIndex = 18;
            // 
            // ServerTitle
            // 
            this.ServerTitle.AutoSize = true;
            this.ServerTitle.Location = new System.Drawing.Point(13, 160);
            this.ServerTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ServerTitle.Name = "ServerTitle";
            this.ServerTitle.Size = new System.Drawing.Size(85, 15);
            this.ServerTitle.TabIndex = 17;
            this.ServerTitle.Text = "Server Name:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listData);
            this.groupBox2.Controls.Add(this.Start);
            this.groupBox2.Controls.Add(this.Display);
            this.groupBox2.Location = new System.Drawing.Point(11, 12);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(592, 416);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Device Information";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 678);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WISE-Log Chart With ODBC";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_Closing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.ListView listData;
        private System.Windows.Forms.Button Display;
        private System.Windows.Forms.TextBox DirPath;
        private System.Windows.Forms.ColumnHeader DeviceName;
        private System.Windows.Forms.ColumnHeader Data;
        private System.Windows.Forms.ColumnHeader Date;
        private System.Windows.Forms.ColumnHeader Total;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Period;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TimeRange;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label ServerTitle;
        private System.Windows.Forms.TextBox ServerName;
        private System.Windows.Forms.TextBox DBName;
        private System.Windows.Forms.Label DBTitle;
        private System.Windows.Forms.Label UIDTitle;
        private System.Windows.Forms.Label PWDTitle;
        private System.Windows.Forms.TextBox PWD;
        private System.Windows.Forms.TextBox UID;
        private System.Windows.Forms.TextBox SQLiteDB;
        private System.Windows.Forms.Label SQLiteTitle;
        private System.Windows.Forms.ComboBox DBMode;
        private System.Windows.Forms.Label label4;
    }
}

