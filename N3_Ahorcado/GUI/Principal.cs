using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using N3_Ahorcado.Modelo;

namespace N3_Ahorcado.GUI
{
    public partial class Principal : Form
    {
        #region Campos
        private JuegoAhorcado m_juego;
        #endregion

        #region Controles
        private ControlAhorcado m_ctlAhorcado;
        private ControlLetras m_ctlLetras;
        private ControlOperaciones m_ctlOperaciones;
        #endregion

        #region Propiedades
        public EstadoJuego Estado
        {
            get
            {
                return m_juego.Estado;
            }
        }
        public short IntentosDisponibles
        {
            get
            {
                return m_juego.IntentosDisponibles;
            }
        }
        public ArrayList Letras
        {
            get
            {
                return m_juego.Ocurrencias;
            }
        }
        #endregion

        #region Constructores
        public Principal()
        {
            InitializeComponent();

            InicializarComponentesPersonalizados();

            m_juego = new JuegoAhorcado();
            m_juego.IniciarJuego();

            m_ctlAhorcado.Actualizar();
        }
        #endregion

        #region Métodos: 
        private void InicializarComponentesPersonalizados()
        {
            m_ctlLetras = new ControlLetras(this) { Location = new Point(20, 70) };
            this.Controls.Add(m_ctlLetras);

            m_ctlAhorcado = new ControlAhorcado(this) { Location = new Point(310, 50) };
            this.Controls.Add(m_ctlAhorcado);

            m_ctlOperaciones = new ControlOperaciones(this) { Location = new Point(280, 310) };
            this.Controls.Add(m_ctlOperaciones);
        }
        public void IniciarJuego()
        {
            m_juego.IniciarJuego();
            m_ctlAhorcado.EtiquetarMensaje(String.Empty);
            m_ctlAhorcado.Actualizar();
        }
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
        public void PuntoExtension1()
        {
            MessageBox.Show(this, m_juego.PuntoExtension1(), "Punto de Extensión", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public void PuntoExtension2()
        {
            MessageBox.Show(this, m_juego.PuntoExtension2(), "Punto de Extensión", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion
    }
}
