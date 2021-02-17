using System;
using ToHModels;
using ToHBL;
using ToHDL;
namespace ToHUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IMenu menu = new HeroMenu(new HeroBL(new HeroRepoFile()));
            menu.Start();
        }
    }
}
