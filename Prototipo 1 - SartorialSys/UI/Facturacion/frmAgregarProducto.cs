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

namespace Prototipo_1___SartorialSys.Formularios
{
    public partial class frmAgregarProducto : Form
    {
        int i = 1;
        private DataGridView listaProductos;

        public frmAgregarProducto(DataGridView dgtvListaProductos)
        {
            InitializeComponent();
            this.listaProductos = dgtvListaProductos;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!Validaciones.esValidoCodigoProducto(txtCodigoProducto.Text))
            {
                Mensajes.emitirMensaje("Código de producto no válido");
                txtCodigoProducto.Text = "";
                this.Close();
            }
            if (!Productos.buscarProducto(i,txtCodigoProducto.Text,listaProductos,txtCantidad.Text))
            {
                txtCodigoProducto.Text = "";
                this.Close();
            }
            i++;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
