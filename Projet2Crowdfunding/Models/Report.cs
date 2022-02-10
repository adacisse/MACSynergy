using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projet2Crowdfunding.Models
{
    public class Report
    {
        [Column(TypeName = "text")]
        [Required]
        [Display(Name = "Charte de Confidentialité")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Charte de Confidentialité")]
        public virtual User User { get; set; }

        [Display(Name = "Charte de Confidentialité")]
        public virtual ProjectOwner ProjectOwner { get; set; }
  
        [Display(Name = "Charte de Confidentialité")]
        public virtual Project Project { get; set; }

    }
}
