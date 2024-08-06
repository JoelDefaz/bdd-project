using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Prototipo_1___SartorialSys.Clases
{
    internal class Ventas
    {
        static string strConn = ConexionBaseDeDatos.getConexion();
        static string strComm = null;
        static SqlConnection conn = null;
        static SqlCommand comm = null;
        internal static bool registrarVenta(string[] datos, string[,] items)
        {
            string numeroDeFactura = "001-001-" + getNumeroFac(getSigNumFact());
            using (conn = new SqlConnection(strConn))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction();
                try
                {
                    SqlCommand command = new SqlCommand(getComandoFacturas(numeroDeFactura, datos), conn, transaction);
                    command.ExecuteNonQuery();

                    if (items != null)
                    {

                        SqlCommand command1 = new SqlCommand(getComandoItems(numeroDeFactura, items), conn, transaction);
                        command1.ExecuteNonQuery();
                    }
                    else
                    {
                        throw new Exception();
                    }

                    SqlCommand command2 = new SqlCommand("UPDATE parametros SET valor = (valor + 1) WHERE nombre = 'num_factura';", conn, transaction);
                    command2.ExecuteNonQuery();

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    // En caso de error, revertir la transacción
                    Mensajes.emitirMensaje("Error 1: " + ex.Message);
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception exRollback)
                    {
                        Mensajes.emitirMensaje("Error al hacer rollback: " + exRollback.Message);
                        return false;
                    }return false;
                }
            }
            return true;
        }

        private static int getSigNumFact()
        {
            int num_factura;
            using (conn = new SqlConnection(strConn))
            {
                conn.Open();
                strComm = "select valor from parametros WHERE nombre = 'num_factura'";
                using (comm = new SqlCommand(strComm, conn))
                {
                    SqlDataReader rdr = comm.ExecuteReader();
                    rdr.Read();
                    num_factura = Convert.ToInt32(rdr.GetDecimal(0));
                }
            }    
                return num_factura;
        }

        private static string getNumeroFac(int num_factura)
        {
            int digitos = num_factura.ToString().Length;
            string numero = "";
            for (int i = 0; i < (9 - digitos); i++)
            {
                numero += "0";
            }
            numero += num_factura.ToString();
            return numero;
        }

        private static string getComandoItems(string numero_factura, string[,] datosIngresar)
        {
            int filas = datosIngresar.GetLength(0);
            string comandoFacturas = "INSERT INTO items VALUES";
            for (int i = 0; i < filas; i++)
            {
                comandoFacturas += "('"+numero_factura+"','"+ datosIngresar[i,0] + "',NULL," + datosIngresar[i,1] + ","+datosIngresar[i,2]+"), ";           
            }
            return comandoFacturas.Substring(0, comandoFacturas.Length - 2) + ";";
        }

        private static string getComandoFacturas(string num_factura, string[] datos)
        {
            return "INSERT INTO facturas VALUES('"+num_factura + "','" + datos[1] + "','" + datos[2] + "','" + datos[3] + "','" + datos[4] + "'," + datos[5] + "," + datos[6] + "," + datos[7] + "," + datos[8] +");";
        }

        internal static string[] consultarVenta(string numero_factura)
        {
            string[] datos = new string[14];
            using (conn = new SqlConnection(strConn))
            {
                conn.Open();
                strComm = getComandoConsulta(numero_factura);
                using (comm = new SqlCommand(strComm, conn))
                {
                    SqlDataReader rdr = comm.ExecuteReader();
                    rdr.Read();
                    if (!rdr.HasRows)
                    {
                        Mensajes.emitirMensaje("Factura no registrada");
                        return (null);
                    }
                    else
                    {
                        datos[0] = numero_factura;
                        datos[1] = rdr.GetString(0);
                        datos[2] = rdr.GetString(1);
                        datos[3] = rdr.GetString(2);
                        datos[4] = rdr.GetString(3);
                        datos[5] = rdr.GetString(4);
                        datos[6] = rdr.GetString(5);
                        datos[7] = rdr.GetDateTime(6).ToString();
                        datos[8] = rdr.GetString(7);
                        datos[9] = rdr.GetDecimal(8).ToString();
                        datos[10] = rdr.GetDecimal(9).ToString();
                        datos[11] = rdr.GetDecimal(10).ToString();
                        if (rdr.GetBoolean(11))
                        {
                            datos[12] = "Pagado";
                        }
                        else
                        {
                            datos[12] = "No pagado";
                        }
                        if (rdr.GetBoolean(12))
                        {
                            datos[13] = "SI";
                        }
                        else
                        {
                            datos[13] = "NO";
                        }
                    }
                }
            }
            return (datos);
        }

        private static string getComandoConsulta(string numero_factura)
        {
            return "SELECT C.cedula_cliente, C.nombres,C.apellidos, C.direccion_domiciliaria, C.numero_telefono, C.correo_electronico," +
                "F.fecha_venta, F.metodo_pago, F.subtotal, F.IVA, F.total, F.estado_pago, F.anulado " +
                "FROM facturas F, items I , clientes C " +
                "WHERE F.numero_factura = '"+numero_factura+"' AND I.numero_factura = F.numero_factura AND F.cedula_cliente = C.cedula_cliente";
        }

        internal static string[,] getItemsFactura(string numero_factura)
        {
            string[,] items = null;
            int filas = 10;
            using (conn = new SqlConnection(strConn))
            {
                conn.Open();
                strComm = "select P.codigo_producto, P.descripcion, I.cantidad, I.precio_vendido from items I, facturas F, productos P " +
                    "where I.numero_factura = F.numero_factura AND F.numero_factura = '" + numero_factura + "' AND I.codigo_producto = P.codigo_producto";
                using (comm = new SqlCommand(strComm, conn))
                {
                    SqlDataReader rdr = comm.ExecuteReader();
                    string[,] datoSItems = new string[filas, 4]; 
                    int i = 0;
                    while (rdr.Read())
                    {
                        datoSItems[i, 0] = rdr.GetString(0);
                        datoSItems[i, 1] = rdr.GetString(1);
                        datoSItems[i, 2] = rdr.GetInt32(2).ToString();
                        datoSItems[i, 3] = rdr.GetDecimal(3).ToString();
                    i++;
                    }
                    items = datoSItems;
                }
            }
            return items;
        }

        internal static bool anularFactura(string text)
        {
            try
            {
                using (conn = new SqlConnection(strConn))
                {
                    conn.Open();
                    strComm = "UPDATE facturas SET anulado = 1 WHERE numero_factura = '" + text + "'";
                    using (comm = new SqlCommand(strComm, conn))
                    {
                        if (comm.ExecuteNonQuery() == 1)
                        {
                            Mensajes.emitirMensaje("Factura anulada con éxito");
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex) { 
                return false;
            }
            return true;
        }

        internal static string getNumeroFactura()
        {
            try
            {
                using (conn = new SqlConnection(strConn))
                {
                    conn.Open();
                    strComm = "SELECT TOP 1 numero_factura FROM facturas ORDER BY fecha_venta DESC;";
                    using (comm = new SqlCommand(strComm, conn))
                    {
                        SqlDataReader rdr = comm.ExecuteReader();
                        return rdr.GetString(0).ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                return "";
            }
            return "";
        }
    }
}