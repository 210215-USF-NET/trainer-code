using System;
using System.Collections.Generic;

#nullable disable

namespace ToHDL.Entities
{
    public partial class Hero
    {
        public int Id { get; set; }
        public string HeroName { get; set; }
        public int Hp { get; set; }
        public int? ElementType { get; set; }

        public virtual ElementType ElementTypeNavigation { get; set; }
        public virtual Superpower Superpower { get; set; }
    }
}
