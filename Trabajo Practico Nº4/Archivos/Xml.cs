using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

using Exceptions;

namespace Archivos
{
    public class Xml<T> : IArchivos<T> 
        where T : class
    {
        #region Metodos
        /// <summary>
        /// Propiedad que devuelve la direccion en donde guardar el archivo
        /// </summary>
        public string GetDirectoryPath
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\";
            }
        }

        /// <summary>
        /// Guarda un archivo con formato XMl
        /// </summary>
        /// <param name="archivo">Archivo a guardar</param>
        /// <param name="datos">Datos a cargar en el archivo</param>
        /// <returns>True si pudo guardar, false en otro caso</returns>
        public bool Guardar(string archivo, T datos)
        {
            bool auxRetorno = false;
            XmlTextWriter xmlWriter = new XmlTextWriter($"{this.GetDirectoryPath}{archivo}", Encoding.UTF8);
            XmlSerializer xmlSerializer;
            try
            {
                if (datos != null)
                {
                    xmlSerializer = new XmlSerializer(typeof(T));
                    xmlSerializer.Serialize(xmlWriter, datos);
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
                xmlWriter.Close();
            }

            return auxRetorno;
        }

        /// <summary>
        /// Leera un archivo con formato xml
        /// </summary>
        /// <param name="archivo">Archivo a leer</param>
        /// <param name="datos">Donde guardara los datos del archivo</param>
        /// <returns>True si pudo guardar, false en otro caso</returns>
        public bool Leer(string archivo, out T datos)
        {
            bool auxRetorno = false;
            XmlTextReader xmlReader = new XmlTextReader(archivo);
            XmlSerializer xmlSerializer;

            try
            {
                if (File.Exists($"{this.GetDirectoryPath}{archivo}"))
                {
                    xmlSerializer = new XmlSerializer(typeof(T));
                    datos = (T)xmlSerializer.Deserialize(xmlReader);
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
                xmlReader.Close();
            }

            return auxRetorno;
        }
        #endregion
    }
}
