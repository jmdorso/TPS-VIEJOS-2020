using Entidades;
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
           if(!verificarDatos())
            {
                MessageBox.Show("No se pudo ingresar precio o talle. Ingrese");
            }
           else
            {
                this.Close();
            }

        }

        internal  bool verificarDatos()
        {
            bool auxRetorno = false;
            

            if(!string.IsNullOrEmpty(textBoxPrecio.Text) || !string.IsNullOrEmpty(textBoxTalle.Text))
            {
                double auxPrecio = Convert.ToDouble(Precio);
                int auxTalle = Convert.ToInt32(Talle);
                if (auxTalle >= 30 && auxTalle <= 46 && auxPrecio >= 3000)
                {
                    auxRetorno = true;
                }
            }

            return auxRetorno;
        }
    }
}
