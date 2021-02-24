using System;
using System.Collections.Generic;
using ToHDL;
using ToHModels;

namespace ToHBL
{
    public class HeroBL : IHeroBL
    {
        private IHeroRepository _repo;
        public HeroBL(IHeroRepository repo)
        {
            _repo = repo;
        }
        public void AddHero(Hero newHero)
        {
            //Todo: Add BL
            _repo.AddHero(newHero);
        }

        public Hero GetHeroByName(string name)
        {
            //Todo: check if the name given is not null or empty string 
            return _repo.GetHeroByName(name);
        }

        public List<Hero> GetHeroes()
        {
            //TODO add BL
            return _repo.GetHeroes();
        }
    }
}
