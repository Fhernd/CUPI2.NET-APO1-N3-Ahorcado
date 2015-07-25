// ===++===
//
//	OrtizOL - xCSw
//
//  Proyecto: Cupi2.NET
//
// ===--===
/*============================================================
//
// Clase(s): LetraTest
//
// Propósito: Probar el estado y comportamiento de la entidad 
// Letra.
//
// Original: 
//
============================================================*/

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using N3_Ahorcado.Modelo;

namespace N3_AhoracadoTest
{
    /// <summary>
    /// Clase de prueba de la clase Letra.
    /// </summary>
    [TestClass]
    public class LetraTest
    {
        #region Campos de prueba
        /// <summary>
        /// Letra de prueba.
        /// </summary>
        private Letra m_letra;
        #endregion

        #region Escenarios de configuración de pruebas
        /// <summary>
        /// Configuración de escenario de pruebas no. 1.
        /// </summary>
        public void ConfiguracionEscenario1()
        {
            m_letra = new Letra('m');
        }
        /// <summary>
        /// /// Configuración de escenario de pruebas no. 2.
        /// </summary>
        public void ConfiguracionEscenario2()
        {
            m_letra = new Letra('P');
        }
        /// <summary>
        /// /// Configuración de escenario de pruebas no. 3.
        /// </summary>
        public void ConfiguracionEscenario3()
        {
            m_letra = new Letra('a');
        }
        /// <summary>
        /// /// Configuración de escenario de pruebas no. 4.
        /// </summary>
        public void ConfiguracionEscenario4()
        {
            m_letra = new Letra('Z');
        }
        #endregion

        #region Métodos de prueba
        /// <summary>
        /// Prueba de la igualdad de dos letras.
        /// </summary>
        [TestMethod]
        public void EsIgualTest1()
        {
            ConfiguracionEscenario1();

            Assert.IsTrue(m_letra.EsIgual(new Letra('M')), "Las letras deben ser iguales");
            Assert.IsTrue(m_letra.EsIgual(new Letra('m')), "Las letras deben ser iguales");
        }
        /// <summary>
        /// Prueba de la igualdad de dos letras.
        /// </summary>
        [TestMethod]
        public void EsIgualTest2()
        {
            ConfiguracionEscenario2();

            Assert.IsTrue(m_letra.EsIgual(new Letra('p')), "Las letras deben ser iguales.");
            Assert.IsTrue(m_letra.EsIgual(new Letra('P')), "Las letras deben ser iguales.");
        }
        /// <summary>
        /// Prueba de la igualdad de dos letras.
        /// </summary>
        [TestMethod]
        public void EsIgualTest3()
        {
            ConfiguracionEscenario3();

            Assert.IsTrue(m_letra.EsIgual(new Letra('A')), "Las letras deben ser iguales.");
            Assert.IsTrue(m_letra.EsIgual(new Letra('a')), "Las letras deben ser iguales.");
        }
        /// <summary>
        /// Prueba de la igualdad de dos letras.
        /// </summary>
        [TestMethod]
        public void EsIgualTest4()
        {
            ConfiguracionEscenario4();

            Assert.IsTrue(m_letra.EsIgual(new Letra('z')), "Las letras deben ser iguales.");
            Assert.IsTrue(m_letra.EsIgual(new Letra('Z')), "Las letras deben ser iguales.");
        }
        /// <summary>
        /// Prueba de la igualdad de dos letras.
        /// </summary>
        [TestMethod]
        public void EsIgualTest5()
        {
            ConfiguracionEscenario2();

            Assert.IsFalse(m_letra.EsIgual(new Letra('J')), "Las eltras no deben ser iguales.");
            Assert.IsFalse(m_letra.EsIgual(new Letra('j')), "Las eltras no deben ser iguales.");
        }
        /// <summary>
        /// Prueba de la igualdad de dos letras.
        /// </summary>
        [TestMethod]
        public void EsIgualTest6()
        {
            ConfiguracionEscenario2();

            Assert.IsFalse(m_letra.EsIgual(new Letra('x')), "Las letras no deben ser iguales.");
            Assert.IsFalse(m_letra.EsIgual(new Letra('X')), "Las letras no deben ser iguales.");
        }
        #endregion
    }
}
