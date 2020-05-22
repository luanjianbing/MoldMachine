using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using System.Net.Sockets;
using Advantech.Adam;
using Advantech.Common;

namespace Adam5013_17_18
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.CheckBox chkboxCh7;
		private System.Windows.Forms.CheckBox chkboxCh6;
		private System.Windows.Forms.CheckBox chkboxCh5;
		private System.Windows.Forms.CheckBox chkboxCh4;
		private System.Windows.Forms.CheckBox chkboxCh3;
		private System.Windows.Forms.CheckBox chkboxCh2;
		private System.Windows.Forms.CheckBox chkboxCh1;
		private System.Windows.Forms.CheckBox chkboxCh0;
		private System.Windows.Forms.TextBox txtAIValue7;
		private System.Windows.Forms.TextBox txtAIValue6;
		private System.Windows.Forms.TextBox txtAIValue5;
		private System.Windows.Forms.TextBox txtAIValue4;
		private System.Windows.Forms.TextBox txtAIValue3;
		private System.Windows.Forms.TextBox txtAIValue2;
		private System.Windows.Forms.TextBox txtAIValue1;
		private System.Windows.Forms.TextBox txtAIValue0;
		private System.Windows.Forms.TextBox txtModule;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtReadCount;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Button buttonStart;
	
		private int m_iSlot, m_iCount, m_iChTotal;
		private bool m_bStart;
		private byte m_byRange;
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

			m_iSlot = 1;	// the slot index of the module
			m_iCount = 0;	// the counting start from 0
			m_bStart = false;
			adamCtl = new AdamControl();

			//m_Adam5000Type = Adam5000Type.Adam5013; // the sample is for ADAM-5013
			//m_Adam5000Type = Adam5000Type.Adam5017; // the sample is for ADAM-5017
			m_Adam5000Type = Adam5000Type.Adam5018; // the sample is for ADAM-5018

			m_iChTotal = AnalogInput.GetChannelTotal(m_Adam5000Type);

			txtModule.Text = m_Adam5000Type.ToString();
			// 
			if (m_Adam5000Type == Adam5000Type.Adam5013)
			{
				chkboxCh3.Visible = false;
				txtAIValue3.Visible = false;
				chkboxCh4.Visible = false;
				txtAIValue4.Visible = false;
				chkboxCh5.Visible = false;
				txtAIValue5.Visible = false;
				chkboxCh6.Visible = false;
				txtAIValue6.Visible = false;
				chkboxCh7.Visible = false;
				txtAIValue7.Visible = false;
			}
			else if (m_Adam5000Type == Adam5000Type.Adam5018)
			{
				chkboxCh7.Visible = false;
				txtAIValue7.Visible = false;
			}
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
			this.chkboxCh7 = new System.Windows.Forms.CheckBox();
			this.chkboxCh6 = new System.Windows.Forms.CheckBox();
			this.chkboxCh5 = new System.Windows.Forms.CheckBox();
			this.chkboxCh4 = new System.Windows.Forms.CheckBox();
			this.chkboxCh3 = new System.Windows.Forms.CheckBox();
			this.chkboxCh2 = new System.Windows.Forms.CheckBox();
			this.chkboxCh1 = new System.Windows.Forms.CheckBox();
			this.chkboxCh0 = new System.Windows.Forms.CheckBox();
			this.txtAIValue7 = new System.Windows.Forms.TextBox();
			this.txtAIValue6 = new System.Windows.Forms.TextBox();
			this.txtAIValue5 = new System.Windows.Forms.TextBox();
			this.txtAIValue4 = new System.Windows.Forms.TextBox();
			this.txtAIValue3 = new System.Windows.Forms.TextBox();
			this.txtAIValue2 = new System.Windows.Forms.TextBox();
			this.txtAIValue1 = new System.Windows.Forms.TextBox();
			this.txtAIValue0 = new System.Windows.Forms.TextBox();
			this.txtModule = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtReadCount = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.buttonStart = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer();
			// 
			// chkboxCh7
			// 
			this.chkboxCh7.Enabled = false;
			this.chkboxCh7.Location = new System.Drawing.Point(16, 320);
			this.chkboxCh7.Size = new System.Drawing.Size(136, 20);
			this.chkboxCh7.Text = "AI-7 value:";
			// 
			// chkboxCh6
			// 
			this.chkboxCh6.Enabled = false;
			this.chkboxCh6.Location = new System.Drawing.Point(16, 288);
			this.chkboxCh6.Size = new System.Drawing.Size(136, 20);
			this.chkboxCh6.Text = "AI-6 value:";
			// 
			// chkboxCh5
			// 
			this.chkboxCh5.Enabled = false;
			this.chkboxCh5.Location = new System.Drawing.Point(16, 256);
			this.chkboxCh5.Size = new System.Drawing.Size(136, 20);
			this.chkboxCh5.Text = "AI-5 value:";
			// 
			// chkboxCh4
			// 
			this.chkboxCh4.Enabled = false;
			this.chkboxCh4.Location = new System.Drawing.Point(16, 224);
			this.chkboxCh4.Size = new System.Drawing.Size(136, 20);
			this.chkboxCh4.Text = "AI-4 value:";
			// 
			// chkboxCh3
			// 
			this.chkboxCh3.Enabled = false;
			this.chkboxCh3.Location = new System.Drawing.Point(16, 192);
			this.chkboxCh3.Size = new System.Drawing.Size(136, 20);
			this.chkboxCh3.Text = "AI-3 value:";
			// 
			// chkboxCh2
			// 
			this.chkboxCh2.Enabled = false;
			this.chkboxCh2.Location = new System.Drawing.Point(16, 160);
			this.chkboxCh2.Size = new System.Drawing.Size(136, 20);
			this.chkboxCh2.Text = "AI-2 value:";
			// 
			// chkboxCh1
			// 
			this.chkboxCh1.Enabled = false;
			this.chkboxCh1.Location = new System.Drawing.Point(16, 128);
			this.chkboxCh1.Size = new System.Drawing.Size(136, 20);
			this.chkboxCh1.Text = "AI-1 value:";
			// 
			// chkboxCh0
			// 
			this.chkboxCh0.Enabled = false;
			this.chkboxCh0.Location = new System.Drawing.Point(16, 96);
			this.chkboxCh0.Size = new System.Drawing.Size(136, 20);
			this.chkboxCh0.Text = "AI-0 value:";
			// 
			// txtAIValue7
			// 
			this.txtAIValue7.Location = new System.Drawing.Point(168, 320);
			this.txtAIValue7.Size = new System.Drawing.Size(176, 22);
			this.txtAIValue7.Text = "";
			// 
			// txtAIValue6
			// 
			this.txtAIValue6.Location = new System.Drawing.Point(168, 288);
			this.txtAIValue6.Size = new System.Drawing.Size(176, 22);
			this.txtAIValue6.Text = "";
			// 
			// txtAIValue5
			// 
			this.txtAIValue5.Location = new System.Drawing.Point(168, 256);
			this.txtAIValue5.Size = new System.Drawing.Size(176, 22);
			this.txtAIValue5.Text = "";
			// 
			// txtAIValue4
			// 
			this.txtAIValue4.Location = new System.Drawing.Point(168, 224);
			this.txtAIValue4.Size = new System.Drawing.Size(176, 22);
			this.txtAIValue4.Text = "";
			// 
			// txtAIValue3
			// 
			this.txtAIValue3.Location = new System.Drawing.Point(168, 192);
			this.txtAIValue3.Size = new System.Drawing.Size(176, 22);
			this.txtAIValue3.Text = "";
			// 
			// txtAIValue2
			// 
			this.txtAIValue2.Location = new System.Drawing.Point(168, 160);
			this.txtAIValue2.Size = new System.Drawing.Size(176, 22);
			this.txtAIValue2.Text = "";
			// 
			// txtAIValue1
			// 
			this.txtAIValue1.Location = new System.Drawing.Point(168, 128);
			this.txtAIValue1.Size = new System.Drawing.Size(176, 22);
			this.txtAIValue1.Text = "";
			// 
			// txtAIValue0
			// 
			this.txtAIValue0.Location = new System.Drawing.Point(168, 96);
			this.txtAIValue0.Size = new System.Drawing.Size(176, 22);
			this.txtAIValue0.Text = "";
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
			this.ClientSize = new System.Drawing.Size(458, 368);
			this.Controls.Add(this.chkboxCh7);
			this.Controls.Add(this.chkboxCh6);
			this.Controls.Add(this.chkboxCh5);
			this.Controls.Add(this.chkboxCh4);
			this.Controls.Add(this.chkboxCh3);
			this.Controls.Add(this.chkboxCh2);
			this.Controls.Add(this.chkboxCh1);
			this.Controls.Add(this.chkboxCh0);
			this.Controls.Add(this.txtAIValue7);
			this.Controls.Add(this.txtAIValue6);
			this.Controls.Add(this.txtAIValue5);
			this.Controls.Add(this.txtAIValue4);
			this.Controls.Add(this.txtAIValue3);
			this.Controls.Add(this.txtAIValue2);
			this.Controls.Add(this.txtAIValue1);
			this.Controls.Add(this.txtAIValue0);
			this.Controls.Add(this.txtModule);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.txtReadCount);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.buttonStart);
			this.Text = "Adam5013_17_18 sample program (C#)";
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
						if (RefreshChannelRange())
						{
							RefreshChannelEnable();
							//
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
			if (m_Adam5000Type == Adam5000Type.Adam5013)
				RefreshAdam5013ChannelValue();
			else if (m_Adam5000Type == Adam5000Type.Adam5017)
				RefreshAdam5017ChannelValue();
			else
				RefreshAdam5018ChannelValue();;
		}

		private void RefreshChannelEnable()
		{
			bool bRet;
			bool[] bEnabled;

			bRet = adamCtl.AnalogInput().GetChannelEnabled(m_iSlot, m_iChTotal, out bEnabled);

			if (bRet)
			{
				if (m_iChTotal>0)
					chkboxCh0.Checked = bEnabled[0];
				if (m_iChTotal>1)
					chkboxCh1.Checked = bEnabled[1];
				if (m_iChTotal>2)
					chkboxCh2.Checked = bEnabled[2];
				if (m_iChTotal>3)
					chkboxCh3.Checked = bEnabled[3];
				if (m_iChTotal>4)
					chkboxCh4.Checked = bEnabled[4];
				if (m_iChTotal>5)
					chkboxCh5.Checked = bEnabled[5];
				if (m_iChTotal>6)
					chkboxCh6.Checked = bEnabled[6];
				if (m_iChTotal>7)
					chkboxCh7.Checked = bEnabled[7];
				txtAIValue0.Text = "";
				txtAIValue1.Text = "";
				txtAIValue2.Text = "";
				txtAIValue3.Text = "";
				txtAIValue4.Text = "";
				txtAIValue5.Text = "";
				txtAIValue6.Text = "";
				txtAIValue7.Text = "";
			}
			else
				MessageBox.Show("GetChannelEnabled() failed", "Error");
		}

		private bool RefreshChannelRange()
		{
			bool bRet;

			bRet = adamCtl.AnalogInput().GetInputRange(m_iSlot, 0, out m_byRange);

			if (!bRet)
				MessageBox.Show("Get range failed!", "Error");
			return bRet;
		}

		private void RefreshAdam5013ChannelValue()
		{
			int iStart = m_iSlot*8+1;
			float[] fVal;
			string szFormat, szUnit;


			if (adamCtl.AnalogInput().GetValues(m_iSlot, m_iChTotal, out fVal))
			{
				// floating format
				szFormat = AnalogInput.GetFloatFormat(m_Adam5000Type, m_byRange);
				szUnit = AnalogInput.GetUnitName(m_Adam5000Type, m_byRange);
				//
				if (chkboxCh0.Checked)
					txtAIValue0.Text = fVal[0].ToString(szFormat)+" "+szUnit;
				if (chkboxCh1.Checked)
					txtAIValue1.Text = fVal[1].ToString(szFormat)+" "+szUnit;
				if (chkboxCh2.Checked)
					txtAIValue2.Text = fVal[2].ToString(szFormat)+" "+szUnit;
			
			}
			else
			{
				if (chkboxCh0.Checked)
					txtAIValue0.Text = "Failed to get!";
				if (chkboxCh1.Checked)
					txtAIValue1.Text = "Failed to get!";
				if (chkboxCh2.Checked)
					txtAIValue2.Text = "Failed to get!";
			}
		}

		private void RefreshAdam5017ChannelValue()
		{
			int iStart = m_iSlot*8+1;
			float[] fVal;
			string szFormat, szUnit;

			if (adamCtl.AnalogInput().GetValues(m_iSlot, m_iChTotal, out fVal))
			{
				// floating format
				szFormat = AnalogInput.GetFloatFormat(m_Adam5000Type, m_byRange);
				szUnit = AnalogInput.GetUnitName(m_Adam5000Type, m_byRange);
				//
				if (chkboxCh0.Checked)
					txtAIValue0.Text = fVal[0].ToString(szFormat)+" "+szUnit;
				if (chkboxCh1.Checked)
					txtAIValue1.Text = fVal[1].ToString(szFormat)+" "+szUnit;
				if (chkboxCh2.Checked)
					txtAIValue2.Text = fVal[2].ToString(szFormat)+" "+szUnit;
				if (chkboxCh3.Checked)
					txtAIValue3.Text = fVal[3].ToString(szFormat)+" "+szUnit;
				if (chkboxCh4.Checked)
					txtAIValue4.Text = fVal[4].ToString(szFormat)+" "+szUnit;
				if (chkboxCh5.Checked)
					txtAIValue5.Text = fVal[5].ToString(szFormat)+" "+szUnit;
				if (chkboxCh6.Checked)
					txtAIValue6.Text = fVal[6].ToString(szFormat)+" "+szUnit;
				if (chkboxCh7.Checked)
					txtAIValue7.Text = fVal[7].ToString(szFormat)+" "+szUnit;
			}
			else
			{
				if (chkboxCh0.Checked)
					txtAIValue0.Text = "Failed to get!";
				if (chkboxCh1.Checked)
					txtAIValue1.Text = "Failed to get!";
				if (chkboxCh2.Checked)
					txtAIValue2.Text = "Failed to get!";
				if (chkboxCh3.Checked)
					txtAIValue3.Text = "Failed to get!";
				if (chkboxCh4.Checked)
					txtAIValue4.Text = "Failed to get!";
				if (chkboxCh5.Checked)
					txtAIValue5.Text = "Failed to get!";
				if (chkboxCh6.Checked)
					txtAIValue6.Text = "Failed to get!";
				if (chkboxCh7.Checked)
					txtAIValue7.Text = "Failed to get!";
			}

		}

		private void RefreshAdam5018ChannelValue()
		{
			int iStart = m_iSlot*8+1;
			float[] fVal;
			string szFormat, szUnit;

			if (adamCtl.AnalogInput().GetValues(m_iSlot, m_iChTotal, out fVal))
			{
				// floating format
				szFormat = AnalogInput.GetFloatFormat(m_Adam5000Type, m_byRange);
				szUnit = AnalogInput.GetUnitName(m_Adam5000Type, m_byRange);
				//
				if (chkboxCh0.Checked)
					txtAIValue0.Text = fVal[0].ToString(szFormat)+" "+szUnit;
				if (chkboxCh1.Checked)
					txtAIValue1.Text = fVal[1].ToString(szFormat)+" "+szUnit;
				if (chkboxCh2.Checked)
					txtAIValue2.Text = fVal[2].ToString(szFormat)+" "+szUnit;
				if (chkboxCh3.Checked)
					txtAIValue3.Text = fVal[3].ToString(szFormat)+" "+szUnit;
				if (chkboxCh4.Checked)
					txtAIValue4.Text = fVal[4].ToString(szFormat)+" "+szUnit;
				if (chkboxCh5.Checked)
					txtAIValue5.Text = fVal[5].ToString(szFormat)+" "+szUnit;
				if (chkboxCh6.Checked)
					txtAIValue6.Text = fVal[6].ToString(szFormat)+" "+szUnit;
			}
			else
			{
				if (chkboxCh0.Checked)
					txtAIValue0.Text = "Failed to get!";
				if (chkboxCh1.Checked)
					txtAIValue1.Text = "Failed to get!";
				if (chkboxCh2.Checked)
					txtAIValue2.Text = "Failed to get!";
				if (chkboxCh3.Checked)
					txtAIValue3.Text = "Failed to get!";
				if (chkboxCh4.Checked)
					txtAIValue4.Text = "Failed to get!";
				if (chkboxCh5.Checked)
					txtAIValue5.Text = "Failed to get!";
				if (chkboxCh6.Checked)
					txtAIValue6.Text = "Failed to get!";
			}
		}
	}
}
