using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projet2Crowdfunding.Models
{
    public enum Status { submittedForEvaluation, validated,  sumittedForPublishing, 
        Publié, submittedForTwins, publishedTwins, Clôturé, cancelled}
    public enum Category { Animaux, Environnement, Humanitaire, Education, Santé, BesoinsElémentaires, Autre}

    public class Project
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "État")]
        public Status? Status { get; set; }

        [MaxLength(100)]
        [Required]
        [Display(Name = "Nom")]
        public string Name { get; set; }

        [MaxLength(190)]
        [Column(TypeName = "text")]
        [Required]
        [Display(Name = "Résumé")]
        public string Summary { get; set; }

        [Column(TypeName = "text")]
        [Required]
        [Display(Name = "Description")]
        public string Descritpion { get; set; }

        [MaxLength(250)]
        [Display(Name = "Image")]
        public string Picture { get; set; }

        [Required]
        [Display(Name = "Catégorie")]
        public Category? Category { get; set; }

        [MaxLength(100)]
        [Required]
        [Display(Name = "Localisation")]
        public string? Location { get; set; }

        [Display(Name = "Date de démarrage")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "Date de clôture")]
        public DateTime EndDate { get; set; }

        [MaxLength(250)]
        [Display(Name = "Vidéo")]
        public string Video { get; set; }

        [Column(TypeName = "text")]
        [Display(Name = "Don matériel")]
        public string MaterialDonation { get; set; }

        [Required]
        public int? ProjectOwnerId { get; set; }
        public virtual ProjectOwner ProjectOwner { get; set; }

        [Required]
        public int HeartCounter { get; set; } //pour le projet

    }
}
