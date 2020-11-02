using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesAbstractas;
using Excepciones;

namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario  
    {
        #region Atributos
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        #endregion

        #region Enumerado
        /// <summary>
        /// Enumerado con el estado de la cuenta (Al dia, Deudor, Becado)
        /// </summary>
        public enum EEstadoCuenta { AlDia, Deudor, Becado }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor de Alumno
        /// </summary>
        public Alumno()
        {

        }

        /// <summary>
        /// Constructor de Alumno que utiliza el de la base y le agrega la clase que toma
        /// </summary>
        /// <param name="id">legajo a instanciar</param>
        /// <param name="nombre">nombre a instanciar</param>
        /// <param name="apellido">apellido a instanciar</param>
        /// <param name="dni">dni a instanciar</param>
        /// <param name="nacionalidad">nacionalidad a instanciar</param>
        /// <param name="claseQueToma">claseQueToma a instanciar</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : base(id,nombre,apellido,dni,nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Constructor de Alumno que reutiliza uno de esta misma clase y le agrega el estado de cuenta
        /// </summary>
        /// <param name="id">legajo a instanciar</param>
        /// <param name="nombre">nombre a instanciar</param>
        /// <param name="apellido">apellido a instanciar</param>
        /// <param name="dni">dni a instanciar</param>
        /// <param name="nacionalidad">nacionalidad a instanciar</param>
        /// <param name="claseQueToma">claseQueToma a instanciar</param>
        /// <param name="estadoCuenta">estado de cuenta a instanciar</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id,nombre,apellido,dni,nacionalidad,claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Muestra los datos del alumno
        /// </summary>
        /// <returns>Datos del alumno en formato string</returns>
        protected override string MostrarDatos()
        {
            StringBuilder auxRetorno = new StringBuilder();

            auxRetorno.AppendLine(base.MostrarDatos());
            auxRetorno.AppendLine($"ESTADO DE CUENTA: {this.estadoCuenta}");
            auxRetorno.AppendLine(ParticiparEnClase());

            return auxRetorno.ToString();
        }

        /// <summary>
        /// Muestra la cadena de la clase que toma
        /// </summary>
        /// <returns>Retorna la clase que toma en formato string</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder auxRetorno = new StringBuilder();

            auxRetorno.AppendFormat($"TOMA CLASE DE {this.claseQueToma.ToString()}");

            return auxRetorno.ToString();
        }

        /// <summary>
        /// Hace publicos los datos del Alumno
        /// </summary>
        /// <returns>Retorna el metodo MostrarDatos</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Operadores

        /// <summary>
        /// Un Alumno será igual a un EClase si toma esa clase y su estado de cuenta no es Deudor.
        /// </summary>
        /// <param name="a">Alumno a comparar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>True si se cumple la condicion, false sino se cumple</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            bool auxRetorno = false;

            if(a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                auxRetorno = true;
            }

            return auxRetorno;
        }

        /// <summary>
        /// Un Alumno será distinto a un EClase sólo si no toma esa clase.
        /// </summary>
        /// <param name="a">Alumno a comparar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>True si se cumple la condicion, false sino se cumple</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            bool auxRetorno = false;

            if (a.claseQueToma != clase)
            {
                auxRetorno = true;
            }

            return auxRetorno;
        }

        #endregion
    }
}
