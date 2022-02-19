using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projet2Crowdfunding.Models
{
    public enum ProjectOwnerType { Association, ONG}
    public enum AssoStatus { registered, published, rejected}

    public class ProjectOwner
    {
        public int Id { get; set; }

        [MaxLength(15)]
        [Required]
        [Display(Name = "Numéro de téléphone")]
        public string PhoneNumber { get; set; }

        [MaxLength(45)]
        [Required]
        [Display(Name = "Nom de l'organisation")]
        public string Name { get; set; }

        [Column(TypeName= "text")]
        [Required]
        [Display(Name = "Résumé de l'organisation")]
        public string Summary { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "Description de l'organisation")]
        public string Description { get; set; }

        [MaxLength(100)]
        [Display(Name = "Lien Hypertext")]
        public string HyperLink { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "Description volontariat")]
        public string VolunteerDescritpion { get; set; }

        [MaxLength(300)]
        [Display(Name = "Partenariat")]
        public string Partnership { get; set; }

        [Required]
        public ProjectOwnerType Type { get; set; }

        [MaxLength(250)]
        [Required]
        [Display(Name = "Justificatif de l'organisation")]
        public string AssociationProof { get; set; }

        [MaxLength(250)]
        [Display(Name = "Logo")]
        public string Image { get; set; }

        [Required]
        [Display(Name = "État")]
        public AssoStatus Status { get; set; }

        [Required]
        [Display(Name = "Charte de Confidentialité")]
        public Boolean ConfidentialityCharter { get; set; }

        public Boolean Newsletter { get; set; }

        [Required]
        [Display(Name = "Adresse")]
        public int? AddressId { get; set; }
        public virtual Address Address { get; set; }

        [Required]
        public int? AccountId { get; set; }
        public virtual Account Account { get; set; }

    }
}
