using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Vehiculo
    {
        #region "Atributos"
        private string chasis;
        private ConsoleColor color;
        private EMarca marca;
        #endregion

        #region "Enumerados"
        /// <summary>
        /// Enumerado para definir las marcas de los vehiculos 
        /// </summary>
        public enum EMarca
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda, HarleyDavidson
        }
        /// <summary>
        /// Enumerado para definir los tamaños de los vehiculos
        /// </summary>
        public enum ETamanio
        {
            Chico, Mediano, Grande
        }
        #endregion

        #region "Propiedad"
        /// <summary>
        /// ReadOnly: Retornará el tamaño
        /// </summary>
        protected abstract ETamanio Tamanio { get;}
        #endregion

        #region "Constructor"
        /// <summary>
        /// Constructor de Vehiculos por 3 parametros
        /// </summary>
        /// <param name="chasis"></param>
        /// <param name="marca"></param>
        /// <param name="color"></param>
        public Vehiculo(string chasis, EMarca marca, ConsoleColor color)
        {
            this.chasis = chasis;
            this.marca = marca;
            this.color = color;
        }
        #endregion

        #region "Sobrecarga"
        /// <summary>
        /// Sobrecarga (explicita) que muestra datos del vehiculo.
        /// </summary>
        /// <param name="vehiculo">el vehiculo a mostrar</param>
        public static explicit operator string(Vehiculo vehiculo)
        {
            StringBuilder auxRetorno = new StringBuilder();

            auxRetorno.AppendLine($"CHASIS: {vehiculo.chasis}\r");
            auxRetorno.AppendLine($"MARCA : {vehiculo.marca}\r");
            auxRetorno.AppendLine($"COLOR : {vehiculo.color}\r");
            auxRetorno.AppendLine("---------------------");

            return auxRetorno.ToString();
        }
        #endregion

        #region "Metodo"
        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }
        #endregion

        #region "Operadores"


        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="vehiculoUno">primer vehiculo a comparar</param>
        /// <param name="vehiculoDos">segundo vehiculo a comparar</param>
        /// <returns></returns>
        public static bool operator ==(Vehiculo vehiculoUno, Vehiculo vehiculoDos)
        {
            return (vehiculoUno.chasis == vehiculoDos.chasis);
        }

        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="vehiculoUno">primer vehiculo a comparar</param>
        /// <param name="vehiculoDos">segundo vehiculo a comparar</param>
        /// <returns></returns>
        public static bool operator !=(Vehiculo vehiculoUno, Vehiculo vehiculoDos)
        {
            return (vehiculoUno.chasis != vehiculoDos.chasis);
        }
        #endregion 
    }
}
