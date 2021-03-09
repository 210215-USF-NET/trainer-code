using System.ComponentModel;
using ToHModels;

namespace ToHMVC.Models
{
    /// <summary>
    /// Model for the index view of my app
    /// </summary>
    public class HeroIndexVM
    {
        //Data annotation
        //Can be used for display purposes, and also for validation
        [DisplayName("Hero Name")]
        public string HeroName { get; set; }

        public int HP { get; set; }

        [DisplayName("Element")]
        public Element ElementType { get; set; }
    }
}