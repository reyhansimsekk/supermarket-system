using MySql.Data.MySqlClient;
using System.Data;

namespace SupermarketApp.Data
{
    public class DatabaseConnection
    {
        private static string connectionString = "Server=localhost;Database=supermarket_db;Uid=root;Pwd=;Port=3306;CharSet=utf8mb4;";
        
        public static string ConnectionString
        {
            get { return connectionString; }
            set { connectionString = value; }
        }

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public static bool TestConnection()
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static DataTable ExecuteQuery(string query, params MySqlParameter[] parameters)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    using (var command = new MySqlCommand(query, connection))
                    {
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }
                        
                        using (var adapter = new MySqlDataAdapter(command))
                        {
                            var dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            return dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Veritabanı sorgu hatası: {ex.Message}");
            }
        }

        public static int ExecuteNonQuery(string query, params MySqlParameter[] parameters)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    using (var command = new MySqlCommand(query, connection))
                    {
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }
                        
                        return command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Veritabanı işlem hatası: {ex.Message}");
            }
        }

        public static object ExecuteScalar(string query, params MySqlParameter[] parameters)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    using (var command = new MySqlCommand(query, connection))
                    {
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }
                        
                        return command.ExecuteScalar();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Veritabanı skaler sorgu hatası: {ex.Message}");
            }
        }
    }
}