Public Class frmPasswordConfirm
    Public Confirmed As Boolean = False

    Private Sub frmPasswordConfirm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Confirmed = False
        txtPassword.Clear()
        txtPassword.Focus()
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        Dim pw As String = txtPassword.Text.Trim()
        If String.IsNullOrWhiteSpace(pw) Then
            MessageBox.Show("Enter administrator password to edit.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtPassword.Focus()
            Return
        End If
        Try
            Using conn As MySql.Data.MySqlClient.MySqlConnection = dbConnection.GetConnection()
                conn.Open()
                Dim sql As String = "SELECT COUNT(*) FROM tblusers WHERE Password=@p AND Role='Administrator' AND Status='Active'"
                Using cmd As New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@p", pw)
                    If Convert.ToInt32(cmd.ExecuteScalar()) > 0 Then
                        Confirmed = True
                        Me.DialogResult = DialogResult.OK
                        Me.Close()
                    Else
                        MessageBox.Show("Invalid administrator password.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        txtPassword.Clear()
                        txtPassword.Focus()
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Verification failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Confirmed = False
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub txtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnConfirm.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub
End Class
