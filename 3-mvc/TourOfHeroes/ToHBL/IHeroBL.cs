using ToHModels;
using System.Collections.Generic;
namespace ToHBL
{
    public interface IHeroBL
    {
        List<Hero> GetHeroes();
        Hero AddHero(Hero newHero);

        Hero GetHeroByName(string name);
        Hero DeleteHero(Hero hero2BDeleted);

        Hero UpdateHero(Hero hero2BUpdated, Hero updatedDetails);
    }
}