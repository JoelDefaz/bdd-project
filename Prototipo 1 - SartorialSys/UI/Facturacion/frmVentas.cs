using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;
using Prototipo_1___SartorialSys.Clases;
using Prototipo_1___SartorialSys.Formularios;

namespace Prototipo_1___SartorialSys
{
    public partial class frmVentas : Form
    {
        bool permiso;
        private struct RGBColor
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 128, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);

        }
        public frmVentas(bool permiso)
        {
            InitializeComponent();
            this.permiso = permiso;
            string iva = "(" + (Convert.ToInt32(Parametros.getIVA()*100)).ToString() + "%):";
            label8.Text += iva;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Venta Registrada con exito");
            limpiarConsola();
        }

        private void limpiarConsola()
        {
            txtCedulaRegistrar.Text = "";
            txtSubtotalRegistrar.Text = "";
            txtIvaRegistrar.Text = "";
            txtTotalRegistrar.Text = "";
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {

        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarConsola();
        }


        private void btnCancelarBusqueda_Click(object sender, EventArgs e)
        {
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Venta eliminada con exito");
        }

        private void frmVentas_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnBuscarCliente_Click_1(object sender, EventArgs e)
        {
            string[] datosCliente = Cliente.buscarCliente(txtCedulaRegistrar.Text);
            if (!existeRegistro(datosCliente[0]))
            {
                if(!Mensajes.confirmarAccion("Desea registrar al cliente"))
                {
                    vaciarDatos();
                    return;
                }
                frmClientes clientes = new frmClientes();
                clientes.ShowDialog();
                return;
            }
            txtCedulaRegistrar.Text = datosCliente[0];
            txtNombresRegistrar.Text = datosCliente[1];
            txtApellidosRegistrar.Text = datosCliente[2];
            txtDireccionRegistrar.Text = datosCliente[3];
            txtCorreoRegistrar.Text = datosCliente[4];
            txtTelefonoRegistrar.Text = datosCliente[5];
        }

        private void vaciarDatos()
        {
            txtCedulaRegistrar.Text = "";
            txtNombresRegistrar.Text = "";
            txtApellidosRegistrar.Text = "";
            txtDireccionRegistrar.Text = "";
            txtCorreoRegistrar.Text = "";
            txtTelefonoRegistrar.Text = "";
        }

        private bool existeRegistro(string cedula)
        {
            return cedula != null;
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            frmAgregarProducto agregarProducto = new frmAgregarProducto(dgtvListaProductos);
            agregarProducto.ShowDialog();
            txtSubtotalRegistrar.Text = getSumatoria();
            txtIvaRegistrar.Text = getIVA();
            txtTotalRegistrar.Text = getTotal();
        }

        private string getTotal()
        {
            return (Convert.ToInt32(txtSubtotalRegistrar.Text) + Convert.ToDecimal(txtIvaRegistrar.Text)).ToString();
        }

        private string getIVA()
        {
            return (Convert.ToInt32(txtSubtotalRegistrar.Text) * (Parametros.getIVA())).ToString();
        }

        private string getSumatoria()
        {
            int subtotal = 0;
            foreach (DataGridViewRow fila in dgtvListaProductos.Rows)
            {
                subtotal += Convert.ToInt32((fila.Cells[4].Value))*Convert.ToInt32((fila.Cells[3].Value));
            }
            return subtotal.ToString();
        }

        private void btnBuscarConsultar_Click_1(object sender, EventArgs e)
        {
            string[] resultados = Ventas.consultarVenta(txtNumeroFacturaConsultar.Text);
            string[,] datosItems = Ventas.getItemsFactura(resultados[0]);

            if (resultados != null && datosItems != null)
            {
                txtNumeroFacturaBusqueda.Text = resultados[0];
                txtCedulaBusqueda.Text = resultados[1];
                txtNombreBusqueda.Text = resultados[2];
                txtApellidoBusqueda.Text = resultados[3];
                txtDireccionConsultar.Text = resultados[4];
                txtTelefonoBusqueda.Text = resultados[5];
                txtCorreoBusqueda.Text= resultados[6];
                txtFechaVentaBusqueda.Text = resultados[7];
                txtMetodoPagoBusqueda.Text = resultados[8];
                txtSubtotalBusqueda.Text = resultados[9];
                txtIvaBusqueda.Text = resultados[10];
                txtTotalBusqueda.Text = resultados[11];
                txtEstadoPagoBusqueda.Text = resultados[12];
                txtAnuladoBusqueda.Text = resultados[13];
                mostrarProductosComprados(dataGridView1, datosItems);
            }
        }

        private void mostrarProductosComprados(DataGridView dataGridView, string[,] items)
        {
            for(int i = 0; i < items.GetLength(0); i++)
            {
                if (items[i,0] == null)
                {
                    break;
                }
                int n = dataGridView.Rows.Add();
                dataGridView.Rows[n].Cells[0].Value = (i+1);
                dataGridView.Rows[n].Cells[1].Value = items[i,0];
                dataGridView.Rows[n].Cells[2].Value = items[i, 1];
                dataGridView.Rows[n].Cells[3].Value = items[i,2];
                dataGridView.Rows[n].Cells[4].Value = items[i, 3];
            }
        }

        private void btnActualizarInformacion_Click(object sender, EventArgs e)
        {
            frmClientes clientes = new frmClientes(txtCedulaRegistrar.Text, 0);
            clientes.ShowDialog();
        }

        private void btnRegistrarVenta_Click(object sender, EventArgs e)
        {
            string[] datos = getDatoVenta();
            if (!Validaciones.estanLlenosLosCampos(datos))
            {
                Mensajes.emitirMensaje("Los datos no pueden estar vacíos - Por favor Llenar");
                limpiarRegistro();
                return;
            }
            string[,] items = getItems();
            if (!Ventas.registrarVenta(datos,items))
            {
                Mensajes.emitirMensaje("Error al registrar la venta");
                limpiarRegistro();
                return;
            }
            else 
            { 
            Mensajes.emitirMensaje("Venta registrada con éxito");
            Inventario.actualizarInventario(items); 
                limpiarRegistro();
            }
        }

        private void limpiarRegistro()
        {
            txtCedulaRegistrar.Text = "";
            txtNombresRegistrar.Text = "";
            txtApellidosRegistrar.Text = "";
            txtDireccionRegistrar.Text = "";
            txtTelefonoRegistrar.Text = "";
            txtCorreoRegistrar.Text = "";
            cmbMetodoPago.Text = "Seleccione";
            cmbEstadoPago.Text = "Seleccione";
            txtSubtotalRegistrar.Text = "";
            txtIvaRegistrar.Text = "";
            txtTotalRegistrar.Text = "";
            dgtvListaProductos.Rows.Clear();
        }

        private string[,] getItems()
        {
            int filas = dgtvListaProductos.RowCount-1;
            string[,] items = new string[filas,3];
            for (int i = 0; i < filas; i++)
            {
                items[i,0] = dgtvListaProductos.Rows[i].Cells[1].Value.ToString();
                items[i,1] = dgtvListaProductos.Rows[i].Cells[3].Value.ToString();
                items[i,2] = dgtvListaProductos.Rows[i].Cells[4].Value.ToString();
            }
            return items;
        }
        private string[] getDatoVenta()
        {
            string[] datos = new string[9];
            datos[1] = txtCedulaRegistrar.Text;
            DateTime fechaSeleccionada = dtpFechaVenta.Value;
            datos[2] = fechaSeleccionada.ToString("yyyy-MM-dd");
            datos[3] = cmbMetodoPago.Text;
            if(cmbEstadoPago.Text == "Pagado")
            {
                datos[4] = "1";
            }
            else
            {
                datos[4] = "0";
            }
            datos[5] = txtSubtotalRegistrar.Text;
            datos[6] = txtIvaRegistrar.Text;
            datos[7] = txtTotalRegistrar.Text;
            datos[8] = "DEFAULT";
            return datos;
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

        private void dgtvListaProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                if(Mensajes.confirmarAccion("¿Desea quitar este producto de la venta?"))
                {
                    int indice = e.RowIndex;
                    dgtvListaProductos.Rows.RemoveAt(indice);
                    dgtvListaProductos.Refresh();
                    txtSubtotalRegistrar.Text = getSumatoria();
                    txtIvaRegistrar.Text = getIVA();
                    txtTotalRegistrar.Text = getTotal();
            }
        }

        private void btnCancelarRegistro_Click(object sender, EventArgs e)
        {
            limpiarRegistro();
        }

        private void btnCancelarBusqueda_Click_1(object sender, EventArgs e)
        {
            limpiarBusqueda();
        }

        private void limpiarBusqueda()
        {
            txtNumeroFacturaBusqueda.Text = "";
            txtCedulaBusqueda.Text = "";
            txtNombreBusqueda.Text = "";
            txtApellidoBusqueda.Text = "";
            txtDireccionConsultar.Text = "";
            txtTelefonoBusqueda.Text = "";
            txtCorreoBusqueda.Text = "";
            txtFechaVentaBusqueda.Text = "";
            txtMetodoPagoBusqueda.Text = "";
            txtSubtotalBusqueda.Text = "";
            txtIvaBusqueda.Text = "";
            txtTotalBusqueda.Text = "";
            txtEstadoPagoBusqueda.Text = "";
            txtAnuladoBusqueda.Text = "";
            dataGridView1.Rows.Clear();
        }

        private void btnBuscarAnular_Click(object sender, EventArgs e)
        {
            string[] resultados = Ventas.consultarVenta(txtNFacturaBuscarAnular.Text);
            string[,] datosItems = Ventas.getItemsFactura(txtNFacturaBuscarAnular.Text);

            if (resultados != null && datosItems != null)
            {
                txtNumeroFacturaAnular.Text = resultados[0];
                txtCedulaAnular.Text = resultados[1];
                txtNmbresAnular.Text = resultados[2];
                txtApellidoAnular.Text = resultados[3];
                txtDireccionAnular.Text = resultados[4];
                txtTelefonoAnular.Text = resultados[5];
                txtCorreoAnular.Text = resultados[6];
                txtFechaVentaAnular.Text = resultados[7];
                txtMetodoPagoAnular.Text = resultados[8];
                txtSubtotalAnular.Text = resultados[9];
                txtIvaAnular.Text = resultados[10];
                txtTotalAnular.Text = resultados[11];
                txtEstadoPagoAnular.Text = resultados[12];
                txtAnuladoAnular.Text = resultados[13];
                mostrarProductosComprados(dataGridView2,datosItems);
            }
        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void btnCancelarEliminar_Click(object sender, EventArgs e)
        {
            txtNumeroFacturaAnular.Text = "";
            txtCedulaAnular.Text = "";
            txtNmbresAnular.Text = "";
            txtApellidoAnular.Text = "";
            txtDireccionAnular.Text = "";
            txtTelefonoAnular.Text = "";
            txtCorreoAnular.Text = "";
            txtFechaVentaAnular.Text = "";
            txtMetodoPagoAnular.Text = "";
            txtSubtotalAnular.Text = "";
            txtIvaAnular.Text = "";
            txtTotalAnular.Text = "";
            txtEstadoPagoAnular.Text = "";
            txtAnuladoAnular.Text = "";
            dataGridView2.Rows.Clear();
        }
        object contenidoCelda;
        DataGridViewColumn columnaSeleccionada;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 1)
            {
                columnaSeleccionada = dataGridView1.Columns[e.ColumnIndex];
                contenidoCelda = dataGridView1.Rows[e.RowIndex].Cells[columnaSeleccionada.Index].Value;
                frmInventario inventario = new frmInventario(contenidoCelda.ToString());
                inventario.ShowDialog();
                columnaSeleccionada = null;
                contenidoCelda = "";
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == 1)
            {
                columnaSeleccionada = dataGridView1.Columns[e.ColumnIndex];
                contenidoCelda = dataGridView1.Rows[e.RowIndex].Cells[columnaSeleccionada.Index].Value;
                frmInventario inventario = new frmInventario(contenidoCelda.ToString());
                inventario.ShowDialog();
                columnaSeleccionada = null;
                contenidoCelda = "";
            }
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (!Ventas.anularFactura(txtNumeroFacturaAnular.Text))
            {
                Mensajes.emitirMensaje("Error al anular la factura");
                return;
            }
        }

        private void txtNumeroFacturaConsultar_Leave(object sender, EventArgs e)
        {
            if (txtNumeroFacturaConsultar.Text == "")
            {
                Mensajes.emitirMensaje("El número de factura no puede estar en blanco – Por favor llenar");
                return;
            }
            if (!Validaciones.esValidoElNumeroDeFactura(txtNumeroFacturaConsultar.Text))
            {
                Mensajes.emitirMensaje("Número de factura equivocada – vuelva a ingresar");
                return;
            }
        }

        private void txtNFacturaBuscarAnular_Leave(object sender, EventArgs e)
        {
            if (txtNumeroFacturaConsultar.Text == "")
            {
                Mensajes.emitirMensaje("El número de factura no puede estar en blanco – Por favor llenar");
                return;
            }
            if (!Validaciones.esValidoElNumeroDeFactura(txtNumeroFacturaConsultar.Text))
            {
                Mensajes.emitirMensaje("Número de factura equivocada – vuelva a ingresar");
                return;
            }
        }
    }
}
