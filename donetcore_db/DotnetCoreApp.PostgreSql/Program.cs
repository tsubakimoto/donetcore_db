using Npgsql;
using static System.Console;

namespace DotnetCoreApp.PostgreSql
{
    class Program
    {
        private static readonly string connectionString = "Server=fukuten0728pg.postgres.database.azure.com;Database=fukuten;Port=5432;User Id=yuta@fukuten0728pg;Password={your_password};";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <remarks>
        /// create table users (id serial not null primary key, name varchar(128) not null);
        /// insert into users(name) values('yuta'), ('tsubaki');
        /// </remarks>
        static void Main(string[] args)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                using (NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM users", connection))
                using (NpgsqlDataReader reader = command.ExecuteReader())
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