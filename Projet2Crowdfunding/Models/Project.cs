using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projet2Crowdfunding.Models
{
    public enum ProjectState { published, inProgress}
    public class Project
    {
        public int Id { get; set; }

        [Required]
        public ProjectState ProjectState { get; set; }

        [MaxLength(100)]
        [Required]
        public string ProjectName { get; set; }

        [Column(TypeName = "text" )]
        [Required]
        public string ProjectSummary { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string ProjectDescritpion { get; set; }

        [MaxLength(250)]
        public string Picture { get; set; }

        [MaxLength(50)]
        [Required]
        public string ProjectCategory { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [MaxLength(250)]
        public string Video { get; set; }

        [Column(TypeName = "text")]
        public string MaterialDonation { get; set; }
    }
}
