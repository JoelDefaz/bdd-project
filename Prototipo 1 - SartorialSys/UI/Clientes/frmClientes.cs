using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Prototipo_1___SartorialSys.BL.BD;
using Prototipo_1___SartorialSys.Clases;

namespace Prototipo_1___SartorialSys
{
    public partial class frmClientes : Form
    {
        private bool permiso;

        public frmClientes()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.Sizable;
        }

        public frmClientes(string cedula, int v)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.Sizable;
            tabClientes.SelectedIndex = 2;
            txtParametroActualizar.Text = cedula;
            btnBuscarActualizar.PerformClick();
        }

        private int v;

        private void btnRegresar_Click(object sender, EventArgs e)
        {
        }

        private void checkNombres_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkDireccion_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkTelefono_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkEmail_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtCedulaActualizar_TextChanged(object sender, EventArgs e)
        {
       
        }

        private void txtTelefonoActualizar_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            string[] datosCliente = { 
                txtCedulaRegistrar.Text, 
                txtNombresRegistrar.Text, 
                txtApellidosRegistrar.Text, 
                txtDireccionRegistrar.Text, 
                txtTelefonoRegistrar.Text, 
                txtCorreoRegistrar.Text, 
                txtCantonRegistrar.Text};
            if (Cliente.registrarCliente(datosCliente))
            {
                limpiarConsola();
            }
        }

        private void limpiarConsola()
        {
            txtCedulaRegistrar.Text = "";
            txtNombresRegistrar.Text = "";
            txtApellidosRegistrar.Text = "";
            txtDireccionRegistrar.Text = "";
            txtTelefonoRegistrar.Text = "";
            txtCorreoRegistrar.Text = "";
            txtCantonRegistrar.Text = "";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarConsola();
        }

        private void tableClientes_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void btnCancelarActualizacion_Click(object sender, EventArgs e)
        {
            limpiarActualizacion();
        }

        private void btnActualizarCliente_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cliente actualizado con éxito", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            limpiarActualizacion();
        }

        private void limpiarActualizacion()
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignorar el carácter ingresado
            }
        }

        private void btnBuscarParaActualizar_Click(object sender, EventArgs e)
        {
            //string[] datosCliente = Cliente.buscarCliente(txtParametroBuscar.Text);
        }

        private void txtParametroParaActualizar_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancelarBusqueda_Click(object sender, EventArgs e)
        {
            limpiarConsulta();
        }

        private void limpiarConsulta()
        {

        }

        private void txtParametroBusqueda_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string[] datosCliente = Cliente.buscarCliente(txtParametroActualizar.Text);
            txtCedulaActualizar.Text = datosCliente[0];
            txtNombresActualizar.Text = datosCliente[1];
            txtApellidosActualizar.Text = datosCliente[2];
            txtDireccionActualizar.Text = datosCliente[3];
            txtCorreoActualizar.Text = datosCliente[4];
            txtTelefonoActualizar.Text = datosCliente[5];
        }

        private void txtParametroEliminar_TextChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            limpiarDarDeBaja();
        }

        private void limpiarDarDeBaja()
        {
            txtParametroDarDeBaja.Text = "";
            txtCedulaDarDeBaja.Text = "";
            txtNombresDarDeBaja.Text = "";
            txtApellidosDarDeBaja.Text = "";
            txtDireccionDarDeBaja.Text = "";
            txtCorreoDarDeBaja.Text = "";
            txtTelefonoDarDeBaja.Text = "";
        }

        private void label29_Click(object sender, EventArgs e)
        {
        }

        private void txtCédulaConsultar_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmClientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void txtFechaNacimientoConsultar_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label30_Click(object sender, EventArgs e)
        {

        }

        private void txtEmailRegistrar_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTeléfonoRegistrar_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDirecciónRegistrar_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombresRegistrar_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtFechaNacimientoRegistrar_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCédulaRegistrar_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void tablaCliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCancelarBuscar_Click(object sender, EventArgs e)
        {
            limpiarBuscar();
        }

        private void limpiarBuscar()
        {
            txtParametroActualizar.Text = "";        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void btnBuscarDarDeBaja_Click(object sender, EventArgs e)
        {
            string[] datosCliente = Cliente.buscarCliente(txtParametroDarDeBaja.Text,1);
            txtCedulaDarDeBaja.Text = datosCliente[0];
            txtNombresDarDeBaja.Text = datosCliente[1];
            txtApellidosDarDeBaja.Text = datosCliente[2];
            txtDireccionDarDeBaja.Text = datosCliente[3];
            txtCorreoDarDeBaja.Text = datosCliente[4];
            txtTelefonoDarDeBaja.Text = datosCliente[5];
        }

        private void bntDarDeBaja_Click(object sender, EventArgs e)
        {
            if (Cliente.darDeBaja(txtParametroDarDeBaja.Text))
            {
                limpiarDarDeBaja();
            }
        }

        private void btnDarDeAlta_Click(object sender, EventArgs e)
        {
            if (Cliente.darDeAlta(txtParametroDarDeBaja.Text))
            {
                limpiarDarDeBaja();
            }
        }

        private void btnCorregirNombres_Click(object sender, EventArgs e)
        {
            if (permiso && checkBoxNombres.Checked)
            {
                if (Cliente.actualizarNombres(txtNombresActualizar.Text, txtParametroActualizar.Text))
                {
                    btnBuscarActualizar.PerformClick();
                    checkBoxNombres.Checked = false;
                }
            }
            else
            {
                Mensajes.emitirMensaje("Usted no posee los permisos para cambiar esta información");
            }
        }

        private void checkBoxNombres_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNombres.Checked)
            {
                txtNombresActualizar.ReadOnly = false;
            }
            else
            {
                txtNombresActualizar.ReadOnly = true;
            }
        }

        private void checkBoxApellidos_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxApellidos.Checked)
            {
                txtApellidosActualizar.ReadOnly = false;
            }
            else
            {
                txtApellidosActualizar.ReadOnly = true;
            }
        }

        private void checkBoxDireccion_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxDireccion.Checked)
            {
                txtDireccionActualizar.ReadOnly = false;
            }
            else
            {
                txtDireccionActualizar.ReadOnly = true;
            }
        }

        private void checkBoxTelefono_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTelefono.Checked)
            {
                txtTelefonoActualizar.ReadOnly = false;
            }
            else
            {
                txtTelefonoActualizar.ReadOnly = true;
            }
        }

        private void checkBoxCorreo_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCorreo.Checked)
            {
                txtCorreoActualizar.ReadOnly = false;
            }
            else
            {
                txtCorreoActualizar.ReadOnly = true;
            }
        }

        private void btnActualizarDireccion_Click(object sender, EventArgs e)
        {
            if (checkBoxDireccion.Checked)
            {
                if (Cliente.actualizarDireccion(txtDireccionActualizar.Text, txtParametroActualizar.Text))
                {
                    btnBuscarActualizar.PerformClick();
                    checkBoxDireccion.Checked = false;
                }
            }
        }

        private void btnActualizarTelefono_Click(object sender, EventArgs e)
        {
            if (checkBoxTelefono.Checked)
            {
                if (Cliente.actualizarTelefono(txtTelefonoActualizar.Text, txtParametroActualizar.Text))
                {
                    btnBuscarActualizar.PerformClick();
                    checkBoxTelefono.Checked = false;
                }
            }
        }

        private void btnActualizarCorreo_Click(object sender, EventArgs e)
        {
            if (checkBoxCorreo.Checked)
            {
                if (Cliente.actualizarCorreo(txtCorreoActualizar.Text, txtParametroActualizar.Text))
                {
                    btnBuscarActualizar.PerformClick();
                    checkBoxCorreo.Checked = false;
                }
            }
        }

        private void btnCorregirApellidos_Click(object sender, EventArgs e)
        {
            if (permiso && checkBoxApellidos.Checked)
            {
                if (Cliente.actualizarApellidos(txtApellidosActualizar.Text, txtParametroActualizar.Text))
                {
                    btnBuscarActualizar.PerformClick();
                    checkBoxApellidos.Checked = false;
                }
            }
            else
            {
                Mensajes.emitirMensaje("Usted no posee los permisos para cambiar esta información");
            }
        }

        private void txtCedulaRegistrar_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void txtCedulaRegistrar_Validated(object sender, EventArgs e)
        {

        }

        private void txtCedulaRegistrar_Leave(object sender, EventArgs e)
        {
            if(txtCedulaRegistrar.Text != "")
            {

            }
        }

        private void txtNombresRegistrar_Leave(object sender, EventArgs e)
        {
            if (txtNombresRegistrar.Text != "")
            {
            }
        }

        private void txtCedulaRegistrar_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void txtApellidosRegistrar_Leave(object sender, EventArgs e)
        {
            if (txtApellidosRegistrar.Text != "")
            {

            }
        }

        private void txtNombresActualizar_Leave(object sender, EventArgs e)
        {
            if (txtNombresActualizar.Text != "")
            {

            }
        }

        private void txtApellidosActualizar_Leave(object sender, EventArgs e)
        {
            if (txtApellidosActualizar.Text != "")
            {

            }
        }

        private void txtNombresRegistrar_KeyUp(object sender, KeyEventArgs e)
        {
            char c = (char)e.KeyCode;
            if (Char.IsDigit(c))
            {
                Mensajes.emitirMensaje("No se permiten números");
                txtNombresRegistrar.Text = "";
                txtNombresRegistrar.Focus();
            }
        }

        private void txtApellidosRegistrar_KeyUp(object sender, KeyEventArgs e)
        {
            char c = (char)e.KeyCode;
            if (Char.IsDigit(c))
            {
                Mensajes.emitirMensaje("No se permiten números");
                txtApellidosRegistrar.Text = "";
                txtApellidosRegistrar.Focus();
            }
        }

        private void txtCedulaRegistrar_KeyUp_1(object sender, KeyEventArgs e)
        {

        }

        private void txtTelefonoRegistrar_Leave(object sender, EventArgs e)
        {
            if (txtTelefonoRegistrar.Text != "")
            {

            }
        }

        private void txtCorreoRegistrar_Leave(object sender, EventArgs e)
        {
            if (txtCorreoRegistrar.Text != "")
            {

            }
        }

        private void txtParametroActualizar_Leave(object sender, EventArgs e)
        {
            if (txtParametroActualizar.Text != "")
            {

            }
        }

        private void txtParametroDarDeBaja_Leave(object sender, EventArgs e)
        {
            if (txtParametroDarDeBaja.Text != "")
            {

            }
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void txtDireccionActualizar_Leave(object sender, EventArgs e)
        {

        }

        private void txtTelefonoActualizar_Leave(object sender, EventArgs e)
        {
            if (txtTelefonoActualizar.Text != "")
            {

            }
        }

        private void txtCorreoActualizar_Leave(object sender, EventArgs e)
        {
            if (txtCorreoActualizar.Text != "")
            {
                }
            }

        private void tabClientes_Enter(object sender, EventArgs e)
        {
            //Buscar en la lista y ponerlo en la tabla
            string query = "SELECT * FROM " + Cliente.getNombreTabla();

            try
            {
                // Obtener la instancia del Singleton
                var dbConnection = OracleDatabaseConnection.Instance;

                // Obtener la conexión
                using (var connection = dbConnection.GetConnection())
                {
                    // Crear el comando
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
            }
            catch (OracleException ex)
            {
                Console.WriteLine($"Error de base de datos: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

    }
}