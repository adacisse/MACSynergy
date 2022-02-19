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

        public Step Step1 { get; set; }

        public Step Step2 { get; set; }

        public Step Step3 { get; set; }

        public List<Project> ProjectList { get; set; }

        public List<Project> ProjectListClosed { get; set; }

        public List<Donation> DonationList { get; set; }

        public List<ProjectOwner> ProjectOwnerList { get; set; }

        [Display(Name = "Justificatif de l'organisation")]
        public IFormFile AssociationProof { get; set; }

        public IFormFile AssoLogo { get; set; }

        public IFormFile ProjectImage { get; set; }

        public IFormFile ProjectVideo { get; set; }

        public double sumDonations { get; set; }//somme dons

        public static object Models { get; private set; }

        public TimeSpan TimeLeftProject { get; set; }

        public Collection Collection { get; set; }
        
        public List<Collection> CollectionList { get; set; }

        public PayPalAccount PayPalAccount { get; set; }

        public CreditCard CreditCard { get; set; }

        public List<Step> ProjectStepsList { get; set; }
        //public List<Participant>AllParticipants

        public List<Favorite> MyFavoritesList { get; set; }
        public int HeartCounter { get; set; }


    }
}
