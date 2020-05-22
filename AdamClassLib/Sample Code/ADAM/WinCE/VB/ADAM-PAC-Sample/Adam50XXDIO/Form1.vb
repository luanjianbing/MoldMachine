Imports Advantech.Adam
Imports Advantech.Common


Public Class Form1
    Inherits System.Windows.Forms.Form
    Friend WithEvents panelDIO As System.Windows.Forms.Panel
    Friend WithEvents panelCh5 As System.Windows.Forms.Panel
    Friend WithEvents txtCh5 As System.Windows.Forms.TextBox
    Friend WithEvents btnCh5 As System.Windows.Forms.Button
    Friend WithEvents panelCh2 As System.Windows.Forms.Panel
    Friend WithEvents txtCh2 As System.Windows.Forms.TextBox
    Friend WithEvents btnCh2 As System.Windows.Forms.Button
    Friend WithEvents panelCh3 As System.Windows.Forms.Panel
    Friend WithEvents txtCh3 As System.Windows.Forms.TextBox
    Friend WithEvents btnCh3 As System.Windows.Forms.Button
    Friend WithEvents panelCh0 As System.Windows.Forms.Panel
    Friend WithEvents txtCh0 As System.Windows.Forms.TextBox
    Friend WithEvents btnCh0 As System.Windows.Forms.Button
    Friend WithEvents panelCh6 As System.Windows.Forms.Panel
    Friend WithEvents txtCh6 As System.Windows.Forms.TextBox
    Friend WithEvents btnCh6 As System.Windows.Forms.Button
    Friend WithEvents panelCh7 As System.Windows.Forms.Panel
    Friend WithEvents txtCh7 As System.Windows.Forms.TextBox
    Friend WithEvents btnCh7 As System.Windows.Forms.Button
    Friend WithEvents panelCh1 As System.Windows.Forms.Panel
    Friend WithEvents txtCh1 As System.Windows.Forms.TextBox
    Friend WithEvents btnCh1 As System.Windows.Forms.Button
    Friend WithEvents panelCh4 As System.Windows.Forms.Panel
    Friend WithEvents txtCh4 As System.Windows.Forms.TextBox
    Friend WithEvents btnCh4 As System.Windows.Forms.Button
    Friend WithEvents panelCh12 As System.Windows.Forms.Panel
    Friend WithEvents txtCh12 As System.Windows.Forms.TextBox
    Friend WithEvents btnCh12 As System.Windows.Forms.Button
    Friend WithEvents panelCh15 As System.Windows.Forms.Panel
    Friend WithEvents txtCh15 As System.Windows.Forms.TextBox
    Friend WithEvents btnCh15 As System.Windows.Forms.Button
    Friend WithEvents panelCh8 As System.Windows.Forms.Panel
    Friend WithEvents txtCh8 As System.Windows.Forms.TextBox
    Friend WithEvents btnCh8 As System.Windows.Forms.Button
    Friend WithEvents panelCh14 As System.Windows.Forms.Panel
    Friend WithEvents txtCh14 As System.Windows.Forms.TextBox
    Friend WithEvents btnCh14 As System.Windows.Forms.Button
    Friend WithEvents panelCh9 As System.Windows.Forms.Panel
    Friend WithEvents txtCh9 As System.Windows.Forms.TextBox
    Friend WithEvents btnCh9 As System.Windows.Forms.Button
    Friend WithEvents panelCh10 As System.Windows.Forms.Panel
    Friend WithEvents txtCh10 As System.Windows.Forms.TextBox
    Friend WithEvents btnCh10 As System.Windows.Forms.Button
    Friend WithEvents panelCh11 As System.Windows.Forms.Panel
    Friend WithEvents txtCh11 As System.Windows.Forms.TextBox
    Friend WithEvents btnCh11 As System.Windows.Forms.Button
    Friend WithEvents panelCh13 As System.Windows.Forms.Panel
    Friend WithEvents txtCh13 As System.Windows.Forms.TextBox
    Friend WithEvents btnCh13 As System.Windows.Forms.Button
    Friend WithEvents txtModule As System.Windows.Forms.TextBox
    Friend WithEvents label7 As System.Windows.Forms.Label
    Friend WithEvents txtReadCount As System.Windows.Forms.TextBox
    Friend WithEvents label6 As System.Windows.Forms.Label
    Friend WithEvents buttonStart As System.Windows.Forms.Button

    Private m_iSlot As Integer, m_iCount As Integer, m_iChTotal As Integer
    Private m_bStart As Boolean
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
        Me.panelDIO = New System.Windows.Forms.Panel
        Me.panelCh5 = New System.Windows.Forms.Panel
        Me.txtCh5 = New System.Windows.Forms.TextBox
        Me.btnCh5 = New System.Windows.Forms.Button
        Me.panelCh2 = New System.Windows.Forms.Panel
        Me.txtCh2 = New System.Windows.Forms.TextBox
        Me.btnCh2 = New System.Windows.Forms.Button
        Me.panelCh3 = New System.Windows.Forms.Panel
        Me.txtCh3 = New System.Windows.Forms.TextBox
        Me.btnCh3 = New System.Windows.Forms.Button
        Me.panelCh0 = New System.Windows.Forms.Panel
        Me.txtCh0 = New System.Windows.Forms.TextBox
        Me.btnCh0 = New System.Windows.Forms.Button
        Me.panelCh6 = New System.Windows.Forms.Panel
        Me.txtCh6 = New System.Windows.Forms.TextBox
        Me.btnCh6 = New System.Windows.Forms.Button
        Me.panelCh7 = New System.Windows.Forms.Panel
        Me.txtCh7 = New System.Windows.Forms.TextBox
        Me.btnCh7 = New System.Windows.Forms.Button
        Me.panelCh1 = New System.Windows.Forms.Panel
        Me.txtCh1 = New System.Windows.Forms.TextBox
        Me.btnCh1 = New System.Windows.Forms.Button
        Me.panelCh4 = New System.Windows.Forms.Panel
        Me.txtCh4 = New System.Windows.Forms.TextBox
        Me.btnCh4 = New System.Windows.Forms.Button
        Me.panelCh12 = New System.Windows.Forms.Panel
        Me.txtCh12 = New System.Windows.Forms.TextBox
        Me.btnCh12 = New System.Windows.Forms.Button
        Me.panelCh15 = New System.Windows.Forms.Panel
        Me.txtCh15 = New System.Windows.Forms.TextBox
        Me.btnCh15 = New System.Windows.Forms.Button
        Me.panelCh8 = New System.Windows.Forms.Panel
        Me.txtCh8 = New System.Windows.Forms.TextBox
        Me.btnCh8 = New System.Windows.Forms.Button
        Me.panelCh14 = New System.Windows.Forms.Panel
        Me.txtCh14 = New System.Windows.Forms.TextBox
        Me.btnCh14 = New System.Windows.Forms.Button
        Me.panelCh9 = New System.Windows.Forms.Panel
        Me.txtCh9 = New System.Windows.Forms.TextBox
        Me.btnCh9 = New System.Windows.Forms.Button
        Me.panelCh10 = New System.Windows.Forms.Panel
        Me.txtCh10 = New System.Windows.Forms.TextBox
        Me.btnCh10 = New System.Windows.Forms.Button
        Me.panelCh11 = New System.Windows.Forms.Panel
        Me.txtCh11 = New System.Windows.Forms.TextBox
        Me.btnCh11 = New System.Windows.Forms.Button
        Me.panelCh13 = New System.Windows.Forms.Panel
        Me.txtCh13 = New System.Windows.Forms.TextBox
        Me.btnCh13 = New System.Windows.Forms.Button
        Me.txtModule = New System.Windows.Forms.TextBox
        Me.label7 = New System.Windows.Forms.Label
        Me.txtReadCount = New System.Windows.Forms.TextBox
        Me.label6 = New System.Windows.Forms.Label
        Me.buttonStart = New System.Windows.Forms.Button
        Me.Timer1 = New System.Windows.Forms.Timer
        '
        'panelDIO
        '
        Me.panelDIO.Controls.Add(Me.panelCh5)
        Me.panelDIO.Controls.Add(Me.panelCh2)
        Me.panelDIO.Controls.Add(Me.panelCh3)
        Me.panelDIO.Controls.Add(Me.panelCh0)
        Me.panelDIO.Controls.Add(Me.panelCh6)
        Me.panelDIO.Controls.Add(Me.panelCh7)
        Me.panelDIO.Controls.Add(Me.panelCh1)
        Me.panelDIO.Controls.Add(Me.panelCh4)
        Me.panelDIO.Controls.Add(Me.panelCh12)
        Me.panelDIO.Controls.Add(Me.panelCh15)
        Me.panelDIO.Controls.Add(Me.panelCh8)
        Me.panelDIO.Controls.Add(Me.panelCh14)
        Me.panelDIO.Controls.Add(Me.panelCh9)
        Me.panelDIO.Controls.Add(Me.panelCh10)
        Me.panelDIO.Controls.Add(Me.panelCh11)
        Me.panelDIO.Controls.Add(Me.panelCh13)
        Me.panelDIO.Enabled = False
        Me.panelDIO.Location = New System.Drawing.Point(16, 80)
        Me.panelDIO.Size = New System.Drawing.Size(432, 336)
        '
        'panelCh5
        '
        Me.panelCh5.BackColor = System.Drawing.Color.SkyBlue
        Me.panelCh5.Controls.Add(Me.txtCh5)
        Me.panelCh5.Controls.Add(Me.btnCh5)
        Me.panelCh5.Location = New System.Drawing.Point(8, 208)
        Me.panelCh5.Size = New System.Drawing.Size(192, 40)
        '
        'txtCh5
        '
        Me.txtCh5.Location = New System.Drawing.Point(88, 8)
        Me.txtCh5.Size = New System.Drawing.Size(64, 22)
        Me.txtCh5.Text = ""
        '
        'btnCh5
        '
        Me.btnCh5.Location = New System.Drawing.Point(8, 8)
        Me.btnCh5.Size = New System.Drawing.Size(72, 24)
        Me.btnCh5.Text = "DIO"
        '
        'panelCh2
        '
        Me.panelCh2.BackColor = System.Drawing.Color.SkyBlue
        Me.panelCh2.Controls.Add(Me.txtCh2)
        Me.panelCh2.Controls.Add(Me.btnCh2)
        Me.panelCh2.Location = New System.Drawing.Point(8, 88)
        Me.panelCh2.Size = New System.Drawing.Size(192, 40)
        '
        'txtCh2
        '
        Me.txtCh2.Location = New System.Drawing.Point(88, 8)
        Me.txtCh2.Size = New System.Drawing.Size(64, 22)
        Me.txtCh2.Text = ""
        '
        'btnCh2
        '
        Me.btnCh2.Location = New System.Drawing.Point(8, 8)
        Me.btnCh2.Size = New System.Drawing.Size(72, 24)
        Me.btnCh2.Text = "DIO"
        '
        'panelCh3
        '
        Me.panelCh3.BackColor = System.Drawing.Color.SkyBlue
        Me.panelCh3.Controls.Add(Me.txtCh3)
        Me.panelCh3.Controls.Add(Me.btnCh3)
        Me.panelCh3.Location = New System.Drawing.Point(8, 128)
        Me.panelCh3.Size = New System.Drawing.Size(192, 40)
        '
        'txtCh3
        '
        Me.txtCh3.Location = New System.Drawing.Point(88, 8)
        Me.txtCh3.Size = New System.Drawing.Size(64, 22)
        Me.txtCh3.Text = ""
        '
        'btnCh3
        '
        Me.btnCh3.Location = New System.Drawing.Point(8, 8)
        Me.btnCh3.Size = New System.Drawing.Size(72, 24)
        Me.btnCh3.Text = "DIO"
        '
        'panelCh0
        '
        Me.panelCh0.BackColor = System.Drawing.Color.SkyBlue
        Me.panelCh0.Controls.Add(Me.txtCh0)
        Me.panelCh0.Controls.Add(Me.btnCh0)
        Me.panelCh0.Location = New System.Drawing.Point(8, 8)
        Me.panelCh0.Size = New System.Drawing.Size(192, 40)
        '
        'txtCh0
        '
        Me.txtCh0.Location = New System.Drawing.Point(88, 8)
        Me.txtCh0.Size = New System.Drawing.Size(64, 22)
        Me.txtCh0.Text = ""
        '
        'btnCh0
        '
        Me.btnCh0.Location = New System.Drawing.Point(8, 8)
        Me.btnCh0.Size = New System.Drawing.Size(72, 24)
        Me.btnCh0.Text = "DIO"
        '
        'panelCh6
        '
        Me.panelCh6.BackColor = System.Drawing.Color.SkyBlue
        Me.panelCh6.Controls.Add(Me.txtCh6)
        Me.panelCh6.Controls.Add(Me.btnCh6)
        Me.panelCh6.Location = New System.Drawing.Point(8, 248)
        Me.panelCh6.Size = New System.Drawing.Size(192, 40)
        '
        'txtCh6
        '
        Me.txtCh6.Location = New System.Drawing.Point(88, 8)
        Me.txtCh6.Size = New System.Drawing.Size(64, 22)
        Me.txtCh6.Text = ""
        '
        'btnCh6
        '
        Me.btnCh6.Location = New System.Drawing.Point(8, 8)
        Me.btnCh6.Size = New System.Drawing.Size(72, 24)
        Me.btnCh6.Text = "DIO"
        '
        'panelCh7
        '
        Me.panelCh7.BackColor = System.Drawing.Color.SkyBlue
        Me.panelCh7.Controls.Add(Me.txtCh7)
        Me.panelCh7.Controls.Add(Me.btnCh7)
        Me.panelCh7.Location = New System.Drawing.Point(8, 288)
        Me.panelCh7.Size = New System.Drawing.Size(192, 40)
        '
        'txtCh7
        '
        Me.txtCh7.Location = New System.Drawing.Point(88, 8)
        Me.txtCh7.Size = New System.Drawing.Size(64, 22)
        Me.txtCh7.Text = ""
        '
        'btnCh7
        '
        Me.btnCh7.Location = New System.Drawing.Point(8, 8)
        Me.btnCh7.Size = New System.Drawing.Size(72, 24)
        Me.btnCh7.Text = "DIO"
        '
        'panelCh1
        '
        Me.panelCh1.BackColor = System.Drawing.Color.SkyBlue
        Me.panelCh1.Controls.Add(Me.txtCh1)
        Me.panelCh1.Controls.Add(Me.btnCh1)
        Me.panelCh1.Location = New System.Drawing.Point(8, 48)
        Me.panelCh1.Size = New System.Drawing.Size(192, 40)
        '
        'txtCh1
        '
        Me.txtCh1.Location = New System.Drawing.Point(88, 8)
        Me.txtCh1.Size = New System.Drawing.Size(64, 22)
        Me.txtCh1.Text = ""
        '
        'btnCh1
        '
        Me.btnCh1.Location = New System.Drawing.Point(8, 8)
        Me.btnCh1.Size = New System.Drawing.Size(72, 24)
        Me.btnCh1.Text = "DIO"
        '
        'panelCh4
        '
        Me.panelCh4.BackColor = System.Drawing.Color.SkyBlue
        Me.panelCh4.Controls.Add(Me.txtCh4)
        Me.panelCh4.Controls.Add(Me.btnCh4)
        Me.panelCh4.Location = New System.Drawing.Point(8, 168)
        Me.panelCh4.Size = New System.Drawing.Size(192, 40)
        '
        'txtCh4
        '
        Me.txtCh4.Location = New System.Drawing.Point(88, 8)
        Me.txtCh4.Size = New System.Drawing.Size(64, 22)
        Me.txtCh4.Text = ""
        '
        'btnCh4
        '
        Me.btnCh4.Location = New System.Drawing.Point(8, 8)
        Me.btnCh4.Size = New System.Drawing.Size(72, 24)
        Me.btnCh4.Text = "DIO"
        '
        'panelCh12
        '
        Me.panelCh12.BackColor = System.Drawing.Color.SkyBlue
        Me.panelCh12.Controls.Add(Me.txtCh12)
        Me.panelCh12.Controls.Add(Me.btnCh12)
        Me.panelCh12.Location = New System.Drawing.Point(232, 168)
        Me.panelCh12.Size = New System.Drawing.Size(192, 40)
        '
        'txtCh12
        '
        Me.txtCh12.Location = New System.Drawing.Point(88, 8)
        Me.txtCh12.Size = New System.Drawing.Size(64, 22)
        Me.txtCh12.Text = ""
        '
        'btnCh12
        '
        Me.btnCh12.Location = New System.Drawing.Point(8, 8)
        Me.btnCh12.Size = New System.Drawing.Size(72, 24)
        Me.btnCh12.Text = "DIO"
        '
        'panelCh15
        '
        Me.panelCh15.BackColor = System.Drawing.Color.SkyBlue
        Me.panelCh15.Controls.Add(Me.txtCh15)
        Me.panelCh15.Controls.Add(Me.btnCh15)
        Me.panelCh15.Location = New System.Drawing.Point(232, 288)
        Me.panelCh15.Size = New System.Drawing.Size(192, 40)
        '
        'txtCh15
        '
        Me.txtCh15.Location = New System.Drawing.Point(88, 8)
        Me.txtCh15.Size = New System.Drawing.Size(64, 22)
        Me.txtCh15.Text = ""
        '
        'btnCh15
        '
        Me.btnCh15.Location = New System.Drawing.Point(8, 8)
        Me.btnCh15.Size = New System.Drawing.Size(72, 24)
        Me.btnCh15.Text = "DIO"
        '
        'panelCh8
        '
        Me.panelCh8.BackColor = System.Drawing.Color.SkyBlue
        Me.panelCh8.Controls.Add(Me.txtCh8)
        Me.panelCh8.Controls.Add(Me.btnCh8)
        Me.panelCh8.Location = New System.Drawing.Point(232, 8)
        Me.panelCh8.Size = New System.Drawing.Size(192, 40)
        '
        'txtCh8
        '
        Me.txtCh8.Location = New System.Drawing.Point(88, 8)
        Me.txtCh8.Size = New System.Drawing.Size(64, 22)
        Me.txtCh8.Text = ""
        '
        'btnCh8
        '
        Me.btnCh8.Location = New System.Drawing.Point(8, 8)
        Me.btnCh8.Size = New System.Drawing.Size(72, 24)
        Me.btnCh8.Text = "DIO"
        '
        'panelCh14
        '
        Me.panelCh14.BackColor = System.Drawing.Color.SkyBlue
        Me.panelCh14.Controls.Add(Me.txtCh14)
        Me.panelCh14.Controls.Add(Me.btnCh14)
        Me.panelCh14.Location = New System.Drawing.Point(232, 248)
        Me.panelCh14.Size = New System.Drawing.Size(192, 40)
        '
        'txtCh14
        '
        Me.txtCh14.Location = New System.Drawing.Point(88, 8)
        Me.txtCh14.Size = New System.Drawing.Size(64, 22)
        Me.txtCh14.Text = ""
        '
        'btnCh14
        '
        Me.btnCh14.Location = New System.Drawing.Point(8, 8)
        Me.btnCh14.Size = New System.Drawing.Size(72, 24)
        Me.btnCh14.Text = "DIO"
        '
        'panelCh9
        '
        Me.panelCh9.BackColor = System.Drawing.Color.SkyBlue
        Me.panelCh9.Controls.Add(Me.txtCh9)
        Me.panelCh9.Controls.Add(Me.btnCh9)
        Me.panelCh9.Location = New System.Drawing.Point(232, 48)
        Me.panelCh9.Size = New System.Drawing.Size(192, 40)
        '
        'txtCh9
        '
        Me.txtCh9.Location = New System.Drawing.Point(88, 8)
        Me.txtCh9.Size = New System.Drawing.Size(64, 22)
        Me.txtCh9.Text = ""
        '
        'btnCh9
        '
        Me.btnCh9.Location = New System.Drawing.Point(8, 8)
        Me.btnCh9.Size = New System.Drawing.Size(72, 24)
        Me.btnCh9.Text = "DIO"
        '
        'panelCh10
        '
        Me.panelCh10.BackColor = System.Drawing.Color.SkyBlue
        Me.panelCh10.Controls.Add(Me.txtCh10)
        Me.panelCh10.Controls.Add(Me.btnCh10)
        Me.panelCh10.Location = New System.Drawing.Point(232, 88)
        Me.panelCh10.Size = New System.Drawing.Size(192, 40)
        '
        'txtCh10
        '
        Me.txtCh10.Location = New System.Drawing.Point(88, 8)
        Me.txtCh10.Size = New System.Drawing.Size(64, 22)
        Me.txtCh10.Text = ""
        '
        'btnCh10
        '
        Me.btnCh10.Location = New System.Drawing.Point(8, 8)
        Me.btnCh10.Size = New System.Drawing.Size(72, 24)
        Me.btnCh10.Text = "DIO"
        '
        'panelCh11
        '
        Me.panelCh11.BackColor = System.Drawing.Color.SkyBlue
        Me.panelCh11.Controls.Add(Me.txtCh11)
        Me.panelCh11.Controls.Add(Me.btnCh11)
        Me.panelCh11.Location = New System.Drawing.Point(232, 128)
        Me.panelCh11.Size = New System.Drawing.Size(192, 40)
        '
        'txtCh11
        '
        Me.txtCh11.Location = New System.Drawing.Point(88, 8)
        Me.txtCh11.Size = New System.Drawing.Size(64, 22)
        Me.txtCh11.Text = ""
        '
        'btnCh11
        '
        Me.btnCh11.Location = New System.Drawing.Point(8, 8)
        Me.btnCh11.Size = New System.Drawing.Size(72, 24)
        Me.btnCh11.Text = "DIO"
        '
        'panelCh13
        '
        Me.panelCh13.BackColor = System.Drawing.Color.SkyBlue
        Me.panelCh13.Controls.Add(Me.txtCh13)
        Me.panelCh13.Controls.Add(Me.btnCh13)
        Me.panelCh13.Location = New System.Drawing.Point(232, 208)
        Me.panelCh13.Size = New System.Drawing.Size(192, 40)
        '
        'txtCh13
        '
        Me.txtCh13.Location = New System.Drawing.Point(88, 8)
        Me.txtCh13.Size = New System.Drawing.Size(64, 22)
        Me.txtCh13.Text = ""
        '
        'btnCh13
        '
        Me.btnCh13.Location = New System.Drawing.Point(8, 8)
        Me.btnCh13.Size = New System.Drawing.Size(72, 24)
        Me.btnCh13.Text = "DIO"
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
        Me.ClientSize = New System.Drawing.Size(466, 424)
        Me.Controls.Add(Me.panelDIO)
        Me.Controls.Add(Me.txtModule)
        Me.Controls.Add(Me.label7)
        Me.Controls.Add(Me.txtReadCount)
        Me.Controls.Add(Me.label6)
        Me.Controls.Add(Me.buttonStart)
        Me.Text = "Adam50XXDIO sample program (VB)"

    End Sub

    Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        m_iSlot = 3 ' the slot index of the module
        m_iCount = 0 ' the counting start from 0
        m_bStart = False

        adamCtl = New AdamControl

        'm_Adam5000Type = Adam5000Type.Adam5050 ' the sample is for ADAM-5050
        'm_Adam5000Type = Adam5000Type.Adam5051 ' the sample is for ADAM-5051
        'm_Adam5000Type = Adam5000Type.Adam5052 ' the sample is for ADAM-5052
        'm_Adam5000Type = Adam5000Type.Adam5055 ' the sample is for ADAM-5055
        'm_Adam5000Type = Adam5000Type.Adam5056 ' the sample is for ADAM-5056
        m_Adam5000Type = Adam5000Type.Adam5060 ' the sample is for ADAM-5060
        'm_Adam5000Type = Adam5000Type.Adam5068 ' the sample is for ADAM-5068
        'm_Adam5000Type = Adam5000Type.Adam5069 ' the sample is for ADAM-5069

        m_iChTotal = DigitalInput.GetChannelTotal(m_Adam5000Type) + DigitalOutput.GetChannelTotal(m_Adam5000Type)
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
                If RefreshForm() = True Then
                    panelDIO.Enabled = True
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
        RefresDIO()
    End Sub

    Private Function RefreshForm() As Boolean
        Dim bRet As Boolean

        bRet = False
        If m_Adam5000Type = Adam5000Type.Adam5050 Then
            bRet = InitAdam5050()
        ElseIf m_Adam5000Type = Adam5000Type.Adam5051 Then
            bRet = InitAdam5051()
        ElseIf m_Adam5000Type = Adam5000Type.Adam5052 Then
            bRet = InitAdam5052()
        ElseIf m_Adam5000Type = Adam5000Type.Adam5055 Then
            bRet = InitAdam5055()
        ElseIf m_Adam5000Type = Adam5000Type.Adam5056 Then
            bRet = InitAdam5056()
        ElseIf m_Adam5000Type = Adam5000Type.Adam5060 Then
            bRet = InitAdam5060()
        ElseIf m_Adam5000Type = Adam5000Type.Adam5068 Then
            bRet = InitAdam5068()
        ElseIf m_Adam5000Type = Adam5000Type.Adam5069 Then
            bRet = InitAdam5069()
        End If
        If bRet = False Then
            MessageBox.Show("Refresh form failed", "Error")
        End If
        Return bRet
    End Function

    Private Sub InitChannelItems(ByVal i_bVisable As Boolean, ByVal i_bIsDI As Boolean, ByVal i_bIsMasked As Boolean, ByRef i_iCh As Integer, ByRef i_iDI As Integer, ByRef i_iDO As Integer, ByRef panelCh As Panel, ByRef btnCh As Button)
        Dim iCh As Integer
        If i_bVisable = True Then
            panelCh.Visible = True
            iCh = i_iDI + i_iDO
            If i_bIsDI = True Then ' DI
                If i_iCh >= 0 Then
                    btnCh.Text = "Ch" + i_iCh.ToString("00") + "/DI"
                    i_iCh = i_iCh + 1
                Else
                    btnCh.Text = "DI " + i_iDI.ToString()
                End If
                btnCh.Enabled = False
                i_iDI = i_iDI + 1
            Else ' DO
                If i_iCh >= 0 Then
                    btnCh.Text = "Ch" + i_iCh.ToString("00") + "/DO"
                    i_iCh = i_iCh + 1
                Else
                    btnCh.Text = "DO " + i_iDO.ToString()
                End If
                If i_bIsMasked = True Then
                    btnCh.Enabled = False
                Else
                    btnCh.Enabled = True
                End If
                i_iDO = i_iDO + 1
            End If
        Else
            panelCh.Visible = False
        End If
    End Sub

    Private Function InitAdam5050() As Boolean
        Dim bDIO() As Boolean, bMask() As Boolean
        Dim bRet As Boolean
        Dim iCh As Integer, iDI As Integer, iDO As Integer

        iCh = 0
        iDI = 0
        iDO = 0

        bRet = (adamCtl.DigitalInput().GetUniversalStatus(m_iSlot, bDIO) And adamCtl.DigitalOutput().GetAlarmMappingMask(m_iSlot, m_iChTotal, bMask))

        If bRet = True And bDIO.Length = 16 Then
            InitChannelItems(True, bDIO(0), False, iCh, iDI, iDO, panelCh0, btnCh0)
            InitChannelItems(True, bDIO(1), False, iCh, iDI, iDO, panelCh1, btnCh1)
            InitChannelItems(True, bDIO(2), False, iCh, iDI, iDO, panelCh2, btnCh2)
            InitChannelItems(True, bDIO(3), False, iCh, iDI, iDO, panelCh3, btnCh3)
            InitChannelItems(True, bDIO(4), False, iCh, iDI, iDO, panelCh4, btnCh4)
            InitChannelItems(True, bDIO(5), False, iCh, iDI, iDO, panelCh5, btnCh5)
            InitChannelItems(True, bDIO(6), False, iCh, iDI, iDO, panelCh6, btnCh6)
            InitChannelItems(True, bDIO(7), False, iCh, iDI, iDO, panelCh7, btnCh7)
            InitChannelItems(True, bDIO(8), False, iCh, iDI, iDO, panelCh8, btnCh8)
            InitChannelItems(True, bDIO(9), False, iCh, iDI, iDO, panelCh9, btnCh9)
            InitChannelItems(True, bDIO(10), False, iCh, iDI, iDO, panelCh10, btnCh10)
            InitChannelItems(True, bDIO(11), False, iCh, iDI, iDO, panelCh11, btnCh11)
            InitChannelItems(True, bDIO(12), False, iCh, iDI, iDO, panelCh12, btnCh12)
            InitChannelItems(True, bDIO(13), False, iCh, iDI, iDO, panelCh13, btnCh13)
            InitChannelItems(True, bDIO(14), False, iCh, iDI, iDO, panelCh14, btnCh14)
            InitChannelItems(True, bDIO(15), False, iCh, iDI, iDO, panelCh15, btnCh15)
            Return True
        End If
        Return False
    End Function

    Private Function InitAdam5051() As Boolean
        Dim iCh As Integer, iDI As Integer, iDO As Integer

        iCh = -1
        iDI = 0
        iDO = 0

        InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh0, btnCh0)
        InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh1, btnCh1)
        InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh2, btnCh2)
        InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh3, btnCh3)
        InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh4, btnCh4)
        InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh5, btnCh5)
        InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh6, btnCh6)
        InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh7, btnCh7)
        InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh8, btnCh8)
        InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh9, btnCh9)
        InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh10, btnCh10)
        InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh11, btnCh11)
        InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh12, btnCh12)
        InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh13, btnCh13)
        InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh14, btnCh14)
        InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh15, btnCh15)
        Return True
    End Function

    Private Function InitAdam5052() As Boolean
        Dim iCh As Integer, iDI As Integer, iDO As Integer

        iCh = -1
        iDI = 0
        iDO = 0

        InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh0, btnCh0)
        InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh1, btnCh1)
        InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh2, btnCh2)
        InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh3, btnCh3)
        InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh4, btnCh4)
        InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh5, btnCh5)
        InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh6, btnCh6)
        InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh7, btnCh7)
        InitChannelItems(False, True, False, iCh, iDI, iDO, panelCh8, btnCh8)
        InitChannelItems(False, True, False, iCh, iDI, iDO, panelCh9, btnCh9)
        InitChannelItems(False, True, False, iCh, iDI, iDO, panelCh10, btnCh10)
        InitChannelItems(False, True, False, iCh, iDI, iDO, panelCh11, btnCh11)
        InitChannelItems(False, True, False, iCh, iDI, iDO, panelCh12, btnCh12)
        InitChannelItems(False, True, False, iCh, iDI, iDO, panelCh13, btnCh13)
        InitChannelItems(False, True, False, iCh, iDI, iDO, panelCh14, btnCh14)
        InitChannelItems(False, True, False, iCh, iDI, iDO, panelCh15, btnCh15)
        Return True
    End Function

    Private Function InitAdam5055() As Boolean

        Dim iCh As Integer, iDI As Integer, iDO As Integer

        iCh = -1
        iDI = 0
        iDO = 0

 
        InitChannelItems(True, False, False, iCh, iDI, iDO, panelCh0, btnCh0)
        InitChannelItems(True, False, False, iCh, iDI, iDO, panelCh1, btnCh1)
        InitChannelItems(True, False, False, iCh, iDI, iDO, panelCh2, btnCh2)
        InitChannelItems(True, False, False, iCh, iDI, iDO, panelCh3, btnCh3)
        InitChannelItems(True, False, False, iCh, iDI, iDO, panelCh4, btnCh4)
        InitChannelItems(True, False, False, iCh, iDI, iDO, panelCh5, btnCh5)
        InitChannelItems(True, False, False, iCh, iDI, iDO, panelCh6, btnCh6)
        InitChannelItems(True, False, False, iCh, iDI, iDO, panelCh7, btnCh7)
        InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh8, btnCh8)
        InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh9, btnCh9)
        InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh10, btnCh10)
        InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh11, btnCh11)
        InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh12, btnCh12)
        InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh13, btnCh13)
        InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh14, btnCh14)
        InitChannelItems(True, True, False, iCh, iDI, iDO, panelCh15, btnCh15)
        Return True

    End Function

    Private Function InitAdam5056() As Boolean

        Dim iCh As Integer, iDI As Integer, iDO As Integer

        iCh = -1
        iDI = 0
        iDO = 0


        InitChannelItems(True, False, False, iCh, iDI, iDO, panelCh0, btnCh0)
        InitChannelItems(True, False, False, iCh, iDI, iDO, panelCh1, btnCh1)
        InitChannelItems(True, False, False, iCh, iDI, iDO, panelCh2, btnCh2)
        InitChannelItems(True, False, False, iCh, iDI, iDO, panelCh3, btnCh3)
        InitChannelItems(True, False, False, iCh, iDI, iDO, panelCh4, btnCh4)
        InitChannelItems(True, False, False, iCh, iDI, iDO, panelCh5, btnCh5)
        InitChannelItems(True, False, False, iCh, iDI, iDO, panelCh6, btnCh6)
        InitChannelItems(True, False, False, iCh, iDI, iDO, panelCh7, btnCh7)
        InitChannelItems(True, False, False, iCh, iDI, iDO, panelCh8, btnCh8)
        InitChannelItems(True, False, False, iCh, iDI, iDO, panelCh9, btnCh9)
        InitChannelItems(True, False, False, iCh, iDI, iDO, panelCh10, btnCh10)
        InitChannelItems(True, False, False, iCh, iDI, iDO, panelCh11, btnCh11)
        InitChannelItems(True, False, False, iCh, iDI, iDO, panelCh12, btnCh12)
        InitChannelItems(True, False, False, iCh, iDI, iDO, panelCh13, btnCh13)
        InitChannelItems(True, False, False, iCh, iDI, iDO, panelCh14, btnCh14)
        InitChannelItems(True, False, False, iCh, iDI, iDO, panelCh15, btnCh15)
            Return True

    End Function

    Private Function InitAdam5060() As Boolean

        Dim iCh As Integer, iDI As Integer, iDO As Integer

        iCh = -1
        iDI = 0
        iDO = 0


        InitChannelItems(True, False, False, iCh, iDI, iDO, panelCh0, btnCh0)
        InitChannelItems(True, False, False, iCh, iDI, iDO, panelCh1, btnCh1)
        InitChannelItems(True, False, False, iCh, iDI, iDO, panelCh2, btnCh2)
        InitChannelItems(True, False, False, iCh, iDI, iDO, panelCh3, btnCh3)
        InitChannelItems(True, False, False, iCh, iDI, iDO, panelCh4, btnCh4)
        InitChannelItems(True, False, False, iCh, iDI, iDO, panelCh5, btnCh5)
        InitChannelItems(False, False, False, iCh, iDI, iDO, panelCh6, btnCh6)
        InitChannelItems(False, False, False, iCh, iDI, iDO, panelCh7, btnCh7)
        InitChannelItems(False, False, False, iCh, iDI, iDO, panelCh8, btnCh8)
        InitChannelItems(False, False, False, iCh, iDI, iDO, panelCh9, btnCh9)
        InitChannelItems(False, False, False, iCh, iDI, iDO, panelCh10, btnCh10)
        InitChannelItems(False, False, False, iCh, iDI, iDO, panelCh11, btnCh11)
        InitChannelItems(False, False, False, iCh, iDI, iDO, panelCh12, btnCh12)
        InitChannelItems(False, False, False, iCh, iDI, iDO, panelCh13, btnCh13)
        InitChannelItems(False, False, False, iCh, iDI, iDO, panelCh14, btnCh14)
        InitChannelItems(False, False, False, iCh, iDI, iDO, panelCh15, btnCh15)
        Return True

    End Function

    Private Function InitAdam5068() As Boolean

        Dim iCh As Integer, iDI As Integer, iDO As Integer

        iCh = -1
        iDI = 0
        iDO = 0


        InitChannelItems(True, False, False, iCh, iDI, iDO, panelCh0, btnCh0)
        InitChannelItems(True, False, False, iCh, iDI, iDO, panelCh1, btnCh1)
        InitChannelItems(True, False, False, iCh, iDI, iDO, panelCh2, btnCh2)
        InitChannelItems(True, False, False, iCh, iDI, iDO, panelCh3, btnCh3)
        InitChannelItems(True, False, False, iCh, iDI, iDO, panelCh4, btnCh4)
        InitChannelItems(True, False, False, iCh, iDI, iDO, panelCh5, btnCh5)
        InitChannelItems(True, False, False, iCh, iDI, iDO, panelCh6, btnCh6)
        InitChannelItems(True, False, False, iCh, iDI, iDO, panelCh7, btnCh7)
        InitChannelItems(False, False, False, iCh, iDI, iDO, panelCh8, btnCh8)
        InitChannelItems(False, False, False, iCh, iDI, iDO, panelCh9, btnCh9)
        InitChannelItems(False, False, False, iCh, iDI, iDO, panelCh10, btnCh10)
        InitChannelItems(False, False, False, iCh, iDI, iDO, panelCh11, btnCh11)
        InitChannelItems(False, False, False, iCh, iDI, iDO, panelCh12, btnCh12)
        InitChannelItems(False, False, False, iCh, iDI, iDO, panelCh13, btnCh13)
        InitChannelItems(False, False, False, iCh, iDI, iDO, panelCh14, btnCh14)
        InitChannelItems(False, False, False, iCh, iDI, iDO, panelCh15, btnCh15)
        Return True

    End Function

    Private Function InitAdam5069() As Boolean

        Dim iCh As Integer, iDI As Integer, iDO As Integer

        iCh = -1
        iDI = 0
        iDO = 0


        InitChannelItems(True, False, False, iCh, iDI, iDO, panelCh0, btnCh0)
        InitChannelItems(True, False, False, iCh, iDI, iDO, panelCh1, btnCh1)
        InitChannelItems(True, False, False, iCh, iDI, iDO, panelCh2, btnCh2)
        InitChannelItems(True, False, False, iCh, iDI, iDO, panelCh3, btnCh3)
        InitChannelItems(True, False, False, iCh, iDI, iDO, panelCh4, btnCh4)
        InitChannelItems(True, False, False, iCh, iDI, iDO, panelCh5, btnCh5)
        InitChannelItems(True, False, False, iCh, iDI, iDO, panelCh6, btnCh6)
        InitChannelItems(True, False, False, iCh, iDI, iDO, panelCh7, btnCh7)
        InitChannelItems(False, False, False, iCh, iDI, iDO, panelCh8, btnCh8)
        InitChannelItems(False, False, False, iCh, iDI, iDO, panelCh9, btnCh9)
        InitChannelItems(False, False, False, iCh, iDI, iDO, panelCh10, btnCh10)
        InitChannelItems(False, False, False, iCh, iDI, iDO, panelCh11, btnCh11)
        InitChannelItems(False, False, False, iCh, iDI, iDO, panelCh12, btnCh12)
        InitChannelItems(False, False, False, iCh, iDI, iDO, panelCh13, btnCh13)
        InitChannelItems(False, False, False, iCh, iDI, iDO, panelCh14, btnCh14)
        InitChannelItems(False, False, False, iCh, iDI, iDO, panelCh15, btnCh15)
        Return True

    End Function

    Private Function RefresDIO() As Boolean
        Dim bData() As Boolean
        Dim bRet As Boolean

        bRet = adamCtl.DigitalInput().GetValues(m_iSlot, m_iChTotal, bData)

        If bRet = True Then
            If m_iChTotal > 0 Then
                txtCh0.Text = bData(0).ToString()
            End If
            If m_iChTotal > 1 Then
                txtCh1.Text = bData(1).ToString()
            End If
            If m_iChTotal > 2 Then
                txtCh2.Text = bData(2).ToString()
            End If
            If m_iChTotal > 3 Then
                txtCh3.Text = bData(3).ToString()
            End If
            If m_iChTotal > 4 Then
                txtCh4.Text = bData(4).ToString()
            End If
            If m_iChTotal > 5 Then
                txtCh5.Text = bData(5).ToString()
            End If
            If m_iChTotal > 6 Then
                txtCh6.Text = bData(6).ToString()
            End If
            If m_iChTotal > 7 Then
                txtCh7.Text = bData(7).ToString()
            End If
            If m_iChTotal > 8 Then
                txtCh8.Text = bData(8).ToString()
            End If
            If m_iChTotal > 9 Then
                txtCh9.Text = bData(9).ToString()
            End If
            If m_iChTotal > 10 Then
                txtCh10.Text = bData(10).ToString()
            End If
            If m_iChTotal > 11 Then
                txtCh11.Text = bData(11).ToString()
            End If
            If m_iChTotal > 12 Then
                txtCh12.Text = bData(12).ToString()
            End If
            If m_iChTotal > 13 Then
                txtCh13.Text = bData(13).ToString()
            End If
            If m_iChTotal > 14 Then
                txtCh14.Text = bData(14).ToString()
            End If
            If m_iChTotal > 15 Then
                txtCh15.Text = bData(15).ToString()
            End If
            Return True
        Else
            txtCh0.Text = "Fail"
            txtCh1.Text = "Fail"
            txtCh2.Text = "Fail"
            txtCh3.Text = "Fail"
            txtCh4.Text = "Fail"
            txtCh5.Text = "Fail"
            txtCh6.Text = "Fail"
            txtCh7.Text = "Fail"
            txtCh8.Text = "Fail"
            txtCh9.Text = "Fail"
            txtCh10.Text = "Fail"
            txtCh11.Text = "Fail"
            txtCh12.Text = "Fail"
            txtCh13.Text = "Fail"
            txtCh14.Text = "Fail"
            txtCh15.Text = "Fail"
        End If
        Return False
    End Function

    Private Sub btnCh_Click(ByVal i_iCh As Integer, ByRef txtBox As TextBox)
        Dim bRet As Boolean
        Dim iStart As Integer

        iStart = m_iSlot * 16 + i_iCh + 1
        Timer1.Enabled = False

        bRet = adamCtl.DigitalOutput().SetValue(m_iSlot, i_iCh, (txtBox.Text = "False"))

        If bRet = False Then
            MessageBox.Show("Set digital output failed!", "Error")
        End If
        Timer1.Enabled = True
    End Sub

    Private Sub btnCh0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh0.Click
        btnCh_Click(0, txtCh0)
    End Sub

    Private Sub btnCh1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh1.Click
        btnCh_Click(1, txtCh1)
    End Sub

    Private Sub btnCh2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh2.Click
        btnCh_Click(2, txtCh2)
    End Sub

    Private Sub btnCh3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh3.Click
        btnCh_Click(3, txtCh3)
    End Sub

    Private Sub btnCh4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh4.Click
        btnCh_Click(4, txtCh4)
    End Sub

    Private Sub btnCh5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh5.Click
        btnCh_Click(5, txtCh5)
    End Sub

    Private Sub btnCh6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh6.Click
        btnCh_Click(6, txtCh6)
    End Sub

    Private Sub btnCh7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh7.Click
        btnCh_Click(7, txtCh7)
    End Sub

    Private Sub btnCh8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh8.Click
        btnCh_Click(8, txtCh8)
    End Sub

    Private Sub btnCh9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh9.Click
        btnCh_Click(9, txtCh9)
    End Sub

    Private Sub btnCh10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh10.Click
        btnCh_Click(10, txtCh10)
    End Sub

    Private Sub btnCh11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh11.Click
        btnCh_Click(11, txtCh11)
    End Sub

    Private Sub btnCh12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh12.Click
        btnCh_Click(12, txtCh12)
    End Sub

    Private Sub btnCh13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh13.Click
        btnCh_Click(13, txtCh13)
    End Sub

    Private Sub btnCh14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh14.Click
        btnCh_Click(14, txtCh14)
    End Sub

    Private Sub btnCh15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh15.Click
        btnCh_Click(15, txtCh15)
    End Sub
End Class
