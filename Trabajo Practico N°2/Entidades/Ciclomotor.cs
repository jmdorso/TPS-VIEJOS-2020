using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Ciclomotor : Vehiculo
    {
        #region "Propiedad"
        /// <summary>
        /// ReadOnly: Retornará el tamaño,siempre los Ciclomotores son 'Chico'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Chico;
            }
        }
        #endregion

        #region "Constructor"
        /// <summary>
        /// Constructor de un Ciclomotor, utilizando el constructor de la clase base Vehiculo
        /// </summary>
        /// <param name="marca">Marca del Ciclomotor</param>
        /// <param name="chasis">Chasis del Ciclomotor</param>
        /// <param name="color">Color del Ciclomotor</param>
        public Ciclomotor(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
        }
        #endregion

        #region "Metodo"
        /// <summary>
        /// Metodo que sobreescribe el mostrar de la clase base, mostrando los datos del ciclomotor
        /// </summary>
        /// <returns>retorna los datos del CICLOMOTOR en formato string</returns>
        public override string Mostrar()
        {
            StringBuilder auxRetorno = new StringBuilder();

            auxRetorno.AppendLine("CICLOMOTOR");
            auxRetorno.AppendLine(base.Mostrar());
            auxRetorno.AppendLine($"TAMAÑO : {this.Tamanio}");
            //comentado para que quede exactamente la misma cantidad de saltos de linea al ejemplo "Funcional"
            //auxRetorno.AppendLine("");
            auxRetorno.AppendLine("---------------------");

            return auxRetorno.ToString();
        }
        #endregion
    }
}
