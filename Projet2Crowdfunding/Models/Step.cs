using System;
using System.ComponentModel.DataAnnotations;

namespace Projet2Crowdfunding.Models
{
    public class Step
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Montant)]
        public double Amount { get; set; }

        [MaxLength(250)]
        [Required]
        public string Description { get; set; }

        [Required]
        public int? ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}
