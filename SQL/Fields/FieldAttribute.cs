using System;
using System.Collections.Generic;
using System.Text;
using SQL.Orm;

namespace SQL.Fields
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public abstract class FieldAttribute : Attribute
    {
        // Имя колонки в БД. Если null — берётся имя свойства
        public string? ColumnName { get; set; }

        // Разрешить NULL в БД
        public bool Null { get; set; } = false;

        // UNIQUE-ограничение
        public bool Unique { get; set; } = false;

        // первичный ключ
        public bool PrimaryKey { get; set; } = false;

        // SQL-тип колонки для конкретного диалекта. Пока только SQLite
        public abstract string SqlType { get; }

        // Проверка значения. Переопределяется в наследниках
        public virtual void Validate(string fieldName, object? value) { }
    }
}
