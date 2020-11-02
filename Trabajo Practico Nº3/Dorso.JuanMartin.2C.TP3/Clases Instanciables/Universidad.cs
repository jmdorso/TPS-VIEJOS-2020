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
    public class Universidad
    {
        #region Atributos
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        #endregion

        #region Enumerado
        /// <summary>
        /// Enumerado con las clases.
        /// </summary>
        public enum EClases { Programacion, Laboratorio, Legislacion, SPD}
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad Lectura/Escritura para Alumnos
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
        /// Propiedad Lectura/Escritura para Profesores
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }

        /// <summary>
        /// Propiedad Lectura/Escritura para Jornadas
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }

        /// <summary>
        /// Propiedad Lectura/Escritura accediendo desde un indexador
        /// </summary>
        /// <param name="i">indexador</param>
        /// <returns></returns>
        public Jornada this[int i]
        {
            get
            {
                if (i >= 0 && i < this.Jornadas.Count)
                {
                    return this.Jornadas[i];
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (i >= this.Jornadas.Count)
                {
                    this.Jornadas.Add(value);
                }
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de Universidad que iniciliza las listas de alumnos, profesores y jornadas
        /// </summary>
        public Universidad()
        {
            this.alumnos = new List<Alumno>();
            this.profesores = new List<Profesor>();
            this.jornada = new List<Jornada>();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Guardar de clase serializará los datos del Universidad en un XML, incluyendo todos los datos de sus Profesores, Alumnos y Jornadas..
        /// </summary>
        /// <param name="uni">Universidad a serializar</param>
        /// <returns>true si se pudo guardar, false si no se pudo</returns>
        public static bool Guardar(Universidad uni)
        {
            bool auxSeGuardo = false;
            Xml<Universidad> xml = new Xml<Universidad>();
            
            auxSeGuardo = xml.Guardar("Universidad.xml", uni);

            return auxSeGuardo;
        }

        /// <summary>
        /// Lee la universidad serializada
        /// </summary>
        /// <returns>Leer de clase retornará un Universidad con todos los datos previamente serializados.</returns>
        public static Universidad Leer()
        {
            Universidad auxUniversidad;
            Xml<Universidad> xml = new Xml<Universidad>();

            xml.Leer("Universidad.xml", out auxUniversidad);

            return auxUniversidad;
        }

        /// <summary>
        /// Muestra todos los datos de la universidad
        /// </summary>
        /// <param name="uni">universidad a mostrar</param>
        /// <returns>la universidad en formato string</returns>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder auxRetorno = new StringBuilder();

            auxRetorno.AppendLine("JORNADA:");
            foreach (Jornada auxJornada in uni.Jornadas)
            {
                auxRetorno.AppendLine(auxJornada.ToString());
            }

            return auxRetorno.ToString();
        }

        /// <summary>
        /// Hace publicos los datos de la Universidad
        /// </summary>
        /// <returns>Retorna el metodo MostrarDatos</returns>
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }
        #endregion

        #region Operadores

        /// <summary>
        /// Un Universidad será igual a un Alumno si el mismo está inscripto en él.
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="a">Alumno a comparar</param>
        /// <returns>True si se cumple la condicion, false sino se cumple</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool estaInscripto = false;

            foreach(Alumno auxAlumno in g.Alumnos)
            {
                if(auxAlumno == a)
                {
                    estaInscripto = true;
                    break;
                }
            }

            return estaInscripto;
        }

        /// <summary>
        /// Seran distintos si no esta inscripto en ella
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="a">Alumno a comparar</param>
        /// <returns>True si se cumple la condicion, false sino se cumple</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        /// <summary>
        /// Un Universidad será igual a un Profesor si el mismo está dando clases en él.
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="i">Profesor a comparar</param>
        /// <returns>True si se cumple la condicion, false sino se cumple</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            bool estaDandoClase = false;

            foreach(Profesor auxProfesor in g.Instructores)
            {
                if(auxProfesor == i)
                {
                    estaDandoClase = true;
                }
            }

            return estaDandoClase;
        }

        /// <summary>
        /// Un universidad sera distinta a un Profesor si el mismo NO esta dando clases en él.
        /// </summary>
        /// <param name="g">Universidad a comparar</param>
        /// <param name="i">Profesor a comparar</param>
        /// <returns>True si se cumple la condicion, false sino se cumple</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        /// <summary>
        /// La igualación entre un Universidad y una Clase retornará el primer Profesor capaz de dar esa clase.
        /// </summary>
        /// <param name="u">Universidad a comparar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>El primer profesor capaz de dar la clase, si no se cumple se lanza una exception</returns></returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach(Profesor auxProfesor in u.Instructores)
            {
                if(auxProfesor == clase)
                {
                    return auxProfesor;
                }
            }
            throw new SinProfesorException();
        }

        /// <summary>
        /// El distinto retornará el primer Profesor que no pueda dar la clase.
        /// </summary>
        /// <param name="u">Universidad a comparar</param>
        /// <param name="clase">Clase a comparar</param>
        /// <returns>El primer profesor que no puede dar la clase o NUll</returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            Profesor auxRetorno = null;

            foreach(Profesor auxProfesor in u.Instructores)
            {
                if(auxProfesor != clase)
                {
                    auxRetorno = auxProfesor;
                    break;
                }
            }
            return auxRetorno;
        }

        /// <summary>
        /// Agrega una clase, generando y agregando una jornada con un profesor que pueda dar dicha clase y alumnos que la toman
        /// </summary>
        /// <param name="g">Universidad a agregarle la clase</param>
        /// <param name="clase">Clase a agregar en la Universidad</param>
        /// <returns>Una Universidad</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            Jornada auxJornada = new Jornada(clase, (g == clase));

            foreach(Alumno auxAlumno in g.alumnos)
            {
                if(auxAlumno == clase)
                {
                    auxJornada += auxAlumno;
                }
            }
            g.Jornadas.Add(auxJornada);

            return g;
        }

        /// <summary>
        /// Se agregarán Alumnos mediante el operador +, validando que no estén previamente  cargados.
        /// </summary>
        /// <param name="u">Universidad en la que se va a agregar el Alumno</param>
        /// <param name="a">Alumno a agregar</param>
        /// <returns>Una universidad o una exception si ya se encuentra en la Universidad</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.Alumnos.Add(a);
                return u;
            }
            throw new AlumnoRepetidoException();

        }

        /// <summary>
        /// Se agregarán Profesores mediante el operador +, validando que no estén previamente cargados.
        /// </summary>
        /// <param name="u">Universidad en la que se va a agregar el Alumno</param>
        /// <param name="i">Profesor a agregar</param>
        /// <returns>Una universidad</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if(u != i)
            {
                u.Instructores.Add(i);
            }

            return u;
        }
        #endregion
    }
}
