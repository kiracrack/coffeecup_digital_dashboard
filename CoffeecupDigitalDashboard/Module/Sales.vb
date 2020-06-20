Imports MySql.Data.MySqlClient

Module Sales
    Public Function TrapTransaction(ByVal cifid As String, ByVal txtBatchcode As String, ByVal productid As String, ByVal txtQuantity As Double) As Boolean
        If cifid = "" Then
            MessageBox.Show("Please select client!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If
        If cifid = "" Then
            MsgBox("Please select client!", MsgBoxStyle.Exclamation, "Error Message")
            Return False

            '#filter if transaction already void
        ElseIf CInt(countqry("tblsalesbatch", "batchcode='" & txtBatchcode & "' and void")) > 0 Then
            MsgBox("Error accessing this transaction! " & Chr(13) & Chr(13) & "Transaction already void by " & qrysingledata("name", "(select fullname from tblaccounts where accountid=tblsalesbatch.userid) as name", "tblsalesbatch where batchcode='" & txtBatchcode & "'").ToString & "! Your transaction will be cancelled.", MsgBoxStyle.Critical, "Error Message")
            Return False

            '#FIlter Fuel Products
        ElseIf CInt(countqry("tblsalesfuelpump", "productid = '" & productid & "'")) > 0 And CInt(countqry("tblclientaccounts", "cifid='" & cifid & "' and walkinaccount=1")) > 0 And EnableModuleFuel = True Then
            MsgBox("Fuel transaction not allowed for walk-in client!", MsgBoxStyle.Exclamation, "Error Message")
            Return False

            '#Check if product access available
        ElseIf CInt(countqry("tblglobalproducts inner join tblproductfilter on tblglobalproducts.catid = tblproductfilter.categorycode", "tblproductfilter.permissioncode='" & globalAuthcode & "' and deleted=0 and tblglobalproducts.productid='" & productid & "' and enablesell=1")) = 0 And GlobalenableProductFilter = True Then
            MsgBox("Product access denied! Please contact your system administrator!", MsgBoxStyle.Exclamation, "Error Message")
            Return False

            '#Check product inventory
        ElseIf CInt(countqry("tblinventory", "productid='" & productid & "' and officeid='" & compOfficeid & "'")) = 0 And CInt(countqry("tblglobalproducts", "productid='" & productid & "' and forcontract=0")) > 0 And compEnableInventory = True Then
            MsgBox("Product inventory not available!", MsgBoxStyle.Exclamation, "Error Message")
            Return False

            '#Check inventory quantity
        ElseIf CInt(countqry("tblinventory", "quantity >= " & txtQuantity & " and productid='" & productid & "' and officeid='" & compOfficeid & "'")) = 0 And CInt(countqry("tblglobalproducts", "productid='" & productid & "' and forcontract=0")) > 0 And compEnableInventory = True Then
            MsgBox("Maximum of Product quantity is " & qrysingledata("quantity", "quantity", "tblinventory where productid='" & productid & "'  and officeid='" & compOfficeid & "'").ToString & "!", MsgBoxStyle.Exclamation, "Error Message")
        End If

        If CInt(countqry("tblglobalproducts", "productid='" & productid & "' and forcontract=1 and menuitem=1 ")) > 0 Then
            '#Check product memu maker inventory
            If CInt(countqry("tblglobalproducts", "productid='" & productid & "' and forcontract=1 and menuitem=1 ")) > 0 And CInt(countqry("tblproductmenuitem", "source_productid='" & productid & "'")) = 0 Then
                MsgBox("Product menu item not available or currently not configured!", MsgBoxStyle.Exclamation, "Error Message")
                Return False
            End If
            If GlobalEnableStrictMenuMakerInventory = True Then
                Dim ProductTrap As String = ""
                msda = Nothing : dst = New DataSet
                msda = New MySqlDataAdapter("select * from tblproductmenuitem where source_productid='" & productid & "'", conn)
                msda.Fill(dst, 0)
                For cnt = 0 To dst.Tables(0).Rows.Count - 1
                    With (dst.Tables(0))
                        If Val(qrysingledata("ttlquantity", "sum(quantity) as ttlquantity", "tblinventory where productid='" & .Rows(cnt)("productid").ToString() & "' and officeid='" & compOfficeid & "'")) < (Val(.Rows(cnt)("quantity").ToString()) * Val(txtQuantity)) Then
                            ProductTrap = ProductTrap + (Val(.Rows(cnt)("quantity").ToString()) * Val(txtQuantity)).ToString + " " + .Rows(cnt)("unit").ToString() + " - " + qrysingledata("itemname", "itemname", "tblglobalproducts where productid='" & .Rows(cnt)("productid").ToString() & "'").ToString + Chr(13)
                        End If
                    End With
                Next

                If ProductTrap.Length > 0 Then
                    MessageBox.Show("Some product menu item inventory not available or insufficient! " & Environment.NewLine & Environment.NewLine & "Required details below: " & Environment.NewLine & Environment.NewLine + ProductTrap, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End If
            End If
        End If
        Return True
    End Function

    Public Sub PostSalesTransaction(ByVal cifid As String, ByVal batchcode As String, ByVal productid As String, ByVal quantity As Double, ByVal unitprice As Double, ByVal chitprice As Double, ByVal parameter As String)
        Dim ckNonInventoryItem As Boolean = False
        If compEnableInventory = True Then
            ckNonInventoryItem = CBool(qrysingledata("forcontract", "forcontract", "tblglobalproducts where productid='" & productid & "'"))
        Else
            ckNonInventoryItem = True
        End If

        Dim remquantity As Double = 0
        msda = Nothing : dst = New DataSet
        If ckNonInventoryItem = True Then
            msda = New MySqlDataAdapter("select *,if(servicemenuproduct=1,ifnull((select sum(amount) from tblproductserviceitem where source_productid=tblglobalproducts.productid),sellingprice),sellingprice) as sellprice, itemname as productname from tblglobalproducts where productid='" & productid & "'", conn)
        Else
            msda = New MySqlDataAdapter("select *,(select allownegativeinputs from tblglobalproducts where productid=tblinventory.productid) as allownegativeinputs, (select salemode from tblglobalproducts where productid=tblinventory.productid) as salemode,(select allowinputdiscountedamount from tblglobalproducts where productid=tblinventory.productid) as allowinputdiscountedamount, sellingprice as sellprice from tblinventory where productid='" & productid & "'  and officeid='" & compOfficeid & "' and quantity > 0 order by dateinventory,trnid", conn)
        End If
        msda.Fill(dst, 0)
        For cnt = 0 To dst.Tables(0).Rows.Count - 1
            With (dst.Tables(0))
                If .Rows(cnt)("salemode").ToString() = "esba" And CBool(.Rows(cnt)("allownegativeinputs").ToString()) = False Then
                    If Val(.Rows(cnt)("sellprice").ToString()) <> Val(CC(unitprice)) And CBool(.Rows(cnt)("allowinputdiscountedamount").ToString()) = False And Val(.Rows(cnt)("sellprice").ToString()) > 0 Then
                        quantity = Val(CC(unitprice)) / Val(.Rows(cnt)("sellprice").ToString())
                    End If
                End If

                'FILTER DISCOUNT
                Dim Discount As Double = 0 : Dim Charges As Double = 0
                Charges = CDbl(GetChargeValue(.Rows(cnt)("catid").ToString(), Val(.Rows(cnt)("sellprice").ToString())))

                Discount = GetTotalDiscount(.Rows(cnt)("catid").ToString(), .Rows(cnt)("productid").ToString(), Val(CC(quantity)), Val(.Rows(cnt)("sellprice").ToString()), Val(CC(unitprice)), cifid, qrysingledata("salemode", "salemode", "tblglobalproducts where productid='" & productid & "'"))
                'FILTER CHARGES SETTINGS
                If Discount < 0 Then
                    Charges = Charges + Val(Discount.ToString.Replace("-", ""))
                    Discount = 0
                End If

                Dim prevQuantity As Double = 0
                If ckNonInventoryItem = False Then
                    prevQuantity = Val(.Rows(cnt)("quantity").ToString())

                    If Val(.Rows(cnt)("sellprice").ToString()) = 0 Then
                        com.CommandText = "update tblglobalproducts set sellingprice='" & Val(CC(unitprice)) & "' where productid='" & .Rows(cnt)("productid").ToString() & "' limit 1" : com.ExecuteNonQuery()
                        com.CommandText = "update tblinventory set sellingprice='" & Val(CC(unitprice)) & "' where trnid='" & .Rows(cnt)("trnid").ToString() & "' limit 1" : com.ExecuteNonQuery()
                    End If

                    If remquantity = 0 Then
                        If Val(CC(quantity)) > Val(.Rows(cnt)("quantity").ToString()) Then
                            remquantity = Val(CC(quantity)) - Val(.Rows(cnt)("quantity").ToString())
                            InsertSalesTransaction(cifid, batchcode, True, .Rows(cnt)("trnid").ToString(), "", "", .Rows(cnt)("productid").ToString(), rchar(.Rows(cnt)("productname").ToString()), Val(CC(.Rows(cnt)("quantity").ToString())), Val(CC(prevQuantity)), .Rows(cnt)("catid").ToString(), .Rows(cnt)("unit").ToString(), .Rows(cnt)("purchasedprice").ToString(), chitprice, .Rows(cnt)("sellprice").ToString(), (Val(.Rows(cnt)("sellprice").ToString()) + Charges) - Discount, Discount, Discount * Val(.Rows(cnt)("quantity").ToString()), Charges, Charges * Val(CC(.Rows(cnt)("quantity").ToString())), GlobalTaxRate, ((GlobalTaxRate / 100) * ((Val(.Rows(cnt)("sellprice").ToString()) + Charges) - Discount)) * Val(CC(.Rows(cnt)("quantity").ToString())), GlobalServiceChargeRate, ((GlobalServiceChargeRate / 100) * ((Val(.Rows(cnt)("sellprice").ToString()) + Charges) - Discount)) * Val(CC(.Rows(cnt)("quantity").ToString())), Val(.Rows(cnt)("sellprice").ToString()) * Val(.Rows(cnt)("quantity").ToString()), ((Val(.Rows(cnt)("sellprice").ToString()) + Charges) - Discount) * Val(.Rows(cnt)("quantity").ToString()), (((Val(.Rows(cnt)("sellprice").ToString()) + Charges) - Discount) * Val(.Rows(cnt)("quantity").ToString())) - (Val(.Rows(cnt)("purchasedprice").ToString()) * Val(.Rows(cnt)("quantity").ToString())), parameter)
                        Else
                            InsertSalesTransaction(cifid, batchcode, True, .Rows(cnt)("trnid").ToString(), "", "", .Rows(cnt)("productid").ToString(), rchar(.Rows(cnt)("productname").ToString()), Val(CC(quantity)), Val(CC(prevQuantity)), .Rows(cnt)("catid").ToString(), .Rows(cnt)("unit").ToString(), .Rows(cnt)("purchasedprice").ToString(), chitprice, .Rows(cnt)("sellprice").ToString(), (Val(.Rows(cnt)("sellprice").ToString()) + Charges) - Discount, Discount, Discount * Val(quantity), Charges, Charges * Val(CC(quantity)), GlobalTaxRate, ((GlobalTaxRate / 100) * ((Val(.Rows(cnt)("sellprice").ToString()) + Charges) - Discount)) * Val(CC(quantity)), GlobalServiceChargeRate, ((GlobalServiceChargeRate / 100) * ((Val(.Rows(cnt)("sellprice").ToString()) + Charges) - Discount)) * Val(CC(quantity)), Val(.Rows(cnt)("sellprice").ToString()) * Val(quantity), ((Val(.Rows(cnt)("sellprice").ToString()) + Charges) - Discount) * Val(quantity), (((Val(.Rows(cnt)("sellprice").ToString()) + Charges) - Discount) * Val(quantity)) - (Val(.Rows(cnt)("purchasedprice").ToString()) * Val(quantity)), parameter)
                            Exit For
                        End If
                    Else
                        If remquantity > Val(.Rows(cnt)("quantity").ToString()) Then
                            remquantity = remquantity - Val(.Rows(cnt)("quantity").ToString())
                            InsertSalesTransaction(cifid, batchcode, True, .Rows(cnt)("trnid").ToString(), "", "", .Rows(cnt)("productid").ToString(), rchar(.Rows(cnt)("productname").ToString()), Val(CC(.Rows(cnt)("quantity").ToString())), Val(CC(prevQuantity)), .Rows(cnt)("catid").ToString(), .Rows(cnt)("unit").ToString(), .Rows(cnt)("purchasedprice").ToString(), chitprice, .Rows(cnt)("sellprice").ToString(), (Val(.Rows(cnt)("sellprice").ToString()) + Charges) - Discount, Discount, Discount * Val(.Rows(cnt)("quantity").ToString()), Charges, Charges * Val(CC(.Rows(cnt)("quantity").ToString())), GlobalTaxRate, ((GlobalTaxRate / 100) * ((Val(.Rows(cnt)("sellprice").ToString()) + Charges) - Discount)) * Val(CC(.Rows(cnt)("quantity").ToString())), GlobalServiceChargeRate, ((GlobalServiceChargeRate / 100) * ((Val(.Rows(cnt)("sellprice").ToString()) + Charges) - Discount)) * Val(CC(.Rows(cnt)("quantity").ToString())), Val(.Rows(cnt)("sellprice").ToString()) * Val(.Rows(cnt)("quantity").ToString()), ((Val(.Rows(cnt)("sellprice").ToString()) + Charges) - Discount) * Val(.Rows(cnt)("quantity").ToString()), (((Val(.Rows(cnt)("sellprice").ToString()) + Charges) - Discount) * Val(.Rows(cnt)("quantity").ToString())) - (Val(.Rows(cnt)("purchasedprice").ToString()) * Val(.Rows(cnt)("quantity").ToString())), parameter)
                        Else
                            InsertSalesTransaction(cifid, batchcode, True, .Rows(cnt)("trnid").ToString(), "", "", .Rows(cnt)("productid").ToString(), rchar(.Rows(cnt)("productname").ToString()), Val(CC(remquantity)), Val(CC(prevQuantity)), .Rows(cnt)("catid").ToString(), .Rows(cnt)("unit").ToString(), .Rows(cnt)("purchasedprice").ToString(), chitprice, .Rows(cnt)("sellprice").ToString(), (Val(.Rows(cnt)("sellprice").ToString()) + Charges) - Discount, Discount, Discount * Val(remquantity), Charges, Charges * Val(CC(remquantity)), GlobalTaxRate, ((GlobalTaxRate / 100) * ((Val(.Rows(cnt)("sellprice").ToString()) + Charges) - Discount)) * Val(CC(remquantity)), GlobalServiceChargeRate, ((GlobalServiceChargeRate / 100) * ((Val(.Rows(cnt)("sellprice").ToString()) + Charges) - Discount)) * Val(CC(remquantity)), Val(.Rows(cnt)("sellprice").ToString()) * Val(remquantity), ((Val(.Rows(cnt)("sellprice").ToString()) + Charges) - Discount) * Val(remquantity), (((Val(.Rows(cnt)("sellprice").ToString()) + Charges) - Discount) * Val(remquantity)) - (Val(.Rows(cnt)("purchasedprice").ToString()) * Val(remquantity)), parameter)
                            Exit For
                        End If
                    End If
                Else
                    Dim TotalPurchasePrice As Double = 0
                    If CBool(.Rows(cnt)("menuitem").ToString()) = True Or CBool(.Rows(cnt)("servicemenuproduct").ToString()) = True Then
                        'process menumaker services item
                        Dim menumakerrefService As String = ""
                        If CBool(.Rows(cnt)("servicemenuproduct").ToString()) = True Then
                            menumakerrefService = getManuMakerServiceSequence()
                            da = Nothing : st = New DataSet
                            da = New MySqlDataAdapter("select *,(select itemname from tblglobalproducts where productid=tblproductserviceitem.productid) as 'itemname', " _
                                                      + " ifnull((select enablecoupon from tblglobalproducts where productid=tblproductserviceitem.productid),0) as enablecoupon, " _
                                                      + " (select unit from tblglobalproducts where productid=tblproductserviceitem.productid) as unit, " _
                                                      + " (select officecenter from tblglobalproducts where productid=tblproductserviceitem.productid) as officecenter " _
                                                      + " from tblproductserviceitem where source_productid='" & .Rows(cnt)("productid").ToString() & "'", conn)
                            da.Fill(st, 0)
                            For nt = 0 To st.Tables(0).Rows.Count - 1
                                com.CommandText = "insert into tblsalesmenumakerservice set officeid='" & compOfficeid & "', refnumber='" & menumakerrefService & "',productid='" & st.Tables(0).Rows(nt)("productid").ToString() & "', productname='" & rchar(st.Tables(0).Rows(nt)("itemname").ToString()) & "', quantity='" & Val(quantity) & "', amount='" & st.Tables(0).Rows(nt)("amount").ToString() & "', total='" & Val(st.Tables(0).Rows(nt)("amount").ToString()) * Val(quantity) & "', salesofficeid='" & If(st.Tables(0).Rows(nt)("officecenter").ToString() = "", compOfficeid, st.Tables(0).Rows(nt)("officecenter").ToString()) & "'" : com.ExecuteNonQuery()
                                If CBool(st.Tables(0).Rows(nt)("enablecoupon").ToString()) = True Then
                                    InsertProductCoupon("POS", batchcode, If(st.Tables(0).Rows(nt)("officecenter").ToString() = "", compOfficeid, st.Tables(0).Rows(nt)("officecenter").ToString()), st.Tables(0).Rows(nt)("productid").ToString(), Val(quantity), st.Tables(0).Rows(nt)("unit").ToString(), st.Tables(0).Rows(nt)("amount").ToString(), Val(st.Tables(0).Rows(nt)("amount").ToString()) * Val(quantity), CDate(Now.ToShortDateString))
                                End If
                            Next
                        End If

                        'process menumaker inventory item
                        Dim menumakerrefItem As String = ""
                        If CBool(.Rows(cnt)("menuitem").ToString()) = True Then
                            menumakerrefItem = getManuMakerSequence()
                            da_manumaker = Nothing : st_menumaker = New DataSet
                            da_manumaker = New MySqlDataAdapter("select *,(select itemname from tblglobalproducts where productid=tblproductmenuitem.productid) as productname from tblproductmenuitem where source_productid='" & .Rows(cnt)("productid").ToString() & "'", conn)
                            da_manumaker.Fill(st_menumaker, 0)
                            For nt = 0 To st_menumaker.Tables(0).Rows.Count - 1
                                remquantity = 0 : Dim purchasePrice As Double = 0
                                If Globalenablemenumakerinventory = True Then
                                    Dim deductQuantity As Double = st_menumaker.Tables(0).Rows(nt)("quantity").ToString() * Val(quantity)
                                    msda2 = Nothing : dst2 = New DataSet
                                    msda2 = New MySqlDataAdapter("select * from tblinventory where officeid='" & compOfficeid & "'  and productid='" & st_menumaker.Tables(0).Rows(nt)("productid").ToString() & "' and quantity>0 order by dateinventory,trnid", conn)
                                    msda2.Fill(dst2, 0)
                                    Dim xnt = 0
                                    For xnt = 0 To dst2.Tables(0).Rows.Count - 1
                                        If remquantity = 0 Then
                                            If deductQuantity > Val(dst2.Tables(0).Rows(xnt)("quantity").ToString()) Then
                                                remquantity = deductQuantity - Val(dst2.Tables(0).Rows(xnt)("quantity").ToString())
                                                'remquantity = 0
                                                purchasePrice += dst2.Tables(0).Rows(xnt)("purchasedprice").ToString() * Val(CC(dst2.Tables(0).Rows(xnt)("quantity").ToString()))
                                                com.CommandText = "insert into tblsalesmenumakerstockout set  trnsumcode='" & globalSalesTrnCOde & "', postingdate='" & ConvertDate(globalTransactionDate) & "',batchcode='" & Trim(batchcode) & "', officeid='" & compOfficeid & "', refnumber='" & menumakerrefItem & "', stockno='" & dst2.Tables(0).Rows(xnt)("trnid").ToString() & "', productid='" & dst2.Tables(0).Rows(xnt)("productid").ToString() & "', productname='" & dst2.Tables(0).Rows(xnt)("productname").ToString() & "', quantity='" & deductQuantity & "',unit='" & dst2.Tables(0).Rows(xnt)("unit").ToString() & "', purchasedprice='" & Val(CC(dst2.Tables(0).Rows(xnt)("purchasedprice").ToString())) & "'" : com.ExecuteNonQuery()
                                                StockoutInventory("POS Sold", dst2.Tables(0).Rows(xnt)("trnid").ToString(), compOfficeid, dst2.Tables(0).Rows(xnt)("productid").ToString(), deductQuantity, Val(CC(dst2.Tables(0).Rows(xnt)("purchasedprice").ToString())), "#" + batchcode + " (Menu maker Item)")
                                            Else
                                                purchasePrice += dst2.Tables(0).Rows(xnt)("purchasedprice").ToString() * deductQuantity
                                                com.CommandText = "insert into tblsalesmenumakerstockout set trnsumcode='" & globalSalesTrnCOde & "',postingdate='" & ConvertDate(globalTransactionDate) & "',batchcode='" & Trim(batchcode) & "', officeid='" & compOfficeid & "', refnumber='" & menumakerrefItem & "', stockno='" & dst2.Tables(0).Rows(xnt)("trnid").ToString() & "', productid='" & dst2.Tables(0).Rows(xnt)("productid").ToString() & "', productname='" & dst2.Tables(0).Rows(xnt)("productname").ToString() & "', quantity='" & deductQuantity & "', unit='" & dst2.Tables(0).Rows(xnt)("unit").ToString() & "',  purchasedprice='" & Val(CC(dst2.Tables(0).Rows(xnt)("purchasedprice").ToString())) & "'" : com.ExecuteNonQuery()
                                                StockoutInventory("POS Sold", dst2.Tables(0).Rows(xnt)("trnid").ToString(), compOfficeid, dst2.Tables(0).Rows(xnt)("productid").ToString(), deductQuantity, Val(CC(dst2.Tables(0).Rows(xnt)("purchasedprice").ToString())), "#" + batchcode + " (Menu maker Item)")
                                                Exit For
                                            End If
                                        Else
                                            If remquantity > Val(dst2.Tables(0).Rows(xnt)("quantity").ToString()) Then
                                                remquantity = remquantity - Val(dst2.Tables(0).Rows(xnt)("quantity").ToString())
                                                purchasePrice += dst2.Tables(0).Rows(xnt)("purchasedprice").ToString() * Val(CC(dst2.Tables(0).Rows(xnt)("quantity").ToString()))
                                                com.CommandText = "insert into tblsalesmenumakerstockout set trnsumcode='" & globalSalesTrnCOde & "',postingdate='" & ConvertDate(globalTransactionDate) & "',batchcode='" & Trim(batchcode) & "', officeid='" & compOfficeid & "', refnumber='" & menumakerrefItem & "', stockno='" & dst2.Tables(0).Rows(xnt)("trnid").ToString() & "', productid='" & dst2.Tables(0).Rows(xnt)("productid").ToString() & "', productname='" & dst2.Tables(0).Rows(xnt)("productname").ToString() & "', quantity='" & Val(CC(dst2.Tables(0).Rows(xnt)("quantity").ToString())) & "', unit='" & dst2.Tables(0).Rows(xnt)("unit").ToString() & "', purchasedprice='" & Val(CC(dst2.Tables(0).Rows(xnt)("purchasedprice").ToString())) & "'" : com.ExecuteNonQuery()
                                                StockoutInventory("POS Sold", dst2.Tables(0).Rows(xnt)("trnid").ToString(), compOfficeid, dst2.Tables(0).Rows(xnt)("productid").ToString(), Val(CC(dst2.Tables(0).Rows(xnt)("quantity").ToString())), Val(CC(dst2.Tables(0).Rows(xnt)("purchasedprice").ToString())), "#" + batchcode + " (Menu maker Item)")
                                            Else
                                                purchasePrice += dst2.Tables(0).Rows(xnt)("purchasedprice").ToString() * remquantity
                                                com.CommandText = "insert into tblsalesmenumakerstockout set trnsumcode='" & globalSalesTrnCOde & "',postingdate='" & ConvertDate(globalTransactionDate) & "',batchcode='" & Trim(batchcode) & "', officeid='" & compOfficeid & "', refnumber='" & menumakerrefItem & "', stockno='" & dst2.Tables(0).Rows(xnt)("trnid").ToString() & "', productid='" & dst2.Tables(0).Rows(xnt)("productid").ToString() & "',productname='" & dst2.Tables(0).Rows(xnt)("productname").ToString() & "', quantity='" & remquantity & "',unit='" & dst2.Tables(0).Rows(xnt)("unit").ToString() & "', purchasedprice='" & Val(CC(dst2.Tables(0).Rows(xnt)("purchasedprice").ToString())) & "'" : com.ExecuteNonQuery()
                                                StockoutInventory("POS Sold", dst2.Tables(0).Rows(xnt)("trnid").ToString(), compOfficeid, dst2.Tables(0).Rows(xnt)("productid").ToString(), remquantity, Val(CC(dst2.Tables(0).Rows(xnt)("purchasedprice").ToString())), "#" + batchcode + " (Menu maker Item)")
                                                Exit For
                                            End If
                                        End If
                                    Next
                                Else
                                    purchasePrice += st_menumaker.Tables(0).Rows(nt)("cost").ToString() * Val(CC(st_menumaker.Tables(0).Rows(nt)("quantity").ToString()))
                                    com.CommandText = "insert into tblsalesmenumakerstockout set trnsumcode='" & globalSalesTrnCOde & "',postingdate='" & ConvertDate(globalTransactionDate) & "',batchcode='" & Trim(batchcode) & "', officeid='" & compOfficeid & "', refnumber='" & menumakerrefItem & "', stockno='-', productid='" & st_menumaker.Tables(0).Rows(nt)("productid").ToString() & "', productname='" & st_menumaker.Tables(0).Rows(nt)("productname").ToString() & "', quantity='" & st_menumaker.Tables(0).Rows(nt)("quantity").ToString() & "',unit='" & st_menumaker.Tables(0).Rows(nt)("unit").ToString() & "', purchasedprice='" & Val(CC(st_menumaker.Tables(0).Rows(nt)("cost").ToString())) & "'" : com.ExecuteNonQuery()
                                End If
                                TotalPurchasePrice += purchasePrice
                            Next
                        End If

                        TotalPurchasePrice = TotalPurchasePrice / Val(quantity)
                        InsertSalesTransaction(cifid, batchcode, False, "0", menumakerrefItem, menumakerrefService, .Rows(cnt)("productid").ToString(), rchar(.Rows(cnt)("productname").ToString()), Val(CC(quantity)), "0", .Rows(cnt)("catid").ToString(), .Rows(cnt)("unit").ToString(), TotalPurchasePrice, chitprice, .Rows(cnt)("sellprice").ToString(), (Val(.Rows(cnt)("sellprice").ToString()) + Charges) - Discount, Discount, Discount * Val(quantity), Charges, Charges * Val(CC(quantity)), GlobalTaxRate, ((GlobalTaxRate / 100) * ((Val(.Rows(cnt)("sellprice").ToString()) + Charges) - Discount)) * Val(CC(quantity)), GlobalServiceChargeRate, ((GlobalServiceChargeRate / 100) * ((Val(.Rows(cnt)("sellprice").ToString()) + Charges) - Discount)) * Val(CC(quantity)), Val(.Rows(cnt)("sellprice").ToString()) * Val(quantity), ((Val(.Rows(cnt)("sellprice").ToString()) + Charges) - Discount) * Val(quantity), (((Val(.Rows(cnt)("sellprice").ToString()) + Charges) - Discount) * Val(quantity)) - (Val(TotalPurchasePrice) * Val(quantity)), parameter)
                    Else
                        InsertSalesTransaction(cifid, batchcode, False, "0", "", "", .Rows(cnt)("productid").ToString(), rchar(.Rows(cnt)("productname").ToString()), Val(CC(quantity)), Val(CC(prevQuantity)), .Rows(cnt)("catid").ToString(), .Rows(cnt)("unit").ToString(), .Rows(cnt)("purchasedprice").ToString(), chitprice, .Rows(cnt)("sellprice").ToString(), (Val(.Rows(cnt)("sellprice").ToString()) + Charges) - Discount, Discount, Discount * Val(quantity), Charges, Charges * Val(CC(quantity)), GlobalTaxRate, ((GlobalTaxRate / 100) * ((Val(.Rows(cnt)("sellprice").ToString()) + Charges) - Discount)) * Val(CC(quantity)), GlobalServiceChargeRate, ((GlobalServiceChargeRate / 100) * ((Val(.Rows(cnt)("sellprice").ToString()) + Charges) - Discount)) * Val(CC(quantity)), Val(.Rows(cnt)("sellprice").ToString()) * Val(quantity), ((Val(.Rows(cnt)("sellprice").ToString()) + Charges) - Discount) * Val(quantity), (((Val(.Rows(cnt)("sellprice").ToString()) + Charges) - Discount) * Val(quantity)) - (Val(.Rows(cnt)("purchasedprice").ToString()) * Val(quantity)), parameter)
                    End If
                End If
            End With
            UpdateTransactionHeader(cifid, batchcode)
        Next
    End Sub
    Public Sub UpdateTransactionHeader(ByVal cifid As String, ByVal batchcode As String)
        Dim txtTotalItem As Double = countqry("tblsalestransaction", "batchcode='" & batchcode & "' and cancelled=0")
        Dim txtTotalCancelled As Double = FormatNumber(Val(qrysingledata("ttl", "count(*) as 'ttl'", "tblsalestransaction where batchcode='" & batchcode & "' and cancelled=1")), 2)
        Dim txtTotalDiscount As Double = FormatNumber(Val(qrysingledata("total", "sum(distotal) as 'total'", "tblsalestransaction where batchcode='" & batchcode & "' and cancelled=0")), 2)
        Dim txtTotalCharge As Double = FormatNumber(Val(qrysingledata("total", "sum(chargetotal) as 'total'", "tblsalestransaction where batchcode='" & batchcode & "' and cancelled=0")), 2)
        Dim txtTotalTax As Double = FormatNumber(Val(qrysingledata("total", "sum(taxtotal) as 'total'", "tblsalestransaction where batchcode='" & batchcode & "' and cancelled=0")), 2)
        Dim txtServiceCharge As Double = FormatNumber(Val(qrysingledata("total", "sum(svchargetotal) as 'total'", "tblsalestransaction where batchcode='" & batchcode & "' and cancelled=0")), 2)
        Dim txtSubTotal As Double = FormatNumber(Val(qrysingledata("total", "sum(subtotal) as 'total'", "tblsalestransaction where batchcode='" & batchcode & "' and cancelled=0")), 2)
        Dim txtTotalChit As Double = FormatNumber(Val(qrysingledata("total", "sum(chittotal) as 'total'", "tblsalestransaction where batchcode='" & batchcode & "' and cancelled=0")), 2)
        Dim txtTotalOnScreen As Double = FormatNumber(Val(qrysingledata("total", "sum(total) as 'total'", "tblsalestransaction where batchcode='" & batchcode & "' and cancelled=0")), 2)
        Dim netincome As Double = qrysingledata("totalincome", "ifnull(sum(income),0) as 'totalincome'", "tblsalestransaction where batchcode='" & Trim(batchcode) & "' and void=0 and cancelled=0")
        Dim chittotal As Double = qrysingledata("chit_total", "ifnull(sum(chittotal),0) as 'chit_total'", "tblsalestransaction where batchcode='" & Trim(batchcode) & "' and void=0 and cancelled=0")
        If countqry("tblsalesbatch", "batchcode='" & Trim(batchcode) & "'") = 0 Then
            com.CommandText = "insert into tblsalesbatch set trnsumcode='" & globalSalesTrnCOde & "', " _
                                    + " userid='" & globalTransactionUserid & "', " _
                                    + " batchcode='" & Trim(batchcode) & "', " _
                                    + " officeid='" & compOfficeid & "', " _
                                    + " cifid='" & cifid & "', " _
                                    + " totalitem='" & Val(CC(txtTotalItem)) & "', " _
                                    + " totalitemcancelled='" & Val(CC(txtTotalCancelled)) & "', " _
                                    + " totaldiscount='" & Val(CC(txtTotalDiscount)) & "', " _
                                    + " totalcharge='" & Val(CC(txtTotalCharge)) & "', " _
                                    + " totaltax='" & Val(CC(txtTotalTax)) & "', " _
                                    + " totalsvcharge='" & Val(CC(txtServiceCharge)) & "', " _
                                    + " subtotal='" & Val(CC(txtSubTotal)) & "', " _
                                    + " chittotal=" & chittotal & "," _
                                    + If(chittotal > 0, "chittrn=1,", "chittrn=0, ") _
                                    + " total='" & Val(CC(txtTotalOnScreen)) & "', " _
                                    + " totalincome='" & netincome & "', " _
                                    + " floattrn=1, " _
                                    + " attendingperson = '" & globalAssistantUserId & "', " _
                                    + " datetrn=" & If(globalBackDateTransaction = True, "concat('" & ConvertDate(globalBackDate) & "',' ',current_time)", "current_timestamp") & "" : com.ExecuteNonQuery()
        Else
            com.CommandText = "update tblsalesbatch set trnsumcode='" & globalSalesTrnCOde & "', " _
                                   + " officeid='" & compOfficeid & "', " _
                                   + " cifid='" & cifid & "', " _
                                   + " totalitem='" & Val(CC(txtTotalItem)) & "', " _
                                   + " totalitemcancelled='" & Val(CC(txtTotalCancelled)) & "', " _
                                   + " totaldiscount='" & Val(CC(txtTotalDiscount)) & "', " _
                                   + " totalcharge='" & Val(CC(txtTotalCharge)) & "', " _
                                   + " totaltax='" & Val(CC(txtTotalTax)) & "', " _
                                   + " totalsvcharge='" & Val(CC(txtServiceCharge)) & "', " _
                                   + " subtotal='" & Val(CC(txtSubTotal)) & "', " _
                                   + " chittotal=" & chittotal & "," _
                                   + If(chittotal > 0, "chittrn=1,", "chittrn=0, ") _
                                   + " total='" & Val(CC(txtTotalOnScreen)) & "', " _
                                   + " totalincome='" & netincome & "', " _
                                   + " floattrn=1, " _
                                   + " attendingperson = '" & globalAssistantUserId & "', " _
                                   + " datetrn=" & If(globalBackDateTransaction = True, "concat('" & ConvertDate(globalBackDate) & "',' ',current_time)", "current_timestamp") & " " _
                                   + " where batchcode='" & Trim(batchcode) & "'" : com.ExecuteNonQuery()
        End If
    End Sub
    Public Function InsertSalesTransaction(ByVal cifid As String, ByVal batchcode As String, ByVal deductInventory As Boolean, ByVal inventorytrnid As String, ByVal menumakerstockref As String, ByVal menumakerserviceref As String, ByVal productid As String, _
                                                                              ByVal productname As String, ByVal quantity As Double, ByVal prevquantity As Double, ByVal catid As String, _
                                                                              ByVal unit As String, ByVal purchasedprice As Double, Chitprice As Double, ByVal originalsellprice As Double, ByVal sellprice As Double, ByVal disrate As Double, _
                                                                              ByVal distotal As Double, ByVal chargerate As Double, ByVal chargetotal As Double, ByVal taxrate As Double, ByVal taxtotal As Double, _
                                                                              ByVal svchargerate As Double, svchargetotal As Double, ByVal subtotal As Double, ByVal total As Double, ByVal income As Double, ByVal parameter As String)
        Dim vatitem As Boolean = False
        Dim svcitem As Boolean = False
        Dim enableofficecenter As Boolean = False
        Dim officecenter As String = ""
        Dim enableCoupon As Boolean = False
        Dim customproductorder As Boolean = False
        Dim requiredattendingpersonnel As Boolean = False
        Dim updaterequired As Boolean = False
        com.CommandText = "select * from tblglobalproducts where productid='" & productid & "' limit 1" : rst = com.ExecuteReader
        While rst.Read
            vatitem = rst("vatableitem")
            svcitem = rst("svchargeitem")
            enableofficecenter = rst("enablecenter")
            officecenter = rst("officecenter").ToString
            enableCoupon = rst("enablecoupon")
            customproductorder = rst("customproductorder")
            requiredattendingpersonnel = rst("requiredattendingpersonnel")
            updaterequired = rst("updaterequired")
        End While
        rst.Close()

        If vatitem = False Then
            taxtotal = 0
        End If

        If svcitem = False Then
            svchargetotal = 0
        End If

        If countqry("tblclientaccounts", "cifid='" & cifid & "' and creditlimit=1") > 0 Then
            Dim txtClient As String = qrysingledata("companyname", "companyname", "cifid='" & cifid & "'")
            Dim remainingcredit As Double = Val(qrysingledata("creditlimitamount", "creditlimitamount", "tblclientaccounts where cifid='" & cifid & "'")) - (Val(qrysingledata("totaldue", "sum(debit)-sum(credit) as totaldue", "tblglaccountledger where accountno='" & cifid & "' and cancelled=0")) + Val(qrysingledata("amount", "amount", "tblsalesclientcharges where accountno='" & cifid & "' and verified=0 and cancelled=0")) + Val(qrysingledata("ttl", "sum(total) as ttl", "tblsalestransaction where cifid='" & cifid & "' and cancelled=0 and void=0 and batchcode='" & batchcode & "'")))
            If remainingcredit < sellprice Then
                MessageBox.Show(txtClient & " has only " & FormatNumber(remainingcredit, 2) & " available from credit limit! Transaction cannot be continue", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            ElseIf remainingcredit < Val(qrysingledata("total", "sum(total) as 'total'", "tblsalestransaction where batchcode='" & batchcode & "' and tblsalestransaction.cancelled=0")) Then
                MessageBox.Show(txtClient & " has only " & FormatNumber(remainingcredit, 2) & " available from credit limit! Transaction cannot be continue", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End If
        End If

        com.CommandText = "insert into tblsalestransaction set trnsumcode='" & globalSalesTrnCOde & "', " _
                                  + " postingdate='" & ConvertDate(globalTransactionDate) & "', " _
                                  + " inventory=" & deductInventory & ", " _
                                  + " inventorytrnid='" & inventorytrnid & "', " _
                                  + " menumakerstockref='" & menumakerstockref & "', " _
                                  + " menumakerserviceref='" & menumakerserviceref & "', " _
                                  + " userid='" & globalTransactionUserid & "', " _
                                  + " batchcode='" & Trim(batchcode) & "', " _
                                  + " officeid='" & compOfficeid & "', " _
                                  + " cifid='" & cifid & "', " _
                                  + " productid='" & productid & "', " _
                                  + " productname='" & productname & "', " _
                                  + " customproductorder=" & customproductorder & "," _
                                  + " quantity='" & quantity & "', " _
                                  + " prevquantity='" & prevquantity & "', " _
                                  + " catid='" & catid & "', " _
                                  + " unit='" & rchar(unit) & "', " _
                                  + " purchasedprice=" & purchasedprice & ", " _
                                  + " originalsellprice=" & originalsellprice & ", " _
                                  + " chitsellprice=" & If(Chitprice > 0, Val(CC(Chitprice)) - sellprice, 0) & ", " _
                                  + " sellprice=" & sellprice & ", " _
                                  + " disrate=" & disrate & ", " _
                                  + " distotal=" & If(sellprice < 0, 0, distotal) & ", " _
                                  + " chargerate='" & chargerate & "', " _
                                  + " chargetotal='" & chargetotal & "', " _
                                  + " taxrate=" & taxrate & ", " _
                                  + " taxtotal=" & taxtotal & ", " _
                                  + " svchargerate='" & svchargerate & "', " _
                                  + " svchargetotal='" & svchargetotal & "', " _
                                  + " subtotal=" & subtotal & ", " _
                                  + " chittotal=" & If(Chitprice > 0, (Val(CC(Chitprice)) * Val(quantity)) - (total + If(GlobalTaxAddtoTotal = True, taxtotal, 0) + If(GlobalSvAddtoTotal = True, svchargetotal, 0)), 0) & ", " _
                                  + " total='" & total + If(GlobalTaxAddtoTotal = True, taxtotal, 0) + If(GlobalSvAddtoTotal = True, svchargetotal, 0) & "'," _
                                  + " income=" & If(purchasedprice = 0, total + If(GlobalTaxAddtoTotal = True, taxtotal, 0) + If(GlobalSvAddtoTotal = True, svchargetotal, 0), income) & ", " _
                                  + " attendingperson='" & globalAssistantUserId & "', " _
                                  + " datetrn=" & If(globalBackDateTransaction = True, "concat('" & ConvertDate(globalBackDate) & "',' ',current_time)", "current_timestamp") _
                                  + parameter : com.ExecuteNonQuery()

        If updaterequired = True Or originalsellprice = 0 And total > 0 Then
            com.CommandText = "Update tblglobalproducts set sellingprice='" & Val(CC(sellprice)) & "',allowinputdiscountedamount=0, updaterequired=0,dateupdated=current_timestamp,updatedby='" & globaluserid & "' where productid='" & productid & "' and deleted=0 " : com.ExecuteNonQuery()
            com.CommandText = "update tblinventory set sellingprice='" & Val(CC(sellprice)) & "' where productid='" & productid & "' and quantity > 0 " : com.ExecuteNonQuery()
        End If

        'End If
        If enableofficecenter = True Then
            If enableCoupon = True Then
                If officecenter <> compOfficeid Then
                    InsertProductCoupon("POS", batchcode, officecenter, productid, quantity, unit, sellprice, total + If(GlobalTaxAddtoTotal = True, taxtotal, 0) + If(GlobalSvAddtoTotal = True, svchargetotal, 0), CDate(Now.ToShortDateString))
                End If
            End If
        End If

        '#update inventory
        If deductInventory = True Then
            StockoutInventory("POS Sold", inventorytrnid, compOfficeid, productid, quantity, purchasedprice, "Sales Batchcode #" + batchcode)
        End If
        Return True
    End Function


    Public Function GetChargeValue(ByVal catid As String, ByVal sellingprice As Double)
        Dim strTotalCharges As Double = 0
        'check the default client discount
        If countqry("tblclientcharges", "catid='" & catid & "'") > 0 Then
            'processesing client product charges
            com.CommandText = "select * from tblclientcharges where catid='" & catid & "' and enable=1" : rst = com.ExecuteReader()
            While rst.Read
                If LCase(rst("chargestype").ToString) = "percent" Then
                    strTotalCharges = (Val(rst("chargesrate").ToString) / 100) * sellingprice
                Else
                    strTotalCharges = rst("chargesrate").ToString
                End If
            End While
            rst.Close()
        End If
        Return strTotalCharges
    End Function

    Public Function GetTotalDiscount(ByVal catid As String, ByVal productid As String, ByVal quant As Double, ByRef originalSellingCost As Double, ByVal AmountTender As Double, ByVal clientid As String, ByVal salemode As String) As Double
        GetTotalDiscount = 0
        If CBool(qrysingledata("skipdiscount", "skipdiscount", "tblclientaccounts where cifid='" & clientid & "'")) = False Then
            Dim allowinputdiscountedamount As Boolean = CBool(qrysingledata("allowinputdiscountedamount", "allowinputdiscountedamount", "tblglobalproducts where productid='" & rchar(productid) & "'"))
            Dim GetCIFGroup As String = qrysingledata("groupcode", "groupcode", "tblclientaccounts where cifid='" & clientid & "'")
            If countqry("tblclientdiscounts", "catid='" & catid & "' and cifid='" & GetCIFGroup & "'") > 0 Or countqry("tblproductdiscounts", "productid='" & productid & "'") > 0 Then
                GetTotalDiscount = GetDiscountValue(clientid, GetCIFGroup, catid, productid, originalSellingCost, originalSellingCost * quant)
            Else
                If allowinputdiscountedamount = True Or GlobalProductTemplate = 4 Or salemode = "esba" Then
                    GetTotalDiscount = originalSellingCost - Val(CC(AmountTender))
                End If
            End If
        End If

        Return GetTotalDiscount
    End Function

    Public Function GetDiscountValue(ByVal cifid As String, ByVal cifgroup As String, ByVal catid As String, ByVal productid As String, ByVal sellingprice As Double, ByVal totalamount As Double)
        Dim strTotalDiscount As Double = 0
        'check the default client discount

        If countqry("tblclientdiscounts", "catid='" & catid & "' and cifid='" & cifgroup & "'") > 0 Then
            'check discount if the product discount are affect to the client
            If countqry("tblproductdiscounts", "productid='" & productid & "' and affectclient=1") > 0 Then
                'processesing default product discount
                com.CommandText = "select * from tblproductdiscounts where productid='" & productid & "'" : rst = com.ExecuteReader()
                While rst.Read
                    If rst("incondition") = True Then
                        If Val(totalamount) >= Val(rst("amount").ToString) Then
                            If LCase(rst("discounttype").ToString) = "percent" Then
                                strTotalDiscount = (Val(rst("discountrate").ToString) / 100) * sellingprice
                            Else
                                strTotalDiscount = rst("discountrate").ToString
                            End If
                        End If
                    Else
                        If LCase(rst("discounttype").ToString) = "percent" Then
                            strTotalDiscount = (Val(rst("discountrate").ToString) / 100) * sellingprice
                        Else
                            strTotalDiscount = rst("discountrate").ToString
                        End If
                    End If
                End While
                rst.Close()
            Else
                'processesing client product discount
                com.CommandText = "select * from tblclientdiscounts where catid='" & catid & "' and cifid='" & cifgroup & "'" : rst = com.ExecuteReader()
                While rst.Read
                    If LCase(rst("discounttype").ToString) = "percent" Then
                        strTotalDiscount = (Val(rst("discountrate").ToString) / 100) * sellingprice
                    Else
                        strTotalDiscount = rst("discountrate").ToString
                    End If
                End While
                rst.Close()
            End If
        Else
            If countqry("tblclientaccounts", "cifid='" & cifid & "' and walkinaccount=1") = 0 Then
                If countqry("tblproductdiscounts", "productid='" & productid & "'") > 0 Then
                    'processesing client product discount
                    com.CommandText = "select * from tblproductdiscounts where productid='" & productid & "'" : rst = com.ExecuteReader()
                    While rst.Read
                        If rst("incondition") = True Then
                            If Val(totalamount) >= Val(rst("amount").ToString) Then
                                If LCase(rst("discounttype").ToString) = "percent" Then
                                    strTotalDiscount = (Val(rst("discountrate").ToString) / 100) * sellingprice
                                Else
                                    strTotalDiscount = rst("discountrate").ToString
                                End If
                            End If
                        Else
                            If LCase(rst("discounttype").ToString) = "percent" Then
                                strTotalDiscount = (Val(rst("discountrate").ToString) / 100) * sellingprice
                            Else
                                strTotalDiscount = rst("discountrate").ToString
                            End If
                        End If
                    End While
                    rst.Close()
                End If
            End If
        End If
        Return strTotalDiscount
    End Function
    Public Sub InsertProductCoupon(ByVal trntype As String, ByVal batchcode As String, ByVal centerofficeid As String, ByVal productid As String, ByVal quantity As Double, ByVal unit As String, ByVal unitprice As String, ByVal total As String, ByVal coupondate As String)
        com.CommandText = "insert into tblsalescoupon set couponcode='" & getCouponSequence() & "', trntype ='" & trntype & "', trnsumcode='" & globalSalesTrnCOde & "', batchcode='" & batchcode & "', trnofficeid='" & compOfficeid & "', centerofficeid='" & centerofficeid & "', productid='" & productid & "', quantity='" & quantity & "', unit='" & unit & "', unitprice='" & unitprice & "', total='" & total & "',coupondate='" & ConvertDate(coupondate) & "', datetrn=current_timestamp,trnby='" & globaluserid & "'" : com.ExecuteNonQuery()
    End Sub



End Module
