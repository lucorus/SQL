using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQL.Orm
{
    public class Database
    {
        private readonly string _connectionString;

        public Database(string databasePath)
        {
            _connectionString = $"Data Source={databasePath}";
        }

        public void CreateTable(Model model)
        {
            var sql = SqliteDialect.CreateTable(model);
            Console.WriteLine($"[SQL] {sql}");

            using var conn = new SqliteConnection(_connectionString);
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }
    }
}
