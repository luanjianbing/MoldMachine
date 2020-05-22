Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Public Class FormSafetySetting
    Public Delegate Sub EventHandler_ApplySafetyValueClick(ByVal szVal() As String)
    Public Event ApplySafetyValueClick As EventHandler_ApplySafetyValueClick
    Private m_iChannelTotal As Integer
    Private m_fVal() As Single
    Private m_szRange() As String

    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal iChannelTotal As Integer, ByRef fVal() As Single, ByRef szRange() As String)
        MyBase.New()
        Dim lvItem As ListViewItem
        InitializeComponent()
        m_iChannelTotal = iChannelTotal
        m_fVal = fVal
        m_szRange = szRange
        ' Set init information
        Dim i As Integer = 0
        Do While (i < iChannelTotal)
            lvItem = New ListViewItem(i.ToString)
            lvItem.SubItems.Add(fVal(i).ToString)
            gridviewSafety.Items.Add(lvItem)
            i = (i + 1)
        Loop
    End Sub
   
    Private Sub gridviewSafety_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gridviewSafety.SelectedIndexChanged
        Dim i As Integer = 0
        Do While (i < gridviewSafety.SelectedIndices.Count)
            If gridviewSafety.Items(gridviewSafety.SelectedIndices(i)).Selected Then
                Dim iSelectedItem As Integer = gridviewSafety.SelectedIndices(i)
                txtChannel.Text = gridviewSafety.Items(iSelectedItem).Text
                txtSafetyVal.Text = gridviewSafety.Items(iSelectedItem).SubItems(1).Text
                labRange.Text = m_szRange(iSelectedItem)
                Return
            End If
            i = (i + 1)
        Loop
    End Sub

    Private Sub btnSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSet.Click
        Dim i As Integer = 0
        Do While (i < gridviewSafety.SelectedIndices.Count)
            If gridviewSafety.Items(gridviewSafety.SelectedIndices(i)).Selected Then
                Dim iSelectedItem As Integer = gridviewSafety.SelectedIndices(i)
                gridviewSafety.Items(iSelectedItem).SubItems(1).Text = txtSafetyVal.Text
                Return
            End If
            i = (i + 1)
        Loop
    End Sub

    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        Try
            Dim o_szVal() As String = New String((m_iChannelTotal) - 1) {}
            Dim i As Integer = 0
            Do While (i < m_iChannelTotal)
                o_szVal(i) = Convert.ToString(gridviewSafety.Items(i).SubItems(1).Text)
                i = (i + 1)
            Loop
            RaiseEvent ApplySafetyValueClick(o_szVal)

        Catch ex As Exception
            MessageBox.Show("Setting Safety Fail", "Error")
        End Try

    End Sub
End Class