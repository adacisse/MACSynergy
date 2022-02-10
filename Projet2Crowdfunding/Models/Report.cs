using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projet2Crowdfunding.Models
{
    public enum ReportStatus { ToProcess, Processed }
    public class Report
    {
        public int Id { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Description { get; set; }

        [Required]
        public int? ParticipantId { get; set; }
        public virtual Participant Participant { get; set; }

        public int? ProjectOwnerId { get; set; }
        public virtual ProjectOwner ProjectOwner { get; set; }

        public int? ReceiveProjectOwnerId { get; set; }
        public virtual ProjectOwner ReceiveProjectOwner { get; set; }
  
        public int? ProjectId { get; set; }
        public virtual Project Project { get; set; }

        public ReportStatus Status { get; set; }
    }
}
