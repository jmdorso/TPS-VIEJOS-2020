using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class SinProfesorException : Exception
    {
        #region Constructores
        /// <summary>
        /// Constructor con msj predeterminado
        /// </summary>
        public SinProfesorException()
            : base("No hay profesor para la clase.")
        {

        }

        /// <summary>
        /// Constructor con parametro para msj personalizado
        /// </summary>
        /// <param name="msj">msj personalizado</param>
        public SinProfesorException(string msj)
            : base(msj)
        {

        }
        #endregion
    }
}
