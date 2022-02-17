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
    public class ProjectOwnerController : Controller
    {
        private AccountService accountService;
        private ProjectService projectService;

        public ProjectOwnerController()
        {
            accountService = new AccountService();
            projectService = new ProjectService();
        }

        public IActionResult PODashboard()
        {
            AccountViewModel viewModel = new AccountViewModel { Authentify = HttpContext.User.Identity.IsAuthenticated }; //cookies
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                viewModel.Account = accountService.GetAccount(HttpContext.User.Identity.Name);
                viewModel.ProjectOwner = accountService.GetProjectOwnerFromAccountId(viewModel.Account.Id);
                return View(viewModel);
            }
            return View(viewModel);
        }


        public IActionResult POPage(int? id)
        {
            AccountViewModel viewModel = new AccountViewModel { Authentify = HttpContext.User.Identity.IsAuthenticated }; //cookies
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                viewModel.Account = accountService.GetAccount(HttpContext.User.Identity.Name);
            }
            if (id.HasValue)
            {
                viewModel.ProjectOwner = accountService.GetProjectOwner(id.Value);
                viewModel.ProjectList = projectService.GetProjectsFromProjectOwnerId(id.Value);
            }

            return View(viewModel);
            
        }

        public IActionResult ModifyProjectOwner(int Id)
        {
            if (Id != 0)
            {
                BddContext ctx = new BddContext();
                ProjectOwner projectOwner = ctx.ProjectOwners.Find(Id);
                if (projectOwner == null)
                {
                    return View("Error");
                }
                return View(projectOwner);
            }
            return View("Error");

        }

        [HttpPost]
        public IActionResult ModifyProjectOwnerInfos(ProjectOwner projectOwner)
        {
            if (projectOwner.Id != 0)
            {
                ProjectOwnerService ps = new ProjectOwnerService();
                ps.ModifyProjectOwnerInfos(projectOwner.Id, projectOwner.Name, projectOwner.Type,
                    projectOwner.HyperLink);
                return RedirectToAction("PODashboard");

            }
            else
            {
                return View("Error");
            }
        }


    }
  
}
