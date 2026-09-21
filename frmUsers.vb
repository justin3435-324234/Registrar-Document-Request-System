Imports MySql.Data.MySqlClient

Public Class frmUsers
    Private isEditing As Boolean = False
    Private currentID As Integer = 0

    Private Sub frmUsers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not Session.IsAdmin() Then
            MessageBox.Show("Access denied. Only Administrators can manage users.", "Forbidden", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Close()
            Return
        End If
        cboRole.Items.AddRange(New String() {"Administrator", "Registrar Staff"})
        cboRole.SelectedIndex = 1
        cboStatus.Items.AddRange(New String() {"Active", "Inactive"})
        cboStatus.SelectedIndex = 0
        cboSearchField.Items.AddRange(New String() {"All", "Username", "FullName", "Role"})
        cboSearchField.SelectedIndex = 0
        LoadUsers()
    End Sub

    Private Sub chkShow_CheckedChanged(sender As Object, e As EventArgs) Handles chkShow.CheckedChanged
        txtPassword.UseSystemPasswordChar = Not chkShow.Checked
    End Sub

    Private Sub LoadUsers(Optional search As String = "", Optional field As String = "All")
        Try
            Using conn As MySqlConnection = dbConnection.GetConnection()
                conn.Open()
                Dim sql As String = "SELECT UserID, Username, FullName, Role, Status FROM tblusers"
                Dim cmd As MySqlCommand
                If Not String.IsNullOrWhiteSpace(search) Then
                    If field = "All" Then
                        sql &= " WHERE Username LIKE @s OR FullName LIKE @s OR Role LIKE @s"
                        cmd = New MySqlCommand(sql, conn)
                        cmd.Parameters.AddWithValue("@s", "%" & search & "%")
                    Else
                        sql &= " WHERE " & field & " LIKE @s"
                        cmd = New MySqlCommand(sql, conn)
                        cmd.Parameters.AddWithValue("@s", "%" & search & "%")
                    End If
                Else
                    cmd = New MySqlCommand(sql, conn)
                End If
                cmd.CommandText &= " ORDER BY UserID"
                Dim dt As New DataTable()
                Using da As New MySqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
                dgvUsers.DataSource = dt
                FormatGrid()
                lblCount.Text = dt.Rows.Count & " record(s)"
            End Using
        Catch ex As Exception
            MessageBox.Show("Failed to load users: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FormatGrid()
        If dgvUsers.Columns.Count = 0 Then Return
        dgvUsers.Columns("UserID").HeaderText = "ID"
        dgvUsers.Columns("Username").HeaderText = "Username"
        dgvUsers.Columns("FullName").HeaderText = "Full Name"
        dgvUsers.Columns("Role").HeaderText = "Role"
        dgvUsers.Columns("Status").HeaderText = "Status"
        dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvUsers.Columns("UserID").FillWeight = 40
        dgvUsers.Columns("Username").FillWeight = 100
        dgvUsers.Columns("FullName").FillWeight = 140
        dgvUsers.Columns("Role").FillWeight = 100
        dgvUsers.Columns("Status").FillWeight = 70
    End Sub

    Private Sub dgvUsers_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvUsers.CellClick
        If e.RowIndex < 0 Then Return
        Dim row As DataGridViewRow = dgvUsers.Rows(e.RowIndex)
        currentID = Convert.ToInt32(row.Cells("UserID").Value)
        txtUsername.Text = row.Cells("Username").Value.ToString()
        txtFullName.Text = row.Cells("FullName").Value.ToString()
        txtPassword.Clear()
        cboRole.Text = row.Cells("Role").Value.ToString()
        cboStatus.Text = row.Cells("Status").Value.ToString()
        lblUserID.Text = "ID: " & currentID
        isEditing = True
        btnAdd.Text = "Update"
        btnToggle.Enabled = True
        btnDelete.Enabled = True
    End Sub

    Private Function ValidateInput() As Boolean
        If String.IsNullOrWhiteSpace(txtUsername.Text) OrElse txtUsername.Text.Trim().Length < 3 Then
            MessageBox.Show("Username is required (min 3 characters).", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUsername.Focus()
            Return False
        End If
        If String.IsNullOrWhiteSpace(txtFullName.Text) Then
            MessageBox.Show("Full Name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtFullName.Focus()
            Return False
        End If
        If Not isEditing AndAlso String.IsNullOrWhiteSpace(txtPassword.Text) Then
            MessageBox.Show("Password is required for a new user.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Focus()
            Return False
        End If
        If Not String.IsNullOrWhiteSpace(txtPassword.Text) AndAlso txtPassword.Text.Length < 6 Then
            MessageBox.Show("Password must be at least 6 characters.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Focus()
            Return False
        End If
        If String.IsNullOrWhiteSpace(cboRole.Text) Then
            MessageBox.Show("Role is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not Session.IsAdmin() Then
            MessageBox.Show("Access denied. Only Administrators can manage users.", "Forbidden", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If Not ValidateInput() Then Return
        Try
            Using conn As MySqlConnection = dbConnection.GetConnection()
                conn.Open()
                If isEditing Then
                    If currentID = Session.CurrentUserID AndAlso cboStatus.Text <> "Active" Then
                        MessageBox.Show("You cannot deactivate your own account while logged in.", "Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Return
                    End If
                    Using chk As New MySqlCommand("SELECT COUNT(*) FROM tblusers WHERE Username=@u AND UserID<>@id", conn)
                        chk.Parameters.AddWithValue("@u", txtUsername.Text.Trim())
                        chk.Parameters.AddWithValue("@id", currentID)
                        If Convert.ToInt32(chk.ExecuteScalar()) > 0 Then
                            MessageBox.Show("Username already exists.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Return
                        End If
                    End Using
                    Dim sql As String
                    If String.IsNullOrWhiteSpace(txtPassword.Text) Then
                        sql = "UPDATE tblusers SET Username=@u, FullName=@f, Role=@r, Status=@s WHERE UserID=@id"
                    Else
                        sql = "UPDATE tblusers SET Username=@u, FullName=@f, Password=@p, Role=@r, Status=@s WHERE UserID=@id"
                    End If
                    Using cmd As New MySqlCommand(sql, conn)
                        cmd.Parameters.AddWithValue("@u", txtUsername.Text.Trim())
                        cmd.Parameters.AddWithValue("@f", txtFullName.Text.Trim())
                        If Not String.IsNullOrWhiteSpace(txtPassword.Text) Then cmd.Parameters.AddWithValue("@p", txtPassword.Text)
                        cmd.Parameters.AddWithValue("@r", cboRole.Text)
                        cmd.Parameters.AddWithValue("@s", cboStatus.Text)
                        cmd.Parameters.AddWithValue("@id", currentID)
                        cmd.ExecuteNonQuery()
                    End Using
                    MirrorUserToRegistrar(currentID)
                    MessageBox.Show("User updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    Using chk As New MySqlCommand("SELECT COUNT(*) FROM tblusers WHERE Username=@u", conn)
                        chk.Parameters.AddWithValue("@u", txtUsername.Text.Trim())
                        If Convert.ToInt32(chk.ExecuteScalar()) > 0 Then
                            MessageBox.Show("Username already exists.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Return
                        End If
                    End Using
                    Dim sql As String = "INSERT INTO tblusers (Username, Password, FullName, Role, Status) VALUES (@u,@p,@f,@r,@s)"
                    Using cmd As New MySqlCommand(sql, conn)
                        cmd.Parameters.AddWithValue("@u", txtUsername.Text.Trim())
                        cmd.Parameters.AddWithValue("@p", txtPassword.Text)
                        cmd.Parameters.AddWithValue("@f", txtFullName.Text.Trim())
                        cmd.Parameters.AddWithValue("@r", cboRole.Text)
                        cmd.Parameters.AddWithValue("@s", cboStatus.Text)
                        cmd.ExecuteNonQuery()
                    End Using
                    Dim newUserID As Integer = 0
                    Using cmdID As New MySqlCommand("SELECT LAST_INSERT_ID()", conn)
                        newUserID = Convert.ToInt32(cmdID.ExecuteScalar())
                    End Using
                    MirrorUserToRegistrar(newUserID)
                    MessageBox.Show("User added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using
            LoadUsers(txtSearch.Text.Trim(), cboSearchField.Text)
            ClearForm()
        Catch ex As MySqlException
            MessageBox.Show("DB error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnToggle_Click(sender As Object, e As EventArgs) Handles btnToggle.Click
        If currentID = 0 Then MessageBox.Show("Select a user first.", "No selection", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Return
        If currentID = Session.CurrentUserID Then
            MessageBox.Show("You cannot deactivate your own account while logged in.", "Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If MessageBox.Show("Activate / deactivate this user?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return
        Dim newStatus As String = If(cboStatus.Text = "Active", "Inactive", "Active")
        Try
            Using conn As MySqlConnection = dbConnection.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand("UPDATE tblusers SET Status=@s WHERE UserID=@id", conn)
                    cmd.Parameters.AddWithValue("@s", newStatus)
                    cmd.Parameters.AddWithValue("@id", currentID)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            MirrorUserToRegistrar(currentID)
            MessageBox.Show("Status changed to " & newStatus, "Toggled", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadUsers(txtSearch.Text.Trim(), cboSearchField.Text)
            ClearForm()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If currentID = 0 Then MessageBox.Show("Select a user to delete.", "No selection", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Return
        If currentID = Session.CurrentUserID Then
            MessageBox.Show("You cannot delete your own account while logged in.", "Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If MessageBox.Show("Delete this user? If they created requests, use Deactivate instead.", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return
        Try
            Using conn As MySqlConnection = dbConnection.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand("DELETE FROM tblusers WHERE UserID=@id", conn)
                    cmd.Parameters.AddWithValue("@id", currentID)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            MirrorUserDeleteToRegistrar(currentID)
            MessageBox.Show("Deleted.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadUsers(txtSearch.Text.Trim(), cboSearchField.Text)
            ClearForm()
        Catch ex As MySqlException
            If ex.Number = 1451 Then
                MessageBox.Show("Cannot delete: user created requests. Deactivate instead.", "In use", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show("Error: " & ex.Message)
            End If
        End Try
    End Sub

    ' Copies a user row from document_request to registrar_db (insert or overwrite).
    ' Mirror failures never block the main save - same pattern as Students/Documents.
    Private Sub MirrorUserToRegistrar(userID As Integer)
        Try
            Dim username As String = "", password As String = "", fullName As String = "", role As String = "", status As String = ""
            Using conn As MySqlConnection = dbConnection.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand("SELECT Username, Password, FullName, Role, Status FROM tblusers WHERE UserID=@id", conn)
                    cmd.Parameters.AddWithValue("@id", userID)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If Not reader.Read() Then Return
                        username = reader("Username").ToString()
                        password = reader("Password").ToString()
                        fullName = reader("FullName").ToString()
                        role = reader("Role").ToString()
                        status = reader("Status").ToString()
                    End Using
                End Using
            End Using
            Using connR As MySqlConnection = dbConnection.GetRegistrarConnection()
                connR.Open()
                Dim sql As String = "INSERT INTO tblusers (UserID, Username, Password, FullName, Role, Status) VALUES (@id,@u,@p,@f,@r,@s) ON DUPLICATE KEY UPDATE Username=@u, Password=@p, FullName=@f, Role=@r, Status=@s"
                Using cmdR As New MySqlCommand(sql, connR)
                    cmdR.Parameters.AddWithValue("@id", userID)
                    cmdR.Parameters.AddWithValue("@u", username)
                    cmdR.Parameters.AddWithValue("@p", password)
                    cmdR.Parameters.AddWithValue("@f", fullName)
                    cmdR.Parameters.AddWithValue("@r", role)
                    cmdR.Parameters.AddWithValue("@s", status)
                    cmdR.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Debug.WriteLine("Registrar user sync failed: " & ex.Message)
        End Try
    End Sub

    Private Sub MirrorUserDeleteToRegistrar(userID As Integer)
        Try
            Using connR As MySqlConnection = dbConnection.GetRegistrarConnection()
                connR.Open()
                Using cmdR As New MySqlCommand("DELETE FROM tblusers WHERE UserID=@id", connR)
                    cmdR.Parameters.AddWithValue("@id", userID)
                    cmdR.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Debug.WriteLine("Registrar user delete sync failed: " & ex.Message)
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearForm()
    End Sub

    Private Sub ClearForm()
        txtUsername.Clear()
        txtFullName.Clear()
        txtPassword.Clear()
        chkShow.Checked = False
        cboRole.SelectedIndex = 1
        cboStatus.SelectedIndex = 0
        lblUserID.Text = "ID: (new)"
        isEditing = False
        currentID = 0
        btnAdd.Text = "Add"
        btnToggle.Enabled = False
        btnDelete.Enabled = False
        txtUsername.Focus()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        LoadUsers(txtSearch.Text.Trim(), cboSearchField.Text)
    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then btnSearch.PerformClick() : e.SuppressKeyPress = True
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        txtSearch.Clear()
        cboSearchField.SelectedIndex = 0
        LoadUsers()
        ClearForm()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub pnlForm_Paint(sender As Object, e As PaintEventArgs) Handles pnlForm.Paint

    End Sub
End Class
