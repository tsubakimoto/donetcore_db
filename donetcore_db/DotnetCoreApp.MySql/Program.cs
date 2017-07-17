using MySql.Data.MySqlClient;
using static System.Console;

namespace DotnetCoreApp.MySql
{
    class Program
    {
        private static readonly string connectionString = "Database=fukuten; Data Source=fukuten0728.mysql.database.azure.com; User Id=yuta@fukuten0728; Password={your_password}";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <remarks>
        /// create table users (id int not null auto_increment primary key, name varchar(128) not null);
        /// insert into users(name) values('yuta'), ('tsubaki');
        /// </remarks>
        static void Main(string[] args)
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand("SELECT * FROM users", connection))
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string row = $"{reader["id"]}\t{reader["name"]}";
                        WriteLine(row);
                    }
                }

                connection.Close();
            }

            ReadLine();
        }
    }
}