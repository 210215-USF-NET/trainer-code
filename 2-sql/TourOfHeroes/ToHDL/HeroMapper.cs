using Model = ToHModels;
using Entity = ToHDL.Entities;
using ToHModels;
using ToHDL.Entities;
namespace ToHDL
{
    public class HeroMapper : IMapper
    {
        public Model.Hero ParseHero(Entity.Hero hero)
        {
            return new Model.Hero
            {
                HeroName = hero.HeroName,
                HP = hero.Hp,
                ElementType = (Model.Element)hero.ElementType,
                SuperPower = ParseSuperPower(hero.Superpower),
                Id = hero.Id
            };
        }

        public Entity.Hero ParseHero(Model.Hero hero)
        {
            // For when you add a new hero, Id isn't set yet
            if (hero.Id == null)
            {
                return new Entity.Hero
                {
                    HeroName = hero.HeroName,
                    Hp = hero.HP,
                    ElementType = (int)hero.ElementType,
                    Superpower = ParseSuperPower(hero.SuperPower)
                };
            }
            //for updating and deletion purposes
            return new Entity.Hero
            {
                HeroName = hero.HeroName,
                Hp = hero.HP,
                ElementType = (int)hero.ElementType,
                Superpower = ParseSuperPower(hero.SuperPower),
                Id = (int)hero.Id
            };

        }

        public SuperPower ParseSuperPower(Superpower superpower)
        {
            return new SuperPower
            {
                Name = superpower.Name,
                Description = superpower.Description,
                Damage = superpower.Damage,
                Id = superpower.Id
            };
        }

        public Superpower ParseSuperPower(SuperPower superPower)
        {   //for adding new superpower
            if (superPower.Id == null)
            {
                return new Superpower
                {
                    Name = superPower.Name,
                    Description = superPower.Description,
                    Damage = superPower.Damage
                };
            }
            //For updating 
            return new Superpower
            {
                Name = superPower.Name,
                Description = superPower.Description,
                Damage = superPower.Damage,
                Id = (int)superPower.Id
            };
        }

    }
}