using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Projet2Crowdfunding.Models;

namespace Projet2Crowdfunding.Service
{
    public class AccountService
    {
        private BddContext bddContext;
        public AccountService()
        {
            bddContext = new BddContext();
        }

        public static string EncodeMD5(string motDePasse)
        {
            string motDePasseSel = "Projet2Crowdfunding" + motDePasse + "ASP.NET MVC";
            return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.Default.GetBytes(motDePasseSel)));
        }

        public int CreateAccount(string mail, string password)
        {
            string encodedPassword = EncodeMD5(password);

            Account account = new Account()
            {
                Mail = mail,
                Password = encodedPassword
            };

            this.bddContext.Accounts.Add(account);
            this.bddContext.SaveChanges();
            return account.Id;
        }

        public int CreateParticipant(int idAccount, string lastName, string firstname)
        {
            Participant participant = new Participant()
            {
                FirstName = firstname,
                LastName = lastName,
                Newsletter = false,
                ConfidentialityCharter = true,
                AccountId = idAccount,
                //Gender = null
            };

            Account account = GetAllAccounts().FirstOrDefault(r => r.Id == idAccount);
            if (account != null)
                account.Role = "participant";

            this.bddContext.Participants.Add(participant);
            this.bddContext.SaveChanges();
            return participant.Id;
        }


        public int CreateProjectOwner(int idAccount, string name, string phoneNumber, 
            string summary, string description, string hyperlink, string volunteerDescritpion, 
            string patnerShip, ProjectOwnerType type, string image, string associationProof, string streetNumber,
            string streetName, string zipCode, string city, string country)
        {
            Address address = new Address()
            {
                StreetNumber = streetNumber,
                StreetName = streetName,
                ZipCode = zipCode,
                City = city,
                Country = country
            };

            ProjectOwner projectOwner = new ProjectOwner()
            {
                Name = name,
                PhoneNumber = phoneNumber,
                Summary = summary,
                Description = description,
                HyperLink = hyperlink,
                VolunteerDescritpion = volunteerDescritpion,
                Partnership = patnerShip,
                AssociationProof = "~JustificatifsPP/" + associationProof,
                Image = "~ImageAsso/" + image,
                Type = type,
                Status = AssoStatus.registered,
                Newsletter = false,
                ConfidentialityCharter = true,
                AccountId = idAccount,
                Address = address
            };

            Account account = GetAllAccounts().FirstOrDefault(r => r.Id == idAccount);
            if (account != null)
                account.Role = "participant";

            this.bddContext.ProjectOwners.Add(projectOwner);
            this.bddContext.SaveChanges();
            return projectOwner.Id;
        }

        public int CreateAdministrator(int idAccount, string lastName, string firstName, 
            string phoneNumber, AdministratorType? type)
        {
            Administrator administrator = new Administrator()
            {
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                Type = type,
                AccountId = idAccount
            };

            Account account = GetAllAccounts().FirstOrDefault(r => r.Id == idAccount);
            if (account != null)
                account.Role = "participant";

            this.bddContext.Administrators.Add(administrator);
            this.bddContext.SaveChanges();
            return administrator.Id;

        }

        public Account Login(string mail, string password)
        {
            string encodedPassword = EncodeMD5(password);
            Account account = this.bddContext.Accounts.FirstOrDefault
                (a => a.Mail == mail && a.Password == encodedPassword);
            return account;
        }


        public List<Account> GetAllAccounts()
        {
            List<Account> accountList = this.bddContext.Accounts.ToList();
            return accountList;
        }

        public Account GetAccount(int id)
        {
            return this.bddContext.Accounts.Find(id);
        }

        public Account GetAccount(string idStr)
        {
            int id;
            if (int.TryParse(idStr, out id))
            {
                return this.GetAccount(id);
            }
            return null;
        }

        public Participant GetParticipant(int id)
        {
            return this.bddContext.Participants.Find(id);
        }

        public Participant GetParticipant(string idStr)
        {
            int id;
            if (int.TryParse(idStr, out id))
            {
                return this.GetParticipant(id);
            }
            return null;
        }

        public Participant GetParticipantFromAccountId(int Id)
        {
            Participant participant = this.bddContext.Participants.FirstOrDefault(p => p.AccountId == Id);
            Address address = this.bddContext.Addresses.Find(participant.AddressId);
            participant.Address = address;
            return (participant);
        }

        public ProjectOwner GetProjectOwner(int id)
        { 
            return this.bddContext.ProjectOwners.Find(id);
        }


        public ProjectOwner GetProjectOwner(string idStr)
        {
            int id;
            if (int.TryParse(idStr, out id))
            {
                return this.GetProjectOwner(id);
            }
            return null;
        }

        public ProjectOwner GetProjectOwnerFromAccountId(int Id)
        {
            ProjectOwner projectOwner = this.bddContext.ProjectOwners.FirstOrDefault(p => p.AccountId == Id);
            Address address = this.bddContext.Addresses.Find(projectOwner.AddressId);
            projectOwner.Address = address;
            return (projectOwner);
        }


        public Administrator GetAdministrator(int id)
        {
            return this.bddContext.Administrators.Find(id);
        }

        public Administrator GetAdministrator(string idStr)
        {
            int id;
            if (int.TryParse(idStr, out id))
            {
                return this.GetAdministrator(id);
            }
            return null;
        }
        public Administrator GetAdminFromAccountId(int Id)
        {
            Administrator administrator = this.bddContext.Administrators.FirstOrDefault(p => p.AccountId == Id);
            return (administrator);
        }

        public Project GetProjectFromProjectOwnerId(int Id)
        {
            Project projet = this.bddContext.Projects.FirstOrDefault(p => p.Id ==Id);
            return (projet);
        }


        public void Dispose()
        {
            bddContext.Dispose();
        }

    }
}




  

