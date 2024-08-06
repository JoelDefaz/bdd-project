using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            string[] datosUsuario = { txtUsuarioRegistrar.Text, txtContraseñaRegistrar.Text, txtCedulaEmpleadoRegistrar.Text, (string)comboBoxRolRegistrar.SelectedItem};
            if (!ValidarCedula.estanLosCamposLlenos(datosUsuario))
            {
                Mensajes.emitirMensaje("Por favor llenar los campos");
                return;
            }
            if (Usuario.registrarUsuario(datosUsuario))
            {
                limpiarConsola();
            }
            else
            {
                Mensajes.emitirMensaje("Verificar datos");
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
            txtCedulaEmpleadoBuscar.Text = "";
            txtUsuarioBuscar.Text = "";
            txtContraseñaBuscar.Text = "";
            txtRolBuscar.Text = "";
        }

        private void btnBuscarConsultar_Click(object sender, EventArgs e)
        {
            txtCedulaEmpleadoBuscar.Text = "1724915770";
            txtUsuarioBuscar.Text = "PabloH24@";
            txtContraseñaBuscar.Text = "admin1234";
            txtRolBuscar.Text = "Gerente";
        }

        private void btnBuscarEliminar_Click(object sender, EventArgs e)
        {
            txtCedulaEmpleadoDarDeBaja.Text = "1724915770";
            txtUsuarioDarDeBaja.Text = "PabloH24@";
            txtContraseñaDarDeBaja.Text = "admin1234";
            txtRolDarDeBaja.Text = "Gerente";

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (Usuario.darDeBaja(txtCedulaEmpleadoDarDeBaja.Text))
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

        private void checkBoxContraseña_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxContraseña.Checked)
            {
                txtContraseñaRegistrar.UseSystemPasswordChar = false;
            }
            else
            {
                txtContraseñaRegistrar.UseSystemPasswordChar = true;
            }
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void btnActualizarContraseña_Click(object sender, EventArgs e)
        {
            if (Usuario.actualizarContraseña(txtContraseñaActualizar.Text, txtCedulaActualizar.Text))
            {
                btnBuscarActualizar.PerformClick();
                checkContraseña.Checked = false;
            }
        }

        private void btnActualizarRol_Click(object sender, EventArgs e)
        {
            if (Usuario.actualizarRol(comboBoxRolActualizar.Text, txtCedulaActualizar.Text))
            {
                btnBuscarActualizar.PerformClick();
                checkBoxRol.Checked = false;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string[] datosUsuario = Usuario.buscarUsuario(txtCedulaEmpleadoBuscar.Text);
            txtUsuarioBuscar.Text = datosUsuario[0];
            txtContraseñaBuscar.Text = datosUsuario[1];
            txtRolBuscar.Text = datosUsuario[3];
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
                if (!Validaciones.validarContraseña(txtContraseñaRegistrar.Text))
                {
                    Mensajes.emitirMensaje("Contrasña equivocada");
                    txtContraseñaRegistrar.Text = "";
                    txtContraseñaRegistrar.Focus();
                }
            }
        }

        private void txtCedulaEmpleadoRegistrar_Leave(object sender, EventArgs e)
        {
            if (txtCedulaEmpleadoRegistrar.Text != "")
            {
                if (!ValidarCedula.validarCedula(txtCedulaEmpleadoRegistrar.Text))
                {
                    Mensajes.emitirMensaje("Número de Cédula invalida");
                    txtCedulaEmpleadoRegistrar.Text = "";
                    txtCedulaEmpleadoRegistrar.Focus();
                }
            }
        }

        private void txtCedulaActualizar_Leave(object sender, EventArgs e)
        {
            if (txtCedulaActualizar.Text != "")
            {
                if (!ValidarCedula.validarCedula(txtCedulaActualizar.Text))
                {
                    Mensajes.emitirMensaje("Número de Cédula invalida");
                    txtCedulaActualizar.Text = "";
                    txtCedulaActualizar.Focus();
                }
            }
        }

        private void txtContraseñaActualizar_Leave(object sender, EventArgs e)
        {
            if (txtContraseñaActualizar.Text != "")
            {
                if (!Validaciones.validarContraseña(txtContraseñaActualizar.Text))
                {
                    Mensajes.emitirMensaje("Contrasña equivocada");
                    txtContraseñaActualizar.Text = "";
                    txtContraseñaActualizar.Focus();
                }
            }
        }

        private void txtCedulaEmpleadoBuscar_Leave(object sender, EventArgs e)
        {
            if (txtCedulaEmpleadoBuscar.Text != "")
            {
                if (!ValidarCedula.validarCedula(txtCedulaEmpleadoBuscar.Text))
                {
                    Mensajes.emitirMensaje("Número de Cédula invalida");
                    txtCedulaEmpleadoBuscar.Text = "";
                    txtCedulaEmpleadoBuscar.Focus();
                }
            }
        }

        private void txtCedulaEmpleadoDarDeBaja_Leave(object sender, EventArgs e)
        {
            if (txtCedulaEmpleadoDarDeBaja.Text != "")
            {
                if (!ValidarCedula.validarCedula(txtCedulaEmpleadoDarDeBaja.Text))
                {
                    Mensajes.emitirMensaje("Número de Cédula invalida");
                    txtCedulaEmpleadoDarDeBaja.Text = "";
                    txtCedulaEmpleadoDarDeBaja.Focus();
                }
            }
        }
    }
}