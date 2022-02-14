using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projet2Crowdfunding.Models;

namespace Projet2Crowdfunding.Controllers
{
    public class UserController : Controller
    {
        private BddContext bddContext;
        public IActionResult LoginPage()
        {
            return View();
        }
        [HttpPost, ActionName("Login")]

        public IActionResult UserLogin(string Mail, string Password)
        {
            
            bddContext = new BddContext();
            bddContext.Users.FindAsync();

            return View();
        }
    }
}