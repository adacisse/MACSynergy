using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projet2Crowdfunding.Models
{
    public class ProjectOwner
    {
        public int Id { get; set; }

        [MaxLength(45)]
        [Required]
        public string AssociationName { get; set; }

        [Column(TypeName= "text")]
        [Required]
        public string Summary { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        [MaxLength(100)]
        public string HyperLink { get; set; }

        [Column(TypeName = "text")]
        public string VolunteerDescritpion { get; set; }

        [MaxLength(300)]
        public string Partnership { get; set; }

        [MaxLength(15)]
        [Required]
        public string PhoneNumber { get; set; }

        [MaxLength(50)]
        [Required]
        public string Category { get; set; }

        [MaxLength(45)]
        [Required]
        public string Type { get; set; }

        [MaxLength(250)]
        [Required]
        public string AssociationProof { get; set; }

        [MaxLength(250)]
        public string Image { get; set; }

        [MaxLength(45)]
        [Required]
        public string State { get; set; }

        [Required]
        public virtual Account Account { get; set; }

        [Required]
        public virtual Address Address { get; set; }

    }
}
