Module Module1

    Sub Main()
        Console.Title = "Calculadora binario/decimal de Jesús Garcés"

        Console.WriteLine("¿Qué desea convertir? Binario | Decimal")
        Dim reply = Console.ReadLine
        Select Case reply
            Case Is = "Binario"
                Console.ForegroundColor = ConsoleColor.Cyan
                Console.WriteLine("Introduzca un número en binario para convertirlo en decimal.")
                Console.ForegroundColor = ConsoleColor.Green
                Console.WriteLine("· No necesita introducir ceros a la izquierda." & vbNewLine & "· Espacios no son admitidos." & vbNewLine & "· Hay un límite técnico de 31 cifras." & vbNewLine & "· Escriba Salir para terminar.")
                Console.ForegroundColor = ConsoleColor.Gray
                BinarioADecimal()
            Case Is = "Decimal"
                DecimalABinario()
            Case Is = "Salir"
                Environment.Exit(0)

        End Select

    End Sub

    Sub BinarioADecimal()
        Dim reply As String
        Dim bits As Integer

        reply = Console.ReadLine()

        If reply.Equals("Salir") Then
            Main()

        End If

        ' Realizar comprobaciones por las que podría fallar para evitar usar try
        Dim sonnumeros As Boolean = False
        Dim numerosmayoresqueuno As Boolean = False
        ' Primero comprobamos si la respuesta es demasiado larga
        If reply.LongCount < 31 Then
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
            Console.WriteLine("Este programa tiene un límite técnico de 31 cifras por número.")
            BinarioADecimal()
        End If

        ' Se han superado todas las comprobaciones

        bits = reply.Length


        'Comienza la conversión
        Dim digitcounter As Integer = bits
        Dim resultado As Long = 0
        Dim digitinteger As Integer = 0

        ' Mi fascinante motor de conversión que me llevó toda la santa tarde.
        ' Y yo suspendía matemáticas...
        ' Mi ego va a estar por las nubes durante lustros por "inventar" esta ecuación.
        ' Sin buscar en Google ni preguntar a nadie, ¡¿quién es el hombre?!

        For Each digit In reply

            digitinteger = digit.ToString
            Dim valor As Integer = 0
            valor += 2 ^ (digitcounter - 1)
            resultado += digitinteger * valor
            digitcounter -= 1

        Next

        Console.WriteLine(reply & " en decimal es: " & resultado & ".")
        BinarioADecimal()

    End Sub

    Sub DecimalABinario()
        Console.WriteLine("Esta función no está aún disponible")
        'Main()

        Dim reply As String = Console.ReadLine
        Dim valor As Integer = 1
        Dim contador As Integer
        Dim resultado As Integer
        Do Until reply.Equals(0)
            valor *= 2
            If valor < reply Then
                resultado = reply - valor
                Console.WriteLine(resultado)
            End If

        Loop


    End Sub

End Module
