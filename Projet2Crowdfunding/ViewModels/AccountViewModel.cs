using System;
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

        [Display(Name = "Justificatif de l'organisation")]
        public IFormFile AssociationProof { get; set; }

        public IFormFile AssoLogo { get; set; }

        public IFormFile ProjectImage { get; set; }

        public IFormFile ProjectVideo { get; set; }
    }
}
