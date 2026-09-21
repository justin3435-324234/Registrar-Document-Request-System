<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRequestDetails
    Inherits System.Windows.Forms.Form

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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lblHeaderTitle = New System.Windows.Forms.Label()
        Me.pnlInfo = New System.Windows.Forms.Panel()
        Me.lblProcessedBy = New System.Windows.Forms.Label()
        Me.lblProcessedByCap = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblTotalCap = New System.Windows.Forms.Label()
        Me.lblCourse = New System.Windows.Forms.Label()
        Me.lblCourseCap = New System.Windows.Forms.Label()
        Me.lblStudentName = New System.Windows.Forms.Label()
        Me.lblStudentNameCap = New System.Windows.Forms.Label()
        Me.lblStudentID = New System.Windows.Forms.Label()
        Me.lblStudentIDCap = New System.Windows.Forms.Label()
        Me.lblRequestDate = New System.Windows.Forms.Label()
        Me.lblRequestDateCap = New System.Windows.Forms.Label()
        Me.lblRequestNo = New System.Windows.Forms.Label()
        Me.lblRequestNoCap = New System.Windows.Forms.Label()
        Me.dgvDetails = New System.Windows.Forms.DataGridView()
        Me.pnlBottom = New System.Windows.Forms.Panel()
        Me.chkORDate = New System.Windows.Forms.CheckBox()
        Me.dtpORDate = New System.Windows.Forms.DateTimePicker()
        Me.lblORDate = New System.Windows.Forms.Label()
        Me.txtORNo = New System.Windows.Forms.TextBox()
        Me.lblORNo = New System.Windows.Forms.Label()
        Me.cboPayment = New System.Windows.Forms.ComboBox()
        Me.lblPayment = New System.Windows.Forms.Label()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.pnlHeader.SuspendLayout()
        Me.pnlInfo.SuspendLayout()
        CType(Me.dgvDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBottom.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.pnlHeader.Controls.Add(Me.btnClose)
        Me.pnlHeader.Controls.Add(Me.lblHeaderTitle)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1360, 74)
        Me.pnlHeader.TabIndex = 0
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnClose.ForeColor = System.Drawing.Color.White
        Me.btnClose.Location = New System.Drawing.Point(1192, 16)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(147, 42)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "✕  CLOSE"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'lblHeaderTitle
        '
        Me.lblHeaderTitle.AutoSize = True
        Me.lblHeaderTitle.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.lblHeaderTitle.ForeColor = System.Drawing.Color.White
        Me.lblHeaderTitle.Location = New System.Drawing.Point(24, 21)
        Me.lblHeaderTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblHeaderTitle.Name = "lblHeaderTitle"
        Me.lblHeaderTitle.Size = New System.Drawing.Size(173, 30)
        Me.lblHeaderTitle.TabIndex = 0
        Me.lblHeaderTitle.Text = "Request Details"
        '
        'pnlInfo
        '
        Me.pnlInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlInfo.BackColor = System.Drawing.Color.White
        Me.pnlInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlInfo.Controls.Add(Me.lblProcessedBy)
        Me.pnlInfo.Controls.Add(Me.lblProcessedByCap)
        Me.pnlInfo.Controls.Add(Me.lblTotal)
        Me.pnlInfo.Controls.Add(Me.lblTotalCap)
        Me.pnlInfo.Controls.Add(Me.lblCourse)
        Me.pnlInfo.Controls.Add(Me.lblCourseCap)
        Me.pnlInfo.Controls.Add(Me.lblStudentName)
        Me.pnlInfo.Controls.Add(Me.lblStudentNameCap)
        Me.pnlInfo.Controls.Add(Me.lblStudentID)
        Me.pnlInfo.Controls.Add(Me.lblStudentIDCap)
        Me.pnlInfo.Controls.Add(Me.lblRequestDate)
        Me.pnlInfo.Controls.Add(Me.lblRequestDateCap)
        Me.pnlInfo.Controls.Add(Me.lblRequestNo)
        Me.pnlInfo.Controls.Add(Me.lblRequestNoCap)
        Me.pnlInfo.Location = New System.Drawing.Point(21, 89)
        Me.pnlInfo.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlInfo.Name = "pnlInfo"
        Me.pnlInfo.Padding = New System.Windows.Forms.Padding(21, 15, 21, 15)
        Me.pnlInfo.Size = New System.Drawing.Size(1317, 184)
        Me.pnlInfo.TabIndex = 1
        '
        'lblProcessedBy
        '
        Me.lblProcessedBy.AutoSize = True
        Me.lblProcessedBy.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.lblProcessedBy.ForeColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.lblProcessedBy.Location = New System.Drawing.Point(25, 87)
        Me.lblProcessedBy.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblProcessedBy.MaximumSize = New System.Drawing.Size(400, 0)
        Me.lblProcessedBy.Name = "lblProcessedBy"
        Me.lblProcessedBy.Size = New System.Drawing.Size(68, 25)
        Me.lblProcessedBy.TabIndex = 13
        Me.lblProcessedBy.Text = "Admin"
        '
        'lblProcessedByCap
        '
        Me.lblProcessedByCap.AutoSize = True
        Me.lblProcessedByCap.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblProcessedByCap.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblProcessedByCap.Location = New System.Drawing.Point(25, 65)
        Me.lblProcessedByCap.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblProcessedByCap.Name = "lblProcessedByCap"
        Me.lblProcessedByCap.Size = New System.Drawing.Size(109, 19)
        Me.lblProcessedByCap.TabIndex = 12
        Me.lblProcessedByCap.Text = "PROCESSED BY"
        '
        'lblTotal
        '
        Me.lblTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotal.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.lblTotal.Location = New System.Drawing.Point(1027, 70)
        Me.lblTotal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(240, 35)
        Me.lblTotal.TabIndex = 11
        Me.lblTotal.Text = "₱ 0.00"
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblTotalCap
        '
        Me.lblTotalCap.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblTotalCap.AutoSize = True
        Me.lblTotalCap.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalCap.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblTotalCap.Location = New System.Drawing.Point(1145, 54)
        Me.lblTotalCap.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTotalCap.Name = "lblTotalCap"
        Me.lblTotalCap.Size = New System.Drawing.Size(117, 19)
        Me.lblTotalCap.TabIndex = 10
        Me.lblTotalCap.Text = "TOTAL AMOUNT"
        '
        'lblCourse
        '
        Me.lblCourse.AutoSize = True
        Me.lblCourse.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.lblCourse.Location = New System.Drawing.Point(573, 76)
        Me.lblCourse.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCourse.MaximumSize = New System.Drawing.Size(333, 0)
        Me.lblCourse.Name = "lblCourse"
        Me.lblCourse.Size = New System.Drawing.Size(19, 25)
        Me.lblCourse.TabIndex = 9
        Me.lblCourse.Text = "-"
        '
        'lblCourseCap
        '
        Me.lblCourseCap.AutoSize = True
        Me.lblCourseCap.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblCourseCap.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblCourseCap.Location = New System.Drawing.Point(573, 54)
        Me.lblCourseCap.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblCourseCap.Name = "lblCourseCap"
        Me.lblCourseCap.Size = New System.Drawing.Size(63, 19)
        Me.lblCourseCap.TabIndex = 8
        Me.lblCourseCap.Text = "COURSE"
        '
        'lblStudentName
        '
        Me.lblStudentName.AutoSize = True
        Me.lblStudentName.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.lblStudentName.Location = New System.Drawing.Point(337, 112)
        Me.lblStudentName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStudentName.MaximumSize = New System.Drawing.Size(467, 0)
        Me.lblStudentName.Name = "lblStudentName"
        Me.lblStudentName.Size = New System.Drawing.Size(19, 25)
        Me.lblStudentName.TabIndex = 7
        Me.lblStudentName.Text = "-"
        '
        'lblStudentNameCap
        '
        Me.lblStudentNameCap.AutoSize = True
        Me.lblStudentNameCap.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblStudentNameCap.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblStudentNameCap.Location = New System.Drawing.Point(337, 90)
        Me.lblStudentNameCap.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStudentNameCap.Name = "lblStudentNameCap"
        Me.lblStudentNameCap.Size = New System.Drawing.Size(116, 19)
        Me.lblStudentNameCap.TabIndex = 6
        Me.lblStudentNameCap.Text = "STUDENT NAME"
        '
        'lblStudentID
        '
        Me.lblStudentID.AutoSize = True
        Me.lblStudentID.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.lblStudentID.Location = New System.Drawing.Point(336, 39)
        Me.lblStudentID.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStudentID.Name = "lblStudentID"
        Me.lblStudentID.Size = New System.Drawing.Size(19, 25)
        Me.lblStudentID.TabIndex = 5
        Me.lblStudentID.Text = "-"
        '
        'lblStudentIDCap
        '
        Me.lblStudentIDCap.AutoSize = True
        Me.lblStudentIDCap.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblStudentIDCap.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblStudentIDCap.Location = New System.Drawing.Point(336, 17)
        Me.lblStudentIDCap.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStudentIDCap.Name = "lblStudentIDCap"
        Me.lblStudentIDCap.Size = New System.Drawing.Size(89, 19)
        Me.lblStudentIDCap.TabIndex = 4
        Me.lblStudentIDCap.Text = "STUDENT ID"
        '
        'lblRequestDate
        '
        Me.lblRequestDate.AutoSize = True
        Me.lblRequestDate.Font = New System.Drawing.Font("Segoe UI", 10.5!)
        Me.lblRequestDate.Location = New System.Drawing.Point(819, 123)
        Me.lblRequestDate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRequestDate.Name = "lblRequestDate"
        Me.lblRequestDate.Size = New System.Drawing.Size(19, 25)
        Me.lblRequestDate.TabIndex = 3
        Me.lblRequestDate.Text = "-"
        '
        'lblRequestDateCap
        '
        Me.lblRequestDateCap.AutoSize = True
        Me.lblRequestDateCap.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblRequestDateCap.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblRequestDateCap.Location = New System.Drawing.Point(819, 101)
        Me.lblRequestDateCap.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRequestDateCap.Name = "lblRequestDateCap"
        Me.lblRequestDateCap.Size = New System.Drawing.Size(107, 19)
        Me.lblRequestDateCap.TabIndex = 2
        Me.lblRequestDateCap.Text = "REQUEST DATE"
        '
        'lblRequestNo
        '
        Me.lblRequestNo.AutoSize = True
        Me.lblRequestNo.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.lblRequestNo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.lblRequestNo.Location = New System.Drawing.Point(818, 46)
        Me.lblRequestNo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRequestNo.MaximumSize = New System.Drawing.Size(320, 0)
        Me.lblRequestNo.Name = "lblRequestNo"
        Me.lblRequestNo.Size = New System.Drawing.Size(19, 25)
        Me.lblRequestNo.TabIndex = 1
        Me.lblRequestNo.Text = "-"
        '
        'lblRequestNoCap
        '
        Me.lblRequestNoCap.AutoSize = True
        Me.lblRequestNoCap.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblRequestNoCap.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblRequestNoCap.Location = New System.Drawing.Point(818, 27)
        Me.lblRequestNoCap.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblRequestNoCap.Name = "lblRequestNoCap"
        Me.lblRequestNoCap.Size = New System.Drawing.Size(132, 19)
        Me.lblRequestNoCap.TabIndex = 0
        Me.lblRequestNoCap.Text = "REQUEST NUMBER"
        '
        'dgvDetails
        '
        Me.dgvDetails.AllowUserToAddRows = False
        Me.dgvDetails.AllowUserToDeleteRows = False
        Me.dgvDetails.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDetails.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(252, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvDetails.ColumnHeadersHeight = 36
        Me.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDetails.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvDetails.EnableHeadersVisualStyles = False
        Me.dgvDetails.GridColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dgvDetails.Location = New System.Drawing.Point(21, 286)
        Me.dgvDetails.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvDetails.Name = "dgvDetails"
        Me.dgvDetails.ReadOnly = True
        Me.dgvDetails.RowHeadersVisible = False
        Me.dgvDetails.RowHeadersWidth = 51
        Me.dgvDetails.RowTemplate.Height = 32
        Me.dgvDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetails.Size = New System.Drawing.Size(1317, 308)
        Me.dgvDetails.TabIndex = 2
        '
        'pnlBottom
        '
        Me.pnlBottom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlBottom.BackColor = System.Drawing.Color.White
        Me.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlBottom.Controls.Add(Me.chkORDate)
        Me.pnlBottom.Controls.Add(Me.dtpORDate)
        Me.pnlBottom.Controls.Add(Me.lblORDate)
        Me.pnlBottom.Controls.Add(Me.txtORNo)
        Me.pnlBottom.Controls.Add(Me.lblORNo)
        Me.pnlBottom.Controls.Add(Me.cboPayment)
        Me.pnlBottom.Controls.Add(Me.lblPayment)
        Me.pnlBottom.Controls.Add(Me.cboStatus)
        Me.pnlBottom.Controls.Add(Me.lblStatus)
        Me.pnlBottom.Controls.Add(Me.btnSave)
        Me.pnlBottom.Location = New System.Drawing.Point(21, 606)
        Me.pnlBottom.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Padding = New System.Windows.Forms.Padding(21, 15, 21, 15)
        Me.pnlBottom.Size = New System.Drawing.Size(1317, 162)
        Me.pnlBottom.TabIndex = 3
        '
        'chkORDate
        '
        Me.chkORDate.AutoSize = True
        Me.chkORDate.Location = New System.Drawing.Point(779, 22)
        Me.chkORDate.Margin = New System.Windows.Forms.Padding(4)
        Me.chkORDate.Name = "chkORDate"
        Me.chkORDate.Size = New System.Drawing.Size(18, 17)
        Me.chkORDate.TabIndex = 9
        Me.chkORDate.UseVisualStyleBackColor = True
        '
        'dtpORDate
        '
        Me.dtpORDate.Enabled = False
        Me.dtpORDate.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.dtpORDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpORDate.Location = New System.Drawing.Point(779, 49)
        Me.dtpORDate.Margin = New System.Windows.Forms.Padding(4)
        Me.dtpORDate.Name = "dtpORDate"
        Me.dtpORDate.Size = New System.Drawing.Size(239, 30)
        Me.dtpORDate.TabIndex = 8
        '
        'lblORDate
        '
        Me.lblORDate.AutoSize = True
        Me.lblORDate.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblORDate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblORDate.Location = New System.Drawing.Point(807, 21)
        Me.lblORDate.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblORDate.Name = "lblORDate"
        Me.lblORDate.Size = New System.Drawing.Size(67, 19)
        Me.lblORDate.TabIndex = 7
        Me.lblORDate.Text = "OR DATE"
        '
        'txtORNo
        '
        Me.txtORNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtORNo.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.txtORNo.Location = New System.Drawing.Point(517, 49)
        Me.txtORNo.Margin = New System.Windows.Forms.Padding(4)
        Me.txtORNo.Name = "txtORNo"
        Me.txtORNo.Size = New System.Drawing.Size(239, 30)
        Me.txtORNo.TabIndex = 6
        '
        'lblORNo
        '
        Me.lblORNo.AutoSize = True
        Me.lblORNo.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblORNo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblORNo.Location = New System.Drawing.Point(517, 21)
        Me.lblORNo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblORNo.Name = "lblORNo"
        Me.lblORNo.Size = New System.Drawing.Size(92, 19)
        Me.lblORNo.TabIndex = 5
        Me.lblORNo.Text = "OR NUMBER"
        '
        'cboPayment
        '
        Me.cboPayment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPayment.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cboPayment.FormattingEnabled = True
        Me.cboPayment.Location = New System.Drawing.Point(269, 49)
        Me.cboPayment.Margin = New System.Windows.Forms.Padding(4)
        Me.cboPayment.Name = "cboPayment"
        Me.cboPayment.Size = New System.Drawing.Size(225, 31)
        Me.cboPayment.TabIndex = 4
        '
        'lblPayment
        '
        Me.lblPayment.AutoSize = True
        Me.lblPayment.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblPayment.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblPayment.Location = New System.Drawing.Point(269, 21)
        Me.lblPayment.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPayment.Name = "lblPayment"
        Me.lblPayment.Size = New System.Drawing.Size(128, 19)
        Me.lblPayment.TabIndex = 3
        Me.lblPayment.Text = "PAYMENT STATUS"
        '
        'cboStatus
        '
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Location = New System.Drawing.Point(21, 49)
        Me.cboStatus.Margin = New System.Windows.Forms.Padding(4)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(225, 31)
        Me.cboStatus.TabIndex = 2
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Segoe UI", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblStatus.Location = New System.Drawing.Point(21, 21)
        Me.lblStatus.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(123, 19)
        Me.lblStatus.TabIndex = 1
        Me.lblStatus.Text = "REQUEST STATUS"
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(1109, 39)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(187, 49)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "SAVE"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'frmRequestDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1360, 788)
        Me.Controls.Add(Me.pnlBottom)
        Me.Controls.Add(Me.dgvDetails)
        Me.Controls.Add(Me.pnlInfo)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRequestDetails"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Request Details"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlInfo.ResumeLayout(False)
        Me.pnlInfo.PerformLayout()
        CType(Me.dgvDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBottom.ResumeLayout(False)
        Me.pnlBottom.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblHeaderTitle As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents pnlInfo As System.Windows.Forms.Panel
    Friend WithEvents lblRequestNoCap As System.Windows.Forms.Label
    Friend WithEvents lblRequestNo As System.Windows.Forms.Label
    Friend WithEvents lblRequestDateCap As System.Windows.Forms.Label
    Friend WithEvents lblRequestDate As System.Windows.Forms.Label
    Friend WithEvents lblStudentIDCap As System.Windows.Forms.Label
    Friend WithEvents lblStudentID As System.Windows.Forms.Label
    Friend WithEvents lblStudentNameCap As System.Windows.Forms.Label
    Friend WithEvents lblStudentName As System.Windows.Forms.Label
    Friend WithEvents lblCourseCap As System.Windows.Forms.Label
    Friend WithEvents lblCourse As System.Windows.Forms.Label
    Friend WithEvents lblProcessedByCap As System.Windows.Forms.Label
    Friend WithEvents lblProcessedBy As System.Windows.Forms.Label
    Friend WithEvents lblTotalCap As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents dgvDetails As System.Windows.Forms.DataGridView
    Friend WithEvents pnlBottom As System.Windows.Forms.Panel
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblPayment As System.Windows.Forms.Label
    Friend WithEvents cboPayment As System.Windows.Forms.ComboBox
    Friend WithEvents lblORNo As System.Windows.Forms.Label
    Friend WithEvents txtORNo As System.Windows.Forms.TextBox
    Friend WithEvents lblORDate As System.Windows.Forms.Label
    Friend WithEvents dtpORDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkORDate As System.Windows.Forms.CheckBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
End Class
