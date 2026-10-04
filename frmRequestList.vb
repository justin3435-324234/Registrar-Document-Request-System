Imports MySql.Data.MySqlClient

Public Class frmRequestList

    Private Sub frmRequestList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboSearchField.Items.AddRange(New String() {"All", "RequestNo", "StudentID", "First Name", "Last Name", "Middle Name", "OR Number"})
        cboSearchField.SelectedIndex = 0
        cboStatusFilter.Items.AddRange(New String() {"All", "Pending", "Processing", "Ready for Release", "Released", "Cancelled", "Inactive", "Overdue"})
        cboStatusFilter.SelectedIndex = 0
        dtpFrom.Value = DateTime.Today.AddMonths(-2)
        dtpTo.Value = DateTime.Today
        LoadRequests()
    End Sub

    Private Sub LoadRequests()
        Try
            Dim search As String = txtSearch.Text.Trim()
            Dim field As String = cboSearchField.Text
            Dim statusFilter As String = cboStatusFilter.Text
            Dim useDate As Boolean = chkDateFilter.Checked
            Dim fromDate As Date = dtpFrom.Value.Date
            Dim toDate As Date = dtpTo.Value.Date

            Using conn As MySqlConnection = dbConnection.GetConnection()
                conn.Open()
                Dim sql As String = "SELECT r.RequestID, r.RequestNo, r.RequestDate, r.StudentID, CONCAT(s.LastName, ', ', s.FirstName) AS StudentName, r.TotalAmount, r.PaymentStatus, r.ORNo, r.Status, CASE WHEN COALESCE(u.FullName,'')='' THEN '' ELSE CONCAT(u.FullName, ' (', u.Role, ')') END AS ProcessedBy, CASE WHEN COALESCE(uRel.FullName,'')='' THEN '' ELSE CONCAT(uRel.FullName, ' (', uRel.Role, ')') END AS ReleasedBy, CASE WHEN COALESCE(uCan.FullName,'')='' THEN '' ELSE CONCAT(uCan.FullName, ' (', uCan.Role, ')') END AS CancelledBy FROM tblrequest r JOIN tblstudents s ON r.StudentID=s.StudentID LEFT JOIN tblusers u ON r.CreatedBy=u.UserID LEFT JOIN tblusers uRel ON r.ReleasedBy=uRel.UserID LEFT JOIN tblusers uCan ON r.CancelledBy=uCan.UserID WHERE 1=1"
                Dim cmd As New MySqlCommand()
                cmd.Connection = conn

                If Not String.IsNullOrWhiteSpace(search) Then
                    If field = "All" Then
                        sql &= " AND (r.RequestNo LIKE @s OR r.StudentID LIKE @s OR s.LastName LIKE @s OR s.FirstName LIKE @s OR s.MiddleName LIKE @s OR r.ORNo LIKE @s)"
                        cmd.Parameters.AddWithValue("@s", "%" & search & "%")
                    ElseIf field = "RequestNo" Then
                        sql &= " AND r.RequestNo LIKE @s"
                        cmd.Parameters.AddWithValue("@s", "%" & search & "%")
                    ElseIf field = "StudentID" Then
                        sql &= " AND r.StudentID LIKE @s"
                        cmd.Parameters.AddWithValue("@s", "%" & search & "%")
                    ElseIf field = "First Name" Then
                        sql &= " AND s.FirstName LIKE @s"
                        cmd.Parameters.AddWithValue("@s", "%" & search & "%")
                    ElseIf field = "Last Name" Then
                        sql &= " AND s.LastName LIKE @s"
                        cmd.Parameters.AddWithValue("@s", "%" & search & "%")
                    ElseIf field = "Middle Name" Then
                        sql &= " AND s.MiddleName LIKE @s"
                        cmd.Parameters.AddWithValue("@s", "%" & search & "%")
                    ElseIf field = "OR Number" Then
                        sql &= " AND r.ORNo LIKE @s"
                        cmd.Parameters.AddWithValue("@s", "%" & search & "%")
                    End If
                End If

                If statusFilter <> "All" Then
                    If statusFilter = "Overdue" Then
                        sql &= " AND r.RequestDate < @over AND r.Status IN ('Pending','Processing')"
                        cmd.Parameters.AddWithValue("@over", DateTime.Today.AddDays(-7))
                    Else
                        sql &= " AND r.Status=@status"
                        cmd.Parameters.AddWithValue("@status", statusFilter)
                    End If
                End If

                If useDate Then
                    sql &= " AND r.RequestDate BETWEEN @from AND @to"
                    cmd.Parameters.AddWithValue("@from", fromDate)
                    cmd.Parameters.AddWithValue("@to", toDate)
                End If

                sql &= " ORDER BY r.RequestDate ASC, r.RequestNo ASC"
                cmd.CommandText = sql

                Dim dt As New DataTable()
                Using da As New MySqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
                dgvRequests.DataSource = dt
                FormatGrid()
                ApplyOverdueColors()
                lblCount.Text = dt.Rows.Count & " request(s)"
            End Using
        Catch ex As Exception
            MessageBox.Show("Failed to load requests: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FormatGrid()
        If dgvRequests.Columns.Count = 0 Then Return
        ' Enforce same records as Reports/Details automatically on open (headers stay 11pt in Designer)
        dgvRequests.DefaultCellStyle.Font = New Font("Segoe UI", 12.0!)
        dgvRequests.RowTemplate.Height = 40
        dgvRequests.AllowUserToResizeColumns = True
        dgvRequests.AllowUserToOrderColumns = False
        dgvRequests.ScrollBars = ScrollBars.Both
        dgvRequests.Columns("RequestID").Visible = False
        dgvRequests.Columns("RequestNo").HeaderText = "Request No"
        dgvRequests.Columns("RequestDate").HeaderText = "Date"
        dgvRequests.Columns("RequestDate").DefaultCellStyle.Format = "MM/dd/yyyy"
        dgvRequests.Columns("StudentID").HeaderText = "Student ID"
        dgvRequests.Columns("StudentName").HeaderText = "Student Name"
        dgvRequests.Columns("TotalAmount").HeaderText = "Total (₱)"
        dgvRequests.Columns("TotalAmount").DefaultCellStyle.Format = "N2"
        dgvRequests.Columns("TotalAmount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvRequests.Columns("PaymentStatus").HeaderText = "Payment"
        dgvRequests.Columns("Status").HeaderText = "Status"
        dgvRequests.Columns("ProcessedBy").HeaderText = "Processed By"
        dgvRequests.Columns("ORNo").HeaderText = "OR No"
        dgvRequests.Columns("ReleasedBy").HeaderText = "Released By"
        dgvRequests.Columns("CancelledBy").HeaderText = "Cancelled By"
        If dgvRequests.Columns.Contains("Remarks") = False Then dgvRequests.Columns.Add("Remarks", "Remarks")
        ' Automatic widths on open: fit header + cell content for current font, keep scrollbar + user resize
        dgvRequests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        SetAutoWidth("RequestNo", 110)
        SetAutoWidth("RequestDate", 85)
        SetAutoWidth("StudentID", 85)
        SetAutoWidth("StudentName", 150)
        SetAutoWidth("TotalAmount", 80)
        SetAutoWidth("PaymentStatus", 75)
        SetAutoWidth("ORNo", 80)
        SetAutoWidth("Status", 100)
        SetAutoWidth("ProcessedBy", 180)
        SetAutoWidth("ReleasedBy", 180)
        SetAutoWidth("CancelledBy", 180)
        SetAutoWidth("Remarks", 100)
        Try
            dgvRequests.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells)
        Catch
        End Try
    End Sub

    Private Sub SetAutoWidth(colName As String, minWidth As Integer)
        If dgvRequests.Columns.Contains(colName) Then
            dgvRequests.Columns(colName).MinimumWidth = minWidth
            dgvRequests.Columns(colName).Width = minWidth
        End If
    End Sub

    Private Sub ApplyOverdueColors()
        Try
            Dim baseFont As Font = dgvRequests.DefaultCellStyle.Font
            If baseFont Is Nothing Then baseFont = dgvRequests.Font
            For Each row As DataGridViewRow In dgvRequests.Rows
                If row.IsNewRow Then Continue For
                Dim overdue As Boolean = False
                Try
                    Dim d As Date = Convert.ToDateTime(row.Cells("RequestDate").Value)
                    Dim s As String = row.Cells("Status").Value.ToString()
                    overdue = AuditHelper.IsOverdue(d, s)
                Catch
                End Try
                If dgvRequests.Columns.Contains("Remarks") Then row.Cells("Remarks").Value = If(overdue, "OVERDUE", "")
                If overdue Then
                    row.DefaultCellStyle.BackColor = Color.FromArgb(254, 226, 226)
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(153, 27, 27)
                    row.DefaultCellStyle.Font = New Font(baseFont, FontStyle.Bold)
                Else
                    row.DefaultCellStyle.BackColor = Color.White
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59)
                    row.DefaultCellStyle.Font = New Font(baseFont, FontStyle.Regular)
                End If
            Next
        Catch
        End Try
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        LoadRequests()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        txtSearch.Clear()
        cboSearchField.SelectedIndex = 0
        cboStatusFilter.SelectedIndex = 0
        chkDateFilter.Checked = False
        LoadRequests()
    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then LoadRequests() : e.SuppressKeyPress = True
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        OpenSelected()
    End Sub

    Private Sub dgvRequests_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRequests.CellDoubleClick
        If e.RowIndex >= 0 Then OpenSelected()
    End Sub

    Private Sub OpenSelected()
        If dgvRequests.SelectedRows.Count = 0 AndAlso dgvRequests.CurrentRow Is Nothing Then
            MessageBox.Show("Select a request to view.", "No selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim row As DataGridViewRow = If(dgvRequests.SelectedRows.Count > 0, dgvRequests.SelectedRows(0), dgvRequests.CurrentRow)
        Dim reqID As Integer = Convert.ToInt32(row.Cells("RequestID").Value)
        Dim f As New frmRequestDetails(reqID)
        f.ShowDialog()
        LoadRequests()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub chkDateFilter_CheckedChanged(sender As Object, e As EventArgs) Handles chkDateFilter.CheckedChanged
        dtpFrom.Enabled = chkDateFilter.Checked
        dtpTo.Enabled = chkDateFilter.Checked
    End Sub
End Class
