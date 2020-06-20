<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLogin
    Inherits DevExpress.XtraEditors.XtraForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.PanelLogin = New DevExpress.XtraEditors.PanelControl()
        Me.TabPane1 = New DevExpress.XtraBars.Navigation.TabPane()
        Me.TabNavigationPage1 = New DevExpress.XtraBars.Navigation.TabNavigationPage()
        Me.loadingPin = New DevExpress.XtraWaitForm.ProgressPanel()
        Me.txtuserid = New System.Windows.Forms.TextBox()
        Me.Profileimg = New DevExpress.XtraEditors.PictureEdit()
        Me.txtOffice = New DevExpress.XtraEditors.LabelControl()
        Me.lblEnterPin = New DevExpress.XtraEditors.LabelControl()
        Me.txtFullname = New DevExpress.XtraEditors.LabelControl()
        Me.txtPIN = New DevExpress.XtraEditors.TextEdit()
        Me.txtinvalidpin = New DevExpress.XtraEditors.LabelControl()
        Me.TabNavigationPage2 = New DevExpress.XtraBars.Navigation.TabNavigationPage()
        Me.txtpassword = New DevExpress.XtraEditors.TextEdit()
        Me.cmdlogin = New DevExpress.XtraEditors.SimpleButton()
        Me.lblCredential = New DevExpress.XtraEditors.LabelControl()
        Me.txtusername = New DevExpress.XtraEditors.TextEdit()
        Me.loadingPass = New DevExpress.XtraWaitForm.ProgressPanel()
        Me.TabNavigationPage3 = New DevExpress.XtraBars.Navigation.TabNavigationPage()
        Me.cmdConfirmCashier = New DevExpress.XtraEditors.SimpleButton()
        Me.cashierid = New System.Windows.Forms.TextBox()
        Me.Em = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PanelUpdate = New DevExpress.XtraEditors.PanelControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtDownloadLocation = New System.Windows.Forms.TextBox()
        Me.txtversion = New System.Windows.Forms.TextBox()
        Me.txtUpdateUrl = New System.Windows.Forms.TextBox()
        Me.Label1 = New DevExpress.XtraEditors.LabelControl()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        CType(Me.PanelLogin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelLogin.SuspendLayout()
        CType(Me.TabPane1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPane1.SuspendLayout()
        Me.TabNavigationPage1.SuspendLayout()
        CType(Me.Profileimg.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPIN.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabNavigationPage2.SuspendLayout()
        CType(Me.txtpassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtusername.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabNavigationPage3.SuspendLayout()
        CType(Me.Em, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PanelUpdate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelUpdate.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelLogin
        '
        Me.PanelLogin.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.PanelLogin.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelLogin.Controls.Add(Me.TabPane1)
        Me.PanelLogin.Location = New System.Drawing.Point(212, 79)
        Me.PanelLogin.Name = "PanelLogin"
        Me.PanelLogin.Size = New System.Drawing.Size(604, 360)
        Me.PanelLogin.TabIndex = 385
        '
        'TabPane1
        '
        Me.TabPane1.AllowCollapse = DevExpress.Utils.DefaultBoolean.[Default]
        Me.TabPane1.AllowTransitionAnimation = DevExpress.Utils.DefaultBoolean.[True]
        Me.TabPane1.AppearanceButton.Hovered.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.TabPane1.AppearanceButton.Hovered.Options.UseFont = True
        Me.TabPane1.AppearanceButton.Normal.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.TabPane1.AppearanceButton.Normal.Options.UseFont = True
        Me.TabPane1.AppearanceButton.Pressed.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.TabPane1.AppearanceButton.Pressed.Options.UseFont = True
        Me.TabPane1.Controls.Add(Me.TabNavigationPage1)
        Me.TabPane1.Controls.Add(Me.TabNavigationPage2)
        Me.TabPane1.Controls.Add(Me.TabNavigationPage3)
        Me.TabPane1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabPane1.Location = New System.Drawing.Point(0, 0)
        Me.TabPane1.Name = "TabPane1"
        Me.TabPane1.Pages.AddRange(New DevExpress.XtraBars.Navigation.NavigationPageBase() {Me.TabNavigationPage1, Me.TabNavigationPage2, Me.TabNavigationPage3})
        Me.TabPane1.RegularSize = New System.Drawing.Size(604, 360)
        Me.TabPane1.SelectedPage = Me.TabNavigationPage1
        Me.TabPane1.Size = New System.Drawing.Size(604, 360)
        Me.TabPane1.TabAlignment = DevExpress.XtraEditors.Alignment.Center
        Me.TabPane1.TabIndex = 393
        Me.TabPane1.Text = "TabPane1"
        Me.TabPane1.TransitionAnimationProperties.FrameCount = 500
        Me.TabPane1.TransitionAnimationProperties.FrameInterval = 5000
        '
        'TabNavigationPage1
        '
        Me.TabNavigationPage1.Caption = "Login with PIN"
        Me.TabNavigationPage1.Controls.Add(Me.loadingPin)
        Me.TabNavigationPage1.Controls.Add(Me.txtuserid)
        Me.TabNavigationPage1.Controls.Add(Me.Profileimg)
        Me.TabNavigationPage1.Controls.Add(Me.txtOffice)
        Me.TabNavigationPage1.Controls.Add(Me.lblEnterPin)
        Me.TabNavigationPage1.Controls.Add(Me.txtFullname)
        Me.TabNavigationPage1.Controls.Add(Me.txtPIN)
        Me.TabNavigationPage1.Controls.Add(Me.txtinvalidpin)
        Me.TabNavigationPage1.Name = "TabNavigationPage1"
        Me.TabNavigationPage1.Size = New System.Drawing.Size(604, 329)
        '
        'loadingPin
        '
        Me.loadingPin.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.loadingPin.Appearance.Options.UseBackColor = True
        Me.loadingPin.BarAnimationElementThickness = 2
        Me.loadingPin.Location = New System.Drawing.Point(213, 91)
        Me.loadingPin.Name = "loadingPin"
        Me.loadingPin.Size = New System.Drawing.Size(246, 66)
        Me.loadingPin.TabIndex = 393
        Me.loadingPin.Text = "ProgressPanel1"
        Me.loadingPin.Visible = False
        '
        'txtuserid
        '
        Me.txtuserid.Location = New System.Drawing.Point(55, 74)
        Me.txtuserid.Name = "txtuserid"
        Me.txtuserid.Size = New System.Drawing.Size(66, 21)
        Me.txtuserid.TabIndex = 631
        Me.txtuserid.Visible = False
        '
        'Profileimg
        '
        Me.Profileimg.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Profileimg.Location = New System.Drawing.Point(213, 16)
        Me.Profileimg.Name = "Profileimg"
        Me.Profileimg.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.Profileimg.Properties.Appearance.Options.UseBackColor = True
        Me.Profileimg.Properties.ShowMenu = False
        Me.Profileimg.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom
        Me.Profileimg.Size = New System.Drawing.Size(152, 151)
        Me.Profileimg.TabIndex = 0
        '
        'txtOffice
        '
        Me.txtOffice.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtOffice.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.txtOffice.Appearance.ForeColor = System.Drawing.Color.Silver
        Me.txtOffice.Appearance.Options.UseFont = True
        Me.txtOffice.Appearance.Options.UseForeColor = True
        Me.txtOffice.Appearance.Options.UseTextOptions = True
        Me.txtOffice.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtOffice.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.txtOffice.Location = New System.Drawing.Point(201, 190)
        Me.txtOffice.Name = "txtOffice"
        Me.txtOffice.Size = New System.Drawing.Size(176, 23)
        Me.txtOffice.TabIndex = 389
        '
        'lblEnterPin
        '
        Me.lblEnterPin.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.lblEnterPin.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.75!)
        Me.lblEnterPin.Appearance.ForeColor = System.Drawing.Color.Silver
        Me.lblEnterPin.Appearance.Options.UseFont = True
        Me.lblEnterPin.Appearance.Options.UseForeColor = True
        Me.lblEnterPin.Appearance.Options.UseTextOptions = True
        Me.lblEnterPin.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.lblEnterPin.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblEnterPin.Location = New System.Drawing.Point(201, 213)
        Me.lblEnterPin.Name = "lblEnterPin"
        Me.lblEnterPin.Size = New System.Drawing.Size(176, 20)
        Me.lblEnterPin.TabIndex = 386
        Me.lblEnterPin.Text = "Enter 4 Digit PIN"
        '
        'txtFullname
        '
        Me.txtFullname.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtFullname.Appearance.Font = New System.Drawing.Font("Segoe UI", 11.75!)
        Me.txtFullname.Appearance.Options.UseFont = True
        Me.txtFullname.Appearance.Options.UseTextOptions = True
        Me.txtFullname.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtFullname.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.txtFullname.Location = New System.Drawing.Point(55, 172)
        Me.txtFullname.Name = "txtFullname"
        Me.txtFullname.Size = New System.Drawing.Size(469, 23)
        Me.txtFullname.TabIndex = 388
        '
        'txtPIN
        '
        Me.txtPIN.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtPIN.EditValue = ""
        Me.txtPIN.Location = New System.Drawing.Point(213, 235)
        Me.txtPIN.Name = "txtPIN"
        Me.txtPIN.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPIN.Properties.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.txtPIN.Properties.Appearance.Options.UseFont = True
        Me.txtPIN.Properties.Appearance.Options.UseForeColor = True
        Me.txtPIN.Properties.Appearance.Options.UseTextOptions = True
        Me.txtPIN.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtPIN.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.txtPIN.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.txtPIN.Properties.MaxLength = 4
        Me.txtPIN.Properties.NullValuePrompt = "PIN"
        Me.txtPIN.Properties.NullValuePromptShowForEmptyValue = True
        Me.txtPIN.Properties.Padding = New System.Windows.Forms.Padding(3)
        Me.txtPIN.Properties.ReadOnly = True
        Me.txtPIN.Properties.UseSystemPasswordChar = True
        Me.txtPIN.Size = New System.Drawing.Size(152, 38)
        Me.txtPIN.TabIndex = 1
        '
        'txtinvalidpin
        '
        Me.txtinvalidpin.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.txtinvalidpin.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.75!)
        Me.txtinvalidpin.Appearance.ForeColor = System.Drawing.Color.Yellow
        Me.txtinvalidpin.Appearance.Options.UseFont = True
        Me.txtinvalidpin.Appearance.Options.UseForeColor = True
        Me.txtinvalidpin.Appearance.Options.UseTextOptions = True
        Me.txtinvalidpin.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtinvalidpin.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.txtinvalidpin.Location = New System.Drawing.Point(201, 291)
        Me.txtinvalidpin.Name = "txtinvalidpin"
        Me.txtinvalidpin.Size = New System.Drawing.Size(176, 20)
        Me.txtinvalidpin.TabIndex = 387
        Me.txtinvalidpin.Text = "Invalid PIN, Please try again!"
        Me.txtinvalidpin.Visible = False
        '
        'TabNavigationPage2
        '
        Me.TabNavigationPage2.Caption = "Login with Password"
        Me.TabNavigationPage2.Controls.Add(Me.txtpassword)
        Me.TabNavigationPage2.Controls.Add(Me.cmdlogin)
        Me.TabNavigationPage2.Controls.Add(Me.lblCredential)
        Me.TabNavigationPage2.Controls.Add(Me.txtusername)
        Me.TabNavigationPage2.Controls.Add(Me.loadingPass)
        Me.TabNavigationPage2.Name = "TabNavigationPage2"
        Me.TabNavigationPage2.Size = New System.Drawing.Size(604, 329)
        '
        'txtpassword
        '
        Me.txtpassword.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtpassword.EditValue = ""
        Me.txtpassword.Location = New System.Drawing.Point(200, 128)
        Me.txtpassword.Name = "txtpassword"
        Me.txtpassword.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpassword.Properties.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.txtpassword.Properties.Appearance.Options.UseFont = True
        Me.txtpassword.Properties.Appearance.Options.UseForeColor = True
        Me.txtpassword.Properties.Appearance.Options.UseTextOptions = True
        Me.txtpassword.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtpassword.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.txtpassword.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.txtpassword.Properties.NullValuePrompt = "Password"
        Me.txtpassword.Properties.NullValuePromptShowForEmptyValue = True
        Me.txtpassword.Properties.UseSystemPasswordChar = True
        Me.txtpassword.Size = New System.Drawing.Size(191, 22)
        Me.txtpassword.TabIndex = 1
        '
        'cmdlogin
        '
        Me.cmdlogin.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdlogin.AutoSize = True
        Me.cmdlogin.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.cmdlogin.ImageOptions.Image = Global.CoffeecupDigitalDashboard.My.Resources.Resources.Action_Apply_32x32___dark
        Me.cmdlogin.Location = New System.Drawing.Point(267, 173)
        Me.cmdlogin.Name = "cmdlogin"
        Me.cmdlogin.Size = New System.Drawing.Size(40, 38)
        Me.cmdlogin.TabIndex = 628
        '
        'lblCredential
        '
        Me.lblCredential.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.lblCredential.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCredential.Appearance.Options.UseFont = True
        Me.lblCredential.Appearance.Options.UseTextOptions = True
        Me.lblCredential.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.lblCredential.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.lblCredential.Location = New System.Drawing.Point(200, 69)
        Me.lblCredential.Name = "lblCredential"
        Me.lblCredential.Size = New System.Drawing.Size(191, 13)
        Me.lblCredential.TabIndex = 626
        Me.lblCredential.Text = "Enter Login Credential"
        '
        'txtusername
        '
        Me.txtusername.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtusername.EditValue = ""
        Me.txtusername.EnterMoveNextControl = True
        Me.txtusername.Location = New System.Drawing.Point(200, 87)
        Me.txtusername.Name = "txtusername"
        Me.txtusername.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtusername.Properties.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.txtusername.Properties.Appearance.Options.UseFont = True
        Me.txtusername.Properties.Appearance.Options.UseForeColor = True
        Me.txtusername.Properties.Appearance.Options.UseTextOptions = True
        Me.txtusername.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtusername.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.txtusername.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.txtusername.Properties.NullValuePrompt = "Username"
        Me.txtusername.Properties.NullValuePromptShowForEmptyValue = True
        Me.txtusername.Size = New System.Drawing.Size(191, 22)
        Me.txtusername.TabIndex = 0
        '
        'loadingPass
        '
        Me.loadingPass.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.loadingPass.Appearance.Options.UseBackColor = True
        Me.loadingPass.BarAnimationElementThickness = 2
        Me.loadingPass.Location = New System.Drawing.Point(217, 65)
        Me.loadingPass.Name = "loadingPass"
        Me.loadingPass.Size = New System.Drawing.Size(246, 66)
        Me.loadingPass.TabIndex = 627
        Me.loadingPass.Text = "ProgressPanel1"
        Me.loadingPass.Visible = False
        '
        'TabNavigationPage3
        '
        Me.TabNavigationPage3.Caption = "Please Select Current Cashier"
        Me.TabNavigationPage3.Controls.Add(Me.cmdConfirmCashier)
        Me.TabNavigationPage3.Controls.Add(Me.cashierid)
        Me.TabNavigationPage3.Controls.Add(Me.Em)
        Me.TabNavigationPage3.Name = "TabNavigationPage3"
        Me.TabNavigationPage3.PageVisible = False
        Me.TabNavigationPage3.Size = New System.Drawing.Size(604, 300)
        '
        'cmdConfirmCashier
        '
        Me.cmdConfirmCashier.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdConfirmCashier.AutoSize = True
        Me.cmdConfirmCashier.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.cmdConfirmCashier.ImageOptions.Image = Global.CoffeecupDigitalDashboard.My.Resources.Resources.Forward_32x32_dark
        Me.cmdConfirmCashier.Location = New System.Drawing.Point(271, 244)
        Me.cmdConfirmCashier.Name = "cmdConfirmCashier"
        Me.cmdConfirmCashier.Size = New System.Drawing.Size(40, 38)
        Me.cmdConfirmCashier.TabIndex = 633
        '
        'cashierid
        '
        Me.cashierid.Location = New System.Drawing.Point(80, 252)
        Me.cashierid.Name = "cashierid"
        Me.cashierid.Size = New System.Drawing.Size(66, 21)
        Me.cashierid.TabIndex = 632
        Me.cashierid.Visible = False
        '
        'Em
        '
        Me.Em.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Em.Dock = System.Windows.Forms.DockStyle.Top
        Me.Em.Location = New System.Drawing.Point(0, 0)
        Me.Em.MainView = Me.GridView1
        Me.Em.Name = "Em"
        Me.Em.Size = New System.Drawing.Size(604, 235)
        Me.Em.TabIndex = 0
        Me.Em.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.Em
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.AllowGroupExpandAnimation = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridView1.OptionsBehavior.AllowSortAnimation = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsImageLoad.AnimationType = DevExpress.Utils.ImageContentAnimationType.SegmentedFade
        Me.GridView1.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridView1.OptionsSelection.UseIndicatorForSelection = False
        Me.GridView1.OptionsView.AnimationType = DevExpress.XtraGrid.Views.Base.GridAnimationType.AnimateFocusedItem
        Me.GridView1.OptionsView.ShowColumnHeaders = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.OptionsView.ShowIndicator = False
        Me.GridView1.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
        '
        'Timer1
        '
        Me.Timer1.Interval = 3000
        '
        'PanelUpdate
        '
        Me.PanelUpdate.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.PanelUpdate.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.PanelUpdate.Controls.Add(Me.LabelControl1)
        Me.PanelUpdate.Controls.Add(Me.txtDownloadLocation)
        Me.PanelUpdate.Controls.Add(Me.txtversion)
        Me.PanelUpdate.Controls.Add(Me.txtUpdateUrl)
        Me.PanelUpdate.Controls.Add(Me.Label1)
        Me.PanelUpdate.Controls.Add(Me.ProgressBar1)
        Me.PanelUpdate.Controls.Add(Me.SimpleButton2)
        Me.PanelUpdate.Location = New System.Drawing.Point(212, 34)
        Me.PanelUpdate.Name = "PanelUpdate"
        Me.PanelUpdate.Size = New System.Drawing.Size(604, 304)
        Me.PanelUpdate.TabIndex = 391
        Me.PanelUpdate.Visible = False
        '
        'LabelControl1
        '
        Me.LabelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelControl1.Appearance.ForeColor = System.Drawing.Color.Silver
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Appearance.Options.UseForeColor = True
        Me.LabelControl1.Appearance.Options.UseTextOptions = True
        Me.LabelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LabelControl1.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.LabelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl1.Location = New System.Drawing.Point(179, 111)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(252, 38)
        Me.LabelControl1.TabIndex = 631
        Me.LabelControl1.Text = "Please wait while system is updating your application"
        '
        'txtDownloadLocation
        '
        Me.txtDownloadLocation.Location = New System.Drawing.Point(438, 139)
        Me.txtDownloadLocation.Name = "txtDownloadLocation"
        Me.txtDownloadLocation.Size = New System.Drawing.Size(66, 21)
        Me.txtDownloadLocation.TabIndex = 630
        Me.txtDownloadLocation.Visible = False
        '
        'txtversion
        '
        Me.txtversion.Location = New System.Drawing.Point(438, 112)
        Me.txtversion.Name = "txtversion"
        Me.txtversion.Size = New System.Drawing.Size(66, 21)
        Me.txtversion.TabIndex = 629
        Me.txtversion.Visible = False
        '
        'txtUpdateUrl
        '
        Me.txtUpdateUrl.Location = New System.Drawing.Point(438, 85)
        Me.txtUpdateUrl.Name = "txtUpdateUrl"
        Me.txtUpdateUrl.Size = New System.Drawing.Size(66, 21)
        Me.txtUpdateUrl.TabIndex = 628
        Me.txtUpdateUrl.Visible = False
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Appearance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label1.Appearance.Options.UseFont = True
        Me.Label1.Appearance.Options.UseForeColor = True
        Me.Label1.Appearance.Options.UseTextOptions = True
        Me.Label1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Label1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.Label1.Location = New System.Drawing.Point(210, 167)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(191, 13)
        Me.Label1.TabIndex = 626
        Me.Label1.Text = "Downloading update.."
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.ProgressBar1.Location = New System.Drawing.Point(185, 153)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(240, 10)
        Me.ProgressBar1.TabIndex = 625
        Me.ProgressBar1.Visible = False
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.SimpleButton2.AutoSize = True
        Me.SimpleButton2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.SimpleButton2.Enabled = False
        Me.SimpleButton2.ImageOptions.Image = Global.CoffeecupDigitalDashboard.My.Resources.Resources.appbar_inbox
        Me.SimpleButton2.Location = New System.Drawing.Point(263, 56)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(84, 82)
        Me.SimpleButton2.TabIndex = 632
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton1.AutoSize = True
        Me.SimpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.SimpleButton1.ImageOptions.Image = Global.CoffeecupDigitalDashboard.My.Resources.Resources.Action_Close_32x32_dark
        Me.SimpleButton1.Location = New System.Drawing.Point(971, 12)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(40, 38)
        Me.SimpleButton1.TabIndex = 392
        '
        'frmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1029, 481)
        Me.ControlBox = False
        Me.Controls.Add(Me.SimpleButton1)
        Me.Controls.Add(Me.PanelLogin)
        Me.Controls.Add(Me.PanelUpdate)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.KeyPreview = True
        Me.Name = "frmLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Coffeecup System Digital Dashboard"
        CType(Me.PanelLogin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelLogin.ResumeLayout(False)
        CType(Me.TabPane1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPane1.ResumeLayout(False)
        Me.TabNavigationPage1.ResumeLayout(False)
        Me.TabNavigationPage1.PerformLayout()
        CType(Me.Profileimg.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPIN.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabNavigationPage2.ResumeLayout(False)
        Me.TabNavigationPage2.PerformLayout()
        CType(Me.txtpassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtusername.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabNavigationPage3.ResumeLayout(False)
        Me.TabNavigationPage3.PerformLayout()
        CType(Me.Em, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PanelUpdate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelUpdate.ResumeLayout(False)
        Me.PanelUpdate.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PanelLogin As DevExpress.XtraEditors.PanelControl
    Friend WithEvents txtPIN As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Profileimg As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents lblEnterPin As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtinvalidpin As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtFullname As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtOffice As DevExpress.XtraEditors.LabelControl
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents PanelUpdate As DevExpress.XtraEditors.PanelControl
    Friend WithEvents txtDownloadLocation As System.Windows.Forms.TextBox
    Friend WithEvents txtversion As System.Windows.Forms.TextBox
    Friend WithEvents txtUpdateUrl As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents txtuserid As System.Windows.Forms.TextBox
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TabPane1 As DevExpress.XtraBars.Navigation.TabPane
    Friend WithEvents TabNavigationPage1 As DevExpress.XtraBars.Navigation.TabNavigationPage
    Friend WithEvents TabNavigationPage2 As DevExpress.XtraBars.Navigation.TabNavigationPage
    Friend WithEvents TabNavigationPage3 As DevExpress.XtraBars.Navigation.TabNavigationPage
    Friend WithEvents Em As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents txtusername As DevExpress.XtraEditors.TextEdit
    Friend WithEvents lblCredential As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cashierid As System.Windows.Forms.TextBox
    Friend WithEvents loadingPin As DevExpress.XtraWaitForm.ProgressPanel
    Friend WithEvents loadingPass As DevExpress.XtraWaitForm.ProgressPanel
    Friend WithEvents cmdlogin As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents cmdConfirmCashier As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Private WithEvents txtpassword As DevExpress.XtraEditors.TextEdit
End Class
