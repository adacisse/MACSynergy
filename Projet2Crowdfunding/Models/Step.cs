using System;
using System.ComponentModel.DataAnnotations;

namespace Projet2Crowdfunding.Models
{
    public class Step
    {
        public int Id { get; set; }

        [Required]
        public double Amount { get; set; }

        [MaxLength(250)]
        [Required]
        public string Desccription { get; set; }

        [Required]
        public virtual Project Project { get; set; }
    }
}
