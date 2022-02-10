using System;
using System.ComponentModel.DataAnnotations;

namespace Projet2Crowdfunding.Models
{
    public class ProjectOwnerAccount : Account
    {
        [Required]
        [Display(Name = "Charte de Confidentialité")]
        public Boolean ConfidentialityCharter { get; set; }

        public virtual NewsLetter NewsLetter { get; set; }
    }
}
