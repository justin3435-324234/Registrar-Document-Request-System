Imports MySql.Data.MySqlClient

Public Class frmRequestDetails
    Private reqID As Integer
    Private originalStudentID As String = ""
    Private originalStatus As String = ""
    Private originalPayment As String = ""
    Private originalORNo As String = ""
    Private originalRequestDate As Date = DateTime.Today
    Private isEditUnlocked As Boolean = False

    Public Sub New(requestID As Integer)
        InitializeComponent()
        Me.reqID = requestID
    End Sub

    Private Sub frmRequestDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtORNo.MaxLength = 6
        LoadDetails()
    End Sub

    Private Sub LockEditing()
        isEditUnlocked = False
        txtStudentIDEdit.Enabled = False
        btnSearchStudent.Enabled = False
        cboStatus.Enabled = False
        cboPayment.Enabled = False
        txtORNo.Enabled = False
        chkORDate.Enabled = False
        dtpORDate.Enabled = False
        btnSave.Enabled = False
        btnEdit.Enabled = True
        btnEdit.Text = "EDIT"
        btnEdit.ForeColor = Color.White
        btnEdit.BackColor = Color.FromArgb(15, 23, 42)
    End Sub

    Private Sub UnlockEditing()
        isEditUnlocked = True
        ' Student search stays locked - request ownership can never change
        txtStudentIDEdit.Enabled = False
        btnSearchStudent.Enabled = False
        cboStatus.Enabled = True
        cboPayment.Enabled = True
        btnSave.Enabled = True
        ' Keep EDIT enabled so text stays white (disabled buttons gray out text)
        btnEdit.Enabled = True
        btnEdit.Text = "EDITING..."
        btnEdit.ForeColor = Color.White
        btnEdit.BackColor = Color.FromArgb(15, 23, 42)
        ApplyPaymentUI()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If isEditUnlocked Then
            MessageBox.Show("Already in edit mode. Press SAVE to confirm changes.", "Edit Mode", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Using f As New frmPasswordConfirm()
            If f.ShowDialog() = DialogResult.OK AndAlso f.Confirmed Then
                UnlockEditing()
                AuditHelper.LogAudit(lblRequestNo.Text, "Edit Unlocked", originalStatus, cboStatus.Text, "Editing enabled by administrator password")
                MessageBox.Show("Editing enabled. Press SAVE to confirm changes.", "Edit Mode", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End Using
    End Sub

    Private Sub LoadDetails()
        Try
            Using conn As MySqlConnection = dbConnection.GetConnection()
                conn.Open()
                Dim sql As String = "SELECT r.RequestNo, r.RequestDate, r.StudentID, CONCAT(s.LastName, ', ', s.FirstName, ' ', s.MiddleName) AS StudentName, s.Course, s.YearLevel, s.Section, r.TotalAmount, r.PaymentStatus, r.ORNo, r.ORDate, r.Status, COALESCE(u.FullName,'') AS ProcessedBy FROM tblrequest r JOIN tblstudents s ON r.StudentID=s.StudentID LEFT JOIN tblusers u ON r.CreatedBy=u.UserID WHERE r.RequestID=@id"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@id", reqID)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            lblRequestNo.Text = reader("RequestNo").ToString()
                            lblRequestDate.Text = Convert.ToDateTime(reader("RequestDate")).ToString("MM/dd/yyyy")
                            lblStudentID.Text = reader("StudentID").ToString()
                            originalStudentID = reader("StudentID").ToString()
                            txtStudentIDEdit.Text = originalStudentID
                            lblStudentName.Text = reader("StudentName").ToString()
                            lblCourse.Text = reader("Course").ToString() & " - " & reader("YearLevel").ToString() & " " & reader("Section").ToString()
                            lblTotal.Text = "₱ " & Convert.ToDecimal(reader("TotalAmount")).ToString("N2")
                            originalPayment = reader("PaymentStatus").ToString()
                            originalStatus = reader("Status").ToString()
                            originalRequestDate = Convert.ToDateTime(reader("RequestDate"))
                            txtORNo.Text = If(reader("ORNo") Is DBNull.Value, "", reader("ORNo").ToString())
                            originalORNo = txtORNo.Text
                            If reader("ORDate") Is DBNull.Value Then
                                chkORDate.Checked = False
                            Else
                                chkORDate.Checked = True
                                dtpORDate.Value = Convert.ToDateTime(reader("ORDate"))
                            End If
                            lblProcessedBy.Text = reader("ProcessedBy").ToString()
                        End If
                    End Using
                End Using

                ' Load document details
                Dim sqlDet As String = "SELECT d.DocumentName, rd.Quantity, rd.Amount, rd.SubTotal FROM tblrequestdetails rd JOIN tbldocuments d ON rd.DocumentID=d.DocumentID WHERE rd.RequestID=@id"
                Using cmd As New MySqlCommand(sqlDet, conn)
                    cmd.Parameters.AddWithValue("@id", reqID)
                    Dim dt As New DataTable()
                    Using da As New MySqlDataAdapter(cmd)
                        da.Fill(dt)
                    End Using
                    dgvDetails.DataSource = dt
                    If dt.Rows.Count > 0 Then
                        dgvDetails.Columns("DocumentName").HeaderText = "Document"
                        dgvDetails.Columns("Quantity").HeaderText = "Qty"
                        dgvDetails.Columns("Amount").HeaderText = "Fee (₱)"
                        dgvDetails.Columns("Amount").DefaultCellStyle.Format = "N2"
                        dgvDetails.Columns("SubTotal").HeaderText = "SubTotal (₱)"
                        dgvDetails.Columns("SubTotal").DefaultCellStyle.Format = "N2"
                        dgvDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Failed to load details: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        cboPayment.Items.Clear()
        If originalPayment = "Paid" Then
            cboPayment.Items.Add("Paid")
        Else
            cboPayment.Items.AddRange(New String() {"Unpaid", "Paid"})
        End If
        cboPayment.Text = originalPayment
        RefreshStatusOptions()
        If cboPayment.Text = "Paid" AndAlso Not (originalStatus = "Released" OrElse originalStatus = "Cancelled" OrElse originalStatus = "Inactive") Then
            cboStatus.Text = "Ready for Release"
        Else
            cboStatus.Text = originalStatus
        End If
        lblOverdue.Visible = AuditHelper.IsOverdue(originalRequestDate, originalStatus)
        UpdatePaidState(originalStudentID)
        ApplyPaymentUI()
        LockEditing()
    End Sub

    Private Sub RefreshStatusOptions()
        cboStatus.Items.Clear()
        If cboPayment.Text = "Paid" Then
            If originalStatus = "Released" OrElse originalStatus = "Cancelled" OrElse originalStatus = "Inactive" Then
                cboStatus.Items.AddRange(AuditHelper.AllowedNextStatuses(originalStatus).ToArray())
            Else
                cboStatus.Items.AddRange(New String() {"Ready for Release", "Released"})
            End If
        Else
            cboStatus.Items.AddRange(AuditHelper.AllowedNextStatuses(originalStatus).ToArray())
        End If
        If cboStatus.Items.Count > 0 AndAlso String.IsNullOrWhiteSpace(cboStatus.Text) Then
            cboStatus.SelectedIndex = 0
        End If
    End Sub

    Private Sub UpdatePaidState(sid As String)
        Dim txt As String = StudentSearch.PaidStateText(sid)
        lblPaidState.Text = txt
        If txt = "NO REQUESTS" Then
            lblPaidState.ForeColor = Color.Gray
        ElseIf txt.Contains("/") Then
            lblPaidState.ForeColor = Color.FromArgb(217, 119, 6)
        ElseIf txt.StartsWith("PAID") Then
            lblPaidState.ForeColor = Color.FromArgb(22, 163, 74)
        Else
            lblPaidState.ForeColor = Color.FromArgb(220, 38, 38)
        End If
    End Sub

    Private Sub btnSearchStudent_Click(sender As Object, e As EventArgs) Handles btnSearchStudent.Click
        Dim keyword As String = txtStudentIDEdit.Text.Trim()
        If String.IsNullOrWhiteSpace(keyword) Then
            MessageBox.Show("Enter Student ID, LRN, First Name or Last Name.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtStudentIDEdit.Focus()
            Return
        End If
        Try
            Dim matches As DataTable = StudentSearch.FindStudents(keyword)
            If matches.Rows.Count = 0 Then
                MessageBox.Show("No student found.", "Not found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtStudentIDEdit.Focus()
                Return
            End If
            Dim sid As String = StudentSearch.PickStudent(matches)
            If String.IsNullOrWhiteSpace(sid) Then Return
            Dim row As DataRow = matches.Select("StudentID='" & sid.Replace("'", "''") & "'")(0)
            txtStudentIDEdit.Text = sid
            lblStudentID.Text = row("StudentID").ToString()
            lblStudentName.Text = row("LastName").ToString() & ", " & row("FirstName").ToString() & " " & row("MiddleName").ToString()
            lblCourse.Text = row("Course").ToString() & " - " & row("YearLevel").ToString() & " " & row("Section").ToString()
            UpdatePaidState(sid)
        Catch ex As Exception
            MessageBox.Show("Search failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Not isEditUnlocked Then
            MessageBox.Show("Press EDIT and enter administrator password first.", "Edit Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If MessageBox.Show("Do you want to save?", "Confirm Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return

        Dim newStatus As String = cboStatus.Text
        Dim newPayment As String = cboPayment.Text
        ' Paid is one-way - it cannot return to Unpaid
        If originalPayment = "Paid" AndAlso newPayment <> "Paid" Then
            MessageBox.Show("Payment cannot return to Unpaid once marked Paid.", "Invalid Payment", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboPayment.Text = "Paid"
            Return
        End If
        ' Student can never change on a saved request - search stays locked
        Dim newStudentID As String = originalStudentID
        Dim orNo As String = txtORNo.Text.Trim()
        Dim orDate As Object = DBNull.Value
        If chkORDate.Checked Then orDate = dtpORDate.Value.Date

        If String.IsNullOrWhiteSpace(newStudentID) Then
            MessageBox.Show("Student record missing.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        If newPayment = "Paid" Then
            If String.IsNullOrWhiteSpace(orNo) Then
                MessageBox.Show("OR Number is required when Payment Status is Paid.", "OR Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtORNo.Focus()
                Return
            End If
            If orNo.Length <> 6 Then
                MessageBox.Show("OR Number must be exactly 6 characters (e.g. OR-001).", "OR Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtORNo.Focus()
                txtORNo.SelectAll()
                Return
            End If
            If Not chkORDate.Checked Then
                MessageBox.Show("OR Date is required when Payment Status is Paid.", "OR Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                chkORDate.Focus()
                Return
            End If
        Else
            If Not String.IsNullOrWhiteSpace(orNo) OrElse chkORDate.Checked Then
                MessageBox.Show("Unpaid requests must have no OR Number / OR Date. Clear OR or switch to Paid.", "OR Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtORNo.Focus()
                Return
            End If
            orNo = ""
            orDate = DBNull.Value
        End If

        ' Forward-only workflow: status cannot return to a previous stage
        ' Exception: Paid requests can jump to Ready for Release or Released
        Dim paidJump As Boolean = (newPayment = "Paid" AndAlso (newStatus = "Ready for Release" OrElse newStatus = "Released") AndAlso (originalStatus = "Pending" OrElse originalStatus = "Processing" OrElse originalStatus = "Ready for Release"))
        If Not paidJump AndAlso Not AuditHelper.CanMoveStatus(originalStatus, newStatus) Then
            MessageBox.Show("Status cannot return to previous stage. Current: " & originalStatus & ".", "Invalid Status", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboStatus.Text = originalStatus
            Return
        End If

        ' Validate new Student ID exists and is Active (allows changing owner of request)
        Try
            Using conn As MySqlConnection = dbConnection.GetConnection()
                conn.Open()
                Using chk As New MySqlCommand("SELECT Status FROM tblstudents WHERE StudentID=@id", conn)
                    chk.Parameters.AddWithValue("@id", newStudentID)
                    Dim st As Object = chk.ExecuteScalar()
                    If st Is Nothing Then
                        MessageBox.Show("Student ID not found.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtStudentIDEdit.Focus()
                        Return
                    ElseIf st.ToString() <> "Active" Then
                        MessageBox.Show("Student is Inactive.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        txtStudentIDEdit.Focus()
                        Return
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Student validation failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

        Try
            Using conn As MySqlConnection = dbConnection.GetConnection()
                conn.Open()
                Dim lastAction As String = "Updated"
                If originalStatus <> newStatus Then lastAction = newStatus
                If originalPayment <> newPayment Then lastAction = If(newPayment = "Paid", "Paid", "Payment Changed")
                Dim sql As String = "UPDATE tblrequest SET StudentID=@sid, Status=@status, PaymentStatus=@pay, ORNo=@orNo, ORDate=@orDate, LastAction=@act, LastActionBy=@by, LastActionDate=NOW(), UpdatedBy=@by WHERE RequestID=@id"
                If newStatus = "Released" AndAlso originalStatus <> "Released" Then sql = "UPDATE tblrequest SET StudentID=@sid, Status=@status, PaymentStatus=@pay, ORNo=@orNo, ORDate=@orDate, LastAction=@act, LastActionBy=@by, LastActionDate=NOW(), UpdatedBy=@by, ReleasedBy=@by, ReleasedDate=NOW() WHERE RequestID=@id"
                If newStatus = "Cancelled" AndAlso originalStatus <> "Cancelled" Then sql = "UPDATE tblrequest SET StudentID=@sid, Status=@status, PaymentStatus=@pay, ORNo=@orNo, ORDate=@orDate, LastAction=@act, LastActionBy=@by, LastActionDate=NOW(), UpdatedBy=@by, CancelledBy=@by, CancelledDate=NOW() WHERE RequestID=@id"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@sid", newStudentID)
                    cmd.Parameters.AddWithValue("@status", newStatus)
                    cmd.Parameters.AddWithValue("@pay", newPayment)
                    cmd.Parameters.AddWithValue("@orNo", If(String.IsNullOrWhiteSpace(orNo), DBNull.Value, CType(orNo, Object)))
                    cmd.Parameters.AddWithValue("@orDate", orDate)
                    cmd.Parameters.AddWithValue("@act", lastAction)
                    cmd.Parameters.AddWithValue("@by", Session.CurrentUserID)
                    cmd.Parameters.AddWithValue("@id", reqID)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            ' Mirror to registrar_db
            Try
                Using conn As MySqlConnection = dbConnection.GetRegistrarConnection()
                    conn.Open()
                    Dim lastAction As String = "Updated"
                    If originalStatus <> newStatus Then lastAction = newStatus
                    If originalPayment <> newPayment Then lastAction = If(newPayment = "Paid", "Paid", "Payment Changed")
                    Dim sql As String = "UPDATE tblrequest SET StudentID=@sid, Status=@status, PaymentStatus=@pay, ORNo=@orNo, ORDate=@orDate, LastAction=@act, LastActionBy=@by, LastActionDate=NOW(), UpdatedBy=@by WHERE RequestNo=@no"
                    If newStatus = "Released" AndAlso originalStatus <> "Released" Then sql = "UPDATE tblrequest SET StudentID=@sid, Status=@status, PaymentStatus=@pay, ORNo=@orNo, ORDate=@orDate, LastAction=@act, LastActionBy=@by, LastActionDate=NOW(), UpdatedBy=@by, ReleasedBy=@by, ReleasedDate=NOW() WHERE RequestNo=@no"
                    If newStatus = "Cancelled" AndAlso originalStatus <> "Cancelled" Then sql = "UPDATE tblrequest SET StudentID=@sid, Status=@status, PaymentStatus=@pay, ORNo=@orNo, ORDate=@orDate, LastAction=@act, LastActionBy=@by, LastActionDate=NOW(), UpdatedBy=@by, CancelledBy=@by, CancelledDate=NOW() WHERE RequestNo=@no"
                    Using cmd As New MySqlCommand(sql, conn)
                        cmd.Parameters.AddWithValue("@sid", newStudentID)
                        cmd.Parameters.AddWithValue("@status", newStatus)
                        cmd.Parameters.AddWithValue("@pay", newPayment)
                        cmd.Parameters.AddWithValue("@orNo", If(String.IsNullOrWhiteSpace(orNo), DBNull.Value, CType(orNo, Object)))
                        cmd.Parameters.AddWithValue("@orDate", orDate)
                        cmd.Parameters.AddWithValue("@act", lastAction)
                        cmd.Parameters.AddWithValue("@by", Session.CurrentUserID)
                        cmd.Parameters.AddWithValue("@no", lblRequestNo.Text)
                        cmd.ExecuteNonQuery()
                    End Using
                End Using
            Catch ex2 As Exception
                Debug.WriteLine("Registrar sync details failed: " & ex2.Message)
            End Try

            If originalStatus <> newStatus Then AuditHelper.LogAudit(lblRequestNo.Text, "Status Changed", originalStatus, newStatus, "Updated by " & Session.CurrentFullName)
            If originalPayment <> newPayment OrElse originalORNo <> orNo Then AuditHelper.LogAudit(lblRequestNo.Text, "Payment Changed", originalPayment & "/" & originalORNo, newPayment & "/" & orNo, "Updated by " & Session.CurrentFullName)
            If originalStudentID <> newStudentID Then AuditHelper.LogAudit(lblRequestNo.Text, "Updated", originalStudentID, newStudentID, "Student reassigned")

            MessageBox.Show("Request updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ' Stay open - refresh saved state so further edits continue from the new values
            originalStatus = newStatus
            originalPayment = newPayment
            originalORNo = orNo
            RefreshStatusOptions()
            cboStatus.Text = originalStatus
            cboPayment.Items.Clear()
            If originalPayment = "Paid" Then
                cboPayment.Items.Add("Paid")
            Else
                cboPayment.Items.AddRange(New String() {"Unpaid", "Paid"})
            End If
            cboPayment.Text = originalPayment
            lblOverdue.Visible = AuditHelper.IsOverdue(originalRequestDate, originalStatus)
            UpdatePaidState(originalStudentID)
            ApplyPaymentUI()
        Catch ex As Exception
            MessageBox.Show("Update failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub chkORDate_CheckedChanged(sender As Object, e As EventArgs) Handles chkORDate.CheckedChanged
        dtpORDate.Enabled = chkORDate.Checked AndAlso txtORNo.Enabled
    End Sub

    Private Sub cboPayment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboPayment.SelectedIndexChanged
        Dim wasPaid As Boolean = txtORNo.Enabled
        Dim isPaid As Boolean = (cboPayment.Text = "Paid")
        ' Auto-clear OR when switching Paid -> Unpaid to keep DB clean
        If wasPaid AndAlso Not isPaid Then
            txtORNo.Clear()
            chkORDate.Checked = False
        End If
        If isEditUnlocked Then
            RefreshStatusOptions()
            If isPaid Then
                cboStatus.Text = "Ready for Release"
            Else
                If cboStatus.Items.Count > 0 AndAlso Not cboStatus.Items.Contains(cboStatus.Text) Then
                    cboStatus.Text = originalStatus
                End If
            End If
        End If
        ApplyPaymentUI()
        If isPaid Then txtORNo.Focus()
    End Sub

    Private Sub ApplyPaymentUI()
        Dim isPaid As Boolean = (cboPayment.Text = "Paid")
        txtORNo.Enabled = isPaid
        chkORDate.Enabled = isPaid
        dtpORDate.Enabled = isPaid AndAlso chkORDate.Checked
        If isPaid Then
            lblORNo.ForeColor = Color.Red
            lblORNo.Text = "OR NUMBER *"
            lblORDate.ForeColor = Color.Red
            lblORDate.Text = "OR DATE *"
            txtORNo.BackColor = Color.LightYellow
        Else
            lblORNo.ForeColor = Color.FromArgb(71, 85, 105)
            lblORNo.Text = "OR NUMBER"
            lblORDate.ForeColor = Color.FromArgb(71, 85, 105)
            lblORDate.Text = "OR DATE"
            txtORNo.BackColor = Color.WhiteSmoke
            dtpORDate.Enabled = False
        End If
    End Sub

    Private Sub pnlInfo_Paint(sender As Object, e As PaintEventArgs) Handles pnlInfo.Paint

    End Sub
End Class
