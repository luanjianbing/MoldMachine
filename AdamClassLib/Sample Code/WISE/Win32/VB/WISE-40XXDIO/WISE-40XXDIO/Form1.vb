Imports System.Net
Imports System.Text
Imports System.Web.Script.Serialization
Imports System.Threading

Public Class Form1
    Dim m_bStart As Boolean
    Dim m_WISE4000Type As WISEType
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
        m_szIP = "10.0.0.1" ' device IP address
        m_iPort = 80 ' http port is 80
        m_szAccount = "root" ' Login account
        m_szPassword = "00000000" ' Login password
        m_iSlot = 0 'Device localhost default slot is 0
        m_iPollingTime = 1000
        'm_WISE4000Type = WISEType.WISE4050LAN ' the sample is for WISE-4050/LAN
        'm_WISE4000Type = WISEType.WISE4050 ' the sample is for Wise-4050
        m_WISE4000Type = WISEType.WISE4060LAN ' the sample is for Wise-4060/LAN
        'm_WISE4000Type = WISEType.WISE4060 'the sample is for Wise-4060
        txtModule.Text = m_WISE4000Type.ToString
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
        m_HttpRequestDI = New AdvantechHttpWebUtility
        AddHandler m_HttpRequestDI.ResquestResponded, AddressOf Me.OnGetDIData
        AddHandler m_HttpRequestDI.ResquestOccurredError, AddressOf Me.OnGetDIHttpRequestError
        m_HttpRequestDO = New AdvantechHttpWebUtility
        AddHandler m_HttpRequestDO.ResquestResponded, AddressOf Me.OnGetDOData
        AddHandler m_HttpRequestDO.ResquestOccurredError, AddressOf Me.OnGetDOHttpRequestError
        IniWISE_DIO()
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

    Protected Sub IniWISE_DIO()
        Dim iDO As Integer = 0
        Dim iDI As Integer = 0
        InitChannelItems(True, True, iDI, iDO, panelCh0, btnCh0)
        InitChannelItems(True, True, iDI, iDO, panelCh1, btnCh1)
        InitChannelItems(True, True, iDI, iDO, panelCh2, btnCh2)
        InitChannelItems(True, True, iDI, iDO, panelCh3, btnCh3)
        InitChannelItems(True, False, iDI, iDO, panelCh4, btnCh4)
        InitChannelItems(True, False, iDI, iDO, panelCh5, btnCh5)
        InitChannelItems(True, False, iDI, iDO, panelCh6, btnCh6)
        InitChannelItems(True, False, iDI, iDO, panelCh7, btnCh7)
        InitChannelItems(False, False, iDI, iDO, panelCh8, btnCh8)
        InitChannelItems(False, False, iDI, iDO, panelCh9, btnCh9)
        InitChannelItems(False, False, iDI, iDO, panelCh10, btnCh10)
        InitChannelItems(False, False, iDI, iDO, panelCh11, btnCh11)
        m_iDoTotal = iDO
        m_iDiTotal = iDI
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
End Class

''' <summary>
'''emun WISE series device
''' </summary>
Public Enum WISEType
    WISE4010LAN = 4010
    WISE4050LAN = 4050
    WISE4060LAN = 4060
    WISE4012 = 24012
    WISE4012E = 34012
    WISE4050 = 24050
    WISE4060 = 24060
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
    Private m_iVal As UInteger 'Channel Value
    Public Property Val() As UInteger
        Get
            Return m_iVal
        End Get
        Set(ByVal value As UInteger)
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
    Private m_iPsIV As UInteger 'Incremental Pulse Output Value
    Public Property PsIV() As UInteger
        Get
            Return m_iPsIV
        End Get
        Set(ByVal value As UInteger)
            m_iPsIV = value
        End Set
    End Property
End Class
''' <summary>
''' Do value object
''' </summary>
Public Class DOSetValueData
    Private m_iVal As UInteger 'Channel Value
    Public Property Val() As UInteger
        Get
            Return m_iVal
        End Get
        Set(ByVal value As UInteger)
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
    Private m_iVal As UInteger 'Channel Value
    Public Property Val() As UInteger
        Get
            Return m_iVal
        End Get
        Set(ByVal value As UInteger)
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