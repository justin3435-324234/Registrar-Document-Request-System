Module Session
    Public CurrentUserID As Integer = 0
    Public CurrentUsername As String = ""
    Public CurrentFullName As String = ""
    Public CurrentRole As String = "" ' Administrator or Registrar Staff

    Public Sub Clear()
        CurrentUserID = 0
        CurrentUsername = ""
        CurrentFullName = ""
        CurrentRole = ""
    End Sub

    Public Function IsAdmin() As Boolean
        Return CurrentRole = "Administrator"
    End Function
End Module
