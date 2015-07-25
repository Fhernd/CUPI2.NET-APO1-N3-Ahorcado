// ===++===
//
//	OrtizOL - xCSw
//
//  Proyecto: Cupi2.NET
//
// ===--===
/*============================================================
//
// Clase(s): Principal
//
// Propósito: Implementar y representar el formulario 
// (ventana) principal de la aplicación.
//
// Original: http://cupi2.uniandes.edu.co/sitio/index.php/cursos/apo1/nivel-3/ahorcado/visualizacion-de-codigo/interfazahorcado
//
============================================================*/

using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using N3_Ahorcado.Modelo;

namespace N3_Ahorcado.GUI
{
    /// <summary>
    /// Clase que representa el formulario principal de la aplicación.
    /// </summary>
    public partial class Principal : Form
    {
        #region Campos
        /// <summary>
        /// Juego del Ahorcado.
        /// </summary>
        private JuegoAhorcado m_juego;
        #endregion

        #region Controles
        /// <summary>
        /// Control visual de la figura del ahorcado.
        /// </summary>
        private ControlAhorcado m_ctlAhorcado;
        /// <summary>
        /// Control visual con las letras del juego.
        /// </summary>
        private ControlLetras m_ctlLetras;
        /// <summary>
        /// Control visual con los botones de interacción de la aplicación.
        /// </summary>
        private ControlOperaciones m_ctlOperaciones;
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene el estado actual del juego.
        /// </summary>
        public EstadoJuego Estado
        {
            get
            {
                return m_juego.Estado;
            }
        }
        /// <summary>
        /// Obtiene el número de intentos disponibles.
        /// </summary>
        public short IntentosDisponibles
        {
            get
            {
                return m_juego.IntentosDisponibles;
            }
        }
        /// <summary>
        /// Obtiene conjunto de letras jugadas.
        /// </summary>
        public ArrayList Letras
        {
            get
            {
                return m_juego.Ocurrencias;
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializa una nueva instancia del formulario principal de la aplicación.
        /// </summary>
        public Principal()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.ahorcado_icon;

            InicializarComponentesPersonalizados();

            m_juego = new JuegoAhorcado();
            m_juego.IniciarJuego();

            m_ctlAhorcado.Actualizar();
        }
        #endregion

        #region Métodos: 
        /// <summary>
        /// Inicializa los controles personalizados del formulario principal.
        /// </summary>
        private void InicializarComponentesPersonalizados()
        {
            m_ctlLetras = new ControlLetras(this) { Location = new Point(20, 70) };
            this.Controls.Add(m_ctlLetras);

            m_ctlAhorcado = new ControlAhorcado(this) { Location = new Point(310, 50) };
            this.Controls.Add(m_ctlAhorcado);

            m_ctlOperaciones = new ControlOperaciones(this) { Location = new Point(280, 310) };
            this.Controls.Add(m_ctlOperaciones);
        }
        /// <summary>
        /// Iniciar un nuevo juego del Ahorcado.
        /// </summary>
        public void IniciarJuego()
        {
            m_juego.IniciarJuego();
            m_ctlAhorcado.EtiquetarMensaje(String.Empty);
            m_ctlAhorcado.Actualizar();
        }
        /// <summary>
        /// Juega una letra.
        /// </summary>
        /// <param name="letra">Letra a jugar.</param>
        public void JugarLetra(char letra)
        {
            EstadoJuego estado = m_juego.Estado;

            if (estado == EstadoJuego.Jugando)
            {
                Letra letraJugada = new Letra(letra);
                bool letraUsada = m_juego.LetraUtilizada(letraJugada);

                if (letraUsada)
                {
                    m_ctlAhorcado.EtiquetarMensaje("Letra Ya Jugada");
                }
                else if (!(m_juego.JugarLetra(letraJugada)) && !letraUsada)
                {
                    m_ctlAhorcado.EtiquetarMensaje("Incorrecto");
                }
                else
                {
                    m_ctlAhorcado.EtiquetarMensaje(String.Empty);
                }

                m_ctlAhorcado.Actualizar();
            }
        }
        #endregion

        #region Métodos de extensión: 
        /// <summary>
        /// Punto de extensión número 1.
        /// </summary>
        public void PuntoExtension1()
        {
            MessageBox.Show(this, m_juego.PuntoExtension1(), "Punto de Extensión", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// Punto de extensión número 2.
        /// </summary>
        public void PuntoExtension2()
        {
            MessageBox.Show(this, m_juego.PuntoExtension2(), "Punto de Extensión", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion
    }
}
