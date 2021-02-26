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

        /// <summary>
        /// This property isn't actually a hero object, it's a fk reference to the hero table
        /// </summary>
        /// <value></value>
        public int Hero { get; set; }

        public virtual Hero HeroNavigation { get; set; }
    }
}
