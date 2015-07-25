// ===++===
//
//	OrtizOL - xCSw
//
//  Proyecto: Cupi2.NET
//
// ===--===
/*============================================================
//
// Clase(s): Letra.
//
// Propósito: Representar e implementar la entidad Letra del 
// dominio.
//
// Original: http://cupi2.uniandes.edu.co/sitio/index.php/cursos/apo1/nivel-3/ahorcado/visualizacion-de-codigo/letra
//
============================================================*/

using System;

namespace N3_Ahorcado.Modelo
{
    /// <summary>
    /// Representa una letra de una palabra.
    /// </summary>
    public class Letra
    {
        #region Campos
        /// <summary>
        /// Carácter que representa la letra.
        /// </summary>
        private Char m_letra;
        #endregion

        #region Propiedades
        /// <summary>
        /// Establece y obtiene el carácter que representa la letra.
        /// </summary>
        public Char Caracter 
        {
            get
            {
                return m_letra;
            }
            set
            {
                m_letra = value;
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Inicializa una nueva instancia de la clase Letra con un carácter específico.
        /// </summary>
        /// <param name="letra">Carácter de la letra.</param>
        public Letra(char letra)
        {
            m_letra = letra;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Determina si una letra es igual a otra.
        /// </summary>
        /// <param name="letra">Letra a comparar.</param>
        /// <returns><em>true</em> si las letras son iguales; <em>false</em> en caso contrario.</returns>
        public bool EsIgual(Letra letra)
        {
            bool igual = false;

            if (letra.Caracter == Caracter)
            {
                igual = true;
            }
            else if (Caracter >= 97 && ((Caracter - 32) == letra.Caracter))
            {
                igual = true;
            }
            else if (Caracter + 32 == letra.Caracter)
            {
                igual = true;
            }

            return igual;
        }
        #endregion
    }
}
