using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projet2Crowdfunding.Models
{
    public enum Gender { Male, Female, Other }
    public class Participant
    {
        public int Id { get; set; }

        [MaxLength(45)]
        [Required]
        [Display(Name = "Nom")]
        public string LastName { get; set; }

        [MaxLength(45)]
        [Required]
        [Display(Name = "Prénom")]
        public string FirstName { get; set; }

        [Display(Name = "Genre")]
        public Gender Gender { get; set; }

        [MaxLength(15)]
        [Display(Name = "Numéro de Téléphone")]
        public string PhoneNumber { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Date de naissance")]
        public DateTime? Birthdate { get; set; }

        [Required]
        public int? AccountId { get; set; }
        public virtual Account Account { get; set; }

        public int? AddressId { get; set; }
        public virtual Address Address { get; set; }

      
    }
}
