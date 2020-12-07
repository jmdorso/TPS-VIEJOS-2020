using Archivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Zapatilla : Calzado
    {
        private ETipoZapatilla tipoZapatilla;

        public enum ETipoZapatilla { Running, Moda, Sport}

        /// <summary>
        /// Constructor sin argumentos
        /// </summary>
        public Zapatilla()
        {

        }

        /// <summary>
        /// Constructor SIN ID, que se autoincrementara. Utiliza el de la base
        /// </summary>
        /// <param name="origen"></param>
        /// <param name="precioCompra"></param>
        /// <param name="talle"></param>
        /// <param name="descripcion"></param>
        /// <param name="marca"></param>
        /// <param name="tipoZapatilla"></param>
        public Zapatilla(EOrigen origen, double precioCompra, int talle, string descripcion, EMarca marca, ETipoZapatilla tipoZapatilla)
            : base(origen, precioCompra, talle, descripcion, marca)
        {
            this.tipoZapatilla = tipoZapatilla;
        }

        /// <summary>
        /// Constructor CON ID. Utiliza el de la base
        /// </summary>
        /// <param name="id"></param>
        /// <param name="origen"></param>
        /// <param name="precioCompra"></param>
        /// <param name="talle"></param>
        /// <param name="descripcion"></param>
        /// <param name="marca"></param>
        /// <param name="tipoZapatilla"></param>
        public Zapatilla(int id, EOrigen origen, double precioCompra, int talle, string descripcion, EMarca marca, ETipoZapatilla tipoZapatilla)
            : base(id, origen, precioCompra, talle, descripcion, marca)
        {
            this.tipoZapatilla = tipoZapatilla;
        }

        /// <summary>
        /// Sobreescribe al metodo de la base
        /// </summary>
        /// <returns></returns>
        public override string Etiqueta()
        {
            StringBuilder auxRetorno = new StringBuilder();


            auxRetorno.AppendLine($"\tZapatilla de {this.tipoZapatilla}");
            auxRetorno.AppendLine(base.Etiqueta());

            return auxRetorno.ToString();
        }

        /// <summary>
        /// Guarda en formato xml una zapatilla.
        /// </summary>
        /// <param name="zapatilla"></param>
        /// <param name="nombreArchivo"></param>
        /// <returns></returns>
        public static bool GuardarXml(Zapatilla zapatilla, string nombreArchivo)
        {
            bool auxSeGuardo = false;
            Xml<Zapatilla> xml = new Xml<Zapatilla>();

            auxSeGuardo = xml.Guardar(nombreArchivo, zapatilla);

            return auxSeGuardo;
        }
    }
}
