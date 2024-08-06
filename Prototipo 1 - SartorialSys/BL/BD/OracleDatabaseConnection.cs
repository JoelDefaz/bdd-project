using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Data;

namespace Prototipo_1___SartorialSys.BL.BD
{
    public class OracleDatabaseConnection
    {
        private static OracleDatabaseConnection _instance = null;
        private static readonly object _lock = new object();
        private OracleConnection _connection;

        // Configura tu cadena de conexión aquí
        private string _connectionString = "User Id=jdefaz;Password=jdefaz;Data Source=CHEOODEEF";

        // Constructor privado para evitar la instanciación externa
        private OracleDatabaseConnection()
        {
            _connection = new OracleConnection(_connectionString);
        }

        // Método público estático para proporcionar acceso a la instancia
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

        // Método para obtener la conexión abierta
        public OracleConnection GetConnection()
        {
            if (_connection.State != ConnectionState.Open)
            {
                _connection.Open();
            }
            return _connection;
        }

        // Método para cerrar la conexión
        public void CloseConnection()
        {
            if (_connection.State != ConnectionState.Closed)
            {
                _connection.Close();
            }
        }

        // Método para ejecutar una consulta SELECT y devolver un DataTable
        public DataTable ExecuteQueryRead(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                using (OracleCommand cmd = new OracleCommand(sql, _connection))
                {
                    using (OracleDataAdapter da = new OracleDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al ejecutar la consulta: {ex.Message}");
            }
            return dt;
        }

        // Método para ejecutar una consulta INSERT, UPDATE o DELETE
        public int ExecuteQueryInsertUpdateDelete(string sql)
        {
            int rowsAffected = 0;
            try
            {
                using (OracleCommand cmd = new OracleCommand(sql, _connection))
                {
                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al ejecutar la consulta: {ex.Message}");
            }
            return rowsAffected;
        }

        // Método para obtener el último ID insertado (asumiendo que hay una secuencia)
        public int ExecuteQueryReadLastId(string sequenceName)
        {
            int lastId = -1;
            string sql = $"SELECT {sequenceName}.CURRVAL FROM DUAL";
            try
            {
                using (OracleCommand cmd = new OracleCommand(sql, _connection))
                {
                    lastId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener el último ID: {ex.Message}");
            }
            return lastId;
        }
    }
}