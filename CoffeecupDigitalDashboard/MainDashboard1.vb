Imports MySql.Data.MySqlClient
Imports System.IO
Imports DevExpress.XtraEditors
Imports DevExpress.LookAndFeel
Imports DevExpress.XtraBars
Imports DevExpress.XtraSplashScreen

Public Class MainDashboard1
    Dim SeletedPile As String = ""
    Dim SubCategoryCode As String = ""
    Dim SubCategoryName As String = ""

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub MainDashboard_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        For i As Integer = My.Application.OpenForms.Count - 1 To 0 Step -1
            If My.Application.OpenForms.Item(i) IsNot Me And My.Application.OpenForms.Item(i) IsNot frmLogin Then
                My.Application.OpenForms.Item(i).Close()
            End If
        Next i
        If XtraMessageBox.Show("Are you sure you want to logoff your account " & globalfullname & " on " & globaldate & " - " & GlobalTime().ToString & ") ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            com.CommandText = "update tbllogin set outtime=current_timestamp  where userid='" & globaluserid & "' and outtime is null" : com.ExecuteNonQuery()
            CloseSystemDeclaration()
            SplashScreenManager.ShowForm(GetType(WaitForm1), True, True)
            frmLogin.Show()
            SplashScreenManager.CloseForm()
        Else
            e.Cancel = True
        End If
    End Sub
    Private Sub XtraForm1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = ico
        LoadCategory()
    End Sub

    Private Sub cmdClose_ElementClick(sender As Object, e As DevExpress.XtraBars.Navigation.NavElementEventArgs) Handles cmdClose.ElementClick
        Me.Close()
    End Sub

    Private Sub cmdBack_ElementClick(sender As Object, e As DevExpress.XtraBars.Navigation.NavElementEventArgs) Handles cmdBack.ElementClick
        If SeletedPile = "subcategory" Then
            LoadCategory()
        ElseIf SeletedPile = "product" Then
            LoadSubCategory(SubCategoryCode, SubCategoryName)
        End If
    End Sub

    Public Sub LoadCategory()
        Dim imgBytes As Byte() = Nothing
        Dim stream As MemoryStream = Nothing
        Dim img As Image = Nothing

        Dim tg As New DevExpress.XtraEditors.TileGroup()
        tg.Text = "Select one of product category listed below to view product sub category"

        com.CommandText = "select *,ifnull((select imgdata from filedir.tblimagerepository where referenceno=tblprocategory.catid and tablename='tblprocategory'),null) as img " _
            + " from tblprocategory where catid in (select categorycode from tblproductfilter where permissioncode='" & globalAuthcode & "')  and description not like '%discount%'" : rst = com.ExecuteReader
        While rst.Read
            Dim ti As New DevExpress.XtraEditors.TileItem()
            Dim te As New DevExpress.XtraEditors.TileItemElement()

            tg.Items.Add(ti)
            ti.AppearanceItem.Normal.BackColor = System.Drawing.Color.Black
            ti.AppearanceItem.Normal.Options.UseBackColor = True

            If rst("img").ToString <> "" Then
                imgBytes = CType(rst("img"), Byte())
                stream = New MemoryStream(imgBytes, 0, imgBytes.Length)
                img = Image.FromStream(stream)
                te.Image = img
                ti.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide
            End If

            ti.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide
            ti.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide
            te.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
            te.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomOutside
            te.Text = rst("description").ToString & Environment.NewLine
            te.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomLeft
            te.Appearance.Normal.Font = New System.Drawing.Font("Segoe UI", 10.25!)
            ti.Elements.Add(te)

            ti.Name = rst("catid").ToString
            ti.Padding = New System.Windows.Forms.Padding(2)
            ti.TextShowMode = DevExpress.XtraEditors.TileItemContentShowMode.Always
            AddHandler ti.ItemClick, AddressOf Me.TileItem_Category

        End While
        rst.Close()
        TileCategory.Groups.Clear()
        TileCategory.Groups.Add(tg)
        tg.Control.AppearanceGroupText.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        TileCategory.AnimateArrival = True
        TileCategory.ItemContentAnimation = TileItemContentAnimationType.RandomSegmentedFade
        TileCategory.ItemCheckMode = TileItemCheckMode.Single
        TileCategory.Text = "Choose Category"

        cmdBack.Visible = False
    End Sub

    Private Sub TileItem_Category(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs)
        SubCategoryCode = e.Item.Name
        SubCategoryName = e.Item.Text
        LoadSubCategory(e.Item.Name, e.Item.Text)
    End Sub

    Public Sub LoadSubCategory(ByVal category As String, ByVal categoryname As String)
        Dim imgBytes As Byte() = Nothing
        Dim stream As MemoryStream = Nothing
        Dim img As Image = Nothing
        Dim tg As New DevExpress.XtraEditors.TileGroup()
        com.CommandText = "select * from tblprocategory where catid='" & category & "'" : rst = com.ExecuteReader
        While rst.Read
            tg.Text = rst("details").ToString
        End While
        rst.Close()
        com.CommandText = "select *, " _
            + " ifnull((select imgdata from filedir.tblimagerepository where referenceno=tblprosubcategory.subcatid and tablename='tblprocategory'),null) as img " _
            + " from tblprosubcategory where catid='" & category & "' and catid in  (select categorycode from tblproductfilter where permissioncode='" & globalAuthcode & "')" : rst = com.ExecuteReader
        While rst.Read
            Dim ti As New DevExpress.XtraEditors.TileItem()
            Dim te As New DevExpress.XtraEditors.TileItemElement()

            tg.Items.Add(ti)
            ti.AppearanceItem.Normal.BackColor = System.Drawing.Color.Black
            ti.AppearanceItem.Normal.Options.UseBackColor = True
            If rst("img").ToString <> "" Then
                imgBytes = CType(rst("img"), Byte())
                stream = New MemoryStream(imgBytes, 0, imgBytes.Length)
                img = Image.FromStream(stream)
                te.Image = img
            End If
            ti.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide
            te.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
            te.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomOutside
            te.Text = rst("description").ToString & Environment.NewLine
            te.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomLeft
            te.Appearance.Normal.Font = New System.Drawing.Font("Segoe UI", 10.25!)
            ti.Elements.Add(te)

            ti.Name = rst("catid").ToString & "|" & rst("subcatid").ToString
            ti.Padding = New System.Windows.Forms.Padding(2)
            ti.TextShowMode = DevExpress.XtraEditors.TileItemContentShowMode.Always
            AddHandler ti.ItemClick, AddressOf Me.TileItem_SubCategory
        End While
        rst.Close()
        TileCategory.Text = categoryname.Replace(vbCrLf, "")
        TileCategory.Groups.Clear()
        TileCategory.Groups.Add(tg)
        tg.Control.AppearanceGroupText.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        TileCategory.AnimateArrival = True
        TileCategory.ItemContentAnimation = TileItemContentAnimationType.Fade
        TileCategory.ItemCheckMode = TileItemCheckMode.Single
        SeletedPile = "subcategory"
        If SeletedPile = "subcategory" Or SeletedPile = "product" Then
            cmdBack.Visible = True
        Else
            cmdBack.Visible = False
        End If
    End Sub

    Private Sub TileItem_SubCategory(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs)
        LoadProduct(e.Item.Name, e.Item.Text)
    End Sub

    Public Sub LoadProduct(ByVal id As String, ByVal categoryname As String)
        Dim catid As String = "" : Dim subcatid As String = ""
        Dim imgBytes As Byte() = Nothing
        Dim stream As MemoryStream = Nothing
        Dim img As Image = Nothing
        Dim word As String() = id.Split("|")
        catid = word(0)
        subcatid = word(1)
        Dim cnt As Integer = 0
        msda = Nothing : dst = New DataSet

        Dim tg As New DevExpress.XtraEditors.TileGroup()
        Dim maincategoryname As String = ""
        com.CommandText = "select * from tblprocategory where catid='" & catid & "'" : rst = com.ExecuteReader
        While rst.Read
            tg.Text = rst("details").ToString
            maincategoryname = rst("description").ToString
        End While
        rst.Close()
        com.CommandText = "select *,ifnull((select imgdata from filedir.tblproductimage where productid=tblglobalproducts.productid),null) as img " _
            + " from tblglobalproducts where catid='" & catid & "'  and subcatid='" & subcatid & "'  and enablesell=1 and deleted=0 and " _
            + " catid in (select categorycode from tblproductfilter where permissioncode='" & globalAuthcode & "') order by itemname asc;" : rst = com.ExecuteReader
        While rst.Read
            Dim ti As New DevExpress.XtraEditors.TileItem()
            Dim te As New DevExpress.XtraEditors.TileItemElement()

            tg.Items.Add(ti)
            If rst("img").ToString <> "" Then
                imgBytes = CType(rst("img"), Byte())
                stream = New MemoryStream(imgBytes, 0, imgBytes.Length)
                img = Image.FromStream(stream)
                te.Image = img
                ti.ItemSize = DevExpress.XtraEditors.TileItemSize.Wide
            Else

                ti.ItemSize = DevExpress.XtraEditors.TileItemSize.Medium
            End If

            te.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter
            te.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomOutside
            te.Text = rst("itemname").ToString & Environment.NewLine & "P " & FormatNumber(rst("sellingprice").ToString, 2)
            te.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.BottomLeft
            'ti.Checked = True
            te.Appearance.Normal.Font = New System.Drawing.Font("Segoe UI", 10.25!)
            ti.Elements.Add(te)
            ti.Id = cnt

            ti.Name = rst("productid").ToString
            ti.Padding = New System.Windows.Forms.Padding(2)
            ti.TextShowMode = DevExpress.XtraEditors.TileItemContentShowMode.Always
            AddHandler ti.ItemClick, AddressOf Me.TileItem_SingleClick
            AddHandler ti.RightItemClick, AddressOf Me.TileItem_RightClick
            cnt = cnt + 1
            Dim rand As New Random
            ti.AppearanceItem.Normal.BackColor = Color.Black
        End While
        rst.Close()

        TileCategory.Text = maincategoryname & " > " & categoryname.Replace(vbCrLf, "")
        TileCategory.Groups.Clear()
        TileCategory.Groups.Add(tg)
        tg.Control.AppearanceGroupText.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        TileCategory.AnimateArrival = True
        TileCategory.ItemCheckMode = TileItemCheckMode.Single
        SeletedPile = "product"

    End Sub

    Private Sub BarManager1_ItemClick(ByVal sender As Object, ByVal e As ItemClickEventArgs)
        XtraMessageBox.Show(e.Item.Caption & " item clicked")
    End Sub

    Private Sub TileItem_SingleClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs)
        MsgBox("hello")
    End Sub

    Private Sub TileItem_RightClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs)
        PopupMenu1.ShowPopup(Control.MousePosition)
    End Sub

    Private Sub NavButton2_ElementClick(sender As Object, e As DevExpress.XtraBars.Navigation.NavElementEventArgs) Handles NavButton2.ElementClick
        frmSetPermission.ShowDialog(Me)
    End Sub

    Private Sub cmdtableQueue_ElementClick(sender As Object, e As DevExpress.XtraBars.Navigation.NavElementEventArgs) Handles cmdtableQueue.ElementClick
        XtraTabControl1.SelectedTabPage = XtraTabPage2
    End Sub

    Private Sub cmdCurrentOrder_ElementClick(sender As Object, e As DevExpress.XtraBars.Navigation.NavElementEventArgs) Handles cmdCurrentOrder.ElementClick
        XtraTabControl1.SelectedTabPage = XtraTabPage1
    End Sub


    Private Sub XtraTabControl1_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XtraTabControl1.SelectedPageChanged
        If XtraTabControl1.SelectedTabPage Is XtraTabPage1 Then
            cmdCurrentOrder.Appearance.BackColor = Color.Black
            cmdtableQueue.Appearance.BackColor = Nothing
        ElseIf XtraTabControl1.SelectedTabPage Is XtraTabPage2 Then
            cmdtableQueue.Appearance.BackColor = Color.Black
            cmdCurrentOrder.Appearance.BackColor = Nothing
        End If
    End Sub
End Class