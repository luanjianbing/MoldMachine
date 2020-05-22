Imports System.Net
Imports System.Text
Imports System.Web.Script.Serialization
Imports System.Threading

Public Class Form1
    Dim m_bStart As Boolean
    Dim m_ADAM3600Type As ADAM3600Type
    Dim m_szIP As String
    Dim m_szAccount As String
    Dim m_szPassword As String
    Dim m_iPort As Integer
    Dim m_iSlot As Integer
    Dim m_iCount As Integer
    Dim m_iDoTotal As Integer
    Dim m_iPollingTime As Integer
    Dim m_iDiTotal As Integer
    Dim m_textBoxList As List(Of TextBox)
    Dim m_DIOPanelList As List(Of Panel)
    Dim m_DIOBtnList As List(Of Button)
    Dim m_HttpRequestDI As AdvantechHttpWebUtility
    Dim m_HttpRequestDO As AdvantechHttpWebUtility
    Public Sub New()
        ' Required for Windows Form Designer support
        '
        InitializeComponent()
        '
        ' TODO: Add any constructor code after InitializeComponent call
        '
        m_bStart = False ' the action stops at the beginning
        m_szIP = "172.18.3.105" ' device IP address
        m_iPort = 80 ' http port is 80
        m_szAccount = "root" ' Login account
        m_szPassword = "00000000" ' Login password
        m_iSlot = 0 'Range from 0~4, Device localhost default slot is 0
        m_iPollingTime = 1000
        m_ADAM3600Type = ADAM3600Type.ADAM3600 ' the sample is for ADAM3600
        'm_ADAM3600Type = ADAM3600Type.ADAM3656 'the sample is forADAM3656
        'm_ADAM3600Type = ADAM3600Type.ADAM3651 ' the sample is for ADAM3651

        txtModule.Text = m_ADAM3600Type.ToString
        m_textBoxList = New List(Of TextBox)
        m_textBoxList.Add(txtCh0)
        m_textBoxList.Add(txtCh1)
        m_textBoxList.Add(txtCh2)
        m_textBoxList.Add(txtCh3)
        m_textBoxList.Add(txtCh4)
        m_textBoxList.Add(txtCh5)
        m_textBoxList.Add(txtCh6)
        m_textBoxList.Add(txtCh7)
        m_textBoxList.Add(txtCh8)
        m_textBoxList.Add(txtCh9)
        m_textBoxList.Add(txtCh10)
        m_textBoxList.Add(txtCh11)
        m_textBoxList.Add(txtCh12)
        m_textBoxList.Add(txtCh13)
        m_textBoxList.Add(txtCh14)
        m_textBoxList.Add(txtCh15)
        m_textBoxList.Add(txtCh16)
        m_textBoxList.Add(txtCh17)
        m_textBoxList.Add(txtCh18)
        m_textBoxList.Add(txtCh19)
        m_textBoxList.Add(txtCh20)
        m_textBoxList.Add(txtCh21)
        m_textBoxList.Add(txtCh22)
        m_textBoxList.Add(txtCh23)

        m_DIOPanelList = New List(Of Panel)
        m_DIOPanelList.Add(panelCh0)
        m_DIOPanelList.Add(panelCh1)
        m_DIOPanelList.Add(panelCh2)
        m_DIOPanelList.Add(panelCh3)
        m_DIOPanelList.Add(panelCh4)
        m_DIOPanelList.Add(panelCh5)
        m_DIOPanelList.Add(panelCh6)
        m_DIOPanelList.Add(panelCh7)
        m_DIOPanelList.Add(panelCh8)
        m_DIOPanelList.Add(panelCh9)
        m_DIOPanelList.Add(panelCh10)
        m_DIOPanelList.Add(panelCh11)
        m_DIOPanelList.Add(panelCh12)
        m_DIOPanelList.Add(panelCh13)
        m_DIOPanelList.Add(panelCh14)
        m_DIOPanelList.Add(panelCh15)
        m_DIOPanelList.Add(panelCh16)
        m_DIOPanelList.Add(panelCh17)
        m_DIOPanelList.Add(panelCh18)
        m_DIOPanelList.Add(panelCh19)
        m_DIOPanelList.Add(panelCh20)
        m_DIOPanelList.Add(panelCh21)
        m_DIOPanelList.Add(panelCh22)
        m_DIOPanelList.Add(panelCh23)

        m_DIOBtnList = New List(Of Button)
        m_DIOBtnList.Add(btnCh0)
        m_DIOBtnList.Add(btnCh1)
        m_DIOBtnList.Add(btnCh2)
        m_DIOBtnList.Add(btnCh3)
        m_DIOBtnList.Add(btnCh4)
        m_DIOBtnList.Add(btnCh5)
        m_DIOBtnList.Add(btnCh6)
        m_DIOBtnList.Add(btnCh7)
        m_DIOBtnList.Add(btnCh8)
        m_DIOBtnList.Add(btnCh9)
        m_DIOBtnList.Add(btnCh10)
        m_DIOBtnList.Add(btnCh11)
        m_DIOBtnList.Add(btnCh12)
        m_DIOBtnList.Add(btnCh13)
        m_DIOBtnList.Add(btnCh14)
        m_DIOBtnList.Add(btnCh15)
        m_DIOBtnList.Add(btnCh16)
        m_DIOBtnList.Add(btnCh17)
        m_DIOBtnList.Add(btnCh18)
        m_DIOBtnList.Add(btnCh19)
        m_DIOBtnList.Add(btnCh20)
        m_DIOBtnList.Add(btnCh21)
        m_DIOBtnList.Add(btnCh22)
        m_DIOBtnList.Add(btnCh23)
        m_HttpRequestDI = New AdvantechHttpWebUtility
        AddHandler m_HttpRequestDI.ResquestResponded, AddressOf Me.OnGetDIData
        AddHandler m_HttpRequestDI.ResquestOccurredError, AddressOf Me.OnGetDIHttpRequestError
        m_HttpRequestDO = New AdvantechHttpWebUtility
        AddHandler m_HttpRequestDO.ResquestResponded, AddressOf Me.OnGetDOData
        AddHandler m_HttpRequestDO.ResquestOccurredError, AddressOf Me.OnGetDOHttpRequestError
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtModule.Text = m_ADAM3600Type.ToString ' arrange channel text box
        txtSlot.Text = "Slot " + m_iSlot.ToString()
        If (m_ADAM3600Type = ADAM3600Type.ADAM3600) Then
            Initial_ADAM3600()
        ElseIf (m_ADAM3600Type = ADAM3600Type.ADAM3651) Then
            Initial_ADAM3651()
        Else
            Initial_ADAM3656()
        End If
        InitailForm()
    End Sub

    Private Sub Initial_ADAM3600()
        m_iDoTotal = 8
        m_iDiTotal = 16
    End Sub

    Private Sub Initial_ADAM3651()
        m_iDoTotal = 0
        m_iDiTotal = 8
    End Sub

    Private Sub Initial_ADAM3656()
        m_iDoTotal = 8
        m_iDiTotal = 0
    End Sub

    Private Sub InitailForm()
        Dim diCh As Integer = 0
        Do While (diCh < 16)
            If (diCh < m_iDiTotal) Then
                m_DIOBtnList(diCh).Text = "DI"
                m_DIOBtnList(diCh).Enabled = False
            End If
            diCh = (diCh + 1)
        Loop
        Dim doCh As Integer = m_iDiTotal
        Do While (doCh < 8 + 16)
            If ((doCh - m_iDiTotal) < m_iDoTotal) Then
                m_DIOBtnList(doCh).Text = "DO"
            Else
                m_DIOPanelList(doCh).Visible = False
            End If
            doCh = (doCh + 1)
        Loop
    End Sub

    Protected Sub InitChannelItems(ByVal i_bVisable As Boolean, ByVal i_bIsDI As Boolean, ByRef i_iDI As Integer, ByRef i_iDO As Integer, ByRef panelCh As Panel, ByRef btnCh As Button)
        Dim iCh As Integer
        If i_bVisable Then
            panelCh.Visible = True
            iCh = (i_iDI + i_iDO)
            If i_bIsDI Then
                btnCh.Text = ("DI " + i_iDI.ToString)
                btnCh.Enabled = False
                i_iDI = (i_iDI + 1)
            Else
                btnCh.Text = ("DO " + i_iDO.ToString)
                i_iDO = (i_iDO + 1)
            End If
        Else
            panelCh.Visible = False
        End If
    End Sub

    Private Function GetURL(ByVal ip As String, ByVal port As Integer, ByVal requestUri As String) As String
        Return ("http://" _
                    + (ip + (":" _
                    + (port.ToString() + ("/" + requestUri)))))
    End Function
    Delegate Sub TextBoxSettingInvoke(ByVal textBox As TextBox, ByVal text As String)
    Private Sub SetTextToTextBox(ByVal textBox As TextBox, ByVal text As String)
        If textBox.InvokeRequired Then
            Dim d As New TextBoxSettingInvoke(AddressOf Me.SetTextToTextBox)
            textBox.Invoke(d, New Object() {textBox, text})
        Else
            textBox.Text = text
        End If
    End Sub

    Private Sub OnGetDIHttpRequestError(ByVal e As Exception)
        Dim i As Integer = 0
        Do While (i < m_iDiTotal)
            SetTextToTextBox(m_textBoxList(i), e.Message)
            i = (i + 1)
        Loop
    End Sub

    Private Sub OnGetDOHttpRequestError(ByVal e As Exception)
        Dim i As Integer = 0
        Do While (i < m_iDoTotal)
            SetTextToTextBox(m_textBoxList((i + m_iDiTotal)), e.Message)
            i = (i + 1)
        Loop
    End Sub

    Private Sub UpdateDIUIStatus(ByVal di_values As DISlotValueData)
        Try
            If (Not (di_values.DIVal) Is Nothing) Then
                Dim i As Integer = 0
                Do While (i < di_values.DIVal.Length)
                    Dim textboxIndex As Integer = di_values.DIVal(i).Ch
                    SetTextToTextBox(m_textBoxList(textboxIndex), di_values.DIVal(i).Val.ToString)
                    i = (i + 1)
                Loop
            Else
                Throw New Exception("Parser DI Data Fail")
            End If
        Catch e As Exception
            OnGetDIHttpRequestError(e)
        Finally
            System.GC.Collect()
        End Try
    End Sub

    Private Sub UpdateDOUIStatus(ByVal do_values As DOSlotValueData)
        Try
            If (Not (do_values.DOVal) Is Nothing) Then
                Dim i As Integer = 0
                Do While (i < do_values.DOVal.Length)
                    Dim textboxIndex As Integer = (do_values.DOVal(i).Ch + m_iDiTotal)
                    SetTextToTextBox(m_textBoxList(textboxIndex), do_values.DOVal(i).Val.ToString)
                    i = (i + 1)
                Loop
            Else
                Throw New Exception("Parser DO Data Fail")
            End If
        Catch e As Exception
            OnGetDOHttpRequestError(e)
        Finally
            System.GC.Collect()
        End Try
    End Sub

    Private Sub GetDIValue()
        Dim uri As WISE_RESTFUL_URI = WISE_RESTFUL_URI.di_value
        m_HttpRequestDI.SendGETRequest(Me.m_szAccount, Me.m_szPassword, GetURL(Me.m_szIP, Me.m_iPort, (uri.ToString() + ("/slot_" + Me.m_iSlot.ToString))))
    End Sub

    Private Sub GetDOValue()
        Dim uri As WISE_RESTFUL_URI = WISE_RESTFUL_URI.do_value
        m_HttpRequestDO.SendGETRequest(Me.m_szAccount, Me.m_szPassword, GetURL(Me.m_szIP, Me.m_iPort, (uri.ToString + ("/slot_" + Me.m_iSlot.ToString))))
    End Sub

    Private Sub RefreshIOStatus()
        SetTextToTextBox(txtReadCount, "Requesting http...")
        If (Me.m_iDiTotal > 0) Then
            GetDIValue()
        Else
            GetDOValue()
        End If
    End Sub

    Private Sub OnGetDIData(ByVal rawData As String)
        Dim dateObj As DISlotValueData = AdvantechHttpWebUtility.ParserJsonToObj(Of DISlotValueData)(rawData)
        UpdateDIUIStatus(dateObj)
        GetDOValue()
    End Sub

    Private Sub OnGetDOData(ByVal rawData As String)
        Dim dateObj As DOSlotValueData = AdvantechHttpWebUtility.ParserJsonToObj(Of DOSlotValueData)(rawData)
        UpdateDOUIStatus(dateObj)
        InvokeReadStatus()
    End Sub

    Private Sub InvokeReadStatus()
        m_iCount = (m_iCount + 1)
        ' increment the reading counter
        SetTextToTextBox(txtReadCount, ("Request http " _
                        + (m_iCount.ToString + " times...")))
        Thread.Sleep(m_iPollingTime)
        If Me.m_bStart Then
            RefreshIOStatus()
        End If
    End Sub


    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
        If m_bStart Then
            m_bStart = Not m_bStart
        End If
    End Sub

    Private Sub btnCh_Click(ByVal i_iCh As Integer, ByVal txtBox As TextBox)
        Dim doData As DOSetValueData = New DOSetValueData()
        If txtBox.Text = "1" Then
            doData.Val = 0
        Else
            doData.Val = 1
        End If
        ' was ON, now set to OFF };
        Dim iChannel As Integer = (i_iCh - m_iDiTotal)
        Dim serializer As JavaScriptSerializer = New JavaScriptSerializer
        Dim sz_Jsonify As String = serializer.Serialize(doData)
        Try
            Dim uri As WISE_RESTFUL_URI = WISE_RESTFUL_URI.do_value
            Dim httpRequest As AdvantechHttpWebUtility = New AdvantechHttpWebUtility
            httpRequest.SendPATCHRequest(m_szAccount, m_szPassword, GetURL(m_szIP, m_iPort, (uri.ToString + ("/slot_" _
                                + (m_iSlot.ToString + ("/ch_" + iChannel.ToString))))), sz_Jsonify)
        Catch
            MessageBox.Show("Set digital output failed!", "Error")
        Finally
            System.GC.Collect()
        End Try
    End Sub

    Private Sub buttonStart_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonStart.Click
        If m_bStart Then
            panelDIO.Enabled = False
            m_bStart = False ' starting flag
            buttonStart.Text = "Start"
        Else
            panelDIO.Enabled = True
            m_iCount = 0 ' reset the reading counter
            buttonStart.Text = "Stop"
            m_bStart = True ' starting flag
            Me.InvokeReadStatus()
        End If
    End Sub

    Private Sub btnCh0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCh0.Click
        btnCh_Click(0, txtCh0)
    End Sub

    Private Sub btnCh1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCh1.Click
        btnCh_Click(1, txtCh1)
    End Sub

    Private Sub btnCh2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCh2.Click
        btnCh_Click(2, txtCh2)
    End Sub

    Private Sub btnCh3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCh3.Click
        btnCh_Click(3, txtCh3)
    End Sub

    Private Sub btnCh4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCh4.Click
        btnCh_Click(4, txtCh4)
    End Sub

    Private Sub btnCh5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCh5.Click
        btnCh_Click(5, txtCh5)
    End Sub

    Private Sub btnCh6_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCh6.Click
        btnCh_Click(6, txtCh6)
    End Sub

    Private Sub btnCh7_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCh7.Click
        btnCh_Click(7, txtCh7)
    End Sub

    Private Sub btnCh8_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCh8.Click
        btnCh_Click(8, txtCh8)
    End Sub

    Private Sub btnCh9_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCh9.Click
        btnCh_Click(9, txtCh9)
    End Sub

    Private Sub btnCh10_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCh10.Click
        btnCh_Click(10, txtCh10)
    End Sub

    Private Sub btnCh11_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCh11.Click
        btnCh_Click(11, txtCh11)
    End Sub

    Private Sub btnCh13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh13.Click
        btnCh_Click(13, txtCh13)
    End Sub

    Private Sub btnCh12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh12.Click
        btnCh_Click(12, txtCh12)
    End Sub

    Private Sub btnCh14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh14.Click
        btnCh_Click(14, txtCh14)
    End Sub

    Private Sub btnCh15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh15.Click
        btnCh_Click(15, txtCh15)
    End Sub

    Private Sub btnCh16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh16.Click
        btnCh_Click(16, txtCh16)
    End Sub

    Private Sub btnCh17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh17.Click
        btnCh_Click(17, txtCh17)
    End Sub

    Private Sub btnCh18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh18.Click
        btnCh_Click(18, txtCh18)
    End Sub

    Private Sub btnCh19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh19.Click
        btnCh_Click(19, txtCh19)
    End Sub

    Private Sub btnCh20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh20.Click
        btnCh_Click(20, txtCh20)
    End Sub

    Private Sub btnCh21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh21.Click
        btnCh_Click(21, txtCh21)
    End Sub

    Private Sub btnCh22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh22.Click
        btnCh_Click(22, txtCh22)
    End Sub

    Private Sub btnCh23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCh23.Click
        btnCh_Click(23, txtCh23)
    End Sub
End Class

''' <summary>
'''emun ADAM 3600 series device
''' </summary>
Public Enum ADAM3600Type
    ADAM3600 = 3600
    ADAM3651 = 3651
    ADAM3656 = 3656
End Enum
''' <summary>
''' Do value object
''' </summary>
Public Class DOValueData
    Private m_iCh As Integer 'Channel Number
    Public Property Ch() As Integer
        Get
            Return m_iCh
        End Get
        Set(ByVal value As Integer)
            m_iCh = value
        End Set
    End Property
    Private m_iMd As Integer 'Mode
    Public Property Md() As Integer
        Get
            Return m_iMd
        End Get
        Set(ByVal value As Integer)
            m_iMd = value
        End Set
    End Property
    Private m_iStat As Integer 'Signal Logic Status
    Public Property Stat() As Integer
        Get
            Return m_iStat
        End Get
        Set(ByVal value As Integer)
            m_iStat = value
        End Set
    End Property
    Private m_iVal As Integer 'Channel Value
    Public Property Val() As Integer
        Get
            Return m_iVal
        End Get
        Set(ByVal value As Integer)
            m_iVal = value
        End Set
    End Property
    Private m_iPsCtn As Integer 'Pulse Output Continue State
    Public Property PsCtn() As Integer
        Get
            Return m_iPsCtn
        End Get
        Set(ByVal value As Integer)
            m_iPsCtn = value
        End Set
    End Property
    Private m_iPsStop As Integer 'Stop Pulse Output
    Public Property PsStop() As Integer
        Get
            Return m_iPsStop
        End Get
        Set(ByVal value As Integer)
            m_iPsStop = value
        End Set
    End Property
    Private m_iPsIV As Integer 'Incremental Pulse Output Value
    Public Property PsIV() As Integer
        Get
            Return m_iPsIV
        End Get
        Set(ByVal value As Integer)
            m_iPsIV = value
        End Set
    End Property
End Class
''' <summary>
''' Do value object
''' </summary>
Public Class DOSetValueData
    Private m_iVal As Integer 'Channel Value
    Public Property Val() As Integer
        Get
            Return m_iVal
        End Get
        Set(ByVal value As Integer)
            m_iVal = value
        End Set
    End Property
End Class
Public Class DOSlotValueData
    Private m_iDOVal As DOValueData() 'Channel Value
    Public Property DOVal() As DOValueData()
        Get
            Return m_iDOVal
        End Get
        Set(ByVal value As DOValueData())
            m_iDOVal = value
        End Set
    End Property
End Class
''' <summary>
''' DI value object
''' </summary>
Public Class DIValueData
    Private m_iCh As Integer 'Channel Number
    Public Property Ch() As Integer
        Get
            Return m_iCh
        End Get
        Set(ByVal value As Integer)
            m_iCh = value
        End Set
    End Property
    Private m_iMd As Integer 'Mode
    Public Property Md() As Integer
        Get
            Return m_iMd
        End Get
        Set(ByVal value As Integer)
            m_iMd = value
        End Set
    End Property
    Private m_iVal As Integer 'Channel Value
    Public Property Val() As Integer
        Get
            Return m_iVal
        End Get
        Set(ByVal value As Integer)
            m_iVal = value
        End Set
    End Property
    Private m_iStat As Integer 'Signal Logic Status
    Public Property Stat() As Integer
        Get
            Return m_iStat
        End Get
        Set(ByVal value As Integer)
            m_iStat = value
        End Set
    End Property
    Private m_iCnting As Integer 'Start Counter
    Public Property Cnting() As Integer
        Get
            Return m_iCnting
        End Get
        Set(ByVal value As Integer)
            m_iCnting = value
        End Set
    End Property
    Private m_iOvLch As Integer 'Get/Clear Counter Overflow or Latch Status
    Public Property OvLch() As Integer
        Get
            Return OvLch
        End Get
        Set(ByVal value As Integer)
            m_iOvLch = value
        End Set
    End Property
End Class
Public Class DISlotValueData
    Private m_iDIVal As DIValueData() 'Values
    Public Property DIVal() As DIValueData()
        Get
            Return m_iDIVal
        End Get
        Set(ByVal value As DIValueData())
            m_iDIVal = value
        End Set
    End Property
End Class
''' <summary>
'''emun WISE series Restful URI 
''' </summary>
Public Enum WISE_RESTFUL_URI
    config
    file_xfer
    profile
    sys_info
    gen_config
    control
    net_basic
    net_config
    di_config
    di_value
    do_config
    do_value
    ai_genconfig
    ai_config
    ai_value
    modbus_coilconfig
    modbus_regconfig
    modbus_coilbas
    modbus_coillen
    modbus_regbas
    modbus_reglen
    accessctrl
    log_dataoption
    log_control
    log_output
    log_message
    log_event
    logex_output
    logex_file
    logex_list
    datastream
    p2p_mode
    p2p_basic
    p2p_advanced
    wlan_config
End Enum
''' <summary>
'''emun Http request method
''' </summary>
Public Enum HttpRequestOption
    HTTP_GET
    HTTP_PATCH
End Enum
Public Delegate Sub ResquestRespondedCallback(ByVal raw_data As String)
Public Delegate Sub ResquestOccurredErrorCallback(ByVal e As Exception)
Public Class AdvantechHttpWebUtility
    Private m_szBasicAuthAccount As String
    Private m_szBasicAuthPassword As String
    Private m_szURL As String
    Private m_szJsonifyString As String
    Private m_bHasDatag As Boolean
    Private m_Method As HttpRequestOption
    Public Event ResquestResponded As ResquestRespondedCallback
    Public Event ResquestOccurredError As ResquestOccurredErrorCallback

    Protected Property BasicAuthAccount() As String
        Get
            Return m_szBasicAuthAccount
        End Get
        Set(ByVal value As String)
            m_szBasicAuthAccount = value
        End Set
    End Property

    Protected Property BasicAuthPassword() As String
        Get
            Return m_szBasicAuthPassword
        End Get
        Set(ByVal value As String)
            m_szBasicAuthPassword = value
        End Set
    End Property

    Protected Property URL() As String
        Get
            Return m_szURL
        End Get
        Set(ByVal value As String)
            m_szURL = value
        End Set
    End Property

    Protected Property JsonifyString() As String
        Get
            Return m_szJsonifyString
        End Get
        Set(ByVal value As String)
            m_szJsonifyString = value
        End Set
    End Property

    Protected Property HasData() As Boolean
        Get
            Return m_bHasDatag
        End Get
        Set(ByVal value As Boolean)
            m_bHasDatag = value
        End Set
    End Property

    Protected Property Method() As HttpRequestOption
        Get
            Return m_Method
        End Get
        Set(ByVal value As HttpRequestOption)
            m_Method = value
        End Set
    End Property

    Public Sub New()
        MyBase.New()
    End Sub

    ''' <summary>
    ''' Invoke ResquestResponded Callback function
    ''' </summary>
    ''' <param name="raw_data"></param>
    Protected Overridable Sub OnResquestResponded(ByVal raw_data As String)
        Try
            RaiseEvent ResquestResponded(raw_data)
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Function ParserJsonToObj(Of T)(ByVal jsonifyString As String)
        Dim serializer As JavaScriptSerializer = New JavaScriptSerializer
        Dim values As T = serializer.Deserialize(Of T)(jsonifyString)
        Return values
    End Function

    ''' <summary>
    ''' Invoke ResquestOccurredError Callback function
    ''' </summary>
    ''' <param name="e"></param>
    Protected Overridable Sub OnResquestOccurredError(ByVal e As Exception)
        Try
            RaiseEvent ResquestOccurredError(e)
        Catch ex As Exception
        End Try
    End Sub

    Public Sub SendGETRequest(ByVal account As String, ByVal password As String, ByVal URL As String)
        Me.BasicAuthAccount = account
        Me.BasicAuthPassword = password
        Me.URL = URL
        Me.HasData = False
        Me.Method = HttpRequestOption.HTTP_GET
        SendRequest()
    End Sub

    Public Sub SendPATCHRequest(ByVal account As String, ByVal password As String, ByVal URL As String, ByVal JSONString As String)
        Me.BasicAuthAccount = account
        Me.BasicAuthPassword = password
        Me.URL = URL
        Me.JsonifyString = JSONString
        Me.HasData = True
        Me.Method = HttpRequestOption.HTTP_PATCH
        SendRequest()
    End Sub

    Protected Sub SendRequest()
        Dim myRequest As HttpWebRequest
        Dim outputStream As System.IO.Stream
        ' End the stream request operation
        myRequest = CType(WebRequest.Create(Me.URL), HttpWebRequest)
        ' create request
        myRequest.Headers.Add("Authorization", ("Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes((Me.BasicAuthAccount + (":" + Me.BasicAuthPassword))))))
        myRequest.Method = Method.ToString.Substring(5)
        myRequest.KeepAlive = False
        myRequest.ContentType = "application/x-www-form-urlencoded"
        myRequest.ReadWriteTimeout = 1000
        ' Create the patch data
        If Me.HasData Then
            Dim byData() As Byte = Encoding.ASCII.GetBytes(Me.JsonifyString)' convert POST data to bytes
            myRequest.ContentLength = byData.Length' Add the post data to the web request
            outputStream = myRequest.GetRequestStream
            outputStream.Write(byData, 0, byData.Length)
            outputStream.Close()
        End If
        Try
            myRequest.BeginGetResponse(New AsyncCallback(AddressOf Me.GetResponsetStreamCallback), myRequest)
        Catch e As Exception
            OnResquestOccurredError(e)
        End Try
    End Sub

    Private Sub GetResponsetStreamCallback(ByVal callbackResult As IAsyncResult)
        Dim request As HttpWebRequest = CType(callbackResult.AsyncState, HttpWebRequest)
        Dim result As String = ""
        Try
            Dim response As HttpWebResponse = CType(request.EndGetResponse(callbackResult), HttpWebResponse)
            Dim httpWebStreamReader As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream)
            If (response.StatusCode = HttpStatusCode.OK) Then
                result = httpWebStreamReader.ReadToEnd
            Else
                OnResquestOccurredError(New Exception(response.StatusCode.ToString))
            End If
            response.Close()
        Catch e As Exception
            OnResquestOccurredError(e)
        Finally
            request.Abort()
            OnResquestResponded(result)
        End Try
    End Sub
End Class