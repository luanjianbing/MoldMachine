Imports System.Net
Imports System.Text
Imports System.Web.Script.Serialization
Imports System.Threading

Public Class Form1
    Dim m_bStart As Boolean
    Dim m_WISEType As WISEType
    Dim m_szIP As String
    Dim m_szAccount As String
    Dim m_szPassword As String
    Dim m_iPort As Integer
    Dim m_iSlot As Integer
    Dim m_iCount As Integer
    Dim m_iDiTotal As Integer
    Dim m_iDoTotal As Integer
    Dim m_iAiTotal As Integer
    Dim m_iPollingTime As Integer
    'for Universal Input channel
    Dim m_bUDiChannelOccurs As Boolean
    Dim m_UDiChannelList As List(Of UiChannelInfo)
    Dim m_iUDiRangeCode As Integer
    'end for Universal Input channel
    Dim m_AIPanelList As List(Of Panel)
    Dim m_DIOPanelList As List(Of Panel)
    Dim m_DIOBtnList As List(Of Button)
    Dim m_AITextBoxList As List(Of TextBox)
    Dim m_AICheckboxList As List(Of CheckBox)
    Dim m_DIOTextBoxList As List(Of TextBox)
    Dim m_HttpRequestDI As AdvantechHttpWebUtility
    Dim m_HttpRequestDO As AdvantechHttpWebUtility
    Dim m_HttpRequestAI As AdvantechHttpWebUtility
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        m_iUDiRangeCode = 480
        m_bStart = False' the action stops at the beginning
        m_szIP = "192.168.100.122" ' device IP address
        m_iPort = 80' Http port is 80
        m_szAccount = "root" ' Login account' Login password
        m_szPassword = "00000000"
        m_iPollingTime = 1000
        m_bUDiChannelOccurs = False
        m_iSlot = 0 'Device localhost default slot is 0

        m_HttpRequestAI = New AdvantechHttpWebUtility
        AddHandler m_HttpRequestAI.ResquestOccurredError, AddressOf Me.OnGetAIHttpRequestError'Delegate callback for resquest value occurred error
        AddHandler m_HttpRequestAI.ResquestResponded, AddressOf Me.OnGetAIData
        m_HttpRequestDI = New AdvantechHttpWebUtility
        AddHandler m_HttpRequestDI.ResquestOccurredError, AddressOf Me.OnGetDIHttpRequestError'Delegate callback for resquest value occurred error
        AddHandler m_HttpRequestDI.ResquestResponded, AddressOf Me.OnGetDIData
        m_HttpRequestDO = New AdvantechHttpWebUtility
        AddHandler m_HttpRequestDO.ResquestOccurredError, AddressOf Me.OnGetDOHttpRequestError'Delegate callback for resquest value occurred error
        AddHandler m_HttpRequestDO.ResquestResponded, AddressOf Me.OnGetDOData
        'm_WISEType = WISEType.WISE4012E 'the sample is for WISE-4012E
        m_WISEType = WISEType.WISE4012 'the sample is for WISE-4012E
        'm_WISEType = WISEType.WISE4010LAN 'the sample is for WISE-4010LAN

        m_UDiChannelList = New List(Of UiChannelInfo)
        m_AITextBoxList = New List(Of TextBox)
        m_AICheckboxList = New List(Of CheckBox)
        m_DIOTextBoxList = New List(Of TextBox)
        m_AIPanelList = New List(Of Panel)
        m_DIOPanelList = New List(Of Panel)
        m_DIOBtnList = New List(Of Button)
        m_DIOBtnList.Add(Me.btnCh0)
        m_DIOBtnList.Add(Me.btnCh1)
        m_DIOBtnList.Add(Me.btnCh2)
        m_DIOBtnList.Add(Me.btnCh3)
        m_AIPanelList.Add(Me.panelAI0)
        m_AIPanelList.Add(Me.panelAI1)
        m_AIPanelList.Add(Me.panelAI2)
        m_AIPanelList.Add(Me.panelAI3)
        m_DIOPanelList.Add(Me.panelDIO0)
        m_DIOPanelList.Add(Me.panelDIO1)
        m_DIOPanelList.Add(Me.panelDIO2)
        m_DIOPanelList.Add(Me.panelDIO3)
        m_AITextBoxList.Add(Me.txtAIValue0)
        m_AITextBoxList.Add(Me.txtAIValue1)
        m_AITextBoxList.Add(Me.txtAIValue2)
        m_AITextBoxList.Add(Me.txtAIValue3)
        m_AICheckboxList.Add(Me.chkboxCh0)
        m_AICheckboxList.Add(Me.chkboxCh1)
        m_AICheckboxList.Add(Me.chkboxCh2)
        m_AICheckboxList.Add(Me.chkboxCh3)
        m_DIOTextBoxList.Add(Me.txtDIOValue0)
        m_DIOTextBoxList.Add(Me.txtDIOValue1)
        m_DIOTextBoxList.Add(Me.txtDIOValue2)
        m_DIOTextBoxList.Add(Me.txtDIOValue3)
        txtModule.Text = m_WISEType.ToString' arrange channel text box
        If (m_WISEType = WISEType.WISE4012) Then
            Initial_WISE_4012()
        ElseIf (m_WISEType = WISEType.WISE4012E) Then
            Initial_WISE_4012E()
        Else
            Initial_WISE_4010LAN()
        End If
    End Sub
    Private Sub Initial_WISE_4010LAN()
        m_iAiTotal = 4
        m_iDoTotal = 4
        InitailForm()
    End Sub

    Private Sub Initial_WISE_4012()
        Dim ui As UiChannelInfo
        m_iAiTotal = 4
        m_iDoTotal = 2
        For index As Integer = 1 To m_iAiTotal
            ui = New UiChannelInfo
            ui.bIsUiChannel = False
            ui.unit = ""
            m_UDiChannelList.Add(ui)
        Next
        InitailForm()
    End Sub

    Private Sub Initial_WISE_4012E()
        m_iAiTotal = 2
        m_iDoTotal = 2
        m_iDiTotal = 2
        InitailForm()
    End Sub

    Private Sub InitailForm()
        Dim aiCh As Integer = 0
        Do While (aiCh < 4)
            If aiCh < m_iAiTotal Then
                m_AIPanelList(aiCh).Visible = True
            Else
                m_AIPanelList(aiCh).Visible = False
            End If
            aiCh = (aiCh + 1)
        Loop
        Dim diCh As Integer = 0
        Do While (diCh < 4)
            If (diCh < m_iDiTotal) Then
                m_DIOBtnList(diCh).Text = "DI"
                m_DIOBtnList(diCh).Enabled = False
            End If
            diCh = (diCh + 1)
        Loop
        Dim doCh As Integer = m_iDiTotal
        Do While (doCh < 4)
            If ((doCh - m_iDiTotal) _
                        < m_iDoTotal) Then
                m_DIOBtnList(doCh).Text = "DO"
            Else
                m_DIOPanelList(doCh).Visible = False
            End If
            doCh = (doCh + 1)
        Loop
    End Sub

    Private Function GetURL(ByVal ip As String, ByVal port As Integer, ByVal requestUri As String) As String
        Return ("http://" _
                    + (ip + (":" _
                    + (port.ToString + ("/" + requestUri)))))
    End Function
    Delegate Sub TextBoxSettingInvoke(ByVal textBox As TextBox, ByVal text As String)
    Private Sub SetTextToTextBox(ByVal textBox As TextBox, ByVal text As String)
        If textBox.InvokeRequired Then
            Dim d As New TextBoxSettingInvoke(AddressOf Me.SetTextToTextBox)
            textBox.Invoke(d, New Object() {textBox, text})
        Else
            textBox.Text = text
        End If
    End Sub
    Delegate Sub CheckBoxSettingInvoke(ByVal checkBox As CheckBox, ByVal status As Boolean)
    Private Sub SetCheckedToCheckBox(ByVal checkBox As CheckBox, ByVal status As Boolean)
        If checkBox.InvokeRequired Then
            Dim d As New CheckBoxSettingInvoke(AddressOf Me.SetCheckedToCheckBox)
            checkBox.Invoke(d, New Object() {checkBox, status})
        Else
            checkBox.Checked = status
        End If
    End Sub

    Private Sub OnGetAIHttpRequestError(ByVal e As Exception)
        Dim errorMsg As String = e.Message
        Dim i As Integer = 0
        Do While (i < m_iAiTotal)
            SetTextToTextBox(m_AITextBoxList(i), errorMsg)
            i = (i + 1)
        Loop
        RefreshIOStatus()
    End Sub

    Private Sub OnGetDIHttpRequestError(ByVal e As Exception)
        Dim errorMsg As String = e.Message
        Dim i As Integer = 0
        Do While (i < m_iDiTotal)
            SetTextToTextBox(m_DIOTextBoxList(i), errorMsg)
            i = (i + 1)
        Loop
        RefreshIOStatus()
    End Sub

    Private Sub OnGetDOHttpRequestError(ByVal e As Exception)
        Dim errorMsg As String = e.Message
        Dim i As Integer = 0
        Do While (i < m_iDoTotal)
            SetTextToTextBox(m_DIOTextBoxList((i + m_iDiTotal)), errorMsg)
            i = (i + 1)
        Loop
        RefreshIOStatus()
    End Sub

    Private Sub UpdateAIUIStatus(ByVal ai_values As AISlotValueData)
        Try
            If (Not (ai_values.AIVal) Is Nothing) Then
                Dim i As Integer = 0
                Do While (i < (ai_values.AIVal.Length - 1))
                    Dim textboxIndex As Integer = ai_values.AIVal(i).Ch
                    If (ai_values.AIVal(i).En > 0) Then
                        Dim channel As Integer = ai_values.AIVal(i).Ch
                        Dim rangeCode As Integer = ai_values.AIVal(i).Rng
                        Dim aiEvent As Integer = ai_values.AIVal(i).Evt
                        Dim value As String
                        value = String.Empty

                        If (m_WISEType = WISEType.WISE4012 And rangeCode = m_iUDiRangeCode) Then 'UI mode
                            m_UDiChannelList(channel).bIsUiChannel = True 'mark channel as UI channel
                            m_UDiChannelList(channel).unit = WISE_AI_RangeInformation.GetUnit(rangeCode)
                            m_bUDiChannelOccurs = True
                            i = (i + 1)
                            Continue Do
                        Else
                            If (m_WISEType = WISEType.WISE4012) Then 'WISE-4012 has UI channel
                                m_UDiChannelList(channel).bIsUiChannel = False 'mark channel as AI channel
                            End If

                            If (m_WISEType = WISEType.WISE4012E And ai_values.AIVal(i).Eg <> 0) Then 'Eg only exists in WISE-4012E old version
                                If (ai_values.AIVal(i).Evt > 0) Then
                                    value = WISE_AI_RangeInformation.GetEvent(aiEvent)
                                Else
                                    value = (ai_values.AIVal(i).Eg / 1000.0).ToString("0.000") + " " + WISE_AI_RangeInformation.GetUnit(rangeCode)
                                End If
                            Else
                                Dim unit As String = WISE_AI_RangeInformation.GetUnit(rangeCode)
                                Dim engineerFloatValue As Single = ai_values.AIVal(i).EgF
                                If (unit = "V" Or unit = "A") Then
                                    engineerFloatValue = engineerFloatValue / 1000
                                    If (ai_values.AIVal(i).Evt > 0) Then
                                        value = WISE_AI_RangeInformation.GetEvent(aiEvent)
                                    Else
                                        value = (Math.Truncate(engineerFloatValue * 10000) / 10000).ToString("0.0000") + " " + unit
                                    End If
                                Else 'mV or mA
                                    If (ai_values.AIVal(i).Evt > 0) Then
                                        value = WISE_AI_RangeInformation.GetEvent(aiEvent)
                                    Else
                                        value = engineerFloatValue.ToString("0.0000") + " " + unit
                                    End If
                                End If
                            End If
                        End If
                        SetTextToTextBox(m_AITextBoxList(textboxIndex), value)
                    Else
                        SetTextToTextBox(m_AITextBoxList(textboxIndex), "")
                    End If
                    i = (i + 1)

                    SetCheckedToCheckBox(m_AICheckboxList(textboxIndex), Convert.ToBoolean(ai_values.AIVal(i).En))
                Loop
            Else
                Throw New Exception("Parser AI Data Fail")
            End If
        Catch e As Exception
            OnGetAIHttpRequestError(e)
        Finally
            System.GC.Collect()
        End Try
    End Sub

    Private Sub UpdateDIUIStatus(ByVal di_values As DISlotValueData)
        Try
            Dim i As Integer = 0
            If (Not (di_values.DIVal) Is Nothing) Then
                If (m_bUDiChannelOccurs) Then 'check Universal Input channel
                    Do While (i < di_values.DIVal.Length)
                        Dim textboxIndex As Integer = di_values.DIVal(i).Ch
                        If (m_UDiChannelList(textboxIndex).bIsUiChannel) Then
                            Dim value = m_UDiChannelList(textboxIndex).unit + " "
                            value += di_values.DIVal(i).Val.ToString()
                            SetTextToTextBox(m_AITextBoxList(textboxIndex), value)
                        End If
                        i = (i + 1)
                    Loop
                End If

                i = 0
                Do While (i < di_values.DIVal.Length)
                    Dim textboxIndex As Integer = di_values.DIVal(i).Ch
                    SetTextToTextBox(m_DIOTextBoxList(textboxIndex), di_values.DIVal(i).Val.ToString)
                    i = (i + 1)
                Loop
            Else
                Throw New Exception("Parser DI Data Fail")
            End If
        Catch e As Exception
            OnGetDIHttpRequestError(e)
        Finally
            System.GC.Collect()
        End Try
    End Sub

    Private Sub UpdateDOUIStatus(ByVal do_values As DOSlotValueData)
        Try
            If (Not (do_values.DOVal) Is Nothing) Then
                Dim i As Integer = 0
                Do While (i < do_values.DOVal.Length)
                    Dim textboxIndex As Integer = (do_values.DOVal(i).Ch + m_iDiTotal)
                    SetTextToTextBox(m_DIOTextBoxList(textboxIndex), do_values.DOVal(i).Val.ToString)
                    i = (i + 1)
                Loop
            Else
                Throw New Exception("Parser DO Data Fail")
            End If
        Catch e As Exception
            OnGetDOHttpRequestError(e)
        Finally
            System.GC.Collect()
        End Try
    End Sub

    Private Sub buttonStart_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonStart.Click
        If m_bStart Then
            panelDIO.Enabled = False
            m_bStart = False' starting flag
            buttonStart.Text = "Start"
        Else
            panelDIO.Enabled = True
            m_iCount = 0' reset the reading counter
            buttonStart.Text = "Stop"
            m_bStart = True 'starting flag
            InvokeReadStatus()
        End If
    End Sub

    Private Sub GetDIValue()
        m_HttpRequestDI.SendGETRequest(Me.m_szAccount, Me.m_szPassword, GetURL(Me.m_szIP, Me.m_iPort, (WISE_RESTFUL_URI.di_value.ToString + ("/slot_" + Me.m_iSlot.ToString))))
    End Sub

    Private Sub GetDOValue()
        m_HttpRequestDO.SendGETRequest(Me.m_szAccount, Me.m_szPassword, GetURL(Me.m_szIP, Me.m_iPort, (WISE_RESTFUL_URI.do_value.ToString + ("/slot_" + Me.m_iSlot.ToString))))
    End Sub

    Private Sub GetAIValue()
        m_HttpRequestAI.SendGETRequest(Me.m_szAccount, Me.m_szPassword, GetURL(Me.m_szIP, Me.m_iPort, (WISE_RESTFUL_URI.ai_value.ToString + ("/slot_" + Me.m_iSlot.ToString))))
    End Sub

    Private Sub RefreshIOStatus()
        SetTextToTextBox(txtReadCount, "Requesting http...")
        If (Me.m_iAiTotal > 0) Then
            GetAIValue()
        ElseIf (Me.m_iDiTotal > 0) Then
            GetDIValue()
        ElseIf (Me.m_iDoTotal > 0) Then
            GetDOValue()
        End If
    End Sub

    Private Sub OnGetDIData(ByVal rawData As String)
        Dim dateObj As DISlotValueData = AdvantechHttpWebUtility.ParserJsonToObj(Of DISlotValueData)(rawData)
        UpdateDIUIStatus(dateObj)
        If (Me.m_iDoTotal > 0) Then
            GetDOValue()
        Else
            InvokeReadStatus()
        End If
    End Sub

    Private Sub OnGetDOData(ByVal rawData As String)
        Dim dateObj As DOSlotValueData = AdvantechHttpWebUtility.ParserJsonToObj(Of DOSlotValueData)(rawData)
        UpdateDOUIStatus(dateObj)
        InvokeReadStatus()
    End Sub

    Private Sub OnGetAIData(ByVal rawData As String)
        Dim dateObj As AISlotValueData = AdvantechHttpWebUtility.ParserJsonToObj(Of AISlotValueData)(rawData)
        UpdateAIUIStatus(dateObj)
        If (Me.m_iDiTotal > 0 Or m_bUDiChannelOccurs) Then
            GetDIValue()
        ElseIf (Me.m_iDoTotal > 0) Then
            GetDOValue()
        Else
            RefreshIOStatus()
        End If
    End Sub

    Private Sub InvokeReadStatus()
        m_iCount = (m_iCount + 1)
        ' increment the reading counter
        SetTextToTextBox(txtReadCount, ("Request http " _
                        + (m_iCount.ToString + " times...")))
        Thread.Sleep(m_iPollingTime)
        If Me.m_bStart Then
            RefreshIOStatus()
        End If
    End Sub

    Private Sub timer1_Tick(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Private Sub btnCh_Click(ByVal i_iCh As Integer, ByVal txtBox As TextBox)
        Dim doData As DOSetValueData = New DOSetValueData
        If txtBox.Text = "1" Then
            doData.Val = 0 ' was ON, now set to OFF 
        Else
            doData.Val = 1
        End If

        Dim iChannel As Integer = (i_iCh - m_iDiTotal)
        Dim serializer As JavaScriptSerializer = New JavaScriptSerializer
        Dim sz_Jsonify As String = serializer.Serialize(doData)
        Try
            Dim httpRequest As AdvantechHttpWebUtility = New AdvantechHttpWebUtility
            httpRequest.SendPATCHRequest(m_szAccount, m_szPassword, GetURL(m_szIP, m_iPort, (WISE_RESTFUL_URI.do_value.ToString + ("/slot_" _
                                + (m_iSlot.ToString + ("/ch_" + iChannel.ToString))))), sz_Jsonify)
        Catch
            MessageBox.Show("Set digital output failed!", "Error")
        Finally
            System.GC.Collect()
        End Try
    End Sub

    Private Sub btnCh0_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCh0.Click
        btnCh_Click(0, txtDIOValue0)
    End Sub

    Private Sub btnCh1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCh1.Click
        btnCh_Click(1, txtDIOValue1)
    End Sub

    Private Sub btnCh2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCh2.Click
        btnCh_Click(2, txtDIOValue2)
    End Sub

    Private Sub btnCh3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCh3.Click
        btnCh_Click(3, txtDIOValue3)
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs)
        If m_bStart Then
            m_bStart = Not m_bStart
        End If
    End Sub
End Class

''' <summary>
'''emun WISE series device
''' </summary>
Public Enum WISEType
    WISE4010LAN = 4010
    WISE4050LAN = 4050
    WISE4060LAN = 4060
    WISE4012 = 24012
    WISE4012E = 34012
    WISE4050 = 24050
    WISE4060 = 24060
End Enum
Public Class WISE_AI_RangeInformation

    Public Shared EventStatusEmun() As String = {"Fail to provide AI value (UART timeout)", "Over Range", "Under Range", "Open Circuit (Burnout)", "Reserved", "Unavailable Channel Configuration", "Reserved", "ADC initializing/Error", "Reserved", "Zero/Span Calibration Error"}

    Public Shared Function GetUnit(ByVal code As Integer) As String
        Select Case (code)
            Case 259, 260, 261, 262
                Return "mV"
            Case 328, 320, 321, 322, 323, 325, 327
                Return "V"
            Case 384, 385, 386
                Return "mA"
            Case 480 'UI Mode
                Return "(UI Mode)"
        End Select
        Return "Invalid Code"
    End Function

    Public Shared Function GetEvent(ByVal evtMask As Integer) As String
        Dim eventStatus As String = ""
        Dim evtEmunLength As Integer = EventStatusEmun.Length
        Dim mask As UInteger = CType(evtMask, UInteger)
        Dim i As Integer = 0
        Do While (i <= evtEmunLength)
            If ((mask And 1) = 1) Then
                eventStatus = (eventStatus _
                            + (EventStatusEmun(i) + " "))
            End If
            mask = mask >> 1
            i = (i + 1)
        Loop
        Return eventStatus
    End Function
End Class

''' <summary>
''' Universal Input channel information Object
''' </summary>
Public Class UiChannelInfo
    Public bIsUiChannel As Boolean
    Public unit As String
End Class
''' <summary>
''' Do value object
''' </summary>
Public Class DOValueData
    Private m_iCh As Integer 'Channel Number
    Public Property Ch() As Integer
        Get
            Return m_iCh
        End Get
        Set(ByVal value As Integer)
            m_iCh = value
        End Set
    End Property
    Private m_iMd As Integer 'Mode
    Public Property Md() As Integer
        Get
            Return m_iMd
        End Get
        Set(ByVal value As Integer)
            m_iMd = value
        End Set
    End Property
    Private m_iStat As Integer 'Signal Logic Status
    Public Property Stat() As Integer
        Get
            Return m_iStat
        End Get
        Set(ByVal value As Integer)
            m_iStat = value
        End Set
    End Property
    Private m_iVal As UInteger 'Channel Value
    Public Property Val() As UInteger
        Get
            Return m_iVal
        End Get
        Set(ByVal value As UInteger)
            m_iVal = value
        End Set
    End Property
    Private m_iPsCtn As Integer 'Pulse Output Continue State
    Public Property PsCtn() As Integer
        Get
            Return m_iPsCtn
        End Get
        Set(ByVal value As Integer)
            m_iPsCtn = value
        End Set
    End Property
    Private m_iPsStop As Integer 'Stop Pulse Output
    Public Property PsStop() As Integer
        Get
            Return m_iPsStop
        End Get
        Set(ByVal value As Integer)
            m_iPsStop = value
        End Set
    End Property
    Private m_iPsIV As UInteger 'Incremental Pulse Output Value
    Public Property PsIV() As UInteger
        Get
            Return m_iPsIV
        End Get
        Set(ByVal value As UInteger)
            m_iPsIV = value
        End Set
    End Property
End Class
Public Class DOSetValueData
    Private m_iVal As UInteger 'Channel Value
    Public Property Val() As UInteger
        Get
            Return m_iVal
        End Get
        Set(ByVal value As UInteger)
            m_iVal = value
        End Set
    End Property
End Class
Public Class DOSlotValueData
    Private m_iDOVal As DOValueData() 'Channel Value
    Public Property DOVal() As DOValueData()
        Get
            Return m_iDOVal
        End Get
        Set(ByVal value As DOValueData())
            m_iDOVal = value
        End Set
    End Property
End Class
''' <summary>
''' DI value object
''' </summary>
Public Class DIValueData
    Private m_iCh As Integer 'Channel Number
    Public Property Ch() As Integer
        Get
            Return m_iCh
        End Get
        Set(ByVal value As Integer)
            m_iCh = value
        End Set
    End Property
    Private m_iMd As Integer 'Mode
    Public Property Md() As Integer
        Get
            Return m_iMd
        End Get
        Set(ByVal value As Integer)
            m_iMd = value
        End Set
    End Property
    Private m_iVal As UInteger 'Channel Value
    Public Property Val() As UInteger
        Get
            Return m_iVal
        End Get
        Set(ByVal value As UInteger)
            m_iVal = value
        End Set
    End Property
    Private m_iStat As Integer 'Signal Logic Status
    Public Property Stat() As Integer
        Get
            Return m_iStat
        End Get
        Set(ByVal value As Integer)
            m_iStat = value
        End Set
    End Property
    Private m_iCnting As Integer 'Start Counter
    Public Property Cnting() As Integer
        Get
            Return m_iCnting
        End Get
        Set(ByVal value As Integer)
            m_iCnting = value
        End Set
    End Property
    Private m_iOvLch As Integer 'Get/Clear Counter Overflow or Latch Status
    Public Property OvLch() As Integer
        Get
            Return OvLch
        End Get
        Set(ByVal value As Integer)
            m_iOvLch = value
        End Set
    End Property
End Class
Public Class DISlotValueData
    Private m_iDIVal As DIValueData() 'Values
    Public Property DIVal() As DIValueData()
        Get
            Return m_iDIVal
        End Get
        Set(ByVal value As DIValueData())
            m_iDIVal = value
        End Set
    End Property
End Class

''' <summary>
''' AI slot value object
''' </summary>
Public Class AISlotValueData
    Private m_AIVal As AIValueData()
    Public Property AIVal() As AIValueData()
        Get
            Return m_AIVal
        End Get
        Set(ByVal value As AIValueData())
            m_AIVal = value
        End Set
    End Property
End Class
''' <summary>
''' AI channel value object
''' </summary>
Public Class AIValueData
    Private m_iCh As Integer 'Channel Number
    Public Property Ch() As Integer
        Get
            Return m_iCh
        End Get
        Set(ByVal value As Integer)
            m_iCh = value
        End Set
    End Property
    Private m_iEn As Integer 'Is Enable
    Public Property En() As Integer
        Get
            Return m_iEn
        End Get
        Set(ByVal value As Integer)
            m_iEn = value
        End Set
    End Property
    Private m_iRng As Integer 'Range
    Public Property Rng() As Integer
        Get
            Return m_iRng
        End Get
        Set(ByVal value As Integer)
            m_iRng = value
        End Set
    End Property
    Private m_iVal As Integer 'Channel Raw Value
    Public Property Val() As Integer
        Get
            Return m_iVal
        End Get
        Set(ByVal value As Integer)
            m_iVal = value
        End Set
    End Property
    Private m_iEg As Integer 'Engineering Value
    Public Property Eg() As Integer
        Get
            Return m_iEg
        End Get
        Set(ByVal value As Integer)
            m_iEg = value
        End Set
    End Property
    Private m_iEvt As Integer 'Event Status
    Public Property Evt() As Integer
        Get
            Return m_iEvt
        End Get
        Set(ByVal value As Integer)
            m_iEvt = value
        End Set
    End Property
    Private m_iLoA As Integer 'Low Alarm Status
    Public Property LoA() As Integer
        Get
            Return m_iLoA
        End Get
        Set(ByVal value As Integer)
            m_iLoA = value
        End Set
    End Property
    Private m_iHiA As Integer 'High Alarm Status
    Public Property HiA() As Integer
        Get
            Return m_iHiA
        End Get
        Set(ByVal value As Integer)
            m_iHiA = value
        End Set
    End Property
    Private m_iHVal As Integer 'Maximum AI Raw Value
    Public Property HVal() As Integer
        Get
            Return m_iHVal
        End Get
        Set(ByVal value As Integer)
            m_iHVal = value
        End Set
    End Property
    Private m_iHEg As Integer  'Maximum AI Engineering data
    Public Property HEg() As Integer
        Get
            Return m_iHEg
        End Get
        Set(ByVal value As Integer)
            m_iHEg = value
        End Set
    End Property
    Private m_iLVal As Integer  'Minimum AI Raw Value
    Public Property LVal() As Integer
        Get
            Return m_iLVal
        End Get
        Set(ByVal value As Integer)
            m_iLVal = value
        End Set
    End Property
    Private m_iLEg As Integer  'Minimum AI Engineering data
    Public Property LEg() As Integer
        Get
            Return m_iLEg
        End Get
        Set(ByVal value As Integer)
            m_iLEg = value
        End Set
    End Property
    Private m_iSVal As Integer  'Channel Raw Value After Scaling
    Public Property SVal() As Integer
        Get
            Return m_iSVal
        End Get
        Set(ByVal value As Integer)
            m_iSVal = value
        End Set
    End Property
    Private m_iClrH As Integer  'Clear Maximum AI Value
    Public Property ClrH() As Integer
        Get
            Return m_iClrH
        End Get
        Set(ByVal value As Integer)
            m_iClrH = value
        End Set
    End Property
    Private m_iClrL As Integer  'Clear Minimum AI Value
    Public Property ClrL() As Integer
        Get
            Return m_iClrL
        End Get
        Set(ByVal value As Integer)
            m_iClrL = value
        End Set
    End Property

    Private m_EgF As Single  'Channel Engineering data(floating type)
    Public Property EgF() As Single
        Get
            Return m_EgF
        End Get
        Set(ByVal value As Single)
            m_EgF = value
        End Set
    End Property
    Private m_HEgF As Single  'Maximum AI Engineering data(floating type)
    Public Property HEgF() As Single
        Get
            Return m_HEgF
        End Get
        Set(ByVal value As Single)
            m_HEgF = value
        End Set
    End Property
    Private m_LEgF As Single  'Minimum AI Engineering data(floating type)
    Public Property LEgF() As Single
        Get
            Return m_LEgF
        End Get
        Set(ByVal value As Single)
            m_LEgF = value
        End Set
    End Property

End Class
''' <summary>
'''emun WISE series Restful URI 
''' </summary>
Public Enum WISE_RESTFUL_URI
    config
    file_xfer
    profile
    sys_info
    gen_config
    control
    net_basic
    net_config
    di_config
    di_value
    do_config
    do_value
    ai_genconfig
    ai_config
    ai_value
    modbus_coilconfig
    modbus_regconfig
    modbus_coilbas
    modbus_coillen
    modbus_regbas
    modbus_reglen
    accessctrl
    log_dataoption
    log_control
    log_output
    log_message
    log_event
    logex_output
    logex_file
    logex_list
    datastream
    p2p_mode
    p2p_basic
    p2p_advanced
    wlan_config
End Enum
''' <summary>
'''emun Http request method
''' </summary>
Public Enum HttpRequestOption
    HTTP_GET
    HTTP_PATCH
End Enum
Public Delegate Sub ResquestRespondedCallback(ByVal raw_data As String)
Public Delegate Sub ResquestOccurredErrorCallback(ByVal e As Exception)
Public Class AdvantechHttpWebUtility
    Private m_szBasicAuthAccount As String
    Private m_szBasicAuthPassword As String
    Private m_szURL As String
    Private m_szJsonifyString As String
    Private m_bHasDatag As Boolean
    Private m_Method As HttpRequestOption
    Public Event ResquestResponded As ResquestRespondedCallback
    Public Event ResquestOccurredError As ResquestOccurredErrorCallback

    Protected Property BasicAuthAccount() As String
        Get
            Return m_szBasicAuthAccount
        End Get
        Set(ByVal value As String)
            m_szBasicAuthAccount = value
        End Set
    End Property

    Protected Property BasicAuthPassword() As String
        Get
            Return m_szBasicAuthPassword
        End Get
        Set(ByVal value As String)
            m_szBasicAuthPassword = value
        End Set
    End Property

    Protected Property URL() As String
        Get
            Return m_szURL
        End Get
        Set(ByVal value As String)
            m_szURL = value
        End Set
    End Property

    Protected Property JsonifyString() As String
        Get
            Return m_szJsonifyString
        End Get
        Set(ByVal value As String)
            m_szJsonifyString = value
        End Set
    End Property

    Protected Property HasData() As Boolean
        Get
            Return m_bHasDatag
        End Get
        Set(ByVal value As Boolean)
            m_bHasDatag = value
        End Set
    End Property

    Protected Property Method() As HttpRequestOption
        Get
            Return m_Method
        End Get
        Set(ByVal value As HttpRequestOption)
            m_Method = value
        End Set
    End Property

    Public Sub New()
        MyBase.New()
    End Sub

    ''' <summary>
    ''' Invoke ResquestResponded Callback function
    ''' </summary>
    ''' <param name="raw_data"></param>
    Protected Overridable Sub OnResquestResponded(ByVal raw_data As String)
        Try
            RaiseEvent ResquestResponded(raw_data)
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Function ParserJsonToObj(Of T)(ByVal jsonifyString As String)
        Dim serializer As JavaScriptSerializer = New JavaScriptSerializer
        Dim values As T = serializer.Deserialize(Of T)(jsonifyString)
        Return values
    End Function

    ''' <summary>
    ''' Invoke ResquestOccurredError Callback function
    ''' </summary>
    ''' <param name="e"></param>
    Protected Overridable Sub OnResquestOccurredError(ByVal e As Exception)
        Try
            RaiseEvent ResquestOccurredError(e)
        Catch ex As Exception
        End Try
    End Sub

    Public Sub SendGETRequest(ByVal account As String, ByVal password As String, ByVal URL As String)
        Me.BasicAuthAccount = account
        Me.BasicAuthPassword = password
        Me.URL = URL
        Me.HasData = False
        Me.Method = HttpRequestOption.HTTP_GET
        SendRequest()
    End Sub

    Public Sub SendPATCHRequest(ByVal account As String, ByVal password As String, ByVal URL As String, ByVal JSONString As String)
        Me.BasicAuthAccount = account
        Me.BasicAuthPassword = password
        Me.URL = URL
        Me.JsonifyString = JSONString
        Me.HasData = True
        Me.Method = HttpRequestOption.HTTP_PATCH
        SendRequest()
    End Sub

    Protected Sub SendRequest()
        Dim myRequest As HttpWebRequest
        Dim outputStream As System.IO.Stream ' End the stream request operation
        myRequest = CType(WebRequest.Create(Me.URL), HttpWebRequest) ' create request
        myRequest.Headers.Add("Authorization", ("Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes((Me.BasicAuthAccount + (":" + Me.BasicAuthPassword))))))
        myRequest.Method = Method.ToString.Substring(5)
        myRequest.KeepAlive = False
        myRequest.ContentType = "application/x-www-form-urlencoded"
        myRequest.ReadWriteTimeout = 1000 ' Create the patch data
        If Me.HasData Then
            Dim byData() As Byte = Encoding.ASCII.GetBytes(Me.JsonifyString) ' convert POST data to bytes
            myRequest.ContentLength = byData.Length ' Add the post data to the web request
            outputStream = myRequest.GetRequestStream
            outputStream.Write(byData, 0, byData.Length)
            outputStream.Close()
        End If
        Try
            myRequest.BeginGetResponse(New AsyncCallback(AddressOf Me.GetResponsetStreamCallback), myRequest)
        Catch e As Exception
            OnResquestOccurredError(e)
        End Try
    End Sub

    Private Sub GetResponsetStreamCallback(ByVal callbackResult As IAsyncResult)
        Dim bRet As Boolean
        bRet = False
        Dim request As HttpWebRequest = CType(callbackResult.AsyncState, HttpWebRequest)
        Dim result As String = ""
        Try
            Dim response As HttpWebResponse = CType(request.EndGetResponse(callbackResult), HttpWebResponse)
            Dim httpWebStreamReader As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream)
            If (response.StatusCode = HttpStatusCode.OK) Then
                result = httpWebStreamReader.ReadToEnd
                bRet = True
            Else
                OnResquestOccurredError(New Exception(response.StatusCode.ToString))
            End If
            response.Close()
        Catch e As Exception
            OnResquestOccurredError(e)
        Finally
            request.Abort()
            If (bRet = True) Then
                OnResquestResponded(result)
            End If
        End Try
    End Sub
End Class