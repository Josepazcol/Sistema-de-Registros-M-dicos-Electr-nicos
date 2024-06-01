using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema_de_Registros_Médicos_Electrónicos.DAL;
using Sistema_de_Registros_Médicos_Electrónicos.BLL;

namespace Sistema_de_Registros_Médicos_Electrónicos.PL
{
    public partial class frmDepartamentos : Form
    {

        DepartamentosDAL oDepartamentosDAL;
        public frmDepartamentos()
        {
            oDepartamentosDAL = new DepartamentosDAL();
            InitializeComponent();
            LLegarGrid();
            LimpiarEntradas();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // obtener informacion 
           
       
            MessageBox.Show("Conectado .. ");
            oDepartamentosDAL.Agregar(RecuperarInformacion());
            LLegarGrid();
        }

        private DepartamentoBLL RecuperarInformacion()
        {
            DepartamentoBLL oDepartamentosBLL = new DepartamentoBLL();

            int ID = 0; int.TryParse(txtID.Text, out ID);

            oDepartamentosBLL.ID = ID;

            oDepartamentosBLL.Departamento = txtNombre.Text;

            return oDepartamentosBLL;
        }

        private void Seleccionar(object sender, DataGridViewCellMouseEventArgs e)
        {
            int indice = e.RowIndex;

            dgvDepartamentos.ClearSelection();

            if (indice>=0)
            {


            

            txtID.Text = dgvDepartamentos.Rows[indice].Cells[0].Value.ToString();
            txtNombre.Text = dgvDepartamentos.Rows[indice].Cells[1].Value.ToString();

            btnAgregar.Enabled = false;
            btnBorrar.Enabled = true;
            btnModificar.Enabled = true;
            btnCancelar.Enabled = true;

            }
        }

        private void dgvDepartamentos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            oDepartamentosDAL.Eliminar(RecuperarInformacion());
            LLegarGrid();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            oDepartamentosDAL.Modificar(RecuperarInformacion());
            LLegarGrid();
        }

        public void LLegarGrid()
        {
            dgvDepartamentos.DataSource = oDepartamentosDAL.MostrarDepartamentos().Tables[0];

            dgvDepartamentos.Columns[0].HeaderText = "ID";
            dgvDepartamentos.Columns[1].HeaderText = "Nombre Departamento";
        }
        public void LimpiarEntradas()
        {
            txtID.Text = "";
            txtNombre.Text = "";


            btnAgregar.Enabled = true;
            btnBorrar.Enabled = false;
            btnModificar.Enabled = false;
            btnCancelar.Enabled = false;
        }
    }
}
