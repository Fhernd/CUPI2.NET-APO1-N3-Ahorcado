using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N3_Ahorcado.Modelo
{
    public class JuegoAhorcado
    {
        #region Campos
        private Palabra[] m_diccionario;
        private Palabra m_actual;
        private ArrayList m_jugadas;
        private Int16 m_intentosDisponibles;
        private EstadoJuego m_estado;
        #endregion

        #region Propiedades
        public EstadoJuego Estado
        {
            get
            {
                return m_estado;
            }
        }

        public Int16 IntentosDisponibles
        {
            get
            {
                return m_intentosDisponibles;
            }
        }

        public ArrayList Jugadas
        {
            get
            {
                return m_jugadas;
            }
        }

        public ArrayList Ocurrencias
        {
            get
            {
                return m_actual.GenerarOcurrencias(m_jugadas);
            }
        }

        public Palabra PalabraActual
        {
            get
            {
                return m_actual;
            }
        }
        #endregion

        #region Constructores
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
        private double GenerarValor()
        {
            return new Random().NextDouble();
        }

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
        public Palabra ObtenerPalabra(int posicion)
        {
            return m_diccionario[posicion];
        }
        #endregion

        #region Puntos de extensión:
        public String PuntoExtension1()
        {
            return "Respuesta 1";
        }
        public String PuntoExtension2()
        {
            return "Respuesta 2";
        }
        #endregion
    }
}
