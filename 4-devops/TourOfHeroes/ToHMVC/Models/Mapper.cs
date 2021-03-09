﻿using ToHModels;

namespace ToHMVC.Models
{
    public class Mapper : IMapper
    {
        public HeroIndexVM cast2HeroIndexVM(Hero hero2BCasted)
        {
            return new HeroIndexVM
            {
                HeroName = hero2BCasted.HeroName,
                HP = hero2BCasted.HP,
                ElementType = hero2BCasted.ElementType
            };
        }
        public Hero cast2Hero(HeroCRVM hero2BCasted)
        {
            return new Hero
            {
                HeroName = hero2BCasted.HeroName,
                HP = hero2BCasted.HP,
                ElementType = hero2BCasted.ElementType,
                SuperPower = new SuperPower
                {
                    Name = hero2BCasted.SuperPowerName,
                    Description = hero2BCasted.Description,
                    Damage = hero2BCasted.Damage
                }
            };
        }
        public HeroCRVM cast2HeroCRVM(Hero hero)
        {
            return new HeroCRVM
            {
                HeroName = hero.HeroName,
                HP = hero.HP,
                ElementType = hero.ElementType,
                SuperPowerName = hero.SuperPower.Name,
                Description = hero.SuperPower.Description,
                Damage = hero.SuperPower.Damage
            };
        }
        public Hero cast2Hero(HeroEditVM hero2BCasted)
        {
            return new Hero
            {
                Id = hero2BCasted.HeroId,
                HeroName = hero2BCasted.HeroName,
                HP = hero2BCasted.HP,
                ElementType = hero2BCasted.ElementType,
                SuperPower = new SuperPower
                {
                    Id = hero2BCasted.SuperPowerId,
                    Name = hero2BCasted.SuperPowerName,
                    Description = hero2BCasted.Description,
                    Damage = hero2BCasted.Damage
                }
            };
        }
        public HeroEditVM cast2HeroEditVM(Hero hero)
        {
            return new HeroEditVM
            {
                HeroName = hero.HeroName,
                HP = hero.HP,
                ElementType = hero.ElementType,
                SuperPowerName = hero.SuperPower.Name,
                Description = hero.SuperPower.Description,
                Damage = hero.SuperPower.Damage,
                HeroId = hero.Id,
                SuperPowerId = hero.SuperPower.Id
            };
        }
    }
}
