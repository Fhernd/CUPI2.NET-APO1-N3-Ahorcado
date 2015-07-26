// ===++===
//
//	OrtizOL - xCSw
//
//  Proyecto: Cupi2.NET
//
// ===--===
/*============================================================
//
// Clase(s): ControlOperaciones.
//
// Propósito: Implementar y representar el control con las 
// operaciones disponibles en el juego.
//
// Original: N/D.
//
============================================================*/

using System;
using System.Windows.Forms;

namespace N3_Ahorcado.GUI
{
    /// <summary>
    /// Clase que representa el control visual ControlOperaciones.
    /// </summary>
    public partial class ControlOperaciones : UserControl
    {
        #region Campos
        /// <summary>
        /// Referencia al formulario principal del juego.
        /// </summary>
        private Principal m_principal;
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializa una nueva instancia de la clase ControlOperaciones.
        /// </summary>
        /// <param name="principal">Referencia al formulario principal.</param>
        public ControlOperaciones(Principal principal)
        {
            InitializeComponent();

            m_principal = principal;
        }
        #endregion

        #region Eventos
        /// <summary>
        /// Se activa cuando se hace clic en el botón Iniciar Juego.
        /// </summary>
        /// <param name="sender">Objeto generador del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void btnIniciarJuego_Click(object sender, EventArgs e)
        {
            m_principal.IniciarJuego();
        }
        /// <summary>
        /// Activa el punto de extensión no. 1.
        /// </summary>
        /// <param name="sender">Objeto generador del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void btnOpcion1_Click(object sender, EventArgs e)
        {
            m_principal.PuntoExtension1();
        }
        /// <summary>
        /// Activa el punto de extensión no. 2.
        /// </summary>
        /// <param name="sender">Objeto generador del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void btnOpcion2_Click(object sender, EventArgs e)
        {
            m_principal.PuntoExtension2();
        }
        #endregion
    }
}
