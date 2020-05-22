Imports Advantech.Adam

Public Class Form1
    Private adamP2P As AdamP2P

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        adamP2P = New AdamP2P()
        AddHandler adamP2P.GetDataEvent, New GetP2PDataCallback(AddressOf OnGetData)
        txtPort.Text = adamP2P.P2P_Port.ToString()
    End Sub

    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        If (btnStart.Text = "Start") Then
            If (adamP2P.Start_P2P_Server() = False) Then
                MessageBox.Show("Failed to start Peer to Peer server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            btnStart.Text = "Stop"

            Dim strNowTime As String
            strNowTime = DateTime.Now.ToString("hh:mm:ss:fff")
            listBoxHistory.Items.Add(strNowTime)
            listBoxHistory.Items.Add("Start listening... ")
            listBoxHistory.Items.Add("")
        Else
            adamP2P.Stop_P2P_Server()
            btnStart.Text = "Start"
            listViewInfo.Items.Clear()
        End If
    End Sub

    Private Sub OnGetData(ByVal config As P2P_Config)
        If (InvokeRequired) Then
            BeginInvoke(New GetP2PDataCallback(AddressOf OnGetData), New Object() {config})
            Return
        End If

        txtRecvNum.Text = adamP2P.P2P_PackageNum.ToString()
        RefreshListView(config)
    End Sub

    Private Sub Form1_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        adamP2P.Stop_P2P_Server()
    End Sub

    Private Sub RefreshListView(ByVal p2p_Config As P2P_Config)
        Dim i As Integer
        Dim bIsValid As Boolean
        Dim iCnt As Integer
        Dim idxData As Integer
        Dim idxDataPos As Integer
        Dim bData As Boolean                'For Coils
        Dim bDataChanged As Boolean   'For Coils
        Dim iData As Integer                    'For Registers
        Dim strTemp As String
        iCnt = 0

        listViewInfo.BeginUpdate()
        listViewInfo.Items.Clear()

        For i = 0 To (p2p_Config.NoChannels - 1)
            bIsValid = (((p2p_Config.ChannelMask >> i) And 1) > 0)

            If (bIsValid) Then
                txtFuncCode.Text = p2p_Config.FunCode.ToString()

                If (p2p_Config.FunCode = CByte(P2P_FunctionCode.DIO_BASIC_MODE)) Then
                    'DIO
                    listViewInfo.Items.Add(i.ToString())

                    idxData = i \ 8
                    idxDataPos = i Mod 8

                    bData = (((p2p_Config.Data(idxData) >> idxDataPos) And 1) > 0)
                    bDataChanged = (((p2p_Config.COS_Flag(idxData) >> idxDataPos) And 1) > 0)

                    listViewInfo.Items(iCnt).SubItems.Add(bData.ToString())
                    listViewInfo.Items(iCnt).SubItems.Add(bDataChanged.ToString())
                    iCnt = iCnt + 1

                ElseIf (p2p_Config.FunCode = CByte(P2P_FunctionCode.DIO_ADV_MODE)) Then
                    'DIO
                    listViewInfo.Items.Add("Advanced DO")

                    bData = (p2p_Config.Data(0) = 255)

                    listViewInfo.Items(iCnt).SubItems.Add(bData.ToString())
                    listViewInfo.Items(iCnt).SubItems.Add("*****")
                    iCnt = iCnt + 1

                ElseIf (p2p_Config.FunCode = CByte(P2P_FunctionCode.AIO_MODE)) Then
                    'AIO
                    If (p2p_Config.P2PMode = CByte(P2P_Mode.Advanced)) Then
                        listViewInfo.Items.Add("Advanced AI")
                    Else
                        listViewInfo.Items.Add(i.ToString())
                    End If

                    iData = (p2p_Config.Data(i * 2) << 8)
                    iData = (iData Or (p2p_Config.Data(i * 2 + 1)))

                    listViewInfo.Items(iCnt).SubItems.Add(iData.ToString())
                    listViewInfo.Items(iCnt).SubItems.Add("*****")
                    iCnt = iCnt + 1

                End If
            End If
        Next i

        listViewInfo.EndUpdate()

        '///////////////////////////////////////////////////////////////////////////////////
        Dim strNowTime As String
        strNowTime = DateTime.Now.ToString("hh:mm:ss:fff")
        listBoxHistory.BeginUpdate()
        listBoxHistory.Items.Add(strNowTime)
        listBoxHistory.Items.Add("PackageNum: " + p2p_Config.PackageNum.ToString())
        listBoxHistory.Items.Add("FuncCode: 0x" + p2p_Config.FunCode.ToString("X02"))
        listBoxHistory.Items.Add("ChannelMask: 0x" + p2p_Config.ChannelMask.ToString("X08"))

        If (p2p_Config.FunCode = CByte(P2P_FunctionCode.DIO_BASIC_MODE)) Then
            bDataChanged = False
            For i = 0 To (p2p_Config.COS_Flag.Length - 3)
                If (p2p_Config.COS_Flag(i) > 0) Then
                    bDataChanged = True
                    Exit For
                End If
            Next i

            If (bDataChanged) Then
                listBoxHistory.Items.Add("Packet Type: C.O.S.")
            Else
                listBoxHistory.Items.Add("Packet Type: Period")
            End If
        End If

        strTemp = ""
        listBoxHistory.Items.Add("Data: ")
        For i = 0 To (p2p_Config.Data.Length - 1)
            strTemp = strTemp + "0x" + p2p_Config.Data(i).ToString("X02")
            If (i <> (p2p_Config.Data.Length - 1)) Then
                strTemp = strTemp + ", "
            End If

            If (i = 7) Then
                listBoxHistory.Items.Add(strTemp)
                strTemp = ""
            End If
        Next i

        listBoxHistory.Items.Add(strTemp)
        listBoxHistory.Items.Add("")
        listBoxHistory.SelectedIndex = listBoxHistory.Items.Count - 1
        listBoxHistory.EndUpdate()
    End Sub

End Class
