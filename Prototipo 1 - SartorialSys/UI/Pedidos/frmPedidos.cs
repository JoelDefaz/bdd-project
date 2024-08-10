using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Prototipo_1___SartorialSys.BL.BD;
using Prototipo_1___SartorialSys.Clases;
using Prototipo_1___SartorialSys.Formularios;
using Prototipo_1___SartorialSys.UI;

namespace Prototipo_1___SartorialSys
{
    public partial class frmPedidos : Form
    {
        public frmPedidos()
        {
            InitializeComponent();
        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {

        }

        private void frmPedidos_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtTelefonoRegistrar_TextChanged(object sender, EventArgs e)
        {

        }

        private void label35_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            string[] datosCliente = Cliente.buscarCliente(txtCedulaRegistrar.Text);

            txtNombresRegistrar.Text = datosCliente[1];
            txtApellidosRegistrar.Text = datosCliente[2];
            txtDireccionRegistrar.Text = datosCliente[3];
            txtCorreoRegistrar.Text = datosCliente[4];
            txtTelefonoRegistrar.Text = datosCliente[5];
        }

        private void btnActualizarInformacion_Click(object sender, EventArgs e)
        {
            frmClientes clientes = new frmClientes(txtCedulaRegistrar.Text, 0);
            clientes.ShowDialog();
        }

        private void btnCancelarRegistro_Click(object sender, EventArgs e)
        {
            limpiarRegistro();
        }

        private void btnRegistrarVenta_Click(object sender, EventArgs e)
        {
            string[] datosCliente = {
            txtCodigoRegistrar.Text,
            txtCedulaRegistrar.Text,
            txtModeloRegistrar.Text,
            txtTotalRegistrar.Text,
            txtAbonaRegistrar.Text,
            txtSaldoRegistrar.Text,
            txtEstadoRegistrar.Text
            };
            if (Pedidos.registrarPedido(datosCliente))
            {
                limpiarRegistro();
            }
        }

        private void limpiarRegistro()
        {
            txtCedulaRegistrar.Text = "";
            btnBuscarCliente.PerformClick();
            txtTotalRegistrar.Text = "";
            txtAbonaRegistrar.Text = "";
            txtSaldoRegistrar.Text = "";
            txtEstadoRegistrar.Text = "";
            txtModeloRegistrar.Text = "";
            txtCodigoRegistrar.Text = "";
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            if (txtAbonaRegistrar.Text != "") {
                double saldo = (double.Parse(txtTotalRegistrar.Text) - double.Parse(txtAbonaRegistrar.Text));
                txtSaldoRegistrar.Text = saldo.ToString();
                txtEstadoRegistrar.Text = (saldo == 0.0)? "Retirar": "Pagar";
            }
            else
            {
                txtSaldoRegistrar.Text = txtTotalRegistrar.Text;
                txtEstadoRegistrar.Text = "Pagar";
                txtAbonaRegistrar.Text = "0";
            }
        }

        private void tabClientes_Enter(object sender, EventArgs e)
        {
            string query = "SELECT * FROM " + Pedidos.getNombreTabla();

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
                        dgtvClientes.DataSource = clientes;
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

        private void textBox22_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCalcularAtualizar_Click(object sender, EventArgs e)
        {
                double saldo = (double.Parse(txtTotalAct.Text) - double.Parse(txtAbonaAct.Text));
                txtSaldoAct.Text = saldo.ToString();
                txtEstadoAct.Text = (saldo == 0.0) ? "Retirar" : "Pagar";
        }

        private void btnCancelarAct_Click(object sender, EventArgs e)
        {
            limpiarActualizar();
        }

        private void limpiarActualizar()
        {
            txtCodigoParaActualizar.Text = "";
            btnBuscarActualizar.PerformClick();
            txtModeloAct.Text = "";
            txtTotalAct.Text = "";
            txtAbonaAct.Text = "";
            txtSaldoAct.Text = "";
            txtEstadoAct.Text = "";
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string[] datos = { 
            txtCodigoParaActualizar.Text,
            txtTotalAct.Text,
            txtAbonaAct.Text,
            txtSaldoAct.Text,
            txtEstadoAct.Text
            };
            Pedidos.actualizarPedido(datos);
        }

        private void btnBuscarActualizar_Click(object sender, EventArgs e)
        {
            string[] datosPedido = Pedidos.buscarPedido(txtCodigoParaActualizar.Text);
            string[] datosCliente = Cliente.buscarCliente(datosPedido[1]);

            //Cliente
            txtCedulaAct.Text = datosCliente[0];
            txtNombreActualizar.Text = datosCliente[1];
            txtApellidoAct.Text = datosCliente[2];

            //Pedido
            txtModeloAct.Text = datosPedido[1];
            txtTotalAct.Text = datosPedido[3];
            txtAbonaAct.Text = datosPedido[4];
            txtSaldoAct.Text = datosPedido[5];
            txtEstadoAct.Text = datosPedido[6];
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            tabClientes_Enter(sender, e);
        }

        private void btnBuscarEli_Click(object sender, EventArgs e)
        {
            string[] datosPedido = Pedidos.buscarPedido(txtCodigoEli.Text);
            string[] datosCliente = Cliente.buscarCliente(datosPedido[1]);

            //Cliente
            txtCedulaEli.Text = datosCliente[0];
            txtNombreEli.Text = datosCliente[1];
            txtApellidoEli.Text = datosCliente[2];

            //Pedido
            txtModeloEli.Text = datosPedido[1];
            txtTotalEli.Text = datosPedido[3];
            txtAbonaEli.Text = datosPedido[4];
            txtSaldoEli.Text = datosPedido[5];
            txtEstadoEli.Text = datosPedido[6];
        }

        private void btnCancelarEli_Click(object sender, EventArgs e)
        {
            limpiarEliminar();
        }

        private void limpiarEliminar()
        {
            txtCodigoEli.Text = "";
            btnBuscarEli.PerformClick();
            txtModeloEli.Text = "";
            txtTotalEli.Text = "";
            txtAbonaEli.Text = "";
            txtSaldoEli.Text = "";
            txtEstadoEli.Text = "";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Pedidos.eliminar(txtCodigoEli.Text))
            {
                limpiarEliminar();
            }
        }
    }
}
