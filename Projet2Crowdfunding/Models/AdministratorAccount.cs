using System;
using System.ComponentModel.DataAnnotations;

namespace Projet2Crowdfunding.Models
{
    public class AdministratorAccount
    {
        public int Id { get; set; }

        [Required]
        public int? AccountId { get; set; }
        public virtual Account Account { get; set; }

    }
}
