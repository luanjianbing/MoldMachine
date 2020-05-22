using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using System.Net.Sockets;
using Advantech.Adam;
using Advantech.Common;

namespace Adam5024
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel panelAO;
		private System.Windows.Forms.ComboBox cbxChannel;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TrackBar trackBar1;
		private System.Windows.Forms.Label lblHigh;
		private System.Windows.Forms.Label lblLow;
		private System.Windows.Forms.Button btnApplyOutput;
		private System.Windows.Forms.TextBox txtOutputValue;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox txtAO3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtAO2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtAO1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtAO0;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtModule;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtReadCount;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button buttonStart;
		private System.Windows.Forms.Timer timer1;
	
		private int m_iSlot, m_iCount, m_iChTotal;
		private bool m_bStart;
		private byte[] m_byRange;
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
			int iIdx;

			adamCtl = new AdamControl();

			m_iSlot = 2;	// the slot index of the module
			m_iCount = 0;	// the counting start from 0
			m_bStart = false;
			adamCtl = new AdamControl();

			m_Adam5000Type = Adam5000Type.Adam5024; // the sample is for ADAM-5024

			m_iChTotal = AnalogOutput.GetChannelTotal(m_Adam5000Type);
			m_byRange = new byte[m_iChTotal];
			for (iIdx=0; iIdx<m_iChTotal; iIdx++)
				cbxChannel.Items.Add(iIdx.ToString());
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
			this.panelAO = new System.Windows.Forms.Panel();
			this.cbxChannel = new System.Windows.Forms.ComboBox();
			this.label11 = new System.Windows.Forms.Label();
			this.trackBar1 = new System.Windows.Forms.TrackBar();
			this.lblHigh = new System.Windows.Forms.Label();
			this.lblLow = new System.Windows.Forms.Label();
			this.btnApplyOutput = new System.Windows.Forms.Button();
			this.txtOutputValue = new System.Windows.Forms.TextBox();
			this.label13 = new System.Windows.Forms.Label();
			this.txtAO3 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtAO2 = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtAO1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtAO0 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtModule = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtReadCount = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.buttonStart = new System.Windows.Forms.Button();
			this.timer1 = new System.Windows.Forms.Timer();
			// 
			// panelAO
			// 
			this.panelAO.BackColor = System.Drawing.Color.SkyBlue;
			this.panelAO.Controls.Add(this.cbxChannel);
			this.panelAO.Controls.Add(this.label11);
			this.panelAO.Controls.Add(this.trackBar1);
			this.panelAO.Controls.Add(this.lblHigh);
			this.panelAO.Controls.Add(this.lblLow);
			this.panelAO.Controls.Add(this.btnApplyOutput);
			this.panelAO.Controls.Add(this.txtOutputValue);
			this.panelAO.Controls.Add(this.label13);
			this.panelAO.Enabled = false;
			this.panelAO.Location = new System.Drawing.Point(16, 216);
			this.panelAO.Size = new System.Drawing.Size(424, 168);
			// 
			// cbxChannel
			// 
			this.cbxChannel.Location = new System.Drawing.Point(128, 16);
			this.cbxChannel.Size = new System.Drawing.Size(112, 20);
			this.cbxChannel.SelectedIndexChanged += new System.EventHandler(this.cbxChannel_SelectedIndexChanged);
			// 
			// label11
			// 
			this.label11.Location = new System.Drawing.Point(16, 16);
			this.label11.Size = new System.Drawing.Size(104, 24);
			this.label11.Text = "Channel index:";
			// 
			// trackBar1
			// 
			this.trackBar1.LargeChange = 16;
			this.trackBar1.Location = new System.Drawing.Point(24, 56);
			this.trackBar1.Maximum = 4095;
			this.trackBar1.Size = new System.Drawing.Size(240, 45);
			this.trackBar1.TickFrequency = 256;
			this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
			// 
			// lblHigh
			// 
			this.lblHigh.Location = new System.Drawing.Point(224, 104);
			this.lblHigh.Size = new System.Drawing.Size(56, 24);
			this.lblHigh.Text = "10 V";
			this.lblHigh.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lblLow
			// 
			this.lblLow.Location = new System.Drawing.Point(8, 104);
			this.lblLow.Size = new System.Drawing.Size(56, 24);
			this.lblLow.Text = "0 V";
			this.lblLow.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// btnApplyOutput
			// 
			this.btnApplyOutput.Location = new System.Drawing.Point(288, 120);
			this.btnApplyOutput.Size = new System.Drawing.Size(128, 32);
			this.btnApplyOutput.Text = "Apply output";
			this.btnApplyOutput.Click += new System.EventHandler(this.btnApplyOutput_Click);
			// 
			// txtOutputValue
			// 
			this.txtOutputValue.Location = new System.Drawing.Point(288, 88);
			this.txtOutputValue.ReadOnly = true;
			this.txtOutputValue.Size = new System.Drawing.Size(88, 22);
			this.txtOutputValue.Text = "0";
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(288, 56);
			this.label13.Size = new System.Drawing.Size(104, 24);
			this.label13.Text = "Value to output:";
			// 
			// txtAO3
			// 
			this.txtAO3.Location = new System.Drawing.Point(168, 176);
			this.txtAO3.Size = new System.Drawing.Size(176, 22);
			this.txtAO3.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 176);
			this.label4.Size = new System.Drawing.Size(136, 20);
			this.label4.Text = "AO-3 value:";
			// 
			// txtAO2
			// 
			this.txtAO2.Location = new System.Drawing.Point(168, 144);
			this.txtAO2.Size = new System.Drawing.Size(176, 22);
			this.txtAO2.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 144);
			this.label3.Size = new System.Drawing.Size(136, 20);
			this.label3.Text = "AO-2 value:";
			// 
			// txtAO1
			// 
			this.txtAO1.Location = new System.Drawing.Point(168, 112);
			this.txtAO1.Size = new System.Drawing.Size(176, 22);
			this.txtAO1.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 112);
			this.label1.Size = new System.Drawing.Size(136, 20);
			this.label1.Text = "AO-1 value:";
			// 
			// txtAO0
			// 
			this.txtAO0.Location = new System.Drawing.Point(168, 80);
			this.txtAO0.Size = new System.Drawing.Size(176, 22);
			this.txtAO0.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 80);
			this.label2.Size = new System.Drawing.Size(136, 20);
			this.label2.Text = "AO-0 value:";
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
			this.ClientSize = new System.Drawing.Size(458, 392);
			this.Controls.Add(this.panelAO);
			this.Controls.Add(this.txtAO3);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtAO2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtAO1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtAO0);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtModule);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.txtReadCount);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.buttonStart);
			this.Text = "Adam5024 sample program (C#)(ADAM-PAC)";
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
				panelAO.Enabled = false;
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
							cbxChannel.SelectedIndex = 0;
							panelAO.Enabled = true;
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
			RefreshChannelValue(0, ref txtAO0);
			RefreshChannelValue(1, ref txtAO1);
			RefreshChannelValue(2, ref txtAO2);
			RefreshChannelValue(3, ref txtAO3);
		}

		private bool RefreshRange(int i_iChannel)
		{
			byte byRange;
			bool bRet;

            bRet = adamCtl.AnalogOutput().GetOutputRange(m_iSlot, i_iChannel, out byRange);
			
			if (bRet)
				m_byRange[i_iChannel] = byRange;
			return bRet;
		}

		private bool RefreshChannelRange()
		{
			bool bRet = true;
			int iIdx;

			for (iIdx=0; iIdx<m_iChTotal; iIdx++)
			{
				bRet = RefreshRange(iIdx);
				if (!bRet)
				{
					MessageBox.Show("Get range failed", "Error");
					break;
				}
			}
			return bRet;
		}

		private void RefreshChannelValue(int i_iChannel, ref TextBox i_txtCh)
		{
			float fValue;
			string szFormat;

			if (adamCtl.AnalogOutput().GetCurrentValue(m_iSlot, i_iChannel, out fValue))
			{
				szFormat = AnalogOutput.GetFloatFormat(m_Adam5000Type, m_byRange[i_iChannel]);
				i_txtCh.Text = fValue.ToString(szFormat)+" "+AnalogOutput.GetUnitName(m_Adam5000Type, m_byRange[i_iChannel]);
			}
			else
				i_txtCh.Text = "Failed to get";
		}

		private void cbxChannel_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			int iCh;
			float fValue;
			Adam5024_OutputRange byRange;

			timer1.Enabled = false;
			iCh = cbxChannel.SelectedIndex;
			fValue = Convert.ToSingle(trackBar1.Value);
			byRange = (Adam5024_OutputRange)m_byRange[iCh];
			if (byRange == Adam5024_OutputRange.mA_0To20) // 0~20mA
			{
				lblLow.Text = "0 mA";
				lblHigh.Text = "20 mA";
				fValue = fValue*20/trackBar1.Maximum;
			}
			else if (byRange == Adam5024_OutputRange.mA_4To20) // 4~20mA
			{
				lblLow.Text = "4 mA";
				lblHigh.Text = "20 mA";
				fValue = 4.0f+fValue*16/trackBar1.Maximum;
			}
			else // 0~10V
			{
				lblLow.Text = "0 V";
				lblHigh.Text = "10 V";
				fValue = fValue*10/trackBar1.Maximum;
			}
			txtOutputValue.Text = fValue.ToString("#0.000");
			timer1.Enabled = true;
		}

		private void trackBar1_ValueChanged(object sender, System.EventArgs e)
		{
			int iCh;
			float fValue;
			Adam5024_OutputRange byRange;

			timer1.Enabled = false;
			iCh = cbxChannel.SelectedIndex;
			fValue = Convert.ToSingle(trackBar1.Value);
			byRange = (Adam5024_OutputRange)m_byRange[iCh];
			if (byRange == Adam5024_OutputRange.mA_0To20) // 0~20mA
				fValue = fValue*20/trackBar1.Maximum;
			else if (byRange == Adam5024_OutputRange.mA_4To20) // 4~20mA
				fValue = 4.0f+fValue*16/trackBar1.Maximum;
			else // 0~10V
				fValue = fValue*10/trackBar1.Maximum;
			txtOutputValue.Text = fValue.ToString("#0.000");
			timer1.Enabled = true;
		}

		private void btnApplyOutput_Click(object sender, System.EventArgs e)
		{
			bool bRet;
			int iChannel;
			float fValue;

			timer1.Enabled = false;
			iChannel = cbxChannel.SelectedIndex;
			fValue = Convert.ToSingle(txtOutputValue.Text);

			bRet = adamCtl.AnalogOutput().SetCurrentValue(m_iSlot, iChannel, fValue);

			if (bRet)
				System.Threading.Thread.Sleep(500);
			else
				MessageBox.Show("Change current value failed!", "Error");
			timer1.Enabled = true;
		}

	}
}
