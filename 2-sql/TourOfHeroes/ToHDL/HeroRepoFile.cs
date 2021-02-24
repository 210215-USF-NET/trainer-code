using System.Collections.Generic;
using ToHModels;
using System.IO;
using System.Text.Json;
using System;
namespace ToHDL
{
    public class HeroRepoFile : IHeroRepository
    {
        private string jsonString;
        private string filePath = "./ToHDL/HeroFiles.json";
        public Hero AddHero(Hero newHero)
        {
            List<Hero> herosFromFile = GetHeroes();
            herosFromFile.Add(newHero);
            jsonString = JsonSerializer.Serialize(herosFromFile);
            File.WriteAllText(filePath, jsonString);
            return newHero;
        }

        public Hero GetHeroByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<Hero> GetHeroes()
        {
            try
            {
                jsonString = File.ReadAllText(filePath);
            }
            catch (Exception)
            {
                return new List<Hero>();
            }
            return JsonSerializer.Deserialize<List<Hero>>(jsonString);
        }
    }
}