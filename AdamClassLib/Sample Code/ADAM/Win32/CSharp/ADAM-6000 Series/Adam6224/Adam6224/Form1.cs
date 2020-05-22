using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using Advantech.Adam;
using System.Net.Sockets;

namespace Adam6224
{
    public partial class Form1 : Form
    {
        private bool m_bStart;
        private AdamSocket adamModbus;
        private Adam6000Type m_Adam6000Type;
        private string m_szIP;
        private int m_iPort;
        private int m_iCount;
        private int m_iAoChTotal, m_iAoRangeTotal;
        private int m_iAoValueStartAddr;
        private int m_iDiTotal;
        private int m_DiValueStartAddr;
        private float m_fHigh, m_fLow;
        private ushort[] m_usRange, m_usAoValue;

        public Form1()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            m_bStart = false;			// the action stops at the beginning
            m_szIP = "172.18.3.93";	// modbus slave IP address
            m_iPort = 502;				// modbus TCP port is 502
            adamModbus = new AdamSocket();
            adamModbus.SetTimeout(1000, 1000, 1000); // set timeout for TCP
            adamModbus.AdamSeriesType = AdamType.Adam6200;
            adamModbus.Connect(m_szIP, ProtocolType.Tcp, m_iPort);

            m_Adam6000Type = Adam6000Type.Adam6224; // the sample is for ADAM-6224

            m_iAoChTotal = AnalogOutput.GetChannelTotal(m_Adam6000Type);
            m_iAoRangeTotal = AnalogOutput.GetRangeTotal(m_Adam6000Type, Adam6000_RangeFormat.Ushort);
            m_iDiTotal = DigitalInput.GetChannelTotal(m_Adam6000Type);
            m_DiValueStartAddr = 1;
            m_iAoValueStartAddr = 1;
            txtModule.Text = m_Adam6000Type.ToString();
            m_usRange = new ushort[m_iAoChTotal];
            m_usAoValue = new ushort[m_iAoChTotal];

            InitialDiDgViewModbusGeneralRow(m_DiValueStartAddr, m_iDiTotal, ref dgViewDiChannelInfo);

            InitialAoDgViewModbusGeneralRow(m_iAoValueStartAddr, m_iAoChTotal, ref dgViewAoChannelInfo);
            for (int i = 0; i < m_iAoChTotal; i++)
                cbxAoChannel.Items.Add(i.ToString());

            cbxAoChannel.Items.Add("All");

            if (m_Adam6000Type == Adam6000Type.Adam6224)
            {
                for (int i_iIndex = 0; i_iIndex < m_iAoRangeTotal; i_iIndex++)
                {
                    ushort usRangeCode = AnalogOutput.GetRangeCode2Byte(m_Adam6000Type, i_iIndex);
                    string strRangeName = AnalogOutput.GetRangeName(m_Adam6000Type, usRangeCode);
                    cbxAoOutputRange.Items.Add(new ComboItem(strRangeName, usRangeCode));
                }
            }
        }

        protected class ComboItem : object
        {
            protected string m_Name;
            protected ushort m_Code;

            public ComboItem(string name, ushort code)
            {
                m_Name = name;
                m_Code = code;
            }

            public ushort GetCode()
            {
                return m_Code;
            }

            public override string ToString()
            {
                return m_Name;
            }
        }

        private void RefreshAoChannelRange(int i_iChannel, bool i_bRefresh)
        {
            ushort usRange;

            if (adamModbus.AnalogOutput().GetOutputRange(i_iChannel, out usRange))
            {
                m_usRange[i_iChannel] = usRange;
                if (i_bRefresh)
                {
                    for (int i = 0; i < cbxAoOutputRange.Items.Count; i++)
                    {
                        if (((ComboItem)cbxAoOutputRange.Items[i]).GetCode() == usRange)
                        {
                            cbxAoOutputRange.SelectedIndex = i;
                            break;
                        }
                    }
                }
            }
            else
                MessageBox.Show("GetRangeCode() failed;");
        }

        private void InitialDiDgViewModbusGeneralRow(int iDiChStart, int iDiChTotal, ref DataGridView targetDataGridView)
        {
            int iPos, iIdx;
            DataGridViewRow dgvRow;
            DataGridViewCell dgvCell;
            targetDataGridView.Rows.Clear();
            targetDataGridView.Columns[0].Width = 30;
            targetDataGridView.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            targetDataGridView.Columns[1].Width = 30;
            targetDataGridView.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            targetDataGridView.Columns[2].Width = 30;
            targetDataGridView.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            targetDataGridView.Columns[3].Width = 30;
            targetDataGridView.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            targetDataGridView.Columns[4].Width = 95;
            targetDataGridView.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;

            iPos = iDiChStart;
            for (iIdx = 0; iIdx < iDiChTotal; iIdx++)
            {
                dgvRow = new DataGridViewRow();
                //Text type : Location
                dgvCell = new DataGridViewTextBoxCell();
                dgvCell.Value = iPos.ToString("D5");
                dgvRow.Cells.Add(dgvCell);
                //Text type : Type
                dgvCell = new DataGridViewTextBoxCell();
                dgvCell.Value = "DI";
                dgvRow.Cells.Add(dgvCell);
                //Text type : Ch No.
                dgvCell = new DataGridViewTextBoxCell();
                dgvCell.Value = iIdx.ToString();
                dgvRow.Cells.Add(dgvCell);
                //Text type : Bool
                dgvCell = new DataGridViewTextBoxCell();
                dgvCell.Value = "BOOL";
                dgvRow.Cells.Add(dgvCell);
                //Text type : Mode Value
                dgvCell = new DataGridViewTextBoxCell();
                dgvCell.Value = "";
                dgvRow.Cells.Add(dgvCell);

                targetDataGridView.Rows.Add(dgvRow);

                iPos++;
            }
        }

        private void InitialAoDgViewModbusGeneralRow(int iAiChStart, int iAiChTotal, ref DataGridView targetDataGridView)
        {
            int iPos, iIdx;
            DataGridViewRow dgvRow;
            DataGridViewCell dgvCell;
            targetDataGridView.Rows.Clear();
            targetDataGridView.Columns[0].Width = 50;
            targetDataGridView.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
            targetDataGridView.Columns[1].Width = 35;
            targetDataGridView.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            targetDataGridView.Columns[2].Width = 30;
            targetDataGridView.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
            targetDataGridView.Columns[3].Width = 63;
            targetDataGridView.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
            targetDataGridView.Columns[4].Width = 63;
            targetDataGridView.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
            targetDataGridView.Columns[5].Width = 63;
            targetDataGridView.Columns[5].SortMode = DataGridViewColumnSortMode.NotSortable;
            targetDataGridView.Columns[6].Width = 90;
            targetDataGridView.Columns[6].SortMode = DataGridViewColumnSortMode.NotSortable;

            iPos = 40000 + iAiChStart;
            for (iIdx = 0; iIdx < iAiChTotal; iIdx++)
            {
                dgvRow = new DataGridViewRow();
                //Text type : Location
                dgvCell = new DataGridViewTextBoxCell();
                dgvCell.Value = iPos.ToString("D5");
                dgvRow.Cells.Add(dgvCell);
                //Text type : Type
                dgvCell = new DataGridViewTextBoxCell();
                dgvCell.Value = "AO";
                dgvRow.Cells.Add(dgvCell);
                //Text type : Ch No.
                dgvCell = new DataGridViewTextBoxCell();
                dgvCell.Value = iIdx.ToString();
                dgvRow.Cells.Add(dgvCell);
                //Text type : Value[Dec]
                dgvCell = new DataGridViewTextBoxCell();
                dgvCell.Value = "******";
                dgvRow.Cells.Add(dgvCell);
                //Text type : Value[Hex]
                dgvCell = new DataGridViewTextBoxCell();
                dgvCell.Value = "******";
                dgvRow.Cells.Add(dgvCell);
                //Text type : Value[Eng]
                dgvCell = new DataGridViewTextBoxCell();
                dgvCell.Value = "******";
                dgvRow.Cells.Add(dgvCell);
                //Text type : Range Description
                dgvCell = new DataGridViewTextBoxCell();
                dgvCell.Value = "";
                dgvRow.Cells.Add(dgvCell);

                targetDataGridView.Rows.Add(dgvRow);
                iPos++;
            }
        }

        private bool RefreshAoModbusValue(int i_AoValueStart, int i_AoChTotal, ref DataGridView dgViewModbus)
        {
            int iIdx;
            int[] iValueData;
            string szRange, szFormat;

            if (adamModbus.Modbus().ReadInputRegs(i_AoValueStart, i_AoChTotal, out iValueData))
            {
                for (iIdx = 0; iIdx < i_AoChTotal; iIdx++)
                {
                    szRange = AnalogOutput.GetRangeName(m_Adam6000Type, m_usRange[iIdx]);
                    szFormat = AnalogOutput.GetFloatFormat(m_Adam6000Type, m_usRange[iIdx]);
                    m_usAoValue[iIdx] = Convert.ToUInt16(iValueData[iIdx]);
                    dgViewModbus.Rows[iIdx].Cells[3].Value = m_usAoValue[iIdx].ToString();
                    dgViewModbus.Rows[iIdx].Cells[4].Value = m_usAoValue[iIdx].ToString("X04");
                    dgViewModbus.Rows[iIdx].Cells[5].Value = AnalogOutput.GetScaledValue(m_Adam6000Type, m_usRange[iIdx], m_usAoValue[iIdx]).ToString(szFormat);
                    dgViewModbus.Rows[iIdx].Cells[6].Value = szRange;
                }
                return true;
            }
            return false;
        }

        private bool RefreshDiModbusValue(int i_DiValueStart, int i_DiChTotal, ref DataGridView dgViewModbus)
        {
            int iIdx;
            bool[] iValueData;

            if (adamModbus.Modbus().ReadCoilStatus(i_DiValueStart, i_DiChTotal, out iValueData))
            {
                for (iIdx = 0; iIdx < i_DiChTotal; iIdx++)
                {
                    dgViewModbus.Rows[iIdx].Cells[4].Value = iValueData[iIdx].ToString();
                }
                return true;
            }
            return false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_bStart)
            {
                timer1.Enabled = false;
                adamModbus.Disconnect(); // disconnect slave
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            m_iCount++; // increment the reading counter
            if (tabControlMain.SelectedIndex == 0)
            {
                if (RefreshDiModbusValue(m_DiValueStartAddr, m_iDiTotal, ref dgViewDiChannelInfo))
                    txtReadCount.Text = "Read Coil Status " + m_iCount.ToString() + " times...";
                else
                    txtReadCount.Text = "Read Coil Status failed !";
            }
            else
            {
                if (RefreshAoModbusValue(m_iAoValueStartAddr, m_iAoChTotal, ref dgViewAoChannelInfo))
                    txtReadCount.Text = "Read Registers " + m_iCount.ToString() + " times...";
                else
                    txtReadCount.Text = "Read Registers failed !";
            }

            timer1.Enabled = true;		
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (m_bStart) // was started
            {
                m_bStart = false;		// starting flag
                timer1.Enabled = false; // disable timer
                buttonStart.Text = "Start";
                btnApplyAoSelRange.Enabled = false;
                btnSetAoValue.Enabled = false;
            }
            else	// was stoped
            {
                m_iCount = 0; // reset the reading counter
                timer1.Enabled = true; // enable timer
                buttonStart.Text = "Stop";
                btnApplyAoSelRange.Enabled = true;
                btnSetAoValue.Enabled = true;
                m_bStart = true; // starting flag
            }
        }

        private void tabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_iCount = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < m_iAoChTotal; i++)
            {
                RefreshAoChannelRange(i, false);
            }

            RefreshAoModbusValue(m_iAoValueStartAddr, m_iAoChTotal, ref dgViewAoChannelInfo);
            cbxAoChannel.SelectedIndex = 0;
        }

        private void cbxAoChannel_SelectedIndexChanged(object sender, EventArgs e)
        {
            int iRetryLimit = 10;
            int iRetryCount = 0;

            if (cbxAoChannel.SelectedIndex != this.m_iAoChTotal)
            {
                if (timer1.Enabled)
                {
                    timer1.Enabled = false;
                    RefreshAoChannelRange(cbxAoChannel.SelectedIndex, true);
                    if (cbxAoChannel.SelectedIndex >= 0)
                        dgViewAoChannelInfo.Rows[cbxAoChannel.SelectedIndex].Selected = true;
                    timer1.Enabled = true;
                }
                else
                {
                    RefreshAoChannelRange(cbxAoChannel.SelectedIndex, true);
                    if (cbxAoChannel.SelectedIndex >= 0)
                        dgViewAoChannelInfo.Rows[cbxAoChannel.SelectedIndex].Selected = true;
                }

                gpBoxAoSetValue.Visible = true;
                for (int i = 0; i < iRetryLimit; i++)
                {
                    AnalogOutput.GetRangeHighLow(m_Adam6000Type, m_usRange[cbxAoChannel.SelectedIndex], out m_fHigh, out m_fLow);
                    if ((m_fHigh == 0.0f) && (m_fLow == 0.0f))
                    {
                        iRetryCount++;
                        System.Threading.Thread.Sleep(150);
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                txtSelAoChannel.Text = cbxAoChannel.SelectedIndex.ToString();
                RefreshOutputPanel(m_fHigh, m_fLow);
                if (iRetryCount >= iRetryLimit)
                    MessageBox.Show("AnalogOutput.GetRangeHighLow failed! Please retry again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            }
            else
            {
                gpBoxAoSetValue.Visible = false;
            }
        }

        public void RefreshOutputPanel(float fHigh, float fLow)
        {
            float fOutputVal;

            fOutputVal = AnalogOutput.GetScaledValue(m_Adam6000Type, m_usRange[cbxAoChannel.SelectedIndex], m_usAoValue[cbxAoChannel.SelectedIndex]);

            labAoHigh.Text = fHigh.ToString();
            labAoLow.Text = fLow.ToString();
            txtAoOutputVal.Text = fOutputVal.ToString("0.000");
            try
            {
                tBarAoOutputVal.Value = Convert.ToInt32(tBarAoOutputVal.Minimum + (tBarAoOutputVal.Maximum - tBarAoOutputVal.Minimum) * (fOutputVal - fLow) / (fHigh - fLow));
            }
            catch
            {
                tBarAoOutputVal.Value = 0;
            }
        }

        private void ApplyAoOutputRange(int idxChannel, int idxOutputRange, bool bShowDone)
        {
            int iChannel;
            ushort usOutputRange;
            if (idxChannel != this.m_iAoChTotal)
            {
                usOutputRange = ((ComboItem)(cbxAoOutputRange.Items[idxOutputRange])).GetCode();
                iChannel = idxChannel;

                if (adamModbus.AnalogOutput().SetOutputRange(iChannel, usOutputRange))
                {
                    System.Threading.Thread.Sleep(50);
                    if (bShowDone)
                        MessageBox.Show("Change output range done!", "Information");
                    RefreshAoChannelRange(iChannel, false);
                }
                else
                    MessageBox.Show("Change output range failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
            else
            {
                bool bRet = true;
                usOutputRange = ((ComboItem)(cbxAoOutputRange.Items[idxOutputRange])).GetCode();
                FormPrompt prompt;
                prompt = new FormPrompt();
                prompt.label1.Text = "Set Output Range.....";
                prompt.Show();
                prompt.IncreaseBar(0);
                prompt.Update();

                for (iChannel = 0; iChannel < this.m_iAoChTotal; iChannel++)
                {
                    if (usOutputRange != this.m_usRange[iChannel])
                    {
                        bRet = adamModbus.AnalogOutput().SetOutputRange(iChannel, usOutputRange);
                        System.Threading.Thread.Sleep(100);
                    }
                    prompt.IncreaseBar((prompt.progressBar1.Maximum * iChannel) / m_iAoChTotal);
                    prompt.Update();
                }

                if (bRet)
                {
                    prompt.IncreaseBar(100);
                    prompt.Update();
                    prompt.Close();
                    prompt = null;
                }
                else
                {
                    prompt.Close();
                    prompt = null;
                }

                if (bRet)
                {
                    if (bShowDone)
                        MessageBox.Show("Change range configuration done!", "Information");
                    System.Threading.Thread.Sleep(500);
                    for (iChannel = 0; iChannel < this.m_iAoChTotal; iChannel++)
                        RefreshAoChannelRange(iChannel, false);
                }
                else
                    MessageBox.Show("Change range configuration failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void btnApplyAoSelRange_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Enabled = false;
                ApplyAoOutputRange(cbxAoChannel.SelectedIndex, cbxAoOutputRange.SelectedIndex, true);
                timer1.Enabled = true;
            }
            else
            {
                ApplyAoOutputRange(cbxAoChannel.SelectedIndex, cbxAoOutputRange.SelectedIndex, true);
            }

            cbxAoChannel_SelectedIndexChanged(this, null);
        }

        public static float ConvertUSSingle(string i_szSingle)
        {
            NumberFormatInfo numberFormatInfo = new CultureInfo("en-US", false).NumberFormat;
            float fVal = 0.0f;

            if (i_szSingle != null && i_szSingle.Length > 0)
            {
                try
                {
                    fVal = Convert.ToSingle(i_szSingle);
                }
                catch
                {
                    System.Windows.Forms.MessageBox.Show("Invalid value: " + i_szSingle);
                }
            }

            return fVal;
        }

        private void btnSetAoValue_Click(object sender, EventArgs e)
        {
            float fVal, fHigh, fLow;
            ushort usValue;
            int iPresetRegAddr = 0;
            byte i_byResolution = 12;
            string strVal = txtAoOutputVal.Text.ToString().Trim();

            if (strVal.Length == 0)
            {
                MessageBox.Show("Illegal value!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                return;
            }

            fVal = ConvertUSSingle(strVal);
            AnalogOutput.GetRangeHighLow(m_Adam6000Type, m_usRange[cbxAoChannel.SelectedIndex], out fHigh, out fLow);

            if (fHigh - fLow == 0)
            {
                MessageBox.Show("GetRangeHighLow() failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                return;
            }

            if (fVal > fHigh || fVal < fLow)
            {
                MessageBox.Show("Illegal value! Please enter the value " + fLow.ToString() + " ~ " + fHigh.ToString() + ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                return;
            }

            usValue = Convert.ToUInt16((Convert.ToSingle(System.Math.Pow(2, i_byResolution) - 1) / (fHigh - fLow)) * (fVal - fLow));

            iPresetRegAddr = m_iAoValueStartAddr + cbxAoChannel.SelectedIndex;

            if (adamModbus.Modbus().PresetSingleReg(iPresetRegAddr, (int)usValue))
            {
                m_usAoValue[cbxAoChannel.SelectedIndex] = usValue;
            }
            else
                MessageBox.Show("PresetSingleReg() failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

            cbxAoChannel_SelectedIndexChanged(this, null);
        }

        private void txtAoOutputVal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar.CompareTo('0') >= 0) && (e.KeyChar.CompareTo('9') <= 0))
                e.Handled = false;
            else if (e.KeyChar.CompareTo('.') == 0 || (e.KeyChar.CompareTo(',') == 0))
                e.Handled = false;
            else if (e.KeyChar == (char)8)
                e.Handled = false;
            else if (e.KeyChar == 0x2d)
                e.Handled = false;
            else if (e.KeyChar == (char)13) //Enter
            {
                btnSetAoValue_Click(this, null);
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void txtAoOutputVal_MouseDown(object sender, MouseEventArgs e)
        {
            txtAoOutputVal.SelectAll();
        }

        private void tBarAoOutputVal_MouseDown(object sender, MouseEventArgs e)
        {
            txtAoOutputVal.SelectAll();
        }

        private void tBarAoOutputVal_ValueChanged(object sender, EventArgs e)
        {
            float fVal;
            fVal = (m_fHigh - m_fLow) * (tBarAoOutputVal.Value - tBarAoOutputVal.Minimum) / (tBarAoOutputVal.Maximum - tBarAoOutputVal.Minimum) + m_fLow;
            txtAoOutputVal.Text = fVal.ToString("0.000");
        }
    }
}