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
        Ahorcado = 2, 
        Ganador = 1, 
        Jugando = 0, 
        NoIniciado = -1 
    }
}