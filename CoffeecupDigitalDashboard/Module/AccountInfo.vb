Imports System.IO
Imports MySql.Data.MySqlClient

Module AccountInfo
    Public screenHeight As Integer
    Public screenWidth As Integer
    Public screenres As String

    'Declaration of module
    Public EnableModuleProcurement As Boolean
    Public EnableModuleInventory As Boolean
    Public EnableModuleSales As Boolean
    Public EnableModuleFuel As Boolean
    Public EnableModuleHR As Boolean
    Public EnableModulePayroll As Boolean
    Public EnableModuleHotel As Boolean
    Public EnableModuleClinic As Boolean
    Public EnableModuleReportGen As Boolean
    Public GlobalNumberOfPOS As Integer = 0
    Public GlobalNumberOfDevision As Integer = 0
    Public EnableRetainersMode As Boolean

    Public SystemEngineCode As String
    Public SystemModule As String
    Public SystemDate As String
    Public SystemExpiryDate As String

    'Declaration of user accounts
    Public globaluserid As String
    Public globalTransactionUserid As String
    Public globalfullname As String
    Public globalNickName As String
    Public globalposition As String
    Public globalEmailaddress As String
    Public globalcontact As String
    Public globalusername As String
    Public globalCoffeecupUser As Boolean
    Public globalpermissioncode As String
    Public globalBegginingCash As Double
    Public globalAssistantUserId As String
    Public globalAssistantFullName As String
    Public globalIconfolder As String
    Public globalBgColor As String
    Public globalFontColor As String
    Public globalUserRequiredUpdateInfo As String

    'Permission
    Public globalAdminApprover As Boolean
    Public globalAdminAllowAdd As Boolean
    Public globalAdminAllowEdit As Boolean
    Public globalAdminAllowDelete As Boolean

    'Declaration of user authority
    Public globalAuthcode As String
    Public globalAuthDescription As String
    Public globalCorporateApprover As Boolean
    Public globalapproveanyoffices As Boolean
    Public globalBranchApprover As Boolean
    Public globalAuthAdvanceSearch As Boolean
    Public globalAuthReminders As Boolean
    Public globalAuthForApproval As Boolean
    Public globalAuthApprovalHistory As Boolean
    Public globalAuthVoidTransaction As Boolean
    Public globalAuthPointofSale As Boolean
    Public globalAuthVIP As Boolean
    Public globalAuthPointofSaleAssistant As Boolean
    Public globalAuthCashChange As Boolean
    Public globalAuthPostExpense As Boolean
    Public globalAuthAccountsJournalEntries As Boolean
    Public globalAuthClientAccountsTransaction As Boolean
    Public globalAuthJournalEntries As Boolean
    Public globalAuthClientAccountsPayment As Boolean
    Public globalAuthsalesdelivery As Boolean
    Public globalAuthOtherTransaction As Boolean
    Public globalAuthReturnitem As Boolean
    Public globalAuthAutoServices As Boolean
    Public globalAuthClinicServices As Boolean
    Public globalAuthPumpReading As Boolean
    Public globalAuthEmployeeAttendance As Boolean
    Public globalAuthComplaintBox As Boolean
    Public globalAuthNewRequisition As Boolean
    Public globalAuthPurchaseOrder As Boolean
    Public globalAuthAccountsPayable As Boolean
    Public globalAuthReceivingofGoods As Boolean
    Public globalAuthReceivingTransfer As Boolean
    Public globalAuthRequisitionManagement As Boolean
    Public globalAuthInventoryManagement As Boolean
    Public globalAuthTransferManagement As Boolean
    Public globalAuthStockoutManagement As Boolean
    Public globalAuthAssetsManagement As Boolean
    Public globalAuthTablesAndCottages As Boolean
    Public globalAuthHotelReservation As Boolean
    Public globalAuthHotelManagement As Boolean
    Public globalAuthRoomOccupancy As Boolean
    Public globalAuthHouseKeeping As Boolean
    Public globalAuthReportGenerator As Boolean

    'Declaration of company profile
    Public GlobalCompanyid As String
    'Public GlobalOrganizationCode As String
    Public GlobalOrganizationInitialCode As String
    Public GlobalOrganizationName As String
    Public GlobalOrganizationAddress As String
    Public GlobalOrganizationEmail As String
    Public GlobalOrganizationWebsite As String
    Public GlobalOrganizationLogoURL As String
    Public GlobalOrganizationContactNumber As String
    Public GlobalOrganization_KB As Boolean
    Public GlobalTinNumber As String
    Public GlobalPermitNumber As String
    Public GlobalMiNumber As String
    Public GlobalSNumber As String
    Public GlobalTaxRate As Double = 0
    Public GlobalTaxAddtoTotal As Boolean
    Public GlobalServiceChargeRate As Double = 0
    Public GlobalSvAddtoTotal As Boolean
    Public GlobalPosReceiptType As String
    Public compkb As String


    'Declaration of Office profile
    Public compCompanyExist As Boolean
    Public compOfficeid As String
    Public compOfficename As String
    Public compAddress As String
    Public compEmailaddress As String
    Public compOfficerid As String
    Public compOfficerIncharge As String
    Public compOfficerEmail As String
    Public compOfficerPosition As String

    Public compposproductioncopy As Boolean
    Public compposfoodcheckercopy As Boolean
    Public compposbutcherycopy As Boolean
    Public compposcustomercopy As Boolean
    Public compposcashiercopy As Boolean



    Public compCorporateoffice As Boolean
    Public allowbegginingInventory As Boolean
    Public custombranchapproval As Boolean
    Public customcorporateapproval As Boolean
    Public compInventoryMethod As String
    Public allowmanualffeinventory As Boolean
    Public compallowmanageffeotheroffice As Boolean
    Public compallowmanagconsumableotheroffice As Boolean
    Public compallowcreaterequestforotheroffice As Boolean
    Public compEnableInventory As Boolean
    Public compAllowreceivedpurchases As Boolean

    'Declaration of general settings
    Public globalregby As String
    Public GlobalAllowableAttachSize As Double
    Public GlobalPOExpiry As Integer
    Public BeginningVendor As Boolean
    Public BeginningVendorName As String
    Public BeginningVendorid As String
    Public GlobalDirectApprovedPr As Boolean
    Public GlobalDirectApprovedPo As Boolean
    Public GlobalDirectProductRegistration As Boolean
    Public GlobalEnableBarcode As Boolean
    Public GlobalDownloadDefaultLocation As String
    Public GlobalApproverName As String
    Public GlobalApproverPosition As String
    Public Globalclientlogofilename As String
    Public GlobalenableProductFilter As Boolean
    Public Globalenablecashiersassistant As Boolean
    Public Globalenablesalesassistant As Boolean
    Public Globalenableupdatesalesamount As Boolean
    Public Globalenablesalesdirectproductregister As Boolean
    Public Globaldefaultsalespersonpermission As String
    Public Globalenablechittransaction As Boolean
    Public Globalenableprintrecieptcashier As Boolean
    Public Globalenablesaleinvoicenumber As Boolean
    Public GLobalenabledirectapprovedclient As Boolean
    Public Globalenableacknowlegedchargetoaccountremarks As Boolean
    Public GlobalProductTemplate As Integer
    Public GlobalStrictadminconfirmed As Boolean
    Public Globalchargeinvoicetemplate As String
    Public Globalchargeinvoicettitle As String
    Public GLobalchargeinvoicessequence As Boolean
    Public Globalclientjournaltemplate As String
    Public Globalclientjournaltitle As String
    Public GLobalclientjournalsequence As Boolean
    Public Globalsalesdeliverytemplate As String
    Public Globalsalesdeliverytitle As String
    Public GLobalsalesdeliverysequence As Boolean
    Public GLobalhotelfoliosequence As Boolean
    Public Globalhotelcheckouttime As DateTime
    Public Globalhotelreservationexpiry As Integer
    Public GLobalhotelreceiptsequence As Boolean
    Public Globalenableclientfilter As Boolean
    Public Globalenablebackdatetrn As Boolean
    Public Globalenablectaadvancepayment As Boolean
    Public GLobalAutoServicesSequence As Boolean
    Public GlobalEnableCashierReportSummaryView As Boolean
    Public Globalenableposcashdrawer As Boolean
    Public GLobalEnableViewSalesCashendreport As Boolean
    Public GLobalEmailNotifyAutoServices As Boolean
    Public GlobalProcurementEmailAddress As String
    Public GlobalWalkinAccountName As String
    Public GlobalWalkinAccountCIFCode As String
    Public GlobalStrictApproverSignature As Boolean
    Public GlobalEnableProcurementPolicy As Boolean
    Public GlobalEnableClientAccounts As Boolean
    Public Globalallowprocessorcreateclientaccounts As Boolean
    Public Globalenablehousekeepingmonitoring As Boolean
    Public Globalenablehotelmaintainanceuponcheckout As Boolean
    Public Globalhotelmaintainancedefaultstatus As String
    Public GlobalShowsalesreportemailcaptionasoffice As Boolean
    Public Globalenablestrictffedetails As Boolean
    Public GlobalEnableVouchernumbersequence As Boolean
    Public GlobalHotelhousekeepingid As String
    Public GlobalEnableQueuingSlip As Boolean
    Public GlobalQueuingSlipType As String
    Public GlobalQueuingProductCategory As String
    Public GlobalEnableStrictMenuMakerInventory As Boolean
    Public Globalallowreceivedexceedingpoamount As Boolean
    Public Globalduetosequenceno As String
    Public GlobalAllowchangeitempo As Boolean
    Public Globalallowaccessallonhold As Boolean
    Public Globalhoteldefaultcheckinstatuscode As String
    Public Globalhoteldefaultvacantstatuscode As String
    Public Globalrequiredpostoclosed As Boolean
    Public GlobalEnableVoucherPaymentPosting As Boolean
    Public Globalcustomorderproductcategory As String
    Public Globalenablecombinepossalesquantity As Boolean
    Public Globalenableposviewrowborder As Boolean
    Public Globalenableposviewcolborder As Boolean
    Public GlobalReportTemplate As String
    Public Globaldefaultroomoccupieddirty As String
    Public Globalhotelitemizedcharge As Boolean
    Public GlobalEnableBookingroomblocking As Boolean
    Public Globalenablehoteldayafterrevenue As Boolean
    Public Globaldefaultroomstatuschangeroom As String
    Public Globalenabledirectinventorytransferconfirmed As Boolean
    Public Globalflexiblehotelrate As Boolean
    Public Globalenablestocktransferclearing As Boolean
    Public Globalenablemenumakerinventory As Boolean

    'Declaration of email settings
    Public globalEmailNotification As Boolean
    Public globalsmtpHost As String
    Public globalsmtpPort As String
    Public globalsslEnable As String
    Public globalserverEmailAddress As String
    Public globaltargetEmailAddress As String
    Public globalemailPassword As String

    'Declaration of sales settings
    Public globalSalesOpentrn As Boolean
    Public globalSalesTrnCOde As String
    Public globalBackDateTransaction As Boolean
    Public globalTransactionDate As Date
    Public globalBackDate As Date
    Public globalBackDateRemarks As String

    'Declaration of POS sales transaction
    'Public GlobalPOSGlTransactionCode As String
    'Public GlobalPOSBeginningCash As Double
    'Public GlobalPOSBeginningCashFrom As String
    'Public GlobalGLExpensesCode As String
    'Public GlobalGLIncomeCode As String
    'Public GlobalGLAccountReceivable As String
    'Public GlobalPaymentGLItemCode As String
    'Public GlobalPaymentDiscountGLItemCode As String
    'Public GlobalGLVoucherCode As String
    'Public GLobalGLItemPurchaseOrder As String

    'Declaration of POS number encryption
    Public GlobalEnableEncryptNumbers As Boolean
    Public GlobalEncrptVal1 As String
    Public GlobalEncrptVal2 As String
    Public GlobalEncrptVal3 As String
    Public GlobalEncrptVal4 As String
    Public GlobalEncrptVal5 As String
    Public GlobalEncrptVal6 As String
    Public GlobalEncrptVal7 As String
    Public GlobalEncrptVal8 As String
    Public GlobalEncrptVal9 As String
    Public GlobalEncrptVal0 As String

    'Filters
    Public GlobalHotelCif As String

    Public Sub check_win()
        screenHeight = My.Computer.Screen.Bounds.Height
        screenWidth = My.Computer.Screen.Bounds.Width
        screenres = "236," + screenHeight
    End Sub

    Public Function LoadAccountDetails(ByVal userid As String)
        com.CommandText = "select *,(select officename from tblcompoffice where officeid=tblaccounts.officeid) as Officename, " _
                                + " (select officeemail from tblcompoffice where officeid=tblaccounts.officeid) as officemail " _
                                + "  from tblaccounts where accountid='" & userid & "'" : rst = com.ExecuteReader
        While rst.Read
            globalTransactionUserid = userid
            compOfficeid = rst("officeid").ToString
            globalfullname = rst("fullname").ToString
            globalNickName = rst("nickname").ToString
            globalposition = StrConv(rst("designation").ToString, vbProperCase)
            globalusername = rst("username").ToString
            globalpermissioncode = Val(rst("permission").ToString)
            globalCoffeecupUser = rst("coffeecupuser")
            globalEmailaddress = rst("emailaddress").ToString
            globalBegginingCash = rst("cashbeggining")
            globalIconfolder = rst("iconfolderclient").ToString
            globalBgColor = rst("bgcolorclient").ToString
            globalFontColor = rst("fontcolorclient").ToString
            globalUserRequiredUpdateInfo = rst("requiredupdate")

            If globalCoffeecupUser = True Then
                globalAuthcode = rst("coffeecupposition").ToString
            End If
        End While
        rst.Close()
        
        com.CommandText = "select * from tblpermissions where percode='" & globalpermissioncode & "'" : rst = com.ExecuteReader
        While rst.Read
            globalAdminApprover = rst("approver")
            globalAdminAllowAdd = rst("allowadd")
            globalAdminAllowEdit = rst("allowedit")
            globalAdminAllowDelete = rst("allowdelete")
        End While
        rst.Close()


        '#validate user authority
        com.CommandText = "select * from tbluserauthority where authcode='" & globalAuthcode & "'" : rst = com.ExecuteReader
        While rst.Read
            globalAuthDescription = rst("authdescription").ToString
            globalBranchApprover = rst("officeapprover")
            globalCorporateApprover = rst("corpapprover")
            globalapproveanyoffices = rst("approveanyoffices")
            globalAuthAdvanceSearch = rst("advancesearch")
            globalAuthReminders = rst("reminders")
            globalAuthForApproval = rst("forapprovalrequest")
            globalAuthApprovalHistory = rst("apphistory")
            globalAuthVoidTransaction = rst("voidtrn")
            globalAuthPointofSale = rst("pointofsale")
            globalAuthVIP = rst("vip")
            globalAuthPointofSaleAssistant = rst("pointofsaleassistant")
            globalAuthCashChange = rst("cashchange")
            globalAuthPostExpense = rst("postexpense")
            globalAuthAccountsJournalEntries = rst("accountjournal")
            globalAuthClientAccountsTransaction = rst("clientaccounts")
            globalAuthJournalEntries = rst("journalentries")
            globalAuthClientAccountsPayment = rst("clientpayment")
            globalAuthsalesdelivery = rst("salesdelivery")
            globalAuthOtherTransaction = rst("othertransaction")
            globalAuthReturnitem = rst("returnitem")
            globalAuthAutoServices = rst("autoservices")
            globalAuthClinicServices = rst("clinicservices")
            globalAuthPumpReading = rst("pumpreading")
            globalAuthEmployeeAttendance = rst("employeeattendance")
            globalAuthComplaintBox = rst("complaintbox")
            globalAuthNewRequisition = rst("requisition")
            globalAuthPurchaseOrder = rst("purchaseorder")
            globalAuthAccountsPayable = rst("accountspayable")
            globalAuthReceivingofGoods = rst("receivingofgoods")
            globalAuthReceivingTransfer = rst("receivingtransfer")
            globalAuthRequisitionManagement = rst("requisitionmgt")
            globalAuthInventoryManagement = rst("inventorymgt")
            globalAuthTransferManagement = rst("transfermgt")
            globalAuthStockoutManagement = rst("stockoutmgt")
            globalAuthAssetsManagement = rst("assetsmgt")

            globalAuthTablesAndCottages = rst("tablesandcottages")
            globalAuthHotelReservation = rst("hotelreservation")
            globalAuthHotelManagement = rst("hotelmgt")
            globalAuthRoomOccupancy = rst("roomoccupancy")
            globalAuthHouseKeeping = rst("HouseKeeping")
            globalAuthReportGenerator = rst("reportgenerator")
        End While
        rst.Close()

        '#validate Office Information settings 
        com.CommandText = "select *,(select fullname from tblaccounts where accountid = tblcompoffice.officerid) as 'incharge', " _
                        + "(select emailaddress from tblaccounts where accountid = tblcompoffice.officerid) as 'officeremail', " _
                        + " (select designation from tblaccounts where accountid = tblcompoffice.officerid) as 'position' from tblcompoffice where officeid='" & compOfficeid & "'" : rst = com.ExecuteReader
        While rst.Read
            GlobalCompanyid = rst("companyid").ToString
            compOfficename = rst("officename").ToString
            compAddress = rst("address").ToString
            compEmailaddress = rst("officeemail").ToString
            compOfficerid = rst("officerid").ToString
            compOfficerIncharge = rst("incharge").ToString
            compOfficerPosition = rst("position").ToString
            compOfficerEmail = rst("officeremail").ToString

            compCorporateoffice = rst("Corporateoffice")
            allowbegginingInventory = rst("allowbeggininginventory")
            custombranchapproval = rst("custombranchapproval")
            customcorporateapproval = rst("customcorporateapproval")
            compInventoryMethod = rst("inventorymethod").ToString
            allowmanualffeinventory = rst("allowmanualffeinventory")
            compallowmanageffeotheroffice = rst("allowmanageffeotheroffice")
            compallowmanagconsumableotheroffice = rst("allowmanualconsumableinventory")
            compallowcreaterequestforotheroffice = rst("allowcreaterequestforotheroffice")
            compEnableInventory = rst("enableinventory")
            compAllowreceivedpurchases = rst("allowreceivedpurchases")

            compposproductioncopy = rst("posproductioncopy")
            compposfoodcheckercopy = rst("posfoodcheckercopy")
            compposbutcherycopy = rst("posbutcherycopy")
            compposcustomercopy = rst("poscustomercopy")
            compposcashiercopy = rst("poscashiercopy")

        End While
        rst.Close()

        '#validate Company Settings
        Dim encryptedModule As String = ""
        If GlobalCompanyid = "" Then
            com.CommandText = "select * from tblcompanysettings where defaultcompany=1"
        Else
            com.CommandText = "select * from tblcompanysettings where companycode='" & GlobalCompanyid & "'"
        End If
        rst = com.ExecuteReader
        While rst.Read
            GlobalOrganizationInitialCode = rst("initialcode").ToString
            GlobalOrganizationName = rst("companyname").ToString
            GlobalOrganizationAddress = rst("compadd").ToString
            GlobalOrganizationEmail = rst("email").ToString
            GlobalOrganizationWebsite = rst("website").ToString
            GlobalOrganizationLogoURL = rst("logourl").ToString
            GlobalOrganizationContactNumber = rst("telephone").ToString
            GlobalOrganization_KB = rst("kb")
            GlobalTinNumber = rst("tinnumber").ToString
            GlobalPermitNumber = rst("permitnumber").ToString
            GlobalMiNumber = rst("minumber").ToString
            GlobalSNumber = rst("snumber").ToString
            GlobalTaxRate = rst("vatpercentage").ToString
            GlobalTaxAddtoTotal = rst("addvattotal")
            GlobalServiceChargeRate = rst("svchargepercentage").ToString
            GlobalSvAddtoTotal = rst("addsvtotal")
            GlobalPosReceiptType = rst("posreceipttype").ToString
            compkb = rst("kb").ToString

            Dim picbox As New PictureBox
            ConvertDatabaseImage("logo", picbox)
            If System.IO.File.Exists(Application.StartupPath.ToString & "\Logo\logo.png") = True Then
                System.IO.File.Delete(Application.StartupPath.ToString & "\Logo\logo.png")
            End If
        End While
        rst.Close()
        LoadGlobalModule()



        '#validate system general settings 
        com.CommandText = "select *,(select companyname from tblglobalvendor where vendorid=tblgeneralsettings.supplierid) as 'vendor', " _
                    + " (select fullname from tblaccounts where accountid=tblgeneralsettings.approvedid) as 'approverName', " _
                    + " (select designation from tblaccounts where accountid=tblgeneralsettings.approvedid) as 'approverPosition' from tblgeneralsettings" : rst = com.ExecuteReader
        While rst.Read
            GlobalAllowableAttachSize = rst("allowableattachsize").ToString
            GlobalPOExpiry = rst("poexpiry").ToString
            GlobalEnableBarcode = rst("enableitembarcode")

            'Email settings
            globalEmailNotification = rst("enableemailnotification")
            globalsmtpHost = rst("smtphost").ToString()
            globalsmtpPort = rst("smptport").ToString()
            globalsslEnable = rst("smtpsslenable").ToString()
            globalserverEmailAddress = rst("serveremailaddress").ToString()
            globalemailPassword = DecryptTripleDES(rst("serverpassword").ToString())

            BeginningVendor = rst("enablebeginsupplier")
            BeginningVendorName = rst("vendor").ToString
            BeginningVendorid = rst("supplierid").ToString

            GlobalDirectApprovedPr = rst("directapprovedpr")
            GlobalDirectApprovedPo = rst("directapprovedpo")
            GlobalDirectProductRegistration = rst("directproductregistration")
            GlobalDownloadDefaultLocation = rst("defaultdownloadlocation").ToString
            Globalclientlogofilename = rst("clientlogofilename").ToString
            GlobalenableProductFilter = rst("enableproductfilter")

            GlobalApproverName = rst("approverName").ToString
            GlobalApproverPosition = rst("approverPosition").ToString

            Globalenablecashiersassistant = rst("enablecashiersassistant")
            Globalenablesalesassistant = rst("enablesalesassistant")
            Globalenableupdatesalesamount = rst("enableupdatesalesamount")
            Globalenablesalesdirectproductregister = rst("enablesalesdirectproductregister")
            Globalenablechittransaction = rst("enablechittransaction")
            Globaldefaultsalespersonpermission = rst("defaultsalespersonpermission").ToString
            Globalenableprintrecieptcashier = rst("enableprintrecieptcashier")
            Globalenablesaleinvoicenumber = rst("enablesaleinvoicenumber")
            GLobalenabledirectapprovedclient = rst("enabledirectapprovedclient")
            Globalenableacknowlegedchargetoaccountremarks = rst("enableacknowlegedchargetoaccountremarks")
            GlobalProductTemplate = rst("producttemplateclient")
            GlobalStrictadminconfirmed = rst("strictadminconfirmed")
            Globalchargeinvoicetemplate = rst("chargeinvoicetemplate").ToString
            Globalchargeinvoicettitle = rst("chargeinvoicettitle").ToString
            If rst("chargeinvoicessequence").ToString = "" Then
                GLobalchargeinvoicessequence = False
            Else
                GLobalchargeinvoicessequence = True
            End If
            Globalclientjournaltemplate = rst("clientjournaltemplate").ToString
            Globalclientjournaltitle = rst("clientjournaltitle").ToString
            If rst("clientjournalsequence").ToString = "" Then
                GLobalclientjournalsequence = False
            Else
                GLobalclientjournalsequence = True
            End If
            Globalsalesdeliverytemplate = rst("salesdeliverytemplate").ToString
            Globalsalesdeliverytitle = rst("salesdeliverytitle").ToString
            If rst("salesdeliverysequence").ToString = "" Then
                GLobalsalesdeliverysequence = False
            Else
                GLobalsalesdeliverysequence = True
            End If
            If rst("hotelfoliosequence").ToString = "" Then
                GLobalhotelfoliosequence = False
            Else
                GLobalhotelfoliosequence = True
            End If
            Globalhotelcheckouttime = rst("hotelcheckouttime").ToString
            Globalhotelreservationexpiry = rst("hotelreservationexpiry")
            If rst("hotelreceiptsequence").ToString = "" Then
                GLobalhotelreceiptsequence = False
            Else
                GLobalhotelreceiptsequence = True
            End If
            Globalenableclientfilter = rst("enableclientfilter")
            Globalenablebackdatetrn = rst("enablebackdatetrn")
            Globalenablectaadvancepayment = rst("enablectaadvancepayment")

            If rst("vouchernosequence").ToString = "" Then
                GLobalAutoServicesSequence = False
            Else
                GLobalAutoServicesSequence = True
            End If

            If rst("vouchernosequence").ToString = "" Then
                GlobalEnableVouchernumbersequence = False
            Else
                GlobalEnableVouchernumbersequence = True
            End If
            GlobalEnableCashierReportSummaryView = rst("enableposcashiersummaryview")
            Globalenableposcashdrawer = rst("enableposcashdrawer")
            GLobalEnableViewSalesCashendreport = rst("enableviewsalescashendreport")
            GLobalEmailNotifyAutoServices = rst("emailnotifyautoservices")
            GlobalProcurementEmailAddress = rst("procurementemailaddress").ToString
            GlobalStrictApproverSignature = rst("strictapproversignature")
            GlobalEnableProcurementPolicy = rst("enableprocurementpolicy")
            GlobalEnableClientAccounts = rst("enableclientaccounts")
            Globalallowprocessorcreateclientaccounts = rst("allowprocessorcreateclientaccounts")
            Globalenablehousekeepingmonitoring = rst("enablehousekeepingmonitoring")
            Globalenablehotelmaintainanceuponcheckout = rst("enablehotelmaintainanceuponcheckout")
            Globalhotelmaintainancedefaultstatus = rst("hotelmaintainancedefaultstatus").ToString
            GlobalShowsalesreportemailcaptionasoffice = rst("showsalesreportemailcaptionasoffice")
            Globalenablestrictffedetails = rst("enablestrictffedetails")
            GlobalHotelhousekeepingid = rst("hotelhousekeepingid").ToString
            GlobalEnableQueuingSlip = rst("enablequeuingslip")
            GlobalQueuingSlipType = StrConv(rst("QueuingSlipType").ToString, vbProperCase)
            GlobalQueuingProductCategory = rst("queuingproductcategory").ToString
            GlobalEnableStrictMenuMakerInventory = rst("enablestrictmenumakerinventory")
            Globalallowreceivedexceedingpoamount = rst("allowreceivedexceedingpoamount")
            Globalduetosequenceno = rst("duetosequenceno")
            GlobalAllowchangeitempo = rst("allowchangeitempo")
            Globalallowaccessallonhold = rst("allowaccessallonhold")
            Globalhoteldefaultcheckinstatuscode = rst("hoteldefaultcheckinstatuscode").ToString
            Globalhoteldefaultvacantstatuscode = rst("hoteldefaultvacantstatuscode").ToString
            'Globalrequiredpostoclosed = rst("requiredpostoclosed")
            GlobalEnableVoucherPaymentPosting = rst("EnableVoucherPaymentPosting")
            Globalcustomorderproductcategory = rst("customorderproductcategory").ToString
            Globalenablecombinepossalesquantity = rst("enablecombinepossalesquantity")
            Globalenableposviewrowborder = rst("enableposviewrowborder")
            Globalenableposviewcolborder = rst("enableposviewcolborder")
            GlobalReportTemplate = rst("reporttemplate").ToString
            Globaldefaultroomoccupieddirty = rst("defaultroomoccupieddirty").ToString
            Globalhotelitemizedcharge = rst("hotelitemizedcharge")
            GlobalEnableBookingroomblocking = rst("enablebookingroomblocking")
            Globalenablehoteldayafterrevenue = rst("enablehoteldayafterrevenue")
            Globaldefaultroomstatuschangeroom = rst("defaultroomstatuschangeroom")
            Globalenabledirectinventorytransferconfirmed = rst("enabledirectinventorytransferconfirmed")
            Globalflexiblehotelrate = rst("flexiblehotelrate")
            Globalenablestocktransferclearing = rst("enablestocktransferclearing")
            Globalenablemenumakerinventory = rst("enablemenumakerinventory")
        End While
        rst.Close()

        com.CommandText = "select * from tblclientaccounts where walkinaccount=1" : rst = com.ExecuteReader
        While rst.Read
            GlobalWalkinAccountName = rst("companyname").ToString
            GlobalWalkinAccountCIFCode = rst("cifid").ToString
        End While
        rst.Close()
        LoadGLSsettings()
        '#Validate sales user accounts
        If EnableModuleSales = True Then
            If countqry("tblsalessummary", "userid='" & globaluserid & "' and openfortrn=1") = 0 Then
                globalSalesOpentrn = False
                globalSalesTrnCOde = ""
            Else
                com.CommandText = "select * from tblsalessummary where userid='" & globaluserid & "' and openfortrn=1" : rst = com.ExecuteReader
                While rst.Read
                    globalSalesTrnCOde = rst("trncode").ToString
                    globalSalesOpentrn = rst("openfortrn")
                    globalBackDateTransaction = rst("backdatetrn")
                    globalTransactionDate = CDate(rst("dateopen").ToString).ToShortDateString
                    If globalBackDateTransaction = True Then
                        globalBackDate = rst("backdate").ToString
                        globalBackDateRemarks = rst("backdateremarks").ToString
                    End If
                End While
                rst.Close()

                If EnableModuleHotel = True Then
                    com.CommandText = "select * from tblhotelfilter where permissioncode='" & globalAuthcode & "'" : rst = com.ExecuteReader
                    While rst.Read
                        GlobalHotelCif = rst("hotelcif").ToString
                    End While
                    rst.Close()
                End If
            End If

            com.CommandText = "select * from tblsalesencryptnumber" : rst = com.ExecuteReader
            While rst.Read
                GlobalEnableEncryptNumbers = rst("enableencrypt")
                GlobalEncrptVal1 = rst("val1").ToString
                GlobalEncrptVal2 = rst("val2").ToString
                GlobalEncrptVal3 = rst("val3").ToString
                GlobalEncrptVal4 = rst("val4").ToString
                GlobalEncrptVal5 = rst("val5").ToString
                GlobalEncrptVal6 = rst("val6").ToString
                GlobalEncrptVal7 = rst("val7").ToString
                GlobalEncrptVal8 = rst("val8").ToString
                GlobalEncrptVal9 = rst("val9").ToString
                GlobalEncrptVal0 = rst("val0").ToString
            End While
            rst.Close()
        End If
        Return 0
    End Function

    Public Function LoadCashierDetails(ByVal userid As String)
        com.CommandText = "select *,(select officename from tblcompoffice where officeid=tblaccounts.officeid) as Officename, " _
                                + " (select officeemail from tblcompoffice where officeid=tblaccounts.officeid) as officemail " _
                                + "  from tblaccounts where accountid='" & userid & "'" : rst = com.ExecuteReader
        While rst.Read
            compOfficeid = rst("officeid").ToString
            globalfullname = rst("fullname").ToString
            globalposition = StrConv(rst("designation").ToString, vbProperCase)
        End While
        rst.Close()
        LoadGLSsettings()
        '#Validate sales user accounts
        If EnableModuleSales = True Then
            If countqry("tblsalessummary", "userid='" & globaluserid & "' and openfortrn=1") = 0 Then
                globalSalesOpentrn = False
                globalSalesTrnCOde = ""
            Else
                com.CommandText = "select * from tblsalessummary where userid='" & globaluserid & "' and openfortrn=1" : rst = com.ExecuteReader
                While rst.Read
                    globalSalesTrnCOde = rst("trncode").ToString
                    globalSalesOpentrn = rst("openfortrn").ToString
                    globalBackDateTransaction = rst("backdatetrn")
                    If globalBackDateTransaction = True Then
                        globalBackDate = rst("backdate").ToString
                        globalBackDateRemarks = rst("backdateremarks").ToString
                    End If
                End While
                rst.Close()
            End If
        End If
        Return 0
    End Function

    Public Function LoadPostTransaction(ByVal trncode As String)
        com.CommandText = "select * from tblsalessummary where userid='" & globaluserid & "' and trncode='" & trncode & "'" : rst = com.ExecuteReader
        While rst.Read
            globalSalesTrnCOde = rst("trncode").ToString
            globalSalesOpentrn = rst("openfortrn").ToString
            globalBackDateTransaction = rst("backdatetrn")
            If globalBackDateTransaction = True Then
                globalBackDate = rst("backdate").ToString
                globalBackDateRemarks = rst("backdateremarks").ToString
            End If
        End While
        rst.Close()
    End Function

    Public Sub LoadGlobalModule()
        com.CommandText = "select * from tblsystemlicense" : rst = com.ExecuteReader
        While rst.Read
            SystemEngineCode = rst("enginecode").ToString
            SystemModule = rst("systemmodule").ToString
            SystemDate = rst("systemdate").ToString
            SystemExpiryDate = rst("expirydate").ToString
        End While
        rst.Close()

        Dim InfoFile As String = DecryptTripleDES(SystemModule)
        For Each strLine As String In InfoFile.Split(vbCrLf)
            Dim word As String() = strLine.Split("=")
            If word(0) = "procurement" Then
                If word(1) = "ACTIVATED" Then
                    EnableModuleProcurement = True
                Else
                    EnableModuleProcurement = False
                End If
            End If
            If word(0) = "inventory" Then
                If word(1) = "ACTIVATED" Then
                    EnableModuleInventory = True
                Else
                    EnableModuleInventory = False
                End If
            End If
            If word(0) = "sales" Then
                If word(1) = "ACTIVATED" Then
                    EnableModuleSales = True
                Else
                    EnableModuleSales = False
                End If
            End If
            If word(0) = "fuel" Then
                If word(1) = "ACTIVATED" Then
                    EnableModuleFuel = True
                Else
                    EnableModuleFuel = False
                End If
            End If
            If word(0) = "hotel" Then
                If word(1) = "ACTIVATED" Then
                    EnableModuleHotel = True
                Else
                    EnableModuleHotel = False
                End If
            End If
            If word(0) = "hr" Then
                If word(1) = "ACTIVATED" Then
                    EnableModuleHR = True
                Else
                    EnableModuleHR = False
                End If
            End If
            If word(0) = "payroll" Then
                If word(1) = "ACTIVATED" Then
                    EnableModulePayroll = True
                Else
                    EnableModulePayroll = False
                End If
            End If
            If word(0) = "clinic" Then
                If word(1) = "ACTIVATED" Then
                    EnableModuleClinic = True
                Else
                    EnableModuleClinic = False
                End If
            End If
            If word(0) = "reportgen" Then
                If word(1) = "ACTIVATED" Then
                    EnableModuleReportGen = True
                Else
                    EnableModuleReportGen = False
                End If
            End If
            If word(0) = "pos" Then
                GlobalNumberOfPOS = word(1)
            End If
            If word(0) = "division" Then
                GlobalNumberOfDevision = word(1)
            End If
            If word(0) = "retainersmode" Then
                If word(1) = "1" Then
                    EnableRetainersMode = True
                Else
                    EnableRetainersMode = False
                End If
            End If
        Next

    End Sub
    Public Sub LoadGLSsettings()
        com.CommandText = "select * from tblglsettings" : rst = com.ExecuteReader
        While rst.Read
            'GlobalGLExpensesCode = rst("expenseglcode").ToString
            'GlobalGLIncomeCode = rst("incomeglcode").ToString
            'GlobalPOSGlTransactionCode = rst("pointofsale").ToString
            'GlobalPOSBeginningCash = rst("cashierbegcashamt")
            'GlobalPOSBeginningCashFrom = rst("cashierbegcashfrom").ToString
            'GlobalPaymentGLItemCode = rst("clientpayment").ToString
            'GlobalGLVoucherCode = rst("voucher").ToString
            'GlobalGLAccountReceivable = rst("acctrecievable").ToString
            'GlobalPaymentDiscountGLItemCode = rst("paymentdiscount").ToString
            'GLobalGLItemPurchaseOrder = rst("popayable").ToString
            GlobalTaxRate = rst("taxrate").ToString
        End While
        rst.Close()

    End Sub

    Public Sub CloseSystemDeclaration()
        globallogin = False


        screenHeight = 0
        screenWidth = 0
        screenres = ""
        globallogin = False

        'Declaration of module
        EnableModuleProcurement = False
        EnableModuleInventory = False
        EnableModuleSales = False
        EnableModuleFuel = False
        EnableModuleHR = False
        EnableModulePayroll = False
        EnableModuleHotel = False
        EnableModuleClinic = False
        EnableModuleReportGen = False
        GlobalNumberOfPOS = 0 = 0
        GlobalNumberOfDevision = 0 = 0
        EnableRetainersMode = False

        SystemEngineCode = ""
        SystemModule = ""
        SystemDate = ""
        SystemExpiryDate = ""

        'Declaration of user accounts
        globaluserid = ""
        globalTransactionUserid = ""
        globalfullname = ""
        globalposition = ""
        globalEmailaddress = ""
        globalcontact = ""
        globalusername = ""
        globalCoffeecupUser = False
        globalpermissioncode = ""
        globalBegginingCash = 0
        globalIconfolder = ""
        globalBgColor = ""
        globalFontColor = ""

        globalAssistantUserId = ""
        globalAssistantFullName = ""

        'Permission
        globalAdminApprover = False
        globalAdminAllowAdd = False
        globalAdminAllowEdit = False
        globalAdminAllowDelete = False

        'Declaration of user authority
        globalAuthcode = ""
        globalAuthDescription = ""
        globalCorporateApprover = False
        globalapproveanyoffices = False
        globalBranchApprover = False
        globalAuthAdvanceSearch = False
        globalAuthReminders = False
        globalAuthForApproval = False
        globalAuthApprovalHistory = False
        globalAuthVoidTransaction = False
        globalAuthPointofSale = False
        globalAuthVIP = False
        globalAuthPointofSaleAssistant = False
        globalAuthCashChange = False
        globalAuthPostExpense = False
        globalAuthAccountsJournalEntries = False
        globalAuthClientAccountsTransaction = False
        globalAuthJournalEntries = False
        globalAuthClientAccountsPayment = False
        globalAuthsalesdelivery = False
        globalAuthOtherTransaction = False
        globalAuthReturnitem = False
        globalAuthAutoServices = False
        globalAuthPumpReading = False
        globalAuthEmployeeAttendance = False
        globalAuthComplaintBox = False
        globalAuthNewRequisition = False
        globalAuthPurchaseOrder = False
        globalAuthAccountsPayable = False
        globalAuthReceivingofGoods = False
        globalAuthRequisitionManagement = False
        globalAuthInventoryManagement = False
        globalAuthTransferManagement = False
        globalAuthStockoutManagement = False
        globalAuthAssetsManagement = False
        globalAuthTablesAndCottages = False
        globalAuthHotelReservation = False
        globalAuthHotelManagement = False
        globalAuthRoomOccupancy = False
        globalAuthHouseKeeping = False
        globalAuthReportGenerator = False

        'Declaration of company profile
        GlobalCompanyid = ""
        GlobalOrganizationName = ""
        GlobalOrganizationAddress = ""
        GlobalOrganizationContactNumber = ""
        GlobalOrganization_KB = False
        GlobalTinNumber = ""
        GlobalPermitNumber = ""
        GlobalMiNumber = ""
        GlobalSNumber = ""
        GlobalTaxRate = 0
        GlobalServiceChargeRate = 0
        GlobalPosReceiptType = ""
        compkb = ""

        'Declaration of Office profile
        compCompanyExist = False
        compOfficeid = ""
        compOfficename = ""
        compAddress = ""
        compEmailaddress = ""
        compOfficerid = ""
        compOfficerIncharge = ""
        compOfficerEmail = ""
        compOfficerPosition = ""

        compposproductioncopy = False
        compposfoodcheckercopy = False
        compposbutcherycopy = False
        compposcustomercopy = False
        compposcashiercopy = False


        compCorporateoffice = False
        allowbegginingInventory = False
        custombranchapproval = False
        customcorporateapproval = False
        compInventoryMethod = ""
        allowmanualffeinventory = False
        compallowmanageffeotheroffice = False
        compallowmanagconsumableotheroffice = False
        compallowcreaterequestforotheroffice = False
        compAllowreceivedpurchases = False

        'Declaration of general settings
        globalregby = ""
        GlobalAllowableAttachSize = 0
        GlobalPOExpiry = 0
        BeginningVendor = False
        BeginningVendorName = ""
        BeginningVendorid = ""
        GlobalDirectApprovedPr = False
        GlobalDirectApprovedPo = False
        GlobalDirectProductRegistration = False
        GlobalEnableBarcode = False
        GlobalDownloadDefaultLocation = ""
        GlobalApproverName = ""
        GlobalApproverPosition = ""
        Globalclientlogofilename = ""
        GlobalenableProductFilter = False
        Globalenablecashiersassistant = False
        Globalenablesalesassistant = False
        Globalenableupdatesalesamount = False
        Globalenablesalesdirectproductregister = False
        Globaldefaultsalespersonpermission = ""
        Globalenablechittransaction = False
        Globalenableprintrecieptcashier = False
        Globalenablesaleinvoicenumber = False
        GLobalenabledirectapprovedclient = False
        Globalenableacknowlegedchargetoaccountremarks = False
        GlobalProductTemplate = 0
        GlobalStrictadminconfirmed = False
        Globalchargeinvoicetemplate = ""
        Globalchargeinvoicettitle = ""
        GLobalchargeinvoicessequence = False
        Globalclientjournaltemplate = ""
        Globalclientjournaltitle = ""
        GLobalclientjournalsequence = False
        Globalsalesdeliverytemplate = ""
        Globalsalesdeliverytitle = ""
        GLobalsalesdeliverysequence = False
        GLobalhotelfoliosequence = False
        Globalhotelcheckouttime = Nothing
        Globalhotelreservationexpiry = 0
        GLobalhotelreceiptsequence = False
        Globalenableclientfilter = False
        Globalenablebackdatetrn = False
        Globalenablectaadvancepayment = False
        GLobalAutoServicesSequence = False
        GlobalEnableCashierReportSummaryView = False
        Globalenableposcashdrawer = False
        GLobalEnableViewSalesCashendreport = False
        GLobalEmailNotifyAutoServices = False
        GlobalProcurementEmailAddress = ""
        GlobalWalkinAccountName = ""
        GlobalWalkinAccountCIFCode = ""
        GlobalStrictApproverSignature = False
        GlobalEnableProcurementPolicy = False
        GlobalEnableClientAccounts = False
        Globalallowprocessorcreateclientaccounts = False
        Globalenablehousekeepingmonitoring = False
        Globalenablehotelmaintainanceuponcheckout = False
        Globalhotelmaintainancedefaultstatus = ""
        GlobalShowsalesreportemailcaptionasoffice = False
        Globalenablestrictffedetails = False
        GlobalHotelhousekeepingid = ""
        GlobalEnableStrictMenuMakerInventory = False
        Globalduetosequenceno = ""
        GlobalAllowchangeitempo = False
        Globalallowaccessallonhold = False
        Globalhoteldefaultcheckinstatuscode = ""
        Globalhoteldefaultvacantstatuscode = ""
        Globalrequiredpostoclosed = False
        GlobalEnableVoucherPaymentPosting = False
        Globalcustomorderproductcategory = ""
        Globalenablecombinepossalesquantity = False
        Globalenableposviewrowborder = True
        GlobalReportTemplate = "default"
        Globaldefaultroomoccupieddirty = ""
        Globalhotelitemizedcharge = False
        GlobalEnableBookingroomblocking = False
        Globalenablehoteldayafterrevenue = True
        Globalenabledirectinventorytransferconfirmed = False
        Globalflexiblehotelrate = False
        Globalenablestocktransferclearing = False

        'Declaration of email settings
        globalEmailNotification = False
        globalsmtpHost = ""
        globalsmtpPort = ""
        globalsslEnable = ""
        globalserverEmailAddress = ""
        globaltargetEmailAddress = ""
        globalemailPassword = ""

        'Declaration of sales settings
        globalSalesOpentrn = False
        globalSalesTrnCOde = ""
        globalBackDateTransaction = False
        globalBackDate = Nothing
        globalBackDateRemarks = ""

        'Declaration of POS sales transaction
        'GlobalPOSGlTransactionCode = ""
        'GlobalPOSBeginningCash = 0
        'GlobalPOSBeginningCashFrom = ""
        'GlobalGLExpensesCode = ""
        'GlobalGLIncomeCode = ""
        'GlobalGLAccountReceivable = ""
        'GlobalPaymentGLItemCode = ""
        'GlobalPaymentDiscountGLItemCode = ""
        'GlobalGLVoucherCode = ""
        'GLobalGLItemPurchaseOrder = ""

        'Declaration of POS number encryption
        GlobalEnableEncryptNumbers = False
        GlobalEncrptVal1 = ""
        GlobalEncrptVal2 = ""
        GlobalEncrptVal3 = ""
        GlobalEncrptVal4 = ""
        GlobalEncrptVal5 = ""
        GlobalEncrptVal6 = ""
        GlobalEncrptVal7 = ""
        GlobalEncrptVal8 = ""
        GlobalEncrptVal9 = ""
        GlobalEncrptVal0 = ""

        'Filters
        GlobalHotelCif = ""
        frmLogin.attemplogin = False
    End Sub
End Module

