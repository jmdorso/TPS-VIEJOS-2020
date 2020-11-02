using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        #region Constructores
        /// <summary>
        /// Constructor con msj predeterminado
        /// </summary>
        public NacionalidadInvalidaException()
            : base ("La Nacionalidad no se condice con el número de DNI")
        {

        }
        /// <summary>
        /// Constructor con parametro para msj personalizado
        /// </summary>
        /// <param name="message">msj personalizado</param>
        public NacionalidadInvalidaException(string message)
            : base(message)
        {

        }
        #endregion
    }
}
