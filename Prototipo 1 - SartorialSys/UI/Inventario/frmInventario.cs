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
    public partial class frmInventario : Form
    {
        bool permiso;
        string codigoConsulta;
        public frmInventario(bool permiso)
        {
            InitializeComponent();
            this.permiso = permiso;
        }
        
        public frmInventario(string codigo)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.Sizable;
            tabInventario.SelectedIndex = 0;
            txtcodigoBusqueda.Text = codigo;
            label12.Visible = true;
            txtPrecioVenta.Visible = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Produto Registrado con exito");
        }

        private void frmInventario_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string[] datosProducto = Inventario.getDatosProducto(txtcodigoBusqueda.Text);
            if(datosProducto != null)
            {
                txtDescripcionConsulta.Text = datosProducto[0];
                txtCategoriaConsulta.Text = datosProducto[1];
                txtColorConsulta.Text = datosProducto[2];
                txtTallaConsulta.Text = datosProducto[3];
                txtStockConsulta.Text = datosProducto[4];
                txtPrecioVenta.Text = datosProducto[5];
            }
        }

        private void bntBuscarActualizar_Click(object sender, EventArgs e)
        {
            string[] datosProducto = Inventario.getDatosProducto(txtParametroActualizar.Text);
            if (datosProducto != null)
            {
                txtDescripcionActualizar.Text = datosProducto[0];
                txtCategoriaActualizar.Text = datosProducto[1];
                txtColorActualizar.Text = datosProducto[2];
                txtTallaActualizar.Text = datosProducto[3];
                txtStockActualizar.Text = datosProducto[4];
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            DateTime fechaSeleccionada = dtpFechaActualizacion.Value;
            if (txtIngresoProducto.Text == "")
            {
                txtIngresoProducto.Text = "0";
            }
            if(txtEgresoProducto.Text == "")
            {
                txtEgresoProducto.Text = "0";
            }
            int ingreso = Convert.ToInt32(txtIngresoProducto.Text) - Convert.ToInt32(txtEgresoProducto.Text);
            if (Convert.ToInt32(txtIngresoProducto.Text) > Convert.ToInt32(txtEgresoProducto.Text)) {
                Inventario.actualizarInventario(txtParametroActualizar.Text, ingreso, fechaSeleccionada.ToString("yyyy-MM-dd"));
            }
            else
            {
                if(Convert.ToInt32(txtStockActualizar.Text) + ingreso < 0)
                {
                    Mensajes.emitirMensaje("Error al actualizar este dato");
                    txtIngresoProducto.Text = "";
                    txtEgresoProducto.Text = "";
                    return;
                }
                Inventario.actualizarInventario(txtParametroActualizar.Text, ingreso, fechaSeleccionada.ToString("yyyy-MM-dd"));
            }
            bntBuscarActualizar.PerformClick();
            txtIngresoProducto.Text = "";
            txtEgresoProducto.Text = "";
        }

        private void txtcodigoBusqueda_Leave(object sender, EventArgs e)
        {
            if (txtcodigoBusqueda.Text != "")
            {
                if (!Validaciones.esValidoCodigoProducto(txtcodigoBusqueda.Text))
                {
                    Mensajes.emitirMensaje("Número de teléfono equivocado");
                    txtcodigoBusqueda.Text = "";
                    txtcodigoBusqueda.Focus();
                }
            }
        }

        private void txtParametroActualizar_Leave(object sender, EventArgs e)
        {
            if (txtParametroActualizar.Text != "")
            {
                if (!Validaciones.esValidoCodigoProducto(txtParametroActualizar.Text))
                {
                    Mensajes.emitirMensaje("Número de teléfono equivocado");
                    txtParametroActualizar.Text = "";
                    txtParametroActualizar.Focus();
                }
            }
        }
    }
}
