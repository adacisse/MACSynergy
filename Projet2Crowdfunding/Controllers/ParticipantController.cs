using Microsoft.AspNetCore.Mvc;
using Projet2Crowdfunding.Models;
using Projet2Crowdfunding.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projet2Crowdfunding.Controllers
{
    public class ParticipantController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PDashboard()
        {
            return View();
        }
                
        //public IActionResult ModifyParticipant(int Id)
        //{
        //    if (Id != 0)
        //    {
        //        BddContext ctx = new BddContext();
        //        Participant participant = ctx.Participants.Find(Id);
        //        if (participant == null)
        //        {
        //            return View("Error");
        //        }
        //        return View(participant);
        //    }
        //    return View("Error");

        //}

        //[HttpPost]
        //public IActionResult ModifyParticipant(Participant participant)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(participant);
        //    }

        //    if (participant.Id != 0)
        //    {
        //        ParticipantService ps = new ParticipantService();
        //        ps.ModifyParticipant(participant.Id, participant.LastName, participant.FirstName,
        //            participant.Gender, participant.PhoneNumber, participant.Birthdate);
        //        return RedirectToAction("Index");

        //    }
        //    else
        //    {
        //        return View("Error");
        //    }
        //}

    }

    
}
