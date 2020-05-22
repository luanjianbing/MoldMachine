using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Advantech.Adam;

namespace P2P_UdpEvent
{
    public partial class Form1 : Form
    {
        private AdamP2P adamP2P;

        public Form1()
        {
            InitializeComponent();

            adamP2P = new AdamP2P();
            adamP2P.GetDataEvent += new GetP2PDataCallback(this.OnGetData);
            txtPort.Text = AdamP2P.P2P_Port.ToString();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Text == "Start")
            {
                if (!adamP2P.Start_P2P_Server())
                {
                    MessageBox.Show("Failed to start Peer to Peer server.", "Error");
                    return;
                }

                btnStart.Text = "Stop";

                string strNowTime = DateTime.Now.ToString("hh:mm:ss:fff");
                this.listBoxHistory.Items.Add(strNowTime);
                this.listBoxHistory.Items.Add("Start listening... ");
                this.listBoxHistory.Items.Add("");
            }
            else
            {
                adamP2P.Stop_P2P_Server();

                btnStart.Text = "Start";

                this.listViewInfo.Items.Clear();
            }
        }

        private void OnGetData(P2P_Config config)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new GetP2PDataCallback(OnGetData), new object[] { config });
                return;
            }

            txtRecvNum.Text = adamP2P.P2P_PackageNum.ToString();
            RefreshListView(config);
        }

        private void Form1_Closed(object sender, EventArgs e)
        {
            adamP2P.Stop_P2P_Server();
        }

        private void RefreshListView(P2P_Config p2p_Config)
        {
            int i;
            bool bIsValid;
            int iCnt = 0;
            int idxData;
            int idxDataPos;
            bool bData;	        //For Coils
            bool bDataChanged;	//For Coils
            int iData;	        //For Registers
            string strTemp;

            //
            listViewInfo.BeginUpdate();
            listViewInfo.Items.Clear();

            for (i = 0; i < p2p_Config.NoChannels; i++)
            {
                bIsValid = (((p2p_Config.ChannelMask >> i) & 0x01) > 0);

                if (bIsValid)
                {
                    txtFuncCode.Text = p2p_Config.FunCode.ToString();

                    if (p2p_Config.FunCode == (byte)P2P_FunctionCode.DIO_BASIC_MODE)
                    {
                        //DIO
                        ListViewItem lvi = new ListViewItem(i.ToString());
                        listViewInfo.Items.Add(lvi);

                        idxData = i / 8;
                        idxDataPos = i % 8;

                        bData = (((p2p_Config.Data[idxData] >> idxDataPos) & 0x01) > 0);
                        bDataChanged = (((p2p_Config.COS_Flag[idxData] >> idxDataPos) & 0x01) > 0);

                        listViewInfo.Items[iCnt].SubItems.Add(bData.ToString());
                        listViewInfo.Items[iCnt].SubItems.Add(bDataChanged.ToString());
                        iCnt++;
                    }
                    else if (p2p_Config.FunCode == (byte)P2P_FunctionCode.DIO_ADV_MODE)
                    {
                        //DIO
                        ListViewItem lvi = new ListViewItem("Advanced DO");
                        listViewInfo.Items.Add(lvi);

                        bData = (p2p_Config.Data[0] == 0xFF);

                        listViewInfo.Items[iCnt].SubItems.Add(bData.ToString());
                        listViewInfo.Items[iCnt].SubItems.Add("*****");
                        iCnt++;
                    }
                    else if (p2p_Config.FunCode == (byte)P2P_FunctionCode.AIO_MODE)
                    {
                        //AIO
                        ListViewItem lvi;

                        if (p2p_Config.P2PMode == (byte)P2P_Mode.Advanced)
                        {
                            lvi = new ListViewItem("Advanced AI");
                            listViewInfo.Items.Add(lvi);
                        }
                        else
                        {
                            lvi = new ListViewItem(i.ToString());
                            listViewInfo.Items.Add(lvi);
                        }

                        iData = (p2p_Config.Data[i * 2] << 8);
                        iData |= (p2p_Config.Data[i * 2 + 1]);

                        listViewInfo.Items[iCnt].SubItems.Add(iData.ToString());
                        listViewInfo.Items[iCnt].SubItems.Add("*****");
                        iCnt++;
                    }
                }
            }
            listViewInfo.EndUpdate();

            ////////////////////////////////////////////////////////////////////////////////////
            string strNowTime = DateTime.Now.ToString("hh:mm:ss:fff");
            this.listBoxHistory.BeginUpdate();
            this.listBoxHistory.Items.Add(strNowTime);
            this.listBoxHistory.Items.Add("PackageNum: " + p2p_Config.PackageNum.ToString());
            this.listBoxHistory.Items.Add("FuncCode: 0x" + p2p_Config.FunCode.ToString("X02"));
            this.listBoxHistory.Items.Add("ChannelMask: 0x" + p2p_Config.ChannelMask.ToString("X08"));
            if (p2p_Config.FunCode == (byte)P2P_FunctionCode.DIO_BASIC_MODE)
            {
                bDataChanged = false;
                for (i = 0; i < p2p_Config.COS_Flag.Length - 2; i++)
                {
                    if (p2p_Config.COS_Flag[i] > 0)
                    {
                        bDataChanged = true;
                        break;
                    }
                }
                if (bDataChanged)
                    this.listBoxHistory.Items.Add("Packet Type: C.O.S.");
                else
                    this.listBoxHistory.Items.Add("Packet Type: Period");
            }

            strTemp = "";
            this.listBoxHistory.Items.Add("Data: ");
            for (i = 0; i < p2p_Config.Data.Length; i++)
            {
                strTemp += "0x" + p2p_Config.Data[i].ToString("X02");
                if (i != p2p_Config.Data.Length - 1)
                    strTemp += ", ";
                if (i == 7)
                {
                    this.listBoxHistory.Items.Add(strTemp);
                    strTemp = "";
                }
            }
            this.listBoxHistory.Items.Add(strTemp);
            this.listBoxHistory.Items.Add("");
            listBoxHistory.SelectedIndex = listBoxHistory.Items.Count - 1;
            this.listBoxHistory.EndUpdate();
            ////////
        }
    }
}