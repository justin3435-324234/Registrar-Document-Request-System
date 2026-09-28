Imports MySql.Data.MySqlClient

Public Class frmDocuments
    Private isEditing As Boolean = False
    Private currentID As Integer = 0

    Private Sub frmDocuments_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboStatus.Items.AddRange(New String() {"Active", "Inactive"})
        cboStatus.SelectedIndex = 0
        cboSearchField.Items.AddRange(New String() {"All", "DocumentName", "Status"})
        cboSearchField.SelectedIndex = 0
        LoadDocuments()
    End Sub

    Private Sub LoadDocuments(Optional search As String = "", Optional field As String = "All")
        Try
            Using conn As MySqlConnection = dbConnection.GetConnection()
                conn.Open()
                Dim sql As String = "SELECT DocumentID, DocumentName, Description, Fee, Status FROM tbldocuments"
                Dim cmd As MySqlCommand
                If Not String.IsNullOrWhiteSpace(search) Then
                    If field = "All" Then
                        sql &= " WHERE DocumentName LIKE @s OR Description LIKE @s OR Status LIKE @s"
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
                cmd.CommandText &= " ORDER BY DocumentID"
                Dim dt As New DataTable()
                Using da As New MySqlDataAdapter(cmd)
                    da.Fill(dt)
                End Using
                dgvDocuments.DataSource = dt
                FormatGrid()
                lblCount.Text = dt.Rows.Count & " record(s)"
            End Using
        Catch ex As Exception
            MessageBox.Show("Failed to load documents: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FormatGrid()
        If dgvDocuments.Columns.Count = 0 Then Return
        dgvDocuments.Columns("DocumentID").HeaderText = "ID"
        dgvDocuments.Columns("DocumentName").HeaderText = "Document Name"
        dgvDocuments.Columns("Description").HeaderText = "Description"
        dgvDocuments.Columns("Fee").HeaderText = "Fee (₱)"
        dgvDocuments.Columns("Status").HeaderText = "Status"
        dgvDocuments.Columns("Fee").DefaultCellStyle.Format = "N2"
        dgvDocuments.Columns("Fee").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvDocuments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvDocuments.Columns("DocumentID").FillWeight = 40
        dgvDocuments.Columns("Fee").FillWeight = 60
        dgvDocuments.Columns("Status").FillWeight = 60
    End Sub

    Private Sub dgvDocuments_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDocuments.CellClick
        If e.RowIndex < 0 Then Return
        Dim row As DataGridViewRow = dgvDocuments.Rows(e.RowIndex)
        currentID = Convert.ToInt32(row.Cells("DocumentID").Value)
        txtDocName.Text = row.Cells("DocumentName").Value.ToString()
        txtDescription.Text = row.Cells("Description").Value.ToString()
        txtFee.Text = Convert.ToDecimal(row.Cells("Fee").Value).ToString("0.00")
        cboStatus.Text = row.Cells("Status").Value.ToString()
        lblDocID.Text = "ID: " & currentID
        isEditing = True
        btnAdd.Text = "Update"
        btnToggle.Enabled = True
        btnDelete.Enabled = True
    End Sub

    Private Function ValidateInput() As Boolean
        If String.IsNullOrWhiteSpace(txtDocName.Text) Then
            MessageBox.Show("Document Name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning) : txtDocName.Focus() : Return False
        End If
        If String.IsNullOrWhiteSpace(txtFee.Text) Then
            MessageBox.Show("Fee is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning) : txtFee.Focus() : Return False
        End If
        Dim fee As Decimal
        If Not Decimal.TryParse(txtFee.Text, fee) OrElse fee < 0 Then
            MessageBox.Show("Fee must be a valid positive number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning) : txtFee.Focus() : Return False
        End If
        If fee > 10000 Then
            MessageBox.Show("Fee seems too high.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Return False
        End If
        Return True
    End Function

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If Not ValidateInput() Then Return
        Try
            Using conn As MySqlConnection = dbConnection.GetConnection()
                conn.Open()
                Dim fee As Decimal = Decimal.Parse(txtFee.Text)
                If isEditing Then
                    Dim sql As String = "UPDATE tbldocuments SET DocumentName=@n, Description=@d, Fee=@f, Status=@s WHERE DocumentID=@id"
                    Using cmd As New MySqlCommand(sql, conn)
                        cmd.Parameters.AddWithValue("@n", txtDocName.Text.Trim())
                        cmd.Parameters.AddWithValue("@d", txtDescription.Text.Trim())
                        cmd.Parameters.AddWithValue("@f", fee)
                        cmd.Parameters.AddWithValue("@s", cboStatus.Text)
                        cmd.Parameters.AddWithValue("@id", currentID)
                        cmd.ExecuteNonQuery()
                        MessageBox.Show("Document updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End Using
                Else
                    Using chk As New MySqlCommand("SELECT COUNT(*) FROM tbldocuments WHERE DocumentName=@n", conn)
                        chk.Parameters.AddWithValue("@n", txtDocName.Text.Trim())
                        If Convert.ToInt32(chk.ExecuteScalar()) > 0 Then
                            MessageBox.Show("Document name already exists.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Return
                        End If
                    End Using
                    Dim sql As String = "INSERT INTO tbldocuments (DocumentName, Description, Fee, Status) VALUES (@n,@d,@f,@s)"
                    Using cmd As New MySqlCommand(sql, conn)
                        cmd.Parameters.AddWithValue("@n", txtDocName.Text.Trim())
                        cmd.Parameters.AddWithValue("@d", txtDescription.Text.Trim())
                        cmd.Parameters.AddWithValue("@f", fee)
                        cmd.Parameters.AddWithValue("@s", cboStatus.Text)
                        cmd.ExecuteNonQuery()
                        MessageBox.Show("Document added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End Using
                End If
            End Using
            LoadDocuments(txtSearch.Text.Trim(), cboSearchField.Text)
            ClearForm()
        Catch ex As MySqlException
            MessageBox.Show("DB error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnToggle_Click(sender As Object, e As EventArgs) Handles btnToggle.Click
        If currentID = 0 Then MessageBox.Show("Select a document first.", "No selection", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Return
        If MessageBox.Show("Are you sure you want to activate/deactivate this document?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return
        Dim newStatus As String = If(cboStatus.Text = "Active", "Inactive", "Active")
        Try
            Using conn As MySqlConnection = dbConnection.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand("UPDATE tbldocuments SET Status=@s WHERE DocumentID=@id", conn)
                    cmd.Parameters.AddWithValue("@s", newStatus)
                    cmd.Parameters.AddWithValue("@id", currentID)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            MessageBox.Show("Status changed to " & newStatus, "Toggled", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadDocuments(txtSearch.Text.Trim(), cboSearchField.Text)
            ClearForm()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If currentID = 0 Then MessageBox.Show("Select a document to delete.", "No selection", MessageBoxButtons.OK, MessageBoxIcon.Warning) : Return
        If MessageBox.Show("Are you sure you want to delete/deactivate this document?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> DialogResult.Yes Then Return
        Try
            Using conn As MySqlConnection = dbConnection.GetConnection()
                conn.Open()
                Using cmd As New MySqlCommand("DELETE FROM tbldocuments WHERE DocumentID=@id", conn)
                    cmd.Parameters.AddWithValue("@id", currentID)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            MessageBox.Show("Deleted.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
            LoadDocuments(txtSearch.Text.Trim(), cboSearchField.Text)
            ClearForm()
        Catch ex As MySqlException
            If ex.Number = 1451 Then
                MessageBox.Show("Cannot delete: document is used in requests. Deactivate instead.", "In use", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                MessageBox.Show("Error: " & ex.Message)
            End If
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearForm()
    End Sub

    Private Sub ClearForm()
        txtDocName.Clear()
        txtDescription.Clear()
        txtFee.Clear()
        cboStatus.SelectedIndex = 0
        lblDocID.Text = "ID: (new)"
        isEditing = False
        currentID = 0
        btnAdd.Text = "Add"
        btnToggle.Enabled = False
        btnDelete.Enabled = False
        txtDocName.Focus()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        LoadDocuments(txtSearch.Text.Trim(), cboSearchField.Text)
    End Sub

    Private Sub txtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then btnSearch.PerformClick() : e.SuppressKeyPress = True
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        txtSearch.Clear()
        cboSearchField.SelectedIndex = 0
        LoadDocuments()
        ClearForm()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class
