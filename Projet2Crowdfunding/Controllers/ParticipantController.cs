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
        private ProjectService projectService;

        public ParticipantController()
        {
            accountService = new AccountService();
            projectService = new ProjectService();
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
                viewModel.ProjectList = projectService.GetFavorites(viewModel.Participant.Id);
                viewModel.ProjectList2 = projectService.GetProjectDonationFromParticipant(viewModel.Participant.Id);
                viewModel.DonationList = projectService.GetDonationFromParticipant(viewModel.Participant.Id);
                viewModel.CollectionList = projectService.GetAllCollections();
                return View(viewModel);
            }
            return View(viewModel);
        }

        public IActionResult ModifyParticipant(int Id)
        {
            if (Id != 0)
            {
                BddContext ctx = new BddContext();
                Participant participant = ctx.Participants.Find(Id);
                if (participant == null)
                {
                    return View("Error");
                }
                return View(participant);
            }
            return View("Error");

        }

        [HttpPost]
        public IActionResult ModifyParticipantInfos(Participant participant)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(participant);
            //}

            if (participant.Id != 0)
            {
                ParticipantService ps = new ParticipantService();
                ps.ModifyParticipantInfos(participant.Id, participant.LastName, participant.FirstName,
                    participant.Gender, participant.Birthdate);
                return RedirectToAction("PDashboard");

            }
            else
            {
                return View("Error");
            }
        }

        public IActionResult ModifyParticipantPhone(Participant participant)
        {
            if (participant.Id != 0)
            {
                ParticipantService ps = new ParticipantService();
                ps.ModifyParticipantPhone(participant.Id, participant.PhoneNumber);
                return RedirectToAction("PDashboard");

            }
            else
            {
                return View("Error");
            }
        }

        public IActionResult ModifyParticipantEmail(Account account)
        {
            if (account.Id != 0)
            {
                ParticipantService ps = new ParticipantService();
                ps.ModifyParticipantEmail(account.Id, account.Mail);
                return RedirectToAction("PDashboard");

            }
            else
            {
                return View("Error");
            }
        }

        public IActionResult ModifyParticipantPwd(Account account)
        {
            if (account.Id != 0)
            {
                ParticipantService ps = new ParticipantService();
                ps.ModifyParticipantPwd(account.Id, account.Password);
                return RedirectToAction("PDashboard");

            }
            else
            {
                return View("Error");
            }
        }

        public IActionResult ModifyParticipantAddress(Participant participant)
        {
            if (participant.Id != 0)
            {
                ParticipantService ps = new ParticipantService();
                ps.ModifyParticipantAddress(participant.Id, participant.Address.StreetNumber, participant.Address.StreetName, participant.Address.ZipCode,
                    participant.Address.City, participant.Address.Country);
                return RedirectToAction("PDashboard");

            }
            else
            {
                return View("Error");
            }
        }

    }
    


}
