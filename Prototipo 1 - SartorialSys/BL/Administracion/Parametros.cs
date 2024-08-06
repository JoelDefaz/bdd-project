using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototipo_1___SartorialSys.Clases
{
    internal class Parametros
    {
        static string strConn = ConexionBaseDeDatos.getConexion();
        static string strComm = null;
        static SqlConnection conn = null;
        static SqlCommand comm = null;

        internal static bool actualizarParametro(string nombre, string[] datos)
        {
            using (conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    strComm = "UPDATE parametros SET valor = " + datos[0] + ", fecha_actualizacion = '" + datos[1] + "'" +
                        " WHERE nombre = '" +nombre+"'";
                    using (comm = new SqlCommand(strComm, conn))
                        if (comm.ExecuteNonQuery() == 1)
                        {
                            Mensajes.emitirMensaje("Parámetro actualizado con éxito");
                        }
                }
                catch (SqlException ex)
                {
                    // Se captura la excepción específica de SQL Server
                    if (ex.Number == 2627 || ex.Number == 2601)
                    {
                        // Manejar el error de duplicado
                        Mensajes.emitirMensaje("Parámetro ya registrado en el Sistema");
                        return false;
                    }
                    else
                    {
                        Mensajes.emitirMensaje("Error al actualizar");
                        return false;
                    }
                }
            }
            return true;
        }

        internal static decimal getIVA()
        {
          /*
                using (conn = new SqlConnection(strConn))
                {
                    conn.Open();
                    strComm = "SELECT valor FROM parametros WHERE nombre = 'IVA'";
                    using (comm = new SqlCommand(strComm, conn))
                    {
                        SqlDataReader rdr = comm.ExecuteReader();
                        rdr.Read();
                        return rdr.GetDecimal(0);
                    }
                }
            */
            return 12;
        }

        internal static string getParametro(string text)
        {
            using (conn = new SqlConnection(strConn))
            {
                conn.Open();
                strComm = "SELECT valor FROM parametros WHERE nombre = '"+text+"'";
                using (comm = new SqlCommand(strComm, conn))
                {
                    SqlDataReader rdr = comm.ExecuteReader();
                    rdr.Read();
                    if (!rdr.HasRows)
                    {
                        Mensajes.emitirMensaje("Parámetro no registrado en el Sistema");
                        return "";
                    }
                    return rdr.GetDecimal(0).ToString();
                }
            }
        }

        internal static string[] getParametroBusqueda(string text)
        {
            string[] datos = new string[2];
            using (conn = new SqlConnection(strConn))
            {
                conn.Open();
                strComm = "SELECT valor,fecha_actualizacion FROM parametros WHERE nombre = '" + text + "'";
                using (comm = new SqlCommand(strComm, conn))
                {
                    SqlDataReader rdr = comm.ExecuteReader();
                    rdr.Read();
                    if (!rdr.HasRows)
                    {
                        Mensajes.emitirMensaje("Parámetro no registrado en el Sistema");
                        return null;
                    }
                    datos[0] = rdr.GetDecimal(0).ToString();
                    datos[1] = rdr.GetDateTime(1).ToString();
                    return datos;
                }
            }
        }

        internal static bool registrarParametro(string[] nuevoParametro)
        {
            using (conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    strComm = "INSERT INTO parametros VALUES('" + nuevoParametro[0] + "'," + nuevoParametro[1] + ",'" + nuevoParametro[2] + "','" + nuevoParametro[2]+"')";
                    using (comm = new SqlCommand(strComm, conn))
                        if (comm.ExecuteNonQuery() == 1)
                        {
                            Mensajes.emitirMensaje("Parámetro registrado con éxito");
                        }
                }
                catch (SqlException ex)
                {
                    // Se captura la excepción específica de SQL Server
                    if (ex.Number == 2627 || ex.Number == 2601)
                    {
                        // Manejar el error de duplicado
                        Mensajes.emitirMensaje("Parámetro ya registrado en el Sistema");
                        return false;
                    }
                    else
                    {
                        Mensajes.emitirMensaje("Error al registrar");
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
