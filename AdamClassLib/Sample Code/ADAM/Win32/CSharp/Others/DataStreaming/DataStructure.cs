using System;

namespace DataStreaming
{
    /// <summary>
    /// Summary description for DataStructure.
    /// </summary>
    public class DataStructure
    {
        private byte[] byData;

        public DataStructure()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public void SetData(byte[] i_byData, int iLen)
        {
            byData = new byte[iLen];
            Array.Copy(i_byData, 0, byData, 0, iLen);
        }

        public UInt32 Header()
        {
            return BitConverter.ToUInt32(byData, 0);
        }

        public byte CommandType()
        {
            return byData[4];
        }

        public byte DataLength()
        {
            return byData[5];
        }

        public UInt16 DIO(int i_iIndex)
        {
            UInt16 iData;
            iData = byData[i_iIndex * 2 + 7];
            iData = Convert.ToUInt16(iData * 256 + byData[i_iIndex * 2 + 6]);
            return iData;
        }

        public UInt16 AIO(int i_iIndex)
        {
            UInt16 iData;
            iData = byData[i_iIndex * 2 + 22];
            iData = Convert.ToUInt16(iData * 256 + byData[i_iIndex * 2 + 23]);
            return iData;
        }
       
    }
}
