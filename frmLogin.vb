Imports MySql.Data.MySqlClient

Public Class frmLogin

    Private Sub chkShow_CheckedChanged(sender As Object, e As EventArgs) Handles chkShow.CheckedChanged
        txtPassword.UseSystemPasswordChar = Not chkShow.Checked
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim username As String = txtUsername.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()

        If String.IsNullOrEmpty(username) OrElse String.IsNullOrEmpty(password) Then
            MessageBox.Show("Please enter both username and password.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            If String.IsNullOrEmpty(username) Then txtUsername.Focus() Else txtPassword.Focus()
            Return
        End If

        btnLogin.Enabled = False
        btnLogin.Text = "SIGNING IN..."
        Application.DoEvents()

        Try
            Using conn As MySqlConnection = dbConnection.GetConnection()
                conn.Open()

                ' Parameterized query prevents SQL injection (PDF requirement)
                Dim sql As String = "SELECT UserID, Username, FullName, Role FROM tblusers WHERE Username=@u AND Password=@p AND Status='Active' LIMIT 1"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@u", username)
                    cmd.Parameters.AddWithValue("@p", password)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim role As String = reader("Role").ToString()
                            Dim fullName As String = reader("FullName").ToString()
                            Dim userId As Integer = Convert.ToInt32(reader("UserID"))

                            ' Save session for Main Menu
                            Session.CurrentUserID = userId
                            Session.CurrentUsername = username
                            Session.CurrentFullName = fullName
                            Session.CurrentRole = role

                            Dim main As New frmMainMenu()
                            main.Show()
                            Me.Hide()
                            txtPassword.Clear()
                            txtUsername.Clear()
                            Return
                        Else
                            MessageBox.Show("Invalid username or password." & vbCrLf & "Try: admin / admin123  or  registrar / registrar123", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            txtPassword.Clear()
                            txtPassword.Focus()
                        End If
                    End Using
                End Using
            End Using

        Catch ex As MySqlException
            MessageBox.Show("Database error: " & ex.Message & vbCrLf & vbCrLf & "Check if XAMPP MySQL is running and database 'document_request' exists.", "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            MessageBox.Show("Unexpected error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            btnLogin.Enabled = True
            btnLogin.Text = "SIGN IN  →"
        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        If MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnLogin.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub txtUsername_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUsername.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPassword.Focus()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Optional: test connection on load silently
        ' dbConnection.TestConnection() - uncomment to show error if DB offline
        txtUsername.Focus()
    End Sub

End Class
