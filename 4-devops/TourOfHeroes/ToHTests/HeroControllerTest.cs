using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using ToHBL;
using ToHModels;
using ToHMVC.Controllers;
using ToHMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace ToHTests
{
    public class HeroControllerTest
    {
        [Fact]
        public void HeroControllerShouldReturnIndex()
        {
            //Arrange
            //Creating a stub of IHeroBL  using Moq the framework and in Moq, fake objects
            // are called Mock
            var mockRepo = new Mock<IHeroBL>();
            // This is just us defining what the stub would do/return if the method GetHeroes() is called
            // We're returning a static list of heroes
            mockRepo.Setup(x => x.GetHeroes())
                .Returns(new List<Hero>()
                {
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
                }
               );
            //I really don't need to create a fake mapper because the real one doesn't affect the 
            // state of my data, just its type, (it just casts stuff)
            var controller = new HeroController(mockRepo.Object, new Mapper());

            //Act
            var result = controller.Index();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<HeroIndexVM>>(viewResult.ViewData.Model);
            Assert.Equal(2, model.Count());

        }
    }
}
