using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using FontAwesome.Sharp;
using Prototipo_1___SartorialSys.Clases;
using Prototipo_1___SartorialSys.Formularios;

namespace Prototipo_1___SartorialSys
{

    public partial class frmMenu : Form
    {
        //Fields
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentchildForm;
        private string usuario;
        private bool permiso;

        //
        public frmMenu(string usuario_actual)
        {
            InitializeComponent();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            pnlMenu.Controls.Add(leftBorderBtn);
            this.usuario = usuario_actual;
            this.permiso = Usuario.tienePermisos(usuario_actual);
            Form currentchildForm;
            label1.Text += usuario_actual;
            activarBotones();
        }

        private void activarBotones()
        {
            if (!permiso)
            {
                btnProductos.Visible = false;
                btnPedidos.Visible = false;
                btnProveedores.Visible = false;
                btnEmpleados.Visible = false;
                btnAdministracion.Visible = false;
                btnAuditoria.Visible = false;
            }
        }

        //Structure
        private struct RGBColor
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3  = Color.FromArgb(253, 128, 114);
            public static Color color4  = Color.FromArgb(95, 77, 221);
            public static Color color5  = Color.FromArgb(249, 88, 155);
            public static Color color6  = Color.FromArgb(24, 161, 251);

        }
        //Métodos
        public void ActivateButton(Object sender, Color color)
        {
            if(sender != null)
            {
                DisableButton();
                currentBtn = (IconButton)sender;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.IconColor = color;
                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
            }
        }

        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(210, 189, 165);
                currentBtn.ForeColor = Color.FromArgb(60, 60, 60);
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.FromArgb(60, 60, 60);
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        public void openFormChild(Form childForm)
        {
            if (currentchildForm != null)
            {
                currentchildForm.Close();
            }
            currentchildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnlEscritorio.Controls.Add(childForm);
            pnlEscritorio.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        private void btnBarras_Click(object sender, EventArgs e)
        {
            if (pnlMenu.Width == 213)
            {
                pnlMenu.Width = 68;
            }
            else
                pnlMenu.Width = 213;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Close();
            frmInicio inicio = new frmInicio();
            inicio.ShowDialog();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColor.color1);
            openFormChild(new frmClientes(permiso));
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColor.color2);
            openFormChild(new frmProveedores());
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColor.color3);
            openFormChild(new frmProductos());
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColor.color4);
            openFormChild(new frmInventario(permiso));
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColor.color5);
            openFormChild(new frmPedidos());
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColor.color6);
            openFormChild(new frmVentas(permiso));
        }

        private void btnAdministracion_Click(object sender, EventArgs e)
        {
                ActivateButton(sender, RGBColor.color1);
                openFormChild(new frmAdministracion());   
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColor.color1);
            openFormChild(new frmEmpleados());
        }

        private void horafecha_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void lblHora_Click(object sender, EventArgs e)
        {

        }
    }
}
