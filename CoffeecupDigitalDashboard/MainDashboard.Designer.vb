<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainDashboard
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
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem2 = New DevExpress.XtraBars.BarButtonItem()
        Me.PopupMenu1 = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.AccordionControl1 = New DevExpress.XtraBars.Navigation.AccordionControl()
        Me.AccordionContentContainer1 = New DevExpress.XtraBars.Navigation.AccordionContentContainer()
        Me.txtTotalDiscount = New DevExpress.XtraEditors.LabelControl()
        Me.txtTotalCharge = New DevExpress.XtraEditors.LabelControl()
        Me.txtTotalItem = New DevExpress.XtraEditors.LabelControl()
        Me.txtBatchcode = New DevExpress.XtraEditors.LabelControl()
        Me.txtServiceCharge = New DevExpress.XtraEditors.LabelControl()
        Me.txtTotalTax = New DevExpress.XtraEditors.LabelControl()
        Me.txtTotalOnScreen = New DevExpress.XtraEditors.LabelControl()
        Me.AccordionControlElement1 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AccordionControlElement2 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.AccordionControlSeparator1 = New DevExpress.XtraBars.Navigation.AccordionControlSeparator()
        Me.AccordionControlElement3 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.TileNavPane1 = New DevExpress.XtraBars.Navigation.TileNavPane()
        Me.cmdBack = New DevExpress.XtraBars.Navigation.NavButton()
        Me.cmdDashboard = New DevExpress.XtraBars.Navigation.NavButton()
        Me.cmdtableQueue = New DevExpress.XtraBars.Navigation.NavButton()
        Me.cmdCurrentOrder = New DevExpress.XtraBars.Navigation.NavButton()
        Me.cmdClose = New DevExpress.XtraBars.Navigation.NavButton()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.tabDigitalScreen = New DevExpress.XtraTab.XtraTabPage()
        Me.TileCategory = New DevExpress.XtraEditors.TileControl()
        Me.tabTableQueue = New DevExpress.XtraTab.XtraTabPage()
        Me.tabCurrentOrder = New DevExpress.XtraTab.XtraTabPage()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.Em = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.cifid = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.gridcif = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtuserid = New DevExpress.XtraEditors.TextEdit()
        Me.txtSubTotal = New DevExpress.XtraEditors.LabelControl()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AccordionControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.AccordionControl1.SuspendLayout()
        Me.AccordionContentContainer1.SuspendLayout()
        CType(Me.TileNavPane1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.tabDigitalScreen.SuspendLayout()
        Me.tabCurrentOrder.SuspendLayout()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.Em, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cifid.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridcif, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtuserid.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarManager1
        '
        Me.BarManager1.AllowHtmlText = True
        Me.BarManager1.DockControls.Add(Me.barDockControlTop)
        Me.BarManager1.DockControls.Add(Me.barDockControlBottom)
        Me.BarManager1.DockControls.Add(Me.barDockControlLeft)
        Me.BarManager1.DockControls.Add(Me.barDockControlRight)
        Me.BarManager1.Form = Me
        Me.BarManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.BarButtonItem1, Me.BarButtonItem2})
        Me.BarManager1.MaxItemId = 2
        '
        'barDockControlTop
        '
        Me.barDockControlTop.CausesValidation = False
        Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlTop.Manager = Me.BarManager1
        Me.barDockControlTop.Size = New System.Drawing.Size(1148, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 646)
        Me.barDockControlBottom.Manager = Me.BarManager1
        Me.barDockControlBottom.Size = New System.Drawing.Size(1148, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Manager = Me.BarManager1
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 646)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1148, 0)
        Me.barDockControlRight.Manager = Me.BarManager1
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 646)
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "View Order"
        Me.BarButtonItem1.Description = "Show list of guest order"
        Me.BarButtonItem1.Id = 0
        Me.BarButtonItem1.ImageOptions.LargeImage = Global.CoffeecupDigitalDashboard.My.Resources.Resources.MemoStyle__2_
        Me.BarButtonItem1.Name = "BarButtonItem1"
        Me.BarButtonItem1.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        '
        'BarButtonItem2
        '
        Me.BarButtonItem2.Caption = "Process Order"
        Me.BarButtonItem2.Description = "Process order to cashier for billing"
        Me.BarButtonItem2.Id = 1
        Me.BarButtonItem2.ImageOptions.AllowStubGlyph = DevExpress.Utils.DefaultBoolean.[True]
        Me.BarButtonItem2.ImageOptions.LargeImage = Global.CoffeecupDigitalDashboard.My.Resources.Resources.ConvertToRange_32x32
        Me.BarButtonItem2.Name = "BarButtonItem2"
        Me.BarButtonItem2.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph
        Me.BarButtonItem2.ShortcutKeyDisplayString = "Process"
        '
        'PopupMenu1
        '
        Me.PopupMenu1.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() {New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem1), New DevExpress.XtraBars.LinkPersistInfo(Me.BarButtonItem2)})
        Me.PopupMenu1.Manager = Me.BarManager1
        Me.PopupMenu1.MenuAppearance.HeaderItemAppearance.Options.UseTextOptions = True
        Me.PopupMenu1.MenuAppearance.HeaderItemAppearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.PopupMenu1.MenuCaption = "Navigation"
        Me.PopupMenu1.MenuDrawMode = DevExpress.XtraBars.MenuDrawMode.LargeImagesTextDescription
        Me.PopupMenu1.Name = "PopupMenu1"
        Me.PopupMenu1.OptionsMultiColumn.ImageHorizontalAlignment = DevExpress.Utils.Drawing.ItemHorizontalAlignment.Center
        Me.PopupMenu1.OptionsMultiColumn.ImageVerticalAlignment = DevExpress.Utils.Drawing.ItemVerticalAlignment.Center
        Me.PopupMenu1.ShowCaption = True
        Me.PopupMenu1.ShowNavigationHeader = DevExpress.Utils.DefaultBoolean.[True]
        '
        'AccordionControl1
        '
        Me.AccordionControl1.Controls.Add(Me.AccordionContentContainer1)
        Me.AccordionControl1.Dock = System.Windows.Forms.DockStyle.Right
        Me.AccordionControl1.Elements.AddRange(New DevExpress.XtraBars.Navigation.AccordionControlElement() {Me.AccordionControlElement1})
        Me.AccordionControl1.Location = New System.Drawing.Point(798, 0)
        Me.AccordionControl1.Name = "AccordionControl1"
        Me.AccordionControl1.OptionsMinimizing.NormalWidth = 350
        Me.AccordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch
        Me.AccordionControl1.ShowFilterControl = DevExpress.XtraBars.Navigation.ShowFilterControl.Always
        Me.AccordionControl1.Size = New System.Drawing.Size(350, 646)
        Me.AccordionControl1.TabIndex = 4
        Me.AccordionControl1.Text = "AccordionControl1"
        Me.AccordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu
        '
        'AccordionContentContainer1
        '
        Me.AccordionContentContainer1.Controls.Add(Me.txtSubTotal)
        Me.AccordionContentContainer1.Controls.Add(Me.LabelControl1)
        Me.AccordionContentContainer1.Controls.Add(Me.cifid)
        Me.AccordionContentContainer1.Controls.Add(Me.txtTotalDiscount)
        Me.AccordionContentContainer1.Controls.Add(Me.txtTotalCharge)
        Me.AccordionContentContainer1.Controls.Add(Me.txtTotalItem)
        Me.AccordionContentContainer1.Controls.Add(Me.txtBatchcode)
        Me.AccordionContentContainer1.Controls.Add(Me.txtServiceCharge)
        Me.AccordionContentContainer1.Controls.Add(Me.txtTotalTax)
        Me.AccordionContentContainer1.Controls.Add(Me.txtTotalOnScreen)
        Me.AccordionContentContainer1.Name = "AccordionContentContainer1"
        Me.AccordionContentContainer1.Size = New System.Drawing.Size(333, 394)
        Me.AccordionContentContainer1.TabIndex = 3
        '
        'txtTotalDiscount
        '
        Me.txtTotalDiscount.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalDiscount.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 12.25!, System.Drawing.FontStyle.Bold)
        Me.txtTotalDiscount.Appearance.ForeColor = System.Drawing.Color.Lime
        Me.txtTotalDiscount.Appearance.Options.UseFont = True
        Me.txtTotalDiscount.Appearance.Options.UseForeColor = True
        Me.txtTotalDiscount.Appearance.Options.UseTextOptions = True
        Me.txtTotalDiscount.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtTotalDiscount.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.txtTotalDiscount.Location = New System.Drawing.Point(8, 302)
        Me.txtTotalDiscount.Name = "txtTotalDiscount"
        Me.txtTotalDiscount.Size = New System.Drawing.Size(309, 18)
        Me.txtTotalDiscount.TabIndex = 14
        Me.txtTotalDiscount.Text = "500"
        '
        'txtTotalCharge
        '
        Me.txtTotalCharge.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalCharge.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 12.25!, System.Drawing.FontStyle.Bold)
        Me.txtTotalCharge.Appearance.ForeColor = System.Drawing.Color.Lime
        Me.txtTotalCharge.Appearance.Options.UseFont = True
        Me.txtTotalCharge.Appearance.Options.UseForeColor = True
        Me.txtTotalCharge.Appearance.Options.UseTextOptions = True
        Me.txtTotalCharge.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtTotalCharge.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.txtTotalCharge.Location = New System.Drawing.Point(8, 278)
        Me.txtTotalCharge.Name = "txtTotalCharge"
        Me.txtTotalCharge.Size = New System.Drawing.Size(309, 18)
        Me.txtTotalCharge.TabIndex = 13
        Me.txtTotalCharge.Text = "500"
        '
        'txtTotalItem
        '
        Me.txtTotalItem.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalItem.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 12.25!, System.Drawing.FontStyle.Bold)
        Me.txtTotalItem.Appearance.ForeColor = System.Drawing.Color.Lime
        Me.txtTotalItem.Appearance.Options.UseFont = True
        Me.txtTotalItem.Appearance.Options.UseForeColor = True
        Me.txtTotalItem.Appearance.Options.UseTextOptions = True
        Me.txtTotalItem.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtTotalItem.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.txtTotalItem.Location = New System.Drawing.Point(8, 254)
        Me.txtTotalItem.Name = "txtTotalItem"
        Me.txtTotalItem.Size = New System.Drawing.Size(309, 18)
        Me.txtTotalItem.TabIndex = 12
        Me.txtTotalItem.Text = "500"
        '
        'txtBatchcode
        '
        Me.txtBatchcode.Appearance.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBatchcode.Appearance.Options.UseFont = True
        Me.txtBatchcode.Appearance.Options.UseTextOptions = True
        Me.txtBatchcode.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtBatchcode.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.txtBatchcode.Location = New System.Drawing.Point(6, 3)
        Me.txtBatchcode.Name = "txtBatchcode"
        Me.txtBatchcode.Size = New System.Drawing.Size(309, 27)
        Me.txtBatchcode.TabIndex = 11
        Me.txtBatchcode.Text = "Batch Code"
        '
        'txtServiceCharge
        '
        Me.txtServiceCharge.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtServiceCharge.Appearance.Font = New System.Drawing.Font("Agency FB", 22.25!, System.Drawing.FontStyle.Bold)
        Me.txtServiceCharge.Appearance.ForeColor = System.Drawing.Color.Lime
        Me.txtServiceCharge.Appearance.Options.UseFont = True
        Me.txtServiceCharge.Appearance.Options.UseForeColor = True
        Me.txtServiceCharge.Appearance.Options.UseTextOptions = True
        Me.txtServiceCharge.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtServiceCharge.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.txtServiceCharge.Location = New System.Drawing.Point(8, 215)
        Me.txtServiceCharge.Name = "txtServiceCharge"
        Me.txtServiceCharge.Size = New System.Drawing.Size(309, 24)
        Me.txtServiceCharge.TabIndex = 10
        Me.txtServiceCharge.Text = "500"
        '
        'txtTotalTax
        '
        Me.txtTotalTax.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalTax.Appearance.Font = New System.Drawing.Font("Agency FB", 22.25!, System.Drawing.FontStyle.Bold)
        Me.txtTotalTax.Appearance.ForeColor = System.Drawing.Color.Lime
        Me.txtTotalTax.Appearance.Options.UseFont = True
        Me.txtTotalTax.Appearance.Options.UseForeColor = True
        Me.txtTotalTax.Appearance.Options.UseTextOptions = True
        Me.txtTotalTax.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtTotalTax.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.txtTotalTax.Location = New System.Drawing.Point(8, 185)
        Me.txtTotalTax.Name = "txtTotalTax"
        Me.txtTotalTax.Size = New System.Drawing.Size(309, 24)
        Me.txtTotalTax.TabIndex = 9
        Me.txtTotalTax.Text = "500"
        '
        'txtTotalOnScreen
        '
        Me.txtTotalOnScreen.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtTotalOnScreen.Appearance.Font = New System.Drawing.Font("Agency FB", 32.25!, System.Drawing.FontStyle.Bold)
        Me.txtTotalOnScreen.Appearance.ForeColor = System.Drawing.Color.Lime
        Me.txtTotalOnScreen.Appearance.Options.UseFont = True
        Me.txtTotalOnScreen.Appearance.Options.UseForeColor = True
        Me.txtTotalOnScreen.Appearance.Options.UseTextOptions = True
        Me.txtTotalOnScreen.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtTotalOnScreen.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.txtTotalOnScreen.Location = New System.Drawing.Point(8, 127)
        Me.txtTotalOnScreen.Name = "txtTotalOnScreen"
        Me.txtTotalOnScreen.Size = New System.Drawing.Size(309, 52)
        Me.txtTotalOnScreen.TabIndex = 8
        Me.txtTotalOnScreen.Text = "500"
        '
        'AccordionControlElement1
        '
        Me.AccordionControlElement1.Elements.AddRange(New DevExpress.XtraBars.Navigation.AccordionControlElement() {Me.AccordionControlElement2, Me.AccordionControlSeparator1, Me.AccordionControlElement3})
        Me.AccordionControlElement1.Expanded = True
        Me.AccordionControlElement1.Name = "AccordionControlElement1"
        Me.AccordionControlElement1.Text = "Digital Dashboard"
        '
        'AccordionControlElement2
        '
        Me.AccordionControlElement2.ContentContainer = Me.AccordionContentContainer1
        Me.AccordionControlElement2.Expanded = True
        Me.AccordionControlElement2.Name = "AccordionControlElement2"
        Me.AccordionControlElement2.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.AccordionControlElement2.Text = "Transaction Header"
        '
        'AccordionControlSeparator1
        '
        Me.AccordionControlSeparator1.Name = "AccordionControlSeparator1"
        '
        'AccordionControlElement3
        '
        Me.AccordionControlElement3.Name = "AccordionControlElement3"
        Me.AccordionControlElement3.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item
        Me.AccordionControlElement3.Text = "Element3"
        '
        'TileNavPane1
        '
        Me.TileNavPane1.Buttons.Add(Me.cmdBack)
        Me.TileNavPane1.Buttons.Add(Me.cmdDashboard)
        Me.TileNavPane1.Buttons.Add(Me.cmdtableQueue)
        Me.TileNavPane1.Buttons.Add(Me.cmdCurrentOrder)
        Me.TileNavPane1.Buttons.Add(Me.cmdClose)
        '
        'TileNavCategory1
        '
        Me.TileNavPane1.DefaultCategory.Name = "TileNavCategory1"
        Me.TileNavPane1.DefaultCategory.OwnerCollection = Nothing
        '
        '
        '
        Me.TileNavPane1.DefaultCategory.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty
        Me.TileNavPane1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TileNavPane1.Location = New System.Drawing.Point(0, 0)
        Me.TileNavPane1.Name = "TileNavPane1"
        Me.TileNavPane1.Size = New System.Drawing.Size(798, 40)
        Me.TileNavPane1.TabIndex = 10
        Me.TileNavPane1.Text = "TileNavPane1"
        '
        'cmdBack
        '
        Me.cmdBack.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Left
        Me.cmdBack.AppearanceHovered.BackColor = System.Drawing.Color.Black
        Me.cmdBack.AppearanceHovered.Options.UseBackColor = True
        Me.cmdBack.Caption = "Back Menu"
        Me.cmdBack.Name = "cmdBack"
        '
        'cmdDashboard
        '
        Me.cmdDashboard.AppearanceHovered.BackColor = System.Drawing.Color.Black
        Me.cmdDashboard.AppearanceHovered.Options.UseBackColor = True
        Me.cmdDashboard.Caption = "Main Dashboard"
        Me.cmdDashboard.Name = "cmdDashboard"
        '
        'cmdtableQueue
        '
        Me.cmdtableQueue.AppearanceHovered.BackColor = System.Drawing.Color.Black
        Me.cmdtableQueue.AppearanceHovered.Options.UseBackColor = True
        Me.cmdtableQueue.Caption = "Table Queue"
        Me.cmdtableQueue.Name = "cmdtableQueue"
        '
        'cmdCurrentOrder
        '
        Me.cmdCurrentOrder.AppearanceHovered.BackColor = System.Drawing.Color.Black
        Me.cmdCurrentOrder.AppearanceHovered.Options.UseBackColor = True
        Me.cmdCurrentOrder.Caption = "Current Order"
        Me.cmdCurrentOrder.Name = "cmdCurrentOrder"
        '
        'cmdClose
        '
        Me.cmdClose.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right
        Me.cmdClose.AppearanceHovered.BackColor = System.Drawing.Color.Black
        Me.cmdClose.AppearanceHovered.Options.UseBackColor = True
        Me.cmdClose.Caption = "Close Window"
        Me.cmdClose.Name = "cmdClose"
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.AppearancePage.Header.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.XtraTabControl1.AppearancePage.Header.Options.UseFont = True
        Me.XtraTabControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 40)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.tabDigitalScreen
        Me.XtraTabControl1.Size = New System.Drawing.Size(798, 606)
        Me.XtraTabControl1.TabIndex = 11
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.tabDigitalScreen, Me.tabTableQueue, Me.tabCurrentOrder})
        Me.XtraTabControl1.Transition.AllowTransition = DevExpress.Utils.DefaultBoolean.[True]
        '
        'tabDigitalScreen
        '
        Me.tabDigitalScreen.Controls.Add(Me.txtuserid)
        Me.tabDigitalScreen.Controls.Add(Me.TileCategory)
        Me.tabDigitalScreen.Name = "tabDigitalScreen"
        Me.tabDigitalScreen.Size = New System.Drawing.Size(792, 581)
        Me.tabDigitalScreen.Text = "Digital Screen"
        '
        'TileCategory
        '
        Me.TileCategory.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TileCategory.HorizontalContentAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.TileCategory.Location = New System.Drawing.Point(0, 0)
        Me.TileCategory.MaxId = 25
        Me.TileCategory.Name = "TileCategory"
        Me.TileCategory.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.TileCategory.ShowGroupText = True
        Me.TileCategory.ShowText = True
        Me.TileCategory.Size = New System.Drawing.Size(792, 581)
        Me.TileCategory.TabIndex = 7
        Me.TileCategory.Text = "Digital Screen"
        '
        'tabTableQueue
        '
        Me.tabTableQueue.Name = "tabTableQueue"
        Me.tabTableQueue.Size = New System.Drawing.Size(792, 581)
        Me.tabTableQueue.Text = "Table Queue"
        '
        'tabCurrentOrder
        '
        Me.tabCurrentOrder.Controls.Add(Me.SplitContainerControl1)
        Me.tabCurrentOrder.Name = "tabCurrentOrder"
        Me.tabCurrentOrder.Size = New System.Drawing.Size(792, 581)
        Me.tabCurrentOrder.Text = "Current Order"
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Horizontal = False
        Me.SplitContainerControl1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.SimpleButton2)
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.SimpleButton1)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.Em)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(792, 581)
        Me.SplitContainerControl1.SplitterPosition = 71
        Me.SplitContainerControl1.TabIndex = 2
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton2.Appearance.Options.UseFont = True
        Me.SimpleButton2.AutoSize = True
        Me.SimpleButton2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.SimpleButton2.ImageOptions.Image = Global.CoffeecupDigitalDashboard.My.Resources.Resources.Cancel_32x32_dark
        Me.SimpleButton2.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.SimpleButton2.Location = New System.Drawing.Point(6, 6)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.Size = New System.Drawing.Size(78, 57)
        Me.SimpleButton2.TabIndex = 394
        Me.SimpleButton2.Text = "Cancel Order"
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton1.Appearance.Options.UseFont = True
        Me.SimpleButton1.AutoSize = True
        Me.SimpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat
        Me.SimpleButton1.ImageOptions.Image = Global.CoffeecupDigitalDashboard.My.Resources.Resources.Apply_32x32_dark
        Me.SimpleButton1.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.TopCenter
        Me.SimpleButton1.Location = New System.Drawing.Point(90, 6)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.Size = New System.Drawing.Size(86, 57)
        Me.SimpleButton1.TabIndex = 393
        Me.SimpleButton1.Text = "Confirm Order"
        '
        'Em
        '
        Me.Em.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Em.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Em.Location = New System.Drawing.Point(0, 0)
        Me.Em.MainView = Me.GridView1
        Me.Em.Name = "Em"
        Me.Em.Size = New System.Drawing.Size(792, 505)
        Me.Em.TabIndex = 1
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
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowColumnHeaders = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.OptionsView.ShowIndicator = False
        Me.GridView1.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Panel
        '
        'cifid
        '
        Me.cifid.EditValue = ""
        Me.cifid.Location = New System.Drawing.Point(97, 36)
        Me.cifid.Name = "cifid"
        Me.cifid.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.5!)
        Me.cifid.Properties.Appearance.Options.UseFont = True
        Me.cifid.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.cifid.Properties.DisplayMember = "Customer Name"
        Me.cifid.Properties.NullText = ""
        Me.cifid.Properties.PopupView = Me.gridcif
        Me.cifid.Properties.ValueMember = "cifid"
        Me.cifid.Size = New System.Drawing.Size(218, 24)
        Me.cifid.TabIndex = 745
        '
        'gridcif
        '
        Me.gridcif.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.gridcif.Name = "gridcif"
        Me.gridcif.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.gridcif.OptionsView.ShowGroupPanel = False
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Options.UseTextOptions = True
        Me.LabelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LabelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.LabelControl1.Location = New System.Drawing.Point(5, 35)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(86, 27)
        Me.LabelControl1.TabIndex = 746
        Me.LabelControl1.Text = "Customer"
        '
        'txtuserid
        '
        Me.txtuserid.Location = New System.Drawing.Point(709, 9)
        Me.txtuserid.MenuManager = Me.BarManager1
        Me.txtuserid.Name = "txtuserid"
        Me.txtuserid.Size = New System.Drawing.Size(66, 20)
        Me.txtuserid.TabIndex = 747
        '
        'txtSubTotal
        '
        Me.txtSubTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtSubTotal.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 12.25!, System.Drawing.FontStyle.Bold)
        Me.txtSubTotal.Appearance.ForeColor = System.Drawing.Color.Lime
        Me.txtSubTotal.Appearance.Options.UseFont = True
        Me.txtSubTotal.Appearance.Options.UseForeColor = True
        Me.txtSubTotal.Appearance.Options.UseTextOptions = True
        Me.txtSubTotal.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.txtSubTotal.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None
        Me.txtSubTotal.Location = New System.Drawing.Point(8, 326)
        Me.txtSubTotal.Name = "txtSubTotal"
        Me.txtSubTotal.Size = New System.Drawing.Size(309, 18)
        Me.txtSubTotal.TabIndex = 747
        Me.txtSubTotal.Text = "500"
        '
        'MainDashboard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1148, 646)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Controls.Add(Me.TileNavPane1)
        Me.Controls.Add(Me.AccordionControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "MainDashboard"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Coffeecup System Digital Dashboard"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AccordionControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.AccordionControl1.ResumeLayout(False)
        Me.AccordionContentContainer1.ResumeLayout(False)
        CType(Me.TileNavPane1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.tabDigitalScreen.ResumeLayout(False)
        Me.tabCurrentOrder.ResumeLayout(False)
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerControl1.ResumeLayout(False)
        CType(Me.Em, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cifid.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridcif, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtuserid.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents PopupMenu1 As DevExpress.XtraBars.PopupMenu
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents AccordionControl1 As DevExpress.XtraBars.Navigation.AccordionControl
    Friend WithEvents AccordionControlElement1 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents TileNavPane1 As DevExpress.XtraBars.Navigation.TileNavPane
    Friend WithEvents cmdBack As DevExpress.XtraBars.Navigation.NavButton
    Friend WithEvents cmdDashboard As DevExpress.XtraBars.Navigation.NavButton
    Friend WithEvents cmdtableQueue As DevExpress.XtraBars.Navigation.NavButton
    Friend WithEvents cmdClose As DevExpress.XtraBars.Navigation.NavButton
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents tabDigitalScreen As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents TileCategory As DevExpress.XtraEditors.TileControl
    Friend WithEvents tabTableQueue As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents cmdCurrentOrder As DevExpress.XtraBars.Navigation.NavButton
    Friend WithEvents tabCurrentOrder As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents Em As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents AccordionContentContainer1 As DevExpress.XtraBars.Navigation.AccordionContentContainer
    Friend WithEvents AccordionControlElement2 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents AccordionControlElement3 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Private WithEvents AccordionControlSeparator1 As DevExpress.XtraBars.Navigation.AccordionControlSeparator
    Friend WithEvents txtTotalOnScreen As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtTotalDiscount As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtTotalCharge As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtTotalItem As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtBatchcode As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtServiceCharge As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtTotalTax As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents cifid As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents gridcif As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents txtuserid As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtSubTotal As DevExpress.XtraEditors.LabelControl

End Class
