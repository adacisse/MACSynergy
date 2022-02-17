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
    public class ParticipantController : Controller
    {
        private AccountService accountService;

        public ParticipantController()
        {
            accountService = new AccountService();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PDashboard()
        {
            AccountViewModel viewModel = new AccountViewModel { Authentify = HttpContext.User.Identity.IsAuthenticated }; //cookies
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                viewModel.Account = accountService.GetAccount(HttpContext.User.Identity.Name);
                viewModel.Participant = accountService.GetParticipantFromAccountId(viewModel.Account.Id);
                return View(viewModel);
            }
            return View(viewModel);
        }
                
        //public IActionResult ModifyParticipant(int Id)
        //{
        //    if (Id != 0)
        //    {
        //        BddContext ctx = new BddContext();
        //        Participant participant = ctx.Participants.Find(Id);
        //        if (participant == null)
        //        {
        //            return View("Error");
        //        }
        //        return View(participant);
        //    }
        //    return View("Error");

        //}

        //[HttpPost]
        //public IActionResult ModifyParticipant(Participant participant)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(participant);
        //    }

        //    if (participant.Id != 0)
        //    {
        //        ParticipantService ps = new ParticipantService();
        //        ps.ModifyParticipant(participant.Id, participant.LastName, participant.FirstName,
        //            participant.Gender, participant.PhoneNumber, participant.Birthdate);
        //        return RedirectToAction("Index");

        //    }
        //    else
        //    {
        //        return View("Error");
        //    }
        //}

    }

    
}
