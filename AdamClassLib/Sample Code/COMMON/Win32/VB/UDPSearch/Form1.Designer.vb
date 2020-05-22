<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Root")
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.btnSearch = New System.Windows.Forms.Button
        Me.tcpTree = New System.Windows.Forms.TreeView
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.panel1 = New System.Windows.Forms.Panel
        Me.txtDescription = New System.Windows.Forms.TextBox
        Me.txtName = New System.Windows.Forms.TextBox
        Me.txtHostIdle = New System.Windows.Forms.TextBox
        Me.txtGateway = New System.Windows.Forms.TextBox
        Me.txtSubnet = New System.Windows.Forms.TextBox
        Me.txtMac = New System.Windows.Forms.TextBox
        Me.txtIP = New System.Windows.Forms.TextBox
        Me.label7 = New System.Windows.Forms.Label
        Me.label6 = New System.Windows.Forms.Label
        Me.label5 = New System.Windows.Forms.Label
        Me.label4 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.label2 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.panelDeviceInfo = New System.Windows.Forms.Panel
        Me.gbxDeviceInfo = New System.Windows.Forms.GroupBox
        Me.gbxNet = New System.Windows.Forms.GroupBox
        Me.btnNetSetting = New System.Windows.Forms.Button
        Me.btnDeviceInfoSetting = New System.Windows.Forms.Button
        Me.gbxOther = New System.Windows.Forms.GroupBox
        Me.btnSystemRestart = New System.Windows.Forms.Button
        Me.panel1.SuspendLayout()
        Me.panelDeviceInfo.SuspendLayout()
        Me.gbxDeviceInfo.SuspendLayout()
        Me.gbxNet.SuspendLayout()
        Me.gbxOther.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(205, 440)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 8
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'tcpTree
        '
        Me.tcpTree.ImageIndex = 0
        Me.tcpTree.ImageList = Me.ImageList1
        Me.tcpTree.Location = New System.Drawing.Point(12, 12)
        Me.tcpTree.Name = "tcpTree"
        TreeNode2.Name = "Node0"
        TreeNode2.Text = "Root"
        Me.tcpTree.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode2})
        Me.tcpTree.SelectedImageIndex = 0
        Me.tcpTree.Size = New System.Drawing.Size(277, 415)
        Me.tcpTree.TabIndex = 7
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "tcpRoot.ico")
        Me.ImageList1.Images.SetKeyName(1, "ADAM5000Off.ico")
        Me.ImageList1.Images.SetKeyName(2, "ADAM5000On.ico")
        Me.ImageList1.Images.SetKeyName(3, "ADAM4000Off.ico")
        Me.ImageList1.Images.SetKeyName(4, "ADAM4000On.ico")
        Me.ImageList1.Images.SetKeyName(5, "tcpOff.ico")
        Me.ImageList1.Images.SetKeyName(6, "tcpOn.ico")
        '
        'panel1
        '
        Me.panel1.Controls.Add(Me.txtHostIdle)
        Me.panel1.Controls.Add(Me.txtGateway)
        Me.panel1.Controls.Add(Me.txtSubnet)
        Me.panel1.Controls.Add(Me.txtMac)
        Me.panel1.Controls.Add(Me.txtIP)
        Me.panel1.Controls.Add(Me.label5)
        Me.panel1.Controls.Add(Me.label4)
        Me.panel1.Controls.Add(Me.label3)
        Me.panel1.Controls.Add(Me.label2)
        Me.panel1.Controls.Add(Me.label1)
        Me.panel1.Location = New System.Drawing.Point(8, 21)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(251, 156)
        Me.panel1.TabIndex = 6
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(88, 33)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(157, 63)
        Me.txtDescription.TabIndex = 16
        Me.txtDescription.MaxLength = 127
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(89, 5)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(156, 22)
        Me.txtName.TabIndex = 15
        '
        'txtHostIdle
        '
        Me.txtHostIdle.Location = New System.Drawing.Point(89, 117)
        Me.txtHostIdle.Name = "txtHostIdle"
        Me.txtHostIdle.Size = New System.Drawing.Size(156, 22)
        Me.txtHostIdle.TabIndex = 14
        '
        'txtGateway
        '
        Me.txtGateway.Location = New System.Drawing.Point(88, 88)
        Me.txtGateway.Name = "txtGateway"
        Me.txtGateway.Size = New System.Drawing.Size(156, 22)
        Me.txtGateway.TabIndex = 13
        '
        'txtSubnet
        '
        Me.txtSubnet.Location = New System.Drawing.Point(88, 60)
        Me.txtSubnet.Name = "txtSubnet"
        Me.txtSubnet.Size = New System.Drawing.Size(156, 22)
        Me.txtSubnet.TabIndex = 12
        '
        'txtMac
        '
        Me.txtMac.Location = New System.Drawing.Point(88, 32)
        Me.txtMac.Name = "txtMac"
        Me.txtMac.ReadOnly = True
        Me.txtMac.Size = New System.Drawing.Size(156, 22)
        Me.txtMac.TabIndex = 11
        '
        'txtIP
        '
        Me.txtIP.Location = New System.Drawing.Point(88, 4)
        Me.txtIP.Name = "txtIP"
        Me.txtIP.Size = New System.Drawing.Size(156, 22)
        Me.txtIP.TabIndex = 10
        '
        'label7
        '
        Me.label7.AutoSize = True
        Me.label7.Location = New System.Drawing.Point(3, 36)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(64, 12)
        Me.label7.TabIndex = 6
        Me.label7.Text = "Description: "
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.Location = New System.Drawing.Point(3, 8)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(73, 12)
        Me.label6.TabIndex = 5
        Me.label6.Text = "Device Name: "
        '
        'label5
        '
        Me.label5.AutoSize = True
        Me.label5.Location = New System.Drawing.Point(3, 120)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(53, 12)
        Me.label5.TabIndex = 4
        Me.label5.Text = "Host Idle: "
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(3, 92)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(86, 12)
        Me.label4.TabIndex = 3
        Me.label4.Text = "Default gateway: "
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(3, 64)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(70, 12)
        Me.label3.TabIndex = 2
        Me.label3.Text = "Subnet mask: "
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(3, 36)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(31, 12)
        Me.label2.TabIndex = 1
        Me.label2.Text = "Mac: "
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(3, 7)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(55, 12)
        Me.label1.TabIndex = 0
        Me.label1.Text = "IP address:"
        '
        'panelDeviceInfo
        '
        Me.panelDeviceInfo.Controls.Add(Me.txtDescription)
        Me.panelDeviceInfo.Controls.Add(Me.txtName)
        Me.panelDeviceInfo.Controls.Add(Me.label6)
        Me.panelDeviceInfo.Controls.Add(Me.label7)
        Me.panelDeviceInfo.Location = New System.Drawing.Point(8, 19)
        Me.panelDeviceInfo.Name = "panelDeviceInfo"
        Me.panelDeviceInfo.Size = New System.Drawing.Size(251, 110)
        Me.panelDeviceInfo.TabIndex = 9
        '
        'gbxDeviceInfo
        '
        Me.gbxDeviceInfo.Controls.Add(Me.btnDeviceInfoSetting)
        Me.gbxDeviceInfo.Controls.Add(Me.panelDeviceInfo)
        Me.gbxDeviceInfo.Location = New System.Drawing.Point(297, 242)
        Me.gbxDeviceInfo.Name = "gbxDeviceInfo"
        Me.gbxDeviceInfo.Size = New System.Drawing.Size(268, 170)
        Me.gbxDeviceInfo.TabIndex = 10
        Me.gbxDeviceInfo.TabStop = False
        Me.gbxDeviceInfo.Text = "Device Info"
        '
        'gbxNet
        '
        Me.gbxNet.Controls.Add(Me.btnNetSetting)
        Me.gbxNet.Controls.Add(Me.panel1)
        Me.gbxNet.Location = New System.Drawing.Point(297, 12)
        Me.gbxNet.Name = "gbxNet"
        Me.gbxNet.Size = New System.Drawing.Size(268, 220)
        Me.gbxNet.TabIndex = 11
        Me.gbxNet.TabStop = False
        Me.gbxNet.Text = "Network Setting"
        '
        'btnNetSetting
        '
        Me.btnNetSetting.Enabled = False
        Me.btnNetSetting.Location = New System.Drawing.Point(169, 187)
        Me.btnNetSetting.Name = "btnNetSetting"
        Me.btnNetSetting.Size = New System.Drawing.Size(84, 23)
        Me.btnNetSetting.TabIndex = 12
        Me.btnNetSetting.Text = "Apply Change"
        Me.btnNetSetting.UseVisualStyleBackColor = True
        '
        'btnDeviceInfoSetting
        '
        Me.btnDeviceInfoSetting.Enabled = False
        Me.btnDeviceInfoSetting.Location = New System.Drawing.Point(168, 137)
        Me.btnDeviceInfoSetting.Name = "btnDeviceInfoSetting"
        Me.btnDeviceInfoSetting.Size = New System.Drawing.Size(84, 23)
        Me.btnDeviceInfoSetting.TabIndex = 19
        Me.btnDeviceInfoSetting.Text = "Apply Change"
        Me.btnDeviceInfoSetting.UseVisualStyleBackColor = True
        '
        'gbxOther
        '
        Me.gbxOther.Controls.Add(Me.btnSystemRestart)
        Me.gbxOther.Location = New System.Drawing.Point(297, 419)
        Me.gbxOther.Name = "gbxOther"
        Me.gbxOther.Size = New System.Drawing.Size(268, 64)
        Me.gbxOther.TabIndex = 12
        Me.gbxOther.TabStop = False
        Me.gbxOther.Text = "Other"
        '
        'btnSystemRestart
        '
        Me.btnSystemRestart.Enabled = False
        Me.btnSystemRestart.Location = New System.Drawing.Point(168, 21)
        Me.btnSystemRestart.Name = "btnSystemRestart"
        Me.btnSystemRestart.Size = New System.Drawing.Size(84, 23)
        Me.btnSystemRestart.TabIndex = 18
        Me.btnSystemRestart.Text = "System Restart"
        Me.btnSystemRestart.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(579, 488)
        Me.Controls.Add(Me.gbxOther)
        Me.Controls.Add(Me.gbxNet)
        Me.Controls.Add(Me.gbxDeviceInfo)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.tcpTree)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Text = "UDP Search Sample Program (VB)"
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        Me.panelDeviceInfo.ResumeLayout(False)
        Me.panelDeviceInfo.PerformLayout()
        Me.gbxDeviceInfo.ResumeLayout(False)
        Me.gbxNet.ResumeLayout(False)
        Me.gbxOther.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents btnSearch As System.Windows.Forms.Button
    Private WithEvents tcpTree As System.Windows.Forms.TreeView
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents txtDescription As System.Windows.Forms.TextBox
    Private WithEvents txtName As System.Windows.Forms.TextBox
    Private WithEvents txtHostIdle As System.Windows.Forms.TextBox
    Private WithEvents txtGateway As System.Windows.Forms.TextBox
    Private WithEvents txtSubnet As System.Windows.Forms.TextBox
    Private WithEvents txtMac As System.Windows.Forms.TextBox
    Private WithEvents txtIP As System.Windows.Forms.TextBox
    Private WithEvents label7 As System.Windows.Forms.Label
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents label5 As System.Windows.Forms.Label
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents panelDeviceInfo As System.Windows.Forms.Panel
    Friend WithEvents gbxDeviceInfo As System.Windows.Forms.GroupBox
    Private WithEvents btnDeviceInfoSetting As System.Windows.Forms.Button
    Friend WithEvents gbxNet As System.Windows.Forms.GroupBox
    Private WithEvents btnNetSetting As System.Windows.Forms.Button
    Private WithEvents gbxOther As System.Windows.Forms.GroupBox
    Private WithEvents btnSystemRestart As System.Windows.Forms.Button

End Class
