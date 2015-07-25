// ===++===
//
//	OrtizOL - xCSw
//
//  Proyecto: Cupi2.NET
//
// ===--===
/*============================================================
//
// Clase(s): PalabraTest
//
// Propósito: Probar el estado y comportamiento de la entidad 
// Palabra.
//
// Original: 
//
============================================================*/

using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using N3_Ahorcado.Modelo;

namespace N3_AhoracadoTest
{
    [TestClass]
    public class PalabraTest
    {
        #region Campos de prueba
        /// <summary>
        /// Palabra de prueba.
        /// </summary>
        private Palabra m_palabra;
        /// <summary>
        /// Jugadas de prueba.
        /// </summary>
        private ArrayList m_jugadas;
        /// <summary>
        /// Número de intentos de prueba.
        /// </summary>
        private int m_numIntentos;
        /// <summary>
        /// Letras del juego.
        /// </summary>
        private ArrayList m_letras;
        #endregion

        #region Escenarios de configuración de pruebas
        /// <summary>
        /// Configuración de escenario de pruebas no. 1.
        /// </summary>
        private void ConfiguracionEscenario1()
        {
            m_letras = new ArrayList();
            m_letras.Add(new Letra('v'));
            m_letras.Add(new Letra('e'));
            m_letras.Add(new Letra('c'));
            m_letras.Add(new Letra('t'));
            m_letras.Add(new Letra('o'));
            m_letras.Add(new Letra('r'));

            m_palabra = new Palabra("vector");
            m_jugadas = new ArrayList();
            m_numIntentos = 6;
        }
        #endregion

        #region Métodos de prueba
        /// <summary>
        /// Método de prueba de búsqueda de una palabra.
        /// </summary>
        [TestMethod]
        public void PalabraBusquedaTest()
        {
            ConfiguracionEscenario1();

            for (int i = 1; i <= m_numIntentos; ++i)
            {
                Letra letraIntento = (Letra)m_letras[i - 1];
                m_jugadas.Add(letraIntento);
                Assert.IsTrue(m_palabra.EstaLetra(letraIntento), "La letra sí está en la palabra.");
            }

            Assert.IsTrue(m_palabra.EstaCompleta(m_jugadas), "La palabra ya está completa.");

            ArrayList ocurrencias = new ArrayList();

            for(int j = 0; j < m_palabra.Letras.Count; j++)
            {
                ocurrencias = m_palabra.GenerarOcurrencias(ocurrencias);
                Assert.IsTrue(((Letra)ocurrencias[j]).EsIgual(new Letra('_')));
            }
        }
        #endregion
    }
}
