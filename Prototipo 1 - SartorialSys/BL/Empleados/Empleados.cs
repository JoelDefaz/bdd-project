using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototipo_1___SartorialSys.Clases
{
    internal class Empleados
    {
        static string strConn = ConexionBaseDeDatos.getConexion();
        static string strComm = null;
        static SqlConnection conn = null;
        static SqlCommand comm = null;
        internal static bool registrarEmpleado(string[] datosCliente)
        {
            using (conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    strComm = getComandoRegistro(datosCliente);
                    using (comm = new SqlCommand(strComm, conn))
                        if (comm.ExecuteNonQuery() == 1)
                        {
                            Mensajes.emitirMensaje("Empleado registrado con éxito");
                            return true;
                        }
                }
                catch (SqlException ex)
                {
                    // Se captura la excepción específica de SQL Server
                    if (ex.Number == 2627 || ex.Number == 2601)
                    {
                        // Manejar el error de duplicado
                        Mensajes.emitirMensaje("Empleado ya registrado en el sistema");
                        return false;
                    }
                    else
                    {
                        Mensajes.emitirMensaje("Error de base de datos");
                        return false;
                    }
                }
            }
            return false;
        }

        private static string getComandoRegistro(string[] datosCliente)
        {
            return "INSERT INTO empleados VALUES('" + datosCliente[0] +"','" + datosCliente[1] +"','" + datosCliente[2] + "','" + datosCliente[3] +"'," +
                "'" + datosCliente[4] + "','" + datosCliente[5] + "'," + datosCliente[6] + ",'" + datosCliente[7]+"','" + datosCliente[8] + "','"+ datosCliente[9] +"'," +
                "'" + datosCliente[10] + "',(SELECT CONVERT(date, CURRENT_TIMESTAMP) AS FechaActual),DEFAULT);";
        }
    }
}