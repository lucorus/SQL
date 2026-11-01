using System;
using System.Collections.Generic;
using SQL.Orm;
using System.Text;

namespace SQL.Fields
{
    public class BooleanFieldAttribute : FieldAttribute
    {
        public override string SqlType => "INTEGER"; // SQLite не имеет bool

        public override void Validate(string fieldName, object? value)
        {
            if (value is null && !Null)
                throw new ValidationException($"{fieldName}: не может быть null");
            if (value is not null and not bool)
                throw new ValidationException($"{fieldName}: ожидался bool");
        }
    }
}
