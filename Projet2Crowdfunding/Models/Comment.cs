using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projet2Crowdfunding.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "Commentaire")]
        public string Comments { get; set; }

        public int? ProjectId { get; set; }
        public virtual Project Project { get; set; }

        public int? ParticipantId { get; set; }
        public virtual Participant Participant { get; set; }
    }
}
