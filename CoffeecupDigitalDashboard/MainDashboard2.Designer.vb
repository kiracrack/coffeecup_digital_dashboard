﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainDashboard2
    Inherits DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.FluentDesignFormContainer1 = New DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.TileCategory = New DevExpress.XtraEditors.TileControl()
        Me.TileNavPane1 = New DevExpress.XtraBars.Navigation.TileNavPane()
        Me.cmdBack = New DevExpress.XtraBars.Navigation.NavButton()
        Me.MainMenu = New DevExpress.XtraBars.Navigation.NavButton()
        Me.NavButton2 = New DevExpress.XtraBars.Navigation.NavButton()
        Me.cmdCurrentOrder = New DevExpress.XtraBars.Navigation.NavButton()
        Me.cmdtableQueue = New DevExpress.XtraBars.Navigation.NavButton()
        Me.cmdClose = New DevExpress.XtraBars.Navigation.NavButton()
        Me.AccordionControl1 = New DevExpress.XtraBars.Navigation.AccordionControl()
        Me.AccordionControlElement1 = New DevExpress.XtraBars.Navigation.AccordionControlElement()
        Me.FluentDesignFormControl1 = New DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl()
        Me.PopupMenu1 = New DevExpress.XtraBars.PopupMenu(Me.components)
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarButtonItem2 = New DevExpress.XtraBars.BarButtonItem()
        Me.BarManager1 = New DevExpress.XtraBars.BarManager(Me.components)
        Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
        Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
        Me.TileNavCategory1 = New DevExpress.XtraBars.Navigation.TileNavCategory()
        Me.FluentDesignFormContainer1.SuspendLayout()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XtraTabPage1.SuspendLayout()
        CType(Me.TileNavPane1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AccordionControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FluentDesignFormControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FluentDesignFormContainer1
        '
        Me.FluentDesignFormContainer1.Controls.Add(Me.XtraTabControl1)
        Me.FluentDesignFormContainer1.Controls.Add(Me.TileNavPane1)
        Me.FluentDesignFormContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FluentDesignFormContainer1.Location = New System.Drawing.Point(277, 0)
        Me.FluentDesignFormContainer1.Margin = New System.Windows.Forms.Padding(2)
        Me.FluentDesignFormContainer1.Name = "FluentDesignFormContainer1"
        Me.FluentDesignFormContainer1.Size = New System.Drawing.Size(1104, 706)
        Me.FluentDesignFormContainer1.TabIndex = 0
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 40)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XtraTabPage2
        Me.XtraTabControl1.ShowTabHeader = DevExpress.Utils.DefaultBoolean.[False]
        Me.XtraTabControl1.Size = New System.Drawing.Size(1104, 666)
        Me.XtraTabControl1.TabIndex = 11
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1, Me.XtraTabPage2})
        Me.XtraTabControl1.Transition.AllowTransition = DevExpress.Utils.DefaultBoolean.[True]
        '
        'XtraTabPage2
        '
        Me.XtraTabPage2.Name = "XtraTabPage2"
        Me.XtraTabPage2.Size = New System.Drawing.Size(1098, 660)
        Me.XtraTabPage2.Text = "XtraTabPage2"
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Controls.Add(Me.TileCategory)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(1335, 660)
        Me.XtraTabPage1.Text = "XtraTabPage1"
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
        Me.TileCategory.Size = New System.Drawing.Size(1335, 660)
        Me.TileCategory.TabIndex = 7
        Me.TileCategory.Text = "Sub Category Selection"
        '
        'TileNavPane1
        '
        Me.TileNavPane1.Buttons.Add(Me.cmdBack)
        Me.TileNavPane1.Buttons.Add(Me.MainMenu)
        Me.TileNavPane1.Buttons.Add(Me.NavButton2)
        Me.TileNavPane1.Buttons.Add(Me.cmdCurrentOrder)
        Me.TileNavPane1.Buttons.Add(Me.cmdtableQueue)
        Me.TileNavPane1.Buttons.Add(Me.cmdClose)
        '
        'TileNavCategory2
        '
        Me.TileNavPane1.DefaultCategory.Name = "TileNavCategory2"
        Me.TileNavPane1.DefaultCategory.OwnerCollection = Nothing
        '
        '
        '
        Me.TileNavPane1.DefaultCategory.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty
        Me.TileNavPane1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TileNavPane1.Location = New System.Drawing.Point(0, 0)
        Me.TileNavPane1.Name = "TileNavPane1"
        Me.TileNavPane1.Size = New System.Drawing.Size(1104, 40)
        Me.TileNavPane1.TabIndex = 10
        Me.TileNavPane1.Text = "TileNavPane1"
        '
        'cmdBack
        '
        Me.cmdBack.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Left
        Me.cmdBack.Caption = "Back"
        Me.cmdBack.Name = "cmdBack"
        '
        'MainMenu
        '
        Me.MainMenu.Caption = "Main Menu"
        Me.MainMenu.IsMain = True
        Me.MainMenu.Name = "MainMenu"
        Me.MainMenu.Visible = False
        '
        'NavButton2
        '
        Me.NavButton2.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right
        Me.NavButton2.Caption = "Set Current Permission"
        Me.NavButton2.Name = "NavButton2"
        '
        'cmdCurrentOrder
        '
        Me.cmdCurrentOrder.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right
        Me.cmdCurrentOrder.Caption = "Current Order"
        Me.cmdCurrentOrder.Name = "cmdCurrentOrder"
        '
        'cmdtableQueue
        '
        Me.cmdtableQueue.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right
        Me.cmdtableQueue.Caption = "Table Queue"
        Me.cmdtableQueue.Name = "cmdtableQueue"
        '
        'cmdClose
        '
        Me.cmdClose.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right
        Me.cmdClose.Caption = "Close Window"
        Me.cmdClose.Name = "cmdClose"
        '
        'AccordionControl1
        '
        Me.AccordionControl1.Dock = System.Windows.Forms.DockStyle.Left
        Me.AccordionControl1.Elements.AddRange(New DevExpress.XtraBars.Navigation.AccordionControlElement() {Me.AccordionControlElement1})
        Me.AccordionControl1.Location = New System.Drawing.Point(0, 0)
        Me.AccordionControl1.Margin = New System.Windows.Forms.Padding(2)
        Me.AccordionControl1.Name = "AccordionControl1"
        Me.AccordionControl1.OptionsMinimizing.NormalWidth = 277
        Me.AccordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch
        Me.AccordionControl1.Size = New System.Drawing.Size(277, 706)
        Me.AccordionControl1.TabIndex = 1
        Me.AccordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu
        '
        'AccordionControlElement1
        '
        Me.AccordionControlElement1.Name = "AccordionControlElement1"
        Me.AccordionControlElement1.Text = "Element1"
        '
        'FluentDesignFormControl1
        '
        Me.FluentDesignFormControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.FluentDesignFormControl1.FluentDesignForm = Me
        Me.FluentDesignFormControl1.Location = New System.Drawing.Point(0, 0)
        Me.FluentDesignFormControl1.Margin = New System.Windows.Forms.Padding(2)
        Me.FluentDesignFormControl1.Name = "FluentDesignFormControl1"
        Me.FluentDesignFormControl1.Size = New System.Drawing.Size(1381, 0)
        Me.FluentDesignFormControl1.TabIndex = 2
        Me.FluentDesignFormControl1.TabStop = False
        Me.FluentDesignFormControl1.Text = "Coffeecup Digital Dashboard"
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
        Me.barDockControlTop.Size = New System.Drawing.Size(1381, 0)
        '
        'barDockControlBottom
        '
        Me.barDockControlBottom.CausesValidation = False
        Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.barDockControlBottom.Location = New System.Drawing.Point(0, 706)
        Me.barDockControlBottom.Manager = Me.BarManager1
        Me.barDockControlBottom.Size = New System.Drawing.Size(1381, 0)
        '
        'barDockControlLeft
        '
        Me.barDockControlLeft.CausesValidation = False
        Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.barDockControlLeft.Location = New System.Drawing.Point(0, 0)
        Me.barDockControlLeft.Manager = Me.BarManager1
        Me.barDockControlLeft.Size = New System.Drawing.Size(0, 706)
        '
        'barDockControlRight
        '
        Me.barDockControlRight.CausesValidation = False
        Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.barDockControlRight.Location = New System.Drawing.Point(1381, 0)
        Me.barDockControlRight.Manager = Me.BarManager1
        Me.barDockControlRight.Size = New System.Drawing.Size(0, 706)
        '
        'TileNavCategory1
        '
        Me.TileNavCategory1.Name = "TileNavCategory1"
        Me.TileNavCategory1.OwnerCollection = Nothing
        '
        '
        '
        Me.TileNavCategory1.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty
        '
        'MainDashboard
        '
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1381, 706)
        Me.ControlContainer = Me.FluentDesignFormContainer1
        Me.Controls.Add(Me.FluentDesignFormContainer1)
        Me.Controls.Add(Me.AccordionControl1)
        Me.Controls.Add(Me.barDockControlLeft)
        Me.Controls.Add(Me.barDockControlRight)
        Me.Controls.Add(Me.barDockControlBottom)
        Me.Controls.Add(Me.barDockControlTop)
        Me.Controls.Add(Me.FluentDesignFormControl1)
        Me.FluentDesignFormControl = Me.FluentDesignFormControl1
        Me.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "MainDashboard"
        Me.NavigationControl = Me.AccordionControl1
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Coffeecup Digital Dashboard"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.FluentDesignFormContainer1.ResumeLayout(False)
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        CType(Me.TileNavPane1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AccordionControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FluentDesignFormControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BarManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FluentDesignFormContainer1 As DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer
    Friend WithEvents AccordionControl1 As DevExpress.XtraBars.Navigation.AccordionControl
    Friend WithEvents AccordionControlElement1 As DevExpress.XtraBars.Navigation.AccordionControlElement
    Friend WithEvents FluentDesignFormControl1 As DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents TileCategory As DevExpress.XtraEditors.TileControl
    Friend WithEvents barDockControlLeft As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarManager1 As DevExpress.XtraBars.BarManager
    Friend WithEvents barDockControlTop As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlBottom As DevExpress.XtraBars.BarDockControl
    Friend WithEvents barDockControlRight As DevExpress.XtraBars.BarDockControl
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents BarButtonItem2 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents PopupMenu1 As DevExpress.XtraBars.PopupMenu
    Friend WithEvents TileNavPane1 As DevExpress.XtraBars.Navigation.TileNavPane
    Friend WithEvents cmdBack As DevExpress.XtraBars.Navigation.NavButton
    Friend WithEvents MainMenu As DevExpress.XtraBars.Navigation.NavButton
    Friend WithEvents NavButton2 As DevExpress.XtraBars.Navigation.NavButton
    Friend WithEvents cmdCurrentOrder As DevExpress.XtraBars.Navigation.NavButton
    Friend WithEvents cmdtableQueue As DevExpress.XtraBars.Navigation.NavButton
    Friend WithEvents cmdClose As DevExpress.XtraBars.Navigation.NavButton
    Friend WithEvents TileNavCategory1 As DevExpress.XtraBars.Navigation.TileNavCategory
End Class
