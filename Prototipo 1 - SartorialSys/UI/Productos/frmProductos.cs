using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Prototipo_1___SartorialSys.Clases;

namespace Prototipo_1___SartorialSys.Formularios
{
    public partial class frmProductos : Form
    {
        public frmProductos()
        {
            InitializeComponent();
            agregarOpciones();
        }

        private void agregarOpciones()
        {
            string[] colores = Productos.getColores();
            foreach (string color in colores) { 
                cmbColorRegistrar.Items.Add(color);
            }
            string[] tallas = Productos.getTallas();
            foreach (string talla in tallas)
            {
                cmbTallaRegistrar.Items.Add(talla);
            }
        }

        private void txtCodigoRegistrar_Leave(object sender, EventArgs e)
        {
            if (txtCodigoRegistrar.Text != "" && !Validaciones.esValidoCodigoProducto(txtCodigoRegistrar.Text))
            {
                Mensajes.emitirMensaje("Datos incorrectos");
                txtCodigoRegistrar.Text = "";
            }
        }

        private void txtDescripcionRegistrar_Leave(object sender, EventArgs e)
        {/*
            if (txtDescripcionRegistrar.Text != "" && !Validaciones.esValidoDescripcion(txtDescripcionRegistrar.Text))
            {
                Mensajes.emitirMensaje("Datos incorrectos");
                txtDescripcionRegistrar.Text = "";
            }*/
        }

        private void cmbCategoriaRegistrar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbCategoriaRegistrar.SelectedIndex != 0)
            {
                cmbTallaRegistrar.Enabled = false;
                txtPrecioVenta.Enabled = false;
            }
            else
            {
                cmbTallaRegistrar.Enabled = true;
                txtPrecioVenta.Enabled = false;
            }
        }

        private void txtRUCProveedorRegistrar_Leave(object sender, EventArgs e)
        {
            if (txtRUCProveedorRegistrar.Text != "" && !Validaciones.esRUCValido(txtRUCProveedorRegistrar.Text))
            {
                Mensajes.emitirMensaje("Datos incorrectos");
                txtRUCProveedorRegistrar.Text = "";
            }
        }

        private void txtCantidadInicialRegistrar_Leave(object sender, EventArgs e)
        {
            if (txtCantidadInicialRegistrar.Text != "" && !Validaciones.esCantidadValida(txtCantidadInicialRegistrar.Text))
            {
                Mensajes.emitirMensaje("Datos incorrectos");
                txtCantidadInicialRegistrar.Text = "";
            }
        }

        private void txtPrecioCompraRegistrar_Leave(object sender, EventArgs e)
        {
            if (txtPrecioCompraRegistrar.Text != "" && !Validaciones.esCantidadDecimalValida(txtPrecioCompraRegistrar.Text))
            {
                Mensajes.emitirMensaje("Datos incorrectos");
                txtPrecioCompraRegistrar.Text = "";
            }
        }

        private void txtPrecioVenta_Leave(object sender, EventArgs e)
        {
            if (txtPrecioVenta.Text != "" && !Validaciones.esCantidadDecimalValida(txtPrecioCompraRegistrar.Text))
            {
                Mensajes.emitirMensaje("Datos incorrectos");
                txtPrecioVenta.Text = "";
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string[] datos = getDatos();
            if (!Validaciones.estanLlenosLosCampos(datos))
            {
                Mensajes.emitirMensaje("Los datos no pueden estar vacíos - Por favor Llenar");
                txtPrecioVenta.Text = "";
                return;
            }
            if (!Productos.registrarProducto(datos))
            {
                Mensajes.emitirMensaje("Error al registrar el producto");
                return;
            }
            Mensajes.emitirMensaje("Producto registrado con éxito");
        }

        private string[] getDatos()
        {
            string[] datos = new string[10];
            datos[0] = txtCodigoRegistrar.Text;
            datos[1] = txtDescripcionRegistrar.Text;
            datos[2] = cmbCategoriaRegistrar.Text;
            datos[3] = cmbColorRegistrar.Text;
            if(cmbCategoriaRegistrar.Text == "Prenda")
            {
                datos[4] = cmbTallaRegistrar.Text;
                datos[8] = txtPrecioVenta.Text;
            }
            else
            {
                datos[4] = null;
                datos[8] = null;
            }
            datos[5] = txtRUCProveedorRegistrar.Text;
            datos[6] = txtCantidadInicialRegistrar.Text;
            datos[7] = txtPrecioCompraRegistrar.Text;
            DateTime fechaSeleccionada = dtpFechaRegistro.Value;
            datos[9] = fechaSeleccionada.ToString("yyyy-MM-dd");
            return datos;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if(txtParametroConsulta.Text == "")
            {
                Mensajes.emitirMensaje("El código del producto no puede estar vacío – Por favor llenar");
                return;
            }
            if (!Validaciones.esValidoCodigoProducto(txtParametroConsulta.Text))
            {
                Mensajes.emitirMensaje("Código del producto equivocado – Vuelva a ingresar");
            }
            string[] datos = Productos.datosProducto(txtParametroConsulta.Text);
            if(datos != null)
            {
                txtCodigoBusqueda.Text = txtParametroConsulta.Text;
                txtDescripcionConsulta.Text = datos[0];
                txtCategoriaConsulta.Text = datos[1];
                txtColorConsulta.Text= datos[2];
                txtTallaConssulta.Text = datos[3];
                txtRUCProveedorConsulta.Text = datos[4];
                txtStockConsulta.Text = datos[5];
                txtPrecioCompraConsulta.Text = datos[6];
                txtPrecioVentaConsulta.Text = datos[7];
                txtFechaIngresoConsulta.Text = datos[8];
                txtFechaActualizacionConsulta.Text = datos[9];
            }
        }

        private void btnBuscarActualizar_Click(object sender, EventArgs e)
        {
            if (txtParametroActualizar.Text == "")
            {
                Mensajes.emitirMensaje("El código del producto no puede estar vacío – Por favor llenar");
                return;
            }
            if (!Validaciones.esValidoCodigoProducto(txtParametroActualizar.Text))
            {
                Mensajes.emitirMensaje("Código del producto equivocado – Vuelva a ingresar");
            }
            string[] datos = Productos.datosProducto(txtParametroActualizar.Text);
            if (datos != null)
            {
                txtCodigoActualizar.Text = txtParametroActualizar.Text;
                txtDescripcionActualizar.Text = datos[0];
                txtCategoriaActualizar.Text = datos[1];
                txtColorActualizar.Text = datos[2];
                txtTallaActualizar.Text = datos[3];
                txtRUCProveedorActualizar.Text = datos[4];
                txtStockActualizar.Text = datos[5];
                txtPrecioCompraActualizar.Text = datos[6];
                txtPrecioVentaActualizar.Text = datos[7];
                txtFechaIngresoActualizar.Text = datos[8];
                txtUltimaActualizacionACtualizar.Text = datos[9];
            }
        }

        private void ckbPrecioCompra_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbPrecioCompra.Checked)
            {
                txtPrecioCompraActualizar.ReadOnly = false;
            }
            else
            {
                txtPrecioCompraActualizar.ReadOnly = true;
            }
        }

        private void ckbPrecioVenta_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbPrecioVenta.Checked)
            {
                txtPrecioVentaActualizar.ReadOnly = false;
            }
            else
            {
                txtPrecioVentaActualizar.ReadOnly = true;
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (ckbPrecioCompra.Checked)
            {
                if (Productos.actualizarPrecioCompra(txtPrecioCompraActualizar.Text, txtCodigoActualizar.Text))
                {
                    btnBuscarActualizar.PerformClick();
                    ckbPrecioCompra.Checked = false;
                }
                else
                {
                    Mensajes.emitirMensaje("Error al actualizar este dato”");
                }
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            if (ckbPrecioVenta.Checked)
            {
                if (Productos.actualizarPrecioVenta(txtPrecioVentaActualizar.Text, txtCodigoActualizar.Text))
                {
                    btnBuscarActualizar.PerformClick();
                    ckbPrecioVenta.Checked = false;
                }
                else
                {
                    Mensajes.emitirMensaje("Error al actualizar este dato”");
                }
            }
        }

        private void btnBuscarDarDeBaja_Click(object sender, EventArgs e)
        {
            if (txtParametroDarDeBaja.Text == "")
            {
                Mensajes.emitirMensaje("El código del producto no puede estar vacío – Por favor llenar");
                return;
            }
            if (!Validaciones.esValidoCodigoProducto(txtParametroDarDeBaja.Text))
            {
                Mensajes.emitirMensaje("Código del producto equivocado – Vuelva a ingresar");
            }
            string[] datos = Productos.datosProducto(txtParametroDarDeBaja.Text);
            if (datos != null)
            {
                txtCodigoDarDeBaja.Text = txtParametroDarDeBaja.Text;
                txtDescripcionDarDeBaja.Text = datos[0];
                txtCategoriaDarDeBaja.Text = datos[1];
                txtColorDarDeBaja.Text = datos[2];
                txtTallaDarDeBaja.Text = datos[3];
                txtRUCDarDeBaja.Text = datos[4];
                txtStockDarDeBaja.Text = datos[5];
                txtPrecioCompraDarBaja.Text = datos[6];
                txtPrecioVentaDarBaja.Text = datos[7];
                txtFechaIngresoDarBaja.Text = datos[8];
                txtFechaActualizacionDarBaja.Text = datos[9];
            }
        }

        private void bntDarDeBaja_Click(object sender, EventArgs e)
        {
            if (Productos.darDeBaja(txtParametroDarDeBaja.Text))
            {
                limpiarDarDeBaja();
            }
        }

        private void limpiarDarDeBaja()
        {
            txtParametroDarDeBaja.Text = "";
            txtCodigoDarDeBaja.Text = "";
            txtDescripcionDarDeBaja.Text = "";
            txtCategoriaDarDeBaja.Text = "";
            txtColorDarDeBaja.Text = "";
            txtTallaDarDeBaja.Text = "";
            txtRUCDarDeBaja.Text = "";
            txtStockDarDeBaja.Text = "";
            txtPrecioCompraDarBaja.Text = "";
            txtPrecioVentaDarBaja.Text = "";
            txtFechaIngresoDarBaja.Text = "";
            txtFechaActualizacionDarBaja.Text = "";
        }

        private void txtParametroConsulta_Leave(object sender, EventArgs e)
        {
            if (txtParametroConsulta.Text != "")
            {
                if (!Validaciones.esValidoCodigoProducto(txtParametroConsulta.Text))
                {
                    Mensajes.emitirMensaje("Número de teléfono equivocado");
                    txtParametroConsulta.Text = "";
                    txtParametroConsulta.Focus();
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