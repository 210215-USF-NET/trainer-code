using System;
using Xunit;
using ToHModels;
//Note that models aren't really supposed to be unit tested because they mainly hold data
//You should focus on unit testing logic. Like your BL, or DL. Also, don't unit test UI. (trust me I tried)
namespace ToHTests
{
    public class HeroModelTest
    {
        //3 parts of a unit test: arrange, act, assert:
        // Arrange is all about setting up the things you need for the unit test 
        // Act its doing the thing you wanna test
        // Assert (the inedible kind) is comparing the actual results to the expected outcome

        //Arrange
        private Hero testHero = new Hero();

        [Fact]
        public void HeroNameShouldBeSet()
        {
            string testName = "the tick";
            //Act
            testHero.HeroName = testName;
            //Assert
            Assert.Equal(testName, testHero.HeroName);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void HeroNameShouldNotBeEmpty(string testName)
        {
            //Act and Assert
            Assert.Throws<ArgumentNullException>(() => testHero.HeroName = testName);
        }

    }
}
