using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using Prototipo_1___SartorialSys.BL.BD;
using Prototipo_1___SartorialSys.Clases;

namespace Prototipo_1___SartorialSys
{
    internal class Pedidos
    {
        static string nombreTablaPedidos = "pedidos";

        internal static void actualizarPedido(string[] datos)
        {
            string query = "UPDATE " + nombreTablaPedidos + " SET total = :total, abonado = :abonado, saldo = :saldo, estado_pedido = :estado WHERE codigo_ped = :codigo";

            try
            {
                var dbConnection = OracleDatabaseConnection.Instance;
                var connection = dbConnection.GetConnection();

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter("total", datos[1]));
                    cmd.Parameters.Add(new OracleParameter("abonado", datos[2]));
                    cmd.Parameters.Add(new OracleParameter("saldo", datos[3]));
                    cmd.Parameters.Add(new OracleParameter("estado_pedido", datos[4]));
                    cmd.Parameters.Add(new OracleParameter("codigo_ped", datos[0]));
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Mensajes.emitirMensaje("Pedido actualizado correctamente.");
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
        }

        internal static string getNombreTabla()
        {
            return nombreTablaPedidos;
        }

        internal static bool registrarPedido(string[] datosPedidos)
        {
            string sql = "INSERT INTO " + nombreTablaPedidos + " (codigo_ped, cedula_cliente, modelo, total, abonado, saldo, estado_pedido) " +
            "VALUES (:codigo_ped, :cedula_cliente, :modelo, :total, :abonado, :saldo, :estado_pedido)";

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
                    // Agregar parámetros a la consulta
                    cmd.Parameters.Add(new OracleParameter("codigo_ped", datosPedidos[0]));
                    cmd.Parameters.Add(new OracleParameter("cedula_cliente", datosPedidos[1]));
                    cmd.Parameters.Add(new OracleParameter("modelo", datosPedidos[2]));
                    cmd.Parameters.Add(new OracleParameter("total", datosPedidos[3]));
                    cmd.Parameters.Add(new OracleParameter("abonado", datosPedidos[4]));
                    cmd.Parameters.Add(new OracleParameter("saldo", datosPedidos[5]));
                    cmd.Parameters.Add(new OracleParameter("estado_pedido", datosPedidos[6]));

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 1)
                    {
                        Mensajes.emitirMensaje("Pedido registrado con éxito");
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

        public static string[] buscarPedido(string codigo) {
            string[] datos = new string[7];
            string query = "SELECT * FROM " + nombreTablaPedidos + " WHERE codigo_ped = '" + codigo + "'";

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

                            datos[0] = row["codigo_ped"].ToString();
                            datos[1] = row["cedula_cliente"].ToString();
                            datos[2] = row["modelo"].ToString();
                            datos[3] = row["total"].ToString();
                            datos[4] = row["abonado"].ToString();
                            datos[5] = row["saldo"].ToString();
                            datos[6] = row["estado_pedido"].ToString();
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
            return datos;
        }

        internal static bool eliminar(string codigo)
        {
            if (!Mensajes.confirmarAccion("¿Está seguro de eliminar este pedido?"))
            {
                return false;
            }
            string query = "DELETE FROM " + nombreTablaPedidos + " WHERE codigo_ped = :codigo";
            try
            {
                var dbConnection = OracleDatabaseConnection.Instance;
                var connection = dbConnection.GetConnection();
                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter("codigo", codigo));
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Mensajes.emitirMensaje("Pedido eliminado correctamente.");
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
    }
}