Public Class FormWait

    Private m_iTime, m_iMilliSec As Int32
    Private m_infiniteTimer As Boolean
    Private m_stopFlag As Boolean
    Private m_counter As Int32
    Private Const DIVIDOR As Int32 = 15

    Public Sub New(ByVal i_iMilliSec As Int32)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_iTime = 0
        m_iMilliSec = i_iMilliSec
    End Sub

    Public Sub New(ByVal i_szTitle As String, ByVal i_szDescription As String, ByVal i_iMilliSec As Int32)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_iTime = 0
        m_iMilliSec = i_iMilliSec

        Me.Text = i_szTitle
        labDescription.Text = i_szDescription
        m_infiniteTimer = False
        m_stopFlag = False
        m_counter = 0
    End Sub

    Public Sub New(ByVal i_szTitle As String, ByVal i_szDescription As String, ByVal i_infiniteTimer As Boolean)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_iTime = 0
        m_iMilliSec = 30000 ' to prevent not calling stop timer function

        Me.Text = i_szTitle
        labDescription.Text = i_szDescription
        m_stopFlag = False
        m_counter = 0

        If (i_infiniteTimer) Then
            m_infiniteTimer = True
        Else
            m_infiniteTimer = False
        End If

    End Sub

    Private Sub FormWait_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        timer1.Enabled = True
    End Sub

    Private Sub timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timer1.Tick
        m_iTime = m_iTime + timer1.Interval

        If (m_infiniteTimer) Then

            If ((m_stopFlag) OrElse (m_iTime >= m_iMilliSec)) Then
                progressBar1.Value = 100
                timer1.Enabled = False
                Me.Close()
            End If

            progressBar1.Value = (m_counter * 100) / DIVIDOR

            If (m_counter >= DIVIDOR) Then
                m_counter = 0
            Else
                m_counter = m_counter + 1
            End If

        Else

            If (m_iTime >= m_iMilliSec) Then
                progressBar1.Value = 100
                timer1.Enabled = False
                Me.Close()
            End If

            progressBar1.Value = m_iTime * 100 / m_iMilliSec

        End If
    End Sub

    Public StopFlagValue As Boolean

    Public Property StopFlag() As Boolean
        Get
            Return StopFlagValue
        End Get
        Set(ByVal value As Boolean)
            StopFlagValue = value
        End Set
    End Property

End Class