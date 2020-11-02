using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : Exception
    {
        #region Constructores
        /// <summary>
        /// Constructor con msj predeterminado
        /// </summary>
        public DniInvalidoException()
            : base("DNI Invalido")
        {

        }

        /// <summary>
        /// Constructor captura excepcion y da msj de error predeterminado
        /// </summary>
        /// <param name="e"></param>
        public DniInvalidoException(Exception e)
            : base("DNI Invalido",e)
        {

        }

        /// <summary>
        /// Constructor con parametro para msj personalizado
        /// </summary>
        /// <param name="message">msj personalizado</param>
        public DniInvalidoException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// Constructor con 2 parametros, captura la excepcion y da msj de error personlizado
        /// </summary>
        /// <param name="message">msj personlizado</param>
        /// <param name="e"></param>
        public DniInvalidoException(string message, Exception e)
            : base(message,e)
        {

        }
        #endregion
    }
}
