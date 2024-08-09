using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Prototipo_1___SartorialSys.BL.BD;
using Prototipo_1___SartorialSys.Clases;

namespace Prototipo_1___SartorialSys.UI.Auditoria
{
    public partial class frmAuditoria : Form
    {
        public frmAuditoria()
        {
            InitializeComponent();
            setTablaAuditoria();
        }

        private void setTablaAuditoria() {

            string query = "SELECT * FROM auditoria";

            try
            {
                var dbConnection = OracleDatabaseConnection.Instance;
                var connection = dbConnection.GetConnection();

                using (var cmd = new OracleCommand(query, connection))
                {
                    // Usar un adaptador para llenar un DataTable
                    using (var adapter = new OracleDataAdapter(cmd))
                    {
                        DataTable clientes = new DataTable();
                        adapter.Fill(clientes);
                        dgtvAuditoria.DataSource = clientes;
                    }
                }
            }
            catch (OracleException ex)
            {
                Console.WriteLine($"Error de base de datos: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                var dbConnection = OracleDatabaseConnection.Instance;
                dbConnection.CloseConnection();
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            setTablaAuditoria();
        }
    }
}
