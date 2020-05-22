using System;
using System.Collections.Generic;
using System.Text;
using Advantech.Adam;
using System.Runtime.InteropServices;
using System.Net.Sockets;

namespace Adam6060Com
{
    [ComVisible(true)]
    [Guid("88DE7087-8B80-4978-B2F4-C0937984A078")]
    public interface DoAdam6060
    {
        [DispId(1)]
        bool Adam6060Init(string m_IP, int m_Port);

        [DispId(2)]
        void Adam6060SingleSetOut(int m_out, bool status);

        [DispId(3)]
        bool Adam6060ReadStatus(int m_in);

        [DispId(4)]
        void Adam6060DisConnect();

        [DispId(5)]
        int Adam6060ReadAllStatus();
    }

    [ComVisible(true)]
    [Guid("1AA8315B-C1A3-45C1-A9E0-9D2CC43763A1")]
    public class Adam6060Operate : DoAdam6060
    {
        private AdamSocket adamModbus;

        public bool Adam6060Init(string m_IP, int m_Port)
        {
            adamModbus = new AdamSocket();
            adamModbus.SetTimeout(1000, 1000, 1000); // set timeout for TCP
            if (adamModbus.Connect(m_IP, ProtocolType.Tcp, m_Port))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Adam6060SingleSetOut(int m_out, bool status)
        {
            adamModbus.Modbus().ForceSingleCoil(m_out + 17, status);		//控制输出通断17-22/0-1
        }

        public bool Adam6060ReadStatus(int m_in)
        {
            bool res = false;
            bool[] bWDT;
            adamModbus.Modbus().ReadCoilStatus(1, 6, out bWDT);
            res = bWDT[m_in];
            return res;
        }

        public void Adam6060DisConnect()
        {
            adamModbus.Disconnect();
        }

        public int Adam6060ReadAllStatus()
        {
            int res = 0, bt = 0;
            bool[] bWDT;
            adamModbus.Modbus().ReadCoilStatus(1, 6, out bWDT);
            for (int i = 0; i < 6; ++i)
            {
                if (bWDT[i]) bt = 1;
                else bt = 0;
                res = res << 1 + bt;
            }
            return res;
        }
    }
}
