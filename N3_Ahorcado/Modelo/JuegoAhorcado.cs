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
        private Palabra[] m_diccioario;
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
            m_diccioario = new Palabra[(int)JuegoAhoracadoConstantes.TotalPalabras];

            m_diccioario[0] = new Palabra("algoritmo");
            m_diccioario[1] = new Palabra("contenedora");
            m_diccioario[2] = new Palabra("avance");
            m_diccioario[3] = new Palabra("ciclo");
            m_diccioario[4] = new Palabra("indice");
            m_diccioario[5] = new Palabra("instrucciones");
            m_diccioario[6] = new Palabra("arreglo");
            m_diccioario[7] = new Palabra("vector");
            m_diccioario[8] = new Palabra("inicio");
            m_diccioario[9] = new Palabra("cuerpo");
            m_diccioario[10] = new Palabra("recorrido");
            m_diccioario[11] = new Palabra("patron");

            m_intentosDisponibles = (int)JuegoAhoracadoConstantes.MaximoIntentos;
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
            double pos = GenerarValor() * (int)JuegoAhoracadoConstantes.TotalPalabras;

            m_actual = (Palabra)m_diccioario[(int)pos];

            m_intentosDisponibles = (int)JuegoAhoracadoConstantes.MaximoIntentos;

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
        public Palabra ObtenerPalabra(int posicion)
        {
            return m_diccioario[posicion];
        }
        #endregion
    }
}
