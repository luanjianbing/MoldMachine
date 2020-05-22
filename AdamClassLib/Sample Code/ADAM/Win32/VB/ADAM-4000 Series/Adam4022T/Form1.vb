Imports Advantech.Common
Imports Advantech.Adam

Public Class Form1
    Private m_iCom As Integer, m_iAddr As Integer, m_iCount As Integer
    Private m_bStart As Boolean
    Private m_Adam4000Type As Adam4000Type
    Private adamCom As AdamCom
    Private m_loopBase As PID_Loop
    Private m_pv1LblHigh() As Single, m_pv1LblLow() As Single
    Private m_pv2LblHigh() As Single, m_pv2LblLow() As Single
    Private m_dVals() As Single
    Private trackSVValue As Integer
    Private m_AsciiProtocol As Boolean

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        m_iCom = 4                              ' using COM2
        m_iAddr = 0                             ' the slave address is 1
        m_iCount = 0                            ' the counting start from 0
        m_AsciiProtocol = True                  ' the protocol is Advantech ASCII
        m_bStart = False
        m_Adam4000Type = Adam4000Type.Adam4022T ' the sample is for ADAM-4022T
        adamCom = New AdamCom(m_iCom)
        adamCom.Checksum = False                ' disbale checksum

        txtModule.Text = m_Adam4000Type.ToString()
        m_pv1LblHigh = New Single(1) {}
        m_pv1LblLow = New Single(1) {}
        m_pv2LblHigh = New Single(1) {}
        m_pv2LblLow = New Single(1) {}
        m_dVals = New Single(2) {}              ' for SV, PV, MV
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If (m_bStart = True) Then
            Timer1.Enabled = False ' disable timer
            adamCom.CloseComPort() ' close the COM port
        End If
    End Sub

    Private Sub buttonStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonStart.Click
        Dim bRet As Boolean
        If (m_bStart = True) Then ' was started
            panelPID.Enabled = False
            m_bStart = False
            Timer1.Enabled = False
            adamCom.CloseComPort()
            buttonStart.Text = "Start"
        Else
            If (adamCom.OpenComPort() = True) Then
                ' set COM port state, 9600,N,8,1
                adamCom.SetComPortState(Baudrate.Baud_9600, Databits.Eight, Parity.None, Stopbits.One)
                ' set COM port timeout
                adamCom.SetComPortTimeout(500, 500, 0, 500, 0)
                m_iCount = 0 ' reset the reading counter
                '
                If (cbxLoop.SelectedIndex >= 0) Then
                    RefreshPIDValue()
                Else
                    ' PID
                    m_loopBase = PID_Loop.Loop0
                    If (m_AsciiProtocol) Then
                        bRet = (adamCom.Pid(m_iAddr).AsciiRefreshBuffer(PID_Loop.Loop0) And adamCom.Pid(m_iAddr).AsciiRefreshBuffer(PID_Loop.Loop1))
                    Else
                        bRet = (adamCom.Pid(m_iAddr).ModbusRefreshBuffer(PID_Loop.Loop0) And adamCom.Pid(m_iAddr).ModbusRefreshBuffer(PID_Loop.Loop1))
                    End If
                    If (bRet = True) Then
                        m_pv1LblHigh(0) = adamCom.Pid(m_iAddr).GetBufferFloat(PID_Loop.Loop0, PID_Addr.Sv1HighLimit)
                        m_pv1LblHigh(1) = adamCom.Pid(m_iAddr).GetBufferFloat(PID_Loop.Loop1, PID_Addr.Sv1HighLimit)
                        m_pv1LblLow(0) = adamCom.Pid(m_iAddr).GetBufferFloat(PID_Loop.Loop0, PID_Addr.Sv1LowLimit)
                        m_pv1LblLow(1) = adamCom.Pid(m_iAddr).GetBufferFloat(PID_Loop.Loop1, PID_Addr.Sv1LowLimit)
                        m_pv2LblHigh(0) = adamCom.Pid(m_iAddr).GetBufferFloat(PID_Loop.Loop0, PID_Addr.Sv2HighLimit)
                        m_pv2LblHigh(1) = adamCom.Pid(m_iAddr).GetBufferFloat(PID_Loop.Loop1, PID_Addr.Sv2HighLimit)
                        m_pv2LblLow(0) = adamCom.Pid(m_iAddr).GetBufferFloat(PID_Loop.Loop0, PID_Addr.Sv2LowLimit)
                        m_pv2LblLow(1) = adamCom.Pid(m_iAddr).GetBufferFloat(PID_Loop.Loop1, PID_Addr.Sv2LowLimit)
                        RefreshPIDStatic()
                    Else
                        MessageBox.Show("Failed to refresh data!", "Error")
                        adamCom.CloseComPort()
                        Return
                    End If
                End If
                '
                panelPID.Enabled = True
                Timer1.Enabled = True ' enable timer
                buttonStart.Text = "Stop"
                m_bStart = True ' starting flag
            Else
                MessageBox.Show("Failed to open COM port!", "Error")
            End If
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        m_iCount = m_iCount + 1
        txtReadCount.Text = "Polling " + m_iCount.ToString() + " times..."
        If (RefreshPIDValue() = True) Then
            txtReadCount.Text = "Polling " + m_iCount.ToString() + " times..."
        Else
            txtReadCount.Text = "Polling " + m_iCount.ToString() + " times... (Fail to read)"
        End If
    End Sub

    Private Function RefreshPIDValue() As Boolean
        Dim bRet As Boolean
        Dim iSVGraphPer As Integer, iPVGraphPer As Integer, iMVGraphPer As Integer
        Dim fVal As Single
        Dim iVal As Integer

        If (m_AsciiProtocol = True) Then
            bRet = adamCom.Pid(m_iAddr).AsciiRefreshBuffer(m_loopBase)
        Else
            bRet = adamCom.Pid(m_iAddr).ModbusRefreshBuffer(m_loopBase)
        End If
        If (bRet = True) Then
            ' check divider
            If ((m_pv1LblHigh(Convert.ToInt32(m_loopBase)) = m_pv1LblLow(Convert.ToInt32(m_loopBase))) Or (m_pv2LblHigh(Convert.ToInt32(m_loopBase)) = m_pv2LblLow(Convert.ToInt32(m_loopBase))) Or adamCom.Pid(m_iAddr).GetBufferInt(m_loopBase, PID_Addr.MvRangeHigh) = adamCom.Pid(m_iAddr).GetBufferInt(m_loopBase, PID_Addr.MvRangeLow)) Then
                Return False
            End If
            ' graph bound check
            If (adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.Pv1EngData) > m_pv1LblHigh(Convert.ToInt32(m_loopBase))) Then
                If (adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.Pv1EngData) + 1.0F < adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.Pv1RangeHigh)) Then
                    m_pv1LblHigh(Convert.ToInt32(m_loopBase)) = adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.Pv1EngData) + 1.0F
                Else
                    m_pv1LblHigh(Convert.ToInt32(m_loopBase)) = adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.Pv1RangeHigh)
                End If
                RefreshPIDStatic()
            ElseIf (adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.Pv1EngData) < m_pv1LblLow(Convert.ToInt32(m_loopBase))) Then
                If (adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.Pv1EngData) > adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.Pv1RangeLow) - 1.0F) Then
                    m_pv1LblLow(Convert.ToInt32(m_loopBase)) = adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.Pv1EngData) - 1000
                Else
                    m_pv1LblLow(Convert.ToInt32(m_loopBase)) = adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.Pv1RangeLow)
                End If
                RefreshPIDStatic()
            End If
            ' SV
            iSVGraphPer = Convert.ToInt32((adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.Sv1) - m_pv1LblLow(Convert.ToInt32(m_loopBase))) * 100.0F / (m_pv1LblHigh(Convert.ToInt32(m_loopBase)) - m_pv1LblLow(Convert.ToInt32(m_loopBase))))
            ' PV
            If (adamCom.Pid(m_iAddr).GetBufferInt(m_loopBase, PID_Addr.Pv1OpenWireFlag) = 0) Then
                fVal = adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.Pv1EngData)
                txtPV.Text = fVal.ToString("#0.000")
            Else
                txtPV.Text = "*****"
            End If
            iPVGraphPer = Convert.ToInt32((adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.Pv1EngData) - m_pv1LblLow(Convert.ToInt32(m_loopBase))) * 100.0F / (m_pv1LblHigh(Convert.ToInt32(m_loopBase)) - m_pv1LblLow(Convert.ToInt32(m_loopBase))))
            progressBarPV.Value = iPVGraphPer
            ' MV
            fVal = (adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.MvEngData) - adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.MvRangeLow)) * 100.0F / (adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.MvRangeHigh) - adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.MvRangeLow))
            iMVGraphPer = Convert.ToInt32(fVal)
            If (txtMV.Focused = False) Then
                txtMV.Text = fVal.ToString("#0.000")
            End If
            progressBarMV.Value = iMVGraphPer
            ' PV alarm
            iVal = adamCom.Pid(m_iAddr).GetBufferInt(m_loopBase, PID_Addr.Pv1AlarmStatus)
            adamLightPV.Value = (iVal <> 0)
            If (iVal = 0) Then
                txtPVAlarm.Text = "Normal"
            ElseIf (iVal = 1) Then
                txtPVAlarm.Text = "H-High alarm"
            ElseIf (iVal = 2) Then
                txtPVAlarm.Text = "High alarm"
            ElseIf (iVal = 3) Then
                txtPVAlarm.Text = "Low alarm"
            Else
                txtPVAlarm.Text = "L-Low alarm"
            End If
            ' MV alarm
            iVal = adamCom.Pid(m_iAddr).GetBufferInt(m_loopBase, PID_Addr.MvAlarmStatus)
            adamLightMV.Value = (iVal <> 0)
            If (iVal = 0) Then
                txtMVAlarm.Text = "Normal"
            ElseIf (iVal = 1) Then
                txtMVAlarm.Text = "High alarm"
            Else
                txtMVAlarm.Text = "Low alarm"
            End If
            m_dVals(0) = Convert.ToSingle(iSVGraphPer)
            m_dVals(1) = Convert.ToSingle(iPVGraphPer)
            m_dVals(2) = Convert.ToSingle(iMVGraphPer)
            AdamTrend1.UpdateGraph(m_dVals)
            Return True
        End If
        Return False
    End Function

    Private Function RefreshPIDStatic() As Boolean
        Dim fVal As Single

        If ((m_pv1LblHigh(Convert.ToInt32(m_loopBase)) = m_pv1LblLow(Convert.ToInt32(m_loopBase))) Or (m_pv2LblHigh(Convert.ToInt32(m_loopBase)) = m_pv2LblLow(Convert.ToInt32(m_loopBase)))) Then
            Return False
        End If
        cbxLoop.SelectedIndex = Convert.ToInt32(m_loopBase)
        cbxControl.SelectedIndex = adamCom.Pid(m_iAddr).GetBufferInt(m_loopBase, PID_Addr.ControlMode)
        ' MV text
        If (adamCom.Pid(m_iAddr).GetBufferInt(m_loopBase, PID_Addr.ControlMode) = 1) Then ' PID auto mode
            txtMV.ReadOnly = True
        Else
            txtMV.ReadOnly = False
        End If
        ' PV
        ' graph's high/low limit
        txtGraphHigh.Text = m_pv1LblHigh(Convert.ToInt32(m_loopBase)).ToString("#0.000")
        txtGraphLow.Text = m_pv1LblLow(Convert.ToInt32(m_loopBase)).ToString("#0.000")
        ' SV trackbar
        fVal = adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.Sv1)
        txtSV.Text = fVal.ToString("#0.000")
        trackBarSV.Value = Convert.ToInt32(((adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.Sv1) - m_pv1LblLow(Convert.ToInt32(m_loopBase))) * trackBarSV.Maximum) / (m_pv1LblHigh(Convert.ToInt32(m_loopBase)) - m_pv1LblLow(Convert.ToInt32(m_loopBase))))
        trackSVValue = trackBarSV.Value
        lblSVHigh.Text = txtGraphHigh.Text
        lblSVLow.Text = txtGraphLow.Text
        Return True
    End Function

    Private Sub cbxLoop_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxLoop.SelectedIndexChanged
        Timer1.Enabled = False
        m_loopBase = cbxLoop.SelectedIndex
        adamTrend1.ClearGraph()
        If (RefreshPIDStatic() = False) Then
            MessageBox.Show("Hi-Lo range Setting is invalid!", "Error")
        End If
        Timer1.Enabled = True
    End Sub

    Private Sub cbxControl_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxControl.SelectedIndexChanged
        Dim bRet As Boolean
        Dim iControl As Integer

        Timer1.Enabled = False
        iControl = cbxControl.SelectedIndex
        If (m_AsciiProtocol = True) Then
            bRet = adamCom.Pid(m_iAddr).AsciiSetValue(m_loopBase, PID_Addr.ControlMode, iControl)
        Else
            bRet = adamCom.Pid(m_iAddr).ModbusSetValue(m_loopBase, PID_Addr.ControlMode, iControl)
        End If
        If (bRet = True) Then
            adamCom.Pid(m_iAddr).SetBufferInt(m_loopBase, PID_Addr.ControlMode, iControl)
        Else
            MessageBox.Show("Failed to change data!", "Error")
        End If
        If (RefreshPIDStatic() = False) Then
            MessageBox.Show("Hi-Lo range Setting is invalid!", "Error")
        End If
        Timer1.Enabled = True
    End Sub

    Private Sub trackBarSV_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trackBarSV.ValueChanged
        Dim bRet As Boolean
        Dim svLarge As Single, fHigh As Single, fLow As Single
        Dim szMsg As String

        If (trackSVValue = trackBarSV.Value) Then
            Return
        End If

        Timer1.Enabled = False
        svLarge = m_pv1LblLow(Convert.ToInt32(m_loopBase)) + (m_pv1LblHigh(Convert.ToInt32(m_loopBase)) - m_pv1LblLow(Convert.ToInt32(m_loopBase))) * trackBarSV.Value / 20.0F
        fHigh = adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.Sv1HighLimit)
        fLow = adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.Sv1LowLimit)
        If (svLarge >= fLow And svLarge <= fHigh) Then
            If (m_AsciiProtocol) Then
                bRet = adamCom.Pid(m_iAddr).AsciiSetValue(m_loopBase, PID_Addr.Sv1, svLarge)
            Else
                bRet = adamCom.Pid(m_iAddr).ModbusSetValue(m_loopBase, PID_Addr.Sv1, svLarge)
            End If
            If (bRet) Then
                adamCom.Pid(m_iAddr).SetBufferFloat(m_loopBase, PID_Addr.Sv1, svLarge)
            Else
                MessageBox.Show("Failed to set data!", "Error")
            End If
        Else
            trackBarSV.Value = trackSVValue
            szMsg = " (MUST: " + fLow.ToString() + " <= value <= " + fHigh.ToString() + ")"
            MessageBox.Show("SV value is out of range!" + szMsg, "Error")
        End If
        If (RefreshPIDStatic() = False) Then
            MessageBox.Show("Hi-Lo range Setting is invalid!", "Error")
        End If
        Timer1.Enabled = True
    End Sub

    Private Sub txtSV_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSV.KeyPress
        Dim bRet As Boolean
        Dim svLarge As Single, fHigh As Single, fLow As Single
        Dim szMsg As String

        If ((e.KeyChar.CompareTo("0"c) >= 0) And (e.KeyChar.CompareTo("9"c) <= 0)) Then
            e.Handled = False
        ElseIf ((e.KeyChar = Convert.ToChar(8)) Or (e.KeyChar.CompareTo("."c) = 0) Or (e.KeyChar.CompareTo("+"c) = 0) Or (e.KeyChar.CompareTo("-"c) = 0)) Then
            e.Handled = False
        ElseIf (e.KeyChar = Convert.ToChar(13)) Then
            If (txtSV.Text.Length > 0) Then
                Timer1.Enabled = False
                svLarge = Convert.ToSingle(txtSV.Text)
                If (svLarge <> adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.Sv1)) Then
                    fHigh = adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.Sv1HighLimit)
                    fLow = adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.Sv1LowLimit)
                    If (svLarge >= fLow And svLarge <= fHigh) Then
                        If (m_AsciiProtocol = True) Then
                            bRet = adamCom.Pid(m_iAddr).AsciiSetValue(m_loopBase, PID_Addr.Sv1, svLarge)
                        Else
                            bRet = adamCom.Pid(m_iAddr).ModbusSetValue(m_loopBase, PID_Addr.Sv1, svLarge)
                        End If
                        If (bRet = True) Then
                            adamCom.Pid(m_iAddr).SetBufferFloat(m_loopBase, PID_Addr.Sv1, svLarge)
                        Else
                            MessageBox.Show("Failed to set data!", "Error")
                        End If
                    Else
                        szMsg = " (MUST: " + fLow.ToString() + " <= value <= " + fHigh.ToString() + ")"
                        MessageBox.Show("SV value is out of range!" + szMsg, "Error")
                    End If
                End If
                If (RefreshPIDStatic() = False) Then
                    MessageBox.Show("Hi-Lo range Setting is invalid!", "Error")
                End If
                Timer1.Enabled = True
            End If
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtMV_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMV.KeyPress
        Dim bRet As Boolean
        Dim MVLarge As Single, MVValue As Single, fHigh As Single, fLow As Single
        Dim szMsg As String

        If ((e.KeyChar.CompareTo("0"c) >= 0) And (e.KeyChar.CompareTo("9"c) <= 0)) Then
            e.Handled = False
        ElseIf ((e.KeyChar = Convert.ToChar(8)) Or (e.KeyChar.CompareTo("."c) = 0) Or (e.KeyChar.CompareTo("+"c) = 0) Or (e.KeyChar.CompareTo("-"c) = 0)) Then
            e.Handled = False
        ElseIf (e.KeyChar = Convert.ToChar(13)) Then
            If (txtMV.Text.Length > 0) Then
                Timer1.Enabled = False
                MVLarge = Convert.ToSingle(txtMV.Text)
                If (MVLarge >= 0.0F And MVLarge <= 100.0F) Then
                    MVValue = adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.MvRangeLow) + (adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.MvRangeHigh) - adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.MvRangeLow)) * MVLarge / 100.0F
                    If (MVValue <> adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.MvEngData)) Then
                        fHigh = adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.MvHighLimit)
                        fLow = adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.MvLowLimit)
                        If (MVValue >= fLow And MVValue <= fHigh) Then
                            If (m_AsciiProtocol = True) Then
                                bRet = adamCom.Pid(m_iAddr).AsciiSetValue(m_loopBase, PID_Addr.MvEngData, MVValue)
                            Else
                                bRet = adamCom.Pid(m_iAddr).ModbusSetValue(m_loopBase, PID_Addr.MvEngData, MVValue)
                            End If
                            If (bRet = True) Then
                                adamCom.Pid(m_iAddr).SetBufferFloat(m_loopBase, PID_Addr.MvEngData, MVValue)
                                txtSV.Focus()
                            Else
                                MessageBox.Show("Failed to set data!", "Error")
                            End If
                        Else
                            szMsg = " (MUST: " + fLow.ToString() + " <= value <= " + fHigh.ToString() + ")"
                            MessageBox.Show("MV value is out of limit!" + szMsg, "Error")
                        End If
                    End If
                Else
                    MessageBox.Show("MV value is out of range! (0.0~100.0)", "Error")
                End If
                Timer1.Enabled = True
            End If
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtGraphHigh_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGraphHigh.KeyPress
        Dim fGraphHigh As Single, fHigh As Single, fLow As Single, fLimit As Single
        Dim szMsg As String

        If ((e.KeyChar.CompareTo("0"c) >= 0) And (e.KeyChar.CompareTo("9"c) <= 0)) Then
            e.Handled = False
        ElseIf ((e.KeyChar = Convert.ToChar(8)) Or (e.KeyChar.CompareTo("."c) = 0) Or (e.KeyChar.CompareTo("+"c) = 0) Or (e.KeyChar.CompareTo("-"c) = 0)) Then
            e.Handled = False
        ElseIf (e.KeyChar = Convert.ToChar(13)) Then
            If (txtGraphHigh.Text.Length > 0) Then
                Timer1.Enabled = False
                fGraphHigh = Convert.ToSingle(txtGraphHigh.Text)
                If (fGraphHigh <> m_pv1LblHigh(Convert.ToInt32(m_loopBase))) Then
                    fHigh = adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.Pv1RangeHigh)
                    fLow = adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.Pv1EngData)
                    fLimit = adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.Sv1)
                    If (fGraphHigh <= fHigh And fGraphHigh >= fLimit And fGraphHigh >= fLow) Then
                        m_pv1LblHigh(Convert.ToInt32(m_loopBase)) = fGraphHigh
                    Else
                        If (fLimit >= fLow) Then
                            szMsg = " (MUST: " + fLimit.ToString() + " <= value < " + fHigh.ToString() + ")"
                        Else
                            szMsg = " (MUST: " + fLow.ToString() + " <= value <= " + fHigh.ToString() + ")"
                        End If
                        MessageBox.Show("Value is out of range!" + szMsg, "Error")
                    End If
                End If
                If (RefreshPIDStatic() = False) Then
                    MessageBox.Show("Hi-Lo range Setting is invalid!", "Error")
                End If
                Timer1.Enabled = True
            End If
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtGraphLow_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGraphLow.KeyPress
        Dim fGraphLow As Single, fHigh As Single, fLow As Single, fLimit As Single
        Dim szMsg As String

        If ((e.KeyChar.CompareTo("0"c) >= 0) And (e.KeyChar.CompareTo("9"c) <= 0)) Then
            e.Handled = False
        ElseIf ((e.KeyChar = Convert.ToChar(8)) Or (e.KeyChar.CompareTo("."c) = 0) Or (e.KeyChar.CompareTo("+"c) = 0) Or (e.KeyChar.CompareTo("-"c) = 0)) Then
            e.Handled = False
        ElseIf (e.KeyChar = Convert.ToChar(13)) Then
            If (txtGraphLow.Text.Length > 0) Then
                Timer1.Enabled = False
                fGraphLow = Convert.ToSingle(txtGraphLow.Text)
                If (fGraphLow <> m_pv1LblLow(Convert.ToInt32(m_loopBase))) Then
                    fHigh = adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.Pv1EngData)
                    fLow = adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.Pv1RangeLow)
                    fLimit = adamCom.Pid(m_iAddr).GetBufferFloat(m_loopBase, PID_Addr.Sv1)
                    If (fGraphLow >= fLow And fGraphLow <= fLimit And fGraphLow <= fHigh) Then
                        m_pv1LblLow(Convert.ToInt32(m_loopBase)) = fGraphLow
                    Else
                        If (fLimit >= fHigh) Then
                            szMsg = " (MUST: " + fLow.ToString() + " <= value < " + fHigh.ToString() + ")"
                        Else
                            szMsg = " (MUST: " + fLow.ToString() + " <= value <= " + fLimit.ToString() + ")"
                        End If
                        MessageBox.Show("Value is out of range!" + szMsg, "Error")
                    End If
                End If
                If (RefreshPIDStatic() = False) Then
                    MessageBox.Show("Hi-Lo range Setting is invalid!", "Error")
                End If
                Timer1.Enabled = True
            End If
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtGraphLow_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGraphLow.Leave
        RefreshPIDStatic()
    End Sub

    Private Sub txtGraphHigh_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGraphHigh.Leave
        RefreshPIDStatic()
    End Sub

    Private Sub txtSV_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSV.Leave
        RefreshPIDStatic()
    End Sub

    Private Sub txtMV_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMV.Leave
        RefreshPIDStatic()
    End Sub
End Class
