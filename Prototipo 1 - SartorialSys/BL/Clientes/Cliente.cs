using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototipo_1___SartorialSys.Clases
{
    internal class Cliente
    {
        static string strConn = ConexionBaseDeDatos.getConexion();
        static string strComm = null;
        static SqlConnection conn = null;
        static SqlCommand comm = null;
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
            string cedula = "'" + datosCliente[0] + "'";
            string nombres = "'" + datosCliente[1] + "'";
            string apellidos = "'" + datosCliente[2] + "'";
            string direccion = "'" + datosCliente[3] + "'";
            string telefono = "'" + datosCliente[4] + "'";
            string correo = "'" + datosCliente[5] + "'";
            using (conn = new SqlConnection(strConn))
            {
                    try
                    {
                        conn.Open();
                        strComm = "INSERT INTO clientes VALUES(" + cedula + "," + nombres + "," + apellidos + "," + direccion + "," + telefono + "," + correo + ",DEFAULT)";
                        using (comm = new SqlCommand(strComm, conn))
                        if (comm.ExecuteNonQuery() == 1)
                        {
                            Mensajes.emitirMensaje("Cliente registrado con éxito");
                            return true;
                        }
                    }
                  catch (SqlException ex)
                  {
                         // Se captura la excepción específica de SQL Server
                         if (ex.Number == 2627 || ex.Number == 2601)
                         {
                        // Manejar el error de duplicado
                        Mensajes.emitirMensaje("Cliente ya registrado en el sistema");
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
    }
}
