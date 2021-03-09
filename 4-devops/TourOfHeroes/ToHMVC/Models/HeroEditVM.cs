using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ToHModels;

namespace ToHMVC.Models
{
    /// <summary>
    /// Needed to store the Id of the hero I'm going to update
    /// </summary>
    public class HeroEditVM
    {
        [Required]
        [DisplayName("Hero Name")]
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

        public int HeroId { get; set; }
        public int SuperPowerId { get; set; }
    }
}