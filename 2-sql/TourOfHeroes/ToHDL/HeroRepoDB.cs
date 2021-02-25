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
            return _context.Heroes.Include("Superpower").AsNoTracking().Select(x => _mapper.ParseHero(x)).ToList().FirstOrDefault(x => x.HeroName == name);
        }

        public List<Model.Hero> GetHeroes()
        {
            return _context.Heroes.Include("Superpower").AsNoTracking().Select(x => _mapper.ParseHero(x)).ToList();
        }
    }
}