using Projet2Crowdfunding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projet2Crowdfunding.ViewModels
{
    public class HomeViewModel
    {
        public Account Account { get; set; }

        public bool Authentify { get; set; }

        public Participant Participant { get; set; }

        public Administrator Administrator { get; set; }

        public ProjectOwner ProjectOwner { get; set; }

        public Project Project { get; set; }

        public List<Project> ProjectList { get; set; }

        public List<Project> ProjectListFavorites { get; set; }

        public List<ProjectOwner> ProjectOwnerList { get; set; }

        public int Inscriptions { get; set; }

        public int PublishedProjects { get; set; }

        public int ClosedProjects { get; set; }

        public double AmountTotal { get; set; }

        public Donation Donation { get; set; }
    }
}
