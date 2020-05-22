using System;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using Advantech.Adam;
using Advantech.Common;

namespace Advantech.Adam
{
	/// <summary>
	/// Summary description for AdamEventServerThread.
	/// </summary>
	public class AdamEventServerThread
	{
		private Advantech.Common.UDPSocketServer m_UDPServer;
		private Advantech.Common.SocketStream  m_SocketStream;
		private string[] m_strIP;
		private int m_iStatus;
		private AdamStreamRecList m_recList;
		private Thread m_UDPServerThread;
		private bool m_bStop;

		private byte[] m_byACK;
		private byte[] m_byQuery;

		private static int ADAM_THREAD_AVAILABLE = 0;
		private static int ADAM_THREAD_BUSY = 1;
		private static int ADAM_THREAD_IDX_EXIT = 0;
		//private static int ADAM_THREAD_IDX_SEND = 1;
		//private static int ADAM_THREAD_IDX_DONE = 2;
		//private static int ADAM_THREAD_IDX_ACK = 1;
		//private static int ADAM_THREAD_IDX_QUERY = 2;

		/// <summary>
		/// Constructer
		/// </summary>
		/// <param name="recList"></param>
		/// <param name="i_IP"></param>
		public AdamEventServerThread(ref AdamStreamRecList recList, string[] i_IP)
		{
			m_UDPServer = null;
			m_SocketStream = null;
			m_recList = recList;
			m_strIP = i_IP;
			m_bStop = false;
			CreateCmdArray();
			
			m_iStatus = ADAM_THREAD_AVAILABLE;
		}

		private void CreateCmdArray()
		{
			int cmdLen = 8;

			//ACK command
			cmdLen = 8;
			m_byACK = new byte[cmdLen];
			m_byACK[0]=Convert.ToByte('M');
			m_byACK[1]=Convert.ToByte('A');
			m_byACK[2]=Convert.ToByte('D');
			m_byACK[3]=Convert.ToByte('A');
			m_byACK[4]=0x02;
			m_byACK[5]=Convert.ToByte('A');
			m_byACK[6]=Convert.ToByte('C');
			m_byACK[7]=Convert.ToByte('K');

			//Query command
			cmdLen = 10;
			m_byQuery = new byte[cmdLen];
			m_byQuery[0]=Convert.ToByte('M');
			m_byQuery[1]=Convert.ToByte('A');
			m_byQuery[2]=Convert.ToByte('D');
			m_byQuery[3]=Convert.ToByte('A');
			m_byQuery[4]=0x02;
			m_byQuery[5]=Convert.ToByte('Q');
			m_byQuery[6]=Convert.ToByte('U');
			m_byQuery[7]=Convert.ToByte('E');
			m_byQuery[8]=Convert.ToByte('R');
			m_byQuery[9]=Convert.ToByte('Y');
		}

		/// <summary>
		/// Start server thread
		/// </summary>
		public void StartThread()
		{
			if (m_UDPServerThread == null)
			{
				m_bStop = false;
				m_UDPServerThread = new System.Threading.Thread(new ThreadStart(this.ThreadMemberFunc));
				m_UDPServerThread.Start();
			}
		}

		/// <summary>
		/// Stop server thread
		/// </summary>
		/// <returns></returns>
		public bool StopThread()
		{
			if (m_UDPServerThread != null)
			{
				m_bStop = true;
				m_UDPServerThread.Abort();
				while (m_iStatus != ADAM_THREAD_IDX_EXIT) 
				{
					Thread.Sleep(10);
				}
				m_UDPServerThread = null;
			}
			return true;
		}

		private void ThreadMemberFunc()
		{
			int[] cntQuery = new int[m_strIP.Length];
			int cntRetry = 0;
			int i;
			byte[] recvBuf = new byte[(int)ADAM_EVENT.MAX_RECV_BUFF_LEN];
			int recvLen;
			IPAddress ipAddress;
			byte[] byIP = null;
			IPEndPoint remoteIPEP;
			EndPoint remoteEP;

			m_UDPServer = new UDPSocketServer();

			try
			{
				m_UDPServer.Create((int)ADAM_EVENT.IN_PORT);

				Socket sk = m_UDPServer.ServerSocket();
				m_SocketStream = new SocketStream(ref sk, m_UDPServer.SendTimeout, m_UDPServer.ReceiveTimeout);

				m_iStatus = ADAM_THREAD_AVAILABLE;

				//First Query
				//Send Query Cmd
				EndPoint remoteEP_Query_First;
				IPEndPoint[] remoteIPEP_Query_First = new IPEndPoint[m_strIP.Length];
				for(i=0;i<m_strIP.Length;i++)
				{
					remoteIPEP_Query_First[i] = new IPEndPoint(IPAddress.Parse(this.m_strIP[i]), (int)ADAM_EVENT.OUT_PORT);
					remoteEP_Query_First = (EndPoint)remoteIPEP_Query_First[i];
					m_SocketStream.SendUDP(ref remoteEP_Query_First, m_byQuery, m_byQuery.Length);
				}
			}
			catch(Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.ToString());
				m_bStop = false;
			}
			while(!m_bStop)
			{
				try
				{
					Thread.Sleep(5);
					m_iStatus = ADAM_THREAD_BUSY;

					if (m_SocketStream.DataArrive((int)ADAM_EVENT.RECV_WAIT))
					{
						for(i=0;i<(int)ADAM_EVENT.MAX_RECV_BUFF_LEN;i++)
							recvBuf[i]=0;
						recvLen = 0;

						if(m_SocketStream.RecvUDP(out remoteEP, recvBuf, out recvLen) && (recvLen == (int)ADAM_EVENT.PATTERN_LEN || recvLen == (int)ADAM_EVENT.PATTERN_LEN32))
						{
							remoteIPEP = (IPEndPoint)remoteEP;
							ipAddress = remoteIPEP.Address;

							for(i=0;i<m_strIP.Length;i++)		
							{
								if(m_strIP[i] == ipAddress.ToString())
								{
									cntQuery[i] = 0;			//Reset Query retry counter

									m_recList.PushStreamRec(ipAddress, recvBuf, recvLen);

									//Send ACK Cmd
									EndPoint remoteEP_ACK;
									IPEndPoint remoteIPEP_ACK = new IPEndPoint(ipAddress, (int)ADAM_EVENT.OUT_PORT);
									remoteEP_ACK = (EndPoint)remoteIPEP_ACK;

									cntRetry = 0;
									while(cntRetry++ < (int)ADAM_EVENT.MAX_RETRY)
									{
										Thread.Sleep(5);
										if(m_SocketStream.SendUDP(ref remoteEP_ACK, m_byACK, m_byACK.Length))
										{
											break;
										}
									}
									break;
								}
							}

						}
					}
					else
					{		
						for(i=0;i<m_strIP.Length;i++)
						{
							if (++cntQuery[i] > 100)
								cntQuery[i] = 2;
							if (cntQuery[i] > 2) // retry more than 2 times
							{
								IPAddress ipTemp;
								ipTemp = IPAddress.Parse(this.m_strIP[i]);
								byIP = ipTemp.GetAddressBytes();
								m_recList.PushEventRec(byIP, 0, 0, (int)EVENT_TYPE.CONNECT, (int)EVENT_STATUS.LOST, 0);
							}

							//Send Query Cmd
							EndPoint remoteEP_Query;
							IPEndPoint remoteIPEP_Query = new IPEndPoint(IPAddress.Parse(this.m_strIP[i]), (int)ADAM_EVENT.OUT_PORT);
							remoteEP_Query = (EndPoint)remoteIPEP_Query;
							m_SocketStream.SendUDP(ref remoteEP_Query, m_byQuery, m_byQuery.Length);
						}
					}
				}
				catch(ThreadAbortException exAbort)
				{
					string strTemp = exAbort.Message;
					m_SocketStream = null;
					if(m_UDPServer!=null)
					{
						m_UDPServer.Terminate();
						m_UDPServer = null;
					}
					m_iStatus = ADAM_THREAD_IDX_EXIT;
					break;
				}
				catch(Exception ex)
				{
					System.Windows.Forms.MessageBox.Show("Exception:"+ex.ToString()+"\nThe server will terminate!");
					m_SocketStream = null;
					if(m_UDPServer!=null)
					{
						m_UDPServer.Terminate();
						m_UDPServer = null;
					}
					m_iStatus = ADAM_THREAD_IDX_EXIT;
					break;
				}
			}

			m_SocketStream = null;
			if(m_UDPServer!=null)
			{
				m_UDPServer.Terminate();
				m_UDPServer = null;
			}
			m_iStatus = ADAM_THREAD_IDX_EXIT;
		}
	}
}
