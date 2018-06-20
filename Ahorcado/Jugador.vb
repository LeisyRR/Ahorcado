Public Class Jugador
    'La palabra, el tiempo, los puntos, 
    'adivinada: array del mismo tamaño de palabra con las letras en orden'

    'recibe la letra y verifica si existe
    'retorna true si acerto y false si fallo
    Public Function verificarLetra(letra As String) As Boolean
        'verifica si la letra existe en palabra
        'en cuales posiciones y cuantas veces
        'y las agrega en las mismas posiciones al array
        'retorna true si acerto
        'sino baja 1 punto
    End Function

    Public Function verificarPalabra(palabraAdivinada As String) As Boolean
        'verifica si la palabra es igual a la palabraadivinada
        'sino deja los puntos en 0
        'si es entonces copia palabra en adivinada
    End Function

    Public Sub subirTiempo(tiempo As Integer)
        'le aumenta el tiempo al jugador
    End Sub

    Public Function estaVivo() As Boolean
        'retorna true si los puntos son mas que cero y si adivinada es diferente a palabra
        'retorn false si puntos son 0 o adivinada es igual a palabra
    End Function
End Class
