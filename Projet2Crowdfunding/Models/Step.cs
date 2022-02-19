using System;
using System.ComponentModel.DataAnnotations;

namespace Projet2Crowdfunding.Models
{
    public class Step
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Montant souhaité (€)")]
        public double Amount { get; set; }

        [MaxLength(250)]
        [Required]
        [Display(Name = "Description du palier")]
        public string Description { get; set; }

        [Required]
        public int? ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}
