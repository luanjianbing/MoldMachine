Imports Advantech.Adam

Public Class Form1
    Inherits System.Windows.Forms.Form
    Friend WithEvents panel1 As System.Windows.Forms.Panel
    Friend WithEvents buttonEnable As System.Windows.Forms.Button
    Friend WithEvents comboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents labelTime As System.Windows.Forms.Label
    Friend WithEvents label2 As System.Windows.Forms.Label
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents panel2 As System.Windows.Forms.Panel
    Friend WithEvents textBox1 As System.Windows.Forms.TextBox
    Friend WithEvents label4 As System.Windows.Forms.Label
    Friend WithEvents buttonStrobe As System.Windows.Forms.Button
    Friend WithEvents buttonTest As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

    Private m_wdt As Advantech.Adam.Watchdog
    Private m_chip As Int32
    Private m_start As DateTime

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
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.panel1 = New System.Windows.Forms.Panel
        Me.buttonEnable = New System.Windows.Forms.Button
        Me.comboBox1 = New System.Windows.Forms.ComboBox
        Me.labelTime = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.panel2 = New System.Windows.Forms.Panel
        Me.textBox1 = New System.Windows.Forms.TextBox
        Me.label4 = New System.Windows.Forms.Label
        Me.buttonStrobe = New System.Windows.Forms.Button
        Me.buttonTest = New System.Windows.Forms.Button
        Me.Timer1 = New System.Windows.Forms.Timer
        Me.panel1.SuspendLayout()
        Me.panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'panel1
        '
        Me.panel1.Controls.Add(Me.buttonEnable)
        Me.panel1.Controls.Add(Me.comboBox1)
        Me.panel1.Controls.Add(Me.labelTime)
        Me.panel1.Controls.Add(Me.label2)
        Me.panel1.Controls.Add(Me.label1)
        Me.panel1.Location = New System.Drawing.Point(8, 8)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(392, 72)
        '
        'buttonEnable
        '
        Me.buttonEnable.Enabled = False
        Me.buttonEnable.Location = New System.Drawing.Point(312, 40)
        Me.buttonEnable.Name = "buttonEnable"
        Me.buttonEnable.Size = New System.Drawing.Size(72, 20)
        Me.buttonEnable.TabIndex = 0
        Me.buttonEnable.Text = "Enable"
        '
        'comboBox1
        '
        Me.comboBox1.Enabled = False
        Me.comboBox1.Location = New System.Drawing.Point(120, 8)
        Me.comboBox1.Name = "comboBox1"
        Me.comboBox1.Size = New System.Drawing.Size(184, 23)
        Me.comboBox1.TabIndex = 1
        '
        'labelTime
        '
        Me.labelTime.Location = New System.Drawing.Point(120, 40)
        Me.labelTime.Name = "labelTime"
        Me.labelTime.Size = New System.Drawing.Size(184, 20)
        Me.labelTime.Text = "00:00:00"
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(8, 40)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(100, 20)
        Me.label2.Text = "Elapsed time:"
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(8, 8)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(100, 20)
        Me.label1.Text = "Response time:"
        '
        'panel2
        '
        Me.panel2.Controls.Add(Me.textBox1)
        Me.panel2.Controls.Add(Me.label4)
        Me.panel2.Controls.Add(Me.buttonStrobe)
        Me.panel2.Controls.Add(Me.buttonTest)
        Me.panel2.Location = New System.Drawing.Point(8, 88)
        Me.panel2.Name = "panel2"
        Me.panel2.Size = New System.Drawing.Size(392, 128)
        '
        'textBox1
        '
        Me.textBox1.BackColor = System.Drawing.Color.Silver
        Me.textBox1.Location = New System.Drawing.Point(8, 40)
        Me.textBox1.Multiline = True
        Me.textBox1.Name = "textBox1"
        Me.textBox1.ReadOnly = True
        Me.textBox1.Size = New System.Drawing.Size(376, 80)
        Me.textBox1.TabIndex = 0
        Me.textBox1.Text = resources.GetString("textBox1.Text")
        '
        'label4
        '
        Me.label4.Location = New System.Drawing.Point(8, 8)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(200, 20)
        Me.label4.Text = "Reboot the machine by Watchdog"
        '
        'buttonStrobe
        '
        Me.buttonStrobe.Enabled = False
        Me.buttonStrobe.Location = New System.Drawing.Point(312, 8)
        Me.buttonStrobe.Name = "buttonStrobe"
        Me.buttonStrobe.Size = New System.Drawing.Size(72, 20)
        Me.buttonStrobe.TabIndex = 2
        Me.buttonStrobe.Text = "Strobe"
        '
        'buttonTest
        '
        Me.buttonTest.Enabled = False
        Me.buttonTest.Location = New System.Drawing.Point(232, 8)
        Me.buttonTest.Name = "buttonTest"
        Me.buttonTest.Size = New System.Drawing.Size(72, 20)
        Me.buttonTest.TabIndex = 3
        Me.buttonTest.Text = "Test"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'Form1
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.ClientSize = New System.Drawing.Size(410, 224)
        Me.Controls.Add(Me.panel2)
        Me.Controls.Add(Me.panel1)
        Me.Name = "Form1"
        Me.Text = "ADAM WDT sample program (VB)"
        Me.panel1.ResumeLayout(False)
        Me.panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub

#End Region

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        m_chip = 0
        m_wdt = New Watchdog
        If m_wdt.Initialize() = True Then
            m_chip = m_wdt.ChipType
            If m_chip = WDTCHIP.Chip_443 Then
                comboBox1.Items.Add("2 seconds")
                comboBox1.Items.Add("5 seconds")
                comboBox1.Items.Add("10 seconds")
                comboBox1.Items.Add("15 seconds")
                comboBox1.Items.Add("30 seconds")
                comboBox1.Items.Add("45 seconds")
                comboBox1.Items.Add("60 seconds")
            ElseIf m_chip = WDTCHIP.Chip_W83977AF Then
                comboBox1.Items.Add("15 seconds")
                comboBox1.Items.Add("45 seconds")
                comboBox1.Items.Add("1 Minute 15 seconds")
                comboBox1.Items.Add("2 Minutes 15 seconds")
                comboBox1.Items.Add("3 Minutes 15 seconds")
                comboBox1.Items.Add("4 Minutes 15 seconds")
                comboBox1.Items.Add("5 Minutes 15 seconds")
                comboBox1.Items.Add("10 Minutes 15 seconds")
                comboBox1.Items.Add("20 Minutes 15 seconds")
                comboBox1.Items.Add("30 Minutes 15 seconds")
                comboBox1.Items.Add("40 Minutes 15 seconds")
                comboBox1.Items.Add("50 Minutes 15 seconds")
                comboBox1.Items.Add("1 Hour 15 seconds")
                comboBox1.Items.Add("2 Hours 15 seconds")
            ElseIf m_chip = WDTCHIP.Chip_W83627HF Then
                comboBox1.Items.Add("15 seconds")
                comboBox1.Items.Add("45 seconds")
                comboBox1.Items.Add("1 Minute 15 seconds")
                comboBox1.Items.Add("2 Minutes 15 seconds")
                comboBox1.Items.Add("3 Minutes 15 seconds")
                comboBox1.Items.Add("4 Minutes 15 seconds")
            ElseIf m_chip = WDTCHIP.Chip_ADAM5550 Then
                comboBox1.Items.Add("15 seconds")
                comboBox1.Items.Add("45 seconds")
                comboBox1.Items.Add("1 Minute 15 seconds")
                comboBox1.Items.Add("2 Minutes 15 seconds")
                comboBox1.Items.Add("3 Minutes 15 seconds")
                comboBox1.Items.Add("4 Minutes 15 seconds")
            Else
                MessageBox.Show("Unknown chip type!")
                Return
            End If
            comboBox1.Enabled = True
            comboBox1.SelectedIndex = m_wdt.Timeout
            m_wdt.EnableStatus = False
            buttonEnable.Text = "Enable"
            buttonEnable.Enabled = True
        Else
            MessageBox.Show("Failed to initialize Watchdog!")
        End If
    End Sub

    Private Sub Form1_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        m_wdt.Terminate()
    End Sub

    Private Sub buttonEnable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonEnable.Click
        If m_wdt.EnableStatus = True Then
            m_wdt.EnableStatus = False
            buttonEnable.Text = "Enable"
            comboBox1.Enabled = True
            buttonTest.Enabled = False
            buttonStrobe.Enabled = False
        Else
            m_wdt.Timeout = comboBox1.SelectedIndex
            buttonEnable.Text = "Disable"
            comboBox1.Enabled = False
            buttonTest.Enabled = True
            buttonStrobe.Enabled = True
            m_wdt.EnableStatus = True
        End If
    End Sub

    Private Sub buttonTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonTest.Click
        If m_wdt.Reboot() = True Then
            buttonEnable.Enabled = False
            buttonTest.Enabled = False
            m_start = DateTime.Now
            labelTime.Text = "00:00:00 (Ready to reboot)"
            Timer1.Enabled = True
        Else
            MessageBox.Show("Failed to set reboot action!")
        End If
    End Sub

    Private Sub buttonStrobe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonStrobe.Click
        If m_wdt.Strobe() = True Then
            m_start = DateTime.Now
            labelTime.Text = "00:00:00 (Ready to reboot)"
        Else
            MessageBox.Show("Failed to set strobe action.")
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim nowTime As DateTime
        Dim diff As TimeSpan
        nowTime = DateTime.Now
        diff = nowTime.Subtract(m_start)
        labelTime.Text = diff.Hours.ToString("00") + ":" + diff.Minutes.ToString("00") + ":" + diff.Seconds.ToString("00") + " (Ready to reboot)"
    End Sub
End Class
