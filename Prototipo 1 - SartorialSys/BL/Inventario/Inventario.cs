using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototipo_1___SartorialSys.Clases
{
    internal class Inventario
    {
        static string strConn = ConexionBaseDeDatos.getConexion();
        static string strComm = null;
        static SqlConnection conn = null;
        static SqlCommand comm = null;
        internal static void actualizarInventario(string[,] items)
        {   
            int filas = items.GetLength(0);
            string comandoActualizarStock = "UPDATE productos SET cantidad_inicial = cantidad_inicial + ";
            for (int i = 0; i < filas; i++)
            {
                actualizarInventario(comandoActualizarStock,items[i,0], "-"+items[i,1]);
                comandoActualizarStock = "UPDATE productos SET cantidad_inicial = cantidad_inicial + ";
            }
        }

        internal static void actualizarInventario(string comando, string codigo, string cantidad)
        {
            using (conn = new SqlConnection(strConn))
            {
                conn.Open();
                strComm = comando + cantidad + ", fecha_actualizacion = ((SELECT CURRENT_TIMESTAMP)) WHERE codigo_producto = '" + codigo+"';";

                using (comm = new SqlCommand(strComm, conn))
                {
                    comm.ExecuteNonQuery();
                }
            }
        }
        internal static void actualizarInventario(string codigo, int cantidad,string fecha_actualizacion)
        {
            using (conn = new SqlConnection(strConn))
            {
                conn.Open();
                strComm = "UPDATE productos SET cantidad_inicial = cantidad_inicial + "+cantidad.ToString()+", fecha_actualizacion = '"+fecha_actualizacion+"' WHERE codigo_producto = '"+codigo+"'";

                using (comm = new SqlCommand(strComm, conn))
                {
                    if(comm.ExecuteNonQuery() == 1)
                    {
                        Mensajes.emitirMensaje("Stock actualizado con éxito");
                    }
                }
            }
        }

        internal static string[] getDatosProducto(string codigo)
        {
            string[] datos = new string[6];
            using (conn = new SqlConnection(strConn))
            {
                conn.Open();
                strComm = "SELECT descripcion, C.categoria, L.color, T.talla, cantidad_inicial, precio_venta, P.activo " +
                        "FROM productos P, categoria C, color L, talla T " +
                        "WHERE codigo_producto = '" + codigo + "' AND P.id_categoria = C.id_categoria AND L.id_color = P.id_color " +
                        "AND T.id_talla = P.id_talla";
                using (comm = new SqlCommand(strComm, conn))
                {
                    SqlDataReader rdr = comm.ExecuteReader();
                    rdr.Read();
                    if (!rdr.HasRows)
                    {
                        Mensajes.emitirMensaje("Producto no Registrado");
                        return (null);
                    }
                    if (!rdr.GetBoolean(6))
                    {
                        Mensajes.emitirMensaje("Producto no Registrado");
                        return (null);
                    }
                    datos[0] = rdr.GetString(0);
                    datos[1] = rdr.GetString(1);
                    datos[2] = rdr.GetString(2);
                    datos[3] = rdr.GetString(3);
                    datos[4] = rdr.GetInt32(4).ToString();
                    datos[5] = rdr.GetDecimal(5).ToString();
                }
            }
            return datos;
        }
    }
}
