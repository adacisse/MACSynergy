using Microsoft.AspNetCore.Mvc;
using Projet2Crowdfunding.Models;
using Projet2Crowdfunding.Service;
using Projet2Crowdfunding.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projet2Crowdfunding.Controllers
{
    public class PaymentController : Controller
    {
        private BddContext bddContext;
        

        public IActionResult PaymentPage()
        {
            return View();
        }

        public IActionResult DonationPage(int? id)
        {
            AccountViewModel viewModel = new AccountViewModel { Authentify = HttpContext.User.Identity.IsAuthenticated }; //cookies
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                viewModel.Account = accountService.GetAccount(HttpContext.User.Identity.Name);
            }
            if (id.HasValue)
            {
                viewModel.Participant = accountService.GetParticipant(id.Value);
                viewModel.DonationList = paymentService.GetDonnationsFromParticipantId(id.Value);
            }

            return View(viewModel);

        }

    }
}
