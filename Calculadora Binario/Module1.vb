Module Module1


    Private ComentariosActivados As Boolean = False
    Private reply As String

    Sub Main()
        Console.Title = "Calculadora binario/decimal de Jesús Garcés"

        Console.WriteLine("¿Qué desea convertir? Binario | Decimal. O bien, escriba Ayuda.")
        reply = Console.ReadLine
        Select Case reply
            Case Is = "Binario"
                Console.ForegroundColor = ConsoleColor.Cyan
                Console.WriteLine("Introduzca un número en binario para convertirlo en decimal.")
                Console.ForegroundColor = ConsoleColor.Green
                Console.WriteLine("· No necesita introducir ceros a la izquierda." & vbNewLine & "· Espacios no son admitidos." & vbNewLine & "· Hay un límite técnico de 31 cifras." & vbNewLine & "· Escriba Salir para terminar.")
                Console.ForegroundColor = ConsoleColor.Gray
                BinarioADecimal()
            Case Is = "Decimal"
                Console.ForegroundColor = ConsoleColor.Cyan
                Console.WriteLine("Introduzca un número en decimal.")
                Console.ForegroundColor = ConsoleColor.Green
                Console.WriteLine("· No puede introducir letras ni signos de puntuación." & vbNewLine & "· Espacios no son admitidos." & vbNewLine & "· Hay un límite técnico de 18 cifras." & vbNewLine & "· Escriba Salir para terminar.")
                Console.ForegroundColor = ConsoleColor.Gray
                DecimalABinario()
            Case Is = "Salir"
                Environment.Exit(0)
            

        End Select

        Main()

    End Sub

    Sub Comandos()

        Select Case reply
            Case Is = "Activar comentarios"
                ComentariosActivados = True
                Console.WriteLine("Comentarios activados")
                reply = ""
                Return
            Case Is = "Desactivar comentarios"
                ComentariosActivados = False
                Console.WriteLine("Comentarios desactivados")
                reply = ""
                Return
            Case Is = "Ayuda"
                Console.ForegroundColor = ConsoleColor.Cyan
                Console.WriteLine("Comandos")
                Console.ForegroundColor = ConsoleColor.Green
                Console.WriteLine("Binario: Convertir un número desde binario a decimal." & vbNewLine & "Decimal: Convertir un número desde decimal a binario." & vbNewLine & "Activar comentarios: Cada paso realizado durante las conversiones es explicado." & vbNewLine & "Desactivar comentarios: Desactiva los comentarios." & vbNewLine & "Salir: Volver al inicio del programa. Si ya está en el inicio, se cierra.")
                Console.ForegroundColor = ConsoleColor.Gray
                reply = ""
                Return
        End Select


    End Sub

    Sub BinarioADecimal()
        reply = Console.ReadLine()
        Comandos()
        If reply.Equals("") Then
            BinarioADecimal()
        ElseIf reply.Equals("Salir") Then
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
        
        ' Se han superado todas las comprobaciones. Comienza la conversión
        Dim bits = reply.Length, digitcounter = bits, digitinteger As Integer = 0
        Dim resultado As Long = 0
        ' Motor de conversión manual
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
        Dim reply As String = Console.ReadLine
        Comandos()
        If reply.Equals("") Then
            DecimalABinario()
        ElseIf reply.Equals("Salir") Then
            Main()
        End If

        ' Realizar comprobaciones por las que podría fallar para evitar usar try
        Dim sonnumeros As Boolean = False
        ' Primero comprobamos si la respuesta es demasiado larga
        If reply.LongCount < 19 Then
            For Each digit As Char In reply
                ' Comprobar si todos los caracteres de la respuesta son números
                sonnumeros = Char.IsDigit(digit)
                ' Comprobar que ningún número sea mayor que 1
            Next
            ' Comprobamos si se cumple alguna de las condiciones no permitidas
            If sonnumeros.Equals(False) Then
                Console.WriteLine("Sólo se admiten números")
                DecimalABinario()
            End If
        Else
            Console.WriteLine("Este programa tiene un límite técnico de 18 cifras por número.")
            DecimalABinario()
        End If
        ' Se han superado todas las comprobaciones

        ' Motor de conversión manual
        Dim dividendo As Integer = reply
        Dim cociente As Integer = 2
        Dim resto As Integer

        Dim resultado As String = ""

        Do Until cociente < 2
            ' El resultado de la división es la respuesta entre (con redondeo a la baja) entre 2.
            cociente = dividendo \ 2
            ' Anotamos el resto
            resto = dividendo Mod 2
            ' Anotamos a la izquierda en el resultado el resto de la división, que será 0 o 1.
            resultado = resto & resultado
            ' Si el cociente es menor que 2, es que hemos llegado al final de la división, el cociente es el primer dígito del resultado en binario.
            Select Case cociente
                Case Is < 2
                    ' El cociente es menor que 2, así que lo anotamos. Hemos terminado de calcular
                    resultado = cociente & resultado
            End Select
            If ComentariosActivados = True Then
                Console.WriteLine("Se ha dividido " & dividendo & " entre 2 con un resultado de " & cociente & " y un resto de " & resto)
            End If
            ' No hemos terminado la división. Hacemos que el nuevo cociente sea el resultado de la división y vuelta a empezar.
            dividendo = cociente
        Loop
        ' Notificamos el resultado y vuelta a empezar.
        Console.WriteLine("Este número en binario es " & resultado)
        DecimalABinario()

    End Sub

End Module
