using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projet2Crowdfunding.Models;

namespace Projet2Crowdfunding.Controllers
{
    public class AccountController : Controller
    {
        private BddContext bddContext;
        public IActionResult LoginPage()
        {
            return View();
        }
        //[HttpPost, ActionName("Login")]

        //public IActionResult UserLogin(string Mail, string Password)
        //{
            
<<<<<<< HEAD
<<<<<<< HEAD
            bddContext = new BddContext();
            bddContext.Accounts.FindAsync();
=======
        //    bddContext = new BddContext();
        //    bddContext.Accounts.FindAsync();
>>>>>>> eea739a249fe00475d5143939202fa323f0cd0d4
=======

            //bddContext = new BddContext();
            //bddContext.Accounts.FindAsync();
>>>>>>> c038d3f2e5ee69acd06da341b504e74b71f0a562

        //    return View();
        //}
    }
}