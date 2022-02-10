using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projet2Crowdfunding.Models
{
    public abstract class Account
    {
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        [Display(Name = "Adresse Email")]
        public string Mail { get; set; }

        [MaxLength(45)]
        [Required]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }
    }
}
