Imports System.Data
Imports System.Text
Imports System.Net
Imports System.IO

Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtURL.Text = "http://" + txtIPAddress.Text + "/" + txtTarget.Text
    End Sub
    Private Sub url_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTarget.TextChanged, txtIPAddress.TextChanged
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
                listView1.Columns.Clear()
                listView1.Items.Clear()
                FillListView(dataSet1)
            Catch
            End Try
        End If
    End Sub

    Private Sub FillListView(ByVal dataSet As DataSet)
        For Each c As DataColumn In dataSet.Tables(1).Columns
            'adding names of columns as Listview columns
            Dim h As ColumnHeader = New ColumnHeader()
            h.Text = c.ColumnName
            listView1.Columns.Add(h)
        Next

        Dim dt As DataTable = dataSet.Tables(1)
        Dim str(dataSet.Tables(1).Columns.Count) As String
        'adding Datarows as listview Grids
        For Each rr As DataRow In dt.Rows
            Dim col As Int32
            For col = 0 To (dataSet.Tables(1).Columns.Count - 1)
                str(col) = rr(col).ToString()
            Next
            Dim ii As ListViewItem
            ii = New ListViewItem(str)
            listView1.Items.Add(ii)
        Next
    End Sub
End Class
