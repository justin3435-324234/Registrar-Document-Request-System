<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRequest
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lblHeaderSub = New System.Windows.Forms.Label()
        Me.lblHeaderTitle = New System.Windows.Forms.Label()
        Me.pnlInfo = New System.Windows.Forms.Panel()
        Me.chkORDate = New System.Windows.Forms.CheckBox()
        Me.dtpORDate = New System.Windows.Forms.DateTimePicker()
        Me.lblORDate = New System.Windows.Forms.Label()
        Me.txtORNo = New System.Windows.Forms.TextBox()
        Me.lblORNo = New System.Windows.Forms.Label()
        Me.cboPaymentStatus = New System.Windows.Forms.ComboBox()
        Me.lblPayment = New System.Windows.Forms.Label()
        Me.cboRequestStatus = New System.Windows.Forms.ComboBox()
        Me.lblReqStatus = New System.Windows.Forms.Label()
        Me.lblProcessedBy = New System.Windows.Forms.Label()
        Me.lblProcessedByCap = New System.Windows.Forms.Label()
        Me.dtpRequestDate = New System.Windows.Forms.DateTimePicker()
        Me.lblReqDate = New System.Windows.Forms.Label()
        Me.txtRequestNo = New System.Windows.Forms.TextBox()
        Me.lblReqNo = New System.Windows.Forms.Label()
        Me.pnlTopRow = New System.Windows.Forms.Panel()
        Me.pnlDoc = New System.Windows.Forms.Panel()
        Me.txtDocSubtotal = New System.Windows.Forms.TextBox()
        Me.lblSubtotal = New System.Windows.Forms.Label()
        Me.numQuantity = New System.Windows.Forms.NumericUpDown()
        Me.lblQty = New System.Windows.Forms.Label()
        Me.txtDocFee = New System.Windows.Forms.TextBox()
        Me.lblFee = New System.Windows.Forms.Label()
        Me.btnAddDocument = New System.Windows.Forms.Button()
        Me.cboDocument = New System.Windows.Forms.ComboBox()
        Me.lblDoc = New System.Windows.Forms.Label()
        Me.lblDocPanelTitle = New System.Windows.Forms.Label()
        Me.pnlStudent = New System.Windows.Forms.Panel()
        Me.lblSection = New System.Windows.Forms.Label()
        Me.lblSectionCap = New System.Windows.Forms.Label()
        Me.lblYear = New System.Windows.Forms.Label()
        Me.lblYearCap = New System.Windows.Forms.Label()
        Me.lblCourse = New System.Windows.Forms.Label()
        Me.lblCourseCap = New System.Windows.Forms.Label()
        Me.lblLRN = New System.Windows.Forms.Label()
        Me.lblStudentName = New System.Windows.Forms.Label()
        Me.lblStudentNameCap = New System.Windows.Forms.Label()
        Me.btnSearchStudent = New System.Windows.Forms.Button()
        Me.txtStudentID = New System.Windows.Forms.TextBox()
        Me.lblStudentID = New System.Windows.Forms.Label()
        Me.lblStudentPanelTitle = New System.Windows.Forms.Label()
        Me.pnlGridHost = New System.Windows.Forms.Panel()
        Me.dgvDetails = New System.Windows.Forms.DataGridView()
        Me.pnlBottom = New System.Windows.Forms.Panel()
        Me.lblTotalCount = New System.Windows.Forms.Label()
        Me.btnClearAll = New System.Windows.Forms.Button()
        Me.btnSaveRequest = New System.Windows.Forms.Button()
        Me.btnRemoveDoc = New System.Windows.Forms.Button()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.lblTotalCap = New System.Windows.Forms.Label()
        Me.pnlHeader.SuspendLayout()
        Me.pnlInfo.SuspendLayout()
        Me.pnlTopRow.SuspendLayout()
        Me.pnlDoc.SuspendLayout()
        CType(Me.numQuantity, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlStudent.SuspendLayout()
        Me.pnlGridHost.SuspendLayout()
        CType(Me.dgvDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBottom.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.pnlHeader.Controls.Add(Me.btnClose)
        Me.pnlHeader.Controls.Add(Me.lblHeaderSub)
        Me.pnlHeader.Controls.Add(Me.lblHeaderTitle)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(0, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Size = New System.Drawing.Size(1150, 72)
        Me.pnlHeader.TabIndex = 0
        '
        'btnClose
        '
        Me.btnClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnClose.ForeColor = System.Drawing.Color.White
        Me.btnClose.Location = New System.Drawing.Point(1038, 18)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(96, 34)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "✕  CLOSE"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'lblHeaderSub
        '
        Me.lblHeaderSub.AutoSize = True
        Me.lblHeaderSub.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeaderSub.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.lblHeaderSub.Location = New System.Drawing.Point(16, 44)
        Me.lblHeaderSub.Name = "lblHeaderSub"
        Me.lblHeaderSub.Size = New System.Drawing.Size(235, 25)
        Me.lblHeaderSub.TabIndex = 1
        Me.lblHeaderSub.Text = "Create document request  "
        '
        'lblHeaderTitle
        '
        Me.lblHeaderTitle.AutoSize = True
        Me.lblHeaderTitle.Font = New System.Drawing.Font("Segoe UI", 16.0!, System.Drawing.FontStyle.Bold)
        Me.lblHeaderTitle.ForeColor = System.Drawing.Color.White
        Me.lblHeaderTitle.Location = New System.Drawing.Point(16, 10)
        Me.lblHeaderTitle.Name = "lblHeaderTitle"
        Me.lblHeaderTitle.Size = New System.Drawing.Size(367, 37)
        Me.lblHeaderTitle.TabIndex = 0
        Me.lblHeaderTitle.Text = "✎  New Document Request"
        '
        'pnlInfo
        '
        Me.pnlInfo.BackColor = System.Drawing.Color.White
        Me.pnlInfo.Controls.Add(Me.chkORDate)
        Me.pnlInfo.Controls.Add(Me.dtpORDate)
        Me.pnlInfo.Controls.Add(Me.lblORDate)
        Me.pnlInfo.Controls.Add(Me.txtORNo)
        Me.pnlInfo.Controls.Add(Me.lblORNo)
        Me.pnlInfo.Controls.Add(Me.cboPaymentStatus)
        Me.pnlInfo.Controls.Add(Me.lblPayment)
        Me.pnlInfo.Controls.Add(Me.cboRequestStatus)
        Me.pnlInfo.Controls.Add(Me.lblReqStatus)
        Me.pnlInfo.Controls.Add(Me.lblProcessedBy)
        Me.pnlInfo.Controls.Add(Me.lblProcessedByCap)
        Me.pnlInfo.Controls.Add(Me.dtpRequestDate)
        Me.pnlInfo.Controls.Add(Me.lblReqDate)
        Me.pnlInfo.Controls.Add(Me.txtRequestNo)
        Me.pnlInfo.Controls.Add(Me.lblReqNo)
        Me.pnlInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlInfo.Location = New System.Drawing.Point(0, 72)
        Me.pnlInfo.Name = "pnlInfo"
        Me.pnlInfo.Padding = New System.Windows.Forms.Padding(16, 10, 16, 10)
        Me.pnlInfo.Size = New System.Drawing.Size(1150, 175)
        Me.pnlInfo.TabIndex = 1
        '
        'chkORDate
        '
        Me.chkORDate.AutoSize = True
        Me.chkORDate.Location = New System.Drawing.Point(596, 125)
        Me.chkORDate.Name = "chkORDate"
        Me.chkORDate.Size = New System.Drawing.Size(18, 17)
        Me.chkORDate.TabIndex = 15
        Me.chkORDate.UseVisualStyleBackColor = True
        '
        'dtpORDate
        '
        Me.dtpORDate.Enabled = False
        Me.dtpORDate.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.dtpORDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpORDate.Location = New System.Drawing.Point(618, 119)
        Me.dtpORDate.Name = "dtpORDate"
        Me.dtpORDate.Size = New System.Drawing.Size(150, 34)
        Me.dtpORDate.TabIndex = 14
        '
        'lblORDate
        '
        Me.lblORDate.AutoSize = True
        Me.lblORDate.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblORDate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblORDate.Location = New System.Drawing.Point(618, 99)
        Me.lblORDate.Name = "lblORDate"
        Me.lblORDate.Size = New System.Drawing.Size(82, 23)
        Me.lblORDate.TabIndex = 13
        Me.lblORDate.Text = "OR DATE"
        '
        'txtORNo
        '
        Me.txtORNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtORNo.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.txtORNo.Location = New System.Drawing.Point(307, 114)
        Me.txtORNo.Name = "txtORNo"
        Me.txtORNo.Size = New System.Drawing.Size(260, 34)
        Me.txtORNo.TabIndex = 12
        '
        'lblORNo
        '
        Me.lblORNo.AutoSize = True
        Me.lblORNo.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblORNo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblORNo.Location = New System.Drawing.Point(303, 88)
        Me.lblORNo.Name = "lblORNo"
        Me.lblORNo.Size = New System.Drawing.Size(111, 23)
        Me.lblORNo.TabIndex = 11
        Me.lblORNo.Text = "OR NUMBER"
        '
        'cboPaymentStatus
        '
        Me.cboPaymentStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPaymentStatus.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.cboPaymentStatus.FormattingEnabled = True
        Me.cboPaymentStatus.Location = New System.Drawing.Point(867, 41)
        Me.cboPaymentStatus.Name = "cboPaymentStatus"
        Me.cboPaymentStatus.Size = New System.Drawing.Size(150, 36)
        Me.cboPaymentStatus.TabIndex = 10
        '
        'lblPayment
        '
        Me.lblPayment.AutoSize = True
        Me.lblPayment.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblPayment.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblPayment.Location = New System.Drawing.Point(863, 15)
        Me.lblPayment.Name = "lblPayment"
        Me.lblPayment.Size = New System.Drawing.Size(155, 23)
        Me.lblPayment.TabIndex = 9
        Me.lblPayment.Text = "PAYMENT STATUS"
        '
        'cboRequestStatus
        '
        Me.cboRequestStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRequestStatus.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.cboRequestStatus.FormattingEnabled = True
        Me.cboRequestStatus.Location = New System.Drawing.Point(670, 41)
        Me.cboRequestStatus.Name = "cboRequestStatus"
        Me.cboRequestStatus.Size = New System.Drawing.Size(150, 36)
        Me.cboRequestStatus.TabIndex = 8
        '
        'lblReqStatus
        '
        Me.lblReqStatus.AutoSize = True
        Me.lblReqStatus.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblReqStatus.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblReqStatus.Location = New System.Drawing.Point(666, 15)
        Me.lblReqStatus.Name = "lblReqStatus"
        Me.lblReqStatus.Size = New System.Drawing.Size(151, 23)
        Me.lblReqStatus.TabIndex = 7
        Me.lblReqStatus.Text = "REQUEST STATUS"
        '
        'lblProcessedBy
        '
        Me.lblProcessedBy.AutoSize = True
        Me.lblProcessedBy.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblProcessedBy.ForeColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.lblProcessedBy.Location = New System.Drawing.Point(19, 88)
        Me.lblProcessedBy.Name = "lblProcessedBy"
        Me.lblProcessedBy.Size = New System.Drawing.Size(71, 25)
        Me.lblProcessedBy.TabIndex = 6
        Me.lblProcessedBy.Text = "Admin"
        '
        'lblProcessedByCap
        '
        Me.lblProcessedByCap.AutoSize = True
        Me.lblProcessedByCap.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblProcessedByCap.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblProcessedByCap.Location = New System.Drawing.Point(21, 36)
        Me.lblProcessedByCap.Name = "lblProcessedByCap"
        Me.lblProcessedByCap.Size = New System.Drawing.Size(132, 23)
        Me.lblProcessedByCap.TabIndex = 5
        Me.lblProcessedByCap.Text = "PROCESSED BY"
        '
        'dtpRequestDate
        '
        Me.dtpRequestDate.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.dtpRequestDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpRequestDate.Location = New System.Drawing.Point(503, 36)
        Me.dtpRequestDate.Name = "dtpRequestDate"
        Me.dtpRequestDate.Size = New System.Drawing.Size(150, 34)
        Me.dtpRequestDate.TabIndex = 4
        '
        'lblReqDate
        '
        Me.lblReqDate.AutoSize = True
        Me.lblReqDate.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblReqDate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblReqDate.Location = New System.Drawing.Point(501, 15)
        Me.lblReqDate.Name = "lblReqDate"
        Me.lblReqDate.Size = New System.Drawing.Size(132, 23)
        Me.lblReqDate.TabIndex = 3
        Me.lblReqDate.Text = "REQUEST DATE"
        '
        'txtRequestNo
        '
        Me.txtRequestNo.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.txtRequestNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRequestNo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.txtRequestNo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.txtRequestNo.Location = New System.Drawing.Point(307, 36)
        Me.txtRequestNo.Name = "txtRequestNo"
        Me.txtRequestNo.ReadOnly = True
        Me.txtRequestNo.Size = New System.Drawing.Size(180, 34)
        Me.txtRequestNo.TabIndex = 2
        '
        'lblReqNo
        '
        Me.lblReqNo.AutoSize = True
        Me.lblReqNo.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblReqNo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblReqNo.Location = New System.Drawing.Point(302, 15)
        Me.lblReqNo.Name = "lblReqNo"
        Me.lblReqNo.Size = New System.Drawing.Size(161, 23)
        Me.lblReqNo.TabIndex = 1
        Me.lblReqNo.Text = "REQUEST NUMBER"
        '
        'pnlTopRow
        '
        Me.pnlTopRow.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.pnlTopRow.Controls.Add(Me.pnlDoc)
        Me.pnlTopRow.Controls.Add(Me.pnlStudent)
        Me.pnlTopRow.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlTopRow.Location = New System.Drawing.Point(0, 247)
        Me.pnlTopRow.Name = "pnlTopRow"
        Me.pnlTopRow.Padding = New System.Windows.Forms.Padding(16, 8, 16, 8)
        Me.pnlTopRow.Size = New System.Drawing.Size(1150, 253)
        Me.pnlTopRow.TabIndex = 2
        '
        'pnlDoc
        '
        Me.pnlDoc.BackColor = System.Drawing.Color.White
        Me.pnlDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlDoc.Controls.Add(Me.txtDocSubtotal)
        Me.pnlDoc.Controls.Add(Me.lblSubtotal)
        Me.pnlDoc.Controls.Add(Me.numQuantity)
        Me.pnlDoc.Controls.Add(Me.lblQty)
        Me.pnlDoc.Controls.Add(Me.txtDocFee)
        Me.pnlDoc.Controls.Add(Me.lblFee)
        Me.pnlDoc.Controls.Add(Me.btnAddDocument)
        Me.pnlDoc.Controls.Add(Me.cboDocument)
        Me.pnlDoc.Controls.Add(Me.lblDoc)
        Me.pnlDoc.Controls.Add(Me.lblDocPanelTitle)
        Me.pnlDoc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlDoc.Location = New System.Drawing.Point(724, 8)
        Me.pnlDoc.Name = "pnlDoc"
        Me.pnlDoc.Padding = New System.Windows.Forms.Padding(12, 10, 12, 10)
        Me.pnlDoc.Size = New System.Drawing.Size(410, 237)
        Me.pnlDoc.TabIndex = 1
        '
        'txtDocSubtotal
        '
        Me.txtDocSubtotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.txtDocSubtotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDocSubtotal.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.txtDocSubtotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.txtDocSubtotal.Location = New System.Drawing.Point(278, 139)
        Me.txtDocSubtotal.Name = "txtDocSubtotal"
        Me.txtDocSubtotal.ReadOnly = True
        Me.txtDocSubtotal.Size = New System.Drawing.Size(130, 36)
        Me.txtDocSubtotal.TabIndex = 9
        Me.txtDocSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblSubtotal
        '
        Me.lblSubtotal.AutoSize = True
        Me.lblSubtotal.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblSubtotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblSubtotal.Location = New System.Drawing.Point(279, 109)
        Me.lblSubtotal.Name = "lblSubtotal"
        Me.lblSubtotal.Size = New System.Drawing.Size(94, 23)
        Me.lblSubtotal.TabIndex = 8
        Me.lblSubtotal.Text = "SUBTOTAL"
        '
        'numQuantity
        '
        Me.numQuantity.Font = New System.Drawing.Font("Segoe UI", 13.0!)
        Me.numQuantity.Location = New System.Drawing.Point(172, 139)
        Me.numQuantity.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numQuantity.Name = "numQuantity"
        Me.numQuantity.Size = New System.Drawing.Size(90, 36)
        Me.numQuantity.TabIndex = 7
        Me.numQuantity.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblQty
        '
        Me.lblQty.AutoSize = True
        Me.lblQty.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblQty.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblQty.Location = New System.Drawing.Point(173, 109)
        Me.lblQty.Name = "lblQty"
        Me.lblQty.Size = New System.Drawing.Size(95, 23)
        Me.lblQty.TabIndex = 6
        Me.lblQty.Text = "QUANTITY"
        '
        'txtDocFee
        '
        Me.txtDocFee.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.txtDocFee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDocFee.Font = New System.Drawing.Font("Segoe UI", 13.0!)
        Me.txtDocFee.Location = New System.Drawing.Point(4, 139)
        Me.txtDocFee.Name = "txtDocFee"
        Me.txtDocFee.ReadOnly = True
        Me.txtDocFee.Size = New System.Drawing.Size(152, 36)
        Me.txtDocFee.TabIndex = 5
        Me.txtDocFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblFee
        '
        Me.lblFee.AutoSize = True
        Me.lblFee.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblFee.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblFee.Location = New System.Drawing.Point(5, 109)
        Me.lblFee.Name = "lblFee"
        Me.lblFee.Size = New System.Drawing.Size(70, 23)
        Me.lblFee.TabIndex = 4
        Me.lblFee.Text = "FEE  (₱)"
        '
        'btnAddDocument
        '
        Me.btnAddDocument.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(129, Byte), Integer))
        Me.btnAddDocument.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAddDocument.FlatAppearance.BorderSize = 0
        Me.btnAddDocument.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddDocument.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnAddDocument.ForeColor = System.Drawing.Color.White
        Me.btnAddDocument.Location = New System.Drawing.Point(422, 139)
        Me.btnAddDocument.Name = "btnAddDocument"
        Me.btnAddDocument.Size = New System.Drawing.Size(120, 32)
        Me.btnAddDocument.TabIndex = 3
        Me.btnAddDocument.Text = "+  ADD"
        Me.btnAddDocument.UseVisualStyleBackColor = False
        '
        'cboDocument
        '
        Me.cboDocument.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cboDocument.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDocument.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.cboDocument.FormattingEnabled = True
        Me.cboDocument.Location = New System.Drawing.Point(5, 65)
        Me.cboDocument.Name = "cboDocument"
        Me.cboDocument.Size = New System.Drawing.Size(370, 36)
        Me.cboDocument.TabIndex = 2
        '
        'lblDoc
        '
        Me.lblDoc.AutoSize = True
        Me.lblDoc.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblDoc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblDoc.Location = New System.Drawing.Point(5, 39)
        Me.lblDoc.Name = "lblDoc"
        Me.lblDoc.Size = New System.Drawing.Size(107, 23)
        Me.lblDoc.TabIndex = 1
        Me.lblDoc.Text = "DOCUMENT"
        '
        'lblDocPanelTitle
        '
        Me.lblDocPanelTitle.AutoSize = True
        Me.lblDocPanelTitle.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblDocPanelTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.lblDocPanelTitle.Location = New System.Drawing.Point(0, 2)
        Me.lblDocPanelTitle.Name = "lblDocPanelTitle"
        Me.lblDocPanelTitle.Size = New System.Drawing.Size(191, 25)
        Me.lblDocPanelTitle.TabIndex = 0
        Me.lblDocPanelTitle.Text = "Document Selection"
        '
        'pnlStudent
        '
        Me.pnlStudent.BackColor = System.Drawing.Color.White
        Me.pnlStudent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlStudent.Controls.Add(Me.lblSection)
        Me.pnlStudent.Controls.Add(Me.lblSectionCap)
        Me.pnlStudent.Controls.Add(Me.lblYear)
        Me.pnlStudent.Controls.Add(Me.lblYearCap)
        Me.pnlStudent.Controls.Add(Me.lblCourse)
        Me.pnlStudent.Controls.Add(Me.lblCourseCap)
        Me.pnlStudent.Controls.Add(Me.lblLRN)
        Me.pnlStudent.Controls.Add(Me.lblStudentName)
        Me.pnlStudent.Controls.Add(Me.lblStudentNameCap)
        Me.pnlStudent.Controls.Add(Me.btnSearchStudent)
        Me.pnlStudent.Controls.Add(Me.txtStudentID)
        Me.pnlStudent.Controls.Add(Me.lblStudentID)
        Me.pnlStudent.Controls.Add(Me.lblStudentPanelTitle)
        Me.pnlStudent.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlStudent.Location = New System.Drawing.Point(16, 8)
        Me.pnlStudent.Name = "pnlStudent"
        Me.pnlStudent.Padding = New System.Windows.Forms.Padding(12, 10, 12, 10)
        Me.pnlStudent.Size = New System.Drawing.Size(708, 237)
        Me.pnlStudent.TabIndex = 0
        '
        'lblSection
        '
        Me.lblSection.AutoSize = True
        Me.lblSection.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblSection.ForeColor = System.Drawing.Color.Gray
        Me.lblSection.Location = New System.Drawing.Point(421, 172)
        Me.lblSection.Name = "lblSection"
        Me.lblSection.Size = New System.Drawing.Size(20, 28)
        Me.lblSection.TabIndex = 12
        Me.lblSection.Text = "-"
        '
        'lblSectionCap
        '
        Me.lblSectionCap.AutoSize = True
        Me.lblSectionCap.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblSectionCap.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblSectionCap.Location = New System.Drawing.Point(421, 152)
        Me.lblSectionCap.Name = "lblSectionCap"
        Me.lblSectionCap.Size = New System.Drawing.Size(81, 23)
        Me.lblSectionCap.TabIndex = 11
        Me.lblSectionCap.Text = "SECTION"
        '
        'lblYear
        '
        Me.lblYear.AutoSize = True
        Me.lblYear.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblYear.ForeColor = System.Drawing.Color.Gray
        Me.lblYear.Location = New System.Drawing.Point(302, 142)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(20, 28)
        Me.lblYear.TabIndex = 10
        Me.lblYear.Text = "-"
        '
        'lblYearCap
        '
        Me.lblYearCap.AutoSize = True
        Me.lblYearCap.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblYearCap.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblYearCap.Location = New System.Drawing.Point(302, 122)
        Me.lblYearCap.Name = "lblYearCap"
        Me.lblYearCap.Size = New System.Drawing.Size(104, 23)
        Me.lblYearCap.TabIndex = 9
        Me.lblYearCap.Text = "YEAR LEVEL"
        '
        'lblCourse
        '
        Me.lblCourse.AutoSize = True
        Me.lblCourse.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.lblCourse.ForeColor = System.Drawing.Color.Gray
        Me.lblCourse.Location = New System.Drawing.Point(303, 199)
        Me.lblCourse.Name = "lblCourse"
        Me.lblCourse.Size = New System.Drawing.Size(20, 28)
        Me.lblCourse.TabIndex = 8
        Me.lblCourse.Text = "-"
        '
        'lblCourseCap
        '
        Me.lblCourseCap.AutoSize = True
        Me.lblCourseCap.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblCourseCap.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblCourseCap.Location = New System.Drawing.Point(303, 179)
        Me.lblCourseCap.Name = "lblCourseCap"
        Me.lblCourseCap.Size = New System.Drawing.Size(76, 23)
        Me.lblCourseCap.TabIndex = 7
        Me.lblCourseCap.Text = "COURSE"
        '
        'lblLRN
        '
        Me.lblLRN.AutoSize = True
        Me.lblLRN.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblLRN.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblLRN.Location = New System.Drawing.Point(6, 187)
        Me.lblLRN.Name = "lblLRN"
        Me.lblLRN.Size = New System.Drawing.Size(60, 23)
        Me.lblLRN.TabIndex = 6
        Me.lblLRN.Text = "LRN: -"
        '
        'lblStudentName
        '
        Me.lblStudentName.AutoSize = True
        Me.lblStudentName.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.lblStudentName.ForeColor = System.Drawing.Color.Gray
        Me.lblStudentName.Location = New System.Drawing.Point(5, 138)
        Me.lblStudentName.Name = "lblStudentName"
        Me.lblStudentName.Size = New System.Drawing.Size(22, 30)
        Me.lblStudentName.TabIndex = 5
        Me.lblStudentName.Text = "-"
        '
        'lblStudentNameCap
        '
        Me.lblStudentNameCap.AutoSize = True
        Me.lblStudentNameCap.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblStudentNameCap.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblStudentNameCap.Location = New System.Drawing.Point(5, 118)
        Me.lblStudentNameCap.Name = "lblStudentNameCap"
        Me.lblStudentNameCap.Size = New System.Drawing.Size(142, 23)
        Me.lblStudentNameCap.TabIndex = 4
        Me.lblStudentNameCap.Text = "STUDENT NAME"
        '
        'btnSearchStudent
        '
        Me.btnSearchStudent.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnSearchStudent.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSearchStudent.FlatAppearance.BorderSize = 0
        Me.btnSearchStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearchStudent.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnSearchStudent.ForeColor = System.Drawing.Color.White
        Me.btnSearchStudent.Location = New System.Drawing.Point(237, 65)
        Me.btnSearchStudent.Name = "btnSearchStudent"
        Me.btnSearchStudent.Size = New System.Drawing.Size(100, 36)
        Me.btnSearchStudent.TabIndex = 3
        Me.btnSearchStudent.Text = "SEARCH"
        Me.btnSearchStudent.UseVisualStyleBackColor = False
        '
        'txtStudentID
        '
        Me.txtStudentID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtStudentID.Font = New System.Drawing.Font("Segoe UI", 13.0!)
        Me.txtStudentID.Location = New System.Drawing.Point(4, 65)
        Me.txtStudentID.Name = "txtStudentID"
        Me.txtStudentID.Size = New System.Drawing.Size(220, 36)
        Me.txtStudentID.TabIndex = 2
        '
        'lblStudentID
        '
        Me.lblStudentID.AutoSize = True
        Me.lblStudentID.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblStudentID.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblStudentID.Location = New System.Drawing.Point(10, 39)
        Me.lblStudentID.Name = "lblStudentID"
        Me.lblStudentID.Size = New System.Drawing.Size(110, 23)
        Me.lblStudentID.TabIndex = 1
        Me.lblStudentID.Text = "STUDENT ID"
        '
        'lblStudentPanelTitle
        '
        Me.lblStudentPanelTitle.AutoSize = True
        Me.lblStudentPanelTitle.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.lblStudentPanelTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.lblStudentPanelTitle.Location = New System.Drawing.Point(5, 9)
        Me.lblStudentPanelTitle.Name = "lblStudentPanelTitle"
        Me.lblStudentPanelTitle.Size = New System.Drawing.Size(147, 25)
        Me.lblStudentPanelTitle.TabIndex = 0
        Me.lblStudentPanelTitle.Text = "Student Search"
        '
        'pnlGridHost
        '
        Me.pnlGridHost.Controls.Add(Me.dgvDetails)
        Me.pnlGridHost.Controls.Add(Me.pnlBottom)
        Me.pnlGridHost.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlGridHost.Location = New System.Drawing.Point(0, 500)
        Me.pnlGridHost.Name = "pnlGridHost"
        Me.pnlGridHost.Padding = New System.Windows.Forms.Padding(16, 8, 16, 16)
        Me.pnlGridHost.Size = New System.Drawing.Size(1150, 260)
        Me.pnlGridHost.TabIndex = 3
        '
        'dgvDetails
        '
        Me.dgvDetails.AllowUserToAddRows = False
        Me.dgvDetails.AllowUserToDeleteRows = False
        Me.dgvDetails.AllowUserToResizeColumns = False
        Me.dgvDetails.AllowUserToResizeRows = False
        Me.dgvDetails.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(252, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDetails.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDetails.ColumnHeadersHeight = 44
        Me.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDetails.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvDetails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvDetails.EnableHeadersVisualStyles = False
        Me.dgvDetails.GridColor = System.Drawing.Color.FromArgb(CType(CType(226, Byte), Integer), CType(CType(232, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.dgvDetails.Location = New System.Drawing.Point(16, 8)
        Me.dgvDetails.Name = "dgvDetails"
        Me.dgvDetails.ReadOnly = True
        Me.dgvDetails.RowHeadersVisible = False
        Me.dgvDetails.RowHeadersWidth = 51
        Me.dgvDetails.RowTemplate.Height = 40
        Me.dgvDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetails.Size = New System.Drawing.Size(1118, 150)
        Me.dgvDetails.TabIndex = 0
        '
        'pnlBottom
        '
        Me.pnlBottom.BackColor = System.Drawing.Color.White
        Me.pnlBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlBottom.Controls.Add(Me.lblTotalCount)
        Me.pnlBottom.Controls.Add(Me.btnClearAll)
        Me.pnlBottom.Controls.Add(Me.btnSaveRequest)
        Me.pnlBottom.Controls.Add(Me.btnRemoveDoc)
        Me.pnlBottom.Controls.Add(Me.lblTotal)
        Me.pnlBottom.Controls.Add(Me.lblTotalCap)
        Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBottom.Location = New System.Drawing.Point(16, 158)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Size = New System.Drawing.Size(1118, 86)
        Me.pnlBottom.TabIndex = 1
        '
        'lblTotalCount
        '
        Me.lblTotalCount.AutoSize = True
        Me.lblTotalCount.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.lblTotalCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblTotalCount.Location = New System.Drawing.Point(190, 48)
        Me.lblTotalCount.Name = "lblTotalCount"
        Me.lblTotalCount.Size = New System.Drawing.Size(119, 23)
        Me.lblTotalCount.TabIndex = 5
        Me.lblTotalCount.Text = "0 document(s)"
        '
        'btnClearAll
        '
        Me.btnClearAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClearAll.BackColor = System.Drawing.Color.White
        Me.btnClearAll.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClearAll.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(203, Byte), Integer), CType(CType(213, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.btnClearAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClearAll.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnClearAll.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.btnClearAll.Location = New System.Drawing.Point(868, 22)
        Me.btnClearAll.Name = "btnClearAll"
        Me.btnClearAll.Size = New System.Drawing.Size(110, 42)
        Me.btnClearAll.TabIndex = 4
        Me.btnClearAll.Text = "CLEAR"
        Me.btnClearAll.UseVisualStyleBackColor = False
        '
        'btnSaveRequest
        '
        Me.btnSaveRequest.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSaveRequest.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnSaveRequest.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSaveRequest.FlatAppearance.BorderSize = 0
        Me.btnSaveRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSaveRequest.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnSaveRequest.ForeColor = System.Drawing.Color.White
        Me.btnSaveRequest.Location = New System.Drawing.Point(988, 22)
        Me.btnSaveRequest.Name = "btnSaveRequest"
        Me.btnSaveRequest.Size = New System.Drawing.Size(110, 42)
        Me.btnSaveRequest.TabIndex = 3
        Me.btnSaveRequest.Text = "SAVE"
        Me.btnSaveRequest.UseVisualStyleBackColor = False
        '
        'btnRemoveDoc
        '
        Me.btnRemoveDoc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnRemoveDoc.BackColor = System.Drawing.Color.White
        Me.btnRemoveDoc.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRemoveDoc.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(113, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.btnRemoveDoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRemoveDoc.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Bold)
        Me.btnRemoveDoc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(38, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.btnRemoveDoc.Location = New System.Drawing.Point(748, 22)
        Me.btnRemoveDoc.Name = "btnRemoveDoc"
        Me.btnRemoveDoc.Size = New System.Drawing.Size(110, 42)
        Me.btnRemoveDoc.TabIndex = 2
        Me.btnRemoveDoc.Text = "REMOVE"
        Me.btnRemoveDoc.UseVisualStyleBackColor = False
        '
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Segoe UI", 20.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.lblTotal.Location = New System.Drawing.Point(16, 34)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(120, 46)
        Me.lblTotal.TabIndex = 1
        Me.lblTotal.Text = "₱ 0.00"
        '
        'lblTotalCap
        '
        Me.lblTotalCap.AutoSize = True
        Me.lblTotalCap.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.lblTotalCap.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblTotalCap.Location = New System.Drawing.Point(16, 14)
        Me.lblTotalCap.Name = "lblTotalCap"
        Me.lblTotalCap.Size = New System.Drawing.Size(142, 23)
        Me.lblTotalCap.TabIndex = 0
        Me.lblTotalCap.Text = "TOTAL AMOUNT"
        '
        'frmRequest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1150, 760)
        Me.Controls.Add(Me.pnlGridHost)
        Me.Controls.Add(Me.pnlTopRow)
        Me.Controls.Add(Me.pnlInfo)
        Me.Controls.Add(Me.pnlHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmRequest"
        Me.Text = "New Document Request"
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlInfo.ResumeLayout(False)
        Me.pnlInfo.PerformLayout()
        Me.pnlTopRow.ResumeLayout(False)
        Me.pnlDoc.ResumeLayout(False)
        Me.pnlDoc.PerformLayout()
        CType(Me.numQuantity, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlStudent.ResumeLayout(False)
        Me.pnlStudent.PerformLayout()
        Me.pnlGridHost.ResumeLayout(False)
        CType(Me.dgvDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBottom.ResumeLayout(False)
        Me.pnlBottom.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblHeaderTitle As System.Windows.Forms.Label
    Friend WithEvents lblHeaderSub As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents pnlInfo As System.Windows.Forms.Panel
    Friend WithEvents lblReqNo As System.Windows.Forms.Label
    Friend WithEvents txtRequestNo As System.Windows.Forms.TextBox
    Friend WithEvents lblReqDate As System.Windows.Forms.Label
    Friend WithEvents dtpRequestDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblProcessedByCap As System.Windows.Forms.Label
    Friend WithEvents lblProcessedBy As System.Windows.Forms.Label
    Friend WithEvents lblReqStatus As System.Windows.Forms.Label
    Friend WithEvents cboRequestStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblPayment As System.Windows.Forms.Label
    Friend WithEvents cboPaymentStatus As System.Windows.Forms.ComboBox
    Friend WithEvents lblORNo As System.Windows.Forms.Label
    Friend WithEvents txtORNo As System.Windows.Forms.TextBox
    Friend WithEvents lblORDate As System.Windows.Forms.Label
    Friend WithEvents dtpORDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkORDate As System.Windows.Forms.CheckBox
    Friend WithEvents pnlTopRow As System.Windows.Forms.Panel
    Friend WithEvents pnlStudent As System.Windows.Forms.Panel
    Friend WithEvents lblStudentPanelTitle As System.Windows.Forms.Label
    Friend WithEvents lblStudentID As System.Windows.Forms.Label
    Friend WithEvents txtStudentID As System.Windows.Forms.TextBox
    Friend WithEvents btnSearchStudent As System.Windows.Forms.Button
    Friend WithEvents lblStudentNameCap As System.Windows.Forms.Label
    Friend WithEvents lblStudentName As System.Windows.Forms.Label
    Friend WithEvents lblLRN As System.Windows.Forms.Label
    Friend WithEvents lblCourseCap As System.Windows.Forms.Label
    Friend WithEvents lblCourse As System.Windows.Forms.Label
    Friend WithEvents lblYearCap As System.Windows.Forms.Label
    Friend WithEvents lblYear As System.Windows.Forms.Label
    Friend WithEvents lblSectionCap As System.Windows.Forms.Label
    Friend WithEvents lblSection As System.Windows.Forms.Label
    Friend WithEvents pnlDoc As System.Windows.Forms.Panel
    Friend WithEvents lblDocPanelTitle As System.Windows.Forms.Label
    Friend WithEvents lblDoc As System.Windows.Forms.Label
    Friend WithEvents cboDocument As System.Windows.Forms.ComboBox
    Friend WithEvents btnAddDocument As System.Windows.Forms.Button
    Friend WithEvents lblFee As System.Windows.Forms.Label
    Friend WithEvents txtDocFee As System.Windows.Forms.TextBox
    Friend WithEvents lblQty As System.Windows.Forms.Label
    Friend WithEvents numQuantity As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblSubtotal As System.Windows.Forms.Label
    Friend WithEvents txtDocSubtotal As System.Windows.Forms.TextBox
    Friend WithEvents pnlGridHost As System.Windows.Forms.Panel
    Friend WithEvents dgvDetails As System.Windows.Forms.DataGridView
    Friend WithEvents pnlBottom As System.Windows.Forms.Panel
    Friend WithEvents lblTotalCap As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents btnRemoveDoc As System.Windows.Forms.Button
    Friend WithEvents btnSaveRequest As System.Windows.Forms.Button
    Friend WithEvents btnClearAll As System.Windows.Forms.Button
    Friend WithEvents lblTotalCount As System.Windows.Forms.Label
End Class
