using System;
using System.ComponentModel.DataAnnotations;

namespace Projet2Crowdfunding.Models
{
    public class PayPalAccount : PaymentOption
    {
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        [Display(Name = "Email")]
        public string Mail { get; set; }
    }
}
