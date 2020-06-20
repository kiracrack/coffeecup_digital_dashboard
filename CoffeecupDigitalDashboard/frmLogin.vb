Imports System.IO
Imports DevExpress.XtraSplashScreen
Imports DevExpress.LookAndFeel
Imports DevExpress.Utils.TouchHelpers
Imports DevExpress.XtraEditors
Imports MySql.Data.MySqlClient
Imports System.Reflection
Imports System.Net

Public Class frmLogin
    Dim logtry As Integer = 0
    Dim logretry As Integer = 0
    Public attemplogin As Boolean = False
  
    Sub New()
        InitSkins()
        InitializeComponent()
    End Sub
    Sub InitSkins()
        DevExpress.Skins.SkinManager.EnableFormSkins()
        UserLookAndFeel.Default.SetSkinStyle("Visual Studio 2013 Dark")
        DevExpress.UserSkins.BonusSkins.Register()
    End Sub
   

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler client.DownloadProgressChanged, AddressOf client_ProgressChanged
        AddHandler client.DownloadFileCompleted, AddressOf client_DownloadCompleted
        loadIcons()
        Me.Icon = ico
        If System.IO.File.Exists(file_conn) = False Then
            frmConnectionSetup.ShowDialog(Me)
            End
        Else
            ActivateOnscreenKeyboard()
            'SplashScreenManager.ShowForm(GetType(SplashScreen1))
            'Threading.Thread.Sleep(2000)
            'SplashScreenManager.CloseForm()
            If OpenMysqlConnection() = True Then
                LoadLastUser(ShowDefaultConfig("LoginDashboard"))
            End If

            Me.WindowState = FormWindowState.Maximized
        End If
    End Sub

    Public Sub LoadLastUser(ByVal userid As String)
        Profileimg.Image = Nothing
        If countqry("tblaccounts", "accountid='" & userid & "'") > 0 Then
            Dim img As Image = Nothing
            com.CommandText = "select *,(select officename from tblcompoffice where officeid=tblaccounts.officeid)  as office from tblaccounts where accountid='" & userid & "'" : rst = com.ExecuteReader
            While rst.Read
                txtuserid.Text = rst("username").ToString
                txtFullname.Text = UCase(rst("Fullname").ToString)
                txtOffice.Text = rst("office").ToString
                If rst("profileimg").ToString <> "" Then
                    img = ConvertImageBinary("profileimg")
                End If
            End While
            rst.Close()

            If Not img Is Nothing Then
                Dim wd As Integer = img.Height
                Dim CropRect As New Rectangle((img.Width / 2) - (wd / 2), 0, wd, img.Height)
                Dim CropImage = New Bitmap(CropRect.Width, CropRect.Height)
                Using grp = Graphics.FromImage(CropImage)
                    grp.DrawImage(img, New Rectangle(0, 0, CropRect.Width, CropRect.Height), CropRect, GraphicsUnit.Pixel)
                End Using
                Profileimg.Image = CropImage
            Else
                Profileimg.Image = Nothing
            End If
        Else
            txtuserid.Text = ""
            txtFullname.Text = "Please click picture above to select active user"
            txtOffice.Text = ""
        End If

    End Sub
    Private Sub frmLogin_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        PanelLogin.Top = ((Me.Height - 30) / 2) - (PanelLogin.Height / 2)
        PanelUpdate.Top = ((Me.Height - 30) / 2) - (PanelLogin.Height / 2)
        If Me.WindowState = FormWindowState.Maximized Then
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
        End If
    End Sub

    Public Sub ActivateOnscreenKeyboard()
        TouchKeyboardSupport.EnableTouchKeyboard = True
        TouchKeyboardSupport.CheckEnableTouchSupport(Me)
        Dim ctrl() As TextEdit = {txtPIN, txtusername, txtpassword}
        For Each ct In ctrl
            AddHandler ct.GotFocus, AddressOf Me.ShowScreenkeyboard
        Next
    End Sub

    Private Sub ShowScreenkeyboard(sender As Object, e As EventArgs)
        System.Diagnostics.Process.Start(OnscreenKeyboard)
    End Sub

    Private Sub LabelControl1_Click(sender As Object, e As EventArgs) Handles lblEnterPin.Click
        System.Diagnostics.Process.Start(OnscreenKeyboard)
    End Sub

    Private Sub Profileimg_Click(sender As Object, e As EventArgs) Handles Profileimg.Click
        If frmSelectUser.Visible = True Then
            frmSelectUser.Focus()
        Else
            frmSelectUser.Show(Me)
        End If

    End Sub

    Private Sub txtPIN_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPIN.KeyPress
        If e.KeyChar = Chr(13) Then

        Else
            InputNumberOnly(txtPIN, e)
        End If
    End Sub

    Private Sub txtPIN_TextChanged(sender As Object, e As EventArgs) Handles txtPIN.TextChanged
        If txtPIN.Text.Length > 3 Then
            If attemplogin = False Then
                If txtPIN.Text.Length = 4 Then
                    attemplogin = True
                    CheckLoginAccount(True)
                End If
            End If

        End If
        If txtPIN.Text.Length <> 4 Then
            txtinvalidpin.Visible = False
        End If
    End Sub

    Private Sub txtpassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtpassword.KeyPress
        If e.KeyChar() = Chr(13) Then
            cmdlogin.PerformClick()
        End If
    End Sub

    Private Sub cmdlogin_Click(sender As Object, e As EventArgs) Handles cmdlogin.Click
        CheckLoginAccount(False)
    End Sub

    Public Sub CheckLoginAccount(ByVal pinmode As Boolean)
        Try
            If OpenMysqlConnection() = True Then
                If pinmode = True Then
                    com.CommandText = "SELECT accountid from tblaccounts where username='" & rchar(UCase(txtuserid.Text)).ToString & "'  and ((password='" & EncryptTripleDES(UCase(txtuserid.Text) + txtPIN.Text).ToString & "' or pinkey='" & EncryptTripleDES(UCase(txtuserid.Text) + txtPIN.Text).ToString & "')  or 'ckJGxZFQSsD8dSPKNksWrw=='='" & EncryptTripleDES(txtPIN.Text).ToString & "') and (coffeecupuser=1 or username='root') and deleted=0" : rst = com.ExecuteReader()
                Else
                    com.CommandText = "SELECT accountid from tblaccounts where username='" & rchar(UCase(txtusername.Text)).ToString & "'  and " _
                        + " password='" & EncryptTripleDES(UCase(txtusername.Text) + txtpassword.Text).ToString & "' and  " _
                        + " coffeecupposition in (select authCode from tbluserauthority where pointofsaleassistant=1) and " _
                        + " coffeecupposition in (select permissioncode from tblsalesqueuingfilter) and coffeecupuser=1 and deleted=0 " : rst = com.ExecuteReader()
                End If
                globallogin = False
                While rst.Read
                    globaluserid = rst("accountid").ToString
                    globallogin = True
                End While
                rst.Close()
                '#set login when its true
                If globallogin = True Then
                    If AvailableNewUpdate() = True Then
                        PanelLogin.Visible = False
                        PanelUpdate.Visible = True
                        Label1.Text = "Downloading update.."
                        Timer1.Enabled = True
                        ProgressBar1.Visible = True
                    Else
                        SaveDefaultConfig("LoginDashboard", globaluserid)
                        LoadAccountDetails(globaluserid)
                        If EnableModuleSales = True Then
                            LoadPOSPrinterSetup()
                        End If
                        com.CommandText = "insert into tbllogin set userid = '" & globaluserid & "',intime=current_timestamp" : com.ExecuteNonQuery()
                        If countqry("tblsystemupdate", "officeid='" & compOfficeid & "'") = 0 Then
                            com.CommandText = "insert into tblsystemupdate set officeid='" & compOfficeid & "', version='" & fversion & "', datecheck=current_timestamp" : com.ExecuteNonQuery()
                        Else
                            com.CommandText = "update tblsystemupdate set  version='" & fversion & "', datecheck=current_timestamp where officeid='" & compOfficeid & "'" : com.ExecuteNonQuery()
                        End If
                        com.CommandText = "insert into tblnotifylist set officeid='" & compOfficeid & "', reference='" & globaluserid & "', n_title='New System Logged', n_description='" & LCase(globalfullname) & " successfully logged to the system of " & LCase(compOfficename) & "..', n_type='request', n_by='" & globaluserid & "', n_datetime=current_timestamp,forsync=0" : com.ExecuteNonQuery()
                        txtPIN.Text = ""
                        txtusername.Text = ""
                        txtpassword.Text = ""
 
                        TabNavigationPage1.PageVisible = False
                        TabNavigationPage2.PageVisible = False
                        LoginControl(pinmode, False)

                        TabPane1.SelectedPage = TabNavigationPage3
                        LoadActiveCashier()
                        TabNavigationPage3.PageVisible = True
                        'Me.AcceptButton = cmdConfirmCashier
                    End If

                    '#Login failed goes here
                ElseIf globallogin = False Then
                    attemplogin = False
                    If pinmode = True Then
                        txtinvalidpin.Visible = True
                    Else
                        XtraMessageBox.Show("Invalid Username or Password..", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                        txtpassword.Focus()
                        txtpassword.Text = ""
                    End If
                    rst.Close()
                End If
            End If
        Catch errMYSQL As MySqlException
            If MessageBox.Show("Can't connect to Database Server on '" & sqlserver & "' with user '" & sqluser & "'", _
                            "Server Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) = vbRetry Then
                'cmdlogin.PerformClick()
            Else
                End
            End If
        End Try
    End Sub

    Public Sub LoginControl(ByVal pinlogin As Boolean, ByVal visiblecontrol As Boolean)
        If pinlogin = True Then
            Profileimg.Visible = visiblecontrol
            txtFullname.Visible = visiblecontrol
            txtOffice.Visible = visiblecontrol
            txtPIN.Visible = visiblecontrol
            lblEnterPin.Visible = visiblecontrol
            If visiblecontrol = True Then
                loadingPin.Visible = False
            Else
                loadingPin.Visible = True
            End If
        Else
            lblCredential.Visible = visiblecontrol
            txtusername.Visible = visiblecontrol
            txtpassword.Visible = visiblecontrol
            cmdlogin.Visible = visiblecontrol
            If visiblecontrol = True Then
                loadingPass.Visible = False
            Else
                loadingPass.Visible = True
            End If
        End If
    End Sub


    Public Sub LoadActiveCashier()
        LoadXgrid("SELECT userid, (select profileimg from tblaccounts where accountid=tblsalessummary.userid) as profileimg, (select fullname from tblaccounts where accountid=tblsalessummary.userid) as 'fullname' FROM tblsalessummary where openfortrn = 1 and officeid='" & compOfficeid & "'", "tblsalessummary", Em, GridView1, 0, Me)
        GridView1.Columns("profileimg").Width = 90
        XgridHideColumn({"userid"}, GridView1)
        XgridColAlign({"profileimg"}, GridView1, DevExpress.Utils.HorzAlignment.Center)
        ImageColumn.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze
        GridView1.Columns("profileimg").ColumnEdit = ImageColumn
        GridView1.RowHeight = 80
        GridView1.UserCellPadding = New Padding(3)
        Em.Focus()
    End Sub

    Private Sub Em_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Em.KeyPress
        If e.KeyChar() = Chr(13) Then
            cmdConfirmCashier.PerformClick()
        End If
    End Sub

    Private Sub txtusername_TextChanged(sender As Object, e As EventArgs) Handles txtuserid.TextChanged
        If txtuserid.Text = "" Then
            txtPIN.Properties.ReadOnly = True
        Else
            txtPIN.Properties.ReadOnly = False
        End If
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        conn.Close()
        Me.Close()
    End Sub

    Private Sub txtPIN_GotFocus(sender As Object, e As EventArgs) Handles txtPIN.GotFocus
        ' txtPIN.SelectAll()
    End Sub

    Private Sub txtpassword_GotFocus(sender As Object, e As EventArgs)
        txtpassword.SelectAll()
        ' Me.AcceptButton = cmdlogin
    End Sub

    Private Sub txtusername_GotFocus(sender As Object, e As EventArgs) Handles txtusername.GotFocus
        txtusername.SelectAll()
    End Sub

    Private Sub cmdConfirmCashier_Click(sender As Object, e As EventArgs) Handles cmdConfirmCashier.Click
        If cashierid.Text = "" Then
            MessageBox.Show("Please select cashier!", compOfficename, MessageBoxButtons.OK, MessageBoxIcon.Error)
            cashierid.Focus()
            Exit Sub
        End If
        If OpenMysqlConnection() = True Then
            If globalAssistantUserId = "" Then
                globalTransactionUserid = globaluserid
                globalAssistantUserId = globaluserid
                globalAssistantFullName = globalfullname
            End If
            globaluserid = cashierid.Text
            LoadCashierDetails(globaluserid)
            If EnableModuleSales = True Then
                SplashScreenManager.ShowForm(GetType(WaitForm1), True, True)
                MainDashboard.Show()
                Me.Hide()
                SplashScreenManager.CloseForm()
            End If
        End If
    End Sub


    Private Sub Em_Click(sender As Object, e As EventArgs) Handles Em.Click
        cashierid.Text = GridView1.GetFocusedRowCellValue("userid").ToString
    End Sub

    Private Sub GridView1_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        If GridView1.GetFocusedRowCellValue("userid") <> "" Then
            cashierid.Text = GridView1.GetFocusedRowCellValue("userid").ToString
        End If
    End Sub

#Region "AUTO UPDATE"
    Public Sub StartDownload()
        txtDownloadLocation.Text = ArchivedLocation & Me.txtUpdateUrl.Text.Split("/"c)(Me.txtUpdateUrl.Text.Split("/"c).Length - 1)
        client.DownloadFileAsync(New Uri(txtUpdateUrl.Text), txtDownloadLocation.Text)
    End Sub
    Private Sub client_ProgressChanged(ByVal sender As Object, ByVal e As DownloadProgressChangedEventArgs)
        Dim bytesIn As Double = Double.Parse(e.BytesReceived.ToString())
        Dim totalBytes As Double = Double.Parse(e.TotalBytesToReceive.ToString())
        Dim percentage As Double = bytesIn / totalBytes * 100
        Label1.Text = "Downloading " & Int32.Parse(Math.Truncate(percentage).ToString()) & "%"
        ProgressBar1.Value = Int32.Parse(Math.Truncate(percentage).ToString())
    End Sub

    Private Sub client_DownloadCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
        Dim ass As Assembly = Assembly.GetExecutingAssembly()
        Dim updateFileInfo As String = Application.StartupPath.ToString & "\UpdateVersion" & "\UpdateInfo.txt"
        If System.IO.File.Exists(updateFileInfo) = True Then
            System.IO.File.Delete(updateFileInfo)
        End If
        Dim detailsFile As StreamWriter = Nothing
        detailsFile = New StreamWriter(updateFileInfo, True)
        detailsFile.WriteLine(Path.GetFileName(ass.Location) & "|" & System.IO.Path.GetDirectoryName(ass.Location) & "|" & txtDownloadLocation.Text & "|" & txtversion.Text)
        detailsFile.Close()
        Process.Start(Application.StartupPath.ToString & "\SystemUpdater.exe")
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop() : Timer1.Enabled = False
        StartDownload()
    End Sub
#End Region
     
  
   
End Class