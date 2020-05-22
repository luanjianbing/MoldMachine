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
        Me.tableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.groupBox1 = New System.Windows.Forms.GroupBox
        Me.dataGridView1 = New System.Windows.Forms.DataGridView
        Me.groupBox2 = New System.Windows.Forms.GroupBox
        Me.reviewDataRichTbx = New System.Windows.Forms.RichTextBox
        Me.flowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
        Me.clmTime = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmRemoteEndPoint = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmReqHttpScheme = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmReqHttpMethod = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmFormat = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmRequestUrl = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tableLayoutPanel1.SuspendLayout()
        Me.groupBox1.SuspendLayout()
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'tableLayoutPanel1
        '
        Me.tableLayoutPanel1.ColumnCount = 1
        Me.tableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tableLayoutPanel1.Controls.Add(Me.groupBox1, 0, 0)
        Me.tableLayoutPanel1.Controls.Add(Me.groupBox2, 0, 1)
        Me.tableLayoutPanel1.Controls.Add(Me.flowLayoutPanel1, 0, 2)
        Me.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.tableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
        Me.tableLayoutPanel1.RowCount = 3
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1.0!))
        Me.tableLayoutPanel1.Size = New System.Drawing.Size(1045, 670)
        Me.tableLayoutPanel1.TabIndex = 2
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.dataGridView1)
        Me.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.groupBox1.Location = New System.Drawing.Point(4, 4)
        Me.groupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.groupBox1.Size = New System.Drawing.Size(1037, 426)
        Me.groupBox1.TabIndex = 1
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "Private Server for Handling POST Requests"
        '
        'dataGridView1
        '
        Me.dataGridView1.AllowUserToAddRows = False
        Me.dataGridView1.AllowUserToDeleteRows = False
        Me.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmTime, Me.clmRemoteEndPoint, Me.clmReqHttpScheme, Me.clmReqHttpMethod, Me.clmFormat, Me.clmRequestUrl})
        Me.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dataGridView1.Location = New System.Drawing.Point(4, 22)
        Me.dataGridView1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.dataGridView1.Name = "dataGridView1"
        Me.dataGridView1.RowTemplate.Height = 24
        Me.dataGridView1.Size = New System.Drawing.Size(1029, 400)
        Me.dataGridView1.TabIndex = 0
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.reviewDataRichTbx)
        Me.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.groupBox2.Location = New System.Drawing.Point(4, 438)
        Me.groupBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.groupBox2.Size = New System.Drawing.Size(1037, 226)
        Me.groupBox2.TabIndex = 2
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Review incoming data"
        '
        'reviewDataRichTbx
        '
        Me.reviewDataRichTbx.Dock = System.Windows.Forms.DockStyle.Fill
        Me.reviewDataRichTbx.Location = New System.Drawing.Point(4, 22)
        Me.reviewDataRichTbx.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.reviewDataRichTbx.Name = "reviewDataRichTbx"
        Me.reviewDataRichTbx.Size = New System.Drawing.Size(1029, 200)
        Me.reviewDataRichTbx.TabIndex = 0
        Me.reviewDataRichTbx.Text = ""
        '
        'flowLayoutPanel1
        '
        Me.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.flowLayoutPanel1.Location = New System.Drawing.Point(4, 672)
        Me.flowLayoutPanel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.flowLayoutPanel1.Name = "flowLayoutPanel1"
        Me.flowLayoutPanel1.Size = New System.Drawing.Size(1037, 1)
        Me.flowLayoutPanel1.TabIndex = 3
        '
        'clmTime
        '
        Me.clmTime.FillWeight = 110.0!
        Me.clmTime.HeaderText = "Time"
        Me.clmTime.Name = "clmTime"
        Me.clmTime.ReadOnly = True
        Me.clmTime.Width = 140
        '
        'clmRemoteEndPoint
        '
        Me.clmRemoteEndPoint.FillWeight = 115.0!
        Me.clmRemoteEndPoint.HeaderText = "Remote End Point"
        Me.clmRemoteEndPoint.Name = "clmRemoteEndPoint"
        Me.clmRemoteEndPoint.ReadOnly = True
        Me.clmRemoteEndPoint.Width = 160
        '
        'clmReqHttpScheme
        '
        Me.clmReqHttpScheme.FillWeight = 50.0!
        Me.clmReqHttpScheme.HeaderText = "Scheme"
        Me.clmReqHttpScheme.Name = "clmReqHttpScheme"
        Me.clmReqHttpScheme.ReadOnly = True
        Me.clmReqHttpScheme.Width = 50
        '
        'clmReqHttpMethod
        '
        Me.clmReqHttpMethod.FillWeight = 95.0!
        Me.clmReqHttpMethod.HeaderText = "HTTP Method"
        Me.clmReqHttpMethod.Name = "clmReqHttpMethod"
        Me.clmReqHttpMethod.ReadOnly = True
        Me.clmReqHttpMethod.Width = 95
        '
        'clmFormat
        '
        Me.clmFormat.FillWeight = 85.0!
        Me.clmFormat.HeaderText = "Data Format"
        Me.clmFormat.Name = "clmFormat"
        Me.clmFormat.ReadOnly = True
        Me.clmFormat.Width = 85
        '
        'clmRequestUrl
        '
        Me.clmRequestUrl.FillWeight = 272.0!
        Me.clmRequestUrl.HeaderText = "Client URL"
        Me.clmRequestUrl.Name = "clmRequestUrl"
        Me.clmRequestUrl.ReadOnly = True
        Me.clmRequestUrl.Width = 290
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1045, 670)
        Me.Controls.Add(Me.tableLayoutPanel1)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form1"
        Me.Text = "WISE-Private Server"
        Me.tableLayoutPanel1.ResumeLayout(False)
        Me.groupBox1.ResumeLayout(False)
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents tableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents dataGridView1 As System.Windows.Forms.DataGridView
    Private WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents reviewDataRichTbx As System.Windows.Forms.RichTextBox
    Private WithEvents flowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents clmTime As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmRemoteEndPoint As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmReqHttpScheme As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmReqHttpMethod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmFormat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmRequestUrl As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
