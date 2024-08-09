using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using Oracle.ManagedDataAccess.Client;
using Prototipo_1___SartorialSys.BL.BD;

namespace Prototipo_1___SartorialSys.Clases
{
    internal class Productos
    {
        static string nombreTabla = "Productos";
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
             string sql = "INSERT INTO " + nombreTabla + " (codigo_producto, ruc_proveedor_fk, descripcion, cantidad_inicial, precio_compra, precio_venta, fecha_ingreso, categoria, color,talla) " +
    "VALUES (:codigo_producto, :ruc_proveedor_fk, :descripcion, :cantidad_inicial, :precio_compra, :precio_venta, :fecha_ingreso, :categoria, :color, :talla)";

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
                    cmd.Parameters.Add(new OracleParameter("codigo_producto", datos[0]));
                    cmd.Parameters.Add(new OracleParameter("ruc_proveedor_fk", datos[1]));
                    cmd.Parameters.Add(new OracleParameter("descripcion", datos[2]));
                    cmd.Parameters.Add(new OracleParameter("cantidad_inicial", datos[3]));
                    cmd.Parameters.Add(new OracleParameter("precio_compra", datos[4]));
                    cmd.Parameters.Add(new OracleParameter("precio_venta", datos[5]));

                    DateTime fechaIngreso;
                    if (DateTime.TryParse(datos[6], out fechaIngreso))
                    {
                        OracleParameter fechaIngresoParam = new OracleParameter("fecha_ingreso", OracleDbType.Date)
                        {
                            Value = fechaIngreso
                        };
                        cmd.Parameters.Add(fechaIngresoParam);
                    }
                    else
                    {
                        throw new ArgumentException("La fecha de ingreso no tiene un formato válido.");
                    }

                    cmd.Parameters.Add(new OracleParameter("categoria", datos[7]));
                    cmd.Parameters.Add(new OracleParameter("color", datos[8]));
                    cmd.Parameters.Add(new OracleParameter("talla", datos[9]));

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 1)
                    {
                        Mensajes.emitirMensaje("Producto registrado con éxito");
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
        {/*
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
            }*/
            return true;
        }

        private static (int,bool) hayStockSuficiente(string codigo, string cantidad)
        {
            int stockACtual = 0;
            bool hayStock = true;/*
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
            }*/
            return (stockACtual, hayStock);
        }

        internal static string[] datosProducto(string ruc)
        {
            string[] datosProductos = new string[10];
            string query = "SELECT * FROM " + nombreTabla + " WHERE codigo_producto = '" + ruc + "'";
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

                            datosProductos[0] = row["codigo_producto"].ToString();
                            datosProductos[1] = row["RUC_PROVEEDOR_FK"].ToString();
                            datosProductos[2] = row["descripcion"].ToString();
                            datosProductos[3] = row["cantidad_inicial"].ToString();
                            datosProductos[4] = row["precio_compra"].ToString();
                            datosProductos[5] = row["precio_venta"].ToString();
                            datosProductos[6] = row["fecha_ingreso"].ToString();
                            datosProductos[7] = row["categoria"].ToString();
                            datosProductos[8] = row["color"].ToString();
                            datosProductos[9] = row["talla"].ToString();
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
            return datosProductos;
        }

        private static string getComandoBusqueda(string text)
        {
            return "select descripcion,C.categoria,L.color,T.talla,ruc_proveedor,cantidad_inicial,precio_compra,precio_venta,fecha_ingreso,fecha_actualizacion, P.activo " +
                "from productos P, categoria C, talla T, color L where codigo_producto = '"+text+"' AND P.id_categoria = C.id_categoria " +
                "AND P.id_color = L.id_color AND P.id_talla = T.id_talla";
        }

        internal static bool actualizarPrecioCompra(string precio_compra, string codigo)
        {
            string query = "UPDATE " + nombreTabla + " SET precio_compra = :precio_compra WHERE codigo_producto = :codigo";

            try
            {
                var dbConnection = OracleDatabaseConnection.Instance;
                var connection = dbConnection.GetConnection();

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter("precio_compra", precio_compra));
                    cmd.Parameters.Add(new OracleParameter("codigo", codigo));

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Mensajes.emitirMensaje("Producto actualizado correctamente.");
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

        internal static bool actualizarPrecioVenta(string precio_venta, string codigo)
        {
            string query = "UPDATE " + nombreTabla + " SET precio_venta = :precio_venta WHERE codigo_producto = :codigo";

            try
            {
                var dbConnection = OracleDatabaseConnection.Instance;
                var connection = dbConnection.GetConnection();

                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter("precio_venta", precio_venta));
                    cmd.Parameters.Add(new OracleParameter("codigo", codigo));

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Mensajes.emitirMensaje("Producto actualizado correctamente.");
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

        internal static bool darDeBaja(string codigo)
        {
            if (!Mensajes.confirmarAccion("¿Está seguro de eliminar a este  producto?"))
            {
                return false;
            }
            string query = "DELETE FROM " + nombreTabla + " WHERE codigo_producto = :codigo";
            try
            {
                var dbConnection = OracleDatabaseConnection.Instance;
                var connection = dbConnection.GetConnection();
                using (var cmd = new OracleCommand(query, connection))
                {
                    cmd.Parameters.Add(new OracleParameter("codigo_producto", codigo));
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Mensajes.emitirMensaje("Producto eliminado correctamente.");
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

        internal static string getNombreTabla()
        {
            return nombreTabla;
        }
    }
}