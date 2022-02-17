using Microsoft.AspNetCore.Mvc;
using Projet2Crowdfunding.Models;
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

        public IActionResult Index()
        {

            return View();
        }
        public IActionResult ProjectPage()
        {
            
            return View();
            
        }
        public IActionResult PaymentPage()//view de dons financiers à faire
        {
            return View("PaymentPage");
        }
        
    }
}
