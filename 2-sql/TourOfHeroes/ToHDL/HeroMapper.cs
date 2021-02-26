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
        //Couple things to note when mapping a hero, the element type property is actually a fk reference
        //to the element table in the db, it's not of the enum/entity element type, so I have to cast the enum to an int
        //this int value corresponds to the element's id in the table in the db
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
            //for updating and deletion purposes, set the id to be able to find the needed hero
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

        //Because superpowers are accessed through the hero object, i did not map the Hero property of Entity.Superpower
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
            //For updating the superpower, you need the id to find it
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