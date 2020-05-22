namespace ModbusRTU
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
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.listViewModbusCur = new System.Windows.Forms.ListView();
            this.columnHeaderLocation = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderType = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderValDec = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderValHex = new System.Windows.Forms.ColumnHeader();
            this.buttonStart = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(12, 12);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(319, 22);
            this.txtStatus.TabIndex = 0;
            // 
            // listViewModbusCur
            // 
            this.listViewModbusCur.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderLocation,
            this.columnHeaderType,
            this.columnHeaderValDec,
            this.columnHeaderValHex});
            this.listViewModbusCur.Location = new System.Drawing.Point(12, 40);
            this.listViewModbusCur.Name = "listViewModbusCur";
            this.listViewModbusCur.Size = new System.Drawing.Size(319, 314);
            this.listViewModbusCur.TabIndex = 1;
            this.listViewModbusCur.UseCompatibleStateImageBehavior = false;
            this.listViewModbusCur.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderLocation
            // 
            this.columnHeaderLocation.Text = "Location";
            this.columnHeaderLocation.Width = 64;
            // 
            // columnHeaderType
            // 
            this.columnHeaderType.Text = "Type";
            // 
            // columnHeaderValDec
            // 
            this.columnHeaderValDec.Text = "Value[Dec]";
            this.columnHeaderValDec.Width = 81;
            // 
            // columnHeaderValHex
            // 
            this.columnHeaderValHex.Text = "Value[Hex]";
            this.columnHeaderValHex.Width = 89;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(337, 10);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 363);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.listViewModbusCur);
            this.Controls.Add(this.txtStatus);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "ModbusRTU sample program (C#)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.ListView listViewModbusCur;
        private System.Windows.Forms.ColumnHeader columnHeaderLocation;
        private System.Windows.Forms.ColumnHeader columnHeaderType;
        private System.Windows.Forms.ColumnHeader columnHeaderValDec;
        private System.Windows.Forms.ColumnHeader columnHeaderValHex;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Timer timer1;
    }
}

