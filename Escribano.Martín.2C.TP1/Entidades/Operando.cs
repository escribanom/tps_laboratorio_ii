using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Operando
    {
        private double numero;
        private string Numero
        {
            set
            {
                this.numero = ValidarOperando(value);
            }
        }
        /// <summary>
        /// Constructor de clase
        /// </summary>
        public Operando() : this(0)
        {

        }
        /// <summary>
        /// Constructor de clase inicializado por parámetrode tipo double
        /// </summary>
        public Operando(double numero)
        {
            this.numero = numero;
        }
        /// <summary>
        /// Constructor de clase inicializado por parámetro de tipo string
        /// </summary>
        public Operando(string strNumero)
        {
            this.Numero = strNumero;
        }
        /// <summary>
        /// Valida y asigna un valor de tipo double
        /// </summary>
        private double ValidarOperando(string strNumero)
        {
            if (Double.TryParse(strNumero, out double operando))
            {
                return operando;
            }
            return 0;
        }
        /// <summary>
        /// Verifica que el parámetro string recibido sea un numero binario
        /// </summary>
        /// <param name="binario">numero a convertir</param>
        /// <returns>Retorna true si es binario, caso contrario devuelve false</returns>
        private bool EsBinario(string binario)
        {
            bool retorno = false;
            char[] auxArray = binario.ToCharArray();

            for (int i = 0; i < auxArray.Length; i++)
            {
                if (auxArray[i] == '1' || auxArray[i] == '0')
                {
                    retorno = true;
                }
            }
            return retorno;
        }
        /// <summary>
        /// Convierte un numero binario a numero decimal
        /// </summary>
        /// <param name="binario">numero a convertir</param>
        /// <returns>Si pudo convertir retorna un string con el numero decimal cargado, caso contrario devuelve un string cargado con "Valor inválido"</returns>
        public string BinarioDecimal(string binario)
        {
            double numeroDecimal = 0;
            double auxDecimal, absoluto;
            string absolutobin;
            if (EsBinario(binario))
            {
                auxDecimal = Double.Parse(binario);
                absoluto = Math.Abs(auxDecimal);
                absolutobin = Convert.ToString(absoluto);

                for (int i = 0; i <= absolutobin.Length - 1; i++)
                {
                    double.TryParse(absolutobin[i].ToString(), out double binarioParsed);
                    if (binarioParsed == 1 || binarioParsed == 0)
                    {
                        numeroDecimal += binarioParsed * Math.Pow(2, absolutobin.Length - i - 1);
                    }
                    else
                    {
                        return "Valor invalido";
                    }
                }
            }
            return numeroDecimal.ToString();
        }
        /// <summary>
        /// Convierte un numero decimal a numero binario
        /// </summary>
        /// <param name="numero">numero a convertir</param>
        /// <returns>Si pudo convertir retorna un string con el numero binario cargado, caso contrario devuelve un string cargado con "Valor inválido"</returns>
        public string DecimalBinario(double numero)
        {
            string numeroBinario = "";
            double absoluto;
            absoluto = Math.Abs(numero);
            long cociente = (long)absoluto;
            long resto = (long)absoluto;

            while (cociente >= 1)
            {
                resto = cociente % 2;
                cociente = cociente / 2;

                if (resto != 0)
                {
                    numeroBinario = "1" + numeroBinario;
                }
                else
                {
                    numeroBinario = "0" + numeroBinario;
                }
            }
            return numeroBinario;
        }
        /// <summary>
        /// Convierte un numero decimal a numero binario
        /// </summary>
        /// <param name="numero">numero a convertir</param>
        /// <returns>Si pudo convertir retorna un string con el numero binario cargado, caso contrario devuelve un string cargado con "Valor inválido"</returns>
        public string DecimalBinario(string numero)
        {
            if (Double.TryParse(numero, out double auxDec))
            {
                return DecimalBinario(auxDec);
            }
            else
            {
                return "Valor Inválido";
            }
        }
        /// <summary>
        /// Sobrecarga del operador -
        /// </summary>
        /// <param name="n1">primer numeor a restar</param>
        /// <param name="n2">segundo numero a reestar</param>
        /// <returns>La resta de los 2 objetos recibidos</returns>
        public static double operator -(Operando n1, Operando n2)
        {
            return (n1.numero - n2.numero);
        }
        /// <summary>
        /// Sobrecarga del operador +
        /// </summary>
        /// <param name="n1">primer numeor a sumar</param>
        /// <param name="n2">segundo numero a sumar</param>
        /// <returns>La suma de los 2 objetos recibidos</returns>
        public static double operator +(Operando n1, Operando n2)
        {
            return (n1.numero + n2.numero);
        }
        /// <summary>
        /// Sobrecarga del operador *
        /// </summary>
        /// <param name="n1">primer numeor a multiplicar</param>
        /// <param name="n2">segundo numero a multiplicar</param>
        /// <returns>La multiplicacion de los 2 objetos recibidos</returns>
        public static double operator *(Operando n1, Operando n2)
        {
            return (n1.numero * n2.numero);
        }
        /// <summary>
        /// Sobrecarga del operador /
        /// </summary>
        /// <param name="n1">primer numeor a dividir</param>
        /// <param name="n2">segundo numero a dividir</param>
        /// <returns>La division entre los 2 objetos recibidos</returns>
        public static double operator /(Operando n1, Operando n2)
        {
            double auxDiv;
            if (n2.numero == 0)
            {

                auxDiv = double.MinValue;
            }
            else
            {
                auxDiv = (n1.numero / n2.numero);
            }
            return auxDiv;
        }
    }
}
