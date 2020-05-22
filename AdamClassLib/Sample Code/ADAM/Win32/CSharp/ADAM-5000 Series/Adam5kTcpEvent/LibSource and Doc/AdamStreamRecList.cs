using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;

namespace Advantech.Adam
{
	#region /-- enum parameters --/

	/// <summary>
	/// Adam event parameters
	/// </summary>
	public enum ADAM_EVENT : int
	{
		/// <summary>
		/// Out port
		/// </summary>
		OUT_PORT	= 9168,
		/// <summary>
		/// In port
		/// </summary>
		IN_PORT		= 8168,
		/// <summary>
		/// Maximum command
		/// </summary>
		MAX_CMD		= 256,
		/// <summary>
		/// Maximum IP
		/// </summary>
		MAX_IP		= 32,
		/// <summary>
		/// Receive waiting time
		/// </summary>
		RECV_WAIT	= 1000,
		/// <summary>
		/// Quit waiting time
		/// </summary>
		QUIT_WAIT	= 50,
		/// <summary>
		/// Mode waiting time
		/// </summary>
		MOD_WAIT	= 3000,
		/// <summary>
		/// Pattern length
		/// </summary>
		PATTERN_LEN	= 262,
		/// <summary>
		/// Pattern length 2
		/// </summary>
		PATTERN_LEN32= 390,
		/// <summary>
		/// Maximum retry times
		/// </summary>
		MAX_RETRY	= 5,
		/// <summary>
		/// Maximum received buffer length
		/// </summary>
		MAX_RECV_BUFF_LEN	= 2048,
		/// <summary>
		/// Maximum number
		/// </summary>
		MAX_NUM		= 8,
		/// <summary>
		/// IsEvenTrigData_DataChange
		/// </summary>
		IsEvenTrigData_DataChange		= 0x03,	//Query
		/// <summary>
		/// IsEvenTrigData
		/// </summary>
		IsEvenTrigData					= 0x02
	}

	/// <summary>
	/// Event type
	/// </summary>
	public enum EVENT_TYPE : int
	{
		/// <summary>
		/// DIO
		/// </summary>
		DIO		= 0x1000,
		/// <summary>
		/// AIO
		/// </summary>
		AIO		= 0x2000,
		/// <summary>
		/// Hi alarm
		/// </summary>
		HIALARM	= 0x3000,
		/// <summary>
		/// Lo alarm
		/// </summary>
		LOALARM	= 0x4000,
		/// <summary>
		/// Connect
		/// </summary>
		CONNECT	= 0xF000
	}

	/// <summary>
	/// Event status
	/// </summary>
	public enum EVENT_STATUS : int
	{
		/// <summary>
		/// No change
		/// </summary>
		NO_CHANGE	= 0x000,
		/// <summary>
		/// On to off
		/// </summary>
		ON_TO_OFF	= 0x100,
		/// <summary>
		/// Off to On
		/// </summary>
		OFF_TO_ON	= 0x200,
		/// <summary>
		/// Lost
		/// </summary>
		LOST		= 0xFFF
	}
	#endregion

	#region /-- class AdamStreamRec --/
	/// <summary>
	/// Class AdamStreamRec for event trigger
	/// </summary>
	public class AdamStreamRec					//262 bytes (Fixed Modbus address) //390 bytes (Flexible Modbus address) 
	{
		/// <summary>
		/// Header : 4 bytes
		/// </summary>
		public byte[] m_Header;	
		/// <summary>
		/// Function code : 1 bytes
		/// </summary>
		public byte m_FcnCode;
		/// <summary>
		/// Package number : 1 bytes
		/// </summary>
		public byte m_PackageNum;
		/// <summary>
		/// DIO data : 16 bytes
		/// </summary>
		public byte[] m_Data_DIO;
		/// <summary>
		/// AIO data : 128 bytes (Fixed Modbus address)
		/// </summary>
		public byte[] m_Data_AIO;	// //256 bytes (Flexible Modbus address) 
		/// <summary>
		/// Hi alarm data : 8 bytes
		/// </summary>
		public byte[] m_HiAlarm;
		/// <summary>
		/// Lo alarm data : 8 bytes
		/// </summary>
		public byte[] m_LoAlarm;
		/// <summary>
		/// Pre DIO data : 16 bytes
		/// </summary>
		public byte[] m_Pre_Data_DIO;
		/// <summary>
		/// Pre Hi alarm data : 8 bytes
		/// </summary>
		public byte[] m_Pre_HiAlarm;
		/// <summary>
		/// Pre Lo alarm data : 8 bytes
		/// </summary>
		public byte[] m_Pre_LoAlarm; 
		
		/// <summary>
		/// DIO off to on mask : 16 bytes
		/// </summary>
		public byte[] m_Mask_DIO_Off2On;
		/// <summary>
		/// DIO on to off mask : 16 bytes
		/// </summary>
		public byte[] m_Mask_DIO_On2Off;
		/// <summary>
		/// Hi alarm off to on mask : 8 bytes
		/// </summary>
		public byte[] m_Mask_HiAlarm_Off2On;
		/// <summary>
		/// Hi alarm on to off mask : 8 bytes
		/// </summary>
		public byte[] m_Mask_HiAlarm_On2Off; 
		/// <summary>
		/// Lo alarm off to on mask : 8 bytes
		/// </summary>
		public byte[] m_Mask_LoAlarm_Off2On;
		/// <summary>
		/// Lo alarm on to off mask: 8 bytes
		/// </summary>
		public byte[] m_Mask_LoAlarm_On2Off;	

		/// <summary>
		/// IP
		/// </summary>
		public byte[] m_byIP;
		/// <summary>
		/// DataStream struct
		/// </summary>
		public byte[] m_Data;					

		/// <summary>
		/// Constructer
		/// </summary>
		/// <param name="i_byRecv"></param>
		/// <param name="i_byIP"></param>
		/// <param name="i_bIsFlexibleModAddrFW"></param>
		public AdamStreamRec(byte[] i_byRecv, byte[] i_byIP, bool i_bIsFlexibleModAddrFW)
		{
			int idx = 0;

			m_Header				= new byte[4];	Array.Copy(i_byRecv,idx,m_Header,0,4);			idx+=4;

			m_FcnCode = i_byRecv[idx];																idx+=1;
			m_PackageNum = i_byRecv[idx];															idx+=1;

			m_Data_DIO				= new byte[16];	Array.Copy(i_byRecv,idx,m_Data_DIO,0,16);		idx+=16;

			if(i_bIsFlexibleModAddrFW)
			{
				m_Data_AIO				= new byte[128*2];Array.Copy(i_byRecv,idx,m_Data_AIO,0,128*2);		idx+=128*2;
			}
			else
			{
				m_Data_AIO				= new byte[128];Array.Copy(i_byRecv,idx,m_Data_AIO,0,128);		idx+=128;
			}

			m_HiAlarm				= new byte[8];	Array.Copy(i_byRecv,idx,m_HiAlarm,0,8);			idx+=8;
			m_LoAlarm				= new byte[8];	Array.Copy(i_byRecv,idx,m_LoAlarm,0,8);			idx+=8;

			m_Pre_Data_DIO			= new byte[16];	Array.Copy(i_byRecv,idx,m_Pre_Data_DIO,0,16);		idx+=16;
			m_Pre_HiAlarm			= new byte[8];	Array.Copy(i_byRecv,idx,m_Pre_HiAlarm,0,8);			idx+=8;
			m_Pre_LoAlarm			= new byte[8];	Array.Copy(i_byRecv,idx,m_Pre_LoAlarm,0,8);			idx+=8;

			m_Mask_DIO_Off2On		= new byte[16];	Array.Copy(i_byRecv,idx,m_Mask_DIO_Off2On,0,16);	idx+=16;	
			m_Mask_DIO_On2Off		= new byte[16];	Array.Copy(i_byRecv,idx,m_Mask_DIO_On2Off,0,16);	idx+=16;	
			m_Mask_HiAlarm_Off2On	= new byte[8];	Array.Copy(i_byRecv,idx,m_Mask_HiAlarm_Off2On,0,8);	idx+=8;
			m_Mask_HiAlarm_On2Off	= new byte[8];	Array.Copy(i_byRecv,idx,m_Mask_HiAlarm_On2Off,0,8);	idx+=8;
			m_Mask_LoAlarm_Off2On	= new byte[8];	Array.Copy(i_byRecv,idx,m_Mask_LoAlarm_Off2On,0,8);	idx+=8;
			m_Mask_LoAlarm_On2Off	= new byte[8];	Array.Copy(i_byRecv,idx,m_Mask_LoAlarm_On2Off,0,8);	idx+=8;



			m_byIP = new byte[4];	Array.Copy(i_byIP,0,m_byIP,0,4);

			m_Data = new byte[6+m_Data_DIO.Length + m_Data_AIO.Length+m_HiAlarm.Length+m_LoAlarm.Length];
			Array.Copy(i_byRecv  ,0,m_Data, 0,6+m_Data_DIO.Length + m_Data_AIO.Length+m_HiAlarm.Length+m_LoAlarm.Length);
		}
	}
	#endregion

	#region /-- class AdamEvent --/
	/// <summary>
	/// Class AdamEvent for event trigger 
	/// </summary>
	public class AdamEvent					
	{
		/// <summary>
		/// IP
		/// </summary>
		public byte[] m_byIP;
		/// <summary>
		/// Time
		/// </summary>
		public System.DateTime m_Time;
		/// <summary>
		/// Slot
		/// </summary>
		public int m_iSlot;
		/// <summary>
		/// Channel
		/// </summary>
		public int m_iChannel;
		/// <summary>
		/// Event Type
		/// </summary>
		public int m_iType;
		/// <summary>
		/// Event status
		/// </summary>
		public int m_iStatus;
		/// <summary>
		/// Value
		/// </summary>
		public long m_lVal;

		/// <summary>
		/// Constructer
		/// </summary>
		/// <param name="i_byIP"></param>
		/// <param name="i_iSlot"></param>
		/// <param name="i_iChannel"></param>
		/// <param name="i_iType"></param>
		/// <param name="i_iStatus"></param>
		/// <param name="i_lVal"></param>
		public AdamEvent(byte[] i_byIP, int i_iSlot, int i_iChannel, int i_iType, int i_iStatus, long i_lVal)
		{
			m_byIP = new byte[i_byIP.Length];
			Array.Copy(i_byIP,0,m_byIP,0,i_byIP.Length);

			m_Time = DateTime.Now;
			m_iSlot = i_iSlot;
			m_iChannel = i_iChannel;
			m_iType = i_iType;
			m_iStatus = i_iStatus;
			m_lVal = i_lVal;
		}
	}
	#endregion

	/// <summary>
	/// Class AdamStreamRecList for event trigger.
	/// </summary>
	public class AdamStreamRecList
	{
		private ArrayList m_ArrayList;
		private ArrayList m_ArrayList_Event;
		private bool m_bIsFlexibleModAddrFW;

		/// <summary>
		/// Constructer
		/// </summary>
		public AdamStreamRecList()
		{
			m_ArrayList = new ArrayList();
			m_ArrayList_Event = new ArrayList();
			m_bIsFlexibleModAddrFW = false;	
		}

		//public AdamStreamRecList(bool i_bIsFlexibleModAddrFW)
		//{
		//	m_ArrayList = new ArrayList();
		//	m_ArrayList_Event = new ArrayList();
		//	m_bIsFlexibleModAddrFW = i_bIsFlexibleModAddrFW;
		//}

		/// <summary>
		/// Clear received stream
		/// </summary>
		public void ClearStreamRec()
		{
			if(m_ArrayList!=null)
				m_ArrayList.Clear();
			if(m_ArrayList_Event!=null)
				m_ArrayList_Event.Clear();
		}

		private void ClearPreStreamRec()
		{
			if(m_ArrayList.Count>300)
			{
				m_ArrayList.RemoveRange(0, m_ArrayList.Count-100);
			}
		}

		/// <summary>
		/// Push received stream
		/// </summary>
		/// <param name="i_ipAddress"></param>
		/// <param name="i_byData"></param>
		/// <param name="i_recvLen"></param>
		public void PushStreamRec(IPAddress i_ipAddress, byte[] i_byData, int i_recvLen)
		{
			int slotIdx, chanIdx;
			byte byHi;
			byte byLo;
			byte byHi_Pre;
			byte byLo_Pre;

			IPAddress ipAddress = i_ipAddress;
			byte[] byIP = ipAddress.GetAddressBytes();

			byte[] byData = new byte[i_recvLen];
			Array.Copy(i_byData,0,byData,0,i_recvLen);

			AdamStreamRec adamStreamRec = new AdamStreamRec(byData, byIP, m_bIsFlexibleModAddrFW);

			if(m_ArrayList.Count==0)						//First Query
				m_ArrayList.Add(adamStreamRec);
			else
			{
				//AdamStreamRec adamStreamRec_Pre = (AdamStreamRec)m_ArrayList[m_ArrayList.Count-1];

				//if(adamStreamRec_Pre.m_PackageNum != adamStreamRec.m_PackageNum)
				{
					if(adamStreamRec.m_FcnCode == (byte)ADAM_EVENT.IsEvenTrigData)	//IsEvenTrigData : 0x02
					{
						m_ArrayList.Add(adamStreamRec);					

						//DIO
						//if(!Array.Equals(adamStreamRec_Pre.m_Data_DIO, adamStreamRec.m_Data_DIO))
						{
							for (slotIdx=0; slotIdx<8; slotIdx++)
							{
								byLo_Pre = adamStreamRec.m_Pre_Data_DIO[slotIdx*2];
								byHi_Pre = adamStreamRec.m_Pre_Data_DIO[slotIdx*2+1];

								byLo = adamStreamRec.m_Data_DIO[slotIdx*2];
								byHi = adamStreamRec.m_Data_DIO[slotIdx*2+1];
								for (chanIdx=0; chanIdx<16; chanIdx++)
								{
									if(chanIdx<8)
									{
										if( ((byLo_Pre>>chanIdx)&0x01) > ((byLo>>chanIdx)&0x01) )
										{
											//On -> Off
											PushEventRec(byIP, slotIdx, chanIdx, (int)EVENT_TYPE.DIO, (int)EVENT_STATUS.ON_TO_OFF, ((byLo>>chanIdx)&0x01));
											
										}
										else if( ((byLo_Pre>>chanIdx)&0x01) < ((byLo>>chanIdx)&0x01) )
										{
											//Off -> On
											PushEventRec(byIP, slotIdx, chanIdx, (int)EVENT_TYPE.DIO, (int)EVENT_STATUS.OFF_TO_ON, ((byLo>>chanIdx)&0x01));
										}
									}
									else
									{
										if( ((byHi_Pre>>(chanIdx-8))&0x01) > ((byHi>>(chanIdx-8))&0x01) )
										{
											//On -> Off
											PushEventRec(byIP, slotIdx, chanIdx, (int)EVENT_TYPE.DIO, (int)EVENT_STATUS.ON_TO_OFF, ((byHi>>(chanIdx-8))&0x01));
										}
										else if( ((byHi_Pre>>(chanIdx-8))&0x01) < ((byHi>>(chanIdx-8))&0x01) )
										{
											//Off -> On
											PushEventRec(byIP, slotIdx, chanIdx, (int)EVENT_TYPE.DIO, (int)EVENT_STATUS.OFF_TO_ON, ((byHi>>(chanIdx-8))&0x01));
										}
									}
								}
							}
						}
						//

						//AIO High Alarm
						//if(!Array.Equals(adamStreamRec_Pre.m_HiAlarm, adamStreamRec.m_HiAlarm))
						{
							long valAIO = 0;
							for (slotIdx=0; slotIdx<8; slotIdx++)
							{
								byHi_Pre = adamStreamRec.m_Pre_HiAlarm[slotIdx];

								byHi = adamStreamRec.m_HiAlarm[slotIdx];
								for (chanIdx=0; chanIdx<8; chanIdx++)
								{
									valAIO = Convert.ToInt64(adamStreamRec.m_Data_AIO[slotIdx*8+chanIdx*2]*256 + adamStreamRec.m_Data_AIO[slotIdx*8+chanIdx*2+1]);
									
									if( ((byHi_Pre>>chanIdx)&0x01) > ((byHi>>chanIdx)&0x01))
									{
										//On -> Off
										PushEventRec(byIP, slotIdx, chanIdx, (int)EVENT_TYPE.HIALARM, (int)EVENT_STATUS.ON_TO_OFF, valAIO);
									}
									else if( ((byHi_Pre>>chanIdx)&0x01) < ((byHi>>chanIdx)&0x01))
									{
										//Off -> On
										PushEventRec(byIP, slotIdx, chanIdx, (int)EVENT_TYPE.HIALARM, (int)EVENT_STATUS.OFF_TO_ON, valAIO);
									}
								}
							}
						}
						//

						//Low Alarm
						//if(!Array.Equals(adamStreamRec_Pre.m_LoAlarm, adamStreamRec.m_LoAlarm))
						{
							long valAIO = 0;
							for (slotIdx=0; slotIdx<8; slotIdx++)
							{
								byLo_Pre = adamStreamRec.m_Pre_LoAlarm[slotIdx];

								byLo = adamStreamRec.m_LoAlarm[slotIdx];
								for (chanIdx=0; chanIdx<8; chanIdx++)
								{
									valAIO = Convert.ToInt64(adamStreamRec.m_Data_AIO[slotIdx*8+chanIdx*2]*256 + adamStreamRec.m_Data_AIO[slotIdx*8+chanIdx*2+1]);
									
									if( ((byLo_Pre>>chanIdx)&0x01) > ((byLo>>chanIdx)&0x01))
									{
										//On -> Off
										PushEventRec(byIP, slotIdx, chanIdx, (int)EVENT_TYPE.LOALARM, (int)EVENT_STATUS.ON_TO_OFF, valAIO);
									}
									else if( ((byLo_Pre>>chanIdx)&0x01) < ((byLo>>chanIdx)&0x01))
									{
										//Off -> On
										PushEventRec(byIP, slotIdx, chanIdx, (int)EVENT_TYPE.LOALARM, (int)EVENT_STATUS.OFF_TO_ON, valAIO);
									}
								}
							}
						}
						//

						ClearPreStreamRec();
					}
				}
			}
		}

		/// <summary>
		/// Get the last received stream
		/// </summary>
		/// <param name="o_byData">The last data stream</param>
		/// <returns></returns>
		public bool GetLastStreamRec(out byte[] o_byData)
		{
			AdamStreamRec adamStreamRec;
			o_byData = null;
			if(m_ArrayList.Count>0)
			{
				adamStreamRec = (AdamStreamRec)m_ArrayList[m_ArrayList.Count-1];

				o_byData = new byte[adamStreamRec.m_Data.Length];

				Array.Copy(adamStreamRec.m_Data,0,o_byData,0,adamStreamRec.m_Data.Length);
				return true;
			}
			return false;
		}

		/// <summary>
		/// Get the last received stream from target IP
		/// </summary>
		/// <param name="i_strIP">Target IP</param>
		/// <param name="o_byData">The last data stream from target IP</param>
		/// <returns></returns>
		public bool GetLastStreamRec(string i_strIP, out byte[] o_byData)
		{
			string strTemp;
			AdamStreamRec adamStreamRec;
			o_byData = null;
			if(m_ArrayList.Count>0)
			{
				for(int i=0;i<m_ArrayList.Count;i++)
				{
					adamStreamRec = (AdamStreamRec)m_ArrayList[m_ArrayList.Count-1-i];
					
					strTemp = string.Format("{0}.{1}.{2}.{3}", adamStreamRec.m_byIP[0], adamStreamRec.m_byIP[1], adamStreamRec.m_byIP[2], adamStreamRec.m_byIP[3]);
					if(strTemp == i_strIP)
					{
						o_byData = new byte[adamStreamRec.m_Data.Length];

						Array.Copy(adamStreamRec.m_Data,0,o_byData,0,adamStreamRec.m_Data.Length);
						return true;
					}
				}
			}
			return false;
		}
		
		/// <summary>
		/// Push received event
		/// </summary>
		/// <param name="i_byIP"></param>
		/// <param name="i_iSlot"></param>
		/// <param name="i_iChannel"></param>
		/// <param name="i_iType"></param>
		/// <param name="i_iStatus"></param>
		/// <param name="i_lVal"></param>
		public void PushEventRec(byte[] i_byIP, int i_iSlot, int i_iChannel, int i_iType, int i_iStatus, long i_lVal)
		{
			m_ArrayList_Event.Add(new AdamEvent(i_byIP, i_iSlot, i_iChannel, i_iType, i_iStatus, i_lVal));
		}

		/// <summary>
		/// Pop received event
		/// </summary>
		/// <param name="o_byIP"></param>
		/// <param name="o_iSlot"></param>
		/// <param name="o_iChannel"></param>
		/// <param name="o_iType"></param>
		/// <param name="o_iStatus"></param>
		/// <param name="o_strTime"></param>
		/// <param name="o_lVal"></param>
		/// <returns></returns>
		public bool PopEventRec(out byte[] o_byIP, out int o_iSlot, out int o_iChannel, out int o_iType, out int o_iStatus, out string o_strTime, out long o_lVal)
		{
			o_byIP = null;
			o_iSlot = -1;
			o_iChannel = -1;
			o_iType = -1;
			o_iStatus = -1;
			o_strTime = "";
			o_lVal = -1;

			if(m_ArrayList_Event.Count>0)
			{
				AdamEvent adamEvent = (AdamEvent)m_ArrayList_Event[0];
				
				o_byIP = new byte[adamEvent.m_byIP.Length];		Array.Copy(adamEvent.m_byIP,0,o_byIP,0,adamEvent.m_byIP.Length);

				o_iSlot		= adamEvent.m_iSlot;
				o_iChannel	= adamEvent.m_iChannel;
				o_iType		= adamEvent.m_iType;
				o_iStatus	= adamEvent.m_iStatus;
				o_strTime	= adamEvent.m_Time.ToString();
				o_lVal		= adamEvent.m_lVal;

				m_ArrayList_Event.RemoveAt(0);
				return true;
			}
			return false;
		}
	}
}
