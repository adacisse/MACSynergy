using System;
using System.ComponentModel.DataAnnotations;

namespace Projet2Crowdfunding.Models
{
    public enum TransactionType { Payment, Reimbursement }

    public class Transaction
    { 
        public int Id { get; set; }

        
        [Required]
        public TransactionType Type { get; set; }

        [Required]
        public int? DonationId { get; set; }
        public virtual Donation Donation { get; set; }

        [Required]
        [Display(Name = "Date de transaction")]
        public DateTime TransationDate { get; set; }

        public int? CreditCardId { get; set; }
        public virtual CreditCard CreditCard { get; set; }

        public int? PaypalAccountId { get; set; }
        public virtual PayPalAccount PaypalAccount { get; set; }

        

    }
}
