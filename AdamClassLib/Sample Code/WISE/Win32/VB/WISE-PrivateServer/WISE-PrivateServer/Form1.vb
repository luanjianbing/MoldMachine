Imports System.Net
Imports System.Text
Imports System.Threading
Imports System.IO
Imports System.Windows.Forms
Imports System.Text.RegularExpressions

Public Class Form1
    Public Const HTTP_Prefix As String = "http://*:8000/" 'Waiting for HTTP request on port 8000
    Public Const HTTPS_Prefix As String = "https://*:8080/" 'Waiting for HTTP request on port 8000
    Public Const Url_File_UploadLog_Token As String = "upload_log"
    Public Const Url_Json_IoLog_Token As String = "io_log"
    Public Const Url_Json_SysLog_Token As String = "sys_log"
    Public Const DataType_Csv_File As String = "CSV File"
    Public Const DataType_Json_Str As String = "JSON String"
    Public Const Slash_Str_Token As String = "/"
    Public Const BackSlash_Str_Token As String = "\"
    Public Const Max_Rows_Val As Integer = 1000
    Public Shared m_HttpListener As HttpListener
    Private httpRequestThread As Thread
    Private _runState As Long = State.Stopped
    Private bScrollToBottom As Boolean = False

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        For Each column As DataGridViewColumn In dataGridView1.Columns
            column.SortMode = DataGridViewColumnSortMode.NotSortable
        Next

        dataGridView1.Rows.Clear()

    End Sub
    Public Enum State
        Stopped
        Stopping
        Starting
        Started
    End Enum

    Public ReadOnly Property RunState() As State
        Get
            Return Interlocked.Read(_runState)
        End Get
    End Property

    Delegate Sub DataGridViewCtrlAddDataRowInvoke(ByVal i_Row As DataGridViewRow)
    Private Sub DataGridViewCtrlAddDataRow(ByVal i_Row As DataGridViewRow)
        If dataGridView1.InvokeRequired Then
            Dim d As New DataGridViewCtrlAddDataRowInvoke(AddressOf Me.DataGridViewCtrlAddDataRow)
            dataGridView1.Invoke(d, New Object() {i_Row})
        Else
            dataGridView1.Rows.Add(i_Row)
            If bScrollToBottom Then
                'Scroll to bottom
                dataGridView1.FirstDisplayedScrollingRowIndex = dataGridView1.RowCount - 1
            End If
            If dataGridView1.Rows.Count > Max_Rows_Val Then
                dataGridView1.Rows.Clear()
            End If
            dataGridView1.Update()
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            m_HttpListener = New HttpListener()

            Try

                m_HttpListener.Prefixes.Add(HTTP_Prefix)
                m_HttpListener.Prefixes.Add(HTTPS_Prefix)

            Catch ex As Exception
                MessageBox.Show("Err : " + ex.ToString(), "Error")
            End Try

            Try

                m_HttpListener.AuthenticationSchemes = AuthenticationSchemes.Anonymous
                httpRequestThread = New Thread(New ThreadStart(AddressOf StartListen))
                httpRequestThread.IsBackground = True
                httpRequestThread.Start()

            Catch exe As Exception
                MessageBox.Show("Err : " + exe.ToString(), "Error")
            End Try

        Catch eee As Exception
            MessageBox.Show("Err : " + eee.ToString(), "Error")
        End Try
    End Sub

    Private Sub StartListen()
        Interlocked.Exchange(Me._runState, State.Starting)
        Try

            If (Not m_HttpListener.IsListening) Then
                Try
                    m_HttpListener.Start()
                Catch ex As Exception
                    MessageBox.Show("Error:\n TCP port listen failed.\n Please make sure:\n(1) Port is not used.\n(2) Firewall is not blocked.\n(3) Use Administrator to run this program.\n\nDetail Information:\n" + ex.ToString())
                End Try
            End If

            If (m_HttpListener.IsListening) Then
                Interlocked.Exchange(Me._runState, State.Started)
            End If

            Try
                While (RunState = State.Started)
                    Dim context As HttpListenerContext = m_HttpListener.GetContext()
                    IncomingHttpRequest(context)
                End While
            Catch ex As HttpListenerException
                Interlocked.Exchange(Me._runState, State.Stopped)
            End Try

        Finally
            Interlocked.Exchange(Me._runState, State.Stopped)
        End Try
    End Sub

    Private Sub StopListen()
        'Interlocked.Exchange(Me._runState, State.Stopping)

        If (m_HttpListener.IsListening) Then
            m_HttpListener.Stop()
            Interlocked.Exchange(Me._runState, State.Stopping)
        End If

        If Not IsNothing(httpRequestThread) And httpRequestThread.IsAlive Then
            httpRequestThread.Join(1000) 'block main thread and wait max 2 seconds for http thread terminate
            httpRequestThread.Abort()
        End If

        'Dim waitTime As Long = DateTime.Now.Ticks + TimeSpan.TicksPerSecond * 20
        'While (Me.RunState <> State.Stopped)
        '    Thread.Sleep(1000)
        '    If (DateTime.Now.Ticks > waitTime) Then
        '        Throw New TimeoutException("Unable to stop the web server process.")
        '    End If
        'End While

        httpRequestThread = Nothing
    End Sub

    Private Function GetUniqueFileName(ByVal logFilePath As String) As String
        While (True)
            If File.Exists(logFilePath) Then
                'file already exists, create new file name
                Dim extensionName As String = Path.GetExtension(logFilePath)
                Dim fileName As String = Path.GetFileNameWithoutExtension(logFilePath)
                Dim dirName As String = Path.GetDirectoryName(logFilePath)
                If fileName.IndexOf(" ") = -1 Then
                    'ex: 20151125111821
                    fileName = fileName + " (1)" + extensionName
                Else
                    'ex: 20151125111821 (1)
                    Dim pattern As String = "(\S+)\ \((\d+)\)"
                    'Instantiate the regular expression object.
                    Dim r As New Regex(pattern, RegexOptions.IgnoreCase)
                    'Match the regular expression pattern against a text string.
                    Dim m As Match = r.Match(fileName)
                    If m.Success Then
                        Dim match1 As String = m.Groups(1).ToString()
                        Dim match2 As String = m.Groups(2).ToString()
                        Dim tmp As Integer = Integer.Parse(match2) + 1
                        fileName = match1 + " (" + tmp.ToString() + ")" + extensionName
                    Else
                        'match failed, append a random number to file name
                        Dim rnd As Random = New Random()
                        Dim tmp As Integer = rnd.Next(1, 1000)
                        fileName = fileName + "_" + tmp + extensionName
                    End If
                End If
                logFilePath = Path.Combine(dirName, fileName)
            Else
                'file not exist
                Return logFilePath
            End If
        End While
    End Function

    Private Sub IncomingHttpRequest(ByVal context As HttpListenerContext)
        Dim response As HttpListenerResponse = context.Response
        'Dim data_text = New StreamReader(context.Request.InputStream, context.Request.ContentEncoding).ReadToEnd()
        'Dim receive_data = System.Web.HttpUtility.UrlDecode(data_text)
        Dim receive_data = New StreamReader(context.Request.InputStream, context.Request.ContentEncoding).ReadToEnd()

        If (context.Request.Url.AbsolutePath.Contains(Url_File_UploadLog_Token)) Then

            Dim szFileName As String = String.Empty
            Dim szList As New List(Of String)()
            szList = New List(Of String)(context.Request.Url.AbsolutePath.Split("/"))

            For Each subValue As String In szList

                If (subValue.Contains(".csv")) Then
                    szFileName = context.Request.Url.AbsolutePath.Replace(Slash_Str_Token, BackSlash_Str_Token)
                    szFileName = szFileName.Substring(BackSlash_Str_Token.Length, (szFileName.Length - BackSlash_Str_Token.Length))
                    szFileName = GetUniqueFileName(szFileName)
                    Dim file As FileInfo = New FileInfo(szFileName)
                    file.Directory.Create()
                    System.IO.File.WriteAllText(file.FullName, receive_data)
                    Exit For
                End If

            Next
        End If

        Dim dgvRow As DataGridViewRow
        Dim dgvCell As DataGridViewCell
        dgvRow = New DataGridViewRow()

        dgvCell = New DataGridViewTextBoxCell() 'Column Time
        Dim dataTimeInfo = DateTime.Now.Year.ToString("D4") + "/" + _
                                       DateTime.Now.Month.ToString("D2") + "/" + _
                                       DateTime.Now.Day.ToString("D2") + " " + _
                                       DateTime.Now.Hour.ToString("D2") + ":" + _
                                       DateTime.Now.Minute.ToString("D2") + ":" + _
                                       DateTime.Now.Second.ToString("D2")

        dgvCell.Value = dataTimeInfo
        dgvRow.Cells.Add(dgvCell)

        dgvCell = New DataGridViewTextBoxCell() 'RemoteEndPoint
        dgvCell.Value = context.Request.RemoteEndPoint.ToString()
        dgvRow.Cells.Add(dgvCell)

        dgvCell = New DataGridViewTextBoxCell() 'Url Scheme
        dgvCell.Value = context.Request.Url.Scheme.ToString()
        dgvRow.Cells.Add(dgvCell)

        dgvCell = New DataGridViewTextBoxCell() 'HTTP Method
        dgvCell.Value = context.Request.HttpMethod
        dgvRow.Cells.Add(dgvCell)

        dgvCell = New DataGridViewTextBoxCell() 'Data Format
        If (context.Request.Url.AbsolutePath.Contains(Url_File_UploadLog_Token)) Then
            dgvCell.Value = DataType_Csv_File
        Else
            dgvCell.Value = DataType_Json_Str
        End If
        dgvRow.Cells.Add(dgvCell)

        dgvCell = New DataGridViewTextBoxCell() 'Request URL
        dgvCell.Value = context.Request.Url.ToString()
        dgvRow.Cells.Add(dgvCell)

        dgvRow.Tag = receive_data

        DataGridViewCtrlAddDataRow(dgvRow)

        response.StatusCode = 200
        response.StatusDescription = "OK"
        response.Close()
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        StopListen()
    End Sub

    Private Sub dataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dataGridView1.CellClick
        Dim iSelectedIdx As Integer = -1

        If ((e.RowIndex < dataGridView1.Rows.Count) AndAlso (e.RowIndex >= 0)) Then
            iSelectedIdx = e.RowIndex
            reviewDataRichTbx.Clear()
            reviewDataRichTbx.AppendText(dataGridView1.Rows(iSelectedIdx).Tag.ToString())
            'check if user click last row
            If ((dataGridView1.SelectedCells.Count <> 0) AndAlso (dataGridView1.CurrentCell.RowIndex = (dataGridView1.RowCount - 1))) Then
                bScrollToBottom = True
            Else
                bScrollToBottom = False
            End If
        End If
    End Sub
End Class
