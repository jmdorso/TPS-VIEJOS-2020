using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private static double Operar(string numero1, string numero2, string operador)
        {
            double valorRetorno;

            Numero numeroAux1 = new Numero(numero1);
            Numero numeroAux2 = new Numero(numero2);

            valorRetorno = Calculadora.Operar(numeroAux1, numeroAux2, operador);

            return valorRetorno;

        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            if (this.cmbOperador.SelectedItem == null)
            {
                this.cmbOperador.Text = "+";
            }
            lblResultado.Text = FormCalculadora.Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text).ToString();
        }

        private void Limpiar()
        {
            this.txtNumero1.Text = String.Empty;
            this.txtNumero2.Text = String.Empty;
            this.cmbOperador.Text = String.Empty;
            this.lblResultado.Text = String.Empty;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if(this.lblResultado.Text != String.Empty && this.lblResultado.Text != "Valor Invalido")
            {
                this.lblResultado.Text = Numero.DecimalBinario(this.lblResultado.Text);
            }
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (this.lblResultado.Text != String.Empty && this.lblResultado.Text != "Valor Invalido")
            {
                this.lblResultado.Text = Numero.BinarioDecimal(this.lblResultado.Text);
            }
        }
    }
}
