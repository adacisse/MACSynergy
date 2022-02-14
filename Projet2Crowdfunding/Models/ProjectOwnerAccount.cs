using System;
using System.ComponentModel.DataAnnotations;

namespace Projet2Crowdfunding.Models
{
    public class ProjectOwnerAccount
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Charte de Confidentialité")]
        public Boolean ConfidentialityCharter { get; set; }

        [Required]
        public Boolean Newsletter { get; set; }

        [Required]
        public int? AccountId { get; set; }
        public virtual Account Account { get; set; }

    }
}
