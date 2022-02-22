using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Projet2Crowdfunding.Models
{
    public class NewsLetter
    {
        public int Id { get; set; }

        [Required]
        public string Mail { get; set; }

    }
}