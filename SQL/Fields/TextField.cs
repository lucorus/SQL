using System;
using System.Collections.Generic;
using SQL.Orm;
using System.Text;

namespace SQL.Fields
{
    public class TextFieldAttribute : FieldAttribute
    {
        public override string SqlType => "TEXT";

        public override void Validate(string fieldName, object? value)
        {
            if (value is null && !Null)
                throw new ValidationException($"{fieldName}: не может быть null");
            if (value is not null and not string)
                throw new ValidationException($"{fieldName}: ожидалась строка");
        }
    }
}
