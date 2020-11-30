using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace CalzadoForm
{
    public partial class VenderEmpresaZapatillas : Form
    {
        Thread hilo;
        EmpresaDeCalzado empresaDeCalzado;
        public VenderEmpresaZapatillas()
        {
            InitializeComponent();

            this.empresaDeCalzado = new EmpresaDeCalzado();
            this.empresaDeCalzado.vendiZapatilla += AgregarItem;
            this.hilo = new Thread(this.empresaDeCalzado.VenderZapatillas);
            this.hilo.Start();

        }
        /// <summary>
        /// Agrega venta 1 x 1 a la list box
        /// </summary>
        /// <param name="calzado"></param>
        public void AgregarItem(Calzado calzado)
        {
            if (listBoxVentas.InvokeRequired)
            {
                Vendido vendido = new Vendido(AgregarItem);
                this.Invoke(vendido, new object[] { calzado });
            }
            else
            {
                listBoxVentas.Items.Add("ID #" + calzado.Id + "\tMarca: " + calzado.Marca + "\tPrecio venta: $ " + calzado.PrecioVenta +
                    "\tTalle: " + calzado.Talle + "\t\t" + calzado.Estado);
            }

        }
        /// <summary>
        /// Al cerrar el form, aborta el hilo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Venta1x1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.hilo.Abort();
        }
    }
}
