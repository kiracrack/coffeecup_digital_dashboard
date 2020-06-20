Imports MySql.Data.MySqlClient
Imports System.IO

Public Class frmSelectUser
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        If keyData = Keys.Escape Then
            Me.Close()
        End If
        Return ProcessCmdKey
    End Function
    Private Sub frmSelectUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = ico
        ShowActiveUser()
    End Sub

    Public Sub ShowActiveUser()
        LoadXgrid("Select distinct accountid, profileimg,Fullname from tblaccounts as a left join tbllogin as b on a.accountid=b.userid where " _
                  + " coffeecupposition in (select authCode from tbluserauthority where pointofsaleassistant=1) and " _
                  + " coffeecupposition in (select permissioncode from tblsalesqueuingfilter) and coffeecupuser=1 and deleted=0 order by outtime desc;", "tblaccounts", Em, GridView1, 0, Me)
        GridView1.Columns("profileimg").Width = 78
        XgridHideColumn({"accountid"}, GridView1)
        XgridColAlign({"profileimg"}, GridView1, DevExpress.Utils.HorzAlignment.Center)

        ImageColumn.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze
        GridView1.Columns("profileimg").ColumnEdit = ImageColumn
        'gridView1.Columns["Picture"].Width = 150;
        GridView1.RowHeight = 80
        GridView1.UserCellPadding = New Padding(3)
    End Sub

    Private Sub Em_Click(sender As Object, e As EventArgs) Handles Em.Click
        frmLogin.LoadLastUser(GridView1.GetFocusedRowCellValue("accountid").ToString)
    End Sub

    Private Sub GridView1_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        frmLogin.LoadLastUser(GridView1.GetFocusedRowCellValue("accountid").ToString)
    End Sub
End Class