using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projet2Crowdfunding.Models;
using Projet2Crowdfunding.Service;
using Projet2Crowdfunding.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public HomeController()
        {
            accountService = new AccountService();
            projectService = new ProjectService();
            projectOwnerService = new ProjectOwnerService();
            homeService = new HomeService();
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

        //[HttpPost]
        //public IActionResult Index(string mailTo)
        //{
        //    using (MailMessage mm = new MailMessage(model.Email, model.To))
        //    {
        //        mm.Subject = model.Subject;
        //        mm.Body = model.Body;
        //        if (model.Attachment.Length > 0)
        //        {
        //            string fileName = Path.GetFileName(model.Attachment.FileName);
        //            mm.Attachments.Add(new Attachment(model.Attachment.OpenReadStream(), fileName));
        //        }
        //        mm.IsBodyHtml = false;
        //        using (SmtpClient smtp = new SmtpClient())
        //        {
        //            smtp.Host = "smtp.gmail.com";
        //            smtp.EnableSsl = true;
        //            NetworkCredential NetworkCred = new NetworkCredential(model.Email, model.Password);
        //            smtp.UseDefaultCredentials = true;
        //            smtp.Credentials = NetworkCred;
        //            smtp.Port = 587;
        //            smtp.Send(mm);
        //            ViewBag.Message = "Email sent.";
        //        }
        //    }

        //    return View();
        //}

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
