using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Prototipo_1___SartorialSys.BL.BD;

namespace Prototipo_1___SartorialSys.Clases
{
    internal class Cliente
    {
        static string nombreTabla = "clientes_quito";
        internal static string[] buscarCliente(string parametroBusqueda)
        {
            string[] datosCliente = new string[7];
            string query = "SELECT * FROM " + nombreTabla + " WHERE cedula_cli = '" + parametroBusqueda+"'";

            try
            {
                var dbConnection = OracleDatabaseConnection.Instance;
                var connection = dbConnection.GetConnection();

                using (var cmd = new OracleCommand(query, connection))
                {
                    // Usar un adaptador para llenar un DataTable
                    using (var adapter = new OracleDataAdapter(cmd))
                    {
                        DataTable clientes = new DataTable();
                        adapter.Fill(clientes);
                        if (clientes.Rows.Count > 0)
                        {
                            DataRow row = clientes.Rows[0];

                            datosCliente[0] = row["cedula_cli"].ToString();
                            datosCliente[1] = row["nombres"].ToString();
                            datosCliente[2] = row["apellidos"].ToString();
                            datosCliente[3] = row["dir_domiciliaria"].ToString();
                            datosCliente[4] = row["email"].ToString();
                            datosCliente[5] = row["telefono"].ToString();
                            datosCliente[6] = row["canton"].ToString();
                        }
                    }
                }
            }
            catch (OracleException ex)
            {
                Console.WriteLine($"Error de base de datos: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                var dbConnection = OracleDatabaseConnection.Instance;
                dbConnection.CloseConnection();
            }
            return datosCliente;
        }

        internal static bool darDeBaja(string parametroBusqueda)
        {
           if (!Mensajes.confirmarAccion("¿Está seguro de eliminar a este cliente?"))
            {
                return false;
            }
            string query = "DELETE FROM "+nombreTabla+ " WHERE cedula_cli = :parametroBusqueda";
            try
            {
                var dbConnection = OracleDatabaseConnection.Instance;
                var connection = dbConnection.GetConnection();
                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter("idCliente", parametroBusqueda));
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Mensajes.emitirMensaje("Cliente eliminado correctamente.");
                        return true;
                    }
                }
            }
            catch (OracleException ex)
            {
                Console.WriteLine($"Error de base de datos: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                // Cerrar la conexión manualmente
                var dbConnection = OracleDatabaseConnection.Instance;
                dbConnection.CloseConnection();
            }
            return false;
        }

        internal static bool registrarCliente(string[] datosCliente)
        {
            string sql = "INSERT INTO " + nombreTabla + " (cedula_cli, nombres, apellidos, dir_domiciliaria, telefono, email, canton) " +
                "VALUES (:cedula, :nombres, :apellidos, :direccion, :telefono, :correo, :canton)";

            OracleConnection connection = null;
            try
            {
                // Obtener la instancia del Singleton
                var dbConnection = OracleDatabaseConnection.Instance;

                // Obtener la conexión
                connection = dbConnection.GetConnection();

                // Asegurarse de que la conexión esté abierta
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }

                // Crear el comando
                using (var cmd = new OracleCommand(sql, connection))
                {
                    // Agregar parámetros a la consulta
                    cmd.Parameters.Add(new OracleParameter("cedula", datosCliente[0]));
                    cmd.Parameters.Add(new OracleParameter("nombres", datosCliente[1]));
                    cmd.Parameters.Add(new OracleParameter("apellidos", datosCliente[2]));
                    cmd.Parameters.Add(new OracleParameter("direccion", datosCliente[3]));
                    cmd.Parameters.Add(new OracleParameter("telefono", datosCliente[4]));
                    cmd.Parameters.Add(new OracleParameter("correo", datosCliente[5]));
                    cmd.Parameters.Add(new OracleParameter("canton", datosCliente[6]));

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 1)
                    {
                        Mensajes.emitirMensaje("Dato registrado con éxito");
                        return true;
                    }
                }
            }
            catch (OracleException ex)
            {
                Mensajes.emitirMensaje($"Error de base de datos: {ex.Message}");
            }
            catch (Exception ex)
            {
                Mensajes.emitirMensaje($"Error: {ex.Message}");
            }
            finally
            {
                // Cerrar la conexión en el bloque finally para asegurarse de que se cierre
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return false;
        }



        internal static bool darDeAlta(string parametroBusqueda)
        {/*
            bool activo;
            using (conn = new SqlConnection(strConn))
            {
                conn.Open();
                strComm = "SELECT * FROM clientes WHERE cedula_cliente = '" + parametroBusqueda + "'";
                using (comm = new SqlCommand(strComm, conn))
                {
                    SqlDataReader rdr = comm.ExecuteReader();
                    rdr.Read();
                    activo = rdr.GetBoolean(6);
                }
            }
            if (activo)
            {
                Mensajes.emitirMensaje("Este cliente ya esta dado de alta");
                return false;
            }
            if (!Mensajes.confirmarAccion("¿Está  seguro de dar de alta a este cliente?"))
            {
                return false;
            }
            using (conn = new SqlConnection(strConn))
            {
                conn.Open();
                strComm = "UPDATE clientes SET activo = 1 WHERE cedula_cliente = " + parametroBusqueda;

                using (comm = new SqlCommand(strComm, conn))
                {
                    if (comm.ExecuteNonQuery() == 1)
                    {
                        Mensajes.emitirMensaje("Cliente dado de alta con éxito");
                    }
                }
            }*/
            return true;
        }

        internal static bool actualizarDireccion(string direccion, string parametroBusqueda)
        {
            string query = "UPDATE " + nombreTabla + " SET dir_domiciliaria = :direccion WHERE cedula_cli = :parametroBusqueda";

            try
            {
                var dbConnection = OracleDatabaseConnection.Instance;
                var connection = dbConnection.GetConnection();

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter("dir_domiciliaria", direccion));
                    cmd.Parameters.Add(new OracleParameter("cedula_cli", parametroBusqueda));

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Mensajes.emitirMensaje("Cliente actualizado correctamente.");
                        return true;
                    }
                }
            }
            catch (OracleException ex)
            {
                Console.WriteLine($"Error de base de datos: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                var dbConnection = OracleDatabaseConnection.Instance;
                dbConnection.CloseConnection();
            }
            return false;
        }

        internal static bool actualizarTelefono(string telefono, string parametroBusqueda)
        {
            string query = "UPDATE " + nombreTabla + " SET telefono = :telefono WHERE cedula_cli = :parametroBusqueda";

            try
            {
                var dbConnection = OracleDatabaseConnection.Instance;
                var connection = dbConnection.GetConnection();

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter("telefono", telefono));
                    cmd.Parameters.Add(new OracleParameter("cedula_cli", parametroBusqueda));

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Mensajes.emitirMensaje("Cliente actualizado correctamente.");
                        return true;
                    }
                }
            }
            catch (OracleException ex)
            {
                Console.WriteLine($"Error de base de datos: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                var dbConnection = OracleDatabaseConnection.Instance;
                dbConnection.CloseConnection();
            }
            return false;
        }

        internal static bool actualizarCorreo(string correo, string parametroBusqueda)
        {
            string query = "UPDATE " + nombreTabla + " SET email = :correo WHERE cedula_cli = :parametroBusqueda";

            try
            {
                var dbConnection = OracleDatabaseConnection.Instance;
                var connection = dbConnection.GetConnection();

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter("email", correo));
                    cmd.Parameters.Add(new OracleParameter("cedula_cli", parametroBusqueda));

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Mensajes.emitirMensaje("Cliente actualizado correctamente.");
                        return true;
                    }
                }
            }
            catch (OracleException ex)
            {
                Console.WriteLine($"Error de base de datos: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                var dbConnection = OracleDatabaseConnection.Instance;
                dbConnection.CloseConnection();
            }
            return false;
        }

        internal static bool actualizarNombres(string nuevoNombre, string cedula)
        {
            string query = "UPDATE "+nombreTabla+ " SET nombres = :nuevoNombre WHERE cedula_cli = :cedula";

            try
            {
                var dbConnection = OracleDatabaseConnection.Instance;
                var connection = dbConnection.GetConnection();

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter("nuevoNombre", nuevoNombre));
                    cmd.Parameters.Add(new OracleParameter("cedula", cedula));

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Mensajes.emitirMensaje("Cliente actualizado correctamente.");
                        return true;
                    }
                }
            }
            catch (OracleException ex)
            {
                Console.WriteLine($"Error de base de datos: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                var dbConnection = OracleDatabaseConnection.Instance;
                dbConnection.CloseConnection();
            }
            return false;
        }

        internal static bool actualizarApellidos(string apellidos, string parametroBusqueda)
        {
            string query = "UPDATE "+nombreTabla+ " SET apellidos = :apellidos WHERE cedula_cli = :parametroBusqueda";

            try
            {
                var dbConnection = OracleDatabaseConnection.Instance;
                var connection = dbConnection.GetConnection();

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter("apellidos", apellidos));
                    cmd.Parameters.Add(new OracleParameter("cedula_cli", parametroBusqueda));

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Mensajes.emitirMensaje("Cliente actualizado correctamente.");
                        return true;
                    }
                }
            }
            catch (OracleException ex)
            {
                Console.WriteLine($"Error de base de datos: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                var dbConnection = OracleDatabaseConnection.Instance;
                dbConnection.CloseConnection();
            }
            return false;
        }

        public static string getNombreTabla()
        {
            return nombreTabla;
        }
    }
}
