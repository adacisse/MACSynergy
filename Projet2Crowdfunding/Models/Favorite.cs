using System;
using System.ComponentModel.DataAnnotations;

namespace Projet2Crowdfunding.Models
{
    public class Favorite
    {
        public int Id { get; set; }

        [Required]
        public int? ProjectId { get; set; }
        public virtual Project Project { get; set; }
        
        [Required]
        public int? ParticipantId { get; set; }
        public virtual Participant Participant { get; set; }
    }
}
