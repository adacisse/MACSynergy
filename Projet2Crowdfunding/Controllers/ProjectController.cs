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
    //[Area("Project")]
    public class ProjectController : Controller
    {
        private BddContext bddContext;
        private AccountService accountService;
        private ParticipantService participantService;
        private ProjectService projectService;

        public ProjectController()
        {
            accountService = new AccountService();
            projectService = new ProjectService();
            participantService = new ParticipantService();
            bddContext = new BddContext();
        }

        public IActionResult Index()
        {
            AccountViewModel viewModel = new AccountViewModel { Authentify = HttpContext.User.Identity.IsAuthenticated }; //cookies
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                viewModel.Account = accountService.GetAccount(HttpContext.User.Identity.Name);
            }
            viewModel.ProjectList = projectService.GetAllProjectsStatus(Status.Publié);
            viewModel.ProjectListClosed = projectService.GetAllProjectsStatus(Status.Clôturé);

            return View(viewModel);
        }

        
        public IActionResult ProjectPage(int? id)

        {
            AccountViewModel viewModel = new AccountViewModel { Authentify = HttpContext.User.Identity.IsAuthenticated }; //cookies

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                viewModel.Account = accountService.GetAccount(HttpContext.User.Identity.Name);

            }
            if (id.HasValue)
            {
                viewModel.Project = projectService.GetProject(id.Value);
                viewModel.ProjectOwner = projectService.GetProjectOwnerFromProjectId(id.Value);
                viewModel.TimeLeftProject = projectService.TimeLeftCalculator(id.Value);
                viewModel.ProjectStepsList = projectService.GetStepsFromProjectId(id.Value);
                viewModel.HeartCounter = projectService.CountProjectFavoriteSum(id.Value);
                viewModel.Collection = projectService.GetCollectionByProjectId(id.Value);
                viewModel.PercentageInProgressBar = projectService.PercentageProgressBar(id.Value);


            }


            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddFavoriteOnClik(int? id)
        {
            AccountViewModel viewModel = new AccountViewModel { Authentify = HttpContext.User.Identity.IsAuthenticated }; //cookies
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                viewModel.Account = accountService.GetAccount(HttpContext.User.Identity.Name);
                
                viewModel.Participant = accountService.GetParticipantFromAccountId(viewModel.Account.Id);


            }
            if (id.HasValue)
            {
                viewModel.Project = projectService.GetProject(id.Value);
                viewModel.ProjectOwner = projectService.GetProjectOwnerFromProjectId(id.Value);
                viewModel.TimeLeftProject = projectService.TimeLeftCalculator(id.Value);
                viewModel.ProjectStepsList = projectService.GetStepsFromProjectId(id.Value);
                viewModel.HeartCounter = projectService.CountProjectFavoriteSum(id.Value);
                if (!projectService.IfExistFavorite(id.Value, viewModel.Participant.Id))
                {
                    viewModel.Project = projectService.AddAFavoriteForAParticipantOnAProject(id.Value, viewModel.Participant.Id);
                    
                }
                else
                { 
                    viewModel.Project = projectService.SuppressAFavoriteForAParticipantOnAProject(id.Value, viewModel.Participant.Id);
                }
               return  Redirect("/Project/ProjectPage/" +viewModel.Project.Id);
            }
            
            return View(viewModel);
        }
        /*      public IActionResult Index()
              {
                  AccountViewModel viewModel = new AccountViewModel { Authentify = HttpContext.User.Identity.IsAuthenticated }; //cookies
                  if (HttpContext.User.Identity.IsAuthenticated)
                  {
                      viewModel.Account = accountService.GetAccount(HttpContext.User.Identity.Name);
                      viewModel.ProjectOwner = accountService.GetProjectOwnerFromAccountId(viewModel.Account.Id);
                      viewModel.Project = accountService.GetProjectFromProjectOwnerId(viewModel.ProjectOwner.Id);
                      return View(viewModel);
                  }
                  else { 

                  }
                  return View(viewModel);

              }
              public IActionResult ProjectPage()
              {
                  AccountViewModel viewModel = new AccountViewModel { Authentify = HttpContext.User.Identity.IsAuthenticated }; //cookies
                  if (HttpContext.User.Identity.IsAuthenticated)
                  {
                      viewModel.Account = accountService.GetAccount(HttpContext.User.Identity.Name);
                      viewModel.ProjectOwner = accountService.GetProjectOwnerFromAccountId(viewModel.Account.Id);
                      viewModel.Project = accountService.GetProjectFromProjectOwnerId(viewModel.ProjectOwner.Id);
                      return View(viewModel);
                  }
                  return View(viewModel);


              }*/
        public IActionResult PaymentPage()//view de dons financiers à faire
        {
            return View("PaymentPage");
        }
        
    }
}
