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
using Prototipo_1___SartorialSys.BL.Proveedor;
using Prototipo_1___SartorialSys.Clases;

namespace Prototipo_1___SartorialSys
{
    public partial class frmProveedores : Form
    {
        public frmProveedores()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
                    }

        private void frmProveedores_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarRegistrar();
        }

        private void limpiarRegistrar()
        {
            txtRucRegistrar.Text = "";
            txtNombresRegistrar.Text = "";
            txtDireccionRegistrar.Text = "";
            txtTelefonoRegistrar.Text = "";
            cmbxTipoRegistrar.SelectedIndex = -1;
            txtEmailRegistrar.Text = "";
            txtSucursalRegistrar.Text = "";
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            string[] datosProveedor = {
            txtRucRegistrar.Text,
            txtNombresRegistrar.Text,
            txtDireccionRegistrar.Text,
            txtTelefonoRegistrar.Text,
            txtEmailRegistrar.Text,
            cmbxTipoRegistrar.SelectedItem as string,
            txtSucursalRegistrar.Text};

            if (Proveedor.registrarCliente(datosProveedor))
            {
                limpiarRegistrar();
            }
        }

        private void tabClientes_Enter(object sender, EventArgs e)
        {
                string query = "SELECT * FROM " + Proveedor.getNombreTabla();

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

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            tabClientes_Enter(sender, e);
        }

        private void btnCancelarActualizacion_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (chckNombre.Checked)
            {
                txtNombreActualizar.ReadOnly = false;
            }
            else
            {
                txtNombreActualizar.ReadOnly = true;
            }
        }

        private void chckDireccion_CheckedChanged(object sender, EventArgs e)
        {
            if (chckDireccion.Checked)
            {
                txtDireccionActualizar.ReadOnly = false;
            }
            else
            {
                txtDireccionActualizar.ReadOnly = true;
            }
        }

        private void chckTelefono_CheckedChanged(object sender, EventArgs e)
        {
            if (chckTelefono.Checked)
            {
                txtTelefonoActualizar.ReadOnly = false;
            }
            else
            {
                txtTelefonoActualizar.ReadOnly = true;
            }
        }

        private void chckTipo_CheckedChanged(object sender, EventArgs e)
        {
            if (chckTipo.Checked)
            {
                cmbxTipoActualizar.Enabled = true;
            }
            else
            {
                cmbxTipoActualizar.Enabled = false;
            }
        }

        private void chckEmail_CheckedChanged(object sender, EventArgs e)
        {
            if (chckEmailActualizar.Checked)
            {
                txtEmailActualizar.ReadOnly = false;
            }
            else
            {
                txtEmailActualizar.ReadOnly = true;
            }
        }

        private void btnBuscarParaActualizar_Click(object sender, EventArgs e)
        {
            string[] datosProveedor = Proveedor.buscarProveedor(txtRucParaActualizar.Text);

            txtRucActualizar.Text = datosProveedor[0];
            txtNombreActualizar.Text = datosProveedor[1];
            txtDireccionActualizar.Text = datosProveedor[2];
            txtTelefonoActualizar.Text = datosProveedor[3];
            txtEmailActualizar.Text = datosProveedor[4];
            cmbxTipoActualizar.Text = datosProveedor[5];
            txtSucursalActualizar.Text = datosProveedor[6];
        }

        private void btnBuscarConsultar_Click(object sender, EventArgs e)
        {
            string[] datosProveedor = Proveedor.buscarProveedor(txtRucParaEliminar.Text);

            txtRucEliminar.Text = datosProveedor[0];
            txtNombreEliminar.Text = datosProveedor[1];
            txtDireccionEliminar.Text = datosProveedor[2];
            txtTelefonoEliminar.Text = datosProveedor[3];
            txtEmailEliminar.Text = datosProveedor[4];
            txtTipoEliminar.Text = datosProveedor[5];
            txtSucursalEliminar.Text = datosProveedor[6];
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Proveedor.eliminar(txtRucEliminar.Text))
            {
                limpiarEliminar();
            }
        }

        private void limpiarEliminar()
        {
            txtRucEliminar.Text = "";
            txtNombreEliminar.Text = "";
            txtDireccionEliminar.Text = "";
            txtTelefonoEliminar.Text = "";
            txtTipoEliminar.Text = "";
            txtEmailEliminar.Text = "";
            txtSucursalEliminar.Text = "";
        }

        private void btnCancelarEliminar_Click(object sender, EventArgs e)
        {
            limpiarEliminar();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (chckNombre.Checked)
            {
                if (Proveedor.actualizarNombre(txtNombreActualizar.Text, txtRucActualizar.Text))
                {
                    btnBuscarParaActualizar.PerformClick();
                    chckNombre.Checked = false;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (chckDireccion.Checked)
            {
                if (Proveedor.actualizarDireccion(txtDireccionActualizar.Text, txtRucActualizar.Text))
                {
                    btnBuscarParaActualizar.PerformClick();
                    chckDireccion.Checked = false;
                }
            }
        }

        private void btnActualizarCliente_Click(object sender, EventArgs e)
        {
            if (chckTelefono.Checked)
            {
                if (Proveedor.actualizarTelefono(txtTelefonoActualizar.Text, txtRucActualizar.Text))
                {
                    btnBuscarParaActualizar.PerformClick();
                    chckTelefono.Checked = false;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (chckTipo.Checked)
            {
                if (Proveedor.actualizarTipo(cmbxTipoActualizar.SelectedItem as string, txtRucActualizar.Text))
                {
                    btnBuscarParaActualizar.PerformClick();
                    chckTipo.Checked = false;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (chckEmailActualizar.Checked)
            {
                if (Proveedor.actualizarEmail(txtEmailActualizar.Text, txtRucActualizar.Text))
                {
                    btnBuscarParaActualizar.PerformClick();
                    chckEmailActualizar.Checked = false;
                }
            }
        }
    }
}
