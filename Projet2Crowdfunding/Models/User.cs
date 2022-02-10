using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projet2Crowdfunding.Models
{
    public class User
    {
        [Required]
        [Display(Name = "Compte")]
        public virtual Account Account { get; set; }


        [MaxLength(15)]
        [Required]
        [Display(Name = "Numéro de téléphone")]
        public string PhoneNumber { get; set; }
    }
}
