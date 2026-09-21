Imports MySql.Data.MySqlClient

Public Class frmRequestDetails
    Private reqID As Integer

    Public Sub New(requestID As Integer)
        InitializeComponent()
        Me.reqID = requestID
    End Sub

    Private Sub frmRequestDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboStatus.Items.AddRange(New String() {"Pending", "Processing", "Ready for Release", "Released", "Cancelled", "Inactive"})
        cboPayment.Items.AddRange(New String() {"Unpaid", "Paid"})
        LoadDetails()
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
                            lblStudentName.Text = reader("StudentName").ToString()
                            lblCourse.Text = reader("Course").ToString() & " - " & reader("YearLevel").ToString() & " " & reader("Section").ToString()
                            lblTotal.Text = "₱ " & Convert.ToDecimal(reader("TotalAmount")).ToString("N2")
                            cboPayment.Text = reader("PaymentStatus").ToString()
                            cboStatus.Text = reader("Status").ToString()
                            txtORNo.Text = If(reader("ORNo") Is DBNull.Value, "", reader("ORNo").ToString())
                            If reader("ORDate") Is DBNull.Value Then
                                chkORDate.Checked = False
                                dtpORDate.Enabled = False
                            Else
                                chkORDate.Checked = True
                                dtpORDate.Enabled = True
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
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If MessageBox.Show("Are you sure you want to update this request?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return

        Dim newStatus As String = cboStatus.Text
        Dim newPayment As String = cboPayment.Text
        Dim orNo As String = txtORNo.Text.Trim()
        Dim orDate As Object = DBNull.Value
        If chkORDate.Checked Then orDate = dtpORDate.Value.Date

        If newPayment = "Paid" AndAlso String.IsNullOrWhiteSpace(orNo) Then
            Dim res = MessageBox.Show("Payment is Paid but OR Number is empty. Continue?", "OR Missing", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If res <> DialogResult.Yes Then Return
        End If

        Try
            Using conn As MySqlConnection = dbConnection.GetConnection()
                conn.Open()
                Dim sql As String = "UPDATE tblrequest SET Status=@status, PaymentStatus=@pay, ORNo=@orNo, ORDate=@orDate WHERE RequestID=@id"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@status", newStatus)
                    cmd.Parameters.AddWithValue("@pay", newPayment)
                    cmd.Parameters.AddWithValue("@orNo", If(String.IsNullOrWhiteSpace(orNo), DBNull.Value, CType(orNo, Object)))
                    cmd.Parameters.AddWithValue("@orDate", orDate)
                    cmd.Parameters.AddWithValue("@id", reqID)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            ' Mirror to registrar_db
            Try
                Using conn As MySqlConnection = dbConnection.GetRegistrarConnection()
                    conn.Open()
                    Dim sql As String = "UPDATE tblrequest SET Status=@status, PaymentStatus=@pay, ORNo=@orNo, ORDate=@orDate WHERE RequestNo=@no"
                    Using cmd As New MySqlCommand(sql, conn)
                        cmd.Parameters.AddWithValue("@status", newStatus)
                        cmd.Parameters.AddWithValue("@pay", newPayment)
                        cmd.Parameters.AddWithValue("@orNo", If(String.IsNullOrWhiteSpace(orNo), DBNull.Value, CType(orNo, Object)))
                        cmd.Parameters.AddWithValue("@orDate", orDate)
                        cmd.Parameters.AddWithValue("@no", lblRequestNo.Text)
                        cmd.ExecuteNonQuery()
                    End Using
                End Using
            Catch ex2 As Exception
                Debug.WriteLine("Registrar sync details failed: " & ex2.Message)
            End Try

            MessageBox.Show("Request updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Update failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub chkORDate_CheckedChanged(sender As Object, e As EventArgs) Handles chkORDate.CheckedChanged
        dtpORDate.Enabled = chkORDate.Checked
    End Sub

    Private Sub pnlInfo_Paint(sender As Object, e As PaintEventArgs) Handles pnlInfo.Paint

    End Sub
End Class
