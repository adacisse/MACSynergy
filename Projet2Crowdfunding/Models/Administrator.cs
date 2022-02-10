using System;
using System.ComponentModel.DataAnnotations;

namespace Projet2Crowdfunding.Models
{
    public class Administrator
    {
        public int Id { get; set; }


        [MaxLength(45)]
        [Required]
        [Display(Name = "Nom")]
        public string LastName { get; set; }

        [MaxLength(45)]
        [Required]
        [Display(Name = "Prenom")]
        public string FirstName { get; set; }

        [Display(Name = "Genre")]
        public Gender Gender { get; set; }

        [MaxLength(15)]
        [Display(Name = "Numéro de Téléphone")]
        public string PhoneNumber { get; set; }

        public int? AddressId { get; set; }
        public virtual Address Address { get; set; }


    }
}
