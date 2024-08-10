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
    public partial class frmAdministrarUsuarios : Form
    {
        public frmAdministrarUsuarios()
        {
            InitializeComponent();
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            string[] datosUsuario = { txtUsuarioRegistrar.Text,
                txtContraseñaRegistrar.Text,
                txtCedulaEmpleadoRegistrar.Text,
                comboBoxRolRegistrar.Text};
            if (Usuario.registrarUsuario(datosUsuario))
            {
                limpiarConsola();
            } 
        }

        private void limpiarConsola()
        {
            txtCedulaEmpleadoRegistrar.Text = "";
            txtUsuarioRegistrar.Text = "";
            txtContraseñaRegistrar.Text = "";
            comboBoxRolRegistrar.Text = "Seleccione";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarConsola();
        }

        private void checkEmail_CheckedChanged(object sender, EventArgs e)
        {
            if (checkContraseña.Checked)
            {
                txtContraseñaActualizar.ReadOnly =false;
            }
            else
            {
                txtContraseñaActualizar.ReadOnly = true;
            }
        }

        private void txtEmailActualizar_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnActualizarCliente_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Usuario Actaulizado con éxito");
            limpiarActualizar();
        }

        private void limpiarActualizar()
        {
            txtCedulaActualizar.Text = "";
            txtUsuarioActualizar.Text = "";
            txtContraseñaActualizar.Text = "";
        }

        private void btnCancelarActualizacion_Click(object sender, EventArgs e)
        {
            limpiarActualizar();
        }

        private void btnBuscarParaActualizar_Click(object sender, EventArgs e)
        {
                string[] datosUsuario = Usuario.buscarUsuario(txtCedulaActualizar.Text);
            txtUsuarioActualizar.Text = datosUsuario[0];
                txtContraseñaActualizar.Text = datosUsuario[1];
                comboBoxRolActualizar.SelectedIndex = getRol(datosUsuario[3]);
        }

        private int getRol(string rol)
        {
            if(rol == "Gerente")
            {
                return 0;
            }
            else if(rol == "Administrador")
            {
                return 1;
            }
            return 2;
        }

        private void comboBoxRolActualizar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void checkBoxRol_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxRol.Checked)
            {
                comboBoxRolActualizar.Enabled = true;
            }
            else
            {
                comboBoxRolActualizar.Enabled = false;
            }
        }

        private void btnCancelarBusqueda_Click(object sender, EventArgs e)
        {
            limpiarConsulta();
        }

        private void limpiarConsulta()
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Usuario.eliminarUsuario(txtUsuarioDarDeBaja.Text))
            {
                limpiarDarDeBaja();
            }
        }

        private void limpiarDarDeBaja()
        {
            txtUsuarioDarDeBaja.Text = "";
            txtContraseñaDarDeBaja.Text = "";
            txtRolDarDeBaja.Text = "";
            txtCedulaEmpleadoDarDeBaja.Text = "";
        }

        private void frmAdministrarUsuarios_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void btnActualizarContraseña_Click(object sender, EventArgs e)
        {
            if (Usuario.actualizarContraseña(txtContraseñaActualizar.Text, txtUsuarioActualizar.Text))
            {
                checkContraseña.Checked = false;
                btnBuscarActualizar.PerformClick();
            }
        }

        private void btnActualizarRol_Click(object sender, EventArgs e)
        {
            if (Usuario.actualizarRol(comboBoxRolActualizar.Text, txtUsuarioActualizar.Text))
            {
                btnBuscarActualizar.PerformClick();
                checkBoxRol.Checked = false;
            }
        }

        private void btnBuscarDarDeBaja_Click(object sender, EventArgs e)
        {
            string[] datosUsuario = Usuario.buscarUsuario(txtCedulaEmpleadoDarDeBaja.Text);
            txtUsuarioDarDeBaja.Text = datosUsuario[0];
            txtContraseñaDarDeBaja.Text = datosUsuario[1];
            txtRolDarDeBaja.Text = datosUsuario[3];
        }

        private void btnDarDeAlta_Click(object sender, EventArgs e)
        {
            if (Usuario.darDeAlta(txtCedulaEmpleadoDarDeBaja.Text))
            {
                limpiarDarDeBaja();
            }
        }

        private void txtContraseñaRegistrar_Leave(object sender, EventArgs e)
        {
            if (txtContraseñaRegistrar.Text != "")
            {

            }
        }

        private void txtCedulaEmpleadoRegistrar_Leave(object sender, EventArgs e)
        {
            if (txtCedulaEmpleadoRegistrar.Text != "")
            {
            }
        }

        private void txtCedulaActualizar_Leave(object sender, EventArgs e)
        {
            if (txtCedulaActualizar.Text != "")
            {
            }
        }

        private void txtContraseñaActualizar_Leave(object sender, EventArgs e)
        {
            if (txtContraseñaActualizar.Text != "")
            {
            }
        }

        private void txtCedulaEmpleadoDarDeBaja_Leave(object sender, EventArgs e)
        {
            if (txtCedulaEmpleadoDarDeBaja.Text != "")
            {
            }
        }

        private void txtContraseñaRegistrar_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txtUsuarioRegistrar_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBoxRolRegistrar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtCedulaEmpleadoRegistrar_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabConsultar_Click(object sender, EventArgs e)
        {

        }

        private void tabClientes_Enter(object sender, EventArgs e)
        {
            string query = "SELECT * FROM " + Usuario.getNombreTabla();

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
                        dgtvCredenciales.DataSource = clientes;
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

        private void button1_Click(object sender, EventArgs e)
        {
            tabClientes_Enter(sender, e);
        }
    }
}