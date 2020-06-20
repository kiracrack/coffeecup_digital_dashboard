Imports MySql.Data.MySqlClient
Imports System.IO

Public Class frmSetPermission

    Private Sub frmSetPermission_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadXgridLookupSearch("select authcode, authdescription as 'Select' from tbluserauthority", "tbluserauthority", txtPermission, gridPermission, Me)
        gridPermission.Columns("authcode").Visible = False
    End Sub

    Public Function LoadXgridLookupSearch(ByVal qry As String, ByVal tbl As String, ByVal Xglue As DevExpress.XtraEditors.SearchLookUpEdit, ByVal xgrid As DevExpress.XtraGrid.Views.Grid.GridView, ByVal myform As DevExpress.XtraEditors.XtraForm)
        Try
            Dim dst As New DataSet : dst.Clear()
            msda = New MySql.Data.MySqlClient.MySqlDataAdapter(qry, conn)
            msda.Fill(dst, tbl)
            Xglue.Properties.DataSource = dst.Tables(tbl)
            xgrid.PopulateColumns(dst.Tables(tbl))
            Xglue.Properties.View.BestFitColumns()
            xgrid.UserCellPadding = New Padding(1.7)
            Xglue.ForceInitialize()
            If xgrid.RowCount > 0 Then
                xgrid.BestFitColumns()
            End If

        Catch errMYSQL As MySqlException
            MessageBox.Show("Form:" & myform.Name & vbCrLf _
                             & "Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMYSQL.Message & vbCrLf _
                             & "Details:" & errMYSQL.StackTrace, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch errMS As Exception
            MessageBox.Show("Form:" & myform.Name & vbCrLf _
                             & "Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMS.Message & vbCrLf _
                             & "Details:" & errMS.StackTrace, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return 0
    End Function

    'Private Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
    '    Dim detailsFile As StreamWriter = Nothing
    '    If System.IO.File.Exists(System_config) = True Then
    '        System.IO.File.Delete(System_config)
    '    End If
    '    detailsFile = Nothing
    '    detailsFile = New StreamWriter(System_config, True)
    '    detailsFile.WriteLine(EncryptTripleDES(txtPermission.Properties.View.GetFocusedRowCellValue("authcode").ToString()))
    '    detailsFile.Close()
    '    MessageBox.Show("Permission successfully save! please restart your system", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    End
    'End Sub
End Class