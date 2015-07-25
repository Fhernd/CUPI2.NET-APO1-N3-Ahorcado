// ===++===
//
//	OrtizOL - xCSw
//
//  Proyecto: Cupi2.NET
//
// ===--===
/*============================================================
//
// Clase(s): JuegoAhorcadoTest
//
// Propósito: Probar el estado y comportamiento de la entidad 
// JuegoAhorcado.
//
// Original: N/D.
//
============================================================*/

using System;
using System.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using N3_Ahorcado.Modelo;

namespace N3_AhoracadoTest
{
    /// <summary>
    /// Clase de prueba de la clase JuegoAhorcado.
    /// </summary>
    [TestClass]
    public class JuegoAhorcadoTest
    {
        #region Campos de prueba
        /// <summary>
        /// Juego de prueba.
        /// </summary>
        private JuegoAhorcado m_juego;
        #endregion

        #region Escenarios de configuración de pruebas
        /// <summary>
        /// Configuración de escenario de pruebas no. 1.
        /// </summary>
        private void ConfiguracionEscenario1()
        {
            m_juego = new JuegoAhorcado();
        }
        #endregion

        #region Métodos de prueba
        /// <summary>
        /// Prueba la inicialización correcta del juego.
        /// </summary>
        [TestMethod]
        public void InicializacionTest()
        {
            ConfiguracionEscenario1();

            for(int i = 0; i < (int)JuegoAhorcadoConstantes.TotalPalabras; ++i)
            {
                Assert.IsNotNull(m_juego.ObtenerPalabra(i));
            }

            Assert.AreEqual(m_juego.IntentosDisponibles, (int)JuegoAhorcadoConstantes.MaximoIntentos);
            Assert.AreEqual(m_juego.Estado, EstadoJuego.NoIniciado);
        }
        /// <summary>
        /// Prueba el inicio correcto del juego.
        /// </summary>
        [TestMethod]
        public void IniciarJuegoTest()
        {
            ConfiguracionEscenario1();

            m_juego.IniciarJuego();

            Assert.AreEqual(EstadoJuego.Jugando, m_juego.Estado, "El estado del juego es incorrecto.");
            Assert.AreEqual(m_juego.IntentosDisponibles, (int)JuegoAhorcadoConstantes.MaximoIntentos, String.Format("El número de intentos debe ser {0}", (int)JuegoAhorcadoConstantes.MaximoIntentos));
            Assert.AreEqual(0, m_juego.Jugadas.Count, "El vector de letras jugadas no se ha inicializado correctamente.");
            Assert.IsNotNull(m_juego.PalabraActual, "No se ha escogido aleatoriamente una palabra para adivinar.");
        }
        /// <summary>
        /// Prueba el estado actual del juego.
        /// </summary>
        [TestMethod]
        public void IniciarTest()
        {
            ConfiguracionEscenario1();

            Assert.IsFalse(m_juego.JugarLetra(new Letra('a')), "Si no está iniciado el juego, no se puede jugar.");
        }
        /// <summary>
        /// Prueba la jugada de una letra.
        /// </summary>
        [TestMethod]
        public void JugarLetraTest()
        {
            ConfiguracionEscenario1();

            m_juego.IniciarJuego();
            Palabra actual = m_juego.PalabraActual;
            ArrayList jugadas = new ArrayList();
            Letra letraIntento = new Letra('a');
            jugadas.AddRange(actual.Letras);

            Assert.IsTrue(actual.EstaCompleta(jugadas), "La palabra ya fue adivinada.");

            ArrayList ocurrencias = actual.GenerarOcurrencias(jugadas);

            Assert.IsFalse(ocurrencias.Contains('_'), "todas las letras deben ser visibles.");
            
            if (m_juego.JugarLetra(letraIntento) == true)
            {
                Assert.IsTrue(m_juego.Jugadas.Contains(letraIntento), "El vector de letras debe contener las letras jugadas.");
            }
            else
            {
                int intentos = (int)JuegoAhorcadoConstantes.MaximoIntentos - 1;

                Assert.AreEqual((int) JuegoAhorcadoConstantes.MaximoIntentos - 1, m_juego.IntentosDisponibles, String.Format("El número de intentos debe ser {0}.", intentos.ToString()));

                if ((int)JuegoAhorcadoConstantes.MaximoIntentos == 0)
                {
                    Assert.AreEqual(EstadoJuego.Ahorcado, m_juego.Estado, "El estado del juego debe ser AHORCADO.");
                }

                Assert.IsFalse(m_juego.JugarLetra(letraIntento), "La letra no est[a en la palabra.");
            }
        }
        #endregion
    }
}
