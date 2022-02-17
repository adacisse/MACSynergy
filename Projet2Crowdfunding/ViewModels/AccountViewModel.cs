using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Projet2Crowdfunding.Models;

namespace Projet2Crowdfunding.ViewModels
{
    public class AccountViewModel
    {
        public Account Account { get; set; }
        public bool Authentify { get; set; }

        public Participant Participant { get; set; }

        public Administrator Administrator { get; set; }

        public ProjectOwner ProjectOwner { get; set; }

        public Project Project { get; set; }

        public List<Project> ProjectList { get; set; }

        [Display(Name = "Justificatif de l'organisation")]
        public IFormFile AssociationProof { get; set; }

        public IFormFile AssoLogo { get; set; }

        public IFormFile ProjectImage { get; set; }

        public IFormFile ProjectVideo { get; set; }

        public int heartCounter { get; set; }//compteur total coups de couer

        public double sumDonations { get; set; }//somme dons
    }
}
