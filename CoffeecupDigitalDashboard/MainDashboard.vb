Imports MySql.Data.MySqlClient
Imports System.IO
Imports DevExpress.XtraEditors
Imports DevExpress.LookAndFeel
Imports DevExpress.XtraBars
Imports DevExpress.XtraSplashScreen
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Grid

Public Class MainDashboard
    Dim SeletedPile As String = ""
    Dim SubCategoryCode As String = ""
    Dim SubCategoryName As String = ""
    Public walkinEnable As Boolean

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub cmdClose_ElementClick(sender As Object, e As DevExpress.XtraBars.Navigation.NavElementEventArgs) Handles cmdClose.ElementClick
        Me.Close()
    End Sub

    Private Sub MainDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Icon = ico
        If Globalenableclientfilter = True Then
            If countqry("tblclientaccounts", "walkinaccount=1  and groupcode in (select clientgroup from tblclientfilter where permissioncode='" & globalAuthcode & "')") > 0 Then
                walkinEnable = True
            Else
                walkinEnable = False
            End If
        Else
            walkinEnable = True
        End If
        LoadClient()
        LoadCategory()
        ShowTabContent()
        BeginNewTransaction()
    End Sub

    Public Sub LoadClient()
        If Globalenableclientfilter = True Then
            LoadXgridLookupSearch("select cifid, companyname as 'Customer Name' from tblclientaccounts where groupcode in (select clientgroup from tblclientfilter where permissioncode='" & globalAuthcode & "') and walkinaccount=0 and approved=1 and deleted=0 and blocked=0 and (vip=0 or (vip=1 and vipactivated=1)) order by companyname asc", "tblclientaccounts", cifid, gridcif, Me)
            XgridHideColumn({"cifid"}, gridcif)
        Else
            LoadXgridLookupSearch("select cifid, companyname as 'Customer Name' from tblclientaccounts where approved=1 and walkinaccount=0 and deleted=0 and blocked=0 and (vip=0 or (vip=1 and vipactivated=1)) order by companyname asc", "tblclientaccounts", cifid, gridcif, Me)
            XgridHideColumn({"cifid"}, gridcif)
        End If
       
    End Sub
    Public Sub BeginNewTransaction()
        Dim newBatchcode As String = getPOSBatchCode() + "-" + globaluserid
        If countqry("tblsalesbatch", "batchcode='" & newBatchcode & "'") > 0 Then
            newBatchcode = getPOSBatchCode() + "-" + globaluserid
        End If
        txtBatchcode.Text = newBatchcode
        ValidatePOSTransaction(txtBatchcode.Text)
        txtuserid.Text = globalTransactionUserid
        LoadDefaultClient()
    End Sub
    Public Sub LoadDefaultClient()
        If walkinEnable = True Then
            cifid.EditValue = qrysingledata("cifid", "cifid", "tblclientaccounts where walkinaccount=1")
        Else
            cifid.EditValue = defaultCombobox("digital_dashboard_cif", True)
        End If
    End Sub
    Public Sub ValidatePOSTransaction(ByVal batchcode As String)
        com.CommandText = "select count(*) as cnt,ifnull(sum(distotal),0) as 'distotal',ifnull(sum(chargetotal),0) as 'chargetotal',ifnull(sum(taxtotal),0) as 'taxtotal',ifnull(sum(svchargetotal),0) as 'svchargetotal',ifnull(sum(subtotal),0) as 'subtotal', ifnull(sum(total),0) as 'total' from tblsalestransaction where batchcode='" & batchcode & "'" : rst = com.ExecuteReader
        While rst.Read
            txtTotalItem.Text = rst("cnt")
            txtTotalDiscount.Text = FormatNumber(rst("distotal"), 2)
            txtTotalCharge.Text = FormatNumber(rst("chargetotal"), 2)
            txtTotalTax.Text = FormatNumber(rst("taxtotal"), 2)
            txtServiceCharge.Text = FormatNumber(rst("svchargetotal"), 2)
            txtSubTotal.Text = FormatNumber(rst("subtotal"), 2)
            txtTotalOnScreen.Text = FormatNumber(rst("total"), 2)
        End While
        rst.Close()
       
        LoadXgrid("select * from (select ID,0 as SUBID,PRODUCTID,productname as 'PARTICULAR',quantity as QTY,UNIT,sellprice as 'UNIT PRICE',chargetotal as 'CHARGES',distotal as 'DISCOUNT',subtotal as 'SUB TOTAL', TOTAL,REMARKS, null as 'add', null as 'less', null as 'cancel' from tblsalestransaction where batchcode='" & batchcode & "'  and cancelled=0  union all " _
                          + " select postrn as ID, ID as SUBID,PRODUCTID, concat('      - ',productname),quantity,unit,0,0,0,0,0,'', null as 'add', null as 'less', null as 'cancel' from tblsalesproductcustomorder where postrn in (select id from tblsalestransaction where batchcode='" & batchcode & "'  and void=0 )) as a order by ID,SUBID desc;", "tblsalestransaction", Em, GridView1, 3, Me)
        XgridHideColumn({"ID", "SUBID", "PRODUCTID"}, GridView1)
        XgridColAlign({"QTY"}, GridView1, DevExpress.Utils.HorzAlignment.Center)
        XgridColCurrency({"UNIT PRICE", "TOTAL"}, GridView1)
        XgridGeneralSummaryCurrency({"TOTAL"}, GridView1)
        XgridGeneralSummaryNumber({"QTY"}, GridView1)
        GridView1.BestFitColumns()
        XgridColWidth({"UNIT PRICE", "TOTAL"}, GridView1, 120)
        XgridColWidth({"quantity", "add", "less", "cancel"}, GridView1, 78)
        'GridView1.RowHeight = 40
        GridView1.OptionsView.ShowHorzLines = False
        XtragridAddButton("add", Em, GridView1)
        XtragridAddButton("less", Em, GridView1)
        XtragridAddButton("cancel", Em, GridView1)


        If Val(CC(GridView1.Columns("QTY").SummaryText)) > 0 Then
            cmdCurrentOrder.Visible = True
            cmdCurrentOrder.Caption = "Current Order (" & Val(CC(GridView1.Columns("QTY").SummaryText)) & ")"
            UpdateTransactionHeader()
        Else
            cmdCurrentOrder.Visible = False
        End If

    End Sub
    Public Sub UpdateTransactionHeader()
        Dim netincome As Double = qrysingledata("totalincome", "ifnull(sum(income),0) as 'totalincome'", "tblsalestransaction where batchcode='" & Trim(txtBatchcode.Text) & "' and void=0 and cancelled=0")
        Dim chittotal As Double = qrysingledata("chit_total", "ifnull(sum(chittotal),0) as 'chit_total'", "tblsalestransaction where batchcode='" & Trim(txtBatchcode.Text) & "' and void=0 and cancelled=0")
        If countqry("tblsalesbatch", "batchcode='" & Trim(txtBatchcode.Text) & "'") = 0 Then
            com.CommandText = "insert into tblsalesbatch set trnsumcode='" & globalSalesTrnCOde & "', " _
                                    + " userid='" & globalTransactionUserid & "', " _
                                    + " batchcode='" & Trim(txtBatchcode.Text) & "', " _
                                    + " officeid='" & compOfficeid & "', " _
                                    + " cifid='" & cifid.EditValue & "', " _
                                    + " totalitem='" & Val(CC(txtTotalItem.Text)) & "', " _
                                    + " totalitemcancelled=0, " _
                                    + " totaldiscount='" & Val(CC(txtTotalDiscount.Text)) & "', " _
                                    + " totalcharge='" & Val(CC(txtTotalCharge.Text)) & "', " _
                                    + " totaltax='" & Val(CC(txtTotalTax.Text)) & "', " _
                                    + " totalsvcharge='" & Val(CC(txtServiceCharge.Text)) & "', " _
                                    + " subtotal='" & Val(CC(txtSubTotal.Text)) & "', " _
                                    + " chittotal=" & chittotal & "," _
                                    + If(chittotal > 0, "chittrn=1,", "chittrn=0, ") _
                                    + " total='" & Val(CC(txtTotalOnScreen.Text)) & "', " _
                                    + " totalincome='" & netincome & "', " _
                                    + " floattrn=1, " _
                                    + " attendingperson = '" & globalAssistantUserId & "', " _
                                    + " datetrn=" & If(globalBackDateTransaction = True, "concat('" & ConvertDate(globalBackDate) & "',' ',current_time)", "current_timestamp") & "" : com.ExecuteNonQuery()
        Else
            com.CommandText = "update tblsalesbatch set trnsumcode='" & globalSalesTrnCOde & "', " _
                                   + " officeid='" & compOfficeid & "', " _
                                   + " cifid='" & cifid.EditValue & "', " _
                                   + " totalitem='" & Val(CC(txtTotalItem.Text)) & "', " _
                                   + " totalitemcancelled=0, " _
                                   + " totaldiscount='" & Val(CC(txtTotalDiscount.Text)) & "', " _
                                   + " totalcharge='" & Val(CC(txtTotalCharge.Text)) & "', " _
                                   + " totaltax='" & Val(CC(txtTotalTax.Text)) & "', " _
                                   + " totalsvcharge='" & Val(CC(txtServiceCharge.Text)) & "', " _
                                   + " subtotal='" & Val(CC(txtSubTotal.Text)) & "', " _
                                   + " chittotal=" & chittotal & "," _
                                   + If(chittotal > 0, "chittrn=1,", "chittrn=0, ") _
                                   + " total='" & Val(CC(txtTotalOnScreen.Text)) & "', " _
                                   + " totalincome='" & netincome & "', " _
                                   + " floattrn=1, " _
                                   + " attendingperson = '" & globalAssistantUserId & "', " _
                                   + " datetrn=" & If(globalBackDateTransaction = True, "concat('" & ConvertDate(globalBackDate) & "',' ',current_time)", "current_timestamp") & " " _
                                   + " where batchcode='" & Trim(txtBatchcode.Text) & "'" : com.ExecuteNonQuery()
        End If
        txtuserid.Text = qrysingledata("userid", "userid", "tblsalesbatch where batchcode='" & txtBatchcode.Text & "'")
        SaveDefaultComboItem("digital_dashboard_cif", cifid.EditValue, cifid.EditValue)
    End Sub

    Public Function getPOSBatchCode()
        Dim strng As Integer = 0 : Dim newBatch As String = ""
        If CInt(countrecord("tblsalesbatchsequence")) = 0 Then
            MsgBox("Transaction Batch Not Set please contact your system administrator")
            Return False
        Else
            com.CommandText = "select batchcode from tblsalesbatchsequence" : rst = com.ExecuteReader()
            While rst.Read
                strng = Val(rst("batchcode").ToString) + 1
            End While
            rst.Close()
        End If
        com.CommandText = "UPDATE tblsalesbatchsequence set batchcode='" & strng & "'" : com.ExecuteNonQuery()
        newBatch = strng.ToString
        Return newBatch
    End Function


#Region "Dashboard"
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
            frmLogin.LoginControl(True, True)
            frmLogin.LoginControl(False, True)
            frmLogin.TabNavigationPage1.PageVisible = True
            frmLogin.TabNavigationPage2.PageVisible = True
            frmLogin.TabNavigationPage3.PageVisible = False
            frmLogin.TabPane1.SelectedPage = frmLogin.TabNavigationPage1
            frmLogin.LoginControl(True, True)
            frmLogin.LoginControl(False, True)
            SplashScreenManager.CloseForm()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub XtraTabControl1_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XtraTabControl1.SelectedPageChanged
        ShowTabContent()
    End Sub

    Public Sub ShowTabContent()
        cmdtableQueue.Appearance.BackColor = Nothing
        cmdDashboard.Appearance.BackColor = Nothing
        cmdCurrentOrder.Appearance.BackColor = Nothing

        If XtraTabControl1.SelectedTabPage Is tabDigitalScreen Then
            cmdDashboard.Appearance.BackColor = Color.Black
        ElseIf XtraTabControl1.SelectedTabPage Is tabTableQueue Then
            cmdtableQueue.Appearance.BackColor = Color.Black
        ElseIf XtraTabControl1.SelectedTabPage Is tabCurrentOrder Then
            cmdCurrentOrder.Appearance.BackColor = Color.Black
        End If
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
    Private Sub TileItem_RightClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs)
        PopupMenu1.ShowPopup(Control.MousePosition)
    End Sub
    Private Sub cmdtableQueue_ElementClick(sender As Object, e As DevExpress.XtraBars.Navigation.NavElementEventArgs) Handles cmdtableQueue.ElementClick
        XtraTabControl1.SelectedTabPage = tabTableQueue
    End Sub
    Private Sub cmdCurrentOrder_ElementClick(sender As Object, e As DevExpress.XtraBars.Navigation.NavElementEventArgs) Handles cmdDashboard.ElementClick
        XtraTabControl1.SelectedTabPage = tabDigitalScreen
    End Sub
    Private Sub cmdCurrentOrder_ElementClick_1(sender As Object, e As Navigation.NavElementEventArgs) Handles cmdCurrentOrder.ElementClick
        XtraTabControl1.SelectedTabPage = tabCurrentOrder
    End Sub
    Private Sub TileItem_SingleClick(sender As Object, e As DevExpress.XtraEditors.TileItemEventArgs)
        If cifid.Text = "" Then
            XtraMessageBox.Show("please select customer name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If
        InsertInitialOrder(e.Item.Name)
    End Sub
    Public Sub InsertInitialOrder(ByVal productid As String)
        Dim productname As String = "" : Dim sellingprice As Double = 0 : Dim customproductorder As Boolean = False
        com.CommandText = "select * from tblglobalproducts where productid='" & productid & "'" : rst = com.ExecuteReader
        While rst.Read
            productname = rst("itemname").ToString
            sellingprice = Val(rst("sellingprice").ToString)
            customproductorder = rst("customproductorder")
        End While
        rst.Close()
        If TrapTransaction(cifid.EditValue, txtBatchcode.Text, productid, 1) = True Then
            PostSalesTransaction(cifid.EditValue, txtBatchcode.Text, productid, 1, sellingprice, 0, "")
            ValidatePOSTransaction(txtBatchcode.Text)
        End If

        'If countqry("tbltouchcurrentorder", "trnby='" & globalAssistantUserId & "' and productid='" & productid & "' and customorder=0") > 0 Then
        '    com.CommandText = "UPDATE tbltouchcurrentorder set quantity=quantity+1 where trnby='" & globalAssistantUserId & "' and productid='" & productid & "' and customorder=0" : com.ExecuteNonQuery()
        'Else
        '    com.CommandText = "insert into tbltouchcurrentorder set productid='" & productid & "', productname='" & productname & "',quantity=1,unitcost='" & sellingprice & "',remarks='',customorder=" & customproductorder & ", trnby='" & globalAssistantUserId & "' " : com.ExecuteNonQuery()
        'End If
        'loadCurrentOrder()
    End Sub
#End Region


#Region "CURRENT ORDER"
   

   

    'Public Sub loadCurrentOrder()
    '    LoadXgrid("select * from (SELECT id,0 as subid,1 as mainitem, productid,customorder,productname,quantity,unitcost,unitcost*quantity as total, null as 'add', null as 'less', null as 'cancel' from tbltouchcurrentorder where trnby='" & globalAssistantUserId & "' union all " _
    '              + " select postrn as id, id as subid,0,productid,0,concat('      - ',lcase(productname)),quantity,unitcost,unitcost*quantity as total, null as 'add', null as 'less', null as 'cancel' from tbltouchcurrentordersubitem where trnby='" & globalAssistantUserId & "') as a order by id asc,subid asc;", "tbltouchcurrentorder", Em, GridView1, 3, Me)
    '    XgridHideColumn({"id", "subid", "mainitem", "productid", "customorder"}, GridView1)
    '    XgridColAlign({"quantity"}, GridView1, DevExpress.Utils.HorzAlignment.Center)
    '    XgridColCurrency({"unitcost", "total"}, GridView1)
    '    XgridGeneralSummaryCurrency({"total"}, GridView1)
    '    XgridGeneralSummaryNumber({"quantity"}, GridView1)
    '    GridView1.BestFitColumns()
    '    XgridColWidth({"unitcost", "total"}, GridView1, 120)
    '    XgridColWidth({"quantity", "add", "less", "cancel"}, GridView1, 78)
    '    'GridView1.RowHeight = 40
    '    GridView1.OptionsView.ShowHorzLines = False
    '    XtragridAddButton("add", Em, GridView1)
    '    XtragridAddButton("less", Em, GridView1)
    '    XtragridAddButton("cancel", Em, GridView1)
    '    CountCurrentOrder()


    'End Sub

    'Public Sub CountCurrentOrder()
    '    If Val(CC(GridView1.Columns("quantity").SummaryText)) > 0 Then
    '        cmdCurrentOrder.Visible = True
    '        cmdCurrentOrder.Caption = "Current Order (" & Val(CC(GridView1.Columns("quantity").SummaryText)) & ")"
    '    Else
    '        cmdCurrentOrder.Visible = False
    '    End If
    'End Sub


    'Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
    '    loadCurrentOrder()
    'End Sub

    'Private Sub GridView1_RowCellClick(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs) Handles GridView1.RowCellClick
    '    If e.Column.Name = "coladd" Then
    '        Dim CurrentQuantity As Double = Val(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, GridView1.Columns("quantity")))
    '        Dim CurrentPrice As Double = Val(CC(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, GridView1.Columns("unitcost"))))
    '        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "quantity", CurrentQuantity + 1)
    '        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "total", CurrentPrice * (CurrentQuantity + 1))

    '        If CBool(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, GridView1.Columns("mainitem")).ToString) = True Then
    '            com.CommandText = "UPDATE tbltouchcurrentorder set quantity=" & CurrentQuantity + 1 & " where id='" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, GridView1.Columns("id")).ToString & "' " : com.ExecuteNonQuery()
    '        Else
    '            com.CommandText = "UPDATE tbltouchcurrentordersubitem set quantity=" & CurrentQuantity + 1 & " where id='" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, GridView1.Columns("subid")).ToString & "' " : com.ExecuteNonQuery()
    '        End If
    '    ElseIf e.Column.Name = "colless" Then
    '        Dim CurrentQuantity As Double = Val(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, GridView1.Columns("quantity")))
    '        If CurrentQuantity = 1 Then Exit Sub
    '        Dim CurrentPrice As Double = Val(CC(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, GridView1.Columns("unitcost"))))
    '        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "quantity", CurrentQuantity - 1)
    '        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "total", CurrentPrice * (CurrentQuantity - 1))

    '        If CBool(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, GridView1.Columns("mainitem")).ToString) = True Then
    '            com.CommandText = "UPDATE tbltouchcurrentorder set quantity=" & CurrentQuantity - 1 & " where id='" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, GridView1.Columns("id")).ToString & "' " : com.ExecuteNonQuery()
    '        Else
    '            com.CommandText = "UPDATE tbltouchcurrentordersubitem set quantity=" & CurrentQuantity - 1 & " where id='" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, GridView1.Columns("subid")).ToString & "' " : com.ExecuteNonQuery()
    '        End If

    '    ElseIf e.Column.Name = "colcancel" Then
    '        If XtraMessageBox.Show("Are you sure you want to continue?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
    '            If CBool(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, GridView1.Columns("mainitem")).ToString) = True Then
    '                com.CommandText = "delete from tbltouchcurrentorder where id='" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, GridView1.Columns("id")).ToString & "'" : com.ExecuteNonQuery()
    '                If CBool(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, GridView1.Columns("customorder")).ToString) = True Then
    '                    com.CommandText = "delete from tbltouchcurrentordersubitem where postrn='" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, GridView1.Columns("id")).ToString & "'" : com.ExecuteNonQuery()
    '                End If
    '            Else
    '                com.CommandText = "delete from tbltouchcurrentordersubitem where id='" & GridView1.GetRowCellValue(GridView1.FocusedRowHandle, GridView1.Columns("subid")).ToString & "'" : com.ExecuteNonQuery()
    '            End If
    '            GridView1.DeleteSelectedRows()
    '        End If
    '    End If
    '    CountCurrentOrder()
    'End Sub

    'Private Sub GridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView1.KeyDown
    '    If e.KeyCode() = Keys.Insert Then
    '        If CBool(GridView1.GetFocusedRowCellValue("customorder").ToString) = True Then
    '            frmCustomOrder.productid.Text = GridView1.GetFocusedRowCellValue("productid").ToString
    '            frmCustomOrder.postrn.Text = GridView1.GetFocusedRowCellValue("id").ToString
    '            If frmCustomOrder.Visible = True Then
    '                frmCustomOrder.Focus()
    '            Else
    '                frmCustomOrder.ShowDialog(Me)
    '            End If
    '        End If
    '    ElseIf e.KeyCode() = Keys.R Then
    '        loadCurrentOrder()
    '    End If
    'End Sub

#End Region

End Class