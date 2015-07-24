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
    public partial class ControlLetras : UserControl
    {
        #region Campos
        private Principal m_principal;
        #endregion

        #region Constructores
        public ControlLetras(Principal principal)
        {
            InitializeComponent();

            m_principal = principal;

            CargarLetras();
        }
        #endregion

        #region Métodos
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
        private void ButtonClickHandler(object sender, EventArgs e)
        {
            char letra = ((Button)sender).Text.ToString()[0];
            m_principal.JugarLetra(letra);
        }
        #endregion
    }
}
