using System;
using Projet2Crowdfunding.Models;

namespace Projet2Crowdfunding.ViewModels
{
    public class PaymentViewModel
    {
        internal bool Authentify;

        public double Amount { get; set; }
        public Donation Donation { get; set; }
        public Account Account { get; set; }
        public Participant Participant { get; set; }
    }
}
