using System;
using System.ComponentModel.DataAnnotations;

namespace Projet2Crowdfunding.Models
{
    public class Favorite
    {
        public Favorite()
        {
        }

        [Required]
        public int id { get; set; }

        [Display (Name ="Id du projet")]
        [Required]
        public int project_id { get; set; }

        [Display(Name = "Id du participant")]
        [Required]
        public int participant_id { get; set; }

    }
}
