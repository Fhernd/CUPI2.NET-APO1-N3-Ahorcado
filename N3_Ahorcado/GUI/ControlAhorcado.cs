// ===++===
//
//	OrtizOL - xCSw
//
//  Proyecto: Cupi2.NET
//
// ===--===
/*============================================================
//
// Clase(s): ControlAhorcado.
//
// Propósito: Implementar y representar el control visual 
// con las figuras y letras del juego.
//
// Original: http://cupi2.uniandes.edu.co/sitio/index.php/cursos/apo1/nivel-3/ahorcado/visualizacion-de-codigo/panelahorcado
//
============================================================*/

using System;
using System.Collections;
using System.Text;
using System.Windows.Forms;
using N3_Ahorcado.Modelo;

namespace N3_Ahorcado.GUI
{
    /// <summary>
    /// Clase que representa el control visual ControlAhorcado.
    /// </summary>
    public partial class ControlAhorcado : UserControl
    {
        #region Campos
        /// <summary>
        /// Referencia al formulario principal del juego.
        /// </summary>
        private Principal m_principal;
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializa una nueva instancia de la clase ControlAhorcado.
        /// </summary>
        /// <param name="principal">Referencia al formulario principal.</param>
        public ControlAhorcado(Principal principal)
        {
            InitializeComponent();

            m_principal = principal;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Actualiza el estado del juego.
        /// </summary>
        public void Actualizar()
        {
            short intentosDisponibles = m_principal.IntentosDisponibles;

            lblIntentos.Text = String.Format("Quedan {0}", intentosDisponibles.ToString());

            switch(intentosDisponibles)
            {
                case 0:
                    pbxAhorcado.Image = Properties.Resources.quedan0;
                    break;
                case 1:
                    pbxAhorcado.Image = Properties.Resources.quedan1;
                    break;
                case 2:
                    pbxAhorcado.Image = Properties.Resources.quedan2;
                    break;
                case 3:
                    pbxAhorcado.Image = Properties.Resources.quedan3;
                    break;
                case 4:
                    pbxAhorcado.Image = Properties.Resources.quedan4;
                    break;
                case 5:
                    pbxAhorcado.Image = Properties.Resources.quedan5;
                    break;
                case 6:
                    pbxAhorcado.Image = Properties.Resources.quedan6;
                    break;
            }

            // Actualización de la palabra: 
            ArrayList palabra = m_principal.Letras;
            StringBuilder sb = new StringBuilder(String.Empty);
            int indice = 0;
            int tamanio = palabra.Count;

            while(indice < tamanio)
            {
                Letra letra = (Letra)palabra[indice];
                sb.Append(String.Format(" {0} ", letra.Caracter));
                ++indice;
            }

            lblPalabra.Text = sb.ToString().Trim();

            // Cambia el estado del mensaje: 
            EstadoJuego estadoJuego = m_principal.Estado;

            if (estadoJuego == EstadoJuego.Ganador)
            {
                lblMensaje.Text = "¡Palabra Adivinada!";
            }
            else if (estadoJuego == EstadoJuego.Ahorcado)
            {
                lblMensaje.Text = "¡Ahorcado!";
            }
        }
        /// <summary>
        /// Etiqueta mensaje de la letra jugada por el jugador.
        /// </summary>
        /// <param name="mensaje">Mensaje de la etiqueta.</param>
        public void EtiquetarMensaje(string mensaje)
        {
            lblMensaje.Text = mensaje;
        }
        #endregion
    }
}
