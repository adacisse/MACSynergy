using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projet2Crowdfunding.Service;
using Projet2Crowdfunding.ViewModels;
using Stripe;
using Stripe.Checkout;

namespace Projet2Crowdfunding.Controllers
{
    public class PaymentsController : Controller
    {

        public PaymentsController()
        {
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
            return View();
        }
        public IActionResult PaymentSuccess()
        {
            return View();
        }

        public IActionResult ProjectPaymentPage()
        {
            return View();
        }

        public IActionResult ProjectPaymentSuccess()
        {
            return View();
        }

    }
}