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
    public class AdminController : Controller
    {
        private AccountService accountService;
        private ProjectService projectService;
        private ProjectOwnerService projectOwnerService;

        public AdminController()
        {
            accountService = new AccountService();
            projectService = new ProjectService();
            projectOwnerService = new ProjectOwnerService();
            projectService = new ProjectService();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AdminDashboard()
        {
            AccountViewModel viewModel = new AccountViewModel { Authentify = HttpContext.User.Identity.IsAuthenticated }; //cookies
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                viewModel.Account = accountService.GetAccount(HttpContext.User.Identity.Name);
                viewModel.Administrator = accountService.GetAdminFromAccountId(viewModel.Account.Id);
                viewModel.ProjectOwnerList = projectOwnerService.GetAllProjectOwnersStatus(AssoStatus.registered);
                viewModel.ProjectList = projectService.GetAllProjectsStatus(Status.sumittedForPublishing);
                return View(viewModel);
            }
            return View(viewModel);
        }

        public IActionResult ModifyAdminInfos(Administrator administrator)
        {
            if (administrator.Id != 0)
            {
                AdminService ps = new AdminService();
                ps.ModifyAdminInfos(administrator.Id, administrator.LastName, administrator.FirstName);
                return RedirectToAction("AdminDashboard");
            }
            else
            {
                return View("Error");
            }
        }

        public IActionResult ModifyAdminPhone(Administrator administrator)
        {
            if (administrator.Id != 0)
            {
                AdminService ps = new AdminService();
                ps.ModifyAdminPhone(administrator.Id, administrator.PhoneNumber);
                return RedirectToAction("AdminDashboard");
            }
            else
            {
                return View("Error");
            }
        }

        public IActionResult ModifyAdminEmail(Account account)
        {
            if (account.Id != 0)
            {
                AdminService ps = new AdminService();
                ps.ModifyAdminEmail(account.Id, account.Mail);
                return RedirectToAction("AdminDashboard");
            }
            else
            {
                return View("Error");
            }
        }

        public IActionResult ModifyAdminPwd(Account account)
        {
            if (account.Id != 0)
            {
                AdminService ps = new AdminService();
                ps.ModifyAdminPwd(account.Id, account.Password);
                return RedirectToAction("AdminDashboard");
            }
            else
            {
                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult ModifyProjectOwnerStatus (ProjectOwner projectOwner)
        {
            if (projectOwner.Id != 0)
            {
                ProjectOwnerService ps = new ProjectOwnerService();
                ps.ModifyProjectOwnerStatus(projectOwner.Id, projectOwner.Status);
                return RedirectToAction("AdminDashboard");
            }
            else
            {
                return View("Error");
            }
        }
    }
}
