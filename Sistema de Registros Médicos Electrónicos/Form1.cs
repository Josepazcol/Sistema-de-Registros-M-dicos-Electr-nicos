using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema_de_Registros_Médicos_Electrónicos.PL;

namespace Sistema_de_Registros_Médicos_Electrónicos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmDepartamentos formularioDepartamentos = new frmDepartamentos();
            formularioDepartamentos.Show();
        }

        private void btnPacientes_Click(object sender, EventArgs e)
        {
            frmPacientes formularioPacientes = new frmPacientes();
            formularioPacientes.Show();
        }
    }
}
