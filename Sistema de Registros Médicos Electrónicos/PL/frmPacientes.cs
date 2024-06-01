using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema_de_Registros_Médicos_Electrónicos.DAL;
using Sistema_de_Registros_Médicos_Electrónicos.BLL;

namespace Sistema_de_Registros_Médicos_Electrónicos.PL
{
    public partial class frmPacientes : Form
    {

        byte[] imagenByte;

        public frmPacientes()
        {
            InitializeComponent();
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmPacientes_Load(object sender, EventArgs e)
        {
            DepartamentosDAL objDepartamentos = new DepartamentosDAL();

            cbxDepartamento.DataSource = objDepartamentos.MostrarDepartamentos().Tables[0];
            cbxDepartamento.DisplayMember = "departamento";
            cbxDepartamento.ValueMember = "ID";


        }

        private void cbxDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            OpenFileDialog selectorImagen = new OpenFileDialog();
            selectorImagen.Title = "Seleccionar imagen";

            if (selectorImagen.ShowDialog() == DialogResult.OK) { 

                picFoto.Image= Image.FromStream(selectorImagen.OpenFile());

                MemoryStream memoria = new MemoryStream();
                picFoto.Image.Save(memoria, System.Drawing.Imaging.ImageFormat.Png);

                imagenByte =memoria.ToArray();

            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            RecolectarDatos();
        }
        private void RecolectarDatos()
        {
            PacientesBLL objPacientes = new PacientesBLL();
            int codigoPaciente = 1;
            int.TryParse(txtID.Text, out codigoPaciente);

            objPacientes.ID = codigoPaciente;
            objPacientes.NombrePaciente= txtNOMBRE.Text;
            objPacientes.PrimerApellido = txtPRIMERA.Text;
            objPacientes.SegundoApellido = txtSEGUNDOA.Text;
            objPacientes.Sintomas = txtSINTOMAS.Text;

            int IDDepartamento = 0;
            int.TryParse(cbxDepartamento.SelectedValue.ToString(), out IDDepartamento);

            objPacientes.Departamentos = IDDepartamento;
            objPacientes.FotoPaciente = imagenByte;

        }
    }
}
