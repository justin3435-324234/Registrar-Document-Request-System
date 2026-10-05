Imports MySql.Data.MySqlClient

Module AuditHelper
    Public Function IsOverdue(requestDate As Date, status As String) As Boolean
        If String.IsNullOrWhiteSpace(status) Then Return False
        Dim s As String = status.Trim()
        If s <> "Pending" AndAlso s <> "Processing" Then Return False
        Return (DateTime.Today - requestDate.Date).TotalDays > 7
    End Function

    Public Function StatusOrder(status As String) As Integer
        Select Case status
            Case "Pending" : Return 0
            Case "Processing" : Return 1
            Case "Ready for Release" : Return 2
            Case "Released" : Return 3
            Case "Cancelled" : Return 99
            Case "Inactive" : Return 100
            Case Else : Return -1
        End Select
    End Function

    Public Function AllowedNextStatuses(currentStatus As String) As List(Of String)
        Dim list As New List(Of String)()
        Select Case currentStatus
            Case "Pending"
                list.AddRange(New String() {"Pending", "Processing", "Cancelled"})
            Case "Processing"
                list.AddRange(New String() {"Processing", "Ready for Release", "Cancelled"})
            Case "Ready for Release"
                list.AddRange(New String() {"Ready for Release", "Released", "Cancelled"})
            Case "Released", "Cancelled", "Inactive"
                list.Add(currentStatus)
            Case Else
                list.Add(currentStatus)
        End Select
        Return list
    End Function

    Public Function CanMoveStatus(oldStatus As String, newStatus As String) As Boolean
        If oldStatus = newStatus Then Return True
        If oldStatus = "Released" OrElse oldStatus = "Cancelled" OrElse oldStatus = "Inactive" Then Return False
        Dim oldOrd As Integer = StatusOrder(oldStatus)
        Dim newOrd As Integer = StatusOrder(newStatus)
        If newStatus = "Cancelled" Then Return True
        If oldOrd >= 0 AndAlso newOrd >= 0 AndAlso newOrd < 90 Then
            Return newOrd = oldOrd OrElse newOrd = oldOrd + 1
        End If
        Return False
    End Function

    Public Sub LogAudit(requestNo As String, actionTaken As String, oldValue As String, newValue As String, remarks As String)
        Try
            Using conn As MySqlConnection = dbConnection.GetConnection()
                conn.Open()
                Dim sql As String = "INSERT INTO tblaudittrail (RequestNo, PerformedBy, UserRole, ActionTaken, OldValue, NewValue, Remarks) VALUES (@no,@by,@role,@act,@old,@new,@rem)"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@no", If(requestNo, ""))
                    cmd.Parameters.AddWithValue("@by", Session.CurrentFullName)
                    cmd.Parameters.AddWithValue("@role", Session.CurrentRole)
                    cmd.Parameters.AddWithValue("@act", actionTaken)
                    cmd.Parameters.AddWithValue("@old", If(oldValue, ""))
                    cmd.Parameters.AddWithValue("@new", If(newValue, ""))
                    cmd.Parameters.AddWithValue("@rem", If(remarks, ""))
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Debug.WriteLine("Audit log failed: " & ex.Message)
        End Try
        Try
            Using conn As MySqlConnection = dbConnection.GetRegistrarConnection()
                conn.Open()
                Dim sql As String = "INSERT INTO tblaudittrail (RequestNo, PerformedBy, UserRole, ActionTaken, OldValue, NewValue, Remarks) VALUES (@no,@by,@role,@act,@old,@new,@rem)"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@no", If(requestNo, ""))
                    cmd.Parameters.AddWithValue("@by", Session.CurrentFullName)
                    cmd.Parameters.AddWithValue("@role", Session.CurrentRole)
                    cmd.Parameters.AddWithValue("@act", actionTaken)
                    cmd.Parameters.AddWithValue("@old", If(oldValue, ""))
                    cmd.Parameters.AddWithValue("@new", If(newValue, ""))
                    cmd.Parameters.AddWithValue("@rem", If(remarks, ""))
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            Debug.WriteLine("Registrar audit log failed: " & ex.Message)
        End Try
    End Sub
End Module
