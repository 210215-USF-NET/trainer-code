using System;
namespace ToHModels
{
    public class SuperPower
    {
        public int Damage { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public override string ToString() => $"\n\t name: {this.Name} \n\t damage: {this.Damage} \n\t description: {this.Description}";
    }
}