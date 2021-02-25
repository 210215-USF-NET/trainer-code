using ToHModels;
using System.Collections.Generic;
namespace ToHBL
{
    public interface IHeroBL
    {
        List<Hero> GetHeroes();
        void AddHero(Hero newHero);

        Hero GetHeroByName(string name);
        void DeleteHero(Hero hero2BDeleted);

        void UpdateHero(Hero hero2BUpdated, Hero updatedDetails);
    }
}