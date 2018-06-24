Imports System
Imports System.IO
Imports System.Collections

Public Class Juego

    Private _tipoJuego As Boolean ' true si es jvj false si es jvm
    Private _turnoJ1 As Boolean     ' true si el jugador 1 esta en turno false si es el jugador 2 
    Private Jugador1 As Jugador
    Private Jugador2 As Jugador



    Public Property TipoJuego As Boolean
        Get
            Return _tipoJuego
        End Get
        Set(value As Boolean)

            _tipoJuego = value
        End Set
    End Property


    Public Property TurnoJ1 As Boolean
        Get
            Return _turnoJ1

        End Get
        Set(value As Boolean)
            _turnoJ1 = value

        End Set
    End Property

    'Recibe las categorias de cada jugador e inicia el juego
    Public Sub IniciarJuego(categoria1 As Integer, categoria2 As Integer)
        Jugador1 = New Jugador()
        Jugador2 = New Jugador()
        Dim word As String = ""
        Dim reader As StreamReader
        Dim NumRandom As Integer


        'verifica que categoria escogio el jugador 1 para leer archivo correcto
        If categoria1 = 1 Then
            reader = New StreamReader("\Categorias\Arte")
        ElseIf categoria1 = 2 Then
            reader = New StreamReader("\Categorias\Ciencia")
        ElseIf categoria1 = 3 Then
            reader = New StreamReader("\Categorias\Entretenimiento")
        ElseIf categoria1 = 4 Then
            reader = New StreamReader("\Categorias\Geografia")
        Else
            reader = New StreamReader("\Categorias\Historia")
        End If

        'escoge un numero random del 1 al 30 
        Randomize() : NumRandom = Int((30 - 1 + 1) * Rnd() + 1)

        For i As Integer = 0 To NumRandom ' mi numero random sera la linea donde esta la palabra que se usara
            word = reader.ReadLine
        Next
        Jugador1.Palabra = word

        'verifica si el tipo de juego es jvj o jvm para leer las categorias del jugador 2 si es necesario
        If TipoJuego = True Then

            If categoria2 = 1 Then
                reader = New StreamReader("\Categorias\Arte")
            ElseIf categoria2 = 2 Then
                reader = New StreamReader("\Categorias\Ciencia")
            ElseIf categoria2 = 3 Then
                reader = New StreamReader("\Categorias\Entretenimiento")
            ElseIf categoria2 = 4 Then
                reader = New StreamReader("\Categorias\Geografia")
            Else
                reader = New StreamReader("\Categorias\Historia")
            End If

            For i As Integer = 0 To NumRandom ' mi numero random sera la linea donde esta la palabra que se usara
                word = reader.ReadLine
            Next
            Jugador2.Palabra = word

        End If
        ReDim Jugador1.Adivinada(Jugador1.Palabra.Count)
        ReDim Jugador1.Adivinada(Jugador1.Palabra.Count)

        Jugador1.Puntos = 10
        Jugador1.Tiempo = 0
        Jugador2.Puntos = 10
        Jugador2.Tiempo = 0

    End Sub

    'Recibe el tiempo que duro el jugador en adivinar
    'No tiene retorno

    Public Sub FinalizarTurno(tiempo As Integer)

        If TurnoJ1 = True Then
            Jugador1.subirTiempo(tiempo)
        Else
            Jugador2.subirTiempo(tiempo)
        End If
        If TipoJuego = True Then
            If Jugador1.estaActivo() = False And Jugador2.estaActivo() = False Then
                VerificarGanador()

            End If
            If TurnoJ1 = True And Jugador2.estaActivo() = True Then
                TurnoJ1 = False
            ElseIf TurnoJ1 = False And Jugador1.estaActivo() = True Then

                TurnoJ1 = True
            End If
        Else
            If Jugador1.estaActivo() = True Then
                VerificarGanador()

            End If
        End If


        'Verifica el jugador en turno y llama a subirTiempo del jugador en turno
        'Si el tipo es 2 jugadores: 
        '   Verifica si ninguno esta vivo(metodo "estaVivo" en Jugador): llamar a verificarGanador
        '   Sino si el otro esta vivo: cambio el jugador en turno
        '   Sino sigo jugando (no pasa nada en lógica)
        'Si el tipo es de 1 jugador:
        '   Verifica si el jugador estaActivo():
        '       Sigo jugando (no pasa nada en lógica)
        '   llama a verificarGanador()
    End Sub

    Public Sub AdivinarLetra(letra As String)

        If TurnoJ1 = True Then
            Jugador1.verificarLetra(letra)
        Else
            Jugador2.verificarLetra(letra)
        End If

        'Verifica el jugador en turno y llama a verificar letra del jugador en turno
    End Sub

    Public Sub AdivinarPalabra(palabra As String)

        If TurnoJ1 = True Then
            Jugador1.verificarPalabra(palabra)
        Else
            Jugador2.verificarPalabra(palabra)
        End If

        'Verifica el jugador en turno y llama a verificar palabra del jugador en turno

    End Sub

    'Retorno el tiempo del ganador ' 
    Public Function VerificarGanador() As Boolean
        Dim ganoJ1 As Boolean
        ganoJ1 = False

        If TipoJuego = True Then
            If Jugador1.Puntos > 0 And Jugador2.Puntos > 0 Then
                If Jugador1.Tiempo > Jugador2.Tiempo Then
                    ganoJ1 = True
                Else
                    ganoJ1 = False
                End If
            ElseIf Jugador1.Puntos > 0 And Jugador2.Puntos = 0 Then
                ganoJ1 = True
            ElseIf Jugador2.Puntos > 0 And Jugador1.Puntos = 0 Then

                ganoJ1 = False
            Else
                If Jugador1.Tiempo > Jugador2.Tiempo Then
                    ganoJ1 = True
                Else
                    ganoJ1 = False
                End If

            End If
        Else
            If Jugador1.Puntos > 0 Then
                ganoJ1 = True
            End If

        End If


        'Si el tipo es 2 jugadores:
        'Verifica si los dos ganaron: 
        '       Verifica quien duró menos
        'Verifica si solo 1 ganó:
        '       Ese es el ganador
        'Verifica si los dos perdieron:
        '       Verifica quien duró menos.

        'Si el tipo es 1 jugador:
        '       Verifica si jugador 1 gano o perdio'
    End Function

End Class
