using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Apax_IO_Module_Library;
using Advantech.Adam;
using APAX_5013;
using APAX_5017;
using APAX_5017H;
using APAX_5017PE;
using APAX_5018;
using APAX_5028;
using APAX_5040;
using APAX_5040PE;
using APAX_5045;
using APAX_5046;
using APAX_5046SO;
using APAX_5060;
using APAX_5060PE;
using APAX_5080;
using APAX_5082;


namespace APAX_Controller_Win32_Sample
{
    public partial class Form_APAX_Controller : Form
    {
        // Global object
        private AdamControl m_adamCtl;
        private Apax5000Config m_aConf;
        private int m_ScanTime_LocalSys;
        private int m_idxID;
        public static string APAX_INFO_PRODUCT = "APAX-5000";
        public string[] m_szSlotInfo;

        private const string APAX_5013_STR = "5013";
        private const string APAX_5017_STR = "5017";
        private const string APAX_5017H_STR = "5017H";
        private const string APAX_5017PE_STR = "5017PE";
        private const string APAX_5018_STR = "5018";
        private const string APAX_5028_STR = "5028";
        private const string APAX_5040_STR = "5040";
        private const string APAX_5040PE_STR = "5040PE";
        private const string APAX_5045_STR = "5045";
        private const string APAX_5046_STR = "5046";
        private const string APAX_5046SO_STR = "5046SO";
        private const string APAX_5060_STR = "5060";
        private const string APAX_5060PE_STR = "5060PE";
        private const string APAX_5080_STR = "5080";
        private const string APAX_5082_STR = "5082";

        private readonly string[] APAX_COUPLER_SUPPORT_MODULE
                   = new string[] { 
                                            APAX_5013_STR, APAX_5017_STR, APAX_5017H_STR, APAX_5017PE_STR, APAX_5018_STR, 
                                            APAX_5028_STR, 
                                            APAX_5040_STR, APAX_5040PE_STR, APAX_5045_STR, 
                                            APAX_5046_STR, APAX_5046SO_STR, APAX_5060_STR, APAX_5060PE_STR,
                                            APAX_5080_STR, APAX_5082_STR 
                                          };

        public Form_APAX_Controller()
        {
            InitializeComponent();
            m_idxID = 210;
            m_ScanTime_LocalSys = Convert.ToInt32(NumericUpDown_SCAN.Value);
        }

        private bool IsApaxCouplerSupportModule(string szModuleName)
        {
            bool bRet = false;
            int intPos = Array.IndexOf(APAX_COUPLER_SUPPORT_MODULE, szModuleName);
            if (intPos > -1)
            {
                bRet = true;
            }
            return bRet;
        }

        public void ShowWaitMsg()
        {
            Wait_Form FormWait = new Wait_Form();
            FormWait.Start_Wait();
            FormWait.ShowDialog();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.FullPath.IndexOf("Local System") == 0)
            {
                if (string.Compare(e.Node.Text, "Local System") == 0)
                {
                    panel4.Visible = false;
                    AfterSelect_LocalDevice(e.Node);
                    panel4.Visible = true;
                }
                else
                    AfterSelect_LocalSlot(e.Node);
            }
        }
        /// <summary>
        /// Refresh I/O modules of this controller and show controller information
        /// </summary>
        /// <param name="e"></param>
        private void AfterSelect_LocalDevice(TreeNode e)
        {
            this.treeView1.SelectedNode = this.treeView1.Nodes[0];	//CE bug exception
            uint uiVer;
            string szTemp = "";
            string szVer = "";

            ThreadStart newStart = new ThreadStart(ShowWaitMsg);
            Thread waitThread = new Thread(newStart);
            waitThread.Start();

            try
            {
                m_adamCtl = new AdamControl(AdamType.Apax5000);
                //Get APAX-Driver Version
                if (m_adamCtl.Configuration().SYS_GetVersion(out uiVer))
                {
                    szTemp = uiVer.ToString("X00000000");
                    if (szTemp.Length >= 3)
                        szVer = szTemp.Insert(szTemp.Length - 2, ".");
                    else
                        szVer = szTemp;
                    statusBar1.Text = " APAX-Driver Version:" + szVer + ".";
                }
                else
                {
                    statusBar1.Text = " Get APAX-Driver Version failed! Please upgrade the driver. ApiErr:" + m_adamCtl.Configuration().ApiLastError.ToString();
                    MessageBox.Show("Please make sure latest APAX-Driver has been installed.");
                    return;
                }
                if (m_adamCtl.OpenDevice())
                {

                    if (!m_adamCtl.Configuration().SYS_SetDspChannelFlag(false))
                        statusBar1.Text = "SYS_SetDspChannelFlag(false) Failed! ";
                    treeView1.Nodes[0].Nodes.Clear();
                    treeView1.BeginUpdate();
                    if (m_adamCtl.Configuration().GetSlotInfo(out m_szSlotInfo))
                    {
                        for (int i = 0; i < m_szSlotInfo.Length; i++)
                        {
                            if (m_szSlotInfo[i].Length > 0)
                            {
                                TreeNode tNode = new TreeNode(m_szSlotInfo[i].ToString() + "(S" + i.ToString() + ")");
                                tNode.Tag = (byte)i;
                                e.Nodes.Add(tNode);
                            }
                        }
                    }
                    e.ExpandAll();
                    treeView1.EndUpdate();

                    if (!RefreshConfiguration())
                        MessageBox.Show("Get controller information failed!\nPlease check the device!", "Error");

                }
            }
            catch
            {
                MessageBox.Show("Open local driver failed!", "Error");
            }
        }

        /// <summary>
        /// When select any I/O Modules, replace related APAX I/O module (usercontrol) at rignt panel
        /// </summary>
        /// <param name="e"></param>
        private void AfterSelect_LocalSlot(TreeNode e)
        {
            string strSelectModuleId = string.Empty;
            int iSlot;
            int iCmpLength = 4;
            Form IO_Module;
            iSlot = Convert.ToInt32(e.Tag);
            strSelectModuleId = m_szSlotInfo[iSlot].ToUpper();

            DialogResult dialogResult = MessageBox.Show("Do you want to demo APAX-" + e.Text + "?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (dialogResult == DialogResult.No)
            {
                return;
            }

            if ((string.Compare(e.Text, 0, "Local System", 0, (iCmpLength + 1)) == 0))
            {
                return;
            }

            if (IsApaxCouplerSupportModule(strSelectModuleId) == false)
            {
                MessageBox.Show(("Not support device APAX-" + e.Text), "Warn");
                return;
            }

            if (strSelectModuleId == APAX_5013_STR)
            {
                IO_Module = new Form_APAX_5013(iSlot, m_ScanTime_LocalSys);
            }
            else if (strSelectModuleId == APAX_5017_STR)
            {
                IO_Module = new Form_APAX_5017(iSlot, m_ScanTime_LocalSys);
            }
            else if (strSelectModuleId == APAX_5017H_STR)
            {
                IO_Module = new Form_APAX_5017H(iSlot, m_ScanTime_LocalSys);
            }
            else if (strSelectModuleId == APAX_5017PE_STR)
            {
                IO_Module = new Form_APAX_5017PE(iSlot, m_ScanTime_LocalSys);
            }
            else if (strSelectModuleId == APAX_5018_STR)
            {
                IO_Module = new Form_APAX_5018(iSlot, m_ScanTime_LocalSys);
            }
            else if (strSelectModuleId == APAX_5028_STR)
            {
                IO_Module = new Form_APAX_5028(iSlot, m_ScanTime_LocalSys);
            }
            else if (strSelectModuleId == APAX_5040_STR)
            {
                IO_Module = new Form_APAX_5040(iSlot, m_ScanTime_LocalSys);
            }
            else if (strSelectModuleId == APAX_5040PE_STR)
            {
                IO_Module = new Form_APAX_5040PE(iSlot, m_ScanTime_LocalSys);
            }
            else if (strSelectModuleId == APAX_5045_STR)
            {
                IO_Module = new Form_APAX_5045(iSlot, m_ScanTime_LocalSys);
            }
            else if (strSelectModuleId == APAX_5046_STR)
            {
                IO_Module = new Form_APAX_5046(iSlot, m_ScanTime_LocalSys);
            }
            else if (strSelectModuleId == APAX_5046SO_STR)
            {
                IO_Module = new Form_APAX_5046SO(iSlot, m_ScanTime_LocalSys);
            }
            else if (strSelectModuleId == APAX_5060_STR)
            {
                IO_Module = new Form_APAX_5060(iSlot, m_ScanTime_LocalSys);
            }
            else if (strSelectModuleId == APAX_5060PE_STR)
            {
                IO_Module = new Form_APAX_5060PE(iSlot, m_ScanTime_LocalSys);
            }
            else if (strSelectModuleId == APAX_5080_STR)
            {
                IO_Module = new Form_APAX_5080(iSlot, m_ScanTime_LocalSys);
            }
            else if (strSelectModuleId == APAX_5082_STR)
            {
                IO_Module = new Form_APAX_5082(iSlot, m_ScanTime_LocalSys);
            }
            else
            {
                MessageBox.Show(("Not support device APAX-" + e.Text), "Warn");
                return;
            }

            IO_Module.ShowDialog();
            IO_Module = null;
        }

        public bool RefreshConfiguration()
        {
            try
            {
                string strModuleName = "APAX-PAC";
                System.UInt32 ui_FPGAVer;
                if (m_adamCtl.Configuration().SYS_SetDspChannelFlag(true))
                {
                    //  Firmware Version
                    if (m_adamCtl.Configuration().GetModuleConfig(m_idxID, out m_aConf))
                    {
                        m_idxID = ((int)(m_aConf.byUID));
                        this.lbl_Controller_Title.Text = strModuleName;
                        //  APAX_INFO_NAME + "-" + m_aConf.GetModuleName();
                        this.TextBox_Firmware_Ver.Text = m_aConf.wFwVerNo.ToString("X04").Insert(2, ".");
                    }
                    if (!m_adamCtl.Configuration().SYS_SetDspChannelFlag(false))
                    {
                        statusBar1.Text = (statusBar1.Text + "SYS_SetDspChannelFlag(fasle) Failed! ");
                    }
                    //  FPGA Version
                    if (m_adamCtl.Configuration().GetFpgaVersion(out ui_FPGAVer))
                    {
                        this.TextBox_FPGA_Ver.Text = ui_FPGAVer.ToString("X2");
                    }
                    else
                    {
                        statusBar1.Text = statusBar1.Text + "Unable to get FPGA version (ApiErr:" + m_adamCtl.Configuration().ApiLastError.ToString() + ") ";
                    }
                    //  Get scan timer interval
                    SetInfoValue(m_ScanTime_LocalSys);
                    // Current modules information
                    RefreshCurrentModuleInfo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            return true;

        }

        public void RefreshCurrentModuleInfo()
        {
            string[] strModuleName;

            try
            {
                if (m_adamCtl.Configuration().GetSlotInfo(out strModuleName))
                {
                    ListViewItem[] listItemModule = new ListViewItem[strModuleName.Length];
                    this.ListView_Module_Infor.BeginUpdate();
                    this.ListView_Module_Infor.Items.Clear();

                    for (int i = 0; i < strModuleName.Length; ++i)
                    {
                        listItemModule[i] = new ListViewItem(i.ToString());
                        listItemModule[i].SubItems.Add(strModuleName[i]);
                        if ((strModuleName[i].Length <= 0))
                        {
                            listItemModule[i].SubItems.Add("");
                        }
                        // Non-module
                        this.ListView_Module_Infor.Items.Add(listItemModule[i]);

                    }
                    this.ListView_Module_Infor.EndUpdate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception");
            }
        }

        public void SetInfoValue(int iScanInterval)
        {
            int iVal = iScanInterval;
            if ((iVal > this.NumericUpDown_SCAN.Maximum))
            {
                iVal = ((int)(this.NumericUpDown_SCAN.Maximum));
            }
            else if ((iVal < this.NumericUpDown_SCAN.Minimum))
            {
                iVal = ((int)(this.NumericUpDown_SCAN.Minimum));
            }
            this.NumericUpDown_SCAN.Value = iVal;
        }

        public void NumericUpDown_SCAN_ValueChanged(object sender, System.EventArgs e)
        {
            m_ScanTime_LocalSys = ((int)(NumericUpDown_SCAN.Value));
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            AfterSelect_LocalDevice(treeView1.Nodes[0]);
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}