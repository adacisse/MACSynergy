using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projet2Crowdfunding.Models
{
    public class CreditCard
    {
        [MaxLength(16)]
        [Required]
        [Display(Name = "Carte bancaire")]
        public string card_number { get; set; }

        [MaxLength(10)]
        [Required]
        [Column(TypeName = "Date d'expiration")] //affichage colonne sql
        [Display(Name = "Date d'expiration")]
        public DateTime? expiration_date { get; set; }

        [MaxLength(3)]
        [Required]
        public string cvv { get; set; }

        [MaxLength(100)]
        [Required]
        [Display(Name = "Nom du propriétaire de la carte")]
        public string owner_name { get; set; }

        [Required]
        [Display(Name = "Id de la transaction")] //Identifiant de transaction pour le proprio de la carte
        public int transaction_id { get; set; }


    }
}
