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
    public class AdminController : Controller
    {
        private AccountService accountService;
        private ProjectService projectService;

        public AdminController()
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
                return View(viewModel);
            }
            return View(viewModel);
        }
    }
}
