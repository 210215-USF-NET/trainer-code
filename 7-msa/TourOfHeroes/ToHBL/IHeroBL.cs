using System.Collections.Generic;
using System.Threading.Tasks;
using ToHModels;

namespace ToHBL
{
    public interface IHeroBL
    {
        Task<Hero> AddHeroAsync(Hero newHero);
        Task<Hero> DeleteHeroAsync(Hero hero2BDeleted);
        Task<Hero> GetHeroByNameAsync(string name);
        Task<List<Hero>> GetHeroesAsync();
        Task<Hero> UpdateHeroAsync(Hero hero2BUpdated);
    }
}