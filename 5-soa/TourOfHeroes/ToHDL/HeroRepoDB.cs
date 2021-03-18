using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToHModels;

namespace ToHDL
{
    public class HeroRepoDB : IHeroRepository
    {
        private readonly HeroDBContext _context;
        public HeroRepoDB(HeroDBContext context)
        {
            _context = context;
        }
        public async Task<Hero> AddHeroAsync(Hero newHero)
        {
            await _context.Heroes.AddAsync(newHero);
            await _context.SaveChangesAsync();
            return newHero;
        }

        public async Task<Hero> DeleteHeroAsync(Hero hero2BDeleted)
        {
            _context.Heroes.Remove(hero2BDeleted);
            await _context.SaveChangesAsync();
            return hero2BDeleted;
        }

        public async Task<Hero> GetHeroByNameAsync(string name)
        {
            return await _context.Heroes
                .Include("SuperPower")
                .AsNoTracking()
                .FirstOrDefaultAsync(hero => hero.HeroName == name);
        }

        public async Task<List<Hero>> GetHeroesAsync()
        {
            return await _context.Heroes
                .Include("SuperPower")
                .AsNoTracking()
                .Select(hero => hero)
                .ToListAsync();
        }

        public async Task<Hero> UpdateHeroAsync(Hero hero2BUpdated)
        {
            Hero oldHero = await _context.Heroes.FindAsync(hero2BUpdated.Id);
            _context.Entry(oldHero).CurrentValues.SetValues(hero2BUpdated);

            //Because I am not mapping the hero property in my mapper, i am unable to use the method
            //_context.Entry(oldSuperPower).CurrentValues.SetValues(_mapper.ParseSuperPower(hero2BUpdated.SuperPower))
            // this would throw an error because i have established a 1:1 relationship between my heroes and superpower
            //tables. Instead, I take advantage of the change tracker and use it to update the superpower
            SuperPower oldSuperPower = _context.SuperPowers.Find(hero2BUpdated.SuperPower.Id);
            oldSuperPower.Damage = hero2BUpdated.SuperPower.Damage;
            oldSuperPower.Description = hero2BUpdated.SuperPower.Description;
            oldSuperPower.Name = hero2BUpdated.SuperPower.Name;

            await _context.SaveChangesAsync();

            //This method clears the change tracker to drop all tracked entities
            _context.ChangeTracker.Clear();
            return hero2BUpdated;
        }
    }

}