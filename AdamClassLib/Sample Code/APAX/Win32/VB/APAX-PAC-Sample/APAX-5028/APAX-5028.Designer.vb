<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_APAX_5028
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Btn_Quit = New System.Windows.Forms.Button
        Me.btnStart = New System.Windows.Forms.Button
        Me.StatusBar_IO = New System.Windows.Forms.StatusBar
        Me.tcRemote = New System.Windows.Forms.TabControl
        Me.tabModuleInfo = New System.Windows.Forms.TabPage
        Me.btnLocate = New System.Windows.Forms.Button
        Me.lblLocate = New System.Windows.Forms.Label
        Me.txtModuleID = New System.Windows.Forms.TextBox
        Me.txtSWID = New System.Windows.Forms.TextBox
        Me.txtFwVer = New System.Windows.Forms.TextBox
        Me.txtSupportKernelFw = New System.Windows.Forms.TextBox
        Me.labModule = New System.Windows.Forms.Label
        Me.labID = New System.Windows.Forms.Label
        Me.labFwVer = New System.Windows.Forms.Label
        Me.labSupportKernelFw = New System.Windows.Forms.Label
        Me.tbAO = New System.Windows.Forms.TabPage
        Me.listViewChInfo = New System.Windows.Forms.ListView
        Me.clmType = New System.Windows.Forms.ColumnHeader
        Me.clmCh = New System.Windows.Forms.ColumnHeader
        Me.clmValue = New System.Windows.Forms.ColumnHeader
        Me.clmRange = New System.Windows.Forms.ColumnHeader
        Me.clmStart = New System.Windows.Forms.ColumnHeader
        Me.clmSafety = New System.Windows.Forms.ColumnHeader
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.panelSafetyFunction = New System.Windows.Forms.Panel
        Me.btnSetSafetyValue = New System.Windows.Forms.Button
        Me.chbxEnableSafety = New System.Windows.Forms.CheckBox
        Me.label2 = New System.Windows.Forms.Label
        Me.panelSetting = New System.Windows.Forms.Panel
        Me.chbxApplyAll = New System.Windows.Forms.CheckBox
        Me.cbxRange = New System.Windows.Forms.ComboBox
        Me.labRange = New System.Windows.Forms.Label
        Me.btnApplySelRange = New System.Windows.Forms.Button
        Me.panelOutputValue = New System.Windows.Forms.Panel
        Me.txtSelChannel = New System.Windows.Forms.TextBox
        Me.btnSetAsSafety = New System.Windows.Forms.Button
        Me.btnApplyOutput = New System.Windows.Forms.Button
        Me.labLow = New System.Windows.Forms.Label
        Me.labHigh = New System.Windows.Forms.Label
        Me.tBarOutputVal = New System.Windows.Forms.TrackBar
        Me.txtOutputVal = New System.Windows.Forms.TextBox
        Me.labOutputVal = New System.Windows.Forms.Label
        Me.btnSetAsStartup = New System.Windows.Forms.Button
        Me.labChannel = New System.Windows.Forms.Label
        Me.panelMain = New System.Windows.Forms.Panel
        Me.chbxShowRawData = New System.Windows.Forms.CheckBox
        Me.chbxHide = New System.Windows.Forms.CheckBox
        Me.tcRemote.SuspendLayout()
        Me.tabModuleInfo.SuspendLayout()
        Me.tbAO.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.panelSafetyFunction.SuspendLayout()
        Me.panelSetting.SuspendLayout()
        Me.panelOutputValue.SuspendLayout()
        CType(Me.tBarOutputVal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'Btn_Quit
        '
        Me.Btn_Quit.Location = New System.Drawing.Point(440, 378)
        Me.Btn_Quit.Name = "Btn_Quit"
        Me.Btn_Quit.Size = New System.Drawing.Size(73, 21)
        Me.Btn_Quit.TabIndex = 25
        Me.Btn_Quit.Text = "Quit"
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(361, 378)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(73, 21)
        Me.btnStart.TabIndex = 24
        Me.btnStart.Text = "Start"
        '
        'StatusBar_IO
        '
        Me.StatusBar_IO.Location = New System.Drawing.Point(0, 403)
        Me.StatusBar_IO.Name = "StatusBar_IO"
        Me.StatusBar_IO.Size = New System.Drawing.Size(525, 24)
        Me.StatusBar_IO.TabIndex = 26
        '
        'tcRemote
        '
        Me.tcRemote.Controls.Add(Me.tabModuleInfo)
        Me.tcRemote.Controls.Add(Me.tbAO)
        Me.tcRemote.Dock = System.Windows.Forms.DockStyle.Top
        Me.tcRemote.Enabled = False
        Me.tcRemote.Location = New System.Drawing.Point(0, 0)
        Me.tcRemote.Name = "tcRemote"
        Me.tcRemote.SelectedIndex = 0
        Me.tcRemote.Size = New System.Drawing.Size(525, 376)
        Me.tcRemote.TabIndex = 23
        Me.tcRemote.Visible = False
        '
        'tabModuleInfo
        '
        Me.tabModuleInfo.Controls.Add(Me.btnLocate)
        Me.tabModuleInfo.Controls.Add(Me.lblLocate)
        Me.tabModuleInfo.Controls.Add(Me.txtModuleID)
        Me.tabModuleInfo.Controls.Add(Me.txtSWID)
        Me.tabModuleInfo.Controls.Add(Me.txtFwVer)
        Me.tabModuleInfo.Controls.Add(Me.txtSupportKernelFw)
        Me.tabModuleInfo.Controls.Add(Me.labModule)
        Me.tabModuleInfo.Controls.Add(Me.labID)
        Me.tabModuleInfo.Controls.Add(Me.labFwVer)
        Me.tabModuleInfo.Controls.Add(Me.labSupportKernelFw)
        Me.tabModuleInfo.Location = New System.Drawing.Point(4, 22)
        Me.tabModuleInfo.Name = "tabModuleInfo"
        Me.tabModuleInfo.Size = New System.Drawing.Size(517, 350)
        Me.tabModuleInfo.TabIndex = 0
        Me.tabModuleInfo.Text = "Module Information"
        '
        'btnLocate
        '
        Me.btnLocate.Location = New System.Drawing.Point(135, 129)
        Me.btnLocate.Name = "btnLocate"
        Me.btnLocate.Size = New System.Drawing.Size(72, 20)
        Me.btnLocate.TabIndex = 50
        Me.btnLocate.Text = "Enable"
        '
        'lblLocate
        '
        Me.lblLocate.Location = New System.Drawing.Point(4, 129)
        Me.lblLocate.Name = "lblLocate"
        Me.lblLocate.Size = New System.Drawing.Size(56, 20)
        Me.lblLocate.TabIndex = 51
        Me.lblLocate.Text = "Locate:"
        '
        'txtModuleID
        '
        Me.txtModuleID.Location = New System.Drawing.Point(135, 9)
        Me.txtModuleID.Name = "txtModuleID"
        Me.txtModuleID.ReadOnly = True
        Me.txtModuleID.Size = New System.Drawing.Size(223, 22)
        Me.txtModuleID.TabIndex = 18
        '
        'txtSWID
        '
        Me.txtSWID.Location = New System.Drawing.Point(135, 40)
        Me.txtSWID.Name = "txtSWID"
        Me.txtSWID.ReadOnly = True
        Me.txtSWID.Size = New System.Drawing.Size(223, 22)
        Me.txtSWID.TabIndex = 23
        '
        'txtFwVer
        '
        Me.txtFwVer.Location = New System.Drawing.Point(135, 100)
        Me.txtFwVer.Name = "txtFwVer"
        Me.txtFwVer.ReadOnly = True
        Me.txtFwVer.Size = New System.Drawing.Size(223, 22)
        Me.txtFwVer.TabIndex = 25
        '
        'txtSupportKernelFw
        '
        Me.txtSupportKernelFw.Location = New System.Drawing.Point(135, 69)
        Me.txtSupportKernelFw.Name = "txtSupportKernelFw"
        Me.txtSupportKernelFw.ReadOnly = True
        Me.txtSupportKernelFw.Size = New System.Drawing.Size(223, 22)
        Me.txtSupportKernelFw.TabIndex = 26
        '
        'labModule
        '
        Me.labModule.Location = New System.Drawing.Point(4, 9)
        Me.labModule.Name = "labModule"
        Me.labModule.Size = New System.Drawing.Size(100, 20)
        Me.labModule.TabIndex = 52
        Me.labModule.Text = "Module :"
        '
        'labID
        '
        Me.labID.Location = New System.Drawing.Point(4, 40)
        Me.labID.Name = "labID"
        Me.labID.Size = New System.Drawing.Size(100, 20)
        Me.labID.TabIndex = 53
        Me.labID.Text = "Switch ID :"
        '
        'labFwVer
        '
        Me.labFwVer.Location = New System.Drawing.Point(4, 100)
        Me.labFwVer.Name = "labFwVer"
        Me.labFwVer.Size = New System.Drawing.Size(125, 20)
        Me.labFwVer.TabIndex = 54
        Me.labFwVer.Text = "Firmware Version:"
        '
        'labSupportKernelFw
        '
        Me.labSupportKernelFw.Location = New System.Drawing.Point(4, 72)
        Me.labSupportKernelFw.Name = "labSupportKernelFw"
        Me.labSupportKernelFw.Size = New System.Drawing.Size(124, 20)
        Me.labSupportKernelFw.TabIndex = 55
        Me.labSupportKernelFw.Text = "Support Kernel Fw:"
        '
        'tbAO
        '
        Me.tbAO.Controls.Add(Me.listViewChInfo)
        Me.tbAO.Controls.Add(Me.Panel1)
        Me.tbAO.Controls.Add(Me.panelMain)
        Me.tbAO.Location = New System.Drawing.Point(4, 22)
        Me.tbAO.Name = "tbAO"
        Me.tbAO.Size = New System.Drawing.Size(541, 350)
        Me.tbAO.TabIndex = 1
        Me.tbAO.Text = "AO"
        '
        'listViewChInfo
        '
        Me.listViewChInfo.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.clmType, Me.clmCh, Me.clmValue, Me.clmRange, Me.clmStart, Me.clmSafety})
        Me.listViewChInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.listViewChInfo.FullRowSelect = True
        Me.listViewChInfo.Location = New System.Drawing.Point(0, 208)
        Me.listViewChInfo.Name = "listViewChInfo"
        Me.listViewChInfo.Size = New System.Drawing.Size(541, 142)
        Me.listViewChInfo.TabIndex = 3
        Me.listViewChInfo.UseCompatibleStateImageBehavior = False
        Me.listViewChInfo.View = System.Windows.Forms.View.Details
        '
        'clmType
        '
        Me.clmType.Text = "Type"
        Me.clmType.Width = 40
        '
        'clmCh
        '
        Me.clmCh.Text = "CH"
        Me.clmCh.Width = 40
        '
        'clmValue
        '
        Me.clmValue.Text = "Value"
        '
        'clmRange
        '
        Me.clmRange.Text = "Range"
        Me.clmRange.Width = 80
        '
        'clmStart
        '
        Me.clmStart.Text = "Startup"
        Me.clmStart.Width = 80
        '
        'clmSafety
        '
        Me.clmSafety.Text = "Safety Value"
        Me.clmSafety.Width = 200
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.panelSafetyFunction)
        Me.Panel1.Controls.Add(Me.panelSetting)
        Me.Panel1.Controls.Add(Me.panelOutputValue)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 32)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(541, 176)
        Me.Panel1.TabIndex = 4
        '
        'panelSafetyFunction
        '
        Me.panelSafetyFunction.BackColor = System.Drawing.Color.SkyBlue
        Me.panelSafetyFunction.Controls.Add(Me.btnSetSafetyValue)
        Me.panelSafetyFunction.Controls.Add(Me.chbxEnableSafety)
        Me.panelSafetyFunction.Controls.Add(Me.label2)
        Me.panelSafetyFunction.Location = New System.Drawing.Point(-12, 97)
        Me.panelSafetyFunction.Name = "panelSafetyFunction"
        Me.panelSafetyFunction.Size = New System.Drawing.Size(263, 73)
        Me.panelSafetyFunction.TabIndex = 0
        '
        'btnSetSafetyValue
        '
        Me.btnSetSafetyValue.Enabled = False
        Me.btnSetSafetyValue.Location = New System.Drawing.Point(134, 31)
        Me.btnSetSafetyValue.Name = "btnSetSafetyValue"
        Me.btnSetSafetyValue.Size = New System.Drawing.Size(83, 24)
        Me.btnSetSafetyValue.TabIndex = 0
        Me.btnSetSafetyValue.Text = "Set Value"
        '
        'chbxEnableSafety
        '
        Me.chbxEnableSafety.Location = New System.Drawing.Point(134, 6)
        Me.chbxEnableSafety.Name = "chbxEnableSafety"
        Me.chbxEnableSafety.Size = New System.Drawing.Size(76, 20)
        Me.chbxEnableSafety.TabIndex = 1
        Me.chbxEnableSafety.Text = "Enable"
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(4, 8)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(100, 20)
        Me.label2.TabIndex = 2
        Me.label2.Text = "Safety Function"
        '
        'panelSetting
        '
        Me.panelSetting.BackColor = System.Drawing.Color.SkyBlue
        Me.panelSetting.Controls.Add(Me.chbxApplyAll)
        Me.panelSetting.Controls.Add(Me.cbxRange)
        Me.panelSetting.Controls.Add(Me.labRange)
        Me.panelSetting.Controls.Add(Me.btnApplySelRange)
        Me.panelSetting.Location = New System.Drawing.Point(-4, 0)
        Me.panelSetting.Name = "panelSetting"
        Me.panelSetting.Size = New System.Drawing.Size(255, 91)
        Me.panelSetting.TabIndex = 1
        '
        'chbxApplyAll
        '
        Me.chbxApplyAll.Location = New System.Drawing.Point(3, 3)
        Me.chbxApplyAll.Name = "chbxApplyAll"
        Me.chbxApplyAll.Size = New System.Drawing.Size(168, 24)
        Me.chbxApplyAll.TabIndex = 0
        Me.chbxApplyAll.Text = "Apply to All Channels"
        '
        'cbxRange
        '
        Me.cbxRange.Location = New System.Drawing.Point(63, 33)
        Me.cbxRange.Name = "cbxRange"
        Me.cbxRange.Size = New System.Drawing.Size(171, 20)
        Me.cbxRange.TabIndex = 1
        '
        'labRange
        '
        Me.labRange.Location = New System.Drawing.Point(3, 35)
        Me.labRange.Name = "labRange"
        Me.labRange.Size = New System.Drawing.Size(60, 20)
        Me.labRange.TabIndex = 2
        Me.labRange.Text = "Range :"
        '
        'btnApplySelRange
        '
        Me.btnApplySelRange.Location = New System.Drawing.Point(167, 62)
        Me.btnApplySelRange.Name = "btnApplySelRange"
        Me.btnApplySelRange.Size = New System.Drawing.Size(67, 24)
        Me.btnApplySelRange.TabIndex = 3
        Me.btnApplySelRange.Text = "Apply"
        '
        'panelOutputValue
        '
        Me.panelOutputValue.BackColor = System.Drawing.Color.SkyBlue
        Me.panelOutputValue.Controls.Add(Me.txtSelChannel)
        Me.panelOutputValue.Controls.Add(Me.btnSetAsSafety)
        Me.panelOutputValue.Controls.Add(Me.btnApplyOutput)
        Me.panelOutputValue.Controls.Add(Me.labLow)
        Me.panelOutputValue.Controls.Add(Me.labHigh)
        Me.panelOutputValue.Controls.Add(Me.tBarOutputVal)
        Me.panelOutputValue.Controls.Add(Me.txtOutputVal)
        Me.panelOutputValue.Controls.Add(Me.labOutputVal)
        Me.panelOutputValue.Controls.Add(Me.btnSetAsStartup)
        Me.panelOutputValue.Controls.Add(Me.labChannel)
        Me.panelOutputValue.Location = New System.Drawing.Point(257, 0)
        Me.panelOutputValue.Name = "panelOutputValue"
        Me.panelOutputValue.Size = New System.Drawing.Size(312, 170)
        Me.panelOutputValue.TabIndex = 2
        '
        'txtSelChannel
        '
        Me.txtSelChannel.Enabled = False
        Me.txtSelChannel.Location = New System.Drawing.Point(80, 8)
        Me.txtSelChannel.Name = "txtSelChannel"
        Me.txtSelChannel.Size = New System.Drawing.Size(94, 22)
        Me.txtSelChannel.TabIndex = 0
        '
        'btnSetAsSafety
        '
        Me.btnSetAsSafety.Enabled = False
        Me.btnSetAsSafety.Location = New System.Drawing.Point(179, 127)
        Me.btnSetAsSafety.Name = "btnSetAsSafety"
        Me.btnSetAsSafety.Size = New System.Drawing.Size(85, 24)
        Me.btnSetAsSafety.TabIndex = 1
        Me.btnSetAsSafety.Text = "Set Safety"
        '
        'btnApplyOutput
        '
        Me.btnApplyOutput.Location = New System.Drawing.Point(186, 34)
        Me.btnApplyOutput.Name = "btnApplyOutput"
        Me.btnApplyOutput.Size = New System.Drawing.Size(78, 24)
        Me.btnApplyOutput.TabIndex = 2
        Me.btnApplyOutput.Text = "Output"
        '
        'labLow
        '
        Me.labLow.Location = New System.Drawing.Point(16, 104)
        Me.labLow.Name = "labLow"
        Me.labLow.Size = New System.Drawing.Size(80, 20)
        Me.labLow.TabIndex = 3
        Me.labLow.Text = "Low"
        '
        'labHigh
        '
        Me.labHigh.Location = New System.Drawing.Point(184, 104)
        Me.labHigh.Name = "labHigh"
        Me.labHigh.Size = New System.Drawing.Size(80, 20)
        Me.labHigh.TabIndex = 4
        Me.labHigh.Text = "High"
        Me.labHigh.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'tBarOutputVal
        '
        Me.tBarOutputVal.LargeChange = 500
        Me.tBarOutputVal.Location = New System.Drawing.Point(8, 64)
        Me.tBarOutputVal.Maximum = 4095
        Me.tBarOutputVal.Name = "tBarOutputVal"
        Me.tBarOutputVal.Size = New System.Drawing.Size(250, 45)
        Me.tBarOutputVal.SmallChange = 100
        Me.tBarOutputVal.TabIndex = 5
        Me.tBarOutputVal.TickFrequency = 100
        '
        'txtOutputVal
        '
        Me.txtOutputVal.Location = New System.Drawing.Point(80, 35)
        Me.txtOutputVal.Name = "txtOutputVal"
        Me.txtOutputVal.Size = New System.Drawing.Size(94, 22)
        Me.txtOutputVal.TabIndex = 6
        '
        'labOutputVal
        '
        Me.labOutputVal.Location = New System.Drawing.Point(8, 36)
        Me.labOutputVal.Name = "labOutputVal"
        Me.labOutputVal.Size = New System.Drawing.Size(60, 20)
        Me.labOutputVal.TabIndex = 7
        Me.labOutputVal.Text = "Value :"
        '
        'btnSetAsStartup
        '
        Me.btnSetAsStartup.Location = New System.Drawing.Point(16, 127)
        Me.btnSetAsStartup.Name = "btnSetAsStartup"
        Me.btnSetAsStartup.Size = New System.Drawing.Size(85, 24)
        Me.btnSetAsStartup.TabIndex = 8
        Me.btnSetAsStartup.Text = "Set Startup"
        '
        'labChannel
        '
        Me.labChannel.Location = New System.Drawing.Point(8, 10)
        Me.labChannel.Name = "labChannel"
        Me.labChannel.Size = New System.Drawing.Size(70, 20)
        Me.labChannel.TabIndex = 9
        Me.labChannel.Text = "Channel :"
        '
        'panelMain
        '
        Me.panelMain.Controls.Add(Me.chbxShowRawData)
        Me.panelMain.Controls.Add(Me.chbxHide)
        Me.panelMain.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelMain.Location = New System.Drawing.Point(0, 0)
        Me.panelMain.Name = "panelMain"
        Me.panelMain.Size = New System.Drawing.Size(541, 32)
        Me.panelMain.TabIndex = 5
        '
        'chbxShowRawData
        '
        Me.chbxShowRawData.Location = New System.Drawing.Point(176, 6)
        Me.chbxShowRawData.Name = "chbxShowRawData"
        Me.chbxShowRawData.Size = New System.Drawing.Size(128, 20)
        Me.chbxShowRawData.TabIndex = 2
        Me.chbxShowRawData.Text = "Show Raw Data"
        Me.chbxShowRawData.Visible = False
        '
        'chbxHide
        '
        Me.chbxHide.Location = New System.Drawing.Point(3, 6)
        Me.chbxHide.Name = "chbxHide"
        Me.chbxHide.Size = New System.Drawing.Size(168, 20)
        Me.chbxHide.TabIndex = 1
        Me.chbxHide.Text = "Hide Setting Panel"
        '
        'Form_APAX_5028
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(525, 427)
        Me.Controls.Add(Me.Btn_Quit)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.StatusBar_IO)
        Me.Controls.Add(Me.tcRemote)
        Me.Name = "Form_APAX_5028"
        Me.Text = "APAX-5028"
        Me.tcRemote.ResumeLayout(False)
        Me.tabModuleInfo.ResumeLayout(False)
        Me.tabModuleInfo.PerformLayout()
        Me.tbAO.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.panelSafetyFunction.ResumeLayout(False)
        Me.panelSetting.ResumeLayout(False)
        Me.panelOutputValue.ResumeLayout(False)
        Me.panelOutputValue.PerformLayout()
        CType(Me.tBarOutputVal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelMain.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Btn_Quit As System.Windows.Forms.Button
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents StatusBar_IO As System.Windows.Forms.StatusBar
    Private WithEvents tcRemote As System.Windows.Forms.TabControl
    Private WithEvents tabModuleInfo As System.Windows.Forms.TabPage
    Private WithEvents btnLocate As System.Windows.Forms.Button
    Private WithEvents lblLocate As System.Windows.Forms.Label
    Private WithEvents txtModuleID As System.Windows.Forms.TextBox
    Private WithEvents txtSWID As System.Windows.Forms.TextBox
    Private WithEvents txtFwVer As System.Windows.Forms.TextBox
    Private WithEvents txtSupportKernelFw As System.Windows.Forms.TextBox
    Private WithEvents labModule As System.Windows.Forms.Label
    Private WithEvents labID As System.Windows.Forms.Label
    Private WithEvents labFwVer As System.Windows.Forms.Label
    Private WithEvents labSupportKernelFw As System.Windows.Forms.Label
    Friend WithEvents tbAO As System.Windows.Forms.TabPage
    Private WithEvents listViewChInfo As System.Windows.Forms.ListView
    Private WithEvents clmType As System.Windows.Forms.ColumnHeader
    Private WithEvents clmCh As System.Windows.Forms.ColumnHeader
    Private WithEvents clmValue As System.Windows.Forms.ColumnHeader
    Private WithEvents clmRange As System.Windows.Forms.ColumnHeader
    Private WithEvents clmStart As System.Windows.Forms.ColumnHeader
    Private WithEvents clmSafety As System.Windows.Forms.ColumnHeader
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Private WithEvents panelSafetyFunction As System.Windows.Forms.Panel
    Private WithEvents btnSetSafetyValue As System.Windows.Forms.Button
    Private WithEvents chbxEnableSafety As System.Windows.Forms.CheckBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents panelSetting As System.Windows.Forms.Panel
    Private WithEvents chbxApplyAll As System.Windows.Forms.CheckBox
    Public WithEvents cbxRange As System.Windows.Forms.ComboBox
    Private WithEvents labRange As System.Windows.Forms.Label
    Private WithEvents btnApplySelRange As System.Windows.Forms.Button
    Private WithEvents panelOutputValue As System.Windows.Forms.Panel
    Public WithEvents txtSelChannel As System.Windows.Forms.TextBox
    Private WithEvents btnSetAsSafety As System.Windows.Forms.Button
    Private WithEvents btnApplyOutput As System.Windows.Forms.Button
    Private WithEvents labLow As System.Windows.Forms.Label
    Private WithEvents labHigh As System.Windows.Forms.Label
    Private WithEvents tBarOutputVal As System.Windows.Forms.TrackBar
    Private WithEvents txtOutputVal As System.Windows.Forms.TextBox
    Private WithEvents labOutputVal As System.Windows.Forms.Label
    Private WithEvents btnSetAsStartup As System.Windows.Forms.Button
    Private WithEvents labChannel As System.Windows.Forms.Label
    Private WithEvents panelMain As System.Windows.Forms.Panel
    Private WithEvents chbxShowRawData As System.Windows.Forms.CheckBox
    Private WithEvents chbxHide As System.Windows.Forms.CheckBox

End Class
