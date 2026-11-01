using System;
using SQL.Orm;

namespace SQL.Fields
{
    public class CharFieldAttribute : FieldAttribute
    {
        public int MaxLength { get; set; } = 255;

        public override string SqlType => "TEXT";

        public override void Validate(string fieldName, object? value)
        {
            if (value is null)
            {
                if (!Null) throw new ValidationException($"{fieldName}: не может быть null");
                return;
            }
            if (value is not string s)
                throw new ValidationException($"{fieldName}: ожидалась строка");

            if (s.Length > MaxLength)
                throw new ValidationException(
                    $"{fieldName}: длина {s.Length} > MaxLength {MaxLength}");
        }
    }
}
