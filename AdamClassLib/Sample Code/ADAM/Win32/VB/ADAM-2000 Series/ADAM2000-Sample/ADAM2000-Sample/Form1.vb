Imports System.Collections
Imports Advantech.Adam

Public Class Form1
    Private ReadOnly ENDDEVICE_MAX_NUMBER As Integer = 64
    Private m_adamCom As AdamCom
    Private m_CoordinatorConfig As Adam2000Config
    Private m_CurrentDeviceNodeConfig As Adam2000Config
    Private m_coordinatorNode As TreeNode
    Private m_deviceList As ArrayList
    Private m_iQueryCount As Integer = 0
    Private m_ChannelNumber As Integer = 0
    Private m_iCoorComport As Integer
    Private m_iCoordinatorSlaveId As Integer
    Private m_Counter As Integer
    Private m_iShortAddr() As Integer
    Private m_iModuleStatus() As Integer
    Private m_iSlaveIDarray() As Integer
    Private m_iModuleNameFirst() As Integer
    Private m_iModuleNameSecond() As Integer
    Private m_iDeviceType() As Integer
    Private m_usRanges() As UShort
    Private m_bCheckName As Boolean
    Private ReadOnly AD_Convert_Timeout As UShort = (1 << 0)
    Private ReadOnly Over_Range As UShort = (1 << 1)
    Private ReadOnly Under_Range As UShort = (1 << 2)
    Private ReadOnly Open_Circuit_Burnout As UShort = (1 << 3)
    Private ReadOnly Not_Converted_Yet As UShort = (1 << 5)
    Private ReadOnly ADC_Initializing_Error As UShort = (1 << 7)
    Private ReadOnly Zero_Span_Calibration_Error As UShort = (1 << 9)
    Private ReadOnly m_StrDeviceInfo As String = "Device Info"

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_CoordinatorConfig = New Adam2000Config()
        m_deviceList = New ArrayList()

        'Initial some UI default option
        cbComportBuadrate.SelectedIndex = 0
        bCoordinator.Enabled = False
        gbDeviceTreeView.Enabled = False
        gbDeviceInfo.Enabled = False
        searchLabel.Visible = False
        bGetEndDevice.Visible = False

    End Sub

    Private Sub bComport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bComport.Click
        gbDeviceInfo.Text = m_StrDeviceInfo

        If (bComport.Text = "Open") Then
            m_iCoorComport = Convert.ToInt32(tbComport.Text.ToString())
            m_adamCom = New AdamCom(m_iCoorComport)

            If (m_adamCom.OpenComPort()) Then
                'Open Comport Success
                m_adamCom.SetComPortTimeout(500, 5000, 0, 1000, 0) ' set comport timeout

                'Set Buadrate
                If (cbComportBuadrate.SelectedIndex = 0) Then
                    m_adamCom.SetComPortState(Advantech.Common.Baudrate.Baud_9600, Advantech.Common.Databits.Eight, Advantech.Common.Parity.None, Advantech.Common.Stopbits.One)
                ElseIf (cbComportBuadrate.SelectedIndex = 1) Then
                    m_adamCom.SetComPortState(Advantech.Common.Baudrate.Baud_115200, Advantech.Common.Databits.Eight, Advantech.Common.Parity.None, Advantech.Common.Stopbits.One)
                Else
                    m_adamCom.SetComPortState(Advantech.Common.Baudrate.Baud_9600, Advantech.Common.Databits.Eight, Advantech.Common.Parity.None, Advantech.Common.Stopbits.One)
                End If

                bComport.Text = "Close"
                gbDeviceTreeView.Enabled = True
                gbDeviceInfo.Enabled = True
                bCoordinator.Enabled = True
            Else
                ' return open Comport Fail
                MessageBox.Show("Open COMPORT fail")
            End If

        ElseIf (bComport.Text = "Close") Then

            If (Not m_adamCom Is Nothing) Then
                m_adamCom.CloseComPort()
            End If

            tcDeviceInfo.SelectedIndex = 0
            txtDeviceName.Text = String.Empty
            txtDescription.Text = String.Empty
            txtFwVerKernal.Text = String.Empty
            txtFwVerZigBee.Text = String.Empty
            txtPanId.Text = String.Empty
            txtChannel.Text = String.Empty
            txtSlaveId.Text = String.Empty
            txtPAddr.Text = String.Empty
            txtSAddr.Text = String.Empty
            txtDataCycle.Text = String.Empty

            treeView1.Nodes.Clear()
            bCoordinator.Enabled = False
            gbDeviceTreeView.Enabled = False
            gbDeviceInfo.Enabled = False
            bGetEndDevice.Visible = False
            bComport.Text = "Open"

        End If
    End Sub

    Private Sub bCoordinator_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bCoordinator.Click
        bGetEndDevice.Visible = False
        Dim bRet As Boolean = False

        If (Not m_adamCom Is Nothing) Then
            bRet = True
        End If

        treeView1.Nodes.Clear()
        gbDeviceInfo.Text = m_StrDeviceInfo

        If (bRet) Then
            'Reset Comport Parameters
            m_adamCom.SetComPortTimeout(200, 600, 0, 400, 0)
            'Set Search Counter to be initial
            m_Counter = 241
            timerSearchCoordinator.Interval = 600
            searchLabel.Visible = True
            timerSearchCoordinator.Enabled = True
        End If

    End Sub

    Private Sub timerSearchCoordinator_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerSearchCoordinator.Tick
        If (m_Counter < 249) Then
            searchLabel.Text = "Searching " + m_Counter.ToString()

            If (m_adamCom.Adam2000(m_Counter).GetCoordinator(m_CoordinatorConfig)) Then
                m_iCoordinatorSlaveId = m_Counter

                If ((m_Counter >= 241) AndAlso (m_Counter <= 244)) Then 'Initial mode
                    m_coordinatorNode = New TreeNode("ADAM-2520Z" + "(*" + m_Counter.ToString("X02") + "h)")
                Else
                    m_coordinatorNode = New TreeNode("ADAM-2520Z" + "(" + m_Counter.ToString("X02") + "h)")
                End If

                treeView1.BeginUpdate()
                treeView1.Nodes.Add(m_coordinatorNode)
                treeView1.EndUpdate()
                treeView1.SelectedNode = treeView1.Nodes(0)
            End If

            m_Counter = m_Counter + 1

        Else
            timerSearchCoordinator.Enabled = False
            searchLabel.Text = ""
        End If
    End Sub


    Private Sub bGetEndDevice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGetEndDevice.Click
        m_coordinatorNode.Nodes.Clear()
        m_deviceList.Clear()
        Dim iRetryCount As Integer = 0
        Dim iRetryLimit As Integer = 3
        Dim iStart As Integer = 213 'wireless version data start address nuder ADAM-2000 protocol definition
        Dim i As Integer = 0
        Dim byWirelessVersionData() As Byte
        Dim bReturnVal As Boolean = True
        Dim bReadShortAddr As Boolean = False
        Dim bReadModuleStatus As Boolean = False
        Dim bReadSlaveID As Boolean = False
        Dim bReadModuleNameFirst As Boolean = False
        Dim bReadModuleNameSecond As Boolean = False

        Try
            While (True)
                For i = 0 To (iRetryLimit - 1)

                    If (Not bReadShortAddr) Then

                        If (Not m_adamCom.Modbus(m_iCoordinatorSlaveId).ReadHoldingRegs(10001, ENDDEVICE_MAX_NUMBER, m_iShortAddr)) Then 'Short address

                            If (iRetryCount >= iRetryLimit) Then
                                MessageBox.Show("EndDevice 10001", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                bReturnVal = False
                                Exit For
                            Else
                                iRetryCount = iRetryCount + 1
                                System.Threading.Thread.Sleep(100)
                                Continue For
                            End If

                        Else
                            bReadShortAddr = True
                        End If

                        System.Threading.Thread.Sleep(30)
                    End If

                    If (Not bReadSlaveID) Then

                        If (Not m_adamCom.Modbus(m_iCoordinatorSlaveId).ReadHoldingRegs(10401, ENDDEVICE_MAX_NUMBER, m_iSlaveIDarray)) Then ' slave ID

                            If (iRetryCount >= iRetryLimit) Then
                                MessageBox.Show("EndDevice 10401", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                bReturnVal = False
                                Exit For
                            Else
                                iRetryCount = iRetryCount + 1
                                System.Threading.Thread.Sleep(100)
                                Continue For
                            End If

                        Else
                            bReadSlaveID = True
                        End If

                        System.Threading.Thread.Sleep(30)
                    End If

                    If (Not bReadModuleNameFirst) Then

                        If (Not m_adamCom.Modbus(m_iCoordinatorSlaveId).ReadHoldingRegs(10601, ENDDEVICE_MAX_NUMBER, m_iModuleNameFirst)) Then 'Module Name

                            If (iRetryCount >= iRetryLimit) Then
                                MessageBox.Show("EndDevice 10601 first", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                bReturnVal = False
                                Exit For
                            Else
                                iRetryCount = iRetryCount + 1
                                System.Threading.Thread.Sleep(100)
                                Continue For
                            End If

                        Else
                            bReadModuleNameFirst = True
                        End If

                        System.Threading.Thread.Sleep(30)
                    End If

                    If (Not bReadModuleNameSecond) Then

                        If (Not m_adamCom.Modbus(m_iCoordinatorSlaveId).ReadHoldingRegs(10601 + ENDDEVICE_MAX_NUMBER, ENDDEVICE_MAX_NUMBER, m_iModuleNameSecond)) Then 'Module Name

                            If (iRetryCount >= iRetryLimit) Then
                                MessageBox.Show("EndDevice 10601 second", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                bReturnVal = False
                                Exit For
                            Else
                                iRetryCount = iRetryCount + 1
                                System.Threading.Thread.Sleep(100)
                                Continue For
                            End If

                        Else
                            bReadModuleNameSecond = True
                        End If

                        System.Threading.Thread.Sleep(30)
                    End If

                    If (Not bReadModuleStatus) Then

                        If (Not m_adamCom.Modbus(m_iCoordinatorSlaveId).ReadHoldingRegs(11001, ENDDEVICE_MAX_NUMBER, m_iModuleStatus)) Then 'Module status

                            If (iRetryCount >= iRetryLimit) Then
                                MessageBox.Show("EndDevice 11001", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                                bReturnVal = False
                                Exit For
                            Else
                                iRetryCount = iRetryCount + 1
                                System.Threading.Thread.Sleep(100)
                                Continue For
                            End If

                        Else
                            bReadModuleStatus = True
                        End If

                        System.Threading.Thread.Sleep(30)
                    End If

                    'prevent old MSP430 firmware not support this address 10801 (End Device and Router Version>=A103B01 supprot this address)
                    If (m_adamCom.Modbus(m_iCoordinatorSlaveId).ReadHoldingRegs(10801, ENDDEVICE_MAX_NUMBER, m_iDeviceType)) Then 'Device Type
                        m_bCheckName = False
                    Else
                        m_bCheckName = True
                    End If

                    If (bReturnVal) Then
                        Exit For
                    End If

                Next

                If (bReadShortAddr AndAlso bReadSlaveID AndAlso bReadModuleNameFirst AndAlso bReadModuleNameSecond AndAlso bReadModuleStatus) Then 'make sure all needed information already read back


                    For i = 0 To (ENDDEVICE_MAX_NUMBER - 1)

                        If (m_iShortAddr(i) <> 65535) Then '0xFFFF means empty
                            Dim tempAdam2kConfig As Adam2000Config = New Adam2000Config()

                            tempAdam2kConfig.wShortAddr = Convert.ToUInt16(m_iShortAddr(i))
                            tempAdam2kConfig.wMBSlaveID = Convert.ToUInt16(m_iSlaveIDarray(i))
                            byWirelessVersionData = New Byte(4) {}

                            Dim j As Integer = 0
                            For j = 0 To (iRetryLimit - 1)
                                If (m_adamCom.Modbus(tempAdam2kConfig.wMBSlaveID).ReadHoldingRegs(iStart, 2, byWirelessVersionData)) Then 'read 2 registers, 4 bytes
                                    tempAdam2kConfig.wFwVerNo = Convert.ToUInt16(byWirelessVersionData(0) * 256 + byWirelessVersionData(1))
                                    tempAdam2kConfig.wFwVerBld = Convert.ToUInt16(byWirelessVersionData(2) * 256 + byWirelessVersionData(3))
                                    Exit For
                                End If
                                System.Threading.Thread.Sleep(100)
                            Next

                            If (i < (ENDDEVICE_MAX_NUMBER / 2)) Then
                                tempAdam2kConfig.dwModName = Convert.ToUInt32(Convert.ToInt32(m_iModuleNameFirst(i * 2)) << 16 Or Convert.ToInt32(m_iModuleNameFirst(i * 2 + 1)))
                            Else
                                tempAdam2kConfig.dwModName = Convert.ToUInt32(Convert.ToInt32(m_iModuleNameSecond((i - ENDDEVICE_MAX_NUMBER / 2) * 2)) << 16 Or Convert.ToInt32(m_iModuleNameSecond((i - ENDDEVICE_MAX_NUMBER / 2) * 2 + 1)))
                            End If

                            tempAdam2kConfig.wModuleStatus = Convert.ToUInt16(m_iModuleStatus(i))
                            m_deviceList.Add(tempAdam2kConfig)

                            If (m_bCheckName) Then

                                If ((((tempAdam2kConfig.dwModName And 4294901760) >> 16).ToString("X4") <> "2520")) Then 'Coordinator
                                    InsertNodeAdamDevice(tempAdam2kConfig)
                                End If

                            Else
                                tempAdam2kConfig.wDevType = Convert.ToUInt16(m_iDeviceType(i))

                                If ((tempAdam2kConfig.wDevType = 1) OrElse (tempAdam2kConfig.wDevType = 2) OrElse (tempAdam2kConfig.wDevType = 3) OrElse (tempAdam2kConfig.wDevType = 4) OrElse (tempAdam2kConfig.wDevType = 13) OrElse (tempAdam2kConfig.wDevType = 15)) Then '0x0001 : DI, 0x0002 : DO, 0x0003 : AI, 0x0004 : AO, 0x000D : Sensor, 0x000F : Router
                                    InsertNodeAdamDevice(tempAdam2kConfig)
                                End If
                            End If

                            tempAdam2kConfig = Nothing

                        End If

                    Next

                Else
                    MessageBox.Show("Load End Device information error, please retry again.\nIf mode change, please re-search coordinator.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

                Exit While

            End While
        Catch ex As Exception
            Dim strMsg As String = ex.Message
            Dim strCap As String = "Exception"
            MessageBox.Show(strMsg, strCap, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub InsertNodeAdamDevice(ByRef a2kConfigObj As Adam2000Config)
        Dim moduleNode As TreeNode
        treeView1.BeginUpdate()

        If ((CType(a2kConfigObj.wModuleStatus, Byte) And 1) = 0) Then 'initial mode
            moduleNode = New TreeNode("ADAM" + "-" + a2kConfigObj.GetModuleName() + "(*" + a2kConfigObj.wMBSlaveID.ToString("X2") + "h)")
        Else
            moduleNode = New TreeNode("ADAM" + "-" + a2kConfigObj.GetModuleName() + "(" + a2kConfigObj.wMBSlaveID.ToString("X2") + "h)")
        End If

        moduleNode.Tag = CType(a2kConfigObj.wShortAddr, Object) 'for store Short address

        m_coordinatorNode.Nodes.Add(moduleNode)
        m_coordinatorNode.Expand()

        treeView1.EndUpdate()
    End Sub

    Private Enum TabPageStatus : int
        Enable = 1
        Disable = 2
    End Enum

    Private Sub treeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles treeView1.AfterSelect
        If (e Is Nothing) Then
            gbDeviceInfo.Text = m_StrDeviceInfo
            Return
        End If

        If (e.Node Is Nothing) Then
            gbDeviceInfo.Text = m_StrDeviceInfo
            Return
        End If

        gbDeviceInfo.Text = m_StrDeviceInfo + " : " + e.Node.Text

        m_CurrentDeviceNodeConfig = New Adam2000Config()

        Select Case e.Node.Level
            Case 0 ' Coordinator Node
                bGetEndDevice.Visible = True
                RefreshCoordinatorInformation()
                m_CurrentDeviceNodeConfig = m_CoordinatorConfig

                If (tcDeviceInfo.Controls.Contains(tpDeviceStatus)) Then
                    tcDeviceInfo.Controls.Remove(tpDeviceStatus)
                End If

                If (tcDeviceInfo.Controls.Contains(tpChannelInfo)) Then
                    tcDeviceInfo.Controls.Remove(tpChannelInfo)
                End If

                If (tcDeviceInfo.Controls.Contains(tpChannelStatus)) Then
                    tcDeviceInfo.Controls.Remove(tpChannelStatus)
                End If

                If (tcDeviceInfo.Controls.Contains(tpSetRange)) Then
                    tcDeviceInfo.Controls.Remove(tpSetRange)
                End If

                If (Not tcDeviceInfo.Controls.Contains(tpDeviceList)) Then
                    tcDeviceInfo.Controls.Add(tpDeviceList)
                End If

                Exit Select

            Case 1 'End Device (Router) Node
                bGetEndDevice.Visible = False
                RefreshEndDeviceInformation(CType(e.Node.Tag, UShort), m_CurrentDeviceNodeConfig)

                If (tcDeviceInfo.Controls.Contains(tpDeviceList)) Then
                    tcDeviceInfo.Controls.Remove(tpDeviceList)
                End If

                If (Not tcDeviceInfo.Controls.Contains(tpDeviceStatus)) Then
                    tcDeviceInfo.Controls.Add(tpDeviceStatus)
                End If

                If (m_CurrentDeviceNodeConfig.wDevType <> 15) Then ' != Router
                    If (Not tcDeviceInfo.Controls.Contains(tpChannelInfo)) Then
                        tcDeviceInfo.Controls.Add(tpChannelInfo)
                    End If
                Else
                    If (tcDeviceInfo.Controls.Contains(tpChannelInfo)) Then
                        tcDeviceInfo.Controls.Remove(tpChannelInfo)
                    End If
                End If

                If (m_CurrentDeviceNodeConfig.wDevType = 3) Then ' AI
                    If (Not tcDeviceInfo.Controls.Contains(tpChannelStatus)) Then
                        tcDeviceInfo.Controls.Add(tpChannelStatus)
                    End If

                    If (Not tcDeviceInfo.Controls.Contains(tpSetRange)) Then
                        tcDeviceInfo.Controls.Add(tpSetRange)
                    End If
                Else
                    If (tcDeviceInfo.Controls.Contains(tpChannelStatus)) Then
                        tcDeviceInfo.Controls.Remove(tpChannelStatus)
                    End If

                    If (tcDeviceInfo.Controls.Contains(tpSetRange)) Then
                        tcDeviceInfo.Controls.Remove(tpSetRange)
                    End If
                End If

                Exit Select

        End Select

        tcDeviceInfo_SelectedIndexChanged(Me, Nothing)
    End Sub

    Private Sub RefreshCoordinatorInformation()
        m_adamCom.Adam2000(m_iCoordinatorSlaveId).GetFixInformation(0, m_CoordinatorConfig)
        m_adamCom.Adam2000(m_iCoordinatorSlaveId).GetCoordinator(m_CoordinatorConfig)
    End Sub

    Private Sub RefreshEndDeviceInformation(ByVal usShortAddr As UShort, ByRef tempAdam2000Config As Adam2000Config)
        Dim i As Integer = 0
        For i = 0 To (m_deviceList.Count - 1)

            Dim a2kcfg As Adam2000Config = CType(m_deviceList(i), Adam2000Config)

            If (a2kcfg.wShortAddr = usShortAddr) Then
                tempAdam2000Config = a2kcfg
                m_adamCom.Adam2000(m_iCoordinatorSlaveId).GetFixInformation(tempAdam2000Config.wShortAddr, tempAdam2000Config)
                m_adamCom.Adam2000(m_iCoordinatorSlaveId).GetVariationInformation(tempAdam2000Config.wShortAddr, tempAdam2000Config)
                m_deviceList(i) = tempAdam2000Config
            End If

        Next
    End Sub

    Private Function GetModuleDescription(ByVal tempAdam2000Config As Adam2000Config) As String
        Dim strRet As String = "Unknown"

        If (tempAdam2000Config.GetModuleName().Contains("2520Z")) Then
            strRet = "Wireless Sensor Network Modbus RTU Gateway"
        ElseIf (tempAdam2000Config.GetModuleName().Contains("2510Z")) Then
            strRet = "Wireless Sensor Network Router Node"
        ElseIf (tempAdam2000Config.GetModuleName().Contains("2017Z")) Then
            strRet = "Wireless Sensor Network 6-ch Analog Input Node"
        ElseIf (tempAdam2000Config.GetModuleName().Contains("2017PZ")) Then
            strRet = "Wireless Sensor Network 6-ch Analog Input Node"
        ElseIf (tempAdam2000Config.GetModuleName().Contains("2031Z")) Then
            strRet = "Wireless Sensor Network Temperature, Humidity Sensor Node"
        ElseIf (tempAdam2000Config.GetModuleName().Contains("2051Z")) Then
            strRet = "Wireless Sensor Network 8-ch Digital Input Node"
        ElseIf (tempAdam2000Config.GetModuleName().Contains("2051PZ")) Then
            strRet = "Wireless Sensor Network 8-ch Digital Input Node"
        End If

        Return strRet
    End Function

    Private Function QueryChannelStatus() As Boolean
        Dim bRet As Boolean = True
        Dim iAiStatusStart As Integer = 101
        Dim AiChNum As Integer = 6
        Dim iAiStatus() As Integer
        listViewChStatus.Items.Clear()

        If (m_adamCom.Modbus(m_CurrentDeviceNodeConfig.wMBSlaveID).ReadHoldingRegs(iAiStatusStart, (AiChNum * 2), iAiStatus)) Then

            Dim i As Integer = 0
            For i = 0 To (AiChNum - 1)
                listViewChStatus.Items.Add("AI")
                listViewChStatus.Items(i).SubItems.Add(i.ToString())
                listViewChStatus.Items(i).SubItems.Add((4000 + iAiStatusStart + (i * 2)).ToString())
                listViewChStatus.Items(i).SubItems.Add(iAiStatus((i * 2)).ToString())
                listViewChStatus.Items(i).SubItems.Add(GetChannelStatusString(CType(iAiStatus((i * 2)), UShort)))
            Next

        Else
            bRet = False
            MessageBox.Show("Error: Read Holding Register fail!")
            Return bRet
        End If

        Return bRet

    End Function

    Private Function GetChannelStatusString(ByVal usStatusValue As UShort) As String
        Dim szMsg As String = String.Empty

        If ((usStatusValue And AD_Convert_Timeout) = AD_Convert_Timeout) Then
            szMsg = "A/D convert timeout (fail)"
        ElseIf ((usStatusValue And Over_Range) = Over_Range) Then
            szMsg = "Over Range"
        ElseIf ((usStatusValue And Under_Range) = Under_Range) Then
            szMsg = "Under_Range"
        ElseIf ((usStatusValue And Open_Circuit_Burnout) = Open_Circuit_Burnout) Then
            szMsg = "Open Circuit (Burnout)"
        ElseIf ((usStatusValue And Not_Converted_Yet) = Not_Converted_Yet) Then
            szMsg = "Not converted yet"
        ElseIf ((usStatusValue And ADC_Initializing_Error) = ADC_Initializing_Error) Then
            szMsg = "ADC initializing/Error"
        ElseIf ((usStatusValue And Zero_Span_Calibration_Error) = Zero_Span_Calibration_Error) Then
            szMsg = "Zero/Span Calibration Error"
        End If

        If (szMsg = String.Empty) Then
            szMsg = "Normal"
        End If

        Return szMsg
    End Function

    Private Sub RefreshModuleInformation()
        If (m_CurrentDeviceNodeConfig.wFwVerNo.ToString("X04").Length = 4) Then
            txtFwVerZigBee.Text = m_CurrentDeviceNodeConfig.wFwVerNo.ToString("X04").Insert(2, ".")
        Else
            txtFwVerZigBee.Text = m_CurrentDeviceNodeConfig.wFwVerNo.ToString("X04")
        End If

        txtDeviceName.Text = m_CurrentDeviceNodeConfig.GetModuleName().ToString()
        txtDescription.Text = GetModuleDescription(m_CurrentDeviceNodeConfig)

        txtPanId.Text = Convert.ToString(m_CurrentDeviceNodeConfig.wPanID)
        txtSlaveId.Text = Convert.ToString(m_CurrentDeviceNodeConfig.wMBSlaveID)
        txtChannel.Text = Convert.ToString(m_CurrentDeviceNodeConfig.wWirelessCh)

        If ((m_CurrentDeviceNodeConfig.wDevType = 1) OrElse (m_CurrentDeviceNodeConfig.wDevType = 2) OrElse (m_CurrentDeviceNodeConfig.wDevType = 3) OrElse (m_CurrentDeviceNodeConfig.wDevType = 4) OrElse (m_CurrentDeviceNodeConfig.wDevType = 13) OrElse (m_CurrentDeviceNodeConfig.wDevType = 15)) Then '0x0001 : DI, 0x0002 : DO, 0x0003 : AI, 0x0004 : AO, 0x000D : Sensor, 0x000F : Router

            labKernal.Visible = False
            txtFwVerKernal.Visible = False
            labPAddr.Visible = True
            txtPAddr.Visible = True
            labSAddr.Visible = True
            txtSAddr.Visible = True
            labDataCycle.Visible = True
            txtDataCycle.Visible = True

            Dim tempVal As UInteger = Convert.ToUInt32(m_CurrentDeviceNodeConfig.wParentShortAddr)
            txtPAddr.Text = "0x" + String.Format("{0:X4}", tempVal)

            tempVal = Convert.ToUInt32(m_CurrentDeviceNodeConfig.wShortAddr)
            txtSAddr.Text = "0x" + String.Format("{0:X4}", tempVal)

            txtDataCycle.Text = Convert.ToString(m_CurrentDeviceNodeConfig.dwActCycle)

        Else

            labKernal.Visible = True
            txtFwVerKernal.Visible = True
            labPAddr.Visible = False
            txtPAddr.Visible = False
            labSAddr.Visible = False
            txtSAddr.Visible = False
            labDataCycle.Visible = False
            txtDataCycle.Visible = False

            If (m_CurrentDeviceNodeConfig.w430FwVer.ToString("X04").Length = 4) Then
                txtFwVerKernal.Text = m_CurrentDeviceNodeConfig.w430FwVer.ToString("X04").Insert(2, ".")
            Else
                txtFwVerKernal.Text = m_CurrentDeviceNodeConfig.w430FwVer.ToString("X04")
            End If

        End If

    End Sub

    Private Sub RefreshChannelInfoPage()

        listViewChannelInfo.Items.Clear()
        listViewChannelInfo.BeginUpdate()

        If (m_CurrentDeviceNodeConfig.wDevType = 1) Then 'DI
            m_ChannelNumber = 8
            InitialDI(m_CurrentDeviceNodeConfig)
        ElseIf (m_CurrentDeviceNodeConfig.wDevType = 13) Then 'Sensor
            m_ChannelNumber = 2
            InitialSensor(m_CurrentDeviceNodeConfig)
        ElseIf (m_CurrentDeviceNodeConfig.wDevType = 3) Then 'AI
            m_ChannelNumber = 6
            ReDim m_usRanges(m_ChannelNumber)
            UpdateRangesValue()
            InitialAI(m_CurrentDeviceNodeConfig)
        Else 'Others

        End If

        listViewChannelInfo.EndUpdate()
        listViewChannelInfo.BringToFront()
    End Sub

    Private Function RefreshData() As Boolean
        Dim bRet As Boolean = True
        Dim byEndDeviceData() As Byte
        Dim start As Integer = 1 ' data start address nuder ADAM-2000 protocol definition
        Dim intInactiveTime As Integer = 0

        Try

            'Modbus EndDevice address defined under ADAM-2000 protocol
            '301	1 Register(2 bytes)	Module Status
            '302	1 Register(2 bytes)	Wireless Signal Intensity (LQI)
            '303	1 Register(2 bytes)	Battery Estimation
            '304	2 Register(4 bytes)	Device Inactive Period (unit:sec)
            start = 301

            If (Not m_adamCom.Modbus(m_CurrentDeviceNodeConfig.wMBSlaveID).ReadHoldingRegs(start, 5, byEndDeviceData)) Then 'read 4 registers, 10 bytes
                MessageBox.Show("Read Holding Regs Fail: " + m_adamCom.Modbus(m_CurrentDeviceNodeConfig.wMBSlaveID).LastError.ToString())
                bRet = False
                Return bRet
            End If

            intInactiveTime = (Convert.ToInt32(byEndDeviceData(6)) << 24) + Convert.ToInt32(byEndDeviceData(7) << 16) + (Convert.ToInt32(byEndDeviceData(8)) << 8) + Convert.ToInt32(byEndDeviceData(9))

            Dim strLQI As String = String.Empty

            If ((byEndDeviceData(3) >= 0) AndAlso (byEndDeviceData(3) <= 255)) Then
                strLQI = (Int(byEndDeviceData(3) * 100 / 255)).ToString() + "%"  'LQI, from 0~255
            Else
                strLQI = "--" 'LQI, but data not fall in reasonable range
            End If

            If (m_CurrentDeviceNodeConfig.wDevType = 1) Then 'DI

                Dim bVal() As Boolean
                start = 1

                If (Not m_adamCom.Modbus(m_CurrentDeviceNodeConfig.wMBSlaveID).ReadCoilStatus(start, m_ChannelNumber, bVal)) Then
                    MessageBox.Show("Read Coil Status Fail: " + m_adamCom.Modbus(m_CurrentDeviceNodeConfig.wMBSlaveID).LastError.ToString())
                    bRet = False
                    Return bRet
                End If

                Dim i As Integer = 0
                For i = 0 To (m_ChannelNumber - 1)
                    Dim strValue As String = String.Empty

                    If (bVal(i)) Then
                        strValue = "1"
                    Else
                        strValue = "0"
                    End If

                    Dim time As DateTime = DateTime.Now   ' fetch current time
                    time = time.AddSeconds(-(intInactiveTime))
                    listViewChannelInfo.Items(i).SubItems(3).Text = strValue ' Value
                    listViewChannelInfo.Items(i).SubItems(5).Text = m_CurrentDeviceNodeConfig.dwActCycle.ToString() + "s"  'Data Cycle;
                    listViewChannelInfo.Items(i).SubItems(6).Text = strLQI 'LQI

                    If ((CType(m_CurrentDeviceNodeConfig.wModuleStatus, Byte) And 1) = 1) Then ' Normal mode
                        listViewChannelInfo.Items(i).SubItems(7).Text = time.ToString("G") ' G is data format like "3/9/2008 4:05:07 PM"
                    Else
                        listViewChannelInfo.Items(i).SubItems(7).Text = String.Empty
                    End If

                Next

            ElseIf (m_CurrentDeviceNodeConfig.wDevType = 13) Then 'Sensor

                Dim byData() As Byte
                Dim usVal(m_ChannelNumber) As UShort
                Dim strValue As String = String.Empty
                start = 1

                If (Not m_adamCom.Modbus(m_CurrentDeviceNodeConfig.wMBSlaveID).ReadHoldingRegs(start, m_ChannelNumber, byData)) Then
                    MessageBox.Show("Read Holding Registers Fail: " + m_adamCom.Modbus(m_CurrentDeviceNodeConfig.wMBSlaveID).LastError.ToString())
                    bRet = False
                    Return bRet
                End If

                Dim i As Integer = 0
                For i = 0 To (m_ChannelNumber - 1)

                    usVal(i) = Convert.ToUInt16((Convert.ToUInt32(byData(i * 2)) << 8) Or Convert.ToUInt32(byData((i * 2) + 1)))

                    If (0 = i) Then
                        strValue = (Adam2000.ConvertToEngineerData(CType(Adam2kChannelType.Temperature, Integer), usVal(i))).ToString("F1") 'temperature, degree C
                    ElseIf (1 = i) Then
                        strValue = (Adam2000.ConvertToEngineerData(CType(Adam2kChannelType.Humidity, Integer), usVal(i))).ToString("F1") 'humidity, %
                    Else
                        strValue = (usVal(i)).ToString()
                    End If

                    Dim time As DateTime = DateTime.Now   ' fetch current time
                    time = time.AddSeconds(-(intInactiveTime))
                    listViewChannelInfo.Items(i).SubItems(3).Text = strValue ' Value
                    listViewChannelInfo.Items(i).SubItems(5).Text = m_CurrentDeviceNodeConfig.dwActCycle.ToString() + "s" ' Data Cycle;
                    listViewChannelInfo.Items(i).SubItems(6).Text = strLQI ' LQI

                    If ((CType(m_CurrentDeviceNodeConfig.wModuleStatus, Byte) And 1) = 1) Then ' Normal mode
                        listViewChannelInfo.Items(i).SubItems(7).Text = time.ToString("G") ' G is data format like "3/9/2008 4:05:07 PM"
                    Else
                        listViewChannelInfo.Items(i).SubItems(7).Text = String.Empty
                    End If

                Next

            ElseIf (m_CurrentDeviceNodeConfig.wDevType = 3) Then 'AI

                Dim usVal() As UShort
                Dim byChannelStatus() As Byte
                Dim strValue As String = String.Empty

                If (Not m_adamCom.Adam2000(Convert.ToInt32(m_iCoordinatorSlaveId)).GetVariationInformation(Convert.ToUInt16(m_CurrentDeviceNodeConfig.wShortAddr), m_CurrentDeviceNodeConfig, byChannelStatus, usVal)) Then
                    MessageBox.Show("Read Get Variation Information Fail: " + m_adamCom.Modbus(m_CurrentDeviceNodeConfig.wMBSlaveID).LastError.ToString())
                    bRet = False
                    Return bRet
                End If

                Dim i As Integer = 0
                For i = 0 To (m_ChannelNumber - 1)
                    Dim time As DateTime = DateTime.Now  ' fetch current time
                    time = time.AddSeconds(-(intInactiveTime))
                    Dim fVal As Single = AnalogInput.GetScaledValue(m_usRanges(i), usVal(i))
                    strValue = fVal.ToString(AnalogInput.GetFloatFormat(m_usRanges(i)))
                    listViewChannelInfo.Items(i).SubItems(3).Text = strValue
                    listViewChannelInfo.Items(i).SubItems(5).Text = m_CurrentDeviceNodeConfig.dwActCycle.ToString() + "s" ' Data Cycle;
                    listViewChannelInfo.Items(i).SubItems(6).Text = strLQI ' LQI

                    If ((CType(m_CurrentDeviceNodeConfig.wModuleStatus, Byte) And 1) = 1) Then ' Normal mode
                        listViewChannelInfo.Items(i).SubItems(7).Text = time.ToString("G") ' G is data format like "3/9/2008 4:05:07 PM"
                    Else
                        listViewChannelInfo.Items(i).SubItems(7).Text = String.Empty
                    End If

                Next

            End If

        Catch ex As Exception
            bRet = False
        End Try

        listViewChannelInfo.BringToFront()
        Return bRet

    End Function

    Private Sub RefreshDeviceStatus()
        If ((m_CurrentDeviceNodeConfig.wDevType = 1) OrElse (m_CurrentDeviceNodeConfig.wDevType = 2) OrElse (m_CurrentDeviceNodeConfig.wDevType = 3) OrElse (m_CurrentDeviceNodeConfig.wDevType = 4) OrElse (m_CurrentDeviceNodeConfig.wDevType = 13) OrElse (m_CurrentDeviceNodeConfig.wDevType = 15)) Then '0x0001 : DI, 0x0002 : DO, 0x0003 : AI, 0x0004 : AO, 0x000D : Sensor, 0x000F : Router

            If ((m_CurrentDeviceNodeConfig.wLQI >= 0) AndAlso (m_CurrentDeviceNodeConfig.wLQI <= 255)) Then
                txtLink.Text = Convert.ToString(Int(m_CurrentDeviceNodeConfig.wLQI * 100 / 255)) + "%" ' LQI is from 0~255
            Else
                txtLink.Text = "--"  'LQI, but data not fall in reasonable range 
            End If

            If (Convert.ToBoolean(m_CurrentDeviceNodeConfig.wModuleStatus And 2)) Then
                txtPower.Text = "Yes"
                txtBattery.Text = "--" 'Battery level is from 0~65535
            Else
                txtPower.Text = "No"
                txtBattery.Text = Convert.ToString((m_CurrentDeviceNodeConfig.wBetteryStatus * 100 / 65535)) + "%" 'Battery status is from 0~65535
            End If

            If (Convert.ToBoolean(m_CurrentDeviceNodeConfig.wModuleStatus And 1)) Then
                txtModeStatus.Text = "Normal"
            Else
                txtModeStatus.Text = "Initial"
            End If

        Else

            txtModeStatus.Text = String.Empty
            txtLink.Text = String.Empty
            txtBattery.Text = String.Empty
            txtPower.Text = String.Empty

        End If
    End Sub

    Private Sub RefreshChannelStatus()

        listViewChStatus.Items.Clear()

        If (m_CurrentDeviceNodeConfig.wDevType = 3) Then 'AI
            bGetChStatus.Enabled = True
            bClearLvChStatus.Enabled = True
        Else
            bGetChStatus.Enabled = False
            bClearLvChStatus.Enabled = False
        End If

    End Sub

    Private Sub RefreshSetRangePage()

        If (m_CurrentDeviceNodeConfig.wDevType = 3) Then ' AI
            bGetConfig.Enabled = True
            bSetRange.Enabled = True
        Else
            bGetConfig.Enabled = False
            bSetRange.Enabled = False
        End If

    End Sub

    Private Sub RefreshDeviceListPage()
        Dim byEndDeviceData() As Byte
        Dim start As Integer = 1 'data start address nuder ADAM-2000 protocol definition

        If (m_CurrentDeviceNodeConfig.wDevType = 14) Then ' Coordinator
            bDeviceListRefresh.Enabled = True
        Else
            bDeviceListRefresh.Enabled = False
            Return
        End If

        listViewDeviceList.Items.Clear()
        listViewDeviceList.BeginUpdate()

        Dim i As Integer
        For i = 0 To (m_deviceList.Count - 1)
            Dim tempAdam2000Config As Adam2000Config
            tempAdam2000Config = CType(m_deviceList(i), Adam2000Config)
            RefreshEndDeviceInformation(tempAdam2000Config.wShortAddr, tempAdam2000Config)
            Dim strDeviceName As String = tempAdam2000Config.GetModuleName().ToString() 'Module name
            Dim strSlaveId As String = tempAdam2000Config.wMBSlaveID.ToString("D3") + " (" + tempAdam2000Config.wMBSlaveID.ToString("X2") + "h)" 'Slave ID

            'Modbus EndDevice address defined under ADAM-2000 protocol
            '301	1 Register(2 bytes)	Module Status
            '302	1 Register(2 bytes)	Wireless Signal Intensity (LQI)
            '303	1 Register(2 bytes)	Battery Estimation
            '304	2 Register(4 bytes)	Device Inactive Period (unit:sec)
            start = 301
            If (Not m_adamCom.Modbus(tempAdam2000Config.wMBSlaveID).ReadHoldingRegs(start, 5, byEndDeviceData)) Then 'read 4 registers, 10 bytes
                MessageBox.Show("Read Holding Regs Fail: " + m_adamCom.Modbus(tempAdam2000Config.wMBSlaveID).LastError.ToString())
            End If

            Dim intInactiveTime As Integer = 0
            intInactiveTime = (Convert.ToInt32(byEndDeviceData(6)) << 24) + Convert.ToInt32(byEndDeviceData(7) << 16) + (Convert.ToInt32(byEndDeviceData(8)) << 8) + Convert.ToInt32(byEndDeviceData(9))

            Dim strLQI As String = String.Empty
            If ((byEndDeviceData(3) >= 0) AndAlso (byEndDeviceData(3) <= 255)) Then
                strLQI = (Int(byEndDeviceData(3) * 100 / 255)).ToString() + "%"  ' LQI, from 0~255
            Else
                strLQI = "--" ' LQI, but data not fall in reasonable range
            End If

            Dim strInactiveTime As String = intInactiveTime.ToString() + "s" 'Inactive Time (s)
            Dim strCycleTime As String = tempAdam2000Config.dwActCycle.ToString() + "s" 'Cycle Time (s)
            Dim strShortAddr As String = "0x" + tempAdam2000Config.wShortAddr.ToString("X4") 'Short address[Hex]
            Dim strParentShortAddr As String = "0x" + tempAdam2000Config.wParentShortAddr.ToString("X4") 'Parent short address[Hex]
            Dim strStatus As String = String.Empty

            If ((Convert.ToInt32(tempAdam2000Config.wModuleStatus) And 1) = 0) Then
                strStatus = "Initial" 'Module status
            Else
                strStatus = "Normal" 'Module status
            End If

            listViewDeviceList.Items.Add(strDeviceName)
            listViewDeviceList.Items(i).SubItems.Add(strSlaveId)
            listViewDeviceList.Items(i).SubItems.Add(strLQI)
            listViewDeviceList.Items(i).SubItems.Add(strInactiveTime)
            listViewDeviceList.Items(i).SubItems.Add(strCycleTime)
            listViewDeviceList.Items(i).SubItems.Add(strShortAddr)
            listViewDeviceList.Items(i).SubItems.Add(strParentShortAddr)
            listViewDeviceList.Items(i).SubItems.Add(strStatus)

        Next

        listViewDeviceList.EndUpdate()

    End Sub

    Private Sub UpdateRangesValue()
        'Read from flash
        Dim iRecvLen As Integer = 0
        Dim iLength As Integer = 4 + 10
        Dim byCmd(4 + 10 + 6) As Byte
        Dim byRecv(256) As Byte
        Dim iSAddr As Integer = 0
        Dim iCAddr As Integer = 0

        'End Device Short Address 
        iSAddr = m_CurrentDeviceNodeConfig.wShortAddr

        'Coordinator ID
        iCAddr = m_iCoordinatorSlaveId

        '4 Bytes 
        byCmd(0) = 255    'Coordinator header
        byCmd(1) = 90    'Coordinator header
        byCmd(2) = Convert.ToByte(iCAddr And 255)                ' Coordinator ID Low 
        byCmd(3) = Convert.ToByte((iCAddr >> 8) And 255)          ' Coordinator ID High

        '10 Bytes
        byCmd(4 + 0) = Convert.ToByte(iSAddr And 255)             ' Short Address Low
        byCmd(4 + 1) = Convert.ToByte((iSAddr >> 8) And 255)      ' Short Address High

        'Message 0x0000 Register Query
        byCmd(4 + 2) = 0    'Message Type Low        
        byCmd(4 + 3) = 0    ' Message Type High      
        byCmd(4 + 4) = 1    ' Packet Version Low
        byCmd(4 + 5) = 0    ' Packet Version High
        byCmd(4 + 6) = 1    ' Sequence Number Low
        byCmd(4 + 7) = 0    ' Sequence Number High
        byCmd(4 + 8) = 0    ' CmdCode Low (Reserved)
        byCmd(4 + 9) = 0    ' CmdCode High (Reserved)

        m_adamCom.SetPurge(12)

        If (m_adamCom.Send(iLength, byCmd) = (4 + 10)) Then
            iRecvLen = m_adamCom.Recv(byRecv.Length, byRecv)
            If (iRecvLen >= (10 + 4 + 12)) Then '// 4 Bytes header + 10 Bytes code + 12 Bytes data

                If ((byRecv(6) = 1) AndAlso (byRecv(7) = 0)) Then

                    Dim i As Integer = 0
                    For i = 49 To ((60 + 4) - 1)

                        'Update Range Code for each channel
                        If ((i >= 49) AndAlso (i <= 59) AndAlso ((i Mod 2) = 1)) Then

                            Dim byHigh As Byte = byRecv(i)
                            Dim byLow As Byte = byRecv(i - 1)
                            Dim iIndex As Integer = i
                            Dim iRangeCode As Integer = 0

                            iRangeCode = ((byHigh And 255) << 8) Or byLow

                            Select Case iIndex
                                Case 49
                                    m_usRanges(0) = CType(iRangeCode, UShort)
                                    Exit Select
                                Case 51
                                    m_usRanges(1) = CType(iRangeCode, UShort)
                                    Exit Select
                                Case 53
                                    m_usRanges(2) = CType(iRangeCode, UShort)
                                    Exit Select
                                Case 55
                                    m_usRanges(3) = CType(iRangeCode, UShort)
                                    Exit Select
                                Case 57
                                    m_usRanges(4) = CType(iRangeCode, UShort)
                                    Exit Select
                                Case 59
                                    m_usRanges(5) = CType(iRangeCode, UShort)
                                    Exit Select
                            End Select

                        End If

                    Next

                Else
                    MessageBox.Show("Function Fail")
                End If

            Else
                MessageBox.Show("Fail: Receive Fail ")
            End If

        Else
            MessageBox.Show("Fail: Send Fail")
        End If

    End Sub

    Private Sub UpdateUICombooBox(ByVal byHigh As Byte, ByVal byLow As Byte, ByVal iIndex As Integer)
        Dim iChangeIndex As Integer = 1
        Dim iRangeCode As Integer = 0
        iRangeCode = ((byHigh And 255) << 8) Or byLow

        Select Case iRangeCode
            Case 259 '0x0103
                iChangeIndex = 0
                Exit Select
            Case 260 '0x0104
                iChangeIndex = 1
                Exit Select
            Case 320 '0x0140
                iChangeIndex = 2
                Exit Select
            Case 322 '0x0142
                iChangeIndex = 3
                Exit Select
            Case 323 '0x0143
                iChangeIndex = 4
                Exit Select
            Case 385 '0x0181
                iChangeIndex = 5
                Exit Select
            Case 386 '0x0182
                iChangeIndex = 6
                Exit Select
            Case 384 '0x0180
                iChangeIndex = 7
                Exit Select
        End Select

        Select Case iIndex
            Case 49
                cbCh0.SelectedIndex = iChangeIndex
                Exit Select
            Case 51
                cbCh1.SelectedIndex = iChangeIndex
                Exit Select
            Case 53
                cbCh2.SelectedIndex = iChangeIndex
                Exit Select
            Case 55
                cbCh3.SelectedIndex = iChangeIndex
                Exit Select
            Case 57
                cbCh4.SelectedIndex = iChangeIndex
                Exit Select
            Case 59
                cbCh5.SelectedIndex = iChangeIndex
                Exit Select
        End Select

    End Sub

    Private Function getRangeConfigFromUI(ByVal cbChannel As ComboBox) As Int16
        Dim selectedRangeCode As Int16

        Select Case cbChannel.SelectedIndex
            Case 0 '+- 150 mV
                selectedRangeCode = 259
                Exit Select
            Case 1 '+-500 mV
                selectedRangeCode = 260
                Exit Select
            Case 2 '+- 1V
                selectedRangeCode = 320
                Exit Select
            Case 3 '+- 5V
                selectedRangeCode = 322
                Exit Select
            Case 4 '+- 10 V
                selectedRangeCode = 323
                Exit Select
            Case 5 '+-20 mA
                selectedRangeCode = 385
                Exit Select
            Case 6 ' 0~20mA
                selectedRangeCode = 386
                Exit Select
            Case 7 '4~20mA
                selectedRangeCode = 384
                Exit Select
            Case Else
                selectedRangeCode = 323
                Exit Select
        End Select

        Return selectedRangeCode

    End Function

    Private Sub InitialDI(ByVal tempAdam2000Config As Adam2000Config)
        Dim start As Integer = 1
        Dim bStatus() As Boolean
        listViewChannelInfo.Columns(4).Text = "Mode"

        If (Not m_adamCom.Modbus(tempAdam2000Config.wMBSlaveID).ReadCoilStatus(start, m_ChannelNumber, bStatus)) Then
            MessageBox.Show("Read Coil Status Fail : " + m_adamCom.Modbus(tempAdam2000Config.wMBSlaveID).LastError.ToString())
        End If

        Dim strLQI As String = String.Empty
        If ((tempAdam2000Config.wLQI >= 0) AndAlso (tempAdam2000Config.wLQI <= 255)) Then
            strLQI = Convert.ToString(Int(tempAdam2000Config.wLQI * 100 / 255)) + "%" ' LQI is from 0~255
        Else
            strLQI = "--"  'LQI, but data not fall in reasonable range
        End If

        Dim i As Integer = 0
        For i = 0 To (m_ChannelNumber - 1)
            listViewChannelInfo.Items.Add("DI") 'Type
            listViewChannelInfo.Tag = i
            listViewChannelInfo.Items(i).SubItems.Add(i.ToString()) 'Ch Number
            listViewChannelInfo.Items(i).SubItems.Add("0000" + (i + 1).ToString()) 'Modbus Addr

            If (bStatus(i)) Then 'Value
                listViewChannelInfo.Items(i).SubItems.Add("1")
            Else
                listViewChannelInfo.Items(i).SubItems.Add("0")
            End If

            listViewChannelInfo.Items(i).SubItems.Add("BOOL") 'Mode

            If ((CType(tempAdam2000Config.wModuleStatus, Byte) And 1) = 1) Then 'Normal mode
                Dim time As DateTime = DateTime.Now   ' fetch current time
                listViewChannelInfo.Items(i).SubItems.Add(tempAdam2000Config.dwActCycle.ToString() + "s") 'Cycle Time
                listViewChannelInfo.Items(i).SubItems.Add(strLQI) 'LQI
                listViewChannelInfo.Items(i).SubItems.Add(time.ToString("G")) 'G is data format like "3/9/2008 4:05:07 PM" 
            Else
                listViewChannelInfo.Items(i).SubItems.Add("1s (initial mode)") 'Cycle Time
                listViewChannelInfo.Items(i).SubItems.Add(strLQI) 'LQI
                listViewChannelInfo.Items(i).SubItems.Add("")
            End If
        Next
    End Sub

    Private Sub InitialAI(ByVal tempAdam2000Config As Adam2000Config)
        listViewChannelInfo.Columns(4).Text = "Range"
        Dim strLQI As String = String.Empty
        If ((tempAdam2000Config.wLQI >= 0) AndAlso (tempAdam2000Config.wLQI <= 255)) Then
            strLQI = Convert.ToString(Int(tempAdam2000Config.wLQI * 100 / 255)) + "%" ' LQI is from 0~255
        Else
            strLQI = "--"  'LQI, but data not fall in reasonable range
        End If

        Dim i As Integer = 0
        For i = 0 To (m_ChannelNumber - 1)

            listViewChannelInfo.Items.Add("AI") 'Type
            listViewChannelInfo.Tag = i
            listViewChannelInfo.Items(i).SubItems.Add(i.ToString()) 'Ch Number
            listViewChannelInfo.Items(i).SubItems.Add((40000 + i + 1).ToString()) 'Modbus Addr
            listViewChannelInfo.Items(i).SubItems.Add("*****") 'Value
            listViewChannelInfo.Items(i).SubItems.Add(AnalogInput.GetRangeName(m_usRanges(i))) 'Range

            If ((CType(tempAdam2000Config.wModuleStatus, Byte) And 1) = 1) Then 'Normal mode
                Dim time As DateTime = DateTime.Now   'fetch current time
                listViewChannelInfo.Items(i).SubItems.Add(tempAdam2000Config.dwActCycle.ToString() + "s") 'Cycle Time
                listViewChannelInfo.Items(i).SubItems.Add(strLQI) 'LQI
                listViewChannelInfo.Items(i).SubItems.Add(time.ToString("G")) 'G is data format like "3/9/2008 4:05:07 PM" 
            Else
                listViewChannelInfo.Items(i).SubItems.Add("1s (initial mode)") 'Cycle Time
                listViewChannelInfo.Items(i).SubItems.Add(strLQI) 'LQI
                listViewChannelInfo.Items(i).SubItems.Add("")
            End If
        Next
    End Sub

    Private Sub InitialSensor(ByVal tempAdam2000Config As Adam2000Config)
        listViewChannelInfo.Columns(4).Text = "Unit"
        Dim strLQI As String = String.Empty
        If ((tempAdam2000Config.wLQI >= 0) AndAlso (tempAdam2000Config.wLQI <= 255)) Then
            strLQI = Convert.ToString(Int(tempAdam2000Config.wLQI * 100 / 255)) + "%" ' LQI is from 0~255
        Else
            strLQI = "--"  'LQI, but data not fall in reasonable range
        End If

        Dim i As Integer = 0
        For i = 0 To (m_ChannelNumber - 1)

            If (0 = i) Then
                listViewChannelInfo.Items.Add("Temp.") 'Type
                listViewChannelInfo.Tag = i
                listViewChannelInfo.Items(i).SubItems.Add(i.ToString()) 'Ch Number
                listViewChannelInfo.Items(i).SubItems.Add((40000 + i + 1).ToString()) 'Modbus Addr
                listViewChannelInfo.Items(i).SubItems.Add("*****") 'Value
                listViewChannelInfo.Items(i).SubItems.Add("C") 'Unit                    
            ElseIf (1 = i) Then
                listViewChannelInfo.Items.Add("Humidity") 'Type
                listViewChannelInfo.Tag = i
                listViewChannelInfo.Items(i).SubItems.Add(i.ToString()) 'Ch Number
                listViewChannelInfo.Items(i).SubItems.Add((40000 + i + 1).ToString()) 'Modbus Addr
                listViewChannelInfo.Items(i).SubItems.Add("*****") 'Value
                listViewChannelInfo.Items(i).SubItems.Add("%") 'Unit                  
            End If

            If ((CType(tempAdam2000Config.wModuleStatus, Byte) And 1) = 1) Then 'Normal mode
                Dim time As DateTime = DateTime.Now   'fetch current time
                listViewChannelInfo.Items(i).SubItems.Add(tempAdam2000Config.dwActCycle.ToString() + "s") 'Cycle Time
                listViewChannelInfo.Items(i).SubItems.Add(strLQI) 'LQI
                listViewChannelInfo.Items(i).SubItems.Add(time.ToString("G")) 'G is data format like "3/9/2008 4:05:07 PM" 
            Else
                listViewChannelInfo.Items(i).SubItems.Add("1s (initial mode)") 'Cycle Time
                listViewChannelInfo.Items(i).SubItems.Add(strLQI) 'LQI
                listViewChannelInfo.Items(i).SubItems.Add("")
            End If
        Next
    End Sub

    Private Sub bGetChStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGetChStatus.Click
        If (Not QueryChannelStatus()) Then
            MessageBox.Show("Query Function Failed")
        End If
    End Sub

    Private Sub bClearLvChStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bClearLvChStatus.Click
        listViewChStatus.Items.Clear()
    End Sub

    Private Sub bDeviceListRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bDeviceListRefresh.Click
        bGetEndDevice_Click(Me, Nothing)
        RefreshDeviceListPage()
    End Sub

    Private Sub bPolling_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bPolling.Click
        If (bPolling.Text = "Polling") Then

            timerPollingData.Interval = 1000
            timerPollingData.Enabled = True
            bPolling.Text = "Stop"

        Else

            m_iQueryCount = 0
            timerPollingData.Enabled = False
            bPolling.Text = "Polling"
            lPollingTimes.Text = "Polling Times : "

        End If
    End Sub

    Private Sub bGetConfig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bGetConfig.Click
        ' Read from flash
        Dim iRecvLen As Integer = 0
        Dim iLength As Integer = 4 + 10
        Dim byCmd(4 + 10 + 6) As Byte
        Dim byRecv(256) As Byte
        Dim iSAddr As Integer = 0
        Dim iCAddr As Integer = 0

        'End Device Short Address 
        iSAddr = m_CurrentDeviceNodeConfig.wShortAddr

        'Coordinator ID
        iCAddr = m_iCoordinatorSlaveId

        '4 Bytes 
        byCmd(0) = 255    'Coordinator header
        byCmd(1) = 90    'Coordinator header
        byCmd(2) = Convert.ToByte(iCAddr And 255)                 ' Coordinator ID Low 
        byCmd(3) = Convert.ToByte((iCAddr >> 8) And 255)          ' Coordinator ID High
        ' 10 Bytes
        byCmd(4 + 0) = Convert.ToByte(iSAddr And 255)             'Short Address Low
        byCmd(4 + 1) = Convert.ToByte((iSAddr >> 8) And 255)      'Short Address High

        ' Message 0x0000 Register Query
        byCmd(4 + 2) = 0    'Message Type Low        
        byCmd(4 + 3) = 0    'Message Type High      
        byCmd(4 + 4) = 1    'Packet Version Low
        byCmd(4 + 5) = 0    'Packet Version High
        byCmd(4 + 6) = 1    'Sequence Number Low
        byCmd(4 + 7) = 0    'Sequence Number High
        byCmd(4 + 8) = 0    'CmdCode Low (Reserved)
        byCmd(4 + 9) = 0    'CmdCode High (Reserved)

        m_adamCom.SetPurge(12)

        If (m_adamCom.Send(iLength, byCmd) = (4 + 10)) Then
            iRecvLen = m_adamCom.Recv(byRecv.Length, byRecv)
            If (iRecvLen >= (10 + 4 + 12)) Then ' 4 Bytes header + 10 Bytes code + 12 Bytes data Then


                If ((byRecv(6) = 1) AndAlso (byRecv(7) = 0)) Then

                    Dim i As Integer = 0
                    For i = 0 To ((72 + 4) - 1)

                        'Update Range Code for each channel
                        If ((i >= 49) AndAlso (i <= 59) AndAlso ((i Mod 2) = 1)) Then
                            UpdateUICombooBox(byRecv(i), byRecv(i - 1), i)
                        End If

                        ' byRecv(60) function enable byte 
                        ' Update burnout Enable
                        If ((byRecv(60) And 1) = 0) Then
                            cbBurnOutEnable.SelectedIndex = 1  ' Disable
                        Else
                            cbBurnOutEnable.SelectedIndex = 0  ' Enable
                        End If

                        ' update burnout ouput option
                        If (((byRecv(60) And 2) >> 1) = 0) Then
                            cbBurnOutPresent.SelectedIndex = 0 ' Low
                        Else
                            cbBurnOutPresent.SelectedIndex = 1 ' High
                        End If

                        ' update Filter Mode 
                        If (((byRecv(60) And 48) >> 4) = 0) Then
                            cbUpdateRate.SelectedIndex = 0
                        ElseIf (((byRecv(60) And 48) >> 4) = 1) Then
                            cbUpdateRate.SelectedIndex = 1
                        ElseIf (((byRecv(60) And 48) >> 4) = 2) Then
                            cbUpdateRate.SelectedIndex = 2
                        End If

                        ' byRecv(61) Channel Mask byte 
                        If ((byRecv(61) And 1) = 1) Then
                            ckCH0.Checked = True
                        Else
                            ckCH0.Checked = False
                        End If

                        If ((byRecv(61) And 2) = 2) Then
                            ckCH1.Checked = True
                        Else
                            ckCH1.Checked = False
                        End If

                        If ((byRecv(61) And 4) = 4) Then
                            ckCH2.Checked = True
                        Else
                            ckCH2.Checked = False
                        End If

                        If ((byRecv(61) And 8) = 8) Then
                            ckCH3.Checked = True
                        Else
                            ckCH3.Checked = False
                        End If

                        If ((byRecv(61) And 16) = 16) Then
                            ckCH4.Checked = True
                        Else
                            ckCH4.Checked = False
                        End If

                        If ((byRecv(61) And 32) = 32) Then
                            ckCH5.Checked = True
                        Else
                            ckCH5.Checked = False
                        End If

                    Next

                Else
                    MessageBox.Show("Function Fail")
                End If

            Else
                MessageBox.Show("Fail: Receive Fail ")
            End If

        Else
            MessageBox.Show("Fail: Send Fail")
        End If

    End Sub

    Private Sub bSetRange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bSetRange.Click
        Dim iRecvLen As Integer = 0
        Dim iLength As Integer = 4 + 10 + 28
        Dim byCmd(4 + 10 + 28) As Byte
        Dim byRecv(256) As Byte
        Dim iSAddr As Integer = 0
        Dim iCAddr As Integer = 0

        'End Device Short Address 
        iSAddr = m_CurrentDeviceNodeConfig.wShortAddr

        'Coordinator ID
        iCAddr = m_iCoordinatorSlaveId

        '4 Bytes 
        byCmd(0) = 255    'Coordinator header
        byCmd(1) = 90    'Coordinator header
        byCmd(2) = Convert.ToByte(iCAddr And 255)                 ' Coordinator ID Low 
        byCmd(3) = Convert.ToByte((iCAddr >> 8) And 255)          ' Coordinator ID High
        ' 10 Bytes
        byCmd(4 + 0) = Convert.ToByte(iSAddr And 255)             'Short Address Low
        byCmd(4 + 1) = Convert.ToByte((iSAddr >> 8) And 255)      'Short Address High

        ' Message 0x0000 Register Query
        byCmd(4 + 2) = 50    'Message Type Low        
        byCmd(4 + 3) = 128    'Message Type High      
        byCmd(4 + 4) = 1    'Packet Version Low
        byCmd(4 + 5) = 0    'Packet Version High
        byCmd(4 + 6) = 1    'Sequence Number Low
        byCmd(4 + 7) = 0    'Sequence Number High
        byCmd(4 + 8) = 0    'CmdCode Low (Reserved)
        byCmd(4 + 9) = 0    'CmdCode High (Reserved)

        ' Ch0~6 Range Code (Little Endian)
        byCmd(14 + 0) = Convert.ToByte(getRangeConfigFromUI(cbCh0) And 255)
        byCmd(14 + 1) = Convert.ToByte((getRangeConfigFromUI(cbCh0) >> 8) And 255)

        byCmd(14 + 2) = Convert.ToByte(getRangeConfigFromUI(cbCh1) And 255)
        byCmd(14 + 3) = Convert.ToByte((getRangeConfigFromUI(cbCh1) >> 8) And 255)

        byCmd(14 + 4) = Convert.ToByte(getRangeConfigFromUI(cbCh2) And 255)
        byCmd(14 + 5) = Convert.ToByte((getRangeConfigFromUI(cbCh2) >> 8) And 255)

        byCmd(14 + 6) = Convert.ToByte(getRangeConfigFromUI(cbCh3) And 255)
        byCmd(14 + 7) = Convert.ToByte((getRangeConfigFromUI(cbCh3) >> 8) And 255)

        byCmd(14 + 8) = Convert.ToByte(getRangeConfigFromUI(cbCh4) And 255)
        byCmd(14 + 9) = Convert.ToByte((getRangeConfigFromUI(cbCh4) >> 8) And 255)

        byCmd(14 + 10) = Convert.ToByte(getRangeConfigFromUI(cbCh5) And 255)
        byCmd(14 + 11) = Convert.ToByte((getRangeConfigFromUI(cbCh5) >> 8) And 255)

        ' Function Config Enable
        byCmd(14 + 12) = 0

        ' Set burn out enable
        If (cbBurnOutEnable.SelectedIndex = 0) Then
            byCmd(14 + 12) = byCmd(14 + 12) Or 1
        Else

            byCmd(14 + 12) = byCmd(14 + 12) And 254
        End If

        ' Set burn out high/low
        If (cbBurnOutPresent.SelectedIndex = 0) Then
            byCmd(14 + 12) = byCmd(14 + 12) And 253  ' Low
        Else
            byCmd(14 + 12) = byCmd(14 + 12) Or 2  ' high
        End If

        ' Set Update Rate Filter Option
        If (cbUpdateRate.SelectedIndex = 0) Then ' Auto
            byCmd(14 + 12) = byCmd(14 + 12) And 207
        ElseIf (cbUpdateRate.SelectedIndex = 1) Then ' 50 Hz
            byCmd(14 + 12) = byCmd(14 + 12) And 207
            byCmd(14 + 12) = byCmd(14 + 12) Or 16
        ElseIf (cbUpdateRate.SelectedIndex = 2) Then ' 60 Hz
            byCmd(14 + 12) = byCmd(14 + 12) And 207
            byCmd(14 + 12) = byCmd(14 + 12) Or 32
        End If

        ' Channel Mask
        byCmd(14 + 13) = 0

        If (ckCH0.Checked) Then
            byCmd(14 + 13) = byCmd(14 + 13) Or 1
        End If

        If (ckCH1.Checked) Then
            byCmd(14 + 13) = byCmd(14 + 13) Or 2
        End If

        If (ckCH2.Checked) Then
            byCmd(14 + 13) = byCmd(14 + 13) Or 4
        End If

        If (ckCH3.Checked) Then
            byCmd(14 + 13) = byCmd(14 + 13) Or 8
        End If

        If (ckCH4.Checked) Then
            byCmd(14 + 13) = byCmd(14 + 13) Or 16
        End If

        If (ckCH5.Checked) Then
            byCmd(14 + 13) = byCmd(14 + 13) Or 32
        End If

        ' reserved
        byCmd(14 + 14) = 119
        byCmd(14 + 15) = 119
        byCmd(14 + 16) = 119
        byCmd(14 + 17) = 119

        ' Tag Name           
        byCmd(14 + 18) = 65
        byCmd(14 + 19) = 85
        byCmd(14 + 20) = 65
        byCmd(14 + 21) = 85
        byCmd(14 + 22) = 65
        byCmd(14 + 23) = 119
        byCmd(14 + 24) = 119
        byCmd(14 + 25) = 119
        byCmd(14 + 26) = 119
        byCmd(14 + 27) = 119

        m_adamCom.SetComPortTimeout(500, 5000, 0, 1000, 0) ' set comport timeout

        m_adamCom.SetPurge(12)

        If (m_adamCom.Send(iLength, byCmd) = (4 + 10 + 28)) Then
            iRecvLen = m_adamCom.Recv(byRecv.Length, byRecv)
            If (iRecvLen >= (10 + 4 + 2)) Then ' 4 Bytes header + 10 Bytes code + 2 Bytes data

                If (byRecv(14) = 0 AndAlso byRecv(15) = 0) Then
                    MessageBox.Show("Set Range Done!")
                Else
                    MessageBox.Show("Function Fail")
                End If

            Else
                MessageBox.Show("Fail: Receive Fail")
            End If

        Else
            MessageBox.Show("Fail: Send Fail")
        End If

    End Sub

    Private Sub tcDeviceInfo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcDeviceInfo.SelectedIndexChanged
        Cursor.Current = Cursors.WaitCursor

        m_iQueryCount = 0
        timerPollingData.Enabled = False
        bPolling.Text = "Polling"
        lPollingTimes.Text = "Polling Times : "

        Try
            If (tcDeviceInfo.SelectedIndex = 0) Then
                RefreshModuleInformation()
            ElseIf (tcDeviceInfo.SelectedIndex = 1) Then
                RefreshDeviceStatus()
            ElseIf (tcDeviceInfo.SelectedIndex = 2) Then
                RefreshChannelInfoPage()
            ElseIf (tcDeviceInfo.SelectedIndex = 3) Then
                RefreshChannelStatus()
            ElseIf (tcDeviceInfo.SelectedIndex = 4) Then
                RefreshSetRangePage()
            ElseIf (tcDeviceInfo.SelectedIndex = 5) Then
                RefreshDeviceListPage()
            End If
        Catch ex As Exception

        End Try

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub tcDeviceInfo_Selecting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles tcDeviceInfo.Selecting
        e.Cancel = Not (CType(e.TabPage, Control)).Enabled
    End Sub

    Private Sub Form1_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        m_iQueryCount = 0
        timerPollingData.Enabled = False
        bPolling.Text = "Polling"
        lPollingTimes.Text = "Polling Times : "
    End Sub

    Private Sub timerPollingData_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerPollingData.Tick
        If (RefreshData()) Then
            m_iQueryCount = m_iQueryCount + 1
            lPollingTimes.Text = "Polling Times : " + m_iQueryCount.ToString()
        Else
            timerPollingData.Enabled = False
            lPollingTimes.Text = "Polling Times : "
            bPolling.Text = "Polling"
        End If
    End Sub
End Class
