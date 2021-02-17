using System.Collections.Generic;
using ToHModels;
using System.IO;
using System.Text.Json;
namespace ToHDL
{
    public class HeroRepoFile : IHeroRepository
    {
        private string jsonString;
        private string filePath = "./ToHDL/HeroFiles.json";
        public Hero AddHero(Hero newHero)
        {
            jsonString = JsonSerializer.Serialize(newHero);
            File.WriteAllText(filePath, jsonString);
            return newHero;
        }

        public List<Hero> GetHeroes()
        {
            jsonString = File.ReadAllText(filePath);
            Hero fileHero = JsonSerializer.Deserialize<Hero>(jsonString);
            return new List<Hero> { fileHero };
        }
    }
}