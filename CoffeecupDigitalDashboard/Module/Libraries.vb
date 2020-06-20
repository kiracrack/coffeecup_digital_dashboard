Imports MySql.Data.MySqlClient
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.Utils
Imports System.IO
Imports System.Drawing.Imaging
Imports DevExpress.XtraSplashScreen
Imports System.Security.Cryptography
Imports System.Text
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Collections
Imports DevExpress.XtraEditors.Repository

Module Libraries
    Public bmpScreenShot As Bitmap
    Public gfxScreenshot As Graphics
    Public initialID As String = ""
    Public myID As String = ""
    Public globaldate As String
    Public removechar As Char() = "\".ToCharArray()
    Public sb As New System.Text.StringBuilder
    Public MemoEdit As New DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit
    Public SpinEdit As New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Public ImageColumn As New DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit

    Public ComboBoxEdit As New DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Public colImageEdit As New DevExpress.XtraEditors.Repository.RepositoryItemImageEdit
    Public globaltheme As String = "Visual Studio 2013 Dark"
    Public TargetFile As String
    Public ico As Icon

    Public imgBytes As Byte() = Nothing
    Public stream As MemoryStream = Nothing
    Public img As Image = Nothing
    Public sqlcmd As New MySqlCommand
    Public sql As String
    Public arrImage() As Byte = Nothing

    Public Function LoadToComboBox(ByVal fld As String, ByVal tbl As String, ByVal combo As DevExpress.XtraEditors.ComboBoxEdit, ByVal mode As Boolean)
        Dim Coll As ComboBoxItemCollection = combo.Properties.Items
        Try
            If mode = True Then
                Coll.Clear()
                com.CommandText = "Select distinct(" & fld & ") from " & tbl & " order by " & fld & " asc"
                rst = com.ExecuteReader
                Coll.BeginUpdate()
                Try
                    While rst.Read
                        Coll.Add(rst(fld))
                    End While
                    rst.Close()
                Finally
                    Coll.EndUpdate()
                End Try
            End If
        Catch errMYSQL As MySqlException
            XtraMessageBox.Show("Message:" & errMYSQL.Message & vbCrLf _
                             & "Details:" & errMYSQL.StackTrace, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch errMS As Exception
            XtraMessageBox.Show("Message:" & errMS.Message & vbCrLf _
                             & "Details:" & errMS.StackTrace, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        Return Coll
    End Function
    Public Function LoadToComboBoxQuery(ByVal fld As String, ByVal fquery As String, ByVal tblandQuery As String, ByVal combo As DevExpress.XtraEditors.ComboBoxEdit)
        Dim Coll As ComboBoxItemCollection = combo.Properties.Items
        Try
            Coll.Clear()
            com.CommandText = "Select " & fquery & " from " & tblandQuery
            rst = com.ExecuteReader
            Coll.BeginUpdate()
            Try
                While rst.Read
                    Coll.Add(rst(fld))
                End While
                rst.Close()
            Finally
                Coll.EndUpdate()
            End Try
        Catch errMYSQL As MySqlException
            XtraMessageBox.Show("Message:" & errMYSQL.Message & vbCrLf _
                             & "Details:" & errMYSQL.StackTrace, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch errMS As Exception
            XtraMessageBox.Show("Message:" & errMS.Message & vbCrLf _
                             & "Details:" & errMS.StackTrace, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        Return Coll
    End Function

    Public Function LoadXgrid(ByVal qry As String, ByVal tbl As String, ByVal Em As DevExpress.XtraGrid.GridControl, ByVal xgrid As DevExpress.XtraGrid.Views.Grid.GridView, ByVal fontsize As Integer, ByVal myform As DevExpress.XtraEditors.XtraForm)
        Try
            Dim dst = New DataSet : dst.Clear()
            xgrid.ClearGrouping()
            Em.DataSource = Nothing
            msda = New MySqlDataAdapter(qry, conn)
            msda.SelectCommand.CommandTimeout = 600000
            msda.Fill(dst, tbl)
            Em.DataSource = dst.Tables(tbl)
            xgrid.PopulateColumns(dst.Tables(tbl))
            Em.ForceInitialize()
            xgrid.BestFitColumns()
            If fontsize > 0 Then
                xgrid.Appearance.Row.FontSizeDelta = fontsize
            End If
            xgrid.UserCellPadding = New Padding(10)

        Catch errMYSQL As MySqlException
            XtraMessageBox.Show("Module: " & myform.Text & vbCrLf _
                             & "Message: " & errMYSQL.Message & vbCrLf _
                             & "Details: " & errMYSQL.StackTrace & Environment.NewLine _
                             & "Error Code: " & errMYSQL.ErrorCode, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        Return 0
    End Function
    Public Function LoadXgridNoPaint(ByVal qry As String, ByVal tbl As String, ByVal Em As DevExpress.XtraGrid.GridControl, ByVal xgrid As DevExpress.XtraGrid.Views.Grid.GridView, ByVal myform As DevExpress.XtraEditors.XtraForm)
        Try
            Dim dst = New DataSet : dst.Clear()
            xgrid.ClearGrouping()
            Em.DataSource = Nothing
            msda = New MySqlDataAdapter(qry, conn)
            msda.SelectCommand.CommandTimeout = 600000
            msda.Fill(dst, tbl)
            Em.DataSource = dst.Tables(tbl)
            xgrid.PopulateColumns(dst.Tables(tbl))
            Em.ForceInitialize()
            xgrid.BestFitColumns()

            xgrid.UserCellPadding = New Padding(1.7)
        Catch errMYSQL As MySqlException
            XtraMessageBox.Show("Module: " & myform.Text & vbCrLf _
                             & "Message: " & errMYSQL.Message & vbCrLf _
                             & "Details: " & errMYSQL.StackTrace & Environment.NewLine _
                             & "Error Code: " & errMYSQL.ErrorCode, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        Return 0
    End Function
    Public Function LoadXgridLookupEdit(ByVal qry As String, ByVal tbl As String, ByVal Xglue As DevExpress.XtraEditors.GridLookUpEdit, ByVal xgrid As DevExpress.XtraGrid.Views.Grid.GridView, ByVal myform As DevExpress.XtraEditors.XtraForm)
        Try
            Dim dst As New DataSet : dst.Clear()
            msda = New MySql.Data.MySqlClient.MySqlDataAdapter(qry, conn)
            msda.Fill(dst, tbl)
            Xglue.Properties.DataSource = dst.Tables(tbl)
            xgrid.PopulateColumns(dst.Tables(tbl))
            Xglue.Properties.View.BestFitColumns()
            Xglue.ForceInitialize()
            xgrid.BestFitColumns()
            xgrid.UserCellPadding = New Padding(1.7)
        Catch errMYSQL As MySqlException
            XtraMessageBox.Show("Form:" & myform.Name & vbCrLf _
                             & "Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMYSQL.Message & vbCrLf _
                             & "Details:" & errMYSQL.StackTrace, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch errMS As Exception
            XtraMessageBox.Show("Form:" & myform.Name & vbCrLf _
                             & "Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMS.Message & vbCrLf _
                             & "Details:" & errMS.StackTrace, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        Return 0
    End Function
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
            xgrid.UserCellPadding = New Padding(1.7)
        Catch errMYSQL As MySqlException
            XtraMessageBox.Show("Form:" & myform.Name & vbCrLf _
                             & "Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMYSQL.Message & vbCrLf _
                             & "Details:" & errMYSQL.StackTrace, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch errMS As Exception
            XtraMessageBox.Show("Form:" & myform.Name & vbCrLf _
                             & "Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMS.Message & vbCrLf _
                             & "Details:" & errMS.StackTrace, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        Return 0
    End Function

    Public Function XgridColCurrencyDecimalCount(ByVal column As Array, ByVal decimalplaces As Integer, ByVal xgrid As DevExpress.XtraGrid.Views.Grid.GridView)
        Try
            For Each col As String In column
                If col <> "" Then
                    For I = 0 To xgrid.Columns.Count - 1
                        If col = xgrid.Columns(I).FieldName Then
                            xgrid.Columns(col).DisplayFormat.FormatType = FormatType.Numeric
                            xgrid.Columns(col).DisplayFormat.FormatString = "n" & decimalplaces
                            xgrid.Columns(col).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                        End If
                    Next


                End If
            Next
        Catch errMS As Exception
            XtraMessageBox.Show("Message:" & errMS.Message & vbCrLf _
                             & "Details:" & errMS.StackTrace, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        Return 0
    End Function
    Public Function XgridColCurrency(ByVal column As Array, ByVal xgrid As DevExpress.XtraGrid.Views.Grid.GridView)
        Try
            For Each col As String In column
                If col <> "" Then
                    For I = 0 To xgrid.Columns.Count - 1
                        If col = xgrid.Columns(I).FieldName Then
                            xgrid.Columns(col).DisplayFormat.FormatType = FormatType.Numeric
                            xgrid.Columns(col).DisplayFormat.FormatString = "n"
                            xgrid.Columns(col).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                        End If
                    Next


                End If
            Next
        Catch errMS As Exception
            XtraMessageBox.Show("Message:" & errMS.Message & vbCrLf _
                             & "Details:" & errMS.StackTrace, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        Return 0
    End Function
    Public Function XgridColWrapText(ByVal column As Array, ByVal xgrid As DevExpress.XtraGrid.Views.Grid.GridView)
        Try
            For Each col As String In column
                If col <> "" Then
                    For I = 0 To xgrid.Columns.Count - 1
                        If col = xgrid.Columns(I).FieldName Then
                            xgrid.Columns(col).ColumnEdit = MemoEdit
                        End If
                    Next


                End If
            Next
        Catch errMS As Exception
            XtraMessageBox.Show("Message:" & errMS.Message & vbCrLf _
                             & "Details:" & errMS.StackTrace, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        Return 0
    End Function
    Public Function XgridColAlign(ByVal column As Array, ByVal xgrid As DevExpress.XtraGrid.Views.Grid.GridView, ByVal algn As DevExpress.Utils.HorzAlignment)
        Try
            For Each col As String In column
                If col <> "" Then
                    For I = 0 To xgrid.Columns.Count - 1
                        If col = xgrid.Columns(I).FieldName Then
                            xgrid.Columns(col).AppearanceCell.TextOptions.HAlignment = algn
                            xgrid.Columns(col).AppearanceHeader.TextOptions.HAlignment = algn
                        End If
                    Next
                End If
            Next

        Catch errMS As Exception
            XtraMessageBox.Show("Message:" & errMS.Message & vbCrLf _
                             & "Details:" & errMS.StackTrace, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        Return 0
    End Function
    Public Function GridHideColumn(ByVal grdView As DataGridView, ByVal column As Array) As DataGridView
        For Each valueArr As String In column
            For i = 0 To grdView.ColumnCount - 1
                If valueArr = grdView.Columns(i).Name Then
                    grdView.Columns(i).Visible = False
                End If
            Next
        Next
        Return grdView
    End Function
    Public Function XgridAllowColumnEdit(ByVal column As Array, ByVal xgrid As DevExpress.XtraGrid.Views.Grid.GridView, ByVal allowedit As Boolean)
        Try
            For Each col As String In column
                xgrid.Columns(col).OptionsColumn.AllowEdit = allowedit
            Next
        Catch errMS As Exception
            XtraMessageBox.Show("Message:" & errMS.Message & vbCrLf _
                             & "Details:" & errMS.StackTrace, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        Return 0
    End Function
    Public Function XgridColWidth(ByVal column As Array, ByVal xgrid As DevExpress.XtraGrid.Views.Grid.GridView, ByVal size As Integer)
        Try
            For Each col As String In column
                If col <> "" Then
                    For I = 0 To xgrid.Columns.Count - 1
                        If col = xgrid.Columns(I).FieldName Then
                            xgrid.Columns(col).Width = size
                        End If
                    Next
                End If
            Next

        Catch errMS As Exception
            XtraMessageBox.Show("Message:" & errMS.Message & vbCrLf _
                             & "Details:" & errMS.StackTrace, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        Return 0
    End Function

    Public Function XgridDisableColumn(ByVal column As Array, ByVal xgrid As DevExpress.XtraGrid.Views.Grid.GridView, ByVal WrapText As Boolean)
        Try
            For Each col As String In column
                If col <> "" Then
                    For I = 0 To xgrid.Columns.Count - 1
                        If col = xgrid.Columns(I).FieldName Then

                            xgrid.Columns(col).OptionsColumn.AllowEdit = False
                            xgrid.Columns(col).OptionsColumn.AllowFocus = False
                            If WrapText = True Then
                                xgrid.Columns(col).AppearanceCell.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
                                xgrid.Columns(col).ColumnEdit = MemoEdit
                            End If

                        End If
                    Next
                End If
            Next

        Catch errMS As Exception
            XtraMessageBox.Show("Message:" & errMS.Message & vbCrLf _
                             & "Details:" & errMS.StackTrace, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        Return 0
    End Function
    Public Function XgridGeneralSummaryCurrency(ByVal column As Array, ByVal xgrid As DevExpress.XtraGrid.Views.Grid.GridView)
        Try
            For Each col As String In column
                If col <> "" Then
                    For I = 0 To xgrid.Columns.Count - 1
                        If col = xgrid.Columns(I).FieldName Then
                            xgrid.Columns(col).Summary.Clear()
                            xgrid.Columns(col).Summary.Add(DevExpress.Data.SummaryItemType.Sum, col, "{0:n}")
                            CType(xgrid.Columns(col).View, GridView).OptionsView.ShowFooter = True
                        End If
                    Next
                End If
            Next

            xgrid.Appearance.FooterPanel.FontSizeDelta = xgrid.Appearance.Row.FontSizeDelta
            xgrid.Appearance.GroupFooter.FontSizeDelta = xgrid.Appearance.Row.FontSizeDelta
        Catch errMS As Exception
            XtraMessageBox.Show("Message:" & errMS.Message & vbCrLf _
                             & "Details:" & errMS.StackTrace, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        Return 0
    End Function
    Public Function XgridGeneralSummaryNumber(ByVal column As Array, ByVal xgrid As DevExpress.XtraGrid.Views.Grid.GridView)
        Try
            For Each col As String In column
                If col <> "" Then
                    For I = 0 To xgrid.Columns.Count - 1
                        If col = xgrid.Columns(I).FieldName Then
                            xgrid.Columns(col).Summary.Clear()
                            xgrid.Columns(col).Summary.Add(DevExpress.Data.SummaryItemType.Sum, col, "{0:n0}")
                            CType(xgrid.Columns(col).View, GridView).OptionsView.ShowFooter = True
                        End If
                    Next
                End If
            Next
            xgrid.Appearance.FooterPanel.FontSizeDelta = xgrid.Appearance.Row.FontSizeDelta
            xgrid.Appearance.GroupFooter.FontSizeDelta = xgrid.Appearance.Row.FontSizeDelta
        Catch errMS As Exception
            XtraMessageBox.Show("Message:" & errMS.Message & vbCrLf _
                             & "Details:" & errMS.StackTrace, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        Return 0
    End Function
    Public Function XgridGroupSummaryCurrency(ByVal column As Array, ByVal xgrid As DevExpress.XtraGrid.Views.Grid.GridView)
        Try
            For Each col As String In column
                xgrid.GroupSummary.Clear()
                If col <> "" Then
                    For I = 0 To xgrid.Columns.Count - 1
                        If col = xgrid.Columns(I).FieldName Then
                            Dim item As New GridGroupSummaryItem()
                            item.FieldName = col
                            item.SummaryType = DevExpress.Data.SummaryItemType.Sum
                            item.DisplayFormat = "{0:n}"
                            item.ShowInGroupColumnFooter = xgrid.Columns(col)
                            xgrid.GroupSummary.Add(item)
                        End If
                    Next
                End If
            Next
        Catch errMS As Exception
            XtraMessageBox.Show("Message:" & errMS.Message & vbCrLf _
                             & "Details:" & errMS.StackTrace, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        Return 0
    End Function
    Public Function XgridHideColumn(ByVal column As Array, ByVal xgrid As DevExpress.XtraGrid.Views.Grid.GridView)
        Try
            For Each col As String In column
                If col <> "" Then
                    For I = 0 To xgrid.Columns.Count - 1
                        If col = xgrid.Columns(I).FieldName Then
                            xgrid.Columns(col).Visible = False
                        End If
                    Next
                End If
            Next
        Catch errMS As Exception
            XtraMessageBox.Show("Message:" & errMS.Message & vbCrLf _
                             & "Details:" & errMS.StackTrace, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        Return 0
    End Function
    Public Function XgriDisableColumn(ByVal column As Array, ByVal xgrid As DevExpress.XtraGrid.Views.Grid.GridView)
        Try
            For Each col As String In column
                For I = 0 To xgrid.Columns.Count - 1
                    If col = xgrid.Columns(I).FieldName Then
                        xgrid.Columns(col).OptionsColumn.AllowEdit = False
                    End If
                Next
            Next
        Catch errMS As Exception
            XtraMessageBox.Show("Message:" & errMS.Message & vbCrLf _
                             & "Details:" & errMS.StackTrace, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        Return 0
    End Function
    Public Sub UpdateGridColumnSetting(ByVal formname As String, ByVal gv As GridView)
        com.CommandText = "delete from tblcolumnindex where form='" & formname & "' and gridview='" & gv.Name & "'" : com.ExecuteNonQuery()
        For I = 0 To gv.Columns.Count - 1
            If gv.Columns(I).VisibleIndex >= 0 Then
                com.CommandText = "insert into tblcolumnindex set form='" & formname & "', gridview='" & gv.Name & "', columnname='" & gv.Columns(I).FieldName & "',columnwidth='" & gv.Columns(I).Width & "', colindex='" & gv.Columns(I).VisibleIndex & "'" : com.ExecuteNonQuery()
            End If
        Next
    End Sub
    Public Sub RemoveSpecialChar(ByVal panel As DevExpress.XtraEditors.PanelControl)
        Dim Ctl As Control
        Try
            For Each Ctl In panel.Controls
                If TypeOf Ctl Is DevExpress.XtraEditors.TextEdit Or TypeOf Ctl Is DevExpress.XtraEditors.ComboBoxEdit Or TypeOf Ctl Is DevExpress.XtraEditors.MemoEdit Then
                    Ctl.Text = Ctl.Text.Replace("'", "''")
                    Ctl.Text = Ctl.Text.Replace("\", "\\")
                End If
            Next Ctl
        Catch errMS As Exception
            XtraMessageBox.Show("Message:" & errMS.Message & vbCrLf _
                             & "Details:" & errMS.StackTrace, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
    Public Function CheckSelectedRow(ByVal col As String, ByVal Xgrid As DevExpress.XtraGrid.Views.Grid.GridView) As Boolean
        Try
            If Xgrid.GetFocusedRowCellValue(col).ToString = "" Then
                XtraMessageBox.Show("There is no item selected! make sure, the selection is on the list", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
                CheckSelectedRow = False
            Else
                CheckSelectedRow = True
            End If
        Catch errMS As Exception
            XtraMessageBox.Show("There is no item selected! make sure, the selection is on the list", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            CheckSelectedRow = False

        End Try
    End Function
    Public Function RemovedNoValueColumn(ByVal col As String, ByVal Xgrid As DevExpress.XtraGrid.Views.Grid.GridView, ByVal myform As DevExpress.XtraEditors.XtraForm)
        Try
            Dim removeColumn As Boolean = True
            For I = 0 To Xgrid.RowCount - 1
                If Xgrid.GetRowCellValue(I, col) <> "" Then
                    removeColumn = False
                End If
            Next
            If removeColumn = True Then
                Xgrid.Columns(col).Visible = False
            End If
        Catch errMYSQL As MySqlException
            XtraMessageBox.Show("Form:" & myform.Name & vbCrLf _
                             & "Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMYSQL.Message & vbCrLf _
                             & "Details:" & errMYSQL.StackTrace, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch errMS As Exception
            XtraMessageBox.Show("Form:" & myform.Name & vbCrLf _
                             & "Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMS.Message & vbCrLf _
                             & "Details:" & errMS.StackTrace, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        Return 0
    End Function
    Public Function DeleteRow(ByVal col As String, ByVal fld As String, ByVal tbl As String, ByVal Xgrid As DevExpress.XtraGrid.Views.Grid.GridView, ByVal myform As DevExpress.XtraEditors.XtraForm)
        Try
            Dim Row As DataRow : Dim Rows() As DataRow : Dim I As Integer : Dim todelete As String = ""
            ReDim Rows(Xgrid.SelectedRowsCount - 1)
            For I = 0 To Xgrid.SelectedRowsCount - 1
                Rows(I) = Xgrid.GetDataRow(Xgrid.GetSelectedRows(I))
                todelete = Xgrid.GetRowCellValue(Xgrid.GetSelectedRows(I), col)
                com.CommandText = "DELETE from " & tbl & " where " & fld & "='" & todelete & "'"
                rst = com.ExecuteReader() : rst.Close()
            Next
            For Each Row In Rows
                Row.Delete()
            Next
        Catch errMYSQL As MySqlException
            XtraMessageBox.Show("Form:" & myform.Name & vbCrLf _
                             & "Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMYSQL.Message & vbCrLf _
                             & "Details:" & errMYSQL.StackTrace, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch errMS As Exception
            XtraMessageBox.Show("Form:" & myform.Name & vbCrLf _
                             & "Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMS.Message & vbCrLf _
                             & "Details:" & errMS.StackTrace, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        Return 0
    End Function

    Public Function ResizeImage(ByVal img As DevExpress.XtraEditors.PictureEdit, ByVal imgsize As Integer, ByVal myform As DevExpress.XtraEditors.XtraForm)
        Try
            If Not img.Image Is Nothing Then
                Dim Original As New Bitmap(img.Image)
                img.Image = Original

                Dim m As Int32 = imgsize
                Dim n As Int32 = m * Original.Height / Original.Width

                Dim Thumb As New Bitmap(m, n, Original.PixelFormat)
                Thumb.SetResolution(Original.HorizontalResolution, Original.VerticalResolution)

                Dim g As Graphics = Graphics.FromImage(Thumb)
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High

                g.DrawImage(Original, New Rectangle(0, 0, m, n))
                img.Image = Thumb
            End If
        Catch errMYSQL As MySqlException
            XtraMessageBox.Show("Form:" & myform.Name & vbCrLf _
                             & "Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMYSQL.Message & vbCrLf _
                             & "Details:" & errMYSQL.StackTrace, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch errMS As Exception
            XtraMessageBox.Show("Form:" & myform.Name & vbCrLf _
                             & "Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMS.Message & vbCrLf _
                             & "Details:" & errMS.StackTrace, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        Return 0
    End Function

    Public Sub ResizeImage(ByVal PictureEdit1 As PictureEdit, ByVal size As Double)
        If PictureEdit1.Image Is Nothing Then Exit Sub
        Dim Original As New Bitmap(PictureEdit1.Image)
        PictureEdit1.Image = Original

        Dim m As Int32 = size
        Dim n As Int32 = m * Original.Height / Original.Width

        Dim Thumb As New Bitmap(m, n, Original.PixelFormat)
        Thumb.SetResolution(Original.HorizontalResolution, Original.VerticalResolution)

        Dim g As Graphics = Graphics.FromImage(Thumb)
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High

        g.DrawImage(Original, New Rectangle(0, 0, m, n))
        PictureEdit1.Image = Thumb
    End Sub

    Public Function UpdateImage(ByVal qry As String, ByVal fld As String, ByVal tbl As String, ByVal Ximg As DevExpress.XtraEditors.PictureEdit, ByVal myform As DevExpress.XtraEditors.XtraForm)
        arrImage = Nothing
        sqlcmd.Dispose()
        Try
            If Not Ximg.Image Is Nothing Then
                Dim mstream As New System.IO.MemoryStream()
                Ximg.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Png)
                arrImage = mstream.GetBuffer()
                mstream.Close()
            End If

            If countqry(tbl, qry) = 0 Then
                sql = "insert into " & tbl & " set " & fld & " = @file, " & qry
            Else
                sql = "Update " & tbl & " set " & fld & " = @file where " & qry
            End If

            With sqlcmd
                .CommandText = sql
                .Connection = conn
                .Parameters.AddWithValue("@file", arrImage)
                .ExecuteNonQuery()
            End With
            sqlcmd.Parameters.Clear()

        Catch errMYSQL As MySqlException
            XtraMessageBox.Show("Form:" & myform.Name & vbCrLf _
                             & "Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMYSQL.Message & vbCrLf _
                             & "Details:" & errMYSQL.StackTrace, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch errMS As Exception
            XtraMessageBox.Show("Form:" & myform.Name & vbCrLf _
                             & "Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMS.Message & vbCrLf _
                             & "Details:" & errMS.StackTrace, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        Return 0
    End Function

    Public Function UpdateImage2(ByVal qry As String, ByVal otherfield As String, ByVal fld As String, ByVal tbl As String, ByVal Ximg As DevExpress.XtraEditors.PictureEdit, ByVal myform As DevExpress.XtraEditors.XtraForm)
        arrImage = Nothing
        sqlcmd.Dispose()
        Try
            If Not Ximg.Image Is Nothing Then
                Dim mstream As New System.IO.MemoryStream()
                Ximg.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Png)
                arrImage = mstream.GetBuffer()
                mstream.Close()
            End If

            If countqry(tbl, qry) = 0 Then
                sql = "insert into " & tbl & " set " & fld & " = @file " & otherfield
            Else
                sql = "Update " & tbl & " set " & fld & " = @file " & otherfield & " where " & qry
            End If

            With sqlcmd
                .CommandText = sql
                .Connection = conn
                .Parameters.AddWithValue("@file", arrImage)
                .ExecuteNonQuery()
            End With
            sqlcmd.Parameters.Clear()

        Catch errMYSQL As MySqlException
            XtraMessageBox.Show("Form:" & myform.Name & vbCrLf _
                             & "Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMYSQL.Message & vbCrLf _
                             & "Details:" & errMYSQL.StackTrace, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch errMS As Exception
            XtraMessageBox.Show("Form:" & myform.Name & vbCrLf _
                             & "Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMS.Message & vbCrLf _
                             & "Details:" & errMS.StackTrace, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        Return 0
    End Function
    Public Function InsertImage(ByVal fld As String, ByVal otherField As String, ByVal tbl As String, ByVal Ximg As DevExpress.XtraEditors.PictureEdit, ByVal myform As DevExpress.XtraEditors.XtraForm)
        arrImage = Nothing
        Try
            If Not Ximg.Image Is Nothing Then
                Dim mstream As New System.IO.MemoryStream()
                Ximg.Image.Save(mstream, System.Drawing.Imaging.ImageFormat.Png)
                arrImage = mstream.GetBuffer()
                mstream.Close()
            End If

            sql = "Insert into " & tbl & " set " & fld & " = @file " & otherField

            With sqlcmd
                .CommandText = sql
                .Connection = conn
                .Parameters.AddWithValue("@file", arrImage)
                .ExecuteNonQuery()
            End With
            sqlcmd.Parameters.Clear()

        Catch errMYSQL As MySqlException
            XtraMessageBox.Show("Form:" & myform.Name & vbCrLf _
                             & "Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMYSQL.Message & vbCrLf _
                             & "Details:" & errMYSQL.StackTrace, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch errMS As Exception
            XtraMessageBox.Show("Form:" & myform.Name & vbCrLf _
                             & "Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMS.Message & vbCrLf _
                             & "Details:" & errMS.StackTrace, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        Return 0
    End Function



    Public Function UpdateIcon(ByVal qry As String, ByVal fld As String, ByVal tbl As String, ByVal format As System.Drawing.Imaging.ImageFormat, ByVal Ximg As DevExpress.XtraEditors.PictureEdit, ByVal myform As DevExpress.XtraEditors.XtraForm)
        arrImage = Nothing
        Try
            If Not Ximg.Image Is Nothing Then
                Dim mstream As New System.IO.MemoryStream()
                Ximg.Image.Save(mstream, format)
                arrImage = mstream.GetBuffer()
                mstream.Close()
            End If

            sql = "Update " & tbl & " set " & fld & " = @file where " & qry

            With sqlcmd
                .CommandText = sql
                .Connection = conn
                .Parameters.AddWithValue("@file", arrImage)
                .ExecuteNonQuery()
            End With
            sqlcmd.Parameters.Clear()

        Catch errMYSQL As MySqlException
            XtraMessageBox.Show("Form:" & myform.Name & vbCrLf _
                             & "Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMYSQL.Message & vbCrLf _
                             & "Details:" & errMYSQL.StackTrace, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch errMS As Exception
            XtraMessageBox.Show("Form:" & myform.Name & vbCrLf _
                             & "Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMS.Message & vbCrLf _
                             & "Details:" & errMS.StackTrace, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        Return 0
    End Function

    Public Function ShowImage(ByVal fld As String, ByVal Ximg As DevExpress.XtraEditors.PictureEdit, ByVal myform As DevExpress.XtraEditors.XtraForm)
        Try
            If rst(fld).ToString <> "" Then
                imgBytes = CType(rst(fld), Byte())
                stream = New MemoryStream(imgBytes, 0, imgBytes.Length)
                img = Image.FromStream(stream)
                Ximg.Image = img
            End If
        Catch errMYSQL As MySqlException
            XtraMessageBox.Show("Form:" & myform.Name & vbCrLf _
                             & "Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMYSQL.Message & vbCrLf _
                             & "Details:" & errMYSQL.StackTrace, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch errMS As Exception
            XtraMessageBox.Show("Form:" & myform.Name & vbCrLf _
                             & "Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMS.Message & vbCrLf _
                             & "Details:" & errMS.StackTrace, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        Return 0
    End Function

    Public Function ShowReportSignature(ByVal userid As String, ByVal Ximg As DevExpress.XtraReports.UI.XRPictureBox)
        Try
            com.CommandText = "select * from tblaccounts where accountid ='" & userid & "'" : rst = com.ExecuteReader
            While rst.Read
                If rst("digitalsign").ToString <> "" Then
                    imgBytes = CType(rst("digitalsign"), Byte())
                    stream = New MemoryStream(imgBytes, 0, imgBytes.Length)
                    img = Image.FromStream(stream)
                    Ximg.Image = img
                End If
            End While
            rst.Close()

        Catch errMYSQL As MySqlException
            XtraMessageBox.Show("Message:" & errMYSQL.Message & vbCrLf _
                             & "Details:" & errMYSQL.StackTrace, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch errMS As Exception
            XtraMessageBox.Show("Message:" & errMS.Message & vbCrLf _
                             & "Details:" & errMS.StackTrace, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        Return 0
    End Function
    Public Function UpdateReportTitle(ByVal Title As String, ByVal customText As String, ByVal myform As DevExpress.XtraEditors.XtraForm)
        Try
            If countqry("tblreportsetting", "formname='" & myform.Name.ToString & "'") = 0 Then
                com.CommandText = "insert into tblreportsetting set formname='" & myform.Name.ToString & "',title='" & Title & "', customtext='" & customText & "'" : com.ExecuteNonQuery()
            Else
                com.CommandText = "update tblreportsetting set title='" & Title & "', customtext='" & customText & "' where formname='" & myform.Name.ToString & "' " : com.ExecuteNonQuery()
            End If
        Catch errMYSQL As MySqlException
            XtraMessageBox.Show("Form:" & myform.Name & vbCrLf _
                             & "Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMYSQL.Message & vbCrLf _
                             & "Details:" & errMYSQL.StackTrace, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch errMS As Exception
            XtraMessageBox.Show("Form:" & myform.Name & vbCrLf _
                             & "Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMS.Message & vbCrLf _
                             & "Details:" & errMS.StackTrace, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        Return 0
    End Function
    Public Sub AddRowXgrid(ByVal View As DevExpress.XtraGrid.Views.Grid.GridView)
        Try
            Dim currentRow As Integer
            currentRow = View.FocusedRowHandle
            If currentRow < 0 Then
                currentRow = View.GetDataRowHandleByGroupRowHandle(currentRow)
            End If
            View.AddNewRow()
        Catch errMYSQL As MySqlException
            XtraMessageBox.Show("Message:" & errMYSQL.Message & vbCrLf _
                             & "Details:" & errMYSQL.StackTrace, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch errMS As Exception
            XtraMessageBox.Show("Message:" & errMS.Message & vbCrLf _
                             & "Details:" & errMS.StackTrace, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

    Public Function qrysingledata(ByVal field As String, ByVal fqry As String, ByVal addwhere As String, ByVal tbl As String)
        Dim def As String = ""
        Try
            If countrecord(tbl) = 0 Then
                def = ""
            Else
                com.CommandText = "select " & fqry & " from " & tbl & " " & addwhere : rst = com.ExecuteReader
                While rst.Read
                    def = rst(field).ToString
                End While
                rst.Close()
            End If
        Catch errMYSQL As MySqlException
            XtraMessageBox.Show("Message:" & errMYSQL.Message & vbCrLf _
                             & "Details:" & errMYSQL.StackTrace, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch errMS As Exception
            XtraMessageBox.Show("Message:" & errMS.Message & vbCrLf _
                             & "Details:" & errMS.StackTrace, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        Return def
    End Function
    Public Function qrysingledata(ByVal field As String, ByVal fqry As String, ByVal tblandqry As String)
        Dim def As String = ""
        com.CommandText = "select " & fqry & " from " & tblandqry : rst = com.ExecuteReader
        While rst.Read
            def = rst(field).ToString
        End While
        rst.Close()
        Return def
    End Function
    Public Function GetArrayList(ByVal field As String, ByVal fqry As String, ByVal tblandqry As String) As ArrayList
        com.CommandText = "select " & fqry & " from " & tblandqry : rst = com.ExecuteReader
        While rst.Read
            GetArrayList.Add(rst(field).ToString)
        End While
        rst.Close()
        Return GetArrayList
    End Function
    'Public Sub ReadFilterColumn(ByVal Xgrid As DevExpress.XtraGrid.Views.Grid.GridView, ByVal filterName As String)
    '    Dim colname As String = ""
    '    For I = 0 To Xgrid.Columns.Count - 1
    '        colname += Xgrid.Columns(I).FieldName & ","
    '    Next
    '    frmColumnFilter.txtColumn.Text = colname.Remove(colname.Count - 1, 1)
    '    frmColumnFilter.GetFilterInfo(Xgrid, filterName)
    '    frmColumnFilter.ShowDialog()
    '    SaveFilterColumn(Xgrid, filterName)
    'End Sub
    Public Sub SaveFilterColumn(ByVal Xgrid As DevExpress.XtraGrid.Views.Grid.GridView, ByVal filterName As String)
        Dim file_conn As String = Application.StartupPath.ToString & "\_config\" & filterName
        If System.IO.File.Exists(file_conn) = True Then
            Dim sr As StreamReader = File.OpenText(file_conn)
            Try
                Dim columnChoosed As String = sr.ReadLine()
                Dim cnt As Integer = 0

                For Each strresult In DecryptTripleDES(columnChoosed).Split(New Char() {","c})
                    If strresult = 0 Then
                        Xgrid.Columns(cnt).Visible = True
                    Else
                        Xgrid.Columns(cnt).Visible = False
                    End If
                    cnt = cnt + 1
                Next

                sr.Close()
            Catch errMS As Exception
                XtraMessageBox.Show("Message: Invalid column filter format! Please update your columns" & vbCrLf, _
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                sr.Close()
            End Try
        End If
    End Sub

    Public Function ConvertCurrencyToEnglish(ByVal MyNumber As Double) As String
        Dim finalword As String = ""
        Dim Temp As String
        Dim Dollars, Cents As String
        Dim DecimalPlace, Count As Integer
        Dim Place(9) As String
        Dim Numb As String
        Place(2) = " Thousand " : Place(3) = " Million " : Place(4) = "Billion " : Place(5) = " Trillion "
        ' Convert Numb to a string, trimming extra spaces.
        Numb = Trim(Str(MyNumber))
        ' Find decimal place.
        DecimalPlace = InStr(Numb, ".")
        ' If we find decimal place...
        If DecimalPlace > 0 Then
            ' Convert cents
            Temp = Left(Mid(Numb, DecimalPlace + 1) & "00", 2)
            Cents = ConvertTens(Temp)
            ' Strip off cents from remainder to convert.
            Numb = Trim(Left(Numb, DecimalPlace - 1))
        End If
        Count = 1
        Do While Numb <> ""
            ' Convert last 3 digits of Numb to English dollars.
            Temp = ConvertHundreds(Right(Numb, 3))
            If Temp <> "" Then Dollars = Temp & Place(Count) & Dollars
            If Len(Numb) > 3 Then
                ' Remove last 3 converted digits from Numb.
                Numb = Left(Numb, Len(Numb) - 3)
            Else
                Numb = ""
            End If
            Count = Count + 1
        Loop

        ' Clean up dollars.
        Select Case Dollars
            Case "" : Dollars = ""
            Case "One" : Dollars = "One Peso"
            Case Else : Dollars = Dollars & " Pesos"
        End Select

        ' Clean up cents.
        Select Case Cents
            Case "" : Cents = ""
            Case "One" : Cents = " And One Cent Only"
            Case Else : Cents = " And " & Cents & " Cents Only"
        End Select

        If Dollars & Cents <> "" Then
            ConvertCurrencyToEnglish = Dollars & If(Cents = "", " Only", Cents)
            finalword = ConvertCurrencyToEnglish
        End If
        Return finalword
    End Function

    Private Function ConvertHundreds(ByVal MyNumber As String) As String
        Dim Result As String
        ' Exit if there is nothing to convert.
        If Val(MyNumber) = 0 Then Exit Function
        ' Append leading zeros to number.
        MyNumber = Right("000" & MyNumber, 3)
        ' Do we have a hundreds place digit to convert?
        If Left(MyNumber, 1) <> "0" Then
            Result = ConvertDigit(Left(MyNumber, 1)) & " Hundred "
        End If
        ' Do we have a tens place digit to convert?
        If Mid(MyNumber, 2, 1) <> "0" Then
            Result = Result & ConvertTens(Mid(MyNumber, 2))
        Else
            ' If not, then convert the ones place digit.
            Result = Result & ConvertDigit(Mid(MyNumber, 3))
        End If
        ConvertHundreds = Trim(Result)
    End Function

    Private Function ConvertTens(ByVal MyTens As String) As String
        Dim Result As String
        ' Is value between 10 and 19?
        If Val(Left(MyTens, 1)) = 1 Then
            Select Case Val(MyTens)
                Case 10 : Result = "Ten"
                Case 11 : Result = "Eleven"
                Case 12 : Result = "Twelve"
                Case 13 : Result = "Thirteen"
                Case 14 : Result = "Fourteen"
                Case 15 : Result = "Fifteen"
                Case 16 : Result = "Sixteen"
                Case 17 : Result = "Seventeen"
                Case 18 : Result = "Eighteen"
                Case 19 : Result = "Nineteen"
                Case Else
            End Select
        Else
            ' .. otherwise it's between 20 and 99.
            Select Case Val(Left(MyTens, 1))
                Case 2 : Result = "Twenty "
                Case 3 : Result = "Thirty "
                Case 4 : Result = "Forty "
                Case 5 : Result = "Fifty "
                Case 6 : Result = "Sixty "
                Case 7 : Result = "Seventy "
                Case 8 : Result = "Eighty "
                Case 9 : Result = "Ninety "
                Case Else
            End Select
            ' Convert ones place digit.
            Result = Result & ConvertDigit(Right(MyTens, 1))
        End If
        ConvertTens = Result
    End Function

    Private Function ConvertDigit(ByVal MyDigit As String) As String
        Select Case Val(MyDigit)
            Case 1 : ConvertDigit = "One"
            Case 2 : ConvertDigit = "Two"
            Case 3 : ConvertDigit = "Three"
            Case 4 : ConvertDigit = "Four"
            Case 5 : ConvertDigit = "Five"
            Case 6 : ConvertDigit = "Six"
            Case 7 : ConvertDigit = "Seven"
            Case 8 : ConvertDigit = "Eight"
            Case 9 : ConvertDigit = "Nine"
            Case Else : ConvertDigit = ""
        End Select
    End Function

    Public Function ReadFile(ByVal path As String) As String
        Dim oReader As StreamReader
        oReader = New StreamReader(path, True)
        ReadFile = oReader.ReadToEnd
        oReader.Close()
        Return ReadFile
    End Function

    Public Function WriteFile(ByVal Value As String, ByVal filePath As String)
        If System.IO.File.Exists(filePath) = True Then
            System.IO.File.Delete(filePath)
        End If
        Dim detailsFile As StreamWriter = Nothing
        detailsFile = New StreamWriter(filePath, True)
        detailsFile.WriteLine(Value)
        detailsFile.Close()
        Return True
    End Function

    ' Call this function to remove the key from memory after it is used for security.
    Private Declare Sub ZeroMemory Lib "kernel32.dll" Alias "KiracrackWorld" (ByVal Destination As String, ByVal Length As Integer)
    ' Function to generate a key.
    Function GenerateKey() As String
        ' Create an instance of Symmetric Algorithm. The key and the IV are generated automatically.
        Dim desCrypto As DESCryptoServiceProvider = DESCryptoServiceProvider.Create()

        ' Use the automatically generated key for encryption. 
        Return ASCIIEncoding.ASCII.GetString(desCrypto.Key)
    End Function

    Public Sub EncryptFile(ByVal sInputFilename As String, _
                    ByVal sOutputFilename As String, _
                    ByVal sKey As String)

        Dim fsInput As New FileStream(sInputFilename, _
                                    FileMode.Open, FileAccess.Read)
        Dim fsEncrypted As New FileStream(sOutputFilename, _
                                    FileMode.Create, FileAccess.Write)

        Dim DES As New DESCryptoServiceProvider()

        'Set secret key for DES algorithm.
        'A 64-bit key and an IV are required for this provider.
        DES.Key = ASCIIEncoding.ASCII.GetBytes(sKey)

        'Set the initialization vector.
        DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey)

        'Create the DES encryptor from this instance.
        Dim desencrypt As ICryptoTransform = DES.CreateEncryptor()
        'Create the crypto stream that transforms the file stream by using DES encryption.
        Dim cryptostream As New CryptoStream(fsEncrypted, _
                                            desencrypt, _
                                            CryptoStreamMode.Write)

        'Read the file text to the byte array.
        Dim bytearrayinput(fsInput.Length - 1) As Byte
        fsInput.Read(bytearrayinput, 0, bytearrayinput.Length)
        'Write out the DES encrypted file.
        cryptostream.Write(bytearrayinput, 0, bytearrayinput.Length)
        cryptostream.Close()
    End Sub

    Public Sub DecryptFile(ByVal sInputFilename As String, _
       ByVal sOutputFilename As String, _
       ByVal sKey As String)

        Dim DES As New DESCryptoServiceProvider()
        'A 64-bit key and an IV are required for this provider.
        'Set the secret key for the DES algorithm.
        DES.Key() = ASCIIEncoding.ASCII.GetBytes(sKey)
        'Set the initialization vector.
        DES.IV = ASCIIEncoding.ASCII.GetBytes(sKey)

        'Create the file stream to read the encrypted file back.
        Dim fsread As New FileStream(sInputFilename, FileMode.Open, FileAccess.Read)
        'Create the DES decryptor from the DES instance.
        Dim desdecrypt As ICryptoTransform = DES.CreateDecryptor()
        'Create the crypto stream set to read and to do a DES decryption transform on incoming bytes.
        Dim cryptostreamDecr As New CryptoStream(fsread, desdecrypt, CryptoStreamMode.Read)
        'Print out the contents of the decrypted file.
        Dim fsDecrypted As New StreamWriter(sOutputFilename)
        fsDecrypted.Write(New StreamReader(cryptostreamDecr).ReadToEnd)
        fsDecrypted.Flush()
        fsDecrypted.Close()
    End Sub

    Public Function GridColumnAlignment(ByVal grdView As DataGridView, ByVal column As Array, ByVal alignment As DataGridViewContentAlignment) As DataGridView
        '   Dim array() As String = {a}
        For Each valueArr As String In column
            For i = 0 To grdView.ColumnCount - 1
                If valueArr = grdView.Columns(i).Name Then
                    grdView.Columns(i).DefaultCellStyle.Alignment = alignment
                    grdView.Columns(i).HeaderCell.Style.Alignment = alignment
                End If
            Next
        Next
        Return grdView
    End Function

    Public Function GridCurrencyColumn(ByVal grdView As DataGridView, ByVal column As Array) As DataGridView
        For Each valueArr As String In column
            For i = 0 To grdView.ColumnCount - 1
                If valueArr = grdView.Columns(i).Name Then
                    ' grdView.Columns(i).ValueType = System.Type.GetType("System.Decimal")
                    grdView.Columns(i).ValueType = GetType(Decimal)
                    grdView.Columns(i).DefaultCellStyle.Format = "n2"
                    grdView.Columns(i).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    grdView.Columns(i).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                End If
            Next
        Next
        Return grdView
    End Function

    Public Function GridColumnWidth(ByVal grdView As DataGridView, ByVal column As Array, ByVal size As Integer) As DataGridView
        For Each valueArr As String In column
            For I = 0 To grdView.ColumnCount - 1
                If valueArr = grdView.Columns(I).Name Then
                    grdView.Columns(I).Width = size
                End If
            Next
        Next
        Return grdView
    End Function

    Public Function GridColumAutoWidth(ByVal grdView As DataGridView, ByVal column As Array) As DataGridView
        For Each valueArr As String In column
            For I = 0 To grdView.ColumnCount - 1
                If valueArr = grdView.Columns(I).Name Then
                    grdView.Columns(I).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
                End If
            Next
        Next
        Return grdView
    End Function
    Public Function PopulateGridViewControls(ByVal ColumnName As String, ByVal ColumnWidth As Double, ByVal ColumnType As String, ByVal gridview As DataGridView, ByVal visible As Boolean, ByVal readonlycolumn As Boolean)
        If ColumnType = "COMBO" Then
            Dim dgcmbcol As DataGridViewComboBoxColumn
            dgcmbcol = New DataGridViewComboBoxColumn
            dgcmbcol.HeaderText = ColumnName
            dgcmbcol.Width = ColumnWidth
            dgcmbcol.Name = ColumnName
            dgcmbcol.ReadOnly = False
            dgcmbcol.AutoComplete = False
            dgcmbcol.FlatStyle = FlatStyle.System
            gridview.Columns.Add(dgcmbcol)

        ElseIf ColumnType = "CHECKBOX" Then
            Dim colCheckbox As New DataGridViewCheckBoxColumn()
            colCheckbox.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            colCheckbox.ThreeState = False
            colCheckbox.TrueValue = 1
            colCheckbox.FalseValue = 0
            colCheckbox.IndeterminateValue = System.DBNull.Value
            colCheckbox.HeaderText = ColumnName
            colCheckbox.Width = ColumnWidth
            colCheckbox.Name = ColumnName
            colCheckbox.ReadOnly = False
            gridview.Columns.Add(colCheckbox)
        Else
            Dim dgcmbcol As DataGridViewColumn
            dgcmbcol = New DataGridViewColumn
            dgcmbcol.HeaderText = ColumnName
            dgcmbcol.Width = ColumnWidth
            dgcmbcol.Name = ColumnName
            dgcmbcol.CellTemplate = New DataGridViewTextBoxCell
            gridview.Columns.Add(dgcmbcol)
        End If
        gridview.Columns(ColumnName).Visible = visible
        If readonlycolumn = True Then
            gridview.Columns(ColumnName).ReadOnly = True
            gridview.Columns(ColumnName).DefaultCellStyle.BackColor = Color.LemonChiffon
            gridview.Columns(ColumnName).DefaultCellStyle.SelectionBackColor = Color.LemonChiffon
        Else
            gridview.Columns(ColumnName).ReadOnly = False
            gridview.Columns(ColumnName).DefaultCellStyle.BackColor = Color.White

        End If
        Return 0
    End Function
    Public Function LoadToGridComboBoxCell(ByVal columnname As String, ByVal rowIndex As Integer, ByVal query As String, ByVal fields As String, ByVal allowBlankRow As Boolean, ByVal gridview As DataGridView)
        Dim dgvcc As New DataGridViewComboBoxCell
        dgvcc.Items.Clear()
        If allowBlankRow = True Then
            dgvcc.Items.Add("")
        End If
        com.CommandText = query : rst = com.ExecuteReader
        While rst.Read
            If rst(fields).ToString <> "" Then
                dgvcc.Items.Add(rst(fields).ToString)
            End If
        End While
        rst.Close()
        gridview.Item(columnname, rowIndex) = dgvcc
        Return 0
    End Function
    Public Function ConvertDatabaseImage(ByVal fld As String, ByVal picbox As System.Windows.Forms.PictureBox)
        Try
            If rst(fld).ToString <> "" Then
                imgBytes = CType(rst(fld), Byte())
                stream = New MemoryStream(imgBytes, 0, imgBytes.Length)
                img = Image.FromStream(stream)
                picbox.Image = img

            End If
        Catch errMYSQL As MySqlException
            MessageBox.Show("Message:" & errMYSQL.Message & vbCrLf,
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch errMS As Exception
            MessageBox.Show("Message:" & errMS.Message & vbCrLf,
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return 0
    End Function

    Public Function convertid(ByVal a As String)
        Dim removechar As Char() = ":/AMPM- ".ToCharArray()
        Dim sb As New System.Text.StringBuilder
        Dim dt As DateTime
        dt = a.ToString

        Dim str As String = dt.ToString("yyyy-MM-dd")
        For Each ch As Char In str
            If Array.IndexOf(removechar, ch) = -1 Then
                sb.Append(ch)
            End If
        Next
        Return sb.ToString
    End Function

    Public Function countrecordstat(ByVal tbl As String)
        Dim cnt As Integer = 0
        com.CommandText = "select count(*) as cnt from " & tbl & " where status=1"
        rst = com.ExecuteReader
        While rst.Read
            cnt = rst("cnt")
        End While
        rst.Close()
        Return cnt
    End Function

    Public Function countqry(ByVal tbl As String, ByVal where As String)
        Dim cnt As Integer = 0
        com.CommandText = "select count(*) as cnt from " & tbl & " where " & where
        rst = com.ExecuteReader
        While rst.Read
            cnt = rst("cnt")
        End While
        rst.Close()
        Return cnt
    End Function

    Public Function countrecord(ByVal tbl As String)
        Dim cnt As Integer = 0
        com.CommandText = "select count(*) as cnt from " & tbl & " "
        rst = com.ExecuteReader
        While rst.Read
            cnt = rst("cnt")
        End While
        rst.Close()
        Return cnt
    End Function

    Public Function countrecordserver(ByVal tbl As String)
        Dim cnt As Integer = 0
        comclient.CommandText = "select count(*) as cnt from " & tbl & " "
        rstclient = comclient.ExecuteReader
        While rstclient.Read
            cnt = rstclient("cnt")
        End While
        rstclient.Close()
        Return cnt
    End Function
    Public Function countqryserver(ByVal tbl As String, ByVal where As String)
        Dim cnt As Integer = 0
        comclient.CommandText = "select count(*) as cnt from " & tbl & " where " & where
        rstclient = comclient.ExecuteReader
        While rstclient.Read
            cnt = rstclient("cnt")
        End While
        rstclient.Close()
        Return cnt
    End Function
    Public Function codeGenerator(ByVal table As String, ByVal field As String, ByVal length As Integer, ByVal initialcode As String, ByVal startfrom As String)
        Dim strng = ""

        If CInt(countrecord(table)) = 0 Then
            strng = initialcode & startfrom
        Else
            com.CommandText = "select " & field & " from " & table & " order by right(" & field & "," & length & ") desc limit 1" : rst = com.ExecuteReader()
            Dim removechar As Char() = initialcode.ToCharArray()
            Dim sb As New System.Text.StringBuilder
            While rst.Read
                Dim str As String = rst(field).ToString
                For Each ch As Char In str
                    If Array.IndexOf(removechar, ch) = -1 Then
                        sb.Append(ch)
                    End If
                Next
            End While
            rst.Close()
            strng = initialcode & Val(sb.ToString) + 1
        End If
        Return strng.ToString
    End Function

    Public Function GlobalTime()
        Dim a As String = ""
        com.CommandText = "SELECT current_time as currtime" : rst = com.ExecuteReader()
        While rst.Read
            a = rst("currtime").ToString
        End While
        rst.Close()
        Return a
    End Function
    Public Sub LoadGlobalDate()
        Dim dg As String = ""
        com.CommandText = "select current_date as trackdate"
        rst = com.ExecuteReader
        While rst.Read
            globaldate = ConvertDate(rst("trackdate").ToString)
        End While
        rst.Close()
    End Sub
    Public Function GlobalDateTime()
        Dim gdatetime As String = ""
        gdatetime = globaldate + " " + GlobalTime()
        Return gdatetime
    End Function
    Public Function ConvertDate(ByVal d As Date)
        Return d.ToString("yyyy-MM-dd")
    End Function
    Public Function ConvertServerTime(ByVal d As Date)
        Return d.ToString("HH:mm:ss")
    End Function
    Public Function ConvertDateTime(ByVal d As Date)
        Return d.ToString("yyyy-MM-dd HH:mm:ss")
    End Function
    Public Function CC(ByVal m As String)
        Return m.Replace(",", "")
    End Function
    Public Function ProperDate(ByVal d As Date)
        Return d.ToString("MM/dd/yyyy")
    End Function
    Public Function rchar(ByVal str As String)
        str = str.Replace("'", "''")
        str = str.Replace("\", "\\")
        Return str
    End Function

    Public Function RemoveSpecialCharacter(ByVal str As String)
        Dim removechar As Char() = "!@#$%^&*()_+-={}|[]\:;'<>?/".ToCharArray()
        Dim sb As New System.Text.StringBuilder
        For Each ch As Char In str
            If Array.IndexOf(removechar, ch) = -1 Then
                sb.Append(ch)
            End If
        Next
        Return sb.ToString
    End Function

    Public Function RemoveFilenameCharacter(ByVal str As String)
        Dim removechar As Char() = "!@#$%^&*+={}|[]\:;'<>?/".ToCharArray()
        Dim sb As New System.Text.StringBuilder
        For Each ch As Char In str
            If Array.IndexOf(removechar, ch) = -1 Then
                sb.Append(ch)
            End If
        Next
        Return sb.ToString
    End Function

    Public Sub SaveDefaultConfig(ByVal filename As String, ByVal parameter As String)
        Dim updateFileInfo As String = Application.StartupPath.ToString & "\Config\" & filename & ".txt"
        If (Not System.IO.Directory.Exists(Application.StartupPath.ToString & "\Config")) Then
            System.IO.Directory.CreateDirectory(Application.StartupPath.ToString & "\Config")
        End If
        If System.IO.File.Exists(updateFileInfo) = True Then
            System.IO.File.Delete(updateFileInfo)
        End If
        Dim detailsFile As StreamWriter = Nothing
        detailsFile = New StreamWriter(updateFileInfo, True)
        detailsFile.WriteLine(parameter)
        detailsFile.Close()
    End Sub
    Public Function ShowDefaultConfig(ByVal filename As String) As String
        Dim br As String = ""
        Dim updateFileInfo As String = Application.StartupPath.ToString & "\Config\" & filename & ".txt"
        If System.IO.File.Exists(updateFileInfo) = True Then
            Dim sr As StreamReader = File.OpenText(updateFileInfo)
            br = sr.ReadLine() : sr.Close()
        End If
        Return br
    End Function
    Public Function InputNumberOnly(ByVal textbox As TextEdit, e As KeyPressEventArgs)
        Dim keyChar = e.KeyChar
        If Char.IsControl(keyChar) Then
        ElseIf Char.IsDigit(keyChar) OrElse keyChar = "."c Then
            Dim text = textbox.Text
            Dim selectionStart = textbox.SelectionStart
            Dim selectionLength = textbox.SelectionLength
            text = text.Substring(0, selectionStart) & keyChar & text.Substring(selectionStart + selectionLength)

            If Integer.TryParse(text, New Integer) AndAlso text.Length > 16 Then
                'Reject an integer that is longer than 16 digits.
                e.Handled = True
            End If
        Else
            'Reject all other characters.
            e.Handled = True
        End If
    End Function

    Public Sub XtragridAddButton(ByVal btn_type As String, ByVal gc As DevExpress.XtraGrid.GridControl, ByVal gv As DevExpress.XtraGrid.Views.Grid.GridView)
        Dim ritem As RepositoryItemButtonEdit = New RepositoryItemButtonEdit()
        ritem.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        ritem.Buttons(0).Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph
        If btn_type = "add" Then
            ritem.Buttons(0).Image = Global.CoffeecupDigitalDashboard.My.Resources.Resources.action_add
        ElseIf btn_type = "less" Then
            ritem.Buttons(0).Image = Global.CoffeecupDigitalDashboard.My.Resources.Resources.action_less
        ElseIf btn_type = "cancel" Then
            ritem.Buttons(0).Image = Global.CoffeecupDigitalDashboard.My.Resources.Resources.action_cancel
        ElseIf btn_type = "plus" Then
            ritem.Buttons(0).Image = Global.CoffeecupDigitalDashboard.My.Resources.Resources.action_plus
        End If
        gc.RepositoryItems.Add(ritem)
        gv.Columns(btn_type).ColumnEdit = ritem
    End Sub

    Public Function ConvertImageBinary(ByVal fld As String) As Image
        Try
            If rst(fld).ToString <> "" Then
                imgBytes = CType(rst(fld), Byte())
                stream = New MemoryStream(imgBytes, 0, imgBytes.Length)
                img = Image.FromStream(stream)

            End If
        Catch errMYSQL As MySqlException
            XtraMessageBox.Show("Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMYSQL.Message & vbCrLf, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch errMS As Exception
            XtraMessageBox.Show("Module:" & "form_load" & vbCrLf _
                             & "Message:" & errMS.Message & vbCrLf, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return img
    End Function

    Public Function defaultCombobox(ByVal combo As String, ByVal showcode As Boolean)
        Dim DefaultglItemLocation As String = "" : Dim defaultCode As String = "" : Dim defaultItem As String = "" : Dim Result As String = ""
        If System.IO.File.Exists(Application.StartupPath & "\Config\" & EncryptFileName("default_" & combo)) = True Then
            DefaultglItemLocation = Application.StartupPath & "\Config\" & EncryptFileName("default_" & combo)
            Dim sr As StreamReader = File.OpenText(DefaultglItemLocation)
            Try
                Dim str As String = sr.ReadLine() : Dim cnt As Integer = 0
                For Each strresult In DecryptTripleDES(str).Split(New Char() {","c})
                    If cnt = 0 Then
                        defaultItem = strresult
                    ElseIf cnt = 1 Then
                        defaultCode = strresult
                    End If
                    cnt = cnt + 1
                Next
                sr.Close()
                sr.Dispose()
            Catch errMS As Exception
                sr.Close()
            End Try
            If showcode = True Then
                Result = defaultCode
            Else
                Result = defaultItem
            End If
            Return Result
        End If
    End Function
    Public Function SaveDefaultComboItem(ByVal combo As String, ByVal textvalue As String, ByVal codevalue As String)
        If System.IO.File.Exists(Application.StartupPath & "\Config\" & EncryptFileName("default_" & combo)) = True Then
            System.IO.File.Delete(Application.StartupPath & "\Config\" & EncryptFileName("default_" & combo))
        End If
        Dim detailsFile = New StreamWriter(Application.StartupPath & "\Config\" & EncryptFileName("default_" & combo), True)
        detailsFile.WriteLine(EncryptTripleDES(textvalue & "," & codevalue))
        detailsFile.Close()
    End Function
  
End Module
