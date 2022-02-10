using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projet2Crowdfunding.Models
{
    public class CreditCard
    {
        public int Id { get; set; }

        [MaxLength(25)]
        [Required]
        [Display(Name = "Numéro de Carte")]
        public string CardNumber { get; set; }

        [MaxLength(10)]
        [Required]
        [Column(TypeName = "Date")] 
        [Display(Name = "Date d'expiration")]
        public DateTime ExpirationDate { get; set; }

        [MaxLength(5)]
        [Required]
        public string Cvv { get; set; }

        [MaxLength(100)]
        [Required]
        [Display(Name = "Nom du titulaire")]
        public string OwnerName { get; set; }

    }
}
