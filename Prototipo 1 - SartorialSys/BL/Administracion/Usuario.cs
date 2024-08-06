using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototipo_1___SartorialSys.Clases
{
    internal class Usuario
    {
        static string strConn = ConexionBaseDeDatos.getConexion();
        static string strComm = null;
        static SqlConnection conn = null;
        static SqlCommand comm = null;

        internal static bool actualizarContraseña(string contraseña, string parametroBusqueda)
        {
            if (!confirmarAccion("¿Está seguro de actualizar este dato?"))
            {
                return false;
            }
            using (conn = new SqlConnection(strConn))
            {
                conn.Open();
                strComm = "UPDATE usuarios SET contraseña = '" + contraseña + "' WHERE cedula_empleado = " + parametroBusqueda;
                using (comm = new SqlCommand(strComm, conn))
                {
                    if (comm.ExecuteNonQuery() == 1)
                    {
                        Mensajes.emitirMensaje("Contraseña actualizada con éxito");
                    }
                }
            }
            return true;
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

        internal static string[] buscarUsuario(string parametroBusqueda)
        {
            string[] datosCliente = new string[5];
            using (conn = new SqlConnection(strConn))
            {
                conn.Open();
                strComm = "SELECT * FROM usuarios WHERE cedula_empleado = '" + parametroBusqueda + "'";
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
//                        datosCliente[4] = rdr.GetString(4);
                        return datosCliente;
                    }
                }
            }
        }

        internal static bool registrarUsuario(string[] datosUsuario)
        {
            string usuario = "'" + datosUsuario[0] + "'";
            string contraseña = "'" + datosUsuario[1] + "'";
            string cedulaEmpleado = "'" + datosUsuario[2] + "'";
            string rol = "'" + datosUsuario[3] + "'";
            using (conn = new SqlConnection(strConn))
            {

                try
                {
                    conn.Open();
                    strComm = "INSERT INTO usuarios VALUES(" + usuario + "," + contraseña + "," + cedulaEmpleado + "," + rol + ",DEFAULT)";
                    using (comm = new SqlCommand(strComm, conn))
                    {
                        if (comm.ExecuteNonQuery() == 1)
                        {
                            Mensajes.emitirMensaje("Usuario registrado con éxito");
                            return true;
                        }
                    }
                }
                catch (SqlException ex)
                {
                    // Se captura la excepción específica de SQL Server
                    if (ex.Number == 2627 || ex.Number == 2601)
                    {
                        // Manejar el error de duplicado
                        Mensajes.emitirMensaje("Usuario ya registrado en el sistema");
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

        internal static bool actualizarRol(string rol, string parametroBusqueda)
        {
            if (!confirmarAccion("¿Está seguro de actualizar este dato?"))
            {
                return false;
            }
            using (conn = new SqlConnection(strConn))
            {
                conn.Open();
                strComm = "UPDATE usuarios SET rol = '" + rol + "' WHERE cedula_empleado = " + parametroBusqueda;
                using (comm = new SqlCommand(strComm, conn))
                {
                    if (comm.ExecuteNonQuery() == 1)
                    {
                        Mensajes.emitirMensaje("Rol actualizado con éxito");
                    }
                }
            }
            return true;
        }

        internal static bool darDeBaja(string parametroBusqueda)
        {
            if (!estaActivo(parametroBusqueda))
            {
                Mensajes.emitirMensaje("Este usuario ya esta dado de baja");
                return false;
            }
            if (!confirmarAccion("¿Está seguro de dar de baja a este usuario?"))
            {
                return false;
            }
            using (conn = new SqlConnection(strConn))
            {
                conn.Open();
                strComm = "UPDATE usuarios SET estado = 0 WHERE cedula_empleado = " + parametroBusqueda;

                using (comm = new SqlCommand(strComm, conn))
                {
                    if (comm.ExecuteNonQuery() == 1)
                    {
                        Mensajes.emitirMensaje("Usuario dado de baja con éxito");
                    }
                }
            }
            return true;
        }

        private static bool estaActivo(string parametroBusqueda)
        {
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
            }
            return activo;
        }

        internal static bool darDeAlta(string parametroBusqueda)
        {
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
            }
            return true;
        }
    }
}
