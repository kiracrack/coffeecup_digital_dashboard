Module Sequence_Number
    Public Function getCouponSequence()
        Dim strng As Integer = 0 : Dim newNumber As String = "" : Dim NumberLen As Integer = 0
        com.CommandText = "select couponseriesno from tblgeneralsettings " : rst = com.ExecuteReader()
        While rst.Read
            NumberLen = rst("couponseriesno").ToString.Length
            strng = Val(rst("couponseriesno").ToString) + 1
        End While
        rst.Close()
        If NumberLen > strng.ToString.Length Then
            Dim a As Integer = NumberLen - strng.ToString.Length
            If a = 6 Then
                newNumber = "000000" & strng
            ElseIf a = 5 Then
                newNumber = "00000" & strng
            ElseIf a = 4 Then
                newNumber = "0000" & strng
            ElseIf a = 3 Then
                newNumber = "000" & strng
            ElseIf a = 2 Then
                newNumber = "00" & strng
            ElseIf a = 1 Then
                newNumber = "0" & strng
            Else
                newNumber = strng
            End If
        Else
            newNumber = strng
        End If
        com.CommandText = "update tblgeneralsettings set couponseriesno='" & newNumber & "'" : com.ExecuteNonQuery()
        Return newNumber
    End Function

    Public Function getManuMakerServiceSequence()
        Dim strng As Integer = 0 : Dim newNumber As String = "" : Dim NumberLen As Integer = 0
        com.CommandText = "select menumakerservicereferenceno from tblgeneralsettings " : rst = com.ExecuteReader()
        While rst.Read
            NumberLen = rst("menumakerservicereferenceno").ToString.Length
            strng = Val(rst("menumakerservicereferenceno").ToString) + 1
        End While
        rst.Close()
        If NumberLen > strng.ToString.Length Then
            Dim a As Integer = NumberLen - strng.ToString.Length
            If a = 6 Then
                newNumber = "000000" & strng
            ElseIf a = 5 Then
                newNumber = "00000" & strng
            ElseIf a = 4 Then
                newNumber = "0000" & strng
            ElseIf a = 3 Then
                newNumber = "000" & strng
            ElseIf a = 2 Then
                newNumber = "00" & strng
            ElseIf a = 1 Then
                newNumber = "0" & strng
            Else
                newNumber = strng
            End If
        Else
            newNumber = strng
        End If
        com.CommandText = "update tblgeneralsettings set menumakerservicereferenceno='" & newNumber & "'" : com.ExecuteNonQuery()
        Return newNumber
    End Function

    Public Function getManuMakerSequence()
        Dim strng As Integer = 0 : Dim newNumber As String = "" : Dim NumberLen As Integer = 0
        com.CommandText = "select menumakerreferenceno from tblgeneralsettings " : rst = com.ExecuteReader()
        While rst.Read
            NumberLen = rst("menumakerreferenceno").ToString.Length
            strng = Val(rst("menumakerreferenceno").ToString) + 1
        End While
        rst.Close()
        If NumberLen > strng.ToString.Length Then
            Dim a As Integer = NumberLen - strng.ToString.Length
            If a = 6 Then
                newNumber = "000000" & strng
            ElseIf a = 5 Then
                newNumber = "00000" & strng
            ElseIf a = 4 Then
                newNumber = "0000" & strng
            ElseIf a = 3 Then
                newNumber = "000" & strng
            ElseIf a = 2 Then
                newNumber = "00" & strng
            ElseIf a = 1 Then
                newNumber = "0" & strng
            Else
                newNumber = strng
            End If
        Else
            newNumber = strng
        End If
        com.CommandText = "update tblgeneralsettings set menumakerreferenceno='" & newNumber & "'" : com.ExecuteNonQuery()
        Return newNumber
    End Function
End Module
