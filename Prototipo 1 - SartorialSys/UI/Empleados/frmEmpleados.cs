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
    public partial class frmEmpleados : Form
    {
        public frmEmpleados()
        {
            InitializeComponent();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            DateTime fechaSeleccionada = dtpFechaIngreso.Value;
            string[] datosEmpleado = { 
                txtCedulaRegistrar.Text,
                txtNombresRegistrar.Text,
                txtApellidosRegistrar.Text,
                txtDireccionRegistrar.Text,
                txtCorreoRegistrar.Text,
                txtTelefonoRegistrar.Text,
                txtSalarioRegistrar.Text,
                txtHEntrada.Text,
                txtHAlmuerzo.Text,
                txtHSalida.Text,
                fechaSeleccionada.ToString("yyyy-MM-dd")};
            if (Empleados.registrarEmpleado(datosEmpleado))
            {
                limpiarRegistro();
            }
            else
            {
                Mensajes.emitirMensaje("Ocurrio un error al ingresar el nuevo empleado");
            }
        }

        private void limpiarRegistro()
        {
            txtCedulaRegistrar.Text = "";
            txtNombresRegistrar.Text = "";
            txtApellidosRegistrar.Text = "";
            txtDireccionRegistrar.Text = "";
            txtCorreoRegistrar.Text = "";
            txtTelefonoRegistrar.Text = "";
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
    }
}
