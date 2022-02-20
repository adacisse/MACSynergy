using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [Column(TypeName = "date")]
        [Display(Name = "Date de payment")]
        public DateTime PayDate { get; set; }

        [Required]
        public int? ParticipantId { get; set; }
        public virtual Participant Participant { get; set; }

        [Required]
        public int? CollectionId { get; set; }
        public virtual Collection Collection { get; set; }

       

    }
}
