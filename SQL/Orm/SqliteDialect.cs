using System;
using System.Collections.Generic;
using System.Text;

namespace SQL.Orm
{
    public static class SqliteDialect
    {
        public static string CreateTable(Model model)
        {
            var sb = new StringBuilder();
            sb.Append($"CREATE TABLE IF NOT EXISTS \"{model.TableName}\" (");

            var defs = new List<string>();
            foreach (var col in model.Columns())
            {
                var def = $"\"{col.Name}\" {col.SqlType}";
                if (col.IsPrimaryKey) def += " PRIMARY KEY";
                if (col.IsNotNull) def += " NOT NULL";
                if (col.IsUnique && !col.IsPrimaryKey) def += " UNIQUE";
                defs.Add(def);
            }

            sb.Append(string.Join(", ", defs));
            sb.Append(");");
            return sb.ToString();
        }
    }
}
