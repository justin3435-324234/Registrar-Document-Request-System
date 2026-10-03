Imports MySql.Data.MySqlClient

Module StudentSearch
    Public Function FindStudents(keyword As String) As DataTable
        Dim dt As New DataTable()
        Using conn As MySqlConnection = dbConnection.GetConnection()
            conn.Open()
            Dim sql As String = "SELECT StudentID, LRN, LastName, FirstName, MiddleName, Course, YearLevel, Section, ContactNo, Status FROM tblstudents WHERE Status='Active' AND (StudentID=@exact OR LRN=@exact OR LastName LIKE @like OR FirstName LIKE @like OR MiddleName LIKE @like) ORDER BY LastName, FirstName LIMIT 50"
            Using cmd As New MySqlCommand(sql, conn)
                cmd.Parameters.AddWithValue("@exact", keyword)
                cmd.Parameters.AddWithValue("@like", "%" & keyword & "%")
                Using da As New MySqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using
        End Using
        Return dt
    End Function

    Public Function PickStudent(matches As DataTable) As String
        If matches.Rows.Count = 1 Then Return matches.Rows(0)("StudentID").ToString()
        Using f As New frmStudentPicker(matches)
            If f.ShowDialog() = DialogResult.OK Then Return f.SelectedStudentID
        End Using
        Return ""
    End Function

    Public Sub GetPaidCounts(studentID As String, ByRef paid As Integer, ByRef unpaid As Integer)
        paid = 0 : unpaid = 0
        Try
            Using conn As MySqlConnection = dbConnection.GetConnection()
                conn.Open()
                Dim sql As String = "SELECT PaymentStatus, COUNT(*) AS Cnt FROM tblrequest WHERE StudentID=@id AND Status NOT IN ('Cancelled','Inactive') GROUP BY PaymentStatus"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@id", studentID)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            If reader("PaymentStatus").ToString() = "Paid" Then
                                paid = Convert.ToInt32(reader("Cnt"))
                            Else
                                unpaid += Convert.ToInt32(reader("Cnt"))
                            End If
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Debug.WriteLine("GetPaidCounts failed: " & ex.Message)
        End Try
    End Sub

    Public Function PaidStateText(studentID As String) As String
        Dim paid As Integer = 0, unpaid As Integer = 0
        GetPaidCounts(studentID, paid, unpaid)
        If paid > 0 AndAlso unpaid > 0 Then Return paid & " PAID / " & unpaid & " UNPAID"
        If paid > 0 Then Return "PAID - " & paid & " paid request(s)"
        If unpaid > 0 Then Return "UNPAID - " & unpaid & " unpaid request(s)"
        Return "NO REQUESTS"
    End Function
End Module
