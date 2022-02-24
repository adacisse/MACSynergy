using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Projet2Crowdfunding.Models;
using Projet2Crowdfunding.Service;
using Projet2Crowdfunding.ViewModels;
using Stripe;
using Stripe.Checkout;
using AccountService = Projet2Crowdfunding.Service.AccountService;

namespace Projet2Crowdfunding.Controllers
{
    public class PaymentsController : Controller
    {
        PaymentService paymentService;
        AccountService accountService;
        ProjectService projectService;
        private IWebHostEnvironment _env;

        public PaymentsController(IWebHostEnvironment environment)
            
        {
            paymentService = new PaymentService();
            accountService = new AccountService();
            projectService = new ProjectService();
            _env = environment;
            StripeConfiguration.ApiKey = "sk_test_51KUbEVFZdOzBn1VnNLVh8lPPu6fTUDUrkMOS7lOremlO7jGBkZg54ArHR0wd3tRAQTtfYmRUGZ0xJmSMkF0RX6iV00nrUzdcIC";
        }
        
        [HttpPost]
        public IActionResult CreateCheckoutSession(PaymentViewModel viewModel) 

        {
            var options = new SessionCreateOptions
            {
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        PriceData = new SessionLineItemPriceDataOptions
                        {

                            UnitAmount = (long?)(viewModel.Amount*100),
                            Currency = "eur",
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = "Contribution",
                            },

                        },
                        Quantity = 1,
                    },
                },
                Mode = "payment",
                SuccessUrl = "http://localhost:5000/Payments/PaymentSuccess",
                CancelUrl = "http://localhost:5000/Home/Index",
            };
            
            var service = new SessionService();
            Session session = service.Create(options);

            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);
        }

        public IActionResult PaymentPage()
        {
            BddContext ctx = new BddContext();

            PaymentViewModel viewModel = new PaymentViewModel { Authentify = HttpContext.User.Identity.IsAuthenticated }; //cookies
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                viewModel.Account = accountService.GetAccount(HttpContext.User.Identity.Name);
                viewModel.Participant = accountService.GetParticipantFromAccountId(viewModel.Account.Id);
            }
            return View(viewModel);
        }
      

        public IActionResult ProjectPaymentPage(int? id)
        {
            BddContext ctx = new BddContext();
                       
            PaymentViewModel viewModel = new PaymentViewModel { Authentify = HttpContext.User.Identity.IsAuthenticated }; //cookies

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                viewModel.Account = accountService.GetAccount(HttpContext.User.Identity.Name);
                viewModel.Participant = accountService.GetParticipantFromAccountId(viewModel.Account.Id);
            }
            viewModel.Project = ctx.Projects.Find(id);
            return View(viewModel);
        }

        public IActionResult PaymentSuccess()
        {
            BddContext ctx = new BddContext();

            PaymentViewModel viewModel = new PaymentViewModel { Authentify = HttpContext.User.Identity.IsAuthenticated }; //cookies
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                viewModel.Account = accountService.GetAccount(HttpContext.User.Identity.Name);
                viewModel.Participant = accountService.GetParticipantFromAccountId(viewModel.Account.Id);
            }
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult CreateCheckoutSession2(int? id, PaymentViewModel viewModel)
        {
            double amount = viewModel.Amount;
            var options = new SessionCreateOptions
            {
                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {

                        UnitAmount = (long?)amount * 100,
                        Currency = "eur",
                          ProductData = new SessionLineItemPriceDataProductDataOptions
                          {
                            Name = "Contribution",
                          },

                    },
                    Quantity = 1,
                },
            },
            Mode = "payment",
            SuccessUrl = "http://localhost:5000/Payments/PaymentSuccess",
            CancelUrl = "http://localhost:5000/Home/Index",
            };

            var service = new SessionService();
            Session session = service.Create(options);

            viewModel = new PaymentViewModel { Authentify = HttpContext.User.Identity.IsAuthenticated }; //cookies

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                viewModel.Account = accountService.GetAccount(HttpContext.User.Identity.Name);
                viewModel.Participant = accountService.GetParticipantFromAccountId(viewModel.Account.Id);
                viewModel.Project = projectService.GetProject(id);
            }
            paymentService.CreateDonation(id,viewModel.Participant.Id, amount );

            //Envoie Mail
            using (MailMessage mm = new MailMessage("macssynergy@gmail.com", viewModel.Account.Mail))
            {
                mm.Subject = "Facture de votre Donnation sur MACSynergy";
                mm.Body = "Bonjour Mr/Mme " + viewModel.Participant.LastName + ",\n\n" +
                    "Merci pour votre contribution au projet !! \n\n" +
                    "Vous trouverez ci-dessous le récapitulatif de votre donation.\n\n" +
                    "Nom du project : " + viewModel.Project.Name + " \n" +
                    "Date de clôture du project : " + viewModel.Project.EndDate.ToString("dd/MM/yyyy") + " \n" +
                    "Montant donné : " + amount + " € \n\n\n" +
                    "A bientôt sur MACSynergy!";

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
            }

            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);
        }

    }
}