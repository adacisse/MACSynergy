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
    public class ProjectController : Controller
    {
        private BddContext bddContext;
        private AccountService accountService;
        public ProjectController()
        {
            accountService = new AccountService();
            bddContext = new BddContext();
        }

        public IActionResult Index() {
            AccountViewModel viewModel = new AccountViewModel();
            viewModel.Project = accountService.GetProjectFromProjectOwnerId(1);
            return View(viewModel);
        }

        public IActionResult projectPage()
        {
            
            return View();
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
