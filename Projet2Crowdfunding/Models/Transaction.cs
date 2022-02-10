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
        public virtual Donation Donation { get; set; }

        [Required]
        public DateTime TransationDate { get; set; }
    }
}
