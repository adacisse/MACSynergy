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
        public int? UserId { get; set; }
        public virtual User User { get; set; }

        public int? ProjectOwnerId { get; set; }
        public virtual ProjectOwner ProjectOwner { get; set; }
  
        public int? ProjectId { get; set; }
        public virtual Project Project { get; set; }

        public ReportStatus Status { get; set; }
    }
}
