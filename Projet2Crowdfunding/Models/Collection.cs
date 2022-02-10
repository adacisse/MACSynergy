using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projet2Crowdfunding.Models
{
    public class Collection
    {
        public int Id { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public virtual Donation Donation { get; set; }
        public int? DonationId { get; set; }

        [Required]
        public virtual Project Project { get; set; }
    }
}
