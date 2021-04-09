using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task<Hero> AddHeroAsync(Hero newHero)
        {
            //Todo: Add BL
            return await _repo.AddHeroAsync(newHero);
        }

        public async Task<Hero> DeleteHeroAsync(Hero hero2BDeleted)
        {
            return await _repo.DeleteHeroAsync(hero2BDeleted);
        }

        public async Task<Hero> GetHeroByNameAsync(string name)
        {
            //Todo: check if the name given is not null or empty string 
            return await _repo.GetHeroByNameAsync(name);
        }

        public async Task<List<Hero>> GetHeroesAsync()
        {
            //TODO add BL
            return await _repo.GetHeroesAsync();
        }

        public async Task<Hero> UpdateHeroAsync(Hero hero2BUpdated)
        {
            return await _repo.UpdateHeroAsync(hero2BUpdated);
        }
    }
}
