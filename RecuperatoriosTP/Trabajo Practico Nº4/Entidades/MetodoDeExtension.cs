using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class MetodoDeExtension
    {
        /// <summary>
        /// Metodo que extiende a double y calcula la ganancia del calzado
        /// </summary>
        /// <param name="precioCompra"></param>
        /// <param name="precioVenta"></param>
        /// <returns></returns>
        public static double GananciaTotalDelCalzado(this double precioCompra, double precioVenta)
        {
            return (precioVenta - precioCompra);
        }
    }
}
