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
    public partial class frmAdministracion : Form
    {
        public frmAdministracion()
        {
            InitializeComponent();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
                frmAdministrarUsuarios usuarios = new frmAdministrarUsuarios();
                usuarios.ShowDialog();
        }

        private void btnParámetros_Click(object sender, EventArgs e)
        {
            frmAdmParametros parametros = new frmAdmParametros();
            parametros.ShowDialog();
        }

        private void frmAdministracion_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
