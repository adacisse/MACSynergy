using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class CreateProjectController : Controller
    {

        private AccountService accountService;
        private ProjectService projectService;
        private ProjectOwnerService projectOwnerService;
        private CreateProjectService createProjectService;
        private IWebHostEnvironment _env;

        private string fileNameImage;
        public string fileNameVideo;

        public CreateProjectController(IWebHostEnvironment environment)
        {
            accountService = new AccountService();
            projectService = new ProjectService();
            projectOwnerService = new ProjectOwnerService();
            createProjectService = new CreateProjectService();
            _env = environment;
        }

        public IActionResult Index()
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

        [HttpPost]
        public IActionResult Index(AccountViewModel viewModel, IFormFile Picture)
        {
            viewModel.Authentify = HttpContext.User.Identity.IsAuthenticated; //cookies
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                viewModel.Account = accountService.GetAccount(HttpContext.User.Identity.Name);
                viewModel.ProjectOwner = accountService.GetProjectOwnerFromAccountId(viewModel.Account.Id);
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

                int idProject = createProjectService.CreateProject(viewModel.ProjectOwner.Id, viewModel.Project.Name,
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
