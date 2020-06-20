Imports MySql.Data.MySqlClient

Module Inventory
    Public Function UpdateInventory(ByVal trntype As String, ByVal ponumber As String, ByVal officeid As String, ByVal vendorid As String, ByVal stockhouseid As String, ByVal productid As String, ByVal quantity As Double, ByVal purchaseprice As Double, ByVal remarks As String)
        Dim inventoryMode As String = "" : Dim catid As String = "" : Dim categoryname As String = "" : Dim productname As String = "" : Dim prepaid As Boolean : Dim unit As String = "" : Dim calcsellrate As Double = 0 : Dim sellingprice As Double = 0
        com.CommandText = "select *,(select description from tblprocategory where catid = tblglobalproducts.catid) as category, (select prepaid from tblprocategory where catid = tblglobalproducts.catid) as prepaid from tblglobalproducts where productid='" & productid & "'" : rst = com.ExecuteReader()
        While rst.Read
            catid = rst("catid").ToString
            categoryname = rst("category").ToString
            productname = rst("itemname").ToString + If(rst("partnumber").ToString = "", "", " " + rst("partnumber").ToString)
            unit = rst("unit").ToString
            calcsellrate = Val(rst("calcsellrate").ToString)
            sellingprice = Val(rst("sellingprice").ToString)
            prepaid = rst("prepaid")
        End While
        rst.Close()

        If CBool(qrysingledata("consumable", "consumable", "tblprocategory where catid='" & catid & "'")) = True Then
            'consumable inventory
            inventoryMode = qrysingledata("inventorymethod", "inventorymethod", "tblcompoffice where officeid='" & officeid & "'")
            If inventoryMode = "lifo" Then
                If countqry("tblinventory", "productid='" & productid & "' and officeid='" & officeid & "'") > 0 Then
                    UpdateConsumableInventory(trntype, officeid, stockhouseid, catid, categoryname, productid, productname, prepaid, quantity, unit, purchaseprice, calcsellrate, sellingprice, remarks)
                Else
                    InsertConsumableInventory(trntype, officeid, stockhouseid, catid, categoryname, productid, productname, prepaid, quantity, unit, purchaseprice, calcsellrate, sellingprice, remarks)
                End If
            ElseIf inventoryMode = "fifo" Then
                InsertConsumableInventory(trntype, officeid, stockhouseid, catid, categoryname, productid, productname, prepaid, quantity, unit, purchaseprice, calcsellrate, sellingprice, remarks)
            End If
            com.CommandText = "update tblitemvendor set procost='" & purchaseprice & "',lastupdate=current_timestamp where itemid='" & productid & "' and vendorid = '" & vendorid & "' and officeid='" & officeid & "'" : com.ExecuteNonQuery()
        End If
        Return True
    End Function

    Public Function UpdateFFEInventory(ByVal mode As String, ByVal ffecodeEdit As String, ByVal reference As String, ByVal officeid As String, ByVal stockhouseid As String, ByVal vendorid As String, ByVal productid As String, ByVal quantity As Double, ByVal purchaseprice As Double, ByVal datepurchase As String, ByVal warranty As Boolean, ByVal datewarranty As String, ByVal manualdepreciation As Boolean, ByVal bookvalue As Double, ByVal monthlydep As Double, ByVal deplastupdate As String, ByVal accountableperson As String, ByVal accountablenote As String, ByVal dateissue As String, ByVal flaged As Boolean, ByVal flagedreason As String, ByVal blocked As Boolean, ByVal ffedetails As DataGridView)
        Dim FFEQuery As String = "" : Dim FFEcode As String = "" : Dim catid As String = "" : Dim categoryname As String = "" : Dim productname As String = "" : Dim unit As String = "" : Dim ffetype As String = ""
        com.CommandText = "select *,(select description from tblprocategory where catid = tblglobalproducts.catid) as category from tblglobalproducts where productid='" & productid & "'" : rst = com.ExecuteReader()
        While rst.Read
            catid = rst("catid").ToString
            categoryname = rst("category").ToString
            productname = rst("itemname").ToString + If(rst("partnumber").ToString = "", "", " " + rst("partnumber").ToString)
            unit = rst("unit").ToString
            ffetype = rst("ffetype").ToString
        End While
        rst.Close()

        If mode = "new" Then
            FFEcode = getInventoryFFECodeSequence()
        Else
            FFEcode = ffecodeEdit
        End If
        FFEQuery = "ffecode='" & FFEcode & "', " _
                        + " ffetype='" & ffetype & "', " _
                        + " reference='" & reference & "', " _
                        + " officeid='" & officeid & "', " _
                        + " stockhouseid='" & stockhouseid & "', " _
                        + " productid='" & productid & "', " _
                        + " productname='" & rchar(productname) & "', " _
                        + " catid='" & catid & "', " _
                        + " categoryname='" & rchar(categoryname) & "', " _
                        + " quantity='" & Val(CC(quantity)) & "', " _
                        + " unit='" & unit & "', " _
                        + " unitcost='" & Val(purchaseprice) & "', " _
                        + " totalamount='" & Val(purchaseprice) * Val(quantity) & "', " _
                        + " vendorid='" & vendorid & "', " _
                        + " datepurchased=" & If(datepurchase = "", "current_date", "'" & datepurchase & "'") & "," _
                        + " warranty=" & warranty & ", " _
                        + " warrantydate=" & If(warranty = True And datewarranty <> "", "'" & datewarranty & "'", "null") & ", " _
                        + " manualdepreciation=" & manualdepreciation & ", " _
                        + " bookvalue='" & If(manualdepreciation = True, Val(bookvalue), "0") & "', " _
                        + " monthlydepreciation='" & If(manualdepreciation = True, Val(monthlydep), "0") & "', " _
                        + " lastdepreciationdate=" & If(manualdepreciation = True, "'" & ConvertDate(deplastupdate) & "'", "null") & ", " _
                        + " acctablepersonid='" & accountableperson & "', " _
                        + " acctableperson='" & qrysingledata("fullname", "fullname", "tblaccounts where accountid='" & accountableperson & "'") & "', " _
                        + " acctdateissued=" & If(accountableperson <> "", "'" & dateissue & "'", "null") & ", " _
                        + " flaged=" & flaged & ", " _
                        + " flagedreason='" & rchar(flagedreason) & "', " _
                        + " blocked=" & blocked & ""

        If mode = "new" Then
            com.CommandText = "INSERT INTO tblinventoryffe SET " & FFEQuery & ", trnby='" & globaluserid & "', datetrn=current_timestamp" : com.ExecuteNonQuery()
            LogFFEHistory(FFEcode, "added new inventory via manual entry")
        Else
            com.CommandText = "UPDATE tblinventoryffe SET " & FFEQuery & " where ffecode='" & FFEcode & "'" : com.ExecuteNonQuery()
            LogFFEHistory(FFEcode, "update inventory via manual entry")
        End If

        'Accountable Person Settings
        If countqry("tblinventoryffeaccountable", " ffecode='" & FFEcode & "' and iscurrent=1") = 0 Then
            com.CommandText = "insert into tblinventoryffeaccountable set ffecode='" & FFEcode & "', acctableperson='" & accountableperson & "',accountname='" & qrysingledata("fullname", "fullname", "tblaccounts where accountid='" & accountableperson & "'") & "', dateissued=" & If(dateissue = "", "null", "'" & dateissue & "'") & ", note='" & accountablenote & "', iscurrent=1,issueby='" & globaluserid & "'" : com.ExecuteNonQuery()
            LogFFEHistory(FFEcode, "added accountable person " & StrConv(qrysingledata("fullname", "fullname", "tblaccounts where accountid='" & accountableperson & "'"), vbProperCase) & " date issued on " & If(dateissue = "", "", CDate(dateissue).ToString("MMMM dd, yyyy")) & If(accountablenote.Length > 0, " - " & accountablenote, ""))
        Else
            com.CommandText = "UPDATE tblinventoryffeaccountable set acctableperson='" & accountableperson & "',accountname='" & qrysingledata("fullname", "fullname", "tblaccounts where accountid='" & accountableperson & "'") & "', dateissued=" & If(dateissue = "", "null", "'" & dateissue & "'") & ", note='" & accountablenote & "', issueby='" & globaluserid & "' where ffecode='" & FFEcode & "' and iscurrent=1" : com.ExecuteNonQuery()
            LogFFEHistory(FFEcode, "update accountable person " & StrConv(qrysingledata("fullname", "fullname", "tblaccounts where accountid='" & accountableperson & "'"), vbProperCase) & " date issued on " & CDate(dateissue).ToString("MMMM dd, yyyy") & If(accountablenote.Length > 0, " - " & accountablenote, ""))
        End If

        'If accountableperson <> "" Then
        'Else


        '    'If mode = "new" Then
        '    '    'com.CommandText = "insert into tblinventoryffeaccountable set ffecode='" & FFEcode & "', acctableperson='" & accountableperson & "',accountname='" & qrysingledata("fullname", "fullname", "tblaccounts where accountid='" & accountableperson & "'") & "', dateissued='" & dateissue & "', note='" & accountablenote & "', iscurrent=1,issueby='" & globaluserid & "'" : com.ExecuteNonQuery()
        '    '    'LogFFEHistory(FFEcode, "added accountable person " & StrConv(qrysingledata("fullname", "fullname", "tblaccounts where accountid='" & accountableperson & "'"), vbProperCase) & " date issued on " & CDate(dateissue).ToString("MMMM dd, yyyy") & If(accountablenote.Length > 0, " - " & accountablenote, ""))

        '    'End If
        'End If


        If mode = "new" And countqry("tblglobalproducts", "productid='" & productid & "' and ffetype=''") > 0 Then
            com.CommandText = "UPDATE tblglobalproducts set ffetype='" & ffetype & "' where productid='" & productid & "'" : com.ExecuteNonQuery()
        End If

        'update ffe other details
        Dim otherdetails As String = ""
        If Not ffedetails Is Nothing Then
            Dim UpdateDetails As Boolean = False
            For Each all As DataGridViewRow In ffedetails.Rows
                If all.Cells("Value").Value <> "" Then
                    UpdateDetails = True
                End If
            Next
            If UpdateDetails = True Then
                com.CommandText = "DELETE from tblinventoryffedetails where ffecode='" & FFEcode & "'" : com.ExecuteNonQuery()
                For Each rw As DataGridViewRow In ffedetails.Rows
                    If Not rw.Cells("Description").Value Is Nothing Then
                        com.CommandText = "insert into tblinventoryffedetails set productid='" & productid & "', ffecode='" & FFEcode & "',ffetype='" & ffetype & "',sortorder=" & rw.Cells("sortorder").Value.ToString & ", fieldname='" & rchar(rw.Cells("fieldname").Value.ToString) & "', description='" & rchar(rw.Cells("Description").Value.ToString) & "', value='" & rchar(rw.Cells("Value").Value.ToString) & "',required=" & CBool(rw.Cells("required").Value.ToString) & "" : com.ExecuteNonQuery()
                    End If
                    otherdetails = otherdetails + rchar(rw.Cells("Description").Value.ToString) + ": " + rchar(rw.Cells("Value").Value.ToString) + Chr(13)
                Next
                LogFFEHistory(FFEcode, "update ffe other details " & Chr(13) + Chr(13) + otherdetails)
            End If
        End If
    End Function

    Public Function UpdateDepreciationInventory(ByVal officeid As String)
        Dim dst As New DataSet
        msda = New MySqlDataAdapter("Select *,timestampdiff(month, datepurchased, current_date) as 'AsMonth', " _
                                            + " format(PERIOD_DIFF(date_format(current_date,'%Y%m'),date_format(datepurchased,'%Y%m'))/12,1) as `AsYear`, " _
                                            + " timestampdiff(month, lastdepreciationdate, current_date) as 'manualmonthdelay' " _
                                            + " from tblinventoryffe inner join tbldeprecitionofassets on tblinventoryffe.catid=tbldeprecitionofassets.catid and  tblinventoryffe.ffetype=tbldeprecitionofassets.ffetype where (month(lastdepreciationdate) < month(current_date) or year(lastdepreciationdate) < year(current_date) or lastdepreciationdate is null) and officeid='" & officeid & "'", conn)
        msda.Fill(dst, 0)
        For cnt = 0 To dst.Tables(0).Rows.Count - 1
            With (dst.Tables(0))
                If CBool(.Rows(cnt)("manualdepreciation").ToString()) = True Then
                    com.CommandText = "update tblinventoryffe set age='-', bookvalue=" & Val(CC(DepreciationManual(.Rows(cnt)("bookvalue").ToString(), .Rows(cnt)("monthlydepreciation").ToString(), .Rows(cnt)("manualmonthdelay").ToString()))) & ",lastdepreciationdate=current_date   where ffecode='" & .Rows(cnt)("ffecode").ToString() & "'" : com.ExecuteNonQuery()
                Else
                    If .Rows(cnt)("depmode").ToString() = "0" Then
                        com.CommandText = "update tblinventoryffe set age='" & .Rows(cnt)("AsYear").ToString() & " Year(s)', bookvalue=" & Val(CC(DepreciationReduce(.Rows(cnt)("total").ToString(), .Rows(cnt)("AsYear").ToString(), .Rows(cnt)("depvalue").ToString()))) & ",lastdepreciationdate=current_date  where ffecode='" & .Rows(cnt)("ffecode").ToString() & "'" : com.ExecuteNonQuery()
                    Else
                        com.CommandText = "update tblinventoryffe set age='" & .Rows(cnt)("AsMonth").ToString() & " Month(s)', bookvalue=" & Val(CC(DepreciationStraight(.Rows(cnt)("totalamount").ToString(), .Rows(cnt)("AsMonth").ToString(), .Rows(cnt)("depvalue").ToString()))) & ",monthlydepreciation='" & .Rows(cnt)("totalamount").ToString() / (.Rows(cnt)("depvalue").ToString() * 12) & "', lastdepreciationdate=current_date where ffecode='" & .Rows(cnt)("ffecode").ToString() & "'" : com.ExecuteNonQuery()
                    End If
                End If
            End With
        Next
    End Function

    Public Function DepreciationReduce(ByVal unitcost As Double, ByVal age As Double, ByVal rate As Double) As Double
        DepreciationReduce = unitcost
        For I = 0 To age - 1
            Dim year1depn = DepreciationReduce * (rate / 100)
            DepreciationReduce = DepreciationReduce - year1depn
        Next
        Return DepreciationReduce
    End Function

    Public Function DepreciationStraight(ByVal unitcost As Double, ByVal age As Double, ByVal NumberOfYears As Double) As Double
        Dim value As Double = 0 : Dim bookValue As Double = 0
        If NumberOfYears > 0 Then
            Dim devidedRate = unitcost / (NumberOfYears * 12)
            DepreciationStraight = 0
            Dim asMonth As Double = age
            For I = 0 To asMonth - 1
                DepreciationStraight = DepreciationStraight + devidedRate
            Next
            value = unitcost - DepreciationStraight
            If value > 0 Then
                bookValue = value
            Else
                bookValue = 1
            End If
        Else
            bookValue = 0
        End If
        Return bookValue
    End Function

    Public Function DepreciationManual(ByVal bookedvalue As Double, ByVal monthlydep As Double, ByVal manualmonthdelay As Double) As Double
        Dim newBookedValue As Double = 0
        Dim totaldepreciate As Double = 0
        For I = 0 To manualmonthdelay - 1
            totaldepreciate = totaldepreciate + monthlydep
        Next
        If bookedvalue > totaldepreciate Then
            newBookedValue = bookedvalue - totaldepreciate
        Else
            newBookedValue = 1
        End If
        Return newBookedValue
    End Function

    Public Function InsertConsumableInventory(ByVal trntype As String, ByVal officeid As String, ByVal stockhouseid As String, ByVal catid As String, ByVal categoryname As String, ByVal productid As String, ByVal productname As String, ByVal prepaid As Boolean, ByVal quantity As Double, ByVal unit As String, ByVal purchaseprice As Double, ByVal calcsellrate As Double, ByVal sellingprice As Double, ByVal remarks As String)
        com.CommandText = "INSERT INTO `tblinventory` set officeid='" & officeid & "', " _
                                + " stockhouseid='" & If(stockhouseid = "", "default", stockhouseid) & "', " _
                                + " catid='" & catid & "', " _
                                + " categoryname='" & rchar(categoryname) & "', " _
                                + " productid='" & productid & "', " _
                                + " productname ='" & rchar(productname) & "', " _
                                + " prepaid=" & prepaid & ", " _
                                + " quantity='" & quantity & "', " _
                                + " unit='" & unit & "', " _
                                + " purchasedprice='" & purchaseprice & "', " _
                                + " calcsellrate='" & calcsellrate & "', " _
                                + " sellingprice='" & sellingprice & "', " _
                                + " lastupdate=current_timestamp, " _
                                + " lasttrnby='" & globaluserid & "', " _
                                + " dateinventory=current_timestamp" : com.ExecuteNonQuery()
        com.CommandText = "update tblglobalproducts set purchasedprice='" & purchaseprice & "' where productid='" & productid & "'" : com.ExecuteNonQuery()
        LogInventoryLedger(trntype, officeid, productid, quantity, 0, purchaseprice, remarks)
        Return True
    End Function

    Public Function UpdateConsumableInventory(ByVal trntype As String, ByVal officeid As String, ByVal stockhouseid As String, ByVal catid As String, ByVal categoryname As String, ByVal productid As String, ByVal productname As String, ByVal prepaid As Boolean, ByVal quantity As Double, ByVal unit As String, ByVal purchaseprice As Double, ByVal calcsellrate As Double, ByVal sellingprice As Double, ByVal remarks As String)
        com.CommandText = "UPDATE `tblinventory` set " _
                                + " catid='" & catid & "', " _
                                + " categoryname='" & rchar(categoryname) & "', " _
                                + " productid='" & productid & "', " _
                                + " productname ='" & rchar(productname) & "', " _
                                + " prepaid=" & prepaid & ", " _
                                + " quantity=quantity+" & quantity & ", " _
                                + " unit='" & unit & "', " _
                                + " purchasedprice='" & purchaseprice & "', " _
                                + " calcsellrate='" & calcsellrate & "', " _
                                + " sellingprice='" & sellingprice & "', " _
                                + " lastupdate=current_timestamp, " _
                                + " lasttrnby='" & globaluserid & "' " _
                                + " where productid='" & productid & "' and officeid='" & officeid & "'" : com.ExecuteNonQuery()
        com.CommandText = "update tblglobalproducts set purchasedprice='" & purchaseprice & "' where productid='" & productid & "'" : com.ExecuteNonQuery()
        LogInventoryLedger(trntype, officeid, productid, quantity, 0, purchaseprice, remarks)
        Return True
    End Function

    Public Function LessHotelStockInventory(ByVal trntype As String, ByVal folioid As String, ByVal productid As String, ByVal quantity As Double, ByVal officeid As String, ByVal remarks As String)
        Dim remquantity As Integer = 0
        Dim st = New DataSet
        da = New MySqlDataAdapter("select * from tblinventory where officeid='" & officeid & "'  and productid='" & productid & "' and quantity > 0 order by dateinventory,trnid", conn)
        da.Fill(st, 0)
        For cnt = 0 To st.Tables(0).Rows.Count - 1
            With (st.Tables(0))
                If remquantity = 0 Then
                    If quantity > Val(.Rows(cnt)("quantity").ToString()) Then
                        remquantity = quantity - Val(.Rows(cnt)("quantity").ToString())
                        com.CommandText = "insert into tblhotelroomsamenitieslog set officeid='" & officeid & "', folioid='" & folioid & "', stockno='" & .Rows(cnt)("trnid").ToString() & "', productid='" & .Rows(cnt)("productid").ToString() & "', quantity='" & Val(CC(.Rows(cnt)("quantity").ToString())) & "',purchasedprice='" & Val(CC(.Rows(cnt)("purchasedprice").ToString())) & "'" : com.ExecuteNonQuery()
                        StockoutInventory(trntype, .Rows(cnt)("trnid").ToString(), officeid, .Rows(cnt)("productid").ToString(), Val(CC(.Rows(cnt)("quantity").ToString())), Val(CC(.Rows(cnt)("purchasedprice").ToString())), remarks)
                    Else
                        com.CommandText = "insert into tblhotelroomsamenitieslog set officeid='" & officeid & "', folioid='" & folioid & "', stockno='" & .Rows(cnt)("trnid").ToString() & "', productid='" & .Rows(cnt)("productid").ToString() & "', quantity='" & quantity & "',purchasedprice='" & Val(CC(.Rows(cnt)("purchasedprice").ToString())) & "'" : com.ExecuteNonQuery()
                        StockoutInventory(trntype, .Rows(cnt)("trnid").ToString(), officeid, .Rows(cnt)("productid").ToString(), quantity, Val(CC(.Rows(cnt)("purchasedprice").ToString())), remarks)
                        Exit For
                    End If
                Else
                    If remquantity > Val(.Rows(cnt)("quantity").ToString()) Then
                        remquantity = remquantity - Val(.Rows(cnt)("quantity").ToString())
                        com.CommandText = "insert into tblhotelroomsamenitieslog set officeid='" & officeid & "', folioid='" & folioid & "', stockno='" & .Rows(cnt)("trnid").ToString() & "', productid='" & .Rows(cnt)("productid").ToString() & "', quantity='" & Val(CC(.Rows(cnt)("quantity").ToString())) & "',purchasedprice='" & Val(CC(.Rows(cnt)("purchasedprice").ToString())) & "'" : com.ExecuteNonQuery()
                        StockoutInventory(trntype, .Rows(cnt)("trnid").ToString(), officeid, .Rows(cnt)("productid").ToString(), Val(CC(.Rows(cnt)("quantity").ToString())), Val(CC(.Rows(cnt)("purchasedprice").ToString())), remarks)
                    Else
                        com.CommandText = "insert into tblhotelroomsamenitieslog set officeid='" & officeid & "', folioid='" & folioid & "', stockno='" & .Rows(cnt)("trnid").ToString() & "', productid='" & .Rows(cnt)("productid").ToString() & "', quantity='" & remquantity & "',purchasedprice='" & Val(CC(.Rows(cnt)("purchasedprice").ToString())) & "'" : com.ExecuteNonQuery()
                        StockoutInventory(trntype, .Rows(cnt)("trnid").ToString(), officeid, .Rows(cnt)("productid").ToString(), remquantity, Val(CC(.Rows(cnt)("purchasedprice").ToString())), remarks)
                        Exit For
                    End If
                End If
            End With
        Next
        Return True
    End Function

    Public Function StockoutInventory(ByVal trntype As String, ByVal stocktrnid As String, ByVal officeid As String, ByVal productid As String, ByVal quantity As Double, ByVal unitcost As Double, ByVal remarks As String)
        com.CommandText = "update tblinventory set quantity=quantity-" & quantity & ",lastupdate=current_timestamp where trnid='" & stocktrnid & "';" : com.ExecuteNonQuery()
        LogInventoryLedger(trntype, officeid, productid, 0, quantity, unitcost, remarks)
        Return True
    End Function

    Public Function StockinInventory(ByVal trntype As String, ByVal stocktrnid As String, ByVal officeid As String, ByVal productid As String, ByVal quantity As Double, ByVal unitcost As Double, ByVal remarks As String)
        com.CommandText = "update tblinventory set quantity=quantity+" & quantity & ",lastupdate=current_timestamp where trnid='" & stocktrnid & "';" : com.ExecuteNonQuery()
        LogInventoryLedger(trntype, officeid, productid, quantity, 0, unitcost, remarks)
        Return True
    End Function

    Public Function GetFirstInFirstOutUnitCost(ByVal officeid As String, ByVal productid As String, ByVal quantity As Double) As Array
        Dim GetResultValue(2) As String
        GetResultValue(0) = "Winter"
        GetResultValue(1) = "Bugahod"
        Return GetResultValue
    End Function

    Public Function LogInventoryLedger(ByVal trntype As String, ByVal officeid As String, ByVal productid As String, ByVal debit As Double, ByVal credit As Double, ByVal unitcost As Double, ByVal remarks As String)
        com.CommandText = "insert into tblinventoryledger set officeid='" & officeid & "', productid='" & productid & "', trntype='" & trntype & "', debit=" & debit & ",credit=" & credit & ",cost=" & unitcost & ", remarks='" & rchar(remarks) & "', datetrn=current_timestamp, trnby='" & StrConv(globalfullname, vbProperCase) & "'" : com.ExecuteNonQuery()
        Return True
    End Function

    Public Function LogFFEHistory(ByVal ffecode As String, ByVal remarks As String)
        com.CommandText = "insert into tblinventoryffehistory set ffecode='" & ffecode & "', remarks='" & rchar(remarks) & "', datetrn=current_timestamp, trnby='" & StrConv(globalfullname, vbProperCase) & "',officename='" & compOfficename & "'" : com.ExecuteNonQuery()
        Return True
    End Function
    Public Function getInventoryFFECodeSequence()
        Dim strng As Integer = 0 : Dim newNumber As String = "" : Dim NumberLen As Integer = 0
        com.CommandText = "select cffecodesequence from tblgeneralsettings " : rst = com.ExecuteReader()
        While rst.Read
            NumberLen = rst("cffecodesequence").ToString.Length
            strng = Val(rst("cffecodesequence").ToString) + 1
        End While
        rst.Close()
        If NumberLen > strng.ToString.Length Then
            Dim a As Integer = NumberLen - strng.ToString.Length
            If a = 10 Then
                newNumber = "0000000000" & strng
            ElseIf a = 9 Then
                newNumber = "000000000" & strng
            ElseIf a = 8 Then
                newNumber = "00000000" & strng
            ElseIf a = 7 Then
                newNumber = "0000000" & strng
            ElseIf a = 6 Then
                newNumber = "000000" & strng
            ElseIf a = 5 Then
                newNumber = "00000" & strng
            ElseIf a = 4 Then
                newNumber = "0000" & strng
            ElseIf a = 3 Then
                newNumber = "000" & strng
            ElseIf a = 2 Then
                newNumber = "00" & strng
            ElseIf a = 1 Then
                newNumber = "0" & strng
            Else
                newNumber = strng
            End If
        Else
            newNumber = strng
        End If
        com.CommandText = "update tblgeneralsettings set cffecodesequence='" & newNumber & "' " : com.ExecuteNonQuery()
        Return newNumber
    End Function

    Public Function UpdateInventoryInfo(ByVal productid As String, ByVal productname As String, ByVal catid As String, ByVal unit As String, ByVal sellingprice As Double)
        Dim GetCategoryname As String = qrysingledata("description", "description", "tblprocategory where catid='" & catid & "'")
        com.CommandText = "update tblinventory set productname='" & rchar(productname) & "', catid='" & catid & "', categoryname='" & rchar(GetCategoryname) & "', unit='" & unit & "', sellingprice=" & sellingprice & "  where productid='" & productid & "' and quantity > 0 " : com.ExecuteNonQuery()
    End Function

     
    Public Function AutoProductUnitConvertion(ByVal stockNo As String, ByVal sourceProduct As String, ByVal txtNewQuantity As Double, ByVal txtCurrentUnitCost As Double)
        Dim txtQuantity_s As Double = 0 : Dim txtQuantity_t As Double = 0 : Dim getQuantity As Double = 0 : Dim getUnitCost As Double = 0
        Dim txtConvertQuantity As Double = 0 : Dim txtConvertUnitCost As Double = 0 : Dim productid_converted As String = "" : Dim txtUnitType As String = ""
        com.CommandText = "select *,(select itemname from tblglobalproducts where productid=tblunitconverter.productid_target) as 'productname', (select unit from tblglobalproducts where productid=tblunitconverter.productid_source) as 'unittype' from tblunitconverter where productid_source = '" & sourceProduct & "'"
        rst = com.ExecuteReader
        While rst.Read
            productid_converted = rst("productid_target").ToString
            txtQuantity_s = rst("quantity_source").ToString
            txtQuantity_t = rst("quantity_target").ToString
            txtUnitType = rst("unittype").ToString
        End While
        rst.Close()

        getQuantity = txtQuantity_t / txtQuantity_s
        txtConvertQuantity = getQuantity * txtNewQuantity

        getUnitCost = Val(CC(txtCurrentUnitCost)) * txtQuantity_s
        txtConvertUnitCost = FormatNumber(getUnitCost / txtQuantity_t)

        UpdateInventory("Auto Unit Convertion", "", compOfficeid, "", "", productid_converted, txtConvertQuantity, txtConvertUnitCost, "Converted from " & LCase(txtUnitType) & "Stock#" & stockNo)
    End Function

    'Inventory script
    'UpdateInventory("Purchase order", GridView1.GetFocusedRowCellValue("trnid").ToString, .Rows(cnt)("officeid").ToString(), .Rows(cnt)("vendorid").ToString(), "", .Rows(cnt)("productid").ToString(), Val(CC(.Rows(cnt)("quantity").ToString())), Val(CC(.Rows(cnt)("cost").ToString())), "Purchase Order #" + GridView1.GetFocusedRowCellValue("trnid").ToString)
    'StockoutInventory("Inventory Stockout", id.Text, officeid.Text, productid, Val(CC(txtquantity.Text)), txtRemarks.Text)

    Public Sub PrintTransmittal(ByVal detail As String, ByVal newbatchcode As String, ByVal txtOfficeName As String, ByVal txtRequestedBy As String, ByVal txtDateRequested As String)
        Dim details As String = ""
        details = PageHeader()
        details += Environment.NewLine & PrintCenterText("T R A N S M I T T A L") & Environment.NewLine & Environment.NewLine
        details += PrintLeftText("TRN #: " & newbatchcode) & Environment.NewLine
        details += PrintLeftText("From: " & compOfficename) & Environment.NewLine
        details += PrintLeftText("To: " & txtOfficeName) & Environment.NewLine
        details += PrintLeftText("Requested By: " & txtRequestedBy) & Environment.NewLine
        details += PrintLeftText("Date Requested: " & txtDateRequested) & Environment.NewLine
        details += PrintLeftText("Processed By: " & globalfullname) & Environment.NewLine
        details += PrintLeftText("Date Transmittal: " & CDate(Now).ToString) & Environment.NewLine
        details += PrintLeftText("Note: " & detail) & Environment.NewLine
        details += PrintSpaceLine() & Environment.NewLine
        Dim totalitem As Double = 0

        'For Each rw As DataGridViewRow In MyDataGridView.SelectedRows
        '    details += PrintLeftRigthText(rw.Cells("Particular").Value.ToString & " - " & rw.Cells("Unit").Value.ToString, FormatNumber(rw.Cells("Quantity").Value.ToString, 2)) & Environment.NewLine
        '    totalitem = totalitem + 1
        'Next
        Dim total As Double = 0
        com.CommandText = "select *,sum(quantity) as ttl,(select itemname from tblglobalproducts where productid =tbltransferitem.itemid) as product,(select unit from tblglobalproducts where productid =tbltransferitem.itemid) as unit from tbltransferitem where batchcode='" & newbatchcode & "' group by itemid,unitcost" : rst = com.ExecuteReader
        While rst.Read
            details += PrintLeftText(rst("product").ToString) & Environment.NewLine
            details += PrintLeftRigthText("  - " & FormatNumber(rst("ttl").ToString, 4) & "@" & FormatNumber(rst("unitcost").ToString, 2) & " " & rst("unit").ToString, FormatNumber(Val(rst("unitcost").ToString) * Val(rst("ttl").ToString), 2)) & Environment.NewLine
            totalitem = totalitem + 1
            total = total + Val(rst("unitcost").ToString) * Val(rst("ttl").ToString)
        End While
        rst.Close()

        details += Environment.NewLine
        details += PrintLeftRigthText("Total Item", FormatNumber(totalitem, 2)) & Environment.NewLine
        details += PrintLeftRigthText("Total Cost", FormatNumber(total, 2)) & Environment.NewLine
        details += PrintSpaceLine() & Environment.NewLine
        details += PrintCenterText("- E N D   R E P O R T -") & Environment.NewLine & Environment.NewLine & Environment.NewLine
        details += PrintCenterText("Received By:") & Environment.NewLine & Environment.NewLine & Environment.NewLine & Environment.NewLine & Environment.NewLine
        details += PrintCenterText("Signature Over Printed Name")
        details += LastPagepaper()

        POSPrint(details, newbatchcode, "Stock Transfer\" & CDate(Now.ToShortDateString()).ToString("yyyy-MM-dd"))

    End Sub



    Public Function ReceivedTransfer(ByVal batchcode As String)
        If countqry("(select sum(quantity) as quantity,(select quantity from tblinventory where trnid=tbltransferitem.refcode) as available from tbltransferitem where batchcode='" & batchcode & "' group by refcode) as a", "quantity > available") > 0 Then
            MessageBox.Show("There was a descrepancy item count on your stock transfer inventory! please report this error to your IT Department.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        Dim inventory_from As String = "" : Dim inventory_to As String = "" : Dim transfer_from_officename As String = "" : Dim transfer_to_officename As String = ""
        com.CommandText = "select *,(select officename from tblcompoffice where officeid=tbltransferbatch.inventory_from) as transfer_from_officename,(select officename from tblcompoffice where officeid=tbltransferbatch.inventory_to) as transfer_to_officename from tbltransferbatch where batchcode='" & batchcode & "'" : rst = com.ExecuteReader
        While rst.Read
            inventory_from = rst("inventory_from").ToString
            inventory_to = rst("inventory_to").ToString
            transfer_from_officename = rst("transfer_from_officename").ToString
            transfer_to_officename = rst("transfer_to_officename").ToString
        End While
        rst.Close()

        dststock = Nothing : dststock = New DataSet
        msdastock = New MySqlDataAdapter("Select * from tbltransferitem where batchcode='" & batchcode & "'", conn)
        msdastock.Fill(dststock, 0)
        For stockcount = 0 To dststock.Tables(0).Rows.Count - 1
            With (dststock.Tables(0))
                'If countqry("tblunitconverter", "productid_source = '" & .Rows(cnt)("itemid").ToString() & "' and autoconvert=1") > 0 Then
                '    AutoProductUnitConvertion(.Rows(cnt)("refcode").ToString(), .Rows(cnt)("itemid").ToString(), Val(CC(.Rows(cnt)("quantity").ToString())), Val(CC(.Rows(cnt)("unitcost").ToString())))
                'End If
                UpdateInventory("Transfer stock", "", inventory_to, "", "", .Rows(stockcount)("itemid").ToString(), Val(CC(.Rows(stockcount)("quantity").ToString())), Val(CC(.Rows(stockcount)("unitcost").ToString())), "Received from " + LCase(transfer_from_officename))
                StockoutInventory("Transfer stock", .Rows(stockcount)("refcode").ToString(), inventory_from, .Rows(stockcount)("itemid").ToString(), Val(CC(.Rows(stockcount)("quantity").ToString())), Val(CC(.Rows(stockcount)("unitcost").ToString())), "Transfer to " + LCase(transfer_to_officename))
            End With
        Next
        com.CommandText = "update tbltransferbatch set confirmed=1, confirmedby='" & globaluserid & "', dateconfirmed=current_timestamp where batchcode='" & batchcode & "'" : com.ExecuteNonQuery()
        Return True
    End Function
End Module
