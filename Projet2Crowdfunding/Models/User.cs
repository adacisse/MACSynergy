using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projet2Crowdfunding.Models
{
    public class User
    {
        public int Id { get; set; }

        [MaxLength(15)]
        [Required]
        [Display(Name = "Numéro de téléphone")]
        public string PhoneNumber { get; set; }

        [Required]     
        public int? AccountId { get; set; }
        public virtual Account Account { get; set; }

    }
}
