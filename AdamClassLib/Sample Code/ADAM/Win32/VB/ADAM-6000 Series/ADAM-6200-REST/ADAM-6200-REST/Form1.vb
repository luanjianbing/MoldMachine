Imports System.Data
Imports System.Text
Imports System.Net
Imports System.IO

Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtURL.Text = "http://" + txtIPAddress.Text + "/" + txtTarget.Text
    End Sub

    Private Sub url_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIPAddress.TextChanged, txtTarget.TextChanged
        txtURL.Text = "http://" + txtIPAddress.Text + "/" + txtTarget.Text
    End Sub

    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        Try
            If (txtPostData.Text.Length > 0) Then ' POST
                SendPOSTRequest()
            Else
                SendGETRequest()
            End If
        Catch err As Exception
            txtXML.Text = err.ToString()
        End Try
    End Sub

    Private Sub SendPOSTRequest()
        Dim byData() As Byte
        Dim szResponse As String
        Dim outputStream, responseStream As System.IO.Stream
        Dim reader As System.IO.StreamReader
        Dim myRequest As HttpWebRequest
        Dim myResponse As HttpWebResponse

        myRequest = WebRequest.Create(txtURL.Text) 'create request
        byData = Encoding.ASCII.GetBytes(txtPostData.Text) 'convert POST data to bytes
        myRequest.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(txtAcount.Text + ":" + txtPassword.Text)))
        myRequest.Method = "POST"
        myRequest.KeepAlive = False
        myRequest.ContentType = "application/x-www-form-urlencoded"
        myRequest.ContentLength = byData.Length
        ' send data
        outputStream = myRequest.GetRequestStream()
        outputStream.Write(byData, 0, byData.Length)
        outputStream.Close()
        ' try to receive
        myResponse = myRequest.GetResponse()
        responseStream = myResponse.GetResponseStream()
        reader = New System.IO.StreamReader(responseStream, Encoding.ASCII)
        szResponse = reader.ReadToEnd()
        txtXML.Text = szResponse
    End Sub

    Private Sub SendGETRequest()
        Dim szResponse As String
        Dim responseStream As System.IO.Stream
        Dim reader As System.IO.StreamReader
        Dim myRequest As HttpWebRequest
        Dim myResponse As HttpWebResponse

        myRequest = WebRequest.Create(txtURL.Text)
        myRequest.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(txtAcount.Text + ":" + txtPassword.Text)))
        myRequest.Method = "GET"
        myRequest.KeepAlive = False
        myRequest.ContentType = "application/x-www-form-urlencoded"
        ' try to receive
        myResponse = myRequest.GetResponse()
        responseStream = myResponse.GetResponseStream()
        reader = New System.IO.StreamReader(responseStream, Encoding.ASCII)
        szResponse = reader.ReadToEnd()
        txtXML.Text = szResponse
    End Sub

    Private Sub btnConvert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConvert.Click
        If (txtXML.Text.Length > 0) Then
            Try
                Dim dataSet1 As DataSet
                Dim theReader As System.IO.StreamReader
                Dim byteArray() As Byte = Encoding.ASCII.GetBytes(txtXML.Text)
                Dim stream As MemoryStream = New MemoryStream(byteArray)

                theReader = New System.IO.StreamReader(stream)
                dataSet1 = New DataSet()
                dataSet1.ReadXml(theReader)
                ''
                dataGridView1.AutoGenerateColumns = True
                dataGridView1.DataSource = dataSet1 ' dataset
                dataGridView1.DataMember = dataSet1.Tables(1).TableName

            Catch
            End Try
        End If
    End Sub

End Class
