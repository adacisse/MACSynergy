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
        private HomeService homeService;

        public HomeController()
        {
            accountService = new AccountService();
            projectService = new ProjectService();
            projectOwnerService = new ProjectOwnerService();
            homeService = new HomeService();
        }

        public IActionResult Index()
        {
            HomeViewModel viewModel = new HomeViewModel { Authentify = HttpContext.User.Identity.IsAuthenticated }; //cookies
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                viewModel.Account = accountService.GetAccount(HttpContext.User.Identity.Name);
            }
            viewModel.ProjectList = projectService.GetAllProjectsStatus(Status.Publié); //Ajouter aussi pour POPage
            viewModel.ProjectOwnerList = projectOwnerService.GetAllProjectOwnersStatus(AssoStatus.published);
            viewModel.Inscriptions = homeService.GetInscriptions();
            viewModel.PublishedProjects = homeService.GetPublishedProjects();
            viewModel.ClosedProjects = homeService.GetClosedProjects();
            viewModel.AmountTotal = homeService.GetTotalAmount();

            return View(viewModel);
        }

    }
}
