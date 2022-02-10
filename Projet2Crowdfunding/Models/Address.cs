using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projet2Crowdfunding.Models
{
    public class Address
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Numéro")]
        public string StreetNumber { get; set; }

        [Required]
        [MaxLength(45)]
        [Display(Name = "Rue")]
        public string StreetName { get; set; }

        [Required]
        [MaxLength(10)]
        [Display(Name = "Code Postal")]
        public string ZipCode { get; set; }

        [Required]
        [MaxLength(45)]
        [Display(Name = "Ville")]
        public string City { get; set; }

        [Required]
        [MaxLength(45)]
        [Display(Name = "Pays")]
        public string Country { get; set; }

    }
}
