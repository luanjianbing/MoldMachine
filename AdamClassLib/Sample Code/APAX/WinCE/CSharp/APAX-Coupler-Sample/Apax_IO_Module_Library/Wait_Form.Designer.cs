namespace Apax_IO_Module_Library
{
    partial class Wait_Form
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lbl_Wait = new System.Windows.Forms.Label();
            this.Timer1 = new System.Windows.Forms.Timer();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(26, 50);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(360, 23);
            this.progressBar1.ParentChanged += new System.EventHandler(this.progressBar1_ParentChanged);
            // 
            // lbl_Wait
            // 
            this.lbl_Wait.Location = new System.Drawing.Point(26, 27);
            this.lbl_Wait.Name = "lbl_Wait";
            this.lbl_Wait.Size = new System.Drawing.Size(152, 20);
            this.lbl_Wait.Text = "Please waiting";
            // 
            // Timer1
            // 
            this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick_1);
            // 
            // Wait_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(414, 103);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lbl_Wait);
            this.Name = "Wait_Form";
            this.Text = "Wait_Form";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar1;
        internal System.Windows.Forms.Label lbl_Wait;
        private System.Windows.Forms.Timer Timer1;
    }
}