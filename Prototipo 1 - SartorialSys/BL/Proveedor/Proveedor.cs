using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Documents;
using Oracle.ManagedDataAccess.Client;
using Prototipo_1___SartorialSys.BL.BD;
using Prototipo_1___SartorialSys.Clases;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Prototipo_1___SartorialSys.BL.Proveedor
{
    [RunInstaller(true)]
    public partial class Proveedor : System.Configuration.Install.Installer
    {
        public Proveedor()
        {
            InitializeComponent();
        }

        static string nombreTabla = "proveedores_quito";

        internal static bool registrarCliente(string[] datosProveedor)
        {
            string sql = "INSERT INTO " + nombreTabla + " (ruc, nombre, direccion, telefono, email, tipo_proveedor, sucursal) " +
    "VALUES (:ruc, :nombre, :direccion, :telefono, :email, :tipo_proveedor, :sucursal)";


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
                    cmd.Parameters.Add(new OracleParameter("ruc", datosProveedor[0]));
                    cmd.Parameters.Add(new OracleParameter("nombre", datosProveedor[1]));
                    cmd.Parameters.Add(new OracleParameter("direccion", datosProveedor[2]));
                    cmd.Parameters.Add(new OracleParameter("telefono", datosProveedor[3]));
                    cmd.Parameters.Add(new OracleParameter("email", datosProveedor[4]));
                    cmd.Parameters.Add(new OracleParameter("tipo_proveedor", datosProveedor[5]));
                    cmd.Parameters.Add(new OracleParameter("sucursal", datosProveedor[6]));

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

        internal static string getNombreTabla()
        {
            return nombreTabla;
        }

        public static string[] buscarProveedor(string ruc)
        {
            string[] datosCliente = new string[7];
            string query = "SELECT * FROM " + nombreTabla + " WHERE ruc = '" + ruc + "'";
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

                            datosCliente[0] = row["ruc"].ToString();
                            datosCliente[1] = row["nombre"].ToString();
                            datosCliente[2] = row["direccion"].ToString();
                            datosCliente[3] = row["telefono"].ToString();
                            datosCliente[4] = row["email"].ToString();
                            datosCliente[5] = row["tipo_proveedor"].ToString();
                            datosCliente[6] = row["sucursal"].ToString();
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

        public static bool eliminar(string ruc)
        {
            if (!Mensajes.confirmarAccion("¿Está seguro de eliminar a este cliente?"))
            {
                return false;
            }
            string query = "DELETE FROM " + nombreTabla + " WHERE ruc = :ruc";
            try
            {
                var dbConnection = OracleDatabaseConnection.Instance;
                var connection = dbConnection.GetConnection();
                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter("ruc", ruc));
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

        internal static bool actualizarNombre(string nombre, string ruc)
        {
            string query = "UPDATE " + nombreTabla + " SET nombre = :nombre WHERE ruc = :ruc";

            try
            {
                var dbConnection = OracleDatabaseConnection.Instance;
                var connection = dbConnection.GetConnection();

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter("nombre", nombre));
                    cmd.Parameters.Add(new OracleParameter("ruc", ruc));

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Mensajes.emitirMensaje("Proveedor actualizado correctamente.");
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

        internal static bool actualizarDireccion(string direccion, string ruc)
        {
            string query = "UPDATE " + nombreTabla + " SET direccion = :direccion WHERE ruc = :ruc";

            try
            {
                var dbConnection = OracleDatabaseConnection.Instance;
                var connection = dbConnection.GetConnection();

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter("direccion", direccion));
                    cmd.Parameters.Add(new OracleParameter("ruc", ruc));

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Mensajes.emitirMensaje("Proveedor actualizado correctamente.");
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

        internal static bool actualizarTelefono(string telefono, string ruc)
        {
            string query = "UPDATE " + nombreTabla + " SET telefono = :telefono WHERE ruc = :ruc";

            try
            {
                var dbConnection = OracleDatabaseConnection.Instance;
                var connection = dbConnection.GetConnection();

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter("telefono", telefono));
                    cmd.Parameters.Add(new OracleParameter("ruc", ruc));

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Mensajes.emitirMensaje("Proveedor actualizado correctamente.");
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

        internal static bool actualizarTipo(string tipo, string ruc)
        {
            string query = "UPDATE " + nombreTabla + " SET tipo_proveedor = :tipo WHERE ruc = :ruc";

            try
            {
                var dbConnection = OracleDatabaseConnection.Instance;
                var connection = dbConnection.GetConnection();

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter("tipo_proveedor", tipo));
                    cmd.Parameters.Add(new OracleParameter("ruc", ruc));

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Mensajes.emitirMensaje("Proveedor actualizado correctamente.");
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

        internal static bool actualizarEmail(string email, string ruc)
        {
            string query = "UPDATE " + nombreTabla + " SET email = :tipo WHERE ruc = :ruc";

            try
            {
                var dbConnection = OracleDatabaseConnection.Instance;
                var connection = dbConnection.GetConnection();

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter("email", email));
                    cmd.Parameters.Add(new OracleParameter("ruc", ruc));

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Mensajes.emitirMensaje("Proveedor actualizado correctamente.");
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
