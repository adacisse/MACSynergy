using HtmlAgilityPack;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projet2Crowdfunding.Models;
using Projet2Crowdfunding.Service;
using Projet2Crowdfunding.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Projet2Crowdfunding.Controllers
{
    public class HomeController : Controller
    {
        private AccountService accountService;
        private ProjectService projectService;
        private ProjectOwnerService projectOwnerService;
        private HomeService homeService;
        private IWebHostEnvironment _env;

        public HomeController(IWebHostEnvironment environment)
        {
            accountService = new AccountService();
            projectService = new ProjectService();
            projectOwnerService = new ProjectOwnerService();
            homeService = new HomeService();
            _env = environment;
        }

        public IActionResult Index()
        {
            HomeViewModel viewModel = new HomeViewModel { Authentify = HttpContext.User.Identity.IsAuthenticated }; //cookies
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                viewModel.Account = accountService.GetAccount(HttpContext.User.Identity.Name);
            }
            viewModel.ProjectList = projectService.GetAllProjectsStatus(Status.Publié); //Ajouter aussi pour POPage
            viewModel.ProjectOwnerList = projectOwnerService.GetAllProjectOwnersStatus(AssoStatus.published);
            viewModel.Inscriptions = homeService.GetInscriptions();
            viewModel.PublishedProjects = homeService.GetPublishedProjects();
            viewModel.ClosedProjects = homeService.GetClosedProjects();
            viewModel.AmountTotal = homeService.GetTotalAmount();
            viewModel.ProjectListFavorites = homeService.Get8ProjetsFavorits();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(string mailTo)
        {
            HomeViewModel viewModel = new HomeViewModel { Authentify = HttpContext.User.Identity.IsAuthenticated }; //cookies
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                viewModel.Account = accountService.GetAccount(HttpContext.User.Identity.Name);
                if (viewModel.Account.Role == "participant")
                {
                    viewModel.Participant = accountService.GetParticipantFromAccountId(viewModel.Account.Id);
                }
            }           
            viewModel.ProjectList = projectService.GetAllProjectsStatus(Status.Publié); //Ajouter aussi pour POPage
            viewModel.ProjectOwnerList = projectOwnerService.GetAllProjectOwnersStatus(AssoStatus.published);
            viewModel.Inscriptions = homeService.GetInscriptions();
            viewModel.PublishedProjects = homeService.GetPublishedProjects();
            viewModel.ClosedProjects = homeService.GetClosedProjects();
            viewModel.AmountTotal = homeService.GetTotalAmount();
            viewModel.ProjectListFavorites = homeService.Get8ProjetsFavorits();

            using (MailMessage mm = new MailMessage("macssynergy@gmail.com", mailTo))
            {
                mm.Subject = "Newsletter de MACSynergy";                
                mm.Body = "Bienvenue sur la Newletter de MACSynergy.\n\n\nNous vous tiendrons informés de nouveautés sur notre site.\n\n\nA bientôt sur MACSYnergy!!";
                   
                    //mm.IsBodyHtml = true;
                    //var doc = new HtmlDocument();
                    //FileStream htmlPath = new FileStream(_env.WebRootPath + "\\html\\Newsletter.html", FileMode.Open);
                    //doc.Load(htmlPath);
                    //mm.Body = doc.DocumentNode.OuterHtml;

                mm.Attachments.Add(new System.Net.Mail.Attachment(_env.ContentRootPath + "/wwwroot/Images/logoMacSynergy.png"));

                mm.IsBodyHtml = false;
                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential("macssynergy@gmail.com", "Macsynergy4");
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;
                    smtp.Send(mm);
                }

                accountService.CreateNewsletter(mailTo);
            }

            return View(viewModel);
        }

        ////CREATIN DU COMPTE HELPER
        //[HttpPost]
        //public IActionResult CreerHelper(CompteProvider compteProvider, IFormFile pictureFile, List<string> competences)
        //{
        //    ProviderViewModel viewModel = new ProviderViewModel { Authentifie = HttpContext.User.Identity.IsAuthenticated };
        //    CompteConsumer compteConsumer = dal.ObtenirConsumer(HttpContext.User.Identity.Name);
        //    using (Dal ctx = new Dal())
        //    {
        //        ctx.AjouterProvider(compteConsumer, compteProvider.Rib.Iban, compteProvider.Rib.Bic, compteProvider.Rib.TitulaireCompte, pictureFile, competences);
        //        if (pictureFile != null)
        //        {
        //            if (pictureFile.Length > 0)
        //            {
        //                string path3 = _env.WebRootPath + "/media/provider/" + pictureFile.FileName;
        //                FileStream stream3 = new FileStream(path3, FileMode.Create);
        //                pictureFile.CopyTo(stream3);
        //            }
        //        }
        //        MailMessage message = new MailMessage();
        //        message.From = new MailAddress("helpmycar.isika@gmail.com", "HelpMyCar");
        //        message.To.Add(compteConsumer.Profil.Mail);
        //        message.Subject = "Helper chez HelpMyCar";
        //        message.IsBodyHtml = true;
        //        var doc = new HtmlDocument();
        //        FileStream cheminHtml = new FileStream(_env.WebRootPath + "/html/WelcomeHelper.html", FileMode.Open);
        //        doc.Load(cheminHtml);
        //        message.Body = doc.DocumentNode.OuterHtml;
        //        var smtp = new SmtpClient
        //        {
        //            Host = "smtp.gmail.com",
        //            Port = 587,
        //            EnableSsl = true,
        //            DeliveryMethod = SmtpDeliveryMethod.Network,
        //            UseDefaultCredentials = false,
        //            Credentials = new NetworkCredential("helpmycar.isika@gmail.com", "helpmycar2021")
        //        };
        //        {
        //            smtp.Send(message);
        //        }
        //        return Redirect("../Profil/Index");
        //    }
        //}





    }
}
