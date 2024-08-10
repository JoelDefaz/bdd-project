using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Prototipo_1___SartorialSys.BL.BD;

namespace Prototipo_1___SartorialSys.Clases
{
    internal class Usuario
    {
        static string nombreTabla = "credenciales";
        internal static bool actualizarContraseña(string contraseña, string usuario)
        {
            string query = "UPDATE " + nombreTabla + " SET contrasenia = :contraseña WHERE usuario = :usuario";

            try
            {
                var dbConnection = OracleDatabaseConnection.Instance;
                var connection = dbConnection.GetConnection();

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter("contrasenia", contraseña));
                    cmd.Parameters.Add(new OracleParameter("usuario", usuario));

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Mensajes.emitirMensaje("Usuario actualizado correctamente.");
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

        private static bool confirmarAccion(string mensaje)
        {
            DialogResult result = MessageBox.Show(mensaje, "Confirmar acción", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                return true;
            }
            return false;
        }

        internal static string[] buscarUsuario(string cedula)
        {
            string[] datosUsuarios = new string[4];
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

                            datosUsuarios[0] = row["usuario"].ToString();
                            datosUsuarios[1] = row["contrasenia"].ToString();
                            datosUsuarios[2] = row["cedula_empleado"].ToString();
                            datosUsuarios[3] = row["rol"].ToString();
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
            return datosUsuarios;
        }

        internal static bool registrarUsuario(string[] datosUsuario)
        {
            string sql = "INSERT INTO " + nombreTabla + " (usuario, contrasenia, cedula_empleado, rol) " +
            "VALUES (:usuario, :contrasenia, :cedula_empleado, :rol)";

            OracleConnection connection = null;
            try
            {
                var dbConnection = OracleDatabaseConnection.Instance;
                connection = dbConnection.GetConnection();
                if (connection.State != System.Data.ConnectionState.Open)
                {
                    connection.Open();
                }

                // Crear el 
                using (var cmd = new OracleCommand(sql, connection))
                {
                    // Agregar parámetros a la consulta
                    cmd.Parameters.Add(new OracleParameter("usuario", datosUsuario[0]));
                    cmd.Parameters.Add(new OracleParameter("contrasenia", datosUsuario[1]));
                    cmd.Parameters.Add(new OracleParameter("cedula_empleado", datosUsuario[2]));
                    cmd.Parameters.Add(new OracleParameter("rol", datosUsuario[3]));

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 1)
                    {
                        Mensajes.emitirMensaje("Usuario registrado con éxito");
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

        internal static bool tienePermisos(string usuario)
        {/*
            using (conn = new SqlConnection(strConn))
            {
                conn.Open();
                strComm = "SELECT * FROM usuarios WHERE usuario = '" + usuario + "'";
                using (comm = new SqlCommand(strComm, conn))
                {
                    SqlDataReader rdr = comm.ExecuteReader();
                    rdr.Read();
                    if (rdr.GetString(3) == "Administrador" || rdr.GetString(3) == "Gerente")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }*/
            return true;
        }

        internal static bool actualizarRol(string rol, string usuario)
        {
            string query = "UPDATE " + nombreTabla + " SET rol = :rol WHERE usuario = :usuario";

            try
            {
                var dbConnection = OracleDatabaseConnection.Instance;
                var connection = dbConnection.GetConnection();

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter("rol", rol));
                    cmd.Parameters.Add(new OracleParameter("usuario", usuario));

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Mensajes.emitirMensaje("Usuario actualizado correctamente.");
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

        internal static bool eliminarUsuario(string usuario)
        {
            if (!Mensajes.confirmarAccion("¿Está seguro de eliminar a este usuario?"))
            {
                return false;
            }
            string query = "DELETE FROM " + nombreTabla + " WHERE usuario = :usuario";
            try
            {
                var dbConnection = OracleDatabaseConnection.Instance;
                var connection = dbConnection.GetConnection();
                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter("usuario", usuario));
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

        private static bool estaActivo(string parametroBusqueda)
        {/*
            bool activo;
            using (conn = new SqlConnection(strConn))
            {
                conn.Open();
                strComm = "SELECT * FROM usuarios WHERE cedula_empleado = '" + parametroBusqueda + "'";
                using (comm = new SqlCommand(strComm, conn))
                {
                    SqlDataReader rdr = comm.ExecuteReader();
                    rdr.Read();
                    activo = rdr.GetBoolean(4);
                }
            }*/
            return true;
        }

        internal static bool darDeAlta(string parametroBusqueda)
        {/*
            if(estaActivo(parametroBusqueda))
            {
                Mensajes.emitirMensaje("Este usuario ya esta dado de alta");
                return false;
            }
            if (!confirmarAccion("¿Está seguro de dar de alta a este usuario?"))
            {
                return false;
            }
            using (conn = new SqlConnection(strConn))
            {
                conn.Open();
                strComm = "UPDATE usuarios SET estado = 1 WHERE cedula_empleado = " + parametroBusqueda;

                using (comm = new SqlCommand(strComm, conn))
                {
                    if (comm.ExecuteNonQuery() == 1)
                    {
                        Mensajes.emitirMensaje("Usuario dado de alta con éxito");
                    }
                }
            }*/
            return true;
        }

        internal static string getNombreTabla()
        {
            return nombreTabla;
        }
    }
}
