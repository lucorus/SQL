using SQL.Fields;
using SQL.Orm;
using System;
using System.Collections.Generic;
using System.Text;

namespace SQL.Models
{
    public class Category : Model
    {
        [UuidField]
        public Guid Uuid { get; set; } = Guid.NewGuid();

        [CharField(MaxLength = 100)]
        public string Name { get; set; } = "";

        [SlugField]
        public string Slug { get; set; } = "";
    }


}
