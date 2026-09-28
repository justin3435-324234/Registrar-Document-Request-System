<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
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
        Me.pnlBrand = New System.Windows.Forms.Panel()
        Me.pnlBrandDivider = New System.Windows.Forms.Panel()
        Me.lblBrandSubtitle = New System.Windows.Forms.Label()
        Me.lblBrandTitle2 = New System.Windows.Forms.Label()
        Me.lblBrandTitle = New System.Windows.Forms.Label()
        Me.lblBrandIcon = New System.Windows.Forms.Label()
        Me.pnlForm = New System.Windows.Forms.Panel()
        Me.pnlCard = New System.Windows.Forms.Panel()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.lblDivider = New System.Windows.Forms.Label()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.chkShow = New System.Windows.Forms.CheckBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.lblSubtitle = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pnlBrand.SuspendLayout()
        Me.pnlForm.SuspendLayout()
        Me.pnlCard.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlBrand
        '
        Me.pnlBrand.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.pnlBrand.Controls.Add(Me.pnlBrandDivider)
        Me.pnlBrand.Controls.Add(Me.lblBrandSubtitle)
        Me.pnlBrand.Controls.Add(Me.lblBrandTitle2)
        Me.pnlBrand.Controls.Add(Me.lblBrandTitle)
        Me.pnlBrand.Controls.Add(Me.lblBrandIcon)
        Me.pnlBrand.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlBrand.Location = New System.Drawing.Point(0, 0)
        Me.pnlBrand.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlBrand.Name = "pnlBrand"
        Me.pnlBrand.Size = New System.Drawing.Size(285, 468)
        Me.pnlBrand.TabIndex = 0
        '
        'pnlBrandDivider
        '
        Me.pnlBrandDivider.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.pnlBrandDivider.Location = New System.Drawing.Point(26, 272)
        Me.pnlBrandDivider.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlBrandDivider.Name = "pnlBrandDivider"
        Me.pnlBrandDivider.Size = New System.Drawing.Size(232, 1)
        Me.pnlBrandDivider.TabIndex = 5
        '
        'lblBrandSubtitle
        '
        Me.lblBrandSubtitle.AutoSize = True
        Me.lblBrandSubtitle.Font = New System.Drawing.Font("Segoe UI", 7.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBrandSubtitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.lblBrandSubtitle.Location = New System.Drawing.Point(26, 242)
        Me.lblBrandSubtitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblBrandSubtitle.Name = "lblBrandSubtitle"
        Me.lblBrandSubtitle.Size = New System.Drawing.Size(199, 17)
        Me.lblBrandSubtitle.TabIndex = 4
        Me.lblBrandSubtitle.Text = "Document Request Management"
        '
        'lblBrandTitle2
        '
        Me.lblBrandTitle2.AutoSize = True
        Me.lblBrandTitle2.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold)
        Me.lblBrandTitle2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.lblBrandTitle2.Location = New System.Drawing.Point(22, 200)
        Me.lblBrandTitle2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblBrandTitle2.Name = "lblBrandTitle2"
        Me.lblBrandTitle2.Size = New System.Drawing.Size(176, 32)
        Me.lblBrandTitle2.TabIndex = 3
        Me.lblBrandTitle2.Text = "DOCS SYSTEM"
        '
        'lblBrandTitle
        '
        Me.lblBrandTitle.AutoSize = True
        Me.lblBrandTitle.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold)
        Me.lblBrandTitle.ForeColor = System.Drawing.Color.White
        Me.lblBrandTitle.Location = New System.Drawing.Point(22, 168)
        Me.lblBrandTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblBrandTitle.Name = "lblBrandTitle"
        Me.lblBrandTitle.Size = New System.Drawing.Size(144, 32)
        Me.lblBrandTitle.TabIndex = 2
        Me.lblBrandTitle.Text = "REGISTRAR"
        '
        'lblBrandIcon
        '
        Me.lblBrandIcon.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.lblBrandIcon.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold)
        Me.lblBrandIcon.ForeColor = System.Drawing.Color.White
        Me.lblBrandIcon.Location = New System.Drawing.Point(21, 59)
        Me.lblBrandIcon.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblBrandIcon.Name = "lblBrandIcon"
        Me.lblBrandIcon.Size = New System.Drawing.Size(52, 52)
        Me.lblBrandIcon.TabIndex = 0
        Me.lblBrandIcon.Text = "◈"
        Me.lblBrandIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlForm
        '
        Me.pnlForm.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.pnlForm.Controls.Add(Me.pnlCard)
        Me.pnlForm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlForm.Location = New System.Drawing.Point(285, 0)
        Me.pnlForm.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlForm.Name = "pnlForm"
        Me.pnlForm.Padding = New System.Windows.Forms.Padding(32, 30, 32, 30)
        Me.pnlForm.Size = New System.Drawing.Size(476, 468)
        Me.pnlForm.TabIndex = 1
        '
        'pnlCard
        '
        Me.pnlCard.BackColor = System.Drawing.Color.White
        Me.pnlCard.Controls.Add(Me.btnExit)
        Me.pnlCard.Controls.Add(Me.lblDivider)
        Me.pnlCard.Controls.Add(Me.btnLogin)
        Me.pnlCard.Controls.Add(Me.chkShow)
        Me.pnlCard.Controls.Add(Me.txtPassword)
        Me.pnlCard.Controls.Add(Me.lblPassword)
        Me.pnlCard.Controls.Add(Me.txtUsername)
        Me.pnlCard.Controls.Add(Me.lblUsername)
        Me.pnlCard.Controls.Add(Me.lblSubtitle)
        Me.pnlCard.Controls.Add(Me.lblTitle)
        Me.pnlCard.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlCard.Location = New System.Drawing.Point(32, 30)
        Me.pnlCard.Margin = New System.Windows.Forms.Padding(4)
        Me.pnlCard.Name = "pnlCard"
        Me.pnlCard.Padding = New System.Windows.Forms.Padding(29, 27, 29, 27)
        Me.pnlCard.Size = New System.Drawing.Size(412, 408)
        Me.pnlCard.TabIndex = 0
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.White
        Me.btnExit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.btnExit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.btnExit.Location = New System.Drawing.Point(32, 325)
        Me.btnExit.Margin = New System.Windows.Forms.Padding(4)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(352, 39)
        Me.btnExit.TabIndex = 9
        Me.btnExit.Text = "EXIT"
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'lblDivider
        '
        Me.lblDivider.BackColor = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.lblDivider.Location = New System.Drawing.Point(32, 310)
        Me.lblDivider.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblDivider.Name = "lblDivider"
        Me.lblDivider.Size = New System.Drawing.Size(352, 1)
        Me.lblDivider.TabIndex = 8
        '
        'btnLogin
        '
        Me.btnLogin.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(99, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLogin.FlatAppearance.BorderSize = 0
        Me.btnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(78, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogin.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnLogin.ForeColor = System.Drawing.Color.White
        Me.btnLogin.Location = New System.Drawing.Point(32, 251)
        Me.btnLogin.Margin = New System.Windows.Forms.Padding(4)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(352, 47)
        Me.btnLogin.TabIndex = 7
        Me.btnLogin.Text = "SIGN IN  →"
        Me.btnLogin.UseVisualStyleBackColor = False
        '
        'chkShow
        '
        Me.chkShow.AutoSize = True
        Me.chkShow.Font = New System.Drawing.Font("Segoe UI", 7.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkShow.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.chkShow.Location = New System.Drawing.Point(32, 214)
        Me.chkShow.Margin = New System.Windows.Forms.Padding(4)
        Me.chkShow.Name = "chkShow"
        Me.chkShow.Size = New System.Drawing.Size(122, 21)
        Me.chkShow.TabIndex = 6
        Me.chkShow.Text = "Show password"
        Me.chkShow.UseVisualStyleBackColor = True
        '
        'txtPassword
        '
        Me.txtPassword.BackColor = System.Drawing.Color.White
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPassword.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txtPassword.ForeColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.txtPassword.Location = New System.Drawing.Point(32, 177)
        Me.txtPassword.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(351, 29)
        Me.txtPassword.TabIndex = 5
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblPassword.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.lblPassword.Location = New System.Drawing.Point(32, 158)
        Me.lblPassword.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(87, 19)
        Me.lblPassword.TabIndex = 4
        Me.lblPassword.Text = "PASSWORD"
        '
        'txtUsername
        '
        Me.txtUsername.BackColor = System.Drawing.Color.White
        Me.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUsername.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txtUsername.ForeColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.txtUsername.Location = New System.Drawing.Point(32, 111)
        Me.txtUsername.Margin = New System.Windows.Forms.Padding(4)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(351, 29)
        Me.txtUsername.TabIndex = 3
        '
        'lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold)
        Me.lblUsername.ForeColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(59, Byte), Integer))
        Me.lblUsername.Location = New System.Drawing.Point(32, 91)
        Me.lblUsername.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(84, 19)
        Me.lblUsername.TabIndex = 2
        Me.lblUsername.Text = "USERNAME"
        '
        'lblSubtitle
        '
        Me.lblSubtitle.AutoSize = True
        Me.lblSubtitle.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(105, Byte), Integer))
        Me.lblSubtitle.Location = New System.Drawing.Point(32, 54)
        Me.lblSubtitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblSubtitle.Name = "lblSubtitle"
        Me.lblSubtitle.Size = New System.Drawing.Size(199, 19)
        Me.lblSubtitle.TabIndex = 1
        Me.lblSubtitle.Text = "Sign in to continue to Registrar"
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.lblTitle.Location = New System.Drawing.Point(29, 22)
        Me.lblTitle.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(179, 32)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Welcome back"
        '
        'frmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(761, 468)
        Me.Controls.Add(Me.pnlForm)
        Me.Controls.Add(Me.pnlBrand)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registrar Document Request - Login"
        Me.pnlBrand.ResumeLayout(False)
        Me.pnlBrand.PerformLayout()
        Me.pnlForm.ResumeLayout(False)
        Me.pnlCard.ResumeLayout(False)
        Me.pnlCard.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlBrand As System.Windows.Forms.Panel
    Friend WithEvents lblBrandIcon As System.Windows.Forms.Label
    Friend WithEvents lblBrandTitle As System.Windows.Forms.Label
    Friend WithEvents lblBrandTitle2 As System.Windows.Forms.Label
    Friend WithEvents lblBrandSubtitle As System.Windows.Forms.Label
    Friend WithEvents pnlBrandDivider As System.Windows.Forms.Panel
    Friend WithEvents pnlForm As System.Windows.Forms.Panel
    Friend WithEvents pnlCard As System.Windows.Forms.Panel
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblSubtitle As System.Windows.Forms.Label
    Friend WithEvents lblUsername As System.Windows.Forms.Label
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents chkShow As System.Windows.Forms.CheckBox
    Friend WithEvents btnLogin As System.Windows.Forms.Button
    Friend WithEvents lblDivider As System.Windows.Forms.Label
    Friend WithEvents btnExit As System.Windows.Forms.Button
End Class
