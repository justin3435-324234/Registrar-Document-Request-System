Imports MySql.Data.MySqlClient
Imports System.Text

Public Class frmAuditTrail
    Private Sub frmAuditTrail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboActionFilter.Items.AddRange(New String() {"All", "Created", "Status Changed", "Payment Changed", "Edit Unlocked", "Updated"})
        cboActionFilter.SelectedIndex = 0
        dtpFrom.Value = DateTime.Today.AddMonths(-2)
        dtpTo.Value = DateTime.Today
        LoadAudit()
    End Sub

    Private Sub LoadAudit()
        Try
            Dim search As String = txtSearch.Text.Trim()
            Dim actionFilter As String = cboActionFilter.Text
            Dim useDate As Boolean = chkDateFilter.Checked
            Using conn As MySqlConnection = dbConnection.GetConnection()
                conn.Open()
                Dim sql As String = "SELECT AuditID, RequestNo, ActionDate, PerformedBy, UserRole, ActionTaken, OldValue, NewValue, Remarks FROM tblaudittrail WHERE 1=1"
                Dim cmd As New MySqlCommand()
                cmd.Connection = conn
                If actionFilter <> "All" Then
                    sql &= " AND ActionTaken=@act"
                    cmd.Parameters.AddWithValue("@act", actionFilter)
                End If
                If Not String.IsNullOrWhiteSpace(search) Then
                    sql &= " AND (RequestNo LIKE @s OR PerformedBy LIKE @s OR ActionTaken LIKE @s)"
                    cmd.Parameters.AddWithValue("@s", "%" & search & "%")
                End If
                If useDate Then
                    sql &= " AND DATE(ActionDate) BETWEEN @from AND @to"
                    cmd.Parameters.AddWithValue("@from", dtpFrom.Value.Date)
                    cmd.Parameters.AddWithValue("@to", dtpTo.Value.Date)
                End If
                sql &= " ORDER BY ActionDate DESC"
                cmd.CommandText = sql
                Dim dt As New DataTable()
                Using da As New MySqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
                dgvAudit.DataSource = dt
                FormatGrid()
                lblCount.Text = dt.Rows.Count & " record(s)"
            End Using
        Catch ex As Exception
            If ex.Message.Contains("doesn't exist") OrElse ex.Message.Contains("Unknown") Then
                MessageBox.Show("Audit table not found. Re-import Database/database.sql in phpMyAdmin.", "Setup Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show("Failed to load audit trail: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub

    Private Sub FormatGrid()
        If dgvAudit.Columns.Count = 0 Then Return
        dgvAudit.AllowUserToResizeColumns = True
        dgvAudit.AllowUserToOrderColumns = False
        dgvAudit.ScrollBars = ScrollBars.Both
        dgvAudit.Columns("AuditID").Visible = False
        dgvAudit.Columns("RequestNo").Visible = False
        dgvAudit.Columns("ActionDate").HeaderText = "Date"
        dgvAudit.Columns("ActionDate").DefaultCellStyle.Format = "MM/dd/yyyy HH:mm"
        dgvAudit.Columns("PerformedBy").HeaderText = "Performed By"
        dgvAudit.Columns("UserRole").HeaderText = "User Role"
        dgvAudit.Columns("ActionTaken").HeaderText = "Action Taken"
        dgvAudit.Columns("OldValue").Visible = False
        dgvAudit.Columns("NewValue").Visible = False
        dgvAudit.Columns("Remarks").HeaderText = "Remarks"
        ' Fixed widths: resize and bottom scrollbar always work reliably
        dgvAudit.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        dgvAudit.Columns("ActionDate").Width = 140
        dgvAudit.Columns("PerformedBy").Width = 170
        dgvAudit.Columns("UserRole").Width = 120
        dgvAudit.Columns("ActionTaken").Width = 140
        dgvAudit.Columns("Remarks").Width = 260
        dgvAudit.Columns("Remarks").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgvAudit.Columns("Remarks").MinimumWidth = 150
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        LoadAudit()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        txtSearch.Clear()
        cboActionFilter.SelectedIndex = 0
        chkDateFilter.Checked = False
        LoadAudit()
    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then LoadAudit() : e.SuppressKeyPress = True
    End Sub

    Private Sub chkDateFilter_CheckedChanged(sender As Object, e As EventArgs) Handles chkDateFilter.CheckedChanged
        dtpFrom.Enabled = chkDateFilter.Checked
        dtpTo.Enabled = chkDateFilter.Checked
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        If dgvAudit.Rows.Count = 0 Then
            MessageBox.Show("No records to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Using sfd As New SaveFileDialog()
            sfd.Filter = "CSV files (*.csv)|*.csv"
            sfd.FileName = "AuditTrail_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".csv"
            If sfd.ShowDialog() = DialogResult.OK Then
                Try
                    Dim sb As New StringBuilder()
                    Dim headers As New List(Of String)()
                    For Each col As DataGridViewColumn In dgvAudit.Columns
                        If col.Visible Then headers.Add("""" & col.HeaderText.Replace("""", """""") & """")
                    Next
                    sb.AppendLine(String.Join(",", headers))
                    For Each row As DataGridViewRow In dgvAudit.Rows
                        If row.IsNewRow Then Continue For
                        Dim cells As New List(Of String)()
                        For Each col As DataGridViewColumn In dgvAudit.Columns
                            If Not col.Visible Then Continue For
                            Dim v As String = If(row.Cells(col.Index).Value Is Nothing, "", row.Cells(col.Index).Value.ToString())
                            cells.Add("""" & v.Replace("""", """""") & """")
                        Next
                        sb.AppendLine(String.Join(",", cells))
                    Next
                    System.IO.File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8)
                    MessageBox.Show("Exported to " & sfd.FileName, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Catch ex As Exception
                    MessageBox.Show("Export failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class
