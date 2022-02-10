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

        [Display(Name = "Numéro")]
        public string StreetNumber { get; set; }

        [MaxLength(45)]
        [Display(Name = "Rue")]
        public string StreetName { get; set; }

        [MaxLength(10)]
        [Display(Name = "Code Postal")]
        public string ZipCode { get; set; }

        [MaxLength(45)]
        [Display(Name = "Ville")]
        public string City { get; set; }

        [MaxLength(45)]
        [Display(Name = "Pays")]
        public string Country { get; set; }

    }
}
