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

namespace CalzadoForm
{
    public partial class MostrarDatos : Form
    {
        public MostrarDatos(Empresa empresa)
        {
            InitializeComponent();
            richTextBox.Text = empresa.MostrarInfoEmpresa();
        }
    }
}
