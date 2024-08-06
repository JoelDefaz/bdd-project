using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototipo_1___SartorialSys.Clases
{
    internal class ConexionBaseDeDatos
    {
        // Conexión para la base de datos, de ser necesario cambiar el nombre de la base
        //const string CONEXION_BASE_DE_DATOS = "Data Source=(Local); database=SartorialSys; Integrated Security=SSPI";
        const string CONEXION_BASE_DE_DATOS = "Data Source=DESKTOP-E0733DQ\\MSSQLSERVER01;Initial Catalog=SartorialSys;Integrated Security=True;TrustServerCertificate=True";
        internal static string getConexion()
        {
            return CONEXION_BASE_DE_DATOS;
        }
    }
}