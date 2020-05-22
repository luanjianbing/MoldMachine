Imports System.Collections
Imports Advantech.Adam
Imports Advantech.Common

Public Class Form1
    Private m_iCom As Integer, m_iAddr As Integer, m_iCount As Integer, m_iChTotal As Integer
    Private m_bStart As Boolean
    Private m_bCh() As Boolean
    Private m_adamConfig As Adam4000Config
    Private m_Adam4000Type As Adam4000Type
    Private adamCom As AdamCom

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        m_iCom = 2                              ' using COM2
        m_iAddr = 1                             ' the slave address is 1
        m_iCount = 0                            ' the counting start from 0
        m_bStart = False
        m_Adam4000Type = Adam4000Type.Adam4018M ' the sample is for ADAM-4018M

        m_iChTotal = AnalogInput.GetChannelTotal(m_Adam4000Type)
        m_bCh = New Boolean(m_iChTotal) {}
        adamCom = New AdamCom(m_iCom)
        adamCom.Checksum = False                ' disbale checksum

        txtModule.Text = m_Adam4000Type.ToString()
    End Sub

    Private Sub Form1_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If (m_bStart = True) Then
            Timer1.Enabled = False ' disable timer
            adamCom.CloseComPort() ' close the COM port
        End If
    End Sub

    Private Sub buttonStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonStart.Click
        If (m_bStart = True) Then ' was started
            tabControl1.Enabled = False
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
                ' get module config
                If (adamCom.Configuration(m_iAddr).GetModuleConfig(m_adamConfig) = False) Then
                    adamCom.CloseComPort()
                    MessageBox.Show("Failed to get module config!", "Error")
                    Return
                End If
                ''''''
                RefreshChannelEnable()
                ''''''
                tabControl1.Enabled = True
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
        If (tabControl1.SelectedIndex = 0) Then ' data page
            RefreshAIValues()
        Else ' memory page
            RefreshMemInfo()
        End If
    End Sub

    Private Sub RefreshChannelEnable()
        Dim bEnabled() As Boolean
        Dim idx As Integer

        If (adamCom.AnalogInput(m_iAddr).GetChannelEnabled(m_iChTotal, bEnabled) = True) Then
            For idx = 0 To m_iChTotal - 1
                m_bCh(idx) = bEnabled(idx)
            Next idx
            chkboxCh0.Checked = bEnabled(0)
            chkboxCh1.Checked = bEnabled(1)
            chkboxCh2.Checked = bEnabled(2)
            chkboxCh3.Checked = bEnabled(3)
            chkboxCh4.Checked = bEnabled(4)
            chkboxCh5.Checked = bEnabled(5)
            chkboxCh6.Checked = bEnabled(6)
            chkboxCh7.Checked = bEnabled(7)
        Else
            MessageBox.Show("GetChannelEnabled() failed", "Error")
        End If
    End Sub

    Private Sub RefreshAIValues()
        If (RefreshValue(0, txtAIValue0) = False) Then
            Return
        End If
        If (RefreshValue(1, txtAIValue1) = False) Then
            Return
        End If
        If (RefreshValue(2, txtAIValue2) = False) Then
            Return
        End If
        If (RefreshValue(3, txtAIValue3) = False) Then
            Return
        End If
        If (RefreshValue(4, txtAIValue4) = False) Then
            Return
        End If
        If (RefreshValue(5, txtAIValue5) = False) Then
            Return
        End If
        If (RefreshValue(6, txtAIValue6) = False) Then
            Return
        End If
        If (RefreshValue(7, txtAIValue7) = False) Then
            Return
        End If
    End Sub

    Private Function RefreshValue(ByVal i_iCh As Integer, ByRef i_txtCh As TextBox) As Boolean
        Dim fVal As Single
        Dim status As Adam4000_ChannelStatus

        If (m_bCh(i_iCh) = False) Then ' channel disabled
            i_txtCh.Text = ""
            Return True
        End If
        If (adamCom.AnalogInput(m_iAddr).GetValue(i_iCh, fVal, status) = True) Then
            If (status = Adam4000_ChannelStatus.Normal) Then
                i_txtCh.Text = fVal.ToString(AnalogInput.GetFloatFormat(m_Adam4000Type, m_adamConfig.TypeCode)) + " " + AnalogInput.GetUnitName(m_Adam4000Type, m_adamConfig.TypeCode)
            Else
                i_txtCh.Text = fVal.ToString()
            End If
            Return True
        End If
        Return False
    End Function

    Private Sub RefreshMemInfo()
        Dim bRecording As Boolean
        Dim iStdCount As Integer, iEvtCount As Integer
        If ((adamCom.AnalogInput(m_iAddr).GetMemOperation(bRecording) = True) And (adamCom.AnalogInput(m_iAddr).GetMemStandardRecordCount(iStdCount) = True) And adamCom.AnalogInput(m_iAddr).GetMemEventRecordCount(iEvtCount) = True) Then
            txtRecord.Text = bRecording.ToString()
            txtMemStandardCount.Text = iStdCount.ToString()
            txtMemEventCount.Text = iEvtCount.ToString()
        Else
            txtRecord.Text = "Fail"
            txtMemStandardCount.Text = "Fail"
            txtMemEventCount.Text = "Fail"
        End If
    End Sub

    Private Sub btnStartMem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStartMem.Click
        Timer1.Enabled = False
        If (adamCom.AnalogInput(m_iAddr).SetMemOperation(True) = True) Then
            System.Threading.Thread.Sleep(500)
        Else
            MessageBox.Show("Start recording failed!", "Error")
        End If
        Timer1.Enabled = True
    End Sub

    Private Sub btnStopMem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStopMem.Click
        Timer1.Enabled = False
        If (adamCom.AnalogInput(m_iAddr).SetMemOperation(False) = True) Then
            System.Threading.Thread.Sleep(500)
        Else
            MessageBox.Show("Stop recording failed!", "Error")
        End If
        Timer1.Enabled = True
    End Sub

    Private Sub btnGetMem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetMem.Click
        Dim memRec As New FormMemoryRecord
        Dim szTitle As String = "ADAM-4018M memory records"

        memRec.FormMemoryRecord_Initial(adamCom, listView1, m_iAddr, szTitle, Width, Height)
        Timer1.Enabled = False
        'memRec = New FormMemoryRecord(adamCom, listView1, m_iAddr, szTitle, Width, Height)
        memRec.ShowDialog()
        memRec = Nothing
        Timer1.Enabled = True
    End Sub
End Class
