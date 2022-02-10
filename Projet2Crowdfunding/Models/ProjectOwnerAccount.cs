using System;
using System.ComponentModel.DataAnnotations;

namespace Projet2Crowdfunding.Models
{
    public class ProjectOwnerAccount : Account
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Charte de Confidentialité")]
        public Boolean ConfidentialityCharter { get; set; }

        public int? NewsletterId { get; set; }
        public virtual NewsLetter NewsLetter { get; set; }
    }
}
