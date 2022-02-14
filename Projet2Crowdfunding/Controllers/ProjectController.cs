using Microsoft.AspNetCore.Mvc;
using Projet2Crowdfunding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projet2Crowdfunding.Controllers
{
    public class ProjectController : Controller
    {
        private BddContext bddContext;
        public IActionResult ProjectPage()
        {
            return View();
        }
    }
}
