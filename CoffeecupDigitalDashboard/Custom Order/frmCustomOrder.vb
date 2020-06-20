Imports MySql.Data.MySqlClient
Imports System.IO

Public Class frmCustomOrder
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = Keys.Escape Then
            Me.Close()
        End If
        Return ProcessCmdKey
    End Function
    Private Sub frmSelectUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = ico
        ShowSubItemProduct()
    End Sub

    Public Sub ShowSubItemProduct()
        LoadXgrid("select productid, itemname, ucase(Unit) as 'unit',null as 'plus' from tblglobalproducts where productid in (select productid from tblproductserviceitem where source_productid='" & productid.Text & "')", "tblglobalproducts", Em, GridView1, 3, Me)
        XgridHideColumn({"productid"}, GridView1)
        XgridColAlign({"unit"}, GridView1, DevExpress.Utils.HorzAlignment.Center)
        XtragridAddButton("plus", Em, GridView1)
    End Sub

    Private Sub GridView1_RowCellClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs) Handles GridView1.RowCellClick
        If e.Column.Name = "colplus" Then
            InsertInitialOrder(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, GridView1.Columns("productid")).ToString)
        End If

    End Sub

    Public Sub InsertInitialOrder(ByVal productid As String)
        Dim productname As String = "" : Dim customproductorder As Boolean = False
        com.CommandText = "select * from tblglobalproducts where productid='" & productid & "'" : rst = com.ExecuteReader
        While rst.Read
            productname = rst("itemname").ToString
            customproductorder = rst("customproductorder")
        End While
        rst.Close()
        If countqry("tbltouchcurrentordersubitem", "trnby='" & globalAssistantUserId & "' and productid='" & productid & "' and postrn='" & postrn.Text & "'") > 0 Then
            com.CommandText = "UPDATE tbltouchcurrentordersubitem set quantity=quantity+1 where trnby='" & globalAssistantUserId & "' and productid='" & productid & "' and postrn='" & postrn.Text & "'" : com.ExecuteNonQuery()
        Else
            com.CommandText = "insert into tbltouchcurrentordersubitem set postrn='" & postrn.Text & "', productid='" & productid & "', productname='" & productname & "',quantity=1,unitcost=0,remarks='', trnby='" & globalAssistantUserId & "' " : com.ExecuteNonQuery()
        End If
        ' MainDashboard.loadCurrentOrder()
    End Sub

    'Private Sub Em_Click(sender As Object, e As EventArgs) Handles Em.Click
    '    frmLogin.LoadLastUser(GridView1.GetFocusedRowCellValue("accountid").ToString)
    'End Sub

    'Private Sub GridView1_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
    '    frmLogin.LoadLastUser(GridView1.GetFocusedRowCellValue("accountid").ToString)
    'End Sub
End Class