Imports Advantech.Adam
Imports Advantech.Common

Public Class Form1
    Inherits System.Windows.Forms.Form
    Friend WithEvents chkboxCh7 As System.Windows.Forms.CheckBox
    Friend WithEvents chkboxCh6 As System.Windows.Forms.CheckBox
    Friend WithEvents chkboxCh5 As System.Windows.Forms.CheckBox
    Friend WithEvents chkboxCh4 As System.Windows.Forms.CheckBox
    Friend WithEvents chkboxCh3 As System.Windows.Forms.CheckBox
    Friend WithEvents chkboxCh2 As System.Windows.Forms.CheckBox
    Friend WithEvents chkboxCh1 As System.Windows.Forms.CheckBox
    Friend WithEvents chkboxCh0 As System.Windows.Forms.CheckBox
    Friend WithEvents txtAIValue7 As System.Windows.Forms.TextBox
    Friend WithEvents txtAIValue6 As System.Windows.Forms.TextBox
    Friend WithEvents txtAIValue5 As System.Windows.Forms.TextBox
    Friend WithEvents txtAIValue4 As System.Windows.Forms.TextBox
    Friend WithEvents txtAIValue3 As System.Windows.Forms.TextBox
    Friend WithEvents txtAIValue2 As System.Windows.Forms.TextBox
    Friend WithEvents txtAIValue1 As System.Windows.Forms.TextBox
    Friend WithEvents txtAIValue0 As System.Windows.Forms.TextBox
    Friend WithEvents txtModule As System.Windows.Forms.TextBox
    Friend WithEvents label7 As System.Windows.Forms.Label
    Friend WithEvents txtReadCount As System.Windows.Forms.TextBox
    Friend WithEvents label6 As System.Windows.Forms.Label
    Friend WithEvents buttonStart As System.Windows.Forms.Button

    Private m_iSlot As Integer, m_iCount As Integer, m_iChTotal As Integer
    Private m_bStart As Boolean
    Private m_byRange As Byte
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
        Me.chkboxCh7 = New System.Windows.Forms.CheckBox
        Me.chkboxCh6 = New System.Windows.Forms.CheckBox
        Me.chkboxCh5 = New System.Windows.Forms.CheckBox
        Me.chkboxCh4 = New System.Windows.Forms.CheckBox
        Me.chkboxCh3 = New System.Windows.Forms.CheckBox
        Me.chkboxCh2 = New System.Windows.Forms.CheckBox
        Me.chkboxCh1 = New System.Windows.Forms.CheckBox
        Me.chkboxCh0 = New System.Windows.Forms.CheckBox
        Me.txtAIValue7 = New System.Windows.Forms.TextBox
        Me.txtAIValue6 = New System.Windows.Forms.TextBox
        Me.txtAIValue5 = New System.Windows.Forms.TextBox
        Me.txtAIValue4 = New System.Windows.Forms.TextBox
        Me.txtAIValue3 = New System.Windows.Forms.TextBox
        Me.txtAIValue2 = New System.Windows.Forms.TextBox
        Me.txtAIValue1 = New System.Windows.Forms.TextBox
        Me.txtAIValue0 = New System.Windows.Forms.TextBox
        Me.txtModule = New System.Windows.Forms.TextBox
        Me.label7 = New System.Windows.Forms.Label
        Me.txtReadCount = New System.Windows.Forms.TextBox
        Me.label6 = New System.Windows.Forms.Label
        Me.buttonStart = New System.Windows.Forms.Button
        Me.Timer1 = New System.Windows.Forms.Timer
        '
        'chkboxCh7
        '
        Me.chkboxCh7.Enabled = False
        Me.chkboxCh7.Location = New System.Drawing.Point(16, 320)
        Me.chkboxCh7.Size = New System.Drawing.Size(136, 20)
        Me.chkboxCh7.Text = "AI-7 value:"
        '
        'chkboxCh6
        '
        Me.chkboxCh6.Enabled = False
        Me.chkboxCh6.Location = New System.Drawing.Point(16, 288)
        Me.chkboxCh6.Size = New System.Drawing.Size(136, 20)
        Me.chkboxCh6.Text = "AI-6 value:"
        '
        'chkboxCh5
        '
        Me.chkboxCh5.Enabled = False
        Me.chkboxCh5.Location = New System.Drawing.Point(16, 256)
        Me.chkboxCh5.Size = New System.Drawing.Size(136, 20)
        Me.chkboxCh5.Text = "AI-5 value:"
        '
        'chkboxCh4
        '
        Me.chkboxCh4.Enabled = False
        Me.chkboxCh4.Location = New System.Drawing.Point(16, 224)
        Me.chkboxCh4.Size = New System.Drawing.Size(136, 20)
        Me.chkboxCh4.Text = "AI-4 value:"
        '
        'chkboxCh3
        '
        Me.chkboxCh3.Enabled = False
        Me.chkboxCh3.Location = New System.Drawing.Point(16, 192)
        Me.chkboxCh3.Size = New System.Drawing.Size(136, 20)
        Me.chkboxCh3.Text = "AI-3 value:"
        '
        'chkboxCh2
        '
        Me.chkboxCh2.Enabled = False
        Me.chkboxCh2.Location = New System.Drawing.Point(16, 160)
        Me.chkboxCh2.Size = New System.Drawing.Size(136, 20)
        Me.chkboxCh2.Text = "AI-2 value:"
        '
        'chkboxCh1
        '
        Me.chkboxCh1.Enabled = False
        Me.chkboxCh1.Location = New System.Drawing.Point(16, 128)
        Me.chkboxCh1.Size = New System.Drawing.Size(136, 20)
        Me.chkboxCh1.Text = "AI-1 value:"
        '
        'chkboxCh0
        '
        Me.chkboxCh0.Enabled = False
        Me.chkboxCh0.Location = New System.Drawing.Point(16, 96)
        Me.chkboxCh0.Size = New System.Drawing.Size(136, 20)
        Me.chkboxCh0.Text = "AI-0 value:"
        '
        'txtAIValue7
        '
        Me.txtAIValue7.Location = New System.Drawing.Point(168, 320)
        Me.txtAIValue7.Size = New System.Drawing.Size(176, 22)
        Me.txtAIValue7.Text = ""
        '
        'txtAIValue6
        '
        Me.txtAIValue6.Location = New System.Drawing.Point(168, 288)
        Me.txtAIValue6.Size = New System.Drawing.Size(176, 22)
        Me.txtAIValue6.Text = ""
        '
        'txtAIValue5
        '
        Me.txtAIValue5.Location = New System.Drawing.Point(168, 256)
        Me.txtAIValue5.Size = New System.Drawing.Size(176, 22)
        Me.txtAIValue5.Text = ""
        '
        'txtAIValue4
        '
        Me.txtAIValue4.Location = New System.Drawing.Point(168, 224)
        Me.txtAIValue4.Size = New System.Drawing.Size(176, 22)
        Me.txtAIValue4.Text = ""
        '
        'txtAIValue3
        '
        Me.txtAIValue3.Location = New System.Drawing.Point(168, 192)
        Me.txtAIValue3.Size = New System.Drawing.Size(176, 22)
        Me.txtAIValue3.Text = ""
        '
        'txtAIValue2
        '
        Me.txtAIValue2.Location = New System.Drawing.Point(168, 160)
        Me.txtAIValue2.Size = New System.Drawing.Size(176, 22)
        Me.txtAIValue2.Text = ""
        '
        'txtAIValue1
        '
        Me.txtAIValue1.Location = New System.Drawing.Point(168, 128)
        Me.txtAIValue1.Size = New System.Drawing.Size(176, 22)
        Me.txtAIValue1.Text = ""
        '
        'txtAIValue0
        '
        Me.txtAIValue0.Location = New System.Drawing.Point(168, 96)
        Me.txtAIValue0.Size = New System.Drawing.Size(176, 22)
        Me.txtAIValue0.Text = ""
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
        Me.ClientSize = New System.Drawing.Size(458, 368)
        Me.Controls.Add(Me.chkboxCh7)
        Me.Controls.Add(Me.chkboxCh6)
        Me.Controls.Add(Me.chkboxCh5)
        Me.Controls.Add(Me.chkboxCh4)
        Me.Controls.Add(Me.chkboxCh3)
        Me.Controls.Add(Me.chkboxCh2)
        Me.Controls.Add(Me.chkboxCh1)
        Me.Controls.Add(Me.chkboxCh0)
        Me.Controls.Add(Me.txtAIValue7)
        Me.Controls.Add(Me.txtAIValue6)
        Me.Controls.Add(Me.txtAIValue5)
        Me.Controls.Add(Me.txtAIValue4)
        Me.Controls.Add(Me.txtAIValue3)
        Me.Controls.Add(Me.txtAIValue2)
        Me.Controls.Add(Me.txtAIValue1)
        Me.Controls.Add(Me.txtAIValue0)
        Me.Controls.Add(Me.txtModule)
        Me.Controls.Add(Me.label7)
        Me.Controls.Add(Me.txtReadCount)
        Me.Controls.Add(Me.label6)
        Me.Controls.Add(Me.buttonStart)
        Me.Text = "Adam5013_17_18 sample program (VB)"

    End Sub

    Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        m_iSlot = 1 ' the slot index of the module
        m_iCount = 0 ' the counting start from 0
        m_bStart = False

        adamCtl = New AdamControl

        'm_Adam5000Type = Adam5000Type.Adam5013 ' the sample is for ADAM-5013
        'm_Adam5000Type = Adam5000Type.Adam5017 ' the sample is for ADAM-5017
        m_Adam5000Type = Adam5000Type.Adam5018 ' the sample is for ADAM-5018

        m_iChTotal = AnalogInput.GetChannelTotal(m_Adam5000Type)

        txtModule.Text = m_Adam5000Type.ToString()
        ' 
        If m_Adam5000Type = Adam5000Type.Adam5013 Then
            chkboxCh3.Visible = False
            txtAIValue3.Visible = False
            chkboxCh4.Visible = False
            txtAIValue4.Visible = False
            chkboxCh5.Visible = False
            txtAIValue5.Visible = False
            chkboxCh6.Visible = False
            txtAIValue6.Visible = False
            chkboxCh7.Visible = False
            txtAIValue7.Visible = False
        ElseIf m_Adam5000Type = Adam5000Type.Adam5018 Then
            chkboxCh7.Visible = False
            txtAIValue7.Visible = False
        End If
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
                    RefreshChannelEnable()
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
        If m_Adam5000Type = Adam5000Type.Adam5013 Then
            RefreshAdam5013ChannelValue()
        ElseIf m_Adam5000Type = Adam5000Type.Adam5017 Then
            RefreshAdam5017ChannelValue()
        Else
            RefreshAdam5018ChannelValue()
        End If
    End Sub

    Private Sub RefreshChannelEnable()
        Dim bRet As Boolean
        Dim bEnabled() As Boolean

        bRet = adamCtl.AnalogInput().GetChannelEnabled(m_iSlot, m_iChTotal, bEnabled)

        If bRet = True Then
            If m_iChTotal > 0 Then
                chkboxCh0.Checked = bEnabled(0)
            End If
            If m_iChTotal > 1 Then
                chkboxCh1.Checked = bEnabled(1)
            End If
            If m_iChTotal > 2 Then
                chkboxCh2.Checked = bEnabled(2)
            End If
            If m_iChTotal > 3 Then
                chkboxCh3.Checked = bEnabled(3)
            End If
            If m_iChTotal > 4 Then
                chkboxCh4.Checked = bEnabled(4)
            End If
            If m_iChTotal > 5 Then
                chkboxCh5.Checked = bEnabled(5)
            End If
            If m_iChTotal > 6 Then
                chkboxCh6.Checked = bEnabled(6)
            End If
            If m_iChTotal > 7 Then
                chkboxCh7.Checked = bEnabled(7)
            End If
            txtAIValue0.Text = ""
            txtAIValue1.Text = ""
            txtAIValue2.Text = ""
            txtAIValue3.Text = ""
            txtAIValue4.Text = ""
            txtAIValue5.Text = ""
            txtAIValue6.Text = ""
            txtAIValue7.Text = ""
        Else
            MessageBox.Show("GetChannelEnabled() failed", "Error")
        End If
    End Sub

    Private Function RefreshChannelRange() As Boolean
        Dim bRet As Boolean

        bRet = adamCtl.AnalogInput().GetInputRange(m_iSlot, 0, m_byRange)
       
        If bRet = False Then
            MessageBox.Show("Get range failed!", "Error")
        End If
        Return bRet
    End Function

    Private Sub RefreshAdam5013ChannelValue()
        Dim fVal() As Single
        Dim szFormat As String, szUnit As String

        If adamCtl.AnalogInput().GetValues(m_iSlot, m_iChTotal, fVal) = True Then

            szFormat = AnalogInput.GetFloatFormat(m_Adam5000Type, m_byRange)
            szUnit = AnalogInput.GetUnitName(m_Adam5000Type, m_byRange)
            '
            If (chkboxCh0.Checked) Then
                txtAIValue0.Text = fVal(0).ToString(szFormat) + " " + szUnit
            End If
            If (chkboxCh1.Checked) Then
                txtAIValue1.Text = fVal(1).ToString(szFormat) + " " + szUnit
            End If
            If (chkboxCh2.Checked) Then
                txtAIValue2.Text = fVal(2).ToString(szFormat) + " " + szUnit
            End If

        Else
            If chkboxCh0.Checked = True Then
                txtAIValue0.Text = "Failed to get!"
            End If
            If chkboxCh1.Checked = True Then
                txtAIValue1.Text = "Failed to get!"
            End If
            If chkboxCh2.Checked = True Then
                txtAIValue2.Text = "Failed to get!"
            End If
        End If
   
    End Sub

    Private Sub RefreshAdam5017ChannelValue()
        Dim fVal() As Single
        Dim szFormat As String, szUnit As String

        If adamCtl.AnalogInput().GetValues(m_iSlot, m_iChTotal, fVal) = True Then
            ' floating format
            szFormat = AnalogInput.GetFloatFormat(m_Adam5000Type, m_byRange)
            szUnit = AnalogInput.GetUnitName(m_Adam5000Type, m_byRange)
            '
            If chkboxCh0.Checked = True Then
                txtAIValue0.Text = fVal(0).ToString(szFormat) + " " + szUnit
            End If
            If chkboxCh1.Checked = True Then
                txtAIValue1.Text = fVal(1).ToString(szFormat) + " " + szUnit
            End If
            If chkboxCh2.Checked = True Then
                txtAIValue2.Text = fVal(2).ToString(szFormat) + " " + szUnit
            End If
            If chkboxCh3.Checked = True Then
                txtAIValue3.Text = fVal(3).ToString(szFormat) + " " + szUnit
            End If
            If chkboxCh4.Checked = True Then
                txtAIValue4.Text = fVal(4).ToString(szFormat) + " " + szUnit
            End If
            If chkboxCh5.Checked = True Then
                txtAIValue5.Text = fVal(5).ToString(szFormat) + " " + szUnit
            End If
            If chkboxCh6.Checked = True Then
                txtAIValue6.Text = fVal(6).ToString(szFormat) + " " + szUnit
            End If
            If chkboxCh7.Checked = True Then
                txtAIValue7.Text = fVal(7).ToString(szFormat) + " " + szUnit
            End If
        Else
            If chkboxCh0.Checked = True Then
                txtAIValue0.Text = "Failed to get!"
            End If
            If chkboxCh1.Checked = True Then
                txtAIValue1.Text = "Failed to get!"
            End If
            If chkboxCh2.Checked = True Then
                txtAIValue2.Text = "Failed to get!"
            End If
            If chkboxCh3.Checked = True Then
                txtAIValue3.Text = "Failed to get!"
            End If
            If chkboxCh4.Checked = True Then
                txtAIValue4.Text = "Failed to get!"
            End If
            If chkboxCh5.Checked = True Then
                txtAIValue5.Text = "Failed to get!"
            End If
            If chkboxCh6.Checked = True Then
                txtAIValue6.Text = "Failed to get!"
            End If
            If chkboxCh7.Checked = True Then
                txtAIValue7.Text = "Failed to get!"
            End If
        End If
    End Sub

    Private Sub RefreshAdam5018ChannelValue()
        Dim fVal() As Single
        Dim szFormat As String, szUnit As String

        If adamCtl.AnalogInput().GetValues(m_iSlot, m_iChTotal, fVal) = True Then
            ' floating format
            szFormat = AnalogInput.GetFloatFormat(m_Adam5000Type, m_byRange)
            szUnit = AnalogInput.GetUnitName(m_Adam5000Type, m_byRange)
            '
            If chkboxCh0.Checked = True Then
                txtAIValue0.Text = fVal(0).ToString(szFormat) + " " + szUnit
            End If
            If chkboxCh1.Checked = True Then
                txtAIValue1.Text = fVal(1).ToString(szFormat) + " " + szUnit
            End If
            If chkboxCh2.Checked = True Then
                txtAIValue2.Text = fVal(2).ToString(szFormat) + " " + szUnit
            End If
            If chkboxCh3.Checked = True Then
                txtAIValue3.Text = fVal(3).ToString(szFormat) + " " + szUnit
            End If
            If chkboxCh4.Checked = True Then
                txtAIValue4.Text = fVal(4).ToString(szFormat) + " " + szUnit
            End If
            If chkboxCh5.Checked = True Then
                txtAIValue5.Text = fVal(5).ToString(szFormat) + " " + szUnit
            End If
            If chkboxCh6.Checked = True Then
                txtAIValue6.Text = fVal(6).ToString(szFormat) + " " + szUnit
            End If
        Else
            If chkboxCh0.Checked = True Then
                txtAIValue0.Text = "Failed to get!"
            End If
            If chkboxCh1.Checked = True Then
                txtAIValue1.Text = "Failed to get!"
            End If
            If chkboxCh2.Checked = True Then
                txtAIValue2.Text = "Failed to get!"
            End If
            If chkboxCh3.Checked = True Then
                txtAIValue3.Text = "Failed to get!"
            End If
            If chkboxCh4.Checked = True Then
                txtAIValue4.Text = "Failed to get!"
            End If
            If chkboxCh5.Checked = True Then
                txtAIValue5.Text = "Failed to get!"
            End If
            If chkboxCh6.Checked = True Then
                txtAIValue6.Text = "Failed to get!"
            End If
        End If

    End Sub

End Class
