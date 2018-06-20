Public Class Juego
    'Atributos:
    'Tipo de juego, 
    'Quien esta en turno, 
    'Dos jugadores(si es de 1 jugador, el 2Do por defecto)

    'Recibe las categorias de cada jugador e inicia el juego
    Public Sub IniciarJuego(categoria1 As Integer, categoria2 As Integer)
        'Busca una palabra de cada categoria
        'Inicializa al jugador con su respectiva palabra, tiempo 0 y puntos 10
        'Pone el turno al jugador 1
        'Pone ambos en vivo
    End Sub

    'Recibe el tiempo que duro el jugador en adivinar
    'No tiene retorno
    Public Sub FinalizarTurno(tiempo As Integer)
        'Verificar el jugador en turno y llama a subirTiempo del jugador en turno
        'Si el tipo es 2 jugadores: 
        '   Verificar si ninguno esta vivo(metodo "estaVivo" en Jugador): llamar a verificarGanador
        '   Sino si el otro esta vivo: cambio el jugador en turno
        '   Sino sigo jugando (no pasa nada en lógica)
        'Si el tipo es de 1 jugador:
        '   Verificar si el jugador estavivo():
        '       Sigo jugando (no pasa nada en lógica)
        '   llamar a verificarGanador()
    End Sub

    Public Sub AdivinarLetra(letra As String)
        'Verifica el jugador en turno y llama a verificar letra del jugador en turno
    End Sub

    Public Sub AdivinarPalabra(palabra As String)
        'Verifica el jugador en turno y llama a verificar palabra del jugador en turno

    End Sub

    'Retorno el tiempo del ganador ' 
    Public Function VerificarGanador() As Integer
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
