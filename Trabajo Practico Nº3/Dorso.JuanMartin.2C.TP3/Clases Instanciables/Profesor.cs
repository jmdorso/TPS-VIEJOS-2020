using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesAbstractas;
using Excepciones;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        #region Atributos
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor de Profesor
        /// </summary>
        public Profesor()
        {

        }

        /// <summary>
        /// Constructor de Profesor statico que inicializa el Random
        /// </summary>
        static Profesor()
        {
            random = new Random();
        }

        /// <summary>
        /// Constructor de Profesor que utiliza el de la base e instancia la cola y le asigna 2 clases randoms
        /// </summary>
        /// <param name="id">legajo a instanciar</param>
        /// <param name="nombre">nombre a instanciar</param>
        /// <param name="apellido">apellido a instanciar</param>
        /// <param name="dni">dni a instanciar</param>
        /// <param name="nacionalidad">nacionalidad a instanciar</param>
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id,nombre,apellido,dni,nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Agrega 2 clases randoms a la cola
        /// </summary>
        private void _randomClases()
        {
            int auxClase;

            for (int i = 0; i < 2; i++)
            {
                auxClase = random.Next(0, 3);
                this.clasesDelDia.Enqueue((Universidad.EClases)auxClase);
            }
        }

        /// <summary>
        /// Muestra los datos del Profesor
        /// </summary>
        /// <returns>Datos del Profesor en formato string</returns>
        protected override string MostrarDatos()
        {
            StringBuilder auxRetorno = new StringBuilder();

            auxRetorno.AppendFormat(base.MostrarDatos());
            auxRetorno.Append(ParticiparEnClase());

            return auxRetorno.ToString();
        }

        /// <summary>
        /// Muestra la cadena de las clases que tiene en el dia
        /// </summary>
        /// <returns>Retorna las clases que dicta en formato string</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder auxRetorno = new StringBuilder();

            auxRetorno.AppendLine($"CLASES DEL DÍA: ");

            foreach(Universidad.EClases auxClases in this.clasesDelDia)
            {
                auxRetorno.AppendLine(auxClases.ToString());
            }

            return auxRetorno.ToString();   
        }

        /// <summary>
        /// Hace publicos los datos del Profesor
        /// </summary>
        /// <returns>Retorna el metodo MostrarDatos</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Operadores

        /// <summary>
        /// Un Profesor sera igual a una clase si dicta esa clase
        /// </summary>
        /// <param name="i">Profesor a comparar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>True si se cumple la condicion, false sino se cumple</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool auxRetorno = false;

            foreach (Universidad.EClases auxClases in i.clasesDelDia)
            {
                if (auxClases == clase)
                {
                   auxRetorno = true;
                }
            }

            return auxRetorno;
        }

        /// <summary>
        /// Un Profesor sera distinto a una clase si NO dicta esa clase
        /// </summary>
        /// <param name="i">Profesor a comparar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>True si se cumple la condicion, false si no se cumple</returns>
        /// <returns></returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        #endregion

    }
}
