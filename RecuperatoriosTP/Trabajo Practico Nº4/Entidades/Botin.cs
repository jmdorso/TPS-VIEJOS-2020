using Archivos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Botin : Calzado
    {
        ETipoBotin tipoBotin;

        public enum ETipoBotin { Cesped, Sintetico, Pista }

        /// <summary>
        /// Constructor sin argumentos
        /// </summary>
        public Botin()
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
        /// <param name="tipoBotin"></param>
        public Botin(EOrigen origen, double precioCompra, int talle, string descripcion, EMarca marca, ETipoBotin tipoBotin)
            : base( origen, precioCompra, talle, descripcion, marca)
        {
            this.tipoBotin = tipoBotin;
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
        /// <param name="tipoBotin"></param>
        public Botin(int id, EOrigen origen, double precioCompra, int talle, string descripcion, EMarca marca, ETipoBotin tipoBotin)
            : base(id, origen, precioCompra, talle, descripcion, marca)
        {
            this.tipoBotin = tipoBotin;
        }

        /// <summary>
        /// Sobreescribe al metodo de la base
        /// </summary>
        /// <returns></returns>
        public override string Etiqueta()
        {
            StringBuilder auxRetorno = new StringBuilder();

            auxRetorno.AppendLine($"\tBotin de {this.tipoBotin}");
            auxRetorno.AppendLine(base.Etiqueta());
            

            return auxRetorno.ToString();
        }

        /// <summary>
        /// Guardar en formato xml botines
        /// </summary>
        /// <param name="botin"></param>
        /// <param name="nombreArchivo"></param>
        /// <returns></returns>
        public static bool GuardarXml(Botin botin, string nombreArchivo)
        {
            bool auxSeGuardo = false;
            Xml<Botin> xml = new Xml<Botin>();

            auxSeGuardo = xml.Guardar(nombreArchivo, botin);

            return auxSeGuardo;
        }
    }
}
