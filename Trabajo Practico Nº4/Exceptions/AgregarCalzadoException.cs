using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class AgregarCalzadoException : Exception
    {
        #region Constructores
        /// <summary>
        /// Constructor con msj predeterminado
        /// </summary>
        public AgregarCalzadoException()
            : base("Error al agregar Calzado")
        {

        }

        /// <summary>
        /// Constructor con parametro para msj personalizado
        /// </summary>
        /// <param name="msj">msj personalizado</param>
        public AgregarCalzadoException(string msj)
            : base(msj)
        {

        }

        /// <summary>
        /// Constructor captura excepcion y da msj de error predeterminado
        /// </summary>
        /// <param name="innerException"></param>
        public AgregarCalzadoException(Exception innerException)
            : base("Error al agregar Calzado", innerException)
        {

        }
        #endregion
    }
}
