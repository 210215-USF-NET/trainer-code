using ToHModels;
using System.Collections.Generic;
namespace ToHBL
{
    public interface IHeroBL
    {
        List<Hero> GetHeroes();
        void AddHero(Hero newHero);

        Hero GetHeroByName(string name);
    }
}