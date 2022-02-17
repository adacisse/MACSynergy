using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public HomeController()
        {
            accountService = new AccountService();
            projectService = new ProjectService();
        }

        public IActionResult Index()
        {
            AccountViewModel viewModel = new AccountViewModel { Authentify = HttpContext.User.Identity.IsAuthenticated }; //cookies
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                viewModel.Account = accountService.GetAccount(HttpContext.User.Identity.Name);
            }
            viewModel.ProjectList = projectService.GetAllProjects();

            return View(viewModel);
        }

    }
}
