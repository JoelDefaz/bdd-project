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
    public partial class frmAdmParametros : Form
    {
        public frmAdmParametros()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Close();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (!Validaciones.estanLlenosLosCampos(getDatos())){
                Mensajes.emitirMensaje("Los datos no pueden estar en blanco – Por favor Llenar");
                return;
            }
            if (!Validaciones.validarParametros(getDatos()))
            {
                Mensajes.emitirMensaje("Datos incorrectos – Vuelva a ingresar”");
                return;
            }
            if (!Parametros.registrarParametro(getDatos()))
            {
                Mensajes.emitirMensaje("Error al registrar el parámetro");
            }
        }

        private string[] getDatos()
        {
            string[] datos = new string[3];
            datos[0] = txtNombreRegistrar.Text;
            datos[1] = txtValorRegistrar.Text;
            DateTime fechaSeleccionada = dateRegister.Value;
            datos[2] = fechaSeleccionada.ToString("yyyy-MM-dd");
            return datos;
        }

        private void btnBuscarActualizar_Click(object sender, EventArgs e)
        {
            if (txtNombreActualizar.Text == "")
            {
                Mensajes.emitirMensaje("El nombre del parámetro no puede estar vacío – Por favor llenar");
                return;
            }
            string datosActualizar = Parametros.getParametro(txtNombreActualizar.Text);
            if (datosActualizar != "")
            {
                txtValorActualizar.Text = datosActualizar;
            }
        }

        private string[] getDatosActualizar()
        {
            string[] datos = new string[2];
            datos[0] = txtValorActualizar.Text;
            DateTime fechaSeleccionada = dtpFechaActualizacion.Value;
            datos[1] = fechaSeleccionada.ToString("yyyy-MM-dd");
            return datos;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (!Validaciones.validarParametros(getDatosActualizar()))
            {
                Mensajes.emitirMensaje("Datos incorretos - Por favor corregir");
                return;
            }
            if (!Parametros.actualizarParametro(txtNombreActualizar.Text, getDatosActualizar()))
            {
                Mensajes.emitirMensaje("Erro al actualizar este dato");
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtNombreBusqueda.Text == "")
            {
                Mensajes.emitirMensaje("El nombre del parámetro no puede estar vacío – Por favor llenar");
                return;
            }
            string[] datosConsulta = Parametros.getParametroBusqueda(txtNombreBusqueda.Text);
            if (datosConsulta != null)
            {
                txtNombre.Text = txtNombreBusqueda.Text;
                txtValorBusqueda.Text = datosConsulta[0];
                txtFechaModificacion.Text = datosConsulta[1];
            }
        }
    }
}
