using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ToHModels;

namespace ToHMVC.Models
{
    /// <summary>
    /// Hero View Model for creating and reading heroes
    /// </summary>
    public class HeroCRVM
    {
        [DisplayName("Hero Name")]
        [Required]
        public string HeroName { get; set; }

        [Required]
        [Range(1, Int32.MaxValue, ErrorMessage = "HP should be positive!")]
        public int HP { get; set; }

        [DisplayName("Element")]
        [Required]
        public Element ElementType { get; set; }

        [DisplayName("Name of hero's superpower")]
        [Required]
        public string SuperPowerName { get; set; }

        [DisplayName("Description of hero's superpower")]
        [Required]
        public string Description { get; set; }

        [DisplayName("Damage of hero's superpower")]
        [Required]
        [Range(0, Int32.MaxValue, ErrorMessage = "Damage should be non negative!")]
        public int Damage { get; set; }
    }
}