Public Class SplashScreen1
    Sub New
        InitializeComponent()
    End Sub

    Public Overrides Sub ProcessCommand(ByVal cmd As System.Enum, ByVal arg As Object)
        MyBase.ProcessCommand(cmd, arg)
    End Sub

    Public Enum SplashScreenCommand
        SomeCommandId
    End Enum

    Private Sub SplashScreen1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        labelControl1.Text = "Copyright © 2011-" & Now.Year
    End Sub
End Class
