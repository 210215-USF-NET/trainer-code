using ToHModels;
using System.Collections.Generic;
namespace ToHDL
{
    public interface IHeroRepository
    {
        List<Hero> GetHeroes();
        Hero AddHero(Hero newHero);
        Hero GetHeroByName(string name);
    }
}