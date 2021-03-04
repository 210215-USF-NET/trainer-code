using Microsoft.EntityFrameworkCore;
using ToHModels;

namespace ToHDL
{
    //By inheriting the DbContext class, I'm establishing an is-a relationship between, herodbcontext
    // and the dbcontext => herodbcontext is a dbcontext
    public class HeroDBContext : DbContext
    {
        public HeroDBContext(DbContextOptions options) : base(options)
        {
        }

        protected HeroDBContext()
        {
        }

        public DbSet<Hero> Heroes { get; set; }
        public DbSet<SuperPower> SuperPowers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hero>()
                .Property(hero => hero.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Hero>()
                .HasOne(hero => hero.SuperPower)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);
            
        }

    }
}