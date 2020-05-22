using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Advantech.Adam;

namespace GCL_IO_Message
{
    public partial class Form1 : Form
    {
        private AdamGCL_IOMsg adamGCL_IOMsg;

        public Form1()
        {
            InitializeComponent();

            adamGCL_IOMsg = new AdamGCL_IOMsg();
            adamGCL_IOMsg.GetDataEvent += new GetDataCallback(this.OnGetData);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Text == "Start")
            {
                adamGCL_IOMsg.Start_Server();

                btnStart.Text = "Stop";

                string strNowTime = DateTime.Now.ToString("hh:mm:ss:fff");
                this.listBoxMsg.Items.Add(strNowTime);
                this.listBoxMsg.Items.Add("Start listening... ");
                this.listBoxMsg.Items.Add("");
            }
            else
            {
                adamGCL_IOMsg.Stop_Server();

                btnStart.Text = "Start";
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (adamGCL_IOMsg.IsServerStart)
            {
                adamGCL_IOMsg.Stop_Server();
            }
            adamGCL_IOMsg = null;
        }

        private void OnGetData(GCL_IOMsg_Config config)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new GetDataCallback(OnGetData), new object[] { config });
                return;
            }

            RefreshListView(config);
        }

        private void RefreshListView(GCL_IOMsg_Config config)
        {
            int i;
            string strTemp;
            string strMsg;
            ArrayList strList = new ArrayList();
            byte[] byAI, byAO, byDI, byDO, byCnt, byMsg;
            DateTime dt = DateTime.Now;
            int iDataSize, iResolution;

            //History
            string ipStr = string.Format("{0}.{1}.{2}.{3}", config.IP[0], config.IP[1], config.IP[2], config.IP[3]);
            string timeStr = dt.Hour.ToString() + ":" + dt.Minute.ToString() + ":" + dt.Second.ToString();
            strTemp = "At " + timeStr + "   IP:" + ipStr + "   SeqNum:" + config.SeqNum.ToString() + "   RuleIdx:" + config.RuleIndex.ToString() + "   OutIdx:" + config.OutputIndex.ToString() + "   OperationVal:" + config.OperationVal.ToString();
            listBoxMsg.Items.Add(strTemp);
            listBoxMsg.SelectedIndex = listBoxMsg.Items.Count - 1;
            //////////////////////////////

            //IO data
            //AI
            if (adamGCL_IOMsg.GetData_AI(config, out byAI))
            {
                if (byAI.Length > 0)
                {
                    iResolution = config.NumBitsAI;
                    iDataSize = (int)(iResolution / 8);
                    if (iResolution % 8 > 0)
                        iDataSize += 1;

                    strList.Add("AI:");
                    strTemp = "";
                    for (i = 0; i < byAI.Length; i++)
                    {
                        if (i % iDataSize == 0)
                        {
                            if (i != 0 && i != byAI.Length - 1)
                                strTemp += " , ";

                            strTemp += "0x" + byAI[i].ToString("X02");
                        }
                        else
                            strTemp += byAI[i].ToString("X02");
                    }
                    strList.Add(strTemp);
                    strList.Add("");
                }
            }

            //AO
            if (adamGCL_IOMsg.GetData_AO(config, out byAO))
            {
                if (byAO.Length > 0)
                {
                    iResolution = config.NumBitsAO;
                    iDataSize = (int)(iResolution / 8);
                    if (iResolution % 8 > 0)
                        iDataSize += 1;

                    strList.Add("AO:");
                    strTemp = "";
                    for (i = 0; i < byAO.Length; i++)
                    {
                        if (i % iDataSize == 0)
                        {
                            if (i != 0 && i != byAO.Length - 1)
                                strTemp += " , ";
                            strTemp += "0x" + byAO[i].ToString("X02");
                        }
                        else
                            strTemp += byAO[i].ToString("X02");
                    }
                    strList.Add(strTemp);
                    strList.Add("");
                }
            }

            //DI
            if (adamGCL_IOMsg.GetData_DI(config, out byDI))
            {
                if (byDI.Length > 0)
                {
                    strList.Add("DI:");
                    strTemp = "0x";
                    for (i = 0; i < byDI.Length; i++)
                    {
                        strTemp += byDI[i].ToString("X02");
                    }
                    strList.Add(strTemp);
                    strList.Add("");
                }
            }

            //DO
            if (adamGCL_IOMsg.GetData_DO(config, out byDO))
            {
                if (byDO.Length > 0)
                {
                    strList.Add("DO:");
                    strTemp = "0x";
                    for (i = 0; i < byDO.Length; i++)
                    {
                        strTemp += byDO[i].ToString("X02");
                    }
                    strList.Add(strTemp);
                    strList.Add("");
                }
            }

            //Cnt
            if (adamGCL_IOMsg.GetData_Cnt(config, out byCnt))
            {
                if (byCnt.Length > 0)
                {
                    iResolution = config.NumBitsCnt;
                    iDataSize = (int)(iResolution / 8);
                    if (iResolution % 8 > 0)
                        iDataSize += 1;

                    strList.Add("Cnt:");
                    strTemp = "";
                    for (i = 0; i < byCnt.Length; i++)
                    {
                        if (i % iDataSize == 0)
                        {
                            if (i != 0 && i != byCnt.Length - 1)
                                strTemp += " , ";
                            strTemp += "0x" + byCnt[i].ToString("X02");
                        }
                        else
                            strTemp += byCnt[i].ToString("X02");

                    }
                    strList.Add(strTemp);
                }
            }

            string[] strArray = (string[])strList.ToArray(typeof(string));
            //////////////////////////////

            //Message
            adamGCL_IOMsg.GetMessage(config, out byMsg);
            strMsg = Encoding.ASCII.GetString(byMsg);
            //////////////////////////////

            this.txtIOData.Lines = strArray;
            txtMsg.Text = strMsg;
        }
    }
}
