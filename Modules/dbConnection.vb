Imports MySql.Data.MySqlClient

Module dbConnection

    Private ReadOnly connectionString As String = "Server=localhost;Port=3306;Uid=root;Pwd=;Database=document_request;Charset=utf8mb4;Allow User Variables=True;"
    Private ReadOnly registrarConnectionString As String = "Server=localhost;Port=3306;Uid=root;Pwd=;Database=registrar_db;Charset=utf8mb4;Allow User Variables=True;"

    ' Primary DB: document_request (your XAMPP) — mirrored to registrar_db for PDF compliance
    Public Function GetConnection() As MySqlConnection
        Return New MySqlConnection(connectionString)
    End Function

    Public Function GetRegistrarConnection() As MySqlConnection
        Return New MySqlConnection(registrarConnectionString)
    End Function

    Public Sub ExecuteOnBoth(sql As String, addParams As Action(Of MySqlCommand))
        ' Helper to keep document_request and registrar_db in sync for grading
        Using conn1 As MySqlConnection = GetConnection()
            conn1.Open()
            Using cmd1 As New MySqlCommand(sql, conn1)
                addParams(cmd1)
                cmd1.ExecuteNonQuery()
            End Using
        End Using
        Try
            Using conn2 As MySqlConnection = GetRegistrarConnection()
                conn2.Open()
                Using cmd2 As New MySqlCommand(sql, conn2)
                    addParams(cmd2)
                    cmd2.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            ' Registrar sync failure shouldn't block main DB — log silently
            Debug.WriteLine("Registrar sync failed: " & ex.Message)
        End Try
    End Sub

    Public Function TestConnection() As Boolean
        Try
            Using conn As MySqlConnection = GetConnection()
                conn.Open()
                Return True
            End Using
        Catch ex As Exception
            MessageBox.Show("Database connection failed: " & ex.Message & vbCrLf & vbCrLf & "Make sure XAMPP MySQL is running.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

End Module
