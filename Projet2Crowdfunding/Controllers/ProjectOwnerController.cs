using Microsoft.AspNetCore.Authentication;
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
using System.Security.Claims;
using System.Threading.Tasks;

namespace Projet2Crowdfunding.Controllers
{
    public class ProjectOwnerController : Controller
    {
        private AccountService accountService;
        private ProjectService projectService;
        private CreateProjectService createProjectService;
        private IWebHostEnvironment _env;

        public ProjectOwnerController(IWebHostEnvironment environment)
        {
            accountService = new AccountService();
            projectService = new ProjectService();
            createProjectService = new CreateProjectService();
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

        [HttpPost]
        public IActionResult ModifyProject(AccountViewModel viewModel, IFormFile Picture)
        {
            string fileNameImage = "";
            string fileNameVideo = "";
            viewModel.Authentify = HttpContext.User.Identity.IsAuthenticated; //cookies
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                viewModel.Account = accountService.GetAccount(HttpContext.User.Identity.Name);
                viewModel.ProjectOwner = accountService.GetProjectOwnerFromAccountId(viewModel.Account.Id);
                viewModel.Project = accountService.GetProjectFromProjectOwnerId(viewModel.ProjectOwner.Id);
                List<Step> steps = projectService.GetStepsFromProjectId(viewModel.Project.Id);
                viewModel.Step1 = steps[0];
                viewModel.Step2 = new Step();
                viewModel.Step3 = new Step();
                if (steps.Count() > 1)
                {
                    viewModel.Step2 = steps[1];
                }
                if (steps.Count() > 2)
                {
                    viewModel.Step3 = steps[2];
                }
            }

            if (viewModel.Project.Name != null && viewModel.Project.Summary != null &&
                viewModel.Project.Descritpion != null && viewModel.Project.Category != null &&
                viewModel.Project.Location != null && viewModel.Project.EndDate != null &&
                viewModel.Step1.Amount != 0 && viewModel.Step1.Description != null)
            {
                if (viewModel.ProjectImage != null)
                {
                    fileNameImage = Path.GetFileName(viewModel.ProjectImage.FileName);
                    var filePath = _env.ContentRootPath + "\\wwwroot\\ImagesProject";
                    using (var fileSteam = new FileStream(Path.Combine(filePath, fileNameImage), FileMode.Create))
                    {
                        viewModel.ProjectImage.CopyTo(fileSteam);
                    }
                }

                if (viewModel.ProjectVideo != null)
                {
                    fileNameVideo = Path.GetFileName(viewModel.ProjectVideo.FileName);
                    var filePath = _env.ContentRootPath + "\\wwwroot\\VideosProject";
                    using (var fileSteam = new FileStream(Path.Combine(filePath, fileNameVideo), FileMode.Create))
                    {
                        viewModel.ProjectVideo.CopyTo(fileSteam);
                    }
                }

                createProjectService.ModifyProject(viewModel.Project.Id, viewModel.Project.Name,
                    viewModel.Project.Summary, viewModel.Project.Descritpion, viewModel.Project.Category,
                    viewModel.Project.Location, viewModel.Project.EndDate, fileNameImage, fileNameVideo,
                    viewModel.Project.MaterialDonation, viewModel.Step1.Amount, viewModel.Step1.Description,
                    viewModel.Step2.Amount, viewModel.Step2.Description, viewModel.Step3.Amount, viewModel.Step3.Description);

                var userClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, viewModel.Account.Mail),
                    new Claim(ClaimTypes.Name, viewModel.Account.Id.ToString()),
                    new Claim(ClaimTypes.Role, "po")
                };

                var ClaimIdentity = new ClaimsIdentity(userClaims, "User Identity");

                var userPrincipal = new ClaimsPrincipal(new[] { ClaimIdentity });
                HttpContext.SignInAsync(userPrincipal);

                return Redirect("/ProjectOwner/PODashboard");
            }

            ModelState.AddModelError("Project", "Les champs obligatoires doivent être remplis. Le montan des palier doit être en numérique.");


            return View(viewModel);
        }



    }
  
}
