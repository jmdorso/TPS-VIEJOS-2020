using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    public class ArchivosException : Exception
    {
        #region Constructores
        /// <summary>
        /// Constructor con msj predeterminado
        /// </summary>
        public ArchivosException()
            : base("Error en Archivo")
        {

        }

        /// <summary>
        /// Constructor con parametro para msj personalizado
        /// </summary>
        /// <param name="msj">msj personalizado</param>
        public ArchivosException(string msj)
            : base(msj)
        {

        }

        /// <summary>
        /// Constructor captura excepcion y da msj de error predeterminado
        /// </summary>
        /// <param name="innerException"></param>
        public ArchivosException(Exception innerException)
            : base("Error en Archivo", innerException)
        {

        }
        #endregion
    }
}
