using System;
using System.Collections.Generic;
using System.Text;
using SQL.Orm;

namespace SQL.Fields
{
    public class UuidFieldAttribute : FieldAttribute
    {
        public override string SqlType => "TEXT";

        public UuidFieldAttribute() { PrimaryKey = true; }

        public override void Validate(string fieldName, object? value)
        {
            if (value is null && !Null)
                throw new ValidationException($"{fieldName}: UUID не может быть null");
            if (value is not null and not Guid)
                throw new ValidationException($"{fieldName}: ожидался Guid");
        }
    }
}
