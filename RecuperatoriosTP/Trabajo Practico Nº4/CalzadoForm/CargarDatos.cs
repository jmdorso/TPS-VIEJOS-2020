using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                MessageBox.Show("No se pudo ingresar precio o talle (verifique que sean numeros y esten dentro del rango). Reingrese");
            }
           else
            {
                this.Close();
            }

        }

        /// <summary>
        /// Verifica los datos de los textbox
        /// </summary>
        /// <returns></returns>
        internal  bool verificarDatos()
        {
            bool auxRetorno = false;
            Regex regex = new Regex("[0-9]{2,20}");

            if (!string.IsNullOrEmpty(textBoxPrecio.Text) || !string.IsNullOrEmpty(textBoxTalle.Text) )
            {
                if(regex.IsMatch(textBoxPrecio.Text) && regex.IsMatch(textBoxTalle.Text))
                { 
                    double auxPrecio = Convert.ToDouble(Precio);
                    int auxTalle = Convert.ToInt32(Talle);
                    if (auxTalle >= 30 && auxTalle <= 46 && auxPrecio >= 3000)
                    {
                        auxRetorno = true;
                    }
                }
            }

            return auxRetorno;
        }
    }
}
