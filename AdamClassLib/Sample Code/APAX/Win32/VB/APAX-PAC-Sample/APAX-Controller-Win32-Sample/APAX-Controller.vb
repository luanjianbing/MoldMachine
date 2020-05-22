Imports System.Data
Imports Advantech.Adam
Imports Advantech.Common
Imports System.Threading
Imports Apax_IO_Module_Library
Imports APAX_5060
Imports APAX_5060PE
Imports APAX_5046
Imports APAX_5046SO
Imports APAX_5045
Imports APAX_5040
Imports APAX_5040PE
Imports APAX_5080
Imports APAX_5082
Imports APAX_5013
Imports APAX_5017
Imports APAX_5017H
Imports APAX_5017PE
Imports APAX_5018
Imports APAX_5028


Public Class Form_APAX_Controller
    Dim m_adamCtl As AdamControl
    Dim iWaitFlag As Boolean = False
    Dim m_ScanTime_LocalSys() As Integer
    Dim m_aConf As Apax5000Config
    Dim m_idxID As Integer
    Dim m_iScanTime() As Integer = {0}
    Dim APAX_INFO_PRODUCT As String = "APAX-5000"
    Dim m_szSlotInfo() As String = Nothing

    Private Const APAX_5013_STR As String = "5013"
    Private Const APAX_5017_STR As String = "5017"
    Private Const APAX_5017H_STR As String = "5017H"
    Private Const APAX_5017PE_STR As String = "5017PE"
    Private Const APAX_5018_STR As String = "5018"
    Private Const APAX_5028_STR As String = "5028"
    Private Const APAX_5040_STR As String = "5040"
    Private Const APAX_5040PE_STR As String = "5040PE"
    Private Const APAX_5045_STR As String = "5045"
    Private Const APAX_5046_STR As String = "5046"
    Private Const APAX_5046SO_STR As String = "5046SO"
    Private Const APAX_5060_STR As String = "5060"
    Private Const APAX_5060PE_STR As String = "5060PE"
    Private Const APAX_5080_STR As String = "5080"
    Private Const APAX_5082_STR As String = "5082"

    Private ReadOnly APAX_COUPLER_SUPPORT_MODULE() _
                       As String = { _
                                            APAX_5013_STR, APAX_5017_STR, APAX_5017H_STR, APAX_5017PE_STR, APAX_5018_STR, _
                                            APAX_5028_STR, _
                                            APAX_5040_STR, APAX_5040PE_STR, APAX_5045_STR, _
                                            APAX_5046_STR, APAX_5046SO_STR, APAX_5060_STR, APAX_5060PE_STR, _
                                            APAX_5080_STR, APAX_5082_STR _
                                          }

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        m_iScanTime(0) = CType(NumericUpDown_SCAN.Value, Integer)
        m_idxID = 210
    End Sub
    Public Sub MenuItem_Exit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem_Exit.Click

        Close()

    End Sub

    Private Function IsApaxCouplerSupportModule(ByVal szModuleName As String) As Boolean
        Dim bRet As Boolean
        Dim intPos As Integer
        bRet = False

        intPos = Array.IndexOf(APAX_COUPLER_SUPPORT_MODULE, szModuleName)

        If (intPos > -1) Then
            bRet = True
        End If

        Return bRet
    End Function

    Private Sub ShowWaitMsg()

        iWaitFlag = True
        Dim FormWait As Wait_Form
        FormWait = New Wait_Form
        FormWait.Start_Wait()
        FormWait.ShowDialog()

    End Sub

    Private Sub CloseWaitMsg()

        iWaitFlag = False

    End Sub
    Private Sub AfterSelect_LocalDevice() ' Refresh I/O modules of this controller and show controller information

        Me.TreeView_MAIN.SelectedNode = Me.TreeView_MAIN.Nodes(0)
        Dim uiVer As UInteger
        Dim szTemp As String = ""
        Dim szVer As String = ""
        m_ScanTime_LocalSys = New Integer((1) - 1) {}
        m_ScanTime_LocalSys(0) = 500
        Dim waitThread As Thread = New Thread(AddressOf ShowWaitMsg)
        waitThread.IsBackground = False
        waitThread.Start()

        Try
            m_adamCtl = New AdamControl(AdamType.Apax5000)
            'Get APAX-Driver Version
            If m_adamCtl.Configuration.SYS_GetVersion(uiVer) Then
                szTemp = uiVer.ToString("X00000000")
                If (szTemp.Length >= 3) Then
                    szVer = szTemp.Insert((szTemp.Length - 2), ".")
                Else
                    szVer = szTemp
                End If
                Me.StatusBar_MAIN.Text = (" APAX-Driver Version:" _
                            + (szVer + "."))
            Else
                Me.StatusBar_MAIN.Text = (" Get APAX-Driver Version failed! Please upgrade the driver. ApiErr:" + m_adamCtl.Configuration.ApiLastError.ToString)
                MessageBox.Show("Please make sure latest APAX-Driver has been installed.")
                GoTo Quit
            End If


            If m_adamCtl.OpenDevice Then

                If Not m_adamCtl.Configuration.SYS_SetDspChannelFlag(False) Then
                    Me.StatusBar_MAIN.Text = "SYS_SetDspChannelFlag(false) Failed! "
                End If

                TreeView_MAIN.Nodes(0).Nodes.Clear()
                Me.TreeView_MAIN.BeginUpdate()

                If m_adamCtl.Configuration.GetSlotInfo(m_szSlotInfo) Then
                    Dim i As Integer = 0
                    Do While (i < m_szSlotInfo.Length)
                        If (m_szSlotInfo(i).Length > 0) Then
                            Dim tNode As TreeNode = New TreeNode((m_szSlotInfo(i).ToString + ("(S" _
                                            + (i.ToString + ")"))))
                            tNode.Tag = CType(i, Byte)
                            TreeView_MAIN.Nodes(0).Nodes.Add(tNode)
                        End If
                        i = (i + 1)
                    Loop
                End If

                TreeView_MAIN.Nodes(0).ExpandAll()
                Me.TreeView_MAIN.EndUpdate()

                If Not RefreshConfiguration() Then
                    MessageBox.Show("Get controller information failed!" + vbLf + "Please check the device!", "Error")
                End If

            End If
        Catch ex As Exception
            MessageBox.Show("Open local driver failed!", "Error")
        End Try

        GoTo Quit
Quit:
    End Sub
    Public Sub MenuItem_Refresh_Local_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem_Refresh_Local.Click

        AfterSelect_LocalDevice()

    End Sub

    Private Sub TreeView_MAIN_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView_MAIN.AfterSelect
        If (e.Node.FullPath.IndexOf("Local System") = 0) Then
            If (String.Compare(e.Node.Text, "Local System") = 0) Then
                Panel1.Visible = False
                AfterSelect_LocalDevice()
                Panel1.Visible = True

            Else
                AfterSelect_LocalSlot(e.Node)
            End If
        End If
    End Sub

    Private Sub AfterSelect_LocalSlot(ByVal e As TreeNode)
        Dim strSelectModuleId As String = String.Empty
        Dim iSlot As Integer
        Dim iCmpLength As Integer = 4
        Dim IO_Module As Form
        iSlot = Convert.ToInt32(e.Tag)
        strSelectModuleId = m_szSlotInfo(iSlot).ToUpper()

        If MsgBox("Do you want to demo APAX-" + e.Text + "?", MsgBoxStyle.YesNo, "Information") = MsgBoxResult.No Then
            Return
        End If

        If Not IsApaxCouplerSupportModule(strSelectModuleId) Then
            MessageBox.Show("Not support APAX" + e.Text + " module", "Error")
            Return
        End If

        If (String.Compare(e.Text, 0, "Local System", 0, (iCmpLength + 1)) = 0) Then
            Return
        End If

        If (strSelectModuleId = APAX_5013_STR) Then
            IO_Module = New Form_APAX_5013(iSlot, m_ScanTime_LocalSys(0))
        ElseIf (strSelectModuleId = APAX_5017_STR) Then
            IO_Module = New Form_APAX_5017(iSlot, m_ScanTime_LocalSys(0))
        ElseIf (strSelectModuleId = APAX_5017H_STR) Then
            IO_Module = New Form_APAX_5017H(iSlot, m_ScanTime_LocalSys(0))
        ElseIf (strSelectModuleId = APAX_5017PE_STR) Then
            IO_Module = New Form_APAX_5017PE(iSlot, m_ScanTime_LocalSys(0))
        ElseIf (strSelectModuleId = APAX_5018_STR) Then
            IO_Module = New Form_APAX_5018(iSlot, m_ScanTime_LocalSys(0))
        ElseIf (strSelectModuleId = APAX_5028_STR) Then
            IO_Module = New Form_APAX_5028(iSlot, m_ScanTime_LocalSys(0))
        ElseIf (strSelectModuleId = APAX_5040_STR) Then
            IO_Module = New Form_APAX_5040(iSlot, m_ScanTime_LocalSys(0))
        ElseIf (strSelectModuleId = APAX_5040PE_STR) Then
            IO_Module = New Form_APAX_5040PE(iSlot, m_ScanTime_LocalSys(0))
        ElseIf (strSelectModuleId = APAX_5045_STR) Then
            IO_Module = New Form_APAX_5045(iSlot, m_ScanTime_LocalSys(0))
        ElseIf (strSelectModuleId = APAX_5046_STR) Then
            IO_Module = New FORM_APAX_5046(iSlot, m_ScanTime_LocalSys(0))
        ElseIf (strSelectModuleId = APAX_5046SO_STR) Then
            IO_Module = New FORM_APAX_5046SO(iSlot, m_ScanTime_LocalSys(0))
        ElseIf (strSelectModuleId = APAX_5060_STR) Then
            IO_Module = New Form_APAX_5060(iSlot, m_ScanTime_LocalSys(0))
        ElseIf (strSelectModuleId = APAX_5060PE_STR) Then
            IO_Module = New Form_APAX_5060PE(iSlot, m_ScanTime_LocalSys(0))
        ElseIf (strSelectModuleId = APAX_5080_STR) Then
            IO_Module = New Form_APAX_5080(iSlot, m_ScanTime_LocalSys(0))
        ElseIf (strSelectModuleId = APAX_5082_STR) Then
            IO_Module = New Form_APAX_5082(iSlot, m_ScanTime_LocalSys(0))
        Else
            MessageBox.Show("Not support device APAX-" + e.Text, "Warn")
            Return
        End If

        IO_Module.ShowDialog()
        IO_Module = Nothing

    End Sub
    Public Function RefreshConfiguration() As Boolean
        Try
            Dim strModuleName As String = "APAX-PAC"
            Dim ui_FPGAVer As UInteger
            If m_adamCtl.Configuration.SYS_SetDspChannelFlag(True) Then
                ' Firmware Version
                If m_adamCtl.Configuration.GetModuleConfig(m_idxID, m_aConf) Then
                    m_idxID = CType(m_aConf.byUID, Integer)
                    Me.lbl_Controller_Title.Text = strModuleName
                    ' APAX_INFO_NAME + "-" + m_aConf.GetModuleName();
                    Me.TextBox_Firmware_Ver.Text = m_aConf.wFwVerNo.ToString("X04").Insert(2, ".")
                End If
                If Not m_adamCtl.Configuration.SYS_SetDspChannelFlag(False) Then
                    StatusBar_MAIN.Text = (StatusBar_MAIN.Text + "SYS_SetDspChannelFlag(fasle) Failed! ")
                End If
                ' FPGA Version
                If m_adamCtl.Configuration.GetFpgaVersion(ui_FPGAVer) Then
                    Me.TextBox_FPGA_Ver.Text = ui_FPGAVer.ToString("X2")
                Else
                    StatusBar_MAIN.Text = (StatusBar_MAIN.Text + ("Unable to get FPGA version (ApiErr:" _
                                + (m_adamCtl.Configuration.ApiLastError.ToString + ") ")))
                End If
                ' Get scan timer interval
                SetInfoValue(m_iScanTime(0))
                'Current modules information
                RefreshCurrentModuleInfo()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error")
        End Try
        Return True
    End Function

    Private Sub RefreshCurrentModuleInfo()
        Dim idx As Integer = 0
        Dim i As Integer = 0
        Dim strModuleName() As String = {""}
        Try
            If m_adamCtl.Configuration.GetSlotInfo(strModuleName) Then
                Dim listItemModule() As ListViewItem = New ListViewItem((strModuleName.Length) - 1) {}
                Me.ListView_Module_Infor.BeginUpdate()
                Me.ListView_Module_Infor.Items.Clear()
                i = 0
                Do While (i < strModuleName.Length)
                    listItemModule(i) = New ListViewItem(i.ToString)
                    listItemModule(i).SubItems.Add(strModuleName(i))

                    If (strModuleName(i).Length <= 0) Then
                        listItemModule(i).SubItems.Add("")
                    End If

                    'Non-module
                    Me.ListView_Module_Infor.Items.Add(listItemModule(i))
                    i = (i + 1)
                Loop
                Me.ListView_Module_Infor.EndUpdate()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Exception")
        End Try
    End Sub
    Public Sub SetInfoValue(ByVal iScanInterval As Integer)
        Dim iVal As Integer = iScanInterval
        If (iVal > Me.NumericUpDown_SCAN.Maximum) Then
            iVal = CType(Me.NumericUpDown_SCAN.Maximum, Integer)
        ElseIf (iVal < Me.NumericUpDown_SCAN.Minimum) Then
            iVal = CType(Me.NumericUpDown_SCAN.Minimum, Integer)
        End If
        Me.NumericUpDown_SCAN.Value = iVal
    End Sub

    Private Sub NumericUpDown_SCAN_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumericUpDown_SCAN.ValueChanged
        m_iScanTime(0) = CType(NumericUpDown_SCAN.Value, Integer)
    End Sub

End Class
