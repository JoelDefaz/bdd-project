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
            if (!ValidarCedula.estanLosCamposLlenos(datosEmpleado))
            {
                Mensajes.emitirMensaje("Los datos no pueden estar vacíos – Por favor llenar");
                return;
            }
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
                if (!ValidarCedula.validarCedula(txtCedulaRegistrar.Text))
                {
                    Mensajes.emitirMensaje("Número de Cédula inválida");
                    txtCedulaRegistrar.Text = "";
                    txtCedulaRegistrar.Focus();
                }
            }
        }

        private void txtNombresRegistrar_Leave(object sender, EventArgs e)
        {
            if (txtNombresRegistrar.Text != "")
            {
                if (!Validaciones.validarNombrApellido(txtNombresRegistrar.Text))
                {
                    Mensajes.emitirMensaje("Nombres equivocados");
                    txtNombresRegistrar.Text = "";
                    txtNombresRegistrar.Focus();
                }
            }
        }

        private void txtApellidosRegistrar_Leave(object sender, EventArgs e)
        {
            if (txtApellidosRegistrar.Text != "")
            {
                if (!Validaciones.validarNombrApellido(txtApellidosRegistrar.Text))
                {
                    Mensajes.emitirMensaje("Apellidos equivocados");
                    txtApellidosRegistrar.Text = "";
                    txtApellidosRegistrar.Focus();
                }
            }
        }

        private void txtTelefonoRegistrar_Leave(object sender, EventArgs e)
        {
            if (txtTelefonoRegistrar.Text != "")
            {
                if (!Validaciones.validarTelefono(txtTelefonoRegistrar.Text))
                {
                    Mensajes.emitirMensaje("Número de teléfono equivocado");
                    txtTelefonoRegistrar.Text = "";
                    txtTelefonoRegistrar.Focus();
                }
            }
        }

        private void txtCorreoRegistrar_Leave(object sender, EventArgs e)
        {
            if (txtCorreoRegistrar.Text != "")
            {
                if (!Validaciones.ValidarCorreoElectronico(txtCorreoRegistrar.Text))
                {
                    Mensajes.emitirMensaje("Correo Electrónico equivocado");
                    txtCorreoRegistrar.Text = "";
                    txtCorreoRegistrar.Focus();
                }
            }
        }

        private void txtSalarioRegistrar_Leave(object sender, EventArgs e)
        {
            if (txtSalarioRegistrar.Text != "")
            {
                if (!Validaciones.esCantidadDecimalValida(txtSalarioRegistrar.Text))
                {
                    Mensajes.emitirMensaje("Valor no válido");
                    txtSalarioRegistrar.Text = "";
                    txtSalarioRegistrar.Focus();
                }
            }
        }

        private void txtHEntrada_Leave(object sender, EventArgs e)
        {
            if (txtHEntrada.Text != "")
            {
                if (!Validaciones.validarHora(txtHEntrada.Text))
                {
                    Mensajes.emitirMensaje("Hora no válida");
                    txtHEntrada.Text = "";
                    txtHEntrada.Focus();
                }
            }
        }

        private void txtHAlmuerzo_Leave(object sender, EventArgs e)
        {
            if (txtHAlmuerzo.Text != "")
            {
                if (!Validaciones.validarHora(txtHAlmuerzo.Text))
                {
                    Mensajes.emitirMensaje("Hora no válida");
                    txtHAlmuerzo.Text = "";
                    txtHAlmuerzo.Focus();
                }
            }
        }

        private void txtHSalida_Leave(object sender, EventArgs e)
        {
            if (txtHSalida.Text != "")
            {
                if (!Validaciones.validarHora(txtHSalida.Text))
                {
                    Mensajes.emitirMensaje("Hora no válida");
                    txtHSalida.Text = "";
                    txtHSalida.Focus();
                }
            }
        }
    }
}
