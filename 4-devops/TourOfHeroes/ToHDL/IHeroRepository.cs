using ToHModels;
using System.Collections.Generic;
namespace ToHDL
{
    public interface IHeroRepository
    {
        List<Hero> GetHeroes();
        Hero AddHero(Hero newHero);
        Hero GetHeroByName(string name);

        Hero DeleteHero(Hero hero2BDeleted);

        Hero UpdateHero(Hero hero2BUpdated);
    }
}