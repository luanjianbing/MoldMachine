using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace APAX_5028
{
    public partial class FormSafetySetting : Form
    {
        public delegate void EventHandler_ApplySafetyValueClick(string[] szVal);
        public event EventHandler_ApplySafetyValueClick ApplySafetyValueClick;
        int m_iChannelTotal;
        float[] m_fVal;
        string[] m_szRange;

        public FormSafetySetting(int iChannelTotal, float[] fVal, string[] szRange)
        {
            InitializeComponent();
            m_iChannelTotal = iChannelTotal;

            m_fVal = fVal;
            m_szRange = szRange;

            // Set init information
            for (int i = 0; i < iChannelTotal; i++)
            {
                ListViewItem lvItem = new ListViewItem(i.ToString());
                lvItem.SubItems.Add(fVal[i].ToString());
                gridviewSafety.Items.Add(lvItem);
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (ApplySafetyValueClick != null)
            {
                string[] o_szVal = new string[m_iChannelTotal];
                for (int i = 0; i < m_iChannelTotal; i++)
                {
                    o_szVal[i] = Convert.ToString(gridviewSafety.Items[i].SubItems[1].Text);
                }
                ApplySafetyValueClick(o_szVal);
            }
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridviewSafety.SelectedIndices.Count; i++)
            {
                if (gridviewSafety.Items[gridviewSafety.SelectedIndices[i]].Selected)
                {
                    int iSelectedItem = gridviewSafety.SelectedIndices[i];
                    gridviewSafety.Items[iSelectedItem].SubItems[1].Text = txtSafetyVal.Text;
                    return;
                }
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
                    txtSafetyVal.Text = gridviewSafety.Items[iSelectedItem].SubItems[1].Text;
                    labRange.Text = m_szRange[iSelectedItem];
                    return;
                }
            }
        }

    }
}