using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;
        
        /// <summary>
        /// Propiedad que valida el dato recibido y lo asigna a numero
        /// </summary>
        public string SetNumero
        {
            set
            { 
                numero = ValidarNumero(value);
            }
        }

        /// <summary>
        /// Constructor por defecto que iniciliza en 0 un objeto de tipo Numero
        /// </summary>
        public Numero()
        {
            numero = 0;
        }

        /// <summary>
        /// Constructor que iniciliza con el valor pasado por parametro tipo Double, a una instancia de tipo Numero
        /// </summary>
        /// <param name="numero">numero a instanciar en el Numero (double)</param>
        public Numero(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Constructor que iniciliza con el valor pasado por parametro tipo String(primero lo verifica), a una instancia de tipo Numero
        /// </summary>
        /// <param name="strNumero">numero a validar e instanciar en el numero (recibido como String)</param>
        public Numero(string strNumero)
        {
            SetNumero = strNumero;
        }

        /// <summary>
        /// Valida que el parametro recibido sea numerico
        /// </summary>
        /// <param name="strNumero">parametro recibido en formato string</param>
        /// <returns>retorna el numero en formato double o en caso de fallar, devuelve 0</returns>
        private double ValidarNumero(string strNumero)
        {
            double valorRetorno;

            if(Double.TryParse(strNumero,out valorRetorno))
            {
                return valorRetorno;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Valida que la cadena este compuestas por 0 y 1. Transforma el parametro string en un arrays de char y compara 1 x 1.
        /// </summary>
        /// <param name="binario">cadena a validar(formato string)</param>
        /// <returns>retorna true si son ceros y unos sino retorna false si tiene algun otro caracter</returns>
        private static bool EsBinario(string binario)
        {
            bool valorRetorno = true;
            char[] arrayBinario = binario.ToCharArray();

            for(int i=0;i<arrayBinario.Length;i++)
            {
                if(arrayBinario[i] != '0' && arrayBinario[i] != '1')
                {
                    valorRetorno = false;
                    break;
                }
            }
            return valorRetorno;
        }

        /// <summary>
        /// Recibe un string binario, comprobamos si cumple los requisitos de un numero binario, y lo convierte a decimal
        /// </summary>
        /// <param name="binario">numero binario a controlar y covnertir a decimal(formato string)</param>
        /// <returns>retorna el numero decimal en formato string en caso de poder, sino, devuelve "Valor invalido"</returns>
        public static string BinarioDecimal(string binario)
        {
            string valorRetorno = "Valor Invalido";
            double numeroDecimalAcumulado = 0;
            char[] arrayBinario = binario.ToCharArray();
            Array.Reverse(arrayBinario);

            //Lo que hacemos dentro del if, es recorrer el array invertido, y si en tal posicion hay un numero 1, se hace 2 elevado a i(posicion actaul del array)
            if (EsBinario(binario))
            {
                for(int i=0;i<arrayBinario.Length;i++)
                {
                    if(arrayBinario[i] == '1')
                    {
                        numeroDecimalAcumulado += Math.Pow(2, i);//2 elevado a i, se va acumulando. 
                    }
                }
                valorRetorno = numeroDecimalAcumulado.ToString();
            }
            
            return valorRetorno;
        }

        /// <summary>
        /// Recibe un numero decimal en formato double y lo transforma en un numero binario si es posible
        /// </summary>
        /// <param name="numero">parametro a controlar y convertir(formato double)</param>
        /// <returns>retorna un numero binario en un string, o "valor invalido" en caso de no poder realizarse</returns>
        public static string DecimalBinario(double numero)
        {
            string valorRetorno = "Valor Invalido";
            long numeroSinSigno = Convert.ToInt64(Math.Abs(numero));

            if(numero > 0)
            {
                valorRetorno = Convert.ToString(numeroSinSigno, 2);
            }

            return valorRetorno;
        }

        /// <summary>
        /// Recibe un numero decimal en formato string, lo convierte en double, reutiliza el metodo ya creado y lo transforma en un numero binario si es posible
        /// </summary>
        /// <param name="numero">parametro a controlar y convertir(formato string)</param>
        /// <returns>retorna un numero binario en un string, o "valor invalido" en caso de no poder realizarse</returns>
        public static string DecimalBinario(string numero)
        {
            string valorRetorno = "Valor Invalido";
            double numeroDecimal;

            if(Double.TryParse(numero,out numeroDecimal))
            {
                valorRetorno = DecimalBinario(numeroDecimal);
            }

            return valorRetorno;
        }

        /// <summary>
        /// Metodo que suma 2 objetos del tipo Numero
        /// </summary>
        /// <param name="n1">primer numero a operar (tipo Numero)</param>
        /// <param name="n2">segundo numero a operar (tipo Numero)</param>
        /// <returns>el resultado de la operacion aritmetica en formato double</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            double resultado;

            resultado = n1.numero + n2.numero;

            return resultado;
        }

        /// <summary>
        /// Metodo que resta 2 objetos del tipo Numero
        /// </summary>
        /// <param name="n1">primer numero a operar (tipo Numero)</param>
        /// <param name="n2">segundo numero a operar (tipo Numero)</param>
        /// <returns>el resultado de la operacion aritmetica en formato double</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            double resultado;

            resultado = n1.numero - n2.numero;

            return resultado;
        }

        /// <summary>
        /// Metodo que divide 2 objetos del tipo Numero
        /// </summary>
        /// <param name="n1">primer numero a operar (tipo Numero)</param>
        /// <param name="n2">segundo numero a operar (tipo Numero)</param>
        /// <returns>el resultado de la operacion aritmetica en formato double o en caso de ser una division por 0, retorna double.MinValue</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            double resultado;

            if(n2.numero == 0)
            {
                resultado = double.MinValue;
            }
            else
            {
                resultado = n1.numero / n2.numero;
            }

            return resultado;
        }

        /// <summary>
        /// Metodo que multiplica 2 objetos del tipo Numero
        /// </summary>
        /// <param name="n1">primer numero a operar (tipo Numero)</param>
        /// <param name="n2">segundo numero a operar (tipo Numero)</param>
        /// <returns>el resultado de la operacion aritmetica en formato double</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            double resultado;

            resultado = n1.numero * n2.numero;

            return resultado;
        }

    }
}
