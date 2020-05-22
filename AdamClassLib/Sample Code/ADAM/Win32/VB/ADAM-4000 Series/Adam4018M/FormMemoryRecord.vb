Imports System.Collections
Imports System.ComponentModel
Imports Advantech.Adam

Public Class FormMemoryRecord
    Private adamCom As AdamCom
    Private m_iAddr As Integer, m_iIndex As Integer, m_iMax As Integer, m_iCount As Integer
    Private m_listView As ListView

    Public Sub FormMemoryRecord_Initial(ByRef i_adamCom As AdamCom, ByRef listView As ListView, ByVal i_iAddr As Integer, ByVal i_szTitle As String, ByVal i_ParentWidth As Integer, ByVal i_ParentHeight As Integer)
        Location = New Point((i_ParentWidth - Width) / 2, (i_ParentHeight - Height) / 2)
        adamCom = i_adamCom
        m_iAddr = i_iAddr
        Text = i_szTitle
        m_listView = listView
    End Sub

    Private Sub FormMemoryRecord_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        timer1.Enabled = False
        m_listView.EndUpdate()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim iCh As Integer, iIdx As Integer
        Dim fData As Single
        Dim lElapse As Long

        Timer1.Enabled = False
        If (m_iCount < m_iMax) Then
            iIdx = m_iIndex + m_iCount
            If (adamCom.AnalogInput(m_iAddr).GetMemRecordData(iIdx, iCh, fData, lElapse) = True) Then
                m_listView.Items.Add(New ListViewItem(iIdx.ToString("0000")))
                m_listView.Items(m_iCount).SubItems.Add(iCh.ToString())
                m_listView.Items(m_iCount).SubItems.Add(fData.ToString())
                m_listView.Items(m_iCount).SubItems.Add(lElapse.ToString())
                m_iCount = m_iCount + 1
                progressBar1.Value = m_iCount * 100 / m_iMax
                Timer1.Enabled = True
            Else
                MessageBox.Show("Get record failed!", "Error")
                Close()
            End If
        Else
            MessageBox.Show("Get record done!", "Information")
            Close()
        End If
    End Sub

    Private Sub btnGetRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetRecord.Click
        btnGetRecord.Enabled = False
        m_iIndex = Convert.ToInt32(numericUpDown1.Value)
        m_iMax = Convert.ToInt32(numericUpDown2.Value)
        m_iCount = 0
        m_listView.Items.Clear()
        m_listView.BeginUpdate()
        Timer1.Enabled = True
    End Sub
End Class