// ===++===
//
//	OrtizOL - xCSw
//
//  Proyecto: Cupi2.NET
//
// ===--===
/*============================================================
//
// Clase(s): ControlLetras
//
// Propósito: Implementar y representar el control visual 
// para las letras (A-Z) del juego.
//
// Original: http://cupi2.uniandes.edu.co/sitio/index.php/cursos/apo1/nivel-3/ahorcado/visualizacion-de-codigo/panelletras
//
============================================================*/

using System;
using System.Windows.Forms;

namespace N3_Ahorcado.GUI
{
    public partial class ControlLetras : UserControl
    {
        #region Campos
        /// <summary>
        /// Referencia al formulario principal del juego.
        /// </summary>
        private Principal m_principal;
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializa una nueva instancia de la clase ControlLetras.
        /// </summary>
        /// <param name="principal">Referencia al formulario principal.</param>
        public ControlLetras(Principal principal)
        {
            InitializeComponent();

            m_principal = principal;

            CargarLetras();
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Carga las letras (A-Z) del juego.
        /// </summary>
        private void CargarLetras()
        {
            byte valorNumero = 65;
            Button btnLetra = null;

            for (int fila = 0; fila < 4; ++fila)
            {
                for (int col = 0; col < 7; ++col)
                {
                    if (fila != 3)
                    {
                        btnLetra = new Button();
                        btnLetra.Width = 37;
                        btnLetra.Height = 37;
                        btnLetra.Text = String.Format("{0}", ((char)valorNumero).ToString());
                        btnLetra.Click += new EventHandler(ButtonClickHandler);
                        tlpLetras.Controls.Add(btnLetra, col, fila);
                    }
                    else
                    {
                        if (col == 5)
                        {
                            break;
                        }

                        btnLetra = new Button();
                        btnLetra.Width = 37;
                        btnLetra.Height = 37;
                        btnLetra.Click += new EventHandler(ButtonClickHandler);
                        btnLetra.Text = String.Format("{0}", ((char)valorNumero).ToString());
                        tlpLetras.Controls.Add(btnLetra, col, fila);
                    }

                    ++valorNumero;
                }
            }
        }
        #endregion

        #region Eventos
        /// <summary>
        /// Responde al clic de uno de los botones de las letras.
        /// </summary>
        /// <param name="sender">Objeto generador del evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        private void ButtonClickHandler(object sender, EventArgs e)
        {
            char letra = ((Button)sender).Text.ToString()[0];
            m_principal.JugarLetra(letra);
        }
        #endregion
    }
}
