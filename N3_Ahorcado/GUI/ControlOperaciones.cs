using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace N3_Ahorcado.GUI
{
    public partial class ControlOperaciones : UserControl
    {
        #region Campos
        private Principal m_principal;
        #endregion

        #region Constructores
        public ControlOperaciones(Principal principal)
        {
            InitializeComponent();

            m_principal = principal;
        }
        #endregion

        #region Eventos
        private void btnIniciarJuego_Click(object sender, EventArgs e)
        {
            m_principal.IniciarJuego();
        }
        private void btnOpcion1_Click(object sender, EventArgs e)
        {
            m_principal.PuntoExtension1();
        }
        private void btnOpcion2_Click(object sender, EventArgs e)
        {
            m_principal.PuntoExtension2();
        }
        #endregion
    }
}
