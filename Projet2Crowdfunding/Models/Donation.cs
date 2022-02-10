using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projet2Crowdfunding.Models
{
    public class Donation
    {
        public int Id { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public virtual Participant Participant { get; set; }
    }
}
