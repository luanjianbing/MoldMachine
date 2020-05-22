
Class FormSafetySetting
    Public Delegate Sub EventHandler_ApplySafetyValueClick(ByVal bVal() As Boolean)
    Public Event ApplySafetyValueClick As EventHandler_ApplySafetyValueClick
    Private m_iChannelTotal As Integer

    Private m_bVal() As Boolean

    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal iChannelTotal As Integer, ByVal bVal() As Boolean)
        MyBase.New()
        InitializeComponent()
        m_iChannelTotal = iChannelTotal
        m_bVal = bVal
        ' Set init information
        Dim i As Integer = 0
        Do While (i < iChannelTotal)
            Dim lvItem As ListViewItem = New ListViewItem(i.ToString)
            lvItem.SubItems.Add(bVal(i).ToString)
            gridviewSafety.Items.Add(lvItem)
            i = (i + 1)
        Loop
    End Sub
 
    ''' <summary>
    ''' Apply setting when user configure safety status
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>


    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click

        Dim o_szVal() As String = New String((m_iChannelTotal) - 1) {}
        Dim o_bVal() As Boolean = New Boolean((m_iChannelTotal) - 1) {}
        Dim i As Integer = 0

        Do While (i < m_iChannelTotal)
            If (gridviewSafety.Items(i).SubItems(1).Text = "True") Then
                o_bVal(i) = True
            Else
                o_bVal(i) = False
            End If
            i = (i + 1)
        Loop

        Try

            RaiseEvent ApplySafetyValueClick(o_bVal)

        Catch ex As Exception
            MessageBox.Show("Delegate function fail.", "Error")
        End Try

        Close()

    End Sub
  

    Private Sub btnSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSet.Click
        If chbxSelecteAll.Checked Then

            Dim idx As Integer = 0
            Do While (idx < m_iChannelTotal)
                If rdbtnOn.Checked Then
                    gridviewSafety.Items(idx).SubItems(1).Text = "True"
                Else
                    gridviewSafety.Items(idx).SubItems(1).Text = "False"
                End If
                idx = (idx + 1)
            Loop
            Return
        End If

        Dim i As Integer = 0
        Do While (i < gridviewSafety.SelectedIndices.Count)
            If gridviewSafety.Items(gridviewSafety.SelectedIndices(i)).Selected Then
                Dim iSelectedItem As Integer = gridviewSafety.SelectedIndices(i)
                If rdbtnOn.Checked Then
                    gridviewSafety.Items(iSelectedItem).SubItems(1).Text = "True"
                Else
                    gridviewSafety.Items(iSelectedItem).SubItems(1).Text = "False"
                End If
                Return
            End If
            i = (i + 1)
        Loop
    End Sub

    Private Sub gridviewSafety_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridviewSafety.SelectedIndexChanged
        Dim i As Integer = 0

        Do While (i < gridviewSafety.SelectedIndices.Count)
            If gridviewSafety.Items(gridviewSafety.SelectedIndices(i)).Selected Then
                Dim iSelectedItem As Integer = gridviewSafety.SelectedIndices(i)
                txtChannel.Text = gridviewSafety.Items(iSelectedItem).Text
                If Convert.ToBoolean(gridviewSafety.Items(iSelectedItem).SubItems(1).Text) Then
                    rdbtnOn.Checked = True
                Else
                    rdbtnOff.Checked = True
                End If
                Return
            End If
            i = (i + 1)
        Loop
    End Sub
End Class