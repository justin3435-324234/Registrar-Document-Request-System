Public Class frmMainMenu

    Private currentChild As Form = Nothing

    Private Sub frmMainMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Show logged in user info
        lblUserName.Text = Session.CurrentFullName
        lblUserRole.Text = Session.CurrentRole
        lblUserInitial.Text = If(String.IsNullOrEmpty(Session.CurrentFullName), "?", Session.CurrentFullName.Substring(0, 1).ToUpper())

        ' Role-based visibility (PDF IV. SYSTEM USERS)
        ' Administrator: can manage users, students, documents, view requests, reports
        ' Registrar Staff: search students, create requests, record payment, update status, view reports
        If Session.IsAdmin() Then
            btnUsers.Enabled = True
            btnUsers.Visible = True
            lblRoleBadge.Text = "ADMINISTRATOR"
            lblRoleBadge.BackColor = Color.FromArgb(37, 99, 235)
        Else
            ' Registrar Staff - User Management hidden
            btnUsers.Enabled = False
            btnUsers.Visible = False
            lblRoleBadge.Text = "REGISTRAR STAFF"
            lblRoleBadge.BackColor = Color.FromArgb(16, 185, 129)
        End If

        ' Highlight default dashboard - welcoming big view (Image 3)
        ShowDashboard()
    End Sub

    Private Sub ShowDashboard()
        ' Close embedded child if any and restore welcoming Dashboard - no sidebar highlight (your request)
        If currentChild IsNot Nothing Then
            Try
                RemoveHandler currentChild.FormClosed, AddressOf Child_FormClosed
                currentChild.Close()
                currentChild.Dispose()
            Catch
            End Try
            currentChild = Nothing
        End If
        pnlContentCard.Visible = True
        pnlContentCard.BringToFront()
        ShowPlaceholder("Dashboard", "Welcome back, " & Session.CurrentFullName & "!" & vbCrLf & "Select a module from the sidebar to get started." & vbCrLf & vbCrLf & "Your registrar workspace is ready — manage students, documents and requests in one clean place.")
        ResetNav() ' no button highlighted on Dashboard (clean)
        lblContentIcon.Text = "◈"
    End Sub

    Private Sub ResetNav()
        For Each ctrl As Control In pnlSidebar.Controls
            If TypeOf ctrl Is Button AndAlso ctrl.Name.StartsWith("btn") Then
                Dim b As Button = DirectCast(ctrl, Button)
                If b IsNot btnLogout AndAlso b IsNot btnExit Then
                    b.BackColor = Color.FromArgb(15, 23, 42)
                    b.ForeColor = Color.FromArgb(148, 163, 184)
                    b.Font = New Font("Segoe UI", 11.0!, FontStyle.Regular)
                End If
            End If
        Next
    End Sub

    Private Sub ShowPlaceholder(title As String, desc As String)
        pnlContentCard.Visible = True
        lblContentTitle.Text = title
        lblContentDesc.Text = desc
        CenterWelcome()
    End Sub

    Private Sub CenterWelcome()
        ' Keep Dashboard perfectly centered at runtime (maximized or any size) - fixes offset seen in your screenshot
        If pnlContentCard Is Nothing OrElse lblContentIcon Is Nothing Then Return
        Try
            Dim cw As Integer = pnlContentCard.ClientSize.Width
            Dim ch As Integer = pnlContentCard.ClientSize.Height
            If cw < 100 OrElse ch < 100 Then Return
            ' Center icon horizontally, place at 30% height
            lblContentIcon.Left = (cw - lblContentIcon.Width) \ 2
            lblContentIcon.Top = CInt(ch * 0.24)
            lblContentTitle.Left = (cw - lblContentTitle.Width) \ 2
            lblContentTitle.Top = lblContentIcon.Bottom + 22
            lblContentDesc.Left = (cw - lblContentDesc.Width) \ 2
            lblContentDesc.Top = lblContentTitle.Bottom + 14
        Catch
        End Try
    End Sub

    Private Sub pnlContentCard_Resize(sender As Object, e As EventArgs) Handles pnlContentCard.Resize
        If pnlContentCard.Visible Then CenterWelcome()
    End Sub

    Private Sub frmMainMenu_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        If pnlContentCard.Visible Then CenterWelcome()
    End Sub

    Private Sub EmbedForm(child As Form)
        ' Put Image 1 (Student Management) cleanly INTO Image 2 (Main Menu pnlContent) instead of floating popup
        If currentChild IsNot Nothing Then
            Try
                RemoveHandler currentChild.FormClosed, AddressOf Child_FormClosed
                pnlContent.Controls.Remove(currentChild)
                currentChild.Close()
                currentChild.Dispose()
            Catch
            End Try
        End If
        pnlContentCard.Visible = False
        child.TopLevel = False
        child.FormBorderStyle = FormBorderStyle.None
        child.Dock = DockStyle.Fill
        child.Visible = True
        AddHandler child.FormClosed, AddressOf Child_FormClosed
        pnlContent.Controls.Add(child)
        pnlContent.Controls.SetChildIndex(child, 0)
        currentChild = child
        child.Show()
        child.BringToFront()
    End Sub

    Private Sub Child_FormClosed(sender As Object, e As FormClosedEventArgs)
        Try
            pnlContent.Controls.Remove(CType(sender, Form))
        Catch
        End Try
        currentChild = Nothing
        ShowDashboard()
    End Sub

    Private Sub btnStudents_Click(sender As Object, e As EventArgs) Handles btnStudents.Click
        SetActiveButton(btnStudents)
        Dim f As New frmStudents()
        EmbedForm(f)
    End Sub

    Private Sub btnDocuments_Click(sender As Object, e As EventArgs) Handles btnDocuments.Click
        SetActiveButton(btnDocuments)
        Dim f As New frmDocuments()
        EmbedForm(f)
    End Sub

    Private Sub btnRequests_Click(sender As Object, e As EventArgs) Handles btnRequests.Click
        SetActiveButton(btnRequests)
        Dim f As New frmRequest()
        EmbedForm(f)
    End Sub

    Private Sub btnRequestList_Click(sender As Object, e As EventArgs) Handles btnRequestList.Click
        SetActiveButton(btnRequestList)
        Dim f As New frmRequestList()
        EmbedForm(f)
    End Sub

    Private Sub btnReports_Click(sender As Object, e As EventArgs) Handles btnReports.Click
        SetActiveButton(btnReports)
        Dim f As New frmReports()
        EmbedForm(f)
    End Sub

    Private Sub btnUsers_Click(sender As Object, e As EventArgs) Handles btnUsers.Click
        If Not Session.IsAdmin() Then
            MessageBox.Show("Access denied. Only Administrators can manage users.", "Forbidden", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        SetActiveButton(btnUsers)
        Dim f As New frmUsers()
        EmbedForm(f)
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        If MessageBox.Show("Are you sure you want to logout?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Session.Clear()
            Dim login As New frmLogin()
            login.Show()
            Me.Close()
        End If
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        If MessageBox.Show("Are you sure you want to exit the application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub SetActiveButton(activeBtn As Button)
        ' Reset all
        For Each ctrl As Control In pnlSidebar.Controls
            If TypeOf ctrl Is Button AndAlso ctrl.Name.StartsWith("btn") Then
                Dim b As Button = DirectCast(ctrl, Button)
                If b IsNot btnLogout AndAlso b IsNot btnExit Then
                    b.BackColor = Color.FromArgb(15, 23, 42)
                    b.ForeColor = Color.FromArgb(148, 163, 184)
                    b.Font = New Font("Segoe UI", 11.0!, FontStyle.Regular)
                End If
            End If
        Next
        ' Highlight active
        activeBtn.BackColor = Color.FromArgb(37, 99, 235)
        activeBtn.ForeColor = Color.White
        activeBtn.Font = New Font("Segoe UI", 11.0!, FontStyle.Bold)
    End Sub

    Private Sub frmMainMenu_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        ' If not logged out properly and form closed, show login if session cleared
        If Session.CurrentUserID = 0 AndAlso Application.OpenForms.Count = 0 Then
            ' allow app to exit normally
        ElseIf Session.CurrentUserID = 0 Then
            ' already logged out, login already shown
        Else
            ' unexpected close -> exit app
            Application.Exit()
        End If
    End Sub

    Private Sub lblContentTitle_Click(sender As Object, e As EventArgs) Handles lblContentTitle.Click

    End Sub
End Class
