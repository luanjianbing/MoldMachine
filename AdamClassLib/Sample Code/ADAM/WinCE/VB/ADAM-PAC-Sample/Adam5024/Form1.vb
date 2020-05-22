Imports Advantech.Adam
Imports Advantech.Common

Public Class Form1
    Inherits System.Windows.Forms.Form
    Friend WithEvents panelAO As System.Windows.Forms.Panel
    Friend WithEvents cbxChannel As System.Windows.Forms.ComboBox
    Friend WithEvents label11 As System.Windows.Forms.Label
    Friend WithEvents trackBar1 As System.Windows.Forms.TrackBar
    Friend WithEvents lblHigh As System.Windows.Forms.Label
    Friend WithEvents lblLow As System.Windows.Forms.Label
    Friend WithEvents btnApplyOutput As System.Windows.Forms.Button
    Friend WithEvents txtOutputValue As System.Windows.Forms.TextBox
    Friend WithEvents label13 As System.Windows.Forms.Label
    Friend WithEvents txtAO3 As System.Windows.Forms.TextBox
    Friend WithEvents label4 As System.Windows.Forms.Label
    Friend WithEvents txtAO2 As System.Windows.Forms.TextBox
    Friend WithEvents label3 As System.Windows.Forms.Label
    Friend WithEvents txtAO1 As System.Windows.Forms.TextBox
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents txtAO0 As System.Windows.Forms.TextBox
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents txtModule As System.Windows.Forms.TextBox
    Friend WithEvents label7 As System.Windows.Forms.Label
    Friend WithEvents txtReadCount As System.Windows.Forms.TextBox
    Friend WithEvents label6 As System.Windows.Forms.Label
    Friend WithEvents buttonStart As System.Windows.Forms.Button

    Private m_iSlot As Integer, m_iCount As Integer, m_iChTotal As Integer
    Private m_bStart As Boolean
    Private m_byRange() As Byte
    Private m_Adam5000Type As Adam5000Type
    Private adamCtl As AdamControl

#Region " Windows Form Designer generated code "

    Public Sub New()

        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Private Sub InitializeComponent()
        Me.panelAO = New System.Windows.Forms.Panel
        Me.cbxChannel = New System.Windows.Forms.ComboBox
        Me.label11 = New System.Windows.Forms.Label
        Me.trackBar1 = New System.Windows.Forms.TrackBar
        Me.lblHigh = New System.Windows.Forms.Label
        Me.lblLow = New System.Windows.Forms.Label
        Me.btnApplyOutput = New System.Windows.Forms.Button
        Me.txtOutputValue = New System.Windows.Forms.TextBox
        Me.label13 = New System.Windows.Forms.Label
        Me.txtAO3 = New System.Windows.Forms.TextBox
        Me.label4 = New System.Windows.Forms.Label
        Me.txtAO2 = New System.Windows.Forms.TextBox
        Me.label3 = New System.Windows.Forms.Label
        Me.txtAO1 = New System.Windows.Forms.TextBox
        Me.label1 = New System.Windows.Forms.Label
        Me.txtAO0 = New System.Windows.Forms.TextBox
        Me.label2 = New System.Windows.Forms.Label
        Me.txtModule = New System.Windows.Forms.TextBox
        Me.label7 = New System.Windows.Forms.Label
        Me.txtReadCount = New System.Windows.Forms.TextBox
        Me.label6 = New System.Windows.Forms.Label
        Me.buttonStart = New System.Windows.Forms.Button
        Me.Timer1 = New System.Windows.Forms.Timer
        '
        'panelAO
        '
        Me.panelAO.BackColor = System.Drawing.Color.SkyBlue
        Me.panelAO.Controls.Add(Me.cbxChannel)
        Me.panelAO.Controls.Add(Me.label11)
        Me.panelAO.Controls.Add(Me.trackBar1)
        Me.panelAO.Controls.Add(Me.lblHigh)
        Me.panelAO.Controls.Add(Me.lblLow)
        Me.panelAO.Controls.Add(Me.btnApplyOutput)
        Me.panelAO.Controls.Add(Me.txtOutputValue)
        Me.panelAO.Controls.Add(Me.label13)
        Me.panelAO.Enabled = False
        Me.panelAO.Location = New System.Drawing.Point(16, 216)
        Me.panelAO.Size = New System.Drawing.Size(424, 168)
        '
        'cbxChannel
        '
        Me.cbxChannel.Location = New System.Drawing.Point(128, 16)
        Me.cbxChannel.Size = New System.Drawing.Size(112, 20)
        '
        'label11
        '
        Me.label11.Location = New System.Drawing.Point(16, 16)
        Me.label11.Size = New System.Drawing.Size(104, 24)
        Me.label11.Text = "Channel index:"
        '
        'trackBar1
        '
        Me.trackBar1.LargeChange = 16
        Me.trackBar1.Location = New System.Drawing.Point(24, 56)
        Me.trackBar1.Maximum = 4095
        Me.trackBar1.Size = New System.Drawing.Size(240, 45)
        Me.trackBar1.TickFrequency = 256
        '
        'lblHigh
        '
        Me.lblHigh.Location = New System.Drawing.Point(224, 104)
        Me.lblHigh.Size = New System.Drawing.Size(56, 24)
        Me.lblHigh.Text = "10 V"
        Me.lblHigh.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblLow
        '
        Me.lblLow.Location = New System.Drawing.Point(8, 104)
        Me.lblLow.Size = New System.Drawing.Size(56, 24)
        Me.lblLow.Text = "0 V"
        Me.lblLow.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnApplyOutput
        '
        Me.btnApplyOutput.Location = New System.Drawing.Point(288, 120)
        Me.btnApplyOutput.Size = New System.Drawing.Size(128, 32)
        Me.btnApplyOutput.Text = "Apply output"
        '
        'txtOutputValue
        '
        Me.txtOutputValue.Location = New System.Drawing.Point(288, 88)
        Me.txtOutputValue.ReadOnly = True
        Me.txtOutputValue.Size = New System.Drawing.Size(88, 22)
        Me.txtOutputValue.Text = "0"
        '
        'label13
        '
        Me.label13.Location = New System.Drawing.Point(288, 56)
        Me.label13.Size = New System.Drawing.Size(104, 24)
        Me.label13.Text = "Value to output:"
        '
        'txtAO3
        '
        Me.txtAO3.Location = New System.Drawing.Point(168, 176)
        Me.txtAO3.Size = New System.Drawing.Size(176, 22)
        Me.txtAO3.Text = ""
        '
        'label4
        '
        Me.label4.Location = New System.Drawing.Point(16, 176)
        Me.label4.Size = New System.Drawing.Size(136, 20)
        Me.label4.Text = "AO-3 value:"
        '
        'txtAO2
        '
        Me.txtAO2.Location = New System.Drawing.Point(168, 144)
        Me.txtAO2.Size = New System.Drawing.Size(176, 22)
        Me.txtAO2.Text = ""
        '
        'label3
        '
        Me.label3.Location = New System.Drawing.Point(16, 144)
        Me.label3.Size = New System.Drawing.Size(136, 20)
        Me.label3.Text = "AO-2 value:"
        '
        'txtAO1
        '
        Me.txtAO1.Location = New System.Drawing.Point(168, 112)
        Me.txtAO1.Size = New System.Drawing.Size(176, 22)
        Me.txtAO1.Text = ""
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(16, 112)
        Me.label1.Size = New System.Drawing.Size(136, 20)
        Me.label1.Text = "AO-1 value:"
        '
        'txtAO0
        '
        Me.txtAO0.Location = New System.Drawing.Point(168, 80)
        Me.txtAO0.Size = New System.Drawing.Size(176, 22)
        Me.txtAO0.Text = ""
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(16, 80)
        Me.label2.Size = New System.Drawing.Size(136, 20)
        Me.label2.Text = "AO-0 value:"
        '
        'txtModule
        '
        Me.txtModule.Location = New System.Drawing.Point(168, 16)
        Me.txtModule.Size = New System.Drawing.Size(176, 22)
        Me.txtModule.Text = ""
        '
        'label7
        '
        Me.label7.Location = New System.Drawing.Point(16, 16)
        Me.label7.Size = New System.Drawing.Size(136, 20)
        Me.label7.Text = "Module name:"
        '
        'txtReadCount
        '
        Me.txtReadCount.Location = New System.Drawing.Point(168, 48)
        Me.txtReadCount.Size = New System.Drawing.Size(176, 22)
        Me.txtReadCount.Text = "0"
        '
        'label6
        '
        Me.label6.Location = New System.Drawing.Point(16, 48)
        Me.label6.Size = New System.Drawing.Size(136, 20)
        Me.label6.Text = "Read count:"
        '
        'buttonStart
        '
        Me.buttonStart.Location = New System.Drawing.Point(368, 16)
        Me.buttonStart.Size = New System.Drawing.Size(72, 24)
        Me.buttonStart.Text = "Start"
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(458, 392)
        Me.Controls.Add(Me.panelAO)
        Me.Controls.Add(Me.txtAO3)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.txtAO2)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.txtAO1)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.txtAO0)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(Me.txtModule)
        Me.Controls.Add(Me.label7)
        Me.Controls.Add(Me.txtReadCount)
        Me.Controls.Add(Me.label6)
        Me.Controls.Add(Me.buttonStart)
        Me.Text = "Adam5024 sample program (VB)"

    End Sub

    Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim iIdx As Integer

        m_iSlot = 2 ' the slot index of the module
        m_iCount = 0 ' the counting start from 0
        m_bStart = False
        m_Adam5000Type = Adam5000Type.Adam5024 ' the sample is for ADAM-5024
        adamCtl = New AdamControl

        m_iChTotal = AnalogOutput.GetChannelTotal(m_Adam5000Type)
        m_byRange = New Byte(m_iChTotal - 1) {} ' 0~(m_iChTotal-1)
        For iIdx = 0 To (m_iChTotal - 1)
            cbxChannel.Items.Add(iIdx.ToString())
        Next iIdx
        txtModule.Text = m_Adam5000Type.ToString()
    End Sub

    Private Sub Form1_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If m_bStart = True Then
            Timer1.Enabled = False ' disable timer

            adamCtl.CloseDevice()
        End If
    End Sub

    Private Sub buttonStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonStart.Click
        If m_bStart = True Then ' was started
            m_bStart = False
            Timer1.Enabled = False

            adamCtl.CloseDevice()

            buttonStart.Text = "Start"
        Else
            If adamCtl.OpenDevice() = True Then

                m_iCount = 0 ' reset the reading counter
                If RefreshChannelRange() = True Then
                    cbxChannel.SelectedIndex = 0
                    panelAO.Enabled = True
                    Timer1.Enabled = True ' enable timer
                    buttonStart.Text = "Stop"
                    m_bStart = True ' starting flag
                Else
                    adamCtl.CloseDevice()
                End If
            Else
                MessageBox.Show("Failed to open COM port!", "Error")
            End If
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        m_iCount = m_iCount + 1
        txtReadCount.Text = "Polling " + m_iCount.ToString() + " times..."
        RefreshChannelValue(0, txtAO0)
        RefreshChannelValue(1, txtAO1)
        RefreshChannelValue(2, txtAO2)
        RefreshChannelValue(3, txtAO3)
    End Sub

    Private Function RefreshRange(ByVal i_iChannel As Integer) As Boolean
        Dim byRange As Byte
        Dim bRet As Boolean

        bRet = adamCtl.AnalogOutput().GetOutputRange(m_iSlot, i_iChannel, byRange)

        If bRet = True Then
            m_byRange(i_iChannel) = byRange
        End If
        Return bRet
    End Function

    Private Function RefreshChannelRange() As Boolean
        Dim bRet As Boolean
        Dim iIdx As Integer

        bRet = True
        For iIdx = 0 To (m_iChTotal - 1)
            bRet = RefreshRange(iIdx)
            If bRet = False Then
                MessageBox.Show("Get range failed", "Error")
                Exit For
            End If
        Next iIdx
        Return bRet
    End Function

    Private Sub RefreshChannelValue(ByVal i_iChannel As Integer, ByVal i_txtCh As TextBox)
        Dim iStart As Integer
        Dim fValue As Single
        Dim szFormat As String

        iStart = m_iSlot * 8 + i_iChannel + 1

        If adamCtl.AnalogOutput().GetCurrentValue(m_iSlot, i_iChannel, fValue) = True Then
            szFormat = AnalogOutput.GetFloatFormat(m_Adam5000Type, m_byRange(i_iChannel))
            i_txtCh.Text = fValue.ToString(szFormat) + " " + AnalogOutput.GetUnitName(m_Adam5000Type, m_byRange(i_iChannel))
        Else
            i_txtCh.Text = "Failed to get"
        End If

    End Sub

    Private Sub cbxChannel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxChannel.SelectedIndexChanged
        Dim iCh As Integer
        Dim fValue As Single
        Dim byRange As Byte

        Timer1.Enabled = False
        iCh = cbxChannel.SelectedIndex
        fValue = Convert.ToSingle(trackBar1.Value)
        byRange = m_byRange(iCh)
        If byRange = Convert.ToByte(Adam5024_OutputRange.mA_0To20) Then ' 0~20mA
            lblLow.Text = "0 mA"
            lblHigh.Text = "20 mA"
            fValue = fValue * 20 / trackBar1.Maximum
        ElseIf (byRange = Convert.ToByte(Adam5024_OutputRange.mA_4To20)) Then ' 4~20mA
            lblLow.Text = "4 mA"
            lblHigh.Text = "20 mA"
            fValue = 4.0F + fValue * 16 / trackBar1.Maximum
        Else ' 0~10V
            lblLow.Text = "0 V"
            lblHigh.Text = "10 V"
            fValue = fValue * 10 / trackBar1.Maximum
        End If
        txtOutputValue.Text = fValue.ToString("#0.000")
        Timer1.Enabled = True
    End Sub

    Private Sub trackBar1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trackBar1.ValueChanged
        Dim iCh As Integer
        Dim fValue As Single
        Dim byRange As Byte

        Timer1.Enabled = False
        iCh = cbxChannel.SelectedIndex
        fValue = Convert.ToSingle(trackBar1.Value)
        byRange = m_byRange(iCh)
        If byRange = Convert.ToByte(Adam5024_OutputRange.mA_0To20) Then ' 0~20mA
            fValue = fValue * 20 / trackBar1.Maximum
        ElseIf byRange = Convert.ToByte(Adam5024_OutputRange.mA_4To20) Then ' 4~20mA
            fValue = 4.0F + fValue * 16 / trackBar1.Maximum
        Else ' 0~10V
            fValue = fValue * 10 / trackBar1.Maximum
        End If
        txtOutputValue.Text = fValue.ToString("#0.000")
        Timer1.Enabled = True
    End Sub

    Private Sub btnApplyOutput_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApplyOutput.Click
        Dim bRet As Boolean
        Dim iChannel As Integer
        Dim fValue As Single

        Timer1.Enabled = False
        iChannel = cbxChannel.SelectedIndex
        fValue = Convert.ToSingle(txtOutputValue.Text)

        bRet = adamCtl.AnalogOutput().SetCurrentValue(m_iSlot, iChannel, fValue)

        If bRet = True Then
            System.Threading.Thread.Sleep(500)
        Else
            MessageBox.Show("Change current value failed!", "Error")
        End If
        Timer1.Enabled = True
    End Sub
End Class
