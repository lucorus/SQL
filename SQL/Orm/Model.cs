using SQL.Fields;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace SQL.Orm
{
    public abstract class Model
    {
        public virtual string TableName => GetType().Name.ToLowerInvariant();

        // Автоматически собирает колонки из свойств с атрибутами [Field].
        // Переопределять в наследниках больше не нужно.
        public virtual IReadOnlyList<Column> Columns()
        {
            var result = new List<Column>();
            var props = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in props)
            {
                var attr = prop.GetCustomAttribute<FieldAttribute>();
                if (attr is null) continue;

                result.Add(new Column(
                    name: attr.ColumnName ?? prop.Name.ToLowerInvariant(),
                    sqlType: attr.SqlType,
                    isPrimaryKey: attr.PrimaryKey,
                    isUnique: attr.Unique,
                    isNotNull: !attr.Null
                ));
            }
            return result;
        }

        // Проверяет все поля с [Field] на текущем объекте
        public void Validate()
        {
            var props = GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (var prop in props)
            {
                var attr = prop.GetCustomAttribute<FieldAttribute>();
                if (attr is null) continue;
                attr.Validate(prop.Name, prop.GetValue(this));
            }
        }

        public override string ToString() => $"<{GetType().Name}>";
    }
}
