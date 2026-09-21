Imports MySql.Data.MySqlClient

Public Class frmRequest
    Private studentFound As Boolean = False
    Private currentStudentID As String = ""
    Private dtDetails As DataTable
    Private totalAmount As Decimal = 0

    Private Sub frmRequest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dtpRequestDate.Value = DateTime.Today
        cboPaymentStatus.Items.AddRange(New String() {"Unpaid", "Paid"})
        cboPaymentStatus.SelectedIndex = 0
        cboRequestStatus.Items.AddRange(New String() {"Pending", "Processing", "Ready for Release", "Released", "Cancelled"})
        cboRequestStatus.SelectedIndex = 0
        cboRequestStatus.Enabled = False ' default Pending on create
        lblProcessedBy.Text = Session.CurrentFullName
        GenerateRequestNo()
        LoadDocumentsCombo()
        InitDetailsTable()
        txtStudentID.Focus()
    End Sub

    Private Sub InitDetailsTable()
        dtDetails = New DataTable()
        dtDetails.Columns.Add("DocumentID", GetType(Integer))
        dtDetails.Columns.Add("DocumentName", GetType(String))
        dtDetails.Columns.Add("Fee", GetType(Decimal))
        dtDetails.Columns.Add("Quantity", GetType(Integer))
        dtDetails.Columns.Add("SubTotal", GetType(Decimal))
        dgvDetails.DataSource = dtDetails
        FormatGrid()
        UpdateTotal()
    End Sub

    Private Sub FormatGrid()
        If dgvDetails.Columns.Count = 0 Then Return
        dgvDetails.Columns("DocumentID").Visible = False
        dgvDetails.Columns("DocumentName").HeaderText = "Document"
        dgvDetails.Columns("Fee").HeaderText = "Fee (₱)"
        dgvDetails.Columns("Fee").DefaultCellStyle.Format = "N2"
        dgvDetails.Columns("Fee").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvDetails.Columns("Quantity").HeaderText = "Qty"
        dgvDetails.Columns("SubTotal").HeaderText = "SubTotal (₱)"
        dgvDetails.Columns("SubTotal").DefaultCellStyle.Format = "N2"
        dgvDetails.Columns("SubTotal").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvDetails.Columns("DocumentName").FillWeight = 250
        dgvDetails.Columns("Quantity").FillWeight = 60
    End Sub

    Private Sub GenerateRequestNo()
        Try
            Dim yearStr As String = DateTime.Today.Year.ToString()
            Dim prefix As String = "REQ-" & yearStr & "-"
            Using conn As MySqlConnection = dbConnection.GetConnection()
                conn.Open()
                Dim sql As String = "SELECT RequestNo FROM tblrequest WHERE RequestNo LIKE @p ORDER BY RequestNo DESC LIMIT 1"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@p", prefix & "%")
                    Dim lastNo As Object = cmd.ExecuteScalar()
                    Dim nextNum As Integer = 1
                    If lastNo IsNot Nothing AndAlso lastNo IsNot DBNull.Value Then
                        Dim lastStr As String = lastNo.ToString()
                        Dim numPart As String = lastStr.Substring(prefix.Length)
                        Integer.TryParse(numPart, nextNum)
                        nextNum += 1
                    End If
                    txtRequestNo.Text = prefix & nextNum.ToString("D5")
                End Using
            End Using
        Catch ex As Exception
            txtRequestNo.Text = "REQ-" & DateTime.Today.Year & "-00001"
        End Try
    End Sub

    Private Sub LoadDocumentsCombo()
        Try
            Using conn As MySqlConnection = dbConnection.GetConnection()
                conn.Open()
                Dim sql As String = "SELECT DocumentID, DocumentName, Fee FROM tbldocuments WHERE Status='Active' ORDER BY DocumentName"
                Using cmd As New MySqlCommand(sql, conn)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        cboDocument.Items.Clear()
                        While reader.Read()
                            Dim id As Integer = Convert.ToInt32(reader("DocumentID"))
                            Dim name As String = reader("DocumentName").ToString()
                            Dim fee As Decimal = Convert.ToDecimal(reader("Fee"))
                            cboDocument.Items.Add(New ComboItem(name & " - ₱" & fee.ToString("0.00"), id, fee))
                        End While
                    End Using
                End Using
            End Using
            If cboDocument.Items.Count > 0 Then cboDocument.SelectedIndex = 0
        Catch ex As Exception
            MessageBox.Show("Failed to load documents: " & ex.Message)
        End Try
    End Sub

    Private Class ComboItem
        Public Text As String
        Public ID As Integer
        Public Fee As Decimal
        Public Sub New(t As String, id As Integer, fee As Decimal)
            Me.Text = t : Me.ID = id : Me.Fee = fee
        End Sub
        Public Overrides Function ToString() As String
            Return Text
        End Function
    End Class

    Private Sub cboDocument_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDocument.SelectedIndexChanged
        If cboDocument.SelectedItem Is Nothing Then Return
        Dim item As ComboItem = CType(cboDocument.SelectedItem, ComboItem)
        txtDocFee.Text = item.Fee.ToString("0.00")
        UpdateDocSubtotal()
    End Sub

    Private Sub numQuantity_ValueChanged(sender As Object, e As EventArgs) Handles numQuantity.ValueChanged
        UpdateDocSubtotal()
    End Sub

    Private Sub UpdateDocSubtotal()
        If cboDocument.SelectedItem Is Nothing Then Return
        Dim item As ComboItem = CType(cboDocument.SelectedItem, ComboItem)
        Dim qty As Integer = CInt(numQuantity.Value)
        Dim subtotal As Decimal = item.Fee * qty
        txtDocSubtotal.Text = subtotal.ToString("0.00")
    End Sub

    Private Sub btnSearchStudent_Click(sender As Object, e As EventArgs) Handles btnSearchStudent.Click
        Dim sid As String = txtStudentID.Text.Trim()
        If String.IsNullOrWhiteSpace(sid) Then MessageBox.Show("Enter Student ID", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning) : txtStudentID.Focus() : Return
        Try
            Using conn As MySqlConnection = dbConnection.GetConnection()
                conn.Open()
                Dim sql As String = "SELECT StudentID, LRN, LastName, FirstName, MiddleName, Course, YearLevel, Section, ContactNo, Status FROM tblstudents WHERE StudentID=@id"
                Using cmd As New MySqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@id", sid)
                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            If reader("Status").ToString() <> "Active" Then
                                MessageBox.Show("Student is Inactive.", "Inactive", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            End If
                            currentStudentID = reader("StudentID").ToString()
                            studentFound = True
                            lblStudentName.Text = reader("LastName").ToString() & ", " & reader("FirstName").ToString() & " " & reader("MiddleName").ToString()
                            lblCourse.Text = reader("Course").ToString()
                            lblYear.Text = reader("YearLevel").ToString()
                            lblSection.Text = reader("Section").ToString()
                            lblLRN.Text = "LRN: " & reader("LRN").ToString()
                            lblStudentName.ForeColor = Color.FromArgb(15, 23, 42)
                            lblCourse.ForeColor = Color.FromArgb(15, 23, 42)
                        Else
                            MessageBox.Show("Student ID not found.", "Not found", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            ClearStudentInfo()
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Search failed: " & ex.Message)
        End Try
    End Sub

    Private Sub ClearStudentInfo()
        studentFound = False
        currentStudentID = ""
        lblStudentName.Text = "—"
        lblCourse.Text = "—"
        lblYear.Text = "—"
        lblSection.Text = "—"
        lblLRN.Text = "LRN: —"
        lblStudentName.ForeColor = Color.Gray
    End Sub

    Private Sub txtStudentID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtStudentID.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearchStudent.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub btnAddDocument_Click(sender As Object, e As EventArgs) Handles btnAddDocument.Click
        If Not studentFound Then
            MessageBox.Show("Search and select a valid student first.", "Student required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtStudentID.Focus()
            Return
        End If
        If cboDocument.SelectedItem Is Nothing Then
            MessageBox.Show("Select a document.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        Dim qty As Integer = CInt(numQuantity.Value)
        If qty <= 0 Then MessageBox.Show("Quantity must be at least 1.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Return

        Dim item As ComboItem = CType(cboDocument.SelectedItem, ComboItem)
        ' Check duplicate document in same request
        For Each row As DataRow In dtDetails.Rows
            If CInt(row("DocumentID")) = item.ID Then
                MessageBox.Show("Document already added. Remove it first to change quantity.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        Next

        Dim subtotal As Decimal = item.Fee * qty
        Dim newRow As DataRow = dtDetails.NewRow()
        newRow("DocumentID") = item.ID
        ' Extract clean document name without fee suffix
        Dim cleanName As String = item.Text.Split("—"c)(0).Trim()
        newRow("DocumentName") = cleanName
        newRow("Fee") = item.Fee
        newRow("Quantity") = qty
        newRow("SubTotal") = subtotal
        dtDetails.Rows.Add(newRow)
        UpdateTotal()
    End Sub

    Private Sub btnRemoveDoc_Click(sender As Object, e As EventArgs) Handles btnRemoveDoc.Click
        If dgvDetails.SelectedRows.Count = 0 Then
            MessageBox.Show("Select a row to remove.", "No selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        For Each r As DataGridViewRow In dgvDetails.SelectedRows
            If Not r.IsNewRow Then
                dgvDetails.Rows.Remove(r)
            End If
        Next
        UpdateTotal()
    End Sub

    Private Sub UpdateTotal()
        totalAmount = 0
        For Each row As DataRow In dtDetails.Rows
            totalAmount += Convert.ToDecimal(row("SubTotal"))
        Next
        lblTotal.Text = "₱ " & totalAmount.ToString("N2")
        lblTotalCount.Text = dtDetails.Rows.Count & " document(s)"
    End Sub

    Private Sub btnSaveRequest_Click(sender As Object, e As EventArgs) Handles btnSaveRequest.Click
        If Not studentFound OrElse String.IsNullOrWhiteSpace(currentStudentID) Then
            MessageBox.Show("Select a valid student first.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If dtDetails.Rows.Count = 0 Then
            MessageBox.Show("Add at least one document.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If totalAmount <= 0 Then
            MessageBox.Show("Total amount invalid.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Validate payment
        Dim paymentStatus As String = cboPaymentStatus.Text
        Dim orNo As String = txtORNo.Text.Trim()
        Dim orDate As Object = DBNull.Value
        If chkORDate.Checked Then
            orDate = dtpORDate.Value.Date
        End If
        If paymentStatus = "Paid" AndAlso String.IsNullOrWhiteSpace(orNo) Then
            Dim res = MessageBox.Show("Payment is Paid but OR Number is empty. Continue?", "OR Missing", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If res <> DialogResult.Yes Then Return
        End If

        Dim reqNo As String = txtRequestNo.Text.Trim()
        Dim reqDate As Date = dtpRequestDate.Value.Date
        Dim status As String = cboRequestStatus.Text
        Dim createdBy As Integer = Session.CurrentUserID

        Try
            Using conn As MySqlConnection = dbConnection.GetConnection()
                conn.Open()
                Using tran As MySqlTransaction = conn.BeginTransaction()
                    Try
                        Dim sqlReq As String = "INSERT INTO tblrequest (RequestNo, StudentID, RequestDate, TotalAmount, PaymentStatus, ORNo, ORDate, Status, CreatedBy) VALUES (@no,@sid,@date,@total,@pay,@orNo,@orDate,@status,@by)"
                        Using cmd As New MySqlCommand(sqlReq, conn, tran)
                            cmd.Parameters.AddWithValue("@no", reqNo)
                            cmd.Parameters.AddWithValue("@sid", currentStudentID)
                            cmd.Parameters.AddWithValue("@date", reqDate)
                            cmd.Parameters.AddWithValue("@total", totalAmount)
                            cmd.Parameters.AddWithValue("@pay", paymentStatus)
                            cmd.Parameters.AddWithValue("@orNo", If(String.IsNullOrWhiteSpace(orNo), DBNull.Value, CType(orNo, Object)))
                            cmd.Parameters.AddWithValue("@orDate", orDate)
                            cmd.Parameters.AddWithValue("@status", status)
                            cmd.Parameters.AddWithValue("@by", createdBy)
                            cmd.ExecuteNonQuery()
                        End Using

                        Dim newId As Integer = 0
                        Using cmd As New MySqlCommand("SELECT LAST_INSERT_ID()", conn, tran)
                            newId = Convert.ToInt32(cmd.ExecuteScalar())
                        End Using

                        For Each row As DataRow In dtDetails.Rows
                            Dim sqlDet As String = "INSERT INTO tblrequestdetails (RequestID, DocumentID, Quantity, Amount, SubTotal) VALUES (@rid,@did,@qty,@amt,@sub)"
                            Using cmd As New MySqlCommand(sqlDet, conn, tran)
                                cmd.Parameters.AddWithValue("@rid", newId)
                                cmd.Parameters.AddWithValue("@did", row("DocumentID"))
                                cmd.Parameters.AddWithValue("@qty", row("Quantity"))
                                cmd.Parameters.AddWithValue("@amt", row("Fee"))
                                cmd.Parameters.AddWithValue("@sub", row("SubTotal"))
                                cmd.ExecuteNonQuery()
                            End Using
                        Next

                        tran.Commit()
                        MessageBox.Show("Request saved!" & vbCrLf & "Request No: " & reqNo & vbCrLf & "Total: ₱" & totalAmount.ToString("N2"), "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ClearAll()
                        GenerateRequestNo()
                    Catch ex As Exception
                        tran.Rollback()
                        Throw
                    End Try
                End Using
            End Using
        Catch ex As MySqlException
            If ex.Number = 1062 Then
                MessageBox.Show("Duplicate Request No. Try again.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                GenerateRequestNo()
            Else
                MessageBox.Show("Save failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ClearAll()
        ClearStudentInfo()
        txtStudentID.Clear()
        dtDetails.Clear()
        UpdateTotal()
        cboPaymentStatus.SelectedIndex = 0
        cboRequestStatus.SelectedIndex = 0
        txtORNo.Clear()
        chkORDate.Checked = False
        If cboDocument.Items.Count > 0 Then cboDocument.SelectedIndex = 0
        numQuantity.Value = 1
    End Sub

    Private Sub btnClearAll_Click(sender As Object, e As EventArgs) Handles btnClearAll.Click
        ClearAll()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub chkORDate_CheckedChanged(sender As Object, e As EventArgs) Handles chkORDate.CheckedChanged
        dtpORDate.Enabled = chkORDate.Checked
    End Sub

    Private Sub lblPayment_Click(sender As Object, e As EventArgs) Handles lblPayment.Click

    End Sub

    Private Sub pnlInfo_Paint(sender As Object, e As PaintEventArgs) Handles pnlInfo.Paint

    End Sub

    Private Sub pnlStudent_Paint(sender As Object, e As PaintEventArgs) Handles pnlStudent.Paint

    End Sub

    Private Sub lblStudentID_Click(sender As Object, e As EventArgs) Handles lblStudentID.Click

    End Sub

    Private Sub txtStudentID_TextChanged(sender As Object, e As EventArgs) Handles txtStudentID.TextChanged

    End Sub

    Private Sub lblStudentPanelTitle_Click(sender As Object, e As EventArgs) Handles lblStudentPanelTitle.Click

    End Sub
End Class
