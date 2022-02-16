using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Projet2Crowdfunding.Models;
using Projet2Crowdfunding.Service;
using Projet2Crowdfunding.ViewModels;

namespace Projet2Crowdfunding.Controllers
{
    public class AccountController : Controller
    {
        private AccountService accountService;
        public AccountController()
        {
            accountService = new AccountService();
        }
       
        public IActionResult LoginPage()
        {
            AccountViewModel viewModel = new AccountViewModel { Authentify = HttpContext.User.Identity.IsAuthenticated }; //cookies
            
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                viewModel.Account = accountService.GetAccount(HttpContext.User.Identity.Name);
                return Redirect("/Home/Index");
            }
            return View(viewModel);
        }


        [HttpPost]
        public IActionResult LoginPage(AccountViewModel viewModel, string returnUrl)
        //returnUrl stock /sejour/index; retourne l'Url initial à la quelle on voulais accèder avant l'autentification
        {
            if (ModelState.IsValid) 
            {
                Account account = accountService.Login(viewModel.Account.Mail, viewModel.Account.Password);
                if (account != null)
                {
                    var userClaims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier, account.Mail),
                        new Claim(ClaimTypes.Name, account.Id.ToString()), //appelé dans la ligne 25
                        new Claim(ClaimTypes.Role, account.Role)
                    };

                    var ClaimIdentity = new ClaimsIdentity(userClaims, "User Identity");

                    var userPrincipal = new ClaimsPrincipal(new[] { ClaimIdentity });

                    HttpContext.SignInAsync(userPrincipal);

                    if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                        return Redirect(returnUrl);

                    return Redirect("/");
                }
                ModelState.AddModelError("Account.Password", "Email et/ou mot de passe incorrect(s)");
            }
            return View(viewModel);
        }

        public IActionResult GpInscription()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GpInscription(AccountViewModel viewModel)
        {
            if (viewModel.Account.Mail != null && viewModel.Account.Password != null &&
                    viewModel.Administrator.FirstName != null && viewModel.Administrator.LastName != null &&
                    viewModel.Administrator.PhoneNumber != null && viewModel.Administrator.Type != null)
            {
                int idAccount = accountService.CreateAccount(viewModel.Account.Mail, viewModel.Account.Password);

                int idAdministrator = accountService.CreateAdministrator(idAccount, viewModel.Administrator.LastName,
                    viewModel.Administrator.FirstName, viewModel.Administrator.PhoneNumber, viewModel.Administrator.Type);

                var userClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, viewModel.Account.Mail),
                    new Claim(ClaimTypes.Name, idAccount.ToString()), //appelé dans la ligne 25
                    new Claim(ClaimTypes.Role, "admin")
                };

                var ClaimIdentity = new ClaimsIdentity(userClaims, "User Identity");

                var userPrincipal = new ClaimsPrincipal(new[] { ClaimIdentity });
                HttpContext.SignInAsync(userPrincipal);

                return Redirect("/");
            }
            return View(viewModel);
        }

        public IActionResult ParticipantInscription()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ParticipantInscription(AccountViewModel viewModel)
        {
            if (viewModel.Participant.ConfidentialityCharter == true)
            {
                //if (ModelState.IsValid)
                if (viewModel.Account.Mail != null && viewModel.Account.Password != null &&
                    viewModel.Participant.FirstName != null && viewModel.Participant.LastName != null)
                {
                    int idAccount = accountService.CreateAccount(viewModel.Account.Mail, viewModel.Account.Password);

                    int idParticipant = accountService.CreateParticipant(idAccount, viewModel.Participant.LastName,
                        viewModel.Participant.FirstName);

                    var userClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, viewModel.Account.Mail),
                    new Claim(ClaimTypes.Name, idAccount.ToString()), 
                    new Claim(ClaimTypes.Role, "participant")
                };

                    var ClaimIdentity = new ClaimsIdentity(userClaims, "User Identity");

                    var userPrincipal = new ClaimsPrincipal(new[] { ClaimIdentity });
                    HttpContext.SignInAsync(userPrincipal);

                    return Redirect("/Account/LoginPage");
                }
            } else
            {
                ModelState.AddModelError("Participant.ConfidentialityCharter", "La politique de confidentialité doit être acceptée");
            }
            
            return View(viewModel);
        }

        public IActionResult PPInscription()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PPInscription(AccountViewModel viewModel)
        {
            if (viewModel.ProjectOwner.ConfidentialityCharter == true && viewModel.Account.Mail != null && 
                viewModel.Account.Password != null && viewModel.ProjectOwner.PhoneNumber != null && 
                viewModel.ProjectOwner.Name != null && viewModel.ProjectOwner.Summary != null &&
                viewModel.ProjectOwner.Type != null && viewModel.ProjectOwner.AssociationProof != null &&
                viewModel.ProjectOwner.Address.StreetName != null && viewModel.ProjectOwner.Address.StreetNumber != null && 
                viewModel.ProjectOwner.Address.ZipCode != null && viewModel.ProjectOwner.Address.City != null && 
                viewModel.ProjectOwner.Address.Country != null)
            {
               
                int idAccount = accountService.CreateAccount(viewModel.Account.Mail, viewModel.Account.Password);

                int idProjectOwner = accountService.CreateProjectOwner(idAccount, viewModel.ProjectOwner.Name,
                    viewModel.ProjectOwner.PhoneNumber, viewModel.ProjectOwner.Summary, viewModel.ProjectOwner.Description,
                    viewModel.ProjectOwner.HyperLink, viewModel.ProjectOwner.VolunteerDescritpion, viewModel.ProjectOwner.Partnership, 
                    viewModel.ProjectOwner.Type, viewModel.ProjectOwner.Image, viewModel.ProjectOwner.AssociationProof, 
                    viewModel.ProjectOwner.Address.StreetName, viewModel.ProjectOwner.Address.StreetNumber, 
                    viewModel.ProjectOwner.Address.ZipCode, viewModel.ProjectOwner.Address.City, viewModel.ProjectOwner.Address.Country);

                var userClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, viewModel.Account.Mail),
                    new Claim(ClaimTypes.Name, idAccount.ToString()),
                    new Claim(ClaimTypes.Role, "po")
                };

                var ClaimIdentity = new ClaimsIdentity(userClaims, "User Identity");

                var userPrincipal = new ClaimsPrincipal(new[] { ClaimIdentity });
                HttpContext.SignInAsync(userPrincipal);

                return Redirect("/");
            }
           
            ModelState.AddModelError("ProjectOwner.ConfidentialityCharter", "La charte de confidentialité doivent être remplis");
            ModelState.AddModelError("ProjectOwner", "Les champs obligatoires doivent être remplis");


            return View(viewModel);
        }

        public IActionResult InscriptionChoice()
        {
            return View();
        }

        public IActionResult ForgetPassword()
        {
            return View();
        }

        public ActionResult Deconnexion()
        {
            HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}