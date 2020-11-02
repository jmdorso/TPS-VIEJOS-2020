using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Excepciones;

namespace Archivos
{
    public interface IArchivo<T>
    {
        #region Metodos
        /// <summary>
        /// Metodo Guardar de la interfaz 
        /// </summary>
        /// <param name="archivo">archivo donde se va a guardar</param>
        /// <param name="datos">datos a guardar</param>
        /// <returns>true si se puede, una exception si no se puede</returns>
        bool Guardar(string archivo, T datos);

        /// <summary>
        /// Metodo Leer de la interfaz
        /// </summary>
        /// <param name="archivo">archivo a leer</param>
        /// <param name="datos">en donde se van guardar los datos </param>
        /// <returns>true si se puede, una exception si no se puede</returns>
        bool Leer(string archivo, out T datos);
        #endregion
    }
}
