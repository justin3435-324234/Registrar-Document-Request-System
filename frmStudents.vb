Imports System.Text.RegularExpressions
Imports MySql.Data.MySqlClient

Public Class frmStudents
    Private isEditing As Boolean = False
    Private originalStudentID As String = ""

    Private Sub frmStudents_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboCourse.Items.AddRange(New String() {"BSIT", "BSCS", "BSBA", "BSED", "BEED", "BSHM"})
        cboYearLevel.Items.AddRange(New String() {"1st Year", "2nd Year", "3rd Year", "4th Year"})
        cboStatus.Items.AddRange(New String() {"Active", "Inactive"})
        cboSearchField.Items.AddRange(New String() {"All", "StudentID", "LastName", "Course"})
        cboSearchField.SelectedIndex = 0
        cboStatus.SelectedIndex = 0
        txtStudentID.MaxLength = 8
        LoadStudents()
    End Sub

    Private Sub txtStudentID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtStudentID.KeyPress
        ' Allow digits, hyphen, backspace only + enforce 1323-24 (3-4 digits - 2 digits) at typing time
        If Char.IsControl(e.KeyChar) Then Return
        If e.KeyChar = "-"c Then
            ' Only one hyphen, not at start, no duplicate hyphen
            If txtStudentID.Text.Contains("-") OrElse txtStudentID.SelectionStart = 0 Then
                e.Handled = True
            End If
            Return
        End If
        If Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
            Return
        End If
        ' Enforce max lengths: prefix 3-4 digits, suffix exactly 2 digits, total 6-7 chars (or legacy 8 digits without hyphen)
        Dim txt As String = txtStudentID.Text
        Dim selStart As Integer = txtStudentID.SelectionStart
        Dim selLen As Integer = txtStudentID.SelectionLength
        ' Simulate what text would be after keypress (insert char at cursor)
        Dim newText As String = txt.Substring(0, selStart) & e.KeyChar & txt.Substring(selStart + selLen)
        If newText.Contains("-") Then
            Dim parts() As String = newText.Split("-"c)
            If parts.Length > 2 Then
                e.Handled = True
                Return
            End If
            Dim prefix As String = parts(0)
            Dim suffix As String = If(parts.Length = 2, parts(1), "")
            ' Prefix max 4 digits
            If prefix.Length > 4 Then
                e.Handled = True
                Return
            End If
            ' Suffix max 2 digits — this blocks your 1323-244 (third digit)
            If suffix.Length > 2 Then
                e.Handled = True
                Return
            End If
            ' Total hyphen format max 7 chars (4+1+2) or 6 (3+1+2)
            If newText.Length > 7 Then
                e.Handled = True
                Return
            End If
        Else
            ' No hyphen yet: could be legacy 8-digit or prefix of hyphen format
            If newText.Length > 8 Then
                e.Handled = True
                Return
            End If
            ' If typing 5th digit without hyphen, will later require hyphen — but allow up to 8 for legacy
        End If
    End Sub

    Private Sub LoadStudents(Optional search As String = "", Optional field As String = "All")
        Try
            Using conn As MySqlConnection = dbConnection.GetConnection()
                conn.Open()
                Dim sql As String = "SELECT StudentID, LRN, LastName, FirstName, MiddleName, Course, YearLevel, Section, ContactNo, Status FROM tblstudents"
                Dim cmd As MySqlCommand

                If Not String.IsNullOrWhiteSpace(search) Then
                    If field = "All" Then
                        sql &= " WHERE StudentID LIKE @s OR LRN LIKE @s OR LastName LIKE @s OR FirstName LIKE @s OR Course LIKE @s"
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

                sql &= " ORDER BY StudentID"
                ' Rebuild cmd with order if needed - ensure ordering applied
                If Not String.IsNullOrWhiteSpace(search) Then
                    ' Already has where, add order
                    Dim fullSql As String = cmd.CommandText & " ORDER BY StudentID"
                    cmd.CommandText = fullSql
                Else
                    cmd.CommandText &= " ORDER BY StudentID"
                End If

                Dim dt As New DataTable()
                Using da As New MySqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using

                dgvStudents.DataSource = dt
                FormatGrid()
                lblCount.Text = dt.Rows.Count & " record(s)"
            End Using
        Catch ex As Exception
            MessageBox.Show("Failed to load students: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FormatGrid()
        If dgvStudents.Columns.Count = 0 Then Return
        dgvStudents.Columns("StudentID").HeaderText = "Student ID"
        dgvStudents.Columns("LRN").HeaderText = "LRN"
        dgvStudents.Columns("LastName").HeaderText = "Last Name"
        dgvStudents.Columns("FirstName").HeaderText = "First Name"
        dgvStudents.Columns("MiddleName").HeaderText = "Middle"
        dgvStudents.Columns("Course").HeaderText = "Course"
        dgvStudents.Columns("YearLevel").HeaderText = "Year"
        dgvStudents.Columns("Section").HeaderText = "Section"
        dgvStudents.Columns("ContactNo").HeaderText = "Contact"
        dgvStudents.Columns("Status").HeaderText = "Status"
        dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvStudents.Columns("StudentID").FillWeight = 85
        dgvStudents.Columns("LRN").FillWeight = 95
        dgvStudents.Columns("Status").FillWeight = 60
    End Sub

    Private Sub dgvStudents_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvStudents.CellClick
        If e.RowIndex < 0 Then Return
        Dim row As DataGridViewRow = dgvStudents.Rows(e.RowIndex)
        txtStudentID.Text = row.Cells("StudentID").Value.ToString()
        txtLRN.Text = row.Cells("LRN").Value.ToString()
        txtLastName.Text = row.Cells("LastName").Value.ToString()
        txtFirstName.Text = row.Cells("FirstName").Value.ToString()
        txtMiddleName.Text = row.Cells("MiddleName").Value.ToString()
        cboCourse.Text = row.Cells("Course").Value.ToString()
        cboYearLevel.Text = row.Cells("YearLevel").Value.ToString()
        txtSection.Text = row.Cells("Section").Value.ToString()
        txtContact.Text = row.Cells("ContactNo").Value.ToString()
        cboStatus.Text = row.Cells("Status").Value.ToString()

        originalStudentID = txtStudentID.Text
        isEditing = True
        txtStudentID.ReadOnly = True
        btnAdd.Text = "Update"
        btnDelete.Enabled = True
    End Sub

    Private Function ToProperCase(src As String) As String
        If String.IsNullOrWhiteSpace(src) Then Return src
        ' Converts JUSTIN or justin -> Justin, handles multi-word
        Return StrConv(src.Trim().ToLower(), VbStrConv.ProperCase)
    End Function

    Private Sub AutoProperCase(sender As Object, e As EventArgs) Handles txtLastName.Leave, txtFirstName.Leave, txtMiddleName.Leave
        Dim tb As TextBox = CType(sender, TextBox)
        If Not String.IsNullOrWhiteSpace(tb.Text) Then
            tb.Text = ToProperCase(tb.Text)
        End If
    End Sub

    Private Sub txtStudentID_Leave(sender As Object, e As EventArgs) Handles txtStudentID.Leave
        ' Trim but keep hyphen format, auto correct spaces
        txtStudentID.Text = txtStudentID.Text.Trim()
    End Sub

    Private Function ValidateInput() As Boolean
        ' Auto proper case before validation so DB always stores Justin not JUSTIN
        If Not String.IsNullOrWhiteSpace(txtLastName.Text) Then txtLastName.Text = ToProperCase(txtLastName.Text)
        If Not String.IsNullOrWhiteSpace(txtFirstName.Text) Then txtFirstName.Text = ToProperCase(txtFirstName.Text)
        If Not String.IsNullOrWhiteSpace(txtMiddleName.Text) Then txtMiddleName.Text = ToProperCase(txtMiddleName.Text)

        If String.IsNullOrWhiteSpace(txtStudentID.Text) Then
            MessageBox.Show("Student ID is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtStudentID.Focus()
            Return False
        End If
        ' Student ID format: strictly 1323-24 style (3-4 digits hyphen 2 digits) OR legacy 20260001 (8 digits)
        Dim sid As String = txtStudentID.Text.Trim()
        Dim isHyphenFormat As Boolean = Regex.IsMatch(sid, "^\d{3,4}-\d{2}$")
        Dim isLegacy As Boolean = Regex.IsMatch(sid, "^\d{8}$")
        If Not (isHyphenFormat OrElse isLegacy) Then
            MessageBox.Show("Student ID must be in format 1323-24 (e.g., 142-24 or 1323-24)." & vbCrLf & "Use 3-4 digits, hyphen, 2 digits." & vbCrLf & "Example 1323-2444 is too long — use 1323-24.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtStudentID.Focus()
            txtStudentID.SelectAll()
            Return False
        End If
        If String.IsNullOrWhiteSpace(txtLRN.Text) Then
            MessageBox.Show("LRN is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtLRN.Focus()
            Return False
        End If
        If txtLRN.Text.Length <> 12 OrElse Not IsNumeric(txtLRN.Text) Then
            MessageBox.Show("LRN must be 12 digits.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtLRN.Focus()
            Return False
        End If
        If String.IsNullOrWhiteSpace(txtLastName.Text) OrElse String.IsNullOrWhiteSpace(txtFirstName.Text) Then
            MessageBox.Show("Last Name and First Name are required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If String.IsNullOrWhiteSpace(cboCourse.Text) Then
            MessageBox.Show("Course is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If String.IsNullOrWhiteSpace(cboYearLevel.Text) Then
            MessageBox.Show("Year Level is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        If String.IsNullOrWhiteSpace(txtSection.Text) Then
            MessageBox.Show("Section is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If
        Return True
    End Function

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not ValidateInput() Then Return

        Try
            Using conn As MySqlConnection = dbConnection.GetConnection()
                conn.Open()

                If isEditing Then
                    Dim oldStatus As String = ""
                    Using cmdOld As New MySqlCommand("SELECT Status FROM tblstudents WHERE StudentID=@id", conn)
                        cmdOld.Parameters.AddWithValue("@id", originalStudentID)
                        Dim vOld As Object = cmdOld.ExecuteScalar()
                        If vOld IsNot Nothing AndAlso vOld IsNot DBNull.Value Then oldStatus = vOld.ToString()
                    End Using
                    Dim sql As String = "UPDATE tblstudents SET LRN=@lrn, LastName=@ln, FirstName=@fn, MiddleName=@mn, Course=@c, YearLevel=@yl, Section=@sec, ContactNo=@cn, Status=@st WHERE StudentID=@id"
                    Using cmd As New MySqlCommand(sql, conn)
                        cmd.Parameters.AddWithValue("@lrn", txtLRN.Text.Trim())
                        cmd.Parameters.AddWithValue("@ln", txtLastName.Text.Trim())
                        cmd.Parameters.AddWithValue("@fn", txtFirstName.Text.Trim())
                        cmd.Parameters.AddWithValue("@mn", txtMiddleName.Text.Trim())
                        cmd.Parameters.AddWithValue("@c", cboCourse.Text)
                        cmd.Parameters.AddWithValue("@yl", cboYearLevel.Text)
                        cmd.Parameters.AddWithValue("@sec", txtSection.Text.Trim())
                        cmd.Parameters.AddWithValue("@cn", txtContact.Text.Trim())
                        cmd.Parameters.AddWithValue("@st", cboStatus.Text)
                        cmd.Parameters.AddWithValue("@id", originalStudentID)
                        Dim rows = cmd.ExecuteNonQuery()
                        If rows > 0 Then MessageBox.Show("Student updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End Using
                    ' Mirror to registrar_db for PDF compliance
                    Try
                        Using connR As MySqlConnection = dbConnection.GetRegistrarConnection()
                            connR.Open()
                            Using cmdR As New MySqlCommand(sql, connR)
                                cmdR.Parameters.AddWithValue("@lrn", txtLRN.Text.Trim())
                                cmdR.Parameters.AddWithValue("@ln", txtLastName.Text.Trim())
                                cmdR.Parameters.AddWithValue("@fn", txtFirstName.Text.Trim())
                                cmdR.Parameters.AddWithValue("@mn", txtMiddleName.Text.Trim())
                                cmdR.Parameters.AddWithValue("@c", cboCourse.Text)
                                cmdR.Parameters.AddWithValue("@yl", cboYearLevel.Text)
                                cmdR.Parameters.AddWithValue("@sec", txtSection.Text.Trim())
                                cmdR.Parameters.AddWithValue("@cn", txtContact.Text.Trim())
                                cmdR.Parameters.AddWithValue("@st", cboStatus.Text)
                                cmdR.Parameters.AddWithValue("@id", originalStudentID)
                                cmdR.ExecuteNonQuery()
                            End Using
                        End Using
                    Catch ex2 As Exception
                        Debug.WriteLine("Registrar sync update failed: " & ex2.Message)
                    End Try
                    If oldStatus = "Inactive" AndAlso cboStatus.Text = "Active" Then
                        Dim restored As Integer = RestoreStudentRequests(conn, originalStudentID)
                        RestoreStudentRequestsRegistrar(originalStudentID)
                        If restored > 0 Then MessageBox.Show(restored & " request(s) restored to their previous status.", "Requests Restored", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                Else
                    ' Check duplicate
                    Using chk As New MySqlCommand("SELECT COUNT(*) FROM tblstudents WHERE StudentID=@id", conn)
                        chk.Parameters.AddWithValue("@id", txtStudentID.Text.Trim())
                        If Convert.ToInt32(chk.ExecuteScalar()) > 0 Then
                            MessageBox.Show("Student ID already exists.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Return
                        End If
                    End Using

                    Dim sql As String = "INSERT INTO tblstudents (StudentID, LRN, LastName, FirstName, MiddleName, Course, YearLevel, Section, ContactNo, Status) VALUES (@id,@lrn,@ln,@fn,@mn,@c,@yl,@sec,@cn,@st)"
                    Using cmd As New MySqlCommand(sql, conn)
                        cmd.Parameters.AddWithValue("@id", txtStudentID.Text.Trim())
                        cmd.Parameters.AddWithValue("@lrn", txtLRN.Text.Trim())
                        cmd.Parameters.AddWithValue("@ln", txtLastName.Text.Trim())
                        cmd.Parameters.AddWithValue("@fn", txtFirstName.Text.Trim())
                        cmd.Parameters.AddWithValue("@mn", txtMiddleName.Text.Trim())
                        cmd.Parameters.AddWithValue("@c", cboCourse.Text)
                        cmd.Parameters.AddWithValue("@yl", cboYearLevel.Text)
                        cmd.Parameters.AddWithValue("@sec", txtSection.Text.Trim())
                        cmd.Parameters.AddWithValue("@cn", txtContact.Text.Trim())
                        cmd.Parameters.AddWithValue("@st", cboStatus.Text)
                        cmd.ExecuteNonQuery()
                        MessageBox.Show("Student added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End Using
                    Try
                        Using connR As MySqlConnection = dbConnection.GetRegistrarConnection()
                            connR.Open()
                            Using cmdR As New MySqlCommand(sql, connR)
                                cmdR.Parameters.AddWithValue("@id", txtStudentID.Text.Trim())
                                cmdR.Parameters.AddWithValue("@lrn", txtLRN.Text.Trim())
                                cmdR.Parameters.AddWithValue("@ln", txtLastName.Text.Trim())
                                cmdR.Parameters.AddWithValue("@fn", txtFirstName.Text.Trim())
                                cmdR.Parameters.AddWithValue("@mn", txtMiddleName.Text.Trim())
                                cmdR.Parameters.AddWithValue("@c", cboCourse.Text)
                                cmdR.Parameters.AddWithValue("@yl", cboYearLevel.Text)
                                cmdR.Parameters.AddWithValue("@sec", txtSection.Text.Trim())
                                cmdR.Parameters.AddWithValue("@cn", txtContact.Text.Trim())
                                cmdR.Parameters.AddWithValue("@st", cboStatus.Text)
                                cmdR.ExecuteNonQuery()
                            End Using
                        End Using
                    Catch ex2 As Exception
                        Debug.WriteLine("Registrar sync insert failed: " & ex2.Message)
                    End Try
                End If
            End Using
            txtSearch.Clear()
            cboSearchField.SelectedIndex = 0
            LoadStudents()
            ClearForm()
        Catch ex As MySqlException
            MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' Restores requests previously marked Inactive by deactivation to their saved status.
    ' Returns the number of restored requests. Uses the already-open main connection.
    Private Function RestoreStudentRequests(conn As MySqlConnection, studentID As String) As Integer
        Try
            Using cmd As New MySqlCommand("UPDATE tblrequest SET Status=PrevStatus, PrevStatus=NULL WHERE StudentID=@id AND Status='Inactive' AND PrevStatus IS NOT NULL", conn)
                cmd.Parameters.AddWithValue("@id", studentID)
                Return cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MessageBox.Show("Student updated, but request restore failed: " & ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return 0
        End Try
    End Function

    Private Sub RestoreStudentRequestsRegistrar(studentID As String)
        Try
            Using connR As MySqlConnection = dbConnection.GetRegistrarConnection()
                connR.Open()
                Using cmdR As New MySqlCommand("UPDATE tblrequest SET Status=PrevStatus, PrevStatus=NULL WHERE StudentID=@id AND Status='Inactive' AND PrevStatus IS NOT NULL", connR)
                    cmdR.Parameters.AddWithValue("@id", studentID)
                    cmdR.ExecuteNonQuery()
                End Using
            End Using
        Catch ex2 As Exception
            Debug.WriteLine("Registrar request restore failed: " & ex2.Message)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If String.IsNullOrWhiteSpace(originalStudentID) Then
            MessageBox.Show("Please select a student to delete/deactivate.", "No selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        ' Read live status + request count to decide the delete rule
        Dim liveStatus As String = ""
        Dim reqCount As Integer = 0
        Try
            Using conn0 As MySqlConnection = dbConnection.GetConnection()
                conn0.Open()
                Using cmdS As New MySqlCommand("SELECT Status FROM tblstudents WHERE StudentID=@id", conn0)
                    cmdS.Parameters.AddWithValue("@id", originalStudentID)
                    Dim vS As Object = cmdS.ExecuteScalar()
                    If vS Is Nothing OrElse vS Is DBNull.Value Then
                        MessageBox.Show("Selected student no longer exists. Refreshing list.", "Not found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        LoadStudents()
                        ClearForm()
                        Return
                    End If
                    liveStatus = vS.ToString()
                End Using
                Using cmdC As New MySqlCommand("SELECT COUNT(*) FROM tblrequest WHERE StudentID=@id", conn0)
                    cmdC.Parameters.AddWithValue("@id", originalStudentID)
                    reqCount = Convert.ToInt32(cmdC.ExecuteScalar())
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Could not read student record: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        If liveStatus = "Inactive" Then
            ' Inactive students can be permanently deleted (cascade to their requests) with confirmation
            Dim msg As String = "Permanently DELETE inactive student " & originalStudentID & "?"
            If reqCount > 0 Then msg &= vbCrLf & vbCrLf & "This will also delete their " & reqCount & " request(s) and all details."
            msg &= vbCrLf & vbCrLf & "This cannot be undone."
            If MessageBox.Show(msg, "Confirm Permanent Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) <> DialogResult.Yes Then Return
            Try
                Using conn As MySqlConnection = dbConnection.GetConnection()
                    conn.Open()
                    Using tran As MySqlTransaction = conn.BeginTransaction()
                        Try
                            Using cmdD As New MySqlCommand("DELETE FROM tblrequestdetails WHERE RequestID IN (SELECT RequestID FROM tblrequest WHERE StudentID=@id)", conn, tran)
                                cmdD.Parameters.AddWithValue("@id", originalStudentID)
                                cmdD.ExecuteNonQuery()
                            End Using
                            Using cmdR As New MySqlCommand("DELETE FROM tblrequest WHERE StudentID=@id", conn, tran)
                                cmdR.Parameters.AddWithValue("@id", originalStudentID)
                                cmdR.ExecuteNonQuery()
                            End Using
                            Using cmdS As New MySqlCommand("DELETE FROM tblstudents WHERE StudentID=@id", conn, tran)
                                cmdS.Parameters.AddWithValue("@id", originalStudentID)
                                cmdS.ExecuteNonQuery()
                            End Using
                            tran.Commit()
                        Catch exTran As Exception
                            tran.Rollback()
                            Throw
                        End Try
                    End Using
                End Using
                ' Mirror cascade to registrar_db (never blocks the main result)
                Try
                    Using connR As MySqlConnection = dbConnection.GetRegistrarConnection()
                        connR.Open()
                        Using cmdD As New MySqlCommand("DELETE FROM tblrequestdetails WHERE RequestID IN (SELECT RequestID FROM tblrequest WHERE StudentID=@id)", connR)
                            cmdD.Parameters.AddWithValue("@id", originalStudentID)
                            cmdD.ExecuteNonQuery()
                        End Using
                        Using cmdR As New MySqlCommand("DELETE FROM tblrequest WHERE StudentID=@id", connR)
                            cmdR.Parameters.AddWithValue("@id", originalStudentID)
                            cmdR.ExecuteNonQuery()
                        End Using
                        Using cmdS As New MySqlCommand("DELETE FROM tblstudents WHERE StudentID=@id", connR)
                            cmdS.Parameters.AddWithValue("@id", originalStudentID)
                            cmdS.ExecuteNonQuery()
                        End Using
                    End Using
                Catch ex2 As Exception
                    Debug.WriteLine("Registrar sync cascade delete failed: " & ex2.Message)
                End Try
                MessageBox.Show("Inactive student and " & reqCount & " request(s) permanently deleted.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtSearch.Clear()
                cboSearchField.SelectedIndex = 0
                LoadStudents()
                ClearForm()
            Catch ex As Exception
                MessageBox.Show("Delete failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            Return
        End If
        Dim choice As DialogResult = MessageBox.Show("Are you sure you want to delete/deactivate this student?", "Confirm", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
        Try
            Using conn As MySqlConnection = dbConnection.GetConnection()
                conn.Open()
                If choice = DialogResult.Yes Then
                    Using cmd As New MySqlCommand("DELETE FROM tblstudents WHERE StudentID=@id", conn)
                        cmd.Parameters.AddWithValue("@id", originalStudentID)
                        cmd.ExecuteNonQuery()
                        MessageBox.Show("Student deleted.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End Using
                    Try
                        Using connR As MySqlConnection = dbConnection.GetRegistrarConnection()
                            connR.Open()
                            Using cmdR As New MySqlCommand("DELETE FROM tblstudents WHERE StudentID=@id", connR)
                                cmdR.Parameters.AddWithValue("@id", originalStudentID)
                                cmdR.ExecuteNonQuery()
                            End Using
                        End Using
                    Catch ex2 As Exception
                        Debug.WriteLine("Registrar sync delete failed: " & ex2.Message)
                    End Try
                ElseIf choice = DialogResult.No Then
                    Using cmd As New MySqlCommand("UPDATE tblstudents SET Status='Inactive' WHERE StudentID=@id", conn)
                        cmd.Parameters.AddWithValue("@id", originalStudentID)
                        cmd.ExecuteNonQuery()
                    End Using
                    ' Propagate Inactive to this student's requests (remember prior status for restore)
                    Dim affectedReqs As Integer = 0
                    Using cmdP As New MySqlCommand("UPDATE tblrequest SET PrevStatus=Status, Status='Inactive' WHERE StudentID=@id AND Status<>'Inactive'", conn)
                        cmdP.Parameters.AddWithValue("@id", originalStudentID)
                        affectedReqs = cmdP.ExecuteNonQuery()
                    End Using
                    MessageBox.Show("Student deactivated (Inactive)." & If(affectedReqs > 0, vbCrLf & affectedReqs & " request(s) also marked Inactive.", ""), "Deactivated", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Try
                        Using connR As MySqlConnection = dbConnection.GetRegistrarConnection()
                            connR.Open()
                            Using cmdR As New MySqlCommand("UPDATE tblstudents SET Status='Inactive' WHERE StudentID=@id", connR)
                                cmdR.Parameters.AddWithValue("@id", originalStudentID)
                                cmdR.ExecuteNonQuery()
                            End Using
                            Using cmdPR As New MySqlCommand("UPDATE tblrequest SET PrevStatus=Status, Status='Inactive' WHERE StudentID=@id AND Status<>'Inactive'", connR)
                                cmdPR.Parameters.AddWithValue("@id", originalStudentID)
                                cmdPR.ExecuteNonQuery()
                            End Using
                        End Using
                    Catch ex2 As Exception
                        Debug.WriteLine("Registrar sync deactivate failed: " & ex2.Message)
                    End Try
                Else
                    Return
                End If
            End Using
            txtSearch.Clear()
            cboSearchField.SelectedIndex = 0
            LoadStudents()
            ClearForm()
        Catch ex As MySqlException
            If ex.Number = 1451 Then
                MessageBox.Show("Cannot delete: student has existing requests. Use Deactivate instead.", "Foreign key", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearForm()
    End Sub

    Private Sub ClearForm()
        txtStudentID.Clear()
        txtLRN.Clear()
        txtLastName.Clear()
        txtFirstName.Clear()
        txtMiddleName.Clear()
        txtSection.Clear()
        txtContact.Clear()
        cboCourse.SelectedIndex = -1
        cboYearLevel.SelectedIndex = -1
        cboStatus.SelectedIndex = 0
        txtStudentID.ReadOnly = False
        isEditing = False
        originalStudentID = ""
        btnAdd.Text = "Add"
        btnDelete.Enabled = False
        txtStudentID.Focus()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        LoadStudents(txtSearch.Text.Trim(), cboSearchField.Text)
    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        txtSearch.Clear()
        cboSearchField.SelectedIndex = 0
        LoadStudents()
        ClearForm()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class
