using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvParcial2.Config
{
    internal class conexion
    {
        private readonly string varconexion = "Server=localhost\\SQLEXPRESS;Database=EvParcial2;Trusted_Connection=True";
        public SqlConnection obtenerConexion()
        {
            return new SqlConnection(varconexion);
        }
    }
}
