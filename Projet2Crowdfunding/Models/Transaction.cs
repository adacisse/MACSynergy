using System;
using System.ComponentModel.DataAnnotations;

namespace Projet2Crowdfunding.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        [MaxLength(45)]
        [Required]
        public string Type { get; set; }

        [Required]
        public int? DonationId { get; set; }
        public virtual Donation Donation { get; set; }

        [Required]
        [Display(Name = "Date de transaction")]
        public DateTime TransationDate { get; set; }
    }
}
