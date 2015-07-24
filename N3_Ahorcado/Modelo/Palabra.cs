using System;
using System.Collections;

namespace N3_Ahorcado.Modelo
{
    public class Palabra
    {
        #region Campos
        private ArrayList m_letras;
        #endregion

        #region Propiedades
        public ArrayList Letras
        {
            get
            {
                return m_letras;
            }
        }
        #endregion

        #region Constructures
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
        private Boolean BuscarLetraEnVector(Letra letra, ArrayList vectorLetras)
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

        public bool EstaLetra(Letra letra)
        {
            return BuscarLetraEnVector(letra, m_letras);
        }
        #endregion
    }
}
