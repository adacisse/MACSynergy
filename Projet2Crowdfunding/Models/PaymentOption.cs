using System;
using System.ComponentModel.DataAnnotations;

namespace Projet2Crowdfunding.Models
{
    public abstract class PaymentOption
    {
        public int Id { get; set; }

        [Required]
        public Boolean RegisterCard { get; set; }


    }
}
