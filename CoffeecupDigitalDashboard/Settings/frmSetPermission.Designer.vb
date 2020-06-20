<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSetPermission
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
        Me.cmdSave = New DevExpress.XtraEditors.SimpleButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPermission = New DevExpress.XtraEditors.SearchLookUpEdit()
        Me.gridPermission = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.txtPermission.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridPermission, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdSave
        '
        Me.cmdSave.Appearance.Font = New System.Drawing.Font("Segoe UI", 12.25!)
        Me.cmdSave.Appearance.Options.UseFont = True
        Me.cmdSave.Location = New System.Drawing.Point(132, 73)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(130, 37)
        Me.cmdSave.TabIndex = 1
        Me.cmdSave.Text = "Save"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(125, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(144, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Select User Permission"
        '
        'txtPermission
        '
        Me.txtPermission.EditValue = ""
        Me.txtPermission.Location = New System.Drawing.Point(34, 35)
        Me.txtPermission.Name = "txtPermission"
        Me.txtPermission.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 14.25!)
        Me.txtPermission.Properties.Appearance.Options.UseFont = True
        Me.txtPermission.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtPermission.Properties.DisplayMember = "Select"
        Me.txtPermission.Properties.NullText = ""
        Me.txtPermission.Properties.PopupView = Me.gridPermission
        Me.txtPermission.Properties.ValueMember = "authcode"
        Me.txtPermission.Size = New System.Drawing.Size(335, 32)
        Me.txtPermission.TabIndex = 707
        '
        'gridPermission
        '
        Me.gridPermission.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.gridPermission.Name = "gridPermission"
        Me.gridPermission.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.gridPermission.OptionsView.ShowGroupPanel = False
        '
        'frmSetPermission
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(399, 125)
        Me.Controls.Add(Me.txtPermission)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdSave)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmSetPermission"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "User Permission"
        CType(Me.txtPermission.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridPermission, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdSave As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPermission As DevExpress.XtraEditors.SearchLookUpEdit
    Friend WithEvents gridPermission As DevExpress.XtraGrid.Views.Grid.GridView
End Class
