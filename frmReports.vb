Imports MySql.Data.MySqlClient
Imports System.Text

Public Class frmReports
    Private printRow As Integer = 0

    Private Sub frmReports_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboReportType.Items.AddRange(New String() {
            "All Document Requests",
            "Pending Requests",
            "Released Requests",
            "Requests by Date",
            "Requests by Document Type",
            "Payment Report"})
        cboReportType.SelectedIndex = 0
        cboPayment.Items.AddRange(New String() {"All", "Paid", "Unpaid"})
        cboPayment.SelectedIndex = 0
        cboSearchField.Items.AddRange(New String() {"All", "Request No", "Student ID", "OR Number", "Last Name"})
        cboSearchField.SelectedIndex = 0
        dtpFrom.Value = DateTime.Today.AddMonths(-2)
        dtpTo.Value = DateTime.Today
        LoadDocumentCombo()
        AddHandler PrintDoc.PrintPage, AddressOf PrintDoc_PrintPage
        GenerateReport()
    End Sub

    Private Sub LoadDocumentCombo()
        Try
            Using conn As MySqlConnection = dbConnection.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand("SELECT DocumentName FROM tbldocuments ORDER BY DocumentName", conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        cboDocument.Items.Clear()
                        cboDocument.Items.Add("All")
                        While reader.Read()
                            cboDocument.Items.Add(reader("DocumentName").ToString())
                        End While
                    End Using
                End Using
            End Using
            cboDocument.SelectedIndex = 0
        Catch ex As Exception
            cboDocument.Items.Clear()
            cboDocument.Items.Add("All")
            cboDocument.SelectedIndex = 0
        End Try
    End Sub

    Private Sub cboReportType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboReportType.SelectedIndexChanged
        Dim t As String = cboReportType.Text
        dtpFrom.Enabled = (t = "Requests by Date")
        dtpTo.Enabled = (t = "Requests by Date")
        cboDocument.Enabled = (t = "Requests by Document Type")
        cboPayment.Enabled = (t = "Payment Report")
        GenerateReport()
    End Sub

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        GenerateReport()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        txtSearch.Clear()
        cboSearchField.SelectedIndex = 0
        cboReportType.SelectedIndex = 0
        If cboDocument.Items.Count > 0 Then cboDocument.SelectedIndex = 0
        If cboPayment.Items.Count > 0 Then cboPayment.SelectedIndex = 0
        dtpFrom.Value = DateTime.Today.AddMonths(-2)
        dtpTo.Value = DateTime.Today
        GenerateReport()
    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            GenerateReport()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub GenerateReport()
        Try
            Dim t As String = If(cboReportType.Text, "All Document Requests")
            Dim search As String = txtSearch.Text.Trim()
            Dim field As String = If(cboSearchField.Text, "All")
            Dim dt As New DataTable()

            Using conn As MySqlConnection = dbConnection.GetConnection()
                conn.Open()
                Dim cmd As New MySqlCommand()
                cmd.Connection = conn

                If t = "Requests by Document Type" Then
                    Dim sql As String = "SELECT r.RequestNo, r.RequestDate, r.StudentID, CONCAT(s.LastName, ', ', s.FirstName) AS StudentName, d.DocumentName, rd.Quantity, rd.SubTotal, r.Status FROM tblrequest r JOIN tblstudents s ON r.StudentID=s.StudentID JOIN tblrequestdetails rd ON rd.RequestID=r.RequestID JOIN tbldocuments d ON d.DocumentID=rd.DocumentID WHERE 1=1"
                    If cboDocument.Text <> "All" AndAlso cboDocument.Text <> "" Then
                        sql &= " AND d.DocumentName=@doc"
                        cmd.Parameters.AddWithValue("@doc", cboDocument.Text)
                    End If
                    If search <> "" Then
                        If field = "Request No" Then
                            sql &= " AND r.RequestNo LIKE @s"
                        ElseIf field = "Student ID" Then
                            sql &= " AND r.StudentID LIKE @s"
                        ElseIf field = "OR Number" Then
                            sql &= " AND r.ORNo LIKE @s"
                        ElseIf field = "Last Name" Then
                            sql &= " AND s.LastName LIKE @s"
                        Else
                            sql &= " AND (r.RequestNo LIKE @s OR r.StudentID LIKE @s OR s.LastName LIKE @s OR r.ORNo LIKE @s)"
                        End If
                        cmd.Parameters.AddWithValue("@s", "%" & search & "%")
                    End If
                    sql &= " ORDER BY r.RequestDate ASC, r.RequestNo ASC"
                    cmd.CommandText = sql
                Else
                    Dim sql As String = "SELECT r.RequestNo, r.RequestDate, r.StudentID, CONCAT(s.LastName, ', ', s.FirstName) AS StudentName, r.TotalAmount, r.PaymentStatus, r.ORNo, r.Status, COALESCE(u.FullName,'') AS ProcessedBy FROM tblrequest r JOIN tblstudents s ON r.StudentID=s.StudentID LEFT JOIN tblusers u ON r.CreatedBy=u.UserID WHERE 1=1"
                    If t = "Pending Requests" Then
                        sql &= " AND r.Status='Pending'"
                    ElseIf t = "Released Requests" Then
                        sql &= " AND r.Status='Released'"
                    ElseIf t = "Requests by Date" Then
                        sql &= " AND r.RequestDate BETWEEN @from AND @to"
                        cmd.Parameters.AddWithValue("@from", dtpFrom.Value.Date)
                        cmd.Parameters.AddWithValue("@to", dtpTo.Value.Date)
                    ElseIf t = "Payment Report" Then
                        If cboPayment.Text = "Paid" OrElse cboPayment.Text = "Unpaid" Then
                            sql &= " AND r.PaymentStatus=@pay"
                            cmd.Parameters.AddWithValue("@pay", cboPayment.Text)
                        End If
                    End If
                    If search <> "" Then
                        If field = "Request No" Then
                            sql &= " AND r.RequestNo LIKE @s"
                        ElseIf field = "Student ID" Then
                            sql &= " AND r.StudentID LIKE @s"
                        ElseIf field = "OR Number" Then
                            sql &= " AND r.ORNo LIKE @s"
                        ElseIf field = "Last Name" Then
                            sql &= " AND s.LastName LIKE @s"
                        Else
                            sql &= " AND (r.RequestNo LIKE @s OR r.StudentID LIKE @s OR s.LastName LIKE @s OR r.ORNo LIKE @s)"
                        End If
                        cmd.Parameters.AddWithValue("@s", "%" & search & "%")
                    End If
                    sql &= " ORDER BY r.RequestDate ASC, r.RequestNo ASC"
                    cmd.CommandText = sql
                End If

                Using da As New MySqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
            End Using

            dgvReport.DataSource = dt
            FormatGrid()
            lblCount.Text = dt.Rows.Count & " record(s)"
            UpdateTotal(dt)
        Catch ex As Exception
            MessageBox.Show("Failed to generate report: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FormatGrid()
        If dgvReport.Columns.Count = 0 Then Return
        For Each col As DataGridViewColumn In dgvReport.Columns
            col.HeaderText = col.HeaderText
        Next
        If dgvReport.Columns.Contains("RequestDate") Then
            dgvReport.Columns("RequestDate").DefaultCellStyle.Format = "MM/dd/yyyy"
        End If
        If dgvReport.Columns.Contains("TotalAmount") Then
            dgvReport.Columns("TotalAmount").HeaderText = "Total (₱)"
            dgvReport.Columns("TotalAmount").DefaultCellStyle.Format = "N2"
            dgvReport.Columns("TotalAmount").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If
        If dgvReport.Columns.Contains("SubTotal") Then
            dgvReport.Columns("SubTotal").HeaderText = "SubTotal (₱)"
            dgvReport.Columns("SubTotal").DefaultCellStyle.Format = "N2"
            dgvReport.Columns("SubTotal").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        End If
        dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    Private Sub UpdateTotal(dt As DataTable)
        Dim total As Decimal = 0
        Try
            If dt.Columns.Contains("TotalAmount") Then
                For Each row As DataRow In dt.Rows
                    If row("TotalAmount") IsNot DBNull.Value Then total += Convert.ToDecimal(row("TotalAmount"))
                Next
            ElseIf dt.Columns.Contains("SubTotal") Then
                For Each row As DataRow In dt.Rows
                    If row("SubTotal") IsNot DBNull.Value Then total += Convert.ToDecimal(row("SubTotal"))
                Next
            End If
        Catch
        End Try
        lblTotal.Text = "Total: ₱" & total.ToString("N2")
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        If dgvReport.Rows.Count = 0 Then
            MessageBox.Show("No records to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Using sfd As New SaveFileDialog()
            sfd.Filter = "CSV files (*.csv)|*.csv"
            sfd.FileName = "Report_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".csv"
            If sfd.ShowDialog() = DialogResult.OK Then
                Try
                    Dim sb As New StringBuilder()
                    Dim headers As New List(Of String)()
                    For Each col As DataGridViewColumn In dgvReport.Columns
                        headers.Add("""" & col.HeaderText.Replace("""", """""") & """")
                    Next
                    sb.AppendLine(String.Join(",", headers))
                    For Each row As DataGridViewRow In dgvReport.Rows
                        If row.IsNewRow Then Continue For
                        Dim cells As New List(Of String)()
                        For Each col As DataGridViewColumn In dgvReport.Columns
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

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If dgvReport.Rows.Count = 0 Then
            MessageBox.Show("No records to print.", "Print", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        printRow = 0
        PrintDoc.DocumentName = cboReportType.Text
        Using dlg As New PrintPreviewDialog()
            dlg.Document = PrintDoc
            dlg.WindowState = FormWindowState.Maximized
            dlg.ShowDialog()
        End Using
    End Sub

    Private Sub PrintDoc_PrintPage(sender As Object, e As System.Drawing.Printing.PrintPageEventArgs)
        Dim titleFont As New Font("Segoe UI", 14, FontStyle.Bold)
        Dim subFont As New Font("Segoe UI", 9)
        Dim cellFont As New Font("Segoe UI", 8)
        Dim y As Single = e.MarginBounds.Top
        e.Graphics.DrawString("Registrar Document Request System", titleFont, Brushes.Black, e.MarginBounds.Left, y)
        y += 26
        e.Graphics.DrawString(cboReportType.Text & "  |  " & DateTime.Now.ToString("MM/dd/yyyy") & "  |  " & lblCount.Text & "  |  " & lblTotal.Text, subFont, Brushes.DimGray, e.MarginBounds.Left, y)
        y += 22

        Dim cols As New List(Of DataGridViewColumn)()
        For Each c As DataGridViewColumn In dgvReport.Columns
            If c.Visible Then cols.Add(c)
        Next
        If cols.Count = 0 Then
            e.HasMorePages = False
            Return
        End If
        Dim colW As Single = e.MarginBounds.Width / cols.Count
        ' Header
        For i As Integer = 0 To cols.Count - 1
            e.Graphics.FillRectangle(Brushes.LightGray, e.MarginBounds.Left + i * colW, y, colW, 22)
            e.Graphics.DrawRectangle(Pens.Gray, e.MarginBounds.Left + i * colW, y, colW, 22)
            e.Graphics.DrawString(cols(i).HeaderText, subFont, Brushes.Black, New RectangleF(e.MarginBounds.Left + i * colW + 2, y + 3, colW - 4, 18))
        Next
        y += 22
        ' Rows
        While printRow < dgvReport.Rows.Count
            Dim row As DataGridViewRow = dgvReport.Rows(printRow)
            If row.IsNewRow Then
                printRow += 1
                Continue While
            End If
            If y + 20 > e.MarginBounds.Bottom Then
                e.HasMorePages = True
                Return
            End If
            For i As Integer = 0 To cols.Count - 1
                Dim v As String = If(row.Cells(cols(i).Index).Value Is Nothing, "", row.Cells(cols(i).Index).Value.ToString())
                If v.Length > 28 Then v = v.Substring(0, 28)
                e.Graphics.DrawRectangle(Pens.LightGray, e.MarginBounds.Left + i * colW, y, colW, 20)
                e.Graphics.DrawString(v, cellFont, Brushes.Black, New RectangleF(e.MarginBounds.Left + i * colW + 2, y + 3, colW - 4, 16))
            Next
            y += 20
            printRow += 1
        End While
        e.HasMorePages = False
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub pnlTop_Paint(sender As Object, e As PaintEventArgs) Handles pnlTop.Paint

    End Sub
End Class
