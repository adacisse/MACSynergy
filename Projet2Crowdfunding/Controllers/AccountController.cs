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
            if (ModelState.IsValid)  //Au lieu de Modelstate.isValid   
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
                    Thread.Sleep(2000);

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
        public IActionResult GpInscription(Account account, Administrator administrator)
        {
            if (ModelState.IsValid)
            {
                int idAccount = accountService.CreateAccount(account.Mail, account.Password);

                int idAdministrator = accountService.CreateAdministrator(account, idAccount, administrator.LastName,
                    administrator.FirstName, administrator.PhoneNumber);

                var userClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, account.Mail),
                    new Claim(ClaimTypes.Name, account.Id.ToString()), //appelé dans la ligne 25
                    new Claim(ClaimTypes.Role, account.Role)
                };

                var ClaimIdentity = new ClaimsIdentity(userClaims, "User Identity");

                var userPrincipal = new ClaimsPrincipal(new[] { ClaimIdentity });
                HttpContext.SignInAsync(userPrincipal);

                return Redirect("/");
            }
            return View(administrator);
        }

        public IActionResult ParticipantInscription()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ParticipantInscription(Account account, Participant participant)
        {
            if (participant.ConfidentialityCharter == true)
            {
                if (ModelState.IsValid)
                {
                    int idAccount = accountService.CreateAccount(account.Mail, account.Password);

                    int idParticipant = accountService.CreateParticipant(account, idAccount, participant.LastName,
                        participant.FirstName);

                    var userClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, account.Mail),
                    new Claim(ClaimTypes.Name, account.Id.ToString()), //appelé dans la ligne 25
                    new Claim(ClaimTypes.Role, account.Role)
                };

                    var ClaimIdentity = new ClaimsIdentity(userClaims, "User Identity");

                    var userPrincipal = new ClaimsPrincipal(new[] { ClaimIdentity });
                    HttpContext.SignInAsync(userPrincipal);

                    return Redirect("/");
                }
            } else
            {
                ModelState.AddModelError("Participant.ConfidentialityCharter", "La politique de confidentialité doit être acceptée");
            }
            
            return View(participant);
        }

        public IActionResult PPInscription()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PPInscription(Account account, ProjectOwner projectOwner)
        {
            if (projectOwner.ConfidentialityCharter == true)
            {
                if (ModelState.IsValid)
                {
                    int idAccount = accountService.CreateAccount(account.Mail, account.Password);

                    int idProjectOwner = accountService.CreateProjectOwner(account, idAccount, projectOwner.Name,
                        projectOwner.PhoneNumber, projectOwner.Summary, projectOwner.Description, projectOwner.HyperLink,
                        projectOwner.VolunteerDescritpion, projectOwner.Partnership, projectOwner.Type, projectOwner.Image,
                        projectOwner.AssociationProof, projectOwner.Address.StreetName, projectOwner.Address.StreetName,
                        projectOwner.Address.ZipCode, projectOwner.Address.City, projectOwner.Address.Country);

                    var userClaims = new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, idAccount.ToString()),
                };

                    var ClaimIdentity = new ClaimsIdentity(userClaims, "User Identity");

                    var userPrincipal = new ClaimsPrincipal(new[] { ClaimIdentity });
                    HttpContext.SignInAsync(userPrincipal);

                    return Redirect("/");
                }
            } else
            {
                ModelState.AddModelError("ProjectOwner.ConfidentialityCharter", "La politique de confidentialité doit être acceptée");
            }
             
            return View(projectOwner);
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