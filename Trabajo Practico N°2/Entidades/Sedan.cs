using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using Microsoft.Win32;

namespace Entidades
{
    public class Sedan : Vehiculo
    {
        #region "Atributo"
        private ETipo tipo;
        #endregion

        #region "Enumerado"
        /// <summary>
        /// Enumerado para definir el tipo(cantidad de puertas) de Sedan. 
        /// </summary>
        public enum ETipo 
        { 
            CuatroPuertas, CincoPuertas 
        }
        #endregion

        #region "Propiedad"
        /// <summary>
        /// ReadOnly: Retornará el tamaño,siempre los Sedan son 'Mediano'
        /// </summary>
        protected override ETamanio Tamanio
        {
            get
            {
                return ETamanio.Mediano;
            }
        }
        #endregion

        #region "Constructores"
        /// <summary>
        /// Por defecto, TIPO será CuatroPuertas
        /// </summary>
        /// <param name="marca">Marca del Sedan</param>
        /// <param name="chasis">Chasis del Sedan</param>
        /// <param name="color">Color del Sedan</param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color)
            : this(marca, chasis, color,ETipo.CuatroPuertas)
        {            
        }

        /// <summary>
        /// Constructor que utiliza el de la base con posibilidad de inicializar el tipo
        /// </summary>
        /// <param name="marca">Marca del Sedan</param>
        /// <param name="chasis">Chasis del Sedan</param>
        /// <param name="color">Color del Sedan</param>
        /// <param name="tipo">Tipo (cant puertas) del Sedan</param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color, ETipo tipo)
            : base(chasis,marca,color)
        {
            this.tipo = tipo;
        }
        #endregion

        #region "Metodo"
        /// <summary>
        /// Metodo que sobreescribe el mostrar de la clase base, mostrando los datos del Sedan
        /// </summary>
        /// <returns>retorna los datos del SEDAN en formato string</returns>
        public override string Mostrar()
        {
            StringBuilder auxRetorno = new StringBuilder();

            auxRetorno.AppendLine("SEDAN");
            auxRetorno.AppendLine(base.Mostrar());
            //En el ejemplo "funcional" se muestra el Tamaño y Tipo en la misma linea, por eso solo uso Append
            auxRetorno.Append($"TAMAÑO : {this.Tamanio}");
            auxRetorno.AppendLine("TIPO : " + this.tipo);
            auxRetorno.AppendLine("");
            auxRetorno.AppendLine("---------------------");

            return auxRetorno.ToString();
        }
        #endregion
    }
}
