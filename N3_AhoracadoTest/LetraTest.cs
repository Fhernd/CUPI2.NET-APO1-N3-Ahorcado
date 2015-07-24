using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using N3_Ahorcado.Modelo;

namespace N3_AhoracadoTest
{
    [TestClass]
    public class LetraTest
    {
        #region Campos de prueba
        private Letra letra;
        #endregion

        #region Escenarios de configuración de pruebas
        public void ConfiguracionEscenario1()
        {
            letra = new Letra('m');
        }
        
        public void ConfiguracionEscenario2()
        {
            letra = new Letra('P');
        }

        public void ConfiguracionEscenario3()
        {
            letra = new Letra('a');
        }

        public void ConfiguracionEscenario4()
        {
            letra = new Letra('Z');
        }
        #endregion

        #region Métodos de prueba
        [TestMethod]
        public void EsIgualTest1()
        {
            ConfiguracionEscenario1();

            Assert.IsTrue(letra.EsIgual(new Letra('M')), "Las letras deben ser iguales");
            Assert.IsTrue(letra.EsIgual(new Letra('m')), "Las letras deben ser iguales");
        }
        [TestMethod]
        public void EsIgualTest2()
        {
            ConfiguracionEscenario2();

            Assert.IsTrue(letra.EsIgual(new Letra('p')), "Las letras deben ser iguales.");
            Assert.IsTrue(letra.EsIgual(new Letra('P')), "Las letras deben ser iguales.");
        }

        [TestMethod]
        public void EsIgualTest3()
        {
            ConfiguracionEscenario3();

            Assert.IsTrue(letra.EsIgual(new Letra('A')), "Las letras deben ser iguales.");
            Assert.IsTrue(letra.EsIgual(new Letra('a')), "Las letras deben ser iguales.");
        }

        [TestMethod]
        public void EsIgualTest4()
        {
            ConfiguracionEscenario4();

            Assert.IsTrue(letra.EsIgual(new Letra('z')), "Las letras deben ser iguales.");
            Assert.IsTrue(letra.EsIgual(new Letra('Z')), "Las letras deben ser iguales.");
        }

        [TestMethod]
        public void EsIgualTest5()
        {
            ConfiguracionEscenario2();

            Assert.IsFalse(letra.EsIgual(new Letra('J')), "Las eltras no deben ser iguales.");
            Assert.IsFalse(letra.EsIgual(new Letra('j')), "Las eltras no deben ser iguales.");
        }

        [TestMethod]
        public void EsIgualTest6()
        {
            ConfiguracionEscenario2();

            Assert.IsFalse(letra.EsIgual(new Letra('x')), "Las letras no deben ser iguales.");
            Assert.IsFalse(letra.EsIgual(new Letra('X')), "Las letras no deben ser iguales.");
        }
        #endregion
    }
}
