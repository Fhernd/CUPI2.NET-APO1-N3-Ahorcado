using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using N3_Ahorcado.Modelo;

namespace N3_AhoracadoTest
{
    [TestClass]
    public class JuegoAhorcadoTest
    {
        #region Campos de prueba
        private JuegoAhorcado juego;
        #endregion

        #region Escenarios de configuración de pruebas
        private void ConfiguracionEscenario1()
        {
            juego = new JuegoAhorcado();
        }
        #endregion

        #region Métodos de prueba
        [TestMethod]
        public void InicializacionTest()
        {
            ConfiguracionEscenario1();

            for(int i = 0; i < (int)JuegoAhorcadoConstantes.TotalPalabras; ++i)
            {
                Assert.IsNotNull(juego.ObtenerPalabra(i));
            }

            Assert.AreEqual(juego.IntentosDisponibles, (int)JuegoAhorcadoConstantes.MaximoIntentos);
            Assert.AreEqual(juego.Estado, EstadoJuego.NoIniciado);
        }

        [TestMethod]
        public void IniciarJuegoTest()
        {
            ConfiguracionEscenario1();

            juego.IniciarJuego();

            Assert.AreEqual(EstadoJuego.Jugando, juego.Estado, "El estado del juego es incorrecto.");
            Assert.AreEqual(juego.IntentosDisponibles, (int)JuegoAhorcadoConstantes.MaximoIntentos, String.Format("El número de intentos debe ser {0}", (int)JuegoAhorcadoConstantes.MaximoIntentos));
            Assert.AreEqual(0, juego.Jugadas.Count, "El vector de letras jugadas no se ha inicializado correctamente.");
            Assert.IsNotNull(juego.PalabraActual, "No se ha escogido aleatoriamente una palabra para adivinar.");
        }

        [TestMethod]
        public void IniciarTest()
        {
            ConfiguracionEscenario1();

            Assert.IsFalse(juego.JugarLetra(new Letra('a')), "Si no está iniciado el juego, no se puede jugar.");
        }

        [TestMethod]
        public void JugarLetraTest()
        {
            ConfiguracionEscenario1();

            juego.IniciarJuego();
            Palabra actual = juego.PalabraActual;
            ArrayList jugadas = new ArrayList();
            Letra letraIntento = new Letra('a');
            jugadas.AddRange(actual.Letras);

            Assert.IsTrue(actual.EstaCompleta(jugadas), "La palabra ya fue adivinada.");

            ArrayList ocurrencias = actual.GenerarOcurrencias(jugadas);

            Assert.IsFalse(ocurrencias.Contains('_'), "todas las letras deben ser visibles.");
            
            if (juego.JugarLetra(letraIntento) == true)
            {
                Assert.IsTrue(juego.Jugadas.Contains(letraIntento), "El vector de letras debe contener las letras jugadas.");
            }
            else
            {
                int intentos = (int)JuegoAhorcadoConstantes.MaximoIntentos - 1;

                Assert.AreEqual((int) JuegoAhorcadoConstantes.MaximoIntentos - 1, juego.IntentosDisponibles, String.Format("El número de intentos debe ser {0}.", intentos.ToString()));

                if ((int)JuegoAhorcadoConstantes.MaximoIntentos == 0)
                {
                    Assert.AreEqual(EstadoJuego.Ahorcado, juego.Estado, "El estado del juego debe ser AHORCADO.");
                }

                Assert.IsFalse(juego.JugarLetra(letraIntento), "La letra no est[a en la palabra.");
            }
        }
        #endregion
    }
}
