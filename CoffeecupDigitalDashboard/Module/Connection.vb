Imports MySql.Data.MySqlClient ' this is to import MySQL.NET
Imports System.Data
Imports System.Management
Imports Microsoft.VisualBasic
Imports System.Net.Mail
Imports System.Text
Imports System.IO
Imports DevExpress.XtraEditors
Imports Microsoft.Win32
Imports System.Security.Cryptography
Imports System.Security.Principal

Module Connection
    Public provider As Globalization.CultureInfo = Globalization.CultureInfo.InvariantCulture
    Public li As String = Environment.NewLine
    Public Em As DataGridView


    Public GlobalApplicationName As String = "Coffeecup Client"
    Public formclose As Boolean
    Public conn As New MySqlConnection
    Public hda As MySqlDataAdapter
    Public da As MySqlDataAdapter
    Public msda As MySqlDataAdapter
    Public msdastock As MySqlDataAdapter
    Public msda2 As MySqlDataAdapter
    Public coupon_adapter As MySqlDataAdapter

    Public da_manumaker As MySqlDataAdapter
    Public st_menumaker As New DataSet

    Public hst As New DataSet
    Public st As New DataSet
    Public dst As New DataSet
    Public dststock As New DataSet
    Public dst2 As New DataSet
    Public dst3 As New DataSet
    Public coupon_dst As New DataSet

    Public com As New MySqlCommand
    Public rst As MySqlDataReader

    Public GlobalApplicationPath As String = Application.StartupPath.ToString
    Public file_Attachment As String = Application.StartupPath.ToString & "\Resources\Attachment\"
    Public file_conn As String = Application.StartupPath.ToString & "\" & My.Application.Info.AssemblyName & ".conn"
    Public file_PrinterSettings As String = Application.StartupPath.ToString & "\" & My.Application.Info.AssemblyName & ".printer"
    Public file_QueuePrinterSettings As String = Application.StartupPath.ToString & "\" & My.Application.Info.AssemblyName & ".queue.printer"
    Public file_PoleDisplaySettings As String = Application.StartupPath.ToString & "\" & My.Application.Info.AssemblyName & ".pole.display"
 
    Public cb As MySqlCommandBuilder

    ' LOCALHOST
    Public sqlserver As String
    Public sqlport As String
    Public sqluser As String
    Public sqlpass As String
    Public sqldatabase As String
    Public sqlfiledir As String

    Public connclient As New MySqlConnection 'for MySQLDatabase Connection
    Public msdaclient As MySqlDataAdapter 'is use to update the dataset and datasource
    Public dstclient As New DataSet 'miniature of your table - cache table to client
    Public comclient As New MySqlCommand
    Public rstclient As MySqlDataReader
    Public ConnectedServer As Boolean = False

    Public clientserver As String
    Public clientport As String
    Public clientuser As String
    Public clientpass As String
    Public clientdatabase As String
    Public globallogin As Boolean

    Public Function OpenMysqlConnection() As Boolean
        Dim strSetup As String = ""
        Dim sr As StreamReader = File.OpenText(file_conn)
        Dim br As String = sr.ReadLine() : sr.Close()
        strSetup = DecryptTripleDES(br) : Dim cnt As Integer = 0
        For Each word In strSetup.Split(New Char() {","c})
            If cnt = 0 Then
                sqlserver = word
            ElseIf cnt = 1 Then
                sqlport = word
            ElseIf cnt = 2 Then
                sqluser = word
            ElseIf cnt = 3 Then
                sqlpass = word
            ElseIf cnt = 4 Then
                sqldatabase = word
            ElseIf cnt = 5 Then
                sqlfiledir = word

            End If
            cnt = cnt + 1
        Next
        Try
            conn.Close()
            conn = New MySql.Data.MySqlClient.MySqlConnection
            conn.ConnectionString = "server=" & sqlserver & "; Port=" & sqlport & "; user id=" & sqluser & "; password=" & sqlpass & "; database=" & sqldatabase & "; Connection Timeout=6000000 ; Allow Zero Datetime=True"
            conn.Open()
            com.Connection = conn
            com.CommandTimeout = 6000000
        Catch errMYSQL As MySqlException
            globallogin = False
            Return False
        End Try
        Return True
    End Function

    Public Function OpenClientServer() As Boolean
        Try
            connclient = New MySql.Data.MySqlClient.MySqlConnection
            connclient.ConnectionString = "server=" & clientserver & "; Port=" & clientport & "; user id=" & clientuser & "; password=" & clientpass & "; database=" & clientdatabase & "; Connection Timeout=10; allow user variables=true"
            connclient.Open()
            comclient.Connection = connclient
            comclient.CommandTimeout = 0
            OpenClientServer = True

        Catch errMYSQL As MySqlException
            XtraMessageBox.Show("Form: Connection Server" & vbCrLf _
                             & "Message:" & errMYSQL.Message & vbCrLf, _
                             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            OpenClientServer = False
            Return False
        Catch errMS As Exception
            XtraMessageBox.Show("Form: Connection Server" & vbCrLf _
                             & "Message:" & errMS.Message & vbCrLf, _
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            OpenClientServer = False
            Return False
        End Try
    End Function
End Module
