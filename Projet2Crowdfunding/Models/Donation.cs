using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projet2Crowdfunding.Models
{
    public class Donation
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Montant")]
        public double Amount { get; set; }

        [Required]
        public int? ProjectId { get; set; }
        public virtual Participant Participant { get; set; }

        [Required]
        public int? CollectionId { get; set; }
        public virtual Collection Collection { get; set; }
        
    }
}
