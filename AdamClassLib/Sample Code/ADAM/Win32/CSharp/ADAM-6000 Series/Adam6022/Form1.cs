using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Advantech.Adam;
using System.Net.Sockets;

namespace Adam6022
{
    public partial class Form1 : Form
    {
        private PID_Loop m_loopBase;
        private float[] m_pv1LblHigh, m_pv1LblLow;
        private float[] m_pv2LblHigh, m_pv2LblLow;
        private float[] m_dVals;
        private int trackSVValue;

        private int m_iCount;
        private bool m_bStart;
        private AdamSocket adamModbus;
        private Adam6000Type m_Adam6000Type;
        private string m_szIP;
        private int m_iPort;

        public Form1()
        {
            InitializeComponent();

            m_bStart = false;			// the action stops at the beginning
            m_szIP = "172.18.3.201";	// modbus slave IP address
            m_iPort = 502;				// modbus TCP port is 502
            adamModbus = new AdamSocket();
            adamModbus.SetTimeout(1000, 1000, 1000); // set timeout for TCP

            m_Adam6000Type = Adam6000Type.Adam6022; // the sample is for ADAM-6050

            m_dVals = new float[3];
            m_pv1LblHigh = new float[2];
            m_pv1LblLow = new float[2];
            m_pv2LblHigh = new float[2];
            m_pv2LblLow = new float[2];

            txtModule.Text = m_Adam6000Type.ToString();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_bStart)
            {
                timer1.Enabled = false; // disable timer
                adamModbus.Disconnect(); // disconnect slave
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            bool bRet;

            if (m_bStart) // was started
            {
                panelPID.Enabled = false;
                m_bStart = false;		// starting flag
                timer1.Enabled = false; // disable timer
                adamModbus.Disconnect(); // disconnect slave
                buttonStart.Text = "Start";
            }
            else	// was stoped
            {
                if (adamModbus.Connect(m_szIP, ProtocolType.Tcp, m_iPort))
                {
                    m_iCount = 0; // reset the reading counter

                    if (cbxLoop.SelectedIndex >= 0)
                        RefreshPIDValue();
                    else
                    {
                        // PID
                        m_loopBase = PID_Loop.Loop0;
                        bRet = (adamModbus.Pid().ModbusRefreshBuffer(PID_Loop.Loop0) && adamModbus.Pid().ModbusRefreshBuffer(PID_Loop.Loop1));

                        if (bRet)
                        {
                            m_pv1LblHigh[0] = adamModbus.Pid().GetBufferFloat(PID_Loop.Loop0, PID_Addr.Sv1HighLimit);
                            m_pv1LblHigh[1] = adamModbus.Pid().GetBufferFloat(PID_Loop.Loop1, PID_Addr.Sv1HighLimit);
                            m_pv1LblLow[0] = adamModbus.Pid().GetBufferFloat(PID_Loop.Loop0, PID_Addr.Sv1LowLimit);
                            m_pv1LblLow[1] = adamModbus.Pid().GetBufferFloat(PID_Loop.Loop1, PID_Addr.Sv1LowLimit);
                            m_pv2LblHigh[0] = adamModbus.Pid().GetBufferFloat(PID_Loop.Loop0, PID_Addr.Sv2HighLimit);
                            m_pv2LblHigh[1] = adamModbus.Pid().GetBufferFloat(PID_Loop.Loop1, PID_Addr.Sv2HighLimit);
                            m_pv2LblLow[0] = adamModbus.Pid().GetBufferFloat(PID_Loop.Loop0, PID_Addr.Sv2LowLimit);
                            m_pv2LblLow[1] = adamModbus.Pid().GetBufferFloat(PID_Loop.Loop1, PID_Addr.Sv2LowLimit);
                            RefreshPIDStatic();
                        }
                        else
                        {
                            MessageBox.Show("Failed to refresh data!", "Error");
                            return;
                        }
                    }
                    //
                    panelPID.Enabled = true;
                    timer1.Enabled = true; // enable timer
                    buttonStart.Text = "Stop";
                    m_bStart = true; // starting flag
                }
                else
                    MessageBox.Show("Connect to " + m_szIP + " failed", "Error");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            m_iCount++;
            txtReadCount.Text = "Polling " + m_iCount.ToString() + " times...";
            if (RefreshPIDValue())
                txtReadCount.Text = "Polling " + m_iCount.ToString() + " times...";
            else
                txtReadCount.Text = "Polling " + m_iCount.ToString() + " times... (Fail to read)";
        }

        private bool RefreshPIDValue()
        {
            bool bRet;
            int iSVGraphPer, iPVGraphPer, iMVGraphPer;
            float fVal;
            int iVal;

            bRet = adamModbus.Pid().ModbusRefreshBuffer(m_loopBase);

            if (bRet)
            {
                // check divider
                if ((m_pv1LblHigh[Convert.ToInt32(m_loopBase)] == m_pv1LblLow[Convert.ToInt32(m_loopBase)]) ||
                    (m_pv2LblHigh[Convert.ToInt32(m_loopBase)] == m_pv2LblLow[Convert.ToInt32(m_loopBase)]) ||
                    adamModbus.Pid().GetBufferInt(m_loopBase, PID_Addr.MvRangeHigh) == adamModbus.Pid().GetBufferInt(m_loopBase, PID_Addr.MvRangeLow))
                    return false;
                // graph bound check
                if (adamModbus.Pid().GetBufferFloat(m_loopBase, PID_Addr.Pv1EngData) > m_pv1LblHigh[Convert.ToInt32(m_loopBase)])
                {
                    if (adamModbus.Pid().GetBufferFloat(m_loopBase, PID_Addr.Pv1EngData) + 1f < adamModbus.Pid().GetBufferFloat(m_loopBase, PID_Addr.Pv1RangeHigh))
                        m_pv1LblHigh[Convert.ToInt32(m_loopBase)] = adamModbus.Pid().GetBufferFloat(m_loopBase, PID_Addr.Pv1EngData) + 1f;
                    else
                        m_pv1LblHigh[Convert.ToInt32(m_loopBase)] = adamModbus.Pid().GetBufferFloat(m_loopBase, PID_Addr.Pv1RangeHigh);
                    RefreshPIDStatic();
                }
                else if (adamModbus.Pid().GetBufferFloat(m_loopBase, PID_Addr.Pv1EngData) < m_pv1LblLow[Convert.ToInt32(m_loopBase)])
                {
                    if (adamModbus.Pid().GetBufferFloat(m_loopBase, PID_Addr.Pv1EngData) > adamModbus.Pid().GetBufferFloat(m_loopBase, PID_Addr.Pv1RangeLow) - 1f)
                        m_pv1LblLow[Convert.ToInt32(m_loopBase)] = adamModbus.Pid().GetBufferFloat(m_loopBase, PID_Addr.Pv1EngData) - 1000;
                    else
                        m_pv1LblLow[Convert.ToInt32(m_loopBase)] = adamModbus.Pid().GetBufferFloat(m_loopBase, PID_Addr.Pv1RangeLow);
                    RefreshPIDStatic();
                }
                // SV
                iSVGraphPer = Convert.ToInt32((adamModbus.Pid().GetBufferFloat(m_loopBase, PID_Addr.Sv1) - m_pv1LblLow[Convert.ToInt32(m_loopBase)]) * 100f /
                    (m_pv1LblHigh[Convert.ToInt32(m_loopBase)] - m_pv1LblLow[Convert.ToInt32(m_loopBase)]));
                // PV
                if (adamModbus.Pid().GetBufferInt(m_loopBase, PID_Addr.Pv1OpenWireFlag) == 0)
                {
                    fVal = adamModbus.Pid().GetBufferFloat(m_loopBase, PID_Addr.Pv1EngData);
                    txtPV.Text = fVal.ToString("#0.000");
                }
                else
                    txtPV.Text = "*****";
                iPVGraphPer = Convert.ToInt32((adamModbus.Pid().GetBufferFloat(m_loopBase, PID_Addr.Pv1EngData) - m_pv1LblLow[Convert.ToInt32(m_loopBase)]) * 100f /
                    (m_pv1LblHigh[Convert.ToInt32(m_loopBase)] - m_pv1LblLow[Convert.ToInt32(m_loopBase)]));
                progressBarPV.Value = iPVGraphPer;
                // MV
                fVal = (adamModbus.Pid().GetBufferFloat(m_loopBase, PID_Addr.MvEngData) - adamModbus.Pid().GetBufferFloat(m_loopBase, PID_Addr.MvRangeLow)) * 100f /
                    (adamModbus.Pid().GetBufferFloat(m_loopBase, PID_Addr.MvRangeHigh) - adamModbus.Pid().GetBufferFloat(m_loopBase, PID_Addr.MvRangeLow));
                iMVGraphPer = Convert.ToInt32(fVal);
                if (!txtMV.Focused)
                    txtMV.Text = fVal.ToString("#0.000");
                progressBarMV.Value = iMVGraphPer;
                // PV alarm
                iVal = adamModbus.Pid().GetBufferInt(m_loopBase, PID_Addr.Pv1AlarmStatus);
                adamLightPV.Value = (iVal != 0);
                if (iVal == 0)
                    txtPVAlarm.Text = "Normal";
                else if (iVal == 1)
                    txtPVAlarm.Text = "H-High alarm";
                else if (iVal == 2)
                    txtPVAlarm.Text = "High alarm";
                else if (iVal == 3)
                    txtPVAlarm.Text = "Low alarm";
                else
                    txtPVAlarm.Text = "L-Low alarm";
                // MV alarm
                iVal = adamModbus.Pid().GetBufferInt(m_loopBase, PID_Addr.MvAlarmStatus);
                adamLightMV.Value = (iVal != 0);
                if (iVal == 0)
                    txtMVAlarm.Text = "Normal";
                else if (iVal == 1)
                    txtMVAlarm.Text = "High alarm";
                else
                    txtMVAlarm.Text = "Low alarm";
                m_dVals[0] = Convert.ToSingle(iSVGraphPer);
                m_dVals[1] = Convert.ToSingle(iPVGraphPer);
                m_dVals[2] = Convert.ToSingle(iMVGraphPer);
                adamTrend1.UpdateGraph(m_dVals);
                return true;
            }
            return false;
        }

        private bool RefreshPIDStatic()
        {
            float fVal;

            if ((m_pv1LblHigh[Convert.ToInt32(m_loopBase)] == m_pv1LblLow[Convert.ToInt32(m_loopBase)]) ||
                (m_pv2LblHigh[Convert.ToInt32(m_loopBase)] == m_pv2LblLow[Convert.ToInt32(m_loopBase)]))
                return false;
            cbxLoop.SelectedIndex = Convert.ToInt32(m_loopBase);
            cbxControl.SelectedIndex = adamModbus.Pid().GetBufferInt(m_loopBase, PID_Addr.ControlMode);
            // MV text
            if (adamModbus.Pid().GetBufferInt(m_loopBase, PID_Addr.ControlMode) == 1) // PID auto mode
                txtMV.ReadOnly = true;
            else
                txtMV.ReadOnly = false;
            // PV
            // graph's high/low limit
            txtGraphHigh.Text = m_pv1LblHigh[Convert.ToInt32(m_loopBase)].ToString("#0.000");
            txtGraphLow.Text = m_pv1LblLow[Convert.ToInt32(m_loopBase)].ToString("#0.000");
            // SV trackbar
            fVal = adamModbus.Pid().GetBufferFloat(m_loopBase, PID_Addr.Sv1);
            txtSV.Text = fVal.ToString("#0.000");
            trackBarSV.Value = Convert.ToInt32(((adamModbus.Pid().GetBufferFloat(m_loopBase, PID_Addr.Sv1) - m_pv1LblLow[Convert.ToInt32(m_loopBase)]) * trackBarSV.Maximum) /
                (m_pv1LblHigh[Convert.ToInt32(m_loopBase)] - m_pv1LblLow[Convert.ToInt32(m_loopBase)]));
            trackSVValue = trackBarSV.Value;
            lblSVHigh.Text = txtGraphHigh.Text;
            lblSVLow.Text = txtGraphLow.Text;
            return true;
        }

        private void cbxLoop_SelectedIndexChanged(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            m_loopBase = (PID_Loop)cbxLoop.SelectedIndex;
            adamTrend1.ClearGraph();
            if (!RefreshPIDStatic())
                MessageBox.Show("Hi-Lo range Setting is invalid!", "Error");
            timer1.Enabled = true;
        }

        private void cbxControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool bRet;
            int iControl;

            timer1.Enabled = false;
            iControl = cbxControl.SelectedIndex;

            bRet = adamModbus.Pid().ModbusSetValue(m_loopBase, PID_Addr.ControlMode, iControl);
            if (bRet)
                adamModbus.Pid().SetBufferInt(m_loopBase, PID_Addr.ControlMode, iControl);
            else
                MessageBox.Show("Failed to change data!", "Error");
            if (!RefreshPIDStatic())
                MessageBox.Show("Hi-Lo range Setting is invalid!", "Error");
            timer1.Enabled = true;
        }

        private void trackBarSV_ValueChanged(object sender, EventArgs e)
        {
            bool bRet;
            float svLarge, fHigh, fLow;
            string szMsg;

            if (trackSVValue == trackBarSV.Value)
                return;

            timer1.Enabled = false;
            svLarge = m_pv1LblLow[Convert.ToInt32(m_loopBase)] + (m_pv1LblHigh[Convert.ToInt32(m_loopBase)] - m_pv1LblLow[Convert.ToInt32(m_loopBase)]) * trackBarSV.Value / 20f;
            fHigh = adamModbus.Pid().GetBufferFloat(m_loopBase, PID_Addr.Sv1HighLimit);
            fLow = adamModbus.Pid().GetBufferFloat(m_loopBase, PID_Addr.Sv1LowLimit);
            if (svLarge >= fLow &&
                svLarge <= fHigh)
            {
                bRet = adamModbus.Pid().ModbusSetValue(m_loopBase, PID_Addr.Sv1, svLarge);

                if (bRet)
                    adamModbus.Pid().SetBufferFloat(m_loopBase, PID_Addr.Sv1, svLarge);
                else
                    MessageBox.Show("Failed to set data!", "Error");
            }
            else
            {
                trackBarSV.Value = trackSVValue;
                szMsg = " (MUST: " + fLow.ToString() + " <= value <= " + fHigh.ToString() + ")";
                MessageBox.Show("SV value is out of range!" + szMsg, "Error");
            }
            if (!RefreshPIDStatic())
                MessageBox.Show("Hi-Lo range Setting is invalid!", "Error");
            timer1.Enabled = true;
        }

        private void txtSV_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool bRet;
            float svLarge, fHigh, fLow;
            string szMsg;

            if ((e.KeyChar.CompareTo('0') >= 0) && (e.KeyChar.CompareTo('9') <= 0))
                e.Handled = false;
            else if ((e.KeyChar == (char)8) || (e.KeyChar.CompareTo('.') == 0) ||
                (e.KeyChar.CompareTo('+') == 0) || (e.KeyChar.CompareTo('-') == 0))
                e.Handled = false;
            else if ((e.KeyChar == (char)13))
            {
                if (txtSV.Text.Length > 0)
                {
                    timer1.Enabled = false;
                    svLarge = Convert.ToSingle(txtSV.Text);
                    if (svLarge != adamModbus.Pid().GetBufferFloat(m_loopBase, PID_Addr.Sv1))
                    {
                        fHigh = adamModbus.Pid().GetBufferFloat(m_loopBase, PID_Addr.Sv1HighLimit);
                        fLow = adamModbus.Pid().GetBufferFloat(m_loopBase, PID_Addr.Sv1LowLimit);
                        if (svLarge >= fLow &&
                            svLarge <= fHigh)
                        {
                            bRet = adamModbus.Pid().ModbusSetValue(m_loopBase, PID_Addr.Sv1, svLarge);

                            if (bRet)
                                adamModbus.Pid().SetBufferFloat(m_loopBase, PID_Addr.Sv1, svLarge);
                            else
                                MessageBox.Show("Failed to set data!", "Error");
                        }
                        else
                        {
                            szMsg = " (MUST: " + fLow.ToString() + " <= value <= " + fHigh.ToString() + ")";
                            MessageBox.Show("SV value is out of range!" + szMsg, "Error");
                        }
                    }
                    if (!RefreshPIDStatic())
                        MessageBox.Show("Hi-Lo range Setting is invalid!", "Error");
                    timer1.Enabled = true;
                }
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void txtMV_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool bRet;
            float MVLarge, MVValue, fHigh, fLow;
            string szMsg;

            if ((e.KeyChar.CompareTo('0') >= 0) && (e.KeyChar.CompareTo('9') <= 0))
                e.Handled = false;
            else if ((e.KeyChar == (char)8) || (e.KeyChar.CompareTo('.') == 0) ||
                (e.KeyChar.CompareTo('+') == 0) || (e.KeyChar.CompareTo('-') == 0))
                e.Handled = false;
            else if ((e.KeyChar == (char)13))
            {
                if (txtMV.Text.Length > 0)
                {
                    timer1.Enabled = false;
                    MVLarge = Convert.ToSingle(txtMV.Text);
                    if (MVLarge >= 0f && MVLarge <= 100f)
                    {
                        MVValue = adamModbus.Pid().GetBufferFloat(m_loopBase, PID_Addr.MvRangeLow) +
                            (adamModbus.Pid().GetBufferFloat(m_loopBase, PID_Addr.MvRangeHigh) -
                            adamModbus.Pid().GetBufferFloat(m_loopBase, PID_Addr.MvRangeLow)) * MVLarge / 100f;
                        if (MVValue != adamModbus.Pid().GetBufferFloat(m_loopBase, PID_Addr.MvEngData))
                        {
                            fHigh = adamModbus.Pid().GetBufferFloat(m_loopBase, PID_Addr.MvHighLimit);
                            fLow = adamModbus.Pid().GetBufferFloat(m_loopBase, PID_Addr.MvLowLimit);
                            if (MVValue >= fLow &&
                                MVValue <= fHigh)
                            {
                                bRet = adamModbus.Pid().ModbusSetValue(m_loopBase, PID_Addr.MvEngData, MVValue);

                                if (bRet)
                                {
                                    adamModbus.Pid().SetBufferFloat(m_loopBase, PID_Addr.MvEngData, MVValue);
                                    txtSV.Focus();
                                }
                                else
                                    MessageBox.Show("Failed to set data!", "Error");
                            }
                            else
                            {
                                szMsg = " (MUST: " + fLow.ToString() + " <= value <= " + fHigh.ToString() + ")";
                                MessageBox.Show("MV value is out of limit!" + szMsg, "Error");
                            }
                        }
                    }
                    else
                        MessageBox.Show("MV value is out of range! (0.0~100.0)", "Error");
                    timer1.Enabled = true;
                }
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void txtGraphHigh_KeyPress(object sender, KeyPressEventArgs e)
        {
            float fGraphHigh, fHigh, fLow, fLimit;
            string szMsg;

            if ((e.KeyChar.CompareTo('0') >= 0) && (e.KeyChar.CompareTo('9') <= 0))
                e.Handled = false;
            else if ((e.KeyChar == (char)8) || (e.KeyChar.CompareTo('.') == 0) ||
                (e.KeyChar.CompareTo('+') == 0) || (e.KeyChar.CompareTo('-') == 0))
                e.Handled = false;
            else if ((e.KeyChar == (char)13))
            {
                if (txtGraphHigh.Text.Length > 0)
                {
                    timer1.Enabled = false;
                    fGraphHigh = Convert.ToSingle(txtGraphHigh.Text);
                    if (fGraphHigh != m_pv1LblHigh[Convert.ToInt32(m_loopBase)])
                    {
                        fHigh = adamModbus.Pid().GetBufferFloat(m_loopBase, PID_Addr.Pv1RangeHigh);
                        fLow = adamModbus.Pid().GetBufferFloat(m_loopBase, PID_Addr.Pv1EngData);
                        fLimit = adamModbus.Pid().GetBufferFloat(m_loopBase, PID_Addr.Sv1);
                        if (fGraphHigh <= fHigh &&
                            fGraphHigh >= fLimit &&
                            fGraphHigh >= fLow)
                            m_pv1LblHigh[Convert.ToInt32(m_loopBase)] = fGraphHigh;
                        else
                        {
                            if (fLimit >= fLow)
                                szMsg = " (MUST: " + fLimit.ToString() + " <= value < " + fHigh.ToString() + ")";
                            else
                                szMsg = " (MUST: " + fLow.ToString() + " <= value <= " + fHigh.ToString() + ")";
                            MessageBox.Show("Value is out of range!" + szMsg, "Error");
                        }
                    }
                    if (!RefreshPIDStatic())
                        MessageBox.Show("Hi-Lo range Setting is invalid!", "Error");
                    timer1.Enabled = true;
                }
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void txtGraphLow_KeyPress(object sender, KeyPressEventArgs e)
        {
            float fGraphLow, fHigh, fLow, fLimit;
            string szMsg;

            if ((e.KeyChar.CompareTo('0') >= 0) && (e.KeyChar.CompareTo('9') <= 0))
                e.Handled = false;
            else if ((e.KeyChar == (char)8) || (e.KeyChar.CompareTo('.') == 0) ||
                (e.KeyChar.CompareTo('+') == 0) || (e.KeyChar.CompareTo('-') == 0))
                e.Handled = false;
            else if ((e.KeyChar == (char)13))
            {
                if (txtGraphLow.Text.Length > 0)
                {
                    timer1.Enabled = false;
                    fGraphLow = Convert.ToSingle(txtGraphLow.Text);
                    if (fGraphLow != m_pv1LblLow[Convert.ToInt32(m_loopBase)])
                    {
                        fHigh = adamModbus.Pid().GetBufferFloat(m_loopBase, PID_Addr.Pv1EngData);
                        fLow = adamModbus.Pid().GetBufferFloat(m_loopBase, PID_Addr.Pv1RangeLow);
                        fLimit = adamModbus.Pid().GetBufferFloat(m_loopBase, PID_Addr.Sv1);
                        if (fGraphLow >= fLow &&
                            fGraphLow <= fLimit &&
                            fGraphLow <= fHigh)
                            m_pv1LblLow[Convert.ToInt32(m_loopBase)] = fGraphLow;
                        else
                        {
                            if (fLimit >= fHigh)
                                szMsg = " (MUST: " + fLow.ToString() + " <= value < " + fHigh.ToString() + ")";
                            else
                                szMsg = " (MUST: " + fLow.ToString() + " <= value <= " + fLimit.ToString() + ")";
                            MessageBox.Show("Value is out of range!" + szMsg, "Error");
                        }
                    }
                    if (!RefreshPIDStatic())
                        MessageBox.Show("Hi-Lo range Setting is invalid!", "Error");
                    timer1.Enabled = true;
                }
                e.Handled = false;
            }
            else
                e.Handled = true;
        }
    }
}
