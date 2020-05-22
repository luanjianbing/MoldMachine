using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using System.Threading;
using Advantech.Adam;
using Advantech.Common;

namespace Adam5kTcpEvent
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox txtPort;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TreeView treeViewDS;
		private System.Windows.Forms.ListBox listBoxMsg;
		private System.Windows.Forms.Button btnStart;
		private System.Windows.Forms.Label label2;
		private System.ComponentModel.IContainer components = null;

		private Advantech.Adam.Adam5000Type[] m_Adam5000Type;
		private string[] m_strHostIP;

		//Event Trigger 5000TCP
		private AdamStreamRecList  StreamRecList;
		private AdamEventServerThread udpServerThread;
		private int m_iCount;
		private bool m_bStopUI;
		private bool m_bTerminateUI;
		private Thread m_uiThread;

		private System.Windows.Forms.Panel panel1;

		private string m_MonitorDataStreamIP;

		private delegate void UpdateListBoxCallback(string strMsg);
		private delegate void UpdateTreeViewCallback(string strMsg, int slot);

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			StreamRecList = new AdamStreamRecList();

			m_Adam5000Type = new Adam5000Type[8];

			m_strHostIP = new string[1];
			m_strHostIP[0] = "10.0.0.11";	

			//m_strHostIP = new string[3];
			//m_strHostIP[0] = "10.0.0.11";					//Adam5000/TCP IP
			//m_strHostIP[1] = "10.0.0.21";					//Adam5000/TCP IP
			//m_strHostIP[2] = "10.0.0.31";					//Adam5000/TCP IP

			
			// for those who wants to listen the data streaming from ADAM-5000TCP
			// you have to make sure the module type you are listening to.
			m_MonitorDataStreamIP = m_strHostIP[0];

			m_Adam5000Type[0] = Adam5000Type.Adam5051;
			m_Adam5000Type[1] = Adam5000Type.Non;
			m_Adam5000Type[2] = Adam5000Type.Non;
			m_Adam5000Type[3] = Adam5000Type.Non;
			m_Adam5000Type[4] = Adam5000Type.Non;
			m_Adam5000Type[5] = Adam5000Type.Non;
			m_Adam5000Type[6] = Adam5000Type.Non;
			m_Adam5000Type[7] = Adam5000Type.Non;
			//

/*
			m_MonitorDataStreamIP = m_strHostIP[1];

			m_Adam5000Type[0] = Adam5000Type.Non;
			m_Adam5000Type[1] = Adam5000Type.Non;
			m_Adam5000Type[2] = Adam5000Type.Adam5051;
			m_Adam5000Type[3] = Adam5000Type.Non;
			m_Adam5000Type[4] = Adam5000Type.Non;
			m_Adam5000Type[5] = Adam5000Type.Non;
			m_Adam5000Type[6] = Adam5000Type.Non;
			m_Adam5000Type[7] = Adam5000Type.Non;
*/

/*
			m_MonitorDataStreamIP = m_strHostIP[2];

			m_Adam5000Type[0] = Adam5000Type.Non;
			m_Adam5000Type[1] = Adam5000Type.Non;
			m_Adam5000Type[2] = Adam5000Type.Non;
			m_Adam5000Type[3] = Adam5000Type.Adam5056;
			m_Adam5000Type[4] = Adam5000Type.Adam5051;
			m_Adam5000Type[5] = Adam5000Type.Non;
			m_Adam5000Type[6] = Adam5000Type.Non;
			m_Adam5000Type[7] = Adam5000Type.Non;
*/
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtPort = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.treeViewDS = new System.Windows.Forms.TreeView();
			this.listBoxMsg = new System.Windows.Forms.ListBox();
			this.btnStart = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.groupBox1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtPort
			// 
			this.txtPort.Enabled = false;
			this.txtPort.Location = new System.Drawing.Point(64, 16);
			this.txtPort.Name = "txtPort";
			this.txtPort.Size = new System.Drawing.Size(88, 22);
			this.txtPort.TabIndex = 10;
			this.txtPort.Text = "9168";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.treeViewDS);
			this.groupBox1.Controls.Add(this.listBoxMsg);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 56);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.groupBox1.Size = new System.Drawing.Size(576, 342);
			this.groupBox1.TabIndex = 12;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Receiving Data";
			// 
			// treeViewDS
			// 
			this.treeViewDS.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeViewDS.ImageIndex = -1;
			this.treeViewDS.Location = new System.Drawing.Point(216, 18);
			this.treeViewDS.Name = "treeViewDS";
			this.treeViewDS.SelectedImageIndex = -1;
			this.treeViewDS.Size = new System.Drawing.Size(357, 321);
			this.treeViewDS.TabIndex = 1;
			// 
			// listBoxMsg
			// 
			this.listBoxMsg.Dock = System.Windows.Forms.DockStyle.Left;
			this.listBoxMsg.HorizontalScrollbar = true;
			this.listBoxMsg.ItemHeight = 12;
			this.listBoxMsg.Location = new System.Drawing.Point(3, 18);
			this.listBoxMsg.Name = "listBoxMsg";
			this.listBoxMsg.Size = new System.Drawing.Size(213, 316);
			this.listBoxMsg.TabIndex = 0;
			// 
			// btnStart
			// 
			this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnStart.Location = new System.Drawing.Point(472, 16);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(88, 24);
			this.btnStart.TabIndex = 11;
			this.btnStart.Text = "Start";
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(48, 20);
			this.label2.TabIndex = 8;
			this.label2.Text = "Port:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.btnStart);
			this.panel1.Controls.Add(this.txtPort);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(576, 56);
			this.panel1.TabIndex = 13;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 15);
			this.ClientSize = new System.Drawing.Size(576, 398);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.panel1);
			this.Name = "Form1";
			this.Text = "Adam-5000/TCP Event Sample (VC#)";
			this.Click += new System.EventHandler(this.FormDataStream_Load);
			this.Load += new System.EventHandler(this.FormDataStream_Load);
			this.Closed += new System.EventHandler(this.FormDataStream_Closed);
			this.groupBox1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		
		private void FormDataStream_Load(object sender, System.EventArgs e)
		{
			m_bTerminateUI = true;
			InitialTreeNode();
		}

		private void FormDataStream_Closed(object sender, System.EventArgs e)
		{
			StopEventRoutineThread();
			if(udpServerThread!=null)
			{
				udpServerThread.StopThread();
				udpServerThread = null;
			}
		}

		private void btnStart_Click(object sender, System.EventArgs e)
		{
			if(btnStart.Text == "Start")
			{
				btnStart.Text = "Stop";

				udpServerThread = new AdamEventServerThread(ref StreamRecList, this.m_strHostIP);
				udpServerThread.StartThread();

				StartEventRoutineThread();
			}
			else
			{
				StopEventRoutineThread();

				btnStart.Text = "Start";
				udpServerThread.StopThread();
				udpServerThread = null;
				StreamRecList.ClearStreamRec();
			}
		}

		private void AddListBoxItem(string szMsg)
		{
			if(listBoxMsg.InvokeRequired)
				this.listBoxMsg.BeginInvoke(new UpdateListBoxCallback(AddListBoxItem), new object[] {szMsg});
			else
			{
				int iLimit = 300;
				listBoxMsg.BeginUpdate();
				if(listBoxMsg.Items.Count>iLimit)
				{
					listBoxMsg.Items.Clear();
				}

				listBoxMsg.Items.Add(szMsg);
				listBoxMsg.SelectedIndex = listBoxMsg.Items.Count - 1;
				listBoxMsg.EndUpdate();
			}
		}

		private void StartEventRoutineThread()
		{
			if (m_uiThread == null)
			{
				m_bStopUI = false;
				m_uiThread = new System.Threading.Thread(new ThreadStart(this.EventRoutine));
				m_uiThread.Start();
			}
		}

		private bool StopEventRoutineThread()
		{
			if (m_uiThread != null)
			{
				m_bStopUI = true;
				while (!m_bTerminateUI) 
				{
					Thread.Sleep(10);
				}
				m_uiThread = null;
			}
			return true;
		}

		private void EventRoutine()
		{
			byte[] byData;
			DataStructure data;
			m_bTerminateUI = false;

			while(!m_bStopUI)
			{
				Thread.Sleep(5);
				if(UpdateEvent())
				{
					this.m_iCount++;

					//Show Data streaming
					if(StreamRecList.GetLastStreamRec(this.m_MonitorDataStreamIP, out byData))
					{	
						data = new DataStructure();
						data.SetData(byData, byData.Length);
						DisplayInform(data);
						data = null;
					}
					/////
				}
			}
			m_bTerminateUI = true;
		}

		private bool UpdateEvent()
		{
			byte[] byIP;
			int iSlot, iChannel, iType, iStatus;
			string strTime;
			long lVal;

			string s0,s1,s2,s3,s4,s5,s6;

			if(StreamRecList.PopEventRec(out byIP, out iSlot, out iChannel, out iType, out iStatus, out strTime, out lVal))
			{
				s0 = byIP[0].ToString()+"."+byIP[1].ToString()+"."+byIP[2].ToString()+"."+byIP[3].ToString();
				s1 = strTime;
				s2 = iSlot.ToString();
				s3 = iChannel.ToString();
				s6 = lVal.ToString();

				switch(iType)
				{
					case (int)EVENT_TYPE.DIO:
						s4 = "DIO event";
						break;
					case (int)EVENT_TYPE.HIALARM:
						s4 = "High Alarm event";
						break;
					case (int)EVENT_TYPE.LOALARM:
						s4 = "Low Alarm event";
						break;
					case (int)EVENT_TYPE.CONNECT:
						s4 = "Connection";
						break;
					default:
						s4 = "unknown event type";
						break;
				}
 
				switch(iStatus)
				{
					case (int)EVENT_STATUS.ON_TO_OFF:
						s5 = "'ON' to 'OFF'";
						break;
					case (int)EVENT_STATUS.OFF_TO_ON:
						s5 = "'OFF' to 'ON'";
						break;
					case (int)EVENT_STATUS.NO_CHANGE:
						s5 = "No change";
						break;
					case (int)EVENT_STATUS.LOST:
						s5 = "Lost";
						break;
					default:
						s5 = "unknown status";
						break;
				}

				AddListBoxItem("Count="+ m_iCount.ToString());
				AddListBoxItem("IP: "+s0);
				AddListBoxItem("("+s1+")");
				AddListBoxItem("--Slot("+s2+"), Ch("+s3+")");
				AddListBoxItem("--Val("+s6+")");
				AddListBoxItem("--Type("+s4+")");
				AddListBoxItem("--Event("+s5+")");
				AddListBoxItem("");				
				return true;
			}
			return false;
		}

		private void InitialTreeNode()
		{
			string strHostIP = m_MonitorDataStreamIP;

			int i;
			string strTemp = "";	

			strTemp = "HOST "+"["+ strHostIP +"]";
			treeViewDS.Nodes.Add(strTemp);
			
			for(i=0;i<this.m_Adam5000Type.Length;i++)
				treeViewDS.Nodes[0].Nodes.Add(m_Adam5000Type[i].ToString());

			for(i=0;i<this.m_Adam5000Type.Length;i++)
				treeViewDS.Nodes[0].Nodes[i].Nodes.Add("Data:");


			treeViewDS.ExpandAll();
		}

		#region Display functions
		private void DisplayInform(DataStructure data)
		{
			// for those who wants to listen the data streaming from ADAM-6000
			// you have to make sure the module type you are listening to.

			string strMsg = "Data:";
			int iSlotIndex = 0;
			for(iSlotIndex=0;iSlotIndex<this.m_Adam5000Type.Length;iSlotIndex++)
			{
				switch(this.m_Adam5000Type[iSlotIndex])
				{
					case Adam5000Type.Adam5013:
						strMsg = DisplayAdam5013(data, iSlotIndex);
						break;
					case Adam5000Type.Adam5017:
						strMsg = DisplayAdam5017(data, iSlotIndex);
						break;
					case Adam5000Type.Adam5018:
						strMsg = DisplayAdam5018(data, iSlotIndex);
						break;
					case Adam5000Type.Adam5024:
						strMsg = DisplayAdam5024(data, iSlotIndex);
						break;
					case Adam5000Type.Adam5050:
						strMsg = DisplayAdam5050(data, iSlotIndex);
						break;
					case Adam5000Type.Adam5051:
						strMsg = DisplayAdam5051(data, iSlotIndex);
						break;
					case Adam5000Type.Adam5052:
						strMsg = DisplayAdam5052(data, iSlotIndex);
						break;
					case Adam5000Type.Adam5055:
						strMsg = DisplayAdam5055(data, iSlotIndex);
						break;
					case Adam5000Type.Adam5056:
						strMsg = DisplayAdam5056(data, iSlotIndex);
						break;
					case Adam5000Type.Adam5060:
						strMsg = DisplayAdam5060(data, iSlotIndex);
						break;
					case Adam5000Type.Adam5068:
						strMsg = DisplayAdam5068(data, iSlotIndex);
						break;
					case Adam5000Type.Adam5069:
						strMsg = DisplayAdam5069(data, iSlotIndex);
						break;
					case Adam5000Type.Adam5080:
						strMsg = DisplayAdam5080(data, iSlotIndex);
						break;
					case Adam5000Type.Adam5081:
						strMsg = DisplayAdam5081(data, iSlotIndex);
						break;
					default:
						strMsg = "";
						break;
				}

				ChangeTreeViewData(strMsg, iSlotIndex);
			}
	
		}

		private void ChangeTreeViewData(string szMsg, int iSlot)
		{
			if(treeViewDS.InvokeRequired)
				this.treeViewDS.BeginInvoke(new UpdateTreeViewCallback(ChangeTreeViewData), new object[] {szMsg, iSlot});
			else
			{
				treeViewDS.Nodes[0].Nodes[iSlot].Nodes[0].Text = szMsg;
			}
		}

		private string DisplayAdam5050(DataStructure data, int iSlot)
		{
			string szMsg;
			szMsg = string.Format("    DIO=0x{0:X04}", data.DIO(iSlot) );
			return szMsg;
		}

		private string DisplayAdam5051(DataStructure data, int iSlot)
		{
			string szMsg = DisplayAdam5050(data, iSlot);
			return szMsg;
		}

		private string DisplayAdam5052(DataStructure data, int iSlot)
		{
			string szMsg = DisplayAdam5050(data, iSlot);
			return szMsg;
		}

		private string DisplayAdam5055(DataStructure data, int iSlot)
		{
			string szMsg = DisplayAdam5050(data, iSlot);
			return szMsg;
		}

		private string DisplayAdam5056(DataStructure data, int iSlot)
		{
			string szMsg = DisplayAdam5050(data, iSlot);
			return szMsg;
		}

		private string DisplayAdam5060(DataStructure data, int iSlot)
		{
			string szMsg = DisplayAdam5050(data, iSlot);
			return szMsg;
		}

		private string DisplayAdam5068(DataStructure data, int iSlot)
		{
			string szMsg = DisplayAdam5050(data, iSlot);
			return szMsg;
		}

		private string DisplayAdam5069(DataStructure data, int iSlot)
		{
			string szMsg = DisplayAdam5050(data, iSlot);
			return szMsg;
		}

		private string DisplayAdam5013(DataStructure data, int iSlot)
		{
			string szMsg;
			szMsg = string.Format("    Ch[0]=0x{0:X04}, Ch[1]=0x{1:X04}, Ch[2]=0x{2:X04}",
				data.AIO(iSlot*8), data.AIO(iSlot*8+1), data.AIO(iSlot*8+2));
			return szMsg;
		}

		private string DisplayAdam5017(DataStructure data, int iSlot)
		{
			string szMsg;
			szMsg = string.Format("    Ch[0]=0x{0:X04}, Ch[1]=0x{1:X04}, Ch[2]=0x{2:X04}, Ch[3]=0x{3:X04}, Ch[4]=0x{4:X04}, Ch[5]=0x{5:X04}, Ch[6]=0x{6:X04}, Ch[7]=0x{7:X04}",
				data.AIO(iSlot*8), data.AIO(iSlot*8+1), data.AIO(iSlot*8+2), data.AIO(iSlot*8+3),
				data.AIO(iSlot*8+4), data.AIO(iSlot*8+5), data.AIO(iSlot*8+6), data.AIO(iSlot*8+7));
			return szMsg;
		}

		private string DisplayAdam5018(DataStructure data, int iSlot)
		{
			string szMsg;
			szMsg = string.Format("    Ch[0]=0x{0:X04}, Ch[1]=0x{1:X04}, Ch[2]=0x{2:X04}, Ch[3]=0x{3:X04}, Ch[4]=0x{4:X04}, Ch[5]=0x{5:X04}, Ch[6]=0x{6:X04}",
				data.AIO(iSlot*8), data.AIO(iSlot*8+1), data.AIO(iSlot*8+2), data.AIO(iSlot*8+3),
				data.AIO(iSlot*8+4), data.AIO(iSlot*8+5), data.AIO(iSlot*8+6));
			return szMsg;
		}

		private string DisplayAdam5024(DataStructure data, int iSlot)
		{
			string szMsg;
			szMsg = string.Format("    Ch[0]=0x{0:X04}, Ch[1]=0x{1:X04}, Ch[2]=0x{2:X04}, Ch[3]=0x{3:X04}",
				data.AIO(iSlot*8), data.AIO(iSlot*8+1), data.AIO(iSlot*8+2), data.AIO(iSlot*8+3));
			return szMsg;
		}

		private string DisplayAdam5080(DataStructure data, int iSlot)
		{
			string szMsg;
			UInt32 uVal0, uVal1, uVal2, uVal3;

			uVal0 = data.AIO(iSlot*8+1);
			uVal0 = Convert.ToUInt32((uint)uVal0*65536+data.AIO(iSlot*8));
			uVal1 = data.AIO(iSlot*8+3);
			uVal1 = Convert.ToUInt32((uint)uVal1*65536+data.AIO(iSlot*8+2));
			uVal2 = data.AIO(iSlot*8+5);
			uVal2 = Convert.ToUInt32((uint)uVal2*65536+data.AIO(iSlot*8+4));
			uVal3 = data.AIO(iSlot*8+7);
			uVal3 = Convert.ToUInt32((uint)uVal3*65536+data.AIO(iSlot*8+6));

			szMsg = string.Format("Slot[{0}]", iSlot);
			szMsg = string.Format("    Ch[0]={0}, Ch[1]={1}, Ch[2]={2}, Ch[3]={3}",
				uVal0, uVal1, uVal2, uVal3);
			return szMsg;
		}

		private string DisplayAdam5081(DataStructure data, int iSlot)
		{
			string szMsg;
			UInt32 uVal0, uVal1, uVal2, uVal3/*, uVal4, uVal5, uVal6, uVal7*/;

			uVal0 = data.AIO(iSlot*8+1);
			uVal0 = Convert.ToUInt32((uint)uVal0*65536+data.AIO(iSlot*8));
			uVal1 = data.AIO(iSlot*8+3);
			uVal1 = Convert.ToUInt32((uint)uVal1*65536+data.AIO(iSlot*8+2));
			uVal2 = data.AIO(iSlot*8+5);
			uVal2 = Convert.ToUInt32((uint)uVal2*65536+data.AIO(iSlot*8+4));
			uVal3 = data.AIO(iSlot*8+7);
			uVal3 = Convert.ToUInt32((uint)uVal3*65536+data.AIO(iSlot*8+6));

			szMsg = string.Format("Slot[{0}]", iSlot);
			szMsg = string.Format("    Ch[0]={0}, Ch[1]={1}, Ch[2]={2}, Ch[3]={3}",
				uVal0, uVal1, uVal2, uVal3);

			return szMsg;
		}
		#endregion
	}
}
