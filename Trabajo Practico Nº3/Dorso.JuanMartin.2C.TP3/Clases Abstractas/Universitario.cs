using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region Atributos
        private int legajo;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor de Universitario
        /// </summary>
        public Universitario()
        {
        }

        /// <summary>
        /// Constructor de Universitario que utiliza el de la base y le instancia el legajo
        /// </summary>
        /// <param name="legajo">legajo a instanciar</param>
        /// <param name="nombre">nombre a instanciar</param>
        /// <param name="apellido">apellido a instanciarse</param>
        /// <param name="dni">dni a instanciar</param>
        /// <param name="nacionalidad">nacionalidad a instanciar</param>
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Verifica que 2 objetos sean iguales"
        /// </summary>
        /// <param name="obj">objeto a analizar</param>
        /// <returns>Retorna true si cumple la condicion y false sino lo hace</returns>
        public override bool Equals(object obj)
        {
            
            return obj is Universitario; 
        }

        /// <summary>
        /// Muestra los datos de un Universitario
        /// </summary>
        /// <returns>Retorna los datos de un universitario en formato string</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder auxRetorno = new StringBuilder();

            auxRetorno.AppendFormat(base.ToString());
            auxRetorno.AppendLine($"LEGAJO NÚMERO: {this.legajo}");

            return auxRetorno.ToString();
        }

        /// <summary>
        /// Metodo abstracto a ser desarrollado en las clases derivadas
        /// </summary>
        /// <returns></returns>
        protected abstract string ParticiparEnClase();
        #endregion

        #region Operadores
        /// <summary>
        ///  Verifica si 2 universitarios son iguales mediante la condicion: "Dos Universitario serán iguales si y sólo si son del mismo Tipo y su Legajo o DNI son iguales.
        /// </summary>
        /// <param name="pg1">1er universitario a comparar</param>
        /// <param name="pg2">2do universitario a comparar</param>
        /// <returns>true si son iguales, false si no lo son</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool auxRetorno = false;

            if (pg1.Equals(pg2) && (pg1.DNI == pg2.DNI || pg1.legajo == pg2.legajo))
            {
                auxRetorno = true;
            }

            return auxRetorno;
        }
        /// <summary>
        /// Verifica si 2 universitarios son distintos (negando el ==)
        /// </summary>
        /// <param name="pg1">1er universitario a comparar</param>
        /// <param name="pg2">2do universitario a comparar</param>
        /// <returns>true si son distintos, false si no lo son</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }
        #endregion
    }
}
