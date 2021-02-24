using System;
using System.Collections.Generic;

#nullable disable

namespace ToHDL.Entities
{
    public partial class Superpower
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Damage { get; set; }
        public int? Hero { get; set; }

        public virtual Hero HeroNavigation { get; set; }
    }
}
