Module Module1

    Sub Main()
        Console.Title = "Calculadora binario de Jesús Garcés"
        Console.WriteLine("Introduzca un número en binario para convertirlo en decimal." & vbNewLine & "No necesita introducir ceros a la izquierda." & vbNewLine & "Espacios no son admitidos." & vbNewLine & "Hay un límite técnico de 19 cifras." & vbNewLine)
        BinarioADecimal()

    End Sub

    Sub BinarioADecimal()
        Dim reply As String = ""
        Dim bits As Integer = 0
        Dim cifra As Long = 0
        reply = Console.ReadLine()

        ' Realizar comprobaciones por las que podría fallar para evitar usar try
        Dim sonnumeros As Boolean = False
        Dim numerosmayoresqueuno As Boolean = False
        ' Primero comprobamos si la respuesta es demasiado larga
        If reply.LongCount < 20 Then
            For Each digit As Char In reply
                ' Comprobar si todos los caracteres de la respuesta son números
                sonnumeros = Char.IsDigit(digit)
                ' Comprobar que ningún número sea mayor que 1
                If sonnumeros = True Then
                    If digit.ToString > 1 Then
                        numerosmayoresqueuno = True
                    End If
                End If
            Next
            ' Comprobamos si se cumple alguna de las condiciones no permitidas
            If sonnumeros.Equals(False) OrElse numerosmayoresqueuno = True Then
                Console.WriteLine("Un número binario sólo puede tener 0 y/o 1.")
                BinarioADecimal()
            End If
        Else
            Console.WriteLine("Este programa tiene un límite técnico de 19 cifras por número.")
            BinarioADecimal()
        End If
        
        ' Se han superado todas las comprobaciones

        bits = reply.Length
        Select Case bits
            Case Is > 1
                Console.WriteLine(reply & " es de " & bits & " bits.")
            Case Is < 2
                Console.WriteLine(reply & " es de " & bits & " bit.")
        End Select

        'Comienza la conversión
        Dim digitcounter As Integer = bits
        Dim resultado As Long = 0
        Dim digitinteger As Integer = 0

        For Each digit In reply

            ' Mi fascinante motor de conversión que me llevó toda la santa tarde.
            ' Y yo suspendía matemáticas...
            ' Mi ego va a estar por las nubes durante lustros por "inventar" esta ecuación.
            ' Sin buscar en Google ni preguntar a nadie, ¡¿quién es el hombre?!

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
