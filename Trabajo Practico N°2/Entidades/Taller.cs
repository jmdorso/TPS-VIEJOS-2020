using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    public sealed class Taller
    {
        #region "Atributos"
        private int espacioDisponible;
        private List<Vehiculo> vehiculos;
        #endregion

        #region "Enumarado"
        /// <summary>
        /// Enumerado para definir el tipo de vehiculo. 
        /// </summary>
        public enum ETipo
        {
            Ciclomotor, Sedan, SUV, Todos
        }
        #endregion

        #region "Constructores"
        /// <summary>
        /// Constructor privado en donde se inicializa la lista de vehiculos del taller
        /// </summary>
        private Taller()
        {
            this.vehiculos = new List<Vehiculo>();
        }

        /// <summary>
        /// Constructor publico para instanciar los espacios disponibles del taller
        /// </summary>
        /// <param name="espacioDisponible">parametro del tipo entero que indica la cant. de espacios</param>
        public Taller(int espacioDisponible)
            : this()
        {
            this.espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro el estacionamiento y TODOS los vehículos
        /// </summary>
        /// <returns>Lista de todos los vehiculos</returns>
        public override string ToString()
        {
            return Taller.Listar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"
        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="taller">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public static string Listar(Taller taller, ETipo tipo)
        {
            StringBuilder auxRetorno = new StringBuilder();

            auxRetorno.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", taller.vehiculos.Count, taller.espacioDisponible);
            auxRetorno.AppendLine("");
            foreach (Vehiculo vehiculo in taller.vehiculos)
            {
                switch (tipo)
                {
                    case ETipo.Ciclomotor:
                        if(vehiculo is Ciclomotor)
                        {
                            auxRetorno.AppendLine(vehiculo.Mostrar());
                        }
                        break;
                    case ETipo.Sedan:
                        if(vehiculo is Sedan)
                        {
                            auxRetorno.AppendLine(vehiculo.Mostrar());
                        }
                        break;
                    case ETipo.SUV:
                        if(vehiculo is Suv)
                        {
                            auxRetorno.AppendLine(vehiculo.Mostrar());
                        }
                        break;
                    default:
                        auxRetorno.AppendLine(vehiculo.Mostrar());
                        break;
                }
            }

            return auxRetorno.ToString();
        }
        #endregion

        #region "Operadores"
        /// <summary>
        /// Agregará un elemento a la lista
        /// </summary>
        /// <param name="taller">Objeto donde se agregará el elemento</param>
        /// <param name="vehiculo">Objeto a agregar</param>
        /// <returns>Retorna el Taller con un nuevo Vehiculo</returns>
        public static Taller operator +(Taller taller, Vehiculo vehiculo)
        {
            if(taller.vehiculos.Count() < taller.espacioDisponible)
            {
                foreach (Vehiculo auxVehiculo in taller.vehiculos)
                {
                    if (auxVehiculo == vehiculo)
                    {
                        return taller;
                    }    
                }
                taller.vehiculos.Add(vehiculo);
            }
            return taller;
        }
        /// <summary>
        /// Quitará un elemento de la lista
        /// </summary>
        /// <param name="taller">Objeto donde se quitará el elemento</param>
        /// <param name="vehiculo">Objeto a quitar</param>
        /// <returns>Retorna el Taller, sin el elemento</returns>
        public static Taller operator -(Taller taller, Vehiculo vehiculo)
        {
            foreach (Vehiculo auxVehiculo in taller.vehiculos)
            {
                if (auxVehiculo == vehiculo)
                {
                    taller.vehiculos.Remove(vehiculo);
                    break;
                }
            }
            return taller;
        }
        #endregion
    }
}
