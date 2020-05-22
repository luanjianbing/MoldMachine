using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using System.Net.Sockets;
using Advantech.Adam;
using Advantech.Common;

namespace Adam50XXDIO
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel panelDIO;
		private System.Windows.Forms.Panel panelCh5;
		private System.Windows.Forms.TextBox txtCh5;
		private System.Windows.Forms.Button btnCh5;
		private System.Windows.Forms.Panel panelCh2;
		private System.Windows.Forms.TextBox txtCh2;
		private System.Windows.Forms.Button btnCh2;
		private System.Windows.Forms.Panel panelCh3;
		private System.Windows.Forms.TextBox txtCh3;
		private System.Windows.Forms.Button btnCh3;
		private System.Windows.Forms.Panel panelCh0;
		private System.Windows.Forms.TextBox txtCh0;
		private System.Windows.Forms.Button btnCh0;
		private System.Windows.Forms.Panel panelCh6;
		private System.Windows.Forms.TextBox txtCh6;
		private System.Windows.Forms.Button btnCh6;
		private System.Windows.Forms.Panel panelCh7;
		private System.Windows.Forms.TextBox txtCh7;
		private System.Windows.Forms.Button btnCh7;
		private System.Windows.Forms.Panel panelCh1;
		private System.Windows.Forms.TextBox txtCh1;
		private System.Windows.Forms.Button btnCh1;
		private System.Windows.Forms.Panel panelCh4;
		private System.Windows.Forms.TextBox txtCh4;
		private System.Windows.Forms.Button btnCh4;
		private System.Windows.Forms.Panel panelCh12;
		private System.Windows.Forms.TextBox txtCh12;
		private System.Windows.Forms.Button btnCh12;
		private System.Windows.Forms.Panel panelCh15;
		private System.Windows.Forms.TextBox txtCh15;
		private System.Windows.Forms.Button btnCh15;
		private System.Windows.Forms.Panel panelCh8;
		private System.Windows.Forms.TextBox txtCh8;
		private System.Windows.Forms.Button btnCh8;
		private System.Windows.Forms.Panel panelCh14;
		private System.Windows.Forms.TextBox txtCh14;
		private System.Windows.Forms.Button btnCh14;
		private System.Windows.Forms.Panel panelCh9;
		private System.Windows.Forms.TextBox txtCh9;
		private System.Windows.Forms.Button btnCh9;
		private System.Windows.Forms.Panel panelCh10;
		private System.Windows.Forms.TextBox txtCh10;
		private System.Windows.Forms.Button btnCh10;
		private System.Windows.Forms.Panel panelCh11;
		private System.Windows.Forms.TextBox txtCh11;
		private System.Windows.Forms.Button btnCh11;
		private System.Windows.Forms.Panel panelCh13;
		private System.Windows.Forms.TextBox txtCh13;
		private System.Windows.Forms.Button btnCh13;
		private System.Windows.Forms.TextBox txtModule;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtReadCount;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Button buttonStart;
	
		private int m_iSlot, m_iCount, m_iChTotal;
		private bool m_bStart;
		private Adam5000Type m_Adam5000Type;
		private AdamControl adamCtl;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//

			m_iSlot = 2;	// the slot index of the module
			m_iCount = 0;	// the counting start from 0
			m_bStart = false;
			adamCtl = new AdamControl();

			//m_Adam5000Type = Adam5000Type.Adam5050; // the sample is for ADAM-5050
			//m_Adam5000Type = Adam5000Type.Adam5051; // the sample is for ADAM-5051
			//m_Adam5000Type = Adam5000Type.Adam5052; // the sample is for ADAM-5052
			//m_Adam5000Type = Adam5000Type.Adam5055; // the sample is for ADAM-5055
			m_Adam5000Type = Adam5000Type.Adam5056; // the sample is for ADAM-5056
			//m_Adam5000Type = Adam5000Type.Adam5060; // the sample is for ADAM-5060
			//m_Adam5000Type = Adam5000Type.Adam5068; // the sample is for ADAM-5068
			//m_Adam5000Type = Adam5000Type.Adam5069; // the sample is for ADAM-5069

			m_iChTotal = DigitalInput.GetChannelTotal(m_Adam5000Type)+DigitalOutput.GetChannelTotal(m_Adam5000Type);
			txtModule.Text = m_Adam5000Type.ToString();
		}
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			base.Dispose( disposing );
		}
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.panelDIO = new System.Windows.Forms.Panel();
			this.panelCh5 = new System.Windows.Forms.Panel();
			this.txtCh5 = new System.Windows.Forms.TextBox();
			this.btnCh5 = new System.Windows.Forms.Button();
			this.panelCh2 = new System.Windows.Forms.Panel();
			this.txtCh2 = new System.Windows.Forms.TextBox();
			this.btnCh2 = new System.Windows.Forms.Button();
			this.panelCh3 = new System.Windows.Forms.Panel();
			this.txtCh3 = new System.Windows.Forms.TextBox();
			this.btnCh3 = new System.Windows.Forms.Button();
			this.panelCh0 = new System.Windows.Forms.Panel();
			this.txtCh0 = new System.Windows.Forms.TextBox();
			this.btnCh0 = new System.Windows.Forms.Button();
			this.panelCh6 = new System.Windows.Forms.Panel();
			this.txtCh6 = new System.Windows.Forms.TextBox();
			this.btnCh6 = new System.Windows.Forms.Button();
			this.panelCh7 = new System.Windows.Forms.Panel();
			this.txtCh7 = new System.Windows.Forms.TextBox();
			this.btnCh7 = new System.Windows.Forms.Button();
			this.panelCh1 = new System.Windows.Forms.Panel();
			this.txtCh1 = new System.Windows.Forms.TextBox();
			this.btnCh1 = new System.Windows.Forms.Button();
			this.panelCh4 = new System.Windows.Forms.Panel();
			this.txtCh4 = new System.Windows.Forms.TextBox();
			this.btnCh4 = new System.Windows.Forms.Button();
			this.panelCh12 = new System.Windows.Forms.Panel();
			this.txtCh12 = new System.Windows.Forms.TextBox();
			this.btnCh12 = new System.Windows.Forms.Button();
			this.panelCh15 = new System.Windows.Forms.Panel();
			this.txtCh15 = new System.Windows.Forms.TextBox();
			this.btnCh15 = new System.Windows.Forms.Button();
			this.panelCh8 = new System.Windows.Forms.Panel();
			this.txtCh8 = new System.Windows.Forms.TextBox();
			this.btnCh8 = new System.Windows.Forms.Button();
			this.panelCh14 = new System.Windows.Forms.Panel();
			this.txtCh14 = new System.Windows.Forms.TextBox();
			this.btnCh14 = new System.Windows.Forms.Button();
			this.panelCh9 = new System.Windows.Forms.Panel();
			this.txtCh9 = new System.Windows.Forms.TextBox();
			this.btnCh9 = new System.Windows.Forms.Button();
			this.panelCh10 = new System.Windows.Forms.Panel();
			this.txtCh10 = new System.Windows.Forms.TextBox();
			this.btnCh10 = new System.Windows.Forms.Button();
			this.panelCh11 = new System.Windows.Forms.Panel();
			this.txtCh11 = new System.Windows.Forms.TextBox();
			this.btnCh11 = new System.Windows.Forms.Button();
			this.panelCh13 = new System.Windows.Forms.Panel();
			this.txtCh13 = new System.Windows.Forms.TextBox();
			this.btnCh13 = new System.Windows.Forms.Button();
			this.txtModule = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtReadCount = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.buttonStart = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer();
			// 
			// panelDIO
			// 
			this.panelDIO.Controls.Add(this.panelCh5);
			this.panelDIO.Controls.Add(this.panelCh2);
			this.panelDIO.Controls.Add(this.panelCh3);
			this.panelDIO.Controls.Add(this.panelCh0);
			this.panelDIO.Controls.Add(this.panelCh6);
			this.panelDIO.Controls.Add(this.panelCh7);
			this.panelDIO.Controls.Add(this.panelCh1);
			this.panelDIO.Controls.Add(this.panelCh4);
			this.panelDIO.Controls.Add(this.panelCh12);
			this.panelDIO.Controls.Add(this.panelCh15);
			this.panelDIO.Controls.Add(this.panelCh8);
			this.panelDIO.Controls.Add(this.panelCh14);
			this.panelDIO.Controls.Add(this.panelCh9);
			this.panelDIO.Controls.Add(this.panelCh10);
			this.panelDIO.Controls.Add(this.panelCh11);
			this.panelDIO.Controls.Add(this.panelCh13);
			this.panelDIO.Enabled = false;
			this.panelDIO.Location = new System.Drawing.Point(16, 80);
			this.panelDIO.Size = new System.Drawing.Size(432, 336);
			// 
			// panelCh5
			// 
			this.panelCh5.BackColor = System.Drawing.Color.SkyBlue;
			this.panelCh5.Controls.Add(this.txtCh5);
			this.panelCh5.Controls.Add(this.btnCh5);
			this.panelCh5.Location = new System.Drawing.Point(8, 208);
			this.panelCh5.Size = new System.Drawing.Size(192, 40);
			// 
			// txtCh5
			// 
			this.txtCh5.Location = new System.Drawing.Point(88, 8);
			this.txtCh5.Size = new System.Drawing.Size(64, 22);
			this.txtCh5.Text = "";
			// 
			// btnCh5
			// 
			this.btnCh5.Location = new System.Drawing.Point(8, 8);
			this.btnCh5.Size = new System.Drawing.Size(72, 24);
			this.btnCh5.Text = "DIO";
			this.btnCh5.Click += new System.EventHandler(this.btnCh5_Click);
			// 
			// panelCh2
			// 
			this.panelCh2.BackColor = System.Drawing.Color.SkyBlue;
			this.panelCh2.Controls.Add(this.txtCh2);
			this.panelCh2.Controls.Add(this.btnCh2);
			this.panelCh2.Location = new System.Drawing.Point(8, 88);
			this.panelCh2.Size = new System.Drawing.Size(192, 40);
			// 
			// txtCh2
			// 
			this.txtCh2.Location = new System.Drawing.Point(88, 8);
			this.txtCh2.Size = new System.Drawing.Size(64, 22);
			this.txtCh2.Text = "";
			// 
			// btnCh2
			// 
			this.btnCh2.Location = new System.Drawing.Point(8, 8);
			this.btnCh2.Size = new System.Drawing.Size(72, 24);
			this.btnCh2.Text = "DIO";
			this.btnCh2.Click += new System.EventHandler(this.btnCh2_Click);
			// 
			// panelCh3
			// 
			this.panelCh3.BackColor = System.Drawing.Color.SkyBlue;
			this.panelCh3.Controls.Add(this.txtCh3);
			this.panelCh3.Controls.Add(this.btnCh3);
			this.panelCh3.Location = new System.Drawing.Point(8, 128);
			this.panelCh3.Size = new System.Drawing.Size(192, 40);
			// 
			// txtCh3
			// 
			this.txtCh3.Location = new System.Drawing.Point(88, 8);
			this.txtCh3.Size = new System.Drawing.Size(64, 22);
			this.txtCh3.Text = "";
			// 
			// btnCh3
			// 
			this.btnCh3.Location = new System.Drawing.Point(8, 8);
			this.btnCh3.Size = new System.Drawing.Size(72, 24);
			this.btnCh3.Text = "DIO";
			this.btnCh3.Click += new System.EventHandler(this.btnCh3_Click);
			// 
			// panelCh0
			// 
			this.panelCh0.BackColor = System.Drawing.Color.SkyBlue;
			this.panelCh0.Controls.Add(this.txtCh0);
			this.panelCh0.Controls.Add(this.btnCh0);
			this.panelCh0.Location = new System.Drawing.Point(8, 8);
			this.panelCh0.Size = new System.Drawing.Size(192, 40);
			// 
			// txtCh0
			// 
			this.txtCh0.Location = new System.Drawing.Point(88, 8);
			this.txtCh0.Size = new System.Drawing.Size(64, 22);
			this.txtCh0.Text = "";
			// 
			// btnCh0
			// 
			this.btnCh0.Location = new System.Drawing.Point(8, 8);
			this.btnCh0.Size = new System.Drawing.Size(72, 24);
			this.btnCh0.Text = "DIO";
			this.btnCh0.Click += new System.EventHandler(this.btnCh0_Click);
			// 
			// panelCh6
			// 
			this.panelCh6.BackColor = System.Drawing.Color.SkyBlue;
			this.panelCh6.Controls.Add(this.txtCh6);
			this.panelCh6.Controls.Add(this.btnCh6);
			this.panelCh6.Location = new System.Drawing.Point(8, 248);
			this.panelCh6.Size = new System.Drawing.Size(192, 40);
			// 
			// txtCh6
			// 
			this.txtCh6.Location = new System.Drawing.Point(88, 8);
			this.txtCh6.Size = new System.Drawing.Size(64, 22);
			this.txtCh6.Text = "";
			// 
			// btnCh6
			// 
			this.btnCh6.Location = new System.Drawing.Point(8, 8);
			this.btnCh6.Size = new System.Drawing.Size(72, 24);
			this.btnCh6.Text = "DIO";
			this.btnCh6.Click += new System.EventHandler(this.btnCh6_Click);
			// 
			// panelCh7
			// 
			this.panelCh7.BackColor = System.Drawing.Color.SkyBlue;
			this.panelCh7.Controls.Add(this.txtCh7);
			this.panelCh7.Controls.Add(this.btnCh7);
			this.panelCh7.Location = new System.Drawing.Point(8, 288);
			this.panelCh7.Size = new System.Drawing.Size(192, 40);
			// 
			// txtCh7
			// 
			this.txtCh7.Location = new System.Drawing.Point(88, 8);
			this.txtCh7.Size = new System.Drawing.Size(64, 22);
			this.txtCh7.Text = "";
			// 
			// btnCh7
			// 
			this.btnCh7.Location = new System.Drawing.Point(8, 8);
			this.btnCh7.Size = new System.Drawing.Size(72, 24);
			this.btnCh7.Text = "DIO";
			this.btnCh7.Click += new System.EventHandler(this.btnCh7_Click);
			// 
			// panelCh1
			// 
			this.panelCh1.BackColor = System.Drawing.Color.SkyBlue;
			this.panelCh1.Controls.Add(this.txtCh1);
			this.panelCh1.Controls.Add(this.btnCh1);
			this.panelCh1.Location = new System.Drawing.Point(8, 48);
			this.panelCh1.Size = new System.Drawing.Size(192, 40);
			// 
			// txtCh1
			// 
			this.txtCh1.Location = new System.Drawing.Point(88, 8);
			this.txtCh1.Size = new System.Drawing.Size(64, 22);
			this.txtCh1.Text = "";
			// 
			// btnCh1
			// 
			this.btnCh1.Location = new System.Drawing.Point(8, 8);
			this.btnCh1.Size = new System.Drawing.Size(72, 24);
			this.btnCh1.Text = "DIO";
			this.btnCh1.Click += new System.EventHandler(this.btnCh1_Click);
			// 
			// panelCh4
			// 
			this.panelCh4.BackColor = System.Drawing.Color.SkyBlue;
			this.panelCh4.Controls.Add(this.txtCh4);
			this.panelCh4.Controls.Add(this.btnCh4);
			this.panelCh4.Location = new System.Drawing.Point(8, 168);
			this.panelCh4.Size = new System.Drawing.Size(192, 40);
			// 
			// txtCh4
			// 
			this.txtCh4.Location = new System.Drawing.Point(88, 8);
			this.txtCh4.Size = new System.Drawing.Size(64, 22);
			this.txtCh4.Text = "";
			// 
			// btnCh4
			// 
			this.btnCh4.Location = new System.Drawing.Point(8, 8);
			this.btnCh4.Size = new System.Drawing.Size(72, 24);
			this.btnCh4.Text = "DIO";
			this.btnCh4.Click += new System.EventHandler(this.btnCh4_Click);
			// 
			// panelCh12
			// 
			this.panelCh12.BackColor = System.Drawing.Color.SkyBlue;
			this.panelCh12.Controls.Add(this.txtCh12);
			this.panelCh12.Controls.Add(this.btnCh12);
			this.panelCh12.Location = new System.Drawing.Point(232, 168);
			this.panelCh12.Size = new System.Drawing.Size(192, 40);
			// 
			// txtCh12
			// 
			this.txtCh12.Location = new System.Drawing.Point(88, 8);
			this.txtCh12.Size = new System.Drawing.Size(64, 22);
			this.txtCh12.Text = "";
			// 
			// btnCh12
			// 
			this.btnCh12.Location = new System.Drawing.Point(8, 8);
			this.btnCh12.Size = new System.Drawing.Size(72, 24);
			this.btnCh12.Text = "DIO";
			this.btnCh12.Click += new System.EventHandler(this.btnCh12_Click);
			// 
			// panelCh15
			// 
			this.panelCh15.BackColor = System.Drawing.Color.SkyBlue;
			this.panelCh15.Controls.Add(this.txtCh15);
			this.panelCh15.Controls.Add(this.btnCh15);
			this.panelCh15.Location = new System.Drawing.Point(232, 288);
			this.panelCh15.Size = new System.Drawing.Size(192, 40);
			// 
			// txtCh15
			// 
			this.txtCh15.Location = new System.Drawing.Point(88, 8);
			this.txtCh15.Size = new System.Drawing.Size(64, 22);
			this.txtCh15.Text = "";
			// 
			// btnCh15
			// 
			this.btnCh15.Location = new System.Drawing.Point(8, 8);
			this.btnCh15.Size = new System.Drawing.Size(72, 24);
			this.btnCh15.Text = "DIO";
			this.btnCh15.Click += new System.EventHandler(this.btnCh15_Click);
			// 
			// panelCh8
			// 
			this.panelCh8.BackColor = System.Drawing.Color.SkyBlue;
			this.panelCh8.Controls.Add(this.txtCh8);
			this.panelCh8.Controls.Add(this.btnCh8);
			this.panelCh8.Location = new System.Drawing.Point(232, 8);
			this.panelCh8.Size = new System.Drawing.Size(192, 40);
			// 
			// txtCh8
			// 
			this.txtCh8.Location = new System.Drawing.Point(88, 8);
			this.txtCh8.Size = new System.Drawing.Size(64, 22);
			this.txtCh8.Text = "";
			// 
			// btnCh8
			// 
			this.btnCh8.Location = new System.Drawing.Point(8, 8);
			this.btnCh8.Size = new System.Drawing.Size(72, 24);
			this.btnCh8.Text = "DIO";
			this.btnCh8.Click += new System.EventHandler(this.btnCh8_Click);
			// 
			// panelCh14
			// 
			this.panelCh14.BackColor = System.Drawing.Color.SkyBlue;
			this.panelCh14.Controls.Add(this.txtCh14);
			this.panelCh14.Controls.Add(this.btnCh14);
			this.panelCh14.Location = new System.Drawing.Point(232, 248);
			this.panelCh14.Size = new System.Drawing.Size(192, 40);
			// 
			// txtCh14
			// 
			this.txtCh14.Location = new System.Drawing.Point(88, 8);
			this.txtCh14.Size = new System.Drawing.Size(64, 22);
			this.txtCh14.Text = "";
			// 
			// btnCh14
			// 
			this.btnCh14.Location = new System.Drawing.Point(8, 8);
			this.btnCh14.Size = new System.Drawing.Size(72, 24);
			this.btnCh14.Text = "DIO";
			this.btnCh14.Click += new System.EventHandler(this.btnCh14_Click);
			// 
			// panelCh9
			// 
			this.panelCh9.BackColor = System.Drawing.Color.SkyBlue;
			this.panelCh9.Controls.Add(this.txtCh9);
			this.panelCh9.Controls.Add(this.btnCh9);
			this.panelCh9.Location = new System.Drawing.Point(232, 48);
			this.panelCh9.Size = new System.Drawing.Size(192, 40);
			// 
			// txtCh9
			// 
			this.txtCh9.Location = new System.Drawing.Point(88, 8);
			this.txtCh9.Size = new System.Drawing.Size(64, 22);
			this.txtCh9.Text = "";
			// 
			// btnCh9
			// 
			this.btnCh9.Location = new System.Drawing.Point(8, 8);
			this.btnCh9.Size = new System.Drawing.Size(72, 24);
			this.btnCh9.Text = "DIO";
			this.btnCh9.Click += new System.EventHandler(this.btnCh9_Click);
			// 
			// panelCh10
			// 
			this.panelCh10.BackColor = System.Drawing.Color.SkyBlue;
			this.panelCh10.Controls.Add(this.txtCh10);
			this.panelCh10.Controls.Add(this.btnCh10);
			this.panelCh10.Location = new System.Drawing.Point(232, 88);
			this.panelCh10.Size = new System.Drawing.Size(192, 40);
			// 
			// txtCh10
			// 
			this.txtCh10.Location = new System.Drawing.Point(88, 8);
			this.txtCh10.Size = new System.Drawing.Size(64, 22);
			this.txtCh10.Text = "";
			// 
			// btnCh10
			// 
			this.btnCh10.Location = new System.Drawing.Point(8, 8);
			this.btnCh10.Size = new System.Drawing.Size(72, 24);
			this.btnCh10.Text = "DIO";
			this.btnCh10.Click += new System.EventHandler(this.btnCh10_Click);
			// 
			// panelCh11
			// 
			this.panelCh11.BackColor = System.Drawing.Color.SkyBlue;
			this.panelCh11.Controls.Add(this.txtCh11);
			this.panelCh11.Controls.Add(this.btnCh11);
			this.panelCh11.Location = new System.Drawing.Point(232, 128);
			this.panelCh11.Size = new System.Drawing.Size(192, 40);
			// 
			// txtCh11
			// 
			this.txtCh11.Location = new System.Drawing.Point(88, 8);
			this.txtCh11.Size = new System.Drawing.Size(64, 22);
			this.txtCh11.Text = "";
			// 
			// btnCh11
			// 
			this.btnCh11.Location = new System.Drawing.Point(8, 8);
			this.btnCh11.Size = new System.Drawing.Size(72, 24);
			this.btnCh11.Text = "DIO";
			this.btnCh11.Click += new System.EventHandler(this.btnCh11_Click);
			// 
			// panelCh13
			// 
			this.panelCh13.BackColor = System.Drawing.Color.SkyBlue;
			this.panelCh13.Controls.Add(this.txtCh13);
			this.panelCh13.Controls.Add(this.btnCh13);
			this.panelCh13.Location = new System.Drawing.Point(232, 208);
			this.panelCh13.Size = new System.Drawing.Size(192, 40);
			// 
			// txtCh13
			// 
			this.txtCh13.Location = new System.Drawing.Point(88, 8);
			this.txtCh13.Size = new System.Drawing.Size(64, 22);
			this.txtCh13.Text = "";
			// 
			// btnCh13
			// 
			this.btnCh13.Location = new System.Drawing.Point(8, 8);
			this.btnCh13.Size = new System.Drawing.Size(72, 24);
			this.btnCh13.Text = "DIO";
			this.btnCh13.Click += new System.EventHandler(this.btnCh13_Click);
			// 
			// txtModule
			// 
			this.txtModule.Location = new System.Drawing.Point(168, 16);
			this.txtModule.Size = new System.Drawing.Size(176, 22);
			this.txtModule.Text = "";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(16, 16);
			this.label7.Size = new System.Drawing.Size(136, 20);
			this.label7.Text = "Module name:";
			// 
			// txtReadCount
			// 
			this.txtReadCount.Location = new System.Drawing.Point(168, 48);
			this.txtReadCount.Size = new System.Drawing.Size(176, 22);
			this.txtReadCount.Text = "0";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(16, 48);
			this.label6.Size = new System.Drawing.Size(136, 20);
			this.label6.Text = "Read count:";
			// 
			// buttonStart
			// 
			this.buttonStart.Location = new System.Drawing.Point(368, 16);
			this.buttonStart.Size = new System.Drawing.Size(72, 24);
			this.buttonStart.Text = "Start";
			this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
			// 
			// timer1
			// 
			this.timer1.Interval = 500;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// Form1
			// 
			this.ClientSize = new System.Drawing.Size(458, 424);
			this.Controls.Add(this.panelDIO);
			this.Controls.Add(this.txtModule);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.txtReadCount);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.buttonStart);
			this.Text = "Adam50XXDIO sample program (C#)";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>

		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (m_bStart)
			{
				timer1.Enabled = false; // disable timer

				adamCtl.CloseDevice();
				adamCtl = null;
			}
		}

		private void buttonStart_Click(object sender, System.EventArgs e)
		{
			if (m_bStart) // was started
			{
				panelDIO.Enabled = false;
				m_bStart = false;
				timer1.Enabled = false;

				adamCtl.CloseDevice();

				buttonStart.Text = "Start";
			}
			else
			{
				try
				{
					if (adamCtl.OpenDevice())
					{
						m_iCount = 0; // reset the reading counter
						//
						if (RefreshForm())
						{
							panelDIO.Enabled = true;
							timer1.Enabled = true; // enable timer
							buttonStart.Text = "Stop";
							m_bStart = true; // starting flag
						}
						else
							adamCtl.CloseDevice();
					}
					else
						MessageBox.Show("Failed to open COM port!", "Error");
				}
				catch
				{
					MessageBox.Show("OpenDevice() failed!!", "Error");
				}
			}
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			m_iCount++;
			txtReadCount.Text = "Polling "+m_iCount.ToString()+" times...";
			RefresDIO();
		}
	
		private bool RefreshForm()
		{
			bool bRet = false;

			if (m_Adam5000Type == Adam5000Type.Adam5050)
				bRet = InitAdam5050();
			else if (m_Adam5000Type == Adam5000Type.Adam5051)
				bRet = InitAdam5051();
			else if (m_Adam5000Type == Adam5000Type.Adam5052)
				bRet = InitAdam5052();
			else if (m_Adam5000Type == Adam5000Type.Adam5055)
				bRet = InitAdam5055();
			else if (m_Adam5000Type == Adam5000Type.Adam5056)
				bRet = InitAdam5056();
			else if (m_Adam5000Type == Adam5000Type.Adam5060)
				bRet = InitAdam5060();
			else if (m_Adam5000Type == Adam5000Type.Adam5068)
				bRet = InitAdam5068();
			else if (m_Adam5000Type == Adam5000Type.Adam5069)
				bRet = InitAdam5069();
			if (!bRet)
				MessageBox.Show("Refresh form failed", "Error");
			return bRet;
		}

		private void InitChannelItems(bool i_bVisable, bool i_bIsDI, bool i_bIsMasked, ref int i_iCh, ref int i_iDI, ref int i_iDO, ref Panel panelCh, ref Button btnCh)
		{
			int iCh;
			if (i_bVisable)
			{
				panelCh.Visible = true;
				iCh = i_iDI + i_iDO;
				if (i_bIsDI) // DI
				{
					if (i_iCh >= 0)
					{
						btnCh.Text = "Ch"+i_iCh.ToString("00")+"/DI";
						i_iCh++;
					}
					else
						btnCh.Text = "DI "+i_iDI.ToString();
					btnCh.Enabled = false;
					i_iDI++;
				}
				else // DO
				{
					if (i_iCh >= 0)
					{
						btnCh.Text = "Ch"+i_iCh.ToString("00")+"/DO";
						i_iCh++;
					}
					else
						btnCh.Text = "DO "+i_iDO.ToString();
					if (i_bIsMasked)
						btnCh.Enabled = false;
					else
						btnCh.Enabled = true;
					i_iDO++;
				}
			}
			else
				panelCh.Visible = false;
		}

		private bool InitAdam5050()
		{
			bool[] bDIO;
			bool bRet;
			int iCh = 0, iDI = 0, iDO = 0;

			bRet = adamCtl.DigitalInput().GetUniversalStatus(m_iSlot, out bDIO);

			if (bRet && bDIO.Length == 16)
			{
				InitChannelItems(true, bDIO[0],   false,  ref iCh,  ref iDI, ref iDO, ref panelCh0,  ref btnCh0);
				InitChannelItems(true, bDIO[1],   false,  ref iCh,  ref iDI, ref iDO, ref panelCh1,  ref btnCh1);
				InitChannelItems(true, bDIO[2],   false,  ref iCh,  ref iDI, ref iDO, ref panelCh2,  ref btnCh2);
				InitChannelItems(true, bDIO[3],   false,  ref iCh,  ref iDI, ref iDO, ref panelCh3,  ref btnCh3);
				InitChannelItems(true, bDIO[4],   false,  ref iCh,  ref iDI, ref iDO, ref panelCh4,  ref btnCh4);
				InitChannelItems(true, bDIO[5],   false,  ref iCh,  ref iDI, ref iDO, ref panelCh5,  ref btnCh5);
				InitChannelItems(true, bDIO[6],   false,  ref iCh,  ref iDI, ref iDO, ref panelCh6,  ref btnCh6);
				InitChannelItems(true, bDIO[7],   false,  ref iCh,  ref iDI, ref iDO, ref panelCh7,  ref btnCh7);
				InitChannelItems(true, bDIO[8],   false,  ref iCh,  ref iDI, ref iDO, ref panelCh8,  ref btnCh8);
				InitChannelItems(true, bDIO[9],   false,  ref iCh,  ref iDI, ref iDO, ref panelCh9,  ref btnCh9);
				InitChannelItems(true, bDIO[10],  false, ref iCh, ref iDI, ref iDO, ref panelCh10, ref btnCh10);
				InitChannelItems(true, bDIO[11],  false, ref iCh, ref iDI, ref iDO, ref panelCh11, ref btnCh11);
				InitChannelItems(true, bDIO[12],  false, ref iCh, ref iDI, ref iDO, ref panelCh12, ref btnCh12);
				InitChannelItems(true, bDIO[13],  false, ref iCh, ref iDI, ref iDO, ref panelCh13, ref btnCh13);
				InitChannelItems(true, bDIO[14],  false, ref iCh, ref iDI, ref iDO, ref panelCh14, ref btnCh14);
				InitChannelItems(true, bDIO[15],  false, ref iCh, ref iDI, ref iDO, ref panelCh15, ref btnCh15);
				return true;
			}
			return false;
		}

		private bool InitAdam5051()
		{
			int iCh = -1, iDI = 0, iDO = 0;

			InitChannelItems(true, true, false, ref iCh,  ref iDI, ref iDO, ref panelCh0,  ref btnCh0);
			InitChannelItems(true, true, false, ref iCh,  ref iDI, ref iDO, ref panelCh1,  ref btnCh1);
			InitChannelItems(true, true, false, ref iCh,  ref iDI, ref iDO, ref panelCh2,  ref btnCh2);
			InitChannelItems(true, true, false, ref iCh,  ref iDI, ref iDO, ref panelCh3,  ref btnCh3);
			InitChannelItems(true, true, false, ref iCh,  ref iDI, ref iDO, ref panelCh4,  ref btnCh4);
			InitChannelItems(true, true, false, ref iCh,  ref iDI, ref iDO, ref panelCh5,  ref btnCh5);
			InitChannelItems(true, true, false, ref iCh,  ref iDI, ref iDO, ref panelCh6,  ref btnCh6);
			InitChannelItems(true, true, false, ref iCh,  ref iDI, ref iDO, ref panelCh7,  ref btnCh7);
			InitChannelItems(true, true, false, ref iCh,  ref iDI, ref iDO, ref panelCh8,  ref btnCh8);
			InitChannelItems(true, true, false, ref iCh,  ref iDI, ref iDO, ref panelCh9,  ref btnCh9);
			InitChannelItems(true, true, false, ref iCh,  ref iDI, ref iDO, ref panelCh10, ref btnCh10);
			InitChannelItems(true, true, false, ref iCh,  ref iDI, ref iDO, ref panelCh11, ref btnCh11);
			InitChannelItems(true, true, false, ref iCh,  ref iDI, ref iDO, ref panelCh12, ref btnCh12);
			InitChannelItems(true, true, false, ref iCh,  ref iDI, ref iDO, ref panelCh13, ref btnCh13);
			InitChannelItems(true, true, false, ref iCh,  ref iDI, ref iDO, ref panelCh14, ref btnCh14);
			InitChannelItems(true, true, false, ref iCh,  ref iDI, ref iDO, ref panelCh15, ref btnCh15);
			return true;
		}
	
		private bool InitAdam5052()
		{
			int iCh = -1, iDI = 0, iDO = 0;

			InitChannelItems(true,  true, false, ref iCh,  ref iDI, ref iDO, ref panelCh0,  ref btnCh0);
			InitChannelItems(true,  true, false, ref iCh,  ref iDI, ref iDO, ref panelCh1,  ref btnCh1);
			InitChannelItems(true,  true, false, ref iCh,  ref iDI, ref iDO, ref panelCh2,  ref btnCh2);
			InitChannelItems(true,  true, false, ref iCh,  ref iDI, ref iDO, ref panelCh3,  ref btnCh3);
			InitChannelItems(true,  true, false, ref iCh,  ref iDI, ref iDO, ref panelCh4,  ref btnCh4);
			InitChannelItems(true,  true, false, ref iCh,  ref iDI, ref iDO, ref panelCh5,  ref btnCh5);
			InitChannelItems(true,  true, false, ref iCh,  ref iDI, ref iDO, ref panelCh6,  ref btnCh6);
			InitChannelItems(true,  true, false, ref iCh,  ref iDI, ref iDO, ref panelCh7,  ref btnCh7);
			InitChannelItems(false, true, false, ref iCh,  ref iDI, ref iDO, ref panelCh8,  ref btnCh8);
			InitChannelItems(false, true, false, ref iCh,  ref iDI, ref iDO, ref panelCh9,  ref btnCh9);
			InitChannelItems(false, true, false, ref iCh,  ref iDI, ref iDO, ref panelCh10, ref btnCh10);
			InitChannelItems(false, true, false, ref iCh,  ref iDI, ref iDO, ref panelCh11, ref btnCh11);
			InitChannelItems(false, true, false, ref iCh,  ref iDI, ref iDO, ref panelCh12, ref btnCh12);
			InitChannelItems(false, true, false, ref iCh,  ref iDI, ref iDO, ref panelCh13, ref btnCh13);
			InitChannelItems(false, true, false, ref iCh,  ref iDI, ref iDO, ref panelCh14, ref btnCh14);
			InitChannelItems(false, true, false, ref iCh,  ref iDI, ref iDO, ref panelCh15, ref btnCh15);
			return true;
		}
	
		private bool InitAdam5055()
		{
			//bool[] bMask;
			//bool bRet;
			int iCh = -1, iDI = 0, iDO = 0;

			InitChannelItems(true, false, false, ref iCh, ref iDI, ref iDO, ref panelCh0,  ref btnCh0);
			InitChannelItems(true, false, false, ref iCh, ref iDI, ref iDO, ref panelCh1,  ref btnCh1);
			InitChannelItems(true, false, false, ref iCh, ref iDI, ref iDO, ref panelCh2,  ref btnCh2);
			InitChannelItems(true, false, false, ref iCh, ref iDI, ref iDO, ref panelCh3,  ref btnCh3);
			InitChannelItems(true, false, false, ref iCh, ref iDI, ref iDO, ref panelCh4,  ref btnCh4);
			InitChannelItems(true, false, false, ref iCh, ref iDI, ref iDO, ref panelCh5,  ref btnCh5);
			InitChannelItems(true, false, false, ref iCh, ref iDI, ref iDO, ref panelCh6,  ref btnCh6);
			InitChannelItems(true, false, false, ref iCh, ref iDI, ref iDO, ref panelCh7,  ref btnCh7);
			InitChannelItems(true, true,  false,  ref iCh,  ref iDI, ref iDO, ref panelCh8,  ref btnCh8);
			InitChannelItems(true, true,  false,  ref iCh,  ref iDI, ref iDO, ref panelCh9,  ref btnCh9);
			InitChannelItems(true, true,  false,  ref iCh,  ref iDI, ref iDO, ref panelCh10, ref btnCh10);
			InitChannelItems(true, true,  false,  ref iCh,  ref iDI, ref iDO, ref panelCh11, ref btnCh11);
			InitChannelItems(true, true,  false,  ref iCh,  ref iDI, ref iDO, ref panelCh12, ref btnCh12);
			InitChannelItems(true, true,  false,  ref iCh,  ref iDI, ref iDO, ref panelCh13, ref btnCh13);
			InitChannelItems(true, true,  false,  ref iCh,  ref iDI, ref iDO, ref panelCh14, ref btnCh14);
			InitChannelItems(true, true,  false,  ref iCh,  ref iDI, ref iDO, ref panelCh15, ref btnCh15);
			return true;
		}
	
		private bool InitAdam5056()
		{
			int iCh = -1, iDI = 0, iDO = 0;

			InitChannelItems(true, false,  false, ref iCh,  ref iDI, ref iDO, ref panelCh0,  ref btnCh0);
			InitChannelItems(true, false,  false, ref iCh,  ref iDI, ref iDO, ref panelCh1,  ref btnCh1);
			InitChannelItems(true, false,  false, ref iCh,  ref iDI, ref iDO, ref panelCh2,  ref btnCh2);
			InitChannelItems(true, false,  false, ref iCh,  ref iDI, ref iDO, ref panelCh3,  ref btnCh3);
			InitChannelItems(true, false,  false, ref iCh,  ref iDI, ref iDO, ref panelCh4,  ref btnCh4);
			InitChannelItems(true, false,  false, ref iCh,  ref iDI, ref iDO, ref panelCh5,  ref btnCh5);
			InitChannelItems(true, false,  false, ref iCh,  ref iDI, ref iDO, ref panelCh6,  ref btnCh6);
			InitChannelItems(true, false,  false, ref iCh,  ref iDI, ref iDO, ref panelCh7,  ref btnCh7);
			InitChannelItems(true, false,  false, ref iCh,  ref iDI, ref iDO, ref panelCh8,  ref btnCh8);
			InitChannelItems(true, false,  false, ref iCh,  ref iDI, ref iDO, ref panelCh9,  ref btnCh9);
			InitChannelItems(true, false,  false, ref iCh,  ref iDI, ref iDO, ref panelCh10, ref btnCh10);
			InitChannelItems(true, false,  false, ref iCh,  ref iDI, ref iDO, ref panelCh11, ref btnCh11);
			InitChannelItems(true, false,  false, ref iCh,  ref iDI, ref iDO, ref panelCh12, ref btnCh12);
			InitChannelItems(true, false,  false, ref iCh,  ref iDI, ref iDO, ref panelCh13, ref btnCh13);
			InitChannelItems(true, false,  false, ref iCh,  ref iDI, ref iDO, ref panelCh14, ref btnCh14);
			InitChannelItems(true, false,  false, ref iCh,  ref iDI, ref iDO, ref panelCh15, ref btnCh15);
			return true;
		}
	
		private bool InitAdam5060()
		{
			int iCh = -1, iDI = 0, iDO = 0;

			InitChannelItems(true,  false,	   false, ref iCh,  ref iDI, ref iDO, ref panelCh0,  ref btnCh0);
			InitChannelItems(true,  false,     false, ref iCh,  ref iDI, ref iDO, ref panelCh1,  ref btnCh1);
			InitChannelItems(true,  false,     false, ref iCh,  ref iDI, ref iDO, ref panelCh2,  ref btnCh2);
			InitChannelItems(true,  false,     false, ref iCh,  ref iDI, ref iDO, ref panelCh3,  ref btnCh3);
			InitChannelItems(true,  false,     false, ref iCh,  ref iDI, ref iDO, ref panelCh4,  ref btnCh4);
			InitChannelItems(true,  false,     false, ref iCh,  ref iDI, ref iDO, ref panelCh5,  ref btnCh5);
			InitChannelItems(false, false,     false, ref iCh,  ref iDI, ref iDO, ref panelCh6,  ref btnCh6);
			InitChannelItems(false, false,     false, ref iCh,  ref iDI, ref iDO, ref panelCh7,  ref btnCh7);
			InitChannelItems(false, false,     false, ref iCh,  ref iDI, ref iDO, ref panelCh8,  ref btnCh8);
			InitChannelItems(false, false,     false, ref iCh,  ref iDI, ref iDO, ref panelCh9,  ref btnCh9);
			InitChannelItems(false, false,     false, ref iCh,  ref iDI, ref iDO, ref panelCh10, ref btnCh10);
			InitChannelItems(false, false,     false, ref iCh,  ref iDI, ref iDO, ref panelCh11, ref btnCh11);
			InitChannelItems(false, false,     false, ref iCh,  ref iDI, ref iDO, ref panelCh12, ref btnCh12);
			InitChannelItems(false, false,     false, ref iCh,  ref iDI, ref iDO, ref panelCh13, ref btnCh13);
			InitChannelItems(false, false,     false, ref iCh,  ref iDI, ref iDO, ref panelCh14, ref btnCh14);
			InitChannelItems(false, false,     false, ref iCh,  ref iDI, ref iDO, ref panelCh15, ref btnCh15);
			return true;
		}
	
		private bool InitAdam5068()
		{
			int iCh = -1, iDI = 0, iDO = 0;

			InitChannelItems(true,  false,     false, ref iCh,  ref iDI, ref iDO, ref panelCh0,  ref btnCh0);
			InitChannelItems(true,  false,     false, ref iCh,  ref iDI, ref iDO, ref panelCh1,  ref btnCh1);
			InitChannelItems(true,  false,     false, ref iCh,  ref iDI, ref iDO, ref panelCh2,  ref btnCh2);
			InitChannelItems(true,  false,     false, ref iCh,  ref iDI, ref iDO, ref panelCh3,  ref btnCh3);
			InitChannelItems(true,  false,     false, ref iCh,  ref iDI, ref iDO, ref panelCh4,  ref btnCh4);
			InitChannelItems(true,  false,     false, ref iCh,  ref iDI, ref iDO, ref panelCh5,  ref btnCh5);
			InitChannelItems(true,  false,     false, ref iCh,  ref iDI, ref iDO, ref panelCh6,  ref btnCh6);
			InitChannelItems(true,  false,     false, ref iCh,  ref iDI, ref iDO, ref panelCh7,  ref btnCh7);
			InitChannelItems(false, false,     false, ref iCh,  ref iDI, ref iDO, ref panelCh8,  ref btnCh8);
			InitChannelItems(false, false,     false, ref iCh,  ref iDI, ref iDO, ref panelCh9,  ref btnCh9);
			InitChannelItems(false, false,     false, ref iCh,  ref iDI, ref iDO, ref panelCh10, ref btnCh10);
			InitChannelItems(false, false,     false, ref iCh,  ref iDI, ref iDO, ref panelCh11, ref btnCh11);
			InitChannelItems(false, false,     false, ref iCh,  ref iDI, ref iDO, ref panelCh12, ref btnCh12);
			InitChannelItems(false, false,     false, ref iCh,  ref iDI, ref iDO, ref panelCh13, ref btnCh13);
			InitChannelItems(false, false,     false, ref iCh,  ref iDI, ref iDO, ref panelCh14, ref btnCh14);
			InitChannelItems(false, false,     false, ref iCh,  ref iDI, ref iDO, ref panelCh15, ref btnCh15);
			return true;
		}
	
		private bool InitAdam5069()
		{
			int iCh = -1, iDI = 0, iDO = 0;

			InitChannelItems(true,  false,     false, ref iCh,  ref iDI, ref iDO, ref panelCh0,  ref btnCh0);
			InitChannelItems(true,  false,     false, ref iCh,  ref iDI, ref iDO, ref panelCh1,  ref btnCh1);
			InitChannelItems(true,  false,     false, ref iCh,  ref iDI, ref iDO, ref panelCh2,  ref btnCh2);
			InitChannelItems(true,  false,     false, ref iCh,  ref iDI, ref iDO, ref panelCh3,  ref btnCh3);
			InitChannelItems(true,  false,     false, ref iCh,  ref iDI, ref iDO, ref panelCh4,  ref btnCh4);
			InitChannelItems(true,  false,     false, ref iCh,  ref iDI, ref iDO, ref panelCh5,  ref btnCh5);
			InitChannelItems(true,  false,     false, ref iCh,  ref iDI, ref iDO, ref panelCh6,  ref btnCh6);
			InitChannelItems(true,  false,     false, ref iCh,  ref iDI, ref iDO, ref panelCh7,  ref btnCh7);
			InitChannelItems(false, false,     false, ref iCh,  ref iDI, ref iDO, ref panelCh8,  ref btnCh8);
			InitChannelItems(false, false,     false, ref iCh,  ref iDI, ref iDO, ref panelCh9,  ref btnCh9);
			InitChannelItems(false, false,     false, ref iCh,  ref iDI, ref iDO, ref panelCh10, ref btnCh10);
			InitChannelItems(false, false,     false, ref iCh,  ref iDI, ref iDO, ref panelCh11, ref btnCh11);
			InitChannelItems(false, false,     false, ref iCh,  ref iDI, ref iDO, ref panelCh12, ref btnCh12);
			InitChannelItems(false, false,     false, ref iCh,  ref iDI, ref iDO, ref panelCh13, ref btnCh13);
			InitChannelItems(false, false,     false, ref iCh,  ref iDI, ref iDO, ref panelCh14, ref btnCh14);
			InitChannelItems(false, false,     false, ref iCh,  ref iDI, ref iDO, ref panelCh15, ref btnCh15);
			return true;
		}

		private bool RefresDIO()
		{
			bool[] bData;
			bool bRet;

			bRet = adamCtl.DigitalInput().GetValues(m_iSlot, m_iChTotal, out bData);

			if (bRet)
			{
				if (m_iChTotal > 0)
					txtCh0.Text = bData[0].ToString();
				if (m_iChTotal > 1)
					txtCh1.Text = bData[1].ToString();
				if (m_iChTotal > 2)
					txtCh2.Text = bData[2].ToString();
				if (m_iChTotal > 3)
					txtCh3.Text = bData[3].ToString();
				if (m_iChTotal > 4)
					txtCh4.Text = bData[4].ToString();
				if (m_iChTotal > 5)
					txtCh5.Text = bData[5].ToString();
				if (m_iChTotal > 6)
					txtCh6.Text = bData[6].ToString();
				if (m_iChTotal > 7)
					txtCh7.Text = bData[7].ToString();
				if (m_iChTotal > 8)
					txtCh8.Text = bData[8].ToString();
				if (m_iChTotal > 9)
					txtCh9.Text = bData[9].ToString();
				if (m_iChTotal > 10)
					txtCh10.Text = bData[10].ToString();
				if (m_iChTotal > 11)
					txtCh11.Text = bData[11].ToString();
				if (m_iChTotal > 12)
					txtCh12.Text = bData[12].ToString();
				if (m_iChTotal > 13)
					txtCh13.Text = bData[13].ToString();
				if (m_iChTotal > 14)
					txtCh14.Text = bData[14].ToString();
				if (m_iChTotal > 15)
					txtCh15.Text = bData[15].ToString();
				return true;
			}
			else
			{
				txtCh0.Text = "Fail";
				txtCh1.Text = "Fail";
				txtCh2.Text = "Fail";
				txtCh3.Text = "Fail";
				txtCh4.Text = "Fail";
				txtCh5.Text = "Fail";
				txtCh6.Text = "Fail";
				txtCh7.Text = "Fail";
				txtCh8.Text = "Fail";
				txtCh9.Text = "Fail";
				txtCh10.Text = "Fail";
				txtCh11.Text = "Fail";
				txtCh12.Text = "Fail";
				txtCh13.Text = "Fail";
				txtCh14.Text = "Fail";
				txtCh15.Text = "Fail";
			}
			return false;
		}

		private void btnCh_Click(int i_iCh, TextBox txtBox)
		{
			bool bRet;
			int iStart = m_iSlot*16+i_iCh+1;

			timer1.Enabled = false;

			bRet = adamCtl.DigitalOutput().SetValue(m_iSlot, i_iCh, (txtBox.Text=="False"));

			if (!bRet)
				MessageBox.Show("Set digital output failed!", "Error");
			timer1.Enabled = true;
		}

		private void btnCh0_Click(object sender, System.EventArgs e)
		{
			btnCh_Click(0, txtCh0);
		}

		private void btnCh1_Click(object sender, System.EventArgs e)
		{
			btnCh_Click(1, txtCh1);
		}

		private void btnCh2_Click(object sender, System.EventArgs e)
		{
			btnCh_Click(2, txtCh2);
		}

		private void btnCh3_Click(object sender, System.EventArgs e)
		{
			btnCh_Click(3, txtCh3);
		}

		private void btnCh4_Click(object sender, System.EventArgs e)
		{
			btnCh_Click(4, txtCh4);
		}

		private void btnCh5_Click(object sender, System.EventArgs e)
		{
			btnCh_Click(5, txtCh5);
		}

		private void btnCh6_Click(object sender, System.EventArgs e)
		{
			btnCh_Click(6, txtCh6);
		}

		private void btnCh7_Click(object sender, System.EventArgs e)
		{
			btnCh_Click(7, txtCh7);
		}

		private void btnCh8_Click(object sender, System.EventArgs e)
		{
			btnCh_Click(8, txtCh8);
		}

		private void btnCh9_Click(object sender, System.EventArgs e)
		{
			btnCh_Click(9, txtCh9);
		}

		private void btnCh10_Click(object sender, System.EventArgs e)
		{
			btnCh_Click(10, txtCh10);
		}

		private void btnCh11_Click(object sender, System.EventArgs e)
		{
			btnCh_Click(11, txtCh11);
		}

		private void btnCh12_Click(object sender, System.EventArgs e)
		{
			btnCh_Click(12, txtCh12);
		}

		private void btnCh13_Click(object sender, System.EventArgs e)
		{
			btnCh_Click(13, txtCh13);
		}

		private void btnCh14_Click(object sender, System.EventArgs e)
		{
			btnCh_Click(14, txtCh14);
		}

		private void btnCh15_Click(object sender, System.EventArgs e)
		{
			btnCh_Click(15, txtCh15);
		}
	}
}
