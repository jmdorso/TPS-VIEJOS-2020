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
using System.Threading;

namespace CalzadoForm
{
    public delegate void Vendido(Calzado calzado);
    public partial class EmpresaDeCalzado : Form
    {
        CalzadosDAO calzadosDAO = new CalzadosDAO();
        static Empresa empresaBotin = new Empresa("Botines BD", 500);
        static Empresa empresaZapatilla = new Empresa("Zapatillas BD", 500);
        Thread hilo;
        public event Vendido vendiBotin;
        public event Vendido vendiZapatilla;
        
        public EmpresaDeCalzado()
        {
            InitializeComponent();
            this.vendiBotin += this.VentaBotin;
            this.vendiZapatilla += this.VentaZapatilla;
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
            if (empresaZapatilla.Calzados.Count > 0)
            {
                MessageBox.Show("SE LEVANTARON LOS DATOS DE LA BD CORRECATAMENTE", "TODO OK", MessageBoxButtons.OK);
            }

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
            if(!cargarDatos.verificarDatos())
            {
                MessageBox.Show("No se cargaron los datos");
            }
            else
            {
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
                Zapatilla.GuardarXml(zapatilla, "Zapatilla.xml");
            }

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
            if (!cargarDatos.verificarDatos())
            {
                MessageBox.Show("No se cargaron los datos");
            }
            else
            {
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
                Botin.GuardarXml(botin, "Botin.xml");
            }

        }
        /// <summary>
        /// Vende botines con precio venta superior a 12mil
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVenderBotin_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vamos a vender todos los botines con un valor de venta superior a $12mil.");
            VenderEmpresaBotines mostrarDatosVenta = new VenderEmpresaBotines();

            DialogResult dialogResult = mostrarDatosVenta.ShowDialog();
            VenderBotines();

            MessageBox.Show("Productos vendidos");
            /*foreach (Botin botin in empresaBotin.Calzados)
            {
                if(botin.PrecioVenta >= 12000)
                {
                    //empresaBotin.GenerarVenta(empresaBotin, botin.Id);
                    this.vendiBotin.Invoke(botin);
                }
            }
            MessageBox.Show("Vendemos todos los botines con un valor de venta superior a $12mil.");*/
        }

        /// <summary>
        /// Vende zapatillas con precio talle mayor o igual a 40
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVenderZapa_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vamos a vender todas las zapatillas con un talle mayor o igual a 40");
            VenderEmpresaZapatillas mostrarDatosVenta = new VenderEmpresaZapatillas();

            DialogResult dialogResult = mostrarDatosVenta.ShowDialog();
            VenderZapatillas();

            MessageBox.Show("Productos vendidos");


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

        /// <summary>
        /// Manejador del evento
        /// </summary>
        /// <param name="calzado"></param>
        public void VentaBotin(Calzado calzado)
        {
            empresaBotin.GenerarVenta(empresaBotin, calzado.Id);
            Thread.Sleep(50);
        }

        /// <summary>
        /// invoca el evento y le da la condicion a la hora de vender
        /// </summary>
        public void VenderBotines()
        {

            foreach (Botin botin in empresaBotin.Calzados)
            {

                if (botin.PrecioVenta >= 12000)
                {
                    //empresaBotin.GenerarVenta(empresaBotin, botin.Id);
                    
                    this.vendiBotin.Invoke(botin);
                    
                }
            }
        }

        /// <summary>
        /// Manejador del evento
        /// </summary>
        /// <param name="calzado"></param>
        public void VentaZapatilla(Calzado calzado)
        {
            empresaZapatilla.GenerarVenta(empresaZapatilla, calzado.Id);
            Thread.Sleep(50);
        }


        /// <summary>
        /// invoca el evento y le da la condicion a la hora de vender
        /// </summary>
        public void VenderZapatillas()
        {

            foreach (Zapatilla zapatilla in empresaZapatilla.Calzados)
            {

                if (zapatilla.Talle >= 40)
                {
                    this.vendiZapatilla.Invoke(zapatilla);
                }
            }
        }
    }
}
