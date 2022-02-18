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

<<<<<<< HEAD
        public List<Donation> DonationList { get; set; }
=======
        public List<ProjectOwner> ProjectOwnerList { get; set; }

>>>>>>> 7b7616b5f85caf1778439d89a1291d8edcb62028
        [Display(Name = "Justificatif de l'organisation")]
        public IFormFile AssociationProof { get; set; }

        public IFormFile AssoLogo { get; set; }

        public IFormFile ProjectImage { get; set; }

        public IFormFile ProjectVideo { get; set; }

        public double sumDonations { get; set; }//somme dons
        public static object Models { get; private set; }

        public TimeSpan TimeLeftProject { get; set; }
        public Collection Collection { get; set; }


    }
}
