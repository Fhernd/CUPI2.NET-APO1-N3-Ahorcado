using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using N3_Ahorcado.Modelo;

namespace N3_Ahorcado.GUI
{
    public partial class ControlAhorcado : UserControl
    {
        #region Campos
        private Principal m_principal;
        #endregion

        #region Constructores
        public ControlAhorcado(Principal principal)
        {
            InitializeComponent();

            m_principal = principal;
        }
        #endregion

        #region Métodos
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
        public void EtiquetarMensaje(string mensaje)
        {
            lblMensaje.Text = mensaje;
        }
        #endregion
    }
}
