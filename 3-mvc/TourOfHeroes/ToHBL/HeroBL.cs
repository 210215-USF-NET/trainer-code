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
        public Hero AddHero(Hero newHero)
        {
            //Todo: Add BL
            return _repo.AddHero(newHero);
        }

        public Hero DeleteHero(Hero hero2BDeleted)
        {
            return _repo.DeleteHero(hero2BDeleted);
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

        public Hero UpdateHero(Hero hero2BUpdated)
        {
            return _repo.UpdateHero(hero2BUpdated);
        }
    }
}
