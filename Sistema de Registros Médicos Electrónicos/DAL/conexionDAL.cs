using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Sistema_de_Registros_Médicos_Electrónicos.DAL
{
    internal class conexionDAL
    {
        private string CadenaConexion = "Data Source=DESKTOP-2V3GRTC\\SQLEXPRESS; Initial Catalog=dbSistema; Integrated Security =True";
        SqlConnection Conexion;

        public SqlConnection EstablecerConexion()
        {

            this.Conexion = new SqlConnection(this.CadenaConexion);
            return this.Conexion;
        }
        // Metodo insert, Delete, update
        public bool EjecutarComandoSinRetornoDatos(string strCommando)
        {
            try
            {

                SqlCommand Comando = new SqlCommand();

                Comando.CommandText = "INSERT INTO Departamentos (departamento)\r\nVALUES('Operacion')\r\n\t ";
                Comando.Connection = this.EstablecerConexion();
                Conexion.Open();
                Comando.ExecuteNonQuery();
                Conexion.Close();
                return true;

            }
            catch
            {
                return false;
            }
        }
        //
        public bool EjecutarComandoSinRetornoDatos(SqlCommand SQLComando)
        {
            try
            {

                SqlCommand Comando =  SQLComando;
                Comando.Connection = this.EstablecerConexion();
                Conexion.Open();
                Comando.ExecuteNonQuery();
                Conexion.Close();
                return true;

            }
            catch
            {
                return false;
            }
        }

        //* Select (Retorno Datos)*/
        public DataSet EjecutarSentencia(SqlCommand sqlComando)
        {
            DataSet DS = new DataSet();
            SqlDataAdapter Adaptador = new SqlDataAdapter();

            try
            {
                SqlCommand Comando = new SqlCommand();
                Comando = sqlComando;
                Comando.Connection = EstablecerConexion();
                Adaptador.SelectCommand = Comando;
                Conexion.Open();
                Adaptador.Fill(DS);
                Conexion.Close();
                return DS;
            }
            catch
            {
                return DS;
            }
        }
    }
}
