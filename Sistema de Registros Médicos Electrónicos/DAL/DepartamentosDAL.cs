using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using Sistema_de_Registros_Médicos_Electrónicos.BLL;

namespace Sistema_de_Registros_Médicos_Electrónicos.DAL
{
    internal class DepartamentosDAL
    {
        conexionDAL conexion;

        public DepartamentosDAL() {

            conexion = new conexionDAL();
        }

        public bool Agregar(DepartamentoBLL oDepartamentosBLL){

            SqlCommand SQLComando = new SqlCommand("INSERT INTRO Departamentos VALUES(@Departamentos)");
            SQLComando.Parameters.Add("@Departamentos",SqlDbType.VarChar).Value = oDepartamentosBLL.Departamento;
            return conexion.EjecutarComandoSinRetornoDatos(SQLComando);

           //return conexion.EjecutarComandoSinRetornoDatos("INSERT INTO Departamentos (Departamento)\r\nVALUES('"+oDepartamentosBLL.Departamento +"')\r\n\t");
        }
        public bool Eliminar(DepartamentoBLL oDepartamentosBLL)
        {


            SqlCommand SQLComando = new SqlCommand("DELETE FROM Departamentos WHERE ID=@ID ");
            SQLComando.Parameters.Add("@ID", SqlDbType.Int).Value = oDepartamentosBLL.ID;
            return conexion.EjecutarComandoSinRetornoDatos(SQLComando);


            //conexion.EjecutarComandoSinRetornoDatos("DELETE FROM Departamentos WHERE ID="+oDepartamentosBLL.ID);

        }


        public bool Modificar(DepartamentoBLL oDepartamentosBLL)
        {
            SqlCommand SQLComando = new SqlCommand("UPDATE Departamento SET departamento=@Departamento WHERE ID=@ID ");
            SQLComando.Parameters.Add("@Departamento", SqlDbType.VarChar).Value = oDepartamentosBLL.ID;
            SQLComando.Parameters.Add("@ID", SqlDbType.Int).Value = oDepartamentosBLL.ID;

            return conexion.EjecutarComandoSinRetornoDatos(SQLComando);
        }

        public DataSet MostrarDepartamentos()
        {
            SqlCommand sentencia = new SqlCommand("SELECT * FROM Departamentos");

            return conexion.EjecutarSentencia(sentencia);
        }
    }
}
