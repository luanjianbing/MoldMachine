<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_APAX_Controller
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
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Local System")
        Me.TreeView_MAIN = New System.Windows.Forms.TreeView
        Me.mainMenu_Main = New System.Windows.Forms.MenuStrip
        Me.MenuItem_Refresh_Local = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuItem_Exit = New System.Windows.Forms.ToolStripMenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ListView_Module_Infor = New System.Windows.Forms.ListView
        Me.ColumnHeader_ID = New System.Windows.Forms.ColumnHeader
        Me.ColumnHeader_Module = New System.Windows.Forms.ColumnHeader
        Me.NumericUpDown_SCAN = New System.Windows.Forms.NumericUpDown
        Me.TextBox_FPGA_Ver = New System.Windows.Forms.TextBox
        Me.TextBox_Firmware_Ver = New System.Windows.Forms.TextBox
        Me.lbl_SCAN = New System.Windows.Forms.Label
        Me.lbl_FPGA_VER = New System.Windows.Forms.Label
        Me.lbl_Controller_Firmware_Ver = New System.Windows.Forms.Label
        Me.lbl_Controller_Title = New System.Windows.Forms.Label
        Me.StatusBar_MAIN = New System.Windows.Forms.StatusBar
        Me.mainMenu_Main.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.NumericUpDown_SCAN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TreeView_MAIN
        '
        Me.TreeView_MAIN.Location = New System.Drawing.Point(20, 44)
        Me.TreeView_MAIN.Name = "TreeView_MAIN"
        TreeNode2.Name = ""
        TreeNode2.Text = "Local System"
        Me.TreeView_MAIN.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode2})
        Me.TreeView_MAIN.Size = New System.Drawing.Size(166, 391)
        Me.TreeView_MAIN.TabIndex = 1
        '
        'mainMenu_Main
        '
        Me.mainMenu_Main.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuItem_Refresh_Local, Me.MenuItem_Exit})
        Me.mainMenu_Main.Location = New System.Drawing.Point(0, 0)
        Me.mainMenu_Main.Name = "mainMenu_Main"
        Me.mainMenu_Main.Size = New System.Drawing.Size(711, 24)
        Me.mainMenu_Main.TabIndex = 3
        Me.mainMenu_Main.Text = "MenuStrip1"
        '
        'MenuItem_Refresh_Local
        '
        Me.MenuItem_Refresh_Local.Name = "MenuItem_Refresh_Local"
        Me.MenuItem_Refresh_Local.Size = New System.Drawing.Size(95, 20)
        Me.MenuItem_Refresh_Local.Text = "Refresh Local"
        '
        'MenuItem_Exit
        '
        Me.MenuItem_Exit.Name = "MenuItem_Exit"
        Me.MenuItem_Exit.Size = New System.Drawing.Size(40, 20)
        Me.MenuItem_Exit.Text = "Exit"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.ListView_Module_Infor)
        Me.Panel1.Controls.Add(Me.NumericUpDown_SCAN)
        Me.Panel1.Controls.Add(Me.TextBox_FPGA_Ver)
        Me.Panel1.Controls.Add(Me.TextBox_Firmware_Ver)
        Me.Panel1.Controls.Add(Me.lbl_SCAN)
        Me.Panel1.Controls.Add(Me.lbl_FPGA_VER)
        Me.Panel1.Controls.Add(Me.lbl_Controller_Firmware_Ver)
        Me.Panel1.Controls.Add(Me.lbl_Controller_Title)
        Me.Panel1.Location = New System.Drawing.Point(218, 44)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(465, 391)
        Me.Panel1.TabIndex = 5
        Me.Panel1.Visible = False
        '
        'ListView_Module_Infor
        '
        Me.ListView_Module_Infor.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader_ID, Me.ColumnHeader_Module})
        Me.ListView_Module_Infor.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ListView_Module_Infor.FullRowSelect = True
        Me.ListView_Module_Infor.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.ListView_Module_Infor.Location = New System.Drawing.Point(0, 207)
        Me.ListView_Module_Infor.Name = "ListView_Module_Infor"
        Me.ListView_Module_Infor.Size = New System.Drawing.Size(465, 184)
        Me.ListView_Module_Infor.TabIndex = 15
        Me.ListView_Module_Infor.UseCompatibleStateImageBehavior = False
        Me.ListView_Module_Infor.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader_ID
        '
        Me.ColumnHeader_ID.Text = "Switch ID"
        Me.ColumnHeader_ID.Width = 143
        '
        'ColumnHeader_Module
        '
        Me.ColumnHeader_Module.Text = "Module"
        Me.ColumnHeader_Module.Width = 213
        '
        'NumericUpDown_SCAN
        '
        Me.NumericUpDown_SCAN.Location = New System.Drawing.Point(137, 99)
        Me.NumericUpDown_SCAN.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.NumericUpDown_SCAN.Minimum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.NumericUpDown_SCAN.Name = "NumericUpDown_SCAN"
        Me.NumericUpDown_SCAN.Size = New System.Drawing.Size(94, 22)
        Me.NumericUpDown_SCAN.TabIndex = 14
        Me.NumericUpDown_SCAN.Value = New Decimal(New Integer() {500, 0, 0, 0})
        '
        'TextBox_FPGA_Ver
        '
        Me.TextBox_FPGA_Ver.Location = New System.Drawing.Point(137, 70)
        Me.TextBox_FPGA_Ver.Name = "TextBox_FPGA_Ver"
        Me.TextBox_FPGA_Ver.Size = New System.Drawing.Size(165, 22)
        Me.TextBox_FPGA_Ver.TabIndex = 13
        '
        'TextBox_Firmware_Ver
        '
        Me.TextBox_Firmware_Ver.Location = New System.Drawing.Point(137, 41)
        Me.TextBox_Firmware_Ver.Name = "TextBox_Firmware_Ver"
        Me.TextBox_Firmware_Ver.Size = New System.Drawing.Size(165, 22)
        Me.TextBox_Firmware_Ver.TabIndex = 12
        '
        'lbl_SCAN
        '
        Me.lbl_SCAN.Location = New System.Drawing.Point(13, 99)
        Me.lbl_SCAN.Name = "lbl_SCAN"
        Me.lbl_SCAN.Size = New System.Drawing.Size(100, 20)
        Me.lbl_SCAN.TabIndex = 16
        Me.lbl_SCAN.Text = "Scan Interval:"
        '
        'lbl_FPGA_VER
        '
        Me.lbl_FPGA_VER.Location = New System.Drawing.Point(13, 70)
        Me.lbl_FPGA_VER.Name = "lbl_FPGA_VER"
        Me.lbl_FPGA_VER.Size = New System.Drawing.Size(100, 20)
        Me.lbl_FPGA_VER.TabIndex = 17
        Me.lbl_FPGA_VER.Text = "FPGA Version:"
        '
        'lbl_Controller_Firmware_Ver
        '
        Me.lbl_Controller_Firmware_Ver.Location = New System.Drawing.Point(13, 41)
        Me.lbl_Controller_Firmware_Ver.Name = "lbl_Controller_Firmware_Ver"
        Me.lbl_Controller_Firmware_Ver.Size = New System.Drawing.Size(118, 23)
        Me.lbl_Controller_Firmware_Ver.TabIndex = 18
        Me.lbl_Controller_Firmware_Ver.Text = "Firmware Version:"
        '
        'lbl_Controller_Title
        '
        Me.lbl_Controller_Title.Location = New System.Drawing.Point(13, 7)
        Me.lbl_Controller_Title.Name = "lbl_Controller_Title"
        Me.lbl_Controller_Title.Size = New System.Drawing.Size(152, 18)
        Me.lbl_Controller_Title.TabIndex = 19
        Me.lbl_Controller_Title.Text = "APAX-PAC"
        '
        'StatusBar_MAIN
        '
        Me.StatusBar_MAIN.Location = New System.Drawing.Point(0, 455)
        Me.StatusBar_MAIN.Name = "StatusBar_MAIN"
        Me.StatusBar_MAIN.Size = New System.Drawing.Size(711, 24)
        Me.StatusBar_MAIN.TabIndex = 21
        '
        'Form_APAX_Controller
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(711, 479)
        Me.Controls.Add(Me.StatusBar_MAIN)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TreeView_MAIN)
        Me.Controls.Add(Me.mainMenu_Main)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.mainMenu_Main
        Me.Name = "Form_APAX_Controller"
        Me.Text = "APAX-Controller"
        Me.mainMenu_Main.ResumeLayout(False)
        Me.mainMenu_Main.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.NumericUpDown_SCAN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents TreeView_MAIN As System.Windows.Forms.TreeView
    Friend WithEvents mainMenu_Main As System.Windows.Forms.MenuStrip
    Friend WithEvents MenuItem_Refresh_Local As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItem_Exit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Public WithEvents ListView_Module_Infor As System.Windows.Forms.ListView
    Protected WithEvents ColumnHeader_ID As System.Windows.Forms.ColumnHeader
    Private WithEvents ColumnHeader_Module As System.Windows.Forms.ColumnHeader
    Public WithEvents NumericUpDown_SCAN As System.Windows.Forms.NumericUpDown
    Public WithEvents TextBox_FPGA_Ver As System.Windows.Forms.TextBox
    Public WithEvents TextBox_Firmware_Ver As System.Windows.Forms.TextBox
    Public WithEvents lbl_SCAN As System.Windows.Forms.Label
    Public WithEvents lbl_FPGA_VER As System.Windows.Forms.Label
    Public WithEvents lbl_Controller_Firmware_Ver As System.Windows.Forms.Label
    Public WithEvents lbl_Controller_Title As System.Windows.Forms.Label
    Friend WithEvents StatusBar_MAIN As System.Windows.Forms.StatusBar

End Class
