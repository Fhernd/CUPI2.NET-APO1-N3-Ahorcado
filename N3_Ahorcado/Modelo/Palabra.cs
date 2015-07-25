// ===++===
//
//	OrtizOL - xCSw
//
//  Proyecto: Cupi2.NET
//
// ===--===
/*============================================================
//
// Clase(s): Palabra
//
// Propósito: Representar e implementar la entidad Palabra 
// del dominio.
//
// Original: http://cupi2.uniandes.edu.co/sitio/index.php/cursos/apo1/nivel-3/ahorcado/visualizacion-de-codigo/palabra
//
============================================================*/

using System;
using System.Collections;

namespace N3_Ahorcado.Modelo
{
    /// <summary>
    /// Clase que representa la entidad Palabra.
    /// </summary>
    public class Palabra
    {
        #region Campos
        /// <summary>
        /// Conjunto de letras de la palabra.
        /// </summary>
        private ArrayList m_letras;
        #endregion

        #region Propiedades
        /// <summary>
        /// Obtiene el conjunto de letras de la palabra.
        /// </summary>
        public ArrayList Letras
        {
            get
            {
                return m_letras;
            }
        }
        #endregion

        #region Constructures
        /// <summary>
        /// Inicializa una nueva instancia de la clase Palabra con la cadena de caracteres que representa la palabra.
        /// </summary>
        /// <param name="palabra">Cadena de caracteres que representa la palabra.</param>
        public Palabra(string palabra)
        {
            m_letras = new ArrayList();

            for (int i = 0; i < palabra.Length; ++i)
            {
                m_letras.Add(new Letra(palabra[i]));
            }
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Bucar una letra en un vector de letras.
        /// </summary>
        /// <param name="letra">Letra a buscar.</param>
        /// <param name="vectorLetras">Vector con las letras.</param>
        /// <returns><i>true</i> si la letra fue encontrada; <i>false</i> en caso contrario.</returns>
        private bool BuscarLetraEnVector(Letra letra, ArrayList vectorLetras)
        {
            bool estaLetra = false;
            int contador = 0;

            // Se recorre el vector:
            while (contador < vectorLetras.Count && !estaLetra)
            {
                Letra l = (Letra)vectorLetras[contador];

                if (l.EsIgual(letra))
                {
                    estaLetra = true;
                }

                ++contador;
            }

            return estaLetra;
        }
        /// <summary>
        /// Genera el conjunto de ocurrencias de un conjunto de letras. Las letras no despejadas se son representadas por el carácter _.
        /// </summary>
        /// <param name="jugadas">Conjunto de letras jugadas.</param>
        /// <returns>Conjunto de ocurrencias de las letras jugadas.</returns>
        public ArrayList GenerarOcurrencias(ArrayList jugadas)
        {
            ArrayList visibles = new ArrayList();

            int contador = 0;

            // Se recorren todas las letras de la palabra: 
            while(contador < m_letras.Count)
            {
                Letra l = (Letra)m_letras[contador];

                if (!BuscarLetraEnVector(l, jugadas))
                {
                    visibles.Add(new Letra('_'));
                }
                else
                {
                    visibles.Add(l);
                }

                ++contador;
            }

            return visibles;
        }
        /// <summary>
        /// Determina si la palabra ya fue completada respecto a las letras jugadas.
        /// </summary>
        /// <param name="jugadas">Conjunto de letras jugadas.</param>
        /// <returns><i>true</i> si palabra ya fue completada; <em>false</em> en caso contrario.</returns>
        public bool EstaCompleta(ArrayList jugadas)
        {
            Boolean completa = true;
            int contador = 0;

            while(contador < m_letras.Count && completa)
            {
                Letra l = (Letra)m_letras[contador];

                if (!BuscarLetraEnVector(l, jugadas))
                {
                    completa = false;
                }

                ++contador;
            }

            return completa;
        }
        /// <summary>
        /// Determina si una letra está en el conjunto de letras de la palabra.
        /// </summary>
        /// <param name="letra">Letra a buscar.</param>
        /// <returns><em>true</em> si la letra está en el conjunto de letras; <em>false</em> en caso contrario.</returns>
        public bool EstaLetra(Letra letra)
        {
            return BuscarLetraEnVector(letra, m_letras);
        }
        #endregion
    }
}
