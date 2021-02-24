using System;
using System.Collections.Generic;

#nullable disable

namespace ToHDL.Entities
{
    public partial class ElementType
    {
        public ElementType()
        {
            Heroes = new HashSet<Hero>();
        }

        public int Id { get; set; }
        public string ElementType1 { get; set; }

        public virtual ICollection<Hero> Heroes { get; set; }
    }
}
