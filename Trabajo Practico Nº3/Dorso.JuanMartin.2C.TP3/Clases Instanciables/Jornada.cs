using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntidadesAbstractas;
using Excepciones;
using Archivos;
    
namespace Clases_Instanciables
{
    public class Jornada
    {
        #region Atributos
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad Lectura/Escritura para alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        /// <summary>
        /// Propiedad Lectura/Escritura para las clases
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        /// <summary>
        /// Propiedad Lectura/Escritura para instructor
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor de Jornada que iniciliza la lista de Alumno
        /// </summary>
        private Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Constructor de Jornada que iniciliza la clase y el instructor. Ademas reutiliza el otro constructor de la clase
        /// </summary>
        /// <param name="clase">clase a instanciar</param>
        /// <param name="instructor">instructor a instanciar</param>
        public Jornada(Universidad.EClases clase, Profesor instructor)
            : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Guardar de clase guardará los datos de la Jornada en un archivo de texto.
        /// </summary>
        /// <param name="jornada">Jornada a guardar</param>
        /// <returns>true si se pudo guardar, false si no se pudo</returns>
        public static bool Guardar(Jornada jornada)
        {
            bool auxSeGuardo = false;
            Texto texto = new Texto();

            auxSeGuardo = texto.Guardar("Jornada.txt", jornada.ToString());

            return auxSeGuardo;
        }

        /// <summary>
        /// Leer de clase retornará los datos de la Jornada como texto.
        /// </summary>
        /// <returns>retorna en formato string los datos</returns>
        public static string Leer()
        {
            string auxJornada = string.Empty;
            Texto texto = new Texto();

            texto.Leer("Jornada.txt", out auxJornada);

            return auxJornada;  
        }

        /// <summary>
        /// Muestra los datos de la jornada
        /// </summary>
        /// <returns>datos de la jornada en formato string</returns>
        public override string ToString()
        {
            StringBuilder auxRetorno = new StringBuilder();

            auxRetorno.AppendLine($"CLASE DE {this.clase.ToString()} POR {this.instructor.ToString()}");
            auxRetorno.AppendLine("ALUMNOS: ");

            foreach(Alumno auxAlumno in this.alumnos)
            {
                auxRetorno.AppendLine(auxAlumno.ToString());
            }
            auxRetorno.AppendLine("<------------------------------------------------>");

            return auxRetorno.ToString();
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Agregar Alumnos a la clase por medio del operador +, validando que no estén previamente cargados.
        /// </summary>
        /// <param name="j">jornada en donde se agregara el alumno</param>
        /// <param name="a">alumno a agregar</param>
        /// <returns>la jornada con el alumno ingresado si se pudo o la jornada como fue pasada al metodo</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if(j != a)
            {
                j.alumnos.Add(a);
            }

            return j;
        }

        /// <summary>
        /// Una Jornada será igual a un Alumno si el mismo participa de la clase.
        /// </summary>
        /// <param name="j">jornada a comparar</param>
        /// <param name="a">alumno a comparar</param>
        /// <returns>Retorna true si son iguales, false si no lo son</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool auxRetorno = false;

            foreach(Alumno auxAlumno in j.alumnos)
            {
                if(auxAlumno == a)
                {
                    auxRetorno = true;
                }
            }

            return auxRetorno;
        }

        /// <summary>
        /// Devuelve si una jornada y un alumno son distintos (no deberia participar ya de la clase)
        /// </summary>
        /// <param name="j">jornada a comparar</param>
        /// <param name="a">alumno a comparar</param>
        /// <returns>Retorna true si son distintos, false si no lo son</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        #endregion

    }
}
