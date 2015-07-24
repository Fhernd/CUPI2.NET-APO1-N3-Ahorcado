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
        private Palabra palabra;
        private ArrayList jugadas;
        private int numIntentos;
        private ArrayList letras;
        #endregion

        #region Escenarios de configuración de pruebas
        private void ConfiguracionEscenario1()
        {
            letras = new ArrayList();
            letras.Add(new Letra('v'));
            letras.Add(new Letra('e'));
            letras.Add(new Letra('c'));
            letras.Add(new Letra('t'));
            letras.Add(new Letra('o'));
            letras.Add(new Letra('r'));

            palabra = new Palabra("vector");
            jugadas = new ArrayList();
            numIntentos = 6;
        }
        #endregion

        #region Métodos de prueba
        [TestMethod]
        public void PalabraBusquedaTest()
        {
            ConfiguracionEscenario1();

            for (int i = 1; i <= numIntentos; ++i)
            {
                Letra letraIntento = (Letra)letras[i - 1];
                jugadas.Add(letraIntento);
                Assert.IsTrue(palabra.EstaLetra(letraIntento), "La letra sí está en la palabra.");
            }

            Assert.IsTrue(palabra.EstaCompleta(jugadas), "La palabra ya está completa.");

            ArrayList ocurrencias = new ArrayList();

            for(int j = 0; j < palabra.Letras.Count; j++)
            {
                ocurrencias = palabra.GenerarOcurrencias(ocurrencias);
                Assert.IsTrue(((Letra)ocurrencias[j]).EsIgual(new Letra('_')));
            }
        }
        #endregion
    }
}
