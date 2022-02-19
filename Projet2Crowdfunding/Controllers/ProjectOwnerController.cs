using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projet2Crowdfunding.Models;
using Projet2Crowdfunding.Service;
using Projet2Crowdfunding.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Projet2Crowdfunding.Controllers
{
    public class ProjectOwnerController : Controller
    {
        private AccountService accountService;
        private ProjectService projectService;
        private IWebHostEnvironment _env;

        public ProjectOwnerController(IWebHostEnvironment environment)
        {
            accountService = new AccountService();
            projectService = new ProjectService();
            _env = environment;
        }

        public IActionResult PODashboard()
        {
            AccountViewModel viewModel = new AccountViewModel { Authentify = HttpContext.User.Identity.IsAuthenticated }; //cookies
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                viewModel.Account = accountService.GetAccount(HttpContext.User.Identity.Name);
                viewModel.ProjectOwner = accountService.GetProjectOwnerFromAccountId(viewModel.Account.Id);
                viewModel.ProjectList = projectService.GetProjectsFromProjectOwnerId(viewModel.ProjectOwner.Id);
                viewModel.CollectionList = projectService.GetAllCollections();
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
                viewModel.ProjectOwner.Account = accountService.GetAccount((int)viewModel.ProjectOwner.AccountId);
                viewModel.ProjectList = projectService.GetProjectsFromPOIdStatus(id.Value, Status.Publié);
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

        public IActionResult ModifyProjectOwnerAddress(ProjectOwner projectOwner)
        {
            if (projectOwner.Id != 0)
            {
                ProjectOwnerService ps = new ProjectOwnerService();
                ps.ModifyProjectOwnerAddress(projectOwner.Id, projectOwner.Address.StreetNumber, projectOwner.Address.StreetName, projectOwner.Address.ZipCode,
                    projectOwner.Address.City, projectOwner.Address.Country);
                return RedirectToAction("PODashboard");
            }
            else
            {
                return View("Error");
            }
        }

        public IActionResult ModifyProjectOwnerPhone(ProjectOwner projectOwner)
        {
            if (projectOwner.Id != 0)
            {
                ProjectOwnerService ps = new ProjectOwnerService();
                ps.ModifyProjectOwnerPhone(projectOwner.Id, projectOwner.PhoneNumber);
                return RedirectToAction("PODashboard");
            }
            else
            {
                return View("Error");
            }
        }

        public IActionResult ModifyProjectOwnerDescription(ProjectOwner projectOwner)
        {
            if (projectOwner.Id != 0)
            {
                ProjectOwnerService ps = new ProjectOwnerService();
                ps.ModifyProjectOwnerDescription(projectOwner.Id, projectOwner.Summary, projectOwner.Description, projectOwner.VolunteerDescritpion, projectOwner.Partnership);
                return RedirectToAction("PODashboard");
              }
            else
            {
                return View("Error");
            }
        }

        public IActionResult ModifyProjectOwnerLogo(AccountViewModel viewModel, IFormFile AssoLogo)
        {            
            string fileName = "";
            if (viewModel.AssoLogo != null)
            {
                fileName = Path.GetFileName(viewModel.AssoLogo.FileName);
                var filePath = _env.ContentRootPath + "\\wwwroot\\ImageAssos";
                using (var fileSteam = new FileStream(Path.Combine(filePath, fileName), FileMode.Create))
                {
                    viewModel.AssoLogo.CopyTo(fileSteam);
                }
            }

            if (viewModel.ProjectOwner.Id != 0)
            {
                ProjectOwnerService ps = new ProjectOwnerService();
                ps.ModifyProjectOwnerLogo(viewModel.ProjectOwner.Id, fileName);
                return RedirectToAction("PODashboard");
            }
            else
            {
                return View("Error");
            }
        }


    }
  
}
