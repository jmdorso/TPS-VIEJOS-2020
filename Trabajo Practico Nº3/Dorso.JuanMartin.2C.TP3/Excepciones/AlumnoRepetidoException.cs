using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {
        #region Constructores
        /// <summary>
        /// Constructor con msj predeterminado
        /// </summary>
        public AlumnoRepetidoException()
            : base("Alumno repetido.")
        {

        }

        /// <summary>
        /// Constructor con parametro para msj personalizado
        /// </summary>
        /// <param name="msj">msj personalizado</param>
        public AlumnoRepetidoException(string msj)
            : base(msj)
        {

        }
        #endregion
    }
}
