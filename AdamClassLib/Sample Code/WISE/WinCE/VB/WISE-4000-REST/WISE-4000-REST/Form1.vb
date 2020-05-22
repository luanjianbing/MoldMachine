Imports System.Net
Imports System.Text

Public Class Form1
    Dim m_httpRequest As AdvantechHttpWebUtility
    Public Sub New()
        MyBase.New()
        InitializeComponent()
        m_httpRequest = New AdvantechHttpWebUtility
        comboBox1.SelectedIndex = 0
        AddHandler m_httpRequest.ResquestResponded, AddressOf Me.OnGetRequestData
        AddHandler m_httpRequest.ResquestOccurredError, AddressOf Me.OnGetErrorRequest
    End Sub


    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        txtURL.Text = ("http://" _
                    + (txtIPAddress.Text + ("/" + txtTarget.Text)))
    End Sub

    Private Sub url_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtTarget.TextChanged, txtIPAddress.TextChanged
        txtURL.Text = ("http://" _
                    + (txtIPAddress.Text + ("/" + txtTarget.Text)))
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
        SetTextToTextBox(txtJSON, rawData)
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
            If ((txtPatchData.Visible = True) AndAlso (txtPatchData.Text.Length > 0)) Then
                Dim data As String = txtPatchData.Text
                m_httpRequest.SendPATCHRequest(account, password, URL, data)
            Else
                m_httpRequest.SendGETRequest(account, password, URL)
            End If
        Catch err As Exception
            txtJSON.Text = err.ToString
        End Try
    End Sub

    Private Sub comboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles comboBox1.SelectedIndexChanged
        Dim cmb As ComboBox = CType(sender, ComboBox)
        Dim method As String = CType(cmb.SelectedItem, String)
        If method = "PATCH" Then
            label4.Visible = True
            txtPatchData.Visible = True
        Else
            label4.Visible = False
            txtPatchData.Visible = False
        End If

    End Sub
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
        End Try
    End Sub
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