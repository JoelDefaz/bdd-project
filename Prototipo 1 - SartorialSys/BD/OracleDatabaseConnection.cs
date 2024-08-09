using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using Prototipo_1___SartorialSys.Clases;

namespace Prototipo_1___SartorialSys.BL.BD
{
    public class OracleDatabaseConnection
    {
        private static OracleDatabaseConnection _instance;
        private static readonly object _lock = new object();
        private OracleConnection _connection;
        private string _connectionString = "User Id=master;Password=master;Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521))(CONNECT_DATA =(SERVICE_NAME = orcl)))";

        private OracleDatabaseConnection()
        {
            _connection = new OracleConnection(_connectionString);
        }

        public static OracleDatabaseConnection Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new OracleDatabaseConnection();
                    }
                }
                return _instance;
            }
        }

        public OracleConnection GetConnection()
        {
            // Asegúrate de que la conexión esté abierta
            if (_connection.State == System.Data.ConnectionState.Closed)
            {
                _connection.Open();
            }
            return _connection;
        }

        public void CloseConnection()
        {
            // Solo cierra la conexión si está abierta
            if (_connection.State == System.Data.ConnectionState.Open)
            {
                _connection.Close();
            }
        }
    }
}