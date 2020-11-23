using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Entidades;

namespace CalzadoForm
{
    public partial class EmpresaDeCalzado : Form
    {
        CalzadosDAO calzadosDAO = new CalzadosDAO();
        static Empresa empresaBotin = new Empresa("Botines BD", 500);
        static Empresa empresaZapatilla = new Empresa("Zapatillas BD", 500);
          
        public EmpresaDeCalzado()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Carga en nuestras empresas las tablas de la BD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmpresaDeCalzado_Load(object sender, EventArgs e)
        {
            empresaBotin = calzadosDAO.ListarBotines();
            empresaZapatilla = calzadosDAO.ListarZapatillas();
        }


        /// <summary>
        /// Lista mediante otro form, la empresa detallada.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnListarBotin_Click(object sender, EventArgs e)
        {

            MostrarDatos mostrarDatos = new MostrarDatos(empresaBotin);
            DialogResult dialogResult = mostrarDatos.ShowDialog();
        }

        /// <summary>
        /// Lista mediante otro form, la empresa detallada.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnListarZapa_Click(object sender, EventArgs e)
        {
            MostrarDatos mostrarDatos = new MostrarDatos(empresaZapatilla);
            DialogResult dialogResult = mostrarDatos.ShowDialog();
        }

        /// <summary>
        /// Agrega un elemento, solo indicandole precio y talle, el resto se genera mediante numeros randoms y descripcion generica
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregarZapa_Click(object sender, EventArgs e)
        {
            CargarDatos cargarDatos = new CargarDatos();
            DialogResult dialogResult = cargarDatos.ShowDialog();
            int talle;
            int.TryParse(cargarDatos.Talle, out talle);
            double precioCompra;
            double.TryParse(cargarDatos.Precio, out precioCompra);

            Random random = new Random();
            int randomOrigen = random.Next(0, 1);
            int randomMarca = random.Next(0, 4);
            int randomTipo = random.Next(0, 2);

            Zapatilla zapatilla = new Zapatilla((Calzado.EOrigen)randomOrigen, precioCompra, talle, "PRODUCTO ALEATORIO",
                (Calzado.EMarca)randomMarca, (Zapatilla.ETipoZapatilla)randomTipo);
            empresaZapatilla.SumarCalzado<Zapatilla>(empresaZapatilla, zapatilla);
        }

        /// <summary>
        /// Agrega un elemento, solo indicandole precio y talle, el resto se genera mediante numeros randoms y descripcion generica
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregarBotin_Click(object sender, EventArgs e)
        {
            CargarDatos cargarDatos = new CargarDatos();
            DialogResult dialogResult = cargarDatos.ShowDialog();
            int talle;
            int.TryParse(cargarDatos.Talle, out talle);
            double precioCompra;
            double.TryParse(cargarDatos.Precio, out precioCompra);

            Random random = new Random();
            int randomOrigen = random.Next(0, 1);
            int randomMarca = random.Next(0, 4);
            int randomTipo = random.Next(0, 2);

            Botin botin = new Botin((Calzado.EOrigen)randomOrigen, precioCompra, talle, "PRODUCTO ALEATORIO",
                (Calzado.EMarca)randomMarca, (Botin.ETipoBotin)randomTipo);
            empresaBotin.SumarCalzado<Botin>(empresaBotin, botin);
        }
        /// <summary>
        /// Vende botines con precio venta superior a 12mil
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVenderBotin_Click(object sender, EventArgs e)
        {
            foreach(Botin botin in empresaBotin.Calzados)
            {
                if(botin.PrecioVenta >= 12000)
                {
                    empresaBotin.GenerarVenta(empresaBotin, botin.Id);
                    
                }
            }
            MessageBox.Show("Vendemos todos los botines con un valor de venta superior a $12mil.");
        }

        /// <summary>
        /// Vende zapatillas con precio venta superior a 12mil
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVenderZapa_Click(object sender, EventArgs e)
        {
              foreach (Zapatilla zapatilla in empresaZapatilla.Calzados)
                {
                    if (zapatilla.PrecioVenta >= 12000)
                    {
                        empresaBotin.GenerarVenta(empresaZapatilla, zapatilla.Id);

                    }
                }
                MessageBox.Show("Vendemos todas las zapatillas con un valor de venta superior a $12mil.");
            
        }

        /// <summary>
        /// Guarda en 2 archivos de texto diferentes, la info de cada empresa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmpresaDeCalzado_FormClosing(object sender, FormClosingEventArgs e)
        {
            Empresa.GuardarTexto(empresaZapatilla, "EmpresaZapatilla.txt");
            Empresa.GuardarTexto(empresaBotin, "EmpresaBotin.txt");
        }
    }
}
