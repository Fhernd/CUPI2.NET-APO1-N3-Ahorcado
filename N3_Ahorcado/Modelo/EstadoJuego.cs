// ===++===
//
//	OrtizOL - xCSw
//
//  Proyecto: Cupi2.NET
//
// ===--===
/*============================================================
//
// Enumeración(s): EstadoJuego.
//
// Propósito: Implementar y representar la enumeración 
// EstadoJuego del dominio.
//
// Original: N/D.
//
============================================================*/

namespace N3_Ahorcado.Modelo
{
    /// <summary>
    /// Especifica el estado del juego.
    /// </summary>
    public enum EstadoJuego
    {
        /// <summary>
        /// El jugador ha perdido.
        /// </summary>
        Ahorcado = 2, 
        /// <summary>
        /// El jugador ha ganado.
        /// </summary>
        Ganador = 1, 
        /// <summary>
        /// El juego está ejecución.
        /// </summary>
        Jugando = 0, 
        /// <summary>
        /// El juego no se ha iniciado.
        /// </summary>
        NoIniciado = -1 
    }
}