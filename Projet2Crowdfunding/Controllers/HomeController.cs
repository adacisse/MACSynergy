using Microsoft.AspNetCore.Http;
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
    public class HomeController : Controller
    {
        private AccountService accountService;
        private ProjectService projectService;
        private ProjectOwnerService projectOwnerService;

        public HomeController()
        {
            accountService = new AccountService();
            projectService = new ProjectService();
            projectOwnerService = new ProjectOwnerService();
        }

        public IActionResult Index()
        {
            HomeViewModel viewModel = new HomeViewModel { Authentify = HttpContext.User.Identity.IsAuthenticated }; //cookies
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                viewModel.Account = accountService.GetAccount(HttpContext.User.Identity.Name);
            }
            viewModel.ProjectList = projectService.GetAllProjectsStatus(Status.published); //Ajouter aussi pour POPage
            viewModel.ProjectOwnerList = projectOwnerService.GetAllProjectOwnersStatus(AssoStatus.published);

            return View(viewModel);
        }

    }
}
