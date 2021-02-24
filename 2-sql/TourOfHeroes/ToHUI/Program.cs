using ToHBL;
using ToHDL;
using ToHDL.Entities;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;
namespace ToHUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //get the config file
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            //setting up db connection
            string connectionString = configuration.GetConnectionString("HeroDB");
            DbContextOptions<HeroDBContext> options = new DbContextOptionsBuilder<HeroDBContext>()
            .UseSqlServer(connectionString)
            .Options;

            //using statement used to dispose of the context when its no longer used 
            using var context = new HeroDBContext(options);

            IMenu menu = new HeroMenu(new HeroBL(new HeroRepoDB(context, new HeroMapper())));
            menu.Start();
        }
    }
}
