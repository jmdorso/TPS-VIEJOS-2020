using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalzadoForm
{

    public partial class CargarDatos : Form
    {
        public CargarDatos()
        {
            InitializeComponent();
        }


        public string Talle
        {
            get
            {
                return textBoxTalle.Text;
            }
        }

        public string Precio
        {
            get
            {
                return textBoxPrecio.Text;
            }
        }

        private void buttonAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
