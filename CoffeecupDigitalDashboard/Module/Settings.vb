Imports System.IO

Module Library
    Public OnscreenKeyboard As String = "C:\Program Files\Common Files\microsoft shared\ink\TabTip.exe"
    Public Sub loadIcons()
        Dim TargetFile As String
        TargetFile = Application.StartupPath + "\ico.ico"
        If File.Exists(TargetFile) = True Then
            ico = New Icon(TargetFile)
        End If
    End Sub
End Module
