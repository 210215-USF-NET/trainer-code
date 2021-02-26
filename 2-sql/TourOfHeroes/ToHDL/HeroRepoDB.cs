using System.Collections.Generic;
using Model = ToHModels;
using Entity = ToHDL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ToHModels;

namespace ToHDL
{
    public class HeroRepoDB : IHeroRepository
    {
        private Entity.HeroDBContext _context;
        private IMapper _mapper;
        public HeroRepoDB(Entity.HeroDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Model.Hero AddHero(Model.Hero newHero)
        {
            _context.Heroes.Add(_mapper.ParseHero(newHero));
            _context.SaveChanges();
            return newHero;
        }

        public Hero DeleteHero(Hero hero2BDeleted)
        {
            _context.Heroes.Remove(_mapper.ParseHero(hero2BDeleted));
            _context.SaveChanges();
            return hero2BDeleted;
        }

        public Hero GetHeroByName(string name)
        {
            //this method returns the hero entity, and eagerly loads the superpower entity associated with it 
            //using the .Include() method. the .AsNoTracking() method makes sure that the enities aren't being 
            //tracked by the change tracker. the .Select() method is used to transform each entity type to a model type
            //The .ToList() method structures the collection into a list, and the FirstOrDefault() method searches
            //that list for a element whose heroName is equal to the parameter
            return _context.Heroes
            .Include("Superpower")
            .AsNoTracking()
            .Select(x => _mapper.ParseHero(x))
            .ToList()
            .FirstOrDefault(x => x.HeroName == name);
        }

        public List<Model.Hero> GetHeroes()
        {
            return _context.Heroes.Include("Superpower").AsNoTracking().Select(x => _mapper.ParseHero(x)).ToList();
        }

        public void UpdateHero(Hero hero2BUpdated)
        {
            Entity.Hero oldHero = _context.Heroes.Find(hero2BUpdated.Id);
            _context.Entry(oldHero).CurrentValues.SetValues(_mapper.ParseHero(hero2BUpdated));

            //Because I am not mapping the hero property in my mapper, i am unable to use the method
            //_context.Entry(oldSuperPower).CurrentValues.SetValues(_mapper.ParseSuperPower(hero2BUpdated.SuperPower))
            // this would throw an error because i have established a 1:1 relationship between my heroes and superpower
            //tables. Instead, I take advantage of the change tracker and use it to update the superpower
            Entity.Superpower oldSuperPower = _context.Superpowers.Find(hero2BUpdated.SuperPower.Id);
            oldSuperPower.Damage = hero2BUpdated.SuperPower.Damage;
            oldSuperPower.Description = hero2BUpdated.SuperPower.Description;
            oldSuperPower.Name = hero2BUpdated.SuperPower.Name;

            _context.SaveChanges();

            //This method clears the change tracker to drop all tracked entities
            _context.ChangeTracker.Clear();
        }
    }
}