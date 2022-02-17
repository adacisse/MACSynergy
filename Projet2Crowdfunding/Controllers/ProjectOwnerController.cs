﻿using Microsoft.AspNetCore.Mvc;
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
            return View();
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


    }
  
}