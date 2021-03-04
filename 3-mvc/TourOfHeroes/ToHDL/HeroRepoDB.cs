using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public Hero AddHero(Hero newHero)
        {
            _context.Heroes.Add(newHero);
            _context.SaveChanges();
            return newHero;
        }

        public Hero DeleteHero(Hero hero2BDeleted)
        {
            _context.Heroes.Remove(hero2BDeleted);
            _context.SaveChanges();
            return hero2BDeleted;
        }

        public Hero GetHeroByName(string name)
        {
            return _context.Heroes
                .Include("SuperPower")
                .AsNoTracking()
                .FirstOrDefault(hero => hero.HeroName == name);
        }

        public List<Hero> GetHeroes()
        {
            return _context.Heroes
                .Include("SuperPower")
                .AsNoTracking()
                .Select(hero => hero)
                .ToList();
        }

        public Hero UpdateHero(Hero hero2BUpdated)
        {
            Hero oldHero = _context.Heroes.Find(hero2BUpdated.Id);
            _context.Entry(oldHero).CurrentValues.SetValues(hero2BUpdated);

            //Because I am not mapping the hero property in my mapper, i am unable to use the method
            //_context.Entry(oldSuperPower).CurrentValues.SetValues(_mapper.ParseSuperPower(hero2BUpdated.SuperPower))
            // this would throw an error because i have established a 1:1 relationship between my heroes and superpower
            //tables. Instead, I take advantage of the change tracker and use it to update the superpower
            SuperPower oldSuperPower = _context.SuperPowers.Find(hero2BUpdated.SuperPower.Id);
            oldSuperPower.Damage = hero2BUpdated.SuperPower.Damage;
            oldSuperPower.Description = hero2BUpdated.SuperPower.Description;
            oldSuperPower.Name = hero2BUpdated.SuperPower.Name;

            _context.SaveChanges();

            //This method clears the change tracker to drop all tracked entities
            _context.ChangeTracker.Clear();
            return hero2BUpdated;
        }
    }
    
}