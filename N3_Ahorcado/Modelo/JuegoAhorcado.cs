// ===++===
//
//	OrtizOL - xCSw
//
//  Proyecto: Cupi2.NET
//
// ===--===
/*============================================================
//
// Clase(s): JuegoAhorcado.
//
// Propósito: Implementar y representar la entidad 
// JuegoAhorcado del mundo del problema.
//
// Original: http://cupi2.uniandes.edu.co/sitio/index.php/cursos/apo1/nivel-3/ahorcado/visualizacion-de-codigo/juegoahorcado
//
============================================================*/

using System;
using System.Collections;

namespace N3_Ahorcado.Modelo
{
    /// <summary>
    /// Clase que representa la entidad JuegoAhorcado.
    /// </summary>
    public class JuegoAhorcado
    {
        #region Campos
        /// <summary>
        /// Diccionario de palabras.
        /// </summary>
        private Palabra[] m_diccionario;
        /// <summary>
        /// Palabra actual en juego.
        /// </summary>
        private Palabra m_actual;
        /// <summary>
        /// Letras jugadas.
        /// </summary>
        private ArrayList m_jugadas;
        /// <summary>
        /// Intentos disponibles en el juego.
        /// </summary>
        private Int16 m_intentosDisponibles;
        /// <summary>
        /// Estado del juego.
        /// </summary>
        private EstadoJuego m_estado;
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene el estado del juego.
        /// </summary>
        public EstadoJuego Estado
        {
            get
            {
                return m_estado;
            }
        }
        /// <summary>
        /// Obtiene los intentos disponibles en el juego.
        /// </summary>
        public Int16 IntentosDisponibles
        {
            get
            {
                return m_intentosDisponibles;
            }
        }
        /// <summary>
        /// Obtiene las letras jugadas hasta el momento.
        /// </summary>
        public ArrayList Jugadas
        {
            get
            {
                return m_jugadas;
            }
        }
        /// <summary>
        /// Obtiene las ocurrencias de letras.
        /// </summary>
        public ArrayList Ocurrencias
        {
            get
            {
                return m_actual.GenerarOcurrencias(m_jugadas);
            }
        }
        /// <summary>
        /// Obtiene la palabra actual en juego.
        /// </summary>
        public Palabra PalabraActual
        {
            get
            {
                return m_actual;
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializa una instancia de la clase JuegoAhorcado.
        /// </summary>
        public JuegoAhorcado()
        {
            m_diccionario = new Palabra[(int)JuegoAhorcadoConstantes.TotalPalabras];

            m_diccionario[0] = new Palabra("algoritmo");
            m_diccionario[1] = new Palabra("contenedora");
            m_diccionario[2] = new Palabra("avance");
            m_diccionario[3] = new Palabra("ciclo");
            m_diccionario[4] = new Palabra("indice");
            m_diccionario[5] = new Palabra("instrucciones");
            m_diccionario[6] = new Palabra("arreglo");
            m_diccionario[7] = new Palabra("vector");
            m_diccionario[8] = new Palabra("inicio");
            m_diccionario[9] = new Palabra("cuerpo");
            m_diccionario[10] = new Palabra("recorrido");
            m_diccionario[11] = new Palabra("patron");

            m_intentosDisponibles = (int)JuegoAhorcadoConstantes.MaximoIntentos;
            m_estado = EstadoJuego.NoIniciado;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Genera un valor aleatorio para la selección de la palabra.
        /// </summary>
        /// <returns></returns>
        private double GenerarValor()
        {
            return new Random().NextDouble();
        }
        /// <summary>
        /// Inicia un nuevo juego.
        /// </summary>
        public void IniciarJuego()
        {
            double pos = GenerarValor() * (int)JuegoAhorcadoConstantes.TotalPalabras;

            m_actual = (Palabra)m_diccionario[(int)pos];

            m_intentosDisponibles = (int)JuegoAhorcadoConstantes.MaximoIntentos;

            // Vector de letras jugadas: 
            m_jugadas = new ArrayList();

            // Actualizaci[on del estado del juego: 
            m_estado = EstadoJuego.Jugando;
        }
        /// <summary>
        /// Juega una letra específica.
        /// </summary>
        /// <param name="letra">Letra a jugar.</param>
        /// <returns><em>true</em> si la letra pertenece a la palbra; <em>false</em> en caso contrario.</returns>
        public bool JugarLetra(Letra letra)
        {
            if (m_estado != EstadoJuego.Jugando)
            {
                return false;
            }

            m_jugadas.Add(letra);

            bool pertenece = m_actual.EstaLetra(letra);


            if (!pertenece)
            {
                --m_intentosDisponibles;

                if(m_intentosDisponibles == 0)
                {
                    m_estado = EstadoJuego.Ahorcado;
                }
            }
            else
            {
                if (m_actual.EstaCompleta(m_jugadas))
                {
                    m_estado = EstadoJuego.Ganador;
                }
            }

            return pertenece;
        }
        /// <summary>
        /// Determina si la letra fue utilizada en una partida del ahorcado.
        /// </summary>
        /// <param name="letra">Letra a determinar si ha sido jugada.</param>
        /// <returns><i>true</i> si la letra fue jugada; <i>false</i> en caso contrario.</returns>
        public bool LetraUtilizada(Letra letra)
        {
            bool utilizada = false;
            int contador = 0;

            while(contador < m_jugadas.Count && !utilizada)
            {
                Letra l = (Letra)m_jugadas[contador];
                
                if (l.EsIgual(letra))
                {
                    utilizada = true;
                }

                ++contador;
            }

            return utilizada;
        }
        /// <summary>
        /// Obtiene una palabra del diccionario.
        /// </summary>
        /// <param name="posicion">Posición de la palabra en el diccionario.</param>
        /// <returns>Palabra del diccionario.</returns>
        public Palabra ObtenerPalabra(int posicion)
        {
            return m_diccionario[posicion];
        }
        #endregion

        #region Puntos de extensión:
        /// <summary>
        /// Punto de extensión no. 1.
        /// </summary>
        /// <returns>Cadena de respuesta del punto de extensión.</returns>
        public String PuntoExtension1()
        {
            return "Respuesta 1";
        }
        /// <summary>
        /// Punto de extensión no. 2.
        /// </summary>
        /// <returns>Cadena de respuesta del punto de extensión.</returns>
        public String PuntoExtension2()
        {
            return "Respuesta 2";
        }
        #endregion
    }
}
