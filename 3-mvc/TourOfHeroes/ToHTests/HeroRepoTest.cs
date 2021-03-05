using Xunit;
using Microsoft.EntityFrameworkCore;
using ToHDL;
using Model = ToHModels;
using System.Linq;
using ToHModels;
//When unit testing DBs, note that you need to install the Microsoft.EntityFrameworkCore.Sqlite package
//Sqlite has features that allows you to create an inmemory rdb. 
namespace ToHTests
{
    /// <summary>
    /// test class for the data access methods in my DL
    /// </summary>
    public class HeroRepoTest
    {
        private readonly DbContextOptions<HeroDBContext> options;
        //Because xunit creates new instances of test classes, you need to make sure your db is seeded
        public HeroRepoTest()
        {
            //use sqlite to create an inmemory test.db
            options = new DbContextOptionsBuilder<HeroDBContext>()
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
            using (var context = new HeroDBContext(options))
            {
                //Arrange
                IHeroRepository _repo = new HeroRepoDB(context);

                //Act
                var heroes = _repo.GetHeroes();
                Assert.Equal(2, heroes.Count);
            }
        }
        [Fact]
        public void GetHeroByNameShouldRetuenHero()
        {
            using (var context = new HeroDBContext(options))
            {
                IHeroRepository _repo = new HeroRepoDB(context);
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
            using (var context = new HeroDBContext(options))
            {
                IHeroRepository _repo = new HeroRepoDB(context);
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
            using (var assertContext = new HeroDBContext(options))
            {
                var result = assertContext.Heroes.FirstOrDefault(hero => hero.HeroName == "ironman");
                Assert.NotNull(result);
                Assert.Equal("ironman", result.HeroName);
            }
        }
        [Fact]
        public void DeleteShouldDelete()
        {
            using (var context = new HeroDBContext(options))
            {
                IHeroRepository _repo = new HeroRepoDB(context);
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
            using (var assertContext = new HeroDBContext(options))
            {
                var result = assertContext.Heroes.Find(1);
                Assert.Null(result);
            }
        }
        [Fact]
        public void UpdateHeroShouldUpdate()
        {
            using (var context = new HeroDBContext(options))
            {
                IHeroRepository _repo = new HeroRepoDB(context);
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
            using (var assertContext = new HeroDBContext(options))
            {
                var result = assertContext.Heroes.Include("SuperPower").FirstOrDefault(hero => hero.Id == 1);
                Assert.NotNull(result);
                Assert.Equal("Aquaperson", result.HeroName);
                Assert.Equal(1500, result.HP);
                Assert.Equal(150, result.SuperPower.Damage);

            }
        }
        private void Seed()
        {
            using (var context = new HeroDBContext(options))
            {
                //This makes sure that the state of the db gets recreated every time to maintain the modularity of the tests.
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();


                context.Heroes.AddRange
                (
                    new Hero
                    {
                        Id = 1,
                        HeroName = "Aquaman",
                        HP = 500,
                        ElementType = Element.Water,
                        SuperPower = new SuperPower
                        {
                            Id = 1,
                            Name = "Super swimming",
                            Description = "He can breathe underwater and swim really fast.",
                            Damage = 50
                        }
                    },
                    new Hero
                    {
                        Id = 2,
                        HeroName = "Batman",
                        HP = 100,
                        ElementType = Element.Earth,
                        SuperPower = new SuperPower
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