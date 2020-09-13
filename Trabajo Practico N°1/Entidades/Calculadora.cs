using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Metodo para validar que el operador ingresado sea un '+','-','/' o '*'. 
        /// </summary>
        /// <param name="operador">El operador ingresado (char)</param>
        /// <returns>retorna el operador convertido en string o en caso de no ser ningun operador valido, retorna un "+"</returns>
        private static string ValidarOperador(char operador)
        {
            string operadorAuxiliar;

            if(operador == '+' || operador == '-' || operador == '*' || operador == '/')
            {
                operadorAuxiliar = Convert.ToString(operador);
            }
            else
            {
                operadorAuxiliar = "+";
            }

            return operadorAuxiliar;

        }
        /// <summary>
        /// Metodo de clase que valida y realiza la operacion pedida entre 2 numeros
        /// </summary>
        /// <param name="num1">El primer numero a operar (objeto Numero)</param>
        /// <param name="num2">El segundo numero a operar(objeto Numero)</param>
        /// <param name="operador">El signo de la operacion que quiero realizar(string)</param>
        /// <returns>el resultado de la operacion</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            char operadorConvertido;
            string operadorAuxiliar;
            double resultado = 0;

            char.TryParse(operador, out operadorConvertido);
            operadorAuxiliar = ValidarOperador(operadorConvertido);

            switch(operadorAuxiliar)
            {
                case "+":
                    resultado = num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
            }
            return resultado;

        }
    }
}
