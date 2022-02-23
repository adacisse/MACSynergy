using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projet2Crowdfunding.Models;
using Projet2Crowdfunding.Service;
using Projet2Crowdfunding.ViewModels;

namespace Projet2Crowdfunding.Controllers
{
    public class AccountController : Controller
    {
        private AccountService accountService;
        private ProjectOwnerService projectOwnerService;
        private ProjectService projectService;
        private IWebHostEnvironment _env;
        private string fileNameProof;
        public string fileNameLogo;
       

        public AccountController(IWebHostEnvironment environment)
        {
            accountService = new AccountService();
            projectOwnerService = new ProjectOwnerService();
            projectService = new ProjectService();
            _env = environment;
        }
       
        public IActionResult LoginPage()
        {
            AccountViewModel viewModel = new AccountViewModel { Authentify = HttpContext.User.Identity.IsAuthenticated }; //cookies
            
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                viewModel.Account = accountService.GetAccount(HttpContext.User.Identity.Name);
                return View(viewModel);
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
            AccountViewModel viewModel = new AccountViewModel { Authentify = HttpContext.User.Identity.IsAuthenticated }; //cookies

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                viewModel.Account = accountService.GetAccount(HttpContext.User.Identity.Name);
                viewModel.Account.Mail = "";
                return View(viewModel);
            }
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult GpInscription(AccountViewModel viewModel)
        {
            if (accountService.IsMailValid(viewModel.Account.Mail) && viewModel.Account.Password.Length > 4 &&
                    viewModel.Administrator.FirstName != null && viewModel.Administrator.LastName != null &&
                    viewModel.Administrator.PhoneNumber != null && viewModel.Administrator.Type != null)
            {
                int idAccount = accountService.CreateAccount(viewModel.Account.Mail, viewModel.Account.Password);

                int idAdministrator = accountService.CreateAdministrator(idAccount, viewModel.Administrator.LastName,
                    viewModel.Administrator.FirstName, viewModel.Administrator.PhoneNumber, viewModel.Administrator.Type);

                viewModel = new AccountViewModel { Authentify = HttpContext.User.Identity.IsAuthenticated };
                if (HttpContext.User.Identity.IsAuthenticated)
                {
                    viewModel.Account = accountService.GetAccount(HttpContext.User.Identity.Name);
                    viewModel.Administrator = accountService.GetAdminFromAccountId(viewModel.Account.Id);
                    viewModel.ProjectOwnerList = projectOwnerService.GetAllProjectOwnersStatus(AssoStatus.registered);
                    viewModel.ProjectList = projectService.GetAllProjectsStatus(Status.sumittedForPublishing);
                }

                return Redirect("/Admin/AdminDashboard");
            }

            if (!accountService.IsMailValid(viewModel.Account.Mail))
                ModelState.AddModelError("Account.Mail", "Veuillez saisir un email valide");

            if (viewModel.Account.Password != null && viewModel.Account.Password.Length < 5)
                ModelState.AddModelError("Account.Password", "Veuillez utiliser 5 caractères au minimum pour le mot de passe");

            return View(viewModel);
        }

        public IActionResult ParticipantInscription()
        {
            AccountViewModel viewModel = new AccountViewModel { Authentify = HttpContext.User.Identity.IsAuthenticated }; //cookies

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                viewModel.Account = accountService.GetAccount(HttpContext.User.Identity.Name);
                return Redirect("/");
            }
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult ParticipantInscription(AccountViewModel viewModel)
        {
            if (viewModel.Participant.ConfidentialityCharter)
            {
                //if (ModelState.IsValid)
                if (accountService.IsMailValid(viewModel.Account.Mail) && viewModel.Account.Password.Length > 4  &&
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

                    return Redirect("/");
                }
            } 

            if (!accountService.IsMailValid(viewModel.Account.Mail))            
                ModelState.AddModelError("Account.Mail", "Veuillez saisir un email valide");
            
            if (viewModel.Account.Password != null && viewModel.Account.Password.Length < 5)            
                ModelState.AddModelError("Account.Password", "Veuillez utiliser 5 caractères au minimum pour le mot de passe");
            
            if (!viewModel.Participant.ConfidentialityCharter)
                ModelState.AddModelError("Participant.ConfidentialityCharter", "La politique de confidentialité doit être acceptée");
                        

            return View(viewModel);
        }

        public IActionResult PPInscription()
        {
            AccountViewModel viewModel = new AccountViewModel { Authentify = HttpContext.User.Identity.IsAuthenticated }; //cookies

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                viewModel.Account = accountService.GetAccount(HttpContext.User.Identity.Name);
                return View(viewModel);
            }
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult PPInscription(AccountViewModel viewModel, IFormFile AssociationProof)
        {
            if (viewModel.ProjectOwner.ConfidentialityCharter == true && accountService.IsMailValid(viewModel.Account.Mail) && 
                viewModel.Account.Password.Length > 4 && viewModel.ProjectOwner.PhoneNumber != null && 
                viewModel.ProjectOwner.Name != null && viewModel.ProjectOwner.Summary != null &&
                viewModel.ProjectOwner.Type != null && viewModel.AssociationProof != null &&
                viewModel.ProjectOwner.Address.StreetName != null && viewModel.ProjectOwner.Address.StreetNumber != null && 
                viewModel.ProjectOwner.Address.ZipCode != null && viewModel.ProjectOwner.Address.City != null && 
                viewModel.ProjectOwner.Address.Country != null)
            {   
                if (viewModel.AssociationProof != null)
                {
                    fileNameProof = Path.GetFileName(viewModel.AssociationProof.FileName);
                    var filePath = _env.ContentRootPath + "\\wwwroot\\JustificatifsPP";
                    using (var fileSteam = new FileStream(Path.Combine(filePath, fileNameProof), FileMode.Create))
                    {
                        viewModel.AssociationProof.CopyTo(fileSteam);
                    }
                }

                if (viewModel.AssoLogo != null)
                {
                    fileNameLogo = Path.GetFileName(viewModel.AssoLogo.FileName);
                    var filePath = _env.ContentRootPath + "\\wwwroot\\ImageAssos";
                    using (var fileSteam = new FileStream(Path.Combine(filePath, fileNameLogo), FileMode.Create))
                    {
                        viewModel.AssoLogo.CopyTo(fileSteam);
                    }
                }

                int idAccount = accountService.CreateAccount(viewModel.Account.Mail, viewModel.Account.Password);

                int idProjectOwner = accountService.CreateProjectOwner(idAccount, viewModel.ProjectOwner.Name,
                    viewModel.ProjectOwner.PhoneNumber, viewModel.ProjectOwner.Summary, viewModel.ProjectOwner.Description,
                    viewModel.ProjectOwner.HyperLink, viewModel.ProjectOwner.VolunteerDescritpion, viewModel.ProjectOwner.Partnership, 
                    viewModel.ProjectOwner.Type, fileNameLogo, fileNameProof, 
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

            if (!viewModel.ProjectOwner.ConfidentialityCharter)
                ModelState.AddModelError("ProjectOwner", "Les champs obligatoires doivent être remplis");                   
         
            if (!accountService.IsMailValid(viewModel.Account.Mail))
                ModelState.AddModelError("Account.Mail", "Veuillez saisir un email valide");

            if (viewModel.Account.Password != null && viewModel.Account.Password.Length < 5)
                ModelState.AddModelError("Account.Password", "Veuillez utiliser 5 caractères au minimum pour le mot de passe");
            

            return View(viewModel);
        }

        public IActionResult InscriptionChoice()
        {
            AccountViewModel viewModel = new AccountViewModel { Authentify = HttpContext.User.Identity.IsAuthenticated }; //cookies

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                viewModel.Account = accountService.GetAccount(HttpContext.User.Identity.Name);
                return View(viewModel);
            }
            return View(viewModel);
        }

        public IActionResult ForgetPassword()
        {
            AccountViewModel viewModel = new AccountViewModel { Authentify = HttpContext.User.Identity.IsAuthenticated }; //cookies

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                viewModel.Account = accountService.GetAccount(HttpContext.User.Identity.Name);
                return Redirect("/");
            }
            return View(viewModel);
        }

        public ActionResult Deconnexion()
        {
            HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}