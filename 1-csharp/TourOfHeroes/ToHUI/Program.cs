using System;
using ToHModels;
using ToHBL;
namespace ToHUI
{
    class Program
    {
        private static IHeroBL heroBL = new HeroBL();
        static void Main(string[] args)
        {
            // Create hero method/logic
            Hero newHero = new Hero();
            Console.WriteLine("Enter Hero Name: ");
            newHero.HeroName = Console.ReadLine();
            Console.WriteLine("Enter HP value: ");
            newHero.HP = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter SuperPower details");
            SuperPower newSuperPower = new SuperPower();
            Console.WriteLine("Enter SuperPower name:");
            newSuperPower.Name = Console.ReadLine();
            Console.WriteLine("Enter SuperPower description");
            newSuperPower.Description = Console.ReadLine();
            Console.WriteLine("Enter SuperPower damage");
            newSuperPower.Damage = int.Parse(Console.ReadLine());
            newHero.SuperPower = newSuperPower;
            Console.WriteLine("Set the element of the hero: ");
            newHero.ElementType = Enum.Parse<Element>(Console.ReadLine());

            heroBL.AddHero(newHero);
            foreach (var item in heroBL.GetHeroes())
            {
                Console.WriteLine(item.ToString());
            }


        }
    }
}
