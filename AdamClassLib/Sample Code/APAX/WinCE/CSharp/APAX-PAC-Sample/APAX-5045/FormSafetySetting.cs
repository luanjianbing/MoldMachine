using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace APAX_5045
{
    public partial class FormSafetySetting : Form
    {
        public delegate void EventHandler_ApplySafetyValueClick(bool[] bVal);
        public event EventHandler_ApplySafetyValueClick ApplySafetyValueClick;
        int m_iChannelTotal;
        bool[] m_bVal;

        public FormSafetySetting(int iChannelTotal, bool[] bVal)
        {
            InitializeComponent();
            m_iChannelTotal = iChannelTotal;
            m_bVal = bVal;
            // Set init information
            for (int i = 0; i < iChannelTotal; i++)
            {
                ListViewItem lvItem = new ListViewItem(i.ToString());
                lvItem.SubItems.Add(bVal[i].ToString());
                gridviewSafety.Items.Add(lvItem);
            }
        }

        private void gridviewSafety_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < gridviewSafety.SelectedIndices.Count; i++)
            {
                if (gridviewSafety.Items[gridviewSafety.SelectedIndices[i]].Selected)
                {
                    int iSelectedItem = gridviewSafety.SelectedIndices[i];

                    txtChannel.Text = gridviewSafety.Items[iSelectedItem].Text;
                    if (Convert.ToBoolean(gridviewSafety.Items[iSelectedItem].SubItems[1].Text))
                        rdbtnOn.Checked = true;
                    else
                        rdbtnOff.Checked = true;
                    return;
                }
            }
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            if (chbxSelecteAll.Checked)
            {
                for (int idx = 0; idx < m_iChannelTotal; idx++)
                {
                    if (rdbtnOn.Checked)
                        gridviewSafety.Items[idx].SubItems[1].Text = "True";
                    else
                        gridviewSafety.Items[idx].SubItems[1].Text = "False";
                }
                return;
            }
            for (int i = 0; i < gridviewSafety.SelectedIndices.Count; i++)
            {
                if (gridviewSafety.Items[gridviewSafety.SelectedIndices[i]].Selected)
                {
                    int iSelectedItem = gridviewSafety.SelectedIndices[i];
                    if (rdbtnOn.Checked)
                        gridviewSafety.Items[iSelectedItem].SubItems[1].Text = "True";
                    else
                        gridviewSafety.Items[iSelectedItem].SubItems[1].Text = "False";
                    return;
                }
            }
        }
        /// <summary>
        /// Apply setting when user configure safety status
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnApply_Click(object sender, EventArgs e)
        {
            string[] o_szVal = new string[m_iChannelTotal];
            bool[] o_bVal = new bool[m_iChannelTotal];
            for (int i = 0; i < m_iChannelTotal; i++)
            {
                if (gridviewSafety.Items[i].SubItems[1].Text == "True")
                    o_bVal[i] = true;
                else
                    o_bVal[i] = false;
            }
            ApplySafetyValueClick(o_bVal);
        }
    }
}