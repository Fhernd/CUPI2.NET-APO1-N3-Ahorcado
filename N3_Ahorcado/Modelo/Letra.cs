using System;

namespace N3_Ahorcado.Modelo
{
    public class Letra
    {
        #region Campos
        private Char m_letra;
        #endregion

        #region Propiedades
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
        public Letra(char letra)
        {
            m_letra = letra;
        }
        #endregion

        #region Métodos
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
