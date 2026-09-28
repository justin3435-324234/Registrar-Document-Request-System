Imports MySql.Data.MySqlClient

Public Class frmRequestList

    Private Sub frmRequestList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboSearchField.Items.AddRange(New String() {"All", "RequestNo", "StudentID"})
        cboSearchField.SelectedIndex = 0
        cboStatusFilter.Items.AddRange(New String() {"All", "Pending", "Processing", "Ready for Release", "Released", "Cancelled", "Inactive"})
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
                Dim sql As String = "SELECT r.RequestID, r.RequestNo, r.RequestDate, r.StudentID, CONCAT(s.LastName, ', ', s.FirstName) AS StudentName, r.TotalAmount, r.PaymentStatus, r.Status, COALESCE(u.FullName,'') AS ProcessedBy FROM tblrequest r JOIN tblstudents s ON r.StudentID=s.StudentID LEFT JOIN tblusers u ON r.CreatedBy=u.UserID WHERE 1=1"
                Dim cmd As New MySqlCommand()
                cmd.Connection = conn

                If Not String.IsNullOrWhiteSpace(search) Then
                    If field = "All" Then
                        sql &= " AND (r.RequestNo LIKE @s OR r.StudentID LIKE @s OR s.LastName LIKE @s OR s.FirstName LIKE @s)"
                        cmd.Parameters.AddWithValue("@s", "%" & search & "%")
                    ElseIf field = "RequestNo" Then
                        sql &= " AND r.RequestNo LIKE @s"
                        cmd.Parameters.AddWithValue("@s", "%" & search & "%")
                    ElseIf field = "StudentID" Then
                        sql &= " AND r.StudentID LIKE @s"
                        cmd.Parameters.AddWithValue("@s", "%" & search & "%")
                    End If
                End If

                If statusFilter <> "All" Then
                    sql &= " AND r.Status=@status"
                    cmd.Parameters.AddWithValue("@status", statusFilter)
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
                lblCount.Text = dt.Rows.Count & " request(s)"
            End Using
        Catch ex As Exception
            MessageBox.Show("Failed to load requests: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FormatGrid()
        If dgvRequests.Columns.Count = 0 Then Return
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
        dgvRequests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvRequests.Columns("RequestNo").FillWeight = 95
        dgvRequests.Columns("RequestDate").FillWeight = 70
        dgvRequests.Columns("StudentID").FillWeight = 75
        dgvRequests.Columns("StudentName").FillWeight = 130
        dgvRequests.Columns("TotalAmount").FillWeight = 70
        dgvRequests.Columns("PaymentStatus").FillWeight = 65
        dgvRequests.Columns("Status").FillWeight = 85
        dgvRequests.Columns("ProcessedBy").FillWeight = 110
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
