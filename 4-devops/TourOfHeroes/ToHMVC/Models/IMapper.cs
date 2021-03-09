using ToHModels;

namespace ToHMVC.Models
{
    public interface IMapper
    {
        Hero cast2Hero(HeroCRVM hero2BCasted);
        HeroIndexVM cast2HeroIndexVM(Hero hero2BCasted);
        HeroCRVM cast2HeroCRVM(Hero hero);
        HeroEditVM cast2HeroEditVM(Hero hero);
        Hero cast2Hero(HeroEditVM hero2BCasted);
    }
}