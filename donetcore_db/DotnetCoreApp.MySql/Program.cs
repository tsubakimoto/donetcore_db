using MySql.Data.MySqlClient;
using System;
using static System.Console;

namespace DotnetCoreApp.MySql
{
    class Program
    {
        private static readonly string connectionString = "Database=fukuten; Data Source=fukuten0728.mysql.database.azure.com; User Id=yuta@fukuten0728; Password={your_password}";

        static void Main(string[] args)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand("SELECT * FROM users", connection);
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string row = $"{reader["name"]}";
                        WriteLine(row);
                    }
                }

                connection.Close();
            }

            ReadLine();
        }
    }
}