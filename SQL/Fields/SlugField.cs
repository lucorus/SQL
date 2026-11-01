using System;
using System.Collections.Generic;
using SQL.Orm;
using System.Text;
using System.Text.RegularExpressions;

namespace SQL.Fields
{
    public class SlugFieldAttribute : CharFieldAttribute
    {
        private static readonly Regex SlugRegex =
            new(@"^[a-z0-9]+(?:-[a-z0-9]+)*$", RegexOptions.Compiled);

        public SlugFieldAttribute() { Unique = true; MaxLength = 200; }

        public override void Validate(string fieldName, object? value)
        {
            base.Validate(fieldName, value);
            if (value is string s && !SlugRegex.IsMatch(s))
                throw new ValidationException(
                    $"{fieldName}: '{s}' не является валидным slug " +
                    "(только a-z, 0-9 и дефис)");
        }
    }
}
