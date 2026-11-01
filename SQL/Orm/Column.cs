using System;
using System.Collections.Generic;
using System.Text;

namespace SQL.Orm
{
    public class Column
    {
        public string Name { get; }
        public string SqlType { get; }
        public bool IsPrimaryKey { get; }
        public bool IsUnique { get; }
        public bool IsNotNull { get; }

        public Column(string name, string sqlType,
                      bool isPrimaryKey = false,
                      bool isUnique = false,
                      bool isNotNull = false)
        {
            Name = name;
            SqlType = sqlType;
            IsPrimaryKey = isPrimaryKey;
            IsUnique = isUnique;
            IsNotNull = isNotNull;
        }
    }
}
