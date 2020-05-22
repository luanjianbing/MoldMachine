<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_APAX_5040PE
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
        Me.tabModuleInfo = New System.Windows.Forms.TabPage
        Me.btnLocate = New System.Windows.Forms.Button
        Me.lblLocate = New System.Windows.Forms.Label
        Me.txtModuleID = New System.Windows.Forms.TextBox
        Me.labModule = New System.Windows.Forms.Label
        Me.labID = New System.Windows.Forms.Label
        Me.labFwVer = New System.Windows.Forms.Label
        Me.txtSWID = New System.Windows.Forms.TextBox
        Me.txtFwVer = New System.Windows.Forms.TextBox
        Me.txtSupportKernelFw = New System.Windows.Forms.TextBox
        Me.labSupportKernelFw = New System.Windows.Forms.Label
        Me.Btn_Quit = New System.Windows.Forms.Button
        Me.btnStart = New System.Windows.Forms.Button
        Me.StatusBar_IO = New System.Windows.Forms.StatusBar
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.tcRemote = New System.Windows.Forms.TabControl
        Me.tabDI = New System.Windows.Forms.TabPage
        Me.listViewChInfo = New System.Windows.Forms.ListView
        Me.clmDIType = New System.Windows.Forms.ColumnHeader
        Me.clmDICh = New System.Windows.Forms.ColumnHeader
        Me.clmDIValue = New System.Windows.Forms.ColumnHeader
        Me.clmDIMode = New System.Windows.Forms.ColumnHeader
        Me.panel2 = New System.Windows.Forms.Panel
        Me.labelCntMin = New System.Windows.Forms.Label
        Me.chkBoxDiFilterEnable = New System.Windows.Forms.CheckBox
        Me.btnApplySetting = New System.Windows.Forms.Button
        Me.labUnit = New System.Windows.Forms.Label
        Me.txtCntMin = New System.Windows.Forms.TextBox
        Me.panelMain = New System.Windows.Forms.Panel
        Me.chbxHide = New System.Windows.Forms.CheckBox
        Me.tabModuleInfo.SuspendLayout()
        Me.tcRemote.SuspendLayout()
        Me.tabDI.SuspendLayout()
        Me.panel2.SuspendLayout()
        Me.panelMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabModuleInfo
        '
        Me.tabModuleInfo.Controls.Add(Me.btnLocate)
        Me.tabModuleInfo.Controls.Add(Me.lblLocate)
        Me.tabModuleInfo.Controls.Add(Me.txtModuleID)
        Me.tabModuleInfo.Controls.Add(Me.labModule)
        Me.tabModuleInfo.Controls.Add(Me.labID)
        Me.tabModuleInfo.Controls.Add(Me.labFwVer)
        Me.tabModuleInfo.Controls.Add(Me.txtSWID)
        Me.tabModuleInfo.Controls.Add(Me.txtFwVer)
        Me.tabModuleInfo.Controls.Add(Me.txtSupportKernelFw)
        Me.tabModuleInfo.Controls.Add(Me.labSupportKernelFw)
        Me.tabModuleInfo.Location = New System.Drawing.Point(4, 22)
        Me.tabModuleInfo.Name = "tabModuleInfo"
        Me.tabModuleInfo.Size = New System.Drawing.Size(466, 295)
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
        'labSupportKernelFw
        '
        Me.labSupportKernelFw.Location = New System.Drawing.Point(4, 72)
        Me.labSupportKernelFw.Name = "labSupportKernelFw"
        Me.labSupportKernelFw.Size = New System.Drawing.Size(124, 20)
        Me.labSupportKernelFw.TabIndex = 55
        Me.labSupportKernelFw.Text = "Support Kernel Fw:"
        '
        'Btn_Quit
        '
        Me.Btn_Quit.Location = New System.Drawing.Point(346, 327)
        Me.Btn_Quit.Name = "Btn_Quit"
        Me.Btn_Quit.Size = New System.Drawing.Size(73, 21)
        Me.Btn_Quit.TabIndex = 21
        Me.Btn_Quit.Text = "Quit"
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(267, 327)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(73, 21)
        Me.btnStart.TabIndex = 20
        Me.btnStart.Text = "Start"
        '
        'StatusBar_IO
        '
        Me.StatusBar_IO.Location = New System.Drawing.Point(0, 356)
        Me.StatusBar_IO.Name = "StatusBar_IO"
        Me.StatusBar_IO.Size = New System.Drawing.Size(474, 24)
        Me.StatusBar_IO.TabIndex = 22
        '
        'Timer1
        '
        '
        'tcRemote
        '
        Me.tcRemote.Controls.Add(Me.tabModuleInfo)
        Me.tcRemote.Controls.Add(Me.tabDI)
        Me.tcRemote.Dock = System.Windows.Forms.DockStyle.Top
        Me.tcRemote.Enabled = False
        Me.tcRemote.Location = New System.Drawing.Point(0, 0)
        Me.tcRemote.Name = "tcRemote"
        Me.tcRemote.SelectedIndex = 0
        Me.tcRemote.Size = New System.Drawing.Size(474, 321)
        Me.tcRemote.TabIndex = 19
        Me.tcRemote.Visible = False
        '
        'tabDI
        '
        Me.tabDI.Controls.Add(Me.listViewChInfo)
        Me.tabDI.Controls.Add(Me.panel2)
        Me.tabDI.Controls.Add(Me.panelMain)
        Me.tabDI.Location = New System.Drawing.Point(4, 22)
        Me.tabDI.Name = "tabDI"
        Me.tabDI.Size = New System.Drawing.Size(466, 295)
        Me.tabDI.TabIndex = 1
        Me.tabDI.Text = "DI"
        '
        'listViewChInfo
        '
        Me.listViewChInfo.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.clmDIType, Me.clmDICh, Me.clmDIValue, Me.clmDIMode})
        Me.listViewChInfo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.listViewChInfo.FullRowSelect = True
        Me.listViewChInfo.Location = New System.Drawing.Point(0, 109)
        Me.listViewChInfo.Name = "listViewChInfo"
        Me.listViewChInfo.Size = New System.Drawing.Size(466, 186)
        Me.listViewChInfo.TabIndex = 7
        Me.listViewChInfo.UseCompatibleStateImageBehavior = False
        Me.listViewChInfo.View = System.Windows.Forms.View.Details
        '
        'clmDIType
        '
        Me.clmDIType.Text = "Type"
        '
        'clmDICh
        '
        Me.clmDICh.Text = "CH"
        '
        'clmDIValue
        '
        Me.clmDIValue.Text = "Value"
        '
        'clmDIMode
        '
        Me.clmDIMode.Text = "Mode"
        '
        'panel2
        '
        Me.panel2.BackColor = System.Drawing.Color.SkyBlue
        Me.panel2.Controls.Add(Me.labelCntMin)
        Me.panel2.Controls.Add(Me.chkBoxDiFilterEnable)
        Me.panel2.Controls.Add(Me.btnApplySetting)
        Me.panel2.Controls.Add(Me.labUnit)
        Me.panel2.Controls.Add(Me.txtCntMin)
        Me.panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.panel2.Location = New System.Drawing.Point(0, 32)
        Me.panel2.Name = "panel2"
        Me.panel2.Size = New System.Drawing.Size(466, 77)
        Me.panel2.TabIndex = 8
        '
        'labelCntMin
        '
        Me.labelCntMin.Location = New System.Drawing.Point(8, 37)
        Me.labelCntMin.Name = "labelCntMin"
        Me.labelCntMin.Size = New System.Drawing.Size(222, 24)
        Me.labelCntMin.TabIndex = 0
        Me.labelCntMin.Text = "Minimum low signal width (10~400)"
        '
        'chkBoxDiFilterEnable
        '
        Me.chkBoxDiFilterEnable.Checked = True
        Me.chkBoxDiFilterEnable.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkBoxDiFilterEnable.Enabled = False
        Me.chkBoxDiFilterEnable.Location = New System.Drawing.Point(8, 6)
        Me.chkBoxDiFilterEnable.Name = "chkBoxDiFilterEnable"
        Me.chkBoxDiFilterEnable.Size = New System.Drawing.Size(160, 24)
        Me.chkBoxDiFilterEnable.TabIndex = 5
        Me.chkBoxDiFilterEnable.Text = "DI Filter Enable"
        '
        'btnApplySetting
        '
        Me.btnApplySetting.Location = New System.Drawing.Point(354, 37)
        Me.btnApplySetting.Name = "btnApplySetting"
        Me.btnApplySetting.Size = New System.Drawing.Size(88, 24)
        Me.btnApplySetting.TabIndex = 6
        Me.btnApplySetting.Text = "Apply"
        '
        'labUnit
        '
        Me.labUnit.Location = New System.Drawing.Point(290, 37)
        Me.labUnit.Name = "labUnit"
        Me.labUnit.Size = New System.Drawing.Size(58, 24)
        Me.labUnit.TabIndex = 7
        Me.labUnit.Text = "0.1 ms"
        '
        'txtCntMin
        '
        Me.txtCntMin.Location = New System.Drawing.Point(230, 38)
        Me.txtCntMin.MaxLength = 10
        Me.txtCntMin.Name = "txtCntMin"
        Me.txtCntMin.Size = New System.Drawing.Size(54, 22)
        Me.txtCntMin.TabIndex = 8
        '
        'panelMain
        '
        Me.panelMain.Controls.Add(Me.chbxHide)
        Me.panelMain.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelMain.Location = New System.Drawing.Point(0, 0)
        Me.panelMain.Name = "panelMain"
        Me.panelMain.Size = New System.Drawing.Size(466, 32)
        Me.panelMain.TabIndex = 9
        '
        'chbxHide
        '
        Me.chbxHide.Location = New System.Drawing.Point(8, 8)
        Me.chbxHide.Name = "chbxHide"
        Me.chbxHide.Size = New System.Drawing.Size(168, 20)
        Me.chbxHide.TabIndex = 1
        Me.chbxHide.Text = "Hide Setting Panel"
        '
        'Form_APAX_5040PE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(474, 380)
        Me.Controls.Add(Me.Btn_Quit)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.StatusBar_IO)
        Me.Controls.Add(Me.tcRemote)
        Me.Name = "Form_APAX_5040PE"
        Me.Text = "APAX-5040PE"
        Me.tabModuleInfo.ResumeLayout(False)
        Me.tabModuleInfo.PerformLayout()
        Me.tcRemote.ResumeLayout(False)
        Me.tabDI.ResumeLayout(False)
        Me.panel2.ResumeLayout(False)
        Me.panel2.PerformLayout()
        Me.panelMain.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents tabModuleInfo As System.Windows.Forms.TabPage
    Private WithEvents btnLocate As System.Windows.Forms.Button
    Private WithEvents lblLocate As System.Windows.Forms.Label
    Private WithEvents txtModuleID As System.Windows.Forms.TextBox
    Private WithEvents labModule As System.Windows.Forms.Label
    Private WithEvents labID As System.Windows.Forms.Label
    Private WithEvents labFwVer As System.Windows.Forms.Label
    Private WithEvents txtSWID As System.Windows.Forms.TextBox
    Private WithEvents txtFwVer As System.Windows.Forms.TextBox
    Private WithEvents txtSupportKernelFw As System.Windows.Forms.TextBox
    Private WithEvents labSupportKernelFw As System.Windows.Forms.Label
    Friend WithEvents Btn_Quit As System.Windows.Forms.Button
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents StatusBar_IO As System.Windows.Forms.StatusBar
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Private WithEvents tcRemote As System.Windows.Forms.TabControl
    Private WithEvents tabDI As System.Windows.Forms.TabPage
    Private WithEvents listViewChInfo As System.Windows.Forms.ListView
    Private WithEvents clmDIType As System.Windows.Forms.ColumnHeader
    Private WithEvents clmDICh As System.Windows.Forms.ColumnHeader
    Private WithEvents clmDIValue As System.Windows.Forms.ColumnHeader
    Private WithEvents clmDIMode As System.Windows.Forms.ColumnHeader
    Private WithEvents panel2 As System.Windows.Forms.Panel
    Private WithEvents labelCntMin As System.Windows.Forms.Label
    Private WithEvents chkBoxDiFilterEnable As System.Windows.Forms.CheckBox
    Private WithEvents btnApplySetting As System.Windows.Forms.Button
    Private WithEvents labUnit As System.Windows.Forms.Label
    Private WithEvents txtCntMin As System.Windows.Forms.TextBox
    Private WithEvents panelMain As System.Windows.Forms.Panel
    Private WithEvents chbxHide As System.Windows.Forms.CheckBox

End Class
