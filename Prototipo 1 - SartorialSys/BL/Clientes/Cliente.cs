using System;
using System.Collections.Generic;
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
        static string strConn = ConexionBaseDeDatos.getConexion();
        static string strComm = null;
        static SqlConnection conn = null;
        static SqlCommand comm = null;
        static string nombreTabla = "clientes_quito";
        internal static string[] buscarCliente(string parametroBusqueda)
        {
            string[] datosCliente = new string[6];
            using (conn = new SqlConnection(strConn))
            {
                conn.Open();
                strComm = "SELECT * FROM clientes WHERE cedula_cliente = '" + parametroBusqueda + "'";
                using (comm = new SqlCommand(strComm, conn))
                {
                    SqlDataReader rdr = comm.ExecuteReader();
                    rdr.Read();
                    if (!rdr.HasRows)
                    {
                        Mensajes.emitirMensaje("No existe registro");
                        return datosCliente;
                    }
                    if(!rdr.GetBoolean(6))
                    {
                        Mensajes.emitirMensaje("Cliente no activo");
                        return datosCliente;
                    }
                    else
                    {
                        datosCliente[0] = rdr.GetString(0);
                        datosCliente[1] = rdr.GetString(1);
                        datosCliente[2] = rdr.GetString(2);
                        datosCliente[3] = rdr.GetString(3);
                        datosCliente[4] = rdr.GetString(4);
                        datosCliente[5] = rdr.GetString(5);
                        return datosCliente;
                    }
                }
            }
        }

        internal static string[] buscarCliente(string parametroBusqueda, int i)
        {
            string[] datosCliente = new string[6];
            using (conn = new SqlConnection(strConn))
            {
                conn.Open();
                strComm = "SELECT * FROM clientes WHERE cedula_cliente = '" + parametroBusqueda + "'";
                using (comm = new SqlCommand(strComm, conn))
                {
                    SqlDataReader rdr = comm.ExecuteReader();
                    rdr.Read();
                    if (!rdr.HasRows)
                    {
                        Mensajes.emitirMensaje("No existe registro");
                        return datosCliente;
                    }
                    else
                    {
                        datosCliente[0] = rdr.GetString(0);
                        datosCliente[1] = rdr.GetString(1);
                        datosCliente[2] = rdr.GetString(2);
                        datosCliente[3] = rdr.GetString(3);
                        datosCliente[4] = rdr.GetString(4);
                        datosCliente[5] = rdr.GetString(5);
                        return datosCliente;
                    }
                }
            }
        }

        internal static bool darDeBaja(string parametroBusqueda)
        {
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
            if (!activo)
            {
                Mensajes.emitirMensaje("Este cliente ya esta dado de baja");
                return false;
            }
           if (!Mensajes.confirmarAccion("¿Está seguro de dar de baja a este cliente?"))
            {
                return false;
            }
            using (conn = new SqlConnection(strConn))
            {
                conn.Open();
                strComm = "UPDATE clientes SET activo = 0 WHERE cedula_cliente = " + parametroBusqueda;

                using (comm = new SqlCommand(strComm, conn))
                {
                    if (comm.ExecuteNonQuery() == 1)
                    {
                        Mensajes.emitirMensaje("Cliente dado de baja con éxito");
                    }
                }
            }
            return true;
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
        {
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
            }
            return true;
        }

        internal static bool actualizarDireccion(string direccion, string parametroBusqueda)
        {
            if (!Mensajes.confirmarAccion("¿Está seguro de actualizar este dato?"))
            {
                return false;
            }
            using (conn = new SqlConnection(strConn))
            {
                conn.Open();
                strComm = "UPDATE clientes SET direccion_domiciliaria = '" + direccion +"' WHERE cedula_cliente = " + parametroBusqueda;

                using (comm = new SqlCommand(strComm, conn))
                {
                    if (comm.ExecuteNonQuery() == 1)
                    {
                        Mensajes.emitirMensaje("Direccion domiciliaria actualizada con éxito");
                    }
                }
            }
            return true;
        }

        internal static bool actualizarTelefono(string telefono, string parametroBusqueda)
        {
            if (!Mensajes.confirmarAccion("¿Está seguro de actualizar este dato?"))
            {
                return false;
            }
            using (conn = new SqlConnection(strConn))
            {
                conn.Open();
                strComm = "UPDATE clientes SET numero_telefono = '" + telefono + "' WHERE cedula_cliente = " + parametroBusqueda;

                using (comm = new SqlCommand(strComm, conn))
                {
                    if (comm.ExecuteNonQuery() == 1)
                    {
                        Mensajes.emitirMensaje("Número de teléfono actualizado con éxito");
                    }
                }
            }
            return true;
        }

        internal static bool actualizarCorreo(string correo, string parametroBusqueda)
        {
            if (!Mensajes.confirmarAccion("¿Está seguro de actualizar este dato?"))
            {
                return false;
            }
            using (conn = new SqlConnection(strConn))
            {
                conn.Open();
                strComm = "UPDATE clientes SET correo_electronico = '" + correo + "' WHERE cedula_cliente = " + parametroBusqueda;

                using (comm = new SqlCommand(strComm, conn))
                {
                    if (comm.ExecuteNonQuery() == 1)
                    {
                        Mensajes.emitirMensaje("Correo electrónico actualizado con éxito");
                    }
                }
            }
            return true;
        }

        internal static bool actualizarNombres(string nombres, string parametroBusqueda)
        {
            if (!Mensajes.confirmarAccion("¿Está seguro de corregir este dato?"))
            {
                return false;
            }
            using (conn = new SqlConnection(strConn))
            {
                conn.Open();
                strComm = "UPDATE clientes SET nombres = '" + nombres + "' WHERE cedula_cliente = " + parametroBusqueda;

                using (comm = new SqlCommand(strComm, conn))
                {
                    if (comm.ExecuteNonQuery() == 1)
                    {
                        Mensajes.emitirMensaje("Nombres corregidos con éxito");
                    }
                }
            }
            return true;
        }

        internal static bool actualizarApellidos(string apellidos, string parametroBusqueda)
        {
            if (!Mensajes.confirmarAccion("¿Está seguro de corregir este dato?"))
            {
                return false;
            }
            using (conn = new SqlConnection(strConn))
            {
                conn.Open();
                strComm = "UPDATE clientes SET nombres = '" + apellidos + "' WHERE cedula_cliente = " + parametroBusqueda;

                using (comm = new SqlCommand(strComm, conn))
                {
                    if (comm.ExecuteNonQuery() == 1)
                    {
                        Mensajes.emitirMensaje("Apellidos corregidos con éxito");
                    }
                }
            }
            return true;
        }

        public static string getNombreTabla()
        {
            return nombreTabla;
        }
    }
}
