<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Form1
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtModule = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtReadCount = New System.Windows.Forms.TextBox
        Me.buttonStart = New System.Windows.Forms.Button
        Me.tabControlMain = New System.Windows.Forms.TabControl
        Me.tabPageDI = New System.Windows.Forms.TabPage
        Me.listViewDiChannelInfo = New System.Windows.Forms.ListView
        Me.ColumnDiInfoLocation = New System.Windows.Forms.ColumnHeader
        Me.ColumnDiInfoType = New System.Windows.Forms.ColumnHeader
        Me.ColumnDiInfoChNo = New System.Windows.Forms.ColumnHeader
        Me.ColumnDiInfoModeValue = New System.Windows.Forms.ColumnHeader
        Me.ColumnDiInfoChValue = New System.Windows.Forms.ColumnHeader
        Me.Label3 = New System.Windows.Forms.Label
        Me.tabPageAO = New System.Windows.Forms.TabPage
        Me.listViewAoChannelInfo = New System.Windows.Forms.ListView
        Me.ColumnAoInfoLocation = New System.Windows.Forms.ColumnHeader
        Me.ColumnAoInfoType = New System.Windows.Forms.ColumnHeader
        Me.ColumnAoInfoChNo = New System.Windows.Forms.ColumnHeader
        Me.ColumnAoInfoValueDec = New System.Windows.Forms.ColumnHeader
        Me.ColumnAoInfoValueHex = New System.Windows.Forms.ColumnHeader
        Me.ColumnAoInfoValueEng = New System.Windows.Forms.ColumnHeader
        Me.ColumnAoInfoRange = New System.Windows.Forms.ColumnHeader
        Me.Label10 = New System.Windows.Forms.Label
        Me.panelAoValueSetting = New System.Windows.Forms.Panel
        Me.btnSetAoValue = New System.Windows.Forms.Button
        Me.labAoHigh = New System.Windows.Forms.Label
        Me.labAoLow = New System.Windows.Forms.Label
        Me.tBarAoOutputVal = New System.Windows.Forms.TrackBar
        Me.txtAoOutputVal = New System.Windows.Forms.TextBox
        Me.txtSelAoChannel = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.btnApplyAoSelRange = New System.Windows.Forms.Button
        Me.cbxAoOutputRange = New System.Windows.Forms.ComboBox
        Me.cbxAoChannel = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer
        Me.tabControlMain.SuspendLayout()
        Me.tabPageDI.SuspendLayout()
        Me.tabPageAO.SuspendLayout()
        Me.panelAoValueSetting.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(17, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 20)
        Me.Label1.Text = "Module name:"
        '
        'txtModule
        '
        Me.txtModule.Location = New System.Drawing.Point(157, 16)
        Me.txtModule.Name = "txtModule"
        Me.txtModule.Size = New System.Drawing.Size(176, 23)
        Me.txtModule.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(17, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 20)
        Me.Label2.Text = "Read count:"
        '
        'txtReadCount
        '
        Me.txtReadCount.Location = New System.Drawing.Point(157, 48)
        Me.txtReadCount.Name = "txtReadCount"
        Me.txtReadCount.Size = New System.Drawing.Size(176, 23)
        Me.txtReadCount.TabIndex = 3
        Me.txtReadCount.Text = "0"
        '
        'buttonStart
        '
        Me.buttonStart.Location = New System.Drawing.Point(396, 16)
        Me.buttonStart.Name = "buttonStart"
        Me.buttonStart.Size = New System.Drawing.Size(95, 47)
        Me.buttonStart.TabIndex = 4
        Me.buttonStart.Text = "Start"
        '
        'tabControlMain
        '
        Me.tabControlMain.Controls.Add(Me.tabPageDI)
        Me.tabControlMain.Controls.Add(Me.tabPageAO)
        Me.tabControlMain.Location = New System.Drawing.Point(5, 86)
        Me.tabControlMain.Name = "tabControlMain"
        Me.tabControlMain.SelectedIndex = 0
        Me.tabControlMain.Size = New System.Drawing.Size(602, 326)
        Me.tabControlMain.TabIndex = 5
        '
        'tabPageDI
        '
        Me.tabPageDI.Controls.Add(Me.listViewDiChannelInfo)
        Me.tabPageDI.Controls.Add(Me.Label3)
        Me.tabPageDI.Location = New System.Drawing.Point(4, 25)
        Me.tabPageDI.Name = "tabPageDI"
        Me.tabPageDI.Size = New System.Drawing.Size(594, 297)
        Me.tabPageDI.Text = "DI"
        '
        'listViewDiChannelInfo
        '
        Me.listViewDiChannelInfo.Columns.Add(Me.ColumnDiInfoLocation)
        Me.listViewDiChannelInfo.Columns.Add(Me.ColumnDiInfoType)
        Me.listViewDiChannelInfo.Columns.Add(Me.ColumnDiInfoChNo)
        Me.listViewDiChannelInfo.Columns.Add(Me.ColumnDiInfoModeValue)
        Me.listViewDiChannelInfo.Columns.Add(Me.ColumnDiInfoChValue)
        Me.listViewDiChannelInfo.Location = New System.Drawing.Point(13, 40)
        Me.listViewDiChannelInfo.Name = "listViewDiChannelInfo"
        Me.listViewDiChannelInfo.Size = New System.Drawing.Size(568, 155)
        Me.listViewDiChannelInfo.TabIndex = 1
        Me.listViewDiChannelInfo.View = System.Windows.Forms.View.Details
        '
        'ColumnDiInfoLocation
        '
        Me.ColumnDiInfoLocation.Text = "Address "
        Me.ColumnDiInfoLocation.Width = 110
        '
        'ColumnDiInfoType
        '
        Me.ColumnDiInfoType.Text = "Type "
        Me.ColumnDiInfoType.Width = 110
        '
        'ColumnDiInfoChNo
        '
        Me.ColumnDiInfoChNo.Text = "Channel"
        Me.ColumnDiInfoChNo.Width = 110
        '
        'ColumnDiInfoModeValue
        '
        Me.ColumnDiInfoModeValue.Text = "Mode"
        Me.ColumnDiInfoModeValue.Width = 110
        '
        'ColumnDiInfoChValue
        '
        Me.ColumnDiInfoChValue.Text = "Value"
        Me.ColumnDiInfoChValue.Width = 125
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(12, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(131, 20)
        Me.Label3.Text = "Channel Information"
        '
        'tabPageAO
        '
        Me.tabPageAO.Controls.Add(Me.listViewAoChannelInfo)
        Me.tabPageAO.Controls.Add(Me.Label10)
        Me.tabPageAO.Controls.Add(Me.panelAoValueSetting)
        Me.tabPageAO.Controls.Add(Me.btnApplyAoSelRange)
        Me.tabPageAO.Controls.Add(Me.cbxAoOutputRange)
        Me.tabPageAO.Controls.Add(Me.cbxAoChannel)
        Me.tabPageAO.Controls.Add(Me.Label6)
        Me.tabPageAO.Controls.Add(Me.Label5)
        Me.tabPageAO.Controls.Add(Me.Label4)
        Me.tabPageAO.Location = New System.Drawing.Point(4, 25)
        Me.tabPageAO.Name = "tabPageAO"
        Me.tabPageAO.Size = New System.Drawing.Size(594, 297)
        Me.tabPageAO.Text = "AO"
        '
        'listViewAoChannelInfo
        '
        Me.listViewAoChannelInfo.Columns.Add(Me.ColumnAoInfoLocation)
        Me.listViewAoChannelInfo.Columns.Add(Me.ColumnAoInfoType)
        Me.listViewAoChannelInfo.Columns.Add(Me.ColumnAoInfoChNo)
        Me.listViewAoChannelInfo.Columns.Add(Me.ColumnAoInfoValueDec)
        Me.listViewAoChannelInfo.Columns.Add(Me.ColumnAoInfoValueHex)
        Me.listViewAoChannelInfo.Columns.Add(Me.ColumnAoInfoValueEng)
        Me.listViewAoChannelInfo.Columns.Add(Me.ColumnAoInfoRange)
        Me.listViewAoChannelInfo.Location = New System.Drawing.Point(8, 165)
        Me.listViewAoChannelInfo.Name = "listViewAoChannelInfo"
        Me.listViewAoChannelInfo.Size = New System.Drawing.Size(576, 120)
        Me.listViewAoChannelInfo.TabIndex = 10
        Me.listViewAoChannelInfo.View = System.Windows.Forms.View.Details
        '
        'ColumnAoInfoLocation
        '
        Me.ColumnAoInfoLocation.Text = "Address"
        Me.ColumnAoInfoLocation.Width = 70
        '
        'ColumnAoInfoType
        '
        Me.ColumnAoInfoType.Text = "Type"
        Me.ColumnAoInfoType.Width = 70
        '
        'ColumnAoInfoChNo
        '
        Me.ColumnAoInfoChNo.Text = "Ch"
        Me.ColumnAoInfoChNo.Width = 45
        '
        'ColumnAoInfoValueDec
        '
        Me.ColumnAoInfoValueDec.Text = "Value[Dec]"
        Me.ColumnAoInfoValueDec.Width = 90
        '
        'ColumnAoInfoValueHex
        '
        Me.ColumnAoInfoValueHex.Text = "Value[Hex]"
        Me.ColumnAoInfoValueHex.Width = 90
        '
        'ColumnAoInfoValueEng
        '
        Me.ColumnAoInfoValueEng.Text = "Value[Eng]"
        Me.ColumnAoInfoValueEng.Width = 90
        '
        'ColumnAoInfoRange
        '
        Me.ColumnAoInfoRange.Text = "Range"
        Me.ColumnAoInfoRange.Width = 118
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(8, 138)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(131, 20)
        Me.Label10.Text = "Channel Information"
        '
        'panelAoValueSetting
        '
        Me.panelAoValueSetting.Controls.Add(Me.btnSetAoValue)
        Me.panelAoValueSetting.Controls.Add(Me.labAoHigh)
        Me.panelAoValueSetting.Controls.Add(Me.labAoLow)
        Me.panelAoValueSetting.Controls.Add(Me.tBarAoOutputVal)
        Me.panelAoValueSetting.Controls.Add(Me.txtAoOutputVal)
        Me.panelAoValueSetting.Controls.Add(Me.txtSelAoChannel)
        Me.panelAoValueSetting.Controls.Add(Me.Label9)
        Me.panelAoValueSetting.Controls.Add(Me.Label8)
        Me.panelAoValueSetting.Controls.Add(Me.Label7)
        Me.panelAoValueSetting.Location = New System.Drawing.Point(224, 9)
        Me.panelAoValueSetting.Name = "panelAoValueSetting"
        Me.panelAoValueSetting.Size = New System.Drawing.Size(360, 146)
        '
        'btnSetAoValue
        '
        Me.btnSetAoValue.Location = New System.Drawing.Point(16, 117)
        Me.btnSetAoValue.Name = "btnSetAoValue"
        Me.btnSetAoValue.Size = New System.Drawing.Size(100, 20)
        Me.btnSetAoValue.TabIndex = 8
        Me.btnSetAoValue.Text = "Apply Output"
        '
        'labAoHigh
        '
        Me.labAoHigh.Location = New System.Drawing.Point(319, 93)
        Me.labAoHigh.Name = "labAoHigh"
        Me.labAoHigh.Size = New System.Drawing.Size(60, 20)
        Me.labAoHigh.Text = "High"
        '
        'labAoLow
        '
        Me.labAoLow.Location = New System.Drawing.Point(17, 94)
        Me.labAoLow.Name = "labAoLow"
        Me.labAoLow.Size = New System.Drawing.Size(60, 20)
        Me.labAoLow.Text = "Low"
        '
        'tBarAoOutputVal
        '
        Me.tBarAoOutputVal.LargeChange = 16
        Me.tBarAoOutputVal.Location = New System.Drawing.Point(12, 54)
        Me.tBarAoOutputVal.Maximum = 4095
        Me.tBarAoOutputVal.Name = "tBarAoOutputVal"
        Me.tBarAoOutputVal.Size = New System.Drawing.Size(337, 45)
        Me.tBarAoOutputVal.TabIndex = 5
        Me.tBarAoOutputVal.TickFrequency = 256
        '
        'txtAoOutputVal
        '
        Me.txtAoOutputVal.Location = New System.Drawing.Point(242, 28)
        Me.txtAoOutputVal.Name = "txtAoOutputVal"
        Me.txtAoOutputVal.Size = New System.Drawing.Size(100, 23)
        Me.txtAoOutputVal.TabIndex = 4
        '
        'txtSelAoChannel
        '
        Me.txtSelAoChannel.Location = New System.Drawing.Point(78, 28)
        Me.txtSelAoChannel.Name = "txtSelAoChannel"
        Me.txtSelAoChannel.ReadOnly = True
        Me.txtSelAoChannel.Size = New System.Drawing.Size(100, 23)
        Me.txtSelAoChannel.TabIndex = 3
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(195, 31)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 20)
        Me.Label9.Text = "Value :     "
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(16, 31)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 20)
        Me.Label8.Text = "Channel : "
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(8, 6)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(114, 20)
        Me.Label7.Text = "Set Output Value"
        '
        'btnApplyAoSelRange
        '
        Me.btnApplyAoSelRange.Location = New System.Drawing.Point(148, 104)
        Me.btnApplyAoSelRange.Name = "btnApplyAoSelRange"
        Me.btnApplyAoSelRange.Size = New System.Drawing.Size(70, 23)
        Me.btnApplyAoSelRange.TabIndex = 5
        Me.btnApplyAoSelRange.Text = "Apply"
        '
        'cbxAoOutputRange
        '
        Me.cbxAoOutputRange.Location = New System.Drawing.Point(89, 75)
        Me.cbxAoOutputRange.Name = "cbxAoOutputRange"
        Me.cbxAoOutputRange.Size = New System.Drawing.Size(129, 23)
        Me.cbxAoOutputRange.TabIndex = 4
        '
        'cbxAoChannel
        '
        Me.cbxAoChannel.Location = New System.Drawing.Point(89, 38)
        Me.cbxAoChannel.Name = "cbxAoChannel"
        Me.cbxAoChannel.Size = New System.Drawing.Size(129, 23)
        Me.cbxAoChannel.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(10, 77)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 20)
        Me.Label6.Text = "Range : "
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(10, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 20)
        Me.Label5.Text = "Channel : "
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(10, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 20)
        Me.Label4.Text = "Output Range"
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(615, 419)
        Me.Controls.Add(Me.tabControlMain)
        Me.Controls.Add(Me.buttonStart)
        Me.Controls.Add(Me.txtReadCount)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtModule)
        Me.Controls.Add(Me.Label1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Text = "Adam6224 Sample Program (VB)"
        Me.tabControlMain.ResumeLayout(False)
        Me.tabPageDI.ResumeLayout(False)
        Me.tabPageAO.ResumeLayout(False)
        Me.panelAoValueSetting.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtModule As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtReadCount As System.Windows.Forms.TextBox
    Friend WithEvents buttonStart As System.Windows.Forms.Button
    Friend WithEvents tabControlMain As System.Windows.Forms.TabControl
    Friend WithEvents tabPageDI As System.Windows.Forms.TabPage
    Friend WithEvents tabPageAO As System.Windows.Forms.TabPage
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents listViewDiChannelInfo As System.Windows.Forms.ListView
    Friend WithEvents ColumnDiInfoLocation As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnDiInfoType As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnDiInfoChNo As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnDiInfoModeValue As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnDiInfoChValue As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbxAoOutputRange As System.Windows.Forms.ComboBox
    Friend WithEvents cbxAoChannel As System.Windows.Forms.ComboBox
    Friend WithEvents btnApplyAoSelRange As System.Windows.Forms.Button
    Friend WithEvents panelAoValueSetting As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtSelAoChannel As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtAoOutputVal As System.Windows.Forms.TextBox
    Friend WithEvents labAoHigh As System.Windows.Forms.Label
    Friend WithEvents labAoLow As System.Windows.Forms.Label
    Friend WithEvents btnSetAoValue As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents listViewAoChannelInfo As System.Windows.Forms.ListView
    Friend WithEvents ColumnAoInfoLocation As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnAoInfoType As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnAoInfoChNo As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnAoInfoValueDec As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnAoInfoValueHex As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnAoInfoValueEng As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnAoInfoRange As System.Windows.Forms.ColumnHeader
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Private WithEvents tBarAoOutputVal As System.Windows.Forms.TrackBar

End Class
