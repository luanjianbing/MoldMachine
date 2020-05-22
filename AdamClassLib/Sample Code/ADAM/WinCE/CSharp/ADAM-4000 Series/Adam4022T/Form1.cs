using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Advantech.Common;
using Advantech.Adam;

namespace Adam4022T
{
    public partial class Form1 : Form
    {
        private int m_iCom, m_iAddr, m_iCount;
        private bool m_bStart;
        private Adam4000Type m_Adam4000Type;
        private AdamCom adamCom;
        private PID_Loop m_loopBase;
        private float[] m_pv1LblHigh, m_pv1LblLow;
        private float[] m_pv2LblHigh, m_pv2LblLow;
        private float[] m_dVals;
        private int trackSVValue;
        private bool m_AsciiProtocol;

        public Form1()
        {
            InitializeComponent();

            m_iCom = 4;				// using COM4
            m_iAddr = 1;			// the slave address is 1
            m_iCount = 0;			// the counting start from 0
            m_AsciiProtocol = true; // the protocol is Advantech ASCII
            m_bStart = false;
            m_Adam4000Type = Adam4000Type.Adam4022T; // the sample is for ADAM-4022T
            adamCom = new AdamCom(m_iCom);
            adamCom.Checksum = false; // disbale checksum

            txtModule.Text = m_Adam4000Type.ToString();
            m_pv1LblHigh = new float[2];
            m_pv1LblLow = new float[2];
            m_pv2LblHigh = new float[2];
            m_pv2LblLow = new float[2];
            m_dVals = new float[3]; // for SV, PV, MV
        }

        private void Form1_Closing(object sender, CancelEventArgs e)
        {
            if (m_bStart)
            {
                timer1.Enabled = false; // disable timer
                adamCom.CloseComPort(); // close the COM port
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            bool bRet;
            if (m_bStart) // was started
            {
                panelPID.Enabled = false;
                m_bStart = false;
                timer1.Enabled = false;
                adamCom.CloseComPort();
                buttonStart.Text = "Start";
            }
            else
            {
                if (adamCom.OpenComPort())
                {
                    // set COM port state, 9600,N,8,1
                    adamCom.SetComPortState(Baudrate.Baud_9600, Databits.Eight, Parity.None, Stopbits.One);
                    // set COM port timeout
                    adamCom.SetComPortTimeout(500, 500, 0, 500, 0);
                    m_iCount = 0; // reset the reading counter
                    //
                    if (cbxLoop.SelectedIndex >= 0)
                        RefreshPIDValue();
                    else
                    {
                        // PID
                        m_loopBase = PID_Loop.Loop0;
                        if (m_AsciiProtocol)
                            bRet = (adamCom.Pid(m_iAddr).AsciiRefreshBuffer(PID_Loop.Loop0) && adamCom.Pid(m_iAddr).AsciiRefreshBuffer(PID_Loop.Loop1));
                        else
                            bRet = (adamCom.Pid(m_iAddr).ModbusRefreshBuffer(PID_Loop.Loop0) && adamCom.Pid(m_iAddr).ModbusRefreshBuffer(PID_Loop.Loop1));
                        if (bRet)
                        {
                            m_pv1LblHigh[0] = adamCom.Pid(m_iAddr).GetBufferFloat(PID_Loop.Loop0, PID_Addr.Sv1HighLimit);
                            m_pv1LblHigh[1] = adamCom.Pid(m_iAddr).GetBufferFloat(PID_Loop.Loop1, PID_Addr.Sv1HighLimit);
                            m_pv1LblLow[0] = adamCom.Pid(m_iAddr).GetBufferFloat(PID_Loop.Loop0, PID_Addr.Sv1LowLimit);
                            m_pv1LblLow[1] = adamCom.Pid(m_iAddr).GetBufferFloat(PID_Loop.Loop1, PID_Addr.Sv1LowLimit);
                            m_pv2LblHigh[0] = adamCom.Pid(m_iAddr).GetBufferFloat(PID_Loop.Loop0, PID_Addr.Sv2HighLimit);
                            m_pv2LblHigh[1] = adamCom.Pid(m_iAddr).GetBufferFloat(PID_Loop.Loop1, PID_Addr.Sv2HighLimit);
                            m_pv2LblLow[0] = adamCom.Pid(m_iAddr).GetBufferFloat(PID_Loop.Loop0, PID_Addr.Sv2LowLimit);
                            m_pv2LblLow[1] = adamCom.Pid(m_iAddr).GetBufferFloat(PID_Loop.Loop1, PID_Addr.Sv2LowLimit);
                            RefreshPIDStatic();
                        }
                        else
                        {
                            MessageBox.Show("Failed to refresh data!", "Error");
                            adamCom.CloseComPort();
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
                    MessageBox.Show("Failed to open COM port!", "Error");
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

            if (m_AsciiProtocol)
                bRet = adamCom.Pid(m_iAddr).AsciiRefreshBuffer(m_loopBase);
            else
                bRet = adamCom.Pid(m_iAddr).ModbusRefreshBuffer(m_loopBase);
            if (bRet)
            {
                // check divider
                if ((m_pv1LblHigh[Convert.ToInt32(m_loopBase)] == m_pv1LblLow[Convert.ToInt32(m_loopBase)]) ||
                    (m_pv2LblHigh[Convert.ToInt32(m_loopBase)] == m_pv2LblLow[Convert.ToInt32(m_loopBase)]) ||
                    adamCom.Pid(m_iAddr).GetBufferInt(m_loopBase, PID_Addr.MvRangeHigh) == adamCom.Pid(m_iAddr).GetBufferInt(m_loopBase, PID_Addr.MvRangeLow))
                    return false;
                // graph bound check
                if (adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.Pv1EngData) > m_pv1LblHigh[Convert.ToInt32(m_loopBase)])
                {
                    if (adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.Pv1EngData) + 1f < adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.Pv1RangeHigh))
                        m_pv1LblHigh[Convert.ToInt32(m_loopBase)] = adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.Pv1EngData) + 1f;
                    else
                        m_pv1LblHigh[Convert.ToInt32(m_loopBase)] = adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.Pv1RangeHigh);
                    RefreshPIDStatic();
                }
                else if (adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.Pv1EngData) < m_pv1LblLow[Convert.ToInt32(m_loopBase)])
                {
                    if (adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.Pv1EngData) > adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.Pv1RangeLow) - 1f)
                        m_pv1LblLow[Convert.ToInt32(m_loopBase)] = adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.Pv1EngData) - 1000;
                    else
                        m_pv1LblLow[Convert.ToInt32(m_loopBase)] = adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.Pv1RangeLow);
                    RefreshPIDStatic();
                }
                // SV
                iSVGraphPer = Convert.ToInt32((adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.Sv1) - m_pv1LblLow[Convert.ToInt32(m_loopBase)]) * 100f /
                    (m_pv1LblHigh[Convert.ToInt32(m_loopBase)] - m_pv1LblLow[Convert.ToInt32(m_loopBase)]));
                // PV
                if (adamCom.Pid(m_iAddr).GetBufferInt(m_loopBase, PID_Addr.Pv1OpenWireFlag) == 0)
                {
                    fVal = adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.Pv1EngData);
                    txtPV.Text = fVal.ToString("#0.000");
                }
                else
                    txtPV.Text = "*****";
                iPVGraphPer = Convert.ToInt32((adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.Pv1EngData) - m_pv1LblLow[Convert.ToInt32(m_loopBase)]) * 100f /
                    (m_pv1LblHigh[Convert.ToInt32(m_loopBase)] - m_pv1LblLow[Convert.ToInt32(m_loopBase)]));
                progressBarPV.Value = iPVGraphPer;
                // MV
                fVal = (adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.MvEngData) - adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.MvRangeLow)) * 100f /
                    (adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.MvRangeHigh) - adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.MvRangeLow));
                iMVGraphPer = Convert.ToInt32(fVal);
                if (!txtMV.Focused)
                    txtMV.Text = fVal.ToString("#0.000");
                progressBarMV.Value = iMVGraphPer;
                // PV alarm
                iVal = adamCom.Pid(m_iAddr).GetBufferInt(m_loopBase, PID_Addr.Pv1AlarmStatus);
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
                iVal = adamCom.Pid(m_iAddr).GetBufferInt(m_loopBase, PID_Addr.MvAlarmStatus);
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
            cbxControl.SelectedIndex = adamCom.Pid(m_iAddr).GetBufferInt(m_loopBase, PID_Addr.ControlMode);
            // MV text
            if (adamCom.Pid(m_iAddr).GetBufferInt(m_loopBase, PID_Addr.ControlMode) == 1) // PID auto mode
                txtMV.ReadOnly = true;
            else
                txtMV.ReadOnly = false;
            // PV
            // graph's high/low limit
            txtGraphHigh.Text = m_pv1LblHigh[Convert.ToInt32(m_loopBase)].ToString("#0.000");
            txtGraphLow.Text = m_pv1LblLow[Convert.ToInt32(m_loopBase)].ToString("#0.000");
            // SV trackbar
            fVal = adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.Sv1);
            txtSV.Text = fVal.ToString("#0.000");
            trackBarSV.Value = Convert.ToInt32(((adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.Sv1) - m_pv1LblLow[Convert.ToInt32(m_loopBase)]) * trackBarSV.Maximum) /
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
            if (m_AsciiProtocol)
                bRet = adamCom.Pid(m_iAddr).AsciiSetValue(m_loopBase, PID_Addr.ControlMode, iControl);
            else
                bRet = adamCom.Pid(m_iAddr).ModbusSetValue(m_loopBase, PID_Addr.ControlMode, iControl);
            if (bRet)
                adamCom.Pid(m_iAddr).SetBufferInt(m_loopBase, PID_Addr.ControlMode, iControl);
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
            fHigh = adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.Sv1HighLimit);
            fLow = adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.Sv1LowLimit);
            if (svLarge >= fLow &&
                svLarge <= fHigh)
            {
                if (m_AsciiProtocol)
                    bRet = adamCom.Pid(m_iAddr).AsciiSetValue(m_loopBase, PID_Addr.Sv1, svLarge);
                else
                    bRet = adamCom.Pid(m_iAddr).ModbusSetValue(m_loopBase, PID_Addr.Sv1, svLarge);
                if (bRet)
                    adamCom.Pid(m_iAddr).SetBufferFloat(m_loopBase, PID_Addr.Sv1, svLarge);
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
                    if (svLarge != adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.Sv1))
                    {
                        fHigh = adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.Sv1HighLimit);
                        fLow = adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.Sv1LowLimit);
                        if (svLarge >= fLow &&
                            svLarge <= fHigh)
                        {
                            if (m_AsciiProtocol)
                                bRet = adamCom.Pid(m_iAddr).AsciiSetValue(m_loopBase, PID_Addr.Sv1, svLarge);
                            else
                                bRet = adamCom.Pid(m_iAddr).ModbusSetValue(m_loopBase, PID_Addr.Sv1, svLarge);
                            if (bRet)
                                adamCom.Pid(m_iAddr).SetBufferFloat(m_loopBase, PID_Addr.Sv1, svLarge);
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
                        MVValue = adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.MvRangeLow) +
                            (adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.MvRangeHigh) -
                            adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.MvRangeLow)) * MVLarge / 100f;
                        if (MVValue != adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.MvEngData))
                        {
                            fHigh = adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.MvHighLimit);
                            fLow = adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.MvLowLimit);
                            if (MVValue >= fLow &&
                                MVValue <= fHigh)
                            {
                                if (m_AsciiProtocol)
                                    bRet = adamCom.Pid(m_iAddr).AsciiSetValue(m_loopBase, PID_Addr.MvEngData, MVValue);
                                else
                                    bRet = adamCom.Pid(m_iAddr).ModbusSetValue(m_loopBase, PID_Addr.MvEngData, MVValue);
                                if (bRet)
                                {
                                    adamCom.Pid(m_iAddr).SetBufferFloat(m_loopBase, PID_Addr.MvEngData, MVValue);
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
                        fHigh = adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.Pv1RangeHigh);
                        fLow = adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.Pv1EngData);
                        fLimit = adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.Sv1);
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
                        fHigh = adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.Pv1EngData);
                        fLow = adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.Pv1RangeLow);
                        fLimit = adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.Sv1);
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

        private void txtGraphHigh_LostFocus(object sender, EventArgs e)
        {
            RefreshPIDStatic();
        }

        private void txtGraphLow_LostFocus(object sender, EventArgs e)
        {
            RefreshPIDStatic();
        }

        private void txtSV_LostFocus(object sender, EventArgs e)
        {
            RefreshPIDStatic();
        }

        private void txtMV_LostFocus(object sender, EventArgs e)
        {
            RefreshPIDStatic();
        }
    }
}