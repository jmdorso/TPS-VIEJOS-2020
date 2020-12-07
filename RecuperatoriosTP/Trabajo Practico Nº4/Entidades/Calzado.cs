using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Archivos;
using Exceptions;

namespace Entidades
{

    public abstract class Calzado
    {
        #region Atributos
        private int id;
        private double precioCompra;
        private double precioVenta;
        private int talle;
        private string descripcion;
        private EMarca marca;
        private EOrigen origen;
        private EEstado estado;


        public enum EMarca { Adidas, Nike, Puma, Umbro, Reebok}
        public enum EOrigen { Nacional, Importado}
        public enum EEstado { Stock, Vendido}

        #endregion

        #region Propiedades

        /// <summary>
        /// Lectura y Escritura del ID
        /// </summary>
        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }
        /// <summary>
        /// Lectura y Escritura (con validacion) del Precio Compra
        /// </summary>
        public double PrecioCompra
        {
            get
            {
                return this.precioCompra;
            }
            set
            {
                this.precioCompra = ValidarPrecioCompra(value);
            }
        }

        /// <summary>
        /// Lectura-Escritura del precio de venta, mediante validacion.
        /// </summary>
        public double PrecioVenta
        {
            get
            {
                return this.precioVenta;
            }
            set
            {
                this.precioVenta = ValidarPrecioVenta(value);
            }
        }

        /// <summary>
        /// Lectura escritura mediante validacion
        /// </summary>
        public int Talle
        {
            get
            {
                return this.talle;
            }
            set
            {
                this.talle = ValidarTalle(value);
            }
        }

        /// <summary>
        /// Lectura escritura mediante validacion
        /// </summary>
        public string Descripcion
        {
            get 
            {
                return this.descripcion;
            }
            set
            {
                this.descripcion = ValidarDescripcion(value);
            }
        }

        /// <summary>
        /// Lectura-escritura
        /// </summary>
        public EMarca Marca
        {
            get
            {
                return this.marca;
            }
            set
            {
                this.marca = value; 
            }
        }

        /// <summary>
        /// Lectura-escritura
        /// </summary>
        public EOrigen Origen
        {
            get
            {
                return this.origen;
            }
            set
            {
                this.origen = value;
            }
        }

        /// <summary>
        /// Lectura-escritura
        /// </summary>
        public EEstado Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }

        }

        /// <summary>
        /// Retorna el 35% a aplicar a los productos importados
        /// </summary>
        public double PorcentajeImpuestoImportacion
        {
            get
            {
                if (this.Origen == EOrigen.Importado)
                {
                    return 0.35;
                }
                else
                {
                    return 0;
                }

            }
        }

        /// <summary>
        /// retorna el 40% a aplicar de ganancia 
        /// </summary>
        public double PorcentajeGanancia
        {
            get
            {
                
                {
                    return 0.40;
                }
            }
        }
        #endregion

        /// <summary>
        /// Constructor sin argumentos
        /// </summary>
        public Calzado()
        {
        }

        /// <summary>
        /// Constructor SIN ID, que se autoincrementara. El estado siempre es en STOCK y el precio venta se calcula a partir del precio compra
        /// </summary>
        /// <param name="origen"></param>
        /// <param name="precioCompra"></param>
        /// <param name="talle"></param>
        /// <param name="descripcion"></param>
        /// <param name="marca"></param>
        public Calzado( EOrigen origen, double precioCompra, int talle, string descripcion, EMarca marca)
        {
            //this.Id = id;
            this.Origen = origen;
            this.PrecioCompra = precioCompra;
            this.Talle = talle;
            this.Descripcion = descripcion;
            this.Marca = marca;
            this.Estado = EEstado.Stock;
            this.PrecioVenta = precioCompra;
        }

        /// <summary>
        /// Constructor CON ID. Reutiliza el propio
        /// </summary>
        /// <param name="id"></param>
        /// <param name="origen"></param>
        /// <param name="precioCompra"></param>
        /// <param name="talle"></param>
        /// <param name="descripcion"></param>
        /// <param name="marca"></param>
        public Calzado(int id,EOrigen origen, double precioCompra, int talle, string descripcion, EMarca marca)
            : this(origen,precioCompra,talle,descripcion,marca)
        {
            this.Id = id;
        }



        /// <summary>
        /// Valida que la descripcion conste entre 2 y 100 caracteres y permita mayusculas, minusculas, acentos y dieresis en la U, ademas de la ñ
        /// </summary>
        /// <param name="descripcion"></param>
        /// <returns></returns>
        private string ValidarDescripcion(string descripcion)
        {
            string auxDescipcion = string.Empty;
            Regex regex = new Regex("[a-zA-ZÁÉÍÓÚÜÑáéíóúüñ]{2,100}");

            if (!(string.IsNullOrEmpty(descripcion)) && (regex.IsMatch(descripcion)))
            {
                auxDescipcion = descripcion;
            }
            return auxDescipcion;
        }

        /// <summary>
        /// valida que el talle sea entre 30 y 46, sino lanza exception
        /// </summary>
        /// <param name="talle"></param>
        /// <returns></returns>
        private int ValidarTalle(int talle)
        {
            int auxTalle;

            if(talle >= 30 && talle <= 46)
            {
                auxTalle = talle;
            }
            else
            {
                throw new TalleInvalidoException();
            }

            return auxTalle;
        }

        /// <summary>
        /// valida que el precio de compra siempre sea mayor a 3mil, agregandole el impuesto a la importacion si es necesario. Sino lanza exception
        /// </summary>
        /// <param name="precio"></param>
        /// <returns></returns>
        private double ValidarPrecioCompra(double precio)
        {
            double auxPrecio;

            if (precio >= 3000 && this.Origen == EOrigen.Importado)
            {
                auxPrecio = precio + (precio * PorcentajeImpuestoImportacion);
            }
            else if (precio >= 3000 && this.Origen == EOrigen.Nacional)
            {
                auxPrecio = precio;
            }
            else
            {
                throw new PrecioInvalidoException();
            }

            return auxPrecio;
        }

        /// <summary>
        /// Valida el precio de venta, sumandole el porcentaje de ganancia y le vuelve a sumar el procentaje de importacion 
        /// (para recuperar lo que se pago). Sino lanza exception
        /// </summary>
        /// <param name="precio"></param>
        /// <returns></returns>
        private double ValidarPrecioVenta(double precio)
        {
            double auxPrecio;

            if(precio >= 3000 && this.Origen == EOrigen.Importado)
            {
                auxPrecio = precio + (precio * PorcentajeGanancia) + (precio * PorcentajeImpuestoImportacion);
            }
            else if(precio >= 3000 && this.Origen == EOrigen.Nacional)
            {
                auxPrecio = precio + (precio * PorcentajeGanancia);
            }
            else
            {
                throw new PrecioInvalidoException();
            }

            return auxPrecio;
        }


        /// <summary>
        /// Dos calzados son iguales si tienen mismo ID y mismo tipo
        /// </summary>
        /// <param name="calzadoUno"></param>
        /// <param name="calzadoDos"></param>
        /// <returns></returns>
        public static bool operator ==(Calzado calzadoUno, Calzado calzadoDos)
        {
            bool auxRetorno = false;

            if (calzadoUno.Equals(calzadoDos) && (calzadoUno.Id == calzadoDos.Id))
            {
                auxRetorno = true;
            }

            return auxRetorno;
        }

        /// <summary>
        /// Dos calzados son distintos si NO tienen mismo ID y mismo tipo
        /// </summary>
        /// <param name="calzadoUno"></param>
        /// <param name="calzadoDos"></param>
        /// <returns></returns>
        public static bool operator !=(Calzado calzadoUno, Calzado calzadoDos)
        {
            return !(calzadoUno == calzadoDos);
        }

        /// <summary>
        /// Etiqueta de producto para mostrar al publico 
        /// </summary>
        /// <returns></returns>
        public virtual string Etiqueta()
        {
            StringBuilder auxRetorno = new StringBuilder();

            auxRetorno.AppendLine($"\t{this.Marca} | ID del producto: {this.Id}");
            auxRetorno.AppendLine($"\t$ {this.PrecioVenta}");
            auxRetorno.AppendLine($"\tTalle: {this.Talle}");
            auxRetorno.AppendLine($"\t{this.Descripcion}");
            auxRetorno.AppendLine($"\tProducto {this.Origen}");
            if(this.Estado == EEstado.Vendido)
            {
                auxRetorno.AppendLine($"\n\tVENDIDO");
            }
            else
            {
                auxRetorno.AppendLine($"\n\tEN STOCK");
            }
            auxRetorno.Append("------------------------------");

            return auxRetorno.ToString();

        }

        /// <summary>
        /// Este metodo nos muestra la informacion para uso interno, mostrandonos cuanto pagamos por el producto
        /// a cuanto lo vendemos y mediante el metodo de extension, mostramos la ganancia que obtenemos en caso de venderlo.
        /// </summary>
        /// <returns></returns>
        internal string InformacionClasificada()
        {
            StringBuilder auxRetorno = new StringBuilder();

            auxRetorno.Append(this.Etiqueta());
            auxRetorno.AppendLine($"Este calzado fue comprado por: $ {this.PrecioCompra}");
            auxRetorno.AppendLine($"Su precio de venta es: $ {this.PrecioVenta}");
            auxRetorno.AppendLine($"En cuanto se genere la venta nos deja un saldo favorable de: $ {this.precioCompra.GananciaTotalDelCalzado(PrecioVenta)}");
            auxRetorno.AppendLine("------------------------------");

            return auxRetorno.ToString();
        }


    }

}
