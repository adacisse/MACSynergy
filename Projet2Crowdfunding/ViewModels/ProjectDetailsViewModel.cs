using Projet2Crowdfunding.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projet2Crowdfunding.ViewModels
{
    public class ProjectDetailsViewModel
    {
        public Project Project { get; set; }
        public string PName { get; set; }
        public string logo { get; set; }

        [MaxLength(190)]
        public string resume { get; set; }
        public int heartCounter { get; set; }
        public double sumDonations { get; set; }




    }
}
