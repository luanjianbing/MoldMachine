Imports System.Text
Imports System.Collections
Imports Advantech.Adam

Public Class Form1
    Private adamGCL_IOMsg As AdamGCL_IOMsg

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        adamGCL_IOMsg = New AdamGCL_IOMsg()
        AddHandler adamGCL_IOMsg.GetDataEvent, New GetDataCallback(AddressOf Me.OnGetData)
    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click

        If (btnStart.Text = "Start") Then

            adamGCL_IOMsg.Start_Server()
            btnStart.Text = "Stop"
            Dim strNowTime As String = DateTime.Now.ToString("hh:mm:ss:fff")
            Me.listBoxMsg.Items.Add(strNowTime)
            Me.listBoxMsg.Items.Add("Start listening... ")
            Me.listBoxMsg.Items.Add("")

        Else

            adamGCL_IOMsg.Stop_Server()
            btnStart.Text = "Start"

        End If

    End Sub

    Private Sub Form1_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed

        If (adamGCL_IOMsg.IsServerStart) Then
            adamGCL_IOMsg.Stop_Server()
        End If

        adamGCL_IOMsg = Nothing

    End Sub

    Private Sub OnGetData(ByVal config As GCL_IOMsg_Config)

        If (InvokeRequired) Then
            BeginInvoke(New GetDataCallback(AddressOf OnGetData), New Object() {config})
            Return
        End If

        RefreshListView(config)

    End Sub

    Private Sub RefreshListView(ByVal config As GCL_IOMsg_Config)
        Dim i As Integer
        Dim strTemp As String
        Dim strMsg As String
        Dim strList As ArrayList = New ArrayList()
        Dim byAI(), byAO(), byDI(), byDO(), byCnt(), byMsg() As Byte
        Dim dt As DateTime = DateTime.Now
        Dim iDataSize, iResolution As Integer

        'History
        Dim ipStr As String = String.Format("{0}.{1}.{2}.{3}", config.IP(0), config.IP(1), config.IP(2), config.IP(3))
        Dim timeStr As String = dt.Hour.ToString() + ":" + dt.Minute.ToString() + ":" + dt.Second.ToString()
        strTemp = "At " + timeStr + "   IP:" + ipStr + "   SeqNum:" + config.SeqNum.ToString() + "   RuleIdx:" + config.RuleIndex.ToString() + "   OutIdx:" + config.OutputIndex.ToString() + "   OperationVal:" + config.OperationVal.ToString()
        listBoxMsg.Items.Add(strTemp)
        listBoxMsg.SelectedIndex = listBoxMsg.Items.Count - 1
        '/////////////////////////////

        'IO data
        'AI
        If (adamGCL_IOMsg.GetData_AI(config, byAI)) Then

            If (byAI.Length > 0) Then

                iResolution = config.NumBitsAI
                iDataSize = CInt(iResolution \ 8)
                If ((iResolution Mod 8) > 0) Then
                    iDataSize = iDataSize + 1
                End If

                strList.Add("AI:")
                strTemp = ""

                For i = 0 To (byAI.Length - 1)
                    If ((i Mod iDataSize) = 0) Then

                        If ((i <> 0) AndAlso (i <> byAI.Length - 1)) Then
                            strTemp = strTemp + " , "
                        End If

                        strTemp = strTemp + "0x" + byAI(i).ToString("X02")

                    Else
                        strTemp = strTemp + byAI(i).ToString("X02")
                    End If
                Next

                strList.Add(strTemp)
                strList.Add("")

            End If

        End If

        'AO
        If (adamGCL_IOMsg.GetData_AO(config, byAO)) Then

            If (byAO.Length > 0) Then

                iResolution = config.NumBitsAO
                iDataSize = CInt(iResolution \ 8)
                If ((iResolution Mod 8) > 0) Then
                    iDataSize = iDataSize + 1
                End If

                strList.Add("AO:")
                strTemp = ""

                For i = 0 To (byAO.Length - 1)
                    If ((i Mod iDataSize) = 0) Then

                        If ((i <> 0) AndAlso (i <> byAO.Length - 1)) Then
                            strTemp = strTemp + " , "
                        End If

                        strTemp = strTemp + "0x" + byAO(i).ToString("X02")

                    Else
                        strTemp = strTemp + byAO(i).ToString("X02")
                    End If
                Next

                strList.Add(strTemp)
                strList.Add("")

            End If

        End If

        'DI
        If (adamGCL_IOMsg.GetData_DI(config, byDI)) Then

            If (byDI.Length > 0) Then

                strList.Add("DI:")
                strTemp = "0x"

                For i = 0 To (byDI.Length - 1)
                    strTemp = strTemp + byDI(i).ToString("X02")
                Next

                strList.Add(strTemp)
                strList.Add("")

            End If

        End If

        'DO
        If (adamGCL_IOMsg.GetData_DO(config, byDO)) Then

            If (byDO.Length > 0) Then

                strList.Add("DO:")
                strTemp = "0x"

                For i = 0 To (byDO.Length - 1)
                    strTemp = strTemp + byDO(i).ToString("X02")
                Next

                strList.Add(strTemp)
                strList.Add("")

            End If

        End If

        'Cnt
        If (adamGCL_IOMsg.GetData_Cnt(config, byCnt)) Then

            If (byCnt.Length > 0) Then

                iResolution = config.NumBitsCnt
                iDataSize = CInt(iResolution \ 8)
                If ((iResolution Mod 8) > 0) Then
                    iDataSize = iDataSize + 1
                End If

                strList.Add("Cnt:")
                strTemp = ""

                For i = 0 To (byCnt.Length - 1)
                    If ((i Mod iDataSize) = 0) Then

                        If ((i <> 0) AndAlso (i <> byCnt.Length - 1)) Then
                            strTemp = strTemp + " , "
                        End If

                        strTemp = strTemp + "0x" + byCnt(i).ToString("X02")

                    Else
                        strTemp = strTemp + byCnt(i).ToString("X02")
                    End If
                Next

                strList.Add(strTemp)

            End If

        End If

        Dim strArray() As String = CType(strList.ToArray(GetType(String)), String())
        '/////////////////////////////

        'Message
        adamGCL_IOMsg.GetMessage(config, byMsg)
        strMsg = Encoding.ASCII.GetString(byMsg)
        '/////////////////////////////

        Me.txtIOData.Lines = strArray
        txtMsg.Text = strMsg

    End Sub

End Class
