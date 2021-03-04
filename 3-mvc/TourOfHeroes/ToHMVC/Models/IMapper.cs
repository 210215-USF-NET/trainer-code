using ToHModels;

namespace ToHMVC.Models
{
    public interface IMapper
    {
        Hero cast2Hero(HeroCRVM hero2BCasted);
        HeroIndexVM cast2HeroIndexVM(Hero hero2BCasted);
    }
}