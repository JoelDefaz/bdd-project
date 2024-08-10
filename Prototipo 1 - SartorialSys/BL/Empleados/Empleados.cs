using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using Prototipo_1___SartorialSys.BL.BD;

namespace Prototipo_1___SartorialSys.Clases
{
    internal class Empleados
    {
        static string nombreTabla = "empleados_1";

        internal static string getNombreTabla()
        {
            return nombreTabla;
        }

        internal static bool registrarEmpleado(string[] datosCliente)
        {
            string sql = "INSERT INTO " + nombreTabla + " (CEDULA_EMPLEADO, NOMBRES, APELLIDOS, DIR_DOMICILIARIA, EMAIL, SALARIO, HORA_ENTRADA,HORA_ALMUERZO,HORA_SALIDA) " +
    "VALUES (:cedula, :nombres, :apellidos, :direccion, :email, :salario, :hora_entrada, :hora_almuerzo, :hora_salida)";
            OracleConnection connection = null;
            try
            {
                var dbConnection = OracleDatabaseConnection.Instance;
                connection = dbConnection.GetConnection();
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }

                // Crear el comando
                using (var cmd = new OracleCommand(sql, connection))
                {
                    cmd.Parameters.Add(new OracleParameter("cedula", datosCliente[0]));
                    cmd.Parameters.Add(new OracleParameter("nombres", datosCliente[1]));
                    cmd.Parameters.Add(new OracleParameter("apellidos", datosCliente[2]));
                    cmd.Parameters.Add(new OracleParameter("direccion", datosCliente[3]));
                    cmd.Parameters.Add(new OracleParameter("email", datosCliente[4]));
                    cmd.Parameters.Add(new OracleParameter("salario", datosCliente[5]));
                    cmd.Parameters.Add(new OracleParameter("hora_entrada", datosCliente[6]));
                    cmd.Parameters.Add(new OracleParameter("hora_almuerzo", datosCliente[7]));
                    cmd.Parameters.Add(new OracleParameter("hora_salida", datosCliente[8]));

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 1)
                    {
                        Mensajes.emitirMensaje("Empleado registrado con éxito");
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
                if (connection != null && connection.State == System.Data.ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            return false;
        }

        public static string[] buscarEmpleado(string cedula)
        {
            string[] datosEmpleados = new string[9];
            string query = "SELECT * FROM " + nombreTabla + " WHERE cedula_empleado = '" + cedula + "'";

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

                            datosEmpleados[0] = row["nombres"].ToString();
                            datosEmpleados[1] = row["apellidos"].ToString();
                            datosEmpleados[2] = row["dir_domiciliaria"].ToString();
                            datosEmpleados[3] = row["email"].ToString();
                            datosEmpleados[4] = row["salario"].ToString();
                            datosEmpleados[5] = row["hora_entrada"].ToString();
                            datosEmpleados[6] = row["hora_almuerzo"].ToString();
                            datosEmpleados[7] = row["hora_salida"].ToString();

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
            return datosEmpleados;
        }

        internal static bool eliminar(string cedula)
        {
            if (!Mensajes.confirmarAccion("¿Está seguro de eliminar a este empleado?"))
            {
                return false;
            }
            string query = "DELETE FROM " + nombreTabla + " WHERE cedula_empleado = :cedula";
            try
            {
                var dbConnection = OracleDatabaseConnection.Instance;
                var connection = dbConnection.GetConnection();
                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter("cedula_empleado", cedula));
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Mensajes.emitirMensaje("Empleado eliminado correctamente.");
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

        internal static bool actualizarNombre(string nombre, string cedula)
        {
            string query = "UPDATE " + nombreTabla + " SET nombres = :nombre WHERE cedula_empleado = :cedula";

            try
            {
                var dbConnection = OracleDatabaseConnection.Instance;
                var connection = dbConnection.GetConnection();

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter("nombres", nombre));
                    cmd.Parameters.Add(new OracleParameter("cedula_empleado", cedula));

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Mensajes.emitirMensaje("Empleado actualizado correctamente.");
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

        internal static bool actualizarApellido(string valor, string cedula)
        {
            string query = "UPDATE " + nombreTabla + " SET apellidos = :valor WHERE cedula_empleado = :cedula";

            try
            {
                var dbConnection = OracleDatabaseConnection.Instance;
                var connection = dbConnection.GetConnection();

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter("apellidos", valor));
                    cmd.Parameters.Add(new OracleParameter("cedula_empleado", cedula));

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Mensajes.emitirMensaje("Empleado actualizado correctamente.");
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

        internal static bool actualizarDireccion(string valor, string cedula)
        {
            string query = "UPDATE " + nombreTabla + " SET DIR_DOMICILIARIA = :valor WHERE cedula_empleado = :cedula";

            try
            {
                var dbConnection = OracleDatabaseConnection.Instance;
                var connection = dbConnection.GetConnection();

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter("DIR_DOMICILIARIA", valor));
                    cmd.Parameters.Add(new OracleParameter("cedula_empleado", cedula));

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Mensajes.emitirMensaje("Empleado actualizado correctamente.");
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

        internal static bool actualizarCorreo(string valor, string cedula)
        {
            string query = "UPDATE " + nombreTabla + " SET email = :valor WHERE cedula_empleado = :cedula";

            try
            {
                var dbConnection = OracleDatabaseConnection.Instance;
                var connection = dbConnection.GetConnection();

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter("email", valor));
                    cmd.Parameters.Add(new OracleParameter("cedula_empleado", cedula));

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Mensajes.emitirMensaje("Empleado actualizado correctamente.");
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

        internal static bool actualizarSalario(string valor, string cedula)
        {
            string query = "UPDATE " + nombreTabla + " SET salario = :valor WHERE cedula_empleado = :cedula";

            try
            {
                var dbConnection = OracleDatabaseConnection.Instance;
                var connection = dbConnection.GetConnection();

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter("salario", valor));
                    cmd.Parameters.Add(new OracleParameter("cedula_empleado", cedula));

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Mensajes.emitirMensaje("Empleado actualizado correctamente.");
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

        internal static bool actualizarEntrada(string valor, string cedula)
        {
            string query = "UPDATE " + nombreTabla + " SET hora_entrada = :valor WHERE cedula_empleado = :cedula";

            try
            {
                var dbConnection = OracleDatabaseConnection.Instance;
                var connection = dbConnection.GetConnection();

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter("hora_entrada", valor));
                    cmd.Parameters.Add(new OracleParameter("cedula_empleado", cedula));

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Mensajes.emitirMensaje("Empleado actualizado correctamente.");
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

        internal static bool actualizarAlmuerzo(string valor, string cedula)
        {
            string query = "UPDATE " + nombreTabla + " SET hora_almuerzo = :valor WHERE cedula_empleado = :cedula";

            try
            {
                var dbConnection = OracleDatabaseConnection.Instance;
                var connection = dbConnection.GetConnection();

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter("hora_almuerzo", valor));
                    cmd.Parameters.Add(new OracleParameter("cedula_empleado", cedula));

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Mensajes.emitirMensaje("Empleado actualizado correctamente.");
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

        internal static bool actualizarSalida(string valor, string cedula)
        {
            string query = "UPDATE " + nombreTabla + " SET hora_salida = :valor WHERE cedula_empleado = :cedula";

            try
            {
                var dbConnection = OracleDatabaseConnection.Instance;
                var connection = dbConnection.GetConnection();

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter("hora_salida", valor));
                    cmd.Parameters.Add(new OracleParameter("cedula_empleado", cedula));

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Mensajes.emitirMensaje("Empleado actualizado correctamente.");
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
    }
}