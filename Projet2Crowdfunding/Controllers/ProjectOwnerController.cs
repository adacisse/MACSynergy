using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projet2Crowdfunding.Controllers
{
    public class ProjectOwnerController : Controller
    {
        public IActionResult PODashboard()
        {
            return View();
        }
    }
  
}
