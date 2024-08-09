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

namespace Prototipo_1___SartorialSys
{
    public partial class frmEmpleados : Form
    {
        public frmEmpleados()
        {
            InitializeComponent();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            string[] datosEmpleado = {
                txtCedulaRegistrar.Text,
                txtNombresRegistrar.Text,
                txtApellidosRegistrar.Text,
                txtDireccionRegistrar.Text,
                txtCorreoRegistrar.Text,
                txtSalarioRegistrar.Text,
                txtHEntrada.Text,
                txtHAlmuerzo.Text,
                txtHSalida.Text};
            if (Empleados.registrarEmpleado(datosEmpleado))
            {
                limpiarRegistro();
            }
        }

        private void limpiarRegistro()
        {
            txtCedulaRegistrar.Text = "";
            txtNombresRegistrar.Text = "";
            txtApellidosRegistrar.Text = "";
            txtDireccionRegistrar.Text = "";
            txtCorreoRegistrar.Text = "";
            txtSalarioRegistrar.Text = "";
            txtHEntrada.Text = "";
            txtHAlmuerzo.Text = "";
            txtHSalida.Text = "";
        }

        private void txtCedulaRegistrar_Leave(object sender, EventArgs e)
        {
            if (txtCedulaRegistrar.Text != "")
            {
            }
        }

        private void txtNombresRegistrar_Leave(object sender, EventArgs e)
        {
            if (txtNombresRegistrar.Text != "")
            {

            }
        }

        private void txtApellidosRegistrar_Leave(object sender, EventArgs e)
        {
            if (txtApellidosRegistrar.Text != "")
            {

            }
        }

        private void txtTelefonoRegistrar_Leave(object sender, EventArgs e)
        {

        }

        private void txtCorreoRegistrar_Leave(object sender, EventArgs e)
        {
            if (txtCorreoRegistrar.Text != "")
            {

            }
        }

        private void txtSalarioRegistrar_Leave(object sender, EventArgs e)
        {
            if (txtSalarioRegistrar.Text != "")
            {
            }
        }

        private void txtHEntrada_Leave(object sender, EventArgs e)
        {
            if (txtHEntrada.Text != "")
            {

            }
        }

        private void txtHAlmuerzo_Leave(object sender, EventArgs e)
        {
            if (txtHAlmuerzo.Text != "")
            {

            }
        }

        private void txtHSalida_Leave(object sender, EventArgs e)
        {
            if (txtHSalida.Text != "")
            {

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarRegistro();
        }

        private void tabClientes_Enter(object sender, EventArgs e)
        {
            string query = "SELECT * FROM " + Empleados.getNombreTabla();

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
                        dgtEmpleados.DataSource = clientes;
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

        private void btnBuscarActualizar_Click(object sender, EventArgs e)
        {
            string[] datosE = Empleados.buscarEmpleado(txtcedulaParaActualizar.Text);

            txtNombreActualizar.Text = datosE[0];
            txtApellidoActualizar.Text = datosE[1];
            txtDireccionActualizar.Text = datosE[2];
            txtEmailActualizar.Text = datosE[3];
            txtSalarioActualizar.Text = datosE[4];
            txtEntradaActualizar.Text = datosE[5];
            txtAlmuerzoActualizar.Text = datosE[6];
            txtSalidaActualizar.Text = datosE[7];
        }

        private void btnBuscarEliminar_Click(object sender, EventArgs e)
        {
            string[] datosE = Empleados.buscarEmpleado(txtCedulaParaEliminar.Text);

            txtNombreEliminar.Text = datosE[0];
            txtApellidosEliminar.Text = datosE[1];
            txtDireccionAliminar.Text = datosE[2];
            txtEmailEliminar.Text = datosE[3];
            txtSalarioEliminar.Text = datosE[4];
            txttxtEntradaEliminar.Text = datosE[5];
            txtAlmuerzoAliminar.Text = datosE[6];
            txtSalidaEliminar.Text = datosE[7];
        }

        private void btnCancelarEliminar_Click(object sender, EventArgs e)
        {
            limpiarElimnar();
        }

        private void limpiarElimnar()
        {
            txtCedulaParaEliminar.Text = "";
            txtNombreEliminar.Text = "";
            txtApellidosEliminar.Text = "";
            txtDireccionAliminar.Text = "";
            txtEmailEliminar.Text = "";
            txtSalarioEliminar.Text = "";
            txttxtEntradaEliminar.Text = "";
            txtAlmuerzoAliminar.Text = "";
            txtSalidaEliminar.Text = "";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Empleados.eliminar(txtCedulaParaEliminar.Text))
            {
                limpiarElimnar();
            }
        }

        private void btnCorregirNombres_Click(object sender, EventArgs e)
        {
            if (chckNombre.Checked)
            {
                if (Empleados.actualizarNombre(txtNombreActualizar.Text, txtcedulaParaActualizar.Text))
                {
                    btnBuscarActualizar.PerformClick();
                    chckNombre.Checked = false;
                }
            }
        }

        private void chckNombre_CheckedChanged(object sender, EventArgs e)
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

        private void chckApellido_CheckedChanged(object sender, EventArgs e)
        {
            if (chckApellido.Checked)
            {
                txtApellidoActualizar.ReadOnly = false;
            }
            else
            {
                txtApellidoActualizar.ReadOnly = true;
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

        private void chckEmail_CheckedChanged(object sender, EventArgs e)
        {
            if (chckEmail.Checked)
            {
                txtEmailActualizar.ReadOnly = false;
            }
            else
            {
                txtEmailActualizar.ReadOnly = true;
            }
        }

        private void chckSalario_CheckedChanged(object sender, EventArgs e)
        {
            if (chckSalario.Checked)
            {
                txtSalarioActualizar.ReadOnly = false;
            }
            else
            {
                txtSalarioActualizar.ReadOnly = true;
            }
        }

        private void chckEntrada_CheckedChanged(object sender, EventArgs e)
        {
            if (chckEntrada.Checked)
            {
                txtEntradaActualizar.ReadOnly = false;
            }
            else
            {
                txtEntradaActualizar.ReadOnly = true;
            }
        }

        private void chckAlmuerzo_CheckedChanged(object sender, EventArgs e)
        {
            if (chckAlmuerzo.Checked)
            {
                txtAlmuerzoActualizar.ReadOnly = false;
            }
            else
            {
                txtAlmuerzoActualizar.ReadOnly = true;
            }
        }

        private void chckSalida_CheckedChanged(object sender, EventArgs e)
        {
            if (chckSalida.Checked)
            {
                txtSalidaActualizar.ReadOnly = false;
            }
            else
            {
                txtSalidaActualizar.ReadOnly = true;
            }
        }

        private void btnCorregirApellidos_Click(object sender, EventArgs e)
        {
            if (chckApellido.Checked)
            {
                if (Empleados.actualizarApellido(txtApellidoActualizar.Text, txtcedulaParaActualizar.Text))
                {
                    btnBuscarActualizar.PerformClick();
                    chckApellido.Checked = false;
                }
            }
        }

        private void btnActualizarDireccion_Click(object sender, EventArgs e)
        {
            if (chckDireccion.Checked)
            {
                if (Empleados.actualizarDireccion(txtDireccionActualizar.Text, txtcedulaParaActualizar.Text))
                {
                    btnBuscarActualizar.PerformClick();
                    chckDireccion.Checked = false;
                }
            }
        }

        private void btnActualizarCorreo_Click(object sender, EventArgs e)
        {
            if (chckEmail.Checked)
            {
                if (Empleados.actualizarCorreo(txtEmailActualizar.Text, txtcedulaParaActualizar.Text))
                {
                    btnBuscarActualizar.PerformClick();
                    chckEmail.Checked = false;
                }
            }
        }

        private void btnActualizarSalario_Click(object sender, EventArgs e)
        {
            if (chckSalario.Checked)
            {
                if (Empleados.actualizarSalario(txtSalarioActualizar.Text, txtcedulaParaActualizar.Text))
                {
                    btnBuscarActualizar.PerformClick();
                    chckSalario.Checked = false;
                }
            }
        }

        private void btnActualizarEntrada_Click(object sender, EventArgs e)
        {
            if (chckEntrada.Checked)
            {
                if (Empleados.actualizarEntrada(txtEntradaActualizar.Text, txtcedulaParaActualizar.Text))
                {
                    btnBuscarActualizar.PerformClick();
                    chckEntrada.Checked = false;
                }
            }
        }

        private void btnActualizarAlmuerzo_Click(object sender, EventArgs e)
        {
            if (chckAlmuerzo.Checked)
            {
                if (Empleados.actualizarAlmuerzo(txtAlmuerzoActualizar.Text, txtcedulaParaActualizar.Text))
                {
                    btnBuscarActualizar.PerformClick();
                    chckAlmuerzo.Checked = false;
                }
            }
        }

        private void btnActualizarSalida_Click(object sender, EventArgs e)
        {
            if (chckSalida.Checked)
            {
                if (Empleados.actualizarSalida(txtSalidaActualizar.Text, txtcedulaParaActualizar.Text))
                {
                    btnBuscarActualizar.PerformClick();
                    chckSalida.Checked = false;
                }
            }
        }
    }
}
