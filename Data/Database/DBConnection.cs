using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVC_WPF.Data.Database
{
    public class DBConnection
    {
        private string _connectionString;

        private static readonly Lazy<DBConnection> _instance=
            new Lazy<DBConnection>(() => new DBConnection());

        private DBConnection()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MySqlConnection"]?.ConnectionString;
            if (string.IsNullOrEmpty(_connectionString))
                MessageBox.Show("Строка подключения не найдена в app.config.");
        }

        public static DBConnection Instance => _instance.Value;

        public void Init()
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    MessageBox.Show("Подключение к базе данных MySQL успешно установлено.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка подключения к базе данных: {ex.Message}");
                }
            }
        }

        ///<summary>
        /// Метод для выполнения запросов с возвратом данных (SELECT)
        ///</summary>
        public DataTable ExecuteQuery(string query, MySqlParameter[] parameters = null)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            return dataTable;
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Ошибка при выполнении запроса: " + ex.Message);
                }
            }
        }

        ///<summary>
        /// Метод для выполнения запросов без возврата данных (INSERT, UPDATE, DELETE)
        /// Возвращает количество изменённых строк
        ///</summary>
        public int ExecuteNonQuery(string query, MySqlParameter[] parameters = null)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }
                        return command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Ошибка при выполнении запроса: " + ex.Message);
                }
            }

        }

        /// <summary>
        /// Метод для быстрого получения одного значения
        /// </summary>
        public object ExecuteScalar(string query, MySqlParameter[] parameters = null)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }
                        return command.ExecuteScalar();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Ошибка при выполнении запроса: " + ex.Message);
                }
            }
        }
    }
}
