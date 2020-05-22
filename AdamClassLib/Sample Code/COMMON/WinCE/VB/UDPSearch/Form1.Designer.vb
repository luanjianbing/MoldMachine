<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Root")
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.btnSearch = New System.Windows.Forms.Button
        Me.tcpTree = New System.Windows.Forms.TreeView
        Me.ImageList1 = New System.Windows.Forms.ImageList
        Me.panelNetworkSetting = New System.Windows.Forms.Panel
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
        Me.btnNetSetting = New System.Windows.Forms.Button
        Me.btnDeviceInfoSetting = New System.Windows.Forms.Button
        Me.panelOther = New System.Windows.Forms.Panel
        Me.btnSystemRestart = New System.Windows.Forms.Button
        Me.panelNetworkSetting.SuspendLayout()
        Me.panelDeviceInfo.SuspendLayout()
        Me.panelOther.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(205, 412)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 11
        Me.btnSearch.Text = "Search"
        '
        'tcpTree
        '
        Me.tcpTree.ImageIndex = 0
        Me.tcpTree.ImageList = Me.ImageList1
        Me.tcpTree.Location = New System.Drawing.Point(3, 17)
        Me.tcpTree.Name = "tcpTree"
        TreeNode1.Text = "Root"
        Me.tcpTree.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1})
        Me.tcpTree.SelectedImageIndex = 0
        Me.tcpTree.Size = New System.Drawing.Size(277, 384)
        Me.tcpTree.TabIndex = 10
        Me.ImageList1.Images.Clear()
        Me.ImageList1.Images.Add(CType(resources.GetObject("resource"), System.Drawing.Icon))
        Me.ImageList1.Images.Add(CType(resources.GetObject("resource1"), System.Drawing.Icon))
        Me.ImageList1.Images.Add(CType(resources.GetObject("resource2"), System.Drawing.Icon))
        Me.ImageList1.Images.Add(CType(resources.GetObject("resource3"), System.Drawing.Icon))
        Me.ImageList1.Images.Add(CType(resources.GetObject("resource4"), System.Drawing.Icon))
        Me.ImageList1.Images.Add(CType(resources.GetObject("resource5"), System.Drawing.Icon))
        Me.ImageList1.Images.Add(CType(resources.GetObject("resource6"), System.Drawing.Icon))
        '
        'panelNetworkSetting
        '
        Me.panelNetworkSetting.Controls.Add(Me.btnNetSetting)
        Me.panelNetworkSetting.Controls.Add(Me.txtHostIdle)
        Me.panelNetworkSetting.Controls.Add(Me.txtGateway)
        Me.panelNetworkSetting.Controls.Add(Me.txtSubnet)
        Me.panelNetworkSetting.Controls.Add(Me.txtMac)
        Me.panelNetworkSetting.Controls.Add(Me.txtIP)
        Me.panelNetworkSetting.Controls.Add(Me.label5)
        Me.panelNetworkSetting.Controls.Add(Me.label4)
        Me.panelNetworkSetting.Controls.Add(Me.label3)
        Me.panelNetworkSetting.Controls.Add(Me.label2)
        Me.panelNetworkSetting.Controls.Add(Me.label1)
        Me.panelNetworkSetting.Location = New System.Drawing.Point(300, 17)
        Me.panelNetworkSetting.Name = "panelNetworkSetting"
        Me.panelNetworkSetting.Size = New System.Drawing.Size(264, 183)
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(106, 32)
        Me.txtDescription.Multiline = True
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(155, 57)
        Me.txtDescription.TabIndex = 16
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(107, 4)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(154, 23)
        Me.txtName.TabIndex = 15
        '
        'txtHostIdle
        '
        Me.txtHostIdle.Location = New System.Drawing.Point(107, 117)
        Me.txtHostIdle.Name = "txtHostIdle"
        Me.txtHostIdle.Size = New System.Drawing.Size(154, 23)
        Me.txtHostIdle.TabIndex = 14
        '
        'txtGateway
        '
        Me.txtGateway.Location = New System.Drawing.Point(106, 88)
        Me.txtGateway.Name = "txtGateway"
        Me.txtGateway.Size = New System.Drawing.Size(154, 23)
        Me.txtGateway.TabIndex = 13
        '
        'txtSubnet
        '
        Me.txtSubnet.Location = New System.Drawing.Point(106, 60)
        Me.txtSubnet.Name = "txtSubnet"
        Me.txtSubnet.Size = New System.Drawing.Size(154, 23)
        Me.txtSubnet.TabIndex = 12
        '
        'txtMac
        '
        Me.txtMac.Location = New System.Drawing.Point(106, 32)
        Me.txtMac.Name = "txtMac"
        Me.txtMac.ReadOnly = True
        Me.txtMac.Size = New System.Drawing.Size(154, 23)
        Me.txtMac.TabIndex = 11
        '
        'txtIP
        '
        Me.txtIP.Location = New System.Drawing.Point(106, 4)
        Me.txtIP.Name = "txtIP"
        Me.txtIP.Size = New System.Drawing.Size(154, 23)
        Me.txtIP.TabIndex = 10
        '
        'label7
        '
        Me.label7.Location = New System.Drawing.Point(3, 35)
        Me.label7.Name = "label7"
        Me.label7.Size = New System.Drawing.Size(79, 19)
        Me.label7.Text = "Description: "
        '
        'label6
        '
        Me.label6.Location = New System.Drawing.Point(3, 7)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(96, 20)
        Me.label6.Text = "Device Name: "
        '
        'label5
        '
        Me.label5.Location = New System.Drawing.Point(3, 120)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(73, 20)
        Me.label5.Text = "Host Idle: "
        '
        'label4
        '
        Me.label4.Location = New System.Drawing.Point(3, 92)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(117, 19)
        Me.label4.Text = "Default gateway: "
        '
        'label3
        '
        Me.label3.Location = New System.Drawing.Point(3, 64)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(96, 19)
        Me.label3.Text = "Subnet mask: "
        '
        'label2
        '
        Me.label2.Location = New System.Drawing.Point(3, 36)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(53, 19)
        Me.label2.Text = "Mac: "
        '
        'label1
        '
        Me.label1.Location = New System.Drawing.Point(3, 7)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(79, 20)
        Me.label1.Text = "IP address:"
        '
        'panelDeviceInfo
        '
        Me.panelDeviceInfo.Controls.Add(Me.btnDeviceInfoSetting)
        Me.panelDeviceInfo.Controls.Add(Me.txtDescription)
        Me.panelDeviceInfo.Controls.Add(Me.txtName)
        Me.panelDeviceInfo.Controls.Add(Me.label6)
        Me.panelDeviceInfo.Controls.Add(Me.label7)
        Me.panelDeviceInfo.Location = New System.Drawing.Point(300, 205)
        Me.panelDeviceInfo.Name = "panelDeviceInfo"
        Me.panelDeviceInfo.Size = New System.Drawing.Size(264, 130)
        '
        'btnNetSetting
        '
        Me.btnNetSetting.Enabled = False
        Me.btnNetSetting.Location = New System.Drawing.Point(141, 150)
        Me.btnNetSetting.Name = "btnNetSetting"
        Me.btnNetSetting.Size = New System.Drawing.Size(120, 23)
        Me.btnNetSetting.TabIndex = 14
        Me.btnNetSetting.Text = "Apply Change"
        '
        'btnDeviceInfoSetting
        '
        Me.btnDeviceInfoSetting.Enabled = False
        Me.btnDeviceInfoSetting.Location = New System.Drawing.Point(141, 98)
        Me.btnDeviceInfoSetting.Name = "btnDeviceInfoSetting"
        Me.btnDeviceInfoSetting.Size = New System.Drawing.Size(120, 23)
        Me.btnDeviceInfoSetting.TabIndex = 20
        Me.btnDeviceInfoSetting.Text = "Apply Change"
        '
        'panelOther
        '
        Me.panelOther.Controls.Add(Me.btnSystemRestart)
        Me.panelOther.Location = New System.Drawing.Point(300, 341)
        Me.panelOther.Name = "panelOther"
        Me.panelOther.Size = New System.Drawing.Size(264, 60)
        '
        'btnSystemRestart
        '
        Me.btnSystemRestart.Enabled = False
        Me.btnSystemRestart.Location = New System.Drawing.Point(140, 18)
        Me.btnSystemRestart.Name = "btnSystemRestart"
        Me.btnSystemRestart.Size = New System.Drawing.Size(120, 23)
        Me.btnSystemRestart.TabIndex = 19
        Me.btnSystemRestart.Text = "System Restart"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(96.0!, 96.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(580, 463)
        Me.Controls.Add(Me.panelOther)
        Me.Controls.Add(Me.panelDeviceInfo)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.tcpTree)
        Me.Controls.Add(Me.panelNetworkSetting)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Text = "UDPSearch Sample Program (VB)"
        Me.panelNetworkSetting.ResumeLayout(False)
        Me.panelDeviceInfo.ResumeLayout(False)
        Me.panelOther.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents btnSearch As System.Windows.Forms.Button
    Private WithEvents tcpTree As System.Windows.Forms.TreeView
    Private WithEvents panelNetworkSetting As System.Windows.Forms.Panel
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
    Private WithEvents btnNetSetting As System.Windows.Forms.Button
    Private WithEvents btnDeviceInfoSetting As System.Windows.Forms.Button
    Private WithEvents panelOther As System.Windows.Forms.Panel
    Private WithEvents btnSystemRestart As System.Windows.Forms.Button

End Class
