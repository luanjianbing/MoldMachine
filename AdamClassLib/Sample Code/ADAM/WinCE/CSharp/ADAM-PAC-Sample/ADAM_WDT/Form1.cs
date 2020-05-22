using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using Advantech.Adam;

namespace ADAM_WDT
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private Advantech.Adam.Watchdog m_wdt;
		private int m_chip;
		private DateTime m_start;

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button buttonEnable;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label labelTime;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button buttonStrobe;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Button buttonTest;
	
		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			m_chip = 0;
			m_wdt = new Watchdog();
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.buttonEnable = new System.Windows.Forms.Button();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.labelTime = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.buttonStrobe = new System.Windows.Forms.Button();
			this.buttonTest = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.buttonEnable);
			this.panel1.Controls.Add(this.comboBox1);
			this.panel1.Controls.Add(this.labelTime);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(8, 8);
			this.panel1.Size = new System.Drawing.Size(392, 72);
			// 
			// buttonEnable
			// 
			this.buttonEnable.Enabled = false;
			this.buttonEnable.Location = new System.Drawing.Point(312, 40);
			this.buttonEnable.Text = "Enable";
			this.buttonEnable.Click += new System.EventHandler(this.buttonEnable_Click);
			// 
			// comboBox1
			// 
			this.comboBox1.Enabled = false;
			this.comboBox1.Location = new System.Drawing.Point(120, 8);
			this.comboBox1.Size = new System.Drawing.Size(184, 20);
			// 
			// labelTime
			// 
			this.labelTime.Location = new System.Drawing.Point(120, 40);
			this.labelTime.Size = new System.Drawing.Size(184, 20);
			this.labelTime.Text = "00:00:00";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 40);
			this.label2.Text = "Elapsed time:";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Text = "Response time:";
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.textBox1);
			this.panel2.Controls.Add(this.label4);
			this.panel2.Controls.Add(this.buttonStrobe);
			this.panel2.Controls.Add(this.buttonTest);
			this.panel2.Location = new System.Drawing.Point(8, 88);
			this.panel2.Size = new System.Drawing.Size(392, 128);
			// 
			// textBox1
			// 
			this.textBox1.BackColor = System.Drawing.Color.Silver;
			this.textBox1.Location = new System.Drawing.Point(8, 40);
			this.textBox1.Multiline = true;
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(376, 80);
			this.textBox1.Text = "NOTES: When the Watchdog is enabled, if user clicks the \"Test\" button, no periodi" +
				"cally resetting signal will be sent to the Watchdog hardware, unless user clicks" +
				" \"Strobe\" button. Without \"Strobe\", the Watchdog will reset CPU when timeout.";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 8);
			this.label4.Size = new System.Drawing.Size(200, 20);
			this.label4.Text = "Reboot the machine by Watchdog";
			// 
			// buttonStrobe
			// 
			this.buttonStrobe.Enabled = false;
			this.buttonStrobe.Location = new System.Drawing.Point(312, 8);
			this.buttonStrobe.Text = "Strobe";
			this.buttonStrobe.Click += new System.EventHandler(this.buttonStrobe_Click);
			// 
			// buttonTest
			// 
			this.buttonTest.Enabled = false;
			this.buttonTest.Location = new System.Drawing.Point(232, 8);
			this.buttonTest.Text = "Test";
			this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
			// 
			// timer1
			// 
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// Form1
			// 
			this.ClientSize = new System.Drawing.Size(410, 224);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Text = "ADAM WDT sample program (C#)";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.Form1_Closing);
			this.Load += new System.EventHandler(this.Form1_Load);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>

		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			if (m_wdt.Initialize())
			{
				m_chip = m_wdt.ChipType;
				if (m_chip == (int)WDTCHIP.Chip_443)
				{
					comboBox1.Items.Add("2 seconds");
					comboBox1.Items.Add("5 seconds");
					comboBox1.Items.Add("10 seconds");
					comboBox1.Items.Add("15 seconds");
					comboBox1.Items.Add("30 seconds");
					comboBox1.Items.Add("45 seconds");
					comboBox1.Items.Add("60 seconds");
				}
				else if (m_chip == (int)WDTCHIP.Chip_W83977AF)
				{
					comboBox1.Items.Add("15 seconds");
					comboBox1.Items.Add("45 seconds");
					comboBox1.Items.Add("1 Minute 15 seconds");
					comboBox1.Items.Add("2 Minutes 15 seconds");
					comboBox1.Items.Add("3 Minutes 15 seconds");
					comboBox1.Items.Add("4 Minutes 15 seconds");
					comboBox1.Items.Add("5 Minutes 15 seconds");
					comboBox1.Items.Add("10 Minutes 15 seconds");
					comboBox1.Items.Add("20 Minutes 15 seconds");
					comboBox1.Items.Add("30 Minutes 15 seconds");
					comboBox1.Items.Add("40 Minutes 15 seconds");
					comboBox1.Items.Add("50 Minutes 15 seconds");
					comboBox1.Items.Add("1 Hour 15 seconds");
					comboBox1.Items.Add("2 Hours 15 seconds");
				}
				else if (m_chip == (int)WDTCHIP.Chip_W83627HF)
				{
					comboBox1.Items.Add("15 seconds");
					comboBox1.Items.Add("45 seconds");
					comboBox1.Items.Add("1 Minute 15 seconds");
					comboBox1.Items.Add("2 Minutes 15 seconds");
					comboBox1.Items.Add("3 Minutes 15 seconds");
					comboBox1.Items.Add("4 Minutes 15 seconds");
				}
                else if (m_chip == (int)WDTCHIP.Chip_ADAM5550)
                {
                    comboBox1.Items.Add("15 seconds");
                    comboBox1.Items.Add("45 seconds");
                    comboBox1.Items.Add("1 Minute 15 seconds");
                    comboBox1.Items.Add("2 Minutes 15 seconds");
                    comboBox1.Items.Add("3 Minutes 15 seconds");
                    comboBox1.Items.Add("4 Minutes 15 seconds");
                }
				else
				{
					MessageBox.Show("Unknown chip type!");
					return;
				}
				comboBox1.Enabled = true;
				comboBox1.SelectedIndex = m_wdt.Timeout;
				//
				m_wdt.EnableStatus = false;
				buttonEnable.Text = "Enable";
				buttonEnable.Enabled = true;
			}
			else
				MessageBox.Show("Failed to initialize Watchdog!");
		}

		private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			m_wdt.Terminate();
		}

		private void buttonEnable_Click(object sender, System.EventArgs e)
		{
			if (m_wdt.EnableStatus) // was enable, become disable
			{
				m_wdt.EnableStatus = false;
				buttonEnable.Text = "Enable";
				comboBox1.Enabled = true;
				buttonTest.Enabled = false;
				buttonStrobe.Enabled = false;
			}
			else
			{
				m_wdt.Timeout = comboBox1.SelectedIndex;
				buttonEnable.Text = "Disable";
				comboBox1.Enabled = false;
				buttonTest.Enabled = true;
				buttonStrobe.Enabled = true;
				m_wdt.EnableStatus = true;
			}
		}

		private void buttonTest_Click(object sender, System.EventArgs e)
		{
			if (m_wdt.Reboot())
			{
				buttonEnable.Enabled = false;
				buttonTest.Enabled = false;
				m_start = DateTime.Now;
				labelTime.Text = "00:00:00 (Ready to reboot)";
				timer1.Enabled = true;
			}
			else
				MessageBox.Show("Failed to set reboot action!");
		}

		private void buttonStrobe_Click(object sender, System.EventArgs e)
		{
			if (m_wdt.Strobe())
			{
				m_start = DateTime.Now;
				labelTime.Text = "00:00:00 (Ready to reboot)";
			}
			else
				MessageBox.Show("Failed to set strobe action.");
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			DateTime nowTime = DateTime.Now;
			TimeSpan diff = nowTime.Subtract(m_start);
			labelTime.Text = diff.Hours.ToString("00")+":"+diff.Minutes.ToString("00")+":"+diff.Seconds.ToString("00")+" (Ready to reboot)";
		}
	}
}
