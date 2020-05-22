Imports System.Net
Imports System.Text
Imports System.Web.Script.Serialization

Public Class Form1
    Dim m_httpRequest As AdvantechHttpWebUtility
    Dim MAX_CHANNEL_NUMBER = 32
    Dim expansion_type = String.Empty
    Dim evtCodeString() As String = {"No error", "Illegal function", "Illegal data address", "Illegal data value", "Slave device failure", "Acknowledge", "Slave device busy", "Negative acknowledge", "Memory parity error", "Reserved", "Gateway path unavailable", "Gateway target device failed to respond", "Reserved", "Reserved", "Reserved", "Reserved", "Unavailable", "Slave response timeout", "Checksum error", "Received data error", "Send request fail", "Unprocessed"}
    Public Sub New()
        MyBase.New()
        InitializeComponent()
        m_httpRequest = New AdvantechHttpWebUtility
        comboBox1.SelectedIndex = 0
        comboBoxUrl1.SelectedIndex = 0
        comboBoxUrl2.SelectedIndex = 0
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
        Dim count As Integer = 0
        Do While(count < MAX_CHANNEL_NUMBER)
            DataGridView1.Rows.Add(count, "", "", "", "", "")
            count = count + 1
        Loop

        AddHandler m_httpRequest.ResquestResponded, AddressOf Me.OnGetRequestData
        AddHandler m_httpRequest.ResquestOccurredError, AddressOf Me.OnGetErrorRequest
    End Sub


    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
        txtURL.Text = ("http://" _
                    + (txtIPAddress.Text + ("/" + comboBoxUrl1.SelectedItem.ToString() + "/" + comboBoxUrl2.SelectedItem.ToString())))
    End Sub

    Private Sub url_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtIPAddress.TextChanged
        Dim url1 As String = CType(comboBoxUrl1.SelectedItem, String)
        Dim url2 As String = CType(comboBoxUrl2.SelectedItem, String)

        txtURL.Text = ("http://" + (txtIPAddress.Text + ("/" + url1 + "/" + url2)))
    End Sub
    Delegate Sub TextBoxSettingInvoke(ByVal textBox As TextBox, ByVal text As String)
    Private Sub SetTextToTextBox(ByVal textBox As TextBox, ByVal text As String)
        If textBox.InvokeRequired Then
            Dim d As New TextBoxSettingInvoke(AddressOf Me.SetTextToTextBox)
            textBox.Invoke(d, New Object() {textBox, text})
        Else
            textBox.Text = text
        End If
    End Sub
    Delegate Sub ButtonSettingInvoke(ByVal btn As Button, ByVal enabled As Boolean)
    Private Sub SetBtnToEnabled(ByVal btn As Button, ByVal enabled As Boolean)
        If btn.InvokeRequired Then
            Dim d As New ButtonSettingInvoke(AddressOf Me.SetBtnToEnabled)
            btn.Invoke(d, New Object() {btn, enabled})
        Else
            btn.Enabled = enabled
        End If
    End Sub

    Private Sub OnGetRequestData(ByVal rawData As String)
        Dim dataObj(MAX_CHANNEL_NUMBER) As ExpansionValueData

        If (expansion_type.Equals("expansion_bit")) Then
            dataObj = (AdvantechHttpWebUtility.ParserJsonToObj(Of ExpansionBitObject)(rawData)).ExpBit
        Else
            dataObj = (AdvantechHttpWebUtility.ParserJsonToObj(Of ExpansionWordObject)(rawData)).ExpWord
        End If

        Dim length = dataObj.Length
        Dim evtWriteOnlyBit
        Dim evtString
        Dim cellArray(MAX_CHANNEL_NUMBER)
        For count = 0 To length - 1
            evtWriteOnlyBit = dataObj(count).Evt >> 7 'get bit 7
            dataObj(count).Evt = dataObj(count).Evt And &H7F 'strip bit 7
            evtString = evtCodeString(dataObj(count).Evt)
            If evtWriteOnlyBit = 1 Then
                DataGridView1.Rows(count).SetValues(New Object() {dataObj(count).Ch, "(Write Only)", evtString, dataObj(count).SID, dataObj(count).Addr, dataObj(count).MAddr})
            Else
                DataGridView1.Rows(count).SetValues(New Object() {dataObj(count).Ch, dataObj(count).Val, evtString, dataObj(count).SID, dataObj(count).Addr, dataObj(count).MAddr})
            End If

        Next count


        SetTextToTextBox(txtJSON, "Response reveived.")
        SetBtnToEnabled(btnSend, True)
    End Sub

    Private Sub OnGetErrorRequest(ByVal e As Exception)
        SetTextToTextBox(txtJSON, e.Message)
        SetBtnToEnabled(btnSend, True)
    End Sub

    Private Sub btnSend_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSend.Click
        Try
            btnSend.Enabled = False
            Dim URL As String = txtURL.Text
            Dim account As String = txtAcount.Text
            Dim password As String = txtPassword.Text
            SetTextToTextBox(txtJSON, "Requesting http...")
            m_httpRequest.SendGETRequest(account, password, URL)
        Catch err As Exception
            txtJSON.Text = err.ToString
        End Try
    End Sub

    Private Sub comboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles comboBox1.SelectedIndexChanged
        Dim cmb As ComboBox = CType(sender, ComboBox)
        Dim method As String = CType(cmb.SelectedItem, String)
    End Sub

    Private Sub comboBoxUrl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comboBoxUrl1.SelectedIndexChanged
        Dim url1 As String = CType(comboBoxUrl1.SelectedItem, String)
        Dim url2 As String = CType(comboBoxUrl2.SelectedItem, String)

        txtURL.Text = ("http://" + (txtIPAddress.Text + ("/" + url1 + "/" + url2)))
        expansion_type = comboBoxUrl1.SelectedItem
    End Sub

    Private Sub comboBoxUrl2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles comboBoxUrl2.SelectedIndexChanged
        Dim url1 As String = CType(comboBoxUrl1.SelectedItem, String)
        Dim url2 As String = CType(comboBoxUrl2.SelectedItem, String)

        txtURL.Text = ("http://" + (txtIPAddress.Text + ("/" + url1 + "/" + url2)))
    End Sub
End Class

''' <summary>
''' Expansion values object
''' </summary>
Public Class ExpansionValueData
    Private m_iCh As Integer 'Channel Number
    Public Property Ch() As Integer
        Get
            Return m_iCh
        End Get
        Set(ByVal value As Integer)
            m_iCh = value
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
    Private m_iEvt As Integer 'Channel Error Code
    Public Property Evt() As Integer
        Get
            Return m_iEvt
        End Get
        Set(ByVal value As Integer)
            m_iEvt = value
        End Set
    End Property
    Private m_iSID As Integer 'Slave Id
    Public Property SID() As Integer
        Get
            Return m_iSID
        End Get
        Set(ByVal value As Integer)
            m_iSID = value
        End Set
    End Property
    Private m_iAddr As Integer 'Slave Modbus address
    Public Property Addr() As Integer
        Get
            Return m_iAddr
        End Get
        Set(ByVal value As Integer)
            m_iAddr = value
        End Set
    End Property
    Private m_iMAddr As UInteger 'Modbus TCP Mapping Address
    Public Property MAddr() As UInteger
        Get
            Return m_iMAddr
        End Get
        Set(ByVal value As UInteger)
            m_iMAddr = value
        End Set
    End Property
End Class
''' <summary>
''' Expansion bit object
''' </summary>
Public Class ExpansionBitObject
    Private m_ExpVal As ExpansionValueData() 'Expansion Bit Value
    Public Property ExpBit() As ExpansionValueData()
        Get
            Return m_ExpVal
        End Get
        Set(ByVal value As ExpansionValueData())
            m_ExpVal = value
        End Set
    End Property
End Class

''' <summary>
''' Expansion Word object
''' </summary>
Public Class ExpansionWordObject
    Private m_ExpVal As ExpansionValueData() 'Expansion Bit Value
    Public Property ExpWord() As ExpansionValueData()
        Get
            Return m_ExpVal
        End Get
        Set(ByVal value As ExpansionValueData())
            m_ExpVal = value
        End Set
    End Property
End Class

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
            MessageBox.Show(ex.ToString(), "Error")
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
            Dim byData() As Byte = Encoding.ASCII.GetBytes(Me.JsonifyString)
            ' convert POST data to bytes
            myRequest.ContentLength = byData.Length
            ' Add the post data to the web request
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
        Dim bRet As Boolean
        bRet = False
        Dim request As HttpWebRequest = CType(callbackResult.AsyncState, HttpWebRequest)
        Dim result As String = ""
        Try
            Dim response As HttpWebResponse = CType(request.EndGetResponse(callbackResult), HttpWebResponse)
            Dim httpWebStreamReader As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream)
            If (response.StatusCode = HttpStatusCode.OK) Then
                If (response.ContentLength > 0) Then
                    result = httpWebStreamReader.ReadToEnd
                Else
                    result = Convert.ToString(Convert.ToInt32(HttpStatusCode.OK)) + " " + response.StatusDescription
                End If

                bRet = True
            Else
                OnResquestOccurredError(New Exception(response.StatusCode.ToString))
            End If
            response.Close()
        Catch e As Exception
            OnResquestOccurredError(e)
        Finally
            request.Abort()

            If (bRet = True) Then
                OnResquestResponded(result)
            End If

        End Try
    End Sub
End Class
