using Archivos;
using Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace Entidades
{

    public class Empresa
    {
        private List<Calzado> calzados;

        private int limiteCalzados;

        private string nombre;
        private double gastos;
        private double ventas;
        private double ganancia;


        /// <summary>
        /// Propiedad lectura escritura de la lista de Calzados
        /// </summary>
        public List<Calzado> Calzados
        {
            get
            {
                return this.calzados;
            }
            set
            {
                this.calzados = value;
            }
        }

        /// <summary>
        /// Propiedad lectura escritura que calcula la ganancia
        /// </summary>
        public double Ganancia
        {
            get
            {
               return this.ganancia;
            }
            set
            {
                this.ganancia = this.ventas - this.gastos;
            }
        }
        
        /// <summary>
        /// propiedad lectura escritura del Nombre
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }

        /// <summary>
        /// propiedad lectura escritura de los gastos(compras de los calzados)
        /// </summary>
        public double Gastos
        {
            get
            {
                return this.gastos;
            }
            set
            {
                this.gastos = value;
            }
        }

        /// <summary>
        /// propedad lectura escritura de las ventas
        /// </summary>
        public double Ventas
        {
            get
            {
                return this.ventas;
            }
            set
            {
                this.ventas = value;
            }
        }

        /// <summary>
        /// Constructor sin argumentos inicializa la lista
        /// </summary>
        public Empresa()
        {
            this.calzados = new List<Calzado>();

        }

        /// <summary>
        /// Constructur con nombre y limite, que inicializa la ganancia, gastos, y ventas en 0. Asigna el nombre y limite e inicializa la lista
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="limiteCalzados"></param>
        public Empresa(string nombre,int limiteCalzados)
        {
            this.nombre = nombre;
            this.calzados = new List<Calzado>();
            this.limiteCalzados = limiteCalzados;
            this.ganancia = 0;
            this.gastos = 0;
            this.ventas = 0;
        }

        public Empresa(string nombre)
            : this(nombre, 10)
        {
        }




        /// <summary>
        /// Una empresa y calzado son iguales si ya se encuentra agregado en ella el producto. 
        /// </summary>
        /// <param name="empresa"></param>
        /// <param name="calzado"></param>
        /// <returns></returns>
        public static bool operator ==(Empresa empresa, Calzado calzado)
        {
            bool auxRetorno = false;

            if (empresa.calzados.Count >= 1)
            {
                foreach (Calzado auxCalzado in empresa.calzados)
                {
                    if (auxCalzado.Id == calzado.Id)
                    {
                        auxRetorno = true;
                    }
                }
            }


            return auxRetorno;
        }

        /// <summary>
        /// Son distintos sino se encuentra agregado el calzado en la empresa
        /// </summary>
        /// <param name="empresa"></param>
        /// <param name="calzado"></param>
        /// <returns></returns>
        public static bool operator !=(Empresa empresa, Calzado calzado)
        {
            return !(empresa == calzado);
        }

      
        /// <summary>
        /// Metodo generico que permite agregar calzado, botin o zapatilla a la empresa, si estos estan en STOCK. autoincrementa id
        /// e incrementa los gastos. Sino se puede, agrega exception.
        /// </summary>
        /// <typeparam name="GCalzado"></typeparam>
        /// <param name="empresa"></param>
        /// <param name="calzado"></param>
        /// <returns></returns>
        public bool SumarCalzado<GCalzado>(Empresa empresa, GCalzado calzado) 
            where GCalzado : Calzado
            
        {
            if ((empresa != calzado) && (calzado != null) && (empresa.calzados.Count<empresa.limiteCalzados) && (calzado.Estado == Calzado.EEstado.Stock))
            {
                calzado.Id = empresa.calzados.Count + 1;
                empresa.calzados.Add(calzado);
                empresa.gastos = empresa.gastos + calzado.PrecioCompra;
                return true;

            }
            else
            {
                throw new AgregarCalzadoException();
            }
        }

        /// <summary>
        /// Genera una venta, mediante el ID(UTILIZAR FUNCION BUSCARID) y modifica el estado del calzado, incrementa el atributo
        /// ventas e incrementa en 1 el limite de calzados, ya que se vendio un producto. Sino lanza exception
        /// </summary>
        /// <param name="empresa"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool GenerarVenta(Empresa empresa, int id) 
        {
            //Factura factura = new Factura
            bool auxRetorno = false;
            int auxId = empresa.BuscarPorId(empresa, id);
            if (id >= 0)
            {
                foreach (Calzado calzado in empresa.calzados)
                {
                    if (calzado == empresa.calzados[auxId] && calzado.Estado == Calzado.EEstado.Stock)
                    {
                        empresa.calzados[auxId].Estado = Calzado.EEstado.Vendido;
                        empresa.ventas += empresa.calzados[auxId].PrecioVenta;
                        empresa.limiteCalzados += 1;
                        auxRetorno = true;
                    }
                }
            }
            else
            {
                throw new VentaInvalidaException();
            }
            return auxRetorno;
        }


        /// <summary>
        /// Muestra el calzado en stock
        /// </summary>
        /// <returns></returns>
        public string MostrarCalzadoEnStock()
        {
            StringBuilder auxRetorno = new StringBuilder();

            auxRetorno.AppendLine("\tCALZADO EN STOCK");
            foreach (Calzado calzado in this.calzados)
            {
                if(calzado.Estado == Calzado.EEstado.Stock)
                {
                    auxRetorno.Append(calzado.Etiqueta());
                    
                }
    
            }

            return auxRetorno.ToString();
        }

        /// <summary>
        /// Muestra el calzado vendido
        /// </summary>
        /// <returns></returns>
        public string MostrarCalzadoVendido()
        {
            StringBuilder auxRetorno = new StringBuilder();

            auxRetorno.AppendLine("\tNUESTRAS VENTAS");
            foreach (Calzado calzado in this.calzados)
            {
                if (calzado.Estado == Calzado.EEstado.Vendido)
                {
                    auxRetorno.Append(calzado.Etiqueta());
                }

            }

            return auxRetorno.ToString();
        }

        /// <summary>
        /// Guarda la empresa en xml en el escritrio mediante un nombre en especifico
        /// </summary>
        /// <param name="empresa"></param>
        /// <param name="nombreArchivo"></param>
        /// <returns></returns>
        public static bool GuardarXml(Empresa empresa,string nombreArchivo)
        {
            bool auxSeGuardo = false;
            Xml<Empresa> xml = new Xml<Empresa>();

            auxSeGuardo = xml.Guardar(nombreArchivo, empresa);

            return auxSeGuardo;
        }

        /// <summary>
        /// Lee la empresa en xml
        /// </summary>
        /// <returns></returns>
        public static Empresa LeerXml()
        {
            Empresa auxEmpresa;
            Xml<Empresa> xml = new Xml<Empresa>();

            xml.Leer("Empresa.xml", out auxEmpresa);

            return auxEmpresa;
        }

        /// <summary>
        /// Guarda la empresa en Texto en el escritrio mediante un nombre especifico
        /// </summary>
        /// <param name="empresa"></param>
        /// <param name="nombreArchivo"></param>
        /// <returns></returns>
        public static bool GuardarTexto(Empresa empresa, string nombreArchivo)
        {
            bool auxSeGuardo = false;
            Texto texto = new Texto();

            auxSeGuardo = texto.Guardar(nombreArchivo, empresa.ToString());

            return auxSeGuardo;
        }

        /// <summary>
        /// Lee un archivo de texto
        /// </summary>
        /// <returns></returns>
        public static string LeerTexto(string nombreArchivo)
        {
            string auxEmpresa = string.Empty;
            Texto texto = new Texto();

            texto.Leer(nombreArchivo, out auxEmpresa);

            return auxEmpresa;
        }

        /// <summary>
        /// Busca por ID un calzado y devuelve la posicion en la lista. 
        /// </summary>
        /// <param name="empresa"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public  int BuscarPorId(Empresa empresa, int id)
        {
            int auxRetorno = -1;
            Calzado calzado1;

            foreach(Calzado calzado in empresa.calzados)
            {
                if(calzado.Id == id)
                {
                    calzado1 = calzado;
                    auxRetorno = empresa.calzados.IndexOf(calzado1);
                    break;
                }
            }

            return auxRetorno;
        }

        /// <summary>
        /// Muestra el nombre de la empresa y sus calzados (sean vendidos o en stock)
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder auxRetorno = new StringBuilder();

            auxRetorno.AppendLine($"\t{this.nombre}");
            auxRetorno.AppendLine("------------------------------");

            foreach (Calzado calzado in this.calzados)
            {
                auxRetorno.Append(calzado.Etiqueta());
            }

            return auxRetorno.ToString();
        }

        /// <summary>
        /// Muestra la info interna de la empresa, con su limite, ganancia, etc.
        /// </summary>
        /// <returns></returns>
        public string MostrarInfoEmpresa()
        {
            StringBuilder auxRetorno = new StringBuilder();

            auxRetorno.AppendLine($"\n\t|||||| INFORMACION DE NUESTRA EMPRESA ||||||");
            auxRetorno.AppendLine($"\t\t{this.nombre}");
            auxRetorno.AppendLine("------------------------------\n");
            auxRetorno.AppendLine($"\tEn este momento contamos con espacio para {this.limiteCalzados} calzados");
            if(this.calzados.Count > 0)
            {
                auxRetorno.AppendLine($"\tNuestros productos en sistema son los siguientes:\n");
                foreach (Calzado calzado in this.calzados)
                {
                    auxRetorno.AppendLine(calzado.InformacionClasificada());
                }
                auxRetorno.AppendLine($"La empresa compro productos por $ {this.gastos} y vendio por $ {this.ventas}");
                auxRetorno.AppendLine($"Ganancia: ${this.Ganancia = this.ventas - this.gastos}");
                auxRetorno.AppendLine($"\n\t\t-----MUCHAS GRACIAS-----\n");
            }
            else
            {
                auxRetorno.AppendLine($"\tAún no tenemos productos en sistema.\n");
                auxRetorno.AppendLine($"\n\t\t-----MUCHAS GRACIAS-----\n");
            }

            
            return auxRetorno.ToString();
        }

    }
}
