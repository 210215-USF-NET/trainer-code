using System.Collections.Generic;
using Model = ToHModels;
using Entity = ToHDL.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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

        public List<Model.Hero> GetHeroes()
        {
            throw new System.NotImplementedException();
        }
    }
}