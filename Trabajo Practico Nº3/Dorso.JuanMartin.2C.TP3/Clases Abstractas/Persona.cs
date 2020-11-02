using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region Atributos
        private string apellido;
        private int dni;
        private ENacionalidad nacionalidad;
        private string nombre;
        #endregion

        #region Enumerado
        /// <summary>
        /// Enumerado con nacionalidad Argentina o Extranjera
        /// </summary>
        public enum ENacionalidad { Argentino, Extranjero}
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad de lectura/escritura que valida el Apellido
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Propiedad de lectura/escritura que valida el DNI
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                this.dni = ValidarDni(Nacionalidad, value);
            }
        }

        /// <summary>
        /// Propiedad de lectura/escritura para la Nacionalidad.
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura/escritura que valida el Nombre
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// Propiedad de lectura/escritura que valida el DNI como String
        /// </summary>
        public string StringToDni
        {
            set
            {
                this.dni = ValidarDni(this.Nacionalidad, value);
            }
        }
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor de persona
        /// </summary>
        public Persona()
        {

        }

        /// <summary>
        /// Constructor de persona que instancia mediante las propiedades, nombre, apellido y nacionalidad
        /// </summary>
        /// <param name="nombre">nombre a instanciar</param>
        /// <param name="apellido">apellido a instanciarse</param>
        /// <param name="nacionalidad">nacionalidad a instanciar</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor de persona que instancia mediante las propiedades, nombre, apellido, dni y nacionalidad. Reutiliza otro constructor.
        /// </summary>
        /// <param name="nombre">nombre a instanciar</param>
        /// <param name="apellido">apellido a instanciarse</param>
        /// <param name="dni">dni a instanciar</param>
        /// <param name="nacionalidad">nacionalidad a instanciar</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre,apellido,nacionalidad)
        {
            this.DNI = dni;
        }

        /// <summary>
        /// Constructor de persona que instancia mediante las propiedades, nombre, apellido, dni y nacionalidad. Reutiliza otro constructor.
        /// </summary>
        /// <param name="nombre">nombre a instanciar</param>
        /// <param name="apellido">apellido a instanciarse</param>
        /// <param name="dni">dni a instanciar</param>
        /// <param name="nacionalidad">nacionalidad a instanciar</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDni = dni;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Muestra los datos de la persona. 
        /// </summary>
        /// <returns>Devuelve la persona en forma de string</returns>
        public override string ToString()
        {
            StringBuilder auxRetorno = new StringBuilder();

            auxRetorno.AppendLine($"NOMBRE COMPLETO: {Apellido}, {Nombre}");
            auxRetorno.AppendLine($"NACIONALIDAD: {Nacionalidad}");
            auxRetorno.AppendLine("");

            return auxRetorno.ToString();
        }

        /// <summary>
        /// Valida el DNI mediante la nacionalidad y que coincidan en el rango numerico asignado
        /// </summary>
        /// <param name="nacionalidad">nacionalidad de la persona</param>
        /// <param name="dato">dni a validar</param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int auxDni = -1;

            switch(nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if(dato >= 1 && dato <= 89999999)
                    {
                        auxDni = dato;
                    }
                    else
                    {
                        throw new NacionalidadInvalidaException();
                    }
                    break;
                case ENacionalidad.Extranjero:
                    if (dato >= 90000000 && dato <= 99999999)
                    {
                        auxDni = dato;
                    }
                    else
                    {
                        throw new NacionalidadInvalidaException();
                    }
                    break;
                default:
                    throw new NacionalidadInvalidaException();
            }
            return auxDni;
        }
        /// <summary>
        /// Valida el dni por su formato, de numeros y como maximo 8 digitos
        /// </summary>
        /// <param name="nacionalidad">nacionalidad de la persona a verificar el dni</param>
        /// <param name="dato">dni a validar</param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int auxDni = -1;
            int parserDni;
            Regex regex = new Regex("[0-9]{1,8}");

            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if(regex.IsMatch(dato) && int.TryParse(dato, out parserDni))
                    {
                        auxDni = ValidarDni(nacionalidad, parserDni);
                    }
                    else
                    {
                        throw new DniInvalidoException("El dato ingresado es incorrecto, no tiene formato de DNI");
                    }
                    break;
                case ENacionalidad.Extranjero:
                    if (regex.IsMatch(dato) && int.TryParse(dato, out parserDni))
                    {
                        auxDni = ValidarDni(nacionalidad, parserDni);
                    }
                    else
                    {
                        throw new DniInvalidoException("El dato ingresado es incorrecto, no tiene formato de DNI");
                    }
                    break;
            }
            return auxDni;
        }

        /// <summary>
        /// Valida un nombre y apellido, mediante mayusculas, minusculas y vocales con tildes, "U"con dieresis y "Ñ"
        /// </summary>
        /// <param name="dato">nombre o apellido a validar</param>
        /// <returns>cadena vacia o nombre asignado</returns>
        private string ValidarNombreApellido(string dato)
        {
            string auxNombre = string.Empty;
            Regex regex = new Regex("[a-zA-ZÁÉÍÓÚÜÑáéíóúüñ]{2,20}");
            
            if(!(string.IsNullOrEmpty(dato))&&(regex.IsMatch(dato)))
            {
                auxNombre = dato;
            }
            return auxNombre;
        }
            
        #endregion
    }
}
