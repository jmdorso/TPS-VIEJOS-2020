using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Suv : Vehiculo
    {
        #region "Propiedad"
        /// <summary>
        /// ReadOnly: Retornará el tamaño,siempre los SUV son 'Grande'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Grande;
            }
        }
        #endregion

        #region "Constructor"
        /// <summary>
        /// Constructor de un SUV, utilizando el constructor de la clase base Vehiculo
        /// </summary>
        /// <param name="marca">Marca del SUV</param>
        /// <param name="chasis">Chasis del SUV</param>
        /// <param name="color">Color del SUV</param>
        public Suv(EMarca marca, string chasis, ConsoleColor color)
            : base(chasis, marca, color)
        {
        }
        #endregion

        #region "Metodo"
        /// <summary>
        /// Metodo que sobreescribe el mostrar de la clase base, mostrando los datos del suv
        /// </summary>
        /// <returns>retorna los datos del SUV en formato string</returns>
        public override string Mostrar()
        {
            StringBuilder auxRetorno = new StringBuilder();

            auxRetorno.AppendLine("SUV");
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
