Imports MySql.Data.MySqlClient

Public Class frmStudentPicker
    Public SelectedStudentID As String = ""

    Public Sub New(matches As DataTable)
        InitializeComponent()
        dgvStudents.DataSource = matches
        FormatGrid()
        lblCount.Text = matches.Rows.Count & " match(es) - double-click to select"
    End Sub

    Private Sub FormatGrid()
        If dgvStudents.Columns.Count = 0 Then Return
        If dgvStudents.Columns.Contains("StudentID") Then dgvStudents.Columns("StudentID").HeaderText = "Student ID"
        If dgvStudents.Columns.Contains("LRN") Then dgvStudents.Columns("LRN").HeaderText = "LRN"
        If dgvStudents.Columns.Contains("LastName") Then dgvStudents.Columns("LastName").HeaderText = "Last Name"
        If dgvStudents.Columns.Contains("FirstName") Then dgvStudents.Columns("FirstName").HeaderText = "First Name"
        If dgvStudents.Columns.Contains("MiddleName") Then dgvStudents.Columns("MiddleName").HeaderText = "Middle"
        If dgvStudents.Columns.Contains("Course") Then dgvStudents.Columns("Course").HeaderText = "Course"
        If dgvStudents.Columns.Contains("YearLevel") Then dgvStudents.Columns("YearLevel").HeaderText = "Year"
        If dgvStudents.Columns.Contains("Section") Then dgvStudents.Columns("Section").HeaderText = "Section"
        If dgvStudents.Columns.Contains("ContactNo") Then dgvStudents.Columns("ContactNo").HeaderText = "Contact"
        If dgvStudents.Columns.Contains("Status") Then dgvStudents.Columns("Status").HeaderText = "Status"
        dgvStudents.AllowUserToResizeColumns = True
        dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        dgvStudents.ScrollBars = ScrollBars.Both
        SetWidth("StudentID", 100)
        SetWidth("LRN", 110)
        SetWidth("LastName", 120)
        SetWidth("FirstName", 100)
        SetWidth("MiddleName", 90)
        SetWidth("Course", 70)
        SetWidth("YearLevel", 80)
        SetWidth("Section", 80)
        SetWidth("ContactNo", 110)
        SetWidth("Status", 80)
    End Sub

    Private Sub SetWidth(colName As String, w As Integer)
        If dgvStudents.Columns.Contains(colName) Then
            dgvStudents.Columns(colName).Width = w
            dgvStudents.Columns(colName).MinimumWidth = 50
        End If
    End Sub

    Private Sub PickSelected()
        If dgvStudents.CurrentRow Is Nothing OrElse dgvStudents.CurrentRow.IsNewRow Then
            MessageBox.Show("Select a student first.", "No selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        SelectedStudentID = dgvStudents.CurrentRow.Cells("StudentID").Value.ToString()
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        PickSelected()
    End Sub

    Private Sub dgvStudents_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvStudents.CellDoubleClick
        If e.RowIndex >= 0 Then PickSelected()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class
