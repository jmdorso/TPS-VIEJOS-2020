using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Remoting.Messaging;

using Exceptions;

namespace Archivos
{
    public class Texto : IArchivos<string>
    {
           
        #region Metodos
        /// <summary>
        /// Propiedad que devuelve la direccion en donde guardar el archivo (escritorio)
        /// </summary>
        public string GetDirectoryPath
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\";
            }
        }



        /// <summary>
        /// Guardara un archivo con formato texto
        /// </summary>
        /// <param name="archivo">Archivo a guardar</param>
        /// <param name="datos">Datos a cargar en el archivo</param>
        /// <returns>True si pudo guardar, false en otro caso</returns>
        public bool Guardar(string archivo, string datos)
            {
                bool auxRetorno = false;
                StreamWriter streamWriter = new StreamWriter($"{this.GetDirectoryPath}{archivo}", false);

                try
                {
                    if (datos != null)
                    {
                        streamWriter.WriteLine(datos);
                        auxRetorno = true;
                    }
                    else
                    {
                        throw new ArchivosException("Los datos son null");
                    }
                }
                catch (Exception exc)
                {
                    throw new ArchivosException(exc);
                }
                finally
                {
                    streamWriter.Close();
                }

                return auxRetorno;
            }

            /// <summary>
            /// Leera un archivo con formato de texto
            /// </summary>
            /// <param name="archivo">Archivo a leer</param>
            /// <param name="datos">Donde guardara los datos del archivo</param>
            /// <returns>True si pudo guardar, false en otro caso</returns>
            public bool Leer(string archivo, out string datos)
            {
                bool auxRetorno = false;
                StreamReader streamReader = new StreamReader($"{this.GetDirectoryPath}{archivo}");

                try
                {
                    if (File.Exists(($"{this.GetDirectoryPath}{archivo}")))
                    {
                        datos = streamReader.ReadToEnd();
                        auxRetorno = true;
                    }
                    else
                    {
                        throw new ArchivosException("No existe el archivo");
                    }
                }
                catch (Exception exc)
                {
                    throw new ArchivosException(exc);
                }
                finally
                {
                    streamReader.Close();
                }

                return auxRetorno;
            }
            #endregion
        }
    }

