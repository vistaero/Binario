Module Module1

    Sub Main()
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
        Console.WriteLine(cifra & " es de " & bits & " bits." & vbNewLine & "Pronto podré convertir a decimal.")
        Environment.Exit(0)

        'Comienza la conversión
        Dim digitcounter As Integer = 0
        Dim resultado As String = ""
        For Each digit In cifra.ToString
            digitcounter += 1
            Select Case digitcounter
                Case Is = 1
                    resultado += 1
                Case Is = 2
                    resultado += 
            End Select
        Next

        Main()

    End Sub

End Module
