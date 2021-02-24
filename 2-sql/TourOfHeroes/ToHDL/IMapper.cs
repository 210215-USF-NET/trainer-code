using Model = ToHModels;
using Entity = ToHDL.Entities;
namespace ToHDL
{
    /// <summary>
    /// To parse entities from DB to models used in BL and vice versa 
    /// </summary>
    public interface IMapper
    {
        Model.Hero ParseHero(Entity.Hero hero);
        Entity.Hero ParseHero(Model.Hero hero);

        Model.SuperPower ParseSuperPower(Entity.Superpower superpower);
        Entity.Superpower ParseSuperPower(Model.SuperPower superPower);
    }
}