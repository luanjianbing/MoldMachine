Imports Advantech.Adam
Imports Advantech.Common
Imports System.Windows.Forms



Public Class Form_APAX_IO

    Public APAX_INFO_NAME As String = "APAX"
    Public DVICE_TYPE As String = "50XX"
    Dim m_adamCtl As AdamControl 'Control Handle
    Dim m_aConf As Apax5000Config 'Configuration information
    Dim m_iSlot_ID As Integer
    Dim m_ScanTime_LocalSys() As Integer
    Dim szSlots() As String = {""} 'Container of all solt device typ
    Dim m_iDIChannelNum As Integer
    Dim m_iDOChannelNum As Integer
    Dim m_iAIChannelNum As Integer
    Dim m_iAOChannelNum As Integer

    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub
    Public Sub New(ByVal strDevice As String, ByVal iScanTime_LocalSys As Byte)
        MyBase.New()

        InitializeComponent()
        DVICE_TYPE = strDevice
        m_ScanTime_LocalSys = New Integer((1) - 1) {}
        m_ScanTime_LocalSys(0) = iScanTime_LocalSys

    End Sub

    Private Sub Btn_Quit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Close()
    End Sub


    Private Sub Btn_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try

            If OpenDevice() = False Then
                Throw New System.Exception("Open Device Fail.")
            End If

            If DeviceFind() = False Then
                Throw New System.Exception("Find Device Fail.")
            End If

            If RefreshConfiguration() = False Then
                Throw New System.Exception("Get Device Configuration Fail.")
            End If

        Catch ex As Exception
            MessageBox.Show("Open local driver failed!", "Error")
        End Try

        Me.Panel_Info.Enabled = True
        Me.Panel_Info.Visible = True
        Me.panel_Remote.Enabled = True
        Me.panel_Remote.Visible = True

    End Sub

    Public Overridable Function OpenDevice() As Boolean
        MessageBox.Show("APAXIOModule OpenDevice")
    End Function

    Public Overridable Function DeviceFind() As Boolean
        MessageBox.Show("APAXIOModule DeviceFind")
        Return True
    End Function

    Public Overridable Function RefreshConfiguration() As Boolean
        MessageBox.Show("APAXIOModule RefreshConfiguration")
        Return True
    End Function

    Public Overridable Function FreeResource() As Boolean
        Return True
    End Function

    Private Sub btn_Locate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MessageBox.Show("APAXIOModule Locate")
    End Sub

    Private Sub Form_APAX_IO_Closing(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)

        FreeResource()

    End Sub

    Public Overridable Function GetChannelInfo() As Boolean
        MessageBox.Show("APAXIOModule GetChannelInfo")
        Return True
    End Function

End Class
