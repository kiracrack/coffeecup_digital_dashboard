Imports System.Drawing.Printing

Public Class POSDirectPrinter
    Friend TextToBePrinted As String
    Public Sub prt(ByVal text As String, ByVal printername As String)
        TextToBePrinted = text
        Dim prn As New Drawing.Printing.PrintDocument
        prn.PrintController = New StandardPrintController

        Using (prn)
            prn.PrinterSettings.PrinterName = printername
            AddHandler prn.PrintPage, AddressOf Me.PrintPageHandler
            prn.Print()
            RemoveHandler prn.PrintPage, AddressOf Me.PrintPageHandler
        End Using
    End Sub
    Private Sub PrintPageHandler(ByVal sender As Object, ByVal args As Drawing.Printing.PrintPageEventArgs)
        Dim myFont As New Font(globalPosFontName, globalPosFontSize)
        args.Graphics.DrawString(TextToBePrinted, New Font(myFont, FontStyle.Regular), Brushes.Black, 2, globalPosCornerLength)
    End Sub

End Class
