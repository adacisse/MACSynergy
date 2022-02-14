using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projet2Crowdfunding.Models;
using Projet2Crowdfunding.Service;
using Projet2Crowdfunding.ViewModels;

namespace Projet2Crowdfunding.Controllers
{
    public class AccountController : Controller
    {
        private AccountService accountService;
        public AccountController()
        {
            accountService = new AccountService();
        }
       
        public IActionResult LoginPage()
        {
           AccountViewModel viewModel = new AccountViewModel { Authentify = HttpContext.User.Identity.IsAuthenticated }; //cookies
            if (viewModel.Authentify)
            {
                viewModel.Account = accountService.ObtenirUtilisateur(HttpContext.User.Identity.Name);
                return View(viewModel);
            }
            return View(viewModel);
        }

       
    //[HttpPost, ActionName("Login")]

    //public IActionResult UserLogin(string Mail, string Password)
    //{
    //    bddContext = new BddContext();
    //    bddContext.Accounts.FindAsync();

    //bddContext = new BddContext();
    //bddContext.Accounts.FindAsync();

    //    return View();
    //}
}
}