using System;
using System.ComponentModel.DataAnnotations;

namespace Projet2Crowdfunding.Models
{
    public class Account
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

        [MaxLength(12)]
        public string Role {get; set;}
        //Role = "admin", "participant", "po"
    }
}
