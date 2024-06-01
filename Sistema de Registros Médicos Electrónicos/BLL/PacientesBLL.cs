using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_Registros_Médicos_Electrónicos.BLL
{
    internal class PacientesBLL
    {
        public int ID { get; set; }
        public string NombrePaciente { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public int Departamentos { get; set; }
        public string Sintomas { get; set; }

        public byte[] FotoPaciente { get; set; }
    }
}
