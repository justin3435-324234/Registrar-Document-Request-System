<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMainMenu
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
        Me.pnlSidebar = New System.Windows.Forms.Panel()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnLogout = New System.Windows.Forms.Button()
        Me.btnReports = New System.Windows.Forms.Button()
        Me.btnRequestList = New System.Windows.Forms.Button()
        Me.btnUsers = New System.Windows.Forms.Button()
        Me.btnRequests = New System.Windows.Forms.Button()
        Me.btnDocuments = New System.Windows.Forms.Button()
        Me.btnStudents = New System.Windows.Forms.Button()
        Me.pnlUserCard = New System.Windows.Forms.Panel()
        Me.lblRoleBadge = New System.Windows.Forms.Label()
        Me.lblUserRole = New System.Windows.Forms.Label()
        Me.lblUserName = New System.Windows.Forms.Label()
        Me.lblUserInitial = New System.Windows.Forms.Label()
        Me.lblSidebarTitle2 = New System.Windows.Forms.Label()
        Me.lblSidebarTitle = New System.Windows.Forms.Label()
        Me.lblBrandIcon = New System.Windows.Forms.Label()
        Me.lblSidebarEyebrow = New System.Windows.Forms.Label()
        Me.pnlHeader = New System.Windows.Forms.Panel()
        Me.lblHeaderSubtitle = New System.Windows.Forms.Label()
        Me.lblHeaderTitle = New System.Windows.Forms.Label()
        Me.pnlContent = New System.Windows.Forms.Panel()
        Me.pnlContentCard = New System.Windows.Forms.Panel()
        Me.lblContentDesc = New System.Windows.Forms.Label()
        Me.lblContentTitle = New System.Windows.Forms.Label()
        Me.lblContentIcon = New System.Windows.Forms.Label()
        Me.pnlSidebar.SuspendLayout()
        Me.pnlUserCard.SuspendLayout()
        Me.pnlHeader.SuspendLayout()
        Me.pnlContent.SuspendLayout()
        Me.pnlContentCard.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlSidebar
        '
        Me.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.pnlSidebar.Controls.Add(Me.btnExit)
        Me.pnlSidebar.Controls.Add(Me.btnLogout)
        Me.pnlSidebar.Controls.Add(Me.btnReports)
        Me.pnlSidebar.Controls.Add(Me.btnRequestList)
        Me.pnlSidebar.Controls.Add(Me.btnUsers)
        Me.pnlSidebar.Controls.Add(Me.btnRequests)
        Me.pnlSidebar.Controls.Add(Me.btnDocuments)
        Me.pnlSidebar.Controls.Add(Me.btnStudents)
        Me.pnlSidebar.Controls.Add(Me.pnlUserCard)
        Me.pnlSidebar.Controls.Add(Me.lblSidebarTitle2)
        Me.pnlSidebar.Controls.Add(Me.lblSidebarTitle)
        Me.pnlSidebar.Controls.Add(Me.lblBrandIcon)
        Me.pnlSidebar.Controls.Add(Me.lblSidebarEyebrow)
        Me.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSidebar.Location = New System.Drawing.Point(0, 0)
        Me.pnlSidebar.Name = "pnlSidebar"
        Me.pnlSidebar.Size = New System.Drawing.Size(289, 661)
        Me.pnlSidebar.TabIndex = 0
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.btnExit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExit.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnExit.FlatAppearance.BorderSize = 0
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnExit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.btnExit.Location = New System.Drawing.Point(0, 577)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Padding = New System.Windows.Forms.Padding(22, 0, 0, 0)
        Me.btnExit.Size = New System.Drawing.Size(289, 42)
        Me.btnExit.TabIndex = 12
        Me.btnExit.Text = "✕   EXIT APPLICATION"
        Me.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'btnLogout
        '
        Me.btnLogout.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLogout.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnLogout.FlatAppearance.BorderSize = 0
        Me.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogout.Font = New System.Drawing.Font("Segoe UI", 10.0!, System.Drawing.FontStyle.Bold)
        Me.btnLogout.ForeColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(113, Byte), Integer), CType(CType(113, Byte), Integer))
        Me.btnLogout.Location = New System.Drawing.Point(0, 619)
        Me.btnLogout.Name = "btnLogout"
        Me.btnLogout.Padding = New System.Windows.Forms.Padding(22, 0, 0, 0)
        Me.btnLogout.Size = New System.Drawing.Size(289, 42)
        Me.btnLogout.TabIndex = 11
        Me.btnLogout.Text = "↪   LOGOUT"
        Me.btnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLogout.UseVisualStyleBackColor = False
        '
        'btnReports
        '
        Me.btnReports.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.btnReports.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnReports.FlatAppearance.BorderSize = 0
        Me.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReports.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReports.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.btnReports.Location = New System.Drawing.Point(0, 442)
        Me.btnReports.Name = "btnReports"
        Me.btnReports.Padding = New System.Windows.Forms.Padding(22, 0, 0, 0)
        Me.btnReports.Size = New System.Drawing.Size(285, 48)
        Me.btnReports.TabIndex = 10
        Me.btnReports.Text = "▭   Reports"
        Me.btnReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReports.UseVisualStyleBackColor = False
        '
        'btnRequestList
        '
        Me.btnRequestList.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.btnRequestList.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRequestList.FlatAppearance.BorderSize = 0
        Me.btnRequestList.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRequestList.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRequestList.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.btnRequestList.Location = New System.Drawing.Point(0, 394)
        Me.btnRequestList.Name = "btnRequestList"
        Me.btnRequestList.Padding = New System.Windows.Forms.Padding(22, 0, 0, 0)
        Me.btnRequestList.Size = New System.Drawing.Size(285, 48)
        Me.btnRequestList.TabIndex = 9
        Me.btnRequestList.Text = "☰   Request List"
        Me.btnRequestList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRequestList.UseVisualStyleBackColor = False
        '
        'btnUsers
        '
        Me.btnUsers.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.btnUsers.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUsers.FlatAppearance.BorderSize = 0
        Me.btnUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUsers.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUsers.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.btnUsers.Location = New System.Drawing.Point(0, 490)
        Me.btnUsers.Name = "btnUsers"
        Me.btnUsers.Padding = New System.Windows.Forms.Padding(22, 0, 0, 0)
        Me.btnUsers.Size = New System.Drawing.Size(285, 48)
        Me.btnUsers.TabIndex = 8
        Me.btnUsers.Text = "◯   User Management"
        Me.btnUsers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnUsers.UseVisualStyleBackColor = False
        '
        'btnRequests
        '
        Me.btnRequests.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.btnRequests.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRequests.FlatAppearance.BorderSize = 0
        Me.btnRequests.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRequests.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRequests.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.btnRequests.Location = New System.Drawing.Point(0, 346)
        Me.btnRequests.Name = "btnRequests"
        Me.btnRequests.Padding = New System.Windows.Forms.Padding(22, 0, 0, 0)
        Me.btnRequests.Size = New System.Drawing.Size(285, 48)
        Me.btnRequests.TabIndex = 7
        Me.btnRequests.Text = "✎   New Request"
        Me.btnRequests.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRequests.UseVisualStyleBackColor = False
        '
        'btnDocuments
        '
        Me.btnDocuments.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.btnDocuments.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDocuments.FlatAppearance.BorderSize = 0
        Me.btnDocuments.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDocuments.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDocuments.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.btnDocuments.Location = New System.Drawing.Point(0, 298)
        Me.btnDocuments.Name = "btnDocuments"
        Me.btnDocuments.Padding = New System.Windows.Forms.Padding(22, 0, 0, 0)
        Me.btnDocuments.Size = New System.Drawing.Size(285, 48)
        Me.btnDocuments.TabIndex = 6
        Me.btnDocuments.Text = "▣   Documents"
        Me.btnDocuments.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDocuments.UseVisualStyleBackColor = False
        '
        'btnStudents
        '
        Me.btnStudents.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.btnStudents.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStudents.FlatAppearance.BorderSize = 0
        Me.btnStudents.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStudents.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStudents.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.btnStudents.Location = New System.Drawing.Point(0, 250)
        Me.btnStudents.Name = "btnStudents"
        Me.btnStudents.Padding = New System.Windows.Forms.Padding(22, 0, 0, 0)
        Me.btnStudents.Size = New System.Drawing.Size(285, 48)
        Me.btnStudents.TabIndex = 5
        Me.btnStudents.Text = "👤   Students"
        Me.btnStudents.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnStudents.UseVisualStyleBackColor = False
        '
        'pnlUserCard
        '
        Me.pnlUserCard.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.pnlUserCard.Controls.Add(Me.lblRoleBadge)
        Me.pnlUserCard.Controls.Add(Me.lblUserRole)
        Me.pnlUserCard.Controls.Add(Me.lblUserName)
        Me.pnlUserCard.Controls.Add(Me.lblUserInitial)
        Me.pnlUserCard.Location = New System.Drawing.Point(11, 107)
        Me.pnlUserCard.Name = "pnlUserCard"
        Me.pnlUserCard.Size = New System.Drawing.Size(268, 88)
        Me.pnlUserCard.TabIndex = 4
        '
        'lblRoleBadge
        '
        Me.lblRoleBadge.AutoSize = True
        Me.lblRoleBadge.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.lblRoleBadge.Font = New System.Drawing.Font("Segoe UI", 7.0!, System.Drawing.FontStyle.Bold)
        Me.lblRoleBadge.ForeColor = System.Drawing.Color.White
        Me.lblRoleBadge.Location = New System.Drawing.Point(64, 54)
        Me.lblRoleBadge.Name = "lblRoleBadge"
        Me.lblRoleBadge.Padding = New System.Windows.Forms.Padding(4, 1, 4, 1)
        Me.lblRoleBadge.Size = New System.Drawing.Size(113, 17)
        Me.lblRoleBadge.TabIndex = 3
        Me.lblRoleBadge.Text = "ADMINISTRATOR"
        Me.lblRoleBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblUserRole
        '
        Me.lblUserRole.AutoSize = True
        Me.lblUserRole.Font = New System.Drawing.Font("Segoe UI", 8.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUserRole.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.lblUserRole.Location = New System.Drawing.Point(64, 34)
        Me.lblUserRole.Name = "lblUserRole"
        Me.lblUserRole.Size = New System.Drawing.Size(100, 20)
        Me.lblUserRole.TabIndex = 2
        Me.lblUserRole.Text = "Administrator"
        '
        'lblUserName
        '
        Me.lblUserName.AutoSize = True
        Me.lblUserName.Font = New System.Drawing.Font("Segoe UI", 10.5!, System.Drawing.FontStyle.Bold)
        Me.lblUserName.ForeColor = System.Drawing.Color.White
        Me.lblUserName.Location = New System.Drawing.Point(64, 12)
        Me.lblUserName.Name = "lblUserName"
        Me.lblUserName.Size = New System.Drawing.Size(196, 25)
        Me.lblUserName.TabIndex = 1
        Me.lblUserName.Text = "System Administrator"
        '
        'lblUserInitial
        '
        Me.lblUserInitial.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.lblUserInitial.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.lblUserInitial.ForeColor = System.Drawing.Color.White
        Me.lblUserInitial.Location = New System.Drawing.Point(12, 22)
        Me.lblUserInitial.Name = "lblUserInitial"
        Me.lblUserInitial.Size = New System.Drawing.Size(44, 44)
        Me.lblUserInitial.TabIndex = 0
        Me.lblUserInitial.Text = "S"
        Me.lblUserInitial.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSidebarTitle2
        '
        Me.lblSidebarTitle2.AutoSize = True
        Me.lblSidebarTitle2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblSidebarTitle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.lblSidebarTitle2.Location = New System.Drawing.Point(64, 42)
        Me.lblSidebarTitle2.Name = "lblSidebarTitle2"
        Me.lblSidebarTitle2.Size = New System.Drawing.Size(147, 28)
        Me.lblSidebarTitle2.TabIndex = 3
        Me.lblSidebarTitle2.Text = "DOCS SYSTEM"
        '
        'lblSidebarTitle
        '
        Me.lblSidebarTitle.AutoSize = True
        Me.lblSidebarTitle.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold)
        Me.lblSidebarTitle.ForeColor = System.Drawing.Color.White
        Me.lblSidebarTitle.Location = New System.Drawing.Point(69, 18)
        Me.lblSidebarTitle.Name = "lblSidebarTitle"
        Me.lblSidebarTitle.Size = New System.Drawing.Size(119, 28)
        Me.lblSidebarTitle.TabIndex = 2
        Me.lblSidebarTitle.Text = "REGISTRAR"
        '
        'lblBrandIcon
        '
        Me.lblBrandIcon.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.lblBrandIcon.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Bold)
        Me.lblBrandIcon.ForeColor = System.Drawing.Color.White
        Me.lblBrandIcon.Location = New System.Drawing.Point(14, 18)
        Me.lblBrandIcon.Name = "lblBrandIcon"
        Me.lblBrandIcon.Size = New System.Drawing.Size(44, 44)
        Me.lblBrandIcon.TabIndex = 1
        Me.lblBrandIcon.Text = "◈"
        Me.lblBrandIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSidebarEyebrow
        '
        Me.lblSidebarEyebrow.AutoSize = True
        Me.lblSidebarEyebrow.Font = New System.Drawing.Font("Segoe UI", 7.5!, System.Drawing.FontStyle.Bold)
        Me.lblSidebarEyebrow.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblSidebarEyebrow.Location = New System.Drawing.Point(14, 78)
        Me.lblSidebarEyebrow.Name = "lblSidebarEyebrow"
        Me.lblSidebarEyebrow.Size = New System.Drawing.Size(127, 17)
        Me.lblSidebarEyebrow.TabIndex = 0
        Me.lblSidebarEyebrow.Text = "MAIN NAVIGATION"
        '
        'pnlHeader
        '
        Me.pnlHeader.BackColor = System.Drawing.Color.White
        Me.pnlHeader.Controls.Add(Me.lblHeaderSubtitle)
        Me.pnlHeader.Controls.Add(Me.lblHeaderTitle)
        Me.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlHeader.Location = New System.Drawing.Point(289, 0)
        Me.pnlHeader.Name = "pnlHeader"
        Me.pnlHeader.Padding = New System.Windows.Forms.Padding(28, 16, 28, 16)
        Me.pnlHeader.Size = New System.Drawing.Size(895, 72)
        Me.pnlHeader.TabIndex = 1
        '
        'lblHeaderSubtitle
        '
        Me.lblHeaderSubtitle.AutoSize = True
        Me.lblHeaderSubtitle.Font = New System.Drawing.Font("Segoe UI", 7.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeaderSubtitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(116, Byte), Integer), CType(CType(139, Byte), Integer))
        Me.lblHeaderSubtitle.Location = New System.Drawing.Point(28, 42)
        Me.lblHeaderSubtitle.Name = "lblHeaderSubtitle"
        Me.lblHeaderSubtitle.Size = New System.Drawing.Size(335, 17)
        Me.lblHeaderSubtitle.TabIndex = 1
        Me.lblHeaderSubtitle.Text = "Manage students, documents and requests in one place"
        '
        'lblHeaderTitle
        '
        Me.lblHeaderTitle.AutoSize = True
        Me.lblHeaderTitle.Font = New System.Drawing.Font("Segoe UI", 13.0!, System.Drawing.FontStyle.Bold)
        Me.lblHeaderTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.lblHeaderTitle.Location = New System.Drawing.Point(28, 12)
        Me.lblHeaderTitle.Name = "lblHeaderTitle"
        Me.lblHeaderTitle.Size = New System.Drawing.Size(389, 30)
        Me.lblHeaderTitle.TabIndex = 0
        Me.lblHeaderTitle.Text = "Registrar Document Request System"
        '
        'pnlContent
        '
        Me.pnlContent.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.pnlContent.Controls.Add(Me.pnlContentCard)
        Me.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContent.Location = New System.Drawing.Point(289, 72)
        Me.pnlContent.Name = "pnlContent"
        Me.pnlContent.Padding = New System.Windows.Forms.Padding(28, 24, 28, 24)
        Me.pnlContent.Size = New System.Drawing.Size(895, 589)
        Me.pnlContent.TabIndex = 2
        '
        'pnlContentCard
        '
        Me.pnlContentCard.BackColor = System.Drawing.Color.White
        Me.pnlContentCard.Controls.Add(Me.lblContentDesc)
        Me.pnlContentCard.Controls.Add(Me.lblContentTitle)
        Me.pnlContentCard.Controls.Add(Me.lblContentIcon)
        Me.pnlContentCard.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlContentCard.Location = New System.Drawing.Point(28, 24)
        Me.pnlContentCard.Name = "pnlContentCard"
        Me.pnlContentCard.Padding = New System.Windows.Forms.Padding(24)
        Me.pnlContentCard.Size = New System.Drawing.Size(839, 541)
        Me.pnlContentCard.TabIndex = 0
        '
        'lblContentDesc
        '
        Me.lblContentDesc.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblContentDesc.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContentDesc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblContentDesc.Location = New System.Drawing.Point(44, 230)
        Me.lblContentDesc.Name = "lblContentDesc"
        Me.lblContentDesc.Size = New System.Drawing.Size(750, 160)
        Me.lblContentDesc.TabIndex = 2
        Me.lblContentDesc.Text = "Welcome description"
        Me.lblContentDesc.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblContentTitle
        '
        Me.lblContentTitle.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblContentTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblContentTitle.Font = New System.Drawing.Font("Segoe UI", 22.0!, System.Drawing.FontStyle.Bold)
        Me.lblContentTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.lblContentTitle.Location = New System.Drawing.Point(44, 170)
        Me.lblContentTitle.Name = "lblContentTitle"
        Me.lblContentTitle.Size = New System.Drawing.Size(750, 48)
        Me.lblContentTitle.TabIndex = 1
        Me.lblContentTitle.Text = "Dashboard"
        Me.lblContentTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblContentIcon
        '
        Me.lblContentIcon.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblContentIcon.BackColor = System.Drawing.Color.FromArgb(CType(CType(239, Byte), Integer), CType(CType(246, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblContentIcon.Font = New System.Drawing.Font("Segoe UI", 28.0!, System.Drawing.FontStyle.Bold)
        Me.lblContentIcon.ForeColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.lblContentIcon.Location = New System.Drawing.Point(369, 50)
        Me.lblContentIcon.Name = "lblContentIcon"
        Me.lblContentIcon.Size = New System.Drawing.Size(100, 80)
        Me.lblContentIcon.TabIndex = 0
        Me.lblContentIcon.Text = "◈"
        Me.lblContentIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmMainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1184, 661)
        Me.Controls.Add(Me.pnlContent)
        Me.Controls.Add(Me.pnlHeader)
        Me.Controls.Add(Me.pnlSidebar)
        Me.Name = "frmMainMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registrar Document Request - Main Menu"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlSidebar.ResumeLayout(False)
        Me.pnlSidebar.PerformLayout()
        Me.pnlUserCard.ResumeLayout(False)
        Me.pnlUserCard.PerformLayout()
        Me.pnlHeader.ResumeLayout(False)
        Me.pnlHeader.PerformLayout()
        Me.pnlContent.ResumeLayout(False)
        Me.pnlContentCard.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlSidebar As System.Windows.Forms.Panel
    Friend WithEvents lblSidebarEyebrow As System.Windows.Forms.Label
    Friend WithEvents lblBrandIcon As System.Windows.Forms.Label
    Friend WithEvents lblSidebarTitle2 As System.Windows.Forms.Label
    Friend WithEvents pnlUserCard As System.Windows.Forms.Panel
    Friend WithEvents lblUserInitial As System.Windows.Forms.Label
    Friend WithEvents lblUserName As System.Windows.Forms.Label
    Friend WithEvents lblUserRole As System.Windows.Forms.Label
    Friend WithEvents lblRoleBadge As System.Windows.Forms.Label
    Friend WithEvents btnStudents As System.Windows.Forms.Button
    Friend WithEvents btnDocuments As System.Windows.Forms.Button
    Friend WithEvents btnRequests As System.Windows.Forms.Button
    Friend WithEvents btnRequestList As System.Windows.Forms.Button
    Friend WithEvents btnReports As System.Windows.Forms.Button
    Friend WithEvents btnUsers As System.Windows.Forms.Button
    Friend WithEvents btnLogout As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents pnlHeader As System.Windows.Forms.Panel
    Friend WithEvents lblHeaderTitle As System.Windows.Forms.Label
    Friend WithEvents lblHeaderSubtitle As System.Windows.Forms.Label
    Friend WithEvents pnlContent As System.Windows.Forms.Panel
    Friend WithEvents pnlContentCard As System.Windows.Forms.Panel
    Friend WithEvents lblContentIcon As System.Windows.Forms.Label
    Friend WithEvents lblContentTitle As System.Windows.Forms.Label
    Friend WithEvents lblContentDesc As System.Windows.Forms.Label
    Friend WithEvents lblSidebarTitle As Label
End Class
