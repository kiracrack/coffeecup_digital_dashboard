<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConnectionSetup
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
        Me.txtpassword = New DevExpress.XtraEditors.TextEdit()
        Me.txtusername = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.txtServerhost = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.txtDatabase = New DevExpress.XtraEditors.TextEdit()
        Me.cmdUpdate = New DevExpress.XtraEditors.SimpleButton()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.txtFileDir = New DevExpress.XtraEditors.TextEdit()
        Me.txtPort = New DevExpress.XtraEditors.TextEdit()
        CType(Me.txtpassword.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtusername.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtServerhost.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDatabase.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFileDir.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPort.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtpassword
        '
        Me.txtpassword.EditValue = "Password"
        Me.txtpassword.Location = New System.Drawing.Point(200, 87)
        Me.txtpassword.Name = "txtpassword"
        Me.txtpassword.Properties.Appearance.Font = New System.Drawing.Font("Wingdings", 10.25!)
        Me.txtpassword.Properties.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.txtpassword.Properties.Appearance.Options.UseFont = True
        Me.txtpassword.Properties.Appearance.Options.UseForeColor = True
        Me.txtpassword.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.txtpassword.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.txtpassword.Properties.AutoHeight = False
        Me.txtpassword.Properties.PasswordChar = Global.Microsoft.VisualBasic.ChrW(108)
        Me.txtpassword.Size = New System.Drawing.Size(191, 26)
        Me.txtpassword.TabIndex = 4
        '
        'txtusername
        '
        Me.txtusername.EditValue = "Username"
        Me.txtusername.EnterMoveNextControl = True
        Me.txtusername.Location = New System.Drawing.Point(200, 58)
        Me.txtusername.Name = "txtusername"
        Me.txtusername.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.25!)
        Me.txtusername.Properties.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.txtusername.Properties.Appearance.Options.UseFont = True
        Me.txtusername.Properties.Appearance.Options.UseForeColor = True
        Me.txtusername.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.txtusername.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.txtusername.Size = New System.Drawing.Size(308, 26)
        Me.txtusername.TabIndex = 3
        '
        'LabelControl1
        '
        Me.LabelControl1.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.25!)
        Me.LabelControl1.Appearance.Options.UseFont = True
        Me.LabelControl1.Location = New System.Drawing.Point(133, 92)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(58, 19)
        Me.LabelControl1.TabIndex = 458
        Me.LabelControl1.Text = "Password"
        '
        'LabelControl2
        '
        Me.LabelControl2.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.25!)
        Me.LabelControl2.Appearance.Options.UseFont = True
        Me.LabelControl2.Location = New System.Drawing.Point(129, 61)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(62, 19)
        Me.LabelControl2.TabIndex = 459
        Me.LabelControl2.Text = "Username"
        '
        'LabelControl4
        '
        Me.LabelControl4.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.25!)
        Me.LabelControl4.Appearance.Options.UseFont = True
        Me.LabelControl4.Location = New System.Drawing.Point(101, 32)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(90, 19)
        Me.LabelControl4.TabIndex = 460
        Me.LabelControl4.Text = "Database Host"
        '
        'txtServerhost
        '
        Me.txtServerhost.EditValue = "localhost"
        Me.txtServerhost.EnterMoveNextControl = True
        Me.txtServerhost.Location = New System.Drawing.Point(200, 29)
        Me.txtServerhost.Name = "txtServerhost"
        Me.txtServerhost.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.25!)
        Me.txtServerhost.Properties.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.txtServerhost.Properties.Appearance.Options.UseFont = True
        Me.txtServerhost.Properties.Appearance.Options.UseForeColor = True
        Me.txtServerhost.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.txtServerhost.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.txtServerhost.Size = New System.Drawing.Size(234, 26)
        Me.txtServerhost.TabIndex = 1
        '
        'LabelControl3
        '
        Me.LabelControl3.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.25!)
        Me.LabelControl3.Appearance.Options.UseFont = True
        Me.LabelControl3.Location = New System.Drawing.Point(134, 119)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(57, 19)
        Me.LabelControl3.TabIndex = 466
        Me.LabelControl3.Text = "Database"
        '
        'txtDatabase
        '
        Me.txtDatabase.EditValue = "Database"
        Me.txtDatabase.EnterMoveNextControl = True
        Me.txtDatabase.Location = New System.Drawing.Point(200, 116)
        Me.txtDatabase.Name = "txtDatabase"
        Me.txtDatabase.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.25!)
        Me.txtDatabase.Properties.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.txtDatabase.Properties.Appearance.Options.UseFont = True
        Me.txtDatabase.Properties.Appearance.Options.UseForeColor = True
        Me.txtDatabase.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.txtDatabase.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.txtDatabase.Size = New System.Drawing.Size(191, 26)
        Me.txtDatabase.TabIndex = 5
        '
        'cmdUpdate
        '
        Me.cmdUpdate.Appearance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdUpdate.Appearance.BackColor2 = System.Drawing.Color.Khaki
        Me.cmdUpdate.Appearance.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUpdate.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical
        Me.cmdUpdate.Appearance.Options.UseBackColor = True
        Me.cmdUpdate.Appearance.Options.UseFont = True
        Me.cmdUpdate.Location = New System.Drawing.Point(200, 178)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(150, 32)
        Me.cmdUpdate.TabIndex = 8
        Me.cmdUpdate.Text = "Connect and Activate"
        '
        'LabelControl5
        '
        Me.LabelControl5.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.25!)
        Me.LabelControl5.Appearance.Options.UseFont = True
        Me.LabelControl5.Location = New System.Drawing.Point(155, 149)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(36, 19)
        Me.LabelControl5.TabIndex = 629
        Me.LabelControl5.Text = "Filedir"
        '
        'txtFileDir
        '
        Me.txtFileDir.EditValue = "filedir"
        Me.txtFileDir.EnterMoveNextControl = True
        Me.txtFileDir.Location = New System.Drawing.Point(200, 146)
        Me.txtFileDir.Name = "txtFileDir"
        Me.txtFileDir.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.25!)
        Me.txtFileDir.Properties.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.txtFileDir.Properties.Appearance.Options.UseFont = True
        Me.txtFileDir.Properties.Appearance.Options.UseForeColor = True
        Me.txtFileDir.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.txtFileDir.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.txtFileDir.Size = New System.Drawing.Size(191, 26)
        Me.txtFileDir.TabIndex = 6
        '
        'txtPort
        '
        Me.txtPort.EditValue = "Port"
        Me.txtPort.EnterMoveNextControl = True
        Me.txtPort.Location = New System.Drawing.Point(438, 29)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Properties.Appearance.Font = New System.Drawing.Font("Segoe UI", 10.25!)
        Me.txtPort.Properties.Appearance.ForeColor = System.Drawing.Color.Gray
        Me.txtPort.Properties.Appearance.Options.UseFont = True
        Me.txtPort.Properties.Appearance.Options.UseForeColor = True
        Me.txtPort.Properties.Appearance.Options.UseTextOptions = True
        Me.txtPort.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.txtPort.Properties.AppearanceFocused.ForeColor = System.Drawing.Color.Black
        Me.txtPort.Properties.AppearanceFocused.Options.UseForeColor = True
        Me.txtPort.Size = New System.Drawing.Size(70, 26)
        Me.txtPort.TabIndex = 2
        '
        'frmConnectionSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(589, 233)
        Me.Controls.Add(Me.txtPort)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.txtFileDir)
        Me.Controls.Add(Me.cmdUpdate)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.txtDatabase)
        Me.Controls.Add(Me.txtServerhost)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.txtpassword)
        Me.Controls.Add(Me.txtusername)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmConnectionSetup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Connection Setup"
        CType(Me.txtpassword.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtusername.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtServerhost.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDatabase.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFileDir.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPort.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtpassword As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtusername As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtServerhost As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtDatabase As DevExpress.XtraEditors.TextEdit
    Friend WithEvents cmdUpdate As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtFileDir As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtPort As DevExpress.XtraEditors.TextEdit
End Class
