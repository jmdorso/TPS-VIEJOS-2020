using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class VentaInvalidaException : Exception
    {
        #region Constructores
        /// <summary>
        /// Constructor con msj predeterminado
        /// </summary>
        public VentaInvalidaException()
            : base("Error al vender Calzado")
        {

        }

        /// <summary>
        /// Constructor con parametro para msj personalizado
        /// </summary>
        /// <param name="msj">msj personalizado</param>
        public VentaInvalidaException(string msj)
            : base(msj)
        {

        }

        /// <summary>
        /// Constructor captura excepcion y da msj de error predeterminado
        /// </summary>
        /// <param name="innerException"></param>
        public VentaInvalidaException(Exception innerException)
            : base("Error al vender Calzado", innerException)
        {

        }
        #endregion
    }
}
