using System;
using System.Collections.Generic;
using ToHDL;
using ToHModels;

namespace ToHBL
{
    public class HeroBL : IHeroBL
    {
        private IHeroRepository repo = new HeroRepoSC();
        public void AddHero(Hero newHero)
        {
            //Todo: Add BL
            repo.AddHero(newHero);
        }

        public List<Hero> GetHeroes()
        {
            //TODO add BL
            return repo.GetHeroes();
        }
    }
}
