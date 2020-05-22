using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Advantech.Adam;

namespace Adam4018M
{
    public partial class FormMemoryRecord : Form
    {
        private AdamCom adamCom;
        private int m_iAddr, m_iIndex, m_iMax, m_iCount;
        private ListView m_listView;

        public FormMemoryRecord(ref AdamCom adamCom, ref ListView listView, int i_iAddr, string i_szTitle, int i_ParentWidth, int i_ParentHeight)
        {
            InitializeComponent();

            this.Location = new Point((i_ParentWidth - this.Width) / 2, (i_ParentHeight - this.Height) / 2);
            this.adamCom = adamCom;
            m_iAddr = i_iAddr;
            this.Text = i_szTitle;
            m_listView = listView;
        }

        private void btnGetRecord_Click(object sender, EventArgs e)
        {
            int iCh, iIdx;
            float fData;
            long lElapse;

            timer1.Enabled = false;
            if (m_iCount < m_iMax)
            {
                iIdx = m_iIndex + m_iCount;
                if (adamCom.AnalogInput(m_iAddr).GetMemRecordData(iIdx, out iCh, out fData, out lElapse))
                {
                    m_listView.Items.Add(new ListViewItem(iIdx.ToString("0000")));
                    m_listView.Items[m_iCount].SubItems.Add(iCh.ToString());
                    m_listView.Items[m_iCount].SubItems.Add(fData.ToString());
                    m_listView.Items[m_iCount].SubItems.Add(lElapse.ToString());
                    m_iCount++;
                    progressBar1.Value = m_iCount * 100 / m_iMax;
                    timer1.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Get record failed!", "Error");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Get record done!", "Information");
                this.Close();
            }
        }

        private void FormMemoryRecord_Closing(object sender, CancelEventArgs e)
        {
            timer1.Enabled = false;
            m_listView.EndUpdate();
        }

        private void btnGetRecord_Click_1(object sender, EventArgs e)
        {
            btnGetRecord.Enabled = false;
            m_iIndex = Convert.ToInt32(numericUpDown1.Value);
            m_iMax = Convert.ToInt32(numericUpDown2.Value);
            m_iCount = 0;
            m_listView.Items.Clear();
            m_listView.BeginUpdate();
            timer1.Enabled = true;
        }
    }
}