using System;
using System.Collections.Generic;
using System.Text;

namespace SQL.Orm
{
    public class UuidField
    {
        public Guid Value { get; }

        public UuidField(Guid value) => Value = value;

        public static UuidField New() => new(Guid.NewGuid());

        public override string ToString() => Value.ToString();
    }
}
