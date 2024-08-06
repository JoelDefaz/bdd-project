using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototipo_1___SartorialSys.Clases
{
    internal class Productos
    {
        static string strConn = ConexionBaseDeDatos.getConexion();
        static string strComm = null;
        static SqlConnection conn = null;
        static SqlCommand comm = null;
        internal static string[] getColores()
        {
            int i = 0;
            string[] colores = { "Rojo","Verde","Gris", "Negro" };
            //string[] colores = new string[4];
            /*
            using (conn = new SqlConnection(strConn))
            {
                conn.Open();
                strComm = "SELECT color FROM color";
                using (comm = new SqlCommand(strComm, conn))
                {
                    SqlDataReader rdr = comm.ExecuteReader();
                    while (rdr.Read())
                    {
                        colores[i] = rdr.GetString(0);
                        i++;
                    }
                    return colores;
                }
            }*/
            return colores;
        }

        internal static string[] getTallas()
        {
            int i = 0;
            string[] tallas = { "" ,"","",""};
            //string[] tallas = new string[4];
            /*
            using (conn = new SqlConnection(strConn))
            {
                conn.Open();
                strComm = "SELECT talla FROM talla";
                using (comm = new SqlCommand(strComm, conn))
                {
                    SqlDataReader rdr = comm.ExecuteReader();
                    while (rdr.Read())
                    {
                        tallas[i] = rdr.GetString(0);
                        i++;
                    }
                    return tallas;
                }
            }*/
            return tallas;
        }

        internal static bool registrarProducto(string[] datos)
        {
            using (conn = new SqlConnection(strConn))
            {
                try
                {
                    conn.Open();
                    if (datos[4] != null)
                    {
                        strComm = getComando(datos);
                    }
                    else
                    {
                        strComm = getComandoNull(datos);
                    }
                    using (comm = new SqlCommand(strComm, conn))
                    {
                        if (comm.ExecuteNonQuery() == 1)
                        {
                            return true;
                        }
                    }
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627 || ex.Number == 2601)
                    {
                        Mensajes.emitirMensaje("Producto ya registrado en el sistema " + ex.Message);
                        return false;
                    }
                    else
                    {
                        Mensajes.emitirMensaje("Error base de datos" + ex.Message);
                        return false;
                    }
                }
            }
            return false;
        }

        private static string getComandoNull(string[] datos)
        {
            return "INSERT INTO productos VALUES('" + datos[0] + "','" + datos[1] + "'," + getIDCategoria(datos[2]) + "," +
                getIdColor(datos[3]) + ",NULL,'" + datos[5] + "'," + datos[6] + ",NULL," + datos[8] + ",'" + datos[9] + "'," + getDia()+")";
        }

        private static string getDia()
        {
            return "(SELECT CAST(GETDATE() AS date))";
        }

        private static string getIdColor(string v)
        {
            return "(SELECT id_color from color WHERE color = '" + v + "')";
        }

        private static string getIDCategoria(string v)
        {
            return "(SELECT id_categoria FROM categoria WHERE categoria = '" + v + "')";
        }

        private static string getComando(string[] datos)
        {
            return "INSERT INTO productos VALUES('" + datos[0] + "','" + datos[1] + "'," + getIDCategoria(datos[2]) + "," +
                getIdColor(datos[3]) + ","+getIDTalla(datos[4]) +",'" + datos[5] + "'," + datos[6] + "," + datos[7] +"," + datos[8] + ",'" + datos[9] + "'," + getDia() + ");";
        }

        private static string getIDTalla(string v)
        {
            return "(SELECT id_talla FROM talla WHERE talla = '" + v + "')";
        }

        internal static bool buscarProducto(int i, string codigo, System.Windows.Forms.DataGridView listaProductos, string cantidad)
        {
            using (conn = new SqlConnection(strConn))
            {
                conn.Open();
                strComm = "SELECT descripcion,precio_venta,activo FROM productos WHERE codigo_producto = '" + codigo + "'";
                using (comm = new SqlCommand(strComm, conn))
                {
                    try
                    {
                        SqlDataReader rdr = comm.ExecuteReader();
                        rdr.Read();
                        if (!rdr.GetBoolean(2))
                        {
                            Mensajes.emitirMensaje("Producto no registrado");
                            return false;
                        }
                        if (rdr.HasRows)
                        {
                            var resultado = hayStockSuficiente(codigo,cantidad);
                            int stock = resultado.Item1;
                            bool esStockSuficiente = resultado.Item2;
                            if (!esStockSuficiente)
                            {
                                if (stock == 0)
                                {
                                    Mensajes.emitirMensaje("No existe stock del producto");
                                    return false;
                                }
                                if (!Mensajes.confirmarAccion("No se tiene esta cantidad al momento.\nSolo de dispone de " + stock + " unidades\n¿Desea agregar solo esta cantidad?"))
                                {
                                    return false;
                                }
                                int n = listaProductos.Rows.Add();
                                listaProductos.Rows[n].Cells[0].Value = i;
                                listaProductos.Rows[n].Cells[1].Value = codigo;
                                listaProductos.Rows[n].Cells[2].Value = rdr.GetString(0);
                                listaProductos.Rows[n].Cells[3].Value = stock;
                                listaProductos.Rows[n].Cells[4].Value = rdr.GetDecimal(1).ToString();
                            }
                            else
                            {
                                int n = listaProductos.Rows.Add();
                                listaProductos.Rows[n].Cells[0].Value = i;
                                listaProductos.Rows[n].Cells[1].Value = codigo;
                                listaProductos.Rows[n].Cells[2].Value = rdr.GetString(0);
                                listaProductos.Rows[n].Cells[3].Value = cantidad;
                                listaProductos.Rows[n].Cells[4].Value = rdr.GetDecimal(1).ToString();
                            }
                        }
                        else
                        {
                            Mensajes.emitirMensaje("Producto no registrado");
                            return false;
                        }
                    }catch(Exception e)
                    {
                        Mensajes.emitirMensaje("Ha ocurrido un error");
                        return false;
                    }
                }
            }
            return true;
        }

        private static (int,bool) hayStockSuficiente(string codigo, string cantidad)
        {
            int stockACtual;
            bool hayStock = true;
            using (conn = new SqlConnection(strConn))
            {
                conn.Open();
                strComm = "SELECT cantidad_inicial FROM productos WHERE codigo_producto = '" + codigo + "'";
                using (comm = new SqlCommand(strComm, conn))
                {
                    SqlDataReader rdr = comm.ExecuteReader();
                    rdr.Read();
                    stockACtual = rdr.GetInt32(0);
                    if (stockACtual - Convert.ToInt32(cantidad) < 0 )
                    {
                        hayStock = false;
                    }
                }
            }
            return (stockACtual, hayStock);
        }

        internal static string[] datosProducto(string text)
        {
            string[] datos = new string[10];
            using (conn = new SqlConnection(strConn))
            {
                conn.Open();
                strComm = getComandoBusqueda(text);
                using (comm = new SqlCommand(strComm, conn))
                {
                    try
                    {
                        SqlDataReader rdr = comm.ExecuteReader();
                        rdr.Read();
                        if (!rdr.GetBoolean(10))
                        {
                            Mensajes.emitirMensaje("Producto no registrado");
                            return null;
                        }
                        if (rdr.HasRows)
                        {
                            datos[0] = rdr.GetString(0);
                            datos[1] = rdr.GetString(1);
                            datos[2] = rdr.GetString(2);
                            datos[3] = rdr.GetString(3);
                            datos[4] = rdr.GetString(4);
                            datos[5] = rdr.GetInt32(5).ToString();
                            datos[6] = rdr.GetDecimal(6).ToString();
                            datos[7] = rdr.GetDecimal(7).ToString();
                            datos[8] = rdr.GetDateTime(8).ToString();
                            datos[9] = rdr.GetDateTime(9).ToString();
                        }
                        else
                        {
                            Mensajes.emitirMensaje("Producto no registrado");
                            return null;
                        }
                    }
                    catch (Exception e)
                    {
                        Mensajes.emitirMensaje("Error al consultar");
                        return null;
                    }
                    return datos;
                }
            }
        }

        private static string getComandoBusqueda(string text)
        {
            return "select descripcion,C.categoria,L.color,T.talla,ruc_proveedor,cantidad_inicial,precio_compra,precio_venta,fecha_ingreso,fecha_actualizacion, P.activo " +
                "from productos P, categoria C, talla T, color L where codigo_producto = '"+text+"' AND P.id_categoria = C.id_categoria " +
                "AND P.id_color = L.id_color AND P.id_talla = T.id_talla";
        }

        internal static bool actualizarPrecioCompra(string precio_compra, string codigo)
        {
            if (!Mensajes.confirmarAccion("¿Está seguro de actualizar este dato?"))
            {
                return false;
            }
            using (conn = new SqlConnection(strConn))
            {
                conn.Open();
                strComm = "UPDATE productos SET precio_compra = '" + precio_compra + "' WHERE codigo_producto = '" + codigo + "';";

                using (comm = new SqlCommand(strComm, conn))
                {
                    if (comm.ExecuteNonQuery() == 1)
                    {
                        Mensajes.emitirMensaje("Precio de compra actualizado con éxito”");
                    }
                }
            }
            return true;
        }

        internal static bool actualizarPrecioVenta(string precio_venta, string codigo)
        {
            if (!Mensajes.confirmarAccion("¿Está seguro de actualizar este dato?"))
            {
                return false;
            }
            using (conn = new SqlConnection(strConn))
            {
                conn.Open();
                strComm = "UPDATE productos SET precio_venta = '" + precio_venta + "' WHERE codigo_producto = '" + codigo + "';";

                using (comm = new SqlCommand(strComm, conn))
                {
                    if (comm.ExecuteNonQuery() == 1)
                    {
                        Mensajes.emitirMensaje("Precio de venta actualizado con éxito”");
                    }
                }
            }
            return true;
        }

        internal static bool darDeBaja(string text)
        {
            throw new NotImplementedException();
        }
    }
}