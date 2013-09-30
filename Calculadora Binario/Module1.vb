Module Module1

    Sub Main()
        BinarioADecimal()

    End Sub

    Sub BinarioADecimal()
        Dim reply As String = ""
        Dim bits As Integer = 0
        Dim cifra As Integer = 0
        Dim salir As Boolean = False
        reply = Console.ReadLine()
        Try
            cifra = reply
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            Main()

        End Try

        For Each digit In cifra.ToString
            If digit.ToString > 1 Then
                Console.WriteLine("No es un número binario")
                Main()

            End If
        Next

        bits = reply.Length
        Select Case bits
            Case Is > 1
                Console.WriteLine(cifra & " es de " & bits & " bits.")
            Case Is < 2
                Console.WriteLine(cifra & " es de " & bits & " bit.")
        End Select

        'Comienza la conversión
        Dim digitcounter As Integer = bits
        Dim resultado As Integer = 0
        Dim digitinteger As Integer = 0

        For Each digit In cifra.ToString

            digitinteger = digit.ToString
            Dim valor As Integer = 0
            valor += 2 ^ (digitcounter - 1)
            resultado += digitinteger * valor
            digitcounter -= 1

        Next

        Console.WriteLine("Este número en decimal es: " & resultado & ".")
        BinarioADecimal()

    End Sub

End Module
