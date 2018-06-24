Public Class Jugador
    Dim _palabra As String
    Dim _tiempo As Integer
    Dim _puntos As Integer
    Dim _adivinada() As String

    Public Property Palabra As String
        Get
            Return _palabra
        End Get
        Set(value As String)
            _palabra = value
        End Set
    End Property

    Public Property Tiempo As Integer
        Get
            Return _tiempo
        End Get
        Set(value As Integer)
            _tiempo = value

        End Set
    End Property

    Public Property Puntos As Integer
        Get
            Return _puntos
        End Get
        Set(value As Integer)
            _puntos = value
        End Set
    End Property

    Public Property Adivinada As String()
        Get
            Return _adivinada
        End Get
        Set(value As String())
            _adivinada = value
        End Set
    End Property

    '*******************metodos*************************************

    'recibe la letra y verifica si existe
    'retorna true si acerto y false si fallo
    Public Function verificarLetra(letra As String) As Boolean
        Dim acerto As Boolean
        acerto = False

        For i As Integer = 0 To Palabra.Length

            If letra = Palabra(i) Then
                Adivinada(i) = letra
                acerto = True

            End If

        Next
        If acerto = False Then
            Puntos -= 1

        End If
        Return acerto

    End Function

    'verifica si la palabra es correcta y mata al judador de lo contrario 
    Public Function verificarPalabra(palabraAdivinada As String) As Boolean
        Dim acerto As Boolean
        acerto = False

        If palabraAdivinada = Palabra Then
            acerto = True

            For i As Integer = 0 To Palabra.Length

                Adivinada(i) = Palabra(i)

            Next
            If acerto = False Then
                Puntos = 0
            End If

        End If
        Return acerto
    End Function
    'acumula el tiempo del jugador
    Public Sub subirTiempo(tiempo As Integer)

        _tiempo += tiempo
    End Sub

    'verifica si el jugador continua activo
    Public Function estaActivo() As Boolean
        Dim vivo As Boolean
        vivo = False
        Dim diferentes As Boolean
        diferentes = False

        For i As Integer = 0 To Palabra.Length - 1

            If Adivinada(i) <> Palabra(i) Then
                diferentes = True
            End If
        Next
        If Puntos > 0 And diferentes = True Then
            vivo = True
        Else
            vivo = False

        End If
        Return vivo

    End Function
End Class
