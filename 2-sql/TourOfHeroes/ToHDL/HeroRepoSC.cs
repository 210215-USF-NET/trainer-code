using ToHModels;
using System.Collections.Generic;
namespace ToHDL
{
    public class HeroRepoSC : IHeroRepository
    {
        public List<Hero> GetHeroes()
        {
            return Storage.AllHeroes;
        }
        public Hero AddHero(Hero newHero)
        {
            Storage.AllHeroes.Add(newHero);
            return newHero;
        }

        public Hero GetHeroByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public Hero DeleteHero(Hero hero2BDeleted)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateHero(Hero hero2BUpdated)
        {
            throw new System.NotImplementedException();
        }
    }
}