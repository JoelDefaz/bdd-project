using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Prototipo_1___SartorialSys.BL.BD;
using Prototipo_1___SartorialSys.BL.Proveedor;
using Prototipo_1___SartorialSys.Clases;

namespace Prototipo_1___SartorialSys.Formularios
{
    public partial class frmProductos : Form
    {
        public frmProductos()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string[] datos = getDatos();

            if (Productos.registrarProducto(datos))
            {
                limpiarRegistro();
            }
        }

        private string[] getDatos()
        {
            string[] datos = new string[10];
            datos[0] = txtCodigoRegistrar.Text;
            datos[1] = txtRUCProveedorRegistrar.Text;
            datos[2] = txtDescripcionRegistrar.Text;
            datos[3] = txtCantidadInicialRegistrar.Text;
            datos[4] = txtPrecioCompraRegistrar.Text;
            datos[5] = txtPrecioVentaRegistrar.Text;
            DateTime fechaSeleccionada = dtpFechaRegistro.Value;
            datos[6] = fechaSeleccionada.ToString("yyyy-MM-dd");
            datos[7] = cmbCategoriaRegistrar.Text;
            datos[8] = cmbColorRegistrar.Text;
            datos[9] = cmbTallaRegistrar.Text;
            return datos;
        }

        private void btnBuscarActualizar_Click(object sender, EventArgs e)
        {
            string[] datos = Productos.datosProducto(txtCodigoParaActualizar.Text);
            if (datos != null)
            {
                txtRUCProveedorActualizar.Text = datos[1];
                txtDescripcionActualizar.Text = datos[2];
                txtStockActualizar.Text = datos[3];
                txtPrecioCompraActualizar.Text = datos[4];
                txtPrecioVentaActualizar.Text = datos[5];
                txtFechaIngresoActualizar.Text = datos[6];
                txtCategoriaActualizar.Text = datos[7];
                txtColorActualizar.Text = datos[8];
                txtTallaActualizar.Text = datos[9];
            }
        }

        private void ckbPrecioCompra_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbPrecioCompra.Checked)
            {
                txtPrecioCompraActualizar.ReadOnly = false;
            }
            else
            {
                txtPrecioCompraActualizar.ReadOnly = true;
            }
        }

        private void ckbPrecioVenta_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbPrecioVenta.Checked)
            {
                txtPrecioVentaActualizar.ReadOnly = false;
            }
            else
            {
                txtPrecioVentaActualizar.ReadOnly = true;
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (ckbPrecioCompra.Checked)
            {
                if (Productos.actualizarPrecioCompra(txtPrecioCompraActualizar.Text, txtCodigoParaActualizar.Text))
                {
                    btnBuscarActualizar.PerformClick();
                    ckbPrecioCompra.Checked = false;
                }
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            if (ckbPrecioVenta.Checked)
            {
                if (Productos.actualizarPrecioVenta(txtPrecioVentaActualizar.Text, txtCodigoParaActualizar.Text))
                {
                    btnBuscarActualizar.PerformClick();
                    ckbPrecioVenta.Checked = false;
                }
            }
        }

        private void btnBuscarDarDeBaja_Click(object sender, EventArgs e)
        {
            string[] datos = Productos.datosProducto(txtCodigoParaEliminar.Text);
            if (datos != null)
            {
                txtRUCDarDeBaja.Text = datos[1];
                txtDescripcionDarDeBaja.Text = datos[2];
                txtStockDarDeBaja.Text = datos[3];
                txtPrecioCompraDarBaja.Text = datos[4];
                txtPrecioVentaDarBaja.Text = datos[5];
                txtFechaIngresoDarBaja.Text = datos[6];
                txtCategoriaDarDeBaja.Text = datos[7];
                txtColorDarDeBaja.Text = datos[8];
                txtTallaDarDeBaja.Text = datos[9];
            }
        }

        private void bntDarDeBaja_Click(object sender, EventArgs e)
        {
            if (Productos.darDeBaja(txtCodigoParaEliminar.Text))
            {
                limpiarDarDeBaja();
            }
        }

        private void limpiarDarDeBaja()
        {
            txtCodigoParaEliminar.Text = "";
            txtRUCDarDeBaja.Text = "";
            txtDescripcionDarDeBaja.Text = "";
            txtStockDarDeBaja.Text = "";
            txtPrecioCompraDarBaja.Text = "";
            txtPrecioVentaDarBaja.Text = "";
            txtFechaIngresoDarBaja.Text = "";
            txtCategoriaDarDeBaja.Text = "";
            txtColorDarDeBaja.Text = "";
            txtTallaDarDeBaja.Text = "";
        }

        private void txtParametroConsulta_Leave(object sender, EventArgs e)
        {

        }

        private void txtParametroActualizar_Leave(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnCancelarRegistro_Click(object sender, EventArgs e)
        {
            limpiarRegistro();
        }

        private void limpiarRegistro()
        {
            txtCodigoRegistrar.Text = "";
            txtRUCProveedorRegistrar.Text = "";
            txtDescripcionRegistrar.Text = "";
            txtCantidadInicialRegistrar.Text = "";
            txtPrecioCompraRegistrar.Text = "";
            txtPrecioVentaRegistrar.Text = "";
            dtpFechaRegistro.Checked = false;
            cmbCategoriaRegistrar.SelectedIndex = -1;
            cmbColorRegistrar.SelectedIndex = -1;
            cmbColorRegistrar.SelectedIndex = -1;

        }

        private void tabClientes_Enter(object sender, EventArgs e)
        {
            string query = "SELECT * FROM " + Productos.getNombreTabla();

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
                        dgtvProductos.DataSource = clientes;
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

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            tabClientes_Enter(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpiarDarDeBaja();
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }
    }
}