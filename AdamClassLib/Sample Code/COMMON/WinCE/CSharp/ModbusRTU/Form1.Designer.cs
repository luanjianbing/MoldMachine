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
            this.buttonStart = new System.Windows.Forms.Button();
            this.listViewModbusCur = new System.Windows.Forms.ListView();
            this.columnHeaderLocation = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderType = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderValDec = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderValHex = new System.Windows.Forms.ColumnHeader();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(334, 7);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 5;
            this.buttonStart.Text = "Start";
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // listViewModbusCur
            // 
            this.listViewModbusCur.Columns.Add(this.columnHeaderLocation);
            this.listViewModbusCur.Columns.Add(this.columnHeaderType);
            this.listViewModbusCur.Columns.Add(this.columnHeaderValDec);
            this.listViewModbusCur.Columns.Add(this.columnHeaderValHex);
            this.listViewModbusCur.Location = new System.Drawing.Point(3, 35);
            this.listViewModbusCur.Name = "listViewModbusCur";
            this.listViewModbusCur.Size = new System.Drawing.Size(319, 314);
            this.listViewModbusCur.TabIndex = 4;
            this.listViewModbusCur.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderLocation
            // 
            this.columnHeaderLocation.Text = "Location";
            this.columnHeaderLocation.Width = 67;
            // 
            // columnHeaderType
            // 
            this.columnHeaderType.Text = "Type";
            this.columnHeaderType.Width = 59;
            // 
            // columnHeaderValDec
            // 
            this.columnHeaderValDec.Text = "Value[Dec]";
            this.columnHeaderValDec.Width = 86;
            // 
            // columnHeaderValHex
            // 
            this.columnHeaderValHex.Text = "Value[Hex]";
            this.columnHeaderValHex.Width = 93;
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(3, 7);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(319, 23);
            this.txtStatus.TabIndex = 3;
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
            this.ClientSize = new System.Drawing.Size(412, 355);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.listViewModbusCur);
            this.Controls.Add(this.txtStatus);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "ModbusRTU Sample Program (C#)";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.ListView listViewModbusCur;
        private System.Windows.Forms.ColumnHeader columnHeaderLocation;
        private System.Windows.Forms.ColumnHeader columnHeaderType;
        private System.Windows.Forms.ColumnHeader columnHeaderValDec;
        private System.Windows.Forms.ColumnHeader columnHeaderValHex;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Timer timer1;
    }
}

