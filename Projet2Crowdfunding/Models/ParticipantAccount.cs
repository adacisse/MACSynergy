using System;
using System.ComponentModel.DataAnnotations;

namespace Projet2Crowdfunding.Models
{
    public class ParticipantAccount : Account
    {
        public int Id { get; set; }

        [Required]
        public Boolean Newsletter { get; set; }

        [Required]
        [Display(Name = "Charte de Confidentialité")]
        public Boolean ConfidentialityCharter { get; set; }
    }
}
