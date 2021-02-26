using Xunit;
using Microsoft.EntityFrameworkCore;
using ToHDL;
using Entity = ToHDL.Entities;
using Model = ToHModels;
using System.Linq;
namespace ToHTests
{
    /// <summary>
    /// test class for the data access methods in my DL
    /// </summary>
    public class HeroRepoTest
    {
        private readonly DbContextOptions<Entity.HeroDBContext> options;
        //Because xunit creates new instances of test classes, you need to make sure your db is seeded
        public HeroRepoTest()
        {
            options = new DbContextOptionsBuilder<Entity.HeroDBContext>()
            .UseSqlite("Filename=Test.db")
            .Options;
            Seed();
        }
        //testing read operations
        //When testing methods that do not change the state of the data in the db, only one context is needed
        [Fact]
        public void GetAllHeroesShouldReturnAllHeroes()
        {
            //This is a using block, at the end of the execution of the code surrounded by the block, the 
            //unmanaged resource is going to be disposed of 
            using (var context = new Entity.HeroDBContext(options))
            {
                //Arrange
                IHeroRepository _repo = new HeroRepoDB(context, new HeroMapper());

                //Act
                var heroes = _repo.GetHeroes();
                Assert.Equal(2, heroes.Count);
            }
        }
        [Fact]
        public void GetHeroByNameShouldRetuenHero()
        {
            using (var context = new Entity.HeroDBContext(options))
            {
                IHeroRepository _repo = new HeroRepoDB(context, new HeroMapper());
                var foundHero = _repo.GetHeroByName("Aquaman");

                Assert.NotNull(foundHero);
                Assert.Equal("Aquaman", foundHero.HeroName);
            }
        }
        //When testing operations that change the state of the db (i.e manipulate the data inside the db) 
        //make sure to check if the change has persisted even when accessing the db using a different context/connection
        //This means that you create another instance of your context when testing to check that the method has 
        //definitely affected the db.
        [Fact]
        public void AddHeroShouldAddHero()
        {
            using (var context = new Entity.HeroDBContext(options))
            {
                IHeroRepository _repo = new HeroRepoDB(context, new HeroMapper());
                _repo.AddHero
                (
                    new Model.Hero
                    {
                        HeroName = "ironman",
                        HP = 100,
                        ElementType = (Model.Element)4,
                        SuperPower = new Model.SuperPower
                        {
                            Name = "Really really rich",
                            Description = "He just makes a bunch of iron outfits with cool accessories using all his money",
                            Damage = 50
                        }
                    }
                );
            }
            //use the context to check the state of the db directly when asserting.
            using (var assertContext = new Entity.HeroDBContext(options))
            {
                var result = assertContext.Heroes.FirstOrDefault(hero => hero.HeroName == "ironman");
                Assert.NotNull(result);
                Assert.Equal("ironman", result.HeroName);
            }
        }
        [Fact]
        public void DeleteShouldDelete()
        {
            using (var context = new Entity.HeroDBContext(options))
            {
                IHeroRepository _repo = new HeroRepoDB(context, new HeroMapper());
                _repo.DeleteHero(
                    new Model.Hero
                    {
                        Id = 1,
                        HeroName = "Aquaman",
                        HP = 500,
                        ElementType = Model.Element.Water,
                        SuperPower = new Model.SuperPower
                        {
                            Id = 1,
                            Name = "Super swimming",
                            Description = "He can breathe underwater and swim really fast.",
                            Damage = 50
                        }
                    }
                );
            }
            using (var assertContext = new Entity.HeroDBContext(options))
            {
                var result = assertContext.Heroes.Find(1);
                Assert.Null(result);
            }
        }
        [Fact]
        public void UpdateHeroShouldUpdate()
        {
            using (var context = new Entity.HeroDBContext(options))
            {
                IHeroRepository _repo = new HeroRepoDB(context, new HeroMapper());
                _repo.UpdateHero(
                    new Model.Hero
                    {
                        Id = 1,
                        HeroName = "Aquaperson",
                        HP = 1500,
                        ElementType = Model.Element.Water,
                        SuperPower = new Model.SuperPower
                        {
                            Id = 1,
                            Name = "Super swimming",
                            Description = "He can breathe underwater and swim really fast.",
                            Damage = 150
                        }
                    }
                );
            }
            using (var assertContext = new Entity.HeroDBContext(options))
            {
                var result = assertContext.Heroes.Include("Superpower").FirstOrDefault(hero => hero.Id == 1);
                Assert.NotNull(result);
                Assert.Equal("Aquaperson", result.HeroName);
                Assert.Equal(1500, result.Hp);
                Assert.Equal(150, result.Superpower.Damage);

            }
        }
        private void Seed()
        {
            using (var context = new Entity.HeroDBContext(options))
            {
                //This makes sure that the state of the db gets recreated every time to maintain the modularity of the tests.
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.ElementTypes.AddRange
                (
                    new Entity.ElementType
                    {
                        Id = 1,
                        ElementType1 = "Water"
                    },
                    new Entity.ElementType
                    {
                        Id = 2,
                        ElementType1 = "Earth"
                    },
                    new Entity.ElementType
                    {
                        Id = 3,
                        ElementType1 = "Air"
                    },
                    new Entity.ElementType
                    {
                        Id = 4,
                        ElementType1 = "Fire"
                    }
                );

                context.Heroes.AddRange
                (
                    new Entity.Hero
                    {
                        Id = 1,
                        HeroName = "Aquaman",
                        Hp = 500,
                        ElementType = 1,
                        Superpower = new Entity.Superpower
                        {
                            Id = 1,
                            Name = "Super swimming",
                            Description = "He can breathe underwater and swim really fast.",
                            Damage = 50
                        }
                    },
                    new Entity.Hero
                    {
                        Id = 2,
                        HeroName = "Batman",
                        Hp = 100,
                        ElementType = 2,
                        Superpower = new Entity.Superpower
                        {
                            Id = 2,
                            Name = "Rich",
                            Description = "He can buy you out. Also he knows the secrets of all the other Justice League members.",
                            Damage = 75
                        }
                    }
                );
                context.SaveChanges();
            }
        }
    }
}