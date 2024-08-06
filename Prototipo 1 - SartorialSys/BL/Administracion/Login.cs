using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prototipo_1___SartorialSys.Clases
{
    internal class Login
    {
        static string strConn = ConexionBaseDeDatos.getConexion();
        static string strComm = null;
        static SqlConnection conn = null;
        static SqlCommand comm = null;
        internal static bool estanCrendencialesVacias(string usuario, string contraseña)
        {
            if ((usuario == "" && contraseña == "") || (usuario == "USUARIO") && (contraseña == "CONTRASEÑA"))
            {
                return true;
            }
            if (contraseña == "CONTRASEÑA" || usuario == "USUARIO")
            {
                return true;
            }
            return false;
        }

        internal static bool sonCorrectasLasCredenciales(string usuario, string contraseña)
        {/*
            using (conn = new SqlConnection(strConn))
            {
                conn.Open();
                strComm = "SELECT * FROM usuarios WHERE usuario = '" + usuario + "'";
                using (comm = new SqlCommand(strComm, conn))
                {

                    SqlDataReader rdr = comm.ExecuteReader();
                    rdr.Read();
                    if (!rdr.HasRows)
                    {
                        Mensajes.emitirMensaje("Usuario no registrado");
                        return false;
                    }
                    if (!estaActivo(rdr))
                    {
                        Mensajes.emitirMensaje("Usuario no activo");
                        return false;
                    }
                    if (contraseña != rdr.GetString(1))
                    {
                        Mensajes.emitirMensaje("Contraseña Incorrecta");
                        return false;
                    }
                }
            }*/
            if(usuario == "admin" && contraseña == "123")
            {
                return true;
            }
            return false;
        }

        private static bool estaActivo(SqlDataReader reader)
        {
            return reader.GetBoolean(4);
        }
    }
}
